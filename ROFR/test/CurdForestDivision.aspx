<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="CurdForestDivision.aspx.cs" Inherits="ROFR.test.CurdForestDivision" EnableEventValidation="false" %>
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
            var result = confirm('Do you want to delete Forset Division ?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
        function Validate() {
            var district = document.getElementById('<%=ddl_district.ClientID %>').value;

            if (district == "0") {

                alert("Please select District!");
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content-area">
     <div class="panel panel-body"  style="margin-top:3px;">

        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">

                <div class="table-responsive">
                      <div class="headertable">

                    <table class="table">
                        <thead>
                            <tr>
                                <h5 class="text-center text-success">UPDATE FOREST DIVISION</h5>
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
                                        
                                        <asp:TemplateField HeaderText="FOREST DIVISION CODE" HeaderStyle-ForeColor="White" ItemStyle-Width="190">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_divisioncode" runat="server" ForeColor="Black" Text='<%# Eval("FOREST_DIVISION_CODE") %>'></asp:Label>

                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txt_divisioncode" runat="server" Text='<%# Eval("FOREST_DIVISION_CODE") %>' onkeypress='codevalidate(event)'  Width="180"></asp:TextBox>
                                            </EditItemTemplate>
                                             <FooterTemplate>
        <asp:TextBox ID="instorid" width="120px" runat="server" onkeypress='codevalidate(event)' />
        <asp:RequiredFieldValidator ID="vstorid" runat="server" ControlToValidate="instorid" Text="?" ValidationGroup="validaiton"/>
    </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FOREST DIVISION NAME" HeaderStyle-ForeColor="White" ItemStyle-Width="250">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_division" runat="server" ForeColor="Black" Text='<%# Eval("FOREST_DIVISION_NAME") %>'></asp:Label>

                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txt_division" runat="server" Text='<%# Eval("FOREST_DIVISION_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>
                                            </EditItemTemplate>
                                             <FooterTemplate>
         <asp:TextBox ID="inname"  width="120px" runat="server" onkeypress='mastervalidatenumerics(event)' />
         <asp:RequiredFieldValidator ID="vname" runat="server" ControlToValidate="inname" Text="?" ValidationGroup="validaiton"/>
     </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="250">
    <EditItemTemplate>
        <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update"  Text="Update"  />
        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel"  Text="Cancel" />
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit"  Text="Edit"  />
        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete"  Text="Delete"  />
    </ItemTemplate>
    <FooterTemplate>
        <asp:Button ID="ButtonAdd" runat="server" CommandName="AddNew"  Text="Add" ValidationGroup="validaiton" />
    </FooterTemplate>
 </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
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
                                    CellPadding="4" DataKeyNames="FOREST_DIVISION_NAME"
                                    onrowcommand="gridView_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="FOREST DIVISION CODE" HeaderStyle-ForeColor="White" ItemStyle-Width="190">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_divisioncode" runat="server" ForeColor="Black" Text='<%# Eval("FOREST_DIVISION_CODE") %>'></asp:Label>

                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="instorid" Width="120px" runat="server" onkeypress='codevalidate(event)' />
                                                <asp:RequiredFieldValidator ID="vstorid" runat="server" ControlToValidate="instorid" Text="?" ValidationGroup="validaiton" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FOREST DIVISION NAME" HeaderStyle-ForeColor="White" ItemStyle-Width="190">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_division" runat="server" ForeColor="Black" Text='<%# Eval("FOREST_DIVISION_NAME") %>'></asp:Label>

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
                                    <FooterStyle BackColor="#007405" ForeColor="#007405" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
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
            </div>

            <div class="col-md-3">
            </div>




        </div>



    </div>
         </div>
</asp:Content>

