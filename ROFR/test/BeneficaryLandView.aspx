<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BeneficaryLandView.aspx.cs" Inherits="ROFR.test.BeneficaryLandView" %>

<!DOCTYPE html>

<html>
<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="user-scalable=no, width=device-width, initial-scale=1, maximum-scale=1">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <title>Beneficiary Extent Land Map</title>
    <style>
        #map {
            height: 100%;
        }
.map-container {
    width:  100%;
    height: 480px;
    margin: .4rem;;
}

        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }
    </style>
    <script type="text/javascript">
function SetUserName()
{
    var hidField = document.getElementById("mapland").value;
    alert(hidField);

}
    </script>

     <script type="text/javascript">

            function PrintDiv() {
                var divToPrint = document.getElementById('printarea');
                var popupWin = window.open('', '_blank', 'width=600px,height=600px,location=no,left=100px');
                popupWin.document.open();
                popupWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</html>');
                popupWin.document.close();
            }

            function PrintElem() {
                var mywindow = window.open('', 'PRINT', 'height=400,width=600');

                mywindow.document.write('<html><head><title>' + document.title + '</title>');
                mywindow.document.write('</head><body >');
                mywindow.document.write('<h1>' + document.title + '</h1>');
                mywindow.document.write(document.getElementById('printarea').innerHTML);
                mywindow.document.write('</body></html>');

                mywindow.document.close(); // necessary for IE >= 10
                mywindow.focus(); // necessary for IE >= 10*/

                mywindow.print();
                mywindow.close();

                return true;
            }

            function printAnyMaps() {
                const $body = $('body');
                const $mapContainer = $('.map-container');
                const $mapContainerParent = $mapContainer.parent();
                const $printContainer = $('<div style="position:relative;">');

                $printContainer
                  .height($mapContainer.height())
                  .append($mapContainer)
                  .prependTo($body);

                const $content = $body
                  .children()
                  .not($printContainer)
                  .not('script')
                  .detach();

                /**
                 * Needed for those who use Bootstrap 3.x, because some of
                 * its `@media print` styles ain't play nicely when printing.
                 */
                const $patchedStyle = $('<style media="print">')
                  .text(`
      img { max-width: none !important; }
      a[href]:after { content: ""; }
    `)
                  .appendTo('head');

                window.print();

                $body.prepend($content);
                $mapContainerParent.prepend($mapContainer);

                $printContainer.remove();
                $patchedStyle.remove();
            }

         </script>

</head>
<body onload="initMap();">
    <div class="col-md-12 text-right">
     <input id="btnprint" type="button" onclick="printAnyMaps()" value="Print"  />
        </div>
              <div class="map-container">
    <h2>Beneficiary Extent Land Map</h2>
    <input runat="server" type="hidden" id="mapland">
    <table>
        <tr>
            <td style="width:800px">
                <div id="map" style="height: 600px; width: auto;"></div>
            </td>
            <td></td>
                         <td style="width:200px">
                <h3>Beneficiary Details</h3>
                <div id="info1" style="position:absolute; color:black; font-family: Verdana; font-size: 14px;">
Beneficiary Extent Land Map
                </div>
            </td>
            <td style="width:300px">
                <h3>Coordinates X Y</h3>
                <div id="info" style="position:absolute; color:red; font-family: Verdana; font-size: 14px;"></div>
            </td>
             <td>
               <div id="dvMapImage">
                   <img id="imgMap" alt="" style = "display:none"/>
               </div>
           </td>
        </tr>

    </table>
</div>
    <script src="https://maps.googleapis.com/maps/api/js?v=2.0&key=AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0">
    </script>
    <script type="text/javascript" src="../MapJsfloder/map.js"></script>
</body>

</html>

