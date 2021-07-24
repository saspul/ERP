<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Product_Master.aspx.cs" Inherits="Master_gen_Product_Master_gen_Product_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

 <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
 <script src="/js/New js/msdropdown/jquery.dd.js"></script>
 <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />

 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/hcm_ns.css" rel="stylesheet" />
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
     <script>
         var $au = jQuery.noConflict();
         $au(function () {
             $au('#cphMain_ddlProductGroup').selectToAutocomplete1Letter();
             $au('#cphMain_ddlProductBrand').selectToAutocomplete1Letter();
             $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
             $au('#cphMain_ddlMainCategory').selectToAutocomplete1Letter();
             $au('#cphMain_ddlUnit').selectToAutocomplete1Letter();
             $au('#cphMain_ddlTax').selectToAutocomplete1Letter();
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
                           window.location.href = "gen_Product_MasterList.aspx";
                           return false;
                       }
                       else {
                           return false;
                       }
                   });
                   return false;
               }
               else {
                   window.location.href = "gen_Product_MasterList.aspx";

               }
               return false;
           }
           function AlertClearAll() {
               if (confirmbox > 0) {
                   ezBSAlert({
                       type: "confirm",
                       messageText: "Do you want to clear all the data from this page?",
                       alertType: "info"
                   }).done(function (e) {
                       if (e == true) {
                           window.location.href = "gen_Product_Master.aspx";
                           return false;
                       }
                       else {
                           return false;
                       }
                   });
                   return false;
               }
               else {
                   window.location.href = "gen_Product_Master.aspx";
                   return false;
               }
               return false;
           }
           function PassSavedProduct(intPrdtId, num) {
               if (window.opener != null && !window.opener.closed) {
                   window.opener.GetValueFromChildProjectPrdt(intPrdtId, num);
               }
               window.close();
           }
           function PassSavedPurchase(intSupplierId, Row) {
               if (window.opener != null && !window.opener.closed) {
                   window.opener.GetValueFromProduct(intSupplierId, Row);
               }
               window.close();
           }
           //stop-0006

           //Pass product id and name for multiple row
           function PassSavedProductId(strId, strName, Row) {
               if (window.opener != null && !window.opener.closed) {
                   window.opener.GetValueFromChildProduct(strId, strName, Row);
               }
               window.close();
           }

    </script>
    <script>
        //start-0006
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {
                IncrmntConfrmCounter();

            }
        });
    </script>
    <script type="text/javascript">
 
        $(document).ready(function () {
           // alert('hi');
           // $('.aspNetDisabled').removeClass('aspNetDisabled').addClass('form1');
        });
        function Duplication() {
            $("#divWarning").html("Duplication error!. Highlighted field's can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=HiddenFieldBindDDl.ClientID%>").value = "1";
            
           // document.getElementById("<%=txtShortName.ClientID%>").style.borderColor = "Red";
         }
        function DuplicationName() {
          //  document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=txtProductName.ClientID%>").style.borderColor = "Red";
        }

        function DuplicationShortName() {
          //  document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=txtShortName.ClientID%>").style.borderColor = "Red";
        }

        function DuplicationCode() {
          //  document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=txtProductCode.ClientID%>").style.borderColor = "Red";
        }
        function DuplicationExternalAppCode() {
          //  document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=txtExternalAppCode.ClientID%>").style.borderColor = "Red";
        }
        function SuccessConfirmation() {
            $("#success-alert").html("Product details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Product details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function ErrorMsg() {
            $("#divWarning").html("Some error occured.Please review entered values !");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=HiddenFieldBindDDl.ClientID%>").value = "1";
        }
        function NameValidate() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtProductName.ClientID%>").value;
            var NamereplaceText1 = NameWithoutReplace.replace(/</g, "");
            var NamereplaceText2 = NamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtProductName.ClientID%>").value = NamereplaceText2;

            var ShrtNameWithoutReplace = document.getElementById("<%=txtShortName.ClientID%>").value;
            var ShrtNamereplaceText1 = ShrtNameWithoutReplace.replace(/</g, "");
            var ShrtNamereplaceText2 = ShrtNamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtShortName.ClientID%>").value = ShrtNamereplaceText2;

            if (document.getElementById("<%=hiddenPrdctCodeGenerate.ClientID%>").value == "2") {
                var PrdctCodeWithoutReplace = document.getElementById("<%=txtProductCode.ClientID%>").value;
                var PrdctCodereplaceText1 = PrdctCodeWithoutReplace.replace(/</g, "");
                var PrdctCodereplaceText2 = PrdctCodereplaceText1.replace(/>/g, "");
                document.getElementById("<%=txtProductCode.ClientID%>").value = PrdctCodereplaceText2;
            }
            var ExtAppCodeWithoutReplace = document.getElementById("<%=txtExternalAppCode.ClientID%>").value;
            var ExtAppCodereplaceText1 = ExtAppCodeWithoutReplace.replace(/</g, "");
            var ExtAppCodereplaceText2 = ExtAppCodereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtExternalAppCode.ClientID%>").value = ExtAppCodereplaceText2;

            var CostPriceWithoutReplace = document.getElementById("<%=txtCostPrice.ClientID%>").value;
            var CostPricereplaceText1 = CostPriceWithoutReplace.replace(/</g, "");
            var CostPricereplaceText2 = CostPricereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCostPrice.ClientID%>").value = CostPricereplaceText2;


            document.getElementById("<%=txtProductName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtShortName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlProductGroup.ClientID%>").style.borderColor = "";
            $("div#divPG input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=ddlProductBrand.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCountry.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlMainCategory.ClientID%>").style.borderColor = "";
            $("div#divMC input.ui-autocomplete-input").css("borderColor", "");
            if (document.getElementById("<%=hiddenPrdctCodeGenerate.ClientID%>").value == "2") {
                document.getElementById("<%=txtProductCode.ClientID%>").style.borderColor = "";
            }
            document.getElementById("<%=txtExternalAppCode.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCostPrice.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlUnit.ClientID%>").style.borderColor = "";
            $("div#divDiv input.ui-autocomplete-input").css("borderColor", "");
            $("div#divUnit input.ui-autocomplete-input").css("borderColor", "");

            var Name = document.getElementById("<%=txtProductName.ClientID%>").value.trim();          
            var DropdownListGroup = document.getElementById('<%=ddlProductGroup.ClientID %>');
            var SelectedValueGroup = DropdownListGroup.value;
            var DropdownListBrand= document.getElementById('<%=ddlProductBrand.ClientID %>');
            var SelectedValueBrand = DropdownListBrand.value;
            var DropdownListCountry = document.getElementById('<%=ddlCountry.ClientID %>');
            var SelectedValueCountry = DropdownListCountry.value;
            var DropdownListDivision = document.getElementById('<%=ddlDivision.ClientID %>');
            var SelectedValueDivision = DropdownListDivision.value;
            var DropdownListMainCtgry = document.getElementById('<%=ddlMainCategory.ClientID %>');
            var SelectedValueMainCtgry = DropdownListMainCtgry.value;
            var Unit = document.getElementById('<%=ddlUnit.ClientID %>');
            var SelectedUnit = Unit.value;
            var Flag = "0";
            if (document.getElementById("<%=hiddenPrdctCodeGenerate.ClientID%>").value == "2") {
                var ProductCode = document.getElementById("<%=txtProductCode.ClientID%>").value;

                if (ProductCode == "")
                {
                    Flag = "1";
                }
            }
            var CostPrice = document.getElementById("<%=txtCostPrice.ClientID%>").value;

          
            if (Name == "" ||  SelectedValueGroup == "--SELECT GROUP--"
                ||  SelectedValueDivision == "--SELECT DIVISION--" || SelectedValueMainCtgry == "--SELECT MAIN CATEGORY--"
                || Flag == "1" || CostPrice == "" || SelectedUnit == "--SELECT UNIT--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                if (SelectedUnit == "--SELECT UNIT--") {
                    document.getElementById("<%=ddlUnit.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlUnit.ClientID%>").focus();
                    $("div#divUnit input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divUnit input.ui-autocomplete-input").select();
                    $("div#divUnit input.ui-autocomplete-input").focus();
                    ret = false;
                }
                if (CostPrice == "") {
                    document.getElementById("<%=txtCostPrice.ClientID%>").style.borderColor = "Red";
                   document.getElementById("<%=txtCostPrice.ClientID%>").focus();
                    ret = false;

                }
                if (Flag == "1") {


                    document.getElementById("<%=txtProductCode.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtProductCode.ClientID%>").focus();
                    ret = false;
                }
                if (SelectedValueMainCtgry == "--SELECT MAIN CATEGORY--") {


                    document.getElementById("<%=ddlMainCategory.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlMainCategory.ClientID%>").focus();
                    $("div#divMC input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divMC input.ui-autocomplete-input").select();
                    $("div#divMC input.ui-autocomplete-input").focus();
                       ret = false;
                }
            
                if (SelectedValueDivision == "--SELECT DIVISION--") {


                    document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlDivision.ClientID%>").focus();
                    $("div#divDiv input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divDiv input.ui-autocomplete-input").select();
                    $("div#divDiv input.ui-autocomplete-input").focus();
                    ret = false;
                }
                if (SelectedValueGroup == "--SELECT GROUP--") {


                    document.getElementById("<%=ddlProductGroup.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlProductGroup.ClientID%>").focus();
                    $("div#divPG input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divPG input.ui-autocomplete-input").select();
                    $("div#divPG input.ui-autocomplete-input").focus();
                    ret = false;
                }
                if (Name == "") {


                    document.getElementById("<%=txtProductName.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=txtProductName.ClientID%>").focus();
                     ret = false;
                 }
            }
            
            if (ret == false) {
                CheckSubmitZero();
            }
            document.getElementById("<%=HiddenFieldcbxSale.ClientID%>").value = "0";
            document.getElementById("<%=HiddenFieldcbxStock.ClientID%>").value = "0";
            if ($("#cphMain_cbxSale").hasClass('clicked')) {
                document.getElementById("<%=HiddenFieldcbxSale.ClientID%>").value = "1";
            }
            if ($("#cphMain_cbxStock").hasClass('clicked')) {
                document.getElementById("<%=HiddenFieldcbxStock.ClientID%>").value = "1";
            }
            document.getElementById("<%=HiddenFieldCntryDDL.ClientID%>").value = document.getElementById("<%=ddlCountry.ClientID%>").value;
            return ret;
        }
    </script>
    <script type="text/javascript" language="javascript">
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
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            var txtPerVal = document.getElementById("<%=txtCostPrice.ClientID%>").value;
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
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


        function ReplaceTagAndCopyToShrtName() {

            var NameWithoutReplace = document.getElementById("<%=txtProductName.ClientID%>").value;
            var NamereplaceText1 = NameWithoutReplace.replace(/</g, "");
            var NamereplaceText2 = NamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtProductName.ClientID%>").value = NamereplaceText2;

            if (document.getElementById("<%=txtShortName.ClientID%>").value == "")
            {
                document.getElementById("<%=txtShortName.ClientID%>").value = document.getElementById("<%=txtProductName.ClientID%>").value;


            }


        }
        function ReplaceTag(obj) {

            var WithoutReplace = document.getElementById(obj).value;
             var replaceText1 = WithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById(obj).value = replaceText2;

            


        }
        function ReplaceTagAndQuote(obj) {

            var WithoutReplace = document.getElementById(obj).value;
            var replaceText1 = WithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4= replaceText3.replace(/"/g, "");
            document.getElementById(obj).value = replaceText4;




        }

        function AmountCheck() {
            //     var ret = true;
            var txtPerVal = document.getElementById("<%=txtCostPrice.ClientID%>").value;
            if (txtPerVal == "") {
                return false;
            }
            else {
                if (!isNaN(txtPerVal) == false) {
                    document.getElementById("<%=txtCostPrice.ClientID%>").value = "";
                    return false;
                }
                else {
                    var amt = parseFloat(txtPerVal);
                    var num = amt;
                    var n = 0;
                    // for floatting number adjustment from corp global
                    var FloatingValue = document.getElementById("<%=hiddenMoneyDecCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);
                    }
                    document.getElementById("<%=txtCostPrice.ClientID%>").value = n;

            }
        }
        }

        //for not allowing above max limit
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }
        
        function isTagMulti(obj, evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                if (obj == "cphMain_txtProductDescription") {

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

            var keynum;
            var keyChar;
            if (window.event) { // IE                    
                keynum = evt.keyCode;
            } else if (evt.which) { // Netscape/Firefox/Opera                   
                keynum = evt.which;
            }
            keyChar=String.fromCharCode(keynum);
            if (keyChar == '"' || keyChar == '\'') {
                ret = false;
            }
            return ret;
        }
        function ChangeProductName(obj) {
            if (obj == "cphMain_cbxNameToDesc") {
                document.getElementById("cphMain_cbxNametoRmrk").checked = false;
            }
            else if (obj == "cphMain_cbxNametoRmrk") {
                document.getElementById("cphMain_cbxNameToDesc").checked = false;
            }
        }
        function selectorToAutocompleteSubC(ev) {
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var countryID = document.getElementById("cphMain_ddlMainCategory").value;
            if (countryID != "--SELECT MAIN CATEGORY--" && countryID != "" && corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
                $au("#cphMain_ddlSubCategoryt").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "gen_Product_Master.aspx/changeSubC",
                            async: false,
                            data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "', 'countryID': '" + parseInt(countryID) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        val: item.split('<,>')[0],
                                        label: item.split('<,>')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                            },
                            failure: function (response) {
                            }
                        });
                    },
                    autoFocus: false,
                    select: function (e, i) {
                        document.getElementById("<%=HiddenFieldSubC.ClientID%>").value = i.item.val;
                        document.getElementById("cphMain_ddlSubCategoryt").value = i.item.label;
                    },
                    change: function (event, ui) {
                        if (ui.item) {
                        }
                        else {
                            document.getElementById("cphMain_ddlSubCategoryt").value = "";
                            document.getElementById("<%=HiddenFieldSubC.ClientID%>").value = "";
                        }
                    }
                });
            }
        }
        function selectorToAutocompleteSmaC(ev) {
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var countryID = document.getElementById("<%=HiddenFieldSubC.ClientID%>").value;
            if (countryID != "--SELECT SUB CATEGORY--" && countryID != "" && corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
                $au("#cphMain_ddlSmallCategory").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "gen_Product_Master.aspx/changeSmaC",
                            async: false,
                            data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "', 'countryID': '" + parseInt(countryID) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        val: item.split('<,>')[0],
                                        label: item.split('<,>')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                            },
                            failure: function (response) {
                            }
                        });
                    },
                    autoFocus: false,
                    select: function (e, i) {
                        document.getElementById("<%=HiddenFieldSmaC.ClientID%>").value = i.item.val;
                        document.getElementById("cphMain_ddlSmallCategory").value = i.item.label;
                    },
                    change: function (event, ui) {
                        if (ui.item) {
                        }
                        else {
                            document.getElementById("cphMain_ddlSmallCategory").value = "";
                            document.getElementById("<%=HiddenFieldSmaC.ClientID%>").value = "";
                        }
                    }
                });
            }
        }
        function selectorToAutocompleteLeaC(ev) {
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var countryID = document.getElementById("<%=HiddenFieldSmaC.ClientID%>").value;
            if (countryID != "--SELECT SMALL CATEGORY--" && countryID != "" && corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
                $au("#cphMain_ddlLeastCategory").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "gen_Product_Master.aspx/changeLeaC",
                            async: false,
                            data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "', 'countryID': '" + parseInt(countryID) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        val: item.split('<,>')[0],
                                        label: item.split('<,>')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                            },
                            failure: function (response) {
                            }
                        });
                    },
                    autoFocus: false,
                    select: function (e, i) {
                        document.getElementById("<%=HiddenFieldLeaC.ClientID%>").value = i.item.val;
                        document.getElementById("cphMain_ddlLeastCategory").value = i.item.label;
                    },
                    change: function (event, ui) {
                        if (ui.item) {
                        }
                        else {
                            document.getElementById("cphMain_ddlLeastCategory").value = "";
                            document.getElementById("<%=HiddenFieldLeaC.ClientID%>").value = "";
                        }
                    }
                });
            }
        }
        function changeMC() {
            document.getElementById("cphMain_ddlSubCategoryt").value = "";
            document.getElementById("<%=HiddenFieldSubC.ClientID%>").value = "";
            document.getElementById("cphMain_ddlSmallCategory").value = "";
            document.getElementById("<%=HiddenFieldSmaC.ClientID%>").value = "";
            document.getElementById("cphMain_ddlLeastCategory").value = "";
            document.getElementById("<%=HiddenFieldLeaC.ClientID%>").value = "";
            IncrmntConfrmCounter();
        }
        function changeSC() {
            document.getElementById("cphMain_ddlSmallCategory").value = "";
            document.getElementById("<%=HiddenFieldSmaC.ClientID%>").value = "";
            document.getElementById("cphMain_ddlLeastCategory").value = "";
            document.getElementById("<%=HiddenFieldLeaC.ClientID%>").value = "";
            if (document.getElementById("<%=HiddenFieldSubC.ClientID%>").value == "") {
                document.getElementById("cphMain_ddlSubCategoryt").value = "";
            }
            IncrmntConfrmCounter();
        }
        function changeSC1() {
            document.getElementById("cphMain_ddlLeastCategory").value = "";
            document.getElementById("<%=HiddenFieldLeaC.ClientID%>").value = "";
            if (document.getElementById("<%=HiddenFieldSmaC.ClientID%>").value == "") {
                document.getElementById("cphMain_ddlSmallCategory").value = "";
            }
            IncrmntConfrmCounter();
        }
        function changeLC() {
            if (document.getElementById("<%=HiddenFieldLeaC.ClientID%>").value == "") {
                document.getElementById("cphMain_ddlLeastCategory").value = "";
            }
            IncrmntConfrmCounter();
        }
        function changeProdGrp() {
            IncrmntConfrmCounter();
            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "1") {
                if (document.getElementById("<%=ddlProductGroup.ClientID%>").value== "--SELECT GROUP--") {
                    document.getElementById("<%=ddlTax.ClientID%>").value = "--SELECT TAX--";
                    $("div#cphMain_divTax input.ui-autocomplete-input").val("--SELECT TAX--");
                }
                else {
                    var orgID = '<%= Session["ORGID"] %>';
                    var corptID = '<%= Session["CORPOFFICEID"] %>';
                    var Product_GrpId = document.getElementById("<%=ddlProductGroup.ClientID%>").value;
                    if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "gen_Product_Master.aspx/changeProdGrp",
                            data: '{Product_GrpId: "' + Product_GrpId + '"}',
                            dataType: "json",
                            success: function (data) {
                                document.getElementById("<%=ddlTax.ClientID%>").value = data.d[0];
                                $("div#cphMain_divTax input.ui-autocomplete-input").val(data.d[1]);
                            }
                        });
                    }
                    else {
                        window.location = '/Security/Login.aspx';
                    }
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
      <li><a href="gen_Product_MasterList.aspx">Product Master</a></li>
        <li id="lblEntryB" runat="server" class="active">Add Product</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
          <asp:HiddenField ID="hiddenMoneyDecCount" runat="server" />
       <asp:HiddenField ID="hiddenTaxEnabled" runat="server" />
      <asp:HiddenField ID="hiddenPrdctCodeGenerate" runat="server" />
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
     <asp:HiddenField ID="HiddenChkMode" runat="server" />

     <asp:HiddenField ID="HiddenFieldcbxSale" runat="server" />
     <asp:HiddenField ID="HiddenFieldcbxStock" runat="server" />
     <asp:HiddenField ID="HiddenFieldCntryDDL" runat="server" />
     <asp:HiddenField ID="HiddenFieldSubC" runat="server" />
     <asp:HiddenField ID="HiddenFieldSmaC" runat="server" />
     <asp:HiddenField ID="HiddenFieldLeaC" runat="server" />
     <asp:HiddenField ID="HiddenFieldProdId" runat="server" />
     <asp:HiddenField ID="HiddenFieldBindDDl" runat="server" Value="0"/>
   <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add Product</h2>

              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480">
                <label for="email" class="fg2_la1">Product Name:<span class="spn1">*</span></label>
                   <asp:TextBox autoComplete="off" ID="txtProductName" class="form-control fg2_inp1 inp_mst ss_sel" placeholder="Product Name" runat="server" MaxLength="150" Style="text-transform: uppercase; " onblur="ReplaceTagAndCopyToShrtName();"></asp:TextBox>
                <button class="input-group-addon date1 ss_ch inp_mst" id="cbxSale" runat="server">
                  <span class="blu_bt blu_c" title="Saleable">
                    <i class="fa fa-shopping-cart "></i>
                  </span>
                </button>
                <button class="input-group-addon date1 ss_ch1 inp_mst" id="cbxStock" runat="server">
                  <span class="blu_bt blu_s" title="Stockable">
                    <i class="fa fa-archive "></i>
                  </span>
                </button>
              </div>

              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480">
                <label for="email" class="fg2_la1">Short/Print Name:<span class="spn1"></span></label>
                   <asp:TextBox autoComplete="off" ID="txtShortName" class="form-control fg2_inp1" placeholder="Short/Print Name" runat="server" MaxLength="100" Style="text-transform: uppercase; " onblur="ReplaceTag('cphMain_txtShortName');"></asp:TextBox>
              </div>

              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480" id="divPG">
               <label for="email" class="fg2_la1">Product Group:<span class="spn1">*</span></label>
                   <asp:DropDownList ID="ddlProductGroup" class="form-control fg2_inp1 inp_mst" runat="server" onchange="changeProdGrp();"></asp:DropDownList>
              </div>

              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480" id="divPB">
               <label for="email" class="fg2_la1">Product Brand:<span class="spn1"></span></label>
                   <asp:DropDownList ID="ddlProductBrand" class="form-control fg2_inp1" runat="server" ></asp:DropDownList>
              </div>

              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480" id="divMC">
               <label for="email" class="fg2_la1">Main Category:<span class="spn1">*</span></label>
                   <asp:DropDownList ID="ddlMainCategory" class="form-control fg2_inp1 inp_mst" runat="server" onchange="changeMC();"></asp:DropDownList>
              </div>
              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480" id="divSC">
               <label for="email" class="fg2_la1">Sub Category:<span class="spn1"></span></label>
                   <asp:TextBox ID="ddlSubCategoryt"  onchange="changeSC();" class="form-control fg2_inp1 inp_mst"  placeholder="--SELECT SUB CATEGORY--"   runat="server"  onkeypress="return selectorToAutocompleteSubC(event);" onkeydown="return selectorToAutocompleteSubC(event);"></asp:TextBox>
              </div>
               <div class="form-group fg2 sa_fg4 fg_m_10 sa_480" id="divSC1">
               <label for="email" class="fg2_la1">Small Category:<span class="spn1"></span></label>
                    <asp:TextBox ID="ddlSmallCategory"  onchange="changeSC1();" class="form-control fg2_inp1 inp_mst"  placeholder="--SELECT SMALL CATEGORY--"   runat="server"  onkeypress="return selectorToAutocompleteSmaC(event);" onkeydown="return selectorToAutocompleteSmaC(event);"></asp:TextBox>
              </div>

              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480" id="divLC">
               <label for="email" class="fg2_la1">Least Category:<span class="spn1"></span></label>
                   <asp:TextBox ID="ddlLeastCategory"  onchange="changeLC();" class="form-control fg2_inp1 inp_mst"  placeholder="--SELECT LEAST CATEGORY--"   runat="server"  onkeypress="return selectorToAutocompleteLeaC(event);" onkeydown="return selectorToAutocompleteLeaC(event);"></asp:TextBox>
              </div>

              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480" id="divDiv">
               <label for="email" class="fg2_la1">Division:<span class="spn1">*</span></label>
                   <asp:DropDownList ID="ddlDivision" class="form-control fg2_inp1 inp_mst" runat="server" ></asp:DropDownList>
              </div>

              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480" id="divCoun">
               <label for="email" class="fg2_la1">Country of Origin:<span class="spn1"></span></label>
                   <asp:DropDownList ID="ddlCountry" class="form-control fg2_inp1 inp_mst" runat="server" ></asp:DropDownList>
              </div>
              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480">
               <label for="email" class="fg2_la1">External App Code:<span class="spn1"></span></label>
                  <asp:TextBox ID="txtExternalAppCode" class="form-control fg2_inp1" placeholder="External App Code" runat="server" MaxLength="100" Style="text-transform: uppercase; "  onblur="ReplaceTag('cphMain_txtExternalAppCode');"></asp:TextBox>
              </div>
              <div class="form-group fg2 sa_fg4 fg_m_10" id="divUnit">
               <label for="email" class="fg2_la1">Unit:<span class="spn1">*</span></label>
                   <asp:DropDownList ID="ddlUnit" class="form-control fg2_inp1 inp_mst" runat="server" ></asp:DropDownList>
              </div>
              <div class="clearfix"></div>
              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480" id="divTax" runat="server">
               <label for="email" class="fg2_la1">Tax:<span class="spn1"></span></label>
                   <asp:DropDownList ID="ddlTax" class="form-control fg2_inp1" runat="server" ></asp:DropDownList>
              </div>
              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480">
               <label for="email" class="fg2_la1">Cost Price:<span class="spn1">*</span></label>
                   <asp:TextBox ID="txtCostPrice" class="form-control fg2_inp1 tr_r inp_mst" placeholder="0.00" runat="server" onblur="return AmountCheck();" MaxLength="10" Style="text-transform: uppercase; " ></asp:TextBox>
              </div>

              <div class="form-group fg2 sa_fg4 fg_m_10 sa_480" id="divPrdctCode" runat="server">
                <label for="email" class="fg2_la1">Product Code:<span class="spn1"></span></label>
                   <asp:TextBox ID="txtProductCode" class="form-control fg2_inp1" placeholder="Product Code" runat="server" MaxLength="25" Style="text-transform: uppercase; "></asp:TextBox>
              </div>

              <div class="fg2 sa_480">
                <div class="form-group fg6" id="divTax1" runat="server">
                  <label for="email" class="fg2_la1 pad_l">Inclusive Tax:<span class="spn1"></span></label>
                  <div class="check1">
                    <div class="">
                      <label class="switch">
                        <input type="checkbox" id="cbxInclusiveExclusiveTax" runat="server" checked="checked" >
                        <span class="slider_tog round"></span>
                      </label>
                    </div>
                  </div>
                </div>
                 <div class="form-group fg6">
                  <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
                  <div class="check1">
                    <div class="">
                      <label class="switch">
                        <input type="checkbox" id="cbxStatus" runat="server" checked="checked">
                        <span class="slider_tog round"></span>
                      </label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="clearfix"></div>

            <div class="form-group fg2 sa_480">
              <label for="email" class="fg2_la1">Product Description: <span class="spn1">&nbsp;</span></label>
                <asp:TextBox ID="txtProductDescription" rows="3" cols="78" style="width: 235px; height: 66px;" class="form-control flt_l txr_1 dt_wdt" placeholder="Product Description" runat="server" TextMode="MultiLine"  onkeypress="return isTagMulti('cphMain_txtProductDescription',event);" onkeydown="textCounter(cphMain_txtProductDescription,3800);" onkeyup="textCounter(cphMain_txtProductDescription,3800);" onblur="ReplaceTagAndQuote('cphMain_txtProductDescription');"  ></asp:TextBox>
            </div>
            <div class="fg2 sa_480">
              <label for="email" class="fg2_la1 pad_l">Replace Product Name in Invoice with:<span class="spn1"></span></label>
              <div class="fg12 sa_480 mar_tp10">
                <div class="check1">
                  <div class="">
                    <label class="switch">
                      <input type="checkbox" id="cbxNameToDesc" runat="server" onkeypress="return DisableEnter(event)" onchange="ChangeProductName('cphMain_cbxNameToDesc');">
                      <span class="slider_tog round"></span>
                    </label> <label>Description</label>
                  </div>
                </div>
              </div>
              <div class="fg12 sa-480 mar_tp10">
                <div class="check1">
                  <div class="">
                    <label class="switch">
                      <input type="checkbox" id="cbxNametoRmrk" runat="server" onkeypress="return DisableEnter(event)" onchange="ChangeProductName('cphMain_cbxNametoRmrk');">
                      <span class="slider_tog round"></span>
                    </label> <label>Invoice Remark</label>
                  </div>
                </div>
              </div>
            </div>

          <div class="clearfix"></div>
          <div class="devider"></div>

                <div class="sub_cont pull-right">
                <div class="save_sec">
                  <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
                  <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
                  <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
                  <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
                   <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
                   <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
                </div>
              </div>
             </div>
            </div>
           </div>
 <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">
          <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
                  <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
                  <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
                  <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
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
                .dd .ddTitle .ddTitleText {
    padding: 7px 20px 7px 5px;
}
                .dd .divider {
    border-left: none;
}
                  .disabledAll{
   background-color: #eee !important;
opacity: 1 !important;
color: #999 !important;
cursor: not-allowed !important;

}
          .flag {
    padding: 0 !important;
    margin: 0 5px 0 0;
}
    </style>
    <script>
        $(document).ready(function () {
            $('.ss_ch').on('click', function () {
                $('.ss_ch').toggleClass('clicked');
                return false;
            });
            $('.ss_ch1').on('click', function () {
                $('.ss_ch1').toggleClass('clicked');
                return false;
            });
            if (document.getElementById("<%=HiddenFieldcbxSale.ClientID%>").value == "1") {
                $("#cphMain_cbxSale").addClass('clicked');
            }
            if (document.getElementById("<%=HiddenFieldcbxStock.ClientID%>").value == "1") {
                $("#cphMain_cbxStock").addClass('clicked');
            }
        });
</script> 
    <script>
        $(document).ready(function () {
            var $aus = jQuery.noConflict();
            $aus("#cphMain_ddlCountry").msDropdown({ roundedBorder: false });
            $aus("#cphMain_ddlCountry").msDropdown({ visibleRows: 4 });
            $aus("").msDropdown();
        });
</script>

<script>
    $(document).on('keydown', function (e) {
        var keyCode = e.keyCode || e.which;

        if (keyCode == 9) {
            $('.dd .ddChild').hide();
        }
    });
</script> 
</asp:Content>

