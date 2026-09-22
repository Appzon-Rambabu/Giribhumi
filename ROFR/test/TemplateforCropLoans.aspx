<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="TemplateforCropLoans.aspx.cs" Inherits="ROFR.test.TemplateforCropLoans" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/web1.css" rel="stylesheet" />
  
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
                /*.panel-body{
	background-color:#fff;
	padding:10px 20px;
	border:1px solid #28a745;
	margin-bottom:20px;
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

 <script>
        function dlcfile(input,obj) {
            debugger;
            var validExtensions = ['pdf', , 'jpg', 'jpeg']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);

            var FileSize = input.files[0].size / 1024 / 1024; // in MB


            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
               // $('#user_img').attr('src', "");
                alert("Only these pdf and jpg  files are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                 <%--   document.getElementById('<%=txt_dlc.ClientID %>').value = input.value;--%>

                      document.getElementById('<%=txt_dlcfile.ClientID %>').value= fileName;
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

     <script>
        function sdlcfile(input,obj) {
            debugger;
            var validExtensions = ['pdf', , 'jpg', 'jpeg']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);

            var FileSize = input.files[0].size / 1024 / 1024; // in MB


            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
               // $('#user_img').attr('src', "");
                alert("Only these pdf and jpg  files are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                 <%--   document.getElementById('<%=txt_dlc.ClientID %>').value = input.value;--%>

                      document.getElementById('<%=txt_sdlc.ClientID %>').value= fileName;
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

     <script>
        function gpfile(input,obj) {
            debugger;
            var validExtensions = ['pdf', , 'jpg', 'jpeg']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);

            var FileSize = input.files[0].size / 1024 / 1024; // in MB


            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
               // $('#user_img').attr('src', "");
                alert("Only these pdf and jpg  files are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                 <%--   document.getElementById('<%=txt_dlc.ClientID %>').value = input.value;--%>

                      document.getElementById('<%=txt_gp_resol.ClientID %>').value= fileName;
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
     <script>
        function pbookfile(input,obj) {
            debugger;
            var validExtensions = ['pdf', , 'jpg', 'jpeg']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);

            var FileSize = input.files[0].size / 1024 / 1024; // in MB


            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
               // $('#user_img').attr('src', "");
                alert("Only these pdf and jpg  files are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                 <%--   document.getElementById('<%=txt_dlc.ClientID %>').value = input.value;--%>

                      document.getElementById('<%=txt_pbook.ClientID %>').value= fileName;
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
     <script type="text/javascript">
         
        function validation()
        {
            var pattano = document.getElementById('<%=txt_pattano.ClientID %>').value;
            var pname = document.getElementById('<%=txt_pname.ClientID %>').value;
            
            var adhar = document.getElementById('<%=txt_adhar.ClientID %>').value;
             var fname = document.getElementById('<%=txt_fname.ClientID %>').value;
             var bname = document.getElementById('<%=txt_bname.ClientID %>').value;
            
            var accno = document.getElementById('<%=txt_accno.ClientID %>').value;
             var ifsc = document.getElementById('<%=txt_ifsc_code.ClientID %>').value;
            var hab = document.getElementById('<%=txt_hb.ClientID %>').value;
            var fdivision = document.getElementById('<%=txt_fd.ClientID %>').value;
            var frange = document.getElementById('<%=txt_fr.ClientID %>').value;
            var fbeat = document.getElementById('<%=txt_fbeat.ClientID %>').value;
              var fblock= document.getElementById('<%=txt_fb.ClientID %>').value;
          
              var cmno= document.getElementById('<%=txt_cmno.ClientID %>').value;
            var rev = document.getElementById('<%=txt_revillage.ClientID %>').value;
             var ext = document.getElementById('<%=txt_ext.ClientID %>').value;
            var dlc = document.getElementById('<%=file_dlc.ClientID %>').value;
            var sdlc = document.getElementById('<%=file_sdlc.ClientID %>').value;
            var gp = document.getElementById('<%=file_gp.ClientID %>').value;
               var pbook = document.getElementById('<%=file_pbook.ClientID %>').value;
          
              
            
                
        
            if (pattano == "") {

                alert("Please enter Rofr Patta No!");
                return false;
            }
            if (pname == "") {

                alert("Please enter Rofr Pattadhar Name!");
                return false;
            }
            if (adhar == "") {

                 alert("Please enter Aadhar Number!");
                 return false;
             }
            if (fname == "") {
            
                 alert("Please enter Father Name!");
                 return false;
             }
            
            if (bname == "") {

                 alert("Please enter Bank Name !");
                 return false;
             }
            if (accno == "") {

                 alert("Please enter Bank Account Number!");
                 return false;
             }
            if (ifsc == "") {

                 alert("Please enter IFSC Code!");
                 return false;
             }
            if (hab == "") {

                 alert("Please enter Habitation !");
                 return false;
             }
           
            if (fdivision == "") {

                 alert("Please enter Forest Division!");
                 return false;
             }
            if (frange == "") {

                 alert("Please enter Forest Range!");
                 return false;
             }

            if (fbeat == "") {

                alert("Please enter Forest Beat!");
                return false;
            }
            if (fblock == "") {

                alert("Please enter Forest Block!");
                return false;
            }
            
            if (cmno == "") {

                alert("Please enter Compartment Number!");
                return false;
            }
            if (rev == "") {

                alert("Please enter Revenue Village!");
                return false;
            }
            if (ext == "") {

                alert("Please enter Extent!");
                return false;
            }
            if (dlc == "") {

                alert("Please Choose DLC file!");
                return false;
            }
            if (sdlc == "") {

                alert("Please Choose SDLC file!");
                return false;
            }
            if (gp == "") {

                alert("Please Choose GP Resolution file!");
                return false;
            }
            if (pbook == "") {

                alert("Please Choose RofrPass Book file!");
                return false;
            }

             
         } 
         
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-area">
     <div class="panel panel-body pt-1 pb-1 mb-2" style="margin-top:3px;">


        <h5 class="text-center text-success mb-1 mt-1">RYTHU BHAROSA FORMAT</h5>

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

        
           <div class="row mb-1 mt-1 justify-content-end">
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
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >

                <HeaderTemplate>
                    <div class="">
                        <%--<h5 class="text-center text-success mb-4">Beneficiary Details</h5>--%>


                        <table id="gvMain" style="border-collapse: collapse;">


                            <thead>



                                <tr class="GridViewScrollHeader">
                                    <td colspan="2" style="background-color: #007405; height: 0px !important; padding: 0px !important;">&nbsp</td>
                                   <td colspan="2" style="background-color: #007405; height: 0px !important; padding: 0px !important;">&nbsp</td>
                                     
                                     <th rowspan="2" scope="col">ROFR PattadarName<span style="color:red">*</span>
                                        <br />
                                        (5)</th>
                                    <th rowspan="2" scope="col">Extent<span style="color:red">*</span>
                                        <br />
                                        (6)</th>
                                    <th rowspan="2" scope="col">AadharNo.<span style="color:red">*</span>
                                        <br />
                                        (7)</th>
                                    <th rowspan="2" scope="col">Father Name/Husband<span style="color:red">*</span>
                                        <br />
                                        (8)</th>
                                    <th rowspan="2" scope="col">Name of the bank<span style="color:red">*</span>
                                        <br />
                                        (9)</th>
                                    <th rowspan="2" scope="col">Account No<span style="color:red">*</span>
                                        <br />
                                        (10)</th>
                                    <th rowspan="2" scope="col">IFSC Code<span style="color:red">*</span>
                                        <br />
                                        (11)</th>
                                    <th rowspan="2" scope="col">Scan copy of Gp resolution,<br />SDLC,DLC Proceedings and ROFR Patta Book
                                        <br />
                                        (12)</th>
                                    <th rowspan="2" scope="col">Mandal<br />
                                        (13)</th>
                                    <th rowspan="2" scope="col">Grama Panchayat<span style="color:red">*</span><br />
                                        (14)</th>
                                    <th rowspan="2" scope="col">Village<span style="color:red">*</span><br />
                                        (15)</th>
                                    <th rowspan="2" scope="col">Habitation<br />
                                        (16)</th>
                                      <th rowspan="2" scope="col">Revenue Village<br />
                                        (17)</th>
                                    <th rowspan="2" scope="col">Forest Division <br />
                                        (18)</th>
                                    <th rowspan="2" scope="col">Forest Range<br />
                                        (19)</th>
                                    <th rowspan="2" scope="col">Forest Beat
                                        (acres)<br />
                                        (20)</th>
                                    <th rowspan="2" scope="col">Forest Block<br />
                                        (21)</th>
                                    <th rowspan="2" scope="col">Compartment No<br />
                                        (22)</th>
                                    <th rowspan="2" scope="col">Extent Plot Area<br />
                                        (23)</th>
                                    <th rowspan="2" scope="col">Total Plot Area<br /> of the Beneficiary<br />
                                        (24)</th>
                                    
                                   
                                    
                                    <th rowspan="2" scope="col">
                                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                    </th>
                                    <th rowspan="2" scope="col" style="width: 0px">
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr class="GridViewScrollHeader">

                                    <th scope="col">ID<br />
                                        (1)</th>
                                      <th scope="col">Select Record<span style="color:red">*</span>
                                        <br />
                                        (2)</th>
                                    <th scope="col">District<span style="color:red">*</span>
                                        <br />
                                        (3)</th>
                                     <th rowspan="2" scope="col">ROFR PattaNo<span style="color:red"></span>
                                        <br />
                                        (4)</th>
                                   
                                    



                                </tr>
                            </thead>
                </HeaderTemplate>

                <ItemTemplate>
                    <tbody>

                        <tr class="GridViewScrollItem" runat="server"  id="row">


                            <td>
                                <asp:Label ID="lbl_Id" runat="server" Text='<%# Eval("croploan_id") %>'></asp:Label>
                            </td>
                           
                              <td>
                                 <asp:Label ID="lblrid" runat="server" Text='<%# Eval("id") %>' Visible="false"> </asp:Label>
                                  <%--<asp:LinkButton ID="LinkButton1" runat="server"  CommandArgument='<%#Eval("id") %>' OnClick="Linkselect_Click"  Font-Underline="true" >EDIT</asp:LinkButton>--%>

                                 <asp:CheckBox ID="chkSelect" runat="server" CommandArgument='<%#Eval("id") %>' AutoPostBack="true" CausesValidation="false" OnCheckedChanged="Checkselect_CheckedChanged" />
                            </td>
                            <td>
                               
                                 <asp:Label ID="LBL_DN" runat="server" Text='<%# Eval("District") %>'></asp:Label>
                               <%-- <asp:TextBox ID="txt_DN" runat="server" Text='<%# Eval("DISTRICT_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>
                             <td>
                               
                                 <asp:Label ID="lbl_RPN" runat="server" Text='<%# Eval("ROFR_PATTANO") %>'></asp:Label>
                                 <asp:TextBox ID="txt_RPN" runat="server" Text='<%# Eval("ROFR_PATTANO") %>' Visible="false"></asp:TextBox>
                                  <%-- <asp:TextBox ID="txt_DN" runat="server" Text='<%# Eval("DISTRICT_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>

                           
                             <td>
                               
                                 <asp:Label ID="txt_RPD" runat="server" Text='<%# Eval("ROFR_PATTADAAR") %>'></asp:Label>
                                  <asp:TextBox ID="txt_RPattadar" runat="server" Text='<%# Eval("ROFR_PATTADAAR") %>' Visible="false"></asp:TextBox>
                               <%-- <asp:TextBox ID="txt_DN" runat="server" Text='<%# Eval("DISTRICT_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>
                              <td>
                               
                                 <asp:Label ID="lbl_extnt" runat="server" Text='<%# Eval("EXTENT") %>'></asp:Label>
                                  <asp:TextBox ID="txt_extnt" runat="server" Text='<%# Eval("EXTENT") %>' Visible="false"></asp:TextBox>
                               <%-- <asp:TextBox ID="txt_DN" runat="server" Text='<%# Eval("DISTRICT_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>
                              <td>
                                <asp:TextBox ID="AADHAR_NO" runat="server" Text='<%# Eval("Aadhaar_NO") %>' onkeypress='codevalidate(event)' MaxLength="12" Visible="false"></asp:TextBox>
                            <asp:Label ID="lbl_aadharno" runat="server" Text='<%# Eval("Aadhaar_NO") %>'  ></asp:Label>
                              </td>
                            <td>
                                <asp:TextBox ID="txt_Fathername" runat="server" Text='<%# Eval("Father_Name") %>' onkeypress='pattadarnamevalidate(event)' Visible="false"></asp:TextBox>
                           <asp:Label ID="lbl_fathername" runat="server" Text='<%# Eval("Father_Name") %>'  ></asp:Label>
                                 </td>
                            <td>
                                   <asp:TextBox ID="txt_Bank" runat="server" Text='<%# Eval("BankName") %>' Visible="false"></asp:TextBox>
                                  <asp:Label ID="lbl_bank" runat="server" Text='<%# Eval("BankName") %>'  ></asp:Label>
                            </td>
                            <td>
                               <asp:TextBox ID="txt_Bankac" runat="server" Text='<%# Eval("BankAccountNo") %>' Visible="false"></asp:TextBox>
                                <asp:Label ID="lbl_bankac" runat="server" Text='<%# Eval("BankAccountNo") %>'  ></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ifsc" runat="server" Text='<%# Eval("IfscCode") %>' Visible="false"></asp:TextBox>
                                 <asp:Label ID="Label3" runat="server" Text='<%# Eval("IfscCode") %>'  ></asp:Label>
                            </td>

                               <td>
                                    <asp:Label ID="lbl_path" runat="server" Text='<%# Eval("Dlcpath") %>'  Visible="false"></asp:Label>
                            <%--    <asp:LinkButton ID="view_file" CommandArgument='<%#Eval("id") %>' runat="server" Font-Underline="true" Visible="false" OnClick="Linkview_Click">View DLC</asp:LinkButton>
                                                                <asp:LinkButton ID="Update_dlc"  CommandArgument='<%#Eval("Id") %>' runat="server" ForeColor="#33cc33" Font-Underline="true" >Update DLC</asp:LinkButton>
                                <asp:CheckBox ID="Update_dlc" runat="server" AutoPostBack="false" ForeColor="#33cc33" onclick="javascript:SelectAllCheckboxes(this);" Text="Update DLC" />--%>
                            </td>
                        
                            

                            <td>
                                <asp:Label ID="ddlmandalas" runat="server" Text='<%# Eval("Mandal") %>' ></asp:Label>
                            <asp:TextBox ID="txt_mandals" runat="server" Text='<%# Eval("Mandal") %>' Visible="false"></asp:TextBox>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.MANDAL_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_MN" runat="server" Text='<%# Eval("MANDAL_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>

                             <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.GP_NAME")%>--%>
                                 <asp:Label ID="txt_GPN" runat="server" Text='<%# Eval("Gram_Panchayat") %>' ></asp:Label>
                                   <asp:TextBox ID="txt_GP" runat="server" Text='<%# Eval("Gram_Panchayat") %>' Visible="false"></asp:TextBox>
                              
                            </td>

                            <td>
                                <asp:Label ID="ddlvillages" runat="server" Text='<%# Eval("Village") %>' ></asp:Label>
                                  <asp:TextBox ID="txt_village" runat="server" Text='<%# Eval("Village") %>' Visible="false"></asp:TextBox>
                              
                                <%--<%#DataBinder.Eval(Container, "DataItem.VILLAGE_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_VN" runat="server" Text='<%# Eval("VILLAGE_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>

                            </td>

                             <td>
                                  <asp:Label ID="txt_HAB" runat="server" Text='<%# Eval("Habitation") %>' ></asp:Label>
                        <asp:TextBox ID="txt_HB" runat="server" Text='<%# Eval("Habitation") %>' Visible="false"></asp:TextBox>
                            </td>
                                 <td>
                                  <asp:Label ID="lbl_rev_village" runat="server" Text='<%# Eval("REV_Village") %>' ></asp:Label>
                        <asp:TextBox ID="txt_rev_village" runat="server" Text='<%# Eval("REV_Village") %>' Visible="false"></asp:TextBox>
                            </td>


                            <td>
                                <asp:Label ID="ddldivisions" runat="server" Text='<%# Eval("Forest_Division") %>' ></asp:Label>
                                   <asp:TextBox ID="txt_division" runat="server" Text='<%# Eval("Forest_Division") %>' Visible="false"></asp:TextBox>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_NAME")%>--%>
                                <%-- <asp:TextBox ID="txt_FDN" runat="server" Text='<%# Eval("FOREST_DIVISION_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>

                            <td>
                                 <asp:Label ID="ddlranges" runat="server" Text='<%# Eval("Forest_Range") %>' ></asp:Label>
                               <asp:TextBox ID="txt_ranges" runat="server" Text='<%# Eval("Forest_Range") %>' Visible="false"></asp:TextBox>
                                <%--<%#DataBinder.Eval(Container, "DataItem.FOREST_RANGE_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_FRN" runat="server" Text='<%# Eval("FOREST_RANGE_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>


                            <td>
                                <asp:Label ID="ddlbeats" runat="server" Text='<%# Eval("Forest_Beat") %>' ></asp:Label>
                                 <asp:TextBox ID="txt_beats" runat="server" Text='<%# Eval("Forest_Beat") %>' Visible="false"></asp:TextBox>
                              
                                <%--<%#DataBinder.Eval(Container, "DataItem.FOREST_BEAT_NAME")%>--%>
                                <%--   <asp:TextBox ID="txt_FBN" runat="server" Text='<%# Eval("FOREST_BEAT_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                            </td>

                            <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>
                                <asp:Label ID="txt_FBL" runat="server" Text='<%# Eval("Forest_Block") %>' ></asp:Label>
                                 <asp:TextBox ID="txt_FBLOCK" runat="server" Text='<%# Eval("Forest_Block") %>' Visible="false"></asp:TextBox>
                               
                            </td>

                            <td>
                                 <asp:Label ID="txt_CNO" runat="server" Text='<%# Eval("Compartment_No") %>' ></asp:Label>
                              <asp:TextBox ID="txt_CN" runat="server" Text='<%# Eval("Compartment_No") %>' Visible="false"></asp:TextBox>
                                <%--   <br />
                                <asp:Label ID="lbl_CNO" runat="server" Visible="false" ForeColor="Red" Text="Please Enter Number Only"></asp:Label>--%>
                            </td>

                 

                        <td>
                                <asp:Label ID="txt_EPA" runat="server" Text='<%# Eval("extentplotarea") %>' ></asp:Label>
                                <asp:TextBox ID="txt_extent" runat="server" Text='<%# Eval("extentplotarea") %>' Visible="false"></asp:TextBox>
                            </td>

                             <td>
                                <asp:Label ID="txt_tEPA" runat="server" Text='<%# Eval("total_extentplotarea") %>' ></asp:Label>
                                  <asp:TextBox ID="txt_totalextent" runat="server" Text='<%# Eval("total_extentplotarea") %>' Visible="false"></asp:TextBox>
                               
                            </td>


                         
                            <%-- <td>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="txtDlc" runat="server" Text='<%# Eval("Dlcpath") %>'  ></asp:Label>
                                 <asp:Label ID="txtimage" runat="server" Text='<%# Eval("Imagepath") %>'  ></asp:Label>
                            </td>
                        --%>


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



    <%--        </div>
     </div>--%>
          </div>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
      <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">UPDATE BENEFICIARY CROP LOAN DETAILS</h5>
           <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return close();">
               --%>
                <asp:ImageButton ID="btn_close" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="Close_Click" />
             
           <%-- </button>--%>
          </div>
          <div class="modal-body" style="max-height:500px;overflow:auto;">
           
               <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-6 col-lg-6 col-12">

                      <div class="row mb-2">
                         
                          <asp:Label ID="lbl_id" runat="server" Text="ID" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    <asp:TextBox ID="txt_mid" runat="server" Text='<%# Eval("Id") %>' CssClass="form-control" Visible="false"></asp:TextBox>
                         
                              <asp:TextBox ID="txt_mid1" runat="server" Text='<%# Eval("croploan_id") %>' CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                      </div>
                      <div class="row mb-2">
                          <asp:Label ID="lbl_pattano" runat="server" Text="ROFR PATTA NO." class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_pattano" runat="server"  CssClass="form-control" onkeypress='plotnovalidate(event)'></asp:TextBox></div>
                         
                      </div>
                         <div class="row mb-2">
                          <asp:Label ID="lbl_adhar" runat="server" Text="AADHAR NO" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_adhar" runat="server"  CssClass="form-control"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_bname" runat="server" Text="NAME OF THE BANK" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_bname" runat="server"  CssClass="form-control"></asp:TextBox></div>
                         
                      </div>
                      <div class="row mb-2">
                          <asp:Label ID="lbl_IFSC" runat="server" Text="IFSC CODE" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_ifsc_code" runat="server"  CssClass="form-control"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_gpt" runat="server" Text="GRAMA PANCHAYAT" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_gpt" runat="server"  CssClass="form-control" onkeypress='mastervalidatenumerics(event)' ReadOnly="true"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_hb" runat="server" Text="HABITATION" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_hb" runat="server"  CssClass="form-control" onkeypress='mastervalidatenumerics(event)'></asp:TextBox></div>
                         
                      </div>
                        <div class="row mb-2">
                          <asp:Label ID="lbl_fr" runat="server" Text="FOREST RANGE" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_fr" runat="server"  CssClass="form-control"></asp:TextBox></div>
                         
                      </div>
                        <div class="row mb-2">
                          <asp:Label ID="lbl_fb" runat="server" Text="FOREST BLOCK" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_fb" runat="server"  CssClass="form-control" onkeypress='mastervalidatenumerics(event)'></asp:TextBox></div>
                         
                      </div>
                        <div class="row mb-2">
                         
                          <asp:Label ID="lbl_revillage" runat="server" Text="REVENUE VILLAGE" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_revillage" runat="server" CssClass="form-control"  ></asp:TextBox></div>
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_epa" runat="server" Text="EXTENT PLOT AREA" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_epa" runat="server"  CssClass="form-control" onkeypress="return isDecimalNumber(event,this);" MaxLength="5" ReadOnly="true"></asp:TextBox></div>
                         
                      </div>
                      <div class="row mb-2">
                          <span class="col-md-4 col-form-label">UPLOAD DLC:<span style="color: Red;">*</span>
                          </span>
                      </div>
                      <div class="row mb-2">
                          <div class="col-md-4">
                               <asp:TextBox ID="txt_dlcfile" runat="server"  CssClass="form-control"></asp:TextBox></div>
                             
                          
                          <div class="col-md-6">
                              <div class="form-group">
                                  <asp:FileUpload ID="file_dlc" runat="server" class="form-control-file"/>
                                 
                              </div>
                          </div>
                        </div>
                       <div class="row mb-2">
                          <span class="col-md-6 col-form-label">UPLOAD GP RESOLUTION:<span style="color: Red;">*</span>
                          </span>
                      </div>
                        <div class="row mb-2">
                          <div class="col-md-4">
                               <asp:TextBox ID="txt_gp_resol" runat="server"  CssClass="form-control"></asp:TextBox></div>
                             
                          
                          <div class="col-md-6">
                              <div class="form-group">
                                  <asp:FileUpload ID="file_gp" runat="server" class="form-control-file"/>
                                 
                              </div>
                          </div>
                            </div>
                      </div>

                  <div class="col-md-6 col-lg-6 col-12">
                      
                       <div class="row mb-2">
                         
                          <asp:Label ID="lbl_dist" runat="server" Text="DISTRICT" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_dist" runat="server"  CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                      </div>
                     
                      <div class="row mb-2">
                         
                          <asp:Label ID="lbl_pname" runat="server" Text="ROFR PATTADAR NAME" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_pname" runat="server" CssClass="form-control" onkeypress='pattadarnamevalidate(event)'></asp:TextBox></div>
                      </div>
                        <div class="row mb-2">
                         
                          <asp:Label ID="lbl_fname" runat="server" Text="FATHER NAME/HUSBAND" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_fname" runat="server" CssClass="form-control" onkeypress='pattadarnamevalidate(event)'></asp:TextBox></div>
                      </div>
                       <div class="row mb-2">
                         
                          <asp:Label ID="lbl_accno" runat="server" Text="BANK ACCOUNT NO" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_accno" runat="server" CssClass="form-control"></asp:TextBox></div>
                      </div>
                        <div class="row mb-2">
                         
                          <asp:Label ID="lbl_mandal" runat="server" Text="MANDAL" class="col-md-4 col-form-label" ></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_mdl" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                      </div>
                       <div class="row mb-2">
                         
                          <asp:Label ID="lbl_village" runat="server" Text="VILLAGE" class="col-md-4 col-form-label" ></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_vlg" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                      </div>
                       <div class="row mb-2">
                         
                          <asp:Label ID="lbl_fd" runat="server" Text="FOREST DIVISION" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_fd" runat="server" CssClass="form-control"></asp:TextBox></div>
                      </div>
                       <div class="row mb-2">
                         
                          <asp:Label ID="lbl_fbeat" runat="server" Text="FOREST BEAT" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_fbeat" runat="server" CssClass="form-control"></asp:TextBox></div>
                      </div>
                       <div class="row mb-2">
                         
                          <asp:Label ID="lbl_cmno" runat="server" Text="COMPARTMENT NO" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_cmno" runat="server" CssClass="form-control" onkeypress='compartnovalidate(event)'></asp:TextBox></div>
                      </div>
                        <div class="row mb-2">
                         
                          <asp:Label ID="lbl_ect" runat="server" Text="EXTENT" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_ext" runat="server" CssClass="form-control"  ></asp:TextBox></div>
                      </div>
                       <div class="row mb-2">
                         
                          <asp:Label ID="lbl_tepa" runat="server" Text="TOTAL EXTENT PLOT AREA" class="col-md-4 col-form-label"></asp:Label><span style="color: Red;">*</span>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_tepa" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                      </div>

                      
                      <div class="row mb-2">
                          <span class="col-md-4 col-form-label">UPLOAD SDLC:<span style="color: Red;">*</span>
                          </span>
                      </div>
                      <div class="row mb-2">
                          <div class="col-md-4">
                               <asp:TextBox ID="txt_sdlc" runat="server" CssClass="form-control"></asp:TextBox></div>
                              
                          
                          <div class="col-md-6">
                              <div class="form-group">
                                  <asp:FileUpload ID="file_sdlc" runat="server" />
                                 
                              </div>
                          </div>
                          </div>
                       <div class="row mb-2">
                          <span class="col-md-6 col-form-label">UPLOAD ROFR PATTA PASSBOOK:<span style="color: Red;">*</span>
                          </span>
                      </div>
                      <div class="row mb-2">
                          <div class="col-md-4">
                               <asp:TextBox ID="txt_pbook" runat="server" CssClass="form-control"></asp:TextBox></div>
                              
                         
                          <div class="col-md-6">
                              <div class="form-group">
                                  <asp:FileUpload ID="file_pbook" runat="server" />
                                 
                              </div>
                          </div>
                           </div>
                      </div>

                  </div>
              </div>
              </div>
                     
  
          <div class="modal-footer">
           
              <asp:Button ID="mbtn_submit" runat="server" Text="Submit" OnClick="mbtn_click" OnClientClick="return validation();" />
           
          </div>
        </div>
      </div>
        </div>
      
    

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
  <%--  <script type="text/javascript">
        $(".view").live("click", function () {
            var row = $(this).closest("tr");
            alert("test");
        });
    </script>--%>

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
