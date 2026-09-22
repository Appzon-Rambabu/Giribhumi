<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Beneficiary_DeletionForm.aspx.cs" Inherits="ROFR.pages.Beneficiary_DeletionForm"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>--%>
    <script src="../linksforcdns/Js/jquery.min.js"></script>
     <script type="text/javascript">

        function openModal() {
            $('#exampleModal').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }
        function openBen() {
            $('#BenexampleModal').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }
        function openyesnoBen() {
            $('#yesnoModal').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }
        function lanopenyesnoBen() {
            $('#dellandyesnoModal').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }
         function openland() {
            $('#LandexampleModal').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }
        function opennoland() {
            $('#NoLandexampleModal').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }

        function opennoyesland() {
            $('#dellnoandyesnoModal').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }
        function opendupyesland() {
            $('#dupnoandyesnoModal').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }

        

        function openBenyorn() {
            $('#Benyorn').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }

      
    </script>
   
      <style>
  .pager span { color:#009900;font-weight:bold; font-size:16pt; } 
  
    .font-telugu {
      font-family: 'Ramabhadra', sans-serif;
      text-shadow: 2px 2px rgba(0, 0, 0, 0.3);
      font-size: 30px;
    }
    

   
     .table th {
      text-align: center;
       background-color: #1F5C99 !important;
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


     <h5 class="text-center text-success mb-4 mt-3">BENEFICIARY DELETION FORM</h5>

      
       

                

           <div class="row d-flex justify-content-end bg-white">
              
                    <div class="col-md-12 text-center ml-0 mr-0 mt-3">

                     <ul class="nav nav-pills nav-wizard mb-3 custom-tabsr d-flex justify-content-center" id="pills-tab" role="tablist">
											
											  <li class="nav-item">
											    <%--<a class="nav-link active" id="pills-workflow-tab"  href="#pills-workflow" rel="pills-workflow" role="tab" aria-controls="pills-workflow" aria-selected="true">Duplicate Benificiary Deletion</a>--%>
											   <asp:LinkButton ID="lnk_dupl" runat="server"  BackColor="Blue" ForeColor="White" Height="30px" OnClick="Dupl_Click" CssClass="nav-link">Duplicate Benificiary Deletion</asp:LinkButton> &nbsp&nbsp&nbsp&nbsp&nbsp
                                              </li>
											 
											   <li class="nav-item">
			
                                                   <asp:LinkButton ID="lnk_ben" runat="server" OnClick="Ben_Click" Height="30px" CssClass="nav-link">Beneficiary Deletion</asp:LinkButton>  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

											   </li>
                         
											 
											  <li class="nav-item">
  											    <%--<a class="nav-link" id="pills_technical_tab"   href="#pills-technical"  rel="pills-technical"  role="tab" aria-controls="pills-technical" aria-selected="false" runat="server" onserverclick="Land_Click">Benificiary Land Deletion</a>--%>
											   <asp:LinkButton ID="lnk_land" runat="server" OnClick="Land_Click" Height="30px" CssClass="nav-link">Benificiary Land Deletion</asp:LinkButton>  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                              </li>
											  
											  <li class="nav-item">
											    <%--<a class="nav-link" id="pills_tender_tab"  href="#pills-tender" rel="pills-tender" role="tab" aria-controls="pills-tender" aria-selected="false" runat="server" onserverclick="NoLand_Click">Delete No Land Details</a>--%>
											  <asp:LinkButton ID="lnk_noland" runat="server" OnClick="NoLand_Click" Height="30px" CssClass="nav-link">Delete No Land Details</asp:LinkButton>  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                   </li>
											
											<%--  <li class="nav-item">
											    <a class="nav-link" id="pills-quality-tab" data-toggle="pill" href="#pills-quality" rel="pills-quality" role="tab" aria-controls="pills-quality" aria-selected="false" onclick="callqcworksfunction(); callQual_Ctrl_ResetFun();">Quality Control Status</a>
											  </li>--%>
											</ul>
                       
					   
					   <div class="tab-content" id="pills-tabContent">
											
						<%--<div class="tab-pane fade active show" id="pills-workflow" role="tabpanel" aria-labelledby="pills-workflow-tab">--%>
					<div id="div_dup" runat="server">		   
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
                        <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true"   runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>

             <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div2" runat="server">
                    <div class="col-md-10">
                        <asp:TextBox ID="txtSearch" runat="server"  class="form-control"  placeholder="Aadhar No..." autocomplete="off"  ></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                         <asp:Button ID="btnsubmit" class="btn btn-sm btn-success" style="height: 25px !important;padding: 1px 10px  !important;" OnClick="txtSearch_Click"  AutoPostBack="true"  runat="server" Text="SUBMIT" />
                    </div>
                </div>
            </div>


  
            <br />
          
    </div> 

                              <div class="row mb-6">
                                            <div class="table-responsive">
                                         <div class="headertable">      
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"    CssClass="table text-center table-bordered "  AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" >  
                  <PagerStyle CssClass="pager" />
<Columns>   
                        
                                       <asp:TemplateField HeaderText="Sno." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl101"   Text='<%# Container.DataItemIndex + 1 %>' runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="Select" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                    
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true"  CommandArgument='<%#Eval("benficiary_id") %>' CausesValidation="false" OnCheckedChanged="CheckBox1_CheckedChanged" />
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Id" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="bid"   Text='<%# Eval("benficiary_id") %>'  runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Itda" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:left">
                  
              <asp:Label Class="txt"  ID="itda" runat="server"   Text='<%# Eval("ITDA_NAME") %>' ForeColor="Black" ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                            
               <asp:TemplateField HeaderText="District" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="district"   Text='<%# Eval("DISTRICT") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="Mandal" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="mandal"   Text='<%# Eval("Mandal") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Village" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="village"   Text='<%# Eval("Village") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Habitation" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="hab"   Text='<%# Eval("Habitation") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Pattadaar Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="farmer"   Text='<%# Eval("ROFR_PATTADAAR") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Father Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="fname"   Text='<%# Eval("Father_Name") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Aadhaar No" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="Aadhaar"   Text='<%# Eval("AADHAAR_NO") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Sub Caste" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="subcaste"   Text='<%# Eval("Sub_Caste") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         

        <asp:TemplateField HeaderText="Bank AccountNo" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="Ban"   Text='<%# Eval("BankAccountNo") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="IfscCode" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="IfscCode"   Text='<%# Eval("IfscCode") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="BankName" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="BankName"   Text='<%# Eval("BankName") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
          

      
                    </Columns>  
                   <%-- <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  --%>
                    <RowStyle BackColor="White" ForeColor="#003399" />  
                   <%-- <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />  
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                    <SortedDescendingCellStyle BackColor="#D6DFDF" /> 
                    <SortedDescendingHeaderStyle BackColor="#002876" /> --%>  
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last"/>
                </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
						</div>

                                                  <div id="del_noland" runat="server" visible="false">
                           <div class="row mb-2">
           
        
                                 <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div4" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="Label19" runat="server" Text="Mandal:"></asp:Label>&nbsp<asp:Label ID="lblm" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                      
                      <asp:DropDownList ID="ddl_mandal" AutoPostBack="true"  CssClass="form-control" runat="server" OnSelectedIndexChanged="ddl_mandal_SelectedIndexChanged"></asp:DropDownList>
                         </div>
                   
                </div>
            </div>
             <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div5" runat="server">
                 

                    <div class="col-md-6 pl-0 pr-0">
                         <asp:Button ID="btn_mandal_submit" class="btn btn-sm btn-success" style="height: 25px !important;padding: 1px 10px  !important;" OnClick="NL_Click"  AutoPostBack="true"  runat="server" Text="SUBMIT" />
                    </div>
                </div>
            </div>
            <br />
          
    </div> 
</div>

                                             
						<div id="del_ben" runat="server" visible="false">
							
                      
                             <div class="row mb-6">
                                            <div class="table-responsive">
                                         <div class="headertable">   
                                              <div id="del_ben12" runat="server" visible="false" style="float:right">                                           
                                            <asp:TextBox ID="TextBox1" runat="server"  placeholder="Aadhar No"/>&nbsp;&nbsp;
                           <asp:Button ID="search" class="btn btn-sm btn-success" runat="server" Text="Search" OnClick="Searchid_Click"/>&nbsp;&nbsp;
                            </div>
   <asp:GridView ID="GridView2"  runat="server"  AutoGenerateColumns="False" CssClass="table text-center table-bordered " AllowPaging="True"  OnPageIndexChanging="GridView2_PageIndexChanging" >  
                 <PagerStyle CssClass="pager" />
<Columns>   
                        
                                       <asp:TemplateField HeaderText="Sno." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl101"   Text='<%# Container.DataItemIndex + 1 %>' runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="Select" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">


                  <%--  <asp:Button Text="Delete" runat="server" CommandName="Delete" CommandArgument="<%# Container.DataItemIndex %>"/>--%>
                    
                  <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="true" CommandArgument='<%#Eval("benficiary_id") %>' CausesValidation="false" OnCheckedChanged="CheckBox2_CheckedChanged" />
                  
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Id" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="bid"   Text='<%# Eval("benficiary_id") %>'  runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Itda" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:left">
                  
              <asp:Label Class="txt"  ID="itda" runat="server"   Text='<%# Eval("ITDA_NAME") %>' ForeColor="Black" ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                            
               <asp:TemplateField HeaderText="District" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="district"   Text='<%# Eval("DISTRICT") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="Mandal" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="mandal"   Text='<%# Eval("Mandal") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Village" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="village"   Text='<%# Eval("Village") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Habitation" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="hab"   Text='<%# Eval("Habitation") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Pattadaar Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="farmer"   Text='<%# Eval("ROFR_PATTADAAR") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Father Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="fname"   Text='<%# Eval("Father_Name") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Aadhaar No" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="Aadhaar"   Text='<%# Eval("AADHAAR_NO") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Sub Caste" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="subcaste"   Text='<%# Eval("Sub_Caste") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         

        <asp:TemplateField HeaderText="Bank AccountNo" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="Ban"   Text='<%# Eval("BankAccountNo") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="IfscCode" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="IfscCode"   Text='<%# Eval("IfscCode") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="BankName" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="BankName"   Text='<%# Eval("BankName") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
          

      
                    </Columns>  

      
      
                   <%-- <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  --%>
                    <RowStyle BackColor="White" ForeColor="#003399" />  
                   <%-- <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />  
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                    <SortedDescendingCellStyle BackColor="#D6DFDF" /> 
                    <SortedDescendingHeaderStyle BackColor="#002876" /> --%>  
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last"/>
                </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
						</div>


						
						<%--<div class="tab-pane fade" id="pills-technical" role="tabpanel" aria-labelledby="pills_technical_tab">--%>
                           <div id="del_land" runat="server" visible="false">
                      
						<div class="row mb-6">
                                            <div class="table-responsive">
                                         <div class="headertable">    
                                             <div id="noadhar" runat="server" visible="false" style="float:right"> 
                                              <asp:TextBox ID="TextBox2" runat="server"  placeholder="Aadhar No"/>&nbsp;&nbsp;
                           <asp:Button ID="Button2" class="btn btn-sm btn-success" runat="server" Text="Search" OnClick="Button2_Click"/>&nbsp;&nbsp; 
                                                 </div>
   <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"    CssClass="table text-center table-bordered " AllowPaging="true" OnPageIndexChanging="GridView3_PageIndexChanging" >  
            <PagerStyle CssClass="pager" />     
<Columns>   
                        
                                       <asp:TemplateField HeaderText="Sno." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl101"   Text='<%# Container.DataItemIndex + 1 %>' runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="Select" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                    
                    <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="true"  CommandArgument='<%#Eval("ID") %>' CausesValidation="false" OnCheckedChanged="CheckBox3_CheckedChanged" />
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Id" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="id"   Text='<%# Eval("ID") %>'  runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Benificiary Id" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="bid"   Text='<%# Eval("benficiary_id2") %>'  runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Itda" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:left">
                  
              <asp:Label Class="txt"  ID="itda" runat="server"   Text='<%# Eval("ITDA_NAME") %>' ForeColor="Black" ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                            
               <asp:TemplateField HeaderText="District" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="district"   Text='<%# Eval("DISTRICT") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="Mandal" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="mandal"   Text='<%# Eval("Mandal") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Village" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="village"   Text='<%# Eval("Village") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Habitation" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="hab"   Text='<%# Eval("Habitation") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Pattadaar Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="farmer"   Text='<%# Eval("ROFR_PATTADAAR") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Father Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="fname"   Text='<%# Eval("Father_Name") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Aadhaar No" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="Aadhaar"   Text='<%# Eval("AADHAAR_NO") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Compartment No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="subcaste"   Text='<%# Eval("Compartment_No") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         

        <asp:TemplateField HeaderText="ROFR PATTANO." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="Ban"   Text='<%# Eval("ROFR_PATTANO") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="Extent Plot Area" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="IfscCode"   Text='<%# Eval("ExtentPlotArea") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     
          

      
                    </Columns>  
                   <%-- <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  --%>
                    <RowStyle BackColor="White" ForeColor="#003399" />  
                   <%-- <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />  
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                    <SortedDescendingCellStyle BackColor="#D6DFDF" /> 
                    <SortedDescendingHeaderStyle BackColor="#002876" /> --%>  
       <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last"/>
                </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
						</div>

						<%--<div class="tab-pane fade" id="pills-tender" role="tabpanel" aria-labelledby="pills_tender_tab">--%>
      
						<div class="row mb-6">
                                            <div class="table-responsive">
                                         <div class="headertable">      
   <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False"    CssClass="table text-center table-bordered " AllowPaging="true" OnPageIndexChanging="GridView4_PageIndexChanging"   >  
                 <PagerStyle CssClass="pager" />
<Columns>   
                        
                                       <asp:TemplateField HeaderText="Sno." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl101"   Text='<%# Container.DataItemIndex + 1 %>' runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="Select" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                    
                    <asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="true"  CommandArgument='<%#Eval("benficiary_id") %>' CausesValidation="false" OnCheckedChanged="CheckBox4_CheckedChanged" />
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Id" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="bid"   Text='<%# Eval("benficiary_id") %>'  runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Itda" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:left">
                  
              <asp:Label Class="txt"  ID="itda" runat="server"   Text='<%# Eval("ITDA_NAME") %>' ForeColor="Black" ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                            
               <asp:TemplateField HeaderText="District" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="district"   Text='<%# Eval("DISTRICT") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="Mandal" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="mandal"   Text='<%# Eval("Mandal") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Village" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="village"   Text='<%# Eval("Village") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Habitation" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="hab"   Text='<%# Eval("Habitation") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Pattadaar Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="farmer"   Text='<%# Eval("ROFR_PATTADAAR") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Father Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="fname"   Text='<%# Eval("Father_Name") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Aadhaar No" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="Aadhaar"   Text='<%# Eval("AADHAAR_NO") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Sub Caste" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="subcaste"   Text='<%# Eval("Sub_Caste") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         

        <asp:TemplateField HeaderText="Bank AccountNo" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="Ban"   Text='<%# Eval("BankAccountNo") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="IfscCode" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="IfscCode"   Text='<%# Eval("IfscCode") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="BankName" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="BankName"   Text='<%# Eval("BankName") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
          

      
                    </Columns>  
                   <%-- <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  --%>
                    <RowStyle BackColor="White" ForeColor="#003399" />  
                   <%-- <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />  
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                    <SortedDescendingCellStyle BackColor="#D6DFDF" /> 
                    <SortedDescendingHeaderStyle BackColor="#002876" /> --%> 
       <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last"/> 
                </asp:GridView>

 
                                                </div>
                                            </div>
                                        </div>
						
						
						<%--<div class="tab-pane fade" id="pills-quality" role="tabpanel" aria-labelledby="pills-quality-tab">

						</div>--%>

						</div>
                       
                    </div>
					</div>
        
                               

              




           

        


        
          </div>
      <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
      <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">DELETE DUPLICATE FARMER DETAILS</h5>
         
                <asp:ImageButton ID="btn_close" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="Close_Click" />
             
        
          </div>
          <div class="modal-body" style="max-height:500px;overflow:auto;">
           
               <div class="col-md-6">
                  <div class="row justify-content-center">

                  <div class="col-md-6 col-lg-6 col-12">

                      
                         
                          <div class="row mb-2">
                          <asp:Label ID="lbl_id" runat="server" Text="Farmer Id" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                   
                         
                              <asp:TextBox ID="txt_bid" runat="server"  CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                      </div>
                     
                         <div class="row mb-2">
                          <asp:Label ID="lbl_hab" runat="server" Text="Habitation" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_hab" runat="server"  CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_farmer" runat="server" Text="Farmer Name" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_farmer" runat="server"  CssClass="form-control" ReadOnly="true" ></asp:TextBox></div>
                         
                      </div>
                      <div class="row mb-2">
                          <asp:Label ID="lbl_fname" runat="server" Text="Father Name" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_fname" runat="server"  CssClass="form-control" ReadOnly="true" autocomplete="off" ></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_subcaste" runat="server" Text="Sub Caste" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                              <asp:TextBox ID="txt_subcaste" runat="server"  CssClass="form-control" autocomplete="off" ReadOnly="true" ></asp:TextBox></div>
                         
                      </div>
                      
                       
                      </div>

                  <div class="col-md-6 col-lg-6 col-12">
                      
                       <div class="row mb-2">
                         
                          <asp:Label ID="lbl_adhar" runat="server" Text="Aadhaar NO" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                    
                        
                              <asp:TextBox ID="txt_adhar" runat="server"  CssClass="form-control"  ReadOnly="true" ></asp:TextBox></div>
                      </div>
                     
                      <div class="row mb-2">
                         
                          <asp:Label ID="lbl_reason" runat="server" Text="Reason" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                    
                     
                              <asp:TextBox ID="txt_reason" runat="server" CssClass="form-control"  autocomplete="off" TextMode="MultiLine"  onpaste="return false" ></asp:TextBox>
                      </div>
                        
                     </div>
                     
                   
                      </div>

                  </div>
              </div>
              </div>
                     
  
          <div class="modal-footer">
           
          

                   <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-6 col-lg-6 col-12">

                      
                         
                          <div class="row mb-2">
                         
                                      <asp:Label ID="Label12" runat="server" Text="" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6 text-center">
                  <asp:Button ID="mbtn_submit" runat="server" Text="Submit" OnClick="mbtn_click"  />       
                              </div>
                      </div>
                       
                       
                      </div>

                 <div class="col-md-6 col-lg-6 col-12">
                     </div>
                  </div>
              </div>
         
           
          </div>
        </div>
      </div>
        </div>



      <div class="modal fade" id="BenexampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
      <div class="modal-dialog modal-md" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="benModalLabel">DELETE BENEFICIARY</h5>
         
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="ImageButton1_Click"/>
             
           <%-- </button>--%>
          </div>
          <div class="modal-body" style="max-height:500px;overflow:auto;">
           
               <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-12 col-lg-12 col-12">

                      
                         
                          <div class="row mb-2">
                          <asp:Label ID="Label2" runat="server" Text="Farmer Id" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                   
                         
                              <asp:TextBox ID="txt_ben_id" runat="server"  CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                      </div>
                         <div class="row mb-2">
                          <asp:Label ID="Label9" runat="server" Text="Farmer" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                   
                         
                              <asp:TextBox ID="txt_fmr" runat="server"  CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                      </div>
                       <div class="row mb-2">
                         
                          <asp:Label ID="Label3" runat="server" Text="Reason" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-8">
                    
                     
                              <asp:TextBox ID="txt_ben_reason" runat="server" CssClass="form-control"  autocomplete="off" TextMode="MultiLine"  onpaste="return false" ></asp:TextBox>
                      </div>
                        
                     </div>
                      
                       
                      </div>

                
                      
                      
                     
         <%--<asp:GridView ID="gvSelected" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="false">
    <Columns>


        <asp:TemplateField HeaderText="Aadhaar No" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="bensid"   Text='<%# Eval("BeneficiaryId") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <asp:TemplateField HeaderText="Compartment No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="farmernames"   Text='<%# Eval("FarmerName") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

     <%--<asp:BoundField DataField="BeneficiaryId" HeaderText="beneficiaryid" ItemStyle-Width="150" />
        <asp:BoundField DataField="FarmerName" HeaderText="Farmer" ItemStyle-Width="150" />
    </Columns>
</asp:GridView>  --%>          
                   
                

                  </div>
              </div>
              </div>
                     
  
          <div class="modal-footer">
            
         
                  <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-6 col-lg-6 col-12">

                      
                         
                          <div class="row mb-2">
                         
                                      <asp:Label ID="Label11" runat="server" Text="" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6 text-center">
                    <asp:Button ID="btn_ben" runat="server" Text="Submit" OnClick="benbtn_click"  />
                         
                              </div>
                      </div>
                       
                       
                      </div>

                  </div>
              </div>
         
          </div>
        </div>
      </div>
        </div>

       <div class="modal fade" id="LandexampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
      <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="lndModalLabel">DELETE BENEFICIARY LAND DETAILS</h5>
          
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="ImageButton2_Click" />
             
       
          </div>
          <div class="modal-body" style="max-height:500px;overflow:auto;">
           
               <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-6 col-lg-6 col-12">

                        <div class="row mb-2">
                          <asp:Label ID="Label6" runat="server" Text="Id" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                   
                         
                              <asp:TextBox ID="txt_id" runat="server"  CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                      </div>
                         
                          <div class="row mb-2">
                          <asp:Label ID="Label4" runat="server" Text="Farmer Id" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                   
                         
                              <asp:TextBox ID="txt_fid" runat="server"  CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                      </div>
                      <div class="row mb-2">
                          <asp:Label ID="Label14" runat="server" Text="Farmer" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                   
                         
                              <asp:TextBox ID="txt_fn" runat="server"  CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                      </div>
                       <div class="row mb-2">
                         
                          <asp:Label ID="Label5" runat="server" Text="Reason" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                    
                     
                              <asp:TextBox ID="txt_land_reason" runat="server" CssClass="form-control"  autocomplete="off" TextMode="MultiLine"  onpaste="return false" ></asp:TextBox>
                      </div>
                        
                     </div>
                      
                       
                      </div>

                  <div class="col-md-6 col-lg-6 col-12">
                      
                      
                     
                     
                   
                      </div>

                  </div>
              </div>
              </div>
                     
  
          <div class="modal-footer">
           
            
              <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-6 col-lg-6 col-12">

                      
                         
                          <div class="row mb-2">
                         
                                      <asp:Label ID="Label13" runat="server" Text="" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6 text-center">
                     <asp:Button ID="btn_land" runat="server" Text="Submit" OnClick="landbtn_click"  />
                         
                              </div>
                      </div>
                       
                       
                      </div>

                 <div class="col-md-6 col-lg-6 col-12">
                     </div>
                  </div>
              </div>
          </div>
        </div>
      </div>
        </div>
     <div class="modal fade" id="NoLandexampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
      <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="nolndModalLabel">DELETE NO LAND BENEFICIARY DETAILS</h5>
           <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return close();">
               --%>
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="ImageButton3_Click" />
             
           <%-- </button>--%>
          </div>
          <div class="modal-body" style="max-height:500px;overflow:auto;">
           
               <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-6 col-lg-6 col-12">

                        <div class="row mb-2">
                          <asp:Label ID="Label8" runat="server" Text="Id" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                   
                         
                              <asp:TextBox ID="txt_nid" runat="server"  CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                      </div>
                         
                         
                        <div class="row mb-2">
                          <asp:Label ID="Label16" runat="server" Text="Farmer" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                   
                         
                              <asp:TextBox ID="txt_fnm" runat="server"  CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                      </div>
                         
                       <div class="row mb-2">
                         
                          <asp:Label ID="Label10" runat="server" Text="Reason" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6">
                    
                     
                              <asp:TextBox ID="txt_noland_reason" runat="server" CssClass="form-control"  autocomplete="off" TextMode="MultiLine"   onpaste="return false" ></asp:TextBox>
                      </div>
                        
                     </div>
                      
                       
                      </div>

                  <div class="col-md-6 col-lg-6 col-12">
                      
                      
                     
                     
                   
                      </div>

                  </div>
              </div>
              </div>
                     
  
          <div class="modal-footer">
           
           
             <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-6 col-lg-6 col-12">

                      
                         
                          <div class="row mb-2">
                         
                                      <asp:Label ID="Label15" runat="server" Text="" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6 text-center">
                      <asp:Button class="text-center text-success" ID="btn_noland" runat="server" Text="Delete" OnClick="nolandbtn_click"  />
                         
                              </div>
                      </div>
                       
                       
                      </div>

                 <div class="col-md-6 col-lg-6 col-12">
                     </div>
                  </div>
              </div>
          </div>
        </div>
      </div>
        </div>



   <div class="modal fade" id="yesnoModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
      <div class="modal-dialog modal-md" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="yesnoModalLabel">DELETE BENEFICIARY</h5>
         
                <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="ImageButton5_Click"/>
             
           <%-- </button>--%>
          </div>
          <div class="modal-body" style="max-height:500px;overflow:auto;">
           
               <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-12 col-lg-12 col-12">

                      
                  <h6 class="text-center text-success">Are you sure you want to delete this <asp:label runat="server" ID="lblyesid"></asp:label> ID</h6>     
                                               
                       
                      </div>


                  </div>
              </div>
              </div>
                     
  
          <div class="modal-footer">
            
         
                  <div class="col-md-12">
                  <div class="row justify-content-end">

                  <div class="col-md-6 col-lg-6 col-12">

                       <div class="row mb-2">
                         <asp:Label ID="Label21" runat="server" Text="" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6 text-right">
                    <asp:Button ID="yes" CssClass="btn btn-success btn-sm" runat="server" Text="Yes" OnClick="yes_Click"/>

                     <asp:Button ID="no" CssClass="btn btn-danger btn-sm" runat="server" Text="No" OnClick="no_Click"/>
                              </div>
                      </div>
                       
                       
                      </div>

                  </div>
              </div>
         
          </div>
        </div>
      </div>
        </div>



    <div class="modal fade" id="dellandyesnoModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
      <div class="modal-dialog modal-md" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="delandyesnoModal">DELETE BENEFICIARY LAND DETAILS</h5>
         
                <asp:ImageButton ID="landclose" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="landclose_Click"/>
             
           <%-- </button>--%>
          </div>
          <div class="modal-body" style="max-height:500px;overflow:auto;">
           
               <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-12 col-lg-12 col-12">

                      
                  <h6 class="text-center text-success">Are you sure you want to delete this <asp:label runat="server" ID="Label17"></asp:label> ID</h6>     
                                               
                       
                      </div>


                  </div>
              </div>
              </div>
                     
  
          <div class="modal-footer">
            
         
                  <div class="col-md-12">
                  <div class="row justify-content-end">

                  <div class="col-md-6 col-lg-6 col-12">

                       <div class="row mb-2">
                         <asp:Label ID="Label18" runat="server" Text="" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6 text-right">
                    <asp:Button ID="landyes" CssClass="btn btn-success btn-sm" runat="server" Text="Yes" OnClick="landyes_Click1"/>

                     <asp:Button ID="landno" CssClass="btn btn-danger btn-sm" runat="server" Text="No" OnClick="landno_Click"/>
                              </div>
                      </div>
                       
                       
                      </div>

                  </div>
              </div>
         
          </div>
        </div>
      </div>
        </div>




    <div class="modal fade" id="dellnoandyesnoModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
      <div class="modal-dialog modal-md" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="delnoandyesnoModal">DELETE NO LAND BENEFICIARY DETAILS</h5>
         
                <asp:ImageButton ID="nolandclose" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="nolandclose_Click"/>
             
           <%-- </button>--%>
          </div>
          <div class="modal-body" style="max-height:500px;overflow:auto;">
           
               <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-12 col-lg-12 col-12">

                      
                  <h6 class="text-center text-success">Are you sure you want to delete this <asp:label runat="server" ID="Label20"></asp:label> ID</h6>     
                                               
                       
                      </div>


                  </div>
              </div>
              </div>
                     
  
          <div class="modal-footer">
            
         
                  <div class="col-md-12">
                  <div class="row justify-content-end">

                  <div class="col-md-6 col-lg-6 col-12">

                       <div class="row mb-2">
                         <asp:Label ID="Label22" runat="server" Text="" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6 text-right">
                    <asp:Button ID="nolandyesbtn" CssClass="btn btn-success btn-sm" runat="server" Text="Yes" OnClick="nolandyesbtn_Click"/>

                     <asp:Button ID="nolandnobutn" CssClass="btn btn-danger btn-sm" runat="server" Text="No" OnClick="nolandnobutn_Click"/>
                              </div>
                      </div>
                       
                       
                      </div>

                  </div>
              </div>
         
          </div>
        </div>
      </div>
        </div>

    <div class="modal fade" id="dupnoandyesnoModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
      <div class="modal-dialog modal-md" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="duplnoandyesnoModal">DELETE DUPLICATE FARMER DETAILS</h5>
         
                <asp:ImageButton ID="deldup" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="deldup_Click"/>
             
           <%-- </button>--%>
          </div>
          <div class="modal-body" style="max-height:500px;overflow:auto;">
           
               <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-12 col-lg-12 col-12">

                      
                  <h6 class="text-center text-success">Are you sure you want to delete this <asp:label runat="server" ID="Labeldup"></asp:label> ID</h6>     
                                               
                       
                      </div>


                  </div>
              </div>
              </div>
                     
  
          <div class="modal-footer">
            
         
                  <div class="col-md-12">
                  <div class="row justify-content-end">

                  <div class="col-md-6 col-lg-6 col-12">

                       <div class="row mb-2">
                         <asp:Label ID="Label24" runat="server" Text="" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-6 text-right">
                    <asp:Button ID="dupdelyes" CssClass="btn btn-success btn-sm" runat="server" Text="Yes" OnClick="dupdelyes_Click"/>

                     <asp:Button ID="dupdelno" CssClass="btn btn-danger btn-sm" runat="server" Text="No" OnClick="dupdelno_Click"/>
                              </div>
                      </div>
                       
                       
                      </div>

                  </div>
              </div>
         
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
        </script>

     <script>

        var d = [[0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
            [1, 2, 3, 4, 0, 6, 7, 8, 9, 5],
            [2, 3, 4, 0, 1, 7, 8, 9, 5, 6],
            [3, 4, 0, 1, 2, 8, 9, 5, 6, 7],
            [4, 0, 1, 2, 3, 9, 5, 6, 7, 8],
            [5, 9, 8, 7, 6, 0, 4, 3, 2, 1],
            [6, 5, 9, 8, 7, 1, 0, 4, 3, 2],
            [7, 6, 5, 9, 8, 2, 1, 0, 4, 3],
            [8, 7, 6, 5, 9, 3, 2, 1, 0, 4],
            [9, 8, 7, 6, 5, 4, 3, 2, 1, 0]];


        // The permutation table
        var p = [
            [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
            [1, 5, 7, 6, 2, 8, 3, 0, 9, 4],
            [5, 8, 0, 3, 7, 9, 6, 1, 4, 2],
            [8, 9, 1, 6, 0, 4, 3, 5, 2, 7],
            [9, 4, 5, 3, 1, 2, 6, 8, 7, 0],
            [4, 2, 8, 6, 5, 7, 3, 9, 0, 1],
            [2, 7, 9, 3, 8, 0, 6, 4, 1, 5],
            [7, 0, 4, 6, 9, 1, 3, 2, 5, 8]];


        // The inverse table
        var inv = [0, 4, 3, 2, 1, 5, 6, 7, 8, 9];



        //  For a given number generates a Verhoeff digit

        //         Validates that an entered number is Verhoeff compliant.

        function validateVerhoeff(num) {
            //  alert("funcall" + num);
            if (num == "333333333333" || num == "777777777777") {
                return 0;
            }
            var cc;
            var c = 0;
            var myArray = StringToReversedIntArray(num);

            for (var i = 0; i < myArray.length; i++) {

                c = d[c][p[(i % 8)][myArray[i]]];

            }

            cc = c;
            if (cc == 0) {
                //alert("Valid UID");
                return true;

            }
            else {

                //alert("Invalid Aadhaar Number");
                return false;


            }
        }



        /*
         * Converts a string to a reversed integer array.
         */
        function StringToReversedIntArray(num) {

            var myArray = [num.length];

            for (var i = 0; i < num.length; i++) {

                myArray[i] = (num.substring(i, i + 1));

            }

            myArray = Reverse(myArray);


            return myArray;

        }

        /*
         * Reverses an int array
         */
        function Reverse(myArray) {

            var reversed = [myArray.length];

            for (var i = 0; i < myArray.length ; i++) {
                reversed[i] = myArray[myArray.length - (i + 1)];

            }

            return reversed;
        }
           </script>
</asp:Content>
