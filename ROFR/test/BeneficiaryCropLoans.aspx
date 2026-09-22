<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="BeneficiaryCropLoans.aspx.cs" Inherits="ROFR.test.BeneficiaryCropLoans" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/web.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/gridviewscroll.js"></script>
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

 

    <%--  <script type="text/javascript">
         function validate() {
             if (( document.getElementById('CheckBox1').checked))
             { document.getElementById("Panel_Uploaddlc").style.display = 'none'; }
            
            return false;
        } 
    </script>--%>

    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("#btnCheck").click(function () {
            var isChecked = $("#chkPassport").is(":checked");
            if (isChecked) {
                alert("CheckBox checked.");
            } else {
                alert("CheckBox not checked.");
            }
        });
    });
</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-area">
     <div class="panel panel-body pt-1 pb-1 mb-2" style="margin-top:150px;">


        <h5 class="text-center text-success mb-1 mt-1">BENEFICIARY CROP LOAN</h5>

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
                        <asp:Label ID="Label6" runat="server" Text="Mandal:"></asp:Label>&nbsp<asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
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
            <asp:Repeater ID="Repeater1" runat="server" >

                <HeaderTemplate>
                    <div class="">
                        <%--<h5 class="text-center text-success mb-4">Beneficiary Details</h5>--%>


                        <table id="gvMain" style="border-collapse: collapse;">


                            <thead>



                                <tr class="GridViewScrollHeader">
                                    <td colspan="2" style="background-color: midnightblue; height: 0px !important; padding: 0px !important;">&nbsp</td>
                                    <td colspan="2" style="background-color: midnightblue; height: 0px !important; padding: 0px !important;">&nbsp</td>

                                    <th rowspan="2" scope="col">AadharNo.<span style="color:red">*</span>
                                        <br />
                                        (5)</th>
                                    <th rowspan="2" scope="col">FATHER NAME/husband<span style="color:red">*</span>
                                        <br />
                                        (6)</th>
                                    <th rowspan="2" scope="col">Name of the bank<span style="color:red">*</span>
                                        <br />
                                        (7)</th>
                                    <th rowspan="2" scope="col">Account No<span style="color:red">*</span>
                                        <br />
                                        (8)</th>
                                    <th rowspan="2" scope="col">IFSC Code<span style="color:red">*</span>
                                        <br />
                                        (9)</th>
                                    <th rowspan="2" scope="col">Scan copy of Gp resolution,<br />SDLC,DLC Proceedings and ROFR Patta Book
                                        <br />
                                        (10)</th>
                                    <th rowspan="2" scope="col">Mandal<br />
                                        (11)</th>
                                    <th rowspan="2" scope="col">Grama Panchayat<span style="color:red">*</span><br />
                                        (12)</th>
                                    <th rowspan="2" scope="col">Village<span style="color:red">*</span><br />
                                        (13)</th>
                                    <th rowspan="2" scope="col">Habitation<br />
                                        (14)</th>
                                    <th rowspan="2" scope="col">Forest Division <br />
                                        (15)</th>
                                    <th rowspan="2" scope="col">Forest Range<br />
                                        (16)</th>
                                    <th rowspan="2" scope="col">Forest Beat
                                        (acres)<br />
                                        (17)</th>
                                    <th rowspan="2" scope="col">Forest Block<br />
                                        (18)</th>
                                    <th rowspan="2" scope="col">Compartment No<br />
                                        (19)</th>
                                    <th rowspan="2" scope="col">Plot Area<br />
                                        (20)</th>
                                    <th rowspan="2" scope="col">Total Plot Area<br /> of the Beneficiary<br />
                                        (21)</th>
                                    
                                   
                                    
                                    <th rowspan="2" scope="col">
                                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                    </th>
                                    <th rowspan="2" scope="col" style="width: 0px">
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr class="GridViewScrollHeader">

                                    <th scope="col">ID<br />
                                        (1)</th>
                                    <th scope="col">District<span style="color:red">*</span>
                                        <br />
                                        (2)</th>
                                     <th rowspan="2" scope="col">ROFR PattaNo<span style="color:red"></span>
                                        <br />
                                        (3)</th>
                                    <th rowspan="2" scope="col">ROFR PattadarName<span style="color:red">*</span>
                                        <br />
                                        (4)</th>
                                    



                                </tr>
                            </thead>
                </HeaderTemplate>

                <ItemTemplate>
                    <tbody>

                        <tr class="GridViewScrollItem" runat="server"  id="row">


                            <td>
                                <asp:Label ID="lbl_Id" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                            </td>
                            <td>
                               
                                 <asp:Label ID="lbl_DN" runat="server" Text='<%# Eval("DISTRICT_NAME") %>'></asp:Label>
                               <%-- <asp:TextBox ID="txt_DN" runat="server" Text='<%# Eval("DISTRICT_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>
                             <td>
                               
                                 <asp:Label ID="lbl_RPN" runat="server" Text='<%# Eval("ROFR_PATTA_NO") %>' Visible="false"></asp:Label>
                              <asp:TextBox ID="txt_RPN" runat="server" Text='<%# Eval("ROFR_PATTA_NO") %>'></asp:TextBox>
                            </td>

                             <td>
                               
                                 <asp:Label ID="lbl_RPD" runat="server" Text='<%# Eval("ROFR_PATTADAAR") %>' Visible="false"></asp:Label>
                            <asp:TextBox ID="txt_RPD" runat="server" Text='<%# Eval("ROFR_PATTADAAR") %>' ></asp:TextBox>
                            </td>

                              <td>
                                <asp:TextBox ID="AADHAR_NO" runat="server" Text='<%# Eval("AADHAR_NO") %>' onkeypress='codevalidate(event)' MaxLength="12"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Fathername" runat="server" Text='<%# Eval("Father_Name") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>
                            </td>
                            <td>
                                   <asp:TextBox ID="txt_Bank" runat="server" Text='<%# Eval("BankName") %>'></asp:TextBox>
                            </td>
                            <td>
                               <asp:TextBox ID="txt_Bankac" runat="server" Text='<%# Eval("BankAccountNo") %>'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ifsc" runat="server" Text='<%# Eval("IfscCode") %>'></asp:TextBox>
                                 <asp:Label ID="Label3" runat="server" Text='<%# Eval("Id") %>'  Visible="false"></asp:Label>
                            </td>

                               <td>

                                <asp:LinkButton ID="view_file" CommandArgument='<%#Eval("Id") %>' runat="server" Font-Underline="true" Visible="false" OnClick="Linkview_Click">View DLC</asp:LinkButton>
                                <%--                                <asp:LinkButton ID="Update_dlc"  CommandArgument='<%#Eval("Id") %>' runat="server" ForeColor="#33cc33" Font-Underline="true" >Update DLC</asp:LinkButton>--%>
                                <asp:CheckBox ID="Update_dlc" runat="server" AutoPostBack="false" ForeColor="#33cc33" onclick="javascript:SelectAllCheckboxes(this);" Text="Update DLC" />
                            </td>
                        
                            

                            <td>
                                <asp:Label ID="lbl_MN" runat="server" Text='<%# Eval("MANDAL_NAME") %>' Visible="false" ></asp:Label>
                            
                                <%-- <%#DataBinder.Eval(Container, "DataItem.MANDAL_NAME")%>--%>
                              <asp:TextBox ID="txt_MN" runat="server" Text='<%# Eval("MANDAL_NAME") %>' ></asp:TextBox>
                            </td>

                             <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.GP_NAME")%>--%>
                                 <asp:Label ID="lbl_GPN" runat="server" Text='<%# Eval("GP_NAME") %>' Visible="false"></asp:Label>
                                 <asp:TextBox ID="txt_GPN" runat="server" Text='<%# Eval("GP_NAME") %>' ></asp:TextBox>
                              
                            </td>

                            <td>
                                <asp:Label ID="lbl_VN" runat="server" Text='<%# Eval("VILLAGE_NAME") %>' Visible="false" ></asp:Label>
                                <asp:TextBox ID="txt_VN" runat="server" Text='<%# Eval("VILLAGE_NAME") %>' ></asp:TextBox>
                              
                                <%--<%#DataBinder.Eval(Container, "DataItem.VILLAGE_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_VN" runat="server" Text='<%# Eval("VILLAGE_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>

                            </td>

                             <td>
                                  <asp:Label ID="lbl_hab" runat="server" Text='<%# Eval("HABITATION") %>' Visible="false"></asp:Label>
                                  <asp:TextBox ID="txt_hab" runat="server" Text='<%# Eval("HABITATION") %>' ></asp:TextBox>
                      
                            </td>


                            <td>
                                <asp:Label ID="lbl_fd" runat="server" Text='<%# Eval("FOREST_DIVISION_NAME") %>' Visible="false" ></asp:Label>
                                 <asp:TextBox ID="txt_fd" runat="server" Text='<%# Eval("FOREST_DIVISION_NAME") %>' ></asp:TextBox>
                                
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_NAME")%>--%>
                                <%-- <asp:TextBox ID="txt_FDN" runat="server" Text='<%# Eval("FOREST_DIVISION_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>

                            <td>
                                 <asp:Label ID="lbl_fr" runat="server" Text='<%# Eval("FOREST_RANGE_NAME") %>' Visible="false"  ></asp:Label>
                                 <asp:TextBox ID="txt_fr" runat="server" Text='<%# Eval("FOREST_RANGE_NAME") %>' ></asp:TextBox>
                              
                                <%--<%#DataBinder.Eval(Container, "DataItem.FOREST_RANGE_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_FRN" runat="server" Text='<%# Eval("FOREST_RANGE_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>


                            <td>
                                <asp:Label ID="lbl_fb" runat="server" Text='<%# Eval("FOREST_BEAT_NAME") %>' Visible="false"  ></asp:Label>
                                 <asp:TextBox ID="txt_fb" runat="server" Text='<%# Eval("FOREST_BEAT_NAME") %>' ></asp:TextBox>
                              
                                <%--<%#DataBinder.Eval(Container, "DataItem.FOREST_BEAT_NAME")%>--%>
                                <%--   <asp:TextBox ID="txt_FBN" runat="server" Text='<%# Eval("FOREST_BEAT_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>

                            <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>
                                <asp:Label ID="lbl_fbl" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' Visible="false"  ></asp:Label>
                                 <asp:TextBox ID="txt_fbl" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' ></asp:TextBox>
                               
                            </td>

                            <td>
                                 <asp:Label ID="lbl_cno" runat="server" Text='<%# Eval("COMPARTMENT_NO") %>' Visible="false"  ></asp:Label>
                                <asp:TextBox ID="txt_cno" runat="server" Text='<%# Eval("COMPARTMENT_NO") %>' ></asp:TextBox>
                            
                                <%--   <br />
                                <asp:Label ID="lbl_CNO" runat="server" Visible="false" ForeColor="Red" Text="Please Enter Number Only"></asp:Label>--%>
                            </td>

                 

                            <td>
                                <asp:Label ID="lbl_epa" runat="server" Text='<%# Eval("EXTENT_PLOT_AREA") %>' Visible="false"  ></asp:Label>
                                <asp:TextBox ID="txt_epa" runat="server" Text='<%# Eval("EXTENT_PLOT_AREA") %>' ></asp:TextBox>
                               
                            </td>

                             <td>
                                <asp:Label ID="lbl_tEPA" runat="server" Text='<%# Eval("EXTENT_PLOT_AREA") %>' Visible="false"  ></asp:Label>
                               <asp:TextBox ID="txt_tEPA" runat="server" Text='<%# Eval("EXTENT_PLOT_AREA") %>'></asp:TextBox>
                            </td>


                         
                             <td>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="txtDlc" runat="server" Text='<%# Eval("Dlcpath") %>'  ></asp:Label>
                                 <asp:Label ID="txtimage" runat="server" Text='<%# Eval("Imagepath") %>'  ></asp:Label>
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


          

        </div>



      
    
        <br />
    </div>

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
