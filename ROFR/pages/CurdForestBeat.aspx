<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="CurdForestBeat.aspx.cs" Inherits="ROFR.pages.CurdForestBeat"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript" language="javascript">
     function DisableBackButton() {
       window.history.forward()
      }
     DisableBackButton();
     window.onload = DisableBackButton;
     window.onpageshow = function(evt) { if (evt.persisted) DisableBackButton() }
     window.onunload = function() { void (0) }
 </script>
    <script type="text/javascript">
        function deleteConfirm(pubid) {
            var result = confirm('Do you want to delete Forset Beat ?');
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
             var division = document.getElementById('<%=ddl_FD.ClientID %>').value;
            var range = document.getElementById('<%=ddl_FR.ClientID %>').value;

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

            if (division == "0") {

                alert("Please select Forest Division!");
                return false;
            }
            if (range == "0") {

                alert("Please select Forest Range!");
                return false;
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
                top: 49px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           <asp:UpdateProgress ID="UPDATED" runat="server">
                                    <ProgressTemplate>
                                        <div class="preloader" style="background: rgba(255,255,255,0.5);">
                                     <div class="spinner"></div>
                                   <span id="loading-msg">
                                 <img src="../Rofrnewassets/images/aplogo.png" />
                             </span>
                              </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
     <asp:UpdatePanel runat="server" ID="updatepanel1">
            <ContentTemplate>
     <div class="panel panel-body">
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">

                <div class="table-responsive">


                    <table class="table">
                        <thead>
                            <tr>
                                <h5 class="text-center text-success">UPDATE FOREST BEAT</h5>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>

                                <td>
                                    <asp:Label ID="txt_district" runat="server" Text="District:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_district" Style="width:150px" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label ID="txt_mandal" runat="server" Text="Mandal:"></asp:Label>&nbsp<asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddl_mandal" Style="width: 150px" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Village:"></asp:Label>&nbsp<asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddl_Village" Style="width: 150px" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Forest Division:"></asp:Label>&nbsp<asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddl_FD" Style="width: 150px" AutoPostBack="true" OnSelectedIndexChanged="ddlFD_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Forest Range:"></asp:Label>&nbsp<asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddl_FR" Style="width: 150px" AutoPostBack="true" OnSelectedIndexChanged="ddlFR_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" ShowFooter="true"
                                    CellPadding="4" DataKeyNames="Id"
                                   onrowcancelingedit="gridView_RowCancelingEdit"
        onrowdeleting="gridView_RowDeleting"
        onrowediting="gridView_RowEditing"
        onrowupdating="gridView_RowUpdating"
      onrowcommand="gridView_RowCommand"
        OnRowDataBound="gridView_RowDataBound">
                                    <Columns>

                                        <asp:TemplateField HeaderText="FOREST BEAT CODE" ItemStyle-Width="190">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_divisioncode" runat="server" Text='<%# Eval("FOREST_BEAT_CODE") %>'></asp:Label>

                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txt_divisioncode" runat="server" Text='<%# Eval("FOREST_BEAT_CODE") %>' onkeypress='codevalidate(event)' Width="180"></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="instorid" Width="120px" runat="server" onkeypress='codevalidate(event)' />
                                                <asp:RequiredFieldValidator ID="vstorid" runat="server" ControlToValidate="instorid" Text="?" ValidationGroup="validaiton" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FOREST BEAT NAME" ItemStyle-Width="250">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_division" runat="server" Text='<%# Eval("FOREST_BEAT_NAME") %>'></asp:Label>

                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txt_division" runat="server" Text='<%# Eval("FOREST_BEAT_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="inname" Width="120px" runat="server" onkeypress='mastervalidatenumerics(event)' />
                                                <asp:RequiredFieldValidator ID="vname" runat="server" ControlToValidate="inname" Text="?" ValidationGroup="validaiton" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="250">
                                            <EditItemTemplate>
                                                <asp:Button ID="ButtonUpdate" CssClass="btn btn-primary" runat="server" CommandName="Update" Text="Update" />
                                                <asp:Button ID="ButtonCancel" CssClass="btn btn-danger" runat="server" CommandName="Cancel" Text="Cancel" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="ButtonEdit" CssClass="btn btn-secondary" runat="server" CommandName="Edit" Text="Edit" />
                                                <asp:Button ID="ButtonDelete" CssClass="btn btn-danger" runat="server" CommandName="Delete" Text="Delete" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="ButtonAdd" CssClass="btn btn-success" runat="server" CommandName="AddNew" Text="Add" ValidationGroup="validaiton" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#008500" Font-Bold="True" ForeColor="#FFFFFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>

                                 <%-- NO ROWS THEN ADD ROWS GRID STARTS HERE--%>

                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" ShowFooter="true"
                                    CellPadding="4" DataKeyNames="FOREST_BEAT_NAME"
                                    onrowcommand="gridView_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="FOREST BEAT CODE" ItemStyle-Width="190">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_divisioncode" runat="server" Text='<%# Eval("FOREST_BEAT_CODE") %>'></asp:Label>

                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="instorid" Width="120px" runat="server" onkeypress='codevalidate(event)' />
                                                <asp:RequiredFieldValidator ID="vstorid" runat="server" ControlToValidate="instorid" Text="?" ValidationGroup="validaiton" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FOREST BEAT NAME" ItemStyle-Width="190">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_division" runat="server" Text='<%# Eval("FOREST_BEAT_NAME") %>'></asp:Label>

                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="inname" Width="120px" runat="server" onkeypress='mastervalidatenumerics(event)' />
                                                <asp:RequiredFieldValidator ID="vname" runat="server" ControlToValidate="inname" Text="?" ValidationGroup="validaiton" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="250">
                                            <FooterTemplate>
                                                <asp:Button ID="ButtonAdd1" runat="server" CommandName="AddNew" Text="Add" ValidationGroup="validaiton" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#008500" Font-Bold="True" ForeColor="#FFFFFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>

                            </tr>
                            <%-- <tr>
                                <td class="text-center">&nbsp;</td>
                                <td>
                                    <asp:Button ID="btn_submit"  OnClientClick=" return Validate()" runat="server" Text="Submit" /></td>
                            </tr>--%>
                        </tbody>
                    </table>

                </div>
            </div>

            <div class="col-md-3">
            </div>




        </div>



    </div>
                 </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
