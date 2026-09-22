


<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="IFR_CFR_approvedclaimsreport.aspx.cs"
    Inherits="ROFR.NewPages.IFR_CFR_approvedclaimsreport" 
    MasterPageFile="~/Masters/ROFR_MASTER.Master" %>



<asp:Content ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">
    <link href="../Newcdn/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Newcdn/buttons.dataTables.min.css" rel="stylesheet" />

    <style>
        :root {
            --brand: #2e7d32;
            --brand-dark: #1f5a24;
            --brand-light: #eaf6ec;
            --bg: #f4f7f9;
            --card: #ffffff;
            --text: #1f2937;
            --muted: #6b7280;
            --border: #d8dee6;
            --header-border: #5c9a61;
            --row-hover: #f7fbf8;
            --shadow: 0 8px 24px rgba(15, 23, 42, 0.08);
            --radius: 14px;
        }

        * {
            box-sizing: border-box;
        }

        body {
            margin: 0;
            padding: 5px;
            background: linear-gradient(180deg,#f7faf8 0%,#eef3f6 100%);
            font-family: 'Poppins', sans-serif;
            color: var(--text);
        }

        .container-fluid {
            width: 100%;
            max-width: 1800px;
            margin: 0 auto;
            padding: 0;
        }

        /* Page title */
        h5 {
            margin: 0 0 -35px 0px;
            text-align: center;
            font-size: 18px;
            font-weight: 700;
        }

        /* Table wrapper */
        /*.table-responsive {
            background: var(--card);
            border: 1px solid var(--border);
            border-radius: var(--radius);
            box-shadow: var(--shadow);
            padding: 14px;
            overflow: hidden !important;
            max-height: none !important;
        }*/

        /* DataTable overall */
        table.dataTable {
            border-collapse: collapse !important;
            border-spacing: 0 !important;
        }

            /* Header */
            /*table.dataTable thead th {
                background: #2e7d32 !important;
                color: #fff !important;
                text-align: center !important;
                font-size: 17px;
                font-weight: 600;
                padding: 4px !important;
                white-space: nowrap;
                border: 1px solid #d8dee6 !important;
                vertical-align: middle !important;
            }*/
            table.dataTable thead th {
                background: #2e7d32 !important;
                color: #fff !important;
                text-align: center !important;
                font-size: 11px !important;
                font-weight: 600;
                padding: 2px 4px !important;
                line-height: 14px;
                white-space: nowrap;
                border: 1px solid #d8dee6 !important;
                vertical-align: middle !important;
            }



            /* Body cells */
            /*table.dataTable tbody td {
                padding: 8px !important;
                border-left: 1px solid #d8dee6 !important;
                border-right: 1px solid #d8dee6 !important;
                border-bottom: 1px solid #d8dee6 !important;
                border-top: none !important;
                background: #fff;
                white-space: nowrap;
            }*/
            table.dataTable tbody td {
                font-size: 11px !important;
                padding: 2px 4px !important;
               
                border: 1px solid #d8dee6 !important;
                white-space: nowrap;
            }

            table.dataTable thead tr:last-child th {
                border-bottom: 0 !important;
            }

           /* table.dataTable tbody tr td:first-child {
                text-align: center !important;
                font-weight: 400 !important;
            }*/

            table.dataTable tbody td:nth-child(2) {
                text-align: left !important;
                font-weight: 500 !important;
                color: #243447;
            }


            table.dataTable tbody tr:hover td {
                background: var(--row-hover) !important;
            }

            table.dataTable tbody tr:nth-child(even) td {
                background: #fcfdfd !important;
            }

           

            .dataTables_wrapper .dataTables_filter label {
                display: flex;
                align-items: center;
                gap: 8px;
                font-weight: 600;
                margin: 0;
            }

            .dataTables_wrapper .dataTables_filter input {
                width: 180px !important;
                height: 36px !important;
                margin-left: 0 !important;
                padding: 4px 10px !important;
                border: 1px solid #ccc !important;
                border-radius: 5px !important;
                background: #fff;
                font-size: 14px;
            }

                .dataTables_wrapper .dataTables_filter input:focus {
                    border-color: var(--brand);
                    box-shadow: 0 0 0 4px rgba(46,125,50,.12);
                }

        /* Export buttons */
        .dt-button {
            background: #fff !important;
            color: var(--brand-dark) !important;
            border: 1px solid #cfd8d3 !important;
            border-radius: 10px !important;
            padding: 3px 10px !important;
            font-size: 10px !important;
            min-width: 50px;
            font-weight: 700 !important;
            box-shadow: 0 2px 6px rgba(0,0,0,.04);
            transition: all .2s ease !important;
        }

            .dt-button:hover,
            .dt-button:focus {
                background: var(--brand) !important;
                color: #fff !important;
                border-color: var(--brand) !important;
                transform: translateY(-1px);
            }

            .dt-button:active {
                transform: translateY(0);
            }

        /* Info + pagination */
        .dataTables_wrapper .dataTables_info {
            padding-top: 14px !important;
            color: var(--muted);
            font-size: 14px;
            font-weight: 600;
        }

        .dataTables_wrapper .dataTables_paginate {
            padding-top: 10px !important;
        }

            .dataTables_wrapper .dataTables_paginate .paginate_button {
                border-radius: 8px !important;
                border: 1px solid transparent !important;
                padding: 6px 12px !important;
                margin-left: 4px !important;
                color: var(--brand-dark) !important;
                background: #fff !important;
            }

                .dataTables_wrapper .dataTables_paginate .paginate_button.current,
                .dataTables_wrapper .dataTables_paginate .paginate_button.current:hover {
                    background: var(--brand) !important;
                    color: #fff !important;
                    border-color: var(--brand) !important;
                }

                .dataTables_wrapper .dataTables_paginate .paginate_button:hover {
                    background: var(--brand-light) !important;
                    color: var(--brand-dark) !important;
                    border-color: #b8d6bd !important;
                }

        .preloader {
            display: none;
            position: fixed;
            inset: 0;
            background: rgba(255,255,255,.72);
            backdrop-filter: blur(2px);
            z-index: 9999;
        }

        .spinner {
            position: absolute;
            top: 45%;
            left: 50%;
            margin-left: -28px;
            width: 56px;
            height: 56px;
            border: 6px solid #d7e3d8;
            border-top: 6px solid var(--brand);
            border-radius: 50%;
            animation: spin .8s linear infinite;
            box-shadow: 0 0 0 8px rgba(46,125,50,.05);
        }

        @keyframes spin {
            to {
                transform: rotate(360deg);
            }
        }

        #loading-msg {
            position: absolute;
            top: 55%;
            left: 50%;
            transform: translateX(-50%);
        }

            #loading-msg img {
                width: 72px;
                height: auto;
                opacity: .95;
            }

        /* Responsive */
        @media (max-width:992px) {
            body {
                padding: 14px;
            }

            h5 {
                font-size: 24px;
                padding: 16px;
            }

            .table-responsive {
                overflow: hidden;
            }

            div.dt-buttons,
            div.dataTables_filter {
                float: none !important;
            }

            .dataTables_wrapper .dt-buttons {
                margin-bottom: 10px;
            }

            div.dataTables_filter label {
                justify-content: flex-start;
                flex-wrap: wrap;
            }

            .dataTables_wrapper .dataTables_filter input {
                min-width: 180px;
                width: 100%;
            }
        }

        @media (max-width:576px) {
            h5 {
                font-size: 20px;
                line-height: 0.5;
            }

            .dt-button {
                padding: 4px 8px !important;
                font-size: 13px !important;
            }
        }

        table.dataTable thead .sorting_disabled {
            padding-top: 0px !important;
            padding-bottom: 0px !important;
        }

        
        #tableContainer {
    width: 100%;
    border: 1px solid #ddd;
    border-radius: 8px;
    background: #fff;
    overflow-x: auto;
    overflow-y: visible;
}

        .custom-toolbar {
            display: flex;
            align-items: center;
            gap: 10px;
            margin-bottom: 10px;
            float: left;
        }

            .custom-toolbar label {
                font-weight: 600;
                margin-bottom: 0;
            }

        #ddlFinancialYear {
            width: 180px;
            height: 36px;
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 4px 8px;
        }

        .financial-year-row {
            display: flex;
            align-items: center;
            gap: 10px;
            margin-bottom: 10px;
        }

            .financial-year-row label {
                font-size: 16px;
                font-weight: 600;
                margin: 0;
            }



        .report-toolbar {
            display: flex;
            align-items: center;
            justify-content: space-between;
            gap: 10px;
            margin-bottom: 12px;
            width: 100%;
        }

        /* LEFT : Export Buttons */
        .toolbar-left {
            width: 25%;
            display: flex;
            align-items: center;
        }

        #dtButtons .dt-buttons {
            display: flex !important;
            flex-wrap: nowrap !important;
            gap: 4px;
        }

        div.dt-buttons {
            float: none !important;
            display: flex !important;
            flex-wrap: nowrap !important;
            gap: 4px;
            max-height: none;
        }

        /* Export Buttons */
        .dt-button {
            background: #fff !important;
            color: #1f5a24 !important;
            border: 1px solid #cfd8d3 !important;
            border-radius: 6px !important;
            padding: 4px 10px !important;
            font-size: 11px !important;
            font-weight: 600 !important;
            min-width: 60px;
            margin: 0 !important;
            box-shadow: none !important;
        }

            .dt-button:hover {
                background: #2e7d32 !important;
                color: #fff !important;
            }

        /* CENTER : TITLE */

        .toolbar-center {
            width: 50%;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .report-title {
            margin: 0;
            font-size: 16px;
            font-weight: 700;
            color: #1f2937;
            white-space: nowrap;
        }

        /* RIGHT : SEARCH */

        .toolbar-right {
            width: 25%;
            display: flex;
            justify-content: flex-end;
            align-items: center;
        }

        #dtSearch .dataTables_filter {
            margin: 0;
        }

            #dtSearch .dataTables_filter label {
                display: flex;
                align-items: center;
                gap: 6px;
                margin: 0;
                font-size: 13px;
                font-weight: 600;
                margin-right: 0;
            }

            #dtSearch .dataTables_filter input {
                width: 240px !important; /* increase width */
                height: 30px !important;
                padding: 4px 10px !important;
                font-size: 12px !important;
                border: 1px solid #cfd8d3 !important;
                border-radius: 4px !important;
                margin-left: 0 !important;
            }

                #dtSearch .dataTables_filter input:focus {
                    border-color: #2e7d32;
                    outline: none;
                }

        /* Remove DataTables float */

        .dataTables_wrapper .dt-buttons,
        .dataTables_wrapper .dataTables_filter {
            float: none !important;
        }

        #dtButtons .dt-buttons {
            gap: 2px;
        }

        #dtSearch .dataTables_filter {
            display: flex;
            align-items: center;
            justify-content: flex-end;
            margin: 0;
        }




            #dtSearch .dataTables_filter input:focus {
                border-color: #2e7d32;
                box-shadow: 0 0 0 3px rgba(46,125,50,.15);
            }

        /* Hide only the duplicate header inside scroll body */
        .dataTables_scrollBody thead {
            visibility: collapse !important;
        }

            .dataTables_scrollBody thead th {
                padding: 0 !important;
                margin: 0 !important;
                height: 0 !important;
                line-height: 0 !important;
                border: none !important;
                background: transparent !important;
            }
        /* Keep the visible header normal */
        table.dataTable {
            margin-left: 0 !important;
            width: 100% !important;
        }

        /* Erst While District Name */
        #dt_Cultivation_tbl tbody td:nth-child(3) {
            text-align: left !important;
            padding-left: 3px !important;
        }

        /* New District Name */
        #dt_Cultivation_tbl tbody td:nth-child(9) {
            text-align: left !important;
            padding-left: 3px !important;
        }

        .total-row td {
            font-weight: bold !important;
            font-size: 12px !important;
        }

        /* GRAND TOTAL ROW */
        #dt_Cultivation_tbl tbody tr.grand-total-row td {
            background: #f2f2f2 !important;
            font-weight: 700 !important;
        }

            /* First S.No - normal */
            #dt_Cultivation_tbl tbody tr.grand-total-row td:first-child {
                font-weight: 400 !important;
            }

            /* Second S.No - normal */
            #dt_Cultivation_tbl tbody tr.grand-total-row td:nth-child(8) {
                font-weight: 400 !important;
            }

            /* Grand Total label */
            #dt_Cultivation_tbl tbody tr.grand-total-row td:nth-child(2) {
                font-weight: 700 !important;
                text-align: left !important;
            }

            /* Right Grand Total label */
            #dt_Cultivation_tbl tbody tr.grand-total-row td:nth-child(9) {
                font-weight: 700 !important;
            }
            /* Grand Total text */
            .grand-total-row td:nth-child(2) {
                text-align: left !important;
            }
       

            /* Left table numeric values */
            .grand-total-row td:nth-child(4),
            .grand-total-row td:nth-child(5),
            .grand-total-row td:nth-child(6),
            .grand-total-row td:nth-child(7),
            
            /* Right table numeric values */
            .grand-total-row td:nth-child(10),
            .grand-total-row td:nth-child(11),
            .grand-total-row td:nth-child(12),
            .grand-total-row td:nth-child(13) {
                text-align: right !important;
            }


       
        .table td {
            padding: 0.75rem;
            vertical-align: middle;
            border-top: 1px solid #dee2e6;
        }
        /*vertical-align: top;*/

        /* ITDA Name - merged vertically and left aligned */
        #dt_Cultivation_tbl tbody td:nth-child(2) {
            text-align: left !important;
            vertical-align: middle !important;
            padding-left: 5px !important;
        }

        /* S.No - merged vertically and centered */
        #dt_Cultivation_tbl tbody td:nth-child(1) {
            text-align: center !important;
            vertical-align: middle !important;
            font-weight: 400 !important;
        }

        #dt_Cultivation_tbl tbody td.left-sno {
            text-align: center !important;
            vertical-align: middle !important;
            font-weight: 400 !important;
        }

        #dt_Cultivation_tbl tbody td.itda-cell {
            text-align: left !important;
            vertical-align: middle !important;
            padding-left: 5px !important;
            font-weight: 500 !important;
        }

        /* =========================================
   ERSTWHILE DISTRICT
   ========================================= */

        #dt_Cultivation_tbl tbody td.erst-district {
            text-align: left !important;
            vertical-align: middle !important;
            padding-left: 5px !important;
        }


        /* =========================================
   NEW DISTRICT
   ========================================= */

        #dt_Cultivation_tbl tbody td.new-district {
            text-align: left !important;
            vertical-align: middle !important;
            padding-left: 5px !important;
        }


        /* =========================================
          ALL TABLE CELLS
    ========================================= */

        #dt_Cultivation_tbl tbody td {
            vertical-align: middle !important;
        }
            /* Numeric values - right aligned */
            #dt_Cultivation_tbl tbody td.numeric-cell {
                text-align: right !important;
                vertical-align: middle !important;
            }

            /* Right-side S.No */
            #dt_Cultivation_tbl tbody td.right-sno {
                text-align: center !important;
                vertical-align: middle !important;
                font-weight: 400 !important;
            }
            /* =========================================================
   VISIBLE REPORT TABLE
   ========================================================= */

#dt_Cultivation_tbl {
    width: 100% !important;
    border-collapse: collapse !important;
    border-spacing: 0 !important;
    table-layout: auto;
    margin: 0 !important;
    background: #fff;
}


#dt_Cultivation_tbl thead th {
    background: #2e7d32 !important;
    color: #fff !important;
    text-align: center !important;
    vertical-align: middle !important;

    font-size: 11px !important;
    font-weight: 600 !important;

    padding: 4px !important;

    border: 1px solid #d8dee6 !important;

    line-height: 14px;
}


#dt_Cultivation_tbl tbody td {
    font-size: 11px !important;

    padding: 4px 5px !important;

    border: 1px solid #21252954 !important;


    vertical-align: middle !important;

    white-space: nowrap;

    background: #fff;
}


/* S.No */

#dt_Cultivation_tbl tbody td.left-sno,
#dt_Cultivation_tbl tbody td.right-sno {
    text-align: center !important;
    vertical-align: middle !important;
}


/* ITDA */

#dt_Cultivation_tbl tbody td.itda-cell {
    text-align: left !important;
    vertical-align: middle !important;
    padding-left: 5px !important;
}


/* Erstwhile District */

#dt_Cultivation_tbl tbody td.erst-district {
    text-align: left !important;
    vertical-align: middle !important;
    padding-left: 5px !important;
}


/* New District */

#dt_Cultivation_tbl tbody td.new-district {
    text-align: left !important;
    vertical-align: middle !important;
    padding-left: 5px !important;
}


/* Numbers */

#dt_Cultivation_tbl tbody td.numeric-cell {
    text-align: right !important;
    vertical-align: middle !important;
}


/* Grand Total */

#dt_Cultivation_tbl tbody tr.grand-total-row td {
    background: #f2f2f2 !important;
    font-weight: 700 !important;
}


/* Keep grand total S.No normal */

#dt_Cultivation_tbl tbody tr.grand-total-row td:first-child,
#dt_Cultivation_tbl tbody tr.grand-total-row td:nth-child(8) {
    font-weight: 400 !important;
}

    </style>

</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">


    <div class="container-fluid">

        

        <div class="report-toolbar">

            <div class="toolbar-left">
                <div id="dtButtons"></div>
            </div>

            <div class="toolbar-center">
                <h5 class="report-title">IFR & CFR Approved Claims Report of Erstwhile Districts Vs New Districts </h5>
            </div>

            <div class="toolbar-right">
                <div id="dtSearch"></div>
            </div>

        </div>

        <div class="preloader">

            <div class="spinner"></div>

            <span id="loading-msg">

                <img src="../Rofrnewassets/images/aplogo.png" />

            </span>

        </div>

        <div id="tableContainer">

            <table id="dt_Cultivation_tbl" class="report-table">
                <thead></thead>
                <tbody></tbody>
            </table>

            <table id="dtExport_tbl" style="display: none;">
                <thead></thead>
                <tbody></tbody>
            </table>

        </div>

    </div>

    <script src="../Newcdn/jquery-3.5.1.js"></script>

<script src="../Newcdn/dataTables.min.js"></script>
<script src="../Newcdn/dataTables.buttons.min.js"></script>

<script src="../Newcdn/jszip.min.js"></script>

<script src="../Newcdn/pdfmake0.1.18.min.js"></script>
<script src="../Newcdn/vfs_fonts.js"></script>

<script src="../Newcdn/html5.min.js"></script>
<script src="../Newcdn/print.min.js"></script>

<script src="../NewJsFiles/IFR_CFR_approvedclaimsreport.js"></script>

</asp:Content>
