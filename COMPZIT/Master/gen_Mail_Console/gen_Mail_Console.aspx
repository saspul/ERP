<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Mail_Console.aspx.cs" Inherits="Master_gen_Mail_Console_gen_Mail_Console" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/hcm_ns.css" rel="stylesheet" />
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {

                return false;
            }
            else {
                return true;
            }
        } function CheckSubmitZero() {
            submit = 0;
        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            if (document.getElementById("cphMain_lblEntry").innerText == "EDIT MAIL SETTINGS") {
                $(".edit").css("display", "block");
            }
            if (document.getElementById("cphMain_lblEntry").innerText != "ADD MAIL SETTINGS") {
                $(".add").css("display", "none");
            }
        });
    </script>
     <script>
         //start-0006
         var confirmbox = 0;

         function IncrmntConfrmCounter() {
             confirmbox++;
         }
         function ConfirmMessage() {
             if (confirmbox > 0) {
                 ezBSAlert({
                     type: "confirm",
                     messageText: "Do you want to leave this page?",
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         window.location.href = "gen_Mail_ConsoleList.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 window.location.href = "gen_Mail_ConsoleList.aspx";

             }
             return false;
         }
         function AlertClearAll() {
             if (confirmbox > 0) {
                 ezBSAlert({
                     type: "confirm",
                     messageText: "Do you want to clear all the data from this page?",
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         window.location.href = "gen_Mail_Console.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 window.location.href = "gen_Mail_Console.aspx";
                 return false;
             }
             return false;
         }
    </script>
    <script type="text/javascript">
        function SuccessConfirmation() {
            $("#success-alert").html("Email details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Email details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function HideLoading() {
            document.getElementById('divLoading').style.display = "";
        }
        function ErrorMsg() {
            $("#divWarning").html("Some error occured.Please review entered information !");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function AmountCheck(control) {
            //     var ret = true;
            var txtPerVal = control.value;
             if (txtPerVal == "") {
                 return false;
             }
             else {
                 if (!isNaN(txtPerVal) == false) {
                     control.value = "";
                    return false;
                }
                else {
                    //var amt = parseFloat(txtPerVal);
                    //var num = amt;
                    //var n = 0;
                    // for floatting number adjustment from corp global
                    //var FloatingValue = control.value;
                    //if (FloatingValue != "") {
                        //var n = num.toFixed(FloatingValue);
                    //}
                    //control.value = n;

            }
        }
    }
        function textCheck(field, maxlimit) {
            var text = field.value;
            var replaceText1 = text.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            field.value = replaceText2;
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }

        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }

        function Validate() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags

            var PasswordWithoutReplace = document.getElementById("<%=txtPassword.ClientID%>").value;
            var replaceText1 = PasswordWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPassword.ClientID%>").value = replaceText2;

            var EmailWithoutReplace = document.getElementById("<%=txtEmail.ClientID%>").value;
            var EmailreplaceText1 = EmailWithoutReplace.replace(/</g, "");
            var EmailreplaceText2 = EmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmail.ClientID%>").value = EmailreplaceText2;

            var ConfirmPasswordWithoutReplace = document.getElementById("<%=txtConfirmPassword.ClientID%>").value;
            var PassWordreplaceText1 = ConfirmPasswordWithoutReplace.replace(/</g, "");
            var PassWordreplaceText2 = PassWordreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtConfirmPassword.ClientID%>").value = PassWordreplaceText2;

            var CodeWithoutReplace = document.getElementById("<%=txtInServiceName.ClientID%>").value;
            var CodereplaceText1 = CodeWithoutReplace.replace(/</g, "");
            var CodereplaceText2 = CodereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtInServiceName.ClientID%>").value = CodereplaceText2;

            var PortWithoutReplace = document.getElementById("<%=txtInPort.ClientID%>").value;
            var PortreplaceText1 = PortWithoutReplace.replace(/</g, "");
            var PortreplaceText2 = PortreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtInPort.ClientID%>").value = PortreplaceText2;

            var ServiceWithoutReplace = document.getElementById("<%=txtOutServerName.ClientID%>").value;
            var ServicereplaceText1 = ServiceWithoutReplace.replace(/</g, "");
            var ServicereplaceText2 = ServicereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOutServerName.ClientID%>").value = ServicereplaceText2;

            var Port2WithoutReplace = document.getElementById("<%=txtOutPort.ClientID%>").value;
            var Port2replaceText1 = Port2WithoutReplace.replace(/</g, "");
            var Port2replaceText2 = Port2replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOutPort.ClientID%>").value = Port2replaceText2;

            var signWithoutReplace = document.getElementById("<%=txtSignature.ClientID%>").value;
            var signreplaceText1 = signWithoutReplace.replace(/</g, "");
            var signreplaceText2 = signreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtSignature.ClientID%>").value = signreplaceText2;

            document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtPassword.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtConfirmPassword.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtInServiceName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtInPort.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOutServerName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOutPort.ClientID%>").style.borderColor = "";
            document.getElementById("<%=cbxSecurity.ClientID%>").style.borderColor = "";

            document.getElementById('ErrorMsgConfirmPassword').style.display = "none";
            //  alert(activeViewIndex);
            var Email = document.getElementById("<%=txtEmail.ClientID%>").value;
            var Password = document.getElementById("<%=txtPassword.ClientID%>").value;
            var ConfirmPassword = document.getElementById("<%=txtConfirmPassword.ClientID%>").value;
            var ServiceName = document.getElementById("<%=txtInServiceName.ClientID%>").value.trim();
            var SecondServiceName = document.getElementById("<%=txtOutServerName.ClientID%>").value.trim();
            var Port = document.getElementById("<%=txtInPort.ClientID%>").value;
            var SecondPort = document.getElementById("<%=txtOutPort.ClientID%>").value;
            var PasswordValidation = document.getElementById("<%=HiddenPassword.ClientID%>").value;
            var LoadCheck = document.getElementById("<%=cbxChecking.ClientID%>");

            document.getElementById('ErrorMsgUsrEmail').style.display = "none";



            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;


            if (SecondPort == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtOutPort.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtOutPort.ClientID%>").focus();
                ret = false;
            }
            if (SecondServiceName == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtOutServerName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtOutServerName.ClientID%>").focus();
                ret = false;
            }
            if (Port == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtInPort.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtInPort.ClientID%>").focus();
                ret = false;
            }
            if (ServiceName == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtInServiceName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtInServiceName.ClientID%>").focus();
                ret = false;
            }
            if (ConfirmPassword != Password) {
                document.getElementById('divpassword').style.display = "";
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById('ErrorMsgConfirmPassword').style.display = "";
                document.getElementById("<%=txtConfirmPassword.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtConfirmPassword.ClientID%>").focus();
                ret = false;
            }
            if (PasswordValidation == 0) {
                if (ConfirmPassword == "") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtConfirmPassword.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtConfirmPassword.ClientID%>").focus();
                    ret = false;
                }
                if (Password == "") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtPassword.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtPassword.ClientID%>").focus();
                    ret = false;
                }
            }

            if (Email == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtEmail.ClientID%>").focus();
                ret = false;
            }

            if (!filter.test(Email)) {
                var ErrorMsg = document.getElementById('ErrorMsgUsrEmail').style.display = "";
                document.getElementById("<%=txtEmail.ClientID%>").focus();
                document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                ret = false;
            }
           

            if (ret == true) {
                if (LoadCheck.checked) {
                    document.getElementById('divLoading').style.display = "block";
                }
            }
            if (ret == false) {
                CheckSubmitZero();

            }
            return ret;
        }
        function ChangePass() {
            IncrmntConfrmCounter();
            var PasswordWithoutReplace = document.getElementById("<%=txtPassword.ClientID%>").value;
            var replaceText1 = PasswordWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPassword.ClientID%>").value = replaceText2;

            var ConfirmPasswordWithoutReplace = document.getElementById("<%=txtConfirmPassword.ClientID%>").value;
            var PassWordreplaceText1 = ConfirmPasswordWithoutReplace.replace(/</g, "");
            var PassWordreplaceText2 = PassWordreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtConfirmPassword.ClientID%>").value = PassWordreplaceText2;

            document.getElementById("<%=txtPassword.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtConfirmPassword.ClientID%>").style.borderColor = "";

            document.getElementById('ErrorMsgConfirmPassword').style.display = "none";

            var Password = document.getElementById("<%=txtPassword.ClientID%>").value;
            var ConfirmPassword = document.getElementById("<%=txtConfirmPassword.ClientID%>").value;
            var PasswordValidation = document.getElementById("<%=HiddenPassword.ClientID%>").value;

            if (ConfirmPassword != Password) {
                document.getElementById('divpassword').style.display = "";
                document.getElementById('ErrorMsgConfirmPassword').style.display = "";
                document.getElementById("<%=txtConfirmPassword.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtConfirmPassword.ClientID%>").focus();
            }
            if (PasswordValidation == 0) {
                if (ConfirmPassword == "") {
                    document.getElementById("<%=txtConfirmPassword.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtConfirmPassword.ClientID%>").focus();
                }
                if (Password == "") {
                    document.getElementById("<%=txtPassword.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtPassword.ClientID%>").focus();
                }
            }
        }
        function ViewMailSettings() {
            document.getElementById('ContactHeadOne').style.display = "";
        }
        function SucessfullUpdation() {
            alert('Email Details Updated Sucessfully');
            window.close();
        }
    </script>
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

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //at enter
            if (keyCodes == 13) {
                return false;
            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
            }
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

        function DuplicationEmail() {
            $("#divWarning").html("Duplication error!. Email address can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
        }

        function WrongInputServer() {
            $("#divWarning").html("Can not found the server. Your given information is not correct ");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtInServiceName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtInPort.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=cbxSecurity.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtInServiceName.ClientID%>").focus();
         }

        function WrongOutputServer() {
            $("#divWarning").html("Can not found the server. Your given information is not correct");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtOutServerName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtOutPort.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtOutServerName.ClientID%>").focus();
        }

        function WrongEmailPassword() {
            $("#divWarning").html("Cant not authenticate! Wrong email or password");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtPassword.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtPassword.ClientID%>").focus();
        }

        function VisiblePassword() {
            var $noCon = jQuery.noConflict();
            if ($noCon('#divpassword:visible').length == 0) {
                document.getElementById('divpassword').style.display = "";
                document.getElementById('headingCaption').style.fontWeight = "";
            }
            else {
                document.getElementById('divpassword').style.display = "none";
                document.getElementById('headingCaption').style.fontWeight = "bold";
            }
            return false;
        }

        function HidePassWord() {
            document.getElementById('divpassword').style.display = "none";
            document.getElementById('divCaption').style.display = "";
        }

        function HidePassWordAll() {
            document.getElementById('divpassword').style.display = "none";
            document.getElementById('divCaption').style.display = "none";
        }

    </script>
    <style>
          .model {
    display: none; /* Hidden by default */
    position: fixed; /* Stay in place */
    z-index: 1; /* Sit on top */
    padding-top: 100px; /* Location of the box */
    left: 0;
    top: 0;
    width: 100%; /* Full width */
    height: 100%; /* Full height */
    overflow: auto; /* Enable scroll if needed */
    background-color: rgb(0,0,0); /* Fallback color */
    background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
}
            .error {       
               color: red;
               font-size: small;
                font-family: Calibri;
           }   
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:HiddenField ID="hiddenDivId" runat="server" />
    <asp:HiddenField ID="hiddenMailId" runat="server" />
    <asp:HiddenField ID="HiddenPassword" runat="server" Value="0" />
        <div id="divLoading" class="model"  >
            <div class="eachform" style="width:70%; height:70%; padding-left:45%; padding-top:12%;">
                 <img src="../../Images/Other Images/LoadingMail.gif" style="width:18%;" />
                 </div>
    </div>
    <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
      <li><a href="gen_Mail_ConsoleList.aspx">Mail Settings</a></li>
        <li id="lblEntryB" runat="server" class="active">Add Mail Settings</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>

    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add Mail Settings</h2>

           <div class="form-group fg4 fg2_mr sa_1">
                <label class="form1 mar_bo">
                  <span class="button-checkbox">
                    <button type="button" class="btn-d" data-color="p" onclick="myFunct()" ng-model="all"></button>
                    <input type="checkbox" class="hidden" id="cbxChecking"  runat="server" checked="checked"/>
                  </span>
                  <p class="pz_s">Perform Server Configuration Test</p>
                </label>
                
              </div>

              <div class="clearfix"></div>

              <div class="free_sp" style="margin-top:0px;"></div>

             <div class="form-group fg2 sa_fg1">
                <label for="email" class="fg2_la1">Enquiry Mail ID:<span class="spn1">*</span></label>
                  <asp:TextBox autocomplete="off" ID="txtEmail" class="form-control fg2_inp1 inp_mst" runat="server" MaxLength="100" placeholder="Enquiry Mail ID"></asp:TextBox>
                <p class="error" id="ErrorMsgUsrEmail" style="display:none;">Please enter valid email address</p>
              </div>

              <div class="form-group fg2 sa_fg1">
               <label for="email" class="fg2_la1">Mail Protocol:<span class="spn1">*</span></label>
                   <asp:DropDownList ID="ddlMailProtocol" class="form-control fg2_inp1 inp_mst"  runat="server" ></asp:DropDownList>     
              </div>






             <div class="clearfix edit" style="display:none;"></div>
              <div class="devider edit" style="display:none;"></div>
              <div class="fg2" id="divCaption" style="display:none;">
               <label for="email" class="fg2_la1">Edit Password:<span class="spn1"></span></label>
                <div class="check1 tr_l">
                  <div class="">
                    <label class="switch">
                      <input type="checkbox" class="bn" onclick="VisiblePassword()"/>
                      <span class="slider_tog round"></span>
                    </label>
                  </div>
                </div>
              </div>

           <div id="divpassword" >
              <div class="form-group fg2 sa_fg1">
                <label for="email" class="fg2_la1">Password:<span class="spn1">*</span></label>
                   <asp:TextBox ID="txtPassword" class="form-control fg2_inp1 inp_mst" placeholder="Password" runat="server" MaxLength="50" TextMode="Password" onchange="return ChangePass();"></asp:TextBox>
              </div>

               <div class="form-group fg2 sa_fg1">
                <label for="email" class="fg2_la1">Confirm Password:<span class="spn1">*</span></label>
                    <asp:TextBox ID="txtConfirmPassword" class="form-control fg2_inp1 inp_mst" placeholder="Confirm Password" runat="server" MaxLength="50" TextMode="Password" onkeyup="return ChangePass();"></asp:TextBox>
                <p class="error" id="ErrorMsgConfirmPassword" style="display:none;width:100%;float:left;">Both passwords must be same</p>
              </div>
               </div>

           <div class="clearfix edit" style="display:none;"></div>
           <div class="devider edit" style="display:none;"></div>


            <div class="clearfix add"></div>





             <div class="form-group fg2 fg2_mr sa_fg1">
                <label for="email" class="fg2_la1">In-Server Name:<span class="spn1">*</span></label>
                 <asp:TextBox ID="txtInServiceName"  class="form-control fg2_inp1 inp_mst" placeholder="In-Server Name" runat="server" MaxLength="200"></asp:TextBox>
              </div>

              <div class="form-group fg2 fg2_mr sa_fg1">
                <label for="email" class="fg2_la1">In-Port:<span class="spn1">*</span></label>
                   <asp:TextBox ID="txtInPort" class="form-control fg2_inp1 inp_mst" placeholder="In-Port" runat="server" MaxLength="10" Style="" onkeydown="return isNumber(event)" onblur="AmountCheck(this)"></asp:TextBox>
              </div>

              <div class="form-group fg2 fg2_mr sa_fg1">
                <label for="email" class="fg2_la1">Out-Server Name:<span class="spn1">*</span></label>
                  <asp:TextBox ID="txtOutServerName" class="form-control fg2_inp1 inp_mst" placeholder="Out-Server Name" runat="server" MaxLength="200" Style=""></asp:TextBox>
              </div>

              <div class="form-group fg2 fg2_mr sa_fg1">
                <label for="email" class="fg2_la1">Out-Port:<span class="spn1">*</span></label>
                   <asp:TextBox ID="txtOutPort" class="form-control fg2_inp1 inp_mst" placeholder="Out-Port" runat="server" MaxLength="10" Style=" " onkeydown="return isNumber(event)" onblur="AmountCheck(this)"></asp:TextBox>
              </div>

          <div class="fg2 sa_2">
            <div class="form-group">
              <label for="email" class="fg2_la1">Signature:<span class="spn1">&nbsp;</span></label>
              <textarea id="txtSignature" runat="server" onblur="textCheck(this,225);" onkeydown="return textCounter(this,248);" onkeyup="return textCounter(this,225);" style=" resize:none;" rows="3" cols="48" class="form-control flt_l txr dt_wdt" placeholder="Enter your HTML code here"></textarea>
            </div>
          </div>

           <div class="form-group fg8 fg2_mr sa_fg4">
                <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
                <div class="check1 tr_l">
                  <div class="">
                    <label class="switch">
                      <input type="checkbox" id="cbxStatus" runat="server" checked="checked"/>
                      <span class="slider_tog round"></span>
                    </label>
                  </div>
                </div>
              </div>

               <div class="form-group fg8 fg2_mr sa_fg4">
                <label for="email" class="fg2_la1 pad_l">Security Layer:<span class="spn1">*</span></label>
                <div class="check1 tr_l">
                  <div class="">
                    <label class="switch">
                      <input type="checkbox" id="cbxSecurity" runat="server" checked="checked"/>
                      <span class="slider_tog round"></span>
                    </label>
                  </div>
                </div>
              </div>
   
        <div class="clearfix"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">
              <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" Visible="false" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
              <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" Visible="false" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
              <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />                    
              <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />   
              <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
              <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
          </div>
        </div>
        
      </div>
    </div>
    </div>
      <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">
         <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" Visible="false" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
              <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" Visible="false" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
              <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />                    
              <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" /> 
               <asp:Button ID="btnClearF" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2 bt_b" Text="Clear"/>
              <asp:Button ID="btnCancelF" runat="server" class="btn sub4 bt_b" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
  </div> 
</div>
<a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
<i class="fa fa-save"></i>
</a>

       <!---back_button_fixed_section--->
  <a href="#" type="button" class="list_b" title="Back to List" onclick="return ConfirmMessage();" id="divList" runat="server">
    <i class="fa fa-arrow-circle-left"></i>
  </a>
<!---back_button_fixed_section--->
  <!--save_pop up_open-->
<script>
    function opensave() {
        document.getElementById("cphMain_mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("cphMain_mySave").style.width = "0px";
    }
</script>
</asp:Content>


