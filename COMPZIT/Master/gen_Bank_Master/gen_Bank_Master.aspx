<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"  MasterPageFile="~/MasterPage/MasterPageCompzit.master" CodeFile="gen_Bank_Master.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Bank_Master_gen_Bank_Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
  <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
     <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
       <script type="text/javascript">
           var $noCon = jQuery.noConflict();
           $noCon(window).load(function () {

               $noCon(".select2").select2();
            
               var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;

               if (EditVal != "") {
                                     
                   var find2 = '\\"\\[';
                   var re2 = new RegExp(find2, 'g');
                   var res2 = EditVal.replace(re2, '\[');

                   var find3 = '\\]\\"';
                   var re3 = new RegExp(find3, 'g');
                   var res3 = res2.replace(re3, '\]');
                   //   alert('res3' + res3);
                   var json = $noCon.parseJSON(res3);
                   for (var key in json) {
                       if (json.hasOwnProperty(key)) {
                           if (json[key].TempDetlId != "") {

                               //  alert('json[key].AddDesc ' + json[key].AddDesc);
                               EditListRows(json[key].ChkBklId, json[key].ChkBkName, json[key].ChLfNumFrom, json[key].ChLfNumTo, json[key].ChkStatus, json[key].ChkTemp, json[key].CnclCkLeaf);
                             
                           }
                       }
                   }
                 //  addMoreRows();

               }
               addMoreRows(1);
  
               //radioTDSclick();
               //radioTCSclick();
               ledgerStsClick(0);
               changeAmnt('cphMain_txtOpenBalanceDeb');
               CheckSpecification();
              
          });


          </script>
     <script>
         var $au = jQuery.noConflict();
         $au(function () {
             $au('#cphMain_ddlCC').selectToAutocomplete1Letter();
         });
    </script>
    <script type="text/javascript">
        function PassSavedBankToRFG(intBankId) {
            if (window.opener != null && !window.opener.closed) {
                window.opener.GetValueFromChildProject(intBankId);
            }
            window.close();
        }
        function DuplicationLedgrCodeMsg() {
            $("#divWarning").html("Duplication error!.Ledger code can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtLedgrCode.ClientID%>").style.borderColor = "Red";
        }

        function DuplicationCstCntrCodeMsg() {
            $("#divWarning").html("Duplication error!.Cost centre code can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });          
            document.getElementById("<%=txtCostCntrCode.ClientID%>").style.borderColor = "Red";
        }
        function SundryDebtorSelect() {
            $("#divWarning").html("Please define an account head for bank before creating new Bank");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
         }
        function DuplicationName() {
            $("#divWarning").html("Duplication error!.Bank name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });          
            document.getElementById("<%=txtBankName.ClientID%>").style.borderColor = "Red";           
        }
        function DuplicationNameLedgr() {
            $("#divWarning").html("Duplication error!.Ledger name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtBankName.ClientID%>").style.borderColor = "Red";           
        }

        function DuplicationNameCostCntr() {
            $("#divWarning").html("Duplication error!.Cost centre name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtBankName.ClientID%>").style.borderColor = "Red";
        }
        function SuccessConfirmation() {
            $("#success-alert").html("Bank details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Bank details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }

        function Validate() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtBankName.ClientID%>").value;

            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtBankName.ClientID%>").value = replaceText2;
            NameWithoutReplace = document.getElementById("<%=txtAccNo.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAccNo.ClientID%>").value = replaceText2;
            NameWithoutReplace = document.getElementById("<%=txtIfscCode.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtIfscCode.ClientID%>").value = replaceText2;
            NameWithoutReplace = document.getElementById("<%=txtBankSwiftCode.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtBankSwiftCode.ClientID%>").value = replaceText2;
            NameWithoutReplace = document.getElementById("<%=txtIBan.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtIBan.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtAddress.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAddress.ClientID%>").value = replaceText2;

            document.getElementById("<%=txtBankName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAccNo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtIfscCode.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtBankSwiftCode.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtIBan.ClientID%>").style.borderColor = "";


            var Name = document.getElementById("<%=txtBankName.ClientID%>").value.trim();
            var AccNo = document.getElementById("<%=txtAccNo.ClientID%>").value.trim();
            var IfscCode = document.getElementById("<%=txtIfscCode.ClientID%>").value.trim();
            var SwiftCode = document.getElementById("<%=txtBankSwiftCode.ClientID%>").value.trim();
            var IBan = document.getElementById("<%=txtIBan.ClientID%>").value.trim();

            var Sname = document.getElementById("<%=txtBankShortName.ClientID%>").value.trim();

            var addRowResultGrp = true;
            addRowtableGrp = document.getElementById("TableaddedRows");

            for (var i = 0; i < addRowtableGrp.rows.length; i++) {

                var row = addRowtableGrp.rows[i];
                var xLoop = (addRowtableGrp.rows[i].cells[0].innerHTML);

                if (ValidateAndHighlightChkBook(xLoop, 0) == false) {
                    addRowResultGrp = false;
                }
            }

            if (document.getElementById("<%=hiddenBankPostAdd.ClientID%>").value == "0") {

                if (document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "1") {

                    if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {

                        //var TDS = document.getElementById("cphMain_ddlTDS").value;
                        //var TCS = document.getElementById("cphMain_ddlTCS").value;

                        //document.getElementById("cphMain_ddlTDS").style.borderColor = "";
                        //document.getElementById("cphMain_ddlTCS").style.borderColor = "";

                        //if (document.getElementById("cphMain_cbxLedgerSts").checked == true && document.getElementById("cphMain_radioTCSyes").checked == true && TCS == "--SELECT TCS--") {

                        //    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        //    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        //    });

                        //    document.getElementById("cphMain_ddlTCS").style.borderColor = "Red";
                        //    document.getElementById("cphMain_ddlTCS").focus();
                        //    ret = false;
                        //}



                        //if (document.getElementById("cphMain_cbxLedgerSts").checked == true && document.getElementById("cphMain_radioTDSyes").checked == true && TDS == "--SELECT TDS--") {


                        //    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        //    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        //    });

                        //    document.getElementById("cphMain_ddlTDS").style.borderColor = "Red";
                        //    document.getElementById("cphMain_ddlTDS").focus();
                        //    ret = false;
                        //}

                    }
                    var CostGrp = document.getElementById("cphMain_ddlCC").value;
                    document.getElementById("cphMain_ddlCC").style.borderColor = "";
                    $("div#divCC input.ui-autocomplete-input").css("borderColor", "");

                    if (document.getElementById("cphMain_cbxLedgerSts").checked == true && document.getElementById("cphMain_cbxCsCntrSts").checked == true && CostGrp == "--SELECT COST GROUP--") {
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });

                        document.getElementById("cphMain_ddlCC").style.borderColor = "Red";
                        document.getElementById("cphMain_ddlCC").focus();

                        $("div#divCC input.ui-autocomplete-input").css("borderColor", "red");
                        $("div#divCC input.ui-autocomplete-input").select();
                        $("div#divCC input.ui-autocomplete-input").focus();
                        ret = false;
                    }


                }
            }
            if (addRowResultGrp == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                ret = false;

            }




            if (Name == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });


                if (Name == "") {


                    document.getElementById("<%=txtBankName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtBankName.ClientID%>").focus();
                    ret = false;
                }


            }
            //if (ret == true) {

            //}

            var acntflg = true;
            if (document.getElementById("<%=hiddenBankPostAdd.ClientID%>").value == "0") {
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
            }


            if (ret == false && acntflg == true) {
                CheckSubmitZero();

            }
            else if (ret == false && acntflg == false) {
                CheckSubmitZero();
            }
            else if (ret == true && acntflg == false) {
                $("#divWarning").html("Please define an account group for bank before creating new bank.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });


              
                CheckSubmitZero();
                ret = false;
            }

            if (ret == true) {
                document.getElementById("cphMain_txtBankName").disabled = false;
                document.getElementById("cphMain_txtAccNo").disabled = false;

                document.getElementById("cphMain_txtAddress").disabled = false;
                document.getElementById("cphMain_txtBankSwiftCode").disabled = false;

                document.getElementById("cphMain_txtIBan").disabled = false;
                document.getElementById("cphMain_txtBankShortName").disabled = false;
                document.getElementById("cphMain_chkHCM").disabled = false;
                document.getElementById("cphMain_cbxStatus").disabled = false;
            }




            if (ret == true) {

                var tbClientTotalValues = '';
                tbClientTotalValues = [];

                var table = document.getElementById("TableaddedRows");
                //  BlurValue(RowNum, null);

                $aa('#TableaddedRows').find('tr').each(function () {
                    var row = $(this);
                    var x = $aa('td:first-child', row).html();

                    if (x != "") {
                        if (document.getElementById('ddlProduct_' + x).value != "") {


                            var client = JSON.stringify({
                                ROWNUM: "" + x + "",


                            });
                            tbClientTotalValues.push(client);
                        }

                    }
                });
                document.getElementById("<%=HiddenAddChkBook.ClientID%>").value = JSON.stringify(tbClientTotalValues);
            }

            return ret;
        }

        function AcntGrpErrMsg() {
            $("#divWarning").html("Please define an account group for bank before creating new bank.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
           // return false;
        }
    </script>

    <script  type="text/javascript">
        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {
                // alert('An attempt was made to submit this form more than once; this extra attempt will be ignored.');
                return false;
            }
            else {
                return true;
            }
        } function CheckSubmitZero() {
            submit = 0;
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
                        window.location.href = "gen_Bank_Master_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_Bank_Master_List.aspx";
            }
        }
        function AlertClearAll() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to clear all the data from this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "gen_Bank_Master.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;              
            }
            else {
                window.location.href = "gen_Bank_Master.aspx";
                return false;
            }
        }

        //stop-0006
    </script>

    <script type="text/javascript" >
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

        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }

        // not to be taken for other form  other thsn this table creation
        function isNumber(objSource, evt) {
            // KEYCODE FOR. AND DELETE IS SAME IN KEY PRESS DIFFERENT IN KEY DOWN AND UP
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //  alert(keyCodes);
            var ObjVal = document.getElementById(objSource).value;


            //0-9
            if (keyCodes >= 48 && keyCodes <= 57) {
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




    </script>    
    <script>

        function ReNumberTable() {
            var Table = "";
            Table = $('#TableaddedRows > tr ');
            var count = 0;
            $(Table).each(function () {
                var RowId = $(this).attr('id');
                var SplitId = RowId.split('_');
                var RowId = SplitId[0];
                var rowCount = SplitId[1];
                if (RowId == "rowId") {
                    count++;

                    $noCon("#txtSlno" + rowCount).val(count);


                }
            });
            rowsl_no = count++;
        }
        function removeRowCheckBook(removeNum, CofirmMsg)
        {
           
            IncrmntConfrmCounter();
            //alert(removeNum);
            
            if (document.getElementById("ChequeSts_" + removeNum).value == "0") {
                if (document.getElementById("cphMain_HiddenFieldView").value != "1") {

                    ezBSAlert({
                        type: "confirm",
                        messageText: CofirmMsg,
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            var evt = document.getElementById("tdEvt" + removeNum).value;

                            if (evt == 'UPD') {
                                var detailId = document.getElementById("tdDtlId" + removeNum).value;
                                var CanclIds = document.getElementById("cphMain_hiddenCkBookCanclDtlId").value;

                                if (CanclIds == '') {
                                    document.getElementById("cphMain_hiddenCkBookCanclDtlId").value = detailId;
                                }
                                else {
                                    document.getElementById("cphMain_hiddenCkBookCanclDtlId").value = document.getElementById("cphMain_hiddenCkBookCanclDtlId").value + ',' + detailId;
                                }
                            }
                            //    var row_index = jQuery('#SubGrpRowId_' + removeNum).index();


                            //  RowIndexTarff--;

                            //    var BforeRmvTableRowCount = document.getElementById("TableQstn_").rows.length;


                            jQuery('#rowId_' + removeNum).remove();
                            ReNumberTable();
                            var TableRowCount = document.getElementById("TableaddedRows").rows.length;


                            if (TableRowCount != 0) {
                                var idlast = $noCon('#TableaddedRows tr:last').attr('id');

                                if (idlast != "") {

                                    var res = idlast.split("_");
                                    //  alert(res[1]);
                                    document.getElementById("tdInxBank" + res[1]).value = "";
                                    document.getElementById("SpanAdd" + res[1]).disabled = false;

                                }
                            }
                            else {

                                addMoreRows(1);
                            }




                            return false;
                        }
                        else {
                            return false;
                        }
                    });


                   
                }
                else {
                    return false;

                }
            }
            return false;
        }


        function CheckaddMoreRows(Grpx) {
            IncrmntConfrmCounter();
            var addRowtableGrp;
            var addRowResultGrp = true;
            var check = document.getElementById("tdInxBank" + Grpx).value;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
          //  alert(check);
            if (check == "") {
        
                addRowtableGrp = document.getElementById("TableaddedRows");
              
                for (var i = 0; i < addRowtableGrp.rows.length; i++) {

                    var row = addRowtableGrp.rows[i];
                    var xLoop = (addRowtableGrp.rows[i].cells[0].innerHTML);
                  
                    if (CheckAndHighlightChkBook(xLoop, 0) == false) {
                        addRowResultGrp = false;
                    }
                }
               

                if (addRowResultGrp == false ) {

                    return false;
                }

                else {

                    //  alert();
                    document.getElementById("tdInxBank" + Grpx).value = Grpx;
                    document.getElementById("SpanAdd" + Grpx).disabled = true;


                    addMoreRows(1);
                    document.getElementById("ddlProduct_" + (Grpx+1)).focus();
                    return false;
                }
            }
            return false;

        }

        
        function ValidateAndHighlightChkBook(x, FirstRow) {
            // checks every field in row

            var CheckAndHighlightRet = true;


            document.getElementById("ddlProduct_" + x).style.borderColor = "";
            document.getElementById("txtChqFrom" + x).style.borderColor = "";
            document.getElementById("txtChqTo" + x).style.borderColor = "";
            document.getElementById("CheqTemplt_" + x).style.borderColor = "";
            $("div#divCheqTemplt_"+x+" input.ui-autocomplete-input").css("borderColor", "");

            var txtSubCatName = document.getElementById("ddlProduct_" + x).value.trim();
            var txtChkFrm = document.getElementById("txtChqFrom" + x).value.trim();
            var txtChkTo = document.getElementById("txtChqTo" + x).value.trim();

            var txtChkTemp = document.getElementById("CheqTemplt_" + x).value;

            if (txtChkTemp != "--SELECT TEMPLATE--" || txtChkFrm != "" || txtChkTo != "" || txtSubCatName != "") {

                if (txtChkTo.length > "6") {
                    document.getElementById("txtChqTo" + x).style.borderColor = "Red";
                    CheckAndHighlightRet = false;
                }
                if (txtChkFrm.length > "6") {
                    document.getElementById("txtChqFrom" + x).style.borderColor = "Red";
                    CheckAndHighlightRet = false;
                }

                if (txtChkTemp == "--SELECT TEMPLATE--") {
                    document.getElementById("CheqTemplt_" + x).style.borderColor = "Red";

                    $("div#divCheqTemplt_" + x + " input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divCheqTemplt_" + x + " input.ui-autocomplete-input").select();
                    $("div#divCheqTemplt_" + x + " input.ui-autocomplete-input").focus();

                    CheckAndHighlightRet = false;
                }
                if (txtChkFrm == "") {
                    document.getElementById("txtChqFrom" + x).style.borderColor = "Red";
                    CheckAndHighlightRet = false;
                }
                if (txtChkTo == "") {
                    document.getElementById("txtChqTo" + x).style.borderColor = "Red";
                    CheckAndHighlightRet = false;
                }


                if (txtSubCatName == "") {
                    document.getElementById("ddlProduct_" + x).style.borderColor = "Red";
                    CheckAndHighlightRet = false;
                }

            }


            return CheckAndHighlightRet;
        }

        function CheckAndHighlightChkBook(x, FirstRow)
        {
            // checks every field in row
         
                var CheckAndHighlightRet = true;


                document.getElementById("ddlProduct_" + x).style.borderColor = "";
                document.getElementById("txtChqFrom" + x).style.borderColor = "";
                document.getElementById("txtChqTo" + x).style.borderColor = "";
                document.getElementById("CheqTemplt_" + x).style.borderColor = "";
                $("div#divCheqTemplt_" + x + " input.ui-autocomplete-input").css("borderColor", "");

                var txtSubCatName = document.getElementById("ddlProduct_" + x).value.trim();
                var txtChkFrm = document.getElementById("txtChqFrom" + x).value.trim();
                var txtChkTo = document.getElementById("txtChqTo" + x).value.trim();

                var txtChkTemp = document.getElementById("CheqTemplt_" + x).value;
                // var txtSubCatSize = document.getElementById("ddlRate_" + x).value;

                if (txtChkTemp == "--SELECT TEMPLATE--") {
                    document.getElementById("CheqTemplt_" + x).style.borderColor = "Red";
                    $("div#divCheqTemplt_" + x + " input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divCheqTemplt_" + x + " input.ui-autocomplete-input").select();
                    $("div#divCheqTemplt_" + x + " input.ui-autocomplete-input").focus();
                    // document.getElementById("txtDateTo" + x).focus();
                    CheckAndHighlightRet = false;
                }

                if (txtChkFrm == "") {
                    document.getElementById("txtChqFrom" + x).style.borderColor = "Red";
                    // document.getElementById("txtDateTo" + x).focus();
                    CheckAndHighlightRet = false;
                }
                if (txtChkTo == "") {
                    document.getElementById("txtChqTo" + x).style.borderColor = "Red";
                    // document.getElementById("txtDateTo" + x).focus();
                    CheckAndHighlightRet = false;
                }


                if (txtSubCatName == "") {
                    document.getElementById("ddlProduct_" + x).style.borderColor = "Red";
                    // document.getElementById("txtDateTo" + x).focus();
                    CheckAndHighlightRet = false;
                }




                return CheckAndHighlightRet;
            


        }
        function CheckCloseFun(x)
        {
            OpenCancelView(x);
            return false;
        }
        function OpenCancelView(x) {
            if (document.getElementById("ChequeSts_" + x).value != "0") {

                document.getElementById('<%=HiddenCurrentRow.ClientID %>').value = x;

                var varChkNumFrm = document.getElementById("txtChqFrom" + x).value;
                var varChkNumTo = document.getElementById("txtChqTo" + x).value;
                if (varChkNumFrm != "" && varChkNumTo != "") {
                    var ddl = document.getElementById('<%=ddlCanChkLf.ClientID %>');

                    ddl.innerHTML = "";
                    var array = document.getElementById('tdCanclChknumedit'+x).value;
                    for (var i = varChkNumFrm; i <= varChkNumTo; i++) {
                        
                      
                        if (array.includes(i) == false) {
                            var option = document.createElement("option");
                            option.innerText = i;
                            option.value = i;
                            ddl.appendChild(option);
                        }
                    }
                    $('#dialog_simple').modal('show');
                    document.getElementById("<%=ddlCanChkLf.ClientID%>").focus();
                }
            }
        

            return false;

        }

        function CheckStatusFun(x)
        {
            document.getElementById("tdChkSts" + x).value = document.getElementById("ChequeSts_" + x).value;
            if (document.getElementById("ChequeSts_" + x).value != "0") {
                document.getElementById("ChqClose" + x).disabled = false;
                document.getElementById("SpanDel" + x).disabled = true;
                //$aa('#ChqClose' + x).css('opacity', '1');
                //$aa('#SpanDel' + x).css('opacity', '.3');
            }
            else {
                document.getElementById("ChqClose" + x).disabled = true;
                document.getElementById("SpanDel" + x).disabled = false;

                //$aa('#ChqClose' + x).css('opacity', '.3');
                //$aa('#SpanDel' + x).css('opacity', '1');
            }
            
        }
        function CheckTempFun(x) {
            document.getElementById("tdChkTemp" + x).value = document.getElementById("CheqTemplt_" + x).value;

        }

        function EditListRows(ChkBklId, ChkBkName, ChLfNumFrom, ChLfNumTo,ChkStatus, ChkTemp,CnclCkLeaf)
        {
            addMoreRows(0);
            
            document.getElementById("ddlProduct_" + RowNum).value = ChkBkName;

            document.getElementById("txtChqFrom" + RowNum).value = ChLfNumFrom;
            document.getElementById("txtChqTo" + RowNum).value = ChLfNumTo;
            document.getElementById("ChequeSts_" + RowNum).value = ChkStatus;
            document.getElementById("CheqTemplt_" + RowNum).value = ChkTemp;
            document.getElementById("tdDtlId" + RowNum).value = ChkBklId;
            document.getElementById("tdEvt" + RowNum).value = "UPD";
            document.getElementById("tdChkSts" + RowNum).value = ChkStatus;
            document.getElementById("tdChkTemp" + RowNum).value = ChkTemp;
            
            if (CnclCkLeaf!="")
            document.getElementById("tdCanclChknumedit" + RowNum).value = CnclCkLeaf;
            
            if(ChkStatus!="0")
            {
                document.getElementById("ChqClose" + RowNum).disabled = false;
                document.getElementById("SpanDel" + RowNum).disabled = true;

                //$aa('#ChqClose' + RowNum).css('opacity', '1');
                //$aa('#SpanDel' + RowNum).css('opacity', '.3');

                
            }
            
            $au("#CheqTemplt_" + RowNum).selectToAutocomplete1Letter();
        }


        var RowNum = 0;
        var rowsl_no = 0;
        function addMoreRows(mod) {
            rowsl_no++;
            RowNum++;

            var $options = $aa("#cphMain_ddlChqTempDtls > option").clone();

              var recRow = '<tr  id="rowId_' + RowNum + '" >';
              recRow += '<td   id="tdidGrpDtls' + RowNum + '" style="display: none" >' + RowNum + '</td>';



              recRow += '<td style="display: none"><input disabled id=\"txtSlno' + RowNum + '\"  style=\"width:100%;\"  name=\"txtSlno' + RowNum + '\"  maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\" class=\"form-control fg2_inp1\" value=\"' + rowsl_no + '\" /></td>';


              recRow += '<td class=" tr_l"><div  id=\"divProduct_' + RowNum + '\"> <input id=\"ddlProduct_' + RowNum + '\" name=\"ddlProduct_' + RowNum + '\"    maxlength=\"90\"  onkeydown=\"return isTag(event)\"   onkeypress=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in\"></div> </td> ';//onchange=\"ChangeProduct(' + RowNum + ')\"
             

              recRow += '<td class=" tr_l"><input id=\"txtChqFrom' + RowNum + '\"  name=\"txtChqFrom' + RowNum + '\"  maxlength=\"6\" onkeypress=\"return isNumber(event)\"  onblur=\"return BlurNotNumber(\'txtChqFrom' + RowNum + '\',' + RowNum + ');\" type=\"text\"  class=\"tb_inp_1 tb_in\" /></td>';
              recRow += '<td class=" tr_l"><input  style=\"width:100%;\" id=\"txtChqTo' + RowNum + '\" name=\"txtChqTo' + RowNum + '\"  maxlength=\"6\" onkeypress=\"return isNumber(event)\"  onblur=\"return BlurNotNumber(\'txtChqTo' + RowNum + '\',' + RowNum + ');\" type=\"text\"  class=\"tb_inp_1 tb_in\" /></td>';

              recRow += '<td ><div  > <select class=\"tb_inp_1 tb_in\" id=\"ChequeSts_' + RowNum + '\" onchange=\"return CheckStatusFun(' + RowNum + ');\"      onkeydown=\"return isTag(event)\"   onkeypress=\"return DisableEnter(event)\" ><option value="0">New</option><option value="1">Open</option><option value="2">Closed</option></select></div> </td> ';

              recRow += '<td "><div  id=\"divCheqTemplt_' + RowNum + '\"> <select class=\"tb_inp_1 tb_in\" id=\"CheqTemplt_' + RowNum + '\"  onchange=\"return CheckTempFun(' + RowNum + ');\"     onkeydown=\"return isTag(event)\"   onkeypress=\"return DisableEnter(event)\" ></select></div> </td> ';

            


             

              recRow += '<td id="tdClose' + RowNum + '" ><button disabled class=\"btn act_btn bn3\"  id=\"ChqClose' + RowNum + '\"  title=\"Cancel\" onclick=\"return CheckCloseFun(' + RowNum + ');\" ><i class="fa fa-times"></i></button></td>';//onclick=\"return CheckCloseFun(' + RowNum + ');\"

             recRow += '<td class="td1">';
             recRow += '<div class="btn_stl1">';
             recRow += '<button id=\"SpanAdd' + RowNum + '\" class="btn act_btn bn2"  onclick=\"return CheckaddMoreRows(' + RowNum + ');\" title="Add">';
             recRow += '<i class="fa fa-plus"></i></button>';
             recRow += '</button>';
             recRow += '<button id=\"SpanDel' + RowNum + '\" class="btn act_btn bn3" " onclick=\"return removeRowCheckBook(' + RowNum + ',\'Are you sure you want to cancel this cheque book?\');\" title="Delete">';
             recRow += ' <i class="fa fa-trash"></i>';
             recRow += ' </button>';
             recRow += '</div>';
             recRow += '</td>';
                



              recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" value="INS" style="display:none;"  id="tdEvt' + RowNum + '" name="tdEvt' + RowNum + '" placeholder=""/></td>';
              recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdDtlId' + RowNum + '" name="tdDtlId' + RowNum + '" placeholder=""/><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdGrp' + RowNum + '" name="tdDtlIdGrp' + RowNum + '" placeholder=""/></td>';
              recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdInxBank' + RowNum + '" name="tdInxBank' + RowNum + '" placeholder=""/> </td>';

              recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdCanclLeaf' + RowNum + '" name="tdCanclLeaf' + RowNum + '" placeholder=""/> </td>';
              recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdCanclReas' + RowNum + '" name="tdCanclReas' + RowNum + '" placeholder=""/> </td>';

              recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;" name=\"tdChkSts' + RowNum + '\" value=\"0\" id="tdChkSts' + RowNum + '"  placeholder=""/> </td>';
              recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;" name=\"tdChkTemp' + RowNum + '\" value=\"0\"  id="tdChkTemp' + RowNum + '"  placeholder=""/> </td>';

              recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdCanclChknumedit' + RowNum + '" name="tdCanclChknumedit' + RowNum + '" placeholder=""/> </td>';


              recRow += '</tr>';
              jQuery('#TableaddedRows').append(recRow);
          
              $("#CheqTemplt_" + RowNum).append($options);
              if(mod==1)
              $au("#CheqTemplt_" + RowNum).selectToAutocomplete1Letter();

        }

        var $aa = jQuery.noConflict();



        $aa(document).ready(function () {
          //  addMoreRows();
        });

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

        function BlurNotNumber(obj, Row) {
          
            var txt = document.getElementById(obj).value;
            if (txt != "") {

                if (isNaN(txt)) {

                    document.getElementById(obj).value = "";
                    document.getElementById(obj).focus();
                    return false;

                }
                else {
                    if (txt.indexOf(".") > 0) {
                        document.getElementById(obj).value = "";
                        document.getElementById(obj).focus();
                        return false;

                    }
                    if (txt < 0) {
                        document.getElementById(obj).value = "";
                        document.getElementById(obj).focus();
                        return false;
                    }
                }
            }
            var text = document.getElementById(obj).value;
            var replaceText1 = text.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2;

            var txtChkFrm = document.getElementById("txtChqFrom" + Row).value;
            var txtChkTo = document.getElementById("txtChqTo" + Row).value;

            if (document.getElementById("txtChqFrom" + Row).value != "" && document.getElementById("txtChqTo" + Row).value != "") {
                var varChkNumFrm = parseFloat(document.getElementById("txtChqFrom" + Row).value);
                var varChkNumTo = parseFloat(document.getElementById("txtChqTo" + Row).value);

                if (txtChkTo.length > "6") {
                    $("#divWarning").html("Maximum length allowed is 6 digits for a cheque leaf number");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("txtChqTo" + Row).value = "";
                    document.getElementById("txtChqTo" + x).style.borderColor = "Red";
                    document.getElementById("txtChqTo" + x).focus();
                }
                if (txtChkFrm.length > "6") {
                    $("#divWarning").html("Maximum length allowed is 6 digits for a cheque leaf number");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("txtChqFrom" + Row).value = "";
                    document.getElementById("txtChqFrom" + x).style.borderColor = "Red";
                    document.getElementById("txtChqFrom" + x).focus();
                }

                if (varChkNumFrm > varChkNumTo) {
                    $("#divWarning").html("Cheque leaf number from should be less than cheque leaf number to.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("txtChqTo" + Row).value = "";
                    document.getElementById("txtChqTo" + x).style.borderColor = "Red";
                    document.getElementById("txtChqTo" + x).focus();
                }

            }
        }

    

        function CloseCancelView() {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close  without completing cancellation process??",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {                  
                    $('#dialog_simple').modal('hide');
                }
                else {
                    return false;
                }
            });
            return false;

           
        }


        //validation when cancel process
        function ValidateCancelReason() {
            // replacing < and > tags
            var ret = true;
            var currentrow = document.getElementById('<%=HiddenCurrentRow.ClientID %>').value;

            var ChkLeaf = $noCon('#cphMain_ddlCanChkLf').val();

            document.getElementById("lblErrMsgCancelReason").style.display = "none";

            var NameWithoutReplace = document.getElementById("<%=txtCnclReason.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtCnclReason.ClientID%>").value = replaceText2;          

             document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "";
            var Reason = document.getElementById("<%=txtCnclReason.ClientID%>").value.trim();
            if (ChkLeaf ==null) {
               

                document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                document.getElementById("lblErrMsgCancelReason").style.display = "";
                $("div.war").fadeIn(200).delay(500).fadeOut(400);
                document.getElementById("<%=ddlCanChkLf.ClientID%>").style.borderColor = "Red";
                ret = false;
                  return false;
              }

             if (Reason == "") {
                 document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                 document.getElementById("lblErrMsgCancelReason").style.display = "";
                 $("div.war").fadeIn(200).delay(500).fadeOut(400);

                 document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                 ret = false;
                 return false;
             }
            if (ret == true)
            {                
                document.getElementById('tdCanclReas' + currentrow).value = ChkLeaf;
                document.getElementById('tdCanclLeaf' + currentrow).value = Reason;      
                $('#dialog_simple').modal('hide');
            }
            return false;           
        }


      

    </script>
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

        function CheckSpecification() {

            if (document.getElementById("<%=HiddenViewSts.ClientID%>").value != "1") {

                     if (document.getElementById("<%=HiddenBusinessSpecific.ClientID%>").value == "0" && document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "0") {

                         document.getElementById("cphMain_txtBankName").disabled = false;
                         document.getElementById("cphMain_txtAccNo").disabled = false;

                         document.getElementById("cphMain_txtAddress").disabled = false;
                         document.getElementById("cphMain_txtBankSwiftCode").disabled = false;

                         document.getElementById("cphMain_txtIBan").disabled = false;
                         document.getElementById("cphMain_txtBankShortName").disabled = false;
                         document.getElementById("cphMain_chkHCM").disabled = false;
                         document.getElementById("cphMain_cbxStatus").disabled = false;


                         document.getElementById("cphMain_cbxLedgerSts").disabled = true;

                     
                         document.getElementById("cphMain_cbxCsCntrSts").disabled = true;

                         if (document.getElementById("cphMain_HiddenTaxEnable").value == "1") {
                        

                             document.getElementById("cphMain_radioTDSyes").disabled = true;
                             document.getElementById("cphMain_radioTDSno").disabled = true;
                             document.getElementById("cphMain_radioTCSyes").disabled = true;
                             document.getElementById("cphMain_radioTCSno").disabled = true;

                             document.getElementById("cphMain_ddlTDS").disabled = true;
                             document.getElementById("cphMain_ddlTCS").disabled = true;

                      



                         }
                         document.getElementById("cphMain_txtOpenBalanceDeb").disabled = true;
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

                    document.getElementById("cphMain_txtBankName").disabled = true;
                    document.getElementById("cphMain_txtAccNo").disabled = true;

                    document.getElementById("cphMain_txtAddress").disabled = true;
                    document.getElementById("cphMain_txtBankSwiftCode").disabled = true;

                    document.getElementById("cphMain_txtIBan").disabled = true;
                    document.getElementById("cphMain_txtBankShortName").disabled = true;
                    document.getElementById("cphMain_chkHCM").disabled = true;
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


                    document.getElementById("cphMain_txtBankName").disabled = false;
                    document.getElementById("cphMain_txtAccNo").disabled = false;

                    document.getElementById("cphMain_txtAddress").disabled = false;
                    document.getElementById("cphMain_txtBankSwiftCode").disabled = false;

                    document.getElementById("cphMain_txtIBan").disabled = false;
                    document.getElementById("cphMain_txtBankShortName").disabled = false;
                    document.getElementById("cphMain_chkHCM").disabled = false;
                    document.getElementById("cphMain_cbxStatus").disabled = false;


                    document.getElementById("cphMain_cbxLedgerSts").disabled = true;

                    document.getElementById("cphMain_cbxCsCntrSts").disabled = true;

                    if (document.getElementById("cphMain_HiddenTaxEnable").value == "1") {


                        document.getElementById("cphMain_radioTDSyes").disabled = true;
                        document.getElementById("cphMain_radioTDSno").disabled = true;
                        document.getElementById("cphMain_radioTCSyes").disabled = true;
                        document.getElementById("cphMain_radioTCSno").disabled = true;

                        document.getElementById("cphMain_ddlTDS").disabled = true;
                        document.getElementById("cphMain_ddlTCS").disabled = true;





                    }
                    document.getElementById("cphMain_txtOpenBalanceDeb").disabled = true;
                    document.getElementById("cphMain_typdebit").disabled = true;

                    document.getElementById("cphMain_typecredit").disabled = true;


                }

                else if (document.getElementById("<%=HiddenBusinessSpecific.ClientID%>").value == "1" && document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "1") {


                    document.getElementById("cphMain_txtBankName").disabled = false;
                    document.getElementById("cphMain_txtAccNo").disabled = false;

                    document.getElementById("cphMain_txtAddress").disabled = false;
                    document.getElementById("cphMain_txtBankSwiftCode").disabled = false;

                    document.getElementById("cphMain_txtIBan").disabled = false;
                    document.getElementById("cphMain_txtBankShortName").disabled = false;
                    document.getElementById("cphMain_chkHCM").disabled = false;
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
                                url: "gen_Bank_Master.aspx/CreateCodeFormate",
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


            if (document.getElementById("cphMain_HiddenViewSts").value != "1") {

                if (document.getElementById("cphMain_cbxLedgerSts").checked == true) {

                    
                    document.getElementById("cphMain_cbxCsCntrSts").disabled = false;
                    if (document.getElementById("cphMain_cbxCsCntrSts").checked == true) {


                        if (document.getElementById("<%=HiddenCodeFormate.ClientID%>").value == "1") {
                            if (document.getElementById("<%=HiddenCodeSts.ClientID%>").value == "1") {
                                document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = false;
                            }

                        }

                        $("div#divCC input.ui-autocomplete-input").prop('disabled', false);

                        document.getElementById("cphMain_ddlCC").disabled = false;
                        document.getElementById("tc_1").style.display = "block";
                        
                        document.getElementById("cphMain_rdIncome").disabled = false;
                        document.getElementById("cphMain_rdExpense").disabled = false;



                    }
                    else {
                        $("div#divCC input.ui-autocomplete-input").val("--SELECT COST GROUP--");
                        document.getElementById("cphMain_ddlCC").value = "--SELECT COST GROUP--";
                        document.getElementById("cphMain_rdIncome").checked = true;
                        document.getElementById("cphMain_ddlCC").disabled = true;
                        $("div#divCC input.ui-autocomplete-input").prop('disabled', true);
                        document.getElementById("cphMain_rdIncome").disabled = true;
                        document.getElementById("cphMain_rdExpense").disabled = true;
                        document.getElementById("tc_1").style.display = "none";
                        if (document.getElementById("<%=HiddenCodeSts.ClientID%>").value == "1") {
                            document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;
                            document.getElementById("<%=txtCostCntrCode.ClientID%>").value = "";
                        }

                       
                    }
                    //if (document.getElementById("cphMain_HiddenTaxEnable").value == "1") {



                    //    document.getElementById("cphMain_radioTDSyes").disabled = false;
                    //    document.getElementById("cphMain_radioTDSno").disabled = false;

                    //    if (document.getElementById("cphMain_radioTDSno").checked == false) {
                    //        document.getElementById("cphMain_ddlTDS").disabled = false;
                    //    }
                    //    else {
                    //        document.getElementById("cphMain_ddlTDS").disabled = true;
                    //    }

                    //    if (document.getElementById("cphMain_radioTCSno").checked == false) {
                    //        document.getElementById("cphMain_ddlTCS").disabled = false;
                    //    }
                    //    else {
                    //        document.getElementById("cphMain_ddlTCS").disabled = true;
                    //    }

                    //    document.getElementById("cphMain_radioTCSyes").disabled = false;
                    //    document.getElementById("cphMain_radioTCSno").disabled = false;

                     
                       
                    //}
                    document.getElementById("cphMain_txtOpenBalanceDeb").disabled = false;
                    
                    document.getElementById("cphMain_DandC").style.display = "block";
                    document.getElementById("cphMain_typdebit").disabled = false;
                    document.getElementById("cphMain_typecredit").disabled = false;



                    if (document.getElementById("<%=HiddenCodeSts.ClientID%>").value == "1") {

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
                            if (document.getElementById("<%=HiddenDefaultAcntGrpId.ClientID%>").value != "") {
                                ActGrpId = document.getElementById("<%=HiddenDefaultAcntGrpId.ClientID%>").value;
                            }

                            if (str == 1) {
                                if (ActGrpId != "" && strUserID != '') {

                                    $.ajax({
                                        type: "POST",
                                        async: false,
                                        contentType: "application/json; charset=utf-8",
                                        url: "gen_Bank_Master.aspx/LoadLedgerCode1",
                                        data: '{strUserID: "' + strUserID + '",ActGrpId: "' + ActGrpId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '"}',

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

                    document.getElementById("cphMain_cbxCsCntrSts").checked = false;
                    document.getElementById("cphMain_cbxCsCntrSts").disabled = true;
                    $("div#divCC input.ui-autocomplete-input").val("--SELECT COST GROUP--");
                    document.getElementById("cphMain_ddlCC").value = "--SELECT COST GROUP--";
                    document.getElementById("cphMain_rdIncome").checked = true;
                    document.getElementById("cphMain_ddlCC").disabled = true;
                    $("div#divCC input.ui-autocomplete-input").prop('disabled', true);
                    document.getElementById("cphMain_rdIncome").disabled = true;
                    document.getElementById("cphMain_rdExpense").disabled = true;
                    document.getElementById("tc_1").style.display = "none";
                    //if (document.getElementById("cphMain_HiddenTaxEnable").value == "1") {

                    //    document.getElementById("cphMain_radioTDSyes").checked = false;
                    //    document.getElementById("cphMain_radioTDSno").checked = true;
                    //    document.getElementById("cphMain_radioTCSyes").checked = false;
                    //    document.getElementById("cphMain_radioTCSno").checked = true;

                    //    document.getElementById("cphMain_radioTDSyes").disabled = true;
                    //    document.getElementById("cphMain_radioTDSno").disabled = true;
                    //    document.getElementById("cphMain_radioTCSyes").disabled = true;
                    //    document.getElementById("cphMain_radioTCSno").disabled = true;

                    //    document.getElementById("cphMain_ddlTDS").disabled = true;
                    //    document.getElementById("cphMain_ddlTCS").disabled = true;

                    //    document.getElementById("cphMain_ddlTCS").value = "--SELECT TCS--";
                    //    document.getElementById("cphMain_ddlTDS").value = "--SELECT TDS--";



                    //}
                    document.getElementById("cphMain_txtOpenBalanceDeb").disabled = true;
                    document.getElementById("cphMain_DandC").style.display = "none";
                    document.getElementById("cphMain_typdebit").disabled = true;
                    document.getElementById("cphMain_typdebit").checked = true;
                    document.getElementById("cphMain_typecredit").disabled = true;
                    document.getElementById("cphMain_txtOpenBalanceDeb").value = "";

                 
                    if (document.getElementById("<%=HiddenCodeSts.ClientID%>").value == "1") {
                        document.getElementById("<%=txtLedgrCode.ClientID%>").disabled = true;
                        document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;
                        document.getElementById("<%=txtCostCntrCode.ClientID%>").value = "";
                        document.getElementById("<%=txtLedgrCode.ClientID%>").value = "";
          
                    }


                }
            }
        }
        function changeAmnt(obj) {
            var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
            var ObjVal = document.getElementById(obj).value.trim();
            if (FloatingValueMoney != "" && ObjVal != "") {
                ObjVal = parseFloat(ObjVal);
                document.getElementById(obj).value = ObjVal.toFixed(FloatingValueMoney);
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

           addCommasOpenBlnc(document.getElementById("cphMain_txtOpenBalanceDeb").value);
        }

       function txtCCclick(x) {
           changeAmnt(x);
           if (document.getElementById("cphMain_txtOpenBalanceDeb").value != "") {
            //   document.getElementById("cphMain_DandC").style.display = "block";
           }
           else {

             //  document.getElementById("cphMain_DandC").style.display = "none";
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
              // addCommas(document.getElementById("cphMain_txtCreditLimit").value);
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
               }
    </script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenCancelReason" runat="server" />
     <asp:HiddenField ID="hiddenEditMode" runat="server" />
    <asp:HiddenField ID="hiddenEditBnkId" runat="server" />
    <asp:HiddenField ID="hiddenPreviousValueChange" runat="server" />
     <asp:HiddenField ID="hiddenBnkIdCancel" runat="server" />
    <asp:HiddenField ID="hiddenCheckBoxValue" runat="server" />
     <asp:HiddenField ID="hiddenRoleRecall" runat="server" />
    <asp:HiddenField ID="hiddenCkBookCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldView" runat="server" />
    <asp:HiddenField ID="HiddenAddChkBook" runat="server" />

      <asp:HiddenField ID="HiddenCurrentRow" runat="server" />
      <asp:HiddenField ID="hiddenEdit" runat="server" />

      <asp:HiddenField ID="HiddenFieldDecimalCnt" runat="server" />
     <asp:HiddenField ID="HiddenTaxEnable" runat="server" />
       <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
         <asp:HiddenField ID="HiddenFieldLedgerId" runat="server" /> 
          <asp:HiddenField ID="hiddenCostCntrId" runat="server" /> 
      <asp:HiddenField ID="HiddenCostCntrCnclId" runat="server" /> 
      <asp:HiddenField ID="HiddenAcntGrpSts" runat="server" /> 
      <asp:HiddenField ID="HiddenViewSts" runat="server" /> 
          <asp:HiddenField ID="HiddenAccountSpecific" runat="server" /> 
      <asp:HiddenField ID="HiddenBusinessSpecific" runat="server" /> 
      <asp:HiddenField ID="HiddenAcntGrpChngSts" runat="server" /> 
          <asp:HiddenField ID="hiddenBankPostAdd" runat="server" /> 
      <asp:HiddenField ID="HiddenCodeSts" runat="server" /> 
      <asp:HiddenField ID="HiddenCodeFormate" runat="server" />
          <asp:HiddenField ID="HiddenDefaultAcntGrpId" runat="server" />
    <asp:HiddenField ID="hiddenCodeNumberFrmt" runat="server" />


  

  <ol class="breadcrumb">
     <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li><a href="gen_Bank_Master_List.aspx">Bank</a></li>
      <li class="active" id="currPage" runat="server">Add Bank</li>
  </ol>
     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>

  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">  
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">ADD BANK</h2>
 <!---------------------------==============frame===============---------------------------------> 
      <div class="col-md-9 mr_at flt_l colpa_0">
        <div class="form-group fg4 sa_o_fg5 sa_480">
          <label for="email" class="fg2_la1">Bank Name:<span class="spn1">*</span></label>
          <input id="txtBankName" runat="server" maxlength="100" type="text" class="form-control fg2_inp1 inp_mst"  placeholder="Bank Name" name=""/>
        </div>
        <div class="form-group fg4 sa_o_fg5 sa_480">
          <label for="email" class="fg2_la1">Bank Short Name:<span class="spn1"></span></label>
          <input id="txtBankShortName"  runat="server"   maxlength="100" type="text" class="form-control fg2_inp1"  placeholder="Bank Short Name" name=""/>
        </div>
        <div class="form-group fg4 sa_o_fg5 sa_480">
          <label for="email" class="fg2_la1">Account#:<span class="spn1"></span></label>
          <input id="txtAccNo"  runat="server"   maxlength="100" type="text" class="form-control fg2_inp1"  placeholder="Account#" name=""/>
        </div> 
        <div class="form-group fg4 sa_o_fg5 sa_480">
          <label for="email" class="fg2_la1">Swift Code:<span class="spn1"></span></label>
          <input id="txtBankSwiftCode"  runat="server"   maxlength="100" type="text" class="form-control fg2_inp1"  placeholder="Swift Code" name=""/>
        </div>

        <div class="form-group fg4 sa_o_fg5 sa_480">
          <label for="email" class="fg2_la1">IBAN#:<span class="spn1"></span></label>
          <input id="txtIBan"  runat="server"   maxlength="100" type="text" class="form-control fg2_inp1"  placeholder="IBAN#" name=""/>
        </div>

        <div class="form-group fg7 fg2_mr sa_o_fg5 sa_480">
          <label for="email" class="fg2_la1 pad_l">HCM Accessibility:<span class="spn1"></span></label>
          <div class="check1">
            <label class="switch">
              <input type="checkbox" id="chkHCM"  runat="server" checked="true"/>
              <span class="slider_tog round"></span>
            </label>
          </div>
        </div>

        <div class="form-group fg7 fg2_mr sa_o_fg5 sa_480">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
          <div class="check1">
            <label class="switch">
              <input type="checkbox" id="cbxStatus"  runat="server" checked="true"/>
              <span class="slider_tog round"></span>
            </label>
          </div>
        </div>

          <div class="form-group fg4 sa_o_fg5 sa_480" style="display:none">
          <label for="email" class="fg2_la1">IFSC Codee:<span class="spn1"></span></label>
          <input id="txtIfscCode"  runat="server"   maxlength="100" type="text" class="form-control fg2_inp1"  placeholder="IFSC Code" name=""/>
        </div>

     </div>
     <div class="col-md-3 mr_at flt_l colpa_0">
        <div class="fg12 tr_l sa_o_fg5 sa_480" style="margin-top: -20px;">
          <div class="form-group">
            <label for="email" class="fg2_la1">Address: <span class="spn1">&nbsp;</span></label>
            <textarea id="txtAddress" runat="server"   maxlength="500" rows="3" cols=31 class="form-control flt_l" placeholder="Address"></textarea>
          </div>
       </div>
     </div>
      
      <div class="clearfix"></div>
      <div class="free_sp"></div>
      <div class="devider"></div>

 <div id="divLedgerBlock" runat="server">

        <div class="form-group fg2 sa_o_fg5 sa_480">
          <label for="email" class="fg2_la1 pad_l">Consider as a Ledger:<span class="spn1"></span></label>
          <div class="check1">
            <label class="switch" onclick="suply()">
              <input type="checkbox"  id="cbxLedgerSts"  runat="server" onchange="IncrmntConfrmCounter();"  onkeypress="return isTag(event)" onclick="ledgerStsClick(1);"/>
              <span class="slider_tog round"></span>
            </label>
          </div>
        </div>
        <div class="form-group fg2 sa_480">
          <label for="email" class="fg2_la1">Opening Balance<span class="spn1"></span>
          </label>
          <input  id="txtOpenBalanceDeb"  runat="server"  maxlength="10"    onblur="return AmountChecking('cphMain_txtOpenBalanceDeb');" onclick="return IncrmntConfrmCounter();" onkeypress="return isDecimalNumber(event,'cphMain_txtOpenBalanceDeb')" onkeydown="return isDecimalNumber(event,'cphMain_txtOpenBalanceDeb')" type="text" class="form-control fg2_inp1 tr_r" placeholder="0.00" disabled="">
        </div>

        <div class="fg2 sa_fg2 sa_480"  id="DandC" runat="server" style="display:none;">
             <label class="fg2_la1">&nbsp;</label>
          <div class="form-group fogp rati_1">
            <label for="email" class="fg2_la1">
              <input type='radio' name="balance" checked="" runat="server" id="typdebit" onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();"/>Debit
              <p class="nbsp1">&nbsp;</p>
            </label>
          </div>
          <div class="form-group fogp rati_1">
            <label for="email" class="fg2_la1">
            <input type='radio' name="balance" runat="server"  id="typecredit"  onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();"/>
            Credit</label>
          </div>
        </div>

        <div class="form-group fg2 sa_o_fg5 sa_480" id="divCode" runat="server">
          <label for="email" class="fg2_la1">Ledger code:<span class="spn1"></span></label>
          <input  type="text" class="form-control fg2_inp1" placeholder="Ledger code" disabled="" id="txtLedgrCode"  runat="server"  maxlength="50"    autocomplete="off"  onkeypress="return DisableEnter(event)"  onkeyup="textCounter(cphMain_txtLedgrCode,50)">
        </div>

        <div class="clearfix"></div>
        <div class="devider"></div>

        <div id="divCstCtr" runat="server" class="form-group fg2 sa_o_fg5 sa_480">
          <label for="email" class="fg2_la1 pad_l">Consider as a Cost Centre:<span class="spn1"></span></label>
          <div class="check1">
            <label class="switch" onclick="ccnt()">
              <input type="checkbox"  disabled="" id="cbxCsCntrSts"  runat="server"    onchange="IncrmntConfrmCounter();"  onkeypress="return isTag(event)" onclick="ledgerStsClick(0);">
              <span class="slider_tog round"></span>
            </label>
          </div>
        </div>

        <div class="form-group fg2 sa_o_fg5 sa_480" id="divCC">
          <label for="email" class="fg2_la1">Cost Group:<span class="spn1">*</span></label>
          <select class="form-control fg2_inp1 inp_mst" disabled="" id="ddlCC"   onkeypress="return isTag(event)" onkeydown="return isTag(event)"  runat="server">
          </select>
        </div>

        <div class="fg2 sa_o_fg5 sa_480" id="tc_1" style="display:none;">
          <label class="form1 mar_bo">
            <input type="checkbox" class="hidden" />
            Cost Centre Nature<span class="spn1"></span>
          </label>
          <div class="form-group fogp rati_1">
            <label for="email" class="fg2_la1">
            <input type='radio' name="gender" checked="" runat="server" id="rdIncome"  onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();"/>
            Income</label>
          </div>
          <div class="form-group fogp rati_1">
            <label for="email" class="fg2_la1">
            <input type='radio' name="gender" disabled="" runat="server"  id="rdExpense"  onkeypress="return isTag(event)" onchange="return  IncrmntConfrmCounter();"/>
            Expense</label>
          </div>
        </div>
        <div class="form-group fg2 sa_o_fg5 sa_480" id="divCode1" runat="server">
          <label for="email" class="fg2_la1">Cost Center Code:<span class="spn1"></span></label>
          <input type="text" class="form-control fg2_inp1" placeholder="Cost Center Code" disabled="" id="txtCostCntrCode"  runat="server"  maxlength="50"   onclick="IncrmntConfrmCounter();" autocomplete="off"  onkeypress="return DisableEnter(event)"  onkeyup="textCounter(cphMain_txtCostCntrCode,50)" >
        </div>
             
        <div class="clearfix"></div>
        <div class="devider"></div>

  </div>



        <div class="table_box tb_scr r_1024">
             <asp:DropDownList ID="ddlChqTempDtls"  style="display:none"   runat="server">
                    </asp:DropDownList>

          <table class="table table-bordered tbl_1024">
            <thead class="thead1">
              <tr>
               <th class="th_b4 tr_l">Cheque Book</th>
                <th class="th_b4 tr_l">Cheque#: From</th>
                <th class="th_b4 tr_l">Cheque#: To</th>
                <th class="th_b1">Status </th>
                <th class="th_b4 tr_c">Cheque Template</th>
                <th class="th_b4 tr_c">Cancel Cheque Leaf</th>

                <th class="th_b6">Actions</th>
              </tr>
            </thead>
          <tbody id="TableaddedRows">
             

          </tbody>
          </table>
        </div>
             
        <div class="clearfix"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">

                <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
                <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
                    

          </div>

         
        </div>
          
<!----------------------------================frame================------------------------------->          
      </div>
      

<!-------working area_closed---->

    </div>    
  </div>


     <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static"    role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document" id="divCancelPopUp">
            <div class="modal-content">
                <div class="modal-header mo_hd1">
                    <h5 class="modal-title" id="H1">Cancel Cheque Leaf</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>
                    <div class="col-md-12">
          <label for="email" class="fg2_la1">Cheque Leaf<span class="spn1">*</span>:</label>
                      <asp:DropDownList ID="ddlCanChkLf" data-placeholder="select" multiple="mutiple" class="form-control select2" runat="server" style="width:100%">
                                            </asp:DropDownList>
                        </div>
                     <div class="col-md-12">
          <label for="email" class="fg2_la1">Cancel Reason<span class="spn1">*</span>:</label>
                    <textarea id="txtCnclReason" runat="server" placeholder="Cancel Reason"  rows="4" cols="50" class="form-control" onblur="RemoveTag('cphMain_txtCnclReason')" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" style="resize: none;"></textarea>
               </div>
                          </div>
                <div class="modal-footer">

                   <asp:Button ID="btnRsnSave" Text="Save" class="btn btn-success" runat="server"  OnClientClick="return ValidateCancelReason();" />                   
                   <button type="button" id="btnRsnCncl" onclick="return CloseCancelView();" class="btn btn-danger" data-dismiss="modal">Close</button>

                   
                </div>
            </div>
        </div>
    </div>
     <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">

       <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                <asp:Button ID="btnClearF" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2 bt_b" Text="Clear"/>
                <asp:Button ID="btnCancelF" runat="server" class="btn sub4 bt_b" Text="Cancel" OnClientClick="return ConfirmMessage();"  />


   
  </div>
  
</div>
    <a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
<i class="fa fa-save"></i>
</a>

       <!---back_button_fixed_section--->
  <a href="#" type="button" class="list_b" title="Back to List" onclick="return ConfirmMessage();" id="divList" runat="server">
    <i class="fa fa-arrow-circle-left"></i>
  </a>
<!---back_button_fixed_section--->
  <!--save_pop up_open-->
<script>
    function opensave() {
        document.getElementById("cphMain_mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("cphMain_mySave").style.width = "0px";
    }
</script>
<!--save_pop up_closed-->
    <style>
         .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
            border: 1px solid #B0BECA;
            max-height: 140px;
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
</asp:Content>
