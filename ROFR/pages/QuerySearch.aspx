<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="QuerySearch.aspx.cs" Inherits="ROFR.pages.QuerySearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SQL Query Search</title>=
    <style>
        body {
            font-family: 'Segoe UI';
            background-color: #f4f6f9;
            margin: 20px;
        }

        .container {
            width: 98% !important;
            margin: auto;
            background: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0px 2px 10px rgba(0,0,0,0.15);
            max-width: 100% !important;
        }

        .title {
            color: #0d6efd;
            margin-bottom: 15px;
            font-weight: 700;
        }

        .query-box {
            width: 70%;
            height: 93px;
            font-family: Consolas;
            font-size: 14px;
            padding: 15px;
            border: 1px solid #ccc;
            border-radius: 12px;
            resize: vertical;
        }

        .btnExecute {
            margin-top: 0px;
            background: #198754;
            color: white;
            border: none;
            padding: 10px 30px;
            font-size: 15px;
            border-radius: 5px;
            cursor: pointer;
        }

            .btnExecute:hover {
                background: #157347;
            }

        .btnReset {
            margin-top: 0px;
            background: #1e1414;
            color: white;
            border: none;
            padding: 10px 30px;
            font-size: 15px;
            border-radius: 5px;
            cursor: pointer;
        }

            .btnReset:hover {
                background: #157347;
            }

        .btnExport {
            margin-top: 0px;
            background: #0db3c8;
            color: white;
            border: none;
            padding: 10px 30px;
            font-size: 15px;
            border-radius: 5px;
            cursor: pointer;
        }

            .btnExport:hover {
                background: #157347;
            }

        .div-buttons {
            display: flex;
            justify-content: center;
            gap: 12px;
        }

        .error {
            margin-top: 15px;
            background: #f8d7da;
            color: #842029;
            padding: 10px;
            border-radius: 5px;
        }

        .success {
            margin-top: 15px;
            background: #d1e7dd;
            color: #0f5132;
            padding: 10px;
            border-radius: 5px;
        }

        .grid-container {
            margin-top: 15px;
            overflow: auto;
            max-height: 600px;
        }

        .gridview {
            width: 100%;
            border-collapse: collapse;
        }

            .gridview th {
                background: #06a2d8;
                color: white;
                padding: 10px;
                position: sticky;
                top: 0;
            }

            .gridview td {
                border: 1px solid #ddd;
                padding: 8px;
            }

            .gridview tr:nth-child(even) {
                background: #f8f9fa;
            }

            .gridview tr:hover {
                background: #e9ecef;
            }

        .form-group {
            flex: 1;
        }

        .gridview .pager {
            text-align: center;
            padding: 10px;
        }

            .gridview .pager a,
            .gridview .pager span {
                padding: 5px 10px;
                margin: 2px;
                border: 1px solid #ccc;
                text-decoration: none;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h4 class="title">SQL Query Search</h4>
        <asp:TextBox ID="txtQuery"
            runat="server"
            CssClass="query-box"
            TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <div class="div-buttons">
            <asp:Button ID="btnExecute"
                runat="server"
                Text="Execute"
                CssClass="btnExecute"
                OnClick="btnExecute_Click" />
            <asp:Button ID="btnReset"
                runat="server"
                Text="Reset"
                CssClass="btnReset"
                OnClick="btnReset_Click" />
            <asp:Button ID="btnExport"
                runat="server"
                Text="Export"
                CssClass="btnExport"
                OnClick="btnExport_Click" />
        </div>
        <asp:Label ID="lblMessage"
            runat="server">
        </asp:Label>
        <div class="grid-container">
            <asp:GridView ID="gvResult"
                runat="server"
                CssClass="gridview"
                AutoGenerateColumns="true"
                EmptyDataText="No Records Found"
                GridLines="Both"
                AllowPaging="true"
                PageSize="20"
                OnPageIndexChanging="gvResult_PageIndexChanging">

                <PagerSettings
                    Mode="NumericFirstLast"
                    FirstPageText="First"
                    LastPageText="Last"
                    Position="Bottom" />

            </asp:GridView>
        </div>

    </div>
</asp:Content>
