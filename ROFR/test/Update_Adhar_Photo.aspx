<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Update_Adhar_Photo.aspx.cs" Inherits="ROFR.test.Update_Adhar_Photo" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-body" style="margin-top:150px;"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
            <h5 class="text-center text-success mb-2 mt-3">Upload Farmer Photo From Adhar Service</h5>
         <div class="row mb-1 mt-1 justify-content-center">
                 <div class="col-md-4">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-3 text-center pl-0 pr-0">
                        <asp:Label ID="Label4" runat="server" Text="ITDA:"></asp:Label>&nbsp<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_itda" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_Itda_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                
           </div>
                     </div>
                 <div class="col-md-4">
                <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                    <div class="col-md-3 text-center pl-0 pr-0">
                        <asp:Label ID="Label1" runat="server" Text="Select records:"></asp:Label>&nbsp<asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                           <asp:DropDownList ID="ddl_records" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlrecords_OnSelectedIndexChanged"></asp:DropDownList>
                    </div>
                
           </div>
                     </div>
            <div class="col-md-4">


                <div class="row d-flex justify-content-center">

                    <div class="col-md-3 ml-0 mr-0">
                       <%--  <button type="button" class="btn btn-sm btn-success"><i class="fa fa-search"></i> Search</button>--%>
                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success" AutoPostBack="true" OnClick="Excel_Click" runat="server" Text="Upload" />
                    </div>
                </div>


            </div>
        </div>
        </div>

</asp:Content>
