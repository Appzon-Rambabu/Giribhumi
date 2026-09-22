<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Update_Farmer.aspx.cs" Inherits="ROFR.pages.Update_Farmer"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>--%>
<%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
   <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>--%>
   <script src="../linksforcdns/Js/jquery.min.js"></script>
     <script type="text/javascript">

        function openModal() {
            $('#exampleModal').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }
      
    </script>
   
  
    <style>
       .required{
           color:red;
       }

   </style>
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
      background-color: #008500 !important;
    }

    .modal-body {
    position: relative;
    -ms-flex: 1 1 auto;
    flex: 1 1 auto;
    padding: 6px !important;
}

    .modal-footer {
    display: -ms-flexbox;
    display: flex;
    -ms-flex-align: center;
    align-items: center;
    -ms-flex-pack: end;
    justify-content: center;
    border-top: 1px solid #dee2e6;
    border-bottom-right-radius: 0.3rem;
    border-bottom-left-radius: 0.3rem;
       padding-top: 21px !important;
    height: 30px !important;
 
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
        <h5 class="text-center text-success mb-4 mt-3">UPDATE/VALIDATE FARMER DETAILS</h5>
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
                        <asp:DropDownList ID="ddl_mandal" Style="width: 100%"  AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="village_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label9" runat="server" Text="Village:"></asp:Label>&nbsp<asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_village" Style="width: 100%"  AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged"></asp:DropDownList>
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
                      
                    <asp:Label ID="lbl101"   Text='<%# Container.DataItemIndex + 1%>' runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="SELECT" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                    
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" CommandArgument='<%#Eval("benficiary_id") %>' CausesValidation="false" OnCheckedChanged="CheckBox1_CheckedChanged" />
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                       <asp:TemplateField HeaderText=" BENEFICIARY ID" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="bid"   Text='<%# Eval("benficiary_id") %>'  runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="HABITATION" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:left">
                  
              <asp:Label Class="txt"  ID="hab" runat="server"   Text='<%# Eval("Habitation") %>' ForeColor="Black" ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                            
               <asp:TemplateField HeaderText="FARMER NAME" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" >
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="farmer"   Text='<%# Eval("ROFR_PATTADAAR") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         
          
                     <asp:TemplateField HeaderText="FATHER NAME" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                      
                  <asp:Label ID="fname"  Text='<%# Eval("Father_Name") %>' runat="server" ForeColor="Black"/>
                      <asp:TextBox runat="server" ID="f_name" Visible="false" Text='<%# Eval("Father_Name")%>'></asp:TextBox>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="CASTE" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="caste_"   Text='<%# Eval("Caste")%>' runat="server" ForeColor="Black"/>
            <asp:TextBox runat="server" ID="caste" Visible="false" Text='<%# Eval("Caste") %>'></asp:TextBox>
                  </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="SUB CASTE" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="subcaste"   Text='<%# Eval("Sub_Caste") %>' runat="server" ForeColor="Black"/>
            <asp:TextBox runat="server" ID="sub_caste" Visible="false" Text='<%# Eval("Sub_Caste") %>'></asp:TextBox>
                  </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="AADHAR NO" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                 <asp:Label ID="adhar"   Text='<%# Eval("Aadhaar_NO")%>' runat="server" ForeColor="Black"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
     <%-- <asp:TemplateField HeaderText="New Aadhaar No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                 <asp:Label ID="newadhar"   Text='<%# Eval("New_Aadhaar_no") %>' runat="server" ForeColor="Black"/>
                       <%--<asp:TextBox runat="server" ID="new_adhar" Visible="false" Text='<%# Eval("New_Aadhaar_no") %>'></asp:TextBox>--%>
             <%--</div>
                      </ItemTemplate>
        </asp:TemplateField> --%>
     

    
                                       <asp:TemplateField HeaderText="DOB" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                 <asp:Label ID="Dob"  Text='<%# Eval("DOB","{0:yyyy-MM-dd}") %>' runat="server" ForeColor="Black"/>
                      <asp:TextBox runat="server" ID="Do_b" Visible="false" Text='<%# Eval("DOB","{0:yyyy-MM-dd}") %>'></asp:TextBox>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                                       <asp:TemplateField HeaderText="GENDER" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                 <asp:Label ID="Gender"  Text='<%# Eval("GENDER") %>' runat="server" ForeColor="Black"/>
                      <asp:TextBox runat="server" ID="Gen_der" Visible="false" Text='<%# Eval("GENDER") %>'></asp:TextBox>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 

                                        <asp:TemplateField HeaderText="MOBILE NO" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                 <asp:Label ID="mobile"  Text='<%# Eval("MOBILE_NO") %>' runat="server" ForeColor="Black"/>
                      <asp:TextBox runat="server" ID="mob_no" Visible="false" Text='<%# Eval("MOBILE_NO") %>'></asp:TextBox>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                                       <asp:TemplateField HeaderText="HOME ADRESS" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                 <asp:Label ID="Address"  Text='<%# Eval("HOME_ADRESS") %>' runat="server" ForeColor="Black"/>
                      <asp:TextBox runat="server" ID="hom_add" Visible="false" Text='<%# Eval("HOME_ADRESS") %>'></asp:TextBox>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                                      
 <asp:TemplateField HeaderText="BANK ACCOUNT NO" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                 <asp:Label ID="banckacnt"   Text='<%# Eval("BankAccountNo") %>' runat="server" ForeColor="Black"/>
                       <asp:TextBox runat="server" ID="banck_acnt" Visible="false" Text='<%# Eval("BankAccountNo")%>'></asp:TextBox>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 


                      <asp:TemplateField HeaderText="IFSC CODE" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                 <asp:Label ID="ifsccode"  Text='<%# Eval("IfscCode") %>' runat="server" ForeColor="Black"/>
                      <asp:TextBox runat="server" ID="ifsc_code" Visible="false" Text='<%# Eval("IfscCode") %>'></asp:TextBox>
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
   
                       <asp:TemplateField HeaderText="BANK NAME" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                 <asp:Label ID="bankname"   Text='<%# Eval("BankName") %>' runat="server" ForeColor="Black"/>
                      <asp:TextBox runat="server" ID="bank_name" Visible="false" Text='<%# Eval("IfscCode") %>'></asp:TextBox>
                        <asp:Label ID="newadhar"   Text='<%# Eval("New_Aadhaar_no") %>' runat="server" ForeColor="Black" Visible="false"/>
            <asp:Label ID="Image1"   Text='<%# Eval("Image1") %>' runat="server" ForeColor="Black" Visible="false"/>
                        <asp:Label ID="Imagepath"   Text='<%# Eval("Imagepath") %>' runat="server" ForeColor="Black" Visible="false"/>
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
            <h5 class="modal-title" id="exampleModalLabel">UPDATE FARMER DETAILS</h5>
           <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return close();">
               --%>
                <asp:ImageButton ID="btn_close" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="Close_Click" />
             
           <%-- </button>--%>
          </div>
          <div class="modal-body" <%--style="max-height:500px;overflow:auto;"--%>>
           
               <div class="col-md-12">
                  <div class="row justify-content-center">

                  <div class="col-md-6 col-lg-6 col-12">

                      
                          <div class="row mb-2">
                          <asp:Label ID="Image" runat="server" Text="Farmer Photo" class="col-md-4 col-form-label"></asp:Label><%--<span style="color: Red;">*</span>--%>
                          <div class="col-md-7">
                               <asp:Image ID="FarmerImage" runat="server"  Width="70px" Height="70px" />
                         </div>
                      </div>
                          <div class="row mb-2">
                          <asp:Label ID="lbl_id" runat="server" Text="Farmer Id" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-7">
                   
                         
                              <asp:TextBox ID="txt_bid" runat="server"  CssClass="form-control" ReadOnly="true"></asp:TextBox></div>
                      </div>
                     
                         <div class="row mb-2">
                          <asp:Label ID="lbl_hab" runat="server" Text="Habitation" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-7">
                              <asp:TextBox ID="txt_hab" runat="server"  CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                         
                      </div>
                       <div class="row mb-2">
                          <asp:Label ID="lbl_farmer" runat="server" Text="Farmer Name" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-7">
                              <asp:TextBox ID="txt_farmer" runat="server"  CssClass="form-control" ReadOnly="true" ></asp:TextBox></div>
                         
                      </div>
                      <div class="row mb-2">
                          <asp:Label ID="lbl_fname" runat="server" Text="Father Name" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-7">
                              <asp:TextBox ID="txt_fname" runat="server"  CssClass="form-control" onkeypress='pattadarnamevalidate(event)' autocomplete="off" ></asp:TextBox></div>
                         
                      </div>
                     
                          
                      <div class="row mb-2">
                          <asp:Label ID="lbl_caste" runat="server" Text="Caste" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-7">
                              <asp:DropDownList ID="ddl_Caste" Style="width: 100%" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddl_Caste_SelectedIndexChanged" runat="server"></asp:DropDownList>
                               <asp:TextBox ID="txt_Caste" runat="server"  CssClass="form-control" autocomplete="off" Visible="false"></asp:TextBox>
                             <%-- <asp:TextBox ID="txt_subcaste" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)' ></asp:TextBox>--%>

                          </div>
                      </div>
                      <div class="row mb-2">
                          <asp:Label ID="lbl_subcaste" runat="server" Text="SubCaste" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-7">
                              <asp:DropDownList ID="ddl_Subcaste" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddl_Subcaste_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                              <asp:TextBox ID="txt_Subcaste" runat="server"  CssClass="form-control" autocomplete="off" Visible="false"></asp:TextBox>
                              <%--<asp:TextBox ID="TextBox1" runat="server"  CssClass="form-control" autocomplete="off" onkeypress='pattadarnamevalidate(event)' ></asp:TextBox>--%>

                          </div>
                         
                      </div>

                      <div class="row mb-2">
                         
                          <asp:Label ID="lbl_adhar" runat="server" Text="Aadhaar NO" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-7">
                    
                        
                              <asp:TextBox ID="txt_adhar" runat="server"  CssClass="form-control"  ReadOnly="true" ></asp:TextBox></div>
                      </div>
                     
                      <div class="row mb-2">
                         
                          <asp:Label ID="lbl_newadhar" runat="server" Text="Enter New Aadhar (If incorrect)" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-7">
                    
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                              <asp:TextBox ID="txt_newadhar" runat="server" CssClass="form-control"  autocomplete="off" MaxLength="12" onkeypress='codevalidate(event)' onchange="return text()" onpaste="return false" ></asp:TextBox></div>
                      </div>
                             
                      </div>
                       <%-- New--%>
                  <div class="col-md-6 col-lg-6 col-12" style="margin-top: 70px!important;">

                      <div class="row mb-2" >
                         
                          <asp:Label ID="Label2" runat="server" Text="Date of Birth:" class="col-md-4 col-form-label" >

                                <%--<asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                          </asp:Label>

                          <div class="col-md-7">
                    
                        
                               <asp:TextBox ID="Apply" runat="server"  type="date" CssClass="form-control" style=" width:100% !important;"></asp:TextBox>
                              
                                <asp:RangeValidator id="rngDate" ControlToValidate="Apply" 
                                             Type="Date" minimumvalue="01/01/1880"
                                             MaximumValue="01/01/2006" 
                                             ErrorMessage="Your Not Eligibil !You must be 18 years old or above "
                                             Display="Dynamic" runat="server" CssClass="required"></asp:RangeValidator>
                         </div>
                      
                         </div>
                    

                           <div class="row mb-2" style="margin-left: -16px !important;">
                          <asp:Label ID="Label3" runat="server" Text="Gender:" class="col-md-5 col-form-label">

                          <%--<asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                          </asp:Label>
                          <div class="col-md-7" >
                              <asp:DropDownList ID="ddl_gender" runat="server" CssClass="form-control"  autocomplete="off" OnSelectedIndexChanged="ddl_gender_SelectedIndexChanged" 
                                  style="width: 100% !important;margin-left: -31px;">
                                   
                                       
                           </asp:DropDownList>
                             <%-- <asp:TextBox ID="txt_gender" runat="server"  CssClass="form-control" autocomplete="off" Visible="false"></asp:TextBox>--%>

                          </div>
                      </div>
                     

                     <div class="row mb-2">
                         
                          <asp:Label ID="Label4" runat="server" Text="Mobile Number:" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-7">
                    
 <asp:HiddenField ID="HiddenField2" runat="server" />
                            <asp:TextBox ID="txt_mob" runat="server" CssClass="form-control" MaxLength="10" autocomplete="off" onkeypress='onlynumbers(event)' onchange="return Mobile()" style="width: 100% !important;"></asp:TextBox>

                          </div>
                      </div>


                            <div class="row mb-2">
                         
                          <asp:Label ID="Label5" runat="server"  Text="Home Address:" class="col-md-4 col-form-label"></asp:Label>
                          <div class="col-md-7">
                    
                              <asp:TextBox ID="Txt_address" runat="server" CssClass="form-control"  autocomplete="off" style="width: 100% !important;"></asp:TextBox>

                          </div>
                      </div>


                        <div class="row mb-2">
                         
                          <asp:Label ID="lbl_bacnt" runat="server" Text="Bank Account No" class="col-md-4 col-form-label" ></asp:Label>
                          <div class="col-md-7">
                    
                        
                              <asp:TextBox ID="txt_bacnt" runat="server" CssClass="form-control"  autocomplete="off" onkeypress='validatebankacnt(event)' style="width: 100% !important;" ></asp:TextBox></div>
                      </div>
                       <div class="row mb-2">
                         
                          <asp:Label ID="lbl_ifsc" runat="server" Text="Ifsc Code" class="col-md-4 col-form-label"  ></asp:Label>
                          <div class="col-md-7">
                    
                        
                              <asp:TextBox ID="txt_ifsc" runat="server" CssClass="form-control" autocomplete="off" onkeypress='validateifsc(event)' style="width: 100% !important;"></asp:TextBox></div>
                      </div>
                        <div class="row mb-2">
                         
                          <asp:Label ID="lbl_bname" runat="server" Text="Bank Name" class="col-md-4 col-form-label" ></asp:Label>
                          <div class="col-md-7">
                    
                        
                              <asp:TextBox ID="txt_bname" runat="server" CssClass="form-control" autocomplete="off" onkeypress='validatebankname(event)' style="width: 100% !important;"></asp:TextBox></div>
                      </div>
                    
                     
                   
                    

                  </div>
              </div>
              </div>
                     
  
          <div class="modal-footer">
           
              <asp:Button ID="mbtn_submit" runat="server" Text="Submit" OnClick="mbtn_click"  />
           
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

      <script>
        var mask;
        function text()
        {
       mask = document.getElementById('<%=txt_newadhar.ClientID %>').value;
     document.getElementById('<%=HiddenField1.ClientID %>').value = mask;
            if (mask != "")
                {
        if (mask.length < 12 ||(mask.length>=13&& mask.length<16))
        {
            alert("Please enter either 12 or 16 digit aadhaar number");
             document.getElementById('<%=txt_newadhar.ClientID %>').value = "";
            return false;
        }
        else if (mask.length == 12) {
            var enteredadhar = mask;
            var status = validateVerhoeff(enteredadhar);
            if (!status)
            {
                if (status == "0") {
                    alert("Please enter a valid Aadhar Number");
                    document.getElementById('<%=txt_newadhar.ClientID %>').value = "";
                }
                return status;
            }
            document.getElementById('<%=txt_newadhar.ClientID %>').value = mask.replace(mask.substring(0, mask.length - 4), 'xxxxxxxx');
                
            }
        else if (mask.length > 12 && mask.length == 16) {
             var enterdadhar = mask;
            var status = validateVerhoeff(enterdadhar);
            if (!status)
            {
                if (status == "0") {
                    alert("Please enter a valid Aadhar Number");
                    document.getElementById('<%=txt_newadhar.ClientID %>').value = "";
                }
                return status;
            }
                document.getElementById('<%=txt_newadhar.ClientID %>').value = mask.replace(mask.substring(0, mask.length - 4), 'xxxxxxxxxxxx');
                
            }
            return mask;
            }
        }
    </script>
<script>
    document.getElementById('<%= txt_newadhar.ClientID %>').disabled = true;
</script>
   
</asp:Content>
   