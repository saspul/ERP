<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Customer_Master.aspx.cs" Inherits="Master_gen_Customer_Master_gen_Customer_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/hcm_ns.css" rel="stylesheet" />
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
        <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
     <script>
         var $au = jQuery.noConflict();

         $au(function () {
             $au('#cphMain_ddlAccountGrp').selectToAutocomplete1Letter();
             $au('#cphMain_ddlCustomerType').selectToAutocomplete1Letter();
             $au('#cphMain_ddlCustomerGroup').selectToAutocomplete1Letter();
             $au('#cphMain_ddlLedger').selectToAutocomplete1Letter();
             $au('#cphMain_ddlCC').selectToAutocomplete1Letter();
             $au('#cphMain_ddlPriceTerm').selectToAutocomplete1Letter();
             $au('#cphMain_ddlPaymentTerm').selectToAutocomplete1Letter();
             $au('#cphMain_ddlDeliveryTerm').selectToAutocomplete1Letter();
             $au('#cphMain_ddlCountry').selectToAutocomplete1Letter();
             $au('#cphMain_ddlState').selectToAutocomplete1Letter();
             $au('#cphMain_ddlCity').selectToAutocomplete1Letter();
         });

        </script>
    <script>
        var $a = jQuery.noConflict();
        $a(function()
        {
           
         if ($('#cphMain_cbxLedgerSts').is(':checked')) {
             $("#asg").children().attr("disabled", false);
         }
        else {
                $("#asg").children().attr("disabled", "disabled");
            $("#costg").children().attr("disabled", "disabled");
        }
        });
        var $b = jQuery.noConflict();
        $b(function () {
            if (document.getElementById("cphMain_cbxLedgerSts").checked == true) {
                if (document.getElementById("cphMain_chkSubLedger").checked == true) {
                    document.getElementById("cphMain_ddlLedger").disabled = false;
                    $("#divddlLedger").children().attr("disabled", false);
                }

                else {
                    $("#divddlLedger").children().attr("disabled", "disabled");

                    $('input.Achead').attr("disabled", "disabled");
                    document.getElementById("cphMain_ddlLedger").disabled = true;
                    $('input.acgrp').attr("disabled", false);
                }
            }
        }
            );
        var $c = jQuery.noConflict();
        
        $c(function () {
           
                if ($('#cphMain_cbxCsCntrSts').is(':checked')) {
                    $("#costg").children().attr("disabled", false);
                }
                else {
                    $("#costg").children().attr("disabled", "disabled");
                }
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
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {


            //AutoCompleteAll();

            if (document.getElementById("cphMain_lblEntry").innerText == "EDIT CUSTOMER MASTER") {
                $(".edit").css("display", "block");
            }
            if (document.getElementById("cphMain_lblEntry").innerText != "ADD CUSTOMER MASTER") {
                $(".add").css("display", "none");
            }

        });
    </script>
   
      <%-- 005 start--%>
           <script>
               function SuccessConfirmation() {
                   $("#success-alert").html("Customer details inserted successfully.");
                   $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
                   });
               }
               function SuccessUpdation() {
                   $("#success-alert").html("Customer details updated successfully.");
                   $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
                   });
               }
               function HideLoading() {
                   document.getElementById('divLoading').style.display = "";
               }
               function ErrorMsg() {
                   $("#divWarning").html("Some error occured.Please review entered information !");
                   $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                   });
               }
               function addCommas(nStr) {

                   // alert(nStr);

                   nStr = nStr.replace(/,/g, "");
                   nStr = nStr.slice(0, 10);
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
                       //alert(x1);
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
                       document.getElementById('cphMain_txtCreditLimit').value = x1;

                   else
                       document.getElementById('cphMain_txtCreditLimit').value = x1 + "." + x2;


                   //AutoCompleteAll();

               }




               function addCommasOpenBlnc(nStr) {

                   nStr = nStr.replace(/,/g, "");
                   nStr = nStr.slice(0, 10);
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
                       //alert(x1);
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
                       document.getElementById('cphMain_txtOpenBalanceDeb').value = x1;

                   else
                       document.getElementById('cphMain_txtOpenBalanceDeb').value = x1 + "." + x2;
                   //AutoCompleteAll();
               }

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
                            window.location.href = "gen_Customer_MasterList.aspx";
                            return false;
                        }
                        else {
                            return false;
                        }
                    });
                    return false;
                }
                else {
                    window.location.href = "gen_Customer_MasterList.aspx";

                }
                return false;
            }
            //stop-0006
            function AlertClearAll() {

                if (confirmbox > 0) {

                    ezBSAlert({
                        type: "confirm",
                        messageText: "Do you want to clear all the data from this page?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            window.location.href = "gen_Customer_Master.aspx";
                            return false;
                        }
                        else {
                            return false;
                        }
                    });
                    return false;
                }
                else {
                    window.location.href = "gen_Customer_Master.aspx";
                    return false;
                }
                return false;
            }

    </script>
    

    <script type="text/javascript">


        function DuplicationLedgrCodeMsg() {

            document.getElementById("<%=txtLedgrCode.ClientID%>").style.borderColor = "Red";
            $("#divWarning").html("Duplication Error!.Ledger Code Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

        }
        function SundryDebtorSelect() {
            $("#divWarning").html("Please define an account head for sundry debtor before creating new customer");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

        }


        function DuplicationCstCntrCodeMsg() {
            $("#divWarning").html("Duplication Error!.Cost centre Code Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            document.getElementById("<%=txtCostCntrCode.ClientID%>").style.borderColor = "Red";

        }

        function DuplicationName() {
            $("#divWarning").html("Duplication Error!. Customer Name Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            document.getElementById("<%=txtCustomerName.ClientID%>").style.borderColor = "Red";

        }
        function DuplicationNameLdgr() {
            $("#divWarning").html("Duplication Error!. Ledger Name Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            document.getElementById("<%=txtCustomerName.ClientID%>").style.borderColor = "Red";

        }
        function DuplicationNameCstcnr() {
            $("#divWarning").html("Duplication Error!. Cost centre Name Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            document.getElementById("<%=txtCustomerName.ClientID%>").style.borderColor = "Red";

        }

        function DuplicationCode() {
            $("#divWarning").html("Duplication Error!. Customer Code Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

        }


        function SaveValidate() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtCustomerName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCustomerName.ClientID%>").value = replaceText2;

            var AddressWithoutReplace = document.getElementById("<%=txtAddress1.ClientID%>").value;
            var replaceAddress1 = AddressWithoutReplace.replace(/</g, "");
            var replaceAddress2 = replaceAddress1.replace(/>/g, "");
            document.getElementById("<%=txtAddress1.ClientID%>").value = replaceAddress2;

            var Address2WithoutReplace = document.getElementById("<%=txtAddress2.ClientID%>").value;
            var replaceAddress21 = Address2WithoutReplace.replace(/</g, "");
            var replaceAddress22 = replaceAddress21.replace(/>/g, "");
            document.getElementById("<%=txtAddress2.ClientID%>").value = replaceAddress22;

            var Address3WithoutReplace = document.getElementById("<%=txtAddress3.ClientID%>").value;
            var replaceAddress31 = Address3WithoutReplace.replace(/</g, "");
            var replaceAddress32 = replaceAddress31.replace(/>/g, "");
            document.getElementById("<%=txtAddress3.ClientID%>").value = replaceAddress32;

            var ZipWithoutReplace = document.getElementById("<%=txtZipCode.ClientID%>").value;
            var replaceZip1 = ZipWithoutReplace.replace(/</g, "");
            var replaceZip2 = replaceZip1.replace(/>/g, "");
            document.getElementById("<%=txtZipCode.ClientID%>").value = replaceZip2.trim();

            var PaymentWithoutReplace = document.getElementById("<%=txtPaymentTerm.ClientID%>").value;
            var replacePayment1 = PaymentWithoutReplace.replace(/</g, "");
            var replacePayment2 = replacePayment1.replace(/>/g, "");
            document.getElementById("<%=txtPaymentTerm.ClientID%>").value = replacePayment2;

            var TinWithoutReplace = document.getElementById("<%=txtTinNumber.ClientID%>").value;
            var replaceTin1 = TinWithoutReplace.replace(/</g, "");
            var replaceTin2 = replaceTin1.replace(/>/g, "");
            document.getElementById("<%=txtTinNumber.ClientID%>").value = replaceTin2;

            var PhoneWithoutReplace = document.getElementById("<%=txtPhone.ClientID%>").value;
            var replacePhone1 = PhoneWithoutReplace.replace(/</g, "");
            var replacePhone2 = replacePhone1.replace(/>/g, "");
            document.getElementById("<%=txtPhone.ClientID%>").value = replacePhone2;

            var EmailWithoutReplace = document.getElementById("<%=txtEmail.ClientID%>").value;
            var replaceEmail1 = EmailWithoutReplace.replace(/</g, "");
            var replaceEmail2 = replaceEmail1.replace(/>/g, "");
            document.getElementById("<%=txtEmail.ClientID%>").value = replaceEmail2;

            var WebsiteWithoutReplace = document.getElementById("<%=txtWebSite.ClientID%>").value;
            var replaceWebsite1 = WebsiteWithoutReplace.replace(/</g, "");
            var replaceWebsite2 = replaceWebsite1.replace(/>/g, "");
            document.getElementById("<%=txtWebSite.ClientID%>").value = replaceWebsite2;


            document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCustomerName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCustomerType.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCustomerGroup.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAddress1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtNameOne.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAddressOne.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtNameTwo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAddressTwo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtNameThree.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAddressThree.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtMobileThree.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmailThree.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtMobileTwo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmailTwo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtMobileOne.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmailOne.ClientID%>").style.borderColor = "";
            document.getElementById('ErrorMsgMob').style.display = "none";
            document.getElementById('ErrorMsgEmail').style.display = "none";

            var Name = document.getElementById("<%=txtCustomerName.ClientID%>").value.trim();

            var CustomerType = document.getElementById("<%=ddlCustomerType.ClientID%>");
            var CustomerTypeText = CustomerType.options[CustomerType.selectedIndex].text;

            var CustomerGroup = document.getElementById("<%=ddlCustomerGroup.ClientID%>");
            var CustomerGroupText = CustomerGroup.options[CustomerGroup.selectedIndex].text;

            var Address = document.getElementById("<%=txtAddress1.ClientID%>").value.trim();

            var Country = document.getElementById("<%=ddlCountry.ClientID%>");
            var CountryName = Country.options[Country.selectedIndex].text;

            var Mobile = document.getElementById("<%=txtMobile.ClientID%>").value;

            var Email = document.getElementById("<%=txtEmail.ClientID%>").value.trim();

            var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;




            //if (Mobile == "") {
            //    document.getElementById('divErrorTotal').style.visibility = "visible";
            //    document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
            //    document.getElementById('divCustomerDetails').style.display = "";
            //    document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "Red";
            //    document.getElementById("<%=txtMobile.ClientID%>").focus();
            //    ret = false;
            //}

            if (Mobile != "") {
                if (!mobileregular.test(Mobile)) {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById('divCustomerDetails').style.display = "";
                    var ErrorMsg = document.getElementById('ErrorMsgMob').style.display = "";
                    var OrgMobileFocus = document.getElementById("<%=txtMobile.ClientID%>").focus();
                    document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
            }

            if (Email != "") {

                if (!filter.test(Email)) {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById('divCustomerDetails').style.display = "";
                    var ErrorMsg = document.getElementById('ErrorMsgEmail').style.display = "";
                    var OrgMobileFocus = document.getElementById("<%=txtEmail.ClientID%>").focus();
                    document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }

            }

            if (CountryName == "--SELECT COUNTRY--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlCountry.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlCountry.ClientID%>").focus();
                ret = false;
            }

            if (Address == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById('divCustomerDetails').style.display = "";
                document.getElementById("<%=txtAddress1.ClientID%>").style.borderColor = "Red";
               document.getElementById("<%=txtAddress1.ClientID%>").focus();
                ret = false;
            }
            if (document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "1") {
                //Start:-Ledger details


                var Currency = document.getElementById("cphMain_ddlCurrency").value;

                $('input.Achead').attr("style", "border-color:none");
                document.getElementById("cphMain_ddlCurrency").style.borderColor = "";
                var LedgerrGroup = document.getElementById("<%=ddlLedger.ClientID%>").value;
                //  var CustomerGroupText = CustomerGroup.options[ddlLedger.selectedIndex].text;

                //EVM-0027 Aug 28
                if (document.getElementById("cphMain_cbxLedgerSts").checked == true && document.getElementById("cphMain_chkSubLedger").checked == true) {
                    if (LedgerrGroup == "--SELECT CUSTOMER--") {
                        document.getElementById("cphMain_ddlLedger").style.borderColor = "Red";
                        $('input.Achead').attr("style", "border-color:red");

                        //document.getElementById("form1  Achead ui-autocomplete-input").style.borderColor = "Red";
                        document.getElementById("cphMain_ddlLedger").focus();

                        ret = false;
                    }
                }

                //end
                if (document.getElementById("cphMain_cbxLedgerSts").checked == true && Currency == "--SELECT CURRENCY--") {
                    document.getElementById("cphMain_ddlCurrency").style.borderColor = "Red";
                    document.getElementById("cphMain_ddlCurrency").focus();
                    ret = false;
                }

                if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                    var TDS = document.getElementById("cphMain_ddlTDS").value;
                    var TCS = document.getElementById("cphMain_ddlTCS").value;
                    document.getElementById("cphMain_ddlTDS").style.borderColor = "";
                    document.getElementById("cphMain_ddlTCS").style.borderColor = "";

                    if (document.getElementById("cphMain_cbxLedgerSts").checked == true && document.getElementById("cphMain_radioTCSyes").checked == true && TCS == "--SELECT TCS--") {
                        document.getElementById("cphMain_ddlTCS").style.borderColor = "Red";
                        document.getElementById("cphMain_ddlTCS").focus();
                        ret = false;
                    }

                    if (document.getElementById("cphMain_cbxLedgerSts").checked == true && document.getElementById("cphMain_radioTDSyes").checked == true && TDS == "--SELECT TDS--") {
                        document.getElementById("cphMain_ddlTDS").style.borderColor = "Red";
                        document.getElementById("cphMain_ddlTDS").focus();
                        ret = false;
                    }

                }

                var CostGrp = document.getElementById("cphMain_ddlCC").value;
                document.getElementById("cphMain_ddlCC").style.borderColor = "";

                if (document.getElementById("cphMain_cbxLedgerSts").checked == true && document.getElementById("cphMain_cbxCsCntrSts").checked == true && CostGrp == "--SELECT COST GROUP--") {
                    document.getElementById("cphMain_ddlCC").style.borderColor = "Red";
                    document.getElementById("cphMain_ddlCC").focus();
                    ret = false;
                }
                //End:-Ledger details
            }
            if (CustomerGroupText == "--SELECT GROUP--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlCustomerGroup.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlCustomerGroup.ClientID%>").focus();
                ret = false;
            }


            if (CustomerTypeText == "--SELECT TYPE--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlCustomerType.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlCustomerType.ClientID%>").focus();
                ret = false;
            }

            if (Name == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtCustomerName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCustomerName.ClientID%>").focus();
                ret = false;
            }

            if (ret == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                CheckSubmitZero();
                return ret;
            }

            var NameOne = document.getElementById("<%=txtNameOne.ClientID%>").value.trim();
            var AddressOne = document.getElementById("<%=txtAddressOne.ClientID%>").value.trim();
            var MobileOne = document.getElementById("<%=txtMobileOne.ClientID%>").value;
            var PhoneOne = document.getElementById("<%=txtPhoneOne.ClientID%>").value;
            var EmailOne = document.getElementById("<%=txtEmailOne.ClientID%>").value;
            var WebsiteOne = document.getElementById("<%=txtWebsiteOne.ClientID%>").value;

            var NameTwo = document.getElementById("<%=txtNameTwo.ClientID%>").value.trim();
            var AddressTwo = document.getElementById("<%=txtAddressTwo.ClientID%>").value.trim();
            var MobileTwo = document.getElementById("<%=txtMobileTwo.ClientID%>").value;
            var PhoneTwo = document.getElementById("<%=txtPhoneTwo.ClientID%>").value;
            var EmailTwo = document.getElementById("<%=txtEmailTwo.ClientID%>").value;
            var WebsiteTwo = document.getElementById("<%=txtWebsiteTwo.ClientID%>").value;

            var NameThree = document.getElementById("<%=txtNameThree.ClientID%>").value.trim();
            var AddressThree = document.getElementById("<%=txtAddressThree.ClientID%>").value.trim();
            var MobileThree = document.getElementById("<%=txtMobileThree.ClientID%>").value;
            var PhoneThree = document.getElementById("<%=txtPhoneThree.ClientID%>").value;
            var EmailThree = document.getElementById("<%=txtEmailThree.ClientID%>").value;
            var WebsiteThree = document.getElementById("<%=txtWebsiteThree.ClientID%>").value;

            document.getElementById('ErrorMsgMobileOne').style.display = "none";
            document.getElementById('ErrorMsgMobileTwo').style.display = "none";
            document.getElementById('ErrorMsgMobileThree').style.display = "none";
            document.getElementById('ErrorMsgEmailOne').style.display = "none";
            document.getElementById('ErrorMsgEmailTwo').style.display = "none";
            document.getElementById('ErrorMsgEmailThree').style.display = "none";


            if (NameOne != "" && NameTwo != "") {
                if (NameOne == NameTwo) {
                    document.getElementById('divCustomerDetails').style.display = "";
                    document.getElementById('divNewContactOne').style.display = "";
                    document.getElementById('ClearOne').style.display = "";
                    document.getElementById('divErrorTotal').style.visibility = "visible";
                    document.getElementById('divNewContactTwo').style.display = "";
                    document.getElementById('ClearTwo').style.display = "";
                    document.getElementById("<%=txtNameTwo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Duplication Error!. Contact Name Can’t be Duplicated.";
                    ret = false;

                    CheckSubmitZero();
                    return ret;
                }
            }
            if (NameOne != "" && NameThree != "") {
                if (NameOne == NameThree) {
                    document.getElementById('divCustomerDetails').style.display = "";
                    document.getElementById('divNewContactOne').style.display = "";
                    document.getElementById('ClearOne').style.display = "";
                    document.getElementById('divErrorTotal').style.visibility = "visible";
                    document.getElementById('divNewContactThree').style.display = "";
                    document.getElementById('ClearThree').style.display = "";
                    document.getElementById("<%=txtNameThree.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Duplication Error!. Contact Name Can’t be Duplicated.";
                    ret = false;


                    CheckSubmitZero();

                    return ret;
                }
            }
            if (NameTwo != "" && NameThree != "") {
                if (NameTwo == NameThree) {
                    document.getElementById('divCustomerDetails').style.display = "";
                    document.getElementById('divNewContactOne').style.display = "";
                    document.getElementById('ClearOne').style.display = "";
                    document.getElementById('divErrorTotal').style.visibility = "visible";
                    document.getElementById('divNewContactThree').style.display = "";
                    document.getElementById('ClearThree').style.display = "";
                    document.getElementById("<%=txtNameThree.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Duplication Error!. Contact Name Can’t be Duplicated.";
                    ret = false;

                    CheckSubmitZero();


                    return ret;
                }
            }

            if (NameThree != "" || AddressThree != "" || MobileThree != "" || PhoneThree != "" || EmailThree != "" || WebsiteThree != "") {


                if (EmailThree != "") {
                    if (!filter.test(EmailThree)) {
                        document.getElementById('divCustomerDetails').style.display = "";
                        document.getElementById('divNewContactOne').style.display = "";
                        document.getElementById('ClearOne').style.display = "";
                        document.getElementById('divNewContactThree').style.display = "";
                        document.getElementById('ClearThree').style.display = "";
                        document.getElementById('ErrorMsgEmailThree').style.display = "";
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        document.getElementById("<%=txtEmailThree.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtEmailThree.ClientID%>").focus();
                        ret = false;
                    }
                }

                if (MobileThree != "") {
                    if (!mobileregular.test(MobileThree)) {
                        document.getElementById('divCustomerDetails').style.display = "";
                        document.getElementById('divNewContactOne').style.display = "";
                        document.getElementById('ClearOne').style.display = "";
                        document.getElementById('divNewContactThree').style.display = "";
                        document.getElementById('ClearThree').style.display = "";
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        }); var ErrorMsg = document.getElementById('ErrorMsgMobileThree').style.display = "";
                        document.getElementById("<%=txtMobileThree.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtMobileThree.ClientID%>").focus();
                        ret = false;
                    }
                }




                if (AddressThree == "") {
                    document.getElementById('divCustomerDetails').style.display = "";
                    document.getElementById('divNewContactOne').style.display = "";
                    document.getElementById('ClearOne').style.display = "";
                    document.getElementById('divNewContactThree').style.display = "";
                    document.getElementById('ClearThree').style.display = "";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtAddressThree.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAddressThree.ClientID%>").focus();
                    ret = false;
                }
                if (NameThree == "") {
                    document.getElementById('divCustomerDetails').style.display = "";
                    document.getElementById('divNewContactOne').style.display = "";
                    document.getElementById('ClearOne').style.display = "";
                    document.getElementById('divNewContactThree').style.display = "";
                    document.getElementById('ClearThree').style.display = "";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtNameThree.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtNameThree.ClientID%>").focus();
                    ret = false;
                }
            }

            if (NameTwo != "" || AddressTwo != "" || MobileTwo != "" || PhoneTwo != "" || EmailTwo != "" || WebsiteTwo != "") {

                if (EmailTwo != "") {
                    if (!filter.test(EmailTwo)) {
                        document.getElementById('divCustomerDetails').style.display = "";
                        document.getElementById('divNewContactOne').style.display = "";
                        document.getElementById('ClearOne').style.display = "";
                        document.getElementById('divNewContactTwo').style.display = "";
                        document.getElementById('ClearTwo').style.display = "";
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        var ErrorMsg = document.getElementById('ErrorMsgEmailTwo').style.display = "";
                        document.getElementById("<%=txtEmailTwo.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtEmailTwo.ClientID%>").focus();
                        ret = false;
                    }
                }

                if (MobileTwo != "") {
                    if (!mobileregular.test(MobileTwo)) {
                        document.getElementById('divCustomerDetails').style.display = "";
                        document.getElementById('divNewContactOne').style.display = "";
                        document.getElementById('ClearOne').style.display = "";
                        document.getElementById('divNewContactTwo').style.display = "";
                        document.getElementById('ClearTwo').style.display = "";
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        var ErrorMsg = document.getElementById('ErrorMsgMobileTwo').style.display = "";
                        document.getElementById("<%=txtMobileTwo.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=txtMobileTwo.ClientID%>").focus();
                        ret = false;
                    }
                }



                if (AddressTwo == "") {
                    document.getElementById('divCustomerDetails').style.display = "";
                    document.getElementById('divNewContactOne').style.display = "";
                    document.getElementById('ClearOne').style.display = "";
                    document.getElementById('divNewContactTwo').style.display = "";
                    document.getElementById('ClearTwo').style.display = "";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtAddressTwo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAddressTwo.ClientID%>").focus();
                    ret = false;
                }
                if (NameTwo == "") {
                    document.getElementById('divCustomerDetails').style.display = "";
                    document.getElementById('divNewContactOne').style.display = "";
                    document.getElementById('ClearOne').style.display = "";
                    document.getElementById('divNewContactTwo').style.display = "";
                    document.getElementById('ClearTwo').style.display = "";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtNameTwo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtNameTwo.ClientID%>").focus();
                    ret = false;
                }
            }

            if (NameOne != "" || AddressOne != "" || MobileOne != "" || PhoneOne != "" || EmailOne != "" || WebsiteOne != "") {


                if (EmailOne != "") {
                    if (!filter.test(EmailOne)) {
                        document.getElementById('divCustomerDetails').style.display = "";
                        document.getElementById('divNewContactOne').style.display = "";
                        document.getElementById('ClearOne').style.display = "";
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        var ErrorMsg = document.getElementById('ErrorMsgEmailOne').style.display = "";
                        document.getElementById("<%=txtEmailOne.ClientID%>").style.borderColor = "Red";
                          document.getElementById("<%=txtEmailOne.ClientID%>").focus();
                        ret = false;
                    }
                }

                if (MobileOne != "") {
                    if (!mobileregular.test(MobileOne)) {
                        document.getElementById('divCustomerDetails').style.display = "";
                        document.getElementById('divNewContactOne').style.display = "";
                        document.getElementById('ClearOne').style.display = "";
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        var ErrorMsg = document.getElementById('ErrorMsgMobileOne').style.display = "";
                        document.getElementById("<%=txtMobileOne.ClientID%>").style.borderColor = "Red";
                       document.getElementById("<%=txtMobileOne.ClientID%>").focus();
                        ret = false;
                    }
                }

                if (AddressOne == "") {
                    document.getElementById('divCustomerDetails').style.display = "";
                    document.getElementById('divNewContactOne').style.display = "";
                    document.getElementById('ClearOne').style.display = "";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtAddressOne.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAddressOne.ClientID%>").focus();
                    ret = false;
                }
                if (NameOne == "") {
                    document.getElementById('divCustomerDetails').style.display = "";
                    document.getElementById('divNewContactOne').style.display = "";
                    document.getElementById('ClearOne').style.display = "";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtNameOne.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtNameOne.ClientID%>").focus();
                    ret = false;
                }
            }
            var acntflg = true;
            var acntSts = document.getElementById("cphMain_HiddenAcntGrpSts").value;
            if (acntSts == 1) {
                acntflg = false;
            }
            else {
                acntflg = true;
            }
            if (document.getElementById("<%=cbxLedgerSts.ClientID%>").checked == true) {
            }
            else {
                acntflg = true;
            }

            if (document.getElementById("cphMain_ddlAccountGrp").value != "--SELECT ACCOUNT GROUP--") {
                acntflg = true;
            }


            if (ret == false && acntflg == true) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                CheckSubmitZero();

            }
            else if (ret == false && acntflg == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                CheckSubmitZero();
            }
            else if (ret == true && acntflg == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                CheckSubmitZero();
                ret = false;
            }

            return ret;
        }

        function VisibleCustomerDetails() {
            if ($('#divCustomerDetails:visible').length == 0) {
                document.getElementById('divCustomerDetails').style.display = "";
                document.getElementById("<%=txtAddress1.ClientID%>").focus();
            }
            else {
                document.getElementById('divCustomerDetails').style.display = "none";
                document.getElementById("<%=txtCustomerName.ClientID%>").focus();

            }
            return false;
        }

        function VisibleMediaDetails() {
            if ($('#divMedia:visible').length == 0) {
                document.getElementById('divMedia').style.display = "";
                document.getElementById("<%=txtAddress1.ClientID%>").focus();
            }
            else {
                document.getElementById('divMedia').style.display = "none";
                document.getElementById("<%=txtCustomerName.ClientID%>").focus();

            }
            return false;
        }

        function VisibleContactOne() {
            if ($('#divNewContactOne:visible').length == 0) {
                document.getElementById('divNewContactOne').style.display = "";
                document.getElementById('ClearOne').style.display = "";
                document.getElementById("<%=txtNameOne.ClientID%>").focus();
            }
            else {
                document.getElementById('divNewContactOne').style.display = "none";
                document.getElementById('ClearOne').style.display = "none";
            }
            return false;
        }

        function ClearContactOne() {
            if (confirm('Do You Want To Clear This Contact Details')) {
                document.getElementById("<%=txtNameOne.ClientID%>").value = "";
                document.getElementById("<%=txtAddressOne.ClientID%>").value = "";
                document.getElementById("<%=txtMobileOne.ClientID%>").value = "";
                document.getElementById("<%=txtPhoneOne.ClientID%>").value = "";
                document.getElementById("<%=txtEmailOne.ClientID%>").value = "";
                document.getElementById("<%=txtWebsiteOne.ClientID%>").value = "";
                document.getElementById("<%=txtNameOne.ClientID%>").focus();
            }
            else {
                document.getElementById("<%=txtNameOne.ClientID%>").focus();
            }

        }

        function ClearContactTwo() {
            if (confirm('Do You Want To Clear This Contact Details')) {
                document.getElementById("<%=txtNameTwo.ClientID%>").value = "";
                document.getElementById("<%=txtAddressTwo.ClientID%>").value = "";
                document.getElementById("<%=txtMobileTwo.ClientID%>").value = "";
                document.getElementById("<%=txtPhoneTwo.ClientID%>").value = "";
                document.getElementById("<%=txtEmailTwo.ClientID%>").value = "";
                document.getElementById("<%=txtWebsiteTwo.ClientID%>").value = "";
                document.getElementById("<%=txtNameTwo.ClientID%>").focus();
            }
            else {
                document.getElementById("<%=txtNameTwo.ClientID%>").focus();
            }
        }

        function ClearContactThree() {
            if (confirm('Do You Want To Clear This Contact Details')) {
                document.getElementById("<%=txtNameThree.ClientID%>").value = "";
                document.getElementById("<%=txtAddressThree.ClientID%>").value = "";
                document.getElementById("<%=txtMobileThree.ClientID%>").value = "";
                document.getElementById("<%=txtPhoneThree.ClientID%>").value = "";
                document.getElementById("<%=txtEmailThree.ClientID%>").value = "";
                document.getElementById("<%=txtWebsiteThree.ClientID%>").value = "";
                document.getElementById("<%=txtNameThree.ClientID%>").focus();
            }
            else {
                document.getElementById("<%=txtNameThree.ClientID%>").focus();
            }
        }

        function VisibleContactTwo() {
            if ($('#divNewContactTwo:visible').length == 0) {
                if (document.getElementById("<%=txtNameOne.ClientID%>").value == "") {
                    document.getElementById("<%=txtNameOne.ClientID%>").focus();
                }
                else {
                    if (document.getElementById("<%=txtAddressOne.ClientID%>").value == "") {
                        document.getElementById("<%=txtAddressOne.ClientID%>").focus();
                    }
                    else {
                        document.getElementById('divNewContactTwo').style.display = "";
                        document.getElementById('ClearTwo').style.display = "";
                        document.getElementById("<%=txtNameTwo.ClientID%>").focus();
                    }
                }
            }
            else {
                document.getElementById('divNewContactTwo').style.display = "none";
                document.getElementById('ClearTwo').style.display = "none";
            }
            return false;
        }

        function VisibleTinNumber() {
            document.getElementById('divTinNumber').style.display = "";
            //  AutoCompleteAll();
        }

        function VisibleContactThree() {
            if ($('#divNewContactThree:visible').length == 0) {
                if (document.getElementById("<%=txtNameOne.ClientID%>").value == "") {
                    document.getElementById("<%=txtNameOne.ClientID%>").focus();
                }
                else {
                    if (document.getElementById("<%=txtAddressOne.ClientID%>").value == "") {
                        document.getElementById("<%=txtAddressOne.ClientID%>").focus();
                    }
                    else {
                        if (document.getElementById("<%=txtNameTwo.ClientID%>").value == "") {
                            document.getElementById("<%=txtNameTwo.ClientID%>").focus();
                        }
                        else {
                            if (document.getElementById("<%=txtAddressTwo.ClientID%>").value == "") {
                                document.getElementById("<%=txtAddressTwo.ClientID%>").focus();
                            }
                            else {
                                document.getElementById('divNewContactThree').style.display = "";
                                document.getElementById('ClearThree').style.display = "";
                                document.getElementById("<%=txtNameThree.ClientID%>").focus();

                            }
                        }
                    }
                }
            }
            else {
                document.getElementById('divNewContactThree').style.display = "none";
                document.getElementById('ClearThree').style.display = "none";
            }
            return false;
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

        function isNumberWithDigit(evt) {



            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13) {
                return false;
            }
                //at dot key
            else if (keyCodes == 190) {
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40 || keyCodes == 46) {
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


        function CountryChange() {
            var Country = document.getElementById("<%=ddlCountry.ClientID%>");
            var CountryName = Country.options[Country.selectedIndex].text;
            if (CountryName == "--SELECT COUNTRY--") {
                IncrmntConfrmCounter();
                document.getElementById("<%=ddlState.ClientID%>").options.length = 0;
             return false;
         }
         return true;
     }
     function CountryChange1() {
         var Country = document.getElementById("<%=ddlState.ClientID%>");
            var CountryName = Country.options[Country.selectedIndex].text;
            if (CountryName == "--SELECT STATE--") {
                IncrmntConfrmCounter();
                document.getElementById("<%=ddlCity.ClientID%>").options.length = 0;
                return false;
            }
            return true;
        }
        function CountryFocus() {
            SetAutoComplete();
            document.getElementById("<%=ddlCountry.ClientID%>").focus();

        }

        function StateFocus() {
            SetAutoComplete();
            document.getElementById("<%=ddlState.ClientID%>").focus();

        }

        function CityFocus() {
            document.getElementById("<%=ddlCity.ClientID%>").focus();
            SetAutoComplete();
        }

        function RemoveTag(control) {

            var text = control.value;
            var replaceText1 = text.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            control.value = replaceText2;
        }

        function AssignMediaValues(control) {

            var text = control.value;
            var replaceText1 = text.replace(/</g, "");

            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/~/g, "");

            var replaceText4 = replaceText3.replace(/^/g, "");

            var replaceText5 = replaceText4.replace(/"/g, "");

            var replaceText6 = replaceText5.replace(/`/g, "");
            var replaceText7 = replaceText6.replace(/!/g, "");
            document.getElementById(control.id).value = replaceText7;

            var MediaValue = document.getElementById("<%=hiddenMedia.ClientID%>").value;//Retrieve the stored data            

            if (MediaValue == "") { //If there is no data, initialize an empty array
                MediaValue = [];
            }
            else {
                MediaValue = JSON.parse(MediaValue); //Converts string to object
                //alert(StringObject.length);
            }
            var $add = jQuery.noConflict();
            var client = JSON.stringify({
                MEDIA_ID: "" + control.id + "",
                MEDIA_NAME: null,
                MEDIA_DESCRIPTION: "" + control.value + ""
            });

            MediaValue.push(client);
            document.getElementById("<%=hiddenMedia.ClientID%>").value = JSON.stringify(MediaValue);
           // alert(document.getElementById("<%=hiddenMedia.ClientID%>").value);
            //  AutoCompleteAll();
        }

    </script>

    <%--<script src="../../../JavaScript/jquery-1.8.3.min.js"></script>--%>
    <script type="text/javascript" language="javascript">

        //005 start
        function BlurNotNumber(obj) {

            var txt = document.getElementById(obj).value;
            txt = txt.replace(/,/g, "");
            if (txt != "") {

                if (isNaN(txt)) {
                    document.getElementById(obj).value = "";
                    document.getElementById(obj).focus();
                    return false;

                }
                else {
                    if (obj == "cphMain_txtCreditLimit") {
                        addCommas(document.getElementById(obj).value);
                    }
                }


            }
        }
        //for not allowing special characters
        //005 start
        function textRemoveSpecial(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            if (keyCodes == 126 || keyCodes == 33 || keyCodes == 94 || keyCodes == 34 || keyCodes == 96) {
                return false;
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
        function isTagMulti(obj, evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                if (obj == "cphMain_txtPriceTerm" || obj == "cphMain_txtPaymentTerm" || obj == "cphMain_txtDeliveryTerm") {

                }
                else {
                    return false;
                }
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
        //for not allowing above max limit
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

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
        function ReplaceTag(obj, evt) {

            // replacing < and > tags
            var WithoutReplace = document.getElementById(obj).value;

            var replaceText1 = WithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2.trim();


        }
    </script>
     <script>        // 005 start
         function ChangePriceTerm() {
             var PreviousVal = document.getElementById("<%=hiddenPreviousPriceTerm.ClientID%>").value;
             var txt_Term = document.getElementById("<%=txtPriceTerm.ClientID%>").value
             var DropdownPriceTerm = document.getElementById("<%=ddlPriceTerm.ClientID%>");
             var SelectedValuePriceTerm = DropdownPriceTerm.value;
             if (SelectedValuePriceTerm == '--SELECT PRICE TERMS--') {

                 SelectedValuePriceTerm = 0;
             }
             if (SelectedValuePriceTerm != 0) {
                 if (txt_Term != '') {


                     if (confirmbox > 0) {
                         ezBSAlert({
                             type: "confirm",
                             messageText: "Are you Sure you want to Change Price Terms?",
                             alertType: "info"
                         }).done(function (e) {
                             if (e == true) {
                                 IncrmntConfrmCounter();
                                 TermSelected(SelectedValuePriceTerm, 'cphMain_txtPriceTerm');
                                 document.getElementById("<%=txtPriceTerm.ClientID%>").focus();
                                 return false;
                             }
                             else {
                                 var desiredValue = PreviousVal;

                                 var el = document.getElementById(("<%=ddlPriceTerm.ClientID%>"));
                                  for (var i = 0; i < el.options.length; i++) {
                                      if (el.options[i].value == desiredValue) {
                                          el.selectedIndex = i;
                                          break;
                                      }
                                  }
                                  document.getElementById("<%=txtPriceTerm.ClientID%>").focus();
                        return false;
                             }
                         });
                         return false;
                     }
                   
                    
                 }


                 else {
                     IncrmntConfrmCounter();
                     TermSelected(SelectedValuePriceTerm, 'cphMain_txtPriceTerm');
                     document.getElementById("<%=txtPriceTerm.ClientID%>").focus();

                     }









            }
            else {
                document.getElementById("<%=txtPriceTerm.ClientID%>").focus();
                  return false;
              }
          }
          function ChangePaymentTerm() {

              var PreviousVal = document.getElementById("<%=hiddenPreviousPaymentTerm.ClientID%>").value;
            var txt_Term = document.getElementById("<%=txtPaymentTerm.ClientID%>").value
            var DropdownPaymentTerm = document.getElementById("<%=ddlPaymentTerm.ClientID%>");
            var SelectedValuePaymentTerm = DropdownPaymentTerm.value;
            if (SelectedValuePaymentTerm == '--SELECT PAYMENT TERMS--') {
                SelectedValuePaymentTerm = 0;

            }
            if (SelectedValuePaymentTerm != 0) {
                if (txt_Term != '') {

                    if (confirmbox > 0) {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you Sure you want to Change Payment Terms?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                IncrmntConfrmCounter();
                                TermSelected(SelectedValuePaymentTerm, 'cphMain_txtPaymentTerm');
                                document.getElementById("<%=txtPaymentTerm.ClientID%>").focus();
                                return false;
                             }
                             else {
                                var desiredValue = PreviousVal;

                                var el = document.getElementById(("<%=ddlPaymentTerm.ClientID%>"));
                                 for (var i = 0; i < el.options.length; i++) {
                                     if (el.options[i].value == desiredValue) {
                                         el.selectedIndex = i;
                                         break;
                                     }
                                 }
                                 document.getElementById("<%=txtPaymentTerm.ClientID%>").focus();
                        return false;
                    }
                         });
                          return false;
                      }
                   
                 
                 }





                else {
                    IncrmntConfrmCounter();
                    TermSelected(SelectedValuePaymentTerm, 'cphMain_txtPaymentTerm');
                    document.getElementById("<%=txtPaymentTerm.ClientID%>").focus();
                    }



                
            }
            else {
                document.getElementById("<%=txtPaymentTerm.ClientID%>").focus();
               return false;
           }


       }
       function ChangeDeliveryTerm() {

           var PreviousVal = document.getElementById("<%=hiddenPreviousDeliveryTerm.ClientID%>").value;
            var txt_Term = document.getElementById("<%=txtDeliveryTerm.ClientID%>").value;
            var DropdownDeliveryTerm = document.getElementById("<%=ddlDeliveryTerm.ClientID%>");
            var SelectedValueDeliveryTerm = DropdownDeliveryTerm.value;
            if (SelectedValueDeliveryTerm == '--SELECT DELIVERY TERMS--') {
                SelectedValueDeliveryTerm = 0;

            }
            if (SelectedValueDeliveryTerm != 0) {
                if (txt_Term != '') {

                    if (confirmbox > 0) {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you Sure you want to Change Delivery Terms?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                IncrmntConfrmCounter();
                                TermSelected(SelectedValueDeliveryTerm, 'cphMain_txtDeliveryTerm');
                                document.getElementById("<%=txtDeliveryTerm.ClientID%>").focus();
                                return false;
                             }
                            else
                            {
                                var desiredValue = PreviousVal;

                            var el = document.getElementById(("<%=ddlDeliveryTerm.ClientID%>"));
                             for (var i = 0; i < el.options.length; i++) {
                                 if (el.options[i].value == desiredValue) {
                                     el.selectedIndex = i;
                                     break;
                                 }
                             }
                             document.getElementById("<%=txtDeliveryTerm.ClientID%>").focus();
                        return false;
                              }
                         });
                          return false;
                      }









                }
                else {
                    IncrmntConfrmCounter();
                    TermSelected(SelectedValueDeliveryTerm, 'cphMain_txtDeliveryTerm');
                    document.getElementById("<%=txtDeliveryTerm.ClientID%>").focus();
                }
            }
            else {
                document.getElementById("<%=txtDeliveryTerm.ClientID%>").focus();
                return false;
            }

        }
    </script>
   
     <script>

         function getPreviousDDLPayment_SelectedVal() {
             var DropdownList = document.getElementById('<%=ddlPaymentTerm.ClientID %>');
           var SelectedValue = DropdownList.value;
           document.getElementById("<%=hiddenPreviousPaymentTerm.ClientID%>").value = SelectedValue;

         }
         function getPreviousDDLPrice_SelectedVal() {
             var DropdownList = document.getElementById('<%=ddlPriceTerm.ClientID %>');
              var SelectedValue = DropdownList.value;
              document.getElementById("<%=hiddenPreviousPriceTerm.ClientID%>").value = SelectedValue;

        }
        function getPreviousDDLDelivery_SelectedVal() {
            var DropdownList = document.getElementById('<%=ddlDeliveryTerm.ClientID %>');
            var SelectedValue = DropdownList.value;
            document.getElementById("<%=hiddenPreviousDeliveryTerm.ClientID%>").value = SelectedValue;

         }
        </script>
        <script>


            function TermSelected(T_Id, objId) {

                //web method for drop down of narrations for common narration
                var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;

                if (CorpId != '' && CorpId != null && OrgId != '' && OrgId != null && T_Id != '' && T_Id != null && (!isNaN(T_Id))) {
                    //  alert('hi entered');
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "gen_Customer_Master.aspx/TermDetails",
                        data: '{corporateId: "' + CorpId + '",organisationId:"' + OrgId + '" ,TermId:"' + T_Id + '"}',
                        dataType: "json",
                        success: function (data) {

                            if (data.d != '') {

                                document.getElementById(objId).value = data.d.strTermDescription;



                            }
                        },
                        error: function (result) {
                            // alert("Error");
                        }
                    });

                }
                // AutoCompleteAll();
            }
        </script>

     <script type="text/javascript">

         function PassSavedCustomer(intCustomerId) {
             if (window.opener != null && !window.opener.closed) {
                 window.opener.GetValueFromChildProject(intCustomerId);
             }
             window.close();
         }

         function PassSavedCustomerToLead(intCustId) {
             if (window.opener != null && !window.opener.closed) {
                 var txtName = window.opener.document.getElementById("cphMain_txtCustName");
                 txtName.value = document.getElementById("<%=txtCustomerName.ClientID%>").value;

                 window.opener.GetValueFromChild(intCustId);
             }
             window.close();
         }
         function PassSavedCustomerToRFG(intCustId) {
             if (window.opener != null && !window.opener.closed) {

                 window.opener.GetValueFromChild(intCustId);
             }
             window.close();

         }

         function CloseWindow() {
             window.close();

         }

         function CreditLimitChange(obj) {

             if (document.getElementById(obj).value != "" && document.getElementById("<%=cbxLedgerSts.ClientID%>").checked == true && document.getElementById("<%=HiddenViewSts.ClientID%>").value != "1") {
                 document.getElementById("<%=cbxCrdtLmtRestrict.ClientID%>").disabled = false;
                 document.getElementById("<%=cbxCrdtLmtWarn.ClientID%>").disabled = false;
             }
             else {
                 document.getElementById("<%=cbxCrdtLmtRestrict.ClientID%>").disabled = true;
                 document.getElementById("<%=cbxCrdtLmtWarn.ClientID%>").disabled = true;
             }

             BlurNotNumber(obj);
         }


         function CreditPeriodChange(obj) {

             if (document.getElementById(obj).value != "" && document.getElementById("<%=cbxLedgerSts.ClientID%>").checked == true && document.getElementById("<%=HiddenViewSts.ClientID%>").value != "1") {
                 document.getElementById("<%=cbxCrdtPeriodRestrict.ClientID%>").disabled = false;
                 document.getElementById("<%=cbxCrdtPeriodWarn.ClientID%>").disabled = false;
             }
             else {
                 document.getElementById("<%=cbxCrdtPeriodRestrict.ClientID%>").disabled = true;
                 document.getElementById("<%=cbxCrdtPeriodWarn.ClientID%>").disabled = true;
             }

             BlurNotNumber(obj);
         }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  
     <asp:HiddenField ID="HiddenCustomerCode" runat="server" /> 
     <asp:HiddenField ID="HiddenFieldLedgerId" runat="server" /> 
           <asp:HiddenField ID="HiddenFieldDecimalCnt" runat="server" />  

      <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenTermDetails" runat="server" />
    <asp:HiddenField ID="hiddenPreviousPriceTerm" runat="server" />
     <asp:HiddenField ID="hiddenPreviousPaymentTerm" runat="server" />
    <asp:HiddenField ID="hiddenPreviousDeliveryTerm" runat="server" />
        <asp:HiddenField ID="HiddenCheckMode" runat="server" />
        <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
            <asp:HiddenField ID="HiddenNextId" runat="server" />
    <asp:HiddenField ID="HiddenTaxEnable" runat="server" />
        <asp:HiddenField ID="hiddenCostCntrId" runat="server" />
      <asp:HiddenField ID="HiddenCostCntrCnclId" runat="server" /> 
      <asp:HiddenField ID="HiddenAccountSpecific" runat="server" /> 
      <asp:HiddenField ID="HiddenBusinessSpecific" runat="server" /> 
      <asp:HiddenField ID="HiddenAcntGrpSts" runat="server" /> 
          <asp:HiddenField ID="HiddenAcntGrpChngSts" runat="server" /> 
     <asp:HiddenField ID="HiddenViewSts" runat="server" /> 

      <asp:HiddenField ID="HiddenCodeFormate" runat="server" />
      <asp:HiddenField ID="HiddenDefaultAcntGrpId" runat="server" />
      <asp:HiddenField ID="hiddenCurrencyAbbrv" runat="server" />
    <asp:HiddenField ID="hiddenCodeNumberFrmt" runat="server" />

    <div class="cont_rght">


      <div id="divErrorTotal" style="visibility: hidden">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>

          <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:5%; top:42%;height:26.5px;">

           <%--  <a href="gen_Customer_MasterList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

       




            <!---new--->

             <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
        <li><a href="gen_Customer_MasterList.aspx">Customer Master</a></li>
         <li class="active">Add Customer Master</li>
      </ol>
        <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
           <div class="fillform" style="width:100%">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <h2 id="lblEntry" runat="server"></h2>
            </div>
        
        
       <%-- <h2>Add Customer Master</h2>--%>
      

           <div class="form-group fg2 sa_fg2">
            <label for="email" class="fg2_la1">Ref#:<span class="spn1">*</span></label>
                           <asp:TextBox ID="txtRefNum" Enabled="false" class="form-control fg2_inp1 inp_mst" placeholder="000001" runat="server"    ></asp:TextBox>

              
          </div>
                 
          <div class="form-group fg2 sa_fg2">
            <label for="email" class="fg2_la1">Customer Name:<span class="spn1">*</span></label>
                          <asp:TextBox ID="txtCustomerName" class="form-control fg2_inp1 inp_mst" placeholder="Customer Name"  runat="server" MaxLength="100" ></asp:TextBox>

          </div>

          <div class="form-group fg2 sa_fg2">
           <label for="email" class="fg2_la1">Customer Type:<span class="spn1">*</span></label>
                              <asp:DropDownList ID="ddlCustomerType" class="form-control fg2_inp1 inp_mst" runat="server" ></asp:DropDownList>


            
          </div>

          <div id="divParentCategory" class="form-group fg2 sa_fg2">
           <label for="email" class="fg2_la1">Customer Group:<span class="spn1">*</span></label>
                              <asp:DropDownList ID="ddlCustomerGroup" class="form-control fg2_inp1 inp_mst" runat="server" ></asp:DropDownList>

           
          </div>

          <div id="divCategoryCode" class="form-group fg2 sa_fg3">
            <label for="email" class="fg2_la1">Credit Period (Days):<span class="spn1">&nbsp;</span></label>


            <div class="fg70 mar_at flt_l">
                                  <asp:TextBox ID="txtCreditPeriod" class="form-control fg2_inp1" placeholder="Credit Period (Days)" runat="server" MaxLength="3"  onkeydown="return isNumber(event)" onblur="return CreditPeriodChange('cphMain_txtCreditPeriod')" ></asp:TextBox>

            </div>
            <div class="fg4 mar_at flt_l" >
              <div class="row">
                <div class="col-md-12">
                  <div class="form-check">
                 <input id="cbxCrdtPeriodRestrict" runat="server" name="radioPeriod" class="form2" type="radio" onkeypress="return isTag(event)" onchange="return IncrmntConfrmCounter();" />
                    <label class="form-check-label" for="cbxCrdtPeriodRestrict">
                      Delimit
                    </label>
                  </div>
                </div>
                <div class="col-md-12">
                  <div class="form-check">
                    <input id="cbxCrdtPeriodWarn" runat="server" name="radioPeriod" checked="true" class="form2" type="radio" onkeypress="return isTag(event)" onchange="return IncrmntConfrmCounter();" />

                    
                    <label class="form-check-label" for="cbxCrdtPeriodWarn">
                      Warn
                    </label>
                  </div>
                </div>
              </div>
            </div>
          </div>

           <div class="form-group fg2 sa_fg3">
            <label for="email" class="fg2_la1">Credit Limit:<span class="spn1">&nbsp;</span></label>
           <div class="fg70 mar_at flt_l">
                                <asp:TextBox ID="txtCreditLimit" class="form-control fg2_inp1" runat="server" placeholder="Credit Limit" MaxLength="13" onkeyup="addCommas(cphMain_txtCreditLimit.value);"  onkeydown="return isNumberWithDigit(event)"  onblur="return CreditLimitChange('cphMain_txtCreditLimit');"></asp:TextBox>
               </div>
             
          
            <div class="fg4 mar_at flt_l" >
              <div class="row">
                <div class="col-md-12">
                  <div class="form-check">
          <input id="cbxCrdtLmtRestrict" runat="server" name="radioLimit" class="form2" type="radio" onkeypress="return isTag(event)" onchange="return IncrmntConfrmCounter();" />

                    <label class="form-check-label" for="option1">
                      Delimit
                    </label>
                  </div>
                </div>
                <div class="col-md-12">
                  <div class="form-check">
                                          <input id="cbxCrdtLmtWarn" runat="server" name="radioLimit" checked="true" class="form2" type="radio" onkeypress="return isTag(event)" onchange="return IncrmntConfrmCounter();" />

                    <label class="form-check-label" for="option2">
                      Warn
                    </label>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div id="DivCustomerCode" runat="server" class="form-group fg2 sa_fg3 " style="display:none">
            <label for="email" class="fg2_la1">Supplier Code:<span class="spn1">&nbsp;</span></label>
                              <asp:TextBox ID="txtCode" Enabled="false"  class="form-control fg2_inp1" placeholder="Supplier Code"  runat="server"   MaxLength="500"  ></asp:TextBox>

          </div>

            <div id="Accounts" runat="server" class="code_box">
              <div class="form-group fg2 sa_fg2 sa_640">
               <label for="email" class="fg2_la1 pad_l">Consider as ledger:<span class="spn1">*</span></label>
                <div class="check1 mar_btm1" >
                  <div class="">
                    <label class="switch" >
                    <asp:CheckBox ID="cbxLedgerSts" Text="" runat="server"      onclick="ledgerStsClick(0);"/>

                     
                      <span class="slider_tog round"></span>
                    </label>
                  </div>
                </div>
              </div>

              <div class="clearfix"></div>
              <div class="devider divid"></div>
                <div id="divCode" runat="server">
              <div class="form-group fg2 sa_fg3 sa_640" >
                <label for="email" class="fg2_la1">Ledger Code:<span class="spn1">&nbsp;</span></label>
            <asp:TextBox  class="form-control fg2_inp1" placeholder="Ledger Code"   id="txtLedgrCode"  runat="server"  MaxLength="50"    autocomplete="off"  onkeypress="return DisableEnter(event)"  onkeyup="textCounter(cphMain_txtLedgrCode,50)"   ></asp:TextBox>

              </div>
                </div>
    <div class="form-group fg2 sa_fg3 sa_640">
      <label class="fg2_la1">Opening Balance:<span class="spn1">&nbsp;</span></label>
                          <asp:TextBox Width="282px"  class="form-control fg2_inp1 tr_r" placeholder="0.00" id="txtOpenBalanceDeb"  runat="server"  MaxLength="10"     onblur="txtCCclick('cphMain_txtOpenBalanceDeb');"  onclick="IncrmntConfrmCounter();" onkeypress="return isDecimalNumber(event,'cphMain_txtOpenBalanceDeb')" onkeydown="return isDecimalNumber(event,'cphMain_txtOpenBalanceDeb')"   ></asp:TextBox>

     
    </div>

    <div  id="DandC" runat="server" class="form-group fg2 sa_fg3">
    
      <div class="row">
      <div class="col-sm-10">
        <div class="form-check">
                         <input name="optradio" checked="true"  runat="server" class="form-check-input" type="radio" id="typdebit"  onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();" />

        
          <label class="form-check-label" for="gridRadios1">
            Debit
          </label>
        </div>
      
     
        <div class="form-check">
                         <input name="optradio" runat="server" type="radio" id="typecredit" class="form-check-input"  onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();" />

        
          <label class="form-check-label" for="gridRadios2">
            Credit
          </label>
        </div>
      </div>
    </div>
  </div>

  <div class="form-group fg2 sa_fg2 st_mrb sa_640">
    <label for="email" class="fg2_la1 pad_l">Sub Ledger:<span class="spn1"></span></label>
    <div class="check1">
      <div class="">
        <label class="switch">
                         <asp:CheckBox ID="chkSubLedger" Text="" runat="server" onclick="SubLedgerClick();" />

          <span class="slider_tog round"></span>
        </label>
      </div>
    </div>
  </div>
  <div class="clearfix"></div>

  <div class="form-group fg2 sa_fg3 sa_640" id="asg" >
    
    <label for="email" class="fg2_la1">Account Group:<span class="spn1">&nbsp;</span></label>
      <asp:DropDownList ID="ddlAccountGrp" class="form-control fg2_inp1"  runat="server"  onchange="ledgerStsClick(0);" disabled=""  >
                </asp:DropDownList>
    
  </div>
    <div  class="form-group fg2 sa_fg3 sa_640" id="divledge">
    <label for="email" class="fg2_la1">Account Head:<span class="spn1">&nbsp;</span></label>
        <div id ="divddlLedger">
         <asp:DropDownList ID="ddlLedger"  class="form-control fg2_inp1" runat="server" onchange="ledgerStsClick(2);" disabled="">
                </asp:DropDownList></div>
  
  </div>
    
               
<div class="form-group fg2 sa_fg2 st_mrb sa_640">
    <label for="email" class="fg2_la1 pad_l">Satus:<span class="spn1"></span></label>
    <div class="check1">
      <div class="">
        <label class="switch">
            <asp:CheckBox ID="cbxStatus" runat="server" Checked="true" />  

          <span class="slider_tog round"></span>
        </label>
      </div>
    </div>
  </div>
 </div>

  <div class="clearfix"></div>
  <div class="devider divid"></div>

              <div id="divCstCtr" class="form-group fg2 fg2_mr sa_fg3 sa_640">
               <label for="email" class="fg2_la1 pad_l">Consider as cost centre:<span class="spn1"></span></label>
                <div class="check1 mar_btm1" >
                  <div class="">
                    <label class="switch" >
                        <asp:CheckBox ID="cbxCsCntrSts" Text="" runat="server"   onclick="ledgerStsClick(1);"/>

                      <span class="slider_tog round"></span>
                    </label>
                  </div>
                </div>
              </div>

              <div class="form-group fg2 fg2_mr sa_fg3 sa_640" id="costg">
                <label for="email" class="fg2_la1">Cost Group:<span class="spn1">&nbsp;</span></label>
                        <asp:DropDownList ID="ddlCC" class="form-control fg2_inp1" onchange="ChangeCostGroup();" onkeypress="return isTag(event)" onkeydown="return isTag(event)"  runat="server" disabled="" ></asp:DropDownList>

              
              </div>

              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Cost Centre Code:<span class="spn1">&nbsp;</span></label>
                                   <asp:TextBox  class="form-control fg2_inp1" placeholder="Cost Centre Code" id="txtCostCntrCode"  runat="server"  MaxLength="50"    autocomplete="off"  onkeypress="return DisableEnter(event)"  onkeyup="textCounter(cphMain_txtLedgrCode,50)"   ></asp:TextBox>

              </div>
                

              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Cost Centre Nature:<span class="spn1">&nbsp;</span></label>
                <div id="Div23" runat="server" class="row">
                  <div class="col-sm-10">
                    <div class="form-check">
                                     <input name="radioNature" checked="true"  runat="server" class="form-check-input" type="radio" id="rdIncome"  onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();" />

                    
                      <label class="form-check-label" for="gridRadios1">Income</label>
                    </div>
                    <div class="form-check">
                                     <input name="radioNature" runat="server" type="radio" id="rdExpense" class="form-check-input" onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();" />

                      
                      <label class="form-check-label" for="gridRadios2">Expense</label>
                    </div>
                  </div>
                </div>
              </div>
            <div class="clearfix"></div>
            <div class="devider divid"></div>
                 <div id="div2"   >
           <p class="plc1 tr_l bn"><a href="#frm" title="Click Here to Add Customer Details" id="headCustomerDetails" ><span class="badge bel_add"><i class="fa fa-plus"></i></span> Customer Details</a></p>

            <div id="divCustomerDetails" class="frm" id="frm" style="display:block;">
              <div id="div1" class="form-group fg2 sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Address 1:<span class="spn1">*</span></label>
                                  <asp:TextBox ID="txtAddress1"  class="form-control fg2_inp1 inp_mst" placeholder="Address 1" runat="server" MaxLength="150" ></asp:TextBox>

         
              </div>

              <div class="form-group fg2 sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Address 2:<span class="spn1"></span></label>
                                  <asp:TextBox ID="txtAddress2" class="form-control fg2_inp1" placeholder="Address 2"  runat="server" ></asp:TextBox>

               
              </div>
                        <div id="div3"  class="form-group fg2 sa_fg3 sa_640">
                 <label for="email" class="fg2_la1">Address 3:<span class="spn1"></span></label>
                <asp:TextBox ID="txtAddress3" class="form-control fg2_inp1" placeholder="Address 3"  runat="server" MaxLength="150" ></asp:TextBox>

            </div>
                    

                 
            
                    <%--<asp:UpdatePanel ID="UpdatePanelCountryState" runat="server"  EnableViewState="true" UpdateMode="Conditional">
                <ContentTemplate> --%>

                 <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Country:<span class="spn1">*</span></label>
                <asp:DropDownList ID="ddlCountry" class="form-control fg2_inp1 inp_mst" runat="server"  AutoPostBack="true" onChange="CountryChange()" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>

            </div>

             <div id="div4" class="form-group fg2 fg2_mr sa_fg3 sa_640">
  <label for="email" class="fg2_la1">State:<span class="spn1"></span></label>
                 <asp:DropDownList ID="ddlState" class="form-control fg2_inp1 inp_mst" runat="server" onChange="CountryChange1()" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>

            </div>
            


              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">City:<span class="spn1"></span></label>

                <asp:DropDownList ID="ddlCity" class="form-control fg2_inp1 inp_mst" runat="server" ></asp:DropDownList>

            </div>

                    
           <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
      
               <div id="div5"  class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Postal Code:<span class="spn1"></span></label>
                                   <asp:TextBox ID="txtZipCode" class="form-control fg2_inp1" placeholder="Postal Code" runat="server" MaxLength="10" ></asp:TextBox>

              
              </div>
               <div id="divTinNumber" class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">TIN#:<span class="spn1"></span></label>
                                   <asp:TextBox ID="txtTinNumber" class="form-control fg2_inp1"  placeholder="TIN#" runat="server" MaxLength="50" ></asp:TextBox>

              
              </div>
                </div>
              <div class="clearfix"></div>
              <div class="devider divid"></div>

               <div class="form-group fg2 sa_fg4 sa_640_i">
                <label for="email" class="fg2_la1">Price Terms:<span class="spn1"></span></label>

                    <asp:DropDownList ID="ddlPriceTerm" class="form-control fg2_inp1" MaxLength="300"  runat="server" onchange="return ChangePriceTerm();" onfocus="getPreviousDDLPrice_SelectedVal()" ></asp:DropDownList>
                       <asp:TextBox ID="txtPriceTerm" class="form-control flt_l mar_tp1 tx_ara" placeholder="Price Terms" runat="server" TextMode="MultiLine"
                        onkeypress="return isTagMulti('cphMain_txtPriceTerm',event);" onkeydown="textCounter(cphMain_txtPriceTerm,295);" onkeyup="textCounter(cphMain_txtPriceTerm,295);" onblur="ReplaceTag('cphMain_txtPriceTerm',event);">
                    </asp:TextBox>
             
               
              </div>

               <div class="form-group fg2 sa_fg4 sa_640_i">
                <label for="email" class="fg2_la1">Payment Terms:<span class="spn1"></span></label>

                   <asp:DropDownList ID="ddlPaymentTerm"  class="form-control fg2_inp1" MaxLength="300" runat="server" onchange="return ChangePaymentTerm();" onfocus="getPreviousDDLPayment_SelectedVal()"></asp:DropDownList>
                  <asp:TextBox ID="txtPaymentTerm" class="form-control flt_l mar_tp1 tx_ara" placeholder="Payment Terms" runat="server" TextMode="MultiLine"
                        onkeypress="return isTagMulti('cphMain_txtPaymentTerm',event);" onkeydown="textCounter(cphMain_txtPaymentTerm,295);" onkeyup="textCounter(cphMain_txtPaymentTerm,295);" onblur="ReplaceTag('cphMain_txtPaymentTerm',event);">
                    </asp:TextBox>
              
              </div>

              <div class="form-group fg2 sa_fg4 sa_640_i">
                <label for="email" class="fg2_la1">Delivery Terms:<span class="spn1"></span></label>
                  
                <asp:DropDownList ID="ddlDeliveryTerm"  class="form-control fg2_inp1"  MaxLength="300" runat="server" onchange="return ChangeDeliveryTerm();"  onfocus="getPreviousDDLDelivery_SelectedVal()" ></asp:DropDownList>
                        <asp:TextBox ID="txtDeliveryTerm" class="form-control flt_l mar_tp1 tx_ara" placeholder="Delivery Terms" runat="server"
                       TextMode="MultiLine"
                        onkeypress="return isTagMulti('cphMain_txtDeliveryTerm',event);" onkeydown="textCounter(cphMain_txtDeliveryTerm,295);" onkeyup="textCounter(cphMain_txtDeliveryTerm,295);" onblur="ReplaceTag('cphMain_txtDeliveryTerm',event);">
                    </asp:TextBox>
               
                 
              </div>

          <div class="clearfix"></div>
          <div class="devider divid"></div>

          <p class="plc2 tr_l">Contact Details</p>
           <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
            <label for="email" class="fg2_la1">Mobile:<span class="spn1"></span></label>
           <asp:TextBox ID="txtMobile" class="form-control fg2_inp1" placeholder="Mobile#" runat="server" MaxLength="50" onkeydown="return isNumber(event)"></asp:TextBox>
                <p class="error" id="ErrorMsgMob" style="display:none;color:red">Please enter Valid Mobile Number</p>
           
                
          </div>
          <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
            <label for="email" class="fg2_la1">Phone:<span class="spn1"></span></label>
                              <asp:TextBox ID="txtPhone" class="form-control fg2_inp1" placeholder="Phone#" runat="server" MaxLength="50"  onkeydown="return isNumber(event)"></asp:TextBox>
          </div>
          <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
            <label for="email" class="fg2_la1">Mail ID:<span class="spn1"></span></label>
                 <asp:TextBox ID="txtEmail" class="form-control fg2_inp1" runat="server" placeholder="Mail ID" MaxLength="100" ></asp:TextBox>
                 <p class="error" id="ErrorMsgEmail" style="display:none;color:red">Please enter valid email address <br />eg: abc@gmail.com</p>
   
           
          </div>
          <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
            <label for="email" class="fg2_la1">Website:<span class="spn1"></span></label>
                            <asp:TextBox ID="txtWebSite" class="form-control fg2_inp1" placeholder="Website" runat="server" MaxLength="100" ></asp:TextBox>

          </div>

          <div class="clearfix"></div>
          <div class="devider divid"></div>

          <p class="plc2 tr_l">Media</p>
                  <asp:HiddenField ID="hiddenMedia" runat="server" />
                 <div id="divMedia" class="eachform" style="width:100%;"  runat="server" >
                     
             </div>
       

          <div class="clearfix"></div>
          <div class="free_sp"></div>
          <div class="devider divid"></div>

          <!---other_contact_1_started-->
           <p class="plc2 tr_l bl1"><a href="#frm1" title="Click Here to Add Other Details"><span class="badge bel_add"><i class="fa fa-plus"></i></span> Other Contact<span class="spn1"></span></a></p>

           <div class="frm1" id="frm1" style="display: none;">
             <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Name:<span class="spn1">*</span></label>
                <asp:TextBox ID="txtNameOne" class="form-control fg2_inp1 inp_mst" placeholder="Name" runat="server" MaxLength="100"  onblur="RemoveTag(this)" ></asp:TextBox>

              </div>



              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Address 1:<span class="spn1">*</span></label>
                                  <asp:TextBox ID="txtAddressOne" class="form-control fg2_inp1 inp_mst" placeholder="Address 1" runat="server" MaxLength="150"  onblur="RemoveTag(this)"></asp:TextBox>

                
              </div>
              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Address 2:<span class="spn1"></span></label>
                                  <asp:TextBox ID="txtAddressOne2" class="form-control fg2_inp1 inp_mst" placeholder="Address 2" runat="server" MaxLength="150"  onblur="RemoveTag(this)"></asp:TextBox>
              </div>
              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Address 3:<span class="spn1"></span></label>
                                  <asp:TextBox ID="txtAddressOne3" class="form-control fg2_inp1 inp_mst" placeholder="Address 3" runat="server" MaxLength="150"  onblur="RemoveTag(this)"></asp:TextBox>
              </div>
           
              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Mobile:<span class="spn1"></span></label>
                   <asp:TextBox ID="txtMobileOne" class="form-control fg2_inp1" runat="server" placeholder="Mobile#" MaxLength="50"  onkeydown="return isNumber(event)" ></asp:TextBox>
                 <p class="error" id="ErrorMsgMobileOne" style="display:none;color:red">Please enter Valid Mobile Number</p>
            
                
              </div>
              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Phone:<span class="spn1"></span></label>
                                  <asp:TextBox ID="txtPhoneOne" class="form-control fg2_inp1" runat="server" placeholder="Phone#" MaxLength="50" onblur="RemoveTag(this)" onkeydown="return isNumber(event)"></asp:TextBox>

                
              </div>
              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Website:<span class="spn1"></span></label>
                                  <asp:TextBox ID="txtWebsiteOne" class="form-control fg2_inp1" placeholder="Website" runat="server" MaxLength="100"  onblur="RemoveTag(this)"></asp:TextBox>

               
              </div>
              <div class="form-group fg2 sa_o_2 sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Mail Delivary Allowed:<span class="spn1"></span></label>
                <div class="input-group dt_wdt">
                  <div class="input-group-addon date1 chec_bx">
                    <div class="check1 c_flt_n">
                      <div class="">
                        <label class="switch">
                        <asp:CheckBox ID="cbxAllowOtherMailOne" runat="server"   />
                    
                          <span class="slider_tog round"></span>
                        </label>
                      </div>
                    </div>
                  </div>
                      <asp:TextBox ID="txtEmailOne" class="form-control fg2_inp1 inp_bdr tr_l inp_chec" placeholder="Email" runat="server" MaxLength="100"  onblur="RemoveTag(this)"></asp:TextBox>
                 <p class="error" id="ErrorMsgEmailOne" style="display:none;color:red">Please enter valid email address <br />eg: abc@gmail.com</p>
                
                  </div>
                </div>

            <!---other_contact_1_closed--->
               <script>
                   function clearvl() {
                       document.getElementById("cphMain_txtNameOne").value = "";
                       document.getElementById("cphMain_txtAddressOne").value = "";
                       document.getElementById("cphMain_txtAddressOne2").value = "";
                       document.getElementById("cphMain_txtAddressOne3").value = "";
                       document.getElementById("cphMain_txtMobileOne").value = "";
                       document.getElementById("cphMain_txtPhoneOne").value = "";
                       document.getElementById("cphMain_txtWebsiteOne").value = "";
                       document.getElementById("cphMain_txtEmailOne").value = "";
                       document.getElementById("cphMain_txtNameOne").focus();
                       return false;
                   }
               </script>
              <!---other_contact_2_started-->

            <p class="plc2"><button class="spn1 pull-right cle_oth" onclick="return clearvl();"><i class="fa fa-refresh"></i> Clear</button></p>
            <div class="clearfix"></div>
            <div class="devider divid"></div>
            
            <p class="plc2 tr_l bl2"><a href="#frm1" title="Click Here to Add Other Details">
              <span class="badge bel_add"><i class="fa fa-plus"></i></span> Other Contact</a></p>

              <div class="frm2" id="frm2" style="display: none;">
             <div class="form-group fg2 fg2_mr sa_fg3">
                <label for="email" class="fg2_la1">Name:<span class="spn1">*</span></label>
                                 <asp:TextBox ID="txtNameTwo" class="form-control fg2_inp1 inp_mst" placeholder="Name" runat="server" MaxLength="100"  onblur="RemoveTag(this)"></asp:TextBox>

              
              </div>




              <div class="form-group fg2 fg2_mr sa_fg3">
                <label for="email" class="fg2_la1">Address 1:<span class="spn1">*</span></label>
                                      <asp:TextBox ID="txtAddressTwo" class="form-control fg2_inp1 inp_mst" placeholder="Address 1" runat="server" MaxLength="150"  onblur="RemoveTag(this)"></asp:TextBox>

                
              </div>
              <div class="form-group fg2 fg2_mr sa_fg3 ">
                <label for="email" class="fg2_la1">Address 2:<span class="spn1"></span></label>
                                                    <asp:TextBox ID="txtAddressTwo2" class="form-control fg2_inp1 inp_mst" placeholder="Address 3" runat="server" MaxLength="150"  onblur="RemoveTag(this)"></asp:TextBox>

              </div>
              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Address 3:<span class="spn1"></span></label>
                                      <asp:TextBox ID="txtAddressTwo3" class="form-control fg2_inp1 inp_mst" placeholder="Address 3" runat="server" MaxLength="150"  onblur="RemoveTag(this)"></asp:TextBox>
              </div>
           
              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Mobile:<span class="spn1"></span></label>
                  <asp:TextBox ID="txtMobileTwo"  class="form-control fg2_inp1" runat="server" placeholder="Mobile#" MaxLength="50"  onkeydown="return isNumber(event)" ></asp:TextBox>
                <p class="error" id="ErrorMsgMobileTwo" style="display:none;color:red">Please enter Valid Mobile Number</p>
          
              
              </div>
              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Phone:<span class="spn1"></span></label>
                                  <asp:TextBox ID="txtPhoneTwo" class="form-control fg2_inp1" runat="server" placeholder="Phone#" MaxLength="50"  onblur="RemoveTag(this)" onkeydown="return isNumber(event)"></asp:TextBox>

           
              </div>
              <div class="form-group fg2 fg2_mr sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Website:<span class="spn1"></span></label>
                                  <asp:TextBox ID="txtWebsiteTwo" class="form-control fg2_inp1" placeholder="Website" runat="server" MaxLength="100"  onblur="RemoveTag(this)"></asp:TextBox>

              
              </div>
              <div class="form-group fg2 sa_o_2 sa_fg3 sa_640">
                <label for="email" class="fg2_la1">Mail Delivary Allowed:<span class="spn1"></span></label>
                <div class="input-group dt_wdt">
                  <div class="input-group-addon date1 chec_bx">
                    <div class="check1 c_flt_n">
                      <div class="">
                        <label class="switch">
                       <asp:CheckBox ID="cbxAllowOtherMailTwo" runat="server"  />
              
                          <span class="slider_tog round"></span>
                        </label>
                      </div>
                    </div>
                  </div>
                       <asp:TextBox ID="txtEmailTwo" class="form-control fg2_inp1 inp_bdr tr_l inp_chec" runat="server" MaxLength="100"  onblur="RemoveTag(this)"></asp:TextBox>
                 <p class="error" id="ErrorMsgEmailTwo" style="display:none;color:red">Please enter valid email address <br />eg: abc@gmail.com</p>
            
                 
                  </div>
                </div>
                   <script>
                       function clearvl2() {
                           document.getElementById("cphMain_txtNameTwo").value = "";
                           document.getElementById("cphMain_txtAddressTwo").value = "";
                           document.getElementById("cphMain_txtAddressTwo2").value = "";
                           document.getElementById("cphMain_txtAddressTwo3").value = "";
                           document.getElementById("cphMain_txtMobileTwo").value = "";
                           document.getElementById("cphMain_txtPhoneTwo").value = "";
                           document.getElementById("cphMain_txtWebsiteTwo").value = "";
                           document.getElementById("cphMain_txtEmailTwo").value = "";
                           document.getElementById("cphMain_txtNameTwo").focus();
                           return false;
                       }
               </script>
              <!---other_contact_2_closed-->
              <p class="plc2"><button class="spn1 pull-right cle_oth" onclick="return clearvl2();"><i class="fa fa-refresh"></i> Clear</button></p>
            </div>

              
           </div>

            </div>

  <div class="clearfix"></div>
  <div class="devider divid"></div>
               <div id="olddis" style="display:none">
                     <div class="eachform" style="width:65%; display:none  ">
   
             <h2 style="padding-top:1%";>Cost Centre*</h2>
            <div class="subform" style="width:65px; padding-top:1%; margin-left: 15.5%;">
             <input name="CostCenter" checked="true" class="form2"  runat="server" type="radio" id="radioCostYes" onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();" />
                <h3 style="padding-top:1%";>Yes</h3>   
                </div>
             <div class="subform" style="width:65px; padding-top:1%; margin-left: 0%;"> 
             <input name="CostCenter" runat="server" class="form2" type="radio" id="radioCostNo" onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();" />
              <h3 style="padding-top:1%";>No</h3>  
                 </div>                                      
  </div>





    <div id="divLedgerBlock" style="display:none">
        <div id="divTdsTcs" runat="server" style="display:none">
     <div class="eachform" style="width:47%; float:left; ">
    
     <h2 style="padding-top:1%";>TDS Applicable*</h2>
          
          <div class="subform" style="width:65px; padding-top:1%; margin-left: 10%;">
             <input name="TDS" class="form2" runat="server" type="radio" id="radioTDSyes" onclick="radioTDSclick();" onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();" />
              <h3 style="padding-top:1%";>Yes</h3>  
              </div>
          <div class="subform" style="width:65px; padding-top:1%; margin-left: 0%;">    
             <input name="TDS" runat="server" checked="true" type="radio" class="form2" id="radioTDSno" onclick="radioTDSclick();" onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();" />
             <h3 style="padding-top:1%";>No</h3> 
              </div>                                    
                                           
  </div>
  <div class="eachform" style="width:47%; float:right; ">
     <h2 style="padding-top:1%";>TCS Applicable*</h2>
           <div class="subform" style="width:65px; padding-top:1%; margin-left: 11%;">
             <input name="TCS" runat="server" class="form2" type="radio" id="radioTCSyes" onclick="radioTCSclick();" onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();" />
                <h3 style="padding-top:1%";>Yes</h3>   
               </div>  
       <div class="subform" style="width:65px; padding-top:1%; margin-left: 0%;">  
             <input name="TCS" runat="server" checked="true" type="radio" id="radioTCSno" class="form2" onclick="radioTCSclick();" onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();" />
                <h3 style="padding-top:1%";>No</h3>    
           </div>                                   
  </div>
 

      <div class="eachform" style="width:47%; float:left; " id="divTDS">
     <h2 style="padding-top:1%";>TDS*</h2>
      <asp:DropDownList ID="ddlTDS" Height="30px" Width="300px" onchange="return  IncrmntConfrmCounter();" onkeypress="return isTag(event)" onkeydown="return isTag(event)" class="form1" runat="server" Style="margin-left: 5%;"></asp:DropDownList>
     
    </div>
   <div class="eachform" style="width:47%; float:right; " id="divTCS">
     <h2 style="padding-top:1%";>TCS*</h2>
        <asp:DropDownList ID="ddlTCS" Height="30px" Width="300px" onchange="return  IncrmntConfrmCounter();" onkeypress="return isTag(event)" onkeydown="return isTag(event)" class="form1" runat="server" Style="margin-left: 5%;"></asp:DropDownList>
      
    </div>

        </div>
    
         <div class="eachform" style="width:47%; float:left; ">
   
               <h2 style="padding-top:1%";>Opening Balance</h2>
             <%--  <asp:TextBox ID="txtOpenBalanceDeb" Height="30px" onblur="return  IncrmntConfrmCounter();" onchange="return changeAmnt('cphMain_txtOpenBalanceDeb');"    onkeypress="return isDecimalNumber(event,'cphMain_txtOpenBalanceDeb')" onkeydown="return isDecimalNumber(event,'cphMain_txtOpenBalanceDeb')"  Width="282px" class="form1" runat="server" MaxLength="12" Style=" margin-left: 5%;text-align:right" ></asp:TextBox onkeyup="addCommas(cphMain_txtCreditLimit.value);"  onkeydown="return isNumberWithDigit(event)"  onblur="return BlurNotNumber('cphMain_txtCreditLimit');">--%>
      
    </div>
    <div class="eachform" style="width:47%; float:right; ">
 <%--   <h2 style="padding-top:1%";>Credit Balance</h2>
         <asp:TextBox ID="txtOpenBalanceCre" Height="30px" onblur="return  IncrmntConfrmCounter();" onchange="return changeAmnt('cphMain_txtOpenBalanceCre');"    onkeypress="return isDecimalNumber(event,'cphMain_txtOpenBalanceCre')" onkeydown="return isDecimalNumber(event,'cphMain_txtOpenBalanceCre')"  Width="282px" class="form1" runat="server" MaxLength="12" Style=" margin-left: 5%;text-align:right;" ></asp:TextBox>--%>

           <div   runat="server"    style="float: right; width: 89%; display:block;">
                   <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; float: left; border: 1px solid #9ba48b; margin-bottom: 1px;margin-left: 28%;width: 67%;">
    <%--  <label class="radio">
        <input type="radio" checked="true"  onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" id="typdebit" style="display:block" name="optradio" />
       <i></i>  Debit</label>
      <label class="radio">
        <input type="radio" id="typecredit"  onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" style="display:block" name="optradio" />
        <i></i> Credit</label>--%>
                         <div class="subform" style="width:65px; padding-top:1%; margin-left: 11%;width: 30%;">
                <h3 style="padding-top:1%";>Debit</h3>   
               </div>  
       <div class="subform" style="width:65px; padding-top:1%; margin-left: 9%;width: 30%;">  
                <h3 style="padding-top:1%";>Credit</h3>    
           </div> 



                </div>
              </div>
      
    </div>

           
          <%--   EVM-0027 Aug21--%>

      

         




              







            
                     <div id="div18" class="eachform" style="width:94%;display:none "  >

                  <h2 id="ContactHeadThree" class="Caption" style="padding-top:1%;  cursor:pointer;" OnClick="VisibleContactThree()" >Other Contact</h2>
                          <h2 id="ClearThree" class="Caption" style="padding-top:1%;  display:none; cursor:pointer; margin-left:429px" OnClick="ClearContactThree()">Clear-</h2>
                  </div>

                         <div id="divNewContactThree" class="eachform" style="display:none;">

                     <div id="div19" class="eachform" style="width:47%;">
                <h2 style="padding-top:1%;">Name*</h2>

                <asp:TextBox ID="txtNameThree" Height="30px" Width="282px" class="form1" runat="server" MaxLength="100" Style=" margin-left: 5%;" onblur="RemoveTag(this)"></asp:TextBox>

            </div>

              <div class="eachform" style="width:47%; float:right; ">
                <h2 style="padding-top:1%";>Address*</h2>

                <asp:TextBox ID="txtAddressThree" Height="30px" Width="282px" class="form1" runat="server" MaxLength="150" Style="margin-left: 5%;" onblur="RemoveTag(this)"></asp:TextBox>

            </div>

                      <div id="div20" class="eachform" style="width:47%;">
                <h2 style="padding-top:1%;">Mobile</h2>

                <asp:TextBox ID="txtMobileThree" Height="30px" Width="282px" class="form1" runat="server" MaxLength="50" Style=" margin-left: 5%;" onkeydown="return isNumber(event)"></asp:TextBox>
                <p class="error" id="ErrorMsgMobileThree" style="display:none">Please enter Valid Mobile Number</p>
            </div>

              <div class="eachform" style="width:47%; float:right; ">
                <h2 style="padding-top:1%";>Phone</h2>

                <asp:TextBox ID="txtPhoneThree" Height="30px" Width="282px" class="form1" runat="server" MaxLength="50" Style="margin-left: 5%;" onblur="RemoveTag(this)" onkeydown="return isNumber(event)"></asp:TextBox>
                
            </div>


                  <div id="div21" class="eachform" style="width:47%;">
                       <div >  <asp:CheckBox ID="cbxAllowOtherMailThree" onkeydown="return DisableEnter(event);" runat="server" style="padding-left:35%;" />
                    <label style="color:rgb(135, 146, 116);font-family:Calibri;" for="cphMain_cbxAllowOtherMailThree">Mail delivery allowed</label>
               </div> 
                <h2 style="padding-top:1%;">Email</h2>

                <asp:TextBox ID="txtEmailThree" Height="30px" Width="282px" class="form1" runat="server" MaxLength="100" Style="margin-left: 5%;" onblur="RemoveTag(this)"></asp:TextBox>
                <p class="error" id="ErrorMsgEmailThree" style="display:none; ">Please enter valid email address</p>
            </div>

              <div class="eachform" style="width:47%; float:right;">
                <h2 style="padding-top:1%;">Website</h2>

                <asp:TextBox ID="txtWebsiteThree" Height="30px" Width="282px" class="form1" runat="server" MaxLength="100" Style="margin-left: 5%;" onblur="RemoveTag(this)"></asp:TextBox>

            </div>
                     
                 </div>

                 </div>
            <br />
                   

            <div class="eachform">
                <div class="subform"style="width: 40%;">

                   </div>
            </div>
               </div>
                               <asp:DropDownList ID="ddlCurrency" Height="30px" Width="300px" onchange="return  IncrmntConfrmCounter();" onkeypress="return isTag(event)" onkeydown="return isTag(event)" class="form1" runat="server" Style="margin-left: 5%;display:none "></asp:DropDownList>

   <!--Buttons_Area_started-->
 <div class="sub_cont pull-right">
  <div class="save_sec">
        <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update"  OnClientClick="return SaveValidate();" OnClick="btnUpdate_Click" />
                     <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close"  OnClientClick="return SaveValidate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return SaveValidate();" />
                      <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return SaveValidate();" />
                                <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>

                            <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                      <asp:Button ID="btnClose" runat="server" class="btn sub4" Text="Close" OnClientClick=" CloseWindow();"  />
               
    <%--<button type="submit" class="btn sub1">Save</button>
    <button type="submit" >Save & Close</button>
    <button type="submit" class="btn sub2">Clear</button>
    <button type="submit" >Cancel</button>--%>
  </div>
     </div>
     </div>
        </div>
      </div>
    </div>
   </div>
<div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">

       <asp:Button ID="btnUpdatef" runat="server" class="btn sub1" Text="Update"  OnClientClick="return SaveValidate();" OnClick="btnUpdate_Click" />
                     <asp:Button ID="btnUpdateClosef" runat="server" class="btn sub3" Text="Update & Close"  OnClientClick="return SaveValidate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnAddf" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return SaveValidate();" />
                      <asp:Button ID="btnAddClosef" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return SaveValidate();" />
                                <asp:Button ID="btnClearf" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
                                  <asp:Button ID="btnCancelf" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />

        
                      <asp:Button ID="btnClosef" runat="server" class="btn sub4" Text="Close" OnClientClick=" CloseWindow();"  />
      </div>
         </div>
  
     
     <a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
<i class="fa fa-save"></i>
</a>
<!--buttons_area_closed--->
     <script>
         function opensave() {

             document.getElementById("cphMain_mySave").style.width = "120px";
         }

         function closesave() {
             document.getElementById("cphMain_mySave").style.width = "0px";
         }
</script>
     <a href="#" type="button" class="list_b" title="Back to List" onclick="return ConfirmMessage();" id="A1" runat="server">
    <i class="fa fa-arrow-circle-left"></i>
  </a>
            <!---new--->











    <script>
        //  $("#asg").addClass("disable");
        $('#cphMain_cbxLedgerSts').on('click', function () {
            if ($('#cphMain_cbxLedgerSts').is(':checked')) {
                $("#asg").children().attr("disabled", false);
            }
            else {
                $("#asg").children().attr("disabled", "disabled");
                $("#costg").children().attr("disabled", "disabled");
            }
        });

    </script>
        <script>
            //  $("#asg").addClass("disable");
            $('#cphMain_cbxCsCntrSts').on('click', function () {
                if ($('#cphMain_cbxCsCntrSts').is(':checked')) {
                    $("#costg").children().attr("disabled", false);
                }
                else {
                    $("#costg").children().attr("disabled", "disabled");
                }
            });

    </script>
    <style>
        .disable {
 
  pointer-events: none;
  opacity: 0.4;
 
}
.disable div,
.disable textarea {
  overflow: hidden;
}
    </style>

   

    
      
   <script>
       $(document).ready(function () {
           $("#hide").click(function () {
               $(".c1h").hide();
           });
           $("#show").click(function () {
               $(".c1h").show();
           });
       });
</script>

<!----hide/Show_section2---->
<script>
    $(document).ready(function () {
        $("#hide").click(function () {
            $(".c2h").hide();
        });
        $("#show1").click(function () {
            $(".c2h").show();
        });
    });
</script>
<!---customer_details section--->
<script>
    $(document).ready(function () {
        $(".bn").click(function () {
            $(".frm").toggle(600);
        });
    });
</script>
<!---customer_details section_closed--->

<!---other_contact_1_started--->
<script>
    $(document).ready(function () {
        $(".bl1").click(function () {
            $(".frm1").toggle(600);
        });
    });
</script>
<!---other_contact_1_closed--->

<!---other_contact_2--->
<script>
    $(document).ready(function () {
        $(".bl2").click(function () {
            $(".frm2").toggle(600);
        });
    });
</script>
<!--save_pop up_open-->


      
    
    <script>

        function radioTDSclick() {

            if (document.getElementById("cphMain_HiddenTaxEnable").value == "1") {

                if (document.getElementById("cphMain_radioTDSyes").checked == true) {
                    if (document.getElementById("cphMain_HiddenViewSts").value != "1") {
                        document.getElementById("cphMain_ddlTDS").disabled = false;
                    }
                }
                else {
                    document.getElementById("cphMain_ddlTDS").disabled = true;
                    document.getElementById("cphMain_ddlTDS").value = "--SELECT TDS--";
                }
            }
        }
        function radioTCSclick() {
            if (document.getElementById("cphMain_HiddenTaxEnable").value == "1") {

                if (document.getElementById("cphMain_radioTCSyes").checked == true) {
                    if (document.getElementById("cphMain_HiddenViewSts").value != "1") {
                        document.getElementById("cphMain_ddlTCS").disabled = false;
                    }
                }
                else {
                    document.getElementById("cphMain_ddlTCS").disabled = true;
                    document.getElementById("cphMain_ddlTCS").value = "--SELECT TCS--";
                }
            }
        }
        function SubLedgerClick() {
            if (document.getElementById("cphMain_cbxLedgerSts").checked == true) {
                if (document.getElementById("cphMain_chkSubLedger").checked == true) {
                    document.getElementById("cphMain_ddlLedger").disabled = false;
                    $("#divddlLedger").children().attr("disabled", false);

                    $('input.Achead').attr("disabled", false);
                    $('input.acgrp').attr("disabled", "disabled");

                }
                else {
                    $("#divddlLedger").children().attr("disabled", "disabled");

                    $('input.Achead').attr("disabled", "disabled");
                    document.getElementById("cphMain_ddlLedger").disabled = true;
                    $('input.acgrp').attr("disabled", false);
                }
            }

        }
        function ledgerStsClick(str) {


            // document.getElementById("asg").disabled = false;
            if (document.getElementById("cphMain_HiddenViewSts").value != "1") {

                CreditLimitChange('cphMain_txtCreditLimit');
                CreditPeriodChange('cphMain_txtCreditPeriod');

                if (document.getElementById("cphMain_cbxLedgerSts").checked == true) {

                    document.getElementById("cphMain_txtCreditLimit").disabled = false;
                    document.getElementById("cphMain_txtCreditPeriod").disabled = false;

                    document.getElementById("cphMain_cbxCsCntrSts").disabled = false;
                    if (document.getElementById("cphMain_cbxCsCntrSts").checked == true) {
                        document.getElementById("cphMain_ddlCC").disabled = false;
                        document.getElementById("cphMain_rdIncome").disabled = false;
                        document.getElementById("cphMain_rdExpense").disabled = false;

                        if (document.getElementById("<%=HiddenCodeFormate.ClientID%>").value == "1") {
                        if (document.getElementById("<%=HiddenCustomerCode.ClientID%>").value == "1") {
                            document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = false;
                        }
                    }
                }
                else {
                    document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;

                    document.getElementById("cphMain_ddlCC").value = "--SELECT COST GROUP--";
                    document.getElementById("cphMain_rdIncome").checked = true;
                    document.getElementById("cphMain_ddlCC").disabled = true;
                    document.getElementById("cphMain_rdIncome").disabled = true;
                    document.getElementById("cphMain_rdExpense").disabled = true;


                    if (document.getElementById("<%=HiddenCustomerCode.ClientID%>").value == "1") {
                        document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;
                        document.getElementById("<%=txtCostCntrCode.ClientID%>").value = "";
                    }

                }
                if (document.getElementById("cphMain_HiddenTaxEnable").value == "1") {

                    document.getElementById("cphMain_radioTDSyes").disabled = false;
                    document.getElementById("cphMain_radioTDSno").disabled = false;
                    document.getElementById("cphMain_radioTCSyes").disabled = false;
                    document.getElementById("cphMain_radioTCSno").disabled = false;

                    document.getElementById("cphMain_ddlTDS").disabled = true;
                    document.getElementById("cphMain_ddlTCS").disabled = true;
                }
                document.getElementById("cphMain_txtOpenBalanceDeb").disabled = false;
                document.getElementById("cphMain_typdebit").disabled = false;
                document.getElementById("cphMain_typecredit").disabled = false;


                if (document.getElementById("cphMain_HiddenAcntGrpChngSts").value == "0") {
                    $('input.acgrp').attr("disabled", false);
                    document.getElementById("cphMain_ddlLedger").disabled = false;

                }
                else {
                    $('input.acgrp').attr("disabled", "disabled");

                    document.getElementById("cphMain_ddlLedger").disabled = false;
                }

                //EVM-0027 Aug 21

                if (document.getElementById("cphMain_chkSubLedger").checked == true) {

                    $('input.acgrp').attr("disabled", "disabled");
                    //  document.getElementById("cphMain_ddlAccountGrp").disabled = false;
                    document.getElementById("cphMain_ddlLedger").disabled = false;
                }

                document.getElementById("cphMain_chkSubLedger").disabled = false;

                if (document.getElementById("cphMain_chkSubLedger").checked == false) {

                    $('input.acgrp').attr("disabled", false);
                    document.getElementById("cphMain_ddlLedger").disabled = true;
                }
                //END



                if (document.getElementById("<%=HiddenCustomerCode.ClientID%>").value == "1") {

                    if (document.getElementById("<%=HiddenCodeFormate.ClientID%>").value == "1") {
                        document.getElementById("<%=txtLedgrCode.ClientID%>").disabled = false;

                    }
                    else {

                        document.getElementById("<%=txtLedgrCode.ClientID%>").disabled = true;
                        document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;


                        var strUserID = '<%=Session["USERID"]%>';
                        var strOrgIdID = '<%=Session["ORGID"]%>';
                        var strCorpID = '<%=Session["CORPOFFICEID"]%>';
                        var ActGrpId = "";
                        if (document.getElementById("<%=ddlAccountGrp.ClientID%>").value == "--SELECT ACCOUNT GROUP--") {
                            ActGrpId = document.getElementById("<%=HiddenDefaultAcntGrpId.ClientID%>").value;
                        }
                        else {
                            IncrmntConfrmCounter();
                            ActGrpId = document.getElementById("<%=ddlAccountGrp.ClientID%>").value;

                        }


                        if (str == 0) {
                            var ldgrsts = 0;

                            if (ActGrpId != "" && strUserID != '') {

                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    contentType: "application/json; charset=utf-8",
                                    url: "gen_Customer_Master.aspx/LoadLedgerCode",
                                    data: '{strUserID: "' + strUserID + '",ActGrpId: "' + ActGrpId + '",strOrgIdID: "' + strOrgIdID + '",ldgrsts: "' + ldgrsts + '",strCorpID: "' + strCorpID + '"}',

                                    dataType: "json",
                                    success: function (data) {
                                        if (data.d != "") {

                                            document.getElementById("<%=txtLedgrCode.ClientID%>").value = data.d;
                                        }

                                    }
                                });
                            }
                        }
                        else if (str == 2) {//evm 0044
                            var ldgrsts = 1;
                            if (document.getElementById("<%=ddlLedger .ClientID%>").value == "--SELECT CUSTOMER--") {
                                ActGrpId = 0;
                            }
                            else {
                                IncrmntConfrmCounter();
                                ActGrpId = document.getElementById("<%=ddlLedger .ClientID%>").value;

                             }
                             if (ActGrpId != "" && strUserID != '') {

                                 $.ajax({
                                     type: "POST",
                                     async: false,
                                     contentType: "application/json; charset=utf-8",
                                     url: "gen_Customer_Master.aspx/LoadLedgerCode",
                                     data: '{strUserID: "' + strUserID + '",ActGrpId: "' + ActGrpId + '",strOrgIdID: "' + strOrgIdID + '",ldgrsts: "' + ldgrsts + '",strCorpID: "' + strCorpID + '"}',

                                     dataType: "json",
                                     success: function (data) {
                                         if (data.d != "") {

                                             document.getElementById("<%=txtLedgrCode.ClientID%>").value = data.d;
                                        }

                                    }
                                });
                            }
                        }

                }





            }
        }

        else {
                // $("#costg").children().attr("disabled", false);
            document.getElementById("cphMain_txtCreditLimit").disabled = true;
            document.getElementById("cphMain_txtCreditPeriod").disabled = true;

            if (document.getElementById("<%=HiddenCustomerCode.ClientID%>").value == "1") {
                    document.getElementById("<%=txtLedgrCode.ClientID%>").disabled = true;
                    document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;
                    document.getElementById("<%=txtCostCntrCode.ClientID%>").value = "";
                    document.getElementById("<%=txtLedgrCode.ClientID%>").value = "";

                }

                $('input.acgrp').attr("disabled", "disabled");
                $('input.Achead').attr("disabled", "disabled");
                $('input.acgrp').val("--SELECT ACCOUNT GROUP--");
                $('input.Achead').val("--SELECT LEDGER--");
                document.getElementById("cphMain_ddlLedger").disabled = true;
                document.getElementById("cphMain_cbxCsCntrSts").checked = false;
                document.getElementById("cphMain_cbxCsCntrSts").disabled = true;
                document.getElementById("cphMain_ddlCC").value = "--SELECT COST GROUP--";
                document.getElementById("cphMain_rdIncome").checked = true;
                document.getElementById("cphMain_ddlCC").disabled = true;
                document.getElementById("cphMain_rdIncome").disabled = true;
                document.getElementById("cphMain_rdExpense").disabled = true;

                if (document.getElementById("cphMain_HiddenTaxEnable").value == "1") {

                    document.getElementById("cphMain_radioTDSyes").checked = false;
                    document.getElementById("cphMain_radioTDSno").checked = true;
                    document.getElementById("cphMain_radioTCSyes").checked = false;
                    document.getElementById("cphMain_radioTCSno").checked = true;

                    document.getElementById("cphMain_radioTDSyes").disabled = true;
                    document.getElementById("cphMain_radioTDSno").disabled = true;
                    document.getElementById("cphMain_radioTCSyes").disabled = true;
                    document.getElementById("cphMain_radioTCSno").disabled = true;

                    document.getElementById("cphMain_ddlTDS").disabled = true;
                    document.getElementById("cphMain_ddlTCS").disabled = true;

                    document.getElementById("cphMain_ddlTCS").value = "--SELECT TCS--";
                    document.getElementById("cphMain_ddlTDS").value = "--SELECT TDS--";



                }
                document.getElementById("cphMain_txtOpenBalanceDeb").disabled = true;
                document.getElementById("cphMain_typdebit").disabled = true;
                document.getElementById("cphMain_typdebit").checked = true;
                document.getElementById("cphMain_typecredit").disabled = true;
                document.getElementById("cphMain_txtOpenBalanceDeb").value = "";
                document.getElementById("cphMain_chkSubLedger").disabled = true;

            }
        }
    }



    function ChangeCostGroup() {
        IncrmntConfrmCounter();

        if (document.getElementById("<%=HiddenCustomerCode.ClientID%>").value == "1") {

                if (document.getElementById("<%=HiddenCodeFormate.ClientID%>").value == "1") {
                    document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = false;

                }
                else {

                    var CstGrpId = document.getElementById("<%=ddlCC.ClientID%>").value;


                    if (CstGrpId != 0 && CstGrpId != "--SELECT COST GROUP--") {

                        var orgID = '<%= Session["ORGID"] %>';
                        var corptID = '<%= Session["CORPOFFICEID"] %>';

                        var ldsts = 1;
                        var CodeSts = document.getElementById("<%=HiddenCodeFormate.ClientID%>").value;

                        if (CodeSts == 0) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                contentType: "application/json; charset=utf-8",
                                url: "gen_Customer_Master.aspx/CrateCodeFormate",
                                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",CstGrpId: "' + CstGrpId + '"}',

                                dataType: "json",
                                success: function (data) {
                                    if (data.d != "") {

                                        document.getElementById("<%=txtCostCntrCode.ClientID%>").value = data.d;
                                    }

                                }
                            });
                        }
                    }
                    else {
                        document.getElementById("<%=txtCostCntrCode.ClientID%>").value = "";
                    }

                }

            }
        }

        function AcntGrpErrMsg() {
            $noCon("#divWarning").html("Please set the account group before adding customer");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;

        }
        function changeAmnt(obj) {
            var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
            var ObjVal = document.getElementById(obj).value.trim();
            if (FloatingValueMoney != "" && ObjVal != "") {
                ObjVal = parseFloat(ObjVal);
                document.getElementById(obj).value = ObjVal.toFixed(FloatingValueMoney);
            }
        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            //AutoCompleteAll();
            radioTDSclick();
            radioTCSclick();
            ledgerStsClick(1);
            //       SubLedgerClick();
            CheckSpecification();


            //    changeAmnt('cphMain_txtOpenBalanceCre');
            changeAmnt('cphMain_txtOpenBalanceDeb');
            changeAmnt('cphMain_txtCreditLimit');
            if (document.getElementById("<%=HiddenCheckMode.ClientID%>").value == "1") {
                document.getElementById("cphMain_cbxLedgerSts").disabled = true;
                // document.getElementById("cphMain_typecredit").checked = true;
                document.getElementById("cphMain_typecredit").disabled = true;
                // document.getElementById("cphMain_typdebit").checked = false;
                document.getElementById("cphMain_typdebit").disabled = true;
            }

            var CrncyAbrv = document.getElementById("<%=hiddenCurrencyAbbrv.ClientID%>").value;
            $au("#cphMain_txtCreditLimit").attr("placeholder", CrncyAbrv);
            $au("#cphMain_txtCreditPeriod").attr("placeholder", "Days");

        });


        function CheckSpecification() {

            if (document.getElementById("<%=HiddenViewSts.ClientID%>").value != "1") {

                if (document.getElementById("<%=HiddenBusinessSpecific.ClientID%>").value == "0" && document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "0") {

                    document.getElementById("cphMain_txtCustomerName").disabled = false;
                    document.getElementById("cphMain_ddlCustomerType").disabled = false;

                    document.getElementById("cphMain_ddlCustomerGroup").disabled = false;

                    //document.getElementById("cphMain_txtCreditLimit").disabled = true;
                    //document.getElementById("cphMain_txtCreditPeriod").disabled = true;

                    document.getElementById("cphMain_cbxStatus").disabled = false;

                    document.getElementById("div2").style.display = "block";

                    document.getElementById("cphMain_cbxLedgerSts").disabled = true;


                    $('input.acgrp').attr("disabled", "disabled");
                    document.getElementById("cphMain_cbxCsCntrSts").disabled = true;

                    if (document.getElementById("cphMain_HiddenTaxEnable").value == "1") {

                        document.getElementById("cphMain_radioTDSyes").disabled = true;
                        document.getElementById("cphMain_radioTDSno").disabled = true;
                        document.getElementById("cphMain_radioTCSyes").disabled = true;
                        document.getElementById("cphMain_radioTCSno").disabled = true;

                        document.getElementById("cphMain_ddlTDS").disabled = true;
                        document.getElementById("cphMain_ddlTCS").disabled = true;



                    }
                    document.getElementById("cphMain_txtblnce").disabled = true;
                    document.getElementById("cphMain_typdebit").disabled = true;

                    document.getElementById("cphMain_typecredit").disabled = true;






                }
                else if (document.getElementById("<%=HiddenBusinessSpecific.ClientID%>").value == "0" && document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "1") {


                    document.getElementById("cphMain_cbxLedgerSts").focus();

                    if (document.getElementById("cphMain_HiddenAcntGrpChngSts").value == "0") {
                        document.getElementById("cphMain_cbxLedgerSts").disabled = false;
                    }
                    else {
                        document.getElementById("cphMain_cbxLedgerSts").disabled = true;
                    }

                    document.getElementById("cphMain_txtCustomerName").disabled = true;
                    document.getElementById("cphMain_ddlCustomerType").disabled = true;

                    document.getElementById("cphMain_ddlCustomerGroup").disabled = false;

                    //document.getElementById("cphMain_txtCreditLimit").disabled = false;
                    //document.getElementById("cphMain_txtCreditPeriod").disabled = true;

                    document.getElementById("cphMain_cbxStatus").disabled = true;



                    document.getElementById("div2").style.display = "none";
                    //  document.getElementById("cphMain_cbxLedgerSts").disabled = true;


                    $('input.acgrp').attr("disabled", "disabled");
                    document.getElementById("cphMain_cbxCsCntrSts").disabled = true;




                }
                else if (document.getElementById("<%=HiddenBusinessSpecific.ClientID%>").value == "1" && document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "0") {


                    document.getElementById("cphMain_txtCustomerName").disabled = false;
                    document.getElementById("cphMain_ddlCustomerType").disabled = false;

                    document.getElementById("cphMain_ddlCustomerGroup").disabled = true;

                    //document.getElementById("cphMain_txtCreditLimit").disabled = true;
                    //document.getElementById("cphMain_txtCreditPeriod").disabled = false;

                    document.getElementById("cphMain_cbxStatus").disabled = false;
                    document.getElementById("cphMain_cbxLedgerSts").disabled = true;
                    document.getElementById("div2").style.display = "block";

                    $('input.acgrp').attr("disabled", "disabled");
                    document.getElementById("cphMain_cbxCsCntrSts").disabled = true;

                    if (document.getElementById("cphMain_HiddenTaxEnable").value == "1") {

                        document.getElementById("cphMain_radioTDSyes").disabled = true;
                        document.getElementById("cphMain_radioTDSno").disabled = true;
                        document.getElementById("cphMain_radioTCSyes").disabled = true;
                        document.getElementById("cphMain_radioTCSno").disabled = true;

                        document.getElementById("cphMain_ddlTDS").disabled = true;
                        document.getElementById("cphMain_ddlTCS").disabled = true;



                    }
                    document.getElementById("cphMain_txtblnce").disabled = true;
                    document.getElementById("cphMain_typdebit").disabled = true;

                    document.getElementById("cphMain_typecredit").disabled = true;

                }

                else if (document.getElementById("<%=HiddenBusinessSpecific.ClientID%>").value == "1" && document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "1") {

                    document.getElementById("cphMain_txtCustomerName").disabled = false;
                    document.getElementById("cphMain_ddlCustomerType").disabled = false;

                    document.getElementById("cphMain_ddlCustomerGroup").disabled = false;

                    //document.getElementById("cphMain_txtCreditLimit").disabled = false;
                    //document.getElementById("cphMain_txtCreditPeriod").disabled = false;

                    document.getElementById("cphMain_cbxStatus").disabled = false;

                    document.getElementById("div2").style.display = "block";
                    if (document.getElementById("cphMain_HiddenAcntGrpChngSts").value == "0") {
                        document.getElementById("cphMain_cbxLedgerSts").disabled = false;
                    }
                    else {
                        document.getElementById("cphMain_cbxLedgerSts").disabled = true;
                    }

                }
    }
    else {
        $('input.acgrp').attr("disabled", "disabled");
    }
}


function isDecimalNumber(evt, textboxid) {
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
       </script>

       <script>
           function AmountChecking(textboxid) {

               var txtPerVal = document.getElementById(textboxid).value;
               //  alert(txtPerVal);

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
                       var FloatingValue = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
                       if (FloatingValue != "") {
                           var n = num.toFixed(FloatingValue);

                       }
                       document.getElementById('' + textboxid + '').value = n;

                   }
               }


           }
           function txtCCclick(x) {
               AmountChecking('cphMain_txtOpenBalanceDeb');
               changeAmnt(x);
               if (document.getElementById("cphMain_txtOpenBalanceDeb").value != "") {
                   //  document.getElementById("cphMain_DandC").style.display = "block";
               }
               else {

                   // document.getElementById("cphMain_DandC").style.display = "none";
                   // document.getElementById("cphMain_ddlTDS").value = "--SELECT TDS--";
               }
               // alert(document.getElementById("cphMain_txtOpenBalanceDeb").value);
               addCommasOpenBlnc(document.getElementById("cphMain_txtOpenBalanceDeb").value);

           }

           function changeAmnt(obj) {

               var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;

               var ObjVal = document.getElementById(obj).value.trim();
               ObjVal = ObjVal.replace(/,/g, "");
               // alert(ObjVal);
               if (FloatingValueMoney != "" && ObjVal != "") {

                   ObjVal = parseFloat(ObjVal);
                   // alert(ObjVal);
                   document.getElementById(obj).value = ObjVal.toFixed(FloatingValueMoney);
               }

               addCommasOpenBlnc(document.getElementById("cphMain_txtOpenBalanceDeb").value);
               addCommas(document.getElementById("cphMain_txtCreditLimit").value);
           }
    </script>

    
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

   
</asp:Content>
