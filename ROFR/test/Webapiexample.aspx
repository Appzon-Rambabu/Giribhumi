<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Webapiexample.aspx.cs" Inherits="ROFR.test.Webapiexample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #38a1d2;}

.headertable .aftr th{position: sticky;top: 49x;}

     
    </style>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <link href="https://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet" />
     <script>
      $(document).ready(function () {
     
          
         $.ajax({
             url: "../getitdalanddetails",
                          data: "",
                          dataType: "json",
                          type: "GET",
                          contentType: "application/json; chartset=utf-8",
                          success: function (data) {

                              console.log(JSON.stringify(data));



                              var trHTML = '';

                              $.each(data, function (i, item) {

                                  alert(data[0].sno);
                                  trHTML += '<tr><td>' + data[i].sno + '</td><td>' + data[i].itda_name + '</td><td>' + data[i].Total_Compartments + '</td></tr>';
                              });

                              $('#mytable1').append(trHTML);


                              for (var i = 0; i < data.length; i++) {
                                  var opt = '';
                                  var opt1 = data[i].itda_name;

                                  //appenddata1 += "<option value = " + data[i].SHORT + " </option>";

                                  opt += "<option>" + data[i].itda_name + "</option>";
                                  $("#DropDownList1").append(opt);
                              }

                              $("#GridView1").append(trHTML);

                     
                              //alert(data[0].sno);
                       
                              //alert(data[0].sno);
                              //for (var i = 0; i < data.length; i++) {
                              //    // alert(data[i].itda_name);
                              //    $('#GridView1').append("<tr><td>" + data[i].sno + "</td><td>" + data[i].itda_name + "</td><td>" + data[i].Total_Compartments + "</td></tr>");

                              //};


                          
                              //var row = $("[id*=GridView1] tr:last-child").clone(true);
                              //$("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();
                           
                              //for (var i = 0; i < data.length; i++) {
                              //    for (var j = 0; j < data[i].length; j++) {
                              //        $("td", row[i][i]).eq(j).html(data[i][j]);
                              //    }
                              //    $("[id*=GridView1]").append(row);
                              //    row = $("[id*=GridView1] tr:last-child").clone(true);

                              //}
                              alert("success data");
                          },
                          error: function () {
                              alert("Error loading data! Please try again.");
                          }
                      })


      })

                </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <div class="panel panel-body" style="margin-top:150px;"> 
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"></asp:GridView>
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
     <div class="table-responsive">

       <div class="headertable">

          <table id="mytable1" border='1'  >
    <tr>
        <th>District</th>
         <th>Mandal</th>
         <th>Grampanchayat</th>
        
    </tr>
</table>
          </div>
         </div>
       </div>

</asp:Content>
