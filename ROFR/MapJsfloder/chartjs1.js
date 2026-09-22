function chartRefresh() {
    // alert(vhabcode);
    // alert(vassetcode);
    // alert(vsubassetcode);
    //alert(refid);
    if (vrefid != "" && vrefid != undefined) {
        Assetimageview(vhabcode, vsubassetcode, vrefid);
    }
};


function Assetimageview(vhabcode, vsubassetcode, vrefid) {
    var hidField1 = vhabcode;//"021505015004";
    var hidField2 = vsubassetcode;//"ED90402048";
    var hidField3 = vrefid;//"ED90402048";
    if (vrefid != "" && vrefid != undefined) {
        $.ajax(
       {
           type: 'POST',
           contentType: 'application/json; charset=utf-8',
           url: '/api/ITDA/SubAssetsDetails',
           data: "{'HAB':'" + hidField1 + "','DEPARTMENT':'" + hidField3 + "','SUBASSET':'" + hidField2 + "'}",
           dataType: "json",
           success: function (response) {
               //console.log(JSON.stringify(response));
               var dist = response;
               if (dist.message != "getSubassetDetails not available") {
                   var aimg2 = dist.msg_cat.SUB_ASSET_IMG1;
                   var aimg3 = dist.msg_cat.SUB_ASSET_IMG2;
                   var aimg4 = dist.msg_cat.SUB_ASSET_IMG3;
                   if (aimg2 != "NA" && aimg3 != "NA" && aimg4 != "NA") {
                       var aimg2 = 'data:image/png;base64,' + dist.msg_cat.SUB_ASSET_IMG1;
                       var aimg3 = 'data:image/png;base64,' + dist.msg_cat.SUB_ASSET_IMG2;
                       var aimg4 = 'data:image/png;base64,' + dist.msg_cat.SUB_ASSET_IMG3;
                     
                       // alert(dist.msg_cat.ASSET_NAME);
                       $("#img1").attr('src', aimg2);
                       
                       document.getElementById("abc1").href = aimg2;

                       // alert(dist.msg_cat.ASSET_NAME);
                       $("#img2").attr('src', aimg3);
                       
                       document.getElementById("abc2").href = aimg3;

                       // alert(dist.msg_cat.ASSET_NAME);
                       $("#img3").attr('src', aimg4);
                       
                       document.getElementById("abc3").href = aimg4;
                   }
                   else if (aimg2 != "NA" && aimg3 == "NA" && aimg4 == "NA") {

                     
                       var aimg2 = 'data:image/png;base64,' + dist.msg_cat.SUB_ASSET_IMG1;
                       $("#img11").attr('src', aimg2);
                       $("#img41").attr('src', aimg2);
                       document.getElementById("abc11").href = aimg2;
                   }

                   var asset = "";
                   var subasset = "";
                   if (vsubassetcode == "MI91403242") {
                       asset = "SHG Building";
                       subasset = "SHG Building";
                   }
                   else {
                       asset = dist.msg_cat.ASSET_NAME;
                       subasset = dist.msg_cat.SUBASSET_NAME;

                   }
                   $("#DEP").html(dist.msg_cat.DEPARTMENT);
                   $("#ASSET").html(asset);
                   $("#SUBASSET").html(subasset);
                   $("#Con").html(dist.msg_cat.SUBASSET_CONDITION);
               }
               else {
                   alert("Images are not available");
               }

           },
           error: function (result) {
               alert("Error");
           }

       });
    }
}



