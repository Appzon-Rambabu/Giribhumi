<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgricultureHorticulture.aspx.cs" Inherits="ROFR.NewPages.AgricultureHorticulture" MasterPageFile="~/Masters/ROFR_MASTER.Master"  EnableEventValidation="false" %>



<asp:Content ID="Content1"  ContentPlaceHolderID="head" runat="server">    
<title>Agriculture & Horticulture Crop Details</title>    
    <%--<link href="../Newcdn/NewCss/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="../Newcdn/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Newcdn/buttons.dataTables.min.css" rel="stylesheet" />
      <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
    <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <%--<script src="../Newcdn/vfs_fonts.js"></script>--%>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    <script src="../Newcdn/xlsx.full.min.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
  <script src="../NewJsFiles/AgricultureHorticulture.js"></script>
    
    <style>
* {
    box-sizing: border-box;
}

body {
    margin: 0;
    padding: 0;
    background: #f5f5f5;
    font-family: 'Poppins', sans-serif;
}

.pageContainer {
    width: 98%;
    margin: 12px auto;
}

.reportCard {
    background: #fff;
    border: 1px solid #dcdcdc;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, .12);
    overflow: hidden;
}

.subheader {
    color: #000;
    text-align: center;
    font-size: 20px;
    font-weight: 700;
    line-height: 1.2;
    margin: 13px 0 -32px;
}

.tableDiv {
    width: 95%;
    overflow: auto;
    background: #fff;
}

.reportTable {
    width: 100%;
    min-width: 4500px;
    border-collapse: collapse;
    border-spacing: 0;
    margin: 0;
    padding: 0;
    background: #fff;
}

.reportTable th {
    padding: 10px 10px;
    font-size: 15px;
    font-weight: 700;
    line-height: 1.25;
    text-align: center !important;
    vertical-align: middle !important;
    border: 1px solid rgba(0, 0, 0, .18);
    white-space: normal;
}

.reportTable td {
    padding: 9px 12px;
    font-size: 15px;
    line-height: 1.25;
    text-align: center;
    vertical-align: middle;
    border: 1px solid #d9e1ea;
    background: #fff;
    white-space: nowrap;
}

.reportTable td:nth-child(2) {
    text-align: left;
    min-width: 230px;
}

.reportTable tbody tr:nth-child(even) td {
    background: #f7f9fb;
}

.reportTable tbody tr:hover td {
    background: #eef7ff;
}

/* Header colors */
.reportTable thead tr:nth-child(1) th {
    background: #2E7D32 !important;
    color: #fff !important;
}

.reportTable thead .mainGroup {
    background: #78AEDC !important;
    color: #fff !important;
}

.reportTable thead .Cereals {
    background: #6FA8FF !important;
    color: #fff !important;
}

.reportTable thead .Millets {
    background: #BFC7A7 !important;
    color: #fff !important;
}

.reportTable thead .Pulses {
    background: #F39C4A !important;
    color: #fff !important;
}

.reportTable thead .Fruits {
    background: #A5D6A7 !important;
    color: #fff !important;
}

.reportTable thead .Commercial {
    background: #F4C7A1 !important;
    color: #fff !important;
}

.reportTable thead .Vegetables {
    background: #AED581 !important;
    color: #fff !important;
}

.reportTable thead tr:last-child th {
    background: #FFF59D !important;
    color: #000 !important;
    padding: 2px 10px;
}

.mainGroup {
    font-size: 15px;
    font-weight: 700;
}

.group {
    font-size: 14px;
    font-weight: 700;
}

.headder-cell {
    line-height: 1.25;
}

/* Datatable toolbar */
.dt-toolbar {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 6px 14px;
    flex-wrap: wrap;
    gap: 10px;
}

/* Buttons */
.dt-buttons {
    display: flex;
    gap: 10px;
    margin: 6px 0;
    align-items: center;
    flex-wrap: wrap;
    margin-left:10px;
}

.dt-button,
.dt-buttons .dt-button {
    display: inline-flex !important;
    align-items: center !important;
    justify-content: center !important;
    height: 34px !important;
    min-width: 65px;
    padding: 9px 18px !important;
    border-radius: 10px !important;
    font-size: 14px !important;
    font-weight: 500 !important;
    line-height: 1 !important;
    text-align: center;
    background: #fff !important;
    color: #0d5a1f !important;
    border: 1px solid #d0d0d0 !important;
    box-shadow: 0 2px 6px rgba(0, 0, 0, .08);

}

.dt-button:hover,
.dt-buttons .dt-button:hover {
    background: #2E7D32 !important;
    color: #fff !important;
}

/* Search */
.dataTables_filter {
    margin: 0 14px 8px 0;
}

.dataTables_filter label {
    font-size: 18px;
    font-weight: 700;
    display: flex;
    align-items: center;
    gap: 10px;
}

.dataTables_filter input {
    width: 320px !important;
    height: 36px;
    border: 1px solid #b8b8b8;
    border-radius: 3px;
    padding: 6px 10px;
    font-size: 15px;
}

/* Info and pagination */
.dataTables_info,
.dataTables_paginate {
    padding: 10px;
}

/* Scroll */
.dataTables_wrapper .dataTables_scroll {
    border: none;
}

.dataTables_wrapper .dataTables_scrollHead {
    border: none;
    background: #fff;
}

.dataTables_wrapper .dataTables_scrollHeadInner {
    width: max-content !important;
}

.dataTables_wrapper .dataTables_scrollBody {
    border: none;
    max-height: 540px !important;
}

/* Responsive */
@media (max-width: 768px) {
    .dt-toolbar {
        flex-direction: column;
        align-items: stretch;
    }

    .dataTables_filter,
    .dataTables_filter label,
    .dataTables_filter input {
        width: 100% !important;
    }

    .subheader {
        font-size: 18px;
    }
}
/* TOTAL ROW - BOLD */
#dt_Cultivation_tbl tbody tr:last-child td {
    font-weight: 700 !important;
}
</style>

</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

            <div class="row justify-content-center">
                <div class="tableDiv">
                        <div class="subheader">
                    Agriculture & Horticulture Crop Details
                </div>
                    <table id="dt_Cultivation_tbl" class="reportTable">


                        <thead>
    <tr>
        <th rowspan="3">S.No</th>

        <th rowspan="3" class="headder-cell">
            District<br />
            (Recontinued Disrict)
        </th>

        <th rowspan="3" class="headder-cell">
            Extent of IFR<br />
            Land Under<br />
            Cultivation
        </th>

        <th colspan="13" class="mainGroup">Agriculture Crop Details</th>

        <th colspan="13" class="mainGroup">Horticulture Crop Details</th>

        <th colspan="18" class="mainGroup">Commercial Crops Details</th>

        <th rowspan="3">Others</th>

        <th rowspan="3" class="headder-cell">
            Total Land<br />
            Under Cultivation<br />
            in Acrs
        </th>

        <th rowspan="3" class="headder-cell">
            Un Cultivable<br />
            Land in Acres
        </th>
    </tr>

    <tr>
        <th colspan="3" class="group Cereals">Cereals</th>
        <th colspan="5" class="group Millets">Millets</th>
        <th colspan="5" class="group Pulses">Pulses</th>

        <th colspan="10" class="group Fruits">Fruits</th>
        <th colspan="3" class="group Vegetables">Vegetables</th>

        <th colspan="18" class="group Commercial">Commercial Crops</th>
    </tr>

    <tr>
        <!-- Cereals -->
        <th class="group Cereals">Paddy</th>
        <th class="group Cereals">Wheat</th>
        <th class="group Cereals">Maize</th>

        <!-- Millets -->
        <th class="group Millets">Millets</th>
        <th class="group Millets">Korralu</th>
        <th class="group Millets headder-cell">Ragi<br />(Finger Millet)</th>
        <th class="group Millets headder-cell">Bajra<br />(Peral Millet)</th>
        <th class="group Millets headder-cell">Jowar<br />(Sorghum)</th>

        <!-- Pulses -->
        <th class="group Pulses headder-cell">Minumulu<br />(Black Gram)</th>
        <th class="group Pulses headder-cell">Pesalu<br />(Green Gram)</th>
        <th class="group Pulses headder-cell">Kandulu<br />(Red Gram)</th>
        <th class="group Pulses headder-cell">Senagalu<br />(Bengal Gram)</th>
        <th class="group Pulses headder-cell">Rajma<br />(Kidney Beans)</th>

        <!-- Fruits -->
        <th class="group Fruits">Pine Apple</th>
        <th class="group Fruits">Mango</th>
        <th class="group Fruits">Banana</th>
        <th class="group Fruits">Guava</th>
        <th class="group Fruits">Straw Berry</th>
        <th class="group Fruits">Sapota</th>
        <th class="group Fruits">Sweet Orange</th>
        <th class="group Fruits">Custard Apple</th>
        <th class="group Fruits">Citrus</th>
        <th class="group Fruits">Jafra</th>

        <!-- Vegetables -->
        <th class="group Vegetables headder-cell">Leafy<br />Vegetables</th>
        <th class="group Vegetables">Tomato</th>
        <th class="group Vegetables">Beans</th>

        <!-- Commercial -->
        <th class="group Commercial">Cashew</th>
        <th class="group Commercial">Coffee</th>
        <th class="group Commercial">Turmeric</th>
        <th class="group Commercial">Tobacco</th>
        <th class="group Commercial">Sugar Cane</th>
        <th class="group Commercial">Ground Nut</th>
        <th class="group Commercial">Cotton</th>
        <th class="group Commercial">Ginger</th>
        <th class="group Commercial">Sweet Corn</th>
        <th class="group Commercial">Brooms</th>
        <th class="group Commercial">Bamboo</th>
        <th class="group Commercial">Coconut</th>
        <th class="group Commercial">Rubber</th>
        <th class="group Commercial">Palm Oil</th>
        <th class="group Commercial">COCO</th>
        <th class="group Commercial">Teak</th>
        <th class="group Commercial headder-cell">Chilli/<br />Red Chilli</th>
        <th class="group Commercial">Sesame Seeds</th>
    </tr>

    <tr>
        <th>1</th>
        <th>2</th>
        <th>3</th>
        <th>4</th>
        <th>5</th>
        <th>6</th>
        <th>7</th>
        <th>8</th>
        <th>9</th>
        <th>10</th>
        <th>11</th>
        <th>12</th>
        <th>13</th>
        <th>14</th>
        <th>15</th>
        <th>16</th>
        <th>17</th>
        <th>18</th>
        <th>19</th>
        <th>20</th>
        <th>21</th>
        <th>22</th>
        <th>23</th>
        <th>24</th>
        <th>25</th>
        <th>26</th>
        <th>27</th>
        <th>28</th>
        <th>29</th>
        <th>30</th>
        <th>31</th>
        <th>32</th>
        <th>33</th>
        <th>34</th>
        <th>35</th>
        <th>36</th>
        <th>37</th>
        <th>38</th>
        <th>39</th>
        <th>40</th>
        <th>41</th>
        <th>42</th>
        <th>43</th>
        <th>44</th>
        <th>45</th>
        <th>46</th>
        <th>47</th>
        <th>48</th>
        <th>49</th>
        <th>50</th>
    </tr>
</thead>
                        <tbody></tbody>

                    </table>
                </div>
            </div>
        
</asp:Content>
