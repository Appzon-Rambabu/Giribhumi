<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="Beneficiary_Transaction.aspx.cs" Inherits="ROFR.test.Beneficiary_Transaction"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .aadhar-details .title span{
            font-weight:600;
        }
        .aadhar-details .value span{
            font-weight:500;
            color:#0061c1;
        }
        .forest-details .value input,select{
            width:100%;
        }
           /*.panel-body{
	background-color:#fff;
	padding:10px 20px;
	border:1px solid #28a745;
	margin-bottom:20px;
}*/
    </style>
   
      <script type="text/javascript">
         
          function valid()
          {
              var aadhar = document.getElementById('<%=txt_adhar.ClientID %>').value;

              if (aadhar == "")
              {

                  
                  alert("Please Enter Beneficiary Id!");
                  return false;
              }
           
          }
          </script>
    <script type="text/javascript">
         
        function validation()
        {
           
            var district = document.getElementById('<%=ddl_district.ClientID %>').value;
            var mandal = document.getElementById('<%=ddl_mandal.ClientID %>').value;
             var village = document.getElementById('<%=ddl_village.ClientID %>').value;
            var division = document.getElementById('<%=ddl_division.ClientID %>').value;
          <%--<%--  var range = document.getElementById('<%=ddl_range.ClientID %>').value;
            var beat = document.getElementById('<%=ddl_beat.ClientID %>').value;--%>--%>
          <%--  var gp = document.getElementById('<%=ddl_gp.ClientID %>').value;--%>
        <%--    var gpcode= document.getElementById('<%=txt_gpcode.ClientID %>').value;
           --%>
            var fblock = document.getElementById('<%=txt_fblock.ClientID %>').value;
               var pattano = document.getElementById('<%=txt_patta_no.ClientID %>').value;
            var compartment = document.getElementById('<%=txt_compartment.ClientID %>').value;
            var plotarea = document.getElementById('<%=txt_plotarea.ClientID %>').value;
            var pattainam = document.getElementById('<%=ddl_patta_inam.ClientID %>').value;
         
           
            var cname = document.getElementById('<%=txt_cname.ClientID %>').value;
            var holding = document.getElementById('<%=txt_holding.ClientID %>').value;
              var landclassification = document.getElementById('<%=txt_land_class.ClientID %>').value;
          <%--  var dlcdate = document.getElementById('<%=txt_dlc_date.ClientID %>').value;--%>
          <%--  var dlc = document.getElementById('<%=file_dlc.ClientID %>').value;--%>

            if (district == "0") {

                alert("Please select District!");
                return false;
            }
            if (mandal == "0") {

                alert("Please select Mandal!");
                return false;
            }
            if (village == "0") {

                alert("Please Select Village!");
                return false;
            }
            if (division == "0") {

                alert("Please select Division!");
                return false;
            }
            //if (range == "0") {

            //    alert("Please select Range!");
            //    return false;
            //}
            //if (beat == "0") {

            //    alert("Please select Beat!");
            //    return false;
            //}
            //if (gp == "") {

            //    alert("Please Enter Grampanchayat!");
            //    return false;
            //}
            //if (gpcode == "") {

            //    alert("Please Enter Grampanchayat code!");
            //    return false;
            //}

            if (fblock == "") {

                alert("Please Enter Forest Block!");
                return false;
            }
            if (pattano == "") {

                alert("Please Enter ROFR Patta Number!");
                return false;
            }

            if (compartment == "") {

                alert("Please Enter Compartment Number!");
                return false;
            }

            if (plotarea == "") {

                alert("Please Enter Plot Area!");
                return false;
            }
            if (pattainam == "0") {

                alert("Please Enter Patta Inam Govt!");
                return false;
            }
          
            if (cname == "") {

                alert("Please Enter Cultivator Name!");
                return false;
            }
            if (holding == "") {

                alert("Please Enter Holding Nature!");
                return false;
            }
            if (landclassification == "") {
                alert("Please Enter Land Classification!");
                return false;
            }

            //if (dlcdate == "") {
            //    alert("Enter Dlc Date!");
            //    return false;
            //}
            //if (dlc == "") {
            //    alert("Please Select Dlc!");
            //    return false;
            //}

        }
        </script>
    <script>
        function file(input,obj) {
            debugger;
            var validExtensions = ['pdf', 'PDF', 'jpg', 'JPG']; //array of valid extensions
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

                      document.getElementById('<%=txt_dlc.ClientID %>').value= "DLC/"+fileName;
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
        <div class="content-area">
    <div class="panel panel-body"  style="margin-top:3px;">


        <h5 class="text-center text-success mb-4 mt-3">FARMER DETAILS</h5>

        <div class="row mb-4 justify-content-center">
            <asp:Label ID="lbl_adhar" runat="server" Text="Enter Beneficiary ID:" CssClass="col-md-2 text-right" >
                <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
           
            <asp:TextBox ID="txt_adhar" runat="server" CssClass="col-md-3" autocomplete="off"></asp:TextBox>
            <div class="col-md-2">
                <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" OnClientClick="return valid()" />
            </div>
            
        </div>


        <div class="card border border-success bg-light" id="div_getdetails" runat="server">
            <div class="card-body aadhar-details">
                <div class="row mb-2">

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="txt_Itda" runat="server" Text="ITDA Name:"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <%-- <asp:DropDownList ID="ddl_ITda" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" runat="server"></asp:DropDownList>--%>
                                <asp:Label ID="Lbl_itda" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="txt_district" runat="server" Text="District:"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:Label ID="lbl_dist" runat="server" Text=""></asp:Label>
                                <%--<asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged" runat="server"></asp:DropDownList>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="mandal_Records" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label6" runat="server" Text="Mandal:"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:Label ID="lbl_mandal" runat="server" Text=""></asp:Label>
                                <%-- <asp:DropDownList ID="ddl_mandal" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" runat="server"></asp:DropDownList>--%>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="village_Records" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label9" runat="server" Text="Village:"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:Label ID="lbl_village" runat="server" Text=""></asp:Label>
                                <%-- <asp:DropDownList ID="ddl_village" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged" runat="server"></asp:DropDownList>--%>
                            </div>
                        </div>
                    </div>
                    

                </div>
                <div class="row mb-1 mt-3">
                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="habiataion" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="txt_Habitation" runat="server" Text="Habitation:"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:Label ID="lbl_habitation" runat="server" Text=""></asp:Label>
                                <%-- <asp:DropDownList ID="ddl_Habitation" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlHabitation_OnSelectedIndexChanged" runat="server"></asp:DropDownList>--%>
                            </div>
                        </div>
                    </div>
                    
                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div2" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label2" runat="server" Text="Pattadhar Name:"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <%-- <asp:DropDownList ID="ddl_ITda" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" runat="server"></asp:DropDownList>--%>
                                <asp:Label ID="lbl_pattadhar" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label11" runat="server" Text="Aadhar Number:"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:Label ID="lbl_adhaar" runat="server" Text=""></asp:Label>
                                <%--  <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged" runat="server"></asp:DropDownList>--%>
                            </div>
                        </div>
                    </div>



                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div7" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label5" runat="server" Text="Father Name:"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <%-- <asp:DropDownList ID="ddl_ITda" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" runat="server"></asp:DropDownList>--%>
                                <asp:Label ID="lbl_father" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    

                </div>
            </div>
         </div>
                    
        <div class="row justify-content-left" id="div_click" runat="server"> <asp:LinkButton ID="LinkButton1" runat="server" CssClass="nav-link" OnClick="LinkButton1_Click"><u>+ Click Here to Enter Farmer Land Details</u></asp:LinkButton></div>


        <div class="col-md-12 text-right" id="div_field" runat="server"><span style="color: red">Fields marked as * are mandatory</span></div>

                
        <div class="card border border-success bg-light mt-3" id="div_forest" runat="server">
            <div class="card-body forest-details">
                <h5 class="mb-3">Forest Details</h5>

                <div class="row mt-2 mb-2 justify-content-center">


                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbldist" runat="server" Text="District:"></asp:Label> <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList ID="ddl_district" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_district_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>



                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lblmandal" runat="server" Text="Mandal:"></asp:Label>
                                <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList  ID="ddl_mandal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_mandal_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Lblvillage" runat="server" Text="Village:"></asp:Label>
                                <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList  ID="ddl_village" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_village_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    </div>
                    <div class="row mt-3 mb-2 justify-content-center">
                        
                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="lbldiv" runat="server" Text="Division:"></asp:Label>
                                    <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:DropDownList ID="ddl_division" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_division_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>


                        
                            <div class="col-md-4">
                                <div class="row  d-flex justify-content-center">
                                    <div class="col-md-6 text-left title">
                                        <asp:Label ID="lblrange" runat="server" Text="Range:"></asp:Label>
                                      <%--  <span style="color: red">*</span>--%>
                                    </div>

                                    <div class="col-md-6 value">
                                        <asp:DropDownList ID="ddl_range" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_range_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>


                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblbeat" runat="server" Text="Beat:"></asp:Label>
                                   <%-- <span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:DropDownList ID="ddl_beat" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_beat_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>



                <div class="row mt-3 mb-2 justify-content-left">

                        <div class="col-md-4">
                            <div class="row justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblgpct" runat="server" Text="Grampanchayat:"></asp:Label>
                                   <%-- <span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">
                                    <%--<asp:TextBox ID="txt_gp" runat="server" autocomplete="off" onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddl_gp" runat="server" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <%--<div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblgpctcode" runat="server" Text="Grampanchayat Code:"></asp:Label>
                                   <%-- <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:TextBox ID="txt_gpcode" runat="server"  autocomplete="off" onkeypress='codevalidate(event)'></asp:TextBox>
                               
                                </div>
                            </div>
                        </div>--%>
                         <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblfblock" runat="server" Text="Forest Block:"></asp:Label>
                                    <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:TextBox ID="txt_fblock" runat="server"  autocomplete="off" onkeypress='mastervalidatenumerics(event)'></asp:TextBox>
                                    
                               
                                </div>
                            </div>
                        </div>
                     <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblpattano" runat="server" Text="Patta Number:"></asp:Label>
                                    <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    
                                    <asp:TextBox ID="txt_patta_no" runat="server"  autocomplete="off" onkeypress='plotnovalidate(event)'></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        </div>

                        <div class="row mt-2 mb-2 justify-content-left">
                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblcmpt" runat="server" Text="Compartment No:"></asp:Label>
                                    <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">

                                    <asp:TextBox ID="txt_compartment" runat="server" autocomplete="off" onkeypress='compartnovalidate(event)'></asp:TextBox>

                                </div>
                            </div>
                        </div>


                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblplot" runat="server" Text="Plot No:"></asp:Label>
                                    <%--<span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:TextBox ID="txt_plot" runat="server"  autocomplete="off" onkeypress='plotnovalidate(event)'></asp:TextBox>
                                    

                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblplotarea" runat="server" Text="Extent Plot Area:"></asp:Label>
                                   <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:TextBox ID="txt_plotarea" runat="server" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>
                                    
                                    

                                </div>
                            </div>
                        </div>


                    </div>



                    <div class="row mt-2 mb-2 justify-content-left">
                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblucland" runat="server" Text="Uncultivable Land:"></asp:Label>
                                   <%-- <span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">

                                    <asp:TextBox ID="txt_uc_land" runat="server"  autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>

                                </div>
                            </div>
                        </div>


                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblcland" runat="server" Text="Cultivable Land:"></asp:Label>
                                    <%--<span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">
                                   
                                    <asp:TextBox ID="txt_c_land" runat="server"  autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblpattainam" runat="server" Text="Patta Inam Govt:"></asp:Label>
                                   <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:DropDownList ID="ddl_patta_inam" runat="server" Visible="false" ></asp:DropDownList>
                                    
                                     <asp:TextBox ID="txt_patta_inam" runat="server"  autocomplete="off" Text="ROFRPATTA" ReadOnly="true"></asp:TextBox>
                                    

                                </div>
                            </div>
                        </div>


                    </div>


                    <div class="row mt-2 mb-2 justify-content-left">
                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblwtax" runat="server" Text="Water Tax:"></asp:Label>
                                   <%-- <span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:TextBox ID="txt_wtax" runat="server"  autocomplete="off"></asp:TextBox>

                                   

                                </div>
                            </div>
                        </div>


                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="lbldry" runat="server" Text="Dry ID:"></asp:Label>
                                    <%--<span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:DropDownList ID="ddl_dry_id" runat="server" ></asp:DropDownList>
                                    

                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="lblwsource" runat="server" Text="Water Source:"></asp:Label>
                                  <%-- <span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:TextBox ID="txt_wsource" runat="server"  autocomplete="off"></asp:TextBox>
                                    
                                    
                                    
                                    

                                </div>
                            </div>
                        </div>


                    </div>



                   <div class="row mt-2 mb-2 justify-content-left">
                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Lblextent" runat="server" Text="Extent Irrigated:"></asp:Label>
                                   <%-- <span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">
                                    

                                   <asp:TextBox ID="txt_Eirrigated" runat="server"  autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>

                                </div>
                            </div>
                        </div>


                       
                      <%--  <div class="col-md-3">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="Label4" runat="server" Text="Water Source:"></asp:Label>
                                   <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:TextBox ID="TextBox2" runat="server"  autocomplete="off"></asp:TextBox>
                                    
                                    
                                    
                                    

                                </div>
                            </div>
                        </div>--%>


                    </div>


                </div>
                    
                    
            
                    



                        

                    
                   


          </div>


                      

         <div class="card border border-success bg-light mt-3" id="div_beneficiary" runat="server">
             <div class="card-body forest-details">

                 <h5 class="mb-3">Farmer Land Details</h5>

                 <div class="row mt-2 mb-2 justify-content-center">


                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="lblcname" runat="server" Text="Cultivator Name:"></asp:Label>
                                 <span style="color: red">*</span>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_cname" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)'></asp:TextBox>

                             </div>
                         </div>
                     </div>



                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="lbleucname" runat="server" Text="Extent Under Cultivator:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_eu_cultivator" runat="server" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>

                             </div>
                         </div>
                     </div>
                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lblhnature" runat="server" Text="Holding Nature:"></asp:Label>
                                 <span style="color: red">*</span>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_holding" runat="server" autocomplete="off" onkeypress='mastervalidatenumerics(event)'></asp:TextBox>

                             </div>
                         </div>
                     </div>

                 </div>


                 <div class="row mt-2 mb-2 justify-content-left">
                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lbltypecode" runat="server" Text="Type Code:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_typecode" runat="server" autocomplete="off" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>

                             </div>
                         </div>
                     </div>



                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="lblextnt" runat="server" Text="Extent:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_extent" runat="server" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>

                             </div>
                         </div>
                     </div>


                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lblnsarea" runat="server" Text="Net Sown Area"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_net_area" runat="server" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>

                             </div>
                         </div>
                     </div>
                 </div>

                 <div class="row mt-2 mb-2 justify-content-left">
                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lblkharif" runat="server" Text="Kharif/Rabi:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:DropDownList ID="ddl_kharif" runat="server"></asp:DropDownList>


                             </div>
                         </div>
                     </div>

                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lblmonth" runat="server" Text="Month of Cultivation:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:DropDownList ID="ddl_month" runat="server"></asp:DropDownList>


                             </div>
                         </div>
                     </div>
                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lblcrop" runat="server" Text="Crop:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_crop" runat="server" autocomplete="off"></asp:TextBox>



                             </div>
                         </div>
                     </div>
                 </div>

                 <div class="row mt-2 mb-2 justify-content-left">
                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lblsingle" runat="server" Text="Single Crop:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_single" runat="server" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>


                             </div>
                         </div>
                     </div>


                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lblmixed" runat="server" Text="Mixed:"></asp:Label>
                                 <%--<span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_mixed" runat="server" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>


                             </div>
                         </div>
                     </div>
                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lbltotal" runat="server" Text="Total:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">


                                 <asp:TextBox ID="txt_total" runat="server" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>

                             </div>
                         </div>
                     </div>


                 </div>



                 <div class="row mt-2 mb-2 justify-content-left">


                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lblwsource1" runat="server" Text="Water Source1:"></asp:Label>
                                 <%--<span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_water" runat="server" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>


                             </div>
                         </div>
                     </div>

                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Label18" runat="server" Text="First Crop:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_firstcrop" runat="server" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>


                             </div>
                         </div>
                     </div>

                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Llblstcrop" runat="server" Text="Second/Third Crop:"></asp:Label>
                               <%--  <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">


                                 <asp:TextBox ID="txt_secondcrop" runat="server" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox>

                             </div>
                         </div>
                     </div>


                 </div>



                 <div class="row mt-2 mb-2 justify-content-left">
                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lblcyield" runat="server" Text="Crop Yield:"></asp:Label>
                                 <%--<span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">

                                 <asp:TextBox ID="txt_crop_yield" runat="server" autocomplete="off"></asp:TextBox>

                             </div>
                         </div>
                     </div>


                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lblclassification" runat="server" Text="Land Classification:"></asp:Label>
                                 <span style="color: red">*</span>
                             </div>

                             <div class="col-md-6 value">

                                 <asp:DropDownList ID="ddl_land_class" runat="server" Visible="false"></asp:DropDownList>

                                   <asp:TextBox ID="txt_land_class" runat="server" autocomplete="off" Text="ROFR" ReadOnly="true"></asp:TextBox>
                             </div>
                         </div>
                     </div>
                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lbldlcdate" runat="server" Text="Dlc Date:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_dlc_date" runat="server" autocomplete="off" onkeypress='datevalidate(event)' MaxLength="10"></asp:TextBox>






                             </div>
                         </div>
                     </div>


                 </div>


                 <div class="row mt-2 mb-2 justify-content-left">
                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Lblvremarks" runat="server" Text="VRO/RI Remarks:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_vro" runat="server" autocomplete="off" onkeypress='mastervalidatenumerics(event)'></asp:TextBox>



                             </div>
                         </div>
                     </div>


                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="lbltremarks" runat="server" Text="Thasildar Remarks:"></asp:Label>
                                 <%--<span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_Thasildar" runat="server" autocomplete="off" onkeypress='mastervalidatenumerics(event)'></asp:TextBox>


                             </div>
                         </div>
                     </div>
                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="lblremarks" runat="server" Text="Remarks:"></asp:Label>
                              <%--   <span style="color: red">*</span>--%>
                             </div>

                             <div class="col-md-6 value">

                                 <asp:TextBox ID="txt_remarks" runat="server" autocomplete="off" onkeypress='mastervalidatenumerics(event)'></asp:TextBox>

                            </div>
                         </div>
                     </div>
                 </div>

                 <div class="row mt-2 mb-2 justify-content-left">
                     
                     <div class="col-md-6">
                         <div class="row  d-flex justify-content-left">
                             <div class="col-md-4 text-left title">
                                 <asp:Label ID="Label1" runat="server" Text="DLC:"></asp:Label>
                               <%-- <span style="color: red">*</span>--%>
                             </div>
                             <div class="col-md-8 value">
                                 <div class="row">
                                     <div class="col-md-6">
                                <asp:TextBox ID="txt_dlc" runat="server" autocomplete="off" ReadOnly="True"></asp:TextBox></div>
                                <%--  <input id="file_dlc" type="file" name="file" onchange="file(this)"  runat="server" />--%>
                                     <div class="col-md-6">
                                <asp:FileUpload ID="file_dlc" runat="server" /></div>
                                <%--<asp:Button ID="btn_dlc" runat="server" Text="Upload" OnClick="btn_dlc_Click"  OnClientClick="return validfile()"/>--%>
                        </div> </div></div>
                     </div>

                 </div>


                 <div class="row justify-content-center">
                     
                     <asp:Button ID="Button1"  runat="server" Text="Submit" OnClick="Submit_Click" OnClientClick="return validation()" />&nbsp&nbsp
                     <asp:Button ID="Button2" runat="server" Text="Reset" OnClick="Button2_Click" />
                 </div>

             </div>
         </div>
        </div>
            </div>
          <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
   

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
