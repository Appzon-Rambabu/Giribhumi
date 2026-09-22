<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/LANDTRANSFER_MASTER.Master" AutoEventWireup="true" CodeBehind="LandTransferRegulation.aspx.cs" Inherits="ROFR.pages.LandTransferRegulation" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .aadhar-details .title span {
            font-weight: 600;
        }

        .aadhar-details .value span {
            font-weight: 500;
            color: #0061c1;
        }

        .forest-details .value input, select {
            width: 100%;
        }

        .my-form .value input {
            width: 100%;
        }

        .bg-light-green {
            background: #d4ffe7;
        }
        .calender-button {
            position:absolute;
            right:0;
            top:1px;
        }
    </style>

    <script type="text/javascript">
        function MutExChkList(chk) {
            var chkList = chk.parentNode.parentNode.parentNode;
            var chks = chkList.getElementsByTagName("input");
            for (var i = 0; i < chks.length; i++) {
                if (chks[i] != chk && chk.checked) {
                    chks[i].checked = false;
                }
            }
        }
    </script>

    
    <script type="text/javascript">
         
        function validation()
        {
            var mandal = document.getElementById('<%=txt_mandal.ClientID %>').value;
             var village = document.getElementById('<%=txt_village.ClientID %>').value;
            
             var ltrp = document.getElementById('<%=txt_ltrp.ClientID %>').value;
             var rsno = document.getElementById('<%=txt_rsno.ClientID %>').value;
            
             var extent = document.getElementById('<%=txt_extent.ClientID %>').value;
            
             var orders = document.getElementById('<%=rbtn_orders.ClientID %>').value;
            var rdofile = document.getElementById('<%=File_rdo_doc.ClientID %>').value;
            var extent = document.getElementById('<%=txt_extent.ClientID %>').value;
              var neworderdate = document.getElementById('<%=txt_ltrpdate.ClientID %>').value;
              
            
                
        
            if (neworderdate == "") {

                alert("Please Enter Order Date!");
                return false;
            }
             if (mandal == "") {

                 alert("Please Enter Mandal Name!");
                 return false;
             }
             if (village== "") {
            
                 alert("Please Enter Village Name!");
                 return false;
             }
             if (ltrp == "") {

                 alert("Please Enter LTRP No & Date of orders!");
                 return false;
             }
             if (rsno == "") {

                 alert("Please Enter R.S.No !");
                 return false;
             }
             if (extent == "") {

                 alert("Please Enter Extent Ac-Cts/Hec-a!");
                 return false;
             }
             if (orders == "") {

                 alert("Please Select Orders Passed in whose Favour !");
                 return false;
             }
           
            
           
               
                
             
         } 
         
    </script>

    <script>
         function file(input, obj) {
             debugger;


             for (var i = 0; i < input.files.length; i++) {
                 
                 var fileName = input.files[i].name;
                 var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
              
             
                 var validExtensions = ['pdf', 'PDF', 'jpg', 'jpeg', 'JPG', 'JPEG'];
                 var FileSize = input.files[0].size / 1024 / 1024; // in MB

                
                 if ($.inArray(fileNameExt, validExtensions) == -1) {

                     input.type = ''
                     input.type = 'file'
                    
                        document.getElementById('<%=txt_rdo_sdc_doc.ClientID %>').value = "";
                     alert("Only these pdf and jpg  files are accepted : " + validExtensions.join(', '));
                     return false;
                      
                 }
             }
         
                
                 
                     if (input.files) {

                         document.getElementById('<%=txt_rdo_sdc_doc.ClientID %>').value = "";
                      


                         for (var j = 0;j < input.files.length; j++) {
                            var f = input.files[j];
                             document.getElementById('<%=txt_rdo_sdc_doc.ClientID %>').value += input.files[j].name + " \n  ";

                         }

                         // }
                         var filerdr = new FileReader();
                       
                         filerdr.readAsDataURL(input.files[0]);
                        
                     }

                 }
             
         
            
           
          
        
    </script>

    <script>
        function collectorshow(input) {
            debugger;
            var validExtensions = ['pdf', 'PDF', 'jpg','jpeg','JPG','JPEG']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
                  
                        var FileSize = input.files[0].size / 1024 / 1024; // in MB
           
         
            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
              
                alert("Only these image types are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                 
                    document.getElementById('<%=txt_collector_po_doc.ClientID %>').value = fileName;
                    var filerdr = new FileReader();
                  
                    filerdr.readAsDataURL(input.files[0]);
                }
               
            }
           
        }
        </script>

     <script>
         function Govshow(input) {
            debugger;
            var validExtensions = ['pdf', 'PDF', 'jpg','jpeg','JPG','JPEG']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
                  
                        var FileSize = input.files[0].size / 1024 / 1024; // in MB
           
         
            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
              
                alert("Only these image types are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                
                    document.getElementById('<%=txt_govt_doc.ClientID %>').value = fileName;
                    var filerdr = new FileReader();
                    filerdr.onload = function (e) {
                       
                    }
                    filerdr.readAsDataURL(input.files[0]);
                }
               
            }
           
        }
        </script>
     <script>
         function highshow(input) {
            debugger;
            var validExtensions = ['pdf', 'PDF', 'jpg','jpeg','JPG','JPEG']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
                  
                        var FileSize = input.files[0].size / 1024 / 1024; // in MB
           
         
            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
                
                alert("Only these image types are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                             document.getElementById('<%=txt_high_court_doc.ClientID %>').value = fileName;
                    var filerdr = new FileReader();
                   
                    filerdr.readAsDataURL(input.files[0]);
                }
               
            }
           
        }
        </script>


   
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <%--Modelpopup1--%>
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-sm" role="document">
    <div class="modal-content">
      <%--<div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>--%>
      <div class="modal-body">
       <%-- <div class="row mb-2">
            <div class="col-md-6">
                <div class="row  d-flex justify-content-center" id="Div12" runat="server">
                    <div class="col-md-4 text-center pl-0 pr-0">
                        <asp:Label ID="lblyear" runat="server" CssClass="col-form-label" Text="Year:"></asp:Label>
                            
                    </div>

                    <div class="col-md-8 pl-0 pr-0">
                       <asp:DropDownList ID="ddl_Year" Style="width: 100%"  autocomplete="off"  AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row  d-flex justify-content-center" id="Div13" runat="server">
                    <div class="col-md-4 text-center pl-0 pr-0">
                        <asp:Label ID="lblMonth" runat="server" CssClass="col-form-label" Text="Month:"></asp:Label>
                    </div>

                    <div class="col-md-8 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_Month" Style="width: 100%"  autocomplete="off"  AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>--%>
          <div class="row justify-content-center">
              <asp:Calendar ID="cal_date_orders" CssClass="calender-pop" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="cal_date_orders_SelectionChanged" ShowGridLines="True" Width="220px">
                  <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                  <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                  <OtherMonthDayStyle ForeColor="#CC9966" />
                  <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                  <SelectorStyle BackColor="#FFCC66" />
                  <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                  <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
              </asp:Calendar>
          </div>
      </div>
   <%--   <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>--%>
    </div>
  </div>
</div>
     <%--Modelpopup2--%>
<div class="modal fade" id="exampleModal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-sm" role="document">
    <div class="modal-content">
      <%--<div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>--%>
      <div class="modal-body">
       <%-- <div class="row mb-2">
            <div class="col-md-6">
                <div class="row  d-flex justify-content-center" id="Div22" runat="server">
                    <div class="col-md-4 text-center pl-0 pr-0">
                        <asp:Label ID="Label6" runat="server" CssClass="col-form-label" Text="Year:"></asp:Label>
                            
                    </div>

                    <div class="col-md-8 pl-0 pr-0">
                       <asp:DropDownList ID="DropDownList1" Style="width: 100%"  autocomplete="off"  AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row  d-flex justify-content-center" id="Div23" runat="server">
                    <div class="col-md-4 text-center pl-0 pr-0">
                        <asp:Label ID="Label7" runat="server" CssClass="col-form-label" Text="Month:"></asp:Label>
                    </div>

                    <div class="col-md-8 pl-0 pr-0">
                        <asp:DropDownList ID="DropDownList2" Style="width: 100%"  autocomplete="off"  AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>--%>
          <div class="row justify-content-center">
              <asp:Calendar ID="cal_date_orders1" CssClass="calender-pop" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="cal_date_orders1_SelectionChanged" ShowGridLines="True" Width="220px">
                  <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                  <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                  <OtherMonthDayStyle ForeColor="#CC9966" />
                  <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                  <SelectorStyle BackColor="#FFCC66" />
                  <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                  <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
              </asp:Calendar>
          </div>
      </div>
   <%--   <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>--%>
    </div>
  </div>
</div>
      <%--Modelpopup3--%>
<div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-sm" role="document">
    <div class="modal-content">
      <%--<div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>--%>
      <div class="modal-body">
       <%-- <div class="row mb-2">
            <div class="col-md-6">
                <div class="row  d-flex justify-content-center" id="Div24" runat="server">
                    <div class="col-md-4 text-center pl-0 pr-0">
                        <asp:Label ID="Label8" runat="server" CssClass="col-form-label" Text="Year:"></asp:Label>
                            
                    </div>

                    <div class="col-md-8 pl-0 pr-0">
                       <asp:DropDownList ID="DropDownList3" Style="width: 100%"  autocomplete="off"  AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row  d-flex justify-content-center" id="Div25" runat="server">
                    <div class="col-md-4 text-center pl-0 pr-0">
                        <asp:Label ID="Label9" runat="server" CssClass="col-form-label" Text="Month:"></asp:Label>
                    </div>

                    <div class="col-md-8 pl-0 pr-0">
                        <asp:DropDownList ID="DropDownList4" Style="width: 100%"  autocomplete="off"  AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>--%>
          <div class="row justify-content-center">
              <asp:Calendar ID="cal_date_orders2" CssClass="calender-pop" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="cal_date_orders2_SelectionChanged" ShowGridLines="True" Width="220px">
                  <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                  <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                  <OtherMonthDayStyle ForeColor="#CC9966" />
                  <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                  <SelectorStyle BackColor="#FFCC66" />
                  <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                  <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
              </asp:Calendar>
          </div>
      </div>
   <%--   <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>--%>
    </div>
  </div>
</div>
     <%--Modelpopup4--%>
<div class="modal fade" id="exampleModal3" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-sm" role="document">
    <div class="modal-content">
      <%--<div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>--%>
      <div class="modal-body">
      <%-- <div class="row mb-2">
            <div class="col-md-6">
                <div class="row  d-flex justify-content-center" id="Div26" runat="server">
                    <div class="col-md-4 text-center pl-0 pr-0">
                        <asp:Label ID="Label10" runat="server" CssClass="col-form-label" Text="Year:"></asp:Label>
                            
                    </div>

                    <div class="col-md-8 pl-0 pr-0">
                       <asp:DropDownList ID="DropDownList5" Style="width: 100%"  autocomplete="off"  AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row  d-flex justify-content-center" id="Div27" runat="server">
                    <div class="col-md-4 text-center pl-0 pr-0">
                        <asp:Label ID="Label13" runat="server" CssClass="col-form-label" Text="Month:"></asp:Label>
                    </div>

                    <div class="col-md-8 pl-0 pr-0">
                        <asp:DropDownList ID="DropDownList6" Style="width: 100%"  autocomplete="off"  AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>--%>
          <div class="row justify-content-center">
              <asp:Calendar ID="cal_date_orders3" CssClass="calender-pop" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="cal_date_orders3_SelectionChanged" ShowGridLines="True" Width="220px">
                  <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                  <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                  <OtherMonthDayStyle ForeColor="#CC9966" />
                  <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                  <SelectorStyle BackColor="#FFCC66" />
                  <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                  <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
              </asp:Calendar>
          </div>
      </div>
   <%--   <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>--%>
    </div>
  </div>
</div>
     <%--Modelpopup5--%>
<div class="modal fade" id="exampleModal4" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-sm" role="document">
    <div class="modal-content">
      <%--<div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>--%>
      <div class="modal-body">
      <%-- <div class="row mb-2">
            <div class="col-md-6">
                <div class="row  d-flex justify-content-center" id="Div28" runat="server">
                    <div class="col-md-4 text-center pl-0 pr-0">
                        <asp:Label ID="Label15" runat="server" CssClass="col-form-label" Text="Year:"></asp:Label>
                            
                    </div>

                    <div class="col-md-8 pl-0 pr-0">
                       <asp:DropDownList ID="DropDownList7" Style="width: 100%"  autocomplete="off"  AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row  d-flex justify-content-center" id="Div29" runat="server">
                    <div class="col-md-4 text-center pl-0 pr-0">
                        <asp:Label ID="Label17" runat="server" CssClass="col-form-label" Text="Month:"></asp:Label>
                    </div>

                    <div class="col-md-8 pl-0 pr-0">
                        <asp:DropDownList ID="DropDownList8" Style="width: 100%"  autocomplete="off"  AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>--%>
          <div class="row justify-content-center">
              <asp:Calendar ID="cal_date_orders4" CssClass="calender-pop" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="cal_date_orders4_SelectionChanged" ShowGridLines="True" Width="220px">
                  <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                  <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                  <OtherMonthDayStyle ForeColor="#CC9966" />
                  <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                  <SelectorStyle BackColor="#FFCC66" />
                  <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                  <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
              </asp:Calendar>
          </div>
      </div>
   <%--   <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>--%>
    </div>
  </div>
</div>
    <div class="panel panel-body" style="margin-top: 150px;">


        <h5 class="text-center text-success mb-4 mt-3">LAND TRANSFER REGULATION</h5>


          <div class="col-md-12 text-right" id="div3" runat="server">
              <asp:LinkButton ID="LinkButton1"  Font-Bold="True"  ForeColor="#009900" Font-Underline="True" runat="server" OnClick="link_onclick" >SEARCH LAND TRANSFER REGULATIONS</asp:LinkButton></div>



        <div class="card border border-success bg-light-green" id="div_getdetails" runat="server">
            <div class="card-body aadhar-details">
                <div class="row mb-2">
                    <div class="col-md-12 text-left" id="div_field" runat="server"><span style="color: red">Fields marked as * are mandatory</span></div>
                    <br />
                    <br />
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_mandal" runat="server" Text="Mandal Name:"></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_mandal" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)' ></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_village" runat="server" Text="Village Name:"></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_village" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)' ></asp:TextBox>
                            </div>
                        </div>
                    </div>




                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div4" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_rsno" runat="server" Text="R.S No:"></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_rsno" runat="server" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                    </div>


                </div>
                <div class="row mb-1 mt-3">
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="habiataion" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_extent" runat="server" Text="Extent Ac-Cts/Hec-a"  ></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_extent" runat="server" autocomplete="off" onkeypress="return isDecimalNumber(event,this);"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div2" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_ltrp" runat="server" Text="LTRP No:"></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_ltrp" runat="server" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                  <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="calenderDiv3" runat="server">
                            <%--<div class="col-md-3 text-left title">
                                <asp:Label ID="lbl_dateoforders" runat="server" Text="Date of Orders:"></asp:Label>
                            </div>--%>
                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_OldDateoforder" placeholder="Date Of Order" autocomplete="off" runat="server" style="width:100%;"></asp:TextBox><span style="color: red">*</span>
                            </div>
                            <div class="col-md-6 value">
                               
                                <asp:TextBox ID="txt_ltrpdate" runat="server" autocomplete="off" onkeypress='datevalidate(event)' MaxLength="10"></asp:TextBox><span style="color: red">*</span>
                                
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagesnew/calenderimage.png" CssClass="calender-button" OnClick="ImageButton1_Click" data-toggle="modal" data-target="#exampleModal"/>--%>
                                
                               

                                <img src="../imagesnew/calenderimage.png"  data-toggle="modal" data-target="#exampleModal" class="calender-button"/>

                                

                            </div>
                        </div>
                    </div>
                </div>
                <%-- </div>
         </div>
                    
               
        <div class="card border border-success bg-light mt-3" id="div_forest" runat="server">
            <div class="card-body forest-details">--%>
                <h5 class="mb-3 mt-4">No. & Date of Appeal/Revision Petition/Write Petition/Status of the case</h5>

                <div class="row mb-2 my-form">

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div6" runat="server">
                            <div class="col-md-12 text-left title">
                                <asp:Label ID="txt_additionalagnt" CssClass="text-info" runat="server" Text="Additional Agent to Government :"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div7" runat="server">
                            <div class="col-md-12 text-left title">
                                <asp:Label ID="txt_agent" runat="server" CssClass="text-info" Text="Agent to Government:"></asp:Label>
                            </div>

                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="mandal_Records" runat="server">
                            <div class="col-md-12 text-left title">
                                <asp:Label ID="lbl_govt" runat="server" CssClass="text-info" Text="Government (Revision):"></asp:Label>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="village_Records" runat="server">
                            <div class="col-md-12 text-left title">
                                <asp:Label ID="lbl_highcourt" runat="server" CssClass="text-info" Text="High Court:"></asp:Label>
                            </div>
                        </div>
                    </div>


                </div>

                <div class="row mb-2 my-form">

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div8" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_cma" runat="server" Text="CMA No :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_cma_no" runat="server" autocomplete="off" onkeypress='datevalidate(event)' ></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div9" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_appeal" runat="server" Text="Appeal No :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_appeal_no" runat="server" autocomplete="off" onkeypress='datevalidate(event)'></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div10" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_rpno" runat="server" Text="R.P.No :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_rpnm" runat="server" autocomplete="off" onkeypress='datevalidate(event)'></asp:TextBox>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div11" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_wpno" runat="server" Text="W.P.No :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_wpno" runat="server" autocomplete="off" onkeypress='datevalidate(event)'></asp:TextBox>
                            </div>
                        </div>
                    </div>


                </div>

                <div class="row mb-2 my-form">

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div14" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label1" runat="server" Text="Date of orders :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_ltrpdate1" runat="server" onkeypress='datevalidate(event)' MaxLength="10"></asp:TextBox>
                                
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagesnew/calenderimage.png" CssClass="calender-button" OnClick="ImageButton1_Click" data-toggle="modal" data-target="#exampleModal"/>--%>
                                
                               

                                <img src="../imagesnew/calenderimage.png"  data-toggle="modal" data-target="#exampleModal1" class="calender-button"/>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div15" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label3" runat="server" Text="Date of orders:"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                               <asp:TextBox ID="txt_ltrpdate2" runat="server" onkeypress='datevalidate(event)' MaxLength="10"></asp:TextBox>
                                
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagesnew/calenderimage.png" CssClass="calender-button" OnClick="ImageButton1_Click" data-toggle="modal" data-target="#exampleModal"/>--%>
                                
                               

                                <img src="../imagesnew/calenderimage.png"  data-toggle="modal" data-target="#exampleModal2" class="calender-button"/>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div20" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="txt_ltrpdate7" runat="server" Text="Date of orders:" ></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                               <asp:TextBox ID="txt_ltrpdated" runat="server" onkeypress='datevalidate(event)' MaxLength="10"></asp:TextBox>
                                
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagesnew/calenderimage.png" CssClass="calender-button" OnClick="ImageButton1_Click" data-toggle="modal" data-target="#exampleModal"/>--%>
                                
                               

                                <img src="../imagesnew/calenderimage.png"  data-toggle="modal" data-target="#exampleModal3" class="calender-button"/>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div21" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label5" runat="server" Text="Date of orders:"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_ltrpdate4" runat="server" onkeypress='datevalidate(event)' MaxLength="10" ></asp:TextBox>
                                
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagesnew/calenderimage.png" CssClass="calender-button" OnClick="ImageButton1_Click" data-toggle="modal" data-target="#exampleModal"/>--%>
                                
                               

                                <img src="../imagesnew/calenderimage.png"  data-toggle="modal" data-target="#exampleModal4" class="calender-button"/>
                            </div>
                        </div>
                    </div>


                </div>
                

                <div class="row mb-2 mt-4 my-form">

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div16" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_favour" runat="server" Text="Orders Passed in whose Favour:"></asp:Label>
                            </div>

                            <div class="col-md-6">
                               <%-- <asp:CheckBoxList ID="chkbox_cma" runat="server" RepeatDirection="Vertical">
                                    <asp:ListItem>Non Tribal</asp:ListItem>
                                    <asp:ListItem>Tribal</asp:ListItem>
                                    <asp:ListItem>Goverment</asp:ListItem>
                                </asp:CheckBoxList>--%>

                           <asp:RadioButtonList ID="Radiobox_cma" runat="server">
                             
                          <asp:ListItem Text="Non-Tribal" Value="A"  ></asp:ListItem>
                               <asp:ListItem Text="Tribal" Value="B" ></asp:ListItem>
                               <asp:ListItem Text="Government" Value="C" ></asp:ListItem>
                           </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div17" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lblopassed" runat="server" Text="Orders Passed in whose Favour:"></asp:Label>
                            </div>

                            <div class="col-md-6">
                               <%-- <asp:CheckBoxList ID="Chkbox_appeal" runat="server" RepeatDirection="Vertical">
                                    <asp:ListItem>Non Tribal</asp:ListItem>
                                    <asp:ListItem>Tribal</asp:ListItem>
                                    <asp:ListItem>Goverment</asp:ListItem>
                                </asp:CheckBoxList>--%>
                                <asp:RadioButtonList ID="Radiobox_appeal" runat="server">
                             
                          <asp:ListItem Text="Non-Tribal" Value="A"  ></asp:ListItem>
                               <asp:ListItem Text="Tribal" Value="B" ></asp:ListItem>
                               <asp:ListItem Text="Government" Value="C" ></asp:ListItem>
                           </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div18" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_passed" runat="server" Text="Orders Passed in whose Favour:"></asp:Label>
                            </div>

                            <div class="col-md-6">
                                 <%--<asp:CheckBoxList ID="Chkbox_rpno" runat="server" RepeatDirection="Vertical">
                                    <asp:ListItem>Non Tribal</asp:ListItem>
                                    <asp:ListItem>Tribal</asp:ListItem>
                                    <asp:ListItem>Goverment</asp:ListItem>
                                </asp:CheckBoxList>--%>
                                <asp:RadioButtonList ID="Radiobox_rpno" runat="server">
                             
                          <asp:ListItem Text="Non-Tribal" Value="A"  ></asp:ListItem>
                               <asp:ListItem Text="Tribal" Value="B" ></asp:ListItem>
                               <asp:ListItem Text="Government" Value="C" ></asp:ListItem>
                           </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-3">
                        <div class="row  d-flex justify-content-center" id="Div19" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_orders_passed" runat="server" Text="Orders Passed in whose Favour:"></asp:Label>
                            </div>

                            <div class="col-md-6">
                               <%-- <asp:CheckBoxList ID="Chkbox_wpno" runat="server" RepeatDirection="Vertical">
                                    <asp:ListItem>Non Tribal</asp:ListItem>
                                    <asp:ListItem>Tribal</asp:ListItem>
                                    <asp:ListItem>Goverment</asp:ListItem>
                                </asp:CheckBoxList>--%>
                                <asp:RadioButtonList ID="Radiobox_wpno" runat="server">
                             
                          <asp:ListItem Text="Non-Tribal" Value="A"  ></asp:ListItem>
                               <asp:ListItem Text="Tribal" Value="B" ></asp:ListItem>
                               <asp:ListItem Text="Government" Value="C" ></asp:ListItem>
                           </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>


                </div>

                <%--  <div class="row mt-2 mb-2 justify-content-center">


                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_option" runat="server" Text="Select Option:"></asp:Label> <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:RadioButtonList ID="rbtn_petition" runat="server" RepeatDirection="Horizontal" Width="500px">
                                    <asp:ListItem>Additional Agent to Government <%--(Orders Passed in whose Favour)</asp:ListItem>
                                    <asp:ListItem>Agent to Government <%--(Orders Passed in whose Favour)</asp:ListItem>
                                    <asp:ListItem>Government (Revision)<%--/(Orders Passed in whose Favour)</asp:ListItem>
                                    <asp:ListItem>High Court<%--/ (Orders Passed in whose Favour)</asp:ListItem>
                                </asp:RadioButtonList>
                              
                            </div>
                        </div>
                    </div>



                    </div>--%>
                <%-- <div class="row mt-3 mb-2 justify-content-center">
                      

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_cmano" runat="server" Text="CMA No:"></asp:Label>
                                <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_cma_no" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Lbl_cma_date" runat="server" Text="Date of Orders:"></asp:Label>
                                <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_cma_date" runat="server"></asp:TextBox><asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                            </div>
                        </div>
                    </div>

                       
                    </div>--%>



                <%--  <div class="row mt-3 mb-2 justify-content-left">

                        <div class="col-md-4">
                            <div class="row justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="lbl_favour" runat="server" Text="Orders Passed in whose Favour:"></asp:Label>
                                    <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:CheckBoxList ID="chkbox_appeal" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="chkbox_appeal_SelectedIndexChanged" Width="200px">
                                        <asp:ListItem>Non Tribal</asp:ListItem>
                                        <asp:ListItem>Tribal</asp:ListItem>
                                        <asp:ListItem>Goverment</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>

                   
                        </div>--%>

                <div class="row mt-2 mb-2 justify-content-left">
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Lbl_landpurpose" runat="server" Text="Land Already acquired for any Project Purpose:"></asp:Label>

                            </div>

                            <div class="col-md-6 value">


                                <asp:TextBox ID="txt_land_purpose" runat="server" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Lblremarks" runat="server" Text="Remarks:"></asp:Label>
                                <%--<span style="color: red">*</span>--%>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_remarks" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)' ></asp:TextBox>


                            </div>
                        </div>
                    </div>



                </div>


                <h5 class="mb-3 mt-4">Details of Land which is available for implementation</h5>
                <div class="row mt-2 mb-2 justify-content-left">

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Lbl_acts" runat="server" Text="Ac-cts:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_ac_cts" runat="server" autocomplete="off"></asp:TextBox>

                            </div>
                        </div>
                    </div>


                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Lblhec" runat="server" Text="Hec-A:"></asp:Label>
                                <%--<span style="color: red">*</span>--%>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_hec" runat="server" autocomplete="off"></asp:TextBox>

                            </div>
                        </div>
                    </div>


                </div>
                <h5 class="mb-3 mt-4">Orders Passed in whose Favour</h5>

                <div class="row mt-2 mb-2 justify-content-left">

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_select_option" runat="server" Text="Select Option:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                            </div>

                            <div class="col-md-6 value">

                                <asp:RadioButtonList ID="rbtn_orders" runat="server" RepeatDirection="Horizontal" Width="500px" OnSelectedIndexChanged="rbtn_orders_SelectedIndexChanged">
                                    <asp:ListItem Value="A">Non Tribal</asp:ListItem>
                                    <asp:ListItem Value="B" >Tribal</asp:ListItem>
                                    <asp:ListItem Value="C">Government</asp:ListItem>
                                </asp:RadioButtonList>

                            </div>
                        </div>
                    </div>





                </div>


                <div class="row mt-2 mb-2 justify-content-left">

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Lblname" runat="server" Text="Enter Name:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_name" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)' ></asp:TextBox>

                            </div>
                        </div>
                    </div>





                </div>



            </div>


        </div>


        <div class="card border border-success  bg-light-green mt-3" id="div5" runat="server">
            <div class="card-body forest-details">
                <h6>Upload Documents</h6>
                <div class="row giribhumi-custom-form">

                    <div class="col-md-6 col-12">


                        <div class="row mb-2">
                            <asp:Label ID="Label2" runat="server" Text="RDO/SDC orders:" CssClass="col-md-4 col-form-label">
                                <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                             <asp:TextBox ID="txt_rdo_sdc_doc" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-4" TextMode="MultiLine"></asp:TextBox>
                            <asp:Label ID="lbl_rdo_doc" runat="server" Text=""></asp:Label>
                            <div class="custom-file col-md-4">
                                <%-- <input id="File_rdo" type="file" name="rdo/sdc" onchange="show(this)" runat="server" />--%>
                                <asp:FileUpload ID="File_rdo_doc" runat="server" AllowMultiple="true" />
                             
                                <asp:Button ID="btn_rdo_upload" runat="server" Text="Upload" OnClick="btn_rdo_upload_Click"/>
                            </div>


                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="Label12" runat="server" Text="Collector/PO ITDA orders:" CssClass="col-md-4 col-form-label"></asp:Label>
                            <asp:TextBox ID="txt_collector_po_doc" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-4"></asp:TextBox>
                             <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                            <div class="custom-file col-md-4">
                               <input id="file_collector_po" type="file" name="file" onchange="collectorshow(this)" runat="server" />
                                 <%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                            </div>


                        </div>




                    </div>


                    <div class="col-md-6 col-12">


                        <div class="row mb-2">
                            <asp:Label ID="Label14" runat="server" Text="Government Order:" CssClass="col-md-4 col-form-label"></asp:Label>
                            <asp:TextBox ID="txt_govt_doc" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-4"></asp:TextBox>
                              <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                            <div class="custom-file col-md-4">
                                <input id="file_govt" type="file" name="file" onchange="Govshow(this)" runat="server" />
                                <%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                            </div>


                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="Label16" runat="server" Text="High Court/Supreme Court Order:" CssClass="col-md-4 col-form-label"></asp:Label>
                            <asp:TextBox ID="txt_high_court_doc" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-4"></asp:TextBox>
                            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                            <div class="custom-file col-md-4">
                                <input id="file_high_court" type="file" name="file" onchange="highshow(this)" runat="server" />
                                <%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" /> OnClientClick="return  validation()" --%>
                            </div>


                        </div>



                    </div>


                </div>


                 <div class="row mb-2">
    <asp:GridView runat="server" ID="gvFiles" AutoGenerateColumns="false" 
         OnRowCancelingEdit="OnRowCancelingEdit" OnRowDeleting="OnRowDeleting"
        OnRowEditing="OnRowEditing" OnRowUpdating="OnRowUpdating"  BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" OnSelectedIndexChanged="gvFiles_SelectedIndexChanged">
        <Columns>
             <asp:CommandField ShowEditButton="true"  ControlStyle-Font-Underline="true" />  
                        <asp:CommandField ShowDeleteButton="true" ControlStyle-Font-Underline="true" />
            <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblId" Text='<%#Eval("Sno") %>' runat="server" />
                   

                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblEditId" Text='<%#Eval("Sno") %>' runat="server" />
                    <%--  <asp:Label ID="lblfileid" Text='<%#Eval("Sno") %>' runat="server" />--%>
                </EditItemTemplate>
            </asp:TemplateField>
              <%--<asp:TemplateField HeaderText="File Path" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                         
               <asp:Label ID="lblpath" Text='<%#Eval("RDO_PATH") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField> --%>
            <asp:TemplateField HeaderText="Files">
                <ItemTemplate>
                    <asp:Label ID="lblFile" Text='<%#Eval("RDO_FILENAME") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="fuEditFile" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvEditFile" ErrorMessage="Required" ControlToValidate="fuEditFile"
                        runat="server" ForeColor="Red" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revEditFile" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.doc|.jpg|.pdf)$"
                        ControlToValidate="fuEditFile" runat="server" ForeColor="Red" ErrorMessage="Please select only jpg/doc/pdf file."
                        Display="Dynamic" />
                    &nbsp;<asp:Label ID="lblEditFile" Text='<%#Eval("RDO_FILENAME") %>' runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                         <asp:LinkButton ID="view_file" CommandArgument='<%#Eval("Sno") %>' runat="server" Font-Underline="true"  Width="75" OnClick="Linkview_Click">View DLC</asp:LinkButton>
               
            </ItemTemplate>
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
</div>

                <div class="row mb-2 justify-content-center">

                    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" OnClientClick="return validation() "  />&nbsp&nbsp
                    <asp:Button ID="btn_reset" runat="server" Text="Reset" OnClick="btn_reset_Click" />
                </div>

               <%-- <asp:HiddenField ID="HiddenField1" runat="server" />--%>

            </div>







        </div>

    </div>
     <script>
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
             var regex = /[a-zA-Z/]|\a/;
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
