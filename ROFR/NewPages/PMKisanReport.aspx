<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PMKisanReport.aspx.cs" Inherits="ROFR.NewPages.PMKisanReport" MasterPageFile="~/Masters/ROFR_MASTER.Master" EnableEventValidation="false" %>


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
            padding: 0px;
            background: linear-gradient(180deg,#f7faf8 0%,#eef3f6 100%);
            font-family: Calibri, Arial, sans-serif;
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
        .table-responsive {
            background: var(--card);
            border: 1px solid var(--border);
            border-radius: var(--radius);
            box-shadow: var(--shadow);
            padding: 14px;
            overflow: hidden !important;
            max-height: none !important;
        }

        /* DataTable overall */
        table.dataTable {
            border-collapse: collapse !important;
            border-spacing: 0 !important;
        }

            /* Header */
            table.dataTable thead th {
                background: #2e7d32 !important;
                color: #fff !important;
                text-align: center !important;
                font-size: 17px;
                font-weight: 600;
                padding: 4px !important;
                white-space: nowrap;
                border: 1px solid #d8dee6 !important;
                vertical-align: middle !important;
            }



            /* Body cells */
            table.dataTable tbody td {
                padding: 8px !important;
                border-left: 1px solid #d8dee6 !important;
                border-right: 1px solid #d8dee6 !important;
                border-bottom: 1px solid #d8dee6 !important;
                border-top: none !important;
                background: #fff;
                white-space: nowrap;
            }

            table.dataTable thead tr:last-child th {
                border-bottom: 0 !important;
            }

            table.dataTable tbody tr td:first-child {
                text-align: center !important;
                font-weight: 600 !important;
            }

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

            /* Remove harsh outer duplicate borders */
            table.dataTable tbody tr td:last-child {
                border-right: none !important;
            }

        /* Toolbar */
        .dataTables_wrapper .dt-buttons,
        .dataTables_wrapper .dataTables_filter {
            margin-bottom: 0px;
        }

        div.dt-buttons {
            float: left !important;
            display: flex;
            flex-wrap: wrap;
            gap: 0px;
            max-height: 40px;
        }

        div.dataTables_filter {
            float: right !important;
        }

            div.dataTables_filter label {
                font-weight: 700;
                color: var(--text);
                display: flex;
                align-items: center;
                gap: 8px;
            }

        .dataTables_wrapper .dataTables_filter {
            display: flex;
            align-items: center;
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
            padding: 9px 16px !important;
            font-size: 14px !important;
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
            border: 1px solid #ddd;
            border-radius: 8px;
            overflow: visible;
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

        #ddlFinancialYear {
            width: 180px;
            height: 38px;
            border: 1px solid #ccc;
            border-radius: 8px;
            padding: 6px 10px;
            font-size: 14px;
        }

        .report-toolbar {
            display: flex;
            align-items: center;
            margin-bottom: 12px;
        }

        .toolbar-left {
            width: 35%;
            display: flex;
            align-items: center;
        }

        .toolbar-center {
            width: 35%;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .toolbar-right {
            width: 30%;
            display: flex;
            justify-content: flex-end;
            align-items: center;
        }

        .report-title {
            margin: 0;
            font-size: 20px;
            font-weight: bold;
            color: #1f2937;
        }

        #dtButtons .dt-buttons {
            display: flex;
            gap: 6px;
        }

        #dtSearch .dataTables_filter {
            display: flex;
            align-items: center;
            justify-content: flex-end;
            margin: 0;
        }

            #dtSearch .dataTables_filter label {
                display: flex;
                align-items: center;
                gap: 8px;
                margin: 0;
                font-size: 15px;
                font-weight: 600;
            }

            #dtSearch .dataTables_filter input {
                width: 180px;
                height: 38px;
                border: 1px solid #cfd8d3;
                border-radius: 8px;
                padding: 6px 12px;
                font-size: 14px;
                outline: none;
                background: #fff;
                margin-left: 0;
                transition: .2s;
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
            width: 100% !important;
        }

        .container-fluid {
            width: 90%;
            margin: 0 auto;
        }

        table.dataTable {
            width: 100% !important;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">


    <div class="container-fluid">

        <div class="financial-year-row">

            <label for="ddlFinancialYear"><b>Financial Year :</b></label>

            <select id="ddlFinancialYear"></select>

        </div>

        <div class="report-toolbar">

            <div class="toolbar-left">
                <div id="dtButtons"></div>
            </div>

            <div class="toolbar-center">
                <h5 class="report-title">Annadatha Sukhibhava - PM Kisan</h5>
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

            <table id="dt_Cultivation_tbl" class="table table-bordered display nowrap">

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
    <script src="../NewJsFiles/PMKisanReport.js"></script>

</asp:Content>
