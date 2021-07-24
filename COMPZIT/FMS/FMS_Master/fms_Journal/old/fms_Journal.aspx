<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Journal.aspx.cs" Inherits="FMS_FMS_Master_fms_Journal_fms_Journal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>

     <script>
         function SuccessMsg() {

             $noCon("#success-alert").html("Journal details inserted successfully");
             $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
             });
             return false;
         }
         function SuccessUpdMsg() {

             $noCon("#success-alert").html("Journal details updated successfully");
             $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
             });
             return false;
         }
         function SuccessCnfMsg() {

             $noCon("#success-alert").html("Journal details confirmed successfully");
             $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
             });
             return false;
         }
         function SuccessReopMsg() {

             $noCon("#success-alert").html("Journal details reopened successfully");
             $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
             });
             return false;
         }

         function CanclUpdMsg() {
             $noCon("#divWarning").html("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
             $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
             });
             return false;
         }
         function CanclCnfMsg() {
             $noCon("#divWarning").html("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!.");
             $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
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


    </script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            
            
            if (document.getElementById("<%=HiddenPurchseSaleStatus.ClientID%>").value == "0") {
                document.getElementById("tsPursheSaleCC").innerText = "CC";
            }
            else{
                document.getElementById("tsPursheSaleCC").innerText="Purchase / Sale / CC";
            }
            if (document.getElementById("<%=HiddenRowCount.ClientID%>").value != "0")
            {
                RowIndex1 = document.getElementById("<%=HiddenRowCount.ClientID%>").value;
               
            }
           
          //  document.getElementById("<%=txtGrantTotal.ClientID%>").disabled = true;

            var EditVal = "";
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
                            addCommas("cphMain_txtForexTotal");
                        }
                    }
                    addCommas("cphMain_txtGrantTotal");
                }
           
                //var find2 = '\\"\\[';
                //var re2 = new RegExp(find2, 'g');
                //var res2 = EditVal.replace(re2, '\[');

                //var find3 = '\\]\\"';
                //var re3 = new RegExp(find3, 'g');
                //var res3 = res2.replace(re3, '\]');
                //var json = $noCon.parseJSON(res3);
                //for (var key in json) {
                //    if (json.hasOwnProperty(key)) {
                //        if (json[key].PYMNT_LDGR_ID != "") {
                //          //  EditListRows(json[key].PYMNT_ID, json[key].PYMNT_LDGR_ID, json[key].LDGR_ID, json[key].LDGR_AMT, json[key].LDGR_NAME, json[key].PYMNT_CST_ID, json[key].COSTCNTR_ID, json[key].PYMNT_CST_AMT, json[key].PURCHS_ID, json[key].RECPT_PURCHS_REF, json[key].COST_LD);
                //        }
                //    }
                //}


                var x = 0;
                buttnVisibile(x,"1");
                flg = 1;
            }


            if (document.getElementById("<%=HiddenFieldViewMode.ClientID%>").value != "1")
            {
                if (document.getElementById("cphMain_hiddenPostdated").value != "1") {
                    AddNewGroup(null);
                }
                document.getElementById("datepicker1").disabled = true;
            }

        
            if (document.getElementById("<%=HiddenRowCount.ClientID%>").value != "0") {
              
                $("#divLedger0> input").focus();
                $("#divLedger0> input").select();
            }
        });


    </script>

    <script>
        var yvalue = 0;
        //var EditAllCostcenters = "";
       // var EditAllPurchase = "";
        //function EditListRows(PYMNT_ID, PYMNT_LDGR_ID, LDGR_ID, LDGR_AMT, LDGR_NAME, PYMNT_CST_ID, COSTCNTR_ID, PYMNT_CST_AMT, PURCHS_ID, RECPT_PURCHS_REF, COST_LD) {
        //    if (LDGR_ID != 0) {
        //        AddNewGroup(LDGR_ID);
        //        document.getElementById("ddlLedId" + currntx).value = LDGR_ID;
        //       // document.getElementById("ddlLedIdDum" + currntx).value = LDGR_ID;
                
        //        document.getElementById("TxtAmount_" + currntx).value = LDGR_AMT;
        //        addCommas("TxtAmount_" + currntx);
        //        document.getElementById("tdEvtGrp" + currntx).value = "UPD";
        //        document.getElementById("tdDtlIdTempid" + currntx).value = PYMNT_LDGR_ID;
        //        document.getElementById("tdInxGrp" + currntx).value = currntx;
        //        document.getElementById("journalADD" + currntx).style.opacity = "0.3";

        //        if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
        //            document.getElementById("ddlLedId" + currntx).disabled = true;
        //            document.getElementById("TxtAmount_" + currntx).disabled = true;
        //            document.getElementById("tdEvtGrp" + currntx).value = "UPD";
        //            document.getElementById("tdDtlIdTempid" + currntx).disabled = true;
        //            document.getElementById("ddlRecptLedger" + currntx).disabled = true;

        //            document.getElementById("bttnRemovGrp" + currntx).disabled = true;
        //            document.getElementById("journalADD" + currntx).disabled = true;
        //            $("#tableGrp").find("input").attr("disabled", "disabled");

        //        }
        //        AccntChangeFunt();
        //    }
        //    if (COSTCNTR_ID != null && COSTCNTR_ID != "" && COSTCNTR_ID != 0) {
        //        document.getElementById("tdCostCenterDtls" + currntx).value = COSTCNTR_ID;
        //    }
        //    if (PURCHS_ID != null && PURCHS_ID != "" && PURCHS_ID != 0) {
        //        document.getElementById("tdPurchaseDtls" + currntx).value = PURCHS_ID;
        //    }
        //     //   FunctionQustn(currntx, currnty, COSTCNTR_ID);

        //        //if (PURCHS_ID != null && PURCHS_ID != "" && PURCHS_ID != 0) {
        //        //    document.getElementById("divCostCenter" + currntx + '' + currnty).style.display = "none";
        //        //    document.getElementById("ddlCostCtrId_" + currntx + '' + currnty).style.display = "none";
        //        //    document.getElementById("TxtIdSales_" + currntx + '' + currnty).style.display = "none";
        //        //    document.getElementById("TxtRecptCosCtr_" + currntx + '' + currnty).style.display = "block";


        //        //    document.getElementById("TxtIdSales_" + currntx + '' + currnty).value = PURCHS_ID;
        //        //    document.getElementById("TxtRecptCosCtr_" + currntx + '' + currnty).value = RECPT_PURCHS_REF;
        //        //}
        //        //if (COSTCNTR_ID != null && COSTCNTR_ID != "" && COSTCNTR_ID != 0) {
        //        //    document.getElementById("divCostCenter" + currntx + '' + currnty).style.display = "block";
        //        //    document.getElementById("ddlCostCtrId_" + currntx + '' + currnty).style.display = "none";
        //        //    document.getElementById("TxtRecptCosCtr_" + currntx + '' + currnty).style.display = "none";
        //        //    document.getElementById("TxtIdSales_" + currntx + '' + currnty).style.display = "none";

        //        //    document.getElementById("ddlCostCtrId_" + currntx + '' + currnty).value = COSTCNTR_ID;
        //        //}
        //        //document.getElementById("TxtCstctrAmount_" + currntx + '' + currnty).value = PYMNT_CST_AMT;
        //        //addCommas("TxtCstctrAmount_" + currntx + '' + currnty);
        //        //document.getElementById("TxtActCstctrAmount_" + currntx + '' + currnty).value = PYMNT_CST_AMT;

        //        //document.getElementById("tdEvtQstn" + currntx + '' + currnty).value = "UPD";
        //        //document.getElementById("tdDtlIdQstn" + currntx + '' + currnty).value = PYMNT_CST_ID;
        //        //document.getElementById("tdInxQstn" + currntx + '' + currnty).value = currntx + '' + currnty;
        //        //document.getElementById("btnCostCenter_" + currntx + '' + currnty).style.opacity = "0.3";

        //        ////if (COSTCNTR_ID != null && COSTCNTR_ID != "") {
        //        ////    FillddlCostCenter(currntx, currnty, COSTCNTR_ID);
        //        ////}
        //        ddlLedOnchange(currntx, "upd");

               
        //}

        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }

        var rowSubCatagory = 0;
        var RowIndex1 = 0;
        var flg = 0;
        function AddNewGroup(ledgerid) {
            RowIndex1++;
            var FrecRow = '';
            FrecRow = '<tr id="SubGrpRowId_' + RowIndex1 + '" class="tr1" ><td   id="tdidGrpDtls' + RowIndex1 + '" style="display: none" >' + RowIndex1 + '</td>';
            FrecRow += '<div style="display:none" id="groupSubCat' + RowIndex1 + '">' + rowSubCatagory + '</div> ';
            var yy = rowSubCatagory + 1;
            FrecRow += ' <td  class="col-md-3"><div id="divLedger' + RowIndex1 + '"><select onkeypress="return DisableEnter(event)"  class="fg2_inp2 fg2_inp3 fg_chs1 f_p3 ddl" id="ddlRecptLedger' + RowIndex1 + '"  onchange="PaymentLedger(' + RowIndex1 + ');">';
            FrecRow += '</select></div><span id="AccntBalance_' + RowIndex1 + '" class="input-group-addon cur2"></span><input class="form-control" style="display:none" name="ddlLedId' + RowIndex1 + '"  value="0" id="ddlLedId' + RowIndex1 + '" type="text"></td>';

            //      FrecRow += ' <td colspan="3" style="padding:0px;width:50%;"><table id="TableAddQstnCostCenter_' + RowIndex1 + '" class="table table-bordered">  </table>';
            FrecRow += '</td > <td  class="col-md-2 tr_r"><div class="input-group"> <span class="input-group-addon cur1">' + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value + '</span><input class="form-control fg2_inp2 tr_r" disabled autocomplete="\off"\ onkeydown="return isDecimalNumber(event,\'TxtAmount_' + RowIndex1 + '\');" onkeypress="return isDecimalNumber(event,\'TxtAmount_' + RowIndex1 + '\');" name="TxtAmount_' + RowIndex1 + '"  onblur="return PendingPurchase(\'TxtAmount_' + RowIndex1 + '\',' + RowIndex1 + ',\'DBT\');"   value="" id="TxtAmount_' + RowIndex1 + '" maxlength="10" type="text" > </div></td>';

            FrecRow += '<td  class="col-md-2 tr_r"><div class="input-group"> <span class="input-group-addon cur1">' + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value + '</span><input class="form-control fg2_inp2 tr_r" disabled autocomplete="\off"\ onkeydown="return isDecimalNumber(event,\'TxtAmountCrdt' + RowIndex1 + '\');" onkeypress="return isDecimalNumber(event,\'TxtAmountCrdt' + RowIndex1 + '\');" name="TxtAmountCrdt' + RowIndex1 + '"  onblur="return PendingPurchase(\'TxtAmountCrdt' + RowIndex1 + '\',' + RowIndex1 + ',\'CDT\');"   value="" id="TxtAmountCrdt' + RowIndex1 + '" maxlength="10" type="text" ></div></td>';

            FrecRow += '<td class="col-md-3" > <textarea id="TxtRemark' + RowIndex1 + '" name="TxtRemark' + RowIndex1 + '"    rows="3" cols="20"  class="form-control" style=" resize: none;" onkeydown="textCounter(TxtRemark' + RowIndex1 + ',450)" onkeyup="textCounter(TxtRemark' + RowIndex1 + ',450)"></textarea></td>';

            //  FrecRow += '<td style="width:15%;"> <input class="form-control"  autocomplete="\off"\  name="TxtRemark' + RowIndex1 + '"    value="" id="TxtRemark' + RowIndex1 + '"      maxlength="500" type="textarea" style="resize:none; height:100px;" onchange="IncrmntConfrmCounter();" onblur="return textCounter(TxtRemark' + RowIndex1 + ', 500)" onkeypress="return textCounter(TxtRemark' + RowIndex1 + ', 500)"  autocomplete="\off"\  rows="4" cols="50" > </td>';


            FrecRow += '<td class="col-md-1 td1"><button title="ADD"  id="journalADD' + RowIndex1 + '" onclick="return FuctionAddGroup(\'' + RowIndex1 + '\')" class="btn act_btn bn2" ><i   class="fa fa-plus-circle"  style="display: block;">&nbsp;</i></button>';


            FrecRow += '<button title="DELETE" id="bttnRemovGrp' + RowIndex1 + '"   onclick="return removeRowGrps(' + RowIndex1 + ',\'Are you sure you want to delete this ledger?\')" class="btn act_btn bn3" >';
            FrecRow += ' <i class="fa fa-trash"   style="display: block;">&nbsp;</i></button></td>';
            FrecRow += '<td class="col-md-1">';
            if (document.getElementById("<%=HiddenPurchseSaleStatus.ClientID%>").value == "1") {
                FrecRow += '<a href=\"javascript:;\" title="PURCHASE" id="ChkPurchase' + RowIndex1 + '"  onclick="return ddlLedOnchange(\'' + RowIndex1 + '\',\'ins\',\'DBT\');"><i id="ChkPurchaseITag' + RowIndex1 + '" class="fa fa-shopping-cart ad_fa psc_p"></i></a>';
                FrecRow += '<a href=\"javascript:;\" title="SALES" id="ChkSales' + RowIndex1 + '"  onclick="return ddlLedOnchange(\'' + RowIndex1 + '\',\'ins\',\'CDT\');"><i id="ChkSalesITag' + RowIndex1 + '" class="fa fa-balance-scale ad_fa psc_s"></i></a>';
            }
            FrecRow += '<a href=\"javascript:;\" title="COST CENTRE" id="ChkCostCenter' + RowIndex1 + '"  onclick="MyModalCostCenter(\'' + RowIndex1 + '\',\'' + rowSubCatagory + '\',null);" ><i class="fa fa-filter ad_fa psc_c"></i></a>';
            FrecRow += '</td>';




            FrecRow += '<td  style="display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowIndex1 + '" name="tdCostCenterDtls' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="display: none;"><input type="text" class="form-control" style="display:none;"  id="tdPurchaseDtls' + RowIndex1 + '" name="tdPurchaseDtls' + RowIndex1 + '" placeholder=""/></td>';

            FrecRow += '<td  style="display: none;"><input type="text" class="form-control" style="display:none;"  id="tdPurchOrSale' + RowIndex1 + '" name="tdPurchOrSale' + RowIndex1 + '" placeholder=""/></td>';

            FrecRow += '<td  style="display: none;"><input type="text" class="form-control" value="INS" style="display:none;"  id="tdEvtGrp' + RowIndex1 + '" name="tdEvtGrp' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdTempid' + RowIndex1 + '" name="tdDtlIdTempid' + RowIndex1 + '" placeholder=""/><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdGrp' + RowIndex1 + '" name="tdDtlIdGrp' + RowIndex1 + '" placeholder=""/></td>';

            FrecRow += '<td  style="display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdInxGrp' + RowIndex1 + '" name="tdInxGrp' + RowIndex1 + '" placeholder=""/> </td></tr>';
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

            $("#divLedger" + RowIndex1 + "> input").focus();
            $("#divLedger" + RowIndex1 + "> input").select();

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
        
            else if (keyCodes == 33 || keyCodes == 34 || keyCodes == 35 || keyCodes == 36 || keyCodes == 37 || keyCodes == 38 || keyCodes == 39 || keyCodes == 40 || keyCodes == 41) {

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
            document.getElementById("TxtAmount_" + x).style.borderColor = "";
            document.getElementById("TxtAmountCrdt" + x).style.borderColor = "";
           
            if (document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) {
             
                $("#divLedger" + x + "> input").css("borderColor", "");
                
                if (LedgerDuplication(x) == true)

                {
                    LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                    document.getElementById("ddlLedId" + x).value = LedgerId;

                    document.getElementById("TxtAmount_" + x).value = "";
                    document.getElementById("TxtAmountCrdt" + x).value = "";
                    document.getElementById("tdCostCenterDtls" + x).value = "";
                    document.getElementById("tdPurchaseDtls" + x).value = "";
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
                document.getElementById("tdPurchaseDtls" + x).value = "";
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
            TxtCstctrAmount = document.getElementById("TxtAmount_" + x).value;
            TxtCstctrAmount = TxtCstctrAmount.trim();
            TxtCstctrAmountCrdt = document.getElementById("TxtAmountCrdt" + x).value.trim();
          
            document.getElementById("TxtAmount_" + x).style.borderColor = "";
            document.getElementById("TxtAmountCrdt" + x).style.borderColor = "";
            $("#divLedger" + x + "> input").css("borderColor", "");
            
            if ((document.getElementById("ddlRecptLedger" + x).value != "" && document.getElementById("ddlRecptLedger" + x).value != 0) ) {
                if (TxtCstctrAmount != "" || TxtCstctrAmountCrdt!="") {
                var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                document.getElementById("ddlLedId" + x).value = LedgerId;
                if (document.getElementById("tdCostCenterDtls" + x).value != "") {
                    var CstCntrDtl = document.getElementById("tdCostCenterDtls" + x).value;

                    var splitrow = CstCntrDtl.split("$");
                    for (var Cst = 0; Cst < splitrow.length; Cst++) {
                        var splitEach = splitrow[Cst].split("%");
                        if (splitEach[0] != "") {
                            FunctionQustn(x, currnty, splitEach[0], splitEach[2], splitEach[3]);

                            //if (document.getElementById("myModalCstCntr").style.display != "block") {
                            //}
                            //document.getElementById("divCostCenter" + x + '' + y).style.display = "block";
                            //document.getElementById("ddlCostCtrId_" + x + '' + y).style.display = "none";
                            //document.getElementById("TxtRecptCosCtr_" + x + '' + y).style.display = "none";
                            //document.getElementById("TxtIdSales_" + x + '' + y).style.display = "none";

                            document.getElementById("ddlCostCtrId_" + x + '' + currnty).value = splitEach[0];

                            document.getElementById("TxtCstctrAmount_" + x + '' + currnty).value = splitEach[1];
                            addCommas("TxtCstctrAmount_" + x + '' + currnty);
                            document.getElementById("TxtActCstctrAmount_" + x + '' + currnty).value = splitEach[1];
                            document.getElementById("tdInxQstn" + x + '' + currnty).value = x + '' + currnty;
                            document.getElementById("btnCostCenter_" + x + '' + currnty).style.opacity = "0.3";

                            //document.getElementById("tdEvtQstn" + x + '' + y).value = "INS";
                            //document.getElementById("tdDtlIdQstn" + x + '' + y).value = PYMNT_CST_ID;
                            //   document.getElementById("tdInxQstn" + x + '' + currnty).value = x + '' + currnty;
                            //  document.getElementById("btnCostCenter_" + x + '' + currnty).style.opacity = "0.3";

                            //if (COSTCNTR_ID != null && COSTCNTR_ID != "") {
                            //    FillddlCostCenter(currntx, currnty, COSTCNTR_ID);
                            //}
                        }

                    }
                    FunctionQustn(x, currnty, null,null,null);
                }
                else {
                    FunctionQustn(x, y, CostCenterId, CostCenterId, CostCenterId);
                }
                document.getElementById("BtnPopupCstCntr").click();
                if (TxtCstctrAmount!="")
                    document.getElementById("LedgerAmtInModal" + x).innerText = TxtCstctrAmount + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value; 
                else if (TxtCstctrAmountCrdt != "")
                {
                    document.getElementById("LedgerAmtInModal" + x).innerText = TxtCstctrAmountCrdt + " " + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
                }
            }
            }

            if (TxtCstctrAmount == "" && TxtCstctrAmountCrdt == "") {

                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";
            }
            if (document.getElementById("ddlRecptLedger" + x).value == "" || document.getElementById("ddlRecptLedger" + x).value == 0) {
                $("#divLedger" + x + "> input").css("borderColor", "red");
                $("#divLedger" + x + "> input").focus();
                $("#divLedger" + x + "> input").select();
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
            else if (keyCodes == 33 || keyCodes == 34 || keyCodes == 35 || keyCodes == 36 || keyCodes == 37 || keyCodes == 38 || keyCodes == 39 || keyCodes == 40 || keyCodes == 41 || keyCodes == 118 || keyCodes == 17) {

                return true;
            }
         else   if ((keyCodes == 65 || keyCodes == 86 || keyCodes == 67) && (evt.ctrlKey === true || evt.metaKey === true)) {

                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
           
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


                FrecRowQst += '<input name="TxtRecptCosGrp1_' + x + '' + y + '"  style="display: none;pointer-events: none;" class="form-control" id="TxtRecptCosGrp1_' + x + '' + y + '" ><div id="divCostGrp1' + x + '' + y + '"><select id="ddlRecptCosGrp1_' + x + '' + y + '" name="ddlRecptCosGrp1_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl"  onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostGrp1Id_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostGrp1Id_' + x + '' + y + '" ></td>';

                FrecRowQst += '<td>';


                FrecRowQst += '<input name="TxtRecptCosGrp2_' + x + '' + y + '"  style="display: none;pointer-events: none;" class="form-control" id="TxtRecptCosGrp2_' + x + '' + y + '" ><div id="divCostGrp2' + x + '' + y + '"><select id="ddlRecptCosGrp2_' + x + '' + y + '" name="ddlRecptCosGrp2_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl"  onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostGrp2Id_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostGrp2Id_' + x + '' + y + '" ></td>';




                FrecRowQst += '<td><input style="display:none" value="-1" name="TxtIdSales_' + x + '' + y + '" class="form-control" id="TxtIdSales_' + x + '' + y + '" ><input name="TxtRecptCosCtr_' + x + '' + y + '"  style="display: none;pointer-events: none;background: #eee;" class="form-control" id="TxtRecptCosCtr_' + x + '' + y + '" ><div id="divCostCenter' + x + '' + y + '"><select id="ddlRecptCosCtr_' + x + '' + y + '" name="ddlRecptCosCtr_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 form-control"  onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  >';


                FrecRowQst += '</select></div><input name="ddlCostCtrId_' + x + '' + y + '" style="display:none"  class="form-control" id="ddlCostCtrId_' + x + '' + y + '" ></td><td class=" tr_r" > <div class="input-group"> <span class="input-group-addon cur1">' + document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value + '</span><input class="form-control fg2_inp2 tr_r" autocomplete="\off"\ maxlength="10"  id="TxtCstctrAmount_' + x + '' + y + '" name="TxtCstctrAmount_' + x + '' + y + '" value="" onchange="return CheckSumOfCstCntr(\'TxtCstctrAmount_' + x + '' + y + '\',' + x + ',' + y + ');"  onkeydown="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '' + y + '\');" onkeypress="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '' + y + '\');" id="TxtCstctrAmount_' + x + '' + y + '" type="text" ><input class="form-control"   id="TxtActCstctrAmount_' + x + '' + y + '" value="" onblur="return CheckSumOfLedger(\'TxtActCstctrAmount_' + x + '' + y + ',' + x + ',' + y + '\');" onkeyup="addCommas("TxtActCstctrAmount_' + x + '' + y + ')" style=" display:none" onkeydown="return isNumber(event,TxtActCstctrAmount_' + x + '' + y + ');" name="TxtActCstctrAmount_' + x + '' + y + '" type="text"></td>';

                FrecRowQst += '<td class="td1">';

                FrecRowQst += '<button title="ADD" id="btnCostCenter_' + x + '' + y + '" onclick="return CheckaddMoreRowsQstn(\'' + x + '\',\'' + y + '\',\'' + x + '' + y + '\');" class="btn act_btn bn2"><i  class="fa fa-plus"  style="display: block;">&nbsp;</i></button>';
                FrecRowQst += '<button class="btn act_btn bn3" id="btnCostCenterDel_' + x + '' + y + '" onclick="return removeRowQstn(\'' + x + '\',\'' + y + '\',\'' + x + '' + y + '\',\'Are you sure you want to delete this cost centre?\')" >';
                FrecRowQst += '<i title="DELETE"   class="fa fa-trash" id="Span4" style="display: block;">&nbsp;</i></button></td>';

                FrecRowQst += '<td   style="display: none;"><input type="text" class="form-control" style="display:none;" value="INS" id="tdEvtQstn' + x + '' + y + '" name="tdEvtQstn' + x + '' + y + '" placeholder=""/></td>';
                FrecRowQst += '<td style="display: none;"><input type="text" class="form-control" style="display:none;"  id="tdDtlIdQstn' + x + '' + y + '" name="tdDtlIdQstn' + x + '' + y + '" placeholder=""/></td>';
                FrecRowQst += '<td  style="display: none;"><input type="text" class="form-control" style="display:none;"  id="tdInxQstn' + x + '' + y + '" name="tdInxQstn' + x + '' + y + '" placeholder=""/> </td></tr>';
                jQuery('#TableAddQstnCostCenter'+x).append(FrecRowQst);

            FillddlCostCenter(x, y, CostCenterId);
            $au("#ddlRecptCosCtr_" + x + '' + y).selectToAutocomplete1Letter();


            FillddlAcntGrp1(x, y, CostGrp1Id);


            $au("#ddlRecptCosGrp1_" + x + '' + y).selectToAutocomplete1Letter();

            FillddlAcntGrp2(x, y, CostGroup2Id);


            $au("#ddlRecptCosGrp2_" + x + '' + y).selectToAutocomplete1Letter();
            //  CheckSubmitZero();
            
            currntx = x;
            currnty = y;
            if (document.getElementById("<%=HiddenFieldViewMode.ClientID%>").value == "1") {
                document.getElementById("btnCostCenter_" + x + y).disabled = "true";
                document.getElementById("btnCostCenterDel_" + x + y).disabled = "true";
                $("#TableAddQstnCostCenter" + x).find("input").attr("disabled", "disabled");
            }

            $('#myModalCstCntr').on('shown.bs.modal', function () {
                $("#divCostGrp1" + x + "" + y + " > input").focus();
                $("#divCostGrp1" + x + "" + y + " > input").select();
            })


            return false;

        }
        function MyModalCostCenter(x, y, CstCntr) {
            var SbCostCenter = '';
            SbCostCenter = '<div class=\"modal fade\" id=\"myModalCstCntr\" role=\"dialog\"  data-backdrop=\"static\" >';
            SbCostCenter += '<div class=\"modal-dialog mod1\" >';

            SbCostCenter += '<div class=\"modal-content\">';
            SbCostCenter += '<div class=\"modal-header\">';
            SbCostCenter += '<button type=\"button\" class=\"close\" onclick=\"return CloseModal(\'' + x + '\')\">&times;</button>';
            SbCostCenter += '<h2 class=\"modal-title mod1 flt_l\" id=\"ModelHeading\"><i class=\"fa fa-filter\"></i> Cost Centre<span class=\"spn_mod\"></span></h2>';
            //SbCostCenter += "<h4 id=\"ModelHeading\" class=\"modal-title\"></h4>";
            SbCostCenter += "</div>";

            SbCostCenter += '<div class="al-box war" id="lblErrMsgCancelReasonCost">Please fill this out</div>';

            SbCostCenter += '<div class=\"modal-body md_bd\">';

            //SbCostCenter += '<div class=\"col-md-12\" style=\"padding-bottom:15px;\">';

            //SbCostCenter += '<div class=\"col-md-12 res_table_box\" style=\"padding-bottom:15px;padding-left: 1px;padding-right: 11px;width:102%\">';
            //SbCostCenter += '<div class=\"tab-content\" id=\"myTabContent\" style=\"max-height:300px;overflow:auto;\">';
            //SbCostCenter += '<div class=\"tab-pane fade active in\" id=\"home\" role=\"tabpanel\" aria-labelledby=\"home-tab\" style=\"border:1px solid #dddddd;padding: 3px;\">';

            //SbCostCenter += '<ul class=\"list-group bg-grey\" style=\"font-size:15px;\">';

            SbCostCenter += '<div id=\"DivPopUpCostCenter\">';

            SbCostCenter += '<table id="TableAddQstnCostCenter' + x + '" class="table table-bordered">';
            SbCostCenter += '<thead class="thead1"> <tr><th class="col-md-2 tr_l">Cost Group1</th><th class="col-md-2 tr_l">Cost Group2</th><th class="col-md-2 tr_l">Cost Centre</th><th class="col-md-3 tr_r"> Amount</th><th class="col-md-3">';
            SbCostCenter += 'Actions</th></tr></thead>';
            SbCostCenter += '</table>';
            SbCostCenter += '</div>';//</ul></div></div></div></div></div>';
            SbCostCenter += '<div class=\"clearfix\"></div><div class=\"devider\"></div>';

            SbCostCenter += '<div class="col-md-12 col_mar">';
            SbCostCenter += '<div class="col-md-6">';
            SbCostCenter += '<label for="email" class="fg2_la1 tt_am am1" id=\"Label1\">Ledger Amount<span class="spn1"></span>:</label>';
            SbCostCenter += '</div>';
            SbCostCenter += '<div class="col-md-6 flt_pr">';
            SbCostCenter += '<span class="tt_am am1 tt_al" id="LedgerAmtInModal' + x + '"></span>';
            SbCostCenter += '</div>';
            SbCostCenter += '</div></div>';


            SbCostCenter += '<div class=\"modal-footer\">';

            //SbCostCenter += '<label id=\"Label1\" for=\"example-text-input\" class=\"col-md-1 col-form-label\" style=\"margin-left: 39%;width: 21%;\">Ledger Amount<span></span></label>';
            //SbCostCenter += '<label id="LedgerAmtInModal' + x + '" for=\"example-text-input\" class=\"col-md-1 col-form-label\" style=\"width: 18%;\"><span></span></label>';
            SbCostCenter += '<button id="btnImportCostCenter' + x + '" type=\"button\" class=\"btn btn-success\"  onclick=\"ButtnFillClickCostCenter(\'' + x + '\');\" >Submit</button>';
            SbCostCenter += '<button id="BttnCost' + x + '"  type=\"button\" class=\"btn btn-danger\" data-dismiss=\"modal\">Cancel</button>';
            SbCostCenter += '</div></div> </div></div>';
            document.getElementById("CostCenterModal").innerHTML = SbCostCenter;
            CostCentr(x, y, CstCntr);
            buttnVisibile(x, "0");
            if (document.getElementById("<%=HiddenFieldViewMode.ClientID%>").value == "1") {
                document.getElementById("btnImportCostCenter" + x).disabled = true;
            }

            var idlast = "";
            var row = $noCon('#TableAddQstnCostCenter' + x).find(' tbody tr:first').attr('id');
            idlast = row.split('_');
            setTimeout(function () { focusCostCentre(idlast[1]); }, 300);
        }
        function focusCostCentre(Rowid) {

            $("#divCostGrp1" + Rowid + " > input").focus();
            $("#divCostGrp1" + Rowid + " > input").select();
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
            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1"){
         //   if (document.getElementById("cphMain_HiddenFieldView").value != "1") {
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
                    if (TableRowCount != 0) {
                        for (var i = 0; i < addRowtable.rows.length; i++) {
                            var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                            if (TableRowCount != 0) {
                                if ((TableRowCount-1)==i) {
                                    document.getElementById("tdInxGrp" + xLoop).value = "";
                                    document.getElementById("journalADD" + xLoop).style.opacity = "1";
                                    document.getElementById("journalADD" + xLoop).disabled = false;
                                   
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

        }
        function buttnVisibile(x,Check) {
            var TableRowCount = document.getElementById("tableGrp").rows.length;
            addRowtable = document.getElementById("tableGrp");

            for (var i = 0; i < addRowtable.rows.length; i++) {
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                if (TableRowCount != 0) {
                   // var idlast = $noCon('#tableGrp >tbody > tr:not(:has(>td>table)):last').attr('id');
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
           // if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                          if (confirmbox > 0) {
                              ezBSAlert({
                                  type: "confirm",
                                  messageText: "Are you sure you want to leave this page?",
                                  alertType: "info"
                              }).done(function (e) {
                                  if (e == true) {
                                      window.location.href = "fms_Journal_List.aspx";
                                  }
                                  else {
                                      return false;
                                      //window.location.href = "Purchase_master.aspx";
                                  }
                              });
                              return false;
                          }
                          else {
                              window.location.href = "fms_Journal_List.aspx";
                              return false;
                          }
                //      }
                //      else {
                //window.location.href = "fms_Payment_Account_List.aspx";
                //          return false;
                //      }

                  }
        function removeRowQstn(Rowid, y, removeNum, CofirmMsg) {
            IncrmntConfrmCounter();

            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
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
                            document.getElementById("tdCostCenterDtls" + Rowid).value = "";
                            if (idlast != "") {

                                var res = idlast.split("_");
                                document.getElementById("tdInxQstn" + res[1]).value = "";
                                document.getElementById("btnCostCenter_" + res[1]).style.opacity = "1";

                                setTimeout(function () { focusCostCentre(res[1]); }, 350);
                            }
                        }
                        else {

                            FunctionQustn(Rowid, y, null,null,null);
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
  
        function PendingPurchase(textboxid, x, CedtOrDbt) {
            IncrmntConfrmCounter();
            //alert(CedtOrDbt);
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

            if (document.getElementById("cphMain_HiddenView").value != "1") {
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
                }
            }

            var Meassage = "";

            var ledgerval = $("#divLedger" + x + "> input").val();
            var ret = true;
            var CstTotal = 0;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var LedgerTotal = 0;
            var addRowtable1 = document.getElementById("tableGrp");

            for (var i = 0; i < addRowtable1.rows.length; i++) {
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

                LdAmt = LdAmt.replace(/\,/g, '');

                if (document.getElementById("tdPurchaseDtls" + xtemp).value != null && document.getElementById("tdPurchaseDtls" + xtemp).value != "" && document.getElementById("tdPurchaseDtls" + xtemp).value != "null") {
                    document.getElementById("TxtAmount_" + xtemp).style.borderColor = "";
                    document.getElementById("TxtAmountCrdt" + xtemp).style.borderColor = "";
                    var PurchaseInfo = document.getElementById("tdPurchaseDtls" + xtemp).value;
                    if (PurchaseInfo != "") {
                        var PrchaseTTl = "0";
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


                        if (parseFloat(PrchaseTTl) > parseFloat(LdAmt)) {
                            if (CrdtOrDbt == "DBT")
                                document.getElementById("TxtAmount_" + xtemp).style.borderColor = "red";
                            else if (CrdtOrDbt == "CDT")
                                document.getElementById("TxtAmountCrdt" + xtemp).style.borderColor = "red";
                            else {
                                document.getElementById("TxtAmount_" + xtemp).style.borderColor = "red";
                                document.getElementById("TxtAmountCrdt" + xtemp).style.borderColor = "red";
                            }
                            $noCon("#divWarning").html("Ledger amount should be greater than or equal to sales amount. ");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
                    }


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

            if (Purchase_ret == true && ret == true) {
                if (LedgerDuplication(x) == true) {

                    if (document.getElementById("ddlRecptLedger" + x).value != "") {
                        var Currency = "";
                        var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
                        var corpid = '<%= Session["CORPOFFICEID"] %>';
                        var orgid = '<%= Session["ORGID"] %>';
                        var userid = '<%= Session["USERID"] %>';

                        var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                        var ViewSts = document.getElementById("<%=HiddenFieldViewMode.ClientID%>").value;
                        document.getElementById("ddlLedId" + x).value = LedgerId;
                        var mode = "ins";
                        var CrncyAbrv = document.getElementById("cphMain_HiddenCurrencyAbrv").value;

                        var jrnlId = document.getElementById("<%=HiddenJrnlId.ClientID%>").value;
                        if (jrnlId == "") {
                            jrnlId = "0";
                        }
                        var LdgrId = document.getElementById("tdDtlIdTempid" + x).value;

                        $noCon.ajax({
                           // async:false,
                            type: "POST",
                            url: "fms_Journal.aspx/LoadSalesForLedger",
                            data: '{intLedgerId:"' + LedgerId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" ,mode:"' + mode + '",x:"' + x + '",strCedtOrDbt:"' + CedtOrDbt + '",strCurrencyId:"' + CurrencyId + '",strViewSts:"' + ViewSts + '" ,strCrncyAbrv:"' + CrncyAbrv + '",jrnlId:"' + jrnlId + '",LdgrId:"' + LdgrId + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
       
                                if (response.d[0] != "") {
                                    setTimeout(function () { NoUse(x, CedtOrDbt); }, 500);
                                }
                                else {
                                    if (document.getElementById("<%=HiddenPurchseSaleStatus.ClientID%>").value != "0") {
                                        document.getElementById("ChkPurchase" + x).style.opacity = "0.5";
                                        document.getElementById("ChkPurchaseITag" + x).className = "fa fa-shopping-cart ad_fa psc_p";

                                        document.getElementById("ChkSales" + x).style.opacity = "0.5";
                                        document.getElementById("ChkSalesITag" + x).className = "fa fa-balance-scale ad_fa psc_s";
                                    }
                                }

                                if (response.d[1] != "") {
                                    addCommasSummry(response.d[1]);

                                    if (response.d[2] == "DR") {
                                        $("#AccntBalance_" + x).addClass("input-group-addon cur2 dr1");
                                    }
                                    else if (response.d[2] == "CR") {
                                        $("#AccntBalance_" + x).addClass("input-group-addon cur2 c1h");
                                    }

                                    if (Currency != "") {
                                        document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i> " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + response.d[4];
                                    }
                                    else {
                                        document.getElementById("AccntBalance_" + x).innerHTML = "<i  class=\"fa fa-money\"></i> " + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + response.d[4];

                                    }
                                }
                                else {
                                    document.getElementById("AccntBalance_" + x).innerHTML = "";
                                }

                                if (response.d[6] != "") {
                                    if (response.d[6] == "0" || response.d[6] == "1") {
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
                    var AmntText;
                    if (CedtOrDbt == "CDT") {

                        AmntText = document.getElementById("TxtAmountCrdt" + x).value;
                        AmntText = AmntText.replace(/,/g, "");
                        if (AmntText != "") {
                            AmntText = parseFloat(AmntText);
                            document.getElementById("TxtAmountCrdt" + x).value = AmntText.toFixed(FloatingValue);
                            addCommas("TxtAmountCrdt" + x);
                        }

                    }
                    else {

                        AmntText = document.getElementById("TxtAmount_" + x).value;
                        AmntText = AmntText.replace(/,/g, "");
                        if (AmntText != "") {
                            AmntText = parseFloat(AmntText);
                            document.getElementById("TxtAmount_" + x).value = AmntText.toFixed(FloatingValue);
                            addCommas("TxtAmount_" + x);
                        }


                    }

                }
            }
            return false;
        }
        function NoUse(varRowidx, CedtOrDbt) {

            if (document.getElementById("<%=HiddenPurchseSaleStatus.ClientID%>").value != "0") {

                if (CedtOrDbt == "CDT") {

                    document.getElementById("ChkPurchase" + varRowidx).style.opacity = "0.5";
                    document.getElementById("ChkPurchaseITag" + varRowidx).className = "fa fa-shopping-cart ad_fa psc_p";

                    document.getElementById("ChkSales" + varRowidx).style.opacity = "1";
                    document.getElementById("ChkSalesITag" + varRowidx).className = "fa fa-balance-scale ad_fa psc_s gre";
                }
                else if (CedtOrDbt == "DBT") {
                    document.getElementById("ChkPurchase" + varRowidx).style.opacity = "1";
                    document.getElementById("ChkPurchaseITag" + varRowidx).className = "fa fa-shopping-cart ad_fa psc_p gre";

                    document.getElementById("ChkSales" + varRowidx).style.opacity = "0.5";
                    document.getElementById("ChkSalesITag" + varRowidx).className = "fa fa-balance-scale ad_fa psc_s";
                }
            }
           
        }
        function LedgerDuplication(rowId) {
            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("tableGrp");
            if (document.getElementById("<%=HiddenLedgrDupSts.ClientID%>").value != "1") {
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
            }

            return ret;
        }

        function CCGrp1Duplication(x, xy) {
            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
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
                            document.getElementById("lblErrMsgCancelReasonCost").innerHTML = "Cost Group should not be duplicated";
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
                            document.getElementById("lblErrMsgCancelReasonCost").innerHTML = "Cost Group should not be duplicated";
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


        function CCDuplication(x, xy) {
            var addRowtable = "";
            var ret = true;
            var flag = 0;
            addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
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
                        document.getElementById("lblErrMsgCancelReasonCost").innerHTML = "Cost centres should not be duplicated for cost groups";
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
        var varRowidx = "";
        var varRowidy = "";
        function ddlLedOnchange(x, mode, CedtOrDbt) {
           
            var Purchase_ret = true;
            var TxtCstctrAmount = "";


            if (CedtOrDbt == "CDT") {
                
                TxtCstctrAmount = document.getElementById("TxtAmountCrdt" + x).value;

            }
            else {
                TxtCstctrAmount = document.getElementById("TxtAmount_" + x).value;

               
            }

            TxtCstctrAmount = TxtCstctrAmount.trim();
            //  document.getElementById("TxtAmountCrdt" + x).style.borderColor = "";
            //   document.getElementById("TxtAmount_" + x).style.borderColor = "";
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
            //if (TxtCstctrAmount == "") {

            //    document.getElementById("TxtAmount_" + x).style.borderColor = "red";
            //}
            if (TxtCstctrAmount == "") {
                Purchase_ret = false;
                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
            }
            if (TxtCstctrAmount != "") {
                if (CedtOrDbt == "CDT") {

                 
                    document.getElementById("TxtAmount_" + x).disabled = true;
                    if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                        document.getElementById("TxtAmountCrdt" + x).disabled = false;
                    }
                    else {
                        document.getElementById("TxtAmountCrdt" + x).disabled = true;
                    }
                }
                else {
                    document.getElementById("TxtAmountCrdt" + x).disabled = true;
                    if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                        document.getElementById("TxtAmount_" + x).disabled = false;
                    }
                    else {
                        document.getElementById("TxtAmount_" + x).disabled = true;
                    }
                }
            }
            else {
                if (document.getElementById("TxtAmount_" + x).value == "" && document.getElementById("TxtAmountCrdt" + x).value == "") {
                    if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                        document.getElementById("TxtAmount_" + x).disabled = false;
                        document.getElementById("TxtAmountCrdt" + x).disabled = false;
                    }
                    else {
                        document.getElementById("TxtAmount_" + x).disabled = true;
                        document.getElementById("TxtAmountCrdt" + x).disabled = true;
                    }
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
            if (CedtOrDbt == "CDT") {
                Meassage = "Do you want to pay the pending sales bill?";
              
            }
            else {
               
                Meassage = "Do you want to pay the pending purchase bill?";
            }

            if (Purchase_ret == true) {
                if (LedgerDuplication(x) == true) {

                    varRowidx = x;
                    if (document.getElementById("ddlRecptLedger" + x).value != "0") {

                        var Currency = "";
                        var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;



                        var corpid = '<%= Session["CORPOFFICEID"] %>';
                        var orgid = '<%= Session["ORGID"] %>';
                        var userid = '<%= Session["USERID"] %>';
                        var LedgerId = document.getElementById("ddlRecptLedger" + x).value;
                        var ViewSts = document.getElementById("<%=HiddenFieldViewMode.ClientID%>").value;
                        var CrncyAbrv = document.getElementById("cphMain_HiddenCurrencyAbrv").value;

                        var jrnlId = document.getElementById("<%=HiddenJrnlId.ClientID%>").value;
                        if (jrnlId == "") {
                            jrnlId = "0";
                        }
                        var LdgrId = document.getElementById("tdDtlIdTempid" + x).value;

                        document.getElementById("ddlLedId" + x).value = LedgerId;
                        var mode = "ins";
                        $noCon.ajax({
                            type: "POST",
                            url: "fms_Journal.aspx/LoadSalesForLedger",
                            data: '{intLedgerId:"' + LedgerId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" ,mode:"' + mode + '",x:"' + x + '",strCedtOrDbt:"' + CedtOrDbt + '",strCurrencyId:"' + CurrencyId + '",strViewSts:"' + ViewSts + '" ,strCrncyAbrv:"' + CrncyAbrv + '",jrnlId:"' + jrnlId + '",LdgrId:"' + LdgrId + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                if (response.d[0] != "") {

                                    document.getElementById("DivPopUpSales").innerHTML = response.d[0];
                                    document.getElementById("btnImportSales").style.display = "";
                                    document.getElementById("BtnPopup").click();

                                    if (CedtOrDbt == "CDT") {
                                        document.getElementById("ModelHeading").innerHTML = "<i class=\"fa fa-line-chart\"></i> Sales  Bill of <span class=\"spn_mod\">" + ledgerval + "</span>";
                                        document.getElementById("ModelHeadingNew").innerHTML = "Sales";
                                        document.getElementById("tdPurchOrSale" + x).value = "PURCH";
                                    }
                                    else {

                                        document.getElementById("ModelHeading").innerHTML = "<i class=\"fa fa-line-chart\"></i> Purchase Bill of <span class=\"spn_mod\">" + ledgerval + "</span>";
                                        document.getElementById("ModelHeadingNew").innerHTML = "Purchase";
                                        document.getElementById("tdPurchOrSale" + x).value = "SAL";
                                    }

                                    var addRowtable = document.getElementById("TableAddQstn");

                                    if (document.getElementById("tdPurchaseDtls" + x).value != "") {
                                        var CstCntrDtl = document.getElementById("tdPurchaseDtls" + x).value;
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

                                if (response.d[1] != "") {
                                    addCommasSummry(response.d[1]);
                                }
                              
                                if (response.d[5] != "") {
                                   
                                    focusPurchase(response.d[5]);
                                }

                                if (response.d[6] != "") {
                                    if (response.d[6] == "0" || response.d[6] == "1") {
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
        function focusPurchase(Rowid) {

            $('#myModal').on('shown.bs.modal', function () {
                document.getElementById("txtPurchaseAmt" + Rowid).focus();
            });
        }

        var $noconfli = jQuery.noConflict();

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
                    if (txtPerVal <= 0) {
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

                if (document.getElementById("tdPurchaseDtls" + x).value != null && document.getElementById("tdPurchaseDtls" + x).value != "" && document.getElementById("tdPurchaseDtls" + x).value != "null") {
                    document.getElementById("TxtAmount_" + x).style.borderColor = "";
                    document.getElementById("TxtAmountCrdt" + x).style.borderColor = "";
                    var PurchaseInfo = document.getElementById("tdPurchaseDtls" + x).value;
                    if (PurchaseInfo != "") {
                        var PrchaseTTl = "0";
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
                                //    PrchsAmt = PrchsAmt.replace(/\,/g, '');
                                PrchaseTTl = parseFloat(PrchaseTTl) + parseFloat(splitEach[1]);
                            }
                        }

                        if (parseFloat(PrchaseTTl) > parseFloat(LdAmt)) {
                            if (CrdtOrDbt=="DBT")
                                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                            else if (CrdtOrDbt == "CDT")
                                document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";
                            else {
                                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                                document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";
                            }


                            $noCon("#divWarning").html("Ledger amount should be greater than or equal to sales amount. ");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
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
            //   document.getElementById("cphMain_txtGrantTotal").value = CstTotal;
            if (CstTotal != 0) {
                if (LedgerTotal != CstTotal) {
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
            //if (ret == true) {
            //    PendingPurchase(x);
            //}
          
            document.getElementById("cphMain_LblDbtTot").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            document.getElementById("cphMain_LblCrdtTot").innerHTML = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            return ret;
        }
 
        function CheckSumOfCstCntr(textboxid, x, y) {
            var CstTotal = 0;
            var LedgerTotal = 0;

            AmountChecking(textboxid);
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

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
                   // document.getElementById("ddlRecptCosCtr_" + varId).style.borderColor = "";
                    $("#divCostCenter" + varId + "> input").css("borderColor", "");

                    if (Costcenterval == 0 && document.getElementById("TxtCstctrAmount_" + varId).value == "") {
    
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
                            // document.getElementById("TxtCstctrAmount_" + varId).value = CstTotal;
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
                        //         document.getElementById("TxtCstctrAmount_" + varId).value = CstTotal;
                        //         addCommas("TxtCstctrAmount_" + varId);
                    }
                }

            });
            var LedgerTotal = 0;
            if (document.getElementById("TxtAmount_" + x).value != "") {
                var ldgramt = document.getElementById("TxtAmount_" + x).value;
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

            return ret;
        }



        function FuctionAddGroup(Ledx) {
           
         
            IncrmntConfrmCounter();
            var addRowtableGrp;
            var addRowResultGrp = true;
            // document.getElementById("ddlRecptLedger" + Ledx).style.borderColor = "";
            $("#divLedger" + Ledx + "> input").css("borderColor", "");

            var check = document.getElementById("tdInxGrp" + Ledx).value;        
            if (check == "") {
                addRowtableGrp = document.getElementById("TableAddQstnCostCenter_" + Ledx);
               
                //if (CheckAndHighlightLedCostCenter(Ledx) == false) {
                //    addRowResultGrp = false;
                //}
                if (CheckSumOfLedger('TxtAmount_' + Ledx , Ledx) == false)
                {
                    addRowResultGrp = false;
                }
                if (LedgerDuplication(Ledx) == false) {
                    addRowResultGrp = false;
                }
                var groupname = document.getElementById("TxtAmount_" + Ledx).value;
                if (groupname == "") {
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
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            $('#TableAddQstnCostCenter' + x + ' td:first-child').each(function () {
                varId = $(this).text();
                var Costcenterval = $("#ddlRecptCosCtr_" + varId).val();
                var ledgerval = $("#ddlRecptLedger" + x).val();
                document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
                $("#divCostCenter" + varId + "> input").css("borderColor", "");
                $("#divCostGrp1" + varId + "> input").css("borderColor", "");
                $("#divCostGrp2" + varId + "> input").css("borderColor", "");
                $("#divLedger" + x + "> input").css("borderColor", "");
                var zero1=0;
                var varzero = zero1.toFixed(FloatingValue);
                if (document.getElementById("TxtCstctrAmount_" + varId).value == "" || parseFloat(document.getElementById("TxtCstctrAmount_" + varId).value.trim().replace(/,/g, "")) <= parseFloat(varzero)) {
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
                //if (ledgerval == "0") {
                //    $("#divLedger" + x + "> input").css("borderColor", "red");
                //    $("#divLedger" + x + "> input").focus();
                //    $("#divLedger" + x + "> input").select();
                //    ret = false;
                //}
                if (ledgerval == 0) {
                    $("#divLedger" + x + "> input").css("borderColor", "red");
                    $("#divLedger" + x + "> input").focus();
                    $("#divLedger" + x + "> input").select();
                    ret = false;
                }


                // }

            });
            return ret;

        }


        function CheckaddMoreRowsQstn(x, y,xy) {
            IncrmntConfrmCounter();
            var addRowtable;
            var addRowResult = true;
            var check = document.getElementById("tdInxQstn" + x + '' + y).value;
            if (check == "") {
                addRowtable = document.getElementById("TableAddQstnCostCenter_" + x);
                if (CCDuplication(x,xy) == false) {
                    addRowResult = false;
                }
                if (addRowResult == true) {
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
                    FunctionQustn(x, y,null,null,null);
                    return false;
                }
            }


            return false;

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
                    // $au("#ddlRecptLedger" + rowCount).selectToAutocomplete1Letter();
                   
                });

                if (document.getElementById("cphMain_HiddenLedgrDupSts").value != "1") {
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
            var ret = true;
            AmountChecking("txtPurchaseAmt" + PurchaseId);

            var tdAmnt = document.getElementById("tdAmnt" + PurchaseId).innerHTML;
            var tdLedgerRow = document.getElementById("tdLedgerRow" + PurchaseId).innerHTML;
            tdAmnt = tdAmnt.replace(/\,/g, '');
            var purchaseAmt = document.getElementById("txtPurchaseAmt" + PurchaseId).value;
            purchaseAmt = purchaseAmt.replace(/\,/g, '');
            var purchaseOrSales = "";

            if (document.getElementById("ModelHeadingNew").innerHTML != "") {
                purchaseOrSales = document.getElementById("ModelHeadingNew").innerHTML;
            }
            if (parseFloat(purchaseAmt) > parseFloat(tdAmnt)) {
               
                if (purchaseOrSales == "Purchase") {
                    document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the purchase amount";
                    $("div.war").fadeIn(200).delay(500).fadeOut(400);
                }
                else if (purchaseOrSales == "Sales") {
                    document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the sale amount";
                    $("div.war").fadeIn(200).delay(500).fadeOut(400);
                }
                ret = false;
            }
            var TxtTotal = 0;
            var TotalPurchaseAmnt = 0;
            var TotalAmnt = 0;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

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
                if (purchaseOrSales == "Purchase")
                    TxtTotal = document.getElementById("TxtAmount_" + tdLedgerRow).value;
                else if (purchaseOrSales == "Sales")
                    TxtTotal = document.getElementById("TxtAmountCrdt" + tdLedgerRow).value;
                  
                if (TotalPurchaseAmnt > TxtTotal) {
                    if (document.getElementById("txtPurchaseAmt" + PurchaseId).value != "") {
                        //if (FloatingValue != "") {
                        //    TotalPurchaseAmnt = TotalPurchaseAmnt.toFixed(FloatingValue);
                        //}
                        //  document.getElementById("LedgerAmtInModalPurchse").innerText = TotalPurchaseAmnt;
                        if (purchaseOrSales == "Purchase") {
                            document.getElementById("lblErrMsgCancelReason").innerHTML = "Purchase total amount should be less than the journal amount";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                        }
                        else if (purchaseOrSales == "Sales") {
                            document.getElementById("lblErrMsgCancelReason").innerHTML = "Sales total amount should be less than the journal amount";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                        }
                        ret = false;

                    }
                }
            }
            addCommas("txtPurchaseAmt" + PurchaseId);

            return ret;
        }

        function ButtnFillClickSales() {
            var ret = true;
            var TotalAmnt = 0;
            var TotalPurchaseAmnt = 0;
            var purchaseFlag = 0;
            var CheckCount = 0;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

            TxtTotal = document.getElementById("LedgerAmtInModalPurchse").innerText;
            TxtTotal = TxtTotal.replace(/\,/g, '');

            var addRowtable = document.getElementById("TableAddQstn");

            for (var i = 1; i < addRowtable.rows.length; i++) {

                var P_Id = (addRowtable.rows[i].cells[0].innerHTML);

                var tdAmnt = document.getElementById("tdAmnt" + P_Id).innerHTML;
                var tdLedgerRow = document.getElementById("tdLedgerRow" + P_Id).innerHTML;
                var purchaseAmt = "";
                document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "";
                if (document.getElementById("txtPurchaseAmt" + P_Id).value != "") {
                    purchaseAmt = document.getElementById("txtPurchaseAmt" + P_Id).value;
                }

                if (document.getElementById("tdSettld" + P_Id).value == "0") {//EVM-0020
                    if (purchaseAmt != "") {
                        purchaseAmt = purchaseAmt.replace(/\,/g, '');
                        TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt) + parseFloat(purchaseAmt);
                        purchaseFlag++;


                        if (parseFloat(purchaseAmt) > parseFloat(tdAmnt)) {
                            document.getElementById("lblErrMsgCancelReason").innerHTML = "Entered amount should be less than the purchase amount";
                            document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "red";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                            ret = false;
                        }
                    }

                }

            }
            if (purchaseFlag == 0) {
                //document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill purchase amount to import.";
                //document.getElementById("divErrMsgCnclRsn").style.display = "";
                //ret = false;

            }
            if (ret == true) {
                var TxtTotal = "0";
                var CrdtOrDbt = "";
                if (TotalPurchaseAmnt != "" && TotalPurchaseAmnt != 0) {
                    if (document.getElementById("TxtAmount_" + tdLedgerRow).value != "") {
                        TxtTotal = document.getElementById("TxtAmount_" + tdLedgerRow).value;
                        CrdtOrDbt = "DBT";
                    }
                    if (document.getElementById("TxtAmountCrdt" + tdLedgerRow).value != "") {
                        TxtTotal = document.getElementById("TxtAmountCrdt" + tdLedgerRow).value;
                        CrdtOrDbt = "CDT";
                    }
                    TxtTotal = TxtTotal.replace(/\,/g, '');
                    if (parseFloat(TotalPurchaseAmnt) > parseFloat(TxtTotal)) {
                        if (FloatingValue != "") {
                            TotalPurchaseAmnt = TotalPurchaseAmnt.toFixed(FloatingValue);
                        }
                        if (CrdtOrDbt == "CDT") {
                            document.getElementById("lblErrMsgCancelReason").innerHTML = "Sales total amount should be less than the journal amount";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                        }
                        if (CrdtOrDbt == "DBT") {
                            document.getElementById("lblErrMsgCancelReason").innerHTML = "Purchase total amount should be less than the journal amount";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                        }
                        ret = false;
                    }

                }

                addCommas("TxtAmount_" + tdLedgerRow);
                addCommas("TxtAmountCrdt" + tdLedgerRow);
                if (TotalPurchaseAmnt != 0) {
                    if (FloatingValue != "") {
                        TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt);
                        TotalPurchaseAmnt = TotalPurchaseAmnt.toFixed(FloatingValue);
                    }
                }
            }

            //if (ret == true) {
            //    for (var i = 1; i < addRowtable.rows.length; i++) {
            //        var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
            //        var tdAmnt = document.getElementById("tdAmnt" + P_Id).innerHTML;
            //        var tdLedgerRow = document.getElementById("tdLedgerRow" + P_Id).innerHTML;
            //        //if (i == 0) {
            //        //    document.getElementById("tdPurchaseDtls" + tdLedgerRow).value = "";
            //        //}
            //        var purchaseAmt = "";
            //        document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "";
            //        if (document.getElementById("txtPurchaseAmt" + P_Id).value != "") {
            //            purchaseAmt = document.getElementById("txtPurchaseAmt" + P_Id).value;
            //        }
            //        if (purchaseAmt != "") {
            //            purchaseAmt = purchaseAmt.replace(/\,/g, '');
            //            TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt) + parseFloat(purchaseAmt);
            //            purchaseFlag++;
            //        }
            //if (ret == true) {
            //    if (document.getElementById("tdSaleID" + P_Id).innerHTML != "" && document.getElementById("txtPurchaseAmt" + P_Id).value != "") {
            //        alert("tdLedgerRow    " + tdLedgerRow);
            //        alert("tdPurchaseDtls    " + document.getElementById("tdPurchaseDtls" + tdLedgerRow).value);
            //        if (document.getElementById("tdPurchaseDtls" + tdLedgerRow).value == "") {
            //            document.getElementById("tdPurchaseDtls" + tdLedgerRow).value = document.getElementById("tdSaleID" + P_Id).innerHTML + "%" + document.getElementById("txtPurchaseAmt" + P_Id).value + "%" + document.getElementById("tdsettlmntAmnt" + P_Id).innerHTML;
            //        }
            //        else {
            //            document.getElementById("tdPurchaseDtls" + tdLedgerRow).value = document.getElementById("tdPurchaseDtls" + tdLedgerRow).value + "$" + document.getElementById("tdSaleID" + P_Id).innerHTML + "%" + document.getElementById("txtPurchaseAmt" + P_Id).value + "%" + document.getElementById("tdsettlmntAmnt" + P_Id).innerHTML;
            //        }
            //    }

            //}


            if (ret == true) {
                document.getElementById("tdPurchaseDtls" + tdLedgerRow).value = "";
                for (var i = 1; i < addRowtable.rows.length; i++) {
                    var P_Id = (addRowtable.rows[i].cells[0].innerHTML);
                    //var tdAmnt = document.getElementById("tdAmnt" + P_Id).innerHTML;
                    //var tdLedgerRow = document.getElementById("tdLedgerRow" + P_Id).innerHTML;
                    //var purchaseAmt = "";
                    //document.getElementById("txtPurchaseAmt" + P_Id).style.borderColor = "";
                    //purchaseAmt = document.getElementById("txtPurchaseAmt" + P_Id).value;
                    //if (purchaseAmt != "") {
                    //    purchaseAmt = purchaseAmt.replace(/\,/g, '');
                    //    TotalPurchaseAmnt = parseFloat(TotalPurchaseAmnt) + parseFloat(purchaseAmt);
                    //}
                    if (ret == true) {
                        if (document.getElementById("tdSaleID" + P_Id).innerHTML != "" && document.getElementById("txtPurchaseAmt" + P_Id).value != "") {
                            if (document.getElementById("tdPurchaseDtls" + tdLedgerRow).value == "") {
                                document.getElementById("tdPurchaseDtls" + tdLedgerRow).value = document.getElementById("tdSaleID" + P_Id).innerHTML + "%" + document.getElementById("txtPurchaseAmt" + P_Id).value + "%" + document.getElementById("tdsettlmntAmnt" + P_Id).innerHTML;
                            }
                            else {
                                document.getElementById("tdPurchaseDtls" + tdLedgerRow).value = document.getElementById("tdPurchaseDtls" + tdLedgerRow).value + "$" + document.getElementById("tdSaleID" + P_Id).innerHTML + "%" + document.getElementById("txtPurchaseAmt" + P_Id).value + "%" + document.getElementById("tdsettlmntAmnt" + P_Id).innerHTML;
                            }
                        }

                    }
                }
            }




            // }

            if (ret == true) {
                //  if (purchaseFlag != 0) {
                calculateTotal();
                document.getElementById("BttnTemp").click();
                // }
            }
        }
     
        function ButtnFillClickCostCenter(x) {
            var ret = true;
          //  var TotalAmnt = 0;
            var purchaseFlag = 0;
            var CheckCount = 0;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

           // var TotalAmnt = document.getElementById("TxtAmount_" + x).value;
            var CrdtOrDbt = "";
            var TotalAmnt = "0";
            if (document.getElementById("TxtAmount_" + x).value != "") {
                TotalAmnt = document.getElementById("TxtAmount_" + x).value;
                CrdtOrDbt = "DBT";
            }
            if (document.getElementById("TxtAmountCrdt" + x).value != "") {
                TotalAmnt = document.getElementById("TxtAmountCrdt" + x).value;
                CrdtOrDbt = "CDT";
            }

           // LdAmt = LdAmt.replace(/\,/g, '');


            document.getElementById("lblErrMsgCancelReasonCost").style.display = "none";

            TotalAmnt = TotalAmnt.replace(/\,/g, '');
            var addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
           // document.getElementById("tdCostCenterDtls" + x).value = "";
            var CstTotal = 0;
            for (var i = 1; i < addRowtable.rows.length; i++) {
                var varId = (addRowtable.rows[i].cells[0].innerHTML);



              
                $("#divCostCenter" + varId + "> input").css("borderColor", "");


                if (CCDuplication(x, varId) == false) {
                    ret = false;
                }


                document.getElementById("divCostCenter" + varId).style.borderColor = "";
                document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
                var Costval = $("#ddlRecptCosCtr_" + varId).val();
                var CostGrp1 = $("#ddlRecptCosGrp1_" + varId).val();
                var CostGrp2 = $("#ddlRecptCosGrp2_" + varId).val();


                var zero1 = 0;
                var varzero = zero1.toFixed(FloatingValue);


                if (CostGrp1 != 0 || CostGrp2 != 0 || Costval != 0 || document.getElementById("TxtCstctrAmount_" + varId).value != "") {

                    if (document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                        document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                        document.getElementById("lblErrMsgCancelReasonCost").innerHTML = "Please enter cost centre amount";
                        document.getElementById("lblErrMsgCancelReasonCost").style.display = "block";
                        document.getElementById("TxtCstctrAmount_" + varId).focus();
                        ret = false;
                    }
                    if (Costval == 0) {
                        $("#divCostCenter" + varId + "> input").css("borderColor", "Red");
                        document.getElementById("lblErrMsgCancelReasonCost").innerHTML = "Please select a cost centre";
                        document.getElementById("lblErrMsgCancelReasonCost").style.display = "block";
                        $("#divCostCenter" + varId + "> input").focus();
                        $("#divCostCenter" + varId + "> input").select();
                        ret = false;
                    }

                    if (ret == true) {
                        if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                            var ldgramt = document.getElementById("TxtCstctrAmount_" + varId).value;
                            ldgramt = ldgramt.replace(/\,/g, '');
                            CstTotal = parseFloat(CstTotal) + parseFloat(ldgramt);
                            purchaseFlag++;

                        }
                    }

                }
            }
            if (ret == true) {

                if (CstTotal != "" && CstTotal != "0") {

                        if (parseFloat(TotalAmnt) != parseFloat(CstTotal)) {
                            document.getElementById("lblErrMsgCancelReasonCost").innerHTML = " Ledger amount should be equal to cost centre amount";
                            document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                            document.getElementById("TxtCstctrAmount_" + varId).focus();
                            document.getElementById("lblErrMsgCancelReasonCost").style.display = "block";
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

                    document.getElementById("BttnCost" + x).click();

                    //    $noCon('#myModalCstCntr').modal('hide'); 
                }
                else {
                    document.getElementById("BttnCost" + x).click();
                }
            }
        
        }
    </script>

    <script>
        function ValidateReceiptAccnt(ClickedBtn) {
            var ret = true;
        
            var AccntDate = document.getElementById("cphMain_txtdate").value;
            document.getElementById("cphMain_txtdate").style.borderColor = "";
            //if (ClickedBtn.id != "cphMain_btnReopen") {
                if (AccntDate == "") {
                    document.getElementById("cphMain_txtdate").style.borderColor = "Red";
                    document.getElementById("cphMain_txtdate").focus();

                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    $noCon(window).scrollTop(0);
                    ret = false;
                }
            //}
        
            if (ret == true) {
                if (!(validateTable(ret))) {
                    ret = false;
                }

                else {
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

                var PurchaseInfo = document.getElementById("tdPurchaseDtls" + xLoop).value;
                var CrdtDbt = document.getElementById("tdPurchOrSale" + xLoop).value;

                if (PurchaseInfo != "" && PurchaseInfo != null && PurchaseInfo != "null") {

                    var strOrgIdID = '<%=Session["ORGID"]%>';
                    var strCorpID = '<%=Session["CORPOFFICEID"]%>';

                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "fms_Journal.aspx/CheckSaleSettlement",
                        data: '{strSalePurchaseDtls: "' + PurchaseInfo + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",strCrdtDbt: "' + CrdtDbt + '"}',
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
                        SuccessSts = "SalePrchsAmtFullySettld";
                        continue;
                    }
                }
                else if (SuccessSts == "SalesAmtFullySettld") {
                    Settld++;
                    continue;
                }
                else if (SuccessSts == "SalesAmountExceeded") {
                    break;
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
            else if (SuccessSts == "SalesAmtFullySettld") {
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
            else if (SuccessSts == "SalesAmountExceeded") {
                SalesAmountExceeded();
            }
            else if (SuccessSts == "SalePrchsAmtFullySettld") {
                ezBSAlert({
                    type: "confirm",
                    messageText: "One or more purchase/sale amount(s) is fully settled. Do you want to confirm by deleting added purchases/sales?",
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

            else if (data.d == 'failed') {
                SuccessErrorReoen();
            }

            return false;
        }


        function SalesAmountExceeded() {
            $noCon("#divWarning").html(" Journal amount should not be greater than sales amount.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function PurchaseAmountExceeded() {
            $noCon("#divWarning").html(" Journal amount should not be greater than purchase amount.");
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
        function PrchsAmtFullySettld() {
            $noCon("#divWarning").html("Purchase amount is already settled.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }


        function validateTable(retchk) {
            document.getElementById("<%=HiddenFieldJornlDataLedgr.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldJornlDataCostCentr.ClientID%>").value = "";
            var Result = true;
            var varfocus = "";
            var varfocusLed = "";
            var varfocusCheck = "";
            var ret = true;
            var purchaseret = true;
            var varTotal = 0;
            //addRowtable = document.getElementById("tableGrp");
            //var RowLength = addRowtable.rows.length;
            //for (var i = 0; i < addRowtable.rows.length; i++) {
            //    var row = addRowtable.rows[i];
            //    var x = (addRowtable.rows[i].cells[0].innerHTML);




            //var CstTotal = 0;
            //var varId = "";
            //var varfocus = "";
            //document.getElementById("TxtAmount_" + x).style.borderColor = "";

            //var LedgerTotal = 0;
            //var ledgerval = $("#ddlRecptLedger" + x).val();



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

                LdAmt = LdAmt.replace(/\,/g, '');

                if (document.getElementById("tdPurchaseDtls" + x).value != null && document.getElementById("tdPurchaseDtls" + x).value != "" && document.getElementById("tdPurchaseDtls" + x).value != "null") {
                    document.getElementById("TxtAmount_" + x).style.borderColor = "";
                    document.getElementById("TxtAmountCrdt" + x).style.borderColor = "";
                    var PurchaseInfo = document.getElementById("tdPurchaseDtls" + x).value;
                    if (PurchaseInfo != "") {
                        var PrchaseTTl = "0";
                        var splitrow = PurchaseInfo.split("$");
                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var CstGrp1Id = "";
                            var CstGrp2Id = "";

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
                                //    PrchsAmt = PrchsAmt.replace(/\,/g, '');
                                PrchaseTTl = parseFloat(PrchaseTTl) + parseFloat(splitEach[1]);
                            }
                        }
                        if (parseFloat(PrchaseTTl) > parseFloat(LdAmt)) {
                            if (CrdtOrDbt == "DBT")
                                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                            else if (CrdtOrDbt == "CDT")
                                document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";
                            else {
                                document.getElementById("TxtAmount_" + x).style.borderColor = "red";
                                document.getElementById("TxtAmountCrdt" + x).style.borderColor = "red";
                            }


                            $noCon("#divWarning").html("Ledger amount should be greater than or equal to sales amount. ");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
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
            //   document.getElementById("cphMain_txtGrantTotal").value = CstTotal;
            if (CstTotal != 0) {
                if (LedgerTotal != CstTotal) {
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
            }

            //if (document.getElementById("ddlRecptLedger" + x).value == 0) {
            //    $("#divLedger" + x + "> input").css("borderColor", "red");
            //    $("#divLedger" + x + "> input").focus();
            //    $("#divLedger" + x + "> input").select();
            //    ret = false;
            //}




            //   if (RowLength == 1) {
            addRowtable = document.getElementById("tableGrp");
            var RowLength = addRowtable.rows.length;

            if (RowLength != 1) {

                for (var i = 0; i < addRowtable.rows.length - 1; i++) {
                    var row = addRowtable.rows[i];
                    var x = (addRowtable.rows[i].cells[0].innerHTML);

                    //if (document.getElementById("TxtAmount_" + x).value == "") {
                    //    document.getElementById("TxtAmount_" + x).style.borderColor = "Red";
                    //    document.getElementById("TxtAmount_" + x).focus();
                    //    ret = false;
                    //}
                    if (document.getElementById("ddlRecptLedger" + x).value == 0) {
                        //    document.getElementById("ddlRecptLedger" + x).style.borderColor = "Red";
                        // divLedger
                        $("#divLedger" + x + "> input").css("borderColor", "red");
                        $("#divLedger" + x + "> input").focus();
                        $("#divLedger" + x + "> input").select();
                        // document.getElementById("ddlRecptLedger" + x).focus();
                        ret = false;
                    }
                }
            }
            else {

                for (var i = 0; i < addRowtable.rows.length ; i++) {
                    var row = addRowtable.rows[i];
                    var x = (addRowtable.rows[i].cells[0].innerHTML);

                    if (document.getElementById("ddlRecptLedger" + x).value == 0) {
                        //    document.getElementById("ddlRecptLedger" + x).style.borderColor = "Red";
                        // divLedger
                        $("#divLedger" + x + "> input").css("borderColor", "red");
                        $("#divLedger" + x + "> input").focus();
                        $("#divLedger" + x + "> input").select();
                        // document.getElementById("ddlRecptLedger" + x).focus();
                        ret = false;
                    }
                }
            }

            // }
            if (ret == true) {
                document.getElementById("cphMain_lblTotDeb").style.borderColor = "";
                document.getElementById("cphMain_lblTotCrdt").style.borderColor = "";


                if (LedgerTtl != LedgerCrdtTtl) {
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing.Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("cphMain_lblTotDeb").style.borderColor = "Red";
                    document.getElementById("cphMain_lblTotCrdt").style.borderColor = "Red";
                    return false;
                }

                if (LedgerTtl == 0 || LedgerCrdtTtl == 0) {
                    $noCon("#divWarning").html("Cannot insert zero amount!");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("cphMain_lblTotDeb").style.borderColor = "Red";
                    document.getElementById("cphMain_lblTotCrdt").style.borderColor = "Red";
                    return false;
                }
            }



            if (ret == false) {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing.Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                return false;
            }







            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];

            var tbClientJobShedulingCost = '';
            tbClientJobShedulingCost = [];


            var tabMode = "Deb";
            var tableOtherItem = document.getElementById("tableGrp");


            for (var i = 0; i < tableOtherItem.rows.length; i++) {
                var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                var Ledgr = document.getElementById("ddlRecptLedger" + validRowID).value;
                if (Ledgr != 0) {
                    var CrdtOrDbt = "";
                    var varTabMode = "";
                    var LedgrAmnt = "0";
                    var LedgrRemarks = document.getElementById("TxtRemark" + validRowID).value.trim().replace(/,/g, "");
                    var LedgrAmntDbt = document.getElementById("TxtAmount_" + validRowID).value.trim().replace(/,/g, "");
                    var LedgrAmntCrdt = document.getElementById("TxtAmountCrdt" + validRowID).value.trim().replace(/,/g, "");
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
                            MAINTABID: "" + validRowID + "",
                            LEDGRTABID: "",
                            LEDGRID: "" + Ledgr + "",
                            LEDGRAMNT: "" + LedgrAmnt + "",
                            //REMARKS: "" + LedgrRemarks + ""
                        });
                    }
                    else if (CrdtOrDbt == "CDT") {
                        var client = JSON.stringify({
                            TABMODE: "1",
                            MAINTABID: "" + validRowID + "",
                            LEDGRTABID: "",
                            LEDGRID: "" + Ledgr + "",
                            LEDGRAMNT: "" + LedgrAmnt + "",
                            //REMARKS: "" + LedgrRemarks + ""
                        });

                    }
                    tbClientJobSheduling.push(client);

                    var DtlPurchase = document.getElementById("tdPurchaseDtls" + validRowID).value;
                    var DtlCostCenter = document.getElementById("tdCostCenterDtls" + validRowID).value;


                    if (DtlPurchase != "") {
                        var splitrow = DtlPurchase.split("$");
                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var splitEach = splitrow[Cst].split("%");
                            if (splitEach[0] != "") {
                                var $add = jQuery.noConflict();
                                var client = JSON.stringify({
                                    TABMODE: "" + varTabMode + "",
                                    MAINTABID: "" + validRowID + "",
                                    SUBTABID: "",
                                    COSTCENTRTABID: "",
                                    COSTCENTRID: "" + splitEach[0] + "",
                                    COSTCENTRAMNT: "" + splitEach[1] + "",
                                    PURSALESTS: "" + varPurSts + "",

                                    SETTLMNT_AMT: "" + splitEach[2] + "",
                                });
                                tbClientJobShedulingCost.push(client);
                            }
                        }
                    }
                    if (DtlCostCenter != "") {
                        var splitrow = DtlCostCenter.split("$");
                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var splitEach = splitrow[Cst].split("%");
                            if (splitEach[0] != "") {
                                var $add = jQuery.noConflict();
                                var client = JSON.stringify({
                                    TABMODE: "" + varTabMode + "",
                                    MAINTABID: "" + validRowID + "",
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
                }
            }


            document.getElementById("<%=HiddenFieldTotAmnt.ClientID%>").value = LedgerCrdtTtl;
            $add("#cphMain_HiddenFieldJornlDataLedgr").val(JSON.stringify(tbClientJobSheduling));
            $add("#cphMain_HiddenFieldJornlDataCostCentr").val(JSON.stringify(tbClientJobShedulingCost));





            return ret;
        }
  
      
            function ConfirmMessageAdd() {

                if (confirmbox > 0) {
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to leave this page?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            window.location.href = "fms_Journal_List.aspx";
                        }
                        else {
                            return false;
                        }
                    });
                }
                else {
                    window.location.href = "fms_Journal_List.aspx";
                }
                return false;

            }
        


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
            var strId = document.getElementById("<%=HiddenJrnlId.ClientID%>").value;
            var crncyAbrvt = document.getElementById("<%=HiddenCurrencyAbrv.ClientID%>").value;
            var crncyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
            var DecCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            if (strCorpID != "" && strCorpID != null && strOrgIdID != "" && strOrgIdID != null && strUserID != null && strUserID != "" && strId != "") {
                
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Journal.aspx/PrintPDF",
                    data: '{Id: "' + strId + '",orgID: "' + strOrgIdID + '",corptID: "' + strCorpID + '",UsrName: "' + UsrName + '",DecCnt: "' + DecCnt + '"}',
                   
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

       </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" />
    <asp:HiddenField ID="HiddentxtefctvedateTo" runat="server" />
    <asp:HiddenField ID="HiddenPurchseSaleStatus" runat="server" />
    <asp:HiddenField ID="HiddenFieldTaxId" runat="server" />
    <asp:HiddenField ID="HiddenChkSts" runat="server" />
    <asp:HiddenField ID="HiddenupdCheckNumber" runat="server" />
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
    <asp:HiddenField ID="hiddenLedgerCanclDtlId" runat="server" />
    <asp:HiddenField ID="hiddenQstnCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenCostCenterEdit" runat="server" />
    <asp:HiddenField ID="HiddenPurchaseEdit" runat="server" />
    <asp:HiddenField ID="HiddenGrdTotl" runat="server" />
    <asp:HiddenField ID="HiddenPrevTab" runat="server" />
    <asp:HiddenField ID="HiddenEdit" runat="server" />
    <asp:HiddenField ID="HiddenCurrencyAbrv" runat="server" />
    <asp:HiddenField ID="HiddenFieldJornlDataLedgr" runat="server" />
    <asp:HiddenField ID="HiddenFieldJornlDataCostCentr" runat="server" />
    <asp:HiddenField ID="HiddenFieldTotAmnt" runat="server" />
    <asp:HiddenField ID="HiddenFieldAcntCloseReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenRowCount" runat="server" />
    <asp:HiddenField ID="HiddenFieldViewMode" runat="server" />
    <asp:HiddenField ID="HiddenStartDate" runat="server" />
    <asp:HiddenField ID="HiddenAcntClsDate" runat="server" />
    <asp:HiddenField ID="HiddenRefAccountCls" runat="server" />
    <asp:HiddenField ID="HiddenRefChange" runat="server" />
    <asp:HiddenField ID="HiddenEditDate" runat="server" />
    <asp:HiddenField ID="HiddenJournalID" runat="server" />
    <asp:HiddenField ID="HiddenUpdRefNum" runat="server" />
    <asp:HiddenField ID="HiddenJrnlId" runat="server" />
    <asp:HiddenField ID="HiddenCostGroup1ddl" runat="server" />
    <asp:HiddenField ID="HiddenCostGroup2ddl" runat="server" />
    <asp:HiddenField ID="HiddenLedgrDupSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldAuditCloseReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenExchngCurrency" runat="server" />
    <asp:HiddenField ID="hiddenPostdated" runat="server" />

    <div class="myAlert-top alert alert-success" id="success-alert">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Success!</strong> Changes completed succesfully
    </div>

    <div class="myAlert-bottom alert alert-danger" id="divWarning">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Danger!</strong> Request not conmpleted
    </div>

    <div id="divLinkSection" runat="server">
        <ol class="breadcrumb">
            <li><a id="aHome" runat="server" href="">Home</a></li>
            <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
            <li><a href="fms_Journal_List.aspx">Journal</a></li>
            <li class="active" id="PathlblEntry" runat="server">Add Journal</li>
        </ol>
    </div>

    <div id="divList" runat="server" class="list_b" style="cursor: pointer;" onclick="return ConfirmMessageAdd()" title="Back to List">
        <i class="fa fa-arrow-circle-left"></i>
    </div>

    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                <div class="" onmouseover="closesave()">
                    <h2 id="lblEntry" runat="server">Add Journal</h2>

                    <div class="fg2">
                        <label for="email" class="fg2_la1">Journal REF#:<span class="spn1">*</span></label>
                        <input type="text" id="TxtRef" class="form-control fg2_inp1 inp_mst" runat="server" name="email" required="" disabled />
                    </div>
                    <div class="fg2">
                        <div class="tdte">
                            <label for="pwd" class="fg2_la1">Date:<span class="spn1">*</span></label>
                            <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                                <input class="form-control inp_bdr inp_mst" type="text" id="txtdate" readonly="readonly" runat="server" onkeypress="return DisableEnter(event)" onchange="showFromDate()" />
                                <span id="DateSpan" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                            </div>
                            <script>

                                var curentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value
                                var StartDate = document.getElementById("<%=HiddenStartDate.ClientID%>").value
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
                                    var usrID = '<%= Session["USERID"] %>';
                                    var corptID = '<%= Session["CORPOFFICEID"] %>';
                                    var jrnlDate = $('#cphMain_txtdate').val().trim();
                                    var RefNum = $('#cphMain_HiddenUpdRefNum').val().trim();
                                    var jrnlID = $('#cphMain_HiddenJournalID').val().trim();
                                    var AcntPrvsn = document.getElementById("<%=HiddenFieldAcntCloseReopenSts.ClientID%>").value
                      var AuditPrvsn = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value

                                    if (jrnlDate != "") {

                                        $.ajax({
                                            type: "POST",
                                            async: false,
                                            contentType: "application/json; charset=utf-8",
                                            url: "fms_Journal.aspx/CheckAcntCloseSts",
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
                                    if (jrnlDate != "" && (document.getElementById("<%=HiddenFieldAcntCloseReopenSts.ClientID%>").value == "1" || document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value == "1")) {

                          if (document.getElementById("<%=HiddenRefAccountCls.ClientID%>").value == "1") {
                              $.ajax({
                                  type: "POST",
                                  async: false,
                                  contentType: "application/json; charset=utf-8",
                                  url: "fms_Journal.aspx/CheckRefNumber",
                                  data: '{jrnlDate: "' + jrnlDate + '",orgID: "' + orgID + '",corptID: "' + corptID + '",usrID: "' + usrID + '",RefNum: "' + RefNum + '",jrnlID: "' + jrnlID + '"}',
                                  dataType: "json",
                                  success: function (data) {

                                      if (document.getElementById("<%=HiddenEdit.ClientID%>").value == "1") {
                                      if (data.d != "" && document.getElementById("<%=HiddenRefChange.ClientID%>").value != "") {
                                          if (document.getElementById("cphMain_TxtRef").value != data.d) {
                                              ezBSAlert({
                                                  type: "confirm",
                                                  messageText: "This action will change the reference number.Are you sure you want to continue?",
                                                  alertType: "info"
                                              }).done(function (e) {
                                                  if (e == true) {
                                                      document.getElementById("cphMain_TxtRef").value = data.d;
                                                      document.getElementById("<%=HiddenRefChange.ClientID%>").value = $('#cphMain_txtdate').val().trim();
                                                  } else {
                                                      $('#cphMain_txtdate').val(document.getElementById("<%=HiddenRefChange.ClientID%>").value);
                                                      // return false;
                                                  }

                                              });
                                          }

                                      }
                                  }
                                  else {

                                      if (data.d != "") {

                                          document.getElementById("cphMain_TxtRef").value = data.d;
                                      }
                                  }
                              }
                          });
                      }

                  }
              }
              function updDebitColor() {
                  $('#tableGrp td:first-child').each(function () {
                      var varId = $(this).text();
                      PendingPurchase('TxtAmount_' + varId, varId, 'DBT');
                      PendingPurchase('TxtAmountCrdt' + varId, varId, 'CDT');
                  });
              }

                            </script>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="devider"></div>


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
                    <script>
                        function enableexchangeRate() {
                            var CurrencyId = document.getElementById("<%=ddlCurrency.ClientID%>").value;
                            if (CurrencyId == "307") {
                                document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = "INR";
                                         document.getElementById("CurrencyAbrv").innerHTML = "INR";
                                     }
                                     else if (CurrencyId == "308") {
                                         document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = "OMR";
                                               document.getElementById("CurrencyAbrv").innerHTML = "OMR";

                                           }
                                           else if (CurrencyId == "309") {
                                               document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = "USD";
                                                   document.getElementById("CurrencyAbrv").innerHTML = "USD";

                                               }

                                       var DftCurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
                            if (CurrencyId == DftCurrencyId) {
                                document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                                         document.getElementById("CurrencyAbrv").style.display = "none";

                                     }
                                     else if (CurrencyId == "--SELECT CURRENCY--") {
                                         document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                                               document.getElementById("CurrencyAbrv").style.display = "none";

                                           }
                                           else {
                                               document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "";
                                               document.getElementById("CurrencyAbrv").style.display = "";
                                               calculateTotal();
                                           }
                                   }
                    </script>





                    <table class="table table-bordered">
                        <thead class="thead1">
                            <tr>
                                <th class="col-md-3 t_r">Particulars</th>
                                <th class="col-md-2 tr_c tr_r">Debit Amount</th>
                                <th class="col-md-2 tr_c tr_r">Credit Amount</th>
                                <th class="col-md-3 tr_l">Remarks</th>
                                <th class="col-md-1 tr_c">ACTIONS</th>
                                <th class="col-md-1 tr_c" id="tsPursheSaleCC">Purchase/sale/CC</th>
                            </tr>
                        </thead>
                    </table>

                    <table id="tableGrp" class="table table-bordered">
                        <tbody id="tabMainDebBody" runat="server"></tbody>
                    </table>


                    <table class="table table-bordered" id="Table1">
                        <thead class="ft_q">
                            <tr>
                                <th class="col-md-3 t_r">TOTAL AMOUNT</th>
                                <th class="col-md-2 tr_c tr_r am3">
                                    <input disabled id="lblTotDeb" runat="server" /><label id="LblDbtTot" runat="server"></label></th>
                                <th class="col-md-2 tr_c tr_r am2">
                                    <input disabled id="lblTotCrdt" runat="server" /><label id="LblCrdtTot" runat="server"></label></th>
                                <th class="col-md-3 tr_c"></th>
                                <th class="col-md-1 tr_c"></th>
                                <th class="col-md-1 tr_c"></th>
                            </tr>
                        </thead>
                    </table>
                    <div class="text_area_container">
                        <div class="col-md-8">
                            <div class="form-group iv">
                                <label for="email" class="fg2_la1">Narration:<span class="spn1">&nbsp;</span></label>
                                <textarea id="txtDescription" rows="4" cols="50" class="form-control" placeholder="Write something here..." runat="server" maxlength="300" onblur="return textCounter(cphMain_txtDescription, 300)" onchage="return textCounter(cphMain_txtDescription, 300)" style="resize: none"></textarea>
                            </div>
                        </div>
                    </div>




                    <div class="col-md-6" style="margin-bottom: 20px; display: none">
                        <label for="example-text-input" class="col-md-1 col-form-label" style="margin-left: 16%; width: 22%;">Total Amount<span></span></label>
                        <div class="col-md-11" style="width: 55%;">
                            <input id="txtGrantTotal" readonly="readonly" style="width: 100%; margin-left: 2%; float: right; text-align: right;" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control" maxlength="50" />
                        </div>
                    </div>
                    <div class="col-md-6" style="display: none; margin-bottom: 20px;">
                        <label for="example-text-input" class="col-md-1 col-form-label" style="margin-left: 16%; width: 22%;">Forex Amount<span></span></label>
                        <div class="col-md-11" style="width: 55%;">
                            <input id="txtForexTotal" readonly="readonly" style="width: 100%; margin-left: 2%; float: right; text-align: right;" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control" maxlength="50" />
                        </div>
                    </div>



                    <!-- Modal purchase/sale-->

                    <div class="modal fade" id="myModal" role="dialog" data-backdrop="static" tabindex="-1">
                        <div class="modal-dialog mod1">
                            <!-- Modal content-->
                            <div class="modal-content">

                                <div class="modal-header">
                                    <button type="button" class="close" onclick="return CloseModalPurchase()">&times;</button>
                                    <h2 id="ModelHeading" class="modal-title mod1 flt_l"></h2>
                                    <h2 id="ModelHeadingNew" class="modal-title mod1 flt_l" style="display: none;"></h2>
                                </div>

                                <div class="al-box war" id="lblErrMsgCancelReason">Please fill this out</div>

                                <div class="modal-body md_bd1">
                                    <div id="DivPopUpSales"></div>

                                    <div class="clearfix"></div>
                                    <div class="devider"></div>

                                    <div class="col-md-12 col_mar">
                                        <div class="box6 tr_r">
                                            <label id="Label1" for="email" class="fg2_la1 tt_am am1">Ledger Amount<span class="spn1"></span>:</label>
                                        </div>
                                        <div class="box6 flt_r">
                                            <span id="LedgerAmtInModalPurchse" class="tt_am am1 tt_al"></span>
                                        </div>
                                    </div>

                                </div>

                                <div class="modal-footer">
                                    <button id="btnImportSales" type="button" class="btn btn-success" onclick="ButtnFillClickSales();">Submit</button>
                                    <button id="BttnTemp" type="button" style="display: none" class="btn btn-primary" data-dismiss="modal"></button>
                                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                                </div>

                            </div>
                        </div>
                    </div>

                    <!-- Modal purchase/sale end-->


                </div>

                <!-- Modal cost centre-->

                <div id="CostCenterModal"></div>

                <!-- Modal cost centre end-->


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
                        //DateCheck();
                        IncrmntConfrmCounter();
                        //  DateCurrentValue();
                        // $noCon4("#txtDateFrom").datetimepicker({ format: 'dd-mm-yyyy' })
                        $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#cphMain_txtFromdate').val().trim());


                    }

                    function showTo() {
                        //DateCheck();
                        IncrmntConfrmCounter();
                        //  DateCurrentValueTo();
                        // $noCon4("#txtDateFrom").datetimepicker({ format: 'dd-mm-yyyy' })
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

                <div class="clearfix"></div>
                <div class="free_sp"></div>
                <div class="devider divid"></div>


                <button id="BtnPopup" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>
                <button id="BtnPopupCstCntr" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModalCstCntr">Open Modal</button>


                <!--Buttons_Area_started--->
                <div class="sub_cont pull-right">
                    <div class="save_sec1">


                        <asp:Button ID="bttnsave" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" OnClick="bttnsave_Click" class="btn sub1" Text="Save" />
                        <asp:Button ID="btnSaveCls" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub3" Text="Save & Close " OnClick="bttnsave_Click" />


                        <asp:Button ID="btnUpdate" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub1" OnClick="btnUpdate_Click" Text="Update" />
                        <asp:Button ID="btnUpdatecls" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />

                        <asp:Button ID="btnConfirm" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub2" Text="Confirm" />
                        <asp:Button ID="btnConfirm1" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub2" OnClick="btnUpdate_Click" Text="confm" Style="display: none;" />

                        <asp:Button ID="btnReopen" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub2" Text="Reopen" />

                        <input type="button" id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />

                        <asp:Button ID="ButtReopn" runat="server" OnClick="btnReopen_Click" Style="display: none;" class="btn sub2" Text="Confirm" />

                        <asp:Button ID="Button1" runat="server" OnClick="btnConfirm_Click" Style="display: none;" class="btn btn-primary btn-grey  btn-width" Text="Confirm" />
                        <asp:Button ID="ButtnClose" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                        <asp:Button ID="btnPRint" runat="server" class="btn sub2" Text="Print" OnClientClick="return  PrintValue(); " />


                    </div>
                </div>
                <!--buttons_area_closed--->
            </div>
            <!----frame_closed section to footer script section--->
        </div>
    </div>
    <a id="btnFloat" runat="server" onmouseover="opensave()" type="button" class="save_b" title="Save">
        <i class="fa fa-save"></i>
    </a>
    <%--    <div class="clearfix"></div>
    <div class="free_sp"></div>
    <div class="devider divid"></div>--%>

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
        function AlertClearAll() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Journal.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "fms_Journal.aspx";
                return false;
            }
        }
    </script>


    <div class="mySave1" id="mySave" runat="server">
        <div class="save_sec">

            <asp:Button ID="btnFloatSave" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" OnClick="bttnsave_Click" class="btn sub1" Text="Save" />
            <asp:Button ID="btnFloatSaveCls" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub3" Text="Save & Close " OnClick="bttnsave_Click" />
            <asp:Button ID="btnFloatUpdate" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub1" OnClick="btnUpdate_Click" Text="Update" />
            <asp:Button ID="btnFloatUpdateCls" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnFloatConfirm" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub2" Text="Confirm" />
            <asp:Button ID="btnFloatConfirm1" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub2" OnClick="btnUpdate_Click" Text="confm" Style="display: none;" />
            <asp:Button ID="btnFloatReopen" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" class="btn sub2" Text="Reopen" />
            <input type="button" id="btnFloatCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
            <asp:Button ID="btnFloatReopen1" runat="server" OnClick="btnReopen_Click" Style="display: none;" class="sub2" Text="Confirm" />
            <asp:Button ID="Button11" runat="server" OnClick="btnConfirm_Click" Style="display: none;" class="btn btn-primary btn-grey  btn-width" Text="Confirm" />
            <asp:Button ID="ButtnFloatClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
            <asp:Button ID="btnFloatPrint" runat="server" class="btn sub2" Text="Print" OnClientClick="return  PrintValue(); " />






        </div>
    </div>

    <%--END--%>
    <!-------working area_closed---->


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
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au(".ddl").selectToAutocomplete1Letter();
        });

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

