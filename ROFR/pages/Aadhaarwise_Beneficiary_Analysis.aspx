<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Aadhaarwise_Beneficiary_Analysis.aspx.cs" Inherits="ROFR.pages.Aadhaarwise_Beneficiary_Analysis" EnableEventValidation="false" %>
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
    </style>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="panel panel-body"  style="margin-top:150px;">


        <h5 class="text-center text-success mb-4 mt-3">AADHAR WISE BENEFICIARY ANALYSIS</h5>
                <div class="row mb-2" id="po" runat="server">
              <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="Label4" runat="server" Text="ITDA:"></asp:Label>&nbsp<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_Itda" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_Itda_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
              <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div4" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="Label1" runat="server" Text="DISTRICT:"></asp:Label>&nbsp<asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_district_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>

      
        </div>
              <div class="card border border-success bg-light" id="div_getdetails" runat="server">
            <div class="card-body aadhar-details">
                 <div class="row mb-2">

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div5" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_records" runat="server" Text="Total Records:"></asp:Label>
                            </div>
                             <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_records" runat="server" Text=""></asp:Label>
                           </div>
                            
                        </div>
                    </div>

                  
                  

                </div>
                 <div class="row mb-2">

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div7" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_adhar" runat="server" Text="Total Records Having  Aadhars:"></asp:Label>
                            </div>
                             <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_adhar" runat="server" Text=""></asp:Label>
                           </div>
                            
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div8" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_uadhar" runat="server" Text="Total Records Having Unique Aadhars:"></asp:Label>
                            </div>

                          <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_uadhar" runat="server" Text=""></asp:Label>
                           </div>
                        </div>
                    </div>

                  

                </div>
                <div class="row mb-2">

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="Lbl_valid_adhar" runat="server" Text="Total Records Having Valid Aadhars:"></asp:Label>
                            </div>
                             <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_valid_adhar" runat="server" Text=""></asp:Label>
                           </div>
                            
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_uvalid_adhar" runat="server" Text="Total Records Having Unique Valid Aadhars:"></asp:Label>
                            </div>

                          <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_uvalid_adhar" runat="server" Text=""></asp:Label>
                           </div>
                        </div>
                    </div>

                  

                </div>

                 <div class="row mb-2">

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div2" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_invadhar" runat="server" Text="Total Records Having Invalid Aadhars:"></asp:Label>
                            </div>
                             <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_invadhar" runat="server" Text=""></asp:Label>
                           </div>
                            
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div6" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_uinvadhar" runat="server" Text="Total Records Having Unique Invalid Aadhars:"></asp:Label>
                            </div>

                          <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_uinvadhar" runat="server" Text=""></asp:Label>
                           </div>
                        </div>
                    </div>

                  

                </div>

                   <div class="row mb-2">

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div9" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_rs_rtgs" runat="server" Text="Total Records Sent To RTGS:"></asp:Label>
                            </div>
                             <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_rs_rtgs" runat="server" Text=""></asp:Label>
                           </div>
                            
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div10" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_uadhar_rtgs" runat="server" Text="Total Unique Aadhar Records Sent to RTGS:"></asp:Label>
                            </div>

                          <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_uadhar_rtgs" runat="server" Text=""></asp:Label>
                           </div>
                        </div>
                    </div>
                       
                 <%--   <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div11" runat="server">
                            <div class="col-md-10 text-left title">
                                <asp:Label ID="lbl_madhar_rtgs" runat="server" Text="Mutiple Records with Same Aadhar Sent To RTGS:"></asp:Label>
                            </div>

                          <div class="col-md-8 value">
                               
                                <asp:Label ID="txt_madhar_rtgs" runat="server" Text=""></asp:Label>
                           </div>
                        </div>
                    </div>--%>
                  

                </div>

                 <div class="row mb-2">

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div12" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_rtgs_success" runat="server" Text="RTGS Payment Success Records:"></asp:Label>
                            </div>
                             <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_rtgs_success" runat="server" Text=""></asp:Label>
                           </div>
                            
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div13" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_rtgs_usadhar" runat="server" Text="Total Unique Aadhar Records in Payment Success:"></asp:Label>
                            </div>

                          <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_rtgs_usadhar" runat="server" Text=""></asp:Label>
                           </div>
                        </div>
                    </div>
                       
                   <%-- <div class="col-md-4">
                        <div class="row  d-flex justify-content-center" id="Div14" runat="server">
                            <div class="col-md-10 text-left title">
                                <asp:Label ID="lbl_rtgs_musadhar" runat="server" Text="Mutiple Records with Same Aadhar in Payment Success:"></asp:Label>
                            </div>

                          <div class="col-md-8 value">
                               
                                <asp:Label ID="txt_rtgs_musadhar" runat="server" Text=""></asp:Label>
                           </div>
                        </div>
                    </div>--%>
                  

                </div>

                 <div class="row mb-2">

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div15" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_rtgs_failed" runat="server" Text="RTGS Payment Failed Records:"></asp:Label>
                            </div>
                             <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_rtgs_failed" runat="server" Text=""></asp:Label>
                           </div>
                            
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div16" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_rtgs_ufailed" runat="server" Text="Total Unique Aadhar Records in Payment Failed:"></asp:Label>
                            </div>

                          <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_rtgs_ufailed" runat="server" Text=""></asp:Label>
                           </div>
                        </div>
                    </div>
                       
                  <%--  <div class="col-md-6">
                        <div class="row  d-flex justify-content-center" id="Div17" runat="server">
                            <div class="col-md-6 text-left title">
                                <asp:Label ID="lbl_rtgs_mufailed" runat="server" Text="Mutiple Records with Same Aadhar in Payment Failed:"></asp:Label>
                            </div>

                          <div class="col-md-6 value">
                               
                                <asp:Label ID="txt_rtgs_mufailed" runat="server" Text=""></asp:Label>
                           </div>
                        </div>
                    </div>
                  --%>

                </div>

                  <div class="row mb-2">
                      
             <div class="col-md-12 mt-10 mb-10">
                 <asp:Repeater ID="Repeater1" runat="server">

                     <HeaderTemplate>


                         <div class="table-responsive bg-white cus-table">
                             <table class="table table-hover table-striped table-bordered" >
                                 <thead style="background-color:cornflowerblue">
                                     <tr style="align-items:center">
                                       

                                         <th>Aadhars Covered in Records</th>
                                         <th>Total Success Aadhars</th>
                                         <th>Total Records</th>
                                         <th>Single Unique Aadhar Covered in Single Beneficiary</th>
                                         <th>Single Beneficiary Count</th>
                                         <th>Multiple Unique Aadhar Covered in Multiple Beneficiary </th>
                                         <th>Multiple Beneficiary Count</th>
                                       
                                       
                                     </tr>
                                 </thead>
                     </HeaderTemplate>

                     <ItemTemplate>
                         <tbody>

                             <tr style="align-items:center; background-color:white">

                           

                                 <td><%#DataBinder.Eval(Container, "DataItem.Adcount")%>  </td>
                                 <td><%#DataBinder.Eval(Container, "DataItem.countaadhar")%>  </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.T")%> </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.SA")%> </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.SB")%> </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.MA")%>  </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.MB")%> </td>



                             
                             </tr>
                         </tbody>
                     </ItemTemplate>
                 
                     <FooterTemplate>
                         </table>
                 </div>
                     </FooterTemplate>

                 </asp:Repeater>


           

         
                      </div>

            </div>
         </div>
            </div>
</asp:Content>
