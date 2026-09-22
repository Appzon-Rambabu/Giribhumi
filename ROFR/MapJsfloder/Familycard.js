

$(document).ready(function () {	
	 $('#FamilyBenefitId').hide();
    var type = "ITDA";
    var uid = "";
    var finyear = "";
    var did = "";
    var mid = "";
    var vid = "";
    var ration = "";
    
    var dist = "";
    //new change
    var rythuDetails = "";
    var UIDList = "";
	var rationNo="";
    var ration_Or_Uid = "";
	var totalamount=0;
	
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/RofrFamilyCard',
        data: "{'screen':'" + type + "'}",
        dataType: "json",
        success: function (response) {
            console.log(JSON.stringify(response));
			$("#itda").append('<option value="">Select</option>');
            var Itda = response;
            for (var i = 0; i < Itda.Data.length; i++) {
                var opt1 = new Option(Itda.Data[i].ITDA);
                var opt2 = new Option(Itda.Data[i].ITDA);
				
                $("#itda").append($('<option>').val(opt2.text).text(opt1.text));
				
            }
			$('.preloader').hide();
        },
        error: function (result) {
            alert("Error");
        }
    });

    //For district
    $("#itda").change(function () {
		$('.preloader').show();
        $("#district").html("DISTRICT");
        var type = "DISTRICT";
        var Itda = $("#itda").val();
        var uid = "";
        var finyear = "";
        var did = "";
        var mid = "";
        var vid = "";
        var ration = "";
        
        $('#district').find('option').remove();
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + type + "','Itda':'" + Itda + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                dist = response.Data[0].DIST_NAME_EN;
                mandalload(Itda);
            },
            error: function (result) {
                alert("Error");
            }

        });
    });

    
    //For Mandal
    $("#district").change(function () {
		$('.preloader').show();
        $('#district').find('option').remove();
        var screen = "MANDAL";
        var Itda = $("#itda").val();
        var district = $("#district").val();
        var uid = "";
        var finyear = "";
        var did = "";
        var mid = "";
        var vid = "";
        var ration = "";
        
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','Itda':'" + Itda + "','did':'" + district + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#mandal').empty();
                $("#mandal").append('<option value="">Select</option>');

                var Itda = response;
                for (var i = 0; i < Itda.Data.length; i++) {
                    var opt1 = new Option(Itda.Data[i].OFFICE_NAME_EN);
                    var opt2 = new Option(Itda.Data[i].OFFICE_NAME_EN);
					
                    $("#mandal").append($("<option>").val(opt2.text).text(opt1.text));
					$('.preloader').hide();
                }
            },
            error: function (result) {
                alert("Error");
            }
        });
    });

    function mandalload(Itda)
    {
    
        var screen = "MANDAL";
        var uid = "";
        var finyear = "";
        var did = "";
        var mid = "";
        var vid = "";
        var ration = "";
        
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','Itda':'" + Itda + "','did':'" + dist + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
				$('#mandal').empty();
                $("#mandal").append('<option value="">Select</option>');

                //var Itda = response;
                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].OFFICE_NAME_EN);
                    var opt2 = new Option(response.Data[i].OFFICE_NAME_EN);
					
                    $("#mandal").append($("<option>").val(opt2.text).text(opt1.text));
					
				
                }
				 $('.preloader').hide();
            },
            error: function (result) {
                alert(dist+"Error");
            }
        });
    
    }

    //For Villages
    $("#mandal").change(function () {
		$('.preloader').show();
        $('#village').find('option').remove();
        var screen = "VILLAGE_SECRETARIAT";
        var Itda = $("#itda").val();
        var mandal = $("#mandal").val();
        var uid = "";
        var finyear = "";
        var did = "";
        var mid = "";
        var vid = "";
        var ration = "";
        

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','Itda':'" + Itda + "','did':'" + dist + "','mid':'" + mandal + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#village').empty();
                $("#village").append('<option value="">Select</option>');

                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].SECRETARIAT_NAME);
                    var opt2 = new Option(response.Data[i].SECRETARIAT_NAME);
					
                    $("#village").append($("<option>").val(opt2.text).text(opt1.text));
					
                }
				 $('.preloader').hide();
            },
            error: function (result) {
                alert(dist+"Error");
            }
        });
    });
    //For Ration numbers
    $("#village").change(function (e) {
		$('.preloader').show();
        $('#ration').find('option').remove();
        
        var screen = "RATION";
        var Itda = $("#itda").val();
        var mandal = $("#mandal").val();
        var village = $("#village").val();
        var uid = "";
        var finyear = "";
        var did = "";
        var mid = "";
        var vid = "";
        var ration = "";
       
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','Itda':'" + Itda + "','did':'" + dist + "','mid':'" + mandal + "','vid':'" + village + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
				$('#rationcard').empty();
                $("#rationcard").append('<option value="">Select</option>');

                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].EXISTING_RC_NUMBER);
                    var opt2 = new Option(response.Data[i].EXISTING_RC_NUMBER);
					
                    $("#rationcard").append($("<option>").val(opt2.text).text(opt1.text));
					
                }
				$('.preloader').hide();
                
            },
            error: function (result) {
                alert(dist+"Error");
            }
        });
    });

    //For Ration Change

    $("#rationcard").change(function () {
        $('.preloader').show();
        rationNo = $("#rationcard").val();
		
        GetYear();
		
        
    });

    $("#btn_submit").click(function () {
     
	 $('#FamilyBenefitId').show();
        ration_Or_Uid = $("#aadhaarNumber").val();
        AllDetailsForAadhar();
		$('#aadhaarNumber').val(''); // Clear textbox after submit
		
    });

    function AllDetailsForAadhar() {
		
         GetDetails();
         GetLandDetails();
         GetMGNREGADetails();
         GetROFRDetails();         
         GetTotalExtent();
         rythuDetails = "";
         for (var i = 0; UIDList.Data != undefined && i < UIDList.Data.length; i++) {
             GetrythuDetails(UIDList.Data[i].UID_NO);
         }
         GetNavarthnaluDetails();
    }
	
	 function AllDetails() {
       
        GetDetails1();
        GetLandDetails1();
        GetMGNREGADetails1();    
        GetTotalExtent1();
        rythuDetails = "";
        for (var i = 0; UIDList.Data != undefined && i < UIDList.Data.length; i++) {
            GetrythuDetails1(UIDList.Data[i].UID_NO);
        }
		GetNavarthnaluDetails1();
    }
    

    $("#yearid").change(function () {
		$('.preloader').show();
		 $('#FamilyBenefitId').show();
		 		
		AllDetails();     
	
    })
	
	

    //For Fin_Year Change
    function GetYear()
    {
        var currentyear = "";
        var type = "FIN_YEAR";
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + type + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
				$('#yearid').empty();	
                $("#yearid").append('<option value="">Select</option>');
                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].FIN_YEAR);
                    var opt2 = new Option(response.Data[i].FIN_YEAR);
					
                    $("#yearid").append($("<option>").val(opt2.text).text(opt1.text));
                     currentyear=response.Data[3].FIN_YEAR; 
                }

                $("#yearid option[value=2021-2022]").prop('selected', true);
               // AllDetails();  
                $("#yearid").change();
				 $('.preloader').hide();
            },
            error: function (result) {
                alert("Error");
            }
        });
    }
    

    //For Details 

    function GetDetails() {
		
        var screen = "DETAILS";
        
		$('#RationCardNo').empty();
		$("#RationCardNo").append("Aadhaar No::" +ration_Or_Uid);
		
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','uid':'" + ration_Or_Uid + "'}",
            dataType: "json",
            success: function (response) {
                console.log(response);
                var rows = "";
                UIDList = response;
                
                for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
                    rows += "<tr><td class='text-right'>"+(i+1)+"</td><td >" + response.Data[i].MEMBER_NAME_EN + "</td><td>" + response.Data[i].GENDER + "</td><td >" + response.Data[i].RELATION_SHIP + "</td></tr>";
                   
                }
                $('#FamilyCard1 tbody').empty();
                $(rows).appendTo("#FamilyCard1 tbody");
                
            },
            error: function (result) {
                alert(result);
            }
			
        });
		
    }

    //For LandDetails 
    function GetLandDetails() {
		
        var screen = "LAND_DETAILS";
        
        var count = 0;
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','ration':'" + rationNo + "'}",
            dataType: "json",
            success: function (response) {
                console.log(response);

                 var WebLand = "", ROFRLand = "";
				 var totalWebLand=0;
				var totalRofrLand=0;
                for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
                    if (response.Data[i].STATUS == "WEBLAND")
                    {
                        WebLand += "<tr><td class='text-right'>" + (i + 1) + "</td><td>" + response.Data[i].MEMBER_NAME_EN + "</td><td>" + response.Data[i].VILLAGES + "</td><td class='text-right'>" + response.Data[i].KHATA_NO + "</td><td class='text-right'>" + response.Data[i].SURVEY_NO + "</td><td class='text-right'>" + response.Data[i].WEBLAND_EXTENT + "</td></tr>";
					         totalWebLand += parseFloat(response.Data[i].WEBLAND_EXTENT);   
									
                        var x = totalWebLand;
                     x = Math.floor(x * 100) / 100;
					 
                        
					}
                    else {
                        ROFRLand += "<tr><td class='text-right'>" + (i + 1) + "</td><td>" + response.Data[i].MEMBER_NAME_EN + "</td><td>" + response.Data[i].VILLAGES + "</td><td class='text-right'>" + response.Data[i].KHATA_NO + "</td><td class='text-right'>" + response.Data[i].SURVEY_NO + "</td><td class='text-right'>" + response.Data[i].WEBLAND_EXTENT + "</td></tr>";
												
                        totalRofrLand += parseFloat(response.Data[i].WEBLAND_EXTENT);
                                                                      
                        var y = totalRofrLand;
                     y = Math.floor(y * 100) / 100;
					 
					
					}
					
                    
                }
                $('#Familywebland tbody').empty();
				$('#FamilyRofrLand tbody').empty();
                if (WebLand!=""){
                    $(WebLand).appendTo("#Familywebland tbody");
				$('#lbltotalwebland').html(x);
				}
                if (ROFRLand!= ""){
                    $(ROFRLand).appendTo("#FamilyRofrLand tbody");
				$('#lbltotalrofrland').html(y);
				}
				
            },
            error: function (result) {
                alert(result);
            }
        });
		
    }
	 
 
    

    //FOR NAVARATHNALU
    function GetNavarthnaluDetails() {
		
        var screen = "OTHER_SCHEMES_RMG";
        
        var Finyear = $("#yearid").val();
        var count = 0;
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
			 data: "{'screen':'" + screen + "','uid':'" + ration_Or_Uid + "','finyear':'" + Finyear + "'}",
            
            dataType: "json",
            success: function (response) {
                console.log(response);

                var rows = "";
                for (var i = 0; response.Data != undefined &&  i < response.Data.length; i++) {
                    rows += "<tr><td class='text-right'>"+(i+1)+"</td><td>" + response.Data[i].SCHEME_NAME + "</td><td>" + response.Data[i].MEMBER_NAME_EN + "</td><td class='text-right'>" + response.Data[i].AMOUNT + "</td></tr>";
                    if (response.Data[i].AMOUNT != undefined) {
                        totalamount += response.Data[i].AMOUNT;
                    }              

                }
                var x = totalamount;
                x = Math.floor(x * 100) / 100;
                $('#Navarathnalu tbody').empty();
               
			   $(rows).appendTo("#Navarathnalu tbody");
			    $('#lbltotal').html(x);
				totalamount=0;
				$('.preloader').hide();
            },
            error: function (result) {
                alert(result);
            }
        });
		
    }

    //For MGNREGA Details
    function GetMGNREGADetails() {
		
        var screen = "OTHER_SCHEMES";
        
        var Finyear = $("#yearid").val();
        var count = 0;
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
           data: "{'screen':'" + screen + "','uid':'" + ration_Or_Uid + "','finyear':'" + Finyear + "'}",
            dataType: "json",
            success: function (response) {
                console.log(response);

                var rows = "";
                for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
                    rows += "<tr><td class='text-right'>"+(i+1)+"</td><td class='text-right'>" + response.Data[i].JOBCARD_ID + "</td><td>" + response.Data[i].CITIZEN_NAME + "</td><td class='text-right'>" + response.Data[i].FIN_YEAR + "</td><td class='text-right'>" + response.Data[i].NUM_OF_DAYS + "</td><td class='text-right'>" + response.Data[i].AMOUNT + "</td></tr>";
                    if (response.Data[i].AMOUNT != undefined) {
                        totalamount += response.Data[i].AMOUNT;
                    }
                   
				}
                $('#MGNREGA tbody').empty();
                $(rows).appendTo("#MGNREGA tbody");
				 
				
            },
            error: function (result) {
                alert(result);
            }
        });
		
    }

    //For Raythu Details
    function GetrythuDetails(UID_NO) {
		
        var screen = "RYTHU_BHAROSA_DET";
        var Finyear = $("#yearid").val();
        var count = 0;
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','finyear':'" + Finyear + "','uid':'" + UID_NO + "'}",
            dataType: "json",
            success: function (response) {
				console.log(screen+' '+Finyear+' '+UID_NO);
                console.log(response);
              
                for (var i = 0; response.Data != undefined && i < response.Data.length; i++)
                {
                    rythuDetails += "<tr><td class='text-right'>" + (i + 1) + "</td><td class='text-right'>" + response.Data[i].KHATHA_NUMBER + "</td><td>" + response.Data[i].FARMER_NAME + "</td><td class='text-right'>" + response.Data[i].CREDIT_DATE + "</td><td class='text-right'>" + response.Data[i].AMOUNT + "</td></tr>";

                    if (response.Data[i].AMOUNT != undefined)
                    {
				       totalamount += response.Data[i].AMOUNT;
                    }                    
				}
				$('#RythuBharosaDetails tbody').empty();
                $(rythuDetails).appendTo("#RythuBharosaDetails tbody");
                $('.preloader').hide();
			},
            error: function (result) {
                alert(result);
            }
        });
		
    }

    // For Total Extent

    function GetTotalExtent() {
		
        var screen = "TOTAL_EXTENT";
        // var Ration = $("#rationcard").val();
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','uid':'" + ration_Or_Uid + "'}",
            dataType: "json",
            success: function (response) {
                console.log(response);
                var rows = "";
                    rows += "<tr><td class='text-right'> Total Extent of the family(In Acres):" + response.Data[0].TOTAL_EXTENT + "</td></tr>";
                $('#FamilyTotalExtent tbody').empty();
                $(rows).appendTo("#FamilyTotalExtent tbody");
				$('#imgIdentity').attr('src', response.Data[0].LAND_IMG_1);
                },

            error: function (result) {
                alert(result);
            }
        });
		
    }
	
	 //for searching functionality
    function GetDetails1() {
		
        var screen = "DETAILS";
        
        $('#RationCardNo').empty();
        $("#RationCardNo").append("RationCard No::" + rationNo);

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','ration':'" + rationNo + "'}",
            dataType: "json",
            success: function (response) {
                console.log(response);
                var rows = "";
                UIDList = response;
                
                for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
                    rows += "<tr><td class='text-right'>" + (i + 1) + "</td><td>" + response.Data[i].MEMBER_NAME_EN + "</td><td>" + response.Data[i].GENDER + "</td><td>" + response.Data[i].RELATION_SHIP + "</td></tr>";
                    
                }
                $('#FamilyCard1 tbody').empty();
                $(rows).appendTo("#FamilyCard1 tbody");
               
            },
            error: function (result) {
                alert(result);
            }
        });
		
    }
    //For LandDetails 
    function GetLandDetails1() {
		
        var screen = "LAND_DETAILS";
        
        var count = 0;
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','ration':'" + rationNo + "'}",
            dataType: "json",
            success: function (response) {
                console.log(response);

                 var WebLand = "", ROFRLand = "";
				 var totalWebLand=0;
				var totalRofrLand=0;
                for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
					if (response.Data[i].STATUS == "WEBLAND") {
                        WebLand += "<tr><td class='text-right'>" + (i + 1) + "</td><td>" + response.Data[i].MEMBER_NAME_EN + "</td><td>" + response.Data[i].VILLAGES + "</td><td class='text-right'>" + response.Data[i].KHATA_NO + "</td><td class='text-right'>" + response.Data[i].SURVEY_NO + "</td><td class='text-right'>" + response.Data[i].WEBLAND_EXTENT + "</td></tr>";
					      totalWebLand += parseFloat(response.Data[i].WEBLAND_EXTENT);   
									
                        var x = totalWebLand;
                     x = Math.floor(x * 100) / 100;
					 
                        
					}
                    else {
                        ROFRLand += "<tr><td class='text-right'>" + (i + 1) + "</td><td>" + response.Data[i].MEMBER_NAME_EN + "</td><td>" + response.Data[i].VILLAGES + "</td><td class='text-right'>" + response.Data[i].KHATA_NO + "</td><td class='text-right'>" + response.Data[i].SURVEY_NO + "</td><td class='text-right'>" + response.Data[i].WEBLAND_EXTENT + "</td></tr>";
												
                        totalRofrLand += parseFloat(response.Data[i].WEBLAND_EXTENT);
                                                                      
                        var y = totalRofrLand;
                     y = Math.floor(y * 100) / 100;
					 
					
					}
					
                    
                }
                $('#Familywebland tbody').empty();
				$('#FamilyRofrLand tbody').empty();
                if (WebLand!=""){
                    $(WebLand).appendTo("#Familywebland tbody");
				$('#lbltotalwebland').html(x);
				}
                if (ROFRLand!= ""){
                    $(ROFRLand).appendTo("#FamilyRofrLand tbody");
				$('#lbltotalrofrland').html(y);
				}
				
            },
            error: function (result) {
                alert(result);
            }
        });
		
    }
	
   
    //FOR NAVARATHNALU
    function GetNavarthnaluDetails1() {
		
        var screen = "OTHER_SCHEMES_RMG";
        
        var Finyear = $("#yearid").val();
        var count = 0;
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','ration':'" + rationNo + "','finyear':'" + Finyear + "'}",
            dataType: "json",
            success: function (response) {
                console.log(response);

                var rows = "";
                for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
					
						rows += "<tr><td class='text-right'>" + (i + 1) + "</td><td>" + response.Data[i].SCHEME_NAME + "</td><td>" + response.Data[i].MEMBER_NAME_EN + "</td><td class='text-right'>" + response.Data[i].AMOUNT + "</td></tr>";
					                    

                    if (response.Data[i].AMOUNT != undefined) {
                        totalamount += response.Data[i].AMOUNT;
                    }	
                }
                var x = totalamount;
                x = Math.floor(x * 100) / 100;

                $('#Navarathnalu tbody').empty();
                $(rows).appendTo("#Navarathnalu tbody");
				$('#lbltotal').html(x);
				totalamount=0;
				$('.preloader').hide();
            },
            error: function (result) {
                alert(result);
            }
        });
		
    }
    //For MGNREGA Details
    function GetMGNREGADetails1() {
		
        var screen = "OTHER_SCHEMES";
        
        var Finyear = $("#yearid").val();
        var count = 0;
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','ration':'" + rationNo + "','finyear':'" + Finyear + "'}",
            dataType: "json",
            success: function (response) {
                console.log(response);

                var rows = "";
                for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
                    rows += "<tr><td class='text-right'>" + (i + 1) + "</td><td class='text-right'>" + response.Data[i].JOBCARD_ID + "</td><td>" + response.Data[i].CITIZEN_NAME + "</td><td class='text-right'>" + response.Data[i].FIN_YEAR + "</td><td class='text-right'>" + response.Data[i].NUM_OF_DAYS + "</td><td class='text-right'>" + response.Data[i].AMOUNT + "</td></tr>";
                    if (response.Data[i].AMOUNT != undefined) {
                        totalamount += response.Data[i].AMOUNT;
                    }
				   
                }
                $('#MGNREGA tbody').empty();
                $(rows).appendTo("#MGNREGA tbody");
				
            },
            error: function (result) {
                alert(result);
            }
        });
		
    }
    //For Raythu Details
    function GetrythuDetails1(UID_NO) {
		
        var screen = "RYTHU_BHAROSA_DET";
        var Finyear = $("#yearid").val();
        var count = 0;
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','finyear':'" + Finyear + "','uid':'" + UID_NO + "'}",
            dataType: "json",
            success: function (response) {
                console.log(screen + ' ' + Finyear + ' ' + UID_NO);
                console.log(response);
                for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
                    rythuDetails += "<tr><td class='text-right'>" + (i + 1) + "</td><td class='text-right'>" + response.Data[i].KHATHA_NUMBER + "</td><td>" + response.Data[i].FARMER_NAME + "</td><td class='text-right'>" + response.Data[i].CREDIT_DATE + "</td><td class='text-right'>" + response.Data[i].AMOUNT + "</td></tr>";
                    if (response.Data[i].AMOUNT != undefined) {
                        totalamount += response.Data[i].AMOUNT;
                    }
				  
                }

                $('#RythuBharosaDetails tbody').empty();
                $(rythuDetails).appendTo("#RythuBharosaDetails tbody");
                $('.preloader').hide();
            },
            error: function (result) {
                alert(result);
            }
        });
		
    }
    // For Total Extent
    function GetTotalExtent1() {
		
        var screen = "TOTAL_EXTENT";
       
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/RofrFamilyCard',
            data: "{'screen':'" + screen + "','ration':'" + rationNo + "'}",
            dataType: "json",
            success: function (response) {
                console.log(response);
                var rows = "";


                rows += "<tr><td class='text-right'> Total Extent of the family(In Acres):" + response.Data[0].TOTAL_EXTENT + "</td></tr>";

                $('#FamilyTotalExtent tbody').empty();
                $(rows).appendTo("#FamilyTotalExtent tbody");
                $('#imgIdentity').attr('src', response.Data[0].LAND_IMG_1);
				
            },

            error: function (result) {
                alert(result);
            }
        });
		
    }
});
