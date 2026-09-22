<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="BeneficaryExtentLandView.aspx.cs" Inherits="ROFR.pages.BeneficaryExtentLandView" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Newcdn/jquery-3.5.1.js"></script>
     <script type="text/javascript">
        function noBack()
         {
             window.history.forward()
         }
        noBack();
        window.onload = noBack;
        window.onpageshow = function(evt) { if (evt.persisted) noBack() }
        window.onunload = function() { void (0) }
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
        function Validate() {
            var district = document.getElementById('<%=ddl_district.ClientID %>').value;
            var mandal = document.getElementById('<%=ddl_mandal.ClientID %>').value;
            var Village = document.getElementById('<%=ddl_Village.ClientID %>').value;
            <%--  var habitation = document.getElementById('<%=ddl_Hab.ClientID %>').value;
           var range = document.getElementById('<%=ddl_FR.ClientID %>').value;--%>

            if (district == "0") {

                alert("Please select District!");
                return false;
            }
            if (mandal == "0") {

                alert("Please select Mandal!");
                return false;
            }

            if (Village == "0") {

                alert("Please select Village!");
                return false;
            }

            if (habitation == "0") {

                alert("Please select Forest Habitation!");
                return false;
            }
            //if (range == "0") {

            //    alert("Please select Forest Range!");
            //    return false;
            //}

        }
    </script>
    <style type="text/css">
      
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
                top: 49px;
            }
            /* GIS FILTERS */

.filter-item {
    display: flex;
    align-items: center;
    width: 100%;
    margin-bottom: 5px;
}

.filter-item label {
    width: 58px;
    min-width: 58px;
    margin: 0;
    font-size: 11px;
    font-weight: normal;
    white-space: nowrap;
}

.gis-select {
    flex: 1;
    width: auto !important;
    height: 28px !important;
    min-height: 28px !important;
    padding: 2px 5px !important;
    font-size: 11px !important;
}

.filter-button {
    margin-left: 58px;
    margin-top: 2px;
}
.btn-gis {
    width: 100%;
    height: 28px;
    padding: 3px 5px !important;
    font-size: 11px !important;
}


/* =========================================
   GOVERNMENT STYLE GIS FILTERS
   ========================================= */

.filter-panel {
    padding-left: 0 !important;
    padding-right: 8px !important;
    font-family: 'Ramabhadra', sans-serif;
}

.filter-item {
    display: flex;
    align-items: center;
    width: 100%;
    margin-bottom: 7px;
    min-width: 0;
}

/* Label */
.filter-item label {
    width: 75px;
    min-width: 75px;
    margin: 0;
    padding: 0;
    color: #333;
    font-family: 'Ramabhadra', sans-serif;
    font-size: 12px;
    font-weight: 600;
    white-space: nowrap;
}

/* Government-style dropdown */
.gis-select {
    width: calc(100% - 75px) !important;
    max-width: calc(100% - 75px) !important;
    min-width: 0 !important;

    height: 30px !important;
    min-height: 30px !important;

    padding: 3px 7px !important;

    background-color: #ffffff !important;
    color: #333333 !important;

    border: 1px solid #aeb5bb !important;
    border-radius: 3px !important;

    font-family: 'Ramabhadra', sans-serif;
    font-size: 12px !important;
    font-weight: 400;

    box-shadow: none !important;

    overflow: hidden;
}
/* Dropdown hover */
.gis-select:hover {
    border-color: #7f8a91 !important;
}

/* Dropdown focus */
.gis-select:focus {
    border-color: #198754 !important;
    outline: none !important;
    box-shadow: 0 0 0 1px rgba(25, 135, 84, 0.15) !important;
}


/* =========================================
   VIEW GIS MAP BUTTON
   ========================================= */

.filter-button {
    margin-left: 75px;
    margin-top: 2px;
}

.btn-gis {
    width: 60%;

    height: 30px;

    padding: 4px 7px !important;

    background-color: #128751 !important;
    border: 1px solid #157347 !important;
    border-radius: 3px !important;

    color: #ffffff !important;

    font-family: 'Ramabhadra', sans-serif;
    font-size: 12px !important;
    font-weight: 600;

    box-shadow: none !important;
}

.btn-gis:hover {
    background-color: #157347 !important;
    border-color: #146c43 !important;
}


/* =========================================
   MAP
   ========================================= */
.map-panel {
    padding-left: 5px !important;
    padding-right: 0 !important;
    height: calc(100vh - 200px);
    overflow: hidden !important;
}

.gis-map-frame {
    display: block;
    width: 100%;
    height: 100% !important;

    border: 1px solid #bfc5ca;
    border-radius: 2px;

    margin: 0;
    padding: 0;

    background-color: #ffffff;

    overflow: hidden !important;
    border: none;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <div class="panel panel-body">

         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
									 
<asp:UpdateProgress
    ID="UpdateProgress1"
    runat="server"
    AssociatedUpdatePanelID="UpdatePanel1"
    DisplayAfter="0">

    <ProgressTemplate>
        <div class="preloader" style="background: rgba(255,255,255,0.5);">
            <div class="spinner"></div>
            <span id="loading-msg">
                <img src="../Rofrnewassets/images/aplogo.png" />
            </span>
        </div>
    </ProgressTemplate>

</asp:UpdateProgress>
              

        <%--<h5 class="text-center text-success"> BENEFICARY EXTENT LAND VIEW ON GIS LAYER</h5>
          --%>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        
           
            <div class="row">

    

<!-- LEFT SIDE -->
<div class="col-md-2 filter-panel">
    <div class="text-center text-success">
        <label>LAND VIEW ON GIS LAYER</label>

    </div>


    <div class="filter-item">
        <label>ITDA</label>
        <asp:DropDownList ID="ddl_ITda" runat="server"
            CssClass="gis-select"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" />
    </div>

    <div class="filter-item">
        

    </div>
    

    <div class="filter-item">
        <label>District</label>
        <asp:DropDownList ID="ddl_district" runat="server"
            CssClass="gis-select"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged" />
    </div>

    <div class="filter-item">
        

    </div>

    <div class="filter-item">
        <label>Mandal</label>
        <asp:DropDownList ID="ddl_mandal" runat="server"
            CssClass="gis-select"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" />
    </div>

    <div class="filter-item">
        

    </div>

    <div class="filter-item">
        <label>Village</label>
        <asp:DropDownList ID="ddl_Village" runat="server"
            CssClass="gis-select"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged" />
    </div>

    <div class="filter-item">
        

    </div>

    <div class="filter-item">
        <label>Habitation</label>
        <asp:DropDownList ID="ddl_hab" runat="server"
            CssClass="gis-select"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlhab_OnSelectedIndexChanged" />
    </div>

    <div class="filter-item">
        

    </div>

    <div class="filter-item">
        <label>Pattadhar</label>
        <asp:DropDownList ID="ddl_pattadhar" runat="server"
            CssClass="gis-select"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlpattadhar_OnSelectedIndexChanged" />
    </div>

    <div class="filter-item">
        

    </div>

    <div class="filter-item">
        <label>Extent</label>
        <asp:DropDownList ID="ddl_extentplotarea" runat="server"
            CssClass="gis-select"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlextentplotarea_OnSelectedIndexChanged" />
    </div>

    <div class="filter-item">
        

    </div>

    <div class="filter-button">
        <asp:Button ID="btnmap"
            runat="server"
            Text="View GIS Map"
            CssClass="btn btn-success btn-gis"
            OnClick="btnmap_Click" />
    </div>

</div>




    <!-- RIGHT SIDE -->
                <div class="col-md-10 map-panel">
        <iframe id="mapFrame"
    runat="server"
    src="about:blank"
    class="gis-map-frame">
</iframe>

    </div>

</div>
        
        
       
             </ContentTemplate>
    </asp:UpdatePanel>
    </div>
           
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_beginRequest(function (sender, args) {

            var postBackElement = args.get_postBackElement();

            if (!postBackElement) {
                return;
            }

            var id = postBackElement.id;

            // Show loader for these controls
            if (
                id.indexOf("ddl_ITda") !== -1 ||
                id.indexOf("ddl_district") !== -1 ||
                id.indexOf("ddl_mandal") !== -1 ||
                id.indexOf("ddl_Village") !== -1 ||
                id.indexOf("ddl_hab") !== -1 ||
                id.indexOf("ddl_pattadhar") !== -1 ||
                id.indexOf("btnmap") !== -1
            ) {
                $(".preloader").show();
            }

            // Extent should NOT show loader
            if (id.indexOf("ddl_extentplotarea") !== -1) {
                $(".preloader").hide();
            }
        });

        prm.add_endRequest(function (sender, args) {

            // Always hide loader after postback completes
            $(".preloader").hide();
        });
    </script>
</asp:Content>
