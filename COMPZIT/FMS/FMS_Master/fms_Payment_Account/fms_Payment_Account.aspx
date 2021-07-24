<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Payment_Account.aspx.cs" Inherits="FMS_FMS_Master_fms_Payment_Account_fms_Payment_Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>

    <script src="/js/Common/Common.js"></script>

    <script>
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
           
            document.getElementById("cphMain_hiddenSelectedAccntBk").value = document.getElementById("cphMain_ddlAccontLed").value;
            $("#divAccount > input").focus();
            $("#divAccount > input").select();
            IssueDateCheck();
            document.getElementById("cphMain_txtDescription").value = document.getElementById("cphMain_txtDescription").value.trim();
            // document.getElementById("divErrMsgCnclRsn").style.display = "none";
            var EditVal = document.getElementById("<%=HiddenEdit.ClientID%>").value;
            var DftCurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
            var DdlAccnt = document.getElementById("<%=ddlCurrency.ClientID%>").value;
            var ForexTl = 0;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

           if (EditVal != "") {
               if (document.getElementById("<%=HiddenGrdTotl.ClientID%>").value != "") {
                    document.getElementById("<%=txtGrantTotal.ClientID%>").value = document.getElementById("<%=HiddenGrdTotl.ClientID%>").value;
                    if (DdlAccnt != "") {
                        if (DdlAccnt != DftCurrencyId) {
                            if (document.getElementById("<%=txtExchangeRate.ClientID%>").value != "") {
                                ForexTl = parseFloat(document.getElementById("<%=HiddenGrdTotl.ClientID%>").value) * parseFloat(document.getElementById("<%=txtExchangeRate.ClientID%>").value);
                                //ForexTl = document.getElementById("<%=txtForexTotal.ClientID%>").value;
                                if (FloatingValue != "") {
                                    ForexTl = ForexTl.toFixed(FloatingValue);
                                }
                            }
                            document.getElementById("<%=txtForexTotal.ClientID%>").value = ForexTl;
                          if( document.getElementById("<%=txtForexTotal.ClientID%>").value !="")
                            addCommas("cphMain_txtForexTotal");
                        }
                    }
                   if (document.getElementById("<%=txtGrantTotal.ClientID%>").value != "")
                    addCommas("cphMain_txtGrantTotal");
                }

                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = EditVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].PYMNT_LDGR_ID != "") {
                            EditListRows(json[key].PYMNT_ID, json[key].PYMNT_LDGR_ID, json[key].LDGR_ID, json[key].LDGR_AMT, json[key].LDGR_NAME, json[key].PYMNT_CST_ID, json[key].COSTCNTR_ID, json[key].PYMNT_CST_AMT, json[key].PURCHS_ID, json[key].RECPT_PURCHS_REF, json[key].COST_LD, json[key].CHK_ID, json[key].PAYMNT_LD_REMARK, json[key].OB_PAID, json[key].EXPNS_DTLS);
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
                AddNewGroup(null);
                AccntChangeFunt(null,0);
            }

            if (document.getElementById("<%=HiddenupdCheckNumber.ClientID%>").value != "" && document.getElementById("<%=HiddenupdCheckNumber.ClientID%>").value != "0") {
                LoadChequeBookNum(document.getElementById("<%=HiddenupdCheckNumber.ClientID%>").value, '1');
            }

            if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "Cheque") {

                $('#liBankTransfer').removeClass('active tablinks').addClass('tablinks');
                $('#BankTransfer').removeClass('tab2content tab-pane fade active in').addClass('tab-pane fade');
                $('#liDD').removeClass('active tablinks').addClass('tablinks');
                $('#DD').removeClass('tab2content tab-pane fade active in').addClass('tab-pane fade');
                $('#lisCheque').removeClass('tablinks').addClass('active tablinks');
                $('#Cheque').removeClass('tab-pane fade').addClass('tab2content tab-pane fade active in');
                document.getElementById("DD").style.display = "none";
                document.getElementById("BankTransfer").style.display = "none";
                document.getElementById("Cheque").style.display = "block";
            

                if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {

                   document.getElementById("cphMain_ddlChequeBook_Cheque").disabled = true;
                   document.getElementById("cphMain_ddlChequeNum_Cheque").disabled = true;
                   document.getElementById("cphMain_txtPayee").disabled = true;


                   document.getElementById("cphMain_txtDate_Cheque").disabled = true;
                   document.getElementById("cphMain_ChkStatus_Cheque").disabled = true;
                   document.getElementById("cphMain_txtIssueDate_Cheque").disabled = true;

                   document.getElementById("liBankTransfer").disabled = true;
                   document.getElementById("liDD").disabled = true;
                   document.getElementById("lisCheque").disabled = true;
                }

                if (document.getElementById("<%=hiddenPostdated.ClientID%>").value == "1") {//Postdated

                    document.getElementById("cphMain_ddlChequeBook_Cheque").disabled = true;
                    document.getElementById("cphMain_ddlChequeNum_Cheque").disabled = true;
                    document.getElementById("cphMain_txtPayee").disabled = true;


                    document.getElementById("cphMain_txtDate_Cheque").disabled = true;
                    document.getElementById("cphMain_ChkStatus_Cheque").disabled = true;
                    document.getElementById("cphMain_txtIssueDate_Cheque").disabled = true;

                    document.getElementById("liBankTransfer").disabled = true;
                    document.getElementById("liDD").disabled = true;
                    document.getElementById("lisCheque").disabled = true;
                    
                }

           }
           else if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "DD") {

               $('#liBankTransfer').removeClass('active tablinks').addClass('tablinks');
               $('#BankTransfer').removeClass('tab2content tab-pane fade active in').addClass('tab-pane fade');
               $('#lisCheque').removeClass('active tablinks').addClass('tablinks');
               $('#Cheque').removeClass('tab2content tab-pane fade active in').addClass('tab-pane fade');


               $('#liDD').removeClass('tablinks').addClass('active tablinks');
               $('#DD').removeClass('tab-pane fade').addClass('tab2content tab-pane fade active in');
               document.getElementById("DD").style.display = "block";
               document.getElementById("BankTransfer").style.display = "none";
               document.getElementById("Cheque").style.display = "none";
               if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                    document.getElementById("cphMain_txtDD_DD").disabled = true;
                    document.getElementById("cphMain_txtDate_DD").disabled = true;
                    document.getElementById("cphMain_txtDate_DD").style.backgroundColor = "#eee";

                    document.getElementById("liBankTransfer").disabled = true;
                    document.getElementById("lisCheque").disabled = true;
                }

            }
            else if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "BankTransfer") {

                $('#liDD').removeClass('active tablinks').addClass('tablinks');
                $('#DD').removeClass('tab2content tab-pane fade active in').addClass('tab-pane fade');
                $('#lisCheque').removeClass('active tablinks').addClass('tablinks');
                $('#Cheque').removeClass('tab2content tab-pane fade active in').addClass('tab-pane fade');

                $('#liBankTransfer').removeClass('tablinks').addClass('active tablinks');
                $('#BankTransfer').removeClass('tab-pane fade').addClass('tab2content tab-pane fade active in');
                document.getElementById("DD").style.display = "none";
                document.getElementById("BankTransfer").style.display = "block";
                document.getElementById("Cheque").style.display = "none";
                if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                    document.getElementById("cphMain_ddlMode_BankTransfer").disabled = true;
                    document.getElementById("cphMain_txtDate_BankTransfer").disabled = true;
                    document.getElementById("cphMain_Bank_BankTransfer").disabled = true;
                    document.getElementById("cphMain_IBAN_BankTransfer").disabled = true;
                    document.getElementById("cphMain_txtDate_BankTransfer").style.backgroundColor = "#eee";


                    document.getElementById("liDD").disabled = true;
                    document.getElementById("lisCheque").disabled = true;
                }
            }
            else if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value != "") {
                $('#liBankTransfer').removeClass('active tablinks').addClass('tablinks');
                $('#BankTransfer').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                $('#liDD').removeClass('active tablinks').addClass('tablinks');
                $('#DD').removeClass('tab-pane fade active in').addClass('tab-pane fade');

                $('#lisCheque').removeClass('tablinks').addClass('active tablinks');
                $('#Cheque').removeClass('tab-pane fade').addClass('tab-pane fade active in');
                document.getElementById("DD").style.display = "none";
                document.getElementById("BankTransfer").style.display = "none";
                document.getElementById("Cheque").style.display = "block";

                if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {

                    document.getElementById("cphMain_ddlChequeBook_Cheque").disabled = true;
                    document.getElementById("cphMain_ddlChequeNum_Cheque").disabled = true;
                    document.getElementById("cphMain_txtPayee").disabled = true;

                    document.getElementById("cphMain_txtDate_Cheque").disabled = true;
                    document.getElementById("cphMain_ChkStatus_Cheque").disabled = true;
                    document.getElementById("cphMain_txtIssueDate_Cheque").disabled = true;
                    document.getElementById("cphMain_txtDate_Cheque").style.backgroundColor = "#eee";


                }
            }

            document.getElementById("lblCurrency").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            document.getElementById("lblCurrncy1").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            document.getElementById("lblCurrncy2").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            document.getElementById("lblCurrncy3").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            document.getElementById("lblCurrncy4").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;

            //evm-0043 start
            document.getElementById("lblcur1").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            document.getElementById("lblcur2").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            document.getElementById("lblcur3").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            document.getElementById("lblcur4").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;


            if (document.getElementById("<%=HiddenView.ClientID%>").value == "0") {
                confirmbox = 0;
                
            }
            if (document.getElementById("<%=HiddenView.ClientID%>").value == "") {
                confirmbox = 0;

            }
           
        });

        //(function ($au) {
        //    $au(function () {
        //        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //        prm.add_endRequest(EndRequest);
        //        $au('form').submit(function () {
        //        });
        //    });
        //})(jQuery);


        //function EndRequest(sender, args) {
        //    $('.nav-item active').removeClass('nav-item active').addClass('nav-item');
        //    $('#').removeClass('nav-item').addClass('nav-item active');
        //}
    </script>
    <script>
        var yvalue = 0;
        function EditListRows(PYMNT_ID, PYMNT_LDGR_ID, LDGR_ID, LDGR_AMT, LDGR_NAME, PYMNT_CST_ID, COSTCNTR_ID, PYMNT_CST_AMT, PURCHS_ID, RECPT_PURCHS_REF, COST_LD, CHK_ID, PAYMNT_LD_REMARK, OB_PAID, EXPNS_DTLS) {
            if (LDGR_ID != 0) {
                AddNewGroup(LDGR_ID);
                document.getElementById("ddlLedId" + currntx).value = LDGR_ID;
                document.getElementById("TxtAmount_" + currntx).value = LDGR_AMT;
                document.getElementById("txtAmntVal" + currntx).value = LDGR_AMT;
                document.getElementById("TxtRemark" + currntx).value = PAYMNT_LD_REMARK;
                addCommas("TxtAmount_" + currntx);
                document.getElementById("tdEvtGrp" + currntx).value = "UPD";
                document.getElementById("tdDtlIdTempid" + currntx).value = PYMNT_LDGR_ID;
                document.getElementById("tdDtlIdGrp" + currntx).value = PYMNT_LDGR_ID;
                document.getElementById("tdInxGrp" + currntx).value = currntx;
                document.getElementById("tdLedgrPaid" + currntx).value = OB_PAID;




                document.getElementById("journalADD" + currntx).style.opacity = "0.3";
                PendingPurchase("TxtAmount_" + currntx, currntx,0);

                if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                    document.getElementById("ddlLedId" + currntx).disabled = true;
                    document.getElementById("TxtAmount_" + currntx).disabled = true;
                    document.getElementById("TxtRemark" + currntx).disabled = true;
                    document.getElementById("tdEvtGrp" + currntx).value = "UPD";
                    document.getElementById("tdDtlIdTempid" + currntx).disabled = true;
                    document.getElementById("ddlRecptLedger" + currntx).disabled = true;

                    document.getElementById("bttnRemovGrp" + currntx).disabled = true;
                    document.getElementById("journalADD" + currntx).disabled = true;
                    $("#tableGrp").find("input").attr("disabled", "disabled");

                }
            }
            if (COSTCNTR_ID != null && COSTCNTR_ID != "" && COSTCNTR_ID != 0) {
                document.getElementById("tdCostCenterDtls" + currntx).value = COSTCNTR_ID;
            }
            if (PURCHS_ID != null && PURCHS_ID != "" && PURCHS_ID != 0) {
                document.getElementById("tdPurchaseDtls" + currntx).value = PURCHS_ID;
            }
            //0043
            if (EXPNS_DTLS != null && EXPNS_DTLS != "" && EXPNS_DTLS != 0) {
                document.getElementById("tdExpenseDtls" + currntx).value = EXPNS_DTLS;
            }

            ddlLedOnchange(currntx, "upd");
           
            AccntChangeFunt(CHK_ID,0);

            if (document.getElementById("<%=hiddenPostdated.ClientID%>").value == "1") {
                document.getElementById("bttnRemovGrp" + currntx).disabled = true;
                document.getElementById("journalADD" + currntx).disabled = true;
                $("#tableGrp").find("input").attr("disabled", "disabled");
                document.getElementById("tdCostCenterDtls" + currntx).disabled = false;
                document.getElementById("tdPurchaseDtls" + currntx).disabled = false;
                document.getElementById("tdEvtGrp" + currntx).disabled = false;
                document.getElementById("tdDtlIdTempid" + currntx).disabled = false;
                document.getElementById("tdDtlIdGrp" + currntx).disabled = false;
                document.getElementById("tdInxGrp" + currntx).disabled = false;
                document.getElementById("ddlLedId" + currntx).disabled = false;
                document.getElementById("txtAmntVal" + currntx).disabled = false;
                //0043
                document.getElementById("tdExpenseDtls" + currntx).disabled = false;
                
            }//Postdated

        }



        var rowSubCatagory = 0;
        var RowIndex1 = 0;
        var flg = 0;
        function 
            AddNewGroup(ledgerid) {
            RowIndex1++;
            var FrecRow = '';
            FrecRow = '<tr class="tr1" id="SubGrpRowId_' + RowIndex1 + '" ><td   id="tdidGrpDtls' + RowIndex1 + '" style="display: none" >' + RowIndex1 + '</td>';
            FrecRow += '<div style="clear:both"></div><div style="display:none" id="divgroupSubCat' + RowIndex1 + '">' + rowSubCatagory + '</div> ';
            var yy = rowSubCatagory + 1;

            FrecRow += '<td><div id="divLedger' + RowIndex1 + '">';
            FrecRow += '<select onkeypress="return DisableEnter(event)"   class="fg2_inp2 fg2_inp3 fg_chs1 f_p3 ddl" id="ddlRecptLedger' + RowIndex1 + '"  onchange="PaymentLedger(' + RowIndex1 + ');"></select>';
            FrecRow += '</div> <span id="AccntBalance_' + RowIndex1 + '" class="input-group-addon cur2 "></span><input class="form-control" style="display:none" name="ddlLedId' + RowIndex1 + '"  value="0" id="ddlLedId' + RowIndex1 + '" type="text"></td>';

            FrecRow += '<td class="tr_r"><div class="input-group"> <span class="input-group-addon cur1"><label for="example-text-input" class="col-form-label" >' + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value + '</label></span><input class="form-control fg2_inp2 tr_r" autocomplete="\off"\ onkeydown="return isDecimalNumber(event,\'TxtAmount_' + RowIndex1 + '\');" onkeypress="return isDecimalNumber(event,\'TxtAmount_' + RowIndex1 + '\');" name="TxtAmount_' + RowIndex1 + '"  onblur="return PendingPurchase(\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',1);"   value="" id="TxtAmount_' + RowIndex1 + '" maxlength="10" type="text" style="text-align: right;"><input class="form-control" style="display:none" name="txtAmntVal' + RowIndex1 + '"  value="0" id="txtAmntVal' + RowIndex1 + '" type="text"> </div></td>';
            FrecRow += '<td><textarea  name="TxtRemark' + RowIndex1 + '"    value="" id="TxtRemark' + RowIndex1 + '" maxlength="450"  rows="3" cols="20"  class="form-control" style="resize: none;" onblur="textCounter(TxtRemark' + RowIndex1 + ',450)" onkeyup="textCounter(TxtRemark' + RowIndex1 + ',450)"></textarea></td>';

            FrecRow += '<td class="td1"><div class="btn_stl1">';
            FrecRow += '<button title="ADD"  id="journalADD' + RowIndex1 + '" onclick="return FuctionAddGroup(\'' + RowIndex1 + '\')" class="btn act_btn bn2" ><span   class="fa fa-plus"  style="display: block;">&nbsp;</span></button>';
            FrecRow += '<button title="DELETE" id="bttnRemovGrp' + RowIndex1 + '"   onclick="return removeRowGrps(' + RowIndex1 + ',\'Are you sure you want to delete this ledger?\')" class="btn act_btn bn3" ><span class="fa fa-trash"   style="display: block;">&nbsp;</span></button>';
            FrecRow += '</div></td>';

            FrecRow += '<td>';
            FrecRow += '<a href="javascript:void(0)" title="PURCHASE" id="ChkPurchase' + RowIndex1 + '" onclick="return ddlLedOnchange(\'' + RowIndex1 + '\',\'ins\');"><i id="iSaleTag' + RowIndex1 + '" class="fa fa-shopping-cart ad_fa psc_p"></i></a>';
            FrecRow += '<a href="javascript:void(0)" title="COST CENTRE" id="ChkCostCenter' + RowIndex1 + '" onclick="MyModalCostCenter(\'' + RowIndex1 + '\',\'' + rowSubCatagory + '\',null);"><i class="fa fa-filter ad_fa"></i></a>';
            FrecRow += '</td>';

            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowIndex1 + '" name="tdCostCenterDtls' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdPurchaseDtls' + RowIndex1 + '" name="tdPurchaseDtls' + RowIndex1 + '" placeholder=""/></td>';

            //0043
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdExpenseDtls' + RowIndex1 + '" name="tdExpenseDtls' + RowIndex1 + '" placeholder=""/></td>';

            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" value="INS" style="display:none;"  id="tdEvtGrp' + RowIndex1 + '" name="tdEvtGrp' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdDtlIdTempid' + RowIndex1 + '" name="tdDtlIdTempid' + RowIndex1 + '" placeholder=""/><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdGrp' + RowIndex1 + '" name="tdDtlIdGrp' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdInxGrp' + RowIndex1 + '" name="tdInxGrp' + RowIndex1 + '" placeholder=""/> </td>';

            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdLedgrPaid' + RowIndex1 + '" name="tdLedgrPaid' + RowIndex1 + '" /> </td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdOpenSts' + RowIndex1 + '" name="tdOpenSts' + RowIndex1 + '" /> </td>';

            FrecRow += '</tr>';

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
            if (ledgerid == null) {
                if (RowIndex1 != "1") {
                    $("#divLedger" + RowIndex1 + "> input").focus();
                    $("#divLedger" + RowIndex1 + "> input").select();
                }
            }
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 38 || keyCodes == 40) {
                return true;
            }
        
            else if (keyCodes == 46) {
                return true;
            }
            else if (keyCodes == 34 || keyCodes == 33 || keyCodes == 36 || keyCodes == 35 || keyCodes == 41) {

                return true;
            }
      
            else if ((keyCodes == 65 || keyCodes == 86 || keyCodes == 67) && (evt.ctrlKey === true || evt.metaKey === true)) {
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

        var currntx = "";
        var currnty = "";

        var submit = 0;

        function CheckIsRepeatSubmit() {
            if (submit++ > 1) {

                return false;
            }
            else {

                return true;
            }
        }
        function CheckSubmitZero() {
            submit = 0;
        }
        function PaymentLedger(x) {
            IncrmntConfrmCounter();
            var LedgerId = 0;
            if (document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) {
                if (LedgerDuplication(x) == true) {
                    LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                    document.getElementById("ddlLedId" + x).value = LedgerId;

                    document.getElementById("TxtAmount_" + x).value = "";
                    document.getElementById("txtAmntVal" + x).value = "";
                    
                    document.getElementById("tdCostCenterDtls" + x).value = "";
                    document.getElementById("tdPurchaseDtls" + x).value = "";
                    //0043
                    document.getElementById("tdExpenseDtls" + x).value = "";
                }
            }
        }
        //function PaymentLedgerChange(x) {
        //    var LedgerId = 0;
        //    if (document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) {
        //        LedgerId = document.getElementById("ddlRecptLedger" + x).value;
        //        document.getElementById("ddlLedId" + x).value = LedgerId;
        //    }
        //}

        function CostCentr(x, y, CostCenterId) {
            var TxtCstctrAmount = "";
            TxtCstctrAmount = document.getElementById("txtAmntVal" + x).value;
            TxtCstctrAmount = TxtCstctrAmount.trim();
            TxtCstctrAmount = TxtCstctrAmount.replace(/,/g, "");
            document.getElementById("TxtAmount_" + x).style.borderColor = "";
            $("#divLedger" + x + "> input").css("borderColor", "");
            if ((document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) && TxtCstctrAmount != "") {
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
                }
                else {
                    FunctionQustn(x, y, CostCenterId, CostCenterId, CostCenterId);
                }
                document.getElementById("BtnPopupCstCntr").click();
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                TxtCstctrAmount = parseFloat(TxtCstctrAmount);
                if (FloatingValue != "") {
                    TxtCstctrAmount = TxtCstctrAmount.toFixed(FloatingValue);
                }
                addCommasSummry(TxtCstctrAmount);

                document.getElementById("LedgerAmtInModal" + x).innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                if (document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value != "") {
                    document.getElementById("LedgerAmtInModal" + x).innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                }
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


        function isNumberWithDigit(evt, textboxid) {
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40 || keyCodes == 118 || keyCodes == 17) {
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
                    return false;
                }

            }
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                    if (keyCodes == 118 || keyCodes == 17)
                        ret = true;
                }
                if (keyCodes == 86 || keyCodes == 17 || keyCodes == 67)
                    ret = true;


                return ret;
            }
        }

        function FunctionQustn(x, y, CostCenterId, CostGrp1Id, CostGroup2Id) {
            y++;
            submit++;
            var FrecRowQst = '';
            FrecRowQst += '<tr id="SubQstnRowId_' + x + '' + y + '" ><td   id="tdidQstnDtls' + x + '' + y + '" style="display: none" >' + x + '' + y + '</td>';
            FrecRowQst += '<td   id="tdvalidate' + x + '' + y + '" style="display: none" >' + x + '</td>';
            FrecRowQst += '<td   id="tdvalidatey' + x + '' + y + '" style="display: none" >' + y + '</td>';
            FrecRowQst += '<td>';
            FrecRowQst += '<input name="TxtRecptCosGrp1_' + x + '' + y + '"  style="display: none;pointer-events: none;" class="form-control" id="TxtRecptCosGrp1_' + x + '' + y + '" ><div id="divCostGrp1' + x + '' + y + '"><select id="ddlRecptCosGrp1_' + x + '' + y + '" name="ddlRecptCosGrp1_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl" onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostGrp1Id_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostGrp1Id_' + x + '' + y + '" ></td>';
            FrecRowQst += '<td>';
            FrecRowQst += '<input name="TxtRecptCosGrp2_' + x + '' + y + '"  style="display: none;pointer-events: none;" class="form-control" id="TxtRecptCosGrp2_' + x + '' + y + '" ><div id="divCostGrp2' + x + '' + y + '"><select id="ddlRecptCosGrp2_' + x + '' + y + '" name="ddlRecptCosGrp2_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl" onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostGrp2Id_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostGrp2Id_' + x + '' + y + '" ></td>';
            FrecRowQst += '<td ><input style="display:none" value="-1" name="TxtIdSales_' + x + '' + y + '" class="form-control" id="TxtIdSales_' + x + '' + y + '" ><input name="TxtRecptCosCtr_' + x + '' + y + '"  style="display: none;pointer-events: none;background: #eee;" class="form-control" id="TxtRecptCosCtr_' + x + '' + y + '" ><div id="divCostCenter' + x + '' + y + '"><select id="ddlRecptCosCtr_' + x + '' + y + '" name="ddlRecptCosCtr_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 " onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div>';
            FrecRowQst += '<input name="ddlCostCtrId_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostCtrId_' + x + '' + y + '" ></td>';
            FrecRowQst += '<td class=" tr_r">';
            FrecRowQst += '<div class="input-group">';
            FrecRowQst += '<span class="input-group-addon cur1">';
            FrecRowQst += '' + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value; +'';
            FrecRowQst += '</span>';
            FrecRowQst += '<input class="form-control fg2_inp2 tr_r" maxlength="10"  id="TxtCstctrAmount_' + x + '' + y + '" name="TxtCstctrAmount_' + x + '' + y + '" value="" onblur="return CheckSumOfCstCntr(\'TxtCstctrAmount_' + x + '' + y + '\',' + x + ',' + y + ');"  autocomplete=\'off\'   onkeydown="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '' + y + '\');" onkeypress="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '' + y + '\');" id="TxtCstctrAmount_' + x + '' + y + '" type="text" />';
            FrecRowQst += '<input class="form-control"   id="TxtActCstctrAmount_' + x + '' + y + '" value="" onblur="return CheckSumOfLedger(\'TxtActCstctrAmount_' + x + '' + y + ',' + x + '\',' + y + ');" onkeyup="addCommas("TxtActCstctrAmount_' + x + '' + y + ')" style="display:none" onkeydown="return isNumber(event,TxtActCstctrAmount_' + x + '' + y + ');" name="TxtActCstctrAmount_' + x + '' + y + '" type="text"/>';
            FrecRowQst += '</div>';
            FrecRowQst += '</td>';
            FrecRowQst += '<td class="td1"> <div class="btn_stl1"><button title="ADD" id="btnCostCenter_' + x + '' + y + '" onclick="return CheckaddMoreRowsQstn(\'' + x + '\',\'' + y + '\',\'' + x + '' + y + '\');" class="btn act_btn bn2"><span  class="fa fa-plus"  style="display: block;">&nbsp;</span></button>';
            FrecRowQst += '<button class="btn act_btn bn3" id="btnCostCenterDel_' + x + '' + y + '" onclick="return removeRowQstn(' + x + ',' + y + ',' + x + '' + y + ',\'Are you sure you want to delete this cost centre?\')" ><span title="DELETE"   class="fa fa-trash" id="Span4" style="display: block;">&nbsp;</span></button>';
            FrecRowQst += '</div></td>';
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
            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                document.getElementById("btnCostCenter_" + x + y).disabled = "true";
                document.getElementById("btnCostCenterDel_" + x + y).disabled = "true";
                $("#TableAddQstnCostCenter" + x).find("input").attr("disabled", "disabled");
            }
            $("#divCostGrp1" + x + "" + y + " > input").focus();
            $("#divCostGrp1" + x + "" + y + " > input").select();
            return false;
        }
        function MyModalCostCenter(x, y, CstCntr) {
            var SbCostCenter = '';
            SbCostCenter = '<div class="modal fade" id=\"myModalCstCntr\"  role="dialog" data-backdrop=\"static\" aria-labelledby="exampleModalLabel" aria-hidden="true" tabindex="-1">';
            SbCostCenter += '<div class="modal-dialog mod1" role="document">';
            SbCostCenter += '<div class=\"modal-content\">';
            SbCostCenter += '<div class=\"modal-header\">';
            SbCostCenter += '<button type=\"button\" class=\"close\" onclick=\"return CloseModal(\'' + x + '\')\"><span aria-hidden="true">&times;</span></button>';
            SbCostCenter += "<h2 id=\"ModelHeading\" class=\"modal-title mod1 flt_l\"><i class=\"fa fa-filter\"></i>Cost Centre</h2>";
            SbCostCenter += "</div>";

            SbCostCenter += '<div class=\"alert alert-danger fade in\" id="divErrMsgCnclRsnCostCenter' + x + '" style=\"display: none;\">';
            SbCostCenter += '</div>';
            SbCostCenter += '<div class=\"al-box war\"  id="lblErrMsgCancelReasonCostCenter' + x + '"> Please fill this out</div>';
            SbCostCenter += '<div class=\"modal-body md_bd\">';




            SbCostCenter += '<div id=\"DivPopUpCostCenter\">';

            SbCostCenter += '<table class=\"table table-bordered\" id="TableAddQstnCostCenter' + x + '">';
            SbCostCenter += '<thead  class=\"thead1\"> <tr><th class=\"col-md-2 tr_l\" >Cost Group1</th><th class=\"col-md-2 tr_l\">Cost Group2</th><th class=\"col-md-2 tr_l\" >Cost Centre</th><th class=\"col-md-3 tr_r\"> Amount</th><th class=\"col-md-3\">ACTIONS';
            SbCostCenter += '</th></tr></thead>';
            SbCostCenter += '</table>';
            SbCostCenter += '</div></div>';
            SbCostCenter += '<div class=\"clearfix\"></div>';
            SbCostCenter += '<div class=\"modal-footer\">';
            SbCostCenter += '<div class="col-md-12 col_mar"><div class="box6 tr_r"><label id=\"Label1\" for=\"example-text-input\" class=\"fg2_la1 tt_am am1\" >Net Amount<span class="spn1"></span></label></div>';
            SbCostCenter += '<div class="box6 flt_r"><span id="LedgerAmtInModal' + x + '" class=\"tt_am am1 tt_al\"></span></label></div></div>';
            SbCostCenter += '<label for="example-text-input" class=\"col-form-label\" id="lblCurrencyCC"></label>';



            SbCostCenter += ' <button id="btnImportCostCenter' + x + '" type="button" class="btn btn-success" onclick=\"ButtnFillClickCostCenter(\'' + x + '\');\">Submit</button>';
            SbCostCenter += '<button type="button" class="btn btn-danger" onclick=\"return CloseModal(\'' + x + '\')\">Cancel</button>';

            //    SbCostCenter += '<button id="btnImportCostCenter' + x + '" type=\"button\" class=\"btn btn-success\"  onclick=\"ButtnFillClickCostCenter(\'' + x + '\');\" >Submit</button>';
            SbCostCenter += '<button id="BttnCost' + x + '" type=\"button\" style=\"display:none\" class=\"btn btn-primary\" data-dismiss=\"modal\"></button>';
            SbCostCenter += '</div></div> </div></div>';
            document.getElementById("CostCenterModal").innerHTML = SbCostCenter;
            CostCentr(x, y, CstCntr);
            buttnVisibile(x, "0");
            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                document.getElementById("btnImportCostCenter" + x).disabled = true;
            }
            var idlast = "";
            var row = $noCon('#TableAddQstnCostCenter' + x).find(' tbody tr:first').attr('id');
            idlast = row.split('_');
            //setTimeout(function () { focusCostCentre(idlast[1]); }, 350);
            focusCostCentre(idlast[1]);

        }

        function focusCostCentre(Rowid) {

            $('#myModalCstCntr').on('shown.bs.modal', function () {
                $("#divCostGrp1" + Rowid + " > input").focus();
                $("#divCostGrp1" + Rowid + " > input").select();
            });

        }

        function ddlCostCenterOnchange(x, y) {
            IncrmntConfrmCounter();
            if (document.getElementById("ddlRecptCosCtr_" + x + '' + y).value != 0) {
                var ddlCostcnt = document.getElementById("ddlRecptCosCtr_" + x + '' + y).value;
                document.getElementById("ddlCostCtrId_" + x + '' + y).value = ddlCostcnt;
            }
            CCDuplication(x, x + '' + y);
        }
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
                            var detailId = document.getElementById("tdDtlIdGrp" + removeNum).value;
                            var CanclIds = document.getElementById("cphMain_hiddenLedgerCanclDtlId").value;
                            if (CanclIds == '') {
                                document.getElementById("cphMain_hiddenLedgerCanclDtlId").value = detailId;
                            }
                            else {
                                document.getElementById("cphMain_hiddenLedgerCanclDtlId").value = document.getElementById("cphMain_hiddenLedgerCanclDtlId").value + ',' + detailId;
                            }
                        }
                        jQuery('#SubGrpRowId_' + removeNum).remove();
                        addRowtable = document.getElementById("tableGrp");
                        var TableRowCount = document.getElementById("tableGrp").rows.length;
                        if (TableRowCount != 1) {
                            for (var i = 1; i < addRowtable.rows.length; i++) {
                                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                                if (TableRowCount != 0) {
                                    if ((TableRowCount - 1) == i) {
                                        document.getElementById("tdInxGrp" + xLoop).value = "";
                                        document.getElementById("journalADD" + xLoop).style.opacity = "1";
                                    }

                                }
                            }
                        }
                        else {

                            AddNewGroup(null);
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
        function calculateTotal() {
            var LedgerTtl = 0;
            var addRowtable = document.getElementById("tableGrp");

            for (var i = 1; i < addRowtable.rows.length; i++) {
                var row = addRowtable.rows[i];
                var x = (addRowtable.rows[i].cells[0].innerHTML);
                if (document.getElementById("txtAmntVal" + x).value != "") {
                    var ldgramt = document.getElementById("txtAmntVal" + x).value;
                    ldgramt = ldgramt.replace(/\,/g, '');
                    LedgerTtl = parseFloat(LedgerTtl) + +parseFloat(ldgramt);
                }
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
                ForexTl = ForexTl.toFixed(FloatingValue);
            }
            document.getElementById("cphMain_txtGrantTotal").value = LedgerTtl;
            document.getElementById("cphMain_txtForexTotal").value = ForexTl;
            if (  document.getElementById("cphMain_txtForexTotal").value !="")
            addCommas("cphMain_txtForexTotal");
            if (document.getElementById("cphMain_txtGrantTotal").value != "")
            addCommas("cphMain_txtGrantTotal");

        }
        function buttnVisibile(x, Check) {
            var TableRowCount = document.getElementById("tableGrp").rows.length;
            addRowtable = document.getElementById("tableGrp");

            for (var i = 1; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                if (TableRowCount != 1) {
                    if (xLoop != "") {
                        if ((TableRowCount - 1) == i) {

                            document.getElementById("tdInxGrp" + xLoop).value = "";
                            document.getElementById("journalADD" + xLoop).style.opacity = "1";
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
        function ConfirmMessage() {

            //var url = window.location.pathname
            //var getQuery = url.split('?')[1]
            //var params = getQuery.split('&');

            //alert(params);

            //PassSavedValue(0);

            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Payment_Account_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "fms_Payment_Account_List.aspx";
                return false;
            }
        }
        function removeRowQstn(Rowid, y, removeNum, CofirmMsg) {
            IncrmntConfrmCounter();

            if (document.getElementById("cphMain_HiddenFieldView").value != "1") {
                ezBSAlert({
                    type: "confirm",
                    messageText: CofirmMsg,
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        // if (confirm(CofirmMsg)) {
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
                                var res = idlast.split("_");
                                // setTimeout(function () { focusCostCentre(res[1]); }, 350);
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

        function PendingPurchase(textboxid, x, modep) {
            if (modep == "1") {
                IncrmntConfrmCounter();
            }
            var Purchase_ret = true;
            var TxtCstctrAmount = "";
            TxtCstctrAmount = document.getElementById("TxtAmount_" + x).value;
            document.getElementById("txtAmntVal" + x).value = TxtCstctrAmount;
            TxtCstctrAmount = TxtCstctrAmount.trim();
            TxtCstctrAmount = TxtCstctrAmount.replace(/,/g, "");
            document.getElementById("TxtAmount_" + x).style.borderColor = "";
            $("#divLedger" + x + "> input").css("borderColor", "");
            if ((document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) && TxtCstctrAmount != "") {
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

                if (isNaN(TxtCstctrAmount)) {

                    document.getElementById("txtAmntVal" + x).value = "";
                }
                else {
                    TxtCstctrAmount = parseFloat(TxtCstctrAmount);

                    if (FloatingValue != "") {
                        TxtCstctrAmount = TxtCstctrAmount.toFixed(FloatingValue);
                    }
                    addCommasSummry(TxtCstctrAmount);

                }

                //TxtCstctrAmount = parseFloat(TxtCstctrAmount);
                //if (FloatingValue != "") {
                //    TxtCstctrAmount = TxtCstctrAmount.toFixed(FloatingValue);
                //}
                //addCommasSummry(TxtCstctrAmount);
                document.getElementById("LedgerAmtInModalPurchse").innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                if (document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value != "") {
                    document.getElementById("LedgerAmtInModalPurchse").innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + "  " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                }
            }

            if (document.getElementById("<%=hiddenPostdated.ClientID%>").value != "1") {//postdated

                if (document.getElementById("ddlRecptLedger" + x).value == "" || document.getElementById("ddlRecptLedger" + x).value == 0) {
                    Purchase_ret = false;
                    $("#divLedger" + x + "> input").css("borderColor", "red");
                    $("#divLedger" + x + "> input").focus();
                    $("#divLedger" + x + "> input").select();
                }
                if (TxtCstctrAmount == "" || TxtCstctrAmount <= 0) {
                    Purchase_ret = false;
                    document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                }
            }

            if (Purchase_ret == true) {
                if (LedgerDuplication(x) == true) {
                    varRowidx = x;
                    var ldgrSts = CheckSumOfLedger(textboxid, x);
                    if (document.getElementById("ddlRecptLedger" + x).value != "" && ldgrSts == true) {
                        var corpid = '<%= Session["CORPOFFICEID"] %>';
                        var orgid = '<%= Session["ORGID"] %>';
                        var userid = '<%= Session["USERID"] %>';
                        var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                        var CrncyAbrv = document.getElementById("cphMain_HiddenCurrencyAbrv").value;
                        var paymentID = "";
                        if (document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value != "")
                            paymentID = document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value;
                        var View = document.getElementById("<%=HiddenView.ClientID%>").value;
                        document.getElementById("ddlLedId" + x).value = LedgerId;
                        //evm-0043 start 20-03
                        var expenseID = "";
                        if (document.getElementById("<%=HiddenFieldExpncId.ClientID%>").value != "")
                            expenseID = document.getElementById("<%=HiddenFieldExpncId.ClientID%>").value;
                        //end
                        var LedgerDtlId = document.getElementById("tdDtlIdGrp" + x).value;

                        var mode = "ins";
                        $noCon.ajax({
                            type: "POST",
                            async: false,
                            url: "fms_Payment_Account.aspx/LoadSalesForLedger",
                            //evm-0043 start
                            data: '{intLedgerId:"' + LedgerId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" ,mode:"' + mode + '",x:"' + x + '",strCrncyAbrv:"' + CrncyAbrv + '",paymentID:"' + paymentID + '",View:"' + View + '",LedgerDtlId:"' + LedgerDtlId + '",expenceID:"' + expenseID + '"}',
                            //end
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                document.getElementById("tdOpenSts" + x).value = response.d[6];

                                document.getElementById("<%=HiddenOBstatus.ClientID%>").value = response.d[6];
                                if (response.d[0] != "") {
                                    if (document.getElementById("cphMain_HiddenFieldView").value != "1") {
                                        document.getElementById("ChkPurchase" + x).style.opacity = "1";
                                        document.getElementById("iSaleTag" + varRowidx).className = "fa fa-shopping-cart ad_fa psc_p gre";
                                    }
                                }
                                else {
                                    document.getElementById("ChkPurchase" + x).style.opacity = "0.3";
                                    document.getElementById("iSaleTag" + varRowidx).className = "fa fa-shopping-cart ad_fa psc_p";
                                }
                                if (response.d[1] != "") {
                                    addCommasSummry(response.d[1]);

                                    if (document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value != "") {
                                        document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;

                                    }
                                    else {
                                        document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;

                                    }
                                    if (response.d[2] == "CR")
                                        document.getElementById("AccntBalance_" + x).className = "input-group-addon cur2 c1h";
                                    else if (response.d[2] == "DR")
                                        document.getElementById("AccntBalance_" + x).className = "input-group-addon cur2 dr1";
                                }
                                else {
                                    document.getElementById("AccntBalance_" + x).innerHTML = "";
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
  
        function LedgerDuplication(rowId) {
            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("tableGrp");

            if (document.getElementById("<%=HiddenLedgrDupSts.ClientID%>").value != "1") {

                for (var i = 1; i < addRowtable.rows.length; i++) {
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
            }
            return ret;
        }

        function CCGrp1Duplication(x, xy) {
            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
            for (var i = 0; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                var xLoopLdgrId = $("#ddlRecptCosGrp1_" + xLoop).val();
                var LedgerId = $("#ddlRecptCosGrp1_" + xy).val();
                if (xLoop != xy) {
                    if ($("#ddlRecptCosGrp1_" + xy).val() != "0") {
                        if (xLoopLdgrId == LedgerId) {
                            $("#divCostGrp1" + xy + "> input").css("borderColor", "red");
                            $("#divCostGrp1" + xy + "> input").focus();
                            $("#divCostGrp1" + xy + "> input").select();
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Cost Group should not be duplicated";
                            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "";
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                            $noCon(window).scrollTop(0);
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

        function AmountCalculationForOB(intLedgerId) {


            //EVM-0027 Aug 26
            var tdOpeningBlncArry = document.getElementById("tdOpeningBalnc" + intLedgerId).innerHTML.split(" ");
            var tdOpeningBlnc = tdOpeningBlncArry[0];
            //EVM-0027 Aug 26 END

            if (tdOpeningBlnc == "") {
                tdOpeningBlnc = "0";
            }

            tdOpeningBlnc = tdOpeningBlnc.replace(/\,/g, '');
            if (tdOpeningBlncArry[1] == "CR") {
                tdOpeningBlnc = -tdOpeningBlnc;
            }
            var TotalOpeningBal = parseFloat(tdOpeningBlnc);
            var TotalOpeningBal1 = parseFloat(tdOpeningBlnc);
            AmountChecking("txtOpeningBalnc" + intLedgerId);

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
            //if ((parseFloat(TotalOpeningBal1) >= parseFloat(OpeningBal)) && (parseFloat(SaleAmt) >= parseFloat(OpeningBal))) {
            //    document.getElementById("SpanOpeningBalance" + intLedgerId).innerHTML = TotalOpeningBal - OpeningBal + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            //}

            //else {
            //    document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the opening balance amount";
            //    $("div.war").fadeIn(200).delay(500).fadeOut(400);
            //    document.getElementById("txtOpeningBalnc" + intLedgerId).style.borderColor = "Red";

            //    document.getElementById("txtOpeningBalnc" + intLedgerId).value = "";
            //    document.getElementById("txtOpeningBalnc" + intLedgerId).focus();
            //    return false;
            //}

            document.getElementById("SpanOpeningBalance" + intLedgerId).innerHTML = TotalOpeningBal + OpeningBal + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            //evm 0044
            setData("lblOpBalance", txtOpeningBlnc);
            loadSettleAmount(-1);

        }

        function CCGrp2Duplication(x, xy) {
            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
            for (var i = 0; i < addRowtable.rows.length; i++) {
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
                            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "";
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);


                            $noCon(window).scrollTop(0);
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
        function CCDuplication(x, xy) {
            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
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
                        document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Cost centres should not be duplicated for cost groups";
                        document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "";
                        document.getElementById("lblErrMsgCancelReasonCostCenter" + x).style.display = "block";
                        $("div.war").fadeIn(200).delay(500).fadeOut(400);


                        $noCon(window).scrollTop(0);
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
        var varRowidx = "";
        var varRowidy = "";
        //evm-0043 start 20-03
        function ddlLedOnchange(x, mode) {
            var Purchase_ret = true;
            var TxtCstctrAmount = "";
            TxtCstctrAmount = document.getElementById("txtAmntVal" + x).value;
            TxtCstctrAmount = TxtCstctrAmount.trim();
            TxtCstctrAmount = TxtCstctrAmount.replace(/,/g, "");
            document.getElementById("TxtAmount_" + x).style.borderColor = "";
            $("#divLedger" + x + "> input").css("borderColor", "");
            if ((document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) && TxtCstctrAmount != "") {
                Purchase_ret = true;
                TxtCstctrAmount = parseFloat(TxtCstctrAmount);
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                if (FloatingValue != "") {
                    TxtCstctrAmount = TxtCstctrAmount.toFixed(FloatingValue);
                }
                addCommasSummry(TxtCstctrAmount);
                document.getElementById("LedgerAmtInModalPurchse").innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;

                if (document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value != "") {
                    document.getElementById("LedgerAmtInModalPurchse").innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + "  " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                }
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
            if (Purchase_ret == true) {
                if (LedgerDuplication(x) == true) {
                    varRowidx = x;
                    if (document.getElementById("ddlRecptLedger" + x).value != "") {
                        var corpid = '<%= Session["CORPOFFICEID"] %>';
                        var orgid = '<%= Session["ORGID"] %>';
                        var userid = '<%= Session["USERID"] %>';
                        var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                        var CrncyAbrv = document.getElementById("cphMain_HiddenCurrencyAbrv").value;
                        var paymentID = "";
                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                        if (document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value != "")
                            paymentID = document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value;

                        //EVM-0043 start
                        var expenseID = "";
                        if (document.getElementById("<%=HiddenFieldExpncId.ClientID%>").value != "")
                            expenseID = document.getElementById("<%=HiddenFieldExpncId.ClientID%>").value;
                        //end
                       // alert(expenseID);
                        var View = document.getElementById("<%=HiddenView.ClientID%>").value;
                        document.getElementById("ddlLedId" + x).value = LedgerId;

                        var LedgerDtlId = document.getElementById("tdDtlIdGrp" + x).value;
                        var OpBalance = 0;
                        var first = "";
                        var Amount = "";
                        $noCon.ajax({
                            type: "POST",
                            async: false,
                            url: "fms_Payment_Account.aspx/LoadSalesForLedger",
                            data: '{intLedgerId:"' + LedgerId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" ,mode:"' + mode + '",x:"' + x + '",strCrncyAbrv:"' + CrncyAbrv + '",paymentID:"' + paymentID + '",View:"' + View + '",LedgerDtlId:"' + LedgerDtlId + '",expenceID:"' + expenseID + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                document.getElementById("tdOpenSts" + x).value = response.d[6];
                                var LedgerId = document.getElementById("ddlRecptLedger" + varRowidx).value;
                               
                                document.getElementById("<%=HiddenOBstatus.ClientID%>").value = response.d[6];
                        
                                if (response.d[0] != "") {

                                    document.getElementById("DivPopUpSales").innerHTML = response.d[0];
                                    document.getElementById("btnImportSales").style.display = "";
                                    document.getElementById("BtnPopup").click();
                                    document.getElementById("ModelHeading").innerHTML = "<i class=\"fa fa-line-chart\"></i> Purchase/Expense/Credit Note Settlement  " + " <span class=\"spn_mod\">" + response.d[3] + "</span>";
                                    
                                    var addRowtable = document.getElementById("TableAddQstn");
                                    var j = 1;
                                    var LedgerId = document.getElementById("ddlRecptLedger" + varRowidx).value;
                                    if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                                        j++;

                                        if (document.getElementById("tdLedgrPaid" + x).value != "") {
                                            var txtOBAmt = document.getElementById("tdLedgrPaid" + x).value;
                                            var amt = txtOBAmt.split("#");
                                            if (amt[0] > 0) {
                                                document.getElementById("txtOpeningBalnc" + x).value = amt[0];
                                                document.getElementById("lblOpBalance").innerText = amt[0];
                                                OpBalance = amt[0];
                                            }
                                            else {
                                                //evm 0044
                                                document.getElementById("txtOpeningBalnc" + x).value = "";
                                                document.getElementById("lblOpBalance").innerText =0;
                                                OpBalance = 0;
                                            }
                                        }
                                        else {
                                            OpBalance = 0;//evm 0044
                                        }

                                        //evm-0020
                                        document.getElementById("tdOpeningBalnc" + x).innerHTML = document.getElementById("tdDupOBAmnt" + x).innerHTML;
                                        var OBPaid = DuplicateOBSettlementChange(x);
                                        var OBBalAmnt = parseFloat(document.getElementById("tdOpeningBalnc" + x).innerHTML) + parseFloat(OBPaid);
                                        document.getElementById("tdOpeningBalnc" + x).innerHTML = OBBalAmnt;
                                        AmountCheckingLabel("tdOpeningBalnc" + x);
                                        if (OBBalAmnt < 0)
                                            OBBalAmnt = -1 * OBBalAmnt;
                                        document.getElementById("tdOpeningBalnc" + x).innerHTML = OBBalAmnt + " " + response.d[7];//EVM-0027 AUG26

                                    }
                                    else {
                                        OpBalance = 0;//evm 0044
                                    }

                                    if (document.getElementById("tdPurchaseDtls" + x).value != "") {
                                        var CstCntrDtl = document.getElementById("tdPurchaseDtls" + x).value;
                                        var splitrow = CstCntrDtl.split("$");
                                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                                            var splitEach = splitrow[Cst].split("%");


                                            for (var i = j; i < addRowtable.rows.length; i++) {

                                                var P_Id = (addRowtable.rows[i].cells[0].innerHTML);

                                                var PrchsAmnt = 0;
                                                if (document.getElementById("tdSaleID" + P_Id).innerHTML == splitEach[0]) {
                                                    if (FloatingValue != "")
                                                        Amount = parseFloat(splitEach[1]).toFixed(FloatingValue);
                                                    if (parseFloat(Amount) > 0) {
                                                        document.getElementById("txtPurchaseAmt" + P_Id).value = splitEach[1];
                                                    }

                                                    if (splitEach[3] == "1") {
                                                        document.getElementById("DebitNoteSettle_Status" + P_Id).checked = true;
                                                        $('#ddlDebitNote' + P_Id).val(splitEach[4]);
                                                        ShowDebitNoteBalance(P_Id);
                                                        document.getElementById("txtDebitNotetxtAmt" + P_Id).value = splitEach[5];
                                                        AmountCalculation(P_Id);
                                                        document.getElementById("tdDebitAmnt" + P_Id).innerHTML = splitEach[6];
                                                        document.getElementById("ddlDebitNote" + P_Id).disabled = false;;
                                                        document.getElementById("txtDebitNotetxtAmt" + P_Id).disabled = false;
                                                    }
                                                    else
                                                        document.getElementById("DebitNoteSettle_Status" + P_Id).checked = false;
                                                }

                                                //evm-0020
                                                if (document.getElementById("txtPurchaseAmt" + P_Id).value != "") {
                                                    PrchsAmnt = document.getElementById("txtPurchaseAmt" + P_Id).value; 0
                                                }
                                                document.getElementById("tdAmnt" + P_Id).innerHTML = document.getElementById("tdDupAmnt" + P_Id).innerHTML;
                                                var MaxAmt = DuplicateSettlementChange(P_Id, x);
                                                var BalAmnt = parseFloat(document.getElementById("tdAmnt" + P_Id).innerHTML) - parseFloat(MaxAmt) //- parseFloat(PrchsAmnt);
                                                document.getElementById("tdAmnt" + P_Id).innerHTML = BalAmnt;
                                                AmountCheckingLabel("tdAmnt" + P_Id);

                                            }

                                        }
                                       
                                    }

                                    if (OpBalance > 0) {
                                        loadSettleAmount(-1);
                                    }
                                    else {
                                        loadSettleAmount(P_Id); //evm 0044 07/02
                                    }
                                   
                                    if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                                        $("#TableAddQstn").find("input,select").attr("disabled", "disabled");
                                        document.getElementById("btnImportSales").disabled = true;
                                    }
                                }
                                if (response.d[1] != "") {
                                    addCommasSummry(response.d[1]);

                                    if (document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value != "") {
                                        document.getElementById("lblCurrency").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                                        document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                                    }
                                    else {
                                        document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;

                                    }
                                    if (response.d[2] == "CR")
                                        document.getElementById("AccntBalance_" + x).className = "input-group-addon cur2 c1h";
                                    else if (response.d[2] == "DR")
                                        document.getElementById("AccntBalance_" + x).className = "input-group-addon cur2 dr1";
                                }
                                else {
                                    document.getElementById("AccntBalance_" + x).innerHTML = "";
                                }
                                if (response.d[4] != "") {
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
                        //evm-0043 ens 20-03

                        //evm-0043 start
                        //$noCon.ajax({
                        //    type: "POST",
                        //    async: false,
                        //    url: "fms_Payment_Account.aspx/LoadExpenceForLedger",
                        //    data: '{intLedgerId:"' + LedgerId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" ,mode:"' + mode + '",x:"' + x + '",strCrncyAbrv:"' + CrncyAbrv + '",paymentID:"' + paymentID + '",View:"' + View + '",LedgerDtlId:"' + LedgerDtlId + '",expenceID:"' + expenseID + '"}',
                        //    contentType: "application/json; charset=utf-8",
                        //    dataType: "json",
                        //    success: function (response) {
                                //document.getElementById("tdOpenSts" + x).value = response.d[6];
                                //var LedgerId = document.getElementById("ddlRecptLedger" + varRowidx).value;

                                //document.getElementById("<%=HiddenOBstatus.ClientID%>").value = response.d[6];

                                //if (response.d[0] != "") {


                                //    document.getElementById("TableExpense").innerHTML = response.d[0];
                                //    document.getElementById("btnImportSales").style.display = "";
                                //    //document.getElementById("BtnPopup").click();
                                //    document.getElementById("ModelHeading").innerHTML = "Purchase/Expense/Credit Note Settlement " + response.d[3];

                                //    var addRowExpense = document.getElementById("TableExpense");
                                //    var j = 1;
                                //    var LedgerId = document.getElementById("ddlRecptLedger" + varRowidx).value;

                                //    var E_Id = 0;
                                    //alert(document.getElementById("tdExpenseDtls" + x).value);

                                    //if (document.getElementById("tdExpenseDtls" + x).value != "") {
                                    //    var CstCntrDtl = document.getElementById("tdExpenseDtls" + x).value;
                                    //    var splitrow = CstCntrDtl.split("$");
                                    //    for (var Cst = 0; Cst < splitrow.length; Cst++) {
                                    //        var splitEach = splitrow[Cst].split("%");


                                    //        for (var i = 0; i < addRowExpense.rows.length; i++) {

                                    //            E_Id = (addRowExpense.rows[i].cells[0].innerHTML);

                                                // alert(E_Id);

                                                //var PrchsAmnt = 0;
                                                //if (document.getElementById("tdExpenseID" + E_Id).innerHTML == splitEach[0]) {
                                                //    if (FloatingValue != "")
                                                //        Amount = parseFloat(splitEach[1]).toFixed(FloatingValue);
                                                //    if (parseFloat(Amount) > 0) {
                                                //        document.getElementById("txtExpenseAmt" + E_Id).value = splitEach[1];
                                                //    }

                                                //}

                                                //evm-0020
                                    //            if (document.getElementById("txtExpenseAmt" + E_Id).value != "") {
                                    //                PrchsAmnt = document.getElementById("txtExpenseAmt" + E_Id).value; 0
                                    //            }

                                    //        }

                                    //    }

                                    //}

                                    //loadSettleAmount(E_Id); //evm 0044 07/02

                                   // if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                                    //    $("#TableExpense").find("input,select").attr("disabled", "disabled");
                                    //    document.getElementById("btnImportSales").disabled = true;

                                    //}
                                    //if (response.d[1] != "") {
                                    //    addCommasSummry(response.d[1]);

                                       // if (document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value != "") {
                                       //     document.getElementById("lblCurrency").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                                       //     document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                                       // }
                                       // else {
                                           // document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;

                                    //    }
                                    //    if (response.d[2] == "CR")
                                    //        document.getElementById("AccntBalance_" + x).className = "input-group-addon cur2 c1h";
                                    //    else if (response.d[2] == "DR")
                                    //        document.getElementById("AccntBalance_" + x).className = "input-group-addon cur2 dr1";
                                    //}
                                    //else {
                                    //    document.getElementById("AccntBalance_" + x).innerHTML = "";
                                    //}
                                    //if (response.d[4] != "") {
                        //            }
                        //            if (response.d[5] != "") {
                        //                if (response.d[5] == "0" || response.d[5] == "1") {
                        //                    document.getElementById('ChkCostCenter' + x).style.pointerEvents = 'none';
                        //                    document.getElementById('ChkCostCenter' + x).style.opacity = "0.5";
                        //                }
                        //                else {
                        //                    document.getElementById('ChkCostCenter' + x).style.pointerEvents = 'auto';
                        //                    document.getElementById('ChkCostCenter' + x).style.opacity = "1";
                        //                }
                        //            }
                        //        }
                        //    },
                        //    failure: function (response) {
                        //    }
                        //});
                        //end



                        if (document.getElementById("tdOpenSts" + x).value == "1") {
                            //document.getElementById("txtOpeningBalnc").focus();
                        }
                        else {
                         
                            $('#TableAddQstn td:first').each(function () {
                                var varId = $(this).text();
                              
                             //   setTimeout(function () { focusPurchase(varId, x); }, 1000);
                            });

                            //idlast = P_Id;
                            //setTimeout(function () { focusSale(idlast); }, 1000);
                        }

                        //$('#TableAddQstn td:first-child').each(function () {
                        //    var varId = $(this).text();
                        //    focusPurchase(varId);
                        //});
                    }
                    if (document.getElementById("ddlRecptLedger" + x).value == "") {
                        document.getElementById("ddlLedId" + x).value = 0;
                    }

                }
            }
           
            return false;
        }


        function focusPurchase(Rowid, x) {
            $('#myModal').on('shown.bs.modal', function () {

                //if (document.getElementById("tdOpenSts" + x).value == 0) {
                //    document.getElementById("txtPurchaseAmt" + Rowid).focus();
                //}
                //else {
                //    document.getElementById("txtOpeningBalnc" + Rowid).focus();
                //}

            });
        }

        var $noconfli = jQuery.noConflict();

        function AmountChecking(textboxid) {
           // alert(textboxid);
            var txtPerVal = document.getElementById(textboxid).value;
           // alert(txtPerVal);
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
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);
                    }
                    document.getElementById('' + textboxid + '').value = n;
                }
            }
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

        function CheckSumOfLedger(textboxid, x) {
        
         
            var ret = true;
            var CstTotal = 0;
          
            if(textboxid!="") 
            {
                AmountChecking(textboxid);
            }
            
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var LedgerTotal = 0;
        
            var addRowtable1 = document.getElementById("tableGrp");
            for (var i = 1; i < addRowtable1.rows.length; i++) {
               
                var row = addRowtable1.rows[i];
               
                var x = (addRowtable1.rows[i].cells[0].innerHTML);
               
                if (document.getElementById("txtAmntVal" + x).value != "") {
                    var AddButton = $noconfli("#TxtAmount_" + i);
                    if (AddButton.length) {
                        var amtwitoutDecimal = document.getElementById("txtAmntVal" + x).value;
                        var amtwitoutDecimal11 = document.getElementById("txtAmntVal" + i).value;
                        amtwitoutDecimal = amtwitoutDecimal.replace(/\,/g, '');
                        amtwitoutDecimal = parseFloat(amtwitoutDecimal);

                        amtwitoutDecimal11 = amtwitoutDecimal11.replace(/\,/g, '');
                        amtwitoutDecimal11 = parseFloat(amtwitoutDecimal11);

                        LedgerTotal = parseFloat(LedgerTotal) + amtwitoutDecimal11;
                        document.getElementById("TxtAmount_" + x).value = amtwitoutDecimal.toFixed(FloatingValue);
                        document.getElementById("txtAmntVal" + x).value = amtwitoutDecimal.toFixed(FloatingValue);
                        
                        addCommas("TxtAmount_" + x);
                    }
                }
              
                document.getElementById("TxtAmount_" + x).style.borderColor = "";
                var CstCntrId = "";
                var SalesId = "";
                var CostCntrAmt = "";
                var PrchsAmt = "";
                var LdAmt = document.getElementById("txtAmntVal" + x).value;
                if (LdAmt == "") {
                    LdAmt = "0";
                }
                LdAmt = LdAmt.replace(/\,/g, '');
                var PrchaseTTl = "0";
              
                if (document.getElementById("tdPurchaseDtls" + x).value != null && document.getElementById("tdPurchaseDtls" + x).value != "" && document.getElementById("tdPurchaseDtls" + x).value != "null") {
                    var PurchaseInfo = document.getElementById("tdPurchaseDtls" + x).value;
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
                   
                    PrchaseTTl = parseFloat(PrchaseTTl).toFixed(FloatingValue);
                   
                    if (parseFloat(PrchaseTTl) > parseFloat(LdAmt)) {
                        document.getElementById("TxtAmount_" + x).style.borderColor = "red";


                        $noCon("#divWarning").html("Ledger amount should be greater than or equal to purchase amount. ");
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

            for (var i = 1; i < addRowtable.rows.length; i++) {
                var row = addRowtable.rows[i];
                var x = (addRowtable.rows[i].cells[0].innerHTML);
                if (document.getElementById("txtAmntVal" + x).value != "") {
                    var ldgramt = document.getElementById("txtAmntVal" + x).value;
                    ldgramt = ldgramt.replace(/\,/g, '');
                    LedgerTtl = parseFloat(LedgerTtl) + +parseFloat(ldgramt);
                    if (FloatingValue != "") {
                        ldgramt = parseFloat(ldgramt);
                        ldgramt = ldgramt.toFixed(FloatingValue);
                    }
                    document.getElementById("TxtAmount_" + x).value = ldgramt;
                    document.getElementById("txtAmntVal" + x).value = ldgramt;
                    addCommas("TxtAmount_" + x);
                }
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
                ForexTl = ForexTl.toFixed(FloatingValue);
            }
            document.getElementById("cphMain_txtGrantTotal").value = LedgerTtl;
            document.getElementById("cphMain_txtForexTotal").value = ForexTl;
            addCommas("cphMain_txtForexTotal");
            addCommas("cphMain_txtGrantTotal");
   
            return ret;
        }

        function CheckSumOfCstCntr(textboxid, x, y) {

            if (document.getElementById(textboxid).value != "" && document.getElementById(textboxid).value != "0") {

            var CstTotal = 0;
            var LedgerTotal = 0;
            AmountChecking(textboxid);
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            $('#TableAddQstnCostCenter' + x + ' td:first-child').each(function () {
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
                if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                    cstamt = document.getElementById("TxtCstctrAmount_" + varId).value;
                    cstamt = cstamt.replace(/\,/g, '');
                    if (FloatingValue != "") {
                        cstamt = parseFloat(cstamt);
                        cstamt = cstamt.toFixed(FloatingValue);
                    }
                    document.getElementById("TxtCstctrAmount_" + varId).value = cstamt;
                    CstTotal = parseFloat(CstTotal) + parseFloat(cstamt);
                    addCommas("TxtCstctrAmount_" + varId);
                    if (document.getElementById("txtAmntVal" + x).value != "") {
                        var ledramt = document.getElementById("txtAmntVal" + x).value;
                        ledramt = ledramt.replace(/\,/g, '');
                        if (FloatingValue != "") {
                            ledramt = parseFloat(ledramt);
                            ledramt = ledramt.toFixed(FloatingValue);
                        }
                        LedgerTotal = parseFloat(LedgerTotal) + +parseFloat(ledramt);
                        addCommas("TxtAmount_" + x);
                    }
                }
            });
            var LedgerTtl = 0;
            var addRowtable = document.getElementById("tableGrp");
            for (var i = 1; i < addRowtable.rows.length; i++) {
                var row = addRowtable.rows[i];
                var x = (addRowtable.rows[i].cells[0].innerHTML);
                if (document.getElementById("txtAmntVal" + x).value != "") {
                    var ldgramt = document.getElementById("txtAmntVal" + x).value;
                    ldgramt = ldgramt.replace(/\,/g, '');
                    LedgerTtl = parseFloat(LedgerTtl) + +parseFloat(ldgramt);
                    if (FloatingValue != "") {
                        ldgramt = parseFloat(ldgramt);
                        ldgramt = ldgramt.toFixed(FloatingValue);
                    }
                    document.getElementById("TxtAmount_" + x).value = ldgramt;
                    document.getElementById("txtAmntVal" + x).value = ldgramt;
                    addCommas("TxtAmount_" + x);
                }
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
                ForexTl = ForexTl.toFixed(FloatingValue);
            }
            document.getElementById("cphMain_txtGrantTotal").value = LedgerTtl;
            document.getElementById("cphMain_txtForexTotal").value = ForexTl;
            addCommas("cphMain_txtForexTotal");
            addCommas("cphMain_txtGrantTotal");
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
            $('#TableAddQstnCostCenter_' + x + ' td:first-child').each(function () {
                varId = $(this).text();
                document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
                var Costcenterval = $("#ddlRecptCosCtr_" + varId).val();
                if (document.getElementById("divCostCenter" + varId).style.display != "none") {
                    $("#divCostCenter" + varId + "> input").css("borderColor", "");

                    if (Costcenterval == 0 && document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                        //document.getElementById("ddlRecptCosCtr_" + varId).style.borderColor = "Red";
                        //document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                        //ret = false;
                    }
                    else {

                        if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                            var costamt = document.getElementById("TxtCstctrAmount_" + varId).value;
                            costamt = costamt.replace(/\,/g, '');
                            CstTotal = parseFloat(CstTotal) + parseFloat(costamt);
                            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                            if (FloatingValue != "") {
                                CstTotal = CstTotal.toFixed(FloatingValue);
                            }
                        }
                        if (document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                            document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                            ret = false;
                            if (varfocus == "") {
                                varfocus = varId;

                            }
                        }
                        if (Costcenterval == 0) {
                            document.getElementById("divCostCenter" + varId).style.borderColor = "Red";
                            ret = false;
                            if (varfocus == "") {
                                varfocus = varId;

                            }
                        }
                    }
                }
                else {
                    if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                        var costamt = document.getElementById("TxtCstctrAmount_" + varId).value;
                        costamt = costamt.replace(/\,/g, '');
                        CstTotal = parseFloat(CstTotal) + parseFloat(costamt);
                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                        if (FloatingValue != "") {
                            CstTotal = CstTotal.toFixed(FloatingValue);
                        }
                    }
                }

            });
            var LedgerTotal = 0;

            var ldgrAmt = document.getElementById("txtAmntVal" + x).value;
            ldgrAmt = ldgrAmt.replace(/\,/g, '');
            if (document.getElementById("txtAmntVal" + x).value != "" && ldgrAmt > 0) {
                var ldgramt = document.getElementById("txtAmntVal" + x).value;
                ldgramt = ldgramt.replace(/\,/g, '');
                LedgerTotal = parseFloat(ldgramt);
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                if (FloatingValue != "") {
                    LedgerTotal = LedgerTotal.toFixed(FloatingValue);
                }
            }
            else {
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
                if (document.getElementById("divCostCenter" + varfocus).style.display != "none") {
                    var CostFocrval = $("#ddlRecptCosCtr_" + varId).val();

                    if (CostFocrval == 0) {
                        $("#divCostCenter" + varId + "> input").focus();
                        $("#divCostCenter" + varId + "> input").css("borderColor", "red");
                    }
                }

            }
            if (CstTotal != 0) {
                if (LedgerTotal != CstTotal) {
                    document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                    $noCon("#divWarning").html("Ledger and cost centre amount should be equal.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    $noCon(window).scrollTop(0);
                    ret = false;
                }
            }

            if (document.getElementById("ddlRecptLedger" + x).value == 0) {
                $("#divLedger" + x + "> input").css("borderColor", "red");
                $("#divLedger" + x + "> input").focus();
                $("#divLedger" + x + "> input").select();
                ret = false;
            }
            //alert(ret);

            return ret;
        }

        function FuctionAddGroup(Ledx) {
            IncrmntConfrmCounter();
            var addRowtableGrp;
            var addRowResultGrp = true;
            $("#divLedger" + Ledx + "> input").css("borderColor", "");
            var check = document.getElementById("tdInxGrp" + Ledx).value;
           
            if (check == "") {
                addRowtableGrp = document.getElementById("TableAddQstnCostCenter_" + Ledx);
              
                if (CheckAndHighlightLedCostCenter(Ledx) == false) {
                    addRowResultGrp = false;
                }

                if (CheckSumOfLedger('TxtAmount_' + Ledx, Ledx) == false) {
                    addRowResultGrp = false;
                }
                if (LedgerDuplication(Ledx) == false) {
                    addRowResultGrp = false;
                }

                //var groupname = document.getElementById("TxtAmount_" + Ledx).value;
                //if (groupname == "") {
                //    document.getElementById("TxtAmount_" + Ledx).style.borderColor = "Red";
                //}
                var TxtCstctrAmount = "";
                TxtCstctrAmount = document.getElementById("txtAmntVal" + Ledx).value;
                TxtCstctrAmount = TxtCstctrAmount.trim();

                TxtCstctrAmount = TxtCstctrAmount.replace(/,/g, "");

                if (TxtCstctrAmount == "" || TxtCstctrAmount <= 0) {
                    addRowResultGrp = false;
                    document.getElementById("TxtAmount_" + Ledx).style.borderColor = "red";
                }
                if (addRowResultGrp == false) {
                    return false;
                }
                else {

                    document.getElementById("tdInxGrp" + Ledx).value = Ledx;
                    document.getElementById("journalADD" + Ledx).style.opacity = "0.3";
                    AddNewGroup(null);
                    return false;
                }
            }
            return false;
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
                    addRowtable = document.getElementById("TableAddQstnCostCenter_" + x);
                    if (CheckAndHighlightCostCenter(x) == false) {
                        addRowResult = false;
                    }
                }
                if (addRowResult == false) {
                    return false;
                }
                else {
                    document.getElementById("tdInxQstn" + x + '' + y).value = x + '' + y;
                    document.getElementById("btnCostCenter_" + x + '' + y).style.opacity = "0.3";
                    CheckSubmitZero();
                    FunctionQustn(x, y, null, null, null);
                    return false;
                }
            }
            return false;
        }

        function FillddlRcptLedger(rowCount, LDGR_ID) {
            var ddlTestDropDownListXML = "";
            ddlTestDropDownListXML = $noCon("#ddlRecptLedger" + rowCount);
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
                    // $au("#ddlRecptLedger" + rowCount).selectToAutocomplete1Letter();

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
                if (LDGR_ID != "" && LDGR_ID != null) {
                    var arrayProduct = JSON.parse("[" + LDGR_ID + "]");
                    $noCon("#ddlRecptLedger" + rowCount).val(arrayProduct);
                    //$au("#ddlRecptLedger" + rowCount).selectToAutocomplete1Letter();
                }
            }
            else {
                var OptionStart = $noCon("<option>--SELECT--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
            }
        }

        function FillddlAcntGrp1(rowCountX, rowCountY, COSTCNTR_ID) {
            var ddlTestDropDownListXML1 = "";
            ddlTestDropDownListXML1 = $noCon("#ddlRecptCosGrp1_" + rowCountX + "" + rowCountY);
            var intOrgID = '<%= Session["ORGID"] %>';
            var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
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
                var OptionStart = $noCon("<option>--SELECT--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML1.append(OptionStart);
            }
            if (COSTCNTR_ID != "" && COSTCNTR_ID != null && COSTCNTR_ID != 0 && COSTCNTR_ID != "null") {
                var arraycostcntr_VALUES = JSON.parse("[" + COSTCNTR_ID + "]");
                $noCon("#ddlRecptCosGrp1_" + rowCountX + "" + rowCountY).val(arraycostcntr_VALUES);
            }
        }
        function FillddlAcntGrp2(rowCountX, rowCountY, COSTCNTR_ID) {

            var ddlTestDropDownListXML1 = "";
            ddlTestDropDownListXML1 = $noCon("#ddlRecptCosGrp2_" + rowCountX + "" + rowCountY);
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
                var OptionStart = $noCon("<option>--SELECT--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML1.append(OptionStart);
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


        function AmountCalculation(PurchaseId) {
            //alert("");
            var ret = true;
            var DebitFlag = true;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            AmountChecking("txtPurchaseAmt" + PurchaseId);
            AmountChecking("txtDebitNotetxtAmt" + PurchaseId);
            var tdAmnt = document.getElementById("tdAmnt" + PurchaseId).innerHTML;
            var tdLedgerRow = document.getElementById("tdLedgerRow" + PurchaseId).innerHTML;
           // alert(tdLedgerRow);
            //evm-0043 start 20-03
            var tdStatus = document.getElementById("tdStatus" + PurchaseId).innerHTML;
            //alert(tdStatus);
            //end
            tdAmnt = tdAmnt.replace(/\,/g, '');
            var purchaseAmt = document.getElementById("txtPurchaseAmt" + PurchaseId).value;
            var DebitAmt = document.getElementById("txtDebitNotetxtAmt" + PurchaseId).value;

            var tdDebitBalanceAmt = document.getElementById("tdDebitBalanceAmt" + PurchaseId).innerHTML;

            DebitAmt = DebitAmt.replace(/\,/g, '');
            purchaseAmt = purchaseAmt.replace(/\,/g, '');
            document.getElementById("txtPurchaseAmt" + PurchaseId).style.borderColor = "";
            document.getElementById("txtDebitNotetxtAmt" + PurchaseId).style.borderColor = "";
            var PymntPurchsDiif = 0;
            var DbtPurchsDiif = 0;

            if (tdDebitBalanceAmt != "" && tdDebitBalanceAmt != "0" && DebitAmt != "") {
                if (parseFloat(DebitAmt) > parseFloat(tdDebitBalanceAmt)) {
                    document.getElementById("txtDebitNotetxtAmt" + PurchaseId).style.borderColor = "red";
                    document.getElementById("txtDebitNotetxtAmt" + PurchaseId).focus();
                    DebitFlag = false;
                    ret = false;
                }
            }
            if (tdDebitBalanceAmt == "" && DebitAmt != "" && (document.getElementById("ddlDebitNote" + PurchaseId).value == "-Select Debit Note-" || document.getElementById("ddlDebitNote" + PurchaseId).value == "0")) {
                document.getElementById("txtDebitNotetxtAmt" + PurchaseId).style.borderColor = "red";
                document.getElementById("txtDebitNotetxtAmt" + PurchaseId).focus();
                ret = false;
            }
            if (tdAmnt != "" && purchaseAmt != "") {
                PymntPurchsDiif = parseFloat(tdAmnt) - parseFloat(purchaseAmt);
                PymntPurchsDiif = PymntPurchsDiif.toFixed(FloatingValue);

                addCommasSummry(PymntPurchsDiif);
                document.getElementById("AccntBalancePrchs" + PurchaseId).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
            }
            else {
                document.getElementById("AccntBalancePrchs" + PurchaseId).innerHTML = "";
            }
            if (parseFloat(tdAmnt) != "" && parseFloat(DebitAmt) != "") {
                DbtPurchsDiif = parseFloat(tdAmnt) - parseFloat(DebitAmt);
                DbtPurchsDiif = DbtPurchsDiif.toFixed(FloatingValue);
                document.getElementById("tdDebitAmnt" + PurchaseId).innerHTML = DbtPurchsDiif;
                addCommasSummry(DbtPurchsDiif);
                if (document.getElementById("tdDebitBalanceAmt" + PurchaseId).innerHTML != "" && document.getElementById("ddlDebitNote" + PurchaseId).value != "0") {
                    document.getElementById("AccntBalanceDebitNote" + PurchaseId).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                }
                else {
                    document.getElementById("AccntBalanceDebitNote" + PurchaseId).innerHTML = "";
                }
            }
            else {
                document.getElementById("AccntBalanceDebitNote" + PurchaseId).innerHTML = "";
            }
            if (parseFloat(purchaseAmt) > parseFloat(tdAmnt)) {
                document.getElementById("txtPurchaseAmt" + PurchaseId).style.borderColor = "red";
                document.getElementById("txtPurchaseAmt" + PurchaseId).focus();
                ret = false;
            }
            if (document.getElementById("DebitNoteSettle_Status" + PurchaseId).checked == true) {
                if (document.getElementById("txtDebitNotetxtAmt" + PurchaseId).value == "") {
                    document.getElementById("txtDebitNotetxtAmt" + PurchaseId).style.borderColor = "red";
                    document.getElementById("txtDebitNotetxtAmt" + PurchaseId).focus();
                    ret = false;
                }
                if (document.getElementById("ddlDebitNote" + PurchaseId).value == "0") {
                    document.getElementById("ddlDebitNote" + PurchaseId).style.borderColor = "red";
                    document.getElementById("ddlDebitNote" + PurchaseId).focus();
                    ret = false;
                }
                if (parseFloat(DebitAmt) > parseFloat(tdAmnt)) {
                    document.getElementById("txtDebitNotetxtAmt" + PurchaseId).style.borderColor = "red";
                    document.getElementById("txtDebitNotetxtAmt" + PurchaseId).focus();
                    ret = false;
                }
                var DbtPurchsSum = parseFloat(DebitAmt) + parseFloat(purchaseAmt)
                if (parseFloat(DbtPurchsSum) > parseFloat(tdAmnt)) {
                    document.getElementById("txtPurchaseAmt" + PurchaseId).style.borderColor = "red";
                    document.getElementById("txtDebitNotetxtAmt" + PurchaseId).style.borderColor = "red";
                    document.getElementById("txtPurchaseAmt" + PurchaseId).focus();
                    ret = false;
                }
                var addRowtable = document.getElementById("TableAddQstn");
                var DebitTotalAmt = 0;
                var j = 1;
                if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                    j++;
                    //EVM-0027 Aug09
                    if (addRowtable.rows.length == 2) {

                        //tableGrp
                        var LedgerId = document.getElementById("ddlRecptLedger" + varRowidx).value;

                        if (document.getElementById("tdOpenSts" + varRowidx).value == 1) {

                            if (document.getElementById("txtOpeningBalnc" + varRowidx).value != "") {
                                var arry = document.getElementById("SpanOpeningBalance" + varRowidx).innerHTML.split(" ");

                                var OpeningBal = document.getElementById("tdOpeningBalnc" + varRowidx).innerHTML;
                                var txtob = document.getElementById("txtOpeningBalnc" + varRowidx).value;
                               
                                OpeningBal = parseFloat(OpeningBal) + parseFloat(txtob);    //EVM-0027 Aug26
                                var amt = document.getElementById("txtOpeningBalnc" + varRowidx).value + "#" + parseFloat(OpeningBal);

                                document.getElementById("tdLedgrPaid" + varRowidx).value = amt;
                            }
                        }
                    }
                    //END
                }
             
                for (var i = j; i < addRowtable.rows.length; i++) {
                    var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
                    var DebitNoteIdEach = document.getElementById("ddlDebitNote" + P_Id).value;
                    var DebitNoteIdRow = document.getElementById("ddlDebitNote" + PurchaseId).value;
                    if (DebitNoteIdEach == DebitNoteIdRow) {
                        var DebitNoteAmtEach = 0;
                        if (document.getElementById("txtDebitNotetxtAmt" + P_Id).value != "") {
                            DebitNoteAmtEach = document.getElementById("txtDebitNotetxtAmt" + P_Id).value;
                            DebitTotalAmt = parseFloat(DebitTotalAmt) + parseFloat(DebitNoteAmtEach);
                        }
                    }
                }
                if (parseFloat(DebitTotalAmt) > parseFloat(tdDebitBalanceAmt)) {
                    document.getElementById("txtDebitNotetxtAmt" + PurchaseId).style.borderColor = "red";
                    document.getElementById("txtDebitNotetxtAmt" + PurchaseId).focus();
                    DebitFlag = false;
                    ret = false;
                }
            }
            if (DebitFlag == false) {
                document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the debit note amount";
                $("div.war").fadeIn(200).delay(500).fadeOut(400);
            }
            else if (ret == false) {
                document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the purchase amount";
                $("div.war").fadeIn(200).delay(500).fadeOut(400);
            }
            var TxtTotal = 0;
            var TotalPurchaseAmnt = 0;
            var TotalAmnt = 0;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

            if (ret == true && DebitFlag == true) {
                var addRowtable = document.getElementById("TableAddQstn");
                var j = 1;
                if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                    j++;
                    //EVM-0027 Aug09
                    if (addRowtable.rows.length == 2) {

                        //tableGrp
                        var LedgerId = document.getElementById("ddlRecptLedger" + varRowidx).value;

                        if (document.getElementById("tdOpenSts" + varRowidx).value == 1) {

                            if (document.getElementById("txtOpeningBalnc" + varRowidx).value != "") {
                                var arry = document.getElementById("SpanOpeningBalance" + varRowidx).innerHTML.split(" ");

                                //EVM-0027 Aug 26
                                var OpeningBalArry = document.getElementById("tdOpeningBalnc" + varRowidx).innerHTML.split(" ");
                                var OpeningBal = OpeningBalArry[0];
                                if (OpeningBalArry[1] == "CR") {
                                    OpeningBal = -OpeningBal;
                                }
                                //EVM-0027 Aug 26 END

                                var txtob = document.getElementById("txtOpeningBalnc" + varRowidx).value;
                                OpeningBal = parseFloat(OpeningBal) +parseFloat(txtob);    //EVM-0027 Aug26
                                var amt = document.getElementById("txtOpeningBalnc" + varRowidx).value + "#" + parseFloat(OpeningBal);

                                document.getElementById("tdLedgrPaid" + varRowidx).value = amt;
                            }
                        }
                    }
                    //END
                }
               
                for (var i = j; i < addRowtable.rows.length; i++) {
                    var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
                    var tdAmnt = document.getElementById("tdAmnt" + P_Id).innerHTML;
                    // evm-0043 start
                   // var tdStatus = document.getElementById("tdStatus" + P_Id).innerHTML;
                    //end
                    var tdLedgerRow = document.getElementById("tdLedgerRow" + P_Id).innerHTML;
                    var purchaseAmt = "";
                    document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "";
                    purchaseAmt = document.getElementById("txtPurchaseAmt" + P_Id).value;
                    if (purchaseAmt != "") {
                        purchaseAmt = purchaseAmt.replace(/\,/g, '');
                        TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt) + parseFloat(purchaseAmt);
                        if (FloatingValue != "") {
                            TotalPurchaseAmnt = TotalPurchaseAmnt.toFixed(FloatingValue);
                        }
                    }
                }
              
                addCommas("txtPurchaseAmt" + PurchaseId);
                TxtTotal = document.getElementById("txtAmntVal" + tdLedgerRow).value;
                if (parseFloat(TotalPurchaseAmnt) > parseFloat(TxtTotal)) {
                    clearData();
                    if (document.getElementById("txtPurchaseAmt" + PurchaseId).value != "") {
                        addCommasSummry(TotalPurchaseAmnt);
                        document.getElementById("lblErrMsgCancelReason").innerHTML = "Purchase total amount should be less than the payment amount";
                        $("div.war").fadeIn(200).delay(500).fadeOut(400);

                        ret = false;
                    }
                }

                if (purchaseAmt == "") {
                    purchaseAmt = 0;
                }
                if (DebitAmt == "") {
                    DebitAmt = 0;
                }

            }
            loadSettleAmount(PurchaseId);//evm 0044
            return ret;
        }

        function DebitNoteSumCalculation(RowId) {
            var ret = true;
            var tdDebitBalanceAmt = document.getElementById("tdDebitBalanceAmt" + RowId).innerHTML;
            var addRowtable = document.getElementById("TableAddQstn");
            var j = 1;
            if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                j++;
                //EVM-0027 Aug09
                if (addRowtable.rows.length == 2) {

                    //tableGrp
                    var LedgerId = document.getElementById("ddlRecptLedger" + varRowidx).value;

                    if (document.getElementById("tdOpenSts" + varRowidx).value == 1) {

                        if (document.getElementById("txtOpeningBalnc" + varRowidx).value != "") {
                            var arry = document.getElementById("SpanOpeningBalance" + varRowidx).innerHTML.split(" ");

                            //EVM-0027 Aug 26
                            var OpeningBalArry = document.getElementById("tdOpeningBalnc" + varRowidx).innerHTML.split(" ");
                            var OpeningBal = OpeningBalArry[0];
                            if (OpeningBalArry[1] == "CR") {
                                OpeningBal = -OpeningBal;
                            }
                            //EVM-0027 Aug 26 END

                            var txtob = document.getElementById("txtOpeningBalnc" + varRowidx).value;
                            OpeningBal = parseFloat(OpeningBal) + parseFloat(txtob);    //EVM-0027 Aug26
                            var amt = document.getElementById("txtOpeningBalnc" + varRowidx).value + "#" + parseFloat(OpeningBal);

                            document.getElementById("tdLedgrPaid" + varRowidx).value = amt;
                        }
                    }
                }
                //END
             }
            //if (document.getElementById("txtDebitNotetxtAmt" + P_Id).value != "") {
            //    DebitTotalAmt = parseFloat(DebitTotalAmt) + parseFloat(document.getElementById("txtDebitNotetxtAmt" + P_Id).value);
            var DebitTotalAmt = 0;
            for (var i = j; i < addRowtable.rows.length; i++) {
                var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
                var DebitNoteIdEach = document.getElementById("ddlDebitNote" + P_Id).value;
                var DebitNoteIdRow = document.getElementById("ddlDebitNote" + RowId).value;
                ///  if (P_Id != RowId) {
                if (DebitNoteIdEach == DebitNoteIdRow) {
                    var DebitNoteAmtEach = 0;
                    if (document.getElementById("txtDebitNotetxtAmt" + P_Id).value != "") {
                        DebitNoteAmtEach = document.getElementById("txtDebitNotetxtAmt" + P_Id).value;
                        DebitTotalAmt = parseFloat(DebitTotalAmt) + parseFloat(DebitNoteAmtEach);
                    }
                }
                // }
            }
            if (parseFloat(DebitTotalAmt) > parseFloat(tdDebitBalanceAmt)) {
                document.getElementById("txtDebitNotetxtAmt" + RowId).style.borderColor = "red";
                document.getElementById("txtDebitNotetxtAmt" + RowId).focus();
                ret = false;
            }
            return ret;
        }
        function ButtnFillClickSales() {
            var ret = true;
            var DebitFlag = true;

            var TotalAmnt = 0;
            var TotalPurchaseAmnt = 0;
            var purchaseFlag = 0;
            var CheckCount = 0;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var TxtTotal = 0;
            var TxtTotalwithoutarr = document.getElementById("LedgerAmtInModalPurchse").innerText;
            var TxtTotalarr = TxtTotalwithoutarr.split(" ");
            if (TxtTotalarr[0] != "") {
                TxtTotal = TxtTotalarr[0];
            }
            TxtTotal = TxtTotal.replace(/\,/g, '');

            var addRowtable = document.getElementById("TableAddQstn");

            var j = 1;
            if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                j++;
                //EVM-0027 Aug09
                if (addRowtable.rows.length == 2) {

                    //tableGrp
                    var LedgerId = document.getElementById("ddlRecptLedger" + varRowidx).value;

                    if (document.getElementById("tdOpenSts" + varRowidx).value == 1) {

                        if (document.getElementById("txtOpeningBalnc" + varRowidx).value != "") {
                            var arry = document.getElementById("SpanOpeningBalance" + varRowidx).innerHTML.split(" ");
                            //EVM-0027 Aug 26
                            var OpeningBalArry = document.getElementById("tdOpeningBalnc" + varRowidx).innerHTML.split(" ");
                            var OpeningBal = OpeningBalArry[0];
                            if (OpeningBalArry[1] == "CR") {
                                OpeningBal = -OpeningBal;
                            }
                            //EVM-0027 Aug 26 END

                            var txtob = document.getElementById("txtOpeningBalnc" + varRowidx).value;
                            OpeningBal = parseFloat(OpeningBal) + parseFloat(txtob);    //EVM-0027 Aug26
                            var amt = document.getElementById("txtOpeningBalnc" + varRowidx).value + "#" + parseFloat(OpeningBal);

                            document.getElementById("tdLedgrPaid" + varRowidx).value = amt;
                        }
                    }
                }
                //END
            }

            for (var i = j; i < addRowtable.rows.length; i++) {

                var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
                var tdLedgerRow = document.getElementById("tdLedgerRow" + P_Id).innerHTML;
                //evm-0043 start 19/3
             //   var tdStatus = document.getElementById(" tdStatus" + P_Id).innerHTML;
                //alert(document.getElementById("tdDupAmnt" + P_Id).innerHTML);
                //evm-0020
                document.getElementById("tdAmnt" + P_Id).innerHTML = document.getElementById("tdDupAmnt" + P_Id).innerHTML;
                var MaxAmt = DuplicateSettlementChange(P_Id, tdLedgerRow);
                //alert(MaxAmt);
                document.getElementById("tdAmnt" + P_Id).innerHTML = parseFloat(document.getElementById("tdAmnt" + P_Id).innerHTML) - parseFloat(MaxAmt);
                AmountCheckingLabel("tdAmnt" + P_Id);


                var tdAmnt = document.getElementById("tdAmnt" + P_Id).innerHTML;
                var DebitAmt = document.getElementById("txtDebitNotetxtAmt" + P_Id).value;
                var tdDebitBalanceAmt = document.getElementById("tdDebitBalanceAmt" + P_Id).innerHTML;
                DebitAmt = DebitAmt.replace(/\,/g, '');

                if (document.getElementById("tdOpenSts" + tdLedgerRow).value == 0) {
                    if (i == 1) {
                        document.getElementById("tdPurchaseDtls" + tdLedgerRow).value = "";
                    }
                }
                else {
                    if (i < 3) {
                        document.getElementById("tdPurchaseDtls" + tdLedgerRow).value = "";
                    }
                }
                var purchaseAmt = "";
                document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "";
                document.getElementById("txtDebitNotetxtAmt" + P_Id).style.borderColor = "";
                document.getElementById("ddlDebitNote" + P_Id).style.borderColor = "";
                purchaseAmt = document.getElementById("txtPurchaseAmt" + P_Id).value;

                if (document.getElementById("tdSettld" + P_Id).value == "0") {
                    if (purchaseAmt != "") {
                        purchaseAmt = purchaseAmt.replace(/\,/g, '');
                        if (purchaseAmt <= 0) {
                            document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "red";
                            ret = false;
                        }
                        TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt) + parseFloat(purchaseAmt);
                        if (FloatingValue != "") {
                            TotalPurchaseAmnt = TotalPurchaseAmnt.toFixed(FloatingValue);
                        }
                        purchaseFlag++;
                    }
                    if (parseFloat(purchaseAmt) > parseFloat(tdAmnt)) {
                        
                        document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the purchase amount";
                        $("div.war").fadeIn(200).delay(500).fadeOut(400);

                        document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "red";
                        ret = false;
                    }
                    if (document.getElementById("DebitNoteSettle_Status" + P_Id).checked == true) {
                        var TxtDbtAmt = "";
                        TxtDbtAmt = document.getElementById("txtDebitNotetxtAmt" + P_Id).value;
                        TxtDbtAmt = TxtDbtAmt.trim();
                        TxtDbtAmt = TxtDbtAmt.replace(/,/g, "");
                        if (TxtDbtAmt == "" || TxtDbtAmt <= 0) {
                            ret = false;
                            document.getElementById("txtDebitNotetxtAmt" + P_Id).style.borderColor = "red";
                        }

                        if (tdDebitBalanceAmt != "" && tdDebitBalanceAmt != "0" && DebitAmt != "" && parseFloat(DebitAmt) <= 0) {
                            if (parseFloat(DebitAmt) > parseFloat(tdDebitBalanceAmt)) {
                                document.getElementById("txtDebitNotetxtAmt" + P_Id).style.borderColor = "red";
                                document.getElementById("txtDebitNotetxtAmt" + P_Id).focus();
                                DebitFlag = false;
                                ret = false;
                            }
                        }
                        if (tdDebitBalanceAmt == "" && DebitAmt != "" && (document.getElementById("ddlDebitNote" + P_Id).value == "-Select Debit Note-" || document.getElementById("ddlDebitNote" + P_Id).value == "0")) {
                            document.getElementById("txtDebitNotetxtAmt" + P_Id).style.borderColor = "red";
                            document.getElementById("txtDebitNotetxtAmt" + P_Id).focus();
                            ret = false;
                        }
                        if (document.getElementById("ddlDebitNote" + P_Id).value == "-Select Debit Note-" || document.getElementById("ddlDebitNote" + P_Id).value == "0") {
                            document.getElementById("ddlDebitNote" + P_Id).style.borderColor = "red";
                            document.getElementById("ddlDebitNote" + P_Id).focus();
                            document.getElementById("lblErrMsgCancelReason").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                            ret = false;
                        }
                        if (parseFloat(DebitAmt) > parseFloat(tdAmnt)) {
                            document.getElementById("txtDebitNotetxtAmt" + P_Id).style.borderColor = "red";
                            document.getElementById("txtDebitNotetxtAmt" + P_Id).focus();
                            ret = false;
                        }
                        var DbtPurchsSum = parseFloat(DebitAmt) + parseFloat(purchaseAmt)
                        if (parseFloat(DbtPurchsSum) > parseFloat(tdAmnt)) {
                            document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "red";
                            document.getElementById("txtDebitNotetxtAmt" + P_Id).style.borderColor = "red";
                            document.getElementById("txtPurchaseAmt" + P_Id).focus();
                            ret = false;
                        }
                        if (document.getElementById("txtDebitNotetxtAmt" + P_Id).value == "") {
                            document.getElementById("txtDebitNotetxtAmt" + P_Id).style.borderColor = "red";
                            document.getElementById("txtDebitNotetxtAmt" + P_Id).focus();
                            ret = false;
                        }
                        if (document.getElementById("ddlDebitNote" + P_Id).value == "0") {
                            document.getElementById("ddlDebitNote" + P_Id).style.borderColor = "red";
                            document.getElementById("ddlDebitNote" + P_Id).focus();
                            ret = false;
                        }
                    }
                    if (DebitNoteSumCalculation(P_Id) == false) {
                        document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the debit note amount";
                        $("div.war").fadeIn(200).delay(500).fadeOut(400);
                        ret = false;
                    }
                }
            }


            ////0043
            //var TotalExpenseAmnt = 0;
            //var addRowExpense = document.getElementById("TableExpense");
            //var expnsAmt = 0, expenseFlag = 0;
            //for (var i = j; i < addRowExpense.rows.length; i++) {

            //    var E_Id = (addRowExpense.rows[i].cells[0].innerHTML);
            //    var tdLedgerRow = document.getElementById("tdLedgerRow" + P_Id).innerHTML;


            //    document.getElementById("tdAmnt" + E_Id).innerHTML = document.getElementById("tdDupAmnt" + E_Id).innerHTML;
            //    var MaxAmt = DuplicateSettlementChange(E_Id, tdLedgerRow);
            //    document.getElementById("tdAmnt" + E_Id).innerHTML = parseFloat(document.getElementById("tdAmnt" + E_Id).innerHTML) - parseFloat(MaxAmt);
            //    AmountCheckingLabel("tdAmnt" + E_Id);


            //    var tdAmnt = document.getElementById("tdAmnt" + P_Id).innerHTML;

            //    var expnsAmt = "";
            //    document.getElementById("txtExpenseAmt" + E_Id).style.borderColor = "";

            //    expnsAmt = document.getElementById("txtExpenseAmt" + E_Id).value;

            //    if (expnsAmt != "") {
            //        expnsAmt = purchaseAmt.replace(/\,/g, '');
            //        if (parseFloat(expnsAmt) <= 0) {
            //            document.getElementById("txtExpenseAmt" + E_Id).style.borderColor = "red";
            //            ret = false;
            //        }
            //        TotalExpenseAmnt = parseFloat(TotalExpenseAmnt) + parseFloat(expnsAmt);
            //        if (FloatingValue != "") {
            //            TotalExpenseAmnt = TotalExpenseAmnt.toFixed(FloatingValue);
            //        }
            //        expenseFlag++;
            //    }
            //    if (parseFloat(expnsAmt) > parseFloat(tdAmnt)) {
            //        document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the purchase amount";
            //        $("div.war").fadeIn(200).delay(500).fadeOut(400);

            //        document.getElementById("txtExpenseAmt" + E_Id).style.borderColor = "red";
            //        ret = false;
            //    }
            //}
            //end


            if (ret == true) {
                var TxtTotal = 0;
                if (TotalPurchaseAmnt != "") {
                    TxtTotal = document.getElementById("txtAmntVal" + tdLedgerRow).value;
                    TxtTotal = TxtTotal.replace(/\,/g, '');
                    if (parseFloat(TotalPurchaseAmnt) > parseFloat(TxtTotal)) {
                        document.getElementById("lblErrMsgCancelReason").innerHTML = "Purchase total amount should be less than the payment amount";
                        $("div.war").fadeIn(200).delay(500).fadeOut(400);
                        ret = false;
                    }
                }
                if (TotalPurchaseAmnt != "") {
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt).toFixed(FloatingValue);
                    }
                }
                if (document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value != "") {
                }
                if (TotalPurchaseAmnt != 0) {
                    if (FloatingValue != "") {
                        TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt);
                        TotalPurchaseAmnt = TotalPurchaseAmnt.toFixed(FloatingValue);
                    }
                }
            }

            //0043 start

            //if (ret == true) {
            //    var TxtTotal = 0;
            //    //alert(TotalExpenseAmnt);
            //    if (TotalExpenseAmnt != "") {
            //        TxtTotal = document.getElementById("txtAmntVal" + tdLedgerRow).value;
            //        TxtTotal = TxtTotal.replace(/\,/g, '');
            //        if (parseFloat(TotalExpenseAmnt) > parseFloat(TxtTotal)) {
            //            document.getElementById("lblErrMsgCancelReason").innerHTML = "Expense total amount should be less than the payment amount";
            //            $("div.war").fadeIn(200).delay(500).fadeOut(400);
            //            ret = false;
            //        }
            //    }
                //if (TotalExpenseAmnt != "") {
                    //var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                //    if (FloatingValue != "") {
                //        TotalExpenseAmnt = parseFloat(TotalExpenseAmnt).toFixed(FloatingValue);
                //    }
                //}
                //if (document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value != "") {
            //    }
            //    if (TotalExpenseAmnt != 0) {
            //        if (FloatingValue != "") {
            //            TotalExpenseAmnt = parseFloat(TotalExpenseAmnt);
            //            TotalExpenseAmnt = TotalExpenseAmnt.toFixed(FloatingValue);
            //        }
            //    }
            //}
            //end


            if (ret == true) {

                var j = 1;
                if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                    j++;
                    //EVM-0027 Aug09
                    if (addRowtable.rows.length == 2) {

                        //tableGrp
                        var LedgerId = document.getElementById("ddlRecptLedger" + varRowidx).value;

                        if (document.getElementById("tdOpenSts" + varRowidx).value == 1) {

                            //evm-0020
                            document.getElementById("tdOpeningBalnc" + varRowidx).innerHTML = document.getElementById("tdDupOBAmnt" + varRowidx).innerHTML;
                            var OBPaid = DuplicateOBSettlementChange(varRowidx);
                            document.getElementById("tdOpeningBalnc" + varRowidx).innerHTML = parseFloat(document.getElementById("tdOpeningBalnc" + varRowidx).innerHTML) + parseFloat(OBPaid);
                            AmountCheckingLabel("tdOpeningBalnc" + varRowidx);


                            if (document.getElementById("txtOpeningBalnc" + varRowidx).value != "") {
                                var arry = document.getElementById("SpanOpeningBalance" + varRowidx).innerHTML.split(" ");
                                var OpeningBal = document.getElementById("tdOpeningBalnc" + varRowidx).innerHTML;
                                var txtob = document.getElementById("txtOpeningBalnc" + varRowidx).value;
                                OpeningBal = parseFloat(OpeningBal) + parseFloat(txtob);    //EVM-0027 Aug26
                                var amt = document.getElementById("txtOpeningBalnc" + varRowidx).value + "#" + parseFloat(OpeningBal);

                                document.getElementById("tdLedgrPaid" + varRowidx).value = amt;
                            }
                        }
                    }
                    //ENd
                }

                for (var i = j; i < addRowtable.rows.length; i++) {

                    var P_Id = (addRowtable.rows[i].cells[0].innerHTML);

                    var tdAmnt = document.getElementById("tdAmnt" + P_Id).innerHTML;
                    var tdLedgerRow = document.getElementById("tdLedgerRow" + P_Id).innerHTML;
                    //--//0043 19/3
                    var tdStatus = document.getElementById("tdStatus" + P_Id).innerHTML;
                    //--//0043 19/3
                    if (i == 0) {
                        document.getElementById("tdExpenseDtls" + tdLedgerRow).value = "";
                        

                    }
                    //----
                    if (document.getElementById("tdOpenSts" + tdLedgerRow).value == 0) {
                        if (i == 1) {
                            document.getElementById("tdPurchaseDtls" + tdLedgerRow).value = "";
                           
                        }
                    }
                    else {
                        if (i < 3) {
                            document.getElementById("tdPurchaseDtls" + tdLedgerRow).value = "";
                        }
                    }
                    var purchaseAmt = "";
                    document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "";
                    purchaseAmt = document.getElementById("txtPurchaseAmt" + P_Id).value;
                    if (purchaseAmt != "") {
                        purchaseAmt = purchaseAmt.replace(/\,/g, '');
                        TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt) + parseFloat(purchaseAmt);
                    }

                    var LedgerId = document.getElementById("ddlRecptLedger" + tdLedgerRow).value;

                    if ((document.getElementById("tdSaleID" + P_Id).innerHTML != "" && document.getElementById("txtPurchaseAmt" + P_Id).value != "") || (document.getElementById("DebitNoteSettle_Status" + P_Id).checked == true)) {
                        var settleStatus = 0;
                        var DebitNoteId = 0;
                        var DebitNoteAmount = 0;
                        var DebitNoteBalAmount = 0;
                        if (document.getElementById("DebitNoteSettle_Status" + P_Id).checked == true) {
                            settleStatus = 1;
                            if (document.getElementById("ddlDebitNote" + P_Id).value != "-Select Debit Note-" && document.getElementById("ddlDebitNote" + P_Id).value != "0")
                                DebitNoteId = document.getElementById("ddlDebitNote" + P_Id).value;
                            if (document.getElementById("txtDebitNotetxtAmt" + P_Id).value != "")
                                DebitNoteAmount = document.getElementById("txtDebitNotetxtAmt" + P_Id).value;

                            if (document.getElementById("tdDebitAmnt" + P_Id).innerHTML != "")
                                DebitNoteBalAmount = document.getElementById("tdDebitAmnt" + P_Id).innerHTML;
                        }
                       
                        //if (document.getElementById("tdStatus" + P_Id).innerHTML == "1") {
                            if (document.getElementById("tdPurchaseDtls" + tdLedgerRow).value == "") {

                                document.getElementById("tdPurchaseDtls" + tdLedgerRow).value = document.getElementById("tdSaleID" + P_Id).innerHTML + "%" + document.getElementById("txtPurchaseAmt" + P_Id).value + "%" + document.getElementById("tdAmnt" + P_Id).innerHTML + "%" + settleStatus + "%" + DebitNoteId + "%" + DebitNoteAmount + "%" + DebitNoteBalAmount + "%" + document.getElementById("tdStatus" + P_Id).innerHTML;
                                
                            }
                            else {
                                document.getElementById("tdPurchaseDtls" + tdLedgerRow).value = document.getElementById("tdPurchaseDtls" + tdLedgerRow).value + "$" + document.getElementById("tdSaleID" + P_Id).innerHTML + "%" + document.getElementById("txtPurchaseAmt" + P_Id).value + "%" + document.getElementById("tdAmnt" + P_Id).innerHTML + "%" + settleStatus + "%" + DebitNoteId + "%" + DebitNoteAmount + "%" + DebitNoteBalAmount + "%" + document.getElementById("tdStatus" + P_Id).innerHTML;
                               
                            }
                        //}
                        //else
                        //{
                        //    if (document.getElementById("tdExpenseDtls" + tdLedgerRow).value == "") {
                        //        document.getElementById("tdExpenseDtls" + tdLedgerRow).value = document.getElementById("tdSaleID" + P_Id).innerHTML + "%" + document.getElementById("txtPurchaseAmt" + P_Id).value + "%" + document.getElementById("tdAmnt" + P_Id).innerHTML;
                        //    }
                        //    else {

                        //        document.getElementById("tdExpenseDtls" + tdLedgerRow).value = document.getElementById("tdExpenseDtls" + tdLedgerRow).value + "$" + document.getElementById("tdSaleID" + P_Id).innerHTML + "%" + document.getElementById("txtPurchaseAmt" + P_Id).value + "%" + document.getElementById("tdAmnt" + P_Id).innerHTML
                        //    }

                        //}                       
                }

                    if (document.getElementById("tdOpenSts" + tdLedgerRow).value == 1) {

                        if (document.getElementById("txtOpeningBalnc" + tdLedgerRow).value != "") {
                            var arry = document.getElementById("SpanOpeningBalance" + tdLedgerRow).innerHTML.split(" ");

                            var amt = document.getElementById("txtOpeningBalnc" + tdLedgerRow).value + "#" + parseFloat(arry[0]);
                            document.getElementById("tdLedgrPaid" + tdLedgerRow).value = amt;
                        }
                    }
                   // alert(document.getElementById("tdStatus" + P_Id).innerHTML);
                    //alert(document.getElementById("tdExpenseDtls" + tdLedgerRow).value);
                    //alert(document.getElementById("tdPurchaseDtls" + tdLedgerRow).value);
                }
             
                ////0043
                //for (var i = 0; i < addRowExpense.rows.length; i++) {

                //    var E_Id = (addRowExpense.rows[i].cells[0].innerHTML);

                //    var tdAmnt = document.getElementById("tdAmnt" + E_Id).innerHTML;
                //    var tdLedgerRow = document.getElementById("tdLedgerRow" + E_Id).innerHTML;

                //    if (i == 0) {
                //        document.getElementById("tdExpenseDtls" + tdLedgerRow).value = "";
                //    }

                //    var expenseAmt = "";
                //    document.getElementById("txtExpenseAmt" + E_Id).style.borderColor = "";
                //    expenseAmt = document.getElementById("txtExpenseAmt" + E_Id).value;
                //    if (expenseAmt != "") {
                //        expenseAmt = expenseAmt.replace(/\,/g, '');
                //        TotalExpenseAmnt = parseFloat(TotalExpenseAmnt) + parseFloat(expenseAmt);
                //    }

                //    var LedgerId = document.getElementById("ddlRecptLedger" + tdLedgerRow).value;

                //    if ((document.getElementById("tdExpenseID" + E_Id).innerHTML != "" && document.getElementById("txtExpenseAmt" + E_Id).value != "")) {

                //        if (document.getElementById("tdExpenseDtls" + tdLedgerRow).value == "") {
                //            document.getElementById("tdExpenseDtls" + tdLedgerRow).value = document.getElementById("tdExpenseID" + E_Id).innerHTML + "%" + document.getElementById("txtExpenseAmt" + E_Id).value + "%" + document.getElementById("tdAmnt" + E_Id).innerHTML;
                //        }
                //        else {

                //            document.getElementById("tdExpenseDtls" + tdLedgerRow).value = document.getElementById("tdExpenseDtls" + tdLedgerRow).value + "$" + document.getElementById("tdExpenseID" + E_Id).innerHTML + "%" + document.getElementById("txtExpenseAmt" + E_Id).value + "%" + document.getElementById("tdAmnt" + E_Id).innerHTML;
                //        }

                //    }
                //}
                //END



                if (ret == true) {
                    calculateTotal();
                    document.getElementById("BttnTemp").click();
                    //   document.getElementById("ChkPurchase" + tdLedgerRow).focus();
                }
            }
        }


        function DuplicateOBSettlementChange(RowId) {//evm-0020

            var TotalAmnt = 0;

            addRowtableLdgr = document.getElementById("tableGrp");
            for (var row = 1; row < addRowtableLdgr.rows.length; row++) {
                var validRow = (addRowtableLdgr.rows[row].cells[0].innerHTML);

                var LedgerPaid = document.getElementById('tdLedgrPaid' + validRow).value;
                if (LedgerPaid != "" && validRow != RowId) {
                    var splitrow = LedgerPaid.split("#");
                    var EachAmnt = parseFloat(splitrow[0]);
                    //alert("EachAmnt " + EachAmnt);
                    TotalAmnt = parseFloat(TotalAmnt) + parseFloat(EachAmnt);
                }
            }
            return TotalAmnt;
        }

        function DuplicateSettlementChange(P_Id,RowId) {//evm-0020

            var TotalAmnt = 0;
            

            addRowtableLdgr = document.getElementById("tableGrp");
            for (var row = 1; row < addRowtableLdgr.rows.length; row++) {
                var validRow = (addRowtableLdgr.rows[row].cells[0].innerHTML);

                var LdgrIdAll = document.getElementById('ddlRecptLedger' + validRow).value;
                var PurchaseInfo = document.getElementById('tdPurchaseDtls' + validRow).value;
               
                //alert(PurchaseInfo);

                if (PurchaseInfo != "" && validRow != RowId) {

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
            ///alert(TotalAmnt);
            //nhb
            return TotalAmnt;
        }

        function ButtnFillClickCostCenter(x) {
            var ret = true;
            var TotalAmnt = 0;
            var purchaseFlag = 0;
            var CheckCount = 0;
            //  document.getElementById("divErrMsgCnclRsn").style.display = "none";
            var TotalAmnt = document.getElementById("txtAmntVal" + x).value;
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
                    //$("div.war").fadeIn(200).delay(500).fadeOut(400);
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
                    //$("div.war").fadeIn(200).delay(500).fadeOut(400);
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
                    //$("div.war").fadeIn(200).delay(500).fadeOut(400);
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
                        document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "block";
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
            var Narration = document.getElementById("cphMain_txtDescription").value.trim();
            document.getElementById("cphMain_txtDescription").style.borderColor = "";
            if (DdlAccnt == "--SELECT--") {
                document.getElementById("cphMain_ddlCurrency").style.borderColor = "Red";
                document.getElementById("cphMain_ddlCurrency").focus();

                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon(window).scrollTop(0);

                ret = false;
            }
            var DftCurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
            if (DdlAccnt != "") {
                if (DdlAccnt != DftCurrencyId) {
                    if (document.getElementById("<%=txtExchangeRate.ClientID%>").value == "") {
                        document.getElementById("<%=txtExchangeRate.ClientID%>").style.borderColor = "red";
                        ret = false;
                    }
                }
            }
            if (AccntDate == "") {
                document.getElementById("cphMain_txtdate").style.borderColor = "Red";
                document.getElementById("cphMain_txtdate").focus();

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

                ret = false;
            }

            if (!(validateTable(ret))) {

                ret = false;

            }

            else if (PaymentModeValidation() == false) {
                ret = false;
            }
            else {
                document.getElementById("<%=hiddenLedgerddl.ClientID%>").value = "";
                document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
                document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
                document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";
            }

            return ret;
        }

        function PaymentModeValidation() {
            var Result = true;
            if (document.getElementById("PaymentMode").style.display != "none") {
                if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "Cheque") {
                    var Cheque = "";
                    var ChequeNO = "";
                    var Payee = "";
                    Cheque = document.getElementById("<%=ddlChequeBook_Cheque.ClientID%>").value;
                    ChequeNO = document.getElementById("<%=ddlChequeNum_Cheque.ClientID%>").value;
                    Payee = document.getElementById("<%=txtPayee.ClientID%>").value.trim();
                    document.getElementById("cphMain_ddlChequeBook_Cheque").style.borderColor = "";
                    document.getElementById("cphMain_ddlChequeNum_Cheque").style.borderColor = "";
                    document.getElementById("cphMain_txtPayee").style.borderColor = "";
                    document.getElementById("<%=txtDate_Cheque.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").style.borderColor = "";
                    document.getElementById("cphMain_ddlMode_BankTransfer").style.borderColor = "";
                    document.getElementById("<%=txtDate_BankTransfer.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=Bank_BankTransfer.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=IBAN_BankTransfer.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtDate_DD.ClientID%>").style.borderColor = "";


                    if (Cheque == "" || Cheque == "0" || Cheque == "--SELECT--") {
                        document.getElementById("cphMain_ddlChequeBook_Cheque").style.borderColor = "Red";
                        document.getElementById("cphMain_ddlChequeBook_Cheque").focus();
                        $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });

                        $noCon(window).scrollTop(0);
                        Result = false;
                    }
                    if (ChequeNO == "" || ChequeNO == "--SELECT--" || ChequeNO == 0) {
                        document.getElementById("cphMain_ddlChequeNum_Cheque").style.borderColor = "Red";
                        document.getElementById("cphMain_ddlChequeNum_Cheque").focus();
                        $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });

                        $noCon(window).scrollTop(0);
                        Result = false;
                    }
                    if (Payee == "") {
                        document.getElementById("cphMain_txtPayee").style.borderColor = "Red";
                        document.getElementById("cphMain_txtPayee").focus();
                        $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });

                        $noCon(window).scrollTop(0);
                        Result = false;
                    }
                    if (document.getElementById("<%=txtDate_Cheque.ClientID%>").value == "") {
                        document.getElementById("<%=txtDate_Cheque.ClientID%>").style.borderColor = "Red";
                        Result = false;
                    }
                    if (document.getElementById("<%=ChkStatus_Cheque.ClientID%>").checked == true) {
                        if (document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").value == "") {
                            document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").style.borderColor = "Red";
                            Result = false;
                        }
                    }
                }
                else if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "DD") {

                    if (document.getElementById("<%=txtDate_DD.ClientID%>").value == "") {
                        document.getElementById("<%=txtDate_DD.ClientID%>").style.borderColor = "Red";
                        Result = false;
                    }
                    if (document.getElementById("<%=txtDD_DD.ClientID%>").value == "") {
                        document.getElementById("<%=txtDD_DD.ClientID%>").style.borderColor = "Red";
                        Result = false;
                    }
                }
                else if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "BankTransfer") {
                    var BankTr = "";
                    BankTr = document.getElementById("<%=ddlMode_BankTransfer.ClientID%>").value;
                    if (BankTr == "" || BankTr == "--SELECT--") {
                        document.getElementById("cphMain_ddlMode_BankTransfer").style.borderColor = "Red";
                        document.getElementById("cphMain_ddlMode_BankTransfer").focus();
                        $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });

                        $noCon(window).scrollTop(0);
                        Result = false;
                    }
                    if (document.getElementById("<%=txtDate_BankTransfer.ClientID%>").value == "") {
                        document.getElementById("<%=txtDate_BankTransfer.ClientID%>").style.borderColor = "Red";
                        Result = false;
                    }
                    if (document.getElementById("<%=Bank_BankTransfer.ClientID%>").value == "") {
                        document.getElementById("<%=Bank_BankTransfer.ClientID%>").style.borderColor = "Red";
                        Result = false;
                    }
                    if (document.getElementById("<%=IBAN_BankTransfer.ClientID%>").value == "") {
                        document.getElementById("<%=IBAN_BankTransfer.ClientID%>").style.borderColor = "Red";
                        Result = false;
                    }
                }
            }
            return Result;
        }

        function validateTable(retchk) {
            var Result = true;
            var varfocus = "";
            var varfocusLed = "";
            var varfocusCheck = "";
            var ret = true;
            var purchaseret = true;
            var varTotal = 0;
            addRowtable = document.getElementById("tableGrp");
            var RowLength = addRowtable.rows.length;

            for (var i = 1; i < addRowtable.rows.length; i++) {

                var row = addRowtable.rows[i];
                var x = (addRowtable.rows[i].cells[0].innerHTML);

                var CstTotal = 0;
                var varId = "";
                var varfocus = "";

                var LedgerTotal = 0;


                var ledgerval = $("#ddlRecptLedger" + x).val();

                if (document.getElementById("txtAmntVal" + x).value != "") {

                    var ldgramt = document.getElementById("txtAmntVal" + x).value;
                    ldgramt = ldgramt.replace(/\,/g, '');
                    LedgerTotal = parseFloat(ldgramt);
                }
                else if (document.getElementById("txtAmntVal" + x).value == "" && ledgerval == "0") {

                    document.getElementById("TxtAmount_" + x).style.borderColor = "";
                }
                else {

                    ret = false;
                    document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                    if (varfocus == "") {
                        if (varfocusLed == "")
                            varfocusLed = x;
                    }
                }
                if (varfocus != "" && varfocusLed != "") {
                    if (varfocusCheck < varfocusLed) {
                        if (document.getElementById("TxtCstctrAmount_" + varfocus).value == "") {
                            document.getElementById("TxtCstctrAmount_" + varfocus).focus();
                            document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                        }
                        if (document.getElementById("divCostCenter" + varfocus).style.display != "none") {
                            var CostFocval = $("#ddlRecptCosCtr_" + varfocus).val();
                            if (CostFocval == 0) {

                                $("#divCostCenter" + varfocus + "> input").focus();
                                $("#divCostCenter" + varfocus + "> input").select();
                            }
                        }
                    }
                    else {

                        if (document.getElementById("TxtAmount_" + x).value == "") {
                            document.getElementById("TxtAmount_" + x).focus();
                            document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
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
                        document.getElementById("TxtAmount_" + x).focus();
                        document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
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
                        document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                    }
                    if (document.getElementById("divCostCenter" + varfocus).style.display != "none") {
                        var CostFocval1 = $("#ddlRecptCosCtr_" + varfocus).val();

                        if (CostFocval1 == 0) {

                            $("#divCostCenter" + varfocus + "> input").focus();
                            $("#divCostCenter" + varfocus + "> input").select();

                        }
                    }


                }


                var SalCstAmt = CheckSumOfLedger("TxtAmount_" + x, x);


                if (SalCstAmt == false) {
                    return false;
                }

                if (CstTotal != 0) {
                    if (LedgerTotal != CstTotal) {
                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                        if (FloatingValue != "") {
                            LedgerTotal = LedgerTotal.toFixed(FloatingValue);
                        }
                        document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                        $noCon("#divWarning").html("Ledger and cost centre amount should be equal.");
                        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

                        });

                        $noCon(window).scrollTop(0);
                        // ret = false;
                        return false;
                    }
                }
                // var SalCstAmt = CheckSumOfLedger("TxtAmount_" + x, +x);

            }

            if (RowLength == 2) {
                if (ledgerval == "0") {
                    $("#divLedger" + x + "> input").css("borderColor", "red");
                    $("#divLedger" + x + "> input").focus();
                    $("#divLedger" + x + "> input").select();
                    ret = false;
                }
                if (document.getElementById("TxtAmount_" + x).value == "") {
                    document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                    document.getElementById("TxtAmount_" + x).focus();
                    ret = false;
                }
            }
            var TxtCstctrAmount = "";
            TxtCstctrAmount = document.getElementById("TxtAmount_" + x).value;
            TxtCstctrAmount = TxtCstctrAmount.trim();
            TxtCstctrAmount = TxtCstctrAmount.replace(/,/g, "");
            if (TxtCstctrAmount == "" || TxtCstctrAmount <= 0) {
                ret = false;
                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
            }
            if (LedgerDuplication(x) == false) {
                ret = false;
            }
            if (ret == false) {


                if ((LedgerDuplication(x) == true) && (purchaseret == true)) {
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

                    });

                    $noCon(window).scrollTop(0);
                }
                if (purchaseret == false) {
                    $noCon("#divWarning").html("Paid amount can not exceed actual amount.");
                    $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });

                    $noCon(window).scrollTop(0);
                }
                return false;
            }
            else if (SalCstAmt == false) {

                ret = false;
            }

            var tbClientTotalValues = '';
            tbClientTotalValues = [];
            var tbClientUploadValues = '';
            tbClientUploadValues = [];

            addRowtable = document.getElementById("tableGrp");

            for (var i = 1; i < addRowtable.rows.length; i++) {


                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                var LedgerSts = document.getElementById("tdEvtGrp" + xLoop).value;
                var CstCntrId = "";
                var PrchsId = "";
                var CostCntrAmt = "";
                var PrchsAmt = "";
                var CstGrp1Id = "";
                var CstGrp2Id = "";
                var EvtGrp = document.getElementById("tdDtlIdTempid" + xLoop).value;
                var CostCenterInfo = document.getElementById("tdCostCenterDtls" + xLoop).value;
                if (CostCenterInfo != "") {
                    var splitrow = CostCenterInfo.split("$");
                    for (var Cst = 0; Cst < splitrow.length; Cst++) {
                        var splitEach = splitrow[Cst].split("%");
                        if (splitEach[0] != "" && splitEach[1] != "") {
                            if (CstCntrId == "") {
                                CstCntrId = splitEach[0];
                                splitEach[1] = splitEach[1].replace(/\,/g, '');
                                CostCntrAmt = splitEach[1];
                                CstGrp1Id = splitEach[2];
                                CstGrp2Id = splitEach[3];
                            }
                            else {
                                CstCntrId = CstCntrId + ',' + splitEach[0];
                                splitEach[1] = splitEach[1].replace(/\,/g, '');
                                CostCntrAmt = CostCntrAmt + ',' + splitEach[1];
                                CstGrp1Id = CstGrp1Id + ',' + splitEach[2];
                                CstGrp2Id = CstGrp2Id + ',' + splitEach[3];
                            }
                        }
                    }
                }

                var OpeningBalInfo = document.getElementById("tdLedgrPaid" + xLoop).value;
                var OB = "";
                if (OpeningBalInfo != "" && OpeningBalInfo != null && OpeningBalInfo != "null") {
                    //alert(document.getElementById("tdLedgrPaid" + xLoop).value);
                    OB = document.getElementById("tdLedgrPaid" + xLoop).value
                }

                var PurchaseInfo = document.getElementById("tdPurchaseDtls" + xLoop).value;
                if (PurchaseInfo != "") {
                    var splitrow = PurchaseInfo.split("$");
                    for (var Cst = 0; Cst < splitrow.length; Cst++) {
                        var splitEach = splitrow[Cst].split("%");
                        if (splitEach[0] != "" && splitEach[1] != "") {
                            if (PrchsId == "") {
                                PrchsId = splitEach[0];
                                splitEach[1] = splitEach[1].replace(/\,/g, '');
                                PrchsAmt = splitEach[1];
                            }
                            else {
                                PrchsId = PrchsId + ',' + splitEach[0];
                                splitEach[1] = splitEach[1].replace(/\,/g, '');
                                PrchsAmt = PrchsAmt + ',' + splitEach[1];
                            }
                        }
                    }
                }

                var $add = jQuery.noConflict();
                // if (Name != "") {
                var client = JSON.stringify({
                    LEDGERID: "" + xLoop + "",
                    LEDGERSTATUS: "" + LedgerSts + "",
                    COSTCENTERID: "" + CstCntrId + "",
                    COSTCENTERAMT: "" + CostCntrAmt + "",
                    PURCHASEID: "" + PrchsId + "",
                    PURCHASEAMT: "" + PrchsAmt + "",
                    LEDGERPYMTID: "" + EvtGrp + "",
                    COSTGRPID_ONE: "" + CstGrp1Id + "",
                    COSTGRPID_two: "" + CstGrp2Id + "",

                });
                tbClientTotalValues.push(client);
            }
            document.getElementById("<%=HiddenFieldSaveAccount.ClientID%>").value = JSON.stringify(tbClientTotalValues);
            return ret;
        }

        var incount = 0;
        function incrementCount() {
            incount++;

        }
        function AccntChangeFunt(ChequeId, mode) {

            if (mode == "1" && document.getElementById("cphMain_hiddenSelectedAccntBk").value != "--SELECT--") {
                IncrmntConfrmCounter();
            }

            if (document.getElementById("cphMain_ddlAccontLed").value != 0 && document.getElementById("cphMain_ddlAccontLed").value != "--SELECT--") {
                var ddlOldAccntId = document.getElementById("cphMain_ddlAccontLed").value;
                var ddlAccntId = document.getElementById("cphMain_ddlAccontLed").value;
                if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {

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


                    }
                    else {
                        document.getElementById("cphMain_hiddenSelectedAccntBk").value = document.getElementById("cphMain_ddlAccontLed").value;
                    }
                }

                var ddlAccntId = document.getElementById("cphMain_ddlAccontLed").value;
                var txtAccnt = $("#cphMain_ddlAccontLed option:selected").text();
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';
                var ChqBkId = document.getElementById("<%=HiddenChequeBookId.ClientID%>").value;

                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "fms_Payment_Account.aspx/AccntBalanceLedger",
                    data: '{intLedgerId:"' + ddlAccntId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",ChqBkId:"' + ChqBkId + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        if (response.d[0] != "0") {
                            addCommasSummry(response.d[0]);
                            if (document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value != "") {
                                document.getElementById("lblCurrency").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                                document.getElementById("cphMain_AccntBalance").innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                            }
                            else {
                                document.getElementById("cphMain_AccntBalance").innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                            }
                            if (response.d[1] == "CR")
                                document.getElementById("cphMain_AccntBalance").className = "input-group-addon cur2 c1h";
                            else if (response.d[1] == "DR")
                                document.getElementById("cphMain_AccntBalance").className = "input-group-addon cur2 dr1";
                        }
                        if (response.d[2] == "True") {
                            $("#cphMain_ddlChequeNum_Cheque").empty();
                            document.getElementById("PaymentMode").style.display = "";
                            if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "") {
                                $('#liBankTransfer').removeClass('active tablinks').addClass('tablinks');
                                $('#BankTransfer').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                                $('#liDD').removeClass('active tablinks').addClass('tablinks');
                                $('#DD').removeClass('tab-pane fade active in').addClass('tab-pane fade');
                                $('#lisCheque').removeClass('tablinks').addClass('active tablinks');
                                $('#Cheque').removeClass('tab-pane fade').addClass('tab-pane fade active in');
                                document.getElementById("DD").style.display = "none";
                                document.getElementById("BankTransfer").style.display = "none";
                                document.getElementById("Cheque").style.display = "block";
                                document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "Cheque";
                            }
                            var ddlTestDropDownListXML2 = $noCon("#cphMain_ddlChequeBook_Cheque");
                            var ddlTestDropDownListXML3 = $noCon("#cphMain_ddlChequeNum_Cheque");
                            $("#cphMain_ddlChequeBook_Cheque").empty();
                            var tableName = "dtTableChequeBook";
                            var OptionStart = $noCon("<option>--SELECT--</option>");
                            OptionStart.attr("value", 0);
                            var OptionStart1 = $noCon("<option>--SELECT--</option>");
                            OptionStart1.attr("value", 0);
                            ddlTestDropDownListXML3.append(OptionStart1);
                            ddlTestDropDownListXML2.append(OptionStart);
                            if (response.d[3] != "") {
                                $noCon(response.d[3]).find(tableName).each(function () {
                                    var OptionValue = $noCon(this).find('CHKBK_ID').text();
                                    var OptionText = $noCon(this).find('CHKBK_NAME').text();
                                    var option = $noCon("<option>" + OptionText + "</option>");
                                    option.attr("value", OptionValue);
                                    //if (ChequeId == null) {
                                    //    LoadChequeBookNum(OptionValue, "0");
                                    //}
                                    ddlTestDropDownListXML2.append(option);
                                });
                            }
                            if (ChequeId != "" && ChequeId != null) {
                                var arrayProduct = JSON.parse("[" + ChequeId + "]");
                                $noCon("#cphMain_ddlChequeBook_Cheque").val(arrayProduct);
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
        function ConfirmMessageAdd() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Payment_Account_List.aspx";
                    }
                    else {
                        window.location.href = "fms_Payment_Account.aspx";
                    }
                });
                return false;
            }
            else {
                window.location.href = "fms_Payment_Account_List.aspx";
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
                        window.location.href = "fms_Payment_Account.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "fms_Payment_Account.aspx";
                return false;
            }
            return false;
        }
        function ConfirmAlert() {
            if (ValidateReceiptAccnt() == true) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm this payment?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {

                        CheckSaleSettlements();
                        return false;
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

        function Confirm() {
            document.getElementById("<%=btnConfirm1.ClientID%>").click();
        }

        function CheckSaleSettlements() {//evm-0020

            var Settld = 0;
            var SettldExceed = 0;
            var SuccessSts = "successConfirm";
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';

            addRowtable = document.getElementById("tableGrp");

            for (var i = 1; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                var PurchaseInfo = document.getElementById("tdPurchaseDtls" + xLoop).value;

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
                                url: "fms_Payment_Account.aspx/CheckSaleSettlement",
                                data: '{strSalePurchaseDtls: "' + PurchaseInfo + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",strTotalAmnt: "' + TotalAmnt + '",strPurchaseId: "' + PrchsId + '"}',
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
                                    SuccessSts = "PrchsAmtFullySettld";
                                }
                            }
                            else if (SuccessSts == "PrchsAmtFullySettld") {
                                Settld++;
                                continue;
                            }
                        }
                    }
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

        function PurchaseAmountExceeded() {
            $noCon("#divWarning").html("Payment amount should not be greater than purchase amount.");
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

    function OpenPrint(StrId) {
        var orgID = '<%= Session["ORGID"] %>';
        var corptID = '<%= Session["CORPOFFICEID"] %>';
        var PreparedBy = '<%= Session["USERFULLNAME"] %>';
        var saleId = document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value
        var currency = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value
        var currencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value
        if (corptID != "" && corptID != null && orgID != "" && orgID != null && saleId != "") {
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "fms_Payment_Account.aspx/PrintPDF",
                data: '{saleId: "' + saleId + '",orgID: "' + orgID + '",corptID: "' + corptID + '",currency: "' + currency + '",currencyId: "' + currencyId + '"}',
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
    function SaveChequeBookNum() {
        var ChequeBookNum = "";

        var ChequeBookNum = $("#cphMain_ddlChequeNum_Cheque option:selected").text();
        if (ChequeBookNum != "--SELECT--" && ChequeBookNum != "" && ChequeBookNum != 0) {
            document.getElementById("<%=HiddenupdCheckNumber.ClientID%>").value = ChequeBookNum;
            }
        }
        function IssueDateCheck() {
            var StartDateFin = document.getElementById("<%=HiddenFinancialYrStartDate.ClientID%>").value;
            if (document.getElementById("<%=txtDate_Cheque.ClientID%>").value != "") {
                if (document.getElementById("<%=ChkStatus_Cheque.ClientID%>").checked == true) {
                    document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").disabled = false;
                    document.getElementById("<%=ChequeIssueDatePikrSpan.ClientID%>").disabled = false;
                    document.getElementById("<%=ChequeIssueDatePikrSpan.ClientID%>").style.pointerEvents = "";

                    var txtIssueDate_Cheque_date = document.getElementById("<%=txtDate_Cheque.ClientID%>").value;
                    var from = $("#cphMain_txtDate_Cheque").val().split("-")
                    var f = new Date(from[2], from[1] - 1, from[0])
                    f.setMonth(f.getMonth() + 3);
                    $noCon('#cphMain_txtIssueDate_Cheque').datepicker({
                        autoclose: true,
                        format: 'dd-mm-yyyy',
                        startDate: StartDateFin,
                        endDate: f,
                        timepicker: false
                    });

                }
                else {
                    document.getElementById("<%=ChequeIssueDatePikrSpan.ClientID%>").disabled = true;
                    document.getElementById("<%=ChequeIssueDatePikrSpan.ClientID%>").style.pointerEvents = "none";

                    document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").disabled = true;
                    document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").value = "";
                }
            }
            else {
                document.getElementById("<%=ChkStatus_Cheque.ClientID%>").checked = false;
                document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").disabled = true;
                document.getElementById("<%=ChequeIssueDatePikrSpan.ClientID%>").disabled = true;
                document.getElementById("<%=ChequeIssueDatePikrSpan.ClientID%>").style.pointerEvents = "none";

                document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").value = "";

            }
        }

        function LoadChequeBookNum(ChequeBookFill, status) {
            PaymentCounter();
            $("#cphMain_ddlChequeNum_Cheque").empty();
            var ChequeBook = 0;
            var strChequeBook = "";
            var ChequeBook = document.getElementById("<%=ddlChequeBook_Cheque.ClientID%>").value;
            var Bank = document.getElementById("<%=ddlAccontLed.ClientID%>").value;
            var corpid = '<%= Session["CORPOFFICEID"] %>';
            var orgid = '<%= Session["ORGID"] %>';
            var EditId = document.getElementById("<%=HiddenPaymentID.ClientID%>").value;

            //if (ChequeBookFill != "" && ChequeBookFill != null)
            //    ChequeBook = ChequeBookFill;
            var ddlTestDropDownListXML = "";
            ddlTestDropDownListXML = $("#cphMain_ddlChequeNum_Cheque");
            var OptionStart = $("<option>--SELECT--</option>");
            OptionStart.attr("value", "--SELECT--");
            ddlTestDropDownListXML.append(OptionStart);
            if (ChequeBook != 0) {
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "fms_Payment_Account.aspx/LoadChequeBookNumber",
                    data: '{ChequeBook:"' + ChequeBook + '",status:"' + status + '",CorpId:"' + corpid + '",OrgId:"' + orgid + '",BankId:"' + Bank + '",EditId:"' + EditId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        result = response.d;
                        if (result != "")
                            strChequeBook = result;

                        //if (strChequeBook == "") {
                        //    $('#cphMain_ddlChequeBook_Cheque').find('option[value=' + ChequeBook + ']').remove();
                        //    //alert(ChequeBook);
                        //}
                    },
                    failure: function (response) {

                    }
                });
                FillddlChequenumbers(strChequeBook, ChequeBookFill);
            }
            document.getElementById("<%=HiddenChequeBookId.ClientID%>").value = document.getElementById("<%=ddlChequeBook_Cheque.ClientID%>").value;
        }
        function FillddlChequenumbers(strACI, ACI) {
            var ddlTestDropDownListXML = "";
            ddlTestDropDownListXML = $("#cphMain_ddlChequeNum_Cheque");

            if (strACI != "") {
                ddlLed = strACI;
                var spltdays = strACI.split(',');
                for (var loop = 0; loop < spltdays.length; loop++) {
                    var OptionText = spltdays[loop];
                    var option = $("<option>" + OptionText + "</option>");
                    option.attr("value", OptionText);
                    ddlTestDropDownListXML.append(option);
                }
                if (ACI != null) {
                    var arrayProduct = ACI;
                    $("#cphMain_ddlChequeNum_Cheque").val(arrayProduct);

                }
            }
            else {
                var OptionStart = $("<option>--SELECT--</option>");
                OptionStart.attr("value", "--SELECT--");
                ddlTestDropDownListXML.append(OptionStart);
            }


        }
        function textCounter1(field, maxlimit, evt) {
            PaymentCounter();
            if (DisableEnter(evt) == false) {
                return false;
            }
            if (field.value.length > maxlimit) {

                field.value = field.value.substring(0, maxlimit);
            }

            else {

            }
            var txt = field.value;
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            field.value = replaceText2;
        }
    </script>
    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au(".ddl").selectToAutocomplete1Letter();
        });
    </script>
    <script>


        function SuccessConfirmation() {
            $noCon("#success-alert").html("Payment Confirmed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }

        function Alreadyreopened() {
            $noCon("#divWarning").html("Payment already reopened.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessUpdation() {
            $noCon("#success-alert").html("Payment updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessNotConfirmation() {
            $noCon("#divWarning").html("Payment already confirmed.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessInsertion() {
            $noCon("#success-alert").html("Payment inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;

        }
        function SuccessCancelation() {
            $noCon("#success-alert").html("Payment deleted is already cancelled.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;

        }
        function SundryDebtorSelect() {
            $noCon("#divWarning").html("Please define the primary account group for bank and cash in hand before creating new payment ");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });

        }
        function SuccessReopMsg() {
            $noCon("#success-alert").html("Payment details reopened successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SalesAmountExceeded() {
            $noCon("#divWarning").html(" Payment amount should not be greater than purchase amount.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function PrintVersnError() {
            $noCon("#divWarning").html("Please select a version for printing from account setting.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 38 || keyCodes == 40) {
                return true;
            }
            else if (keyCodes == 36 || keyCodes == 35 || keyCodes == 41) {
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

        function ConfirmReopen() {


            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to reopen this payment?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {


                    document.getElementById("<%=hiddenLedgerddl.ClientID%>").value = "";
                    document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
                    document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
                    document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";

                    document.getElementById("<%=btnReopen1.ClientID%>").click();
                    return false;
                }

                else {
                    return false;
                }
            });
            return false;
        }



        function showFromDate() {
            document.getElementById("cphMain_txtdate").style.borderColor = "";
            IncrmntConfrmCounter();
            var orgID = '<%= Session["ORGID"] %>';
                var corptID = '<%= Session["CORPOFFICEID"] %>';
                var UserID = '<%= Session["USERID"] %>';
                var jrnlDate = $('#cphMain_txtdate').val().trim();
                var RcptDate = $('#cphMain_HiddenUpdatedDate').val().trim();
                var RefNum = $('#cphMain_HiddenUpdRefNum').val().trim();
                var PaymentId = $('#cphMain_HiddenPaymentID').val().trim();

                var AcntPrvsn = document.getElementById("<%=HiddenFieldAcntCloseReopenSts.ClientID%>").value
            var AuditPrvsn = document.getElementById("<%=HiddenAuditProvisionStatus.ClientID%>").value

                if (jrnlDate != "") {

                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "fms_Payment_Account.aspx/CheckAcntCloseSts",
                        data: '{jrnlDate: "' + jrnlDate + '",orgID: "' + orgID + '",corptID: "' + corptID + '"}',
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
                        url: "fms_Payment_Account.aspx/CheckRefNumber",
                        data: '{jrnlDate: "' + jrnlDate + '",orgID: "' + orgID + '",corptID: "' + corptID + '",UserID: "' + UserID + '",RefNum: "' + RefNum + '",PaymentId: "' + PaymentId + '"}',
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
        function clearValue() {
            document.getElementById("<%=hiddenLedgerddl.ClientID%>").value = "";
            document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
            document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
            document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";

            return true;
            // document.getElementById("<%=hiddenLedgerddl.ClientID%>").value = "";
        }

    </script>
    <script>
        var FileCounterVhcl = 0;
        var currntx = 0;

        function AddFileUploadVhcl() {

            var FrecRow = '<tr id="FilerowId_' + FileCounterVhcl + '" >';
            FrecRow += '<td   id="tdFileId' + FileCounterVhcl + '" style="display: none" >' + FileCounterVhcl + '</td>';
            var labelForStyle = '<label for="file' + FileCounterVhcl + '" class="custom-file-upload" style="margin-left: 0%;"> <img src="/Images/Icons/cloud_upload.jpg"></img>Upload Document</label>';
            var tdInner = labelForStyle + '<input   id="file' + FileCounterVhcl + '" name = "file' + FileCounterVhcl +
            '" type="file" onchange="ChangeFileVhcl(' + FileCounterVhcl + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/>';
            FrecRow += '<td id="tdTdInner' + FileCounterVhcl + '" style="width: 35%;" >' + tdInner + '</td>';



            FrecRow += '<td style="word-break: break-all;" id="filePath' + FileCounterVhcl + '"  ></td  >';
            FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterVhcl + '"  style="width: 1.5%; padding-left: 4px;"><a  href="javascript:;" id=\"SpanAddUpload' + FileCounterVhcl + '\"  onclick="return CheckaddMoreRowsIndividualFilesVhcl(' + FileCounterVhcl + ');" class=\"glyphicon glyphicon-plus\" class=\"tooltip\" title=\"Add\"></a> </td>';
            FrecRow += '<td id="FileIndvlDelMoreRow' + FileCounterVhcl + '" style="width: 1.5%; padding-left: 9px;"><a  href="javascript:;" id=\"SpanDelUpload' + FileCounterVhcl + '\"  onclick = "return RemoveFileUploadVhcl(' + FileCounterVhcl + ');" class=\"glyphicon glyphicon-trash\" class=\"tooltip\" title=\"Delete\" ></a></td>';
            FrecRow += ' <td id="FileInx' + FileCounterVhcl + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + FileCounterVhcl + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + FileCounterVhcl + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId' + FileCounterVhcl + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName' + FileCounterVhcl + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableFileCCN').append(FrecRow);

            document.getElementById('filePath' + FileCounterVhcl).innerHTML = 'No File Uploaded';
            currntx = FileCounterVhcl;
            FileCounterVhcl++;
        }
        function EditFileUpload(PURCHSE_ID, ATTACH_ID, FIMENAME, ACT_FILENAME) {
            AddFileUploadVhcl();
            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + FIMENAME + ' >' + ACT_FILENAME + '</a>';
            document.getElementById('filePath' + currntx).innerHTML = tdFileNameEdit;
            var filee = document.getElementById("<%=hiddenFilePath.ClientID%>").value + FIMENAME;
            document.getElementById("FileInx" + currntx).innerHTML = ATTACH_ID;
            document.getElementById("DbFileName" + currntx).innerHTML = ACT_FILENAME;
            document.getElementById("FileDtlId" + currntx).innerHTML = ATTACH_ID;
            document.getElementById("FileEvt" + currntx).innerHTML = "UPD";
            document.getElementById("tdTdInner" + currntx).style.display = "none";
            document.getElementById("filePath" + currntx).setAttribute("colspan", "2");
            document.getElementById("FileIndvlAddMoreRow" + currntx).style.opacity = "0.3";
            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                document.getElementById('SpanAddUpload' + currntx).style.pointerEvents = "none";
                document.getElementById('SpanDelUpload' + currntx).style.pointerEvents = "none";
                document.getElementById("FileIndvlAddMoreRow" + currntx).style.opacity = "1";
            }
            //colspan = "2"
        }
        function CheckaddMoreRowsIndividualFilesVhcl(x) {
            var check = document.getElementById("FileInx" + x).innerHTML;
            if (check == " ") {
                var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                if (CheckFileUploaded(x) == true) {
                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                    AddFileUploadVhcl();
                    return false;
                }
            }
            return false;
        }
        function RemoveFileUploadVhcl(removeNum) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to delete selected file?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                    AddDeletedAttachment(removeNum);
                    jQuery('#FilerowId_' + removeNum).remove();
                    var TableFileRowCount = document.getElementById("TableFileCCN").rows.length;
                    if (TableFileRowCount != 0) {
                        var idlast = $noCon('#TableFileCCN tr:last').attr('id');
                        if (idlast != "") {
                            var res = idlast.split("_");
                            document.getElementById("FileInx" + res[1]).innerHTML = " ";
                            document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";
                        }
                    }
                    else {
                        AddFileUploadVhcl();
                    }
                }
                else {
                    return false;
                }
            });

            return false;
        }
        function CheckFileUploaded(x) {
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (Fevt != 'UPD') {
                if (document.getElementById('file' + x).value != "") {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                var fileInx = "";
                if (document.getElementById("FileInx" + x).innerHTML != "")
                    fileInx = document.getElementById("FileInx" + x).innerHTML;
                if (fileInx != "") {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        function ChangeFileVhcl(x) {
            if (ClearDivDisplayImage1(x)) {
                IncrmntConfrmCounter();
                if (document.getElementById('file' + x).value != "") {
                    document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;
                }
                else {
                    document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';
                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                if (SavedorNot == "saved") {
                    var row_index = jQuery('#FilerowId_' + x).index();
                }
                else {
                    //    FileLocalStorageAddVhcl(x);
                }
            }
        }
        function ClearDivDisplayImage1(x) {
            var fuData = document.getElementById('file' + x);
            var FileUploadPath = fuData.value;
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg" || Extension == "xlsx" || Extension == "xls" || Extension == "doc" ||
                Extension == "docx" || Extension == "csv" || Extension == "ppt" || Extension == "pptx"
               || Extension == "txt" || Extension == "pdf") {
                return true;
            }
            else {
                document.getElementById('file' + x).value = "";
                document.getElementById('filePath' + x).innerHTML = 'No File Selected';
                $noCon("#divWarning").html("The specified file type could not be uploaded.Only support image files and document files.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                return false;
            }
        }

        function buttnVisibileFileUpload() {
            var TableRowCount = document.getElementById("TableFileCCN").rows.length;
            addRowtable = document.getElementById("TableFileCCN");
            //    var TableRowCount1 = document.getElementById("TableAddQstnCostCenter" + x).rows.length;
            if (TableRowCount != 0) {
                var idlast = $noCon1('#TableFileCCN tr:last').attr('id');
                if (idlast != "") {
                    var res = idlast.split("_");
                    document.getElementById("FileInx" + res[1]).innerHTML = " ";
                    document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";
                }
            }
        }
        function AddDeletedAttachment(Delrowcount) {
            if (document.getElementById("FileEvt" + Delrowcount).innerHTML == "UPD") {
                var detailId = document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value;
                detailId = detailId + "," + document.getElementById("FileDtlId" + Delrowcount).innerHTML;
                document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value = detailId;
            }

        }
        function CheckAdAttachment() {
            if (document.getElementById("<%=cbxAttachment.ClientID%>").checked == true)
                document.getElementById("<%=divAtchCCN.ClientID%>").style.display = "block";
            else
                document.getElementById("<%=divAtchCCN.ClientID%>").style.display = "none";
        }
        function ChequePrint() {
            document.getElementById("print_cap").click();
            return false;
        }
    </script>
    <script>
        var paymentDone = 0;

        function PaymentCounter() {
            paymentDone++;
            return false;
        }
        function ChangePaymentode(tabName) {
            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                if (paymentDone > 0) {
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to change the payment mode",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            if (tabName == "Cheque_tab") {
                                document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "Cheque";
                                document.getElementById("<%=txtDate_BankTransfer.ClientID%>").value = "";
                                document.getElementById("<%=IBAN_BankTransfer.ClientID%>").value = "";
                                document.getElementById("<%=Bank_BankTransfer.ClientID%>").value = "";
                                $('#cphMain_ddlMode_BankTransfer option').prop('selected', function () {
                                    return this.defaultSelected;
                                });
                                document.getElementById("<%=txtDate_DD.ClientID%>").value = "";
                                document.getElementById("<%=txtDD_DD.ClientID%>").value = "";
                                $('#liBankTransfer').removeClass('active tablinks').addClass('tablinks');
                                $('#BankTransfer').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                                $('#liDD').removeClass('active tablinks').addClass('tablinks');
                                $('#DD').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                                $('#lisCheque').removeClass('tablinks').addClass('active tablinks');
                                $('#Cheque').removeClass('tab2content tab-pane fade').addClass('tab2content tab-pane fade active in');
                                document.getElementById("DD").style.display = "none";
                                document.getElementById("BankTransfer").style.display = "none";
                                document.getElementById("Cheque").style.display = "block";
                                paymentDone = 0;
                            }
                            else if (tabName == "DD_tab") {
                                document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "DD";
                                $('#cphMain_ddlChequeBook_Cheque option').prop('selected', function () {
                                    return this.defaultSelected;
                                });
                                $('#cphMain_ddlChequeNum_Cheque option').prop('selected', function () {
                                    return this.defaultSelected;
                                });
                                document.getElementById("<%=txtDate_Cheque.ClientID%>").value = "";
                                document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").value = "";
                                document.getElementById("<%=txtPayee.ClientID%>").value = "";
                                document.getElementById("<%=ChkStatus_Cheque.ClientID%>").checked = false;
                                document.getElementById("<%=txtDate_BankTransfer.ClientID%>").value = "";
                                document.getElementById("<%=IBAN_BankTransfer.ClientID%>").value = "";
                                document.getElementById("<%=Bank_BankTransfer.ClientID%>").value = "";
                                $('#cphMain_ddlMode_BankTransfer option').prop('selected', function () {
                                    return this.defaultSelected;
                                });
                                $('#liBankTransfer').removeClass('active tablinks').addClass('tablinks');
                                $('#BankTransfer').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                                $('#lisCheque').removeClass('active tablinks').addClass('tablinks');
                                $('#Cheque').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                                $('#liDD').removeClass('tablinks').addClass('active tablinks');
                                $('#DD').removeClass('tab2content tab-pane fade').addClass('tab2content tab-pane fade active in');
                                document.getElementById("BankTransfer").style.display = "none";
                                document.getElementById("DD").style.display = "block";
                                document.getElementById("Cheque").style.display = "none";
                                paymentDone = 0;

                            }
                            else if (tabName == "BankTransfer_tab") {
                                document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "BankTransfer";
                                $('#cphMain_ddlChequeBook_Cheque option').prop('selected', function () {
                                    return this.defaultSelected;
                                });
                                $('#cphMain_ddlChequeNum_Cheque option').prop('selected', function () {
                                    return this.defaultSelected;
                                });
                                document.getElementById("<%=txtDate_Cheque.ClientID%>").value = "";
                                document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").value = "";
                                document.getElementById("<%=txtPayee.ClientID%>").value = "";
                                document.getElementById("<%=txtDate_DD.ClientID%>").value = "";
                                document.getElementById("<%=txtDD_DD.ClientID%>").value = "";
                                $('#liDD').removeClass('active tablinks').addClass('tablinks');
                                $('#DD').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                                $('#lisCheque').removeClass('active tablinks').addClass('tablinks');
                                $('#Cheque').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                                $('#liBankTransfer').removeClass('tablinks').addClass('active tablinks');
                                $('#BankTransfer').removeClass('tab2content tab-pane fade').addClass('tab2content tab-pane fade active in');
                                document.getElementById("BankTransfer").style.display = "block";
                                document.getElementById("DD").style.display = "none";
                                document.getElementById("Cheque").style.display = "none";
                                paymentDone = 0;
                            }
                        }
                        else {
                            if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "Cheque") {
                                $('#liBankTransfer').removeClass('active tablinks').addClass('tablinks');
                                $('#BankTransfer').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                                $('#liDD').removeClass('active tablinks').addClass('tablinks');
                                $('#DD').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                                $('#lisCheque').removeClass('tablinks').addClass('active tablinks');
                                $('#Cheque').removeClass('tab2content tab-pane fade').addClass('tab2content tab-pane fade active in');
                                document.getElementById("DD").style.display = "none";
                                document.getElementById("BankTransfer").style.display = "none";
                                document.getElementById("Cheque").style.display = "block";
                            }
                            else if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "DD") {
                                $('#liBankTransfer').removeClass('active tablinks').addClass('tablinks');
                                $('#BankTransfer').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                                $('#lisCheque').removeClass('active tablinks').addClass('tablinks');
                                $('#Cheque').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                                $('#liDD').removeClass('tablinks').addClass('active tablinks');
                                $('#DD').removeClass('tab2content tab-pane fade').addClass('tab2content tab-pane fade active in');
                                document.getElementById("DD").style.display = "block";
                                document.getElementById("BankTransfer").style.display = "none";
                                document.getElementById("Cheque").style.display = "none";
                            }
                            else if (document.getElementById("<%=HiddenPrevTab.ClientID%>").value == "BankTransfer") {

                                $('#liDD').removeClass('active tablinks').addClass('tablinks');
                                $('#DD').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                                $('#lisCheque').removeClass('active tablinks').addClass('tablinks');
                                $('#Cheque').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                                $('#liBankTransfer').removeClass('tablinks').addClass('active tablinks');
                                $('#BankTransfer').removeClass('tab2content tab-pane fade').addClass('tab2content tab-pane fade active in');
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
                        document.getElementById("<%=IBAN_BankTransfer.ClientID%>").value = "";
                        document.getElementById("<%=Bank_BankTransfer.ClientID%>").value = "";
                        $('#cphMain_ddlMode_BankTransfer option').prop('selected', function () {
                            return this.defaultSelected;
                        });
                        document.getElementById("<%=txtDate_DD.ClientID%>").value = "";
                        document.getElementById("<%=txtDD_DD.ClientID%>").value = "";
                        $('#liBankTransfer').removeClass('active tablinks').addClass('tablinks');
                        $('#BankTransfer').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                        $('#liDD').removeClass('active tablinks').addClass('tablinks');
                        $('#DD').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                        $('#lisCheque').removeClass('tablinks').addClass('active tablinks');
                        $('#Cheque').removeClass('tab2content tab-pane fade').addClass('tab2content tab-pane fade active in');
                        paymentDone = 0;
                        document.getElementById("DD").style.display = "none";
                        document.getElementById("BankTransfer").style.display = "none";
                        document.getElementById("Cheque").style.display = "block";
                    }
                    else if (tabName == "DD_tab") {
                        document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "DD";
                        $('#cphMain_ddlChequeBook_Cheque option').prop('selected', function () {
                            return this.defaultSelected;
                        });
                        $('#cphMain_ddlChequeNum_Cheque option').prop('selected', function () {
                            return this.defaultSelected;
                        });
                        document.getElementById("<%=txtDate_Cheque.ClientID%>").value = "";
                        document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").value = "";
                        document.getElementById("<%=ChkStatus_Cheque.ClientID%>").checked = false;
                        document.getElementById("<%=txtPayee.ClientID%>").value = "";
                        document.getElementById("<%=txtDate_BankTransfer.ClientID%>").value = "";
                        document.getElementById("<%=IBAN_BankTransfer.ClientID%>").value = "";
                        document.getElementById("<%=Bank_BankTransfer.ClientID%>").value = "";
                        $('#cphMain_ddlMode_BankTransfer option').prop('selected', function () {
                            return this.defaultSelected;
                        });
                        $('#liBankTransfer').removeClass('active tablinks').addClass('tablinks');
                        $('#BankTransfer').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                        $('#lisCheque').removeClass('active tablinks').addClass('tablinks');
                        $('#Cheque').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                        $('#liDD').removeClass('tablinks').addClass('active tablinks');
                        $('#DD').removeClass('tab2content tab-pane fade').addClass('tab2content tab-pane fade active in');
                        paymentDone = 0;
                        document.getElementById("BankTransfer").style.display = "none";
                        document.getElementById("DD").style.display = "block";
                        document.getElementById("Cheque").style.display = "none";

                    }
                    else if (tabName == "BankTransfer_tab") {
                        document.getElementById("<%=HiddenPrevTab.ClientID%>").value = "BankTransfer";
                        $('#cphMain_ddlChequeBook_Cheque option').prop('selected', function () {
                            return this.defaultSelected;
                        });
                        $('#cphMain_ddlChequeNum_Cheque option').prop('selected', function () {
                            return this.defaultSelected;
                        });
                        document.getElementById("<%=txtDate_Cheque.ClientID%>").value = "";
                        document.getElementById("<%=txtIssueDate_Cheque.ClientID%>").value = "";
                        document.getElementById("<%=txtPayee.ClientID%>").value = "";
                        document.getElementById("<%=txtDate_DD.ClientID%>").value = "";
                        document.getElementById("<%=txtDD_DD.ClientID%>").value = "";
                        $('#liDD').removeClass('active tablinks').addClass('tablinks');
                        $('#DD').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                        $('#lisCheque').removeClass('active tablinks').addClass('tablinks');
                        $('#Cheque').removeClass('tab2content tab-pane fade active in').addClass('tab2content tab-pane fade');
                        $('#liBankTransfer').removeClass('tablinks').addClass('active tablinks');
                        $('#BankTransfer').removeClass('tab2content tab-pane fade').addClass('tab2content tab-pane fade active in');
                        document.getElementById("BankTransfer").style.display = "block";
                        document.getElementById("DD").style.display = "none";
                        document.getElementById("Cheque").style.display = "none";
                        paymentDone = 0;
                    }
                    return false;
                }
        }
        else {

            document.getElementById("Cheque_tab").disabled = true;
            document.getElementById("DD_tab").disabled = true;
            document.getElementById("BankTransfer_tab").disabled = true;
        }
    }

    function suply1(PurchaseId) {
        if (document.getElementById("DebitNoteSettle_Status" + PurchaseId).checked == true) {
            document.getElementById("ddlDebitNote" + PurchaseId).disabled = false;
            document.getElementById("txtDebitNotetxtAmt" + PurchaseId).disabled = false;
        } else {
            $("select#ddlDebitNote" + PurchaseId).val('0');
            document.getElementById("txtDebitNotetxtAmt" + PurchaseId).value = "";
            document.getElementById("ddlDebitNote" + PurchaseId).disabled = true;
            document.getElementById("txtDebitNotetxtAmt" + PurchaseId).disabled = true;
        }
        loadSettleAmount(PurchaseId);//evm 0044
    }
    function ShowDebitNoteBalance(PurchaseId) {
        var DebitNoteId = document.getElementById("ddlDebitNote" + PurchaseId).value;
        var tdLedgerRow = document.getElementById("tdLedgerRow" + PurchaseId).innerHTML;
        var LedgerId = document.getElementById("ddlRecptLedger" + tdLedgerRow).value;
        var corpid = '<%= Session["CORPOFFICEID"] %>';
            var orgid = '<%= Session["ORGID"] %>';
            $.ajax({
                async: false,
                type: "POST",
                url: "fms_Payment_Account.aspx/LoadDebitNoteBalance",
                data: '{DebitNoteId:"' + DebitNoteId + '",corpid:"' + corpid + '",orgid:"' + orgid + '",LedgerId:"' + LedgerId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d != "") {
                        addCommasSummry(response.d);
                        document.getElementById("DebitNoteBalance" + PurchaseId).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                        document.getElementById("tdDebitBalanceAmt" + PurchaseId).innerHTML = response.d;
                        document.getElementById("txtDebitNotetxtAmt" + PurchaseId).value = ""
                    }
                    else {
                        document.getElementById("DebitNoteBalance" + PurchaseId).innerHTML = "";
                        document.getElementById("tdDebitBalanceAmt" + PurchaseId).innerHTML = "";
                        document.getElementById("txtDebitNotetxtAmt" + PurchaseId).value = ""
                    }
                },
                failure: function (response) {

                }
            });
    }


        function ChequeNoDuplicate() {
            $noCon("#divWarning").html("Cheque number is already used!.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        //evm 0044
        function clearData() {
            document.getElementById("lblSetleAmt").innerHTML = "";
            document.getElementById("lblBlncAmt").innerHTML = "";
        }
        function setData(id, data) {
            document.getElementById(id).innerText = data;
        }
        function clearLabelData() {

            document.getElementById("lblSetleAmt").innerHTML = "";
            document.getElementById("lblBlncAmt").innerHTML = "";
            document.getElementById("lblSetle").innerText = "";
            document.getElementById("lblDebit").innerText = "";
            //0043
            document.getElementById("lblExpenc").innerText = "";
        }
        function loadSettleAmount(x) {

            //alert(x);
            var purchAmt = 0;
            var opBalance = 0;
            var debitAmt = 0;
            clearLabelData();
            if (x != -1) {
                P_Id = x;
                document.getElementById("lblOpBalance").innerText = "";
            }


            var addRowtable = document.getElementById("TableAddQstn");
            if (typeof addRowtable !== 'undefined' && addRowtable !== null) {
                var j = 1;

                if (document.getElementById("<%=HiddenOBstatus.ClientID%>").value == "1") {
                    j++;
                }
                var elem = document.getElementById("txtDebitNotetxtAmt" + P_Id);
                if (typeof elem !== 'undefined' && elem !== null) {
                    for (var i = j; i < addRowtable.rows.length; i++) {//2nd row onwards
                        var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
                        var rcptAmt2d = document.getElementById("txtDebitNotetxtAmt" + P_Id).value.replace(/\,/g, '');
                        if (rcptAmt2d == "") {
                            rcptAmt2d = "0";

                        }
                        debitAmt = parseFloat(debitAmt) + parseFloat(rcptAmt2d);
                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                        debitAmt = parseFloat(debitAmt);
                        if (FloatingValue != "") {
                            debitAmt = debitAmt.toFixed(FloatingValue);

                        }

                        document.getElementById("lblDebit").innerText = debitAmt.replace(/\,/g, '');


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
                        purchAmt = parseFloat(purchAmt) + parseFloat(rcptAmt);


                    }


                    purchAmt = parseFloat(purchAmt);
                    //alert(purchAmt);
                    if (FloatingValue != "") {
                        purchAmt = purchAmt.toFixed(FloatingValue);

                    }
                    document.getElementById("lblSetle").innerText = purchAmt.replace(/\,/g, '');
                }
            }


            //EVM-0043 start
            //var addRowExpense = document.getElementById("DivPopupSales");
            //var expnsAmt = 0;
            //var ret = true;
            //var DebitFlag = true;

            //for (var i = 0; i < addRowExpense.rows.length; i++) {//2nd row onwards
            //    var P_Id = (addRowExpense.rows[i].cells[0].innerHTML);
            //    //alert(P_Id);

            //    var SalesAmtd = 0;
            //    var rcptAmt = document.getElementById("txtExpenseAmt" + P_Id).value;
            //    if (rcptAmt == "") {
            //        rcptAmt = "0";
            //    }
            //    else {
            //        rcptAmt = rcptAmt.replace(/\,/g, '');
            //    }
            //    expnsAmt = parseFloat(expnsAmt) + parseFloat(rcptAmt);
            //}

            ////alert(expnsAmt);
            //expnsAmt = parseFloat(expnsAmt);
            ////alert(purchAmt);
            //if (FloatingValue != "") {
            //    expnsAmt.toFixed(FloatingValue);
            //}
            //document.getElementById("lblExpenc").innerText = expnsAmt;

            //var expnsSettleAmt = document.getElementById("lblExpenc").innerText.replace(/\,/g, '');

            //end




            var opBalance = document.getElementById("lblOpBalance").innerText.replace(/\,/g, '');
            //alert(opBalance);
            // alert("op"+opBalance);
            var settleamt = document.getElementById("lblSetle").innerText.replace(/\,/g, '');
            //alert("setle"+settleamt);
            var dbitAmt = document.getElementById("lblDebit").innerText.replace(/\,/g, '');
            //alert("debit"+dbitAmt);
            var blnctamt;
            var ldgramt = document.getElementById("LedgerAmtInModalPurchse").innerText.replace(/\,/g, '');

            var ldgramt1 = ldgramt.split(" ");
            ldgramt = ldgramt1[0].replace(/,/g, "");
            //alert("ledger" + ldgramt);
            var totalamt = 0;
            totalamt = Number(opBalance) + Number(settleamt) + Number(dbitAmt);
                //+ Number(expnsSettleAmt);
            blnctamt = Number(ldgramt) - Number(totalamt);
            //alert("balance"+blnctamt);
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
                document.getElementById("lblSetleAmt").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + "  " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                blnctamt = addCommasSummry(blnctamt);
                document.getElementById("lblBlncAmt").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + "  " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            }
        }
            //-------------

        //0043
        function AmountCalculationExpense(ExpenseId) {
            var ret = true;

            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            AmountChecking("txtExpenseAmt" + ExpenseId);
            //evm-0043 start 20-03
            var tdStatus = document.getElementById("tdStatus" + ExpenseId).innerHTML;
        
            //end
            var tdLedgerRow = document.getElementById("tdLedgerRow" + ExpenseId).innerHTML;

            var Expense = document.getElementById("txtExpenseAmt" + ExpenseId).value;
            var tdAmnt = document.getElementById("tdAmnt" + ExpenseId).innerHTML;
            tdAmnt = tdAmnt.replace(/\,/g, '');
            var PymntExpnsDiif = 0;

            Expense = Expense.replace(/\,/g, '');
            document.getElementById("txtExpenseAmt" + ExpenseId).style.borderColor = "";
            if (tdAmnt != "" && Expense != "") {
                PymntExpnsDiif = parseFloat(tdAmnt) - parseFloat(Expense);
                PymntExpnsDiif = PymntExpnsDiif.toFixed(FloatingValue);
                //alert(tdAmnt + "-" + Expense);
                addCommasSummry(PymntExpnsDiif);
                document.getElementById("AccntBalanceExpns" + ExpenseId).innerHTML = "<i  class=\"fa fa-money\"></i>  " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
            }
            else {
                document.getElementById("AccntBalanceExpns" + ExpenseId).innerHTML = "";
            }

            var expenseAmt = document.getElementById("txtExpenseAmt" + ExpenseId).value;
            expenseAmt = expenseAmt.replace(/\,/g, '');
            if (expenseAmt != "") {
                if (parseFloat(expenseAmt) > parseFloat(tdAmnt)) {
                    document.getElementById("lblErrMsgCancelReason").innerHTML = "Expense total amount should be less than the payment amount";
                    $("div.war").fadeIn(200).delay(500).fadeOut(400);
                    ret = false;
                }
            }
            //alert(ret);

            var TxtTotal = 0;
            var TotalExpenseAmnt = 0;

            var addRowtable = document.getElementById("TableAddQstn");
            for (var i = 1; i < addRowtable.rows.length; i++) {
                var E_Id = (addRowtable.rows[i].cells[0].innerHTML);
                var tdAmnt = document.getElementById("tdAmnt" + E_Id).innerHTML;
                var Amt = 0;
                document.getElementById("txtPurchaseAmt" + E_Id).style.borderColor = "";
                if (document.getElementById("txtPurchaseAmt" + E_Id).value != "") {
                    Amt = document.getElementById("txtPurchaseAmt" + E_Id).value;
                    Amt = Amt.replace(/\,/g, '');
                    TotalExpenseAmnt = parseFloat(TotalExpenseAmnt) + parseFloat(Amt);
                }
            }


            var addRowtable = document.getElementById("TableExpense");
            for (var i = 0; i < addRowtable.rows.length; i++) {
                var E_Id = (addRowtable.rows[i].cells[0].innerHTML);
                var tdAmnt = document.getElementById("tdAmnt" + E_Id).innerHTML;
                var expnsAmt = 0;
                document.getElementById("txtExpenseAmt" + E_Id).style.borderColor = "";
                if (document.getElementById("txtExpenseAmt" + E_Id).value != "") {
                    expnsAmt = document.getElementById("txtExpenseAmt" + E_Id).value;
                    expnsAmt = expnsAmt.replace(/\,/g, '');
                    TotalExpenseAmnt = parseFloat(TotalExpenseAmnt) + parseFloat(expnsAmt);
                }
            }

            addCommas("txtExpenseAmt" + ExpenseId);
            TxtTotal = document.getElementById("txtAmntVal" + tdLedgerRow).value;
            if (parseFloat(TotalExpenseAmnt) > parseFloat(TxtTotal)) {
                clearData();
                if (document.getElementById("txtExpenseAmt" + ExpenseId).value != "") {
                    addCommasSummry(TotalExpenseAmnt);
                    document.getElementById("lblErrMsgCancelReason").innerHTML = "Expense total amount should be less than the payment amount";
                    $("div.war").fadeIn(200).delay(500).fadeOut(400);
                    ret = false;
                }
            }

            var purchaseAmt = document.getElementById("txtExpenseAmt" + ExpenseId).value;

            loadSettleAmount(ExpenseId);

            //alert(ret);

            return ret;
        }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">


  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>


        <asp:HiddenField ID="HiddenFieldRecurrencyPeriod" runat="server" />
      <asp:HiddenField ID="HiddenFieldRemindDays" runat="server" />

    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" />
    <asp:HiddenField ID="HiddentxtefctvedateTo" runat="server" />
    <asp:HiddenField ID="HiddenFieldTaxId" runat="server" />
    <asp:HiddenField ID="HiddenChkSts" runat="server" />
    <asp:HiddenField ID="HiddenupdCheckNumber" runat="server" />
    <asp:HiddenField ID="HiddenView" runat="server" />
    <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="hiddenLedgerddl" runat="server" />
    <asp:HiddenField ID="hiddenCostCenterddl" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="HiddenCurrencyAbrv" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="HiddenSequenceRef" runat="server" />
    <asp:HiddenField ID="Hiddenreturnfun" runat="server" />
    <asp:HiddenField ID="HiddenPresentDate" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYearId" runat="server" />
    <asp:HiddenField ID="HiddenFieldSaveAccount" runat="server" />
    <asp:HiddenField ID="HiddenFieldView" runat="server" />
    <asp:HiddenField ID="hiddenLedgerCanclDtlId" runat="server" />
    <asp:HiddenField ID="hiddenQstnCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenCostCenterEdit" runat="server" />
    <asp:HiddenField ID="HiddenPurchaseEdit" runat="server" />
    <asp:HiddenField ID="HiddenGrdTotl" runat="server" />
    <asp:HiddenField ID="HiddenPrevTab" runat="server" />
    <asp:HiddenField ID="HiddenEdit" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYrStartDate" runat="server" />
    <asp:HiddenField ID="HiddenStartDate" runat="server" />
    <asp:HiddenField ID="HiddenConfirmProvisionStatus" runat="server" />
    <asp:HiddenField ID="HiddenAcntClsSts" runat="server" />
    <asp:HiddenField ID="HiddenAuditProvisionStatus" runat="server" />
    <asp:HiddenField ID="HiddenFieldAcntCloseReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenAuditClsDate" runat="server" />
    <asp:HiddenField ID="HiddenAcntClsDate" runat="server" />
    <asp:HiddenField ID="HiddenRefNum" runat="server" />
    <asp:HiddenField ID="HiddenUpdatedDate" runat="server" />
    <asp:HiddenField ID="HiddenRestritionStatus" runat="server" />
    <asp:HiddenField ID="HiddenRefAccountCls" runat="server" />
    <asp:HiddenField ID="HiddenUpdRefNum" runat="server" />
    <asp:HiddenField ID="HiddenPaymentID" runat="server" />
    <asp:HiddenField ID="HiddenChequeBookId" runat="server" />
    <asp:HiddenField ID="HiddenReOpenStatus" runat="server" />
    <asp:HiddenField ID="HiddenCostGroup1ddl" runat="server" />
    <asp:HiddenField ID="HiddenCostGroup2ddl" runat="server" />
    <asp:HiddenField ID="hiddenFileCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenEditAttachment" runat="server" />
    <asp:HiddenField ID="HiddenUploadInfo" runat="server" />
    <asp:HiddenField ID="hiddenFilePath" runat="server" />
    <asp:HiddenField ID="HiddenExchngCurrency" runat="server" />
    <asp:HiddenField ID="hiddenPostdated" runat="server" />
    <asp:HiddenField ID="hiddenSelectedAccntBk" runat="server" />
    <asp:HiddenField ID="HiddenOBstatus" runat="server" />
    <asp:HiddenField ID="HiddenLedgrDupSts" runat="server" />
     <asp:HiddenField ID="hiddenInsUser" runat="server" />
    <asp:HiddenField ID="HiddenFieldExpncId" runat="server" />


    <div id="divLinkSection" runat="server">
        <ol class="breadcrumb sticky1">
            <li><a id="aHome" runat="server" href="">Home</a></li>
            <li><a id="aDashBord" runat="server" href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
            <li><a href="fms_Payment_Account_List.aspx">Payment</a></li>
            <li class="active">Add Payment</li>
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
                        <h2><asp:Label ID="lblEntry" runat="server"></asp:Label></h2>
                    </div>
                    
                    
                    <div class="form-group fg2">
                        <label for="email" class="fg2_la1">Payment REF#: <span class="spn1">&nbsp;</span></label>
                        <input id="TxtRef" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control fg2_inp1" maxlength="50" />
                    </div>
                    <div class="form-group fg2">
                        <label for="pwd" class="fg2_la1 fg_9">
                            Account Book:<span class="spn1">*</span>
                            <span id="AccntBalance" runat="server" class="input-group-addon cur2 c2h flt_amt1" style=""></span>
                        </label>
                        <div id="divAccount">
                            <asp:DropDownList ID="ddlAccontLed" class="form-control fg2_inp1 fg_chs1 inp_mst ddl" Style="width: 232px;" onchange="return AccntChangeFunt(null,1);" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group fg2">
                        <div id="DivPaymentDate" class="tdte">
                            <label for="pwd" class="fg2_la1">Date:<span class="spn1"></span> </label>
                            <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                                <input id="txtdate" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr" onchange="showFromDate()" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                <span id="PaymentDatePikrSpan" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                            </div>
                        </div>
                        <script>
                            var StartDate = "";
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
                    <div class="form-group fg2" style="display: none;">
                        <label for="email" class="fg2_la1 pad_l">Postdated Cheque Payment:<span class="spn1">&nbsp;</span></label>
                        <div class="check1">
                            <div class="">
                                <label class="switch">
                                    <input type="checkbox" id="postdate">
                                    <span class="slider_tog round"></span>
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class="clearfix"></div>
                    <div class="devider"></div>

                    <div class="tabl_1" id="dvledg">

                        <table id="tableGrp" class="table table-bordered">
                            <thead class="thead1">
                                <tr>
                                    <th class="col-md-5 t_r">Particulars</th>
                                    <th class="col-md-2 tr_c">Amount</th>
                                    <th class="col-md-2 tr_l">Remarks</th>
                                    <th class="col-md-1 tr_c">Actions</th>
                                    <th class="col-md-2 tr_c">Purchase/CC</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>


                    </div>


                    <div id="PaymentMode">
                            <div class="clearfix"></div>
                            <div class="free_sp"></div>
                            <div class="devider"></div>
                            <div class="tab2">
                                <button id="lisCheque" class="active tablinks" onclick="return ChangePaymentode('Cheque_tab');">Cheque</button>
                                <button id="liDD" class="tablinks" onclick="return ChangePaymentode('DD_tab');">DD</button>
                                <button id="liBankTransfer" class="tablinks" onclick="return ChangePaymentode('BankTransfer_tab');">Bank Transfer</button>
                            </div>
                            <div id="Cheque" class="tab2content">
                                <div class="fg2">
                                    <label for="pwd" class="fg2_la1">Cheque Book:<span class="spn1">*</span></label>
                                    <asp:DropDownList ID="ddlChequeBook_Cheque" class="form-control fg2_inp1 fg_chs1 inp_mst" onchange="LoadChequeBookNum(null,'0');" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="fg2">
                                    <label for="email" class="fg2_la1">Cheque#:<span class="spn1">*</span></label>

                                    <asp:DropDownList ID="ddlChequeNum_Cheque" class="form-control fg2_inp1 fg_chs1 inp_mst" Style="" onchange="SaveChequeBookNum();" runat="server" maxlength="7">
                                        <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="fg2">
                                    <div class="tdte">
                                        <label for="pwd" class="fg2_la1">Cheque Date:<span class="spn1">*</span></label>
                                        <div id="datepicker3" class="input-group date" data-date-format="mm-dd-yyyy">
                                            <input id="txtDate_Cheque" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr inp_mst" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                            <span id="ChequeDatePikrSpan" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                                            <script>
                                                var StartDate = "";
                                                if (document.getElementById("<%=HiddenRestritionStatus.ClientID%>").value == "1")
                                                    StartDate = document.getElementById("<%=HiddenFinancialYrStartDate.ClientID%>").value;
                                                else
                                                    StartDate = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
                                                var curentDate = "";
                                                curentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value
                                                $noCon('#datepicker3').datepicker({
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
                                <div class="form-group fg2">
                                    <label for="email" class="fg2_la1">Payee Name:<span class="spn1">*</span></label>
                                    <input id="txtPayee" autocomplete="off" runat="server" type="text" onblur="return textCounter1(cphMain_txtPayee,50,event)" onkeypress="return textCounter1(cphMain_txtPayee,50,event)" class="form-control fg2_inp1 inp_mst" maxlength="50" />

                                </div>
                                <div class="fg2">
                                    <label for="email" class="fg2_la1 pad_l">Cheque Issued:<span class="spn1">&nbsp;</span></label>
                                    <div class="check1">
                                        <div class="">
                                            <label class="switch">
                                                <input type="checkbox" runat="server" checked="checked" onkeydown="PaymentCounter();" onchange="return IssueDateCheck()" onkeypress="return DisableEnter(event)" id="ChkStatus_Cheque" />
                                                <span class="slider_tog round"></span>
                                            </label>
                                        </div>
                                    </div>

                                </div>
                                <div class="fg2">
                                    <div class="tdte">
                                        <label for="pwd" class="fg2_la1">Cheque Issued Date:<span class="spn1"></span> </label>
                                        <div id="DivDatePickerChequeIssue" class="input-group date" data-date-format="mm-dd-yyyy">
                                            <input id="txtIssueDate_Cheque" disabled="" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                            <span id="ChequeIssueDatePikrSpan" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                                            <script>
                                                var StartDate = "";
                                                if (document.getElementById("<%=HiddenRestritionStatus.ClientID%>").value == "1")
                                                    StartDate = document.getElementById("<%=HiddenFinancialYrStartDate.ClientID%>").value;
                                                else
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


                                                    <div id="DD" class="tab2content">
                                <div class="fg2">
                                    <label for="email" class="fg2_la1">DD#:<span class="spn1">*</span></label>
                                    <input id="txtDD_DD" onblur="PaymentCounter();" autocomplete="off" runat="server" type="text" onkeyup="return DisableEnter(event)" onkeypress="return isNumberAmount(event)" onkeydown="return isNumberAmount(event)" class="form-control fg2_inp1 inp_mst" maxlength="10" />
                                </div>
                                <div class="fg2">
                                    <div class="tdte">
                                        <label for="pwd" class="fg2_la1">DD Date:<span class="spn1">*</span> </label>
                                        <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                                            <input id="txtDate_DD" readonly="readonly" runat="server" type="text" onkeydown=" PaymentCounter();" onkeypress="return DisableEnter(event)" class="form-control inp_bdr inp_mst" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                            <span id="DD_DatePikrSpan" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                                            <script>
                                                var curentDate = "";
                                                curentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value
                                                var StartDate = "";
                                                StartDate = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
                                                $noCon('#datepicker').datepicker({
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

                            <div id="BankTransfer" class="tab2content">
                                <div class="fg2">
                                    <label for="pwd" class="fg2_la1">Mode:<span class="spn1">*</span></label>
                                    <asp:DropDownList ID="ddlMode_BankTransfer" class="form-control fg2_inp1 fg_chs1 inp_mst" onchange=" PaymentCounter();" Style="" runat="server">
                                        <asp:ListItem Text="IMPS" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="NEFT" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="RTGS" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="OTHERS" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="fg2">
                                    <div class="tdte">
                                        <label for="pwd" class="fg2_la1">Transfer Date:<span class="spn1">*</span> </label>
                                        <div id="datepicker4" class="input-group date" data-date-format="mm-dd-yyyy">
                                            <input id="txtDate_BankTransfer" readonly="readonly" autocomplete="off" onkeydown=" PaymentCounter();"  runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr inp_mst" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                            <span id="Transfer_DatePikrSpan" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                                        </div>
                                        <script>

                                            var curentDate = "";
                                            curentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value
                                            var StartDate = "";
                                            StartDate = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
                                            $noCon('#datepicker4').datepicker({
                                                autoclose: true,
                                                format: 'dd-mm-yyyy',
                                                startDate: StartDate,
                                                endDate: curentDate,
                                                timepicker: false
                                            });
                                        </script>
                                    </div>
                                </div>
                                <div class="fg2">
                                    <label for="email" class="fg2_la1">Bank:<span class="spn1">*</span></label>
                                    <input id="Bank_BankTransfer" style="width: 100%; margin-left: 2%; float: right; text-align: left;" onblur="return textCounter1(cphMain_Bank_BankTransfer,50,event)" autocomplete="off" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control fg2_inp1 inp_mst" maxlength="50" />
                                </div>

                                <div class="fg2">
                                    <label for="email" class="fg2_la1">IBAN#:<span class="spn1">*</span></label>
                                    <input id="IBAN_BankTransfer" onblur="PaymentCounter();" autocomplete="off" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control fg2_inp1 inp_mst" maxlength="50" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="free_sp"></div>

                     </div>

                    <div class="clearfix"></div>
                    <div class="free_sp"></div>

                    <div class="text_area_container">
                        <div class="col-md-8 ma_at_fl">
                            <div class="form-group">
                                <label for="email" class="fg2_la1">Narration<span class="spn1">&nbsp;</span></label>
                                <textarea id="txtDescription" class="form-control" runat="server" rows="4" cols="50" maxlength="450" onblur="return textCounter(cphMain_txtDescription, 450)" style="resize: none;">
                                </textarea>
                            </div>
                        </div>
                       
                        <div class="col-md-3 txt_alg flt_pr">
                            <label for="email" class="fg2_la1">Total Amount:<span class="spn1">&nbsp;</span></label>
                            <div class="input-group">
                                <span class="input-group-addon cur1">
                                    <label for="example-text-input" class="col-form-label" id="lblCurrency"></label>
                                </span>
                                <input id="txtGrantTotal" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control fg2_inp2 tr_r" maxlength="50" />

                            </div>

                             <div  style="margin-top:5%;" id="divRecur" runat="server">
                            <a href="#" id="popup-btn"><i class="fa fa-retweet gre" title="Recurring"></i></a>
                        </div>

                        </div>
                    </div>

                 <div class="clearfix"></div>
                <div class="devider divid"></div>

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
      



                 <div class="sub_cont pull-right">
                        <div class="save_sec">

                            <asp:Button ID="bttnsave" runat="server" class="btn sub1" Text="Save" OnClientClick="return ValidateReceiptAccnt();" OnClick="bttnsave_Click" />
                            <asp:Button ID="btnSaveCls" runat="server" class="btn sub3" Text="Save & Close" OnClientClick="return ValidateReceiptAccnt();" OnClick="bttnsave_Click" />
                            <asp:Button ID="btnUpdate" runat="server"  class="btn sub1" OnClientClick="return ValidateReceiptAccnt();" OnClick="btnUpdate_Click" Text="Update" />
                            <asp:Button ID="btnUpdateClose" runat="server" OnClientClick="return ValidateReceiptAccnt();" class="btn sub3" OnClick="btnUpdate_Click" Text="Update & Close" />
                            <asp:Button ID="btnConfirm" runat="server" OnClientClick="return ConfirmAlert();" class="btn sub2" Text="Confirm" />
                            <asp:Button ID="btnConfirm1" runat="server" OnClientClick="return ValidateReceiptAccnt();" class="btn btn-primary btn-grey  btn-width" OnClick="btnUpdate_Click" Text="confm" Style="display: none;" />
                            <asp:Button ID="btnReopen" runat="server" class="btn sub2" Text="Reopen" OnClientClick="return ConfirmReopen();" />
                            <asp:Button ID="btnReopen1" runat="server" class="btn btn-primary" Style="display: none" Text="Reopen" OnClick="btnReopen_Click" />
                            <input type="button" id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
                            <asp:Button ID="ButtnClose" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                            <asp:Button ID="btnPRint" runat="server" class="btn sub2" Text="Print" OnClientClick="return OpenPrint();" />
                <asp:Button ID="btnPRintCheque" runat="server" class="btn sub3" Text="Print Cheque" OnClientClick="return  ChequePrint();" />

                        </div>
                    </div>

                  <div id="divList" runat="server" class="list_b" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
                        <i class="fa fa-arrow-circle-left"></i>
                    </div>


                <div class="mySave1" id="mySave" runat="server">
                    <div class="save_sec">
                        <asp:Button ID="btnFloatSave" runat="server" OnClientClick="return ValidateReceiptAccnt();" OnClick="bttnsave_Click" class="btn sub1" Text="Save" />
                        <asp:Button ID="btnFloatSaveCls" runat="server" OnClientClick="return ValidateReceiptAccnt();" class="btn sub3" Text="Save & Close" OnClick="bttnsave_Click" />
                        <asp:Button ID="btnFloatUpdate" runat="server" OnClientClick="return ValidateReceiptAccnt();" class="btn sub1" OnClick="btnUpdate_Click" Text="Update" />
                        <asp:Button ID="btnFloatUpdateCls" runat="server" OnClientClick="return ValidateReceiptAccnt();" class="btn sub3" OnClick="btnUpdate_Click" Text="Update & Close" />
                        <asp:Button ID="btnFloatConfirm" runat="server" OnClientClick="return ConfirmAlert();" class="btn sub2" Text="Confirm" />
                        <asp:Button ID="btnFloatReopen" runat="server" class="btn sub2" Text="Reopen" OnClientClick="return ConfirmReopen();" />
                        <input type="button" id="btnFloatCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
                        <asp:Button ID="ButtnFloatClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                        <asp:Button ID="btnFloatPrint" runat="server" class="btn sub2" Text="Print" OnClientClick="return OpenPrint();" />
                <asp:Button ID="btnFloatPRintCheque" runat="server" class="btn sub3" Text="Print Cheque" OnClientClick="return  ChequePrint();" />

                    </div>
                    </div>


               
            </div>
        </div>
      </div>

    <button id="BtnPopup" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>
    <button id="BtnPopupCstCntr" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModalCstCntr">Open Modal</button>

    <label id="RefLabel" runat="server"></label>

    <!-- Modal -->
    <div class="modal fade" id="myModal" data-backdrop="static" role="dialog" tabindex="-1"  >
        <div class="modal-dialog mod2 mo3" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 id="ModelHeading" class="modal-title"></h2>
                    <h2 class="modal-title mod1 flt_l" id="PurchaseName"><i class="fa fa-business-time"></i></h2>
                    <button type="button" class="close" onclick="return CloseModalPurchase()">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body md_bd1 mdl_mx_h">
                    <div class="al-box war" id="lblErrMsgCancelReason">Please fill this out</div>
             <%--       evm-0043 start 20-03--%>
                    <table id="TableAddQstn" class="table table-bordered">
                        <thead class="thead1">
                            <tr>
                               <th class="th_b2 td1">Purchase/Sales<br /> Ref#
                                </th>
                                <th class="th_b6">Purchase/<br />Sales Date
                                </th>
                                <th class="th_b2">Expense<br/>Ref#
                                </th>
                                <th class="th_b2 tr_r">Amount<span class="cur_ic"><label id="lblCurrncy1"></label></span>
                                </th>
                                <th class="th_b11">Settlement Amount<span class="cur_ic"><label id="lblCurrncy2"></label></span>
                                </th>
                                <th  class="th_b6">Settlement
                                </th>
                               <th class="th_b4 tr_l">Debitnote <span class="cur_ic"><label id="lblCurrncy3"></label></span>
                                </th>
                               <th class="th_b2">Settlement Amount <span class="cur_ic"><label id="lblCurrncy4"></label></span>
                               </th>
                            </tr>
                        </thead>
                        <tbody id="DivPopUpSales">
                        </tbody>
                    </table>
<%--                    <div class="clearfix"></div>
                    <div class="devider"></div>

                    <div class="col-md-12 col_mar">
                        <div class="col-md-6">
                            <label for="email" class="fg2_la1 tt_am am1">Net Amount<span class="spn1"></span>:</label>
                        </div>
                        <div class="col-md-6 flt_pr">
                            <span id="LedgerAmtInModalPurchse" class="tt_am am1 tt_al"></span>
                            <label class="col-md-1 col-form-label" style="" id="CurrencyAb"></label>
                        </div>
                    </div>--%>


                   <%-- evm-0043 start 20-03--%>
        <table id=""class="table table-bordered tbl_slf">
            <thead class="thead1" style="display:none">
              <tr>
                <th class="th_b7 td1">Expense Ref#</th>
                <th class="th_b1">Sales Ref#</th>
                <th class="th_b1">Sales Date</th>
                <th class="th_b7 tr_r">Amount <span class="cur_ic"><label id="lblcur1"></label></span>
                </th>
                <th class="th_b2">Settlement Amount <span class="cur_ic"><label id="lblcur2"></label></span>
                </th>
                <th class="th_b7">Settlement
                </th>
                <th class="th_b11 tr_l">Debitnote <span class="cur_ic"><label id="lblcur3"></label></span>
                </th>
                <th class="th_b4">Settlement Amount <span class="cur_ic"><label id="lblcur4"></label></span>
                </th>
              </tr>
            </thead>
                         <tbody id="TableExpense">
                        </tbody>
         </table>
                   <%-- end--%>




                </div>
                     <div class="modal-footer">
               <div class="col-md-12">
          <div class="col-md-3 flt_r tr_l">
           <label class="fg2_la1 tt_am am12 tr_l">SETTLEMENT</label></div>

      <div class="col-md-12">
        <div class="col-md-10">
      <label class="fg2_la1 tt_am am1 tr_r">Payment Amount<span class="spn1"></span>:</label></div>
       <div class="col-md-2" ><span id="LedgerAmtInModalPurchse"  class="tt_am am1_n tr_r"></span></div>
        </div>

      <div class="col-md-12">
        <div class="col-md-10">
        <label class="fg2_la1 tt_am am1 tr_r">Settled Amount<span class="spn1"></span>:</label></div>

           <label id="lblOpBalance" style="display: none;"><span></span></label>
           <label id="lblSetle" style="display: none;"><span></span></label>
           <label id="lblDebit" style="display: none;"><span></span></label>
           <label id="lblExpenc" style="display:none;"><span></span></label>

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

                    <button id="btnImportSales" type="button" class="btn btn-success" onclick="ButtnFillClickSales();">Submit</button>
                    <button type="button" class="btn btn-danger" onclick="return CloseModalPurchase()">Cancel</button>
                    <button id="BttnTemp" type="button" style="display: none" class="btn btn-primary" data-dismiss="modal" onclick ="clearData();"></button><%--evm 0044 onclick added--%>
                </div>
            </div>
        </div>
    </div>


    <div id="CostCenterModal"></div>


    <div class="popup-flex">
<div id="popup-wrapper" class="popup-container">
  <div class="popup-content">
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


    <div>
        <div class="col-md-12" style="padding: 9px;">
            <div style="float: right;">


                <a id="print_cap" target="_blank" href="/FMS/FMS_Master/fms_Payment_Account/19_Print.htm" style="display: none;" />

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

                <%--<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-upload" style="margin-right:10px;"></i>Update</button>
<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-check" style="margin-right:10px;"></i>Publish/Conform</button>
<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-refresh" style="margin-right:10px;"></i>Clear</button>
<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-remove" style="margin-right:10px;"></i>Cancel</button>--%>
            </div>
        </div>
    </div>

    <div class="col-md-12" style="">
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

    <div class="col-md-6" style="display: none; margin-bottom: 20px;">
        <label for="example-text-input" class="col-md-1 col-form-label" style="margin-left: 16%; width: 22%;">Forex Amount<span></span></label>
        <div class="col-md-11" style="width: 55%;">
            <%--   <input id="txtGrantTotal" style="width:100%;margin-left:2%;float: right;"   runat="server" type="text" onkeypress="return DisableEnter(event)"   class="form-control"  maxlength="50" />--%>
            <input id="txtForexTotal" readonly="readonly" style="width: 100%; margin-left: 2%; float: right; text-align: right;" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control" maxlength="50" />
        </div>
    </div>

    <div class="col-lg-6" style="display:none;">

        <div class="smart-form" style="width: 48%; margin-top: 3%; display: none;">
            <label for="inputPassword" class="col-sm-4 col-form-label font-sty" style="width: 54%; color: #333;">Add Attachment<span style=""></span></label>

            <label class="checkbox" style="float: left;">
                <input type="checkbox" runat="server" checked="checked" onkeydown="return  IncrmntConfrmCounter();" onchange="return CheckAdAttachment();" onkeypress="return DisableEnter(event)" id="cbxAttachment" />
                <i></i>
            </label>
        </div>
    </div>
    <div id="divAtchCCN" runat="server" class="container-fluid" style="width: 50%; float: left; margin-left: 1%; padding-top: 1%; display: none;">
        <%--  <h2 style="color: #000;margin: 0 0 12px;" >Attachments</h2>--%>
        <div id="divFileCCN" style="width: 100%; height: 85px;">
            <%--overflow-y:auto;--%>
            <table id="TableFileCCN" style="width: 100%;">
            </table>
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
    <script type="text/javascript">
        var RecuCounter = 0;

        if (document.getElementById("<%=hiddenPostdated.ClientID%>").value != "1") {

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
        var RemnDays = document.getElementById("cphMain_txtRemindDays").value.trim();
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
        var remindDays = document.getElementById("cphMain_txtRemindDays").value.trim();
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

