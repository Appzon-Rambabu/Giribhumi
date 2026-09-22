<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GramaSabhaRegistration.aspx.cs" Inherits="FRA.GramaSabhaRegistration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Grama Sabha</title>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" rel="stylesheet" />

    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: 'Segoe UI';
        }

        body {
            background: #f5f7f9;
        }

        .main-container {
            display: flex;
            min-height: 100vh;
        }

        /* SIDEBAR */

        .sidebar {
            width: 260px;
            background: linear-gradient(180deg,#015c36,#00361f);
            color: white;
            padding: 20px;
        }

        .logo {
            display: flex;
            align-items: center;
            gap: 12px;
            margin-bottom: 40px;
        }

        .logo img {
            width: 50px;
            height: 50px;
        }

        .logo h2 {
            font-size: 28px;
        }

        .menu {
            list-style: none;
        }

        .menu li {
            padding: 14px 15px;
            border-radius: 10px;
            margin-bottom: 10px;
            cursor: pointer;
            transition: 0.3s;
        }

        .menu li:hover,
        .menu li.active {
            background: rgba(255,255,255,0.12);
        }

        .menu li i {
            margin-right: 12px;
        }

        /* CONTENT */

        .content {
            flex: 1;
            padding: 25px;
        }

        .topbar {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 25px;
        }

        .breadcrumb {
            color: #666;
            font-size: 14px;
        }

        .user-box {
            display: flex;
            align-items: center;
            gap: 12px;
        }

        .user-box i {
            font-size: 20px;
        }

        .page-title h1 {
            font-size: 40px;
            margin-bottom: 10px;
        }

        .page-title h3 {
            color: #0d7a44;
            margin-bottom: 25px;
        }

        /* CARD */

        .card {
            background: white;
            border-radius: 14px;
            padding: 25px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.08);
        }

        .section-title {
            color: #066738;
            font-size: 28px;
            margin-bottom: 25px;
            font-weight: 600;
        }

        .form-row {
            display: flex;
            gap: 20px;
            margin-bottom: 20px;
        }

        .form-group {
            flex: 1;
        }

        label {
            display: block;
            margin-bottom: 8px;
            font-weight: 600;
            color: #333;
        }

        .required {
            color: red;
        }

        input[type=text],
        input[type=date],
        select {
            width: 100%;
            height: 48px;
            border: 1px solid #d6d6d6;
            border-radius: 8px;
            padding: 10px;
            font-size: 15px;
        }

        .radio-group {
            display: flex;
            gap: 25px;
            margin-top: 12px;
        }

        .checkbox-list {
            display: grid;
            grid-template-columns: repeat(4,1fr);
            gap: 15px;
            background: #fafafa;
            padding: 20px;
            border-radius: 10px;
            border: 1px solid #e3e3e3;
        }

        .upload-box input {
            padding: 10px;
        }

        /* TABLE */

        .table-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-top: 30px;
            margin-bottom: 20px;
        }

        .btn-add {
            background: #0b7d45;
            color: white;
            border: none;
            padding: 12px 20px;
            border-radius: 8px;
            cursor: pointer;
            font-size: 15px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        table th {
            background: #f4f4f4;
            padding: 14px;
            text-align: left;
            font-size: 14px;
        }

        table td {
            padding: 12px;
            border-bottom: 1px solid #ececec;
        }

        table input,
        table select {
            height: 42px;
        }

        .info-box {
            background: #eef9f1;
            border: 1px solid #c9e9d1;
            color: #0a6f3d;
            padding: 18px;
            border-radius: 10px;
            margin-top: 25px;
            font-size: 15px;
        }

        /* FOOTER BUTTONS */

        .footer-buttons {
            display: flex;
            justify-content: flex-end;
            gap: 15px;
            margin-top: 30px;
        }

        .btn {
            padding: 14px 26px;
            border-radius: 10px;
            border: none;
            font-size: 16px;
            cursor: pointer;
        }

        .btn-cancel {
            background: #f0f0f0;
        }

        .btn-save {
            background: #0b7d45;
            color: white;
        }

        @media(max-width:1200px) {

            .form-row {
                flex-direction: column;
            }

            .checkbox-list {
                grid-template-columns: repeat(2,1fr);
            }

            table {
                display: block;
                overflow-x: auto;
            }
        }
    </style>

</head>

<body>

    <form id="form1" runat="server">

        <div class="main-container">

            <!-- SIDEBAR -->

            <div class="sidebar">

                <div class="logo">
                    <img src="images/logo.png" />
                    <div>
                        <h2>GIRIBHUMI</h2>
                        <p>Forest Rights Act</p>
                    </div>
                </div>

                <ul class="menu">
                    <li><i class="fa fa-home"></i>Dashboard</li>

                    <li class="active">
                        <i class="fa fa-users"></i>Grama Sabha
                    </li>

                    <li><i class="fa fa-sitemap"></i>FRC Committee</li>
                    <li><i class="fa fa-file"></i>Claims</li>
                    <li><i class="fa fa-map"></i>Survey Management</li>
                    <li><i class="fa fa-check-circle"></i>SDLC</li>
                    <li><i class="fa fa-building"></i>DLC</li>
                    <li><i class="fa fa-id-card"></i>FRA Cell</li>
                    <li><i class="fa fa-chart-bar"></i>Reports</li>
                    <li><i class="fa fa-user-cog"></i>User Management</li>
                </ul>

            </div>

            <!-- CONTENT -->

            <div class="content">

                <div class="topbar">

                    <div class="breadcrumb">
                        Home > Grama Sabha > Register Grama Sabha
                    </div>

                    <div class="user-box">
                        <i class="fa fa-bell"></i>
                        <i class="fa fa-user-circle"></i>
                        <span>GS User</span>
                    </div>

                </div>

                <div class="page-title">
                    <h1>Register Grama Sabha</h1>
                    <h3>Step 1 : Registration of Grama Sabha</h3>
                </div>

                <!-- MAIN CARD -->

                <div class="card">

                    <!-- SECTION -->

                    <div class="section-title">
                        Grama Sabha Details
                    </div>

                    <div class="form-row">

                        <div class="form-group">
                            <label>
                                Registration Type <span class="required">*</span>
                            </label>

                            <div class="radio-group">

                                <label>
                                    <asp:RadioButton ID="rbNew"
                                        runat="server"
                                        GroupName="RegType"
                                        Checked="true" />
                                    New
                                </label>

                                <label>
                                    <asp:RadioButton ID="rbExisting"
                                        runat="server"
                                        GroupName="RegType" />
                                    Existing
                                </label>

                            </div>

                        </div>

                        <div class="form-group">
                            <label>
                                Grama Sabha Name <span class="required">*</span>
                            </label>

                            <asp:TextBox ID="txtGramaSabhaName"
                                runat="server"
                                placeholder="Enter Grama Sabha Name">
                            </asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>
                                Date of Grama Sabha Resolution
                                <span class="required">*</span>
                            </label>

                            <asp:TextBox ID="txtResolutionDate"
                                runat="server"
                                TextMode="Date">
                            </asp:TextBox>
                        </div>

                    </div>

                    <!-- SECOND ROW -->

                    <div class="form-row">

                        <div class="form-group upload-box">

                            <label>
                                Upload Grama Sabha Resolution
                                <span class="required">*</span>
                            </label>

                            <asp:FileUpload ID="fuResolution"
                                runat="server" />

                        </div>

                        <div class="form-group">

                            <label>
                                Select Multiple Revenue Villages
                                <span class="required">*</span>
                            </label>

                            <asp:ListBox ID="lstVillages"
                                runat="server"
                                SelectionMode="Multiple"
                                Height="140px">

                                <asp:ListItem>Pedda Gudem</asp:ListItem>
                                <asp:ListItem>Chinna Gudem</asp:ListItem>
                                <asp:ListItem>Rampuram</asp:ListItem>
                                <asp:ListItem>Kothapalli</asp:ListItem>
                                <asp:ListItem>Lingalavalasa</asp:ListItem>
                                <asp:ListItem>Vegavaram</asp:ListItem>

                            </asp:ListBox>

                        </div>

                    </div>

                    <!-- FRC MEMBERS -->

                    <div class="table-header">

                        <div class="section-title">
                            FRC Members Details
                        </div>

                        <button type="button" class="btn-add">
                            <i class="fa fa-plus"></i> Add Member
                        </button>

                    </div>

                    <table>

                        <thead>

                            <tr>
                                <th>S.No</th>
                                <th>Name</th>
                                <th>Age</th>
                                <th>Gender</th>
                                <th>Father Name</th>
                                <th>DOB</th>
                                <th>Aadhaar Number</th>
                                <th>Designation</th>
                                <th>PVTG / Non PVTG</th>
                                <th>Action</th>
                            </tr>

                        </thead>

                        <tbody>

                            <tr>

                                <td>1</td>

                                <td>
                                    <asp:TextBox runat="server"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox runat="server"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:DropDownList runat="server">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:DropDownList>
                                </td>

                                <td>
                                    <asp:TextBox runat="server"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox runat="server"
                                        TextMode="Date">
                                    </asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox runat="server"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:DropDownList runat="server">
                                        <asp:ListItem>Chairperson</asp:ListItem>
                                        <asp:ListItem>Member</asp:ListItem>
                                    </asp:DropDownList>
                                </td>

                                <td>
                                    <asp:DropDownList runat="server">
                                        <asp:ListItem>PVTG</asp:ListItem>
                                        <asp:ListItem>Non-PVTG</asp:ListItem>
                                    </asp:DropDownList>
                                </td>

                                <td>
                                    <i class="fa fa-trash"
                                        style="color:red; cursor:pointer;">
                                    </i>
                                </td>

                            </tr>

                        </tbody>

                    </table>

                    <!-- INFO -->

                    <div class="info-box">

                        Minimum 6 members and maximum 15 members are allowed.
                        At least 1/3 of the committee should be female members.

                    </div>

                    <!-- FOOTER BUTTONS -->

                    <div class="footer-buttons">

                        <button type="button" class="btn btn-cancel">
                            Cancel
                        </button>

                        <asp:Button ID="btnSave"
                            runat="server"
                            Text="Save & Create Login"
                            CssClass="btn btn-save" />

                    </div>

                </div>

            </div>

        </div>

    </form>

</body>
</html>