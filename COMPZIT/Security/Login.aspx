<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Security_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Demo Company</title>
<link rel="shortcut icon" href="/css/Login/image/short-icon.png"/>
<link href="/css/Login/bootstrap-4.0.0-beta.2-dist(1)/css/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="/css/Login/wow-effects/css/libs/animate.css" rel="stylesheet" type="text/css" />
<link href="/css/Login/CSS/style.css" rel="stylesheet" type="text/css"/>

    <style>
        /*--------------------------------------------------for modal CorpList------------------------------------------------------*/
        .modalCorpList {
            display: none;
            position: absolute;
            z-index: 30;
            padding-top: 3.5%;
            left: 0;
            top: 0;
            width: 92%;
            overflow: auto;
            background-color: transparent;
            padding-left: 28%;
        }

        /* Modal Content */
        .modal-contentCorpList {
            /*position: relative;*/
            background-color: #fefefe;
            margin: auto;
            padding: 0;
            /*border: 1px solid #888;*/
            width: 95.6%;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
        }

        .modalCorpList ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            min-height: 280px;
            background-color: rgb(58, 58, 58);
            width: 63%;
        }

        .modalCorpList li {
            font-family: Calibri;
            font-size: 18px;
            padding-bottom: 1%;
            margin-bottom: 1%;
            padding-left: 1%;
            background-color: #4b7200;
            border-radius: 7px;
            border: 2px solid #dbdbdb;
        }

            .modalCorpList li a {
                color:#FFF;
                display: block;
            }

                .modalCorpList li:hover {
                   background-color: #2b98c3;
                     border:2px solid #fff;
                }

        .modalCorpList h2 {
            font-size: 25px;
            color: white;
            margin-left: 16%;
            font-family:Calibri;
        }

    </style>
    <script type="text/javascript" language="javascript">
        // for not allowing <> tags
        function isTag(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        function controlTab(obj, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 9) {
                document.getElementById(obj).focus();
                return false;
            }

            else {
                return true;
            }
        }

        function getdetails(href) {
            window.location = href;
            return false;
        }

        function ShowCorpList() {

            document.getElementById("myModalCorpList").style.display = "block";
            document.getElementById("freezelayer").style.display = "";

        }

    </script>

    <script type="text/javascript">



        function Valid() {
            // replacing < and > tags
            var UserIdWithoutReplace = document.getElementById("txtEmailId").value;
            var UserIdreplaceText1 = UserIdWithoutReplace.replace(/</g, "");
            var UserIdreplaceText2 = UserIdreplaceText1.replace(/>/g, "");
            document.getElementById("txtEmailId").value = UserIdreplaceText2;

            var PasswordWithoutReplace = document.getElementById("txtPassword").value;
            var PasswordreplaceText1 = PasswordWithoutReplace.replace(/</g, "");
            var PasswordreplaceText2 = PasswordreplaceText1.replace(/>/g, "");
            document.getElementById("txtPassword").value = PasswordreplaceText2;


            var TxtMailAreaWithoutReplace = document.getElementById("TxtMailArea").value;
            var TxtMailAreareplaceText1 = TxtMailAreaWithoutReplace.replace(/</g, "");
            var TxtMailAreareplaceText2 = TxtMailAreareplaceText1.replace(/>/g, "");
            document.getElementById("TxtMailArea").value = TxtMailAreareplaceText2;


            var ResendMailID = document.getElementById("TxtMailArea").value;


            if (ResendMailID == "") {
                alert("Sorry, Please enter mail id for sending mail!");
                document.getElementById("TxtMailArea").focus();
                return false;
            }
            if (ValidateEmailSend() == false) {
                alert("Sorry, Please enter a valid mail id for sending mail!");
                document.getElementById("TxtMailArea").focus();
                return false;

            }
            $("#myDIV").slideUp();
            return true;
        }
        function Validation() {
            // replacing < and > tags
            var UserIdWithoutReplace = document.getElementById("txtEmailId").value;
            var UserIdreplaceText1 = UserIdWithoutReplace.replace(/</g, "");
            var UserIdreplaceText2 = UserIdreplaceText1.replace(/>/g, "");
            document.getElementById("txtEmailId").value = UserIdreplaceText2;

            var PasswordWithoutReplace = document.getElementById("txtPassword").value;
            var PasswordreplaceText1 = PasswordWithoutReplace.replace(/</g, "");
            var PasswordreplaceText2 = PasswordreplaceText1.replace(/>/g, "");
            document.getElementById("txtPassword").value = PasswordreplaceText2;


            var TxtMailAreaWithoutReplace = document.getElementById("TxtMailArea").value;
            var TxtMailAreareplaceText1 = TxtMailAreaWithoutReplace.replace(/</g, "");
            var TxtMailAreareplaceText2 = TxtMailAreareplaceText1.replace(/>/g, "");
            document.getElementById("TxtMailArea").value = TxtMailAreareplaceText2;

            var USERNAME = document.getElementById("txtEmailId").value;

            var PASSWORD = document.getElementById("txtPassword").value;
            if (USERNAME == "") {
                alert("Sorry, Please enter valid user id for login!");
                document.getElementById("txtEmailId").focus();
                return false;
            }
            if (PASSWORD == "") {
                alert("Sorry, Please enter valid password for login!");
                document.getElementById("txtPassword").focus();
                return false;
            }
        }

        function IsValidEmail(email) {
            var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            return expr.test(email);
        };
        function ValidateEmail() {
            var email = document.getElementById("txtEmailId").value;
            if (!IsValidEmail(email)) {

                return false;
            }
            return true;
        } function ValidateEmailSend() {
            var email = document.getElementById("TxtMailArea").value;
            if (!IsValidEmail(email)) {

                return false;
            }
            return true;
        }

        function ShowMailArea() {
            document.getElementById("divSendMailTextArea").style.visibility = "visible";
        }
       
    </script>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            if (document.getElementById("<%=hiddenCorpList.ClientID%>").value == "") {
                document.getElementById("myModalCorpList").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
            }
        });
    </script>
</head>
<body>
    
     <form id="Form1" style="margin-top:4%;" runat="server">
     
<div id="MainDiv" class="col-lg-4 col-md-6 col-sm-12 bluee align-01 wow slideInDown" runat="server"> 
   <div class="white-box">
     <img style="padding-top: 4%;" src="/css/Login/image/logo.png"/>
   </div>
  

        <asp:HiddenField ID="hiddenCorpList" runat="server" />
 <div class="input-group hover-text">
    <span class="input-group-addon"><img src="/css/Login/image/user-id-icon.png" /></span>
        	<input class="effect-1" type="text" placeholder="User Id" id="txtEmailId" runat="server" maxlength="100">
            <span class="focus-border"></span>
        
        </div>
        
        
<div class="input-group hover-text">
    <span class="input-group-addon"><img src="/css/Login/image/password-icon.png" /></span>
        	<input class="effect-1" type="password" placeholder="Password" id="txtPassword" runat="server" maxlength="100">
            <span class="focus-border"></span>
        </div>
       
<!-- Squared THREE -->
<label class="checkbox-1">
<div class="squaredThree">
	<input type="checkbox" value="None" id="squaredThree" name="check" runat="server" />
	<label for="squaredThree"></label>
</div>
    </label> <span class="rem-div">  Remember me</span>

        <asp:Button ID="btnLogin" runat="server" text="SIGN IN" class="btn btn-change9 sign-in" OnClientClick="return Validation();"  OnClick="btnLogin_Click" />

         <div id="divSendMailAll" runat="server" class="col-xs-12 col-md-12 col-sm-12 text-center" style=" letter-spacing:.5px;font-size:14px;margin-top:63px;color:#666; text-transform: uppercase;">
         <span style="color:#00aeff;cursor:pointer;" id="me"> Send</span> Verification Mail, If not Received!
         </div>
         <div class="input-group hover-text animated" id="myDIV" style="z-index:100;">
        	 <input style="float:left;width:54%;" class="effect-1"  type="text" placeholder="Email" id="TxtMailArea" runat="server" maxlength="100">

              <asp:Button runat="server" class="btn btn-change10 sign-in-10" id="hide_mydiv" OnClick="hide_mydiv_Click" OnClientClick="return Valid();" style="height:37px;background-color:#00aeff;float:left;" Text="SEND" />

        </div>
       <div id="divOR" runat="server" class="col-xs-12 col-md-12 col-sm-12 text-center" style="margin-top:10px;color:#666;">OR</div>
    
      <button  id="divNewRegister" class="btn btn-change10 sign-in-10" runat="server" onclick="location.href='/Master/gen_Org_Parking/gen_Org_Parking_Reg.aspx';return false;" data-tooltip="Not Registered Yet?">REGISTER</button>
      <button id="BtnCand" class="btn btn-change10 sign-in-10" runat="server"  onclick="location.href='/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx';return false;" data-tooltip="Select this Link to login as Candidate.">CANDIDATE</button>

     
    </div>
        <!-- Trigger/Open The Modal -->

            <!-- The Modal Loading MAIL -->
            <div id="myModalCorpList" class="modalCorpList">
                <div>
                    <!-- Modal content -->
                    <div id="divCorpList" runat="server">
                    </div>
                </div>
            </div>


            <div style="width: 100% !important; position: fixed; top: 0px; left: 0px; right: 0px; bottom: 0px; background: rgb(57, 57, 57) none repeat scroll 0% 0%; opacity: 0.9; z-index: 29; height: auto !important;display:none;"
                class="freezelayer" id="freezelayer">
            </div>

  </form> 
     <footer class="page-footer font-small blue pt-4 mt-4">
    <div id="divdevelop" class="footer-copyright text-center" style="font-size:13px;" runat="server">
    </div>
</footer>
   
<script src="/css/Login/bootstrap-4.0.0-beta.2-dist(1)/js/jquery.min.js"></script>
<script src="/css/Login/bootstrap-4.0.0-beta.2-dist(1)/js/bootstrap.min.js"></script>
<script>
    function getData() { return false; }
    $("#me").click(function () {
        $("#myDIV").slideDown(1000, function () { $("#TxtMailArea").focus(); })
    });
    //$("#hide_mydiv").click(function () { $("#myDIV").slideUp(); });
</script>
<script language="javascript" src="/css/Login/wow-effects/dist/wow.min.js"></script>
<script>
    //wow = new WOW(
	//{
	//}
	//);
    //wow.init();
</script>
    <style>
   
.mt-4, .my-4 {
    margin-top: 0rem !important;
}
    </style>
</body>
</html>
