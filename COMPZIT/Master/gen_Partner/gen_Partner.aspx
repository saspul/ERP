<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Partner.aspx.cs" Inherits="Master_gen_Partner_gen_Partner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <script src="/js/Common/Common.js"></script>
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
    </script>
     <script>
       
            var $au = jQuery.noConflict();
             $au(function () {
                 $au('#cphMain_ddlCountry').selectToAutocomplete1Letter();
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
                         window.location.href = "gen_PartnerList.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 window.location.href = "gen_PartnerList.aspx";

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
                         window.location.href = "gen_Partner.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 window.location.href = "gen_Partner.aspx";
                 return false;
             }
             return false;
         }
    </script>
    <style>
         .error {
              
               color: red;
               font-size: small;
                font-family: Calibri;
                width: 95%;
           }  
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
            z-index: 3;
            right: 18%;
            z-index: 2000;
        }

            .lightbox-target:target img {
                max-height: 100%;
                max-width: 80%;
            }

            .lightbox-target:target a.lightbox-close {
                top: 0px;
            }
    </style>
     <script>
         //start-0006
         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {
             changeIndex();
             localStorage.clear();           
             if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {
                 IncrmntConfrmCounter();
             }
         });
    </script>
        
     <script>
        
             function ChangeFileIcon(x) {
                 
                 document.getElementById('FilerowId1_' + x).innerHTML = "";
             if (ClearDivDisplayImage(x)) {
                 IncrmntConfrmCounter();
                 if (document.getElementById('file' + x).value != "") {
                     document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;


                 }
                 else {
                     document.getElementById('filePath' + x).innerHTML = 'No file uploaded';


                 }

             }
         }

       
         function ClearDivDisplayImage(x) {

             var fuData = document.getElementById('file' + x);
             var FileUploadPath = fuData.value;
             var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



             if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                         || Extension == "jpeg" || Extension == "jpg") {


                 return true;

             }
             else {
                 document.getElementById('file' + x).value = "";
                 document.getElementById('filePath' + x).innerHTML = 'No file selected';
                 $("#divWarning").html("The specified file type could not be uploaded.Only support image files");
                 $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                 });
                 return false;
             }
         }
            
         function CheckFileUploaded(x) {

             if (document.getElementById('file' + x).value != "") {
                 return true;
             }
             else {
                 return false;
             }


         }

       
       
         </script>
    <script>
        function ClearDivDisplayImage() {
            
            IncrmntConfrmCounter();


            var FileUploadPath = document.getElementById("<%=FileUploadProPic.ClientID%>").value.replace("C:\\fakepath\\", "");
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg") {

            }
            else {
                document.getElementById("<%=FileUploadProPic.ClientID%>").value = "";
                document.getElementById("<%=Label1.ClientID%>").textContent = "No file selected";
                $("#divWarning").html("The specified file type could not be uploaded.Only support image files");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
              

            }


            var hidnImageSize = document.getElementById("<%=hiddenUserImageSize.ClientID%>").value;

                    var fuData = document.getElementById("<%=FileUploadProPic.ClientID%>");
             var size = fuData.files[0].size;
             var convertToKb = hidnImageSize / 1000;
             if (size > hidnImageSize) {
                        document.getElementById("<%=FileUploadProPic.ClientID%>").value = "";
                 document.getElementById("<%=Label1.ClientID%>").textContent = "No file selected";

                 $("#divWarning").html(" Sorry maximum file size exceeds. Please upload image of size less than " + convertToKb + "kb !.");
                 $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                 });

                       
                        //return false;
                    }
                    else {

                        if (document.getElementById("<%=FileUploadProPic.ClientID%>").value != "") {
                            document.getElementById("<%=Label1.ClientID%>").textContent = document.getElementById("<%=FileUploadProPic.ClientID%>").value.replace("C:\\fakepath\\", "");
                    document.getElementById("<%=divImageDisplay.ClientID%>").innerHTML = "";
                    document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
                }

                        //    return true;

            }
        }
        function ClearImage() {
            if (document.getElementById("<%=hiddenUserImage.ClientID%>").value != "" || document.getElementById("<%=FileUploadProPic.ClientID%>").value != "") {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to remove selected photo?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        IncrmntConfrmCounter();
                        document.getElementById("<%=FileUploadProPic.ClientID%>").value = "";
                       document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
                        document.getElementById("<%=divImageDisplay.ClientID%>").innerHTML = "";
                        document.getElementById("<%=Label1.ClientID%>").textContent = "No file selected";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            return false;
        }
        function ImagePosition(object, obj2) {
            var $Mo = jQuery.noConflict();

            var offset = $Mo("#" + object).offset();

            var posY = 0;
            var posX = 0;
            posY = offset.top;

            posX = offset.left

            if (object == 'ClearImage') {
                posX = 7.1;
            }
            
            var d = document.getElementById(obj2);
            d.style.position = "absolute";
            d.style.left = posX + '%';
            if (object == 'ClearImage') {
                d.style.top = posY - 52 + 'px';
            }
            
        }
    </script>


    <script type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13) {
                // return false;
            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete,UP ARROW ,DOWN ARROW
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


        function isNumberDate(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13) {
                return false;
            }
                //dash
            else if (keyCodes == 173) {
                return true;
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46) {
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
        function BlurNotNumber(obj) {
            var txt = document.getElementById(obj).value;

            if (txt != "") {

                if (isNaN(txt)) {
                    document.getElementById(obj).value = "";
                    document.getElementById(obj).focus();
                    return false;

                }


            }
        }
       

    </script>
    <script>
        function DuplicationName() {
            $("#divWarning").html("Duplication error!. Corporate partner name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtPartName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtPartName.ClientID%>").focus();
        }
        function DuplicationDoc() {
            $("#divWarning").html("Duplication error!. Document number can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtDocNum.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtDocNum.ClientID%>").focus();
        }
        function DuplicationCRN() {
            $("#divWarning").html("Duplication error!. Commercial registration number can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtCRN.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtCRN.ClientID%>").focus();
        }
        function DuplicationCCN() {
            $("#divWarning").html("Duplication error!. Computer card number can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtCCN.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtCCN.ClientID%>").focus();
        }
        function DuplicationTIN() {
            $("#divWarning").html("Duplication error!. Tax identification no. can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtTIN.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtTIN.ClientID%>").focus();
        }
        function SuccessConfirmation() {
            $("#success-alert").html("Corporate partner details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Corporate partner details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
    </script>
    <script>


        function changeIndex() {
           
            var partType = document.getElementById("<%=ddlPartshipTyp.ClientID%>");
            var partTypeText = partType.options[partType.selectedIndex].text;          
            if (partTypeText == "COMPANY") {
            document.getElementById('divCompInfo').style.display ="block";
                
            }
            else {
                document.getElementById('divCompInfo').style.display = "none";
            }
           
        }
        function PartnrValidation() {

            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            // replacing < and > tags
            var CorpNameWithoutReplace = document.getElementById("<%=txtPartName.ClientID%>").value;
            var CorpNamereplaceText1 = CorpNameWithoutReplace.replace(/</g, "");
            var CorpNamereplaceText2 = CorpNamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPartName.ClientID%>").value = CorpNamereplaceText2;

            var Add1WithoutReplace = document.getElementById("<%=txtAdd1.ClientID%>").value;
            var Add1replaceText1 = Add1WithoutReplace.replace(/</g, "");
            var Add1replaceText2 = Add1replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAdd1.ClientID%>").value = Add1replaceText2;

            var Add2WithoutReplace = document.getElementById("<%=txtAdd2.ClientID%>").value;
            var Add2replaceText1 = Add2WithoutReplace.replace(/</g, "");
            var Add2replaceText2 = Add2replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAdd2.ClientID%>").value = Add2replaceText2;

            var Add3WithoutReplace = document.getElementById("<%=txtAdd3.ClientID%>").value;
            var Add3replaceText1 = Add3WithoutReplace.replace(/</g, "");
            var Add3replaceText2 = Add3replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAdd3.ClientID%>").value = Add3replaceText2;

            var ZipWithoutReplace = document.getElementById("<%=txtZip.ClientID%>").value;
            var ZipreplaceText1 = ZipWithoutReplace.replace(/</g, "");
            var ZipreplaceText2 = ZipreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtZip.ClientID%>").value = ZipreplaceText2;

            var PhoneWithoutReplace = document.getElementById("<%=txtPhone.ClientID%>").value;
            var PhonereplaceText1 = PhoneWithoutReplace.replace(/</g, "");
            var PhonereplaceText2 = PhonereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPhone.ClientID%>").value = PhonereplaceText2;

            var WebsiteWithoutReplace = document.getElementById("<%=txtWebsite.ClientID%>").value;
            var WebsitereplaceText1 = WebsiteWithoutReplace.replace(/</g, "");
            var WebsitereplaceText2 = WebsitereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtWebsite.ClientID%>").value = WebsitereplaceText2;

            var EmailWithoutReplace = document.getElementById("<%=txtEmail.ClientID%>").value;
            var EmailreplaceText1 = EmailWithoutReplace.replace(/</g, "");
            var EmailreplaceText2 = EmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmail.ClientID%>").value = EmailreplaceText2;         
                   

            var CodeWithoutReplace = document.getElementById("<%=txtFax.ClientID%>").value;
            var CodereplaceText1 = CodeWithoutReplace.replace(/</g, "");
            var CodereplaceText2 = CodereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtFax.ClientID%>").value = CodereplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtEnqMail.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEnqMail.ClientID%>").value = EnqreplaceText2;
          
            var EnqWithoutReplace = document.getElementById("<%=txtCRN.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCRN.ClientID%>").value = EnqreplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtTIN.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTIN.ClientID%>").value = EnqreplaceText2;         

            var EnqWithoutReplace = document.getElementById("<%=txtCCN.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCCN.ClientID%>").value = EnqreplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtDocNum.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDocNum.ClientID%>").value = EnqreplaceText2;


            document.getElementById("<%=txtPartName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlPartshipTyp.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAdd1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCountry.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtPhone.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCRN.ClientID%>").style.borderColor = "";           
            document.getElementById("<%=txtTIN.ClientID%>").style.borderColor = "";           
            document.getElementById("<%=txtCCN.ClientID%>").style.borderColor = "";            
            document.getElementById("<%=txtEnqMail.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDocNum.ClientID%>").style.borderColor = "";
            document.getElementById('ErrorMsgUsrMob').style.display = "none";
            document.getElementById('ErrorMsgUsrEmail').style.display = "none";
            document.getElementById('ErrorEnqEmail').style.display = "none";
          
            $("div#divBnk input.ui-autocomplete-input").css("borderColor", "");
            var PartName = document.getElementById("<%=txtPartName.ClientID%>").value.trim();

            var PartshipType = document.getElementById("<%=ddlPartshipTyp.ClientID%>");
            var PartType = PartshipType.options[PartshipType.selectedIndex].text.trim();

            var CorpaCountry = document.getElementById("<%=ddlCountry.ClientID%>");
            var CorpCountry = CorpaCountry.options[CorpaCountry.selectedIndex].text.trim();         

            var CorpAdd = document.getElementById("<%=txtAdd1.ClientID%>").value.trim();

            var CorpMobile = document.getElementById("<%=txtPhone.ClientID%>").value.trim();
            var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

            var EmailAdd = document.getElementById("<%=txtEmail.ClientID%>").value.trim();
            var Email = document.getElementById("<%=txtEmail.ClientID%>");

            var EmailEnq = document.getElementById("<%=txtEnqMail.ClientID%>").value.trim();
            var EmailEnqq = document.getElementById("<%=txtEnqMail.ClientID%>");

            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            
            var DocNum = document.getElementById("<%=txtDocNum.ClientID%>").value.trim();
            var CRN = document.getElementById("<%=txtCRN.ClientID%>").value.trim();           
            var TIN = document.getElementById("<%=txtTIN.ClientID%>").value.trim();
            var CCN = document.getElementById("<%=txtCCN.ClientID%>").value.trim();         

            if (PartType == "COMPANY") {
               
                if (TIN == "") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtTIN.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTIN.ClientID%>").focus();
                    ret = false;
                }
                if (CRN == "") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                document.getElementById("<%=txtCRN.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCRN.ClientID%>").focus();
                ret = false;
            }          

            }
            if (DocNum == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtDocNum.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtDocNum.ClientID%>").focus();
                 ret = false;
             }
            if (EmailEnq != "") {
                if (!filter.test(EmailEnqq.value)) {
                    document.getElementById('ErrorEnqEmail').style.display = "";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtEnqMail.ClientID%>").focus();
                    document.getElementById("<%=txtEnqMail.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
            }

            if (!filter.test(Email.value)) {
                if (EmailAdd != "") {
                    document.getElementById('ErrorMsgUsrEmail').style.display = "";
                }
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtEmail.ClientID%>").focus();
                document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                ret = false;
            }
            
            if (!mobileregular.test(CorpMobile)) {
                if (CorpMobile != "") {
                    document.getElementById('ErrorMsgUsrMob').style.display = "";

                }
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                    document.getElementById("<%=txtPhone.ClientID%>").focus();
                document.getElementById("<%=txtPhone.ClientID%>").style.borderColor = "Red";

                ret = false;
            }
            if (CorpCountry == "--Select Country--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlCountry.ClientID%>").focus();
                document.getElementById("<%=ddlCountry.ClientID%>").style.borderColor = "Red";
                $("div#divBnk input.ui-autocomplete-input").css("borderColor", "red");
                $("div#divBnk input.ui-autocomplete-input").select();
                $("div#divBnk input.ui-autocomplete-input").focus();
                 ret = false;
            }
            if (CorpAdd == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtAdd1.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtAdd1.ClientID%>").focus();
                 ret = false;
            }
            if (PartType == "--Select Partnership Type--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlPartshipTyp.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=ddlPartshipTyp.ClientID%>").focus();
                 ret = false;
             }
            if (PartName == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtPartName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtPartName.ClientID%>").focus();
                ret = false;
            }
                 
             if (ret == false) {
                 CheckSubmitZero();

             }

             return ret;
        }
        function RemoveTag(obj) {
            //    IncrmntConfrmCounter();

            var txt = document.getElementById(obj).value;
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2;

        }
        function selectorToAutocompleteState(ev) {
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var countryID = document.getElementById("cphMain_ddlCountry").value;
            if (countryID != "--Select Country--" && countryID != "" && corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
                $au("#cphMain_ddlState").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "gen_Partner.aspx/changeState",
                            async: false,
                            data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "', 'countryID': '" + parseInt(countryID) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        val: item.split('<,>')[0],
                                        label: item.split('<,>')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                            },
                            failure: function (response) {
                            }
                        });
                    },
                    autoFocus: false,
                    select: function (e, i) {
                        document.getElementById("<%=HiddenFieldState.ClientID%>").value = i.item.val;
                        document.getElementById("cphMain_ddlState").value = i.item.label;
                    },
                    change: function (event, ui) {
                        if (ui.item) {
                        }
                        else {
                            document.getElementById("cphMain_ddlState").value = "";
                            document.getElementById("<%=HiddenFieldState.ClientID%>").value = "";
                        }
                    }
                });
            }
        }
        function selectorToAutocompleteCity(ev) {
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var stateID = document.getElementById("<%=HiddenFieldState.ClientID%>").value;
            if (stateID != "" && corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
                $au("#cphMain_ddlCity").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "gen_Partner.aspx/changeCity",
                            async: false,
                            data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "', 'stateID': '" + parseInt(stateID) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        val: item.split('<,>')[0],
                                        label: item.split('<,>')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                            },
                            failure: function (response) {
                            }
                        });
                    },
                    autoFocus: false,
                    select: function (e, i) {
                        document.getElementById("cphMain_ddlCity").value = i.item.label;
                        document.getElementById("<%=HiddenFieldCity.ClientID%>").value = i.item.val;
                    },
                    change: function (event, ui) {
                        if (ui.item) {

                        }
                        else {
                            document.getElementById("cphMain_ddlCity").value = "";
                            document.getElementById("<%=HiddenFieldCity.ClientID%>").value = "";
                        }
                    }
                });
            }
        }
        function changeCountry() {
            document.getElementById("cphMain_ddlState").value = "";
            document.getElementById("<%=HiddenFieldState.ClientID%>").value = "";
            document.getElementById("cphMain_ddlCity").value = "";
            document.getElementById("<%=HiddenFieldCity.ClientID%>").value = "";
            IncrmntConfrmCounter();
        }
        function changeState() {         
            document.getElementById("cphMain_ddlCity").value = "";
            document.getElementById("<%=HiddenFieldCity.ClientID%>").value = "";
            if (document.getElementById("<%=HiddenFieldState.ClientID%>").value == "") {
                document.getElementById("cphMain_ddlState").value = "";
            }
            IncrmntConfrmCounter();
        }
        function changeCity() {           
            if (document.getElementById("<%=HiddenFieldCity.ClientID%>").value == "") {
                document.getElementById("cphMain_ddlCity").value = "";
            }
            IncrmntConfrmCounter();
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="hiddenConfirmValue" runat="server" />


     <asp:HiddenField ID="hiddenFilePath" runat="server" />
     <asp:HiddenField ID="hiddenFileCanclDtlId" runat="server" />
   
     <asp:HiddenField ID="hiddenEditAttchmnt" runat="server" />
     <asp:HiddenField ID="HiddenAtchmnt" runat="server" />
     <asp:HiddenField ID="hiddenOrgId" runat="server" />
     <asp:HiddenField ID="HiddenField1" runat="server" />
     <asp:HiddenField ID="HiddenField2" runat="server" />
     <asp:HiddenField ID="HiddenField4" runat="server" />
     <asp:HiddenField ID="hiddenEdit" runat="server" />
     <asp:HiddenField ID="hiddenView" runat="server" />
     <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />     
     <asp:HiddenField ID="HiddenField3" runat="server" />
     <asp:HiddenField ID="hiddenUserImageSize" runat="server" />
    <asp:HiddenField ID="hiddenUserImage" runat="server" />
    <asp:HiddenField ID="hiddenImageName" runat="server" />

    <asp:HiddenField ID="HiddenFieldState" runat="server" />
    <asp:HiddenField ID="HiddenFieldCity" runat="server" />
   
     <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li><a href="gen_PartnerList.aspx">Corporate Partner</a></li>
        <li id="lblEntryB" runat="server" class="active">Add Corporate Partner</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>

    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add Corporate Partner</h2>

        <div class="form-group fg2 sa_fg3 sa_640">
          <label for="email" class="fg2_la1">Partnership Type:<span class="spn1">*</span></label>
             <asp:DropDownList ID="ddlPartshipTyp" runat="server" class="form-control fg2_inp1 inp_mst prt_typ" onclick="changeIndex();"></asp:DropDownList>
         
        </div>

        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1">Partner Name:<span class="spn1">*</span></label>
             <asp:TextBox ID="txtPartName" placeholder="Partner Name" class="form-control fg2_inp1 inp_mst" runat="server" onblur="RemoveTag('cphMain_txtPartName')" MaxLength="100"  Style="text-transform: uppercase"></asp:TextBox>
        
        </div>
        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1">Document#:<span class="spn1">*</span></label>
            <asp:TextBox ID="txtDocNum" onblur="RemoveTag('cphMain_txtDocNum')" class="form-control fg2_inp1 inp_mst"  runat="server" MaxLength="100" placeholder="Document#"></asp:TextBox>         
        </div>
        <div class="form-group fg2 fg2_mr sa_640 sa_fg3">
          <label for="email" class="fg8_la1 pad_l">Logo:<span class="spn1">&nbsp;</span></label><br>
             <asp:FileUpload ID="FileUploadProPic"  runat="server" Style=" display: none;" onchange="ClearDivDisplayImage()" Accept="image/png, image/gif, image/jpeg" />
          <label for="cphMain_FileUploadProPic" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>
          <div class="file_n" id="Label1" runat="server">No File selected</div>
            <div id="divImageEdit" runat="server" style=" width: 100%;">
               
                 <button class="btn act_btn bn3 bdr_rd2" title="Remove Selected Logo" style="margin-left: 10px;" id="imgClear" runat="server" onclick="return ClearImage();">
            <i class="fa fa-times"></i>
          </button> 
                     <div id="divImageDisplay" runat="server" style="float:left;width:100%;">
                        </div>    
                    </div>
        </div> 
        <div class="clearfix"></div>
        <div class="devider"></div>

        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1">Address 1:<span class="spn1">*</span></label>
            <asp:TextBox ID="txtAdd1"  class="form-control fg2_inp1 inp_mst"  placeholder="Address 1" onblur="RemoveTag('cphMain_txtAdd1')"  runat="server" MaxLength="150" ></asp:TextBox>
        </div>
        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1">Address 2:<span class="spn1"></span></label>
             <asp:TextBox ID="txtAdd2" onblur="RemoveTag('cphMain_txtAdd2')"  runat="server" MaxLength="150" class="form-control fg2_inp1" placeholder="Address 2"></asp:TextBox>
        </div>
        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1">Address 3:<span class="spn1"></span></label>
             <asp:TextBox ID="txtAdd3" onblur="RemoveTag('cphMain_txtAdd3')"  runat="server" MaxLength="150" class="form-control fg2_inp1" placeholder="Address 3"></asp:TextBox>  
        </div>
           
        <div class="form-group fg2 sa_640 sa_fg3" id="divBnk">
          <label for="email" class="fg2_la1">Country:<span class="spn1">*</span></label>
             <asp:DropDownList ID="ddlCountry" class="form-control fg2_inp1 inp_mst" runat="server"  onchange="changeCountry();"></asp:DropDownList>
         
        </div>

        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1">State:<span class="spn1"></span></label>
             <asp:TextBox ID="ddlState"  onchange="changeState();" class="form-control fg2_inp1 inp_mst"  placeholder="--Select State--"   runat="server"  onkeypress="return selectorToAutocompleteState(event);" onkeydown="return selectorToAutocompleteState(event);"></asp:TextBox>
        </div>
        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1">City:<span class="spn1"></span></label>
            <asp:TextBox ID="ddlCity"  onchange="changeCity();" class="form-control fg2_inp1 inp_mst"  placeholder="--Select City--"   runat="server"  onkeypress="return selectorToAutocompleteCity(event);" onkeydown="return selectorToAutocompleteCity(event);"></asp:TextBox>
        </div>

        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1">Postal Code:<span class="spn1"></span></label>
             <asp:TextBox ID="txtZip" class="form-control fg2_inp1"  placeholder="Postal Code" onblur="RemoveTag('cphMain_txtZip')"  runat="server" MaxLength="10" Style="text-transform: uppercase"></asp:TextBox>
        </div>
        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1">Phone#:<span class="spn1">*</span></label>
             <asp:TextBox ID="txtPhone" class="form-control fg2_inp1 inp_mst" placeholder="Phone#" onblur="RemoveTag('cphMain_txtPhone')"  runat="server" MaxLength="50"  onkeydown="return isNumber(event);" Style="text-transform: uppercase"></asp:TextBox> 
             <p class="error" id="ErrorMsgUsrMob" style="display: none;">Please enter valid phone number</p>
        </div>

         <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1">Fax:<span class="spn1"></span></label>
               <asp:TextBox ID="txtFax" class="form-control fg2_inp1" placeholder="Fax" onblur="RemoveTag('cphMain_txtFax')"  runat="server" MaxLength="100" ></asp:TextBox>
        </div>
        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1">Website:<span class="spn1"></span></label>
             <asp:TextBox ID="txtWebsite" onblur="RemoveTag('cphMain_txtWebsite')"  runat="server" MaxLength="100" class="form-control fg2_inp1"  placeholder="Website"></asp:TextBox>

        </div>
        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1">Email:<span class="spn1">*</span></label>
             <asp:TextBox ID="txtEmail" onblur="RemoveTag('cphMain_txtEmail')" class="form-control fg2_inp1 inp_mst" placeholder="Email" runat="server" MaxLength="100" ></asp:TextBox>                     
                <p class="error" id="ErrorMsgUsrEmail" style="display: none;">Please enter valid email address</p> 
         
        </div>
        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1"> Enquiry Mail:<span class="spn1"></span></label>
             <asp:TextBox ID="txtEnqMail" onblur="RemoveTag('cphMain_txtEnqMail')" class="form-control fg2_inp1"  placeholder="Enquiry Mail"  runat="server" MaxLength="100" ></asp:TextBox> 
                       <p class="error" id="ErrorEnqEmail" style="display: none;">Please enter valid email address</p>
        
        </div>

        <div class="form-group fg2 sa_640 sa_fg3">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
          <div class="check1">
            <label class="switch">
              <input type="checkbox" id="cbxStatus"  runat="server" onkeypress="return isTag(event);" onclick="IncrmntConfrmCounter();" checked="checked">
              <span class="slider_tog round"></span>
            </label>
          </div>
        </div>

        <div class="clearfix"></div>
        <div class="devider"></div>

        <div class="shw_com" style="display: none;" id="divCompInfo">
          <h3>Company Details</h3>
          <div class="form-group fg2 sa_640 sa_fg3">
            <label for="email" class="fg2_la1">Commercial Registration#:<span class="spn1">*</span></label>
               <asp:TextBox ID="txtCRN" class="form-control fg2_inp1 inp_mst" placeholder="Commercial Registration#" onblur="RemoveTag('cphMain_txtCRN')" runat="server" MaxLength="100"  Style="text-transform: uppercase"></asp:TextBox>
          </div>
          <div class="form-group fg2 sa_640 sa_fg3">
            <label for="email" class="fg2_la1">Computer Card#:<span class="spn1"></span></label>
               <asp:TextBox ID="txtCCN"  onblur="RemoveTag('cphMain_txtCCN')" runat="server" MaxLength="100" class="form-control fg2_inp1 inp_mst" placeholder="Computer Card#" Style="text-transform: uppercase"></asp:TextBox>
          </div>
          <div class="form-group fg2 sa_640 sa_fg3">
            <label for="email" class="fg2_la1">Tax Identification#:<span class="spn1">*</span></label>
               <asp:TextBox ID="txtTIN" class="form-control fg2_inp1 inp_mst" placeholder="Tax Identification#" onblur="RemoveTag('cphMain_txtTIN')" runat="server" MaxLength="100"  Style="text-transform: uppercase"></asp:TextBox>
          </div>
             
              <div class="clearfix"></div>
              <div class="devider"></div>
        </div>
             
                <div class="sub_cont pull-right">
                <div class="save_sec">
                 
                     <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return PartnrValidation(); " />
                         <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return PartnrValidation(); " />
                         <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return PartnrValidation();" />
                         <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return PartnrValidation();" />
                  <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
                   <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
                </div>
              </div>
             </div>
            </div>
           </div>
     <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">

     
                     <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return PartnrValidation(); " />
                         <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return PartnrValidation(); " />
                         <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return PartnrValidation();" />
                         <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return PartnrValidation();" />
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
    <style>
         .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
            border: 1px solid #B0BECA;
            max-height: 140px;
            overflow-x: auto;
            font-family: Calibri;
        }

            .ui-autocomplete .ui-menu-item {
                border-top: 1px solid #B0BECA;
                display: block;
                padding: 4px 6px;
                color: #353D44;
                cursor: pointer;
                font-family: Calibri;
            }

                .ui-autocomplete .ui-menu-item:first-child {
                    border-top: none;
                    font-family: Calibri;
                }

                .ui-autocomplete .ui-menu-item.ui-state-focus {
                    background-color: #D5E5F4;
                    color: #161A1C;
                    font-family: Calibri;
                }
    </style>
</asp:Content>

