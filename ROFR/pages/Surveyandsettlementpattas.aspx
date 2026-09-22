<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Surveyandsettlementpattas.aspx.cs" Inherits="ROFR.pages.Surveyandsettlementpattas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .custom-file {
            overflow: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-body" style="margin-top:150px;">


        <h5 class="text-center text-success mb-4 mt-3">SURVEY AND SETTLEMENT PATTAS</h5>
          <div class="col-md-12 text-right" id="div_field" runat="server"><span style="color: red">Fields marked as * are mandatory</span></div>

                
          <%-- first one--%>
        
        <div class="card row mt-2 mb-2 border border-success bg-light">
            <div class="card-body">
                <div class="row giribhumi-custom-form">

                    <div class="col-md-4 col-12">
                        <div class="row mb-2">
                            <asp:Label ID="lbl_pattadhar" runat="server" CssClass="col-md-6 col-form-label" Text="Mandal Name:"><asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="txt_pattadhar" runat="server" CssClass="col-md-6" autocomplete="off" ></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_father" runat="server" Text="RSR Details:" CssClass="col-md-6 col-form-label" ><asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="txt_father" runat="server" CssClass="col-md-6" autocomplete="off"></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_Adhar" runat="server" Text="settlement No & date of orders:" CssClass="col-md-6 col-form-label" ><asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                             <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:TextBox ID="txt_Adhar" runat="server" CssClass="col-md-6" autocomplete="off" onkeypress='codevalidate(event)'  MaxLength="16" onchange="return text()" style="height: 35px;margin: 10px 0px;"></asp:TextBox>
                           <%-- <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Font-Underline="true">Check</asp:LinkButton>--%>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_bankname" runat="server" Text="R.S.No:" CssClass="col-md-6 col-form-label" ><asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="txt_bankname" runat="server" CssClass="col-md-6" autocomplete="off"></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="Label25" runat="server" CssClass="col-md-6 col-form-label" Text="Land already acquired for any project:"></asp:Label>

                            <asp:TextBox ID="TextBox11" runat="server" CssClass="col-md-6" autocomplete="off" style="height: 35px;margin: 10px 0px;"></asp:TextBox>
                        </div>
                    </div>


                    <div class="col-md-4 col-12">

                        <div class="row mb-2">
                            <asp:Label ID="lbl_poname" runat="server" Text="Village Name:" CssClass="col-md-6 col-form-label" ><asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="txt_poname" runat="server" CssClass="col-md-6" autocomplete="off" ></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_poaccount" runat="server" Text="Name of the settlement Regulations(2 of 69,2 of 70,Inam Abolition Regulations or other):" CssClass="col-md-6 col-form-label" ><asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="txt_poaccount" runat="server" CssClass="col-md-6" autocomplete="off" style="height: 35px;margin: 30px 0px;"></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl" runat="server" Text="Extent(Ac-Cts/Hec-a):" CssClass="col-md-6 col-form-label"><asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="txt_po_number" runat="server" CssClass="col-md-6" autocomplete="off"></asp:TextBox>
                        </div>  
                        
                          <div class="row mb-2">
                            <asp:Label ID="Label33" runat="server" Text="Remarks:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <asp:TextBox ID="TextBox17" runat="server" CssClass="col-md-6" autocomplete="off" ></asp:TextBox>
                        </div>           
                    </div>

                    <div class="col-md-4 col-12">
                        
                         <div class="row mb-2">
                            <asp:Label ID="Label13" runat="server" Text="Orders Passed in whose Favour ?" CssClass="col-md-12 col-form-label" style="font-weight:bold;"></asp:Label>
                        </div>
                         <div class="row mb-2 justify-content-center">


                          <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                             
                          <asp:ListItem Text="N.T" Value="A" Selected="True" ></asp:ListItem>
                               <asp:ListItem Text="Tri" Value="B" ></asp:ListItem>
                               <asp:ListItem Text="Govt" Value="C" ></asp:ListItem>
                           </asp:RadioButtonList>
                        </div>
                         <div class="row mb-2">
                            <asp:Label ID="Label21" runat="server" Text="Government:" CssClass="col-md-6 col-form-label" ><asp:Label ID="Label22" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="TextBox7" runat="server" CssClass="col-md-6" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>


                </div>
            </div>
        </div>

         <%-- second one--%>
           <div class="card row mt-2 mb-2 border border-success bg-light">
            <div class="card-body">
                 <h6>No.& Date in which an appeal was filed & present</h6>
                <div class="row giribhumi-custom-form">
                    
                    <div class="col-md-4 col-12">
                        <div class="row mb-2">
                            <asp:Label ID="Label1" runat="server" Text="Director of survey & settlement order" CssClass="col-md-6 col-form-label mb-2"></asp:Label>


                            <div class="col-md-6">
                                <asp:TextBox ID="TextBox5" placeholder="Appeal No." runat="server" CssClass="" autocomplete="off" Style="height: 35px; margin: 10px 0px;"></asp:TextBox>
                                <input type="date" cssclass="form-control" />

                                <asp:RadioButtonList ID="RadioButtonListm" runat="server" CssClass="mt-2">

                                    <asp:ListItem Text="N.T" Value="A" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Tri" Value="B"></asp:ListItem>
                                    <asp:ListItem Text="Govt" Value="C"></asp:ListItem>
                                </asp:RadioButtonList>

                            </div>
                        </div>

                    </div>


                    <div class="col-md-4 col-12">

                         <div class="row mb-2"> 
                             <asp:Label ID="Label23" runat="server" Text="CCLA ORDER" CssClass="col-md-6 col-form-label mb-2"></asp:Label>
                             <div class="col-md-6">
                                <asp:TextBox ID="TextBox6"  placeholder="Appeal No." runat="server" CssClass="" autocomplete="off" Style="height: 35px; margin: 10px 0px;"></asp:TextBox>
                                <input type="date" cssclass="form-control" />
                          <asp:RadioButtonList ID="RadioButtonListl" runat="server">
                             
                          <asp:ListItem Text="N.T" Value="A" Selected="True"></asp:ListItem>
                               <asp:ListItem Text="Tri" Value="B" ></asp:ListItem>
                               <asp:ListItem Text="Govt" Value="C" ></asp:ListItem>
                           </asp:RadioButtonList>

                            </div>
                        </div>
                    </div>

                    <div class="col-md-4 col-12">
                        <div class="row mb-2">
                            <asp:Label ID="Label7" runat="server" Text="High Court/Supreme Court Order" CssClass="col-md-6 col-form-label mb-2"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="TextBox8"  placeholder="Appeal No." runat="server" CssClass="" autocomplete="off" Style="height: 35px; margin: 10px 0px;"></asp:TextBox>
                                <input type="date" cssclass="form-control" />
                            <asp:RadioButtonList ID="RadioButtonListo" runat="server">

                                <asp:ListItem Text="N.T" Value="A" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Tri" Value="B"></asp:ListItem>
                                <asp:ListItem Text="Govt" Value="C"></asp:ListItem>
                            </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
         <%-- third one--%>
          <div class="card row mt-2 mb-2 border border-success bg-light">
            <div class="card-body">
                <h6>Upload Documents</h6>
                <div class="row giribhumi-custom-form">

                    <div class="col-md-6 col-12">
                 

                         <div class="row mb-2">
                            <asp:Label ID="Label2" runat="server" Text="Upload Settlement officer order:" CssClass="col-md-4 col-form-label"><asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-4"></asp:TextBox>
                                    
                            <div class="custom-file col-md-4">
                                    <input id="File1" type="file" name="file" onchange="show(this)" runat="server" />
                                    <%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                            </div>
                           

                        </div>

                         <div class="row mb-2">
                            <asp:Label ID="Label12" runat="server" Text="Director & Survey & Settlement order:" CssClass="col-md-4 col-form-label"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-4"></asp:TextBox>
                                    
                            <div class="custom-file col-md-4">
                                    <input id="File3" type="file" name="file" onchange="show(this)" runat="server" />
                                    <%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                            </div>
                           

                        </div>

                        

                        

                    </div>


                    <div class="col-md-6 col-12">

                      
                        <div class="row mb-2">
                            <asp:Label ID="Label14" runat="server" Text="CCLA Order:" CssClass="col-md-4 col-form-label"></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-4"></asp:TextBox>
                                    
                            <div class="custom-file col-md-4">
                                    <input id="File4" type="file" name="file" onchange="show(this)" runat="server" />
                                    <%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                            </div>
                           

                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="Label16" runat="server" Text="High Court/SUpreme Court Order:" CssClass="col-md-4 col-form-label"></asp:Label>
                            <asp:TextBox ID="TextBox4" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-4"></asp:TextBox>
                                    
                            <div class="custom-file col-md-4">
                                    <input id="File5" type="file" name="file" onchange="show(this)" runat="server" />
                                    <%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                            </div>
                           

                        </div>
                     

                        
                    </div>
                  

                </div>


                <div class="row mb-2 justify-content-center">
                           <%-- <asp:Button ID="Button3" runat="server" Text="Submit"  OnClick="btn_sumit_Click"  OnClientClick="return  validation()"/>&nbsp &nbsp--%>
                     </div>
                


            </div>
        </div>
        <div>
             
             
              
                

        </div>
          </div>
</asp:Content>
