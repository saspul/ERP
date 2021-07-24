<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Water_Card_Recharge.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Water_Card_Recharge_gen_Water_Card_Recharge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="../../../JavaScript/jquery_2.1.3_jquery_min.js"></script>
    <link href="../../../JavaScript/ToolTip/jBox.css" rel="stylesheet" />
    <script src="../../../JavaScript/ToolTip/jBox.js"></script>

    <script>

        javascript
        new jBox('Tooltip', {
            attach: '.tooltip'
        });




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
                       window.location.href = "gen_Water_Card_Recharge_List.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Water_Card_Recharge_List.aspx";

               }
           }


           function ConfirmCancel() {
               if (confirmbox > 0) {
                   if (confirm("Are You Sure You Want To Leave This Page?")) {
                       return true;
                   }
                   else {
                       return false;
                   }
               }
               else {
                   return true;;

               }
           }
           function AlertClearAll() {
               if (confirmbox > 0) {
                   if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                       window.location.href = "gen_Water_Card_Recharge.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Water_Card_Recharge.aspx";

               }
           }


           function RedirectConFirm(RechargeId) {
               if (confirm("Do you want to confirm this Entry?")) {
                   if (document.getElementById("<%=hiddenBackToCard.ClientID%>").value == "0") {
                       window.location.href = "gen_Water_Card_Recharge.aspx?Id=" + RechargeId + "&&InsUpd=CnfrmPnd";
                   }
                   else {
                       window.location.href = "gen_Water_Card_Recharge.aspx?Id=" + RechargeId + "&&InsUpd=CnfrmPnd&&BckCrd=Act";
                   }
               }
               else {

                   if (document.getElementById("<%=hiddenBackToCard.ClientID%>").value == "0") {
                       window.location.href ="gen_Water_Card_Recharge.aspx?InsUpd=Ins";
                   }
                   else {
                       window.location.href = "/AWMS/AWMS_Master/gen_Water_Card_Master/gen_Water_Card_Master_List.aspx?InsUpd=RechIns";
                   }
               }
           }
           function RedirectConFirmAdCls(RechargeId) {
               if (confirm("Do you want to confirm this Entry?")) {
                   if (document.getElementById("<%=hiddenBackToCard.ClientID%>").value == "0") {
                       window.location.href = "gen_Water_Card_Recharge.aspx?Id=" + RechargeId + "&&InsUpd=CnfrmPnd";
                   }
                   else {
                       window.location.href = "gen_Water_Card_Recharge.aspx?Id=" + RechargeId + "&&InsUpd=CnfrmPnd&&BckCrd=Act";
                   }
               }
               else {

                   if (document.getElementById("<%=hiddenBackToCard.ClientID%>").value == "0") {
                       window.location.href = "gen_Water_Card_Recharge_List.aspx?InsUpd=Ins";
                   }
                   else {
                       window.location.href = "/AWMS/AWMS_Master/gen_Water_Card_Master/gen_Water_Card_Master_List.aspx?InsUpd=RechIns";
                   }
               }
           }


           function ConfirmAlert() {
             
               if (WaterCardValidate() == true) {
                   if (confirm("Are You Sure You Want To Confirm?")) {
                       return true;
                   }
                   else {
                       AmountChecking('cphMain_txtRechargeAmount');
                       AmountChecking('cphMain_txtFinalAmount');
                       AmountChecking('cphMain_txtBalanceAmount');
                           CheckSubmitZero();
                           return false;
                   }
               }
               else {
                       return false;
               }
           }
    </script>

     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
           
            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {

                IncrmntConfrmCounter();
            }
            
            AmountChecking('cphMain_txtRechargeAmount');
            AmountChecking('cphMain_txtFinalAmount');
            AmountChecking('cphMain_txtBalanceAmount');
            //__doPostBack('<%=ddlCardNumber.ClientID %>', '');
           

        });
       
    </script>

        <script type="text/javascript">

            function SuccessConfirmation() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Water Card Recharge Details Inserted Successfully.";
            }

            function SuccessUpdation() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Water Card Recharge Details Updated Successfully.";
        }

            function SuccessReOpen() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Water Card Recharge Details ReOpened Successfully.";
            }

            function SuccessConfirm(){
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Water Card Recharge Details Confirmed Successfully.";
            }

            function ConfirmedAlready() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirm Denied.Entry Is Already Confirmed.";
            }
            function FailedReOpen() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Re-Open Denied.Available Balance Is Lower Than Recharge Amount";
            }
            function ReOpenedAlrdy() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Re-Open Denied.Entry is Already Reopened.";
            }
            function ConfirmPnd() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Water Card Recharge Details Inserted Successfully.Confirmation Pending";
            }

        function WaterCardValidate() {
            var $noCon = jQuery.noConflict();
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
         
            // replacing < and > tags
            var RechAmntWithoutReplace = document.getElementById("<%=txtRechargeAmount.ClientID%>").value;
            var replaceText1 = RechAmntWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtRechargeAmount.ClientID%>").value = replaceText2;

            var RechDateWithoutReplace = document.getElementById("<%=txtRechargeDate.ClientID%>").value;
            var replaceCode1 = RechDateWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtRechargeDate.ClientID%>").value = replaceCode2;

            var RemarksWithoutReplace = document.getElementById("<%=txtRemarks.ClientID%>").value;
            var replaceCode1 = RemarksWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtRemarks.ClientID%>").value = replaceCode2;

             
                document.getElementById("<%=ddlCardNumber.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtRechargeAmount.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtRechargeDate.ClientID%>").style.borderColor = "";

                var RechAmount = document.getElementById("<%=txtRechargeAmount.ClientID%>").value.trim();
                var RechDate = document.getElementById("<%=txtRechargeDate.ClientID%>").value.trim();

                var CardDdl = document.getElementById("<%=ddlCardNumber.ClientID%>");
                var CardText = CardDdl.options[CardDdl.selectedIndex].text;

                if (RechDate == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtRechargeDate.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtRechargeDate.ClientID%>").focus();
                 ret = false;
             }
             else {

                 var TaskdatepickerDate = document.getElementById("<%=txtRechargeDate.ClientID%>").value;
                 var arrDatePickerDate = TaskdatepickerDate.split("-");
                 var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                 var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                if (dateDateCntrlr > dateCurrentDate) {

                    document.getElementById("<%=txtRechargeDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtRechargeDate.ClientID%>").focus();
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,  Recharge Date should be less than Current Date!.";

                    ret = false;
                }
                }
            if (RechAmount == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtRechargeAmount.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtRechargeAmount.ClientID%>").focus();
                 ret = false;
             }

                if (CardText == "--SELECT--") {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=ddlCardNumber.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlCardNumber.ClientID%>").focus();
                    ret = false;
                }

        if (ret == false) {
            CheckSubmitZero();

        }
        return ret;
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
            function isNumber(evt, textboxid) {
                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                var charCode = (evt.which) ? evt.which : evt.keyCode;

                var txtPerVal = document.getElementById(textboxid).value;
                //enter
                if (keyCodes == 13) {

                    if (textboxid == "cphMain_txtCalciText") {
                        CalculateAmount();
                        return false;
                    } else {
                        return false;
                    }
                   
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
                    var ret = true;
                    if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                        ret = false;
                    }
                    return ret;
                }
            }

            function CommonDecimalChecking(textboxid) {
                var txtPerVal =(document.getElementById(textboxid).value).split(',').join('');
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
                        var FloatingValue = document.getElementById("<%=hiddenDecimalCountCommon.ClientID%>").value;
                        if (FloatingValue != "") {
                            var n = num.toFixed(FloatingValue);
                        }
                        document.getElementById('' + textboxid + '').value =addCommas(n);

                    }
                }
            }

            function AmountChecking(textboxid) {
               // alert('hi amnt chckng');
                var txtPerVal = (document.getElementById(textboxid).value).split(',').join('');
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
                    document.getElementById('' + textboxid + '').value =addCommas(n);

                }
            }
        }
            function addCommas(nStr) {

                nStr += '';
                var x = nStr.split('.');
                var x1 = x[0];
                var x2 = x[1];
                //var a = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;
                 //alert('hi'+a);
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
                     return x1;
                 else
                     return x1 + "." + x2;
             }
            function AmountCheckPostback(textboxid) {

             
                document.getElementById("<%=ddlCardNumber.ClientID%>").focus();

                var txtPerVal = document.getElementById(textboxid).value;
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
                document.getElementById('' + textboxid + '').style.borderColor = "";
                var RechargeAmount = document.getElementById('' + textboxid + '').value;
                var BalanceAmount = document.getElementById("<%=hiddenBalanceAmount.ClientID%>").value;

                var TotalAmount = parseFloat(RechargeAmount) + parseFloat(BalanceAmount); 
                if (TotalAmount > 999999999.999) {
                    document.getElementById('' + textboxid + '').value = "";
                    return false;
                }
                if (isNaN(TotalAmount) == false) {
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    TotalAmount = TotalAmount.toFixed(FloatingValue);
                    document.getElementById('cphMain_txtFinalAmount').value = TotalAmount;
                }
                else {
                    var Error = 0;
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    Error = Error.toFixed(FloatingValue);
                    document.getElementById('cphMain_txtFinalAmount').value = Error;
                }


            }

            function AmountCheck(textboxid) {
              // alert('kooi');

               var txtPerVal = (document.getElementById(textboxid).value).split(',').join('');
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
                        var a = document.getElementById('' + textboxid + '').value;
                        document.getElementById('' + textboxid + '').value =addCommas(n);

                    }
                }
                document.getElementById('' + textboxid + '').style.borderColor = "";
                var RechargeAmount = a;
                var BalanceAmount = document.getElementById("<%=hiddenBalanceAmount.ClientID%>").value;

                var TotalAmount = parseFloat(RechargeAmount) + parseFloat(BalanceAmount);
                if (TotalAmount > 999999999.999) {
                    document.getElementById('' + textboxid + '').value = "";
                    return false;
                }
                if (isNaN(TotalAmount) == false) {
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    TotalAmount = TotalAmount.toFixed(FloatingValue);
                    document.getElementById('cphMain_txtFinalAmount').value = addCommas(TotalAmount);
                }
                else {
                    var Error = 0;
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    Error = Error.toFixed(FloatingValue);
                    document.getElementById('cphMain_txtFinalAmount').value = Error;
                }


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
        function ClearImage() {
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


            function ConfirmReOpen() {
                if (confirm("Are You Sure You Want To ReOpen This Page?")) {
                    return true;
                }
                else {
                    return false;
                }
            }
    </script>
        
             
        <%--for delete image description--%>
     <script>
         function ImagePosition(object) {

             var $Mo = jQuery.noConflict();

             var offset = $Mo("#" + object).offset();

             var posY = 0;
             var posX = 0;
             posY = offset.top;

             posX = offset.left

             posX = 55.1;

             var d = document.getElementById('RemovePhoto');
             d.style.position = "absolute";
             d.style.left = posX + '%';
             d.style.top = posY + 15 + 'px';
         }

         function VisibleCalc() {
             if (document.getElementById('divCalculator').style.visibility == "visible") {
                
                 document.getElementById('divCalculator').style.visibility = "hidden";
                 document.getElementById('cphMain_txtCalciText').value ="";
                 document.getElementById('cphMain_lblCalciAmnt').textContent = "";

             }
             else {
                
           
                 document.getElementById('divCalculator').style.visibility = "visible";
               
             }
         }


         function CalculateAmount() {

             var RechargeAmount = document.getElementById("<%=hiddenAmountPerBarrel.ClientID%>").value;
             var NoOfTrip = (document.getElementById("<%=txtCalciText.ClientID%>").value).split(',').join('');;
             var TotalAmount = parseFloat(RechargeAmount) * parseFloat(NoOfTrip);
             var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
             if (FloatingValue != "") {
                 var Amount = TotalAmount.toFixed(FloatingValue);
             }
             if (isNaN(Amount) == false) {
                 document.getElementById("<%=lblCalciAmnt.ClientID%>").textContent = addCommas(Amount);
             }
             else {
                 var Error = 0;
                 Error = Error.toFixed(FloatingValue);
                 document.getElementById("<%=lblCalciAmnt.ClientID%>").textContent = Error;
             }
             return false;
         
         }
         function BalanceAmount() {
   
             var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
             var Amount = document.getElementById("<%=txtBalanceAmount.ClientID%>").text;

             Amount = Amount.toFixed(FloatingValue);

             document.getElementById("<%=txtBalanceAmount.ClientID%>").text = Amount;

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
    </style>
        <%--FOR DATE TIME PICKER--%>
<script type="text/javascript" src="../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>                      
<script type="text/javascript" src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
<script type="text/javascript" src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
<script type="text/javascript"src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
<link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
<link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
      <style>
             /*for file upload*/
        /*input[type="file"] {*/
        .fileUpload {
            margin-left: -17%;
            position: relative;
            z-index: 1;
        }

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


        .imgWrap:hover .imgDescription {
            visibility: visible;
            opacity: 1;
        }
        .LabelName {
    font-family: Calibri;
    font-size: 14px;
    float: left;
    text-align: left;
    /*color: #536533;*/
    padding-left: 4px;
    margin: 6px 0 0px;
    line-height: 2;
    font-weight: normal;
    float: left;
}
    </style>
         <style>
         .colmcenter {
             width: 75%;
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

                    .form-group p {
            color: red;
            margin-top: 1%;
            margin-left: 40%;
        }



        #cphMain_mydiv {
            background: #C2DFEF;
            text-align: left;
            overflow: auto;
            margin-left: 14.5%;
            max-height: 220px;
            margin-top:-2%;
        }


        .form2 label {
        padding-left:1.5%;
        }
        #cphMain_divImageDisplay a {
            color:rgb(40, 111, 150);
        }
         #cphMain_divImageDisplay a:hover {
            color:rgb(52, 165, 239);
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
       #cphMain_mydiv td {
            border-right:0px;
        }
        #cphMain_cbxlCorporateOffc {
        width:100%;
        }
      
    #goofy {
            right:17%;
            top:51px;
            width:60%;
        }
    .open > .dropdown-menu {
    display: none;
}
     .eachform h2 {
                margin: 6px 0 6px;
            }


     #divCalculator {
    width: 90%;
    height: 200px;
    border: 2px ridge;
     background-image:url("/Images/Icons/calciBaground4.jpg");
    /*background-color: #f8f8f8;*/
    border-color: #d7d7d7;
    visibility: hidden;
    margin-left:10%;
}


             #divCalciHead {
                 display: inline-block;
                 text-align: center;
                 height: 30px;
                 width: 99%;
                 background-image:url("/Images/Icons/calci_head.png");
                 /*background-color: #8cd8d0;*/
                 border: 2px ridge;
                 /*border-style: inset;*/
                 border-color: #dad8d5;
             }
             #cphMain_lblCalciAmnt {
                 display: inline-block;
                 text-align: right;
                 height: 30px;
                 width: 93%;
                 font-family: calibri;
                 font-size: 20px;
                 color: #4A4A4A;
                 float: right;
                 margin-right: 2%;
                 background-color: white;
                 border: 1px solid;
                 border-color: #9e9c9c;
                 padding-right: 7px;
             }

  </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="hiddenRechargeFile" runat="server" />
     <asp:HiddenField ID="hiddenRechargeFileDeleted" runat="server" />
    <asp:HiddenField ID="hiddenRechargeFileAct" runat="server" />
       
    <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />
        <asp:HiddenField ID="hiddenRoleReOpen" runat="server" />
     <asp:HiddenField ID="hiddenPermitFileSize" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCountCommon" runat="server" />
    <asp:HiddenField ID="hiddenBackToCard" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <div class="cont_rght">
        

                   <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>

        <br />


          <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:6%; top:140px;height:26.5px;">

          <%--   <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>
                     
        <div class="fillform" style="width:95%;">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />
            <div id="divImage" style="float: right;margin-right:30%;margin-top:-7%">
                       
                        <asp:ImageButton ID="imgbtnReOpen" runat="server" OnClientClick="return ConfirmReOpen();" Style="margin-left: 0%;" OnClick="imgbtnReOpen_Click" />
                         <p id="imgReOpen" class="imgDescription" style="color: white">ReOpen Confirmed Entry</p>
                    </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                     <asp:HiddenField ID="hiddenBalanceAmount" runat="server" />
                     <asp:HiddenField ID="hiddenAmountPerBarrel" runat="server" />


            <div style="float:left;width:60%"> 
               <div class="eachform">
                   <h2>Card Number*</h2>
                    <asp:DropDownList ID="ddlCardNumber" Height="30px" Width="54.5%" class="form1"  onkeydown="return DisableEnter(event)" OnSelectedIndexChanged="ddlCardNumber_SelectedIndexChanged" AutoPostBack="true" runat="server" Style="margin-right: 3%;"></asp:DropDownList>
                   </div> 
                 <div class="eachform">
                      <h2>Vehicle Number</h2>
                      <asp:TextBox ID="txtVehicleNumber" Enabled="false" Height="30px" Width="51.5%" class="form1" runat="server" MaxLength="12" Style="text-transform: uppercase;text-align:right; margin-right: 3%;"></asp:TextBox>
                   
                     </div>
                 <div class="eachform">
                      <h2>Card Name</h2>
                      <asp:TextBox ID="txtCardName" Enabled="false" Height="30px" Width="51.5%" class="form1" runat="server" MaxLength="12" Style="text-transform: uppercase;text-align:right; margin-right: 3%;"></asp:TextBox>
                   
                     </div>
                           
            <div class="eachform">

                <h2>Balance Amount</h2>
                 <asp:TextBox ID="txtBalanceAmount" Enabled="false" Height="30px" Width="51.5%" class="form1" runat="server" MaxLength="12" Style="text-transform: uppercase;text-align:right; margin-right: 3%;"  onchange="AmountChecking('cphMain_txtBalanceAmount');" ></asp:TextBox>
            </div>


                </div>

                                <div style="float:right;width:37%">

                <div id="divCalciPic" runat="server" style="width: 20%;cursor:pointer;" onclick="VisibleCalc();">
                    <img title="Trip Amount Calculator" id="img3" src="/Images/Icons/icon_calculator.jpg" alt="Clear" />
                </div>

                <div id="divCalculator">
                    <div id="divCalciHead">
                         <asp:Label ID="lblCalci" class="" runat="server" style="display:inline-block;text-align:center; height:30px;width:80%;font-family: calibri;font-size: 20px;color: #C8DDA4;">Calculator</asp:Label>
                    <img id="imgCloseCalci" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="Clear" style="float: right;margin-top: 7px;margin-right: 6px;cursor: pointer;" onclick="VisibleCalc();" />
                    </div>

                    <%--<img id="imgCalci" src="/Images/Icons/Calculator-icon.png" alt="Clear" style="float: left;margin-left: 4%;margin-top: 7%;" />--%>
                  <div style="width: 100%;">
                    
                      <div style="width: 100%;margin-top: 5%;">
                    <h2 style="margin:6px 10px 0px;font-size:17px;font-family: calibri;color:#60635a;float:left">No. Of Trips</h2>
                 <asp:TextBox ID="txtCalciText" class="form1" runat="server" MaxLength="9" Style="resize: none;width:25%; text-align:right; margin-left: 3%;float:left; font-family:Calibri" onkeydown="return isNumber(event,'cphMain_txtCalciText');" onblur="CommonDecimalChecking('cphMain_txtCalciText');"></asp:TextBox>
                    <asp:ImageButton runat="server" id="img2" src="/Images/Icons/calci Equal_sign.png" alt="Clear" style="float: left;cursor:pointer; margin-left: 7%;margin-top: -5%;" onclientclick="return CalculateAmount();" />
                           </div>

                    
           
                     <div style="float:right;width: 100%;margin-top: 2%;">
                         <label style="margin:5px 0 0px;font-size:24px;color: #6b6b65;margin-left: 36%;font-family: calibri;">Amount :</label>
                         </div>
                      <div style="float:right;width: 100%;margin-top: 4%;">
                     <asp:Label ID="lblCalciAmnt" runat="server"></asp:Label>
                     </div>
                      </div>
                    
                     </div>


                </div>




                                         </ContentTemplate>
            </asp:UpdatePanel>
                       <div style="float:left;width:60%"> 

              <div class="eachform">

                <h2>Recharge Amount*</h2>
                <asp:TextBox ID="txtRechargeAmount" Height="30px" Width="51.5%" class="form1" runat="server" MaxLength="12" Style="text-transform: uppercase;text-align:right; margin-right: 3%;" onkeydown="return isNumber(event,'cphMain_txtRechargeAmount');" onblur="AmountCheck('cphMain_txtRechargeAmount');"></asp:TextBox>

            </div>
            <div class="eachform">

                <h2>Final Amount</h2>
                 <asp:TextBox ID="txtFinalAmount" Enabled="false" Height="30px" Width="51.5%" class="form1" runat="server" MaxLength="12" Style="text-transform: uppercase;text-align:right; margin-right: 3%;" onblur="AmountCheck('cphMain_txtFinalAmount');"></asp:TextBox>
            </div>

            <div class="eachform">

                <h2>Remarks</h2>
                 <asp:TextBox ID="txtRemarks" class="form1" runat="server" MaxLength="500" Width="51.5%" Height="115px" TextMode="MultiLine" Style="resize: none; margin-right: 3%;font-family:Calibri" onkeydown="textCounter(cphMain_txtRemarks,450)" onkeyup="textCounter(cphMain_txtRemarks,450)"></asp:TextBox>

            </div>
             <div class="eachform">
                 <h2>Recharge Date*</h2>
               <div id="RechargeDate" class="input-append date" style="font-family:Calibri;float:right;width:50%;margin-right: 8%;">
                 <asp:TextBox ID="txtRechargeDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event)" Style="width:98.8%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <img id= "img1" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#RechargeDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                endDate: new Date(),
                            });

                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>
                         <div  class="eachform" style="width: 97%;margin-top:1%;">
              
               


                <h2 style="margin-top: 1%;">Attach Recharge Invoice</h2>
                <label for="cphMain_FileUploadRecharge" class="custom-file-upload" tabindex="0">
                    <img src="/Images/Icons/cloud_upload.jpg" />Upload File</label>
                <%--<input id="file" name = "file" type="file" onchange="ClearDivDisplayImage()" accept="image/png, image/gif, image/jpeg" />--%>

                <asp:FileUpload ID="FileUploadRecharge" class="fileUpload" runat="server" Style="height: 30px; display:none;" onchange="ClearDivDisplayImage()" Accept="All" />


                <div id="divImageEdit" runat="server" style="float: right; width: 54%; height: 20px; margin-top: -1%;">
                    <div class="imgWrap">
                        <img id="ClearImage" src="/Images/Icons/clear-image-green.png" alt="Clear" onclick="ClearImage()" onmouseover="ImagePosition('ClearImage')"; style="cursor: pointer; float: right;" />
                        <p id="RemovePhoto" class="imgDescription" style="color: white">Remove Selected Photo</p>
                    </div>
                    <div id="divImageDisplay" runat="server">
                    </div>
                </div>
                <asp:Label ID="Label3" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
           
            </div>

                </div>
                                       





            </div>

            <br />
            <div class="eachform">
                <div class="subform" style="width: 62%; margin-top:5%;margin-right: 17%;">

                    <asp:Button ID="btnConfirm" runat="server" class="save" Text="Confirm" OnClick="btnConfirm_Click" OnClientClick="return ConfirmAlert();"/>
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return WaterCardValidate();"/>
                      <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return WaterCardValidate();"/>
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return WaterCardValidate();"/>
                     <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return WaterCardValidate();"/>
                     <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmCancel()" OnClick="btnCancel_Click"/>
                    <asp:Button ID="btnClear" runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAll();" OnClick="btnClear_Click" class="cancel" Text="Clear"/>
               
                </div>
            </div>

        </div>
</asp:Content>

