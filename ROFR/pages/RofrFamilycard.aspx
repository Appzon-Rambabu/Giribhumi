<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="RofrFamilycard.aspx.cs" Inherits="ROFR.pages.RofrFamilycard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
		
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
	<style>
	td{
         text-align: left;
      }
	</style>
	 
    <script type="text/javascript">
					
        function codevalidate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9]|\0/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function mastervalidatenumerics(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z]|\A/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
		
		
		
    </script>
	
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-top: 5px;">
        <div class="col-md-12 ml-sm-auto col-lg-12 px-1">
            <div class="row justify-content-between">
                <div class="col-md-4"></div>
                <div class="col-md-4 text-left">
                    <h4 class="font-weight-bold">RoFR-Webland Card Details</h4>
                </div>
				
                       <div class="col-md-4 d-flex py-2">
                   <!--  Search: 
               <input type="text" id="aadhaarNumber" placeholder="Aadhaar No.." class="form-control ml-2" disabled style="padding: 0 0 0 10px; background: #dae4ed; max-width: 190px;" autocomplete="off">&nbsp &nbsp
               <button id="btn_submit" Text="Get"  type="button" class="btn btn-success" style="max-height: 80px;">Get</button>-->
                
				</div>
				
            </div>
            <section class="content-area">
                <div class="container-fluid">
                    <div class="card">
                        <div class="card-body">
						
				<div class="preloader" style="background: rgba(255,255,255,0.5);">
        <div class="spinner"></div>
        <span id="loading-msg">
           <%-- <img src="../Rofrnewassets/aplogo.png">--%>
             <img src="../Rofrnewassets/images/aplogo.png" />
        </span>
      </div>
              
              </div>
                            <div class="row">
                                <div class="col-auto"><b>ITDA:</b></div>
                                <div class="col-md-2">
                                    <select name="itda" id="itda" class="form-control">
                                               <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
                                    </select>
                                </div>
                                <div class="col-md-2" style="display: none;">
                                    <select name="district" id="district"  class="form-control" >
                                        <option value="" selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;---Select---</option>
                                    </select>
                                </div>

                                <div class="col-auto"><b>Mandal:</b></div>
                                <div class="col-md-2">
                                    <select name="mandal" id="mandal" class="form-control">
                                        <option value="" selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;---Select---</option>
                                    </select>
                                </div>
                                <div class="col-auto"><b>Village Secretariat:</b></div>
                                <div class="col-md-2">
                                    <select name="village" id="village" class="form-control">
                                        <option value="" selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;---Select---</option>
                                    </select>
                                </div>
                                <div class="col-md-1"><b>Ration Card Number:</b></div>
                                <div class="col-md-2">
                                    <select name="rationcard" id="rationcard" class="form-control">
                                        <option value="" selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;---Select---</option>
                                    </select>
                                </div>
                                <div class="col-auto"><b>Year:</b></div>
                                <div class="col-md-2">
                                    <select name="year" id="yearid" class="form-control">
                                        <option value="" selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;---Select---</option>
                                        
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card mt-3 mb-3" id="FamilyBenefitId">
                        <div class="card-body">
                            <div class="row justify-content-center pattadhar-details">
                                <div class="col-md-10 border-dark border">
                                    <div class="row pattadhar-title bg-success">
                                        <div class="col-md-12">
                                            <h2 class="text-center text-white"><i class="fa fa-list-alt"></i>Family Benefit Card</h2>

                                        </div>
                                         <!-- <div> <a href="#"><img  src='./images/print.png' width="100" height="100" style="float:right;margin:3px" onclick="printPattaCardDet()"></a></div> -->
                                    </div>

                                    <div class="row pattadhar-middle">
                                        <div class="col-md-8 mt-2 px-0">

                                            <div class="family-details ">
                                                <strong class="pl-1 bg-info" style="font-size: large; color: #fff; display: flex; justify-content: space-between;"><span>1. Family Details</span>  <label id="RationCardNo"></label></strong>
                                                <table class="table table-bordered mb-0" id="FamilyCard1">
                                                    <thead>
                                                        <!-- <tr>
                                                              <th class="text-center bg-primary text-white" colspan="5">Family Details</th>
                                                            </tr> -->
                                                        <tr>
                                                            <th style="width: 50px;">S.No</th>
                                                            <th style="text-align:center">Name</th>
                                                            <th  style="text-align:center">Gender</th>
                                                            <th  style="text-align:center">Relation</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
															<tr>
															<td></td>
															<td></td>
															<td></td>
															<td></td>
															</tr>
                                                    </tbody>
                                                </table>

                                            </div>

                                            <div class="land-details mt-2">

                                                <strong style="font-size: large; color: #ffffff; text-align: left; display: block;" class="pl-1 bg-info">2. Land Details</strong>
                                                <!-- <hr class="mt-1 mb-2"/> -->

                                                <table class="table table-bordered mb-1" id="Familywebland">
                                                    <thead>
                                                        <tr>
                                                            <th class="bg-white text-left text-orange font-weight-bold" colspan="6" style="background-color: white">Webland</th>
                                                        </tr>
                                                        <tr>
                                                            <th style="width: 50px;">S.No</th>
                                                            <th  style="text-align:center">Pattadar Name</th>
                                                            <th  style="text-align:center">Village</th>
                                                            <th  style="text-align:center">Katha No</th>
                                                            <th  style="text-align:center">Survey No</th>
                                                            <th  style="text-align:center">Total Ext(In Acres)</th>
												       </tr>
														
                                                    </thead>
                                                    <tbody>
													<tr style="text-align:center">
															
															

                                                     </tr>
                                                    </tbody>
                                                </table>
														<table class="table table-bordered mb-1" >
                                                    <thead>
                                                        <tr>
                                                            <th class="bg-white text-right text-orange font-weight-bold" colspan="6" style="background-color: white">
															WeblandTotalExtent:<label id="lbltotalwebland"></label></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
													 

                                                    </tbody>
                                                </table> 
                                                <table class="table table-bordered mb-1" id="FamilyRofrLand">
                                                    <thead>
                                                        <tr class="bg-white">
                                                            <th class="bg-white text-left text-orange font-weight-bold" colspan="6" style="background-color: white">ROFR Land</th>
                                                        </tr>
                                                        <tr style="font-weight: bold;">
                                                            <th style="width: 50px;">S.No</th>
                                                            <th  style="text-align:center">Pattadar Name</th>
                                                            <th  style="text-align:center">Village</th>
                                                            <th  style="text-align:center">Patta No</th>
                                                            <th  style="text-align:center">Compartment/Beat No</th>
                                                            <th  style="text-align:center">Extent(In Acres)</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
													 

                                                    </tbody>
                                                </table>
												<table class="table table-bordered mb-1" >
                                                    <thead>
                                                        <tr>
                                                            <th class="bg-white text-right text-orange font-weight-bold" colspan="6" style="background-color: white">
															ROfrlandTotalExtent:<label id="lbltotalrofrland"></label></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
													 

                                                    </tbody>
                                                </table> 
                                           <table class="table table-bordered mb-1" id="FamilyTotalExtent">
                                                    <thead>
                                                        
                                                    </thead>
                                                    <tbody>
													 

                                                    </tbody>
                                                </table>



                                            </div>

                                            <div class="land-details mt-2">


                                                <div class="land-details mt-2 ">
                                                    <strong class="pl-1 bg-info" style="font-size: large; color: #fff; text-align: left; display: block;">3. Rythu Bharosa Details</strong>
                                                    <table class="table table-bordered mb-1" id="RythuBharosaDetails">
                                                        <thead>
                                                            <!--  <tr>
                                                              <th class="text-center bg-primary text-white" colspan="5">Rythu Bharosa Details</th>
                                                            </tr> -->
                                                            <tr>
                                                                <th style="width: 50px;">S.No</th>
                                                                <th  style="text-align:center">Katha No / Patta No</th>
                                                                <th  style="text-align:center">Beneficiary Name</th>
                                                                <th  style="text-align:center">Paid Date</th>
                                                                <th  style="text-align:center">Amount</th>

                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>

                                            <div class="land-details mt-2">


                                                <div class="land-details mt-2">
                                                    <strong class="pl-1 bg-info" style="font-size: large; color: #fff; text-align: left; display: block;">4. MGNREGA Details</strong>
                                                    <table class="table table-bordered mb-1" id="MGNREGA">
                                                        <thead>

                                                            <tr>
                                                                <th style="width: 50px;">S.No</th>
                                                                <th  style="text-align:center">Job card ID</th>
                                                                <th  style="text-align:center">Beneficiary Name</th>
                                                                <th  style="text-align:center">Year</th>
                                                                <th  style="text-align:center">No.of Man days</th>
                                                                <th  style="text-align:center">Amount</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>


                                        </div>


                                        <div class="col-md-4">

                                            <div class="land-fencing border-0 bg-light mt-2 mb-3 p-2 ">
                                                <img id="imgIdentity" src="#" class="img-fluid" style="height: 300px; width:450px"/>
                                            </div>



                                            <div class="">
                                                <table class="table table-bordered my-1" id="Navarathnalu">
                                                    <thead>
                                                        <tr>
                                                            <th class="text-center bg-primary text-white" colspan="5">Navaratnalu</th>
                                                        </tr>
                                                        <tr>
                                                            <th style="width: 50px;">S.No</th>
                                                            <th  style="text-align:center">Scheme Name</th>
                                                            <th  style="text-align:center">Beneficiary Name</th>
                                                            <th  style="text-align:center">Amount</th>
                                                            <!-- <th>Paid Date</th> -->
                                                        </tr>
                                                    </thead>
                                                    <tbody>


                                                        



                                                    </tbody>
                                                </table>
                                            </div>


                                        </div>



                                    </div>
                                    <div class="row"></div>

                                    <div class="row">
                                        <div class="col-md-8">
                                            <h6 class="text-right font-weight-bold">Total Benefited Amount of the Family :&nbsp;&nbsp;&nbsp;&nbsp;<label id="lbltotal"></label></h6>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 text-center">
                                    Tribal Welfare Department
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </section>
        </div>

    </div>
   
     <script src="js/custom.js"></script>
	 <script src="../newcss/js/bootstrap.min.js"></script>
    <script src="../newcss/js/jquery-3.5.1.min.js"></script>
	
	<script src="../js/jquery-ui.js"></script>
         <script src="../MapJsfloder/Familycard.js"></script>
</asp:Content>
