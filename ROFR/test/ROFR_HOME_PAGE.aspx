<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/HOME.Master" AutoEventWireup="true" CodeBehind="ROFR_HOME_PAGE.aspx.cs" Inherits="ROFR.test.ROFR_HOME_PAGE"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="panel panel-body"> <%--<h3 class="text-dark">Welcome to ROFR</h3>--%>


         <div class="row">
        <div id="carouselExampleControls" class="carousel slide d-flex" data-ride="carousel" style="width:100%;height:400px;">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img class="d-block w-100" src="../imagesnew/3.jpg" alt="Giribhumi" style="width:100%;height:400px;">
                </div>
                <div class="carousel-item">
                    <img class="d-block w-100" src="../imagesnew/4.jpg" alt="Giribhumi" style="width:100%;height:400px;">
                </div>
                <%--<div class="carousel-item">
                    <img class="d-block w-100" src="imagesnew/3.png" alt="Third slide">
                </div>--%>
            </div>
            <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>

    </div>


     </div>

</asp:Content>
