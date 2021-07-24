<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Sales_Master.aspx.cs" Inherits="FMS_FMS_Master_fms_Sales_Master_fms_Sales_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
     <script>
         var $au2 = jQuery.noConflict();
         $au2(function () {
            
             $au2(".ddl").selectToAutocomplete1Letter();
             $au2("div#divddlLedger input.ui-autocomplete-input").select();
         });
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
  
    
    <script>


        function OpenComment(StrId) {
            RemarkShow(StrId);
            $('#dialog_simple').modal('show');
            $('#dialog_simple').on('shown.bs.modal', function () {
                document.getElementById("txtProductRemark" + StrId).focus();
            });
         
            return false;
        }
        function AddRemarks(StrId) {
            document.getElementById('tdProductRemark' + StrId).innerHTML = document.getElementById('txtProductRemark' + StrId).value;
            document.getElementById('txtRemark' + StrId).value = document.getElementById('tdProductRemark' + StrId).innerHTML;
            $('#dialog_simple').modal('hide');


            $('#dialog_simple').on('hidden.bs.modal', function () {
                $('#DivAddComment_' + StrId).focus();
            });
        }

        function RemarkShow(RowId) {

            var recRow = "";
            if (document.getElementById("<%=HiddenviewSts.ClientID%>").value == "1") {
                if (document.getElementById("tdProductRemark" + RowId).innerHTML != "") {
                    recRow += '<textarea name="txtProductRemark' + RowId + '" rows="2" disabled cols="20" id="txtProductRemark' + RowId + '" class="form-control" onblur="RemoveTag(\'txtProductRemark' + RowId + '\')" onkeypress="return isTag(event)" onkeydown="textCounter(txtProductRemark' + RowId + ',450)" onkeyup="textCounter(txtProductRemark' + RowId + ',450)" >' + document.getElementById("tdProductRemark" + RowId).innerHTML + '</textarea>';
                }
                else
                    recRow += '<textarea name="txtProductRemark' + RowId + '" rows="2" cols="20" disabled id="txtProductRemark' + RowId + '"  class="form-control" onblur="RemoveTag(\'txtProductRemark' + RowId + '\')" onkeypress="return isTag(event)" onkeydown="textCounter(txtProductRemark' + RowId + ',450)" onkeyup="textCounter(txtProductRemark' + RowId + ',450)"></textarea>';
                recRow += '<div class="modal-footer">';
                //recRow += '<div class="ui-dialog-buttonset">';
                recRow += '<button type="button" id="btnCancelRsnSave" disabled onclick="return AddRemarks(' + RowId + ');" class="btn btn-success">Add</button>';
                recRow += '<button type="button" disabled id="btnCnclRsn" onclick="return CloseCancelView(' + RowId + ');"class="btn btn-danger"  data-dismiss="modal" >Cancel</button></div>';
            }
            else {
                if (document.getElementById("tdProductRemark" + RowId).innerHTML != "") {
                    recRow += '<textarea name="txtProductRemark' + RowId + '" rows="2" cols="20" id="txtProductRemark' + RowId + '" class="form-control" onblur="RemoveTag(\'txtProductRemark' + RowId + '\')" onkeypress="return isTag(event)" onkeydown="textCounter(txtProductRemark' + RowId + ',450)" onkeyup="textCounter(txtProductRemark' + RowId + ',450)" >' + document.getElementById("tdProductRemark" + RowId).innerHTML + '</textarea>';
                }
                else
                    recRow += '<textarea name="txtProductRemark' + RowId + '" rows="2" cols="20" id="txtProductRemark' + RowId + '"  class="form-control" onblur="RemoveTag(\'txtProductRemark' + RowId + '\')" onkeypress="return isTag(event)" onkeydown="textCounter(txtProductRemark' + RowId + ',450)" onkeyup="textCounter(txtProductRemark' + RowId + ',450)" ></textarea>';
                //recRow += '</div>';
                recRow += '<div class="modal-footer">';
                recRow += '<button type="button" id="btnCancelRsnSave" onclick="return AddRemarks(' + RowId + ');" class="btn btn-success" >Add</button>';
                recRow += '<button type="button" id="btnCnclRsn" onclick="return CloseCancelView(' + RowId + ');"class="btn btn-danger" data-dismiss="modal"> Cancel</button></div>';
            }

             //recRow += '</tr>';
             //jQuery('#TableaddedRows').append(recRow);
            $("#divCancelPopUp").html(recRow);
        }



        function CloseCancelView(RowId) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to close?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        $('#dialog_simple').modal('hide');
                        $('#dialog_simple').on('hidden.bs.modal', function () {
                            $('#DivAddComment_' + RowId).focus();
                        });
                        return false;
                    }
                    else {
                        $('#dialog_simple').modal('show');
                        $('#dialog_simple').on('shown.bs.modal', function () {
                            document.getElementById("txtProductRemark" + RowId).focus();
                        });
                        return false;
                    }
                });
                return false;
        }
    </script>
        <script>
            function AutoCompleteTextBox(TextId, Rowx, sts) {
                $noCon(TextId + Rowx).autocomplete({
                    source: function (request, response) {

                        var strOrgId = '<%=Session["ORGID"]%>';
                        var strCorpId = '<%=Session["CORPOFFICEID"]%>';
                        var objSearchMstr = {};
                        objSearchMstr.prefix = request.term;
                        objSearchMstr.strOrgid = strOrgId;
                        objSearchMstr.strCorpid = strCorpId;
                        $noCon.ajax({
                            url: '<%=ResolveUrl("fms_Sales_Master.aspx/DropdownProductBind") %>',
                            data: JSON.stringify(objSearchMstr),
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($noCon.map(data.d, function (item) {
                                    return {
                                        label: item.split('—')[0],
                                        val: item.split('—')[1]
                                    }
                                }))
                            },
                            error: function (response) {

                            },
                            failure: function (response) {
                            }
                        });
                    },
                    autoFocus: true,
                    select: function (e, i) {
                        var srtSearchItemMstr = i.item.label;
                        document.getElementById("txtproductName" + Rowx).value = i.item.label;
                        document.getElementById("txtproductId" + Rowx).value = i.item.val;
                        $noCon("#ddlProduct_" + Rowx).attr("title", i.item.label);


                        document.getElementById('txtQntity' + Rowx).value = 1;
                        document.getElementById('txtQntity' + Rowx).readOnly = false;
                        document.getElementById('txtQntity' + Rowx).style.pointerEvents = "painted";
                        document.getElementById('txtRate' + Rowx).style.pointerEvents = "painted";
                        document.getElementById('txtRate' + Rowx).readOnly = false;

                        if (document.getElementById("<%=HiddenDiscountEnableSts.ClientID%>").value == "1") {
                            document.getElementById('txtDisPercent' + Rowx).disabled = false;
                            document.getElementById('txtDisAmt' + Rowx).disabled = false;
                        }
                        else {
                            document.getElementById('txtDisPercent' + Rowx).disabled = true;
                            document.getElementById('txtDisAmt' + Rowx).disabled = true;
                        }
                        $(".ddlProduct_" + Rowx).focus();
                        BlurValue(Rowx, 'txtDisPercent');

                    },
                    minLength: 3
                });
            }
    </script>
    <script>
        var $aa = jQuery.noConflict();
        $aa(document).ready(function () {
        });
    </script>
     <script type="text/javascript" language="javascript">
         function isTagDes(evt) {
             if (DisableEnter(evt) == false) {
                 return false;
             }
             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
             if (keyCodes == 13) {
                 return true;
             }
             var charCode = (evt.which) ? evt.which : evt.keyCode;
             var ret = true;
             if (charCode == 60 || charCode == 62) {
                 ret = false;
             }
             return ret;
         }
         function ReplaceTag(obj, evt) {
             DisableEnter(evt);
             var WithoutReplace = document.getElementById(obj).value;
             var replaceText1 = WithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById(obj).value = replaceText2;
         }
             function DisableEnter(evt) {
                 evt = (evt) ? evt : window.event;
                 var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                 if (keyCodes == 13) {
                     return false;
                 }
                 if (keyCodes == 32) {
                 }
                 else {
                     IncrmntConfrmCounter();
                 }
             }
             function textCounter1(field, maxlimit, evt) {
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
       
         </script>
        <script>
          var  $noCon = jQuery.noConflict();
            var $noCon1 = jQuery.noConflict();
            $noCon1(window).load(function () {
               
                localStorage.clear();

                var Id = 0;
                //loadTableDesg();
                CheckSupplierType();
                curncyChangeFunt(Id);
               
                var defaultVal = "";
                document.getElementById("<%=txtGrsTotal.ClientID%>").disabled = true;
                document.getElementById("<%=txtTotalTaxAmt.ClientID%>").disabled = true;
                document.getElementById("<%=txtNetTotal.ClientID%>").disabled = true;
                document.getElementById("<%=txtDefultCrncyTotl.ClientID%>").disabled = true;
                document.getElementById("DivCurrency").style.display = "";
                if (document.getElementById("<%=HiddensaleId.ClientID%>").value == "") {
                    if (document.getElementById("<%=HiddenCurrncyId.ClientID%>").value == document.getElementById("cphMain_ddlCurrency").value) {
                        document.getElementById("cphMain_divExchangecurency").style.display = "none";
                        document.getElementById("cphMain_divTotalDefultCrncy").style.display = "none";
                    }
                    else {
                        document.getElementById("cphMain_divExchangecurency").style.display = "block";
                        document.getElementById("cphMain_divTotalDefultCrncy").style.display = "block";
                    }
                    document.getElementById("<%=txtGrsTotal.ClientID%>").innerHTML = "";
                    document.getElementById("<%=txtTotalTaxAmt.ClientID%>").innerHTML = "";
                    document.getElementById("<%=txtNetTotal.ClientID%>").value = "";
                    document.getElementById("<%=txtDefultCrncyTotl.ClientID%>").value = "";
                }
                if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value != "1") {
                    document.getElementById("DiTaxTot").style.display = "none";
                    document.getElementById("tdHdTax").style.display = "none";
                    //document.getElementById("tdHdTaxamnt").style.display = "none";
                    //document.getElementById("tdHdTaxPercent").style.display = "none";
                }
                if (document.getElementById("<%=HiddenInventoryForex.ClientID%>").value == "1") {
                    if (document.getElementById("<%=HiddenCurrncyId.ClientID%>").value != document.getElementById("cphMain_ddlCurrency").value) {
                        document.getElementById("cphMain_divExchangecurency").style.display = "";
                        document.getElementById("cphMain_divTotalDefultCrncy").style.display = "";
                    }
                    else {
                        document.getElementById("cphMain_divExchangecurency").style.display = "none";
                        document.getElementById("cphMain_divTotalDefultCrncy").style.display = "none";
                    }
                    document.getElementById("DivCurrency").style.display = "";
                }
                else {
                    document.getElementById("DivCurrency").style.display = "none";
                    document.getElementById("cphMain_divExchangecurency").style.display = "none";
                    document.getElementById("cphMain_divTotalDefultCrncy").style.display = "none";
                    if (document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value == "") {
                        document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value = document.getElementById("<%=HiddenCurrency.ClientID%>").value;
                    }
                }
             
                var $noCon = jQuery.noConflict();
                var EditVal = document.getElementById("<%=HiddenEdit.ClientID%>").value;
                var ViewVal = document.getElementById("<%=HiddenView.ClientID%>").value;
                if (document.getElementById("<%=hiddenEditPrmtAttchmnt.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditPrmtAttchmnt.ClientID%>").value;
                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');
                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');
                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {
                            if (jsonAtt[key].AttachmentDtlId != "") {
                                if (document.getElementById("<%=HiddenviewSts.ClientID%>").value == "1") {
                                    ViewAttachmentVhcl(jsonAtt[key].AttachmentDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].RowCount);
                                }
                                else {
                                    EditAttachmentVhcl(jsonAtt[key].AttachmentDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].RowCount);
                                }
                            }
                        }
                    }
                }
                else {
                    AddFileUploadVhcl();
                    if (document.getElementById("<%=cbxAddAttachment.ClientID%>").checked == true) {
                        document.getElementById("<%=divAttachment.ClientID%>").style.display = "block";
                        if (ViewVal != "") {
                            $("#TableFileCCN").find("input").attr("disabled", "disabled");
                            document.getElementById("FileIndvlAddMoreRow" + 0).style.opacity = "0.3";
                            document.getElementById("FileIndvldeleteRow" + 0).style.opacity = "0.3";
                            document.getElementById("FileIndvldeleteRow" + 0).disabled = true;
                        }
                    }
                    else {
                        document.getElementById("<%=divAttachment.ClientID%>").style.display = "none";
                    }
                }
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
                            if (json[key].SALES_ID != "") {
                                EditListRows(json[key].SALES_ID, json[key].PRODUCT_ID, json[key].PRODUCTROW, json[key].SLNO, json[key].QUANTITY, json[key].RATE, json[key].DISPER, json[key].DISAMT, json[key].TAX, json[key].TAXAMT, json[key].PRICE, json[key].TAXNAME, json[key].TAXPERCENTAGE, json[key].PRODUCT_NAME, json[key].PRDCT_CHCK, json[key].SALS_PRODUCT_REMARK, json[key].COSTCENTRE);
                            }
                        }
                    }
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
                            if (json[key].SALES_ID != "") {
                                ViewListRows(json[key].SALES_ID, json[key].PRODUCT_ID, json[key].PRODUCTROW, json[key].SLNO, json[key].QUANTITY, json[key].RATE, json[key].DISPER, json[key].DISAMT, json[key].TAX, json[key].TAXAMT, json[key].PRICE, json[key].TAXNAME, json[key].TAXPERCENTAGE, json[key].PRODUCT_NAME, json[key].PRDCT_CHCK, json[key].SALS_PRODUCT_REMARK, json[key].COSTCENTRE);
                            }
                        }
                    }
                }
                else {
                }
                if (ViewVal == "" && EditVal == "") {
                    addMoreRows();
                }
                document.getElementById("<%=cbxExtngSplr.ClientID%>").focus();
                if (document.getElementById("<%=HiddenRefEnableSts.ClientID%>").value == "0") {
                    document.getElementById("cphMain_txtOrder").focus(); //evm 0044
                }
                else
                {
                    document.getElementById("cphMain_txtRef").focus(); //evm 0044
                }

                               
            });
            function CalculateNetTotal(str) {
                var NetAmt = 0;
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                var FinalGrossTotal = 0;
                var FinalTax = 0;
                var NetTotal = 0;
                var NetTotal_Exchange = 0;
                var FinalDiscount = 0;
                $('#TableaddedRows').find('tr').each(function () {
                    var row = $(this);
                    var rowid1 = $('td:first-child', row).html();
                    if (rowid1 != "") {
                        var rate1 = document.getElementById("txtRate" + rowid1).value;
                        rate1 = rate1.replace(/,/g, "");
                        var qty1 = document.getElementById("txtQntity" + rowid1).value.replace(/,/g, "");
                        if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                            var txAmt1 = document.getElementById("txtTaxAmt" + rowid1).value;
                            txAmt1 = txAmt1.replace(/,/g, "");
                        }
                        var discnt1 = document.getElementById("txtDisAmt" + rowid1).value;
                        discnt1 = discnt1.replace(/,/g, "");
                        if (rate1 != "" && qty1 != "") {
                            FinalGrossTotal = parseFloat(FinalGrossTotal) + (parseFloat(rate1) * parseFloat(qty1));
                        }
                        if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                            if (txAmt1 != "") {
                                FinalTax = parseFloat(FinalTax) + parseFloat(txAmt1);
                            }
                        }
                        if (discnt1 != "") {
                            FinalDiscount = parseFloat(FinalDiscount) + parseFloat(discnt1);
                        }
                    }
                });
                if (FinalDiscount <= 0) {
                    if (document.getElementById("<%=HiddenDiscountEnableSts.ClientID%>").value == "1") {
                        if (document.getElementById("<%=HiddenviewSts.ClientID%>").value != "1") {
                            document.getElementById("<%=txtDiscount.ClientID%>").disabled = false;
                            if (str == 1 || document.getElementById("<%=Hiddendiscount.ClientID%>").value > 0) {
                                var dicntAmt = document.getElementById("<%=txtDiscount.ClientID%>").value;
                                var x = dicntAmt.split(' ');
                                if (parseFloat(x[0]) > 0) {
                                    FinalDiscount = document.getElementById("<%=txtDiscount.ClientID%>").value;
                                    FinalDiscount = FinalDiscount.replace(/,/g, "");
                                }
                                if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                                    document.getElementById("<%=txtDiscount.ClientID%>").disabled = true;
                                }
                            }
                            else {
                            }
                        }
                        else {
                            document.getElementById("<%=txtDiscount.ClientID%>").disabled = true;
                            var dicntAmt = document.getElementById("<%=txtDiscount.ClientID%>").value;
                            var x = dicntAmt.split(' ');
                            if (parseFloat(x[0]) > 0) {
                                FinalDiscount = document.getElementById("<%=txtDiscount.ClientID%>").value;
                                FinalDiscount = FinalDiscount.replace(/,/g, "");
                            }
                            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                                document.getElementById("<%=txtDiscount.ClientID%>").disabled = true;
                            }
                        }
                        if (FinalDiscount == 0) {
                            FinalDiscount = 0;
                        }
                    }
                    else {
                        document.getElementById("<%=txtDiscount.ClientID%>").disabled = true;
                    }
                }
                else {
                    document.getElementById("<%=txtDiscount.ClientID%>").disabled = true;
                    document.getElementById("<%=txtDiscount.ClientID%>").value = FinalDiscount;
                }
                NetTotal = (parseFloat(FinalGrossTotal) + parseFloat(FinalTax)) - parseFloat(FinalDiscount);
                NetTotal = parseFloat(NetTotal);
                if (FloatingValue != "") {
                    NetTotal = NetTotal.toFixed(FloatingValue);
                    var ExnhgRate = 0;
                    if (document.getElementById("<%=txtExchangeRate.ClientID%>").value != "") {
                        ExnhgRate = document.getElementById("<%=txtExchangeRate.ClientID%>").value;
                        NetTotal_Exchange = parseFloat(NetTotal);
                        NetTotal_Exchange = parseFloat(NetTotal) * parseFloat(document.getElementById("<%=txtExchangeRate.ClientID%>").value);
                    }
                    ExnhgRate = parseFloat(ExnhgRate);
                    ExnhgRate = ExnhgRate.toFixed(FloatingValue);
                    document.getElementById("<%=txtExchangeRate.ClientID%>").value = ExnhgRate;
                    NetTotal_Exchange = parseFloat(NetTotal_Exchange);
                    NetTotal_Exchange = NetTotal_Exchange.toFixed(FloatingValue);
                }
                addCommasSummry(NetTotal_Exchange);
                document.getElementById("<%=txtDefultCrncyTotl.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value;
                document.getElementById("<%=lblExchnangAmt.ClientID%>").innerHTML = "Amount in " + document.getElementById("<%= HiddenDefultCrncAbrvtn.ClientID%>").value + " :" + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                addCommas("cphMain_txtExchangeRate");
                if (document.getElementById("<%=HiddenInventoryForex.ClientID%>").value == "1") {
                    if (document.getElementById("<%=divExchangecurency.ClientID%>").style.display == "") {
                        if (document.getElementById("<%=txtExchangeRate.ClientID%>").value != "") {
                            //  NetTotal = (parseFloat(NetTotal) + parseFloat(document.getElementById("<%=txtExchangeRate.ClientID%>").value));
                        }
                    }
                }
                if (FloatingValue != "") {
                    FinalGrossTotal = parseFloat(FinalGrossTotal);
                    FinalTax = parseFloat(FinalTax);
                    FinalDiscount = parseFloat(FinalDiscount);
                    NetTotal = parseFloat(NetTotal);
                    FinalGrossTotal = FinalGrossTotal.toFixed(FloatingValue);
                    FinalTax = FinalTax.toFixed(FloatingValue);
                    FinalDiscount = FinalDiscount.toFixed(FloatingValue);
                    NetTotal = NetTotal.toFixed(FloatingValue);
                }

                document.getElementById("<%=HiddenNetAmt.ClientID%>").value = NetTotal;
                DisplayCredit(0);

                document.getElementById("<%=Hiddendiscount.ClientID%>").value = FinalDiscount;
                document.getElementById("<%=HiddenGrossAmt.ClientID%>").value = FinalGrossTotal;
                document.getElementById("<%=HiddenNetAmt.ClientID%>").value = NetTotal;
                document.getElementById("<%=HiddenTax.ClientID%>").value = FinalTax;
                addCommasSummry(FinalDiscount);
                document.getElementById("<%=txtDiscount.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value;
                addCommasSummry(FinalGrossTotal);
                document.getElementById("<%=txtGrsTotal.ClientID%>").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value;
                addCommasSummry(NetTotal);
                document.getElementById("<%=txtNetTotal.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value;
                addCommasSummry(FinalTax);
                document.getElementById("<%=txtTotalTaxAmt.ClientID%>").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value;
            }
            function ChangeEnable(field) {
                ddlDeptHaveValue = $noCon2('#cphMain_ddlDepartment').val();
                ddlDivisionHaveValue = $noCon2('#cphMain_ddlDivision').val();
                ddlEmpHaveValue = $noCon2('#cphMain_ddlEmployee').val();
                ddlDsgnHaveValue = $noCon2('#cphMain_ddlDesignation').val();
                if (field == 'cphMain_cbxAllDiv') {
                    if (document.getElementById("<%=cbxAllDiv.ClientID%>").checked == true && ddlDivisionHaveValue != null) {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Selected division will be remove and consider as all divisions",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                var newVar = "";
                                document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                                $p('#cphMain_ddlDivision').val(newVar);
                                $p("#cphMain_ddlDivision").trigger("change");
                            }
                            else {
                                document.getElementById("<%=cbxAllDiv.ClientID%>").checked = false;
                            }
                        });
                        return false;
                    }
                    else if (document.getElementById("<%=cbxAllDiv.ClientID%>").checked == true && ddlDivisionHaveValue == null) {
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                    }
                    else if (document.getElementById("<%=cbxAllDiv.ClientID%>").checked == false) {
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = false;
                    }
            return false;
        }
        else if (field == 'cphMain_cbxAllDept') {

            if (document.getElementById("<%=cbxAllDept.ClientID%>").checked == true && (ddlDeptHaveValue != null || ddlDivisionHaveValue != null || ddlEmpHaveValue != null || ddlDsgnHaveValue != null)) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Selected departments will be remove and consider as all departments",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var newVar = "";
                        $p('#cphMain_ddlDepartment').val(newVar);
                        $p("#cphMain_ddlDepartment").trigger("change");
                        $p('#cphMain_ddlEmployee').val(newVar);
                        $p("#cphMain_ddlEmployee").trigger("change");
                        $p('#cphMain_ddlDivision').val(newVar);
                        $p("#cphMain_ddlDivision").trigger("change");
                        $p('#cphMain_ddlDesignation').val(newVar);
                        $p("#cphMain_ddlDesignation").trigger("change");
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllEmp.ClientID%>").checked = true;
                                document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxDsgn.ClientID%>").checked = true;
                                document.getElementById("<%=cbxDsgn.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                            }
                            else {
                                document.getElementById("<%=cbxAllDept.ClientID%>").checked = false;
                            }

                        });

                        return false;

                    }
                    else if (document.getElementById("<%=cbxAllDept.ClientID%>").checked == true && (ddlDeptHaveValue == null || ddlDivisionHaveValue == null || ddlEmpHaveValue == null || ddlDsgnHaveValue == null)) {
                document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                    }
                    else if (document.getElementById("<%=cbxAllDept.ClientID%>").checked == false) {
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = false;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = false;
                    }
            return false;

        }
        else if (field == 'cphMain_cbxDsgn') {

            if (document.getElementById("<%=cbxDsgn.ClientID%>").checked == true && (ddlEmpHaveValue != null || ddlDsgnHaveValue != null)) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Selected designations will be remove and consider as all designations",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var newVar = "";
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = true;
                                document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                                document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDept.ClientID%>").checked = true;
                                document.getElementById("<%=cbxAllDept.ClientID%>").disabled = true;
                                $p('#cphMain_ddlDepartment').val(newVar);
                                $p("#cphMain_ddlDepartment").trigger("change");
                                $p('#cphMain_ddlEmployee').val(newVar);
                                $p("#cphMain_ddlEmployee").trigger("change");
                                $p('#cphMain_ddlDivision').val(newVar);
                                $p("#cphMain_ddlDivision").trigger("change");
                                $p('#cphMain_ddlDesignation').val(newVar);
                                $p("#cphMain_ddlDesignation").trigger("change");
                            }
                            else {
                                document.getElementById("<%=cbxDsgn.ClientID%>").checked = false;
                            }
                        });
                        return false;

                    }
                    else if (document.getElementById("<%=cbxDsgn.ClientID%>").checked == true && (ddlEmpHaveValue == null || ddlDsgnHaveValue == null)) {
                document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = true;
                    }
                    else if (document.getElementById("<%=cbxDsgn.ClientID%>").checked == false) {
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = false;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = false;
                    }
            return false;

        }

        else if (field == 'cphMain_cbxAllEmp') {
            if (document.getElementById("<%=cbxAllEmp.ClientID%>").checked == true && (ddlDeptHaveValue != null || ddlDivisionHaveValue != null || ddlEmpHaveValue != null || ddlDsgnHaveValue != null)) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Selected employees will be remove and consider as all employees",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var newVar = "";

                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxDsgn.ClientID%>").checked = true;
                                document.getElementById("<%=cbxDsgn.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                                document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDept.ClientID%>").checked = true;
                                document.getElementById("<%=cbxAllDept.ClientID%>").disabled = true;
                                $p('#cphMain_ddlDepartment').val(newVar);
                                $p("#cphMain_ddlDepartment").trigger("change");
                                $p('#cphMain_ddlEmployee').val(newVar);
                                $p("#cphMain_ddlEmployee").trigger("change");
                                $p('#cphMain_ddlDivision').val(newVar);
                                $p("#cphMain_ddlDivision").trigger("change");
                                $p('#cphMain_ddlDesignation').val(newVar);
                                $p("#cphMain_ddlDesignation").trigger("change");
                            }
                            else {
                                document.getElementById("<%=cbxAllEmp.ClientID%>").checked = false;
                            }
                        });
                        return false;
                    }
                    else if (document.getElementById("<%=cbxAllEmp.ClientID%>").checked == true && (ddlDeptHaveValue == null || ddlDivisionHaveValue == null || ddlEmpHaveValue == null || ddlDsgnHaveValue == null)) {

                document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = true;
                    }
                    else if (document.getElementById("<%=cbxAllEmp.ClientID%>").checked == false) {
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = false;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = false;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = false;

                    }
            return false;
        }

}

        </script>
    <script>
        function check($char, obj) {
            if (obj.value > 100.0) {
                return false;
            }
            if ($char == 60 || $char == 62 || $char == 13) {
                return false;
            }
          
            if ($char >= 65 && $char <= 90) {
                return false;
            }
            if (obj.value.length == 0 || obj.value.length == 1) {
                if (($char >= 48 && $char <= 57) || ($char >= 96 && $char <= 105) || $char == 190 || $char == 8 || $char == 9 || $char == 46 || $char == 13 || $char == 9 || $char == 35 || $char == 36 || $char == 37 || $char == 39 || $char == 110) {
                    return true;
                }
            }
            else if (obj.value.length == 2) {
                if ((obj.value > 10) && ($char == 110 || $char == 190 || $char == 46 || $char == 8 || $char == 9 || $char == 37 || $char == 39 || $char == 35 || $char == 36)) {
                    return true;
                }
                else if ((obj.value == 10) && ($char == 48 || $char == 96 || $char == 110 || $char == 190 || $char == 46 || $char == 8 || $char == 9 || $char == 37 || $char == 39 || $char == 35 || $char == 36)) {
                    return true;
                }
                else if ((obj.value < 10) && (($char >= 48 && $char <= 57) || ($char >= 96 && $char <= 105) || $char == 190 || $char == 8 || $char == 9 || $char == 46 || $char == 13 || $char == 9 || $char == 35 || $char == 36 || $char == 37 || $char == 39 || $char == 110)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (obj.value.length == 3) {
                if ((obj.value == 100) && ($char == 110 || $char == 190 || $char == 46 || $char == 8 || $char == 37 || $char == 39 || $char == 35 || $char == 36)) {
                    return true;
                }
                else if ((obj.value.indexOf(".") != -1) && (($char >= 48 && $char <= 57) || ($char >= 96 && $char <= 105) || $char == 190 || $char == 8 || $char == 9 || $char == 46 || $char == 13 || $char == 9 || $char == 35 || $char == 36 || $char == 37 || $char == 39 || $char == 110)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (obj.value.length == 4) {
                if ((obj.value.indexOf(".") != -1) && (($char >= 48 && $char <= 57) || ($char >= 96 && $char <= 105) || $char == 190 || $char == 8 || $char == 9 || $char == 46 || $char == 13 || $char == 9 || $char == 35 || $char == 36 || $char == 37 || $char == 39 || $char == 110)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (($char == 46 || $char == 8 || $char == 9 || $char == 37 || $char == 39 || $char == 35 || $char == 36)) {
                return true;
            }
            else {
                return false;
            }
        }

        function PrintVersnError() {
            $noCon("#divWarning").html("Please select a version for printing from account setting.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            $(window).scrollTop(0);
            return false;
        }

        function SuccessConfirmation() {
            $noCon("#success-alert").html("Sales details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            
            //ddlAccountName.Focus();
            return false;
        }

        function SuccessUpdation() {
            $noCon("#success-alert").html("Sales details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            
            //ddlAccountName.Focus();
            return false;
        }
        function SuccessConfirmationcnfrm() {
            $noCon("#success-alert").html("Sales details confirmed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            
            return false;
        }
        function ConfirmError() {
            $noCon("#divWarning").html("Sales details already confirmed.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
          
           // ddlAccountName.Focus();
            return false;
        }

        function ReopenError() {
            $noCon("#divWarning").html("Sales details already reopened.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            // ddlAccountName.Focus();
            return false;
        }

        function StatusError() {
            $noCon("#divWarning").html("Cannot be confirmed as status is inactive.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            // ddlAccountName.Focus();
            return false;
        }

        function Error() {
            $noCon("#divWarning").html("Some error occured!");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        function AlreadyCancelMsg() {
            $noCon("#divWarning").html("Sale details is already cancelled");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
          
            //ddlAccountName.Focus();
        }
        function SundryDebtorSelect() {
            $noCon("#divWarning").html("Please define the primary account group for customer before creating new sale ");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
          
        }
        
        function CreditLimtAlert() {
            $noCon("#divWarning").html("Sale amount greater than  credit amount.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
          
            return false;
        }
        function CreditPeriodAlert() {
            $noCon("#divWarning").html("Credit period exceeded.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
          
            return false;
        }
        function SuccessReopMsg() {
            $noCon("#success-alert").html("Sales details reopened successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        //evm 0044
        function DuplicationRefNumMsg() {

            $noCon("#divWarning").html("Duplication Error!. Reference number can’t be duplicated.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            if ($("#cphMain_txtRef").length) {
                document.getElementById("cphMain_txtRef").style.borderColor = "red";
                document.getElementById("cphMain_txtRef").focus();
            }
            return false;
        }


        function SalesValidate() {

            var ret = true;
            var ExRateSts = 0;
            var dupFlg = 0;


            document.getElementById("<%=HiddenExRateSts.ClientID%>").value = "0";
            document.getElementById("<%=txtRef.ClientID%>").style.border = "";
            document.getElementById("<%=txtDateFrom.ClientID%>").style.border = "";
            document.getElementById("<%=txtExchangeRate.ClientID%>").style.border = "";
            document.getElementById("cphMain_ddlCurrency").style.border = "";
            var CurrId = document.getElementById("cphMain_ddlCurrency").value;

            $au("div#divddlCustomerLdgr input.ui-autocomplete-input").css("borderColor", "");
            var date = document.getElementById("<%=txtDateFrom.ClientID%>").value;
            var Ref = document.getElementById("<%=txtRef.ClientID%>").value;

            var cstmrLdgr = document.getElementById("<%=ddlCustomerLdgr.ClientID%>").value;
            var ExgRate = document.getElementById("<%=txtExchangeRate.ClientID%>").value;

            var CostFlag = 0;
            var RowNum = document.getElementById("<%=HiddenRowNo.ClientID%>").value;
            $('#TableaddedRows').find('tr').each(function () {
                var row = $(this);
                var x = $('td:first-child', row).html();
                // var idlast = $noCon('#TableaddedRows  tr:last').attr('id');
                var table = document.getElementById("TableaddedRows");
                var xLength = table.rows.length;

                var TotalCost = 0;

                if (x != "") {
                    var costCntrAmt = document.getElementById("txtPrice" + x).value.replace(/,/g, "");
                    var CstCntrDtl = document.getElementById("tdCostCenterDtls" + x).value;

                    if (CstCntrDtl != "") {
                        var splitrow = CstCntrDtl.split("$");

                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var splitEach = splitrow[Cst].split("%");

                            if (splitEach[1] != "") {
                                TotalCost = parseFloat(TotalCost) + parseFloat(splitEach[1].replace(/,/g, ""));
                            }
                        }
                        if (TotalCost != costCntrAmt) {
                            //  ret = false;
                            CostFlag = 1;
                        }
                    }
                    var product = document.getElementById("ddlProduct_" + x).value;
                    if (product != "" || xLength == 1) {

                        var qty = document.getElementById("txtQntity" + x).value;
                        if (qty == "") {
                            document.getElementById("txtQntity" + x).style.borderColor = "Red";
                            //  $noCon("#txtToDate" + x).select();
                            document.getElementById("txtQntity" + x).focus();
                            ret = false;




                        }

                        var Rate = document.getElementById("txtRate" + x).value;
                        Rate = Rate.replace(/,/g, "");
                        if (Rate == "" || Rate <= 0) {
                            document.getElementById("txtRate" + x).style.borderColor = "Red";
                            //  $noCon("#txtToDate" + x).select();
                            document.getElementById("txtRate" + x).focus();
                            ret = false;

                        }
                        var value = $aa('#ddlProduct_' + x).val();

                        if (value == "" || value == null) {


                            $("div#divProduct_" + x).css('border', '0.5px solid rgb(255, 0, 0)');

                            $("#ddlProduct_" + x).focus();
                            ret = false;;


                        }

                        if (ret == true) {
                            if (ProductDuplication(x) == false) {



                                dupFlg = 1;
                                // ret = false;
                            }
                        }
                    }
                }
            });

            if (document.getElementById("<%=HiddenDefaultCurncy.ClientID%>").value == document.getElementById("cphMain_ddlCurrency").value || document.getElementById("cphMain_ddlCurrency").value == "--SELECT CURRENCY--") {

            }
            else {

                document.getElementById("<%=HiddenExRateSts.ClientID%>").value = "1";
                if (ExgRate == "") {
                    document.getElementById("<%=txtExchangeRate.ClientID%>").style.borderColor = "red";
                    $noCon1(window).scrollTop(0);
                    document.getElementById("<%=txtExchangeRate.ClientID%>").focus();
                    ret = false;
                }
            }
            if (document.getElementById("<%=HiddenCurrncyId.ClientID%>").value != document.getElementById("cphMain_ddlCurrency").value) {
                if (document.getElementById("<%=HiddenInventoryForex.ClientID%>").value == "1") {
                    var ExchngRt = document.getElementById("<%=txtExchangeRate.ClientID%>").value;
                    var x = ExchngRt.split(' ');
                    if (document.getElementById("<%=txtExchangeRate.ClientID%>").value.trim() == "" || x[0] <= 0) {
                        document.getElementById("<%=ddlCurrency.ClientID%>").focus();
                        document.getElementById("<%=txtExchangeRate.ClientID%>").style.borderColor = "red";
                        ret = false;
                    }
                }
            }
            document.getElementById("<%=txtAddress1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtsplrName.ClientID%>").style.borderColor = "";


            var acntflg = true;
            var acntSts = document.getElementById("cphMain_HiddenDefaultLdgrSts").value;
            if (acntSts == 1) {
                acntflg = false;
            }
            else {
                acntflg = true;
            }
            if (document.getElementById("<%=cbxExtngSplr.ClientID%>").checked == true) {

                acntflg = true;

                if (DisplayCredit(1) == false) {
                    return false;
                }

                if (document.getElementById("<%=ddlCustomerLdgr.ClientID%>").value == "--SELECT CUSTOMER--") {
                    // alert();
                    $noCon("div#divddlCustomerLdgr input.ui-autocomplete-input").css("borderColor", "red");

                    $noCon("div#divddlCustomerLdgr input.ui-autocomplete-input").focus();
                    $noCon("div#divddlCustomerLdgr input.ui-autocomplete-input").select();
                    ret = false;
                }
                else {
                    document.getElementById("<%=Hiddencustldgr.ClientID%>").value = cstmrLdgr;
                }
            }
            else {

                if (document.getElementById("<%=txtsplrName.ClientID%>").value.trim() == "") {
                    document.getElementById("<%=txtsplrName.ClientID%>").style.borderColor = "red";
                    ret = false;
                }


                if (document.getElementById("<%=txtAddress1.ClientID%>").value.trim() == "") {
                    document.getElementById("<%=txtAddress1.ClientID%>").style.borderColor = "red";
                    ret = false;
                }
            }

            if (date == "") {
                document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "red";
                $noCon1(window).scrollTop(0);
                document.getElementById("<%=txtDateFrom.ClientID%>").focus();
                ret = false;
            }
            if (Ref == "") {
                document.getElementById("<%=txtRef.ClientID%>").style.borderColor = "red";
                $noCon1(window).scrollTop(0);
                document.getElementById("<%=txtRef.ClientID%>").focus();
                ret = false;
            }


            var prdFlg = true;
            var acntSts = document.getElementById("cphMain_HiddenDefltPrdtLedId").value;
            if (acntSts == 1) {
                prdFlg = false;
            }
            else {
                // acntflg = true;
            }


            if (ret == true) {

                var tbClientTotalValues = '';
                tbClientTotalValues = [];
                var cbGatePassStatus;
                var curncy = "0";
                var fromDate = "";
                var todate = "0";


                //----------------------products------------------------

                document.getElementById("<%=HiddenAdd.ClientID%>").value = "";

                var table = document.getElementById("TableaddedRows");

                $('#TableaddedRows').find('tr').each(function () {
                    var row = $(this);
                    var x = $('td:first-child', row).html();

                    if (x != "" && document.getElementById("txtproductId" + x).value != "") {
                        var xLoop = x;
                        var slNo = document.getElementById("txtSlno" + x).value;
                        var prdtId = document.getElementById("txtproductId" + x).value;

                        var qnty = document.getElementById("txtQntity" + x).value;
                        var rate = document.getElementById("txtRate" + x).value;
                        var descprcng = document.getElementById("txtDisPercent" + x).value;
                        var dscAmt = document.getElementById("txtDisAmt" + x).value;
                        var taxId = "0";
                        var taxAmt = "0";
                        if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {

                            taxId = document.getElementById("txttaxid" + x).value;
                            taxAmt = document.getElementById("txtTaxAmt" + x).value;
                        }
                        var price = document.getElementById("txtPrice" + x).value;

                        var detailId = document.getElementById("tdDtlId" + x).innerHTML;
                        var Remark = document.getElementById("tdProductRemark" + x).innerHTML;
                        var evt = document.getElementById("tdEvt" + x).innerHTML;

                        var client = JSON.stringify({
                            SLNO: "" + slNo + "",
                            PRDTID: "" + prdtId + "",
                            QTY: "" + qnty + "",
                            RATE: "" + rate + "",
                            DESCPRCNTG: "" + descprcng + "",
                            DECAMT: "" + dscAmt + "",
                            TAXID: "" + taxId + "",
                            TAXAMT: "" + taxAmt + "",
                            PRICE: "" + price + "",
                            EVENT: "" + evt + "",
                            DTLIT: "" + detailId + "",
                            // REMARK: "" + Remark + "",
                            XLOOP: "" + xLoop + "",
                        });
                        tbClientTotalValues.push(client);

                    }
                });
                document.getElementById("<%=HiddenAdd.ClientID%>").value = JSON.stringify(tbClientTotalValues);


                //----------------------attachmnts------------------------

                document.getElementById("<%=HiddenField4_FileUpload.ClientID%>").value = "";

                var tbClientVehicleFileUpload = '';
                tbClientVehicleFileUpload = [];
                $('#TableFileCCN').find('tr').each(function () {

                    var row = $(this);
                    var x = $('td:first-child', row).html();
                    if (x != "") {

                        var FileUpdId = document.getElementById("file" + x).value;
                        //alert(FileUpdId);
                        if (FileUpdId != "") {

                            if (tbClientVehicleFileUpload == null) //If there is no data, initialize an empty array
                                tbClientVehicleFileUpload = [];

                            var FilePath = document.getElementById("filePath" + x).innerHTML;
                            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
                            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

                            if (Fevt == 'INS') {
                                var $addFile = jQuery.noConflict();
                                var client = JSON.stringify({
                                    ROWID: "" + x + "",
                                    FILEPATH: "" + FilePath + "",
                                    EVTACTION: "" + Fevt + "",
                                    DTLID: "0"
                                });
                            }
                            else if (Fevt == 'UPD') {
                                var $addFile = jQuery.noConflict();
                                FilePath = document.getElementById("DbFileName" + x).innerHTML;
                                var client = JSON.stringify({
                                    ROWID: "" + x + "",
                                    FILEPATH: "" + FilePath + "",
                                    EVTACTION: "" + Fevt + "",
                                    DTLID: "" + FdetailId + ""
                                });
                            }
                            tbClientVehicleFileUpload.push(client);
                        }

                    }
                });


                document.getElementById("<%=HiddenField4_FileUpload.ClientID%>").value = JSON.stringify(tbClientVehicleFileUpload);
            }

            if (ret == false && acntflg == true) {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon1(window).scrollTop(0);
            }
            else if (ret == false && acntflg == false) {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon1(window).scrollTop(0);
            }
            else if (ret == true && acntflg == false) {
                $noCon("#divWarning").html("Please define an account head  for customer before creating new sale ");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon1(window).scrollTop(0);
                ret = false;
            }
            else if (dupFlg == 1) {



                $noCon("#divWarning").html("Product should not be duplicated.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon1(window).scrollTop(0);

                ret = false;
            }

            else if (prdFlg == false) {

                $noCon("#divWarning").html("Please define an account head  for sales before creating new sale");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon1(window).scrollTop(0);

                ret = false;

            }

            if (CostFlag == 1) {
                $noCon("#divWarning").html("Product amount should be equal to cost centre amount.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon1(window).scrollTop(0);
                ret = false;
            }
            if (ret == true) {
                document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
                document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";
                document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
                document.getElementById("<%=HiddenLoadLedgers.ClientID%>").value = "";
            }
            return ret;
        }
      
        
        function ConfirmAlert() {
            if (SalesValidate() == true) {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm this sale?",
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
        function ConfirmReopen() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to reopen this sale?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
                    document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";
                    document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
                    document.getElementById("<%=HiddenLoadLedgers.ClientID%>").value = ""; 
                    document.getElementById("<%=btnReopen1.ClientID%>").click();
                } else {
                    return false;
                }
            });
            return false;
        }
        function ChangeProductTTT(PRowNum)
        {
            document.getElementById("<%=HiddenFocusId.ClientID%>").value = "";
            document.getElementById("<%=HiddenFocusName.ClientID%>").value = "";

            var QtnItemName = document.getElementById("txtproductName" + PRowNum).value;
            document.getElementById("<%=HiddenFocusName.ClientID%>").value = QtnItemName;

            var QtnItemId = document.getElementById("txtproductId" + PRowNum).value;
            document.getElementById("<%=HiddenFocusId.ClientID%>").value = QtnItemId;

        }

    </script>
    
      <script>
          var rowSubCatagory = 0;
          var RowNum = 0;
          var rowsl_no = 0;
          function addMoreRows() {
              rowsl_no++;
              RowNum++;
              document.getElementById("<%=HiddenRowNo.ClientID%>").value = RowNum;
              var recRow = '<tr  id="rowId_' + RowNum + '" >';
              recRow += '<td   id="tdidGrpDtls' + RowNum + '" style="display: none" >' + RowNum + '</td>';
              recRow += '<td>' + RowNum + '<input  style="display: none"  disabled=\"disabled\"  tabindex=\"-1\"  id=\"txtSlno' + RowNum + '\"   name=\"txtSlno' + RowNum + '\"  maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\" class=\"form-control\" value=\"' + rowsl_no + '\" /></td>';
              recRow += '<td ><div   class=\"input-group in_flw\" id=\"divProduct_' + RowNum + '\"> <input id=\"ddlProduct_' + RowNum + '\"  placeholder="--Select Item--"   style=\"\" onkeydown=\"return isTag(event)\"   onchange=\"ChangeProduct(' + RowNum + ',' + null + ')\"  onkeypress=\"return DisableEnter(event)\" class=\"fg2_inp2 fg2_inp3 fg_chs1 in_flw\" onblur=\"return BlurValue(' + RowNum + ',\'ddlProduct_\');\" > ';
              recRow += ' <a href="javascript:;" id="\DivAdddPrdtp_' + RowNum + '\" onclick="OpenProduct(' + RowNum + ');"  class=\"input-group-addon cur1 spn1_pro gren\" title=\"Add\"> <i class="fa fa-plus-circle"></i></a> </div></td>';
              recRow += '<td style=\"  display:none\"><input id=\"txtproductId' + RowNum + '\"   name=\"txtproductId' + RowNum + '\"  type=\"text\"  class=\"form-control\" /> <input id=\"txtproductName' + RowNum + '\"   name=\"txtproductName' + RowNum + '\"  type=\"text\"  class=\"form-control\" /></td> ';
              recRow += '<td ><input id=\"txtQntity' + RowNum + '\" autocomplete=\"off\"    name=\"txtQntity' + RowNum + '\"  maxlength=\"10\"  onkeypress=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onkeydown=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onblur=\"return BlurValue(' + RowNum + ',\'txtQntity\');\" type=\"text\"  class=\"form-control fg2_inp2 inp_mst tr_c\" /></td>';
              recRow += '<td ><input id=\"txtRate' + RowNum + '\" autocomplete=\"off\"    name=\"txtRate' + RowNum + '\"    maxlength=\"10\" onkeydown=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\"  onblur="return BlurValue(' + RowNum + ',\'txtRate\')" onkeypress=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\"  type=\"text\"  class=\"form-control fg2_inp2 tr_r\" /></td>';
              if (document.getElementById("<%=HiddenDiscountEnableSts.ClientID%>").value == "1")
              {
                  recRow += '<td ><div class=\"input-group ing1\"><input  autocomplete=\"off\"    id=\"txtDisPercent' + RowNum + '\"  name=\"txtDisPercent' + RowNum + '\"  maxlength=\"10\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\"  onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\"  onblur=\"return BlurValue(' + RowNum + ',\'txtDisPercent\');\" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /> <span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span></div>';
                  recRow += '<div class=\"input-group ing2\"><input  autocomplete=\"off\"    id=\"txtDisAmt' + RowNum + '\" name=\"txtDisAmt' + RowNum + '\"    maxlength=\"10\" onkeypress=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + ')\"  onblur=\"return BlurValue(' + RowNum + ',\'txtDisAmt\')\" type=\"text\" class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div></td>';
              }
              else
              {
                  recRow += '<td ><div class=\"input-group ing1\"><input  disabled=\"disabled\" autocomplete=\"off\"      id=\"txtDisPercent' + RowNum + '\"  name=\"txtDisPercent' + RowNum + '\"  maxlength=\"10\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\"  onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\"  onblur=\"return BlurValue(' + RowNum + ',\'txtDisPercent\');\" type=\"text\" class=\"form-control fg2_inp2 tr_r inp1_pro\" /> <span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span></div>';
                  recRow += '<div class=\"input-group ing2\"><input disabled=\"disabled\"  autocomplete=\"off\"     id=\"txtDisAmt' + RowNum + '\" name=\"txtDisAmt' + RowNum + '\"    maxlength=\"10\" onkeypress=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + ')\"  onblur=\"return BlurValue(' + RowNum + ',\'txtDisAmt\')\" type=\"text\"  class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div></td>';
              }
              if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1")
              {
                  recRow += '<td ><input id=\"ddlTax' + RowNum + '\" disabled  name=\"ddlTax' + RowNum + '\"  type=\"text\"  tabindex=\"-1\"  onkeydown=\"return isTag(event)\"  onkeypress=\"return IncrmntConfrmCounter()\" class=\"form-control fg2_inp2 tr_l inp_3_1\" /> ';
                  recRow += '<div class="input-group ing1 inp_3_2"><input id=\"txttaxprcntg' + RowNum + '\" disabled name=\"txttaxprcntg' + RowNum + '\"  type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /> <span class="input-group-addon cur1 spn1_pro pur_pe">%</span></div>';
                  recRow += '<div class="input-group ing2 inp_3_3"><input  id=\"txtTaxAmt' + RowNum + '\" disabled name=\"txtTaxAmt' + RowNum + '\" tabindex=\"-1\"  maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"   class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div></td>';
                  recRow += '<td style=\" padding-right: 0.5%; display:none\"><input id=\"txttaxid' + RowNum + '\"  name=\"txttaxid' + RowNum + '\"  type=\"text\"  class=\"form-control\" /> ';
              }

              recRow += '<td><input id=\"txtPrice' + RowNum + '\" disabled name=\"txtPrice' + RowNum + '\"  tabindex=\"-1\"   maxlength=\"10\" onkeypress=\"return isNumberAmount(event)\" type=\"text\"  class=\"form-control fg2_inp2 tr_r\" /></td>';
              recRow += '<td class="td1"  id="tdIndvlAddMoreRow' + RowNum + '" ><a href="javascript:;" id="\DivAddComment_' + RowNum + '\" onclick="OpenComment(' + RowNum + ');"  class=\"btn act_btn bn9\" title=\"Add Remark\"><i class="fa fa-commenting"></i></a> ';
              recRow += '<a  href="javascript:;"  id=\"SpanAdd' + RowNum + '\"   onclick=\"return CheckaddMoreRows(' + RowNum + ');\" class=\"btn act_btn bn2\" title=\"Add\"><i class="fa fa-plus-circle"></i> </a>';
            

              recRow += '<a  href="javascript:;"   onclick=\"return CheckDelEachRow(' + RowNum + ');\" class=\"btn act_btn bn3\" title=\"Delete\"><i class="fa fa-trash"></i></a></div></td>';
              recRow += '<td ><a href="javascript:;" id="\DivCostCentre_' + RowNum + '\" onclick="MyModalCostCenter(\'' + RowNum + '\',\'' + rowSubCatagory + '\',null);"  title=\"Add Cost Centre\">  <i class=\"fa fa-filter ad_fa\"></i></a></td> ';
              recRow += '<td id="tdEvt' + RowNum + '" style="display: none;">INS</td>';
              recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowNum + '" name="tdCostCenterDtls' + RowNum + '" placeholder=""/></td>';
              recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowNum + '" name="tdCostCenterDtls' + RowNum + '" placeholder=""/></td>';

              recRow += '<td id="tdDtlId' + RowNum + '" style="display: none;"></td>';
              recRow += '<td id="tdProductRemark' + RowNum + '" style="display: none;"></td>';
              recRow += '<td  style="display: none;"><input id=\"txtRemark' + RowNum + '\" name=\"txtRemark' + RowNum + '\" style="display: none;" > </td>';
              recRow += '</tr>';
              jQuery('#TableaddedRows').append(recRow);
              document.getElementById('txtDisPercent' + RowNum).disabled = true;
              document.getElementById('txtDisAmt' + RowNum).disabled = true;
              document.getElementById('txtRate' + RowNum).readOnly = true;
              document.getElementById('txtQntity' + RowNum).readOnly = true;
              var valuesSel = "";
              AutoCompleteTextBox("#ddlProduct_", RowNum,0);
              $noCon("#ddlProduct_" + RowNum).select();
          }
  
          function EditListRows(SALES_ID, PRODUCT_ID, PRODUCTROW, SLNO, QUANTITY, RATE, DISPER, DISAMT, TAX, TAXAMT, PRICE, TAXNAME, TAXPERCENTAGE, PRODUCT_NAME, PRDCT_CHCK, SALS_PRODUCT_REMARK, COSTCENTRE) {
              RowNum++;
              rowsl_no++;
              document.getElementById("cphMain_HiddenRowNo").value = RowNum;
              var recRow = '<tr  id="rowId_' + RowNum + '">';
              recRow += '<td   id="tdidGrpDtls' + RowNum + '" style="display: none" >' + RowNum + '</td>';
              recRow += '<td >' + rowsl_no + '<input disabled=\"disabled\"  style="display: none"   tabindex=\"-1\"  id=\"txtSlno' + RowNum + '\"   name=\"txtSlno' + RowNum + '\" tabindex=\"-1\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\" class=\"form-control\" value=\"' + rowsl_no + '\" /></td>';
              recRow += '<td ><div class=\"input-group in_flw\"  id=\"divProduct_' + RowNum + '\"> <input id=\"ddlProduct_' + RowNum + '\"  placeholder="--Select Item--"   onkeydown=\"return isTag(event)\"  onchange=\"ChangeProduct(' + RowNum + ',' + null + ')\"  onkeypress=\"return DisableEnter(event)\" class=\"fg2_inp2 fg2_inp3 fg_chs1 in_flw\" onblur=\"return BlurValue(' + RowNum + ',\'ddlProduct_\');\">';
              recRow += '<a href=\"javascript:;\" id="\DivAdddPrdtp_' + RowNum + '\"  onclick=\"OpenProduct(' + RowNum + ');\"  class=\"input-group-addon cur1 spn1_pro gren\" title=\"Add\"> <i class="fa fa-plus-circle"></i></a> </div></td>';
              recRow += '<td style=\"  padding-right: 0.5%; display:none\"><input id=\"txtproductId' + RowNum + '\"   name=\"txtproductId' + RowNum + '\"  type=\"text\"  class=\"form-control\" /> <input id=\"txtproductName' + RowNum + '\"   name=\"txtproductName' + RowNum + '\"  type=\"text\"  class=\"form-control\" /></td> ';
              recRow += '<td ><input autocomplete=\"off\"  id=\"txtQntity' + RowNum + '\"  name=\"txtQntity' + RowNum + '\"  maxlength=\"10\" onkeypress=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onkeydown=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onblur=\"return BlurValue(' + RowNum + ',\'txtQntity\');\" type=\"text\"  class=\"form-control fg2_inp2 inp_mst tr_c\"  value=\"' + QUANTITY + '\" /></td>';
              recRow += '<td ><input  autocomplete=\"off\"  id=\"txtRate' + RowNum + '\" name=\"txtRate' + RowNum + '\"   style=\" text-align: right;\" maxlength=\"10\" onkeydown=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\"  onblur="return BlurValue(' + RowNum + ',\'txtRate\')" onkeypress=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\" type=\"text\"  class=\"form-control fg2_inp2 tr_r\"  value=\"' + RATE + '\" /></td>';

              if (document.getElementById("<%=HiddenDiscountEnableSts.ClientID%>").value == "1") {

                  recRow += '<td > <div class=\"input-group ing1\"><input id=\"txtDisPercent' + RowNum + '\"  autocomplete=\"off\"       name=\"txtDisPercent' + RowNum + '\"  maxlength=\"10\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onblur=\"return BlurValue(' + RowNum + ',\'txtDisPercent\');\" type=\"text\" value=\"' + DISPER + '\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /> <span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span></div>';
                  recRow += '<div class=\"input-group ing2\"><input id=\"txtDisAmt' + RowNum + '\" autocomplete=\"off\"     name=\"txtDisAmt' + RowNum + '\"    maxlength=\"10\" onkeypress=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + ')\"  onblur=\"return BlurValue(' + RowNum + ',\'txtDisAmt\');\"  type=\"text\"    value=\"' + DISAMT + '\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div></td>';
              }
              else {
                  recRow += '<td > <div class=\"input-group ing1\"><input  disabled=\"disabled\"   id=\"txtDisPercent' + RowNum + '\"   name=\"txtDisPercent' + RowNum + '\"   maxlength=\"10\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onblur=\"return BlurValue(' + RowNum + ',\'txtDisPercent\');\" type=\"text\"   value=\"' + DISPER + '\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /> <span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span></div>';
                  recRow += '<div class=\"input-group ing2\"><input disabled=\"disabled\"    id=\"txtDisAmt' + RowNum + '\" " name=\"txtDisAmt' + RowNum + '\"    maxlength=\"10\" onkeypress=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + ')\"  onblur=\"return BlurValue(' + RowNum + ',\'txtDisAmt\');\"  type=\"text\"   value=\"' + DISAMT + '\" class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div></td>';

              }
              if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                  recRow += '<td ><input id=\"ddlTax' + RowNum + '\"  tabindex=\"-1\"    style=\"cursor: pointer;\"     disabled   name=\"ddlTax' + RowNum + '\"  type=\"text\"    onkeydown=\"return isTag(event)\"    onkeypress=\"return IncrmntConfrmCounter()\" class=\"form-control fg2_inp2 tr_l inp_3_1\" value=\"' + TAXNAME + '\"  title=\"' + TAXNAME + '\" />';
                  recRow += '<div class="input-group ing1 inp_3_2"><input id=\"txttaxprcntg' + RowNum + '\"  disabled name=\"txttaxprcntg' + RowNum + '\"  type=\"text\"   value=\"' + TAXPERCENTAGE + '\"   class=\"form-control fg2_inp2 tr_r inp1_pro\" /> <span class="input-group-addon cur1 spn1_pro pur_pe">%</span></div>';
                  recRow += '<div class="input-group ing2 inp_3_3"><input id=\"txtTaxAmt' + RowNum + '\"  tabindex=\"-1\"   name=\"txtTaxAmt' + RowNum + '\"    maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"   value=\"' + TAXAMT + '\" class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></td>';
                  recRow += '<td style=\" padding-right: 0.5%; display:none\"><input id=\"txttaxid' + RowNum + '\"  value=\"' + TAX + '\"  name=\"txttaxid' + RowNum + '\"  type=\"text\"  class=\"form-control\" /> </td> ';
              }
              recRow += '<td><input  tabindex=\"-1\"   id=\"txtPrice' + RowNum + '\"  name=\"txtPrice' + RowNum + '\"     maxlength=\"10\" onkeypress=\"return isNumberAmount(event)\" type=\"text\"  class=\"form-control fg2_inp2 tr_r\" value=\"' + PRICE + '\"  /></td>';
              recRow += '<td id="tdIndvlAddMoreRow' + RowNum + '" ><a href="javascript:;" id="\DivAddComment_' + RowNum + '\" onclick="OpenComment(' + RowNum + ');"   class=\"btn act_btn bn9\" title=\"Add Remark\"><i class="fa fa-commenting"></i></a> ';
             
              recRow += '<a  href="javascript:;"  id=\"SpanAdd' + RowNum + '\"    title=\"Add\"  onclick=\"return CheckaddMoreRows(' + RowNum + ');\" class=\"btn act_btn bn2\" title=\"Add\"><i class="fa fa-plus-circle"></i> </a>';
              recRow += '<a  href="javascript:;"    onclick=\"return CheckDelEachRow(' + RowNum + ');\" class=\"btn act_btn bn3\" title=\"Delete\"><i class="fa fa-trash"></i></a></div></td>';

              recRow += '<td ><a href="javascript:;" id="\DivCostCentre_' + RowNum + '\" onclick="MyModalCostCenter(\'' + RowNum + '\',\'' + rowSubCatagory + '\',null);"  title=\"Add Cost Centre\">  <i class=\"fa fa-filter ad_fa\"></i></a></td> ';
              recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowNum + '" name="tdCostCenterDtls' + RowNum + '" placeholder=""/></td>';

              recRow += '<td id="tdEvt' + RowNum + '" style="display: none;">UPD</td>';
              recRow += '<td id="tdDtlId' + RowNum + '" style="display: none;" ">' + PRODUCTROW + '</td>';
              if (SALS_PRODUCT_REMARK != null)
                  recRow += '<td id="tdProductRemark' + RowNum + '" style="display: none;">' + SALS_PRODUCT_REMARK + '  </td>';
              else
                  recRow += '<td id="tdProductRemark' + RowNum + '" style="display: none;"></td>';
              if (SALS_PRODUCT_REMARK != null)
                  recRow += '<td  style="display: none;"><input id=\"txtRemark' + RowNum + '\" name=\"txtRemark' + RowNum + '\" style="display: none;" value=\"' + SALS_PRODUCT_REMARK + '\" > </td>';
              else
                  recRow += '<td  style="display: none;"><input id=\"txtRemark' + RowNum + '\" name=\"txtRemark' + RowNum + '\" style="display: none;" value="" > </td>';

              recRow += '</tr>';
              jQuery('#TableaddedRows').append(recRow);
             
              document.getElementById("tdCostCenterDtls" + RowNum).value = COSTCENTRE;
              currnty = RowNum;
              //document.getElementById('txtRate' + RowNum).style.pointerEvents = 'none';
              if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                  document.getElementById('txtTaxAmt' + RowNum).style.pointerEvents = 'none';
              }
              document.getElementById('txtPrice' + RowNum).style.pointerEvents = 'none';
              if (PRODUCT_ID != "") {
                  $noCon("#ddlProduct_" + RowNum).val(PRODUCT_NAME);
                  $noCon("#txtproductId" + RowNum).val(PRODUCT_ID);
                  $noCon("#txtproductName" + RowNum).val(PRODUCT_NAME);
                  AutoCompleteTextBox("#ddlProduct_", RowNum, 0);
                  $noCon("#ddlProduct_" + RowNum).select();
                  var FinalGrossTotal1 = 0;
                  var FinalTax1 = 0;
                  var NetTotal1 = 0;
                  var FinalDiscount1 = 0;

                  FinalGrossTotal1 = document.getElementById("<%=HiddenGrossAmt.ClientID%>").value;
                  NetTotal1 = document.getElementById("<%=HiddenNetAmt.ClientID%>").value;
                  FinalDiscount1 = document.getElementById("<%=Hiddendiscount.ClientID%>").value;
                  addCommasSummry(FinalGrossTotal1);

                  if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                      FinalTax1 = document.getElementById("<%=HiddenTax.ClientID%>").value;
                      addCommasSummry(FinalTax1);
                      addCommasSummry(FinalTax1);
                      document.getElementById("<%=txtTotalTaxAmt.ClientID%>").txtTotalTaxAmt = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;;
                  }


                  addCommasSummry(NetTotal1);
                  addCommasSummry(FinalDiscount1);
                  document.getElementById("<%=txtDiscount.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;;
                  addCommasSummry(FinalGrossTotal1);
                  document.getElementById("<%=txtGrsTotal.ClientID%>").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;;
                  addCommasSummry(NetTotal1);
                  document.getElementById("<%=txtNetTotal.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrency.ClientID%>").value;;
                  addCommas("txtRate" + RowNum);
                  if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                      addCommas("txtTaxAmt" + RowNum);
                  }
                  addCommas("txtDisAmt" + RowNum);

                  addCommas("txtPrice" + RowNum);



              }
          }

          function ViewListRows(SALES_ID, PRODUCT_ID, PRODUCTROW, SLNO, QUANTITY, RATE, DISPER, DISAMT, TAX, TAXAMT, PRICE, TAXNAME, TAXPERCENTAGE, PRODUCT_NAME, PRDCT_CHCK, SALS_PRODUCT_REMARK, COSTCENTRE) {
              RowNum++;
              rowsl_no++;
              document.getElementById("cphMain_HiddenRowNo").value = RowNum;
              var recRow = '<tr  id="rowId_' + RowNum + '">';
              recRow += '<td   id="tdidGrpDtls' + RowNum + '" style="display: none" >' + RowNum + '</td>';
              recRow += '<td >' + rowsl_no + '<input disabled id=\"txtSlno' + RowNum + '\"  style="display: none"   name=\"txtSlno' + RowNum + '\" tabindex=\"-1\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\" class=\"form-control\" value=\"' + rowsl_no + '\" /></td>';
              recRow += '<td ><div class=\"input-group in_flw\"   id=\"divProduct_' + RowNum + '\"> <input disabled id=\"ddlProduct_' + RowNum + '\"  placeholder="--Select Item--"   style=\"\"  onkeydown=\"return isTag(event)\" onfocus=\"ChangeProduct(' + RowNum + ',' + RATE + ')\"  onchange=\"ChangeProduct(' + RowNum + ',' + RATE + ')\"  onkeypress=\"return DisableEnter(event)\"  class=\"fg2_inp2 fg2_inp3 fg_chs1 in_flw\"/></td> ';

              recRow += '<td style=\" padding-right: 0.5%; display:none\"><input disabled id=\"txtproductId' + RowNum + '\"   name=\"txtproductId' + RowNum + '\"  type=\"text\"  class=\"form-control\" /> <input id=\"txtproductName' + RowNum + '\"   name=\"txtproductName' + RowNum + '\"  type=\"text\"  class=\"form-control\" /></td> ';
              recRow += '<td ><input disabled id=\"txtQntity' + RowNum + '\"  name=\"txtQntity' + RowNum + '\"  maxlength=\"10\" onkeypress=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onkeydown=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onblur=\"return BlurValue(' + RowNum + ',\'txtQntity\');\" type=\"text\"  class=\"form-control fg2_inp2 inp_mst tr_c\"  value=\"' + QUANTITY + '\" /></td>';
              recRow += '<td ><input disabled id=\"txtRate' + RowNum + '\" name=\"txtRate' + RowNum + '\"    maxlength=\"10\" onkeydown=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\"  onkeypress=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\" type=\"text\"  class=\"form-control fg2_inp2 tr_r\"  value=\"' + RATE + '\" /></td>';
              recRow += '<td ><div class="input-group ing1"><input disabled id=\"txtDisPercent' + RowNum + '\"   name=\"txtDisPercent' + RowNum + '\"  maxlength=\"10\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onblur=\"return BlurValue(' + RowNum + ',\'txtDisPercent\');\" type=\"text\"   value=\"' + DISPER + '\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span></div>';
              recRow += '<div class="input-group ing2"><input disabled id=\"txtDisAmt' + RowNum + '\" " name=\"txtDisAmt' + RowNum + '\"    maxlength=\"10\" onkeypress=\"return isNumberAmount(event)\" onblur=\"return BlurValue(' + RowNum + ',\'txtDisAmt\');\"  type=\"text\"   value=\"' + DISAMT + '\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div></td>';
              if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                  recRow += '<td ><input disabled id=\"ddlTax' + RowNum + '\"  name=\"ddlTax' + RowNum + '\"  type=\"text\"    onkeydown=\"return isTag(event)\"    onkeypress=\"return IncrmntConfrmCounter()\" class=\"form-control fg2_inp2 tr_l inp_3_1\" value=\"' + TAXNAME + '\"  title=\"' + TAXNAME + '\"  />  ';
                  recRow += '<div class="input-group ing1 inp_3_2"><input disabled id=\"txttaxprcntg' + RowNum + '\"   name=\"txttaxprcntg' + RowNum + '\"  type=\"text\"   value=\"' + TAXPERCENTAGE + '\"    class=\"form-control fg2_inp2 tr_r inp1_pro\" /> <span class="input-group-addon cur1 spn1_pro pur_pe">%</span></div>';
                  recRow += ' <div class="input-group ing2 inp_3_3"><input disabled id=\"txtTaxAmt' + RowNum + '\" name=\"txtTaxAmt' + RowNum + '\"    maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  value=\"' + TAXAMT + '\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /> <span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div></td>';
                  recRow += '<td style=\" padding-right: 0.5%; display:none\"><input disabled id=\"txttaxid' + RowNum + '\"  value=\"' + TAX + '\"  name=\"txttaxid' + RowNum + '\"  type=\"text\"  class=\"form-control\" /> </td> ';
              }
              recRow += '<td><input disabled id=\"txtPrice' + RowNum + '\"  name=\"txtPrice' + RowNum + '\"     maxlength=\"10\" onkeypress=\"return isNumberAmount(event)\" type=\"text\"  class=\"form-control fg2_inp2 tr_r\" value=\"' + PRICE + '\"  /></td>';
              recRow += '<td id="tdIndvlAddMoreRow' + RowNum + '" ><a href="javascript:;" id="\DivAddComment_' + RowNum + '\" onclick="OpenComment(' + RowNum + ');"   class=\"btn act_btn bn9\" title=\"Add Remark\"><i class="fa fa-commenting"></i></a> ';
              recRow += '<a disabled href="javascript:;"  id=\"SpanAdd' + RowNum + '\"   class=\"btn act_btn bn2\" title=\"Add\"><i class="fa fa-plus-circle"></i> </a>';
              recRow += '<a disabled href="javascript:;"   class=\"btn act_btn bn3\" title=\"Delete\"><i class="fa fa-trash"></i></a></div></td>';
              recRow += '<td><a href="javascript:;" id="\DivCostCentre_' + RowNum + '\" onclick="MyModalCostCenter(\'' + RowNum + '\',\'' + rowSubCatagory + '\',null);"  title=\"Add Cost Centre\">  <i class=\"fa fa-filter ad_fa\"></i></a></td> ';
              recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowNum + '" name="tdCostCenterDtls' + RowNum + '" value=\"' + COSTCENTRE + '\" placeholder=""/></td>';
              recRow += '<td id="tdEvt' + RowNum + '" style="display: none;">UPD</td>';
              recRow += '<td id="tdDtlId' + RowNum + '" style="display: none;" ">' + PRODUCTROW + '</td>';
              if (SALS_PRODUCT_REMARK != null)
                  recRow += '<td id="tdProductRemark' + RowNum + '" style="display: none;">' + SALS_PRODUCT_REMARK + '</td>';
              else
                  recRow += '<td id="tdProductRemark' + RowNum + '" style="display: none;"></td>';
              recRow += '</tr>';
              currnty = RowNum;
              jQuery('#TableaddedRows').append(recRow);
              document.getElementById('txtRate' + RowNum).style.pointerEvents = 'none';
              if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                  document.getElementById('txtTaxAmt' + RowNum).style.pointerEvents = 'none';
              }
              document.getElementById('txtPrice' + RowNum).style.pointerEvents = 'none';
              if (PRODUCT_ID != "") {
                  $noCon("#ddlProduct_" + RowNum).val(PRODUCT_NAME);
                  $noCon("#txtproductId" + RowNum).val(PRODUCT_ID);
                  $noCon("#txtproductName" + RowNum).val(PRODUCT_NAME);
                  AutoCompleteTextBox("#ddlProduct_", RowNum, 0);
                  $noCon("#ddlProduct_" + RowNum).select();
                  var FinalGrossTotal1 = 0;
                  var FinalTax1 = 0;
                  var NetTotal1 = 0;
                  var FinalDiscount1 = 0;
                  FinalGrossTotal1 = document.getElementById("<%=HiddenGrossAmt.ClientID%>").value;
                  NetTotal1 = document.getElementById("<%=HiddenNetAmt.ClientID%>").value;
                  FinalDiscount1 = document.getElementById("<%=Hiddendiscount.ClientID%>").value;
                  addCommasSummry(FinalGrossTotal1);
                  if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                      FinalTax1 = document.getElementById("<%=HiddenTax.ClientID%>").value;
                      addCommasSummry(FinalTax1);
                      addCommasSummry(FinalTax1);
                      document.getElementById("<%=txtTotalTaxAmt.ClientID%>").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;;
                  }
                  addCommasSummry(NetTotal1);
                  addCommasSummry(FinalDiscount1);
                  document.getElementById("<%=txtDiscount.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;;
                  addCommasSummry(FinalGrossTotal1);
                  document.getElementById("<%=txtGrsTotal.ClientID%>").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value;;
                  addCommasSummry(NetTotal1);
                  document.getElementById("<%=txtNetTotal.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenCurrency.ClientID%>").value;;
                  addCommas("txtRate" + RowNum);
                  if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                      addCommas("txtTaxAmt" + RowNum);
                  }
                  addCommas("txtDisAmt" + RowNum);
                  addCommas("txtPrice" + RowNum);

              }
          }
          function AmountChecking(textboxfeild, id) {

              var textboxid = textboxfeild + id;
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
                      var n = num;
                      // for floatting number adjustment from corp global
                      var FloatingValue = "";

                      FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                      if (FloatingValue != "") {
                          n = num.toFixed(FloatingValue);

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

              //var txtPerVal = document.getElementById(textboxid).value;
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
                  //var ret = false;
                  return false;

              }

              else {

                  var ret = true;
                  if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                      ret = false;
                  }

              }
              return ret;
          }


          function isNumberAmount(evt, textboxid) {

              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
              var charCode = (evt.which) ? evt.which : evt.keyCode;

              var txtPerVal = document.getElementById(textboxid).value;

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
          function isDecimalNumberprcntg(evt, textboxid) {
              // alert(textboxid);
              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
              var charCode = (evt.which) ? evt.which : evt.keyCode;
             
              var txtPerVal = document.getElementById(textboxid).value;

              if (txtPerVal > 100) {
                  return false;
              }

              var ret = true;

              if (keyCodes == 13) {
                  ret = false;
              }
                  //0-9
              else if (keyCodes >= 48 && keyCodes <= 57) {
                  ret = true;
              }
                  //numpad 0-9
              else if (keyCodes >= 96 && keyCodes <= 105) {
                  ret = true;
              }
              //    //left arrow key,right arrow key,home,end ,delete
              //else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 38 || keyCodes == 40) {
              //    ret = false;

                  //}
             
              else if (keyCodes == 34 || keyCodes == 33 || keyCodes == 36 || keyCodes == 35 || keyCodes == 41 || keyCodes == 37 || keyCodes == 39) {

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
                  //return ret;

              }
              else {
                  var ret = true;
                  if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                      ret = false;
                  }
                  //return ret;
              }
              if (ret == true) {


                  if (txtPerVal.length == 0 || txtPerVal.length == 1) {

                      if ((charCode >= 48 && charCode <= 57) || (charCode >= 96 && charCode <= 105) || charCode == 190 || charCode == 8 || charCode == 9 || charCode == 46 || charCode == 13 || charCode == 9 || charCode == 110) {

                          return true;
                      }
                  }
                  else if (txtPerVal.length == 2) {
                      if ((txtPerVal > 10) && (charCode == 110 || charCode == 190 || charCode == 46 || charCode == 8 || charCode == 9)) {

                          return true;
                      }

                      else if ((txtPerVal == 10) && (charCode == 48 || charCode == 96 || charCode == 110 || charCode == 190 || charCode == 46 || charCode == 8 || charCode == 9)) {

                          return true;
                      }
                      else if ((txtPerVal < 10) && ((charCode >= 48 && charCode <= 57) || (charCode >= 96 && charCode <= 105) || charCode == 190 || charCode == 8 || charCode == 9 || charCode == 46 || charCode == 13 || charCode == 9 || charCode == 110)) {

                          return true;
                      }
                      else {

                          return false;
                      }
                  }

                  else if (txtPerVal.length == 3) {
                      if ((txtPerVal == 100) && (charCode == 110 || charCode == 190 || charCode == 46 || charCode == 8 || charCode == 9)) {

                          return true;
                      }
                      else if ((txtPerVal.indexOf(".") != -1) && ((charCode >= 48 && charCode <= 57) || (charCode >= 96 && charCode <= 105) || charCode == 190 || charCode == 8 || charCode == 9 || charCode == 46 || charCode == 13 || charCode == 9 || charCode == 35 || charCode == 36 || charCode == 37 || charCode == 39 || charCode == 110)) {
                          return true;
                      }
                      else {
                          return false;
                      }
                  }
                  else if (txtPerVal.length == 4) {
                      if ((txtPerVal.indexOf(".") != -1) && ((charCode >= 48 && charCode <= 57) || (charCode >= 96 && charCode <= 105) || charCode == 190 || charCode == 8 || charCode == 9 || charCode == 46 || charCode == 13 || charCode == 9 || charCode == 35 || charCode == 36 || charCode == 37 || charCode == 39 || charCode == 110)) {
                          return true;
                      }
                      else {
                          return false;
                      }
                  }
                  else if ((charCode == 46 || charCode == 8 || charCode == 9 || charCode == 37 || charCode == 39 || charCode == 35 || charCode == 36)) {
                      return true;
                  }
              }

              return ret;


          }

          function isDecimalNumber(evt, textboxid) {

              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
              var charCode = (evt.which) ? evt.which : evt.keyCode;
              var txtPerVal = document.getElementById(textboxid).value;
              if (keyCodes == 13) {
                  return false;
              }
              else if (keyCodes >= 48 && keyCodes <= 57) {
                  return true;
              }
              else if (keyCodes >= 96 && keyCodes <= 105) {
                  return true;
              }
              else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 38 || keyCodes == 40) {
                  return true;
              }
              else if (keyCodes == 46) {
                  return true;
              }
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
        
          function MyModalCostCenter(x, y, CstCntr) {
             
              var SbCostCenter = '';
              SbCostCenter = '<div class=\"modal fade\" id=\"myModalCstCntr\" role=\"dialog\" data-backdrop=\"static\" data-keyboard=\"false\" >';
              SbCostCenter += '<div class=\"modal-dialog mod1\" role="document" >';
              SbCostCenter += '<div class=\"modal-content\">';
              SbCostCenter += '<div class=\"modal-header\">';
              SbCostCenter += '<button type=\"button\" class=\"close\" onclick=\"return CloseModal(\'' + x + '\')\">&times;</button>';
              SbCostCenter += "<h4 id=\"ModelHeading\" class=\"modal-title\"></h4>";
              SbCostCenter += "</div>";
              SbCostCenter += '<div class=\"alert alert-danger fade in\" id="divErrMsgCnclRsnCostCenter' + x + '" style=\"display: none; margin-top: 1%\">';
              SbCostCenter += '</div>';
              SbCostCenter += '<div class=\"al-box war\"  id="lblErrMsgCancelReasonCostCenter' + x + '"> Please fill this out</div>';
              SbCostCenter += '<div class=\"modal-body md_bd\">';
              SbCostCenter += '<div id=\"DivPopUpCostCenter\">';
              SbCostCenter += '<table class="table table-bordered"  id="TableAddQstnCostCenter' + x + '">';
              SbCostCenter += '<thead class="thead1">';
              SbCostCenter += ' <tr>';
              SbCostCenter += '<th class="col-md-2 tr_l">Cost Group1';
              SbCostCenter += ' </th>';
              SbCostCenter += '  <th class="col-md-2 tr_l">Cost Group2';
              SbCostCenter += '  </th>';
              SbCostCenter += '  <th class="col-md-2 tr_l">Cost Centre';
              SbCostCenter += ' </th>';
              SbCostCenter += '  <th class="col-md-3 tr_r">Amount';
              SbCostCenter += ' </th>';
              SbCostCenter += '  <th class="col-md-3">Actions';
              SbCostCenter += ' </th>';
              SbCostCenter += ' </tr>';
              SbCostCenter += '</thead>';
              SbCostCenter += '</table>';
              SbCostCenter += '</div></div>';
              SbCostCenter += '<div class=\"clearfix\"></div>';
              
              SbCostCenter += '<div class=\"modal-footer\">';
              SbCostCenter += '<div class="col-md-12 col_mar"><div class="box6 tr_r"><label id=\"Label1\" for=\"example-text-input\" class=\"fg2_la1 tt_am am1\" >Ledger Amount<span class="spn1"></span>:</label></div>';
              SbCostCenter += '<div class="box6 flt_r"><span id="LedgerAmtInModal' + x + '" class=\"tt_am am1 tt_al\" ></span></div></div>';
              SbCostCenter += '<label for="example-text-input" class=\"col-form-label\" id="lblCurrencyCC"></label>';
              if (document.getElementById("<%=HiddenviewSts.ClientID%>").value == "1") {
                  SbCostCenter += '<button id="BttnCost' + x + '" type=\"button\" class=\"btn btn-danger\" data-dismiss=\"modal\">Cancel</button>';
              }
              else {
                  SbCostCenter += '<button id="btnImportCostCenter' + x + '" type=\"button\" class=\"btn btn-success\"  onclick=\"ButtnFillClickCostCenter(\'' + x + '\');\" >Submit</button>';
                  SbCostCenter += '<button id="BttnCost' + x + '" type=\"button\" style=\"display:none\" class=\"btn btn-primary\" data-dismiss=\"modal\"></button>';
              }
             // SbCostCenter += '<button id="BttnCost' + x + '" type=\"button\" style=\"display:none\" class=\"btn btn-primary\" data-dismiss=\"modal\"></button>';
              SbCostCenter += '</div></div> </div></div>';
              document.getElementById("CostCenterModal").innerHTML = SbCostCenter;
             
              CostCentr(x, y, CstCntr);
             

              if (document.getElementById("ddlProduct_" + x).value != "") {
                  buttnVisibile(x, "0");
                  var idlast = "";
                  var row = $noCon('#TableAddQstnCostCenter' + x).find(' tbody tr:first').attr('id');
                  idlast = row.split('_');
                  setTimeout(function () { focusCostCentre(idlast[1]); }, 350);
              }
             
              if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                 
                 // document.getElementById("btnImportCostCenter" + x).disabled = true;
                  $("#btnImportCostCenter" + x).attr("disabled", true);
            }

          }
          var currntx = "";
          var currnty = "";
          function FunctionQustn(x, y, CostCenterId, CostGrp1Id, CostGroup2Id) {
             
            
              y++;
              submit++;
              var FrecRowQst = '';
              FrecRowQst += '<tr id="SubQstnRowId_' + x + '' + y + '" ><td   id="tdidQstnDtls' + x + '' + y + '" style="display: none" >' + x + '' + y + '</td>';
              FrecRowQst += '<td   id="tdvalidate' + x + '' + y + '" style="display: none" >' + x + '</td>';
              FrecRowQst += '<td   id="tdvalidatey' + x + '' + y + '" style="display: none" >' + y + '</td>';
              FrecRowQst += '<td >';


              FrecRowQst += '<input name="TxtRecptCosGrp1_' + x + '' + y + '"  style="display: none;" class="fg2_inp2 fg2_inp3 fg_chs1" id="TxtRecptCosGrp1_' + x + '' + y + '" ><div id="divCostGrp1' + x + '' + y + '"><select id="ddlRecptCosGrp1_' + x + '' + y + '" name="ddlRecptCosGrp1_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl" onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostGrp1Id_' + x + '' + y + '" style="display:none"  class="fg2_inp2 fg2_inp3 fg_chs1" id="ddlCostGrp1Id_' + x + '' + y + '" ></td>';

              FrecRowQst += '<td >';
             
             
              FrecRowQst += '<input name="TxtRecptCosGrp2_' + x + '' + y + '"  style="display: none;" class="fg2_inp2 fg2_inp3 fg_chs1" id="TxtRecptCosGrp2_' + x + '' + y + '" ><div id="divCostGrp2' + x + '' + y + '"><select id="ddlRecptCosGrp2_' + x + '' + y + '" name="ddlRecptCosGrp2_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl"  onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostGrp2Id_' + x + '' + y + '" style="display:none"  class="fg2_inp2 fg2_inp3 fg_chs1" id="ddlCostGrp2Id_' + x + '' + y + '" ></td>';
              FrecRowQst += '<td  ><input style="display:none" value="-1" name="TxtIdSales_' + x + '' + y + '" class="form-control" id="TxtIdSales_' + x + '' + y + '" >';
              FrecRowQst += ' <input name="TxtRecptCosCtr_' + x + '' + y + '"  style="display: none;" class="fg2_inp2 fg2_inp3 fg_chs1" id="TxtRecptCosCtr_' + x + '' + y + '" ><div id="divCostCenter' + x + '' + y + '">';
              FrecRowQst += ' <select id="ddlRecptCosCtr_' + x + '' + y + '" name="ddlRecptCosCtr_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl" onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  >';
              FrecRowQst += '</select></div><input name="ddlCostCtrId_' + x + '' + y + '" style="display:none"  class="fg2_inp2 fg2_inp3 fg_chs1 ddl" id="ddlCostCtrId_' + x + '' + y + '" ></td>';
              FrecRowQst += '<td  class=" tr_r" > <div class="input-group">  <span class="input-group-addon cur1">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span><input class="form-control fg2_inp2 tr_r" autocomplete="\off"\  maxlength="10"  id="TxtCstctrAmount_' + x + '' + y + '" name="TxtCstctrAmount_' + x + '' + y + '" value="" onblur="return CheckSumOfCstCntr(\'TxtCstctrAmount_' + x + '' + y + '\',' + x + ',' + y + ');"  onkeydown="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '' + y + '\');" onkeypress="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '' + y + '\');" id="TxtCstctrAmount_' + x + '' + y + '" type="text" ><input class="form-control fg2_inp2 tr_r"   id="TxtActCstctrAmount_' + x + '' + y + '" value="" onblur="return CheckSumOfLedger(\'TxtActCstctrAmount_' + x + '' + y + ',' + x + ',' + y + '\');" onkeyup="addCommas("TxtActCstctrAmount_' + x + '' + y + ')" style="display:none" onkeydown="return isNumberAmount(event,TxtActCstctrAmount_' + x + '' + y + ');" name="TxtActCstctrAmount_' + x + '' + y + '" type="text"></td>';






              FrecRowQst += '<td  class="td1"><div class="btn_stl1">';

              FrecRowQst += '<button title="ADD" id="btnCostCenter_' + x + '' + y + '" onclick="return CheckaddMoreRowsQstn(\'' + x + '\',\'' + y + '\',\'' + x + '' + y + '\');" class="btn act_btn bn2"><i class="fa fa-plus-circle"></i></button>';
              FrecRowQst += '<button class="btn act_btn bn3" id="btnCostCenterDel_' + x + '' + y + '" onclick="return removeRowQstn(' + x + ',' + y + ',' + x + '' + y + ',\'Are you sure you want to delete this cost centre?\')" style="">';
              FrecRowQst += '<span title="DELETE"   class="fa fa-trash" id="Span4" style="display: block;">&nbsp;</span></button></td>';

              FrecRowQst += '<td   style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value="INS" id="tdEvtQstn' + x + '' + y + '" name="tdEvtQstn' + x + '' + y + '" placeholder=""/></td>';
              FrecRowQst += '<td style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdDtlIdQstn' + x + '' + y + '" name="tdDtlIdQstn' + x + '' + y + '" placeholder=""/></td>';
              FrecRowQst += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdInxQstn' + x + '' + y + '" name="tdInxQstn' + x + '' + y + '" placeholder=""/> </td></tr>';
              jQuery('#TableAddQstnCostCenter' + x).append(FrecRowQst);
              //ddlCostCtrId_

              FillddlAcntGrp1(x, y, CostGrp1Id);


              $au("#ddlRecptCosGrp1_" + x + '' + y).selectToAutocomplete1Letter();

              FillddlAcntGrp2(x, y, CostGroup2Id);


              $au("#ddlRecptCosGrp2_" + x + '' + y).selectToAutocomplete1Letter();
              //  CheckSubmitZero();


              FillddlCostCenter(x, y, CostCenterId);

              //$au("#ddlRecptCosCtr_" + x + '' + y).selectToAutocomplete1Letter();
              $au("#ddlRecptCosCtr_" + x + '' + y).selectToAutocomplete1Letter();

              currntx = x;
              currnty = y;
              if (document.getElementById("<%=HiddenviewSts.ClientID%>").value == "1") {
                  document.getElementById("btnCostCenter_" + x + y).disabled = "true";
                  document.getElementById("btnCostCenterDel_" + x + y).disabled = "true";
                  $("#TableAddQstnCostCenter" + x).find("input").attr("disabled", "disabled");
              }
              $("#divCostGrp1" + x + "" + y + " > input").focus();
              $("#divCostGrp1" + x + "" + y + " > input").select();

              return false;

          }
          </script>
          <script>
          function CostCentr(x, y, CostCenterId) {
           
              $("#divProduct_" + x + "> input").css("borderColor", "");
              if ((document.getElementById("ddlProduct_" + x).value != "" && document.getElementById("ddlProduct_" + x).value != 0)) {
                  var LedgerId = document.getElementById("ddlProduct_" + x).value;
                 
                   
                  if (document.getElementById("tdCostCenterDtls" + x).value != "")
                  {
                      var CstCntrDtl = document.getElementById("tdCostCenterDtls" + x).value;
                      var splitrow = CstCntrDtl.split("$");
                      for (var Cst = 0; Cst < splitrow.length; Cst++) {
                          var splitEach = splitrow[Cst].split("%");

                          FunctionQustn(x, currnty, splitEach[0], splitEach[2], splitEach[3]);

                          if (splitEach[0] != 0 && splitEach[1] != "" && splitEach[1] != "null" && splitEach[1] != null && splitEach[1] != "undefined") {
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
                  var Price = "";
                  if (document.getElementById("txtPrice" + x).value != "") {
                      Price = document.getElementById("txtPrice" + x).value;
                  }
                  addCommasSummry(Price);
                  document.getElementById("BtnPopupCstCntr").click();
                  var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                  document.getElementById("LedgerAmtInModal" + x).innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                  if (document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value != "") {
                      document.getElementById("LedgerAmtInModal" + x).innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value;
                  }
              }
              if (document.getElementById("ddlProduct_" + x).value == "" || document.getElementById("ddlProduct_" + x).value == 0) {
                
                  $("#divProduct_" + x + "> input").css("borderColor", "red");
                  $("#divProduct_" + x + "> input").focus();
                  $("#divProduct_" + x + "> input").select();
              }

          }

          function buttnVisibile(y, Check) {
             
              var table = document.getElementById("TableaddedRows");
              var x = table.rows.length;

              var TableRowCount = document.getElementById("TableaddedRows").rows.length;
              if (TableRowCount != 0) {
                  var idlast = $noCon('#TableaddedRows  tr:last').attr('id');
                  if (idlast != "") {
                      var res = idlast.split("_");
                      document.getElementById("SpanAdd" + res[1]).disabled = false;
                      document.getElementById("SpanAdd" + res[1]).style.pointerEvents = 'auto';
                      BlurValue(res[1], 'txtDisAmt');
                  }
              }
            
              if (y != 0) {
                  if (Check == "0") {
                       var TableRowCount1 = document.getElementById("TableAddQstnCostCenter" + y).rows.length;
                      if (TableRowCount1 != 0) {
                          var idlast1 = $noCon('#TableAddQstnCostCenter' + y + ' tr:last').attr('id');
                        
                          if (idlast1 != "") {
                              var res1 = idlast1.split("_");
                              document.getElementById("tdInxQstn" + res1[1]).value = "";
                              document.getElementById("btnCostCenter_" + res1[1]).style.opacity = "1";
                          }
                      }
                  }
              }
          }
          function ButtnFillClickCostCenter(x) {
             
              var ret = true;
              var TotalAmnt = 0;
              var purchaseFlag = 0;
              var CheckCount = 0;
              var TotalAmnt = document.getElementById("txtPrice" + x).value;
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
                  
                  var CostGrp1 = $("#ddlRecptCosGrp1_" + varId).val();
                  var CostGrp2 = $("#ddlRecptCosGrp2_" + varId).val();

                  if (CostGrp1 != 0 || CostGrp2 != 0 || Costval != 0 || document.getElementById("TxtCstctrAmount_" + varId).value != "") {

                      if (document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                          document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                          document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Please enter cost centre amount";
                          $("div.war").fadeIn(200).delay(500).fadeOut(400);
                          document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "";
                          document.getElementById("TxtCstctrAmount_" + varId).focus();
                          ret = false;
                      }
                      if (Costval == 0) {
                          
                          $("#divCostCenter" + varId + "> input").css("borderColor", "Red");
                          document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Please select a cost centre";
                          $("div.war").fadeIn(200).delay(500).fadeOut(400);
                          document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "";
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
                  if (CstTotal != "0") {
                      if (parseFloat(TotalAmnt) != parseFloat(CstTotal)) {
                          document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = " Product amount should be equal to cost centre amount";
                          $("div.war").fadeIn(200).delay(500).fadeOut(400);
                          document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "";
                          document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                          document.getElementById("TxtCstctrAmount_" + varId).focus();

                          ret = false;
                      }
                  }
              }
              if (ret == true) {
                  if (purchaseFlag != 0) {
                      document.getElementById("tdCostCenterDtls" + x).value = "";

                      for (var i = 1; i < addRowtable.rows.length; i++)
                      {
                          var varId = (addRowtable.rows[i].cells[0].innerHTML);
                         

                          var Costcntrval = document.getElementById("ddlCostCtrId_" + varId).value;
                              //$('#ddlRecptCosCtr_' + varId).val();
                          
                        
                         
                          if (Costcntrval != 0 && document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                              if (document.getElementById("tdCostCenterDtls" + x).value == "") {
                                  document.getElementById("tdCostCenterDtls" + x).value = Costcntrval + "%" + document.getElementById("TxtCstctrAmount_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp1_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp2_" + varId).value;
                              }
                              else {
                                  document.getElementById("tdCostCenterDtls" + x).value = document.getElementById("tdCostCenterDtls" + x).value + "$" + Costcntrval + "%" + document.getElementById("TxtCstctrAmount_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp1_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp2_" + varId).value;

                              }
                          }
                          //alert(document.getElementById("tdCostCenterDtls" + x).value);

                      }
                  }
                  document.getElementById("BttnCost" + x).click();
                 // document.getElementById("ChkCostCenter" + x).focus();
              }

          }
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
          function ddlCostCenterOnchange(x, y) {
              IncrmntConfrmCounter();
              if (document.getElementById("ddlRecptCosCtr_" + x + '' + y).value != 0) {
                  var ddlCostcnt = document.getElementById("ddlRecptCosCtr_" + x + '' + y).value;
                  document.getElementById("ddlCostCtrId_" + x + '' + y).value = ddlCostcnt;
              }
              CCDuplication(x, x + '' + y);
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
          function CheckSumOfCstCntr(textboxid, x, y) {

              if (document.getElementById(textboxid).value != "" && document.getElementById(textboxid).value != "0") {
                  var CstTotal = 0;
                  var LedgerTotal = 0;
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
                          if (document.getElementById("txtPrice" + x).value != "") {
                              var ledramt = document.getElementById("txtPrice" + x).value;
                              ledramt = ledramt.replace(/\,/g, '');
                              if (FloatingValue != "") {
                                  ledramt = parseFloat(ledramt);
                                  ledramt = ledramt.toFixed(FloatingValue);
                              }
                              LedgerTotal = parseFloat(LedgerTotal) + +parseFloat(ledramt);
                              addCommas("txtPrice" + x);
                          }
                      }
                  });
              }
              else {
                  document.getElementById(textboxid).value = "";
              }
            return true;
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
                                  var res = idlast.split("_");
                                  setTimeout(function () { focusCostCentre(res[1]); }, 350);
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
          function CheckAndHighlightCostCenter(x) {
            
              var ret = true;
              var CstTotal = 0;
              var varId = "";
              var varfocus = "";
              $('#TableAddQstnCostCenter' + x + ' td:first-child').each(function () {
                  varId = $(this).text();
                  var Costcenterval = $("#ddlRecptCosCtr_" + varId).val();
                  var ledgerval = $("#ddlProduct_" + x).val();
                  document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
                  $("#divCostCenter" + varId + "> input").css("borderColor", "");
                  $("#divCostGrp1" + varId + "> input").css("borderColor", "");
                  $("#divCostGrp2" + varId + "> input").css("borderColor", "");
                  $("#ddlProduct_" + x + "> input").css("borderColor", "");
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

                      if (costId != "" && costId != null && costId != null) {
                          var arrayProduct = JSON.parse("[" + costId + "]");
                          $noCon("#ddlRecptCosCtr_" + rowCountX + "" + rowCountY).val(arrayProduct);
                      }
                      else {

                      }
                  });
              }
              else {
                  var OptionStart = $noCon("<option>--SELECT--</option>");
                  OptionStart.attr("value", 0);
                  ddlTestDropDownListXML1.append(OptionStart);
              }
          }


          function FillddlAcntGrp1(rowCountX, rowCountY, COSTCNTR_ID) {
              var ddlTestDropDownListXML1 = "";
              ddlTestDropDownListXML1 = $noCon("#ddlRecptCosGrp1_" + rowCountX + "" + rowCountY);
              var intOrgID = '<%= Session["ORGID"] %>';
              var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
              var tableName = "dtTableCostCenter";
               if (document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value != "0")
              {
                  ddlLed = document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value;
                  var OptionStart = $noCon("<option>--SELECT--</option>");
                  OptionStart.attr("value", 0);
                  ddlTestDropDownListXML1.append(OptionStart);
                  $noCon(ddlLed).find(tableName).each(function () {
                      var OptionValue = $noCon(this).find('COSTGRP_ID').text();
                      var OptionText = $noCon(this).find('COSTGRP_NAME').text();
                      var option = $noCon("<option>" + OptionText + "</option>");
                      option.attr("value", OptionValue);
                      ddlTestDropDownListXML1.append(option);

                      if (COSTCNTR_ID != "" && COSTCNTR_ID != null && COSTCNTR_ID != "null") {
                          var arrayProduct = JSON.parse("[" + COSTCNTR_ID + "]");
                          $noCon("#ddlRecptCosCtr_" + rowCountX + "" + rowCountY).val(arrayProduct);
                      }

                                        


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
              var tableName = "dtTableCostCenter";
              if (document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value != "0") {
                  ddlLed = document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value;
                  var OptionStart = $noCon("<option>--SELECT--</option>");
                  OptionStart.attr("value", 0);
                  ddlTestDropDownListXML1.append(OptionStart);
                  $noCon(ddlLed).find(tableName).each(function () {
                      var OptionValue = $noCon(this).find('COSTGRP_ID').text();
                      var OptionText = $noCon(this).find('COSTGRP_NAME').text();
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

              function ChangeProduct(evt, RATE) {
                  var ret = true;
                  var $noCon = jQuery.noConflict();
                  var x2 = evt;
                  var strproductId = document.getElementById("ddlProduct_" + x2).value;
                  if (strproductId == "--SELECT PRODUCT--" || strproductId == "") {

                      var hiddenHeadValId = document.getElementById("<%=HiddenFocusId.ClientID%>").value;
                      var hiddenHeadValText = document.getElementById("<%=HiddenFocusName.ClientID%>").value;
                      if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                          document.getElementById("txtproductName" + x2).value = hiddenHeadValText;
                          document.getElementById("ddlProduct_" + x2).value = hiddenHeadValText;
                          document.getElementById("txtproductId" + x2).value = hiddenHeadValId;
                      }

                      // document.getElementById("<%=HiddenFocusId.ClientID%>").value ;
                      //  document.getElementById("<%=HiddenFocusName.ClientID%>").value ;

                      document.getElementById('txtQntity' + x2).readOnly = true;
                      //  document.getElementById('txtQntity' + x2).disabled = true;

                      document.getElementById('txtQntity' + x2).value = "";
                      document.getElementById('txtDisPercent' + x2).disabled = true;
                      document.getElementById('txtDisPercent' + x2).value = "";
                      //document.getElementById('ddlTaxText' + RowNum).disabled = true;
                      document.getElementById('txtDisAmt' + x2).disabled = true;
                      document.getElementById('txtDisAmt' + x2).value = "";
                      if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {

                          document.getElementById('ddlTax' + x2).disabled = true;
                          document.getElementById('ddlTax' + x2).value = "";
                          document.getElementById('txtTaxAmt' + x2).disabled = true;
                          document.getElementById('txtTaxAmt' + x2).value = "";
                          document.getElementById('txttaxprcntg' + x2).readOnly = true;

                      }
                      document.getElementById('txtRate' + x2).disabled = true;
                      document.getElementById('txtRate' + x2).value = "";
                      document.getElementById('txtPrice' + x2).disabled = true;
                      document.getElementById('txtPrice' + x2).value = "";

                      if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {

                          document.getElementById('txttaxprcntg' + x2).value = "";
                      }
                      BlurValue(x2, null);




                  }
                  else {

                      var PrdctName = document.getElementById("txtproductName" + x2).value.trim();
                      $noCon("#ddlProduct_" + x2).attr("title", PrdctName);
                      if (PrdctName != "" || PrdctName != "--SELECT PRODUCT--") {

                          document.getElementById("ddlProduct_" + x2).value = PrdctName;

                      }
                      var valuesSel = "";
                      FillTax(x2, valuesSel, RATE);


                      if (ProductDuplication(x2) == false) {
                          ret = false;

                          // $("#divProduct_" + x2).focus();
                          $("#divProduct_" + x2 + "> input").focus();
                          $("#divProduct_" + x2 + "> input").select();

                          $noCon("#divWarning").html("Product should not be duplicated.");
                          $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                          });

                          $noCon(window).scrollTop(0);


                      }

                  }
                  return ret;
              }


          function FillTax(rowCount, TAX_VALUES,RATE) {
                  var ddlTestDropDownListXML = $noCon("#ddlTax" + rowCount);
           
                  var strproductId = document.getElementById("txtproductId" + rowCount).value;

                
                  if (strproductId != "--SELECT PRODUCT--" && strproductId != "") {
                      var strOrgId = '<%=Session["ORGID"]%>';
                      var strCorpId = '<%=Session["CORPOFFICEID"]%>';
                      var tableName = "dtTableLoadTax";

                      $noCon.ajax({
                          type: "POST",
                          url: "fms_Sales_Master.aspx/DropdownTaxBind",
                          data: '{strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '",strproductId:"' + strproductId + '"}',
                          contentType: "application/json; charset=utf-8",
                          dataType: "json",
                          success: function (response) {
                              $noCon(response.d).find(tableName).each(function () {
                                  var OptionValue = $noCon(this).find('TAX_ID').text();
                                  var OptionText = $noCon(this).find('TAX_NAME').text();
                                  var OptionRate = $noCon(this).find('PRDT_COST_PRICE').text();
                                  var OptionTaxprcng = $noCon(this).find('TAX_PERCENTAGE').text();
                                  var defultVal = "";
                                  if (OptionText != "") {
                                      if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {

                                          $noCon("#txttaxid" + rowCount).val(OptionValue);
                                          $noCon("#ddlTax" + rowCount).val(OptionText);
                                          $noCon("#ddlTax" + rowCount).attr("title", OptionText);
                                      }
                                  }
                                  else {
                                      if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                                          $noCon("#txttaxid" + rowCount).val("");
                                          $noCon("#ddlTax" + rowCount).val("");
                                          $noCon("#txtTaxAmt" + rowCount).val(defultVal);
                                          $noCon("#txttaxprcntg" + rowCount).val(defultVal);
                                          

                                      }
                                  }
                                 if (RATE != "" && RATE != null) {
                                      $noCon("#txtRate" + rowCount).val(RATE);
                                  }
                                 else if (OptionRate != "") {
                                     $noCon("#txtRate" + rowCount).val(OptionRate);
                                 }
                                  else {
                                      $noCon("#txtRate" + rowCount).val(defultVal);
                                  }
                                  if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                                      if (OptionTaxprcng != "") {
                                          $noCon("#txttaxprcntg" + rowCount).val(OptionTaxprcng);
                                          var taxtAmtprcng = OptionTaxprcng / 100;

                                          var qty = document.getElementById("txtQntity" + rowCount).value;

                                          var taxAmt = "";
                                          if (qty != "") {

                                              taxAmt = qty * OptionRate * taxtAmtprcng;
                                          }
                                          else {
                                              taxAmt = OptionRate * taxtAmtprcng;
                                          }


                                          $noCon("#txtTaxAmt" + rowCount).val(taxAmt);
                                      }
                                      else {
                                          $noCon("#txtTaxAmt" + rowCount).val(defultVal);
                                      }



                                      var tax = "";
                                      if (TAX_VALUES != null)
                                          tax = TAX_VALUES;


                                      if (tax != "") {

                                          var arraytax_VALUES = JSON.parse("[" + TAX_VALUES + "]");

                                          $noCon("#ddlTax" + rowCount).val(arraytax_VALUES);



                                      }
                                  }

                                  BlurValue(rowCount, null);

                              });
                          },
                          failure: function (response) {

                          }

                      });
                  }
              }
              function FillddlProduct(rowCount, PRODUCT_VALUES, PRODUCT_NAME, PRDCT_CHCK) {
                  addCommas("txtRate" + rowCount);
                  addCommas("txtTaxAmt" + rowCount);
                  addCommas("txtDisAmt" + rowCount);
                  addCommas("txtPrice" + rowCount);
                  var ddlTestDropDownListXML = $noCon("#ddlProduct_" + rowCount);
                  var strOrgId = '<%=Session["ORGID"]%>';
                  var strCorpId = '<%=Session["CORPOFFICEID"]%>';
                  var tableName = "dtTableLoadProduct";

                  $noCon.ajax({
                      type: "POST",
                      url: "fms_Sales_Master.aspx/DropdownProductBind",
                      async :false,
                      data: '{strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '"}',
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function (response) {

                          $noCon(response.d).find(tableName).each(function () {
                              // Get the OptionValue and OptionText Column values.
                              var OptionValue = $noCon(this).find('PRDT_ID').text();
                              var OptionText = $noCon(this).find('PRDT_NAME').text();
                              // Create an Option for DropDownList.
                              if (OptionText != "") {
                                  $noCon("#txtproductId" + rowCount).val(OptionValue);
                                  var option = $noCon("<option>" + OptionText + "</option>");
                                  option.attr("value", OptionValue);
                                  ddlTestDropDownListXML.append(option);
                              }

                
                              //  BlurValue(rowCount, null);
                              if (PRODUCT_VALUES != null)
                                  tax = PRODUCT_VALUES;
                   
                              //if (tax != "") {

                              //    var arrayPRDT_VALUES = JSON.parse("[" + PRODUCT_VALUES + "]");
                              //    $noCon("#ddlProduct_" + rowCount).val(arrayPRDT_VALUES);
                              //                       }
                   
                          });
                
                          if (PRDCT_CHCK==0)
                          {
                              if (PRODUCT_VALUES != null)
                              {
                                  // var $Mo = jQuery.noConflict();
                                  var newOption = "<option value='" + PRODUCT_VALUES + "'>" + PRODUCT_NAME + "</option>";

                                  $aa("#ddlProduct_" + rowCount).append(newOption);
                                  //SORTING DDL
                                  var options = $aa("#ddlProduct_" + rowCount+" option");                    // Collect options         
                                  options.detach().sort(function (a, b) {               // Detach from select, then Sort
                                      var at = $aa(a).text();
                                      var bt = $aa(b).text();
                                      return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                                  });
                                  options.appendTo("#ddlProduct_" + rowCount);
               
                              }
                          }
                      },
                      failure: function (response) {

                      }
                  });
              
              }
     
              function AddDeleted(Delrowcount) {

                  if (document.getElementById("tdEvt" + Delrowcount).innerHTML == "UPD") {
                      var detailId = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value;
                      detailId = detailId + "," + document.getElementById("tdDtlId" + Delrowcount).innerHTML;
                      document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = detailId;

                  }

              }

              var $noconfli = jQuery.noConflict();
              function CheckDelEachRow(Delrowcount) {
                
              
                  ezBSAlert({
                      type: "confirm",
                      messageText: "Do you want to delete this product?",
                      alertType: "info"
                  }).done(function (e) {
                      if (e == true) {
                        
                          AddDeleted(Delrowcount);
                          jQuery('#rowId_' + Delrowcount).remove();
                          var table = document.getElementById("TableaddedRows");
                          var x = table.rows.length;
                          var Rownum = document.getElementById("<%=HiddenRownum.ClientID%>").value;
                      
                          var len;
                       
                          ReNumberTable();
                          var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                          if (TableRowCount != 0) {
                              var idlast = $noCon('#TableaddedRows  tr:last').attr('id');
                           
                              if (idlast != "") {
                               
                                  var res = idlast.split("_");
                              
                                  document.getElementById("SpanAdd" + res[1]).disabled = false;
                                  document.getElementById("SpanAdd" + res[1]).style.pointerEvents = 'auto';
                                  BlurValue(res[1], 'txtDisAmt');
                            
                              }
                          }
                          else {
                         
                              document.getElementById("<%=txtGrsTotal.ClientID%>").innerHTML = "";
                              document.getElementById("<%=txtTotalTaxAmt.ClientID%>").innerHTML = "";
                              document.getElementById("<%=txtDiscount.ClientID%>").value = "";
                              document.getElementById("<%=txtNetTotal.ClientID%>").value = "";
                              addMoreRows();
                          }


                
                      }
                  });
                  return false;
              }
          function focusCostCentre(Rowid) {

              $("#divCostGrp1" + Rowid + " > input").focus();
              $("#divCostGrp1" + Rowid + " > input").select();
          }
              var flag = 0;
              var discountOrAmt = "";
              function QuantityChk(rowCount) {
                  document.getElementById("txtQntity" + rowCount).style.borderColor="Red";
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                  });
                
                  $noCon1(window).scrollTop(0);

                  return false;
              }

              function RateChk(rowCount) {
                  document.getElementById("txtRate" + rowCount).style.borderColor = "Red";
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                  });
                
                  $noCon1(window).scrollTop(0);

                  return false;
              }

              function BlurValue(rowCount, textField) {
                
                  var Table = "";
                  var VartxtQntity = 0;
                  var VartxttaxAmt = 0;
                  var VartxtRatevalue = 0;
                  var OptionTaxPercentage = 0;
                  var total = 0;
                  var txtDisPercentage = "";
                  var txtDisAmt = 0;
                  var taxAmt = 0;
                  var DisAmt = 0;
                  var DisPer = 0;
                  var Grosstotal = 0;
                  if ((textField == "txtDisPercent") || (textField == "txtDisAmt") || (textField == "txtPrice") || (textField == "txtQntity")) {
                      AmountChecking(textField, rowCount);
                  }
                  //if (textField == "txtQntity") {
                  //    RemoveNaN_OnBlur(textField + rowCount);
                  //}
               
                  if (textField != "txtDisAmt" && textField != "txtDisPercent" && document.getElementById("txtDisPercent" + rowCount).value == "0" && document.getElementById("txtDisAmt" + rowCount).value == "0") {
                      $noCon("#txtDisAmt" + rowCount).val(0);
                      $noCon("#txtDisPercent" + rowCount).val(0);
                  }
                  if (document.getElementById('txtDisAmt' + rowCount).value != "") {
                      DisAmt = document.getElementById('txtDisAmt' + rowCount).value;
                  }
                  var strproductId = document.getElementById("ddlProduct_" + rowCount).value;
                  VartxtQntity = document.getElementById("txtQntity" + rowCount).value.replace(/,/g, "")
                  VartxtRatevalue = document.getElementById("txtRate" + rowCount).value;

               
                  
               
                  if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                      VartxttaxAmt = document.getElementById("txtTaxAmt" + rowCount).value;
                      OptionTaxPercentage = document.getElementById("txttaxprcntg" + rowCount).value;
                  }
                  else {
                      VartxttaxAmt = "0";
                      OptionTaxPercentage = "0";
                  }

                  var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                  if (isNaN(OptionTaxPercentage)) {
                      document.getElementById("txttaxprcntg" + rowCount).value = "";
                      OptionTaxPercentage = "0";
                  }
               
                      if (OptionTaxPercentage != "" && OptionTaxPercentage != 0) {
                          if (document.getElementById("txtQntity" + rowCount).value == "") {
                              var taxtAmtprcng = parseFloat(OptionTaxPercentage) / 100;
                              if (isNaN(VartxtRatevalue)) {
                                  document.getElementById("txtRate" + rowCount).value = "";
                                  VartxtRatevalue =0;
                                 
                              }
                              else {
                                  VartxtRatevalue = VartxtRatevalue.replace(/,/g, "");
                                  taxAmtint = parseFloat(VartxtRatevalue) * parseFloat(taxtAmtprcng);
                              }

                              if (FloatingValue != "") {
                                  taxAmtint = taxAmtint.toFixed(FloatingValue);

                              }
                              document.getElementById("txtTaxAmt" + rowCount).value = taxAmtint;

                          }
                      }
                  
           VartxtRatevalue = VartxtRatevalue.replace(/,/g, "");
           VartxttaxAmt = VartxttaxAmt.replace(/,/g, "");
           if (VartxtQntity != 0 && VartxtRatevalue != 0) {
               total = parseFloat(VartxtQntity) * parseFloat(VartxtRatevalue);
               if (FloatingValue != "") {
                   total = total.toFixed(FloatingValue);
               }
           }
           if (flag == 1) {
               if (document.getElementById('txtDisAmt' + rowCount).disabled == false && document.getElementById('txtDisPercent' + rowCount).disabled == false) {
                   flag = 0;
                   discountOrAmt = "";
               }

           }
           if (textField == "txtDisPercent") {
               //|| textField == "txtQntity"
               if (flag == 0) {


                   flag++;
                   discountOrAmt = "txtDisPercent";
               }
           }
        
           if (discountOrAmt == "txtDisPercent" || textField == "txtQntity") {


               txtDisPercentage = document.getElementById("txtDisPercent" + rowCount).value;
               VartxtRatevalue = VartxtRatevalue.replace(/,/g, "");


               if (txtDisPercentage != "" && txtDisPercentage != 0 && txtDisPercentage != null && total != 0) {


                   DisAmt = parseFloat(VartxtRatevalue) * parseFloat(VartxtQntity) * (parseFloat(txtDisPercentage) / 100);

                   if (FloatingValue != "") {
                       DisAmt = parseFloat(DisAmt);
                       txtDisPercentage = parseFloat(txtDisPercentage);
                       DisAmt = DisAmt.toFixed(FloatingValue);
                       txtDisPercentage = txtDisPercentage.toFixed(FloatingValue);
                   }
                   $noCon("#txtDisAmt" + rowCount).val(DisAmt);
                   $noCon("#txtDisPercent" + rowCount).val(txtDisPercentage);
                   if (DisAmt == 0) {
                       $noCon("#txtDisPercent" + rowCount).val(0);
                   }
               }
               else {
                   $noCon("#txtDisAmt" + rowCount).val(0);

                   $noCon("#txtDisPercent" + rowCount).val(0);
                   document.getElementById("<%=Hiddendiscount.ClientID%>").value = 0;
                   
                   document.getElementById('txtDisPercent' + rowCount).style.pointerEvents = "";

                   if (document.getElementById("<%=HiddenDiscountEnableSts.ClientID%>").value == "1") {


                              document.getElementById('txtDisPercent' + rowCount).disabled = false;
                              document.getElementById('txtDisAmt' + rowCount).style.pointerEvents = "";
                              document.getElementById('txtDisAmt' + rowCount).disabled = false;
                          }
                          else {
                              document.getElementById('txtDisPercent' + rowCount).disabled = true;

                              document.getElementById('txtDisAmt' + rowCount).disabled = true;
                          }
                      }
                  }
                  if (textField == "txtDisAmt") {
                      if (flag == 0) {

                          flag++;
                          discountOrAmt = "txtDisAmt";

                      }
                  }
                  if (discountOrAmt == "txtDisAmt") {
                      DisAmt = document.getElementById("txtDisAmt" + rowCount).value;
                      DisAmt = DisAmt.replace(/,/g, "");
                      if (DisAmt != "" && DisAmt != 0 && DisAmt != null && total != 0) {
                          var prcntg = parseFloat(DisAmt) * 100;
                          if (isNaN(VartxtRatevalue)) {
                              document.getElementById("txtRate" + rowCount).value = "";
                              VartxtRatevalue = 0;
                             
                          }
                          DisPer = parseFloat(prcntg) / (parseFloat(VartxtQntity) * parseFloat(VartxtRatevalue));
                          DisPer = parseFloat(DisPer);
                          if (FloatingValue != "") {
                              DisPer = DisPer.toFixed(FloatingValue);
                              DisAmt = parseFloat(DisAmt);

                              DisAmt = DisAmt.toFixed(FloatingValue);
                          }
                          $noCon("#txtDisPercent" + rowCount).val(DisPer);
                          $noCon("#txtDisAmt" + rowCount).val(DisAmt);
                      }
                      else {
                          $noCon("#txtDisPercent" + rowCount).val(0);
                          $noCon("#txtDisAmt" + rowCount).val(0);
                          document.getElementById("<%=Hiddendiscount.ClientID%>").value = 0;
                          document.getElementById('txtDisPercent' + rowCount).style.pointerEvents = "";
                          document.getElementById('txtDisPercent' + rowCount).disabled = false;
                          document.getElementById('txtDisAmt' + rowCount).style.pointerEvents = "";
                          document.getElementById('txtDisAmt' + rowCount).disabled = false;
                      }
                  }

                  if (OptionTaxPercentage != "" && OptionTaxPercentage != 0 && total != 0) {
                      var taxtAmtprcng = parseFloat(OptionTaxPercentage) / 100;
                      if (isNaN(VartxtRatevalue)) {
                          document.getElementById("txtRate" + rowCount).value = "";
                          VartxtRatevalue = 0;
                        
                      }
                      taxAmt = parseFloat(VartxtQntity) * parseFloat(VartxtRatevalue) * parseFloat(taxtAmtprcng);
                      taxAmt = parseFloat(taxAmt);
                      if (FloatingValue != "") {
                          taxAmt = taxAmt.toFixed(FloatingValue);
                      }
                      $noCon("#txtTaxAmt" + rowCount).val(taxAmt);
                  }
                  if (VartxtRatevalue != 0 && VartxtQntity != 0) {
                      VartxtRatevalue = VartxtRatevalue.replace(/,/g, "");
                      if (DisAmt != "" && DisAmt != null) {
                          var pricewithoutTax = ((parseFloat(VartxtRatevalue) * parseFloat(VartxtQntity)) - (parseFloat(DisAmt)));
                      }
                      else {
                          var pricewithoutTax = parseFloat(VartxtRatevalue) * parseFloat(VartxtQntity);
                      }
                      var price = parseFloat(pricewithoutTax) + parseFloat(taxAmt);
                      price = price.toFixed(FloatingValue);
                      $noCon("#txtPrice" + rowCount).val(price);
                  }
                  else {
                      $noCon("#txtPrice" + rowCount).val(0);
                  }
                  curncyChangeFunt('1');
                  var FinalGrossTotal = 0;
                  var FinalTax = 0;
                  var NetTotal = 0;
                  var FinalDiscount = 0;
                  var Defult_Totl = 0;
                  var RowNum = document.getElementById("<%=HiddenRowNo.ClientID%>").value;
                  $('#TableaddedRows').find('tr').each(function () {
                      var row = $(this);

                      var rowid = $('td:first-child', row).html();

                      if (rowid != "") {
                          var rate1 = 0;
                          rate1 = document.getElementById("txtRate" + rowid).value;
                          rate1 = rate1.replace(/,/g, "");
                          var qty1 = document.getElementById("txtQntity" + rowid).value;

                          var txAmt1 = "0";
                          if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                              if (document.getElementById("txtTaxAmt" + rowid).value != "") {
                                  txAmt1 = document.getElementById("txtTaxAmt" + rowid).value;
                              }
                          }
                          txAmt1 = txAmt1.replace(/,/g, "");
                          var discnt1 = "0";
                          if (document.getElementById("txtDisAmt" + rowid).value != "") {
                              discnt1 = document.getElementById("txtDisAmt" + rowid).value;
                              discnt1 = discnt1.replace(/,/g, "");
                              var vartxtDisAmt = 0;
                              vartxtDisAmt = discnt1;
                              vartxtDisAmt = parseFloat(vartxtDisAmt);
                              vartxtDisAmt = vartxtDisAmt.toFixed(FloatingValue);
                              document.getElementById("txtDisAmt" + rowid).value = vartxtDisAmt;
                          }
                          var discntPercent = "0";

                          if (document.getElementById("txtDisPercent" + rowid).value != "") {
                              discntPercent = document.getElementById("txtDisPercent" + rowid).value;
                              discntPercent = discntPercent.replace(/,/g, "");
                              var vartxtPercent = 0;
                              vartxtPercent = discntPercent;
                              vartxtPercent = parseFloat(vartxtPercent);
                              vartxtPercent = vartxtPercent.toFixed(FloatingValue);
                              document.getElementById("txtDisPercent" + rowid).value = vartxtPercent;
                          }
                          if (document.getElementById("txtRate" + rowid).value != "") {
                              var vartxtRate = 0;
                              if (FloatingValue != "") {
                                  vartxtRate = document.getElementById("txtRate" + rowid).value;
                                  vartxtRate = vartxtRate.replace(/,/g, "");
                                  vartxtRate = parseFloat(vartxtRate);
                                  vartxtRate = vartxtRate.toFixed(FloatingValue);
                                  document.getElementById("txtRate" + rowid).value = vartxtRate;
                              }
                          }
                          if (rate1 != "" && qty1 != "") {
                              FinalGrossTotal = parseFloat(FinalGrossTotal) + (parseFloat(rate1) * parseFloat(qty1));
                          }
                          if (txAmt1 != "" && txAmt1 != "0") {
                              FinalTax = parseFloat(FinalTax) + parseFloat(txAmt1);
                          }
                          if (discnt1 != "" && discnt1 != null) {
                              discnt1 = parseFloat(discnt1);
                              FinalDiscount = parseFloat(FinalDiscount) + parseFloat(discnt1);
                          }



                          NetTotal = (parseFloat(FinalGrossTotal) + parseFloat(FinalTax)) - parseFloat(FinalDiscount);

                          if (document.getElementById("<%=divExchangecurency.ClientID%>").style.display == "") {
                              if (document.getElementById("<%=txtExchangeRate.ClientID%>").value != "") {
                                  var ExchngCrncy = document.getElementById("<%=txtExchangeRate.ClientID%>").value;
                                  ExchngCrncy = ExchngCrncy.replace(/,/g, "");

                                  Defult_Totl = parseFloat(NetTotal) * parseFloat(ExchngCrncy);
                              }
                          }
                          else {
                              Defult_Totl = parseFloat(NetTotal);

                          }

                          if (FloatingValue != "") {
                              FinalGrossTotal = parseFloat(FinalGrossTotal);

                              FinalGrossTotal = FinalGrossTotal.toFixed(FloatingValue);
                              FinalTax = parseFloat(FinalTax);
                              FinalTax = FinalTax.toFixed(FloatingValue);
                              FinalDiscount = parseFloat(FinalDiscount);
                              FinalDiscount = FinalDiscount.toFixed(FloatingValue);
                              NetTotal = parseFloat(NetTotal);
                              NetTotal = NetTotal.toFixed(FloatingValue);
                              Defult_Totl = parseFloat(Defult_Totl);
                              Defult_Totl = Defult_Totl.toFixed(FloatingValue);
                          }


                        
                          addCommas("txtRate" + rowid);
                          addCommas("txtDisAmt" + rowid);
                          addCommas("txtDisPercent" + rowid);
                          addCommas("txtPrice" + rowid);

                      }
                  });

                  if (document.getElementById("<%=divExchangecurency.ClientID%>").style.display == "") {
               if (document.getElementById("<%=txtExchangeRate.ClientID%>").value != "") {
                          var ExnhgRate = "";
                          if (document.getElementById("<%=txtExchangeRate.ClientID%>").value != "") {
                              ExnhgRate = document.getElementById("<%=txtExchangeRate.ClientID%>").value;
                          }
                          ExnhgRate = ExnhgRate.replace(/,/g, "");
                          ExnhgRate = parseFloat(ExnhgRate);
                          ExnhgRate = ExnhgRate.toFixed(FloatingValue);
                          document.getElementById("<%=txtExchangeRate.ClientID%>").value = ExnhgRate;
                          addCommas("cphMain_txtExchangeRate");

                      }
                  }

                
                  VartxtQntity1 = document.getElementById("txtQntity" + rowCount).value;
                  VartxtRatevalue1 = document.getElementById("txtRate" + rowCount).value;

                  if (document.getElementById("ddlProduct_" + rowCount).value != "--Select Item--" && document.getElementById("ddlProduct_" + rowCount).value != "") {



                      if (VartxtQntity1 <= 0) {

                          QuantityChk(rowCount);
                      }
                      else {
                          document.getElementById("txtQntity" + rowCount).style.borderColor = "";
                      }
                      if (VartxtRatevalue1 <= 0) {

                        //  RateChk(rowCount);
                      }
                      else {
                          document.getElementById("txtRate" + rowCount).style.borderColor = "";
                      }


                  }
                  else {
                      document.getElementById("txtQntity" + rowCount).style.borderColor = "";
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


          function ProductDuplication(rowId) {
              var addRowtable = "";
              var ret = true;
              var flag = 0;
              addRowtable = document.getElementById("TableaddedRows");
              var ProductDupCheck = document.getElementById("<%=HiddenProductDupSts.ClientID%>").value;
             
              if (ProductDupCheck == "1") {
                  return true;

              }
              else
              {

                  for (var i = 0; i < addRowtable.rows.length; i++) {
                      var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                      var xLoopLdgrId = $("#ddlProduct_" + xLoop).val();
                      var LedgerId = $("#ddlProduct_" + rowId).val();
                      if (xLoop != rowId) {
                          if (xLoopLdgrId == LedgerId) {
                              $("#divProduct_" + rowId + "> input").css("borderColor", "red");
                              $("#divProduct_" + rowId + "> input").focus();
                              $("#divProduct_" + rowId + "> input").select();


                              ret = false;

                          }
                          else
                          {
                              $("#divProduct_" + rowId + "> input").css("borderColor", "");
                              $("#divProduct_" + xLoop + "> input").css("borderColor", "");


                          }
                      }

                  }
              }
              return ret;
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
                  else
                      document.getElementById('' + textboxid + '').value = x1 + "." + x2;
                
              }
              function ReNumberTable() {
                  var Table = "";
                  Table = $('#TableaddedRows > tbody > tr ');
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
              function CheckaddMoreRows(x) {
             
                  if (LimitTableCheck() == true) {
                    
                      //  document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.6";
                      document.getElementById("SpanAdd" + x).style.pointerEvents = 'none';
                      document.getElementById("SpanAdd" + x).disabled =true;
                      
                      addMoreRows();
                      var y = x + 1;
                      $(".ddlProduct_" + y).focus();
                      return false;
                   
                  }
                  return false;
              }
              function LimitTableCheck() {
             
                  var ret = true;
            
                  $('#TableaddedRows').find('tr').each(function () {
                      var row = $(this);
                      var x = $('td:first-child', row).html();
                      if (x != "") {
                     
                          document.getElementById("ddlProduct_" + x).style.borderColor = "";
                          document.getElementById("txtQntity" + x).style.borderColor = "";
                          $("div#divProduct_" + x).css('border', '');
                          //  document.getElementById("txtPrice" + x).style.borderColor = "";

              
                          var qty = document.getElementById("txtQntity" + x).value;
                          if (qty == "") {
                              document.getElementById("txtQntity" + x).style.borderColor = "Red";
                              document.getElementById("txtQntity" + x).focus();
                              ret = false;
                              //   }


                          }


                          var value = $aa('#ddlProduct_' + x).val();
                          if (value == "" || value == null) {
                              $("div#divProduct_" + x).css('border', '0.5px solid rgb(255, 0, 0)');
                         
                              $("#ddlProduct_" + x).focus();
                              ret = false;;


                          }
                    
                      }
                  });
             
                  return ret;
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
         
          
           

      </script>
            <script>
                function ChangeEnable(field) {
                    ddlDeptHaveValue = $noCon2('#cphMain_ddlDepartment').val();
                    ddlDivisionHaveValue = $noCon2('#cphMain_ddlDivision').val();
                    ddlEmpHaveValue = $noCon2('#cphMain_ddlEmployee').val();
                    ddlDsgnHaveValue = $noCon2('#cphMain_ddlDesignation').val();

                    if (field == 'cphMain_cbxAllDiv') {
                        if (document.getElementById("<%=cbxAllDiv.ClientID%>").checked == true && ddlDivisionHaveValue != null) {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Selected division will be remove and consider as all divisions",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                var newVar = "";

                                document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                                $p('#cphMain_ddlDivision').val(newVar);
                                $p("#cphMain_ddlDivision").trigger("change");
                            }
                            else {
                                document.getElementById("<%=cbxAllDiv.ClientID%>").checked = false;
                            }
                        });
                        return false;

                    }

                    else if (document.getElementById("<%=cbxAllDiv.ClientID%>").checked == true && ddlDivisionHaveValue == null) {
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                    }
                    else if (document.getElementById("<%=cbxAllDiv.ClientID%>").checked == false) {
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = false;
                    }
            return false;
        }
        else if (field == 'cphMain_cbxAllDept') {

            if (document.getElementById("<%=cbxAllDept.ClientID%>").checked == true && (ddlDeptHaveValue != null || ddlDivisionHaveValue != null || ddlEmpHaveValue != null || ddlDsgnHaveValue != null)) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Selected departments will be remove and consider as all departments",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var newVar = "";
                        $p('#cphMain_ddlDepartment').val(newVar);
                        $p("#cphMain_ddlDepartment").trigger("change");
                        $p('#cphMain_ddlEmployee').val(newVar);
                        $p("#cphMain_ddlEmployee").trigger("change");
                        $p('#cphMain_ddlDivision').val(newVar);
                        $p("#cphMain_ddlDivision").trigger("change");
                        $p('#cphMain_ddlDesignation').val(newVar);
                        $p("#cphMain_ddlDesignation").trigger("change");
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                    }
                    else {
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = false;
                    }

                });

                return false;

            }
            else if (document.getElementById("<%=cbxAllDept.ClientID%>").checked == true && (ddlDeptHaveValue == null || ddlDivisionHaveValue == null || ddlEmpHaveValue == null || ddlDsgnHaveValue == null)) {
                document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                    }
                    else if (document.getElementById("<%=cbxAllDept.ClientID%>").checked == false) {
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = false;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = false;
                    }
            return false;

        }
        else if (field == 'cphMain_cbxDsgn') {

            if (document.getElementById("<%=cbxDsgn.ClientID%>").checked == true && (ddlEmpHaveValue != null || ddlDsgnHaveValue != null)) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Selected designations will be remove and consider as all designations",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var newVar = "";
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = true;
                        $p('#cphMain_ddlDepartment').val(newVar);
                        $p("#cphMain_ddlDepartment").trigger("change");
                        $p('#cphMain_ddlEmployee').val(newVar);
                        $p("#cphMain_ddlEmployee").trigger("change");
                        $p('#cphMain_ddlDivision').val(newVar);
                        $p("#cphMain_ddlDivision").trigger("change");
                        $p('#cphMain_ddlDesignation').val(newVar);
                        $p("#cphMain_ddlDesignation").trigger("change");
                    }
                    else {
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = false;
                    }
                });
                return false;

            }
            else if (document.getElementById("<%=cbxDsgn.ClientID%>").checked == true && (ddlEmpHaveValue == null || ddlDsgnHaveValue == null)) {
                document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = true;
                    }
                    else if (document.getElementById("<%=cbxDsgn.ClientID%>").checked == false) {
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = false;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = false;
                    }
            return false;

        }

        else if (field == 'cphMain_cbxAllEmp') {
            if (document.getElementById("<%=cbxAllEmp.ClientID%>").checked == true && (ddlDeptHaveValue != null || ddlDivisionHaveValue != null || ddlEmpHaveValue != null || ddlDsgnHaveValue != null)) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Selected employees will be remove and consider as all employees",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var newVar = "";

                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = true;
                        $p('#cphMain_ddlDepartment').val(newVar);
                        $p("#cphMain_ddlDepartment").trigger("change");
                        $p('#cphMain_ddlEmployee').val(newVar);
                        $p("#cphMain_ddlEmployee").trigger("change");
                        $p('#cphMain_ddlDivision').val(newVar);
                        $p("#cphMain_ddlDivision").trigger("change");
                        $p('#cphMain_ddlDesignation').val(newVar);
                        $p("#cphMain_ddlDesignation").trigger("change");
                    }
                    else {
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = false;
                    }
                });
                return false;
            }
            else if (document.getElementById("<%=cbxAllEmp.ClientID%>").checked == true && (ddlDeptHaveValue == null || ddlDivisionHaveValue == null || ddlEmpHaveValue == null || ddlDsgnHaveValue == null)) {

                document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = true;
                    }
                    else if (document.getElementById("<%=cbxAllEmp.ClientID%>").checked == false) {
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = false;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = false;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = false;

                    }
            return false;
        }

}

        </script>
        <script>


            function AddDeleted(Delrowcount) {
                if (document.getElementById("tdEvt" + Delrowcount).innerHTML == "UPD") {
                    var detailId = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value;
                detailId = detailId + "," + document.getElementById("tdDtlId" + Delrowcount).innerHTML;
                document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = detailId;

                }

            }



            var confirmbox = 0;

            function IncrmntConfrmCounter() {
                confirmbox++;
            }

            function ConfirmMessage() {
                if (document.getElementById("<%=HiddenView.ClientID%>").value == "") {
                    if (confirmbox > 0) {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you sure you want to leave this page?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                window.location.href = "fms_Sales_Master_List.aspx";
                            }
                            else {
                                return false;
                            }
                        });
                        return false;
                    }
                    else {
                        window.location.href = "fms_Sales_Master_List.aspx";
                        return false;
                    }
                }
                else {
                    window.location.href = "fms_Sales_Master_List.aspx";
                    return false;
                }
            }
            function AlertClearAll() {
                if (confirmbox > 0) {
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to clear this page?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            window.location.href = "fms_Sales_Master.aspx";
                        }
                        else {
                            return false;
                        }
                    });
                    return false;
                }
                else {
                    window.location.href = "fms_Sales_Master.aspx";
                    return false;
                }
            }


        </script>
        <script>
            function ChangeTotl() {
                IncrmntConfrmCounter();
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                if (document.getElementById("<%=divExchangecurency.ClientID%>").style.display == "") {
                    if (document.getElementById("<%=txtExchangeRate.ClientID%>").value != "") {
                        var ExnhgRate = "";
                        if (document.getElementById("<%=txtExchangeRate.ClientID%>").value != "") {
                              ExnhgRate = document.getElementById("<%=txtExchangeRate.ClientID%>").value;
                          }
                          ExnhgRate = parseFloat(ExnhgRate);
                          ExnhgRate = ExnhgRate.toFixed(FloatingValue);
                          document.getElementById("<%=txtExchangeRate.ClientID%>").value = ExnhgRate;
                                addCommas("cphMain_txtExchangeRate");

                            }
                        }
                        addRowtable = document.getElementById("TableaddedRows");

                        var RowCount = addRowtable.rows.length;
                // BlurValue(RowCount, null);
                    }

                    function curncyChangeFunt(Id) {

                        if (Id == 0) {
                        }
                        else {
                            IncrmntConfrmCounter();
                        }

                        if (document.getElementById("cphMain_ddlCurrency").value != 0) {

                            var ddlcrncyId = document.getElementById("cphMain_ddlCurrency").value;
                            if (document.getElementById("<%=HiddenDefaultCurncy.ClientID%>").value == document.getElementById("cphMain_ddlCurrency").value || document.getElementById("cphMain_ddlCurrency").value == "--SELECT CURRENCY--") {

                        document.getElementById("cphMain_divExchangecurency").style.display = "none";
                        document.getElementById("cphMain_divTotalDefultCrncy").style.display = "none";
                        // document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = 
                    }
                    else {
                        document.getElementById("cphMain_divExchangecurency").style.display = "block";
                        document.getElementById("cphMain_divTotalDefultCrncy").style.display = "block";

                    }

                    if (document.getElementById("cphMain_ddlCurrency").value != "--SELECT CURRENCY--") {

                        var corpid = '<%= Session["CORPOFFICEID"] %>';
                        var orgid = '<%= Session["ORGID"] %>';
                        var userid = '<%= Session["USERID"] %>';

                        $noCon.ajax({
                            type: "POST",
                            url: "fms_Sales_Master.aspx/RedCurencyAbrvtn",
                            data: '{intCrncyId:"' + ddlcrncyId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" }',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                if (response.d != "0") {
                                    document.getElementById("cphMain_lblCrncyAbrvtn").innerHTML = response.d;
                                    document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = response.d;

                                    CalculateNetTotal(0);
                                    if (document.getElementById("cphMain_divExchangecurency").style.display != "none") {
                                        document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value = response.d;


                                    }
                                    else {
                                    }
                                    addRowtable = document.getElementById("TableaddedRows");

                                    var RowCount = addRowtable.rows.length;
                                }



                                else {

                                }



                            },
                            failure: function (response) {

                            }


                        });

                    }



                }

            }
            function OpenPrint() {

                var StrId = document.getElementById("<%=HiddensaleId.ClientID%>").value;

       var orgID = '<%= Session["ORGID"] %>';
       var corptID = '<%= Session["CORPOFFICEID"] %>';
       var UsrName = '<%= Session["USERFULLNAME"] %>';
       var saleId = StrId;

       if (corptID != "" && corptID != null && orgID != "" && orgID != null && saleId != "") {
           $.ajax({
               type: "POST",
               async: false,
               contentType: "application/json; charset=utf-8",
               url: "fms_Sales_Master.aspx/PrintPDF",
               data: '{saleId: "' + saleId + '",orgID: "' + orgID + '",corptID: "' + corptID + '",UsrName: "' + UsrName + '"}',
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
       </script>
        <script>
            var $noC = jQuery.noConflict();
            function RemoveFileUploadVhcl(removeNum) {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you Sure you want to Delete Selected File?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                        FileLocalStorageDeleteVhcl(Filerow_index, removeNum);
                        jQuery('#FilerowId_' + removeNum).remove();
                        var TableFileRowCount = document.getElementById("TableFileCCN").rows.length;
                        if (TableFileRowCount != 0) {
                            var idlast = $noC('#TableFileCCN tr:last').attr('id');
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



            }




            function FileLocalStorageDeleteVhcl(row_index, x) {
                var $DelFile = jQuery.noConflict();
                var tbClientVehicleFileUpload = localStorage.getItem("tbClientVehicleFileUpload");//Retrieve the stored data

                tbClientVehicleFileUpload = JSON.parse(tbClientVehicleFileUpload); //Converts string to object

                if (tbClientVehicleFileUpload == null) //If there is no data, initialize an empty array
                    tbClientVehicleFileUpload = [];

                tbClientVehicleFileUpload.splice(row_index, 1);

                var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                if (Fevt == 'UPD') {
                    var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                    if (FdetailId != '') {

                        DeleteFileLSTORAGEAddVhcl(x);
                    }

                }
            }

            function DeleteFileLSTORAGEAddVhcl(x) {

                var tbClientVehicleFileUploadCancel = localStorage.getItem("tbClientVehicleFileUploadCancel");//Retrieve the stored data

                tbClientVehicleFileUploadCancel = JSON.parse(tbClientVehicleFileUploadCancel); //Converts string to object

                if (tbClientVehicleFileUploadCancel == null) //If there is no data, initialize an empty array
                    tbClientVehicleFileUploadCancel = [];


                var FileName = document.getElementById("DbFileName" + x).innerHTML;
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;


                var detailId = document.getElementById("<%=hiddenVhclFileCanclDtlId.ClientID%>").value;
                if (detailId == "") {
                    detailId = FdetailId;
                }
                else {
                    detailId = detailId + "," + FdetailId;
                }
                document.getElementById("<%=hiddenVhclFileCanclDtlId.ClientID%>").value = detailId;


                return true;

            }
            function CheckFileUpload() {

                if (document.getElementById("<%=cbxAddAttachment.ClientID%>").checked == true) {
                    document.getElementById("<%=divAttachment.ClientID%>").style.display = "block";
                    //  AddFileUpload();
                }
                else {
                    document.getElementById("<%=divAttachment.ClientID%>").style.display = "none";


                }
            }

            var FileCounterVhcl = 0;
            function AddFileUploadVhcl() {

                var FrecRow = '<tr id="FilerowId_' + FileCounterVhcl + '" >';
                var labelForStyle = '<label for="file' + FileCounterVhcl + '" class="la_up" > <i class="fa fa-upload" aria-hidden="true"></i>Upload File</label>';
                var tdInner = labelForStyle + '<div id="file-upload-filename" class="file_n"><input   id="file' + FileCounterVhcl + '" name = "file' + FileCounterVhcl +
                '" type="file" onchange="ChangeFileVhcl(' + FileCounterVhcl + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/></div>';
                FrecRow += '<td   id="tdidAtchmntDtls' + FileCounterVhcl + '" style="display: none" >' + FileCounterVhcl + '</td>';
                FrecRow += '<td  >' + tdInner + '</td>';
                FrecRow += '<td style="word-break: break-all;" id="filePath' + FileCounterVhcl + '"  ></td  >';
                FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterVhcl + '"  ><a  href="javascript:;" id=\"SpanAddUpload' + FileCounterVhcl + '\"  onclick="return CheckaddMoreRowsIndividualFilesVhcl(' + FileCounterVhcl + ');" class=\"btn act_btn bn2\" title=\"Add\"><i class="fa fa-plus-circle"></i></a> </td>';
                FrecRow += '<td  id="FileIndvldeleteRow' + FileCounterVhcl + '" ><a  href="javascript:;" id=\"SpanDel' + FileCounterVhcl + '\"  onclick = "return RemoveFileUploadVhcl(' + FileCounterVhcl + ');" class=\"btn act_btn bn3\" title=\"Delete\" ><i class="fa fa-trash"></i></a></td></div>';
                FrecRow += ' <td id="FileInx' + FileCounterVhcl + '" style="display: none;" > </td>';
                FrecRow += '<td id="FileSave' + FileCounterVhcl + '" style="display: none;"> </td>';
                FrecRow += '<td id="FileEvt' + FileCounterVhcl + '" style="display: none;">INS</td>';
                FrecRow += '<td id="FileDtlId' + FileCounterVhcl + '" style="display: none;"></td>';
                FrecRow += '<td id="DbFileName' + FileCounterVhcl + '" style="display: none;"></td>';
                FrecRow += '</tr>';

                jQuery('#TableFileCCN').append(FrecRow);

                document.getElementById('filePath' + FileCounterVhcl).innerHTML = 'No File Uploaded';
                FileCounterVhcl++;
            }

            function EditAttachmentVhcl(editTransDtlId, EditFileName, EditActualFileName, RowCount) {
                var FrecRow = '<tr id="FilerowId_' + FileCounterVhcl + '" >';
                var labelForStyle = '<label for="file' + FileCounterVhcl + '" class="custom-file-upload" style="margin-left: 0%;"> <img src="/Images/Icons/cloud_upload.jpg"></img>Upload Document</label>';
                var tdInner = labelForStyle + '<input   id="file' + FileCounterVhcl + '" name = "file' + FileCounterVhcl + '" type="file" onchange="ChangeFileVhcl(' + FileCounterVhcl + ');" value=\"' + EditActualFileName + '\"    accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/>';
                FrecRow += '<td   id="tdidAtchmntDtls' + FileCounterVhcl + '" style="display: none" >' + FileCounterVhcl + '</td>';
                var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';
                FrecRow += '<td style="width: 35%;display: none;"  >' + tdInner + '</td>';
                FrecRow += '<td  colspan="2"  style="word-break: break-all;" id="filePath' + FileCounterVhcl + '"  >' + tdFileNameEdit + '</td  >';
                FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterVhcl + '"  ><a  href="javascript:;" id=\"SpanAddUpload' + FileCounterVhcl + '\"  onclick="return CheckaddMoreRowsIndividualFilesVhcl(' + FileCounterVhcl + ');"  class=\"btn act_btn bn2\" title=\"Add\"><i class="fa fa-plus-circle"></i></a> </td>';
                FrecRow += '<td  id="FileIndvldeleteRow' + FileCounterVhcl + '"  ><a  href="javascript:;" id=\"SpanDel' + FileCounterVhcl + '\"  onclick = "return RemoveFileUploadVhcl(' + FileCounterVhcl + ');"  class=\"btn act_btn bn3\" title=\"Delete\" ><i class="fa fa-trash"></i></a></td>';
                FrecRow += ' <td id="FileInx' + FileCounterVhcl + '" style="display: none;" ></td>';
                FrecRow += '<td id="FileSave' + FileCounterVhcl + '" style="display: none;"> </td>';
                FrecRow += '<td id="FileEvt' + FileCounterVhcl + '" style="display: none;">UPD</td>';
                FrecRow += '<td id="FileDtlId' + FileCounterVhcl + '" style="display: none;">' + editTransDtlId + '</td>';
                FrecRow += '<td id="DbFileName' + FileCounterVhcl + '" style="display: none;">' + EditActualFileName + '</td>';
                FrecRow += '</tr>';

                jQuery('#TableFileCCN').append(FrecRow);
                if (FileCounterVhcl != (parseFloat(RowCount) - 1)) {
                    document.getElementById("FileInx" + FileCounterVhcl).innerHTML = FileCounterVhcl;
                    document.getElementById("FileIndvlAddMoreRow" + FileCounterVhcl).style.opacity = "0.3";
                }
                else {
                    //   AddFileUploadVhcl();
                }
                FileCounterVhcl++;


            }


            function ViewAttachmentVhcl(editTransDtlId, EditFileName, EditActualFileName, RowCount) {
                var FrecRow = '<tr id="FilerowId_' + FileCounterVhcl + '" >';
                var labelForStyle = '<label for="file' + FileCounterVhcl + '" class="custom-file-upload" style="margin-left: 0%;"> <img src="/Images/Icons/cloud_upload.jpg"></img>Upload Document</label>';
                var tdInner = labelForStyle + '<input   id="file' + FileCounterVhcl + '" name = "file' + FileCounterVhcl + '" type="file" onchange="ChangeFileVhcl(' + FileCounterVhcl + ');" value=\"' + EditActualFileName + '\"    accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/>';
                FrecRow += '<td   id="tdidAtchmntDtls' + FileCounterVhcl + '" style="display: none" >' + FileCounterVhcl + '</td>';
                var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';
                FrecRow += '<td style="width: 35%;display: none;"  >' + tdInner + '</td>';
                FrecRow += '<td  colspan="2"  style="word-break: break-all;" id="filePath' + FileCounterVhcl + '"  >' + tdFileNameEdit + '</td  >';
                FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterVhcl + '"><a  href="javascript:;" id=\"SpanAddUpload' + FileCounterVhcl + '\"  onclick="return CheckaddMoreRowsIndividualFilesVhcl(' + FileCounterVhcl + ');" class=\"btn act_btn bn2\" title=\"Add\"><i class="fa fa-plus-circle"></i></a> </td>';
                FrecRow += '<td id="FileIndvldeleteRow' + FileCounterVhcl + '"    ><a  href="javascript:;" id=\"SpanDel' + FileCounterVhcl + '\"   class=\"btn act_btn bn3\" title=\"Delete\" ><i class="fa fa-trash"></i></a></td>';
                FrecRow += ' <td id="FileInx' + FileCounterVhcl + '" style="display: none;" ></td>';
                FrecRow += '<td id="FileSave' + FileCounterVhcl + '" style="display: none;"> </td>';
                FrecRow += '<td id="FileEvt' + FileCounterVhcl + '" style="display: none;">UPD</td>';
                FrecRow += '<td id="FileDtlId' + FileCounterVhcl + '" style="display: none;">' + editTransDtlId + '</td>';
                FrecRow += '<td id="DbFileName' + FileCounterVhcl + '" style="display: none;">' + EditActualFileName + '</td>';
                FrecRow += '</tr>';
                jQuery('#TableFileCCN').append(FrecRow);

                document.getElementById("FileInx" + FileCounterVhcl).innerHTML = FileCounterVhcl;
                document.getElementById("FileIndvlAddMoreRow" + FileCounterVhcl).style.opacity = "0.3";
                document.getElementById("FileIndvldeleteRow" + FileCounterVhcl).style.opacity = "0.3";

                FileCounterVhcl++;

            }

            function CheckaddMoreRowsIndividualFilesVhcl(x) {
                var check = document.getElementById("FileInx" + x).innerHTML.trim();
                if (check == "") {

                    var Fevt = document.getElementById("file" + x).innerHTML;
                    if (CheckFileUploaded(x) == true) {
                        document.getElementById("FileInx" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                        AddFileUploadVhcl();
                        return false;
                    }
                    //}
                }
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
                    if (document.getElementById("FileDtlId" + x).innerHTML != "")
                        fileInx = document.getElementById("FileDtlId" + x).innerHTML;
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
        </script>
        <script>


            var $au = jQuery.noConflict();
            //$au1(function () {
            //    $au1('#cphMain_ddlLedger').selectToAutocomplete1Letter();
            //});
            $au(function () {
                
                $au('#cphMain_ddlCustomerLdgr').selectToAutocomplete1Letter();
          //     $au('.grpLdgr').selectToAutocomplete1Letter();
            });

           


            (function ($au) {
                $au(function () {
                  
                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    prm.add_endRequest(EndRequest);
                    $au('#cphMain_ddlCustomerLdgr').selectToAutocomplete1Letter();
                  
                    $au('form').submit(function () {
                      
                    });
                   
                });

            })(jQuery);
            function EndRequest(sender, args) {
               
                $au('#cphMain_ddlCustomerLdgr').selectToAutocomplete1Letter();
           //   $au('#cphMain_ddlLedger').selectToAutocomplete1Letter();
                $au("div#divddlCustomerLdgr input.ui-autocomplete-input").select();
              //  $au("div#divddlLedger input.ui-autocomplete-input").select();
                
            }

            function OpenProduct(RowNum) {



                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want add new product?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {



                        var nWindow = window.open('/Master/gen_Product_Master/gen_Product_Master.aspx?RFGP=PRDT&NUM=' + RowNum + '', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                        nWindow.focus();

                    }
                    else {
                        return false;
                    }
                });

            }

            function OpenSupplier() {


                if (document.getElementById("<%=HiddenviewSts.ClientID%>").value != "1") {

                    if (document.getElementById("<%=cbxExtngSplr.ClientID%>").checked == true) {

                        ezBSAlert({
                            type: "confirm",
                            messageText: "Do you want add new customer?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {

                                document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
                                document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";
                                document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
                                document.getElementById("<%=HiddenLoadLedgers.ClientID%>").value = ""; 
                                var nWindow = window.open('/Master/gen_Customer_Master/gen_Customer_Master.aspx?RFGP=CUST', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                                nWindow.focus();

                            }
                            else {
                                return false;
                            }
                        });
                    }
                }
            }

                    function GetValueFromChildProject(myVal) {
                        if (myVal != '') {
                            PostbackFunProject(myVal);
                        }
                    }

                    function PostbackFunProject(myValPrj) {
                        document.getElementById("<%=HiddenCustomerId.ClientID%>").value = myValPrj;

                        var corpid = '<%= Session["CORPOFFICEID"] %>';
                        var orgid = '<%= Session["ORGID"] %>';
                        var userid = '<%= Session["USERID"] %>';
                        document.getElementById("<%=btnCustomer.ClientID%>").click();
                        return false;
                    }







                    function GetValueFromChildProjectPrdt(myVal, num) {
                        if (myVal != '' && num != '') {
                            PostbackFunProjectPrdt(myVal, num);
                        }
                    }
                    function PostbackFunProjectPrdt(myValPrj, num) {
                        document.getElementById("<%=HiddenInsPrdtId.ClientID%>").value = myValPrj;
                        document.getElementById("<%=HiddenInsNum.ClientID%>").value = num;

                        var corpid = '<%= Session["CORPOFFICEID"] %>';
                        var orgid = '<%= Session["ORGID"] %>';
                        var userid = '<%= Session["USERID"] %>';

                        $noCon.ajax({
                            type: "POST",
                            url: "fms_Sales_Master.aspx/RedPrdtName",
                            data: '{intProductId:"' + myValPrj + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" }',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {


                                if (response.d != "0") {

                                    $noCon("#ddlProduct_" + num).val(response.d);
                                    $noCon("#txtproductId" + num).val(myValPrj);
                                    $noCon("#txtproductName" + num).val(response.d);
                                    AutoCompleteTextBox("#ddlProduct_", num, 1);
                                    $noCon("#ddlProduct_" + num).select();


                                    document.getElementById('txtQntity' + num).value = 1;
                                    document.getElementById('txtQntity' + num).readOnly = false;
                                    document.getElementById('txtQntity' + num).style.pointerEvents = "painted";
                                    document.getElementById('txtRate' + num).style.pointerEvents = "painted";
                                    document.getElementById('txtRate' + num).readOnly = false;

                                    if (document.getElementById("<%=HiddenDiscountEnableSts.ClientID%>").value == "1") {
                                        document.getElementById('txtDisPercent' + num).disabled = false;
                                        document.getElementById('txtDisAmt' + num).disabled = false;
                                    }
                                    else {
                                        document.getElementById('txtDisPercent' + num).disabled = true;
                                        document.getElementById('txtDisAmt' + num).disabled = true;
                                    }
                                    $(".ddlProduct_" + num).focus();
                                    BlurValue(num, 'txtDisPercent');

                                    ChangeProduct(num, null);
                                    // AutoCompleteTextBox("#ddlProduct_", num, 1);


                                }



                                else {

                                }
                            },
                            failure: function (response) {

                            }
                        });









                        return false;
                    }




            function CheckSupplierType() {

                if (document.getElementById("<%=HiddenviewSts.ClientID%>").value != "1") {

                    //supplier
                    if (document.getElementById("<%=cbxExtngSplr.ClientID%>").checked == true) {

                        document.getElementById("<%=txtsplrName.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAddress1.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAddress2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAddress3.ClientID%>").disabled = true;
                        document.getElementById("<%=txtsplrName.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAddress1.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAddress2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAddress3.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlLedger.ClientID%>").disabled = true;

                        document.getElementById("<%=txtsplrName.ClientID%>").value = "";
                        document.getElementById("<%=txtAddress1.ClientID%>").value = "";
                        document.getElementById("<%=txtAddress2.ClientID%>").value = "";
                        document.getElementById("<%=txtAddress3.ClientID%>").value = "";
                        document.getElementById("<%=txtsplrName.ClientID%>").value = "";
                        document.getElementById("<%=txtAddress1.ClientID%>").value = "";
                        document.getElementById("<%=txtAddress2.ClientID%>").value = "";
                        document.getElementById("<%=txtAddress3.ClientID%>").value = "";
                        //document.getElementById("<%=ddlLedger.ClientID%>").value = "--SELECT LEDGER--";

                        $au('input.grpLdgr').val("--SELECT LEDGER--");
                        $au('input.grpLdgr').attr('disabled', 'disabled');
                        $au('input.grp').attr('disabled', false);
                        if (document.getElementById("<%=HiddenAccountSpecific.ClientID%>").value == "1") {
                            document.getElementById("DivAdddSup").style.display = "block";
                        }
                        else {
                            document.getElementById("DivAdddSup").style.display = "none";
                        }

                        DisplayCredit(0);

                        $("#divddlCustomerLdgr > input").focus();
                        $("#divddlCustomerLdgr> input").select();

                    }
                    else {

                        document.getElementById("<%=txtsplrName.ClientID%>").disabled = false;
                        document.getElementById("<%=txtAddress1.ClientID%>").disabled = false;
                        document.getElementById("<%=txtAddress2.ClientID%>").disabled = false;
                        document.getElementById("<%=txtAddress3.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlLedger.ClientID%>").disabled = false;
                        //document.getElementById("<%=ddlLedger.ClientID%>").style.display = "block";
                        $au('input.grp').attr('disabled', 'disabled');
                        document.getElementById("<%=ddlCustomerLdgr.ClientID%>").value = "--SELECT CUSTOMER--";
                        $au('input.grp').val("--SELECT CUSTOMER--");
                        $au('input.grpLdgr').attr('disabled', false);
                        $("#cphMain_ddlLedger").val(document.getElementById("<%=HiddenDfltLdgr.ClientID%>").value);
                        var PrevsVal = document.getElementById("cphMain_HiddenDfltLdgr").value;
                        var sel = $("#cphMain_ddlLedger option[value='" + PrevsVal + "']").text();
                        $('#cphMain_ddlLedger').val(PrevsVal);
                        $("#divddlLedger > input").val(sel);
                        document.getElementById("<%=txtsplrName.ClientID%>").focus();
                    }
                }
                else {
                    document.getElementById("<%=txtsplrName.ClientID%>").disabled = true;
                    document.getElementById("<%=txtAddress1.ClientID%>").disabled = true;
                    document.getElementById("<%=txtAddress2.ClientID%>").disabled = true;
                    document.getElementById("<%=txtAddress3.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlLedger.ClientID%>").disabled = true;
                    $au('input.grp').attr('disabled', 'disabled');
                    $au('input.grpLdgr').attr('disabled', 'disabled');
                }

            }

            function DisplayCredit(mode) {

                var ret = true;

                var OrgId = '<%=Session["ORGID"] %>';
                var CorpId = '<%=Session["CORPOFFICEID"] %>';

                if (document.getElementById("<%=ddlCustomerLdgr.ClientID%>").value != "--SELECT CUSTOMER--") {

                    var CustomerId = document.getElementById("<%=ddlCustomerLdgr.ClientID%>").value;
                    var NetTotal = document.getElementById("<%=HiddenNetAmt.ClientID%>").value;
                    var Date = document.getElementById("<%=txtDateFrom.ClientID%>").value;
                    var SaleId = document.getElementById("<%=HiddensaleId.ClientID%>").value;

                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "fms_Sales_Master.aspx/DisplayCreditDtls",
                        data: '{CustomerId: "' + CustomerId + '",NetAmnt: "' + NetTotal + '",Date: "' + Date + '",SaleId: "' + SaleId + '"}',
                        dataType: "json",
                        success: function (data) {

                            if (data.d[0] != "") {

                                if (mode == "0") {
                                    if (data.d[0] == "both") {
                                        $noCon("#divWarning").html("Credit limit and period exceeded for the customer");
                                        $noCon("#divWarning").fadeTo(5000, 500).slideUp(500, function () {
                                        });
                                    }
                                    else if (data.d[0] == "limit") {
                                        $noCon("#divWarning").html("Credit limit exceeded for the customer");
                                        $noCon("#divWarning").fadeTo(5000, 500).slideUp(500, function () {
                                        });
                                    }
                                    else if (data.d[0] == "period") {
                                        $noCon("#divWarning").html("Credit period exceeded for the customer");
                                        $noCon("#divWarning").fadeTo(5000, 500).slideUp(500, function () {
                                        });
                                    }
                                }
                                else if (mode == "1") {

                                    if (data.d[1] == "restrict") {

                                        if (data.d[0] == "both") {
                                            $noCon("#divWarning").html("Credit limit and period exceeded for the customer");
                                            $noCon("#divWarning").fadeTo(5000, 500).slideUp(500, function () {
                                            });
                                            ret = false;
                                        }
                                        else if (data.d[0] == "limit") {
                                            $noCon("#divWarning").html("Credit limit exceeded for the customer");
                                            $noCon("#divWarning").fadeTo(5000, 500).slideUp(500, function () {
                                            });
                                            ret = false;
                                        }
                                        else if (data.d[0] == "period") {
                                            $noCon("#divWarning").html("Credit period exceeded for the customer");
                                            $noCon("#divWarning").fadeTo(5000, 500).slideUp(500, function () {
                                            });
                                            ret = false;
                                        }
                                    }

                                }
                            }

                            ///////////////////////Status bar/////////////////////////////

                            if (data.d[4] != "0" || data.d[5] != "0") {

                                document.getElementById("divCreditDtls").style.display = "block";

                                if (data.d[4] != "") {

                                    document.getElementById("divCreditLimit").style.display = "block";
                                    document.getElementById("spanLimit").innerHTML = "Credit Limit<br>" + data.d[4] + "";

                                    if (data.d[2] != "") {
                                        if (parseInt(data.d[2]) >= 0) {
                                            moveProgressBarLimit(data.d[2]);
                                        }
                                        else {
                                            moveProgressBarLimit("100");
                                        }
                                    }
                                    else {
                                        moveProgressBarLimit("0");
                                    }
                                }
                                else {
                                    document.getElementById("divCreditLimit").style.display = "none";
                                }

                                if (data.d[5] != "") {

                                    document.getElementById("divCreditPeriod").style.display = "block";
                                    document.getElementById("spanPeriod").innerHTML = "Credit Period<br>" + data.d[5] + " days";


                                    if (data.d[3] != "") {
                                        if (parseInt(data.d[3]) >= 0) {
                                            moveProgressBarPeriod(data.d[3]);
                                        }
                                        else {
                                            moveProgressBarPeriod("100");
                                        }
                                    }
                                    else {
                                        moveProgressBarPeriod("0");
                                    }
                                }
                                else {

                                    document.getElementById("divCreditPeriod").style.display = "none";






                                }

                            }
                            else {
                                document.getElementById("divCreditDtls").style.display = "none";
                            }


                        },
                        failure: function (data) {
                            alert("error");
                        }
                    });
                }
                return ret;
            }


            function DisplayCreditData(mode) {

                var ret = true;

                var OrgId = '<%=Session["ORGID"] %>';
                var CorpId = '<%=Session["CORPOFFICEID"] %>';

                if (document.getElementById("<%=ddlCustomerLdgr.ClientID%>").value != "--SELECT CUSTOMER--") {

                    var CustomerId = document.getElementById("<%=ddlCustomerLdgr.ClientID%>").value;
                    var NetTotal = document.getElementById("<%=HiddenNetAmt.ClientID%>").value;
                    var Date = document.getElementById("<%=txtDateFrom.ClientID%>").value;
                    var SaleId = document.getElementById("<%=HiddensaleId.ClientID%>").value;

                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "fms_Sales_Master.aspx/DisplayCreditDtls",
                        data: '{CustomerId: "' + CustomerId + '",NetAmnt: "' + NetTotal + '",Date: "' + Date + '",SaleId: "' + SaleId + '"}',
                        dataType: "json",
                        success: function (data) {

                            if (data.d[0] != "") {

                                if (mode == "0") {
                                    if (data.d[0] == "both") {
                                        $noCon("#divWarning").html("Credit limit and period exceeded for the customer");
                                        $noCon("#divWarning").fadeTo(5000, 500).slideUp(500, function () {
                                        });
                                    }
                                    else if (data.d[0] == "limit") {
                                        $noCon("#divWarning").html("Credit limit exceeded for the customer");
                                        $noCon("#divWarning").fadeTo(5000, 500).slideUp(500, function () {
                                        });
                                    }
                                    else if (data.d[0] == "period") {
                                        $noCon("#divWarning").html("Credit period exceeded for the customer");
                                        $noCon("#divWarning").fadeTo(5000, 500).slideUp(500, function () {
                                        });
                                    }
                                }
                                else if (mode == "1") {

                                    if (data.d[1] == "restrict") {

                                        if (data.d[0] == "both") {
                                            $noCon("#divWarning").html("Credit limit and period exceeded for the customer");
                                            $noCon("#divWarning").fadeTo(5000, 500).slideUp(500, function () {
                                            });
                                            ret = false;
                                        }
                                        else if (data.d[0] == "limit") {
                                            $noCon("#divWarning").html("Credit limit exceeded for the customer");
                                            $noCon("#divWarning").fadeTo(5000, 500).slideUp(500, function () {
                                            });
                                            ret = false;
                                        }
                                        else if (data.d[0] == "period") {
                                            $noCon("#divWarning").html("Credit period exceeded for the customer");
                                            $noCon("#divWarning").fadeTo(5000, 500).slideUp(500, function () {
                                            });
                                            ret = false;
                                        }
                                    }

                                }
                            }

                            ///////////////////////Status bar/////////////////////////////

                            if (data.d[4] != "0" || data.d[5] != "0") {

                                document.getElementById("divCreditDtls").style.display = "block";

                                if (data.d[4] != "") {

                                    document.getElementById("divCreditLimit").style.display = "block";
                                    document.getElementById("spanLimit").innerHTML = "Credit Limit<br>" + data.d[4] + "";

                                    if (data.d[2] != "") {
                                        if (parseInt(data.d[2]) >= 0) {
                                            moveProgressBarLimit(data.d[2]);
                                        }
                                        else {
                                            moveProgressBarLimit("100");
                                        }
                                    }
                                    else {
                                        moveProgressBarLimit("0");
                                    }
                                }
                                else {
                                    document.getElementById("divCreditLimit").style.display = "none";
                                }

                                if (data.d[5] != "") {

                                    document.getElementById("divCreditPeriod").style.display = "block";
                                    document.getElementById("spanPeriod").innerHTML = "Credit Period<br>" + data.d[5] + " days";
                                    document.getElementById("<%=txtcrdtPeriod.ClientID%>").value = data.d[5];//EVM 0044

                                    if (data.d[3] != "") {
                                        if (parseInt(data.d[3]) >= 0) {
                                            moveProgressBarPeriod(data.d[3]);
                                        }
                                        else {
                                            moveProgressBarPeriod("100");
                                        }
                                    }
                                    else {
                                        moveProgressBarPeriod("0");
                                    }
                                }
                                else {

                                    document.getElementById("divCreditPeriod").style.display = "none";
                                    document.getElementById("<%=txtcrdtPeriod.ClientID%>").value = "";//EVM 0044





                                }

                            }
                            else {

                                document.getElementById("divCreditDtls").style.display = "none";

                            }


                        },
                        failure: function (data) {
                            alert("error");
                        }
                    });
                }
                return ret;
            }
            



                </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenRowNo" runat="server" />
    <asp:HiddenField ID="HiddenAdd" runat="server" />
    <asp:HiddenField ID="Hiddendiscount" runat="server" />
    <asp:HiddenField ID="HiddenGrossAmt" runat="server" />
    <asp:HiddenField ID="Hiddenreturnfun" runat="server" />
    <asp:HiddenField ID="HiddenInventoryForex" runat="server" />
    <asp:HiddenField ID="HiddenNetAmt" runat="server" />
    <asp:HiddenField ID="HiddenTax" runat="server" />
    <asp:HiddenField ID="HiddenCurrncyId" runat="server" />
    <asp:HiddenField ID="hiddenCostCenterddl" runat="server" />
    <asp:HiddenField ID="HiddenCostGroup1ddl" runat="server" />
    <asp:HiddenField ID="HiddenCostGroup2ddl" runat="server" />
    <asp:HiddenField ID="Hiddencustldgr" runat="server" />
    <asp:HiddenField ID="HiddenDefultCrncAbrvtn" runat="server" />
    <asp:HiddenField ID="HiddenAcntClsSts" runat="server" />
    <asp:HiddenField ID="HiddenConfirmStatus" runat="server" />
    <asp:HiddenField ID="HiddenReopen" runat="server" />
    <asp:HiddenField ID="HiddenAcntClsDate" runat="server" />
    <asp:HiddenField ID="HiddenFieldAuditCloseReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenCustomerId" runat="server" />
    <asp:HiddenField ID="HiddenInsPrdtId" runat="server" />
    <asp:HiddenField ID="HiddenInsNum" runat="server" />
    <asp:HiddenField ID="HiddenUpdateSts" runat="server" />
    <asp:HiddenField ID="HiddenReopenPrvsn" runat="server" />
    <asp:HiddenField ID="HiddenField4_FileUpload" runat="server" />
    <asp:HiddenField ID="HiddenAccountSpecific" runat="server" />
    <asp:HiddenField ID="HiddenDefltPrdtLedId" runat="server" />
    <asp:HiddenField ID="HiddenCurrency" runat="server" />
    <asp:HiddenField ID="HiddenUnit" runat="server" />
    <asp:HiddenField ID="HiddenRownum" runat="server" />
    <asp:HiddenField ID="HiddenRet" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="custmrldgr" runat="server" />
    <asp:HiddenField ID="hiddenQstnCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenEdit" runat="server" />
    <asp:HiddenField ID="HiddenView" runat="server" />
    <asp:HiddenField ID="HiddenviewSts" runat="server" />
    <asp:HiddenField ID="HiddensaleId" runat="server" />
    <asp:HiddenField ID="HiddenDefaultCurncy" runat="server" />
    <asp:HiddenField ID="HiddenExchngCurrency" runat="server" />
    <asp:HiddenField ID="HiddenFocusId" runat="server" />
    <asp:HiddenField ID="HiddenFocusName" runat="server" />
    <asp:HiddenField ID="HiddenTaxEnable" runat="server" />
    <asp:HiddenField ID="HiddenCurrcyFxAbbrvn" runat="server" />
    <asp:HiddenField ID="HiddenExRateSts" runat="server" />
    <asp:HiddenField ID="HiddenDiscountEnableSts" runat="server" />
    <asp:HiddenField ID="HiddenDfltLdgr" runat="server" />
    <asp:HiddenField ID="HiddenDefaultLdgrSts" runat="server" />
    <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="HiddenProvisionSts" runat="server" />
    <asp:HiddenField ID="HiddenStartDate" runat="server" />
    <asp:HiddenField ID="HiddenUpdatedDate" runat="server" />
    <asp:HiddenField ID="HiddenUpdRefNum" runat="server" />
    <asp:HiddenField ID="HiddenRefNum" runat="server" />
    <asp:HiddenField ID="HiddenRefAccountCls" runat="server" />
    <asp:HiddenField ID="hiddenFilePath" runat="server" />
    <asp:HiddenField ID="hiddenEditPrmtAttchmnt" runat="server" />
    <asp:HiddenField ID="hiddenVhclFileCanclDtlId" runat="server" />
    <asp:HiddenField ID="Hiddenref_NextNumber" runat="server" />
    <asp:HiddenField ID="HiddenProductDupSts" runat="server" />
    <asp:HiddenField ID="HiddenLoadLedgers" runat="server" />
    <asp:HiddenField ID="HiddenLimitRestrict" runat="server" />
    <asp:HiddenField ID="HiddenLimitWarn" runat="server" />
    <asp:HiddenField ID="HiddenPeriodRestrict" runat="server" />
    <asp:HiddenField ID="HiddenPeriodWarn" runat="server" />
    <asp:HiddenField ID="HiddenRefEnableSts" runat="server" />

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="fms_Sales_Master_List.aspx">Sales</a></li>
        <li class="active">Add Sales</li>
    </ol>
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
                    <asp:Label ID="lblEntry" runat="server"></asp:Label></h2>

                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Sale REF #:<span class="spn1">*</span></label>
                    <div id="divtxtRef" runat="server">
                        <%--<asp:TextBox ID="txtRef" class="form-control fg2_inp1"  runat="server" TabIndex="-1" MaxLength="100" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtRef,190)" onkeydown=" return textCounter(cphMain_txtRef,150)"></asp:TextBox>--%>
                          <asp:TextBox ID="txtRef" class="form-control fg2_inp1"  runat="server" autocomplete="off"  TabIndex="-1" MaxLength="100" onchange="IncrmntConfrmCounter();" onkeypress="return  isTagDes(event);" onblur="ReplaceTag('cphMain_txtOrder',event);" onkeydown=" return textCounter(cphMain_txtOrder,100)"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group fg5 fg2_mr">
                    <div class="tdte">
                        <label for="pwd" class="fg2_la1">Date:<span class="spn1">*</span> </label>
                        <div id="datepicker2" class="input-group date" data-date-format="mm-dd-yyyy">
                            <input id="txtDateFrom" runat="server" class="form-control inp_bdr inp_mst" autocomplete="off" readonly="true" name="txtDate" type="text" onkeypress="return DisableEnter(event)" onchange="showFromDate()" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                            <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                        </div>
                    </div>
                    <script>
                        var $noCon4 = jQuery.noConflict();
                        var dateToday = new Date();


                        var curentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value
                        var StartDate = document.getElementById("<%=HiddenStartDate.ClientID%>").value
                        $noCon4('#cphMain_txtDateFrom').datepicker({
                            autoclose: true,
                            // startDate: new Date(),
                            format: 'dd-mm-yyyy',
                            startDate: StartDate,
                            endDate: curentDate,

                        });
                        function showFromDate() {
                            document.getElementById("cphMain_txtDateFrom").style.borderColor = "";
                            IncrmntConfrmCounter();
                            var orgID = '<%= Session["ORGID"] %>';
                            var corptID = '<%= Session["CORPOFFICEID"] %>';
                            var jrnlDate = $('#cphMain_txtDateFrom').val().trim();
                            var usrID = '<%= Session["USERID"] %>';
                            var RcptDate = $('#cphMain_HiddenUpdatedDate').val().trim();
                            var RefNum = $('#cphMain_HiddenUpdRefNum').val().trim();
                            var saleId = $('#cphMain_HiddensaleId').val().trim();
                            var AcntPrvsn = document.getElementById("<%=HiddenProvisionSts.ClientID%>").value
                            var AuditPrvsn = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;
                            if (jrnlDate != "") {

                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    contentType: "application/json; charset=utf-8",
                                    url: "fms_Sales_Master.aspx/CheckAcntCloseSts",
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
                            if (jrnlDate != "" && (document.getElementById("<%=HiddenProvisionSts.ClientID%>").value == "1" || document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value == "1")) {
                                if (document.getElementById("<%=HiddenRefEnableSts.ClientID%>").value == "0") {
                                    if (document.getElementById("<%=HiddenRefAccountCls.ClientID%>").value == "1") {
                                        $.ajax({
                                            type: "POST",
                                            async: false,
                                            contentType: "application/json; charset=utf-8",
                                            url: "fms_Sales_Master.aspx/CheckRefNumber",
                                            data: '{jrnlDate: "' + jrnlDate + '",orgID: "' + orgID + '",corptID: "' + corptID + '",usrID: "' + usrID + '",RefNum: "' + RefNum + '",saleId: "' + saleId + '"}',
                                            dataType: "json",
                                            success: function (data) {

                                                if (data.d != "") {

                                                    if (document.getElementById("<%=HiddenRefNum.ClientID%>").value != data.d && RcptDate != "") {

                                                        if (document.getElementById("cphMain_txtRef").value != data.d) {
                                                            ezBSAlert({
                                                                type: "confirm",
                                                                messageText: "This action will change the reference number.Are you sure you want to continue ?",
                                                                alertType: "info"
                                                            }).done(function (e) {
                                                                if (e == true) {
                                                                    document.getElementById("cphMain_txtRef").value = data.d;
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
                                                            document.getElementById("cphMain_txtRef").value = data.d;
                                                        }
                                                    }
                                                    else {
                                                        document.getElementById("cphMain_txtRef").value = data.d;
                                                        document.getElementById("cphMain_HiddenRefNum").value = data.d;
                                                    }
                                                }
                                            }
                                        });
                                    }

                                }
                            }

                            DisplayCredit(0);
                        }
                    </script>
                </div>
                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Order#:<span class="spn1"></span></label>
                    <asp:TextBox ID="txtOrder" autocomplete="off" class="form-control fg2_inp1" runat="server" MaxLength="100" onkeypress="return  isTagDes(event);" onblur="ReplaceTag('cphMain_txtOrder',event);" onkeydown=" return textCounter(cphMain_txtOrder,100)"></asp:TextBox>
                </div>
                <div class="form-group fg5">
                    <label for="email" class="fg2_la1 pad_l">Status: <span class="spn1">&nbsp;</span></label>
                    <div class="check1">
                        <div class="">
                            <label class="switch">
                                <input type="checkbox" runat="server" checked="checked" onchange="FunctStsChkBx();" onkeypress="return DisableEnter(event)" id="checkSts" />
                                <span class="slider_tog round"></span>
                            </label>
                        </div>
                    </div>
                </div>
             <div class="form-group fg5 fg2_mr">
                <label class="form1 mar_bo">
                  <p class="pz_s"> Existing Customer:</p><span class="spn1 flt_l">*</span>
                  <span class=" mar_rgt1 flt_l">
                    <label class="switch">
                    <input type="checkbox" runat="server" checked="checked" onclick="CheckSupplierType();" onkeydown="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" id="cbxExtngSplr" />
                     <span class="slider_tog round"></span>
                    </label>
                  </span>
                </label>

                <div id="divCreditDtls" class="crt_ara mar_rgt1" style="display:none;">

                  <div id="divCreditLimit" class="prog_1 tooltip1" style="display:none;"> 
                    <div class="progress-wrap progress1">
                      <div id="divLimitPrcnt" class="progress-bar progress1"></div>
                    </div>
                   <span id="spanLimit" class="tooltiptext1">Credit Limit<br>0</span>
                  </div>

                 <div id="divCreditPeriod" class="prog_1 tooltip2" style="display:none;"> 
                  <div class="progress-wrap progress1">
                    <div id="divPeriodPrcnt" class="progress-bar progress1"></div>
                  </div>
                  <span id="spanPeriod" class="tooltiptext2">Credit Period<br>0 Days</span>
                </div>

                </div>

                    <div id="divddlCustomerLdgr">
                        <asp:DropDownList ID="ddlCustomerLdgr" class="form-control fg2_inp1 inp_mst custom-select grp" runat="server" onkeydown="return DisableEnter(event);" onkeypress="return  DisableEnter(event);" onchange="return DisplayCreditData(0);"></asp:DropDownList>
                    </div>
                    <a href="javascript:;" id="DivAdddSup" onclick="OpenSupplier();" title="Add"><span class="input-group-addon cur6"><i class="fa fa-plus"></i></span></a>
                </div>
                       <div class="clearfix"></div>
                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Customer:<span class="spn1">*</span></label>
                    <asp:TextBox ID="txtsplrName" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 inp_mst" runat="server" onchange="IncrmntConfrmCounter();" onkeypress="return isTagDes(event);" onblur="ReplaceTag('cphMain_txtsplrName',event);"></asp:TextBox>
                </div>

                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Address 1:<span class="spn1">*</span></label>
                    <asp:TextBox ID="txtAddress1" autocomplete="off" class="form-control fg2_inp1  inp_mst" runat="server" MaxLength="499" onchange="IncrmntConfrmCounter();" onkeypress="return isTagDes(event);" onblur="ReplaceTag('cphMain_txtAddress1',event);"></asp:TextBox>
                </div>
                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Address 2:<span class="spn1">&nbsp;</span></label>
                    <asp:TextBox ID="txtAddress2" autocomplete="off" class="form-control fg2_inp1" runat="server" MaxLength="499" onchange="IncrmntConfrmCounter();" onkeypress="return isTagDes(event);" onblur="ReplaceTag('cphMain_txtAddress2',event);"></asp:TextBox>
                </div>

                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Address 3:<span class="spn1">&nbsp;</span></label>
                    <asp:TextBox ID="txtAddress3" autocomplete="off" class="form-control fg2_inp1" runat="server" MaxLength="499" onchange="IncrmntConfrmCounter();" onkeypress="return isTagDes(event);" onblur="ReplaceTag('cphMain_txtAddress3',event);"></asp:TextBox>

                </div>

                <div class="form-group fg5" style="display:block;">
                    <label for="email" class="fg2_la1">Ledger<span class="spn1"></span>:</label>
                    <div id ="divddlLedger">
                    <asp:DropDownList ID="ddlLedger" class="form-control fg2_inp1 fg_chs2 custom-select grpLdgr ddl" runat="server" onkeypress="return DisableEnter(event);"></asp:DropDownList>
                    </div>
                </div>


                     <div class="clearfix"></div>
                <div class="form-group fg5" id="DivCurrency">
                    <label for="email" class="fg2_la1">Currency<span class="spn1"></span>:</label>
                    <asp:DropDownList ID="ddlCurrency" onchange="return curncyChangeFunt(1);" class="form-control fg2_inp1 fg_chs2 custom-select" runat="server" onkeypress="return DisableEnter(event);"></asp:DropDownList>
                </div>

                <div class="form-group fg5 fg2_mr" runat="server" id="divExchangecurency">
                    <label class="form1 mar_bo">
                        <span class="">
                            <input type="checkbox" class="hidden" />
                        </span>
                        Exchange Rate:
                    </label>
                    <div class="input-group">
                        <asp:TextBox ID="txtExchangeRate" autocomplete="off" class="form-control inp_bdr inp_mst tr_r" runat="server" MaxLength="20" onchange="return curncyChangeFunt(1);" onkeypress="return isNumberAmount(event);" onblur="return  isTagDes(event);" onkeydown=" return textCounter(cphMain_txtOrder,150)"></asp:TextBox>
                        <span class="input-group-addon date1">
                            <asp:Label ID="lblCrncyAbrvtn" runat="server"></asp:Label></span>
                    </div>
                </div>
               
           <div class="form-group fg5 fg2_mr">
              <label for="email" class="fg2_la1">Credit Period:<span class="spn1"></span></label>
              <asp:TextBox ID="txtcrdtPeriod"  class="form-control fg2_inp1" runat="server" MaxLength="20" onkeydown="return isNumber(event);"></asp:TextBox>
             </div>

                  <%--  43--%>
             <div class="form-group fg5 fg2_mr">
              <label for="email" class="fg2_la1">Guest/Party Name:<span class="spn1"></span></label>
              <asp:TextBox ID="txtGuestName"  autocomplete="off" class="form-control fg2_inp1" runat="server" MaxLength="20" onkeypress="return  isTagDes(event);" onkeydown=" return textCounter(cphMain_txtGuestName,20)" ></asp:TextBox>
             </div>
                    <%-- end--%>


            <div class="sub_add" style="display:block;" id="sale_add" runat="server">

                          <%--<div class="form-group fg5 fg2_mr">
                    <div class="tdte">  
                        <label for="pwd" class="fg2_la1">Date:<span class="spn1">*</span> </label>
                        <div id="Div6" class="input-group date" data-date-format="mm-dd-yyyy">
                            <input id="Text1" runat="server" class="form-control inp_bdr inp_mst" autocomplete="off" readonly="true" name="txtDate" type="text" onkeypress="return DisableEnter(event)" onchange="showFromDate()" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                            
                              <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                        </div>
                        </div>
                              </div>           

                        
               <%-- <div class="form-group fg5 fg2_mr">
                  
                    </div>
                  <label for="email" class="fg2_la1">Guest Name:<span class="spn1"></span></label>
                  <input type="text" class="form-control fg2_inp1" id="email" placeholder="Guest Name" name="email" required=""/>
                              <asp:TextBox ID=Text  class='form-control fg2_inp1' runat='server' MaxLength="20" onkeydown="return isNumber(event);"></asp:TextBox>
                </div>
                <div class="form-group fg5 fg2_mr">
                  <label for="email" class="fg2_la1">Guest Name:<span class="spn1"></span></label>
                  <input type="text" class="form-control fg2_inp1" id="Text1" placeholder="Guest Name" name="email" required=""/>
                </div>
                <div class="form-group fg5 fg2_mr">
                  <label for="email" class="fg2_la1">Guest Name:<span class="spn1"></span></label>
                  <input type="text" class="form-control fg2_inp1" id="Text2" placeholder="Guest Name" name="email" required=""/>
                </div>
                <div class="form-group fg5 fg2_mr">
                  <label for="email" class="fg2_la1">Guest Name:<span class="spn1"></span></label>
                  <input type="text" class="form-control fg2_inp1" id="Text3" placeholder="Guest Name" name="email" required=""/>
                </div>
                <div class="form-group fg5 fg2_mr">
                  <label for="email" class="fg2_la1">Guest Name:<span class="spn1"></span></label>
                  <input type="text" class="form-control fg2_inp1" id="Text4" placeholder="Guest Name" name="email" required=""/>
                </div>
                <div class="form-group fg5 fg2_mr">
                  <label for="email" class="fg2_la1">Guest Name:<span class="spn1"></span></label>
                  <input type="text" class="form-control fg2_inp1" id="Text5" placeholder="Guest Name" name="email" required=""/>
                </div>
                <div class="form-group fg5 fg2_mr">
                  <label for="email" class="fg2_la1">Guest Name:<span class="spn1"></span></label>
                  <input type="text" class="form-control fg2_inp1" id="Text6" placeholder="Guest Name" name="email" required=""/>
                </div>

                    <%-- end--%>
              
              </div>




                <div class="clearfix"></div>
                <div class="devider divid"></div>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Products:<span class="spn1">*</span></label>
                </div>
                <div id="divEmployeeTable" runat="server">
                    <table id="tableMain" class="table table-bordered">
                        <thead class="thead1">
                            <tr>
                                <th class="th_b5">SL#</th>
                                <th class="th_b4 tr_l">PRODUCT Name</th>
                                <th class="th_b5 tr_c">QTY</th>
                                <th class="th_b1 tr_r">PRICE</th>
                                <th class="th_b4">DISCOUNT</th>
                                <th id="tdHdTax" class="th_b11">TAX</th>
                                <th class="th_b7 tr_r">TOTAL AMOUNT</th>
                                <th class="th_b6">ACTIONS</th>
                                <th class="th_b5 tr_c">CC</th>
                            </tr>
                        </thead>
                        <tbody id="TableaddedRows">
                        </tbody>
                    </table>
                </div>
                <div class="text_area_container">
                    <div class="col-md-6 flt_l">
                        <div class="form-group">
                            <label for="email" class="fg2_la1">Description: <span class="spn1">&nbsp;</span></label>

                            <textarea rows="4" cols="50" class="form-control" onchange="IncrmntConfrmCounter();" runat="server" style="resize: none;" id="txtDesc" onkeydown="textCounter(cphMain_txtDesc,500)" onkeyup="textCounter(cphMain_txtDesc,500)"></textarea>
                        </div>
                    </div>
                    <div class="col-md-6 txt_alg  flt_l">
                        <div class="col-md-6 flt_l">
                            <label for="email" class="fg2_la1 tt_am">Gross Amount: <span class="spn1">&nbsp;</span></label>
                        </div>
                        <div class="col-md-6 flt_l" id="div1" runat="server">
                            <span id="txtGrsTotal" class="tt_am tt_al" runat="server" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtGrsTotal,190)" onkeydown=" return textCounter(cphMain_txtGrsTotal,150)"></span>
                        </div>
                    </div>
                    <div class="col-md-6 txt_alg flt_l" id="DiTaxTot">
                        <div class="col-md-6 flt_l">
                            <label for="email" class="fg2_la1 tt_am am2">Tax Amount:<span class="spn1">&nbsp;</span></label>
                        </div>
                        <div class="col-md-6 flt_l" id="div2" runat="server">
                            <span id="txtTotalTaxAmt" class="tt_am tt_al" runat="server" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtTotalTaxAmt,190)" onkeydown=" return textCounter(cphMain_txtTotalTaxAmt,150)"></span>
                        </div>
                    </div>

                    <div class="col-md-6 txt_alg  flt_l">
                        <div class="col-md-6 flt_l">
                            <label for="email" class="fg2_la1 tt_am am3">Total Discount:<span class="spn1">&nbsp;</span></label>
                        </div>
                        <div class="col-md-6 flt_l" id="div3" runat="server">
                            <asp:TextBox ID="txtDiscount" class="form-control fg2_inp2 tr_r mar_bo_d" runat="server" MaxLength="100" autocomplete="off" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" onblur="CalculateNetTotal(1);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6 txt_alg  flt_l">
                        <hr class="hr_amt">
                        <div class="col-md-6 flt_l">
                            <label for="email" class="fg2_la1 tt_am am1 txt_l">Net Amount<span class="spn1"></span>:</label>
                        </div>
                        <div class="col-md-6 flt_l" id="div4" runat="server">
                            <asp:TextBox ID="txtNetTotal" class="fg2_inp2 tr_r" runat="server" Style="border: none; background: none;" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtNetTotal,190)" onkeydown=" return textCounter(cphMain_txtNetTotal,150)"></asp:TextBox>
                        </div>
                    </div>

                    <div id="divTotalDefultCrncy" runat="server" style="display: none" class="col-md-6 txt_alg  flt_l">
                        <div class="col-md-6 flt_l" id="div5" runat="server">
                            <asp:Label ID="lblExchnangAmt" runat="server" class="fg2_la1 tt_am am1 txt_l"></asp:Label>
                        </div>

                        <div class="col-md-6 flt_l">
                            <asp:TextBox ID="txtDefultCrncyTotl" class="tt_am tt_al" runat="server" MaxLength="100" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtDefultCrncyTotl,190)" onkeydown=" return textCounter(cphMain_txtDefultCrncyTotl,150)" Style="display: none;"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-md-8">
                    <label for="example-text-input" class="fg2_la1 pad_l">Add Attachment<span></span></label>
                    <div class="check1 mar_btm1">
                        <div class="">
                            <label class="switch">
                                <input type="checkbox" runat="server" class="bu1" checked="checked" onclick="CheckFileUpload();" onkeydown="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" id="cbxAddAttachment" />
                                <span class="slider_tog round"></span>
                            </label>
                        </div>
                    </div>
                    <div id="divAttachment" runat="server">

                        <div id="divFileCCN" class="col-md-12">
                            <table id="TableFileCCN" width="100%">
                            </table>
                        </div>
                    </div>
                </div>
                         </div>
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
                 <a id="btnFloat" runat="server" onmouseover="opensave()" type="button" class="save_b" title="Save" >
                    <i class="fa fa-save"></i>
                </a>
                <div class="clearfix"></div>
                <div class="free_sp"></div>
                <div class="devider divid"></div>
                              <div class="mySave1" id="mySave" runat="server">
                    <div class="save_sec">
                        <asp:Button ID="btnFloatPrdt" runat="server" class="btn btn-primary" Style="display: none" Text="Reopen" />
                        <asp:Button ID="btnFloatCustomer" runat="server" class="btn btn-primary" Style="display: none" Text="Reopen" OnClick="btnCustomer_Click" />
                        <asp:Button ID="btnFloatUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return SalesValidate();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnFloatUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return SalesValidate();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnFloatConfirm1" runat="server" class="btn sub2" Text="Confirm" OnClick="btnUpdate_Click" Style="display: none" />
                        <asp:Button ID="btnFloatReopen1" runat="server" Style="display: none" class="btn sub2" Text="Reopen" OnClick="btnReopen1_Click" />
                        <asp:Button ID="btnFloatReopen" runat="server" class="btn sub2" Text="Reopen" OnClientClick="return ConfirmReopen();" />
                        <asp:Button ID="btnFloatConfirm" runat="server" class="btn sub2" Text="Confirm" OnClientClick="return ConfirmAlert();" />
                        <asp:Button ID="btnFloatAdd" runat="server" class="btn sub1" Text="Save" OnClientClick="return SalesValidate();" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnFloatAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClientClick="return SalesValidate();" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnFloatCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                        <asp:Button ID="btnFloatClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                        <asp:Button ID="btnFloatPRint" runat="server" class="btn sub3" Text="Print" OnClientClick="return OpenPrint();" />

                        <button id="BtnFloatPopup" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>
                        <button id="BtnFloatPopupCstCntr" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModalCstCntr">Open Modal</button>
                     </div>
                      </div>
                <div class="sub_cont pull-right">
                    <div class="save_sec">
                        <asp:Button ID="btnPrdt" runat="server" class="btn btn-primary" Style="display: none" Text="Reopen" />
                        <asp:Button ID="btnCustomer" runat="server" class="btn btn-primary" Style="display: none" Text="Reopen" OnClick="btnCustomer_Click" />
                        <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return SalesValidate();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return SalesValidate();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnConfirm1" runat="server" class="btn sub2" Text="Confirm" OnClick="btnUpdate_Click" Style="display: none" />
                        <asp:Button ID="btnReopen1" runat="server" Style="display: none" class="btn sub2" Text="Reopen" OnClick="btnReopen1_Click" />
                        <asp:Button ID="btnReopen" runat="server" class="btn sub2" Text="Reopen" OnClientClick="return ConfirmReopen();" />
                        <asp:Button ID="btnConfirm" runat="server" class="btn sub2" Text="Confirm" OnClientClick="return ConfirmAlert();" />
                        <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClientClick="return SalesValidate();" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClientClick="return SalesValidate();" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                        <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                        <asp:Button ID="btnPRint" runat="server" class="btn sub3" Text="Print" OnClientClick="return OpenPrint();" />

                        <button id="BtnPopup" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>
                        <button id="BtnPopupCstCntr" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModalCstCntr">Open Modal</button>
                    </div>
                </div>

                <div id="divList" style="cursor: pointer;" class="list_b" onclick="ConfirmMessage();" runat="server">
                    <i class="fa fa-arrow-circle-left"></i>
                </div>


            </div>
        </div>
    </div>


    <div class="col-sm-12 col-md-12 col-lg-6" style="float: right; display: none">
        <div class="form-group row" style="display: none">
            <label for="inputPassword" class="col-sm-4 col-form-label font-sty" style="width: 28%;">Available for<span style="color: #F00">*</span></label>
            <div class="col-sm-8">
                <asp:DropDownList ID="ddlAccountName" class="form-control fg2_inp1 fg_chs2 inp_mst custom-select" runat="server" onkeypress="return DisableEnter(event);"></asp:DropDownList>
                <div id="divAvailable" runat="server" class="col-xs-12" style="background-color: rgb(234, 234, 234); height: auto; padding-top: 10px; border: 1px solid rgb(204, 204, 204); border-radius: 3px; width: 105%;">
                    <div class="form-group row">
                        <label for="inputPassword" class="col-sm-3 col-form-label font-sty" style="padding: 7px; width: 27%">Department</label>

                        <div id="divDept" class="col-sm-6">
                            <asp:DropDownList ID="ddlDepartment" class="form-control select2" multiple="multiple" data-placeholder="Select Department" Style="height: 25px; width: 124%;" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2" style="padding: 0px; width: 20%;">
                            <div id="divcbxAllDept" runat="server" class="smart-form" style="float: left; width: 99%;">
                                <label class="checkbox" style="float: right;">
                                    All
        <input type="checkbox" runat="server" onchange="ChangeEnable('cphMain_cbxAllDept');" onkeypress="return DisableEnter(event)" id="cbxAllDept" />
                                    <i></i>
                                </label>
                            </div>
                        </div>

                    </div>
                    <div class="form-group row">
                        <label for="inputPassword" class="col-sm-3 col-form-label font-sty" style="padding: 7px; width: 27%">Division</label>
                        <div id="divDivision" class="col-sm-6">
                            <asp:DropDownList ID="ddlDivision" class="form-control select2" multiple="multiple" data-placeholder="Select Division" Style="height: 25px; width: 124%;" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2" style="padding: 0px; width: 20%;">

                            <div id="divcbxAllDiv" runat="server" class="smart-form" style="float: left; width: 99%;">
                                <label class="checkbox" style="float: right;">
                                    All
        <input type="checkbox" runat="server" onchange="ChangeEnable('cphMain_cbxAllDiv');" onkeypress="return DisableEnter(event)" id="cbxAllDiv" />
                                    <i></i>
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="inputPassword" class="col-sm-3 col-form-label font-sty" style="padding: 7px; width: 27%">Designation</label>
                        <div id="divDsgn" class="col-sm-6">
                            <asp:DropDownList ID="ddlDesignation" class="form-control select2" multiple="multiple" data-placeholder="Select Designation" Style="height: 25px; width: 124%;" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2" style="padding: 0px; width: 20%;">

                            <div id="divcbxDsgn" runat="server" class="smart-form" style="float: left; width: 99%;">
                                <label class="checkbox" style="float: right;">
                                    All
        <input type="checkbox" runat="server" onchange="ChangeEnable('cphMain_cbxDsgn');" onkeypress="return DisableEnter(event)" id="cbxDsgn" />
                                    <i></i>
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="inputPassword" class="col-sm-3 col-form-label font-sty" style="padding: 7px; width: 27%">Employee</label>
                        <div id="divEmp" class="col-sm-6">
                            <asp:DropDownList ID="ddlEmployee" class="form-control select2" multiple="multiple" data-placeholder="Select Employee" Style="height: 25px; width: 124%;" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2" style="padding: 0px; width: 20%;">
                            <div id="divcbxAllEmp" runat="server" class="smart-form" style="float: left; width: 99%;">
                                <label class="checkbox" style="float: right;">
                                    All
        <input type="checkbox" runat="server" onchange="ChangeEnable('cphMain_cbxAllEmp');" onkeypress="return DisableEnter(event)" id="cbxAllEmp" />
                                    <i></i>
                                </label>
                            </div>
                        </div>
                    </div>



                </div>
            </div>
        </div>
    </div>

    <div class="col-sm-12 col-md-12 col-lg-6" style="margin-top: 1%; display: none">
        <div class="form-group row">
            <label for="inputPassword" class="col-sm-4 col-form-label font-sty" style="width: 24%;">Receipt No</label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtReceipt" Height="30px" Width="100%" class="form-control" runat="server" MaxLength="20" onchange="IncrmntConfrmCounter();" onkeypress="return  isTagDes(event);" onblur="return textCounter1(cphMain_txtReceipt,20,event)" onkeydown=" return textCounter(cphMain_txtReceipt,150)"></asp:TextBox>
            </div>
        </div>
    </div>

    <div id="dialog_simple" class="modal fade" tabindex="-1" data-backdrop="static" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod3" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title mod1 flt_l" id="exampleModalLabel"><i class="fa fa-commenting"></i>Remarks</h2>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body md_bd" id="divCancelPopUp">
                    <div id="divErrMsgCnclRsn" class="al-box war">Warning Alert !!!</div>
                    <textarea rows="4" cols="50" class="form-control" placeholder="Write Remarks here..."></textarea>
                </div>

            </div>
        </div>
    </div>
    <div id="CostCenterModal"></div>
     <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>


<!----animation script--->
<script>
    // SIGNATURE PROGRESS
    function moveProgressBarLimit(val) {
        //alert(val); alert(barname);
        var getPercent = (val / 100);
        var getProgressWrapWidth = $('#divLimitPrcnt').width();
        var progressTotal = getPercent * getProgressWrapWidth;
        var animationLength = 2500;

        // on page load, animate percentage bar to data percentage length
        // .stop() used to prevent animation queueing
        $('#divLimitPrcnt').stop().animate({
            left: progressTotal
        }, animationLength);
    }

    // SIGNATURE PROGRESS
    function moveProgressBarPeriod(val) {
        //alert(val); alert(barname);
        var getPercent = (val / 100);
        var getProgressWrapWidth = $('#divPeriodPrcnt').width();
        var progressTotal = getPercent * getProgressWrapWidth;
        var animationLength = 2500;

        // on page load, animate percentage bar to data percentage length
        // .stop() used to prevent animation queueing
        $('#divPeriodPrcnt').stop().animate({
            left: progressTotal
        }, animationLength);
    }
</script>


</asp:Content>

