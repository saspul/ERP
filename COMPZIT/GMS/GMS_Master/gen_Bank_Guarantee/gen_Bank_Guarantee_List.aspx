<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" CodeFile="gen_Bank_Guarantee_List.aspx.cs" Inherits="GMS_GMS_Master_gen_Bank_Guarantee_gen_Bank_Guarantee_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

  <style>
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
          input[type="radio"] {
    display: inline-block;
}
      .open > .dropdown-menu {
    display: none;
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

         /*<!-- EVM-0031 -->*/
         select[disabled], textarea[disabled], input[readonly], select[readonly], textarea[readonly] {
             cursor: not-allowed;
             background-color: #eee;
         }

         
     </style>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {

              //EVM-0027 Aug1
              // divInsurProvider  divGuaranteeSectn

              if (document.getElementById("<%=ddlPolicyType.ClientID%>").value == "0") {

                  document.getElementById('divInsurProvider').style.display = "";
                  document.getElementById('divGuaranteeSectn').style.display = "";
                  document.getElementById('divddlBankName').style.display = "none";
                  $('#divGuaranteeSectn :input').removeAttr('disabled');
                  $("#divGuaranteeSectn").find("input,button,textarea,select").attr("disabled", "disabled");
                  $("#divInsurProvider").find("input,button,textarea,select").attr("disabled", "disabled");
              }
              //END
             
              // divddlBankName  divddlInsurncPrvdr


              if (document.getElementById("<%=ddlPolicyType.ClientID%>").value == "1") {
                  document.getElementById('idBankTypeOrCateg').innerHTML = 'Type';
                  document.getElementById('divGuaranteeSectn').style.display = "block";
                  document.getElementById('divInsurProvider').style.display = "block";
                  document.getElementById('divddlBankName').style.display = "block";
                  document.getElementById('divddlInsurncPrvdr').style.display = "none";
                  // $("#divInsurProvider").find("input,button,textarea,select").attr("disabled", "disabled");
              }
              if (document.getElementById("<%=ddlPolicyType.ClientID%>").value == "2") {         
                  document.getElementById('idBankTypeOrCateg').innerHTML = 'Category';
                  document.getElementById('divGuaranteeSectn').style.display = "block";
                  document.getElementById('divInsurProvider').style.display = "block";
                  document.getElementById('divddlBankName').style.display = "none";
                  document.getElementById('divddlInsurncPrvdr').style.display = "block";
                  $("#divGuaranteeSectn").find("input,button,textarea,select").attr("disabled", "disabled");
              }

              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              document.getElementById('MymodalCancelView_INSRNC').style.display = "none";
              var ClosePrimaryId = document.getElementById("<%=hiddenRsnidclose.ClientID%>").value;
              if (ClosePrimaryId != "") {
                  OpenCloseView();
                 
              }

              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();                
              }


              var ClosePrimary_INSRNCId = document.getElementById("<%=hiddenRsn_INSRNCidclose.ClientID%>").value;
              if (ClosePrimary_INSRNCId != "") {
                  OpenCloseView_INSRNC();

              }

              var CancelPrimary_INSRNCId = document.getElementById("<%=hiddenRsn_INSRNCid.ClientID%>").value;
             
              if (CancelPrimary_INSRNCId != "") {
                  OpenCancelView_INSRNC();
              }




             // if (document.getElementById("<%=radioCus.ClientID%>").checked == true) {
                
                  //document.getElementById("divSuplier").style.display = "none";
                //  document.getElementById("divcustomer").style.display = "";
         // }
          //else if (document.getElementById("<%=radioSup.ClientID%>").checked == true) {
           //   document.getElementById("divSuplier").style.display = "";
           //   document.getElementById("divcustomer").style.display = "none";
              //}


              document.getElementById("<%=ddlPolicyType.ClientID%>").focus();

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

                   $au('#cphMain_ddlGuaranteeMde').selectToAutocomplete1Letter();
                   $au('#cphMain_ddlSup').selectToAutocomplete1Letter();
                   $au('#cphMain_ddlBankNm').selectToAutocomplete1Letter();
                   $au('#cphMain_ddlSuplCus').selectToAutocomplete1Letter();
                   $au('form').submit(function () {




                       //   return false;
                   });
               });
           })(jQuery);





                    </script>
      <script type="text/javascript">


          function RemoveTag(obj) {

              var txt = document.getElementById(obj).value.trim();
              var replaceText1 = txt.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById(obj).value = replaceText2;
          }

          var $Mo = jQuery.noConflict();


          function OpenCloseView() {

              document.getElementById("MymodalCloseView").style.display = "block";
              document.getElementById("freezelayer").style.display = "";
              document.getElementById("<%=TxtCloseReson.ClientID%>").focus();

              return false;

          }
          function CloseCloseView() {
              if (confirm("Do you want to close without completing closing process?")) {
                  document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById('imgMessageArea').src = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("MymodalCloseView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsnidclose.ClientID%>").value = "";
              }
          }

          function OpenCancelView() {



              document.getElementById("MymodalCancelView").style.display = "block";
              document.getElementById("freezelayer").style.display = "";
              document.getElementById("<%=txtCnclReason.ClientID%>").focus();

              return false;

          }
          function CloseCancelView() {
              if (confirm("Do you want to close without completing cancellation process?")) {
                  document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById('imgMessageArea').src = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("MymodalCancelView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
              }
          }

          function ReCallAlert(href) {

              if (confirm("Do you want to recall this entry?")) {
                  window.location = href;
                  return false;
              }
              else {
                  return false;
              }
          }
          function PrintAlert(href) {

              if (confirm("Do you want to take a print?")) {
                  window.location = href;
                  return false;
              }
              else {
                  return false;
              }
          }








          function OpenCloseView_INSRNC() {
              document.getElementById("MymodalCloseView_INSRNC").style.display = "block";
              document.getElementById("freezelayer").style.display = "";
              document.getElementById("<%=TxtCloseReson_INSRNC.ClientID%>").focus();
               return false;
           }

          function CloseCloseView_INSRNC() {
               if (confirm("Do you want to close without completing closing process?")) {
                   document.getElementById('divMessageArea').style.display = "none";
                   document.getElementById('imgMessageArea').src = "";
                   document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                   document.getElementById("MymodalCloseView_INSRNC").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsn_INSRNCidclose.ClientID%>").value = "";
              }
          }

          function OpenCancelView_INSRNC() {
              document.getElementById("MymodalCancelView_INSRNC").style.display = "block";
              document.getElementById("freezelayer").style.display = "";
              document.getElementById("<%=txtCnclReason_INSRNC.ClientID%>").focus();

              return false;

          }
          function CloseCancelView_INSRNC() {
              if (confirm("Do you want to close without completing cancellation process?")) {
                  document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById('imgMessageArea').src = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("MymodalCancelView_INSRNC").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsn_INSRNCid.ClientID%>").value = "";
              }
          }

          function ReCallAlert_INSRNC(href) {
              if (confirm("Do you want to recall this insurance?")) {
                  window.location = href;
                  return false;
              }
              else {
                  return false;
              }
          }
    </script>
    <script type="text/javascript">
        function DuplicationRFQ() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!.Request for guarantee can’t be duplicated.";
        

        }
        function Duplication() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!. Guarantee number can’t be duplicated.";


        }
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee details inserted successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee details updated successfully.";
        }
        function SuccessCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee cancelled successfully.";
        }
        function SuccessRecall() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee recalled successfully.";
        }
        function SuccessStatusChange() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee status changed successfully.";
        }
        function SuccessReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee details reopened successfully.";
        }
        function SuccessConfirm() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee details confirmed successfully.";
         }
         function SuccessClose() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee details closed successfully.";
         }



        ////////////////////////////////


        function DuplicationRFQ_insr() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!. Request for insurance can’t be duplicated.";


        }
        function Duplication_insr() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!. Insurance number can’t be duplicated.";


        }
        function SuccessConfirmation_insr() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details inserted successfully.";
        }
        function SuccessUpdation_insr() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details updated successfully.";
        }
        function SuccessCancelation_insr() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance cancelled successfully.";
        }
        function SuccessRecall_insr() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance recalled successfully.";
        }
        function SuccessStatusChange_insr() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance status changed successfully.";
        }
        function SuccessReOpen_insr() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details reopened successfully.";
        }
        function SuccessConfirm_insr() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details confirmed successfully.";
        }
        function SuccessClose_insr() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details closed successfully.";
         }

        function getdetails(href) {
            window.location = href;
            return false;
        }

        function ConfirmClose() {


            if (confirm("Are you sure you want to close?")) {
                window.location = href;
                return true;
            }
            else {

               // CheckSubmitZero();
                return false;
            }

        }
        function closeWindow() {
            window.close();
        }
        function CancelAlert(href) {

            if (confirm("Do you want to cancel this bank guarantee?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }

        function CancelAlert_INSRNC(href) {

            if (confirm("Do you want to cancel this insurance?")) {
                //   OpenCancelView_INSRNC();
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }

        function CancelNotPossible() {
            alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            return false;

        }
        // for not allowing <> tags
        function isTag(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }

        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }

        function getdetails(href) {
            window.location = href;
            return false;
        }
        function ConfirmGtee(href,expStatus) {
            if (expStatus == "1") {
                if (confirm("Bank guarantee has been expired already. Are you sure you want to continue?")) {
                    // ret = true;
                    window.location = href;
                    return false;
                }
                else {

                    // CheckSubmitZero();
                    return false;
                }
            }
            else {
                if (confirm("Are you sure you want to confirm?")) {
                    window.location = href;
                    return false;
                }
                else {
                    return false;
                }

            }
        }
        function StatusCheck() {

            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirm denied.Entry is already confirmed.";
           
         }
        </script>

   <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });
        });


    //    $p(document).ready(function () {
    //        $p('#ReportTable').dataTable({
    //            "aoColumns": [
    //                null,
    //                null,
    //                null,
    //                null,
    //                null,
    //                null,
    //                    null,
    //null,
    //null,
    //null,
    //null,
    //null,
    //null,


    //            ]
    //        });

    //    });


    </script>
      <style>

        #cphMain_btnNext.aspNetDisabled {
            width: 202px;
            height: 33px;
            margin-top: -5px;
            font-size: 13px;
            cursor: default;
        }
        #cphMain_btnPrevious.aspNetDisabled {
            width: 202px;
            height: 33px;
            margin-top: -5px;
            font-size: 13px;
            cursor: default;
        }
        .searchlist_btn_rght {
            cursor: pointer;
        }
           input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
        }
        #a_Caption:hover {
        color: rgb(83, 101, 51);
        
        }
        #a_Caption {
        color: rgb(88, 134, 7);
        
        }
        #a_Caption:focus {
        color: rgb(83, 101, 51);
        
        }
         .searchlist_btn_lft:hover {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
        .searchlist_btn_lft:focus {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
        input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;
        }
         .searchlist_btn_rght:hover {
                background: #7B866A;
            }
             .searchlist_btn_rght:focus {
                background: #7B866A;
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
               // $au('#cphMain_ddlCustomer').selectToAutocomplete1Letter();


            });
        })(jQuery);





    </script>


    <style>
        #cphMain_divReport {
            float: left;
            width: 97.5%;
        }

      

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
        }
    </style>

    <script>

        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
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
        }

        function ValidateCancelReason_INSRNC() {
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtCnclReason_INSRNC.ClientID%>").value;
               var replaceText1 = NameWithoutReplace.replace(/</g, "");
               var replaceText2 = replaceText1.replace(/>/g, "");
               document.getElementById("<%=txtCnclReason_INSRNC.ClientID%>").value = replaceText2;

            var divErrorMsg = document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
            var txthighlit = document.getElementById("<%=txtCnclReason_INSRNC.ClientID%>").style.borderColor = "";
            var Reason = document.getElementById("<%=txtCnclReason_INSRNC.ClientID%>").value.trim();
               if (Reason == "") {
                   document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                   document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                document.getElementById("<%=txtCnclReason_INSRNC.ClientID%>").style.borderColor = "Red";
                return false;
            }
            else {
                Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                Reason = Reason.replace(/[ ]{2,}/gi, " ");
                Reason = Reason.replace(/\n /, "\n");
                if (Reason.length < "10") {
                    document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                    document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=txtCnclReason_INSRNC.ClientID%>").style.borderColor = "Red";
                    return false;
                }
            }
        }

        function ValidateCloseReason() {
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=TxtCloseReson.ClientID%>").value;
                var replaceText1 = NameWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById("<%=TxtCloseReson.ClientID%>").value = replaceText2;

            var divErrorMsg = document.getElementById('divErrorCloseRsnAWMS').style.visibility = "hidden";
            var txthighlit = document.getElementById("<%=TxtCloseReson.ClientID%>").style.borderColor = "";
            var Reason = document.getElementById("<%=TxtCloseReson.ClientID%>").value.trim();
                if (Reason == "") {
                    document.getElementById('divErrorCloseRsnAWMS').style.visibility = "visible";
                    document.getElementById("<%=lblErrorCloseRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                document.getElementById("<%=TxtCloseReson.ClientID%>").style.borderColor = "Red";
                return false;
            }
            else {
                Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                Reason = Reason.replace(/[ ]{2,}/gi, " ");
                Reason = Reason.replace(/\n /, "\n");
                if (Reason.length < "10") {
                    document.getElementById('divErrorCloseRsnAWMS').style.visibility = "visible";
                    document.getElementById("<%=lblErrorCloseRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=TxtCloseReson.ClientID%>").style.borderColor = "Red";
                    return false;
                }
            }
        }

        function ValidateCloseReason_INSRNC() {
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=TxtCloseReson_INSRNC.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=TxtCloseReson_INSRNC.ClientID%>").value = replaceText2;

                var divErrorMsg = document.getElementById('divErrorCloseRsnAWMS').style.visibility = "hidden";
                var txthighlit = document.getElementById("<%=TxtCloseReson_INSRNC.ClientID%>").style.borderColor = "";
            var Reason = document.getElementById("<%=TxtCloseReson_INSRNC.ClientID%>").value.trim();
             if (Reason == "") {
                 document.getElementById('divErrorCloseRsnAWMS').style.visibility = "visible";
                 document.getElementById("<%=lblErrorCloseRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                    document.getElementById("<%=TxtCloseReson_INSRNC.ClientID%>").style.borderColor = "Red";
                    return false;
                }
                else {
                    Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                    Reason = Reason.replace(/[ ]{2,}/gi, " ");
                    Reason = Reason.replace(/\n /, "\n");
                    if (Reason.length < "10") {
                        document.getElementById('divErrorCloseRsnAWMS').style.visibility = "visible";
                        document.getElementById("<%=lblErrorCloseRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=TxtCloseReson_INSRNC.ClientID%>").style.borderColor = "Red";
                    return false;
                }
            }
        }

        function SearchValidation() {
            ret = true;
            var Biding;
            var Awarded;
            var ddlCustSuplr;
            
            
            //var ddlSuplr;
            var CrdExpWithoutReplace = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtFromDate.ClientID%>").value = replaceCode2;

            var CrdExpWithoutReplace = document.getElementById("<%=txtToDate.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtToDate.ClientID%>").value = replaceCode2;

            var CrdExpWithoutReplace = document.getElementById("<%=BankGurntExpire.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=BankGurntExpire.ClientID%>").value = replaceCode2;

            var FromDate= document.getElementById("<%=txtFromDate.ClientID%>").value;
            var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;
            var InsurProvider = document.getElementById("<%=ddlInsurncPrvdr.ClientID%>").value;
            var InsurPolicySts  = document.getElementById("<%=ddlPolicyType.ClientID%>").value;
             var GuaranteType = document.getElementById("<%=ddlGuaranteeTyp.ClientID%>").value;
            var GuaranteMode = document.getElementById("<%=ddlGuaranteeMde.ClientID%>").value;
            var BankId = document.getElementById("<%=ddlBankNm.ClientID%>").value; 
            var varGarntSts = document.getElementById("<%=ddlGuaranteeStatus.ClientID%>").value;
            if (document.getElementById("<%=radioBinding.ClientID%>").checked == true) {
                Biding = "1";
                Awarded = "0";
            }
            else if (document.getElementById("<%=radioAwdrd.ClientID%>").checked == true) {
                Biding = "0";
                Awarded = "1";
            }
            else
            {
                Biding = "0";
                Awarded = "0";
            }

            var ddlcussup = document.getElementById("<%=ddlCustSuplrsrch.ClientID%>").value;
            if (ddlcussup == 1)
            {
                ddlCustSuplr = document.getElementById("<%=ddlSup.ClientID%>").value;
                document.getElementById("<%=HiddenFieldRadioCusSupl.ClientID%>").value = "2";
            }
            else if (ddlcussup == 2)
            {
                ddlCustSuplr = document.getElementById("<%=ddlSuplCus.ClientID%>").value;
                document.getElementById("<%=HiddenFieldRadioCusSupl.ClientID%>").value = "1";
            }
             var cbxStatus = document.getElementById("<%=cbxCnclStatus.ClientID%>");
            var EspireDate = document.getElementById("<%=BankGurntExpire.ClientID%>").value;

            var Currency = document.getElementById("<%=ddlCurrency.ClientID%>").value;
            var PolicyNum = document.getElementById("<%=ddlPolicyNum.ClientID%>").value;
            var InsuranceType = document.getElementById("<%=ddlInsurncTyp.ClientID%>").value;
           
             var cbx = 0;
             if (cbxStatus.checked) {
                 cbx = 1;
             }
             else {
                 cbx = 0;
             }
             
             
             if (ret == true) {

                 document.getElementById("<%=HiddenSearchField.ClientID%>").value = FromDate + ',' + ToDate + ',' + GuaranteType + ',' + GuaranteMode + ',' + Biding + ',' + Awarded + ',' + ddlCustSuplr + ',' + EspireDate + ',' + cbx + ',' + BankId + ',' + varGarntSts + ',' + ddlcussup + ',' + InsurProvider + ',' + InsurPolicySts + ',' + Currency + ',' + PolicyNum + ',' + InsuranceType;;
             }


             return ret;

         }


         function ChangeStatus(CatId, CatStatus) {
             if (confirm("Do You Want To Change The Status Of This Entry?")) {
                 var SearchString = document.getElementById("<%=HiddenSearchField.ClientID%>").value;
                var Details = PageMethods.ChangeContractStatus(CatId, CatStatus, function (response) {
                    var SucessDetails = response;

                    if (SucessDetails == "success") {
                        if (SearchString == "") {
                            window.location = 'gen_Bank_Guarantee_List.aspx?InsUpd=StsCh';
                        }
                        else {
                            window.location = 'gen_Bank_Guarantee_List.aspx?InsUpd=StsCh&Srch=' + SearchString + '';
                        }


                    }
                    else {
                        window.location = 'gen_Bank_Guarantee_List.aspx?InsUpd=Error';
                    }
                });
            }
            else {
                return false;
            }
        }
        //function RadioCusClick()
       // {
       //     document.getElementById("divSuplier").style.display = "none";
      //      document.getElementById("divcustomer").style.display = "";
      //  }
       // function RadiosUPClick()
       // {
          //  document.getElementById("divSuplier").style.display = "";
          //  document.getElementById("divcustomer").style.display = "none";
       // }


        function PreviewPDF(pageurl) {
            // alert(pageurl);
            var Preview = window.open(pageurl, '_blank');
            Preview.focus();
        }
        function ExpiryDateChk()
        {
           
            var ExpireDate = document.getElementById("<%=BankGurntExpire.ClientID%>").value.trim();
            //alert(ExpireDate);
            var arrDateExpireDate = ExpireDate.split("-");
            var datearrDateExpireDate = new Date(arrDateExpireDate[2], arrDateExpireDate[1] - 1, arrDateExpireDate[0]);
           

            var CurrentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;
          
            var arrDateCurrentDate = CurrentDate.split("-");
          
            var datearrDateCurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);
           
            if (datearrDateExpireDate < datearrDateCurrentDate)
            {

                document.getElementById("<%=BankGurntExpire.ClientID%>").value = "";
            }
            
            return false;
        }

        
        function Autocomplt()
        {
            $au('#cphMain_ddlSup').selectToAutocomplete1Letter();
            $au('#cphMain_ddlBankNm').selectToAutocomplete1Letter();
            $au('#cphMain_ddlSuplCus').selectToAutocomplete1Letter();
        }

        function printredirect() {
            alert("");
            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
            $('#cphMain_divPrintReportSorted table tr').find('td:eq(8),th:eq(8),td:eq(9),th:eq(9),td:eq(10),th:eq(10),td:eq(11),th:eq(11),td:eq(12),th:eq(12)').remove();

        }

        function ChangeInsurGmsSection() {

            $('#divInsurProvider :input').removeAttr('disabled');
            $('#divGuaranteeSectn :input').removeAttr('disabled');
            document.getElementById("divddlBankName").style.display = "none";
            document.getElementById("divddlInsurncPrvdr").style.display = "none";

            //BankG
            if (document.getElementById("<%=ddlPolicyType.ClientID%>").value == "1") {  
                document.getElementById('idBankTypeOrCateg').innerHTML = 'Type        ';
                document.getElementById("divGuaranteeSectn").style.display = "block";
                document.getElementById("divInsurProvider").style.display = "block";
                document.getElementById("divddlBankName").style.display = "block";
            }
            else if (document.getElementById("<%=ddlPolicyType.ClientID%>").value == "2") {
                document.getElementById('idBankTypeOrCateg').innerHTML = 'Category';
                document.getElementById("divGuaranteeSectn").style.display = "block";
                document.getElementById("divInsurProvider").style.display = "block";
                $("#divGuaranteeSectn").find("input,button,textarea,select").attr("disabled", "disabled");
                document.getElementById("divddlInsurncPrvdr").style.display = "block";
             }
            else if (document.getElementById("<%=ddlPolicyType.ClientID%>").value == "0") {
                //EVM-0027 Aug1
                // divInsurProvider  divGuaranteeSectn
                document.getElementById('divInsurProvider').style.display = "";
                document.getElementById("divddlInsurncPrvdr").style.display = "";
                document.getElementById('divGuaranteeSectn').style.display = "";
                $('#divGuaranteeSectn :input').removeAttr('disabled');
                $("#divGuaranteeSectn").find("input,button,textarea,select").attr("disabled", "disabled");
                $("#divInsurProvider").find("input,button,textarea,select").attr("disabled", "disabled");
            }
        }



        //EVM-0027
        function printredirect() {
           

            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#PrintTable')[0].outerHTML;


            var resultCurrcy = [];
            var result = 0;
            var incrmnt = 0;

            $p('#cphMain_divPrintReportSorted table tr').each(function () {

                $p('td', this).each(function (index, val) {

                    if (document.getElementById("<%=ddlPolicyType.ClientID%>").value == "2") {

                        if (index == 7) {

                            result += parseFloat($(val).text().replace(/,/g, ""));
                        }

                    }
                    else {
                        if (index == 6) {

                            result += parseFloat($(val).text().replace(/,/g, ""));
                        }
                    }

                });

            });

            //$p('#cphMain_divPrintReportSorted table').append('<tr ></tr>');

           
          
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var n = result;
            if (FloatingValue != "") {
                n = result.toFixed(FloatingValue);
            }
          
            addCommas(n);
            var cnt = 0;
            var dec = cnt.toFixed(FloatingValue);

            if (document.getElementById("<%=HiddenFieldAmount.ClientID%>").value != dec)
            {
               

                if (document.getElementById("<%=hiddenPolicyType.ClientID%>").value == "2") {

                    $('#cphMain_divPrintReportSorted table tr').find('td:eq(9),th:eq(9),td:eq(10),th:eq(10),td:eq(11),th:eq(11),td:eq(12),th:eq(12),td:eq(13),th:eq(13)').remove();
                }
                else {
                    $('#cphMain_divPrintReportSorted table tr').find('td:eq(8),th:eq(8),td:eq(9),th:eq(9),td:eq(10),th:eq(10),td:eq(11),th:eq(11),td:eq(12),th:eq(12)').remove();
                }


            }


    //        var table = document.getElementById('PrintTable'),
    //rows = table.getElementsByTagName('tr'),
    //i, j, cells, customerId;

    //        for (i = 0, j = rows.length; i < j; ++i) {
    //            cells = rows[i].getElementsByTagName('tdTamount');
    //            if (!cells.length) {
    //                continue;
    //            }
    //            customerId = cells[0].innerHTML;
    //        }

            //$('#PrintTable td.tdTQAR').each(function () {

            //    var tdCount = $(this).find('td.tdTaa').text();
            //    alert(tdCount)
            //    var tdamt = $(this).find('td.tdTamount').text();
            //    alert(tdamt);

            //    if ($(this).find('td.tdTQAR').text() == "QAR")
            //        alert(find('td.tdTQAR').text());
            //    for (i = 0; i < tdCount; i++) {
            //        newRow[i] += parseInt($(this).eq(i).value);
            //    }
            //});
            //var row = "<tr>";
            //for (i = 0; i < newRow.length; i++)
            //    row += "<td>" + newRow[i] + "</td>";
            //row += "</tr>";
           // $("table").append(row);



            //var currentRow = $(this).closest("tr");
            
            //var col1 = currentRow.find("td:eq(tdT USD)").text(); // get current row 1st TD value
            //var col1 = currentRow.find("tdT USD").html();
            ////var col2 = currentRow.find("td:eq(1)").text(); // get current row 2nd TD
            ////var col3 = currentRow.find("td:eq(2)").text(); // get current row 3rd TD
            //var data = col1 ;

         //   alert(data);
           

            //$('#cphMain_divPrintReportSorted table tr').find( 'td:eq(tdT USD)').filter(function () {
              
            //    //return $(this).text() == "saved block";
            //}).text('changed');

         
            $p('#cphMain_divPrintReportSorted table').append($('#PrintTable1')[0].outerHTML);
        }


        function addCommas(amnt) {

            nStr = amnt;
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
                document.getElementById("<%=HiddenFieldAmount.ClientID%>").value = x1;
                //return x1;
            else
                document.getElementById("<%=HiddenFieldAmount.ClientID%>").value = x1 + "." + x2;
            // return x1 + "." + x2;

        }


        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();

        }
        //END

    </script>

   
       <script>
           var $au = jQuery.noConflict();

           (function ($au) {
               $au(function () {
                   $au('#cphMain_ddlPolicyNum').selectToAutocomplete1Letter();


                   $au('form').submit(function () {

                   });
               });
           })(jQuery);
       </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
       <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <asp:HiddenField ID="HiddenFieldRadioCusSupl" runat="server" />
    <asp:HiddenField ID="HiddenFieldRenew" runat="server" />
     <asp:HiddenField ID="hiddenFieldConfirm" runat="server" />
      <asp:HiddenField ID="hiddenRsnidclose" runat="server" />
    <asp:HiddenField ID="hiddenRoleClose" runat="server" />
    <asp:HiddenField ID="HiddenIntCanlId" runat="server" />
     <asp:HiddenField ID="HiddenGurantNum" runat="server" />
     <asp:HiddenField ID="HiddenFieldSuplier" runat="server" />
       <asp:HiddenField ID="HiddenFieldClient" runat="server" />

    <asp:HiddenField ID="hiddenCommodityValue" runat="server" />
    <asp:HiddenField ID="hiddenMemorySize" runat="server" />
      <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
     <asp:HiddenField ID="hiddenNext" runat="server" />
      <asp:HiddenField ID="hiddenPrevious" runat="server" />
      <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="HiddenCheckDashboard" runat="server" />
             <asp:HiddenField ID="hiddenRsn_INSRNCid" runat="server" />
                <asp:HiddenField ID="hiddenRsn_INSRNCidclose" runat="server" />
       <asp:HiddenField ID="hiddenDefaultDashboard" runat="server" />


        <%--EVM-0027--%>
    <asp:HiddenField ID="HiddenFieldAmount" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="HiddenCurrency" runat="server" />
   <%-- END--%>
        <asp:HiddenField ID="hiddenPolicyType" runat="server" />


    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>

      <asp:Button ID="BtnCSV" Style="float: right; height: 25px; margin-top: 4.5%; text-align: center; display: none" runat="server" class="searchlist_btn_rght" Text="CSV" OnClick="BtnCSV_Click" />

        <a id="A2" data-title="Item Listing" style="float: right; margin-top: 4.5%; color: rgb(83, 101, 51); font-family: Calibri; width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
        <img src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;"><span style="float: right; margin-top: 4%; margin-right: 55%;">CSV</span> </a>

       <div style="cursor: default; float: right; height: 25px; margin-right:3.5%;margin-top:4.5%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="A1" target="_blank" data-title="Item Listing"  href="/Reports/Print/SortedPrint.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                Print</a>                                    
                                </div>

     <div style="cursor: default; float: right; height: 25px; margin-right:4.5%;margin-top:4.5%;font-family:Calibri;display:none;" class="print" onclick="printredirectt()">            
                                 <a id="print_cap" target="_blank" data-title="Item Listing"  href="/Reports/Print/28_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                 Print</a>                                    
                                </div>
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>


     <div onclick="location.href='gen_Bank_Guarantee.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;">
        </div>
    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Bank-guarantee.png" style="vertical-align: middle;" />
            Policy
            <p id="pHeader" style="font-size: 16px;" runat="server"></p>
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 97.5%;margin-top:1%;">



            <div id="Divnext" style="width: 100%;float: left;">
                  <%--////////////////////////////////////L11L--%>
                           <div class="eachform" style="width: 97%; float: left; margin-top: 9px; margin-left: 18px; border: 1px solid; border-color: #9ba48b;">

             <asp:UpdatePanel ID="UpdatePanel2"  EnableViewState="true" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                 <div class="eachform" style="width: 30%; padding-left: 0.5%; padding-top: 1%; float: left;">
                     <h2 style="margin-top:1%; margin-left: 2%">Policy Type</h2>
                     <asp:DropDownList ID="ddlPolicyType" onchange="ChangeInsurGmsSection()" style="width:62%; float:left;margin-left:2%" class="form1" runat="server">
                        <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>--%> 
                         <asp:ListItem Value="1">Bank Guarantee</asp:ListItem>
                         <asp:ListItem Value="2">Insurance</asp:ListItem>
                     </asp:DropDownList>
                 </div>

                 <div class="eachform"  style="width: 37%; padding-left: 0.5%; padding-top: 1%; float: left;">
                     <h2 style="margin-top:1%; margin-left: 2%">Policy Number</h2>


                     <asp:DropDownList ID="ddlPolicyNum"   class="form1" Style="float: right; width: 48% !important; margin-right: 15%;" runat="server" AutoPostBack="false" autofocus="autofocus" autocorrect="off" autocomplete="off" onkeypress="return DisableEnter(event)">
                    </asp:DropDownList>

                     <%--<asp:TextBox ID="txtPolicyNum" class="form1" runat="server" Style="width: 60%; height: 27px; font-family: calibri; float: left; margin-left: 4%;"></asp:TextBox>--%>


                     </div>
                                         </ContentTemplate>
                     
                     </asp:UpdatePanel>




                 <div class="eachform" style="width: 30%; padding-left: 0.5%; padding-top: 0%; float: left;">
                     <h2 style="margin-top: 4%; margin-left: 2%">Expiry Date</h2>
                     <div id="DivExpre" class="input-append date" style="font-family: Calibri; width: 99%; margin-right: 1%; margin-top: 3%;">
                         <asp:TextBox ID="BankGurntExpire" class="textDate form1" placeholder="DD-MM-YYYY" MaxLength="20" onblur="return ExpiryDateChk();" runat="server" Style="width: 32%; height: 27px; font-family: calibri; float: left; margin-left: 4%;"></asp:TextBox>
                         <input type="image" id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextDateChange()" style="height: 19px; float: left; width: 12px; cursor: pointer;" />
                         <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
                         <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                         <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                         <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                         <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                         <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                         <script type="text/javascript">
                             var $noC2 = jQuery.noConflict();
                             $noC2('#DivExpre').datetimepicker({
                                 format: 'dd-MM-yyyy',
                                 language: 'en',
                                 pickTime: false,
                                // startDate: new Date(),


                             });
                             function FocusOnDate() {

                                 $noC2('#DivExpre').datetimepicker({
                                     format: 'dd-MM-yyyy',
                                     language: 'en',
                                     pickTime: false,
                                   //  startDate: new Date(),
                                 });
                             }
                         </script>
                         <p style="visibility: hidden">Please enter</p>
                     </div>
                 </div>

             </div>

                <%--//////////////////////////////////////////111--%>
                <div class="eachform" style="width: 20%; float: left; margin-top: 10px; border: 1px solid; border-color: #9ba48b; padding: 5px; margin-left: 12px;">
                    <div class="eachform" style="width: 100%; padding-left: 0.5%; padding-top: 1%; float: left;">
                        <h2 style="margin-top: 0.5%; margin-left: 5%;">From</h2>

                        <div id="Div3" class="input-append date" style="font-family: Calibri; float: right; width: 50%; margin-right: 7%; margin-top: 1%;">
                            <asp:TextBox ID="txtFromDate" class="textDate form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 82.8%; height: 27px; font-family: calibri; float: left; margin-left: -29%;" onkeypress="return DisableEnter(event)"></asp:TextBox>

                            <input type="image" id="img2" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextDateChange()" style="height: 19px; float: left; width: 12px; cursor: pointer;" />

                            <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
                            <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                            <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                            <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                            <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                            <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                            <script type="text/javascript">
                                var $noC2 = jQuery.noConflict();
                                $noC2('#Div3').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                });
                                function FocusOnDate() {

                                    $noC2('#Div3').datetimepicker({
                                        format: 'dd-MM-yyyy',
                                        language: 'en',
                                        pickTime: false,

                                    });
                                }
                            </script>
                            <p style="visibility: hidden">Please enter</p>
                        </div>
                    </div>

                    <div class="eachform" style="width: 100%; padding-left: 0.5%; padding-top: 1%; float: left;">
                        <h2 style="margin-top: 0.5%; margin-left: 5%;">To </h2>

                        <div id="ClosingDate" class="input-append date" style="font-family: Calibri; float: right; width: 50%; margin-right: 7%; margin-top: 1%; margin-bottom: -3px;">
                            <asp:TextBox ID="txtToDate" class="textDate form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 82.8%; height: 27px; font-family: calibri; float: left; margin-left: -29%;" onkeypress="return DisableEnter(event)"></asp:TextBox>

                            <input type="image" id="img1" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextDateChange()" style="height: 19px; float: left; width: 12px; cursor: pointer;" />

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
                                    //  startDate: new Date(),
                                });
                                function FocusOnDate() {

                                    $noC2('#ClosingDate').datetimepicker({
                                        format: 'dd-MM-yyyy',
                                        language: 'en',
                                        pickTime: false,
                                        //  startDate: new Date(),
                                    });
                                }
                            </script>
                            <p style="visibility: hidden">Please enter</p>
                        </div>

                    </div>
                </div>


                <%--//////////////////////////////////////////222--%>
                <div class="eachform" style="width: 16%; float: left; margin-top: 10px; margin-left: 12px; border: 1px solid; border-color: #9ba48b;">
                    <div class="eachform" style="width: 100%; padding-left: 0.5%; padding-top: 1%; float: left;">
                        <h2 style="margin-top: 5%; margin-left: 4%">Status</h2>
                        <asp:DropDownList ID="ddlGuaranteeStatus" class="form1" Style="height: 25px; width: 50%; margin-left: 17%; margin-top: 4%; float: left; margin-bottom: 9px;" runat="server">
                            <asp:ListItem Text="New"  Value="1"></asp:ListItem>
                            <asp:ListItem Text="Confirmed" Value="2"></asp:ListItem>

                            <asp:ListItem Text="Renewed" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Closed" Value="4"></asp:ListItem>
                            <asp:ListItem Text="All" Selected="True" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="eachform" style="width: 100%; padding-left: 0.5%; padding-top: 1%; float: left;">
                        <div style="width:40%"> 
                        <h2 id="idBankTypeOrCateg" style="margin-top: 5%; margin-left: 8%">Category</h2>
                            </div>
                        <div style="width:60%; float:right;"> 
                        <asp:DropDownList ID="ddlGuaranteeTyp" class="form1" Style="height: 25px; width: 82%; margin-left: 7%; margin-top: 4%; margin-bottom: 3%; float: left;" runat="server">
                            <asp:ListItem Text="Open" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Limited" Value="2"></asp:ListItem>
                            <asp:ListItem Text="All" Selected="True" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                            </div>
                    </div>
                </div>

                <%--/////////////////////////////////333--%>
                <div id="divGuaranteeSectn">
                <div class="eachform" style="width: 58%; float: left; margin-top: 10px; margin-left: 12px; border: 1px solid; border-color: #9ba48b;">
                    <h2 style="width: 18%; margin-top: 1%; margin-left: 1%">Guarantee Mode</h2>

                    <div class="eachform" style="width: 33%; padding-left: 1%; padding-top: 1%; float: left;">
                        <asp:DropDownList ID="ddlGuaranteeMde" class="form1" Style="height: 25px; width: 79%; margin-top: 0%; margin-left: 8px; float: left; margin-bottom: 2%;" runat="server">
                        </asp:DropDownList>
                    </div>

                    <div class="eachform" style="width: 20%; padding-left: 0%; padding-top: 1%; float: left;">
                        <div style="margin-left: 4%; float: left;">
                            <input id="radioBinding" type="radio" runat="server" onchange="RadioopenClick()" name="radType" onkeypress="return DisableEnter(event)" />
                            <label style="font-family: Calibri" for="cphMain_radioBinding">Bidding</label>
                        </div>
                    </div>

                    <div class="eachform" style="width: 20%; padding-left: 0.5%; padding-top: 1%; float: left;">
                        <div style="float: left;">
                            <input id="radioAwdrd" type="radio" runat="server" onchange="RadioLimitedClick()" name="radType" onkeypress="return DisableEnter(event)" />
                            <label style="font-family: Calibri" for="cphMain_radioAwdrd">Awarded</label>
                        </div>
                    </div>

                    <div class="eachform" style="width: 100%; padding-left: 0%; padding-top: 1%; float: left;">
                        <div class="eachform" style="width: 50%; padding-left: 0.5%; padding-top: 0%; float: left;">
                            <h2 style="margin-top: 0.5%; margin-left: 1%">Customer/Supplier</h2>
                            <asp:DropDownList ID="ddlCustSuplrsrch" class="form1" AutoPostBack="true" OnSelectedIndexChanged="ddlCustSuplrsrch_SelectedIndexChanged" autocorrect="off" autocomplete="off" Style="height: 25px; width: 57.5%; margin-left: 2%; margin-top: 0%; float: left; margin-bottom: 9px;" runat="server" >
                                <asp:ListItem Text="CUSTOMER" Value="2"></asp:ListItem>
                                <asp:ListItem Text="SUPPLIER" Selected="True" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="eachform" style="width: 49%; padding-left: 0.5%; padding-top: 0%; float: left;">
                            <h2 runat="server" id="h2SuplCus" style="width: 25%; margin-top: 0.5%; margin-left: 4%;">Customer/Supplier</h2>
                            <div runat="server" id="divcustomer">
                                <asp:DropDownList ID="ddlSuplCus" class="form1" Style="float: left; height: 25px; width: 58%; margin-right: 0%;" runat="server" onkeypress="return DisableEnter(event)"></asp:DropDownList>
                            </div>
                            <div runat="server" id="divSuplier">
                                <asp:DropDownList ID="ddlSup" class="form1" Style="float: left; height: 25px; width: 58%; margin-right: 0%;" runat="server" onkeypress="return DisableEnter(event)"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
              </div>
         </div>

              
          
  
  

                        <div id="CustmrBank" style="width: 100%;float: left;">

    

            
                         
   <asp:UpdatePanel ID="UpdatePanel1"  EnableViewState="true" UpdateMode="Conditional" runat="server">
                <ContentTemplate>


        <div id="divInsurProvider">
                    <div class="eachform" style="width: 38%; float: left; margin-top: 10px; border: 1px solid; border-color: #9ba48b; margin-left: 1%;">

                        <div id="divddlBankName">
                        <div class="eachform" style="width: 100%; padding-left: 0.5%; padding-top: 3%; float: left; padding-bottom: 1%;">
                            <h2 style="margin-top: 0.5%; margin-left: 3%;">Bank Name </h2>

                            <asp:DropDownList ID="ddlBankNm" class="form1" Style="height: 25px; width: 56%; margin-right: 10%;" runat="server" onkeypress="return DisableEnter(event)">
                            </asp:DropDownList>
                        </div>
                        </div>


                            <div id="divddlInsurncPrvdr">

                           <div class="eachform" style="width: 100%; padding-left: 0.5%; padding-top: 3%; float: left; padding-bottom: 1%;">
                                <h2 style="margin-top: 0.5%; margin-left: 3%;">Insurance Type </h2>
                            <asp:DropDownList ID="ddlInsurncTyp" class="form1" Style="height: 25px; width: 56%; margin-right: 10%;" runat="server" onkeypress="return DisableEnter(event)">
                            </asp:DropDownList>
                            </div>

                                <div class="eachform" style="width: 100%; padding-left: 0.5%; padding-top: 3%; float: left; padding-bottom: 1%;">
                                <h2 style="margin-top: 0.5%; margin-left: 3%;">Insurance Provider </h2>
                            <asp:DropDownList ID="ddlInsurncPrvdr" class="form1" Style="height: 25px; width: 56%; margin-right: 10%;" runat="server" onkeypress="return DisableEnter(event)">
                            </asp:DropDownList>
                            </div>


                        </div>


                    </div>
                    </div>
                      </ContentTemplate>
                     
                     </asp:UpdatePanel>
                            <div style="width: 20%; float: left; margin-top: 0%; /*! margin-bottom: 4%; */height: 127px;">

                                 <div class="eachform" style=" height: 55px; margin-top: 0%;">
                                    <div class="subform" style=" float: left; margin-left: 9%; margin-top: 12%;">

                                   <h3 style="margin-top: 1%;">Currency</h3>
                                     <asp:DropDownList ID="ddlCurrency" class="form1" Style="float: right; width: 67.8% !important;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off" onkeypress="return DisableEnter(event)">
                                     </asp:DropDownList>

                                    </div>
                                </div>


                              <%-- EVM-0027 Aug--%>

                                   <div class="eachform" >
                                    <div class="subform" style=" float: left; margin-left: 126%; margin-top: -17%;">
                                        <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" Checked="false" class="form2" onkeypress="return DisableEnter(event)" />
                                        <h3 style="margin-top: 1%;">Show Deleted Entries</h3>
                                    </div>
                                </div>

                              <%--  <div class="eachform" style="margin-left: 222%;    margin-top: -25%;">--%>
                              
                    <asp:Button ID="btnSearch" Style="cursor: pointer;margin-left: 217%;margin-top: -26%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
                                
                                    
                           

                            <%--END--%>
                            </div>
                </div>
            <br style="clear: both" />
            </div>
        <br />
         <br />

        
          
        <table style="width:35%;">
            <tr>
                <td style="width:28%;">
                    <asp:Button ID="btnPrevious" style=" float:left; font-size: 13px;" Enabled="false"  Width="98%" runat="server" class="searchlist_btn_rght" Text="Show Previous 500 Records" OnClick="btnPrevious_Click"  />
          </td>
                <td style="width:25%;">

        <asp:Button ID="btnNext"  Width="98%" Margin-Left="5px"  style=" float:left; font-size: 13px;" runat="server" class="searchlist_btn_rght" Text="Show Next 500 Records" OnClick="btnNext_Click"  />
               </td>
               </tr>
        </table>

       
      <%--    <br />
        <br />--%>
        <div id="divReport" class="table-responsive" runat="server">
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
        <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
         <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
    </div>
        <div id="divtile" runat="server" style="display: none"></div>
          <div id="divTitle" runat="server" style="display: none"></div>

         <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>
                 
            </div>
                                 <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Bank Guarantee</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   



              <div id="MymodalCloseView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCloseView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Bank Guarantee</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorCloseRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorCloseRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Close Reason*</label>
                        <asp:TextBox ID="TxtCloseReson" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_TxtCloseReson)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_TxtCloseReson,450)" onkeyup="textCounter(cphMain_TxtCloseReson,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="BtnCloseSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCloseReason();" OnClick="BtnCloseSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnCloseCancl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCloseView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

    
       <%--------------------------------View for error Reason INSURANCE--------------------------%>
            <div id="MymodalCancelView_INSRNC" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView_INSRNC();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Insurance</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS_INSRNC" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS_INSRNC" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason_INSRNC" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason_INSRNC)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason_INSRNC,450)" onkeyup="textCounter(cphMain_txtCnclReason_INSRNC,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave_INSRNC" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason_INSRNC();" OnClick="btnRsnSave_INSRNC_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl_INSRNC" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView_INSRNC();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>  

          <div id="MymodalCloseView_INSRNC" class="modalCancelView" >
                <!-- Modal content INSURANCE-->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCloseView_INSRNC();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Insurance</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorCloseRsnAWMS_INSRNC" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorCloseRsnAWMS_INSRNC" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Close Reason*</label>
                        <asp:TextBox ID="TxtCloseReson_INSRNC" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_TxtCloseReson_INSRNC)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_TxtCloseReson_INSRNC,450)" onkeyup="textCounter(cphMain_TxtCloseReson_INSRNC,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="BtnCloseSave_INSRNC" class="save" runat="server" Text="Save" OnClientClick="return ValidateCloseReason_INSRNC();" OnClick="BtnCloseSave_INSRNC_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnCloseCancl_INSRNC" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCloseView_INSRNC();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div> 




         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height:auto!important;"
                class="freezelayer" id="freezelayer">
                    </div>
    </div>

<%--    <a href="TEST_SERVICE.aspx">TEST_SERVICE.aspx</a>--%>

    <style>


                #cphMain_TxtCloseReson_INSRNC {
    font-family: Calibri;
}

        #divErrorCloseRsnAWMS_INSRNC {
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

        textarea {
    overflow: auto;
    vertical-align: top;
}
        #cphMain_TxtCloseReson {
    font-family: Calibri;
}
        #divErrorCloseRsnAWMS {
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

     

        #ReportTable_filter input {
    height: 19px;
    width: 208px;
    color: #336B16;
    font-size: 14px;
}
             .open > .dropdown-menu {
    display: none;
}
        </style>
     <style>
.divbutton {
    display:inline-block;
    color:#0C7784;
    border:1px solid #999;
    background:#CBCBCB;
    /*box-shadow: 0 0 5px -1px rgba(0,0,0,0.2);*/
    cursor:pointer;
    vertical-align:middle;
    width: 18.7%;
    padding: 5px;
    text-align: center;
    font-family: calibri;
}
.divbutton:active {
    color:red;
    box-shadow: 0 0 5px -1px rgba(0,0,0,0.6);
}

    </style>

                          <div style="width: 31%; float: left; padding-top: 1%; margin-left: 36%; display: none">
                            <input id="radioCus" type="radio" runat="server" onchange="RadioCusClick()" name="radTypenxt" />
                            <label style="font-family: Calibri" for="cphMain_radioOpen">Customer</label>
                        </div>


                        <div style="width: 29%; float: left; margin-top: -5%; margin-left: 69%; display: none">
                            <input id="radioSup" type="radio" runat="server" onchange="RadiosUPClick()" name="radTypenxt" />
                            <label style="font-family: Calibri" for="cphMain_radioLimited">Supplier</label>
                        </div>




</asp:Content>


