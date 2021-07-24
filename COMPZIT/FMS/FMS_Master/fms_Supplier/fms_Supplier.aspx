<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Supplier.aspx.cs" Inherits="FMS_FMS_Master_fms_Supplier_fms_Supplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>


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
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            radioTDSclick();
            radioTCSclick();
            ledgerStsClick(0);
            //  changeAmnt('cphMain_txtOpenBalanceCre');
            changeAmnt('cphMain_txtblnce');
            changeAmnt('cphMain_txtCreditLimit');

            CheckSpecification();
            if (document.getElementById("<%=HiddenPurchaseMode.ClientID%>").value == "1") {
                document.getElementById("cphMain_cbxLedgerSts").disabled = true;
                document.getElementById("cphMain_typecredit").checked = true;
                document.getElementById("cphMain_typecredit").disabled = true;
                document.getElementById("cphMain_typdebit").checked = false;
                document.getElementById("cphMain_typdebit").disabled = true;
            }

            if (document.getElementById("<%=hiddenPMSDisplaySts.ClientID%>").value == "1") {
                document.getElementById("divContact").style.display = "block";
                document.getElementById("divCatgry").style.display = "block";
                document.getElementById("divRating").style.display = "block";
            }
            else {
                document.getElementById("divContact").style.display = "none";
                document.getElementById("divCatgry").style.display = "none";
                document.getElementById("divRating").style.display = "none";
            }
            LoadContactDtls();

        });

        function SubLedgerClick() {
            if (document.getElementById("cphMain_cbxLedgerSts").checked == true) {
                if (document.getElementById("cphMain_cbxSubLedger").checked == true) {
                    document.getElementById("cphMain_ddlLedger").disabled = false;
                    $('input.ldgr').attr("disabled", false);
                    $('input.acgrp').attr("disabled", "disabled");

                }
                else {
                    $('input.ldgr').attr("disabled", "disabled");
                    document.getElementById("cphMain_ddlLedger").disabled = true;
                    $('input.acgrp').attr("disabled", false);
                }
            }

        }


        function SuccessMsg() {

            $noCon("#success-alert").html("Supplier details inserted successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdMsg() {

            $noCon("#success-alert").html("Supplier details updated successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SundryCreditorSelect() {
            $noCon("#divWarning").html("Please define an account head for sundry creditor before creating new supplier");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function CanclUpdMsg() {
            $noCon("#divWarning").html("This action is  denied! This Supplier is already cancelled .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function DupName() {

            $noCon("#divWarning").html("Duplication Error!. Supplier name can’t be duplicated.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("cphMain_txtName").style.borderColor = "red";
            document.getElementById("cphMain_txtName").focus();
            return false;
        }
        function DupLedgrName() {

            $noCon("#divWarning").html("Duplication Error!. Ledger name can’t be duplicated.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("cphMain_txtName").style.borderColor = "red";
            document.getElementById("cphMain_txtName").focus();
            return false;
        }
        function AcntGrpErrMsg() {
            $noCon("#divWarning").html("Please define an account group for the supplier before creating new supplier");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon(window).scrollTop(0);
            return false;

        }
        function DupNameCost() {

            $noCon("#divWarning").html("Duplication Error!. Cost centre name can’t be duplicated.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("cphMain_txtName").style.borderColor = "red";
            document.getElementById("cphMain_txtName").focus();
            return false;
        }

        function DuplicationLedgrCodeMsg() {

            $noCon("#divWarning").html("Duplication Error!. Ledger code can’t be duplicated.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

            });
            document.getElementById("cphMain_txtLedgrCode").style.borderColor = "red";
            document.getElementById("cphMain_txtLedgrCode").focus();
            $noCon(window).scrollTop(0);
            return false;

        }
        function DuplicationCstCntrCodeMsg() {
            $noCon("#divWarning").html("Duplication Error!. Cost centre code can’t be duplicated.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

            });
            document.getElementById("cphMain_txtCostCntrCode").style.borderColor = "red";
            document.getElementById("cphMain_txtCostCntrCode").focus();
            $noCon(window).scrollTop(0);
            return false;
        }
        function SundryDebtorSelect() {
            $noCon("#divWarning").html("Please define an account head for sundry creditor before creating new supplier");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });

        }

        function ConfirmMessage() {

            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Supplier_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
            }
            else {
                window.location.href = "fms_Supplier_List.aspx";
            }
            return false;

        }

    </script>
    <script>
        function PassSavedSupplier(intLedgerId) {
            if (window.opener != null && !window.opener.closed) {
                window.opener.GetValueFromChildSupplier(intLedgerId);
            }
            window.close();
        }


//----contact details----

        function LoadContactDtls() {

            if (document.getElementById("<%=hiddenContactDtls.ClientID%>").value != "[]" && document.getElementById("<%=hiddenContactDtls.ClientID%>").value != "") {

                var EditVal = document.getElementById("<%=hiddenContactDtls.ClientID%>").value;

                var findAtt2 = '\\"\\[';
                var reAtt2 = new RegExp(findAtt2, 'g');
                var resAtt2 = EditVal.replace(reAtt2, '\[');

                var findAtt3 = '\\]\\"';
                var reAtt3 = new RegExp(findAtt3, 'g');
                var resAtt3 = resAtt2.replace(reAtt3, '\]');

                var jsonAtt = $.parseJSON(resAtt3);
                for (var key in jsonAtt) {
                    if (jsonAtt.hasOwnProperty(key)) {
                        if (jsonAtt[key].CNTCT_ID != "") {

                            EditContact(jsonAtt[key].CNTCT_ID, jsonAtt[key].CNTCT_NAME, jsonAtt[key].CNTCT_ADDRESS, jsonAtt[key].CNTCT_MOBILE, jsonAtt[key].CNTCT_PHONE, jsonAtt[key].CNTCT_WEBSITE, jsonAtt[key].CNTCT_EMAIL);

                        }
                    }
                }
            }
            else {
                AddContact();
            }
        }

        var Counter = 0;

        function AddContact() {

            var FrecRow = '<tr id="ContactRowId_' + Counter + '" >';

            FrecRow += '<td id="tdIdContact' + Counter + '" style="display: none;width:0%;">' + Counter + '</td>';

            FrecRow += '<td><input class="fg2_inp2 brd_r" type="text" id="txtCntctName' + Counter + '" name="txtCntctName' + Counter + '" onblur="return BlurContact(' + Counter + ',\'txtCntctName' + Counter + '\')" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" maxlength="100" placeholder="Name" /></td>';
            FrecRow += '<td><input class="fg2_inp2 brd_r" type="text" id="txtCntctAddress' + Counter + '" name="txtCntctAddress' + Counter + '" onblur="return BlurContact(' + Counter + ',\'txtCntctAddress' + Counter + '\')" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" maxlength="100" placeholder="Address" /></td>';
            FrecRow += '<td><input class="fg2_inp2 brd_r" type="text" id="txtCntctMobile' + Counter + '" name="txtCntctMobile' + Counter + '" onblur="return BlurContact(' + Counter + ',\'txtCntctMobile' + Counter + '\')" onkeydown="return isNumber(event);" onkeypress="return isNumber(event);" onkeyup="IncrmntConfrmCounter()" maxlength="20" placeholder="Mobile#" /></td>';
            FrecRow += '<td><input class="fg2_inp2 brd_r" type="text" id="txtCntctPhone' + Counter + '" name="txtCntctPhone' + Counter + '" onblur="return BlurContact(' + Counter + ',\'txtCntctPhone' + Counter + '\')" onkeydown="return isNumber(event);" onkeypress="return isNumber(event);" onkeyup="IncrmntConfrmCounter()" maxlength="20" placeholder="Phone#" /></td>';
            FrecRow += '<td><input class="fg2_inp2 brd_r" type="text" id="txtCntctWebsite' + Counter + '" name="txtCntctWebsite' + Counter + '" onblur="return BlurContact(' + Counter + ',\'txtCntctWebsite' + Counter + '\')" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" maxlength="100" placeholder="Website" /></td>';
            FrecRow += '<td><input class="fg2_inp2 brd_r" type="text" id="txtCntctEmail' + Counter + '" name="txtCntctEmail' + Counter + '" onblur="return BlurContact(' + Counter + ',\'txtCntctEmail' + Counter + '\')" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" maxlength="100" placeholder="Mail ID" /></td>';

            FrecRow += '<td>';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button title="Add" id="btnAddContact' + Counter + '" class="btn act_btn bn2" onclick="return CheckaddMoreRows(' + Counter + ');" ><i class="fa fa-plus-circle"></i></button>';
            FrecRow += '<button title="Delete" id="btnDeleteContact' + Counter + '" class="btn act_btn bn3" onclick="return RemoveRows(' + Counter + ');" ><i class="fa fa-trash"></i></button>';
            FrecRow += '</div></td>';

            FrecRow += '<td id="tdEvt' + Counter + '" style="width:0%;display: none;">INS</td>';
            FrecRow += '<td id="tdDtlId' + Counter + '" style="width:0%;display: none;">0</td>';

            FrecRow += '</tr>';

            jQuery('#tableContact').append(FrecRow);

            if (document.getElementById("<%=HiddenViewSts.ClientID%>").value == "1") {
                document.getElementById("btnAddContact" + Counter).disabled = true;
                document.getElementById("btnDeleteContact" + Counter).disabled = true;
                document.getElementById("txtCntctName" + Counter).disabled = true;
                document.getElementById("txtCntctAddress" + Counter).disabled = true;
                document.getElementById("txtCntctMobile" + Counter).disabled = true;
                document.getElementById("txtCntctPhone" + Counter).disabled = true;
                document.getElementById("txtCntctWebsite" + Counter).disabled = true;
                document.getElementById("txtCntctEmail" + Counter).disabled = true;
            }

            Counter++;
        }

        var EditCounter = 0;

        function EditContact(CNTCT_ID, CNTCT_NAME, CNTCT_ADDRESS, CNTCT_MOBILE, CNTCT_PHONE, CNTCT_WEBSITE, CNTCT_EMAIL) {

            AddContact();
            document.getElementById('tdDtlId' + EditCounter).innerHTML = CNTCT_ID;
            document.getElementById("txtCntctName" + EditCounter).value = CNTCT_NAME;
            document.getElementById("txtCntctAddress" + EditCounter).value = CNTCT_ADDRESS;
            document.getElementById("txtCntctMobile" + EditCounter).value = CNTCT_MOBILE;
            document.getElementById("txtCntctPhone" + EditCounter).value = CNTCT_PHONE;
            document.getElementById("txtCntctWebsite" + EditCounter).value = CNTCT_WEBSITE;
            document.getElementById("txtCntctEmail" + EditCounter).value = CNTCT_EMAIL;
            document.getElementById("tdEvt" + EditCounter).innerHTML = "UPD";

            if ((parseInt(document.getElementById("cphMain_hiddenContactRows").value)-1) > parseInt(EditCounter)) {
                document.getElementById("btnAddContact" + EditCounter).disabled = true;
            }

            if (document.getElementById("<%=HiddenViewSts.ClientID%>").value == "1") {
                document.getElementById("btnAddContact" + EditCounter).disabled = true;
                document.getElementById("btnDeleteContact" + EditCounter).disabled = true;
                document.getElementById("txtCntctName" + EditCounter).disabled = true;
                document.getElementById("txtCntctAddress" + EditCounter).disabled = true;
                document.getElementById("txtCntctMobile" + EditCounter).disabled = true;
                document.getElementById("txtCntctPhone" + EditCounter).disabled = true;
                document.getElementById("txtCntctWebsite" + EditCounter).disabled = true;
                document.getElementById("txtCntctEmail" + EditCounter).disabled = true;
            }

            EditCounter++;

        }

        function BlurContact(x, obj) {

            RemoveTag(obj);
            //if (obj == "txtCntctMobile" || obj == "txtCntctPhone") {
            //    RemoveNaN_OnBlur(obj)
            //}

            if (CheckAndHighlight(x, 1, obj) == false) {
                return false;
            }
        }

        function CheckaddMoreRows(x) {

            document.getElementById("txtCntctName" + x).style.borderColor = "";
            document.getElementById("txtCntctAddress" + x).style.borderColor = "";

            if (CheckAndHighlight(x, 0, null) == true) {
                AddContact();

                var idlast = $('#tableContact tr:last').attr('id');
                var LastId = "";
                if (idlast != "") {
                    var res = idlast.split("_");
                    LastId = res[1];
                }
                document.getElementById("txtCntctName" + LastId).focus();
                document.getElementById("btnAddContact" + x).disabled = true;
                return false;
            }
            else {
                return false;
            }

            return false;
        }

        function CheckAndHighlight(x, Mode, obj) {

            var ret = true;

            var Table = document.getElementById("tableContact");

            var Name = document.getElementById("txtCntctName" + x).value.trim();
            var Address = document.getElementById("txtCntctAddress" + x).value.trim();
            var Mobile = document.getElementById("txtCntctAddress" + x).value.trim();

            document.getElementById("txtCntctName" + x).style.borderColor = "";
            document.getElementById("txtCntctAddress" + x).style.borderColor = "";

            if (Mode == "1") {
                if (Address == "" && obj == "txtCntctAddress" + x) {
                    document.getElementById("txtCntctAddress" + x).style.borderColor = "Red";
                    document.getElementById("txtCntctAddress" + x).focus();
                    ret = false;
                }
                if (Name == "" && obj == "txtCntctName" + x) {
                    document.getElementById("txtCntctName" + x).style.borderColor = "Red";
                    document.getElementById("txtCntctName" + x).focus();
                    ret = false;
                }
            }
            else {
                if (Address == "") {
                    document.getElementById("txtCntctAddress" + x).style.borderColor = "Red";
                    document.getElementById("txtCntctAddress" + x).focus();
                    ret = false;
                }
                if (Name == "") {
                    document.getElementById("txtCntctName" + x).style.borderColor = "Red";
                    document.getElementById("txtCntctName" + x).focus();
                    ret = false;
                }
            }

            if (ret == true) {

                for (var i = 0; i < Table.rows.length; i++) {

                    if (Table.rows[i].cells[0].innerHTML != "") {

                        var validRowID = (Table.rows[i].cells[0].innerHTML);

                        var NameAll = document.getElementById("txtCntctName" + validRowID).value.trim();
                        var AddressAll = document.getElementById("txtCntctAddress" + validRowID).value.trim();

                        if (x != validRowID && Name == NameAll && Address == AddressAll) {
                            document.getElementById("txtCntctName" + x).style.borderColor = "Red";
                            document.getElementById("txtCntctName" + x).focus();
                            $("#divWarning").html("Contacts cannot be duplicated!");
                            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            ret = false;
                        }
                    }
                }
            }
            else {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                ret = false;
            }

            return ret;
        }

        function RemoveRows(removeNum) {

            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to delete selected contact details?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    var row_index = jQuery('#ContactRowId_' + removeNum).index();

                    var evt = document.getElementById("tdEvt" + removeNum).innerHTML;

                    if (evt == "UPD") {
                        var detailId = document.getElementById("tdDtlId" + removeNum).innerHTML;
                    }

                    jQuery('#ContactRowId_' + removeNum).remove();

                    var idlast = $('#tableContact tr:last').attr('id');
                    var LastId = "";
                    if (idlast != "") {
                        var res = idlast.split("_");
                        LastId = res[1];
                    }

                    document.getElementById("btnAddContact" + LastId).disabled = false;

                    var Table = document.getElementById("tableContact");
                    if (Table.rows.length < 1) {
                        AddContact();
                    }
                }
                else {
                    return false;
                }
            });
            return false;
        }

        function ValidateContactDtls() {

            var ret = true;
            var flag = 0;

            var Table = document.getElementById("tableContact");

            for (var x = 0; x < Table.rows.length; x++) {

                if (Table.rows[x].cells[0].innerHTML != "") {

                    var validRowID = (Table.rows[x].cells[0].innerHTML);

                    var Name = document.getElementById("txtCntctName" + validRowID).value.trim();
                    var Address = document.getElementById("txtCntctAddress" + validRowID).value.trim();

                    if ((Table.rows.length > 1) || (Table.rows.length == 1 && (Name != "" || Address != ""))) {
                        if (CheckAndHighlight(validRowID, 0, null) == false) {
                            ret = false;
                        }
                        flag = 1;
                    }

                }
            }

            if (ret == true) {

                if (flag == 1) {
                    document.getElementById("cphMain_hiddenContactRows").value = Table.rows.length;
                }
                else {
                    document.getElementById("cphMain_hiddenContactRows").value = "";
                }

            }

            return ret;
        }


        function CheckRating(obj) {

            var Rating = document.getElementById("cphMain_txtRating").value;
            Rating = Math.round(Rating * 2) / 2;
            document.getElementById("cphMain_txtRating").value = Rating;

            if (Rating == "" || parseFloat(Rating) < 0) {
                document.getElementById("cphMain_txtRating").value = "0";
            }
            else if (parseFloat(Rating) > 5) {
                document.getElementById("cphMain_txtRating").value = "5";
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenupd" runat="server" />
    <asp:HiddenField ID="HiddenFieldQryString" runat="server" />
    <asp:HiddenField ID="HiddenFieldLedgerId" runat="server" />
    <asp:HiddenField ID="HiddenFieldDecimalCnt" runat="server" />
    <asp:HiddenField ID="Hiddenreturnfun" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="hiddenTaxEnabled" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="hiddenCostCntrId" runat="server" />
    <asp:HiddenField ID="HiddenCostCntrCnclId" runat="server" />
    <asp:HiddenField ID="HiddenAcntGrpSts" runat="server" />
    <asp:HiddenField ID="HiddenViewSts" runat="server" />
    <asp:HiddenField ID="HiddenAccountSpecific" runat="server" />
    <asp:HiddenField ID="HiddenBusinessSpecific" runat="server" />
    <asp:HiddenField ID="HiddenAccountGrp" runat="server" />
    <asp:HiddenField ID="HiddenPurchaseMode" runat="server" />
    <asp:HiddenField ID="HiddenAcntGrpChngSts" runat="server" />
    <asp:HiddenField ID="HiddenCodeSts" runat="server" />
    <asp:HiddenField ID="HiddenCodeFormate" runat="server" />
    <asp:HiddenField ID="HiddenDefaultAcntGrpId" runat="server" />
    <asp:HiddenField ID="hiddenContactDtls" runat="server" />
    <asp:HiddenField ID="hiddenContactRows" runat="server" />
    <asp:HiddenField ID="hiddenCodeNumberFrmt" runat="server" />
    <asp:HiddenField ID="hiddenPMSDisplaySts" runat="server" />

  <div id="divLinkSection" runat="server">
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="fms_Supplier_List.aspx">Supplier</a></li>
        <li class="active">Add Supplier</li>
    </ol>
 </div>

    <div class="myAlert-bottom alert alert-danger" id="divWarning" style="display: none">
        <button type="button" class="close" data-dismiss="alert">x</button>
    </div>
    <div class="myAlert-top alert alert-success" id="success-alert" style="display: none">
        <button type="button" class="close" data-dismiss="alert">x</button>
    </div>
    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">         
            <div class="content_box1 cont_contr">
                <h2>
                    <asp:Label ID="lblEntry" runat="server"></asp:Label>
                </h2>

                <div class="table_box tb_scr">
                    <div class="add_sec">
                        <div class="col-md-12 clm" id="DivContainer" runat="server">

                            <div class="form-group fg2">
                                <label for="email" class="fg2_la1">Name:<span class="spn1">*</span></label>
                                <asp:TextBox ID="txtName" autocomplete="off" runat="server" MaxLength="100" class="form-control fg2_inp1 inp_mst" onchange="return  IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)"></asp:TextBox>
                            </div>

                           <div id="divCatgry" class="form-group fg2" style="display:none;">
                                <label for="email" class="fg2_la1">Category:<span class="spn1"></span></label>
                                 <asp:DropDownList ID="ddlVendorCategory" class="form-control fg2_inp1 fg_chs1" runat="server">
                                 </asp:DropDownList>
                           </div>
                              
                            <div class="form-group fg2">
                                <label for="email" class="fg2_la1">Address 1:<span class="spn1">*</span></label>
                                <asp:TextBox  class="form-control fg2_inp1 inp_mst" ID="txtAddress" onchange="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" MaxLength="499" runat="server" Style="resize: none;" autocomplete="off"></asp:TextBox>
                            </div>

                            <div class="form-group fg2">
                                <label for="email" class="fg2_la1">Address 2:<span class="spn1">&nbsp;</span></label>
                                <asp:TextBox class="form-control fg2_inp1" ID="txtAddress2" onchange="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" MaxLength="499" runat="server" Style="resize: none;" autocomplete="off"></asp:TextBox>
                            </div>

                            <div class="form-group fg2">
                                <label for="email" class="fg2_la1">Address 3:<span class="spn1">&nbsp;</span></label>
                                <asp:TextBox class="form-control fg2_inp1" ID="txtAddress3" onchange="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" MaxLength="499" runat="server" Style="resize: none;" autocomplete="off"></asp:TextBox>
                            </div>

                            <div class="form-group fg2">
                                <label for="email" class="fg2_la1">Contact#:<span class="spn1">&nbsp;</span></label>
                                <asp:TextBox class="form-control fg2_inp1" ID="txtContact" onchange="return  IncrmntConfrmCounter();" onkeydown="return DisableEnter(event)" onkeypress="return isNumber(event);" MaxLength="12" runat="server" autocomplete="off" Style="resize: none;"></asp:TextBox>
                            </div>

                            <div id="divRating" class="fg8" style="display:none;">
                                  <label for="email" class="fg2_la1">Rating:<span class="spn1"></span></label>
                                     <div class="input-group number-spinner grp_splr">
                                      <span class="input-group-btn data-dwn">
                                        <button class="btn btn-default btn-info blu_spn bt_splr" data-dir="dwn" onclick="return false;" id="btnMinus" runat="server"><span class="fa fa-minus"></span></button>
                                      </span>
                                          <asp:TextBox ID="txtRating" runat="server" autocomplete="off" MaxLength="4" class="form-control text-center in_splr" value="5" min="0" max="5" onblur="CheckRating('cphMain_txtRating');" onkeydown="return isDecimalNumber(event);" onkeypress="return isDecimalNumber(event);" onkeyup="IncrmntConfrmCounter()" ></asp:TextBox>
                                      <span class="input-group-btn data-up">
                                        <button class="btn btn-default btn-info blu_spn bt_splr" data-dir="up" onclick="return false;" id="btnPlus" runat="server"><span class="fa fa-plus"></span></button>
                                      </span>
                                     </div>
                            </div>

                            <div class="form-group col-md-6 padding5" style="display: none">
                                <label for="ddlCurrency" style="margin-bottom: 3px;">Currency*</label>
                                <asp:DropDownList ID="ddlCurrency" CssClass="form-control" class="form1" runat="server" onchange="return  IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)" Style="float: right; width: 75%;" >
                                </asp:DropDownList>
                            </div>

                            <div class="clearfix"></div>
                            <div class="devider divid"></div>

                            <div class="form-group fg2">
                                <label for="email" class="fg2_la1">Credit Period (Days):<span class="spn1">&nbsp;</span></label>
                                <asp:TextBox ID="txtCreditPeriod"  runat="server" MaxLength="4" class="form-control fg2_inp1" onchange="return  IncrmntConfrmCounter();" autocomplete="off" onkeypress="return isNumberAmountAA(event)" onkeydown="return isNumberAmountAA(event)"></asp:TextBox>
                            </div>

                            <div class="form-group fg2">
                                <label for="email" class="fg2_la1">Credit Limit:<span class="spn1">&nbsp;</span></label>
                                <asp:TextBox ID="txtCreditLimit" runat="server" MaxLength="12" class="form-control fg2_inp1" autocomplete="off" onchange="return   changeAmnt('cphMain_txtCreditLimit');" onkeypress="return isDecimalNumber(event,'cphMain_txtCreditLimit')" onkeydown="return isDecimalNumber(event,'cphMain_txtCreditLimit');" onblur="return AmountChecking('cphMain_txtCreditLimit');"></asp:TextBox>
                            </div>

                            <div class="code_box" id="divAccountSpecific" runat="server">


                                <div class="form-group fg2" id="DivConsdrLdgr" runat="server">
                                    <label for="email" class="fg2_la1 pad_l">Consider as ledger:<span class="spn1"></span></label>
                                    <div class="check1 mar_btm1">
                                        <div class="">
                                            <label class="switch" onclick="consider()">
                                                <input type="checkbox" id="cbxLedgerSts" onclick="ledgerStsClick(1);" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" />
                                                <span class="slider_tog round"></span>
                                            </label>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group fg2">
                                    <label for="email" class="fg2_la1">Account Group:<span class="spn1">&nbsp;</span></label>
                                    <asp:DropDownList ID="ddlAccountGrp" class="form-control fg2_inp1 acgrp" runat="server" onchange="ledgerStsClick(1);" onkeypress="return isTagEnter(event)">
                                    </asp:DropDownList>
                                </div>

                                <div class="clearfix"></div>

                                <div class="form-group fg2 fg2_mr" id="divCstCtr" runat="server" style="display: block;">
                                    <label for="email" class="fg2_la1 pad_l">Consider as cost centre:<span class="spn1"></span></label>
                                    <div class="check1 mar_btm1">
                                        <div class="">
                                            <label class="switch" onclick="con_cc()">
                                                <input type="checkbox" id="cbxCsCntrSts" onclick="ledgerStsClick(0);" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" />
                                                <span class="slider_tog round"></span>
                                            </label>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group fg2 fg2_mr" id="div2" runat="server">
                                    <label for="email" class="fg2_la1">Cost Group:<span class="spn1">&nbsp;</span></label>
                                    <asp:DropDownList ID="ddlCC" class="form-control fg2_inp1" runat="server" onchange="ChangeCostGroup();" onkeypress="return isTagEnter(event)">
                                    </asp:DropDownList>
                                </div>

     <div class="form-group fg2 fg2_mr sa_fg3 sa_480">
        <label for="email" class="fg2_la1 pad_l">Sub Ledger:<span class="spn1">&nbsp;</span></label>
        <div class="check1">
          <div class="">
            <label class="switch">
              <input type="checkbox" id="cbxSubLedger"  onchange="return SubLedgerClick();" onclick="ledgerStsClick(2);" onkeypress="return DisableEnter(event)" runat="server" >
              <span class="slider_tog round"></span>
            </label>
          </div>
        </div>
      </div>

      <div class="form-group fg2 fg2_mr sa_fg3 sa_480">
        <label for="email" class="fg2_la1">Account Head:<span class="spn1"></span></label>
          <div id="divLedger">
           <asp:DropDownList ID="ddlLedger"  class="form-control fg2_inp1 fg_chs2 ldgr" runat="server"  onchange="ledgerStsClick(2);" onblur="return  IncrmntConfrmCounter();"   onkeypress="return isTagEnter(event)" onkeydown="return DisableEnter(event);" >
          </asp:DropDownList>
          </div>
      </div>


                                <div class="clearfix"></div>
                                <div class="free_sp"></div>
                                <div class="devider divid"></div>

                                <div id="DivTdcTcs" runat="server">

                                <div class="form-group fg5 fg2_mr">

                                    <label for="email" class="fg2_la1 pad_l">TDS Applicable:<span class="spn1"></span></label>
                                    <div class="check1 mar_btm1">
                                        <div class="">
                                            <label class="switch">
                                                <input type="checkbox" class="bu" onclick="radioTDSclick();" onchange="IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)" onkeydown="return DisableEnter(event);" runat="server" id="radioTDSyes" />
                                                <span class="slider_tog round"></span>
                                            </label>
                                        </div>
                                    </div>
                                    <div id="divTDS" runat="server">
                                        <asp:DropDownList ID="ddlTDS" Class="form-control fg2_inp1 inp_mst" runat="server" onchange="return  IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)">
                                        </asp:DropDownList>
                                    </div>


                                </div>

                                <div class="form-group fg5 fg2_mr">
                                    <label for="email" class="fg2_la1 pad_l">TCS Applicable:<span class="spn1"></span></label>
                                    <div class="check1 mar_btm1">
                                        <div class="">
                                            <label class="switch">
                                                <input type="checkbox" class="bu1" onclick="radioTCSclick();" onchange="IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)" onkeydown="return DisableEnter(event);" runat="server" id="radioTCSyes" />
                                                <span class="slider_tog round"></span>
                                            </label>
                                        </div>
                                    </div>
                                    <div id="divTCS" runat="server">
                                        <asp:DropDownList ID="ddlTCS" class="form-control fg2_inp1 inp_mst" runat="server" onchange="return  IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                </div>

                                <div id="divCode" runat="server">

                                    <div class="form-group fg5 fg2_mr">
                                        <label for="email" class="fg2_la1">Ledger Code :<span class="spn1">&nbsp;</span></label>
                                        <asp:TextBox class="form-control fg2_inp1" ID="txtLedgrCode" runat="server" MaxLength="50" onclick="IncrmntConfrmCounter();" autocomplete="off" onkeypress="return DisableEnter(event)" onkeyup="textCounter(cphMain_txtLedgrCode,50)"></asp:TextBox>
                                    </div>

                                    <div class="form-group fg5 fg2_mr">
                                        <label for="email" class="fg2_la1">Cost Centre Code :<span class="spn1">&nbsp;</span></label>
                                        <asp:TextBox class="form-control fg2_inp1" ID="txtCostCntrCode" runat="server" MaxLength="50" onclick="IncrmntConfrmCounter();" autocomplete="off" onkeypress="return DisableEnter(event)" onkeyup="textCounter(cphMain_txtCostCntrCode,50)"></asp:TextBox>
                                    </div>

                                 <div class="form-group fg5 fg2_mr" id="divCodeSts" runat="server">
                                    <label for="TxtSuplrCode" class="fg2_la1">Supplier Code*</label>
                                    <asp:TextBox class="form-control fg2_inp1 " ID="TxtSuplrCode" onchange="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" MaxLength="499" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>

                                </div>

                                <div class="clearfix"></div>
                                <div class="free_sp"></div>
                                <div class="devider divid"></div>


                                <div class="form-group fg5 fg2_mr">
                                    <label class="fg2_la1">Opening Balance:<span class="spn1">&nbsp;</span></label>
                                    <asp:TextBox class="form-control fg2_inp1 tr_r" ID="txtblnce" runat="server" MaxLength="10" autocomplete="off" onblur="txtCCclick('cphMain_txtblnce');" onclick="IncrmntConfrmCounter();" onkeypress="return isDecimalNumber(event,'cphMain_txtblnce')" onkeydown="return isDecimalNumber(event,'cphMain_txtblnce')"></asp:TextBox>
                                </div>

                                <div class="form-group fg5 fg2_mr">
                                    <div class="row" id="DandC" runat="server">
                                        <div class="col-sm-10">
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" checked="true" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" id="typdebit" name="optradio" />
                                                <label class="form-check-label" for="gridRadios1">
                                                    Debit
                                                </label>
                                            </div>
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" id="typecredit" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" name="optradio" />
                                                <label class="form-check-label" for="gridRadios2">
                                                    Credit
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group fg5 fg2_mr">
                                    <label for="email" class="fg2_la1">Cost Centre Nature:<span class="spn1">&nbsp;</span></label>
                                    <div class="row">
                                        <div class="col-sm-10" id="Div1" runat="server">
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" checked="true" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" id="rdIncome" name="radioNature" />
                                                <label class="form-check-label" for="gridRadios1">Income</label>
                                            </div>
                                            <div class="form-check">
                                                <input type="radio" id="rdExpense" class="form-check-input" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" name="radioNature" />
                                                <label class="form-check-label" for="gridRadios2">Expense</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>


                            <div class="form-group fg5 fg2_mr">
                                <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1"></span></label>
                                <div class="check1">
                                    <div class="">
                                        <label class="switch">
                                            <input type="checkbox" id="cbxStatus" onchange="IncrmntConfrmCounter();" checked="true" onkeypress="return DisableEnter(event)" runat="server" />
                                            <span class="slider_tog round"></span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>


<div id="divContact" style="display:none;">

<div class="clearfix"></div>
  <div class="free_sp"></div>
  <div class="devider divid"></div>

<!--table_section_started-->
  <table class="table table-bordered">
    <thead class="thead1">
      <tr>
        <th class="th_b11 t_l">Name</th>
        <th class="th_b11 tr_l">Address</th>
        <th class="th_b6 tr_l">Mobile#</th>
        <th class="th_b6 tr_l">Phone#</th>
        <th class="th_b4 tr_l">Website</th>
        <th class="th_b2 tr_l">Mail ID</th>
        <th class="th_b6 tr_c">Actions</th>
      </tr>
    </thead>
    <tbody id="tableContact">
    </tbody>
  </table>

</div>
                        <div class="clearfix"></div>
                        <div class="devider divid"></div>

                        <div class="sub_cont pull-right">
                            <div class="save_sec">
                                <asp:Button ID="bttnsave" runat="server" OnClientClick="return ValidateSupplier();" class="btn sub1" Text="Save" OnClick="bttnsave_Click" />
                                <asp:Button ID="btnSaveAndClose" runat="server" OnClientClick="return ValidateSupplier();" class="btn sub3" Text="Save & Close" OnClick="bttnsave_Click" />

                                <asp:Button ID="btnUpdate" runat="server" OnClientClick="return ValidateSupplier();" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnUpdateAndClose" runat="server" OnClientClick="return ValidateSupplier();" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />


                                <asp:Button ID="btnCancel" runat="server" OnClientClick="return ConfirmMessage();" class="btn sub4" Text="Cancel" />
                                <asp:Button ID="btnClear" OnClientClick="return AlertClearAll();" runat="server" class="btn sub2" Text="Clear" />
                            </div>
                        </div>
                        </div>
                    </div>

                <div id="divList" runat="server" class="list_b" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
                    <i class="fa fa-arrow-circle-left"></i>
                </div>
                </div>
            </div>
            </div>
      
    <script>

        function AlertClearAll() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Supplier.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                return true;
            }
        }



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
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);

                    }
                    document.getElementById('' + textboxid + '').value = n;

                }
            }

            addCommas(textboxid);
        }

        function isNumber(evt) {
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
                return false;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
                // . period and numpad . period
            else if (keyCodes == 190 || keyCodes == 110) {
                var ret = true;
                return ret;

            }
            else if (keyCodes >= 65 && keyCodes <= 73) {
                ret = false;
            }
            else if (keyCodes == 78) {
                ret = false;
            }
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    ret = false;
                }
                return ret;
            }
        }

        function isNumberAmountAA(evt) {

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
            else if (keyCodes == 33 || keyCodes == 34 || keyCodes == 35 || keyCodes == 36 || keyCodes == 37 || keyCodes == 38 || keyCodes == 39 || keyCodes == 40 || keyCodes == 41 || keyCodes == 118 || keyCodes == 17) {

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

        function ValidateSupplier() {
            var ret = true;

            if (ValidateContactDtls() == false) {
                ret = false;
            }

            var Name = document.getElementById("cphMain_txtName").value.trim();
            var Currency = document.getElementById("cphMain_ddlCurrency").value;
            var Address = document.getElementById("cphMain_txtAddress").value.trim();
            var VndrCatgry = document.getElementById("cphMain_ddlVendorCategory").value;

            document.getElementById("cphMain_ddlCurrency").style.borderColor = "";
            document.getElementById("cphMain_txtAddress").style.borderColor = "";
            document.getElementById("cphMain_txtName").style.borderColor = "";

            if (document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "1") {

                document.getElementById("cphMain_ddlLedger").style.borderColor = "";
                $("#divLedger> input").css("borderColor", "");

                if (document.getElementById("cphMain_hiddenTaxEnabled").value == "1") {
                    var TCS = document.getElementById("cphMain_ddlTCS").value;
                    document.getElementById("cphMain_ddlTCS").style.borderColor = "";

                    if (document.getElementById("cphMain_cbxLedgerSts").checked == true && document.getElementById("cphMain_radioTCSyes").checked == true && TCS == "--SELECT TCS--") {
                        document.getElementById("cphMain_ddlTCS").style.borderColor = "Red";
                        document.getElementById("cphMain_ddlTCS").focus();
                        ret = false;
                    }
                }
                if (document.getElementById("cphMain_hiddenTaxEnabled").value == "1") {
                    document.getElementById("cphMain_ddlTDS").style.borderColor = "";
                    var TDS = document.getElementById("cphMain_ddlTDS").value;


                    if (document.getElementById("cphMain_cbxLedgerSts").checked == true && document.getElementById("cphMain_radioTDSyes").checked == true && TDS == "--SELECT TDS--") {
                        document.getElementById("cphMain_ddlTDS").style.borderColor = "Red";
                        document.getElementById("cphMain_ddlTDS").focus();
                        ret = false;
                    }
                }
                //   if (document.getElementById("cphMain_hiddenTaxEnabled").value == "1") {
                var CostGrp = document.getElementById("cphMain_ddlCC").value;
                document.getElementById("cphMain_ddlCC").style.borderColor = "";

                if (document.getElementById("cphMain_cbxLedgerSts").checked == true && document.getElementById("cphMain_cbxCsCntrSts").checked == true && CostGrp == "--SELECT COST GROUP--") {
                    document.getElementById("cphMain_ddlCC").style.borderColor = "Red";
                    document.getElementById("cphMain_ddlCC").focus();
                    ret = false;
                }

                if (document.getElementById("cphMain_cbxLedgerSts").checked == true) {
                    if (document.getElementById("cphMain_cbxSubLedger").checked == true) {
                        if (document.getElementById("cphMain_ddlLedger").value == "--SELECT SUPPLIER--") {
                            document.getElementById("cphMain_ddlLedger").style.borderColor = "Red";
                            $("#divLedger> input").css("borderColor", "Red");
                            document.getElementById("cphMain_ddlLedger").focus();
                            ret = false;
                        }
                    }
                }

            }
            //  }
            if (Address == "") {
                document.getElementById("cphMain_txtAddress").style.borderColor = "Red";
                document.getElementById("cphMain_txtAddress").focus();
                ret = false;
            }
            if (Currency == "" || Currency == "--SELECT CURRENCY--") {
                document.getElementById("cphMain_ddlCurrency").style.borderColor = "Red";
                document.getElementById("cphMain_ddlCurrency").focus();
                ret = false;
            }
            //if (VndrCatgry == "" || VndrCatgry == "--SELECT VENDOR CATEGORY--") {
            //    document.getElementById("cphMain_ddlVendorCategory").style.borderColor = "Red";
            //    document.getElementById("cphMain_ddlVendorCategory").focus();
            //    ret = false;
            //}
            if (Name == "") {
                document.getElementById("cphMain_txtName").style.borderColor = "Red";
                document.getElementById("cphMain_txtName").focus();
                ret = false;
            }

            var acntflg = true;
            var acntSts = document.getElementById("cphMain_HiddenAcntGrpSts").value;
            if (acntSts == 1) {
                acntflg = false;
            }
            else {
                acntflg = true;
            }
            if (document.getElementById("cphMain_HiddenAccountSpecific").value == "1") {
                if (document.getElementById("cphMain_cbxLedgerSts").checked == true) {
                }

                else {
                    acntflg = true;
                }
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
                $(window).scrollTop(0);
            }

            else if (ret == false && acntflg == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);

                //  AcntGrpErrMsg();
            }
            else if (ret == true && acntflg == false) {
                AcntGrpErrMsg();
                ret = false;
            }


            if (ret == true) {
                document.getElementById("cphMain_txtName").disabled = false;
                document.getElementById("cphMain_txtAddress").disabled = false;

                document.getElementById("cphMain_txtAddress2").disabled = false;
                document.getElementById("cphMain_txtAddress3").disabled = false;

                document.getElementById("cphMain_txtCreditPeriod").disabled = false;
                document.getElementById("cphMain_txtCreditLimit").disabled = false;
                document.getElementById("cphMain_cbxStatus").disabled = false;

            }

            return ret;
        }

        function radioTDSclick() {

            if (document.getElementById("cphMain_hiddenTaxEnabled").value == "1") {
                if (document.getElementById("cphMain_radioTDSyes").checked == true) {
                    if (document.getElementById("<%=HiddenViewSts.ClientID%>").value != "1") {
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
        if (document.getElementById("cphMain_hiddenTaxEnabled").value == "1") {
            if (document.getElementById("cphMain_radioTCSyes").checked == true) {
                if (document.getElementById("<%=HiddenViewSts.ClientID%>").value != "1") {
                        document.getElementById("cphMain_ddlTCS").disabled = false;
                    }
                }
                else {

                    document.getElementById("cphMain_ddlTCS").disabled = true;

                    document.getElementById("cphMain_ddlTCS").value = "--SELECT TCS--";
                }
            }
        }
        function CheckSpecification() {

            if (document.getElementById("<%=HiddenViewSts.ClientID%>").value != "1") {

                if (document.getElementById("<%=HiddenBusinessSpecific.ClientID%>").value == "0" && document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "0") {

                    document.getElementById("cphMain_txtName").disabled = false;
                    document.getElementById("cphMain_txtAddress").disabled = false;

                    document.getElementById("cphMain_txtAddress2").disabled = false;
                    document.getElementById("cphMain_txtAddress3").disabled = false;

                    document.getElementById("cphMain_txtCreditPeriod").disabled = false;
                    document.getElementById("cphMain_txtCreditLimit").disabled = false;
                    document.getElementById("cphMain_cbxStatus").disabled = false;


                    document.getElementById("cphMain_cbxLedgerSts").disabled = true;


                    $('input.acgrp').attr("disabled", "disabled");
                    document.getElementById("cphMain_cbxCsCntrSts").disabled = true;

                    if (document.getElementById("cphMain_hiddenTaxEnabled").value == "1") {

                        document.getElementById("cphMain_radioTDSyes").disabled = true;
                        //document.getElementById("cphMain_radioTDSno").disabled = true;
                        document.getElementById("cphMain_radioTCSyes").disabled = true;
                        //document.getElementById("cphMain_radioTCSno").disabled = true;

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

                    document.getElementById("cphMain_txtName").disabled = true;
                    document.getElementById("cphMain_txtAddress").disabled = true;

                    document.getElementById("cphMain_txtAddress2").disabled = true;
                    document.getElementById("cphMain_txtAddress3").disabled = true;

                    document.getElementById("cphMain_txtCreditPeriod").disabled = true;
                    document.getElementById("cphMain_txtCreditLimit").disabled = true;
                    document.getElementById("cphMain_cbxStatus").disabled = true;



                    //  $('input.acgrp').attr("disabled", "disabled");
                    //document.getElementById("cphMain_cbxCsCntrSts").disabled = false;

                    //if (document.getElementById("cphMain_hiddenTaxEnabled").value == "1") {

                    //    document.getElementById("cphMain_radioTDSyes").disabled = false;
                    //    document.getElementById("cphMain_radioTDSno").disabled = false;
                    //    document.getElementById("cphMain_radioTCSyes").disabled = false;
                    //    document.getElementById("cphMain_radioTCSno").disabled = false;

                    //    document.getElementById("cphMain_ddlTDS").disabled = false;
                    //    document.getElementById("cphMain_ddlTCS").disabled = false;



                    //}
                    //document.getElementById("cphMain_txtblnce").disabled = false;
                    //document.getElementById("cphMain_typdebit").disabled = false;

                    //document.getElementById("cphMain_typecredit").disabled = false;



                }
                else if (document.getElementById("<%=HiddenBusinessSpecific.ClientID%>").value == "1" && document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "0") {


                    document.getElementById("cphMain_txtName").disabled = false;
                    document.getElementById("cphMain_txtAddress").disabled = false;

                    document.getElementById("cphMain_txtAddress2").disabled = false;
                    document.getElementById("cphMain_txtAddress3").disabled = false;

                    document.getElementById("cphMain_txtCreditPeriod").disabled = false;
                    document.getElementById("cphMain_txtCreditLimit").disabled = false;
                    document.getElementById("cphMain_cbxStatus").disabled = false;
                    document.getElementById("cphMain_cbxLedgerSts").disabled = true;


                    $('input.acgrp').attr("disabled", "disabled");
                    document.getElementById("cphMain_cbxCsCntrSts").disabled = true;

                    if (document.getElementById("cphMain_hiddenTaxEnabled").value == "1") {

                        document.getElementById("cphMain_radioTDSyes").disabled = true;
                        //document.getElementById("cphMain_radioTDSno").disabled = true;
                        document.getElementById("cphMain_radioTCSyes").disabled = true;
                        //document.getElementById("cphMain_radioTCSno").disabled = true;

                        document.getElementById("cphMain_ddlTDS").disabled = true;
                        document.getElementById("cphMain_ddlTCS").disabled = true;



                    }
                    document.getElementById("cphMain_txtblnce").disabled = true;
                    document.getElementById("cphMain_typdebit").disabled = true;

                    document.getElementById("cphMain_typecredit").disabled = true;

                }

                else if (document.getElementById("<%=HiddenBusinessSpecific.ClientID%>").value == "1" && document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "1") {

                    document.getElementById("cphMain_txtName").disabled = false;
                    document.getElementById("cphMain_txtAddress").disabled = false;

                    document.getElementById("cphMain_txtAddress2").disabled = false;
                    document.getElementById("cphMain_txtAddress3").disabled = false;

                    document.getElementById("cphMain_txtCreditPeriod").disabled = false;
                    document.getElementById("cphMain_txtCreditLimit").disabled = false;
                    document.getElementById("cphMain_cbxStatus").disabled = false;


                    if (document.getElementById("cphMain_HiddenAcntGrpChngSts").value == "0") {
                        document.getElementById("cphMain_cbxLedgerSts").disabled = false;
                    }
                    else {
                        document.getElementById("cphMain_cbxLedgerSts").disabled = true;
                    }

                }
    }
}
function ChangeCostGroup() {
    IncrmntConfrmCounter();

    if (document.getElementById("<%=HiddenCodeSts.ClientID%>").value == "1") {

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
                                url: "fms_Supplier.aspx/CreateCodeFormate",
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

        function ledgerStsClick(str) {
            

            if (document.getElementById("<%=HiddenPurchaseMode.ClientID%>").value == "") {

                if (document.getElementById("<%=HiddenViewSts.ClientID%>").value != "1") {

                    if (document.getElementById("cphMain_cbxLedgerSts").checked == true) {
                       
                        //if (document.getElementById("<%=HiddenAcntGrpSts.ClientID%>").value == "1") {
                        //document.getElementById("cphMain_cbxLedgerSts").checked = false;
                        //document.getElementById("cphMain_cbxLedgerSts").disabled = true;
                        //document.getElementById("divNote").style.display = "block";
                        //document.getElementById("cphMain_cbxCsCntrSts").checked = false;
                        //document.getElementById("cphMain_cbxCsCntrSts").disabled = true;

                        //document.getElementById("cphMain_radioTDSyes").disabled = true;
                        //document.getElementById("cphMain_radioTDSno").disabled = true;
                        //document.getElementById("cphMain_radioTCSyes").disabled = true;
                        //document.getElementById("cphMain_radioTCSno").disabled = true;

                        //document.getElementById("cphMain_ddlTDS").disabled = true;
                        //document.getElementById("cphMain_ddlTCS").disabled = true;
                        //document.getElementById("cphMain_txtblnce").disabled = true;
                        //document.getElementById("cphMain_typdebit").disabled = true;
                        //document.getElementById("cphMain_typecredit").disabled = true;


                        //  }
                        //  else {

                        //   alert();
                        // document.getElementById("divNote").style.display = "none";


                        if (document.getElementById("cphMain_HiddenAcntGrpChngSts").value == "0") {
                            $('input.acgrp').attr("disabled", false);
                        }
                        else {
                            $('input.acgrp').attr("disabled", "disabled");
                        }
                        document.getElementById("cphMain_cbxCsCntrSts").disabled = false;
                        if (document.getElementById("cphMain_cbxCsCntrSts").checked == true) {



                            document.getElementById("cphMain_ddlCC").disabled = false;
                            document.getElementById("cphMain_rdIncome").disabled = false;
                            document.getElementById("cphMain_rdExpense").disabled = false;


                            if (document.getElementById("<%=HiddenCodeFormate.ClientID%>").value == "1") {
                                if (document.getElementById("<%=HiddenCodeSts.ClientID%>").value == "1") {
                                    document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = false;
                                }

                            }
                        }
                        else {
                            document.getElementById("cphMain_ddlCC").value = "--SELECT COST GROUP--";
                            document.getElementById("cphMain_rdIncome").checked = true;
                            document.getElementById("cphMain_ddlCC").disabled = true;
                            document.getElementById("cphMain_rdIncome").disabled = true;
                            document.getElementById("cphMain_rdExpense").disabled = true;


                            if (document.getElementById("<%=HiddenCodeSts.ClientID%>").value == "1") {
                                document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;
                                document.getElementById("<%=txtCostCntrCode.ClientID%>").value = "";
                            }

                        }



                        if (document.getElementById("cphMain_hiddenTaxEnabled").value == "1") {

                            document.getElementById("cphMain_radioTDSyes").disabled = false;
                            //document.getElementById("cphMain_radioTDSno").disabled = false;
                            document.getElementById("cphMain_radioTCSyes").disabled = false;
                            //document.getElementById("cphMain_radioTCSno").disabled = false;

                            if (document.getElementById("cphMain_radioTDSyes").checked == true) {
                                document.getElementById("cphMain_ddlTDS").disabled = false;
                            }
                            else {
                                document.getElementById("cphMain_ddlTDS").disabled = true;
                            }

                            if (document.getElementById("cphMain_radioTCSyes").checked == true) {
                                document.getElementById("cphMain_ddlTCS").disabled = false;
                            }
                            else {
                                document.getElementById("cphMain_ddlTCS").disabled = true;
                            }
                        }
                        document.getElementById("cphMain_txtblnce").disabled = false;
                        document.getElementById("cphMain_typdebit").disabled = false;
                        document.getElementById("cphMain_typecredit").disabled = false;
                        //  }


                        document.getElementById("cphMain_cbxSubLedger").disabled = false;

                        if (document.getElementById("cphMain_cbxSubLedger").checked == true) {
                            document.getElementById("cphMain_ddlLedger").disabled = false;
                            $('input.ldgr').attr("disabled", false);
                            $('input.acgrp').attr("disabled", "disabled");
                        }
                        else {
                            document.getElementById("cphMain_ddlLedger").disabled = true;
                            $('input.ldgr').attr("disabled", "disabled");
                            $('input.acgrp').attr("disabled", false);
                        }


                        //   document.getElementById("divLedgerBlock").style.display = "block";
                        //  document.getElementById("cphMain_divCstCtr").style.display = "block";

                        if (document.getElementById("<%=HiddenCodeSts.ClientID%>").value == "1") {

                            if (document.getElementById("<%=HiddenCodeFormate.ClientID%>").value == "1") {
                                document.getElementById("<%=txtLedgrCode.ClientID%>").disabled = false;

                            }
                            else {
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
                                if (str == 1) {
                                    var ldgrsts = 1;//evm 0044
                                    if (ActGrpId != "" && strUserID != '') {
                                        var Details = PageMethods.LoadLedgerCode(strUserID, ActGrpId, strOrgIdID,ldgrsts, strCorpID, function (response) {

                                            var SucessDetails = response;


                                            if (SucessDetails != "") {

                                                document.getElementById("<%=txtLedgrCode.ClientID%>").value = SucessDetails;
                                            }
                                            else {
                                                //   window.location = 'fms_Sales_Master_List.aspx';
                                            }
                                        });
                                    }
                                }
                                else if (str == 2) {//evm 0044
                                    var ldgrsts = 2;
                                 
                                    if (document.getElementById("<%=ddlLedger .ClientID%>").value == "--SELECT SUPPLIER--") {
                                        ActGrpId = 0;
                                   }
                                   else {
                                       IncrmntConfrmCounter();
                                       ActGrpId = document.getElementById("<%=ddlLedger .ClientID%>").value;

                                }
                                    if (ActGrpId != "" && strUserID != '') {
                                        var Details = PageMethods.LoadLedgerCode(strUserID, ActGrpId, strOrgIdID, ldgrsts, strCorpID, function (response) {

                                            var SucessDetails = response;


                                            if (SucessDetails != "") {

                                                document.getElementById("<%=txtLedgrCode.ClientID%>").value = SucessDetails;
                                            }
                                            else {
                                                //   window.location = 'fms_Sales_Master_List.aspx';
                                            }
                                        });
                                    }
                                }

                            }




                        }
                    }
                    else {

                        //   alert();
                        // document.getElementById("cphMain_cbxCsCntrSts").checked = false;

                        $('input.acgrp').attr("disabled", "disabled");
                        document.getElementById("cphMain_cbxCsCntrSts").checked = false;
                        document.getElementById("cphMain_cbxCsCntrSts").disabled = true;
                        document.getElementById("cphMain_ddlCC").value = "--SELECT COST GROUP--";
                        document.getElementById("cphMain_rdIncome").checked = true;
                        document.getElementById("cphMain_ddlCC").disabled = true;
                        document.getElementById("cphMain_rdIncome").disabled = true;
                        document.getElementById("cphMain_rdExpense").disabled = true;


                        if (document.getElementById("cphMain_hiddenTaxEnabled").value == "1") {

                            document.getElementById("cphMain_radioTDSyes").checked = false;
                            document.getElementById("cphMain_radioTCSyes").checked = false;

                            document.getElementById("cphMain_radioTDSyes").disabled = true;
                            //document.getElementById("cphMain_radioTDSno").disabled = true;
                            document.getElementById("cphMain_radioTCSyes").disabled = true;
                            //document.getElementById("cphMain_radioTCSno").disabled = true;

                            document.getElementById("cphMain_ddlTDS").disabled = true;
                            document.getElementById("cphMain_ddlTCS").disabled = true;

                            document.getElementById("cphMain_ddlTCS").value = "--SELECT TCS--";
                            document.getElementById("cphMain_ddlTDS").value = "--SELECT TDS--";



                        }
                        $au('input.acgrp').val("--SELECT ACCOUNT GROUP--");
                        document.getElementById("cphMain_txtblnce").disabled = true;
                        document.getElementById("cphMain_typdebit").disabled = true;
                        document.getElementById("cphMain_typdebit").checked = true;
                        document.getElementById("cphMain_typecredit").disabled = true;
                        document.getElementById("cphMain_txtblnce").value = "";

                        if (document.getElementById("<%=HiddenCodeSts.ClientID%>").value == "1") {
                            document.getElementById("<%=txtLedgrCode.ClientID%>").disabled = true;
                            document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;
                            document.getElementById("<%=txtCostCntrCode.ClientID%>").value = "";
                            document.getElementById("<%=txtLedgrCode.ClientID%>").value = "";

                        }

                        document.getElementById("cphMain_cbxSubLedger").checked = false;
                        document.getElementById("cphMain_cbxSubLedger").disabled = true;
                        document.getElementById("cphMain_ddlLedger").disabled = true;
                        $('input.ldgr').attr("disabled", "disabled");

                    }



                    // divCstCtr
                }
            }
        }

        function changeAmnt(obj) {
            var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
            var ObjVal = document.getElementById(obj).value.trim();
            if (FloatingValueMoney != "" && ObjVal != "") {
                ObjVal = ObjVal.replace(/,/g, "");
                ObjVal = parseFloat(ObjVal);
                var FixedAmnt = ObjVal.toFixed(FloatingValueMoney);
                addCommasSummry(FixedAmnt);


                document.getElementById(obj).value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
             }
         }
    </script>

    <script>
        function txtCCclick(x) {

            AmountChecking('cphMain_txtblnce');

            changeAmnt(x);


            if (document.getElementById("cphMain_txtblnce").value != "") {
                /// document.getElementById("cphMain_DandC").style.display = "block";
            }
            else {

                // document.getElementById("cphMain_DandC").style.display = "none";
                // document.getElementById("cphMain_ddlTDS").value = "--SELECT TDS--";
            }
        }


        //Pass supplier id and name for multiple row
        function PassSavedSupplierId(strId, strName) {
            if (window.opener != null && !window.opener.closed) {
                window.opener.GetValueFromChildSupplierId(strId, strName);
            }
            window.close();
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
    </style>
        <script>
            var $au = jQuery.noConflict();

            $au(function () {
                $au('#cphMain_ddlAccountGrp').selectToAutocomplete1Letter();
                $au('#cphMain_ddlLedger').selectToAutocomplete1Letter();
            });

        </script>


<!----spinner_script----started---->
<script type="text/javascript">
    $(function () {
        var action;
        $(".number-spinner button").mousedown(function () {
            btn = $(this);
            input = btn.closest('.number-spinner').find('input');
            btn.closest('.number-spinner').find('button').prop("disabled", false);

            if (btn.attr('data-dir') == 'up') {
                action = setInterval(function () {
                    if (input.attr('max') == undefined || parseInt(input.val()) < parseInt(input.attr('max'))) {
                        input.val(parseFloat(input.val()) + 0.5);
                    } else {
                        btn.prop("disabled", true);
                        clearInterval(action);
                    }
                }, 50);
            } else {
                action = setInterval(function () {
                    if (input.attr('min') == undefined || parseInt(input.val()) > parseInt(input.attr('min'))) {
                        input.val(parseFloat(input.val()) - 0.5);
                    } else {
                        btn.prop("disabled", true);
                        clearInterval(action);
                    }
                }, 50);
            }
        }).mouseup(function () {
            clearInterval(action);
        });
    });
</script>
<!----spinner_script----closed---->

</asp:Content>



