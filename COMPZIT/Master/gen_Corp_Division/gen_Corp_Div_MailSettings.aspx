<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_App.master" CodeFile="gen_Corp_Div_MailSettings.aspx.cs" Inherits="Master_gen_Corp_Division_gen_Corp_Div_MailSettings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
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
    </script>

    <style>
        /* Styles the thumbnail */
        a.lightbox img {
            height: 150px;
            border: 3px solid white;
            box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
            margin: 94px 20px 20px 20px;
        }

        /* Styles the lightbox, removes it from sight and adds the fade-in transition */
        .lightbox-target {
            position: fixed;
            top: -100%;
            width: 100%;
            background: rgba(0, 0, 0, 0.7);
            width: 60%;
            opacity: 0;
            -webkit-transition: opacity .5s ease-in-out;
            -moz-transition: opacity .5s ease-in-out;
            -o-transition: opacity .5s ease-in-out;
            transition: opacity .5s ease-in-out;
            overflow: hidden;
        }

            /* Styles the lightbox image, centers it vertically and horizontally, adds the zoom-in transition and makes it responsive using a combination of margin and absolute positioning */
            .lightbox-target img {
                margin: auto;
                position: absolute;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                max-height: 0%;
                max-width: 0%;
                border: 3px solid white;
                box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
                box-sizing: border-box;
                -webkit-transition: .5s ease-in-out;
                -moz-transition: .5s ease-in-out;
                -o-transition: .5s ease-in-out;
                transition: .5s ease-in-out;
            }

        /* Styles the close link, adds the slide down transition */
        a.lightbox-close {
            display: block;
            width: 50px;
            height: 50px;
            box-sizing: border-box;
            background: white;
            color: black;
            text-decoration: none;
            position: absolute;
            top: -80px;
            right: 0;
            -webkit-transition: .5s ease-in-out;
            -moz-transition: .5s ease-in-out;
            -o-transition: .5s ease-in-out;
            transition: .5s ease-in-out;
        }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:before {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(45deg);
                -moz-transform: rotate(45deg);
                -o-transform: rotate(45deg);
                transform: rotate(45deg);
            }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:after {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(-45deg);
                -moz-transform: rotate(-45deg);
                -o-transform: rotate(-45deg);
                transform: rotate(-45deg);
            }

        /* Uses the :target pseudo-class to perform the animations upon clicking the .lightbox-target anchor */
        .lightbox-target:target {
            opacity: 1;
            top: 0;
            bottom: 0;
            right: 18%;
        }

            .lightbox-target:target img {
                max-height: 100%;
                max-width: 80%;
            }

            .lightbox-target:target a.lightbox-close {
                top: 0px;
            }
    </style>



    <style>
        .fillform {
            width: 70%;
        }

        .subform {
            float: left;
            margin-left: 38.5%;
            /*padding-left: 2%;*/
        }

        /**/

        /*.aspNetDisabled {
            margin-left: -31%;
        }*/


        /*input[type=text][disabled="disabled"] {
            margin-left: 28% !important;
            height: 30px !important;
        }*/

        /*.aspNetDisabled {
            margin-left: 0%;
        }


        input[type=text][disabled="disabled"] {
            margin-left: 30% !important;
            height: 30px !important;
            float: right;
        }

        select[disabled="disabled"] {
            margin-left: 29.7% !important;
            width: 358px!important;
            height: 30px !important;
        }*/


        .clearimage {
            height: 20px;
            width: 20px;
            margin-left: 5%;
            float: left;
        }

        .imageUpload {
            width: 350px;
            height: 28px;
            /*padding: 0px 8px;*/
            /* border: 1px solid #cfcccc;*/
            float: left;
            color: #000;
            font-size: 13px;
            margin-left: 34%;
        }


        .imgDescription {
            position: absolute;
            top: 73%;
            right: 24%;
            background: rgba(123, 150, 100, 0.7);
            visibility: hidden;
            opacity: 0;
            padding: 0.1%;
            font-family: Calibri;
            /*remove comment if you want a gradual transition between states
  -webkit-transition: visibility opacity 0.2s;
  */
        }

        .imgWrap:hover .imgDescription {
            visibility: visible;
            opacity: 1;
        }


        /*.clear {
            font-family: Calibri;
            font-size: 14px;
            color: #000;
            padding: 4px 24px 5px;
            margin: 0 14px 6px 2px;
            line-height: 1;
            font-weight: normal;
            margin-left:87%;
            margin-top:-4.5%;
            float: left;
            background: #e5fac1;
            border: none;
            border-radius: 2px;
            cursor: pointer;
            text-transform: uppercase;
        }

            .clear:hover, .clear:focus {
                background: #f4fac1;
            }*/
    </style>
    <script type="text/javascript">

        function SuccessConfirmation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Corporate Division Details Inserted Successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Corporate Division Details Updated Successfully.";
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

            var CodeWithoutReplace = document.getElementById("<%=txtServiceName.ClientID%>").value;
            var CodereplaceText1 = CodeWithoutReplace.replace(/</g, "");
            var CodereplaceText2 = CodereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtServiceName.ClientID%>").value = CodereplaceText2;

            var PortWithoutReplace = document.getElementById("<%=txtPort.ClientID%>").value;
            var PortreplaceText1 = PortWithoutReplace.replace(/</g, "");
            var PortreplaceText2 = PortreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPort.ClientID%>").value = PortreplaceText2;

            document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtPassword.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtConfirmPassword.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtServiceName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtPort.ClientID%>").style.borderColor = "";

            document.getElementById('ErrorMsgConfirmPassword').style.visibility = "hidden";
            //  alert(activeViewIndex);

        
            var Email = document.getElementById("<%=txtEmail.ClientID%>").value;
            var Password = document.getElementById("<%=txtPassword.ClientID%>").value;
            var ConfirmPassword = document.getElementById("<%=txtConfirmPassword.ClientID%>").value;
            var ServiceName = document.getElementById("<%=txtServiceName.ClientID%>").value;
            var Port = document.getElementById("<%=txtPort.ClientID%>").value;
            var PasswordValidation = document.getElementById("<%=HiddenPassword.ClientID%>").value;


            document.getElementById('ErrorMsgUsrEmail').style.visibility = "hidden";


            

            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    
            if (Port == "") {
                document.getElementById('divErrorTotal').style.visibility = "visible";
                document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtPort.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtPort.ClientID%>").focus();
                ret = false;
            }
            if (ServiceName == "") {
                document.getElementById('divErrorTotal').style.visibility = "visible";
                document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtServiceName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtServiceName.ClientID%>").focus();
                ret = false;
            }
            if (ConfirmPassword != Password) {
                document.getElementById('divErrorTotal').style.visibility = "visible";
                document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById('ErrorMsgConfirmPassword').style.visibility = "visible";
                document.getElementById("<%=txtConfirmPassword.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtConfirmPassword.ClientID%>").focus();
                ret = false;
            }
            if (PasswordValidation == 0) {
                if (ConfirmPassword == "") {
                    document.getElementById('divErrorTotal').style.visibility = "visible";
                    document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtConfirmPassword.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtConfirmPassword.ClientID%>").focus();
                    ret = false;
                }
                if (Password == "") {
                    document.getElementById('divErrorTotal').style.visibility = "visible";
                    document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtPassword.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtPassword.ClientID%>").focus();
                    ret = false;
                }
            }

            if (Email == "") {
                document.getElementById('divErrorTotal').style.visibility = "visible";
                document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtEmail.ClientID%>").focus();
                 ret = false;
            }

            if (!filter.test(Email)) {
                var ErrorMsg = document.getElementById('ErrorMsgUsrEmail').style.visibility = "visible";
                document.getElementById("<%=txtEmail.ClientID%>").focus();
                document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                ret = false;
             }
          
            if (ret == false) {
                CheckSubmitZero();

            }
            return ret;
        }

        function ViewMailSettings() {
            document.getElementById('ContactHeadOne').style.display = "";
        }

        function Close() {
            window.close();
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


        function VisiblePassword() {
            if ($('#divpassword:visible').length == 0) {
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

    </script>
    <%-- <script>
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ImgPrw.ClientID%>').prop('src', e.target.result)
                        .width(50)
                        .height(50);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }


    </script>--%>

    <%--   <script type="text/javascript" language="javascript">
       var ifIgnoreError = false;
       function UpLoadStarted(sender, e) {
           var fileName = e.get_fileName();
           var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1);
           if (fileExtension == 'jpg' || fileExtension == 'jpeg') {
               //file is good -- go ahead
           }
           else {
               //stop upload
               ifIgnoreError = true;
               sender._stopLoad();
           }
       }
       function UploadError(sender, e) {
           if (ifIgnoreError) {
               alert("Wrong file type");
           }
           else {
               alert(e.get_message());
           }
       }


    </script>--%>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenDivId" runat="server" />
    <asp:HiddenField ID="hiddenMailId" runat="server" />
    

    <div class="cont_rght">


        <div id="divErrorTotal" style="visibility: hidden">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>


        <br />
        <br />
        <br />


        <div class="fillform">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
                <h2 id="ContactHeadOne" style="padding-top:1%; color: #5223a1; cursor:pointer; display:none; float:right" OnClick="VisibleContactOne()">Mail Settings</h2>
            </div>
            <br />
            <br />
            <asp:HiddenField ID="HiddenPassword" runat="server" Value="0" />
            <div class="eachform">

                <h2>Enquiry Email ID*</h2>
                <asp:TextBox ID="txtEmail" class="form1" Height="30px" Width="350px" runat="server" MaxLength="100"></asp:TextBox>
                <p class="error" id="ErrorMsgUsrEmail" style="visibility: hidden; float: right; color: red; margin-bottom: -2%; font-size: 9pt; margin-right: 31.5%;">Please enter valid email address</p>

            </div>
            <div id="divCaption" class="eachform" style="display:none; padding-left: 47%;">
                <h2 id="headingCaption" style="color: rgb(83, 101, 51); cursor:pointer; font-weight: bold;" OnClick="VisiblePassword()" >Edit Password+</h2> 
                </div>
            <div id="divpassword" class="eachform" style="height: 1px;">
            <div class="eachform">
                <h2 style="padding-top:1%;">Password*</h2>
                <asp:TextBox ID="txtPassword" class="form1" Height="30px" Width="350px" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                </div>

            <div class="eachform">
                <h2 style="padding-top:1%;">Confirm Password*</h2>
                <asp:TextBox ID="txtConfirmPassword" class="form1" Height="30px" Width="350px" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                <p class="error" id="ErrorMsgConfirmPassword" style="visibility: hidden; font-family:Calibri; float: right; color: red; margin-bottom: -2%; font-size: 9pt; margin-right: 31%;">Both Passwords Must Be Same</p>
                </div>
           </div>
            <div class="eachform">
                <h2>Server Name*</h2>
                <asp:TextBox ID="txtServiceName" class="form1" Height="30px" Width="350px" runat="server" MaxLength="200" Style=" margin-left: 15%;"></asp:TextBox>

            </div>

           <div class="eachform">

                <h2>Port*</h2>
                <asp:TextBox ID="txtPort" class="form1" Height="30px" Width="350px" runat="server" MaxLength="10" Style=" margin-left: 15%;" onkeydown="return isNumber(event)"></asp:TextBox>

            </div>
            
            <br />
            <div class="eachform">
                <div class="subform">


                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Update" OnClick="btnAdd_Click" OnClientClick="return Validate();" />                    
                    <asp:Button ID="btnClose" runat="server" class="save" Text="Cancel" OnClientClick="Close();" />



                </div>
            </div>


        </div>
        

    </div>
    <div>
    </div>



</asp:Content>


