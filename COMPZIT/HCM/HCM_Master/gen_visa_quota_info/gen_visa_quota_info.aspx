<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" CodeFile="gen_visa_quota_info.aspx.cs" Inherits="HCM_HCM_Master_gen_visa_quota_info_gen_visa_quota_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
  <style>

              .model {
    display: none;  Hidden by default 
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
       
          .open > .dropdown-menu {
            display: none;
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
 #ReportTables_filter {
    font-family: Calibri;
    font-weight: bold;
    font-size: 14px;
    margin-bottom: .5%;
}
      .searchlist_btn_lft:hover {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
        .searchlist_btn_lft:focus {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
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
                           document.getElementById('' + textboxid + '').value = x1;
                           //return x1;
                       else
                           document.getElementById('' + textboxid + '').value = x1 + "." + x2;
                       // return x1 + "." + x2;

                   }

    </script>
   

     <style>

           .textDate:focus {
            border: 1px solid #bbf2cf;
            box-shadow: 0px 0px 4px 2.5px #bbf2cf;
        }
        .textDate {
            border: 1px solid #cfcccc;
        }
            .open > .dropdown-menu {
    display: none;
             }

            .bootstrap-datetimepicker-widget {

    z-index: 100;
}
              .eachform h2 {
                margin: 6px 0 6px;
            }
    </style>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {

              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              
              document.getElementById("<%=txtBundlNum.ClientID%>").focus();
              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              //if (CancelPrimaryId != "") {
              //    OpenCancelView();
              //}
             
          
        
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
              if (confirm("Do you want to close  without completing Cancellation Process?")) {
                  document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById('imgMessageArea').src = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("MymodalCancelView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";

                  document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
              }
              LoadListPageallwnce();
             

              return false;
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
    <script type="text/javascript">

        function DuplicationName() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error.Bundle Number Can't Be Duplicated.";

            $(window).scrollTop(0);
        }
     
  
      



        function CancelAlert(href) {

            if (confirm("Do you want to cancel this Entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }

        function CancelNotPossible() {
            alert("Sorry, Cancellation Denied. This Entry is Already Selected Somewhere Or It is a Confirmed Entry!");
            return false;

        }

        var confirmbox = 0;
        var confirmboxSalryVisQut = 0;
        var confirmboxSalryAllwnce = 0;
        var confirmboxSalryDedctn = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }

  
        function IncrmntConfrmCounterVisQut() {
            confirmboxSalryVisQut++;
        }
        function AlertClearAll() {
            if (confirmbox > 0 || confirmboxSalryVisQut > 0) {
                if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                    window.location.href = "gen_Pay_Grade_Master.aspx";
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Pay_Grade_Master.aspx";

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
        // var $pp = jQuery.noConflict();
        $p(document).ready(function () {
            $p("#ReportTable").data({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });
            $p("#ReportTables").data({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });

        });




        function reporttables() {


            var $p1 = jQuery.noConflict();


            $p("#ReportTable").dataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });

            $p("#ReportTables").dataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });




        }



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


        function SuccessConfirmationVisaQuota() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa quota inserted successfully.";
           // ClearAllPaygrd();
          //  LoadListPageallwnce();
           // LoadListPageDed();

         
            document.getElementById("<%=txtBundlNum.ClientID%>").focus();
           $(window).scrollTop(0);

          
        }


        function UpdatePayGradePayGrade() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Pay Grade Details Updated Successfully.";
            
          
            document.getElementById("<%=txtBundlNum.ClientID%>").focus();
            $(window).scrollTop(0);

        }
        function SuccessConfirmationVisaQuotaDtls() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa details inserted successfully.";
            LoadListPageallwnce();
            ClearVisaDetails();
            document.getElementById("<%=txtBundlNum.ClientID%>").focus();
                    $(window).scrollTop(0);

        }
        
        function UpdateVisaDetls() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa details Updated Successfully.";
            LoadListPageallwnce();
            ClearVisaDetails();
            document.getElementById("<%=txtBundlNum.ClientID%>").focus();
            $(window).scrollTop(0);

        }
        function DuplicationVisaTypNameSave() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error.Visa Type Can’t be Duplicated.";
            LoadListPageallwnce();
            //ClearVisaDetails();
            document.getElementById("<%=txtnumofvisa.ClientID%>").value = document.getElementById("<%=HiddenNumVisa.ClientID%>").value;
            
            
            $(window).scrollTop(0);
            document.getElementById("<%=ddlVisTyp.ClientID%>").focus();
        

        }
        function DuplicationVisaTypName() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error.Visa Type Can’t be Duplicated.";
            LoadListPageallwnce();
              //ClearVisaDetails();
            document.getElementById("<%=txtnumofvisa.ClientID%>").value = document.getElementById("<%=HiddenNumVisa.ClientID%>").value;
            document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "none";
            document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "block";

            document.getElementById("<%=txtnumofvisa.ClientID%>").disabled = true;

            $(window).scrollTop(0);
            document.getElementById("<%=ddlVisTyp.ClientID%>").focus();
           

        }
        function SuccessCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa details Cancelled Successfully.";
            document.getElementById("<%=txtBundlNum.ClientID%>").focus();
              LoadListPageallwnce();
              ClearVisaDetails();
             
              $(window).scrollTop(0);


          }
        
        function Rangeexceed(textboxid1) {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "From Range amount should not be equal or greater than the To Range amount.";
            document.getElementById(textboxid1).style.borderColor = "Red";
            // document.getElementById(textboxid1).focus();
            $(window).scrollTop(0);

        }
    
    
        function ValidateVisaQuota() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            var NameWithoutReplace = document.getElementById("<%=txtBundlNum.ClientID%>").value.trim();
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtBundlNum.ClientID%>").value = replaceText2;

           
            var NameWithoutReplace = document.getElementById("<%=txtIssuedDate.ClientID%>").value.trim();
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtIssuedDate.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtExpDate.ClientID%>").value.trim();
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtExpDate.ClientID%>").value = replaceText2;


            var NameWithoutReplace = document.getElementById("<%=txtnumofvisa.ClientID%>").value.trim();
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtnumofvisa.ClientID%>").value = replaceText2;


            document.getElementById("<%=txtBundlNum.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtIssuedDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtExpDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtnumofvisa.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlVisTyp.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlNation.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlBusUnit.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlGender.ClientID%>").style.borderColor = "";

            var BundlNum = document.getElementById("<%=txtBundlNum.ClientID%>").value.trim();

          

            var IssueDate = document.getElementById("<%=txtIssuedDate.ClientID%>").value;
            var ExpDate = document.getElementById("<%=txtExpDate.ClientID%>").value;
            if (ExpDate != "" && IssueDate!="")
            {
            var datepickerDate = document.getElementById("<%=txtIssuedDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=txtExpDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            if (dateTxIss >= dateCompExp) {
                document.getElementById("<%=txtExpDate.ClientID%>").value = "";
            }
        }
            //evm-0023 
            
 
           
            
            if (ExpDate == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtExpDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtExpDate.ClientID%>").focus();
                  ret = false;

              }

            if (IssueDate == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtIssuedDate.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtIssuedDate.ClientID%>").focus();
                        ret = false;

                    }

                            if (BundlNum == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtBundlNum.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtBundlNum.ClientID%>").focus();
                ret = false;

            }
            CheckSubmitZero();
            $(window).scrollTop(0);
            if (ret == true) {
                // alert(Amountsummry);
                // document.getElementById('SumryPayRng').innerHTML = Amountsummry;

document.getElementById('divLoading').style.display = "block";

            }
            return ret;

        }
        function ValidateVisaQuotaDetails() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
         

            var NameWithoutReplace = document.getElementById("<%=txtnumofvisa.ClientID%>").value.trim();
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtnumofvisa.ClientID%>").value = replaceText2;


           
            document.getElementById("<%=txtnumofvisa.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlVisTyp.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlNation.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlBusUnit.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlGender.ClientID%>").style.borderColor = "";

            var NumOfVisa = document.getElementById("<%=txtnumofvisa.ClientID%>").value.trim();

            
         
            var VisaTyp = document.getElementById("<%=ddlVisTyp.ClientID%>").value;
            var Nation = document.getElementById("<%=ddlNation.ClientID%>").value;
            var BusUnit = document.getElementById("<%=ddlBusUnit.ClientID%>").value;
            var Gender = document.getElementById("<%=ddlGender.ClientID%>").value;
            
            document.getElementById("<%=HiddenBissnsUnitID.ClientID%>").value = BusUnit;
            if (NumOfVisa == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtnumofvisa.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtnumofvisa.ClientID%>").focus();
                ret = false;

            }
            else {
                document.getElementById("<%=HiddenNumVisa.ClientID%>").value = NumOfVisa;
            }

            if (Nation == "--SELECT NATION--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlNation.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlNation.ClientID%>").focus();
                ret = false;

            }
            else
            {
                document.getElementById("<%=HiddenNation.ClientID%>").value=Nation;
            }
   
            if (VisaTyp == "--SELECT VISA TYPE--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlVisTyp.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlVisTyp.ClientID%>").focus();
                ret = false;

            }
            else
            {
                document.getElementById("<%=HiddenVisaTyp.ClientID%>").value = VisaTyp;
        }
         
            if (document.getElementById("<%=HiddenVisaQuotaId.ClientID%>").value == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please add visa quota to proceed.";
                document.getElementById('DivPaygrd').style.borderColor = "Red";
                document.getElementById("<%=txtBundlNum.ClientID%>").focus();
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
    
        function AlertClearVisaDetails() {
            if (confirmboxSalryVisQut > 0) {
                if (confirm("Are You Sure You Want Clear All Data In This Section?")) {
                    // window.location.href = "gen_Bank_Guarantee.aspx";
                    document.getElementById("<%=ddlVisTyp.ClientID%>").selectedIndex = "0";
                    document.getElementById("<%=ddlNation.ClientID%>").selectedIndex = "0";
                    
                  var corp=  document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                       document.getElementById("<%=txtnumofvisa.ClientID%>").value = "";
                    document.getElementById("<%=txtAllotdVisa.ClientID%>").value = "";

                    document.getElementById("<%=ddlBusUnit.ClientID%>").value = corp;
                    document.getElementById("<%=txtnumofvisa.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlGender.ClientID%>").value = "0";
                      
                       if (document.getElementById("<%=hiddenRoleAdd.ClientID%>").value == "1") {
                           document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
                       }
                       document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";
                  

                       return false;
                   }
                   else {
                       return false;
                   }
               }
               else {
                   //window.location.href = "gen_Bank_Guarantee.aspx";
                document.getElementById("<%=ddlVisTyp.ClientID%>").selectedIndex = "0";
                document.getElementById("<%=ddlNation.ClientID%>").selectedIndex = "0";

                var corp = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                document.getElementById("<%=txtnumofvisa.ClientID%>").value = "";

                document.getElementById("<%=txtnumofvisa.ClientID%>").disabled = false;
                document.getElementById("<%=ddlBusUnit.ClientID%>").value = corp;
                document.getElementById("<%=ddlGender.ClientID%>").value = "0";

                if (document.getElementById("<%=hiddenRoleAdd.ClientID%>").value == "1") {
                    document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
                       }
                       document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";
                   return false;
            }
            return false;
           }

        function ClearVisaDetails() {
            document.getElementById("<%=ddlVisTyp.ClientID%>").selectedIndex = "0";
            document.getElementById("<%=ddlNation.ClientID%>").selectedIndex = "0";

            var corp = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
            document.getElementById("<%=txtnumofvisa.ClientID%>").value = "";

            document.getElementById("<%=txtAllotdVisa.ClientID%>").value = "";
            document.getElementById("<%=ddlBusUnit.ClientID%>").value = corp;
            document.getElementById("<%=ddlGender.ClientID%>").value = "0";

            if (document.getElementById("<%=hiddenRoleAdd.ClientID%>").value == "1") {
                document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
                }
                document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";

           }

        function AlertClearVisaQuota() {
            if (confirmbox > 0) {
                if (confirm("Are You Sure You Want Clear All Data In This Section?")) {
                 
                    document.getElementById("<%=txtBundlNum.ClientID%>").value = "";
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
                document.getElementById("<%=txtBundlNum.ClientID%>").value = "";
                document.getElementById("<%=txtIssuedDate.ClientID%>").value = "";
                document.getElementById("<%=txtExpDate.ClientID%>").value = "";
                    
                return false;
            }
        }

        function ClearVisaQuota() {
            document.getElementById("<%=txtBundlNum.ClientID%>").value = "";
            document.getElementById("<%=txtIssuedDate.ClientID%>").value = "";
            document.getElementById("<%=txtExpDate.ClientID%>").value = "";
                    

        }

        function LoadListPageallwnce() {

            var View = document.getElementById("<%=HiddenView.ClientID%>").value;
           
            var EnableCanl = document.getElementById("<%=HiddnEnableCacel.ClientID%>").value;
            
            var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
            var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
            var VisaQuotaId = document.getElementById("<%=HiddenVisaQuotaId.ClientID%>").value;
            var RoleUpdate = document.getElementById("<%=hiddenRoleUpdate.ClientID%>").value;
            var Details = PageMethods.LoadListPageallwnce(EnableCanl, CorpId, OrgId, VisaQuotaId, RoleUpdate,View, function (response) {

                // alert(response);
                // reporttable();

                document.getElementById('cphMain_divReport').innerHTML = response.strhtml;

                //$p("#ReportTableAllw").DataTable({
                //    "pagingType": "full_numbers",
                //    "bSort": true,
                //    "pageLength": 25,
                //    "bDestroy": true
                //});
         
                   $p("#ReportTableAllw").DataTable({
                       "pagingType": "full_numbers",
                       "bSort": true,
                       "pageLength": 25,
                       "bDestroy": true
                   });


               });





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

           function AmountChecking(textboxid, textboxid1, textboxid2) {
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
                       if (textboxid != 'cphMain_txtperctg') {
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


   
           function AlertClearAddition() {
               if (confirmboxSalryAllwnce > 0) {
                   if (confirm("Are You Sure You Want Clear All Data In This Section?")) {
                       // window.location.href = "gen_Bank_Guarantee.aspx";
                      
                  
                     
                       document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
                       document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";
                       return false;
                   }
                   else {
                       return false;
                   }
               }
               else {
                   //window.location.href = "gen_Bank_Guarantee.aspx";
              
              
                  
                   document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
                   document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";
                   return false;
               }
           }

           function ClearAddition() {
             
        
             
           }
   

           function ConfirmMessage() {
               if (confirmbox > 0 || confirmboxSalryVisQut>0) {
                   if (confirm("Are You Sure You Want To Leave This Page?")) {
                       window.location.href = "gen_visa_quota_info_list.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_visa_quota_info_list.aspx";

               }
           }
        

       
           function getdetailsAllwceById(x) {



               var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
               var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
               var Details = PageMethods.ReadVisaDetailsEdit(x, CorpId, OrgId, function (response) {

              
                   document.getElementById("<%=txtnumofvisa.ClientID%>").value = response.NoofVisa;
                   document.getElementById("<%=ddlGender.ClientID%>").value = response.Gender;

                   if (response.ddlChkVisa == 0) {
                     
                       document.getElementById("<%=ddlVisTyp.ClientID%>").value = response.ddlselValVisa;
                   }
                   else if (response.ddlChkVisa == 1) {
                       var $Mo = jQuery.noConflict();
                       var newOption = "<option value='" + response.ddlselValVisa + "'>" + response.ddltextVisa + "</option>";
                    
                       $Mo('#<%=ddlVisTyp.ClientID%>').append(newOption);
                       //SORTING DDL
                       var options = $Mo("#<%=ddlVisTyp.ClientID%> option");                    // Collect options         
                       options.detach().sort(function (a, b) {               // Detach from select, then Sort
                           var at = $Mo(a).text();
                           var bt = $Mo(b).text();
                           return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                       });
                       options.appendTo('#<%=ddlVisTyp.ClientID%>');
                       document.getElementById("<%=ddlVisTyp.ClientID%>").value = response.ddlselValVisa;

                   }


                   if (response.ddlChkContry == 0) {
                       document.getElementById("<%=ddlNation.ClientID%>").value = response.ddlselValNation;
                   }
                   else if (response.ddlChkContry == 1) {
                       var $Mo = jQuery.noConflict();
                       var newOption = "<option value='" + response.ddlselValNation + "'>" + response.ddltextNation + "</option>";

                       $Mo('#<%=ddlNation.ClientID%>').append(newOption);
                       //SORTING DDL
                       var options = $Mo("#<%=ddlNation.ClientID%> option");                    // Collect options         
                       options.detach().sort(function (a, b) {               // Detach from select, then Sort
                           var at = $Mo(a).text();
                           var bt = $Mo(b).text();
                           return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                       });
                       options.appendTo('#<%=ddlNation.ClientID%>');
                       document.getElementById("<%=ddlNation.ClientID%>").value = response.ddlselValNation;

                   }

                   if (response.ddlChkCorp == 0) {
                       document.getElementById("<%=ddlBusUnit.ClientID%>").value = response.ddlselValBussns;
                     }
                   else if (response.ddlChkCorp == 1) {
                         var $Mo = jQuery.noConflict();
                         var newOption = "<option value='" + response.ddlselValBussns + "'>" + response.ddltextBussns + "</option>";

                         $Mo('#<%=ddlBusUnit.ClientID%>').append(newOption);
                       //SORTING DDL
                       var options = $Mo("#<%=ddlBusUnit.ClientID%> option");                    // Collect options         
                       options.detach().sort(function (a, b) {               // Detach from select, then Sort
                           var at = $Mo(a).text();
                           var bt = $Mo(b).text();
                           return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                       });
                       options.appendTo('#<%=ddlBusUnit.ClientID%>');
                       document.getElementById("<%=ddlBusUnit.ClientID%>").value = response.ddlselValBussns;

                   }
                   
                   document.getElementById("<%=txtAllotdVisa.ClientID%>").value = response.strRemVis;
                   document.getElementById("<%=HiddenVisaDetlId.ClientID%>").value = response.VisDtlId;
                   document.getElementById("<%=HiddenVisaQuotaId.ClientID%>").value = response.VisaQuotaId;
                   document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "none";
                   document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "block";
                
              
                   document.getElementById("<%=txtnumofvisa.ClientID%>").disabled = true;
               
                

               });
               return false;
           }
        
          function CancelAlertAllwceById(x) {
              if (confirm("Do you want to cancel this Entry?")) {

                
                   document.getElementById("<%=hiddenRsnid.ClientID%>").value = x;
                   var userId = document.getElementById("<%=HiddenUserId.ClientID%>").value;
                   var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                  var Details = PageMethods.CancelAlertVisaDtls(x, userId, CorpId, function (response) {


                      var SucessDetails = response;
                    
                      if (SucessDetails == "success") {
                          // window.location = 'gen_Pay_Grade_Master.aspx?InsUpd=StsCh';
                          //reporttable();
                        
                          //LoadListPageallwnce();
                          // LoadListPageDed();
                          SuccessCancelation();

                      }
                      else {
                          // window.location = 'gen_Pay_Grade_Master_List.aspx?InsUpd=Error';
                      }
                      
                       LoadListPageallwnce();
                      

                   });
                   return false;
             

              }
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

           function ConfirmAlert() {
           

                   if (confirm("Are You Sure You Want To Confirm?")) {
                       var check = ValidateVisaQuota();
                       if (check == true) {
                         
                           //document.getElementById('divLoading').style.display = "block";
                           return true;
                       }
                       else
                           return false;
                   }
                   else {

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
           function DateChk() {

               var dateCurrentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;
               var arrDateCurrentDate = dateCurrentDate.split("-");
               var CurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);
         
               if (document.getElementById("<%=txtIssuedDate.ClientID%>").value != "")
               {
                   var datepickerDate1 = document.getElementById("<%=txtIssuedDate.ClientID%>").value;
                   var arrDatePickerDate1 = datepickerDate1.split("-");
                   var dateTxIss1 = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

                  
                 
                 
                   if (CurrentDate < dateTxIss1)
                   {
                       //evm-0023 message show in message label
                       document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, issue date should be less than or equal to current date !";
                       //alert("Sorry, issue date should be less than or equal to current date !");
                       document.getElementById("<%=txtExpDate.ClientID%>").focus();
                       document.getElementById("<%=txtExpDate.ClientID%>").value = "";
                       document.getElementById('divMessageArea').style.display = "";
                       return false;
  
                   }
                   else {
                       document.getElementById('divMessageArea').style.display = "none";
                   }
                  
            
               }
        
   
               if (document.getElementById("<%=txtIssuedDate.ClientID%>").value != "" && document.getElementById("<%=txtExpDate.ClientID%>").value != "") {
                   var datepickerDate = document.getElementById("<%=txtIssuedDate.ClientID%>").value;
                              var arrDatePickerDate = datepickerDate.split("-");
                              var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                              var datepickerDate = document.getElementById("<%=txtExpDate.ClientID%>").value;
                            var arrDatePickerDate = datepickerDate.split("-");
                            var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
                        


                            if (dateTxIss >= dateCompExp) {
                                //evm-0023 message show in message label
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, expiry date should be greater than issue date !";
                                //alert("Sorry, expiry date should be greater than issue date !");

                                // document.getElementById("<%=txtExpDate.ClientID%>").value = "";
                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById("<%=txtExpDate.ClientID%>").focus();
                                document.getElementById("<%=txtExpDate.ClientID%>").value = "";
                                
                            }
                            else {
                                document.getElementById('divMessageArea').style.display = "none";
                            }


                          }

               return false;

           }

    //</style>
      <%--FOR DATE TIME PICKER--%>
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
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>
    
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    
      <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    
     <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
   
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
      <asp:HiddenField ID="HiddenVisaQuotaId" runat="server" />
      <asp:HiddenField ID="hiddenRoleUpdate" runat="server" />
       <asp:HiddenField ID="HiddenVisaDetlId" runat="server" />
     <asp:HiddenField ID="hiddenRoleReOpen" runat="server" />
     <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />
      <asp:HiddenField ID="HiddenView" runat="server" />
          <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
        <asp:HiddenField ID="HiddenVisaTyp" runat="server" />
        <asp:HiddenField ID="HiddenNation" runat="server" />
      <asp:HiddenField ID="HiddenBissnsUnitID" runat="server" />

     <asp:HiddenField ID="HiddenNumVisa" runat="server" />
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
               <div id="divImage" style="float: right;margin-right:3%;margin-top:-3%">
                       
                        <asp:ImageButton ID="imgbtnReOpen" runat="server" OnClientClick="return ConfirmReOpen();" Style="margin-left: 0%;" OnClick="imgbtnReOpen_Click" />
                         <p id="imgReOpen" class="imgDescription" style="color: white"></p>
                    </div>
                        <div id="divContactPersn" class="eachform" style="width: 71%; float: left;margin-top: 1%;">

                            <h2 style="margin-left: 20%;">Bundle Number*</h2>
                                                         
                                  <asp:TextBox ID="txtBundlNum"  class="form1" runat="server" MaxLength="100" Style="width: 46%; text-transform: uppercase; margin-right: 8.4%; height: 30px" onkeydown="textCounter(cphMain_txtBundlNum,100)" onkeyup="textCounter(cphMain_txtBundlNum,100)"></asp:TextBox>
                                                            
                                                         
                                                </div>

               <div class="eachform" style="width:71%;margin-top: 1%;">
              <h2 style="margin-left: 20%;">Issued Date*</h2>
               <div id="VisaQuot" class="input-append date" style="font-family:Calibri;float:right;width:56.5%;">
                 <asp:TextBox ID="txtIssuedDate" class="textDate" onchange="IncrmntConfrmCounter()" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onblur="return DateChk();" Style="float:left;width:79%;height:28px; font-family: calibri;" ></asp:TextBox>

                        <input type="image" runat="server" id= "imgDate" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return DateChk();" style="   height:22px; width:16px; cursor:pointer;float: left;margin-top: 0%;" />

                        <script type="text/javascript">
                            var $noCo = jQuery.noConflict();
                            var year = (new Date).getFullYear();
                            var month = (new Date).getUTCMonth() ;
                            var day = (new Date).getUTCDate();
                            $noCo('#VisaQuot').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(year, month, day),
                                startDate: new Date(year, '0', '2'),

                            });
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                   </div>


 <div class="eachform" style="width:71%">
              <h2 style="margin-left: 20%;">Expiry Date*</h2>
               <div id="VisaQuotDtls" class="input-append date" style="font-family:Calibri;float:right;width:56.5%;">
                 <asp:TextBox ID="txtExpDate" class="textDate" onchange="IncrmntConfrmCounter()" placeholder="DD-MM-YYYY" MaxLength="20" onblur="return DateChk();" runat="server" Style="float:left;width:79%;height:28px; font-family: calibri;" ></asp:TextBox>

                        <input type="image" runat="server" id= "img1" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return DateChk();" style=" height:22px; width:16px; cursor:pointer;float: left;margin-top: 0%;" />

                        <script type="text/javascript">
                            var $noCo = jQuery.noConflict();
                            var year = (new Date).getFullYear();

                            $noCo('#VisaQuotDtls').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                startDate: new Date(year, '0', '2'),

                            });
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                   </div>

               <%-- <div class="eachform"  style="width:57%;padding-top: 2%;">--%>
                  <%--<h2>Status*</h2>--%>
           
                

           <%-- </div>    --%>
             
                <div class="eachform" style="width: 21%;  float: right;margin-top: -5%;">
                    <div class="subform" style="width: 58%; margin-left: 38%;padding: 2%;border: 2px solid rgb(207, 204, 204);">
                       
                       <%-- <asp:Button ID="btnConfirm" TabIndex="24" runat="server" class="save" Text="Confirm"  OnClientClick="return ConfirmAlert();"/>--%>
                          <asp:Button ID="btnConfirm" runat="server" style="width: 95%;" class="save" Text="Confirm" OnClick="btnConfirm_Click" OnClientClick="return ConfirmAlert();"/>
                     <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" style="width: 95%;" OnClientClick="return ValidateVisaQuota();" OnClick="btnUpdate_Click"  />
                    <asp:Button ID="btnUpdateClose" style="width: 95%;" runat="server" class="save" Text="Update & Close" OnClientClick="return ValidateVisaQuota();" OnClick="btnUpdate_Click"   />
                    <asp:Button ID="btnAdd"  runat="server"  class="save" style="width: 95%;" Text="Save" OnClientClick="return ValidateVisaQuota();" onclick="btnAdd_Click"    />
                    <asp:Button ID="btnAddClose"  runat="server" style="width: 95%;" class="save" Text="Save & Close" OnClientClick="return ValidateVisaQuota();" onclick="btnAdd_Click"   />
                    <asp:Button ID="btnCancel"   runat="server" style="width: 95%;margin-left: 1%;" class="cancel" Text="Cancel" PostBackUrl="gen_visa_quota_info_List.aspx"  />
                     <asp:Button ID="btnClear"  runat="server" style="width: 95%;margin-top: 4%;margin-left: 1%;" OnClientClick="return AlertClearVisaQuota();"  class="cancel" Text="Clear"/>
                        </div>
                    </div>
             
                
                 </div>

    <%-- NEXT DIV    --%>
            <div id="divAllnce" runat="server" style="float:left;width:97%;border: 2px solid rgb(207, 204, 204);margin-left: 1.3%;margin-top: 3%;">

                <div id="div2" style="margin-top: 1%;padding-left: 1%;font-size: 22px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
           <%-- <img src="/Images/BigIcons/Contract_Master48x48.png" style="vertical-align: middle;" />--%>
            Visa Details
        </div >
                <div style="float:left;width:100%">
                  <div id="divAddtn" class="eachform" style="width: 48%; float: left;margin-top: 1%;">

                            <h2 style="margin-left: 14.5%;">Visa Profession*</h2>
                                                         
                                    <asp:DropDownList ID="ddlVisTyp" class="form1" runat="server" Style="height:30px;width:50.8%;float:left; margin-left: 5.8%;">
                   
                </asp:DropDownList>
                                                            
                                                         
                                                </div>
                  <div id="divNation" class="eachform" style="width: 48%; float: left;margin-top: 1%;">

                            <h2 style="margin-left: 16.5%;">Nation*</h2>
                                                         
                                    <asp:DropDownList ID="ddlNation" class="form1" runat="server" Style="height:30px;width:52.8%;float:left; margin-left: 19%;">
                   
                </asp:DropDownList>
                                                            
                                                         
                                                </div>
                    </div>
                <div style="float:left;width:100%">
              <div class="eachform" style="width: 98%;margin-top:1%;float: left;">
                 
                  <h2 style="margin-top:1%;width: 9%;margin-left: 7.1%;">No. Of Visas*</h2>
                    <asp:TextBox ID="txtnumofvisa"  class="form1" runat="server" MaxLength="8" Style="width: 23.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 3.8%;" onblur="return removeSpclChrcter('cphMain_txtnumofvisa')" onkeydown="return isNumber(event,'cphMain_txtAllotdVisa');" onkeyup="addCommas('cphMain_txtAllotdVisa')"></asp:TextBox>
                   <h2 style="margin-left: 12.4%;float: left;">Balance Num Of Visas</h2>
                  <asp:TextBox ID="txtAllotdVisa"  class="form1" runat="server" MaxLength="12" Style="width: 24.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 1%;" onkeydown="return isNumber(event,'cphMain_txtAllotdVisa');" onkeyup="addCommas('cphMain_txtAmntRgeTo')"></asp:TextBox>
                </div>
                    </div>
                <div style="float:left;width:100%">
                  <div id="div1" class="eachform" style="width: 48%; float: left;margin-top: 1%;">

                            <h2 style="margin-left: 14.5%;">Business Unit*</h2>
                                                         
                                    <asp:DropDownList ID="ddlBusUnit" class="form1" runat="server" Style="height:30px;width:50.8%;float:left; margin-left: 7.8%;">
                   
                </asp:DropDownList>
                                                            
                                                         
                                                </div>
                  <div id="div3" class="eachform" style="width: 48%; float: left;margin-top: 1%;">

                            <h2 style="margin-left: 16.8%;">Gender*</h2>
                                                         
                                    <asp:DropDownList ID="ddlGender" class="form1" runat="server" Style="height:30px;width:52.8%;float:left; margin-left: 18.2%;">
                    <asp:ListItem Value="0" Selected="True" Text="Male"></asp:ListItem>
                     <asp:ListItem Text="Female" Value="1"></asp:ListItem>
                  
                </asp:DropDownList>
                      </div>
 <%--       <div id="Div2" class="eachform" style="width: 98%;margin-top:1%;">

                <h2 style="margin-top:1%;width: 8%;margin-left: 20%;">Currency*</h2>

               


            </div>--%>

               <%-- <div class="eachform"  style="width:57%;padding-top: 2%;">--%>
                  <%--<h2>Status*</h2>--%>
             
                 <div class="eachform" id="ButtnDiv" runat="server" style="width: 21%;  float: right;margin-top: 0%;">
                    <div class="subform" style="width: 58%; margin-left: 37%;padding: 2%;border: 2px solid rgb(207, 204, 204);margin-right: 3%;">
                         
                     <asp:Button ID="UpdateAddtn" runat="server" class="save" style="display:none;width:95%" Text="Update" OnClientClick="return ValidateVisaQuotaDetails();" onclick="btnUpdate_VisaDtls_Click"  />
                     <asp:Button ID="SaveAddtn" style="width:95%" runat="server"  class="save" Text="Save" OnClientClick="return ValidateVisaQuotaDetails();"  onclick="btnAdd_Addtn_Click" />
                     <asp:Button ID="ClearAddtn"  runat="server" style="margin-left: 2px;width:95%" OnClientClick="return AlertClearVisaDetails();"  class="cancel" Text="Clear"/>
                        </div>
                     </div>
                 <div id="divReport" class="table-responsive" runat="server" style="margin-left: 3.2%;margin-bottom: 1%;margin-top: 2%;font-family: Calibri;">
            <br />
          
                   <%--  style="margin-left: 3.2%;margin-bottom: 1%;"--%>
        </div>
                <br /><br /><br />
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
                 </div>
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

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="return CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

       
    </div>
     <div id="divLoading" class="model"  >
            <div class="eachform" style="width:55%; height:55%; padding-left:46%; padding-top:9%;">
                 <img src="/Images/Other Images/LoadingMail.gif" style="width:18%;" />
                 </div>
      </div>
      <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
         
     <style>
          .open > .dropdown-menu {
            display: none;
        }
      
         .dataTables_wrapper .dataTables_filter {
    float: right;
    text-align: right;
     margin-bottom: .5%;
}
         </style>

</asp:Content>



