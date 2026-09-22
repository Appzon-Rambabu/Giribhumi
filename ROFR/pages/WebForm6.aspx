<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="ROFR.pages.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <%--  <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>--%>
    <!--<script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.3.3/jspdf.min.js"></script>-->
    <script src="../linksforcdns/Js/jspdf.js"></script>
    <!--<script src="https://html2canvas.hertzen.com/dist/html2canvas.js"></script>-->
    <script src="../linksforcdns/Js/html2canvas.js"></script>
    <script src="../MapJsfloder/pdfconverjs.js"></script>
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        table {
            border: 1px solid #ccc;
            border-collapse: collapse;
              text-align: center;
            
        }

            table th {
                background-color: #1F5C99;
                color: #FFFFFF;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                border: 1px solid #ccc;
            }

            div {
 
}
#orderName {
    vertical-align: middle;
}
#orderNo {
    float: left;
}
.center {
  margin-left: auto;
  margin-right: auto;
}

.box {
    width: 430px;
    margin: 10px 0;
    float:left;
}

.box1 {
   margin-left: 160px;
    text-align: right;
    display:inline-block;
    font-weight: bold;
}
.box2 {

    text-align: right;
    display:inline-block;
    font-weight: bold;
}

.box label {
   margin-left: 100px;
    text-align: right;
    display:inline-block;
    font-weight: bold;
}

.clear {
    clear:both;
}
    </style>
</head>
<body>
    <div class="canvas_div_pdf" >
       
            <div class="row" style="text-align: center;">
                <label for="html" style="font-weight: bold;   text-align: center;
  color: #28a745;">FARMER LAND IMAGES REPORT</label>
            </div>
     <br />
      
        <div class="box">
            <asp:label id="myLabel" CssClass="box1" Text="ITDA: " runat="server" /><asp:label id="Label1" CssClass="box2" runat="server" />
         <%--   <label>ITDA: </label><label id="itdalabel"></label>--%>
        </div>
        <div class="box">
            <asp:label id="Label2" CssClass="box1" Text="District: " runat="server" /><asp:label id="Label3" CssClass="box2" runat="server" />
            <%--  <label>District: </label><label id="distlabel"></label>--%>
        </div>
        <div class="box">
            <asp:label id="Label4" CssClass="box1" Text="Mandal: " runat="server" /><asp:label id="Label5" CssClass="box2" runat="server" />
            <%-- <label>Mandal: </label><label id="mandallabel"></label>--%>
        </div>
        <div class="box">
            <asp:label id="Label6" CssClass="box1" Text="Village: " runat="server" /><asp:label id="Label7" CssClass="box2" runat="server" />
            <%-- <label>Village: </label><label id="villagelabel"></label>--%>
        </div>
        <div class="box">
            <asp:label id="Label8" CssClass="box1" Text="Status: " runat="server" /><asp:label id="Label9" CssClass="box2" Text="LAND IMAGES UPLOADED  " runat="server" />
            <%-- <label>Status: </label><label>LAND IMAGES UPLOADED </label>--%>
        </div>
    
        <br />
       
            <div class="row">
                <br />
                <asp:Literal ID = "ltTable"  runat = "server"  />
              <%--  <table id="tblCustomers" cellspacing="0" cellpadding="0" class="center">
                    <tr>
                        <th>S.No</th>
                        <th>Id</th>
                        <th>Benficiary Id</th>
                        <th>Rofr Pattadaar</th>
                        <th>Father Name</th>
                        <th>Compartment No.</th>
                        <th>ROFR Pattano.</th>
                        <th>Plot No.</th>
                        <th>Extent Plot Area</th>
                        <th>Aadhaar No.</th>
                        <th>Land Image1</th>
                        <th>Land Image2</th>

                    </tr>

                    <!--<tr>
                    <td>1</td>
                    <td>John Hammond</td>
                    <td>United States</td>
                    <td>
                        <img src="Land Images/Image1/04-10-2020_150504452_218884_150504452_218884_1.jpg" alt="" style="width:50px; height:50px;">
                    </td>
                </tr>-->



                </table>--%>
            </div>
        </div>
    <br />
    <br />
    <div class="row" style="text-align: center;">
        <input type="button" id="btnExport" value="ExportPdf" onclick="Export()" />
    </div>
</body>
</html>
