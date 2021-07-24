<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Manpower_Recruitment.aspx.cs" Inherits="HCM_HCM_Master_gen_Manpower_Recruitment_gen_Manpower_Recruitment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <style>
        .cont_rght {
            width: 98%;
        }

        #divGreySection {
            background-color: #efefef;
            border: 1px solid;
            border-color: #cfcfcf;
            padding: 15px;
            height: auto;
        }

        .eachform h2 {
            margin: 8px 0 6px;
        }

        #divAwardedContainer {
            width: 46%;
            float: right;
            margin-top: -17%;
            margin-left: 3%;
            border: 1px solid;
            height: auto;
            border-color: #11839c;
            background-color: white;
            min-height: 180px;
        }

        #divMessageArea {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }

        #imgMessageArea {
            float: left;
            margin-left: 1%;
            margin-top: -0.2%;
        }
    </style>

        <style>
        #cphMain_divCheckBox label {
            /*float: right;*/
            margin-bottom: 0px;
            color: #16682a;
            font-family: Calibri;
            font-size: 15px;
        }
        #cphMain_divCheckBox label.hover{
             color: #1acc45;
        }
        #cphMain_divCheckBox input[type="checkbox"] {
            float: left;
            margin: 3px 8px 3px 3px;
        }
         .eachform h2 {
                margin: 6px 0 6px;
            }
        #cphMain_divCheckBox {
             float: right;
             height: 80px;
             width: 63%;
             max-height: 100px;
             overflow: auto;
             border: 1px solid;
             border-color: #90a8b0;
             background-color: #f9f9f9;

         }
             .imgDescription {
            position: absolute;
            /*top: 511px;
            left: 6.5%;*/
            background: rgb(154, 163, 138);
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
                /*--------------------------------------------------for modal Cancel Reason------------------------------------------------------*/
         .modalCancelView {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 23%;
             top: 30%;
             width: 50%; /* Full width */
             /*height: 58%;*/ /* Full height */
             overflow: auto; /* Enable scroll if needed */
             background-color: transparent;
         }


         /* Modal Content */
         .modal-CancelView {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 95.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }


         /* The Close Button */
         .closeCancelView {
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
         }

             .closeCancelView:hover,
             .closeCancelView:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
             }

         .modal-headerCancelView {
             /*padding: 1% 1%;*/
            background-color: #91a172;
             color: white;
         }

         .modal-bodyCancelView {
             padding: 4% 4% 7% 4%;
         }

         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
            #divErrorRsnAWMS {
                border-radius: 4px;
                background: #fff;
                color: #53844E;
                font-size: 12.5px;
                font-family: Calibri;
                font-weight: bold;
                border: 2px solid #53844E;
                margin-top: -3.5%;
                margin-bottom: 2%;
            }
    </style>
       <style type="text/css">
        .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            /*width: 52.6%;*/
            border: 1px solid #B0BECA;
            max-height: 135px;
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
   
    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
        <script>




            var $au = jQuery.noConflict();

            (function ($au) {
                $au(function () {

                    $au('#cphMain_ddlIdenter').selectToAutocomplete1Letter();
                    $au('form').submit(function () {


                    });
                });
            })(jQuery);
        </script>
          <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            document.getElementById("freezelayer").style.display = "none";
            document.getElementById('MymodalCancelView').style.display = "none";
            var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
            if (CancelPrimaryId != "") {
                OpenCancelView();
            }
        });
    </script>

    <script>
        function GetEmployeeCount() {
            IncrmntConfrmCounter();
         
            var div;
            var desig;
            var ddldesig = document.getElementById("<%=ddlDesignation.ClientID%>").value;
            var ddldiv = document.getElementById("<%=ddlDivision.ClientID%>").value;
            if (ddldesig == "--SELECT DESIGNATION--")
            {
                desig = 0;


            }
            else
                desig = document.getElementById("<%=ddlDesignation.ClientID%>").value;
            if (ddldiv == "--SELECT DIVISION--")
            {
                div = 0;


            }
            else
                div = document.getElementById("<%=ddlDivision.ClientID%>").value;
            var Details = PageMethods.GetEmployeeCount(desig, div, function (response) {
                document.getElementById("<%=txtnoEmpInSamepos.ClientID%>").value = response;
                return true;
            });
         //    alert('fggggf');
            return true;
        }


    </script>
     <script type="text/javascript">
         var $Mo = jQuery.noConflict();

         function OpenCancelView() {



             document.getElementById("MymodalCancelView").style.display = "block";
             document.getElementById("freezelayer").style.display = "";
             document.getElementById("<%=txtCnclReason.ClientID%>").focus();

              return false;

          }
          function CloseCancelView() {
              if (confirm("Do you want to close  without completing cancellation process?")) {
                  document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById('imgMessageArea').src = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("MymodalCancelView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
              }
              return false;
          }
         //validation when cancel process
         function ValidateCancelReason() {
             // replacing < and > tags
             var NameWithoutReplace = document.getElementById("<%=txtCnclReason.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCnclReason.ClientID%>").value = replaceText2;

            var divErrorMsg = document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
            var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "";
            var Reason = document.getElementById("<%=txtCnclReason.ClientID%>").value.trim();
            if (Reason == "") {
                document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                return false;
            }
            else {
                Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                Reason = Reason.replace(/[ ]{2,}/gi, " ");
                Reason = Reason.replace(/\n /, "\n");
                if (Reason.length < "10") {
                    document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                    document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                    return false;
                }
            }
             document.getElementById("<%=HiddenRjct.ClientID%>").value = document.getElementById("<%=txtCnclReason.ClientID%>").value;
                 
        }

          function ReCallAlert(href) {

              if (confirm("Do you want to Recall this Entry?")) {
                  window.location = href;
                  return false;
              }
              else {
                  return false;
              }
          }

    </script>
    <script>

             var confirmbox = 0;

             function IncrmntConfrmCounter() {
                 
                 confirmbox++;
             }
             function ConfirmMessage() {
                 if (confirmbox > 0) {
                     if (confirm("Are you sure you want to leave this page?")) {
                         window.location.href = "gen_Manpower_Recruitment_List.aspx";
                     }
                     else {
                         return false;
                     }
                 }
                 else {
                     window.location.href = "gen_Manpower_Recruitment_List.aspx";

                 }
             }
             function AlertClearAll() {
                 if (confirmbox > 0) {
                     if (confirm("Are you sure you want cancel?")) {
                         window.location.href = "gen_Manpower_Recruitment_List.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 }
                 else {
                     window.location.href = "gen_Manpower_Recruitment_List.aspx";
                     return false;
                 }
             }
             function ClearAll() {
                 if (confirmbox > 0) {
                     if (confirm("Are you sure you want clear all data in this page?")) {
                         window.location.href = "gen_Manpower_Recruitment.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 }
                 else {
                     window.location.href = "gen_Manpower_Recruitment.aspx";
                     return false;
                 }
             }

             function SuccessConfirmation()
             {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Manpower details created successfully.";
         
            //  document.getElementById("<%=txtYrOfExp.ClientID%>").value = "";
             //    document.getElementById("<%=txtrsnforrqrmnt.ClientID%>").value = "";
              //   document.getElementById("<%=ddlDepartment.ClientID%>").value = 0;
              //   document.getElementById("<%=ddlDesignation.ClientID%>").value = "";
               //  document.getElementById("<%=ddlDivision.ClientID%>").value = "";
              //   document.getElementById("<%=ddlIdenter.ClientID%>").value = "";
                 //document.getElementById("<%=ddlpaygrade.ClientID%>").value = "";
              //   document.getElementById("<%=ddlProject.ClientID%>").value = "";
                // document.getElementById("<%=txtrsnforrqrmnt.ClientID%>").value = "";
              //   document.getElementById("<%=txtrqstdate.ClientID%>").value = "";

               //  document.getElementById("<%=txtRqrmntNo.ClientID%>").value = "";
               //  document.getElementById("<%=TxtRefNo.ClientID%>").value = "";
              //   document.getElementById("<%=txtothrbenefits.ClientID%>").value = "";
              //   document.getElementById("<%=txtnoEmpInSamepos.ClientID%>").value = "";
//
              //   document.getElementById("<%=TxtdivRqrdDate.ClientID%>").value = "";
              ////   document.getElementById("<%=txtcomments.ClientID%>").value = "";
              //   document.getElementById("<%=txtothrbenefits.ClientID%>").value = "";
               //  document.getElementById("<%=txtnoEmpInSamepos.ClientID%>").value = "";
                document.getElementById("<%=txtrqstdate.ClientID%>").focus();


         }
         function SuccessConfirmed() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Manpower details confirmed successfully";
         }
        function SuccessUpdation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Manpower details updated successfully.";
            document.getElementById("<%=txtrqstdate.ClientID%>").focus();
         }
         function SuccessApproved() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Manpower details approved successfully";
         }
        function SuccessReopened() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Manpower details reopened successfully";
        }
        function SuccessClosed() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Manpower details closed successfully";
        }
        function SuccessRejected() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Manpower details rejected successfully";
        }
         function DuplicationName() {
             document.getElementById('divMessageArea').style.display = "";

             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!.Manpower name can’t be duplicated.";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
       
         }
         function DuplicationCode() {
             document.getElementById('divMessageArea').style.display = "";

             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
         }

    </script>
    <script>
        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
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


    </script>
  

     


       <script>


           function DisableEnter(evt) {

               evt = (evt) ? evt : window.event;
               var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
               if (keyCodes == 13) {
                   return false;
               }
           }
           function ApproveValidate() {
               

               var ret = true;
             
               var dateofrqst = document.getElementById("<%=txtrqstdate.ClientID%>").value.trim();
               var arrDatePickerDate1 = dateofrqst.split("-");
               dateofrqst = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

               var rqrddate = document.getElementById("<%=TxtdivRqrdDate.ClientID%>").value.trim();
               var arrDatePickerDate1 = rqrddate.split("-");
               rqrddate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

               // replacing < and > tags
               if (document.getElementById("<%=HiddenDivHrSts.ClientID%>").value == "1") {
                   var NameWithoutReplace = document.getElementById("<%=txthrnote.ClientID%>").value;
                   var replaceText1 = NameWithoutReplace.replace(/</g, "");
                   var replaceText2 = replaceText1.replace(/>/g, "");

                   document.getElementById("<%=txthrnote.ClientID%>").value = replaceText2;

                   document.getElementById("<%=txtverifieddate.ClientID%>").style.borderColor = "";
                   document.getElementById("<%=txthrnote.ClientID%>").style.borderColor = "";
                   var verdate1 = document.getElementById("<%=txtverifieddate.ClientID%>").value;

                

                   var hrnote = document.getElementById("<%=txthrnote.ClientID%>").value;
                  

                   if (hrnote == "") {



                       document.getElementById('divMessageArea').style.visibility = "visible";
                       document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                       document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                       // document.getElementById('divCustomerDetails').style.display = "";
                       // var ErrorMsg = document.getElementById('ErrorMsgEmail').style.display = "";
                       // document.getElementById('ErrorMsgEmail').style.display = "";
                       var OrgMobileFocus = document.getElementById("<%=txthrnote.ClientID%>").focus();
                       document.getElementById("<%=txthrnote.ClientID%>").style.borderColor = "Red";
                       ret = false;
                   }
                   if (verdate1 == "") {



                       document.getElementById('divMessageArea').style.visibility = "visible";
                       document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                       document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                       // document.getElementById('divCustomerDetails').style.display = "";
                       // var ErrorMsg = document.getElementById('ErrorMsgEmail').style.display = "";
                       // document.getElementById('ErrorMsgEmail').style.display = "";
                       var OrgMobileFocus = document.getElementById("<%=txtverifieddate.ClientID%>").focus();
                       document.getElementById("<%=txtverifieddate.ClientID%>").style.borderColor = "Red";
                       ret = false;
                   }
                   var verdate = document.getElementById("<%=txtverifieddate.ClientID%>").value;
                   var arrDatePickerDate1 = verdate.split("-");
                   verdate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
                   if (dateofrqst > verdate) {
                       document.getElementById("<%=txtverifieddate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtverifieddate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtverifieddate.ClientID%>").focus();
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,verified date cannot be smaller than request date !.";
                ret = false;
            }
               }
              
               if (dateofrqst > rqrddate) { //3emp17

                   document.getElementById("<%=TxtdivRqrdDate.ClientID%>").style.borderColor = "Red";
                   //document.getElementById("<%=TxtdivRqrdDate.ClientID%>").style.borderColor = "Red";
                   document.getElementById("<%=txtrqstdate.ClientID%>").focus();
                   document.getElementById('divMessageArea').style.display = "";
                   document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,request date cannot be greater than required date !.";
                  ret = false;
              }

            return ret;
           }
           function allnumeric() {
               
               var totlnorsrc = document.getElementById("<%=txtRqrmntNo.ClientID%>").value;
             //  var totlexp = document.getElementById("<%=txtYrOfExp.ClientID%>").value;
           
               var numbers = /^[0-9]+$/;
               if (!numbers.test(totlnorsrc)) {
                   document.getElementById("<%=txtRqrmntNo.ClientID%>").value = "";
                   return true;
               }
             
               else {
               
              
                   return false;
               }
           }
           function allnumeric1() {

            
                var totlexp = document.getElementById("<%=txtYrOfExp.ClientID%>").value;

                var numbers = /^[0-9]+$/;
     
               if (!numbers.test(totlexp)) {
                   document.getElementById("<%=txtYrOfExp.ClientID%>").value = "";
                   return true;
               }
               else {


                   return false;
               }
           }
        function Validate() {

            var ret = true;

            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtothrbenefits.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtothrbenefits.ClientID%>").value = replaceText2;


              var NameWithoutReplace = document.getElementById("<%=txtcomments.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtcomments.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtnoEmpInSamepos.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtnoEmpInSamepos.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtothrbenefits.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtothrbenefits.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=TxtRefNo.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=TxtRefNo.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtRqrmntNo.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtRqrmntNo.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtrsnforrqrmnt.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtrsnforrqrmnt.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtYrOfExp.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtYrOfExp.ClientID%>").value = replaceText2;



              //$noCon("div#divProject input.ui-autocomplete-input").css("borderColor", "");
              //$noCon("div#divCntrctType input.ui-autocomplete-input").css("borderColor", "");
              //$noCon("div#divJobCtgry input.ui-autocomplete-input").css("borderColor", "");
              //$noCon("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "");


              //document.getElementById('ErrorMsgMob').style.display = "none";
              document.getElementById('divMessageArea').style.display = "none";
              document.getElementById('imgMessageArea').src = "";


              document.getElementById("cphMain_divCheckBox").style.borderColor = "";

              document.getElementById("<%=txtYrOfExp.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtrsnforrqrmnt.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlDepartment.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlDesignation.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlIdenter.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlpaygrade.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlProject.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtrsnforrqrmnt.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtrqstdate.ClientID%>").style.borderColor = "";

              document.getElementById("<%=txtRqrmntNo.ClientID%>").style.borderColor = "";
              document.getElementById("<%=TxtRefNo.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtothrbenefits.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtnoEmpInSamepos.ClientID%>").style.borderColor = "";

              document.getElementById("<%=TxtdivRqrdDate.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtcomments.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtothrbenefits.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtnoEmpInSamepos.ClientID%>").style.borderColor = "";
              var dateofrqstfld = document.getElementById("<%=txtrqstdate.ClientID%>").value.trim();

              var dateofrqst = document.getElementById("<%=txtrqstdate.ClientID%>").value.trim();
              var arrDatePickerDate1 = dateofrqst.split("-");
              dateofrqst = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
              var rqrddatefld = document.getElementById("<%=TxtdivRqrdDate.ClientID%>").value.trim();

               var rqrddate = document.getElementById("<%=TxtdivRqrdDate.ClientID%>").value.trim();
              var arrDatePickerDate1 = rqrddate.split("-");
              rqrddate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

              //alert(rqrddatefld);
              var totlnorsrc = document.getElementById("<%=txtRqrmntNo.ClientID%>").value;
              //  var CountryName = Country.options[Country.selectedIndex].text;
              var ddldesig = document.getElementById("<%=ddlDesignation.ClientID%>").value;
              var sampos = document.getElementById("<%=txtnoEmpInSamepos.ClientID%>").value;
              var yrofexp = document.getElementById("<%=txtYrOfExp.ClientID%>").value.trim();
              var prefnattlbty = document.getElementById("<%=chkbxListCountry.ClientID%>").value;
              var ddlidentr = document.getElementById("<%=ddlIdenter.ClientID%>").value;
              var paygrde = document.getElementById("<%=ddlpaygrade.ClientID%>").value;
              var refnum = document.getElementById("<%=TxtRefNo.ClientID%>").value;
              var mobileregular = /^(\+91-|\+91|0)?\d{0,50}$/;

              var filter = /^[A-Z0-9]+$/;
















              if (ddlidentr == "--SELECT IDENTER--") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  //     document.getElementById('divCustomerDetails').style.display = "";
            document.getElementById("<%=ddlIdenter.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=ddlIdenter.ClientID%>").focus();
                  ret = false;
              }
              if (paygrde == "--SELECT PAYGRADE--") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  //     document.getElementById('divCustomerDetails').style.display = "";
                  document.getElementById("<%=ddlpaygrade.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=ddlpaygrade.ClientID%>").focus();
                  ret = false;
              }

              var flag = 0;
              var RowCount = document.getElementById("<%=HiddenFieldCbxCount.ClientID%>").value;
              if (document.getElementById("cphMain_Chkall").checked == false) {
                  // alert("sebaaaaaaaaaaga");

                  for (var i = 0; i < RowCount; i++) {
                      if (document.getElementById("cphMain_chkbxListCountry_" + i).checked == true) {
                          //     alert("sebaaaaaaaaaaa");
                          flag = 1;
                      }
                  }

              }
              else
                  flag = 1;

              if (flag == "0") {
                  //  alert("sebaaaaaaaaadaa");
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                          //     document.getElementById('divCustomerDetails').style.display = "";
                  document.getElementById("cphMain_divCheckBox").style.borderColor = "Red";
                  document.getElementById("<%=chkbxListCountry.ClientID%>").focus();
                         ret = false;
                     }
                     if (yrofexp == "") {

                         document.getElementById('divMessageArea').style.display = "";
                         document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  //     document.getElementById('divCustomerDetails').style.display = "";
                  document.getElementById("<%=txtYrOfExp.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtYrOfExp.ClientID%>").focus();
                  ret = false;
              } if (sampos == "") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  //     document.getElementById('divCustomerDetails').style.display = "";
                  document.getElementById("<%=txtnoEmpInSamepos.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtnoEmpInSamepos.ClientID%>").focus();
                  ret = false;
              }
              if (ddldesig == "--SELECT DESIGNATION--") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  //     document.getElementById('divCustomerDetails').style.display = "";
                  document.getElementById("<%=ddlDesignation.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=ddlDesignation.ClientID%>").focus();
                  ret = false;
              }
              if (refnum == "") {



                  document.getElementById('divMessageArea').style.visibility = "visible";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  // document.getElementById('divCustomerDetails').style.display = "";
                  // var ErrorMsg = document.getElementById('ErrorMsgEmail').style.display = "";
                  // document.getElementById('ErrorMsgEmail').style.display = "";
                  var OrgMobileFocus = document.getElementById("<%=TxtRefNo.ClientID%>").focus();
                  document.getElementById("<%=TxtRefNo.ClientID%>").style.borderColor = "Red";
                  ret = false;
              }
              if (totlnorsrc != "") {


                  if (!filter.test(totlnorsrc)) {





                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Total number of requirement cannot be zero";

                      //  document.getElementById('ErrorMsgMob').style.display = "";
                      // document.getElementById('ErrorMsgMob').innerHTML = "Inavalid Mobile Number";
                      var OrgMobileFocus = document.getElementById("<%=txtRqrmntNo.ClientID%>").focus();
                      document.getElementById("<%=txtRqrmntNo.ClientID%>").style.borderColor = "Red";
                      ret = false;

                  }

              }



              if (totlnorsrc == "0") {


                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Total number of requirement cannot be zero";

                  //  document.getElementById('ErrorMsgMob').style.display = "";
                  // document.getElementById('ErrorMsgMob').innerHTML = "Inavalid Mobile Number";
                  var OrgMobileFocus = document.getElementById("<%=txtRqrmntNo.ClientID%>").focus();
                  document.getElementById("<%=txtRqrmntNo.ClientID%>").style.borderColor = "Red";
                  ret = false;

              }

              if (totlnorsrc == "") {


                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                  //  document.getElementById('ErrorMsgMob').style.display = "";
                  // document.getElementById('ErrorMsgMob').innerHTML = "Inavalid Mobile Number";
                  var OrgMobileFocus = document.getElementById("<%=txtRqrmntNo.ClientID%>").focus();
                  document.getElementById("<%=txtRqrmntNo.ClientID%>").style.borderColor = "Red";
                  ret = false;

              }
              if (dateofrqst > rqrddate) { //3emp17

                  document.getElementById("<%=TxtdivRqrdDate.ClientID%>").style.borderColor = "Red";
                  //document.getElementById("<%=TxtdivRqrdDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtrqstdate.ClientID%>").focus();
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,request date cannot be greater than required date !.";
                   ret = false;
               }

               if (rqrddatefld == "") {

                   document.getElementById('divMessageArea').style.display = "";
                   document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                   document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                  document.getElementById("<%=TxtdivRqrdDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=TxtdivRqrdDate.ClientID%>").focus();
                  ret = false;
              }

              if (dateofrqstfld == "") {



                  document.getElementById('divMessageArea').style.visibility = "visible";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  // document.getElementById('divCustomerDetails').style.display = "";
                  // var ErrorMsg = document.getElementById('ErrorMsgEmail').style.display = "";
                  // document.getElementById('ErrorMsgEmail').style.display = "";
                  var OrgMobileFocus = document.getElementById("<%=txtrqstdate.ClientID%>").focus();
                  document.getElementById("<%=txtrqstdate.ClientID%>").style.borderColor = "Red";
                  ret = false;
              }
              return ret;

        }
           function DateChk() {
               if (document.getElementById("<%=txtrqstdate.ClientID%>").value != "") {
                   var datepickerDate1 = document.getElementById("<%=txtrqstdate.ClientID%>").value;
                   var arrDatePickerDate1 = datepickerDate1.split("-");
                   var dateTxIss1 = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);


                   var dateCurrentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;
                   var arrDateCurrentDate = dateCurrentDate.split("-");
                   var CurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);

                   if (CurrentDate < dateTxIss1) {
                       //evm-0023 message show in message label
                       document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, date of request should be less than or equal to current date !";
                       //alert("Sorry, issue date should be less than or equal to current date !");
                       document.getElementById("<%=txtrqstdate.ClientID%>").focus();
                       document.getElementById("<%=txtrqstdate.ClientID%>").value = "";
                       document.getElementById('divMessageArea').style.display = "";

                   }
                   else {
                       document.getElementById('divMessageArea').style.display = "none";
                   }
               }
           }

    </script>

      <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                               <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                           <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
     <asp:HiddenField ID="Hiddenenablecancl" runat="server" />
             <asp:HiddenField ID="HiddenHrCnfrm" runat="server" />
               <asp:HiddenField ID="HiddenGMApprove" runat="server" />
      <asp:HiddenField ID="Hiddenenabledit" runat="server" />
               <asp:HiddenField ID="HiddenRjct" runat="server" />
    <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="HiddenDivHrSts" runat="server" />
     <div class="cont_rght" style="padding-top: 1%;">

        <div id="divMessageArea" style="display: none; margin: 0px 0 13px;">
            <img id="imgMessageArea" src="">
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 22%; height: 26.5px;">

            <%--   <a href="gen_ProjectsList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div class="fillform" style="width: 100%">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; margin-bottom: 2%;">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
                <div id="divImage" style="float: right;margin-right:3%;margin-top:-7%">
                       
                        <asp:ImageButton ID="imgbtnReOpen" runat="server" OnClientClick="return ConfirmReOpen();" Style="margin-left: 0%;" OnClick="imgbtnReOpen_Click" />
                         <p id="imgReOpen" class="imgDescription" style="color: white">ReOpen Confirmed Entry</p>   
                    </div>
               <div class="eachform" style="float:left;width:49%">
                <h2>Date Of Request*</h2>
                
               <div id="div1" class="input-append date" style="float:right;margin-right:8%;width: 49%;">

                 
                   
                        <asp:TextBox ID="txtrqstdate"  class="form1" placeholder="DD-MM-YYYY" MaxLength="20" onblur=" DateChk();" runat="server" Height="30px" Width="71%" Style="height:30px;width:88.6%;margin-top: 0%;float:left;margin-left: -2.3%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image1" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:-0.2%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#div1').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                // startDate: new Date(),
                                endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
                  <div class="eachform" style="float:right;width:48.4%">
                <h2>Required Date*</h2>
                
               <div id="divRqrdDate" class="input-append date" style="float:right;margin-right:8%;width: 49%;">

                 
                   
                        <asp:TextBox ID="TxtdivRqrdDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:30px;width:90.6%;margin-top: 0%;float:left;margin-left: -2.8%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image6" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:-0.2%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divRqrdDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                               // endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
        
            
                <div class="eachform" style="float:left;width: 48.4%;">
                    <h2 style="margin-left: 0%">Total Number Of Resources*</h2>

                   <asp:TextBox ID="txtRqrmntNo"  class="form1" runat="server"  MaxLength="6" Style="width: 50%; text-transform: uppercase; height: 30px;margin-right: 4.5%;" onblur="return allnumeric()" onkeydown="return isNumber(event)"></asp:TextBox>
                   </div>
                  <div class="eachform" style="float:right;width: 48.4%;">
                    <h2 style="margin-left: 0%">Reference Number*</h2>
   <asp:TextBox ID="TxtRefNo"  class="form1" runat="server" MaxLength="50" Style="width: 50.3%; text-transform: uppercase; margin-right: 5.0%; height: 30px" Enabled="false"></asp:TextBox>



                            </div>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                   <ContentTemplate>  
            <div style="float:left;width:100%">
              <div class="eachform" style="float:left;width: 48.4%;"">
               <h2 style="float: left;">Designation*</h2>    <%--emp17--%>
                
                <asp:DropDownList ID="ddlDesignation" Height="30px" Width="53.2%" class="form1" onchange="return GetEmployeeCount();" runat="server" Style="text-align:left;margin-right:4.5%;float:right;"  ></asp:DropDownList>
                
                </div>
                 <div class="eachform" style="float:right;width: 48.4%;">
                <h2>Department </h2>
                
                  <asp:DropDownList ID="ddlDepartment" Height="30px" Width="53.2%" class="form1"  runat="server" Style="text-align:left;margin-right: 5%;float:right" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList>
              
            </div>
                       
                      </div>
                      <div style="width:100%;float:left" >
                           
                       <div class="eachform" style="float:left;width: 48.4%;">
                <h2>Division</h2>
                
                  <asp:DropDownList ID="ddlDivision" Height="30px" Width="53.6%" class="form1" runat="server" Style="text-align:left;float: right;margin-right: 4.5%;" AutoPostBack="true" onchange=" GetEmployeeCount();" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList>
              
            </div>
           
            <div class="eachform" style="float:right;width: 48.4%;margin-left: 3%;">
                <h2>Project</h2>
                
                  <asp:DropDownList ID="ddlProject" Height="30px" Width="53.5%" class="form1" runat="server"  Style="text-align:left;float:right;margin-right:5%;" onchange="return loadprojassign();"></asp:DropDownList>
              
            </div>
     </div>  
            </ContentTemplate>

            </asp:UpdatePanel>
                 <div id="divCntrctType" class="eachform" style="width: 48.4%; float: left;">
                    <h2 style="width: 41%;">No. of Employees in the same position*</h2>
                 <asp:TextBox ID="txtnoEmpInSamepos" class="form1" runat="server" MaxLength="50" Enabled="false" Text="0" Style="width: 50%;  text-transform: uppercase; margin-right: 4.5%; height: 30px"></asp:TextBox>
           </div>

                   <div class="eachform" style="width: 48.4%; float: right;">
                    <h2 >Relevant Years of Experience*</h2>
                     <asp:TextBox ID="txtYrOfExp" class="form1" runat="server" MaxLength="2" Style="width: 50.3%; text-transform: uppercase; margin-right: 5%; height: 30px" onblur="return allnumeric1()"  onkeydown="return isNumber(event)"></asp:TextBox>
                     
                </div>
            <div style="float:left;width:100%">
                 <div class="eachform" style="width: 49.4%;float: left;">
                    <h2>Proposed Pay Grade*</h2>
                   
                  <asp:DropDownList ID="ddlpaygrade" Height="30px" Width="52%" class="form1" runat="server"  Style="text-align:left;float:right;margin-right: 6.5%;text-transform: uppercase;" onchange="return loadprojassign();"></asp:DropDownList>
              
                </div>

                  <div class="eachform" style="width: 48.4%; float: right;">
                    <h2>Indenter*</h2>
                      
                  <asp:DropDownList ID="ddlIdenter" Height="30px" Width="50.5%" class="form1" runat="server"  Style="text-align:left;float:right;margin-right: 5%;" onchange="return loadprojassign();"></asp:DropDownList>
              </div>
                 


 



            </div>

             <div style="float:left;width:100%;font-family:Calibri">
                  
                     <div class="eachform" style="width: 49%; float: left;">
                    <h2>Any Other Benefits </h2>
                     <asp:TextBox ID="txtothrbenefits"  TextMode="MultiLine" class="form1" runat="server" MaxLength="95" Style="width: 49%;  margin-right: 6%; height: 80px; resize:none;font-family:Calibri" onblur="textCounter(cphMain_txtothrbenefits,95)" onkeydown="textCounter(cphMain_txtothrbenefits,95)" onkeyup="textCounter(cphMain_txtothrbenefits,95)"></asp:TextBox>
                    
                </div>
       <div class="eachform" style="width: 49%; float: right;font-family:Calibri">
                    <h2 style="margin-left: 1.2%;">Reason for Requirement</h2>
                     <asp:TextBox ID="txtrsnforrqrmnt"  class="form1" TextMode="MultiLine" runat="server" MaxLength="95" Style="width: 50%; margin-right: 4.7%; height: 80px;resize:none;font-family:Calibri" onblur="textCounter(cphMain_txtrsnforrqrmnt,95)" onkeydown="textCounter(cphMain_txtrsnforrqrmnt,95)" onkeyup="textCounter(cphMain_txtrsnforrqrmnt,95)"></asp:TextBox>
                     
                </div>
                 </div>
            <div style="float:left;width:100%;font-family:Calibri">
  
            	           <div class="eachform" style="width: 48.4%; float: left;">
                    <h2>Comments</h2>
                     <asp:TextBox ID="txtcomments" class="form1" runat="server" MaxLength="95" TextMode="MultiLine" Style="width: 50%;  margin-right:4.7%; height: 80px; resize:none;font-family:Calibri" onblur="textCounter(cphMain_txtcomments,95)" onkeydown="textCounter(cphMain_txtcomments,95)" onkeyup="textCounter(cphMain_txtcomments,95)"></asp:TextBox>
                                     <p class="error" id="ErrorMsgEmail" style="display:none">Please Enter Valid Email Id</p>
                </div>
                
                 <div class="eachform" style="float:right;width: 48.4%;margin-right: 0.0%;height: 80px">

             <h2>Preferred Nationalities*</h2>
                           <asp:CheckBox ID="Chkall" onchange="return changeAll()" runat="server" Style="float: left;margin-left: 13.2%;font-family:Calibri" Text="All"/>
               <div id="divCheckBox" runat="server" style="width: 53.5%;margin-right: 4.6%;">
             
                <asp:CheckBoxList  ID="chkbxListCountry"  runat="server">

                </asp:CheckBoxList>
                   </div>
                </div>
         

    
            </div>
                <asp:HiddenField ID="HiddenFieldCbxCount" runat="server" />
              <script type="text/javascript">



                  function changeAll() {
                 
                      var RowCount = document.getElementById("<%=HiddenFieldCbxCount.ClientID%>").value;
               

                      if (document.getElementById("cphMain_Chkall").checked == true) {


                        for (var i = 0; i < RowCount; i++) {
                            if (document.getElementById("cphMain_chkbxListCountry_" + i).disabled == false)
                            {
                                document.getElementById("cphMain_chkbxListCountry_" + i).checked = true;
                            }

                        }



                    }
                    else {

                        for (var i = 0; i < RowCount; i++) {
                            if (document.getElementById("cphMain_chkbxListCountry_" + i).disabled == false) {
                                document.getElementById("cphMain_chkbxListCountry_" + i).checked = false;
                            }

                        }

                    }

                      return false;
                }
         </script>
            <div class="eachform" style="margin-top: 1%;float: left;width: 48.4%;">
                <h2>Status*</h2>
                <div class="subform" style="float: right;margin-right: 15.5%;padding-top: 8px;">


                    <asp:CheckBox ID="cbxStatus" Text="" runat="server" Checked="true" onclick="IncrmntConfrmCounter()" onkeydown="return DisableEnter(event)" class="form2" />
                    <h3>Active</h3>

                </div>
            </div>
                    <div id="divhApproval" runat="server"   style="float:left;font-family: Calibri;width:100%;border: .5px solid;border-color: #9ba48b;background-color: #f3f3f3;">
    <h2 style="width: 100%;font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; margin-bottom: 2%;float:left;margin-left:1%">HR Department*</h2>
         <div class="eachform" style="float:left;margin-left:1%;width: 51.4%;">
                <h2>Request Verified Date*</h2>
                
               <div id="divVerifiedDate" class="input-append date" style="width: 53%; float: right;margin-right:2%;">

                 
                   
                     
                        <asp:TextBox ID="txtverifieddate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="width:83%;float:left;height: 30px;" onkeydown="return DisableEnter(event)" ></asp:TextBox>      <%--//emp17--%>

              
                        <input type="image" runat="server" id="Image18" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divVerifiedDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                              
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              
            </div>
                          <div class="eachform" style="width: 51.4%; float: left;margin-left:1%;font-family:Calibri;">
                    <h2>Notes From HR*</h2>
                     <asp:TextBox ID="txthrnote" class="form1" runat="server" MaxLength="50" TextMode="MultiLine" Style="width: 50%; text-transform: uppercase; margin-right: 2.3%; height: 90px; resize:none;font-family: calibri;" onblur="textCounter(cphMain_txtcomments,95)" onkeydown="textCounter(cphMain_txtcomments,95)" onkeyup="textCounter(cphMain_txtcomments,95)"></asp:TextBox>
                                     <p class="error" id="P1" style="display:none">Please Enter Valid Email Id</p>
                </div>
                           <div id="DivGmreject" runat="server" class="eachform" style="width: 51.4%; float: left;margin-left:1%;font-family:Calibri;">
                    <h2>GM Reject Reason*</h2>
                     <asp:TextBox ID="txtgmNotes" class="form1" runat="server" MaxLength="50" TextMode="MultiLine" Style="width: 50%; text-transform: uppercase; margin-right: 2.3%; height: 90px; resize:none;font-family: calibri;" Enabled="false" onblur="textCounter(cphMain_txtgmNotes,95)" onkeydown="textCounter(cphMain_txtgmNotes,95)" onkeyup="textCounter(cphMain_txtgmNotes,95)"></asp:TextBox>
                                     <p class="error" id="P2" style="display:none">Please Enter Valid Email Id</p>
                </div>
                        </div>
                <div class="eachform" style="width: 99%; margin-top: 3%; float: left">
                    <div class="subform" style="width: 70%; margin-left: 38%">
                           <asp:Button ID="btnHrconfirm"  runat="server" class="save" Text="Verify" OnClientClick="return ApproveValidate();" OnClick="btnHrconfirm_Click" />
                <asp:Button ID="brnGMapprove"  runat="server" class="save" Text="Approve" OnClientClick="return ApproveValidate();" OnClick="brnGMapprove_Click" />
                  <asp:Button ID="btnConfirm"  runat="server" class="save" Text="Confirm" OnClientClick="return ApproveValidate();" OnClick="btnConfirm_Click" />
                    <asp:Button ID="btnGMreject"  runat="server" class="save" Text="Reject" OnClientClick="return OpenCancelView();" OnClick="btnGMreject_Click" />
                    <asp:Button ID="btnHrReject"  runat="server" class="save" Text="Reject" OnClientClick="return ApproveValidate();" OnClick="btnreject_Click" />

                    <asp:Button ID="btnUpdate"  runat="server" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClose"  runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnAdd"  runat="server" class="save" Text="Save" OnClick="btnAdd_Click"  OnClientClick="return Validate();" />
       
                    <asp:Button ID="btnAddClose"  runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate(); " />
                    <asp:Button ID="btnCancel" TabIndex="0"   runat="server" class="cancel" OnClientClick="return AlertClearAll();" Text="Cancel"   />
                    <asp:Button ID="btnClear" runat="server" style="margin-left: 19px;" OnClientClick="return ClearAll();"  class="cancel" Text="Clear"/>
                        <asp:HiddenField ID="Hiddenrqstid" runat="server" />
                   <asp:HiddenField ID="hiddenenxtid" runat="server" />
                                   <asp:HiddenField ID="hiddenRsnid" runat="server" />
               </div>
                </div>


                <br style="clear: both" />
            </div>

            <div id="divManpower" class="table-responsive" style="height:370px;" runat="server">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

  <div id="div2" style="float: right;margin-right:3%;margin-top:-7%">
                       
                        <asp:ImageButton ID="imgBtnClose" class="tooltip" title="Close" TabIndex="0" runat="server" OnClientClick="return ConfirmClose();" Style="margin-left: 0%;opacity:1;position:relative;z-index: 29" OnClick="imgBtnClose_Click" />  
                         
                    </div>


        </div>
         </div>
                                 <%--------------------------------View for error Reason--------------------------%>
               <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="return CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Manpower Requirement</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Reject Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save"  style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" OnClientClick="return ValidateCancelReason();"  OnClick="btnGMreject_Click"  />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="return CloseCancelView();" runat="server" Text="Close" />
                             </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
       <style>

        .form1 {
            
            height: 27px;
        }
          .open > .dropdown-menu {
            display: none;
        }
    </style>
    <script>
        function ConfirmReOpen() {


            if (confirm("Are you sure you want to reopen?")) {
                           return true;
            }
            else {

                //CheckSubmitZero();
                return false;
            }

        }
        function ConfirmClose() {


            if (confirm("Are you sure you want to close?")) {
                  return true;
            }
            else {

               // CheckSubmitZero();
                return false;
            }

        }


    </script>
</asp:Content>

