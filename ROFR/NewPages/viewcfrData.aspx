<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="viewcfrData.aspx.cs" Inherits="ROFR.NewPages.viewcfrData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Newcdn/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Newcdn/buttons.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/fixedcolumns/4.2.1/css/fixedColumns.dataTables.min.css" rel="stylesheet"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>

    <style>
        .font-telugu {
      font-family: 'Ramabhadra', sans-serif;
      text-shadow: 2px 2px rgba(0, 0, 0, 0.3);
      font-size: 30px;
    }
     .table th {
       background-color:#008500 !important;
       color:white;
       }
    .bg-nav{
      background-color: #008500 !important;
    }
     #loading-wrapper {
            background: rgba(255, 255, 255, 0.40) !important;
        }
         
  .table thead tr:last-child th:nth-child(1) {
    width: 10px!important;
    text-align:right
}

    </style>
    <style>
        .table-bordered td {
            border: 1px solid #808080;
        }
        .header{
            text-align:center;
            color:white;
        }
        
        .container-center {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100%;
}

#viewcfrdataTbl {
    width: 100% !important;
    white-space: nowrap;
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
        <div class="row justify-content-center mt-1">
        <div class="col-md-5">
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">View CFR Details</h5>

          </div>
            </div>
        <div id="myForm" style="margin-top: 15px;">
                <div class="row">
                   <div class="col-auto"><b>ITDA:</b>
                            </div>
                            <div class="col-md-2">
                                <select id="ddlItda" class="form-select form-control" style="margin-left: -16px;width: 200px;">
                                    <option value="">Select ITDA</option>
                                </select>
                           </div>
                        
                    <!-- District -->
                    
                        <div class="col-auto" ><b>District:</b>
                            </div>
                            
                            
                            <div class="col-md-2">
                                <select id="ddlDistrict" class="form-select form-control" style="margin-left: -16px;width: 200px;">
                                    <option value="">Select District</option>
                                </select>
                            </div>
                    <!-- Mandal -->
                    <div class="col-auto"><b>Mandal:</b>
                            </div>
                            
                            <div class="col-md-2">
                                <select id="ddlMandal" class="form-select form-control" style="margin-left: -16px;width: 200px;">
                                    <option value="">Select Mandal</option>
                                </select>
                            </div>
                    </div>
         </div>
                    
            
          </div>
            
       
        <div class="mt-3" style="width:100%; overflow:auto;">
                        <table id="viewcfrdataTbl" class="table table-bordered text-center" style="display:none; max-width:100%;">
                            <thead>
                              
                                <tr>
                                    <th class="text-center">S.NO</th>
                                    <th class="text-center">CFR ID</th>
                                    <th class="text-center">Revenue Village</th>
                                    <th class="text-center">Village</th>
                                    <th class="text-center">Habitation</th>
                                    <th class="text-center">Compartment No</th>
                                    <th class="text-center">Khasra No</th>
                                    <th class="text-center">Rofr Pattano</th>
                                    <th class="text-center">Description of boundaries</th>
                                    <th class="text-center">Total Members</th>
                                    <th class="text-center">Total Extent</th>
                                    <th class="text-center">Nature of Rights</th>
                                    <th class="text-center">Nature of Description</th>
                                    <th class="text-center">Utilization Status</th>
                                    <th class="text-center">Support Required</th>
                                     <th class="text-center">Grama Sabha</th>
                                    <th class="text-center">Remarks</th>
                                </tr>
                            </thead>
                            <tbody>
                                
                            </tbody>
                        </table>
                    </div>


     

    <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
    <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <script src="../Newcdn/vfs_fonts.js"></script>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
    <script src="../NewJsFiles/viewcfrdata.js"></script>
</asp:Content>
