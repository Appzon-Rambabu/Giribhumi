<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="RTGS_FORMAT.aspx.cs" Inherits="ROFR.test.RTGS_FORMAT" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="../css/web.css" rel="stylesheet" />
  
    <script type="text/javascript" src="../js/gridviewscroll.js"></script>
<%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>--%>
<%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
    <script type="text/javascript">
        var gridViewScroll = null;
        window.onload = function () {
            gridViewScroll = new GridViewScroll({
                elementID: "gvMain",
                height: 320,
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
     <script type="text/javascript">
        function openModal() {
            $('#exampleModal').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }
      
    </script>

    <style>
        #gvMain_Content_Fixed {
            width: 100% !important;
        }
        [role="main"] {
            padding-top: 10px !important;
            background-color: #eee;
            padding-bottom: 20px;
        }
         /*.headertable input, select, textarea { 
            border-color: #a9a9a9 !important;
            border-width: 1px !important;
        }*/
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="panel panel-body pt-1 pb-1 mb-2" style="margin-top:150px;">

        <div class="row mb-1 mt-1 justify-content-center">
            
            <div class="col-md-4"></div>
            
            <div class="col-md-4"><h5 class="text-center text-success mb-1 mt-1">RYTHU BHAROSA FORMAT</h5></div>
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">
                    <div class="col-md-7 text-center ml-0 mr-0">
                     
                       <asp:TextBox ID="txtSearch" runat="server"  class="form-control"  placeholder="ROFR PATTADAR NAME..." autocomplete="off"  ></asp:TextBox>
                       
                    </div>

                    <div class="col-md-3 ml-0 mr-0">
                       <%--  <button type="button" class="btn btn-sm btn-success"><i class="fa fa-search"></i> Search</button>--%>
                     <asp:Button ID="btnsubmit" class="btn btn-sm btn-success" style="height: 25px !important;padding: 1px 10px  !important;" OnClick="txtSearch_Click" AutoPostBack="true"  runat="server" Text="Search" />
                    </div>

                    
                   <%-- <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
                      Launch demo modal
                    </button>--%>
                  
                </div>


            </div>
        </div>
        

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

            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="mandal_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label6" runat="server" Text="Mandal:"></asp:Label>&nbsp<asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_mandal" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
             <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="village_records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label4" runat="server" Text="Village:"></asp:Label>&nbsp<asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_village" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
              <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div2" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label10" runat="server" Text="Status:"></asp:Label>&nbsp<asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_valid" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlvalid_OnSelectedIndexChanged" runat="server">
                            <%-- <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Valid</asp:ListItem>
                            <asp:ListItem>Invalid</asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
             <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label2" runat="server" Text="Aadhar/Bank:"></asp:Label>&nbsp<asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_type" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddltype_OnSelectedIndexChanged" runat="server">
                            <%-- <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Aadhar</asp:ListItem>
                            <asp:ListItem>Bank</asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

          <%--  <div class="col-md-2">
                <div class="row d-flex justify-content-center" id="select_records" runat="server">
                    <div class="col-md-7 text-center ml-0 mr-0">
                        <asp:Label ID="txt_records" runat="server" Text="Select Records: "></asp:Label>&nbsp<asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-5 ml-0 mr-0">
                        <asp:DropDownList ID="ddl_records" Style="width: 100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlrecords_OnSelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>--%>
        </div>

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

                                    <th rowspan="2" scope="col">Village<%--<span style="color:red">*</span>--%>
                                        <br />
                                        (5)</th>
                                     <th rowspan="2" scope="col">Farmer Name
                                        <br />
                                        (6)</th>
                                    <th rowspan="2" scope="col">Farmer Father Name<br />
                                        (7)</th>
                                    <th rowspan="2" scope="col">Farmer Aadhar No.<%--<span style="color:red">*</span--%><br />
                                        (8)</th>
                                    <th rowspan="2" scope="col">Bank Account No.<%--<span style="color:red">*</span>--%><br />
                                        (9)</th>
                                    <th rowspan="2" scope="col">Ifsc Code<br />
                                        (10)</th>
                                    <th rowspan="2" scope="col">Bank Name <%--<span style="color:red">*</span>--%><br />
                                        (11)</th>
                                     <th rowspan="2" scope="col">Patta No.<%--<span style="color:red">*</span>--%>
                                        <br />
                                        (12)</th>
                                    <th rowspan="2" scope="col">Compartment No.<%--<span style="color:red">*</span>--%>
                                        <br />
                                        (13)</th>
                                    <th rowspan="2" scope="col">Extent Plot Area<%--<span style="color:red">*</span>--%>
                                        <br />
                                        (14)</th>
                                   
                                    <th rowspan="2" scope="col">Plot No.<%--<span style="color:red">*</span>--%>
                                        <br />
                                        (15)</th>
                                   
                                   
                                </tr>
                                <tr class="GridViewScrollHeader">

                                    <th scope="col">S.No<br />
                                        (1)</th>
                                    <th scope="col">District<span style="color:red">*</span>
                                        <br />
                                        (2)</th>
                                     <th rowspan="2" scope="col">Select Record<span style="color:red"></span>
                                        <br />
                                        (3)</th>
                                    <th rowspan="2" scope="col">Mandal<span style="color:red">*</span>
                                        <br />
                                        (4)</th>
                                    



                                </tr>
                            </thead>
                </HeaderTemplate>

                <ItemTemplate>
                    <tbody>

                        <tr class="GridViewScrollItem" runat="server"  id="row">


                            <td>
                                <asp:Label ID="lbl_sno" runat="server" Text='<%# Eval("sno") %>'></asp:Label>
                            
                                <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                      
                         
                            </td>
                           
                            <td>
                                <%#DataBinder.Eval(Container, "DataItem.District")%>
                              
                            </td>

                            <td>
                                <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" CausesValidation="false" OnCheckedChanged="CheckBox1_CheckedChanged" />

                            </td>
                            

                            <td>
                                
                           <asp:TextBox ID="txt_mandal" runat="server" Text='<%# Eval("Mandal") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>
                            </td>

                            <td>
                               
                               <asp:TextBox ID="txt_village" runat="server" Text='<%# Eval("Village") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>

                            </td>


                            <td>
                                <asp:TextBox ID="txt_rpd" runat="server" Text='<%# Eval("ROFR_PATTADAAR") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>
                            </td>

                             <td>
                                <asp:TextBox ID="txt_Fathername" runat="server" Text='<%# Eval("Father_Name") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>
                            </td>
                           
                             <td>
                                <asp:TextBox ID="txt_adhar" runat="server" Text='<%# Eval("Aadhaar_NO") %>' onkeypress='pattadarnamevalidate(event)' MaxLength="12"></asp:TextBox>
                            </td>
                             <td>
                                <asp:TextBox ID="txt_bankno" runat="server" Text='<%# Eval("BankAccountNo") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>
                            </td>
                             <td>
                                <asp:TextBox ID="txt_ifsc" runat="server" Text='<%# Eval("IfscCode") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>
                            </td>
                             <td>
                                <asp:TextBox ID="txt_bname" runat="server" Text='<%# Eval("BankName") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>
                            </td>
                           
                              <td>
                                <asp:TextBox ID="txt_rpn" runat="server" Text='<%# Eval("ROFR_PATTANO") %>' onkeypress='plotnovalidate(event)'></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txt_cno" runat="server" Text='<%# Eval("Compartment_No") %>' onkeypress='compartnovalidate(event)'></asp:TextBox>
                                                         </td>
                              <td>
                                <asp:TextBox ID="txt_epa" runat="server" Text='<%# Eval("ExtentPlotArea") %>' onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>
                            </td>

                            
                            <td>
                                <asp:TextBox ID="txt_pn" runat="server" Text='<%# Eval("Plot_No") %>' onkeypress='plotnovalidate(event)'></asp:TextBox>
                            </td>

                          
                           

                         
                            
                         
                        


                        </tr>
                    </tbody>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                
                 </div>
                </FooterTemplate>

            </asp:Repeater>
  

        


            <input type="hidden" id="div_position" name="div_position" />
          


            <div class="row justify-content-center mt-1 mb-0">
                <asp:CheckBox ID="chkAll" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" runat="server" CssClass="mb-0" Text="Select All" />

            </div>

        </div>
      
             <div class="row justify-content-center mt-1 mb-0">
           
                <asp:Button ID="btn_submit" OnClick="btnsend_Click" OnClientClick=" return Validate()" runat="server" Text="SUBMIT" />
            


            
        </div>
        <br />
    </div>
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

        function datevalidate(evt) {
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
     <script>

  var count = 0;
  function isDecimalNumber(evt, c) {
      count = count + 1;
      var charCode = (evt.which) ? evt.which : event.keyCode;
      var dot1 = c.value.indexOf('.');
      var dot2 = c.value.lastIndexOf('.');
      if (count > 2 && dot1 == -1) {
          c.value = "";
          count = 0;
      }
      if (dot1 > 2) {
          c.value = "";
      }
      if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
          return false;
      else if (charCode == 46 && (dot1 == dot2) && dot1 != -1 && dot2 != -1)
          return false;

      return true;
  }
</script>

    
</asp:Content>
