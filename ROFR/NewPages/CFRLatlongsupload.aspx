<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="CFRLatlongsupload.aspx.cs" Inherits="ROFR.NewPages.CFRLatlongsupload" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style>
        .card {
            margin-top: 20px;
        }

        .section-title {
            font-weight: bold;
            margin-top: 20px;
            font-size: 1.2rem;
        }

      /* #formSection input.form-control {
            width: 150px;
        }*/

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

       /* .content-section {
            max-height: 485px;
            height: 347px;
            overflow: hidden;
        }*/

       .asterisk:after{
           content:"*";
           color:#ff0000;
       }
  
         .commform {
            font-weight: 600;
        }

            table {
    width: 80%;
    border-collapse: collapse; /* ensures single border */
    margin-top: 20px;
}

th, td {
    border: 1px solid #000; /* 👈 black border for each cell */
    padding: 8px;
    text-align: center;
}



.table thead th{
    background-color: #198754!important;
    color:#fff!important;
        text-align: center;
}
.bold
{
    border:3px solid #ccc;
}

.form-select{
font-size: .8rem!important;
}
.form-control {
   padding: 6px 0 31px 0 !important;
}

.form-label{
    white-space:nowrap;
}
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <span id="userprevilages" style="display:none" runat="server"></span>
         <span id="username" style="display:none" runat="server"></span>
          <span id="ipadress" style="display:none" runat="server"></span>
          <span id="tk" style="display:none" runat="server"></span>
          <label type="text" id="cpt"  style="display:none" runat="server"/>
          <span id="ustart" style="display:none" runat="server"></span>
         <span id="end" style="display:none" runat="server"></span>
    
   <div class="container-fluid" style="margin-top:10px">
        <!-- Representative Card -->
        <div class="container mt-4">
           
            <div class="card">
                <div class="card-header bg-success  text-white text-center">BOUNDARIES GIS COORDINATES</div>
                <div class="card-body">
                    
                    <div class="row" id="dropdownid">
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-4"><label for="ddlDistrict1"
                                        class="form-label asterisk commform">District</label>

                                </div>
                                <div class="col-8">
                                    <select id="ddlDistrict1" class="form-select asterisk commform flex-grow-1 " style="border:3px solid #ccc;" >
                                        <option value="">Select District</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-4">
                                    <label for="ddlMandal1" class="form-label  asterisk commform">Mandal</label>
                                </div>
                                <div class="col-8">
                                    <select id="ddlMandal1" class="form-select flex-grow-1 " style="border:3px solid #ccc;" >
                                        <option value="">Select Mandal</option>
                                    </select>
                                </div>
                            </div>
                        </div> 
                        <div class="col-md-3" id="cfriddll">
                            <div class="row">
                                <div class="col-4">
                                    <label for="ddlcfr" class="form-label asterisk commform">CFR</label>
                                </div>
                                <div class="col-8">
                                    <select id="ddlcfr" class="form-select flex-grow-1 " style="border:3px solid #ccc;" >
                                        <option value="">Select crf</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-4">
                                    
                                </div>
                                <div class="col-8">
                                   <button type="button" id="savelatupload" class="btn btn-primary px-3">Bulk Upload</button>
                                    <a href="#" id="backBtn">⬅ Back</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="col-1">
                                    
                                </div>
                                <div class="col-3">
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-4">
                            <h6 style="color:red" id="McId">Note: Please upload the data in the given format – CFRID,LATITUDE,LONGITUDE</h6>
                        </div>
                          <div class="col-md-4" id="uploadexid">
                            <div class="row d-flex justify-content-center align-items-center">
                                <div class="col-3">
                                    <label for="lblExcel" id="lblExcel"
                                        class="form-label asterisk commform" style="display:none">Upload Excel</label>
                                </div>
                                <div class="col-7">
                                    <input type="file" id="excelUpload" accept=".xls,.xlsx" class="form-control" style="display:none"/>
                                </div>
                                 <div class="col-2">
                                     <button type="button" id="uploadBtn" class="btn btn-success" style="display:none">Upload</button>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4"></div>
                    </div>
                     <div class="row" style=" margin-top: 20px;" id="tbltbtId">
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-4">
                                    <label class="asterisk commform">LATITUDE</label>
                                </div>
                                <div class="col-8">
                                    
                                    <input type="text" id="LATITUDEID" class="form-control decimal-only " style="border:3px solid #ccc;"  />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-4">
                                     <label class="asterisk commform">LONGITUDE</label>
                                </div>
                                <div class="col-8">
                                    <input type="text" id="LONGITUDEID" class="form-control decimal-only " style="border:3px solid #ccc;" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="row">
                                
                                <div class="col-8">
                                   <button type="button" id="addRowBtn" class="btn btn-success px-3">Add</button>
                                </div>
                            </div>
                        </div>
                    </div>

                     <div class="row justify-content-center" style="margin-top:20px">
     <table id="LatlongsTable" class="table table-bordered mt-3 w-50" style="margin-top:20px; width:75%; border:3px solid #ccc">
    <thead>
        <tr>
            <th style="border:3px solid #ccc">S.No</th>
            <th style="border:3px solid #ccc">LATITUDE</th>
            <th style="border:3px solid #ccc">LONGITUDE</th>
            <th style="border:3px solid #ccc">Action</th>
        </tr>
    </thead>
    <tbody>
       
        
    </tbody>
</table>
                        <div class="row">
                        <div class="col text-center">
                            <button type="button" id="saveBtn" class="btn btn-success px-3">Save All</button>
                        </div>
                    </div>

                    </div>
                </div>
            </div>
        </div>

    </div>

   
   
    <!-- jQuery must be loaded first -->
<%--<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>--%>
    <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
<!-- DataTables core -->
<script src="../Newcdn/dataTables.min.js"></script>

<!-- DataTables buttons extension -->
<script src="../Newcdn/dataTables.buttons.min.js"></script>

<!-- Dependencies for export features -->
<script src="../Newcdn/jszip.min.js"></script>
<script src="../Newcdn/pdfmake0.1.18.min.js"></script>
<script src="../Newcdn/vfs_fonts.js"></script>

<!-- Buttons for HTML5 export & print -->
<script src="../Newcdn/html5.min.js"></script>
<script src="../Newcdn/print.min.js"></script>

<!-- Other export utilities -->
<script src="../Newcdn/xlsx.full.min.js"></script>
<script src="../Newcdn/tabletoexcel.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../NewJsFiles/cfrLatlongs.js"></script>

    <!--Bootstrap Cdn -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
    

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

        $('.decimal-only').on('keypress', function (e) {
            var charCode = e.which ? e.which : e.keyCode;

            // Digits 0–9 are allowed
            if (charCode >= 48 && charCode <= 57) {
                return true;
            }

            // One dot (.) allowed
            if (charCode === 46) {
                if ($(this).val().includes('.')) {
                    e.preventDefault(); // Prevent more than one dot
                }
                return true;
            }

            e.preventDefault(); // Block everything else
            return false;
        });

        $(document).ready(function () {
            $("#savelatupload").on("click", function () {
                // Hide button
                $("#tbltbtId").hide();
                $("#saveBtn").hide();
                $(this).hide();
                
                $("#LatlongsTable").hide();
                // Show file upload
                $("#excelUpload").show();
                $("#lblExcel").show();
                $("#uploadBtn").show();
            });
        });
    </script>
  
   
    
   
</asp:Content>
