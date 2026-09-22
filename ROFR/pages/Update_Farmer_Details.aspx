<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Update_Farmer_Details.aspx.cs" Inherits="ROFR.pages.Update_Farmer_Details"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <%--   <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>--%>
    <script src="../linksforcdns/Js/jquery.min.js"></script>
     <script>
        var pattano;
        function pattachange(event)
        {
            pattano = document.getElementById('<%=txt_patta.ClientID %>').value;
            var sub = /^0+$/;
            //var starting_date = '00000000'
            if (pattano.match(sub)) {
                //document.getElementById('<%=txt_patta.ClientID %>').value == "";
                alert("Please enter valid Patta No. and value cannot be zero's");
                event.value = "";
                return false;
              //  document.getElementById('<%=txt_patta.ClientID %>').value == "";
            }

          
        }
    </script>
     
     <script>
        var spancmt;
        function cmtchange(event)
        {
            spancmt = document.getElementById('<%=txt_cno.ClientID %>').value;
            var subject = /^0+$/;
            //var starting_date = '00000000'
            if (spancmt.match(subject)) {
                //document.getElementById('<%=txt_cno.ClientID %>').value == "";
                alert("Please enter valid Compartment No. and value cannot be zero's");
                event.value = "";
                return false;
              //  document.getElementById('<%=txt_cno.ClientID %>').value == "";
            }

           else if (spancmt=="ORF"||spancmt=="ENCL" ||spancmt=="ENCLOSURE")
            {
           document.getElementById('<%=s_block.ClientID %>').style.display= 'none';
               //document.getElementById("s_block").style.display= 'none';
                return false;
            }
            else 
            {
                if( document.getElementById('<%=txt_block.ClientID %>').value=="")
                {
                    document.getElementById('<%=s_block.ClientID %>').style.display= 'block';
                    //alert("Please enter Block");
                    //document.getElementById("s_block").style.display= 'block';
                    return false;
                }
             <%--   if( document.getElementById('<%=txt_fblock.ClientID %>').value=="")
                {
                    document.getElementById('<%=s_block.ClientID %>').style.display= 'block';
                    //alert("Please enter Block");
                    //document.getElementById("s_block").style.display= 'block';
                    return false;
                }--%>

              
            }
        }
    </script>
   
      <script type="text/javascript">
         
    
        function validation()
        {
           
            var cno = document.getElementById('<%=txt_cno.ClientID %>').value;
            var patta = document.getElementById('<%=txt_patta.ClientID %>').value;
            var extent = document.getElementById('<%=txt_extent.ClientID %>').value;
           
        
            if (cno == "0") {

                alert("Please enter valid Compartment No.!");
                return false;
            }
            if (patta == "0") {

                alert("Please enter valid Patta No.!");
                return false;
            }
            if (extent == "0" || extent == "0.0" || extent == "0.00") {

                alert("Please enter valid Extent No.!");
                return false;
            }
			if (extent == "" || extent == null || extent == undefined)
            {
                alert("Please enter Extent");
                return false;
            }
            if (extent >10) {
                alert("Total Extent for Beneficiary should not be greater than 10 Acres!");
                return false;
            }
			
        }
        </script>
        <script type="text/javascript">

        function openModal() {
            $('#exampleModal').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }
      
    </script>
   
      <style>
   
  
    .font-telugu {
      font-family: 'Ramabhadra', sans-serif;
      text-shadow: 2px 2px rgba(0, 0, 0, 0.3);
      font-size: 30px;
    }
    

   
     .table th {
      text-align: center;
       background-color: #008500 !important;
    font-weight: 100 !important;
       }
  
  
  
    .bg-nav{
      background-color: #1F5C99 !important;
    }
   
  </style>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="panel panel-body">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <h5 class="text-center text-success mb-4 mt-3">UPDATE/VALIDATE FARMER LAND DETAILS</h5>
        
        <div class="row mb-2">
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="txt_Itda" runat="server" Text="ITDA Name:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                      
                    <asp:DropDownList ID="ddl_ITda" Style="width: 100%" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged"></asp:DropDownList>
                         </div>
                   
                </div>
            </div>
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="txt_district" runat="server" Text="District:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged"  runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="mandal_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label6" runat="server" Text="Mandal:"></asp:Label>&nbsp<asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_mandal" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="village_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label9" runat="server" Text="Village:"></asp:Label>&nbsp<asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_village" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>

          

  
            <br />
          
    </div> 
          <%--<div class="col-md-12 text-right" id="div_field" runat="server"><span style="color: red">Fields marked as * are mandatory</span></div>--%>

                
<br />
         
        
                                 <div class="row mb-6">
                                            <div class="table-responsive">
                                              
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"    CssClass="table text-center table-bordered "   >  
                 
<Columns>   
                        
                                       <asp:TemplateField HeaderText="S.NO" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl101"   Text='<%# Container.DataItemIndex + 1 %>' runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="SELECT" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                    
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true"  CommandArgument='<%#Eval("benficiary_id2") %>' CausesValidation="false" OnCheckedChanged="CheckBox1_CheckedChanged" />
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="BENEFICIARY ID" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                       <asp:Label ID="id"   Text='<%# Eval("id") %>'  runat="server"  ForeColor="Black" Visible="false"/>
                    <asp:Label ID="bid"   Text='<%# Eval("benficiary_id2") %>'  runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="FARMER NAME" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:left">
                  
              <asp:Label Class="txt"  ID="farmer" runat="server"   Text='<%# Eval("ROFR_PATTADAAR") %>' ForeColor="Black" ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                            
               <asp:TemplateField HeaderText="CULTIVATOR NAME" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:left">
                      
                    <asp:Label ID="cultivator"   Text='<%# Eval("CULTIVATOR_NAME") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         
          
                     <asp:TemplateField HeaderText="GRAM PANCHAYAT" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                      
                  <asp:Label ID="gp"  Text='<%# Eval("Gram_Panchayat") %>' runat="server" ForeColor="Black"/>
                       <asp:Label ID="gpcode"  Text='<%# Eval("Grama_Panchayat_Code") %>' runat="server" ForeColor="Black" Visible="false"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="REVENUE VILLAGE" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="rev_village"   Text='<%# Eval("REV_Village") %>' runat="server" ForeColor="Black"/>
            <asp:Label ID="rev_village_code"   Text='<%# Eval("Village_Revcode") %>' runat="server" ForeColor="Black" Visible="false"/>
                  </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="HABITATION" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="hab"   Text='<%# Eval("Habitation") %>' runat="server" ForeColor="Black"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
  
      <asp:TemplateField HeaderText="FOREST DIVISION" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                      <asp:Label ID="divisioncode"   Text='<%# Eval("Forest_DivisionCode") %>' runat="server" ForeColor="Black" Visible="false"/>
                 <asp:Label ID="division"   Text='<%# Eval("Forest_Division") %>' runat="server" ForeColor="Black"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 

     <asp:TemplateField HeaderText="FOREST RANGE" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                       <asp:Label ID="rangecode"  Text='<%# Eval("Forest_RangeCode") %>' runat="server" ForeColor="Black" Visible="false"/>
                 <asp:Label ID="range"  Text='<%# Eval("Forest_Range") %>' runat="server" ForeColor="Black"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
    <asp:TemplateField HeaderText="FOREST BEAT" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                       <asp:Label ID="beatcode"  Text='<%# Eval("Forest_BeatCode") %>' runat="server" ForeColor="Black" Visible="false"/>
                 <asp:Label ID="beat"  Text='<%# Eval("Forest_Beat") %>' runat="server" ForeColor="Black"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
     <asp:TemplateField HeaderText="FOREST BLOCK" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                       
                 <asp:Label ID="block"  Text='<%# Eval("Forest_Block") %>' runat="server" ForeColor="Black"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
      <asp:TemplateField HeaderText="COMPARTMENT NO" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                       
                 <asp:Label ID="cno"  Text='<%# Eval("Compartment_No") %>' runat="server" ForeColor="Black"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
    
      <asp:TemplateField HeaderText="PLOT NO" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                       
                 <asp:Label ID="plotno"  Text='<%# Eval("Plot_No") %>' runat="server" ForeColor="Black"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
    
    
      <asp:TemplateField HeaderText="PATTA NO" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                       
                 <asp:Label ID="pattano"  Text='<%# Eval("ROFR_PATTANO") %>' runat="server" ForeColor="Black"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
     <asp:TemplateField HeaderText="EXTENT PLOT AREA" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                       
                 <asp:Label ID="extent"  Text='<%# Eval("ExtentPlotArea") %>' runat="server" ForeColor="Black"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
    
       <asp:TemplateField HeaderText="CULTIVABLE LAND" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                       
                 <asp:Label ID="cult_land"  Text='<%# Eval("Cultivable_Land") %>' runat="server" ForeColor="Black"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
    
       <asp:TemplateField HeaderText="UNCULTIVABLE LAND" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                       
                 <asp:Label ID="uncult_land"  Text='<%# Eval("Uncultivable_Land") %>' runat="server" ForeColor="Black"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
       <asp:TemplateField HeaderText="PATTA INAM GOVT" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                       
                 <asp:Label ID="patta_inam"  Text='<%# Eval("PATTA_INAMGOVT") %>' runat="server" ForeColor="Black"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
     <asp:TemplateField HeaderText="HOLDING NATURE" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                       
                 <asp:Label ID="h_nature"  Text='<%# Eval("HOLDING_NATURE") %>' runat="server" ForeColor="Black"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="LAND CLASSIFICATION NAME" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                       
                 <asp:Label ID="land_class"  Text='<%# Eval("Land_Classification_Name") %>' runat="server" ForeColor="Black"/>

                       <asp:Label ID="water_tax"  Text='<%# Eval("Water_Tax") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="dry_id"  Text='<%# Eval("DRYID_ONECROP_TWO_CROP") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="water_source"  Text='<%# Eval("WATER_SOURCE") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="extent_irrigated"  Text='<%# Eval("EXTENT_IRRIGATED") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="extent_u_cult"  Text='<%# Eval("EXTENT_UNDER_CULTIVATOR") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="type_code"  Text='<%# Eval("TYPE_CODE") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="extents"  Text='<%# Eval("extent") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="net_sown_area"  Text='<%# Eval("NET_SOWN_AREA") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="khariff"  Text='<%# Eval("KHARIFF_RABI") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="month"  Text='<%# Eval("MONTH_OF_CULTIVATION") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="crop"  Text='<%# Eval("crop") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="single"  Text='<%# Eval("single") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="mixed"  Text='<%# Eval("mixed") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="total"  Text='<%# Eval("total") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="water_source1"  Text='<%# Eval("WATER_SOURCE1") %>' runat="server" ForeColor="Black" Visible="false"/>

                           <asp:Label ID="first_crop"  Text='<%# Eval("FIRST_CROP") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="second_crop"  Text='<%# Eval("SECOND_THIRD_CROP") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="crop_yield"  Text='<%# Eval("CROP_YIELD") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="vro"  Text='<%# Eval("VRO_RI_REMARKS") %>' runat="server" ForeColor="Black" Visible="false"/>
                           <asp:Label ID="tahsildar"  Text='<%# Eval("TAHSILDAR_REMARKS") %>' runat="server" ForeColor="Black" Visible="false"/>
                      <asp:Label ID="remarks"  Text='<%# Eval("REMARKS") %>' runat="server" ForeColor="Black" Visible="false"/>
                      
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
                    
      
                    </Columns>  
                   <%-- <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    <HeaderStyle BackColor="#008500" Font-Bold="True" ForeColor="#FFFFFF" />  
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  --%>
                    <RowStyle BackColor="White" ForeColor="#003399" />  
                   <%-- <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />  
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                    <SortedDescendingCellStyle BackColor="#D6DFDF" /> 
                    <SortedDescendingHeaderStyle BackColor="#002876" /> --%>  
                </asp:GridView>
                                              
                                            </div>
                                        </div>

              

<%--
                <div class="row mb-2 justify-content-center">
                            <asp:Button ID="btn_sumit" runat="server" Text="Submit"   OnClick="btn_click"/>&nbsp &nbsp
          
                     </div>
                --%>


           

        


        
          </div>
      <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
      <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">UPDATE/VALIDATE FARMER LAND DETAILS</h5>
           <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return close();">
               --%>
                <asp:ImageButton ID="btn_close" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="Close_Click" />
             
           <%-- </button>--%>
          </div>
          <div class="modal-body" style="max-height:500px;overflow:auto;">
           
               <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-6 col-lg-6 col-12">

                      
                         <%-- <div class="row mb-2">
                          <asp:Label ID="Image" runat="server" Text="Farmer Photo" class="col-md-4 col-form-label"></asp:Label><%--<span style="color: Red;">*</span>
                          <div class="col-md-6">
                               <asp:Image ID="FarmerImage" runat="server"  Width="70px" Height="70px" />
                         </div>
                      </div>--%>
                          <div class="row mb-2">
                          <asp:Label ID="lbl_id" runat="server" Text="Farmer Id" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                   
                          <asp:TextBox ID="txt_id" runat="server"  CssClass="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                              <asp:TextBox ID="txt_bid" runat="server"  CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                      </div>
                      <div class="row mb-2">
                          <asp:Label ID="lbl_farmer" runat="server" Text="Farmer Name" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_farmer" runat="server"  CssClass="form-control" ReadOnly="true" ></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_cult" runat="server" Text="Cultivator Name" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_cultivator" runat="server"  CssClass="form-control" ReadOnly="true" ></asp:TextBox></div>
                         
                      </div>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                      <ContentTemplate>
                       <div class="row mb-2">
                          <asp:Label ID="Label2" runat="server" Text="Gram Panchayat" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <%--<asp:TextBox ID="txt_gp" runat="server"  CssClass="form-control" ReadOnly="true" ></asp:TextBox></div>--%>
                           <asp:DropDownList ID="ddl_gp" runat="server" CssClass="form-control"  AutoPostBack="true" ReadOnly="true"></asp:DropDownList>
                              
</div>
                      </div>
                            <div class="row mb-2">
                          <asp:Label ID="Label3" runat="server" Text="Revenue Village" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                             <%-- <asp:TextBox ID="txt_rev_village" runat="server"  CssClass="form-control"  ></asp:TextBox></div>--%>
                          <asp:DropDownList ID="ddl_rv" runat="server" CssClass="form-control"  AutoPostBack="true" ReadOnly="true"></asp:DropDownList>
                      </div>
                           </div>
                           </ContentTemplate></asp:UpdatePanel>
                     
                         <div class="row mb-2">
                          <asp:Label ID="lbl_hab" runat="server" Text="Habitation" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_hab" runat="server"  CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                         
                      </div>


                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>
                      <div class="row mb-2">
                          <asp:Label ID="lbl_div" runat="server" Text="Forest Division" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:DropDownList ID="ddl_division" runat="server" CssClass="form-control" ReadOnly="true" AutoPostBack="true" OnSelectedIndexChanged="ddldivision_OnSelectedIndexChanged"></asp:DropDownList>
                              <asp:TextBox ID="txt_division" runat="server"  CssClass="form-control" onkeypress='pattadarnamevalidate(event)' autocomplete="off" Visible="false" ReadOnly="true"></asp:TextBox>
                          <asp:TextBox ID="txt_divisioncode" runat="server"  CssClass="form-control" onkeypress='pattadarnamevalidate(event)' autocomplete="off"  Visible="false" ReadOnly="true"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_range" runat="server" Text="Forest Range" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:DropDownList ID="ddl_range" runat="server" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlrange_OnSelectedIndexChanged" ReadOnly="true"></asp:DropDownList>
                              <asp:TextBox ID="txt_range" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)'  Visible="false" ReadOnly="true"></asp:TextBox>
                             <asp:TextBox ID="txt_rangecode" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)' Visible="false" ReadOnly="true"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_beat" runat="server" Text="Forest Beat" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:DropDownList ID="ddl_beat" runat="server" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlbeat_OnSelectedIndexChanged" ReadOnly="true"></asp:DropDownList>
                              <asp:TextBox ID="txt_beat" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)' Visible="false" ReadOnly="true"></asp:TextBox>
                           <asp:TextBox ID="txt_beatcode" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)'  Visible="false" ReadOnly="true"></asp:TextBox></div>
                         
                      </div>
                          </ContentTemplate>
                      </asp:UpdatePanel>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_block" runat="server" Text="Forest Block" class="col-md-4 col-form-label"> <span style="color: red"  id="s_block" runat="server"  >*</span></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_block" runat="server"  CssClass="form-control" autocomplete="off" ></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_cmno" runat="server" Text="Compartment No." class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_cno" runat="server"  CssClass="form-control" autocomplete="off" onchange="return cmtchange(this);" onkeypress="return validatesplkeyPress(this,event);" oncopy="return false" onpaste="return false" oncut="return false" ></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_plot" runat="server" Text="Plot No" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_plotno" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='codevalidate(event)' ></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_patta" runat="server" Text="Patta No." class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_patta" runat="server"  CssClass="form-control" autocomplete="off"  onchange="return pattachange(this);" onkeypress='Accountnovalidate(event)' oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_extent" runat="server" Text="ExtentPlotArea" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_extent" runat="server"  CssClass="form-control" autocomplete="off"  onkeypress="return validateFloatKeyPress(this,event);" oncopy="return false" onpaste="return false" oncut="return false" onchange="return fdecimal(this);"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_cultivable" runat="server" Text="Cultivable Land" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_cultivable" runat="server"  CssClass="form-control" autocomplete="off" onkeypress="return validateFloatKeyPress(this,event);" oncopy="return false" onpaste="return false" oncut="return false" onchange="return fdecimal(this);"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_uncultivable" runat="server" Text="Uncultivable Land" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_uncultivable" runat="server"  CssClass="form-control" autocomplete="off"  onkeypress="return validateFloatKeyPress(this,event);" Readonly="true" oncopy="return false" onpaste="return false" oncut="return false" onchange="return fdecimal(this);"></asp:TextBox></div>
                         
                      </div>
                      <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_nature" runat="server" Text="Holding Nature" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_nature" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)'  Visible="false"></asp:TextBox>
                           <asp:DropDownList ID="ddl_nature" runat="server"  CssClass="form-control" AutoPostBack="true">
                                 <%--<asp:ListItem>Select</asp:ListItem>
              <asp:ListItem>Agriculture</asp:ListItem>
              <asp:ListItem>Housing</asp:ListItem>--%>
          </asp:DropDownList>
                              </div>
                      </div>
                          </ContentTemplate>
                          </asp:UpdatePanel>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_w_tax" runat="server" Text="Water Tax" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_w_tax" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='mastervalidatenumerics(event)' ></asp:TextBox></div>
                         
                      </div>
                      <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                          <ContentTemplate>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_dryid" runat="server" Text="DryId OneCrop/TwoCrop" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_dryid" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)'  Visible="false"></asp:TextBox>
                          <asp:DropDownList ID="ddl_dryid" runat="server"  CssClass="form-control">
                                <%-- <asp:ListItem>Select</asp:ListItem>
              <asp:ListItem>Dry</asp:ListItem>
              <asp:ListItem>Irrigated Dry</asp:ListItem>
                               <asp:ListItem>One Crop</asp:ListItem>
                               <asp:ListItem>Two Crop</asp:ListItem>--%>
          </asp:DropDownList>
                      </div>
                    
</div></ContentTemplate>
                         </asp:UpdatePanel>
                      </div>

                  <div class="col-md-6 col-lg-6 col-12">
                         <div class="row mb-2">
                          <asp:Label ID="Label20" runat="server" Text="Water Source" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_w_source" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='mastervalidatenumerics(event)' ></asp:TextBox></div>
                         
                      </div>
                      
                       <div class="row mb-2">
                         
                          <asp:Label ID="lbl_eirrigated" runat="server" Text="Extent Irrigated" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_eirrigated" runat="server"  CssClass="form-control"  autocomplete="off"   onkeypress="return validateFloatKeyPress(this,event);" oncopy="return false" onpaste="return false" oncut="return false" onchange="return fdecimal(this);"></asp:TextBox></div>
                      </div>
                     
                      <div class="row mb-2">
                         
                          <asp:Label ID="lbl_extent_cult" runat="server" Text="Extent Under Cultivator" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_extent_cult" runat="server" CssClass="form-control" autocomplete="off"  onkeypress="return validateFloatKeyPress(this,event);" ReadOnly="true" oncopy="return false" onpaste="return false" oncut="return false" onchange="return fdecimal(this);"></asp:TextBox></div>
                      </div>
                        <div class="row mb-2">
                         
                          <asp:Label ID="lbl_tcode" runat="server" Text="Type Code" class="col-md-4 col-form-label" ></asp:Label>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_tcode" runat="server" CssClass="form-control"  autocomplete="off" onkeypress='Accountnovalidate(event)' ></asp:TextBox></div>
                      </div>
                       <div class="row mb-2">
                         
                          <asp:Label ID="lbl_extnt" runat="server" Text="Extent" class="col-md-4 col-form-label"  ></asp:Label>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_extnt" runat="server" CssClass="form-control" autocomplete="off"  onkeypress="return validateFloatKeyPress(this,event);"  oncopy="return false" onpaste="return false" oncut="return false" onchange="return fdecimal(this);"></asp:TextBox></div>
                      </div>
                        <div class="row mb-2">
                         
                          <asp:Label ID="lbl_net" runat="server" Text="Net Sown Area" class="col-md-4 col-form-label" ></asp:Label>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_net" runat="server" CssClass="form-control" autocomplete="off" onkeypress="return validateFloatKeyPress(this,event);"  oncopy="return false" onpaste="return false" oncut="return false" onchange="return fdecimal(this);"></asp:TextBox></div>
                      </div>
                      <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                      <div class="row mb-2">
                          <asp:Label ID="lbl_kharif" runat="server" Text="Khariff/Rabi" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_kharif" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)' Visible="false" ></asp:TextBox>
                              <asp:DropDownList ID="ddl_kharif" runat="server"  CssClass="form-control" AutoPostBack="true">
                                 <%--<asp:ListItem>Select</asp:ListItem>
              <asp:ListItem>Kharif</asp:ListItem>
              <asp:ListItem>Rabi</asp:ListItem>--%>
                              
          </asp:DropDownList>
                      </div>
                          </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_month" runat="server" Text="Month Of Cultivation" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_month" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)' Visible="false" ></asp:TextBox>
                          
                              <asp:DropDownList ID="ddl_month" runat="server"  CssClass="form-control" AutoPostBack="true">
                                 <%--<asp:ListItem>Select</asp:ListItem>
              <asp:ListItem>January</asp:ListItem>
              <asp:ListItem>February</asp:ListItem>
                                   <asp:ListItem>March</asp:ListItem>
                                   <asp:ListItem>April</asp:ListItem>
                                   <asp:ListItem>May</asp:ListItem>
                                   <asp:ListItem>June</asp:ListItem>
                                   <asp:ListItem>July</asp:ListItem>
                                   <asp:ListItem>August</asp:ListItem>
                                   <asp:ListItem>September</asp:ListItem>
                                   <asp:ListItem>October</asp:ListItem>
                                   <asp:ListItem>November</asp:ListItem>
                                   <asp:ListItem>December</asp:ListItem>--%>
                              
          </asp:DropDownList>
                      </div>
                           </div>
                          </ContentTemplate>
                          </asp:UpdatePanel>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_crop" runat="server" Text="Crop" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_crop" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='mastervalidatenumerics(event)' ></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_single" runat="server" Text="Single Crop" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_single" runat="server"  CssClass="form-control" autocomplete="off"  onkeypress="return validateFloatKeyPress(this,event);" oncopy="return false" onpaste="return false" oncut="return false" onchange="return fdecimal(this);"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_mixed" runat="server" Text="Mixed Crop" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_mixed" runat="server"  CssClass="form-control" autocomplete="off"   onkeypress="return validateFloatKeyPress(this,event);" oncopy="return false" onpaste="return false" oncut="return false" onchange="return fdecimal(this);"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_tcrop" runat="server" Text="Total Crop" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_tcrop" runat="server"  CssClass="form-control" autocomplete="off"   onkeypress="return validateFloatKeyPress(this,event);" oncopy="return false" onpaste="return false" oncut="return false" onchange="return fdecimal(this);"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_w_source1" runat="server" Text="Water Source1" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_w_source1" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='mastervalidatenumerics(event)' ></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_first" runat="server" Text="First Crop" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_first" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='mastervalidatenumerics(event)' ></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_second" runat="server" Text="Second/Third Crop" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_second" runat="server"  CssClass="form-control" autocomplete="off"  onkeypress='mastervalidatenumerics(event)'></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_cyield" runat="server" Text="Crop Yield" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_cyield" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='mastervalidatenumerics(event)'></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_vro" runat="server" Text="VRO/RI Remarks" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_vro" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)' ></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_tahsildar" runat="server" Text="Tahsildar Remarks" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_tahsildar" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)' ></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_remarks" runat="server" Text="Remarks" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_remarks" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)' ></asp:TextBox></div>
                         
                      </div>
                     
                   
                      </div>

                  </div>
              </div>
              </div>
                     
  
          <div class="modal-footer">
           
              <asp:Button ID="mbtn_submit" runat="server" Text="Submit" OnClick="mbtn_click" OnClientClick="return validation();"  />
           
          </div>
        </div>
      </div>
        </div>
    
    <script>
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
    <script>
function validatename(){
    //var regName = /^[a-zA-Z]+ [a-zA-Z]+$/;
    var regName = /^[a-zA-Z ]*$/;
    var name = document.getElementById('name').value;
    var name = document.getElementById('<%=ddl_village.ClientID %>').value;
    if(!regName.test(name)){
     
        return false;
    }
    else {
    
        return true;
    }
}

        function float(event) {
            if (event.shiftKey == true) {
                event.preventDefault();
            }

            if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39 || event.keyCode == 46 || event.keyCode == 190) {

            } else {
                event.preventDefault();
            }



            if (($(this).val().indexOf('.') != -1) && ($(this).val().substring($(this).val().indexOf('.')).length > 2) && (event.which != 0 && event.which != 8) && ($(this)[0].selectionStart >= $(this).val().length - 2)) {
                event.preventDefault();
            }
        }
</script>
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
            var regex = /[a-zA-Z ]|\a/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
     }


     function validatebankname(evt) {
         var theEvent = evt || window.event;

         //Handle paste
         if (theEvent.type === 'paste') {
             key = event.clipboardData.getData('text/plain');
         } else {
             // Handle key press
             var key = theEvent.keyCode || theEvent.which;
             key = String.fromCharCode(key);
         }
         var regex = /[a-zA-Z, ]|\a/;
         if (!regex.test(key)) {
             theEvent.returnValue = false;
             if (theEvent.preventDefault) theEvent.preventDefault();
         }
     }
     function validateadhar(evt) {
         var theEvent = evt || window.event;

         //Handle paste
         if (theEvent.type === 'paste') {
             key = event.clipboardData.getData('text/plain');
         } else {
             // Handle key press
             var key = theEvent.keyCode || theEvent.which;
             key = String.fromCharCode(key);
         }
         var regex = /[0-9]/;
         if (!regex.test(key)) {
             theEvent.returnValue = false;
             if (theEvent.preventDefault) theEvent.preventDefault();
         }
     }
     function validatebankacnt(evt) {
         var theEvent = evt || window.event;

         //Handle paste
         if (theEvent.type === 'paste') {
             key = event.clipboardData.getData('text/plain');
         } else {
             // Handle key press
             var key = theEvent.keyCode || theEvent.which;
             key = String.fromCharCode(key);
         }
         var regex = /[0-9-]/;
         if (!regex.test(key)) {
             theEvent.returnValue = false;
             if (theEvent.preventDefault) theEvent.preventDefault();
         }
     }
     function validateifsc(evt) {
         var theEvent = evt || window.event;

         //Handle paste
         if (theEvent.type === 'paste') {
             key = event.clipboardData.getData('text/plain');
         } else {
             // Handle key press
             var key = theEvent.keyCode || theEvent.which;
             key = String.fromCharCode(key);
         }
         var regex = /[a-zA-Z0-9]/;
         if (!regex.test(key)) {
             theEvent.returnValue = false;
             if (theEvent.preventDefault) theEvent.preventDefault();
         }
     }
     function validateExtent(el, evt) {
         var charCode = (evt.which) ? evt.which : event.keyCode;
         var number = el.value.split('.');
         if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
             return false;
         }
         //just one dot
         if (number.length > 1 && charCode == 46) {
             return false;
         }
         //get the carat position
         var caratPos = getSelectionStart(el);
         var dotPos = el.value.indexOf(".");
         if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) {
             return false;
         }
         return true;
     }

     function validatesplkeyPress(el, evt) {
         var charCode = (evt.which) ? evt.which : event.keyCode;

         if (charCode >= 31 && charCode <= 37) {
             return false;
         }
         if (charCode >= 39 && charCode <= 43) {
             return false;
         }
         if (charCode == 46) {
             return false;
         }
         if (charCode >= 58 && charCode <= 64) {
             return false;
         }
         if (charCode >= 91 && charCode <= 96) {
             return false;
         }
         if (charCode >= 123 && charCode <= 255) {
             return false;
         }

     }
     function validateFloatKeyPress(el, evt) {
         var charCode = (evt.which) ? evt.which : event.keyCode;
         var number = el.value.split('.');
         if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
             return false;
         }
         if (charCode >= 13 && charCode <= 27) {
             return false;
         }
         //if (evt.which &&( charCode == 86|| charCode == 88 ||charCode == 67)) {
         //    return false;
         //}
         //just one dot
         if (number.length > 1 && charCode == 46) {
             return false;
         }
         //get the carat position
         var caratPos = getSelectionStart(el);
         var dotPos = el.value.indexOf(".");
         if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) {
             return false;
         }
         return true;
     }


     function getSelectionStart(o) {
         if (o.createTextRange) {
             var r = document.selection.createRange().duplicate()
             r.moveEnd('character', o.value.length)
             if (r.text == '') return o.value.length
             return o.value.lastIndexOf(r.text)
         } else return o.selectionStart
     }

        function fdecimal(event) {
      
      var str = event.value.indexOf(".");
      var reg = /^\d{1,2}(?:\.\d{1,2})?$/
     if (str != -1) {
         if (reg.test(event.value)) {
             return true;

         }
         else
         {
            ext = document.getElementById('<%=txt_extent.ClientID %>').value;
            var subt = /^0+$/;
            //var starting_date = '00000000'
            if (ext.match(subt)) {
                //document.getElementById('<%=txt_extent.ClientID %>').value == "";
                alert("Please enter valid Extent No. and value cannot be zero's");
                event.value = "";
                return false;
              //  document.getElementById('<%=txt_extent.ClientID %>').value == "";
            }
            else {
                 alert('Please enter valid extent.... Example:2.00, 23.45')
              <%--document.getElementById('<%=txt_plotarea.ClientID %>').value = "";--%>
            event.value = "";
            return false;
            }
         }
             
          }
          
//     else if (str ==3) {
//              alert('Please enter valid extent.... Example:2.00, 23.45')
//              event.value = "";
           
//}
     else  {
         ext = document.getElementById('<%=txt_extent.ClientID %>').value;
            var subt = /^0+$/;
            //var starting_date = '00000000'
            if (ext.match(subt)) {
                //document.getElementById('<%=txt_extent.ClientID %>').value == "";
                alert("Please enter valid Extent No. and value cannot be zero's");
                event.value = "";
                return false;
              //  document.getElementById('<%=txt_extent.ClientID %>').value == "";
            }
            else {
                 alert('Please enter valid extent.... Example:2.00, 23.45')
              <%--document.getElementById('<%=txt_plotarea.ClientID %>').value = "";--%>
            event.value = "";
            return false;
            }

     }
        }



        function Accountnovalidate(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z0-9 ]|\a/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
        </script>
</asp:Content>
