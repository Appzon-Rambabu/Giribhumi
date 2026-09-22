<%@ Page Language="C#"  MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="CommunityRightsUpload.aspx.cs" Inherits="ROFR.NewPages.CommunityRightsUpload" EnableEventValidation="false"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
   
    <meta name="viewport" content="width=device-width, initial-scale=1" />
     <link rel="stylesheet" 
          href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    
     
    <style>
        .col-form-label,.form-label {
  white-space: nowrap!important;
}
.bg-success{
     background-color:#007405!important;
}
.table th{
    font-size: .8rem!important;
     background:#007405!important;
     color:#ffffff!important;
}

.col-form-label, .form-select,.form-label,.col-form-control {
   font-size: .8rem!important;
   
}

.form-control{
    font-size: 1rem!important;
   
}


        body {
            background: #f8f9fa;
        }
        .card {
            border-radius: 12px;
        }
        .card-header {
            font-weight: bold;
            font-size: 18px;
            text-align: center;
            border-radius: 12px 12px 0 0;
        }
        
        .btn-primary {
            border-radius: 25px;
            font-size: 16px;
            padding: 8px 30px;
        }
        .btn-link {
            font-size: 15px;
            color: #007bff;
        }
        .btn-link:hover {
            text-decoration: underline;
        }
        .form-text {
            font-size: 12px;
        }
        .row {
            margin-bottom: 12px;
        }

     
label.required::after {
    content: "*";
    color: red;
    font-weight: bold;
}



body.swal2-toast-shown .swal2-container{
        box-sizing: border-box;
    width: 516px !important;
    max-width: 100%;
    background-color: rgba(0, 0, 0, 0);
    pointer-events: none;
    overflow-y: hidden!important;
    
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
   
  <div class="container-fluid">
        
        <div id="loader"
            style="display:none; text-align:center; position:fixed; top:40%; left:50%; transform:translate(-50%,-50%); z-index:9999;">
            <img src="../Rofrnewassets/images/aplogo.png" alt="Loading..." width="80" />
            <p>Please wait...</p>
        </div>
        <div class="card shadow" id="myForm">
            <div class="card-header bg-success text-white">
                Community Forest Right Location Details
            </div>
            <div class="card-body">
                <div class="row">
                    <!-- ITDA -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ddlItda" class="col-sm-5 col-form-label required">ITDA:</label>
                            <div class="col-sm-7">
                                <select id="ddlItda" class="form-select">
                                    <option value="">Select ITDA</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <!-- District -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ddlDistrict" class="col-sm-5 col-form-label required">District:</label>
                            <div class="col-sm-7">
                                <select id="ddlDistrict" class="form-select">
                                    <option value="">Select District</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <!-- Mandal -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ddlMandal" class="col-sm-5 col-form-label required">Mandal:</label>
                            <div class="col-sm-7">
                                <select id="ddlMandal" class="form-select">
                                    <option value="">Select Mandal</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <!-- Panchayat -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ddlPanchayat" class="col-sm-5 col-form-label required">Panchayat:</label>
                            <div class="col-sm-7">
                                <select id="ddlPanchayat" class="form-select">
                                    <option value="">Select Panchayat</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <!-- Revenue Village -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ddlRevVillage" class="col-sm-5 col-form-label required">Revenue Village:</label>
                            <div class="col-sm-7">
                                <select id="ddlRevVillage" class="form-select">
                                    <option value="">Select Revenue Village</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <!-- Village -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ddlVillage" class="col-sm-5 col-form-label required">Village:</label>
                            <div class="col-sm-7">
                                <select id="ddlVillage" class="form-select">
                                    <option value="">Select Village</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <!-- Habitation -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ddlHabitation" class="col-sm-5 col-form-label required">Habitation:</label>
                            <div class="col-sm-7">
                                <select id="ddlHabitation" class="form-select">
                                    <option value="">Select Habitation</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <!-- Forest Division -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ddlDivision" class="col-sm-5 col-form-label required">Forest Division:</label>
                            <div class="col-sm-7">
                                <select id="ddlDivision" class="form-select">
                                    <option value="">Select Forest Division</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <!-- Forest Range -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ddlRange" class="col-sm-5 col-form-label required">Forest Range:</label>
                            <div class="col-sm-7">
                                <select id="ddlRange" class="form-select">
                                    <option value="">Select Forest Range</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <!-- Forest Beat -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ddlBeat" class="col-sm-5 col-form-label required">Forest Beat:</label>
                            <div class="col-sm-7">
                                <select id="ddlBeat" class="form-select">
                                    <option value="">Select Forest Beat</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <!-- Forest Block -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ForestBlockId" class="col-sm-5 col-form-label required">Forest Block:</label>
                            <div class="col-sm-7">
                                <input type="text" id="ForestBlockId" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <!-- Compartment No -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="CompNoID" class="col-sm-5 col-form-label required">Compartment No:</label>
                            <div class="col-sm-7">
                                <input type="text" id="CompNoID" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <!-- Khasra No -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="KhasraId" class="col-sm-5 col-form-label required">Khasra No:</label>
                            <div class="col-sm-7">
                                <input type="text" id="KhasraId" class="form-control only-numbers-dot" />
                            </div>
                        </div>
                    </div>
                    <!-- Description of boundaries -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center" style="margin-top: -.7rem;">
                            <label for="DesobId" class="col-sm-5 col-form-label">Description of
                               <br/> boundaries:</label>
                            <div class="col-sm-7">
                                <input type="text" id="DesobId" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <!-- Rofr Patta No -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="RofrPattaId" class="col-sm-5 col-form-label">Rofr Patta No:</label>
                            <div class="col-sm-7">
                                <input type="text" id="RofrPattaId" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <!-- Total Members -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="NoOFBcMeId" class="col-sm-5 col-form-label required">Total Members:</label>
                            <div class="col-sm-7">
                                <input type="text" id="NoOFBcMeId" class="form-control only-numbers-dot" />
                            </div>
                        </div>
                    </div>
                    <!-- Total CFR Extent -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="TotalcfrExtentId" class="col-sm-5 col-form-label required">CFR Extent
                                (Acres):</label>
                            <div class="col-sm-7">
                                <input type="text" id="TotalcfrExtentId" class="form-control decimal-only" />
                            </div>
                        </div>
                    </div>

                     <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ddlNature" class="col-sm-5 col-form-label required">Nature of Rights:</label>
                            <div class="col-sm-7">
                                <select id="ddlNatureofcfr" class="form-select">
                                    <option value="">Select Nature of Right</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <!-- Nature of Community Rights -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="NaofCrId" class="col-sm-5 col-form-label required">Nature of Description:</label>
                            <div class="col-sm-7">
                                <input type="text" id="NaofCrId" class="form-control only-text" />
                            </div>
                        </div>
                    </div>
                    <!-- Utilization Status -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="preStaId" class="col-sm-5 col-form-label">Utilization Status:</label>
                            <div class="col-sm-7">
                                <select id="preStaId" class="form-select">
                                    <option value="">-- Select Status --</option>
                                    <option value="Yes">Yes</option>
                                    <option value="No">No</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <!-- Support If Any -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row">
                            <label for="SupportifanyId" class="col-sm-5 col-form-label">Support
                                Required:</label>
                            <div class="col-sm-7">
                                <input type="text" id="SupportifanyId" class="form-control only-text" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 mb-3">
                        <div class="form-group row">
                            <label for="Grama" class="col-sm-5 col-form-label required">Grama Sabha:</label>
                            <div class="col-sm-7">
                                <input type="text" id="GramasabhaId" class="form-control only-text" />
                            </div>
                        </div>
                    </div>
                    <!-- Remarks -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row">
                            <label for="RemarksId" class="col-sm-5 col-form-label">Remarks:</label>
                            <div class="col-sm-7">
                                <input type="text" id="RemarksId" class="form-control only-text" />
                            </div>
                        </div>
                    </div>
                    <!-- CFR Document Upload -->
                    <div class="col-md-3 mb-3">
                        <div class="form-group row">
                            <label for="CFRDocumentUploadId" class="col-sm-5 col-form-label">CFR
                                Document:</label>
                            <div class="col-sm-7">
                                <input class="form-control" type="file" id="CFRDocumentUploadId" accept=".pdf,.csv" />
                                <div class="form-text" style="color: forestgreen;">Allowed formats: PDF</div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Submit Button -->
                <div class="row">
                    <div class="col text-center">
                        <button type="button" id="submitBtn" class="btn btn-success px-3">Submit</button>
                    </div>
                </div>
                <div class="row">
                    <a href="#" id="showRepForm" class="btn btn-link text-decoration-none text-start">+ Add Community Representatives</a>
                </div>
            </div>
        </div>

    </div>

    <!-- Community Representative Section -->

    <div class="container-fluid my-4" >
        <div class="card shadow d-none" id="repCard">
            <div class="card-header bg-success text-white">Community Representative Details</div>
            <div class="card-body">
                <div class="row col-md-12 g-3"> <!-- g-3 adds spacing -->
    

                     <%--<div class="col-md-3 mb-3">
                        <div class="form-group row align-items-center">
                            <label for="ddlDistrict" class="col-sm-5 col-form-label required">District:</label>
                            <div class="col-sm-7">
                                <select id="ddlDistrict" class="form-select">
                                    <option value="">Select District</option>
                                </select>
                            </div>
                        </div>
                    </div>--%>
    <!-- District -->
    <div class="col-md-3 mb-3">
       <div class="form-group row align-items-center">
        <label for="ddlDistrict1" class="col-sm-5 col-form-label required">District</label>
      
       <div class="col-sm-7">
        <select id="ddlDistrict1" class="form-select">
            <option value="">Select District</option>
        </select>
       </div>
       </div>
    </div>

    <!-- Mandal (Normal / Bulk Toggle) -->
    <div class="col-md-3 mb-3">
        <!-- Normal Mandal -->
        <div id="nalmandal" class="form-group row align-items-center">
            <label for="ddlMandal1" class="col-sm-5 col-form-label required">Mandal</label>
            <div class="col-sm-7">
            <select id="ddlMandal1" class="form-select">
                <option value="">Select Mandal</option>
            </select>
        </div>
            </div>

        <!-- Bulk Mandal -->
        <div id="bulkmandal" style="display:none" class="form-group row align-items-center">
            <label for="ddlMandalbulk"  class="col-sm-5 col-form-label required">Mandal</label>
            <div class="col-sm-7">
            <select id="ddlMandalbulk" class="form-select">
                <option value="">Select Mandal</option>
            </select>
        </div>
           </div> 
    </div>

    <!-- CFR -->
    <div class="col-md-3 form-group row align-items-center" id="ddlcfr1">
        <label for="ddlcfr" class="col-sm-5 col-form-label required">CFR</label>
         <div class="col-sm-7">
        <select id="ddlcfr" class="form-select">
            <option value="">Select CFR</option>
        </select>
    </div>
        </div>

    <!-- CFR Table -->
    <div class="col-md-3">
        <table id="cfrTable" class="table table-bordered text-center mb-0">
            <thead>
                <tr>
                    <th>Total Members</th>
                    <th>Submitted</th>
                    <th>Yet to Submit</th>
                </tr>
            </thead>
            <tbody>
                <!-- Fill with JS -->
            </tbody>
        </table>
    </div>

</div>

                

                <!-- Add Representative Fields -->
                <div class="row justify-content-center mt-3 align-items-center">
                    <div class="col-md-3">
                        <div class="row" id="repName1">
                            <div class="col-4"><label class="form-label required" >Representative <br/> Name</label></div>
                            <div class="col-8"><input type="text" id="repName" class="form-control only-text" /></div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="row" id="fatherName1">
                            <div class="col-4"><label class="form-label required" >Father's Name</label></div>
                            <div class="col-8"><input type="text" id="fatherName" class="form-control only-text" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="row" id="aadhaarNo1">
                            <div class="col-4"><label class="form-label required">Aadhaar No</label></div>
                            <div class="col-8"><input type="text" id="aadhaarNo" maxlength="12"
                                    class="form-control only-numbers-dot" /></div>
                        </div>
                    </div>
                    
                    <div class="col-md-2 d-flex align-items-center">
                        
                    <button type="button" id="addRowBtn" class="btn btn-success me-2 btn-sm w-50"">Add</button>
                     <button type="button" id="savelatupload" class="btn btn-primary px-3 me-2 btn-sm w-100"">Bulk Upload</button>
                     
                    </div>
                    <div class="col-md-3">
                                  
                                </div>
                </div>

         <div class="d-flex mt-2 justify-content-center">
    <div class="col-md-8" id="uploadexid">
        <div class="row align-items-center g-2">
            
            <!-- Label -->
            <div class="col-2">
                <label for="excelUpload" class="form-label fw-bold mb-0" style="font-size:13px;">Upload Excel</label>
            </div>
            
            <!-- File Input -->
            <div class="col-4">
                <input type="file" id="excelUpload" accept=".xls,.xlsx" 
                       class="form-control form-control-sm border-dark" />
            </div>
            
            <!-- Upload Button -->
            <div class="col-2">
                <button type="button" id="uploadBtn" class="btn btn-success btn-sm w-100">Upload</button>
            </div>
            
            <!-- Back Button -->
            <div class="col-2 ms-5">
                <a href="#" id="backBtn" class="btn btn-outline-secondary btn-sm w-100">⬅ Back</a>
            </div>
        </div>
    </div>
</div>

                
 <h6><span style="color: red; font-weight: bold;" id="McId">*** Note: Please upload the data in the given format – CFRID,RepresentativeName,FatherName,AadhaarNo ***</span></h6>
<h6 style="color:red" id="noteid">Note: Submit button will be enabled only when the submitted members is equal to the total members.</h6>
                <!-- Members Table -->
                <div class="d-flex justify-content-center mt-3">
                    <table id="membersTable" class="table table-bordered w-50">
                        <thead>
                            <tr>
                                <th>S.No</th>
                                <th>Representative Name</th>
                                <th>Father's Name</th>
                                <th>Aadhaar No</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <!-- JS will append rows here -->
                        </tbody>
                    </table>
                </div>

                <div class="d-flex justify-content-center mt-3">
                        <table id="cfrTablemulti"  class="table table-bordered text-center" style="display:none; max-width:600px;">
                            <thead>
                                <tr>
                                    <th class="text-center">S.NO</th>
                                    <th class="text-center">CFRID</th>
                                    <th class="text-center">Total Members</th>
                                    <th class="text-center">Total Extent</th>
                                </tr>
                            </thead>
                            <tbody>
                                
                            </tbody>
                        </table>
                    </div>

                <div class="row mt-3 justify-content-center">
                    <div class="text-center">
                        <button type="button" id="saveBtn" class="btn btn-success px-3" style="display:none">Save
                            All</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    

   
   
  
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.13.6/css/jquery.dataTables.min.css"/>
<!-- jQuery -->
<script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
     <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
    <!-- DataTables JS -->
<script src="https://cdn.datatables.net/1.13.6/js/jquery.dataTables.min.js"></script>
<!-- Popper.js -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>

<!-- Bootstrap 4.3.1 JS -->

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

<script src="../NewJsFiles/Cfr.js"></script>

   
    
     
    
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
  
     <script>
         $(document).ready(function () {
             $("#showRepForm").click(function (e) {
                 $("#membersTable").hide();
                 $("#noteid").hide();
                 $("#saveBtn").hide();
                 $("#cfrTable").hide();
                 $("#McId").hide();
                 $("#backBtn").hide();
                 $("#uploadexid").hide();
                 $("#bulkmandal").hide();
                 
                 e.preventDefault();
                 $("#repCard").removeClass("d-none");
                 $('html, body').animate({
                     scrollTop: $("#repCard").offset().top
                 }, 1000);
                 
             });
             loadDistricts();
             $("#membersTable").show();
             $("#saveBtn").show();
             $("#cfrTable").show();
            
         });
     </script>
    <script>
        $("#ForestBlockId").on("input", function () {
            // Replace everything that's not A-Z, a-z, or 0-9
            this.value = this.value.replace(/[^a-zA-Z0-9]/g, '');
        });
        //$("#CompNoID").on("input", function () {
        //    // Replace everything that's not A-Z, a-z, or 0-9
        //    this.value = this.value.replace(/[^a-zA-Z0-9]/g, '');
        //});
        $("#RofrPattaId").on("input", function () {
            // Replace everything that's not A-Z, a-z, or 0-9
            this.value = this.value.replace(/[^a-zA-Z0-9]/g, '');
        });
        
        $('.only-text').on('keypress', function (e) {
            var charCode = e.which ? e.which : e.keyCode;

            if (
                (charCode >= 65 && charCode <= 90) ||  // A-Z
                (charCode >= 97 && charCode <= 122) || // a-z
                charCode === 32                        // space
            ) {
                return true;
            } else {
                e.preventDefault();
                return false;
            }
        });

        // Extra safety: clean pasted text (remove numbers/special chars)
        $('.only-text').on('input', function () {
            this.value = this.value.replace(/[^a-zA-Z ]/g, '');
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


        

        
    </script>
   


 <script>

     var d = [[0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
     [1, 2, 3, 4, 0, 6, 7, 8, 9, 5],
     [2, 3, 4, 0, 1, 7, 8, 9, 5, 6],
     [3, 4, 0, 1, 2, 8, 9, 5, 6, 7],
     [4, 0, 1, 2, 3, 9, 5, 6, 7, 8],
     [5, 9, 8, 7, 6, 0, 4, 3, 2, 1],
     [6, 5, 9, 8, 7, 1, 0, 4, 3, 2],
     [7, 6, 5, 9, 8, 2, 1, 0, 4, 3],
     [8, 7, 6, 5, 9, 3, 2, 1, 0, 4],
     [9, 8, 7, 6, 5, 4, 3, 2, 1, 0]];


     // The permutation table
     var p = [
         [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
         [1, 5, 7, 6, 2, 8, 3, 0, 9, 4],
         [5, 8, 0, 3, 7, 9, 6, 1, 4, 2],
         [8, 9, 1, 6, 0, 4, 3, 5, 2, 7],
         [9, 4, 5, 3, 1, 2, 6, 8, 7, 0],
         [4, 2, 8, 6, 5, 7, 3, 9, 0, 1],
         [2, 7, 9, 3, 8, 0, 6, 4, 1, 5],
         [7, 0, 4, 6, 9, 1, 3, 2, 5, 8]];


     // The inverse table
     var inv = [0, 4, 3, 2, 1, 5, 6, 7, 8, 9];



     //  For a given number generates a Verhoeff digit

     //         Validates that an entered number is Verhoeff compliant.

     function validateVerhoeff(num) {
         //  alert("funcall" + num);
         if (num == "333333333333" || num == "777777777777") {
             return 0;
         }
         var cc;
         var c = 0;
         var myArray = StringToReversedIntArray(num);

         for (var i = 0; i < myArray.length; i++) {

             c = d[c][p[(i % 8)][myArray[i]]];

         }

         cc = c;
         if (cc == 0) {
             //alert("Valid UID");
             return true;

         }
         else {

             //alert("Invalid Aadhaar Number");
             return false;


         }
     }



     /*
      * Converts a string to a reversed integer array.
      */
     function StringToReversedIntArray(num) {

         var myArray = [num.length];

         for (var i = 0; i < num.length; i++) {

             myArray[i] = (num.substring(i, i + 1));

         }

         myArray = Reverse(myArray);


         return myArray;

     }

     /*
      * Reverses an int array
      */
     function Reverse(myArray) {

         var reversed = [myArray.length];

         for (var i = 0; i < myArray.length; i++) {
             reversed[i] = myArray[myArray.length - (i + 1)];

         }

         return reversed;
     }



 </script>
    <script>
        $('#aadhaarNo').on('blur', function () {
            var aadhaar = $(this).val();

            if (aadhaar.length !== 12) {
                alert("Please enter a 12-digit Aadhaar number");
                $(this).val('');
                return;
            }

            if (!validateVerhoeff(aadhaar)) {
                alert("Invalid Aadhaar number");
                $(this).val('');
                return;
            }

            console.log("✅ Valid Aadhaar:", aadhaar);
        });
    </script>

   
</asp:Content>
