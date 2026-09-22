<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="ROFR.test.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../reports1/css/bootstrap.min.css">
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
      <script src="../reports1/js/bootstrap.min.js"></script>
    
    
       <link rel="stylesheet" type="text/css" href="../reports1/css/font-awesome.css"> 
      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.15.1/moment.min.js"></script>
      <link rel="stylesheet" type="text/css" href="../datepicker/css/bootstrap-datetimepicker.min.css"> 
      <link rel="stylesheet" type="text/css" href="../datepicker/css/bootstrap-datetimepicker-standalone.css"> 
      <script type="text/javascript" src="../datepicker/js/bootstrap-datetimepicker.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
          <div class="row">
            <div class='col-sm-6'>


                <div class="form-group">
                    <div class='input-group date' id='datetimepicker1'>
                        <input type='text' class="form-control" />
                        <span class="input-group-addon">
                            <span class="fa fa-calendar"></span>
                        </span>
                    </div>



                    <div class="input-group mb-3 date" id='datetimepicker2'>
                        <input type="text" class="form-control">
                        <div class="input-group-addon">
                            <span class="fa fa-calendar"></span>
                        </div>
                    </div>


                </div>
            </div>
            <script type="text/javascript">
                $(function () {
                    $('#datetimepicker1').datetimepicker();
                  
                });
            </script>
               <script type="text/javascript">
                   $(function () {
                       $('#datetimepicker2').datetimepicker({
                           format: 'DD/MM/YYYY'
                       
                   });
                });
            </script>
              <script type="text/javascript">
                  function validateDecimal(value)    {
                      var RE =^\d*\.?\d{0,2}$
                      if(RE.test(value)){
                          return true;
                      }else{
                          return false;
                      }
                  }
              </script>
          </div>
       </div>
    
    </form>
</body>

   

</html>
