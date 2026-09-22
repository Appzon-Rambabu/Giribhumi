$(document).ready(function () {
    $('#FarmerUpdateId').hide();
    $("#submitBtn").click(function () {
        $("#txtbenid").submit();
        /*GetSelected();*/
        $("#FarmerUpdateId").show();
    });
    // Here data from table click on checkbox
    $(document).on('click', '#FarmerUpdateId tbody tr', function () {
        var SBeneID = $(this).find('td:eq(2)').text();
        var SAaharID = $(this).find('td:eq(3)').text();
        var SFarmerID = $(this).find('td:eq(4)').text();
        var SFatherID = $(this).find('td:eq(5)').text();
        $('#BenID').val(SBeneID);
        $('#aadharID').val(SAaharID);
        $('#farmerID').val(SFarmerID);
        $('#fatherID').val(SFatherID);
        // Here store value to Hiddenfiled
        let inputValue = $("#aadharID").val();
        $("#hiddenElement").val(inputValue);
        sessionStorage.setItem('AADHAAR', inputValue)
    })
    // Here Modal Popup Close Once click on closebutton
    $("#btnClosePopup").click(function () {
       
        $("#myModal").hide();
        $('.checkbox').attr('checked', false);
    });
    $("#btnClose").click(function () {
       
        $("#myModal").hide();
        $('.checkbox').attr('checked', false);
    });

    $('#updateId').click(function () {
        updatedetails();
    });
    // Here is validation
    $('#submitBtn').click(function () {
       
        var VBenid ,
            VBenid = $("#txtbenid").val();
        if (VBenid == '')
        {
            alert("Please Enter Beneficiary ID");
            return false;
        }
        //if (VBenid.length == '10') {
        //    alert("Please Enter Vaild Beneficiary ID");
        //    return false;
        //}
    })
    // Here Validations 
    $('#updateId').click(function () {

        var Vaadhar; var Vfarmer; var Vfather;
       
        Vaadhar = $("#aadharID").val();
        Vfarmer = $("#farmerID").val();
        Vfather = $("#fatherID").val();
        if (Vaadhar == '') {
            alert("Please Enter Aadhaar Number");
            return false;
        }
        if (Vfarmer == '') {
            alert("Please Enter Farmer Name");
            return false;
        }
        if (Vfather == '') {
            alert("Please Enter Father Name");
            return false;
        }
    })
    
})


// Here Get Table 
function GetDetails() {

    var screen = "FarmerUpdate";
    var beneficiaryId = $('#txtbenid').val();
    var Ptype = "1"
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Farmer_Update',
        data: "{'type':'" + screen + "','Benificiary_id':'" + beneficiaryId + "','Type':'" + Ptype +"'}",
        dataType: "json",
        success: function (response) {
            console.log(response);
            var rows = "";
            UIDList = response;
            data = response.Data;
            
            for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
                rows += "<tr><td class='text-right'>" + (i + 1) + "</td><td class='text-center'><input type='checkbox' id='chk_" + i + "' onclick='GetSelected()' /></td><td >" + response.Data[i].benficiary_id + "</td><td>" + response.Data[i].Aadhaar_NO + "</td><td >" + response.Data[i].ROFR_PATTADAAR + "</td><td >" + response.Data[i].Father_Name + "</td><td >" + response.Data[i].Total_Extent + "</td></tr>";
                sessionStorage.setItem('aadhaar', response.Data[i].Aadhaar_NO);
            }
            $('#FarmerUpdateId tbody').empty();
            $(rows).appendTo("#FarmerUpdateId tbody");

        },
        error: function (result) {
            alert(result);
        }

    });

}
// Here Select Checkboxs
function GetSelected() {
   
    $('input[type="checkbox"]').on('change', function (e) {
        $('.checkbox').attr('checked', false);
        if (e.target.checked) {
           
            $('#myModal').show();
        }
    });
   
}
// Here UpdatedDetails
function updatedetails() {
   
    var screen = "FDataUpdate";
    var ben = $('#BenID').val();
    var ptype = "2"
    var aadhar = $('#aadharID').val();
    var farmername = $('#farmerID').val();
    var fathername = $('#fatherID').val();
    var inputaadhar = sessionStorage.getItem('AADHAAR');
    if (inputaadhar == aadhar)
    {
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/Farmer_Data_Update',
            data: "{'type':'" + screen + "','Benificiary_id':'" + ben + "','Aadhaar_NO':null,'ROFR_PATTADAAR':'" + farmername + "','fathername':'" + fathername + "','Type':'" + ptype + "'}",
            dataType: "json",
            success: function (response) {
                alert("Data Successfully Updated")
                GetDetails();
                $('#myModal').hide();
                $('.checkbox').prop('checked', false);
            },
            error: function (result) {
                alert(result);
            }

        });
    }
    else if (inputaadhar != aadhar) {
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/Farmer_Data_Update',
            data: "{'type':'" + screen + "','Benificiary_id':'" + ben + "','Aadhaar_NO':'" + aadhar + "','ROFR_PATTADAAR':'" + farmername + "','fathername':'" + fathername + "','Type':'" + ptype + "'}",
            dataType: "json",
            success: function (response) {

                alert(response.Message);

                GetDetails();
                $('#myModal').hide();
                $('.checkbox').prop('checked', false);
            },
            error: function (result) {
                alert(result);
            }

        });
    }
}




