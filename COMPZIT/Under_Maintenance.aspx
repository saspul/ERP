<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Under_Maintenance.aspx.cs" Inherits="Security_Under_Maintenance" %>

<!DOCTYPE html>
<html>
<title>Compzit</title>
<link rel="shortcut icon" href="/Images/New Images/images/com.ico" type="image/x-icon"/>
<link rel="stylesheet" type="text/css" href="/js/New js/bootstrap/css/bootstrap.css"/>
<link rel="stylesheet" type="text/css" href="/js/New js/bootstrap/css/bootstrap.min.css"/>

<!-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"> -->

<meta name="viewport" content="width=device-width, initial-scale=1.0">
<!-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> -->

<script type="text/javascript" src="/js/New js/js/ajax.js"></script>
<script type="text/javascript" src="/js/New js/js/boot.min.js"></script>

<link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet">
<!---Font_Awesome_section_opened----------->
  <link rel="stylesheet" type="text/css" href="/css/New css/font_awe/css/font-awesome.css"/>
  <link rel="stylesheet" type="text/css" href="/css/New css/font_awe/css/font-awesome.min.css"/>
<!---Font_Awesome_section_closed----------->

<!--------css_Included------->

<link rel="stylesheet" type="text/css" href="/css/New css/afsdez.css"/>
<link rel="stylesheet" type="text/css" href="/css/New css/rec.css"/>
<style>
  .head_undr{width: 100%;height: 100px;margin:auto;float: left;background-color: #fff;text-align: center;padding-top: 30px;}
  .cont_undr{width: 100%;height: auto;margin:auto;margin-top:60px;float: left;}
  .cont_undr h1{width: 100%;height: auto;margin:auto;text-align: center;color:#1b5dab;text-transform: uppercase;font-weight: 600;
                font-size: 28px;margin-bottom:40px;}
  .cont_undr h3{width: 100%;height: auto;margin:auto;text-align: center;color:#b9b9b9;font-weight: 300;
                font-size:18px;margin-bottom:40px;text-transform: capitalize;}
    .undr_inr{width: 60%;height: auto;margin:auto;}
    .foot_undr{width: 100%;height:60px;position: fixed;bottom: 0;background-color:#1b5dab;color: #fff;text-align: center;padding-top:20px; }
    .foot_undr a{color:#73bf44;}
</style>


</head>
<body onLoad="MM_preloadImages('/Images/New Images/images/btn_h.png')">




  <div class="wrapper wr2">

<div class="head_undr">
  <img src="/Images/New Images/images/logo.png">
</div>

<!----------------------------------------------Content_section_opened------------------------------------------------------------->
 <div class="cont_undr">
  <h1> Under Maintenance</h1>
  <!-- <h3>Please comeback after 30  minutes</h3> -->
  <div class="undr_inr">
    <img src="/Images/New Images/images/af_1.png" width="100%" height="auto">
  </div>
 </div>

 <div class="foot_undr" id="divdevelop" runat="server">
  
 </div>

	</div><!--wrapper_closed-->
 <script type="text/javascript"
        src="../../JavaScript/jquery_2.1.3_jquery_min.js"></script>

    
 <script type="text/javascript">
         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {
             setInterval(Autorefresh, 1000);
         });
         function Autorefresh() {
             var WorkSts = '<%=ConfigurationManager.AppSettings["WorkingStatus"]%>';
             if (WorkSts == "1") {
                 window.location = '/Security/Login.aspx';
             }
         }
   </script>
</body>
</html>
