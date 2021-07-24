<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Receipt_Account.aspx.cs" Inherits="FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
         <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
    <script src="/js/Common/Common.js"></script>
    
    <style>
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

        .ui-autocomplete {
            position: absolute;
            cursor: default;
            z-index: 4000 !important;
        }
    </style>
    <script>
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
         
            confirmbox++;
        }
       

        function c() {
            confirmbox++;
            return false;
        }
        function AlertClearAll() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Receipt_Account.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "fms_Receipt_Account.aspx";
                return false;
            }
            return false;
        }
        function ConfirmMessage() {
                    
             if (confirmbox > 0) {
                 ezBSAlert({
                     type: "confirm",
                     messageText: "Are you sure you want to leave this page?",
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         window.location.href = "fms_Receipt_Account_List.aspx";
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 window.location.href = "fms_Receipt_Account_List.aspx";
                 return false;
             }
        }

        function changeBankAcNum() {
            PaymentCounter();
            var ret = "true";
            //document.getElementById("cphMain_ddlChequeBank").style.borderColor = "";
            //document.getElementById("txtRcAcntNum" + CurrRowId).style.borderColor = "";
            var RcptBankCurr = document.getElementById("cphMain_ddlChequeBank").value.trim();
            var RcptAcntNumCurr = document.getElementById("cphMain_txtChequeNo_Cheque").value.trim();
            if (RcptBankCurr != "" && RcptAcntNumCurr != "") {

                var UpdateId = 0;
                if (document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value != "") {
                    UpdateId = document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value;
                }

                //         $.ajax({
                //             async: false,
                //             type: "POST",
                //             url: "fms_Receipt_Account.aspx/CheckDupBankAcNum",
                //             data: '{RcptBankCurr:"' + RcptBankCurr + '",RcptAcntNumCurr:"' + RcptAcntNumCurr + '",UpdateId:"' + UpdateId + '"}',
                //             contentType: "application/json; charset=utf-8",
                //             dataType: "json",
                //             success: function (response) {
                //                 if (response.d == "false") {
                //                     document.getElementById("cphMain_ddlChequeBank").style.borderColor = "red";
                //                     document.getElementById("cphMain_ddlChequeBank" ).focus();

                //                     document.getElementById("cphMain_txtChequeNo_Cheque").style.borderColor = "red";
                //                     document.getElementById("cphMain_txtChequeNo_Cheque" ).focus();

                //                     $noCon("#divWarning").html("Duplication is not allowed for cheque number!");
                //                     $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                //                     });
                //                     $noCon(window).scrollTop(0);
                //                     ret = "false";

                //                 }

                //             },
                //             failure: function (response) {
                //                 ret = "true";
                //             }

                //});

            }
            if (ret == "false") {
                return false;
            }
            else {
                return true;
            }
            //}
            // return false;
        }

        function AccntChangeFunt(mode) {
           
            if (mode == "1" && document.getElementById("cphMain_hiddenSelectedAccntBk").value != "--SELECT--") {
                IncrmntConfrmCounter();
            }
            if (document.getElementById("cphMain_ddlAccontLed").value != 0 && document.getElementById("cphMain_ddlAccontLed").value != "--SELECT--") {
                var ddlOldAccntId = document.getElementById("cphMain_ddlAccontLed").value;
                var ddlAccntId = document.getElementById("cphMain_ddlAccontLed").value;
                if (confirmbox > 1) {
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to change the account book?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                          
                           document.getElementById("cphMain_hiddenSelectedAccntBk").value = document.getElementById("cphMain_ddlAccontLed").value;
                        }
                        else {
                            
                            var PrevsVal = document.getElementById("cphMain_hiddenSelectedAccntBk").value;
                            var sel = $("#cphMain_ddlAccontLed option[value='" + PrevsVal + "']").text();
                            $('#cphMain_ddlAccontLed').val(PrevsVal);
                            $("#divAccount > input").val(sel);
                            return false;
                        }
                       
                        return false;
                    });
                  // IncrmntConfrmCounter();
                    //return false;
                }

                IncrmntConfrmCounter();
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';

                $noCon.ajax({
                    type: "POST",
                    url: "fms_Receipt_Account.aspx/AccntBalanceLedger",
                    data: '{intLedgerId:"' + ddlAccntId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {


                        if (response.d[0] != "0") {
                            nStr = response.d[0];
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




                            if (isNaN(x2)) {
                                document.getElementById("cphMain_AccntBalance").innerHTML = "<i class=\"fa fa-money\"></i>" + x1 + " " + response.d[1] + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                            }
                                //return x1;
                            else {
                                document.getElementById("cphMain_AccntBalance").innerHTML = "<i class=\"fa fa-money\"></i>" + x1 + "." + x2 + " " + response.d[1] + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                            }
                            document.getElementById("lblCurrency").innerHTML = document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                            // return x1 + "." + x2;



                            // addCommas(cphMain_AccntBalance);


                        }
                            // document.getElementById("BtnPopup").click();


                        else {
                            document.getElementById("cphMain_AccntBalance").innerHTML = "";
                        }


                        if (response.d[2] == "True") {
                            document.getElementById("PaymentMode").style.display = "";
                            if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "") {
                                $('#liBankTransfer').removeClass('tablinks active').addClass('tablinks');
                                $('#BankTransfer').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                                $('#liDD').removeClass('tablinks active').addClass('tablinks');
                                $('#DD').removeClass('tab-pane fade active in').addClass('tab-pane fade');

                                $('#lisCheque').removeClass('tablinks').addClass('tablinks active');
                                $('#Cheque').removeClass('tab-pane fade').addClass('tab-pane fade active in');
                                document.getElementById("DD").style.display = "none";
                                document.getElementById("BankTransfer").style.display = "none";
                                document.getElementById("Cheque").style.display = "block";
                                document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "Cheque";
                            }
                        }
                        else {
                            document.getElementById("PaymentMode").style.display = "none";
                            document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "";

                        }


                    },
                    failure: function (response) {

                    }


                });


            }
            else {
                document.getElementById("cphMain_ddlAccontLed").value = "--SELECT--";
                document.getElementById("cphMain_AccntBalance").innerHTML = "";
                document.getElementById("PaymentMode").style.display = "none";
                document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "";

            }

        }
         function SuccessMsg() {

             $noCon("#success-alert").html("Receipt details inserted successfully.");
             $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
             });
             

             return false;


         }
         function SuccessUpdMsg() {

             $noCon("#success-alert").html("Receipt details updated successfully.");
             $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
             });
             

             return false;


         }
         function SundryDebtorSelect() {
             $noCon("#divWarning").html("Please define the primary account group for bank and cash in hand before creating new receipt");
             $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
             });
            
         }
         function PrintVersnError() {
             $noCon("#divWarning").html("Please select a version for printing from account setting.");
             $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
             });
            
             return false;
         }

         function AmountCalculationForOB(intLedgerId) {
             //EVM-0027 Aug 26
             var tdOpeningBlncArry = document.getElementById("tdOpeningBalnc" + intLedgerId).innerHTML.split(" ");
             var tdOpeningBlnc = tdOpeningBlncArry[0];
             //EVM-0027 Aug 26 END
             if (tdOpeningBlnc == "") {
                 tdOpeningBlnc = "0";
             }

             tdOpeningBlnc = tdOpeningBlnc.replace(/\,/g, '');
             var TotalOpeningBal = parseFloat(tdOpeningBlnc);

             var txtOpeningBlnc = document.getElementById("txtOpeningBalnc" + intLedgerId).value;
             addCommasSummry(txtOpeningBlnc);
             if (txtOpeningBlnc == "") {
                 txtOpeningBlnc = "0";
             }

             txtOpeningBlnc = txtOpeningBlnc.replace(/\,/g, '');
             var OpeningBal = parseFloat(txtOpeningBlnc);

             var lblLdgrAmt = document.getElementById("LedgerAmtInModalPurchse").innerHTML;
             if (lblLdgrAmt == "") {
                 lblLdgrAmt = "0";
             }
             lblLdgrAmt = lblLdgrAmt.replace(/\,/g, '');
             var SaleAmt = parseFloat(lblLdgrAmt);
         
            

             document.getElementById("txtOpeningBalnc" + intLedgerId).style.borderColor = "";
             if ((parseFloat(Math.abs(TotalOpeningBal)) >= parseFloat(OpeningBal)) && (parseFloat(SaleAmt) >= parseFloat(OpeningBal))) {
                 document.getElementById("SpanOpeningBalance" + intLedgerId).innerHTML = TotalOpeningBal - OpeningBal + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;

             }
             else {
               
                 document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the sales amount";
                 $("div.war").fadeIn(200).delay(500).fadeOut(400);
                 document.getElementById("txtOpeningBalnc" + intLedgerId).style.borderColor = "Red";

                 document.getElementById("txtOpeningBalnc" + intLedgerId).value = "";
                 document.getElementById("txtOpeningBalnc" + intLedgerId).focus();
                
                 return false;
             }
             //evm 0044
             setData("lblOpBalance", txtOpeningBlnc);
             loadSettleAmount(-1);

         }
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

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
           
            document.getElementById("cphMain_hiddenSelectedAccntBk").value = document.getElementById("cphMain_ddlAccontLed").value;
          
            $(".cur_ic").text(document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value);

            $("#divAccount > input").focus();
            $("#divAccount > input").select();
            //EVM-0027 12-04
            document.getElementById("cphMain_txtDesc").value=  document.getElementById("cphMain_txtDesc").value.trim();
            AccntChangeFunt("0");

            document.getElementById("lblCurrency").innerHTML = document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
            if (document.getElementById("<%=HiddenPaymode.ClientID%>").value == "0")
                ChangePaymentode("Cheque_tab");
            else if (document.getElementById("<%=HiddenPaymode.ClientID%>").value == "1")
                ChangePaymentode("DD_tab");
            else if (document.getElementById("<%=HiddenPaymode.ClientID%>").value == "2")
                ChangePaymentode("BankTransfer_tab");
            if (document.getElementById("<%=HiddenPaymode.ClientID%>").value == "0" && document.getElementById("<%=txtChequeNo_Cheque.ClientID%>").value == "") {
            }
            else {
                PaymentCounter();
            }
            document.getElementById("<%=btnConfirm1.ClientID%>").style.display = "none";
            //insert();
            //   FunctStsChkBxFill();
            addCommas("cphMain_txtTotalAmt");
            if (EditVal == "" && ViewVal=="") {
                document.getElementById("<%=txtTotalAmt.ClientID%>").value = "";
            }
            else {
                document.getElementById("<%=txtTotalAmt.ClientID%>").value = document.getElementById("<%=txtTotalAmt.ClientID%>").value + " " + document.getElementById("<%=HiddenCRNCYABRVTN.ClientID%>").value
            }

            var EditVal = document.getElementById("<%=HiddenEdit.ClientID%>").value;
            var ViewVal = document.getElementById("<%=HiddenViewDtls.ClientID%>").value;
            if (EditVal != "") {
                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = EditVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].LDGR_ID != "") {
                            EditListRows(json[key].RCPT_ID, json[key].RCPT_LDGR_ID, json[key].LDGR_ID, json[key].LDGR_AMT, json[key].LDGR_NAME, json[key].ROW_COUNT, json[key].PYMNT_CST_ID, json[key].COSTCNTR_ID, json[key].PYMNT_CST_AMT, json[key].PURCHS_ID, json[key].RECPT_PURCHS_REF, json[key].COST_LD, json[key].SALES_ID, json[key].LDGR_REMARKS, json[key].OB_PAID);
                        }
                    }
                }
                var x = 0;
                buttnVisibile(x);
            }
            else if (ViewVal != "") {




                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = ViewVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].LDGR_ID != "") {
                            ViewListRows(json[key].RCPT_ID, json[key].RCPT_LDGR_ID, json[key].LDGR_ID, json[key].LDGR_AMT, json[key].LDGR_NAME, json[key].ROW_COUNT, json[key].PYMNT_CST_ID, json[key].COSTCNTR_ID, json[key].PYMNT_CST_AMT, json[key].PURCHS_ID, json[key].RECPT_PURCHS_REF, json[key].COST_LD, json[key].SALES_ID, json[key].LDGR_REMARKS, json[key].OB_PAID);
                        }
                    }
                }
                var x = 0;
                buttnVisibile(x);
            }
            else {
            }

            if (ViewVal == "" && EditVal == "") {
                AddNewGroup();
            }


            if (document.getElementById("<%=hiddenPostdated.ClientID%>").value == "1") {             
                document.getElementById("lisCheque").disabled = true;
                document.getElementById("liDD").disabled = true;
                document.getElementById("liBankTransfer").disabled = true;
            }



        });


    </script>

    <script>


       

        var rowSubCatagory = 0;
        var RowIndex1 = 0;

        function AddNewGroup() {
            RowIndex1++;
            var FrecRow = '';
            FrecRow = '<tr class="tr1" id="SubGrpRowId_' + RowIndex1 + '" ><td   id="tdidGrpDtls' + RowIndex1 + '" style="display: none" >' + RowIndex1 + '</td>';
            // FrecRow += '<td>';
            FrecRow += '<div style="clear:both"></div><div style="display:none" id="groupSubCat' + RowIndex1 + '">' + rowSubCatagory + '</div> ';
            var yy = rowSubCatagory + 1;
            FrecRow += ' <td ><div id="divLedger' + RowIndex1 + '"><select onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);" onchange="return showBalenceAmt(\'' + RowIndex1 + '\',\'' + yy + '\');"   class="fg2_inp2 fg2_inp3 fg_chs1 ddl" id="ddlRecptLedger' + RowIndex1 + '" >';
            FrecRow += '</select> <span class="input-group-addon cur2" id="AccntBalance_' + RowIndex1 + '"><i class="fa fa-money"></i></span></div><input class="form-control" style="display:none" name="ddlLedId' + RowIndex1 + '"  value="0" id="ddlLedId' + RowIndex1 + '" type="text"></td>';
     
            FrecRow += ' <td class=" tr_r" > <div class="input-group"> <span class="input-group-addon cur1"><label for="example-text-input" class="col-form-label" >' + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value + '</label></span><input class="form-control fg2_inp2 tr_r" onkeydown="return CheckSalesDetails(event,\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'' + yy + '\');"  onkeypress="return  CheckSalesDetails(event,\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'' + yy + '\');" name="TxtAmount_' + RowIndex1 + '"  MaxLength="10"  onblur="return PendingSales(\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'' + yy + '\' );"    value="" id="TxtAmount_' + RowIndex1 + '" type="text"  autocomplete=\'off\'></div> </td>';
            FrecRow += '<td > <textarea   name="TxtRemark' + RowIndex1 + '"    value="" id="TxtRemark' + RowIndex1 + '"   rows="3" cols="20"  class="form-control" style="resize: none;" onkeydown="textCounter(TxtRemark' + RowIndex1 + ',450)" onkeyup="textCounter(TxtRemark' + RowIndex1 + ',450)"></textarea></td>';
            FrecRow += '    <td class="td1">';
            FrecRow += ' <div class="btn_stl1"><button title="ADD"  id="journalADD' + RowIndex1 + '" onclick="return FuctionAddGroup(\'' + RowIndex1 + '\')" class="btn act_btn bn2" ><span   class="fa fa-plus"  style="display: block;">&nbsp;</span></button><button title="DELETE" id="bttnRemovGrp' + RowIndex1 + '"   onclick="return removeRowGrps(' + RowIndex1 + ',\'Are you sure you want to delete this ledger?\')" class="btn act_btn bn3" >';
            FrecRow += ' <span class="fa fa-trash"   style="display: block;">&nbsp;</span></button></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" value="" style="display:none;"  id="tdRcptLdgrId' + RowIndex1 + '" name="tdRcptLdgrId' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td ><a href="javascript:void(0)" title="SALE" id="ChkSale' + RowIndex1 + '"  onclick="return ddlLedOnchange(\'' + RowIndex1 + '\',\'ins\');" ><i id="iSaleTag' + RowIndex1 + '" class="fa fa-balance-scale ad_fa"></i></a>';
            FrecRow += '<a   href="javascript:void(0)"  title="COST CENTRE" id="ChkCostCenter' + RowIndex1 + '"  onclick="MyModalCostCenter(\'' + RowIndex1 + '\',\'' + rowSubCatagory + '\',null);" ><i class="fa fa-filter ad_fa"></i></a></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowIndex1 + '" name="tdCostCenterDtls' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterSTS' + RowIndex1 + '" name="tdCostCenterSTS' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdSalesDtls' + RowIndex1 + '" name="tdSalesDtls' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" value="INS" style="display:none;"  id="tdEvtGrp' + RowIndex1 + '" name="tdEvtGrp' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdTempid' + RowIndex1 + '" name="tdDtlIdTempid' + RowIndex1 + '" placeholder=""/><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdGrp' + RowIndex1 + '" name="tdDtlIdGrp' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdInxGrp' + RowIndex1 + '" name="tdInxGrp' + RowIndex1 + '" placeholder=""/> </td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdLedgrPaid' + RowIndex1 + '" name="tdLedgrPaid' + RowIndex1 + '" /> </td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdOpenSts' + RowIndex1 + '" name="tdOpenSts' + RowIndex1 + '" /> </td>';

            FrecRow += '</tr>';
            jQuery('#tableGrp').append(FrecRow);

            var valuesSel = "";
            FillddlRcptLedger(RowIndex1, valuesSel);
            $au("#ddlRecptLedger" + RowIndex1).selectToAutocomplete1Letter();
            if (RowIndex1 != "1") {  //Koooiii
                $("#divLedger" + RowIndex1 + "> input").focus();
                $("#divLedger" + RowIndex1 + "> input").select();
            }



            return false;

        }
        function EditListRows(RCPT_ID, RCPT_LDGR_ID, LDGR_ID, LDGR_AMT, LDGR_NAME, ROW_COUNT, PYMNT_CST_ID, COSTCNTR_ID, PYMNT_CST_AMT, PURCHS_ID, RECPT_PURCHS_REF, COST_LD, SALES_ID, LDGR_REMARKS, OB_PAID) {
            document.getElementById("<%=HiddenLedgerId.ClientID%>").value = RCPT_LDGR_ID;
            RowIndex1++;
            var FrecRow = '';
            FrecRow = '<tr class="tr1"  id="SubGrpRowId_' + RowIndex1 + '" ><td   id="tdidGrpDtls' + RowIndex1 + '" style="display: none" >' + RowIndex1 + '</td>';
            FrecRow += '<div style="clear:both"></div><div style="display:none" id="groupSubCat' + RowIndex1 + '">' + rowSubCatagory + '</div> ';
            var yy = rowSubCatagory + 1;
            FrecRow += ' <td ><div id="divLedger' + RowIndex1 + '"><select   onchange="return showBalenceAmt(\'' + RowIndex1 + '\',\'' + yy + '\');"  onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);" class="fg2_inp2 fg2_inp3 fg_chs1 ddl ddl" id="ddlRecptLedger' + RowIndex1 + '" >';
            FrecRow += '</select><span class="input-group-addon cur2" id="AccntBalance_' + RowIndex1 + '"><i class="fa fa-money-check-alt"></i></span></div><input class="form-control" style="display:none" name="ddlLedId' + RowIndex1 + '"  value=' + LDGR_ID + ' id="ddlLedId' + RowIndex1 + '" type="text"></td>';

           
            FrecRow += ' <td class=" tr_r" ><div class="input-group"> <span class="input-group-addon cur1"><label for="example-text-input" class="col-form-label" >' + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value + '</label></span> <input class="form-control fg2_inp2 tr_r" onkeydown="return CheckSalesDetails(event,\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'' + yy + '\');"  onkeypress="return  CheckSalesDetails(event,\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'' + yy + '\');" name="TxtAmount_' + RowIndex1 + '"  MaxLength="10"  onblur="return PendingSales( \'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'' + yy + '\' );"    value=' + LDGR_AMT + ' id="TxtAmount_' + RowIndex1 + '" type="text"  autocomplete=\'off\' > </td>';
            //FrecRow += ' <td ><input class="form-control"onkeydown="return CheckSalesDetails(event,\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'' + yy + '\');"  onkeypress="return  CheckSalesDetails(event,\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'' + yy + '\');" name="TxtAmount_' + RowIndex1 + '"  MaxLength="10"  onblur="return PendingSales( \'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'' + yy + '\' );"    value=' + LDGR_AMT + ' id="TxtAmount_' + RowIndex1 + '" type="text"  autocomplete=\'off\'  style="text-align: right;"> </td>';
            FrecRow += '<td > <textarea name="TxtRemark' + RowIndex1 + '"    value=' + LDGR_REMARKS + ' id="TxtRemark' + RowIndex1 + '"   rows="3" cols="20"  class="form-control" style="resize: none;" onkeydown="textCounter(TxtRemark' + RowIndex1 + ',450)" onkeyup="textCounter(TxtRemark' + RowIndex1 + ',450)">' + LDGR_REMARKS + '</textarea></td>';

            //EVM-0027 12-04
            FrecRow += '<td class="td1"><div class="btn_stl1"><button  title="ADD"  id="journalADD' + RowIndex1 + '" onclick="return FuctionAddGroup(\'' + RowIndex1 + '\')" class="btn act_btn bn2" ><i   class="fa fa-plus"  style="display: block;">&nbsp;</i></button>';
            FrecRow += '<button title="DELETE" id="bttnRemovGrp' + RowIndex1 + '"   onclick="return removeRowGrps(' + RowIndex1 + ',\'Are you sure you want to delete this ledger?\')" class="btn act_btn bn3" >';
            FrecRow += ' <i class="fa fa-trash"   style="display: block;">&nbsp;</i></button></div></td>';
            //EVM-0027 12-04 END
            FrecRow += '<td ><a  href="javascript:void(0)"  title="SALE" id="ChkSale' + RowIndex1 + '" onclick="return ddlLedOnchange(\'' + RowIndex1 + '\',\'upd\');"><i id="iSaleTag' + RowIndex1 + '" class="fa fa-balance-scale ad_fa"></i></a>';
            FrecRow += '<a  href="javascript:void(0)"  title="COST CENTRE" id="ChkCostCenter' + RowIndex1 + '"  onclick="MyModalCostCenter(\'' + RowIndex1 + '\',\'' + rowSubCatagory + '\',\'' + RCPT_LDGR_ID + '\');" ><i class="fa fa-filter ad_fa"></i></a></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" value=' + RCPT_LDGR_ID + ' style="display:none;"  id="tdRcptLdgrId' + RowIndex1 + '" name="tdRcptLdgrId' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value=' + COSTCNTR_ID + '  id="tdCostCenterDtls' + RowIndex1 + '" name="tdCostCenterDtls' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterSTS' + RowIndex1 + '" name="tdCostCenterSTS' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdSalesDtls' + RowIndex1 + '" value=' + SALES_ID + ' name="tdSalesDtls' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" value="UPD" style="display:none;"  id="tdEvtGrp' + RowIndex1 + '" name="tdEvtGrp' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdTempid' + RowIndex1 + '" name="tdDtlIdTempid' + RowIndex1 + '" placeholder=""/><input type="text" class="form-control"  style="display:none;" value="' + RCPT_LDGR_ID + '"  id="tdDtlIdGrp' + RowIndex1 + '" name="tdDtlIdGrp' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;" value="' + RCPT_LDGR_ID + '"  id="tdInxGrp' + RowIndex1 + '" name="tdInxGrp' + RowIndex1 + '" placeholder=""/> </td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdLedgrPaid' + RowIndex1 + '" name="tdLedgrPaid' + RowIndex1 + '" value="' + OB_PAID + '"  /> </td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdOpenSts' + RowIndex1 + '" name="tdOpenSts' + RowIndex1 + '" /> </td>';

            FrecRow += '</tr>';

            jQuery('#tableGrp').append(FrecRow);

            //document.getElementById("tdLedgrPaid" + currntx).value = OB_PAID;
            FillddlRcptLedger(RowIndex1, LDGR_ID);
            $au("#ddlRecptLedger" + RowIndex1).selectToAutocomplete1Letter();
            if (LDGR_ID != "") {
                ddlLedOnchangeEdit(RowIndex1, yy);

            }
            if (RowIndex1 == ROW_COUNT) {
                document.getElementById("tdInxGrp" + ROW_COUNT).value = "";
                document.getElementById("journalADD" + ROW_COUNT).style.opacity = "1";
            }
            else {
                document.getElementById("journalADD" + RowIndex1).style.opacity = "0.3";
                document.getElementById("journalADD" + RowIndex1).disabled = true;
            }

            addCommas("TxtAmount_" + RowIndex1);


            if (document.getElementById("<%=hiddenPostdated.ClientID%>").value == "1") {

                document.getElementById("journalADD" + RowIndex1).style.opacity = "0.3";
                document.getElementById("journalADD" + RowIndex1).disabled = true;

                document.getElementById("bttnRemovGrp" + RowIndex1).style.opacity = "0.3";
                document.getElementById("bttnRemovGrp" + RowIndex1).disabled = true;

                document.getElementById("TxtAmount_" + RowIndex1).disabled = true;
                $("#divLedger" + RowIndex1).find("input").attr("disabled", "disabled");
              
            }


            return false;

        }

        function ViewListRows(RCPT_ID, RCPT_LDGR_ID, LDGR_ID, LDGR_AMT, LDGR_NAME, ROW_COUNT, PYMNT_CST_ID, COSTCNTR_ID, PYMNT_CST_AMT, PURCHS_ID, RECPT_PURCHS_REF, COST_LD, SALES_ID, LDGR_REMARKS, OB_PAID) {

            document.getElementById("<%=HiddenLedgerId.ClientID%>").value = RCPT_LDGR_ID;
            RowIndex1++;
            var FrecRow = '';
            FrecRow = '<tr id="SubGrpRowId_' + RowIndex1 + '" ><td   id="tdidGrpDtls' + RowIndex1 + '" style="display: none" >' + RowIndex1 + '</td>';
            FrecRow += '<div style="clear:both"></div><div style="display:none" id="groupSubCat' + RowIndex1 + '">' + rowSubCatagory + '</div> ';
            var yy = rowSubCatagory + 1;
            FrecRow += ' <td ><select disabled  onchange="return ddlLedOnchange(\'' + RowIndex1 + '\',\'' + yy + '\');" class="fg2_inp2 fg2_inp3 fg_chs1 ddl" id="ddlRecptLedger' + RowIndex1 + '" >';
            FrecRow += '</select> <span class="input-group-addon cur2" id="AccntBalance_' + RowIndex1 + '"><i class="fa fa-money"></i>000</span></p><input class="form-control" style="display:none" name="ddlLedId' + RowIndex1 + '"  value=' + LDGR_ID + ' id="ddlLedId' + RowIndex1 + '" type="text"></td>';
            FrecRow += ' <td class=" tr_r" > <div class="input-group" > <span disabled class="input-group-addon cur1">' + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value + '</span><input disabled class="form-control fg2_inp2 tr_r" onkeydown="return CheckSalesDetails(event,\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'' + yy + '\');"  onkeypress="return  CheckSalesDetails(event,\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'' + yy + '\');" name="TxtAmount_' + RowIndex1 + '"  MaxLength="10"  onblur="return PendingSales(\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'' + yy + '\' );"    value=' + LDGR_AMT + ' id="TxtAmount_' + RowIndex1 + '" type="text"  autocomplete=\'off\'></div> </td>';
            FrecRow += '<td > <textarea name="TxtRemark' + RowIndex1 + '"  disabled   value=' + LDGR_REMARKS + ' id="TxtRemark' + RowIndex1 + '"   rows="3" cols="20"  class="form-control" style="resize: none;" onkeydown="textCounter(TxtRemark' + RowIndex1 + ',450)" onkeyup="textCounter(TxtRemark' + RowIndex1 + ',450)">' + LDGR_REMARKS + '</textarea></td>';
            //EVM-0027 12-04
            FrecRow += '<td ><button title="ADD" disabled style="opacity: .5;pointer-events: none;"  id="journalADD' + RowIndex1 + '" onclick="return FuctionAddGroup(\'' + RowIndex1 + '\')" class="btn act_btn bn2" ><span   class="fa fa-plus"  style="display: block;">&nbsp;</span></button>';         
            FrecRow += '<button disabled title="DELETE" id="bttnRemovGrp' + RowIndex1 + '"   onclick="return removeRowGrps(' + RowIndex1 + ',\'Are you sure you want to delete this Ledger?\')" class="btn act_btn bn3" style="">';
            FrecRow += ' <span class="fa fa-trash"   style="display: block;">&nbsp;</span></button></td>';
            //END
            FrecRow += '<a title="COST CENTRE" id="ChkCostCenter' + RowIndex1 + '"  onclick="MyModalCostCenter(\'' + RowIndex1 + '\',\'' + rowSubCatagory + '\',\'' + RCPT_LDGR_ID + '\');" ><i class="fa fa-filter ad_fa"></i></a></td>';
            FrecRow += '<td  ><a title="SALE" id="ChkSale' + RowIndex1 + '"  onclick="return ddlLedOnchange(\'' + RowIndex1 + '\',\'upd\');" style=""><i id="iSaleTag' + RowIndex1 + '" class="fa fa-balance-scale ad_fa"></i></a>';
            FrecRow += '<a   title="COST CENTRE" id="ChkCostCenter' + RowIndex1 + '" onclick="MyModalCostCenter(\'' + RowIndex1 + '\',\'' + rowSubCatagory + '\',\'' + RCPT_LDGR_ID + '\');"><i class="fa fa-filter ad_fa"></a></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" value=' + RCPT_LDGR_ID + ' style="display:none;"  id="tdRcptLdgrId' + RowIndex1 + '" name="tdRcptLdgrId' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowIndex1 + '" value=' + COSTCNTR_ID + '    name="tdCostCenterDtls' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterSTS' + RowIndex1 + '" name="tdCostCenterSTS' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdSalesDtls' + RowIndex1 + '" value=' + SALES_ID + ' name="tdSalesDtls' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" value="UPD" style="display:none;"  id="tdEvtGrp' + RowIndex1 + '" name="tdEvtGrp' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdTempid' + RowIndex1 + '" name="tdDtlIdTempid' + RowIndex1 + '" placeholder=""/><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdGrp' + RowIndex1 + '" name="tdDtlIdGrp' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;" value="' + RCPT_LDGR_ID + '"  id="tdInxGrp' + RowIndex1 + '" name="tdInxGrp' + RowIndex1 + '" placeholder=""/> </td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdLedgrPaid' + RowIndex1 + '" name="tdLedgrPaid' + RowIndex1 + '"  value="' + OB_PAID + '"  /> </td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdOpenSts' + RowIndex1 + '" name="tdOpenSts' + RowIndex1 + '" /> </td>';

            FrecRow += '</tr>';
            jQuery('#tableGrp').append(FrecRow);
            addCommas("TxtAmount_" + RowIndex1);
            FillddlRcptLedger(RowIndex1, LDGR_ID);
            $au("#ddlRecptLedger" + RowIndex1).selectToAutocomplete1Letter();
            if (LDGR_ID != "")
            {
                ddlLedOnchangeEdit(RowIndex1, yy);
            }
            return false;
       }

        function MyModalCostCenter(x, y, CstCntr) {
            var SbCostCenter = '';
           //EVM-0027 12-04
            SbCostCenter = '<div class=\"modal fade\" id=\"myModalCstCntr\" role=\"dialog\" data-backdrop=\"static\" >';
            //END
            SbCostCenter += '<div class=\"modal-dialog mod1\" >';
            SbCostCenter += '<div class=\"modal-content\">';
            SbCostCenter += '<div class=\"modal-header\">';
            SbCostCenter += '<button type=\"button\" class=\"close\"  onclick=\"return CloseModal(\'' + x + '\')\"> <span aria-hidden="true">&times;</span></button>';
            SbCostCenter += "<h2 id=\"ModelHeading\" class=\"modal-title mod1 flt_l\"><i class=\"fa fa-filter\"></i> Cost Centre</h2>";        
            SbCostCenter += "</div>";
            SbCostCenter += '<div class=\"alert alert-danger fade in\" id="divErrMsgCnclRsnCostCenter' + x + '" style=\"display: none; margin-top: 1%\">';
            SbCostCenter += '</div>';
            SbCostCenter += '<div class=\"al-box war\"  id="lblErrMsgCancelReasonCostCenter' + x + '"> Please fill this out</div>';        
            SbCostCenter += '<div class=\"modal-body md_bd\" >';
            SbCostCenter += '<div id=\"DivPopUpCostCenter\">';
            SbCostCenter += '<table class=\"table table-bordered\"  id="TableAddQstnCostCenter' + x + '">';
            SbCostCenter += '<thead class=\"thead1\"> <tr><th  class=\"col-md-2 tr_l\">Cost Group1</th><th class=\"col-md-2 tr_l\">Cost Group2</th><th class=\"col-md-2 tr_l\">Cost Centre</th><th class=\"col-md-2 tr_l\"> Amount</th><th class=\"col-md-2 tr_l\">ACTIONS';
            SbCostCenter += '</th></tr></thead>';
            SbCostCenter += '</table>';
            SbCostCenter += '</div></div>';
            SbCostCenter += '<div class=\"clearfix\"></div>';
            SbCostCenter += '<div class=\"modal-footer\">';
            SbCostCenter += '<div class="col-md-12 col_mar"><div class="box6 tr_r"><label id=\"Label1\" for=\"example-text-input\" class=\"fg2_la1 tt_am am1\" >Ledger Amount<span class="spn1"></span>:</label></div>';
            SbCostCenter += '<div class="box6 flt_r"><span id="LedgerAmtInModal' + x + '" class=\"tt_am am1 tt_al\" ></span></div></div>';
            SbCostCenter += '<label for="example-text-input" class=\"col-form-label\" id="lblCurrencyCC"></label>';
            SbCostCenter += '<button id="btnImportCostCenter' + x + '" type=\"button\" class=\"btn btn-success\"  onclick=\"ButtnFillClickCostCenter(\'' + x + '\');\" >Submit</button>';

            SbCostCenter += '<button type="button" class="btn btn-danger" onclick=\"return CloseModal(\'' + x + '\')\">Cancel</button>';
            //SbCostCenter += '<button id="BttnTemp ' + x + '" type=\"button\" style=\"display:none\" class=\"btn btn-primary\" data-dismiss=\"modal\"></button>';
            SbCostCenter += '<button id="BttnCost' + x + '" type=\"button\" style=\"display:none\" class=\"btn btn-primary\" data-dismiss=\"modal\"></button>';
            SbCostCenter += '</div></div> </div></div>';
            document.getElementById("CostCenterModal").innerHTML = SbCostCenter;
            CostCentr(x, y, CstCntr);
            buttnVisibile(x);
            var idlast = "";
            var row = $noCon('#TableAddQstnCostCenter' + x).find(' tbody tr:first').attr('id');
            idlast = row.split('_');
            setTimeout(function () { focusCostCentre(idlast[1]); }, 350);
        }
        function focusCostCentre(Rowid) {

            $("#divCostGrp1" + Rowid + " > input").focus();
            $("#divCostGrp1" + Rowid + " > input").select();
        }

        function CostCentr(x, y, CostCenterId) {
            var TxtCstctrAmount = "";
            TxtCstctrAmount = document.getElementById("TxtAmount_" + x).value;
            TxtCstctrAmount = TxtCstctrAmount.trim();
            TxtCstctrAmount = TxtCstctrAmount.replace(/,/g, "");

            document.getElementById("TxtAmount_" + x).style.borderColor = "";
            $("#divLedger" + x + "> input").css("borderColor", "");
            var RCPT_LDGR_ID = document.getElementById("tdRcptLdgrId" + x).value;
            if ((document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) && TxtCstctrAmount != "") {
                var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                document.getElementById("ddlLedId" + x).value = LedgerId;

                if (document.getElementById("tdCostCenterDtls" + x).value != "") {

                    var CstCntrDtl = document.getElementById("tdCostCenterDtls" + x).value;
                    var PrchaseTTl = "0";
                    var splitrow = CstCntrDtl.split("$");
                    for (var Cst = 0; Cst < splitrow.length; Cst++) {
                        var splitEach = splitrow[Cst].split("%");
                        if (splitEach[0] != "") {
                            FunctionQustn(x, currnty, splitEach[0], splitEach[4], splitEach[5]);

                            if (splitEach[0] != "null" && splitEach[0] != null && document.getElementById("<%=HiddenView.ClientID%>").value != "1") {

                                document.getElementById("tdEvtQstn" + x + '' + currnty).value = splitEach[2];
                                document.getElementById("tdrcptcstCntrId" + x + '' + currnty).value = splitEach[3];
                                document.getElementById("ddlCostCtrId_" + x + '' + currnty).value = splitEach[0];
                                document.getElementById("TxtCstctrAmount_" + x + '' + currnty).value = splitEach[1];

                                document.getElementById("TxtActCstctrAmount_" + x + '' + currnty).value = splitEach[1];
                                document.getElementById("ddlRecptCosGrp1_" + x + '' + currnty).value = splitEach[4];
                                document.getElementById("ddlRecptCosGrp2_" + x + '' + currnty).value = splitEach[5];
                                PrchaseTTl = parseFloat(PrchaseTTl) + parseFloat(splitEach[1]);
                                document.getElementById("btnCostCenter_" + x + '' + currnty).style.opacity = "0.3";
                                document.getElementById("btnCostCenter_" + x + '' + currnty).disabled = true;

                            }
                            else if (splitEach[0] != "null" && splitEach[0] != null && document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                                document.getElementById("tdEvtQstn" + x + '' + currnty).value = splitEach[2];
                                document.getElementById("tdrcptcstCntrId" + x + '' + currnty).value = splitEach[3];
                                document.getElementById("ddlCostCtrId_" + x + '' + currnty).value = splitEach[0];
                                document.getElementById("TxtCstctrAmount_" + x + '' + currnty).value = splitEach[1];

                                document.getElementById("TxtActCstctrAmount_" + x + '' + currnty).value = splitEach[1];

                                PrchaseTTl = parseFloat(PrchaseTTl) + parseFloat(splitEach[1]);

                                $("#TableAddQstnCostCenter" + x).find("input").attr("disabled", "disabled");
                                document.getElementById("btnCostCenterDel_" + x + '' + currnty).style.opacity = "0.3";
                                document.getElementById("btnCostCenter_" + x + '' + currnty).style.opacity = "0.3";
                                document.getElementById("btnImportCostCenter" + x).style.display = "none";
                                document.getElementById("ddlRecptCosGrp1_" + x + '' + currnty).value = splitEach[4];
                                document.getElementById("ddlRecptCosGrp2_" + x + '' + currnty).value = splitEach[5];
                                document.getElementById("btnCostCenterDel_" + x + '' + currnty).disabled = true;
                                document.getElementById("btnCostCenter_" + x + '' + currnty).disabled = true;
                            }
                            else if ((splitEach[0] == "null" || splitEach[0] != null) && document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                                $("#TableAddQstnCostCenter" + x).find("input").attr("disabled", "disabled");
                                document.getElementById("btnCostCenterDel_" + x + '' + currnty).style.opacity = "0.3";
                                document.getElementById("btnCostCenter_" + x + '' + currnty).style.opacity = "0.3";
                                document.getElementById("btnImportCostCenter" + x).style.display = "none";
                                document.getElementById("btnCostCenterDel_" + x + '' + currnty).disabled = true;
                                document.getElementById("btnCostCenter_" + x + '' + currnty).disabled = true;
                            }
                        }

                    }

                }
                else
                {

                    if (CostCenterId == null)
                    {
                        FunctionQustn(x, y, CostCenterId);

                    }
                    else
                    {
                        if (document.getElementById("tdCostCenterDtls" + x).value != "")
                        {
                            FunctionEditQustn(x, y, CostCenterId, CostCenterId, CostCenterId);
                        }
                        else {
                            FunctionQustn(x, y, null, null, null);
                        }
                    }

                }
           var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                TxtCstctrAmount = parseFloat(TxtCstctrAmount);
                if (FloatingValue != "") {
                    TxtCstctrAmount = TxtCstctrAmount.toFixed(FloatingValue);
                }
                addCommasSummry(TxtCstctrAmount);
                document.getElementById("LedgerAmtInModal" + x).innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                if (document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value != "") {
                    document.getElementById("LedgerAmtInModal" + x).innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                }
                document.getElementById("BtnPopupCstCntr").click();
            }
            if (document.getElementById("ddlRecptLedger" + x).value == "" || document.getElementById("ddlRecptLedger" + x).value == 0) {
                $("#divLedger" + x + "> input").css("borderColor", "red");
                $("#divLedger" + x + "> input").focus();
                $("#divLedger" + x + "> input").select();
            }
            if (TxtCstctrAmount == "") {
                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
            }
        }
        function buttnVisibile(x) {
            var TableRowCount = document.getElementById("tableGrp").rows.length;
            addRowtable = document.getElementById("tableGrp");
            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {

                for (var i = 1; i < addRowtable.rows.length; i++) {
                    var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                    if (TableRowCount != 0) {


                        if (xLoop != "") {
                            if (xLoop == addRowtable.rows.length) {

                                document.getElementById("tdInxGrp" + xLoop).value = "";
                                document.getElementById("journalADD" + xLoop).style.opacity = "1";
                            }
                            //else {
                            //    alert(".3");
                            //    document.getElementById("journalADD" + xLoop).style.opacity = "0.3";
                            //}
                        }
                    }

                    if (x != 0) {
                        var TableRowCount1 = document.getElementById("TableAddQstnCostCenter" + x).rows.length;
                        if (TableRowCount1 != 0) {
                            var idlast1 = $noCon('#TableAddQstnCostCenter' + x + ' tr:last').attr('id');

                            if (idlast1 != "") {
                                var res1 = idlast1.split("_");
                                document.getElementById("tdInxQstn" + res1[1]).value = "";
                                document.getElementById("btnCostCenter_" + res1[1]).style.opacity = "1";
                                document.getElementById("btnCostCenter_" + res1[1]).disabled = false;

                            }
                        }
                    }
                }
            }

        }


        var currntx = "";
        var currnty = "";


        function FunctionQustn(x, y, CostCenterId, CostGrp1Id, CostGroup2Id) {
            y++;
            // submit++;
            var FrecRowQst = '';
            FrecRowQst = '<tr id="SubQstnRowId_' + x + '' + y + '" ><td   id="tdidQstnDtls' + x + '' + y + '" style="display: none" >' + x + '' + y + '</td>';
            FrecRowQst += '<td   id="tdvalidate' + x + '' + y + '" style="display: none" >' + x + '</td>';
            FrecRowQst += '<td   id="tdvalidatey' + x + '' + y + '" style="display: none" >' + y + '</td>';

            FrecRowQst += '<td>';
            FrecRowQst += '<input name="TxtRecptCosGrp1_' + x + '' + y + '"  style="display: none;pointer-events: none;" class="form-control" id="TxtRecptCosGrp1_' + x + '' + y + '" ><div id="divCostGrp1' + x + '' + y + '"><select id="ddlRecptCosGrp1_' + x + '' + y + '" name="ddlRecptCosGrp1_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl" onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostGrp1Id_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostGrp1Id_' + x + '' + y + '" ></td>';

            FrecRowQst += '<td>';
            FrecRowQst += '<input name="TxtRecptCosGrp2_' + x + '' + y + '"  style="display: none;pointer-events: none;" class="form-control" id="TxtRecptCosGrp2_' + x + '' + y + '" ><div id="divCostGrp2' + x + '' + y + '"><select id="ddlRecptCosGrp2_' + x + '' + y + '" name="ddlRecptCosGrp2_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl"  onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostGrp2Id_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostGrp2Id_' + x + '' + y + '" ></td>';

            FrecRowQst += '<td><input style="display:none" value="-1" name="TxtIdSales_' + x + '' + y + '" class="form-control" id="TxtIdSales_' + x + '' + y + '" >';
            FrecRowQst += '<input name="TxtRecptCosCtr_' + x + '' + y + '"  style="display: none;pointer-events: none;background: #eee;" class="form-control" id="TxtRecptCosCtr_' + x + '' + y + '" ><div id="divCostCenter' + x + '' + y + '"><select id="ddlRecptCosCtr_' + x + '' + y + '" name="ddlRecptCosCtr_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl"  onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostCtrId_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostCtrId_' + x + '' + y + '" ></td>';

            //FrecRowQst += '<td class="tr_r"><div class="input-group"><span class="input-group-addon cur1">' + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value; +'</span>';
         

            FrecRowQst += '<td class=" tr_r">';
            FrecRowQst += '<div class="input-group">';
            FrecRowQst += '<span class="input-group-addon cur1">';
            FrecRowQst += '' + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value; +'';
            FrecRowQst += '</span>';
            FrecRowQst += '<input class="form-control fg2_inp2 tr_r" maxlength="10"  id="TxtCstctrAmount_' + x + '' + y + '" name="TxtCstctrAmount_' + x + '' + y + '" value="" onchange="return CheckSumOfCstCntr(\'TxtCstctrAmount_' + x + '' + y + '\',' + x + ',' + y + ');"  autocomplete=\'off\'   onkeydown="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '' + y + '\');" onkeypress="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '' + y + '\');" id="TxtCstctrAmount_' + x + '' + y + '" type="text" />';
            FrecRowQst += '<input class="form-control"   id="TxtActCstctrAmount_' + x + '' + y + '" value="" onblur="return CheckSumOfLedger(\'TxtActCstctrAmount_' + x + '' + y + ',' + x + '\',' + y + ');" onkeyup="addCommas("TxtActCstctrAmount_' + x + '' + y + ')" style="display:none" onkeydown="return isNumber(event,TxtActCstctrAmount_' + x + '' + y + ');" name="TxtActCstctrAmount_' + x + '' + y + '" type="text"/>';
            FrecRowQst += '</div>';
            FrecRowQst += '</td>';

            FrecRowQst += '<td class="td1"> <div class="btn_stl1"><button title="ADD" id="btnCostCenter_' + x + '' + y + '" onclick="return CheckaddMoreRowsQstn(\'' + x + '\',\'' + y + '\',\'' + x + '' + y + '\');" class="btn act_btn bn1"><span  class="fa fa-plus"  style="display: block;">&nbsp;</span></button>';
            FrecRowQst += '<button class="btn act_btn bn3" id="btnCostCenterDel_' + x + '' + y + '" onclick="return removeRowQstn(' + x + ',' + y + ',' + x + '' + y + ',\'Are you sure you want to delete this cost centre?\')" ><span title="DELETE"   class="fa fa-trash" id="Span4" style="display: block;">&nbsp;</span></button>';
            FrecRowQst += '</div></td>';

            FrecRowQst += '<td   style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value="" id="tdrcptcstCntrId' + x + '' + y + '" name="tdrcptcstCntrId' + x + '' + y + '" placeholder=""/></td>';
            FrecRowQst += '<td   style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value="INS" id="tdEvtQstn' + x + '' + y + '" name="tdEvtQstn' + x + '' + y + '" placeholder=""/></td>';
            FrecRowQst += '<td style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdDtlIdQstn' + x + '' + y + '" name="tdDtlIdQstn' + x + '' + y + '" placeholder=""/></td>';
            FrecRowQst += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdInxQstn' + x + '' + y + '" name="tdInxQstn' + x + '' + y + '" placeholder=""/> </td></tr>';
            jQuery('#TableAddQstnCostCenter' + x).append(FrecRowQst);

            FillddlCostCenter(x, y, CostCenterId);


            $au("#ddlRecptCosCtr_" + x + '' + y).selectToAutocomplete1Letter();


            FillddlAcntGrp1(x, y, CostGrp1Id);


            $au("#ddlRecptCosGrp1_" + x + '' + y).selectToAutocomplete1Letter();

            FillddlAcntGrp2(x, y, CostGroup2Id);


            $au("#ddlRecptCosGrp2_" + x + '' + y).selectToAutocomplete1Letter();

            currntx = x;
            currnty = y;
            $("#divCostGrp1" + x + '' + y + " > input").focus();
            $("#divCostGrp1" + x + '' + y + " > input").select();
            return false;

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

            // addCommas(textboxid);
        }

        function AmountCheckingLabel(LblId) {
            var txtPerVal = document.getElementById(LblId).innerHTML;
            txtPerVal = txtPerVal.replace(/,/g, "");
            if (txtPerVal == "") {
                return false;
            }
            else {
                if (!isNaN(txtPerVal) == false) {
                    document.getElementById('' + LblId + '').innerHTML = "";
                    return false;
                }
                else {
                    var amt = parseFloat(txtPerVal);
                    var num = amt;
                    var n = 0;
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);
                    }
                    document.getElementById('' + LblId + '').innerHTML = n;
                }
            }
        }

        function CheckSalesDetails(evt, textboxid, x, y) {


            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            if (charCode != 13) {
                //  isDecimalNumber(evt, textboxid);
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
                else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 38 || keyCodes == 40) {
                    return false;

                }
                else if (keyCodes == 34 || keyCodes == 33 || keyCodes == 36 || keyCodes == 35 || keyCodes == 41) {

                    return true;
                }
                else if ((keyCodes == 65 || keyCodes == 86 || keyCodes == 67) && (evt.ctrlKey === true || evt.metaKey === true)) {
                    return true;
                }
                else if (keyCodes == 46) {
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



        }

        function isDecimalNumber(evt, textboxid) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            var txtPerVal = document.getElementById(textboxid).value;
            //enter

            // alert(keyCodes);

            if (keyCodes == 27) {
                $noCon('btnImportSales').prop("data-dismiss", "modal");
            }

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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 38 || keyCodes == 40) {
                return false;

            }
            else if (keyCodes == 46) {
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

       

        function ButtnFillClickCostCenter(x) {
            var ret = true;
            var TotalAmnt = 0;
            var purchaseFlag = 0;
            var CheckCount = 0;
            //  document.getElementById("divErrMsgCnclRsn").style.display = "none";
            var TotalAmnt = document.getElementById("TxtAmount_" + x).value;
            TotalAmnt = TotalAmnt.replace(/\,/g, '');
            var addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
            var CstTotal = 0;
            for (var i = 1; i < addRowtable.rows.length; i++) {
                var varId = (addRowtable.rows[i].cells[0].innerHTML);
                if (CCDuplication(x, varId) == false) {
                    ret = false;
                }
                document.getElementById("divCostCenter" + varId).style.borderColor = "";
                document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
                var Costval = $("#ddlRecptCosCtr_" + varId).val();
                var CostGrpval = $("#ddlRecptCosGrp1_" + varId).val();
                var CostGrp2val = $("#ddlRecptCosGrp2_" + varId).val();

                if (CostGrpval == 0 && CostGrp2val == 0 && Costval == 0 && document.getElementById("TxtCstctrAmount_" + varId).value == "") {

                }

                else if (Costval == 0 && document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                    $("#divCostCenter" + varId + "> input").css("borderColor", "Red");
                    document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Please select a cost centre";
                    document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                    $("#divCostCenter" + varId + "> input").focus();
                    $("#divCostCenter" + varId + "> input").select();
                   // $("div.war").fadeIn(200).delay(500).fadeOut(400);
                    ret = false;

                }
                else if (Costval != 0 && document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                    //$("#divCostCenter" + varId + "> input").css("borderColor", "Red");
                    document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Please enter cost centre amount";
                    document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                    document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                    document.getElementById("TxtCstctrAmount_" + varId).focus();
                    //$("TxtCstctrAmount_" + varId + "> input").focus();
                    //$("TxtCstctrAmount_" + varId + "> input").select();
                   // $("div.war").fadeIn(200).delay(500).fadeOut(400);
                    ret = false;

                }
                else if ((CostGrpval != 0 || CostGrp2val != 0) && Costval == 0 && document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                    $("#divCostCenter" + varId + "> input").css("borderColor", "Red");
                    document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Please fill highlighted fields ";
                    document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                    $("#divCostCenter" + varId + "> input").focus();
                    $("#divCostCenter" + varId + "> input").select();
                    document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                    document.getElementById("TxtCstctrAmount_" + varId).focus();
                   // $("div.war").fadeIn(200).delay(500).fadeOut(400);
                    ret = false;

                }
                else if ((CostGrpval != 0 || CostGrp2val != 0) && document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                    //$("#divCostCenter" + varId + "> input").css("borderColor", "Red");
                    document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Please enter cost centre amount";
                    document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                    $("#TxtCstctrAmount_" + varId + "> input").focus();
                    $("#TxtCstctrAmount_" + varId + "> input").select();
                   // $("div.war").fadeIn(200).delay(500).fadeOut(400);
                    ret = false;

                }
                else {
                    if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                        var ldgramt = document.getElementById("TxtCstctrAmount_" + varId).value;
                        ldgramt = ldgramt.replace(/\,/g, '');
                        CstTotal = parseFloat(CstTotal) + parseFloat(ldgramt);
                        purchaseFlag++;
                    }
                    if (document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                        document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";

                    }
                    if (Costval == 0) {
                        $("#divCostCenter" + varId + "> input").css("borderColor", "red");
                    }
                }
            }
            if (ret == true) {
                if (CstTotal != "") {
                    if (parseFloat(TotalAmnt) != parseFloat(CstTotal)) {
                        document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = " Ledger amount should be equal to cost centre amount";
                        document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
                        document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                        //$("div.war").fadeIn(200).delay(500).fadeOut(400);

                        document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                        document.getElementById("TxtCstctrAmount_" + varId).focus();

                        ret = false;
                    }
                }
            }
            if (ret == true) {
                if (purchaseFlag != 0) {
                    document.getElementById("tdCostCenterDtls" + x).value = "";

                    for (var i = 1; i < addRowtable.rows.length; i++) {
                        var varId = (addRowtable.rows[i].cells[0].innerHTML);
                        var rcptCstId = document.getElementById("tdrcptcstCntrId" + varId).value;
                        var Costval = $("#ddlRecptCosCtr_" + varId).val();
                        if (Costval != 0 && document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                            if (document.getElementById("tdCostCenterDtls" + x).value == "") {
                                document.getElementById("tdCostCenterDtls" + x).value = Costval + "%" + document.getElementById("TxtCstctrAmount_" + varId).value + "%" + document.getElementById("tdEvtQstn" + varId).value + "%" + rcptCstId + "%" + document.getElementById("ddlRecptCosGrp1_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp2_" + varId).value;
                            }
                            else {
                                document.getElementById("tdCostCenterDtls" + x).value = document.getElementById("tdCostCenterDtls" + x).value + "$" + Costval + "%" + document.getElementById("TxtCstctrAmount_" + varId).value + "%" + document.getElementById("tdEvtQstn" + varId).value + "%" + rcptCstId + "%" + document.getElementById("ddlRecptCosGrp1_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp2_" + varId).value;

                            }
                        }
                    }
                }
                document.getElementById("BttnCost" + x).click();
                document.getElementById("ChkCostCenter" + x).focus();
            }
        }

       
        function FunctionEditQustn(x, y, RCPT_LDGR_ID) {
            // y = 1;
            var strOrgId = '<%=Session["ORGID"]%>';
            var strCorpId = '<%=Session["CORPOFFICEID"]%>';
            var tableName = "dtTableLoadcstcntr";
            if (RCPT_LDGR_ID != "") {

                var strldgrId = "" + RCPT_LDGR_ID + "";
                $noCon.ajax({
                    type: "POST",


                    url: "fms_Receipt_Account.aspx/ReadreceiptCstcntr",
                    data: '{strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '",strldgrId:"' + strldgrId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        //  alert(response.d);
                        // HiddenEditcstcntjson
                        // document.getElementById("cphMain_hiddenQstnCanclDtlId").value = detailId;
                        if (response.d != "[]") {
                            var cstCnt = response.d;
                            var find2 = '\\"\\[';
                            var re2 = new RegExp(find2, 'g');
                            var res2 = cstCnt.replace(re2, '\[');

                            var find3 = '\\]\\"';
                            var re3 = new RegExp(find3, 'g');
                            var res3 = res2.replace(re3, '\]');
                            var json = $noCon.parseJSON(res3);

                            for (var key in json) {
                                if (json.hasOwnProperty(key)) {
                                    // alert(flag);
                                    //   alert(yid);

                                    EditLiscostcenttRows(x, y, json[key].RECPT_CST_ID, json[key].COSTCNTR_ID, json[key].RECPT_ID, json[key].RECPT_CST_AMT, json[key].RECPT_LD_ID, json[key].SALES_ID, json[key].RECPT_SALES_REF, json[key].ROWCOUNT, json[key].SALEAMOUNT);
                                    // if (document.getElementById("<%=HiddenLedgerId.ClientID%>").value == RECPT_LD_ID) {
                                    y++;
                                    //  }

                                }



                            }
                        }
                        else {
                            FunctionQustn(x, currnty, null, null, null);
                        }
                        if (json == "") {
                            y = 0;
                            //  FunctionQustn(x, y);
                        }


                    },
                    failure: function (response) {

                    }
                });
            }


        }
        function FunctionViewQustn(x, y, RCPT_LDGR_ID) {
            y = 1;
            var strOrgId = '<%=Session["ORGID"]%>';
            var strCorpId = '<%=Session["CORPOFFICEID"]%>';
            var tableName = "dtTableLoadcstcntr";
            if (RCPT_LDGR_ID != "") {

                var strldgrId = "" + RCPT_LDGR_ID + "";
                $noCon.ajax({
                    type: "POST",
                    url: "fms_Receipt_Account.aspx/ReadreceiptCstcntr",
                    data: '{strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '",strldgrId:"' + strldgrId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        // HiddenEditcstcntjson
                        // document.getElementById("cphMain_hiddenQstnCanclDtlId").value = detailId;
                        var cstCnt = response.d;
                        var find2 = '\\"\\[';
                        var re2 = new RegExp(find2, 'g');
                        var res2 = cstCnt.replace(re2, '\[');

                        var find3 = '\\]\\"';
                        var re3 = new RegExp(find3, 'g');
                        var res3 = res2.replace(re3, '\]');
                        var json = $noCon.parseJSON(res3);

                        for (var key in json) {
                            if (json.hasOwnProperty(key)) {
                                // alert(flag);
                                //   alert(yid);

                                ViewLiscostcenttRows(x, y, json[key].RECPT_CST_ID, json[key].COSTCNTR_ID, json[key].RECPT_ID, json[key].RECPT_CST_AMT, json[key].RECPT_LD_ID, json[key].SALES_ID, json[key].RECPT_SALES_REF, json[key].ROWCOUNT, json[key].SALEAMOUNT);
                                // if (document.getElementById("<%=HiddenLedgerId.ClientID%>").value == RECPT_LD_ID) {
                                        y++;
                                        //  }

                                    }
                                }
                                if (json == "") {
                                    //FunctionQustn(x, y);

                                    //$('#TableQstn_' + x + ' td:first-child').each(function () {
                                    //    var varId = $(this).text();
                                    //   // document.getElementById("ddlRecptCosCtr_" + varId).disabled = true;
                                    //    // document.getElementById("TxtCstctrAmount_" + varId).disabled = true;
                                    //    $("#TableQstn_" + x).find("input").attr("disabled", "disabled");
                                    //  //  $('#TableQstn_' + varId).find("input").attr("disabled", "disabled");

                                    //});



                                }

                            },
                            failure: function (response) {

                            }
                        });
                    }


                }
                function ViewLiscostcenttRows(x, y, RECPT_CST_ID, COSTCNTR_ID, RECPT_ID, RECPT_CST_AMT, RECPT_LD_ID, SALES_ID, RECPT_SALES_REF, ROWCOUNT, SALEAMOUNT) {
                    //alert(response.d);
                    // y++;
                    //alert(y);
                    // for (var i = 1; i <= ROWCOUNT; i++) {


                    var FrecRowQst = '';

                    FrecRowQst += '<tr id="SubQstnRowId_' + x + '' + y + '" ><td   id="tdidQstnDtls' + x + '' + y + '" style="display: none" >' + x + '' + y + '</td>';
                    FrecRowQst += '<td   id="tdvalidate' + x + '' + y + '" style="display: none" >' + x + '</td>';
                    FrecRowQst += '<td   id="tdvalidatey' + x + '' + y + '" style="display: none" >' + y + '</td>';
                    FrecRowQst += '<td  style="width:48%;padding-left: 1px;padding-top: 7px;">';
                    if (SALES_ID != 0) {
                        FrecRowQst += '<input  name="TxtIdSales_' + x + '' + y + '" style="display: none;" value=' + SALES_ID + ' class="form-control" id="TxtIdSales_' + x + '' + y + '" >';
                        FrecRowQst += '<input name="TxtRecptCosCtr_' + x + '' + y + '" value=' + RECPT_SALES_REF + '  style="pointer-events: none;background: #eee;" class="form-control" id="TxtRecptCosCtr_' + x + '' + y + '" >';
                        FrecRowQst += '<div id="divCostCenter' + x + '' + y + '"> <select id="ddlRecptCosCtr_' + x + '' + y + '"   style="display: none;" form-control ddl onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');"  >';
                        FrecRowQst += '</select></div><input  style="display: none"  name="ddlCostCtrId_' + x + '' + y + '"  class="form-control" id="ddlCostCtrId_' + x + '' + y + '" >';
                    }
                    if (COSTCNTR_ID != 0) {
                        FrecRowQst += '<input  name="TxtIdSales_' + x + '' + y + '" style="display: none;" value="" class="form-control" id="TxtIdSales_' + x + '' + y + '" >';
                        FrecRowQst += '<input name="TxtRecptCosCtr_' + x + '' + y + '"  style="display: none;" value=""  style="pointer-events: none;background: #eee;" class="form-control" id="TxtRecptCosCtr_' + x + '' + y + '" >';
                        FrecRowQst += ' <div id="divCostCenter' + x + '' + y + '"><select id="ddlRecptCosCtr_' + x + '' + y + '" disabled  class="form-control ddl" onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');"  >';
                        FrecRowQst += '</select></div><input  style="display: none"  name="ddlCostCtrId_' + x + '' + y + '" value=' + COSTCNTR_ID + '  class="form-control" id="ddlCostCtrId_' + x + '' + y + '" >';
                    }
                    FrecRowQst += '</td><td  style="padding-right: 5px;width:43%;padding-left: 2px;padding-top: 7px;"><input disabled class="form-control"   id="TxtCstctrAmount_' + x + '' + y + '" value=' + RECPT_CST_AMT + ' onchange="return CheckSumOfCstCntr(\'TxtCstctrAmount_' + x + '' + y + '\',' + x + ',' + y + ');" onkeyup="addCommas(TxtCstctrAmount_' + x + '' + y + ')" style="text-align: right;" onkeydown="return isNumber(event,TxtCstctrAmount_' + x + '' + y + ');" name="TxtCstctrAmount_' + x + '' + y + '" type="text"><input class="form-control"   id="TxtActCstctrAmount_' + x + '' + y + '" value=' + SALEAMOUNT + ' onchange="return CheckSumOfCstCntr(\'TxtActCstctrAmount_' + x + '' + y + '\',' + x + ',' + y + ');" onkeyup="addCommas("TxtActCstctrAmount_' + x + '' + y + '")" style="text-align: right; display:none" onkeydown="return isNumber(event,TxtActCstctrAmount_' + x + '' + y + ');" name="TxtActCstctrAmount_' + x + '' + y + '" type="text"></td>';
                    FrecRowQst += '<td style="padding-top: 7px;width:17%;"><button title="ADD" id="btnCostCenter_' + x + '' + y + '" style="opacity: .5;pointer-events: none;"  class="btn btn-primary"><span  class="fa fa-plus"  style="display: block;">&nbsp;</span></button></td><td style="padding-top: 7px;width:17%;"><button class="btn btn-primary"  style="margin-bottom:8%;opacity: .5;pointer-events: none;">';
                    FrecRowQst += '<span title="DELETE"   class="fa fa-trash" id="Span4" style="display: block;">&nbsp;</span></button>';
                    FrecRowQst += '</td>';

                    FrecRowQst += '<td   style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value=' + RECPT_CST_ID + ' id="tdrcptcstCntrId' + x + '' + y + '" name="tdrcptcstCntrId' + x + '' + y + '" placeholder=""/></td>';
                    FrecRowQst += '<td   style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value="VIEW" id="tdEvtQstn' + x + '' + y + '" name="tdEvtQstn' + x + '' + y + '" placeholder=""/></td>';
                    FrecRowQst += '<td style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdDtlIdQstn' + x + '' + y + '" value="tdDtlIdQstn' + x + '' + y + '"  name="tdDtlIdQstn' + x + '' + y + '" placeholder=""/></td>';
                    FrecRowQst += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdInxQstn' + x + '' + y + '" name="tdInxQstn' + x + '' + y + '" placeholder=""/> </td></tr>';
                    jQuery('#TableQstn_' + x).append(FrecRowQst);
                    if (COSTCNTR_ID != 0) {
                        FillddlCostCenter(x, y, COSTCNTR_ID);
                        $au("#ddlRecptCosCtr_" + x + '' + y).selectToAutocomplete1Letter();
                    }
                    //  document.getElementById("TxtIdSales_" + x + '' + y).value = -1;
                    // alert(y);
                    addCommas("TxtCstctrAmount_" + x + '' + y);
                    currntx = x;
                    currnty = y;

                    //  y++;
                    //alert(currnty);
                    return true;
                }

                function EditLiscostcenttRows(x, y, RECPT_CST_ID, COSTCNTR_ID, RECPT_ID, RECPT_CST_AMT, RECPT_LD_ID, SALES_ID, RECPT_SALES_REF, ROWCOUNT, SALEAMOUNT) {

                    // submit++;
                    //   alert(RECPT_CST_ID);
                    var FrecRowQst = '';
                    y++;
                    FrecRowQst = '<tr id="SubQstnRowId_' + x + '' + y + '" ><td   id="tdidQstnDtls' + x + '' + y + '" style="display: none" >' + x + '' + y + '</td>';
                    FrecRowQst += '<td   id="tdvalidate' + x + '' + y + '" style="display: none" >' + x + '</td>';
                    FrecRowQst += '<td   id="tdvalidatey' + x + '' + y + '" style="display: none" >' + y + '</td>';

                    FrecRowQst += '<td  style="width:48%;padding-left: 1px;padding-top: 7px;"><input style="display:none" value="-1" name="TxtIdSales_' + x + '' + y + '" class="form-control" id="TxtIdSales_' + x + '' + y + '" ><input name="TxtRecptCosCtr_' + x + '' + y + '"  style="display: none;pointer-events: none;background: #eee;" class="form-control" id="TxtRecptCosCtr_' + x + '' + y + '" ><div id="divCostCenter' + x + '' + y + '"><select id="ddlRecptCosCtr_' + x + '' + y + '" name="ddlRecptCosCtr_' + x + '' + y + '" class="form-control ddl" onblur="CCDuplication(\'' + x + '\',\'' + x + '' + y + '\');" onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  >';


                    FrecRowQst += '</select></div><input name="ddlCostCtrId_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostCtrId_' + x + '' + y + '" ></td><td  style="padding-right: 5px;width:43%;padding-left: 2px;padding-top: 7px;"><input class="form-control" maxlength="10"  id="TxtCstctrAmount_' + x + '' + y + '" name="TxtCstctrAmount_' + x + '' + y + '" value=' + RECPT_CST_AMT + ' onchange="return CheckSumOfCstCntr(\'TxtCstctrAmount_' + x + '' + y + '\',' + x + ',' + y + ');"  onkeydown="return isNumberAmount(event,\'TxtCstctrAmount_' + x + '' + y + '\');" id="TxtCstctrAmount_' + x + '' + y + '" type="text" style="text-align: right;"><input class="form-control"   id="TxtActCstctrAmount_' + x + '' + y + '" value="" onblur="return CheckSumOfLedger(\'TxtActCstctrAmount_' + x + '' + y + '\',' + x + ',' + y + ');" onkeyup="addCommas("TxtActCstctrAmount_' + x + '' + y + ')" style="text-align: right; display:none" onkeydown="return isNumber(event,TxtActCstctrAmount_' + x + '' + y + ');" name="TxtActCstctrAmount_' + x + '' + y + '" type="text"></td>';

                    FrecRowQst += '<td style="padding-top: 7px;width:41%;padding-left: 1px;"><button title="ADD" id="btnCostCenter_' + x + '' + y + '" onclick="return CheckaddMoreRowsQstn(\'' + x + '\',\'' + y + '\',\'' + x + '' + y + '\');" class="btn btn-primary"><span  class="fa fa-plus"  style="display: block;">&nbsp;</span></button></td><td style="padding-top: 7px;width:17%;"><button class="btn btn-primary" id="btnCostCenterDel_' + x + '' + y + '" onclick="return removeRowQstn(' + x + ',' + y + ',' + x + '' + y + ',\'Are you sure you want to delete this cost centre?\')" style="margin-bottom:8%;">';

                    FrecRowQst += '<span title="DELETE"   class="fa fa-trash" id="Span4" style="display: block;">&nbsp;</span></button>';
                    FrecRowQst += '</td>';

                    FrecRowQst += '<td   style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value=' + RECPT_CST_ID + ' id="tdrcptcstCntrId' + x + '' + y + '" name="tdrcptcstCntrId' + x + '' + y + '" placeholder=""/></td>';
                    FrecRowQst += '<td   style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value="UPD" id="tdEvtQstn' + x + '' + y + '" name="tdEvtQstn' + x + '' + y + '" placeholder=""/></td>';
                    FrecRowQst += '<td style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdDtlIdQstn' + x + '' + y + '" name="tdDtlIdQstn' + x + '' + y + '"  value="' + RECPT_CST_ID + '"  placeholder=""/></td>';
                    FrecRowQst += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdInxQstn' + x + '' + y + '" name="tdInxQstn' + x + '' + y + '"  value="' + x + '' + y + ' "   placeholder=""/> </td></tr>';
                    jQuery('#TableAddQstnCostCenter' + x).append(FrecRowQst);
                    // document.getElementById("TableAddQstnCostCenter").innerHTML = FrecRowQst;
                    //  if (document.getElementById("myModal").style.display != "block") {
                    //   document.getElementById("BtnPopup").click();
                    //document.getElementById("btnImportSales").style.display = "none";
                    //document.getElementById("btnImportCostCenter").style.display = "";
                    //document.getElementById("ModelHeading").innerHTML = "Cost Center";
                    //document.getElementById("divErrMsgCnclRsn").style.display = "none";
                    //  }
                    //  var costId = 0;
                    //setTimeout(FillddlCostCenter(x, y, CostCenterId), 10000);
                    FillddlCostCenter(x, y, COSTCNTR_ID);

                    if (y == ROWCOUNT) {
                        document.getElementById("tdInxQstn" + x + '' + ROWCOUNT).value = "";
                        document.getElementById("btnCostCenter_" + x + '' + ROWCOUNT).style.opacity = "1";
                        document.getElementById("btnCostCenter_" + x + '' + y).disabled = false;
                    }
                    else {
                        document.getElementById("btnCostCenter_" + x + '' + y).style.opacity = "0.3";
                        document.getElementById("btnCostCenter_" + x + '' + y).disabled = true;
                    }



                    // $au("#ddlRecptCosCtr_" + x + '' + y).selectToAutocomplete1Letter();
                    // $au("div#divCostCenter" + x + '' + y + " input.ui-autocomplete-input").val("--SELECT--");

                    //   $au("#ddlRecptCosCtr_" + x + '' + y).selectToAutocomplete1Letter();
                    //  CheckSubmitZero();

                    currntx = x;
                    currnty = y;


                    //  $("#ddlRecptCosCtr_" +  + x + '' + y ).val("--SELECT--");
                    return false;

                }





                //function EditLiscostcenttRows(x, y, RECPT_CST_ID, COSTCNTR_ID, RECPT_ID, RECPT_CST_AMT, RECPT_LD_ID, SALES_ID, RECPT_SALES_REF, ROWCOUNT, SALEAMOUNT)
                //{
                //   // alert(y);
                //        var FrecRowQst = '';

                //        FrecRowQst += '<tr id="SubQstnRowId_' + x + '' + y + '" ><td   id="tdidQstnDtls' + x + '' + y + '" style="display: none" >' + x + '' + y + '</td>';
                //        FrecRowQst += '<td   id="tdvalidate' + x + '' + y + '" style="display: none" >' + x + '</td>';
                //        FrecRowQst += '<td   id="tdvalidatey' + x + '' + y + '" style="display: none" >' + y + '</td>';
                //        FrecRowQst += '<td  style="width:50%">';
                //        if (SALES_ID != 0) {
                //            FrecRowQst += '<input  name="TxtIdSales_' + x + '' + y + '" style="display: none;" value=' + SALES_ID + ' class="form-control" id="TxtIdSales_' + x + '' + y + '" >';
                //            FrecRowQst += '<input name="TxtRecptCosCtr_' + x + '' + y + '" value=' + RECPT_SALES_REF + '  style="pointer-events: none;background: #eee;" class="form-control" id="TxtRecptCosCtr_' + x + '' + y + '" >';
                //            FrecRowQst += '<div id="divCostCenter' + x + '' + y + '"> <select id="ddlRecptCosCtr_' + x + '' + y + '" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);"  class="form-control ddl" onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');"  >';
                //            FrecRowQst += '</select></div><input  style="display: none"  name="ddlCostCtrId_' + x + '' + y + '"  class="form-control" id="ddlCostCtrId_' + x + '' + y + '" >';
                //        }
                //        if (COSTCNTR_ID != 0) {
                //            FrecRowQst += '<input  name="TxtIdSales_' + x + '' + y + '" style="display: none;" value="" class="form-control" id="TxtIdSales_' + x + '' + y + '" >';
                //            FrecRowQst += '<input name="TxtRecptCosCtr_' + x + '' + y + '"  style="display: none;" value=""  style="pointer-events: none;background: #eee;" class="form-control" id="TxtRecptCosCtr_' + x + '' + y + '" >';
                //            FrecRowQst += '<div id="divCostCenter' + x + '' + y + '"> <select id="ddlRecptCosCtr_' + x + '' + y + '" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);" class="form-control ddl" onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');"  >';
                //            FrecRowQst += '</select></div><input  style="display: none"  name="ddlCostCtrId_' + x + '' + y + '" value=' + COSTCNTR_ID + '  class="form-control" id="ddlCostCtrId_' + x + '' + y + '" >';
                //        }
                //        FrecRowQst += '</td><td  style="width:40%"><input class="form-control"   id="TxtCstctrAmount_' + x + '' + y + '" value=' + RECPT_CST_AMT + ' onblur="return CheckSumOfCstCntr(TxtCstctrAmount_' + x + '' + y + ',' + x + ',' + y + ');" onkeyup="addCommas("TxtCstctrAmount_' + x + '' + y + '")"  MaxLength="10" onkeydown="return isNumber(event,TxtCstctrAmount_' + x + '' + y + ');" style="text-align: right;" name="TxtCstctrAmount_' + x + '' + y + '" type="text"><input class="form-control"   id="TxtActCstctrAmount_' + x + '' + y + '" value=' + SALEAMOUNT + ' onblur="return CheckSumOfCstCntr(TxtActCstctrAmount_' + x + '' + y + ',' + x + ',' + y + ');" onkeyup="addCommas("TxtActCstctrAmount_' + x + '' + y + '")" style="text-align: right; display:none" onkeydown="return isNumber(event,TxtActCstctrAmount_' + x + '' + y + ');" name="TxtActCstctrAmount_' + x + '' + y + '" type="text"></td>';
                //        FrecRowQst += '<td style="width:10%;"><button class="btn btn-primary" onclick="return removeRowQstn(' + x + ',' + y + ',' + x + '' + y + ',\'Are you sure you want to delete this cost center?\')" style="margin-bottom:8%;">';
                //        FrecRowQst += '<span title="DELETE"   class="fa fa-trash" id="Span4" style="display: block;">&nbsp;</span></button>';
                //        FrecRowQst += '<button title="ADD" id="btnCostCenter_' + x + '' + y + '" onclick="return CheckaddMoreRowsQstn(\'' + x + '\',\'' + y + '\');" class="btn btn-primary"><span  class="fa fa-plus"  style="display: block;">&nbsp;</span></button></td>';
                //        FrecRowQst += '<td   style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value=' + RECPT_CST_ID + ' id="tdrcptcstCntrId' + x + '' + y + '" name="tdrcptcstCntrId' + x + '' + y + '" placeholder=""/></td>';
                //        FrecRowQst += '<td   style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value="UPD" id="tdEvtQstn' + x + '' + y + '" name="tdEvtQstn' + x + '' + y + '" placeholder=""/></td>';
                //        FrecRowQst += '<td style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdDtlIdQstn' + x + '' + y + '" name="tdDtlIdQstn' + x + '' + y + '" value="' + RECPT_CST_ID + '" placeholder=""/></td>';
                //        FrecRowQst += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdInxQstn' + x + '' + y + '" value="' + x + '' + y + ' " name="tdInxQstn' + x + '' + y + '" placeholder=""/> </td></tr>';
                //        jQuery('#TableQstn_' + x).append(FrecRowQst);
                //        if (COSTCNTR_ID != 0) {
                //            FillddlCostCenter(x, y, COSTCNTR_ID);
                //            $au("#ddlRecptCosCtr_" + x + '' + y).selectToAutocomplete1Letter();

                //        }
                //        else {
                //            var sel = "";
                //            FillddlCostCenter(x, y, sel);
                //            $au("#ddlRecptCosCtr_" + x + '' + y).selectToAutocomplete1Letter();
                //        }
                //        if (SALES_ID != 0) {
                //            //document.getElementById("ddlRecptCosCtr_" + x + '' + y).style.display = "none";
                //            document.getElementById("divCostCenter" + x + '' + y).style.display = "none";
                //        }
                //      //  addCommas("TxtCstctrAmount_" + x + '' + y );
                //     // alert("ROWCOUNT" + ROWCOUNT);
                //      if (y == ROWCOUNT) {
                //        //  document.getElementById("tdInxQstn" + x + '' + ROWCOUNT).value = "";
                //         // document.getElementById("btnCostCenter_" + x + '' + ROWCOUNT).style.opacity = "1";
                //      }
                //      else {
                //          document.getElementById("btnCostCenter_" + x + '' + y).style.opacity = "0.3";
                //          document.getElementById("btnCostCenter_" + x + '' + y).disabled = true;
                //      }
                //        currntx = x;
                //        currnty = y;
                //      //  addCommas("TxtCstctrAmount_" + x + '' + y);
                //     //  y++;
                //    //alert(currnty);
                //    return true;
                //}


                function removeRowGrps(removeNum, CofirmMsg) {
                    IncrmntConfrmCounter();
                    if (document.getElementById("cphMain_HiddenFieldView").value != "1") {
                        ezBSAlert({
                            type: "confirm",
                            messageText: CofirmMsg,
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                var evt = document.getElementById("tdEvtGrp" + removeNum).value;

                                if (evt == 'UPD') {
                                    var ROWDEC = parseFloat(removeNum);

                                    var detailId = document.getElementById("tdDtlIdGrp" + removeNum).value;
                                    var CanclIds = document.getElementById("cphMain_hiddenLedgerCanclDtlId").value;
                                    if (CanclIds == '') {
                                        document.getElementById("cphMain_hiddenLedgerCanclDtlId").value = detailId;
                                    }
                                    else {
                                        document.getElementById("cphMain_hiddenLedgerCanclDtlId").value = document.getElementById("cphMain_hiddenLedgerCanclDtlId").value + ',' + detailId;
                                    }
                                }
                                CheckSumOfLedger("TxtAmount_" + removeNum, removeNum);
                                jQuery('#SubGrpRowId_' + removeNum).remove();
                                var addRowtable = document.getElementById("tableGrp");
                                var TableRowCount = document.getElementById("tableGrp").rows.length;
                                if (TableRowCount != 1) {

                                    for (var i = 1; i < addRowtable.rows.length; i++) {
                                        var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                                        if ((TableRowCount - 1) == i) {
                                            document.getElementById("tdInxGrp" + xLoop).value = "";
                                            document.getElementById("journalADD" + xLoop).style.opacity = "1";
                                        }

                                    }
                                }


                                else {
                                    document.getElementById("<%=HiddenTotalAmount.ClientID%>").value = "";
                        document.getElementById("<%=txtTotalAmt.ClientID%>").value = "";
                        AddNewGroup();
                    }
                }
                else {
                }

                    calculateTotal();






                });
            return false;
        }
        else {
            return false;
        }

    }
    function calculateTotal() {
        var LedgerTtl = 0;
        var addRowtable = document.getElementById("tableGrp");

        for (var i = 1; i < addRowtable.rows.length; i++) {
            var row = addRowtable.rows[i];
            var x = (addRowtable.rows[i].cells[0].innerHTML);
            if (document.getElementById("TxtAmount_" + x).value != "") {
                var ldgramt = document.getElementById("TxtAmount_" + x).value;
                ldgramt = ldgramt.replace(/\,/g, '');
                LedgerTtl = parseFloat(LedgerTtl) + +parseFloat(ldgramt);
            }
        }
        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;



            document.getElementById("cphMain_txtTotalAmt").value = LedgerTtl;

            addCommas("cphMain_txtTotalAmt");
            document.getElementById("<%=HiddenTotalAmount.ClientID%>").value = LedgerTtl;
        }

        function removeRowQstn(Rowid, y, removeNum, CofirmMsg) {
            IncrmntConfrmCounter();

            if (document.getElementById("cphMain_HiddenFieldView").value != "1") {
                //alert(removeNum);
                if (confirm(CofirmMsg)) {
                    var evt = document.getElementById("tdEvtQstn" + removeNum).value;

                    if (evt == 'UPD') {
                        var detailId = document.getElementById("tdrcptcstCntrId" + removeNum).value;
                        //document.getElementById("tdDtlIdQstn" + removeNum).value;

                        var CanclIds = document.getElementById("cphMain_hiddenQstnCanclDtlId").value;
                        if (CanclIds == '') {
                            document.getElementById("cphMain_hiddenQstnCanclDtlId").value = detailId;
                        }
                        else {
                            document.getElementById("cphMain_hiddenQstnCanclDtlId").value = document.getElementById("cphMain_hiddenQstnCanclDtlId").value + ',' + detailId;
                        }
                    }

                    // var row_index = jQuery('#TarffRowId_' + removeNum).index();


                    //  RowIndexTarff--;

                    //    var BforeRmvTableRowCount = document.getElementById("TableQstn_").rows.length;


                    jQuery('#SubQstnRowId_' + removeNum).remove();






                    var TableRowCount = document.getElementById("TableAddQstnCostCenter" + Rowid).rows.length;

                    //  if (TableRowCount != 0) {
                    if (TableRowCount - 1 != 0) {
                        var idlast = $noCon('#TableAddQstnCostCenter' + Rowid + ' tr:last').attr('id');

                        if (idlast != "") {

                            var res = idlast.split("_");
                            //  alert(res[1]);
                            //  if (document.getElementById("ddlRecptCosCtr_" + res[1]).style.display=="block") {
                            document.getElementById("tdInxQstn" + res[1]).value = "";
                            document.getElementById("btnCostCenter_" + res[1]).style.opacity = "1";
                            document.getElementById("btnCostCenter_" + res[1]).disabled = false;
                            setTimeout(function () { focusCostCentre(res[1]); }, 350);
                            //  }
                            //btnaddqstn
                            // document.getElementById("btnImportQstn_" + res[1]).style.opacity = "1";
                            // document.getElementById("btnImportQstn_" + res[1]).disabled = false;
                        }
                    }
                    else {

                        FunctionQustn(Rowid, y, null, null);
                    }
                    CheckSumOfCstCntr("TxtCstctrAmount_" + removeNum, Rowid, y);


                    return false;
                }
                else {
                    return false;

                }
            }
            else {
                return false;

            }
        }
        var varRowidx = "";
        var varRowidy = "";

        function CCGrp1Duplication(x, xy) {
            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "none";
            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
            for (var i = 0; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                var xLoopLdgrId = $("#ddlRecptCosGrp1_" + xLoop).val();
                var LedgerId = $("#ddlRecptCosGrp1_" + xy).val();

                if ($("#ddlRecptCosGrp1_" + xy).val() != "0") {
                    if (xLoop != xy) {
                        if (xLoopLdgrId == LedgerId) {
                            $("#divCostGrp1" + xy + "> input").css("borderColor", "red");
                            $("#divCostGrp1" + xy + "> input").focus();
                            $("#divCostGrp1" + xy + "> input").select();
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Cost Group should not be duplicated";
                            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                            $noCon(window).scrollTop(0);
                            //flag++;
                            ret = false;

                        }
                    }
                    else {
                      //  $("#divCostGrp1" + xy + "> input").css("borderColor", "");
                    }
                }
                else {
                   // $("#divCostGrp1" + xy + "> input").css("borderColor", "");
                }
            }
            return ret;
        }

        function CCGrp2Duplication(x, xy) {
            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "none";
            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
            for (var i = 0; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                var xLoopLdgrId = $("#ddlRecptCosGrp2_" + xLoop).val();
                var LedgerId = $("#ddlRecptCosGrp2_" + xy).val();
                if (xLoop != xy) {
                    if (LedgerId != "0") {
                        if (xLoopLdgrId == LedgerId) {
                            $("#divCostGrp2" + xy + "> input").css("borderColor", "red");
                            $("#divCostGrp2" + xy + "> input").focus();
                            $("#divCostGrp2" + xy + "> input").select();
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Cost Group should not be duplicated";
                            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                            $noCon(window).scrollTop(0);
                            //flag++;
                            ret = false;

                        }
                        else {

                          //  $("#divCostGrp2" + xy + "> input").css("borderColor", "");

                        }
                    }
                    else {
                      //  $("#divCostGrp2" + xy + "> input").css("borderColor", "");
                    }
                }
            }
            return ret;
        }
        function CCDuplication(x, xy) {
            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "none";
            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
            for (var i = 0; i < addRowtable.rows.length; i++) {

              
                $("#divCostGrp1" + xLoop + "> input").css("borderColor", "");

                $("#divCostGrp2" + xLoop + "> input").css("borderColor", "");

                $("#divCostCenter" + xLoop + "> input").css("borderColor", "");


                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                var xLoopLdgrId = $("#ddlRecptCosCtr_" + xLoop).val();


                var LedgerId = $("#ddlRecptCosCtr_" + xy).val();

                var xLoopLdgrId2 = $("#ddlRecptCosGrp2_" + xLoop).val();



                var LedgerId2 = $("#ddlRecptCosGrp2_" + xy).val();

                var xLoopLdgrId1 = $("#ddlRecptCosGrp1_" + xLoop).val();
                var LedgerId1 = $("#ddlRecptCosGrp1_" + xy).val();


                if (xLoop != xy) {
                    if ((xLoopLdgrId == LedgerId) && (xLoopLdgrId1 == LedgerId1) && (xLoopLdgrId2 == LedgerId2)) {

                        $("#divCostGrp1" + xy + "> input").css("borderColor", "red");
                      

                        $("#divCostGrp2" + xy + "> input").css("borderColor", "red");

                        $("#divCostCenter" + xy + "> input").css("borderColor", "red");

                       
                        $("#divCostGrp1" + xy + "> input").focus();
                        $("#divCostGrp1" + xy + "> input").select();

                        //   $("#divCostCenter" + xy + "> input").focus();
                        //$("#divCostCenter" + xy + "> input").select();
                        document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Cost centres should not be duplicated for cost groups";
                        document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
                        document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                        $noCon(window).scrollTop(0);
                        //flag++;
                        ret = false;

                    }
                    else {
                        $("#divCostGrp1" + xy + "> input").css("borderColor", "");


                        $("#divCostGrp2" + xy + "> input").css("borderColor", "");

                        $("#divCostCenter" + xy + "> input").css("borderColor", "");
                       
                    }
                }
            }
            return ret;
        }
        function ddlCostCenterOnchange(x, y) {
            IncrmntConfrmCounter();
            if (document.getElementById("ddlRecptCosCtr_" + x + '' + y).value != 0) {

                var ddlCostcnt = document.getElementById("ddlRecptCosCtr_" + x + '' + y).value;
                document.getElementById("ddlCostCtrId_" + x + '' + y).value = ddlCostcnt;


            }

            CCDuplication(x, x + '' + y);
        } 
        function LedgerDuplication(rowId) {

            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("tableGrp");

            if (document.getElementById("<%=HiddenLedgrDupSts.ClientID%>").value != "1") {
                for (var i = 1; i < addRowtable.rows.length; i++) {
                    var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                    var xLoopLdgrId = document.getElementById("ddlRecptLedger" + xLoop).value;
                    var LedgerId = document.getElementById("ddlRecptLedger" + rowId).value;
                    if (xLoop != rowId) {
                        document.getElementById("ddlRecptLedger" + rowId).style.borderColor = "";
                        $("#divLedger" + rowId + "> input").css("borderColor", "");

                        if (xLoopLdgrId == LedgerId) {

                            $("#divLedger" + rowId + "> input").css("borderColor", "Red");
                            $("#divLedger" + rowId + "> input").focus();
                            $("#divLedger" + rowId + "> input").select();

                            //  document.getElementById("ddlRecptLedger" + rowId).style.borderColor="red";
                            $noCon("#divWarning").html("Ledger can not be duplicated.");
                            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                            });

                            $noCon(window).scrollTop(0);


                            flag++;

                            // document.getElementById("ddlRecptLedger" + rowId).clearAttributes();
                            ret = false;

                        }
                    }
                }
            }
            return ret;
        }
        function SalesLedger(x) {
            var LedgerId = 0;
            if (document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) {
                if (LedgerDuplication(x) == true) {
                    LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                    document.getElementById("ddlLedId" + x).value = LedgerId;

                    document.getElementById("TxtAmount_" + x).value = "";
                    document.getElementById("tdCostCenterDtls" + x).value = "";
                    // document.getElementById("tdSalesDtls" + x).value = "";
                }
            }
        }
        function showBalenceAmt(x, y) {

            if (document.getElementById("ddlRecptLedger" + x).value != 0) {
                //     if (document.getElementById("ddlLedId" + x).value != document.getElementById("ddlRecptLedger" + x).value) {

                //   ddlLedId
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';
                var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                var rcptLdId = document.getElementById("tdRcptLdgrId" + x).value;
                document.getElementById("ddlLedId" + x).value = LedgerId;

                //  document.getElementById("TxtAmount_" + x).value = "";
                //document.getElementById("ChkSale" + x).style.backgroundColor = "#337ab7";
                //   document.getElementById("ChkSale" + x).className = "gre";

                //document.getElementById("ChkSale" + x).attributes.cl= "#337ab7";
                document.getElementById("ChkSale" + x).style.opacity = "1";

                document.getElementById("<%=HiddenChangeSts.ClientID%>").value = "0";
                var chngSts = document.getElementById("<%=HiddenChangeSts.ClientID%>").value;
                var CrncyAbrvtn = document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;

                var rcptId = document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value;
                var View = document.getElementById("<%=HiddenView.ClientID%>").value;

                if (rcptId == "") {
                    rcptId = "0";
                }
                document.getElementById("tdCostCenterDtls" + x).value = "";

                var LedgerDtlId = document.getElementById("tdRcptLdgrId" + x).value;
                //--1--    On ledger chng
                $noCon.ajax({
                    type: "POST",
                    url: "fms_Receipt_Account.aspx/LoadSalesForLedger",
                    data: '{intLedgerId:"' + LedgerId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",x:"' + x + '",rcptLdId:"' + rcptLdId + '",chngSts:"' + chngSts + '",CrncyAbrvtn:"' + CrncyAbrvtn + '",rcptId:"' + rcptId + '",View:"' + View + '" ,LedgerDtlId:"' + LedgerDtlId + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        document.getElementById("tdOpenSts" + x).value = response.d[5];
                        if (document.getElementById("tdOpenSts" + x).value != "1") {
                            document.getElementById("tdLedgrPaid" + x).value = "";
                        }

                        document.getElementById("<%=HiddenOBstatus.ClientID%>").value = response.d[5];

                        if (response.d[2] == "DR") {
                            $("#AccntBalance_" + x).addClass("input-group-addon cur2 dr1");
                        }
                        else if (response.d[2] == "CR") {
                            $("#AccntBalance_" + x).addClass("input-group-addon cur2 c1h");
                        }

                        if (response.d[0] != "") {
                            document.getElementById("TxtAmount_" + x).value = "";
                            document.getElementById("tdSalesDtls" + x).value = "";
                        }
                        else {
                            document.getElementById("tdSalesDtls" + x).value = "";
                            document.getElementById("TxtAmount_" + x).value = "";
                        }

                        if (response.d[4] == "") {

                            if (response.d[1] != "") {
                                document.getElementById("AccntBalance_" + x).innerHTML = response.d[1];
                                addCommaLedger("AccntBalance_" + x);
                                document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("AccntBalance_" + x).innerHTML + " " + response.d[2] + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                                document.getElementById("lblCurrency").innerHTML = document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                            }

                            if (response.d[3] != "") {
                                if (response.d[3] == "0" || response.d[3] == "1") {
                                    document.getElementById('ChkCostCenter' + x).style.pointerEvents = 'none';
                                    document.getElementById('ChkCostCenter' + x).style.opacity = "0.5";
                                }
                                else {
                                    document.getElementById('ChkCostCenter' + x).style.pointerEvents = 'auto';
                                    document.getElementById('ChkCostCenter' + x).style.opacity = "1";
                                }
                            }
                        }
                        else if (response.d[4] == "1") {
                            document.getElementById("btnImportSales").disabled = true;
                        }

                    },
                    failure: function (response) {

                    }


                });


            }
        }


        function ddlLedOnchange(x, y) {
            var EditVal = document.getElementById("cphMain_HiddenEdit").value;
            var viewVal = document.getElementById("cphMain_HiddenViewDtls").value;
            var ret = true;
            //   alert();
            //  showBalenceAmt(x, y);
            // alert(document.getElementById("ddlRecptLedger" + x).value);
            var TxtCstctrAmount = "";
            TxtCstctrAmount = document.getElementById("TxtAmount_" + x).value;
            TxtCstctrAmount = TxtCstctrAmount.trim();
            TxtCstctrAmount = TxtCstctrAmount.replace(/,/g, "");
            document.getElementById("TxtAmount_" + x).style.borderColor = "";
            $("#divLedger" + x + "> input").css("borderColor", "");
            if ((document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) && TxtCstctrAmount != "") {
                // Purchase_ret = true;
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                TxtCstctrAmount = parseFloat(TxtCstctrAmount);
                if (FloatingValue != "") {
                    TxtCstctrAmount = TxtCstctrAmount.toFixed(FloatingValue);
                }
                addCommasSummry(TxtCstctrAmount);
                document.getElementById("LedgerAmtInModalPurchse").innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                // document.getElementById("LedgerAmtInModalPurchse").innerText = TxtCstctrAmount;
                if (document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value != "") {
                    document.getElementById("LedgerAmtInModalPurchse").innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                }

                document.getElementById("lblLdgrAmt").innerText = TxtCstctrAmount + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;//evm 0044 07/02

            }
            if (document.getElementById("ddlRecptLedger" + x).value == "" || document.getElementById("ddlRecptLedger" + x).value == 0) {
                // Purchase_ret = false;
                $("#divLedger" + x + "> input").css("borderColor", "red");
                $("#divLedger" + x + "> input").focus();
                $("#divLedger" + x + "> input").select();
                ret = false;
            }

            if (TxtCstctrAmount == "") {
                //   Purchase_ret = false;
                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                document.getElementById("TxtAmount_" + x).focus();
                ret = false;
            }
            var LedgrRet = LedgerDuplication(x);
            if (LedgrRet == true && ret == true) {
                varRowidx = x;
                if (document.getElementById("ddlRecptLedger" + x).value != 0) {
                    var corpid = '<%= Session["CORPOFFICEID"] %>';
                    var orgid = '<%= Session["ORGID"] %>';
                    var userid = '<%= Session["USERID"] %>';
                    var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                    document.getElementById("ddlLedId" + x).value = LedgerId;
                    var rcptLdId = document.getElementById("tdRcptLdgrId" + x).value;
                    var chngSts = document.getElementById("<%=HiddenChangeSts.ClientID%>").value;
                    var CrncyAbrvtn = document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                    //  var per
                    var rcptId = document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value;
                    var View = document.getElementById("<%=HiddenView.ClientID%>").value;

                    if (rcptId == "") {
                        rcptId = "0";
                    }

                    var LedgerDtlId = document.getElementById("tdRcptLdgrId" + x).value;
                    //--2--    On sales click
                    var opBalance = 0;//evm 0044
                    var settle = 0;//evm 0044
                    $noCon.ajax({
                        type: "POST",
                        async:false,
                        url: "fms_Receipt_Account.aspx/LoadSalesForLedger",
                        data: '{intLedgerId:"' + LedgerId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",x:"' + x + '",rcptLdId:"' + rcptLdId + '",chngSts:"' + chngSts + '",CrncyAbrvtn:"' + CrncyAbrvtn + '",rcptId:"' + rcptId + '",View:"' + View + '",LedgerDtlId:"' + LedgerDtlId + '"  }',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {

                            document.getElementById("tdOpenSts" + x).value = response.d[5];
                            document.getElementById("<%=HiddenOBstatus.ClientID%>").value = response.d[5];

                            if (response.d[2] == "DR") {
                                $("#AccntBalance_" + x).addClass("input-group-addon cur2 dr1");
                            }
                            else if (response.d[2] == "CR") {
                                $("#AccntBalance_" + x).addClass("input-group-addon cur2 c1h");
                            }

                            document.getElementById("DivPopUpSales").innerHTML = response.d[0];
                            if (response.d[0] != "") {
                                // document.getElementById("ChkSale" + x).style.backgroundColor = "#00b147";
                                document.getElementById("DivPopUpSales").innerHTML = response.d[0];
                                document.getElementById("btnImportSales").style.display = "";
                                document.getElementById("BtnPopup").click();

                                if (response.d[4] == "") {

                                    document.getElementById("PurchaseName").innerHTML = response.d[3];
                                    var PrchaseTTl = "0";
                                    var addRowtable = document.getElementById("TableAddQstn");
                                    var j = 1;

                                    if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                                        j++;
                                        if (addRowtable.rows.length == 2) {
                                            if (document.getElementById("tdOpenSts" + varRowidx).value == 1) {
                                                if (document.getElementById("txtOpeningBalnc" + x).value != "") {
                                                }
                                            }
                                        }
                                        if (document.getElementById("tdLedgrPaid" + x).value != "") {
                                            var txtOBAmt = document.getElementById("tdLedgrPaid" + x).value;
                                            var amt = txtOBAmt.split("#");
                                            if (amt[0] != null && amt[0] != "" && amt[0] != "null" && amt[0] != "0") {
                                                document.getElementById("txtOpeningBalnc" + x).value = amt[0];
                                                //evm 0044
                                                document.getElementById("lblOpBalance").innerText = amt[0];
                                                opBalance = amt[0];
                                            }
                                            else {
                                                document.getElementById("txtOpeningBalnc" + x).value = "";

                                                opBalance = 0;//evm 0044
                                            }
                                        }
                                        else {//evm 0044
                                            opBalance = 0;//evm 0044
                                        }

                                        //evm-0020
                                        document.getElementById("tdOpeningBalnc" + x).innerHTML = document.getElementById("tdDupOBAmnt" + x).innerHTML;
                                        var OBPaid = DuplicateOBSettlementChange(x);
                                        var OBBalAmnt = parseFloat(document.getElementById("tdOpeningBalnc" + x).innerHTML) - parseFloat(OBPaid);
                                        document.getElementById("tdOpeningBalnc" + x).innerHTML = OBBalAmnt;
                                        AmountCheckingLabel("tdOpeningBalnc" + x);
                                        if (response.d[6] == "CR")
                                            OBBalAmnt = -1 * OBBalAmnt;
                                        document.getElementById("tdOpeningBalnc" + x).innerHTML = OBBalAmnt + " " + response.d[6];//EVM-0027 AUG26
                                    }
                                    else {
                                        opBalance = 0;//evm 0044
                                    }

                                    if (document.getElementById("tdSalesDtls" + x).value != "") {
                                        var CstCntrDtl = document.getElementById("tdSalesDtls" + x).value;
                                   
                                        var splitrow = CstCntrDtl.split("$");
                                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                                            var splitEach = splitrow[Cst].split("%");

                                            for (var i = j; i < addRowtable.rows.length; i++) {
                                                var P_Id = (addRowtable.rows[i].cells[0].innerHTML);

                                                var PrchsAmnt = 0;

                                                if (document.getElementById("tdSettld" + P_Id).value == "0") {
   
                                                    if (document.getElementById("tdSaleID" + P_Id).innerHTML == splitEach[0])
                                                    {
                                                        if (splitEach[1] != "0") {
                                                            document.getElementById("txtPurchaseAmt" + P_Id).value = splitEach[1];
                                                        }
                                                        PrchaseTTl = parseFloat(PrchaseTTl) + parseFloat(splitEach[1]);

                                                        var purchAmt = splitEach[1];
                                                        purchAmt = purchAmt.replace(/\,/g, '');

                                                        if (purchAmt == "") {
                                                            purchAmt = 0;
                                                        }
                                                        var saleamt = document.getElementById("tdAmnt" + P_Id).innerHTML;
                                                        saleamt = saleamt.replace(/\,/g, '');

                                                        var purchAmt2 = 0;
                                                        if (splitEach[4] != "0") {                                                           
                                                             purchAmt2 = splitEach[6];
                                                            purchAmt2 = purchAmt2.replace(/\,/g, '');
                                                            if (purchAmt2 == "") {
                                                                purchAmt2 = 0;
                                                            }
                                                        }

                                                        var BlncAmt = parseFloat(saleamt) - (parseFloat(purchAmt) + parseFloat(purchAmt2));
                                                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                                                        if (FloatingValue != "") {
                                                            BlncAmt = BlncAmt.toFixed(FloatingValue)
                                                        }

                                                        addCommasSummry(BlncAmt);
                                                        document.getElementById("SlsBlnc" + P_Id).innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;

                                                        if (splitEach[4] != "0") {
                                                            document.getElementById("cbx_sly" + P_Id).checked = true;
                                                            document.getElementById("ddlCreditNote" + P_Id).disabled = false;
                                                            document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).disabled = false;

                                                            var purchAmt = splitEach[5];
                                                            purchAmt = purchAmt.replace(/\,/g, '');
                                                            if (purchAmt == "") {
                                                                purchAmt = 0;
                                                            }
                                                            var BlncAmt =  parseFloat(purchAmt);
                                                            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                                                            if (FloatingValue != "") {
                                                                BlncAmt = BlncAmt.toFixed(FloatingValue)
                                                            }
                                                            addCommasSummry(BlncAmt);

                                                            document.getElementById("creNoteBalaF" + P_Id).innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                                                        }
                                                        else {
                                                            document.getElementById("cbx_sly" + P_Id).checked = false;
                                                        }
                                                        document.getElementById("ddlCreditNote" + P_Id).value = splitEach[4];
                                                        document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).value = splitEach[6];
                                                        document.getElementById("tdCredNoteAmnt" + P_Id).innerHTML = splitEach[5];

                                                        //document.getElementById("creNoteBala" + P_Id).innerHTML = document.getElementById("SlsBlnc" + P_Id).innerHTML;


                                                        AmountChecking("txtCreNoteStlmntAmmnt" + P_Id);
                                                        AmountChecking("txtPurchaseAmt" + P_Id);


                                                        //evm-0020
                                                        if (document.getElementById("txtPurchaseAmt" + P_Id).value != "") {
                                                            PrchsAmnt = document.getElementById("txtPurchaseAmt" + P_Id).value;
                                                        }
                                                        document.getElementById("tdAmnt" + P_Id).innerHTML = document.getElementById("tdDupAmnt" + P_Id).innerHTML;
                                                        var MaxAmt = DuplicateSettlementChange(P_Id, x);
                                                        var BalAmnt = parseFloat(document.getElementById("tdAmnt" + P_Id).innerHTML) - parseFloat(MaxAmt); //- parseFloat(PrchsAmnt);
                                                        document.getElementById("tdAmnt" + P_Id).innerHTML = BalAmnt;
                                                        document.getElementById("tdBalnc" + P_Id).innerHTML = BalAmnt;
                                                        AmountCheckingLabel("tdBalnc" + P_Id);

                                                    }
                                                }
                                            }
                                        }
                                        if (opBalance > 0) {
                                            settle = 1;
                                            loadSettleAmount(-1);
                                        }
                                        else {
                                            settle = 1;
                                            loadSettleAmount(P_Id); //evm 0044 07/02
                                        }
                                    }

                                    if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                                        $("#TableAddQstn").find("input,select,checkbox").attr("disabled", "disabled");
                                        document.getElementById("btnImportSales").disabled = true;

                                    }


                                }
                                else if (response.d[4] != "" && response.d[4] == "1") {
                                    document.getElementById("btnImportSales").disabled = true;
                                }

                            }
                            else {

                                $('#TableAddQstnCostCenter' + x + ' td:first-child').each(function () {
                                    var varId = $(this).text();
                                    var TableRowCount1 = document.getElementById("TableAddQstnCostCenter" + x).rows.length;
                                    if (TableRowCount1 != 0 && TableRowCount1 != 1) {
                                        var idlast1 = $noCon('#TableAddQstnCostCenter' + x + ' tr:last').attr('id');

                                        if (idlast1 != "") {
                                            var res1 = idlast1.split("_");
                                            document.getElementById("tdInxQstn" + res1[1]).value = "";
                                            document.getElementById("btnCostCenter_" + res1[1]).style.opacity = "1";
                                            document.getElementById("btnCostCenter_" + res[1]).disabled = false;

                                            if (res1 != varId) {
                                                jQuery('#SubQstnRowId_' + res1[1]).remove();
                                            }

                                        }
                                    }
                                    document.getElementById("TxtAmount_" + varRowidx).value = "";
                                    document.getElementById("TxtRecptCosCtr_" + varId).style.display = "none";
                                    document.getElementById("divCostCenter" + varId).style.display = "block";
                                    document.getElementById("tdInxQstn" + varId).value = "";
                                    document.getElementById("btnCostCenter_" + varId).style.opacity = "1";
                                    document.getElementById("btnCostCenter_" + varId).disabled = false;

                                    document.getElementById("TxtCstctrAmount_" + varId).value = "";
                                    document.getElementById("TxtActCstctrAmount_" + varId).value = "";

                                    $("div#divCostCenter" + varId + " input.ui-autocomplete-input").val("--SELECT--");
                                    $("#ddlRecptCosCtr_" + varId).val("--SELECT--");
                                    CheckSumOfLedger("TxtAmount_" + varRowidx, varRowidx);

                                });

                            }
                            if (response.d[1] != "") {
                                document.getElementById("AccntBalance_" + x).innerHTML = response.d[1];
                                addCommaLedger("AccntBalance_" + x);
                                document.getElementById("AccntBalance_" + x).innerHTML = document.getElementById("AccntBalance_" + x).innerHTML + " " + response.d[2] + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;;
                            }


                            if (response.d[3] != "") {
                                if (response.d[3] == "0" || response.d[3] == "1") {
                                    document.getElementById('ChkCostCenter' + x).style.pointerEvents = 'none';
                                    document.getElementById('ChkCostCenter' + x).style.opacity = "0.5";
                                }
                                else {
                                    document.getElementById('ChkCostCenter' + x).style.pointerEvents = 'auto';
                                    document.getElementById('ChkCostCenter' + x).style.opacity = "1";
                                }
                            }


                        },
                        failure: function (response) {

                        }
                    });
                }
                else {
                    document.getElementById("TxtAmount_" + varRowidx).value = "";
                    document.getElementById("ddlLedId" + x).value = 0;

                    $('#TableQstn_' + x + ' td:first-child').each(function () {
                        var varId = $(this).text();

                        var TableRowCount1 = document.getElementById("TableQstn_" + x).rows.length;

                        if (TableRowCount1 != 0 && TableRowCount1 != 1) {
                            var idlast1 = $noCon('#TableQstn_' + x + ' tr:last').attr('id');

                            if (idlast1 != "") {
                                var res1 = idlast1.split("_");
                                document.getElementById("tdInxQstn" + res1[1]).value = "";
                                document.getElementById("btnCostCenter_" + res1[1]).style.opacity = "1";
                                document.getElementById("btnCostCenter_" + res1[1]).disabled = false;

                                if (res1 != varId) {
                                    jQuery('#SubQstnRowId_' + res1[1]).remove();

                                }

                            }
                        }
                        document.getElementById("TxtAmount_" + varRowidx).value = "";
                        document.getElementById("TxtRecptCosCtr_" + varId).style.display = "none";
                        document.getElementById("divCostCenter" + varId).style.display = "block";
                        document.getElementById("tdInxQstn" + varId).value = "";
                        document.getElementById("btnCostCenter_" + varId).style.opacity = "1";
                        document.getElementById("btnCostCenter_" + varId).disabled = false;

                        document.getElementById("TxtActCstctrAmount_" + varId).value = "";
                        document.getElementById("TxtCstctrAmount_" + varId).value = "";
                        $("div#divCostCenter" + varId + " input.ui-autocomplete-input").val("--SELECT--");
                        $("#ddlRecptCosCtr_" + varId).val("--SELECT--");
                        CheckSumOfLedger("TxtAmount_" + varRowidx, varRowidx);

                    });
                }

                var idlast = "";
                var addRowtable = document.getElementById("TableAddQstn");
                var j = 1;
                if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                     j++;
                 }
                var P_Id = 0;
                var FLGSLS = 0;
                for (var i = j; i < addRowtable.rows.length; i++) {
                    if (FLGSLS == 0) {
                        P_Id = (addRowtable.rows[i].cells[0].innerHTML);

                        FLGSLS = 1;
                    }
                }

                idlast = P_Id;

                if (opBalance < 0) {//evm 0044
                    loadSettleAmount(-1);
                }
                else if (settle == "0") {
                    loadSettleAmount(x);
                }

                setTimeout(function () { focusSale(idlast); }, 350);

                return false;
            }
        }

        function DuplicateOBSettlementChange(RowId) {//evm-0020

            var TotalAmnt = 0;

            addRowtableLdgr = document.getElementById("tableGrp");
            for (var row = 1; row < addRowtableLdgr.rows.length; row++) {
                var validRow = (addRowtableLdgr.rows[row].cells[0].innerHTML);

                var LedgerPaid = document.getElementById('tdLedgrPaid' + validRow).value;
                if (LedgerPaid != "" && LedgerPaid != "null" && LedgerPaid != null && validRow != RowId) {
                    var splitrow = LedgerPaid.split("#");
                    var EachAmnt = parseFloat(splitrow[0]);
                    //alert("EachAmnt " + EachAmnt);
                    TotalAmnt = parseFloat(TotalAmnt) - parseFloat(EachAmnt);
                }
            }
            return TotalAmnt;
        }


        function DuplicateSettlementChange(P_Id, RowId) {//evm-0020

            var TotalAmnt = 0;

            addRowtableLdgr = document.getElementById("tableGrp");
            for (var row = 1; row < addRowtableLdgr.rows.length; row++) {
                var validRow = (addRowtableLdgr.rows[row].cells[0].innerHTML);

                var LdgrIdAll = document.getElementById('ddlRecptLedger' + validRow).value;
                var PurchaseInfo = document.getElementById('tdSalesDtls' + validRow).value;

                if (PurchaseInfo!=null && PurchaseInfo!="null" && PurchaseInfo != "" && validRow != RowId) {

                    var splitrow = PurchaseInfo.split("$");
                    for (var Cst = 0; Cst < splitrow.length; Cst++) {
                        var splitEach = splitrow[Cst].split("%");
                        if (splitEach[0] != "" && splitEach[1] != "") {
                            var PrchsId = splitEach[0];
                            var LdgrId = document.getElementById("ddlRecptLedger" + validRow).value;

                            var PrchsAmnt = 0;
                            if (splitEach[1] != "") {
                                PrchsAmnt = splitEach[1].replace(/\,/g, '');
                            }
                            var DebitAmnt = 0;
                            if (splitEach[5] != "") {
                                DebitAmnt = splitEach[5].replace(/\,/g, '');
                            }
                            if (LdgrIdAll == LdgrId && P_Id == PrchsId) {
                                var EachAmnt = parseFloat(PrchsAmnt) + parseFloat(DebitAmnt);
                                //alert("EachAmnt " + EachAmnt);
                                TotalAmnt = parseFloat(TotalAmnt) + parseFloat(EachAmnt);
                            }
                        }
                    }

                }

            }
            return TotalAmnt;
        }

        function focusSale(Rowid) {

           // document.getElementById("txtPurchaseAmt" + Rowid).focus();
        }

        function ddlLedOnchangeEdit(x, y) {

            var settle = 0;
            var EditVal = document.getElementById("cphMain_HiddenEdit").value;
            var viewVal = document.getElementById("cphMain_HiddenViewDtls").value;
            var LedgrRet = LedgerDuplication(x);
            if (LedgrRet == true) {
                varRowidx = x;
                varRowidy = y;
                if (document.getElementById("ddlRecptLedger" + x).value != 0) {
                    var corpid = '<%= Session["CORPOFFICEID"] %>';
                    var orgid = '<%= Session["ORGID"] %>';
                    var userid = '<%= Session["USERID"] %>';
                    var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                    document.getElementById("ddlLedId" + x).value = LedgerId;
                    var rcptLdId = document.getElementById("tdRcptLdgrId" + x).value;
                    var chngSts = document.getElementById("<%=HiddenChangeSts.ClientID%>").value;
                    var CrncyAbrvtn = document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                    var rcptId = document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value;
                    var View = document.getElementById("<%=HiddenView.ClientID%>").value;

                    if (rcptId == "") {
                        rcptId = "0";
                    }
                    //  alert(rcptLdId);

                    var LedgerDtlId = document.getElementById("tdRcptLdgrId" + x).value;
                    //--3--    On edit view
                    $noCon.ajax({
                        type: "POST",
                        url: "fms_Receipt_Account.aspx/LoadSalesForLedger",
                        data: '{intLedgerId:"' + LedgerId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",x:"' + x + '",rcptLdId:"' + rcptLdId + '",chngSts:"' + chngSts + '",CrncyAbrvtn:"' + CrncyAbrvtn + '",rcptId:"' + rcptId + '",View:"' + View + '" ,LedgerDtlId:"' + LedgerDtlId + '"  }',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {

                            document.getElementById("tdOpenSts" + x).value = response.d[5];
                            document.getElementById("<%=HiddenOBstatus.ClientID%>").value = response.d[5];

                            if (response.d[2] == "DR") {
                                $("#AccntBalance_" + x).addClass("input-group-addon cur2 dr1");
                            }
                            else if (response.d[2] == "CR") {
                                $("#AccntBalance_" + x).addClass("input-group-addon cur2 c1h");
                            }

                            if (response.d[0] != "") {

                                //document.getElementById("ChkSale" + x).style.backgroundColor = "#00b147";
                                document.getElementById("DivPopUpSales").innerHTML = response.d[0];


                                document.getElementById("iSaleTag" + x).style.opacity = "1";
                                document.getElementById("iSaleTag" + x).className = "fa fa-balance-scale ad_fa gre";

                                if (response.d[4] == "") {

                                    document.getElementById("btnImportSales").style.display = "";
                                    document.getElementById("PurchaseName").innerHTML = response.d[3];


                                    var addRowtable = document.getElementById("TableAddQstn");

                                    var j = 1;
                                    if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                                        j++;
                                    }

                                    if (document.getElementById("tdSalesDtls" + x).value != "") {

                                        var CstCntrDtl = document.getElementById("tdSalesDtls" + x).value;
                                        var splitrow = CstCntrDtl.split("$");
                                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                                            var splitEach = splitrow[Cst].split("%");
                                            for (var i = j; i < addRowtable.rows.length; i++) {
                                                var P_Id = (addRowtable.rows[i].cells[0].innerHTML);

                                                var PrchsAmnt = 0;
                                                if (document.getElementById("tdSettld" + P_Id).value == "0") {

                                                    if (document.getElementById("tdSaleID" + P_Id).innerHTML == splitEach[0]) {
                                                        document.getElementById("txtPurchaseAmt" + P_Id).value = splitEach[1];


                                                        var purchAmt = splitEach[1];
                                                        purchAmt = purchAmt.replace(/\,/g, '');

                                                        if (purchAmt == "") {
                                                            purchAmt = 0;
                                                        }
                                                        var saleamt = document.getElementById("tdAmnt" + P_Id).innerHTML;
                                                        saleamt = saleamt.replace(/\,/g, '');
                                                        var BlncAmt = parseFloat(saleamt) - parseFloat(purchAmt);
                                                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                                                        if (FloatingValue != "") {
                                                            BlncAmt = BlncAmt.toFixed(FloatingValue)
                                                        }

                                                        addCommasSummry(BlncAmt);

                                                        document.getElementById("SlsBlnc" + P_Id).innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;


                                                        //evm-0020
                                                        if (document.getElementById("txtPurchaseAmt" + P_Id).value != "") {
                                                            PrchsAmnt = document.getElementById("txtPurchaseAmt" + P_Id).value;
                                                        }
                                                        document.getElementById("tdAmnt" + P_Id).innerHTML = document.getElementById("tdDupAmnt" + P_Id).innerHTML;
                                                        var MaxAmt = DuplicateSettlementChange(P_Id, x);
                                                        var BalAmnt = parseFloat(document.getElementById("tdAmnt" + P_Id).innerHTML) - parseFloat(MaxAmt) //- parseFloat(PrchsAmnt);
                                                        document.getElementById("tdAmnt" + P_Id).innerHTML = BalAmnt;
                                                        document.getElementById("tdBalnc" + P_Id).innerHTML = BalAmnt;
                                                        AmountCheckingLabel("tdBalnc" + P_Id);

                                                    }

                                                }
                                            }
                                        }
                                       
                                        settle = 1;
                                        loadSettleAmount(P_Id); //evm 0044 07/02
                                    }
                                }
                                else if (response.d[4] != "" && response.d[4] == "1") {
                                    document.getElementById("btnImportSales").disabled = true;
                                }
                                // ButtnFillClickSales(1);
                            }
                            else {

                                $('#TableAddQstnCostCenter' + x + ' td:first-child').each(function () {
                                    var varId = $(this).text();
                                    //   alert(varId);

                                    var TableRowCount1 = document.getElementById("TableAddQstnCostCenter" + x).rows.length;

                                    if (TableRowCount1 != 0 && TableRowCount1 != 1) {
                                        var idlast1 = $noCon('#TableAddQstnCostCenter' + x + ' tr:last').attr('id');

                                        if (idlast1 != "") {
                                            var res1 = idlast1.split("_");
                                            // alert(res1);
                                            document.getElementById("tdInxQstn" + res1[1]).value = "";
                                            document.getElementById("btnCostCenter_" + res1[1]).style.opacity = "1";
                                            document.getElementById("btnCostCenter_" + res1[1]).disabled = false;

                                            if (res1 != varId) {
                                                jQuery('#SubQstnRowId_' + res1[1]).remove();
                                                // var r = parseFloat(x) - 1;
                                                // CheckSumOfLedger("TxtAmount_" + r, r);

                                            }

                                        }
                                    }
                                    // jQuery('#SubQstnRowId_' + varId).remove();
                                    //FunctionQustn();
                                    //  document.getElementById("TxtRecptCosCtr_" + varId).style.display = "none";


                                    document.getElementById("TxtAmount_" + varRowidx).value = "";
                                    //document.getElementById("<%=txtTotalAmt.ClientID%>").value = "";
                                    //  document.getElementById("ddlRecptCosCtr_" + varId).value = "--SELECT--";
                                    //  $au("#ddlRecptCosCtr_" + varId).selectToAutocomplete1Letter();
                                    document.getElementById("TxtRecptCosCtr_" + varId).style.display = "none";
                                    document.getElementById("divCostCenter" + varId).style.display = "block";
                                    //  document.getElementById("ddlRecptCosCtr_" + varId).style.display = "block";

                                    document.getElementById("tdInxQstn" + varId).value = "";
                                    document.getElementById("btnCostCenter_" + varId).style.opacity = "1";
                                    document.getElementById("btnCostCenter_" + varId).disabled = false;

                                    document.getElementById("TxtCstctrAmount_" + varId).value = "";
                                    document.getElementById("TxtActCstctrAmount_" + varId).value = "";

                                    $("div#divCostCenter" + varId + " input.ui-autocomplete-input").val("--SELECT--");
                                    $("#ddlRecptCosCtr_" + varId).val("--SELECT--");
                                    //  jQuery('#SubQstnRowId_' + varId).remove();  //**//

                                    CheckSumOfLedger("TxtAmount_" + varRowidx, varRowidx);

                                });
                                //     document.getElementById("ChkSale" + x).className = "gre";
                                //document.getElementById("ChkSale" + x).style.backgroundColor = "#337ab7";
                                document.getElementById("ChkSale" + x).style.opacity = "0.5";
                            }


                            if (response.d[1] != "") {

                                document.getElementById("AccntBalance_" + x).innerHTML = response.d[1];
                                addCommaLedger("AccntBalance_" + x);
                                document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("AccntBalance_" + x).innerHTML + " " + response.d[2] + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;;



                            }



                            if (response.d[3] != "") {
                                if (response.d[3] == "0" || response.d[3] == "1") {
                                    document.getElementById('ChkCostCenter' + x).style.pointerEvents = 'none';
                                    document.getElementById('ChkCostCenter' + x).style.opacity = "0.5";
                                }
                                else {
                                    document.getElementById('ChkCostCenter' + x).style.pointerEvents = 'auto';
                                    document.getElementById('ChkCostCenter' + x).style.opacity = "1";
                                }
                            }


                        },
                        failure: function (response) {

                        }


                    });

                }
                else {
                    document.getElementById("ddlLedId" + x).value = 0;
                }

                if (settle == "0") {
                    loadSettleAmount(x);
                }

                return false;
            }
        }

            function addCommaLedger(textboxId) {

                nStr = document.getElementById(textboxId).innerHTML;
                //  alert(nStr);
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
                document.getElementById('' + textboxId + '').innerHTML = x1;
                //return x1;
            else
                document.getElementById('' + textboxId + '').innerHTML = x1 + "." + x2;
            // return x1 + "." + x2;
        }


        var $noconfli = jQuery.noConflict();
        function PendingSales(textboxid, x, y) {



            var EditVal = document.getElementById("cphMain_HiddenEdit").value;
            var viewVal = document.getElementById("cphMain_HiddenViewDtls").value;
            var ret = true;
            //   alert();
            //showBalenceAmt(x, y);
            // alert(document.getElementById("ddlRecptLedger" + x).value);
            var TxtCstctrAmount = "";
            TxtCstctrAmount = document.getElementById("TxtAmount_" + x).value;
            TxtCstctrAmount = TxtCstctrAmount.trim();
            TxtCstctrAmount = TxtCstctrAmount.replace(/,/g, "");
            // document.getElementById("TxtAmount_" + x).style.borderColor = "";
            //  $("#divLedger" + x + "> input").css("borderColor", "");
            if ((document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) && TxtCstctrAmount != "") {
                // Purchase_ret = true;
                //   document.getElementById("LedgerAmtInModalPurchse").innerText = TxtCstctrAmount;

                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                TxtCstctrAmount = parseFloat(TxtCstctrAmount);
                if (FloatingValue != "") {
                    TxtCstctrAmount = TxtCstctrAmount.toFixed(FloatingValue);
                }
                addCommasSummry(TxtCstctrAmount);
                document.getElementById("LedgerAmtInModalPurchse").innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;

                if (document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value != "") {
                    document.getElementById("LedgerAmtInModalPurchse").innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                }

                document.getElementById("lblLdgrAmt").innerText = TxtCstctrAmount + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;//evm 0044 07/02

            }
            var LedgrRet = LedgerDuplication(x);
            var ldgrSts = CheckSumOfLedger(textboxid, x);


            if (LedgrRet == true && ret == true) {
                varRowidx = x;

                if (document.getElementById("ddlRecptLedger" + x).value != 0 && ldgrSts == true) {
                    var corpid = '<%= Session["CORPOFFICEID"] %>';
                    var orgid = '<%= Session["ORGID"] %>';
                    var userid = '<%= Session["USERID"] %>';
                    var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                    document.getElementById("ddlLedId" + x).value = LedgerId;
                    var rcptLdId = document.getElementById("tdRcptLdgrId" + x).value;

                    var chngSts = document.getElementById("<%=HiddenChangeSts.ClientID%>").value;
                    var CrncyAbrvtn = document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                    var rcptId = document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value;
                    var View = document.getElementById("<%=HiddenView.ClientID%>").value;
                
                    if (rcptId == "") {
                        rcptId = "0";
                    }
                
                    //  var per

                    var LedgerDtlId = document.getElementById("tdRcptLdgrId" + x).value;
                    //--4--    On amount chng
                    $noCon.ajax({
                        type: "POST",
                        url: "fms_Receipt_Account.aspx/LoadSalesForLedger",
                        data: '{intLedgerId:"' + LedgerId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",x:"' + x + '",rcptLdId:"' + rcptLdId + '",chngSts:"' + chngSts + '",CrncyAbrvtn:"' + CrncyAbrvtn + '",rcptId:"' + rcptId + '",View:"' + View + '",LedgerDtlId:"' + LedgerDtlId + '"  }',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {

                            document.getElementById("tdOpenSts" + x).value = response.d[5];
                            document.getElementById("<%=HiddenOBstatus.ClientID%>").value = response.d[5];

                            if (response.d[2] == "DR") {

                                $("#AccntBalance_" + x).addClass("input-group-addon cur2 dr1");
                            }
                            else if (response.d[2] == "CR") {
                                $("#AccntBalance_" + x).addClass("input-group-addon cur2 c1h");
                            }

                                document.getElementById("DivPopUpSales").innerHTML = response.d[0];
                                if (response.d[0] != "") {
                                    document.getElementById("ChkSale" + x).style.opacity = "1";
                                    document.getElementById("iSaleTag" + x).className = "fa fa-balance-scale ad_f gre";
                                    // document.getElementById("ChkSale" + x).style.backgroundColor = "#00b147";
                                }
                                else {

                                    //  document.getElementById("ChkSale" + x).style.backgroundColor = "#337ab7";
                                    document.getElementById("ChkSale" + x).style.opacity = "0.5";
                                    // document.getElementById("ChkSale" + x).className = "gre";
                                }

                                if (response.d[4] == "") {

                                    if (response.d[1] != "") {
                                        document.getElementById("AccntBalance_" + x).innerHTML = response.d[1];
                                        addCommaLedger("AccntBalance_" + x);
                                        document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("AccntBalance_" + x).innerHTML + " " + response.d[2] + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;;
                                        document.getElementById("lblCurrency").innerHTML = document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;

                                    }
                                }
                                else if (response.d[4] != "" && response.d[4] == "1") {
                                    document.getElementById("btnImportSales").disabled = true;
                                }
                        },
                        failure: function (response) {

                        }
                    });
                }
                else {
                    //  document.getElementById("TxtAmount_" + varRowidx).value = "";
                    document.getElementById("ddlLedId" + x).value = 0;

                    $('#TableQstn_' + x + ' td:first-child').each(function () {
                        var varId = $(this).text();

                        var TableRowCount1 = document.getElementById("TableQstn_" + x).rows.length;

                        if (TableRowCount1 != 0 && TableRowCount1 != 1) {
                            var idlast1 = $noCon('#TableQstn_' + x + ' tr:last').attr('id');

                            if (idlast1 != "") {
                                var res1 = idlast1.split("_");
                                document.getElementById("tdInxQstn" + res1[1]).value = "";
                                document.getElementById("btnCostCenter_" + res1[1]).style.opacity = "1";
                                document.getElementById("btnCostCenter_" + res1[1]).disabled = false;

                                if (res1 != varId) {
                                    jQuery('#SubQstnRowId_' + res1[1]).remove();

                                }

                            }
                        }
                        document.getElementById("TxtAmount_" + varRowidx).value = "";
                        document.getElementById("TxtRecptCosCtr_" + varId).style.display = "none";
                        document.getElementById("divCostCenter" + varId).style.display = "block";
                        document.getElementById("tdInxQstn" + varId).value = "";
                        document.getElementById("btnCostCenter_" + varId).style.opacity = "1";
                        document.getElementById("btnCostCenter_" + varId).disabled = false;

                        document.getElementById("TxtActCstctrAmount_" + varId).value = "";
                        document.getElementById("TxtCstctrAmount_" + varId).value = "";
                        $("div#divCostCenter" + varId + " input.ui-autocomplete-input").val("--SELECT--");
                        $("#ddlRecptCosCtr_" + varId).val("--SELECT--");
                        CheckSumOfLedger("TxtAmount_" + varRowidx, varRowidx);


                        if (response.d[3] != "") {
                            if (response.d[3] == "0" || response.d[3] == "1") {
                                document.getElementById('ChkCostCenter' + x).style.pointerEvents = 'none';
                                document.getElementById('ChkCostCenter' + x).style.opacity = "0.5";
                            }
                            else {
                                document.getElementById('ChkCostCenter' + x).style.pointerEvents = 'auto';
                                document.getElementById('ChkCostCenter' + x).style.opacity = "1";
                            }
                        }

                    });
                }

            }


            return false;
        }


        function CheckSumOfLedger(textboxid, x) {
            var ret = true;
            AmountChecking(textboxid);
            var CstTotal = 0;
            $('#TableQstn_' + x + ' td:first-child').each(function () {
                var varId = $(this).text();
                if (document.getElementById("TxtCstctrAmount_" + varId).value != "")

                    var cstamt = 0;
                cstamt = document.getElementById("TxtCstctrAmount_" + varId).value;
                if (cstamt == "") {
                    cstamt = 0;
                }
                else {
                    cstamt = cstamt.replace(/\,/g, '');
                }
                CstTotal = parseFloat(CstTotal) + parseFloat(cstamt);

            });
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

            var LedgerTotal = 0;
            var addRowtable1 = document.getElementById("tableGrp");

            for (var i = 1; i < addRowtable1.rows.length; i++) {
                var row = addRowtable1.rows[i];
                var x = (addRowtable1.rows[i].cells[0].innerHTML);
                if (document.getElementById("TxtAmount_" + x).value != "") {
                    var AddButton = $noconfli("#TxtAmount_" + i);
                    if (AddButton.length) {
                        var amtwitoutDecimal = document.getElementById("TxtAmount_" + x).value;
                        var amtwitoutDecimal11 = document.getElementById("TxtAmount_" + i).value;
                        amtwitoutDecimal = amtwitoutDecimal.replace(/\,/g, '');
                        amtwitoutDecimal = parseFloat(amtwitoutDecimal);

                        amtwitoutDecimal11 = amtwitoutDecimal11.replace(/\,/g, '');
                        amtwitoutDecimal11 = parseFloat(amtwitoutDecimal11);

                        LedgerTotal = parseFloat(LedgerTotal) + amtwitoutDecimal11;
                        document.getElementById("TxtAmount_" + x).value = amtwitoutDecimal.toFixed(FloatingValue);
                        addCommas("TxtAmount_" + x);
                    }
                }

                var CstCntrId = "";
                var SalesId = "";
                var CostCntrAmt = "";
                var PrchsAmt = "";
                var LdAmt = document.getElementById("TxtAmount_" + x).value;
                if (LdAmt == "") {
                    LdAmt = "0";
                }
                LdAmt = LdAmt.replace(/\,/g, '');

                var PrchaseTTl = "0";
                if (document.getElementById("tdSalesDtls" + x).value != null && document.getElementById("tdSalesDtls" + x).value != "" && document.getElementById("tdSalesDtls" + x).value != "null") {

                    var PurchaseInfo = document.getElementById("tdSalesDtls" + x).value;
                    if (PurchaseInfo != "") {
                      
                        var splitrow = PurchaseInfo.split("$");
                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var splitEach = splitrow[Cst].split("%");
                            if (splitEach[0] != "" && splitEach[1] != "") {
                                if (SalesId == "") {
                                    SalesId = splitEach[0];
                                    splitEach[1] = splitEach[1].replace(/\,/g, '');
                                    PrchsAmt = splitEach[1];
                                }
                                else {
                                    SalesId = SalesId + ',' + splitEach[0];
                                    splitEach[1] = splitEach[1].replace(/\,/g, '');
                                    PrchsAmt = PrchsAmt + ',' + splitEach[1];
                                }
                                PrchaseTTl = parseFloat(PrchaseTTl) + parseFloat(splitEach[1]);
                            }
                        }
                        document.getElementById("TxtAmount_" + x).style.borderColor = "";
                        if (parseFloat(PrchaseTTl) > parseFloat(LdAmt)) {
                            document.getElementById("TxtAmount_" + x).style.borderColor = "red";


                            $noCon("#divWarning").html("Ledger amount should be greater than or equal to sales amount. ");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                           
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
                    }
                }


                var OB = 0;
                var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                if (document.getElementById("tdLedgrPaid" + x).value != null && document.getElementById("tdLedgrPaid" + x).value != "") {
                    var OB = document.getElementById("tdLedgrPaid" + x).value;
                    var OpeningBal = OB.split('#');
                    var paid = OpeningBal[0];//paid
                    if (paid != "") {
                        PrchaseTTl = parseFloat(PrchaseTTl) + parseFloat(paid);
                    }
                }

                if (document.getElementById("tdCostCenterDtls" + x).value != null && document.getElementById("tdCostCenterDtls" + x).value != "" && document.getElementById("tdCostCenterDtls" + x).value != "null") {
                    var CostCenterInfo = document.getElementById("tdCostCenterDtls" + x).value;
                    var CstnrTTl = "0";
                    if (CostCenterInfo != "" && CostCenterInfo != "null" && CostCenterInfo != null) {
                        var splitrow = CostCenterInfo.split("$");
                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var splitEach = splitrow[Cst].split("%");
                            if (splitEach[0] != "" && splitEach[1] != "") {
                                if (CstCntrId == "") {
                                    CstCntrId = splitEach[0];
                                    splitEach[1] = splitEach[1].replace(/\,/g, '');
                                    CostCntrAmt = splitEach[1];
                                }
                                else {
                                    CstCntrId = CstCntrId + ',' + splitEach[0];
                                    splitEach[1] = splitEach[1].replace(/\,/g, '');
                                    CostCntrAmt = CostCntrAmt + ',' + splitEach[1];
                                }
                                CstnrTTl = parseFloat(CstnrTTl) + parseFloat(splitEach[1]);
                            }
                        }

                        document.getElementById("TxtAmount_" + x).style.borderColor = "";
                      
                        if (parseFloat(CstnrTTl) != parseFloat(LdAmt)) {
                            document.getElementById("TxtAmount_" + x).style.borderColor = "red";


                            $noCon("#divWarning").html("Ledger amount should be equal to cost centre amount. ");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                           
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
                    }
               }
            }

            if (CstTotal != 0) {
                if (LedgerTotal != CstTotal) {
                }
            }
            var LedgerTtl = 0;
            var addRowtable = document.getElementById("tableGrp");
            var ExchngRt = "";
            var exeFlg = 0;
            if (document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value != document.getElementById("<%=ddlCurrency.ClientID%>").value) {
                ExchngRt = document.getElementById("cphMain_txtExchangeRate").value;
                ExchngRt = ExchngRt.replace(/\,/g, '');
                exeFlg = 1;
            }
            for (var i = 1; i < addRowtable.rows.length; i++) {
                var row = addRowtable.rows[i];
                var x = (addRowtable.rows[i].cells[0].innerHTML);
                if (document.getElementById("TxtAmount_" + x).value != "") {
                    var ldgramt = document.getElementById("TxtAmount_" + x).value;
                    if (ldgramt == "") {
                        ldgramt = 0;

                    }
                    else {
                        ldgramt = ldgramt.replace(/\,/g, '');
                    }
                    LedgerTtl = parseFloat(LedgerTtl) + +parseFloat(ldgramt);

                    if (exeFlg == 1) {
                        var forexTtl = parseFloat(LedgerTtl) * parseFloat(ExchngRt);
                    }

                    if (FloatingValue != "") {
                        ldgramt = parseFloat(ldgramt);
                        ldgramt = ldgramt.toFixed(FloatingValue);
                    }
                    //  alert(ldgramt);
                    document.getElementById("TxtAmount_" + x).value = ldgramt;
                    addCommas("TxtAmount_" + x);
                }
            }

            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            if (FloatingValue != "") {
                LedgerTtl = LedgerTtl.toFixed(FloatingValue);
            }

            //    document.getElementById("cphMain_txtGrantTotal").value = LedgerTtl;
            //   addCommas("cphMain_txtGrantTotal");


            document.getElementById("<%=HiddenTotalAmount.ClientID%>").value = LedgerTtl;
            document.getElementById("<%=txtTotalAmt.ClientID%>").value = LedgerTtl;

            document.getElementById("<%=txtForexAmt.ClientID%>").value = forexTtl;
            addCommas("cphMain_txtTotalAmt");
            addCommas("cphMain_txtForexAmt");
            return ret;
        }

        function CheckSumOfCstCntr(textboxid, x, y) {
            if (document.getElementById(textboxid).value != "" && document.getElementById(textboxid).value != "0") {
            var CstTotal = 0;
            var LedgerTotal = 0;
            AmountChecking("TxtCstctrAmount_" + x + y);
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            $('#TableQstn_' + x + ' td:first-child').each(function () {
                var varId = $(this).text();

                if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {

                    if (document.getElementById("TxtRecptCosCtr_" + varId).value != "") {
                        var actAmt = document.getElementById("TxtActCstctrAmount_" + varId).value;
                        var ObjVal = document.getElementById("TxtCstctrAmount_" + varId).value;

                        if (document.getElementById("TxtActCstctrAmount_" + varId).value != "") {
                            ObjVal = ObjVal.replace(/\,/g, '');
                            if (parseFloat(ObjVal) > parseFloat(actAmt)) {

                                $noCon("#divWarning").html("Paid amount can not exceed actual amount.");
                                document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "red";
                                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                                });
                               
                                $noCon(window).scrollTop(0);
                                return false;


                            }
                        }
                    }

                }
                var cstamt = 0;
                cstamt = document.getElementById("TxtCstctrAmount_" + varId).value;
                if (cstamt == "") {

                }
                else {
                    cstamt = cstamt.replace(/\,/g, '');
                }

                if (FloatingValue != "" && cstamt != "") {
                    cstamt = parseFloat(cstamt);
                    cstamt = cstamt.toFixed(FloatingValue);

                }
                if (cstamt != "") {
                    document.getElementById("TxtCstctrAmount_" + varId).value = cstamt;
                    CstTotal = parseFloat(CstTotal) + parseFloat(cstamt);
                }
                addCommas("TxtCstctrAmount_" + varId);
                document.getElementById("TxtAmount_" + x).value = CstTotal;
            });
          
            $('#TableAddQstnCostCenter' + x + ' td:first-child').each(function () {

                var varId = $(this).text();
                addCommas("TxtCstctrAmount_" + varId);

            });
            var LedgerTtl = 0;
            var addRowtable = document.getElementById("tableGrp");

            for (var i = 1; i < addRowtable.rows.length; i++) {
                var row = addRowtable.rows[i];
                var x = (addRowtable.rows[i].cells[0].innerHTML);
                if (document.getElementById("TxtAmount_" + x).value != "") {
                    var ldgramt = document.getElementById("TxtAmount_" + x).value;
                    ldgramt = ldgramt.replace(/\,/g, '');
                    LedgerTtl = parseFloat(LedgerTtl) + +parseFloat(ldgramt);
                    if (FloatingValue != "") {
                        ldgramt = parseFloat(ldgramt);
                        ldgramt = ldgramt.toFixed(FloatingValue);
                    }
                    document.getElementById("TxtAmount_" + x).value = ldgramt;
                    addCommas("TxtAmount_" + x);


                }
            }


            var ExchngRt = "";
            var exeFlg = 0;
            var forexLdeTtl = ldgramt.replace(/\,/g, '');
            if (document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value != document.getElementById("<%=ddlCurrency.ClientID%>").value) {
                ExchngRt = document.getElementById("cphMain_txtExchangeRate").value;
                if (ExchngRt != "") {
                    ExchngRt = ExchngRt.replace(/\,/g, '');
                    exeFlg = 1;
                    document.getElementById("cphMain_txtForexAmt").value = parseFloat(forexLdeTtl) * parseFloat(ExchngRt);
                    addCommas("cphMain_txtForexAmt");
                }
                else {

                }
            }
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            if (FloatingValue != "") {
                LedgerTtl = LedgerTtl.toFixed(FloatingValue);
            }
            document.getElementById("<%=HiddenTotalAmount.ClientID%>").value = LedgerTtl;



            document.getElementById("cphMain_txtTotalAmt").value = LedgerTtl;
            addCommas("cphMain_txtTotalAmt");

            }
            else {
                document.getElementById(textboxid).value = "";
            }
            return true;
        }

        function CheckAndHighlightLedCostCenter(x) {
            var ret = true;
            var CstTotal = 0;
            var varId = "";
            var varfocus = "";
            document.getElementById("TxtAmount_" + x).style.borderColor = "";
            var FloatingValueMoney = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;


                $('#TableQstn_' + x + ' td:first-child').each(function () {
                    varId = $(this).text();

                    document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";




                    if (document.getElementById("ddlRecptCosCtr_" + varId).style.display != "none") {
                        $("#divCostCenter" + varId + "> input").css("borderColor", "");
                        //document.getElementById("ddlRecptCosCtr_" + varId).style.borderColor = "";

                        if (document.getElementById("ddlRecptCosCtr_" + varId).value == 0 && document.getElementById("TxtCstctrAmount_" + varId).value == "") {

                        }
                        else {

                            if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                                var varsctrAmt = document.getElementById("TxtCstctrAmount_" + varId).value;
                                varsctrAmt = varsctrAmt.replace(/\,/g, '');
                                CstTotal = parseFloat(CstTotal) + parseFloat(varsctrAmt);
                                CstTotal = parseFloat(CstTotal).toFixed(FloatingValueMoney);
                                // CstTotal = CstTotal.toFixed(FloatingValueMoney);
                            }





                            if (document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                                document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                                ret = false;
                                if (varfocus == "") {
                                    varfocus = varId;

                                }
                            }
                            if (document.getElementById("ddlRecptCosCtr_" + varId).value == 0) {

                                $("#divCostCenter" + varId + "> input").css("borderColor", "red");
                                $("#divCostCenter" + varId + "> input").focus();
                                $("#divCostCenter" + varId + "> input").select();
                                //  document.getElementById("ddlRecptCosCtr_" + varId).style.borderColor = "Red";
                                ret = false;
                                if (varfocus == "") {
                                    varfocus = varId;

                                }
                            }




                        }
                    }
                    else {
                        if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                            var varsctrAmt = document.getElementById("TxtCstctrAmount_" + varId).value;
                            varsctrAmt = varsctrAmt.replace(/\,/g, '');
                            CstTotal = parseFloat(CstTotal) + parseFloat(varsctrAmt);
                            CstTotal = parseFloat(CstTotal).toFixed(FloatingValueMoney);
                            // CstTotal = CstTotal.toFixed(FloatingValueMoney);
                        }
                    }

                });
                var LedgerTotal = 0;
                var ldgerAmt = document.getElementById("TxtAmount_" + x).value;
                ldgerAmt = ldgerAmt.replace(/\,/g, '');
                if (document.getElementById("TxtAmount_" + x).value != "" && ldgerAmt > 0) {
                    LedgerTotal = document.getElementById("TxtAmount_" + x).value;
                    LedgerTotal = LedgerTotal.replace(/\,/g, '');
                    LedgerTotal = parseFloat(LedgerTotal).toFixed(FloatingValueMoney);
                    //   LedgerTotal = LedgerTotal.toFixed(FloatingValueMoney);
                }
                else {
                    //  alert();
                    ret = false;
                    document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                    if (varfocus == "") {

                        document.getElementById("TxtAmount_" + x).focus();
                    }
                }
                if (varfocus != "") {
                    if (document.getElementById("TxtCstctrAmount_" + varfocus).value == "") {
                        document.getElementById("TxtCstctrAmount_" + varfocus).focus();
                    }
                    if (document.getElementById("ddlRecptCosCtr_" + varfocus).style.display != "none") {
                        if (document.getElementById("ddlRecptCosCtr_" + varfocus).value == 0) {
                            document.getElementById("ddlRecptCosCtr_" + varfocus).focus();
                        }
                    }

                }
                if (CstTotal != 0) {
                    //   alert(LedgerTotal); alert(CstTotal);
                    if (LedgerTotal != CstTotal) {
                        $noCon("#divWarning").html("Ledger and cost centre amount should be equal.");
                        $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                        });
                       
                        $noCon(window).scrollTop(0);
                        document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                        ret = false;


                        //  alert("Ledger amount and cost center amount should be equal");
                        // document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                        //   ret = false;
                    }
                }

                if (document.getElementById("ddlRecptLedger" + x).value == 0) {
                    $("#divLedger" + x + "> input").css("borderColor", "Red");
                    $("#divLedger" + x + "> input").focus();
                    $("#divLedger" + x + "> input").select();
                    // document.getElementById("ddlRecptLedger" + x).style.borderColor = "Red";
                    //document.getElementById("ddlRecptLedger" + x).focus();
                    ret = false;
                }

                return ret;
            }

        function FuctionAddGroup(Ledx) {
           
                IncrmntConfrmCounter();
                var addRowtableGrp;
                var addRowResultGrp = true;
                $("#divLedger" + Ledx + "> input").css("borderColor", "");
                var check = document.getElementById("tdInxGrp" + Ledx).value;
                if (check == "") {
                    addRowtableGrp = document.getElementById("TableQstn_" + Ledx);
                    if (CheckAndHighlightLedCostCenter(Ledx) == false) {
                        addRowResultGrp = false;
                    }
                    if (LedgerDuplication(Ledx) == false) {
                        addRowResultGrp = false;

                    }
                    //  }
                    var groupname = document.getElementById("TxtAmount_" + Ledx).value;
                    //   document.getElementById("TxtAmount_" + Ledx).style.borderColor = "";
                    if (groupname == "") {
                        // document.getElementById("inpGrpName_" + Grpx).style.borderColor = "";
                        //document.getElementById("TxtAmount_" + Ledx).style.borderColor = "Red";
                    }
                    var ldgrSts = CheckSumOfLedger("TxtAmount_" + Ledx, +Ledx);
                    if (addRowResultGrp == false) {

                        return false;
                    }
                    else if (ldgrSts == false) {
                        return false;
                    }

                    else {

                        //  alert();
                        document.getElementById("tdInxGrp" + Ledx).value = Ledx;
                        document.getElementById("journalADD" + Ledx).style.opacity = "0.3";


                        AddNewGroup();
                        // document.getElementById("inpGrpName_" + currntx).focus();
                        return false;
                    }
                }
                //}
                //else {
                //    document.getElementById("ddlRecptLedger" + Ledx).style.borderColor = "Red";
                //}

                // AddNewGroup();
                return false;

            }

            function CheckAndHighlightCostCenter(x) {
                var ret = true;
                var CstTotal = 0;
                var varId = "";
                var varfocus = "";
                $('#TableAddQstnCostCenter' + x + ' td:first-child').each(function () {
                    varId = $(this).text();
                    document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
                    $("#divCostCenter" + varId + "> input").css("borderColor", "");
                    $("#divCostGrp1" + varId + "> input").css("borderColor", "");
                    $("#divCostGrp2" + varId + "> input").css("borderColor", "");




                    $("#divLedger" + x + "> input").css("borderColor", "");
                    if (document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                        document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                        document.getElementById("TxtCstctrAmount_" + varId).focus();
                        ret = false;
                    }

                    if (document.getElementById("divCostCenter" + varId).style.display != "none") {
                        if (document.getElementById("ddlRecptCosCtr_" + varId).value == 0) {
                            $("#divCostCenter" + varId + "> input").css("borderColor", "Red");
                            $("#divCostCenter" + varId + "> input").focus();
                            $("#divCostCenter" + varId + "> input").select();
                            ret = false;
                        }
                    }
                    if (document.getElementById("ddlRecptLedger" + x).value == 0) {
                        $("#divLedger" + x + "> input").css("borderColor", "red");
                        $("#divLedger" + x + "> input").focus();
                        $("#divLedger" + x + "> input").select();
                        ret = false;
                    }
                });
                return ret;

            }


            function CheckaddMoreRowsQstn(x, y, xy) {
               
                IncrmntConfrmCounter();
                var addRowtable;
                var addRowResult = true;
                var check = document.getElementById("tdInxQstn" + x + '' + y).value;

                if (check == "") {
                    if (CCDuplication(x, xy) == false) {
                        addRowResult = false;
                    }

                  
                    if (addRowResult == true) {
                       
                        addRowtable = document.getElementById("TableQstn_" + x);
                        if (CheckAndHighlightCostCenter(x) == false) {
                            addRowResult = false;
                        }

                    }


                        if (addRowResult == false) {
                            return false;
                        }


                   else
                     {
                        document.getElementById("tdInxQstn" + x + '' + y).value = x + '' + y;
                        document.getElementById("btnCostCenter_" + x + '' + y).style.opacity = "0.3";
                        FunctionQustn(x, y, null, null, null);
                        return false;
                    }
                }


                return false;

            }
            function GetTotal(x, y) {
                var total = 0;
                for (var i = 1; i <= y; i++) {
                    total = +total + +document.getElementById("TxtCstctrAmount_" + x + '' + i).value;

                }

                //alert(total);
                document.getElementById("<%=txtTotalAmt.ClientID%>").value = total;
            }

            function FillddlRcptLedger(rowCount, LDGR_ID) {
                var ddlTestDropDownListXML = "";
                // if (mode == "GATEPASS") {
                ddlTestDropDownListXML = $noCon("#ddlRecptLedger" + rowCount);
                // }

                var intOrgID = '<%= Session["ORGID"] %>';
                var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
                // Provide Some Table name to pass to the WebMethod as a paramter.
                var tableName = "dtTableLedger";


                if (document.getElementById("<%=hiddenLedgerddl.ClientID%>").value != 0) {
                    ddlLed = document.getElementById("<%=hiddenLedgerddl.ClientID%>").value;
                    var OptionStart = $noCon("<option>--SELECT--</option>");
                    OptionStart.attr("value", 0);
                    ddlTestDropDownListXML.append(OptionStart);
                    // Now find the Table from response and loop through each item (row).
                    $noCon(ddlLed).find(tableName).each(function () {
                        // Get the OptionValue and OptionText Column values.
                        var OptionValue = $noCon(this).find('LDGR_ID').text();
                        var OptionText = $noCon(this).find('LDGR_NAME').text();
                        // Create an Option for DropDownList.
                        var option = $noCon("<option>" + OptionText + "</option>");
                        option.attr("value", OptionValue);

                        ddlTestDropDownListXML.append(option);
                    });
                    //Remove Ledger
                    var addRowtable = "";
                    addRowtable = document.getElementById("tableGrp");
                    for (var i = 1; i < addRowtable.rows.length; i++) {
                        var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                        var xLoopLdgrId = "";
                        if (document.getElementById("<%=HiddenLedgrDupSts.ClientID%>").value != "1") {
                            if ($("#ddlRecptLedger" + xLoop).val() != 0) {
                                xLoopLdgrId = $("#ddlRecptLedger" + xLoop).val();
                                $noCon("#ddlRecptLedger" + rowCount + " option[value='" + xLoopLdgrId + "']").remove();
                            }
                        }
                    }
                }
                else {
                    var OptionStart = $noCon("<option>--SELECT--</option>");
                    OptionStart.attr("value", 0);
                    ddlTestDropDownListXML.append(OptionStart);
                }

                //alert(LDGR_ID);

                if (LDGR_ID != "") {
                    var arrayldgr_VALUES = JSON.parse("[" + LDGR_ID + "]");
                    $noCon("#ddlRecptLedger" + rowCount).val(arrayldgr_VALUES);
                }


            }
            function FillddlAcntGrp1(rowCountX, rowCountY, COSTCNTR_ID) {

                var ddlTestDropDownListXML1 = "";
                // if (mode == "GATEPASS") {
                ddlTestDropDownListXML1 = $noCon("#ddlRecptCosGrp1_" + rowCountX + "" + rowCountY);
                // }

                var intOrgID = '<%= Session["ORGID"] %>';
            var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableCostCenter";

            if (document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value != "0") {
                ddlLed = document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML1.append(OptionStart);
                // Now find the Table from response and loop through each item (row).
                $noCon(ddlLed).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('COSTGRP_ID').text();
                    var OptionText = $noCon(this).find('COSTGRP_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML1.append(option);
                });
            }
            else {
                //alert();
                var OptionStart = $noCon("<option>--SELECT--</option>");
                OptionStart.attr("value", 0);
                // alert(ddlTestDropDownListXML1);
                ddlTestDropDownListXML1.append(OptionStart);
                //alert();
            }
            if (COSTCNTR_ID != "" && COSTCNTR_ID != null && COSTCNTR_ID != 0 && COSTCNTR_ID != "null") {
                var arraycostcntr_VALUES = JSON.parse("[" + COSTCNTR_ID + "]");
                $noCon("#ddlRecptCosGrp1_" + rowCountX + "" + rowCountY).val(arraycostcntr_VALUES);
            }
        }
        function FillddlAcntGrp2(rowCountX, rowCountY, COSTCNTR_ID) {

            var ddlTestDropDownListXML1 = "";
            // if (mode == "GATEPASS") {
            ddlTestDropDownListXML1 = $noCon("#ddlRecptCosGrp2_" + rowCountX + "" + rowCountY);
            // }

            var intOrgID = '<%= Session["ORGID"] %>';
            var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableCostCenter";

            if (document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value != "0") {
                        ddlLed = document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value;
                        var OptionStart = $noCon("<option>--SELECT--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML1.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $noCon(ddlLed).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('COSTGRP_ID').text();
                            var OptionText = $noCon(this).find('COSTGRP_NAME').text();
                            // Create an Option for DropDownList.
                            var option = $noCon("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);

                            ddlTestDropDownListXML1.append(option);
                        });
                    }
                    else {
                        //alert();
                        var OptionStart = $noCon("<option>--SELECT--</option>");
                        OptionStart.attr("value", 0);
                        // alert(ddlTestDropDownListXML1);
                        ddlTestDropDownListXML1.append(OptionStart);
                        //alert();
                    }
                    if (COSTCNTR_ID != "" && COSTCNTR_ID != null && COSTCNTR_ID != 0 && COSTCNTR_ID != "null") {
                        var arraycostcntr_VALUES = JSON.parse("[" + COSTCNTR_ID + "]");
                        $noCon("#ddlRecptCosGrp2_" + rowCountX + "" + rowCountY).val(arraycostcntr_VALUES);
                    }
                }


                function FillddlCostCenter(rowCountX, rowCountY, COSTCNTR_ID) {

                    var ddlTestDropDownListXML1 = "";
                    // if (mode == "GATEPASS") {
                    ddlTestDropDownListXML1 = $noCon("#ddlRecptCosCtr_" + rowCountX + "" + rowCountY);
                    // }

                    var intOrgID = '<%= Session["ORGID"] %>';
                var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableCostCenter";

            if (document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value != "0") {
                    ddlLed = document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value;
                    var OptionStart = $noCon("<option>--SELECT--</option>");
                    OptionStart.attr("value", 0);
                    ddlTestDropDownListXML1.append(OptionStart);
                    // Now find the Table from response and loop through each item (row).
                    $noCon(ddlLed).find(tableName).each(function () {
                        // Get the OptionValue and OptionText Column values.
                        var OptionValue = $noCon(this).find('COSTCNTR_ID').text();
                        var OptionText = $noCon(this).find('COSTCNTR_NAME').text();
                        // Create an Option for DropDownList.
                        var option = $noCon("<option>" + OptionText + "</option>");
                        option.attr("value", OptionValue);

                        ddlTestDropDownListXML1.append(option);
                    });
                }
                else {
                    //alert();
                    var OptionStart = $noCon("<option>--SELECT--</option>");
                    OptionStart.attr("value", 0);
                    // alert(ddlTestDropDownListXML1);
                    ddlTestDropDownListXML1.append(OptionStart);
                    //alert();
                }
                if (COSTCNTR_ID != "" && COSTCNTR_ID != null && COSTCNTR_ID != 0 && COSTCNTR_ID != "null") {
                    var arraycostcntr_VALUES = JSON.parse("[" + COSTCNTR_ID + "]");
                    $noCon("#ddlRecptCosCtr_" + rowCountX + "" + rowCountY).val(arraycostcntr_VALUES);
                }
            }

        function AmountCalculation(SalesId) {

            var ret = true;
            AmountChecking("txtPurchaseAmt" + SalesId);
            var tdAmnt = document.getElementById("tdAmnt" + SalesId).innerHTML;
            var rcptAmt1 = document.getElementById("txtPurchaseAmt" + SalesId).value;
            if (rcptAmt1 == "") {
                rcptAmt1 = "0";
            }
            rcptAmt1 = rcptAmt1.replace(/\,/g, '');
            var SalesAmt1 = parseFloat(rcptAmt1);
            tdAmnt = tdAmnt.replace(/\,/g, '');
            document.getElementById("txtPurchaseAmt" + SalesId).style.borderColor = "";


            var rcptAmt2 = document.getElementById("txtCreNoteStlmntAmmnt" + SalesId).value;
            if (rcptAmt2 == "") {
                rcptAmt2 = "0";
            }
            rcptAmt2 = rcptAmt2.replace(/\,/g, '');
            var SalesAmt2 = parseFloat(rcptAmt2);



            if (parseFloat(SalesAmt1) > parseFloat(tdAmnt)) {
                clearData();
                document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the sales amount";
                $("div.war").fadeIn(200).delay(500).fadeOut(400);
                document.getElementById("txtPurchaseAmt" + SalesId).style.borderColor = "Red";
                document.getElementById("txtPurchaseAmt" + SalesId).focus();
                document.getElementById("txtPurchaseAmt" + SalesId).value = "";
                ret = false;
            }
            else if ((parseFloat(SalesAmt2) + parseFloat(SalesAmt1)) > parseFloat(tdAmnt)) {
                clearData();
                document.getElementById("lblErrMsgCancelReason").innerHTML = "Sum of settlement amount and creditnote settlement amount should be less than the sale amount";
                $("div.war").fadeIn(200).delay(500).fadeOut(400);
                document.getElementById("txtPurchaseAmt" + SalesId).style.borderColor = "Red";
                document.getElementById("txtPurchaseAmt" + SalesId).focus();
                document.getElementById("txtPurchaseAmt" + SalesId).value = "";
                ret = false;
            }


            var purchaseAmt = 0;
            var ledgerAmt = 0;
            var addRowtable = document.getElementById("TableAddQstn");
            var j = 1;
            if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                  j++;
              }
            for (var i = j; i < addRowtable.rows.length; i++) {//2nd row onwards
                var P_Id = (addRowtable.rows[i].cells[0].innerHTML);

                var SalesAmt = 0;
                var rcptAmt = document.getElementById("txtPurchaseAmt" + P_Id).value;
                if (rcptAmt == "") {
                    rcptAmt = "0";
                }
                rcptAmt = rcptAmt.replace(/\,/g, '');
                SalesAmt = parseFloat(rcptAmt);



                var SalesAmt2 = 0;
                var rcptAmt2 = document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).value;
                if (rcptAmt2 == "") {
                    rcptAmt2 = "0";
                }
                rcptAmt2 = rcptAmt2.replace(/\,/g, '');
                SalesAmt2 = parseFloat(rcptAmt2);



                purchaseAmt = parseFloat(purchaseAmt) + parseFloat(rcptAmt) + parseFloat(rcptAmt2);
                var ledgerAmtwithoutarr = document.getElementById("LedgerAmtInModalPurchse").innerText;

                var TxtTotalarr = ledgerAmtwithoutarr.split(" ");
                if (TxtTotalarr[0] != "") {
                    ledgerAmt = TxtTotalarr[0];
                }
                ledgerAmt = ledgerAmt.replace(/\,/g, '');
                var actLedgerAmt = document.getElementById("lblLdgrAmt").innerText;


                if (parseFloat(purchaseAmt) > parseFloat(ledgerAmt)) {
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    purchaseAmt = parseFloat(purchaseAmt);
                    if (FloatingValue != "") {
                        purchaseAmt = purchaseAmt.toFixed(FloatingValue);
                    }
                    addCommasSummry(purchaseAmt);
                }
                else if (parseFloat(purchaseAmt) <= parseFloat(ledgerAmt)) {
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    actLedgerAmt = parseFloat(actLedgerAmt);
                    if (FloatingValue != "") {
                        actLedgerAmt = actLedgerAmt.toFixed(FloatingValue);
                    }
                    addCommasSummry(actLedgerAmt);
                }

                //evm 0044
             

                if (parseFloat(purchaseAmt) > parseFloat(ledgerAmt)) {
                    clearData();
                    document.getElementById("lblErrMsgCancelReason").innerHTML = "Sales total amount should be less than the receipt amount";
                    $("div.war").fadeIn(200).delay(500).fadeOut(400);
                    if (document.getElementById("txtPurchaseAmt" + P_Id).value != "") {
                        document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "Red";
                        document.getElementById("txtPurchaseAmt" + P_Id).focus();
                        document.getElementById("txtPurchaseAmt" + P_Id).value = "";
                    }
                    ret = false;
                }

            }

            if (ret == true) {

                var purchAmt = document.getElementById("txtPurchaseAmt" + SalesId).value;
                purchAmt = purchAmt.replace(/\,/g, '');

                if (purchAmt == "") {
                    purchAmt = 0;
                }



                var purchAmt1 = document.getElementById("txtCreNoteStlmntAmmnt" + SalesId).value;
                purchAmt1 = purchAmt1.replace(/\,/g, '');

                if (purchAmt1 == "") {
                    purchAmt1 = 0;
                }


                var saleamt = document.getElementById("tdAmnt" + SalesId).innerHTML;
                saleamt = saleamt.replace(/\,/g, '');
                var BlncAmt = parseFloat(saleamt) - (parseFloat(purchAmt)+parseFloat(purchAmt1));
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            if (FloatingValue != "") {
                BlncAmt = BlncAmt.toFixed(FloatingValue)
            }

            addCommasSummry(BlncAmt);

            document.getElementById("SlsBlnc" + SalesId).innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;

                //document.getElementById("creNoteBala" + SalesId).innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;

            }
            //  alert(purchaseAmt+"fgf");
            // alert(ledgerAmt);



            //  if (ret == true) {
            //   if (document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value != "") {
            //      document.getElementById("LedgerAmtInModalPurchse").innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
            //  }
            // }
            addCommas("txtPurchaseAmt" + SalesId);
            loadSettleAmount(SalesId);
            return ret;
        }

        //evm 0044
        function clearData() {
            document.getElementById("lblSetleAmt").innerHTML = " ";
            document.getElementById("lblBlncAmt").innerHTML = " ";
        }
        function clearLabelData() {

            document.getElementById("lblSetleAmt").innerHTML = "";
            document.getElementById("lblBlncAmt").innerHTML = "";
            document.getElementById("lblSetle").innerText = "";
            document.getElementById("lblCredit").innerText = "";

        }
        function setData(id, data) {
            document.getElementById(id).innerText = data;
        }
        function loadSettleAmount(x) {
            //alert(x);
            clearLabelData();
            if (x != -1) {
                P_Id = x;
                document.getElementById("lblOpBalance").innerText = "";
            }
            var salesAmt = 0;
            var opBalance = 0;
            var creditAmt = 0;
            var addRowtable = document.getElementById("TableAddQstn");
            if (typeof addRowtable !== 'undefined' && addRowtable !== null) {
                var j = 1;
                if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                    j++;
                }
                var elem = document.getElementById("txtCreNoteStlmntAmmnt" + P_Id);
                if (typeof elem !== 'undefined' && elem !== null) {
                    for (var i = j; i < addRowtable.rows.length; i++) {//2nd row onwards
                        var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
                        var rcptAmt2d = document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).value.replace(/\,/g, '');
                        if (rcptAmt2d == "") {
                            rcptAmt2d = "0";

                        }
                        creditAmt = parseFloat(creditAmt) + parseFloat(rcptAmt2d);

                    }

                }

                var elem = document.getElementById("txtPurchaseAmt" + P_Id);

                if (typeof elem !== 'undefined' && elem !== null) {

                    for (var i = j; i < addRowtable.rows.length; i++) {//2nd row onwards
                        var P_Id = (addRowtable.rows[i].cells[0].innerHTML);

                        var SalesAmtd = 0;
                        var rcptAmt = document.getElementById("txtPurchaseAmt" + P_Id).value.replace(/\,/g, '');
                        if (rcptAmt == "") {
                            rcptAmt = "0";
                        }
                        rcptAmt = rcptAmt.replace(/\,/g, '');
                        SalesAmtd = parseFloat(rcptAmt);
                        salesAmt = parseFloat(salesAmt) + parseFloat(rcptAmt);

                    }
                }
            }


            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            creditAmt = parseFloat(creditAmt);
            if (FloatingValue != "") {
                creditAmt = creditAmt.toFixed(FloatingValue);

            }

            document.getElementById("lblCredit").innerText = creditAmt.replace(/\,/g, '');

            salesAmt = parseFloat(salesAmt); c
            if (FloatingValue != "") {
                salesAmt = salesAmt.toFixed(FloatingValue);

            }
            document.getElementById("lblSetle").innerText = salesAmt.replace(/\,/g, '');
            var opBalance = document.getElementById("lblOpBalance").innerText.replace(/\,/g, '');
            //alert("op" + opBalance);
            var settleamt = document.getElementById("lblSetle").innerText.replace(/\,/g, '');
            //alert("setle" + settleamt);
            var crditAmt = document.getElementById("lblCredit").innerText.replace(/\,/g, '');
            //alert("credit" + crditAmt);
            var blnctamt = 0;
            var ldgramt = document.getElementById("lblLdgrAmt").innerText.split(" ");
            var ldgramt = ldgramt[0];
            totalamt = Number(opBalance) + Number(settleamt) + Number(crditAmt);
            blnctamt = Number(ldgramt) - Number(totalamt);
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            totalamt = parseFloat(totalamt);
            if (FloatingValue != "") {
                totalamt = totalamt.toFixed(FloatingValue);

            }
            blnctamt = parseFloat(blnctamt);
            if (FloatingValue != "") {
                blnctamt = blnctamt.toFixed(FloatingValue);

            }

            if (blnctamt < 0) {

                document.getElementById("lblSetleAmt").innerHTML = "";
                document.getElementById("lblBlncAmt").innerHTML = "";
            }
            else {
                totalamt = addCommasSummry(totalamt);
                document.getElementById("lblSetleAmt").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                //alert(blnctamt);
                blnctamt = addCommasSummry(blnctamt);
                document.getElementById("lblBlncAmt").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
            }

        }

        function ButtnFillClickSales(str) {

            var ret = true;
            var TotalAmnt = 0;
            var chk = 0;
            var TotalAmnt = 0;
            var TotalPurchaseAmnt = 0;
            var purchaseFlag = 0;
            var CheckCount = 0;
            var TxtTotal = 0;
            document.getElementById("TxtAmount_" + varRowidx).value;

            var ledgerAmtwithoutarr = 0;
            if (document.getElementById("LedgerAmtInModalPurchse").innerText != "") {
                ledgerAmtwithoutarr = document.getElementById("LedgerAmtInModalPurchse").innerText;
                var TxtTotalarr = ledgerAmtwithoutarr.split(" ");
                if (TxtTotalarr[0] != "") {
                    TxtTotal = TxtTotalarr[0];
                }
                TxtTotal = TxtTotal.replace(/\,/g, '');
            }

            var j = 1;
            if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                j++;
            }

            var addRowtable = document.getElementById("TableAddQstn");
            var j = 1;
            var Obamt = 0;
            if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                j++;
                if (addRowtable.rows.length == 2) {

                    //tableGrp
                    var LedgerId = document.getElementById("ddlRecptLedger" + varRowidx).value;

                    if (document.getElementById("tdOpenSts" + varRowidx).value == 1) {

                        var arry = document.getElementById("SpanOpeningBalance" + varRowidx).innerHTML.split(" ");

                        //evm-0020
                        document.getElementById("tdOpeningBalnc" + varRowidx).innerHTML = document.getElementById("tdDupOBAmnt" + varRowidx).innerHTML;
                        var OBPaid = DuplicateOBSettlementChange(varRowidx);
                        document.getElementById("tdOpeningBalnc" + varRowidx).innerHTML = parseFloat(document.getElementById("tdOpeningBalnc" + varRowidx).innerHTML) - parseFloat(OBPaid);
                        AmountCheckingLabel("tdOpeningBalnc" + varRowidx);

                        var OpeningBal = document.getElementById("tdOpeningBalnc" + varRowidx).innerHTML;
                        var txtob = 0;
                        if (document.getElementById("txtOpeningBalnc" + varRowidx).value != "") {
                            txtob = document.getElementById("txtOpeningBalnc" + varRowidx).value;
                        }
                        Obamt = txtob;
                        OpeningBal = parseFloat(OpeningBal) - parseFloat(txtob);
                        var amt = txtob + "#" + parseFloat(OpeningBal);
                        document.getElementById("tdLedgrPaid" + varRowidx).value = amt;
                    }
                }
            }

            for (var i = j; i < addRowtable.rows.length; i++) {
                var P_Id = (addRowtable.rows[i].cells[0].innerHTML);

                var tdLedgerRow = document.getElementById("tdLedgerRow" + P_Id).innerHTML;


                //evm-0020
                document.getElementById("tdAmnt" + P_Id).innerHTML = document.getElementById("tdDupAmnt" + P_Id).innerHTML;
                var MaxAmt = DuplicateSettlementChange(P_Id, tdLedgerRow);
                document.getElementById("tdAmnt" + P_Id).innerHTML = parseFloat(document.getElementById("tdAmnt" + P_Id).innerHTML) - parseFloat(MaxAmt);
                document.getElementById("tdBalnc" + P_Id).innerHTML = document.getElementById("tdAmnt" + P_Id).innerHTML;
                AmountCheckingLabel("tdBalnc" + P_Id);



                var tdAmnt = document.getElementById("tdAmnt" + P_Id).innerHTML;

                if (document.getElementById("tdOpenSts" + tdLedgerRow).value == 0) {
                    if (i == 1) {
                        document.getElementById("tdSalesDtls" + tdLedgerRow).value = "";
                    }
                }
                else {
                    if (i < 3) {
                        document.getElementById("tdSalesDtls" + tdLedgerRow).value = "";
                    }
                }
                if (document.getElementById("tdSettld" + P_Id).value == "0") {

                    var purchaseAmt = "";
                    document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "";
                    purchaseAmt = document.getElementById("txtPurchaseAmt" + P_Id).value;


                    var purchaseAmt2 = "";
                    purchaseAmt2 = document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).value;


                    if (purchaseAmt != "" || purchaseAmt2 != "") {
                        chk++;
                    }

                    var salCstId = document.getElementById('tdrcptSalId' + P_Id).innerHTML;

                    if (purchaseAmt != "") {
                        purchaseAmt = purchaseAmt.replace(/\,/g, '');
                        TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt) + parseFloat(purchaseAmt);
                        purchaseFlag++;
                    }
                    if (purchaseAmt2 != "") {
                        purchaseAmt2 = purchaseAmt2.replace(/\,/g, '');
                        TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt) + parseFloat(purchaseAmt2);
                        purchaseFlag++;
                    }

                    purchaseAmt = parseFloat(purchaseAmt)// + parseFloat(Obamt);
                    if (parseFloat(purchaseAmt) > parseFloat(tdAmnt)) {
                        document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the sales amount";
                        $("div.war").fadeIn(200).delay(500).fadeOut(400);
                        document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "red";
                        document.getElementById("txtPurchaseAmt" + P_Id).focus();

                        ret = false;
                    }
                    else if ((parseFloat(purchaseAmt) > parseFloat(TxtTotal)) || (parseFloat(TotalPurchaseAmnt) > parseFloat(TxtTotal))) {
                        document.getElementById("lblErrMsgCancelReason").innerHTML = "Sales total amount should be less than the receipt amount";
                        $("div.war").fadeIn(200).delay(500).fadeOut(400);
                        document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "red";
                        document.getElementById("txtPurchaseAmt" + P_Id).focus();
                        ret = false;
                    }


                    if (document.getElementById("cbx_sly" + P_Id).checked == true) {

                        if (document.getElementById("ddlCreditNote" + P_Id).value == "0") {
                            document.getElementById("lblErrMsgCancelReason").innerHTML = "Some of the information you entered is missing";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                            document.getElementById("ddlCreditNote" + P_Id).style.borderColor = "red";
                            document.getElementById("ddlCreditNote" + P_Id).focus();
                            ret = false;
                        }
                        if (document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).value.trim() == "") {
                            document.getElementById("lblErrMsgCancelReason").innerHTML = "Some of the information you entered is missing";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                            document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).style.borderColor = "red";
                            document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).focus();
                            ret = false;
                        }


                    }
                }

                if (ret == true) {
                    if (document.getElementById("tdSaleID" + P_Id).innerHTML != "") {
                        if (document.getElementById("tdSalesDtls" + tdLedgerRow).value == "") {
                            document.getElementById("tdSalesDtls" + tdLedgerRow).value = document.getElementById("tdSaleID" + P_Id).innerHTML + "%" + document.getElementById("txtPurchaseAmt" + P_Id).value + "%" + document.getElementById("tdsettlmntAmnt" + P_Id).innerHTML + "%" + salCstId + "%" + document.getElementById("ddlCreditNote" + P_Id).value + "%" + document.getElementById("tdCredNoteAmnt" + P_Id).innerHTML + "%" + document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).value;
                        }
                        else {
                            document.getElementById("tdSalesDtls" + tdLedgerRow).value = document.getElementById("tdSalesDtls" + tdLedgerRow).value + "$" + document.getElementById("tdSaleID" + P_Id).innerHTML + "%" + document.getElementById("txtPurchaseAmt" + P_Id).value + "%" + document.getElementById("tdsettlmntAmnt" + P_Id).innerHTML + "%" + salCstId + "%" + document.getElementById("ddlCreditNote" + P_Id).value + "%" + document.getElementById("tdCredNoteAmnt" + P_Id).innerHTML + "%" + document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).value;
                        }
                    }
                }

                var LedgerId = document.getElementById("ddlRecptLedger" + tdLedgerRow).value;

                if (document.getElementById("tdOpenSts" + tdLedgerRow).value == 1) {

                    if (document.getElementById("txtOpeningBalnc" + tdLedgerRow).value != "") {
                        var arry = document.getElementById("SpanOpeningBalance" + tdLedgerRow).innerHTML.split(" ");
                        //EVM-0027 Aug 26
                        var OpeningBalArry=    document.getElementById("tdOpeningBalnc" + tdLedgerRow).innerHTML.split(" ");
                        //var OpeningBal = document.getElementById("tdOpeningBalnc" + tdLedgerRow).innerHTML.split(" ");
                        var OpeningBal = OpeningBalArry[0];
                        //EVM-0027 Aug 26 END
                        var txtob = document.getElementById("txtOpeningBalnc" + tdLedgerRow).value;

                        OpeningBal = parseFloat(OpeningBal) - parseFloat(txtob); //EVM-0027 Aug 26
                        var amt = document.getElementById("txtOpeningBalnc" + tdLedgerRow).value + "#" + parseFloat(OpeningBal);

                        document.getElementById("tdLedgrPaid" + tdLedgerRow).value = amt;
                    }
                }

            }

            $noCon('btnImportSales').prop("data-dismiss", "modal");

            if (ret == true) {
                document.getElementById("BttnTemp").click();
            }
            var FloatingValueMoney = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

            if (str == "0") {

                var ledgerAmtwithoutarr = document.getElementById("LedgerAmtInModalPurchse").innerText;
                var ttlLdgrAmt = 0;
                var TxtTotalarr = ledgerAmtwithoutarr.split(" ");
                if (TxtTotalarr[0] != "") {
                    ttlLdgrAmt = TxtTotalarr[0];
                }
                ttlLdgrAmt = ttlLdgrAmt.replace(/\,/g, '');

                if (FloatingValueMoney != "") {
                    CheckSumOfLedger("TxtAmount_" + varRowidx, +varRowidx);
                }
                else {
                    document.getElementById("TxtAmount_" + varRowidx).value = ttlLdgrAmt;
                }
            }
        }
    </script>

    <script>
        function ValidateReceiptAccnt() {
            var ret = true;
            var DdlAccntName = document.getElementById("cphMain_ddlAccontLed").value;
            $("#divAccount > input").css("borderColor", "");


            var AccntDate = document.getElementById("cphMain_txtdate").value;
            document.getElementById("cphMain_txtdate").style.borderColor = "";

            var DdlAccnt = document.getElementById("cphMain_ddlCurrency").value;
            document.getElementById("cphMain_ddlCurrency").style.borderColor = "";

            var flag1 = 0;
            var flag2 = 0;
            var flag3 = 0;

            var Narrtn = document.getElementById("cphMain_txtDesc").value.trim();
            document.getElementById("cphMain_txtDesc").style.borderColor = "";

           
            if (changeBankAcNum() == false) {
                document.getElementById("cphMain_ddlChequeBank").style.borderColor = "red";
                document.getElementById("cphMain_ddlChequeBank").focus();

                document.getElementById("cphMain_txtChequeNo_Cheque").style.borderColor = "red";
                document.getElementById("cphMain_txtChequeNo_Cheque").focus();

                $noCon("#divWarning").html("Duplication is not allowed for cheque number!");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $noCon(window).scrollTop(0);
                ret = false;
            }
            //if (DdlAccnt == "--SELECT CURRENCY--") {
            //    document.getElementById("cphMain_ddlCurrency").style.borderColor = "Red";
            //    document.getElementById("cphMain_ddlCurrency").focus();
            //    flag3 = 1;
            //    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            //    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            //    });

            //    $noCon(window).scrollTop(0);

            //    ret = false;
            //    alert(DdlAccnt);
            //}

            if (AccntDate == "") {
                document.getElementById("cphMain_txtdate").style.borderColor = "Red";
                document.getElementById("cphMain_txtdate").focus();
                flag2 = 1
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon(window).scrollTop(0);
                ret = false;
               
            }
            if (DdlAccntName == "--SELECT--") {
                $("#divAccount > input").css("borderColor", "red");
                $("#divAccount > input").focus();
                $("#divAccount > input").select();

                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon(window).scrollTop(0);
                flag1 = 1
                ret = false;
            }

            var CurrentDateDate = document.getElementById("<%=txtdate.ClientID%>").value;
            var arrCurrentDate = CurrentDateDate.split("-");
            var curntDate = document.getElementById("<%=txtdate.ClientID%>").value;
            var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

            //  alert(dateCurrentDate+"text");
            var presenrdate = document.getElementById("<%=HiddenPresentDate.ClientID%>").value;
            var arrpresenrdate = presenrdate.split("-");
            var datepresenrdate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);

            //     alert(datepresenrdate + "current");
            if (datepresenrdate > dateCurrentDate) {

                document.getElementById("cphMain_txtdate").style.borderColor = "Red";
                document.getElementById("cphMain_txtdate").focus();
                flag2 = 1
                $noCon("#divWarning").html("Sorry, date can't be less than current date !");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon(window).scrollTop(0);

                ret = false;

            }

            var tabName = document.getElementById("<%=HiddenPrevTab.ClientID%>").value;

            document.getElementById("<%=txtChequeNo_Cheque.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtChequeIBAN.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDate_Cheque.ClientID%>").style.borderColor = "";

            document.getElementById("<%=ddlDDBank.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDDIBAN.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDate_DD.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDD_DD.ClientID%>").style.borderColor = "";


            document.getElementById("<%=ddlTransfrBank.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTranserIBAN.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDate_BankTransfer.ClientID%>").style.borderColor = "";


            if (tabName == "Cheque") {

                if (document.getElementById("<%=txtChequeNo_Cheque.ClientID%>").value == "") {
                    document.getElementById("<%=txtChequeNo_Cheque.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=txtChequeNo_Cheque.ClientID%>").focus();
                    ret = false;
                }
                //  if (document.getElementById("<%=txtChequeIBAN.ClientID%>").value.trim() == "") {
                //      document.getElementById("<%=txtChequeIBAN.ClientID%>").style.borderColor = "red";
                //     document.getElementById("<%=txtChequeIBAN.ClientID%>").focus();
                //     ret = false;
                // }
                if (document.getElementById("<%=txtDate_Cheque.ClientID%>").value.trim() == "") {
                    document.getElementById("<%=txtDate_Cheque.ClientID%>").style.borderColor = "red";
                    //  document.getElementById("<%=txtDate_Cheque.ClientID%>").focus();

                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon(window).scrollTop(0);
                    ret = false;
                }


            }
            else if (tabName == "DD") {
                <%--   if (document.getElementById("<%=ddlDDBank.ClientID%>").value == "--SELECT--") {
                    document.getElementById("<%=ddlDDBank.ClientID%>").style.borderColor = "red";
                      document.getElementById("<%=ddlDDBank.ClientID%>").focus();
                      ret = false;
                  }
                  if (document.getElementById("<%=txtDDIBAN.ClientID%>").value.trim() == "") {
                    document.getElementById("<%=txtDDIBAN.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=txtDDIBAN.ClientID%>").focus();
                    ret = false;
                }--%>
                if (document.getElementById("<%=txtDate_DD.ClientID%>").value.trim() == "") {
                    document.getElementById("<%=txtDate_DD.ClientID%>").style.borderColor = "red";
                    //   document.getElementById("<%=txtDate_DD.ClientID%>").focus();


                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon(window).scrollTop(0);

                    ret = false;
                }
                if (document.getElementById("<%=txtDD_DD.ClientID%>").value.trim() == "") {
                    document.getElementById("<%=txtDD_DD.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=txtDD_DD.ClientID%>").focus();


                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon(window).scrollTop(0);

                    ret = false;
                }

            }
            else if (tabName == "BankTransfer") {

                // if (document.getElementById("<%=ddlTransfrBank.ClientID%>").value == "--SELECT--") {
                //   document.getElementById("<%=ddlTransfrBank.ClientID%>").style.borderColor = "red";
                //     document.getElementById("<%=ddlTransfrBank.ClientID%>").focus();
                //     ret = false;
                // }
                // if (document.getElementById("<%=txtTranserIBAN.ClientID%>").value.trim() == "") {
                //   document.getElementById("<%=txtTranserIBAN.ClientID%>").style.borderColor = "red";
                //    document.getElementById("<%=txtTranserIBAN.ClientID%>").focus();
                //    ret = false;
                //}
                if (document.getElementById("<%=txtDate_BankTransfer.ClientID%>").value.trim() == "") {
                    document.getElementById("<%=txtDate_BankTransfer.ClientID%>").style.borderColor = "red";
                    //  document.getElementById("<%=txtDate_BankTransfer.ClientID%>").focus();

                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon(window).scrollTop(0);
                    ret = false;

                }
            }

            if (!(validateTable(ret))) {
                ret = false;
            }

            else {
                document.getElementById("cphMain_hiddenLedgerddl").value = "";
                document.getElementById("cphMain_hiddenCostCenterddl").value = "";
                document.getElementById("cphMain_HiddenCostGroup1ddl").value = "";
                document.getElementById("cphMain_HiddenCostGroup2ddl").value = "";

                for (var i = 1; i < addRowtable.rows.length; i++) {
                    var row = addRowtable.rows[i];
                    var x = (addRowtable.rows[i].cells[0].innerHTML);
                    document.getElementById("TxtAmount_" + x).disabled = false;
                }

            }

            if (flag1 == 1) {
                document.getElementById("cphMain_ddlAccontLed").focus();
            }
            else if (flag2 == 1) {
                document.getElementById("cphMain_txtdate").focus();
            }
            else if (flag3 == 1) {
                document.getElementById("cphMain_ddlCurrency").focus();
            }
          

            return ret;
        }

        function validateTable(retchk) {
            var Result = true;
            var varfocus = "";
            var varfocusLed = "";
            var varfocusCheck = "";
            var ret = true;
            var FloatingValueMoney = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            addRowtable = document.getElementById("tableGrp");
            for (var i = 1; i < addRowtable.rows.length; i++) {
                var row = addRowtable.rows[i];
                var x = (addRowtable.rows[i].cells[0].innerHTML);
                var ledgerRet = LedgerDuplication(x);
                if (ledgerRet == false) {
                    ret = false;
                }
                var CstTotal = 0;
                var varId = "";
                var varfocus = "";
                document.getElementById("TxtAmount_" + x).style.borderColor = "";
                $("#divLedger" + x + "> input").css("borderColor", "");
                $('#TableQstn_' + x + ' td:first-child').each(function () {
                    varId = $(this).text();
                    document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
                    if (document.getElementById("divCostCenter" + varId).style.display != "none") {
                        $("#divCostCenter" + varId + "> input").css("borderColor", "");
                        if (document.getElementById("ddlRecptCosCtr_" + varId).value == 0 && document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                        }
                        else {
                            if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                                var csamt = document.getElementById("TxtCstctrAmount_" + varId).value;
                                csamt = csamt.replace(/\,/g, '');
                                CstTotal = parseFloat(CstTotal) + parseFloat(csamt);
                                CstTotal = parseFloat(CstTotal).toFixed(FloatingValueMoney);
                            }
                            if (document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                                document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                                ret = false;
                                if (varfocus == "") {
                                    varfocus = varId;
                                    varfocusCheck = document.getElementById("tdvalidate" + varId).value;
                                }
                            }
                            var cscntrval = document.getElementById("ddlRecptCosCtr_" + varId).value;
                            if (cscntrval == "0") {
                                $("#divCostCenter" + varId + "> input").css("borderColor", "red");
                                $("#divCostCenter" + varId + "> input").select();
                                ret = false;
                                if (varfocus == "") {
                                    varfocus = varId;
                                    varfocusCheck = document.getElementById("tdvalidate" + varId).value;
                                }
                            }
                        }
                    }
                    else {
                        if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                            var varcstAmt = document.getElementById("TxtCstctrAmount_" + varId).value;
                            varcstAmt = varcstAmt.replace(/\,/g, '');
                            CstTotal = parseFloat(CstTotal) + parseFloat(varcstAmt);
                            CstTotal = parseFloat(CstTotal).toFixed(FloatingValueMoney);
                        }
                    }
                });
                var LedgerTotal = 0;
                var ledgerval = $("#ddlRecptLedger" + x).val();
                if (addRowtable.rows.length) {
                    if (document.getElementById("TxtAmount_" + x).value != "") {
                        LedgerTotal = document.getElementById("TxtAmount_" + x).value;
                        LedgerTotal = LedgerTotal.replace(/\,/g, '');
                        LedgerTotal = parseFloat(LedgerTotal);
                        LedgerTotal = LedgerTotal.toFixed(FloatingValueMoney);
                    }
                    else {
                        ret = false;
                        document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                        if (varfocus == "") {
                            if (varfocusLed == "")
                                varfocusLed = x;
                        }
                    }
                }
                if (ledgerval != 0) {
                    var ldgerAmt = document.getElementById("TxtAmount_" + x).value;
                    ldgerAmt = ldgerAmt.replace(/\,/g, '');
                    if (document.getElementById("TxtAmount_" + x).value != "" && ldgerAmt > 0) {
                        LedgerTotal = document.getElementById("TxtAmount_" + x).value;
                        LedgerTotal = LedgerTotal.replace(/\,/g, '');
                        LedgerTotal = parseFloat(LedgerTotal);
                        LedgerTotal = LedgerTotal.toFixed(FloatingValueMoney);
                    }
                    else {
                        ret = false;
                        document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                        if (varfocus == "") {
                            if (varfocusLed == "")
                                varfocusLed = x;
                            if (ledgerval == "0") {
                                $("#divLedger" + x + "> input").css("borderColor", "red");
                                $("#divLedger" + x + "> input").focus();
                                $("#divLedger" + x + "> input").select();
                                ret = false;
                            }
                        }
                    }
                }
                else if (ledgerval == "0") {
                    $("#divLedger" + x + "> input").css("borderColor", "red");
                    $("#divLedger" + x + "> input").focus();
                    $("#divLedger" + x + "> input").select();
                    ret = false;
                }
                if (varfocus != "" && varfocusLed != "") {
                    if (varfocusCheck < varfocusLed) {
                        if (document.getElementById("TxtCstctrAmount_" + varfocus).value == "") {
                            document.getElementById("TxtCstctrAmount_" + varfocus).focus();
                        }
                        if (document.getElementById("divCostCenter" + varfocus).style.display != "none") {
                            if (document.getElementById("ddlRecptCosCtr_" + varfocus).value == 0) {
                                $("#divCostCenter" + varfocus + "> input").focus();
                            }
                        }
                    }
                    else {
                        if (document.getElementById("TxtAmount_" + x).value == "") {
                            document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                            document.getElementById("TxtAmount_" + x).focus();
                            ret = false;
                        }
                        if (ledgerval == "0") {
                            $("#divLedger" + x + "> input").css("borderColor", "red");
                            $("#divLedger" + x + "> input").focus();
                            $("#divLedger" + x + "> input").select();
                            ret = false;
                        }
                    }
                }
                else if (varfocusLed != "") {
                    if (document.getElementById("TxtAmount_" + x).value == "") {
                        document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                        document.getElementById("TxtAmount_" + x).focus();
                        ret = false;
                    }
                    if (ledgerval == "0") {
                        $("#divLedger" + x + "> input").css("borderColor", "red");
                        $("#divLedger" + x + "> input").focus();
                        $("#divLedger" + x + "> input").select();
                        ret = false;
                    }
                }
                else if (varfocus != "") {
                    if (document.getElementById("TxtCstctrAmount_" + varfocus).value == "") {
                        document.getElementById("TxtCstctrAmount_" + varfocus).focus();
                    }
                    if (document.getElementById("divCostCenter" + varfocus).style.display != "none") {
                        if (document.getElementById("ddlRecptCosCtr_" + varfocus).value == 0) {
                            $("#divCostCenter" + varfocus + "> input").focus();
                        }
                    }
                }
                if (CstTotal != 0) {
                    if (LedgerTotal != CstTotal) {
                        $noCon("#divWarning").html("Ledger and cost centre amount should be equal.");
                        $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                        });

                        $noCon(window).scrollTop(0);
                        document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                        ret = false;
                        return false;
                    }
                }
                var SalCstAmt = CheckSumOfLedger("TxtAmount_" + x, +x);
                if (SalCstAmt == false) {
                }
            }
            if (ret == false) {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon(window).scrollTop(0);
                return false;
            }
            else if (SalCstAmt == false) {

                ret = false;
            }
            document.getElementById("cphMain_hiddenLedgerddl").value = "";
            document.getElementById("cphMain_hiddenCostCenterddl").value = "";
            var tbClientTotalValues = '';
            tbClientTotalValues = [];
            addRowtable = document.getElementById("tableGrp");
            for (var i = 1; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                var LedgerSts = document.getElementById("tdEvtGrp" + xLoop).value;
                var CstCntrId = "";
                var SalesId = "";
                var CostCntrAmt = "";
                var PrchsAmt = "";
                var CstGrp1Id = "";
                var CstGrp2Id = "";
                var EvtGrp = document.getElementById("tdDtlIdTempid" + xLoop).value;
                var CostCenterInfo = document.getElementById("tdCostCenterDtls" + xLoop).value;
                if (CostCenterInfo != "" && CostCenterInfo != "null" && CostCenterInfo != null) {
                    var splitrow = CostCenterInfo.split("$");
                    for (var Cst = 0; Cst < splitrow.length; Cst++) {
                        var splitEach = splitrow[Cst].split("%");
                        if (splitEach[0] != "" && splitEach[1] != "") {
                            if (CstCntrId == "") {
                                CstCntrId = splitEach[0];
                                splitEach[1] = splitEach[1].replace(/\,/g, '');
                                CostCntrAmt = splitEach[1];
                                CstGrp1Id = splitEach[4];
                                CstGrp2Id = splitEach[5];
                            }
                            else {
                                CstCntrId = CstCntrId + ',' + splitEach[0];
                                splitEach[1] = splitEach[1].replace(/\,/g, '');
                                CostCntrAmt = CostCntrAmt + ',' + splitEach[1];


                                CstGrp1Id = CstGrp1Id + ',' + splitEach[4];
                                CstGrp2Id = CstGrp2Id + ',' + splitEach[5];
                            }
                        }
                    }
                }

                var OpeningBalInfo = document.getElementById("tdLedgrPaid" + xLoop).value;

                if (OpeningBalInfo != "" && OpeningBalInfo != null && OpeningBalInfo != "null") {
                    //alert(document.getElementById("tdLedgrPaid" + xLoop).value);
                    OB = document.getElementById("tdLedgrPaid" + xLoop).value
                }
                var BalanceAmount = "0";

                var PurchaseInfo = document.getElementById("tdSalesDtls" + xLoop).value;
                if (PurchaseInfo != "" && PurchaseInfo != null && PurchaseInfo != "null") {
                    //   ButtnFillClickSales(1);
                    var splitrow = PurchaseInfo.split("$");
                    for (var Cst = 0; Cst < splitrow.length; Cst++) {
                        var splitEach = splitrow[Cst].split("%");
                        if (splitEach[0] != "" && splitEach[1] != "") {
                            if (SalesId == "") {
                                SalesId = splitEach[0];
                                splitEach[1] = splitEach[1].replace(/\,/g, '');
                                PrchsAmt = splitEach[1];
                            }
                            else {
                                SalesId = SalesId + ',' + splitEach[0];
                                splitEach[1] = splitEach[1].replace(/\,/g, '');
                                PrchsAmt = PrchsAmt + ',' + splitEach[1];
                            }
                        }
                    }
                }

                var $add = jQuery.noConflict();
                var client = JSON.stringify({
                    LEDGERID: "" + xLoop + "",
                    LEDGERSTATUS: "" + LedgerSts + "",
                    COSTCENTERID: "" + CstCntrId + "",
                    COSTCENTERAMT: "" + CostCntrAmt + "",
                    PURCHASEID: "" + SalesId + "",
                    PURCHASEAMT: "" + PrchsAmt + "",
                    LEDGERPYMTID: "" + EvtGrp + "",
                    COSTGRPID_ONE: "" + CstGrp1Id + "",
                    COSTGRPID_two: "" + CstGrp2Id + ""

                });
                tbClientTotalValues.push(client);
            }

            document.getElementById("<%=HiddenFieldSaveAccount.ClientID%>").value = JSON.stringify(tbClientTotalValues);
            return ret;
        }

        var incremtaccntcnge = 0;
        function IncrementAccountchange() {

            incremtaccntcnge++;
        }
       

       </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenPostdated" runat="server" />
    <asp:HiddenField ID="HiddenFieldRecurrencyPeriod" runat="server" />
    <asp:HiddenField ID="HiddenFieldRemindDays" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" />
    <asp:HiddenField ID="HiddentxtefctvedateTo" runat="server" />
    <asp:HiddenField ID="HiddenFieldTaxId" runat="server" />
    <asp:HiddenField ID="HiddenChkSts" runat="server" />
    <asp:HiddenField ID="HiddenView" runat="server" />
    <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="hiddenLedgerddl" runat="server" />
    <asp:HiddenField ID="hiddenCostCenterddl" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="Hiddenreturnfun" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYearId" runat="server" />
    <asp:HiddenField ID="HiddenFieldSaveAccount" runat="server" />
    <asp:HiddenField ID="HiddenFieldView" runat="server" />
    <asp:HiddenField ID="hiddenQstnCanclDtlId" runat="server" />
    <asp:HiddenField ID="hiddenLedgerCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenCRNCYABRVTN" runat="server" />
    <asp:HiddenField ID="HiddenEdit" runat="server" />
    <asp:HiddenField ID="HiddenViewDtls" runat="server" />
    <asp:HiddenField ID="HiddenEditcstcntjson" runat="server" />
    <asp:HiddenField ID="HiddenLedgerId" runat="server" />
    <asp:HiddenField ID="HiddenLedgercnt" runat="server" />
    <asp:HiddenField ID="HiddenTotalAmount" runat="server" />
    <asp:HiddenField ID="HiddenCurrcyFxAbbrvn" runat="server" />
    <asp:HiddenField ID="HiddenExRateSts" runat="server" />
    <asp:HiddenField ID="HiddenDefultCrncAbrvtn" runat="server" />
    <asp:HiddenField ID="HiddenPaymode" runat="server" />
    <asp:HiddenField ID="HiddenPrevTab" runat="server" />
    <asp:HiddenField ID="HiddenStartDate" runat="server" />
    <asp:HiddenField ID="HiddenAcntClsSts" runat="server" />
    <asp:HiddenField ID="HiddenAcntClsDate" runat="server" />
    <asp:HiddenField ID="HiddenProvisionSts" runat="server" />
    <asp:HiddenField ID="HiddenPresentDate" runat="server" />
    <asp:HiddenField ID="HiddenRefAccountCls" runat="server" />
    <asp:HiddenField ID="HiddenUpdatedDate" runat="server" />
    <asp:HiddenField ID="HiddenRefNum" runat="server" />
    <asp:HiddenField ID="HiddenFieldAcntCloseReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenReptID" runat="server" />
    <asp:HiddenField ID="HiddenUpdRefNum" runat="server" />
    <asp:HiddenField ID="HiddenChangeSts" runat="server" />
    <asp:HiddenField ID="HiddenReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldAuditCloseReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenCostGroup1ddl" runat="server" />
    <asp:HiddenField ID="HiddenCostGroup2ddl" runat="server" />
    <asp:HiddenField ID="HiddenRefNextNum" runat="server" />
    <asp:HiddenField ID="hiddenSelectedAccntBk" runat="server" />
    <asp:HiddenField ID="HiddenLedgrDupSts" runat="server" />
   <asp:HiddenField ID="HiddenOBstatus" runat="server" />
   <asp:HiddenField ID="HiddenRecurring" runat="server" />


  <div id="divLinkSection" runat="server">
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a id="aDashBord"  runat="server"  href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="fms_Receipt_Account_List.aspx">Receipt</a></li>
        <li class="active">Add Receipt</li>
    </ol>
  </div>
      <!---alert_message_section---->
<div class="myAlert-top alert alert-success" id="success-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully
</div>

<div class="myAlert-bottom alert alert-danger" id="divWarning">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Danger!</strong> Request not conmpleted
</div>
<!----alert_message_section_closed---->
     
    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                 <div class="" onmouseover="closesave()">
                <div id="divReportCaption" runat="server">
                    <h2>
                    <asp:Label ID="lblEntry" runat="server"></asp:Label></h2>
                </div>
                <div class="form-group fg2">
                    <label for="pwd" class="fg2_la1">Receipt REF#:<span class="spn1">*</span></label>
                    <input id="TxtRef" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control fg2_inp1 inp_mst" maxlength="50" />
                </div>
                <div class="form-group fg2">
                    <label for="pwd" class="fg2_la1 fg_9">Account Book:<span class="spn1">*</span>
                         <span runat="server" id="AccntBalance" class="input-group-addon cur2 c2h flt_amt1" style=""></span>

                    </label>
                    <div id="divAccount">
                        <asp:DropDownList ID="ddlAccontLed" class="form-control fg2_inp1 fg_chs1 inp_mst ddl" onchange="return AccntChangeFunt(1);"  runat="server">
                        </asp:DropDownList>
                    </div>
                  
                </div>
            <div class="form-group fg5">
    <label for="pwd" class="fg2_la1"> Date:<span class="spn1">*</span> </label>
    <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
      <input id="txtdate"  runat="server" type="text"  onkeypress="return DisableEnterAndComma(event)" onkeydown="return DisableEnterAndComma(event)"    onchange="showFromDate()"   class="form-control inp_bdr inp_mst"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
   
      <span id="spandate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      var curentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value
                      var StartDate = document.getElementById("<%=HiddenStartDate.ClientID%>").value

                      $noCon('#datepicker').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          startDate: StartDate,
                          endDate: curentDate,
                          timepicker: false
                      });

                      function DateChk() {
                          var ret = true;
                          if (document.getElementById("cphMain_txtdate").value != "")
                          {

                              var datepickerDate = document.getElementById("cphMain_txtdate").value;
                              var arrDatePickerDate = datepickerDate.split("-");
                              var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
                          }
                          return ret;
                      }
                      function DisableEnter(evt) {
                          evt = (evt) ? evt : window.event;
                          var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                          if (keyCodes == 13) {
                              return false;
                          }
                      }
       </script>
    </div>
  </div>

                <div class="form-group col-md-4" style="display: none;">
                    <label for="example-text-input" class="col-md-3 col-form-label">Currency<span>*</span></label>
                    <div class="col-md-9">
                        <asp:DropDownList ID="ddlCurrency" class="form-control" onchange="return curncyChangeFunt();" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>

<div class="clearfix"></div>
<div class="devider"></div>

                <table id="tableGrp" class="table table-bordered" >
                    <thead class="thead1">
                        <tr>
                            <th class="col-md-5 t_r">Particulars</th>
                            <th class="col-md-2 tr_c">Amount</th>
                            <th class="col-md-2 tr_l">Remarks</th>
                            <th  class="col-md-2 tr_c">Actions</th>
                            <th class="col-md-1 tr_c">Sale/CC</th>
                        </tr>
                    </thead>
                    <tbody ></tbody>
                </table>
               <div runat="server" id="divExchangecurency" class="form-group col-md-6" style="display: none">
                    <label for="inputPassword" class="col-md-3 col-form-label" style="width: 20%;">Exchange Rate<span>*</span></label>
                    <div class="col-md-9" style="width: 63%;">
                        <asp:TextBox ID="txtExchangeRate" Height="30px" class="form-control" runat="server" TabIndex="5" MaxLength="20" onchange="IncrmntConfrmCounter();" onblur="CalculateForexAmt()" Style="margin-right: 4%;"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                        <asp:Label ID="lblCrncyAbrvtn" Height="30px" class="col-sm-4 col-form-label font-sty" runat="server" Style="width: 27%;"></asp:Label>
                    </div>
                </div>

                <div id="PaymentMode" style="display:none;">
                    <div class="clearfix"></div>
                    <div class="free_sp"></div>
                    <div class="devider"></div>

                <div class="tab2" >
                    <button id="lisCheque" class="tablinks active" onclick="return ChangePaymentode('Cheque_tab');">Cheque</button>
                    <button id="liDD" class="tablinks" onclick="return ChangePaymentode('DD_tab');">DD</button>
                    <button id="liBankTransfer" class="tablinks" onclick="return ChangePaymentode('BankTransfer_tab');">Bank Transfer</button>
                </div>
                <div id="Cheque" class="tab2content">
                    <div class="fg2" id="divChequeBank">
                        <label for="example-text-input"  class="fg2_la1">Bank<span></span></label>
                        <input id="ddlChequeBank" autocomplete="off"   onblur="PaymentCounter();"  style="" runat="server" type="text"  onkeypress="return DisableEnter(event)"  class="form-control fg2_inp1 fg_chs1"  maxlength="50" />
                    </div>
               
                <div class="fg2">
                    <label for="example-text-input" class="fg2_la1">IBAN<span></span></label>
                    <input id="txtChequeIBAN" onblur="PaymentCounter();" runat="server" autocomplete="off" type="text" onkeypress="return DisableEnter(event)" class="form-control fg2_inp1 fg_chs1 inp_mst" maxlength="50" />
             
                </div>


                   <div class="fg2">
                    <div class="tdte">
                        <label for="example-text-input" class="fg2_la1">Date<span class="spn1">*</span></label>
                        <div id="divChequedate" class="input-group date" data-date-format="mm-dd-yyyy">
                            <input id="txtDate_Cheque" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event)" onblur="PaymentCounter();" class="form-control inp_bdr" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                            <span id="spanChqDate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                        </div>
                        <script>
                            var txtDate_Cheque_currentDate = document.getElementById("<%=HiddenPresentDate.ClientID%>").value;

                            $noCon('#divChequedate').datepicker({
                                autoclose: true,
                                format: 'dd-mm-yyyy',
                                startDate: txtDate_Cheque_currentDate,
                                timepicker: false
                            });
                        </script>
                    </div>
                </div>

                <div class="fg2">
                    <label for="example-text-input" class="fg2_la1">Cheque Number<span class="spn1">*</span></label>
                        <input id="txtChequeNo_Cheque" autocomplete="off" onblur="return changeBankAcNum();" runat="server" type="text" onkeypress="return isNumberAmount(event)" onkeydown="return isNumberAmount(event)" class=" form-control fg2_inp1 fg_chs1 inp_mst " maxlength="10" />
                </div>
           </div>

                <div id="DD" class="tab2content">

               <%-- <div class="tab-pane fade" id="DD" role="tabpanel" aria-labelledby="profile-tab" style="border: 1px solid #dddddd;border-top: none;padding:15px;float:left;width: 100%;display:none">--%>

      
                    <div class="fg2">
                        <label for="example-text-input" class="fg2_la1">DD<span class="spn1">*</span></label>
                        <input id="txtDD_DD" autocomplete="off" onblur="PaymentCounter();" maxlength="10" runat="server" type="text" onkeyup="return DisableEnter(event)" onkeypress="return isNumberAmount(event)" onkeydown="return isNumberAmount(event)" class="form-control fg2_inp1 inp_mst" />
                    </div>

              <div class="fg2">
                   <div class="tdte">
                  <label for="example-text-input"  class="fg2_la1">Date<span class="spn1">*</span></label>
                    <div id="datepicker4" class="input-group date" data-date-format="mm-dd-yyyy">
                      <input id="txtDate_DD" readonly="readonly" runat="server" type="text" onkeydown=" PaymentCounter();" onkeypress="return DisableEnter(event)"  class="form-control inp_bdr inp_mst"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                          <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  </div>
                       </div>
                
                       <script>
                           var txtDate_DD_currentDate = document.getElementById("<%=HiddenPresentDate.ClientID%>").value;
                           $noCon('#cphMain_txtDate_DD').datepicker({
                               autoclose: true,
                               format: 'dd-mm-yyyy',
                               startDate: txtDate_DD_currentDate,
                               timepicker: false
                           });
                       </script>
              </div>



                    <div class="fg2">
                        <label for="example-text-input"  class="fg2_la1">Bank<span></span></label>
                        <div id="divDDBank" class="col-md-8">
                            <input id="ddlDDBank" onkeydown="PaymentCounter();" autocomplete="off"  runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control fg2_inp1 fg_chs1" maxlength="50" />

                            <script>
                        
                            </script>
                        
                        </div>
                    </div>

               <div class="fg2">
                  <label for="example-text-input" class="fg2_la1">IBAN<span class="spn1"></span></label>
                  
                <input id="txtDDIBAN"  autocomplete="off" onblur="PaymentCounter();" runat="server" type="text"  onkeypress="return DisableEnter(event)"  class="form-control fg2_inp1 fg_chs1"  maxlength="50" />

                  
                  </div>
              </div>
                    <div id="BankTransfer" class="tab2content">
                        <div class="fg2">
                            <label for="example-text-input" class="fg2_la1">Mode<span class="spn1">*</span></label>
                            <asp:DropDownList ID="ddlMode_BankTransfer" class="form-control fg2_inp1 fg_chs1 inp_mst" onchange=" PaymentCounter();" Style="" runat="server">
                                <asp:ListItem Text="IMPS" Value="0"></asp:ListItem>
                                <asp:ListItem Text="NEFT" Value="1"></asp:ListItem>
                                <asp:ListItem Text="RTGS" Value="2"></asp:ListItem>
                                <asp:ListItem Text="OTHERS" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <p style="margin-top: 2%; font-weight: bold;"><span runat="server" id="Span2"></span></p>
                        </div>
                        <div class="fg2">
                            <div class="tdte">
                                <label for="example-text-input" class="fg2_la1">Date<span class="spn1">*</span></label>
                                <div id="datepicker5" class="input-group date" data-date-format="mm-dd-yyyy">
                                    <input id="txtDate_BankTransfer" readonly="readonly" onblur=" PaymentCounter();" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr inp_mst" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                    <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                                </div>
                                <script>
                                    var txtDate_BankTransfer_currentDate = document.getElementById("<%=HiddenPresentDate.ClientID%>").value;
                                    $noCon('#cphMain_txtDate_BankTransfer').datepicker({
                                        autoclose: true,
                                        format: 'dd-mm-yyyy',
                                        startDate: txtDate_BankTransfer_currentDate,
                                        timepicker: false
                                    });
                                </script>
                            </div>
                        </div>
                        <div class="fg2" style="">
                            <label for="example-text-input" class="fg2_la1">Bank<span></span></label>
                            <input id="ddlTransfrBank" onblur="PaymentCounter();" runat="server" type="text" autocomplete="off" onkeypress="return DisableEnter(event)" class="form-control fg2_inp1 fg_chs1" maxlength="50" />
                        </div>
                        <div class="fg2">
                            <label for="example-text-input" class="fg2_la1">IBAN<span class="spn1"></span></label>
                            <input id="txtTranserIBAN" autocomplete="off" onblur="PaymentCounter();" runat="server" type="text" onkeypress="return DisableEnter(event)" class=" form-control fg2_inp1 " maxlength="50" />
                        </div>

                    </div>

                 </div>

                    <div class="clearfix"></div>
                    <div class="free_sp"></div>

                <!---text_Area_section_started--->
  <div class="text_area_container">
      <div class="col-md-8 mar_a flt_l">
          <div class="form-group">
              <label for="email" class="fg2_la1">Narration:<span class="spn1">&nbsp;</span></label>
              <textarea class="form-control" id="txtDesc" onkeypress="return  isTagEnter(event);" onblur=" RemoveTag();" maxlength="450" runat="server" rows="4" cols="50"   style="resize: none;">
                </textarea>
          </div>
      </div>
      <div class="col-md-4 txt_alg mar_a flt_l">
          <label for="email" class="fg2_la1">Total Amount:<span class="spn1">&nbsp;</span></label>
          <div class="input-group">
              <span class="input-group-addon cur1">
                  <label for="example-text-input" class="col-form-label" id="lblCurrency"></label>
              </span>
              <input id="txtTotalAmt" readonly="readonly" runat="server" type="text" class="form-control fg2_inp2  tr_r" />
              <asp:TextBox ID="txtTotal" lass="form-control fg2_inp2  tr_r" runat="server" Rows="4" cols="50" Style="display: none;"></asp:TextBox>
          </div>


          <div style="margin-top:5%;" id="divRecur" runat="server">
           <a href="javascript:;" id="popup-btn" > <i class="fa fa-retweet gre" title="Recurring" ></i></a>         
         </div>

      </div>

      


      <div id="divForeXAmt" runat="server" class="col-md-12" style="margin-bottom: 20px; width: 32%; float: right; display: none">
          <label for="example-text-input" class="col-md-1 col-form-label" style="width: 33%;">Forex Total Amount<span></span></label>
          <div class="col-md-11" style="width: 66%;">
              <input id="txtForexAmt" readonly="readonly" runat="server" type="text" style="margin-left: 2%; text-align: right;" class="form-control" />
          </div>
      </div>
  </div>

                 <div class="clearfix"></div>
                <div class="devider divid"></div>

  </div>

                <a id="btnFloat" runat="server" onmouseover="opensave()" type="button" class="save_b" title="Save" >
                    <i class="fa fa-save"></i>
                </a>

                <script>
                    function opensave() {
                        document.getElementById("cphMain_mySave").style.width = "140px";
                    }

                    function closesave() {
                        document.getElementById("cphMain_mySave").style.width = "0px";
                    }
                
                    function mysave() {
                        var x = document.getElementById("mysav");
                        if (x.style.display === "block") {
                            x.style.display = "none";
                        } else {
                            x.style.display = "block";
                        }
                    }
                </script>
              



<div class="sub_cont pull-right" >
     <div class="save_sec">
    <asp:Button ID="bttnsave" runat="server" OnClientClick="return ValidateReceiptAccnt();" OnClick="bttnsave_Click" class="btn sub1" Text="Save" />
    <asp:Button ID="btnSaveCls" runat="server" OnClientClick="return ValidateReceiptAccnt();" class="btn sub3" Text="Save & Close" OnClick="bttnsave_Click" />

    <asp:Button ID="btnUpdate" runat="server" OnClientClick="return ValidateReceiptAccnt();" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnUpdatecls" runat="server" OnClientClick="return ValidateReceiptAccnt();" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />

    <asp:Button ID="btnConfirm1" runat="server" class="btn sub2" Text="Confirm" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnConfirm" runat="server" class="btn sub2" Text="Confirm" OnClientClick="return ConfirmAlert();" />
    <asp:Button ID="btnReopen" runat="server" class="btn sub2" Text="Reopen" OnClientClick="return ConfirmReopen(1);" />
    <asp:Button ID="btnReopen1" runat="server" class="btn sub2" Style="display: none" Text="Reopen" OnClick="btnReopen_Click" />
    <input type="button" id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
      <asp:Button ID="ButtnClose"  runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
    <asp:Button ID="btnPRint" runat="server" class="btn sub2" Text="Print" OnClientClick="return  PrintValue(); " /> 
</div>
</div>

          <div id="divList" runat="server" class="list_b" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
            <i class="fa fa-arrow-circle-left"></i>
        </div>
  

                   <div class="mySave1" id="mySave" runat="server">
                    <div class="save_sec">
                        <asp:Button ID="btnFloatSave" runat="server" OnClientClick="return ValidateReceiptAccnt();" OnClick="bttnsave_Click" class="btn sub1" Text="Save" />
                        <asp:Button ID="btnFloatSaveCls" runat="server" OnClientClick="return ValidateReceiptAccnt();" class="btn sub3" Text="Save & Close" OnClick="bttnsave_Click" />
                        <asp:Button ID="btnFloatUpdate" runat="server" OnClientClick="return ValidateReceiptAccnt();" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnFloatUpdateCls" runat="server" OnClientClick="return ValidateReceiptAccnt();" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnFloatConfirm1" runat="server" Style="display: none" class="btn sub2" Text="Confirm" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnFloatConfirm" runat="server"  class="btn sub2" Text="Confirm" OnClientClick="return ConfirmAlert();" />
                        <asp:Button ID="btnFloatReopen" runat="server" class="btn sub2" Text="Reopen" OnClientClick="return ConfirmReopen(2);" />
                        <asp:Button ID="btnFloatReopen1" runat="server" class="btn sub2" Style="display: none" Text="Reopen" OnClick="btnReopen_Click" />
                        <input type="button" id="btnFloatCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
                        <asp:Button ID="ButtnFloatClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                        <asp:Button ID="btnFloatPrint" runat="server" class="btn sub2" Text="Print" OnClientClick="return  PrintValue(); " />
                    </div>
                </div>



      </div>   
   </div>
 </div>
           



          <script>

              function CalculateForexAmt() {
                  if (document.getElementById("<%=txtExchangeRate.ClientID%>").value != "") {
                      if (document.getElementById("<%=txtTotalAmt.ClientID%>").value != "") {
                          var exchngRt = document.getElementById("<%=txtExchangeRate.ClientID%>").value;
                          exchngRt = exchngRt.replace(/>/g, "");
                          var ttl = document.getElementById("<%=txtTotalAmt.ClientID%>").value;
                          ttl = ttl.replace(/>/g, "");
                          document.getElementById("<%=txtForexAmt.ClientID%>").value = parseFloat(exchngRt) * parseFloat(ttl);

                          addCommas("txtForexAmt");
                      }
                  }
              }
              var paymentDone = 0;

              function PaymentCounter() {
                 

               //   IncrmntConfrmCounter();
                  paymentDone++;
                  return false;
              }
              function ChangePaymentode(tabName) {
                  if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {

                      if (paymentDone > 0) {
                          ezBSAlert({
                              type: "confirm",
                              messageText: "Are you sure you want to change the payment mode?",
                              alertType: "info"
                          }).done(function (e) {
                              if (e == true) {
                                  if (tabName == "Cheque_tab") {
                                      document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "Cheque";
                                      document.getElementById("<%=txtDate_BankTransfer.ClientID%>").value = "";
                                      $('#cphMain_ddlMode_BankTransfer option').prop('selected', function () {
                                          return this.defaultSelected;
                                      });
                                      document.getElementById("<%=txtDate_DD.ClientID%>").value = "";
                                      document.getElementById("<%=txtDD_DD.ClientID%>").value = "";

                                      document.getElementById("<%=ddlTransfrBank.ClientID%>").value = "";

                                      document.getElementById("<%=txtTranserIBAN.ClientID%>").value = "";

                                      document.getElementById("<%=ddlDDBank.ClientID%>").value = "";
                                      document.getElementById("<%=txtDDIBAN.ClientID%>").value = "";
                                      $('#liBankTransfer').removeClass('tablinks active').addClass('tablinks');
                                      $('#BankTransfer').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                                      $('#liDD').removeClass('tablinks active').addClass('tablinks');
                                      $('#DD').removeClass('tab-pane fade active in').addClass('tab-pane fade');

                                      $('#lisCheque').removeClass('tablinks').addClass('tablinks active');
                                      $('#Cheque').removeClass('tab-pane fade').addClass('tab-pane fade active in');
                                      document.getElementById("DD").style.display = "none";
                                      document.getElementById("BankTransfer").style.display = "none";

                                      document.getElementById("Cheque").style.display = "block";
                                      paymentDone = 0;

                                  }
                                  else if (tabName == "DD_tab") {
                                      document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "DD";
                                      $('#cphMain_ddlChequeBank option').prop('selected', function () {
                                          return this.defaultSelected;
                                      });

                                    
                                      document.getElementById("<%=ddlChequeBank.ClientID%>").value = "";

                                      document.getElementById("<%=txtDate_Cheque.ClientID%>").value = "";
                                      document.getElementById("<%=txtChequeNo_Cheque.ClientID%>").value = "";
                                      document.getElementById("<%=txtChequeIBAN.ClientID%>").value = "";
                                      document.getElementById("<%=ddlTransfrBank.ClientID%>").value = "";
                                      document.getElementById("<%=txtTranserIBAN.ClientID%>").value = "";
                                      document.getElementById("<%=txtDate_BankTransfer.ClientID%>").value = "";
                                      $('#cphMain_ddlMode_BankTransfer option').prop('selected', function () {
                                          return this.defaultSelected;
                                      });

                                      $('#liBankTransfer').removeClass('tablinks active').addClass('tablinks');
                                      $('#BankTransfer').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                                      $('#lisCheque').removeClass('tablinks active').addClass('tablinks');
                                      $('#Cheque').removeClass('tab-pane fade active in').addClass('tab-pane fade');


                                      $('#liDD').removeClass('tablinks').addClass('tablinks active');
                                      $('#DD').removeClass('tab-pane fade').addClass('tab-pane fade active in');
                                      document.getElementById("BankTransfer").style.display = "none";
                                      document.getElementById("DD").style.display = "block";
                                      document.getElementById("Cheque").style.display = "none";
                                      paymentDone = 0;

                                  }
                                  else if (tabName == "BankTransfer_tab") {
                                      document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "BankTransfer";

                                      //   $('#cphMain_ddlChequeBook_Cheque').val('');
                                      $('#cphMain_ddlChequeBook_Cheque option').prop('selected', function () {
                                          return this.defaultSelected;
                                      });
                                      //   $('#cphMain_ddlChequeNum_Cheque').val('');
                                      $('#cphMain_ddlChequeNum_Cheque option').prop('selected', function () {


                                          return this.defaultSelected;
                                      });


                                      $('#cphMain_ddlChequeBank option').prop('selected', function () {
                                          return this.defaultSelected;
                                      });

                                      document.getElementById("<%=txtChequeIBAN.ClientID%>").value = "";


                                      document.getElementById("<%=ddlChequeBank.ClientID%>").value = "";
                                      document.getElementById("<%=ddlDDBank.ClientID%>").value = "";

                                      document.getElementById("<%=txtDDIBAN.ClientID%>").value = "";

                                      document.getElementById("<%=txtDate_Cheque.ClientID%>").value = "";
                                      document.getElementById("<%=txtChequeNo_Cheque.ClientID%>").value = "";

                                      document.getElementById("<%=txtDate_DD.ClientID%>").value = "";
                                      document.getElementById("<%=txtDD_DD.ClientID%>").value = "";


                                      $('#liDD').removeClass('tablinks active').addClass('tablinks');
                                      $('#DD').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                                      $('#lisCheque').removeClass('tablinks active').addClass('tablinks');
                                      $('#Cheque').removeClass('tab-pane fade active in').addClass('tab-pane fade');

                                      $('#liBankTransfer').removeClass('tablinks').addClass('tablinks active');
                                      $('#BankTransfer').removeClass('tab-pane fade').addClass('tab-pane fade active in');

                                      document.getElementById("BankTransfer").style.display = "block";
                                      document.getElementById("DD").style.display = "none";
                                      document.getElementById("Cheque").style.display = "none";
                                      paymentDone = 0;

                                  }
                      }
                      else {
                          if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "Cheque") {

                                      $('#liBankTransfer').removeClass('tablinks active').addClass('tablinks');
                                      $('#BankTransfer').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                                      $('#liDD').removeClass('tablinks active').addClass('tablinks');
                                      $('#DD').removeClass('tab-pane fade active in').addClass('tab-pane fade');

                                      $('#lisCheque').removeClass('tablinks').addClass('tablinks active');
                                      $('#Cheque').removeClass('tab-pane fade').addClass('tab-pane fade active in');
                                      document.getElementById("DD").style.display = "none";
                                      document.getElementById("BankTransfer").style.display = "none";
                                      document.getElementById("Cheque").style.display = "block";
                                  }
                                  else if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "DD") {

                                      $('#liBankTransfer').removeClass('tablinks active').addClass('tablinks');
                                      $('#BankTransfer').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                                      $('#lisCheque').removeClass('tablinks active').addClass('tablinks');
                                      $('#Cheque').removeClass('tab-pane fade active in').addClass('tab-pane fade');


                                      $('#liDD').removeClass('tablinks').addClass('tablinks active');
                                      $('#DD').removeClass('tab-pane fade').addClass('tab-pane fade active in');
                                      document.getElementById("DD").style.display = "block";
                                      document.getElementById("BankTransfer").style.display = "none";
                                      document.getElementById("Cheque").style.display = "none";
                                  }
                                  else if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "BankTransfer") {

                                      $('#liDD').removeClass('tablinks active').addClass('tablinks');
                                      $('#DD').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                                      $('#lisCheque').removeClass('tablinks active').addClass('tablinks');
                                      $('#Cheque').removeClass('tab-pane fade active in').addClass('tab-pane fade');

                                      $('#liBankTransfer').removeClass('tablinks').addClass('tablinks active');
                                      $('#BankTransfer').removeClass('tab-pane fade').addClass('tab-pane fade active in');
                                      document.getElementById("DD").style.display = "none";
                                      document.getElementById("BankTransfer").style.display = "block";
                                      document.getElementById("Cheque").style.display = "none";
                                  }
                              return false;
                          }

                          });
                      return false;
                  }
                  else {
                      if (tabName == "Cheque_tab") {
                          document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "Cheque";

                              document.getElementById("<%=txtDate_BankTransfer.ClientID%>").value = "";
                              $('#cphMain_ddlMode_BankTransfer option').prop('selected', function () {
                                  return this.defaultSelected;
                              });
                              document.getElementById("<%=txtDate_DD.ClientID%>").value = "";
                              document.getElementById("<%=txtDD_DD.ClientID%>").value = "";
                              document.getElementById("<%=ddlDDBank.ClientID%>").value = "";
                              document.getElementById("<%=txtDDIBAN.ClientID%>").value = "";
                              $('#liBankTransfer').removeClass('tablinks active').addClass('tablinks');
                              $('#BankTransfer').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                              $('#liDD').removeClass('tablinks active').addClass('tablinks');
                              $('#DD').removeClass('tab-pane fade active in').addClass('tab-pane fade');

                              $('#lisCheque').removeClass('tablinks').addClass('tablinks active');
                              $('#Cheque').removeClass('tab-pane fade').addClass('tab-pane fade active in');
                              paymentDone = 0;
                              document.getElementById("DD").style.display = "none";
                              document.getElementById("BankTransfer").style.display = "none";
                              document.getElementById("Cheque").style.display = "block";
                          }
                          else if (tabName == "DD_tab") {
                              document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "DD";


                              //   $('#cphMain_ddlChequeBook_Cheque').val('');
                              $('#cphMain_ddlChequeBook_Cheque option').prop('selected', function () {
                                  return this.defaultSelected;
                              });
                              //    $('#cphMain_ddlChequeNum_Cheque').val('');
                              $('#cphMain_ddlChequeNum_Cheque option').prop('selected', function () {
                                  return this.defaultSelected;
                              });
                              document.getElementById("<%=txtDate_Cheque.ClientID%>").value = "";
                              document.getElementById("<%=txtChequeNo_Cheque.ClientID%>").value = "";



                              document.getElementById("<%=txtDate_BankTransfer.ClientID%>").value = "";
                              $('#cphMain_ddlMode_BankTransfer option').prop('selected', function () {
                                  return this.defaultSelected;
                              });

                              $('#liBankTransfer').removeClass('tablinks active').addClass('tablinks');
                              $('#BankTransfer').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                              $('#lisCheque').removeClass('tablinks active').addClass('tablinks');
                              $('#Cheque').removeClass('tab-pane fade active in').addClass('tab-pane fade');


                              $('#liDD').removeClass('tablinks').addClass('tablinks active');
                              $('#DD').removeClass('tab-pane fade').addClass('tab-pane fade active in');
                              paymentDone = 0;
                              document.getElementById("BankTransfer").style.display = "none";
                              document.getElementById("DD").style.display = "block";
                              document.getElementById("Cheque").style.display = "none";

                          }
                          else if (tabName == "BankTransfer_tab") {
                              document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "BankTransfer";

                              //   $('#cphMain_ddlChequeBook_Cheque').val('');
                              $('#cphMain_ddlChequeBook_Cheque option').prop('selected', function () {
                                  return this.defaultSelected;
                              });
                              //   $('#cphMain_ddlChequeNum_Cheque').val('');
                              $('#cphMain_ddlChequeNum_Cheque option').prop('selected', function () {
                                  return this.defaultSelected;
                              });
                              document.getElementById("<%=txtDate_Cheque.ClientID%>").value = "";
                              document.getElementById("<%=txtChequeNo_Cheque.ClientID%>").value = "";

                              document.getElementById("<%=txtDate_DD.ClientID%>").value = "";
                              document.getElementById("<%=txtDD_DD.ClientID%>").value = "";
                              document.getElementById("<%=ddlDDBank.ClientID%>").value = "";
                              document.getElementById("<%=txtDDIBAN.ClientID%>").value = "";

                              $('#liDD').removeClass('tablinks active').addClass('tablinks');
                              $('#DD').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                              $('#lisCheque').removeClass('tablinks active').addClass('tablinks');
                              $('#Cheque').removeClass('tab-pane fade active in').addClass('tab-pane fade');

                              $('#liBankTransfer').removeClass('tablinks').addClass('tablinks active');
                              $('#BankTransfer').removeClass('tab-pane fade').addClass('tab-pane fade active in');

                              document.getElementById("BankTransfer").style.display = "block";
                              document.getElementById("DD").style.display = "none";
                              document.getElementById("Cheque").style.display = "none";
                              paymentDone = 0;

                          }
                  return false;
              }
          }
          else {
              if (tabName == "Cheque_tab") {
                  document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "Cheque";

                          document.getElementById("<%=txtDate_BankTransfer.ClientID%>").value = "";
                          $('#cphMain_ddlMode_BankTransfer option').prop('selected', function () {
                              return this.defaultSelected;
                          });
                          document.getElementById("<%=txtDate_DD.ClientID%>").value = "";
                           document.getElementById("<%=txtDD_DD.ClientID%>").value = "";
                          document.getElementById("<%=ddlDDBank.ClientID%>").value = "";
                          document.getElementById("<%=txtDDIBAN.ClientID%>").value = "";
                          $('#liBankTransfer').removeClass('tablinks active').addClass('tablinks');
                          $('#BankTransfer').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                          $('#liDD').removeClass('tablinks active').addClass('tablinks');
                          $('#DD').removeClass('tab-pane fade active in').addClass('tab-pane fade');

                          $('#lisCheque').removeClass('tablinks').addClass('tablinks active');
                          $('#Cheque').removeClass('tab-pane fade').addClass('tab-pane fade active in');
                          paymentDone = 0;
                          document.getElementById("DD").style.display = "none";
                          document.getElementById("BankTransfer").style.display = "none";
                          document.getElementById("Cheque").style.display = "block";
                      }
                      else if (tabName == "DD_tab") {
                          document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "DD";


                           //   $('#cphMain_ddlChequeBook_Cheque').val('');
                           $('#cphMain_ddlChequeBook_Cheque option').prop('selected', function () {
                               return this.defaultSelected;
                           });
                           //    $('#cphMain_ddlChequeNum_Cheque').val('');
                           $('#cphMain_ddlChequeNum_Cheque option').prop('selected', function () {
                               return this.defaultSelected;
                           });
                           document.getElementById("<%=txtDate_Cheque.ClientID%>").value = "";
                              document.getElementById("<%=txtChequeNo_Cheque.ClientID%>").value = "";



                           document.getElementById("<%=txtDate_BankTransfer.ClientID%>").value = "";
                           $('#cphMain_ddlMode_BankTransfer option').prop('selected', function () {
                               return this.defaultSelected;
                           });

                           $('#liBankTransfer').removeClass('tablinks active').addClass('tablinks');
                           $('#BankTransfer').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                           $('#lisCheque').removeClass('tablinks active').addClass('tablinks');
                           $('#Cheque').removeClass('tab-pane fade active in').addClass('tab-pane fade');


                           $('#liDD').removeClass('tablinks').addClass('tablinks active');
                           $('#DD').removeClass('tab-pane fade').addClass('tab-pane fade active in');
                           paymentDone = 0;
                           document.getElementById("BankTransfer").style.display = "none";
                           document.getElementById("DD").style.display = "block";
                           document.getElementById("Cheque").style.display = "none";

                       }
                       else if (tabName == "BankTransfer_tab") {
                           document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "BankTransfer";

                              //   $('#cphMain_ddlChequeBook_Cheque').val('');
                              $('#cphMain_ddlChequeBook_Cheque option').prop('selected', function () {
                                  return this.defaultSelected;
                              });
                              //   $('#cphMain_ddlChequeNum_Cheque').val('');
                              $('#cphMain_ddlChequeNum_Cheque option').prop('selected', function () {
                                  return this.defaultSelected;
                              });
                              document.getElementById("<%=txtDate_Cheque.ClientID%>").value = "";
                              document.getElementById("<%=txtChequeNo_Cheque.ClientID%>").value = "";

                              document.getElementById("<%=txtDate_DD.ClientID%>").value = "";
                              document.getElementById("<%=txtDD_DD.ClientID%>").value = "";
                              document.getElementById("<%=ddlDDBank.ClientID%>").value = "";
                              document.getElementById("<%=txtDDIBAN.ClientID%>").value = "";

                              $('#liDD').removeClass('tablinks active').addClass('tablinks');
                              $('#DD').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                              $('#lisCheque').removeClass('tablinks active').addClass('tablinks');
                              $('#Cheque').removeClass('tab-pane fade active in').addClass('tab-pane fade');

                              $('#liBankTransfer').removeClass('tablinks').addClass('tablinks active');
                              $('#BankTransfer').removeClass('tab-pane fade').addClass('tab-pane fade active in');

                              document.getElementById("BankTransfer").style.display = "block";
                              document.getElementById("DD").style.display = "none";
                              document.getElementById("Cheque").style.display = "none";
                              paymentDone = 0;

                          }
                  return false;
              }
          }



          function ConfirmReopen(mode) {


              ezBSAlert({
                  type: "confirm",
                  messageText: "Are you sure you want to reopen this receipt?",
                  alertType: "info"
              }).done(function (e) {
                  if (e == true) {
                      //Sales
                      document.getElementById("<%=hiddenLedgerddl.ClientID%>").value = "";
                      document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
                      document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
                      document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = ""; 

                      if (mode == 1) {
                          document.getElementById("<%=btnReopen1.ClientID%>").click();
                      }
                      else if (mode == 2) {
                          document.getElementById("<%=btnFloatReopen1.ClientID%>").click();
                      }
                          return false;
                      }

                      else {
                          return false;
                      }
                  });
                  return false;
              }


          </script> 
<button id="BtnPopup" type="button" style="display:none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>
<button id="BtnPopupCstCntr" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModalCstCntr">Open Modal</button>
<button id="Button1" type="button" style="display: none" class="btn btn-primary" data-dismiss="modal"></button>
        <!-- Modal -->
    <%--  //EVM-0027 12-04--%>
  <div class="modal fade" id="myModal" role="dialog" data-backdrop="static">
     <%-- END--%>
    <div class="modal-dialog mod2 mo3" role="document">
    
      <!-- Modal content-->
      <div class="modal-content">
          <div class="modal-header">
              <button type="button" class="close"  onclick="return CloseModalPurchase()" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
              </button>
              <h2 class="modal-title mod1 flt_l"><i class="fa fa-balance-scale"></i>Sales/Debit Note Settlement
</h2>
          </div>

     <div class="modal-body md_bd1 mdl_mx_h">

      <div class="al-box war" id="lblErrMsgCancelReason"> Please fill this out</div>

        <h4 id="PurchaseName" style="display:none;" class="modal-title"></h4>
           <table id="TableAddQstn" class="table table-bordered">
            <thead class="thead1">
              <tr>
                <th style="display:none;" class="th_b7 td1">Id
                </th>
               <th class="th_b8 td1">Bill#
                </th>
                <th class="th_b1">Bill Date
                </th>
                <th class="th_b8 tr_r">Amount <span class="cur_ic"></span>
                </th>
                <th class="th_b11">Settlement Amount <span class="cur_ic"></span>
                </th>
                <th class="th_b6">Settlement
                </th>
                <th class="th_b9 tr_l">Debit Note <span class="cur_ic"></span>
                </th>
                <th class="th_b11">Settlement Amount <span class="cur_ic"></span>
                </th>
              </tr>
            </thead>
           <tbody id="DivPopUpSales">
          </tbody>
       </table>

          <%--<div class="clearfix"></div>
            <div class="devider"></div>
            <div class="col-md-12 col_mar">
                <div class="box6 tr_r">
                    <label for="email" class="fg2_la1 tt_am am1">Net Amount<span class="spn1"></span>:</label>
                </div>
                <div class="box6 flt_r">
                    <label id="LedgerAmtInModalPurchse" for="example-text-input" class="col-md-1 col-form-label" style="width: 27%; display: none;"><span></span></label>
                    <label class="col-md-1 col-form-label" style="padding-left: 0; text-align: left;" id="CurrencyAb"></label>
                    <span id="lblLdgrAmt" class="tt_am am1 tt_al"></span>
                </div>
            </div>--%>

        </div>

          <div class="modal-footer">
               <div class="col-md-12">
          <div class="col-md-3 flt_r tr_l">
           <label class="fg2_la1 tt_am am12 tr_l">SETTLEMENT</label></div>

      <div class="col-md-12">
        <div class="col-md-10">
        <label class="fg2_la1 tt_am am1 tr_r">Receipt Amount<span class="spn1"></span>:</label></div>
          <label id="LedgerAmtInModalPurchse" style="display: none;"><span></span></label>
        <div class="col-md-2" ><span id="lblLdgrAmt" class="tt_am am1_n tr_r" ></span></div>
      </div>

      <div class="col-md-12">
        <div class="col-md-10">
        <label class="fg2_la1 tt_am am1 tr_r">Settled Amount<span class="spn1"></span>:</label></div>
          <label id="lblOpBalance" style="display: none;"><span></span></label>
           <label id="lblSetle" style="display: none;"><span></span></label>
           <label id="lblCredit" style="display: none;"><span></span></label>
        <div class="col-md-2"><span id="lblSetleAmt" class="tt_am am1_n tr_r" ></span></div>
      </div>

      <div class="col-md-12">
        <div class="col-md-10">
        <label class="fg2_la1 tt_am am1 tr_r">Balance<span class="spn1"></span>:</label></div>
        <div class="col-md-2"><span id="lblBlncAmt" class="tt_am am1_n tr_r" ></span></div>
      </div>
      </div>

      <div class="clearfix"></div>
      <div class="devider"></div>

              <button id="btnImportSales" type="button" class="btn btn-success" onclick="ButtnFillClickSales(0);">Submit</button>
              <button id="BttnTemp" type="button" style="display: none" class="btn btn-primary" data-dismiss="modal"></button>
               <button type="button" class="btn btn-danger" data-dismiss="modal" onclick="clearData();">Cancel</button><%--evm 0044--%>
          </div>

      </div>    
    </div>
  </div>      
         
         <div id="CostCenterModal" ></div>        
                                
           
   <!---fade in div for reminder_closed--->

<div class="popup-flex" >
<div id="popup-wrapper" class="popup-container" >
  <div class="popup-content" >
    <!-- <span>&times;</span> -->
    <p>
     <div class="col-md-12">
      <h3>Recurring</h3>
        <div class="col-md-6">
          <h5 class="h5_remind">&nbsp;</h5>
          <select class="form-control fg2_inp1 fg_chs1" id="ddlRecurPeriod" runat="server" onchange="return ChangeRecurPeriod();">
            <option value="1">Daily</option>
            <option value="2">Monthly</option>
            <option value="3">Bimonthly</option>
            <option value="4">Half Yearly</option>
            <option value="5">Yearly</option>
          </select> 
        </div>
        <div class="col-md-6">
          <h5 class="h5_remind">REMINDER (Days)</h5>
          <div class="input-group number-spinner">
            <span class="input-group-btn data-dwn">
              <button class="btn btn-default btn-info blu_spn" data-dir="dwn" onclick="return false;" id="btnRecurMinus" runat="server"><span class="fa fa-minus"></span></button>
            </span>
            <input type="text" class="form-control text-center" value="0" min="0" max="1" id="txtRemindDays" onchange="return ChangeRecurAmnt();" runat="server" maxlength="3" onkeypress="return isNumberAmount(event)" onkeydown="return isNumberAmount(event)">
            <span class="input-group-btn data-up">
              <button class="btn btn-default btn-info blu_spn" data-dir="up" onclick="return false;" id="btnRecurPlus" runat="server"><span class="fa fa-plus"></span></button>
            </span>
          </div>
        </div>
      </div><!----col-md_12_closed---->
    </p>
    <div class="mod-foot pull-right">
        <button type="button" class="btn btn-success" onclick="return RecurrSave();" id="btnRecurrSave" runat="server">Save</button>
        <button type="button" class="btn btn-danger" id="close">Cancel</button>
      </div>
   <!--  <button type="button" class="btn btn-danger pull-right">Cancel</button> -->
  </div>
</div>
    </div>
<!--------script section_started----------> 
                           

             <script>
                 function CloseModal(x) {
                     ezBSAlert({
                         type: "confirm",
                         messageText: "Are you sure you want to close?",
                         alertType: "info"
                     }).done(function (e) {
                         if (e == true) {
                             document.getElementById("BttnCost" + x).click();
                             return false;
                         }
                         else {
                             return false;
                         }
                     });
                     return false;
                 }
                 function CloseModalPurchase() {
                     ezBSAlert({
                         type: "confirm",
                         messageText: "Are you sure you want to close?",
                         alertType: "info"
                     }).done(function (e) {
                         if (e == true) {
                             //   $noCon('btnImportSales').prop("data-dismiss", "modal");
                             document.getElementById("BttnTemp").click();

                             return false;
                         }
                         else {
                             return false;
                         }
                     });
                     return false;
                 }
                 $noCon('#cphMain_txtFromdate').datepicker({
                     autoclose: true,
                     format: 'dd-mm-yyyy',
                     // startDate: new Date(),
                     timepicker: false
                 });
                 $noCon('#cphMain_txtTodate').datepicker({
                     autoclose: true,
                     format: 'dd-mm-yyyy',
                     startDate: new Date(),
                     timepicker: false
                 });



       </script>

                                         <script>
                                             var $noCon4 = jQuery.noConflict();
                                             function show() {
                                                 //DateCheck();
                                                 IncrmntConfrmCounter();
                                                 //  DateCurrentValue();
                                                 // $noCon4("#txtDateFrom").datetimepicker({ format: 'dd-mm-yyyy' })
                                                 $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#cphMain_txtFromdate').val().trim());


                                             }


                                             function insert() {

                                                 IncrmntConfrmCounter();
                                                 $noCon4('#cphMain_txtFromdate').val($noCon4('#cphMain_Hiddentxtefctvedate').val().trim());

                                             }
                                             function insertTO() {

                                                 IncrmntConfrmCounter();
                                                 $noCon4('#cphMain_txtFromdate').val($noCon4('#cphMain_HiddentxtefctvedateTo').val().trim());

                                             }
                                                                             </script>


        
   
  
  <div style="clear:both"></div>
    <script type="text/javascript">

        function clearValue() {
            document.getElementById("<%=hiddenLedgerddl.ClientID%>").value = "";
              document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
             document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
             document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";

             return true;
        }


        function PrintValue() {

            var UsrName = '<%= Session["USERFULLNAME"] %>';
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            var strId = document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value;
            var crncyAbrvt = document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
            var crncyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

            if (strCorpID != "" && strCorpID != null && strOrgIdID != "" && strOrgIdID != null && strUserID != null && strUserID != "" && strId != "" && crncyAbrvt != "") {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Receipt_Account.aspx/printReceiptDetails",
                    data: '{strId: "' + strId + '",strUserID: "' + strUserID + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",crncyAbrvt: "' + crncyAbrvt + '",crncyId: "' + crncyId + '",UsrName: "' + UsrName + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            window.open(data.d, '_blank');
                        }
                        else {
                            PrintVersnError();
                        }
                    }
                });
            }
            else {
                window.location = '/Security/Login.aspx';
            }
            return false;


         //   document.getElementById("<%=hiddenLedgerddl.ClientID%>").value = "";
          //  document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
          //  document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
          //  document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";

          //  return true;
          
        }
        function ConfirmAlert() {
            if (ValidateReceiptAccnt() == true) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm this receipt?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        CheckSaleSettlements();
                    }
                    else {
                        return false;
                    }

                });
                return false;
            }
            else {
                return false;

            }
        }

        function Confirm() {
            document.getElementById("<%=btnConfirm1.ClientID%>").click();
        }

        function CheckSaleSettlements() {//EVM-0020

            var Settld = 0;
            var SettldExceed = 0;
            var SuccessSts = "successConfirm";
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';

            addRowtable = document.getElementById("tableGrp");
            for (var i = 1; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);

                var PurchaseInfo = document.getElementById("tdSalesDtls" + xLoop).value;
                if (PurchaseInfo != "" && PurchaseInfo != null && PurchaseInfo != "null") {

                    var strOrgIdID = '<%=Session["ORGID"]%>';
                    var strCorpID = '<%=Session["CORPOFFICEID"]%>';

                    var TotalAmnt = 0;
                    var splitrow = PurchaseInfo.split("$");
                    for (var Cst = 0; Cst < splitrow.length; Cst++) {
                        var splitEach = splitrow[Cst].split("%");
                        if (splitEach[0] != "") {
                            var PrchsId = splitEach[0];
                            TotalAmnt = DuplicateSettlementChange(PrchsId, xLoop);
                            var PrchsAmnt = 0;
                            if (splitEach[1] != "") {
                                PrchsAmnt = splitEach[1].replace(/\,/g, '');
                            }
                            var DebitAmnt = 0;
                            if (splitEach[5] != "") {
                                DebitAmnt = splitEach[5].replace(/\,/g, '');
                            }
                            TotalAmnt = parseFloat(TotalAmnt) + parseFloat(PrchsAmnt) + parseFloat(DebitAmnt);

                            $.ajax({
                                type: "POST",
                                async: false,
                                contentType: "application/json; charset=utf-8",
                                url: "fms_Receipt_Account.aspx/CheckSaleSettlement",
                                data: '{strSalePurchaseDtls: "' + PurchaseInfo + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",strxLoop: "' + xLoop + '",strTotalAmnt: "' + TotalAmnt + '",strPurchaseId: "' + PrchsId + '"}',
                                dataType: "json",
                                success: function (data) {

                                    if (data.d != "") {
                                        SuccessSts = data.d;
                                    }

                                    if (SuccessSts == "PrchsAmountExceeded") {
                                        SettldExceed++;
                                    }

                                }
                            });

                        }
                    }

                }

                if (parseInt(SettldExceed) > 0) {
                    PurchaseAmountExceeded();
                    return false;
                }
                else {

                    if (SuccessSts == "successConfirm") {
                        if (Settld == 0) {
                            continue;
                        }
                        else {
                            SuccessSts = "SalesAmtFullySettld";
                        }
                    }
                    else if (SuccessSts == "SalesAmtFullySettld") {
                        Settld++;
                        continue;
                    }
                }
            }

            if (SuccessSts == "successConfirm") {
                Confirm();
                return false;
            }
            else if (SuccessSts == "SalesAmtFullySettld") {

                ezBSAlert({
                    type: "confirm",
                    messageText: "One or more sale amount(s) is fully settled. Do you want to confirm by deleting added sales?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {

                        Confirm();
                        return false;
                    }
                    else {
                        return false;
                    }
                });

            }
            else if (SuccessSts == "SalesAmountExceeded") {
                SalesAmountExceeded();
            }
            else if (SuccessSts == 'failed') {
                SuccessErrorReoen();
            }
        }


    function SuccessCancel() {
        $noCon("#divWarning").html("Receipt details already cancelled.");
        $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
        });
       
        return false;
    }
    function SuccessNotConfirmation() {
        $noCon("#divWarning").html("Receipt details already confirmed.");
        $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
        });
       
        return false;
    }
    function SalesAmountExceeded() {
        $noCon("#divWarning").html("Receipt amount should not be greater than sales amount.");
        $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
        });

        return false;
    }
    function SalesAmountFullySettld() {
        $noCon("#divWarning").html("Sale amount is already settled.");
        $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }

    function SuccessConfirmation() {
        $noCon("#success-alert").html("Receipt Confirmed successfully.");
        $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        
        return false;
    }
        //0039
    function AlreadyReopened() {
    
        $noCon("#divWarning").html("Receipt details reopened already");
        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
        //end
    function SuccessReopMsg() {

        $noCon("#success-alert").html("Receipt details reopened successfully");
        $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function isTagEnter(evt) {
        IncrmntConfrmCounter();

        evt = (evt) ? evt : window.event;
        var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

        var charCode = (evt.which) ? evt.which : evt.keyCode;
        var ret = true;
        if (charCode == 60 || charCode == 62) {
            ret = false;
        }
        return ret;
    }
    function RemoveTag() {


        var NameWithoutReplace = document.getElementById("<%=txtDesc.ClientID%>").value;

            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDesc.ClientID%>").value = replaceText2;


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
             else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40 || keyCodes == 110) {
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
       var $aa = jQuery.noConflict();
       $aa(function () {
           $aa.widget("custom.combobox", {
               _create: function () {
                   this.wrapper = $aa("<span>")
                     .addClass("custom-combobox " + $aa(this.element).prop("id"))
                     .insertAfter(this.element);

                   this.element.hide();
                   this._createAutocomplete();
                   // this._createShowAllButton();
               },




               _createAutocomplete: function () {

                   var selected = this.element.children(":selected"),

                     value = selected.val() ? selected.text() : "";
                   var idd = $aa(this.element).prop("id");
                   this.input = $aa("<input>")
                     .appendTo(this.wrapper)
                     .val(value)
                     .attr("title", "")
                     .attr("placeholder", "--SELECT--")
                       //danger custom function here
                  // attr("change","ChangeProduct()")
                       .attr("onkeydown", "return isTag(event);")
                      // .attr("onchange", "return ChangeProduct(" + idd + ");")
                       .attr("tabindex", 7)
                     //.addClass( "custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left" )
                     .addClass("form-control  ui-autocomplete-input " + $aa(this.element).prop("id"))
                     .autocomplete({
                         delay: 0,
                         minLength: 0,

                         select: function (event, ui) {

                         },
                         change: function (event, ui) {

                             ChangeProduct(idd);
                         },

                         source: $aa.proxy(this, "_source")


                     })

                     .tooltip({
                         classes: {
                             "ui-tooltip": "ui-state-highlight"
                         }
                     });

                   this._on(this.input, {
                       autocompleteselect: function (event, ui) {
                           ui.item.option.selected = true;
                           this._trigger("select", event, {
                               item: ui.item.option

                           });

                           $aa(".selector").autocomplete({
                               autoFocus: true
                           });

                       },



                       autocompletechange: "_removeIfInvalid"
                   });

                   //$aa(".combobox_ui_ddlProduct").change(function () {
                   //    alert(this.value);
                   //});


               },



               _source: function (request, response) {
                   var matcher = new RegExp($aa.ui.autocomplete.escapeRegex(request.term), "i");
                   response(this.element.children("option").map(function () {
                       var text = $aa(this).text();
                       if (this.value && (!request.term || matcher.test(text)))
                           return {
                               label: text,
                               value: text,
                               option: this
                           };
                   }));
               },

               _removeIfInvalid: function (event, ui) {

                   // Selected an item, nothing to do
                   if (ui.item) {

                       //  alert(ui.item.label);
                       return;
                   }

                   // Search for a match (case-insensitive)
                   var value = this.input.val(),
                     valueLowerCase = value.toLowerCase(),
                     valid = false;
                   this.element.children("option").each(function () {
                       if ($aa(this).text().toLowerCase() === valueLowerCase) {
                           this.selected = valid = true;
                           return false;
                       }
                   });

                   // Found a match, nothing to do
                   if (valid) {

                       return;
                   }

                   // Remove invalid value
                   this.input
                     .val("")

                   //.attr( "title", value + " didn't match any item" )
                   //.tooltip( "open" );
                   this.element.val("");

                   var selected = this.element.children(":selected"),

                   value = selected.val() ? selected.text() : "";
                   var idd = $aa(this.element).prop("id");
                   // ChangeProduct(idd);
                   //this._delay(function() {
                   //    this.input.tooltip( "close" ).attr( "title", "" );
                   //}, 2500 );
                   this.input.autocomplete("instance").term = "";
               },

               _destroy: function () {
                   this.wrapper.remove();
                   this.element.show();
               }
           });



       });



       $aa(document).ready(function () {

       });
    </script>

    <%--<script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>--%>
   
     <script>
         var $au = jQuery.noConflict();
         $au(function () {
             $au(".ddl").selectToAutocomplete1Letter();
         });
         function DisableEnter(evt) {
             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
             if (keyCodes == 13) {
                 return false;
             }
         }

         function DisableEnterAndComma(evt) {
             DisableEnter(evt);
             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
             if (keyCodes == 188) {
                 return false;
             }
         }


         function curncyChangeFunt() {


             if (document.getElementById("cphMain_ddlCurrency").value != 0) {

                 var ddlcrncyId = document.getElementById("cphMain_ddlCurrency").value;
                 if (document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value == document.getElementById("cphMain_ddlCurrency").value || document.getElementById("cphMain_ddlCurrency").value == "--SELECT CURRENCY--") {

                     document.getElementById("cphMain_divExchangecurency").style.display = "none";
                     document.getElementById("cphMain_divForeXAmt").style.display = "none";

                     // document.getElementById("cphMain_divTotalDefultCrncy").style.display = "none";

                 }
                 else {
                     document.getElementById("cphMain_divExchangecurency").style.display = "block";
                     document.getElementById("cphMain_divForeXAmt").style.display = "block";
                     // document.getElementById("cphMain_divTotalDefultCrncy").style.display = "block";

                 }

                 var exhgAmt = "0";
                 var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                 if (FloatingValue != "") {
                     exhgAmt = parseFloat(exhgAmt).toFixed(FloatingValue);
                 }

                 var corpid = '<%= Session["CORPOFFICEID"] %>';
                 var orgid = '<%= Session["ORGID"] %>';
                 var userid = '<%= Session["USERID"] %>';

                 $noCon.ajax({
                     type: "POST",
                     url: "fms_Receipt_Account.aspx/RedCurencyAbrvtn",
                     data: '{intCrncyId:"' + ddlcrncyId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" }',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (response) {


                         if (response.d != "0") {
                             document.getElementById("cphMain_lblCrncyAbrvtn").innerHTML = response.d;
                             if (document.getElementById("cphMain_divExchangecurency").style.display == "block") {
                                 document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value = response.d;
                                    document.getElementById("<%=txtForexAmt.ClientID%>").value = exhgAmt + " " + response.d;
                                    //   alert(exhgAmt+" "+response.d);
                                }
                                else {

                                }
                                // addRowtable = document.getElementById("TableaddedRows");

                                // var RowCount = addRowtable.rows.length;
                                //alert(RowCount);
                                // BlurValue(RowCount, null);
                            }



                            else {

                            }



                        },
                        failure: function (response) {

                        }


                    });





                }

            }



            function isNumberAmount(evt) {

                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                var charCode = (evt.which) ? evt.which : evt.keyCode;
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
                else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 38 || keyCodes == 40 || keyCodes == 41) {
                    return false;

                }
                if (keyCodes == 46)
                    return true;

                if (keyCodes > 31 && (keyCodes < 48 || keyCodes > 57)) {
                    return false;
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

        function showFromDate() {


            document.getElementById("cphMain_txtdate").style.borderColor = "";
            IncrmntConfrmCounter();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var UsrID = '<%= Session["USERID"] %>';
            var jrnlDate = $('#cphMain_txtdate').val().trim();
            var RcptDate = $('#cphMain_HiddenUpdatedDate').val().trim();
            var RefNum = $('#cphMain_HiddenUpdRefNum').val().trim();
            var ReptID = $('#cphMain_HiddenFieldTaxId').val().trim();
            var AcntPrvsn = document.getElementById("<%=HiddenFieldAcntCloseReopenSts.ClientID%>").value;
            var AuditPrvsn = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;


            if (jrnlDate != "") {



                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Receipt_Account.aspx/CheckAcntCloseSts",
                    data: '{jrnlDate: "' + jrnlDate + '",orgID: "' + orgID + '",corptID: "' + corptID + '",AuditPrvsn: "' + AuditPrvsn + '",AcntPrvsn: "' + AcntPrvsn + '"}',
                    dataType: "json",
                    success: function (data) {

                        if (data.d == "1") {
                            document.getElementById("cphMain_txtdate").style.borderColor = "Red";
                            document.getElementById("cphMain_txtdate").focus();
                            document.getElementById("cphMain_txtdate").value = "";
                            $noCon("#divWarning").html("This action is  denied! Audit is already closed for the selected date.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            return false;
                        }
                        else if (data.d == "2") {
                            document.getElementById("cphMain_txtdate").style.borderColor = "Red";
                            document.getElementById("cphMain_txtdate").focus();
                            document.getElementById("cphMain_txtdate").value = "";
                            $noCon("#divWarning").html("This action is  denied! Account is already closed for the selected date.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            return false;
                        }
                       
                    }
                });
            }


            if (jrnlDate != "" && jrnlDate != document.getElementById("<%=HiddenUpdatedDate.ClientID%>").value && (document.getElementById("<%=HiddenProvisionSts.ClientID%>").value == "Active" || document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value == "1")) {

                
                    if (document.getElementById("<%=HiddenRefAccountCls.ClientID%>").value == "1") {
                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "fms_Receipt_Account.aspx/CheckRefNumber",
                            data: '{jrnlDate: "' + jrnlDate + '",orgID: "' + orgID + '",corptID: "' + corptID + '",UsrID: "' + UsrID + '",RefNum: "' + RefNum + '",ReptID: "' + ReptID + '"}',
                            dataType: "json",
                            success: function (data) {

                                if (data.d != "") {
                                    if (document.getElementById("<%=HiddenRefNum.ClientID%>").value != data.d && RcptDate != "") {
                                        if (document.getElementById("cphMain_TxtRef").value != data.d) {

                                            ezBSAlert({
                                                type: "confirm",
                                                messageText: "This action will change the reference number.Are you sure you want to continue ?",
                                                alertType: "info"
                                            }).done(function (e) {
                                                if (e == true) {
                                                    document.getElementById("cphMain_TxtRef").value = data.d;
                                                    document.getElementById("cphMain_HiddenRefNum").value = data.d;
                                                }
                                                else {
                                                    document.getElementById("cphMain_txtdate").value = $('#cphMain_HiddenUpdatedDate').val()

                                                    return false;
                                                }
                                            });
                                            return false;
                                        }
                                    }
                                    else {
                                        document.getElementById("cphMain_TxtRef").value = data.d;
                                    }
                                }
                            }
                        });
                    }

              //  }
            }
        }






        //newwwwwwwwwwwwwwwwwwwwww

        function suply1(x) {
            document.getElementById("ddlCreditNote" + x).value = "0";
            document.getElementById("txtCreNoteStlmntAmmnt" + x).value = "";
            //document.getElementById("creNoteBalaF" + x).innerHTML = "";

            if (document.getElementById("cbx_sly" + x).checked == true) {
                document.getElementById("ddlCreditNote" + x).disabled = false;
                document.getElementById("txtCreNoteStlmntAmmnt" + x).disabled = false;
                //document.getElementById("creNoteBala" + x).innerHTML = document.getElementById("SlsBlnc" + x).innerHTML;
            } else {
                document.getElementById("ddlCreditNote" + x).disabled = true;
                document.getElementById("txtCreNoteStlmntAmmnt" + x).disabled = true;
                document.getElementById("creNoteBala" + x).innerHTML = "";              

            }
            loadSettleAmount(x);//evm 0044

            var purchAmt = document.getElementById("txtCreNoteStlmntAmmnt" + x).value;
            purchAmt = purchAmt.replace(/\,/g, '');
            if (purchAmt == "") {
                purchAmt = 0;
            }

            var purchAmt1 = document.getElementById("txtPurchaseAmt" + x).value;
            purchAmt1 = purchAmt1.replace(/\,/g, '');
            if (purchAmt1 == "") {
                purchAmt1 = 0;
            }

            var saleamt = document.getElementById("tdAmnt" + x).innerHTML;
            saleamt = saleamt.replace(/\,/g, '');

            var BlncAmt = parseFloat(saleamt) - (parseFloat(purchAmt) + parseFloat(purchAmt1));
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                if (FloatingValue != "") {
                    BlncAmt = BlncAmt.toFixed(FloatingValue)
                }
                addCommasSummry(BlncAmt);
                document.getElementById("SlsBlnc" + x).innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                //document.getElementById("creNoteBala" + x).innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
        }
        function CreditNoteStlmtAmntChange(x) {

            if (document.getElementById("ddlCreditNote" + x).value == "0") {
                document.getElementById("txtCreNoteStlmntAmmnt" + x).value = "";
            }
            else {

                var ret = true;
                AmountChecking("txtCreNoteStlmntAmmnt" + x);

                var tdAmnt = document.getElementById("tdAmnt" + x).innerHTML;
                var rcptAmt1 = document.getElementById("txtPurchaseAmt" + x).value;
                if (rcptAmt1 == "") {
                    rcptAmt1 = "0";
                }
                rcptAmt1 = rcptAmt1.replace(/\,/g, '');
                var SalesAmt1 = parseFloat(rcptAmt1);
                tdAmnt = tdAmnt.replace(/\,/g, '');



                var tdAmnt2 = document.getElementById("tdCredNoteAmnt" + x).innerHTML;
                var rcptAmt2 = document.getElementById("txtCreNoteStlmntAmmnt" + x).value;
                if (rcptAmt2 == "") {
                    rcptAmt2 = "0";
                }
                rcptAmt2 = rcptAmt2.replace(/\,/g, '');
                var SalesAmt2 = parseFloat(rcptAmt2);
                tdAmnt2 = tdAmnt2.replace(/\,/g, '');


                var CreNoteid = document.getElementById("ddlCreditNote" + x).value;
                var purchaseAmtd = 0;
                var addRowtable = document.getElementById("TableAddQstn");
                var j = 1;
                if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                    j++;
                }
                for (var i = j; i < addRowtable.rows.length; i++) {//2nd row onwards
                    var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
                    if (CreNoteid == document.getElementById("ddlCreditNote" + P_Id).value && x != P_Id) {
                        var SalesAmt2d = 0;
                        var rcptAmt2d = document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).value;
                        if (rcptAmt2d == "") {
                            rcptAmt2d = "0";
                        }
                        rcptAmt2d = rcptAmt2d.replace(/\,/g, '');
                        SalesAmt2d = parseFloat(rcptAmt2d);

                        purchaseAmtd = parseFloat(purchaseAmtd) + parseFloat(rcptAmt2d);
                    }
                }
                tdAmnt2 = parseFloat(tdAmnt2) - parseFloat(purchaseAmtd);
                document.getElementById("txtCreNoteStlmntAmmnt" + x).style.borderColor = "";


                if (parseFloat(SalesAmt2) > parseFloat(tdAmnt2)) {
                    clearData();
                    document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the creditnote amount";
                    $("div.war").fadeIn(200).delay(500).fadeOut(400);
                    document.getElementById("txtCreNoteStlmntAmmnt" + x).style.borderColor = "Red";
                    document.getElementById("txtCreNoteStlmntAmmnt" + x).focus();
                    document.getElementById("txtCreNoteStlmntAmmnt" + x).value = "";
                    ret = false;
                }
                else if ((parseFloat(SalesAmt2) + parseFloat(SalesAmt1)) > parseFloat(tdAmnt)) {
                    clearData();
                    document.getElementById("lblErrMsgCancelReason").innerHTML = "Sum of settlement amount and creditnote settlement amount should be less than the sale amount";
                    $("div.war").fadeIn(200).delay(500).fadeOut(400);
                    document.getElementById("txtCreNoteStlmntAmmnt" + x).style.borderColor = "Red";
                    document.getElementById("txtCreNoteStlmntAmmnt" + x).focus();
                    document.getElementById("txtCreNoteStlmntAmmnt" + x).value = "";
                    ret = false;
                }


                var purchaseAmt = 0;
                var ledgerAmt = 0;
                var addRowtable = document.getElementById("TableAddQstn");
                var j = 1;
                if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                    j++;
                }
                for (var i = j; i < addRowtable.rows.length; i++) {//2nd row onwards
                    var P_Id = (addRowtable.rows[i].cells[0].innerHTML);

                    var SalesAmt = 0;
                    var rcptAmt = document.getElementById("txtPurchaseAmt" + P_Id).value;
                    if (rcptAmt == "") {
                        rcptAmt = "0";
                    }
                    rcptAmt = rcptAmt.replace(/\,/g, '');
                    SalesAmt = parseFloat(rcptAmt);



                    var SalesAmt2 = 0;
                    var rcptAmt2 = document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).value;
                    if (rcptAmt2 == "") {
                        rcptAmt2 = "0";
                    }
                    rcptAmt2 = rcptAmt2.replace(/\,/g, '');
                    SalesAmt2 = parseFloat(rcptAmt2);


                    purchaseAmt = parseFloat(purchaseAmt) + parseFloat(rcptAmt) + parseFloat(rcptAmt2);
                    var ledgerAmtwithoutarr = document.getElementById("LedgerAmtInModalPurchse").innerText;

                    var TxtTotalarr = ledgerAmtwithoutarr.split(" ");
                    if (TxtTotalarr[0] != "") {
                        ledgerAmt = TxtTotalarr[0];
                    }
                    ledgerAmt = ledgerAmt.replace(/\,/g, '');
                    var actLedgerAmt = document.getElementById("lblLdgrAmt").innerText.split(" ");//evm 0044 07/02
                    actLedgerAmt = actLedgerAmt[0];//evm 0044 07/02

                    if (parseFloat(purchaseAmt) > parseFloat(ledgerAmt)) {
                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                        purchaseAmt = parseFloat(purchaseAmt);
                        if (FloatingValue != "") {
                            purchaseAmt = purchaseAmt.toFixed(FloatingValue);
                        }
                        addCommasSummry(purchaseAmt);
                    }
                    else if (parseFloat(purchaseAmt) <= parseFloat(ledgerAmt)) {
                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                        actLedgerAmt = parseFloat(actLedgerAmt);
                        if (FloatingValue != "") {
                            actLedgerAmt = actLedgerAmt.toFixed(FloatingValue);
                        }
                        addCommasSummry(actLedgerAmt);
                    }

                    if (parseFloat(purchaseAmt) > parseFloat(ledgerAmt)) {
                        clearData();
                        document.getElementById("lblErrMsgCancelReason").innerHTML = "Settlement total amount should be less than the receipt amount";
                        $("div.war").fadeIn(200).delay(500).fadeOut(400);
                        if (document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).value != "") {
                            document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).style.borderColor = "Red";
                            document.getElementById("txtCreNoteStlmntAmmnt" + P_Id).focus();
                        }
                        ret = false;
                    }
                }

               
                if (ret == true) {

                    var purchAmt = document.getElementById("txtCreNoteStlmntAmmnt" + x).value;
                    purchAmt = purchAmt.replace(/\,/g, '');
                    if (purchAmt == "") {
                        purchAmt = 0;
                    }

                    var purchAmt1 = document.getElementById("txtPurchaseAmt" + x).value;
                    purchAmt1 = purchAmt1.replace(/\,/g, '');
                    if (purchAmt1 == "") {
                        purchAmt1 = 0;
                    }



                    var saleamt = document.getElementById("tdAmnt" + x).innerHTML;
                    saleamt = saleamt.replace(/\,/g, '');
                    var BlncAmt = parseFloat(saleamt) - (parseFloat(purchAmt) + parseFloat(purchAmt1));
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        BlncAmt = BlncAmt.toFixed(FloatingValue)
                    }
                    addCommasSummry(BlncAmt);
                    //document.getElementById("creNoteBala" + x).innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                    document.getElementById("SlsBlnc" + x).innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;

                    addCommas("txtCreNoteStlmntAmmnt" + x);
                }
                else {
                    document.getElementById("txtCreNoteStlmntAmmnt" + x).style.borderColor = "Red";
                    document.getElementById("txtCreNoteStlmntAmmnt" + x).focus();
                    document.getElementById("txtCreNoteStlmntAmmnt" + x).value = "";


                    //document.getElementById("creNoteBala" + x).innerHTML = document.getElementById("SlsBlnc" + x).innerHTML;


                }
                //evm 0044
                loadSettleAmount(x);

                return ret;


            }
        }

        function ddlCreditNoteChange(x) {
            var CreNoteid = document.getElementById("ddlCreditNote" + x).value;
            document.getElementById("txtCreNoteStlmntAmmnt" + x).value = "";
            document.getElementById("tdCredNoteAmnt" + x).innerHTML = "";
            if (CreNoteid != "") {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Receipt_Account.aspx/ReadCreditNoteDtls",
                    data: '{CreNoteid: "' + CreNoteid + '"}',
                    dataType: "json",
                    success: function (data) {

                        //document.getElementById("creNoteBalaF" + x).innerHTML = data.d[0];
                        //document.getElementById("tdCredNoteAmnt" + x).innerHTML = data.d[0];
                        document.getElementById("creNoteBala" + x).innerHTML = data.d[1];
                    }
                });
            }
            if (CreNoteid != "0") {
                if (document.getElementById("creNoteBalaF" + x).innerHTML != "") {
                    var bal = document.getElementById("creNoteBalaF" + x).innerHTML;
                    bal = parseFloat(bal);

                    document.getElementById("tdCredNoteAmnt" + x).innerHTML = bal;

                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        bal = bal.toFixed(FloatingValue)
                    }
                    addCommasSummry(bal);
                    document.getElementById("creNoteBalaF" + x).innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
                }
            }
            var purchAmt = document.getElementById("txtCreNoteStlmntAmmnt" + x).value;
            purchAmt = purchAmt.replace(/\,/g, '');
            if (purchAmt == "") {
                purchAmt = 0;
            }

            var purchAmt1 = document.getElementById("txtPurchaseAmt" + x).value;
            purchAmt1 = purchAmt1.replace(/\,/g, '');
            if (purchAmt1 == "") {
                purchAmt1 = 0;
            }



            var saleamt = document.getElementById("tdAmnt" + x).innerHTML;
            saleamt = saleamt.replace(/\,/g, '');
            var BlncAmt = parseFloat(saleamt) - (parseFloat(purchAmt) + parseFloat(purchAmt1));
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            if (FloatingValue != "") {
                BlncAmt = BlncAmt.toFixed(FloatingValue)
            }
            addCommasSummry(BlncAmt);
            //document.getElementById("creNoteBala" + x).innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
            document.getElementById("SlsBlnc" + x).innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;
            loadSettleAmount(x);//evm 0044 08/02
        }
       
    </script>
    <!----spinner_script----started---->
<script type="text/javascript">

    var RecuCounter = 0;

    if (document.getElementById("<%=hiddenPostdated.ClientID%>").value != "1" && document.getElementById("<%=HiddenRecurring.ClientID%>").value == "1" && document.getElementById("<%=HiddenView.ClientID%>").value != "1") {

        var popup = document.getElementById('popup-wrapper');
        var btn = document.getElementById("popup-btn");
        var span = document.getElementById("close");
        btn.onclick = function () {
            RecuCounter = 0;
            popup.classList.add('show');
            document.getElementById("cphMain_ddlRecurPeriod").focus();
            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                document.getElementById("cphMain_btnRecurMinus").disabled = false;
                document.getElementById("cphMain_btnRecurPlus").disabled = false;
            }
            document.getElementById("cphMain_txtRemindDays").style.borderColor = "";
            if (document.getElementById("<%=HiddenFieldRecurrencyPeriod.ClientID%>").value != "") {
                document.getElementById("cphMain_ddlRecurPeriod").value = document.getElementById("<%=HiddenFieldRecurrencyPeriod.ClientID%>").value;
                document.getElementById("cphMain_txtRemindDays").value = document.getElementById("<%=HiddenFieldRemindDays.ClientID%>").value;

                var RecurPeriod = document.getElementById("cphMain_ddlRecurPeriod").value;
                var DaysMax = 1;
                if (RecurPeriod == "2") {
                    DaysMax = 30;
                }
                else if (RecurPeriod == "3") {
                    DaysMax = 60;
                }
                else if (RecurPeriod == "4") {
                    DaysMax = 182;
                }
                else if (RecurPeriod == "5") {
                    DaysMax = 365;
                }
                var requester = document.getElementById("cphMain_txtRemindDays");
                requester.setAttribute('max', DaysMax);
            }
            else {
                document.getElementById("cphMain_ddlRecurPeriod").value = "1";
                document.getElementById("cphMain_txtRemindDays").value = "0";
            }
        }

        span.onclick = function () {
            if (RecuCounter > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to cancel without save?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        popup.classList.remove('show');
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                popup.classList.remove('show');
                return false;
            }

        }

        //window.onclick = function (event) {
        //    if (event.target == popup) {
        //        popup.classList.remove('show');
        //    }
        //}
    }

    $(function () {
        var action;
        $(".number-spinner button").mousedown(function () {
           
            btn = $(this);
            input = btn.closest('.number-spinner').find('input');
            btn.closest('.number-spinner').find('button').prop("disabled", false);

            if (btn.attr('data-dir') == 'up') {
                action = setInterval(function () {
                    if (input.attr('max') == undefined || parseInt(input.val()) < parseInt(input.attr('max'))) {
                        input.val(parseInt(input.val()) + 1);
                        RecuCounter++;
                    } else {
                        btn.prop("disabled", true);
                        clearInterval(action);
                    }
                }, 50);
            } else {
                action = setInterval(function () {
                    if (input.attr('min') == undefined || parseInt(input.val()) > parseInt(input.attr('min'))) {
                        input.val(parseInt(input.val()) - 1);
                        RecuCounter++;
                    } else {
                        btn.prop("disabled", true);
                        clearInterval(action);
                    }
                }, 50);
            }
        }).mouseup(function () {
            clearInterval(action);          
        });
        return false;
    });
</script>
<!----spinner_script----closed---->


<!-----toogle script_for_reccuring section--->
<script>
    $(document).ready(function () {
        $(".req1").click(function () {
            $(".slow").toggle(600);
        });
    });

    function ChangeRecurPeriod() {

        RecuCounter++;
        document.getElementById("cphMain_btnRecurMinus").disabled = false;
        document.getElementById("cphMain_btnRecurPlus").disabled = false;

        document.getElementById("cphMain_txtRemindDays").style.borderColor = "";
        document.getElementById("cphMain_txtRemindDays").value = "0";
        var RecurPeriod = document.getElementById("cphMain_ddlRecurPeriod").value;
        var DaysMax = 1;
        if (RecurPeriod == "2") {
            DaysMax = 30;
        }
        else if (RecurPeriod == "3") {
            DaysMax = 60;
        }
        else if (RecurPeriod == "4") {
            DaysMax = 182;
        }
        else if (RecurPeriod == "5") {
            DaysMax = 365;
        }
        var requester = document.getElementById("cphMain_txtRemindDays");
        requester.setAttribute('max', DaysMax);

    }
    function ChangeRecurAmnt() {
        RecuCounter++;
        document.getElementById("cphMain_txtRemindDays").style.borderColor = "";
        var RemnDays=document.getElementById("cphMain_txtRemindDays").value.trim();
        var RecurPeriod = document.getElementById("cphMain_ddlRecurPeriod").value;
        var DaysMax = 1;
        if (RecurPeriod == "2") {
            DaysMax = 30;
        }
        else if (RecurPeriod == "3") {
            DaysMax = 60;
        }
        else if (RecurPeriod == "4") {
            DaysMax = 182;
        }
        else if (RecurPeriod == "5") {
            DaysMax = 365;
        }
        if (RemnDays != "") {
            RemnDays = parseInt(RemnDays);
            if (RemnDays > DaysMax) {
                //document.getElementById("cphMain_txtRemindDays").style.borderColor = "red";
                document.getElementById("cphMain_txtRemindDays").value = DaysMax;
            }
        }
    }
    function RecurrSave() {
        document.getElementById("cphMain_txtRemindDays").style.borderColor = "";
        var remindDays=document.getElementById("cphMain_txtRemindDays").value.trim();
        if (remindDays == "") {
            document.getElementById("cphMain_txtRemindDays").style.borderColor = "red";
            document.getElementById("cphMain_txtRemindDays").focus();
        }
        else {
            var popup = document.getElementById('popup-wrapper');
            popup.classList.remove('show');

            document.getElementById("<%=HiddenFieldRecurrencyPeriod.ClientID%>").value = document.getElementById("cphMain_ddlRecurPeriod").value;
            document.getElementById("<%=HiddenFieldRemindDays.ClientID%>").value = remindDays;
        }
        return false;
    }
    function PassSavedValue(Status) {
        if (window.opener != null && !window.opener.closed) {

            window.opener.GetValueFromChild(Status);
        }
        if (Status == "1") {
            window.close();
        }
    }
</script>
</asp:Content>