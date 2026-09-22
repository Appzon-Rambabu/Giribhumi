<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CultivationReport.aspx.cs"
    Inherits="ROFR.NewPages.CultivationReport" MasterPageFile="~/Masters/ROFR_MASTER.Master" EnableEventValidation="false" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">
    <title>Cultivation Report</title>

    <%--<link href="../Newcdn/NewCss/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="../Newcdn/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Newcdn/buttons.dataTables.min.css" rel="stylesheet" />

    <style>

        .dataTables_scrollHeadInner table {
            margin-bottom: 0 !important;
        }
        .dataTables_scrollHead {
            border-bottom: 0 !important;
        }

        .dataTables_scrollBody table {
            margin-top: 0 !important;
        }

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

        .report-page * {
    box-sizing: border-box;
}
        .report-page {
    padding: 24px;
    background: linear-gradient(180deg,#f7faf8 0%,#eef3f6 100%);
    
    font-family: 'Poppins', sans-serif;
    color: var(--text);
}

        /*body {
            margin: 0;
            padding: 24px;
            background: linear-gradient(180deg,#f7faf8 0%,#eef3f6 100%);
            font-family: Calibri, Arial, sans-serif;
            color: var(--text);
        }*/

        .report-page .container-fluid {
    width: 100%;
    max-width: 1800px;
    margin: 0 auto;
    padding: 0;
}

        /* Page title */
         .report-page h5 {
            margin: 0 0 -35px 0px;
            text-align: center;
            font-size: 18px;
            font-weight: 700;
        }

        /* Table wrapper */
        .table-responsive {
    background: var(--card);
    border: none !important;
    border-radius: 0 !important;
    box-shadow: none !important;
    padding: 0 !important;
    overflow: hidden !important;
    max-height: none !important;
}


        /* DataTable overall */
        table.dataTable {
            width: 100% !important;
            border-collapse: separate !important;
            border-spacing: 0 !important;
            white-space: nowrap;
            /*margin-top: 8px !important;*/
            margin-bottom: 0 !important;
        }

            /* Header */
            table.dataTable thead th {
                position: static !important;
                background: linear-gradient(180deg,var(--brand) 0%,var(--brand-dark) 100%) !important;
                color: #fff !important;
                text-align: center !important;
                vertical-align: middle !important;
                font-size: 17px !important;
                font-weight: 600 !important;
                padding: 14px 10px !important;
            }

                table.dataTable thead th:first-child {
                    border-top-left-radius: 10px;
                }

                table.dataTable thead th:last-child {
                    border-top-right-radius: 10px;
                    border-right: none !important;
                }

            /* Body cells */
            table.dataTable tbody td {
                background: #fff !important;
                color: var(--text);
                border-right: 1px solid var(--border) !important;
                border-bottom: 1px solid var(--border) !important;
                padding: 0px 2px 3px !important;
                font-size: 14px !important;
                font-weight: 500 !important;
                text-align: right;
                /*transition: background-color .2s ease, transform .15s ease;*/
                
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
        /* TOTAL ROW - BOLD */
        #dt_Cultivation_tbl tbody tr:last-child td {
            font-weight: 700 !important;
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

        .dataTables_wrapper .dataTables_filter input {
            margin-left: 0 !important;
            border: 1px solid var(--border);
            border-radius: 10px;
            padding: 9px 12px;
            min-width: 220px;
            outline: none;
            font-size: 14px;
            background: #fff;
            transition: border-color .2s ease, box-shadow .2s ease;
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

        /*Scroll containers*/


        .dataTables_scrollHead {
            overflow: hidden !important;
            border: none !important;
            margin: 0 !important;
            padding: 0 !important;
        }

        .dataTables_scrollHeadInner {
            width: 100% !important;
        }

            .dataTables_scrollHeadInner table {
                margin: 0 !important;
                border-bottom: 0 !important;
            }

        .dataTables_scrollBody {
            height: 500px !important;
            overflow-y: auto !important;
            overflow-x: auto !important;
            border-top: 0 !important;
        }

            .dataTables_scrollBody table {
                margin-top: 0 !important;
            }

        /* Preloader */
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
            .report-page {
                padding: 14px;
            }

            .report-page h5 {
                font-size: 24px;
                padding: 16px;
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

            table.dataTable thead th {
                font-size: 15px !important;
                /*padding: 12px 8px !important;*/
            }

            table.dataTable tbody td {
                font-size: 14px !important;
                /*padding: 12px 8px !important;*/
            }
        }

        @media (max-width:576px) {
             .report-page h5 {
                font-size: 20px;
                line-height: 0.5;
            }

            .dt-button {
                padding: 4px 8px !important;
                font-size: 13px !important;
            }
        }



        .dataTables_scrollHead table thead tr {
            height: auto !important;
        }



        table.dataTable thead .sorting_disabled {
            padding-top: 0px !important;
            padding-bottom: 0px !important;
        }

        
#tableContainer {
    border: none !important;
    border-radius: 0 !important;
    box-shadow: none !important;
    overflow: hidden;
}

        div.dataTables_scroll {
            border: none !important;
        }

        div.dataTables_scrollHead {
            margin: 0 !important;
            padding: 0 !important;
            border: none !important;
        }

        div.dataTables_scrollBody {
            border-top: none !important;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

    <div class="report-page">
    <div class="container-fluid">

        <h5>Cropping Pattern of Individual Forest Right Lands
        </h5>

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
    </div>
    <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
    <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <script src="../Newcdn/vfs_fonts.js"></script>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    <script src="../NewJsFiles/CultivationReport.js"></script>

</asp:Content>
