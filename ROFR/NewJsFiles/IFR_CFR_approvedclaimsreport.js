
$(document).ready(function () {

    LoadIFRCFRClaims();

});


/* =========================================================
   LOAD DATA
   ========================================================= */

function LoadIFRCFRClaims() {

    $.ajax({

        type: "POST",
        url: "IFR_CFR_approvedclaimsreport.aspx/GetIFRCFRClaims",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (response) {

            var data = JSON.parse(response.d);

            // Visible merged table
            BindTable(data);

            // Hidden flat table for DataTables
            BindExportTable(data);

        },

        error: function (xhr) {

            console.log(xhr.responseText);

        }

    });

}


/* =========================================================
   GET VALUE
   ========================================================= */

function GetValue(value) {

    if (
        value === null ||
        value === undefined
    ) {
        return "";
    }

    return value.toString().trim();
}


/* =========================================================
   EXPORT VALUE
   ========================================================= */

function GetExportValue(value) {

    if (
        value === null ||
        value === undefined
    ) {
        return "";
    }

    return value.toString().trim();

}


/* =========================================================
   FORMAT NUMBER
   ========================================================= */

function FormatNumber(value) {

    if (
        value === null ||
        value === "" ||
        value === undefined
    ) {
        return "0";
    }

    var num = parseFloat(value);

    if (isNaN(num)) {
        return "0";
    }

    return num
        .toFixed(2)
        .replace(/\.00$/, '');

}


/* =========================================================
   BUILD NUMERIC CELLS
   IMPORTANT:
   If next continuation rows contain:
   
   IFR Claims = 0
   IFR Extent = 0
   CFR Claims = 0
   CFR Extent = 0

   then merge all 4 numeric cells vertically.
   ========================================================= */

/* =========================================================
   BUILD NUMERIC CELLS
   ========================================================= */

function BuildNumericCells(
    item,
    side,
    index,
    data,
    groupEnd
) {

    var isLeft = side === "left";


    // =====================================================
    // GET VALUES
    // =====================================================

    var claims = isLeft
        ? item.IFR_DLC_TotalClaims
        : item.IFR_DLC_Total_Claims;

    var extent = isLeft
        ? item.IFR_DLC_TotalExtent
        : item.IFR_DLC_Total_Extent;

    var cfrClaims = isLeft
        ? item.CFR_DLC_TotalClaims
        : item.CFR_DLC_Total_Claims;

    var cfrExtent = isLeft
        ? item.CFR_DLC_TotalExtent
        : item.CFR_DLC_Total_Extent;


    // =====================================================
    // LEFT SIDE
    // =====================================================

    if (isLeft) {

        var currentSno =
            GetValue(item.Sno);

        var currentITDA =
            GetValue(item.ITDA_Name);


        var currentAllZero =
            Number(claims || 0) === 0 &&
            Number(extent || 0) === 0 &&
            Number(cfrClaims || 0) === 0 &&
            Number(cfrExtent || 0) === 0;


        /* =================================================
           IMPORTANT FIX

           If this is a continuation row:

               S.No = blank
               ITDA = blank
               IFR = 0
               IFR Extent = 0
               CFR = 0
               CFR Extent = 0

           DO NOT CREATE THE FOUR ZERO <td>s.

           The previous row already has rowspan.
           ================================================= */

        if (
            currentAllZero &&
            currentSno === "" &&
            currentITDA === ""
        ) {

            return "";
        }


        // =================================================
        // CALCULATE ROWSPAN
        // =================================================

        var rowSpan = 1;

        var nextIndex = index + 1;


        while (nextIndex <= groupEnd) {

            var next = data[nextIndex];

            if (!next) {
                break;
            }


            var nextClaims =
                next.IFR_DLC_TotalClaims;

            var nextExtent =
                next.IFR_DLC_TotalExtent;

            var nextCfrClaims =
                next.CFR_DLC_TotalClaims;

            var nextCfrExtent =
                next.CFR_DLC_TotalExtent;


            var nextAllZero =
                Number(nextClaims || 0) === 0 &&
                Number(nextExtent || 0) === 0 &&
                Number(nextCfrClaims || 0) === 0 &&
                Number(nextCfrExtent || 0) === 0;


            var nextSno =
                GetValue(next.Sno);

            var nextITDA =
                GetValue(next.ITDA_Name);


            if (
                nextAllZero &&
                nextSno === "" &&
                nextITDA === ""
            ) {

                rowSpan++;

                nextIndex++;

            }
            else {

                break;

            }

        }


        // =================================================
        // LEFT NUMERIC CELLS
        // =================================================

        return `

            <td
                class="numeric-cell"
                rowspan="${rowSpan}">
                ${FormatNumber(claims)}
            </td>

            <td
                class="numeric-cell"
                rowspan="${rowSpan}">
                ${FormatNumber(extent)}
            </td>

            <td
                class="numeric-cell"
                rowspan="${rowSpan}">
                ${FormatNumber(cfrClaims)}
            </td>

            <td
                class="numeric-cell"
                rowspan="${rowSpan}">
                ${FormatNumber(cfrExtent)}
            </td>

        `;
    }


    // =====================================================
    // RIGHT SIDE
    // =====================================================

    var rightDistrict =
        GetValue(item.New_DistrictName);


    var rightAllZero =
        Number(claims || 0) === 0 &&
        Number(extent || 0) === 0 &&
        Number(cfrClaims || 0) === 0 &&
        Number(cfrExtent || 0) === 0;


    /* =====================================================
       RIGHT SIDE ZERO ROW

       If New District is blank and all four values are 0,
       don't display the four zero cells.

       Return empty string.
       ===================================================== */

    if (
        rightDistrict === "" &&
        rightAllZero
    ) {

        return "";
    }


    // =====================================================
    // RIGHT NORMAL DATA
    // =====================================================

    return `

        <td class="numeric-cell">
            ${FormatNumber(claims)}
        </td>

        <td class="numeric-cell">
            ${FormatNumber(extent)}
        </td>

        <td class="numeric-cell">
            ${FormatNumber(cfrClaims)}
        </td>

        <td class="numeric-cell">
            ${FormatNumber(cfrExtent)}
        </td>

    `;
}


/* =========================================================
   BIND VISIBLE TABLE
   ========================================================= */

function BindTable(data) {

    /* =====================================================
       HEADER
       ===================================================== */

    $("#dt_Cultivation_tbl thead").html(`

        <tr>

            <th rowspan="2">S.No</th>

            <th rowspan="2">
                ITDA Name
            </th>

            <th rowspan="2">
                Erst While District Name
            </th>

            <th colspan="2">
                IFR (DLC approvals)
            </th>

            <th colspan="2">
                CFR (DLC approvals)
            </th>

            <th rowspan="2">
                S.No
            </th>

            <th rowspan="2">
                New District Name
            </th>

            <th colspan="2">
                IFR (DLC approvals)
            </th>

            <th colspan="2">
                CFR (DLC approvals)
            </th>

        </tr>

        <tr>

            <th>Total Claims</th>
            <th>Total Extent</th>

            <th>Total Claims</th>
            <th>Total Extent</th>

            <th>Total Claims</th>
            <th>Total Extent</th>

            <th>Total Claims</th>
            <th>Total Extent</th>

        </tr>

    `);


    var tbody =
        $("#dt_Cultivation_tbl tbody");


    tbody.empty();


    if (
        !data ||
        data.length === 0
    ) {
        return;
    }


    /* =====================================================
       HELPER
       ===================================================== */

    function IsBlank(value) {

        return GetValue(value) === "";

    }


    /* =====================================================
       GRAND TOTAL
       ===================================================== */

    function IsGrandTotal(item) {

        var sno =
            GetValue(item.Sno)
                .toUpperCase();

        var itda =
            GetValue(item.ITDA_Name)
                .toUpperCase();

        var newDistrict =
            GetValue(item.New_DistrictName)
                .toUpperCase();


        return (

            sno === "TOTAL" ||
            sno === "GRAND TOTAL" ||

            itda === "TOTAL" ||
            itda === "GRAND TOTAL" ||

            newDistrict === "TOTAL" ||
            newDistrict === "GRAND TOTAL"

        );

    }


    /* =====================================================
       LEFT GROUP END
       ===================================================== */

    function GetLeftGroupEnd(startIndex) {

        var startItem =
            data[startIndex];


        if (
            IsGrandTotal(startItem)
        ) {
            return startIndex;
        }


        var endIndex =
            startIndex;


        for (
            var j = startIndex + 1;
            j < data.length;
            j++
        ) {

            var nextItem =
                data[j];


            if (
                IsGrandTotal(nextItem)
            ) {
                break;
            }


            var nextSno =
                GetValue(nextItem.Sno);

            var nextITDA =
                GetValue(nextItem.ITDA_Name);


            if (
                nextSno === "" &&
                nextITDA === ""
            ) {

                endIndex = j;

            }
            else {

                break;

            }

        }


        return endIndex;

    }


    /* =====================================================
       LEFT DISTRICT ROWSPAN
       ===================================================== */

    //function GetLeftDistrictRowSpan(
    //    index,
    //    groupEnd
    //) {

    //    var currentDistrict =
    //        GetValue(
    //            data[index]
    //                .EarstWhile_DistrictName
    //        );


    //    if (
    //        currentDistrict === ""
    //    ) {
    //        return 1;
    //    }


    //    if (
    //        index < groupEnd
    //    ) {

    //        var nextDistrict =
    //            GetValue(
    //                data[index + 1]
    //                    .EarstWhile_DistrictName
    //            );


    //        if (
    //            nextDistrict === ""
    //        ) {
    //            return 2;
    //        }

    //    }


    //    return 1;

    //}


    /* =========================================================
   LEFT DISTRICT ROWSPAN
   Merge district with consecutive blank district rows
   ========================================================= */

    function GetLeftDistrictRowSpan(index, groupEnd) {

        var currentDistrict =
            GetValue(data[index].EarstWhile_DistrictName);

        // No district -> don't create rowspan cell
        if (currentDistrict === "") {
            return 0;
        }

        var rowSpan = 1;

        for (var j = index + 1; j <= groupEnd; j++) {

            var nextDistrict =
                GetValue(data[j].EarstWhile_DistrictName);

            var nextSno =
                GetValue(data[j].Sno);

            var nextITDA =
                GetValue(data[j].ITDA_Name);

            /*
             * Merge ONLY continuation rows.
             *
             * Continuation row:
             * District = blank
             * S.No     = blank
             * ITDA     = blank
             */
            if (
                nextDistrict === "" &&
                nextSno === "" &&
                nextITDA === ""
            ) {

                rowSpan++;

            }
            else {

                break;

            }
        }

        return rowSpan;
    }

    /* =====================================================
       RIGHT DISTRICT ROWSPAN
       ===================================================== */

    function GetRightDistrictRowSpan(
        index,
        groupEnd
    ) {

        var currentDistrict =
            GetValue(
                data[index]
                    .New_DistrictName
            );


        if (
            currentDistrict === ""
        ) {
            return 1;
        }


        if (
            index < groupEnd
        ) {

            var nextDistrict =
                GetValue(
                    data[index + 1]
                        .New_DistrictName
                );


            if (
                nextDistrict === ""
            ) {
                return 2;
            }

        }


        return 1;

    }


    /* =====================================================
       LEFT DISTRICT COVERED
       ===================================================== */

    //function IsLeftDistrictCovered(index) {

    //    if (index <= 0) {
    //        return false;
    //    }


    //    var currentDistrict =
    //        GetValue(
    //            data[index]
    //                .EarstWhile_DistrictName
    //        );


    //    var previousDistrict =
    //        GetValue(
    //            data[index - 1]
    //                .EarstWhile_DistrictName
    //        );


    //    return (
    //        currentDistrict === "" &&
    //        previousDistrict !== ""
    //    );

    //}


    /* =========================================================
   LEFT DISTRICT COVERED BY PREVIOUS ROWSPAN
   ========================================================= */

    function IsLeftDistrictCovered(index) {

        if (index <= 0) {
            return false;
        }

        var currentDistrict =
            GetValue(data[index].EarstWhile_DistrictName);

        var currentSno =
            GetValue(data[index].Sno);

        var currentITDA =
            GetValue(data[index].ITDA_Name);

        /*
         * Only a true continuation row should be covered.
         */
        if (
            currentDistrict !== "" ||
            currentSno !== "" ||
            currentITDA !== ""
        ) {
            return false;
        }

        /*
         * Search backwards for the district cell.
         */
        for (var i = index - 1; i >= 0; i--) {

            var previousDistrict =
                GetValue(data[i].EarstWhile_DistrictName);

            var previousSno =
                GetValue(data[i].Sno);

            var previousITDA =
                GetValue(data[i].ITDA_Name);

            if (
                previousDistrict !== "" &&
                previousSno !== "" &&
                previousITDA !== ""
            ) {
                return true;
            }

            /*
             * If another actual row starts,
             * this is not a continuation.
             */
            if (
                previousSno !== "" ||
                previousITDA !== ""
            ) {
                break;
            }
        }

        return false;
    }

    /* =====================================================
       RIGHT DISTRICT COVERED
       ===================================================== */

    function IsRightDistrictCovered(index) {

        if (index <= 0) {
            return false;
        }


        var currentDistrict =
            GetValue(
                data[index]
                    .New_DistrictName
            );


        var previousDistrict =
            GetValue(
                data[index - 1]
                    .New_DistrictName
            );


        return (
            currentDistrict === "" &&
            previousDistrict !== ""
        );

    }


    /* =====================================================
       RIGHT S.NO
       ===================================================== */

    var rightSnoCounter = 0;


    /* =====================================================
       MAIN LOOP
       ===================================================== */

    var i = 0;


    while (
        i < data.length
    ) {

        var item =
            data[i];


        /* =================================================
           GRAND TOTAL
           ================================================= */

        if (
            IsGrandTotal(item)
        ) {

            var grandTotalRow = $(`
                
                <tr class="grand-total-row">

                    <td class="left-sno"></td>

                    <td class="itda-cell">
                        Grand Total
                    </td>

                   /* <td class="erst-district"></td>*/

                    <td class="numeric-cell">
                        ${FormatNumber(
                item.IFR_DLC_TotalClaims
            )}
                    </td>

                    <td class="numeric-cell">
                        ${FormatNumber(
                item.IFR_DLC_TotalExtent
            )}
                    </td>

                    <td class="numeric-cell">
                        ${FormatNumber(
                item.CFR_DLC_TotalClaims
            )}
                    </td>

                    <td class="numeric-cell">
                        ${FormatNumber(
                item.CFR_DLC_TotalExtent
            )}
                    </td>

                    <td class="right-sno"></td>

                    <td class="new-district">
                        Grand Total
                    </td>

                    <td class="numeric-cell">
                        ${FormatNumber(
                item.IFR_DLC_Total_Claims
            )}
                    </td>

                    <td class="numeric-cell">
                        ${FormatNumber(
                item.IFR_DLC_Total_Extent
            )}
                    </td>

                    <td class="numeric-cell">
                        ${FormatNumber(
                item.CFR_DLC_Total_Claims
            )}
                    </td>

                    <td class="numeric-cell">
                        ${FormatNumber(
                item.CFR_DLC_Total_Extent
            )}
                    </td>

                </tr>

            `);


            tbody.append(
                grandTotalRow
            );


            i++;

            continue;

        }


        /* =================================================
           FIND GROUP
           ================================================= */

        var groupEnd =
            GetLeftGroupEnd(i);


        var groupRowSpan =
            groupEnd - i + 1;


        /* =================================================
           CURRENT VALUES
           ================================================= */

        var sno =
            GetValue(item.Sno);

        var itda =
            GetValue(item.ITDA_Name);

        var district =
            GetValue(
                item.EarstWhile_DistrictName
            );

        var newDistrict =
            GetValue(
                item.New_DistrictName
            );


       

        var rightSno = "";


        if (
            newDistrict !== ""
        ) {

            rightSnoCounter++;

            rightSno =
                rightSnoCounter;

        }


        /* =================================================
           LEFT S.NO
           ================================================= */

        var leftSnoHtml = "";
        var leftITDAHtml = "";


        if (
            i === 0 ||
            !IsBlank(sno) ||
            !IsBlank(itda)
        ) {

            leftSnoHtml = `

                <td
                    class="left-sno"
                    rowspan="${groupRowSpan}">

                    ${sno}

                </td>

            `;


            leftITDAHtml = `

                <td
                    class="itda-cell"
                    rowspan="${groupRowSpan}">

                    ${itda}

                </td>

            `;

        }


        /* =================================================
           LEFT DISTRICT
           ================================================= */

        /* =================================================
   LEFT DISTRICT
   ================================================= */

        var leftDistrictHtml = "";

        var districtValue =
            GetValue(item.EarstWhile_DistrictName);

        var currentSnoValue =
            GetValue(item.Sno);

        var currentITDAValue =
            GetValue(item.ITDA_Name);


        /*
         * Render district only when actual district exists.
         */
        if (districtValue !== "") {

            var leftDistrictSpan =
                GetLeftDistrictRowSpan(
                    i,
                    groupEnd
                );

            leftDistrictHtml = `
        <td
            class="erst-district"
            rowspan="${leftDistrictSpan}">
            ${districtValue}
        </td>
    `;
        }


        /* =================================================
    RIGHT DISTRICT
    ================================================= */

        var rightSnoHtml = "";
        var rightDistrictHtml = "";
        var rightNumericHtml = "";


        /* =================================================
           RIGHT SIDE VALUES
           ================================================= */

        var rightClaims =
            Number(item.IFR_DLC_Total_Claims || 0);

        var rightExtent =
            Number(item.IFR_DLC_Total_Extent || 0);

        var rightCfrClaims =
            Number(item.CFR_DLC_Total_Claims || 0);

        var rightCfrExtent =
            Number(item.CFR_DLC_Total_Extent || 0);


        /* =================================================
           CHECK RIGHT SIDE ALL 4 VALUES ZERO
           ================================================= */

        var rightAllZero =
            rightClaims === 0 &&
            rightExtent === 0 &&
            rightCfrClaims === 0 &&
            rightCfrExtent === 0;


        /* =================================================
           CASE 1:
           RIGHT DISTRICT IS BLANK
           AND ALL 4 VALUES ARE ZERO
           =================================================
        
           Example:
        
           S.No | District | IFR Claims | IFR Extent | CFR Claims | CFR Extent
                |          | 0          | 0          | 0          | 0
        
           Result:
        
           S.No | District | IFR Claims | IFR Extent | CFR Claims | CFR Extent
                |          |            |            |            |
        
           ================================================= */

        if (
            newDistrict === "" &&
            rightAllZero
        ) {

            // Keep empty TDs so columns DON'T shift

            rightSnoHtml = `

        <td class="right-sno"></td>

    `;


            rightDistrictHtml = `

        <td class="new-district"></td>

    `;


            rightNumericHtml = `

        <td class="numeric-cell"></td>

        <td class="numeric-cell"></td>

        <td class="numeric-cell"></td>

        <td class="numeric-cell"></td>

    `;

        }


        /* =================================================
           CASE 2:
           RIGHT DISTRICT HAS DATA
           ================================================= */

        else {

            rightSnoHtml = `

        <td class="right-sno">

            ${rightSno}

        </td>

    `;


            rightDistrictHtml = `

        <td class="new-district">

            ${newDistrict}

        </td>

    `;


            rightNumericHtml =
                BuildNumericCells(
                    item,
                    "right",
                    i,
                    data,
                    groupEnd
                );

        }


        /* =================================================
           CREATE ROW
           ================================================= */

        var tr = $(`
    <tr>

        <!-- LEFT S.NO -->
        ${leftSnoHtml}

        <!-- LEFT ITDA -->
        ${leftITDAHtml}

        <!-- LEFT DISTRICT -->
        ${leftDistrictHtml}

        <!-- LEFT IFR + CFR -->
        ${BuildNumericCells(
            item,
            "left",
            i,
            data,
            groupEnd
        )}

        <!-- RIGHT S.NO -->
        ${rightSnoHtml}

        <!-- RIGHT DISTRICT -->
        ${rightDistrictHtml}

        <!-- RIGHT IFR + CFR -->
        ${rightNumericHtml}

    </tr>
`);


        tbody.append(tr);


        i++;

    }


    /* =====================================================
       ALIGNMENT
       ===================================================== */

    $("#dt_Cultivation_tbl td[rowspan]")
        .css({
            "vertical-align": "middle"
        });


    $("#dt_Cultivation_tbl .left-sno, " +
        "#dt_Cultivation_tbl .right-sno")
        .css({
            "text-align": "center",
            "vertical-align": "middle"
        });


    $("#dt_Cultivation_tbl .itda-cell")
        .css({
            "text-align": "left",
            "vertical-align": "middle",
            "padding-left": "5px"
        });


    $("#dt_Cultivation_tbl .erst-district, " +
        "#dt_Cultivation_tbl .new-district")
        .css({
            "text-align": "left",
            "vertical-align": "middle",
            "padding-left": "5px"
        });


    $("#dt_Cultivation_tbl .numeric-cell")
        .css({
            "text-align": "right",
            "vertical-align": "middle"
        });

}


/* =========================================================
   HIDDEN EXPORT / SEARCH DATATABLE
   ========================================================= */

function BindExportTable(data) {

    var table =
        $("#dtExport_tbl");


    /* -----------------------------------------------------
       DESTROY OLD DATATABLE
       ----------------------------------------------------- */

    if (
        $.fn.DataTable.isDataTable(
            "#dtExport_tbl"
        )
    ) {

        table
            .DataTable()
            .destroy();

    }


    /* -----------------------------------------------------
       HEADER
       ----------------------------------------------------- */

    table.find("thead").html(`

        <tr>

            <th>S.No</th>
            <th>ITDA Name</th>
            <th>Erst While District Name</th>

            <th>IFR Total Claims</th>
            <th>IFR Total Extent</th>

            <th>CFR Total Claims</th>
            <th>CFR Total Extent</th>

            <th>S.No</th>
            <th>New District Name</th>

            <th>IFR Total Claims</th>
            <th>IFR Total Extent</th>

            <th>CFR Total Claims</th>
            <th>CFR Total Extent</th>

        </tr>

    `);


    var tbody =
        table.find("tbody");


    tbody.empty();


    var exportRightSno =
        0;


    /* -----------------------------------------------------
       BUILD FLAT TABLE
       ----------------------------------------------------- */

    $.each(
        data,
        function (i, item) {

            var sno =
                GetExportValue(item.Sno);

            var itda =
                GetExportValue(item.ITDA_Name);

            var district =
                GetExportValue(
                    item.EarstWhile_DistrictName
                );

            var newDistrict =
                GetExportValue(
                    item.New_DistrictName
                );


            var isGrandTotal =
                sno.toUpperCase() === "TOTAL" ||
                sno.toUpperCase() === "GRAND TOTAL" ||
                itda.toUpperCase() === "TOTAL" ||
                itda.toUpperCase() === "GRAND TOTAL" ||
                newDistrict.toUpperCase() === "TOTAL" ||
                newDistrict.toUpperCase() === "GRAND TOTAL";


            if (
                isGrandTotal
            ) {

                tbody.append(`

                    <tr>

                        <td></td>

                        <td>
                            Grand Total
                        </td>

                        <td></td>

                        <td>
                            ${FormatNumber(
                    item.IFR_DLC_TotalClaims
                )}
                        </td>

                        <td>
                            ${FormatNumber(
                    item.IFR_DLC_TotalExtent
                )}
                        </td>

                        <td>
                            ${FormatNumber(
                    item.CFR_DLC_TotalClaims
                )}
                        </td>

                        <td>
                            ${FormatNumber(
                    item.CFR_DLC_TotalExtent
                )}
                        </td>

                        <td></td>

                        <td>
                            Grand Total
                        </td>

                        <td>
                            ${FormatNumber(
                    item.IFR_DLC_Total_Claims
                )}
                        </td>

                        <td>
                            ${FormatNumber(
                    item.IFR_DLC_Total_Extent
                )}
                        </td>

                        <td>
                            ${FormatNumber(
                    item.CFR_DLC_Total_Claims
                )}
                        </td>

                        <td>
                            ${FormatNumber(
                    item.CFR_DLC_Total_Extent
                )}
                        </td>

                    </tr>

                `);

                return;

            }


            if (
                newDistrict !== ""
            ) {

                exportRightSno++;

            }


            tbody.append(`

                <tr>

                    <td>
                        ${sno}
                    </td>

                    <td>
                        ${itda}
                    </td>

                    <td>
                        ${district}
                    </td>

                    <td>
                        ${FormatNumber(
                item.IFR_DLC_TotalClaims
            )}
                    </td>

                    <td>
                        ${FormatNumber(
                item.IFR_DLC_TotalExtent
            )}
                    </td>

                    <td>
                        ${FormatNumber(
                item.CFR_DLC_TotalClaims
            )}
                    </td>

                    <td>
                        ${FormatNumber(
                item.CFR_DLC_TotalExtent
            )}
                    </td>

                    <td>
                        ${newDistrict !== ""
                    ? exportRightSno
                    : ""}
                    </td>

                    <td>
                        ${newDistrict}
                    </td>

                    <td>
                        ${FormatNumber(
                        item.IFR_DLC_Total_Claims
                    )}
                    </td>

                    <td>
                        ${FormatNumber(
                        item.IFR_DLC_Total_Extent
                    )}
                    </td>

                    <td>
                        ${FormatNumber(
                        item.CFR_DLC_Total_Claims
                    )}
                    </td>

                    <td>
                        ${FormatNumber(
                        item.CFR_DLC_Total_Extent
                    )}
                    </td>

                </tr>

            `);

        }
    );


    /* -----------------------------------------------------
       INITIALIZE DATATABLE
       ----------------------------------------------------- */

    var dt =
        table.DataTable({

            destroy: true,

            ordering: false,

            searching: true,

            paging: false,

            info: false,

            autoWidth: false,

            dom: "Bfrtip",

            buttons: [

                "copy",

                "excel",

                "csv",

                {
                    extend: "pdf",
                    orientation: "landscape",
                    pageSize: "A3"
                },

                "print"

            ],

            initComplete: function () {

                var api =
                    this.api();


                /* -----------------------------------------
                   BUTTONS
                   ----------------------------------------- */

                $("#dtButtons")
                    .empty();


                api.buttons()
                    .container()
                    .appendTo(
                        "#dtButtons"
                    );


                /* -----------------------------------------
                   SEARCH
                   ----------------------------------------- */

                $("#dtSearch")
                    .empty();


                $("#dtExport_tbl_filter")
                    .appendTo(
                        "#dtSearch"
                    );


                var searchInput =
                    $("#dtSearch input");


                searchInput
                    .off("keyup input")
                    .on(
                        "keyup input",
                        function () {

                            var value =
                                $(this)
                                    .val()
                                    .toLowerCase()
                                    .trim();


                            /* -----------------------------
                               FILTER VISIBLE TABLE
                               ----------------------------- */

                            $("#dt_Cultivation_tbl tbody tr")
                                .each(
                                    function () {

                                        var rowText =
                                            $(this)
                                                .text()
                                                .toLowerCase();


                                        $(this).toggle(

                                            value === "" ||

                                            rowText.indexOf(
                                                value
                                            ) !== -1

                                        );

                                    }
                                );

                        }
                    );


                /* -----------------------------------------
                   REMOVE DEFAULT DATATABLE POSITIONING
                   ----------------------------------------- */

                $("#dtExport_tbl_filter")
                    .css({
                        "margin": "0"
                    });


                api.columns.adjust();

            }

        });

}


/* =========================================================
   OPTIONAL EXISTING ALIGNMENT FUNCTION
   ========================================================= */

function applyTableAlignment(
    tableId,
    alignmentMap
) {

    $(tableId + " th")
        .removeClass(
            "text-left text-right text-center"
        )
        .addClass(
            "text-center"
        );


    $(tableId + " tbody tr")
        .each(
            function () {

                $(this)
                    .find("td")
                    .each(
                        function (index) {

                            let align =
                                alignmentMap[index];


                            if (
                                align === "left"
                            ) {

                                $(this)
                                    .removeClass()
                                    .addClass(
                                        "text-left"
                                    );

                            }
                            else if (
                                align === "right"
                            ) {

                                $(this)
                                    .removeClass()
                                    .addClass(
                                        "text-right"
                                    );

                            }

                        }
                    );

            }
        );

}


/* =========================================================
   FOOTER ALIGNMENT
   ========================================================= */

function setFooterAlignment(
    tableId,
    alignments
) {

    let footerCells =
        $(`${tableId} tfoot th`);


    Object.keys(
        alignments
    ).forEach(
        function (index) {

            let cell =
                footerCells.eq(index);

            let align =
                alignments[index];


            cell.removeClass(
                "text-left text-right text-center"
            );


            if (
                align === "left"
            ) {

                cell.addClass(
                    "text-left"
                );

            }
            else if (
                align === "right"
            ) {

                cell.addClass(
                    "text-right"
                );

            }
            else {

                cell.addClass(
                    "text-center"
                );

            }

        }
    );

}


