<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="mfpproductwisedata.aspx.cs" Inherits="ROFR.NewPages.mfpproductwisedata" %>
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
        label {
    font-size: 16px;
    font-weight: 600;
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
.form-control,
.form-select {
    height: 35px !important;
    padding: 8px 15px;
    border-radius: 8px;
}

 /*.custom-input {
    height: 50px;
    padding: 8px 12px;
    box-sizing: border-box;
}*/

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
                <div class="card-header bg-success  text-white text-center">MFP PRODUCT DETAILS</div>
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
                                    <label for="ddlcfrmfp" class="form-label asterisk commform">CFR</label>
                                </div>
                                <div class="col-8">
                                    <select id="ddlcfrmfp" class="form-select flex-grow-1 " style="border:3px solid #ccc;" >
                                        <option value="">Select crf</option>
                                    </select>
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
                   
     <div class="row align-items-end" style="margin-top:50px; display:none" id="tbltbtId">

    <div class="col-md-2">
        <label class="form-label asterisk commform">ProductName</label>
        <select id="ddlmfpPrdName" class="form-select" style="border:3px solid #ccc;">
            <option value="">Select Product</option>
        </select>
    </div>

    <div class="col-md-2">
        <label class="asterisk commform">TotalAcres</label>
        <input type="text" id="TotalAcresID" class="form-control decimal-only custom-input" style="border:3px solid #ccc;" />
    </div>

    <div class="col-md-2">
        <label class="asterisk commform">IncomePerAnnum (In Lakhs)</label>
        <input type="text" id="IncomePerAnnumID" class="form-control decimal-only custom-input" style="border:3px solid #ccc;" />
    </div>

    <div class="col-md-2">
        <label class="asterisk commform">PointOfSale</label>
        <input type="text" id="PointOfSaleID" class="form-control custom-input" style="border:3px solid #ccc;" />
    </div>

    <div class="col-md-2">
        <label class="asterisk commform">Product Quantity (In Kgs)</label>
        <input type="text" id="QuantityID" class="form-control decimal-only custom-input" style="border:3px solid #ccc;" />
    </div>

    <div class="col-md-2">
        <button type="button" id="addRowBtn" class="btn btn-success w-50">
            Add
        </button>
    </div>

    </div>

                    

      <div class="row justify-content-center" style="margin-top:20px">
     <table id="mfpProductTable" class="table table-bordered mt-3 w-80" style="margin-top:20px; width:75%; border:3px solid #ccc">
    <thead>
        <tr>
            <th style="border:3px solid #ccc">S.No</th>
            <th style="border:3px solid #ccc">ProductName</th>
            <th style="border:3px solid #ccc">TotalAcres</th>
            <th style="border:3px solid #ccc">IncomePerAnnum (In Lakhs)</th>
            <th style="border:3px solid #ccc">PointOfSale</th>
            <th style="border:3px solid #ccc">Product Quantity (In Kgs)</th>
            <th style="border:3px solid #ccc">Action</th>
        </tr>
    </thead>
    <tbody>
       
        
    </tbody>
</table>
                        <div class="row">
                        <div class="col text-center">
                            <button type="button" id="mfpsaveBtn" class="btn btn-success px-3">Save All</button>
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
    <script src="../NewJsFiles/cfrmfp.js"></script>

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
