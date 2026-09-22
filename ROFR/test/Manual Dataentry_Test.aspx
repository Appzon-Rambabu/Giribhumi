<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manual Dataentry_Test.aspx.cs" Inherits="ROFR.test.Manual_Dataentry_Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>:: MANUAL DATA ENTRY FORM ::</title>
    <meta http-equiv="Content-type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../css/styles.css" type="text/css" media="all" />

    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>

    <script src="../js/ConstentHdrGridScrollV3.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/jquery-fns.js"></script>

    <link href="../css/grid.css" rel="stylesheet" type="text/css" />

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js"></script>

    <script type="text/javascript">
        function PrintPanel() {
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<p>GVMC, GARBAGE DETAILS<br />------------------------------</p>');
            printWindow.document.write('<table><thead><tr><td>Trip No</td><td>Details</td></tr></thead><tbody>');
            printWindow.document.write('<tr><td>Vehicle No</td><td>' + $("#mvehicleno_txt").val() + '</td></tr>');
            printWindow.document.write('<tr><td>Zone</td><td>' + $("#mzone_txt").val() + '</td></tr>');
            printWindow.document.write('<tr><td>Ward</td><td>' + $("#mward_txt").val() + '</td></tr>');
            printWindow.document.write('<tr><td>Owned by</td><td>' + $("#mowner_txt").val() + '</td></tr>');
            printWindow.document.write('<tr><td>Veh.Type</td><td>' + $("#mvehicletype_txt").val() + '</td></tr>');
            printWindow.document.write('<tr><td>Driver</td><td>' + $("#mdrivername_txt").val() + '</td></tr>');
            printWindow.document.write('<tr><td>In Weight</td><td>' + $("#mvehiclewt_txt").val() + '</td></tr>');
            printWindow.document.write('<tr><td>Out Weight</td><td>' + $("#mgrosswt_txt").val() + '</td></tr>');
            printWindow.document.write('<tr><td>Net Weight</td><td>' + $("#mnetwt_txt").val() + '</td></tr></tbody></table>');
            printWindow.document.write('<p>----------------------------------------------------------------</p><p><strong>Incharge Sign</strong></p>');
            printWindow.document.write('<p><strong>TS Incharge Sign</strong></p>');
            printWindow.document.write('<p><strong>DYard Incharge Sign</strong></p>');
            printWindow.document.close();
            setTimeout(function() {
            printWindow.print();
            
                document.getElementById('tag_txt').value = "";
                document.getElementById('getvhe_txt').value = "";
                document.getElementById('mvehicleno_txt').value = "";
                document.getElementById('mvehicletype_txt').value = "";
                document.getElementById('mzone_txt').value = "";
                document.getElementById('mward_txt').value = "";
                document.getElementById('mmaterial_txt').value = "";
                document.getElementById('mdrivername_txt').value = "";
                document.getElementById('mowner_txt').value = "";
                document.getElementById('mgrosswt_txt').value = "";
                document.getElementById('mvehiclewt_txt').value = "";
                document.getElementById('mnetwt_txt').value = "";
                document.getElementById('mshift_ddl').value = "Select";
                document.getElementById('mbin_txt').value = "";
                document.getElementById('blocation_txt').value = "";
                document.getElementById('tripnor_lbl').value = "";
                document.getElementById('dtripval_lbl').value = "";
                document.getElementById('message_lbl').innerHTML = "";
                document.getElementById('binzone_ddl').value = "Select";
                document.getElementById('ddltrip').value = "Select";
            }, 500);
            return false;
        }
    </script>

    <style type="text/css">
        .pop_box2
        {
            height: 195px;
            width: 950px;
            background-color: #E5E5E5;
            border-radius: 8px;
            -moz-border-radius: 8px;
            -webkit-border-radius: 8px;
            -khtml-border-radius: 8px;
            border: 1px solid rgba(0, 0, 0, 0.1); /*box-shadow:-5px -5px 10px;*/
        }
    </style>
</head>
<body onload="OnBodyLoad()">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManger1" runat="server">
    </asp:ScriptManager>
    <input type="hidden" id="hidfrmCalender" runat="server" /><input type="hidden" id="hidtoCalender"
        runat="server" />
    <!-- START PAGE SOURCE -->
    <table style="width: 100%;" cellpadding="0" cellspacing="0">
        <!--header start-->
        <tr style="background-image: url(../images/bg_header.jpg);">
            <td width="20%" height="95" align="left" valign="middle" style="padding-left: 10px">
                <img src="../images/logo.jpg">
            </td>
            <td width="70%" align="center" valign="middle">
                <img src="../images/title.jpg">
            </td>
            <td colspan="2" width="10%" align="right" valign="middle">
                <img src="../images/logo2.jpg">
            </td>
        </tr>
        <!--header end-->
        <!--links bar start-->
        <tr style="background-image: url(../images/bg-link.jpg)">
            <td align="center" colspan="3" height="38" style="font-weight: bold;">
                <center>
                    <asp:Label ID="Heading_lbl" runat="server" ForeColor="White" Text="TRIPS AND WEIGHT DETAILS MANUAL DATA ENTRY FORM"></asp:Label>
                </center>
            </td>
            <td height="38" colspan="3" valign="top" width="100%" align="right">
                <a id="imgHome" href="MIS_Dataentry.aspx" title="Home">
                    <img src="../images/scilab-logo.png" width="30" height="30" title="Home" alt="Home" /></a>
            </td>
        </tr>
        <tr>
            <td align="center" height="450" colspan="4">
                </br>
                <table width="80%" border="0" cellpadding="0" cellspacing="0" align="center" class="pop_box2">
                    <tr>
                        <td colspan="5" height="350" valign="top">
                            <%--<asp:Panel ID="Panel2" runat="server" GroupingText="Institution  Details" CssClass="form_text" BackColor="#B8FF7E">--%>
                            <fieldset class="entry_form_text" style="height:350px"; id="Fieldset1">
                                <table width="100%" border="0" cellpadding="4" cellspacing="0">
                                    <tr>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Barcode No
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span cssclass="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:TextBox ID="tag_txt" runat="server" AutoPostBack="True" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Vehicle Search
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span cssclass="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:TextBox ID="getvhe_txt" runat="server" AutoPostBack="True" OnTextChanged="getvhe_txt_TextChanged" ></asp:TextBox>
                                        </td>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Vehicle Number
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span class="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:TextBox ID="mvehicleno_txt" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Vehicle Type
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span cssclass="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:TextBox ID="mvehicletype_txt" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Zone
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span cssclass="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:TextBox ID="mzone_txt" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Ward
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span cssclass="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:TextBox ID="mward_txt" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Material
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span class="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:DropDownList runat="server" ID="ddlgrabagematerial" CssClass="form" 
                                                Style="width: 130px;" AutoPostBack="True">
                                                <asp:ListItem Value='-1' Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="M-1" Text="Wet"></asp:ListItem>
                                                <asp:ListItem Value="M-2" Text="Dry"> </asp:ListItem>
                                                 <asp:ListItem Value="M-3" Text="Mix"></asp:ListItem>
                                                <asp:ListItem Value="M-4" Text="Inert"> </asp:ListItem>
                                                 <asp:ListItem Value="M-5" Text="Silt"> </asp:ListItem>
                                             
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Driver Name
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span cssclass="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:TextBox ID="mdrivername_txt" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Owner
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span class="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:TextBox ID="mowner_txt" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Gross Weight
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span class="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:TextBox ID="mgrosswt_txt" runat="server" Enabled="False" 
                                                AutoPostBack="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Empty Weight
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span class="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:TextBox ID="mvehiclewt_txt" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Net Weight
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span class="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:TextBox ID="mnetwt_txt" runat="server"  OnTextChanged="mgrosswt_txt_TextChanged" AutoPostBack="True"></asp:TextBox>
                                        </td>
                                        <td height="29" valign="middle" style="font-weight: bold;" class="entry_form_text">
                                            Shift
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span class="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:DropDownList runat="server" ID="mshift_ddl" CssClass="form" Style="width: 130px;">
                                                <asp:ListItem Value='-1' Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Day"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Night"> </asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                <tr>
                                        <td valign="middle" cssclass="entry_form_text" style="font-weight: bold;" style="height: 29px">
                                            Yard
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span class="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:DropDownList runat="server" ID="binzone_ddl" CssClass="form" 
                                                Style="width: 130px;" AutoPostBack="True">
                                                <asp:ListItem Value='-1' Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="Y-1" Text="MSF 1"></asp:ListItem>
                                                <asp:ListItem Value="Y-2" Text="MSF 2"> </asp:ListItem>
                                                <asp:ListItem Value="Y-3" Text="MSF 3"> </asp:ListItem>
                                                <asp:ListItem Value="Y-4" Text="MSF-KRM"> </asp:ListItem>
                                                <asp:ListItem Value="Y-5" Text="MSF 5"> </asp:ListItem>
                                                <asp:ListItem Value="Y-6" Text="MSF 6"> </asp:ListItem>
                                                 <asp:ListItem Value="Y-7" Text="Kapuluppada"> </asp:ListItem>
                                                 <asp:ListItem Value="Y-8" Text="MSF-AKP"> </asp:ListItem>
                                                <asp:ListItem Value="Y-9" Text="MSF-BML"> </asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    <td valign="middle" cssclass="entry_form_text" style="font-weight: bold;" style="height: 29px">
                                           Trip Type
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span class="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" class="entry_form_text">
                                            <asp:DropDownList runat="server" ID="ddltrip" CssClass="form" 
                                                Style="width: 130px;" AutoPostBack="True">
                                                <asp:ListItem Value='-1' Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="Y-1" Text="IN"></asp:ListItem>
                                                <asp:ListItem Value="Y-2" Text="OUT"> </asp:ListItem>
                                             
                                            </asp:DropDownList>
                                        </td>
                                 
                                    </tr>
                                    <tr>
                                        <td height="29" valign="middle" style="font-weight: bold;" cssclass="entry_form_text">
                                            Trip No
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span cssclass="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" cssclass="entry_form_text">
                                            <asp:Label ID="tripnor_lbl" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td height="29" valign="middle" style="font-weight: bold;" cssclass="entry_form_text">
                                            Daily Trip No
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span class="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" cssclass="entry_form_text">
                                            <asp:Label ID="dtripval_lbl" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td height="29" valign="middle" style="font-weight: bold;" cssclass="entry_form_text">
                                            Remarks
                                        </td>
                                        <td valign="middle" style="font-weight: bold;">
                                            <span cssclass="entry_form_text">:</span>
                                        </td>
                                        <td valign="middle" align="left" cssclass="entry_form_text">
                                            <asp:TextBox ID="remarks_txt" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="9">
                                            <asp:Label ID="message_lbl" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    <tr align="center">
                                        <td valign="middle" cssclass="entry_form_text" style="height: 29px" colspan="6">
                                            <asp:Button ID="save_btn" runat="server" Text="SAVE" OnClick="save_btn_Click" />
                                            <%--<img src="../images/Submit.JPG" style="height: 30px; cursor: pointer;"/>--%>
                                        </td>
                                        <td valign="middle" align="left" style="height: 29px" colspan="5" class="entry_form_text">
                                            <asp:Button ID="btnPrint" runat="server" Text="PRINT" OnClientClick="return PrintPanel();" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                </div>
            </td>
        </tr>
        <tr>
            <td height="3" bgcolor="#1CA938" colspan="4">
            </td>
        </tr>
        <tr style="background-color: #275D75;color:white;" >
            <td height="33" colspan="4" align="center" valign="middle" style="height: 33px; text-align: center;
                vertical-align: middle;" >
                <span class="style2 footer" >DESIGNED & MAINTAINED BY VAIBHAV SOFTWARE SOLUTIONS.</span>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>