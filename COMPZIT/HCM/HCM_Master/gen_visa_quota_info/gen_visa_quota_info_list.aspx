<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" CodeFile="gen_visa_quota_info_list.aspx.cs" Inherits="HCM_HCM_Master_gen_visa_quota_info_gen_visa_quota_info_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

  <style>
         .model {
    display: none;  
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

      .closeCancelViewRenwl {
          color: white;
          float: right;
          font-size: 28px;
          font-weight: bold;
      }

          .closeCancelViewRenwl:hover,
          .closeCancelViewRenwl:focus {
              color: #000;
              text-decoration: none;
              cursor: pointer;
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

      #divErrorRsnAWMSRenwl {
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

      .searchlist_btn_lft:hover {
          background: url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
      }

      .searchlist_btn_lft:focus {
          background: url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
      }
  </style>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              if (document.getElementById("<%=HiddenRenwSts.ClientID%>").value == "") {
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("MymodalCancelViewRenewl").style.display = "none";
              }
              document.getElementById('MymodalCancelView').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              document.getElementById("<%=txtFromDate.ClientID%>").focus();

              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
          });


          </script>
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
                           document.getElementById('' + textboxid + '').value = x1;
                           //return x1;
                       else
                           document.getElementById('' + textboxid + '').value = x1 + "." + x2;
                       // return x1 + "." + x2;

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
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa details inserted successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa details updated successfully.";
        }
        function SuccessCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa details cancelled successfully.";
        }
        function Successconfirm() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa details confirmed successfully.";
        }
        function Successreniewed() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa details reniewed successfully.";
            document.getElementById("<%=HiddenRenwSts.ClientID%>").value = "";
        }
        function SuccessReopen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa details reopened successfully.";
        }
        function DuplicationName() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Re Calling Denied!. Bundle Number Can’t be Duplicated.";
        }
        function SuccessRecall() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa details recalled successfully.";
        }
        function getdetails(href) {
            window.location = href;
            return false;
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
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            
            if (keyCodes == 13) {
                return false;
            }
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
        function isTagDisableEnter(evt) {
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
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
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

    <script>

        // for not allowing enter


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


        function SearchValidation() {
            ret = true;

            var CrdExpWithoutReplace = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtFromDate.ClientID%>").value = replaceCode2;

            var CrdExpWithoutReplace = document.getElementById("<%=txtToDate.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtToDate.ClientID%>").value = replaceCode2;

            var FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;


            var cbxStatus = document.getElementById("<%=cbxCnclStatus.ClientID%>");
            var cbx = 0;

            if (cbxStatus.checked) {
                cbx = 1;
            }
            else {
                cbx = 0;
            }

            if (ret == true) {

                document.getElementById("<%=HiddenSearchField.ClientID%>").value = FromDate + ',' + ToDate + ',' + cbx;
            }


            return ret;

        }




        function CloseCancelViewRenwl() {

            if (confirm("Do you want to close  without completing renewal process?")) {
                document.getElementById('divMessageArea').style.display = "none";
                document.getElementById('imgMessageArea').src = "";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
               document.getElementById("MymodalCancelViewRenewl").style.display = "none";
               document.getElementById("freezelayer").style.display = "none";
               document.getElementById("<%=txtIssuedDate.ClientID%>").value = "";
            document.getElementById("<%=txtExpDate.ClientID%>").value = "";
                document.getElementById("<%=txtBundlNum.ClientID%>").value = "";

                document.getElementById("<%=txtnumofvisa.ClientID%>").value = "";
               

                    document.getElementById("<%=HiddenRenwSts.ClientID%>").value = "";
                }
            return false;
        }
       
        function OpenCancelViewRenwl(strId, IntBundleNum) {

            if (confirm("Do you want to renew this entry?")) {

                document.getElementById("<%=txtBundlNum.ClientID%>").value = IntBundleNum;
                document.getElementById("<%=HiddenBundlNum.ClientID%>").value = IntBundleNum;
                document.getElementById("<%=HiddenVisaQuotaId.ClientID%>").value = strId;
                
                document.getElementById("<%=btnRedirect.ClientID%>").click();


            }
            return false;

        }
        function RenewelView()
        {
            document.getElementById("<%=txtBundlNum.ClientID%>").value = document.getElementById("<%=HiddenBundlNum.ClientID%>").value;
            document.getElementById("<%=txtnumofvisa.ClientID%>").disabled = true;
               
            document.getElementById("MymodalCancelViewRenewl").style.display = "block";
            document.getElementById("freezelayer").style.display = "";

            document.getElementById("<%=txtIssuedDate.ClientID%>").focus();
            document.getElementById('divErrorRsnAWMSRenwl').style.visibility = "hidden";
            return false;

        }

        function VisaTyp()
        {
            if (document.getElementById("<%=ddlVisTyp.ClientID%>").value == "--SELECT VISA TYPE--") {
                
                document.getElementById("NumVisa1").style.display = "none";
                document.getElementById("NumVisa").style.display = "";
                
                document.getElementById("<%=txtnumofvisa.ClientID%>").value = "";
                document.getElementById("<%=txtnumofvisa.ClientID%>").disabled = true;
            }
            else {
                document.getElementById("NumVisa1").style.display = "";
                document.getElementById("NumVisa").style.display = "none";
                document.getElementById("<%=txtnumofvisa.ClientID%>").disabled = false;
            }
            return false;
        }
        function ValidateVisaQuota() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }


         
         
            var NameWithoutReplace = document.getElementById("<%=txtIssuedDate.ClientID%>").value.trim();
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtIssuedDate.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtExpDate.ClientID%>").value.trim();
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtExpDate.ClientID%>").value = replaceText2;

            if (document.getElementById("<%=ddlVisTyp.ClientID%>").value != "--SELECT VISA TYPE--") {
             
                var NameWithoutReplace = document.getElementById("<%=txtnumofvisa.ClientID%>").value.trim();
                var replaceText1 = NameWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById("<%=txtnumofvisa.ClientID%>").value = replaceText2;

                document.getElementById("<%=txtnumofvisa.ClientID%>").style.borderColor = "";
                
                }

              document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";

              document.getElementById("<%=txtIssuedDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtExpDate.ClientID%>").style.borderColor = "";


            var BundlNum = document.getElementById("<%=txtBundlNum.ClientID%>").value.trim();



            var IssueDate = document.getElementById("<%=txtIssuedDate.ClientID%>").value;
            var ExpDate = document.getElementById("<%=txtExpDate.ClientID%>").value;
            if (ExpDate != "" && IssueDate != "") {
                var datepickerDate = document.getElementById("<%=txtIssuedDate.ClientID%>").value;
                  var arrDatePickerDate = datepickerDate.split("-");
                  var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                  var datepickerDate = document.getElementById("<%=txtExpDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                if (dateTxIss >= dateCompExp) {

                    document.getElementById("<%=txtExpDate.ClientID%>").value = "";
                ExpDate = "";
                document.getElementById('divErrorRsnAWMSRenwl').style.visibility = "visible";
                document.getElementById("<%=lblErrorRsnAWMSRenwl.ClientID%>").innerHTML = "Expiry date should be greater than issue date";
                var txthighlit = document.getElementById("<%=txtExpDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtExpDate.ClientID%>").focus();


            }
        }
            if (document.getElementById("<%=ddlVisTyp.ClientID%>").value != "--SELECT VISA TYPE--") {
                if (document.getElementById("<%=txtnumofvisa.ClientID%>").value == "")
                {
                    document.getElementById('divErrorRsnAWMSRenwl').style.visibility = "visible";
                    document.getElementById("<%=lblErrorRsnAWMSRenwl.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
     var txthighlit = document.getElementById("<%=txtnumofvisa.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtnumofvisa.ClientID%>").focus();

                    ret = false;
                }
            }
            
        if (ExpDate == "") {
            //  document.getElementById('divMessageArea').style.display = "";
            //document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            //document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
            // document.getElementById("<%=txtExpDate.ClientID%>").style.borderColor = "Red";

            document.getElementById('divErrorRsnAWMSRenwl').style.visibility = "visible";
            document.getElementById("<%=lblErrorRsnAWMSRenwl.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
          
            document.getElementById("<%=txtExpDate.ClientID%>").focus();
            var txthighlit = document.getElementById("<%=txtExpDate.ClientID%>").style.borderColor = "Red";
            ret = false;

        }

        if (IssueDate == "") {
            // document.getElementById('divMessageArea').style.display = "";
            //  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            // document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                // document.getElementById("<%=txtIssuedDate.ClientID%>").style.borderColor = "Red";

                document.getElementById('divErrorRsnAWMSRenwl').style.visibility = "visible";
                document.getElementById("<%=lblErrorRsnAWMSRenwl.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
            document.getElementById("<%=txtIssuedDate.ClientID%>").focus();
                var txthighlit = document.getElementById("<%=txtIssuedDate.ClientID%>").style.borderColor = "Red";
             

                ret = false;
              
            }


            CheckSubmitZero();
            $(window).scrollTop(0);
            if (ret == true) {
                // alert(Amountsummry);
                // document.getElementById('SumryPayRng').innerHTML = Amountsummry;



            }
            return ret;

        }
        function ConfirmAlert() {
           
            ValidateVisaQuota();
            var chck = ValidateVisaQuota();

            if (chck == true) {

                if (confirm("Are You Sure You Want To Confirm?")) {

                    document.getElementById('MymodalCancelViewRenewl').style.display = "none";
                    document.getElementById("<%=HiddenVisaNum.ClientID%>").value = document.getElementById("<%=txtnumofvisa.ClientID%>").value;
                    
                    document.getElementById('divLoading').style.display = "block";
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
        function DateChk() {
            //evm-0023 In renew page show appropriate validation message in date field
            document.getElementById("<%=txtExpDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtIssuedDate.ClientID%>").style.borderColor = "";
            document.getElementById('divMessageArea').style.display = "none";

            var dateCurrentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;
            var arrDateCurrentDate = dateCurrentDate.split("-");
            var CurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);

            if (document.getElementById("<%=txtIssuedDate.ClientID%>").value != "") {

                var datepickerDate1 = document.getElementById("<%=txtIssuedDate.ClientID%>").value;
                var arrDatePickerDate1 = datepickerDate1.split("-");
                var dateTxIss1 = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);


             

                 if (CurrentDate < dateTxIss1) {
                    // document.getElementById('divMessageArea').style.display = "";
                     document.getElementById("<%=lblErrorRsnAWMSRenwl.ClientID%>").innerHTML = "Sorry, issue date should be less than or equal to current date !";
                      
                     document.getElementById("<%=txtIssuedDate.ClientID%>").value = "";
                     document.getElementById("<%=txtIssuedDate.ClientID%>").focus();
                     document.getElementById("<%=txtIssuedDate.ClientID%>").style.borderColor = "red";
                     document.getElementById('divErrorRsnAWMSRenwl').style.visibility = "visible";
                     return false;
                     
                  }
                  else {
                      document.getElementById('divErrorRsnAWMSRenwl').style.visibility = "hidden";
                  }
                document.getElementById("<%=lblErrorRsnAWMSRenwl.ClientID%>").innerHTM = "";
            }

            if (document.getElementById("<%=txtExpDate.ClientID%>").value != "") {

                var datepickerDate = document.getElementById("<%=txtExpDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);



                if (CurrentDate >= dateCompExp) {
                     //  document.getElementById('divMessageArea').style.display = "";
                       document.getElementById("<%=lblErrorRsnAWMSRenwl.ClientID%>").innerHTML = "Sorry, expiry date should be greater than current date !";

                     document.getElementById("<%=txtExpDate.ClientID%>").value = "";
                     document.getElementById("<%=txtExpDate.ClientID%>").focus();
                     document.getElementById("<%=txtExpDate.ClientID%>").style.borderColor = "red";
                     document.getElementById('divErrorRsnAWMSRenwl').style.visibility = "visible";
                     return false;

                 }
                 else {
                     document.getElementById('divErrorRsnAWMSRenwl').style.visibility = "hidden";
                 }
                 document.getElementById("<%=lblErrorRsnAWMSRenwl.ClientID%>").innerHTM = "";
            }

              if (document.getElementById("<%=txtIssuedDate.ClientID%>").value != "" && document.getElementById("<%=txtExpDate.ClientID%>").value != "") {

                var datepickerDate = document.getElementById("<%=txtIssuedDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var datepickerDate = document.getElementById("<%=txtExpDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);



                if (dateTxIss >= dateCompExp) {

                    //  alert("Sorry, expiry date should be greater than issue date !");
                    //document.getElementById("<%=txtExpDate.ClientID%>").value = "";


                    // document.getElementById('divErrorRsnAWMSRenwl').style.visibility = "visible";

                    document.getElementById("<%=lblErrorRsnAWMSRenwl.ClientID%>").innerHTML = "Sorry, issue date should be less than or equal to current date !";
                    
                    document.getElementById("<%=txtExpDate.ClientID%>").focus();

                    document.getElementById("<%=txtExpDate.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=txtExpDate.ClientID%>").value = "";
                    document.getElementById('divErrorRsnAWMSRenwl').style.visibility = "visible";
                    
                   

                }
                else {
                    document.getElementById('divErrorRsnAWMSRenwl').style.visibility = "hidden";
                }
                  
                return false;
            }
        }
        function AlertClearVisaQuota() {
            if (confirmboxSalryVisQut > 0) {
                if (confirm("Are You Sure You Want Clear All Data In This Section?")) {


                    document.getElementById("<%=txtIssuedDate.ClientID%>").value = "";
                    document.getElementById("<%=txtExpDate.ClientID%>").value = "";




                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                //window.location.href = "gen_Bank_Guarantee.aspx";

                document.getElementById("<%=txtIssuedDate.ClientID%>").value = "";
                document.getElementById("<%=txtExpDate.ClientID%>").value = "";

                return false;
            }
        }
        var confirmbox = 0;

        var confirmboxSalryAllwnce = 0;
        var confirmboxSalryDedctn = 0;
        var confirmboxSalryVisQut = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }


        function IncrmntConfrmCounterVisQut() {
            confirmboxSalryVisQut++;
        }

        function DateChkSearch() {

            if (document.getElementById("<%=txtFromDate.ClientID%>").value != "" && document.getElementById("<%=txtToDate.ClientID%>").value != "") {
                var datepickerDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var datepickerDate = document.getElementById("<%=txtToDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
                ///
                if (dateTxIss >= dateCompExp) {
                    //evm-0023 label maessage changed from alert

                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, expiry date should be greater than issue date !";
                       document.getElementById('divMessageArea').style.display = "";
                       document.getElementById("<%=txtToDate.ClientID%>").value = "";
                       document.getElementById("<%=txtToDate.ClientID%>").focus();
                       // alert("bbb");
                   }
                   else {
                       document.getElementById('divMessageArea').style.display = "none";
                   }
               }
               return false;

           }
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
                function removeSpclChrcter(obj) {

                    var txt = document.getElementById(obj).value;


                    if (txt != "") {

                        if (isNaN(txt)) {
                            document.getElementById(obj).value = "";
                            document.getElementById(obj).focus();
                            return true;

                        }
                        else {
                            var specialChars = "!@#$^&%*()+=-[]\/{}|:<>?,.";
                            if (!specialChars.test(txt)) {
                                document.getElementById(obj).value = "";

                                return true;
                            }
                        }


                    }

                }
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
       <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />

     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <asp:HiddenField ID="HiddenVisaQuotaId" runat="server" />
    <asp:HiddenField ID="HiddenBundlNum" runat="server" />
    <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="HiddenDate" runat="server" />
         <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
     <asp:HiddenField ID="HiddenRenwSts" runat="server" />
      <asp:HiddenField ID="HiddenVisaNum" runat="server" />
        <asp:Button ID="btnRedirect" runat="server" Text="Button" style="display:none;" OnClick="btnRedirect_Click" />
    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">
           

        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/visa quata.png" style="vertical-align: middle;" />
     Visa Quota
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 93.5%;margin-top:0.5%;height:10%;">

            <div style="width:100%;float:left;margin-top:14px">
                        <div class="eachform" style="width:42%;float:left;margin-top:-4px;border: 1px solid;border-color: #9ba48b;padding: 5px;margin-left: 1%;">
                 <h2 style="margin-top: 0.5%;margin-left: 34%;">Expiry Date</h2>
             <div class="eachform" style="width: 100%; padding-left: 0.5%;padding-top:1% ;float: left;">
            <h2 style="margin-top: 1.5%;margin-left: 5%;">From Date</h2>

             <div id="Div3" class="input-append date" style="font-family:Calibri;float:right;width:50%;margin-right:7%;margin-top: 1%;">
                 <asp:TextBox ID="txtFromDate"  class="textDate form1" onblur="DateChkSearch();" onkeydown="return DisableEnter(event);" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width:82.8%;height:27px; font-family: calibri;float: left;margin-left: -13%;" ></asp:TextBox>

                        <input type="image" id= "img2" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return DateChkSearch()" style=" height:19px;float:left; width:12px; cursor:pointer;" />

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
                                // startDate: new Date(),


                            });
                            function FocusOnDate() {

                                $noC2('#Div3').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    //startDate: new Date(),


                                });
                            }
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                  


        </div>

            <div class="eachform" style="width: 100%; padding-left: 0.5%;padding-top:0% ;float: left;">
            <h2 style="margin-top: 1.5%;margin-left: 5%;">To Date </h2>

            <div id="ClosingDate" class="input-append date" style="font-family:Calibri;float:right;width:50%;margin-right:7%;margin-top: 1%;margin-bottom: -3px;">
                 <asp:TextBox ID="txtToDate"  class="textDate form1" onblur="DateChkSearch();" onkeydown="return DisableEnter(event);" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width:82.8%;height:27px; font-family: calibri;float: left;margin-left: -13%;" ></asp:TextBox>

                        <input type="image" id="img1" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return DateChkSearch()" style=" height:19px;float:left; width:12px; cursor:pointer;" />

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

                                 
                <div class="subform" style="width:19%;float: left;margin-left: 13%;margin-top: 4%;">


                    <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" onkeydown="return DisableEnter(event);" Checked="false" class="form2" />
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
                  </div>

               
   
                </div>
             <div class="eachform" style="width:12%;float:right;margin-top:-8.5%;margin-left: 0%;">


        
                <div class="eachform" style="width:98%;float: left;/*! margin-right: 9%; *//*! margin-top: 10%; */">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: -0.4%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();"  OnClick="btnSearch_Click" />
                     </div>
                 </div>
              <asp:Button ID="Button1" class="save" runat="server" Text="Mail"  OnClick="btnMail_Click" style="width: 64px; float:right;margin-left:0%;margin-top: -4%;display:none" />
            <br style="clear: both" />
            </div>
        <br />

        <div onclick="location.href='gen_visa_quota_info.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;">

          <%--  <a href="gen_Projects.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
        </div>
        <%--  <br />
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

                                 <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Visa Quota</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 24%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   


                                    <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelViewRenewl" class="modalCancelView" style="display: none;width: 69%;margin-left: -9%;">
                <!-- Modal content -->
                <div class="modal-CancelView" style="height:350px" >
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 1%; margin-right: 1%;" cursor: pointer;" onclick="CloseCancelViewRenwl();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 42%; padding-bottom: 0.7%; padding-top: 0.6%;">Visa Quota</h3>
                    </div>
                    <div class="modal-bodyCancelView" style="height: 140px;">
                                <div id="divErrorRsnAWMSRenwl" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMSRenwl" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; display:none">Close Reason*</label>
                       <asp:TextBox ID="TextBox1" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;display:none" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTagOnly(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                        <div style="float: left;width: 100%;">
                          <div class="eachform" style="width:99%;float:left;margin-top:10px;margin-left:1px;border: 1px solid;border-color: #9ba48b;">

                                   <div id="divContactPersn" class="eachform" style="width: 53%; float: left;margin-top: 1%;">

                            <h2 style="margin-left: 4%;margin-top: 1%;">Bundle Number*</h2>
                                                         
                                  <asp:TextBox ID="txtBundlNum"  class="form1" runat="server" MaxLength="10" Style="width: 46%; text-transform: uppercase; margin-right: 8.4%; height: 30px" onblur="return removeSpclChrcter('cphMain_txtBundlNum')" onkeydown="return isNumber(event)"></asp:TextBox>
                                                            
                                                         
                                                </div>
                                <div class="eachform" style="width: 47%;  float: right;margin-top: 0%;">
                    <div class="subform" style="width: 97%; margin-left: 38%;padding: 1%;border: 2px solid rgb(207, 204, 204);margin-top: 1%;height: 21px;">

                         <asp:Button ID="btnConfirm"  runat="server" style="width: 28%;" class="save" Text="Confirm" OnClick="btnConfirm_Click" OnClientClick="return ConfirmAlert();"/>
                         <asp:Button ID="btnCancel"   runat="server" style="width: 28%;margin-left: 1%;" class="cancel" Text="Cancel"  OnClientClick="return CloseCancelViewRenwl();"  />
                     <asp:Button ID="btnClear"  runat="server" style="width: 28%;margin-top: 0%;margin-left: 5%;" OnClientClick="return AlertClearVisaQuota();"  class="cancel" Text="Clear"/>
                        </div>
                                    </div>
                       <%-- <div class="eachform" style="width: 100%;margin-top:0%;">--%>
              <div class="eachform" style="width:49%;margin-top: 3%;">
              <h2 style="margin-left: 4.5%;margin-top: 1%;">Issued Date*</h2>
               <div id="VisaQuot" class="input-append date" style="font-family:Calibri;float:right;width:56.5%;">
                 <asp:TextBox ID="txtIssuedDate" class="textDate" onchange="IncrmntConfrmCounter()" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onblur="DateChk();" Style="float:left;width:81%;height:28px; font-family: calibri;margin-left: 3%;" ></asp:TextBox>

                        <input type="image" id= "imgDate" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="DateChk();" style="height:24px; width:16px; cursor:pointer;float: left;margin-top: 0%;" />

                        <script type="text/javascript">
                            var $noCo = jQuery.noConflict();
                          
                            $noCo('#VisaQuot').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date()
                                                         });
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                   </div>


 <div class="eachform" style="width:48%">
              <h2 style="margin-left: 6%;margin-top: 1%;">Expiry Date*</h2>
               <div id="VisaQuotDtls" class="input-append date" style="font-family:Calibri;float:right;width:56.5%;">
                 <asp:TextBox ID="txtExpDate" class="textDate" onchange="IncrmntConfrmCounter()" placeholder="DD-MM-YYYY" MaxLength="20" onblur="DateChk();" runat="server" Style="float:left;width:79%;height:28px; font-family: calibri;" ></asp:TextBox>

                        <input type="image" id="img3" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="DateChk();" style="height:24px; width:16px; cursor:pointer;float: left;margin-top: 0%;" />

                        <script type="text/javascript">
                            var $noCo = jQuery.noConflict();
                            var year = (new Date).getFullYear();

                            var dateCurrentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;
                            var arrDateCurrentDate = dateCurrentDate.split("-");
                            var CurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);
                        
                            var date1 = new Date();
                         
                            // add a day
                       
                            CurrentDate.setDate(CurrentDate.getDate() + 1);
                         
                            $noCo('#VisaQuotDtls').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                             
                                startDate: CurrentDate,
                              

                            });
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                   </div>


                                   <div class="eachform" style="width: 98%;margin-top:1%;float: left;">

                                             <div id="divAddtn" class="eachform" style="width: 51%; float: left;margin-top: 1%;">

                            <h2 style="margin-left: 4.5%;">Visa Type</h2>
                                                         
                                    <asp:DropDownList ID="ddlVisTyp" onchange="return VisaTyp();" class="form1" runat="server" Style="height:30px;width:53.2%;float:left; margin-left: 23.2%;">
                   
                </asp:DropDownList>
                                                            
                                                         
                                                </div>

                 
                  <h2 id="NumVisa" style="margin-top:1%;width: 13%;margin-left: 2.5%;">No. Of Visas</h2>
                                        <h2 id="NumVisa1" style="margin-top:1%;width: 13%;margin-left: 2.5%;display:none">No. Of Visas*</h2>
                    <asp:TextBox ID="txtnumofvisa"  class="form1" runat="server" MaxLength="8" Style="width: 24%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 5.3%;" onblur="return removeSpclChrcter('cphMain_txtnumofvisa')" onkeydown="return isNumber(event,'cphMain_txtnumofvisa');" onkeyup="addCommas('cphMain_txtnumofvisa')"></asp:TextBox>
                 
                </div>


                    </div>
              


                </div>
            </div>   
                          
                    <div class="modal-footerCancelView" style="margin-top: 42px;" >
                    </div>
                    </div>
                </div>
          
        
    </div>
     <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
    <div id="divLoading" class="model" style="display:none" >
            <div class="eachform" style="width:55%; height:55%; padding-left:46%; padding-top:9%;">
                 <img src="/Images/Other Images/LoadingMail.gif" style="width:18%;" />
                 </div>
      </div>

    <style>
        #ReportTable_filter input {
            height: 18px;
            width: 200px;
            color: #336B16;
            font-size: 14px;
        }

        .open > .dropdown-menu {
            display: none;
        }
    </style>
</asp:Content>

