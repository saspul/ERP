<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Postdated_Cheque.aspx.cs" Inherits="FMS_FMS_Master_fms_Postdated_Cheque_fms_Postdated_Cheque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
    <script src="/js/Common/Common.js"></script>
    <link href="/css/rec.css" rel="stylesheet" />
        <script>

            var confirmbox = 0;

            function IncrmntConfrmCounter() {
                confirmbox++;
                return false;
            }

            var $noCon = jQuery.noConflict();
            $noCon(window).load(function () {

                ChangeMethod();
                GetBalance();

                document.getElementById("cphMain_hiddenSelectedAccntBk").value = document.getElementById("cphMain_ddlAccontLed").value;

                IssueDateCheck();
                if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0") {
                    document.getElementById("Cheque_details").style.display = "block";
                    document.getElementById("thIban").style.display = "none";
                    document.getElementById("thFirst").innerHTML = "Cheque Book";                   
                    if (document.getElementById("<%=HiddenFieldChequePrint.ClientID%>").value == "1") {
                        document.getElementById("thPrint").style.display = "";
                    }
                    else {
                        document.getElementById("thPrint").style.display = "none";
                    }
                    document.getElementById("DivAccountParty").style.display = "block";
                    document.getElementById("DivAccountParty1").style.display = "none";
                }
                else {
                    document.getElementById("thPrint").style.display = "none";
                    document.getElementById("Cheque_details").style.display = "none";
                    document.getElementById("thIban").style.display = "";
                    document.getElementById("thFirst").innerHTML = "Bank";

                    document.getElementById("DivAccountParty").style.display = "none";
                    document.getElementById("DivAccountParty1").style.display = "block";
                }


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
                            if (json[key].PST_CHEQUE_DTLS_ID != "") {
                                EditListRows(json[key].PST_CHEQUE_ID, json[key].PST_CHEQUE_DTLS_ID, json[key].CHKBK_ID, json[key].CHQ_DTLS_NUMBER, json[key].CHQ_DTLS_AMOUNT, json[key].CHQ_DTLS_CHQ_DATE, json[key].CHQ_DTLS_REMARK, json[key].CHQ_DTLS_PAID_RJCT_STATUS, json[key].PST_CHEQUE_CONFIRM_STATUS, json[key].CHQ_DTLS_BANK, json[key].CHQ_DTLS_IBAN);
                            }
                        }
                    }
                    buttnVisibile();

                    addCommas("cphMain_txtGrantTotal");
                }
                else {
                    AddChequeDetails(null,null,null);
                }
                var ReopenSts = '<%= Session["REOPEN_STS"] %>';
                if (ReopenSts != '') {
                    if (ReopenSts == 'successReopen') {
                        successReopen();
                    }
                    else if (ReopenSts == 'failed') {
                        SuccessError();
                    } else if (ReopenSts == 'successConfirm') {
                        SuccesssuccessConfirm();
                    }

                }

                $noCon("#DivAccountBook input.ui-autocomplete-input").focus();
                $noCon("#DivAccountBook input.ui-autocomplete-input").select();

            });
            var currntx = 0;
            function EditListRows(PST_CHEQUE_ID, PST_CHEQUE_DTLS_ID, CHKBK_ID, CHQ_DTLS_NUMBER, CHQ_DTLS_AMOUNT, CHQ_DTLS_CHQ_DATE, CHQ_DTLS_REMARK, CHQ_DTLS_PAID_RJCT_STATUS, PST_CHEQUE_CONFIRM_STATUS, CHQ_DTLS_BANK, CHQ_DTLS_IBAN) {
                if (PST_CHEQUE_DTLS_ID != 0) {
                  
                    AddChequeDetails(CHKBK_ID, PST_CHEQUE_DTLS_ID, CHQ_DTLS_CHQ_DATE);
                    document.getElementById("txtChequeAmount" + currntx).value = CHQ_DTLS_AMOUNT;
                    addCommas("txtChequeAmount" + currntx);
                    document.getElementById("TxtRemark" + currntx).value = CHQ_DTLS_REMARK;

                    if (CHKBK_ID == "" || CHKBK_ID == null) {
                        document.getElementById("txtRcBank" + currntx).value = CHQ_DTLS_BANK;
                        document.getElementById("txtRcIban" + currntx).value = CHQ_DTLS_IBAN;
                        document.getElementById("txtRcAcntNum" + currntx).value = CHQ_DTLS_NUMBER;
                    }
                    document.getElementById("tdInxGrp" + currntx).value = currntx;
                    document.getElementById("btnChequeAdd" + currntx).style.opacity = "0.3";
                    if (CHKBK_ID != 0 && CHKBK_ID != "") {
                        LoadChequeBookNum(CHKBK_ID, CHQ_DTLS_NUMBER, "1", currntx);
                    }
                    if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                        document.getElementById("btnChequePrint" + RowId).style.opacity = "1";
                        document.getElementById("btnChequePrint" + RowId).disabled = false;
                        document.getElementById("ddlChequeBook" + currntx).disabled = true;
                        document.getElementById("ddlChequeNumber" + currntx).disabled = true;
                        document.getElementById("TxtRemark" + currntx).disabled = true;
                        document.getElementById("btnChequeAdd" + currntx).disabled = true;
                        document.getElementById("btnChequeDelete" + currntx).disabled = true;
                        $("#Cheque_tBody").find("input").attr("disabled", "disabled");
                    }


                    CheckPaymentPaid(PST_CHEQUE_ID, PST_CHEQUE_DTLS_ID, currntx);

                    var GenSts = document.getElementById("tdPaymntRecptId" + currntx).value;


                    if (PST_CHEQUE_CONFIRM_STATUS == "1") {
                        document.getElementById("btnChequePaid" + RowId).style.opacity = "1";
                        document.getElementById("btnChequeReject" + RowId).style.opacity = "1";
                        document.getElementById("btnChequePaid" + RowId).disabled = false;
                        document.getElementById("btnChequeReject" + RowId).disabled = false;

                        if (GenSts == "") {
                            document.getElementById("btnGen" + RowId).style.opacity = "1";
                            document.getElementById("btnGen" + RowId).disabled = false;
                            document.getElementById("btnChequePaid" + RowId).disabled = true;
                        }
                    }
                    if (CHQ_DTLS_PAID_RJCT_STATUS == "1" || CHQ_DTLS_PAID_RJCT_STATUS == "2") {
                        document.getElementById("btnChequePaid" + RowId).disabled = true;
                        document.getElementById("btnChequeReject" + RowId).disabled = true;

                        document.getElementById("btnGen" + RowId).style.opacity = "0.3";
                        document.getElementById("btnGen" + RowId).disabled = true;
                    }
                    if (CHQ_DTLS_PAID_RJCT_STATUS == "1") {
                        document.getElementById("btnChequePaid" + RowId).innerHTML = "Paid";
                        document.getElementById("btnChequeReject" + RowId).style.display = "none";
                    }
                    else if (CHQ_DTLS_PAID_RJCT_STATUS == "2") {
                        document.getElementById("btnChequeReject" + RowId).innerHTML = "Rejected";
                        document.getElementById("btnChequePaid" + RowId).style.display = "none";
                        document.getElementById("btnChequeCnclReject" + RowId).style.display = "block";
                    }
                   
                    if (document.getElementById("<%=hiddenEndYrClose.ClientID%>").value == "1") {
                        document.getElementById("btnChequeReject" + RowId).disabled = true;
                        document.getElementById("btnChequePaid" + RowId).disabled = true;
                        document.getElementById("btnGen" + RowId).disabled = true;
                    }


                    if (document.getElementById("<%=hiddenModalView.ClientID%>").value == "1") {
                        document.getElementById("btnChequeReject" + RowId).disabled = true;
                        document.getElementById("btnChequePaid" + RowId).disabled = true;
                        document.getElementById("btnGen" + RowId).disabled = true;
                    }

                }
            }
            function CheckPaymentPaid(ChkId, ChkBkId, RowId) {

                var CorpId = '<%= Session["CORPOFFICEID"] %>';
                var OrgId = '<%= Session["ORGID"] %>';
                var TranType=document.getElementById("<%=ddlTranscationType.ClientID%>").value;
                var AcntClosePrvsn = document.getElementById("<%=HiddenFieldAcntCloseReopenSts.ClientID%>").value;
                var AuditClosePrvsn = document.getElementById("<%=HiddenAuditProvisionStatus.ClientID%>").value;
                var Date = document.getElementById("txtChequedate" + RowId).value;
                var Method = document.getElementById("<%=ddlMethod.ClientID%>").value;

                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "fms_Postdated_Cheque.aspx/CheckPaymentInserted",
                    data: '{ChkId:"' + ChkId + '",ChkBkId:"' + ChkBkId + '",TranType:"' + TranType + '",CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",AcntClosePrvsn:"' + AcntClosePrvsn + '",AuditClosePrvsn:"' + AuditClosePrvsn + '",Date:"' + Date + '",Method:"' + Method + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        result = response.d[0];
                        document.getElementById("tdPaymntRecptId" + RowId).value = "";
                        document.getElementById("tdPaymntRecptRef" + RowId).value = response.d[1];
                        if (result != "Not_Paid") {
                            document.getElementById("tdPaymntRecptId" + RowId).value = result;
                            document.getElementById("btnChequeReject" + RowId).style.display = "none";
                        }

                    }
                });
                return false;
            }

      </script>
    <script>

        var RowId = 0;
        function AddChequeDetails(CHKBK_ID, PST_CHEQUE_DTLS_ID, CHQ_DTLS_CHQ_DATE) {
            RowId++;
            var FrecRow = '';
            FrecRow = '<tr class="tr1" id="SubGrpRowId_' + RowId + '">';
            FrecRow += '<td   id="tdidGrpDtls' + RowId + '" style="display: none" >' + RowId + '</td>';

            if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0") {


                FrecRow += '<td ><div id="divChequeBook' + RowId + '"><select id="ddlChequeBook' + RowId + '" name="ddlChequeBook' + RowId + '" onchange="LoadChequeBookNum(' + null + ',' + null + ',' + "0" + ',' + RowId + ');" onkeypress="return DisableEnter(event)" class="fg2_inp2 fg2_inp2 fg_chs1 pst_dt"></select></div></td>';
                FrecRow += '<td ><div id="divChequeNumber' + RowId + '"><select id="ddlChequeNumber' + RowId + '" name="ddlChequeNumber' + RowId + '" onkeypress="return DisableEnter(event)" onchange="IncrmntConfrmCounter()" class="fg2_inp2 fg2_inp2 fg_chs1 pst_dt" onchange="return ChangeChequeNo(' + RowId + ');"></select></div></td>';

                FrecRow += '<td style="display:none;" class="tr_r"><input onchange="changeBankAcNum(' + RowId + ');"  id="txtRcBank' + RowId + '" autocomplete="off" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" onchange="IncrmntConfrmCounter()"  name="txtRcBank' + RowId + '"  type="text"  class="form-control fg2_inp2 tr_r"  maxlength="50" /></td>';
                FrecRow += '<td style="display:none;" class="tr_r"><input id="txtRcIban' + RowId + '" autocomplete="off" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)"  name="txtRcIban' + RowId + '"  type="text" onchange="IncrmntConfrmCounter()" class="form-control fg2_inp2 tr_r"  maxlength="50" /></td>';
                FrecRow += '<td style="display:none;" class="tr_r"><input onchange="changeBankAcNum(' + RowId + ');"  id="txtRcAcntNum' + RowId + '" autocomplete="off" onkeypress="return isNumber(event)" onkeydown="return isNumber(event)"  name="txtRcAcntNum' + RowId + '" onchange="IncrmntConfrmCounter()" type="text"  class="form-control fg2_inp2 tr_r"  maxlength="10" /></td>';

            }
            else {

                FrecRow += '<td style="display:none;"><div  id="divChequeBook' + RowId + '"><select id="ddlChequeBook' + RowId + '" name="ddlChequeBook' + RowId + '" onchange="LoadChequeBookNum(' + null + ',' + null + ',' + "0" + ',' + RowId + ');" onkeypress="return DisableEnter(event)" class="fg2_inp2 fg2_inp2 fg_chs1 pst_dt"></select></div></td>';
                FrecRow += '<td style="display:none;"><div id="divChequeNumber' + RowId + '"><select id="ddlChequeNumber' + RowId + '" name="ddlChequeNumber' + RowId + '" onkeypress="return DisableEnter(event)" class="fg2_inp2 fg2_inp2 fg_chs1 pst_dt" onchange="return ChangeChequeNo(' + RowId + ');"></select></div></td>';

                FrecRow += '<td class="tr_r"><input onchange="changeBankAcNum(' + RowId + ');" style="text-align: left !important;"  id="txtRcBank' + RowId + '" autocomplete="off" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)"  name="txtRcBank' + RowId + '" onchange="IncrmntConfrmCounter()" type="text"  class="form-control fg2_inp2 tr_r"  maxlength="50" /></td>';
                FrecRow += '<td class="tr_r"><input style="text-align: left !important;"  id="txtRcIban' + RowId + '" autocomplete="off" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)"  name="txtRcIban' + RowId + '"  type="text"  class="form-control fg2_inp2 tr_r" onchange="IncrmntConfrmCounter()" maxlength="50" /></td>';
                FrecRow += '<td class="tr_r"><input onchange="changeBankAcNum(' + RowId + ');" style="text-align: left !important;" id="txtRcAcntNum' + RowId + '" autocomplete="off" onkeypress="return isNumber(event)" onkeydown="return isNumber(event)"  name="txtRcAcntNum' + RowId + '" onchange="IncrmntConfrmCounter()" type="text"  class="form-control fg2_inp2 tr_r"  maxlength="10" /></td>';
            }
            if (CHQ_DTLS_CHQ_DATE != null)
                FrecRow += '<td ><div id="divChequeDate' + RowId + '" class="input-group date" data-date-format="dd-mm-yyyy"><input autocomplete="off" value="' + CHQ_DTLS_CHQ_DATE + '" placeholder="dd-mm-yyyy" id="txtChequedate' + RowId + '" name="txtChequedate' + RowId + '" onchange="IncrmntConfrmCounter()" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" class="form-control inp_bdr fg2_inp2" type="text"  /><span class="input-group-addon date1 int_dt dl_nn"><i class="fa fa-calendar"></i></span></div></td>';
            else
                FrecRow += '<td ><div id="divChequeDate' + RowId + '" class="input-group date" data-date-format="dd-mm-yyyy"><input autocomplete="off" placeholder="dd-mm-yyyy" id="txtChequedate' + RowId + '" name="txtChequedate' + RowId + '" onchange="IncrmntConfrmCounter()" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" class="form-control inp_bdr fg2_inp2" type="text"  /><span class="input-group-addon date1 int_dt dl_nn"><i class="fa fa-calendar"></i></span></div></td>';
            //            FrecRow += '<td ><input id="txtChequedate' + RowId + '" name="txtChequedate' + RowId + '" type="date" class="fg2_inp2 tr_c pst_dt" onkeypress="return DisableEnter(event)"/></td>';
            FrecRow += '<td class="tr_r"><input id="txtChequeAmount' + RowId + '" autocomplete="off" onkeydown="return isDecimalNumber(event,\'txtChequeAmount' + RowId + '\');" onkeypress="return isDecimalNumber(event,\'txtChequeAmount' + RowId + '\');"  name="txtChequeAmount' + RowId + '" onblur="return CheckSumOfCheque(\'txtChequeAmount' + RowId + '\');" onchange="IncrmntConfrmCounter()" type="text" onkeypress="return DisableEnter(event)" class="form-control fg2_inp2 tr_r"  maxlength="10" /></td>';
            FrecRow += '<td class="tr_r"> <textarea   name="TxtRemark' + RowId + '"  value="" id="TxtRemark' + RowId + '" maxlength="450"  rows="3" cols="20"  class="form-control" style="resize: none;" onkeydown="IncrmntConfrmCounter()" onblur="textCounter(TxtRemark' + RowId + ',450)" onkeyup="textCounter(TxtRemark' + RowId + ',450)"></textarea></td>';
            FrecRow += '<td class="td1"><div class="btn_stl1">';
            FrecRow += '<button id="btnChequeAdd' + RowId + '" class="btn act_btn bn2" onclick="return AddNewChequeDetails(\'' + RowId + '\')" title="Add New"><i class="fa fa-plus-circle"></i></button><button id="btnChequeDelete' + RowId + '" onclick="return removeCheque(' + RowId + ',\'Are you sure you want to delete this cheque?\')"  class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';
            FrecRow += '</div></td>';


            FrecRow += '<td class="td1"><div class="btn_stl1"><button id="btnGen' + RowId + '" class="btn act_btn bn8" title="Generate" onclick="return PaidRejctStatusUpdate(' + PST_CHEQUE_DTLS_ID + ',' + "1" + ',' + RowId + ')"><i class="fa fa-puzzle-piece "></i></button></div>';

            FrecRow += '<td ><div class="btn_stl1"><button id="btnChequePaid' + RowId + '"  onclick="return PaidRejctStatusUpdate(' + PST_CHEQUE_DTLS_ID + ',' + "1" + ',' + RowId + ')" class="btn act_btn bn2" data-toggle="modal" data-target="#exampleModal3" title="Paid"><i class="fa fa-check"></i></button>';
            FrecRow += '<button id="btnChequeReject' + RowId + '" onclick="return PaidRejctStatusUpdate(' + PST_CHEQUE_DTLS_ID + ',' + "2" + ',' + RowId + ')"  class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal3" title="Reject"><i class="fa fa-times"></i></button>';
            FrecRow += '<button id="btnChequeCnclReject' + RowId + '" onclick="return PaidRejctStatusUpdate(' + PST_CHEQUE_DTLS_ID + ',' + "0" + ',' + RowId + ')"  class="btn act_btn bn2" data-toggle="modal" data-target="#exampleModal3" title="Recall Rejected"><i class="fa fa-unlock"></i></button></div></td>';



            if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0" && document.getElementById("<%=HiddenFieldChequePrint.ClientID%>").value == "1") {
                FrecRow += '<td><button id="btnChequePrint' + RowId + '" class="btn act_btn bn6" onclick="return ChequePrint(' + RowId + ')" title="Print"><i class="fa fa-print"></i></button></td>';
            }
            else {
                FrecRow += '<td style="display:none;"><button id="btnChequePrint' + RowId + '" class="btn act_btn bn6" onclick="return ChequePrint(' + RowId + ')" title="Print"><i class="fa fa-print"></i></button></td>';
            }
            FrecRow += '<td style="display: none;"><input type="text" style="display:none;"  id="tdInxGrp' + RowId + '" name="tdInxGrp' + RowId + '" /> </td>';
            FrecRow += '<td style="display: none;"><input type="text" style="display:none;"  id="tdPaymntRecptId' + RowId + '" name="tdPaymntRecptId' + RowId + '" /> </td>';
            FrecRow += '<td style="display: none;"><input type="text" style="display:none;"  id="tdPaymntRecptRef' + RowId + '" name="tdPaymntRecptRef' + RowId + '" /> </td>';

            FrecRow += '</tr>';
            jQuery('#Cheque_tBody').append(FrecRow);
            var ddlTestDropDownListXML = "";
            ddlTestDropDownListXML = $noCon("#ddlChequeBook" + RowId);
            var ddlTestDropDownListXML1 = "";
            ddlTestDropDownListXML1 = $noCon("#ddlChequeNumber" + RowId);
            var OptionStart = $noCon("<option>--SELECT--</option>");
            OptionStart.attr("value", 0);
            var OptionStart1 = $noCon("<option>--SELECT--</option>");
            OptionStart1.attr("value", 0);
            ddlTestDropDownListXML.append(OptionStart);
            ddlTestDropDownListXML1.append(OptionStart1);
            if (document.getElementById("cphMain_ddlAccontLed").value != 0 && document.getElementById("cphMain_ddlAccontLed").value != "--SELECT--") {
                FillChequeBookLoad(RowId, CHKBK_ID, '0');
            }
            var StartDate = "";
            if (document.getElementById("<%=HiddenRestritionStatus.ClientID%>").value == "1")
                StartDate = document.getElementById("<%=HiddenFinancialYrStartDate.ClientID%>").value;
            else
                StartDate = document.getElementById("<%=HiddenToday.ClientID%>").value;
            var curentDate = "";
            curentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;
            if (CHQ_DTLS_CHQ_DATE != "" && CHQ_DTLS_CHQ_DATE != null) {
                StartDate = CHQ_DTLS_CHQ_DATE;
            }

            $noCon('#divChequeDate' + RowId + '').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                startDate: StartDate,
                //endDate: '31-12-2020',
                timepicker: false,

            });
            
            document.getElementById("btnChequePaid" + RowId).style.opacity = "0.3";
            document.getElementById("btnChequePaid" + RowId).disabled = true;
            document.getElementById("btnChequeReject" + RowId).disabled = true;
            document.getElementById("btnChequeReject" + RowId).style.opacity = "0.3";
            document.getElementById("btnChequeCnclReject" + RowId).style.display = "none";
            document.getElementById("btnChequePrint" + RowId).style.opacity = "0.3";
            document.getElementById("btnChequePrint" + RowId).disabled = true;
            document.getElementById("btnGen" + RowId).style.opacity = "0.3";
            document.getElementById("btnGen" + RowId).disabled = true;

            currntx = RowId;
            if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0") {
                document.getElementById("ddlChequeBook" + RowId).focus();
            }
            else {
                document.getElementById("txtRcBank" + RowId).focus();
            }
            return false;
        }

        function ChequePrint(RowId) {
            IncrmntConfrmCounter();
            var ChequeBook = document.getElementById("ddlChequeBook" + RowId).value;
            var ChequeBookDate = document.getElementById("txtChequedate" + RowId).value;
            var ChequeBookAmt = document.getElementById("txtChequeAmount" + RowId).value;
            var intOrgID = '<%= Session["ORGID"] %>';
            var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
            var CurrencyId = document.getElementById("<%=HiddenCurrencyId.ClientID%>").value;
            var PostdatedChequeId = document.getElementById("cphMain_HiddenPostdatedChequeId").value;
            if (ChequeBook != 0 && ChequeBook != null) {
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "fms_Postdated_Cheque.aspx/PrintPostDated",
                    data: '{ChequeBook:"' + ChequeBook + '",CurrencyId:"' + CurrencyId + '",intOrgID:"' + intOrgID + '",intCorrpID:"' + intCorrpID + '",PostdatedChequeId:"' + PostdatedChequeId + '",ChequeBookDate:"' + ChequeBookDate + '",ChequeBookAmt:"' + ChequeBookAmt + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        result = response.d;
                        document.getElementById("cphMain_PlblHeight").value = result[4];
                        document.getElementById("cphMain_PlblWidth").value = result[5];
                        document.getElementById("cphMain_PlblPayeeLeft").value = result[6];
                        document.getElementById("cphMain_PlblPayeeTop").value = result[7];
                        document.getElementById("cphMain_PlblDateLeft").value = result[8];
                        document.getElementById("cphMain_PlblDateTop").value = result[9];
                        document.getElementById("cphMain_PlblAmntWordLeft").value = result[10];
                        document.getElementById("cphMain_PlblAmntWordTop").value = result[11];
                        document.getElementById("cphMain_PlblAmntWordLeft1").value = result[12];
                        document.getElementById("cphMain_PlblAmntWordTop1").value = result[13];
                        document.getElementById("cphMain_PlblAmntNumTop").value = result[14];
                        document.getElementById("cphMain_PlblAmntNumLeft").value = result[15];
                        document.getElementById("cphMain_txtPrintPos").value = result[16];

                        if (result[0] != "")
                            document.getElementById("cphMain_TextBox1").value = result[0];
                        if (result[1] != "")
                            document.getElementById("cphMain_TextBox2").value = result[1];
                        if (result[2] != "")
                            document.getElementById("cphMain_TextBox3").value = result[2];
                        if (result[3] != "") {
                            document.getElementById("cphMain_TextBox4").value = result[3] + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;

                        }
                        if (result[17] != "")
                            document.getElementById("cphMain_TextBox5").value = result[17];

                    },
                    failure: function (response) {

                    }
                });
                document.getElementById("print_cap").click();
            }
            return false;
        }

        function LoadChequeBkDetails(rowCount, ChequeId, Mode) {

            var ddlAccntId = document.getElementById("cphMain_ddlAccontLed").value;
            var intOrgID = '<%= Session["ORGID"] %>';
            var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
            $noCon.ajax({
                type: "POST",
                async: false,
                url: "fms_Postdated_Cheque.aspx/ChequeBookLoad",
                data: '{intLedgerId:"' + ddlAccntId + '",intorgid:"' + intOrgID + '" ,intcorpid:"' + intCorrpID + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    result = response.d;

                    if (rowCount != "-1") {

                        var ddlTestDropDownListXML2 = $noCon("#ddlChequeBook" + rowCount);
                        var ddlTestDropDownListXML3 = $noCon("#ddlChequeNumber" + rowCount);
                        $("#ddlChequeBook" + rowCount).empty();
                        var tableName = "dtTableChequeBook";
                        var OptionStart = $noCon("<option>--SELECT--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML3.append(OptionStart);
                        ddlTestDropDownListXML2.append(OptionStart);
                        $noCon(result).find(tableName).each(function () {
                            var OptionValue = $noCon(this).find('CHKBK_ID').text();
                            var OptionText = $noCon(this).find('CHKBK_NAME').text();
                            var option = $noCon("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);
                            ddlTestDropDownListXML2.append(option);
                            if (ChequeId == null)
                                LoadChequeBookNum(OptionValue, null, "0", rowCount);
                        });
                        if (ChequeId != "" && ChequeId != null) {
                            var arrayProduct = JSON.parse("[" + ChequeId + "]");
                            $noCon("#ddlChequeBook" + rowCount).val(arrayProduct);
                        }
                    }
                    else {
                        var addRowtable = document.getElementById("Cheque_tBody");
                        for (var Id = 0; Id < addRowtable.rows.length; Id++) {
                            var x = (addRowtable.rows[Id].cells[0].innerHTML);
                            var ddlTestDropDownListXML2 = $noCon("#ddlChequeBook" + x);
                            var ddlTestDropDownListXML3 = $noCon("#ddlChequeNumber" + x);
                            $("#ddlChequeBook" + x).empty();
                            var tableName = "dtTableChequeBook";
                            var OptionStart = $noCon("<option>--SELECT--</option>");
                            OptionStart.attr("value", 0);
                            ddlTestDropDownListXML3.append(OptionStart);
                            ddlTestDropDownListXML2.append(OptionStart);
                            $noCon(result).find(tableName).each(function () {
                                var OptionValue = $noCon(this).find('CHKBK_ID').text();
                                var OptionText = $noCon(this).find('CHKBK_NAME').text();
                                var option = $noCon("<option>" + OptionText + "</option>");
                                option.attr("value", OptionValue);
                                ddlTestDropDownListXML2.append(option);
                                if (ChequeId == null)
                                    LoadChequeBookNum(OptionValue, null, "0", x);
                            });
                            if (ChequeId != "" && ChequeId != null) {
                                var arrayProduct = JSON.parse("[" + ChequeId + "]");
                                $noCon("#ddlChequeBook" + x).val(arrayProduct);
                            }
                            if (document.getElementById("cphMain_ddlAccontLed").value == 0 && document.getElementById("cphMain_ddlAccontLed").value == "--SELECT--") {
                                var OptionStart = $noCon("<option>--SELECT--</option>");
                                OptionStart.attr("value", 0);
                                ddlTestDropDownListXML3.append(OptionStart);
                                ddlTestDropDownListXML2.append(OptionStart);
                            }
                            //}
                            //else {
                            //    var OptionStart = $noCon("<option>--SELECT--</option>");
                            //    OptionStart.attr("value", 0);
                            //    ddlTestDropDownListXML2.append(OptionStart);
                            //}
                        }
                    }
                }
            });

        }



        function FillChequeBookLoad(rowCount, ChequeId, Mode) {

            var ddlTestDropDownListXML = "";
            ddlTestDropDownListXML = $noCon("#ddlChequeBook" + rowCount);
            if (document.getElementById("cphMain_ddlAccontLed").value != 0 && document.getElementById("cphMain_ddlAccontLed").value != "--SELECT--") {

                if (Mode == "1") {
                    if (confirmbox > 0) {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you sure you want to change the account book?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                document.getElementById("cphMain_hiddenSelectedAccntBk").value = document.getElementById("cphMain_ddlAccontLed").value;
                                LoadChequeBkDetails(rowCount, ChequeId, Mode);
                                return false;
                            }
                            else {
                                var PrevsVal = document.getElementById("cphMain_hiddenSelectedAccntBk").value;
                                var sel = $("#cphMain_ddlAccontLed option[value='" + PrevsVal + "']").text();
                                $('#cphMain_ddlAccontLed').val(PrevsVal);
                                $("#DivAccountBook > input").val(sel);
                                LoadChequeBkDetails(rowCount, ChequeId, Mode);
                                return false;
                            }
                        });
                        IncrmntConfrmCounter();
                        return false;
                    }
                    else {
                        document.getElementById("cphMain_hiddenSelectedAccntBk").value = document.getElementById("cphMain_ddlAccontLed").value;
                        LoadChequeBkDetails(rowCount, ChequeId, Mode);
                        return false;
                    }
                }
                else {
                    document.getElementById("cphMain_hiddenSelectedAccntBk").value = document.getElementById("cphMain_ddlAccontLed").value;
                    LoadChequeBkDetails(rowCount, ChequeId, Mode);
                    return false;
                }

            }
            else {
                var addRowtable = document.getElementById("Cheque_tBody");
                for (var Id = 0; Id < addRowtable.rows.length; Id++) {
                    var x = (addRowtable.rows[Id].cells[0].innerHTML);
                    var ddlTestDropDownListXML2 = $noCon("#ddlChequeBook" + x);
                    var ddlTestDropDownListXML3 = $noCon("#ddlChequeNumber" + x);
                    $("#ddlChequeBook" + x).empty();
                    var tableName = "dtTableChequeBook";
                    var OptionStart = $noCon("<option>--SELECT--</option>");
                    OptionStart.attr("value", 0);
                    ddlTestDropDownListXML3.append(OptionStart);
                    ddlTestDropDownListXML2.append(OptionStart);
                }
            }

        }

        function LoadChequeBookNum(ChequeBookFill, ChequeBookNum, status, RowId) {

         $("#ddlChequeNumber" + RowId).empty();
         var ChequeBook = 0;
         var strChequeBook = "";
         var ChequeBook = document.getElementById("ddlChequeBook" + RowId).value;
         var Bank = document.getElementById("<%=ddlAccontLed.ClientID%>").value;
         var corpid = '<%= Session["CORPOFFICEID"] %>';
         var orgid = '<%= Session["ORGID"] %>';
         var EditId = document.getElementById("<%=HiddenPostdatedChequeId.ClientID%>").value;

         if (ChequeBookFill != "" && ChequeBookFill != null)
             ChequeBook = ChequeBookFill;
         var ddlTestDropDownListXML = "";
         ddlTestDropDownListXML = $("#ddlChequeNumber" + RowId);
         var OptionStart = $("<option>--SELECT--</option>");
         OptionStart.attr("value", "--SELECT--");
         ddlTestDropDownListXML.append(OptionStart);
         if (ChequeBook != 0) {
             $.ajax({
                 async: false,
                 type: "POST",
                 url: "fms_Postdated_Cheque.aspx/LoadChequeBookNumber",
                 data: '{ChequeBook:"' + ChequeBook + '",status:"' + status + '",CorpId:"' + corpid + '",OrgId:"' + orgid + '",BankId:"' + Bank + '",EditId:"' + EditId + '"}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {
                     result = response.d;
                     if (result != "")
                         strChequeBook = result;

                     if (strChequeBook == "") {
                         $("#ddlChequeBook" + RowId + " option[value='" + ChequeBook + "']").remove();
                         //alert(ChequeBook);
                     }
                 },
                 failure: function (response) {

                 }
             });
             FillddlChequenumbers(strChequeBook, ChequeBookNum, RowId);
         }
     }
     function FillddlChequenumbers(strACI, ACI, RowId) {
         var ddlTestDropDownListXML = "";
         ddlTestDropDownListXML = $("#ddlChequeNumber" + RowId);
         var ChequeBook = document.getElementById("ddlChequeBook" + RowId).value;
         if (strACI != "") {
             ddlLed = strACI;
             var spltdays = strACI.split(',');
             for (var loop = 0; loop < spltdays.length; loop++) {
                 var OptionText = spltdays[loop];
                 var option = $("<option>" + OptionText + "</option>");
                 option.attr("value", OptionText);
                 ddlTestDropDownListXML.append(option);
             }

             //Remove Ledger
             var addRowtable = "";
             addRowtable = document.getElementById("Cheque_tBody");
             for (var i = 0; i < addRowtable.rows.length; i++) {
                 var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                 if (xLoop != RowId) {
                     var ChequeBookRow = document.getElementById("ddlChequeBook" + xLoop).value;
                     var xLoopLdgrId = "";
                     if ($("#ddlChequeNumber" + xLoop).val() != 0) {
                         xLoopLdgrId = $("#ddlChequeNumber" + xLoop).val();

                         //alert(xLoopLdgrId); alert(ChequeBook); alert(ChequeBookRow);

                         if (ChequeBook == ChequeBookRow)
                             $noCon("#ddlChequeNumber" + RowId + " option[value='" + xLoopLdgrId + "']").remove();
                     }
                 }
             }
             if (ACI != null) {
                 var arrayProduct = ACI;
                 $("#ddlChequeNumber" + RowId).val(arrayProduct);

             }
         }
         else {
             var OptionStart = $("<option>--SELECT--</option>");
             OptionStart.attr("value", "--SELECT--");
             ddlTestDropDownListXML.append(OptionStart);
         }


     }
     function AddNewChequeDetails(RowId) {
         IncrmntConfrmCounter();
         var TableFlag;
         var Flag = true;
         document.getElementById("ddlChequeBook" + RowId).style.borderColor = "";
         document.getElementById("ddlChequeNumber" + RowId).style.borderColor = "";
         document.getElementById("txtChequedate" + RowId).style.borderColor = "";
         document.getElementById("txtChequeAmount" + RowId).style.borderColor = "";
          
         document.getElementById("txtRcBank" + RowId).style.borderColor = "";
         document.getElementById("txtRcIban" + RowId).style.borderColor = "";
         document.getElementById("txtRcAcntNum" + RowId).style.borderColor = "";

         var check = document.getElementById("tdInxGrp" + RowId).value;
         if (check == "") {
             var ChequeBook = document.getElementById("ddlChequeBook" + RowId).value;
             var ChequeBookNumber = document.getElementById("ddlChequeNumber" + RowId).value;
             var ChequeBookDate = document.getElementById("txtChequedate" + RowId).value;
             var ChequeBookAmt = document.getElementById("txtChequeAmount" + RowId).value;


             var RcptBank = document.getElementById("txtRcBank" + RowId).value.trim();
             var RcptIban = document.getElementById("txtRcIban" + RowId).value.trim();
             var RcptAcntNum = document.getElementById("txtRcAcntNum" + RowId).value.trim();


             ChequeBookAmt = ChequeBookAmt.trim();
             ChequeBookAmt = ChequeBookAmt.replace(/,/g, "");
             if (ChequeBookAmt == "" || parseFloat(ChequeBookAmt) <= 0) {
                 document.getElementById("txtChequeAmount" + RowId).style.borderColor = "red";
                 document.getElementById("txtChequeAmount" + RowId).focus();
                 Flag = false;
             }
             if (ChequeBookDate == "") {
                 document.getElementById("txtChequedate" + RowId).style.borderColor = "red";
                 document.getElementById("txtChequedate" + RowId).focus();
                 Flag = false;
             }

             if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0") {
                 if (ChequeBookNumber == "0" || ChequeBookNumber == "--SELECT--") {
                     document.getElementById("ddlChequeNumber" + RowId).style.borderColor = "red";
                     document.getElementById("ddlChequeNumber" + RowId).focus();
                     Flag = false;
                 }
                 if (ChequeBook == "0" || ChequeBook == "--SELECT--") {
                     document.getElementById("ddlChequeBook" + RowId).style.borderColor = "red";
                     document.getElementById("ddlChequeBook" + RowId).focus();
                     Flag = false;
                 }
             }
             else {
                 if (RcptAcntNum == "") {
                     document.getElementById("txtRcAcntNum" + RowId).style.borderColor = "red";
                     document.getElementById("txtRcAcntNum" + RowId).focus();
                     Flag = false;
                 }
                 if (RcptIban == "" ) {
                     document.getElementById("txtRcIban" + RowId).style.borderColor = "red";
                     document.getElementById("txtRcIban" + RowId).focus();
                     Flag = false;
                 }
                 if (RcptBank == "") {
                     document.getElementById("txtRcBank" + RowId).style.borderColor = "red";
                     document.getElementById("txtRcBank" + RowId).focus();
                     Flag = false;
                 }
             }

             var Balnc = 0;
             if (Flag == true) {
                 var BalnceAmnt = document.getElementById("<%=hiddenBalanceAmnt.ClientID%>").value;
                 if (CheckBalanceSettled(BalnceAmnt) == false) {
                     Balnc++;
                     Flag = false;
                 }
             }

             if (Flag == false) {

                 if (Balnc > 0) {
                     document.getElementById("txtChequeAmount" + RowId).style.borderColor = "red";
                     document.getElementById("txtChequeAmount" + RowId).focus();
                     $noCon("#divWarning").html("Cheque amount cannot be greater than the balance amount to be paid!.");
                     $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                     });
                     $noCon(window).scrollTop(0);
                 }
                 else {
                     $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                     $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                     });
                 }
                 $noCon(window).scrollTop(0);
                 return false;
             }
             else {

                 document.getElementById("tdInxGrp" + RowId).value = RowId;
                 document.getElementById("btnChequeAdd" + RowId).style.opacity = "0.3";
                 AddChequeDetails(null,null,null);
                 return false;
             }
         }
         return false;
     }


        function changeBankAcNum(CurrRowId) {

            document.getElementById("txtRcBank" + CurrRowId).style.borderColor = "";
            document.getElementById("txtRcAcntNum" + CurrRowId).style.borderColor = "";
            var RcptBankCurr = document.getElementById("txtRcBank" + CurrRowId).value.trim();
            var RcptAcntNumCurr = document.getElementById("txtRcAcntNum" + CurrRowId).value.trim();
            if (RcptBankCurr != "" && RcptAcntNumCurr != "") {
                var addRowtable = document.getElementById("Cheque_tBody");
                for (var Id = 0; Id < addRowtable.rows.length; Id++) {
                    var RowId = (addRowtable.rows[Id].cells[0].innerHTML);
                    var RcptBank = document.getElementById("txtRcBank" + RowId).value.trim();
                    var RcptAcntNum = document.getElementById("txtRcAcntNum" + RowId).value.trim();
                    if (RowId != CurrRowId && RcptBank != "" && RcptAcntNum != "") {

                        if (RcptAcntNum == RcptAcntNumCurr && RcptBankCurr == RcptBank) {
                            document.getElementById("txtRcAcntNum" + CurrRowId).style.borderColor = "red";
                            document.getElementById("txtRcAcntNum" + CurrRowId).focus();

                            document.getElementById("txtRcBank" + CurrRowId).style.borderColor = "red";
                            document.getElementById("txtRcBank" + CurrRowId).focus();

                            $noCon("#divWarning").html("Duplication is not allowed for cheque number!");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            $noCon(window).scrollTop(0);

                            return false;
                        }
                    }
                }
                    var ret = "";
                    var UpdateId = 0;
                    if (document.getElementById("<%=HiddenPostdatedChequeId.ClientID%>").value != "") {
                        UpdateId = document.getElementById("<%=HiddenPostdatedChequeId.ClientID%>").value;
                    }
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "fms_Postdated_Cheque.aspx/CheckDupBankAcNum",
                    data: '{RcptBankCurr:"' + RcptBankCurr + '",RcptAcntNumCurr:"' + RcptAcntNumCurr + '",UpdateId:"' + UpdateId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                            
                        if (response.d == "false") {
                            document.getElementById("txtRcAcntNum" + CurrRowId).style.borderColor = "red";
                            document.getElementById("txtRcAcntNum" + CurrRowId).focus();

                            document.getElementById("txtRcBank" + CurrRowId).style.borderColor = "red";
                            document.getElementById("txtRcBank" + CurrRowId).focus();

                            $noCon("#divWarning").html("Duplication is not allowed for cheque number!");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            $noCon(window).scrollTop(0);
                            ret = "false";
                        }
                        else if(response.d =="")
                        {
                             
                            ret = "true";
                        }

                    },
                    failure: function (response) {
                           
                    }
                  
                    });
                return ret;

            }
           
           
            
             //return false;

        }

        function ValidatePostDated_Cheque() {

            IncrmntConfrmCounter();
            var Flag = true;
            $("#DivAccountBook > input").css("borderColor", "");
            $("#DivAccountParty > input").css("borderColor", "");
            $("#DivAccountParty1 > input").css("borderColor", "");
            $("#cphMain_ddlInvoice").css("borderColor", "");
            $("#cphMain_ddlExp").css("borderColor", "");
            $("#cphMain_ddlIncm").css("borderColor", "");
            document.getElementById("cphMain_txtPayee").style.borderColor = "";
            document.getElementById("cphMain_txtIssueDate_Cheque").style.borderColor = "";

            if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0") {
                if (document.getElementById("cphMain_ChkStatus_Cheque").checked == true) {
                    if (document.getElementById("cphMain_txtIssueDate_Cheque").value == "") {
                        document.getElementById("cphMain_txtIssueDate_Cheque").style.borderColor = "Red";
                        document.getElementById("cphMain_txtIssueDate_Cheque").focus();
                        Flag = false;
                    }
                }
                if (document.getElementById("cphMain_txtPayee").value == "") {
                    document.getElementById("cphMain_txtPayee").style.borderColor = "red";
                    document.getElementById("cphMain_txtPayee").focus();
                    Flag = false;
                }
            }

            if (document.getElementById("<%=ddlMethod.ClientID%>").value != "0") {
                if (document.getElementById("<%=ddlMethod.ClientID%>").value == "1") {
                    if (document.getElementById("cphMain_ddlInvoice").value == "--SELECT--" || document.getElementById("cphMain_ddlInvoice").value == "0" || document.getElementById("cphMain_ddlInvoice").value == "") {
                        $("#cphMain_ddlInvoice").css("borderColor", "red");
                        $("#cphMain_ddlInvoice").focus();
                        Flag = false;
                    }
                }
                if (document.getElementById("<%=ddlMethod.ClientID%>").value == "2") {
                    if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0") {
                        if (document.getElementById("cphMain_ddlExp").value == "--SELECT--" || document.getElementById("cphMain_ddlExp").value == "0" || document.getElementById("cphMain_ddlExp").value == "") {
                            $("#divddlExp > input").css("borderColor", "red");
                            $("#divddlExp > input").focus();
                            $("#divddlExp > input").select();
                            Flag = false;
                        }
                    }
                    else {
                        if (document.getElementById("cphMain_ddlIncm").value == "--SELECT--" || document.getElementById("cphMain_ddlIncm").value == "0" || document.getElementById("cphMain_ddlIncm").value == "") {
                            $("#divddlIncm > input").css("borderColor", "red");
                            $("#divddlIncm > input").focus();
                            $("#divddlIncm > input").select();
                            Flag = false;
                        }
                    }
                }
            }

            if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0") {
                if (document.getElementById("cphMain_ddlSupplier").value == 0 || document.getElementById("cphMain_ddlSupplier").value == "--SELECT--") {
                    $("#DivAccountParty > input").css("borderColor", "red");
                    $("#DivAccountParty > input").focus();
                    $("#DivAccountParty > input").select();
                    Flag = false;
                }
            }
            else {
                if (document.getElementById("cphMain_ddlSupplier1").value == 0 || document.getElementById("cphMain_ddlSupplier1").value == "--SELECT--") {
                    $("#DivAccountParty1 > input").css("borderColor", "red");
                    $("#DivAccountParty1 > input").focus();
                    $("#DivAccountParty1 > input").select();
                    Flag = false;
                }
            }
            if (document.getElementById("cphMain_txtdate").value == "") {
                $("#cphMain_txtdate").css("borderColor", "red");
                $("#cphMain_txtdate").focus();
                Flag = false;
            }
            if (document.getElementById("cphMain_ddlAccontLed").value == 0 || document.getElementById("cphMain_ddlAccontLed").value == "--SELECT--") {
                $("#DivAccountBook > input").css("borderColor", "red");
                $("#DivAccountBook > input").focus();
                $("#DivAccountBook > input").select();
                Flag = false;
            }
            var Dup = 0;
            var Balnc = 0;

            var addRowtable = document.getElementById("Cheque_tBody");

            for (var Id = 0; Id < addRowtable.rows.length; Id++) {

                var RowId = (addRowtable.rows[Id].cells[0].innerHTML);

                document.getElementById("ddlChequeBook" + RowId).style.borderColor = "";
                document.getElementById("ddlChequeNumber" + RowId).style.borderColor = "";
                document.getElementById("txtChequedate" + RowId).style.borderColor = "";
                document.getElementById("txtChequeAmount" + RowId).style.borderColor = "";


                document.getElementById("txtRcBank" + RowId).style.borderColor = "";
                document.getElementById("txtRcIban" + RowId).style.borderColor = "";
                document.getElementById("txtRcAcntNum" + RowId).style.borderColor = "";


                var ChequeBook = document.getElementById("ddlChequeBook" + RowId).value;
                var ChequeBookNumber = document.getElementById("ddlChequeNumber" + RowId).value;
                var ChequeBookDate = document.getElementById("txtChequedate" + RowId).value;
                var ChequeBookAmt = document.getElementById("txtChequeAmount" + RowId).value;


                var RcptBank = document.getElementById("txtRcBank" + RowId).value.trim();
                var RcptIban = document.getElementById("txtRcIban" + RowId).value.trim();
                var RcptAcntNum = document.getElementById("txtRcAcntNum" + RowId).value.trim();

                ChequeBookAmt = ChequeBookAmt.trim();
                ChequeBookAmt = ChequeBookAmt.replace(/,/g, "");

                if (ChequeBookAmt == "" || parseFloat(ChequeBookAmt) <= 0) {
                    document.getElementById("txtChequeAmount" + RowId).style.borderColor = "red";
                    document.getElementById("txtChequeAmount" + RowId).focus();
                    Flag = false;
                }
                if (ChequeBookDate == "") {
                    document.getElementById("txtChequedate" + RowId).style.borderColor = "red";
                    //document.getElementById("txtChequedate" + RowId).focus();
                    Flag = false;
                }
                if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0") {
                    if (ChequeBookNumber == "0" || ChequeBookNumber == "--SELECT--") {
                        document.getElementById("ddlChequeNumber" + RowId).style.borderColor = "red";
                        document.getElementById("ddlChequeNumber" + RowId).focus();
                        Flag = false;
                    }
                    if (ChequeBook == "0" || ChequeBook == "--SELECT--") {
                        document.getElementById("ddlChequeBook" + RowId).style.borderColor = "red";
                        document.getElementById("ddlChequeBook" + RowId).focus();
                        Flag = false;
                    }

                    if (RowId != "") {

                        if (ChequeNoDuplication(RowId) == false) {

                            document.getElementById("ddlChequeBook" + RowId).style.borderColor = "red";
                            document.getElementById("ddlChequeNumber" + RowId).style.borderColor = "red";
                            document.getElementById("ddlChequeNumber" + RowId).focus();
                            Dup++;
                            Flag = false;
                        }
                    }
                }
                else {

                    if (RcptAcntNum == "") {
                        document.getElementById("txtRcAcntNum" + RowId).style.borderColor = "red";
                        document.getElementById("txtRcAcntNum" + RowId).focus();
                        Flag = false;
                    }
                    if (RcptIban == "") {
                        document.getElementById("txtRcIban" + RowId).style.borderColor = "red";
                        document.getElementById("txtRcIban" + RowId).focus();
                        Flag = false;
                    }
                    if (RcptBank == "") {
                        document.getElementById("txtRcBank" + RowId).style.borderColor = "red";
                        document.getElementById("txtRcBank" + RowId).focus();
                        Flag = false;
                    }

                    if (RowId != "") {
                        if (changeBankAcNum(RowId) == "false" || (changeBankAcNum(RowId) == false)) {

                            document.getElementById("txtRcAcntNum" + RowId).style.borderColor = "red";
                            document.getElementById("txtRcAcntNum" + RowId).focus();
                            document.getElementById("txtRcBank" + RowId).style.borderColor = "red";
                            document.getElementById("txtRcBank" + RowId).focus();
                            Dup++;
                            Flag = false;
                        }
                    }

                }
            }

            if (Flag == true) {
                var BalnceAmnt = document.getElementById("<%=hiddenBalanceAmnt.ClientID%>").value;
                if (CheckBalanceSettled(BalnceAmnt) == false) {
                    Balnc++;
                    Flag = false;
                }
            }

            if (Flag == false) {

                if (Balnc > 0) {
                    document.getElementById("txtChequeAmount" + RowId).style.borderColor = "red";
                    document.getElementById("txtChequeAmount" + RowId).focus();
                    $noCon("#divWarning").html("Cheque amount cannot be greater than the balance amount to be paid!.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    $noCon(window).scrollTop(0);
                }
                else if (Dup > 0) {
                    $noCon("#divWarning").html("Duplication is not allowed for cheque number!");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    $noCon(window).scrollTop(0);
                    return false;
                }
                else {
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    $noCon(window).scrollTop(0);
                    return false;
                }
            }

            if (Flag == true) {

                if (document.getElementById("<%=ddlMethod.ClientID%>").value == "1") {
                    document.getElementById("<%=hiddenInvoiceId.ClientID%>").value = document.getElementById("cphMain_ddlInvoice").value;
                    $('#cphMain_ddlInvoice').empty();
                    $('#cphMain_ddlInvoice').append("--SELECT--");
                }

                var tbClientTotalValues = '';
                tbClientTotalValues = [];

                var addRowtable = document.getElementById("Cheque_tBody");

                for (var i = 0; i < addRowtable.rows.length; i++) {
                    var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                    var ChequeBookId = document.getElementById("ddlChequeBook" + xLoop).value;
                    var ChequeBookNum = document.getElementById("ddlChequeNumber" + xLoop).value;
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + xLoop + "",
                        CHEQUEBOOK: "" + ChequeBookId + "",
                        CHEQUEBOOKNO: "" + ChequeBookNum + "",
                    });
                    tbClientTotalValues.push(client);
                }
                document.getElementById("<%=HiddenSaveInfo.ClientID%>").value = JSON.stringify(tbClientTotalValues);
            }

            return Flag;
        }

        function ChangeChequeNo(RowId) {
          
            IncrmntConfrmCounter();
            var ret = true;
            document.getElementById("ddlChequeBook" + RowId).style.borderColor = "";
            document.getElementById("ddlChequeNumber" + RowId).style.borderColor = "";

            if (ChequeNoDuplication(RowId) == false) {

                document.getElementById("ddlChequeBook" + RowId).style.borderColor = "red";
                document.getElementById("ddlChequeNumber" + RowId).style.borderColor = "red";
                document.getElementById("ddlChequeNumber" + RowId).focus();

                $noCon("#divWarning").html("Duplication is not allowed for cheque number!");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $noCon(window).scrollTop(0);
                ret = false;
            }
           
            return ret;
        }

        function ChequeNoDuplication(rowId) {
            var ret = true;
            var flag = 0;
            var addRowtable = document.getElementById("Cheque_tBody");
            for (var i = 1; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);

                var xLoopChqBkId = $("#ddlChequeBook" + xLoop).val();
                var ChqBkId = $("#ddlChequeBook" + rowId).val();

                var xLoopChqNoId = $("#ddlChequeNumber" + xLoop).val();
                var ChqNoId = $("#ddlChequeNumber" + rowId).val();

                if (xLoop != rowId) {
                    if (xLoopChqBkId == ChqBkId && xLoopChqNoId == ChqNoId) {
                        flag++;
                        ret = false;
                    }
                }
            }
         
            return ret;
        }



        function CheckSumOfCheque(textboxid) {
            var ret = true;
            var CstTotal = 0;
            AmountChecking(textboxid);
            var FloatingValue = document.getElementById("<%=HiddenDecimalCount.ClientID%>").value;
            var LedgerTotal = 0;
            var LedgerTtl = 0;
            var addRowtable = document.getElementById("Cheque_tBody");
            for (var i = 0; i < addRowtable.rows.length; i++) {
                var row = addRowtable.rows[i];
                var x = (addRowtable.rows[i].cells[0].innerHTML);
                if (document.getElementById("txtChequeAmount" + x).value != "") {
                    var ldgramt = document.getElementById("txtChequeAmount" + x).value;
                    ldgramt = ldgramt.replace(/\,/g, '');
                    LedgerTtl = parseFloat(LedgerTtl) + parseFloat(ldgramt);
                    if (FloatingValue != "") {
                        ldgramt = parseFloat(ldgramt);
                        ldgramt = ldgramt.toFixed(FloatingValue);
                    }
                    document.getElementById("txtChequeAmount" + x).value = ldgramt;
                    addCommas("txtChequeAmount" + x);
                }
            }
            var FloatingValue = document.getElementById("<%=HiddenDecimalCount.ClientID%>").value;
            var DftCurrencyId = document.getElementById("<%=HiddenCurrencyId.ClientID%>").value;
            if (FloatingValue != "") {
                LedgerTtl = LedgerTtl.toFixed(FloatingValue);
            }
            document.getElementById("cphMain_txtGrantTotal").value = LedgerTtl;
            addCommas("cphMain_txtGrantTotal");
            return ret;
        }
        function AmountChecking(textboxid) {
            IncrmntConfrmCounter();
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
                    var FloatingValue = document.getElementById("<%=HiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);
                    }
                    document.getElementById('' + textboxid + '').value = n;
                }
            }
        }

        function PaidRejctStatusUpdate(ChequeBkId, Status, RowId) {

            IncrmntConfrmCounter();
            var usrId = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            var ChequeId = document.getElementById("<%=HiddenPostdatedChequeId.ClientID%>").value;
            document.getElementById("<%=hiddenRow.ClientID%>").value = RowId;
            var PaymntReceiptId = document.getElementById("tdPaymntRecptId" + RowId).value;
            var PaymntReceiptRef = document.getElementById("tdPaymntRecptRef" + RowId).value;
            var ChequeDate = document.getElementById("txtChequedate" + RowId).value;

            var TransType = document.getElementById("cphMain_ddlTranscationType").value;
            var Method = document.getElementById("cphMain_ddlMethod").value;

            var AcntClosePrvsn = document.getElementById("<%=HiddenFieldAcntCloseReopenSts.ClientID%>").value;
            var AuditClosePrvsn = document.getElementById("<%=HiddenAuditProvisionStatus.ClientID%>").value;

            if (PaymntReceiptRef == "AcntClosed") {
                AcntClosed();
            }
            else if (PaymntReceiptRef == "AuditClosed") {
                AuditClosed();
            }
            else {
                var Msg = "";
                if (Status == "1") {

                    //method 1
                    if (Method == "0") {

                        if (TransType == "0") {
                            if (PaymntReceiptId != "") {
                                Msg = "Are you sure you want to mark as paid the payment voucher?";
                            }
                            else {
                                Msg = "Are you sure you want to generate payment voucher with Ref#" + PaymntReceiptRef + " ?";
                            }
                        }
                        else {
                            if (PaymntReceiptId != "") {
                                Msg = "Are you sure you want to mark as paid the receipt voucher?";
                            }
                            else {
                                Msg = "Are you sure you want to generate receipt voucher with Ref#" + PaymntReceiptRef + "?";
                            }
                        }

                    }
                    //method 2 or 3
                    else {
                        if (PaymntReceiptId != "") {
                            Msg = "Are you sure you want to mark as paid the journal voucher?";
                        }
                        else {
                            Msg = "Are you sure you want to generate journal voucher with Ref#" + PaymntReceiptRef + "?";
                        }
                    }

                }
                else if (Status == "2") {
                    Msg = "Are you sure you want to mark as rejected?";
                }
                else if (Status == "0") {
                    Msg = "Are you sure you want to recall this rejected cheque?";
                }
                ezBSAlert({
                    type: "confirm",
                    messageText: Msg,
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        if (ChequeId != '') {

                            $.ajax({
                                type: "POST",
                                async: false,
                                contentType: "application/json; charset=utf-8",
                                url: "fms_Postdated_Cheque.aspx/ChequePaidRejectStatus",
                                data: '{usrId: "' + usrId + '",ChequeId: "' + ChequeId + '",strCorpID: "' + strCorpID + '",strOrgIdID: "' + strOrgIdID + '",ChequeBkId: "' + ChequeBkId + '",Status: "' + Status + '",TransType: "' + TransType + '",PaymntRecptId: "' + PaymntReceiptId + '",AcntClosePrvsn: "' + AcntClosePrvsn + '",AuditClosePrvsn: "' + AuditClosePrvsn + '",Method: "' + Method + '",ChequeDate: "' + ChequeDate + '"}',
                                dataType: "json",
                                success: function (data) {
                                    var ReopenSts = data.d[0];
                                    var Ref = data.d[1];

                                    $(window).scrollTop(0);
                                    var SucessDetails = ReopenSts;
                                    if (SucessDetails != "Rejected" && SucessDetails != "Paid" && SucessDetails != "failed" && SucessDetails != "Payment" && SucessDetails != "CnclReject") {

                                        if (Status == "1") {
                                            if (PaymntReceiptId != "") {

                                                //method 1
                                                if (Method == "0") {

                                                    if (TransType == "0") {
                                                        var nWindow = window.open('/FMS/FMS_Master/fms_Payment_Account/fms_Payment_Account.aspx?Id=' + SucessDetails + '&VId=1', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                                                        nWindow.focus();
                                                    }
                                                    else {
                                                        var nWindow = window.open('/FMS/FMS_Master/fms_Receipt_Account/fms_Receipt_Account.aspx?Id=' + SucessDetails + '&VId=1', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                                                        nWindow.focus();
                                                    }

                                                }
                                                    //method 2 or 3
                                                else {
                                                    var nWindow = window.open('/FMS/FMS_Master/fms_Journal/fms_Journal.aspx?Id=' + SucessDetails + '&VId=1', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                                                    nWindow.focus();
                                                }

                                            }
                                            else {
                                                successGenerate(Ref);
                                            }

                                            CheckPaymentPaid(ChequeId, ChequeBkId, RowId);

                                            document.getElementById("btnChequeReject" + RowId).style.display = "none";

                                            document.getElementById("btnGen" + RowId).style.opacity = "0.3";
                                            document.getElementById("btnGen" + RowId).disabled = true;
                                            document.getElementById("btnChequePaid" + RowId).disabled = false;
                                        }
                                        else if (Status == "2") {

                                            document.getElementById("btnChequePaid" + RowId).disabled = true;
                                            document.getElementById("btnChequeReject" + RowId).disabled = true;
                                            document.getElementById("btnChequeReject" + RowId).innerHTML = "Rejected";
                                            document.getElementById("btnChequePaid" + RowId).style.display = "none";
                                            document.getElementById("btnChequeCnclReject" + RowId).style.display = "block";

                                            document.getElementById("btnGen" + RowId).style.opacity = "0.3";
                                            document.getElementById("btnGen" + RowId).disabled = true;

                                            successReject();
                                        }
                                        else if (Status == "0") {

                                            document.getElementById("btnChequeCnclReject" + RowId).style.display = "none";
                                            document.getElementById("btnChequePaid" + RowId).style.display = "";
                                            document.getElementById("btnChequeReject" + RowId).innerHTML = "<i class=\"fa fa-times\"></i>";
                                            //document.getElementById("btnChequePaid" + RowId).disabled = false;
                                            document.getElementById("btnChequeReject" + RowId).disabled = false;

                                            document.getElementById("btnGen" + RowId).style.opacity = "1";
                                            document.getElementById("btnGen" + RowId).disabled = false;
                                            successRecall();
                                        }
                                        $("#cphMain_btnReopen").hide();
                                        $("#cphMain_btnFloatReopen").hide();
                                    }
                                    else if (SucessDetails == "Rejected") {

                                        document.getElementById("btnChequePaid" + RowId).disabled = true;
                                        document.getElementById("btnChequeReject" + RowId).disabled = true;
                                        document.getElementById("btnChequeReject" + RowId).innerHTML = "Rejected";
                                        document.getElementById("btnChequePaid" + RowId).style.display = "none";
                                        document.getElementById("btnChequeCnclReject" + RowId).style.display = "block";

                                        document.getElementById("btnGen" + RowId).style.opacity = "0.3";
                                        document.getElementById("btnGen" + RowId).disabled = true;

                                        Already_Rejected();
                                    }
                                    else if (SucessDetails == "Paid") {

                                        document.getElementById("btnChequePaid" + RowId).innerHTML = "Paid";
                                        document.getElementById("btnChequeReject" + RowId).style.display = "none";
                                        document.getElementById("btnChequePaid" + RowId).disabled = true;
                                        document.getElementById("btnChequePrint" + RowId).style.opacity = "1";
                                        document.getElementById("btnChequePrint" + RowId).disabled = false;
                                        Already_Paid();
                                    }
                                    else if (SucessDetails == "Payment") {

                                        CheckPaymentPaid(ChequeId, ChequeBkId, RowId);

                                        document.getElementById("btnChequeReject" + RowId).style.display = "none";

                                        document.getElementById("btnGen" + RowId).style.opacity = "0.3";
                                        document.getElementById("btnGen" + RowId).disabled = true;
                                        document.getElementById("btnChequePaid" + RowId).disabled = false;
                                        Already_Payment();
                                    }
                                    else if (SucessDetails == "CnclReject") {

                                        document.getElementById("btnChequeCnclReject" + RowId).style.display = "none";
                                        document.getElementById("btnChequePaid" + RowId).style.display = "";
                                        document.getElementById("btnChequeReject" + RowId).innerHTML = "<i class=\"fa fa-times\"></i>";
                                        //document.getElementById("btnChequePaid" + RowId).disabled = false;
                                        document.getElementById("btnChequeReject" + RowId).disabled = false;

                                        document.getElementById("btnGen" + RowId).style.opacity = "1";
                                        document.getElementById("btnGen" + RowId).disabled = false;
                                        Already_CnclReject();
                                    }
                                    else {
                                        SuccessError();
                                    }

                                }
                            });
                        }
                    }
                });
            }

            return false;
        }

        function GetValueFromChild(myVal) {
            if (myVal != '') {
                PostbackFunProject(myVal);
            }
        }

        function PostbackFunProject(myVal) {
            if (myVal == "1") {
                var RowId = document.getElementById("<%=hiddenRow.ClientID%>").value;

                document.getElementById("btnChequePaid" + RowId).innerHTML = "Paid";
                document.getElementById("btnChequeReject" + RowId).style.display = "none";
                document.getElementById("btnChequePaid" + RowId).disabled = true;
                document.getElementById("btnChequePrint" + RowId).style.opacity = "1";
                document.getElementById("btnChequePrint" + RowId).disabled = false;
                successPymntInsert();
            }

            return false;
        }

        function ConfirmReopen() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to reopen this postdated cheque?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=btnReopen1.ClientID%>").click();
                    return false;
                }

                else {
                    return false;
                }
            });
            return false;
        }
        function ChangeType() {

            if (confirmbox > 0) {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to change transaction type?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {

                        confirmbox = 0;

                        if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0") {

                            document.getElementById("DivAccountParty").style.display = "block";
                            document.getElementById("DivAccountParty1").style.display = "none";

                            document.getElementById("Cheque_details").style.display = "block";
                            document.getElementById("thIban").style.display = "none";
                            document.getElementById("thFirst").innerHTML = "Cheque Book";
                            if (document.getElementById("<%=HiddenFieldChequePrint.ClientID%>").value == "1") {
                                document.getElementById("thPrint").style.display = "";
                            }
                            else {
                                document.getElementById("thPrint").style.display = "none";
                            }

                        }
                        else {

                            document.getElementById("DivAccountParty").style.display = "none";
                            document.getElementById("DivAccountParty1").style.display = "block";

                            document.getElementById("thPrint").style.display = "none";
                            document.getElementById("Cheque_details").style.display = "none";
                            document.getElementById("thIban").style.display = "";
                            document.getElementById("thFirst").innerHTML = "Bank";
                        }
                        $('#Cheque_tBody').empty();
                        AddChequeDetails(null, null, null);
                        document.getElementById("cphMain_ddlSupplier").value = "--SELECT--";
                        document.getElementById("cphMain_ddlSupplier1").value = "--SELECT--";
                        $("#DivAccountParty > input").val("--SELECT--");
                        $("#DivAccountParty1 > input").val("--SELECT--");

                        if (document.getElementById("cphMain_ddlAccontLed").value == 0 || document.getElementById("cphMain_ddlAccontLed").value == "--SELECT--") {
                            $("#DivAccountBook > input").focus();
                            $("#DivAccountBook > input").select();
                        }
                        else {
                            $("#DivAccountParty > input").focus();
                            $("#DivAccountParty > input").select();

                            $("#DivAccountParty1 > input").focus();
                            $("#DivAccountParty1 > input").select();
                        }
                        document.getElementById("cphMain_txtPayee").value = "";
                        document.getElementById("cphMain_txtGrantTotal").value = "";
                        document.getElementById("cphMain_ChkStatus_Cheque").checked = false;
                        IssueDateCheck();

                        return false;
                    }

                    else {
                        if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0") {
                            document.getElementById("<%=ddlTranscationType.ClientID%>").value = "1";
                        }
                        else {
                            document.getElementById("<%=ddlTranscationType.ClientID%>").value = "0";
                        }
                        return false;
                    }
                });
            }
            else {


                if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0") {

                    document.getElementById("DivAccountParty").style.display = "block";
                    document.getElementById("DivAccountParty1").style.display = "none";

                    document.getElementById("Cheque_details").style.display = "block";
                    document.getElementById("thIban").style.display = "none";
                    document.getElementById("thFirst").innerHTML = "Cheque Book";
                    if (document.getElementById("<%=HiddenFieldChequePrint.ClientID%>").value == "1") {
                        document.getElementById("thPrint").style.display = "";
                    }
                    else {
                        document.getElementById("thPrint").style.display = "none";
                    }

                }
                else {

                    document.getElementById("DivAccountParty").style.display = "none";
                    document.getElementById("DivAccountParty1").style.display = "block";

                    document.getElementById("thPrint").style.display = "none";
                    document.getElementById("Cheque_details").style.display = "none";
                    document.getElementById("thIban").style.display = "";
                    document.getElementById("thFirst").innerHTML = "Bank";
                }
                $('#Cheque_tBody').empty();
                AddChequeDetails(null, null, null);
                document.getElementById("cphMain_ddlSupplier").value = "--SELECT--";
                document.getElementById("cphMain_ddlSupplier1").value = "--SELECT--";
                $("#DivAccountParty > input").val("--SELECT--");
                $("#DivAccountParty1 > input").val("--SELECT--");

                if (document.getElementById("cphMain_ddlAccontLed").value == 0 || document.getElementById("cphMain_ddlAccontLed").value == "--SELECT--") {
                    $("#DivAccountBook > input").focus();
                    $("#DivAccountBook > input").select();
                }
                else {
                    $("#DivAccountParty > input").focus();
                    $("#DivAccountParty > input").select();

                    $("#DivAccountParty1 > input").focus();
                    $("#DivAccountParty1 > input").select();
                }
                document.getElementById("cphMain_txtPayee").value = "";
                document.getElementById("cphMain_txtGrantTotal").value = "";
                document.getElementById("cphMain_ChkStatus_Cheque").checked = false;
                IssueDateCheck();
            }

            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var OrgId = '<%= Session["ORGID"] %>';
            var TransactionType = document.getElementById("<%=ddlTranscationType.ClientID%>").value;

            $noCon.ajax({
                type: "POST",
                async: false,
                url: "fms_Postdated_Cheque.aspx/CheckClrnceLdgrSlctn",
                data: '{CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",TransactionType:"' + TransactionType + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {

                    if (data.d != "") {
                        if (data.d == "ClearanceLedgerSelect") {
                            ClearanceLedgerSelect();
                        }
                        else {
                            document.getElementById("cphMain_hiddenClearanceLedger").value = data.d;
                        }
                    }

                },
                failure: function (data) {
                    alert("error");
                }
            });


            ChangeMethod();

            return false;
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
        var $au = jQuery.noConflict();
        $au(function () {
            $au(".ddl").selectToAutocomplete1Letter();
        });
        function SuccessInsertion() {
            $noCon("#success-alert").html("Postdated cheque inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdation() {
            $noCon("#success-alert").html("Postdated cheque updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessConfirmation() {
            $noCon("#success-alert").html("Postdated cheque confirmed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function Alreadyconfrm() {
            $noCon("#divWarning").html("Postdated cheque confirmed already");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function successPymntInsert() {
            $noCon("#success-alert").html("Payment inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function successReject() {
            $noCon("#success-alert").html("Postdated cheque is rejected successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function successRecall() {
            $noCon("#success-alert").html("Postdated cheque is recalled successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function Already_Paid() {
            $noCon("#divWarning").html("Cheque is already Paid!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function Already_CnclReject() {
            $noCon("#divWarning").html("Cheque is already recalled!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        
        function Already_Payment() {
            if (document.getElementById("cphMain_ddlTranscationType").value == "0") {

                $noCon("#divWarning").html("Payment is already accepted!.");
            }
            else {
                $noCon("#divWarning").html("Receipt is already accepted!.");
            }
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function successGenerate(Ref) {
            if (document.getElementById("cphMain_ddlTranscationType").value == "0") {

                $noCon("#success-alert").html("Payment voucher generated successfully with <b>REF# : <font size=\"3\">" + Ref + "</font><b>.");
            }
            else {
                $noCon("#success-alert").html("Receipt voucher generated successfully with <b>REF# : <font size=\"3\">" + Ref + "</font><b>.");
            }
            $noCon("#success-alert").fadeTo(8000, 500).slideUp(500, function () {
            });
            return false;
        }
        
        function AcntClosed() {
            $noCon("#divWarning").html("This action is  denied! Account is already closed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function AuditClosed() {
            $noCon("#divWarning").html("This action is  denied! Audit is already closed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }  
        function ClearanceLedgerSelect() {
            $noCon("#divWarning").html("Please define the default account head for clearance ledgers ");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });

        }
        
        function Already_Rejected() {
            $noCon("#divWarning").html("Cheque is already rejected!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessError() {
            $noCon("#divWarning").html("Some error occured!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccesssuccessConfirm() {
            var ret = false;
            $noCon("#success-alert").html("Postdated Cheque confirmed successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function successReopen() {
            var ret = false;
            $noCon("#success-alert").html("Postdated Cheque reopened successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }

        function ChequeNoDuplicate() {
            $noCon("#divWarning").html("Cheque number is already used!.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }


        function ConfirmAlert() {
            if (ValidatePostDated_Cheque() == true) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm this postdated cheque?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        document.getElementById("<%=btnConfirm1.ClientID%>").click();
                } else {
                    return false;
                }

                });
            return false;
        }
        else {
            return false;

        }
        }
        function AlertClearAll() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Postdated_Cheque.aspx";
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
        function ConfirmMessage() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Postdated_Cheque_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "fms_Postdated_Cheque_List.aspx";
                return false;
            }
        }
        function buttnVisibile() {
            var TableRowCount = document.getElementById("Cheque_tBody").rows.length;
            addRowtable = document.getElementById("Cheque_tBody");
            for (var i =0; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                if (TableRowCount != 0) {
                    if (xLoop != "") {
                        if ((TableRowCount - 1) == i) {

                            document.getElementById("tdInxGrp" + xLoop).value = "";
                            document.getElementById("btnChequeAdd" + xLoop).style.opacity = "1";
                        }
                    }
                }
            }
        }
        function removeCheque(removeNum, CofirmMsg) {

            IncrmntConfrmCounter();
            if (document.getElementById("cphMain_HiddenView").value != "1") {
                ezBSAlert({
                    type: "confirm",
                    messageText: CofirmMsg,
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        jQuery('#SubGrpRowId_' + removeNum).remove();
                        addRowtable = document.getElementById("Cheque_tBody");
                        var TableRowCount = document.getElementById("Cheque_tBody").rows.length;
                        if (TableRowCount != 0) {
                            for (var i = 0; i < addRowtable.rows.length; i++) {
                                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                                if (TableRowCount != 0) {
                                    if ((TableRowCount - 1) == i) {
                                        document.getElementById("tdInxGrp" + xLoop).value = "";
                                        document.getElementById("btnChequeAdd" + xLoop).style.opacity = "1";
                                        document.getElementById("btnChequeAdd" + xLoop).disabled = false;
                                        if (document.getElementById("<%=ddlTranscationType.ClientID%>").value == "0") {
                                            document.getElementById("ddlChequeBook" + xLoop).focus();
                                        }
                                        else {
                                            document.getElementById("txtRcBank" + xLoop).focus();
                                        }

                                        CheckSumOfCheque('txtChequeAmount' + xLoop);

                                    }
                                }
                            }
                        }
                        else {
                            AddChequeDetails(null, null, null);
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

        function IssueDateCheck() {
            if (document.getElementById("<%=ChkStatus_Cheque.ClientID%>").checked == false) {
                document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").disabled = true;
                document.getElementById("<%=ChequeIssueDatePikrSpan.ClientID%>").disabled = true;
                document.getElementById("<%=ChequeIssueDatePikrSpan.ClientID%>").style.pointerEvents = "none";
                document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").value = "";
            }
            else {
                document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").disabled = false;
                document.getElementById("<%=ChequeIssueDatePikrSpan.ClientID%>").disabled = false;
                document.getElementById("<%=ChequeIssueDatePikrSpan.ClientID%>").style.pointerEvents = "";
            }
        }

        function ChangeMethod() {

            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var OrgId = '<%= Session["ORGID"] %>';
            var TransactionType = document.getElementById("<%=ddlTranscationType.ClientID%>").value;

            if (document.getElementById("<%=ddlMethod.ClientID%>").value == "0") {
                document.getElementById("divInvoice").style.display = "none";
                document.getElementById("divExp").style.display = "none";
                document.getElementById("divIncm").style.display = "none";
                document.getElementById("cphMain_ddlInvoice").value = "--SELECT--";
                document.getElementById("cphMain_ddlExp").value = "--SELECT--";
                document.getElementById("cphMain_ddlIncm").value = "--SELECT--";
            }
            else if (document.getElementById("<%=ddlMethod.ClientID%>").value == "1") {
                document.getElementById("divInvoice").style.display = "block";
                document.getElementById("divExp").style.display = "none";
                document.getElementById("divIncm").style.display = "none";
                document.getElementById("cphMain_ddlExp").value = "--SELECT--";
                document.getElementById("cphMain_ddlIncm").value = "--SELECT--";

                var Party = "";
                if (TransactionType == "0" && document.getElementById("<%=ddlSupplier.ClientID%>").value != "--SELECT--" && document.getElementById("<%=ddlSupplier.ClientID%>").value != "0") {
                    Party = document.getElementById("<%=ddlSupplier.ClientID%>").value;
                }
                else if (TransactionType == "1" && document.getElementById("<%=ddlSupplier1.ClientID%>").value != "--SELECT--" && document.getElementById("<%=ddlSupplier1.ClientID%>").value != "0") {
                    Party = document.getElementById("<%=ddlSupplier1.ClientID%>").value;
                }

                var InvoiceId = document.getElementById("<%=hiddenInvoiceId.ClientID%>").value;
                var InvoiceRefrnc = document.getElementById("<%=hiddenInvoiceRefrnc.ClientID%>").value; 

                if (Party != "") {

                    $noCon.ajax({
                        type: "POST",
                        async: false,
                        url: "fms_Postdated_Cheque.aspx/LoadInvoices",
                        data: '{CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",TransactionType:"' + TransactionType + '",Party:"' + Party + '",InvoiceId:"' + InvoiceId + '",InvoiceRefrnc:"' + InvoiceRefrnc + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {

                            $noCon("#cphMain_ddlInvoice").empty();
                            $noCon("#cphMain_ddlInvoice").append(data.d);

                            if (InvoiceId != "") {
                                $noCon("#cphMain_ddlInvoice").val(InvoiceId);
                            }

                            //$au("#cphMain_ddlInvoice").selectToAutocomplete1Letter();

                        },
                        failure: function (data) {
                            alert("error");
                        }

                    });
                }
            }
            else if (document.getElementById("<%=ddlMethod.ClientID%>").value == "2") {
                document.getElementById("divInvoice").style.display = "none";
                if (TransactionType == "0") {
                    document.getElementById("divExp").style.display = "block";
                    document.getElementById("divIncm").style.display = "none";
                }
                else if (TransactionType == "1") {
                    document.getElementById("divIncm").style.display = "block";
                    document.getElementById("divExp").style.display = "none";
                }
                document.getElementById("cphMain_ddlInvoice").value = "--SELECT--";         
            }

        }


        function GetBalance() {

            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var OrgId = '<%= Session["ORGID"] %>';
            var TransactionType = document.getElementById("<%=ddlTranscationType.ClientID%>").value;
            var Invoice = document.getElementById("<%=ddlInvoice.ClientID%>").value;

            $noCon.ajax({
                type: "POST",
                async: false,
                url: "fms_Postdated_Cheque.aspx/GetBalanceAmnt",
                data: '{CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",TransactionType:"' + TransactionType + '",Invoice:"' + Invoice + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {

                    if (data.d != "") {

                        document.getElementById("<%=hiddenBalanceAmnt.ClientID%>").value = data.d;
                        document.getElementById("spanBalance").innerHTML = "<i class=\"fa fa-money\"></i> " + data.d;

                        var BalnceAmnt = document.getElementById("<%=hiddenBalanceAmnt.ClientID%>").value;
                        if (CheckBalanceSettled(BalnceAmnt) == false) {
                            $noCon("#divWarning").html("Cheque amount cannot be greater than the balance amount to be paid!.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                        }
                    }

                },
                failure: function (data) {
                    alert("error");
                }

            });

        }

        function CheckBalanceSettled(BalAmnt) {

            var ret = true;

            var TotalAmnt = "0";
            var addRowtable = document.getElementById("Cheque_tBody");
            for (var i = 0; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);

                var Amnt = document.getElementById("txtChequeAmount" + xLoop).value;
                Amnt = Amnt.replace(/,/g, '');
                TotalAmnt = parseFloat(TotalAmnt) + parseFloat(Amnt);
            }

            if (parseFloat(TotalAmnt) > parseFloat(BalAmnt)) {   
                ret = false;
            }

            return ret;
        }

        //0039
        function PrintPdf() {

            
            var UsrName = '<%= Session["USERFULLNAME"] %>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            var strId = document.getElementById("<%=HiddenPostdatedChequeId.ClientID%>").value;
            var crncyAbrvt = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            //currency hidden filed changed
            var crncyId = document.getElementById("<%=HiddenCurrencyId.ClientID%>").value;

            
            if (strCorpID != "" && strCorpID != null && strOrgIdID != "" && strOrgIdID != null && UsrName != null && UsrName != "" && strId != "" && crncyAbrvt != "") {

              
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Postdated_Cheque.aspx/printReceiptDetails",
                    data: '{strId: "' + strId + '",UsrName: "' + UsrName + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",crncyAbrvt: "' + crncyAbrvt + '",crncyId: "' + crncyId + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            if (data.d != "false") {
                                window.open(data.d, '_blank');
                            }
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
        }
        //end


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
    
    <asp:HiddenField ID="HiddenFieldChequePrint" runat="server" />

    <asp:HiddenField ID="HiddenToday" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="Hiddenreturnfun" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYearId" runat="server" />
    <asp:HiddenField ID="HiddenAuditClsDate" runat="server" />
    <asp:HiddenField ID="HiddenAcntClsDate" runat="server" />
    <asp:HiddenField ID="HiddenAuditProvisionStatus" runat="server" />
    <asp:HiddenField ID="HiddenStartDate" runat="server" />
    <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="HiddenFieldAcntCloseReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenRefAccountCls" runat="server" />
    <asp:HiddenField ID="HiddenAcntClsSts" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYrStartDate" runat="server" />
    <asp:HiddenField ID="HiddenSaveInfo" runat="server" />
    <asp:HiddenField ID="HiddenChequeBookNumber" runat="server" />
    <asp:HiddenField ID="HiddenCurrencyId" runat="server" />
    <asp:HiddenField ID="HiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="HiddenUpdRefNum" runat="server" />
    <asp:HiddenField ID="HiddenUpdatedDate" runat="server" />
    <asp:HiddenField ID="HiddenSequenceRef" runat="server" />
    <asp:HiddenField ID="HiddenEdit" runat="server" />
    <asp:HiddenField ID="HiddenView" runat="server" />
    <asp:HiddenField ID="HiddenReOpenStatus" runat="server" />
    <asp:HiddenField ID="HiddenConfirmProvisionStatus" runat="server" />

    <asp:HiddenField ID="HiddenRestritionStatus" runat="server" />
    <asp:HiddenField ID="HiddenPostdatedChequeId" runat="server" />
    <asp:HiddenField ID="HiddenCurrencyAbrv" runat="server" />
    <asp:HiddenField ID="hiddenRow" runat="server" />
    <asp:HiddenField ID="hiddenSelectedAccntBk" runat="server" />
    <asp:HiddenField ID="hiddenEndYrClose" runat="server" />

    <asp:HiddenField ID="hiddenInvoiceId" runat="server" />
    <asp:HiddenField ID="hiddenClearanceLedger" runat="server" />
    <asp:HiddenField ID="hiddenBalanceAmnt" runat="server" />
    <asp:HiddenField ID="hiddenInvoiceRefrnc" runat="server" />
    <asp:HiddenField ID="hiddenModalView" runat="server" />

    <div id="divLinkSection" runat="server">
        <ol class="breadcrumb sticky1">
            <li><a id="aHome" runat="server" href="">Home</a></li>
            <li><a id="aDashBord" runat="server" href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
            <li><a href="fms_Postdated_Cheque_List.aspx">Postdated Cheque</a></li>
            <li class="active">Add Postdated Cheque</li>
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
    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                <div class="" onmouseover="closesave()">
                    <div id="divReportCaption" runat="server">
                        <h2>
                            <asp:Label ID="lblEntry" runat="server"></asp:Label></h2>
                    </div>

      <div class="form-group fg5">
        <label for="email" class="fg2_la1">Method:<span class="spn1">*</span></label>
        <asp:DropDownList ID="ddlMethod" class="form-control fg2_inp1 fg_chs1 inp_mst" runat="server" onchange="return ChangeMethod();">
          <asp:ListItem Value="0">Method 1</asp:ListItem>
          <asp:ListItem Value="1">Method 2</asp:ListItem>
          <asp:ListItem Value="2">Method 3</asp:ListItem>
        </asp:DropDownList>
      </div>


                    <div class="form-group fg5" id="dvledg1">
                        <label for="email" class="fg2_la1">Transaction Type: <span class="spn1">&nbsp;</span></label>
                        <asp:DropDownList ID="ddlTranscationType" class="form-control fg2_inp1 fg_chs1 inp_mst" runat="server" onchange="return ChangeType();">
                            <asp:ListItem Value="0">Payment</asp:ListItem>
                            <asp:ListItem Value="1">Receipt</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="dis_pay">
                        <div class="form-group fg5">
                            <label for="email" class="fg2_la1">Postdated Ref#: <span class="spn1">&nbsp;</span></label>
                            <input id="TxtRef" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control fg2_inp1" maxlength="50" />
                        </div>
                        <div id="DivAccountBook" class="form-group fg5">
                            <label for="pwd" class="fg2_la1 fg_9">
                                Account Book:<span class="spn1">*</span>
                                <span class="input-group-addon cur2 c2h flt_amt1" style="display: none;"><i class="fa fa-money"></i>2000.00</span>
                            </label>
                            <asp:DropDownList ID="ddlAccontLed" onchange="FillChequeBookLoad('-1', null,'1')" class="form-control fg2_inp1 fg_chs1 inp_mst ddl" runat="server">
                            </asp:DropDownList>

                        </div>

                        <div class="form-group fg5">
                            <div class="tdte">
                                <label for="pwd" class="fg2_la1">Entry Date:<span class="spn1"></span> </label>
                                <div id="datepicker1" class="input-group date" data-date-format="dd-mm-yyyy">
                                    <input id="txtdate" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event)" onchange="IncrmntConfrmCounter()" class="form-control inp_bdr" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                    <span id="PaymentDatePikrSpan" runat="server" class="input-group-addon date1" onchange="IncrmntConfrmCounter()"><i class="fa fa-calendar"></i></span>
                                </div>
                            </div>
                            <script>
                                var StartDate = "";
                                if (document.getElementById("<%=HiddenRestritionStatus.ClientID%>").value == "1")
                              StartDate = document.getElementById("<%=HiddenFinancialYrStartDate.ClientID%>").value;
                          else
                              StartDate = document.getElementById("<%=HiddenStartDate.ClientID%>").value
                          var curentDate = "";
                          curentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value
                             $noCon('#datepicker1').datepicker({
                                 autoclose: true,
                                 format: 'dd-mm-yyyy',
                                 startDate: StartDate,
                                 endDate: curentDate,
                                 timepicker: false
                             });
                            </script>
                        </div>

                        <div class="clearfix"></div>
                        <div class="free_sp"></div>
                        <div class="devider"></div>
                        <!----display when click on post dated checkbox--->

                        <div id="">

                            <div id="DivAccountParty" class="form-group fg2">
                                <label for="pwd" class="fg2_la1 fg_9">
                                    Party:<span class="spn1">*</span>
                                    <span class="input-group-addon cur2 c2h c3 flt_amt1" style="display: none;"><i class="fa fa-money"></i></span>
                                </label>
                                <asp:DropDownList ID="ddlSupplier" class="form-control fg2_inp1 fg_chs1 inp_mst ddl" runat="server" onchange="return ChangeMethod();">
                                </asp:DropDownList>
                            </div>

                            <div id="DivAccountParty1" class="form-group fg2" style="display: none;">
                                <label for="pwd" class="fg2_la1 fg_9">
                                    Party:<span class="spn1">*</span>
                                    <span class="input-group-addon cur2 c2h c3 flt_amt1" style="display: none;"><i class="fa fa-money"></i></span>
                                </label>
                                <asp:DropDownList ID="ddlSupplier1" class="form-control fg2_inp1 fg_chs1 inp_mst ddl" runat="server" onchange="return ChangeMethod();">
                                </asp:DropDownList>
                            </div>

  <div id="divInvoice" class="form-group fg2">
    <label for="pwd" class="fg2_la1 fg_9">Invoice#:<span class="spn1">*</span>
      <span id="spanBalance" class="input-group-addon cur2 c2h c3 flt_amt1"></span>
    </label>
      <div id="divddlInvoice">
      <asp:DropDownList ID="ddlInvoice" class="form-control fg2_inp1 fg_chs1 inp_mst" runat="server" onchange="return GetBalance();">
         </asp:DropDownList>
      </div>
  </div>

  <div id="divExp" class="form-group fg2">
    <label for="pwd" class="fg2_la1 fg_9">Income/ Expense Ledger:<span class="spn1">*</span></label>
      <div id="divddlExp">
     <asp:DropDownList ID="ddlExp" class="form-control fg2_inp1 fg_chs1 inp_mst ddl" onchange="IncrmntConfrmCounter()" runat="server">
         </asp:DropDownList>
      </div>
  </div>

  <div id="divIncm" class="form-group fg2">
    <label for="pwd" class="fg2_la1 fg_9">Income/ Expense Ledger:<span class="spn1">*</span></label>
      <div id="divddlIncm">
     <asp:DropDownList ID="ddlIncm" class="form-control fg2_inp1 fg_chs1 inp_mst ddl" onchange="IncrmntConfrmCounter()" runat="server">
         </asp:DropDownList>
      </div>
  </div>

                            <div class="clearfix"></div>

                            <div class=" tab2 tab3">
                                <div class="tablinks tb_butn active">Cheque Details</div>
                            </div>

                            <div id="Cheque_details" class="tab3content">
                                <div class="form-group fg4">
                                    <label for="email" class="fg2_la1">Payee Name:<span class="spn1">*</span></label>
                                    <input type="text" id="txtPayee" runat="server" autocomplete="off" onchange="IncrmntConfrmCounter()" class="form-control fg2_inp1 inp_mst" onkeyup="return DisableEnter(event)" placeholder="Enter Payee Name" name="email" />
                                </div>
                                <div class="fg4">
                                    <label for="email" class="fg2_la1 pad_l">Cheque Issued:<span class="spn1">&nbsp;</span></label>
                                    <div class="check1">
                                        <div class="">
                                            <label class="switch">
                                                <input type="checkbox" runat="server" onkeypress="return DisableEnter(event)" id="ChkStatus_Cheque" onchange="return IssueDateCheck()" onclick="IncrmntConfrmCounter()" />
                                                <span class="slider_tog round"></span>
                                            </label>
                                        </div>
                                    </div>
                                </div>

                                <div class="fg2">
                                    <div class="tdte">
                                        <label for="pwd" class="fg2_la1">Cheque Issued Date:<span class="spn1"></span> </label>
                                        <div id="DivDatePickerChequeIssue" class="input-group date" data-date-format="dd-mm-yyyy">
                                            <input id="txtIssueDate_Cheque" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr" onchange="IncrmntConfrmCounter()" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                            <span id="ChequeIssueDatePikrSpan" runat="server" class="input-group-addon date1" onchange="IncrmntConfrmCounter()"><i class="fa fa-calendar"></i></span>
                                            <script>
                                                var StartDate = "";
                                                StartDate = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
                  var curentDate = "";
                  curentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value
                  $noCon('#DivDatePickerChequeIssue').datepicker({
                      autoclose: true,
                      format: 'dd-mm-yyyy',
                      startDate: StartDate,
                      endDate: curentDate,
                      timepicker: false
                  });
                                            </script>
                                        </div>

                                    </div>
                                </div>

                            </div>
                            <!---tab3content_closed--->

                            <table class="table table-bordered">
                                <thead class="thead1">
                                    <tr>
                                        <th class="th_b2 tr_l" id="thFirst">Cheque Book</th>
                                        <th class="th_b2 tr_l" id="thIban" style="display: none;">IBAN</th>
                                        <th class="th_b6 tr_c tr_l">Cheque#</th>
                                        <th class="th_b6 tr_c tr_l">Date</th>
                                        <th class="th_b7 tr_r">Amount</th>
                                        <th class="th_b11 tr_c">Remarks</th>
                                        <th class="th_b6 tr_c">ACTIONS</th>
                                        <th class="th_b7 tr_c">Generate</th>
                                        <th class="th_b7 tr_c">Paid/Reject</th>
                                        <th class="th_b7 tr_c" id="thPrint">Cheque Print</th>
                                    </tr>
                                </thead>
                                <tbody id="Cheque_tBody">
                                </tbody>
                            </table>

                        </div>
                        <!----dvchke_section_closed--->

                        <div class="clearfix"></div>

                        <div class="text_area_container">
                            <div class="col-md-7 ma_at_fl">
                                <div class="form-group iv">
                                    <label for="email" class="fg2_la1">Description:<span class="spn1">&nbsp;</span></label>
                                    <textarea id="txtDescription" placeholder="Write something here..." class="form-control" runat="server" rows="4" cols="50" maxlength="450" onblur="return textCounter(cphMain_txtDescription, 450)" style="resize: none;" onchange="IncrmntConfrmCounter()">
         </textarea>
                                </div>
                            </div>

                            <div class="col-md-5 txt_alg flt_pr">
                                <label for="email" class="fg2_la1">Total Amount:<span class="spn1">&nbsp;</span></label>
                                <div class="input-group">
                                    <span class="input-group-addon cur1">
                                        <label id="lblCurrency" runat="server"></label>
                                    </span>
                                    <input id="txtGrantTotal" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control fg2_inp2 tr_r" maxlength="50" />
                                </div>
                            </div>
                        </div>

                    </div>
                    <!---dis_pay_closed--->


                    <div class="dis_rec">
                    </div>
                    <!---dis_rec_closed--->

                </div>
                <a id="btnFloat" runat="server" onmouseover="opensave()" type="button" class="save_b" title="Save">
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
                <div class="clearfix"></div>
                <div class="devider divid"></div>

                <div class="mySave1" id="mySave" runat="server">
                    <div class="save_sec">
                        <asp:Button ID="btnFloatSave" runat="server" OnClientClick="return ValidatePostDated_Cheque();" class="btn sub1" Text="Save" OnClick="btnsave_Click" />
                        <asp:Button ID="btnFloatSaveCls" runat="server" OnClientClick="return ValidatePostDated_Cheque();" class="btn sub3" Text="Save & Close" OnClick="btnsave_Click" />
                        <asp:Button ID="btnFloatUpdate" runat="server" OnClientClick="return ValidatePostDated_Cheque();" class="btn sub1" OnClick="btnUpdate_Click" Text="Update" />
                        <asp:Button ID="btnFloatUpdateCls" runat="server" OnClientClick="return ValidatePostDated_Cheque();" class="btn sub3" OnClick="btnUpdate_Click" Text="Update & Close" />
                        <asp:Button ID="btnFloatConfirm" runat="server" OnClientClick="return ConfirmAlert();" class="btn sub2" Text="Confirm" />
                        <asp:Button ID="btnFloatReopen" runat="server" class="btn sub2" Text="Reopen" OnClientClick="return ConfirmReopen();" />
                        <input type="button" id="btnFloatCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
                        <asp:Button ID="ButtnFloatClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                        <asp:Button ID="btnPRint" runat="server" class="btn sub2" Text="Print" OnClientClick="return PrintPdf();" />


                    </div>
                </div>



                <div id="divList" runat="server" class="list_b" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
                    <i class="fa fa-arrow-circle-left"></i>
                </div>


                <div class="sub_cont pull-right">
                    <div class="save_sec">

                        <asp:Button ID="btnsave" runat="server" class="btn sub1" Text="Save" OnClientClick="return ValidatePostDated_Cheque();" OnClick="btnsave_Click" />
                        <asp:Button ID="btnSaveCls" runat="server" class="btn sub3" Text="Save & Close" OnClientClick="return ValidatePostDated_Cheque();" OnClick="btnsave_Click" />
                        <asp:Button ID="btnUpdate" runat="server" class="btn sub1" OnClientClick="return ValidatePostDated_Cheque();" OnClick="btnUpdate_Click" Text="Update" />
                        <asp:Button ID="btnUpdateClose" runat="server" OnClientClick="return ValidatePostDated_Cheque();" class="btn sub3" OnClick="btnUpdate_Click" Text="Update & Close" />
                        <asp:Button ID="btnConfirm" runat="server" OnClientClick="return ConfirmAlert();" class="btn sub2" Text="Confirm" />
                        <asp:Button ID="btnConfirm1" runat="server" OnClick="btnConfirm1_Click" class="btn btn-primary btn-grey  btn-width" Text="confm" Style="display: none;" />
                        <asp:Button ID="btnReopen" runat="server" class="btn sub2" Text="Reopen" OnClientClick="return ConfirmReopen();" />
                        <asp:Button ID="btnReopen1" runat="server" class="btn btn-primary" Style="display: none" Text="Reopen" OnClick="btnReopen1_Click" />
                        <input type="button" id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
                        <asp:Button ID="ButtnClose" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                        <asp:Button ID="btnFloatPrint" runat="server" class="btn sub2" Text="Print" OnClientClick="return PrintPdf();" />


                    </div>
                </div>


            </div>
            <!-------working area_closed---->

        </div>
    </div>
  <div>
        <div class="col-md-12" style="padding: 9px;">
            <div style="float: right;">
                <a id="print_cap" target="_blank" href="19_Print.htm" style="display: none;" />
                <input type="text" id="PlblHeight" style="display: none;" runat="server" />
                <input type="text" id="PlblWidth" style="display: none;" runat="server" />
                <input type="text" id="PlblPayeeTop" style="display: none;" runat="server" />
                <input type="text" id="PlblPayeeLeft" style="display: none;" runat="server" />
                <input type="text" id="PlblDateTop" style="display: none;" runat="server" />
                <input type="text" id="PlblDateLeft" style="display: none;" runat="server" />
                <input type="text" id="PlblAmntWordTop" style="display: none;" runat="server" />
                <input type="text" id="PlblAmntWordLeft" style="display: none;" runat="server" />
                <input type="text" id="PlblAmntWordTop1" style="display: none;" runat="server" />
                <input type="text" id="PlblAmntWordLeft1" style="display: none;" runat="server" />
                <input type="text" id="PlblAmntNumTop" style="display: none;" runat="server" />
                <input type="text" id="PlblAmntNumLeft" style="display: none;" runat="server" />
                <input type="text" id="TextBox1" style="display: none;" runat="server" />
                <input type="text" id="TextBox2" style="display: none;" runat="server" />
                <input type="text" id="TextBox3" style="display: none;" runat="server" />
                <input type="text" id="TextBox4" style="display: none;" runat="server" />
                <input type="text" id="TextBox5" style="display: none;" runat="server" />
                 <input type="text" id="txtPrintPos" style="display:none;" runat="server"/> 

            </div>
        </div>
    </div>

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



 
    </a>



 
</asp:Content>

