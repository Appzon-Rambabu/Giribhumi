<%@ Page Title="Forest Division Master Details" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Forest_Division_Master.aspx.cs" Inherits="ROFR.test.Forest_Division_Master" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
     function DisableBackButton() {
       window.history.forward()
      }
     DisableBackButton();
     window.onload = DisableBackButton;
     window.onpageshow = function(evt) { if (evt.persisted) DisableBackButton() }
     window.onunload = function() { void (0) }
 </script>
     <script type="text/javascript">
    function Validate() {
        var district = document.getElementById('<%=ddl_district.ClientID %>').value;
       
       
        if (district== "0") {
            
            alert("Please select District!");
            return false;
        }
      
     
       
    }
</script>
       <style type="text/css">
    /*.panel-group .panel {
		border-radius: 0;
		box-shadow: none;
		border-color: #EEEEEE;
	}

	.panel-default > .panel-heading {
		width: auto;
	}

	.panel-title {
		font-size: 14px;
		background: orange;
    padding: 10px;
    z-index: 2;
    position: relative;
    left: 30px;
    top: 20px;
	color:#000;
	
		
	}
	
	.panel-title a:hover {color:#000;}
	.panel-title a:focus {color:#000;}

	.panel-title > a {
		
	}

	.more-less {
		margin-left:10px;
		color: #212121;
	}
	.clps-heading{
		background: orange;
    padding: 10px;
    z-index: 999;
    position: relative;
    left: 30px;
    top: 10px;
	}
	.clps-heading:hover {color:#000;}
	.clps-heading:focus {color:#000;}

	
	
	.panel-group .panel-body {
        display: block;
    margin-left: 10px;
    margin-right: 20px;
    padding-top: 2.35em;
    padding-bottom: 0.625em;
    padding-left: 0.75em;
    padding-right: 0.75em;
    border: 2px groove burlywood;
	
}
.panel-title > a:before {
    float: right !important;
    font-family: FontAwesome;
    content:"\f068";
	margin-left:10px;
}
.panel-title > a.collapsed:before {
    float: right !important;
    content:"\f067";
	margin-left:10px;
}
.panel-title > a:hover, 
.panel-title > a:active, 
.panel-title > a:focus  {
    text-decoration:none;
}*/
.headertable tr td {
       
       border:1px solid #eee !important;}

 
.headertable { overflow-y: auto; height:auto; max-height:300px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #38a1d2;}

.headertable .aftr th{position: sticky;top: 49x;}

         </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="panel panel-body" style="margin-top:150px;"> 

    <div class="row">
        <div class="col-md-4">
            
        </div><div class="col-md-4">

            <div class="table-responsive">


            <table class="table">
  <thead>
    <tr>
      <h5 class="text-center text-success">Revenue District - Forest Division Master</h5>
    </tr>
  </thead>
  <tbody>
    <tr>
        
      <td><asp:Label ID="txt_district"  runat="server" Text="District:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
      <td><asp:DropDownList ID="ddl_district" style="width:150px" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged"  runat="server"></asp:DropDownList>
            </td>
    </tr>
      
    
    <tr>
        <td class="text-center">&nbsp;</td>
      <td><asp:Button ID="btn_submit" OnClick="btnsend_Click" runat="server" OnClientClick="return Validate()" Text="Submit"  /></td>
      
    </tr>
      
  </tbody>
</table>

           
            
            
            
             
        </div>
        </div>

        <div class="col-md-4">
            
        </div>


        

       

    </div>

<%--        <div class="row">
        
<div class="container-fluid">
       
       

   
          <div class="panel-group" role="tablist" aria-multiselectable="true" id="panel" runat="server" style="width:99%;">

    <div class="panel panel-default">
        <div class="panel-heading" role="tab" id="headingOne">
            <h4 class="panel-title">
								<a class="collapsed" role="button" data-toggle="collapse" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
									Forest Division Master Details
								</a>
							</h4>
        </div>
        <div class="panel-body">
            <div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne" aria-expanded="false" style="height: 0px;">--%>



    <asp:Repeater ID="Repeater1" runat="server"  >

            <HeaderTemplate>
              <%--  <div class="headertable">
                   
                
            <table class="table table-bordered table-striped" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <thead class="text-white" style="background-color:#38a1d2; ">
                        <tr>--%>
                          <div class="">
             <table id="gvMain" style=" border-collapse: collapse;" align="center" border="1" bordercolor="lightgrey">
                        
                            <thead class="text-white"  >
                        <tr class="GridViewScrollHeader"  style="background-color: #38a1d2;"> 
                            
                         <th style="text-align: center" >S.No<br />(1)</th> 
                    <th style="text-align: center" >LGD  DISTRICT  CODE<br />(2)</th> 

                        <th style="text-align: center" >REVENUE DISTRICT CODE <br />(3)</th>  
                    
                         <th style="text-align: center" >FOREST DIVISION CODE<br />(4)</th>    
                   
                        
                        <th style="text-align: center" >FOREST DIVISION NAME<br />(5)</th>   
                       
      
                    </tr>
          </thead>
            </HeaderTemplate>

            <ItemTemplate>
                  <tbody>

                <tr class="GridViewScrollItem">
                    <td style="text-align: center" > <%#DataBinder.Eval(Container, "DataItem.Sno")%>  </td>
                     <td style="text-align: center" > <%#DataBinder.Eval(Container, "DataItem.LGD_DISTRICT_CODE")%>  </td>

                    <td style="text-align: center" >  <%#DataBinder.Eval(Container, "DataItem.REV_DISTRICT_CODE")%>  </td>

                    <td style="text-align: center" >  <%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_CODE")%> </td>

                  <td style="text-align: center" >  <%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_NAME")%>  </td>

                 

                 
                </tr>
                        </tbody>
            </ItemTemplate>

            <AlternatingItemTemplate>
                  <tbody>
              <tr style="background-color:#AED6FF" class="GridViewScrollItem">
                    <td style="text-align: center" > <%#DataBinder.Eval(Container, "DataItem.Sno")%>  </td>
                     <td style="text-align: center" > <%#DataBinder.Eval(Container, "DataItem.LGD_DISTRICT_CODE")%>  </td>

                    <td style="text-align: center" >  <%#DataBinder.Eval(Container, "DataItem.REV_DISTRICT_CODE")%>  </td>

                    <td style="text-align: center" >  <%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_CODE")%> </td>

                  <td style="text-align: center" >  <%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_NAME")%>  </td>

                  

                </tr>
  </tbody>
            </AlternatingItemTemplate>

            <FooterTemplate>

                </table>
                 </div>
            </FooterTemplate>

        </asp:Repeater>
            
    </div>
     <%--   </div>
    </div>

   
</div></div> 
        </div>
     </div>--%>
</asp:Content>
