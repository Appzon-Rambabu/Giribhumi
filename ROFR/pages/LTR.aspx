<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="LTR.aspx.cs" Inherits="ROFR.pages.LTR"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
    <link href="../date/css/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen"/>
     <script type="text/javascript">
        function noBack()
         {
             window.history.forward()
         }
        noBack();
        window.onload = noBack;
        window.onpageshow = function(evt) { if (evt.persisted) noBack() }
        window.onunload = function() { void (0) }
    </script>
    
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

        .input-group-addon{
            background-color: #eee;
            border: 1px solid #ccc;
            padding: 0px 5px;
            border-radius: 0px 5px 5px 0px;
            
        }
        .input-group-addon span{
            color: #000 !important;
        }
    </style>
    <%-- <script type="text/javascript"> 
        function setFocus() { 
            document.getElementById('<%=chk_add_agent.ClientID %>').focus(); 
        } 
  
        function removeFocus() { 
            document.getElementById("focus").blur(); 
        } 
    </script> --%>
 
      
   
    <script type="text/javascript">
         
        function validation()
        {
            var itda = document.getElementById('<%=ddl_itda.ClientID %>').value;
            var district = document.getElementById('<%=ddl_district.ClientID %>').value;
            var mandal = document.getElementById('<%=ddl_mandal.ClientID %>').value;
            var village = document.getElementById('<%=ddl_village.ClientID %>').value;
               var hab = document.getElementById('<%=ddl_hab.ClientID %>').value;
             var rsno = document.getElementById('<%=txt_rsno.ClientID %>').value;
            
            var extent = document.getElementById('<%=txt_extent.ClientID %>').value;
             var ltrp = document.getElementById('<%=txt_ltrp.ClientID %>').value;
          <%--  var ltrpdate = document.getElementById('<%=dtp_input2.ClientID %>').value;
            var sdclevel = document.getElementById('<%=ddl_sdc.ClientID %>').value;
           --%>



           
            var respondent= document.getElementById('<%=txt_respondent.ClientID %>').value;
            
            // var orders = document.getElementById('<%=rbtn_sdc_orders_passed.ClientID %>').value;
            //var rdofile = document.getElementById('<%=File_rdo_doc.ClientID %>').value;
           // var extent = document.getElementById('<%=txt_extent.ClientID %>').value;
          
              
          
        
            if (itda == "0") {

                alert("Please Select Itda!");
                return false;
            }
            if (district == "0") {

                alert("Please Select district!");
                return false;
            }
             if (mandal == "0") {

                 alert("Please Select Mandal Name!");
                 return false;
             }
             if (village== "0") {
            
                 alert("Please Select Village Name!");
                 return false;
             }
             if (hab == "0") {

                 alert("Please Select Habitation Name!");
                 return false;
             }

             if (rsno == "") {

                 alert("Please Enter R.S.No !");
                 return false;
             }
             if (extent == "") {

                 alert("Please Enter Extent Ac-Cts!");
                 return false;
             }
             if (ltrp == "") {

                 alert("Please Enter LTRP No!");
                 return false;
             }
             //if (ltrpdate == "") {

             //    alert("Please Enter LTRP Date of Orders!");
             //    return false;
             //}
             //if (sdclevel == "0")
             //{
             //    alert("Please Select Petition!");
             //    return false;
             //}
            
             if (petitioner == "") {

                 alert("Please Enter Petitioner name!");
                 return false;
             }
             if (respondent == "") {

                 alert("Please Enter Respondent name!");
                 return false;
             }

            
               
                
             
         } 
         
    </script>

    <script>
         function filesdc(input, obj) {
             debugger;


             for (var i = 0; i < input.files.length; i++) {
                 
                 var fileName = input.files[i].name;
                 var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
              
             
                 var validExtensions = ['pdf', 'jpg', 'jpeg'];
                 var FileSize = input.files[0].size / 1024 / 1024; // in MB

                
                 if ($.inArray(fileNameExt, validExtensions) == -1) {

                     input.type = ''
                     input.type = 'file'
                    
                        document.getElementById('<%=txt_sdc_file.ClientID %>').value = "";
                     alert("Only these pdf and jpg  files are accepted : " + validExtensions.join(', '));
                     return false;
                      
                 }
             }
         
                
                 
                     if (input.files) {

                         document.getElementById('<%=txt_sdc_file.ClientID %>').value = "";
                      


                         for (var j = 0;j < input.files.length; j++) {
                            var f = input.files[j];
                             document.getElementById('<%=txt_sdc_file.ClientID %>').value += input.files[j].name + " \n  ";

                         }

                         // }
                         var filerdr = new FileReader();
                       
                         filerdr.readAsDataURL(input.files[0]);
                        
                     }

                 }
        
    </script>

    <script>
         function file(input, obj) {
             debugger;

             for (var i = 0; i < input.files.length; i++) {
                 
                 var fileName = input.files[i].name;
                 var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
              
             
                 var validExtensions = ['pdf', 'jpg', 'jpeg'];
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
         function filecollector(input, obj) {
             debugger;
             for (var i = 0; i < input.files.length; i++) {
                 
                 var fileName = input.files[i].name;
                 var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
              
             
                 var validExtensions = ['pdf', 'jpg', 'jpeg'];
                 var FileSize = input.files[0].size / 1024 / 1024; // in MB

                
                 if ($.inArray(fileNameExt, validExtensions) == -1) {

                     input.type = ''
                     input.type = 'file'
                    
                        document.getElementById('<%=txt_collector_po_doc.ClientID %>').value = "";
                     alert("Only these pdf and jpg  files are accepted : " + validExtensions.join(', '));
                     return false;
                      
                 }
             }
         
                
                 
                     if (input.files) {

                         document.getElementById('<%=txt_collector_po_doc.ClientID %>').value = "";
                      


                         for (var j = 0;j < input.files.length; j++) {
                            var f = input.files[j];
                             document.getElementById('<%=txt_collector_po_doc.ClientID %>').value += input.files[j].name + " \n  ";

                         }

                         // }
                         var filerdr = new FileReader();
                       
                         filerdr.readAsDataURL(input.files[0]);
                        
                     }

                 }
    </script>

     <script>
         function filegov(input, obj) {
             debugger;
             for (var i = 0; i < input.files.length; i++) {
                 
                 var fileName = input.files[i].name;
                 var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
              
             
                 var validExtensions = ['pdf', 'jpg', 'jpeg'];
                 var FileSize = input.files[0].size / 1024 / 1024; // in MB

                
                 if ($.inArray(fileNameExt, validExtensions) == -1) {

                     input.type = ''
                     input.type = 'file'
                    
                        document.getElementById('<%=txt_govt_doc.ClientID %>').value = "";
                     alert("Only these pdf and jpg  files are accepted : " + validExtensions.join(', '));
                     return false;
                      
                 }
             }
         
                
                 
                     if (input.files) {

                         document.getElementById('<%=txt_govt_doc.ClientID %>').value = "";
                      


                         for (var j = 0;j < input.files.length; j++) {
                            var f = input.files[j];
                             document.getElementById('<%=txt_govt_doc.ClientID %>').value += input.files[j].name + " \n  ";

                         }

                         // }
                         var filerdr = new FileReader();
                       
                         filerdr.readAsDataURL(input.files[0]);
                        
                     }

                 }
    </script>

     <script>
         function filehighcourt(input, obj) {
             debugger;
             for (var i = 0; i < input.files.length; i++) {
                 
                 var fileName = input.files[i].name;
                 var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
              
             
                 var validExtensions = ['pdf', 'jpg', 'jpeg'];
                 var FileSize = input.files[0].size / 1024 / 1024; // in MB

                
                 if ($.inArray(fileNameExt, validExtensions) == -1) {

                     input.type = ''
                     input.type = 'file'
                    
                        document.getElementById('<%=txt_high_court_doc.ClientID %>').value = "";
                     alert("Only these pdf and jpg  files are accepted : " + validExtensions.join(', '));
                     return false;
                      
                 }
             }
         
                
                 
                     if (input.files) {

                         document.getElementById('<%=txt_high_court_doc.ClientID %>').value = "";
                      


                         for (var j = 0;j < input.files.length; j++) {
                            var f = input.files[j];
                             document.getElementById('<%=txt_high_court_doc.ClientID %>').value += input.files[j].name + " \n  ";

                         }

                         // }
                         var filerdr = new FileReader();
                       
                         filerdr.readAsDataURL(input.files[0]);
                        
                     }

                 }
    </script>

   <%-- <script>
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
        </script>--%>

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

   
     <asp:UpdatePanel runat="server">
            <ContentTemplate>
    <div class="panel panel-body">
        
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
       <div class="col-md-12 text-right" id="div_field" runat="server">
           <asp:LinkButton ID="btnback" runat="server" OnClick="btnback_Click" Font-Underline="true">Back</asp:LinkButton>

       </div>

        <h5 class="text-center text-success mb-4 mt-3" id="h_title" runat="server">LAND TRANSFER REGULATION</h5>
      
        <div class="card border border-success bg-light-green" id="div_getdetails" runat="server">
             
            <div class="card-body aadhar-details">
                 <div class="row mb-2">
                    <div class="col-md-12 text-left" id="div5" runat="server"><span style="color: red">Fields marked as * are mandatory</span>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div6" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_itda" runat="server" Text="ITDA :"></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList ID="ddl_itda" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_itda_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div7" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_distrcit" runat="server" Text="District:"></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                 <asp:DropDownList ID="ddl_district" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_district_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row mb-2">
                  
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_mandal" runat="server" Text="Mandal Name:"></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                          <asp:DropDownList ID="ddl_mandal" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_mandal_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                <%--<asp:TextBox ID="txt_mandal" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)' ></asp:TextBox>--%>

                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_village" runat="server" Text="Village Name:"></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                          <asp:DropDownList ID="ddl_village" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_village_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>

                                <%--<asp:TextBox ID="txt_village" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)' ></asp:TextBox>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div17" runat="server">
                            <div class="col-md-4 text-left title">
                                <asp:Label ID="Lbl_hab" runat="server" Text="Habitation:"></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList ID="ddl_hab" runat="server" OnSelectedIndexChanged="ddl_hab_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                               
                            </div>
                        </div>
                    </div>
                   <%-- <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div4" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_rsno" runat="server" Text="R.S No:"></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_rsno" runat="server" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                    </div>--%>
                </div>
                <div class="row mb-1 mt-3">
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div4" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_rsno" runat="server" Text="R.S No:/Sy.No"></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_rsno" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="habiataion" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_extent" runat="server" Text="Extent Ac-Cts"  ></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_extent" runat="server" autocomplete="off"  CssClass="form-control" onkeypress="return isNumberKey(event,this);"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    </div>
                <div class="row">
                   <div class="col-md-12 text-left" id="div3" runat="server"><span style="color: red">Note: If R.S.No. is not there then enter 'NA'</span></div>
                 </div>
                      <div class="row">
                  <h5  class="mb-2 mt-2 float-left">At SDC(TW)/Sub Collector Orders Passed in whose Favour</h5>
                </div>
                 <div class="row mb-2">
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div2" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_ltrp" runat="server" Text="LTRP No/SR/OP:"></asp:Label><span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_ltrp" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                     <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="calenderDiv3" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label1" runat="server" Text="Date of Orders:"></asp:Label><%--<span style="color: red">*</span>--%>
                            </div>
                            <div class="col-md-6 value">
                               
                              <%--  <asp:TextBox ID="txt_ltrpdate" runat="server" autocomplete="off" onkeypress='datevalidate(event)' MaxLength="10"  CssClass="form-control "></asp:TextBox>
                                
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagesnew/calenderimage.png" CssClass="calender-button" OnClick="ImageButton1_Click" data-toggle="modal" data-target="#exampleModal"/>--%>
                                
                               

                                 <%-- <img src="../imagesnew/calenderimage.png"  data-toggle="modal" data-target="#exampleModal" class="calender-button"/>--%>

                                <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input2" data-link-format="dd/mm/yyyy">
                                        <asp:TextBox ID="dtp_input2" name="txt_ltrpdate" runat="server" class="form-control" autocomplete="off" placeholder="dd/mm/yyyy" ></asp:TextBox>
					                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                    </div>
				                   <%-- <input type="hidden" id="dtp_input2" name="txt_ltrpdate"  disabled /><br/>--%>
                                


                            </div>
                       

                      </div>
                                         
                </div>

                       <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div8" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label18" runat="server" Text="Date of Disposal:"></asp:Label><%--<span style="color: red">*</span>--%>
                            </div>
                            <div class="col-md-6 value">
                               
                              <%--  <asp:TextBox ID="txt_ltrpdate" runat="server" autocomplete="off" onkeypress='datevalidate(event)' MaxLength="10"  CssClass="form-control "></asp:TextBox>
                                
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagesnew/calenderimage.png" CssClass="calender-button" OnClick="ImageButton1_Click" data-toggle="modal" data-target="#exampleModal"/>--%>
                                
                               

                                 <%-- <img src="../imagesnew/calenderimage.png"  data-toggle="modal" data-target="#exampleModal" class="calender-button"/>--%>

                                <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input2" data-link-format="dd/mm/yyyy">
                                        <asp:TextBox ID="txt_OldDateoforder" name="txt_ltrpdate" runat="server" class="form-control" autocomplete="off" placeholder="dd/mm/yyyy" ></asp:TextBox>
					                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                    </div>
				                   <%-- <input type="hidden" id="dtp_input2" name="txt_ltrpdate"  disabled /><br/>--%>
                                


                            </div>
                       

                      </div>
                                         
                </div>

                 </div>
                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2 title">
                        <asp:Label ID="Label5" runat="server" Text="Petition:"></asp:Label><%--<span style="color: red">*</span>--%>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddl_sdc" runat="server" OnSelectedIndexChanged="ddl_sdc_SelectedIndexChanged" AutoPostBack="true">
                          <asp:ListItem Value="0">Select</asp:ListItem>
                              <asp:ListItem Value="ALLOWED">ALLOWED</asp:ListItem>
                            <asp:ListItem Value="DISALLOWED">DISALLOWED</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                   <%-- <div class="col-md-2">
                        <div class="form-check">
                            <input class="form-check-input" type="checkbox" value="" id="defaultCheck2">
                            <label class="form-check-label" for="defaultCheck2">
                                Fully
                            </label>
                        </div>
                    </div>--%>
                       
                    <div class="col-md-2">
                        <asp:LinkButton ID="btn_edit" runat="server"  Font-Underline="true" OnClick="btn_edit_Click" >Edit</asp:LinkButton>
                    </div>

                </div>

                <div class="row text-left" id="div_sdc" runat="server">
                 <div class="col-md-2 title"><asp:Label ID="Lbl_sdc" runat="server" Text="Orders Passed in whose Favour:"></asp:Label><%--<span style="color: red">*</span>--%>

                 </div>
                    
                    
                    <div class="col-md-2" id="div_sdc_passed" runat="server">
                        <asp:RadioButtonList ID="rbtn_sdc_orders_passed" runat="server" RepeatDirection="Horizontal" Height="16px" Width="100%"  AutoPostBack="true" OnSelectedIndexChanged="rbtn_sdc_orders_passed_SelectedIndexChanged" >
                              
                            <asp:ListItem Value="A">Partially</asp:ListItem>
                            <asp:ListItem Value="B">Fully</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>

                    <div class="col-md-3"  id="div_sdc_disallowed" runat="server">
                        <asp:RadioButtonList ID="rbtn_sdc_disallowed" runat="server" RepeatDirection="Horizontal" Height="16px" Width="100%"  AutoPostBack="true" OnSelectedIndexChanged="rbtn_sdc_disallowed_SelectedIndexChanged" >
                            <asp:ListItem Value="A">On Full trial</asp:ListItem>
                            <asp:ListItem Value="B">Resjudicated/Dropped</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>

                   <%-- <div class="col-md-5">
                        <asp:RadioButtonList ID="rbtn_sdc_remanded" runat="server" RepeatDirection="Horizontal" Height="16px" Width="100%"  AutoPostBack="true" OnSelectedIndexChanged="rbtn_hc_orders_passed_SelectedIndexChanged">
                            <asp:ListItem Value="A">Additional Agent</asp:ListItem>
                            <asp:ListItem Value="B">Agent to Government</asp:ListItem>
                            <asp:ListItem Value="B">Government</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>--%>
                </div>

              <%--  <div class="row mt-2 mb-2 justify-content-left" id="div_sdc_orders_option" runat="server" style="display:none">

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_select_option" runat="server" Text="Select Option:"></asp:Label>
                                <%-- <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">

                                <asp:RadioButtonList ID="rbtn_orders" runat="server" RepeatDirection="Horizontal" Width="500px"  OnSelectedIndexChanged="rbtn_orders_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="A" >Non Tribal</asp:ListItem>
                                    <asp:ListItem Value="B" >Tribal</asp:ListItem>
                                    <asp:ListItem Value="C">Government</asp:ListItem>
                                </asp:RadioButtonList>

                            </div>
                        </div>
                    </div>
                </div>--%>


                 <div class="col-md-12 mb-2 mt-2" id="div_sdc_partially" runat="server">
                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_sdc_nt" runat="server" Text="Non Tribal" OnCheckedChanged="rbtn_sdc_nt_CheckedChanged" AutoPostBack="true" />
                    </div>
                    <div id="div_sdc_nt_name" class="col-md-10" runat="server">
                    <div class="row">
                        <div class="col-md-2"> <asp:Label ID="Label9" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_sdc_nt_name" runat="server"  CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label10" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_sdc_nt_extent" runat="server" autocomplete="off" CssClass="form-control" onkeypress="return isDecimalNumber(event,this);"></asp:TextBox>
                    </div>
                    </div>
                        </div>
                </div>

                <div class="row mt-2 mb-2 text-left" id="div_sdc_tri" runat="server">
                    <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_sdc_tri" runat="server" Text="Tribal" AutoPostBack="true" OnCheckedChanged="rbtn_sdc_tri_CheckedChanged"/>
                        
                 

                    </div>
                     <div id="div_sdc_tri_name" class="col-md-10" runat="server">
                         <div class="row">
                             <div class="col-md-2">
                                 <asp:Label ID="lbl_sdc_tri_name" runat="server" Text="Enter Name:"></asp:Label></div>
                             <div class="col-md-2">
                                 <asp:TextBox ID="txt_sdc_tri_name" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                             </div>
                             <div class="col-md-2">
                                 <asp:Label ID="lbl_sdc_tri_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                             <div class="col-md-2">
                                 <asp:TextBox ID="txt_sdc_tri_extent" runat="server" CssClass="form-control" autocomplete="off" onkeypress="return isDecimalNumber(event,this);"></asp:TextBox>
                             </div>
                         </div>
                          <div class="row mt-2">
                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbtn_sdc_tri_impl" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Value="A">Orders Implemented</asp:ListItem>
                                    <asp:ListItem Value="B">Available for Implementation</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                     </div>
                          <div class="row mt-2">
                            <div class="col-md-12">
                                 <div class="row mt-2 mb-2 justify-content-left">

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Lbl_acts" runat="server" Text="Ac-cts:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_t_ac_cts" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>

                            </div>
                        </div>
                    </div>


                <%--    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Lblhec" runat="server" Text="Hec-A:"></asp:Label>
                                
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_t_hec"  CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>

                            </div>
                        </div>
                    </div>--%>


                </div>
                               
                            </div>
                     </div>
                         </div>
                </div>

                <div class="row mt-2 mb-2 text-left" id="div_sdc_ogov" runat="server">
                   <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_sdc_gov" runat="server" Text="Government"  AutoPostBack="true" OnCheckedChanged="rbtn_sdc_gov_CheckedChanged"/>
                        
                 

                    </div>
                       <div id="div_sdc_gov" class="col-md-10" runat="server">
                    <div class="row">
                     
                    <div class="col-md-2"> <asp:Label ID="lbl_sdc_gov_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_sdc_gov_name" runat="server"  CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_sdc_gov_extent" runat="server" Text="Enter Extent:" ></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_sdc_gov_extent" runat="server"  CssClass="form-control" autocomplete="off" ></asp:TextBox>
                    </div>
                        </div>
                            <div class="row mt-2">
                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbtn_sdc_gov_impl" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Value="A">Orders Implemented</asp:ListItem>
                                    <asp:ListItem Value="B">Available for Implementation</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                     </div>
                            <div class="row mt-2">
                            <div class="col-md-12">
                                 <div class="row mt-2 mb-2 justify-content-left">

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label11" runat="server" Text="Ac-cts:"></asp:Label>
                                <%-- <span style="color: red">*</span>--%>
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_g_ac_cts" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>

                            </div>
                        </div>
                    </div>


                  <%--  <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label13" runat="server" Text="Hec-A:"></asp:Label>
                               
                            </div>

                            <div class="col-md-6 value">

                                <asp:TextBox ID="txt_g_hec" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>

                            </div>
                        </div>
                    </div>--%>


                </div>
                               
                            </div>
                     </div>
                         </div>
                    </div>
                </div>

             <%--   <div class="row mt-2 mb-2 justify-content-left" id="div_sdc_nt_name" runat="server"  >

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Lblname" runat="server" Text="Non Tribal Name:"></asp:Label>
                                <%-- <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_name" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)'  CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label9" runat="server" Text="Extent:"></asp:Label>
                                <%-- <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_sdc_nt_extent" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)'  CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                    </div>





                </div>

                <div class="row mt-2 mb-2 justify-content-left" id="div_sdc_tri_name" runat="server"  >

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label10" runat="server" Text="Tribal Name:"></asp:Label>
                                <%-- <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_sdc_tri_name" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)'  CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label11" runat="server" Text="Tribal Extent:"></asp:Label>
                                <%-- <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_sdc_tri_extent" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)'  CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                    </div>





                </div>

                  <div class="row mt-2 mb-2 justify-content-left" id="div_sdc_tri_orders_impl" runat="server">
                             <div class="col-md-2 text-left title">
                                <asp:Label ID="Label17" runat="server" Text="Select:"></asp:Label>
                                <%-- <span style="color: red">*</span>
                            </div>
                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbtn_sdc_tri_orders_impl" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem>Orders Implemented</asp:ListItem>
                                    <asp:ListItem>Available for Implementation</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                     </div>

                  <div class="row mt-2 mb-2 justify-content-left" id="div_sdc_gov_name" runat="server"  >

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label13" runat="server" Text="Enter Name:"></asp:Label>
                                <%-- <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_sdc_gov_name" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)'  CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label15" runat="server" Text="Extent:"></asp:Label>
                                <%-- <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_sdc_gov_extent" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)'  CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                    </div>





                </div>

                <div class="row mt-2 mb-2 justify-content-left" id="div_sdc_gov_orders_impl" runat="server">
                             <div class="col-md-2 text-left title">
                                <asp:Label ID="Label18" runat="server" Text="Select:"></asp:Label>
                                <%-- <span style="color: red">*</span>
                            </div>
                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rntn_sdc_gov_impl" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem>Orders Implemented</asp:ListItem>
                                    <asp:ListItem>Available for Implementation</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                     </div>
--%>

             
                
                  <div class="row mt-2 mb-2 justify-content-left">

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_petitioner" runat="server" Text="Petitioner:"></asp:Label>
                                <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_petitioner" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)'  CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_respondent" runat="server" Text="Respondent:"></asp:Label>
                                <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_respondent" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)'  CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                </div>

                 <div class="row mb-2 text-left justify-content-left  title">
                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-center">
                             <div class="col-md-6 text-left title">
                                 <asp:Label ID="Label3" runat="server" Text="Orders:" CssClass="col-form-label">
                              <%--  <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>--%></asp:Label>

                             </div>
                             <div class="col-md-6 value">
                                 <asp:TextBox ID="txt_sdc_file" runat="server" autocomplete="off"  CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

                             </div>
                         </div>
                     </div>

                     <div class="col-md-4">
                         <div class="row  d-flex justify-content-left">
                             <div class="col-md-6 text-left title">
                                 <asp:FileUpload ID="File_sdc" runat="server" AllowMultiple="true"  />
                             </div>
                             <div class="col-md-6 value text-left">
                                 <div class="custom-file">
                                <%-- <input id="File_rdo" type="file" name="rdo/sdc" onchange="show(this)" runat="server" />--%>

                             <asp:Button ID="btn_sdc_upload" runat="server" Text="Upload" OnClick="btn_sdc_upload_Click" />
                            </div>
                             </div>
                         </div>
                     </div>
                           


                        </div>

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

                <div class="row mt-2 mb-2 justify-content-left">
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label7" runat="server" Text="Case Status At SDC"></asp:Label>

                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList ID="ddl_sdc_status" runat="server">
                                    <asp:ListItem>SELECT</asp:ListItem>
                                    <asp:ListItem>PENDING</asp:ListItem>
                                    <asp:ListItem>DISPOSED</asp:ListItem>
                                </asp:DropDownList>

                               
                            </div>
                        </div>
                    </div>


                 


                </div>


                <div class="row" id="div_label" runat="server">
                 <h5 class="mb-3 mt-4 float-left">No. & Date of Appeal/Revision Petition/Write Petition/Status of the case</h5>
                
                    
                
                </div>
                <div class="row" id="div_note" runat="server">
                <marquee behaviour="scroll" direction="left" width="100%" height="20px" onmousehover="this.stop();" onmouseout="this.start();">
                    <p style="color:red;">Note :Please check on each checkbox to edit each level </p></marquee>
                </div>
              <%--  Additional agent--%>
               
                 <div class="row text-left  title  mt-2 mb-2">
                 
                             <asp:CheckBox ID="chk_add_agent" runat="server" AutoPostBack="true" OnCheckedChanged="chk_add_agent_CheckedChanged"   />
                        <asp:Label ID="Label4" CssClass="text-info" runat="server" Text="Additional Agent to Government :"></asp:Label>
 
                          
                 </div>
                       
                <div style="background:#eee; border-radius:5px;padding:10px 10px;" id="div_add_agent" runat="server">
                <div class="row">
                    
                    <div class="col-md-4 col-xl-4">
                        <div class="row  d-flex justify-content-center" id="Div13" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_cma_no" runat="server" Text="CMA No/SRA :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_cma_no" runat="server" autocomplete="off" onkeypress='datevalidate(event)' ></asp:TextBox>
                            </div>
                        </div>
                    </div>

                     <div class="col-md-4 col-xl-4">
                         <div class="row  d-flex justify-content-center" id="Div14" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_add_dt_orders" runat="server" Text="Date of orders :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                               
                             <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="txt_add_dt_orders" data-link-format="dd/mm/yyyy">
                                        <asp:TextBox ID="txt_add_dt_orders" name="txt_ltrpdate" runat="server" class="form-control" placeholder="dd/mm/yyyy" autocomplete="off"  ></asp:TextBox>
					                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                    </div>
                            </div>
                        </div>
                     </div>

                     <div class="col-md-4 col-xl-4">
                         <div class="row  d-flex justify-content-center" id="Div18" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label22" runat="server" Text="Date of Disposal :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                               
                             <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="txt_add_dt_orders" data-link-format="dd/mm/yyyy">
                                        <asp:TextBox ID="txt_add_disposal" name="txt_ltrpdate" runat="server" class="form-control" placeholder="dd/mm/yyyy" autocomplete="off"  ></asp:TextBox>
					                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                    </div>
                            </div>
                        </div>
                     </div>
                </div>
                     <div class="row mt-2 mb-2 text-left">
                         <div class="col-md-4 col-xl-4">
                             <div class="row  d-flex justify-content-left" >
                                 <div class="col-md-6 text-left title">
                                     <asp:Label ID="Label20" runat="server" Text="Appeal:"></asp:Label>
                                 </div>
                                 <div class="col-md-6 value">
                                     <asp:DropDownList ID="ddl_add" runat="server" OnSelectedIndexChanged="ddl_add_SelectedIndexChanged" AutoPostBack="true">
                                         <asp:ListItem Value="1">SELECT</asp:ListItem>
                                         <asp:ListItem Value="ALLOWED">ALLOWED</asp:ListItem>
                                         <asp:ListItem Value="DISALLOWED">DISALLOWED</asp:ListItem>
                                         <asp:ListItem Value="REMANDED">REMANDED</asp:ListItem>
                                     </asp:DropDownList>
                                 </div>
                             </div>
                         </div>

                    

                   <%-- <div class="col-md-2">
                        <div class="form-check">
                            <input class="form-check-input" type="checkbox" value="" id="defaultCheck2">
                            <label class="form-check-label" for="defaultCheck2">
                                Fully
                            </label>
                        </div>
                    </div>--%>

                </div>

                <div class="row mt-2 mb-2 text-left" id="div_add_option" runat="server">

                    <div class="col-md-2 title" id="div_add_passed" runat="server"><asp:Label ID="lbl_add_orders_passed" runat="server" Text="Orders Passed in whose Favour:"></asp:Label></div>

                    <div class="col-md-2" id="div_add_allowed" runat="server">
                       
<%--                            <asp:CheckBoxList ID="Chk_agent_order_passed" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Partially</asp:ListItem>
                                <asp:ListItem>Fully</asp:ListItem>
                            </asp:CheckBoxList>--%>

                        <asp:RadioButtonList ID="rbtn_add_orders_passed" runat="server" RepeatDirection="Horizontal" Height="16px" Width="205px"  AutoPostBack="true" OnSelectedIndexChanged="rbtn_add_orders_passed_SelectedIndexChanged" >
                            <asp:ListItem  Text="Partially" Value="A" ></asp:ListItem>
                            <asp:ListItem Text="Fully" Value="B"></asp:ListItem>
                            </asp:RadioButtonList>
                       
                    </div>
                     <div class="col-md-3" id="div_add_disallowed" runat="server">
                        <asp:RadioButtonList ID="rbtn_add_disallowed" runat="server" RepeatDirection="Horizontal" Height="16px" Width="100%"  AutoPostBack="true" >
                            <asp:ListItem Value="A">On Full trial</asp:ListItem>
                            <asp:ListItem Value="B">Resjudicated/Dropped</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>

                    <div class="col-md-5" id="div_add_remanded" runat="server">
                        <asp:RadioButtonList ID="rbtn_add_remanded" runat="server" RepeatDirection="Horizontal" Height="16px" Width="100%"  AutoPostBack="true" >
                           
                           <%-- <asp:ListItem Value="A">Agent to Government</asp:ListItem>
                            <asp:ListItem Value="B">Government</asp:ListItem>
                             <asp:ListItem Value="C">High Court</asp:ListItem>--%>
                             <asp:ListItem Value="D">SDC</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>

                   <%-- <div class="col-md-2">
                        <div class="form-check">
                            <input class="form-check-input" type="checkbox" value="" id="defaultCheck2">
                            <label class="form-check-label" for="defaultCheck2">
                                Fully
                            </label>
                        </div>
                    </div>--%>

                </div>
                <div class="col-md-12 mb-2 mt-2" id="div_add_partially" runat="server">
                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_add_nt" runat="server" Text="Non Tribal" OnCheckedChanged="rbtn_add_nt_CheckedChanged" AutoPostBack="true" />
                        
                 

                    </div>
                    <div id="div_add_nt_txt" class="col-md-10" runat="server">
                    <div class="row">
                        <div class="col-md-2"> <asp:Label ID="lbl_add_nt_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_add_nt_name" runat="server"  CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_add_nt_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_add_nt_extent" runat="server"  CssClass="form-control" autocomplete="off" onkeypress="return isDecimalNumber(event,this);"></asp:TextBox>
                    </div>
                    </div>
                        </div>
                </div>

                <div class="row mt-2 mb-2 text-left" id="div_add_tri" runat="server">
                    <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_add_tri" runat="server" Text="Tribal" AutoPostBack="true" OnCheckedChanged="rbtn_add_tri_CheckedChanged"/>
                        
                 

                    </div>
                     <div id="div_add_tri_txt" class="col-md-10" runat="server">
                    <div class="row">
                    <div class="col-md-2"> <asp:Label ID="lbl_add_tri_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_add_tri_name" runat="server"  CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_add_tri_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_add_tri_extent" runat="server"  CssClass="form-control" autocomplete="off" onkeypress="return isDecimalNumber(event,this);"></asp:TextBox>
                    </div>
                        </div>
                          <div class="row mt-2">
                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbtn_add_tri_impl" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Value="A">Orders Implemented</asp:ListItem>
                                    <asp:ListItem Value="B">Available for Implementation</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                     </div>
                         </div>
                </div>

                <div class="row mt-2 mb-2 text-left" id="div_add_gov" runat="server">
                   <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_add_gov" runat="server" Text="Government"  AutoPostBack="true" OnCheckedChanged="rbtn_add_gov_CheckedChanged"/>
                        
                 

                    </div>
                       <div id="div_add_gov_txt" class="col-md-10" runat="server">
                    <div class="row">
                     
                    <div class="col-md-2"> <asp:Label ID="lbl_add_gov_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_add_gov_name" runat="server"  CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_add_gov_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_add_gov_extent" runat="server"  CssClass="form-control" autocomplete="off" onkeypress="return isDecimalNumber(event,this);"></asp:TextBox>
                    </div>
                        </div>
                            <div class="row mt-2">
                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbtn_add_gov_impl" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Value="A">Orders Implemented</asp:ListItem>
                                    <asp:ListItem Value="B">Available for Implementation</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                     </div>
                         </div>
                    </div>
                </div>


                   <%--   <div class="col-md-12 mb-2 mt-2">
                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Non Tribal" />
                        
                 

                    </div>
                    <div class="col-md-2"> <asp:Label ID="Label2" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox3" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="TextBox5" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Tribal" />
                        
                 

                    </div>
                    <div class="col-md-2"> <asp:Label ID="Label5" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox16" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label10" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="TextBox17" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-2 mb-2 text-left">
                   <div class="col-md-2">
                        <asp:RadioButton ID="RadioButton3" runat="server" Text="Government" />
                        
                 

                    </div>
                    <div class="col-md-2"> <asp:Label ID="Label33" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox18" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label34" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="TextBox19" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    </div>
                </div>--%>
                    F
                  
                <div class="row mb-2 text-left justify-content-left  title">
                            
                    <div class="col-md-2 ">
                        <asp:Label ID="Label28" runat="server" Text="RDO/SDC orders:" CssClass="col-form-label">
                              <%--  <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>--%></asp:Label>
                    </div>
                    <div class="col-md-2 ">
                        <asp:TextBox ID="txt_rdo_sdc_doc" runat="server" autocomplete="off" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                       
                    </div>


                    <div class="custom-file col-md-2">
                        <%-- <input id="File_rdo" type="file" name="rdo/sdc" onchange="show(this)" runat="server" />--%>
                        <asp:FileUpload ID="File_rdo_doc" runat="server" AllowMultiple="true" />
                    </div>

                    <div class="custom-file col-md-2">
                        <asp:Button ID="btn_rdo_upload" runat="server" Text="Upload" OnClick="btn_rdo_upload_Click" />
                    </div>
                </div>
                  
                <div class="row mt-2 mb-2 justify-content-left">
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label8" runat="server" Text="Case Status "></asp:Label>

                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList ID="ddl_add_status" runat="server">
                                    <asp:ListItem>SELECT</asp:ListItem>
                                    <asp:ListItem>PENDING</asp:ListItem>
                                    <asp:ListItem>DISPOSED</asp:ListItem>
                                </asp:DropDownList>

                               
                            </div>
                        </div>
                    </div>
                   
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-left">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_add_remarks" runat="server" Text="Remarks:"></asp:Label>
                                <%--<span style="color: red">*</span>--%>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_add_remarks" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)' class="form-control"></asp:TextBox>


                            </div>
                        </div>
                    </div>



                </div>
                </div>


                 <%--  Agent to Government--%>
                   <div class="row text-left  title  mt-2 mb-2">
                  
                       <asp:CheckBox ID="chk_agent" runat="server" AutoPostBack="true" OnCheckedChanged="chk_agent_CheckedChanged"/>
                        <asp:Label ID="lbl_agent" CssClass="text-info" runat="server" Text="Agent to Government :"></asp:Label>
  
                            </div>

                <div style="background:#eee; border-radius:5px;padding:10px 10px;" id="div_agent" runat="server">
                <div class="row">
                    
                    <div class="col-md-4 col-xl-4">
                        <div class="row  d-flex justify-content-center" id="Div9" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_appeal" runat="server" Text="Appeal No :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_appeal_no" CssClass="form-control" runat="server" autocomplete="off" onkeypress='datevalidate(event)' ></asp:TextBox>
                            </div>
                        </div>
                    </div>

                     <div class="col-md-4 col-xl-4">
                         <div class="row  d-flex justify-content-center" id="Div10" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_agent_orders" runat="server" Text="Date of orders :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                              
                            <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="txt_agent_dt_orders" data-link-format="dd/mm/yyyy">
                                        <asp:TextBox ID="txt_agent_dt_orders" name="txt_ltrpdate" runat="server" class="form-control" placeholder="dd/mm/yyyy" autocomplete="off"  ></asp:TextBox>
					                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                    </div>
                                
                                 </div>
                        </div>
                     </div>

                     <div class="col-md-4 col-xl-4">
                         <div class="row  d-flex justify-content-center" id="Div19" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label23" runat="server" Text="Date of Disposal:"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                              
                            <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="txt_agent_dt_orders" data-link-format="dd/mm/yyyy">
                                        <asp:TextBox ID="txt_agent_disposal" name="txt_ltrpdate" runat="server" class="form-control" placeholder="dd/mm/yyyy" autocomplete="off"  ></asp:TextBox>
					                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                    </div>
                                
                                 </div>
                        </div>
                     </div>
                </div>
                    <div class="row mt-2 mb-2 text-left">

                    <div class="col-md-2 title"><asp:Label ID="Label21" runat="server" Text="Agent:"></asp:Label></div>
                    
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddl_agent" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_agent_SelectedIndexChanged">
                          <asp:ListItem Value="1">SELECT</asp:ListItem>
                              <asp:ListItem Value="ALLOWED">ALLOWED</asp:ListItem>
                            <asp:ListItem Value="DISALLOWED">DISALLOWED</asp:ListItem>
                            <asp:ListItem Value="REMANDED">REMANDED</asp:ListItem>
                        </asp:DropDownList>
                    </div>


                    

                   <%-- <div class="col-md-2">
                        <div class="form-check">
                            <input class="form-check-input" type="checkbox" value="" id="defaultCheck2">
                            <label class="form-check-label" for="defaultCheck2">
                                Fully
                            </label>
                        </div>
                    </div>--%>

                </div>

                <div class="row mt-2 mb-2 text-left" id="div_agent_option" runat="server">

                    <div class="col-md-2 title" ><asp:Label ID="lbl_agent_orders_passed" runat="server" Text="Orders Passed in whose Favour:"></asp:Label></div>

                    <div class="col-md-2" id="div_agent_allowed" runat="server">
                       
<%--                            <asp:CheckBoxList ID="Chk_agent_order_passed" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Partially</asp:ListItem>
                                <asp:ListItem>Fully</asp:ListItem>
                            </asp:CheckBoxList>--%>

                        <asp:RadioButtonList ID="rbtn_agent" runat="server" RepeatDirection="Horizontal" Height="16px" Width="205px" OnSelectedIndexChanged="rbtn_agent_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="A">Partially</asp:ListItem>
                            <asp:ListItem Value="B">Fully</asp:ListItem>
                            </asp:RadioButtonList>
                       
                    </div>

                   <%-- <div class="col-md-2">
                        <div class="form-check">
                            <input class="form-check-input" type="checkbox" value="" id="defaultCheck2">
                            <label class="form-check-label" for="defaultCheck2">
                                Fully
                            </label>
                        </div>
                    </div>--%>
                     <div class="col-md-3"  id="div_agent_disallowed" runat="server">
                        <asp:RadioButtonList ID="rbtn_agent_disallowed" runat="server" RepeatDirection="Horizontal" Height="16px" Width="100%"  AutoPostBack="true">
                            <asp:ListItem Value="A">On Full trial</asp:ListItem>
                            <asp:ListItem Value="B">Resjudicated/Dropped</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>

                    <div class="col-md-5"  id="div_agent_remanded" runat="server">
                        <asp:RadioButtonList ID="rbtn_agent_remanded" runat="server" RepeatDirection="Horizontal" Height="16px" Width="100%"  AutoPostBack="true" >
                           <%-- <asp:ListItem Value="A">Additional Agent</asp:ListItem>
                            <asp:ListItem Value="B">Government</asp:ListItem>
                            <asp:ListItem Value="C">High Court</asp:ListItem>--%>
                             <asp:ListItem Value="D">SDC</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>

                </div>
                <div class="col-md-12 mb-2 mt-2" id="div_agent_partially" runat="server">
                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_nt" runat="server" Text="Non Tribal" OnCheckedChanged="rbtn_nt_CheckedChanged" AutoPostBack="true" />
                        
                 

                    </div>
                     <div id="div_agent_nt_txt" class="col-md-10" runat="server">
                    <div class="row">
                    <div class="col-md-2"> <asp:Label ID="lbl_nt_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_nt_name" runat="server"  CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_nt_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_nt_extent" runat="server"  CssClass="form-control" onkeypress="return isDecimalNumber(event,this);" autocomplete="off"></asp:TextBox>
                    </div>
                        </div></div>
                </div>

                <div class="row mt-2 mb-2 text-left" id="div_agent_tri" runat="server">
                    <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_tribal" runat="server" Text="Tribal" OnCheckedChanged="rbtn_tribal_CheckedChanged" AutoPostBack="true" />
                        
                 

                    </div>
                      <div id="div_agent_tri_txt" class="col-md-10" runat="server">
                    <div class="row">
                    <div class="col-md-2"> <asp:Label ID="lbl_tri_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_tri_name" runat="server"  CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_tri_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_tri_extent" runat="server"  CssClass="form-control" onkeypress="return isDecimalNumber(event,this);" autocomplete="off"></asp:TextBox>
                    </div>
                        </div>
                           <div class="row mt-2">
                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbtn_agent_tri_impl" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Value="A">Orders Implemented</asp:ListItem>
                                    <asp:ListItem Value="B">Available for Implementation</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                     </div>
                      </div>
                </div>

                <div class="row mt-2 mb-2 text-left" id="div_agent_gov" runat="server">
                   <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_agent_gov" runat="server" Text="Government" OnCheckedChanged="rbtn_agent_gov_CheckedChanged"  AutoPostBack="true"/>
                        
                 

                    </div>
                      <div id="div_agent_gov_txt" class="col-md-10" runat="server">
                    <div class="row">
                    <div class="col-md-2"> <asp:Label ID="lbl_gov_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_gov_name" runat="server"  CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_gov_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_gov_extent" runat="server"  CssClass="form-control" autocomplete="off" onkeypress="return isDecimalNumber(event,this);"></asp:TextBox>
                    </div>
                        </div>
                           <div class="row mt-2">
                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbtn_agent_gov_impl" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Value="A">Orders Implemented</asp:ListItem>
                                    <asp:ListItem Value="B">Available for Implementation</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                     </div>
                      </div>
                    </div>
                </div>


                   <%--   <div class="col-md-12 mb-2 mt-2">
                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Non Tribal" />
                        
                 

                    </div>
                    <div class="col-md-2"> <asp:Label ID="Label2" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox3" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="TextBox5" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Tribal" />
                        
                 

                    </div>
                    <div class="col-md-2"> <asp:Label ID="Label5" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox16" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label10" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="TextBox17" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-2 mb-2 text-left">
                   <div class="col-md-2">
                        <asp:RadioButton ID="RadioButton3" runat="server" Text="Government" />
                        
                 

                    </div>
                    <div class="col-md-2"> <asp:Label ID="Label33" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox18" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label34" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="TextBox19" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    </div>
                </div>--%>

                    <div class="row mb-2 text-left justify-content-left  title">
                        <div class="col-md-2">

                            <asp:Label ID="Label2" runat="server" Text="RDO/SDC orders:" CssClass="col-form-label">
                              <%--  <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>--%></asp:Label>

                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txt_collector_po_doc" runat="server" autocomplete="off" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <%--<div class="col-md-2">
                            <asp:Label ID="Label12" runat="server" Text="" class=""></asp:Label>
                        </div>--%>
                        <div class="custom-file col-md-2">
                            <%-- <input id="File_rdo" type="file" name="rdo/sdc" onchange="show(this)" runat="server" />--%>

                            <asp:FileUpload ID="file_collector" runat="server" AllowMultiple="true" />

                            
                        </div>

                        <div class="custom-file col-md-2">
                            <asp:Button ID="btn_agent_upload" runat="server" Text="Upload" OnClick="btn_agent_upload_Click" />
                        </div>


                    </div>
                    
                <%--    <div class="row mb-2 text-left justify-content-left  title">
                        <asp:Label ID="Label12" runat="server" Text="RDO/SDC orders:" CssClass="col-md-2 col-form-label"></asp:Label>
                        <asp:TextBox ID="txt_collector_po_doc" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-2"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        <div class="custom-file col-md-2">
                            <input id="file_collector_po" type="file" name="file" onchange="collectorshow(this)" runat="server" />
                            <%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                         <%--</div>
                    </div>--%>




                <div class="row mt-2 mb-2 justify-content-left">

                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label12" runat="server" Text="Case Status"></asp:Label>

                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList ID="ddl_agent_status" runat="server">
                                    <asp:ListItem>SELECT</asp:ListItem>
                                    <asp:ListItem>PENDING</asp:ListItem>
                                    <asp:ListItem>DISPOSED</asp:ListItem>
                                </asp:DropDownList>

                               
                            </div>
                        </div>
                    </div>
                   
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-left">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_agent_remarks" runat="server" Text="Remarks:"></asp:Label>
                                <%--<span style="color: red">*</span>--%>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_agent_remarks" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)' class="form-control"></asp:TextBox>


                            </div>
                        </div>
                    </div>



                </div>
                </div>


                  <%--  Government--%>


                 <div class="row text-left  title  mt-2 mb-2">
                       <asp:CheckBox ID="chk_government" runat="server"  AutoPostBack="true" OnCheckedChanged="chk_government_CheckedChanged"/>
                        <asp:Label ID="lbl_gov" CssClass="text-info" runat="server" Text="Government(Revision):"></asp:Label>
                 </div>

                <div style="background:#eee; border-radius:5px;padding:10px 10px;" id="div_gov" runat="server">
                <div class="row">
                    
                    <div class="col-md-4 col-xl-4">
                        <div class="row  d-flex justify-content-center" id="Div11" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_rpno" runat="server" Text="R.P.No :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_rpno" runat="server" autocomplete="off" onkeypress='datevalidate(event)' ></asp:TextBox>
                            </div>
                        </div>
                    </div>

                     <div class="col-md-4 col-xl-4">
                         <div class="row  d-flex justify-content-center" id="Div12" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_gov_dt_orders" runat="server" Text="Date of orders :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                 <%--<asp:TextBox ID="txt_gov_dt_orders" runat="server" onkeypress='datevalidate(event)' MaxLength="10"></asp:TextBox>--%>
                                
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagesnew/calenderimage.png" CssClass="calender-button" OnClick="ImageButton1_Click" data-toggle="modal" data-target="#exampleModal"/>--%>
                                
                               

                                <%--<img src="../imagesnew/calenderimage.png"  data-toggle="modal" data-target="#exampleModal3" class="calender-button"/>--%>
                             <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="txt_gov_dt_orders" data-link-format="dd/mm/yyyy">
                                        <asp:TextBox ID="txt_gov_dt_orders"  runat="server" class="form-control" placeholder="dd/mm/yyyy" autocomplete="off"  ></asp:TextBox>
					                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                    </div>
                                
                                 </div>
                        </div>
                     </div>

                     <div class="col-md-4 col-xl-4">
                         <div class="row  d-flex justify-content-center" id="Div20" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label24" runat="server" Text="Date of Disposal :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                              
                             <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="txt_gov_dt_orders" data-link-format="dd/mm/yyyy">
                                        <asp:TextBox ID="txt_gov_disposal"  runat="server" class="form-control" placeholder="dd/mm/yyyy" autocomplete="off"  ></asp:TextBox>
					                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                    </div>
                                
                                 </div>
                        </div>
                     </div>
                </div>
                      <div class="row mt-2 mb-2 text-left">

                    <div class="col-md-2 title"><asp:Label ID="Label19" runat="server" Text="Revision:"></asp:Label></div>
                    
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddl_gov" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_gov_SelectedIndexChanged">
                             <asp:ListItem Value="1">SELECT</asp:ListItem>
                            <asp:ListItem Value="ALLOWED">ALLOWED</asp:ListItem>
                            <asp:ListItem Value="DISALLOWED">DISALLOWED</asp:ListItem>
                            <asp:ListItem Value="REMANDED">REMANDED</asp:ListItem>
                        </asp:DropDownList>
                    </div>


                    

                   <%-- <div class="col-md-2">
                        <div class="form-check">
                            <input class="form-check-input" type="checkbox" value="" id="defaultCheck2">
                            <label class="form-check-label" for="defaultCheck2">
                                Fully
                            </label>
                        </div>
                    </div>--%>

                </div>
                <div class="row mt-2 mb-2 text-left" id="div_gov_option" runat="server">

                    <div class="col-md-2 title"><asp:Label ID="lbl_gov_orders_passed" runat="server" Text="Orders passed in whose favour:"></asp:Label></div>

                    <div class="col-md-2" id="div_gov_allowed" runat="server">
                       
<%--                            <asp:CheckBoxList ID="Chk_agent_order_passed" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Partially</asp:ListItem>
                                <asp:ListItem>Fully</asp:ListItem>
                            </asp:CheckBoxList>--%>

                        <asp:RadioButtonList ID="rbtn_gov_orders_passed" runat="server" RepeatDirection="Horizontal" Height="16px" Width="205px"  AutoPostBack="true" OnSelectedIndexChanged="rbtn_gov_orders_passed_SelectedIndexChanged">
                            <asp:ListItem Value="A">Partially</asp:ListItem>
                            <asp:ListItem Value="B">Fully</asp:ListItem>
                            </asp:RadioButtonList>
                       
                    </div>
                      <div class="col-md-3" id="div_gov_disallowed" runat="server">
                        <asp:RadioButtonList ID="rbtn_gov_disallowed" runat="server" RepeatDirection="Horizontal" Height="16px" Width="100%"  AutoPostBack="true" >
                            <asp:ListItem Value="A">On Full trial</asp:ListItem>
                            <asp:ListItem Value="B">Resjudicated/Dropped</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>

                    <div class="col-md-5" id="div_gov_remanded" runat="server">
                        <asp:RadioButtonList ID="rbtn_gov_remanded" runat="server" RepeatDirection="Horizontal" Height="16px" Width="100%"  AutoPostBack="true" >
                            <asp:ListItem Value="A">Additional Agent</asp:ListItem>
                            <asp:ListItem Value="B">Agent to Government</asp:ListItem>
                            <%--<asp:ListItem Value="C">High Court</asp:ListItem>--%>
                            <asp:ListItem Value="D">SDC</asp:ListItem>

                            </asp:RadioButtonList>
                    </div>
                   <%-- <div class="col-md-2">
                        <div class="form-check">
                            <input class="form-check-input" type="checkbox" value="" id="defaultCheck2">
                            <label class="form-check-label" for="defaultCheck2">
                                Fully
                            </label>
                        </div>
                    </div>--%>

                </div>
                <div class="col-md-12 mb-2 mt-2" id="div_gov_partially" runat="server">
                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_gov_nt" runat="server" Text="Non Tribal"  AutoPostBack="true" OnCheckedChanged="rbtn_gov_nt_CheckedChanged"/>
                        
                 

                    </div>
                      <div id="div_gov_nt_txt" class="col-md-10" runat="server">
                    <div class="row">
                    <div class="col-md-2"> <asp:Label ID="lbl_gov_nt_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_gov_nt_name" runat="server"  CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_gov_nt_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_gov_nt_extent" runat="server"  CssClass="form-control" onkeypress="return isDecimalNumber(event,this);" autocomplete="off"></asp:TextBox>
                    </div>
                        </div></div>
                </div>

                <div class="row mt-2 mb-2 text-left" id="div_gov_tri" runat="server">
                    <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_gov_tri" runat="server" Text="Tribal"  AutoPostBack="true" OnCheckedChanged="rbtn_gov_tri_CheckedChanged"/>
                        
                 

                    </div>
                      <div id="div_gov_tri_txt" class="col-md-10" runat="server">
                    <div class="row">
                    <div class="col-md-2"> <asp:Label ID="lbl_gov_tri_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_gov_tri_name" runat="server"  CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_gov_tri_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_gov_tri_extent" runat="server"  CssClass="form-control" onkeypress="return isDecimalNumber(event,this);" autocomplete="off"></asp:TextBox>
                    </div>
                        </div>
                           <div class="row mt-2">
                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbtn_gov_tri_impl" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Value="A">Orders Implemented</asp:ListItem>
                                    <asp:ListItem Value="B">Available for Implementation</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                     </div>


                      </div>
                </div>

                <div class="row mt-2 mb-2 text-left" id="div_gov_gov" runat="server">
                   <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_gov_gov" runat="server" Text="Government" AutoPostBack="true" OnCheckedChanged="rbtn_gov_gov_CheckedChanged" />
                        
                 

                    </div>
                      <div id="div_gov_gov_txt" class="col-md-10" runat="server">
                    <div class="row">
                    <div class="col-md-2"> <asp:Label ID="lbl_gov_gov_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_gov_gov_name" runat="server"  CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_gov_gov_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_gov_gov_extent" runat="server"  CssClass="form-control" autocomplete="off" onkeypress="return isDecimalNumber(event,this);"></asp:TextBox>
                    </div>
                    </div>
                           <div class="row mt-2">
                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbtn_gov_impl" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Value="A">Orders Implemented</asp:ListItem>
                                    <asp:ListItem Value="B">Available for Implementation</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                     </div>
                          </div></div>
                </div>


                   <%--   <div class="col-md-12 mb-2 mt-2">
                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Non Tribal" />
                        
                 

                    </div>
                    <div class="col-md-2"> <asp:Label ID="Label2" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox3" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="TextBox5" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Tribal" />
                        
                 

                    </div>
                    <div class="col-md-2"> <asp:Label ID="Label5" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox16" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label10" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="TextBox17" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-2 mb-2 text-left">
                   <div class="col-md-2">
                        <asp:RadioButton ID="RadioButton3" runat="server" Text="Government" />
                        
                 

                    </div>
                    <div class="col-md-2"> <asp:Label ID="Label33" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox18" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label34" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="TextBox19" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    </div>
                </div>--%>

                      <div class="row mb-2 text-left justify-content-left  title">
                          <div class="col-md-2">
                              <asp:Label ID="Label15" runat="server" Text="Collector/PO ITDA orders:" CssClass="col-form-label">
                              <%--  <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>--%></asp:Label>
                          </div>
                          <div class="col-md-2">
                              <asp:TextBox ID="txt_govt_doc" runat="server" autocomplete="off"  CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                          </div>
                          <%--<div class="col-md-2">
                              <asp:Label ID="Label17" runat="server" Text=""></asp:Label>
                          </div>--%>
                            <div class="custom-file col-md-2">
                                <%-- <input id="File_rdo" type="file" name="rdo/sdc" onchange="show(this)" runat="server" />--%>

                                 <asp:FileUpload ID="File_gov" runat="server" AllowMultiple="true"  />
                            </div>
                            <div class="custom-file col-md-2">
                               <asp:Button ID="btn_gov_upload" runat="server" Text="Upload" OnClick="btn_gov_upload_Click" />
                            </div>


                        </div>
                    
               <%-- <div class="row mb-2 text-left justify-content-left  title">
                        
                     <asp:Label ID="Label14" runat="server" Text="Collector/PO ITDA orders:" CssClass="col-md-2 col-form-label"></asp:Label>
                            <asp:TextBox ID="txt_govt_doc" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-2"></asp:TextBox>
                              <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                            <div class="custom-file col-md-2">
                                <input id="file_govt" type="file" name="file" onchange="Govshow(this)" runat="server" />
                                <%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                            <%-- </div>

                        </div>--%>




                <div class="row mt-2 mb-2 justify-content-left">
                      <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label16" runat="server" Text="Case Status"></asp:Label>

                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList ID="ddl_gov_status" runat="server">
                                    <asp:ListItem>SELECT</asp:ListItem>
                                    <asp:ListItem>PENDING</asp:ListItem>
                                    <asp:ListItem>DISPOSED</asp:ListItem>
                                </asp:DropDownList>

                               
                            </div>
                        </div>
                    </div>
                   
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-left">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_gov_remarks" runat="server" Text="Remarks:"></asp:Label>
                                <%--<span style="color: red">*</span>--%>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_gov_remarks" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)' class="form-control"></asp:TextBox>


                            </div>
                        </div>
                    </div>



                </div>
                </div>

               
                 <%--  High court--%>


              
                  <div class="row text-left  title  mt-2 mb-2">
                       <asp:CheckBox ID="chk_high_court" runat="server"  AutoPostBack="true" OnCheckedChanged="chk_high_court_CheckedChanged"/>
                        <asp:Label ID="lbl_high_court" CssClass="text-info" runat="server" Text="High Court:"></asp:Label>
                 </div>

                <div style="background:#eee; border-radius:5px;padding:10px 10px;" id="div_high_court" runat="server">
                <div class="row">
                    
                    <div class="col-md-4 col-xl-4">
                        <div class="row  d-flex justify-content-center" id="Div15" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_wpno" runat="server" Text="W.P.No :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_wpno" runat="server" autocomplete="off" onkeypress='datevalidate(event)' ></asp:TextBox>
                            </div>
                        </div>
                    </div>

                     <div class="col-md-4 col-xl-4">
                         <div class="row  d-flex justify-content-center" id="Div16" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_hc_dt_orders" runat="server" Text="Date of orders :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                 <%--<asp:TextBox ID="txt_hc_dt_orders" runat="server" onkeypress='datevalidate(event)' MaxLength="10"></asp:TextBox>--%>
                                
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagesnew/calenderimage.png" CssClass="calender-button" OnClick="ImageButton1_Click" data-toggle="modal" data-target="#exampleModal"/>--%>
                                
                               

                               <%-- <img src="../imagesnew/calenderimage.png"  data-toggle="modal" data-target="#exampleModal4" class="calender-button"/>--%>
                            
                              <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="txt_hc_dt_orders" data-link-format="dd/mm/yyyy">
                                        <asp:TextBox ID="txt_hc_dt_orders"  runat="server" class="form-control" placeholder="dd/mm/yyyy" autocomplete="off"  ></asp:TextBox>
					                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                    </div>
                            </div>
                        </div>
                     </div>

                    <div class="col-md-4 col-xl-4">
                         <div class="row  d-flex justify-content-center" id="Div21" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label25" runat="server" Text="Date of Disposal :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                               
                            
                              <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="txt_hc_dt_orders" data-link-format="dd/mm/yyyy">
                                        <asp:TextBox ID="txt_hc_disposal"  runat="server" class="form-control" placeholder="dd/mm/yyyy" autocomplete="off"  ></asp:TextBox>
					                    <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                                    </div>
                            </div>
                        </div>
                     </div>
                </div>
                    <br />
                      <div class="row">
                    
                    <div class="col-md-4 col-xl-4">
                        <div class="row  d-flex justify-content-center" id="Div22" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label13" runat="server" Text="W.P.MP.No :"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_wp_mpno" runat="server" autocomplete="off"  ></asp:TextBox>
                            </div>
                        </div>
                    </div>

                     <div class="col-md-4 col-xl-4">
                         <div class="row  d-flex justify-content-center" id="Div23" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label26" runat="server" Text="W.P.MP.No  Status"></asp:Label>
                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList ID="ddl_wpno_status" runat="server">
                                    <asp:ListItem>SELECT</asp:ListItem>
                                    <asp:ListItem>STAY</asp:ListItem>
                                    <asp:ListItem>INTERM SUSPENSION</asp:ListItem>
                                    <asp:ListItem>STATUSCO</asp:ListItem>
                                </asp:DropDownList>
                                
                             
                            </div>
                        </div>
                     </div>

                  
                </div>

                <div class="row mt-2 mb-2 text-left">

                    <div class="col-md-2 title"><asp:Label ID="lbl_hc_orders_passed" runat="server" Text="Writ Petition:"></asp:Label></div>
                    
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddl_hc" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_hc_SelectedIndexChanged" CssClass="form-control">
                             <asp:ListItem Value="1">SELECT</asp:ListItem>
                            <asp:ListItem Value="ALLOWED">ALLOWED</asp:ListItem>
                            <asp:ListItem Value="DISALLOWED">DISALLOWED</asp:ListItem>
                            <asp:ListItem Value="REMANDED">REMANDED</asp:ListItem>
                        </asp:DropDownList>
                    </div>


                    

                   <%-- <div class="col-md-2">
                        <div class="form-check">
                            <input class="form-check-input" type="checkbox" value="" id="defaultCheck2">
                            <label class="form-check-label" for="defaultCheck2">
                                Fully
                            </label>
                        </div>
                    </div>--%>

                </div>

                <div class="row text-left" id="div_hc_option" runat="server">
                    <div class="col-md-2 title"><asp:Label ID="Lbl_hc" runat="server" Text="Orders Passed in whose Favour:"></asp:Label></div>
                    
                    
                    <div class="col-md-2" id="div_hc_allowed" runat="server">
                        <asp:RadioButtonList ID="rbtn_hc_orders_passed" runat="server" RepeatDirection="Horizontal" Height="16px" Width="100%"  AutoPostBack="true" OnSelectedIndexChanged="rbtn_hc_orders_passed_SelectedIndexChanged">
                            <asp:ListItem Value="A">Partially</asp:ListItem>
                            <asp:ListItem Value="B">Fully</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>

                    <div class="col-md-3" id="div_hc_disallowed" runat="server">
                        <asp:RadioButtonList ID="rbtn_hc_disallowed" runat="server" RepeatDirection="Horizontal" Height="16px" Width="100%"  AutoPostBack="true" >
                            <asp:ListItem Value="A">On Full trial</asp:ListItem>
                            <asp:ListItem Value="B">Resjudicated/Dropped</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>

                    <div class="col-md-5" id="div_hc_remanded" runat="server">
                        <asp:RadioButtonList ID="rbtn_hc_remanded" runat="server" RepeatDirection="Horizontal" Height="16px" Width="100%"  AutoPostBack="true">
                            <asp:ListItem Value="A">Additional Agent</asp:ListItem>
                            <asp:ListItem Value="B">Agent to Government</asp:ListItem>
                            <asp:ListItem Value="C">Government</asp:ListItem>
                              <asp:ListItem Value="D">SDC</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-md-12 mb-2 mt-2" id="div_high_court_partially" runat="server">
                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_hc_nt" runat="server" Text="Non Tribal" AutoPostBack="true" OnCheckedChanged="rbtn_hc_nt_CheckedChanged" />
                        
                 

                    </div>
                      <div id="div_hc_nt_txt" class="col-md-10" runat="server">
                    <div class="row">
                    <div class="col-md-2"> <asp:Label ID="lbl_hc_nt_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_hc_nt_name" runat="server"  CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_hc_nt_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_hc_nt_extent" runat="server"  CssClass="form-control" onkeypress="return isDecimalNumber(event,this);"></asp:TextBox>
                    </div></div></div>
                </div>

                <div class="row mt-2 mb-2 text-left" id="div_hc_tri" runat="server">
                    <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_hc_tri" runat="server" Text="Tribal" AutoPostBack="true" OnCheckedChanged="rbtn_hc_tri_CheckedChanged" />
                        
                 

                    </div>
                      <div id="div_hc_tri_txt" class="col-md-10" runat="server">
                    <div class="row">
                    <div class="col-md-2"> <asp:Label ID="lbl_hc_tri_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_hc_tri_name" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_hc_tri_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_hc_tri_extent" runat="server"  CssClass="form-control" onkeypress="return isDecimalNumber(event,this);"></asp:TextBox>
                    </div></div>

                    <div class="row mt-2">
                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbtn_hc_tri_orders_impl" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Value="A">Orders Implemented</asp:ListItem>
                                    <asp:ListItem Value="B">Available for Implementation</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                     </div>


                      </div>

                   
                </div>

                <div class="row mt-2 mb-2 text-left" id="div_hc_gov" runat="server">
                   <div class="col-md-2">
                        <asp:RadioButton ID="rbtn_hc_gov" runat="server" Text="Government"  AutoPostBack="true" OnCheckedChanged="rbtn_hc_gov_CheckedChanged"/>
                    </div>  
                    <div id="div_hc_gov_txt" class="col-md-10" runat="server">
                    <div class="row">
                    <div class="col-md-2"> <asp:Label ID="lbl_hc_gov_name" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_hc_gov_name" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="lbl_hc_gov_extent" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="txt_hc_gov_extent" runat="server"  CssClass="form-control" onkeypress="return isDecimalNumber(event,this);" autocomplete="off"></asp:TextBox>
                    </div>
                        </div>

                    <div class="row mt-2">
                            <div class="col-md-6">
                                <asp:RadioButtonList ID="rbtn_hc_orders_impl" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Value="A">Orders Implemented</asp:ListItem>
                                    <asp:ListItem Value="B">Available for Implementation</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            
                     </div>
                    </div>
                    </div>
                </div>


                   <%--   <div class="col-md-12 mb-2 mt-2">
                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Non Tribal" />
                        
                 

                    </div>
                    <div class="col-md-2"> <asp:Label ID="Label2" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox3" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label3" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="TextBox5" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-2 mb-2 text-left">
                    <div class="col-md-2">
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Tribal" />
                        
                 

                    </div>
                    <div class="col-md-2"> <asp:Label ID="Label5" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox16" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label10" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="TextBox17" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mt-2 mb-2 text-left">
                   <div class="col-md-2">
                        <asp:RadioButton ID="RadioButton3" runat="server" Text="Government" />
                        
                 

                    </div>
                    <div class="col-md-2"> <asp:Label ID="Label33" runat="server" Text="Enter Name:"></asp:Label></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox18" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2"><asp:Label ID="Label34" runat="server" Text="Enter Extent:"></asp:Label></div>
                    <div class="col-md-2">
                      <asp:TextBox ID="TextBox19" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    </div>
                </div>--%>
                    
                       <div class="row mb-2 text-left justify-content-left  title">
                            <div class="col-md-2">
                               <asp:Label ID="Label6" runat="server" Text="Lowercourt Orders/Notice/New Petition:" CssClass="col-form-label">
                              <%--  <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>--%></asp:Label>
                             </div>
                           <div class="col-md-2">
                               <asp:TextBox ID="txt_high_court_doc" runat="server" autocomplete="off"  CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            
                           </div>
                           
                           <asp:Label ID="Label14" runat="server" Text=""></asp:Label>
                            <div class="custom-file col-md-2">
                                <%-- <input id="File_rdo" type="file" name="rdo/sdc" onchange="show(this)" runat="server" />--%>

                                 <asp:FileUpload ID="File_highcourt" runat="server" AllowMultiple="true"  />
                            </div>
                            <div class="custom-file col-md-2">
                                <asp:Button ID="btn_high_upload" runat="server" Text="Upload" OnClick="btn_high_upload_Click" />
                            </div>


                        </div>
             <%--   <div class="row mb-2 text-left justify-content-left  title">
                           
                     <asp:Label ID="Label16" runat="server" Text="Lowercourt Orders/Notice/New Petition:" CssClass="col-md-3 col-form-label"></asp:Label>
                            <asp:TextBox ID="txt_high_court_doc" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-2"></asp:TextBox>
                            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                            <div class="custom-file col-md-2">
                                <input id="file_high_court" type="file" name="file" onchange="highshow(this)" runat="server" />
                                <%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" /> OnClientClick="return  validation()" --%>
                            <%--</div>

                        </div>
--%>



                <div class="row mt-2 mb-2 justify-content-left">
                      <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Label17" runat="server" Text="Case Status"></asp:Label>

                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList ID="ddl_hc_status" runat="server">
                                    <asp:ListItem>SELECT</asp:ListItem>
                                    <asp:ListItem>PENDING</asp:ListItem>
                                    <asp:ListItem>DISPOSED</asp:ListItem>
                                </asp:DropDownList>

                               
                            </div>
                        </div>
                    </div>
                   
                    <div class="col-md-4">
                        <div class="row  d-flex justify-content-left">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_hc_remarks" runat="server" Text="Remarks:"></asp:Label>
                                <%--<span style="color: red">*</span>--%>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_hc_remarks" runat="server" autocomplete="off" onkeypress='pattadarnamevalidate(event)' class="form-control"></asp:TextBox>


                            </div>
                        </div>
                    </div>



                </div>
                </div>





               <%-- land purpose--%>

                


                <div class="row mb-2">
                    <div class="col-md-12">
                        <asp:GridView runat="server" ID="gvFiles" AutoGenerateColumns="false"
                            OnRowCancelingEdit="OnRowCancelingEdit" OnRowDeleting="OnRowDeleting"
                            OnRowEditing="OnRowEditing" OnRowUpdating="OnRowUpdating" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="4">
                            <Columns>
                              <%--  <asp:CommandField ShowEditButton="true" ControlStyle-Font-Underline="true" />
                                <asp:CommandField ShowDeleteButton="true" ControlStyle-Font-Underline="true" />
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" Text='<%#Eval("Sno") %>' runat="server" />


                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEditId" Text='<%#Eval("Sno") %>' runat="server" />
                                        <asp:Label ID="lblfileid" Text='<%#Eval("Sno") %>' runat="server" />
                                    </EditItemTemplate>
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="File Path" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                         
               <asp:Label ID="lblpath" Text='<%#Eval("RDO_PATH") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField> --%>
                                  <asp:TemplateField HeaderText="S.no">
                                    <ItemTemplate>
                                        <asp:Label ID="Id" Text='<%#Container.DataItemIndex+1 %>' runat="server" />
                                    </ItemTemplate>
                                      </asp:TemplateField>
                                <asp:TemplateField HeaderText="Files">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFile" Text='<%#Eval("RDO_FILENAME") %>' runat="server" />
                                    </ItemTemplate>
                                  <%--  <EditItemTemplate>
                                        <asp:FileUpload ID="fuEditFile" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvEditFile" ErrorMessage="Required" ControlToValidate="fuEditFile"
                                            runat="server" ForeColor="Red" Display="Dynamic" />
                                        <asp:RegularExpressionValidator ID="revEditFile" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.doc|.jpg|.pdf)$"
                                            ControlToValidate="fuEditFile" runat="server" ForeColor="Red" ErrorMessage="Please select only jpg/doc/pdf file."
                                            Display="Dynamic" />
                                        &nbsp;<asp:Label ID="lblEditFile" Text='<%#Eval("RDO_FILENAME") %>' runat="server" />
                                    </EditItemTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="view_file" CommandArgument='<%#Eval("Sno") %>' runat="server" Font-Underline="true" Width="75" OnClick="Linkview_Click">View</asp:LinkButton>

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
                </div>


                 </div>
             
            
             <div class="row mb-2 justify-content-center">

                    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" OnClientClick="return validation();"  />&nbsp&nbsp
                    <asp:Button ID="btn_reset" runat="server" Text="Reset" OnClick="btn_reset_Click" />
                </div>
          
        </div>

                </div>
  </ContentTemplate>
          <Triggers>
        <asp:PostBackTrigger ControlID="btn_sdc_upload" />
        <asp:PostBackTrigger ControlID="btn_rdo_upload" />
        <asp:PostBackTrigger ControlID="btn_agent_upload" />
         <asp:PostBackTrigger ControlID="btn_gov_upload" />
         <asp:PostBackTrigger ControlID="btn_high_upload" />
    </Triggers>
        </asp:UpdatePanel>
  
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

<script type="text/javascript" src="../date/jquery/jquery-1.8.3.min.js" charset="UTF-8"></script>
<script type="text/javascript" src="../date/bootstrap/js/bootstrap.min.js"></script>
<script type="text/javascript" src="../date/js/bootstrap-datetimepicker.js" charset="UTF-8"></script>
<script type="text/javascript" src="../date/js/locales/bootstrap-datetimepicker.fr.js" charset="UTF-8"></script>
<script type="text/javascript">
    $('.form_datetime').datetimepicker({
        //language:  'fr',
        weekStart: 1,
        todayBtn:  1,
		autoclose: 1,
		todayHighlight: 1,
		startView: 2,
		forceParse: 0,
        showMeridian: 1
    });
	$('.form_date').datetimepicker({
        language:  'en',
        weekStart: 1,
        todayBtn:  1,
		autoclose: 1,
		todayHighlight: 1,
		startView: 2,
		minView: 2,
		forceParse: 0,
		format: 'dd/mm/yyyy'
    });
	$('.form_time').datetimepicker({
        language:  'en',
        weekStart: 1,
        todayBtn:  1,
		autoclose: 1,
		todayHighlight: 1,
		startView: 1,
		minView: 0,
		maxView: 1,
		forceParse: 0
    });
</script>

</asp:Content>
