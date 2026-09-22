<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="UploadMultipleLatlongs.aspx.cs" Inherits="ROFR.test.UploadMultipleLatlongs" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #007405;}

.headertable .aftr th{position: sticky;top: 49x;}

     
    </style>

    <script type="text/javascript">

            function PrintDiv() {
                var divToPrint = document.getElementById('printarea');
                var popupWin = window.open('', '_blank', 'width=300,height=400,location=no,left=200px');
                popupWin.document.open();
                popupWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</html>');
                popupWin.document.close();
            }
         </script>
      <script type="text/javascript">
        function deleteConfirm(pubid) {
            var result = confirm('Do you want to delete Latlong ?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }

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
    <style type="text/css">
        /*.panel-group .panel {
		border-radius: 0;
		box-shadow: none;
		border-color: #EEEEEE;
	}

	.panel-default > .panel-heading {
		width: auto;
	}

	.panel-title {
		font-size: 14px;
		background: orange;
    padding: 10px;
    z-index: 2;
    position: relative;
    left: 30px;
    top: 20px;
	color:#000;
	
		
	}
	
	.panel-title a:hover {color:#000;}
	.panel-title a:focus {color:#000;}

	.panel-title > a {
		
	}

	.more-less {
		margin-left:10px;
		color: #212121;
	}
	.clps-heading{
		background: orange;
    padding: 10px;
    z-index: 999;
    position: relative;
    left: 30px;
    top: 10px;
	}
	.clps-heading:hover {color:#000;}
	.clps-heading:focus {color:#000;}

	
	
	.panel-group .panel-body {
        display: block;
    margin-left: 10px;
    margin-right: 20px;
    padding-top: 2.35em;
    padding-bottom: 0.625em;
    padding-left: 0.75em;
    padding-right: 0.75em;
    border: 2px groove burlywood;
	
}
.panel-title > a:before {
    float: right !important;
    font-family: FontAwesome;
    content:"\f068";
	margin-left:10px;
}
.panel-title > a.collapsed:before {
    float: right !important;
    content:"\f067";
	margin-left:10px;
}
.panel-title > a:hover, 
.panel-title > a:active, 
.panel-title > a:focus  {
    text-decoration:none;
}*/
        .headertable tr td {
            border: 1px solid #eee !important;
        }


        .headertable {
            overflow-y: auto;
            height: auto;
            max-height: 300px;
        }

            .headertable table {
                border-collapse: collapse;
                width: 100%;
                border: 1px solid #000000 !important;
            }

            .headertable th, .headertable td {
                padding: 8px 16px;
            }

            .headertable th {
                position: sticky;
                top: -10px;
                background-color: #38a1d2;
            }

            .headertable .aftr th {
                position: sticky;
                top: 49x;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="content-area">
     <div class="panel panel-body" style="margin-top:2px;">

        <h5 class="text-center text-success"> UPDATE MULTIPLE LATLONGS </h5>
          <div class="row justify-content-center">
            <div class="col-md-1 text-right">
                <asp:Label ID="txt_Itda" runat="server" Text="Itda:"></asp:Label>&nbsp<asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddl_ITda" Style="width:150px" AutoPostBack="true" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
            </div> 
        </div>
    
         <div class="row justify-content-center mt-3" runat="server" id="uploadfile">
               <div class="col-md-6">
                   <div class="row  d-flex justify-content-center" id="Div2" runat="server">
                       <div class="col-md-2 text-center">
                           Select File
                       </div>

                       <div class="col-md-4 text-center">
                           <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Select Only Excel File" />
                       </div>

                       <div class="col-md-2 text-center">
                           <asp:Button ID="Button2" runat="server" Text="Upload" CssClass="btn btn-success" OnClick="Button1_Click" />
                       </div>
                        <div class="col-md-2 text-center">
                           <asp:Button ID="btnmap" runat="server" Text="ViewGISMap" CssClass="btn btn-success" OnClick="btnmap_Click" />
                       </div>
                   </div>
               </div>
           </div>
    </div>
          </div>
</asp:Content>
