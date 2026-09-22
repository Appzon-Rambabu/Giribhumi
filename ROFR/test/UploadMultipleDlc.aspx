<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="UploadMultipleDlc.aspx.cs" Inherits="ROFR.test.UploadMultipleDlc" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../css/web.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/gridviewscroll.js"></script>
    <script type="text/javascript">
        var gridViewScroll = null;
        window.onload = function () {
            gridViewScroll = new GridViewScroll({
                elementID: "gvMain",
                height: 400,
                freezeColumn: true,
                freezeFooter: false,
                freezeColumnCssClass: "GridViewScrollItemFreeze",
                freezeFooterCssClass: "GridViewScrollFooterFreeze",
                freezeHeaderRowCount: 2,
                freezeColumnCount: 2,
                onscroll: function (scrollTop, scrollLeft) {
                    console.log(scrollTop + " - " + scrollLeft);
                }
            });
            gridViewScroll.enhance();

        }
    </script>

    <style>
        #gvMain_Content_Fixed {
            width: 100% !important;
        }
         /*.headertable input, select, textarea { 
            border-color: #a9a9a9 !important;
            border-width: 1px !important;
        }*/
    </style>

    <script>
        function show(input) {
            debugger;
            var validExtensions = ['jpg', 'png', 'jpeg', 'JPG', 'JPEG', 'PNG']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);

            var FileSize = input.files[0].size / 1024 / 1024; // in MB


            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
                $('#user_img').attr('src', "");
                alert("Only these image types are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                    document.getElementById('<%=txt_dlc.ClientID %>').value = '<%= Server.MapPath("~/Beneficairy Images/" +"/"+ DateTime.Now.ToString("dd-MM-yyy") )%> ' + "/" + fileName;
                    document.getElementById('<%=txt_dlc.ClientID %>').value = fileName;
                    var filerdr = new FileReader();
                    filerdr.onload = function (e) {
                        $('#user_img').attr('src', e.target.result);
                    }
                    filerdr.readAsDataURL(input.files[0]);
                }

            }
            if (FileSize > 2) {
                alert('File size exceeds 2 MB');
                return false;
            }
        }
    </script>
    <script>
        function file(input, obj) {
            debugger;
            var validExtensions = ['pdf', 'PDF', 'jpg', 'JPG']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);

            var FileSize = input.files[0].size / 1024 / 1024; // in MB


            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
                // $('#user_img').attr('src', "");
                alert("Only these pdf and jpg files are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                 <%--   document.getElementById('<%=txt_dlc.ClientID %>').value = input.value;--%>

                    document.getElementById('<%=txt_dlc.ClientID %>').value = fileName;
                    var filerdr = new FileReader();
                    filerdr.onload = function (e) {
                        // $('#user_img').attr('src', e.target.result);
                    }
                    filerdr.readAsDataURL(input.files[0]);
                }

            }
            //if (FileSize > 2) {
            //    alert('File size exceeds 2 MB');
            //    return false;
            //}

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="panel panel-body">


        <h5 class="text-center text-success mb-4 mt-3">MULTIPLE DLC UPLOAD</h5>

        <div class="row mb-2">
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="txt_Itda" runat="server" Text="ITDA Name:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_ITda" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="txt_district" runat="server" Text="District:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="mandal_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label6" runat="server" Text="Dlc Date:"></asp:Label>&nbsp<asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_mandal" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
          


            <div class="col-md-2">
                <div class="row d-flex justify-content-center" id="select_records" runat="server">
                    <div class="col-md-7 text-center ml-0 mr-0">
                        <asp:Label ID="txt_records" runat="server" Text="Select Records: "></asp:Label>&nbsp<asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-5 ml-0 mr-0">
                        <asp:DropDownList ID="ddl_records" Style="width: 100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlrecords_OnSelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>





        <%-- <div class="row mb-0">
            <div class="col-md-4"></div>
            <div class="col-md-4">

                <div class="row  d-flex justify-content-center" id="select_records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="txt_records" runat="server" Text="Select Records: "></asp:Label>&nbsp<asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-4">
                        <asp:DropDownList ID="ddl_records" style="width:125px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlrecords_OnSelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                
            </div>


            <div class="col-md-4"></div>
        </div>--%>
        <div id="dvScroll" class="headertable mt-1">
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">

                <HeaderTemplate>
                    <div class="">
                        <%--<h5 class="text-center text-success mb-4">Beneficiary Details</h5>--%>


                        <table id="gvMain" style="border-collapse: collapse;">


                            <thead>



                                <tr class="GridViewScrollHeader">
                                    <td colspan="2" style="background-color: midnightblue; height: 0px !important; padding: 0px !important;">&nbsp</td>
                                    <td colspan="2" style="background-color: midnightblue; height: 0px !important; padding: 0px !important;">&nbsp</td>

                                    <th rowspan="2" scope="col">Habitation<br />
                                        (5)</th>
                                    <th rowspan="2" scope="col">Compartment No.<span style="color:red">*</span><br />
                                        (6)</th>
                                    <th rowspan="2" scope="col">Extent Plot Area <span style="color:red">*</span><br />
                                        (7)</th>
                                    <th rowspan="2" scope="col">ROFR PATTA NO.<span style="color:red">*</span><br />
                                        (8)</th>
                                    <th rowspan="2" scope="col">ROFR PATTADAAR<span style="color:red">*</span><br />
                                        (9)</th>
                                    <th rowspan="2" scope="col">CULTIVATOR NAME<span style="color:red">*</span><br />
                                        (10)</th>
                                     <th rowspan="2" scope="col">DLC DATE<br />
                                        (11)</th>
                                    <th rowspan="2" scope="col">Dlc<br />
                                        (12)</th>
                                    <th rowspan="2" scope="col">
                                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                    </th>
                                    <th rowspan="2" scope="col" style="width: 0px">
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr class="GridViewScrollHeader">

                                    <th scope="col">S.No<br />
                                        (1)</th>
                                    <th scope="col">District<span style="color:red">*</span>
                                        <br />
                                        (2)</th>
                                    <th rowspan="2" scope="col">MANDAL<span style="color:red">*</span>
                                        <br />
                                        (3)</th>
                                    <th rowspan="2" scope="col">VILLAGE<span style="color:red">*</span>
                                        <br />
                                        (4)</th>



                                </tr>
                            </thead>
                </HeaderTemplate>

                <ItemTemplate>
                    <tbody>

                        <tr class="GridViewScrollItem">


                            <td>
                                <asp:Label ID="lbl_Id" runat="server" Text='<%# Eval("sno") %>'></asp:Label>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container, "DataItem.DISTRICT_NAME")%>
                               <%-- <asp:TextBox ID="txt_DN" runat="server" Text='<%# Eval("DISTRICT_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>

                            <td>
                                <asp:DropDownList ID="ddlmandalas" runat="server"></asp:DropDownList>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.MANDAL_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_MN" runat="server" Text='<%# Eval("MANDAL_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>

                            <td>
                                <asp:DropDownList ID="ddlvillages" runat="server"></asp:DropDownList>
                                <%--<%#DataBinder.Eval(Container, "DataItem.VILLAGE_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_VN" runat="server" Text='<%# Eval("VILLAGE_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>

                            </td>


                            <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.HABITATION")%>--%>
                                <asp:TextBox ID="txt_HAB" runat="server" Text='<%# Eval("HABITATION") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>
                            </td>


                            <td>
                                <asp:TextBox ID="txt_CNO" runat="server" Text='<%# Eval("COMPARTMENT_NO") %>' onkeypress='compartnovalidate(event)'></asp:TextBox>
                                <%--   <br />
                                <asp:Label ID="lbl_CNO" runat="server" Visible="false" ForeColor="Red" Text="Please Enter Number Only"></asp:Label>--%>
                            </td>

                            
                            <td>
                                <asp:TextBox ID="txt_EPA" runat="server" Text='<%# Eval("EXTENT_PLOT_AREA") %>' onkeypress='validate(event)'></asp:TextBox>
                            </td>


                            <td>
                                <asp:TextBox ID="txt_RPN" runat="server" Text='<%# Eval("ROFR_PATTA_NO") %>' onkeypress='plotnovalidate(event)'></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txt_RPD" runat="server" Text='<%# Eval("ROFR_PATTADAAR") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txt_CNA" runat="server" Text='<%# Eval("CULTIVATOR_NAME_") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>
                            </td>


                             <td>
                                <asp:TextBox ID="txt_dlcdate" runat="server" Text='<%# Eval("Dlc_date") %>' onkeypress='codevalidate(event)'></asp:TextBox>
                            </td>
                          
                            <td>

                                <asp:LinkButton ID="view_file" CommandArgument='<%#Eval("Id") %>' runat="server" Font-Underline="true" Visible="false" OnClick="Linkview_Click">View DLC</asp:LinkButton>
                                <%--                                <asp:LinkButton ID="Update_dlc"  CommandArgument='<%#Eval("Id") %>' runat="server" ForeColor="#33cc33" Font-Underline="true" >Update DLC</asp:LinkButton>--%>
                                <asp:CheckBox ID="Update_dlc" runat="server" AutoPostBack="false" ForeColor="#33cc33" onclick="javascript:SelectAllCheckboxes(this);" Text="Update DLC" />
                            </td>
                       
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                <asp:Label ID="txtDlc" runat="server" Text='<%# Eval("Dlcpath") %>'></asp:Label>
                            </td>
                        


                        </tr>
                    </tbody>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                
                 </div>
                </FooterTemplate>

            </asp:Repeater>

            <%--<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">View DLC</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                          <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                      <div class="modal-body">
                        <textarea class="form-control" placeholder="hello" value="hello">adas</textarea>
                      </div>
                      <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                      </div>
                    </div>
                  </div>
                </div>--%>



            <input type="hidden" id="div_position" name="div_position" />
            <%--  <tr>
     <td class="text-center">&nbsp;</td>--%>


            <%--  </tr>--%>


            <div class="row justify-content-center mt-1">
                <asp:CheckBox ID="chkAll" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" runat="server" Text="Select All" />

            </div>

        </div>



        <div id="panlimage" runat="server" class="card mb-1 mt-1">
            <div class="card-header bg-info">
                <strong class="text-white">Upload Beneficiary DLC</strong>
            </div>
            <div class="card-body">








                <div class="row">
                  
                    <div class="col-md-1 pt-2 align-bottom"><strong class="text-info">Upload DLC :</strong></div>
                    <div class="col-md-3">
                        <div class="input-group mb-1">
                            <div class="custom-file">

                                <asp:TextBox ID="txt_dlc" runat="server" autocomplete="off" ReadOnly="True"></asp:TextBox>
                                &nbsp&nbsp
    <%--  <input id="file_dlc" type="file" name="file" onchange="file(this)"  runat="server" />--%>
                                <asp:FileUpload ID="file_dlc" runat="server" /><%--<asp:Button ID="btn_dlc" runat="server" Text="Upload" OnClick="btn_dlc_Click"  OnClientClick="return validfile()"/>--%>
                            </div>
                            <div class="input-group-append">
                            </div>
                        </div>
                    </div>








                </div>



                <div class="row justify-content-center mt-2">

                    <div class="col-md-2">
                        <asp:Button ID="btn_Image"  runat="server" Text="SINGLE DLC UPLOAD" />
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btn_Image1" OnClick="btn_Image1_Click" runat="server" Text="MULTIPLE DLC UPLOAD" />
                    </div>
                </div>



            </div>
        </div>
        <div class="row justify-content-center mt-1">
            <div class="col-md-6"><asp:Label ID="lblnote" runat="server" ForeColor="Red"></asp:Label></div>

            <div class="col-md-6 justify-content-start">
                <asp:Button ID="btn_submit" OnClick="btnsend_Click" OnClientClick=" return Validate()" runat="server" Text="SUBMIT" />
            </div>


            
        </div>
        <br />
    </div>



    <%--        </div>
     </div>--%>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    <script type="text/javascript">
        $(".view").live("click", function () {
            var row = $(this).closest("tr");
            alert("test");
        });
    </script>

    <script>
        function validate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9]|\./;
            //var regex = /^[-+]?[0-9]+\.[0-9]+$/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function compartnovalidate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9&]|\,/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function plotnovalidate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9/]|\-/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
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

        function pattadarnamevalidate(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z0-9/]|\a/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function validatenumerics(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z/]|\./;
            if (test.indexOf('.') >= 0) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
           
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        //function SelectAllCheckboxes(chk) {
        //    if (chk.Checked == true)
        //    {
        //        alert("CheckBox checked.");
        //    }
        //    else if (chk.Checked == false) {
        //        alert("CheckBox checked.");
        //    }


        //}
    </script>
</asp:Content>
