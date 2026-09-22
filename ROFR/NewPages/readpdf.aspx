<%@ Page Language="C#" MasterPageFile="~/Masters/Adangal.master" AutoEventWireup="true" CodeBehind="readpdf.aspx.cs" Inherits="ROFR.NewPages.readpdf" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Newcdn/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Newcdn/buttons.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/fixedcolumns/4.2.1/css/fixedColumns.dataTables.min.css" rel="stylesheet"/>

     <script type="text/javascript">
         function noBack() {
             window.history.forward()
         }
         noBack();
         window.onload = noBack;
         window.onpageshow = function (evt) { if (evt.persisted) noBack() }
         window.onunload = function () { void (0) }
     </script>

     <style>
        .table-bordered td {
            border: 1px solid #808080;
        }
    </style>
      <style>
   .dt-checkboxes {
float :left;
}
  
    .font-telugu {
      font-family: 'Ramabhadra', sans-serif;
      text-shadow: 2px 2px rgba(0, 0, 0, 0.3);
      font-size: 30px;
    }

   
     .table th {
      text-align: center;
       background-color:#008500 !important;
       }
  
  
  
    .bg-nav{
      background-color: #008500 !important;
    }
     #loading-wrapper {
            background: rgba(255, 255, 255, 0.40) !important;
        }
          
        /* column width size reduce here*/
  .table thead tr:last-child th:nth-child(1) {
    width: 10px!important;
    text-align:right
}
  
  .box1 {
    
    padding: 10px;
    
}

.box2 {
   
    padding: 10px;
    
    
}
 
  </style>

     <script>        
         function handleFileSelect() {
             mtlFileContent = '';
             
             if (!window.File || !window.FileReader || !window.FileList || !window.Blob) {
                 alert('The File APIs are not fully supported in this browser.');
                 return;
             }

             var input = document.getElementById('fileinput');
             if (!input) {
                 alert("Um, couldn't find the fileinput element.");
             }
             else if (!input.files) {
                 alert("This browser doesn't seem to support the `files` property of file inputs.");
             }
             else if (!input.files[0]) {
                 alert("Please select a file before clicking 'Load'");
             }
             else {
                 
                  var file = input.files[0];
                 /*var file = document.getElementById('mtlFileInput').files[0];*/
                 var fr = new FileReader();
                 //fr.onload = (function () {
                 //    return function () {
                 //        mtlFileContent = receivedText;
                 //        mtlFileContent = mtlFileContent.replace('data:;base64,', '');
                 //        mtlFileContent = window.atob(file);
                 //    };
                 //})
                 fr.onload = receivedText;
                 fr.readAsText(file);
                 fr.readAsBinaryString(file); 
                 fr.readAsDataURL(file);
               
             }

             function receivedText() {
                 document.getElementById('editor').appendChild(document.createTextNode(fr.result));
             }
         }

         

     </script>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <span id="userprevilages" style="display:none" runat="server"></span>
         <span id="username" style="display:none" runat="server"></span>
          <span id="ipadress" style="display:none" runat="server"></span>
          <span id="tk" style="display:none" runat="server"></span>
          <label type="text" id="cpt"  style="display:none" runat="server"/>
          <span id="ustart" style="display:none" runat="server"></span>
         <span id="end" style="display:none" runat="server"></span>

 
          <div class="row justify-content-center" style="margin-top:10px">
             
            <div class="col-md-3"></div>
            <div class="col-md-6">
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">READ PDF</h5>
          </div>
              <div class="col-md-3 text-right">
                  
              </div>
             
        </div>
         <br />
              <div class="Updateform"> 
                  <div class="row justify-content-center">
                      <div class="box1">
                         <input type="file" id="fileinput"/>
                      <input type='button' id='btnLoad' value='Load' name="mtlFileInput" onclick='handleFileSelect();' />
                          <div id="editor"></div>
                      </div>
                  </div>
            
            </div>  
         <br />
                                      
    </div>


     
    
    <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
   <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <script src="../Newcdn/vfs_fonts.js"></script>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    
    
    <script src="../Newcdn/tabletoexcel.js"></script>
   
     
</asp:Content>
