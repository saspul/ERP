<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" CodeFile="gen_Pay_Grade_Master.aspx.cs" Inherits="HCM_HCM_Master_gen_Pay_Grade_Master_gen_Pay_Grade_Master" %>


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
 input[type="radio"] {
             display: inline-block;
         }
 #ReportTables_filter input {
    height: 23px;
    width: 200px;
    color: #336B16;
    font-size: 14px;
}


  
     </style>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
               <script>
                   function addCommas(textboxid) {

                       nStr = document.getElementById(textboxid).value;
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
                       document.getElementById(''+textboxid+'').value = x1;
                       //return x1;
                   else
                       document.getElementById(''+textboxid+'').value = x1 + "." + x2;
                       // return x1 + "." + x2;
                  
                   }
                   function addCommasSummry(nStr) {
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
                           document.getElementById("<%=Hiddenreturnfun.ClientID%>").value = x1;
                           //return x1;
                       else
                           document.getElementById("<%=Hiddenreturnfun.ClientID%>").value = x1 + "." + x2;
                       

                   }


    </script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
             
              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              //if (CancelPrimaryId != "") {
              //    OpenCancelView();
              //}
            
              document.getElementById('SumryPayRng').innerHTML = document.getElementById("<%=HiddenAmountRnge.ClientID%>").value;
              if (document.getElementById("<%=HiddenEdtOrViw.ClientID%>").value == "") {
                  document.getElementById("<%=cbxRestrictPaygrd.ClientID%>").checked = false;
          
              }
              if (document.getElementById("<%=hiddenRoleAdd.ClientID%>").value == "0")
              {
                  document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "none";
                  document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "none";
              }
              document.getElementById("<%=CheckRestrict.ClientID%>").checked = false;
              document.getElementById("<%=RestrctstsDed.ClientID%>").checked = false;
              document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
              document.getElementById("<%=radPercntge.ClientID%>").checked = true;
              // RadioAmountClick();
              RadioPerClick();

              //document.getElementById("<%=RadioPercAllow.ClientID%>").checked = true;
              document.getElementById("<%=radioBascPayAllow.ClientID%>").checked = true;


              document.getElementById("<%=RadioPercAllow.ClientID%>").checked = true;
              document.getElementById("<%=radAmntAllw.ClientID%>").checked = false;
              RadioPerClickAllow();
              
              
          });


          </script>
      <script type="text/javascript">
          var $Mo = jQuery.noConflict();

          function OpenCancelView() {



              document.getElementById("MymodalCancelView").style.display = "block";
              document.getElementById("freezelayer").style.display = "";
              document.getElementById("<%=txtCnclReason.ClientID%>").focus();
              document.getElementById("<%=txtCnclReason.ClientID%>").value = "";
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
              LoadListPageallwnce();
             LoadListPageDed();
  
              return false;
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

    </script>
   
    <script type="text/javascript">
      
        function SuccessConfirmationAllwnce() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Salary allowance details inserted successfully.";
            ClearAddition();
            document.getElementById("<%=txtName.ClientID%>").focus();
            LoadListPageallwnce();
            LoadListPageDed();
            $(window).scrollTop(0);
        }
        function DuplicationSalaryAllwnce()
        {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error.salary allowance can't be duplicated.";
            document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "Red";
            LoadListPageallwnce();
            LoadListPageDed();
            $(window).scrollTop(0);
        }
        function SuccessCancelationAllwnce() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Allowance cancelled successfully.";
            document.getElementById("<%=txtName.ClientID%>").focus();
            LoadListPageallwnce();
            LoadListPageDed();
            ClearAddition();
            $(window).scrollTop(0);
            
           
        }
        function UpdatePayGradeAllwnce() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Allowance details updated successfully.";
            document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
            document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";
            ClearAddition();
            LoadListPageallwnce();
            LoadListPageDed();
            document.getElementById("<%=txtName.ClientID%>").focus();
            $(window).scrollTop(0);
        }


        function SuccessConfirmationDedctn() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Salary deduction details inserted successfully.";
            ClearDedAll();
            LoadListPageallwnce();
            LoadListPageDed();
            document.getElementById("<%=txtName.ClientID%>").focus();
            $(window).scrollTop(0);
        }
        function DuplicationSalaryDedctn() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error.Salary deduction can't be duplicated.";
            document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "Red";
            LoadListPageallwnce();
            LoadListPageDed();
            $(window).scrollTop(0);
        }
        function DuplicationSalaryDedctnUpdate()
        {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error.Salary deduction can't be duplicated.";
            document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "none";
            document.getElementById("<%=UpdateDedctn.ClientID%>").style.display = "block";
            LoadListPageallwnce();
            LoadListPageDed();
            $(window).scrollTop(0);
        }
        function SuccessCancelationDedctn() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Deduction cancelled successfully.";
            LoadListPageallwnce();
            LoadListPageDed();
            document.getElementById("<%=txtName.ClientID%>").focus();
            ClearDedAll();
            $(window).scrollTop(0);
            
        }
        function UpdatePayGradeDedctn() {
     
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Deduction details updated successfully.";
            document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "block";
            document.getElementById("<%=UpdateDedctn.ClientID%>").style.display = "none";
            LoadListPageallwnce();
            LoadListPageDed();
            ClearDedAll();
            document.getElementById("<%=txtName.ClientID%>").focus();
            $(window).scrollTop(0);
        }



        function SuccessChangeAllowceStatus() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Allowance status changed successfully.";
            LoadListPageallwnce();
            LoadListPageDed();
            document.getElementById("<%=txtName.ClientID%>").focus();
           // $(window).scrollTop(0);
        }
        function SuccessChangeDedctnStatus() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Deduction status changed successfully.";
            LoadListPageallwnce();
            LoadListPageDed();
            document.getElementById("<%=txtName.ClientID%>").focus();
             // $(window).scrollTop(0);
          }
        function SuccessConfirmationPayGrade() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Pay grade details inserted successfully.";
           // ClearAllPaygrd();
            LoadListPageallwnce();
            LoadListPageDed();
          
            document.getElementById("<%=HiddenAmountRnge.ClientID%>").value = document.getElementById("<%=HiddenAmountRngeChk.ClientID%>").value ;
            document.getElementById("<%=txtName.ClientID%>").focus();
           // document.getElementById("<%=btnUpdate.ClientID%>").style.display = "block";
            //document.getElementById("<%=btnAdd.ClientID%>").style.display = "none";
            $(window).scrollTop(0);
           
            //document.getElementById("<%=HiddenAmountRnge.ClientID%>").value = document.getElementById("<%=HiddenAmountRngeChk.ClientID%>").value;
        }
        function UpdatePayGradePayGrade() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Pay grade details updated successfully.";
           // ClearAllPaygrd();
            LoadListPageallwnce();
            LoadListPageDed();
            document.getElementById("<%=HiddenAmountRnge.ClientID%>").value = document.getElementById("<%=HiddenAmountRngeChk.ClientID%>").value ;
            document.getElementById("<%=txtName.ClientID%>").focus();
            $(window).scrollTop(0);
          
        }
     
        function DuplicationPaygrdName() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error.Pay grade can't be duplicated.";
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
            $(window).scrollTop(0);
         //   document.getElementById("<%=HiddenAmountRnge.ClientID%>").value = document.getElementById("<%=HiddenAmountRngeChk.ClientID%>").value;
            // document.getElementById('SumryPayRng').innerHTML = "";
            
          
       }
      
     
       
        function CancelAlert(href) {

            if (confirm("Do you want to cancel this entry?")) {
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

        var confirmbox = 0;
           
        var confirmboxSalryAllwnce = 0;
        var confirmboxSalryDedctn = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }
 
        function IncrmntConfrmCounterSalryAllwnce() {
            confirmboxSalryAllwnce++;
        }
        function IncrmntConfrmCounterSalryDedctn() {
            confirmboxSalryDedctn++;
        }
        function AlertClearAll() {
        
            if (confirmbox > 0 || confirmboxSalryAllwnce > 0 || confirmboxSalryDedctn>0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    window.location.href = "gen_Pay_Grade_Master_list.aspx";
                }
                else {
                    return false;
                }
            }
            else {
               window.location.href = "gen_Pay_Grade_Master_list.aspx";

            }
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
        </script>

   <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
     

        var $p = jQuery.noConflict();
        $p(document).ready(function () {


            $p('#ReportTableAllw').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25,
                "bDestroy": true


            });

            $p('#ReportTableDed').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25,
                "bDestroy": true


            });

        
        });
  
        
   


    </script>



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


            
    <%--  //SALARY DETAILS--%>
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

        function RadioAmountClickAllow() {

            document.getElementById('divperclkAllow').style.display = "none";
            document.getElementById('divAmtAllow').style.display = "block";
            document.getElementById('AllowRestr').style.display = "block";
        }
        function RadioPerClickAllow() {
            document.getElementById('divperclkAllow').style.display = "block";
            document.getElementById('divAmtAllow').style.display = "none";
            document.getElementById('AllowRestr').style.display = "none";

        }

        function RadioAmountClick()
        {
            
            document.getElementById('divperclk').style.display = "none";
            document.getElementById('divAmtClk').style.display = "block";
            document.getElementById('divRestrct').style.display = "block";
        }
        function RadioPerClick()
        {
            document.getElementById('divperclk').style.display = "block";
            document.getElementById('divAmtClk').style.display = "none";
            document.getElementById('divRestrct').style.display = "none";
            
        }
        function Rangeexceed(textboxid1)
        {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "From range amount should not be equal or greater than the To range amount.";
            document.getElementById(textboxid1).style.borderColor = "Red";
           // document.getElementById(textboxid1).focus();
            $(window).scrollTop(0);
           
        }
        function ValidateDedctn(buttnId)
        {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            var NameWithoutReplace = document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = replaceText2;

            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtAmntRedcnTo.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAmntRedcnTo.ClientID%>").value = replaceText2;

            
            var NameWithoutReplace = document.getElementById("<%=txtperctg.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtperctg.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtperctgTo.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtperctgTo.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtAmntRedcnTo.ClientID%>").value;
            var AmntTo = NameWithoutReplace.replace(/,/g, "");

            var NameWithoutReplace = document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value;
            var AmntFrom = NameWithoutReplace.replace(/,/g, "");

            
            var NameWithoutReplace = document.getElementById("<%=txtperctg.ClientID%>").value;
            var Perctge = NameWithoutReplace.replace(/,/g, "");

            var NameWithoutReplace = document.getElementById("<%=txtperctgTo.ClientID%>").value;
            var PerctgeTo = NameWithoutReplace.replace(/,/g, "");

            document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAmntRedcnTo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtperctgTo.ClientID%>").style.borderColor = "";

            document.getElementById('DivPaygrd').style.borderColor = "";

            // var AmntFrom = document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value.trim();
            // var AmntTo = document.getElementById("<%=txtAmntRgeTo.ClientID%>").value.trim();

            var varddlAddtn = document.getElementById("<%=ddldedctn.ClientID%>");
            var ddlDedctnText = varddlAddtn.options[varddlAddtn.selectedIndex].text;
            
            
            
            if (document.getElementById("<%=radAmnt.ClientID%>").checked == true) {
                if (AmntTo == "") {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtAmntRedcnTo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAmntRedcnTo.ClientID%>").focus();
                    ret = false;
                }
                else {
                    document.getElementById("<%=txtAmntRgeTo.ClientID%>").style.borderColor = "";
                }

                if (AmntFrom == "") {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").focus();
                    ret = false;
                }
                else {
                    document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "";
                }

                if (AmntTo != "" && AmntFrom != "") {
                    if (parseFloat(AmntTo) <= parseFloat(AmntFrom)) {
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "From Range amount should not be equal or greater than the To Range amount.";
                        document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").focus();
                    }

                }
            }
            else if (document.getElementById("<%=radPercntge.ClientID%>").checked == true)
            {

                if (PerctgeTo == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtperctgTo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtperctgTo.ClientID%>").focus();
                    ret = false;
                }
                else {

                    if (parseFloat(PerctgeTo) > parseFloat(100)) {

                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Percentage should not exceed hundred.";
                        document.getElementById("<%=txtperctgTo.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtperctgTo.ClientID%>").focus();
                        ret = false;
                    }
                    else {


                        var perTotalChek = 0;

                        var PerTotal = parseFloat(document.getElementById("<%=HiddenTotalPerTotal.ClientID%>").value);

                        var PerBasic = parseFloat(document.getElementById("<%=HiddenTotalPerBasic.ClientID%>").value);

                        // perTotalChek=parseFloat(PerTotal)+parseFloat(PerBasic)+parseFloat(Perctge) ;
                        var EditPerValue = parseFloat(document.getElementById("<%=HiddenEditPerctgTo.ClientID%>").value);
                        if (buttnId == 'UpdateDedctn') {

                            perTotalChek = parseFloat(PerTotal) + parseFloat(PerBasic) + parseFloat(PerctgeTo) - parseFloat(EditPerValue);

                        }
                        else if (buttnId == 'SaveDedctn') {

                            perTotalChek = parseFloat(PerTotal) + parseFloat(PerBasic) + parseFloat(PerctgeTo);

                        }


                        if (parseFloat(perTotalChek) > parseFloat(100)) {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sum of percentage in deduction should be less than or equal to hundred.";
                            document.getElementById("<%=txtperctgTo.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtperctgTo.ClientID%>").focus();
                            ret = false;
                        }
                    }
                }


                if (Perctge == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtperctg.ClientID%>").focus();
                    ret = false;
                }
                else {
                    
                    if (parseFloat(Perctge) > parseFloat(100))
                    {
                       
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Percentage should not exceed hundred.";
                        document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtperctg.ClientID%>").focus();
                        ret = false;
                    }
                    else {


                        var perTotalChek = 0;

                        var PerTotal = parseFloat(document.getElementById("<%=HiddenTotalPerTotal.ClientID%>").value);

                        var PerBasic = parseFloat(document.getElementById("<%=HiddenTotalPerBasic.ClientID%>").value);

                        // perTotalChek=parseFloat(PerTotal)+parseFloat(PerBasic)+parseFloat(Perctge) ;
                        var EditPerValue = parseFloat(document.getElementById("<%=HiddenEditPerctg.ClientID%>").value);
                        if (buttnId == 'UpdateDedctn') {
                         
                            perTotalChek = parseFloat(PerTotal) + parseFloat(PerBasic) + parseFloat(Perctge) - parseFloat(EditPerValue);

                        }
                        else if (buttnId == 'SaveDedctn') {

                            perTotalChek = parseFloat(PerTotal) + parseFloat(PerBasic) + parseFloat(Perctge);

                        }
                      
                
                        if (parseFloat(perTotalChek) > parseFloat(100)) {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sum of percentage in deduction should be less than or equal to hundred.";
                            document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtperctg.ClientID%>").focus();
                            ret = false;
                        }
                    }
                }
            }
            if (ddlDedctnText == "--SELECT SALARY DEDUCTION--") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddldedctn.ClientID%>").focus();
                ret = false;
            }
            if (document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value == "")
            {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please add paygrade to proceed.";
                document.getElementById('DivPaygrd').style.borderColor = "Red";
                document.getElementById("<%=txtName.ClientID%>").focus();
                ret = false;
            }
            CheckSubmitZero();
            $(window).scrollTop(0);
            return ret;

        }
        function ValidateAllwnce(buttnId)
        {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = replaceText2;

            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtAmntRgeTo.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAmntRgeTo.ClientID%>").value = replaceText2;


            var NameWithoutReplace = document.getElementById("<%=txtperctgAllw.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtperctgAllw.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtperctgAllwTo.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtperctgAllwTo.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtAmntRgeTo.ClientID%>").value;
            var AmntTo = NameWithoutReplace.replace(/,/g, "");

            var NameWithoutReplace = document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value;
            var AmntFrom = NameWithoutReplace.replace(/,/g, "");

            var NameWithoutReplace = document.getElementById("<%=txtperctgAllw.ClientID%>").value;
            var Perctge = NameWithoutReplace.replace(/,/g, "");

            var NameWithoutReplace = document.getElementById("<%=txtperctgAllwTo.ClientID%>").value;
            var PerctgeTo = NameWithoutReplace.replace(/,/g, "");

            document.getElementById("<%=txtperctgAllw.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtperctgAllwTo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAmntRgeTo.ClientID%>").style.borderColor = "";
            document.getElementById('DivPaygrd').style.borderColor = "";

           // var AmntFrom = document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value.trim();
           // var AmntTo = document.getElementById("<%=txtAmntRgeTo.ClientID%>").value.trim();

            var varddlAddtn = document.getElementById("<%=ddlAddtn.ClientID%>");
            var ddlAddtnText = varddlAddtn.options[varddlAddtn.selectedIndex].text;



     

            if (document.getElementById("<%=radAmntAllw.ClientID%>").checked == true) {
               
                if (AmntTo == "") {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtAmntRgeTo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAmntRgeTo.ClientID%>").focus();
                    ret = false;
                }
                else {
                    document.getElementById("<%=txtAmntRgeTo.ClientID%>").style.borderColor = "";
                }

                if (AmntFrom == "") {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAmntRgeFrm.ClientID%>").focus();
                    ret = false;
                }
                else {
                    document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "";
                }

                if (AmntTo != "" && AmntFrom != "") {
                    if (parseFloat(AmntTo) <= parseFloat(AmntFrom)) {
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "From Range amount should not be equal or greater than the To Range amount.";
                        document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtAmntRgeFrm.ClientID%>").focus();
                    }

                }
            }
            else if (document.getElementById("<%=RadioPercAllow.ClientID%>").checked == true) {


                if (PerctgeTo == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtperctgAllwTo.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=txtperctgAllwTo.ClientID%>").focus();
                     ret = false;
                 }
                 else {

                    if (parseFloat(PerctgeTo) > parseFloat(100)) {

                         document.getElementById('divMessageArea').style.display = "";
                         document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Percentage should not exceed hundred.";
                        document.getElementById("<%=txtperctgAllwTo.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtperctgAllwTo.ClientID%>").focus();
                        ret = false;
                    }
                    else {


                        var perTotalChek = 0;


                        var PerBasic = parseFloat(document.getElementById("<%=HiddenTotalPerBasicAloww.ClientID%>").value);
                        var EditPerValue = parseFloat(document.getElementById("<%=HiddenEditPerctgTo.ClientID%>").value);



                        if (buttnId == 'UpdateAddtn') {
                            //alert(PerBasic + "PerBasic");
                            //alert(Perctge + "Perctge");
                            //alert(EditPerValue + "EditPerValue");

                            perTotalChek = parseFloat(PerBasic) + parseFloat(PerctgeTo) - parseFloat(EditPerValue);


                        }
                        else if (buttnId == 'SaveAddtn') {

                            perTotalChek = parseFloat(PerBasic) + parseFloat(PerctgeTo);

                        }


                        if (parseFloat(perTotalChek) > parseFloat(100)) {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sum of percentage in allowance should be less than or equal to hundred.";
                            document.getElementById("<%=txtperctgAllwTo.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtperctgAllwTo.ClientID%>").focus();
                            ret = false;
                        }
                    }
                }


                if (Perctge == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtperctgAllw.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtperctgAllw.ClientID%>").focus();
                    ret = false;
                }
                else {

                    if (parseFloat(Perctge) > parseFloat(100)) {

                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Percentage should not exceed hundred.";
                        document.getElementById("<%=txtperctgAllw.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtperctgAllw.ClientID%>").focus();
                        ret = false;
                    }
                    else {


                        var perTotalChek = 0;

                      //  var PerTotal = parseFloat(document.getElementById("<%=HiddenTotalPerTotalAllow.ClientID%>").value);

                        var PerBasic = parseFloat(document.getElementById("<%=HiddenTotalPerBasicAloww.ClientID%>").value);
                        var EditPerValue = parseFloat(document.getElementById("<%=HiddenEditPerctg.ClientID%>").value);
                        
                     

                        if (buttnId == 'UpdateAddtn') {
                            //alert(PerBasic + "PerBasic");
                            //alert(Perctge + "Perctge");
                            //alert(EditPerValue + "EditPerValue");
                         
                            perTotalChek = parseFloat(PerBasic) + parseFloat(Perctge) - parseFloat(EditPerValue);
                         

                        }
                        else if (buttnId == 'SaveAddtn') {

                            perTotalChek = parseFloat(PerBasic) + parseFloat(Perctge);

                        }


                        if (parseFloat(perTotalChek) > parseFloat(100)) {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sum of percentage in allowance should be less than or equal to hundred.";
                            document.getElementById("<%=txtperctgAllw.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtperctgAllw.ClientID%>").focus();
                            ret = false;
                        }
                    }
                }
            }



            if (ddlAddtnText == "--SELECT SALARY ADDITION--") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=ddlAddtn.ClientID%>").focus();
                  ret = false;
            }
            if (document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please add paygrade to proceed.";
                                document.getElementById('DivPaygrd').style.borderColor = "Red";
                document.getElementById("<%=txtName.ClientID%>").focus();
                ret = false;
            }
            else {

            }
           
                CheckSubmitZero();
            
            
            $(window).scrollTop(0);
            return ret;
        }
        function ValidatePayGrade()
        {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            var NameWithoutReplace = document.getElementById("<%=txtBasicpayFrm.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtBasicpayFrm.ClientID%>").value = replaceText2;

            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtBasicpayTo.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtBasicpayTo.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtName.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtBasicpayTo.ClientID%>").value;
           
            var AmntTo = NameWithoutReplace.replace(/,/g, "");

            var NameWithoutReplace = document.getElementById("<%=txtBasicpayFrm.ClientID%>").value;
            var AmntFrom = NameWithoutReplace.replace(/,/g, "");
          
          


            document.getElementById("<%=txtBasicpayFrm.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtBasicpayTo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";

            var Name = document.getElementById("<%=txtName.ClientID%>").value.trim();
           
           // var AmntFrom = document.getElementById("<%=txtBasicpayFrm.ClientID%>").value.trim();
           // var AmntTo = document.getElementById("<%=txtBasicpayTo.ClientID%>").value.trim();

            var varddlAddtn = document.getElementById("<%=ddlcurrncy.ClientID%>");
            var ddlAddtnText = varddlAddtn.options[varddlAddtn.selectedIndex].text;
            

            var ddlAddtnValue = document.getElementById("<%=ddlcurrncy.ClientID%>").value;
         
            var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
            var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;


            if (ddlAddtnText == "--SELECT CURRENCY--") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlcurrncy.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlcurrncy.ClientID%>").focus();
                ret = false;
            }
           // else {
           // var  ddlcurval=  document.getElementById("<%=ddlcurrncy.ClientID%>").value;
           //     currcyabbrvLoad(ddlcurval);
           // }
   
           
            var currcAbbrv="";
            if (ddlAddtnText != "--SELECT CURRENCY--") {
                var Details = PageMethods.LoadCurrcyAbbrv(ddlAddtnValue, CorpId, OrgId, function (response) {
                   currcAbbrv = response;
                    
                });
            }

            var Amountsummry;

            if (AmntTo == "") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtBasicpayTo.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtBasicpayTo.ClientID%>").focus();
                ret = false;
            }
            else {
                document.getElementById("<%=txtBasicpayTo.ClientID%>").style.borderColor = "";
            }

            if (AmntFrom == "") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtBasicpayFrm.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtBasicpayFrm.ClientID%>").focus();
                ret = false;
            }
            else {
                document.getElementById("<%=txtBasicpayFrm.ClientID%>").style.borderColor = "";
            }

            if (AmntTo != "" && AmntFrom != "") {
              
              
                if (parseFloat(AmntTo) <= parseFloat(AmntFrom)) {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "From Range amount should not be equal or greater than the To Range amount.";
                    document.getElementById("<%=txtBasicpayFrm.ClientID%>").style.borderColor = "Red";
                   // document.getElementById("<%=txtBasicpayTo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtBasicpayFrm.ClientID%>").focus(); 
                    ret = false;
                }

            }
          
         
            
            if (Name == "")
            {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtName.ClientID%>").focus();
                ret = false;

            }
            CheckSubmitZero();
            $(window).scrollTop(0);
            if (ret == true)
            {
               // alert(Amountsummry);
                // document.getElementById('SumryPayRng').innerHTML = Amountsummry;
                addCommasSummry(AmntFrom);
                AmntFrom = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                addCommasSummry(AmntTo);
                AmntTo = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                document.getElementById("<%=HiddenBasicForPer.ClientID%>").value = AmntFrom + "-" + AmntTo;
                Amountsummry = AmntFrom + " - " + AmntTo + "  " + currcAbbrv;
              
                document.getElementById("<%=HiddenAmountRngeChk.ClientID%>").value = Amountsummry + " " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
                
               // document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value = currcAbbrv;
                
            }
            return ret;

        }

        </script>
       <script type="text/javascript" >
           function isNumber(evt, textboxid) {
             
               evt = (evt) ? evt : window.event;
               var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
               var charCode = (evt.which) ? evt.which : evt.keyCode;
             //  alert(textboxid);
               var txtPerVal = document.getElementById(textboxid).value;
              // alert(txtPerVal);
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
                   if (textboxid == textboxid) {
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
                       //alert("55");
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
       
           function AmountChecking(textboxid,textboxid1, textboxid2) {
              // alert("111");
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
                      document.getElementById('divMessageArea').style.display = "none";
                      document.getElementById(textboxid1).style.borderColor = "";
                      document.getElementById('' + textboxid + '').value = n;
                      if (textboxid != 'cphMain_txtperctg' && textboxid != 'cphMain_txtperctgAllw') {
                          if (document.getElementById(textboxid1).value != "" && document.getElementById(textboxid2).value != "") {
                              var NameWithoutReplace = document.getElementById(textboxid1).value;
                              document.getElementById(textboxid1).value = NameWithoutReplace.replace(/,/g, "");
                              var NameWithoutReplace = document.getElementById(textboxid2).value;
                              document.getElementById(textboxid2).value = NameWithoutReplace.replace(/,/g, "");
                              var amtrnge1 = document.getElementById(textboxid1).value;
                              var amtrnge2 = document.getElementById(textboxid2).value;
                              if (parseFloat(amtrnge2) <= parseFloat(amtrnge1)) {
                                 
                                  Rangeexceed(textboxid1);
                              }

                          }
                      }

                  }
               }
               
           
               addCommas(textboxid);
              // alert("55");
               return true;
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
       
           function AlertClearDedAll()
           {
               if (confirmboxSalryDedctn > 0) {
                   if (confirm("Are you sure you want clear all data in this section?")) {
                       // window.location.href = "gen_Bank_Guarantee.aspx";
                       document.getElementById("<%=ddldedctn.ClientID%>").selectedIndex = "0";
                       document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = "";
                       document.getElementById("<%=txtAmntRedcnTo.ClientID%>").value = "";
                       
                       document.getElementById("<%=txtperctg.ClientID%>").value = "";
                       document.getElementById("<%=txtperctgTo.ClientID%>").value = "";
                       document.getElementById("<%=RestrctstsDed.ClientID%>").checked = false;
                       document.getElementById("<%=RestrctstsDedPerc.ClientID%>").checked = false;

                       document.getElementById("<%=CheckstsDedctn.ClientID%>").checked = true;

                       document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
                       document.getElementById("<%=radPercntge.ClientID%>").checked = true;
                       if (document.getElementById("<%=hiddenRoleAdd.ClientID%>").value == "1") {
                           document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "block";
                            }
                       document.getElementById("<%=UpdateDedctn.ClientID%>").style.display = "none";
                       RadioAmountClick();
                       RadioPerClick();

                       return false;
                   }
                   else {
                       return false;
                   }
               }
               else {
          //window.location.href = "gen_Bank_Guarantee.aspx";
                   document.getElementById("<%=ddldedctn.ClientID%>").selectedIndex = "0";
                   document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = "";
                   document.getElementById("<%=txtAmntRedcnTo.ClientID%>").value = "";

                   document.getElementById("<%=txtperctg.ClientID%>").value = "";
                   document.getElementById("<%=txtperctgTo.ClientID%>").value = "";
                   document.getElementById("<%=RestrctstsDed.ClientID%>").checked = false;
                   document.getElementById("<%=RestrctstsDedPerc.ClientID%>").checked = false;
                   document.getElementById("<%=CheckstsDedctn.ClientID%>").checked = true;

                   document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
                   document.getElementById("<%=radPercntge.ClientID%>").checked = true;
                   if (document.getElementById("<%=hiddenRoleAdd.ClientID%>").value == "1") {
                       document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "block";
                    }
                
                   document.getElementById("<%=UpdateDedctn.ClientID%>").style.display = "none";
                   RadioAmountClick();
                   RadioPerClick();
          return false;
      }
           }

           function ClearDedAll()
           {
               document.getElementById("<%=ddldedctn.ClientID%>").selectedIndex = "0";
               document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = "";
               document.getElementById("<%=txtAmntRedcnTo.ClientID%>").value = "";

               document.getElementById("<%=txtperctg.ClientID%>").value = "";
               document.getElementById("<%=txtperctgTo.ClientID%>").value = "";
               document.getElementById("<%=RestrctstsDed.ClientID%>").checked = false;
               document.getElementById("<%=RestrctstsDedPerc.ClientID%>").checked = false;
               document.getElementById("<%=CheckstsDedctn.ClientID%>").checked = true;

               document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
               document.getElementById("<%=radPercntge.ClientID%>").checked = true;
               RadioAmountClick();

               RadioPerClick();

           }
           function AlertClearAddition() {
               if (confirmboxSalryAllwnce > 0) {
                   if (confirm("Are you sure you want clear all data in this section?")) {
                       // window.location.href = "gen_Bank_Guarantee.aspx";
                       document.getElementById("<%=ddlAddtn.ClientID%>").selectedIndex = "0";
                       document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = "";
                       document.getElementById("<%=txtAmntRgeTo.ClientID%>").value = "";
                       document.getElementById("<%=txtperctgAllw.ClientID%>").value = "";
                       document.getElementById("<%=txtperctgAllwTo.ClientID%>").value = "";
                       
                       document.getElementById("<%=CheckRestrict.ClientID%>").checked = false;
                       document.getElementById("<%=CheckRestrictPerc.ClientID%>").checked = false;
                       document.getElementById("<%=CheckStatsAddtn.ClientID%>").checked = true;
                       if (document.getElementById("<%=hiddenRoleAdd.ClientID%>").value == "1") {
                           document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
                       }
                     //  RadioAmountClickAllow();
                       document.getElementById("<%=RadioPercAllow.ClientID%>").checked = true;
                       document.getElementById("<%=radAmntAllw.ClientID%>").checked = false;
                     //  RadioPerClickAllow();
                       RadioPerClickAllow();
                       //document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
                       document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";
                       return false;
                   }
                   else {
                       return false;
                   }
               }
               else {

                   //window.location.href = "gen_Bank_Guarantee.aspx";
                   document.getElementById("<%=ddlAddtn.ClientID%>").selectedIndex = "0";
                   document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = "";
                   document.getElementById("<%=txtAmntRgeTo.ClientID%>").value = "";
                   document.getElementById("<%=txtperctgAllw.ClientID%>").value = "";
                   document.getElementById("<%=txtperctgAllwTo.ClientID%>").value = "";
                   document.getElementById("<%=CheckRestrict.ClientID%>").checked = false;
                   document.getElementById("<%=CheckRestrictPerc.ClientID%>").checked = false;
                   document.getElementById("<%=CheckStatsAddtn.ClientID%>").checked = true;
                   if (document.getElementById("<%=hiddenRoleAdd.ClientID%>").value == "1") {
                       document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
                   }
                  // RadioAmountClickAllow();

                   document.getElementById("<%=RadioPercAllow.ClientID%>").checked = true;
                   document.getElementById("<%=radAmntAllw.ClientID%>").checked = false;
                   RadioPerClickAllow();
                   document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";
                   return false;
               }
           }
           
           function ClearAddition()
           {
               document.getElementById("<%=ddlAddtn.ClientID%>").selectedIndex = "0";
               document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = "";
               document.getElementById("<%=txtAmntRgeTo.ClientID%>").value = "";
               document.getElementById("<%=txtperctgAllw.ClientID%>").value = "";
               document.getElementById("<%=txtperctgAllwTo.ClientID%>").value = "";
               document.getElementById("<%=CheckRestrict.ClientID%>").checked = false;
               document.getElementById("<%=CheckRestrictPerc.ClientID%>").checked = false;
               document.getElementById("<%=CheckStatsAddtn.ClientID%>").checked = true;
             //  RadioAmountClickAllow();

               document.getElementById("<%=RadioPercAllow.ClientID%>").checked = true;
               document.getElementById("<%=radAmntAllw.ClientID%>").checked = false;
               RadioPerClickAllow();
           }
           function AlertClearAllPaygrd() {
               if (confirmbox > 0) {
                   if (confirm("Are you sure you want clear all data in this section?")) {
                       // window.location.href = "gen_Bank_Guarantee.aspx";
                       document.getElementById("<%=ddlcurrncy.ClientID%>").selectedIndex = "0";
                       
                       document.getElementById("<%=txtName.ClientID%>").value = "";
                       document.getElementById("<%=txtBasicpayFrm.ClientID%>").value = "";
                       document.getElementById("<%=txtBasicpayTo.ClientID%>").value = "";
                       document.getElementById("<%=cbxRestrictPaygrd.ClientID%>").checked = false;
                       document.getElementById("<%=cbxStatus.ClientID%>").checked = true;

                       return false;
                   }
                   else {
                       return false;
                   }
               }
               else {
                   //window.location.href = "gen_Bank_Guarantee.aspx";
                   document.getElementById("<%=ddlcurrncy.ClientID%>").selectedIndex = "0";

                   document.getElementById("<%=txtName.ClientID%>").value = "";
                   document.getElementById("<%=txtBasicpayFrm.ClientID%>").value = "";
                   document.getElementById("<%=txtBasicpayTo.ClientID%>").value = "";
                   document.getElementById("<%=cbxRestrictPaygrd.ClientID%>").checked = true;
                   document.getElementById("<%=cbxStatus.ClientID%>").checked = true;


                   return false;
               }
           }

           function ClearAllPaygrd()

           {
               document.getElementById("<%=ddlcurrncy.ClientID%>").selectedIndex = "0";

               document.getElementById("<%=txtName.ClientID%>").value = "";
               document.getElementById("<%=txtBasicpayFrm.ClientID%>").value = "";
               document.getElementById("<%=txtBasicpayTo.ClientID%>").value = "";
               document.getElementById("<%=cbxRestrictPaygrd.ClientID%>").checked = false;
               document.getElementById("<%=cbxStatus.ClientID%>").checked = true;

           }

           function ConfirmMessage() {
               if (confirmbox > 0) {
                   if (confirm("Are you sure you want to leave this page?")) {
                       window.location.href = "gen_Pay_Grade_Master_List.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Pay_Grade_Master_List.aspx";

               }
           }
           function LoadListPageallwnce()
           {
              

         
               var EnableCanl = document.getElementById("<%=HiddnEnableCacel.ClientID%>").value;
               var CurrcyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
               var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
               var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
               var PaygrdId = document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value; 
               var RoleUpdate = document.getElementById("<%=hiddenRoleUpdate.ClientID%>").value;
               var View = document.getElementById("<%=HiddenView.ClientID%>").value;
               
               var Details = PageMethods.LoadListPageallwnce(EnableCanl, CurrcyId, CorpId, OrgId,PaygrdId,RoleUpdate,View, function (response) {
                
                   // alert(response);
                // reporttable();
                
                   document.getElementById('cphMain_divReport').innerHTML = response.strhtml;
                   document.getElementById("<%=HiddenTotalPerBasicAloww.ClientID%>").value = response.strPerFromBasicAllw;
                   //$p("#ReportTableAllw").DataTable({
                   //    "pagingType": "full_numbers",
                   //    "bSort": true,
                   //    "pageLength": 25,
                   //    "bDestroy": true
                   //});
                   if (response.strSummry != "") {
                       var n,n1;
                       var num = response.strSummry;
                       var sumry = num.split("-");
                       var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

                       if (FloatingValue != "") {
                           if (sumry[0] != "" && sumry[0] != undefined)
                               sumry[0] = sumry[0].replace(/,/g, "");
                           else
                               sumry[0] = 0;
                           if (sumry[1] != "" && sumry[1] != undefined)
                               sumry[1] = sumry[1].replace(/,/g, "");
                           else
                               sumry[1] = 0;
                           n = parseFloat(sumry[0]).toFixed(FloatingValue);
                           
                        
                           addCommasSummry(n);
                           n = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                           n1 = parseFloat(sumry[1]).toFixed(FloatingValue);
                          
                           addCommasSummry(n1);
                           n1 = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                          
                           n = n + "-" +n1;
                           document.getElementById("<%=HiddenAdditionRange.ClientID%>").value = n

                           if (response.strPerFromBasicAllw != 0 ) {
                               
                             //  PerctgeCalcAllow();
                           }
                       }
                       document.getElementById('SumryAdtnRng').innerHTML = n + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
                       // document.getElementById('SumryAdtnRng').innerHTML = response.strSummry + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
                       if (response.strPerFromBasicAllw != 0) {

                           PerctgeCalcAllow();
                       }
                    }
                    else {
                       document.getElementById('SumryAdtnRng').innerHTML = response.strSummry;
                    }
                   $p("#ReportTableAllw").DataTable({
                       "pagingType": "full_numbers",
                       "bSort": true,
                       "pageLength": 25,
                       "bDestroy": true
                   });
                
                  
               });

           
              

             
           }
           function LoadListPageDed() {
             
               var EnableCanl = document.getElementById("<%=HiddnEnableCacel.ClientID%>").value;
               var CurrcyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
               var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
               var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
               var PaygrdId = document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value;
               var RoleUpdate = document.getElementById("<%=hiddenRoleUpdate.ClientID%>").value;
               var View = document.getElementById("<%=HiddenView.ClientID%>").value;
               var Details = PageMethods.LoadListPageDed(EnableCanl, CurrcyId, CorpId, OrgId,PaygrdId,RoleUpdate,View,  function (response) {

                   // alert(response);
                // reporttables();
                //  reporttable();
                   
                   document.getElementById('cphMain_divList').innerHTML = response.strhtml;
                   //$p("#ReportTableDed").DataTable({
                   //    "pagingType": "full_numbers",
                   //    "bSort": true,
                   //    "pageLength": 25,
                   //    "bDestroy": true
                   //});
                   document.getElementById("<%=HiddenTotalPerTotal.ClientID%>").value = response.strPerFromTotal;
                   document.getElementById("<%=HiddenTotalPerBasic.ClientID%>").value = response.strPerFromBasic;

                   if (response.strSummry != "") {
                       var n, n1;
                       var num = response.strSummry;
                       var sumry = num.split("-");
                       var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

                       if (FloatingValue != "") {
                           if (sumry[0] != "" && sumry[0] != undefined)
                               sumry[0] = sumry[0].replace(/,/g, "");
                           else
                               sumry[0] = 0;
                           if (sumry[1] != "" && sumry[1] != undefined)
                               sumry[1] = sumry[1].replace(/,/g, "");
                           else
                               sumry[1] = 0;
                           n = parseFloat(sumry[0]).toFixed(FloatingValue);
                           addCommasSummry(n);
                           n = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                           n1 = parseFloat(sumry[1]).toFixed(FloatingValue);
                           addCommasSummry(n1);
                           n1 = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                         
                           n = n + "-" + n1;
                          
                           
                           document.getElementById("<%=HiddenDedctnRng.ClientID%>").value = n;
                      
                           if (response.strPerFromBasic != 0 || response.strPerFromBasic != 0) {
                              
                               PerctgeCalc();
                           }
                       }
                     
                       document.getElementById('SumryDedctnRng').innerHTML = n + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;

                       if (response.strPerFromTotal != 0 || response.strPerFromBasic != 0) {
                          
                           PerctgeCalc();
                       }
                  
                       //document.getElementById('SumryDedctnRng').innerHTML = n+ "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
                   }
                   else {
                       document.getElementById('SumryDedctnRng').innerHTML = response.strSummry;
                   }

                

                   $p("#ReportTableDed").DataTable({
                       "pagingType": "full_numbers",
                       "bSort": true,
                       "pageLength": 25,
                       "bDestroy": true
                   });
                
               });
            
           }
           function PerctgeCalcAllow()
           {
               var Amntrng = document.getElementById("<%=HiddenBasicForPer.ClientID%>").value;

               var Amntrngarr = Amntrng.split("-");
             
               Amntrngarr[0] = Amntrngarr[0].replace(/,/g, "");

               Amntrngarr[1] = Amntrngarr[1].replace(/,/g, "");
               var basicpayfrm = parseFloat(Amntrngarr[0]);
               var basicpayto = parseFloat(Amntrngarr[1]);

              
               var FloatingValue = parseFloat(document.getElementById("<%=hiddenDecimalCount.ClientID%>").value);
               if (FloatingValue != "") {
                   //Amntrngarr[0] = parseFloat(Amntrngarr[0]).toFixed(FloatingValue);
                   //  varAmntrngarr[0]=
               }

              
               var PerBasic = parseFloat(document.getElementById("<%=HiddenTotalPerBasicAloww.ClientID%>").value);

               var dedctn = document.getElementById("<%=HiddenAdditionRange.ClientID%>").value;
               dedctn = dedctn.split("-");
               var dedctnfrm = dedctn[0].replace(/,/g, "");
               var dedctnTo = dedctn[1].replace(/,/g, "");


           
               if (PerBasic != 0) {
               
                   var BasicFrm = parseFloat(basicpayfrm) / 100;
                  
                   BasicFrm = BasicFrm * PerBasic;
                  
                   var BasicTo = parseFloat(basicpayto) / 100;

                   BasicTo = BasicTo * PerBasic;
                   
                   dedctnfrm = parseFloat(BasicFrm) + parseFloat(dedctnfrm);
                  
                   dedctnTo = parseFloat(BasicTo) + parseFloat(dedctnTo);

                  

               }
             
               if (FloatingValue != "") {
                   dedctnfrm = parseFloat(dedctnfrm).toFixed(FloatingValue);
               }
               addCommasSummry(dedctnfrm);
               dedctnfrm = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
              if (FloatingValue != "") {
                  dedctnTo = parseFloat(dedctnTo).toFixed(FloatingValue);
              }
              addCommasSummry(dedctnTo);
              dedctnTo = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
             //  alert(dedctnfrm + "t");
               var Finaldedcn = dedctnfrm + "-" + dedctnTo;
               document.getElementById("<%=HiddenAdditionRange.ClientID%>").value = Finaldedcn + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
               document.getElementById('SumryAdtnRng').innerHTML = Finaldedcn + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
       
           }
           function PerctgeCalc()
           {
               
               var Amntrng = document.getElementById("<%=HiddenBasicForPer.ClientID%>").value;
             
               var Amntrngarr = Amntrng.split("-");
            //   alert(Amntrngarr);
            //   var varAmntrngarr = Amntrngarr.split(" ");

              // Amntrngarr[0] = Amntrngarr[0].replace(/,/g, "");

               //var basicpayfrm=  parseFloat(Amntrngarr[0]);
             //  alert(Amntrngarr[0]);
               Amntrngarr[0] = Amntrngarr[0].replace(/,/g, "");
          
               Amntrngarr[1] = Amntrngarr[1].replace(/,/g, "");
               var basicpayfrm = parseFloat(Amntrngarr[0]);
               var basicpayto = parseFloat(Amntrngarr[1]);

             var addtnrng = document.getElementById("<%=HiddenAdditionRange.ClientID%>").value;
               //alert(addtnrng+"addtn");
               addtnrng = addtnrng.split("-");
               addtnrng[0] = addtnrng[0].replace(/,/g, "");

               var addtnrangeFrm = parseFloat(addtnrng[0]);
               addtnrng[1] = addtnrng[1].replace(/,/g, "");

               var addtnrangeTo = parseFloat(addtnrng[1]);
               var FloatingValue = parseFloat(document.getElementById("<%=hiddenDecimalCount.ClientID%>").value);
               if (FloatingValue != "")
               {
//Amntrngarr[0] = parseFloat(Amntrngarr[0]).toFixed(FloatingValue);
                 //  varAmntrngarr[0]=
               }

               var PerTotal = parseFloat(document.getElementById("<%=HiddenTotalPerTotal.ClientID%>").value);
               var PerBasic = parseFloat(document.getElementById("<%=HiddenTotalPerBasic.ClientID%>").value);

               var dedctn = document.getElementById("<%=HiddenDedctnRng.ClientID%>").value;
               dedctn = dedctn.split("-");
              var dedctnfrm = dedctn[0].replace(/,/g, "");
             var  dedctnTo = dedctn[1].replace(/,/g, "");
         

               if (PerTotal != 0) {
                   var totalFrom = basicpayfrm + addtnrangeFrm;
                   totalFrom = parseFloat(totalFrom) / 100;

                   totalFrom = totalFrom * PerTotal;
                //   alert(totalFrom+"totalfrom")
                   var totalTo = basicpayto + addtnrangeTo;
                   totalTo = parseFloat(totalTo) / 100;
                   totalTo = totalTo * PerTotal;
                 //  totalpercentage = parseFloat(totalpercentage) + PerTotal;
                   dedctnfrm = parseFloat(dedctnfrm) +parseFloat( totalFrom);
                   //alert(dedctnfrm+"dedctnFrmmm")
                   dedctnTo = parseFloat(dedctnTo) + parseFloat(totalTo);
                 
               }
               if (PerBasic != 0) {
                   var BasicFrm = parseFloat(basicpayfrm) / 100;
                   BasicFrm = BasicFrm * PerBasic;
                   var BasicTo = parseFloat(basicpayto) / 100;

                   BasicTo = BasicTo * PerBasic;

                   dedctnfrm = parseFloat(BasicFrm) + parseFloat(dedctnfrm);
                   dedctnTo = parseFloat(BasicTo) + parseFloat(dedctnTo);
               
                  // Finaltotalpay = parseFloat(basicpay) - PerBasic;
                 //  totalpercentage = parseFloat(totalpercentage) + PerBasic;

               }
             // alert(dedctnfrm + "frm")
             // alert(dedctnTo + "To")
              if (FloatingValue != "") {
                  dedctnfrm = parseFloat(dedctnfrm).toFixed(FloatingValue);
              }
              addCommasSummry(dedctnfrm);
              dedctnfrm = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
               if (FloatingValue != "") {
                   dedctnTo = parseFloat(dedctnTo).toFixed(FloatingValue);
               }
               addCommasSummry(dedctnTo);
               dedctnTo = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
              //  alert(dedctnfrm + "frm")
               // alert(dedctnTo + "To")
              var Finaldedcn = dedctnfrm + "-" + dedctnTo;
              document.getElementById('SumryDedctnRng').innerHTML = Finaldedcn + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
             
           }
           function ChangeStatus(CatId, CatStatus, AllwOrDed) {
              
               if (confirm("Do you want to change the status of this entry?")) {
                   //  var SearchString = document.getElementById("<%=HiddnEnableCacel.ClientID%>").value;
                // reporttable();
                   
                   var Details = PageMethods.ChangeContractStatus(CatId, CatStatus,AllwOrDed, function (response) {
                     var SucessDetails = response;
                    
                     if (SucessDetails == "success") {
                         // window.location = 'gen_Pay_Grade_Master.aspx?InsUpd=StsCh';
                         //reporttable();
                         if (AllwOrDed == 0) {
                             SuccessChangeAllowceStatus();
                         }
                         if (AllwOrDed == 1) {
                             SuccessChangeDedctnStatus();
                         }
                         //LoadListPageallwnce();
                         // LoadListPageDed();
                    

                     }
                     else {
                        // window.location = 'gen_Pay_Grade_Master_List.aspx?InsUpd=Error';
                     }
                 });
             }
             else {
                 return false;
             }
         }
           function getdetailsAllwceById(x) {

              
               
               var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
               var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
               var Details = PageMethods.ReadAllwceById(x, CorpId, OrgId, function (response) {
                  

                   if (response.PerOrAmntck == 1) {
                       addCommasSummry(response.strPerctgeamn);
                       document.getElementById("<%=txtperctgAllw.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                       document.getElementById("<%=HiddenEditPerctg.ClientID%>").value = response.strPerctgeamn;

                       addCommasSummry(response.strPerctgeamnTo);
                       document.getElementById("<%=txtperctgAllwTo.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                       document.getElementById("<%=HiddenEditPerctgTo.ClientID%>").value = response.strPerctgeamnTo;

                       document.getElementById("<%=RadioPercAllow.ClientID%>").checked = true;
                       document.getElementById("<%=radAmntAllw.ClientID%>").checked = false;
                       RadioPerClickAllow();
                        }
                   else {
                       document.getElementById("<%=HiddenEditPerctg.ClientID%>").value = "0";
                       document.getElementById("<%=HiddenEditPerctgTo.ClientID%>").value = "0";
                       var n = response.FrmAmount;
                       var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                       if (FloatingValue != "") {
                           n = n.toFixed(FloatingValue);
                       }
                           addCommasSummry(n);
                           document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;

                       var a = response.Toamount;
                       var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                          if (FloatingValue != "") {
                              a = a.toFixed(FloatingValue);
                          }
                       addCommasSummry(a);
                       document.getElementById("<%=txtAmntRgeTo.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                            document.getElementById("<%=radAmntAllw.ClientID%>").checked = true;
                            document.getElementById("<%=RadioPercAllow.ClientID%>").checked = false;
                       RadioAmountClickAllow();
                        }
                   document.getElementById("<%=ddlAddtn.ClientID%>").value = response.ddlselectedVal;
                   document.getElementById("<%=Hiddendddlallwce.ClientID%>").value = response.ddlselectedVal;
                   if (response.ddlBinding == 0) {
                       document.getElementById("<%=ddlAddtn.ClientID%>").value = response.ddlselectedVal;
                      }
                   else if (response.ddlBinding == 1) {
                       var $Mo = jQuery.noConflict();
                       var newOption = "<option value='" + response.ddlselectedVal + "'>" + response.ddltext + "</option>";
                    
                       $Mo('#<%=ddlAddtn.ClientID%>').append(newOption);
                       //SORTING DDL
                      var options = $Mo("#<%=ddlAddtn.ClientID%> option");                    // Collect options         
                       options.detach().sort(function (a, b) {               // Detach from select, then Sort
                           var at = $Mo(a).text();
                           var bt = $Mo(b).text();
                           return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                       });
                       options.appendTo('#<%=ddlAddtn.ClientID%>');
                      document.getElementById("<%=ddlAddtn.ClientID%>").value = response.ddlselectedVal;

                      }
                   // document.getElementById("<%=ddlAddtn.ClientID%>").value = response.ddlselectedVal
                   if (response.RestrctSts == 1) {
                       document.getElementById("<%=CheckRestrict.ClientID%>").checked = true;
                   }
                   else {
                       document.getElementById("<%=CheckRestrict.ClientID%>").checked = false;
                   }

                   if (response.RestrctStsPerc == 1) {
                       document.getElementById("<%=CheckRestrictPerc.ClientID%>").checked = true;
                      }
                    else {
                         document.getElementById("<%=CheckRestrictPerc.ClientID%>").checked = false;
                     }

                   if (response.sts == 1) {
                       document.getElementById("<%=CheckStatsAddtn.ClientID%>").checked = true;
                   }
                   else {
                       document.getElementById("<%=CheckStatsAddtn.ClientID%>").checked = false;

                   }
                 //  alert(response.AllowceId);
                  // document.getElementById("<%=HiddenAllownceId.ClientID%>").value = "";
                   document.getElementById("<%=HiddenAllownceId.ClientID%>").value = response.AllowceId;
                   document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = response.PaygrdId;
                   document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "none";
                   document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "block";
                   
                   
               });


            //   $('body, html, #div2').scrollTop(0);


               document.getElementById("<%=ddlAddtn.ClientID%>").focus();

               return false;
           }
          function getdetailsDedctnById(x)
           {
            
              var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
              var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
              var Details = PageMethods.ReadDedctnId(x, CorpId, OrgId, function (response) {

                 
                  document.getElementById("<%=Hiddenddldedctn.ClientID%>").value = response.ddlselectedVal;
                  if (response.ddlBinding == 0) {
                      document.getElementById("<%=ddldedctn.ClientID%>").value = response.ddlselectedVal;
                  }
                  else if (response.ddlBinding == 1) {
                      //var $coo = jQuery.noConflict();
                      //var option = $coo("<option>" + response.ddltext + "</option>");
                      //option.attr("value", response.ddlselectedVal);
                      //ddldedctn.append(option);
                      //dynamic adding in drpdown
                      var $Mo = jQuery.noConflict();
                      var newOption = "<option value='" + response.ddlselectedVal + "'>" + response.ddltext + "</option>";
                  
                      $Mo('#<%=ddldedctn.ClientID%>').append(newOption);
                      //SORTING DDL
                      var options = $Mo("#<%=ddldedctn.ClientID%> option");                    // Collect options         
                      options.detach().sort(function (a, b) {               // Detach from select, then Sort
                          var at = $Mo(a).text();
                          var bt = $Mo(b).text();
                          return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                      });
                      options.appendTo('#<%=ddldedctn.ClientID%>');
                      document.getElementById("<%=ddldedctn.ClientID%>").value = response.ddlselectedVal;

                  }
                  // document.getElementById("<%=ddlAddtn.ClientID%>").value = response.ddlselectedVal
                 
                   if (response.RestrctSts == 1) {
                       document.getElementById("<%=RestrctstsDed.ClientID%>").checked = true;
                   }
                   else {
                       document.getElementById("<%=RestrctstsDed.ClientID%>").checked = false;
                   }

                  if (response.RestrctStsPerc == 1) {
                      document.getElementById("<%=RestrctstsDedPerc.ClientID%>").checked = true;
                        }
                     else {
                             document.getElementById("<%=RestrctstsDedPerc.ClientID%>").checked = false;
                       }


                   if (response.sts == 1) {
                       document.getElementById("<%=CheckstsDedctn.ClientID%>").checked = true;
                   }
                   else {
                       document.getElementById("<%=CheckstsDedctn.ClientID%>").checked = false;

                   }
                  if (response.BasicOrTotl == 1)
                  {
                      
                      document.getElementById("<%=radioBascPay.ClientID%>").checked = false;
                      document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
                  }
                  else
                  {
                      document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = false;
                      document.getElementById("<%=radioBascPay.ClientID%>").checked = true;
                  }
                  if (response.PerOrAmntck == 1) {
                      addCommasSummry(response.strPerctgeamn);
                      document.getElementById("<%=txtperctg.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                      document.getElementById("<%=HiddenEditPerctg.ClientID%>").value = response.strPerctgeamn;
                      
                      addCommasSummry(response.strPerctgeamnTo);
                      document.getElementById("<%=txtperctgTo.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                      document.getElementById("<%=HiddenEditPerctgTo.ClientID%>").value = response.strPerctgeamnTo;
                      

                      document.getElementById("<%=radPercntge.ClientID%>").checked = true;
                      document.getElementById("<%=radAmnt.ClientID%>").checked = false;
                      RadioPerClick();
                  }
                  else {
                      document.getElementById("<%=HiddenEditPerctg.ClientID%>").value = "0";
                      document.getElementById("<%=HiddenEditPerctgTo.ClientID%>").value = "0";
                      var n = response.FrmAmount;
                      var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                       if (FloatingValue != "") {
                           n = n.toFixed(FloatingValue);
                       }
                       addCommasSummry(n);
                    
                       document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;

                      var a = response.Toamount;
                      var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                            if (FloatingValue != "") {
                                a = a.toFixed(FloatingValue);
                            }
                            addCommasSummry(a);

                            document.getElementById("<%=txtAmntRedcnTo.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                      document.getElementById("<%=radAmnt.ClientID%>").checked = true;
                      document.getElementById("<%=radPercntge.ClientID%>").checked = false;
                      RadioAmountClick();
                  }
                  document.getElementById("<%=HiddenDedctnId.ClientID%>").value = response.DedctnId;
                   document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = response.PaygrdId;
                   document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "none";
                   document.getElementById("<%=UpdateDedctn.ClientID%>").style.display = "block";


              });

              //var p = $("p:first");


             // $('body, html, #div2').scrollTop(0);
              document.getElementById("<%=ddldedctn.ClientID%>").focus();



               return false;

           }
           function CancelAlertAllwceById(x, AllwOrDed)
           {
               if (confirm("Do you want to cancel this entry?")) {
                  
                   document.getElementById("<%=HiddenDelChk.ClientID%>").value = AllwOrDed;
                   document.getElementById("<%=hiddenRsnid.ClientID%>").value = x;
                   var userId= document.getElementById("<%=HiddenUserId.ClientID%>").value;
                   var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                   var Details = PageMethods.CancelAlertAllwceById(x, userId, CorpId, AllwOrDed, function (response) {
                      
                   

                       if (response == 1) {
                           OpenCancelView();
                       }
                       else {
                           if (AllwOrDed == 1)
                           {
                               SuccessCancelationDedctn();
                           }
                           else if (AllwOrDed==0)
                           {
                               SuccessCancelationAllwnce();
                           }
                          
                       }
                       LoadListPageallwnce();
                       LoadListPageDed();

                   });
                   return false;
               }
               else {
                   return false;
               }

           }
           function dddedctnchange()
           {
               IncrmntConfrmCounterSalryDedctn();
               var ddldedctnval = document.getElementById("<%=ddldedctn.ClientID%>").value;
              
               if (ddldedctnval != "--SELECT SALARY DEDUCTION--") {
                   document.getElementById("<%=Hiddenddldedctn.ClientID%>").value = ddldedctnval;
               }
           }
           function ddlAllwncechange() {
               IncrmntConfrmCounterSalryAllwnce();
               var ddldedctnval = document.getElementById("<%=ddlAddtn.ClientID%>").value;
              
               if (ddldedctnval != "--SELECT SALARY ADDITION--") {
                   document.getElementById("<%=Hiddendddlallwce.ClientID%>").value = ddldedctnval;
                 //  document.getElementById("<%=HiddenAllownceId.ClientID%>").value = ddldedctnval;
                 
               }
             
           }
           function currcyabbrvLoad()
           {
               
               IncrmntConfrmCounter();
               var ddlAddtnValue = document.getElementById("<%=ddlcurrncy.ClientID%>").value;
              
               if (ddlAddtnValue != "--SELECT CURRENCY--") {

                   var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
                   var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                   var currcAbbrv = "";

                   var Details = PageMethods.LoadCurrcyAbbrv(ddlAddtnValue, CorpId, OrgId, function (response) {
                      
                       currcAbbrv = response;

                       document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value = currcAbbrv;
                     
                   });
               }
               
           }


            </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
     <asp:HiddenField ID="HiddenEditPerctg" runat="server" />
     <asp:HiddenField ID="HiddenEditPerctgTo" runat="server" />
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>
    
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    
      <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    
     <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
     <asp:HiddenField ID="HiddenPayGrdeId" runat="server" />
      <asp:HiddenField ID="HiddnEnableCacel" runat="server" />

     <asp:HiddenField ID="HiddenOrgId" runat="server" />
     <asp:HiddenField ID="HiddenCorpId" runat="server" />
      <asp:HiddenField ID="HiddenAllownceId" runat="server" />
    <asp:HiddenField ID="HiddenUserId" runat="server" />
     <asp:HiddenField ID="HiddenDelChk" runat="server" />
     <asp:HiddenField ID="HiddenDedctnId" runat="server" />
         <asp:HiddenField ID="HiddenAmountRnge" runat="server" />
    <asp:HiddenField ID="HiddenAmountRngeChk" runat="server" />
    <asp:HiddenField ID="HiddenSalaryAbbrv" runat="server" />
        <asp:HiddenField ID="HiddenEdtOrViw" runat="server" />
     <asp:HiddenField ID="Hiddenreturnfun" runat="server" />
         <asp:HiddenField ID="hiddenRoleUpdate" runat="server" />
     <asp:HiddenField ID="HiddenTotalPerTotal" runat="server" />
    <asp:HiddenField ID="HiddenTotalPerBasic" runat="server" />
      <asp:HiddenField ID="HiddenAdditionRange" runat="server" />
      <asp:HiddenField ID="HiddenBasicRnge" runat="server" />
     <asp:HiddenField ID="HiddenDedctnRng" runat="server" />
      <asp:HiddenField ID="HiddenBasicForPer" runat="server" />
     <asp:HiddenField ID="HiddenView" runat="server" />
       <asp:HiddenField ID="Hiddenddldedctn" runat="server" />
       <asp:HiddenField ID="Hiddendddlallwce" runat="server" />
     <asp:HiddenField ID="HiddenTotalPerTotalAllow" runat="server" />
      <asp:HiddenField ID="HiddenTotalPerBasicAloww" runat="server" />
    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
  
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
     <div id="div5" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 22%; height: 26.5px;">


        </div>

    <div class="cont_rght">

        
    <%--    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
           <%-- <img src="/Images/BigIcons/Contract_Master48x48.png" style="vertical-align: middle;" />
            Add Pay Grade
        </div >--%>
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 99.5%;margin-top:1%;">

         <div id="DivPaygrd" style="float:left;width:96%;margin-left: 1%;margin-top: 1%;border: 1px solid;padding: 10px;">
             <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
                        <div id="divContactPersn" class="eachform" style="width: 99%; float: left;margin-top: 1%;">

                            <h2 style="margin-left: 20%;">Name*</h2>
                                                         
                                    <asp:TextBox ID="txtName" onkeydown="return DisableEnter(event)" class="form1" runat="server" MaxLength="45"  Style="float: left; width: 26.7% !important; margin-left: 17.8%; text-transform: uppercase;"></asp:TextBox>
                                                            
                                                         
                                                </div>

              <div class="eachform" style="width: 77%;margin-top:1%;float: left;">
                  <h2 style="margin-top:1%;width: 14%;margin-left: 25.5%;">Basic Pay Range *</h2>
                    <asp:TextBox ID="txtBasicpayFrm"  class="form1" runat="server" MaxLength="12" Style="width: 14.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 14.7%;" onkeydown="return isNumber(event,'cphMain_txtBasicpayFrm');" onkeyup="addCommas('cphMain_txtBasicpayFrm')" onblur="return AmountChecking('cphMain_txtBasicpayFrm','cphMain_txtBasicpayFrm','cphMain_txtBasicpayTo');"></asp:TextBox>
                   <h2 style="margin-left: 1%;float: left;">To</h2>
                  <asp:TextBox ID="txtBasicpayTo"  class="form1" runat="server" MaxLength="12" Style="width: 14.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 1%;" onkeydown="return isNumber(event,'cphMain_txtBasicpayTo');" onkeyup="addCommas('cphMain_txtBasicpayTo')" onblur="return AmountChecking('cphMain_txtBasicpayTo','cphMain_txtBasicpayFrm','cphMain_txtBasicpayTo');"></asp:TextBox>
                </div>
           
        <div id="Divcurrncy" class="eachform" style="width: 77%;margin-top:1%;">

                <h2 style="margin-top:1%;width: 8%;margin-left: 25.5%;">Currency*</h2>

                <asp:DropDownList ID="ddlcurrncy" onchange="currcyabbrvLoad()" class="form1" runat="server" Style="height:30px;width:36.6%;float:left; margin-left: 20.7%;">
                   
                </asp:DropDownList>


            </div>

               <%-- <div class="eachform"  style="width:57%;padding-top: 2%;">--%>
                  <%--<h2>Status*</h2>--%>
                <div class="subform" style=" float: left;margin-left: 41.5%;width: 8%;">


                    <asp:CheckBox ID="cbxStatus" Text="" runat="server" onkeydown="return DisableEnter(event)" Checked="true" class="form2" />
                    <h3>Active</h3>

                </div>
                   <div class="subform" style="margin-right: 7%; float: left;margin-left: 7.8%;width: 15%; ">


                    <asp:CheckBox ID="cbxRestrictPaygrd" Text="" runat="server" onkeydown="return DisableEnter(event)" Checked="true" class="form2" />
                    <h3>Restrict The Range</h3>

                </div>
                

           <%-- </div>    --%>
             
                <div class="eachform" style="width: 21%;  float: right;margin-top: -12%;">
                    <div class="subform" style="width: 58%; margin-left: 38%;padding: 2%;border: 2px solid rgb(207, 204, 204);">

                       <%-- <asp:Button ID="btnConfirm" TabIndex="24" runat="server" class="save" Text="Confirm"  OnClientClick="return ConfirmAlert();"/>--%>
                     <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" style="width: 95%;" OnClientClick="return ValidatePayGrade();"  OnClick="btnUpdate_Click"  />
                    <asp:Button ID="btnUpdateClose" style="width: 95%;" runat="server" class="save" Text="Update & Close" OnClientClick="return ValidatePayGrade();" OnClick="btnUpdate_Click"    />
                    <asp:Button ID="btnAdd"  runat="server"  class="save" style="width: 95%;" Text="Save" OnClientClick="return ValidatePayGrade();" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnAddClose"  runat="server" style="width: 95%;" class="save" Text="Save & Close" OnClientClick="return ValidatePayGrade();" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnCancel"   runat="server" style="width: 95%;margin-left: 1%;" class="cancel" Text="Cancel" OnClientClick="return AlertClearAll();"  />
                     <asp:Button ID="btnClear"  runat="server" style="width: 95%;margin-top: 4%;margin-left: 1%;" OnClientClick="return AlertClearAllPaygrd();"  class="cancel" Text="Clear"/>
                        </div>
                    </div>
             
                
                 </div>

    <%-- NEXT DIV    --%>
            <div id="divAllnce" runat="server" style="float:left;width:97%;border: 2px solid rgb(207, 204, 204);margin-left: 1.3%;margin-top: 3%;font-family: Calibri;">

                <div id="div2" style="margin-top: 1%;padding-left: 1%;font-size: 22px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
           <%-- <img src="/Images/BigIcons/Contract_Master48x48.png" style="vertical-align: middle;" />--%>
            Allowance/Benefits
        </div >
                  <div id="divAddtn" class="eachform" style="width: 99%; float: left;margin-top: 1%;">

                            <h2 style="margin-left: 18.5%;">Salary Addition*</h2>
                                                         
                                    <asp:DropDownList ID="ddlAddtn" class="form1" onchange="ddlAllwncechange()" runat="server" Style="height:30px;width:28.8%;float:left; margin-left: 12.8%;">
                   
                </asp:DropDownList>
                       <div class="eachform" style="width: 26%; float: left; margin-top: 1.5%;/*! height: 130px; */margin-left: 42%;">
                                                              
                            <div style="width:28%;float:left;margin-left: 6%;">
                          <input id="radAmntAllw" type="radio" runat="server"  onchange="RadioAmountClickAllow()"  name="radTypAlw"/>
                                <label style="font-family:Calibri" for="cphMain_radioOpen">Amount</label>
                            </div>

                       
                        
                       <div style="width:33%;float:left;margin-left: 25%;">
                          <input id="RadioPercAllow" type="radio" runat="server"    onchange="RadioPerClickAllow()" name="radTypAlw" />
                                <label style="font-family:Calibri" for="cphMain_radioLimited">Percentage</label>
                            </div>
                    
                </div>
                                                        
                                                         
                                                </div>
                    <div id="divAmtAllow" >

              <div class="eachform" style="width: 98%;margin-top:1%;float: left;">
                  <h2 style="margin-top:1%;width: 11%;margin-left: 18.5%;">Amount Range *</h2>
                    <asp:TextBox ID="txtAmntRgeFrm"  class="form1" runat="server" MaxLength="12" Style="width: 11.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 12%;" onkeydown="return isNumber(event,'cphMain_txtAmntRgeFrm');" onkeyup="addCommas('cphMain_txtAmntRgeFrm')" onblur="AmountChecking('cphMain_txtAmntRgeFrm','cphMain_txtAmntRgeFrm','cphMain_txtAmntRgeTo');"></asp:TextBox>
                   <h2 style="margin-left: 1%;float: left;">To</h2>
                  <asp:TextBox ID="txtAmntRgeTo"  class="form1" runat="server" MaxLength="12" Style="width: 11.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 1%;" onkeydown="return isNumber(event,'cphMain_txtAmntRgeTo');" onkeyup="addCommas('cphMain_txtAmntRgeTo')" onblur="AmountChecking('cphMain_txtAmntRgeTo','cphMain_txtAmntRgeFrm','cphMain_txtAmntRgeTo');"></asp:TextBox>
                </div>
           </div>
                    <div id="divperclkAllow">

                              <div class="eachform" style="width: 98%;margin-top:0%;float: left;border: 2px solid rgb(207, 204, 204);background-color: #edecec;margin-left: .8%;">
                  <h2 style="margin-top:1%;width: 11%;margin-left: 17.5%;">Percentage *</h2>
                    <asp:TextBox ID="txtperctgAllw"  class="form1" runat="server" MaxLength="5" Style="margin-top: .5%;width: 11.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 12%;" onkeydown="return isNumber(event,'cphMain_txtperctgAllw');" onkeyup="addCommas('cphMain_txtperctgAllw')" onblur="AmountChecking('cphMain_txtperctgAllw','cphMain_txtperctgAllw','cphMain_txtperctgAllwTo');"></asp:TextBox>
                    <h2 style="margin-left: 1%;float: left;margin-top: .5%;">To</h2>

                    <asp:TextBox ID="txtperctgAllwTo"  class="form1" runat="server" MaxLength="5" Style="margin-top: .5%;width: 11.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 1%;" onkeydown="return isNumber(event,'cphMain_txtperctgAllwTo');" onkeyup="addCommas('cphMain_txtperctgAllwTo')" onblur="AmountChecking('cphMain_txtperctgAllwTo','cphMain_txtperctgAllw','cphMain_txtperctgAllwTo');"></asp:TextBox>

                                       <div class="eachform" style="width: 26%; float: left; margin-top: 1%;/*! height: 130px; */margin-left: 4.5%;">
                                                              
                            <div style="width:30%;float:left;margin-left: 5.8%;">
                          <input id="radioBascPayAllow" type="radio" runat="server"     disabled="disabled" name="radTypeAllw"  />
                                <label style="font-family:Calibri" for="cphMain_radioOpen">Basic Pay</label>
                            </div>
                                                                 
                </div>
                  
                   <div id="AllowRestrPerc" class="subform" style="margin-right: 7%; float: left;margin-left: 40.2%;width: 15%; ">
                    <asp:CheckBox ID="CheckRestrictPerc" Text="" runat="server" onkeydown="return DisableEnter(event)"  class="form2" />
                    <h3>Restrict The Limits</h3>

                </div>



                </div>

                             

                          </div>
                  <%--<h2>Status*</h2>--%>
                <div class="subform" style=" float: left;margin-left: 40.5%;width: 8%;">
                   
                    <asp:CheckBox ID="CheckStatsAddtn" Text="" runat="server" onkeydown="return DisableEnter(event)" Checked="true" class="form2" />
                    <h3>Active</h3>

                </div>
                   <div id="AllowRestr" class="subform" style="margin-right: 7%; float: left;margin-left: 7.8%;width: 15%; ">


                    <asp:CheckBox ID="CheckRestrict" Text="" runat="server" onkeydown="return DisableEnter(event)" Checked="true" class="form2" />
                    <h3>Restrict The Limits</h3>

                </div>
                 <div class="eachform" style="width: 21%;  float: right;margin-top: 0%;">
                    <div class="subform" runat="server" id="divallw" style="width: 58%; margin-left: 37%;padding: 2%;border: 2px solid rgb(207, 204, 204);margin-right: 3%;">
                         
                     <asp:Button ID="UpdateAddtn" runat="server" class="save" style="display:none;width:95%" Text="Update" OnClientClick="return ValidateAllwnce('UpdateAddtn');" OnClick="btnUpdate_Addtn_Click"   />
                     <asp:Button ID="SaveAddtn" style="width:95%" runat="server"  class="save" Text="Save" OnClientClick="return ValidateAllwnce('SaveAddtn');"  OnClick="btnAdd_Addtn_Click" />
                     <asp:Button ID="ClearAddtn"  runat="server" style="margin-left: 2px;width:95%" OnClientClick="return AlertClearAddition();"  class="cancel" Text="Clear"/>
                        </div>
                     </div>
                 <div id="divReport" class="table-responsive" runat="server" style="margin-left: 3.2%;margin-bottom: 1%;overflow: auto;max-height: 150px;margin-top: 2%; font-family: Calibri;font-size:13.5px">
            <br />
          
                   <%--  style="margin-left: 3.2%;margin-bottom: 1%;"--%>
        </div>
                <br /><br /><br />
                </div>

        <%-- NEXT DIV    --%>


                      <div id="divdedcn" runat="server" style="float:left;width:97%;border: 2px solid rgb(207, 204, 204);margin-left: 1.3%;margin-top: 3%;">

                <div id="div1" style="margin-top: 1%;padding-left: 1%;font-size: 22px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
           <%-- <img src="/Images/BigIcons/Contract_Master48x48.png" style="vertical-align: middle;" />--%>
            Deduction
        </div >
                  <div id="div3" class="eachform" style="width: 99%; float: left;margin-top: 1%;">

                            <h2 style="margin-left: 18.3%;">Salary Deduction*</h2>
                                                         
                                    <asp:DropDownList ID="ddldedctn" class="form1" onchange="dddedctnchange()"  runat="server" Style="height:30px;width:28.8%;float:left; margin-left: 11.8%;">
                                        
                   
                </asp:DropDownList>
                        <div class="eachform" style="width: 26%; float: left; margin-top: 1.5%;/*! height: 130px; */margin-left: 42%;">
                                                              
                            <div style="width:28%;float:left;margin-left: 6%;">
                          <input id="radAmnt" type="radio" runat="server"  onchange="RadioAmountClick()" name="radTyp"  />
                                <label style="font-family:Calibri" for="cphMain_radioOpen">Amount</label>
                            </div>

                       
                        
                       <div style="width:33%;float:left;margin-left: 25%;">
                          <input id="radPercntge" type="radio" runat="server"  onchange="RadioPerClick()" name="radTyp" />
                                <label style="font-family:Calibri" for="cphMain_radioLimited">Percentage</label>
                            </div>
                    
                </div>
                                                            
                                                         
                                                </div>
                          <div id="divAmtClk" >

              <div class="eachform" style="width: 98%;margin-top:0%;float: left;">
                  <h2 style="margin-top:1%;width: 11%;margin-left: 18.5%;">Amount Range *</h2>
                    <asp:TextBox ID="txtAmntRedcnFrom"  class="form1" runat="server" MaxLength="12" Style="width: 11.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 12%;" onkeydown="return isNumber(event,'cphMain_txtAmntRedcnFrom');" onkeyup="addCommas('cphMain_txtAmntRedcnFrom')" onblur="AmountChecking('cphMain_txtAmntRedcnFrom','cphMain_txtAmntRedcnFrom','cphMain_txtAmntRedcnTo');"></asp:TextBox>
                   <h2 style="margin-left: 1%;float: left;">To</h2>
                  <asp:TextBox ID="txtAmntRedcnTo"  class="form1" runat="server" MaxLength="12" Style="width: 11.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 1%;" onkeydown="return isNumber(event,'cphMain_txtAmntRedcnTo');" onkeyup="addCommas('cphMain_txtAmntRedcnTo')" onblur="AmountChecking('cphMain_txtAmntRedcnTo','cphMain_txtAmntRedcnFrom','cphMain_txtAmntRedcnTo');"></asp:TextBox>
                </div>
           
 <%--       <div id="Div2" class="eachform" style="width: 98%;margin-top:1%;">

                <h2 style="margin-top:1%;width: 8%;margin-left: 20%;">Currency*</h2>

               


            </div>--%>

               <%-- <div class="eachform"  style="width:57%;padding-top: 2%;">--%>
                  <%--<h2>Status*</h2>--%>
               
                          </div>
                          <div id="divperclk">

                              <div class="eachform" style="width: 98%;margin-top:0%;float: left;border: 2px solid rgb(207, 204, 204);background-color: #edecec;margin-left: .8%;">
                  <h2 style="margin-top:1%;width: 11%;margin-left: 17.5%;">Percentage *</h2>
                    <asp:TextBox ID="txtperctg"  class="form1" runat="server" MaxLength="5" Style="margin-top: .5%;width: 11.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 12%;" onkeydown="return isNumber(event,'cphMain_txtperctg');" onkeyup="addCommas('cphMain_txtperctg')" onblur="AmountChecking('cphMain_txtperctg','cphMain_txtperctg','cphMain_txtperctgTo');"></asp:TextBox>
                      <h2 style="margin-left: 1%;float: left;margin-top: .5%;">To</h2>
                    <asp:TextBox ID="txtperctgTo"  class="form1" runat="server" MaxLength="12" Style="width: 11.2%; text-transform: uppercase;text-align:right;margin-top: .5%;  height: 30px;float: left;margin-left: 1%;" onkeydown="return isNumber(event,'cphMain_txtperctgTo');" onkeyup="addCommas('cphMain_txtperctgTo')" onblur="AmountChecking('cphMain_txtperctgTo','cphMain_txtperctg','cphMain_txtperctgTo');"></asp:TextBox>

                                       <div class="eachform" style="width: 26%; float: left; margin-top: 1%;/*! height: 130px; */margin-left: 3.4%;">
                                                              
                            <div style="width:30%;float:left;margin-left: 5.8%;">
                          <input id="radioBascPay" type="radio" runat="server"  onchange="RadioopenClick()" name="radTypenxt"  />
                                <label style="font-family:Calibri" for="cphMain_radioOpen">Basic Pay</label>
                            </div>

                        
                       <div style="width:39%;float:left;margin-left: 24%;">
                          <input id="radioTotlAmnt" type="radio" runat="server"   onchange="RadioLimitedClick()" name="radTypenxt" />
                                <label style="font-family:Calibri" for="cphMain_radioLimited">Total Amount</label>
                            </div>                      
                </div>

                <div class="subform" id="divRestrctPerc" style="margin-right: 7%; float: left;margin-left: 40.2%;width: 15%; ">


                    <asp:CheckBox ID="RestrctstsDedPerc" Text="" runat="server" onkeydown="return DisableEnter(event)"  class="form2" />
                    <h3>Restrict The Limits</h3>

                </div>
                  
                </div>

                             

                          </div>
                           <div class="subform" style=" float: left;margin-left: 40.5%;width: 8%;">


                    <asp:CheckBox ID="CheckstsDedctn" Text="" runat="server" onkeydown="return DisableEnter(event)" Checked="true" class="form2" />
                    <h3>Active</h3>

                </div>
                   <div class="subform" id="divRestrct" style="margin-right: 7%; float: left;margin-left: 7.8%;width: 15%; ">


                    <asp:CheckBox ID="RestrctstsDed" Text="" runat="server" onkeydown="return DisableEnter(event)" Checked="true" class="form2" />
                    <h3>Restrict The Limits</h3>

                </div>

                            <div class="eachform" style="width: 21%;  float: right;margin-top: 0%;">
                    <div id="divded" runat="server" class="subform" style="width: 58%; margin-left: 37%;padding: 2%;border: 2px solid rgb(207, 204, 204);margin-right: 3%;">
                      
                     <asp:Button ID="UpdateDedctn"  runat="server" class="save" style="display:none;width:95%" Text="Update" OnClientClick="return ValidateDedctn('UpdateDedctn');"  OnClick="btnUpdate_Dedctn_Click" />
                     <asp:Button ID="SaveDedctn" style="width:95%;" runat="server"  class="save" Text="Save" OnClientClick="return ValidateDedctn('SaveDedctn');" OnClick="btnAdd_Dedctn_Click"  />
                     <asp:Button ID="ClearDedctn"  runat="server" style="margin-left: 2px;width:95%;" OnClientClick="return AlertClearDedAll();"  class="cancel" Text="Clear"/>
                        </div>
                     </div>
                 <div id="divList" class="table-responsive" runat="server" style="margin-left: 3.2%;margin-bottom: 1%;float: left;width: 94%;overflow: auto;max-height: 150px;margin-top: 2%; font-family: Calibri;font-size:13.5px">
            <br />
          
        </div>
                </div>
              <div id="divovertime" style="float: left;width: 100%;margin-top: 2%;" runat="server" >
                              
                                </div>
              <div id="DivSalrysumry" class="eachform" style="float:left;width:97%;border: 2px solid rgb(207, 204, 204);margin-left: 1.3%;margin-top: 3%;">
                          <div id="div4"  style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
         <h3 style="padding-left: 1%;font-size: 23px;margin-top: 1%"> Salary Summary </h3>   
                              <div style="padding:5%">
                               <h2 style="">Basic Pay Range </h2>   <h2 id="SumryPayRng" style="margin-left: 9.5%;"> </h2> <br />
                               <h2 style="">Addition Range </h2>   <h2 id="SumryAdtnRng" style="margin-left: 9.8%;"></h2> <br />
                               <h2 style="">Deduction Range </h2>     <h2 id="SumryDedctnRng" style="margin-left: 8.6%;" ></h2>  <br />
                                  </div>
        </div >
                  </div>
            <%-- <div class="eachform" style="width: 99%; margin-top: 3%; float: left">
                    <div class="subform" style="width: 58%; margin-left: 38%">--%>
                 
                       <%-- <asp:Button ID="btnConfirm" TabIndex="24" runat="server" class="save" Text="Confirm"  OnClientClick="return ConfirmAlert();"/>--%>
                   <%--  <asp:Button ID="btnPayupdt"  runat="server" class="save" Text="Update" OnClientClick="return ValidatePayGrade();"  OnClick="btnUpdate_Click"  />
                    <asp:Button ID="btnPayupdtclose"  runat="server" class="save" Text="Update & Close" OnClientClick="return ValidatePayGrade();" OnClick="btnUpdate_Click"    />
                    <asp:Button ID="btnPaySave"  runat="server"  class="save" Text="Save" OnClientClick="return ValidatePayGrade();" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnPaySveClose"  runat="server" class="save" Text="Save & Close" OnClientClick="return ValidatePayGrade();" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnPayCancl"   runat="server" class="cancel" Text="Cancel" PostBackUrl="gen_Pay_Grade_Master_List.aspx"  />
                     <asp:Button ID="btnPayClr"  runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAllPaygrd();"  class="cancel" Text="Clear"/>--%>
                     <%--   </div>
                    </div>--%>
            <br style="clear: both" />
            </div>
        <br />

      <%--  <div onclick="location.href='gen_Notification_Template.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;">--%>

          <%--  <a href="gen_Projects.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
       <%-- </div>--%>
        <%--  <br />
        <br />--%>
       
         <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
         <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
    </div>
        <div id="divtile" runat="server" style="display: none"></div>
                                 <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Pay Grade</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 24%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;"  onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="return CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
    </div>
     <style>

        .dataTables_wrapper .dataTables_filter {
    float: right;
    text-align: right;
    margin-bottom: .5%;
}
    </style>
</asp:Content>



