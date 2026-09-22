<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="VillageDataUpdate.aspx.cs" Inherits="ROFR.NewPages.VillageDataUpdate" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Village Validation Data</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
     <link href="../Newcdn/NewCss/bootstrap.min.css" rel="stylesheet" />
     <script src="../Newcdn/bootstrap.bundle.min.js"></script>
   
    <style>
        .card {
            margin-top: 20px;
        }

        .section-title {
            font-weight: bold;
            margin-top: 20px;
            font-size: 1.2rem;
        }

        #formSection input.form-control {
            width: 150px;
        }

        #formSection {
            width: 70%;
            margin: 0 auto;
        }

        .container-fluid1 {
            padding-right: 336px !important;
            width: 100%;
            padding-right: 336px;
            padding-left: 15px;
            margin-right: auto;
            margin-left: auto;
        }

        .container {
            max-width: 1476px !important;
        }

        .Gpwidth {
            -ms-flex: 0 0 25%;
            flex: 0 0 25%;
            max-width: 19%;
        }

        .content-section {
            max-height: 485px;
            height: 347px;
            overflow: hidden;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="container py-4">--%>
    <h2 class="row g-3 mb-3 justify-content-center">Village Validation Data</h2>

    <!-- Dropdown Row -->
    <div class="row g-3 mb-3">
        <div class=" row col-md-12 col-lg-12 justify-content-center">
            <div class="col-md-2 col-lg-2">
                <label class="form-label">District</label>
                <select id="districtDropdown" class="form-select" style="width: 150px;">
                    <option value="">Select District</option>
                </select>
            </div>
            <div class="col-md-2 col-lg-2">
                <label class="form-label">Mandal</label>
                <select id="mandalDropdown" class="form-select" style="width: 150px;">
                    <option value="">Select Mandal</option>
                </select>
            </div>
            <div class="col-md-2 col-lg-3 Gpwidth">
                <label class="form-label">Panchayati</label>
                <select id="gpDropdown" class="form-select" style="width: 150px;">
                    <option value="">Select Panchayati</option>
                </select>
            </div>
            <div class="col-md-2 col-lg-2 text-left">
                <label class="form-label">Village</label>
                <select id="villageDropdown" class="form-select" style="width: 150px;">
                    <option value="">Select Village</option>
                </select>
            </div>
        </div>
    </div>


    <!-- Confirmation Box -->
    <div class="d-flex justify-content-center" style="max-height: 400px;">
        <div id="confirmLoadSection" class="alert alert-info" style="display: none; width: 300px;">
            <p class="mb-2">Do you want to load village data?</p>
            <button id="btnYes" class="btn btn-success btn-sm me-2">Yes</button>
            <button id="btnNo" class="btn btn-danger btn-sm">No</button>
        </div>
    </div>
    <%--<div id="loader" style="display:none; position:fixed; top:50%; left:50%; transform:translate(-50%, -50%);
 z-index:9999;">
            <img src="../Rofrnewassets/images/aplogo.png" alt="Loading..." />
</div>--%>
    <!-- Card Form -->

    <div class="container-fluid1">
        <div class="d-flex justify-content-center align-items-center min-vh-100">
            <div class="col-12 col-md-10 col-xl-9" style="padding-bottom: 325px;">
                <div id="formSection" class="card" style="display: none; width: 1200px; height: 400px">
                    <div class="card-body" style="padding-bottom: 250px;">
                        <div class="section-title">Village Data Form</div>

                        <div class="row g-3 mb-3">
                            <div class="row col-md-12 col-lg-12">
                                <input type="hidden" id="VillageStatus" />
                                <input type="hidden" id="Record_id" class="form-control only-numbers-dot" />
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">Village Category</label>
                                    <select id="Village_Category" class="form-select" style="width: 150px;">
                                        <option value="">Select Village Category</option>
                                    </select>
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">Geographical Area</label>
                                    <input type="text" id="Geog_Area" class="form-control only-numbers-dot" />
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">Total Households</label>
                                    <input type="text" id="Total_HH" class="form-control only-numbers-dot" />
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">Total Population</label>
                                    <input type="text" id="Total_PoP" class="form-control only-numbers-dot" />
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">Total Male</label>
                                    <input type="text" id="Total_Male" class="form-control only-numbers-dot" />
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">Total Female</label>
                                    <input type="text" id="Total_Fema" class="form-control only-numbers-dot" />
                                </div>
                            </div>
                        </div>

                        <div class="section-title">Scheduled Caste (SC)</div>
                        <div class="row g-3 md-3">
                            <div class="row col-md-12 col-lg-12">
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">Total SC</label>
                                    <input type="text" id="Total_SC" class="form-control only-numbers-dot" />
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">SC Male</label>
                                    <input type="text" id="SC_Male" class="form-control only-numbers-dot" />
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">SC Female</label>
                                    <input type="text" id="SC_Female" class="form-control only-numbers-dot" />
                                </div>
                            </div>
                        </div>
                        <div class="section-title">Scheduled Tribe (ST)</div>
                        <div class="row g-3 md-3">
                            <div class="row col-md-12 col-lg-12">
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">Total ST</label>
                                    <input type="number" id="Total_ST" class="form-control only-numbers-dot" />
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">ST Male</label>
                                    <input type="number" id="ST_Male" class="form-control only-numbers-dot" />
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">ST Female</label>
                                    <input type="number" id="ST_Female" class="form-control only-numbers-dot" />
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <label class="form-label">Forest Area (Ha)</label>
                                    <input type="text" id="Forest_Ha" class="form-control only-numbers-dot" />
                                </div>

                            </div>
                        </div>

                        <div class="row g-3 md-3">
                            <div class="row col-md-12 col-lg-12">
                            </div>
                        </div>
                        <div class="mt-3 d-flex justify-content-center">
                            <button class="btn btn-primary" id="submitBtn">Update</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--</div>--%>
    <!-- JS Includes -->
    <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
    <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <script src="../Newcdn/vfs_fonts.js"></script>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    <script src="../Newcdn/xlsx.full.min.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
    <script src="../NewJsFiles/VillageUpdateform.js"></script>
    <script>
        $('input.only-numbers-dot').on('keypress', function (e) {
            var charCode = e.which ? e.which : e.keyCode;
            if ((charCode >= 48 && charCode <= 57) || charCode === 46) {
                if (charCode === 46 && $(this).val().includes('.')) {
                    e.preventDefault();
                }
            } else {
                e.preventDefault();
            }
        });
    </script>
</asp:Content>
