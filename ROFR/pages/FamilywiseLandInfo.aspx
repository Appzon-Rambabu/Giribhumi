<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="FamilywiseLandInfo.aspx.cs" Inherits="ROFR.pages.FamilywiseLandInfo" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       .table.dataTable thead th, table.dataTable thead td {
    padding: 2px 10px !important;
    border-bottom: 1px solid #111 !important;
    font-size: 12px !important;
}
.table.dataTable tbody th, table.dataTable tbody td {
    padding: 0px 5px !important;
    font-size: 12px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
      <div class="row" style="margin-top:30px;">
      <span id="tk" style="display:none" runat="server"></span>
        <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">
            <div class="panel" style="margin-top:120px;">
                <div class="panel-body">
                    <div class="row ">
                        <div class="col-md-3"></div>
                        <div class="col-md-6 text-center">
                            <h4 style="color:#00ad27;font-size:24px"><b>Family wise Rythu Bharosa Details</b></h4>
                        </div>
                        <div class="col-md-3">
                            <a id="landexcel"><img src="../imagesnew/download1.jpg" width="28" height="28" style="float:right;margin:3px"
                                    onclick="land_excel()"/></a>
                            <a id="Rythuexcel"><img src="../imagesnew/download1.jpg" width="28" height="28" style="float: right; margin: 3px"
                                    onclick="Rythu_excel()"/></a>
                        </div>
                    </div>
                    



                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div class="panel-body bg-light p-2">
                                    <div class="row justify-content-center">
                                        <div class="showdetails1 col-md-6">
                                            
                                            <table class="table table-bordered" style="text-align: center;margin: 0 auto;font-size:14px;" id="abstarct_tbl">
                    
                                                <thead class="bg-custom">
                                                    <tr>
                                                        <th rowspan="2"
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Total No.of Families</th>
                                                            <th rowspan="2" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                          Sub-Merged/Migrated/In-Eligible Families</th>
                                                        <th colspan="3"
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Land Holding Details</th>
                                                        <th colspan="3"
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Rythu Bharosa Status</th>
                                                    </tr>
                                                    <tr class="aftr">
                                                        <th
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Families with &lt; 2Acres</th>
                                                        <th
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Families with &gt; 2Acres</th>
                                                        <th
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Families with No Land</th>
                 
                                                        <th

                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Eligible Families</th>
                                                        <th
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Rejected Families</th>
                                                        <th
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Families Not Covered</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                   
                                                </tbody>
                    
                                            </table>
                    
                    
                                        </div>
                    
                                    </div>
                    
                                    <div class="row">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-1">
                                            <%--<input type="radio" value="3.2Lacs" name="filter_select" id="filter_select" checked="checked"
                                                required="" onchange="filterData(this.id);">
                                            <label class="mr-2"><b>3.21</b></label>--%>

                                              <label class="Radio Radio--large" for="rbgst">
                                            <input type="radio" checked="checked" class="Radio-Input" id="rbbid" name="in" value="1"><b>3.21</b>
                                        </label>
                                        </div>
                                        <div class="col-md-1">
                                            <%--<input type="radio" value="2.7Lacs" name="filter_select" id="filter_select" required=""
                                                onchange="filterData(this.id);">
                                            <label class="mr-2 ml-2"><b>2.7</b></label>
                                            <input type="hidden" name="landtype" id="landtype" value="3.2Lacs">--%>


                                             <label class="Radio Radio--large" for="rbgst">
                                     <input type="radio" class="Radio-Input" id="rbid" name="in" value="2"><b>2.7</b>
                                        </label>
                                        </div>
                                         <div class="col-md-2">
                                            <%--<input type="radio" value="3.2Lacs" name="filter_select" id="filter_select" checked="checked"
                                                required="" onchange="filterData(this.id);">
                                            <label class="mr-2"><b>3.21</b></label>--%>

                                              <label class="Radio Radio--large" for="rbgst">
                                            <input type="radio" checked="checked" class="Radio-Input" id="rbl" name="inl" value="3"><b>Land Holding</b>
                                        </label>
                                        </div>
                                          <div class="col-md-2">
                                            <%--<input type="radio" value="2.7Lacs" name="filter_select" id="filter_select" required=""
                                                onchange="filterData(this.id);">
                                            <label class="mr-2 ml-2"><b>2.7</b></label>
                                            <input type="hidden" name="landtype" id="landtype" value="3.2Lacs">--%>


                                             <label class="Radio Radio--large" for="rbgst">
                                     <input type="radio" class="Radio-Input" id="rbr" name="inl" value="4"><b>Rythu Bharosa</b>
                                        </label>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                    
                                    <div class="row d-flex justify-content-center">

                                        <div class="col-md-2 d-flex">
                                        <label>ITDA: </label>
                                           <select class="form-control" id="Itda">
							<option value="0">Select Itda</option>
							
						</select>
                                        </div>
                    
                                        <div class="col-md-2 d-flex">
                                        <label>District:</label>
                                             <select class="form-control" id="District">
							<option value="0">Select District</option>
							
						</select>
                                        </div>
                    
                                        
                                        <div class="col-md-2 d-flex">
                                        <label>Mandal:</label>
                                             <select class="form-control" id="Mandal">
							<option value="0">Select Mandal</option>
							
						</select>
                                        </div>
                    
                                        
                                        <div class="col-md-2 d-flex">
                                        <label>Village:</label>
                                              <select class="form-control" id="Village">
							<option value="0">Select Village</option>
							
						</select>
                                        </div>
                    
                                        
                                        <div class="col-md-2 d-flex">
                                        <label>Status:</label>
                                             <select class="form-control" id="Status">
							<option value="0">Select Status</option>
							
						</select>
                                        </div>
                                    </div>

                                    <div class="row justify-content-center mt-3">
                                        <div class="col-md-12">
                                            <div class="table-responsive">
                                                <div id="table-container">
                                                    <div class="headertable">
                                                        <div class="showdetails">
                                                            <table class="table table-bordered" style="text-align: center;margin: 0 auto;" id="land_table">
                                                                <thead class="bg-custom">
                                                                    
                                                                      <tr>
                                                                        <th colspan="9"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                                         Land Holding Details</th>
                                                                          </tr>
                                                                    <tr>
                                                                        <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                                            S.No</th>
                                                                        <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                            Ration Card No</th>
                                                                        <%-- <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                           Aadhar No.</th>--%>
                                                                        <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                            Family Member Name</th>
                                                                        <th colspan="5"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 145px;">
                                                                            Land Details</th>
                                                                       <%-- <th colspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 95px;">
                                                                            Rythu Bharosa Status</th>--%>
                                                                        <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                          TWD Dept. Comments</th>
                                                                    </tr>
                                                                    <tr class="aftr">
                                                                        <th colspan="2"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 185px;">
                                                                            WebLand</th>
                                                                        <th colspan="2"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 95px;">
                                                                            RoFR</th>
                                              <th rowspan="2"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                           New Dkt Extent.</th>
                                                                       <%-- <th rowspan="2"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                            Status</th>
                                                                        <th rowspan="2"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                            Amount</th>
                                                                        <th rowspan="2"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                                            Reason</th>--%>
                                                                    </tr>
                                                                    <tr class="aftr1">
                                                                        <th
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;width:100px;">
                                                                            Survey No.</th>
                                                                      <%--  <th
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;width:100px;">
                                                                            Khata No.</th>--%>
                                                                            
                                                                        <th
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                            Extent.</th>
                                                                       
                                                                    
                                                                        <th

                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                            Compartment No.</th>
                                                                        <th
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                            Extent.</th>
                                                                        <%-- <th
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                           Patta No.</th>--%>
                                                                            </tr>
                                                                </thead>
                                                                <tbody>
                                                               
                                            
                                            
                                            
                                                                </tbody>
                                            
                                                            </table>
                                            
                                            
                                                            
                                                             <table class="table table-bordered" style="text-align: center;margin: 0 auto;" id="Rythu_tbl">
                                                                <thead class="bg-custom">
                                                                    
                                                                      <tr>
                                                                        <th colspan="12"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                                         Rythu Bharosa Details</th>
                                                                          </tr>
                                                                    <tr>
                                                                        <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                                            S.No</th>
                                                                        <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                            Ration Card No</th>
                                                                         <%--<th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                           Aadhar No.</th>--%>
                                                                        <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                            Family Member Name</th>
                                                                        <th colspan="5"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 145px;">
                                                                            Land Details</th>
                                                                        <th colspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 95px;">
                                                                            Rythu Bharosa Status</th>
                                                                       <%-- <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                       New DKT</th>
                                                                         <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                        Status</th>
                                                                         <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                        Amount</th>
                                                                         <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                         Reason</th>--%>
                                                                        <th rowspan="3"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                          TWD Dept. Comments</th>
                                                                    </tr>
                                                                    <tr class="aftr">
                                                                        <th colspan="2"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 185px;">
                                                                            WebLand</th>
                                                                        <th colspan="2"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 95px;">
                                                                            RoFR</th>
                                            <th rowspan="2"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">
                                                                       New DKT</th>
                                                                        <th rowspan="2"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                            Status</th>
                                                                        <th rowspan="2"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                            Amount</th>
                                                                        <th rowspan="2"
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                                            Reason</th>
                                                                    </tr>
                                                                    <tr class="aftr1">
                                                                        <th
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;width:100px;">
                                                                            Survey No.</th>
                                                                      <%--  <th
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;width:100px;">
                                                                            Khata No.</th>--%>
                                                                            
                                                                        <th
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                            Extent.</th>
                                                                        
                                                                    
                                                                        <th

                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                            Compartment No.</th>
                                                                        <th
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                            Extent.</th>
                                                                        <%-- <th
                                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">
                                                                           Patta No.</th>--%>
                                                                            </tr>
                                                                </thead>
                                                                <tbody>
                                                               
                                            
                                            
                                            
                                                                </tbody>
                                            
                                                            </table>

                                            
                                                      </div>
                                            
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                    
                    
                                   
                                </div>
                            </div>
                    
                        </div>
                    </div>


                </div>
            </div>
        </main>
      </div>
    </div>  
     
       <script src="js/custom.js"></script>
<%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>--%>
  
     <%-- <script src="https://code.jquery.com/jquery-1.12.1.min.js"></script>--%>
    <script src="../linksforcdns/Js/jquery-1.12.1.min.js"></script>
     <script src="../MapJsfloder/FamilyWiseLandInfo.js"></script>

    <%--<link href="../css/datatables.min.css" rel="stylesheet" />
    <script src="../js1/datatables.min.js"></script>--%>
    <%--<script src="../js/dataTables.rowsGroup.js"></script>--%>
  <link href="../js/datatable.css" rel="stylesheet" />
    <script src="../js/datatable.js"></script>
    <script src="../js1/Jquery.rowspanizer.js"></script>
   <%-- <script src="../js/jquery.rowspanizer.js"></script>
    <script src="../js/jquery.rowspanizer.min.js"></script>--%>
    <script src="../js/jquery.table2excel.js"></script>
</asp:Content>
