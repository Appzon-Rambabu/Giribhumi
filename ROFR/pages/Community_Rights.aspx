<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Community_Rights.aspx.cs" Inherits="ROFR.pages.Community_Rights"  EnableEventValidation="false"%>
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
           .panel-body{
	background-color:#fff;
	padding:10px 20px;
	border:1px solid #28a745;
	margin-bottom:20px;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-body"  style="margin-top:150px;">


        <h5 class="text-center text-success mb-4 mt-3">COMMUNITY RIGHTS</h5>




                    
     


        <div class="col-md-12 text-right" id="div_field" runat="server"><span style="color: red">Fields marked as * are mandatory</span></div>

                
        <div class="card border border-success bg-light mt-3" id="div_forest" runat="server">
            <div class="card-body forest-details">
                <h5 class="mb-3">Community Rights</h5>

                <div class="row mt-2 mb-2 justify-content-center">

                       <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="itda" runat="server" Text="ITDA:"></asp:Label>
                                    <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:DropDownList ID="ddl_itda" Style="width: 100%"  runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                  
                     <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="lbldiv" runat="server" Text="Division:"></asp:Label>
                                    <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:DropDownList ID="ddl_division" Style="width: 100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_division_SelectedIndexChanged" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                  
                     <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="com_name" runat="server" Text="Community Name:"></asp:Label>
                                    <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:TextBox ID="txt_com_name" runat="server"  autocomplete="off" onkeypress='mastervalidatenumerics(event)'></asp:TextBox>
                                    
                               
                                </div>
                            </div>
                        </div>


                   
                    </div>
                    <div class="row mt-3 mb-2 justify-content-center">
                        
                         <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbldist" runat="server" Text="District:"></asp:Label> <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList ID="ddl_district" Style="width: 100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged"></asp:DropDownList>
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
                                        <asp:DropDownList ID="ddl_range" runat="server" AutoPostBack="true" Style="width: 100%" OnSelectedIndexChanged="ddl_range_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>


                     
                         <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="com_khata" runat="server" Text="Community Khata No. :"></asp:Label>
                                    <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:TextBox ID="txt_com_khata" runat="server"  autocomplete="off" onkeypress='mastervalidatenumerics(event)'></asp:TextBox>
                                    
                               
                                </div>
                            </div>
                        </div>
                    </div>



                <div class="row mt-3 mb-2 justify-content-left">

                     <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lblmandal" runat="server" Text="Mandal:"></asp:Label>
                                <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList  ID="ddl_mandal" runat="server" AutoPostBack="true" Style="width: 100%" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged"></asp:DropDownList>
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
                                    <asp:DropDownList ID="ddl_beat" runat="server" AutoPostBack="true" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    
                  <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="extent_area" runat="server" Text="Extent Area:"></asp:Label>
                                    <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">

                                    <asp:TextBox ID="txt_extent_area" runat="server" autocomplete="off" onkeypress='compartnovalidate(event)'></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        </div>

                        


                    <div class="row mt-2 mb-2 justify-content-left">
                       
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
                                    <asp:Label ID="no_holders" runat="server" Text="No. of Holders:"></asp:Label>
                                   <span style="color: red">*</span>
                                </div>

                                <div class="col-md-6 value">
                                    
                                    
                                     <asp:TextBox ID="txt_no_holders" runat="server"  autocomplete="off"  ></asp:TextBox>
                                    

                                </div>
                            </div>
                        </div>


                    </div>


                    <div class="row mt-2 mb-2 justify-content-left">
                           <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Lblvillage" runat="server" Text="Village:"></asp:Label>
                                <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:DropDownList  ID="ddl_village" runat="server" AutoPostBack="true" ></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="compart_no" runat="server" Text="Compartment No"></asp:Label>
                                   <%-- <span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:TextBox ID="txt_compart_no" runat="server"  autocomplete="off"></asp:TextBox>

                                   

                                </div>
                            </div>
                        </div>


                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="nature_rights" runat="server" Text="Nature of Community Rights:"></asp:Label>
                                    <%--<span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">
                                     <asp:TextBox ID="txt_nature_rights" runat="server"  autocomplete="off"></asp:TextBox>

                                    

                                </div>
                            </div>
                        </div>
                     

                    </div>

                      <div class="row mt-2 mb-2 justify-content-left">
                           <div class="col-md-4">
                        <div class="row  d-flex justify-content-center">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="pattainam" runat="server" Text="Patta Inam:"></asp:Label>
                                <span style="color: red">*</span>
                            </div>

                            <div class="col-md-6 value">
                                <asp:TextBox ID="txt_patta_inam" runat="server"  autocomplete="off" Text="Community" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="lat" runat="server" Text="Latitude:"></asp:Label>
                                   <%-- <span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">
                                    <asp:TextBox ID="txt_lat" runat="server"  autocomplete="off"></asp:TextBox>

                                   

                                </div>
                            </div>
                        </div>


                        <div class="col-md-4">
                            <div class="row  d-flex justify-content-center">
                                <div class="col-md-6 text-left title">
                                    <asp:Label ID="long" runat="server" Text="Longitude:"></asp:Label>
                                    <%--<span style="color: red">*</span>--%>
                                </div>

                                <div class="col-md-6 value">
                                     <asp:TextBox ID="txt_long" runat="server"  autocomplete="off"></asp:TextBox>

                                    

                                </div>
                            </div>
                        </div>
                     

                    </div>

                   <div class="row mt-2 mb-2 justify-content-left">
                                              <div class="col-md-6">
                         <div class="row  d-flex justify-content-left">
                             <div class="col-md-4 text-left title">
                                 <asp:Label ID="Label1" runat="server" Text="Documents Upload:"></asp:Label>
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
                     
                     <asp:Button ID="Button1"  runat="server" Text="Submit" OnClientClick="return validation()" />&nbsp&nbsp
                     <asp:Button ID="Button2" runat="server" Text="Reset"  />
                 </div>
                </div>
                    
                    
            
                    



                        

                    
                   


          </div>


                      

        
        </div>
</asp:Content>
