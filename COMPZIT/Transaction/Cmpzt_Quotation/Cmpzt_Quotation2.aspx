<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="Cmpzt_Quotation2.aspx.cs" EnableEventValidation="false" Inherits="Transaction_Cmpzt_Quotation_Cmpzt_Quotation2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <link href="/css/New%20css/hcm_ns.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
    <script src="/js/New js/msdropdown/jquery.dd.js"></script>

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

            //history.pushState(null, null, document.URL);
            //window.addEventListener('popstate', function () {
            //    history.pushState(null, null, document.URL);
            //});
        </script>
     <script>

         var confirmbox = 0;

         function IncrmntConfrmCounter() {
             confirmbox++;
         }
         function ConfirmMessage() {
          
             if (confirmbox > 0) {

                 ezBSAlert({
                     type: "confirm",
                     messageText: "Are You Sure You Want To Leave This Page?",
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         if (document.getElementById("<%=hiddenL_MODE.ClientID%>").value != "") {
                             window.location.href = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=" + document.getElementById("<%=hiddenL_MODE.ClientID%>").value + "";
                         }
                         else {
                             window.location.href = "/Transaction/gen_Lead/gen_LeadList.aspx";
                         }
                     }
                 });
                 return false;
             }
             else {
                 if (document.getElementById("<%=hiddenL_MODE.ClientID%>").value != "") {
                     window.location.href = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=" + document.getElementById("<%=hiddenL_MODE.ClientID%>").value + "";
                 }
                 else {
                     window.location.href = "/Transaction/gen_Lead/gen_LeadList.aspx";
                 }
                 return false;
             }
         }
          //stop-0006
    </script>


    <script>
        function addCommas(nStr) {
           
          
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
                return x1;
            else
            return x1 + "." + x2;
        }
       
    </script>
    <script>

        function PreviewPDF(pageurl) {

            var Preview = window.open(pageurl, '_blank');
            Preview.focus();

        }

        function SaveFinal() {
            $("#success-alert").html("Quotation Details Successfully Made Final.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessSave() {
            $("#success-alert").html("Quotation Details Saved Successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessConfirmation() {
            $("#success-alert").html("Quotation Details Confirmed Successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessConfirmationNM() {
            $("#danger-alert").html("Quotation Details Confirmed Successfully.But Mail Sending To Team Head was Unsuccessfull.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdation() {
            $("#success-alert").html("Quotation Details Updated Successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessApprove() {
            $("#success-alert").html("Quotation Details Approved Successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessReturn() {
            $("#success-alert").html("Quotation Details Returned Successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessReOpen() {
            $("#success-alert").html("Quotation Details Re-Opened Successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessDelivery() {
            $("#success-alert").html("Quotation Details Delivered Successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function ErrorMsg() {
            $("#danger-alert").html("Some Error Occured.Please Review Entered Values !");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function NoQuotataion() {
            $("#danger-alert").html("You Do Not Have Provision To do any activities related to Quotation .Please Contact Authorised Person for Clarification.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessApproveNM() {
            $("#danger-alert").html("Quotation Details Approved . But Mail Sending was Unsuccessfull.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessApproveDeliver() {
            $("#success-alert").html("Quotation Details Approved and Delivered Successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessReMail() {
            $("#success-alert").html("Mail Send Successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function UnSuccessReMail() {
            $("#danger-alert").html("Mail Sending was Unsuccessfull.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function ErrorMsgImportFormat() {
            $("#danger-alert").html("Sorry, cannot recognize csv file format. Previous data will be loaded.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
    </script>


    <script>

        var $Mo = jQuery.noConflict();

        function OpenModal(objname, CntMain, CntSub) {

            if (CheckItemSelected(CntMain, CntSub) == true) {

                var Option= document.getElementById("<%=divPrdctStockOptions.ClientID%>").innerHTML;
                $("#cbxPrdctStock").append(Option);

                document.getElementById("pRowCount").innerHTML = CntMain + "_" + CntSub;

                document.getElementById('divErrorRsn').style.visibility = "hidden";
                document.getElementById("lblErrorRsn").innerHTML = "";

                document.getElementById("txtareaMoreInfo").value = "";

                if (document.getElementById("tdPrintSt_" + CntMain + "_" + CntSub).innerHTML != "") {
                    if (document.getElementById("tdPrintSt_" + CntMain + "_" + CntSub).innerHTML == 1) {
                        document.getElementById("ChkPrinted").checked = true;
                    }
                    else {
                        document.getElementById("ChkPrinted").checked = false;
                    }

                }
               
                if (document.getElementById("tdAdditional_" + CntMain + "_" + CntSub).innerHTML != "") {
                    document.getElementById("txtareaMoreInfo").value = document.getElementById("tdAdditional_" + CntMain + "_" + CntSub).innerHTML;

                }

                if (document.getElementById("tdPrdctAvailable_" + CntMain + "_" + CntSub).innerHTML != "") {
                    if (document.getElementById("tdPrdctAvailable_" + CntMain + "_" + CntSub).innerHTML == "0") {
                        document.getElementById("cbxPrdctStock").value = "--SELECT--";
                    }
                    else {

                        document.getElementById("cbxPrdctStock").value = document.getElementById("tdPrdctAvailable_" + CntMain + "_" + CntSub).innerHTML;
                    }
                }
                var ItemName = document.getElementById("txtItem_" + CntMain + "_" + CntSub).value;
                document.getElementById("pModal").innerHTML = "Additional Information Related to Product ( " + ItemName + " )";

                document.getElementById("txtareaMoreInfo").focus();

            }

            return false;
        }

        function LoadStockPrdct(x, y, event){

            if (event != null) {
                if (isTagEnter(event) == false) {
                    return false;
                }
            }

            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var OrgId = '<%=Session["ORGID"]%>';
 
            $noCon('#cbxPrdctStock'+ x + "_" + y).autocomplete({
                source: function (request, response) {

                    $.ajax({
                        async: false,
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        url: "Cmpzt_Quotation.aspx/LoadStockPrdct",
                        data: '{}',
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    val: item.split('<>')[0],
                                    label: item.split('<>')[1],
                                }
                            }))
                        }
                    });
                },
                autoFocus: false,

                select: function (e, i) {
                    document.getElementById("tdStockPrdctId"+ x + "_" + y).innerHTML = i.item.val;
                    document.getElementById("cbxPrdctStock"+ x + "_" + y).value = i.item.label;
                },
                change: function (event, ui) {
                    if (ui.item) {
                        document.getElementById("tdStockPrdctName"+ x + "_" + y).innerHTML = document.getElementById("cbxPrdctStock"+ x + "_" + y).value;
                    }
                    else {
                        document.getElementById("cbxPrdctStock"+ x + "_" + y).value = document.getElementById("tdStockPrdctName"+ x + "_" + y).innerHTML;
                    }
                }
            });
        }

        function CloseModal() {

            document.getElementById("myModal").style.display = "none";
            return false;
        }
        function SaveAdditional() {

            var ret=true;
            if (document.getElementById("pRowCount").innerHTML != "") {
                var x = document.getElementById("pRowCount").innerHTML;

                var AddntnlInformtnWithoutReplace = document.getElementById("txtareaMoreInfo"+x).value;

                var replaceText1 = AddntnlInformtnWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                var replaceText3 = replaceText2.replace(/'/g, "");
                var replaceText4 = replaceText3.replace(/"/g, "");
                var replaceText5 = replaceText4.replace(/\\/g, "");
                document.getElementById("txtareaMoreInfo"+x).value = replaceText5.trim();

                var print = 0;
                if (document.getElementById("ChkPrinted"+x).checked == true) {
                    print = 1;
                }

                var ddlPrdctSts = document.getElementById("tdStockPrdctId"+x).value;
                if (ddlPrdctSts == "--SELECT--") {
                    ddlPrdctSts = 0;
                }

                if(document.getElementById("txtareaMoreInfo"+x).value==""){
                    document.getElementById("txtareaMoreInfo"+x).style.borderColor="red";
                    document.getElementById("txtareaMoreInfo"+x).focus();
                    ret= false;
                }

                if(document.getElementById("cbxPrdctStock"+x).value==""){
                    document.getElementById("cbxPrdctStock"+x).style.borderColor="red";
                    document.getElementById("cbxPrdctStock"+x).focus();
                    ret= false;
                }

                if(ret==true){
                    document.getElementById("tdPrintSt_" + x).innerHTML = print;
                    document.getElementById("tdPrdctAvailable_" + x).innerHTML = ddlPrdctSts;
                    document.getElementById("tdPrdctName_" + x).innerHTML = document.getElementById("cbxPrdctStock" + x).value;
                    document.getElementById("tdAdditional_" + x).innerHTML = document.getElementById("txtareaMoreInfo"+x).value;
                    document.getElementById("imgMoreInfo_" + x).focus();
                    $(".popover").css("display","none");
                }
            }

            return false;
        }

    </script>

    <%--Maintable--%>
    <script type="text/javascript">
      
        var $noCon = jQuery.noConflict();

// not to be taken for other form  other thsn this table creation
function isNumber(objSource, objDestntn, evt) {
    // KEYCODE FOR. AND DELETE IS SAME IN KEY PRESS DIFFERENT IN KEY DOWN AND UP
    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
    var charCode = (evt.which) ? evt.which : evt.keyCode;

    var ObjVal = document.getElementById(objSource).value;
    if (keyCodes == 13) {
        document.getElementById(objDestntn).focus();
        if (objDestntn != "cphMain_btnSave") {
            $noCon("#" + objDestntn).select();
        }
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



        var count = ObjVal.split('.').length - 1;

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
// not to be taken for other form  other thsn this table creation
function isNumberValidity(objSource, evt) {
    // KEYCODE FOR. AND DELETE IS SAME IN KEY PRESS DIFFERENT IN KEY DOWN AND UP
    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
 
    var ObjVal = document.getElementById(objSource).value;
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

function isEnter(obj, x, evt) {

    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (keyCodes == 13) {


       
        return false;

    }

}

function ClearStorage() {
    // "use strict";
    localStorage.clear();
    //return false;
}



function ReturnConfirm() {

    var ret = true;
    if (CheckIsRepeat() == true) {
    }
    else {
        ret = false;
        return ret;
    }

    if(ret==true){
        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to Return this Quotation without Approval?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {
                document.getElementById("<%=btnReturnClick.ClientID%>").click();
            }
        });
    }
    CheckSubmitZero();
    return false;
}

        function ReOpenConfirm() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            if(ret==true){
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to Re-Open this Quotation?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        OpenModalReopenReason();
                    }
                });
            }
            CheckSubmitZero();
            return false;
        }

        function ReturnReSendMail() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
               
            }
            if (ret == true) {
                ShowLoadingGif();
            }
            return ret;
            
        }


        $noCon(window).load(function () {
          
            $noCon('#cphMain_ddlPriceTerm').selectToAutocomplete1Letter();
            $noCon('#cphMain_ddlManufacturerTerm').selectToAutocomplete1Letter();
            $noCon('#cphMain_ddlPymntTerm').selectToAutocomplete1Letter();
            $noCon('#cphMain_ddlDlvryTerm').selectToAutocomplete1Letter();
            $noCon('#cphMain_ddlWrntyTerm').selectToAutocomplete1Letter();
            $noCon('#cphMain_ddlcustomername').selectToAutocomplete1Letter();
         
            document.getElementById("<%=HiddenField1.ClientID%>").value = "";

            localStorage.clear();

            //var ImportVal = document.getElementById("<%=hiddenCSVvalues.ClientID%>").value;
            var ImportVal = '<%= Session["CSV_VAL"] %>';

            var Copiedval = document.getElementById("<%=HiddenCopiedval.ClientID%>").value;
            var Oldval = document.getElementById("<%=HiddenDonotclear.ClientID%>").value;
            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
            var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;
          
            var DetailGrpEditCopy = document.getElementById("<%=hiddenEditdetailgroupDataCopied.ClientID%>").value;
            var DetailGrdpEdit = document.getElementById("<%=hiddenEditdetailgroupData.ClientID%>").value;
        
           
            if (DetailGrpEditCopy != "" && DetailGrpEditCopy != "[]") {
                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = DetailGrpEditCopy.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');

                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].BRID != "") {

                            AddMoreMainTemplate('COPY', json[key].BRID, json[key].BRNAME, json[key].BRGRSAMNT, json[key].DISCMOD, json[key].DISCVAL, json[key].DISCAMNT, json[key].NETAMNT);
                        }
                    }
                }
            }

            else if (DetailGrdpEdit != "" && DetailGrdpEdit != "[]") {
                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = DetailGrdpEdit.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');

                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].BRID != "") {

                            AddMoreMainTemplate('UPD', json[key].BRID, json[key].BRNAME, json[key].BRGRSAMNT, json[key].DISCMOD, json[key].DISCVAL, json[key].DISCAMNT, json[key].NETAMNT);
                        }
                    }
                }

            } else { AddMoreMainTemplate('INS', '0', '0', '0', '0', '0', '0', '0'); }


            if (ImportVal != "") {


                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    $('#TableProductWithTaxBody_1 tr').remove();
                }
                else {
                    $('#TableProductWithoutTaxBody_1 tr').remove();
                }
                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = ImportVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');

                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].TransId != "") {
                            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                                document.getElementById('TableProductWithoutTaxHead_' + 1).style.display = "none";
                                document.getElementById('TableFooterWithoutTax_' + 1).style.display = "none";

                                AddMoreProductRowWithTax(1, 0, "INS", json[key].ProductName, json[key].UnitName, json[key].Quantity, json[key].CostPrice, json[key].Margin, json[key].SellingPrice, json[key].TaxPer, "0", "0", "0", json[key].AddDesc, "0", "0", "0", "0", "FALSE", "CSV","0" ,json[key].StockName);

                                if (json[key].ProductNameAbNormal == 1) {
                                    document.getElementById("txtItem_" + 1 + "_" + SubTempCount).style.backgroundColor = "rgb(195, 255, 0)";
                                    document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value = "ImportErrors";
                                }
                                if (json[key].UnitNameAbNormal == 1) {
                                    document.getElementById("txtUnit_" + 1 + "_" + SubTempCount).style.backgroundColor = "rgb(195, 255, 0)";
                                    document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value = "ImportErrors";
                                }
                                if (json[key].QuantityAbNormal == 1) {
                                    document.getElementById("txtQuantity_" + 1 + "_" + SubTempCount).style.backgroundColor = "rgb(195, 255, 0)";
                                    document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value = "ImportErrors";
                                }

                                if (json[key].CostPriceAbNormal == 1) {
                                    document.getElementById("txtCprice_" + 1 + "_" + SubTempCount).style.backgroundColor = "rgb(195, 255, 0)";
                                    document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value = "ImportErrors";
                                }
                                if (json[key].SellingPriceAbNormal == 1) {
                                    document.getElementById("txtRate_" + 1 + "_" + SubTempCount).style.backgroundColor = "rgb(195, 255, 0)";
                                    document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value = "ImportErrors";
                                }
                                if (json[key].TaxPerAbNormal == 1) {
                                    document.getElementById("txtTaxPerc_" + 1 + "_" + SubTempCount).style.backgroundColor = "rgb(195, 255, 0)";
                                    document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value = "ImportErrors";
                                }

                            
                                if (json[key].CostPriceAbNormal == 0 && json[key].MarginAbNormal == 0) {
                                    CalculateCheckingRate(1, SubTempCount);
                                }

                                CalculateRowTotalDefault(1, SubTempCount);
                              

                                //if (document.getElementById("txtRate_" + 1 + "_" + SubTempCount).value == 0) {
                                //    document.getElementById("txtRate_" + 1 + "_" + SubTempCount).value = 1;

                                //    ValueCheck('txtRate_', 1, SubTempCount);

                                //}
                            }
                            else {

                                AddMoreProductRow(1, 0, "INS", json[key].ProductName, json[key].UnitName, json[key].Quantity, json[key].CostPrice, json[key].Margin, json[key].SellingPrice, "0", "0", json[key].AddDesc, "0", "0", "0", "0", "FALSE", "CSV","0" ,json[key].StockName);
                                if (json[key].ProductNameAbNormal == 1) {
                                    document.getElementById("txtItem_" + 1 + "_" + SubTempCount).style.backgroundColor = "rgb(195, 255, 0)";
                                    document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value = "ImportErrors";
                                }
                                if (json[key].UnitNameAbNormal == 1) {
                                    document.getElementById("txtUnit_" + 1 + "_" + SubTempCount).style.backgroundColor = "rgb(195, 255, 0)";
                                    document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value = "ImportErrors";
                                }
                                if (json[key].QuantityAbNormal == 1) {
                                    document.getElementById("txtQuantity_" + 1 + "_" + SubTempCount).style.backgroundColor = "rgb(195, 255, 0)";
                                    document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value = "ImportErrors";
                                }

                                if (json[key].CostPriceAbNormal == 1) {
                                    document.getElementById("txtCprice_" + 1 + "_" + SubTempCount).style.backgroundColor = "rgb(195, 255, 0)";
                                    document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value = "ImportErrors";
                                }
                                if (json[key].SellingPriceAbNormal == 1) {
                                    document.getElementById("txtRate_" + 1 + "_" + SubTempCount).style.backgroundColor = "rgb(195, 255, 0)";
                                    document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value = "ImportErrors";
                                }
                                if (json[key].CostPriceAbNormal == 0 && json[key].MarginAbNormal == 0) {
                                    CalculateCheckingRate(1, SubTempCount);
                                }

                                CalculateRowTotalDefault(1, SubTempCount);

                                //if (document.getElementById("txtRate_" + 1 + "_" + SubTempCount).value == 0) {
                                //    document.getElementById("txtRate_" + 1 + "_" + SubTempCount).value = 1;
                                //    ValueCheck('txtRate_', 1, SubTempCount);
                                //}
                            }

                        }
                    }
                }
                CalculateTotalAmountFromHiddenField(1);
                ReNumberTable(1);
                AddButtonVisible(1);
                document.getElementById("<%=btnImportCsv.ClientID%>").focus();

                $noCon('html, body').animate({ scrollTop: 700 }, 1000);

            }
            else if (ViewVal != "") {

                var QtnTmpltId = document.getElementById("<%=hiddenQtnTemplateId.ClientID%>").value;

                if (QtnTmpltId.toString() == '2') {
                    document.getElementById("<%=fupImportCsv.ClientID%>").disabled = true;
                    document.getElementById("<%=btnImportCsv.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxImprtHasHeader.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxSkpRowWithouItmNm.ClientID%>").disabled = true;
                }

                document.getElementById("<%=ddlPriceTerm.ClientID%>").disabled = true;
                $("div#divPriceTerm input.ui-autocomplete-input").attr("disabled", "disabled");
                document.getElementById("<%=ddlManufacturerTerm.ClientID%>").disabled = true;
                $("div#divManufacturerTerms input.ui-autocomplete-input").attr("disabled", "disabled");
                document.getElementById("<%=ddlPymntTerm.ClientID%>").disabled = true;
                $("div#divPymntTerm input.ui-autocomplete-input").attr("disabled", "disabled");
                document.getElementById("<%=ddlDlvryTerm.ClientID%>").disabled = true;
                $("div#divDlvryTerm input.ui-autocomplete-input").attr("disabled", "disabled");
                document.getElementById("<%=ddlWrntyTerm.ClientID%>").disabled = true;
                $("div#divWrntyTerm input.ui-autocomplete-input").attr("disabled", "disabled");

                document.getElementById("<%=ddlCurrency.ClientID%>").disabled = true;
                $("div#divCurrncy input.ui-autocomplete-input").attr("disabled", "disabled");

                document.getElementById("<%=txtPriceTerm.ClientID%>").disabled = true;
                document.getElementById("<%=txtPymntTerm.ClientID%>").disabled = true;
                document.getElementById("<%=txtWrntyTerm.ClientID%>").disabled = true;
                document.getElementById("<%=txtDlvryTerm.ClientID%>").disabled = true;
                document.getElementById("<%=txtValidityTerm.ClientID%>").disabled = true;
                document.getElementById("<%=txtComments.ClientID%>").disabled = true;
                document.getElementById("<%=cbxSendMail.ClientID%>").disabled = true;
                document.getElementById('btnAddmailSave').style.display = "none"; 
                if ($('#cphMain_lblEditMailWindow').length) {
                    $("#divToAddressContent :input").prop("disabled", true);
                    document.getElementById('cphMain_lblEditMailWindow').innerText = "Click to view address";
                }
            }
            else if (EditVal != "" && EditVal != "[]")
            {
            }
            else
            {
          
                document.getElementById("<%=ddlPriceTerm.ClientID%>").focus();
                var num = 0;
                var n = 0;
                // for floatting number adjustment from corp global
                var FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                if (FloatingValue != "") {
                    var n = num.toFixed(FloatingValue);
                }
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    document.getElementById('tdFooterTotalCPriceWithTax_1').innerText = n;
                    document.getElementById('tdFooterTotalSPriceWithTax_1').innerText = n;
                    document.getElementById('tdFooterTotalMarginWithTax_1').innerText = n;
                    document.getElementById('tdFooterTotalDiscAmntWithTax_1').innerText = n;
                    document.getElementById('tdFooterTotalAmountWithTax_1').innerText = n;
                    document.getElementById('tdFooterTotalTaxAmntWithTax_1').innerText = n;

                }
                else {
                    document.getElementById('tdFooterTotalCPriceWithoutTax_1').innerText = n;
                    document.getElementById('tdFooterTotalSPriceWithoutTax_1').innerText = n;
                    document.getElementById('tdFooterTotalMarginWithoutTax_1').innerText = n;
                    document.getElementById('tdFooterTotalDiscAmntWithoutTax_1').innerText = n;
                    document.getElementById('tdFooterTotalAmountWithoutTax_1').innerText = n;

                }

            }
            //end old

            if (document.getElementById("<%=hiddenImportError.ClientID%>").value == "error") {
                  document.getElementById('divErrorNotification_1').style.visibility = "visible";
                  document.getElementById('lblErrorNotification_1').innerHTML = "Sorry, cannot recognize csv file format. Previous data will be loaded.";

                document.getElementById("<%=hiddenImportError.ClientID%>").value = "";
                document.getElementById("<%=btnImportCsv.ClientID%>").focus();

                $noCon('html, body').animate({ scrollTop: 700 }, 1000);
              }

           
            document.getElementById("<%=ddlPriceTerm.ClientID%>").focus();
            $("div#divPriceTerm input.ui-autocomplete-input").select();
        });
    </script>


    <script>

        // for not allowing <> tags
        function isTag(obj, evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                if (obj == "cphMain_txtComments" || obj == "cphMain_txtPriceTerm" || obj == "cphMain_txtPymntTerm" || obj == "cphMain_txtDlvryTerm" || obj == "cphMain_txtValidityTerm" || obj == "cphMain_txtReopenReasonDescptn" || obj == "cphMain_txtManufacturerTerm") {

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
        function isTagName(Dstnobj, event) {
            //for item name and unit name
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 13) {
                document.getElementById(Dstnobj).focus();
                return false;
            }
            else if (keyCode == 39) {
                //single quote also right arrow when key press
                //  return false;
            }
            else if (keyCode == 34) {//double quotes
                return false;
            }
            else if (keyCode == 92) {
                // \ back slash
                return false;
            }
            else if (keyCode == 60 || keyCode == 62) {
                //< and >
                return false;
            }
        }
        function isTagQuotesBackSlash(obj, event) {

            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;

            if (keyCode == 39) {
                //single quote also right arrow when key press
                //  return false;
            }
            else if (keyCode == 34) {//double quotes
                return false;
            }
            else if (keyCode == 92) {
                // \ back slash
                return false;
            }
            else if (keyCode == 60 || keyCode == 62) {
                //< and >
                return false;
            }
        }

        // for replacing <> tags
        function ReplaceTag(obj, evt) {

            // replacing < and > tags
            var WithoutReplace = document.getElementById(obj).value;

            var replaceText1 = WithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2.trim();


        }
        function ReplaceTagAlphabetValidity(obj, evt) {

            // replacing < and > tags
            var WithoutReplace = document.getElementById(obj).value;

            var replaceText1 = WithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var QuoteValidity = document.getElementById(obj).value = replaceText2.trim();
            if (isNaN(QuoteValidity)) {
                document.getElementById(obj).value = '';
            }
            return false;
        }




        //<!-- Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TXTBOX
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


        //  End -->>
        function ShowHidden() {
            var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
           
            var MainCancDtlld = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value
       
            return false;
        }


    </script>
    <script>
        function ChangePriceTerm() {
            var $noCT = jQuery.noConflict();
            var PreviousVal = document.getElementById("<%=hiddenPreviousPriceTerm.ClientID%>").value;


            var txt_Term = document.getElementById("<%=txtPriceTerm.ClientID%>").value
            var DropdownPriceTerm = document.getElementById("<%=ddlPriceTerm.ClientID%>");
            var SelectedValuePriceTerm = DropdownPriceTerm.value;
           
            if (SelectedValuePriceTerm != PreviousVal) {
                if (SelectedValuePriceTerm == '--SELECT PRICE TERMS--') {

                    SelectedValuePriceTerm = 0;
                }
                if (SelectedValuePriceTerm != 0) {
                    if (txt_Term != '') {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you Sure you want to Change Price Terms?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                IncrmntConfrmCounter();
                                TermSelected(SelectedValuePriceTerm, 'cphMain_txtPriceTerm');
                                document.getElementById("<%=txtPriceTerm.ClientID%>").focus();
                            }
                            else{
                                document.getElementById("<%=ddlPriceTerm.ClientID%>").value = PreviousVal;

                                var a = $noC("#cphMain_ddlPriceTerm option:selected").text();
                                $noCT("div#divPriceTerm input.ui-autocomplete-input").val(a);

                                document.getElementById("<%=txtPriceTerm.ClientID%>").focus();
                            }
                        });
                        return false;
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
            else {

                return false;
            }
        }

        function ChangeManufacturerTerm() {
            var $noCT = jQuery.noConflict();
            var PreviousVal = document.getElementById("<%=hiddenPreviousManufacturerTerm.ClientID%>").value;


            var txt_Term = document.getElementById("<%=txtManufacturerTerm.ClientID%>").value
            var DropdownManufacturerTerm = document.getElementById("<%=ddlManufacturerTerm.ClientID%>");
            var SelectedValueManufacturerTerm = DropdownManufacturerTerm.value;

            
            if (SelectedValueManufacturerTerm != PreviousVal) {

                if (SelectedValueManufacturerTerm == '--SELECT MANUFACTURER TERMS--') {

                    SelectedValueManufacturerTerm = 0;
                }

                if (SelectedValueManufacturerTerm != 0) {
                    if (txt_Term != '') {

                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you sure you want to change manufacturer terms?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                IncrmntConfrmCounter();
                                TermSelected(SelectedValueManufacturerTerm, 'cphMain_txtManufacturerTerm');
                                document.getElementById("<%=txtManufacturerTerm.ClientID%>").focus();
                            }
                            else{
                                document.getElementById("<%=ddlManufacturerTerm.ClientID%>").value = PreviousVal;

                                var a = $noC("#cphMain_ddlManufacturerTerm option:selected").text();
                                $noCT("div#divManufacturerTerms input.ui-autocomplete-input").val(a);

                                document.getElementById("<%=txtManufacturerTerm.ClientID%>").focus();
                            }
                        });
                        return false;
                    }
                    else {
                        IncrmntConfrmCounter();
                        TermSelected(SelectedValueManufacturerTerm, 'cphMain_txtManufacturerTerm');
                        document.getElementById("<%=txtManufacturerTerm.ClientID%>").focus();

                    }
                }
                else {
                    document.getElementById("<%=txtManufacturerTerm.ClientID%>").focus();
                    return false;
                }
            }
            else {

                return false;
            }
        }

        function ChangePaymentTerm() {
            var $noCT = jQuery.noConflict();
            var PreviousVal = document.getElementById("<%=hiddenPreviousPaymentTerm.ClientID%>").value;
            var txt_Term = document.getElementById("<%=txtPymntTerm.ClientID%>").value

            var DropdownPaymentTerm = document.getElementById("<%=ddlPymntTerm.ClientID%>");
            var SelectedValuePaymentTerm = DropdownPaymentTerm.value;

            if (SelectedValuePaymentTerm != PreviousVal) {
                if (SelectedValuePaymentTerm == '--SELECT PAYMENT TERMS--') {
                    SelectedValuePaymentTerm = 0;

                }

                if (SelectedValuePaymentTerm != 0) {
                    if (txt_Term != '') {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you Sure you want to Change Payment Terms?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                IncrmntConfrmCounter();
                                TermSelected(SelectedValuePaymentTerm, 'cphMain_txtPymntTerm');
                                document.getElementById("<%=txtPymntTerm.ClientID%>").focus();
                            }
                            else{
                                document.getElementById("<%=ddlPymntTerm.ClientID%>").value = PreviousVal;

                                var a = $noC("#cphMain_ddlPymntTerm option:selected").text();
                                $noCT("div#divPymntTerm input.ui-autocomplete-input").val(a);

                                document.getElementById("<%=txtPymntTerm.ClientID%>").focus();
                            }
                        });
                        return false;
                    }
                    else {
                        IncrmntConfrmCounter();
                        TermSelected(SelectedValuePaymentTerm, 'cphMain_txtPymntTerm');
                        document.getElementById("<%=txtPymntTerm.ClientID%>").focus();
                    }
                }
                else {
                    document.getElementById("<%=txtPymntTerm.ClientID%>").focus();
                    return false;
                }
            }
            else {

                return false;
            }
        }
        function ChangeDeliveryTerm() {
            var $noCT = jQuery.noConflict();
            var PreviousVal = document.getElementById("<%=hiddenPreviousDeliveryTerm.ClientID%>").value;

            var txt_Term = document.getElementById("<%=txtDlvryTerm.ClientID%>").value
            var DropdownDeliveryTerm = document.getElementById("<%=ddlDlvryTerm.ClientID%>");
            var SelectedValueDeliveryTerm = DropdownDeliveryTerm.value;
        
            if (SelectedValueDeliveryTerm != PreviousVal) {
                if (SelectedValueDeliveryTerm == '--SELECT DELIVERY TERMS--') {
                    SelectedValueDeliveryTerm = 0;

                }

                if (SelectedValueDeliveryTerm != 0) {
                    if (txt_Term != '') {

                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you Sure you want to Change Delivery Terms?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                IncrmntConfrmCounter();
                                TermSelected(SelectedValueDeliveryTerm, 'cphMain_txtDlvryTerm');
                                document.getElementById("<%=txtDlvryTerm.ClientID%>").focus();
                            }
                            else{
                                document.getElementById("<%=ddlDlvryTerm.ClientID%>").value = PreviousVal;

                                var a = $noC("#cphMain_ddlDlvryTerm option:selected").text();
                                $noCT("div#divDlvryTerm input.ui-autocomplete-input").val(a);

                                document.getElementById("<%=txtDlvryTerm.ClientID%>").focus();
                            }
                        });
                        return false;
 
                    }
                    else {
                        IncrmntConfrmCounter();
                        TermSelected(SelectedValueDeliveryTerm, 'cphMain_txtDlvryTerm');
                        document.getElementById("<%=txtDlvryTerm.ClientID%>").focus();

                    }
                }
                else {
                    document.getElementById("<%=txtDlvryTerm.ClientID%>").focus();
                    return false;
                }
            }
            else {

                return false;
            }
        }

        function ChangeWarrantyTerm() {
            var $noCT = jQuery.noConflict();
            var PreviousVal = document.getElementById("<%=hiddenPreviousWarrantyTerm.ClientID%>").value;

            var txt_Term = document.getElementById("<%=txtWrntyTerm.ClientID%>").value
            var DropdownWarrantyTerm = document.getElementById("<%=ddlWrntyTerm.ClientID%>");
            var SelectedValueWarrantyTerm = DropdownWarrantyTerm.value;

            if (SelectedValueWarrantyTerm != PreviousVal) {
                if (SelectedValueWarrantyTerm == '--SELECT WARRANTY TERMS--') {
                    SelectedValueWarrantyTerm = 0;

                }
                if (SelectedValueWarrantyTerm != 0) {
                    if (txt_Term != '') {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you Sure you want to Change Warranty Terms?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                IncrmntConfrmCounter();
                                TermSelected(SelectedValueWarrantyTerm, 'cphMain_txtWrntyTerm');
                                document.getElementById("<%=txtWrntyTerm.ClientID%>").focus();
                            }
                            else{
                                document.getElementById("<%=ddlWrntyTerm.ClientID%>").value = PreviousVal;

                                var a = $noC("#cphMain_ddlWrntyTerm option:selected").text();
                                $noCT("div#divWrntyTerm input.ui-autocomplete-input").val(a);

                                document.getElementById("<%=txtWrntyTerm.ClientID%>").focus();
                            }
                        });
                        return false;
                    }
                    else {
                        IncrmntConfrmCounter();
                        TermSelected(SelectedValueWarrantyTerm, 'cphMain_txtWrntyTerm');
                        document.getElementById("<%=txtWrntyTerm.ClientID%>").focus();

                    }
                }
                else {
                    document.getElementById("<%=txtWrntyTerm.ClientID%>").focus();
                    return false;
                }
            }
            else {

                return false;
            }
        }


        

        function getPreviousDDLPayment_SelectedVal() {
            var DropdownList = document.getElementById('<%=ddlPymntTerm.ClientID %>');
            var SelectedValue = DropdownList.value;
            document.getElementById("<%=hiddenPreviousPaymentTerm.ClientID%>").value = SelectedValue;

        }
        function getPreviousDDLPrice_SelectedVal() {
            var DropdownList = document.getElementById('<%=ddlPriceTerm.ClientID %>');
            var SelectedValue = DropdownList.value;
            document.getElementById("<%=hiddenPreviousPriceTerm.ClientID%>").value = SelectedValue;
        }
        function getPreviousDDLManufacturer_SelectedVal() {
            var DropdownList = document.getElementById('<%=ddlManufacturerTerm.ClientID %>');
                    var SelectedValue = DropdownList.value;
                    document.getElementById("<%=hiddenPreviousManufacturerTerm.ClientID%>").value = SelectedValue;
        }
        function getPreviousDDLDelivery_SelectedVal() {
            var DropdownList = document.getElementById('<%=ddlDlvryTerm.ClientID %>');
            var SelectedValue = DropdownList.value;
            document.getElementById("<%=hiddenPreviousDeliveryTerm.ClientID%>").value = SelectedValue;

        }
        function getPreviousDDLWarranty_SelectedVal() {
            var DropdownList = document.getElementById('<%=ddlWrntyTerm.ClientID %>');
            var SelectedValue = DropdownList.value;
            document.getElementById("<%=hiddenPreviousWarrantyTerm.ClientID%>").value = SelectedValue;

        }
        
    </script>
    <script>


        function TermSelected(T_Id, objId) {

            //web method for drop down of narrations for common narration
            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;

            if (CorpId != '' && CorpId != null && OrgId != '' && OrgId != null && T_Id != '' && T_Id != null && (!isNaN(T_Id))) {
    
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "Cmpzt_Quotation2.aspx/TermDetails",
                    data: '{corporateId: "' + CorpId + '",organisationId:"' + OrgId + '" ,TermId:"' + T_Id + '"}',
                    dataType: "json",
                    success: function (data) {

                        if (data.d != '') {

                            document.getElementById(objId).value = data.d.strTermDescription;



                        }
                    },
                    error: function (result) {
              
                    }
                });

            }
        }

        function FileImportValidate() {
            var ret = true;

            var fileUploader = document.getElementById("<%=fupImportCsv.ClientID%>").value;
            var Extension = fileUploader.substring(fileUploader.lastIndexOf('.') + 1).toLowerCase();
            document.getElementById('divErrorNotification_1').style.visibility = "hidden";
            document.getElementById('lblErrorNotification_1').innerHTML = "";
            document.getElementById("<%=fupImportCsv.ClientID%>").style.borderColor = "";

            if (fileUploader == "") {
                $("#danger-alert").html("Please Choose a .csv File for Uploading");
                $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=fupImportCsv.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=fupImportCsv.ClientID%>").focus();
                ret = false;
            }
            else {

                if (Extension == "csv") {
                    ret = true;
                }
                else {
                    $("#danger-alert").html("Sorry, The specified file could not be uploaded. You can choose .csv files for uploading.");
                    $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=fupImportCsv.ClientID%>").focus();
                    ret = false;
                }
            }
            if (ret == true)
            {
                var MainTable = $('#tableTotalProductContainer > tbody > tr');

                var countRow=0;
                $(MainTable).each(function () {

                    var RowIdMain = $(this).attr('id');
                    var SplitIdMain = RowIdMain.split('_');
                    var RowIdMainName = SplitIdMain[0];
                    var CntMain = SplitIdMain[1];
                    if (RowIdMainName == "TemplateRowId") {
                        var subTable = "";

                        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                            subTable = $('#TableProductWithTaxBody_' + CntMain + ' tr.ClassBody');
                        }
                        else {

                            subTable = $('#TableProductWithoutTaxBody_' + CntMain + ' tr.ClassBody');
                        }
                        $(subTable).each(function () {
                            countRow++;
                        });
                    }
                });

                if (countRow>1) {
                    if (confirm("All data Inserted would be cleared.Are you sure you want to Import New data?")) {
                        ret = true;
                    }
                    else {
                        ret = false;
                    }
                }
            }

            if (ret == true)
            {
                ShowLoadingGif();
                document.getElementById("<%=btnImportCsv.ClientID%>").click();
            }
            return ret;
        }
        function ShowLoadingGif() {
            document.getElementById("myModalLoadingMail").style.display = "block";
        }
        function HideLoadingGif() {
            document.getElementById("myModalLoadingMail").style.display = "none";
        }
        function NoDfltCurrency(strRandomMixedId, strL_MODE, strPrev) {
            if (strPrev == '') {
                if (strRandomMixedId == '') {
                    alert('Sorry Please Define a Default Currency for Your Corporate Office !');
                    window.location = '/Transaction/gen_Lead/gen_LeadList.aspx';
                }
                else {
                    if (strL_MODE == '') {

                        alert('Sorry Please Define a Default Currency for Your Corporate Office !');
                        window.location = '/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=' + strRandomMixedId + '';
                    }
                    else {
                        alert('Sorry Please Define a Default Currency for Your Corporate Office !');
                        window.location = '/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=' + strRandomMixedId + '&L_MODE=' + strL_MODE + '';


                    }

                }
            }
            else {

                if (strPrev == 'List') {


                    if (strL_MODE == '') {

                        alert('Sorry Please Define a Default Currency for Your Corporate Office !');
                        window.location = '/Transaction/gen_Lead/gen_LeadList.aspx';
                    }
                    else {
                        alert('Sorry Please Define a Default Currency for Your Corporate Office !');
                        window.location = '/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=' + strL_MODE + '';


                    }



                }
                else {
                    if (strRandomMixedId == '') {
                        alert('Sorry Please Define a Default Currency for Your Corporate Office !');
                        window.location = '/Transaction/gen_Lead/gen_LeadList.aspx';
                    }
                    else {
                        if (strL_MODE == '') {

                            alert('Sorry Please Define a Default Currency for Your Corporate Office !');
                            window.location = '/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=' + strRandomMixedId + '';
                        }
                        else {
                            alert('Sorry Please Define a Default Currency for Your Corporate Office !');
                            window.location = '/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=' + strRandomMixedId + '&L_MODE=' + strL_MODE + '';


                        }

                    }

                }

            }
        }
        //005
        function NotCorrectRefFormat(strRandomMixedId, strL_MODE, strPrev) {
            if (strPrev == '') {
                if (strRandomMixedId == '') {
                    alert('Sorry Please Define The Reference Number Format Correctly !');
                    window.location = '/Transaction/gen_Lead/gen_LeadList.aspx';
                }
                else {
                    if (strL_MODE == '') {

                        alert('Sorry Please Define The Reference Number Format Correctly !');
                        window.location = '/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=' + strRandomMixedId + '';
                    }
                    else {
                        alert('Sorry Please Define The Reference Number Format Correctly !');
                        window.location = '/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=' + strRandomMixedId + '&L_MODE=' + strL_MODE + '';


                    }

                }
            }
            else {

                if (strPrev == 'List') {


                    if (strL_MODE == '') {

                        alert('Sorry Please Define The Reference Number Format Correctly !');
                        window.location = '/Transaction/gen_Lead/gen_LeadList.aspx';
                    }
                    else {
                        alert('Sorry Please Define The Reference Number Format Correctly!');
                        window.location = '/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=' + strL_MODE + '';


                    }



                }
                else {
                    if (strRandomMixedId == '') {
                        alert('Sorry Please Define The Reference Number Format Correctly!');
                        window.location = '/Transaction/gen_Lead/gen_LeadList.aspx';
                    }
                    else {
                        if (strL_MODE == '') {

                            alert('Sorry Please Define The Reference Number Format Correctly!');
                            window.location = '/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=' + strRandomMixedId + '';
                        }
                        else {
                            alert('Sorry Please Define The Reference Number Format Correctly!');
                            window.location = '/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=' + strRandomMixedId + '&L_MODE=' + strL_MODE + '';


                        }

                    }

                }

            }
        }
    </script>

      <%-----------------------------------------------------FOR ReopenReason------------------------------------------------------------------%>



    <script>

        var $Mo = jQuery.noConflict();

        function OpenModalReopenReason() {


            var OptionsRsn = document.getElementById("<%=divOptionsReopenReason.ClientID%>").innerHTML;

             var DfltOptnRsn = '<option value="--SELECT REASON--">--SELECT REASON--</option>';
             var TotalOptnRsn = "";
             if (OptionsRsn == "") {
                 TotalOptnRsn = DfltOptnRsn;
             }
             else {
                 TotalOptnRsn = DfltOptnRsn + OptionsRsn;
             }

             var ReopenReasonHtml = ' <select id="ddlReopenReason" class="form-control fg2_inp1 inp_mst" > ';
             ReopenReasonHtml += TotalOptnRsn;
             ReopenReasonHtml += ' </select>';

             document.getElementById('SpanddlReopenReason').innerHTML = ReopenReasonHtml;

             document.getElementById('divErrorRsnReopenReason').style.visibility = "hidden";
             document.getElementById("<%=lblErrorRsnReopenReason.ClientID%>").innerHTML = "";
            document.getElementById("ddlReopenReason").style.borderColor = "";
            document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").style.borderColor = "";

            document.getElementById("ddlReopenReason").disabled = false;

            $('#myModalReopenReason').modal('show');

            var desiredValueRsn = "--SELECT REASON--";
            var elRsn = document.getElementById("ddlReopenReason");
            for (var i = 0; i < elRsn.options.length; i++) {
                if (elRsn.options[i].value == desiredValueRsn) {
                    elRsn.selectedIndex = i;
                    break;
                }
            }

            document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value = "";
            document.getElementById("ddlReopenReason").focus();
            return false;
        }

        function CloseModalReopenReason() {
 
            ezBSAlert({
                type: "confirm",
                messageText: "Are you Sure you want to Close?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value = "";
                    document.getElementById('divErrorNotification_1').style.visibility = "hidden";
                    document.getElementById('lblErrorNotification_1').innerHTML = "";
                    $('#myModalReopenReason').modal('hide');
                }
            });
            return false;
        }

        function CheckReopenReason() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            document.getElementById("<%=hiddenReopenReasonId.ClientID%>").value = "";
            // replacing < and > tags

            var RdescWithoutReplace = document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value;
            var RdescreplaceText1 = RdescWithoutReplace.replace(/</g, "");
            var RdescreplaceText2 = RdescreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value = RdescreplaceText2;

            document.getElementById("ddlReopenReason").style.borderColor = "";
            document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").style.borderColor = "";

            var DropdownListRsn = document.getElementById("ddlReopenReason");
            var SelectedValueRsn = DropdownListRsn.value;
            document.getElementById("<%=hiddenReopenReasonId.ClientID%>").value = SelectedValueRsn;
            var HiddenRsn = document.getElementById("<%=hiddenReopenReasonId.ClientID%>").value
            var RDescptn = document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value;

            document.getElementById('divErrorRsnReopenReason').style.visibility = "hidden";
            document.getElementById("<%=lblErrorRsnReopenReason.ClientID%>").innerHTML = "";

            if (SelectedValueRsn == "--SELECT REASON--" || HiddenRsn == "--SELECT REASON--" || HiddenRsn == "") {

                document.getElementById('divErrorRsnReopenReason').style.visibility = "visible";
                document.getElementById("<%=lblErrorRsnReopenReason.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                if (SelectedValueRsn == "--SELECT REASON--") {
                    document.getElementById("ddlReopenReason").focus();
                    document.getElementById("ddlReopenReason").style.borderColor = "Red";
                    ret = false;
                }


            }

            if (ret == true) {
                $('#myModalReopenReason').modal('hide');

            }
            if (ret == false) {
                CheckSubmitZero();

            }

            return ret;
        }




    </script>

     <script>



         var $MRD = jQuery.noConflict();
         function DisplayReturnDescription(objId) {

             if (document.getElementById("<%=divReopenDescription.ClientID%>").style.display == "none") {


                 var offset = $MRD("#" + objId).offset();
                 var posY = 0;
                 var posX = 0;
                 posY = offset.top + 25;

                 posX = offset.left - 680;

                 posX = 36;

                 //   document.getElementById("<%=divReopenDescription.ClientID%>").style.display = "block";
                 $MRD("#cphMain_divReopenDescription").show(500);
                 var d = document.getElementById("<%=divReopenDescription.ClientID%>");
                 d.style.position = "absolute";
                 d.style.left = posX + '%';
                 d.style.top = posY + 'px';

                 var div = $MRD("#cphMain_divReopenDescription");
                 div.animate({ top: '+=30px' }, "slow");


             }
             else {
                 var div = $MRD("#cphMain_divReopenDescription");
                 //   div.animate({ left: '+=35%' }, "slow");
                 div.animate({ top: '-=30px' }, "slow");
                 $MRD("#cphMain_divReopenDescription").hide(500);
                 // document.getElementById("<%=divReopenDescription.ClientID%>").style.display = "none";

             }
             return false;
         }

         function CloseReopenDescription() {
             var div = $MRD("#cphMain_divReopenDescription");
             //   div.animate({ left: '+=35%' }, "slow");
             div.animate({ top: '-=30px' }, "slow");
             $MRD("#cphMain_divReopenDescription").hide(500);

             return false;
         }


          </script>
    <script>

        //---------------------for product details section---------------------------

        var MainTempCount = 0;

        function AddMoreMainTemplate(Event, GrpId, GrpName, GrossAmnt, DiscMode, DiscVal, DiscAmnt, NetAmnt) {


            MainTempCount++;

            var recRow = '';
            recRow += '<tr id="ErrorMesgRowId_' + MainTempCount + '"><td><div id="divErrorNotification_' + MainTempCount + '" class="divErrorNotification" style="visibility: hidden">';
            recRow += '<label id="lblErrorNotification_' + MainTempCount + '" ></label>';
            recRow += '</div></td></tr>';

            recRow += '<tr id="TemplateRowId_' + MainTempCount + '" class="ClassMain">';
            recRow += '<td>';

            if(document.getElementById("<%=HiddenTemplatetype.ClientID%>").value == "2"){//project

                recRow += '<div class="fg2">';
                recRow += 'Quotation For:<input type="text" id="PrdctGrpName_' + MainTempCount + '" class="form-control fg2_inp1 tr_l" placeholder="Quotation For" title="Type in a name" onkeypress="return isTag(\'PrdctGrpName_' + MainTempCount + '\',event);" onblur="return CkeckDupGroupName(' + MainTempCount + ',event);" maxlength="100" />';
                recRow += '</div>';
                recRow += '<div class="fg2 flt_r tr_r">';
                recRow += '<button id="MainTempAdd_' + MainTempCount + '" class="btn act_btn bn11 clone" title="Add New" onclick="return CheckaddMoreRowsTotal();"><i class="opp_ico_img_ptp"><img src="/Images/New%20Images/images/icons/opp/copy_sec.png"></i></button>';
                recRow += '<button id="MainTempClose_' + MainTempCount + '" class="btn act_btn bn3 remove" title="Delete" onclick="removeMainTemplate(' + MainTempCount + ');return false;"><i class="fa fa-trash"></i></button>';
                recRow += '</div>';

                recRow += '<div id="divTables" class="table_box tb_scr r_1024">';

                //without tax
                recRow += '<table id="TableProductWithoutTaxHead_' + MainTempCount + '" class="table table-bordered tbl_1024">';
                recRow += '<thead class="thead1">';
                recRow += '<tr>';
                recRow += '<th class="th_b2 tr_l">PRODUCT / Service </th>';
                recRow += '<th class="th_b6 tr_c">UNIT</th>';
                recRow += '<th class="th_b1 tr_c">QTY</th>';
                recRow += '<th class="th_b7 tr_r">COST PRICE</th>';
                recRow += '<th class="th_b7">Margin%</th>';
                recRow += '<th class="th_b6 tr_c">Selling<br> Price</th>';
                recRow += '<th class="th_b7 tr_c">Discount<br> Amount</th>';
                recRow += '<th class="th_b6 tr_r">Total</th>';
                recRow += '<th class="th_b4">ACTIONS</th>';
                recRow += '</tr>';
                recRow += '</thead>';
                recRow += '<tbody id="TableProductWithoutTaxBody_' + MainTempCount + '">';
                recRow += '</tbody>';
                recRow += '<tfoot id="TableFooterWithoutTax_' + MainTempCount + '" class="bg1" style="background-color:#eceff1!important;">';
                recRow += '<th colspan="3" class="tr_l txt_rd">Total</th>';
                recRow += '<th id="tdFooterTotalCPriceWithoutTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalMarginWithoutTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalSPriceWithoutTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalDiscAmntWithoutTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalAmountWithoutTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th></th>';
                recRow += '</tfoot>';
                recRow += '</table>';
                //without tax

                //with tax
                recRow += '<table id="TableProductWithTaxHead_' + MainTempCount + '" class="table table-bordered tbl_1024">';
                recRow += '<thead class="thead1">';
                recRow += '<tr>';
                recRow += '<th class="th_b2 tr_l">PRODUCT / Service </th>';
                recRow += '<th class="th_b6 tr_c">UNIT</th>';
                recRow += '<th class="th_b1 tr_c">QTY</th>';
                recRow += '<th class="th_b7 tr_r">COST PRICE</th>';
                recRow += '<th class="th_b7">Margin%</th>';
                recRow += '<th class="th_b6 tr_c">Selling<br> Price</th>';
                recRow += '<th class="th_b2 tr_c">Tax Amount</th>';
                recRow += '<th class="th_b7 tr_c">Discount<br> Amount</th>';
                recRow += '<th class="th_b6 tr_r">Total</th>';
                recRow += '<th class="th_b4">ACTIONS</th>';
                recRow += '</tr>';
                recRow += '</thead>';
                recRow += '<tbody id="TableProductWithTaxBody_' + MainTempCount + '">';
                recRow += '</tbody>';
                recRow += '<tfoot id="TableFooterWithTax_' + MainTempCount + '" class="bg1" style="background-color:#eceff1!important;">';
                recRow += '<th colspan="3" class="tr_l txt_rd">Total</th>';
                recRow += '<th id="tdFooterTotalCPriceWithTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalMarginWithTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalSPriceWithTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalTaxPerWithTax_' + MainTempCount + '" class="tr_r txt_rd" style="display:none;"></th>';
                recRow += '<th id="tdFooterTotalTaxAmntWithTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalDiscAmntWithTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalAmountWithTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th></th>';
                recRow += '</tfoot>';
                recRow += '</table>';
                //with tax

                recRow += '</div>';

                recRow += '<div class="text_area_container flt_l txt1_a pa_tx_1 gross_gray">';
                recRow += '<div class="col-md-6 tx_st"></div>';
                recRow += '<div class="col-md-6">';

                recRow += '<div class="col-md-12 txt_alg al1">';
                recRow += '<div class="col-md-5 col-sm-5 col-xs-5">';
                recRow += '<label for="email" class="fg2_la1 tt_am">Gross Amount: <span class="spn1">&nbsp;</span></label>';
                recRow += '</div>';
                recRow += '<div class="col-md-5 col-sm-5 col-xs-5">';
                recRow += '<input type="text" id="txtGrossAmount_' + MainTempCount + '" class="tt_am tt_al rt_l flt_l" disabled="true" maxLength="20" style="border:none;background-color:#ebeeef;" />';
                recRow += '</div>';
                recRow += '</div>';

                recRow += '<div class="col-md-12 txt_alg al1">';
                recRow += '<div class="col-md-5 col-sm-5 col-xs-5">';
                recRow += '<label for="email" class="fg2_la1 tt_am am3">Discount:<span class="spn1">&nbsp;</span></label>';
                recRow += '</div>';
                recRow += '<div class="col-md-6 col-sm-6 col-xs-6 dsc_1">';
                recRow += '<div class="input-group ing1 dsc_1">';
                recRow += '<input type="text" id="txtDiscntValPerc_' + MainTempCount + '" class="form-control fg2_inp2 inp_st tr_r" maxLength="6" onkeydown="return isNumber(\'txtDiscntValPerc_' + MainTempCount + '\',\'cphMain_btnSave\', event)" onblur="BlurDiscVal(\'txtDiscntValPerc_\',' + MainTempCount + ');" onkeypress=" return DisableEnter(event);" />';
                recRow += '<span class="input-group-addon cur3">%</span>';
                recRow += '</div>';
                recRow += '<div class="input-group ing2 col-sm-6 dsc_1 flt_480_r">';
                recRow += ' <input type="text" id="txtDiscntValAmnt_' + MainTempCount + '" class="form-control fg2_inp2 inp_st tr_r" maxLength="23" onkeydown="return isNumber(\'txtDiscntValAmnt_' + MainTempCount + '\',\'cphMain_btnSave\', event)" onkeypress=" return DisableEnter(event);" onblur="BlurDiscVal(\'txtDiscntValAmnt_\',' + MainTempCount + ');"  />';
                recRow += '<span class="input-group-addon cur3">' + document.getElementById("<%=hiddenCurrencyCode.ClientID%>").value + '</span>';
                recRow += '</div>';
                recRow += '</div>';
                recRow += '</div>';
                recRow += ' <input style="display:none;" type="text" id="txtTotalDiscntAmnt_' + MainTempCount + '" value="0" maxLength="10" />';

                recRow += '<div class="col-md-12 txt_alg al1">';
                recRow += '<hr class="hr_amt amt_res1">';
                recRow += '<div class="col-md-5 col-sm-5 col-xs-5">';
                recRow += '<label for="email" class="fg2_la1 tt_am am1">Net Amount:<span class="spn1"></span></label>';
                recRow += '</div>';
                recRow += '<div class="col-md-5 col-sm-5 col-xs-5">';
                recRow += '<input type="text" id="txtNetAmount_' + MainTempCount + '" class="tt_am am1 tt_al rt_l flt_l" disabled="true" maxLength="20" style="border:none;background-color:#ebeeef;" />';
                recRow += '</div>';
                recRow += '</div>';

                recRow += '</div>';
                recRow += '</div>';
            }
            else if(document.getElementById("<%=HiddenTemplatetype.ClientID%>").value == "3"){//tender

                recRow += '<div class="clone_sec0">';
                recRow += '<div class="spl_hcm wid_100_1 hei_102 bg_ne_1" style="margin-bottom: 10px;">';

                recRow += '<div class="fg2">';
                recRow += 'Quotation For:<input type="text" id="PrdctGrpName_' + MainTempCount + '" class="form-control fg2_inp1 tr_l" placeholder="Quotation For" title="Type in a name" onkeypress="return isTag(\'PrdctGrpName_' + MainTempCount + '\',event);" onblur="return CkeckDupGroupName(' + MainTempCount + ',event);" maxlength="100" />';
                recRow += '</div>';

                recRow += '<div class="fg2 flt_r tr_r">';
                recRow += '<button id="MainTempAdd_' + MainTempCount + '" class="btn act_btn bn11 clone" title="Add New" onclick="return CheckaddMoreRowsTotal();"><i class="opp_ico_img_ptp"><img src="/Images/New%20Images/images/icons/opp/copy_sec.png"></i></button>';
                recRow += '<button id="MainTempClose_' + MainTempCount + '" class="btn act_btn bn3 remove" title="Delete" onclick="removeMainTemplate(' + MainTempCount + ');return false;"><i class="fa fa-trash"></i></button>';
                recRow += '</div>';

                recRow += '<div id="divTables" class="table_box tb_scr r_1024">';

                //without tax
                recRow += '<table id="TableProductWithoutTaxHead_' + MainTempCount + '" class="table table-bordered tbl_1024">';
                recRow += '<thead class="thead1">';
                recRow += '<tr>';
                recRow += '<th class="th_b2 tr_l">PRODUCT / Service </th>';
                recRow += '<th class="th_b6 tr_c">UNIT</th>';
                recRow += '<th class="th_b1 tr_c">QTY</th>';
                recRow += '<th class="th_b7 tr_r">COST PRICE</th>';
                recRow += '<th class="th_b7">Margin%</th>';
                recRow += '<th class="th_b6 tr_c">Selling<br> Price</th>';
                recRow += '<th class="th_b7 tr_c">Discount<br> Amount</th>';
                recRow += '<th class="th_b6 tr_r">Total</th>';
                recRow += '<th class="th_b4">ACTIONS</th>';
                recRow += '</tr>';
                recRow += '</thead>';
                recRow += '<tbody id="TableProductWithoutTaxBody_' + MainTempCount + '">';
                recRow += '</tbody>';
                recRow += '<tfoot id="TableFooterWithoutTax_' + MainTempCount + '" class="bg1" style="background-color:#eceff1!important;">';
                recRow += '<th colspan="3" class="tr_l txt_rd">Total</th>';
                recRow += '<th id="tdFooterTotalCPriceWithoutTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalMarginWithoutTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalSPriceWithoutTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalDiscAmntWithoutTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalAmountWithoutTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th></th>';
                recRow += '</tfoot>';
                recRow += '</table>';
                //without tax

                //with tax
                recRow += '<table id="TableProductWithTaxHead_' + MainTempCount + '" class="table table-bordered tbl_1024">';
                recRow += '<thead class="thead1">';
                recRow += '<tr>';
                recRow += '<th class="th_b2 tr_l">PRODUCT / Service </th>';
                recRow += '<th class="th_b6 tr_c">UNIT</th>';
                recRow += '<th class="th_b1 tr_c">QTY</th>';
                recRow += '<th class="th_b7 tr_r">COST PRICE</th>';
                recRow += '<th class="th_b7">Margin%</th>';
                recRow += '<th class="th_b6 tr_c">Selling<br> Price</th>';
                recRow += '<th class="th_b2 tr_c">Tax Amount</th>';
                recRow += '<th class="th_b7 tr_c">Discount<br> Amount</th>';
                recRow += '<th class="th_b6 tr_r">Total</th>';
                recRow += '<th class="th_b4">ACTIONS</th>';
                recRow += '</tr>';
                recRow += '</thead>';
                recRow += '<tbody id="TableProductWithTaxBody_' + MainTempCount + '">';
                recRow += '</tbody>';
                recRow += '<tfoot id="TableFooterWithTax_' + MainTempCount + '" class="bg1" style="background-color:#eceff1!important;">';
                recRow += '<th colspan="3" class="tr_l txt_rd">Total</th>';
                recRow += '<th id="tdFooterTotalCPriceWithTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalMarginWithTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalSPriceWithTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalTaxPerWithTax_' + MainTempCount + '" class="tr_r txt_rd" style="display:none;"></th>';
                recRow += '<th id="tdFooterTotalTaxAmntWithTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalDiscAmntWithTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th id="tdFooterTotalAmountWithTax_' + MainTempCount + '" class="tr_r txt_rd"></th>';
                recRow += '<th></th>';
                recRow += '</tfoot>';
                recRow += '</table>';
                //with tax

                recRow += '</div>';

                recRow += '<div class="text_area_container flt_l txt1_a pa_tx_1 gross_gray">';
                recRow += '<div class="col-md-6 tx_st"></div>';
                recRow += '<div class="col-md-6">';

                recRow += '<div class="col-md-12 txt_alg al1">';
                recRow += '<div class="col-md-5 col-sm-5 col-xs-5">';
                recRow += '<label for="email" class="fg2_la1 tt_am">Gross Amount: <span class="spn1">&nbsp;</span></label>';
                recRow += '</div>';
                recRow += '<div class="col-md-5 col-sm-5 col-xs-5">';
                recRow += '<input type="text" id="txtGrossAmount_' + MainTempCount + '" class="tt_am tt_al rt_l flt_l" disabled="true" maxLength="20" style="border:none;background-color:#ebeeef;" />';
                recRow += '</div>';
                recRow += '</div>';

                recRow += '<div class="col-md-12 txt_alg al1">';
                recRow += '<div class="col-md-5 col-sm-5 col-xs-5">';
                recRow += '<label for="email" class="fg2_la1 tt_am am3">Discount:<span class="spn1">&nbsp;</span></label>';
                recRow += '</div>';
                recRow += '<div class="col-md-6 col-sm-6 col-xs-6 dsc_1">';
                recRow += '<div class="input-group ing1 dsc_1">';
                recRow += '<input type="text" id="txtDiscntValPerc_' + MainTempCount + '" class="form-control fg2_inp2 inp_st tr_r" maxLength="6" onkeydown="return isNumber(\'txtDiscntValPerc_' + MainTempCount + '\',\'cphMain_btnSave\', event)" onblur="BlurDiscVal(\'txtDiscntValPerc_\',' + MainTempCount + ');" onkeypress=" return DisableEnter(event);" />';
                recRow += '<span class="input-group-addon cur3">%</span>';
                recRow += '</div>';
                recRow += '<div class="input-group ing2 col-sm-6 dsc_1 flt_480_r">';
                recRow += '<input type="text" id="txtDiscntValAmnt_' + MainTempCount + '" class="form-control fg2_inp2 inp_st tr_r" maxLength="23" onkeydown="return isNumber(\'txtDiscntValAmnt_' + MainTempCount + '\',\'cphMain_btnSave\', event)" onkeypress=" return DisableEnter(event);" onblur="BlurDiscVal(\'txtDiscntValAmnt_\',' + MainTempCount + ');"  />';
                recRow += '<span class="input-group-addon cur3">' + document.getElementById("<%=hiddenCurrencyCode.ClientID%>").value + '</span>';
                recRow += '</div>';
                recRow += '</div>';
                recRow += '</div>';
                recRow += ' <input style="display:none;" type="text" id="txtTotalDiscntAmnt_' + MainTempCount + '"  value="0" maxLength="10" />';

                recRow += '<div class="col-md-12 txt_alg al1">';
                recRow += '<hr class="hr_amt amt_res1">';
                recRow += '<div class="col-md-5 col-sm-5 col-xs-5">';
                recRow += '<label for="email" class="fg2_la1 tt_am am1">Net Amount:<span class="spn1"></span></label>';
                recRow += '</div>';
                recRow += '<div class="col-md-5 col-sm-5 col-xs-5">';
                recRow += ' <input type="text" id="txtNetAmount_' + MainTempCount + '" class="tt_am am1 tt_al rt_l flt_l" disabled="true" maxLength="20" style="border:none;background-color:#ebeeef;" />';
                recRow += '</div>';
                recRow += '</div>';
                
                recRow += '</div>';
                recRow += '</div>';

                recRow += '</div>';
                recRow += '</div>';
            }

            recRow += '</td>';
            recRow += '<td id="tdPrdctGrpId_' + MainTempCount + '" style="display: none;">' + GrpId + '</td>';
            recRow += '<td id="tdPrdctGrpEvt_' + MainTempCount + '" style="display: none;">' + Event + '</td>';
            recRow += '</tr>';

            jQuery('#tableTotalProductContainer').append(recRow);


            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                document.getElementById('TableProductWithoutTaxHead_' + MainTempCount).style.display = "none";
                document.getElementById('TableFooterWithoutTax_' + MainTempCount).style.display = "none";
            } else {
                document.getElementById('TableProductWithTaxHead_' + MainTempCount).style.display = "none";
                document.getElementById('TableFooterWithTax_' + MainTempCount).style.display = "none";
            }

            if (Event == "UPD" || Event == "COPY") {
                if (GrpName != 0) {
                    document.getElementById('PrdctGrpName_' + MainTempCount).value = GrpName;
                }
                document.getElementById('txtGrossAmount_' + MainTempCount).value = GrossAmnt;

                if (DiscMode == "1") {
                    document.getElementById('txtDiscntValAmnt_' + MainTempCount).value = DiscVal;
                    BlurDiscVal('txtDiscntValAmnt_', MainTempCount);
                } else {
                    document.getElementById('txtDiscntValPerc_' + MainTempCount).value = DiscVal;
                    BlurDiscVal('txtDiscntValPerc_', MainTempCount);
                }

                document.getElementById('txtTotalDiscntAmnt_' + MainTempCount).value = DiscAmnt;
                document.getElementById('txtNetAmount_' + MainTempCount).value = NetAmnt;
            }

            // InitializeSubCount();

            if (Event == "UPD" || Event == "COPY") {
             
                var CopiedCatTotalVal = document.getElementById("<%=hiddenEditCatDataCopied.ClientID%>").value;
                var CatTotalVal = document.getElementById("<%=hiddenEditCatData.ClientID%>").value;

                if (CopiedCatTotalVal != "" && CopiedCatTotalVal != "[]") {
                    CatTotalVal = CopiedCatTotalVal
                }

                if (CatTotalVal != "" && CatTotalVal != "[]") {

                    var find4 = '\\"\\[';
                    var re4 = new RegExp(find4, 'g');
                    var res4 = CatTotalVal.replace(re4, '\[');

                    var find5 = '\\]\\"';
                    var re5 = new RegExp(find5, 'g');
                    var res5 = res4.replace(re5, '\]');

                    var json = $noCon.parseJSON(res5);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                          
                            if (json[key].GRPID == GrpId) {
                                var OpenCat = "";
                                if (json[key].CATNAME != "") {
                                    OpenCat = "true";
                                } else {
                                    OpenCat = "false";
                                }
                                var CopiedVal = document.getElementById("<%=HiddenCopiedval.ClientID%>").value;
                                var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
                                var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;
                               
                                if (CopiedVal != "" && CopiedVal != "[]") {

                                    var find2 = '\\"\\[';
                                    var re2 = new RegExp(find2, 'g');
                                    var res2 = CopiedVal.replace(re2, '\[');

                                    var find3 = '\\]\\"';
                                    var re3 = new RegExp(find3, 'g');
                                    var res3 = res2.replace(re3, '\]');

                                    var json2 = $noCon.parseJSON(res3);
                                    for (var key2 in json2) {
                                        if (json2.hasOwnProperty(key2)) {
                                            if (json2[key2].TransDtlId != "") {

                                                if (json2[key2].ProductGroupId == GrpId && json[key].CATNAME == json2[key2].ProductCat) {

                                                    if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                                                        document.getElementById('TableProductWithoutTaxHead_' + MainTempCount).style.display = "none";
                                                        document.getElementById('TableFooterWithoutTax_' + MainTempCount).style.display = "none";
                                                    
                                                        AddMoreProductRowWithTax(MainTempCount, 0, "COPY", json2[key2].ProductName, json2[key2].UnitName, json2[key2].Quantity, json2[key2].CostPrice, json2[key2].Hike, json2[key2].Rate, json2[key2].TaxPer, json2[key2].TaxAmnt, json2[key2].DiscountAmnt, json2[key2].Amount, json2[key2].AddDesc, json2[key2].StockStatus, json2[key2].TransDtlId, json2[key2].PrintSts, json2[key2].ProductCat, OpenCat, "other", json2[key2].ProductWinSts ,json2[key2].StockName);

                                                    }
                                                    else {

                                                        AddMoreProductRow(MainTempCount, 0, "COPY", json2[key2].ProductName, json2[key2].UnitName, json2[key2].Quantity, json2[key2].CostPrice, json2[key2].Hike, json2[key2].Rate, json2[key2].DiscountAmnt, json2[key2].Amount, json2[key2].AddDesc, json2[key2].StockStatus, json2[key2].TransDtlId, json2[key2].PrintSts, json2[key2].ProductCat, OpenCat, "other", json2[key2].ProductWinSts ,json2[key2].StockName);

                                                    }
                                                    OpenCat = "false";

                                                }


                                            }
                                        }
                                    }

                                }
                                else if (EditVal != "" && EditVal != "[]") {

                                    var find2 = '\\"\\[';
                                    var re2 = new RegExp(find2, 'g');
                                    var res2 = EditVal.replace(re2, '\[');

                                    var find3 = '\\]\\"';
                                    var re3 = new RegExp(find3, 'g');
                                    var res3 = res2.replace(re3, '\]');

                                    var json2 = $noCon.parseJSON(res3);
                                    for (var key2 in json2) {
                                        if (json2.hasOwnProperty(key2)) {
                                            if (json2[key2].TransDtlId != "") {

                                                if (json2[key2].ProductGroupId == GrpId && json[key].CATNAME == json2[key2].ProductCat) {

                                                
                                                    if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                                                        document.getElementById('TableProductWithoutTaxHead_' + MainTempCount).style.display = "none";
                                                        document.getElementById('TableFooterWithoutTax_' + MainTempCount).style.display = "none";

                                                        AddMoreProductRowWithTax(MainTempCount, 0, "UPD", json2[key2].ProductName, json2[key2].UnitName, json2[key2].Quantity, json2[key2].CostPrice, json2[key2].Hike, json2[key2].Rate, json2[key2].TaxPer, json2[key2].TaxAmnt, json2[key2].DiscountAmnt, json2[key2].Amount, json2[key2].AddDesc, json2[key2].StockStatus, json2[key2].TransDtlId, json2[key2].PrintSts, json2[key2].ProductCat, OpenCat, "other", json2[key2].ProductWinSts ,json2[key2].StockName);

                                                    }
                                                    else {

                                                        AddMoreProductRow(MainTempCount, 0, "UPD", json2[key2].ProductName, json2[key2].UnitName, json2[key2].Quantity, json2[key2].CostPrice, json2[key2].Hike, json2[key2].Rate, json2[key2].DiscountAmnt, json2[key2].Amount, json2[key2].AddDesc, json2[key2].StockStatus, json2[key2].TransDtlId, json2[key2].PrintSts, json2[key2].ProductCat, OpenCat, "other", json2[key2].ProductWinSts ,json2[key2].StockName);

                                                    }
                                                    OpenCat = "false";

                                                }


                                            }
                                        }
                                    }
                                    
                                }
                                else if (ViewVal != "" && ViewVal != "[]") {
                                 
                                    var find2 = '\\"\\[';
                                    var re2 = new RegExp(find2, 'g');
                                    var res2 = ViewVal.replace(re2, '\[');

                                    var find3 = '\\]\\"';
                                    var re3 = new RegExp(find3, 'g');
                                    var res3 = res2.replace(re3, '\]');

                                    var json2 = $noCon.parseJSON(res3);
                                    for (var key2 in json2) {
                                        if (json2.hasOwnProperty(key2)) {
                                            if (json2[key2].TransDtlId != "") {

                                                if (json2[key2].ProductGroupId == GrpId && json[key].CATNAME == json2[key2].ProductCat) {


                                                    if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                                                        document.getElementById('TableProductWithoutTaxHead_' + MainTempCount).style.display = "none";
                                                        document.getElementById('TableFooterWithoutTax_' + MainTempCount).style.display = "none";

                                                        AddMoreProductRowWithTax(MainTempCount, 0, "UPD", json2[key2].ProductName, json2[key2].UnitName, json2[key2].Quantity, json2[key2].CostPrice, json2[key2].Hike, json2[key2].Rate, json2[key2].TaxPer, json2[key2].TaxAmnt, json2[key2].DiscountAmnt, json2[key2].Amount, json2[key2].AddDesc, json2[key2].StockStatus, json2[key2].TransDtlId, json2[key2].PrintSts, json2[key2].ProductCat, OpenCat, "other", json2[key2].ProductWinSts ,json2[key2].StockName);

                                                    }
                                                    else {

                                                        AddMoreProductRow(MainTempCount, 0, "UPD", json2[key2].ProductName, json2[key2].UnitName, json2[key2].Quantity, json2[key2].CostPrice, json2[key2].Hike, json2[key2].Rate, json2[key2].DiscountAmnt, json2[key2].Amount, json2[key2].AddDesc, json2[key2].StockStatus, json2[key2].TransDtlId, json2[key2].PrintSts, json2[key2].ProductCat, OpenCat, "other", json2[key2].ProductWinSts ,json2[key2].StockName);

                                                    }
                                                    OpenCat = "false";

                                                }


                                            }
                                        }
                                    }
                                    $("#divTotalproductDetailContainer *").attr("disabled", "disabled");
                                    enableAllAdditionalForView();
                                }


                                if (json[key].CATNAME != "") {
                                    AddSubTotal(MainTempCount, 0, 1);
                                }

                            }


                        }
                    }

                }

                else {
                    var OpenCat = "false";
                    var CopiedVal = document.getElementById("<%=HiddenCopiedval.ClientID%>").value;
                    var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
                    var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;

                    if (CopiedVal != "" && CopiedVal != "[]") {

                        var find2 = '\\"\\[';
                        var re2 = new RegExp(find2, 'g');
                        var res2 = CopiedVal.replace(re2, '\[');

                        var find3 = '\\]\\"';
                        var re3 = new RegExp(find3, 'g');
                        var res3 = res2.replace(re3, '\]');

                        var json = $noCon.parseJSON(res3);
                        for (var key in json) {
                            if (json.hasOwnProperty(key2)) {
                                if (json[key2].TransId != "") {
                                    if (json[key2].ProductGroupId == GrpId) {

                                        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                                            document.getElementById('TableProductWithoutTaxHead_' + MainTempCount).style.display = "none";
                                            document.getElementById('TableFooterWithoutTax_' + MainTempCount).style.display = "none";

                                            AddMoreProductRowWithTax(MainTempCount, 0, "COPY", json2[key2].ProductName, json2[key2].UnitName, json2[key2].Quantity, json2[key2].CostPrice, json2[key2].Hike, json2[key2].Rate, json2[key2].TaxPer, json2[key2].TaxAmnt, json2[key2].DiscountAmnt, json2[key2].Amount, json2[key2].AddDesc, json2[key2].StockStatus, json2[key2].TransDtlId, json2[key2].PrintSts, json2[key2].ProductCat, OpenCat, "other", json2[key2].ProductWinSts ,json2[key2].StockName);

                                        }
                                        else {

                                            AddMoreProductRow(MainTempCount, 0, "COPY", json2[key2].ProductName, json2[key2].UnitName, json2[key2].Quantity, json2[key2].CostPrice, json2[key2].Hike, json2[key2].Rate, json2[key2].DiscountAmnt, json2[key2].Amount, json2[key2].AddDesc, json2[key2].StockStatus, json2[key2].TransDtlId, json2[key2].PrintSts, json2[key2].ProductCat, OpenCat, "other", json2[key2].ProductWinSts ,json2[key2].StockName);

                                        }

                                    }
                                }
                            }
                        }
                    }
                    else if (EditVal != "" && EditVal != "[]") {

                        var find2 = '\\"\\[';
                        var re2 = new RegExp(find2, 'g');
                        var res2 = EditVal.replace(re2, '\[');

                        var find3 = '\\]\\"';
                        var re3 = new RegExp(find3, 'g');
                        var res3 = res2.replace(re3, '\]');

                        var json = $noCon.parseJSON(res3);
                        for (var key in json) {
                            if (json.hasOwnProperty(key2)) {
                                if (json[key2].TransId != "") {
                                    if (json[key2].ProductGroupId == GrpId) {

                                        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                                            document.getElementById('TableProductWithoutTaxHead_' + MainTempCount).style.display = "none";
                                            document.getElementById('TableFooterWithoutTax_' + MainTempCount).style.display = "none";

                                            AddMoreProductRowWithTax(MainTempCount, 0, "UPD", json2[key2].ProductName, json2[key2].UnitName, json2[key2].Quantity, json2[key2].CostPrice, json2[key2].Hike, json2[key2].Rate, json2[key2].TaxPer, json2[key2].TaxAmnt, json2[key2].DiscountAmnt, json2[key2].Amount, json2[key2].AddDesc, json2[key2].StockStatus, json2[key2].TransDtlId, json2[key2].PrintSts, json2[key2].ProductCat, OpenCat, "other", json2[key2].ProductWinSts ,json2[key2].StockName);

                                        }
                                        else {

                                            AddMoreProductRow(MainTempCount, 0, "UPD", json2[key2].ProductName, json2[key2].UnitName, json2[key2].Quantity, json2[key2].CostPrice, json2[key2].Hike, json2[key2].Rate, json2[key2].DiscountAmnt, json2[key2].Amount, json2[key2].AddDesc, json2[key2].StockStatus, json2[key2].TransDtlId, json2[key2].PrintSts, json2[key2].ProductCat, OpenCat, "other", json2[key2].ProductWinSts ,json2[key2].StockName);

                                        }

                                    }
                                }
                            }
                        }
                    }
                    else if (ViewVal != "" && ViewVal != "[]") {
                        var find2 = '\\"\\[';
                        var re2 = new RegExp(find2, 'g');
                        var res2 = ViewVal.replace(re2, '\[');

                        var find3 = '\\]\\"';
                        var re3 = new RegExp(find3, 'g');
                        var res3 = res2.replace(re3, '\]');

                        var json = $noCon.parseJSON(res3);
                        for (var key in json) {
                            if (json.hasOwnProperty(key2)) {
                                if (json[key2].TransId != "") {
                                    if (json[key2].ProductGroupId == GrpId) {

                                        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                                            document.getElementById('TableProductWithoutTaxHead_' + MainTempCount).style.display = "none";
                                            document.getElementById('TableFooterWithoutTax_' + MainTempCount).style.display = "none";

                                            AddMoreProductRowWithTax(MainTempCount, 0, "UPD", json2[key2].ProductName, json2[key2].UnitName, json2[key2].Quantity, json2[key2].CostPrice, json2[key2].Hike, json2[key2].Rate, json2[key2].TaxPer, json2[key2].TaxAmnt, json2[key2].DiscountAmnt, json2[key2].Amount, json2[key2].AddDesc, json2[key2].StockStatus, json2[key2].TransDtlId, json2[key2].PrintSts, json2[key2].ProductCat, OpenCat, "other", json2[key2].ProductWinSts ,json2[key2].StockName);

                                        }
                                        else {

                                            AddMoreProductRow(MainTempCount, 0, "UPD", json2[key2].ProductName, json2[key2].UnitName, json2[key2].Quantity, json2[key2].CostPrice, json2[key2].Hike, json2[key2].Rate, json2[key2].DiscountAmnt, json2[key2].Amount, json2[key2].AddDesc, json2[key2].StockStatus, json2[key2].TransDtlId, json2[key2].PrintSts, json2[key2].ProductCat, OpenCat, "other", json2[key2].ProductWinSts ,json2[key2].StockName);

                                        }

                                    }
                                }
                            }
                        }
                        $("#divTotalproductDetailContainer *").attr("disabled", "disabled");
                      
                        enableAllAdditionalForView();
                    }
                }
                CalculateTotalAmountFromHiddenField(MainTempCount);

            }

            else {
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    AddMoreProductRowWithTax(MainTempCount, 0, "INS", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "false", "other","0","");
                }
                else {
                    AddMoreProductRow(MainTempCount, 0, "INS", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "false", "other","0","");
                }

                if (DiscMode == "1") {
                    BlurDiscVal('txtDiscntValAmnt_', MainTempCount);
                }
                else{
                    BlurDiscVal('txtDiscntValPerc_', MainTempCount);
                }
            }
            var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;
            if (ViewVal != "" && ViewVal != "[]") {
            } else {
                AddButtonVisible(MainTempCount);
            }

        }

        function CheckaddMoreRowsTotal() {
            
            var ret=true;

            var MainTable = $('#tableTotalProductContainer tr.ClassMain');
            $(MainTable).each(function () {

                var RowIdMain = $(this).attr('id');
                var SplitIdMain = RowIdMain.split('_');
                var RowIdMainName = SplitIdMain[0];
                var CntMain = SplitIdMain[1];

                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    subTable = $('#TableProductWithTaxBody_' + CntMain + ' tr.ClassBody');
                }
                else {
                    subTable = $('#TableProductWithoutTaxBody_' + CntMain + ' tr.ClassBody');
                }
                $(subTable).each(function () {

                    var RowId = $(this).attr('id');
                    var SplitId = RowId.split('_');
                    var RowIdName = SplitId[0];
                    var MainCount = SplitId[1];
                    var SubCount = SplitId[2];

                    if (CheckAllRowFieldAndHighlight(MainCount, SubCount) == false) {
                        ret=false;
                    }
                });
            });

            if(ret==true){
                AddMoreMainTemplate("INS","0","0","0","0","0","0","0");
            }

            return false;
        }

        function enableAllAdditionalForView() {

            var MainTable = $('#tableTotalProductContainer tr.ClassMain');
            $(MainTable).each(function () {

                var RowIdMain = $(this).attr('id');
                var SplitIdMain = RowIdMain.split('_');
                var RowIdMainName = SplitIdMain[0];
                var CntMain = SplitIdMain[1];

                var subTable = "";

                if (RowIdMainName == "TemplateRowId") {
                    if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                        subTable = $('#TableProductWithTaxBody_' + CntMain + ' tr.ClassBody');
                    }
                    else {

                        subTable = $('#TableProductWithoutTaxBody_' + CntMain + ' tr.ClassBody');
                    }

                    $(subTable).each(function () {
                        var RowId = $(this).attr('id');
                        var SplitId = RowId.split('_');
                        var RowIdName = SplitId[0];
                        var MainCount = SplitId[1];
                        var SubCount = SplitId[2];

                        if (RowIdName == "RowTableProductWithoutTax" || RowIdName == "RowTableProductWithTax") {
                            var Itemselect = $noconfli("#imgMoreInfo_" + MainCount + "_" + SubCount);

                            if (Itemselect.length) {

                                document.getElementById('imgMoreInfo_' + MainCount + '_' + SubCount).disabled = false;
                                document.getElementById('imgAddRow_' + MainCount + '_' + SubCount).disabled = true;
                            }
                        }
                    });
                }
            });

            $("#myModal *").attr("disabled", "disabled");
        }


        var SubTempCount = 0;

        function InitializeSubCount() {
            SubTempCount = 0;
        }


        function AddMoreProductRow(MainCount, CurrRow, EventAction, UPDProductName, UPDUnitName, UPDQuantity, UPDCostPrice, UPDHike, UPDRate, UPDDiscountAmnt, UPDAmount, UPDAddDesc, UPDStockStatus, UPDTransDtlId, UPDPrintSts, UPDProductCat, OpenCatOrNot, CsvOrNot, PrdctWinSts,StockName) {
         
            SubTempCount++;

            var num = 0;
            var nMoney = 0;
            var nUnit = 0;
            var nCommonPerc = 0;

            var QtyMaxLen = 8;
            var HikeMaxLen = 6;
            var DiscPercMaxLen = 6;
            var DiscAmntMaxLen = 23;
            var AmntMaxLen = 23;
            var CPriceMaxLen = 23;
            var RateMaxLen = 23;


            var FloatingValueMoney = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
            if (FloatingValueMoney != "") {

                nMoney = num.toFixed(FloatingValueMoney);

                var fVal = parseInt(FloatingValueMoney) + 1;

                var AmntMaxLen = 13 - fVal;
            }
            var FloatingValueUnit = document.getElementById("<%=hiddenFloatingValueUnit.ClientID%>").value;
            if (FloatingValueUnit != "") {

                nUnit = num.toFixed(FloatingValueUnit);

            }
            var FloatingValueCmmnPercentage = document.getElementById("<%=hiddenFloatingValueCommonPercentage.ClientID%>").value;
            if (FloatingValueCmmnPercentage != "") {

                nCommonPerc = num.toFixed(FloatingValueCmmnPercentage);

            }
 
            var recRow='';

            recRow += '<tr id="RowTableHeadWithoutTax_' + MainCount + '_' + SubTempCount + '" class="ClassHead">';
            recRow += '<td id="tdAddCtgry' + MainCount + '_' + SubTempCount + '" style="width:50px!important;text-align: left; display:block;" class="dis_td1" colspan="11">';
            recRow += '<button id="btnCatgryAdd_' + MainCount + '_' + SubTempCount + '" class="btn act_btn bn11 bt_cat_g1" title="Add Category" onclick="return AddcategoryRow(' + MainCount + ',' + SubTempCount + ',1,\'true\');"><i class="opp_ico_img_ptp"><img src="/Images/New%20Images/images/icons/opp/add_cat.png"></i></button>';
            recRow += '</td>';
            recRow += '<td id="tdCtgry' + MainCount + '_' + SubTempCount + '" style="text-align: left; display: none;" class="dis_td2" colspan="11">';
            recRow += '<button id="btnCatgryRmv_' + MainCount + '_' + SubTempCount + '" class="btn act_btn bn3 flt_l bt_cat_g2" title="Remove Category" onclick="return RemovecategoryRow(' + MainCount + ',' + SubTempCount + ',1,\'true\');"><i class="fa fa-close"></i></button>';
            recRow += '<input type="text" id="txtCategoryName_' + MainCount + '_' + SubTempCount + '" class="form-control fg2_inp2 tr_l"  onkeypress="return isTag(\'txtCategoryName_' + MainCount + '_' + SubTempCount + '\',event);" onblur="ReplaceTag(\'txtCategoryName_' + MainCount + '_' + SubTempCount + '\',event);" maxlength="100" placeholder="Category Name" autofocus="" style="width: 30%!important;margin-left: 10px;height: 34px!important;">';
            recRow += '</td>';
            recRow += '</tr>';

            recRow += '<tr id="RowTableProductWithoutTax_' + MainCount + '_' + SubTempCount + '" class="ClassBody">';

            recRow += '<td style="display:none;">';
            recRow += '<div class="up" onclick="return MoveRowUp(\'RowTableProductWithoutTax_' + MainCount + '_' + SubTempCount + '\');" ><input type="image" src="/Images/Icons/row_up.png" /></div>';
            recRow += '<div class="down" onclick="return MoveRowDown(\'RowTableProductWithoutTax_' + MainCount + '_' + SubTempCount + '\');" ><input type="image" src="/Images/Icons/row_down.png" /></div>';
            recRow += '<div id="DivSerial_' + MainCount + '_' + SubTempCount + '" >' + SubTempCount + '</div>';
            recRow += '</td>';

            recRow += '<td> ';
            recRow += '<input id="txtItem_' + MainCount + '_' + SubTempCount + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" onkeypress="return isTagName(\'txtUnit_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurQtnItem(' + MainCount + ',' + SubTempCount + ')" onfocus="FocusQtnItem(' + MainCount + ',' + SubTempCount + ')"  type="text" maxlength="100" />';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input id="txtUnit_' + MainCount + '_' + SubTempCount + '" class="form-control fg2_inp2 tr_c" placeholder="Unit" type="text" onkeypress="return isTagName(\'txtQuantity_' + MainCount + '_' + SubTempCount + '\', event)"   onblur="return BlurQtnUnit(' + MainCount + ',' + SubTempCount + ')" onfocus="FocusQtnUnit(' + MainCount + ',' + SubTempCount + ')"  maxlength="50" />';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input id="txtQuantity_' + MainCount + '_' + SubTempCount + '" class="form-control fg2_inp2 tr_c" value="' + nUnit + '" type="text" maxlength="' + QtyMaxLen + '" onkeydown="return isNumber(\'txtQuantity_' + MainCount + '_' + SubTempCount + '\',\'txtCprice_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurValue(\'txtQuantity_\',' + MainCount + ',' + SubTempCount + ')" onfocus="FocusValue(\'txtQuantity_\',' + MainCount + ',' + SubTempCount + ')" />';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input id="txtCprice_' + MainCount + '_' + SubTempCount + '" value="' + nMoney + '" class="form-control fg2_inp2 tr_r" type="text"  maxlength="' + CPriceMaxLen + '" onkeydown="return isNumber(\'txtCprice_' + MainCount + '_' + SubTempCount + '\',\'txtHike_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurValue(\'txtCprice_\',' + MainCount + ',' + SubTempCount + ')" onfocus="FocusValue(\'txtCprice_\',' + MainCount + ',' + SubTempCount + ')" />';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input id="txtHike_' + MainCount + '_' + SubTempCount + '" value="' + nCommonPerc + '" class="form-control fg2_inp2 tr_r"  type="text" maxlength="' + HikeMaxLen + '" onkeydown="return isNumber(\'txtHike_' + MainCount + '_' + SubTempCount + '\',\'txtRate_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurValue(\'txtHike_\',' + MainCount + ',' + SubTempCount + ')" onfocus="FocusValue(\'txtHike_\',' + MainCount + ',' + SubTempCount + ')" />';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input id="txtRate_' + MainCount + '_' + SubTempCount + '" value="' + nMoney + '" class="form-control fg2_inp2 tr_r" type="text"   maxlength="' + RateMaxLen + '" onkeydown="return isNumber(\'txtRate_' + MainCount + '_' + SubTempCount + '\',\'txtTaxPerc_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurValue(\'txtRate_\',' + MainCount + ',' + SubTempCount + ')" onfocus="FocusValue(\'txtRate_\',' + MainCount + ',' + SubTempCount + ')" />';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input id="txtDiscAmnt_' + MainCount + '_' + SubTempCount + '"  value="' + nMoney + '" class="form-control fg2_inp2 tr_r" type="text"  maxlength="' + DiscAmntMaxLen + '" onkeydown="return isNumber(\'txtDiscAmnt_' + MainCount + '_' + SubTempCount + '\',\'imgMoreInfo_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurValue(\'txtDiscAmnt_\',' + MainCount + ',' + SubTempCount + ')" onfocus="FocusValue(\'txtDiscAmnt_\',' + MainCount + ',' + SubTempCount + ')"/>';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input disabled id="txtAmnt_' + MainCount + '_' + SubTempCount + '" value="' + nMoney + '" class="form-control fg2_inp2 tr_r" type="text" maxlength="' + AmntMaxLen + '" />';
            recRow += '</td>';

            recRow += '<td class="td1">';
            recRow += '<div class="btn_stl1">';
            recRow += '<a id="imgMoreInfo_' + MainCount + '_' + SubTempCount + '" class="btn act_btn bn4" title="Additional Information" onclick="SaveId(' + MainCount + ',' + SubTempCount + ');return false;" data-toggle="popover" data-placement="top" data-html="true" data-height="400" data-width="400" ';
            
            recRow+='data-content=" ';
            recRow+='<label class=\'form1 mar_bo\'><p id=\'pModal' + MainCount + '_' + SubTempCount + '\'></p></label>';
            recRow+='<p id=\'pRowCount\' style=\'display:none;\'>' + MainCount + '_' + SubTempCount + '</p>';
            recRow+='<label>Additional Information</label>';
            recRow+='<div class=\'check1 flt_r\' style=\'width:auto;float:right;margin:auto;text-align:right;margin-right:8px;\'>';
            recRow+='<div>';
            recRow+='<label class=\'switch tr_r flt_r\' title=\'Include Additional Information in PDF\'>';
            recRow+='<input type=\'checkbox\' id=\'ChkPrinted' + MainCount + '_' + SubTempCount + '\' checked=\'false\' onkeypress=\'return isTag(event);\' />';
            recRow+='<span class=\'slider_tog round\'></span>';
            recRow+='</div>';
            recRow+='</div>';
            recRow+='<textarea id=\'txtareaMoreInfo' + MainCount + '_' + SubTempCount + '\' cols=\'46\' rows=\'2\' placeholder=\'Description\' onkeypress=\'return isTagQuotesBackSlash(txtareaMoreInfo' + MainCount + '_' + SubTempCount + ', event);\' onkeydown=\'textCounter(txtareaMoreInfo' + MainCount + '_' + SubTempCount + ',3500);\' onkeyup=\'textCounter(txtareaMoreInfo' + MainCount + '_' + SubTempCount + ',3500);\' style=\'resize: none;\'></textarea><br />';
            recRow+='<label>Stock Availability:</label><br />';
            recRow+='<input type=\'text\' id=\'cbxPrdctStock' + MainCount + '_' + SubTempCount + '\' value=\''+StockName+'\' onkeypress=\'return LoadStockPrdct(' + MainCount + ',' + SubTempCount + ',event);\' onkeydown=\'return LoadStockPrdct(' + MainCount + ',' + SubTempCount + ',event);\' /><br/>';
            recRow+='<div class=\'clearfix\'></div><div class=\'devider mar_top6\'></div>';
            recRow+='<button id=\'btnSaveAdditional\' class=\'btn btn-success flt_r\' onclick=\'return SaveAdditional();\'>Save</button>';
            recRow+='<div id=\'tdStockPrdctId' + MainCount + '_' + SubTempCount + '\' style=\'display: none;\'>'+UPDStockStatus+'</div>';
            recRow+='<div id=\'tdStockPrdctName' + MainCount + '_' + SubTempCount + '\' style=\'display: none;\'>'+StockName+'</div>';
            recRow+=' "><i class="fa fa-sticky-note-o"></i></a>';
            recRow += '<button id="imgAddRow_' + MainCount + '_' + SubTempCount + '" class="btn act_btn bn2" title="Add"  onclick="return CheckaddMoreRowsIndividual(' + MainCount + ',' + SubTempCount + ');"><i class="fa fa-plus-circle"></i></button>';
            recRow += '<button class="btn act_btn bn3" title="Delete" onclick = "return CheckDelEachRowProduct(' + MainCount + ',' + SubTempCount + ');"><i class="fa fa-trash"></i></button>';
            recRow += '</div>';
            recRow += '</td>';

            recRow += '<td id="tdSave_' + MainCount + '_' + SubTempCount + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt_' + MainCount + '_' + SubTempCount + '" style="display: none;">' + EventAction + '</td>';
            recRow += '<td id="tdDtlId_' + MainCount + '_' + SubTempCount + '" style="display: none;">' + UPDTransDtlId + '</td>';
            recRow += '<td id="tdAdditional_' + MainCount + '_' + SubTempCount + '" style="display: none;"></td>';
            recRow += '<td id="tdPrdctAvailable_' + MainCount + '_' + SubTempCount + '" style="display: none;">0</td>';
            recRow += '<td id="tdPrdctName_' + MainCount + '_' + SubTempCount + '" style="display: none;"></td>';
            recRow += '<td id="tdPrintSt_' + MainCount + '_' + SubTempCount + '" style="display: none;">0</td>';
            recRow += '<td id="tdLastRowCount_' + MainCount + '_' + SubTempCount + '" style="display: none;">' + SubTempCount + '</td>';

            recRow += '</tr>';

            if (CurrRow == 0) {
                jQuery('#TableProductWithoutTaxBody_' + MainCount).append(recRow);
            }
            else {
                $('#RowTableProductWithoutTax_' + MainCount + '_' + CurrRow).after(recRow);
            }

            $("[data-toggle=popover]").popover();

            if (PrdctWinSts == "1") {
                document.getElementById("RowTableProductWithoutTax_" + MainCount + "_" + SubTempCount).style.backgroundColor = "rgb(156, 230, 186)";
            }
            if (EventAction == "UPD" || EventAction == "COPY") {
                if (OpenCatOrNot == "true") {
                    document.getElementById("txtCategoryName_" + MainCount + "_" + SubTempCount).value = UPDProductCat;
                    $("#tdAddCtgry" + MainCount + "_" + SubTempCount).hide();
                    $("#tdCtgry" + MainCount + "_" + SubTempCount).show();
                }
              
                document.getElementById("tdAdditional_" + MainCount + "_" + SubTempCount).innerHTML = UPDAddDesc;
                document.getElementById("tdPrdctAvailable_" + MainCount + "_" + SubTempCount).innerHTML = UPDStockStatus;
                document.getElementById("tdPrdctName_" + MainCount + "_" + SubTempCount).innerHTML = StockName;
                document.getElementById("tdPrintSt_" + MainCount + "_" + SubTempCount).innerHTML = UPDPrintSts;

                document.getElementById("txtItem_" + MainCount + "_" + SubTempCount).value = UPDProductName;
                document.getElementById("txtUnit_" + MainCount + "_" + SubTempCount).value = UPDUnitName;
                document.getElementById("txtQuantity_" + MainCount + "_" + SubTempCount).value = UPDQuantity;
                document.getElementById("txtCprice_" + MainCount + "_" + SubTempCount).value = UPDCostPrice;
                document.getElementById("txtHike_" + MainCount + "_" + SubTempCount).value = UPDHike;
                document.getElementById("txtRate_" + MainCount + "_" + SubTempCount).value = UPDRate;
                document.getElementById("txtDiscAmnt_" + MainCount + "_" + SubTempCount).value = UPDDiscountAmnt;
                document.getElementById("txtAmnt_" + MainCount + "_" + SubTempCount).value = UPDAmount;

                ValueCheck('txtQuantity_', MainCount, SubTempCount);
                ValueCheck('txtCprice_', MainCount, SubTempCount);
                ValueCheck('txtHike_', MainCount, SubTempCount);
                ValueCheck('txtRate_', MainCount, SubTempCount);
                ValueCheck('txtDiscAmnt_', MainCount, SubTempCount);
                ValueCheck('txtAmnt_', MainCount, SubTempCount);

                Calculate_CPorSP_FromHiddenField("txtCprice_", MainCount);
                Calculate_CPorSP_FromHiddenField("txtHike_", MainCount);
                Calculate_CPorSP_FromHiddenField("txtRate_", MainCount);
                Calculate_CPorSP_FromHiddenField("txtDiscAmnt_", MainCount);
                Calculate_CPorSP_FromHiddenField("txtAmnt_", MainCount); 

                document.getElementById("tdAdditional_" + MainCount + "_" + SubTempCount).innerHTML = UPDAddDesc;
                document.getElementById("tdPrdctAvailable_" + MainCount + "_" + SubTempCount).innerHTML = UPDStockStatus;
                document.getElementById("tdPrdctName_" + MainCount + "_" + SubTempCount).innerHTML = StockName;
                document.getElementById("tdPrintSt_" + MainCount + "_" + SubTempCount).innerHTML = UPDPrintSts;

            } else {
               
                if (CsvOrNot == "CSV") {
                    if (OpenCatOrNot == "true") {
                        document.getElementById("txtCategoryName_" + MainCount + "_" + SubTempCount).value = UPDProductCat;
                        $("#tdAddCtgry" + MainCount + "_" + SubTempCount).hide();
                        $("#tdCtgry" + MainCount + "_" + SubTempCount).show();
                    }
                    document.getElementById("tdAdditional_" + MainCount + "_" + SubTempCount).innerHTML = UPDAddDesc;
                    document.getElementById("tdPrdctAvailable_" + MainCount + "_" + SubTempCount).innerHTML = UPDStockStatus;
                    document.getElementById("tdPrdctName_" + MainCount + "_" + SubTempCount).innerHTML = StockName;
                    document.getElementById("tdPrintSt_" + MainCount + "_" + SubTempCount).innerHTML = UPDPrintSts;
                
                    document.getElementById("txtItem_" + MainCount + "_" + SubTempCount).value = UPDProductName;
                    document.getElementById("txtUnit_" + MainCount + "_" + SubTempCount).value = UPDUnitName;
                    document.getElementById("txtQuantity_" + MainCount + "_" + SubTempCount).value = UPDQuantity;
                    document.getElementById("txtCprice_" + MainCount + "_" + SubTempCount).value = UPDCostPrice;

                    if (UPDCostPrice != 0) {
                        document.getElementById("txtHike_" + MainCount + "_" + SubTempCount).value = UPDHike;
                    } else {
                        document.getElementById("txtHike_" + MainCount + "_" + SubTempCount).value = 0;
                    }

                    if (UPDRate != 0) {
                        document.getElementById("txtRate_" + MainCount + "_" + SubTempCount).value = UPDRate;
                    } else {
                        document.getElementById("txtRate_" + MainCount + "_" + SubTempCount).value = 1;
                    }

                    document.getElementById("txtDiscAmnt_" + MainCount + "_" + SubTempCount).value = UPDDiscountAmnt;
                    document.getElementById("txtAmnt_" + MainCount + "_" + SubTempCount).value = UPDAmount;
     
                    ValueCheck('txtQuantity_', MainCount, SubTempCount);
                    ValueCheck('txtCprice_', MainCount, SubTempCount);
                    ValueCheck('txtHike_', MainCount, SubTempCount);
                    ValueCheck('txtRate_', MainCount, SubTempCount);
                    ValueCheck('txtDiscAmnt_', MainCount, SubTempCount);
                    ValueCheck('txtAmnt_', MainCount, SubTempCount);
                

                    Calculate_CPorSP_FromHiddenField("txtCprice_", MainCount);
                    Calculate_CPorSP_FromHiddenField("txtHike_", MainCount);
                    Calculate_CPorSP_FromHiddenField("txtRate_", MainCount);
                    Calculate_CPorSP_FromHiddenField("txtDiscAmnt_", MainCount);
                    Calculate_CPorSP_FromHiddenField("txtAmnt_", MainCount);
                   
                }

            }

            $("[data-toggle=popover]").on('shown.bs.popover', function () {

                var Id= document.getElementById("<%=hiddenAdditionalId.ClientID%>").value;

                var ItemName = document.getElementById("txtItem_" + Id).value.trim();
                document.getElementById("pModal"+ Id).innerHTML =  ItemName;

                if(document.getElementById("tdPrintSt_" + Id).innerHTML != "" && document.getElementById("tdPrintSt_" + Id).innerHTML == 1){
                    if (document.getElementById("tdPrintSt_" + Id).innerHTML == 1) {
                        document.getElementById("ChkPrinted" + Id).checked = true;
                    }
                    else {
                        document.getElementById("ChkPrinted" + Id).checked = false;
                    }
                }
                if (document.getElementById("tdAdditional_" + Id).innerHTML != "") {
                    document.getElementById("txtareaMoreInfo" + Id).value = document.getElementById("tdAdditional_" + Id).innerHTML;
                }
               
                if (document.getElementById("tdPrdctAvailable_" + Id).innerHTML != "") {
                    if (document.getElementById("tdPrdctAvailable_" + Id).innerHTML == 0) {
                        document.getElementById("cbxPrdctStock"+ Id).value = "";
                        document.getElementById("tdStockPrdctId" + Id).innerHTML=0;
                        document.getElementById("tdStockPrdctName" + Id).innerHTML="";
                    }
                    else {
                        document.getElementById("cbxPrdctStock"+ Id).value = document.getElementById("tdPrdctName_" + Id).innerHTML;
                        document.getElementById("tdStockPrdctId" + Id).innerHTML=document.getElementById("tdPrdctAvailable_" + Id).innerHTML;
                        document.getElementById("tdStockPrdctName" + Id).innerHTML=document.getElementById("tdPrdctName_" + Id).innerHTML;
                    }
                }

                document.getElementById("txtareaMoreInfo" + Id).focus();
            });

        }

        function AddMoreProductRowWithTax(MainCount, CurrRow, EventAction, UPDProductName, UPDUnitName, UPDQuantity, UPDCostPrice, UPDHike, UPDRate, UPDTaxPer, UPDTaxAmnt, UPDDiscountAmnt, UPDAmount, UPDAddDesc, UPDStockStatus, UPDTransDtlId, UPDPrintSts, UPDProductCat, OpenCatOrNot, CsvOrNot, PrdctWinSts,StockName) {
       
            SubTempCount++;

            var num = 0;
            var nMoney = 0;
            var nUnit = 0;
            var nCommonPerc = 0;
            var nTaxPerc = 0;

            var QtyMaxLen = 8;
            var HikeMaxLen = 6;
            var DiscPercMaxLen = 6;
            var TaxPercMaxLen = 12;
            var TaxAmntMaxLen = 23;
            var DiscAmntMaxLen = 23;
            var AmntMaxLen = 23;
            var CPriceMaxLen = 23;
            var RateMaxLen = 23;


            var FloatingValueMoney = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
            if (FloatingValueMoney != "") {

                nMoney = num.toFixed(FloatingValueMoney);
                var fVal = parseInt(FloatingValueMoney) + 1;

                var AmntMaxLen = 13 - fVal;
            }
            var FloatingValueUnit = document.getElementById("<%=hiddenFloatingValueUnit.ClientID%>").value;
            if (FloatingValueUnit != "") {

                nUnit = num.toFixed(FloatingValueUnit);

            }
            var FloatingValueCmmnPercentage = document.getElementById("<%=hiddenFloatingValueCommonPercentage.ClientID%>").value;
            if (FloatingValueCmmnPercentage != "") {

                nCommonPerc = num.toFixed(FloatingValueCmmnPercentage);
                nTaxPerc = num.toFixed(FloatingValueCmmnPercentage);
            }
           
            var recRow = '';

            recRow += '<tr id="RowTableHeadWithTax_' + MainCount + '_' + SubTempCount + '" class="ClassHead">';
            recRow += '<td id="tdAddCtgry' + MainCount + '_' + SubTempCount + '" style="width:50px!important;text-align: left; display:block;" class="dis_td1" colspan="11">';
            recRow += '<button id="btnCatgryAdd_' + MainCount + '_' + SubTempCount + '" class="btn act_btn bn11 bt_cat_g1" title="Add Category" onclick="return AddcategoryRow(' + MainCount + ',' + SubTempCount + ',1,\'true\');"><i class="opp_ico_img_ptp"><img src="/Images/New%20Images/images/icons/opp/add_cat.png"></i></button>';
            recRow += '</td>';
            recRow += '<td id="tdCtgry' + MainCount + '_' + SubTempCount + '" style="text-align: left; display: none;" class="dis_td2" colspan="11">';
            recRow += '<button id="btnCatgryRmv_' + MainCount + '_' + SubTempCount + '" class="btn act_btn bn3 flt_l bt_cat_g2" title="Remove Category" onclick="return RemovecategoryRow(' + MainCount + ',' + SubTempCount + ',1,\'true\');"><i class="fa fa-close"></i></button>';
            recRow += '<input type="text" id="txtCategoryName_' + MainCount + '_' + SubTempCount + '" class="form-control fg2_inp2 tr_l"  onkeypress="return isTag(\'txtCategoryName_' + MainCount + '_' + SubTempCount + '\',event);" onblur="ReplaceTag(\'txtCategoryName_' + MainCount + '_' + SubTempCount + '\',event);" maxlength="100" placeholder="Category Name" autofocus="" style="width: 30%!important;margin-left: 10px;height: 34px!important;">';
            recRow += '</td>';
            recRow += '</tr>';

            recRow += '<tr id="RowTableProductWithTax_' + MainCount + '_' + SubTempCount + '" class="ClassBody">';

            recRow += '<td style="display:none;">';
            recRow += '<div class="up" onclick="return MoveRowUp(\'RowTableProductWithTax_' + MainCount + '_' + SubTempCount + '\');" ><input type="image" src="/Images/Icons/row_up.png" /></div>';
            recRow += '<div class="down" onclick="return MoveRowDown(\'RowTableProductWithTax_' + MainCount + '_' + SubTempCount + '\');" ><input type="image" src="/Images/Icons/row_down.png" /></div>';
            recRow += '<div id="DivSerial_' + MainCount + '_' + SubTempCount + '" >' + SubTempCount + '</div>';
            recRow += '</td>';

            recRow += '<td> ';
            recRow += '<input id="txtItem_' + MainCount + '_' + SubTempCount + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" onkeypress="return isTagName(\'txtUnit_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurQtnItem(' + MainCount + ',' + SubTempCount + ')" onfocus="FocusQtnItem(' + MainCount + ',' + SubTempCount + ')"  type="text" maxlength="100" />';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input id="txtUnit_' + MainCount + '_' + SubTempCount + '" class="form-control fg2_inp2 tr_c" placeholder="Unit" type="text" onkeypress="return isTagName(\'txtQuantity_' + MainCount + '_' + SubTempCount + '\', event)"   onblur="return BlurQtnUnit(' + MainCount + ',' + SubTempCount + ')" onfocus="FocusQtnUnit(' + MainCount + ',' + SubTempCount + ')"  maxlength="50" />';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input id="txtQuantity_' + MainCount + '_' + SubTempCount + '" class="form-control fg2_inp2 tr_c" value="' + nUnit + '" type="text" maxlength="' + QtyMaxLen + '" onkeydown="return isNumber(\'txtQuantity_' + MainCount + '_' + SubTempCount + '\',\'txtCprice_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurValue(\'txtQuantity_\',' + MainCount + ',' + SubTempCount + ')" onfocus="FocusValue(\'txtQuantity_\',' + MainCount + ',' + SubTempCount + ')" />';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input id="txtCprice_' + MainCount + '_' + SubTempCount + '" value="' + nMoney + '" class="form-control fg2_inp2 tr_r" type="text"  maxlength="' + CPriceMaxLen + '" onkeydown="return isNumber(\'txtCprice_' + MainCount + '_' + SubTempCount + '\',\'txtHike_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurValue(\'txtCprice_\',' + MainCount + ',' + SubTempCount + ')" onfocus="FocusValue(\'txtCprice_\',' + MainCount + ',' + SubTempCount + ')" />';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input id="txtHike_' + MainCount + '_' + SubTempCount + '" value="' + nCommonPerc + '" class="form-control fg2_inp2 tr_r"  type="text" maxlength="' + HikeMaxLen + '" onkeydown="return isNumber(\'txtHike_' + MainCount + '_' + SubTempCount + '\',\'txtRate_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurValue(\'txtHike_\',' + MainCount + ',' + SubTempCount + ')" onfocus="FocusValue(\'txtHike_\',' + MainCount + ',' + SubTempCount + ')" />';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input id="txtRate_' + MainCount + '_' + SubTempCount + '" value="' + nMoney + '" class="form-control fg2_inp2 tr_r" type="text"   maxlength="' + RateMaxLen + '" onkeydown="return isNumber(\'txtRate_' + MainCount + '_' + SubTempCount + '\',\'txtTaxPerc_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurValue(\'txtRate_\',' + MainCount + ',' + SubTempCount + ')" onfocus="FocusValue(\'txtRate_\',' + MainCount + ',' + SubTempCount + ')" />';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<div class="input-group ing1">';
            recRow += '<input id="txtTaxPerc_' + MainCount + '_' + SubTempCount + '" class="form-control fg2_inp2 tr_r inp1_pro" value="' + nTaxPerc + '" type="text" onkeydown="return isNumber(\'txtTaxPerc_' + MainCount + '_' + SubTempCount + '\',\'txtDiscAmnt_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurValue(\'txtTaxPerc_\',' + MainCount + ',' + SubTempCount + ')" onfocus="FocusValue(\'txtTaxPerc_\',' + MainCount + ',' + SubTempCount + ')" maxlength="' + TaxPercMaxLen + '" />';
            recRow += '<span class="input-group-addon cur1 spn1_pro pur_pe">%</span>';
            recRow += '</div>';
            recRow += '<div class="input-group ing2">';
            recRow += '<input id="txtTaxAmnt_' + MainCount + '_' + SubTempCount + '" class="form-control fg2_inp2 tr_r inp1_pro" value="' + nMoney + '" type="text" maxlength="' + TaxAmntMaxLen + '"/>';
            recRow += '<span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=hiddenCurrencyCode.ClientID%>").value + '</span>';
            recRow += '</div>';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input id="txtDiscAmnt_' + MainCount + '_' + SubTempCount + '"  value="' + nMoney + '" class="form-control fg2_inp2 tr_r" type="text"  maxlength="' + DiscAmntMaxLen + '" onkeydown="return isNumber(\'txtDiscAmnt_' + MainCount + '_' + SubTempCount + '\',\'imgMoreInfo_' + MainCount + '_' + SubTempCount + '\', event)" onblur="return BlurValue(\'txtDiscAmnt_\',' + MainCount + ',' + SubTempCount + ')" onfocus="FocusValue(\'txtDiscAmnt_\',' + MainCount + ',' + SubTempCount + ')"/>';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<input disabled id="txtAmnt_' + MainCount + '_' + SubTempCount + '" value="' + nMoney + '" class="form-control fg2_inp2 tr_r" type="text" maxlength="' + AmntMaxLen + '" />';
            recRow += '</td>';

            recRow += '<td class="td1">';
            recRow += '<div class="btn_stl1">';
            recRow += '<a id="imgMoreInfo_' + MainCount + '_' + SubTempCount + '" class="btn act_btn bn4" title="Additional Information" onclick="SaveId(' + MainCount + ',' + SubTempCount + ');return false;" data-toggle="popover" data-placement="top" data-html="true" data-height="400" data-width="400" ';
            
            recRow+='data-content=" ';
            recRow+='<label class=\'form1 mar_bo\'><p id=\'pModal' + MainCount + '_' + SubTempCount + '\'></p></label>';
            recRow+='<p id=\'pRowCount\' style=\'display:none;\'>' + MainCount + '_' + SubTempCount + '</p>';
            recRow+='<label>Additional Information</label>';
            recRow+='<div class=\'check1 flt_r\' style=\'width:auto;float:right;margin:auto;text-align:right;margin-right:8px;\'>';
            recRow+='<div>';
            recRow+='<label class=\'switch tr_r flt_r\' title=\'Include Additional Information in PDF\'>';
            recRow+='<input type=\'checkbox\' id=\'ChkPrinted' + MainCount + '_' + SubTempCount + '\' checked=\'false\' onkeypress=\'return isTag(event);\' />';
            recRow+='<span class=\'slider_tog round\'></span>';
            recRow+='</div>';
            recRow+='</div>';
            recRow+='<textarea id=\'txtareaMoreInfo' + MainCount + '_' + SubTempCount + '\' cols=\'46\' rows=\'2\' placeholder=\'Description\' onkeypress=\'return isTagQuotesBackSlash(txtareaMoreInfo' + MainCount + '_' + SubTempCount + ', event);\' onkeydown=\'textCounter(txtareaMoreInfo' + MainCount + '_' + SubTempCount + ',3500);\' onkeyup=\'textCounter(txtareaMoreInfo' + MainCount + '_' + SubTempCount + ',3500);\' style=\'resize: none;\'></textarea><br />';
            recRow+='<label>Stock Availability:</label><br />';
            recRow+='<input type=\'text\' id=\'cbxPrdctStock' + MainCount + '_' + SubTempCount + '\' value=\''+StockName+'\' onkeypress=\'return LoadStockPrdct(' + MainCount + ',' + SubTempCount + ',event);\' onkeydown=\'return LoadStockPrdct(' + MainCount + ',' + SubTempCount + ',event);\' /><br/>';
            recRow+='<div class=\'clearfix\'></div><div class=\'devider mar_top6\'></div>';
            recRow+='<button id=\'btnSaveAdditional\' class=\'btn btn-success flt_r\' onclick=\'return SaveAdditional();\'>Save</button>';
            recRow+='<div id=\'tdStockPrdctId' + MainCount + '_' + SubTempCount + '\' style=\'display: none;\'>'+UPDStockStatus+'</div>';
            recRow+='<div id=\'tdStockPrdctName' + MainCount + '_' + SubTempCount + '\' style=\'display: none;\'>'+StockName+'</div>';
            recRow+=' "><i class="fa fa-sticky-note-o"></i></a>';
            recRow += '<button id="imgAddRow_' + MainCount + '_' + SubTempCount + '" class="btn act_btn bn2" title="Add"  onclick="return CheckaddMoreRowsIndividual(' + MainCount + ',' + SubTempCount + ');"><i class="fa fa-plus-circle"></i></button>';
            recRow += '<button class="btn act_btn bn3" title="Delete" onclick = "return CheckDelEachRowProduct(' + MainCount + ',' + SubTempCount + ');"><i class="fa fa-trash"></i></button>';
            recRow += '</div>';
            recRow += '</td>';

            recRow += '<td id="tdSave_' + MainCount + '_' + SubTempCount + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt_' + MainCount + '_' + SubTempCount + '" style="display: none;">' + EventAction + '</td>';
            recRow += '<td id="tdDtlId_' + MainCount + '_' + SubTempCount + '" style="display: none;">' + UPDTransDtlId + '</td>';
            recRow += '<td id="tdAdditional_' + MainCount + '_' + SubTempCount + '" style="display: none;"></td>';
            recRow += '<td id="tdPrdctAvailable_' + MainCount + '_' + SubTempCount + '" style="display: none;">0</td>';
            recRow += '<td id="tdPrdctName_' + MainCount + '_' + SubTempCount + '" style="display: none;"></td>';
            recRow += '<td id="tdPrintSt_' + MainCount + '_' + SubTempCount + '" style="display: none;">0</td>';
            recRow += '<td id="tdLastRowCount_' + MainCount + '_' + SubTempCount + '" style="display: none;">' + SubTempCount + '</td>';

            recRow += '</tr>';

            if (CurrRow == 0) {
                jQuery('#TableProductWithTaxBody_' + MainCount).append(recRow);
            }
            else {
                $('#RowTableProductWithTax_' + MainCount + '_' + CurrRow).after(recRow);
            }

            $("[data-toggle=popover]").popover();

            if (PrdctWinSts == "1") {
                document.getElementById("RowTableProductWithTax_" + MainCount + "_" + SubTempCount).style.backgroundColor = "rgb(156, 230, 186)";
            }
            if (EventAction == "UPD" || EventAction == "COPY") {

                if (OpenCatOrNot == "true") {
                    document.getElementById("txtCategoryName_" + MainCount + "_" + SubTempCount).value = UPDProductCat;
                    $("#tdAddCtgry" + MainCount + "_" + SubTempCount).hide();
                    $("#tdCtgry" + MainCount + "_" + SubTempCount).show();
                }
                document.getElementById("tdAdditional_" + MainCount + "_" + SubTempCount).innerHTML = UPDAddDesc;
                document.getElementById("tdPrdctAvailable_" + MainCount + "_" + SubTempCount).innerHTML = UPDStockStatus;
                document.getElementById("tdPrdctName_" + MainCount + "_" + SubTempCount).innerHTML = StockName;
                document.getElementById("tdPrintSt_" + MainCount + "_" + SubTempCount).innerHTML = UPDPrintSts;
                document.getElementById("txtItem_" + MainCount + "_" + SubTempCount).value = UPDProductName;

                document.getElementById("txtUnit_" + MainCount + "_" + SubTempCount).value = UPDUnitName;
                document.getElementById("txtQuantity_" + MainCount + "_" + SubTempCount).value = UPDQuantity;
                document.getElementById("txtCprice_" + MainCount + "_" + SubTempCount).value = UPDCostPrice;
                document.getElementById("txtHike_" + MainCount + "_" + SubTempCount).value = UPDHike;
                document.getElementById("txtRate_" + MainCount + "_" + SubTempCount).value = UPDRate;
                document.getElementById("txtDiscAmnt_" + MainCount + "_" + SubTempCount).value = UPDDiscountAmnt;
                document.getElementById("txtAmnt_" + MainCount + "_" + SubTempCount).value = UPDAmount;

                //document.getElementById("txtTaxAmnt_" + MainCount + "_" + SubTempCount).value = UPDTaxAmnt;
                document.getElementById("txtTaxPerc_" + MainCount + "_" + SubTempCount).value = UPDTaxPer;

                ValueCheck('txtQuantity_', MainCount, SubTempCount);
                ValueCheck('txtCprice_', MainCount, SubTempCount);
                ValueCheck('txtHike_', MainCount, SubTempCount);
                ValueCheck('txtRate_', MainCount, SubTempCount);
                ValueCheck('txtDiscAmnt_', MainCount, SubTempCount);
                ValueCheck('txtTaxAmnt_', MainCount, SubTempCount);
                ValueCheck('txtTaxPerc_', MainCount, SubTempCount);
                ValueCheck('txtAmnt_', MainCount, SubTempCount);

                Calculate_CPorSP_FromHiddenField("txtCprice_", MainCount);
                Calculate_CPorSP_FromHiddenField("txtHike_", MainCount);
                Calculate_CPorSP_FromHiddenField("txtRate_", MainCount);
                Calculate_CPorSP_FromHiddenField("txtDiscAmnt_", MainCount);

                Calculate_CPorSP_FromHiddenField("txtTaxAmnt_", MainCount);
                Calculate_CPorSP_FromHiddenField("txtTaxPerc_", MainCount);
                Calculate_CPorSP_FromHiddenField("txtAmnt_", MainCount);

                document.getElementById("tdAdditional_" + MainCount + "_" + SubTempCount).innerHTML = UPDAddDesc;
                document.getElementById("tdPrdctAvailable_" + MainCount + "_" + SubTempCount).innerHTML = UPDStockStatus;
                document.getElementById("tdPrdctName_" + MainCount + "_" + SubTempCount).innerHTML = StockName;
                document.getElementById("tdPrintSt_" + MainCount + "_" + SubTempCount).innerHTML = UPDPrintSts;

            }
            else {
                if (CsvOrNot == "CSV") {
                    if (OpenCatOrNot == "true") {
                        document.getElementById("txtCategoryName_" + MainCount + "_" + SubTempCount).value = UPDProductCat;
                        $("#tdAddCtgry" + MainCount + "_" + SubTempCount).hide();
                        $("#tdCtgry" + MainCount + "_" + SubTempCount).show();
                    }

                    document.getElementById("tdAdditional_" + MainCount + "_" + SubTempCount).innerHTML = UPDAddDesc;
                    document.getElementById("tdPrdctAvailable_" + MainCount + "_" + SubTempCount).innerHTML = UPDStockStatus;
                    document.getElementById("tdPrdctName_" + MainCount + "_" + SubTempCount).innerHTML = StockName;
                    document.getElementById("tdPrintSt_" + MainCount + "_" + SubTempCount).innerHTML = UPDPrintSts;

                    document.getElementById("txtItem_" + MainCount + "_" + SubTempCount).value = UPDProductName;
                    document.getElementById("txtUnit_" + MainCount + "_" + SubTempCount).value = UPDUnitName;
                    document.getElementById("txtQuantity_" + MainCount + "_" + SubTempCount).value = UPDQuantity;
                    document.getElementById("txtCprice_" + MainCount + "_" + SubTempCount).value = UPDCostPrice;
                    if (UPDCostPrice != 0) {
                        document.getElementById("txtHike_" + MainCount + "_" + SubTempCount).value = UPDHike;
                    } else {
                        document.getElementById("txtHike_" + MainCount + "_" + SubTempCount).value = 0;
                    }
                  
                    if (UPDRate != 0) {
                        document.getElementById("txtRate_" + MainCount + "_" + SubTempCount).value = UPDRate;
                    } else {
                        document.getElementById("txtRate_" + MainCount + "_" + SubTempCount).value = 1;
                    }
                    document.getElementById("txtDiscAmnt_" + MainCount + "_" + SubTempCount).value = UPDDiscountAmnt;
                    document.getElementById("txtAmnt_" + MainCount + "_" + SubTempCount).value = UPDAmount;

                    // document.getElementById("txtTaxAmnt_" + MainCount + "_" + SubTempCount).value = UPDTaxAmnt;
                    document.getElementById("txtTaxPerc_" + MainCount + "_" + SubTempCount).value = UPDTaxPer;
                    ValueCheck('txtQuantity_', MainCount, SubTempCount);
                    ValueCheck('txtCprice_', MainCount, SubTempCount);
                    ValueCheck('txtHike_', MainCount, SubTempCount);
                    ValueCheck('txtRate_', MainCount, SubTempCount);
                    ValueCheck('txtDiscAmnt_', MainCount, SubTempCount);
                    ValueCheck('txtTaxAmnt_', MainCount, SubTempCount);
                    ValueCheck('txtTaxPerc_', MainCount, SubTempCount);
                    ValueCheck('txtAmnt_', MainCount, SubTempCount);




                    Calculate_CPorSP_FromHiddenField("txtCprice_", MainCount);
                    Calculate_CPorSP_FromHiddenField("txtHike_", MainCount);
                    Calculate_CPorSP_FromHiddenField("txtRate_", MainCount);
                    Calculate_CPorSP_FromHiddenField("txtDiscAmnt_", MainCount);

                    Calculate_CPorSP_FromHiddenField("txtTaxAmnt_", MainCount);
                    Calculate_CPorSP_FromHiddenField("txtTaxPerc_", MainCount);
                    Calculate_CPorSP_FromHiddenField("txtAmnt_", MainCount);
                    
                    
                }
            }

            $("[data-toggle=popover]").on('shown.bs.popover', function () {

                var Id= document.getElementById("<%=hiddenAdditionalId.ClientID%>").value;

                var ItemName = document.getElementById("txtItem_" + Id).value.trim();
                document.getElementById("pModal"+ Id).innerHTML =  ItemName;

                if(document.getElementById("tdPrintSt_" + Id).innerHTML != "" && document.getElementById("tdPrintSt_" + Id).innerHTML == 1){
                    if (document.getElementById("tdPrintSt_" + Id).innerHTML == 1) {
                        document.getElementById("ChkPrinted" + Id).checked = true;
                    }
                    else {
                        document.getElementById("ChkPrinted" + Id).checked = false;
                    }
                }
                if (document.getElementById("tdAdditional_" + Id).innerHTML != "") {
                    document.getElementById("txtareaMoreInfo" + Id).value = document.getElementById("tdAdditional_" + Id).innerHTML;
                }
               
                if (document.getElementById("tdPrdctAvailable_" + Id).innerHTML != "") {
                    if (document.getElementById("tdPrdctAvailable_" + Id).innerHTML == 0) {
                        document.getElementById("cbxPrdctStock"+ Id).value = "";
                        document.getElementById("tdStockPrdctId" + Id).innerHTML=0;
                        document.getElementById("tdStockPrdctName" + Id).innerHTML="";
                    }
                    else {
                        document.getElementById("cbxPrdctStock"+ Id).value = document.getElementById("tdPrdctName_" + Id).innerHTML;
                        document.getElementById("tdStockPrdctId" + Id).innerHTML=document.getElementById("tdPrdctAvailable_" + Id).innerHTML;
                        document.getElementById("tdStockPrdctName" + Id).innerHTML=document.getElementById("tdPrdctName_" + Id).innerHTML;
                    }
                }

                document.getElementById("txtareaMoreInfo" + Id).focus();
            });
        }

        function SaveId(x,y){
            document.getElementById("<%=hiddenAdditionalId.ClientID%>").value=x+"_"+y;
        }


        var subTotalCount = 0;
        function AddSubTotal(CntMain, CntSub, LastOrNot) {

            subTotalCount++;
            var recRow = '';

            recRow += '<tr id="SubTotalRowId_' + CntMain + '_' + subTotalCount + '" class="bg1" style="background-color:#b9ddf7!important;">';
            
            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                
                recRow += '<th colspan="3" class="tr_l" style="font-weight: 600;">Sub Total</th>';
                recRow += '<th id="tdSubTotalCPriceWithTax_' + CntMain + '_' + subTotalCount + '" class="tr_r"></th>';
                recRow += '<th id="tdSubTotalMarginWithTax_' + CntMain + '_' + subTotalCount + '" class="tr_r"></th>';
                recRow += '<th id="tdSubTotalSPriceWithTax_' + CntMain + '_' + subTotalCount + '" class="tr_r"></th>';
                recRow += '<th id="tdSubTotalBlankWithTax_' + CntMain + '_' + subTotalCount + '" class="tr_r" style="display:none;"></th>';
                recRow += '<th id="tdSubTotalTaxAmntWithTax_' + CntMain + '_' + subTotalCount + '" class="tr_r" style="font-weight: 600;"></th>';
                recRow += '<th id="tdSubTotalDiscAmntWithTax_' + CntMain + '_' + subTotalCount + '" class="tr_r" style="font-weight: 600;"></th>';
                recRow += '<th id="tdSubTotalAmountWithTax_' + CntMain + '_' + subTotalCount + '" class="tr_r" style="font-weight: 600;"></th>';
                recRow += '<th></th>';
                recRow += '</tr>';
            }
            else {

                recRow += '<th colspan="3" class="tr_l" style="font-weight: 600;">Sub Total</th>';
                recRow += '<th id="tdSubTotalCPriceWithoutTax_' + CntMain + '_' + subTotalCount + '" class="tr_r"></th>';
                recRow += '<th id="tdSubTotalMarginWithoutTax_' + CntMain + '_' + subTotalCount + '" class="tr_r"></th>';
                recRow += '<th id="tdSubTotalSPriceWithoutTax_' + CntMain + '_' + subTotalCount + '" class="tr_r"></th>';
                recRow += '<th id="tdSubTotalDiscAmntWithoutTax_' + CntMain + '_' + subTotalCount + '" class="tr_r" style="font-weight: 600;">0.00</th>';
                recRow += '<th id="tdSubTotalAmountWithoutTax_' + CntMain + '_' + subTotalCount + '" class="tr_r" style="font-weight: 600;">0.00</th>';
                recRow += '<th></th>';
                recRow += '</tr>';
            }
            recRow += ' </tr>';

            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                if (LastOrNot == 0) {
                    $('#RowTableHeadWithTax_' + CntMain + '_' + CntSub).prev().after(recRow);//check
                }
                else {
                    $('#TableProductWithTaxBody_' + CntMain).append(recRow);
                }
            }
            else {
                if (LastOrNot == 0) {
                    $('#RowTableHeadWithoutTax_' + CntMain + '_' + CntSub).prev().after(recRow);
                }
                else {
                    $('#TableProductWithoutTaxBody_' + CntMain).append(recRow);
                }
            }

            CalculateSubtotalOfCat(CntMain);

        }

        function CalculateSubtotalOfCat(CntMain) {
            var Total = 0;

            var Table = "";

            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                Table = $('#TableProductWithTaxBody_' + CntMain + ' tr').not(".ClassHead");
            }
            else {

                Table = $('#TableProductWithoutTaxBody_' + CntMain + ' tr').not(".ClassHead");
            }
            var MarginCount = 0;

            var SubTotalCost = 0;
            var SubTotalMargin = 0;
            var SubTotalSell = 0;
            var SubTotalDisc = 0;
            var SubTotalAmnt = 0;
            var SubTotalTax = 0;

            $(Table).each(function () {
                var RowId = $(this).attr('id');
                var SplitId = RowId.split('_');
                var RowIdName = SplitId[0];
                var MainCount = SplitId[1];
                var SubCount = SplitId[2];

                if (RowIdName == "RowTableProductWithoutTax" || RowIdName == "RowTableProductWithTax") {
                    if (RowIdName == "RowTableProductWithTax") {
                        var SubTotalTaxThis = document.getElementById("txtTaxAmnt_" + MainCount + "_" + SubCount).value;
                        SubTotalTax = SubTotalTax + parseFloat(SubTotalTaxThis);
                    }
                    MarginCount++;
                    var SubTotalCostthis = document.getElementById("txtCprice_" + MainCount + "_" + SubCount).value;
                    SubTotalCost = SubTotalCost + parseFloat(SubTotalCostthis);

                    var SubTotalMarginthis = 0;
                    if (document.getElementById("txtHike_" + MainCount + "_" + SubCount).value != "") {
                        SubTotalMarginthis = document.getElementById("txtHike_" + MainCount + "_" + SubCount).value;
                    }
                    SubTotalMargin = SubTotalMargin + parseFloat(SubTotalMarginthis);

                    var SubTotalSellthis = document.getElementById("txtRate_" + MainCount + "_" + SubCount).value;
                    SubTotalSell = SubTotalSell + parseFloat(SubTotalSellthis);

                    var SubTotalDiscthis = document.getElementById("txtDiscAmnt_" + MainCount + "_" + SubCount).value;
                    SubTotalDisc = SubTotalDisc + parseFloat(SubTotalDiscthis);

                    var SubTotalAmntthis = document.getElementById("txtAmnt_" + MainCount + "_" + SubCount).value;
                    SubTotalAmnt = SubTotalAmnt + parseFloat(SubTotalAmntthis);

                } else if (RowIdName == "SubTotalRowId") {

                    var FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;

                    if (FloatingValue != "") {

                        SubTotalCost = SubTotalCost.toFixed(FloatingValue);
                        SubTotalMargin = SubTotalMargin / MarginCount;
                        SubTotalMargin = SubTotalMargin.toFixed(FloatingValue);
                        SubTotalSell = SubTotalSell.toFixed(FloatingValue);
                        SubTotalDisc = SubTotalDisc.toFixed(FloatingValue);
                        SubTotalAmnt = SubTotalAmnt.toFixed(FloatingValue);
                        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                            SubTotalTax = SubTotalTax.toFixed(FloatingValue);
                        }
                        MarginCount = 0;
                    }
                    if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                        document.getElementById("tdSubTotalTaxAmntWithTax_" + MainCount + "_" + SubCount).innerText = SubTotalTax;
                        document.getElementById("tdSubTotalCPriceWithTax_" + MainCount + "_" + SubCount).innerText = SubTotalCost;
                        document.getElementById("tdSubTotalMarginWithTax_" + MainCount + "_" + SubCount).innerText = SubTotalMargin;
                        document.getElementById("tdSubTotalSPriceWithTax_" + MainCount + "_" + SubCount).innerText = SubTotalSell;
                        document.getElementById("tdSubTotalDiscAmntWithTax_" + MainCount + "_" + SubCount).innerText = SubTotalDisc;
                        document.getElementById("tdSubTotalAmountWithTax_" + MainCount + "_" + SubCount).innerText = SubTotalAmnt;
                    } else {
                        document.getElementById("tdSubTotalCPriceWithoutTax_" + MainCount + "_" + SubCount).innerText = SubTotalCost;
                        document.getElementById("tdSubTotalMarginWithoutTax_" + MainCount + "_" + SubCount).innerText = SubTotalMargin;
                        document.getElementById("tdSubTotalSPriceWithoutTax_" + MainCount + "_" + SubCount).innerText = SubTotalSell;
                        document.getElementById("tdSubTotalDiscAmntWithoutTax_" + MainCount + "_" + SubCount).innerText = SubTotalDisc;
                        document.getElementById("tdSubTotalAmountWithoutTax_" + MainCount + "_" + SubCount).innerText = SubTotalAmnt;
                    }


                    SubTotalCost = 0;
                    SubTotalMargin = 0;
                    SubTotalSell = 0;
                    SubTotalDisc = 0;
                    SubTotalAmnt = 0;
                    SubTotalTax = 0;

                }


            });

    }


    function MoveRowUp(rowid) {
        var row = $('#' + rowid);
        var splitId = rowid.split('_');
        var MainId = splitId[1];
        var SubId = splitId[2];
 
        var firstRowId = "";
        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
            firstRowId = $('#TableProductWithTaxBody_' + MainId + ' tr.ClassBody:first').attr('id');
        } else {
            firstRowId = $('#TableProductWithoutTaxBody_' + MainId + ' tr.ClassBody:first').attr('id');
        }
        if (firstRowId == rowid) {
            return false;
        }


        if (document.getElementById("txtItem_" + MainId + "_" + SubId).value == ""){
            return false;
        }

        if ($("#tdCtgry" + MainId + "_" + SubId).is(":visible") == true) {
           
            var NextRowId = row.next().attr('id');
         
            if (NextRowId != undefined) {
                splitNextRowId = NextRowId.split('_');

                if (splitNextRowId[0] == "RowTableProductWithTax" || splitNextRowId[0] == "RowTableProductWithoutTax") {
                    RemovecategoryRow(MainId, SubId, 0, "false");
                    AddcategoryRow(splitNextRowId[1], splitNextRowId[2], 0, "false");
                    document.getElementById("txtCategoryName_" + splitNextRowId[1] + "_" + splitNextRowId[2]).value = document.getElementById("txtCategoryName_" + MainId + "_" + SubId).value;
                    document.getElementById("txtCategoryName_" + MainId + "_" + SubId).value = "";

                }
                else {
                 
                    if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                        RemovecategoryRow(MainId, SubId, 0, "false");
                        AddMoreProductRowWithTax(MainId, SubId, "INS", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "false","other","0","");

                        var Newrow = $('#RowTableProductWithTax_' + MainId + '_' + SubId).next().attr('id');

                        splitNewrow = Newrow.split('_');
                        AddcategoryRow(splitNewrow[1], splitNewrow[2], 0, "false");

                        document.getElementById("txtCategoryName_" + splitNewrow[1] + "_" + splitNewrow[2]).value = document.getElementById("txtCategoryName_" + MainId + "_" + SubId).value;
                        document.getElementById("txtCategoryName_" + MainId + "_" + SubId).value = "";


                    }
                    else {
                        RemovecategoryRow(MainId, SubId, 0, "false");
                        AddMoreProductRow(MainId, SubId, "INS", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "false","other","0","");

                        var Newrow = $('#RowTableProductWithoutTax_' + MainId + '_' + SubId).next().attr('id');
                        splitNewrow = Newrow.split('_');
                        AddcategoryRow(splitNewrow[1], splitNewrow[2], 0, "false");
                        document.getElementById("txtCategoryName_" + splitNewrow[1] + "_" + splitNewrow[2]).value = document.getElementById("txtCategoryName_" + MainId + "_" + SubId).value;
                        document.getElementById("txtCategoryName_" + MainId + "_" + SubId).value = "";
                    }

                }
            }

        } else {
         
            var PrevRowId = row.prev().attr('id');
            if (PrevRowId != undefined) {
                splitPrevRowId = PrevRowId.split('_');
                if (splitPrevRowId[0] == "RowTableProductWithTax" || splitPrevRowId[0] == "RowTableProductWithoutTax") {

                        if ($("#tdCtgry" + splitPrevRowId[1] + "_" + splitPrevRowId[2]).is(":visible") == true) {

                        RemovecategoryRow(splitPrevRowId[1], splitPrevRowId[2], 0, "false");
                        AddcategoryRow(MainId, SubId, 0, "false");
                        document.getElementById("txtCategoryName_" + MainId + "_" + SubId).value = document.getElementById("txtCategoryName_" + splitPrevRowId[1] + "_" + splitPrevRowId[2]).value;
                        document.getElementById("txtCategoryName_" + splitPrevRowId[1] + "_" + splitPrevRowId[2]).value = "";


                    }
                }
            }
        }
      
        row.insertBefore(row.prev());
        CommonFactorsChecking(MainId);
        AddButtonVisible(MainId);
        ReNumberTable(MainId)

        CalculateSubtotalOfCat(MainId);
        return false;
    }



        function MoveRowDown(rowid) {

            var splitId = rowid.split('_');
            var MainId = splitId[1];
            var SubId = splitId[2];

            if (document.getElementById("txtItem_" + MainId + "_" + SubId).value == "") {
                return false;
            }

            var row = $('#' + rowid);
            var rowNextId = row.next().attr('id');
            if (rowNextId != undefined) {
                var splitrowNextId = rowNextId.split('_');
                if (splitrowNextId[0] == "RowTableProductWithTax" || splitrowNextId[0] == "RowTableProductWithoutTax") {
                    row.insertAfter(row.next());
                    if ($("#tdCtgry" + MainId + "_" + SubId).is(":visible") == true){
                        RemovecategoryRow(MainId, SubId, 0, "false");
                        AddcategoryRow(splitrowNextId[1], splitrowNextId[2], 0, "false");
                        document.getElementById("txtCategoryName_" + splitrowNextId[1] + "_" + splitrowNextId[2]).value = document.getElementById("txtCategoryName_" + MainId + "_" + SubId).value;
                        document.getElementById("txtCategoryName_" + MainId + "_" + SubId).value = "";

                    }

                }
                else {
                    if ($("#tdCtgry" + MainId + "_" + SubId).is(":visible") == true){
                        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                            AddMoreProductRowWithTax(MainId, SubId, "INS", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "false", "other","0","");
                        }
                        else {
                            AddMoreProductRow(MainId, SubId, "INS", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "false", "other","0","");
                        }


                        var rownewNextId = row.next().attr('id');
                        var splitrownewNextId = rownewNextId.split('_');
                        row.insertAfter(row.next().next().next());

                        RemovecategoryRow(MainId, SubId, 0, "false");
                        AddcategoryRow(splitrownewNextId[1], splitrownewNextId[2], 0, "false");
                        document.getElementById("txtCategoryName_" + splitrownewNextId[1] + "_" + splitrownewNextId[2]).value = document.getElementById("txtCategoryName_" + MainId + "_" + SubId).value;
                        document.getElementById("txtCategoryName_" + MainId + "_" + SubId).value = "";

                    } else {


                        row.insertAfter(row.next().next());
                    }
                }
            }

            CommonFactorsChecking(MainId);

            AddButtonVisible(MainId);
            ReNumberTable(MainId)

            CalculateSubtotalOfCat(MainId);
            return false;
    
        }

        function CommonFactorsChecking(Cntmain) {
            var Table = "";
            var RowIdLast = "";
            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                Table = $('#TableProductWithTaxBody_' + Cntmain + ' tr.ClassBody');
                RowIdLast = $('#TableProductWithTaxBody_' + Cntmain + ' tr.ClassBody:last').attr('id');
            }
            else {

                Table = $('#TableProductWithoutTaxBody_' + Cntmain + ' tr.ClassBody');
                RowIdLast = $('#TableProductWithoutTaxBody_' + Cntmain + ' tr.ClassBody:last').attr('id');
            }
            var subCount = 0;
            var SubTotalRowId = "";
            $(Table).each(function () {
                var RowId = $(this).attr('id');
                var SplitId = RowId.split('_');
                var RowIdName = SplitId[0];
                if (RowIdName == "SubTotalRowId") {
                    subCount++;
                    SubTotalRowId = RowId;
                }
            });

            if (subCount > 1) {

                var firstRowId = "";
                var firstRow = "";
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    firstRowId = $('#TableProductWithTaxBody_' + Cntmain + ' tr.ClassBody:first').attr('id');
                    firstRow = $('#TableProductWithTaxBody_' + Cntmain + ' tr.ClassBody:first');
                } else {
                    firstRowId = $('#TableProductWithoutTaxBody_' + Cntmain + ' tr.ClassBody:first').attr('id');
                    firstRow = $('#TableProductWithoutTaxBody_' + Cntmain + ' tr.ClassBody:first');
                }

                var splitfirstRowId = firstRowId.split('_');

                if (splitfirstRowId[0] == "RowTableProductWithTax" || splitfirstRowId[0] == "RowTableProductWithoutTax") {
                    if ($("#tdCtgry" + splitfirstRowId[1] + "_" + splitfirstRowId[2]).is(":visible") == false){
                        AddcategoryRow(splitfirstRowId[1], splitfirstRowId[2], 0, "false");
                    }
                } else {
                    firstRow.remove();
                }
            }
            else if (subCount == 1) {
                var firstRowId = "";
                var firstRow = "";
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    firstRowId = $('#TableProductWithTaxBody_' + Cntmain + ' tr.ClassBody:first').attr('id');
                    firstRow = $('#TableProductWithTaxBody_' + Cntmain + ' tr.ClassBody:first');
                } else {
                    firstRowId = $('#TableProductWithoutTaxBody_' + Cntmain + ' tr.ClassBody:first').attr('id');
                    firstRow = $('#TableProductWithoutTaxBody_' + Cntmain + ' tr.ClassBody:first');
                }
                var splitfirstRowId = firstRowId.split('_');

                if (splitfirstRowId[0] == "RowTableProductWithTax" || splitfirstRowId[0] == "RowTableProductWithoutTax") {
                    if ($("#tdCtgry" + splitfirstRowId[1] + "_" + splitfirstRowId[2]).is(":visible") == false){
                        $('#' + SubTotalRowId).remove();
                    }
                }
            }
        }

        function removeMainTemplate(count) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure want to remove?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var rowCount = $('#tableTotalProductContainer tr').length;

                    if (rowCount > 9) {
                        if (document.getElementById("tdPrdctGrpEvt_" + count).innerHTML == "UPD") {
                            var detailId = document.getElementById("<%=hiddenDeletedPrdctGrps.ClientID%>").value;
                            detailId = detailId + "," + document.getElementById("tdPrdctGrpId_" + count).innerHTML;
                            document.getElementById("<%=hiddenDeletedPrdctGrps.ClientID%>").value = detailId;
                        }
                        $('#tableTotalProductContainer tr#TemplateRowId_' + count).remove();
                        $('#tableTotalProductContainer tr#ErrorMesgRowId_' + count).remove();
                    }
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }

        function CalculateCheckingRate(Cntmain, CntSub) {
      
            var TotalRate = 0;
            var QtyTextBoxVal = document.getElementById("txtQuantity_" + Cntmain + "_" + CntSub).value;
            var CostPriceTextBoxVal = document.getElementById("txtCprice_" + Cntmain + "_" + CntSub).value;
            var HkeTextBoxVal = document.getElementById("txtHike_" + Cntmain + "_" + CntSub).value;
            var RateTextBoxVal = document.getElementById("txtRate_" + Cntmain + "_" + CntSub).value;
            if (parseFloat(CostPriceTextBoxVal) == 0) {
                document.getElementById("txtHike_" + Cntmain + "_" + CntSub).value = "";
            }
            //new blank
            if (document.getElementById("txtHike_" + Cntmain + "_" + CntSub).value != "") {
                TotalRate = parseFloat(CostPriceTextBoxVal) + ((parseFloat(CostPriceTextBoxVal) * parseFloat(HkeTextBoxVal)) / 100);

            }

            var numRateTxtBox = parseFloat(RateTextBoxVal);
            var nRateTxtBox = parseFloat(RateTextBoxVal);
            var numTotalRate = parseFloat(TotalRate);
            var nTotalRate = parseFloat(TotalRate);
            // for floatting number adjustment from corp global
            var FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
            if (FloatingValue != "") {
                nRateTxtBox = numRateTxtBox.toFixed(FloatingValue);
                nTotalRate = numTotalRate.toFixed(FloatingValue);
            }
         
            if (nRateTxtBox != nTotalRate) {
                document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value = "ImportErrors";
                document.getElementById("txtRate_" + Cntmain + "_" + CntSub).style.backgroundColor = "rgb(255, 236, 91)";
                document.getElementById("txtRate_" + Cntmain + "_" + CntSub).value = nTotalRate; 
            }
        }

        function AddcategoryRow(Cntmain, CntSub, NeedSub, CommnFactNeed) {

            $("#tdAddCtgry" + Cntmain + "_" + CntSub).hide();
            $("#tdCtgry"+ Cntmain + "_" + CntSub).show();

            if (NeedSub == 1) {
                var PrevRow = ""
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    PrevRow = $('#RowTableHeadWithTax_' + Cntmain + '_' + CntSub).prev().attr('id');
                }
                else {
                    PrevRow = $('#RowTableHeadWithoutTax_' + Cntmain + '_' + CntSub).prev().attr('id');
                }
                if (PrevRow != undefined) {
                    var SplitPrev = PrevRow.split('_');
                    if (SplitPrev[0] != "SubTotalRowId") {
                        AddSubTotal(Cntmain, CntSub, 0);
                    }
                }
            }
            var Table = "";
            var RowIdLast = "";
            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                Table = $('#TableProductWithTaxBody_' + Cntmain + ' tr.ClassBody');
                RowIdLast = $('#TableProductWithTaxBody_' + Cntmain + ' tr.ClassBody:last').attr('id');
            }
            else {

                Table = $('#TableProductWithoutTaxBody_' + Cntmain + ' tr.ClassBody');
                RowIdLast = $('#TableProductWithoutTaxBody_' + Cntmain + ' tr.ClassBody:last').attr('id');
            }
            var subCount = 0;
            $(Table).each(function () {
                var RowId = $(this).attr('id');
                var SplitId = RowId.split('_');
                var RowIdName = SplitId[0];
                if (RowIdName == "SubTotalRowId") {
                    subCount++;
                }
            });

            var SplitRowlast = RowIdLast.split('_');
            if (subCount > 0 && SplitRowlast[0] != "SubTotalRowId") {

                AddSubTotal(Cntmain, CntSub, 1);
            }
            if (CommnFactNeed == "true") {
                CommonFactorsChecking(Cntmain);
            }
            AddButtonVisible(Cntmain);
            ReNumberTable(Cntmain)
            document.getElementById("txtCategoryName_" + Cntmain + "_" + CntSub).focus();
            return false;
        }
        function RemovecategoryRow(Cntmain, CntSub, RemvOrnot, commonFact) {

            $("#tdAddCtgry" + Cntmain + "_" + CntSub).show();
            $("#tdCtgry"+ Cntmain + "_" + CntSub).hide();

            var PrevRow = ""
            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                PrevRow = $('#RowTableHeadWithTax_' + Cntmain + '_' + CntSub).prev().attr('id');
                if (PrevRow != undefined) {
                    var SplitPrev = PrevRow.split('_');
                    if (SplitPrev[0] == "SubTotalRowId") {

                        if (RemvOrnot == 1) {
                            $('#TableProductWithTaxBody_' + Cntmain + ' tr#' + PrevRow).remove();
                        }
                    }
                }
            }
            else {
                PrevRow = $('#RowTableHeadWithoutTax_' + Cntmain + '_' + CntSub).prev().attr('id');
                if (PrevRow != undefined) {
                    var SplitPrev = PrevRow.split('_');
                    if (SplitPrev[0] == "SubTotalRowId") {
                        if (RemvOrnot == 1) {
                            $('#TableProductWithoutTaxBody_' + Cntmain + ' tr#' + PrevRow).remove();
                        }
                    }
                }
            }

            AddButtonVisible(Cntmain);
            ReNumberTable(Cntmain);
            if (commonFact == "true") {
                CommonFactorsChecking(Cntmain);
            }
            CalculateSubtotalOfCat(Cntmain);
            return false;
        }

        var $noconfli = jQuery.noConflict();
        function CheckaddMoreRowsIndividual(CurrRowMain, CurRowSub) {
            var LastId = "";
            if (CheckAllRowFieldAndHighlight(CurrRowMain, CurRowSub) == true) {
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    AddMoreProductRowWithTax(CurrRowMain, CurRowSub, "INS", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "false", "other","0","");
                }
                else {
                    AddMoreProductRow(CurrRowMain, CurRowSub, "INS", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "false", "other","0","");
                }
                AddButtonVisible(CurrRowMain);
            }
            return false;
        }

        function AddButtonVisible(CntMain) {
            ReNumberTable(CntMain);
            var Table = "";
            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                Table = $('#TableProductWithTaxBody_' + CntMain + ' tr').not(".ClassHead");
            }
            else {
                Table = $('#TableProductWithoutTaxBody_' + CntMain + ' tr').not(".ClassHead");
            }
            var count = 0;
            $(Table.get().reverse()).each(function () {
                var RowId = $(this).attr('id');
                var SplitId = RowId.split('_');
                var RowIdName = SplitId[0];
                var MainCount = SplitId[1];
                var SubCount = SplitId[2];
                if (RowIdName == "RowTableProductWithTax" || RowIdName == "RowTableProductWithoutTax") {
                    var AddButton = $noconfli("#imgAddRow_" + MainCount + "_" + SubCount);
                    if (AddButton.length) {
                        document.getElementById("imgAddRow_" + MainCount + "_" + SubCount).disabled = true;
                        document.getElementById("imgAddRow_" + MainCount + "_" + SubCount).style.opacity = "0.3";
                        if (count == 0) {
                            document.getElementById("imgAddRow_" + MainCount + "_" + SubCount).disabled = false;
                            document.getElementById("imgAddRow_" + MainCount + "_" + SubCount).style.opacity = "1";
                            count++;
                        }
                    }
                }
                if (RowIdName == "SubTotalRowId") {
                    var SubCategory = $noconfli("#SubTotalRowId_" + MainCount + "_" + SubCount);
                    if (SubCategory.length) {
                        count = 0;
                    }
                }
            });
        }


        // checks every field in row
        function CheckAllRowFieldAndHighlight(CntMain, CntSub) {
            ret = true;
                var Item = document.getElementById("txtItem_" + CntMain + "_" + CntSub).value;
                if (Item == "") {
                    document.getElementById("txtItem_" + CntMain + "_" + CntSub).style.borderColor = "Red";
                    document.getElementById("txtItem_" + CntMain + "_" + CntSub).focus();
                    $noCon("#txtItem_" + CntMain + "_" + CntSub).select();
                    return false;

                }

                var Unit = document.getElementById("txtUnit_" + CntMain + "_" + CntSub).value;
                if (Unit == "") {
                    document.getElementById("txtUnit_" + CntMain + "_" + CntSub).style.borderColor = "Red";
                    document.getElementById("txtUnit_" + CntMain + "_" + CntSub).focus();
                    $noCon("#txtUnit_" + CntMain + "_" + CntSub).select();
                    return false;

                }


            if (ValueCheck('txtQuantity_', CntMain, CntSub) == false) {

                document.getElementById("txtQuantity_" + CntMain + "_" + CntSub).style.borderColor = "Red";
                document.getElementById("txtQuantity_" + CntMain + "_" + CntSub).focus();
                $noCon("#txtQuantity_" + CntMain + "_" + CntSub).select();
                return false;
            }

            if (document.getElementById("txtCprice_" + CntMain + "_" + CntSub).value == "") {

                return false;
            }
            if (document.getElementById("txtHike_" + CntMain + "_" + CntSub).value == "") {

            }

            if (ValueCheck('txtRate_', CntMain, CntSub) == false) {
                document.getElementById("txtRate_" + CntMain + "_" + CntSub).style.borderColor = "Red";
                document.getElementById("txtRate_" + CntMain + "_" + CntSub).focus();
                $noCon("#txtRate_" + CntMain + "_" + CntSub).select();
                return false;
            }
            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {

            }

            if (document.getElementById("txtDiscAmnt_" + CntMain + "_" + CntSub).value == "") {
                document.getElementById("txtDiscAmnt_" + CntMain + "_" + CntSub).style.borderColor = "Red";
                document.getElementById("txtDiscAmnt_" + CntMain + "_" + CntSub).focus();
                $noCon("#txtDiscAmnt_" + CntMain + "_" + CntSub).select();
                return false;
            }

            if (document.getElementById("txtAmnt_" + CntMain + "_" + CntSub).value == "") {
                document.getElementById("txtAmnt_" + CntMain + "_" + CntSub).style.borderColor = "Red";
                document.getElementById("txtAmnt_" + CntMain + "_" + CntSub).focus();
                $noCon("#txtAmnt_" + CntMain + "_" + CntSub).select();
                return false;
            }

            return true;
        }

        // For adjust to decimal point also used for checking
        function ValueCheck(obj, CntMain, CntSub) {
            var ret = true;
            var Val = document.getElementById(obj + CntMain + "_" + CntSub).value;
            if (Val == "") {
                ret = false;
            }
            else {
                var amt = parseFloat(Val);
                if (amt == 0) {
                    ret = false;
                }
            }
            if (ret == false) {
                var num = 0;
                var n = 0;
                // for floatting number adjustment from corp global
                var FloatingValue = 0;
                if (obj == 'txtQuantity_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueUnit.ClientID%>").value;
                }
                else if (obj == 'txtCprice_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }
                else if (obj == 'txtHike_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueCommonPercentage.ClientID%>").value;
                }
                else if (obj == 'txtRate_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }
                else if (obj == 'txtTaxPerc_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueTaxPercentage.ClientID%>").value;
                }
                else if (obj == 'txtTaxAmnt_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }
                else if (obj == 'txtDiscAmnt_') {

                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }
                else if (obj == 'txtAmnt_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }

                if (FloatingValue != "") {

                    n = num.toFixed(FloatingValue);
                }

                document.getElementById(obj + CntMain + "_" + CntSub).value = n;

            }
            else {

                var amt = parseFloat(Val);
                var num = amt;
                var n = Val;
                // for floatting number adjustment from corp global
                var FloatingValue = 0;
                if (obj == 'txtQuantity_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueUnit.ClientID%>").value;

                }
                else if (obj == 'txtCprice_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }
                else if (obj == 'txtHike_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueCommonPercentage.ClientID%>").value;
                }
                else if (obj == 'txtRate_') {

                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }
                else if (obj == 'txtTaxPerc_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueTaxPercentage.ClientID%>").value;
                }
                else if (obj == 'txtTaxAmnt_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }
                else if (obj == 'txtDiscAmnt_') {

                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }
                else if (obj == 'txtAmnt_') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }

                if (FloatingValue != "") {

                    n = num.toFixed(FloatingValue);
                }
                document.getElementById(obj + CntMain + "_" + CntSub).value = n;
            }

            return ret;

        }
        function FocusQtnItem(CntMain, CntSub, event) {
            //for viewing over label
            var offset = $noCon("#txtItem_" + CntMain + "_" + CntSub).offset();
            var posY = 0;
            var posX = 0;
            posY = offset.top - 12.5;

            posX = offset.left - 680;

            posX = 7.6;
            document.getElementById("divBlink").innerHTML = "Product"
            var d = document.getElementById('divBlink');
            d.style.position = "absolute";
            d.style.left = posX + '%';
            d.style.top = posY + 'px';
            //to close moadal because by tab we can acess below thing of modal

            document.getElementById("<%=hiddenQtnItemIdFocus.ClientID%>").value = "";
            var QtnItemName = document.getElementById("txtItem_" + CntMain + "_" + CntSub).value;
            document.getElementById("<%=hiddenQtnItemIdFocus.ClientID%>").value = QtnItemName;

        }


        function BlurQtnItem(CntMain, CntSub) {

            var QtnItemWithoutReplace = document.getElementById("txtItem_" + CntMain + "_" + CntSub).value;

            var replaceText1 = QtnItemWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");
            document.getElementById("txtItem_" + CntMain + "_" + CntSub).value = replaceText5.trim();

            var QtnItemName = document.getElementById("txtItem_" + CntMain + "_" + CntSub).value;

                if (QtnItemName != "") {

                    document.getElementById('divErrorNotification_' + CntMain).style.visibility = "hidden";
                    document.getElementById('lblErrorNotification_' + CntMain).innerHTML = "";

                    document.getElementById("txtItem_" + CntMain + "_" + CntSub).style.borderColor = "";

                    //if (CheckAllRowField(CntMain, CntSub) == false) {
                    //    return false;
                    //}

                }
               
            CalculateSubtotalOfCat(CntMain);
            CalculateTotalAmountFromHiddenField(CntMain);
        }


        function CalculateTotalAmountFromHiddenField(CntMain) {
            var Total = 0;

            var Table = "";

            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                Table = $('#TableProductWithTaxBody_' + CntMain + ' tr.ClassBody');
            }
            else {

                Table = $('#TableProductWithoutTaxBody_' + CntMain + ' tr.ClassBody');
            }

            $(Table).each(function () {
                var RowId = $(this).attr('id');
                var SplitId = RowId.split('_');
                var RowId = SplitId[0];
                var MainCount = SplitId[1];
                var SubCount = SplitId[2];
                if (RowId == "RowTableProductWithoutTax" || RowId == "RowTableProductWithTax") {
                    var Itemselect = $noconfli("#txtAmnt_" + CntMain + "_" + SubCount);
                    if (Itemselect.length) {
                        TotalEach = Itemselect.val();
                        Total = Total + parseFloat(TotalEach);
                    }
                }
            });

            var num = Total;
            var n = Total;
            // for floatting number adjustment from corp global
            var FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
            if (FloatingValue != "") {
                n = num.toFixed(FloatingValue);
            }
            document.getElementById("txtGrossAmount_" + CntMain).value = n;
            var TotalGrossAmt = document.getElementById("txtGrossAmount_" + CntMain).value;
            var TotalDiscVal = 0;
            var TotalNetcVal = TotalGrossAmt;

            var ZeroVal=0;
            var FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
            var FloatingValuePrcnt = document.getElementById("<%=hiddenFloatingValueCommonPercentage.ClientID%>").value;

            if (document.getElementById("txtDiscntValAmnt_" + CntMain).value!="0" && document.getElementById("txtDiscntValAmnt_" + CntMain).value!=ZeroVal.toFixed(FloatingValue) && document.getElementById("txtDiscntValAmnt_" + CntMain).value!="") {
                TotalDiscVal = document.getElementById("txtDiscntValAmnt_" + CntMain).value;
                document.getElementById('txtTotalDiscntAmnt_' + CntMain).value = TotalDiscVal;

                DiscValueCheck('txtTotalDiscntAmnt_', CntMain);
                TotalNetcVal = TotalGrossAmt - TotalDiscVal;
            }

            if (document.getElementById("txtDiscntValPerc_" + CntMain).value!="0" && document.getElementById("txtDiscntValPerc_" + CntMain).value!=ZeroVal.toFixed(FloatingValuePrcnt) && document.getElementById("txtDiscntValPerc_" + CntMain).value!="") {
                TotalDiscVal = document.getElementById("txtDiscntValPerc_" + CntMain).value;
                TotalNetcVal = TotalGrossAmt - ((TotalGrossAmt * TotalDiscVal) / 100);
                document.getElementById('txtTotalDiscntAmnt_' + CntMain).value = ((TotalGrossAmt * TotalDiscVal) / 100);

                DiscValueCheck('txtTotalDiscntAmnt_', CntMain);
            }

            var numNet = TotalNetcVal;
            var nNet = TotalNetcVal;

            if (FloatingValue != "") {
                nNet = parseFloat(numNet).toFixed(FloatingValue);
            }
            document.getElementById("txtNetAmount_" + CntMain).value = nNet;

        }
        function FocusValue(obj, CntMain, CntSub) {

            //for viewing over label
            var offset = $noCon("#" + obj + CntMain + "_" + CntSub).offset();

            var posY = 0;
            var posX = 0;
            posY = offset.top - 12.5;

            if (obj == "txtQuantity_") {
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    posX = offset.left - 416.8;
                }
                else {
                    posX = offset.left - 513.1;
                }
                document.getElementById("divBlink").innerHTML = "Quantity";
            }
            else if (obj == "txtHike_") {
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    posX = offset.left - 560.783;
                }
                else {
                    posX = offset.left - 677.6;
                }
                document.getElementById("divBlink").innerHTML = "Margin %";
            }
            else if (obj == "txtRate_") {
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    posX = offset.left - 622.85;
                }
                else {
                    posX = offset.left - 752.1;
                }
                document.getElementById("divBlink").innerHTML = "Selling Price";
            }
            else if (obj == "txtTaxPerc_") {
                posX = offset.left - 701.2;
                document.getElementById("divBlink").innerHTML = "Tax %";
            }
            else if (obj == "txtCprice_") {
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    posX = offset.left - 439.1;
                }
                else {
                    posX = offset.left - 585.2;
                }
                document.getElementById("divBlink").innerHTML = "Cost Price";
            }

            else if (obj == "txtDiscAmnt_") {
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                    posX = offset.left - 890;
                }
                else {
                    posX = offset.left - 856.0;
                }

                document.getElementById("divBlink").innerHTML = "Disc Amt";
            }

            var d = document.getElementById('divBlink');
            d.style.position = "absolute";
            d.style.left = posX + '%';
            d.style.top = posY + 'px';

            document.getElementById("<%=hiddenValueFocus.ClientID%>").value = "";
            var Amt = document.getElementById(obj + CntMain + "_" + CntSub).value;
            document.getElementById("<%=hiddenValueFocus.ClientID%>").value = Amt;

        }
        function BlurValue(obj, CntMain, CntSub) {
            var AmntVal = document.getElementById(obj + CntMain + "_" + CntSub).value;

            if (isNaN(AmntVal) == true) {
                //NaN not a number ,if number return false ,If not a number return true
                AmntVal = "";

            }
            document.getElementById(obj + CntMain + "_" + CntSub).value = AmntVal;

            var Amnt = document.getElementById(obj + CntMain + "_" + CntSub).value;

            if (obj == 'txtHike_' && Amnt == "")
            { }
            else
            {

                ValueCheck(obj, CntMain, CntSub);
            }

            if (CheckItemSelected(CntMain, CntSub) == true) {

                document.getElementById(obj + CntMain + "_" + CntSub).style.borderColor = "";
                if (obj == 'txtRate_') {
                    var hiddenAmntVal = document.getElementById("<%=hiddenValueFocus.ClientID%>").value;
                    if (Amnt != hiddenAmntVal) {

                        document.getElementById("txtRate_" + CntMain + "_" + CntSub).style.color = "rgb(87, 149, 0)";
                        CalculateHikeFromRate(CntMain, CntSub);
                    }
                }
                //for changing row color if entered by rate and undo it if hike typed
                if (obj == 'txtHike_') {
                    var hiddenAmntVal = document.getElementById("<%=hiddenValueFocus.ClientID%>").value;
                    if (Amnt != hiddenAmntVal) {
                        document.getElementById("txtRate_" + CntMain + "_" + CntSub).style.color = "";

                    }
                }

                //for calculation of total amaount
                CalculateRowTotalDefault(CntMain, CntSub);

                CalculateSubtotalOfCat(CntMain);
                CalculateTotalAmountFromHiddenField(CntMain);
                //if (CheckAllRowField(CntMain, CntSub) == false) {

                //    return false;

                //}

            }
            else {

                document.getElementById(obj + CntMain + "_" + CntSub).value = 0;
                ValueCheck(obj, CntMain, CntSub);

            }

        }
        function CalculateHikeFromRate(CntMain, CntSub) {

            var HikeTotal = 0;
            var QtyTextBoxVal = document.getElementById("txtQuantity_" + CntMain + "_" + CntSub).value;
            var CostPriceTextBoxVal = document.getElementById("txtCprice_" + CntMain + "_" + CntSub).value;
            var RateTextBoxVal = document.getElementById("txtRate_" + CntMain + "_" + CntSub).value;
            if (parseFloat(CostPriceTextBoxVal) != 0) {
                HikeTotal = (((parseFloat(RateTextBoxVal) - parseFloat(CostPriceTextBoxVal)) * 100) / parseFloat(CostPriceTextBoxVal));

            }
           // document.getElementById("txtHike_" + CntMain + "_" + CntSub).value = HikeTotal;
            //  ValueCheck('txtHike_', CntMain, CntSub);
            document.getElementById("txtHike_" + CntMain + "_" + CntSub).value = "";

        }
        function CalculateRowTotalDefault(CntMain, CntSub) {
            var Total = 0;
            var TotalRate = 0;
            var QtyTextBoxVal = document.getElementById("txtQuantity_" + CntMain + "_" + CntSub).value;
            var CostPriceTextBoxVal = document.getElementById("txtCprice_" + CntMain + "_" + CntSub).value;
            var HkeTextBoxVal = document.getElementById("txtHike_" + CntMain + "_" + CntSub).value;
            var TaxAmntVal = 0;
            var TaxPercTextBoxVal = 0;
            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                TaxPercTextBoxVal = document.getElementById("txtTaxPerc_" + CntMain + "_" + CntSub).value;
            }

            var DiscAmntTextBoxVal = document.getElementById("txtDiscAmnt_" + CntMain + "_" + CntSub).value;
            //new blank
            if (document.getElementById("txtHike_" + CntMain + "_" + CntSub).value != "") {
                TotalRate = parseFloat(CostPriceTextBoxVal) + ((parseFloat(CostPriceTextBoxVal) * parseFloat(HkeTextBoxVal)) / 100);

                if (TotalRate == 0) {
                    TotalRate = 1;
                }
            }
            else {

                TotalRate = document.getElementById("txtRate_" + CntMain + "_" + CntSub).value;
            }
            //-----
            Total = (parseFloat(QtyTextBoxVal) * TotalRate);
            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {



                TaxAmntVal = ((Total * parseFloat(TaxPercTextBoxVal)) / 100);
                Total = Total + TaxAmntVal;
                document.getElementById("txtTaxAmnt_" + CntMain + "_" + CntSub).value = TaxAmntVal;
                ValueCheck('txtTaxAmnt_', CntMain, CntSub);
                Calculate_CPorSP_FromHiddenField("txtTaxAmnt_", CntMain);
            }
          
            Total = Total - parseFloat(DiscAmntTextBoxVal);
            document.getElementById("txtRate_" + CntMain + "_" + CntSub).value = TotalRate;
            ValueCheck('txtRate_', CntMain, CntSub);
            document.getElementById("txtAmnt_" + CntMain + "_" + CntSub).value = Total;
            ValueCheck('txtAmnt_', CntMain, CntSub);

            Calculate_CPorSP_FromHiddenField("txtCprice_", CntMain);
            Calculate_CPorSP_FromHiddenField("txtDiscAmnt_", CntMain);
            Calculate_CPorSP_FromHiddenField("txtHike_", CntMain);
            Calculate_CPorSP_FromHiddenField("txtRate_", CntMain);
            Calculate_CPorSP_FromHiddenField("txtAmnt_", CntMain);

        }



        function BlurQtnUnit(CntMain, CntSub) {

            if (CheckItemSelected(CntMain, CntSub) == true) {
                var QtnUnitId = document.getElementById("selectorUnit_" + CntMain + "_" + CntSub).value;
                if (QtnUnitId != "--Select Unit--") {
                    document.getElementById("selectorUnit_" + CntMain + "_" + CntSub).style.borderColor = "";
                    //for saving
                    CalculateSubtotalOfCat(CntMain);
                    CalculateTotalAmountFromHiddenField(CntMain);
                    //if (CheckAllRowField(CntMain, CntSub) == false) {

                    //    return false;

                    //}
                }

            }
            else {

                var desiredValue = '--Select Unit--';
                var el = document.getElementById(('selectorUnit_' + CntMain + "_" + CntSub));
                for (var i = 0; i < el.options.length; i++) {
                    if (el.options[i].value == desiredValue) {
                        el.selectedIndex = i;
                        break;
                    }
                }

            }


        }

        function BlurQtnUnit(CntMain, CntSub) {

            var QtnUnitWithoutReplace = document.getElementById("txtUnit_" + CntMain + "_" + CntSub).value;

            var replaceText1 = QtnUnitWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");
            document.getElementById("txtUnit_" + CntMain + "_" + CntSub).value = replaceText5.trim();


            if (CheckItemSelected(CntMain, CntSub) == true) {
                var QtnUnitId = document.getElementById("txtUnit_" + CntMain + "_" + CntSub).value;
                if (QtnUnitId != "") {
                    document.getElementById("txtUnit_" + CntMain + "_" + CntSub).style.borderColor = "";

                    //if (CheckAllRowField(CntMain, CntSub) == false) {

                    //    return false;

                    //}

                }

            }
            else {
                document.getElementById("txtUnit_" + CntMain + "_" + CntSub).value = '';
            }
        }
        

        function FocusQtnUnit(CntMain, CntSub) {

            //for viewing over label
            var offset = $noCon("#txtUnit_" + CntMain + "_" + CntSub).offset();
            var posY = 0;
            var posX = 0;
            posY = offset.top - 12.5;
            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                posX = offset.left - 314;
            }
            else {
                posX = offset.left - 377.7;

            }
            document.getElementById("divBlink").innerHTML = "Unit"
            var d = document.getElementById('divBlink');
            d.style.position = "absolute";
            d.style.left = posX + '%';
            d.style.top = posY + 'px';

            document.getElementById("<%=hiddenQtnUnitIdFocus.ClientID%>").value = "";
            var QtnUnitId = document.getElementById("txtUnit_" + CntMain + "_" + CntSub).value;
            document.getElementById("<%=hiddenQtnUnitIdFocus.ClientID%>").value = QtnUnitId;
        }

        //function to check if Item is selected or not
        function CheckItemSelected(CntMain, CntSub) {
            var ret = true;
            var Item = document.getElementById("txtItem_" + CntMain + "_" + CntSub).value;
            if (Item == "") {
                ret = false;

            }

            if (ret == false) {
                document.getElementById("txtItem_" + CntMain + "_" + CntSub).style.borderColor = "Red";
                $noCon("#txtItem_" + CntMain + "_" + CntSub).select();
            }

            return ret;
        }

        function Calculate_CPorSP_FromHiddenField(obj, CntMain) {
            var Total = 0;

            var Table = "";

            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                Table = $('#TableProductWithTaxBody_' + CntMain + ' tr.ClassBody');
            }
            else {

                Table = $('#TableProductWithoutTaxBody_' + CntMain + ' tr.ClassBody');
            }
            var MCOUNT=0;
            $(Table).each(function () {
                var RowId = $(this).attr('id');
                var SplitId = RowId.split('_');
                var RowIdName = SplitId[0];
                var MainCount = SplitId[1];
                var SubCount = SplitId[2];
                if (RowIdName == "RowTableProductWithTax" || RowIdName == "RowTableProductWithoutTax") {
                    var Itemselect = $noconfli("#txtCprice_" + MainCount + "_" + SubCount);
                    if (Itemselect.length) {
                        if (obj == "txtCprice_") {

                            var Itemselect = $noconfli("#txtCprice_" + MainCount + "_" + SubCount);
                        }
                        if (obj == "txtRate_") {

                            var Itemselect = $noconfli("#txtRate_" + MainCount + "_" + SubCount);
                        }
                        if (obj == "txtTaxAmnt_") {

                            var Itemselect = $noconfli("#txtTaxAmnt_" + MainCount + "_" + SubCount);
                        }
                        if (obj == "txtDiscAmnt_") {

                            var Itemselect = $noconfli("#txtDiscAmnt_" + MainCount + "_" + SubCount);
                        }
                        if (obj == "txtAmnt_") {

                            var Itemselect = $noconfli("#txtAmnt_" + MainCount + "_" + SubCount);
                        }
                        if (obj == "txtHike_") {
                            MCOUNT++;
                            var Itemselect = $noconfli("#txtHike_" + MainCount + "_" + SubCount);
                        }
                    }
                    if (obj == "txtHike_") {
                        if (Itemselect.length) {

                            TotalEach = Itemselect.val();

                            if (TotalEach == "") {
                                TotalEach = 0;
                            }

                            Total = Total + parseFloat(TotalEach);

                        }
                    }
                    else {
                        if (Itemselect.length) {

                            TotalEach = Itemselect.val();
                            Total = Total + parseFloat(TotalEach);

                        }
                    }
                }
            });

            var num = Total;
            var n = Total;
            // for floatting number adjustment from corp global
            var FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
            if (FloatingValue != "") {
                n = num.toFixed(FloatingValue);
            }
          
            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                if (obj == 'txtCprice_') {
                   
                    document.getElementById('tdFooterTotalCPriceWithTax_' + CntMain).innerText = n;
                }
                else if (obj == 'txtHike_') {
                    n = n / MCOUNT;
                    if (FloatingValue != "") {
                        n = n.toFixed(FloatingValue);
                    }
                    document.getElementById('tdFooterTotalMarginWithTax_' + CntMain).innerText = n;
                }
                else if (obj == 'txtRate_') {
                    document.getElementById('tdFooterTotalSPriceWithTax_' + CntMain).innerText = n;
                }
                else if (obj == 'txtTaxAmnt_') {
                    document.getElementById('tdFooterTotalTaxAmntWithTax_' + CntMain).innerText = n;
                }
                else if (obj == 'txtDiscAmnt_') {
                    document.getElementById('tdFooterTotalDiscAmntWithTax_' + CntMain).innerText = n;
                }
                else if (obj == 'txtAmnt_') {
                    document.getElementById('tdFooterTotalAmountWithTax_' + CntMain).innerText = n;
                }
            }
            else {
                if (obj == 'txtCprice_') {
                    document.getElementById('tdFooterTotalCPriceWithoutTax_' + CntMain).innerText = n;
                }
                else if (obj == 'txtRate_') {
                    document.getElementById('tdFooterTotalSPriceWithoutTax_' + CntMain).innerText = n;
                }
                else if (obj == 'txtDiscAmnt_') {
                    document.getElementById('tdFooterTotalDiscAmntWithoutTax_' + CntMain).innerText = n;
                }
                else if (obj == 'txtAmnt_') {
                    document.getElementById('tdFooterTotalAmountWithoutTax_' + CntMain).innerText = n;
                }
                else if (obj == 'txtHike_') {
                    n = n / MCOUNT;

                    if (FloatingValue != "") {
                        n = n.toFixed(FloatingValue);
                    }
                    document.getElementById('tdFooterTotalMarginWithoutTax_' + CntMain).innerText = n;
                }
            }


        }

        function BlurDiscVal(obj, CntMain) {

            var FloatingValue="";
            var ZeroVal=0;

            if (obj == "txtDiscntValPerc_") {

                if (DiscValueCheck(obj, CntMain) == true) {

                    var Val = document.getElementById(obj + CntMain).value;
                    if (parseFloat(Val) > 100) {
                        document.getElementById(obj + CntMain).value = 100;
                        DiscValueCheck(obj, CntMain);
                    }
                }

                FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                document.getElementById("txtDiscntValAmnt_" + CntMain).value=ZeroVal.toFixed(FloatingValue);
            }
            else if (obj == "txtDiscntValAmnt_") {

                DiscValueCheck(obj, CntMain);

                FloatingValue = document.getElementById("<%=hiddenFloatingValueCommonPercentage.ClientID%>").value;
                document.getElementById("txtDiscntValPerc_" + CntMain).value=ZeroVal.toFixed(FloatingValue);
            }

            CalculateSubtotalOfCat(CntMain);
            CalculateTotalAmountFromHiddenField(CntMain);
        }

        function DiscValueCheck(obj, CntMain) {

            var ret = true;
            var txtDiscVal = document.getElementById(obj + CntMain).value;

            if (txtDiscVal == "") {
                ret = false;
            }
            else if (!isNaN(txtDiscVal) == false) {

                document.getElementById(obj + CntMain).value = "";
                ret = false;
            }
            if (ret == false) {
                var num = 0;
                var n = 0;
                // for floatting number adjustment from corp global
                var FloatingValue = 0;
                if (obj == "txtDiscntValPerc_") {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueCommonPercentage.ClientID%>").value;
                }
                else if (obj == "txtDiscntValAmnt_") {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }
                else if (obj == "txtTotalDiscntAmnt_") {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }
                if (FloatingValue != "") {
                    n = num.toFixed(FloatingValue);
                }
                document.getElementById(obj + CntMain).value = n;

            }
            else {
                var amt = parseFloat(txtDiscVal);
                var num = amt;
                var n = amt;
                // for floatting number adjustment from corp global
                var FloatingValue = 0;
                if (obj == "txtDiscntValPerc_") {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueCommonPercentage.ClientID%>").value;
                }
                else if (obj == "txtDiscntValAmnt_") {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }
                else if (obj == "txtTotalDiscntAmnt_") {

                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }
                if (FloatingValue != "") {
                    n = num.toFixed(FloatingValue);
                }
                document.getElementById(obj + CntMain).value = n;

            }
            return ret;
        }


function RadioDiscAmntClick(CntMain) {
    if (document.getElementById('txtDiscntValAmnt_' + CntMain).style.display == "none") {
        var num = 0;
        var n = 0;
        // for floatting number adjustment from corp global
        var FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
        if (FloatingValue != "") {
            var n = num.toFixed(FloatingValue);
        }

        document.getElementById('txtDiscntValAmnt_' + CntMain).value = n;


    }

    document.getElementById('txtDiscntValPerc_' + CntMain).style.display = "none";
    document.getElementById('txtDiscntValAmnt_' + CntMain).style.display = "";
    CalculateSubtotalOfCat(CntMain);
    CalculateTotalAmountFromHiddenField(CntMain);
}
function RadioDiscPercClick(CntMain) {
    if (document.getElementById('txtDiscntValPerc_' + CntMain).style.display == "none") {
        var num = 0;
        var n = 0;
        // for floatting number adjustment from corp global
        var FloatingValue = document.getElementById("<%=hiddenFloatingValueCommonPercentage.ClientID%>").value;
                if (FloatingValue != "") {
                    var n = num.toFixed(FloatingValue);
                }

                document.getElementById('txtDiscntValPerc_' + CntMain).value = n;


            }
            document.getElementById('txtDiscntValAmnt_' + CntMain).style.display = "none";
            document.getElementById('txtDiscntValPerc_' + CntMain).style.display = "";
            CalculateSubtotalOfCat(CntMain);
            CalculateTotalAmountFromHiddenField(CntMain);
        }

        function AddDeletedRowId(DelrowMain, DelRowSub) {
            if (document.getElementById("tdEvt_" + DelrowMain + "_" + DelRowSub).innerHTML == "UPD") {
                var detailId = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value;
                detailId = detailId + "," + document.getElementById("tdDtlId_" + DelrowMain + "_" + DelRowSub).innerHTML;
                document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = detailId;
            }
        }

        function CheckDelEachRowProduct(DelrowMain, DelRowSub) {
            var newCount = 0;
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to remove?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    AddDeletedRowId(DelrowMain, DelRowSub);

                    if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {

                        if ($("#tdCtgry" + DelrowMain + "_" + DelRowSub).is(":visible") == true){

                            var NextIdObj = jQuery('#RowTableProductWithTax_' + DelrowMain + "_" + DelRowSub).next();
                            var NextId = NextIdObj.attr('id');
                            if (NextId != undefined) {

                                NextIdSplit = NextId.split('_');
                                if (NextIdSplit[0] == "RowTableProductWithoutTax" || NextIdSplit[0] == "RowTableProductWithTax") {
                                    AddcategoryRow(NextIdSplit[1], NextIdSplit[2], 0, "false");
                                    document.getElementById("txtCategoryName_" + NextIdSplit[1] + "_" + NextIdSplit[2]).value = document.getElementById("txtCategoryName_" + DelrowMain + "_" + DelRowSub).value;
                                    document.getElementById("txtCategoryName_" + DelrowMain + "_" + DelRowSub).value = "";
                                } else {
                                    if (NextIdSplit[0] == "SubTotalRowId" || NextIdSplit[0] == "SubTotalRowId") {
                                        AddMoreProductRowWithTax(DelrowMain, DelRowSub, "INS", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "false", "other","0","");
                                        var Newrow = $('#RowTableProductWithTax_' + DelrowMain + '_' + DelRowSub).next().attr('id');
                                        splitNewrow = Newrow.split('_');
                                        AddcategoryRow(splitNewrow[1], splitNewrow[2], 0, "false");

                                        document.getElementById("txtCategoryName_" + splitNewrow[1] + "_" + splitNewrow[2]).value = document.getElementById("txtCategoryName_" + DelrowMain + "_" + DelRowSub).value;
                                        document.getElementById("txtCategoryName_" + DelrowMain + "_" + DelRowSub).value = "";
                                    }
                                }
                            }

                        }

                        jQuery('#RowTableProductWithTax_' + DelrowMain + "_" + DelRowSub).remove();
                        Table = $('#TableProductWithTaxBody_' + DelrowMain + ' tr.ClassBody');
                    }
                    else {
                        
                        if ($("#tdCtgry" + DelrowMain + "_" + DelRowSub).is(":visible") == true){

                            var NextIdObj = jQuery('#RowTableProductWithoutTax_' + DelrowMain + "_" + DelRowSub).next();
                            var NextId = NextIdObj.attr('id');
                            if (NextId != undefined) {

                                NextIdSplit = NextId.split('_');
                                if (NextIdSplit[0] == "RowTableProductWithoutTax" || NextIdSplit[0] == "RowTableProductWithTax") {
                                    AddcategoryRow(NextIdSplit[1], NextIdSplit[2], 0, "false");
                                    document.getElementById("txtCategoryName_" + NextIdSplit[1] + "_" + NextIdSplit[2]).value = document.getElementById("txtCategoryName_" + DelrowMain + "_" + DelRowSub).value;
                                    document.getElementById("txtCategoryName_" + DelrowMain + "_" + DelRowSub).value = "";
                                } else {
                                    if (NextIdSplit[0] == "SubTotalRowId" || NextIdSplit[0] == "SubTotalRowId") {
                                        AddMoreProductRow(MainTempCount, DelRowSub, "INS", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "false", "other","0","");
                                        var Newrow = $('#RowTableProductWithoutTax_' + DelrowMain + '_' + DelRowSub).next().attr('id');
                                        splitNewrow = Newrow.split('_');
                                        AddcategoryRow(splitNewrow[1], splitNewrow[2], 0, "false");

                                        document.getElementById("txtCategoryName_" + splitNewrow[1] + "_" + splitNewrow[2]).value = document.getElementById("txtCategoryName_" + DelrowMain + "_" + DelRowSub).value;
                                        document.getElementById("txtCategoryName_" + DelrowMain + "_" + DelRowSub).value = "";
                                    }
                                }
                            }

                        }
                   
                        jQuery('#RowTableProductWithoutTax_' + DelrowMain + "_" + DelRowSub).remove();
                        Table = $('#TableProductWithoutTaxBody_' + DelrowMain + ' tr.ClassBody');
                    }

                    var count = 0;
                    $(Table).each(function () {
                        var RowId = $(this).attr('id');
                        var SplitId = RowId.split('_');
                        var RowIdName = SplitId[0];
                        var MainCount = SplitId[1];
                        var SubCount = SplitId[2];
                        if (RowIdName == "RowTableProductWithoutTax" || RowIdName == "RowTableProductWithTax") {
                            count++;
                        }

                    });
                    ReNumberTable(DelrowMain);
                    if (count == 0) {
                        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                            AddMoreProductRowWithTax(DelrowMain, 1, 0, "INS", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "false", "other", "0","");
                        } else {
                            AddMoreProductRow(DelrowMain, 1, 0, "INS", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "false", "other", "0","");
                        }
                    }
                    ReNumberTable(DelrowMain);
                    AddButtonVisible(DelrowMain);
                }

            });
            CalculateSubtotalOfCat(DelrowMain);
            CalculateTotalAmountFromHiddenField(DelrowMain);
            return false;
        }

        function ReNumberTable(CntMain) {
            var Table = "";

            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                Table = $('#TableProductWithTaxBody_' + CntMain + ' tr.ClassBody');
            }
            else {

                Table = $('#TableProductWithoutTaxBody_' + CntMain + ' tr.ClassBody');
            }
            var count = 0;
            $(Table).each(function () {
                var RowId = $(this).attr('id');
                var SplitId = RowId.split('_');
                var RowIdName = SplitId[0];
                var MainCount = SplitId[1];
                var SubCount = SplitId[2];
                if (RowIdName == "RowTableProductWithoutTax" || RowIdName == "RowTableProductWithTax") {
                    var Itemselect = $noconfli("#DivSerial_" + CntMain + "_" + SubCount);
                    if (Itemselect.length) {
                        count++;
                        document.getElementById('DivSerial_' + CntMain + "_" + SubCount).innerHTML = count;

                    }
                }
            });
        }


        function ValidateAndSave(obj) {

            var ret = true;
            if (CheckIsRepeat() == true) {

                ret = true;
            }
            else {
                ret = false;
                return ret;
            }

            var MainTable = $('#tableTotalProductContainer tr.ClassMain');

            $(MainTable).each(function () {

                var RowIdMain = $(this).attr('id');
                var SplitIdMain = RowIdMain.split('_');
                var RowIdMainName = SplitIdMain[0];
                var CntMain = SplitIdMain[1];

                document.getElementById('divErrorNotification_'+CntMain).style.visibility = "hidden";
                document.getElementById('lblErrorNotification_' + CntMain).innerHTML = "";

                if (RowIdMainName == "TemplateRowId") {
                    var subTable = "";

                    if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                        subTable = $('#TableProductWithTaxBody_' + CntMain + ' tr.ClassBody');
                    }
                    else {
                        subTable = $('#TableProductWithoutTaxBody_' + CntMain + ' tr.ClassBody');
                    }

                    $("#PrdctGrpName_" + CntMain).css("border-color", "");
                    if (document.getElementById('PrdctGrpName_' + CntMain).value.trim() == "") {
                        document.getElementById('divErrorNotification_' + CntMain).style.visibility = "visible";
                        document.getElementById('lblErrorNotification_' + CntMain).innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById('PrdctGrpName_' + CntMain).focus();
                        document.getElementById('PrdctGrpName_' + CntMain).style.borderColor = "red";
                        ret = false;
                    }

                    $(subTable).each(function () {

                        var RowId = $(this).attr('id');
                        var SplitId = RowId.split('_');
                        var RowIdName = SplitId[0];
                        var MainCount = SplitId[1];
                        var SubCount = SplitId[2];

                        if (RowIdName == "RowTableProductWithoutTax" || RowIdName == "RowTableProductWithTax") {
                            if ($("#tdCtgry" + MainCount + "_" + SubCount).is(":visible") == true) {
                                if (document.getElementById("txtCategoryName_" + MainCount + "_" + SubCount).value.trim() == "") {
                                    document.getElementById("txtCategoryName_" + MainCount + "_" + SubCount).style.borderColor = "red";
                                    document.getElementById("txtCategoryName_" + MainCount + "_" + SubCount).focus();
                                    document.getElementById('divErrorNotification_' + MainCount).style.visibility = "visible";
                                    document.getElementById('lblErrorNotification_' + MainCount).innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                    ret = false;
                                }
                            }
                        }

                        if (CheckAllRowFieldAndHighlight(MainCount, SubCount) == false) {
                            document.getElementById('divErrorNotification_' + MainCount).style.visibility = "visible";
                            document.getElementById('lblErrorNotification_' + MainCount).innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            ret = false;
                        }
                        
                    });
                }

            });

            if (ret == false) {

            }
            else {


                var tbClientTotalValues = '';
                tbClientTotalValues = [];

                var tbClientGroupValues = '';
                tbClientGroupValues = [];
                var MainTable = $('#tableTotalProductContainer tr.ClassMain');
                var OrderNo = 0;
                $(MainTable).each(function () {

                    var RowIdMain = $(this).attr('id');
                    var SplitIdMain = RowIdMain.split('_');
                    var RowIdMainName = SplitIdMain[0];
                    var CntMain = SplitIdMain[1];

                    if (RowIdMainName == "TemplateRowId") {

                        var productGrpname = $("#PrdctGrpName_" + CntMain).val();
                        var prdctGrpId = document.getElementById('tdPrdctGrpId_' + CntMain).innerHTML;
                        var prdctGrpEvt = document.getElementById('tdPrdctGrpEvt_' + CntMain).innerHTML;

                        if (prdctGrpEvt == "COPY") {
                            prdctGrpEvt = "INS";
                            prdctGrpId = "0";
                        }

                        var DiscMode = "1";
                        var DiscValue = "0";

                        var ZeroVal=0;
                        var FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                        var FloatingValuePrcnt = document.getElementById("<%=hiddenFloatingValueCommonPercentage.ClientID%>").value;

                        if (document.getElementById('txtDiscntValAmnt_' + CntMain).value!="0" && document.getElementById('txtDiscntValAmnt_' + CntMain).value!=ZeroVal.toFixed(FloatingValue)) {
                            DiscMode = "1";
                            DiscValue = document.getElementById('txtDiscntValAmnt_' + CntMain).value;
                        }
                        if (document.getElementById('txtDiscntValPerc_' + CntMain).value!="0" && document.getElementById('txtDiscntValPerc_' + CntMain).value!=ZeroVal.toFixed(FloatingValuePrcnt)) {
                            DiscMode = "2";
                            DiscValue = document.getElementById('txtDiscntValPerc_' + CntMain).value;
                        }

                        var DiscAmount = document.getElementById('txtTotalDiscntAmnt_' + CntMain).value;
                        var GrossAmount = document.getElementById('txtGrossAmount_' + CntMain).value;
                        var NetAmount = document.getElementById('txtNetAmount_' + CntMain).value;
                        var Grpclient = JSON.stringify({
                            GRPNAME: "" + productGrpname + "",
                            GRPID: "" + prdctGrpId + "",
                            GROSSAMNT: "" + GrossAmount + "",
                            DISCMODE: "" + DiscMode + "",
                            DISCVALUE: "" + DiscValue + "",
                            DISCAMNT: "" + DiscAmount + "",
                            NETAMOUNT: "" + NetAmount + "",
                            EVTACTION: "" + prdctGrpEvt + "",
                        });

                        var subTable = "";
                        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == '1') {
                            subTable = $('#TableProductWithTaxBody_' + CntMain + ' tr.ClassBody');
                        }
                        else {

                            subTable = $('#TableProductWithoutTaxBody_' + CntMain + ' tr.ClassBody');
                        }
                        var CategoryName = "";
                        $(subTable).each(function () {
                            var RowId = $(this).attr('id');
                            var SplitId = RowId.split('_');
                            var RowIdName = SplitId[0];
                            var MainCount = SplitId[1];
                            var SubCount = SplitId[2];

                            if (RowIdName == "RowTableProductWithoutTax" || RowIdName == "RowTableProductWithTax") {

                                if ($("#tdCtgry" + MainCount + "_" + SubCount).is(":visible") == true) {
                                    CategoryName = document.getElementById('txtCategoryName_' + MainCount + '_' + SubCount).value;
                                }

                                var detailId = document.getElementById("tdDtlId_" + MainCount + '_' + SubCount).innerHTML;
                                var evt = document.getElementById("tdEvt_" + MainCount + '_' + SubCount).innerHTML;
                                if (evt == "COPY") {
                                    evt = "INS";
                                    detailId = "0";
                                }
                                var PrdctAvlbl = document.getElementById("tdPrdctAvailable_" + MainCount + '_' + SubCount).innerHTML;
                                var additional = document.getElementById("tdAdditional_" + MainCount + '_' + SubCount).innerHTML;
                                var print = document.getElementById("tdPrintSt_" + MainCount + '_' + SubCount).innerHTML;
                                var $add = jQuery.noConflict();
                                OrderNo++;
                                var client = JSON.stringify({
                                    ROWID: "" + SubCount + "",
                                    ITEMNAME: $add("#txtItem_" + MainCount + '_' + SubCount).val(),
                                    UNITNAME: $add("#txtUnit_" + MainCount + '_' + SubCount).val(),
                                    QUANTITY: $add("#txtQuantity_" + MainCount + '_' + SubCount).val(),
                                    COSTPRICE: $add("#txtCprice_" + MainCount + '_' + SubCount).val(),
                                    HIKE: $add("#txtHike_" + MainCount + '_' + SubCount).val(),
                                    RATE: $add("#txtRate_" + MainCount + '_' + SubCount).val(),
                                    TAXPERC: $add("#txtTaxPerc_" + MainCount + '_' + SubCount).val(),
                                    TAXAMNT: $add("#txtTaxAmnt_" + MainCount + '_' + SubCount).val(),
                                    DISCAMNT: $add("#txtDiscAmnt_" + MainCount + '_' + SubCount).val(),
                                    AMOUNT: $add("#txtAmnt_" + MainCount + '_' + SubCount).val(),
                                    ADDITIONAL: "" + additional + "",
                                    PRDCTAVAILABLE: "" + PrdctAvlbl + "",
                                    EVTACTION: "" + evt + "",
                                    DTLID: "" + detailId + "",
                                    PRDCTMODE: "1",
                                    PRINTED: "" + print + "",
                                    PRDCTCAT: "" + CategoryName + "",
                                    PRDCTGRPID: "" + prdctGrpId + "",
                                    PRDCTGRPNAME: "" + productGrpname + "",
                                    PRDCTGRPEVT: "" + prdctGrpEvt + "",
                                    PRDCTORDERID: "" + OrderNo + "",
                                });


                                tbClientTotalValues.push(client);

                            }
                        });
                        tbClientGroupValues.push(Grpclient);
                    }

                
                });
            
                document.getElementById("<%=HiddenField1.ClientID%>").value = JSON.stringify(tbClientTotalValues);
                document.getElementById("<%=hiddenTotalProductGrpNames.ClientID%>").value = JSON.stringify(tbClientGroupValues);

                if (document.getElementById("<%=hiddenConfirmImportErrors.ClientID%>").value != "") {

                    if (confirm("There was some Mis-Match/Missing in Imported Data.Are you Sure you want to Continue?")) {
                        ret = true;
                    }
                    else {
                        ret = false;
                    }
                }

                if (ret == true) {
                    if (obj == "Confirm") {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you Sure you want to Confirm this Quotation?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                document.getElementById("<%=btnConfirmClick.ClientID%>").click();
                                ShowLoadingGif();
                            }
                        });
                        return false;
                    }
                    else if (obj == "Approve") {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you sure you want to Approve this Quotation?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                document.getElementById("<%=btnApproveClick.ClientID%>").click();
                                if (document.getElementById("<%=cbxSendMail.ClientID%>").checked) {
                                    ShowLoadingGif();
                                }
                            }
                        });
                        return false;

                    }
                    else if (obj == "Return") {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you sure you want to Return this Quotation without Approval?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                document.getElementById("<%=btnReturnClick.ClientID%>").click();
                            }
                        });
                        return false;

                    }
                }
            }

            if (ret == false) {
                CheckSubmitZero();
            }

            return ret;
        }

    function CkeckDupGroupName(subCount, event) {


        ReplaceTag('PrdctGrpName_' + subCount, event);
        var MainTable = $('#tableTotalProductContainer tr.ClassMain');
        var GroupName = $("#PrdctGrpName_" + subCount).val()
        var MainTablePrdctGrp = "";
        $(MainTable).each(function () {

            var RowIdMain = $(this).attr('id');
            var SplitIdMain = RowIdMain.split('_');
            var RowIdMainName = SplitIdMain[0];
            var CntMain = SplitIdMain[1];
            if (RowIdMainName == "TemplateRowId") {
                var productGrpname = $("#PrdctGrpName_" + CntMain).val()
                $("#PrdctGrpName_" + CntMain).css("border-color", "#09511e");
                if (subCount != CntMain) {
                    if (GroupName!="")
                    {
                    if (GroupName == productGrpname) {
                        $("#PrdctGrpName_" + subCount).val("");
                        $("#PrdctGrpName_" + subCount).css("border-color", "red");
                        
                        document.getElementById('divErrorNotification_' + subCount).style.visibility = "visible";
                        document.getElementById('lblErrorNotification_' + subCount).innerHTML = "Duplication Occur in \"Quotation for\" template name.Please check the highlighted field";
                        $("#PrdctGrpName_" + subCount).focus();
                        return false;
                    }
                    }
                }
            }
        });
    }

    function OpenQuotationSts(objname, subEvent) {

        var leadId = document.getElementById("<%=HiddenLeadId.ClientID%>").value;
        $Mo.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "Cmpzt_Quotation2.aspx/QuotanStsLoad",
            data: '{strLeadId: "' + leadId + '"}',
            dataType: "json",
            success: function (data) {
                if($('#DivQutionSts:visible').length == 0)
                {
                    document.getElementById("DivQutionSts").style.display = "block";
                    document.getElementById('divReport').innerHTML = data.d;
                }
                else {
                    document.getElementById("DivQutionSts").style.display = "none";
                }
            },
            error: function (result) {

            }
        });
        return false;

    }

        function ChangeQuotSts(Stsid, stsName) {

            ezBSAlert({
                type: "confirm",
                messageText: "Are You Sure You Want To Change The Status ?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var leadId = document.getElementById("<%=HiddenLeadId.ClientID%>").value;
                    $Mo.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "Cmpzt_Quotation.aspx/QuotanStsSave",
                        data: '{strLeadId: "' + leadId + '",strId: "' + Stsid + '",strName: "' + stsName + '"}',
                        dataType: "json",
                        success: function (data) {
                            var leadidref = document.getElementById("<%=HiddenLeadIdres.ClientID%>").value;
                            window.location.href = 'Cmpzt_Quotation2.aspx?LeadId=' + leadidref + '&InsUpd=StsChange&Prev=List&QTN_TMPLT=2';


                        },
                        error: function (result) {
                            // alert("Error");
                        }
                    });
                }
            });
            return false;
        }
        function SuccessStatusChange() {
            $("#success-alert").html("Quotation Status Changed Successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function ConfirmCopyFrmRvsd() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure to make it as final Quotation?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=btnMakeFinalClick.ClientID%>").click();
                }
            });
            return false;
        }
    </script>

         <script>
             var $Mo = jQuery.noConflict();
             function OpenEditMailWindow(objname, subEvent) {

                 $('#myModalMail').modal('show');
                 document.getElementById('imgarrowDownMail').style.visibility = "visible";

                 document.getElementById("<%=txtToAddress.ClientID%>").style.borderColor = "";

                 document.getElementById("<%=txtCccontent.ClientID%>").style.borderColor = "";
                 document.getElementById("<%=txtBCccontent.ClientID%>").style.borderColor = "";

                 localStorage.clear();
                 var offset = $Mo("#" + objname).offset();
                 var posY = 0;
                 var posX = 0;

                 posY = offset.top - 5;

                 posX = offset.left - 680;

                 posX = 37.5;


                 document.getElementById('divErrorRsnMail').style.visibility = "hidden";
                 document.getElementById("<%=lblErrorRsnMail.ClientID%>").innerHTML = "";

                 document.getElementById("<%=txtToAddress.ClientID%>").readOnly = false;

                 document.getElementById("<%=txtCccontent.ClientID%>").readOnly = false;
                 document.getElementById("<%=txtBCccontent.ClientID%>").readOnly = false;

                 return false;
             }

         function CloseModalMail() {

             ezBSAlert({
                 type: "confirm",
                 messageText: "Do You Want To Close This?",
                 alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                     $('#myModalMail').modal('hide');
                 }
             });
             return false;

        }


    </script>
    <script>
        function saveAddtnlMailIds() {


            if (CheckMail()) {
                var LeadId = document.getElementById("<%=HiddenLeadId.ClientID%>").value;
                var ToAddr = document.getElementById("<%=txtToAddress.ClientID%>").value;
                var CcAddr = document.getElementById("<%=txtCccontent.ClientID%>").value;
                var BCcAddr = document.getElementById("<%=txtBCccontent.ClientID%>").value;
                BCcAddr = BCcAddr.replace(/ /g, '')
                CcAddr = CcAddr.replace(/ /g, '')
                ToAddr = ToAddr.replace(/ /g, '')
                PageMethods.AddMailIds(LeadId, ToAddr, CcAddr, BCcAddr, onSucess);
                function onSucess(result) {
                    document.getElementById("<%=lblErrorRsnMail.ClientID%>").style.visibility = "visible";
                    document.getElementById("<%=lblErrorRsnMail.ClientID%>").innerHTML = "Details Saved Sucessfully.";

                }

                return false;
            }
            else {
                return false;
            }
        }
        function CheckMail() {

            var ret = true;

            if (document.getElementById("<%=txtToAddress.ClientID%>").value == "") {

                document.getElementById("<%=lblErrorRsnMail.ClientID%>").style.visibility = "visible";
                document.getElementById("<%=lblErrorRsnMail.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtToAddress.ClientID%>").style.borderColor = "Red";
                ret = false;

            }
            else {

                document.getElementById("<%=txtToAddress.ClientID%>").style.borderColor = "";
                var data = document.getElementById("<%=txtToAddress.ClientID%>").value;
                var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                var res = [];
                res = data.split(",");

                for (var i = 0; i < res.length; i++) {

                    if (!filter.test(res[i].trim())) {

                        document.getElementById("<%=lblErrorRsnMail.ClientID%>").style.visibility = "visible";
                        document.getElementById("<%=lblErrorRsnMail.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=txtToAddress.ClientID%>").style.borderColor = "Red";
                        ret = false;
                    }
                    if (ret !== false) {
                        document.getElementById("<%=txtToAddress.ClientID%>").style.borderColor = "";
                        ret = true;

                    }
                }

            }

            if (document.getElementById("<%=txtCccontent.ClientID%>").value != "") {
                var dataCc = document.getElementById("<%=txtCccontent.ClientID%>").value;
                var filterCc = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                var resCc = [];
                resCc = dataCc.split(",");
                for (var j = 0; j < resCc.length; j++) {
                    if (!filterCc.test(resCc[j].trim())) {
                        document.getElementById("<%=lblErrorRsnMail.ClientID%>").style.visibility = "visible";
                         document.getElementById("<%=lblErrorRsnMail.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                         document.getElementById("<%=txtCccontent.ClientID%>").style.borderColor = "Red";
                         ret = false;
                     }
                     if (ret !== false) {
                         document.getElementById("<%=txtCccontent.ClientID%>").style.borderColor = "";
                        ret = true;
                    }
                }
            }

            if (document.getElementById("<%=txtBCccontent.ClientID%>").value != "") {
                var dataBCc = document.getElementById("<%=txtBCccontent.ClientID%>").value;
                var filterBCc = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                var resBCc = [];
                resBCc = dataBCc.split(",");
                for (var k = 0; k < resBCc.length; k++) {
                    if (!filterBCc.test(resBCc[k].trim())) {
                        document.getElementById("<%=lblErrorRsnMail.ClientID%>").style.visibility = "visible";
                       document.getElementById("<%=lblErrorRsnMail.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                       document.getElementById("<%=txtBCccontent.ClientID%>").style.borderColor = "Red";
                       ret = false;
                   }
                   if (ret !== false) {
                       document.getElementById("<%=txtBCccontent.ClientID%>").style.borderColor = "";
                         ret = true;
                     }
                 }
             }
             return ret;
         }

    </script>

     <%-- Copy from old Quatations Emp15--%>
    <script>
        function Showquatationlist() {
            $('#MymodalQtnList').modal('show');
            return false;
        }
        function CloseCancelView() {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close  without completing the process?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    $('#MymodalQtnList').modal('hide');
                    document.getElementById("mymodaldivQtnListDetails").style.display = "none";
                }
            });
            return false;
        }
        function CloseCancelViewdet() {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close  without completing the process?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("mymodaldivQtnListDetails").style.display = "none";
                }
            });
            return false;
        }
        function ShowquatationDetaillist(T_Id, REfno) {

            //web method for drop down of narrations for common narration
            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            var tempttype = document.getElementById("<%=HiddenTemplatetype.ClientID%>").value;
            if (CorpId != '' && CorpId != null && OrgId != '' && OrgId != null && T_Id != '' && T_Id != null) {

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "Cmpzt_Quotation2.aspx/LoadQutationdetails",
                    data: '{corpid:' + CorpId + ',orgid:' + OrgId + ' ,intQtnId:' + T_Id + ' ,templttype:' + tempttype + '}',
                    dataType: "json",
                    success: function (data) {

                        if (data.d != '') {

                            document.getElementById("cphMain_divQtnListDetails").innerHTML = data.d;
                            document.getElementById("cphMain_lblQtnRefnopopup").innerText = "Ref No:" + REfno;

                        }
                    },
                    error: function (result) {

                    }
                });

            }
            return false;
        }

        function AddToQuotation(T_Id) {

            ezBSAlert({
                type: "confirm",
                messageText: "All data inserted would be cleared.Are you sure you want to copy?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=HiddenCopyqtnid.ClientID%>").value = T_Id;
                    __doPostBack('<%=btncopyquoationdummy.UniqueID %>', '')
                }
            });
            return false;
        }

        function writeToFile(d1) {
            var fso = new ActiveXObject("Scripting.FileSystemObject");
            var fh = fso.OpenTextFile("E:/data.txt", 8, false, 0);
            fh.WriteLine(d1);
            fh.Close();
        }

    </script>
       <%--Start:-EMP-0009 --%>
    <script>
        function showRevsdQtnList() {
            $('#MyModalRvsdQtnList').modal('show');
            return false;
        }
        function CloseCancelViewRvsd() {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close  without completing cancellation process?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    $('#MyModalRvsdQtnList').modal('hide');
                }
            });
            return false;
        }
        //start:-EMP-0015 9   
        function Searchbyname() {


            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            var tempttype = document.getElementById("<%=HiddenTemplatetype.ClientID%>").value;
            var userId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
            var customer = document.getElementById("<%=ddlcustomername.ClientID%>").value;
            if (customer == "--SELECT CUSTOMER--" || customer == "")
                customer = "0";
            if (CorpId != '' && CorpId != null && OrgId != '' && OrgId != null && userId != '' && userId != null) {

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "Cmpzt_Quotation2.aspx/LoadQutationListBysearch",
                    data: '{corpid:' + CorpId + ',orgid:' + OrgId + ' ,customerId:' + customer + ' ,templttype:' + tempttype + ' ,userId:' + userId + '}',
                    dataType: "json",
                    success: function (data) {

                        if (data.d != '') {
                            document.getElementById("<%=divQtnList.ClientID%>").innerHTML = data.d;;
                        }
                    },
                    error: function (result) {

                    }
                });

            }
            return false;
        }

    </script>
 
     <%--End:-EMP-0009 --%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>


    <asp:HiddenField ID="hiddenL_MODE" runat="server" />
    <asp:HiddenField ID="hiddenDfltQuotationFormatId" runat="server" />
    <asp:HiddenField ID="hiddenDivisionCode" runat="server" />
    <asp:HiddenField ID="hiddenUserCode" runat="server" />
    <asp:HiddenField ID="hiddenMonthMM" runat="server" />
    <asp:HiddenField ID="hiddenYearYYYY" runat="server" />
    <asp:HiddenField ID="hiddenQtnRevisionVersn" runat="server" />
    <asp:HiddenField ID="hiddenImportError" runat="server" />
    <asp:HiddenField ID="hiddenQtnTemplateId" runat="server" />
    <asp:HiddenField ID="hiddenCSVvalues" runat="server" />
    <asp:HiddenField ID="hiddenPreviousPriceTerm" runat="server" />
    <asp:HiddenField ID="hiddenPreviousManufacturerTerm" runat="server" />
    <asp:HiddenField ID="hiddenPreviousPaymentTerm" runat="server" />
    <asp:HiddenField ID="hiddenPreviousDeliveryTerm" runat="server" />
    <asp:HiddenField ID="hiddenPreviousWarrantyTerm" runat="server" />
    <asp:HiddenField ID="hiddenQuotationDate" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenQuotationStatus" runat="server" />
    <asp:HiddenField ID="hiddenLeadActiveUser" runat="server" />
    <asp:HiddenField ID="hiddenBillDiscountAmount" runat="server" />
    <asp:HiddenField ID="hiddenQuotationId" runat="server" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenGrossAmount" runat="server" />
    <asp:HiddenField ID="hiddenNetAmount" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenQtnUnitIdFocus" runat="server" />
    <asp:HiddenField ID="hiddenQtnItemIdFocus" runat="server" />
    <asp:HiddenField ID="hiddenValueFocus" runat="server" />
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hiddenFloatingValueMoney" runat="server" />
    <asp:HiddenField ID="hiddenFloatingValueUnit" runat="server" />
    <asp:HiddenField ID="hiddenFloatingValueTaxPercentage" runat="server" />
    <asp:HiddenField ID="hiddenFloatingValueCommonPercentage" runat="server" />
    <asp:HiddenField ID="hiddenTaxEnabled" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="hiddenCorporateDivId" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="hiddenQtnRefSerialId" runat="server" />
    <asp:HiddenField ID="hiddenCurrencySymbol" runat="server" />
    <asp:HiddenField ID="hiddenConfirmImportErrors" runat="server" />
    <asp:HiddenField ID="hiddenReopenReasonId" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyDisplay" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyCode" runat="server" />
    <asp:HiddenField ID="HiddenLeadId" runat="server" />
    <asp:HiddenField ID="HiddenTemplatetype" runat="server" />
    <asp:HiddenField ID="HiddenCopyqtnid" runat="server" />
    <asp:HiddenField ID="HiddenCopiedval" runat="server" />
    <asp:HiddenField ID="HiddenDonotclear" runat="server" />
    <asp:HiddenField ID="HiddenCategoryName" runat="server" />
    <asp:HiddenField ID="HiddenPrevCategory" runat="server" />
    <asp:HiddenField ID="HiddenFieldViewChk" runat="server" />
    <asp:HiddenField ID="hiddenTotalProductGrpNames"  runat="server" />
    <asp:HiddenField ID="hiddenDeletedPrdctGrps"  runat="server" />
    <asp:HiddenField ID="hiddenEditdetailgroupData"  runat="server" />
    <asp:HiddenField ID="hiddenEditCatData"  runat="server" />
    <asp:HiddenField ID="hiddenEditdetailgroupDataCopied"  runat="server" />
    <asp:HiddenField ID="hiddenEditCatDataCopied"  runat="server" />
    <asp:HiddenField ID="HiddenLeadIdres"  runat="server" />
    <asp:HiddenField ID="HiddenFieldTeamLeadId" runat="server" />
    <asp:HiddenField ID="hiddenAdditionalId" runat="server" />

  <ol class="breadcrumb">
        <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
        <li><a href="/Transaction/gen_Lead/gen_LeadList.aspx">Opportunity</a></li>
        <li><a id="aLeadInfo" runat="server" href="/Transaction/gen_Lead/gen_LeadIndividualList.aspx">Opportunity Information</a></li>
        <li id="aHead" runat="server" class="active">Quotation (Project Template)</li>
   </ol>

<!---alert_message_section---->
<div class="myAlert-top alert alert-success" id="success-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully
</div>

<div class="myAlert-bottom alert alert-danger" id="danger-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Danger!</strong> Request not conmpleted
</div>
<!----alert_message_section_closed---->


  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr">

        <div onmouseover="closesave()">

        <h2><span id="divReportCaption" runat="server">Quotation (Project Template)</span>
          <a class="btn act_btn bn4 bt_e bt_fx_crqt" id="popoverOpener" data-height="600" data-width="400" title="Customer Requirements" ><i class="fa fa-address-card-o"></i></a>
        </h2>

        <div id="popoverWrapper" class="stmp_tmpl">
          <div class="popover" role="tooltip">
            <div class="arrow"></div>
            <h3 class="popover-title">Customer Requirements</h3>
            <div class="popover-content">
                <div class="form-group fg12">
              <CKEditor:CKEditorControl ID="CKEditorDescription" runat="server" cols="30" rows="7" BasePath="~/ckeditor" RemovePlugins="toolbar" Enabled="false" ></CKEditor:CKEditorControl>
               <%-- <asp:TextBox ID="CKEditorDescription" runat="server" cols="64" rows="18" placeholder="Description" Style="resize: none;width:100%;outline:none!important;border:none;background-color:#fff;" TextMode="MultiLine" onkeypress="return isTag('cphMain_CKEditorDescription',event);" onkeydown="textCounter(cphMain_CKEditorDescription,295);" onkeyup="textCounter(cphMain_CKEditorDescription,295);" onblur="ReplaceTag('cphMain_CKEditorDescription',event);"></asp:TextBox>--%>
                </div>
                <div class="clearfix"></div>
                <div class="devider"></div>
              <button class="btn btn-danger btn-dz flt_r"" style="margin-left:4px;" onclick="return CloseDescriptn();">Close</button>
            </div>
          </div>
        </div>

          <script>
              function OpenDescription() {
                  $("#popoverWrapper").fadeIn();
                  return false;
              }

              function CloseDescriptn() {
                  $("#popoverWrapper").fadeOut();
                  return false;
              }
          </script>

        <div class="clearfix"></div>

      
    <div class="top_br_container hc_at">
            <div class="top_br_1 pa_h1">
              <div class="col-md-5 tx_100 hcm_1_2 ref_box_head gray_ul">
                <ul>
                  <li><span class="fg6_22 li_100">Customer Name:</span> <span class="fg6_78 li_100_1"><asp:Label ID="lblCustomerName" runat="server"></asp:Label></span></li>
                  <li><span class="fg6_22 li_100">Division:</span> <span class="fg6_78 li_100_1"><asp:Label ID="lblDivision" runat="server"></asp:Label></span></li>
                  <li id="divQtnRtrnReasonSts" runat="server"><span id="divQtnReason" runat="server" class="fg6_22 li_100"></span> <span class="fg6_78 li_100_1"> <a id="aOptionsReopenReason" runat="server" href="javascript:;" data-toggle="popover" data-placement="bottom"></a></span></li>
                </ul>
              </div>
              <div class="col-md-4 tx_100 hcm_1_2 ref_box_head">
                <ul>
                  <li><span class="fg6_10 li_100">Title:</span> <span class="fg6_90 li_100_1"><asp:Label ID="lblTitle" runat="server"></asp:Label></span></li>
                  <li id="divQtnSts" runat="server"><span class="fg6_10 li_100">Status:</span> <span class="fg6_90 li_100_1"><asp:Label ID="lblStatus" runat="server"></asp:Label></span></li>
                </ul>
              </div>

              <div class="col-md-3 tx_100 hcm_1_2 ref_box_head ">
                <ul>
                  <li><span class="fg6_14 fg2 li_100">Date:</span> <span class="fg6_86 li_100_1"><asp:Label ID="lblDate" runat="server"></asp:Label></span></li>
                  <li id="divRef" runat="server"><span class="fg6_14 i_100">Ref#:</span> <span class="fg6_86 li_100_1"><asp:Label ID="lblRefNumbr" runat="server"></asp:Label></span></li>
                </ul>
              </div>
            </div>
    </div>

<div class="clearfix"></div>
<div class="devider"></div>

<p class="plc1 pl_rg">PRODUCT / SERVICE DETAILS  
  <button id="btnshowoldqtns" runat="server" class="btn tab_but1 butn5 cpy_hi" onclick="return Showquatationlist();" title="Copy From Previous"><i class="fa fa-files-o"></i></button>
</p>


<div id="divTotalproductDetailContainer" class="clone_sec0">
  <div class="spl_hcm wid_100_1 hei_102 bg_ne_1" style="margin-bottom: 10px;">

 <div id="divTemplate2" runat="server">
    <div class="fg6">
      <div id="divFileUploader" class="fg4 sa_1">
        <label for="email" class="fg2_la1 pad_l">CSV: <span class="spn1">&nbsp;</span></label>
        <asp:FileUpload ID="fupImportCsv" runat="server" Accept=".csv" />
        <label for="cphMain_fupImportCsv" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>
        <div id="file-upload-filename" class="file_n"></div>
      </div>

      <div class="form-group fg4 sa_1">
        <label class="form1 mar_bo">
          <span class="button-checkbox">
            <button type="button" class="btn-d" data-color="p" ng-model="all"></button>
            <asp:CheckBox ID="cbxSkpRowWithouItmNm" Text="" runat="server" Checked="false"  class="hidden" onkeypress=" return DisableEnter(event);" />
          </span>
          <p class="pz_s" data-toggle="tooltip" title="Skip all records without product / service name">Skip Records</p>
        </label><br>
        <label class="form1 mar_bo">
          <span class="button-checkbox">
            <button type="button" class="btn-d" data-color="p" ng-model="all"></button>
            <asp:CheckBox ID="cbxImprtHasHeader" Text="" runat="server" Checked="false" class="hidden" onkeypress=" return DisableEnter(event);" />
          </span>
          <p class="pz_s">My Data Has Headers</p>
        </label><br>
      </div>
      <div class="fg5">
        <asp:Button ID="btnImportCsv" runat="server" Style="display:none;" Text="Import from CSV file" OnClick="btnImportCsv_Click"/>
        <button class="btn tab_but1 butn5" onclick="return FileImportValidate();"><i class="fa fa-files-o"></i> Import from CSV file</button>
      </div>
    </div>
<div class="clearfix"></div>
<div class="devider"></div>
 </div>

  <div id="tableTotalProductContainer">
    <div id="divBlink" style="display:none;"></div> 
  </div>

 </div>
</div>

   <div class="clearfix"></div>
   <div class="devider"></div>


    <p class="plc1 pl_rg">TERMS & CONDITIONS
      <button id="btnViewRevsdQtn" runat="server" class="btn act_btn bn11 bt_e" onclick="return showRevsdQtnList();" title="View Revised Quotation">
          <i class="opp_ico_img"><img src="/Images/New%20Images/images/icons/opp/view_quot.png"> </i>
      </button>
    </p>

    <div id="divPriceTerm" class="form-group fg2 fg2_mr sa_480">
      <label for="email" class="fg2_la1">Price Terms:<span class="spn1"></span></label>
      <asp:DropDownList ID="ddlPriceTerm" class="form-control fg2_inp1" runat="server" onblur="return ChangePriceTerm();" onfocus="getPreviousDDLPrice_SelectedVal()" autofocus="autofocus" autocorrect="off" autocomplete="off"></asp:DropDownList>
      <%--<asp:TextBox ID="txtPriceTerm" class="leads_field" runat="server" MaxLength="200" Style="text-transform: uppercase;"></asp:TextBox>--%>
      <asp:TextBox ID="txtPriceTerm" runat="server" rows="3" cols="48" class="form-control flt_l mar_tp1 tx1" placeholder="Price Terms" Style=" resize: none; " TextMode="MultiLine" onkeypress="return isTag('cphMain_txtPriceTerm',event);" onkeydown="textCounter(cphMain_txtPriceTerm,295);" onkeyup="textCounter(cphMain_txtPriceTerm,295);" onblur="ReplaceTag('cphMain_txtPriceTerm',event);"></asp:TextBox>
    </div>

    <div id="divPymntTerm" class="form-group fg2 fg2_mr sa_480">
      <label for="email" class="fg2_la1">Payment Terms:<span class="spn1"></span></label>
        <asp:DropDownList ID="ddlPymntTerm" class="form-control fg2_inp1" runat="server" onblur="return ChangePaymentTerm();" onfocus="getPreviousDDLPayment_SelectedVal()" autofocus="autofocus" autocorrect="off" autocomplete="off"></asp:DropDownList>
        <%--<asp:TextBox ID="txtPymntTerm" class="leads_field" runat="server" MaxLength="300" Style="text-transform: uppercase;"></asp:TextBox>--%>
        <asp:TextBox ID="txtPymntTerm" runat="server" rows="3" cols="48" class="form-control flt_l mar_tp1 tx1" placeholder="Payment Terms" Style="resize: none;" TextMode="MultiLine" onkeypress="return isTag('cphMain_txtPymntTerm',event);" onkeydown="textCounter(cphMain_txtPymntTerm,295);" onkeyup="textCounter(cphMain_txtPymntTerm,295);" onblur="ReplaceTag('cphMain_txtPymntTerm',event);"></asp:TextBox>
    </div>

    <div id="divDlvryTerm" class="form-group fg2 fg2_mr sa_480">
      <label for="email" class="fg2_la1">Delivery Terms:<span class="spn1"></span></label>
      <asp:DropDownList ID="ddlDlvryTerm" class="form-control fg2_inp1" runat="server" onblur="return ChangeDeliveryTerm();" onfocus="getPreviousDDLDelivery_SelectedVal()" autofocus="autofocus" autocorrect="off" autocomplete="off"></asp:DropDownList>
      <%--<asp:TextBox ID="txtDlvryTerm" class="leads_field" runat="server" MaxLength="300" Style="text-transform: uppercase;"></asp:TextBox>--%>
      <asp:TextBox ID="txtDlvryTerm" runat="server" rows="3" cols="48" class="form-control flt_l mar_tp1 tx1" placeholder="Delivery Terms" Style="resize: none;" TextMode="MultiLine" onkeypress="return isTag('cphMain_txtDlvryTerm',event);" onkeydown="textCounter(cphMain_txtDlvryTerm,295);" onkeyup="textCounter(cphMain_txtDlvryTerm,295);" onblur="ReplaceTag('cphMain_txtDlvryTerm',event);"></asp:TextBox>
    </div>

   <div id="divWrntyTerm" class="form-group fg2 fg2_mr sa_480">
      <label for="email" class="fg2_la1">Warranty Terms:<span class="spn1"></span></label>
      <asp:DropDownList ID="ddlWrntyTerm" class="form-control fg2_inp1" runat="server" onblur="return ChangeWarrantyTerm();" onfocus="getPreviousDDLWarranty_SelectedVal()" autofocus="autofocus" autocorrect="off" autocomplete="off"></asp:DropDownList>
      <%--<asp:TextBox ID="txtDlvryTerm" class="leads_field" runat="server" MaxLength="300" Style="text-transform: uppercase;"></asp:TextBox>--%>
      <asp:TextBox ID="txtWrntyTerm" runat="server" rows="3" cols="48" class="form-control flt_l mar_tp1 tx1" placeholder="Warranty Terms" Style="resize: none;" TextMode="MultiLine" onkeypress="return isTag('cphMain_txtWrntyTerm',event);" onkeydown="textCounter(cphMain_txtWrntyTerm,295);" onkeyup="textCounter(cphMain_txtWrntyTerm,295);" onblur="ReplaceTag('cphMain_txtWrntyTerm',event);"></asp:TextBox>
    </div>

    <div id="divManufacturerTerms" class="form-group fg2 fg2_mr sa_480">
      <label for="email" class="fg2_la1">Manufacturer Terms:<span class="spn1"></span></label>
      <asp:DropDownList ID="ddlManufacturerTerm" class="form-control fg2_inp1" runat="server" onblur="return ChangeManufacturerTerm();" onfocus="getPreviousDDLManufacturer_SelectedVal()" autofocus="autofocus" autocorrect="off" autocomplete="off"></asp:DropDownList>
      <%--<asp:TextBox ID="txtDlvryTerm" class="leads_field" runat="server" MaxLength="300" Style="text-transform: uppercase;"></asp:TextBox>--%>
      <asp:TextBox ID="txtManufacturerTerm" runat="server" rows="3" cols="48" class="form-control flt_l mar_tp1 tx1" placeholder="Manufacturer Terms" Style="resize: none;" TextMode="MultiLine" onkeypress="return isTag('cphMain_txtManufacturerTerm',event);" onkeydown="textCounter(cphMain_txtManufacturerTerm,295);" onkeyup="textCounter(cphMain_txtManufacturerTerm,295);" onblur="ReplaceTag('cphMain_txtManufacturerTerm',event);"></asp:TextBox>
    </div>

    <div  class="fg6 tx_100">
      <div class="form-group txt_96_wid">
        <label for="email" class="fg2_la1">Description:<span class="spn1">&nbsp;</span></label>
        <asp:TextBox ID="txtComments" runat="server" rows="3" cols="50" class="form-control" placeholder="Description" Style="resize: none;" TextMode="MultiLine" onkeypress="return isTag('cphMain_txtComments',event);" onkeydown="textCounter(cphMain_txtComments,800);" onkeyup="textCounter(cphMain_txtComments,800);" onblur="ReplaceTag('cphMain_txtComments',event);"></asp:TextBox>
      </div><br />
      </div>

      <div class="form-group fg2 fg2_mr sa_480">
      <label for="email" class="fg2_la1">Quote Validity:<span class="spn1"></span></label>
      <div class="input-group dys">
        <asp:TextBox ID="txtValidityTerm" class="form-control inp_st tr_r" runat="server" Style="width: 78%!important;" onkeypress="return isTag('cphMain_txtValidityTerm',event);" onkeydown="return isNumberValidity('cphMain_txtValidityTerm',event)" onblur="ReplaceTagAlphabetValidity('cphMain_txtValidityTerm',event);" MaxLength="4"></asp:TextBox>
        <span class="input-group-addon cur3 sp_hv" style="width: 22%!important;">Days</span>
      </div>
    </div>

      <div id="divCurrncy" class="form-group fg2 sa_fg4 sa_480" style=" padding-bottom: 2px;">
        <label for="email" class="fg2_la1">Currency:<span class="spn1"></span></label>
        <asp:DropDownList ID="ddlCurrency" class="form-control fg2_inp1" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off"></asp:DropDownList>
      </div>  

           <%--discarded--%>
                <div class="leads_form_left" style="width: 43%; display: none;">
                    <h3 style="margin-top: 1%;">Delivery Period</h3>
                    <asp:TextBox ID="txtDlvryPeriod" class="leads_field" onkeypress="return isTag('cphMain_txtDlvryPeriod',event);" Style="width: 74%;" onblur="ReplaceTag('cphMain_txtDlvryPeriod',event);" runat="server" MaxLength="300"></asp:TextBox>
                </div>
           <%--discarded--%>


  <div class="clearfix"></div>
  <div class="devider"></div>

  <div class="fg12">
    <div class="fg4 sa_1">
      <label class="form1 mar_bo wid_at">
        <span class="button-checkbox">
          <button type="button" class="btn-d" data-color="p" ng-model="all"></button>
          <asp:CheckBox ID="cbxSendMail" Text="" runat="server" Checked="false" class="hidden"  onkeypress="return DisableEnter(event);" />
        </span>
        <p class="pz_s">Send Quotation Automatically While Approval</p>
      </label>
      <span id="lblSendMailError" runat="server" class="opp_ico_img_ptp1 btm_info" data-toggle="tooltip" title="Please Review E-Mail Settings of Employee, Division And Customer" tooltip-title="Tooltip title #1"><img src="/Images/New%20Images/images/icons/opp/hint.png"></span>
    </div>
    <div class="fg7 sa_1">
      <div class="t1_b blink">
      </div>
    </div>
  </div>

  <a href="javascript:;" id="lblEditMailWindow" runat="server" onclick="OpenEditMailWindow('cphMain_lblEditMailWindow',event);"></a>
  <asp:Button ID="btnReSendMail" runat="server" class="btn sub2" Text="Send Mail" OnClick="btnReSendMail_Click" OnClientClick="return ReturnReSendMail();" />

  <div class="clearfix"></div>
  <div class="free_sp"></div>
  <div class="devider"></div>

  <div class="sub_cont pull-right">
    <div class="save_sec">
      <asp:Button ID="btnSave" runat="server" class="btn sub1" Text="Save" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
      <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />
      <asp:Button ID="btnConfirm" runat="server" class="btn sub3" Text="Confirm" OnClientClick="return ValidateAndSave('Confirm');" OnClick="btnConfirm_Click" />
      <asp:Button ID="btnReOpenDown" runat="server" class="btn sub1" Text="Re-Open"  OnClientClick="return ReOpenConfirm();" />
      <asp:Button ID="btnDeliveredDown" runat="server" class="btn sub3" Text="Delivered" OnClick="btnDelivered_Click" OnClientClick="return CheckIsRepeat();" />  
      <asp:Button ID="btnReturn" runat="server" class="btn sub2" Text="Return" ToolTip="Return Without Approval" OnClientClick="return ReturnConfirm();" />
      <asp:Button ID="btnApprove" runat="server" class="btn sub1" Text="Approve" ToolTip="Save & Approval" OnClick="btnApprove_Click" OnClientClick="return ValidateAndSave('Approve');" />
      <asp:Button ID="btnShowPDF" runat="server" class="btn sub3" Text="Preview  PDF" OnClick="ButtonShowPDF_Click" />
      <asp:Button ID="btnMakeFnlDown" runat="server" class="btn sub1" Text="Make Final" OnClientClick="return ConfirmCopyFrmRvsd()" OnClick="btnMakeFinalquoation_Click" />
      <asp:Button ID="btnClose" runat="server" class="btn sub4" Text="Close" OnClick="btnClose_Click" />
    </div>
  </div>
   
     <asp:Button ID="btnList" runat="server" Visible="false" class="save" Text="List" OnClick="btnListTop_Click" OnClientClick="return ConfirmMessage()" />

       </div>
      </div><!---content_box1--_closed--->
     </div>
   </div>

     <!-- The Modal Loading MAIL -->
      <div id="myModalLoadingMail" style="display:none;">
         <div><img src="../../Images/Other Images/LoadingMail.gif" /></div>
      </div>
     <!-- The Modal Loading MAIL -->

<a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
 <i class="fa fa-save"></i>
</a>

<a id="divList" runat="server" href="javascript:;" type="button" class="list_b" title="Back to List" onclick="return ConfirmMessage();">
 <i class="fa fa-arrow-circle-left"></i>
</a>

<a href="#" id="scroll" style="display: none;"><span class="fa fa-angle-up"></span></a>

<a id="BtnQuatnSts" runat="server" href="javascript:;" title="Change Quotation Status" onclick="return OpenQuotationSts('cphMain_BtnQuatnSts', event);">
 <div onclick="topFunction()" id="myBtn" class="dropdown dd_spl1 opp_btz tp_ovr">
  <i class="fa fa-file-text-o"></i>
 </div>
</a>

<div id="DivQutionSts" class="stat_sbox">
  <ul id="divReport"></ul>
</div>

 <div class="mySave1" id="mySave">
  <div class="save_sec" style="padding-top: 10px;">
      <asp:Button ID="btnReSendMailTop" runat="server" class="btn sub2" Text="Send Mail" OnClick="btnReSendMail_Click" OnClientClick="return ReturnReSendMail();" />
      <asp:Button ID="btnSaveTop" runat="server" class="btn sub1" Text="Save" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
      <asp:Button ID="btnUpdateTop" runat="server" class="btn sub1" Text="Update" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />
      <asp:Button ID="btnConfirmTop" runat="server" class="btn sub3" Text="Confirm" OnClientClick="return ValidateAndSave('Confirm');" />
      <asp:Button ID="btnReOpen" runat="server" class="btn sub1" Text="Re-Open"  OnClientClick="return ReOpenConfirm();" />
      <asp:Button ID="btnDelivered" runat="server" class="btn sub3" Text="Delivered" OnClick="btnDelivered_Click" OnClientClick="return CheckIsRepeat();" />   
      <asp:Button ID="btnReturnTop" runat="server" class="btn sub2" Text="Return" ToolTip="Return Without Approval" OnClientClick="return ReturnConfirm();" />
      <asp:Button ID="btnApproveTop" runat="server" class="btn sub1" Text="Approve" ToolTip="Save & Approval" OnClientClick="return ValidateAndSave('Approve');" />
      <asp:Button ID="btnShowPDFTop" runat="server" class="btn sub3" Text="Preview PDF" OnClick="ButtonShowPDF_Click" />
      <asp:Button ID="btnMakeFnlTop" runat="server" class="btn sub1" Text="Make Final" OnClientClick="return ConfirmCopyFrmRvsd()" />
      <asp:Button ID="btnCloseTop" runat="server" class="btn sub4" Text="Close" OnClick="btnClose_Click" />

    <asp:Button ID="btnConfirmClick" Style="display:none;" runat="server" class="btn sub3" Text="Confirm" OnClick="btnConfirm_Click" />
    <asp:Button ID="btnReturnClick" Style="display:none;" runat="server" class="btn sub2" Text="Return" ToolTip="Return Without Approval" OnClick="btnReturn_Click" />
    <asp:Button ID="btnApproveClick" Style="display:none;" runat="server" class="btn sub1" Text="Approve" ToolTip="Save & Approval" OnClick="btnApprove_Click" />
    <asp:Button ID="btnMakeFinalClick" Style="display:none;" runat="server" class="btn sub1" Text="Make Final" OnClick="btnMakeFinalquoation_Click" />
  </div>
</div>

<asp:Button ID="btnListTop" runat="server" Visible="false" class="save" Text="List" OnClick="btnListTop_Click" OnClientClick="return ConfirmMessage()" />

 <div id="divReopenDescription" runat="server" style="display: none;"></div>
 <div id="divPrdctStockOptions" runat="server" style="display: none;"></div>
 <div id="divOptionsReopenReason" runat="server" style="display: none;"></div>

<script>
    function opensave() {
        document.getElementById("mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("mySave").style.width = "0px";
    }
</script>


<!-- Modal Quotation list -->
<div class="modal fade" id="MymodalQtnList" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog ad_sd_mod01 flt_l" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Quotation List</h5>
        <button type="button" class="close" onclick="return CloseCancelView();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="form-group fg6">
          <label for="email" class="fg2_la1">Customer Name:<span class="spn1"></span></label>
          <asp:DropDownList ID="ddlcustomername" runat="server" class="form-control fg2_inp1 qou_op1"></asp:DropDownList>          
        </div>
        <div class="fg2">
          <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
          <button id="btnSearch" runat="server" class="btn tab_but1 butn5" onclick="return Searchbyname();"><i class="fa fa-search"></i> Search</button>  
        </div>
      <div class="clearfix"></div>
        <div id="divQtnList" runat="server" class="table_box tb_scr"></div>
    </div>
      <div class="modal-footer">
        <asp:Button ID="btnRsnCncl" class="btn sub4" onclientclick="return CloseCancelView();" runat="server" Text="Close" />
      </div>
    </div>
  </div>
</div>
<!-- Modal Quotation list -->

<!-- Modal Quotation details -->
  <div id="mymodaldivQtnListDetails" class="modal-dialog ad_sd_mod02 flt_l icon_2 closs1" role="document" style="display:none;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Quotation Details</h5>
        <button type="button" class="close closs" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body" style="height: 161px!important;">
          <asp:Label ID="lblQtnRefnopopup" runat="server" Text=""></asp:Label>
          <div id="divQtnListDetails" runat="server"></div>
      </div>
      <div class="modal-footer">
        <asp:Button ID="btncopyquoationdummy" runat="server" Text="Copy" Visible="false"  OnClick="btncopyquoation_Click"/>
       <button type="submit" class="btn sub4 closs" aria-label="Close" onclick="return CloseCancelViewdet();">Close</button>
      </div>
    </div>
  </div>
<!-- Modal Quotation details -->  

<script type="text/javascript">
    $(".icon_3").click(function(){
        $(".icon_2").toggle();
    });
</script>

<!-- Modal Send mail -->
<div class="modal fade" id="myModalMail" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog ad_sd_mod01 flt_r" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Send Mail</h5>
        <button type="button" class="close" onclick="return CloseModalMail();">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div  id="divToAddressContent" class="modal-body">
           <div id="divErrorRsnMail" style="visibility: hidden; font-family: Calibri;">
               <asp:Label ID="lblErrorRsnMail" runat="server"></asp:Label>
           </div>
         <div id="divToAddress" class="form-group fg_container sa_fg4 sa_640">
          <label class="fg2_la1">To:</label>
          <asp:TextBox ID="txtToAddress" runat="server" MaxLength="499" class="form-control fg2_inp1 inp_mst sen_op1"  onkeypress="return DisableEnter(event);" autocomplete="off"></asp:TextBox>
          <label class="fg2_la1">Cc:</label>
          <asp:TextBox ID="txtCccontent" runat="server" MaxLength="499" class="form-control fg2_inp1 inp_mst" onkeypress="return DisableEnter(event);" autocomplete="off"></asp:TextBox>
          <label class="fg2_la1">Bcc:</label>
          <asp:TextBox ID="txtBCccontent" runat="server" MaxLength="499" class="form-control fg2_inp1 inp_mst" onkeypress="return DisableEnter(event);" autocomplete="off"></asp:TextBox>
        </div>
      </div>
        </div>
      <div class="modal-footer">
       <button type="submit" id="btnAddmailSave" onclick="return saveAddtnlMailIds();" class="btn sub1" aria-label="Close">Save</button>
      </div>
      <img id='img1' src="../../Images/Icons/green-arrowDown-20x20.png" style="display:none;"> 
        </div>
      </div>
    </div>
<!-- Modal Send mail -->

<!-- Modal revised quotation list -->
<div class="modal fade" id="MyModalRvsdQtnList" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog ad_sd_mod01 flt_l" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Revised Quotation List</h5>
        <button type="button" class="close" onclick="return CloseCancelViewRvsd();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
      <div class="modal-body">
           <div id="divRvsdList" runat="server" class="form-group fg_container"></div>
      </div>
        </div>
      <div class="modal-footer">
       <button type="submit" class="btn sub4" onclick="return CloseCancelViewRvsd();">Close</button>
      </div>
        </div>
      </div>
 </div>
<!-- Modal revised quotation list -->


<!-- Modal reopen reason -->
<div class="modal fade" id="myModalReopenReason" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog ad_sd_mod01 flt_r" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Reopen Reason</h5>
        <button type="button" class="close" onclick="return CloseModalReopenReason();">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
         <div id="divErrorRsnReopenReason" style="visibility: hidden; font-family: Calibri;">
             <asp:Label ID="lblErrorRsnReopenReason" runat="server"></asp:Label>
          </div>
        <div class="form-group fg_container">
          <label for="email" class="fg2_la1">Reason:<span class="spn1">*</span></label>
          <span id="SpanddlReopenReason"></span>           
        </div>
      <div class="form-group dys">
        <label for="email" class="fg2_la1">Description:<span class="spn1">&nbsp;</span></label>
        <asp:TextBox ID="txtReopenReasonDescptn" rows="3" cols="50" class="form-control" placeholder="Description" TextMode="MultiLine" runat="server" onkeypress="return isTag('cphMain_txtReopenReasonDescptn', event);" onkeydown="textCounter(cphMain_txtReopenReasonDescptn,900);" onkeyup="textCounter(cphMain_txtReopenReasonDescptn,900);" Style="resize: none;"></asp:TextBox>
      </div>
     </div>
      <div class="modal-footer">
        <asp:Button ID="btnReopenReasonSave" runat="server" class="btn sub1" Text="Save" OnClientClick="return CheckReopenReason();" OnClick="btnReopenReasonSave_Click" />
      </div>
        </div>
      </div>
    </div>
<!-- Modal reopen reason -->



  <script type="text/javascript">
      $(document).ready(function () {
          $(".cont_contr").scroll(function () {
              if ($(this).scrollTop() > 100) {
                  $('#scroll').fadeIn();
                  $('.popover.right').fadeOut();
                  $('.popover.top').fadeOut();
              } else {
                  $('#scroll').fadeOut();
              }
          });
          $('#scroll').click(function () {
              $(".cont_contr").animate({ scrollTop: 0 }, 600);
              return false;
          });
      });
</script>

<script>
    $(document).ready(function() {
        $noCon("#cphMain_ddlCurrency").msDropdown({ roundedBorder: false });
    })
</script>

<script>
    $(document).ready(function(e) {
        $noCon("#cphMain_ddlCurrency").msDropdown({ visibleRows: 4 });
    });
    $(document).on('keydown', function(e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            $('.dd .ddChild').hide();
        }
    });
</script>

<script type="text/javascript">

    $("[data-toggle=popover]").popover({
        html : true,
        trigger: 'focus',
        content: function() {
            var content = $(this).attr("data-popover-content");
            return $(content).children("btn-danger").html();
        }
    });
    $(document).on('keydown', function(e) { 
        var keyCode = e.keyCode || e.which; 

        if (keyCode == 27) { 
            $('.popover.top').hide();
            $('.popover.right').hide();
        } 
    });
    $(document).on("click", ".popover .btn-danger" , function(){
        $(this).parents(".popover").popover('hide');
    });
</script>

<style type="text/css">
  .popover-content{max-height: 240px;}
  .popover.top{max-width:370px;}
</style>

<script type="text/javascript">
    $(function () {
        $('[data-toggle="popover0"]').popover();
        $('[data-toggle="tooltip0"]').tooltip();
    });
    $(document).on('keydown', function(e) { 
        var keyCode = e.keyCode || e.which; 

        if (keyCode == 27) { 
            $('.popover.top').hide();
        } 
    });
    $(document).ready(function () {
        $(".pop_o_cls").click(function () {
            $(".popover.right").hide();
        });
    });
</script>
<style type="text/css">
  .popover-content0{max-height: 300px;}
  .popover0.top0{max-width:500px;}
  .popover.right{min-width:500px;min-height: 400px;}
  .popover.right .popover-content{min-height:400px;}
</style>
<script type="text/javascript">
    $(".closs").click(function () {
        $(".closs1").toggle();
    }); $(".closs").click(function () {
        $(".closs1").hide();
    });
</script>

<script type="text/javascript">
    'use strict';
class Popover {
    constructor(element, trigger, options) {
        this.options = { // defaults
            position: Popover.LEFT
        };
        this.element = element;
        this.trigger = trigger;
        this._isOpen = false;
        Object.assign(this.options, options);
        this.events();
        this.initialPosition();
    }

    events() {
        this.trigger.addEventListener('click', this.toggle.bind(this));
    }

    initialPosition() {
      let triggerRect = this.trigger.getBoundingClientRect();
        this.element.style.top = ~~triggerRect.top + 'px';
        this.element.style.left = ~~triggerRect.left + 'px';
    }

    toggle(e) {
        e.stopPropagation();
        if (this._isOpen) {
            this.close(e);
        } else {
            this.element.style.display = 'block';
            this._isOpen = true;
            this.outsideClick();
            this.position();
        }
    }

    targetIsInsideElement(e) {
      let target = e.target;
        if (target) {
            do {
                if (target === this.element) {
                    return true;
                }
            } while (target = target.parentNode);
        }
        return false;
    }

    close(e) {
        if (!this.targetIsInsideElement(e)) {
            this.element.style.display = 'block';
            this._isOpen = false;
            this.killOutSideClick();
        }
    }

    position(overridePosition) {
      let triggerRect = this.trigger.getBoundingClientRect(),
        elementRect = this.element.getBoundingClientRect(),
        position = overridePosition || this.options.position;
        this.element.classList.remove(Popover.TOP, Popover.BOTTOM, Popover.LEFT, Popover.RIGHT); // remove all possible values
        this.element.classList.add(position);
        if (position.indexOf(Popover.BOTTOM) !== -1) {
            this.element.style.left = ~~triggerRect.left + ~~((triggerRect.width / 2) - ~~(elementRect.width / 2)) + 'px';
            this.element.style.top = ~~triggerRect.bottom + 'px';
        } else if (position.indexOf(Popover.TOP) !== -1) {
            this.element.style.left = ~~triggerRect.left + ~~((triggerRect.width / 2) - ~~(elementRect.width / 2)) + 'px';
            this.element.style.top = ~~(triggerRect.top - elementRect.height) + 'px';
        } else if (position.indexOf(Popover.LEFT) !== -1) {
            this.element.style.top = ~~((triggerRect.top + triggerRect.height / 2) - ~~(elementRect.height / 2)) + 'px';
            this.element.style.left = ~~(triggerRect.left - elementRect.width) + 'px';
        } else {
            this.element.style.top = ~~((triggerRect.top + triggerRect.height / 2) - ~~(elementRect.height / 2)) + 'px';
            this.element.style.left = ~~triggerRect.right + 'px';
            this.element.classList.add(position);
        }
    }

    outsideClick() {
        document.addEventListener('', this.close.bind(this));
    }

    // killOutSideClick() {
    //   document.removeEventListener('click', this.close.bind(this));
    // }

    isOpen() {
        return this._isOpen;
    }
}

    Popover.TOP = 'top';
    Popover.RIGHT = 'right';
    Popover.BOTTOM = 'bottom';
    Popover.LEFT = 'left';

    document.addEventListener('DOMContentLoaded', function() {
      let btn = document.querySelector('#popoverOpener'),
        template = document.querySelector('.popover'),
        pop = new Popover(template, btn, {
            position: Popover.RIGHT
        }),
        links = template.querySelectorAll('.popover-content a');
        for (let i = 0, len = links.length; i < len; ++i) {
          let link = links[i];
            console.log(link);
            link.addEventListener('click', function(e) {
                e.preventDefault();
                pop.position(this.className);
                this.blur();
                return true;
            });
        }
    });

    $(document).on('keydown', function(e) { 
        var keyCode = e.keyCode || e.which; 

        if (keyCode == 27) { 
            $('.popover.right').hide("");
        } 
    });
    $(document).on("click", ".popover.right .btn-dz" , function(){
        $('.popover.right').hide("");
    });
</script>
<script type="text/javascript">
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
</script>


</asp:Content>

