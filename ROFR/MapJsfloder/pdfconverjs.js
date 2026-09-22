function Export() {
    getPDF();
}
function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    console.log("URL", url);
    console.log("NAME", name);
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function getPDF() {

    var HTML_Width = $(".canvas_div_pdf").width();
    var HTML_Height = $(".canvas_div_pdf").height();
    var top_left_margin = 15;
    var PDF_Width = HTML_Width + (top_left_margin * 2);
    var PDF_Height = (PDF_Width * 1.5) + (top_left_margin * 2);
    var canvas_image_width = HTML_Width;
    var canvas_image_height = HTML_Height;

    var totalPDFPages = Math.ceil(HTML_Height / PDF_Height) - 1;


    html2canvas($(".canvas_div_pdf")[0], { allowTaint: true }).then(function (canvas) {
        canvas.getContext('2d');

        console.log(canvas.height + "  " + canvas.width);


        var imgData = canvas.toDataURL("image/jpeg", 1.0);
        var pdf = new jsPDF('p', 'pt', [PDF_Width, PDF_Height]);
        pdf.addImage(imgData, 'JPG', top_left_margin, top_left_margin, canvas_image_width, canvas_image_height);


        for (var i = 1; i <= totalPDFPages; i++) {
            pdf.addPage(PDF_Width, PDF_Height);
            pdf.addImage(imgData, 'JPG', top_left_margin, -(PDF_Height * i) + (top_left_margin * 4), canvas_image_width, canvas_image_height);
        }

        pdf.save("FARMERLANDIMAGESREPORT.pdf");
    });
};

//$(document).ready(function () {
  

//    var type= getParameterByName("type");
//    var itda = getParameterByName("itda");
//    var Dist = getParameterByName("Dist");
//    var Mandal = getParameterByName("Mandal");
//    var Village = getParameterByName("Village");
//    var user = getParameterByName("user");
//    var userpre = getParameterByName("userpre");
//    $("#itdalabel").text(itda);
//    $("#distlabel").text(Dist);
//    $("#mandallabel").text(Mandal);
//    $("#villagelabel").text(Village);

//    $.ajax(
//  {
//      type: 'POST',
//      contentType: 'application/json; charset=utf-8',
//      url: '../Giribhumi/pdfimagedataconversion',
//      data: "{'type':'" + type + "','itda':'" + itda + "', 'Dist':'" + Dist + "', 'Mandal':'" + Mandal + "', 'Village':'" + Village + "', 'user':'" + user + "','userpre':'" + userpre + "'}",
//      dataType: "json",
//      success: function (response) {
//          console.log(JSON.stringify(response));
//          var dist = response;
//          for (var i = 0; i < dist.itdalist.length; i++) {
//              var d = i+1;
               
//              var f='<img src='+"Land Images/Image1/04-10-2020_150504452_218884_150504452_218884_1.jpg"+ ' alt="" style="width:50px; height:50px;">';
//              var tblRow = '<tr><td>' + d + '</td><td style="color:#003399;">' + dist.itdalist[i].ID + '</td><td style="color:#003399;">' + dist.itdalist[i].benficiary_id2 + '</td><td style="color:#003399;">' + dist.itdalist[i].ROFR_PATTADAAR + '</td><td>' + dist.itdalist[i].Father_Name + '</td><td>' + dist.itdalist[i].Compartment_No + '</td><td>' + dist.itdalist[i].ROFR_PATTANO + '</td><td>' + dist.itdalist[i].Plot_No + '</td><td>' + dist.itdalist[i].ExtentPlotArea + '</td><td>' + dist.itdalist[i].Aadhaar_NO + '</td><td><img src=' + dist.itdalist[i].limg1 + ' alt="" style="width:50px; height:50px;"></td><td><img src=' + dist.itdalist[i].limg2 + ' alt="" style="width:50px; height:50px;"></td></tr>';
//              $("#tblCustomers").append(tblRow);

//          }


//      },
//      error: function (result) {
//          alert("Error");
//      }

//  });
//});