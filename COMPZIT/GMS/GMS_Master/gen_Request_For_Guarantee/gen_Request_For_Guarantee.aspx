<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="gen_Request_For_Guarantee.aspx.cs" Inherits="GMS_GMS_Master_gen_Request_For_Guarantee_gen_Request_For_Guarantee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
      <style>
          /*EVM-0016*/
          .custom-file-upload {
              margin-left: 13.3%;
              border: 1px solid #ccc;
              display: inline-block;
              padding: 2px 4px;
              cursor: pointer;
              position: relative;
              z-index: 2;
              font-family: Calibri;
              background: white;
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
              right: 18%;
              z-index: 103;
          }

              .lightbox-target:target img {
                  max-height: 100%;
                  max-width: 80%;
              }

              .lightbox-target:target a.lightbox-close {
                  top: 0px;
              }
          /*EVM-0016*/
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

          #DivreissueErrormsg {
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
     <style type="text/css">
         .ui-autocomplete {
             padding: 0;
             list-style: none;
             background-color: #fff;
             width: 218px;
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

         input[type="radio"] {
             display: inline-block;
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
     </style>
 <style>
     #cphMain_divReport {
         float: left;
         width: 93.5%;
     }



     #TableRprtRow .tdT {
         line-height: 100%;
     }


     .cont_rght {
         width: 98%;
     }
 </style>
   <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

           <script>
               function addCommas() {

                   IncrmntConfrmCounter();
                   nStr = document.getElementById("<%=txtAmount.ClientID%>").value;
                   nStr += '';
                   var x = nStr.split('.');
                   var x1 = x[0];
                   var x2 = x[1];

                   if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "1") {
                       var rgx = /(\d+)(\d{7})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                       rgx = /(\d+)(\d{5})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                       rgx = /(\d+)(\d{3})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                   }

                   if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "2") {
                       var rgx = /(\d+)(\d{9})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }

                       rgx = /(\d+)(\d{6})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                       rgx = /(\d+)(\d{5})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                       rgx = /(\d+)(\d{3})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                   }
                   if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "3") {
                       var rgx = /(\d+)(\d{9})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                       rgx = /(\d+)(\d{6})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                       rgx = /(\d+)(\d{3})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                   }




                   if (isNaN(x2))
                       document.getElementById("<%=txtAmount.ClientID%>").value = x1;
                       //return x1;
                   else
                       document.getElementById("<%=txtAmount.ClientID%>").value = x1 + "." + x2;
                   // return x1 + "." + x2;
               }

    </script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            document.getElementById("freezelayer").style.display = "none";
            document.getElementById('MymodalCancelView').style.display = "none";
            document.getElementById('DivmodalCancelView').style.display = "none";
            var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
            if (CancelPrimaryId != "") {
                OpenCancelView();
            }
            //  OpenHistory();
            //document.getElementById("ClearImage").disabled = true;
            if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {

                  //IncrmntConfrmCounter();
                  document.getElementById("divExistingEmp").style.display = "none";
                  document.getElementById("divNewEmp").style.display = "";


              }
              else {
                  //IncrmntConfrmCounter();
                  document.getElementById("divNewEmp").style.display = "none";
                  document.getElementById("divExistingEmp").style.display = "";

              }
              document.getElementById("<%=hiddenDup.ClientID%>").value != "";

            if (document.getElementById("<%=hiddenConfirmOrNot.ClientID%>").value != "1") {
                if (document.getElementById("<%=radioLimited.ClientID%>").checked == true) {
                    document.getElementById("<%=txtValidity.ClientID%>").disabled = false;
                }
                else if (document.getElementById("<%=radioOpen.ClientID%>").checked == true) {
                    document.getElementById("<%=txtValidity.ClientID%>").disabled = true;
                }
        }

            AmountChecking('cphMain_txtAmount');

            addCommas();
        });
    </script>
    <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {
               // $au('#cphMain_ddlGuaranteCat').selectToAutocomplete1Letter();
                $au('#cphMain_ddlProject').selectToAutocomplete1Letter();
                $au('#cphMain_ddlCustomer').selectToAutocomplete1Letter();
                $au('#cphMain_ddlCurrency').selectToAutocomplete1Letter();
                $au('#cphMain_ddlJobCategory').selectToAutocomplete1Letter();
                $au('#cphMain_ddlExistingEmp').selectToAutocomplete1Letter();
                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);



       

    </script>
      <script language="javascript" type="text/javascript">
          var submit = 0;
          function CheckIsRepeat() {
              if (++submit > 1) {

                  return false;
              }
              else {
                  return true;
              }
          }
          function CheckSubmitZero() {
              submit = 0;
          }
    </script>
     <script>

         var confirmbox = 0;

         function IncrmntConfrmCounter() {

             confirmbox++;
         }
         function ConfirmMessage() {
             if (confirmbox > 0) {
                 if (confirm("Are You Sure You Want To Leave This Page?")) {
                     window.location.href = "gen_Request_For_Guarantee_List.aspx";
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Request_For_Guarantee_List.aspx";

             }
         }
         function AlertClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                     window.location.href = "gen_Request_For_Guarantee.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Request_For_Guarantee.aspx";
                 return false;
             }
         }


         function SuccessUpdation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Request For Guarantee Details Updated Successfully.";
         }
         function SuccessUpdationPrjct() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Project Details Updated Successfully.";
         }

         function SuccessConfirmation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Request For Guarantee Details Inserted Successfully.";
         }
         function SuccessConfirmationCntrct() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Contract Details Inserted Successfully.";
         }
         function SuccessConfirmationPrjct() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Project Details Inserted Successfully.";
         }

         function SuccessReOpen() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Request For Guarantee Details ReOpened Successfully.";
         }
         function SuccessConfirm() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Request For Guarantee Details Confirmed Successfully.";
         }
         function SuccessReissue() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Request For Guarantee Details Reissued Successfully.";
         }
         function SuccessProceed() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Request For Guarantee Status Changed To Proceed Successfully.";

        }
    </script>
      <script type="text/javascript" >
          function isNumber(evt, textboxid) {
              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
              var charCode = (evt.which) ? evt.which : evt.keyCode;

              var txtPerVal = document.getElementById(textboxid).value;
              //enter
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
                  // . period and numpad . period
              else if (keyCodes == 190 || keyCodes == 110) {
                  var ret = true;
                  if (textboxid == "cphMain_txtAmount") {
                      var count = txtPerVal.split('.').length - 1;

                      if (count > 0) {

                          ret = false;
                      }
                      else {
                          ret = true;
                      }
                      return ret;
                  }
                  else {
                      return false;
                  }

              }

              else {
                  var ret = true;
                  if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                      ret = false;
                  }
                  return ret;
              }
          }

          function AmountChecking(textboxid) {
              var txtPerVal = document.getElementById(textboxid).value;

              txtPerVal = txtPerVal.replace(/,/g, "");



              if (txtPerVal == "") {
                  return false;
              }
              else {
                  if (!isNaN(txtPerVal) == false) {
                      document.getElementById('' + textboxid + '').value = "";
                      return false;
                  }
                  else {
                      if (txtPerVal < 0) {
                          document.getElementById('' + textboxid + '').value = "";
                          return false;
                      }
                      var amt = parseFloat(txtPerVal);
                      var num = amt;
                      var n = 0;
                      // for floatting number adjustment from corp global
                      var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                      if (FloatingValue != "") {
                          var n = num.toFixed(FloatingValue);

                      }
                      document.getElementById('' + textboxid + '').value = n;

                  }
              }

              addCommas();
          }
          function NumberChecking(textboxid) {
              var txtPerVal = document.getElementById(textboxid).value;

              txtPerVal = txtPerVal.replace(/,/g, "");



              if (txtPerVal == "") {
                  return false;
              }
              else {
                  if (!isNaN(txtPerVal) == false) {
                      document.getElementById('' + textboxid + '').value = "";
                      return false;
                  }
                  else {
                      if (txtPerVal < 0) {
                          document.getElementById('' + textboxid + '').value = "";
                          return false;
                      }

                  }

              }
          }
          // for not allowing <> tags  and enter
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
          function isTagOnly(evt) {

              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
              var charCode = (evt.which) ? evt.which : evt.keyCode;
              var ret = true;
              if (charCode == 60 || charCode == 62) {
                  ret = false;
              }
              return ret;
          }
          // for not allowing <> tags
          function isTagEnter(evt) {

              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

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

          //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
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
              var NameWithoutReplace = document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtInFavrOf.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtInFavrOf.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtEmpName.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtEmpName.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtAmount.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtAmount.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtValidity.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtValidity.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtCntctMail.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtCntctMail.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtRemarks.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtRemarks.ClientID%>").value = replaceText2;


              document.getElementById("<%=txtPrjctClsngDate.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtCntctMail.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtValidity.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtAmount.ClientID%>").style.borderColor = "";
              document.getElementById("<%=GuarTypeContainer.ClientID%>").style.border = "none";
              $noCon("div#divProject input.ui-autocomplete-input").css("borderColor", "");
              $noCon("div#divCustomer input.ui-autocomplete-input").css("borderColor", "");
              //$noCon("div#divGuaranteCat input.ui-autocomplete-input").css("borderColor", "");
              $noCon("div#divCurrency input.ui-autocomplete-input").css("borderColor", "");
              document.getElementById("<%=ddlGuaranteCat.ClientID%>").style.borderColor = "";


              var Validity = document.getElementById("<%=txtValidity.ClientID%>").value.trim();
              var Amount = document.getElementById("<%=txtAmount.ClientID%>").value.trim();
              var CloseDate = document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value.trim();

              var ProjectDdl = document.getElementById("<%=ddlProject.ClientID%>");
              var ProjectText = ProjectDdl.options[ProjectDdl.selectedIndex].text;

              var GurCatDdl = document.getElementById("<%=ddlGuaranteCat.ClientID%>");
              var GuarCatText = GurCatDdl.options[GurCatDdl.selectedIndex].text;

              var CustomerDdl = document.getElementById("<%=ddlCustomer.ClientID%>");
              var CustomerText = CustomerDdl.options[CustomerDdl.selectedIndex].text;

              var CurrencyDdl = document.getElementById("<%=ddlCurrency.ClientID%>");
              var CurrencyText = CurrencyDdl.options[CurrencyDdl.selectedIndex].value;


              var ContactEmail = document.getElementById("<%=txtCntctMail.ClientID%>").value;
              var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

              document.getElementById('divMessageArea').style.display = "none";
              document.getElementById('imgMessageArea').src = "";

              if (ContactEmail != "") {
                  if (!filter.test(ContactEmail)) {
                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                      document.getElementById("<%=txtCntctMail.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=txtCntctMail.ClientID%>").focus();
                      ret = false;
                  }

              }

              if (CurrencyText == "--SELECT CURRENCY--") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  $noCon("div#divCurrency input.ui-autocomplete-input").css("borderColor", "red");
                  $noCon("div#divCurrency input.ui-autocomplete-input").focus();
                  $noCon("div#divCurrency input.ui-autocomplete-input").select();
                  ret = false;
              }
              if (Amount == "") {
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtAmount.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtAmount.ClientID%>").focus();
                  ret = false;
              }

              if (CloseDate == "") {
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtPrjctClsngDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtPrjctClsngDate.ClientID%>").focus();
                  ret = false;
              }
              else {

                  var TaskdatepickerDate = document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value;
                  var arrDatePickerDate = TaskdatepickerDate.split("-");
                  var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                  var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                  var arrCurrentDate = CurrentDateDate.split("-");
                  var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
                  if (dateDateCntrlr < dateCurrentDate) {
                      document.getElementById("<%=txtPrjctClsngDate.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=txtPrjctClsngDate.ClientID%>").focus();
                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, Closing Date should be greater than Current Date !";
                      ret = false;

                  }
              }
              if (document.getElementById("<%=radioLimited.ClientID%>").checked == true) {
                  if (Validity == "") {
                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtValidity.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtValidity.ClientID%>").focus();
                  ret = false;
              }
          }


          if (CustomerText == "--SELECT CUSTOMER--" || CustomerText == "") {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  $noCon("div#divCustomer input.ui-autocomplete-input").css("borderColor", "red");
                  $noCon("div#divCustomer input.ui-autocomplete-input").focus();
                  $noCon("div#divCustomer input.ui-autocomplete-input").select();
                  ret = false;
              }
              if (GuarCatText == "--SELECT CATEGORY--") {
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  //$noCon("div#divGuaranteCat input.ui-autocomplete-input").css("borderColor", "red");
                  //$noCon("div#divGuaranteCat input.ui-autocomplete-input").focus();
                  //$noCon("div#divGuaranteCat input.ui-autocomplete-input").select();
                  document.getElementById("<%=ddlGuaranteCat.ClientID%>").style.borderColor = "Red";

                  ret = false;
              }
              else {
                  document.getElementById("<%=hiddenGuantCat.ClientID%>").value = document.getElementById("<%=ddlGuaranteCat.ClientID%>").value;
              }

              if (ProjectText == "--SELECT PROJECT--") {
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  $noCon("div#divProject input.ui-autocomplete-input").css("borderColor", "red");
                  $noCon("div#divProject input.ui-autocomplete-input").focus();
                  $noCon("div#divProject input.ui-autocomplete-input").select();
                  ret = false;
              }
              if (document.getElementById("<%=radioOpen.ClientID%>").checked != true && document.getElementById("<%=radioLimited.ClientID%>").checked != true) {
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=GuarTypeContainer.ClientID%>").style.border = "1px solid";
                  document.getElementById("<%=GuarTypeContainer.ClientID%>").style.borderColor = "Red";

                  ret = false;
              }
              if (ret == false) {
                  CheckSubmitZero();

              }
              $noCon(window).scrollTop(0);
              return ret;
          }

    </script>
    <script>
        function ConfirmAlert() {

            if (Validate() == true) {
                if (confirm("Are You Sure You Want To Confirm?")) {
                    return true;
                }
                else {

                    CheckSubmitZero();
                    return false;
                }
            } else {

                CheckSubmitZero();
                return false;
            }

        }

        function ConfirmReOpen() {


            if (confirm("Are You Sure You Want To ReOpen?")) {
                return true;
            }
            else {

                CheckSubmitZero();
                return false;
            }

        }
        function ConfirmClose() {


            if (confirm("Are You Sure You Want To Close?")) {
                return true;
            }
            else {

                CheckSubmitZero();
                return false;
            }

        }
        function closeWindow() {
            window.close();
        }


        function CbxChange() {
            IncrmntConfrmCounter();
            if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {

                //IncrmntConfrmCounter();
                document.getElementById("divExistingEmp").style.display = "none";
                document.getElementById("divNewEmp").style.display = "";

                document.getElementById("<%=ddlExistingEmp.ClientID%>").value = "--SELECT EMPLOYEE--";
                document.getElementById("<%=txtCntctMail.ClientID%>").value = "";
            }
            else {
                $noC = jQuery.noConflict();
                //IncrmntConfrmCounter();
                document.getElementById("divNewEmp").style.display = "none";
                document.getElementById("divExistingEmp").style.display = "";
                document.getElementById("<%=ddlExistingEmp.ClientID%>").value = "--SELECT EMPLOYEE--";
                var a = $noC("#cphMain_ddlExistingEmp option:selected").text();
                $noC("div#divExistingEmp input.ui-autocomplete-input").val(a);

            }

            return false;
        }
        function waitSeconds(iMilliSeconds) {
            //  alert(iMilliSeconds);
            var counter = 0
                , start = new Date().getTime()
                , end = 0;
            while (counter < iMilliSeconds) {
                end = new Date().getTime();
                counter = end - start;
            }
        }

    </script>
   <script>
       $noCon = jQuery.noConflict();

       //EVM-0016
        <%--for delete image description--%>
       function ImagePosition(object) {

           var $Mo = jQuery.noConflict();

           var offset = $Mo("#" + object).offset();

           var posY = 0;
           var posX = 0;
           posY = offset.top;

           posX = offset.left

           posX = 47;

           var d = document.getElementById('RemovePhoto');
           d.style.position = "absolute";
           d.style.left = posX + '%';
           d.style.top = posY + 15 + 'px';
       }

       //for permit file uploader

       function ClearDivDisplayImage() {

           IncrmntConfrmCounter();

           var hidnImageSize = document.getElementById("<%=hiddenPermitFileSize.ClientID%>").value;

           var fuData = document.getElementById("<%=FileUploadRecharge.ClientID%>");
           var size = fuData.files[0].size;
           var convertToKb = hidnImageSize / 1000;
           if (size > hidnImageSize) {
               document.getElementById("<%=FileUploadRecharge.ClientID%>").value = "";
                    document.getElementById("<%=Label3.ClientID%>").textContent = "No File Selected";
                    alert(" Sorry Maximum file size exceeds. Please Upload Image of size less than " + convertToKb + "KB !.");
                    //return false;
                }
                else {

                    if (document.getElementById("<%=FileUploadRecharge.ClientID%>").value != "") {
                        document.getElementById("<%=Label3.ClientID%>").textContent = document.getElementById("<%=FileUploadRecharge.ClientID%>").value;
                        document.getElementById("<%=divImageDisplay.ClientID%>").innerHTML = "";
                        document.getElementById("<%=hiddenRechargeFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenRechargeFile.ClientID%>").value;
                        document.getElementById("<%=hiddenRechargeFile.ClientID%>").value = "";
                    }

                    //    return true;

                }
            }

            function ClearImages() {

                if (document.getElementById("<%=hiddenRechargeFile.ClientID%>").value != "" || document.getElementById("<%=FileUploadRecharge.ClientID%>").value != "") {
               if (confirm("Do You Want To Remove Selected File?")) {
                   IncrmntConfrmCounter();
                   document.getElementById("<%=FileUploadRecharge.ClientID%>").value = "";
                   document.getElementById("<%=hiddenRechargeFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenRechargeFile.ClientID%>").value;
                   document.getElementById("<%=hiddenRechargeFile.ClientID%>").value = "";
                   document.getElementById("<%=divImageDisplay.ClientID%>").innerHTML = "";
                   document.getElementById("<%=Label3.ClientID%>").textContent = "No File Selected";
                   //  alert("Image has been Removed Sucessfully. ");
               }
               else {

               }

           }
       }
       //EVM-0016
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
        }
        function ValidateCancelReasonReissue() {
            // replacing < and > tags
            var ret = true;
            var NameWithoutReplace = document.getElementById("<%=txtreissue.ClientID%>").value;
           var replaceText1 = NameWithoutReplace.replace(/</g, "");
           var replaceText2 = replaceText1.replace(/>/g, "");
           document.getElementById("<%=txtreissue.ClientID%>").value = replaceText2;

              var divErrorMsg = document.getElementById('DivreissueErrormsg').style.visibility = "hidden";
              var txthighlit = document.getElementById("<%=txtreissue.ClientID%>").style.borderColor = "";
           var Reason = document.getElementById("<%=txtreissue.ClientID%>").value.trim();
           if (Reason == "") {
               document.getElementById('DivreissueErrormsg').style.visibility = "visible";
               document.getElementById("<%=Lblreissueerrormsg.ClientID%>").innerHTML = "Please fill this out";
                  document.getElementById("<%=txtreissue.ClientID%>").style.borderColor = "Red";
                  //return false;
                  ret = false;
              }
              else {
                  Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                  Reason = Reason.replace(/[ ]{2,}/gi, " ");
                  Reason = Reason.replace(/\n /, "\n");
                  if (Reason.length < "10") {
                      document.getElementById('DivreissueErrormsg').style.visibility = "visible";
                      document.getElementById("<%=Lblreissueerrormsg.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=txtreissue.ClientID%>").style.borderColor = "Red";
                    //  return false;
                    ret = false;
                }
            }
            if (ret == true) {
                CloseReissueCancelView();
                var CatId = document.getElementById("<%=HiddenViewId.ClientID%>").value;
               var UserId = document.getElementById("<%=HiddenUserId.ClientID%>").value;
               var Reason = document.getElementById("<%=txtreissue.ClientID%>").value.trim();
               var Details = PageMethods.ChangeToReissue(CatId, UserId, Reason, function (response) {

                   var SucessDetails = response;


                   if (SucessDetails == "success") {

                       //if (SearchString == "") {
                       document.getElementById("<%=txtreissue.ClientID%>").value = "";
                       window.location = 'gen_Request_For_Guarantee.aspx?ReissueIddirect=' + CatId + '';
                       //}
                       //else {
                       //    window.location = 'gen_Request_For_Guarantee_List.aspx?InsUpd=PrcedCh&Srch=' + SearchString + '';
                       //}


                   }

               });

           }
           return false;
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
          function OpenCancelViewReissue() {



              document.getElementById("ReisssuemodalCancelView").style.display = "block";
              document.getElementById("freezelayer").style.display = "";
              document.getElementById("<%=txtreissue.ClientID%>").focus();

              return false;

          }
          function OpenCancelViewHisList() {



              document.getElementById("DivmodalCancelView").style.display = "block";
              document.getElementById("freezelayer").style.display = "";


              return false;

          }
          function ReissueCancelView() {
              if (confirm("Do you want to close  without completing Reissue Process?")) {
                  document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById('imgMessageArea').src = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("ReisssuemodalCancelView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
              }
          }
          function CloseReissueCancelView() {

              document.getElementById('divMessageArea').style.display = "none";
              document.getElementById('imgMessageArea').src = "";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("ReisssuemodalCancelView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";

              }
              function CloseCancelView() {
                  if (confirm("Do you want to close  without completing Closing Process?")) {
                      document.getElementById('divMessageArea').style.display = "none";
                      document.getElementById('imgMessageArea').src = "";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("MymodalCancelView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
              }
          }
          function CloseCancelViewHisList() {

              document.getElementById('divMessageArea').style.display = "none";
              document.getElementById('imgMessageArea').src = "";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
              // document.getElementById("MymodalCancelView").style.display = "none";
                  document.getElementById("DivmodalCancelView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";

              }
              function RadioOpenClick() {
                  IncrmntConfrmCounter();
                  document.getElementById("<%=txtValidity.ClientID%>").disabled = true;
          }
          function RadioLimitedClick() {
              IncrmntConfrmCounter();
              document.getElementById("<%=txtValidity.ClientID%>").disabled = false;
          }
          function NewCustPageLoad() {
              var $noC = jQuery.noConflict();


              if (confirm('Do you want to add a new customer?') == true) {

                  var CustNme = '';

                  //if (obj == "ddlExistingCntrctr") {

                  //    CustNme = ''
                  //}
                  var nWindow = window.open('/Master/gen_Customer_Master/gen_Customer_Master.aspx?CFAM=' + CustNme + '&CFTYP=CUSTR', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                  nWindow.focus();
              }

              return false;
          }
          function PostbackFun(myVal) {
              document.getElementById("<%=hiddenNewCustId.ClientID%>").value = myVal;
              __doPostBack("<%=btnNewCust.UniqueID %>", "");
              return false;
          }

          function GetValueFromChild(myVal) {

              if (myVal != '') {

                  //  alert(myVal);
                  PostbackFun(myVal);
                  //     alert(myVal);
              }
          }

          function UpdatePanelCustomerLoad(strCustId) {

              document.getElementById("<%=hiddenNewCustId.ClientID%>").value = "";
                CheckSubmitZero();


                $au('#cphMain_ddlCustomer').selectToAutocomplete1Letter();

                document.getElementById("<%=ddlCustomer.ClientID%>").style.borderColor = "";
               $au("div#divCustomer input.ui-autocomplete-input").css("borderColor", "");

               document.getElementById("<%=ddlCustomer.ClientID%>").value = strCustId;
                var a = $au("#cphMain_ddlCustomer option:selected").text();

                $au("div#divCustomer input.ui-autocomplete-input").val(a);

                //document.getElementById("<%=ddlCustomer.ClientID%>").focus();
                $noCon("div#divCustomer input.ui-autocomplete-input").focus();
                $au("#cphMain_ddlCustomer").select();
            }
            function NewProjectLoad(obj) {
                var $noC = jQuery.noConflict();
                if (confirm('Are you Sure.You Want To Add New Project?.') == true) {

                    var PrjctNme = '';

                    //Customer = $noC("#cphMain_ddlExistingCustomer option:selected").text();
                    //if (Customer == "--SELECT CUSTOMER/COMPANY--") {

                    //    Customer = "";
                    //    //alert("Please Select A Customer/Company To Continue");
                    //    //return false;
                    //}
                    //else {
                    //    Customer = $noC("#cphMain_ddlExistingCustomer option:selected").val();

                    //}





                    var nWindow = window.open('/Master/gen_Projects/gen_Projects.aspx?PRFG=' + PrjctNme + '&RFGP=RFG', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                    nWindow.focus();
                }
                return false;
            }

            function UpdatePanelProjectLoad(strPrjctId) {
                //since both are in update panel


            
                CheckSubmitZero();


                document.getElementById("<%=hiddenNewCustId.ClientID%>").value = "";
         CheckSubmitZero();


         $au('#cphMain_ddlProject').selectToAutocomplete1Letter();

         document.getElementById("<%=ddlCustomer.ClientID%>").style.borderColor = "";
              $au("div#divProject input.ui-autocomplete-input").css("borderColor", "");

              document.getElementById("<%=ddlProject.ClientID%>").value = strPrjctId;
              var a = $au("#cphMain_ddlProject option:selected").text();

              $au("div#divProject input.ui-autocomplete-input").val(a);

              // document.getElementById("<%=ddlProject.ClientID%>").focus();
              $noCon("div#divProject input.ui-autocomplete-input").focus();
              $au("#cphMain_ddlProject").select();
              ddlProjectChange();

          }
          function GetValueFromChildProject(myVal) {

              if (myVal != '') {

                  //  alert(myVal);
                  PostbackFunProject(myVal);
                  //     alert(myVal);
              }
          }
          function PostbackFunProject(myValPrj) {
              document.getElementById("<%=hiddenNewProjectId.ClientID%>").value = myValPrj;
              __doPostBack("<%=btnNewProject.UniqueID %>", "");
              return false;
          }

          function NewCategoryLoad() {
              var $noC = jQuery.noConflict();
              if (confirm('Are you Sure.You Want To Add New Category?.') == true) {

                  var Prjct = '';
                  var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                  var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
                  //Customer = $noC("#cphMain_ddlExistingCustomer option:selected").text();
                  //if (Customer == "--SELECT CUSTOMER/COMPANY--") {

                  //    Customer = "";
                  //    //alert("Please Select A Customer/Company To Continue");
                  //    //return false;
                  //}
                  //else {
                  //    Customer = $noC("#cphMain_ddlExistingCustomer option:selected").val();

                  //}
                  var prjctId;
                  prjctId = $noC("#cphMain_ddlProject option:selected").val();
                  if (prjctId != "--SELECT PROJECT--") {
                      var Details = PageMethods.CheckProjctAwdOrBiddg(prjctId, CorpId, OrgId, function (response) {
                          if (response == 1) {
                              Prjct = 'BIDDING';
                          }
                          else {

                              Prjct = 'AWARDED';
                          }

                          var nWindow = window.open('/GMS/GMS_Master/gen_Guarantee_Type_Master/gen_Guarantee_Type_Master.aspx?PRFG=' + Prjct + '&RFGP=RFG', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                          nWindow.focus();
                      });

                  }

                  var nWindow = window.open('/GMS/GMS_Master/gen_Guarantee_Type_Master/gen_Guarantee_Type_Master.aspx?PRFG=' + Prjct + '&RFGP=RFG', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                  nWindow.focus();
              }
              return false;
          }
          function UpdatePanelCategoryLoad(strCatId) {

              document.getElementById("<%=hiddenNewCustId.ClientID%>").value = "";
              CheckSubmitZero();


             // $au('#cphMain_ddlGuaranteCat').selectToAutocomplete1Letter();

              document.getElementById("<%=ddlGuaranteCat.ClientID%>").style.borderColor = "";
             // $au("div#divGuaranteCat input.ui-autocomplete-input").css("borderColor", "");

              document.getElementById("<%=ddlGuaranteCat.ClientID%>").value = strCatId;
              document.getElementById("<%=ddlGuaranteCat.ClientID%>").focus();

             // var a = $au("#cphMain_ddlGuaranteCat option:selected").text();

             // $au("div#divGuaranteCat input.ui-autocomplete-input").val(a);

              //document.getElementById("<%=ddlGuaranteCat.ClientID%>").focus();
              //$noCon("div#divGuaranteCat input.ui-autocomplete-input").focus();

              //$au("#cphMain_ddlGuaranteCat").select();
          }
          function GetValueFromChildCategory(myVal) {

              if (myVal != '') {

                  //  alert(myVal);
                  PostbackFunCategory(myVal);
                  //     alert(myVal);
              }
          }
          function PostbackFunCategory(myValPrj) {
              document.getElementById("<%=HiddenCategryId.ClientID%>").value = myValPrj;
              __doPostBack("<%=btnNewCategory.UniqueID %>", "");
              return false;
          }
          function ReissueAlert() {

              //if (Validate() == true) {

              if (confirm("Are You Sure You Want To Reissue?")) {
                  OpenCancelViewReissue();

              }
              else {

                  CheckSubmitZero();
                  return false;
              }
              CheckSubmitZero();
              return false;

          }
        

          function OpenHistory() {



              var RfqId = document.getElementById("<%=HiddenRFQid.ClientID%>").value;

              var varOrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
              var varCorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
              var varUserId = document.getElementById("<%=HiddenUserId.ClientID%>").value;

              var Details = PageMethods.HistoryList(RfqId, varOrgId, varCorpId, varUserId, function (response) {

                  if (response.strhtml != "") {

                      if (response.strhtml != "1") {
                          document.getElementById('cphMain_divPrintCaption').innerHTML = response.strPrintCap;
                          document.getElementById('cphMain_divPrintReport').innerHTML = response.strPrintReport;
                          document.getElementById('divReport').innerHTML = response.strhtml;

                          OpenCancelViewHisList();
                      }
                      else {
                          document.getElementById('cphMain_BttnHis').disabled = true;
                      }
                  }
                  else {
                      document.getElementById('cphMain_BttnHis').disabled = true;
                      // BttnHis
                  }
                  //   document.getElementById('cphMain_divList').innerHTML

              });

              return false;

          }

          function disablingCancel() {
              document.getElementById("ClearImage").disabled = true;

          }

          function ddlProjectChange() {

              var ddlTestDropDownListXML = $noCon('#cphMain_ddlGuaranteCat');
              var IntOrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
              var IntCorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
             var varUserId = document.getElementById("<%=HiddenUserId.ClientID%>").value;
              var ProjectId = document.getElementById("<%=ddlProject.ClientID%>").value;

              var tableName = "dtCategory";

              ddlTestDropDownListXML.empty();
              $noCon.ajax({
                  type: "POST",
                  url: "gen_Request_For_Guarantee.aspx/ProjectChange",
                  data: '{ProjectId:"' + ProjectId + '",OrgId:"' + IntOrgId + '",corpId:"' + IntCorpId + '"}',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (response) {
                      var OptionStart = $noCon("<option>--SELECT CATEGORY--</option>");
                      OptionStart.attr("value", 0);
                      ddlTestDropDownListXML.append(OptionStart);

                      // Now find the Table from response and loop through each item (row).
                      $noCon(response.d[0]).find(tableName).each(function () {
                          // Get the OptionValue and OptionText Column values.
                          var OptionValue = $noCon(this).find('GUANTCAT_ID').text();
                          var OptionText = $noCon(this).find('GUANTCAT_NAME').text();
                          // Create an Option for DropDownList.
                          var option = $noCon("<option>" + OptionText + "</option>");
                          option.attr("value", OptionValue);

                          ddlTestDropDownListXML.append(option);
                      });
                      document.getElementById("<%=ddlCustomer.ClientID%>").value = response.d[1];
                      var a = $au("#cphMain_ddlCustomer option:selected").text();

                      $au("div#divCustomer input.ui-autocomplete-input").val(a);
                      if (response.d[2] != "") {
                          document.getElementById("<%=ddlExistingEmp.ClientID%>").value = response.d[2];
                          var B = $au("#cphMain_ddlExistingEmp option:selected").text();

                          $au("div#divExistingEmp input.ui-autocomplete-input").val(B);
                          document.getElementById("<%=txtCntctMail.ClientID%>").value = response.d[3];
                      }

                  }

              });

             // $au('#cphMain_ddlGuaranteCat').selectToAutocomplete1Letter();
         }

         function ddlExistEmployeeChange() {
             var varOrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
             var varCorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
             var EmployId = document.getElementById("<%=ddlExistingEmp.ClientID%>").value;
             var Details = PageMethods.EmployeeChange(EmployId, varOrgId, varCorpId, function (response) {

                 document.getElementById("<%=txtCntctMail.ClientID%>").value = response;

             });
          }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true" >
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenViewId" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenNewCustId" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDup" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenCustomerFocus" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenRsnid" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenRoleReOpen" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenRoleConfirm" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenRoleAdd" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenRoleClose" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenCurrentDate" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" Value="0" />
       <asp:HiddenField ID="hiddenConfirmOrNot" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenCustmerId" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenContPersn" runat="server" Value="0" />

    <asp:HiddenField ID="hiddenPermitFileSize" runat="server" />
    <asp:HiddenField ID="hiddenRechargeFile" runat="server" />
     <asp:HiddenField ID="hiddenRechargeFileDeleted" runat="server" />
    <asp:HiddenField ID="hiddenRechargeFileAct" runat="server" />

     <asp:HiddenField ID="hiddenNewProjectId" runat="server" />
     <asp:HiddenField ID="HiddenOrgId" runat="server" />
     <asp:HiddenField ID="HiddenCorpId" runat="server" />
     <asp:HiddenField ID="HiddenCategryId" runat="server" />
    <asp:HiddenField ID="HiddenReissue" runat="server" />
    <asp:HiddenField ID="HiddenUserId" runat="server" />
     <asp:HiddenField ID="HiddenRFQid" runat="server" />
     <asp:HiddenField ID="HiddenReissuecHCK" runat="server" />
    <asp:HiddenField ID="hiddenGuantCat" runat="server" />
   
    <div class="cont_rght">
        
        <div id="divMessageArea" style="display: none; margin: 0px 0 13px;">
            <img id="imgMessageArea" src="">
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 22%; height: 26.5px;">


        </div>

        <div class="fillform" style="width: 100%">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>

            <div id="divGreySection">
               
                <div id="divImage" style="float: right;margin-right:3%;margin-top:-7%">
                       
                        <asp:ImageButton ID="imgbtnReOpen" runat="server" OnClientClick="return ConfirmReOpen();" Style="margin-left: 0%;" OnClick="imgbtnReOpen_Click" />
                         <p id="imgReOpen" class="imgDescription" style="color: white">ReOpen Confirmed Entry</p>
                    </div>

                <div class="eachform" style="width: 49%; float: left; margin-top: 3.8%;height: 122px;">
                      <h2 style="margin-left: 8%;margin-top:8%">Guarantee Type *</h2>

                    <div id="GuarTypeContainer" runat="server" style="float:right;width:45%;margin-right: 12%;">
                        <div style="width:30%;float:left;margin-left: 10%;">
                        <img src="/Images/Icons/Open_Guarantee.png" alt="X" style="margin-left: 5%; margin-top: 0%; width: 90%;float:left"/>
                            <div style="width:100%;float:left">
                          <input id="radioOpen" type="radio" runat="server" tabindex="1" name="radType" onchange="RadioOpenClick()" />
                                <label style="font-family:Calibri" for="cphMain_radioOpen">Open</label>
                            </div>

                        </div>
                        <div style="width:30%;float:left;margin-left: 10%;">
                          <img src="/Images/Icons/Closed_Guarantee.png" alt="X" style="margin-left: 5%; margin-top: 0%; width: 90%;"/>
                       <div style="width:100%;float:left">
                          <input id="radioLimited" type="radio" runat="server"  tabindex="2" name="radType" onchange="RadioLimitedClick()" />
                                <label style="font-family:Calibri" for="cphMain_radioLimited">Limited</label>
                            </div>
                            
                      </div>

                    </div>
                </div>
              
                
                 <div class="eachform" style="width: 49%; float: right; margin-top: 3%;">
                    <h2 style="margin-left: 8%">Ref*</h2>

                    <asp:Label ID="lblRefNumber" class="form1" runat="server" Style="padding-top:2px; margin-right: 15%; border: none;font-family:Calibri;font-size:16px;font-weight: bold;"></asp:Label>
                </div>


                 <div id="divProject" class="eachform" style="width: 49%; float: right; margin-top: 1%;">
                    <h2 style="margin-left: 8%">Project*</h2>
                    <asp:DropDownList ID="ddlProject" TabIndex="3" class="form1" Style="float: left; width: 43% !important; margin-left: 25%;" runat="server" OnChange="ddlProjectChange()">
                    </asp:DropDownList>
                      <asp:Button ID="btnNewProject" runat="server" class="save" style="margin-left: 0%;  padding: 1%;border-radius: 0px;padding-bottom: 1.7%; padding-top:6px;" ToolTip="Add Project" Text="+" OnClientClick="return NewProjectLoad()" OnClick="btnNewProject_Click"/>
                </div>

              <div id="divGuaranteCat" class="eachform" style="width: 49%; float: right;margin-top: .5%;">
                    <h2 style="margin-left: 8%">Guarantee Category*</h2>
                    <asp:DropDownList ID="ddlGuaranteCat" TabIndex="4" class="form1" Style="float: left; width: 46% !important;height: 30px; margin-left: 9.1%;" runat="server" >
                    </asp:DropDownList>
                    <asp:Button ID="btnNewCategory" runat="server" class="save" style="margin-left: 0%;  padding: 1%;border-radius: 0px;padding-bottom: 1.7%; padding-top:6px;" ToolTip="Add Category" Text="+" OnClientClick="return NewCategoryLoad()" OnClick="btnNewCategory_Click"/>
                </div>
                     <div style="float: left;width: 100%;">
                 <div id="divCustomer" class="eachform" style="width: 49%; float: left;margin-top:1%">
                    <h2 style="margin-left: 8%">Client/Customer*</h2>
                    <asp:DropDownList ID="ddlCustomer" TabIndex="5" class="form1" Style="float: left; width: 43% !important; margin-left: 14%;" runat="server" EnableViewState="true" Visible="true" autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>

                       <asp:Button ID="btnNewCust" runat="server" class="save" ToolTip="Add Customer" Style="margin-left: 0.1%; padding: 1%; border-radius: 0px; padding-bottom: 2%;" Text="+" OnClientClick="return NewCustPageLoad()" OnClick="btnNewCust_Click" />
                </div>

                <div class="eachform" style="width: 49%; float: right;margin-top:.5%">
                  <h2 style="margin-left: 8%">In Favour Of </h2>
                    <asp:TextBox ID="txtInFavrOf" TabIndex="6" class="form1" runat="server" MaxLength="80" Style="width: 47%; text-transform: uppercase; margin-right: 7%; height: 30px"></asp:TextBox>
                </div>
   </div>
<div style="float: left;width: 100%;">
                <div class="eachform" style="width: 49%; float: left;margin-top:0%">
                 <h2 style="margin-left: 8%;float:left;margin-top: 2%;width:28%">Validity Of Guarantee*</h2>
                     
                  <asp:TextBox ID="txtValidity" TabIndex="7" class="form1" runat="server" MaxLength="4" onblur="NumberChecking('cphMain_txtValidity');" onkeydown="return isNumber(event,'cphMain_txtValidity');" Style="width: 26%;text-align:right; text-transform: uppercase; margin-left: 7%; height: 29px;float:left;margin-top: 1%;"></asp:TextBox>
                    <h2 style="margin-left: 1.5%;float:left;">Days</h2>
                     </div>
    

                 <div id="divProjectClosingDate" class="eachform" runat="server" style="width: 49%;float:right">
                 <h2 id="Project_Closing_Date" style="font-size:17px;margin-left:8%;width:  32%;" runat="server">Project/RFQ Closing Date*</h2>
               <div id="ClosingDate" class="input-append date" style="font-family:Calibri;float:right;width:50%;margin-right:7%;margin-top: 1%;">
                 <asp:TextBox ID="txtPrjctClsngDate" TabIndex="8" class="textDate form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width:83.8%;height:27px; font-family: calibri;float: left;" ></asp:TextBox>
                   <img id= "img2" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter();" style=" height:19px;float:left; width:12px;cursor:pointer;" />
                      
                       
                   <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
                   <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                   <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                   <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                        <script type="text/javascript">
                            var $noC2 = jQuery.noConflict();
                            $noC2('#ClosingDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),


                            });

                            function FocusOnDate() {

                                $noC2('#ClosingDate').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    startDate: new Date(),


                                });
                            }
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>
                        </div>
                        <div style="float: left;width: 100%;">
                 <div class="eachform" style="width: 49%; float: left;margin-top:0%">
                  <h2 style="margin-left: 8%">Amount * </h2>
                    <asp:TextBox ID="txtAmount" TabIndex="9" class="form1" runat="server" MaxLength="12" Style="width: 47%; text-transform: uppercase;text-align:right; margin-right: 7%; height: 30px" onkeydown="return isNumber(event,'cphMain_txtAmount');" onkeyup="addCommas()"  onblur="AmountChecking('cphMain_txtAmount');"></asp:TextBox>
                </div>
                 <div id="divCurrency" class="eachform" style="width: 49%; float: right; margin-top:0%;">
                    <h2 style="margin-left: 8%">Currency *</h2>
                    <asp:DropDownList ID="ddlCurrency" TabIndex="10" class="form1" Style="float: right; width: 47%!important; margin-right: 7%;" runat="server"  autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>
                </div>
                        </div>


                <div style="float: left;width: 100%;">
                 <div class="eachform" style="width: 49%; float: left;margin-top:0.5%">
                  <h2 style="margin-left: 8%">Remarks </h2>
                    <asp:TextBox ID="txtRemarks" TabIndex="11" class="form1" runat="server" TextMode="MultiLine" MaxLength="950" onkeydown="textCounter(cphMain_txtRemarks,950)" onkeyup="textCounter(cphMain_txtRemarks,950)" Style="resize:none; width: 47%;height:100px; text-transform: uppercase;font-family:Calibri; margin-right: 7%;"></asp:TextBox>
                </div>

                        <div class="eachform" style="width: 28.4%; float: right !important; margin-right: 0%;">
                            <span>
                              <asp:CheckBox ID="cbxExistingEmployee" TabIndex="14" runat="server" onchange="CbxChange()" />
                                <label style="color: rgb(135, 146, 116); font-family: Calibri;" for="cphMain_cbxExistingCustomer">Select Employee From List</label>
                            </span>
                        </div>
                        <div class="eachform" style="width: 49%; float: right">

                            <h2 id="h2_person" style="margin-left: 8%" runat="server">Contact Person </h2>
                            <div style="width: 57.5%; float: right;">
                                <div id="divNewEmp">
                                    <asp:TextBox ID="txtEmpName" TabIndex="15" class="form1" runat="server" MaxLength="100" onblur="RemoveTag(this)" Style="float: left; width: 81%!important; margin-left: 1%; text-transform: uppercase;"></asp:TextBox>
                                  
                                 </div>

                                <div id="divExistingEmp">
                                    <asp:DropDownList ID="ddlExistingEmp" TabIndex="16" class="form1" Style="float: left; width: 81%!important; margin-left: 1%;" OnChange="ddlExistEmployeeChange()" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                                    </asp:DropDownList>
                               </div>
                            </div>

                        </div>
                         <div class="eachform" style="width: 49%; float: right;margin-top:.5%">
                  <h2 id="h2_email" style="margin-left: 8%" runat="server">Contact Person Email </h2>

                    <asp:TextBox ID="txtCntctMail" TabIndex="17" class="form1" runat="server" MaxLength="100" Style="width:47%; margin-right: 7%; height: 30px"></asp:TextBox>
                </div>

                  <div id="divJobCategory" class="eachform" style="width: 49%; float: left;margin-top:0.5%">
                    <h2 style="margin-left: 8%">Job Category</h2>
                    <asp:DropDownList ID="ddlJobCategory" TabIndex="12" class="form1" Style="float: right; width: 47%!important; margin-right: 7%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>
                </div>

               <div class="eachform" style="width: 49%; float: right;margin-top:0%">
                    <h2 style="margin-left: 8%">Status*</h2>
                    <div class="subform" style="width: 30%; margin-right: 27.5%; padding-top: 7px;">
                        <asp:CheckBox ID="cbxStatus" TabIndex="18" Text="" runat="server" Checked="true" class="form2" />

                        <h3>Active</h3>

                    </div>
                </div>
                </div>

                <div  class="eachform" style="width: 97%;margin-top:1%;">
              
                <h2 style="margin-top: 1%;margin-left:47px;">Attach RFG</h2>
                <label for="cphMain_FileUploadRecharge" class="custom-file-upload" tabIndex="13" style="margin-left:118px;">
                    <img src="/Images/Icons/cloud_upload.jpg" />Upload File</label>

                    <asp:FileUpload ID="FileUploadRecharge" class="fileUpload" runat="server"  Style="height: 30px; display: none;" onchange="ClearDivDisplayImage()" Accept="All" />
                     <asp:Label ID="Label3" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
                     </div>
                <div id="divImageEdit" runat="server" style="float: right; width: 54%; height: 20px; margin-top: -1%;">
                    <div class="imgWrap">
                        <img id="ClearImage"  src="/Images/Icons/clear-image-green.png" alt="Clear" onclick="ClearImages()" onmouseover="ImagePosition('ClearImages')"; style="cursor: pointer; float:left;" />
                        <p id="RemovePhoto" class="imgDescription" style="color: white;position: absolute; left: 48.1%; top: 711.85px;">Remove selected attachment</p>
                    </div>
                    <div id="divImageDisplay" runat="server">
                    </div>
                </div>

                <div class="eachform" style="width: 99%; margin-top: 3%; float: left">
                    <div class="subform" style="width: 70%; margin-left: 38%">
                         
                     <asp:Button ID="btnConfirm" TabIndex="19" runat="server" class="save" Text="Confirm" OnClick="btnConfirm_Click" OnClientClick="return ConfirmAlert();"/>
                     <asp:Button ID="btnUpdate" TabIndex="20" runat="server" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClose" TabIndex="21" runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click"  />
                    <asp:Button ID="btnAdd" TabIndex="22" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnAddClose" TabIndex="23" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="BttnReissue" TabIndex="24" runat="server" class="save" Text="Reissue"  OnClientClick="return ReissueAlert();"/>
                    <asp:Button ID="Butproceed" TabIndex="25" runat="server" class="save" Text="Proceed"  OnClientClick="return Validate();"  OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnCancel" TabIndex="26" runat="server" class="cancel" Text="Cancel" PostBackUrl="gen_Request_For_Guarantee_List.aspx"  />
                     <asp:Button ID="btnClear" TabIndex="27" runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAll();"  class="cancel" Text="Clear"/>
               </div>



                      <div id="div1" style="float: right;margin-right:3%;margin-top:-7%">
                       
                        <asp:ImageButton ID="imgBtnClose" class="tooltip" title="Close" TabIndex="29" runat="server" OnClientClick="return ConfirmClose();" Style="margin-left: 0%;opacity:1;position:relative;z-index: 29" OnClick="imgBtnClose_Click" />
                         
                    </div>






                </div>

                  <div id="DivHistory" runat="server" class="eachform" style="float:left;width:44%;border: 2px solid rgb(195, 221, 182);margin-left: 1.3%;margin-top: 3%;background-color: #c2cfcf;">
                          <div id="div4"  style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
         <h3 style="padding-left: 1%;font-size: 23px;margin-top: 1%;width: 79%;"> History </h3>  
                               <asp:Button ID="BttnHis" TabIndex="28"  Style="float: right;width: 28%;margin-top: -4%;background-color: #76b05d;" runat="server" class="save" Text="Full History" OnClientClick="return OpenHistory();"   /> 
                              <div style="padding:2%">
                               <h2 style="">Last Modified Date </h2>   <h2 id="LMDate" runat="server" style="margin-left: 9.6%;"> </h2> <br /><br />
                               <h2 style="margin-top:-1%;">Last Modified User </h2>   <h2 id="LMUser" runat="server" style="margin-left: 10%;margin-top:-1%;"></h2> <br /><br />
                               <h2 style="margin-top:-3%;">Last Modified Status </h2>     <h2 id="LMStatus" runat="server" style="margin-left: 8%;margin-top:-3%;"></h2>
                                  </div>
        </div >
                  </div>

                    <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
                   <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
    </div>
        <div id="divtile" runat="server" style="display: none"></div>

                <br style="clear: both" />
            </div>




        </div>
    </div>


                                     <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Request For Guarantee</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                            <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Close Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTagOnly(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();" runat="server" Text="Close" />
                       
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

  <%--  for history List--%>

               <div id="DivmodalCancelView" class="modalCancelView" style=" display: none;  position: fixed; z-index: 30;padding-top: 0%; left: 2%; top: 20%;  width: 96%;  background-color: transparent;">
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelViewHisList();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Request For Guarantee</h3>
                    </div>
                    <div class="modal-bodyCancelView" style="overflow: auto;height: 210px;">
                                 <div style="cursor: default; float: right; height: 25px; margin-right:7.5%;margin-top:4.5%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="print_cap" target="_blank" data-title="Item Listing"  href="/Reports/Print/28_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                 Print</a>                                    
                                </div>
                           <asp:Label id="Labl_HistoryList" runat="server" style="display:inline-block;width:51%;font-weight: bold;color: rgb(83, 101, 51);font-family: Calibri; font-size: 18px; margin-left: 0%; padding-bottom: 0.7%; padding-top: 0.6%;float: left;" text_align="center" Width="100%"></asp:Label>
                               

                        <label  class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; "></label>
                        
                          <div id="divReport"  class="table-responsive"  style="margin-top: 1%;">
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
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;padding: 1.5% 1%;">
                    </div>


                </div>
            </div>   
  <%--  for reissue--%>
      <div id="ReisssuemodalCancelView" class="modalCancelView"  >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="ReissueCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Request For Guarantee</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="DivreissueErrormsg" class="error" style="visibility:hidden;  text-align: center; ">
                            <asp:Label ID="Lblreissueerrormsg" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 25%;color: #909c7b; ">Reissue Reason*</label>
                        <asp:TextBox ID="txtreissue" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtreissue)" onkeypress="return isTagOnly(event)" onkeydown="textCounter(cphMain_txtreissue,450)" onkeyup="textCounter(cphMain_txtreissue,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="Btnreissue" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReasonReissue();"  style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="Btnreisueclose" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="ReissueCancelView();" runat="server" Text="Close" />
                       
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>

    <style>
        .open > .dropdown-menu {
            display: none;
        }
    </style>
</asp:Content>


