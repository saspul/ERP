<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Debit_Note.aspx.cs" Inherits="FMS_FMS_Master_fms_Debit_Note_fms_Debit_Note" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
   <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
     <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    
    <script>
        function AlertClearAll() {
            clearValue();
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Debit_Note.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                //window.location.href = "fms_Credit_Note.aspx";
                return true;
            }
        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            document.getElementById("cphMain_txtDescription").value = document.getElementById("cphMain_txtDescription").value.trim();
            var EditVal = document.getElementById("<%=HiddenEdit.ClientID%>").value;
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
                        if (json[key].CREDIT_NOTE_ID != "") {
                            EditListRows(json[key].CREDIT_NOTE_ID, json[key].LDGR_CR_ID, json[key].LDGR_ID, json[key].LDGR_CR_AMT, json[key].LDGR_NAME, json[key].CST_CNTR_CR_ID, json[key].COSTCNTR_ID, json[key].CST_CNTR_CR_AMOUNT, json[key].LDGR_CR_DR_CR_STATUS, json[key].PURCHS_ID, json[key].LDGR_REMARKS);
                        }
                    }
                }
                var x = 0;
                buttnVisibile(x, "1");
                flg = 1;
            }

            else if (EditVal == "") {
                flg = 0;
                document.getElementById("<%=txtGrantTotal.ClientID%>").value = "0.00";
                AddNewGroup(null,null);
                document.getElementById("cphMain_lblTotDeb").value = "";
                document.getElementById("cphMain_lblTotCrdt").value = "";
            }
            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {

                document.getElementById("cphMain_TxtRef").disabled = true;
                document.getElementById("cphMain_txtdate").disabled = true;
            }

        });
        function EditListRows(CREDIT_NOTE_ID, LDGR_CR_ID, LDGR_ID, LDGR_CR_AMT, LDGR_NAME, CST_CNTR_CR_ID, COSTCNTR_ID, CST_CNTR_CR_AMOUNT, LDGR_CR_DR_CR_STATUS, PURCHS_ID, LDGR_REMARKS) {
            if (LDGR_ID != 0) {

                AddNewGroup(LDGR_ID, LDGR_NAME);
                var CrdtOrDbt = "";
                document.getElementById("ddlLedId" + currntx).value = LDGR_ID;
                document.getElementById("TxtRemark" + currntx).value = LDGR_REMARKS;
                if (LDGR_CR_DR_CR_STATUS == "0") {
                    document.getElementById("TxtAmount_" + currntx).value = LDGR_CR_AMT;
                    addCommas("TxtAmount_" + currntx);
                    CrdtOrDbt = "DBT";
                }
                else {
                    document.getElementById("TxtAmountCrdt" + currntx).value = LDGR_CR_AMT;
                    addCommas("TxtAmountCrdt" + currntx);
                    CrdtOrDbt = "CDT";
                }
                document.getElementById("tdEvtGrp" + currntx).value = "UPD";
                document.getElementById("tdDtlIdTempid" + currntx).value = LDGR_CR_ID;
                document.getElementById("tdInxGrp" + currntx).value = currntx;
                document.getElementById("CreditNote" + currntx).style.opacity = "0.3";

                if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                    document.getElementById("TxtRemark" + currntx).disabled = true;
                    document.getElementById("ddlLedId" + currntx).disabled = true;
                    document.getElementById("TxtAmount_" + currntx).disabled = true;
                    document.getElementById("TxtAmountCrdt" + currntx).disabled = true;
                    document.getElementById("tdEvtGrp" + currntx).value = "UPD";
                    document.getElementById("tdDtlIdTempid" + currntx).disabled = true;
                    document.getElementById("ddlRecptLedger" + currntx).disabled = true;
                    document.getElementById("TxtAmountCrdt" + currntx).disabled = true;
                    document.getElementById("bttnRemovGrp" + currntx).disabled = true;
                    document.getElementById("CreditNote" + currntx).disabled = true;
                    document.getElementById("cphMain_txtDescription").disabled = true;
                    $("#tableGrp").find("input").attr("disabled", "disabled");

                }
            }

            document.getElementById("cphMain_lblTotDeb").value = document.getElementById("<%=HiddenGrdTotl.ClientID%>").value;
            document.getElementById("cphMain_lblTotCrdt").value = document.getElementById("<%=HiddenGrdTotl.ClientID%>").value;

            addCommas("cphMain_lblTotDeb");
            addCommas("cphMain_lblTotCrdt");

            document.getElementById("cphMain_lblTotDeb").value = document.getElementById("<%=HiddenGrdTotl.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            document.getElementById("cphMain_lblTotCrdt").value = document.getElementById("<%=HiddenGrdTotl.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;

            if (COSTCNTR_ID != null && COSTCNTR_ID != "" && COSTCNTR_ID != 0) {
                document.getElementById("tdCostCenterDtls" + currntx).value = COSTCNTR_ID;
            }
            if (PURCHS_ID != null && PURCHS_ID != "" && PURCHS_ID != 0) {
                document.getElementById("tdSaleDtls" + currntx).value = PURCHS_ID;
            }
            ddlLedOnchange(currntx, CrdtOrDbt, "Upd");

            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                document.getElementById("TxtAmount_" + currntx).disabled = true;
                document.getElementById("TxtAmountCrdt" + currntx).disabled = true;
            }
        }

        var varRowidx = "";
        var varRowidy = "";
        function ddlLedOnchange(x, CedtOrDbt, mode) {
            var Purchase_ret = true;
            var TxtCstctrAmount = "";
            if (CedtOrDbt == "CDT") {
                TxtCstctrAmount = document.getElementById("TxtAmountCrdt" + x).value;
            }
            else {
                TxtCstctrAmount = document.getElementById("TxtAmount_" + x).value;

            }
            TxtCstctrAmount = TxtCstctrAmount.trim();
            $("#divLedger" + x + "> input").css("borderColor", "");
            if ((document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) && TxtCstctrAmount != "") {
                Purchase_ret = true;
                document.getElementById("LedgerAmtInModalPurchse").innerText = TxtCstctrAmount + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            }
            if (document.getElementById("ddlRecptLedger" + x).value == "" || document.getElementById("ddlRecptLedger" + x).value == 0) {
                Purchase_ret = false;
                $("#divLedger" + x + "> input").css("borderColor", "red");
                $("#divLedger" + x + "> input").focus();
                $("#divLedger" + x + "> input").select();
            }
            if (TxtCstctrAmount == "") {
                Purchase_ret = false;
                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
            }
            if (TxtCstctrAmount != "") {
                if (CedtOrDbt == "CDT") {
                    document.getElementById("TxtAmount_" + x).disabled = true;
                    document.getElementById("TxtAmountCrdt" + x).disabled = false;
                }
                else {
                    document.getElementById("TxtAmountCrdt" + x).disabled = true;
                    document.getElementById("TxtAmount_" + x).disabled = false;
                }
            }
            else {
                if (document.getElementById("TxtAmount_" + x).value == "" && document.getElementById("TxtAmountCrdt" + x).value == "") {
                    document.getElementById("TxtAmount_" + x).disabled = false;
                    document.getElementById("TxtAmountCrdt" + x).disabled = false;
                    document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                    document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";
                }
                else {
                    document.getElementById("TxtAmount_" + x).style.borderColor = "";
                    document.getElementById("TxtAmountCrdt" + x).style.borderColor = "";
                }
            }
            var Meassage = "";
            var ledgerval = $("#divLedger" + x + "> input").val();
            if (Purchase_ret == true) {
                if (LedgerDuplication(x) == true) {

                    varRowidx = x;
                    if (document.getElementById("ddlRecptLedger" + x).value != "0") {
                        var Currency = "";
                        var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
                        var DebitID = "";
                        if (document.getElementById("<%=HiddenDebitNoteID.ClientID%>").value != "")
                            DebitID = document.getElementById("<%=HiddenDebitNoteID.ClientID%>").value;
                        var View = document.getElementById("<%=HiddenView.ClientID%>").value;
                        var corpid = '<%= Session["CORPOFFICEID"] %>';
                        var orgid = '<%= Session["ORGID"] %>';
                        var userid = '<%= Session["USERID"] %>';
                        var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                        var CrncyAbrv = document.getElementById("cphMain_HiddenCurrencyAbrv").value;

                        document.getElementById("ddlLedId" + x).value = LedgerId;
                        $noCon.ajax({
                            type: "POST",
                            url: "fms_Debit_Note.aspx/LoadSalesForLedger",
                            data: '{intLedgerId:"' + LedgerId + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" ,strCedtOrDbt:"' + CedtOrDbt + '",strCurrencyId:"' + CurrencyId + '",x:"' + x + '" ,strCrncyAbrv:"' + CrncyAbrv + '",DebitID:"' + DebitID + '",View:"' + View + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                               
                                
                                document.getElementById("MoHeading").innerHTML = response.d[3];
                                if (mode != "Upd") {
                                  
                                    if (response.d[0] != "") {
                                        document.getElementById("DivPopUpSales").innerHTML = response.d[0];
                                        document.getElementById("btnImportSales").style.display = "";
                                        document.getElementById("BtnPopup").click();
                                        document.getElementById("lblErrMsgCancelReason").style.display = "none";
                                        document.getElementById("ModelHeading").innerHTML = "Purchase";
                                        //document.getElementById("PurchaseName").innerHTML = response.d[3];
                                       
                                        var addRowtable = document.getElementById("TableAddQstn");
                                        if (document.getElementById("tdSaleDtls" + x).value != "") {
                                            var CstCntrDtl = document.getElementById("tdSaleDtls" + x).value;
                                            var splitrow = CstCntrDtl.split("$");
                                            for (var Cst = 0; Cst < splitrow.length; Cst++) {
                                                var splitEach = splitrow[Cst].split("%");
                                                for (var i = 1; i < addRowtable.rows.length; i++) {
                                                    var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
                                                   
                                                    if (document.getElementById("tdSaleID" + P_Id).innerHTML == splitEach[0]) {
                                                        document.getElementById("txtPurchaseAmt" + P_Id).value = splitEach[1];

                                                    }
                                                }
                                            }
                                        }
                                        if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                                            $("#TableAddQstn").find("input").attr("disabled", "disabled");
                                            document.getElementById("btnImportSales").disabled = true;

                                        }
                                    }
                                }
                                else {
                                    if (response.d[0] != "") {
                                        if (CedtOrDbt == "DBT") {
                                         //   if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                                                document.getElementById("ChkPurchase" + x).style.opacity = "1";
                                                //document.getElementById("ChkPurchase" + x).style.backgroundColor = "#00b147";
                                                document.getElementById("ChkPurchase" + x).className = "fa fa-shopping-cart ad_fa psc_p gre";
                                                document.getElementById("ChkPurchase" + x).disabled = false;
                                        //    }
                                        }
                                        else {
                                            document.getElementById("ChkPurchase" + x).style.opacity = "0.3";
                                            //document.getElementById("ChkPurchase" + x).style.backgroundColor = "#337ab7";
                                            document.getElementById("ChkPurchase" + x).disabled = true;
                                        }
                                    }
                                    else {
                                        document.getElementById("ChkPurchase" + x).style.opacity = "0.3";
                                        //document.getElementById("ChkPurchase" + x).style.backgroundColor = "#337ab7";
                                        document.getElementById("ChkPurchase" + x).disabled = true;
                                    }
                                }
                                if (response.d[1] != "") {
                                    addCommasSummry(response.d[1]);

                                    if (Currency != "") {
                                        document.getElementById("AccntBalance_" + x).innerHTML = "<i class=\"fa fa-money\"></i> " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                                    }
                                    else {
                                        document.getElementById("AccntBalance_" + x).innerHTML = "<i class=\"fa fa-money\"></i> " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;

                                    }
                                }
                                else {
                                    document.getElementById("AccntBalance_" + x).innerHTML = "";
                                }
                                if (response.d[2] == "CR")
                                    document.getElementById("AccntBalance_" + x).className = "input-group-addon cur2 c1h";
                                else if (response.d[2] == "DR")
                                    document.getElementById("AccntBalance_" + x).className = "input-group-addon cur2 dr1";
                                //alert(response.d[4]);
                                if (response.d[4] != "")
                                {
                                    setTimeout(function () { focusPurchase(response.d[4]); }, 500);

                                }

                                if (response.d[5] != "") {
                                    if (response.d[5] == "0" || response.d[5] == "1") {
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
                    if (document.getElementById("ddlRecptLedger" + x).value == "") {
                        document.getElementById("ddlLedId" + x).value = 0;
                    }
                }
            }
            //idlast = P_Id;
            //setTimeout(function () { focusSale(idlast); }, 350);
            return false;

        }
        function PurchaseAmountExceeded() {
            $noCon("#divWarning").html("Debit note amount should not be greater than purchase amount.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function PrchsAmtFullySettld() {
            $noCon("#divWarning").html("Purchase amount is already settled.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessReoen() {
            var ret = false;
            $noCon("#success-alert").html("Debit note reopened successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        function focusPurchase(Rowid) {
          
            document.getElementById("txtPurchaseAmt" + Rowid).focus();
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
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }

    </script>

    <script>
        function MyModalCostCenter(x, y, CstCntr, LDGR_NAME) {
            var SbCostCenter = '';
            SbCostCenter = '<div class=\"modal fade\" id=\"myModalCstCntr\" role=\"dialog\" aria-labelledby="exampleModalLabel"  tabindex="-1"  data-backdrop="static"  aria-hidden="true">';
            SbCostCenter += '<div class=\"modal-dialog mod1\" >';
            SbCostCenter += '<div class=\"modal-content\">';
            SbCostCenter += '<div class=\"modal-header\">';
            SbCostCenter += '<h2 class="modal-title mod1 flt_l" id="exampleModalLabel"><i class="fa fa-filter"></i> Cost Centre';
            SbCostCenter += '<span class="spn_mod"  id=\"MoHeadingCost\"></span></h2>';
            SbCostCenter += '<button type=\"button\" class=\"close\" onclick=\"return CloseModal(\'' + x + '\')\">&times;</button>';
            SbCostCenter += "<h4 class=\"modal-title\"></h4>";
            SbCostCenter += "</div>";
            SbCostCenter += '<div class=\"al-box war\"  id="lblErrMsgCancelReasonCostCenter' + x + '"> Please fill this out</div>';
            SbCostCenter += '<div class=\"modal-body md_bd\" id=\"DivPopUpCostCenter\">';
            SbCostCenter += '<table class=\"display table-bordered\"  id="TableAddQstnCostCenter' + x + '">';
            SbCostCenter += '<thead class=\"thead1\"> <tr><th class=\"col-md-2 tr_l\">Cost Group1</th><th class=\"col-md-2 tr_l\" >Cost Group2</th><th class=\"col-md-2 tr_l\" >Cost Centre</th><th class=\"col-md-2 tr_r\" > Amount</th><th>Actions</th>';
            SbCostCenter += '</tr></thead>';
            SbCostCenter += '</table>';
            SbCostCenter += '</div>';
            SbCostCenter += '<div class=\"clearfix\"></div>';
            SbCostCenter += '<div class=\"modal-footer\"> <div class="col-md-12 col_mar"><div class="box6 tr_r">';
            SbCostCenter += '<label id=\"Label1\" for=\"example-text-input\" class=\"fg2_la1 tt_am am1\">Ledger Amount<span class="spn1"></span>:</label></div>';
            SbCostCenter += '<div class="box6 flt_r"><span  id="LedgerAmtInModal' + x + '" class="tt_am am1 tt_al"></span>  </div> </div>';
            SbCostCenter += '<button id="btnImportCostCenter' + x + '" type=\"button\" class=\"btn btn-success\"  onclick=\"ButtnFillClickCostCenter(\'' + x + '\');\" >Submit</button>';

            SbCostCenter += '<button type="button" class="btn btn-danger" onclick=\"return CloseModal(\'' + x + '\')\">Cancel</button>';
            SbCostCenter += '<button id="BttnCost' + x + '" type=\"button\" style=\"display:none\" class=\"btn btn-primary\" data-dismiss=\"modal\"></button>';
            SbCostCenter += '</div></div> </div></div>';
            document.getElementById("CostCenterModal").innerHTML = SbCostCenter;
            CostCentr(x, y, CstCntr);
            buttnVisibile(x, "0");
            var idlast = "";
            var row = $noCon('#TableAddQstnCostCenter' + x).find(' tbody tr:first').attr('id');
            idlast = row.split('_');
            focusCostCentre(idlast[1]);
        }
        function focusCostCentre(Rowid) {
            $('#myModalCstCntr').on('shown.bs.modal', function () {
                $("#divCostGrp1" + Rowid + " > input").focus();
                $("#divCostGrp1" + Rowid + " > input").select();
            });
        }

        var rowSubCatagory = 0;
        var RowIndex1 = 0;
        var currntx = "";
        var currnty = "";
        var flg = 0;

        function AddNewGroup(ledgerid, LDGR_NAME) {
            RowIndex1++;
            var FrecRow = '';
            FrecRow = '<tr  class="tr1" id="SubGrpRowId_' + RowIndex1 + '" ><td   id="tdidGrpDtls' + RowIndex1 + '" style="display: none" >' + RowIndex1 + '</td>';
            FrecRow += '<div style="clear:both"></div><div style="display:none" id="groupSubCat' + RowIndex1 + '">' + rowSubCatagory + '</div> ';
            var yy = rowSubCatagory + 1;
            FrecRow += '<td><div id="divLedger' + RowIndex1 + '">';
            FrecRow += '<select onkeypress="return DisableEnter(event)"   class="fg2_inp2 fg2_inp3 fg_chs1 fgs1 ddl" id="ddlRecptLedger' + RowIndex1 + '"  onchange="PaymentLedger(' + RowIndex1 + ');"></select>';
            FrecRow += '<input class="fg2_inp2 fg2_inp3 fg_chs1 fgs1" style="display:none" name="ddlLedId' + RowIndex1 + '"  value="0" id="ddlLedId' + RowIndex1 + '" type="text">';
            FrecRow += '</div><span id="AccntBalance_' + RowIndex1 + '" class="input-group-addon cur2 c1h"><i class="fa fa-money"></i> </span></td>';

            FrecRow += '<td class=" tr_r">';
            FrecRow += '<div class="input-group">';
            FrecRow += '<span class="input-group-addon cur1">' + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value + '</span>';
            FrecRow += '<input class="form-control fg2_inp2 tr_r" autocomplete="\off"\  disabled onkeydown="return isDecimalNumber(event,\'TxtAmount_' + RowIndex1 + '\');" onkeypress="return isDecimalNumber(event,\'TxtAmount_' + RowIndex1 + '\');" name="TxtAmount_' + RowIndex1 + '"  onchange="return PendingPurchase(\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'DBT\');"   value="" id="TxtAmount_' + RowIndex1 + '" maxlength="10" type="text" >';
            FrecRow += '</div>';
            FrecRow += '</td>';
       
            FrecRow += '<td class=" tr_r">';
            FrecRow += '<div class="input-group">';
            FrecRow += '<span class="input-group-addon cur1">' + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value + '</span>';
            FrecRow += '<input class="form-control fg2_inp2 tr_r" autocomplete="\off"\  disabled onkeydown="return isDecimalNumber(event,\'TxtAmountCrdt' + RowIndex1 + '\');" onkeypress="return isDecimalNumber(event,\'TxtAmountCrdt' + RowIndex1 + '\');" name="TxtAmountCrdt' + RowIndex1 + '"  onchange="return PendingPurchase(\'TxtAmountCrdt' + RowIndex1 + '\',' + RowIndex1 + ',\'CDT\');"    value="" id="TxtAmountCrdt' + RowIndex1 + '" maxlength="10" type="text">';
            FrecRow += '</div>';
            FrecRow += '</td>';
                    
            FrecRow += '<td><textarea   name="TxtRemark' + RowIndex1 + '"    value="" id="TxtRemark' + RowIndex1 + '"   rows="3" cols="20"  class="form-control" style="; resize: none;" onkeydown="textCounter(TxtRemark' + RowIndex1 + ',450)" onblur="return textCounter(TxtRemark' + RowIndex1 + ',450)" onchange="return textCounter(TxtRemark' + RowIndex1 + ',450)"onkeyup="textCounter(TxtRemark' + RowIndex1 + ',450)"></textarea></td>';

            FrecRow += '<td class="td1"><div class="btn_stl1">';
            FrecRow += '<button title="ADD"  id="CreditNote' + RowIndex1 + '" onclick="return FuctionAddGroup(\'' + RowIndex1 + '\')" class="btn act_btn bn2" ><span   class="fa fa-plus"  style="display: block;"></span></button>';
            FrecRow += '<button title="DELETE" id="bttnRemovGrp' + RowIndex1 + '"   onclick="return removeRowGrps(' + RowIndex1 + ',\'Are you sure you want to delete this ledger?\')" class="btn act_btn bn3"><span class="fa fa-trash"   style="display: block;"></span></button>';
            FrecRow += '</div></td>';

            FrecRow += '<td>';
            FrecRow += '<a href="javascript:void(0)" title="PURCHASE RETURN"  onclick="return ddlLedOnchange(\'' + RowIndex1 + '\',\'DBT\',\'ins\');" ><i id="ChkPurchase' + RowIndex1 + '" class="fa fa-shopping-cart ad_fa psc_p"></i></a>';
            FrecRow += '<a href="javascript:void(0)" title="COST CENTRE" id="ChkCostCenter' + RowIndex1 + '"  onclick="MyModalCostCenter(\'' + RowIndex1 + '\',\'' + rowSubCatagory + '\',null,\'' + LDGR_NAME + '\');"><i class="fa fa-filter ad_fa psc_c"></i></a></td>';

            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdSaleDtls' + RowIndex1 + '" name="tdSaleDtls' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowIndex1 + '" name="tdCostCenterDtls' + RowIndex1 + '" placeholder=""/></td>';

            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" value="INS" style="display:none;"  id="tdEvtGrp' + RowIndex1 + '" name="tdEvtGrp' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdTempid' + RowIndex1 + '" name="tdDtlIdTempid' + RowIndex1 + '" placeholder=""/><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdGrp' + RowIndex1 + '" name="tdDtlIdGrp' + RowIndex1 + '" placeholder=""/></td>';

            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdInxGrp' + RowIndex1 + '" name="tdInxGrp' + RowIndex1 + '" placeholder=""/> </td></tr>';
            jQuery('#tableGrp').append(FrecRow);
            FillddlRcptLedger(RowIndex1, ledgerid);
            $au("#ddlRecptLedger" + RowIndex1).selectToAutocomplete1Letter();
            if (flg != "0") {
                FunctionQustn(RowIndex1, rowSubCatagory, null, null, null);
            }
            else {
                currntx = RowIndex1;
                currnty = rowSubCatagory;
            }
            //  if (RowIndex1 != "1") {
            //$("#divLedger" + RowIndex1 + "> input").focus();
            //$("#divLedger" + RowIndex1 + "> input").select();
            // }
            currntx = RowIndex1;
            currnty = rowSubCatagory;
            return false;
        }
        function removeRowGrps(removeNum, CofirmMsg) {
            IncrmntConfrmCounter();
            //alert(removeNum);
            if (document.getElementById("cphMain_HiddenView").value != "1") {
                ezBSAlert({
                    type: "confirm",
                    messageText: CofirmMsg,
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var evt = document.getElementById("tdEvtGrp" + removeNum).value;
                        //   if (evt == 'UPD') {
                        var detailId = document.getElementById("tdDtlIdTempid" + removeNum).value;
                        var CanclIds = document.getElementById("cphMain_hiddenLedgerCanclDtlId").value;
                        if (CanclIds == '') {
                            document.getElementById("cphMain_hiddenLedgerCanclDtlId").value = detailId;
                        }
                        else {
                            document.getElementById("cphMain_hiddenLedgerCanclDtlId").value = document.getElementById("cphMain_hiddenLedgerCanclDtlId").value + ',' + detailId;
                        }

                        jQuery('#SubGrpRowId_' + removeNum).remove();
                        addRowtable = document.getElementById("tableGrp");
                        var TableRowCount = document.getElementById("tableGrp").rows.length;
                        if (TableRowCount != 0) {
                            for (var i = 0; i < addRowtable.rows.length; i++) {
                                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                                if (TableRowCount != 0) {
                                    if ((TableRowCount - 1) == i) {
                                        document.getElementById("tdInxGrp" + xLoop).value = "";
                                        document.getElementById("CreditNote" + xLoop).style.opacity = "1";
                                        document.getElementById("CreditNote" + xLoop).disabled = false;

                                    }
                                }
                            }
                        }
                        else {

                            AddNewGroup(null,null);
                        }
                        calculateTotal();

                    }
                    else {
                    }
                });
                return false;
            }
            else {
                return false;
            }

        }
        function removeRowQstn(Rowid, y, removeNum, CofirmMsg) {
            IncrmntConfrmCounter();

            if (document.getElementById("cphMain_HiddenView").value != "1") {
                ezBSAlert({
                    type: "confirm",
                    messageText: CofirmMsg,
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var evt = document.getElementById("tdEvtQstn" + removeNum).value;

                        if (evt == 'UPD') {
                            var detailId = document.getElementById("tdDtlIdQstn" + removeNum).value;

                            var CanclIds = document.getElementById("cphMain_hiddenQstnCanclDtlId").value;
                            if (CanclIds == '') {
                                document.getElementById("cphMain_hiddenQstnCanclDtlId").value = detailId;
                            }
                            else {
                                document.getElementById("cphMain_hiddenQstnCanclDtlId").value = document.getElementById("cphMain_hiddenQstnCanclDtlId").value + ',' + detailId;
                            }
                        }
                        jQuery('#SubQstnRowId_' + removeNum).remove();

                        var TableRowCount = document.getElementById("TableAddQstnCostCenter" + Rowid).rows.length;
                        if (TableRowCount != 1) {
                            var idlast = "";
                            idlast = $noCon('#TableAddQstnCostCenter' + Rowid + ' tr:last').attr('id');

                            if (idlast != "") {
                              
                                //13-02-2019
                                var res = idlast.split("_");
                                 focusCostCentre(res[1]); 
                                document.getElementById("tdInxQstn" + res[1]).value = "";
                                document.getElementById("btnCostCenter_" + res[1]).style.opacity = "1";
                            }
                        }
                        else {

                            FunctionQustn(Rowid, y, null, null, null);
                            document.getElementById("tdCostCenterDtls" + Rowid).value = "";
                        }
                    }
                    else {
                    }
                });
                return false;
            }
            else {
                return false;
            }

        }
        function buttnVisibile(x, Check) {
            var TableRowCount = document.getElementById("tableGrp").rows.length;         
            addRowtable = document.getElementById("tableGrp");

            for (var i = 0; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                if (TableRowCount != 0) {
                    if (xLoop != "") {
                        if ((TableRowCount - 1) == i) {

                            document.getElementById("tdInxGrp" + xLoop).value = "";
                            document.getElementById("CreditNote" + xLoop).style.opacity = "1";
                        }
                    }
                }
                if (x != 0) {
                    if (Check == "0") {
                        var TableRowCount1 = document.getElementById("TableAddQstnCostCenter" + x).rows.length;
                        if (TableRowCount1 != 0) {
                            var idlast1 = $noCon('#TableAddQstnCostCenter' + x + ' tr:last').attr('id');

                            if (idlast1 != "") {
                                var res1 = idlast1.split("_");
                                document.getElementById("tdInxQstn" + res1[1]).value = "";
                                document.getElementById("btnCostCenter_" + res1[1]).style.opacity = "1";
                            }
                        }
                    }
                }
            }


        }
        function FillddlRcptLedger(rowCount, LDGR_ID) {
            var ddlTestDropDownListXML = "";
            ddlTestDropDownListXML = $noCon("#ddlRecptLedger" + rowCount);

            var intOrgID = '<%= Session["ORGID"] %>';
            var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
            var tableName = "dtTableLedger";

            if (document.getElementById("<%=hiddenLedgerddl.ClientID%>").value != 0) {
                   ddlLed = document.getElementById("<%=hiddenLedgerddl.ClientID%>").value;
                   var OptionStart = $noCon("<option>--SELECT--</option>");
                   OptionStart.attr("value", 0);
                   ddlTestDropDownListXML.append(OptionStart);
                   $noCon(ddlLed).find(tableName).each(function () {
                       var OptionValue = $noCon(this).find('LDGR_ID').text();
                       var OptionText = $noCon(this).find('LDGR_NAME').text();
                       var option = $noCon("<option>" + OptionText + "</option>");
                       option.attr("value", OptionValue);

                       ddlTestDropDownListXML.append(option);

                   });
                //Remove Ledger
                   var addRowtable = "";
                   addRowtable = document.getElementById("tableGrp");
                   for (var i = 0; i < addRowtable.rows.length; i++) {
                       var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                       var xLoopLdgrId = "";
                       if ($("#ddlRecptLedger" + xLoop).val() != 0) {
                           xLoopLdgrId = $("#ddlRecptLedger" + xLoop).val();
                           $noCon("#ddlRecptLedger" + rowCount + " option[value='" + xLoopLdgrId + "']").remove();
                       }
                   }
                   if (LDGR_ID != "" && LDGR_ID != null) {
                       var arrayProduct = JSON.parse("[" + LDGR_ID + "]");
                       $noCon("#ddlRecptLedger" + rowCount).val(arrayProduct);
                   }
               }
               else {
                   var OptionStart = $noCon("<option>--SELECT--</option>");
                   OptionStart.attr("value", 0);
                   ddlTestDropDownListXML.append(OptionStart);
               }

           }
           function FuctionAddGroup(Ledx) {

               IncrmntConfrmCounter();
               var addRowtableGrp;
               var addRowResultGrp = true;
               $("#divLedger" + Ledx + "> input").css("borderColor", "");
               var check = document.getElementById("tdInxGrp" + Ledx).value;

               if (check == "") {
                   addRowtableGrp = document.getElementById("TableAddQstnCostCenter_" + Ledx);
                   if (CheckSumOfLedger('TxtAmount_' + Ledx, Ledx) == false) {
                       addRowResultGrp = false;
                   }
                   if (LedgerDuplication(Ledx) == false) {
                       addRowResultGrp = false;
                   }
                   if (addRowResultGrp == false) {
                       return false;
                   }
                   else {
                       document.getElementById("tdInxGrp" + Ledx).value = Ledx;
                       document.getElementById("CreditNote" + Ledx).style.opacity = "0.3";
                       AddNewGroup(null,null);
                       return false;
                   }
               }
               return false;

           }
           function PaymentLedger(x) {
               var LedgerId = 0;
               confirmbox++;
               document.getElementById("TxtAmount_" + x).style.borderColor = "";
               document.getElementById("TxtAmountCrdt" + x).style.borderColor = "";

               if (document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) {

                   $("#divLedger" + x + "> input").css("borderColor", "");
                   if (LedgerDuplication(x) == true) {
                       LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                       document.getElementById("ddlLedId" + x).value = LedgerId;

                       document.getElementById("TxtAmount_" + x).value = "";
                       document.getElementById("TxtAmountCrdt" + x).value = "";
                       document.getElementById("tdCostCenterDtls" + x).value = "";
                       document.getElementById("tdSaleDtls" + x).value = "";
                       
                       document.getElementById("TxtAmountCrdt" + x).disabled = false;
                       document.getElementById("TxtAmount_" + x).disabled = false;
                   }
               }
               else {

                   document.getElementById("TxtAmountCrdt" + x).value = "";
                   document.getElementById("TxtAmountCrdt" + x).disabled = true;

                   document.getElementById("TxtAmount_" + x).value = "";
                   document.getElementById("TxtAmount_" + x).disabled = true;
                   document.getElementById("tdCostCenterDtls" + x).value = "";
                   document.getElementById("tdSaleDtls" + x).value = "";

               }
           }
           function LedgerDuplication(rowId) {
               var addRowtable = "";
               var ret = true;
               var flag = 0;
               addRowtable = document.getElementById("tableGrp");

               for (var i = 0; i < addRowtable.rows.length; i++) {
                   var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                   var xLoopLdgrId = $("#ddlRecptLedger" + xLoop).val();
                   var LedgerId = $("#ddlRecptLedger" + rowId).val();
                   if (xLoop != rowId) {
                       if (xLoopLdgrId == LedgerId) {
                           $("#divLedger" + rowId + "> input").css("borderColor", "red");
                           $("#divLedger" + rowId + "> input").focus();
                           $("#divLedger" + rowId + "> input").select();
                           $noCon("#divWarning").html("Ledgers should not be duplicated.");
                           $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                           });
                          
                           $noCon(window).scrollTop(0);
                           flag++;
                           ret = false;

                       }
                   }
               }
               return ret;
           }
           function CostCentr(x, y, CostCenterId) {
               var TxtCstctrAmount = "";
               TxtCstctrAmount = document.getElementById("TxtAmount_" + x).value;
               TxtCstctrAmount = TxtCstctrAmount.trim();
               TxtCstctrAmountCrdt = document.getElementById("TxtAmountCrdt" + x).value.trim();
               document.getElementById("TxtAmount_" + x).style.borderColor = "";
               document.getElementById("TxtAmountCrdt" + x).style.borderColor = "";
               $("#divLedger" + x + "> input").css("borderColor", "");
               if ((document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0)) {
                   if (TxtCstctrAmount != "" || TxtCstctrAmountCrdt != "") {
                       var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                       document.getElementById("ddlLedId" + x).value = LedgerId;
                       if (document.getElementById("tdCostCenterDtls" + x).value != "") {
                           var CstCntrDtl = document.getElementById("tdCostCenterDtls" + x).value;

                           var splitrow = CstCntrDtl.split("$");
                           for (var Cst = 0; Cst < splitrow.length; Cst++) {
                               var splitEach = splitrow[Cst].split("%");
                               if (splitEach[0] != "") {
                                   FunctionQustn(x, currnty, splitEach[0], splitEach[2], splitEach[3]);
                                   document.getElementById("ddlCostCtrId_" + x + '' + currnty).value = splitEach[0];

                                   document.getElementById("TxtCstctrAmount_" + x + '' + currnty).value = splitEach[1];
                                   addCommas("TxtCstctrAmount_" + x + '' + currnty);
                                   document.getElementById("TxtActCstctrAmount_" + x + '' + currnty).value = splitEach[1];
                                   document.getElementById("tdInxQstn" + x + '' + currnty).value = x + '' + currnty;
                                   document.getElementById("btnCostCenter_" + x + '' + currnty).style.opacity = "0.3";
                               }

                           }
                           FunctionQustn(x, currnty, null, null, null);
                       }
                       else {
                           FunctionQustn(x, y, CostCenterId, CostCenterId, CostCenterId);
                       }
                       document.getElementById("BtnPopupCstCntr").click();

                       if (TxtCstctrAmount != "")
                           document.getElementById("LedgerAmtInModal" + x).innerText = TxtCstctrAmount + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                    else if (TxtCstctrAmountCrdt != "") {
                        document.getElementById("LedgerAmtInModal" + x).innerText = TxtCstctrAmountCrdt + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                }
        }
    }

    if (TxtCstctrAmount == "" && TxtCstctrAmountCrdt == "") {

        document.getElementById("TxtAmount_" + x).style.borderColor = "red";
        document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";
        //   document.getElementById("TxtAmountCrdt" + x).focus();
        //   document.getElementById("TxtAmount_" + x).focus();

    }
    if (document.getElementById("ddlRecptLedger" + x).value == "" || document.getElementById("ddlRecptLedger" + x).value == 0) {
        $("#divLedger" + x + "> input").css("borderColor", "red");
        $("#divLedger" + x + "> input").focus();
        $("#divLedger" + x + "> input").select();
    }

}
        function FunctionQustn(x, y, CostCenterId, CostGrp1Id, CostGroup2Id) {
    y++;
    // submit++;
    var FrecRowQst = '';
    FrecRowQst += '<tr id="SubQstnRowId_' + x + '' + y + '" ><td   id="tdidQstnDtls' + x + '' + y + '" style="display: none" >' + x + '' + y + '</td>';
    FrecRowQst += '<td   id="tdvalidate' + x + '' + y + '" style="display: none" >' + x + '</td>';
    FrecRowQst += '<td   id="tdvalidatey' + x + '' + y + '" style="display: none" >' + y + '</td>';

    FrecRowQst += '<td>';

            //13-02-2019
    FrecRowQst += '<input name="TxtRecptCosGrp1_' + x + '' + y + '"  style="display: none;pointer-events: none;background: #eee;" class="form-control" id="TxtRecptCosGrp1_' + x + '' + y + '" ><div id="divCostGrp1' + x + '' + y + '"><select id="ddlRecptCosGrp1_' + x + '' + y + '" name="ddlRecptCosGrp1_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl"  onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostGrp1Id_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostGrp1Id_' + x + '' + y + '" ></td>';

    FrecRowQst += '<td >';


    FrecRowQst += '<input name="TxtRecptCosGrp2_' + x + '' + y + '"  style="display: none;pointer-events: none;background: #eee;" class="form-control" id="TxtRecptCosGrp2_' + x + '' + y + '" ><div id="divCostGrp2' + x + '' + y + '"><select id="ddlRecptCosGrp2_' + x + '' + y + '" name="ddlRecptCosGrp2_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl"  onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostGrp2Id_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostGrp2Id_' + x + '' + y + '" ></td>';


    FrecRowQst += '<td><input style="display:none" value="-1" name="TxtIdSales_' + x + '' + y + '" class="form-control" id="TxtIdSales_' + x + '' + y + '" ><input name="TxtRecptCosCtr_' + x + '' + y + '"  style="display: none;pointer-events: none;background: #eee;" class="form-control" id="TxtRecptCosCtr_' + x + '' + y + '" ><div id="divCostCenter' + x + '' + y + '"><select id="ddlRecptCosCtr_' + x + '' + y + '" name="ddlRecptCosCtr_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1"   onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  >';


    FrecRowQst += '</select></div><input name="ddlCostCtrId_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostCtrId_' + x + '' + y + '" ></td>';


    FrecRowQst += '<td class=" tr_r"><div class="input-group"> <span class="input-group-addon cur1">' + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value + '</span><input class="form-control fg2_inp2 tr_r" maxlength="10" autocomplete="\off"\   id="TxtCstctrAmount_' + x + '' + y + '" name="TxtCstctrAmount_' + x + '' + y + '" value="" onblur="return CheckSumOfCstCntr(\'TxtCstctrAmount_' + x + '' + y + '\',' + x + ',' + y + ');"  onkeydown="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '' + y + '\');" onkeypress="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '' + y + '\');" id="TxtCstctrAmount_' + x + '' + y + '" type="text" ><input class="form-control fg2_inp2 tr_r"   id="TxtActCstctrAmount_' + x + '' + y + '" value="" onblur="return CheckSumOfLedger(\'TxtActCstctrAmount_' + x + '' + y + ',' + x + ',' + y + '\');" onkeyup="addCommas("TxtActCstctrAmount_' + x + '' + y + ')" style="text-align: right; display:none" onkeydown="return isNumber(event,TxtActCstctrAmount_' + x + '' + y + ');" name="TxtActCstctrAmount_' + x + '' + y + '" type="text"></div></td>';

     FrecRowQst += '<td>';

    FrecRowQst += '<button title="ADD" id="btnCostCenter_' + x + '' + y + '" onclick="return CheckaddMoreRowsQstn(\'' + x + '\',\'' + y + '\',\'' + x + '' + y + '\');" class="btn act_btn bn2"><span  class="fa fa-plus"  style="display: block;">&nbsp;</span></button>';
    FrecRowQst += '<button class="btn act_btn bn3" id="btnCostCenterDel_' + x + '' + y + '" onclick="return removeRowQstn(\'' + x + '\',\'' + y + '\',\'' + x + '' + y + '\',\'Are you sure you want to delete this cost centre?\')" style="">';
    FrecRowQst += '<span title="DELETE"   class="fa fa-trash" id="Span4" style="display: block;">&nbsp;</span></button></td>';

    //FrecRowQst += '<button title="ADD" id="btnCostCenter_' + x + '' + y + '" onclick="return CheckaddMoreRowsQstn(\'' + x + '\',\'' + y + '\',\'' + x + '' + y + '\');" class="btn btn-primary"><span  class="fa fa-plus"  style="display: block;">&nbsp;</span></button></td>';
    //FrecRowQst += '<td style="width:10%;"><button class="btn btn-primary" id="btnCostCenterDel_' + x + '' + y + '" onclick="return removeRowQstn(\'' + x + '\',\'' + y + '\',\'' + x + '' + y + '\',\'Are you sure you want to delete this cost centre?\')" style="">';
    //FrecRowQst += '<span title="DELETE"   class="fa fa-trash" id="Span4" style="display: block;">&nbsp;</span></button></td>';

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



    //  CheckSubmitZero();

    currntx = x;
    currnty = y;
    if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                document.getElementById("btnCostCenter_" + x + y).disabled = "true";
                document.getElementById("btnCostCenterDel_" + x + y).disabled = "true";
                $("#TableAddQstnCostCenter" + x).find("input").attr("disabled", "disabled");
    }

            //13-02-2019
            $("#divCostGrp1" + x + '' + y + " > input").focus();
            $("#divCostGrp1" + x + '' + y + " > input").select();

            return false;

        }
        function ddlCostCenterOnchange(x, y) {
            IncrmntConfrmCounter();
            if (document.getElementById("ddlRecptCosCtr_" + x + '' + y).value != 0) {
                var ddlCostcnt = document.getElementById("ddlRecptCosCtr_" + x + '' + y).value;
                document.getElementById("ddlCostCtrId_" + x + '' + y).value = ddlCostcnt;
              //  document.getElementById("TxtCstctrAmount_" + x + '' + y).value = "";
            }
            CCDuplication(x, x + '' + y);
        }
        function CheckSumOfCstCntr(textboxid, x, y) {
            if (document.getElementById(textboxid).value != "" && document.getElementById(textboxid).value != "0") {
            var CstTotal = 0;
            var LedgerTotal = 0;
            AmountChecking(textboxid);
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            }
            else {
                document.getElementById(textboxid).value = "";
            }
            return true;
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


        function FillddlCostCenter(rowCountX, rowCountY, costId) {

            var ddlTestDropDownListXML1 = "";
            ddlTestDropDownListXML1 = $noCon("#ddlRecptCosCtr_" + rowCountX + "" + rowCountY);

            var intOrgID = '<%= Session["ORGID"] %>';
            var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
            var tableName = "dtTableCostCenter";

            if (document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value != "0") {
                ddlLed = document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML1.append(OptionStart);
                $noCon(ddlLed).find(tableName).each(function () {
                    var OptionValue = $noCon(this).find('COSTCNTR_ID').text();
                    var OptionText = $noCon(this).find('COSTCNTR_NAME').text();
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML1.append(option);
                    if (costId != "" && costId != null) {
                        var arrayProduct = JSON.parse("[" + costId + "]");
                        $noCon("#ddlRecptCosCtr_" + rowCountX + "" + rowCountY).val(arrayProduct);

                    }
                });
            }
            else {
                var OptionStart = $noCon("<option>--SELECT--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML1.append(OptionStart);
            }
        }
        function PendingPurchase(textboxid, x, CedtOrDbt) {

            var Purchase_ret = true;
            var TxtCstctrAmount = "";
            addCommas("TxtAmount_" + x + "");
            addCommas("TxtAmountCrdt" + x + "");
            TxtCstctrAmount = document.getElementById(textboxid).value;
            TxtCstctrAmount = TxtCstctrAmount.trim();

            $("#divLedger" + x + "> input").css("borderColor", "");
            if ((document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) && TxtCstctrAmount != "") {
                document.getElementById("LedgerAmtInModalPurchse").innerText = TxtCstctrAmount + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                Purchase_ret = true;

            }
            if (document.getElementById("ddlRecptLedger" + x).value == "" || document.getElementById("ddlRecptLedger" + x).value == 0) {
                Purchase_ret = false;
                $("#divLedger" + x + "> input").css("borderColor", "red");
                $("#divLedger" + x + "> input").focus();
                $("#divLedger" + x + "> input").select();
            }
            if (TxtCstctrAmount == "") {
                Purchase_ret = false;
            }
            if (TxtCstctrAmount != "") {
                if (CedtOrDbt == "CDT") {
                    document.getElementById("TxtAmount_" + x).disabled = true;
                    document.getElementById("TxtAmountCrdt" + x).disabled = false;
                }
                else {
                    document.getElementById("TxtAmountCrdt" + x).disabled = true;
                    document.getElementById("TxtAmount_" + x).disabled = false;
                }
            }
            else {
                if (document.getElementById("TxtAmount_" + x).value == "" && document.getElementById("TxtAmountCrdt" + x).value == "") {
                    document.getElementById("TxtAmount_" + x).disabled = false;
                    document.getElementById("TxtAmountCrdt" + x).disabled = false;
                }
                else {
                }
            }
            var ret = true;
            var CstTotal = 0;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

            var LedgerTotal = 0;
            var addRowtable1 = document.getElementById("tableGrp");

            for (var i = 0; i < addRowtable1.rows.length; i++)
            {
                var row = addRowtable1.rows[i];
                var xtemp = (addRowtable1.rows[i].cells[0].innerHTML);

                var CrdtOrDbt = "";

                var CstCntrId = "";
                var SalesId = "";
                var CostCntrAmt = "";
                var PrchsAmt = "";
                var LdAmt = "0";
              
                if (document.getElementById("TxtAmount_" + xtemp).value != "") {
                    LdAmt = document.getElementById("TxtAmount_" + xtemp).value;
                    CrdtOrDbt = "DBT";
                }
                if (document.getElementById("TxtAmountCrdt" + xtemp).value != "") {
                    LdAmt = document.getElementById("TxtAmountCrdt" + xtemp).value;
                    CrdtOrDbt = "CDT";
                }
                document.getElementById("TxtAmountCrdt" + xtemp).style.borderColor = "";
                document.getElementById("TxtAmount_" + xtemp).style.borderColor = "";
                LdAmt = LdAmt.replace(/\,/g, '');
                if (LdAmt <= 0) {
                    document.getElementById("TxtAmount_" + xtemp).style.borderColor = "red";
                    document.getElementById("TxtAmountCrdt" + xtemp).style.borderColor = "red";
                    document.getElementById("TxtAmount_" + xtemp).focus();
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                   
                    $noCon(window).scrollTop(0);
                    ret = false;
                }
                calculateTotal();
                if (document.getElementById("tdCostCenterDtls" + xtemp).value != null && document.getElementById("tdCostCenterDtls" + xtemp).value != "" && document.getElementById("tdCostCenterDtls" + xtemp).value != "null") {
                    var CostCenterInfo = document.getElementById("tdCostCenterDtls" + xtemp).value;
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
                        if (parseFloat(CstnrTTl) != parseFloat(LdAmt)) {
                            if (CrdtOrDbt == "DBT")
                                document.getElementById("TxtAmount_" + xtemp).style.borderColor = "red";
                            else if (CrdtOrDbt == "CDT")
                                document.getElementById("TxtAmountCrdt" + xtemp).style.borderColor = "red";
                            else {
                                document.getElementById("TxtAmount_" + xtemp).style.borderColor = "red";
                                document.getElementById("TxtAmountCrdt" + xtemp).style.borderColor = "red";
                            }
                            $noCon("#divWarning").html("Ledger amount should be equal to cost centre amount. ");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                           
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
                    }


                }
            }
            if (ret == true) {
                if (LedgerDuplication(x) == true) {
                    varRowidx = x;

                    if (document.getElementById("ddlRecptLedger" + x).value != "") {

                        var Currency = "";
                        var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
                        var DebitID = "";
                        if (document.getElementById("<%=HiddenDebitNoteID.ClientID%>").value != "")
                            DebitID = document.getElementById("<%=HiddenDebitNoteID.ClientID%>").value;
                        var View = document.getElementById("<%=HiddenView.ClientID%>").value;
                        var corpid = '<%= Session["CORPOFFICEID"] %>';
                        var orgid = '<%= Session["ORGID"] %>';
                        var userid = '<%= Session["USERID"] %>';
                        var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                        var CrncyAbrv = document.getElementById("cphMain_HiddenCurrencyAbrv").value;

                        document.getElementById("ddlLedId" + x).value = LedgerId;
                        $noCon.ajax({
                            type: "POST",
                            url: "fms_Debit_Note.aspx/LoadSalesForLedger",
                            data: '{intLedgerId:"' + LedgerId + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" ,strCedtOrDbt:"' + CedtOrDbt + '",strCurrencyId:"' + CurrencyId + '",x:"' + x + '",strCrncyAbrv:"' + CrncyAbrv + '" ,DebitID:"' + DebitID + '",View:"' + View + '" }',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                if (response.d[0] != "") {

                                    if (CedtOrDbt == "DBT") {
                                        if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                                            document.getElementById("ChkPurchase" + x).style.opacity = "1";
                                            //document.getElementById("ChkPurchase" + x).style.backgroundColor = "#00b147";

                                            document.getElementById("ChkPurchase" + x).className = "fa fa-shopping-cart ad_fa psc_p gre";

                                            document.getElementById("ChkPurchase" + x).disabled = false;

                                        }
                                    }
                                    else {
                                        document.getElementById("ChkPurchase" + x).style.opacity = "0.3";
                                        //document.getElementById("ChkPurchase" + x).style.backgroundColor = "#337ab7";
                                        document.getElementById("ChkPurchase" + x).disabled = true;
                                    }
                                }
                                else {
                                    document.getElementById("ChkPurchase" + x).style.opacity = "0.3";
                                    //document.getElementById("ChkPurchase" + x).style.backgroundColor = "#337ab7";
                                    document.getElementById("ChkPurchase" + x).disabled = true;
                                }

                                if (response.d[1] != "") {
                                    addCommasSummry(response.d[1]);

                                    if (Currency != "") {
                                        document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i> " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                                    }
                                    else {
                                        document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i> " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;

                                    }
                                }
                                else {
                                    document.getElementById("AccntBalance_" + x).innerHTML = "";
                                }

                                if (response.d[2] == "CR") {
                                    document.getElementById("AccntBalance_" + x).className = "input-group-addon cur2 c1h";
                                }
                                else if (response.d[2] == "DR") {
                                    document.getElementById("AccntBalance_" + x).className = "input-group-addon cur2 dr1";
                                }



                                if (response.d[5] != "") {
                                    if (response.d[5] == "0" || response.d[5] == "1") {
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
                    if (document.getElementById("ddlRecptLedger" + x).value == "") {
                        document.getElementById("ddlLedId" + x).value = 0;
                    }


                }
            }
            return false;
        }

        function calculateTotal() {
            var LedgerTtl = 0, LedgerCrdtTtl = 0;;
            var addRowtable = document.getElementById("tableGrp");

            for (var i = 0; i < addRowtable.rows.length; i++) {
                var ldgramt = "";
                var row = addRowtable.rows[i];
                var x = (addRowtable.rows[i].cells[0].innerHTML);
                if (document.getElementById("TxtAmount_" + x).value != "") {
                    ldgramt = document.getElementById("TxtAmount_" + x).value;
                    ldgramt = ldgramt.replace(/\,/g, '');
                    LedgerTtl = parseFloat(LedgerTtl) + +parseFloat(ldgramt);

                }
                else if (document.getElementById("TxtAmountCrdt" + x).value != "") {
                    ldgramt = document.getElementById("TxtAmountCrdt" + x).value;
                    ldgramt = ldgramt.replace(/\,/g, '');
                    LedgerCrdtTtl = parseFloat(LedgerCrdtTtl) + +parseFloat(ldgramt);

                }
            }




            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

            var DftCurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
            var DdlAccnt = document.getElementById("<%=ddlCurrency.ClientID%>").value;
            var ForexTl = 0;
            if (FloatingValue != "") {
                LedgerTtl = LedgerTtl.toFixed(FloatingValue);
                LedgerCrdtTtl = LedgerCrdtTtl.toFixed(FloatingValue);
            }


            document.getElementById("cphMain_lblTotDeb").value = LedgerTtl;
            document.getElementById("cphMain_lblTotCrdt").value = LedgerCrdtTtl;

            addCommas("cphMain_lblTotDeb");
            addCommas("cphMain_lblTotCrdt");

            document.getElementById("cphMain_lblTotDeb").value = document.getElementById("cphMain_lblTotDeb").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            document.getElementById("cphMain_lblTotCrdt").value = document.getElementById("cphMain_lblTotCrdt").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
        }
        function ButtnFillClickCostCenter(x) {
            var ret = true;
            var purchaseFlag = 0;
            var CheckCount = 0;
            document.getElementById("lblErrMsgCancelReason").style.display = "none";
            var CrdtOrDbt = "";
            var TotalAmnt = "0";
            if (document.getElementById("TxtAmount_" + x).value != "")
            {
                TotalAmnt = document.getElementById("TxtAmount_" + x).value;
                CrdtOrDbt = "DBT";
            }
            if (document.getElementById("TxtAmountCrdt" + x).value != "")
            {
                TotalAmnt = document.getElementById("TxtAmountCrdt" + x).value;
                CrdtOrDbt = "CDT";
            }
            TotalAmnt = TotalAmnt.replace(/\,/g, '');
            var addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "none";
          
            var CstTotal = 0;
            for (var i = 1; i < addRowtable.rows.length; i++) {
                var varId = (addRowtable.rows[i].cells[0].innerHTML);
                if (CCDuplication(x, varId) == false) {
                    ret = false;
                }
                //13-02-2019
                //if (CCGrp1Duplication(x, varId) == false) {
                //    ret = false;
                //}
                //if (CCGrp2Duplication(x, varId) == false) {
                //    ret = false;
                //}

                //13-02-2019
                $("#divCostCenter" + varId + "> input").css("borderColor", '');
               
                   
                    //ddlRecptCosCtr
                    //TxtCstctrAmount
                    document.getElementById("divCostCenter" + varId).style.borderColor = "";
                    document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
                    $("#divCostCenter" + varId + "> input").css("borderColor", '');
                    var Costval = $("#ddlRecptCosCtr_" + varId).val();
                    var CostGrpval = $("#ddlRecptCosGrp1_" + varId).val();
                    var CostGrp2val = $("#ddlRecptCosGrp2_" + varId).val();
                                       
                    if (CostGrpval == 0 && CostGrp2val==0 && Costval == 0 && document.getElementById("TxtCstctrAmount_" + varId).value == "")
                    {

                    }
                   
                    else if (Costval == 0 && document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                        $("#divCostCenter" + varId + "> input").css("borderColor", "Red");
                        document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Please select a cost centre";
                        document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                        $("#divCostCenter" + varId + "> input").focus();
                        $("#divCostCenter" + varId + "> input").select();
                        //$("div.war").fadeIn(200).delay(500).fadeOut(400);
                        ret = false;

                    }
                    else if (Costval != 0 && document.getElementById("TxtCstctrAmount_" + varId).value == "")
                    {
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
                    else
                    {
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
                        document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                        document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                        document.getElementById("TxtCstctrAmount_" + varId).focus();
                       // $("div.war").fadeIn(200).delay(500).fadeOut(400);
                        ret = false;
                    }
                }
            }
            if (ret == true) {
                if (purchaseFlag != 0) {
                    document.getElementById("tdCostCenterDtls" + x).value = "";
                    for (var i = 1; i < addRowtable.rows.length; i++) {
                        var varId = (addRowtable.rows[i].cells[0].innerHTML);
                        var Costval = $("#ddlRecptCosCtr_" + varId).val();
                        if (Costval != 0 && document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                            if (document.getElementById("tdCostCenterDtls" + x).value == "") {
                                document.getElementById("tdCostCenterDtls" + x).value = Costval + "%" + document.getElementById("TxtCstctrAmount_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp1_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp2_" + varId).value;
                            }
                            else {
                                document.getElementById("tdCostCenterDtls" + x).value = document.getElementById("tdCostCenterDtls" + x).value + "$" + Costval + "%" + document.getElementById("TxtCstctrAmount_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp1_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp2_" + varId).value;
                            }
                        }
                    }
                }
                document.getElementById("BttnCost" + x).click();
                document.getElementById("ChkCostCenter" + x).focus();
            }
        }
        function CheckSumOfLedger(textboxid, x) {

            var ret = true;
            var CstTotal = 0;
            AmountChecking(textboxid);
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var LedgerTotal = 0;
            var addRowtable1 = document.getElementById("tableGrp");

            for (var i = 0; i < addRowtable1.rows.length; i++) {
                var row = addRowtable1.rows[i];
                var x = (addRowtable1.rows[i].cells[0].innerHTML);
                var CrdtOrDbt = "";
                var CstCntrId = "";
                var SalesId = "";
                var CostCntrAmt = "";
                var PrchsAmt = "";
                var LdAmt = "0";
                if (document.getElementById("TxtAmount_" + x).value != "") {
                    LdAmt = document.getElementById("TxtAmount_" + x).value;
                    CrdtOrDbt = "DBT";
                }
                if (document.getElementById("TxtAmountCrdt" + x).value != "") {
                    LdAmt = document.getElementById("TxtAmountCrdt" + x).value;
                    CrdtOrDbt = "CDT";
                }
                LdAmt = LdAmt.replace(/\,/g, '');
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
                        if (parseFloat(CstnrTTl) != parseFloat(LdAmt)) {
                            if (CrdtOrDbt == "DBT")
                                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                            else if (CrdtOrDbt == "CDT")
                                document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";
                            else {
                                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                                document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";
                            }
                            $noCon("#divWarning").html("Ledger amount should be equal to cost centre amount. ");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                           
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
                    }


                }
            }
            var LedgerTtl = 0, LedgerCrdtTtl = 0;
            if (ret == true) {

                var addRowtable = document.getElementById("tableGrp");
                var FocusFirstChk = "";
                for (var i = 0; i < addRowtable.rows.length; i++) {

                    var row = addRowtable.rows[i];
                    var x = (addRowtable.rows[i].cells[0].innerHTML);
                    document.getElementById("TxtAmount_" + x).style.borderColor = "";
                    document.getElementById("TxtAmountCrdt" + x).style.borderColor = "";
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
                    else if (document.getElementById("TxtAmountCrdt" + x).value != "") {
                        var ldgramt = document.getElementById("TxtAmountCrdt" + x).value;
                        ldgramt = ldgramt.replace(/\,/g, '');
                        LedgerCrdtTtl = parseFloat(LedgerCrdtTtl) + +parseFloat(ldgramt);
                        if (FloatingValue != "") {
                            ldgramt = parseFloat(ldgramt);
                            ldgramt = ldgramt.toFixed(FloatingValue);
                        }
                        document.getElementById("TxtAmountCrdt" + x).value = ldgramt;
                        addCommas("TxtAmountCrdt" + x);
                    }
                    else {

                        document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                        document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";

                        if (FocusFirstChk == "")
                            FocusFirstChk = x;
                        ret = false;
                    }
                }
                if (FocusFirstChk != "") {
                    document.getElementById("TxtAmount_" + FocusFirstChk).focus();
                }
            }

            if (document.getElementById("ddlRecptLedger" + x).value == 0) {
                $("#divLedger" + x + "> input").css("borderColor", "red");
                $("#divLedger" + x + "> input").focus();
                $("#divLedger" + x + "> input").select();
                ret = false;
            }

            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

            var DftCurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
            var DdlAccnt = document.getElementById("<%=ddlCurrency.ClientID%>").value;
            var ForexTl = 0;
            if (DdlAccnt != "") {
                if (DdlAccnt != DftCurrencyId) {
                    if (document.getElementById("<%=txtExchangeRate.ClientID%>").value != "") {
                        ForexTl = parseFloat(LedgerTtl) * parseFloat(document.getElementById("<%=txtExchangeRate.ClientID%>").value);

                    }
                }
            }
            if (FloatingValue != "") {
                LedgerTtl = LedgerTtl.toFixed(FloatingValue);
                LedgerCrdtTtl = LedgerCrdtTtl.toFixed(FloatingValue);
            }
            document.getElementById("cphMain_lblTotDeb").value = LedgerTtl;
            document.getElementById("cphMain_lblTotCrdt").value = LedgerCrdtTtl;

            addCommas("cphMain_lblTotDeb");
            addCommas("cphMain_lblTotCrdt");

            document.getElementById("cphMain_lblTotDeb").value = document.getElementById("cphMain_lblTotDeb").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            document.getElementById("cphMain_lblTotCrdt").value = document.getElementById("cphMain_lblTotCrdt").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            return ret;
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
        }
        function CheckaddMoreRowsQstn(x, y, xy) {
            IncrmntConfrmCounter();
            var addRowtable;
            var addRowResult = true;
            var check = document.getElementById("tdInxQstn" + x + '' + y).value;
            if (check == "") {
                addRowtable = document.getElementById("TableAddQstnCostCenter_" + x);
             //13-02-2019
                if (CCDuplication(x, xy) == false) {
                    addRowResult = false;
                }

                if (addRowResult == true) {
                    if (CheckAndHighlightCostCenter(x) == false) {
                        addRowResult = false;
                    }
                }

                //if (CCGrp1Duplication(x, xy) == false) {
                //    addRowResult = false;
                //}
                //if (CCGrp2Duplication(x, xy) == false) {
                //    addRowResult = false;
                //}

                if (addRowResult == false) {
                    return false;
                }
                else {
                    document.getElementById("tdInxQstn" + x + '' + y).value = x + '' + y;
                    document.getElementById("btnCostCenter_" + x + '' + y).style.opacity = "0.3";
                    //    CheckSubmitZero();
                    FunctionQustn(x, y, null,null,null);
                    return false;
                }
            }
            return false;
        }



        function CCGrp1Duplication(x, xy) {
            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "none";
            for (var i = 1; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                var xLoopLdgrId = $("#ddlRecptCosGrp1_" + xLoop).val();
                var LedgerId = $("#ddlRecptCosGrp1_" + xy).val();
                // alert(LedgerId = $("#ddlRecptCosGrp1_" + xy).val());
                if (xLoop != xy) {
                    if ($("#ddlRecptCosGrp1_" + xy).val() != "0") {
                        if (xLoopLdgrId == LedgerId) {
                            $("#divCostGrp1" + xy + "> input").css("borderColor", "red");
                            $("#divCostGrp1" + xy + "> input").focus();
                            $("#divCostGrp1" + xy + "> input").select();
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Cost Group should not be duplicated";
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                            $noCon(window).scrollTop(0);
                            //flag++;
                            ret = false;

                        }
                        else {
                            $("#divCostGrp1" + xy + "> input").css("borderColor", "");
                        }
                    }
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
            for (var i = 1; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                var xLoopLdgrId = $("#ddlRecptCosGrp2_" + xLoop).val();
                var LedgerId = $("#ddlRecptCosGrp2_" + xy).val();

                if (xLoop != xy) {
                    if ($("#ddlRecptCosGrp2_" + xy).val() != "0") {
                        if (xLoopLdgrId == LedgerId) {
                            $("#divCostGrp2" + xy + "> input").css("borderColor", "red");
                            $("#divCostGrp2" + xy + "> input").focus();
                            $("#divCostGrp2" + xy + "> input").select();
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Cost Group should not be duplicated";
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                            $noCon(window).scrollTop(0);
                            //flag++;
                            ret = false;

                        }
                        else {
                            $("#divCostGrp2" + xy + "> input").css("borderColor", "");
                        }
                    }
                }
            }
            return ret;
        }

        //13-02-2019

        function CCDuplication(x, xy) {
            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "none";
            for (var i = 1; i < addRowtable.rows.length; i++) {


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
                        document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "";
                        $("div.war").fadeIn(200).delay(500).fadeOut(400);
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
        function CheckAndHighlightCostCenter(x) {
            var ret = true;
            var CstTotal = 0;
            var varId = "";
            var varfocus = "";
            $('#TableAddQstnCostCenter' + x + ' td:first-child').each(function () {
                varId = $(this).text();
                var Costcenterval = $("#ddlRecptCosCtr_" + varId).val();
                var ledgerval = $("#ddlRecptLedger" + x).val();
                document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
                //13-02-2019
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
                    if (Costcenterval == 0) {
                        document.getElementById("ddlRecptCosCtr_" + varId).style.borderColor = "Red";
                        $("#divCostCenter" + varId + "> input").css("borderColor", "red");
                        $("#divCostCenter" + varId + "> input").focus();
                        $("#divCostCenter" + varId + "> input").select();
                        ret = false;

                    }
                }
                if (ledgerval == 0) {
                    $("#divLedger" + x + "> input").css("borderColor", "red");
                    $("#divLedger" + x + "> input").focus();
                    $("#divLedger" + x + "> input").select();
                    ret = false;
                }
            });
            return ret;
        }
        function ValidateReceiptAccnt(ClickedBtn) {
           
            
            var ret = true;
            var AccntDate = document.getElementById("cphMain_txtdate").value;
            document.getElementById("cphMain_txtdate").style.borderColor = "";
            
            if (ClickedBtn.id != "cphMain_btnReopen") {
               
                if (AccntDate == "") {
                    document.getElementById("cphMain_txtdate").style.borderColor = "Red";
                    document.getElementById("cphMain_txtdate").focus();

                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                   
                    $noCon(window).scrollTop(0);
                    ret = false;
                }
            }

            if (ret == true)
            {
                if (!(validateTable()))
                {
                    ret = false;
                }

                else
                {
                   
                    document.getElementById("<%=hiddenLedgerddl.ClientID%>").value = "";
                    document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
                    document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
                    document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";
                }
            }
            
            if (ret == true) {
                if (ClickedBtn.id == "cphMain_btnConfirm" || ClickedBtn.id == "cphMain_btnFloatConfirm") {
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to confirm?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {

                            CheckSaleSettlements();//EVM-0020
                            return false;
                        }
                        else {
                            return false;
                        }
                    });
                    return false;
                }
                else if (ClickedBtn.id == "cphMain_btnReopen" || ClickedBtn.id == "cphMain_btnFloatReopen") {

                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to reopen?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            document.getElementById("cphMain_ButtReopn").click();
                            return false;
                        }
                        else {
                            return false;
                        }
                    });
                    return false;
                }
            }

            return ret;
        }

        function Confirm() {//EVM-0020
            document.getElementById("cphMain_Button1").click();
        }

        function CheckSaleSettlements() {//EVM-0020

            var Settld = 0;
            var SuccessSts = "successConfirm";
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';

            addRowtable = document.getElementById("tableGrp");
            for (var i = 0; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);

                var PurchaseInfo = document.getElementById("tdSaleDtls" + xLoop).value;

                if (PurchaseInfo != "" && PurchaseInfo != null && PurchaseInfo != "null") {

                    var strOrgIdID = '<%=Session["ORGID"]%>';
                    var strCorpID = '<%=Session["CORPOFFICEID"]%>';

                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "fms_Debit_Note.aspx/CheckSaleSettlement",
                        data: '{strSalePurchaseDtls: "' + PurchaseInfo + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '"}',
                        dataType: "json",
                        success: function (data) {

                            if (data.d != "") {
                                SuccessSts = data.d;
                            }

                        }

                    });

                }

                if (SuccessSts == "successConfirm") {
                    if (Settld == 0) {
                        continue;
                    }
                    else {
                        SuccessSts = "PrchsAmtFullySettld";
                    }
                }
                else if (SuccessSts == "PrchsAmtFullySettld") {
                    Settld++;
                    continue;
                }
                else if (SuccessSts == "PrchsAmountExceeded") {
                    break;
                }

            }

            if (SuccessSts == "successConfirm") {
                Confirm();
                return false;
            }
            else if (SuccessSts == "PrchsAmtFullySettld") {

                ezBSAlert({
                    type: "confirm",
                    messageText: "One or more purchase amount(s) is fully settled. Do you want to confirm by deleting added purchases?",
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
            else if (SuccessSts == "PrchsAmountExceeded") {
                PurchaseAmountExceeded();
            }


            return false;
        }





        function validateTable() {
            document.getElementById("<%=HiddenLedgerDtls.ClientID%>").value = "";
            document.getElementById("<%=HiddenCostCentreDtls.ClientID%>").value = "";
            document.getElementById("<%=HiddenSaleDtls.ClientID%>").value = "";

            var Result = true;
            var varfocus = "";
            var varfocusLed = "";
            var varfocusCheck = "";
            var ret = true;
            var purchaseret = true;
            var varTotal = 0;
            var ret = true;
            var CstTotal = 0;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var LedgerTotal = 0;
            var addRowtable1 = document.getElementById("tableGrp");
           
            for (var i = 0; i < addRowtable1.rows.length; i++) {
                var row = addRowtable1.rows[i];
                var x = (addRowtable1.rows[i].cells[0].innerHTML);
                AmountChecking("TxtAmount_" + x);
                AmountChecking("TxtAmountCrdt" + x);
                var CrdtOrDbt = "";
                var CstCntrId = "";
                var SalesId = "";
                var CostCntrAmt = "";
                var PrchsAmt = "";
                var LdAmt = "0";
                if (document.getElementById("TxtAmount_" + x).value != "") {
                    LdAmt = document.getElementById("TxtAmount_" + x).value;
                    CrdtOrDbt = "DBT";
                }
                if (document.getElementById("TxtAmountCrdt" + x).value != "") {
                    LdAmt = document.getElementById("TxtAmountCrdt" + x).value;
                    CrdtOrDbt = "CDT";
                }
                document.getElementById("TxtAmount_" + x).style.borderColor = "";
                document.getElementById("TxtAmountCrdt" + x).style.borderColor = "";
                LdAmt = LdAmt.replace(/\,/g, '');
                if (LdAmt <= 0) {
                    document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                    document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";
                    document.getElementById("TxtAmount_" + x).focus();
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                   
                    $noCon(window).scrollTop(0);
                    ret = false;
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
                        if (parseFloat(CstnrTTl) != parseFloat(LdAmt)) {
                            if (CrdtOrDbt == "DBT")
                                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                            else if (CrdtOrDbt == "CDT")
                                document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";
                            else {
                                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                                document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";
                            }
                            $noCon("#divWarning").html("Ledger amount should be equal to cost centre amount.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                           
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
                    }


                }
            }
            var LedgerTtl = 0, LedgerCrdtTtl = 0;
            if (ret == true) {

                var addRowtable = document.getElementById("tableGrp");
                var FocusFirstChk = "";
                for (var i = 0; i < addRowtable.rows.length; i++) {

                    var row = addRowtable.rows[i];
                    var x = (addRowtable.rows[i].cells[0].innerHTML);
                    document.getElementById("TxtAmount_" + x).style.borderColor = "";
                    document.getElementById("TxtAmountCrdt" + x).style.borderColor = "";
                    if (document.getElementById("ddlRecptLedger" + x).value != 0) {
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
                        else if (document.getElementById("TxtAmountCrdt" + x).value != "") {
                            var ldgramt = document.getElementById("TxtAmountCrdt" + x).value;
                            ldgramt = ldgramt.replace(/\,/g, '');
                            LedgerCrdtTtl = parseFloat(LedgerCrdtTtl) + +parseFloat(ldgramt);
                            if (FloatingValue != "") {
                                ldgramt = parseFloat(ldgramt);
                                ldgramt = ldgramt.toFixed(FloatingValue);
                            }
                            document.getElementById("TxtAmountCrdt" + x).value = ldgramt;
                            addCommas("TxtAmountCrdt" + x);
                        }
                        else {

                            document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                            document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";

                            if (FocusFirstChk == "")
                                FocusFirstChk = x;
                            ret = false;
                        }
                        if (LedgerDuplication(x) == false) {
                            ret = false;
                        }
                    }
                }
                if (FocusFirstChk != "") {
                    document.getElementById("TxtAmount_" + FocusFirstChk).focus();
                }
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

                var DftCurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
                var DdlAccnt = document.getElementById("<%=ddlCurrency.ClientID%>").value;
                var ForexTl = 0;
                if (FloatingValue != "") {
                    LedgerTtl = LedgerTtl.toFixed(FloatingValue);
                    LedgerCrdtTtl = LedgerCrdtTtl.toFixed(FloatingValue);
                }

                document.getElementById("cphMain_lblTotDeb").value = LedgerTtl;
                document.getElementById("cphMain_lblTotCrdt").value = LedgerCrdtTtl;

                document.getElementById("cphMain_lblTotDeb").value = document.getElementById("cphMain_lblTotDeb").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                document.getElementById("cphMain_lblTotCrdt").value = document.getElementById("cphMain_lblTotCrdt").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            }
          //  if (RowLength == 1) {
                addRowtable = document.getElementById("tableGrp");
                var RowLength = addRowtable.rows.length;
                for (var i = 0; i < addRowtable.rows.length; i++) {
                    var row = addRowtable.rows[i];
                    var x = (addRowtable.rows[i].cells[0].innerHTML);
                    //if (document.getElementById("TxtAmount_" + x).value == "") {
                    //    document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                    //    document.getElementById("TxtAmount_" + x).focus();
                    //    ret = false;
                    //}
                    if (document.getElementById("ddlRecptLedger" + x).value == 0) {
                        $("#divLedger" + x + "> input").css("borderColor", "red");
                        $("#divLedger" + x + "> input").focus();
                        $("#divLedger" + x + "> input").select();
                        ret = false;
                    }
                }

         //   }
            if (ret == true) {
                document.getElementById("cphMain_lblTotDeb").style.borderColor = "";
                document.getElementById("cphMain_lblTotCrdt").style.borderColor = "";
                if (LedgerTtl != LedgerCrdtTtl) {
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing.Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

                    });
                   
                    document.getElementById("cphMain_lblTotDeb").style.borderColor = "Red";
                    document.getElementById("cphMain_lblTotCrdt").style.borderColor = "Red";
                    ret = true;
                    return false;
                }

            }
            if (ret == false) {
                return false;
            }
            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];

            var tbClientJobShedulingCost = '';
            tbClientJobShedulingCost = [];

            var tbClientJobShedulingSale = '';
            tbClientJobShedulingSale = [];


            var tabMode = "Deb";
            var tableOtherItem = document.getElementById("tableGrp");

            for (var i = 0; i < tableOtherItem.rows.length; i++) {
                var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                var Ledgr = document.getElementById("ddlRecptLedger" + validRowID).value;
                var LedgerSts = document.getElementById("tdEvtGrp" + validRowID).value;
                var EvtGrp = validRowID;
                if (document.getElementById("tdDtlIdTempid" + validRowID).value != "") {
                    EvtGrp = document.getElementById("tdDtlIdTempid" + validRowID).value;
                }
                if (Ledgr != 0) {
                    var CrdtOrDbt = "";
                    var varTabMode = "";
                    var LedgrAmnt = "0";
                    var LedgrAmntDbt = document.getElementById("TxtAmount_" + validRowID).value.trim().replace(/,/g, "");
                    var LedgrAmntCrdt = document.getElementById("TxtAmountCrdt" + validRowID).value.trim().replace(/,/g, "");
                    //   var LedgrRemarks = document.getElementById("TxtRemark" + validRowID).value.trim();
                    var LedgrRemarks = "";
                    var varPurSts = "";
                    if (LedgrAmntDbt != "") {
                        CrdtOrDbt = "DBT";
                        varPurSts = "Deb";
                        varTabMode = "0";
                        LedgrAmnt = LedgrAmntDbt;
                    }
                    if (LedgrAmntCrdt != "") {
                        CrdtOrDbt = "CDT";
                        varPurSts = "Cre";
                        varTabMode = "1";
                        LedgrAmnt = LedgrAmntCrdt;
                    }
                    var $add = jQuery.noConflict();
                    if (CrdtOrDbt == "DBT") {
                        var client = JSON.stringify({
                            TABMODE: "0",
                            MAINTABID: "" + EvtGrp + "",
                            LEDGRTABID: "",
                            LEDGRID: "" + Ledgr + "",
                            LEDGRAMNT: "" + LedgrAmnt + "",
                            LEDGERSTATUS: "" + LedgerSts + "",
                            REMARKS: "" + LedgrRemarks + "",
                            TBL_ID: "" + validRowID + ""

                        });
                    }
                    else if (CrdtOrDbt == "CDT") {
                        var client = JSON.stringify({
                            TABMODE: "1",
                            MAINTABID: "" + EvtGrp + "",
                            LEDGRTABID: "",
                            LEDGRID: "" + Ledgr + "",
                            LEDGRAMNT: "" + LedgrAmnt + "",
                            LEDGERSTATUS: "" + LedgerSts + "",
                            REMARKS: "" + LedgrRemarks + "",
                            TBL_ID: "" + validRowID + ""
                        });

                    }
                    tbClientJobSheduling.push(client);
                    var DtlCostCenter = document.getElementById("tdCostCenterDtls" + validRowID).value;
                 
                    if (DtlCostCenter != "") {
                        var splitrow = DtlCostCenter.split("$");
                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var splitEach = splitrow[Cst].split("%");
                            if (splitEach[0] != "") {
                                var $add = jQuery.noConflict();
                                var client = JSON.stringify({
                                    TABMODE: "" + varTabMode + "",
                                    MAINTABID: "" + EvtGrp + "",
                                    SUBTABID: "",
                                    COSTCENTRTABID: "",
                                    COSTCENTRID: "" + splitEach[0] + "",
                                    COSTCENTRAMNT: "" + splitEach[1] + "",
                                    PURSALESTS: "",
                                    COSTGRPID_ONE: "" + splitEach[2] + "",
                                    COSTGRPID_TWO: "" + splitEach[3] + "",

                                });
                                tbClientJobShedulingCost.push(client);
                            }
                        }
                    }

                    var DtlSale = document.getElementById("tdSaleDtls" + validRowID).value;
                    if (DtlSale != "") {
                        var splitrow = DtlSale.split("$");
                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var splitEach = splitrow[Cst].split("%");
                            if (splitEach[0] != "") {
                                var $add = jQuery.noConflict();
                                var client = JSON.stringify({
                                    TABMODE: "" + varTabMode + "",
                                    MAINTABID: "" + EvtGrp + "",
                                    PURCHASEID: "" + splitEach[0] + "",
                                    PURCHASEAMNT: "" + splitEach[1] + "",
                                    PURCHASEAMNT_ACT: "" + splitEach[2] + "",
                                });
                                tbClientJobShedulingSale.push(client);
                            }
                        }
                    }
                }
            }


            document.getElementById("<%=HiddenFieldTotAmnt.ClientID%>").value = LedgerCrdtTtl;
            $add("#cphMain_HiddenLedgerDtls").val(JSON.stringify(tbClientJobSheduling));
            $add("#cphMain_HiddenCostCentreDtls").val(JSON.stringify(tbClientJobShedulingCost));
            $add("#cphMain_HiddenSaleDtls").val(JSON.stringify(tbClientJobShedulingSale));
            return ret;
        }
        function ConfirmMessage() {

            //if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Debit_note_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
            //}
            //else {
            //    window.location.href = "fms_Debit_note_List.aspx";
            //}
            return false;

        }

        function SuccessUpdation() {
            $noCon("#success-alert").html("Debit note updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            
            return false;
        }
        function SuccessNotConfirmation() {
            $noCon("#divWarning").html("Debit note already confirmed.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
           
            return false;
        }
        function SuccessInsertion() {
            $noCon("#success-alert").html("Debit note inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            
            return false;

        }
    </script>
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
            IncrmntConfrmCounter();
            $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#cphMain_txtFromdate').val().trim());


        }

        function showTo() {
            IncrmntConfrmCounter();

            $noCon4('#cphMain_HiddentxtefctvedateTo').val($noCon4('#cphMain_txtTodate').val().trim());


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
  
    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au(".ddl").selectToAutocomplete1Letter();
        });
        function clearValue() {
            document.getElementById("<%=hiddenLedgerddl.ClientID%>").value = "";
             document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
             document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
             document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";
             return true;
         }


         function OpenPrint() {

             var orgID = '<%= Session["ORGID"] %>';
             var corptID = '<%= Session["CORPOFFICEID"] %>';
             var UsrName = '<%= Session["USERFULLNAME"] %>';
             var DecCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
             var Id = document.getElementById("<%=HiddenDebitNoteID.ClientID%>").value;
             var crncyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

             if (corptID != "" && corptID != null && orgID != "" && orgID != null && UsrName != null && UsrName != "" && Id != "") {
                 $.ajax({
                     type: "POST",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     url: "fms_Debit_Note.aspx/PrintPDF",
                     data: '{Id: "' + Id + '",orgID: "' + orgID + '",corptID: "' + corptID + '",UsrName: "' + UsrName + '",DecCnt: "' + DecCnt + '",crncyId: "' + crncyId + '"}',
                     dataType: "json",
                     success: function (data) {
                         if (data.d != "") {
                             window.open(data.d, '_blank');
                         }
                     }
                 });
             }
             else {
                 window.location = '/Security/Login.aspx';
             }
             return false;
         }

         function PrintVersnError() {
             $noCon("#divWarning").html("Please select a version for printing from account setting.");
             $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
             });

             return false;
         }
        

         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
      <asp:HiddenField ID="Hiddenreturnfun" runat="server" />
      <asp:HiddenField ID="hiddenCostCenterddl" runat="server" />
      <asp:HiddenField ID="hiddenLedgerddl" runat="server" />
      <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
      <asp:HiddenField ID="HiddenDebitNoteID" runat="server" />
      <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
      <asp:HiddenField ID="HiddenCurrencyAbrv" runat="server" />
      <asp:HiddenField ID="HiddenView" runat="server" />
      <asp:HiddenField ID="HiddenLedgerDtls" runat="server" />
      <asp:HiddenField ID="HiddenCostCentreDtls" runat="server" />
      <asp:HiddenField ID="HiddenFieldTotAmnt" runat="server" />
      <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
      <asp:HiddenField ID="HiddenEdit" runat="server" />
      <asp:HiddenField ID="hiddenLedgerCanclDtlId" runat="server" />
      <asp:HiddenField ID="HiddenSaleDtls" runat="server" />
      <asp:HiddenField ID="hiddenQstnCanclDtlId" runat="server" />
      <asp:HiddenField ID="HiddenGrdTotl" runat="server" />
      <asp:HiddenField ID="HiddenFinancialYearId" runat="server" />  
      <asp:HiddenField ID="HiddenAcntClsDate" runat="server" />
      <asp:HiddenField ID="HiddenAuditClsDate" runat="server" />
      <asp:HiddenField ID="HiddenAuditProvisionStatus" runat="server" />
      <asp:HiddenField ID="HiddenFieldAcntCloseReopenSts" runat="server" />
      <asp:HiddenField ID="HiddenStartDate" runat="server" />
      <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
      <asp:HiddenField ID="HiddenUpdRefNum" runat="server" />
      <asp:HiddenField ID="HiddenRefAccountCls" runat="server" /> 
      <asp:HiddenField ID="HiddenUpdatedDate" runat="server" />
      <asp:HiddenField ID="HiddenRefNum" runat="server" />
      <asp:HiddenField ID="HiddenReOpenStatus" runat="server" />
      <asp:HiddenField ID="HiddenDebitID" runat="server" />
      <asp:HiddenField ID="HiddenDateNow" runat="server" />
      <asp:HiddenField ID="HiddenConfirmSts" runat="server" />
      <asp:HiddenField ID="HiddenCostGroup1ddl" runat="server" />
      <asp:HiddenField ID="HiddenCostGroup2ddl" runat="server" />

  <div id="divLinkSection" runat="server">
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="fms_Debit_note_List.aspx">Debit Note</a></li>
        <li class="active">Add Debit Note</li>
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
                <div class="" onmouseover="closesave()">
                    <h2>
                        <asp:Label ID="lblEntry" runat="server"></asp:Label>
                    </h2>
                    <div id="divList" class="list_b" runat="server" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
                        <i class="fa fa-arrow-circle-left"></i>
                    </div>

                    <div class="fg2">
                        <label for="email" class="fg2_la1">Debit Note REF #<span class="spn1">&nbsp;</span></label>
                        <input id="TxtRef" readonly="readonly" style="" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control fg2_inp1" maxlength="50" />
                    </div>

                    <div class="fg2">
                        <div class="tdte">
                            <label for="pwd" class="fg2_la1">Date<span class="spn1"></span> </label>
                            <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                                <input id="txtdate" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event)" onchange="showFromDate()" class="form-control inp_bdr" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                  <span id="spandate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                            </div>
                        </div>
                    </div>

                    <script>
                        var curentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;
                        var StartDate = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
                        $noCon('#datepicker1').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            startDate: StartDate,
                            endDate: curentDate,
                            timepicker: false
                        });


                        function showFromDate() {
                            document.getElementById("cphMain_txtdate").style.borderColor = "";
                            IncrmntConfrmCounter();
                            var orgID = '<%= Session["ORGID"] %>';
                            var corptID = '<%= Session["CORPOFFICEID"] %>';
                            var usrID = '<%= Session["USERID"] %>';
                            var jrnlDate = $('#cphMain_txtdate').val().trim();
                            var RcptDate = $('#cphMain_HiddenUpdatedDate').val().trim();
                            var RefNum = $('#cphMain_HiddenUpdRefNum').val().trim();
                            var DebitID = $('#cphMain_HiddenDebitID').val().trim();
                            var AcntPrvsn = document.getElementById("<%=HiddenFieldAcntCloseReopenSts.ClientID%>").value
                  var AuditPrvsn = document.getElementById("<%=HiddenAuditProvisionStatus.ClientID%>").value
                            if (jrnlDate != "") {

                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    contentType: "application/json; charset=utf-8",
                                    url: "fms_Debit_Note.aspx/CheckAcntCloseSts",
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
                            if (jrnlDate != "" && (document.getElementById("<%=HiddenFieldAcntCloseReopenSts.ClientID%>").value == "1" || document.getElementById("<%=HiddenAuditProvisionStatus.ClientID%>").value == "1")) {

                      if (document.getElementById("<%=HiddenRefAccountCls.ClientID%>").value == "1") {
                          $.ajax({
                              type: "POST",
                              async: false,
                              contentType: "application/json; charset=utf-8",
                              url: "fms_Debit_Note.aspx/CheckRefNumber",
                              data: '{jrnlDate: "' + jrnlDate + '",orgID: "' + orgID + '",corptID: "' + corptID + '",usrID: "' + usrID + '",DebitID: "' + DebitID + '",RefNum: "' + RefNum + '"}',
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
                                          else {
                                              document.getElementById("cphMain_TxtRef").value = data.d;
                                          }
                                      }
                                      else {
                                          document.getElementById("cphMain_TxtRef").value = data.d;
                                          document.getElementById("cphMain_HiddenRefNum").value = data.d;
                                      }
                                  }
                              }
                          });
                      }

                  }
              }
                        function ButtnFillClickSales() {
                            var ret = true;

                            var TotalAmnt = 0;
                            var TotalPurchaseAmnt = 0;
                            var purchaseFlag = 0;
                            var CheckCount = 0;
                            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                            var TxtTotal = 0;
                            document.getElementById("lblErrMsgCancelReason").style.display = "none";
                            var TxtTotalwithoutarr = document.getElementById("LedgerAmtInModalPurchse").innerText;
                            var TxtTotalarr = TxtTotalwithoutarr.split(" ");
                            if (TxtTotalarr[0] != "") {
                                TxtTotal = TxtTotalarr[0];
                            }
                            TxtTotal = TxtTotal.replace(/\,/g, '');
                            var addRowtable = document.getElementById("TableAddQstn");

                            for (var i = 1; i < addRowtable.rows.length; i++) {
                                var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
                                var tdAmnt = document.getElementById("tdAmnt" + P_Id).innerHTML;
                                var tdLedgerRow = document.getElementById("tdLedgerRow" + P_Id).innerHTML;
                                var purchaseAmt = "";
                                document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "";

                                purchaseAmt = document.getElementById("txtPurchaseAmt" + P_Id).value;

                                if (document.getElementById("tdSettld" + P_Id).value == "0") {//EVM-0020
                                    if (purchaseAmt != "") {
                                        purchaseAmt = purchaseAmt.replace(/\,/g, '');
                                        TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt) + parseFloat(purchaseAmt);
                                        purchaseFlag++;
                                    }
                                    if (parseFloat(purchaseAmt) > parseFloat(tdAmnt)) {
                                        document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the purchase amount";
                                        document.getElementById("lblErrMsgCancelReason").style.display = "";
                                        document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "red";
                                        $("div.war").fadeIn(200).delay(500).fadeOut(400);
                                        ret = false;
                                    }
                                }
                            }

                            if (purchaseFlag == 0) {

                            }
                            else {
                                if (ret == true) {
                                    var TxtTotal = 0;
                                    if (TotalPurchaseAmnt != "") {
                                        //EVM--0024
                                        if (document.getElementById("TxtAmount_" + tdLedgerRow).value != "") {
                                            TxtTotal = document.getElementById("TxtAmount_" + tdLedgerRow).value;
                                            // CedtOrDbt = "DBT";

                                        }
                                        TxtTotal = TxtTotal.replace(/\,/g, '');
                                        if (TotalPurchaseAmnt > TxtTotal) {
                                            if (FloatingValue != "") {
                                                TotalPurchaseAmnt = TotalPurchaseAmnt.toFixed(FloatingValue);
                                            }
                                            document.getElementById("lblErrMsgCancelReason").innerHTML = "Sale return total amount should be less than the ledger amount";
                                            document.getElementById("lblErrMsgCancelReason").style.display = "";
                                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                                            ret = false;
                                        }

                                    }
                                    addCommas("TxtAmount_" + tdLedgerRow);
                                    if (TotalPurchaseAmnt != "") {
                                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                                        if (FloatingValue != "") {
                                            TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt).toFixed(FloatingValue);
                                        }
                                    }
                                    addCommasSummry(TotalPurchaseAmnt);
                                    if (document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value != "") {
                                    }
                                    if (TotalPurchaseAmnt != 0) {
                                        if (FloatingValue != "") {
                                            TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt);
                                            TotalPurchaseAmnt = TotalPurchaseAmnt.toFixed(FloatingValue);
                                        }
                                    }
                                }
                                if (ret == true) {
                                    document.getElementById("tdSaleDtls" + tdLedgerRow).value = "";
                                    for (var i = 1; i < addRowtable.rows.length; i++) {
                                        var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
                                        var tdAmnt = document.getElementById("tdAmnt" + P_Id).innerHTML;
                                        var tdLedgerRow = document.getElementById("tdLedgerRow" + P_Id).innerHTML;
                                        var purchaseAmt = "";
                                        document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "";
                                        purchaseAmt = document.getElementById("txtPurchaseAmt" + P_Id).value;
                                        if (purchaseAmt != "") {
                                            purchaseAmt = purchaseAmt.replace(/\,/g, '');
                                            TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt) + parseFloat(purchaseAmt);
                                        }
                                        if (ret == true) {
                                            if (document.getElementById("tdSaleID" + P_Id).innerHTML != "" && document.getElementById("txtPurchaseAmt" + P_Id).value != "") {
                                                if (document.getElementById("tdSaleDtls" + tdLedgerRow).value == "") {
                                                    document.getElementById("tdSaleDtls" + tdLedgerRow).value = document.getElementById("tdSaleID" + P_Id).innerHTML + "%" + document.getElementById("txtPurchaseAmt" + P_Id).value + "%" + document.getElementById("tdAmnt" + P_Id).innerHTML;
                                                }
                                                else {
                                                    document.getElementById("tdSaleDtls" + tdLedgerRow).value = document.getElementById("tdSaleDtls" + tdLedgerRow).value + "$" + document.getElementById("tdSaleID" + P_Id).innerHTML + "%" + document.getElementById("txtPurchaseAmt" + P_Id).value + "%" + document.getElementById("tdAmnt" + P_Id).innerHTML;
                                                }
                                            }

                                        }
                                    }
                                }
                            }

                            if (ret == true) {
                                if (purchaseFlag != 0) {
                                    calculateTotal();
                                    document.getElementById("BttnTemp").click();
                                    document.getElementById("ChkPurchase" + tdLedgerRow).focus();
                                }
                                else {
                                    document.getElementById("tdSaleDtls" + tdLedgerRow).value = "";
                                    document.getElementById("BttnTemp").click();
                                }
                            }
                        }

              function AmountCalculation(PurchaseId) {
                  var ret = true;
                  AmountChecking("txtPurchaseAmt" + PurchaseId);
                  document.getElementById("lblErrMsgCancelReason").style.display = "none";

                  var tdAmnt = document.getElementById("tdAmnt" + PurchaseId).innerHTML;
                  var tdLedgerRow = document.getElementById("tdLedgerRow" + PurchaseId).innerHTML;
                  tdAmnt = tdAmnt.replace(/\,/g, '');
                  var purchaseAmt = document.getElementById("txtPurchaseAmt" + PurchaseId).value;
                  purchaseAmt = purchaseAmt.replace(/\,/g, '');
                  if (parseFloat(purchaseAmt) > parseFloat(tdAmnt)) {
                      document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the sale amount";
                      document.getElementById("lblErrMsgCancelReason").style.display = "";
                      $("div.war").fadeIn(200).delay(500).fadeOut(400);
                      ret = false;
                  }
                  var TxtTotal = 0;
                  var TotalPurchaseAmnt = 0;
                  var TotalAmnt = 0;
                  var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                  addCommas("txtPurchaseAmt" + PurchaseId);

                  if (ret == true) {
                      var addRowtable = document.getElementById("TableAddQstn");

                      for (var i = 1; i < addRowtable.rows.length; i++) {
                          var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
                          var tdAmnt = document.getElementById("tdAmnt" + P_Id).innerHTML;
                          var tdLedgerRow = document.getElementById("tdLedgerRow" + P_Id).innerHTML;
                          var purchaseAmt = "";
                          document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "";

                          purchaseAmt = document.getElementById("txtPurchaseAmt" + P_Id).value;
                          if (purchaseAmt != "") {
                              purchaseAmt = purchaseAmt.replace(/\,/g, '');
                              TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt) + parseFloat(purchaseAmt);
                          }
                      }
                      addCommas("txtPurchaseAmt" + PurchaseId);
                      TxtTotal = document.getElementById("TxtAmount_" + tdLedgerRow).value;
                      if (TotalPurchaseAmnt > TxtTotal) {
                          if (document.getElementById("txtPurchaseAmt" + PurchaseId).value != "") {
                              if (FloatingValue != "") {
                                  TotalPurchaseAmnt = TotalPurchaseAmnt.toFixed(FloatingValue);
                              }
                              //EVM--0024
                              //    addCommasSummry(TotalPurchaseAmnt);
                              //    document.getElementById("txtPurchaseAmt" + PurchaseId).value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                              document.getElementById("lblErrMsgCancelReason").innerHTML = "Purchase total amount should be less than the ledger amount";
                              document.getElementById("lblErrMsgCancelReason").style.display = "";
                              $("div.war").fadeIn(200).delay(500).fadeOut(400);
                              ret = false;

                          }
                      }
                  }
                  return ret;
              }

                    </script>


                    <table class="table table-bordered" >
                        <thead class="thead1">
                            <tr>
                            
                                <th class="th_b9 tr_l">Particulars</th>
                                <th class="th_b8 tr_r">Debit Amount</th>
                                <th class="th_b8 tr_r">Credit Amount</th>
                                <th class="th_b2 tr_l">Remarks</th>
                                <th class="th_b6 tr_c">ACTIONS</th>
                                <th class="th_b8 tr_c">Purchase Return/CC</th>

                               
                            </tr>
                        </thead>
                        <tbody id="tableGrp" >
                        </tbody>
                        <tfoot class="ft_q">
                            <tr>
                                <th class="th_b9 t_r">Total Amount</th>
                                <th class="th_b8 tr_c tr_r am3">
                                    <input disabled="disabled" id="lblTotDeb" runat="server" class="fgs4 tr_r" /><label id="LblDbtTot" runat="server"></label></th>
                                <th id="Th1" class="th_b8 tr_c tr_r am2" runat="server">
                                    <input disabled="disabled" id="lblTotCrdt" runat="server" class="fgs4 tr_r" /><label id="LblCrdtTot" runat="server"></label></th>
                                <th class="th_b2 tr_c"></th>
                                <th class="th_b6 tr_c"></th>
                                <th class="th_b8 tr_c"></th>
                            </tr>
                        </tfoot>
                    </table>

  <div class="text_area_container">
      <div class="col-md-8 mar_a flt_l">
          <div class="form-group">
              <label for="email" class="fg2_la1">Description:<span class="spn1">&nbsp;</span></label>
              <textarea class="form-control" id="txtDescription" runat="server" onkeypress="return  isTagEnter(event);" onblur=" RemoveTag('cphMain_txtDescription');" maxlength="450"  rows="4" cols="50"   style="resize: none;">
                </textarea>
          </div>
      </div>
                   
                   <%-- <div class="text_area_container">
                        <div class="col-md-8">
                            <div class="form-group iv">
                                <label for="email" class="fg2_la1">Description:<span class="spn1">&nbsp;</span></label>--%>
                                <%--<textarea id="txtDescription" class="form-control" runat="server" rows="4" cols="50" onkeypress="return textCounter(cphMain_txtDescription, 150)" onblur="return textCounter(cphMain_txtDescription, 150)" onchange="return textCounter(cphMain_txtDescription, 150)">--%>
                    <%-- </textarea>
                            </div>
                        </div>--%>
                    </div>

                     </div>
                    <div class="clearfix"></div>
                    <div class="free_sp"></div>
                    <div class="devider divid"></div>
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
                    <div class="sub_cont pull-right">
                        <div class="save_sec">
                            <asp:Button ID="bttnsave" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" OnClick="bttnsave_Click" class="btn sub1" Text="Save" />
                            <asp:Button ID="bttnsaveClose" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" OnClick="bttnsave_Click" class="btn sub3" Text="Save & Close" />
                            <asp:Button ID="btnUpdate" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" OnClick="btnUpdate_Click" class="btn sub1" Text="Update" />
                            <asp:Button ID="btnUpdatecls" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" OnClick="btnUpdate_Click" class="btn sub3" Text="Update & Close" />
                            <asp:Button ID="btnConfirm" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub2" Text="Confirm" />
                            <asp:Button ID="btnConfirm1" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub2" Text="confm" Style="display: none;" />
                            <asp:Button ID="btnReopen" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub2" Text="Reopen" />
                            <input type="button" id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
                            <asp:Button ID="ButtReopn" runat="server" Style="display: none;" OnClick="ButtReopn_Click" class="btn sub2" Text="Confirm" />
                            <asp:Button ID="Button1" runat="server" Style="display: none;" OnClick="btnUpdate_Click" class="btn sub2" Text="Confirm" />
                            <asp:Button ID="btnPRint" runat="server" class="btn sub2" Text="Print" OnClientClick="return  OpenPrint(); " />
                            <asp:Button ID="btnClear"  runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                        </div>
                    </div>

                    <div class="mySave1" id="mySave" runat="server">
                    <div class="save_sec">
                            <asp:Button ID="btnFloatSave" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" OnClick="bttnsave_Click" class="btn sub1" Text="Save" />
                            <asp:Button ID="bttnFloatsaveClose" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" OnClick="bttnsave_Click" class="btn sub3" Text="Save & Close" />
                            <asp:Button ID="btnFloatUpdate" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" OnClick="btnUpdate_Click" class="btn sub1" Text="Update" />
                            <asp:Button ID="btnFloatUpdatecls" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" OnClick="btnUpdate_Click" class="btn sub3" Text="Update & Close" />
                            <asp:Button ID="btnFloatConfirm" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub2" Text="Confirm" />
                            <asp:Button ID="btnFloatConfirm1" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub2" Text="confm" Style="display: none;" />
                            <asp:Button ID="btnFloatReopen" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub2" Text="Reopen" />
                            <input type="button" id="btnFloatCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
                         <asp:Button ID="ButtnFloatClear"  runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                            <asp:Button ID="ButtFloatReopn" runat="server" Style="display: none;" OnClick="ButtReopn_Click" class="btn sub2" Text="Confirm" />
                            <asp:Button ID="Button11" runat="server" Style="display: none;" OnClick="btnUpdate_Click" class="btn sub2" Text="Confirm" />
                            <asp:Button ID="btnFloatPRint" runat="server" class="btn sub2" Text="Print" OnClientClick="return  OpenPrint(); " />
                        </div>
                    </div>
                    <div class="form-group col-md-4" style="display: none; padding-right: 0%; width: 28%;">
                        <label for="example-text-input" style="width: 28%;" class="col-md-3 col-form-label">Currency<span>*</span></label>
                        <div class="col-md-8" style="width: 67%;">
                            <asp:DropDownList ID="ddlCurrency" class="form-control" Style="width: 125%;" onchange="enableexchangeRate();" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="divExchangeRate" runat="server" class="col-md-4" style="margin-bottom: 20px; display: none; margin-left: 5%; padding-left: 0%; width: 32%;">
                        <label for="example-text-input" class="col-md-5 col-form-label" style="padding: 0%; width: 33%;">Exchange Currency</label>
                        <div class="col-md-7">
                            <input id="txtExchangeRate" style="width: 101%; /*! margin-left: 2%; */" runat="server" type="text" onkeypress="return DisableEnter(event)" onblur="calculateTotal()" class="form-control" maxlength="12" />
                        </div>
                        <label id="CurrencyAbrv" for="example-text-input" class="col-md-5 col-form-label" style="/*! padding: 0%; */width: 18%; /*! margin-left: 93%; *//*! margin-top: 4%; *//*! float: right; */margin-top: 2%; margin-right: -11%; /*! margin-bottom: -18%; */"></label>
                    </div>

                    
                    

                   
                </div>
            </div>
        </div>


<input id="txtGrantTotal" readonly="readonly" style="width: 100%; margin-left: 2%; float: right; text-align: right;display:none" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control" maxlength="50" />
<button id="BtnPopup" type="button" style="display:none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>
<button id="BtnPopupCstCntr" type="button" style="display:none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModalCstCntr">Open Modal</button>

  
         
    <div class="modal fade" id="myModal" tabindex="-1"  data-backdrop="static" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title mod1 flt_l" id="exampleModalLabel"><i class="fa fa-line-chart"></i>Purchase Bill of 
          <span class="spn_mod" id="MoHeading"></span></h2>
                    <button type="button" class="close" onclick="return CloseModalPurchase()">
                        <h4 id="ModelHeading" class="modal-title" style="display: none"></h4>
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>
                <div class="modal-body md_bd1">
                    <div id="DivPopUpSales">
                    </div>
                    <div class="clearfix"></div>
                    <div class="devider"></div>
                    <div class="col-md-12 col_mar">
                        <div class="box6 tr_r">
                            <label id="Label1" for="example-text-input" class="fg2_la1 tt_am am1">Ledger Amount<span class="spn1"></span>:</label>

                        </div>
                        <div class="box6 flt_r">
                            <span id="LedgerAmtInModalPurchse" class="tt_am am1 tt_al"></span>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btnImportSales" type="button" class="btn btn-success" onclick="ButtnFillClickSales();">Submit</button>
                                      <button type="button" class="btn btn-danger" onclick="return CloseModalPurchase()">Cancel</button>
                    <button id="BttnTemp" type="button" style="display: none" class="btn btn-danger" data-dismiss="modal"></button>
                </div>
            </div>
        </div>
    </div> 
        <div id="CostCenterModal"></div>        
                                
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

