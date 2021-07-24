<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="pms_Purchase_Order.aspx.cs" Inherits="PMS_PMS_Master_pms_Purchase_Order_pms_Purchase_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

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
    var confirmbox = 0;

    function IncrmntConfrmCounter() {
        confirmbox++;
    }

    var $noCon = jQuery.noConflict();

    $noCon(window).load(function () {

        ChangeCurrency(0);
        LoadVendors(0, null);

        DisplayProducts(0,0);

        DisplayCharge(0,0);
        DisplayAttachmnts(0);

        document.getElementById("<%=tdDiscntTotal.ClientID%>").value = "0";

        CalculateNetAmount();

        if (document.getElementById("<%=hiddenView.ClientID%>").value == "1") {
            document.getElementById("<%=divQuickSearch.ClientID%>").style.display = "none";
        }
    });

    function DatePickerActivate() {

        $noCon('#datepickerPrchsDate').datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            timepicker: false
        }).on('changeDate', function (selected) {
            var minDate = new Date(selected.date.valueOf());
            $noCon('#datepickerExpctdDelvryDt').datepicker('setStartDate', minDate);
        });

        var DateVal = document.getElementById("<%=txtPrchsOrdrDate.ClientID%>").value;
        $noCon('#datepickerExpctdDelvryDt').datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            startDate: DateVal,
            timepicker: false
        });

        $noCon('#datepickerQuotnDate').datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            timepicker: false
        });

        $noCon('#datepickerRqrmntDate').datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            timepicker: false
        });

        $noCon('#datepickerRqstnDate').datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            timepicker: false
        });

        $noCon('#datepickerAprvlDate').datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            //startDate: new Date(),
            timepicker: false
        });

    }

    var $au = jQuery.noConflict();
    $au(function () {
        $au(".ddl").selectToAutocomplete1Letter();
    });

    function AutoCompleteAll(Mode) {
        $au(".ddl").selectToAutocomplete1Letter();
        //setTimeout(function () { $au(".ddl").selectToAutocomplete1Letter(); }, 50);

        if (Mode == "1") {
            $("#divddlPODivision> input").select();
        }
        else if (Mode == "2") {
            $("#divddlProject> input").select();
        }
        else if (Mode == "3") {
            $("#divddlPORequestor> input").select();
        }
        else if (Mode == "4") {
            $("#divddlVendor> input").select();
        }

        DatePickerActivate();
    }

    function ConfirmMessageList() {
        if (confirmbox > 0) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to leave this page?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    window.location.href = "pms_Purchase_Order_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }
        else {
            window.location.href = "pms_Purchase_Order_List.aspx";
            return false;
        }
        return false;
    }

    function AlertClearAll() {
        if (confirmbox > 0) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want clear all data in this page?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    window.location.href = "pms_Purchase_Order.aspx";
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }
        else {
            window.location.href = "pms_Purchase_Order.aspx";
            return false;
        }
        return false;
    }

    function ConfirmMessage() {
        if (confirmbox > 0) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to leave this page?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    if (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value != "") {
                        window.location.href = "/Master/gen_Approval_Console/gen_Approval_Console.aspx";
                        return false;
                    }
                    else {
                        window.location.href = "pms_Purchase_Order_List.aspx";
                        return false;
                    }
                }
                else {
                    return false;
                }
            });
        }
        else {
            if (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value != "") {
                window.location.href = "/Master/gen_Approval_Console/gen_Approval_Console.aspx";
                return false;
            }
            else {
                window.location.href = "pms_Purchase_Order_List.aspx";
                return false;
            }
        }
        return false;
    }

    function DisplayProducts(Mode, CopyMode) {

        if (Mode != "0") {
            IncrmntConfrmCounter();
        }
        //Edit
        if (document.getElementById("<%=hiddenEditDtls.ClientID%>").value != "[]" && document.getElementById("<%=hiddenEditDtls.ClientID%>").value != "") {

            var Count = 0;
            var EditVal = document.getElementById("<%=hiddenEditDtls.ClientID%>").value;

            var findAtt2 = '\\"\\[';
            var reAtt2 = new RegExp(findAtt2, 'g');
            var resAtt2 = EditVal.replace(reAtt2, '\[');

            var findAtt3 = '\\]\\"';
            var reAtt3 = new RegExp(findAtt3, 'g');
            var resAtt3 = resAtt2.replace(reAtt3, '\]');

            var jsonAtt = $.parseJSON(resAtt3);
            for (var key in jsonAtt) {
                if (jsonAtt.hasOwnProperty(key)) {
                    if (jsonAtt[key].DTLID != "") {

                        EditRows(jsonAtt[key].DTLID, jsonAtt[key].SLNO, jsonAtt[key].QUANTITY, jsonAtt[key].PRICE, jsonAtt[key].TOTALAMNT, jsonAtt[key].PRODUCTID, jsonAtt[key].DISCNTPRCNTG, jsonAtt[key].DISCNTAMNT, jsonAtt[key].TAXID, jsonAtt[key].TAXPRCNTG, jsonAtt[key].VEHICLEID, jsonAtt[key].STRTDATE, jsonAtt[key].ENDDATE, jsonAtt[key].EMPID, jsonAtt[key].FLGHTPNRNO, jsonAtt[key].SECTOR, jsonAtt[key].TRVLDATE, jsonAtt[key].PRODUCTNAME, jsonAtt[key].VEHICLENAME, jsonAtt[key].EMPNAME, jsonAtt[key].TAXNAME, Count);

                        if (parseInt(Count + 1) < parseInt(jsonAtt.length)) {
                            document.getElementById("btnAdd" + Count).disabled = true;
                        }

                        if (CopyMode == "1") {
                            document.getElementById("tdEvt" + Count).innerHTML = "INS";
                        }

                        Count++;
                    }
                }
            }
        }
        else {
            //Add

            document.getElementById("btnCopy").style.display = "block";

            if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {

                //Products
                document.getElementById("divProducts").style.display = "block";
                document.getElementById("divVehicle").style.display = "none";
                document.getElementById("divAirTicket").style.display = "none";

                AddMoreRowsProducts(0);

                document.getElementById("divBulkProduct").style.display = "block";
            }
            else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {

                //Vehicles
                document.getElementById("divProducts").style.display = "none";
                document.getElementById("divVehicle").style.display = "block";
                document.getElementById("divAirTicket").style.display = "none";

                AddMoreRowsVehicles(0);
                document.getElementById("divBulkProduct").style.display = "block";
            }
            else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {

                //AirTickets
                document.getElementById("divProducts").style.display = "none";
                document.getElementById("divVehicle").style.display = "none";
                document.getElementById("divAirTicket").style.display = "block";

                AddMoreRowsAirTckt(0);
                document.getElementById("divBulkProduct").style.display = "none";
            }

        }

    }

    function DisplayCharge(Mode, CopyMode) {

        if (Mode != "0") {
            IncrmntConfrmCounter();
        }

        //Edit
        if (document.getElementById("<%=hiddenChrgDtls.ClientID%>").value != "[]" && document.getElementById("<%=hiddenChrgDtls.ClientID%>").value != "") {

            var Count = 0;
            var EditVal = document.getElementById("<%=hiddenChrgDtls.ClientID%>").value;

            var findAtt2 = '\\"\\[';
            var reAtt2 = new RegExp(findAtt2, 'g');
            var resAtt2 = EditVal.replace(reAtt2, '\[');

            var findAtt3 = '\\]\\"';
            var reAtt3 = new RegExp(findAtt3, 'g');
            var resAtt3 = resAtt2.replace(reAtt3, '\]');

            var jsonAtt = $.parseJSON(resAtt3);
            for (var key in jsonAtt) {
                if (jsonAtt.hasOwnProperty(key)) {
                    if (jsonAtt[key].DTLID != "") {

                        EditRowsChrg(jsonAtt[key].DTLID, jsonAtt[key].CHRGHDID, jsonAtt[key].CHRGAMNT, jsonAtt[key].CHRGHDNAME, jsonAtt[key].CHRGCALCULATE, Count);

                        if (parseInt(Count + 1) < parseInt(jsonAtt.length)) {
                            document.getElementById("btnAddChrg" + Count).disabled = true;
                        }

                        if (CopyMode == "1") {
                            document.getElementById("tdEvtChrg" + Count).innerHTML = "INS";
                        }

                        Count++;
                    }
                }
            }
        }
        else {
            AddMoreRowsCharge(0);
        }

        CalculateNetAmount();
    }

    function DisplayAttachmnts(Mode) {

        if (Mode != "0") {
            IncrmntConfrmCounter();
        }

        AttachmentAdd();

        //Edit
        if (document.getElementById("<%=hiddenAttchmntDtls.ClientID%>").value != "[]" && document.getElementById("<%=hiddenAttchmntDtls.ClientID%>").value != "") {

            var Count = 0;
            var EditVal = document.getElementById("<%=hiddenAttchmntDtls.ClientID%>").value;

            var findAtt2 = '\\"\\[';
            var reAtt2 = new RegExp(findAtt2, 'g');
            var resAtt2 = EditVal.replace(reAtt2, '\[');

            var findAtt3 = '\\]\\"';
            var reAtt3 = new RegExp(findAtt3, 'g');
            var resAtt3 = resAtt2.replace(reAtt3, '\]');

            var jsonAtt = $.parseJSON(resAtt3);
            for (var key in jsonAtt) {
                if (jsonAtt.hasOwnProperty(key)) {
                    if (jsonAtt[key].DTLID != "") {

                        EditRowsAttchmnt(jsonAtt[key].DTLID, jsonAtt[key].FILENAME, jsonAtt[key].ACT_FILENAME, jsonAtt[key].DESCRIPTN, Count);

                        if (parseInt(Count + 1) < parseInt(jsonAtt.length)) {
                            document.getElementById("btnAddFile" + Count).disabled = true;
                        }

                        Count++;
                    }
                }
            }
        }
        else {
            AddMoreRowsAttachmnt(0);
        }
    }


    function ChangeCurrency(Mode) {

        if (Mode != "0") {
            IncrmntConfrmCounter();
        }

        if (document.getElementById("<%=ddlCurrency.ClientID%>").value == document.getElementById("<%=hiddenDefaultCurrencyId.ClientID%>").value) {
            document.getElementById("divExchangeRate").style.display = "none";
        }
        else {
            document.getElementById("divExchangeRate").style.display = "block";

            document.getElementById("<%=spanCrncyExchng.ClientID%>").innerHTML = document.getElementById("<%=hiddenDefaultCrncyAbrvtn.ClientID%>").value;

            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var OrgId = '<%= Session["ORGID"] %>';
            var CurrencyId = document.getElementById("<%=ddlCurrency.ClientID%>").value;

            $.ajax({
                async: false,
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                url: "pms_Purchase_Order.aspx/ChangeCurrency",
                data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",CurrencyId:"' + CurrencyId + '"}',
                success: function (response) {

                    document.getElementById("<%=hiddenExchngCurrencyModeId.ClientID%>").value = response.d[0];
                    document.getElementById("<%=hiddenExchngCrncyAbrvtn.ClientID%>").value = response.d[1];

                    $('.clsCrncy').html(document.getElementById("<%=hiddenExchngCrncyAbrvtn.ClientID%>").value);

                    CalculateNetAmount();
                },
                failure: function (response) {

                }
            });
        }
    }

    function ChangeDiscntTotal() {
        document.getElementById("<%=tdDiscntTotal.ClientID%>").value = document.getElementById("<%=txtDiscntTotal.ClientID%>").value;
        CalculateNetAmount();
    }

    function ValidatePO() {

        var ret = true;

        //alert(ValidateDtls()); alert(ValidateChrgDtls()); alert(ValidateAttchmntDtls());

        //alert(ValidateMobile('cphMain_txtVendorMobile')); alert(ValidateEmail('cphMain_txtVendorEmail')); alert(ValidateMobile('cphMain_txtPOMobile'));

        var validateMobile = 0, validateEmail = 0;

        if (ValidateMobile('cphMain_txtVendorMobile') == false || ValidateMobile('cphMain_txtPOMobile') == false || ValidateEmail('cphMain_txtVendorEmail') == false) {

            $noCon('#cphMain_txtVendorMobile').css("border-color", "");
            $noCon('#cphMain_txtPOMobile').css("border-color", "");
            $noCon('#cphMain_txtVendorEmail').css("border-color", "");

            if (ValidateMobile('cphMain_txtVendorMobile') == false) {
                $noCon('#cphMain_txtVendorMobile').css("border-color", "red");
                $noCon('#cphMain_txtVendorMobile').focus();
                validateMobile++;
            }
            if (ValidateMobile('cphMain_txtPOMobile') == false) {
                $noCon('#cphMain_txtPOMobile').css("border-color", "red");
                $noCon('#cphMain_txtPOMobile').focus();
                validateMobile++;
            }
            if (ValidateEmail('cphMain_txtVendorEmail') == false) {
                $noCon('#cphMain_txtVendorEmail').css("border-color", "red");
                $noCon('#cphMain_txtVendorEmail').focus();
                validateEmail++;
            }

            ret = false;
        }

        if (ValidateDtls() == false || ValidateChrgDtls() == false || ValidateAttchmntDtls() == false) {
            ret = false;
        }

        document.getElementById("<%=txtPOMobile.ClientID%>").style.borderColor = "";
        document.getElementById("<%=ddlDocumntWrkflw.ClientID%>").style.borderColor = "";
        document.getElementById("<%=txtVendorMobile.ClientID%>").style.borderColor = "";
        document.getElementById("<%=ddlVendor.ClientID%>").style.borderColor = "";
        document.getElementById("<%=txtWarehouseDelivery.ClientID%>").style.borderColor = "";
        document.getElementById("<%=ddlWarehouse.ClientID%>").style.borderColor = "";
        document.getElementById("<%=ddlModeofSupply.ClientID%>").style.borderColor = "";
        document.getElementById("<%=ddlPODivision.ClientID%>").style.borderColor = "";
        document.getElementById("<%=txtPrchsOrdrDate.ClientID%>").style.borderColor = "";
        document.getElementById("<%=txtPrchsOrdrRef.ClientID%>").style.borderColor = "";
        $("#divddlDocumntWrkflw> input").css("borderColor", "");
        $("#divddlVendor> input").css("borderColor", "");
        document.getElementById("<%=ddlWarehouse.ClientID%>").style.borderColor = "";
        $("#divddlWarehouse> input").css("borderColor", "");
        $("#divddlPODivision> input").css("borderColor", "");
        document.getElementById("<%=txtVendorAddress.ClientID%>").style.borderColor = "";

        var VendorAddress = document.getElementById("<%=txtVendorAddress.ClientID%>").value.trim();
        var POMobile = document.getElementById("<%=txtPOMobile.ClientID%>").value.trim();
        var Wrkflow = document.getElementById("<%=ddlDocumntWrkflw.ClientID%>").value;
        var VendorMobile = document.getElementById("<%=txtVendorMobile.ClientID%>").value.trim();
        var Vendor = document.getElementById("<%=ddlVendor.ClientID%>").value;
        var Warehs = document.getElementById("<%=ddlWarehouse.ClientID%>").value;
        var DelvrLoctnWrhs = document.getElementById("<%=txtWarehouseDelivery.ClientID%>").value.trim();
        var ModeOfSupply = document.getElementById("<%=ddlModeofSupply.ClientID%>").value.trim();
        var Division = document.getElementById("<%=ddlPODivision.ClientID%>").value;
        var Date = document.getElementById("<%=txtPrchsOrdrDate.ClientID%>").value.trim();
        var Ref = document.getElementById("<%=txtPrchsOrdrRef.ClientID%>").value.trim();

        if (POMobile == "") {
            document.getElementById("<%=txtPOMobile.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtPOMobile.ClientID%>").focus();
            ret = false;
        }
        if (Wrkflow == "" || Wrkflow == "--SELECT DOCUMENT WORKFLOW--") {
            document.getElementById("<%=ddlDocumntWrkflw.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=ddlDocumntWrkflw.ClientID%>").focus();
            $("#divddlDocumntWrkflw> input").css("borderColor", "Red");
            $("#divddlDocumntWrkflw> input").select();
            ret = false;
        }
        if (document.getElementById("<%=hiddenF9Mode.ClientID%>").value == "0") {
            if (document.getElementById("<%=cbxFuture.ClientID%>").checked == true) {
                if (VendorAddress == "") {
                    document.getElementById("<%=txtVendorAddress.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtVendorAddress.ClientID%>").focus();
                    ret = false;
                }
            }
        }

        if (VendorMobile == "") {
            document.getElementById("<%=txtVendorMobile.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtVendorMobile.ClientID%>").focus();
            ret = false;
        }
        if (Vendor == "" || Vendor == "--SELECT VENDOR--") {
            $("#divddlVendor> input").css("borderColor", "Red");
            $("#divddlVendor> input").select();
            ret = false;
        }
        if (document.getElementById("<%=radioWarehouse.ClientID%>").checked == true) {
            if (DelvrLoctnWrhs == "") {
                document.getElementById("<%=txtWarehouseDelivery.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtWarehouseDelivery.ClientID%>").focus();
                ret = false;
            }
            if (Warehs == "" || Warehs == "--SELECT WAREHOUSE--") {
                document.getElementById("<%=ddlWarehouse.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlWarehouse.ClientID%>").focus();
                $("#divddlWarehouse> input").css("borderColor", "Red");
                $("#divddlWarehouse> input").select();
                ret = false;
            }
        }
        if (document.getElementById("<%=radioProjct.ClientID%>").checked == true) {
        
        }
        if (ModeOfSupply == "" || ModeOfSupply == "--SELECT MODE OF SUPPLY--") {
            document.getElementById("<%=ddlModeofSupply.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=ddlModeofSupply.ClientID%>").focus();
            ret = false;
        }
        if (Division == "" || Division == "--SELECT DIVISION--") {
            $("#divddlPODivision> input").css("borderColor", "Red");
            $("#divddlPODivision> input").select();
            ret = false;
        }
        if (Date == "") {
            document.getElementById("<%=txtPrchsOrdrDate.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtPrchsOrdrDate.ClientID%>").focus();
            ret = false;
        }
        if (Ref == "") {
            document.getElementById("<%=txtPrchsOrdrRef.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtPrchsOrdrRef.ClientID%>").focus();
            ret = false;
        }

        if (ret == false) {

            if (parseInt(validateMobile) > 0 || parseInt(validateEmail) > 0) {

                if (parseInt(validateMobile) > 0) {
                    $("#danger-alert").html("Please enter a valid mobile number");
                    $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
                    });
                }
                if (parseInt(validateEmail) > 0) {
                    $("#danger-alert").html("Please enter a valid email-id");
                    $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
                    });
                }
            }
            else {
                $("#danger-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
            }
        }
        else {

        }

        return ret;
    }

    function SuccessInsertion() {
        $("#success-alert").html("Purchase order inserted successfully.");
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }

    function SuccessUpdation() {
        $("#success-alert").html("Purchase order updated successfully.");
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }

    function SuccessConfirmation() {
        $("#success-alert").html("Purchase order confirmed successfully.");
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }

    function SuccessReopen() {
        $("#success-alert").html("Purchase order reopened successfully.");
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }

    function AlreadyReopened() {
        $("#danger-alert").html("Sorry, this purchase order is already reopened!");
        $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function AlreadyConfirmed() {
        $("#danger-alert").html("Sorry, this purchase order is already confirmed!");
        $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function AlreadyDeleted() {
        $("#danger-alert").html("Sorry, this purchase order is already deleted!");
        $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }

    function ConfirmAlert() {
        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to confirm this purchase order?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {
                document.getElementById("<%=btnConfirmClick.ClientID%>").click();
            }
        });
        return false;
    }

    function ReopenAlert() {
        //alert();
        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to reopen this purchase order?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {
                document.getElementById("<%=btnReopenClick.ClientID%>").click();
            }
        });
        return false;
    }

</script>

<script>
    //CHANGE DDL

    function LoadVendors(Mode, event) {

        if (event != null) {
            if (isTagEnter(event) == false) {
                return false;
            }
        }

        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var OrgId = '<%=Session["ORGID"]%>';

        $noCon('#cphMain_ddlVendor').autocomplete({
            source: function (request, response) {

                $.ajax({
                    async: false,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "pms_Purchase_Order.aspx/LoadVendors",
                    data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",strText:"' + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + '"}',
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
                document.getElementById("<%=hiddenVendorId.ClientID%>").value = i.item.val;
                document.getElementById("<%=ddlVendor.ClientID%>").value = i.item.label;
            },
            change: function (event, ui) {
                if (ui.item) {
                    document.getElementById("<%=tdVendorName.ClientID%>").value = document.getElementById("<%=ddlVendor.ClientID%>").value;
                    document.getElementById("<%=btnSupp.ClientID%>").click();
                    AutoCompleteAll("4");
                }
                else {
                    document.getElementById("<%=ddlVendor.ClientID%>").value = document.getElementById("<%=tdVendorName.ClientID%>").value;
                }
            }
        });
    }

    function ValidateEmail(obj) {
        var ret = true;

        $noCon('#' + obj + '').css("borderColor", "");

        var Email = document.getElementById(obj).value;
        var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

        if (Email != "" && Email != undefined) {
            if (!filter.test(Email)) {
                $("#danger-alert").html("Please enter a valid email id");
                $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
                });
                $noCon('#' + obj + '').css("borderColor", "red");
                ret = false;
            }
        }
        //RemoveTag(obj);

        return ret;
    }

    function ValidateMobile(obj) {
        var ret = true;

        $noCon('#' + obj + '').css("borderColor", "");

        var Mobile = $('#' + obj).val();
        var mobileregular = /^(\+\d{1,3}[- ]?)?\d{10}$/;
        if (Mobile != "" && Mobile != undefined) {
            if (!mobileregular.test(Mobile)) {
                $("#danger-alert").html("Please enter a valid mobile number");
                $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
                });
                $noCon('#' + obj + '').css("borderColor", "red");
                ret = false;
            }
        }
        //RemoveNaN_OnBlur('cphMain_txtVendorMobile');
        //RemoveNaN_OnBlur('cphMain_txtPOMobile');

        return ret;
    }

    function F9Click(evt, Mode) {

        var ret = true;

        if (isTagEnter(evt) == false) {
            ret = false;
        }

        evt = (evt) ? evt : window.event;
        var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
        var charCode = (evt.which) ? evt.which : evt.keyCode;

        if (keyCodes == 120) {// both F9 AND 'x' has same code in keypress

            if (Mode == 0) {//ddl
                document.getElementById("<%=ddlVendorContact.ClientID%>").style.display = "none";
                document.getElementById("<%=txtVendorContact.ClientID%>").style.display = "block";
                document.getElementById("<%=cbxFuture.ClientID%>").disabled = false;
                document.getElementById("<%=txtVendorContact.ClientID%>").focus();
                ret = false;
            }
            else if (Mode == 1) {//text
                document.getElementById("<%=ddlVendorContact.ClientID%>").style.display = "block";
                document.getElementById("<%=txtVendorContact.ClientID%>").style.display = "none";
                document.getElementById("<%=cbxFuture.ClientID%>").checked = false;
                document.getElementById("<%=cbxFuture.ClientID%>").disabled = true;
                document.getElementById("<%=ddlVendorContact.ClientID%>").focus();
                ret = false;
            }

            document.getElementById("<%=hiddenF9Mode.ClientID%>").value = Mode;
        }
        //alert(Mode);

        return ret;
    }

</script>

<script>

    //DYNAMIC ADD ROWS

    //--------------------Products--------------------

    var CountProducts = 0;

    function AddMoreRowsProducts(Mode) {

        if (Mode == "0") {
            $("#tableProducts").empty();
            $("#tableVehicles").empty();
            $("#tableAirTickt").empty();
        }
        else {
            CountProducts++;
        }

        var RecRow = '';

        RecRow += '<tr id="trRowId_' + CountProducts + '" >';
        RecRow += '<td id="tdId' + CountProducts + '" style="display: none;">' + CountProducts + '</td>';
        RecRow += '<td id="tdSLNo' + CountProducts + '">' + (CountProducts + 1) + '</td>';
        RecRow += '<td>';
        RecRow += '<div class="input-group in_flw">';
        RecRow += '<div id="divProduct_' + CountProducts + '"><input id="ddlProducts' + CountProducts + '" type="text" name="ddlProducts' + CountProducts + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" autocomplete="off" placeholder="-Select-" maxlength="150"  onkeypress="return LoadProducts(' + CountProducts + ',\'ddlProducts\',event);" onkeydown="return LoadProducts(' + CountProducts + ',\'ddlProducts\',event);" onkeyup="IncrmntConfrmCounter()" /></div>';
        RecRow += '<a id="btnAddProduct' + CountProducts + '" href="javascript:;" onclick="OpenProduct(' + CountProducts + ');" title="Add New Product" class="input-group-addon cur1 spn1_pro gren spn_pro1" >';
        RecRow += '<i class="fa fa-plus-circle"></i>';
        RecRow += '</a>';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtQnty' + CountProducts + '" type="text" name="txtQnty' + CountProducts + '" class="form-control fg2_inp2 inp_mst tr_c" maxlength="3" onkeypress=\"return isNumberAmount(event,\'txtQnty' + CountProducts + '\')\" onkeydown=\"return isNumberAmount(event,\'txtQnty' + CountProducts + '\')\" onblur="BlurValue(' + CountProducts + ')">';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtPrice' + CountProducts + '" type="text" name="txtPrice' + CountProducts + '" class="form-control fg2_inp2 tr_r" maxlength="8" onkeypress=\"return isNumberAmount(event,\'txtPrice' + CountProducts + '\')\" onkeydown=\"return isNumberAmount(event,\'txtPrice' + CountProducts + '\')\" onblur="BlurValue(' + CountProducts + ')">';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<div class="input-group ing1">';
        RecRow += '<input id="txtDiscntPrcnt' + CountProducts + '" type="text" name="txtDiscntPrcnt' + CountProducts + '" class="form-control fg2_inp2 tr_r inp1_pro clsDiscnt" maxlength="5" onkeypress=\"return isNumberAmount(event,\'txtDiscntPrcnt' + CountProducts + '\')\" onkeydown=\"return isNumberAmount(event,\'txtDiscntPrcnt' + CountProducts + '\')\" onblur="return BlurValue(' + CountProducts + ')">';
        RecRow += '<span class="input-group-addon cur1 spn1_pro pur_pe">%</span>';
        RecRow += '</div>';
        RecRow += '<div class="input-group ing2">';
        RecRow += '<input id="txtDiscntAmnt' + CountProducts + '" type="text" name="txtDiscntAmnt' + CountProducts + '" class="form-control fg2_inp2 tr_r inp1_pro clsDiscnt" maxlength="10" onkeypress=\"return isNumberAmount(event,\'txtDiscntAmnt' + CountProducts + '\')\" onkeydown=\"return isNumberAmount(event,\'txtDiscntAmnt' + CountProducts + '\')\" onblur="BlurValue(' + CountProducts + ')">';

        var CrncyAbrv = document.getElementById("<%=hiddenDefaultCrncyAbrvtn.ClientID%>").value;
        if (document.getElementById("<%=ddlCurrency.ClientID%>").value != document.getElementById("<%=hiddenDefaultCurrencyId.ClientID%>").value) {
            CrncyAbrv = document.getElementById("<%=hiddenExchngCrncyAbrvtn.ClientID%>").value;
        }

        RecRow += '<span class="input-group-addon cur1 spn1_pro pur_at clsCrncy">' + CrncyAbrv + '</span>';
        RecRow += '</div>';
        RecRow += '</td>';

        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "1") {
            RecRow += '<td id="tdTax">';
        }
        else {
            RecRow += '<td id="tdTax" style="display:none;">';
        }
        RecRow += '<input id="txtTax' + CountProducts + '" type="text" name="txtTax' + CountProducts + '" class="form-control fg2_inp2 tr_l inp_3_1" disabled>';
        RecRow += '<div class="input-group ing1 inp_3_2">';
        RecRow += '<input id="txtTaxPrcnt' + CountProducts + '" type="text" name="txtTaxPrcnt' + CountProducts + '" class="form-control fg2_inp2 tr_r inp1_pro" maxlength="10" disabled>';
        RecRow += '<span class="input-group-addon cur1 spn1_pro pur_pe">%</span>';
        RecRow += '</div>';
        RecRow += '<div class="input-group ing2 inp_3_3">';
        RecRow += '<input id="txtTaxAmnt' + CountProducts + '" type="text" name="txtTaxAmnt' + CountProducts + '" class="form-control fg2_inp2 tr_r inp1_pro" maxlength="10" disabled>';
        RecRow += '<span class="input-group-addon cur1 spn1_pro pur_at clsCrncy">' + CrncyAbrv + '</span>';
        RecRow += '</div>';
        RecRow += '</td>';

        RecRow += '<td>';
        RecRow += '<input id="txtTotalAmnt' + CountProducts + '" type="text" name="txtTotalAmnt' + CountProducts + '" class="form-control fg2_inp2 tr_r" maxlength="10" value="0" disabled >';
        RecRow += '</td>';
        RecRow += '<td class="td1">';
        RecRow += '<div class="btn_stl1">';
        //RecRow += '<button id="btnRemark' + CountProducts + '" class="btn act_btn bn9" title="Remarks" data-toggle="modal" data-target="#exampleModalre"><i class="fa fa-commenting"></i></button>';
        RecRow += '<button id="btnAdd' + CountProducts + '" class="btn act_btn bn2" title="Add" onclick="return CheckaddMoreRows(' + CountProducts + ');"><i class="fa fa-plus-circle"></i></button>';
        RecRow += '<button id="btnDelete' + CountProducts + '" class="btn act_btn bn3" title="Delete" onclick="return RemoveRows(' + CountProducts + ');"><i class="fa fa-trash"></i></button>';
        RecRow += '</div>';
        RecRow += '</td>';
        RecRow += '<td style="display: none;"><input id="tdProductId' + CountProducts + '" name="tdProductId' + CountProducts + '" value="-Select-"></td>';
        RecRow += '<td style="display: none;"><input id="tdProductName' + CountProducts + '" name="tdProductName' + CountProducts + '" ></td>';
        RecRow += '<td style="display: none;"><input id="tdTaxId' + CountProducts + '" name="tdTaxId' + CountProducts + '" ></td>';
        RecRow += '<td style="display: none;"><input id="tdEmpId' + CountProducts + '" name="tdEmpId' + CountProducts + '" value="-Select-"></td>';
        RecRow += '<td style="display: none;"><input id="tdEmpName' + CountProducts + '" name="tdEmpName' + CountProducts + '" ></td>';
        RecRow += '<td id="tdEvt' + CountProducts + '" style="width:0%;display: none;">INS</td>';
        RecRow += '<td id="tdDtlId' + CountProducts + '" style="width:0%;display: none;">0</td>';
        RecRow += '</tr>';

        $("#tableProducts").append(RecRow);

        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "0") {
            document.getElementById("thTax").style.display = "none";
            //document.getElementById("tdTax").style.display = "none";
        }
        document.getElementById("txtQnty" + CountProducts).disabled = true;
        document.getElementById("txtPrice" + CountProducts).disabled = true;
        document.getElementById("txtDiscntPrcnt" + CountProducts).disabled = true;
        document.getElementById("txtDiscntAmnt" + CountProducts).disabled = true;
    }

    var CountVehicles = 0;

    function AddMoreRowsVehicles(Mode) {

        if (Mode == "0") {
            $("#tableProducts").empty();
            $("#tableVehicles").empty();
            $("#tableAirTickt").empty();
        }
        else {
            CountVehicles++;
        }

        var RecRow = '';

        RecRow += '<tr id="trRowId_' + CountVehicles + '" >';
        RecRow += '<td id="tdId' + CountVehicles + '" style="display: none;">' + CountVehicles + '</td>';
        RecRow += '<td id="tdSLNo' + CountVehicles + '">' + (CountVehicles + 1) + '</td>';
        RecRow += '<td>';
        RecRow += '<div class="input-group in_flw">';
        RecRow += '<div id="divVehicle_' + CountVehicles + '"><input id="ddlVehicle' + CountVehicles + '" name="ddlVehicle' + CountVehicles + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw inp_pro2" autocomplete="off" placeholder="-Select-" maxlength="100"  onkeypress="return LoadProducts(' + CountVehicles + ',\'ddlVehicle\',event);" onkeydown="return LoadProducts(' + CountVehicles + ',\'ddlVehicle\',event);" onkeyup="IncrmntConfrmCounter()"></div>';
        RecRow += '<a id="btnAddVehicle' + CountProducts + '" href="javascript:;" onclick="OpenProduct(' + CountProducts + ');" title="Add New Vehicle" class="input-group-addon cur1 spn1_pro gren spn_pro1">';
        RecRow += '<i class="fa fa-plus-circle"></i>';
        RecRow += '</a>';
        RecRow += '</div>';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<div id="datepickerStrtDt' + CountVehicles + '" class="input-group date" data-date-format="dd-mm-yyyy">';
        RecRow += '<input id="txtStrtDate' + CountVehicles + '" type="text" name="txtStrtDate' + CountVehicles + '" class="form-control inp_bdr inp_pro1 pa_l1 pa_r1" maxlength="10" onchange="ChangeDates(' + CountVehicles + ');" />';
        RecRow += '<span id="spanStrtDate' + CountVehicles + '" class="input-group-addon date1 dt_pro1"><i class="fa fa-calendar"></i></span>';
        RecRow += '</div>';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<div id="datepickerEndDt' + CountVehicles + '" class="input-group date" data-date-format="dd-mm-yyyy">';
        RecRow += '<input id="txtEndDate' + CountVehicles + '" type="text" name="txtEndDate' + CountVehicles + '" class="form-control inp_bdr inp_pro1 pa_l1 pa_r1" maxlength="10" onchange="ChangeDates(' + CountVehicles + ');" />';
        RecRow += '<span id="spanEndDate' + CountVehicles + '" class="input-group-addon date1 dt_pro1"><i class="fa fa-calendar"></i></span>';
        RecRow += '</div>';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="ddlEmployee' + CountVehicles + '" name="ddlEmployee' + CountVehicles + '" class="form-control fg2_inp2 fg_chs1 pa_n" autocomplete="off" placeholder="-Select-" maxlength="500"  onkeypress="return LoadEmployees(2, ' + CountVehicles + ',\'ddlEmployee\',event);" onkeydown="return LoadEmployees(2, ' + CountVehicles + ',\'ddlEmployee\',event);" onkeyup="IncrmntConfrmCounter()">';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtEmpCode' + CountVehicles + '" name="txtEmpCode' + CountVehicles + '" class="form-control fg2_inp2 fg_chs1 pa_n tr_c" placeholder="ID#" maxlength="500" disabled>';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtEmpDivision' + CountVehicles + '" name="txtEmpDivision' + CountVehicles + '" class="form-control fg2_inp2 fg_chs1 pa_n tr_l pa_l1" placeholder="Division" maxlength="500" disabled>';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtQnty' + CountVehicles + '" name="txtQnty' + CountVehicles + '" class="form-control fg2_inp2 fg_chs1 pa_n tr_c" maxlength="3"  onkeypress=\"return isNumberAmount(event,\'txtQnty' + CountVehicles + '\')\" onkeydown=\"return isNumberAmount(event,\'txtQnty' + CountVehicles + '\')\" onblur="BlurValue(' + CountVehicles + ')">';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtPrice' + CountVehicles + '" name="txtPrice' + CountVehicles + '" class="form-control fg2_inp2 fg_chs1 pa_n tr_r pa_r1" maxlength="8"  onkeypress=\"return isNumberAmount(event,\'txtPrice' + CountVehicles + '\')\" onkeydown=\"return isNumberAmount(event,\'txtPrice' + CountVehicles + '\')\" onblur="BlurValue(' + CountVehicles + ')" value="0">';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtTotalAmnt' + CountVehicles + '" name="txtTotalAmnt' + CountVehicles + '" class="form-control fg2_inp2 fg_chs1 pa_n tr_r pa_r1" maxlength="10" disabled>';
        RecRow += '</td>';
        RecRow += '<td class="td1">';
        RecRow += '<div class="btn_stl1">';
        //RecRow += '<button id="btnRemark' + CountVehicles + '" class="btn act_btn bn9" title="Remarks" data-toggle="modal" data-target="#exampleModalre"><i class="fa fa-commenting"></i></button>';
        RecRow += '<button id="btnAdd' + CountVehicles + '" class="btn act_btn bn2" title="Add" onclick="return CheckaddMoreRows(' + CountVehicles + ');"><i class="fa fa-plus-circle"></i></button>';
        RecRow += '<button id="btnDelete' + CountVehicles + '" class="btn act_btn bn3" title="Delete" onclick="return RemoveRows(' + CountVehicles + ');"><i class="fa fa-trash"></i></button>';
        RecRow += '</div>';
        RecRow += '</td>';
        RecRow += '<td style="display: none;"><input id="tdProductId' + CountVehicles + '" name="tdProductId' + CountVehicles + '" value="-Select-"></td>';
        RecRow += '<td style="display: none;"><input id="tdProductName' + CountVehicles + '" name="tdProductName' + CountVehicles + '" ></td>';
        RecRow += '<td style="display: none;"><input id="tdTaxId' + CountVehicles + '" name="tdTaxId' + CountVehicles + '" ></td>';
        RecRow += '<td style="display: none;"><input id="tdEmpId' + CountVehicles + '" name="tdEmpId' + CountVehicles + '" value="-Select-"></td>';
        RecRow += '<td style="display: none;"><input id="tdEmpName' + CountVehicles + '" name="tdEmpName' + CountVehicles + '" ></td>';
        RecRow += '<td id="tdEvt' + CountVehicles + '" style="width:0%;display: none;">INS</td>';
        RecRow += '<td id="tdDtlId' + CountVehicles + '" style="width:0%;display: none;">0</td>';
        RecRow += '</tr>';

        $("#tableVehicles").append(RecRow);

        $noCon('#datepickerStrtDt' + CountVehicles).datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            timepicker: false
        });
        $noCon('#datepickerEndDt' + CountVehicles).datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            timepicker: false
        });

        document.getElementById("txtQnty" + CountVehicles).disabled = true;
        document.getElementById("txtPrice" + CountVehicles).disabled = true;

    }

    var CountAirTckt = 0;

    function AddMoreRowsAirTckt(Mode) {

        if (Mode == "0") {
            $("#tableProducts").empty();
            $("#tableVehicles").empty();
            $("#tableAirTickt").empty();
        }
        else {
            CountAirTckt++;
        }

        var RecRow = '';
        RecRow += '<tr id="trRowId_' + CountAirTckt + '" >';
        RecRow += '<td id="tdId' + CountAirTckt + '" style="display: none;">' + CountAirTckt + '</td>';
        RecRow += '<td id="tdSLNo' + CountAirTckt + '">' + (CountAirTckt + 1) + '</td>';
        RecRow += '<td>';
        RecRow += '<div class="input-group in_flw">';
        RecRow += '<div id="divFlight_' + CountProducts + '"><input id="ddlFlight' + CountAirTckt + '" name="ddlFlight' + CountAirTckt + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw inp_pro2" autocomplete="off" maxlength="100" onblur="BlurValue(' + CountAirTckt + ');" onkeyup="IncrmntConfrmCounter()" /></div>';
        RecRow += '</span>';
        RecRow += '</div>';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<textarea id="txtSector' + CountAirTckt + '" name="txtSector' + CountAirTckt + '" class="form-control fg2_inp2 fg_chs1 pa_n pa_l1" maxlength="100" rows="1" style="resize:none;" onkeydown="textCounter(txtSector' + CountAirTckt + ',100)" onkeyup="textCounter(txtSector' + CountAirTckt + ',100)" onblur="textCounter(txtSector' + CountAirTckt + ',100)"></textarea>';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<div id="datepickerTravelDt' + CountAirTckt + '" class="input-group date" data-date-format="mm-dd-yyyy">';
        RecRow += '<input id="txtTravelDt' + CountAirTckt + '" type="text" name="txtTravelDt' + CountAirTckt + '" class="form-control inp_bdr inp_pro1 pa_l1 pa_r1" data-dateformat="dd-mm-yyyy" maxlength="10" />';
        RecRow += '<span id="spanTravelDt' + CountAirTckt + '" class="input-group-addon date1 dt_pro1"><i class="fa fa-calendar"></i></span>';
        RecRow += '</div>';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="ddlEmployee' + CountAirTckt + '" name="ddlEmployee' + CountAirTckt + '" class="form-control fg2_inp2 fg_chs1 pa_n" autocomplete="off" placeholder="-Select-" maxlength="500"  onkeypress="return LoadEmployees(3, ' + CountAirTckt + ',\'ddlEmployee\',event);" onkeydown="return LoadEmployees(3, ' + CountAirTckt + ',\'ddlEmployee\',event);" onkeyup="IncrmntConfrmCounter()">';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtEmpCode' + CountAirTckt + '" name="txtEmpCode' + CountAirTckt + '" class="form-control fg2_inp2 fg_chs1 pa_n tr_c" placeholder="ID#" maxlength="500" disabled>';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtEmpDivision' + CountAirTckt + '" name="txtEmpDivision' + CountAirTckt + '" class="form-control fg2_inp2 fg_chs1 pa_n tr_l pa_l1" placeholder="Division" maxlength="500" disabled>';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtQnty' + CountAirTckt + '" name="txtQnty' + CountAirTckt + '" class="form-control fg2_inp2 fg_chs1 pa_n tr_c" maxlength="3"  onkeypress=\"return isNumberAmount(event,\'txtQnty' + CountAirTckt + '\')\" onkeydown=\"return isNumberAmount(event,\'txtQnty' + CountAirTckt + '\')\" onblur="BlurValue(' + CountAirTckt + ')">';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtPrice' + CountAirTckt + '" name="txtPrice' + CountAirTckt + '" class="form-control fg2_inp2 fg_chs1 pa_n tr_r pa_r1" maxlength="8"  onkeypress=\"return isNumberAmount(event,\'txtPrice' + CountAirTckt + '\')\" onkeydown=\"return isNumberAmount(event,\'txtPrice' + CountAirTckt + '\')\" onblur="BlurValue(' + CountAirTckt + ')" value="0">';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtTotalAmnt' + CountAirTckt + '" name="txtTotalAmnt' + CountAirTckt + '" class="form-control fg2_inp2 fg_chs1 pa_n tr_r pa_r1" maxlength="10" disabled>';
        RecRow += '</td>';
        RecRow += '<td class="td1">';
        RecRow += '<div class="btn_stl1">';
        //RecRow += '<button id="btnRemark' + CountAirTckt + '" class="btn act_btn bn9" title="Remarks" data-toggle="modal" data-target="#exampleModalre"><i class="fa fa-commenting"></i></button>';
        RecRow += '<button id="btnAdd' + CountAirTckt + '" class="btn act_btn bn2" title="Add" onclick="return CheckaddMoreRows(' + CountAirTckt + ');"><i class="fa fa-plus-circle"></i></button>';
        RecRow += '<button id="btnDelete' + CountAirTckt + '" class="btn act_btn bn3" title="Delete" onclick="return RemoveRows(' + CountAirTckt + ');"><i class="fa fa-trash"></i></button>';
        RecRow += '</div>';
        RecRow += '</td>';
        RecRow += '<td style="display: none;"><input id="tdProductId' + CountAirTckt + '" name="tdProductId' + CountAirTckt + '" value="-Select-"></td>';
        RecRow += '<td style="display: none;"><input id="tdProductName' + CountAirTckt + '" name="tdProductName' + CountAirTckt + '" ></td>';
        RecRow += '<td style="display: none;"><input id="tdTaxId' + CountAirTckt + '" name="tdTaxId' + CountAirTckt + '" ></td>';
        RecRow += '<td style="display: none;"><input id="tdEmpId' + CountAirTckt + '" name="tdEmpId' + CountAirTckt + '" value="-Select-"></td>';
        RecRow += '<td style="display: none;"><input id="tdEmpName' + CountAirTckt + '" name="tdEmpName' + CountAirTckt + '"></td>';
        RecRow += '<td id="tdEvt' + CountAirTckt + '" style="width:0%;display: none;">INS</td>';
        RecRow += '<td id="tdDtlId' + CountAirTckt + '" style="width:0%;display: none;">0</td>';
        RecRow += '</tr>';

        $("#tableAirTickt").append(RecRow);

        $noCon('#datepickerTravelDt' + CountAirTckt).datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            //startDate: new Date(),
            timepicker: false
        });

        document.getElementById("txtQnty" + CountAirTckt).disabled = true;
        document.getElementById("txtPrice" + CountAirTckt).disabled = true;
    }


    function EditRows(DTLID, SLNO, QUANTITY, PRICE, TOTALAMNT, PRODUCTID, DISCNTPRCNTG, DISCNTAMNT, TAXID, TAXPRCNTG, VEHICLEID, STRTDATE, ENDDATE, EMPID, FLGHTPNRNO, SECTOR, TRVLDATE, PRODUCTNAME, VEHICLENAME, EMPNAME, TAXNAME, Count) {

        if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") { //Products

            document.getElementById("divProducts").style.display = "block";
            document.getElementById("divVehicle").style.display = "none";
            document.getElementById("divAirTicket").style.display = "none";

            AddMoreRowsProducts(Count);
            CountProducts = Count;

            document.getElementById("tdProductId" + Count).value = PRODUCTID;
            document.getElementById("ddlProducts" + Count).value = PRODUCTNAME;
            document.getElementById("tdProductName" + Count).value = PRODUCTNAME;
            document.getElementById("txtDiscntPrcnt" + Count).value = DISCNTPRCNTG;
            document.getElementById("txtDiscntAmnt" + Count).value = DISCNTAMNT;

            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "1") {
                document.getElementById("tdTaxId" + Count).value = TAXID;
                document.getElementById("txtTaxPrcnt" + Count).value = TAXPRCNTG;
                document.getElementById("txtTax" + Count).value = TAXNAME;
            }

            if ((document.getElementById("<%=hiddenView.ClientID%>").value == "1") || (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value == "0")) {
                document.getElementById("ddlProducts" + Count).disabled = true;
                document.getElementById("txtDiscntPrcnt" + Count).disabled = true;
                document.getElementById("txtDiscntAmnt" + Count).disabled = true;
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "1") {
                    document.getElementById("txtTaxPrcnt" + Count).disabled = true;
                }
                document.getElementById("btnAddProduct" + Count).disabled = true;
                document.getElementById("btnAddProduct" + Count).style.pointerEvents = "none";
            }
            else {
                document.getElementById("divBulkProduct").style.display = "block";
            }
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") { //Vehicles

            document.getElementById("divProducts").style.display = "none";
            document.getElementById("divVehicle").style.display = "block";
            document.getElementById("divAirTicket").style.display = "none";

            AddMoreRowsVehicles(Count);
            CountVehicles = Count;

            document.getElementById("tdProductId" + Count).value = VEHICLEID;
            document.getElementById("ddlVehicle" + Count).value = VEHICLENAME;
            document.getElementById("tdProductName" + Count).value = VEHICLENAME;
            document.getElementById("txtStrtDate" + Count).value = STRTDATE;
            document.getElementById("txtEndDate" + Count).value = ENDDATE;
            document.getElementById("tdEmpId" + Count).value = EMPID;
            document.getElementById("ddlEmployee" + Count).value = EMPNAME;
            document.getElementById("tdEmpName" + Count).value = EMPNAME;

            if ((document.getElementById("<%=hiddenView.ClientID%>").value == "1") || (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value == "0")) {
                document.getElementById("ddlVehicle" + Count).disabled = true;
                document.getElementById("txtStrtDate" + Count).disabled = true;
                document.getElementById("spanStrtDate" + Count).style.pointerEvents = "none";
                document.getElementById("txtEndDate" + Count).disabled = true;
                document.getElementById("spanEndDate" + Count).style.pointerEvents = "none";
                document.getElementById("ddlEmployee" + Count).disabled = true;
                document.getElementById("btnAddVehicle" + Count).disabled = true;
            }
            else {
                document.getElementById("divBulkProduct").style.display = "block";
            }
            LoadEmpDtls(Count);
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") { //AirTickets

            document.getElementById("divProducts").style.display = "none";
            document.getElementById("divVehicle").style.display = "none";
            document.getElementById("divAirTicket").style.display = "block";

            AddMoreRowsAirTckt(Count);
            CountAirTckt = Count;

            document.getElementById("ddlFlight" + Count).value = FLGHTPNRNO;
            document.getElementById("txtSector" + Count).value = SECTOR;
            document.getElementById("txtTravelDt" + Count).value = TRVLDATE;
            document.getElementById("tdEmpId" + Count).value = EMPID;
            document.getElementById("ddlEmployee" + Count).value = EMPNAME;
            document.getElementById("tdEmpName" + Count).value = EMPNAME;

            if ((document.getElementById("<%=hiddenView.ClientID%>").value == "1") || (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value == "0")) {
                document.getElementById("ddlEmployee" + Count).disabled = true;
                document.getElementById("ddlFlight" + Count).disabled = true;
                document.getElementById("txtSector" + Count).disabled = true;
                document.getElementById("txtTravelDt" + Count).disabled = true;
                document.getElementById("spanTravelDt" + Count).style.pointerEvents = "none";
            }

            LoadEmpDtls(Count);
        }

        document.getElementById('tdDtlId' + Count).innerHTML = DTLID;
        document.getElementById("txtQnty" + Count).value = QUANTITY;
        document.getElementById("txtPrice" + Count).value = PRICE;
        document.getElementById("txtTotalAmnt" + Count).value = TOTALAMNT;
        document.getElementById("tdEvt" + Count).innerHTML = "UPD";

        if ((document.getElementById("<%=hiddenView.ClientID%>").value == "1") || (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value == "0")) {
            document.getElementById("txtQnty" + Count).disabled = true;
            document.getElementById("txtPrice" + Count).disabled = true;
            document.getElementById("txtTotalAmnt" + Count).disabled = true;
            document.getElementById("btnAdd" + Count).disabled = true;
            document.getElementById("btnDelete" + Count).disabled = true;
        }

        BlurValue(Count);
    }

    //-----------------------Charge-----------------------

    var CountChrg = 0;

    function AddMoreRowsCharge(Mode) {

        if (Mode != "0") {
            CountChrg++;
        }

        var RecRow = '';

        RecRow += '<tr id="trRowChrgId_' + CountChrg + '" >';
        RecRow += '<td id="tdChrgId' + CountChrg + '" style="display: none;">' + CountChrg + '</td>';
        RecRow += '<td>';
        RecRow += '<input id="ddlChrgHead' + CountChrg + '" type="text" name="ddlChrgHead' + CountChrg + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" placeholder="-Select-" onkeypress="return LoadChargeHeads(' + CountChrg + ',event);" onkeydown="return LoadChargeHeads(' + CountChrg + ',event);" onkeyup="IncrmntConfrmCounter()">';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<input id="txtChrgAmnt' + CountChrg + '" type="text" name="txtChrgAmnt' + CountChrg + '" class="form-control fg2_inp2 tr_r" onblur="CalculateNetAmount();"  onkeypress=\"return isNumberAmount(event,\'txtChrgAmnt' + CountChrg + '\')\" onkeydown=\"return isNumberAmount(event,\'txtChrgAmnt' + CountChrg + '\')\">';
        RecRow += '</td>';
        RecRow += '<td>';
        RecRow += '<div class="btn_stl1">';
        RecRow += '<button id="btnAddChrg' + CountChrg + '" class="btn act_btn bn2" title="Add New" onclick="return CheckaddMoreRowsChrg(' + CountChrg + ');"><i class="fa fa-plus-circle"></i></button>';
        RecRow += '<button id="btnDeleteChrg' + CountChrg + '" class="btn act_btn bn3" title="Delete" onclick="return RemoveRowsChrg(' + CountChrg + ');"><i class="fa fa-trash"></i></button>';
        RecRow += '</div>';
        RecRow += '</td>';
        RecRow += '<td style="display: none;"><input id="tdChrgCalculate' + CountChrg + '" name="tdChrgCalculate' + CountChrg + '" /></td>';
        RecRow += '<td style="display: none;"><input id="tdChrgHdId' + CountChrg + '" name="tdChrgHdId' + CountChrg + '" placeholder="-Select-"></td>';
        RecRow += '<td style="display: none;"><input id="tdChrgHdName' + CountChrg + '" name="tdChrgHdName' + CountChrg + '"></td>';
        RecRow += '<td id="tdEvtChrg' + CountChrg + '" style="width:0%;display: none;">INS</td>';
        RecRow += '<td id="tdDtlIdChrg' + CountChrg + '" style="width:0%;display: none;">0</td>';
        RecRow += '</tr>';

        $("#tableCharge").append(RecRow);

        LoadChargeHeads(CountChrg, null);

        if ((document.getElementById("<%=hiddenView.ClientID%>").value == "1") || (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value == "0")) {
            document.getElementById("ddlChrgHead" + CountChrg).disabled = true;
            document.getElementById("txtChrgAmnt" + CountChrg).disabled = true;
            document.getElementById("btnAddChrg" + CountChrg).disabled = true;
            document.getElementById("btnDeleteChrg" + CountChrg).disabled = true;
        }
    }


    function EditRowsChrg(DTLID, CHRGHDID, CHRGAMNT, CHRGHDNAME, CHRGCALCULATE, Count) {

        AddMoreRowsCharge(Count);
        CountChrg = Count;

        document.getElementById('tdDtlIdChrg' + Count).innerHTML = DTLID;
        document.getElementById("ddlChrgHead" + Count).value = CHRGHDNAME;
        document.getElementById("tdChrgHdName" + Count).value = CHRGHDNAME;
        document.getElementById("tdChrgHdId" + Count).value = CHRGHDID;
        document.getElementById("txtChrgAmnt" + Count).value = CHRGAMNT;
        document.getElementById("tdChrgCalculate" + Count).value = CHRGCALCULATE;
        document.getElementById("tdEvtChrg" + Count).innerHTML = "UPD";

        if ((document.getElementById("<%=hiddenView.ClientID%>").value == "1") || (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value == "0")) {
            document.getElementById("ddlChrgHead" + Count).disabled = true;
            document.getElementById("txtChrgAmnt" + Count).disabled = true;
            document.getElementById("btnAddChrg" + Count).disabled = true;
            document.getElementById("btnDeleteChrg" + Count).disabled = true;
        }
    }

    //-----------------------Attachmnt-----------------------

    function AttachmentAdd() {

        if (document.getElementById("<%=cbxAttachmnt.ClientID%>").checked == true) {
            document.getElementById("tableAttachmnt").style.display = "block";
        }
        else {
            document.getElementById("tableAttachmnt").style.display = "none";
        }
    }

    var CountAttch = 0;

    function AddMoreRowsAttachmnt(Mode) {

        if (Mode != "0") {
            CountAttch++;
        }

        var RecRow = '';

        RecRow += '<tr id="trRowAttchId_' + CountAttch + '" class="col-md-12" >';
        RecRow += '<td id="tdFileId' + CountAttch + '" style="display: none;">' + CountAttch + '</td>';
        RecRow += '<td class="col-md-6 fg2_wf1 po_flt po_mar_bt">';
        RecRow += '<div id="divFileUpload' + CountAttch + '">';
        RecRow += '<label for="fileAttach' + CountAttch + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
        RecRow += '<input id="fileAttach' + CountAttch + '" type="file" name="fileAttach' + CountAttch + '" onchange="ChangeFile(' + CountAttch + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" />';
        RecRow += '</div>';
        RecRow += '<div id="filePath' + CountAttch + '" class="file_n" style="word-break: break-all;">No File Uploaded</div>';
        RecRow += '</td>';
        RecRow += '<td class="col-md-4 fg2_wf1 po_flt po_mar_bt">';
        RecRow += '<textarea id="fileDescrptn' + CountAttch + '" name="fileDescrptn' + CountAttch + '" rows="1" cols="50" class="form-control" placeholder="Description" style="resize:none;" maxlength="450" onkeydown="textCounter(fileDescrptn' + CountAttch + ',450)" onkeyup="textCounter(fileDescrptn' + CountAttch + ',450)" onblur="textCounter(fileDescrptn' + CountAttch + ',450)"></textarea>';
        RecRow += '</td>';
        RecRow += '<td class="col-md-2 fg2_wf1 po_flt po_mar_bt">';
        RecRow += '<button id="btnAddFile' + CountAttch + '" class="btn act_btn bn2" title="Add New" onclick="return CheckaddMoreRowsAttch(' + CountAttch + ');"><i class="fa fa-plus-circle"></i></button>';
        RecRow += '<button id="btnDeleteFile' + CountAttch + '" class="btn act_btn bn3" title="Delete" onclick="return RemoveRowsAttch(' + CountAttch + ');"><i class="fa fa-trash"></i></button>';
        RecRow += '</td>';
        RecRow += '<td id="tdEvtFile' + CountAttch + '" style="width:0%;display: none;">INS</td>';
        RecRow += '<td id="tdDtlIdFile' + CountAttch + '" style="width:0%;display: none;">0</td>';
        RecRow += '<td id="tdActFileName' + CountAttch + '" style="display: none;"></td>';
        RecRow += '</tr>';

        $("#tableAttachmnt").append(RecRow);

        if ((document.getElementById("<%=hiddenView.ClientID%>").value == "1") || (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value == "0")) {
            document.getElementById("btnAddFile" + CountAttch).disabled = true;
            document.getElementById("btnDeleteFile" + CountAttch).disabled = true;
            document.getElementById("fileDescrptn" + CountAttch).disabled = true;
        }
    }

    function EditRowsAttchmnt(DTLID, FILENAME, ACT_FILENAME, DESCRIPTN, Count) {

        AddMoreRowsAttachmnt(Count);
        CountAttch = Count;

        document.getElementById('tdDtlIdFile' + Count).innerHTML = DTLID;
        document.getElementById('filePath' + Count).innerHTML = '<a target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + FILENAME + ' >' + ACT_FILENAME + '</a>';
        document.getElementById("tdActFileName" + Count).innerHTML = ACT_FILENAME;
        document.getElementById("fileDescrptn" + Count).value = DESCRIPTN;
        document.getElementById("tdEvtFile" + Count).innerHTML = "UPD";
        document.getElementById("divFileUpload" + Count).style.display = "none";

        if ((document.getElementById("<%=hiddenView.ClientID%>").value == "1") || (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value == "0")) {
            document.getElementById("btnAddFile" + Count).disabled = true;
            document.getElementById("btnDeleteFile" + Count).disabled = true;
            document.getElementById("fileDescrptn" + Count).disabled = true;
        }
    }

</script>

<script>

    //LOAD DYNAMIC DDL

    function LoadProducts(x, obj, event) {

        if (event != null) {
            if (isTagEnter(event) == false) {
                return false;
            }
        }

        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var OrgId = '<%=Session["ORGID"]%>';
        var ProductMode = document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value;

        $noCon('#' + obj + x).autocomplete({
            source: function (request, response) {

                $.ajax({
                    async: false,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "pms_Purchase_Order.aspx/LoadProducts",
                    data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",ProductMode:"' + ProductMode + '",strText:"' + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + '"}',
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
                document.getElementById("tdProductId" + x).value = i.item.val;
                document.getElementById(obj + x).value = i.item.label;
            },
            change: function (event, ui) {
                if (ui.item) {
                    document.getElementById("tdProductName" + x).value = document.getElementById(obj + x).value;
                    LoadProductTaxDtls(x);
                }
                else {
                    document.getElementById(obj + x).value = document.getElementById("tdProductName" + x).value;
                }
            }
        });
    }

    function LoadEmployees(ProductMode, x, obj, event) {

        if (event != null) {
            if (isTagEnter(event) == false) {
                return false;
            }
        }

        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var OrgId = '<%=Session["ORGID"]%>';

        $noCon('#' + obj + x).autocomplete({
            source: function (request, response) {

                $.ajax({
                    async: false,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "pms_Purchase_Order.aspx/LoadEmployees",
                    data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",ProductMode:"' + ProductMode + '",strText:"' + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + '"}',
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                val: item.split('<>')[0],
                                label: item.split('<>')[1],
                            }
                        }))
                    },
                    failure: function (response) {
                    }
                });
            },
            autoFocus: false,

            select: function (e, i) {
                document.getElementById("tdEmpId" + x).value = i.item.val;
                document.getElementById(obj + x).value = i.item.label;
            },
            change: function (event, ui) {
                if (ui.item) {
                    document.getElementById("tdEmpName" + x).value = document.getElementById(obj + x).value;

                    LoadEmpDtls(x);
                }
                else {
                    document.getElementById(obj + x).value = document.getElementById("tdEmpName" + x).value;
                }
            }
        });
    }

    function LoadEmpDtls(x) {

        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var OrgId = '<%=Session["ORGID"]%>';

        var EmpId = document.getElementById("tdEmpId" + x).value;
        $.ajax({
            async: false,
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: "pms_Purchase_Order.aspx/LoadEmployeeDtls",
            data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",EmpId:"' + EmpId + '"}',
            success: function (response) {
                $("#txtEmpCode" + x).val(response.d[0]);
                $("#txtEmpDivision" + x).val(response.d[1]);
            },
            failure: function (response) {

            }
        });
    }

    function LoadProductTaxDtls(x) {

        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var OrgId = '<%= Session["ORGID"] %>';
        var ProductId = document.getElementById("tdProductId" + x).value;

        $.ajax({
            async: false,
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: "pms_Purchase_Order.aspx/LoadProductTaxDetails",
            data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",ProductId:"' + ProductId + '"}',
            success: function (data) {

                var DecCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                var CrncyModeId = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;
                if (document.getElementById("<%=ddlCurrency.ClientID%>").value != document.getElementById("<%=hiddenDefaultCurrencyId.ClientID%>").value) {
                    CrncyModeId = document.getElementById("<%=hiddenExchngCurrencyModeId.ClientID%>").value;
                }
                var TaxDecCnt = document.getElementById("<%=hiddenTaxDecimalCount.ClientID%>").value;
                var PrcntgDecimalCnt = document.getElementById("<%=hiddenPercntgDecimalCount.ClientID%>").value;
                var Zero = 0;

                document.getElementById("txtQnty" + x).disabled = false;
                document.getElementById("txtPrice" + x).disabled = false;

                document.getElementById("txtQnty" + x).value = 1;
                document.getElementById("txtPrice" + x).value = Zero.toFixed(DecCnt);

                if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {

                    var ProductAmnt = data.d[0];
                    document.getElementById("txtPrice" + x).value = addCommasReturn(ProductAmnt, CrncyModeId);

                    if ((document.getElementById("<%=hiddenView.ClientID%>").value == "1") || (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value == "0")) {
                        document.getElementById("txtDiscntPrcnt" + x).disabled = true;
                        document.getElementById("txtDiscntAmnt" + x).disabled = true;
                    }
                    else {
                        document.getElementById("txtDiscntPrcnt" + x).disabled = false;
                        document.getElementById("txtDiscntAmnt" + x).disabled = false;
                    }

                    document.getElementById("txtDiscntPrcnt" + x).value = Zero.toFixed(DecCnt);
                    document.getElementById("txtDiscntAmnt" + x).value = Zero.toFixed(PrcntgDecimalCnt);

                    var TaxPrcnt = 0;
                    var TaxAmnt = 0;
                    if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "1") {

                        document.getElementById("tdTaxId" + x).value = data.d[4];
                        document.getElementById("txtTax" + x).value = data.d[1];
                        if (data.d[2] != "" && data.d[2] != null) {
                            TaxPrcnt = data.d[2];
                        }
                        document.getElementById("txtTaxPrcnt" + x).value = BlurAmountReturn(TaxPrcnt, PrcntgDecimalCnt);
                        if (data.d[3] != "" && data.d[3] != null) {
                            TaxAmnt = data.d[3];
                        }
                        document.getElementById("txtTaxAmnt" + x).value = addCommasReturn(BlurAmountReturn(TaxAmnt, TaxDecCnt), CrncyModeId);
                    }
                }

                BlurValue(x);

            },
            failure: function (response) {

            }
        });

    }

    function LoadChargeHeads(x, event) {

        if (event != null) {
            if (isTagEnter(event) == false) {
                return false;
            }
        }

        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var OrgId = '<%=Session["ORGID"]%>';
        var ChrgHdId = "";
        //document.getElementById("txtChrgAmnt" + x).value = "";
        CalculateNetAmount();

        $noCon('#ddlChrgHead' + x).autocomplete({
            source: function (request, response) {

                $.ajax({
                    async: false,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "pms_Purchase_Order.aspx/LoadChargeHeads",
                    data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",ChrgHdId:"' + ChrgHdId + '"}',
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
                document.getElementById('ddlChrgHead' + x).value = i.item.label;
                document.getElementById('tdChrgHdId' + x).value = i.item.val;
            },
            change: function (event, ui) {

                if (ui.item) {
                    document.getElementById("tdChrgHdName" + x).value = document.getElementById("ddlChrgHead" + x).value;
                    ChrgHdId = document.getElementById('tdChrgHdId' + x).value;

                    $.ajax({
                        async: false,
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        url: "pms_Purchase_Order.aspx/LoadChargeHeads",
                        data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",ChrgHdId:"' + ChrgHdId + '"}',
                        success: function (data) {
                            document.getElementById("tdChrgCalculate" + x).value = data.d[0];
                        }
                    });

                }
                else {
                    document.getElementById(obj + x).value = document.getElementById("tdChrgHdName" + x).value;
                }
            }
        });
    }


</script>

<script>
    //DYNAMIC FUNCTIONS

    //--------------------Products--------------------

    function BlurValue(x) {

        var DecCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
        var CrncyModeId = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;
        if (document.getElementById("<%=ddlCurrency.ClientID%>").value != document.getElementById("<%=hiddenDefaultCurrencyId.ClientID%>").value) {
            CrncyModeId = document.getElementById("<%=hiddenExchngCurrencyModeId.ClientID%>").value;
        }
        var TaxDecCnt = document.getElementById("<%=hiddenTaxDecimalCount.ClientID%>").value;
        var PrcntgDecimalCnt = document.getElementById("<%=hiddenPercntgDecimalCount.ClientID%>").value;
        var Zero = 0;

        if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
            obj = "ddlProducts";
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
            obj = "ddlVehicle";
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
            obj = "ddlFlight";
        }

        if (document.getElementById(obj + x).value != "") {

            if ((document.getElementById("<%=hiddenView.ClientID%>").value == "1") || (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value == "0")) {
                document.getElementById("txtQnty" + x).disabled = true;
                document.getElementById("txtPrice" + x).disabled = true;
                document.getElementById("txtDiscntPrcnt" + x).disabled = true;
                document.getElementById("txtDiscntAmnt" + x).disabled = true;
            }
            else {
                document.getElementById("txtQnty" + x).disabled = false;
                document.getElementById("txtPrice" + x).disabled = false;
            }

            var Qnty = 1;
            if (document.getElementById("txtQnty" + x).value != "") {
                Qnty = document.getElementById("txtQnty" + x).value.replace(/\,/g, '');
            }
            var ProductAmnt = 0;
            if (document.getElementById("txtPrice" + x).value != "") {
                ProductAmnt = document.getElementById("txtPrice" + x).value.replace(/\,/g, '');
            }

            var DiscntPrcnt = 0, DiscntAmnt = 0, TaxPrcnt = 0, TaxAmnt = 0;

            if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {

                DiscntPrcnt = document.getElementById("txtDiscntPrcnt" + x).value.replace(/\,/g, '');
                if (DiscntPrcnt == "") {
                    document.getElementById("txtDiscntPrcnt" + x).value = Zero;
                    document.getElementById("txtDiscntAmnt" + x).value = Zero.toFixed(DecCnt);
                }
                else {
                    DiscntAmnt = (parseFloat(ProductAmnt) * parseFloat(DiscntPrcnt)) / 100;
                }

                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "1") {
                    if (document.getElementById("txtTax" + x).value != "" && document.getElementById("txtTax" + x).value != null) {
                        TaxPrcnt = document.getElementById("txtTaxPrcnt" + x).value.replace(/\,/g, '');
                    }
                    if (document.getElementById("txtTax" + x).value != "" && document.getElementById("txtTax" + x).value != null) {
                        TaxAmnt = (parseFloat(ProductAmnt) * parseFloat(TaxPrcnt)) / 100;
                    }

                    document.getElementById("txtTaxPrcnt" + x).value = BlurAmountReturn(TaxPrcnt, PrcntgDecimalCnt);
                    document.getElementById("txtTaxAmnt" + x).value = addCommasReturn(BlurAmountReturn(TaxAmnt, TaxDecCnt), CrncyModeId);
                }

                document.getElementById("txtDiscntPrcnt" + x).value = BlurAmountReturn(DiscntPrcnt, PrcntgDecimalCnt);
                document.getElementById("txtDiscntAmnt" + x).value = addCommasReturn(BlurAmountReturn(DiscntAmnt, DecCnt), CrncyModeId);


            }

            if (Qnty % 1 != 0) {
                document.getElementById("txtQnty" + x).value = addCommasReturn(BlurAmountReturn(Qnty, DecCnt), CrncyModeId);
            }
            else {
                document.getElementById("txtQnty" + x).value = addCommasReturn(Qnty, CrncyModeId);
            }
            document.getElementById("txtPrice" + x).value = addCommasReturn(BlurAmountReturn(ProductAmnt, DecCnt), CrncyModeId);

            var TotalAmnt = 0;
            TotalAmnt = (parseFloat(ProductAmnt) + parseFloat(TaxAmnt) - parseFloat(DiscntAmnt)) * parseFloat(Qnty);
            document.getElementById("txtTotalAmnt" + x).value = addCommasReturn(BlurAmountReturn(TotalAmnt, DecCnt), CrncyModeId);

        }

        CalculateNetAmount();
    }

    function CalculateNetAmount() {

        var DecCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
        var CrncyModeId = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;
        if (document.getElementById("<%=ddlCurrency.ClientID%>").value != document.getElementById("<%=hiddenDefaultCurrencyId.ClientID%>").value) {
            CrncyModeId = document.getElementById("<%=hiddenExchngCurrencyModeId.ClientID%>").value;
        }
        var TaxDecCnt = document.getElementById("<%=hiddenTaxDecimalCount.ClientID%>").value;
        var PrcntgDecimalCnt = document.getElementById("<%=hiddenPercntgDecimalCount.ClientID%>").value;

        var Table = "";
        if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
            Table = document.getElementById("tableProducts");
            obj = "ddlProducts";
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
            Table = document.getElementById("tableVehicles");
            obj = "ddlVehicle";
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
            Table = document.getElementById("tableAirTickt");
            obj = "ddlFlight";
        }

        var GrossTotal = 0, DiscntTotal = 0, TaxTotal = 0, NetTotal = 0;

        for (var i = 0; i < Table.rows.length; i++) {
            var x = (Table.rows[i].cells[0].innerHTML);
            if (document.getElementById(obj + x).value != "") {
                if (document.getElementById("txtTotalAmnt" + x).value != "") {

                    var TotalAmnt = document.getElementById("txtTotalAmnt" + x).value.replace(/\,/g, '');
                    GrossTotal += parseFloat(TotalAmnt);

                    if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {

                        var DiscntAmnt = document.getElementById("txtDiscntAmnt" + x).value.replace(/\,/g, '');
                        DiscntTotal += parseFloat(DiscntAmnt);

                        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "1") {
                            var TaxAmnt = document.getElementById("txtTaxAmnt" + x).value.replace(/\,/g, '');
                            TaxTotal += parseFloat(TaxAmnt);
                        }
                    }

                }
            }
        }

        var CrncyAbrv = document.getElementById("<%=hiddenDefaultCrncyAbrvtn.ClientID%>").value;
        if (document.getElementById("<%=ddlCurrency.ClientID%>").value != document.getElementById("<%=hiddenDefaultCurrencyId.ClientID%>").value) {
            CrncyAbrv = document.getElementById("<%=hiddenExchngCrncyAbrvtn.ClientID%>").value;
        }

        document.getElementById("<%=txtGrossTotal.ClientID%>").value = addCommasReturn(BlurAmountReturn(GrossTotal, DecCnt), CrncyModeId) + " " + CrncyAbrv;
        document.getElementById("<%=txtTaxTotal.ClientID%>").value = addCommasReturn(BlurAmountReturn(TaxTotal, TaxDecCnt).toString(), CrncyModeId) + " " + CrncyAbrv;

        if (DiscntTotal != 0) {  //Dynamic discnt
            document.getElementById("<%=txtDiscntTotal.ClientID%>").disabled = true;
            $(".clsDiscnt").prop('disabled', false);
        }
        else {
            if (document.getElementById("<%=hiddenView.ClientID%>").value != "1") {
                document.getElementById("<%=txtDiscntTotal.ClientID%>").disabled = false;
            }
            if (document.getElementById("<%=tdDiscntTotal.ClientID%>").value != "0") {
                $(".clsDiscnt").prop('disabled', true);
                if (document.getElementById("<%=tdDiscntTotal.ClientID%>").value != "") {
                    DiscntTotal = parseFloat(document.getElementById("<%=tdDiscntTotal.ClientID%>").value);
                }
            }
            else {
                if (document.getElementById("<%=hiddenView.ClientID%>").value != "1") {
                    $(".clsDiscnt").prop('disabled', false);
                    document.getElementById("<%=txtDiscntTotal.ClientID%>").disabled = false;
                }
            }
        }

        if ((document.getElementById("<%=hiddenView.ClientID%>").value == "1") || (document.getElementById("<%=hiddenApprvaCnslMode.ClientID%>").value == "0")) {
            $(".clsDiscnt").prop('disabled', true);
        }

        document.getElementById("<%=txtDiscntTotal.ClientID%>").value = addCommasReturn(BlurAmountReturn(DiscntTotal, DecCnt).toString(), CrncyModeId) + " " + CrncyAbrv;

        NetTotal = parseFloat(GrossTotal) + parseFloat(TaxTotal) - parseFloat(DiscntTotal);


        var TotalChrgAmount = 0;
        var ChrgTable = document.getElementById("tableCharge");
        for (var i = 0; i < ChrgTable.rows.length; i++) {
            var validRow = (ChrgTable.rows[i].cells[0].innerHTML);
            var ChrgAmnt = document.getElementById("txtChrgAmnt" + validRow).value;
            var ChrgCalculate = document.getElementById("tdChrgCalculate" + validRow).value;
            if (ChrgAmnt != "") {
                if (ChrgCalculate == "0") {
                    TotalChrgAmount += parseFloat(TotalChrgAmount) + parseFloat(ChrgAmnt);
                }
                else if (ChrgCalculate == "1") {
                    TotalChrgAmount += parseFloat(TotalChrgAmount) - parseFloat(ChrgAmnt);
                }
                document.getElementById("txtChrgAmnt" + validRow).value = addCommasReturn(BlurAmountReturn(ChrgAmnt, DecCnt), CrncyModeId);
            }
        }
        NetTotal = parseFloat(NetTotal) + parseFloat(TotalChrgAmount);


        document.getElementById("<%=txtNetTotal.ClientID%>").value = addCommasReturn(BlurAmountReturn(NetTotal, DecCnt), CrncyModeId) + " " + CrncyAbrv;

        var ExchngRate = 1;
        if (document.getElementById("<%=ddlCurrency.ClientID%>").value == document.getElementById("<%=hiddenDefaultCurrencyId.ClientID%>").value) {
            document.getElementById("divExchngTotal").style.display = "none";
        }
        else {
            document.getElementById("divExchngTotal").style.display = "block";
            RemoveNaN_OnBlur('cphMain_txtExchgRate');
            if (document.getElementById("<%=txtExchgRate.ClientID%>").value != "") {
                ExchngRate = document.getElementById("<%=txtExchgRate.ClientID%>").value.replace(/\,/g, '');
            }
        }
        NetTotal = parseFloat(NetTotal) * parseFloat(ExchngRate);

        document.getElementById("<%=spanExchngTotal.ClientID%>").innerHTML = "Amount in " + document.getElementById("<%=hiddenDefaultCrncyAbrvtn.ClientID%>").value + ": " + addCommasReturn(BlurAmountReturn(NetTotal, DecCnt), CrncyModeId);

        document.getElementById("<%=hiddenNetAmnt.ClientID%>").value = NetTotal;
    }

    function CheckaddMoreRows(x) {

        if (CheckAndHighlight(x, 1, "") == true) {

            var idlast = "", focusobj = "";
            if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
                AddMoreRowsProducts(1);
                idlast = $('#tableProducts tr:last').attr('id');
                focusobj = "ddlProducts";
            }
            else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
                AddMoreRowsVehicles(1);
                idlast = $('#tableVehicles tr:last').attr('id');
                focusobj = "ddlVehicle";
            }
            else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
                AddMoreRowsAirTckt(1);
                idlast = $('#tableAirTickt tr:last').attr('id');
                focusobj = "ddlFlight";
            }
            var LastId = "";
            if (idlast != "") {
                var res = idlast.split("_");
                LastId = res[1];
            }
            document.getElementById(focusobj + LastId).focus();
            document.getElementById("btnAdd" + x).disabled = true;
            return false;
        }
        else {
            return false;
        }

        return false;
    }

    function CheckAndHighlight(x, Mode, obj) {

        var ret = true;

        document.getElementById("txtQnty" + x).style.borderColor = "";
        document.getElementById("txtPrice" + x).style.borderColor = "";
        document.getElementById("txtTotalAmnt" + x).style.borderColor = "";

        if (Mode == "0") {

            if ((obj == "txtPrice" + x) && (document.getElementById("txtPrice" + x).value.trim() == "")) {
                document.getElementById("txtPrice" + x).style.borderColor = "Red";
                ret = false;
            }
            if ((obj == "txtQnty" + x) && (document.getElementById("txtQnty" + x).value.trim() == "")) {
                document.getElementById("txtQnty" + x).style.borderColor = "Red";
                ret = false;
            }

            if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
                //Products
                document.getElementById("ddlProducts" + x).style.borderColor = "";

                if ((obj == "ddlProducts" + x) && (document.getElementById("ddlProducts" + x).value.trim() == "")) {
                    document.getElementById("ddlProducts" + x).style.borderColor = "Red";
                    ret = false;
                }
            }
            else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
                //Vehicles
                document.getElementById("ddlVehicle" + x).style.borderColor = "";
                document.getElementById("txtStrtDate" + x).style.borderColor = "";
                document.getElementById("txtEndDate" + x).style.borderColor = "";
                document.getElementById("ddlEmployee" + x).style.borderColor = "";

                if ((obj == "ddlEmployee" + x) && (document.getElementById("ddlEmployee" + x).value.trim() == "")) {
                    document.getElementById("ddlEmployee" + x).style.borderColor = "Red";
                    ret = false;
                }
                if ((obj == "txtEndDate" + x) && (document.getElementById("txtEndDate" + x).value.trim() == "")) {
                    document.getElementById("txtEndDate" + x).style.borderColor = "Red";
                    ret = false;
                }
                if ((obj == "txtStrtDate" + x) && (document.getElementById("txtStrtDate" + x).value.trim() == "")) {
                    document.getElementById("txtStrtDate" + x).style.borderColor = "Red";
                    ret = false;
                }
                if ((obj == "ddlVehicle" + x) && (document.getElementById("ddlVehicle" + x).value.trim() == "")) {
                    document.getElementById("ddlVehicle" + x).style.borderColor = "Red";
                    ret = false;
                }
            }
            else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
                //AirTickets
                document.getElementById("ddlFlight" + x).style.borderColor = "";
                document.getElementById("txtSector" + x).style.borderColor = "";
                document.getElementById("txtTravelDt" + x).style.borderColor = "";
                document.getElementById("ddlEmployee" + x).style.borderColor = "";

                if ((obj == "ddlEmployee" + x) && (document.getElementById("ddlEmployee" + x).value.trim() == "")) {
                    document.getElementById("ddlEmployee" + x).style.borderColor = "Red";
                    ret = false;
                }
                if ((obj == "txtTravelDt" + x) && (document.getElementById("txtTravelDt" + x).value.trim() == "")) {
                    document.getElementById("txtTravelDt" + x).style.borderColor = "Red";
                    ret = false;
                }
                if ((obj == "txtSector" + x) && (document.getElementById("txtSector" + x).value.trim() == "")) {
                    document.getElementById("txtSector" + x).style.borderColor = "Red";
                    ret = false;
                }
                if ((obj == "ddlFlight" + x) && (document.getElementById("ddlFlight" + x).value.trim() == "")) {
                    document.getElementById("ddlFlight" + x).style.borderColor = "Red";
                    ret = false;
                }

            }

        }
        else {
            var DecCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var Zero = 0;
            Zero = Zero.toFixed(DecCnt);

            if (document.getElementById("txtPrice" + x).value.trim() != "" && (document.getElementById("txtPrice" + x).value.trim() == "0" || document.getElementById("txtPrice" + x).value.trim() == Zero)) {
                document.getElementById("txtPrice" + x).style.borderColor = "Red";
                document.getElementById("txtPrice" + x).focus();
                ret = false;
            }

            if (document.getElementById("txtPrice" + x).value.trim() == "") {
                document.getElementById("txtPrice" + x).style.borderColor = "Red";
                document.getElementById("txtPrice" + x).focus();
                ret = false;
            }
            if (document.getElementById("txtQnty" + x).value.trim() == "") {
                document.getElementById("txtQnty" + x).style.borderColor = "Red";
                document.getElementById("txtQnty" + x).focus();
                ret = false;
            }

            if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
                //Products
                document.getElementById("ddlProducts" + x).style.borderColor = "";

                if (document.getElementById("ddlProducts" + x).value.trim() == "") {
                    document.getElementById("ddlProducts" + x).style.borderColor = "Red";
                    document.getElementById("ddlProducts" + x).focus();
                    ret = false;
                }
            }
            else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
                //Vehicles
                document.getElementById("ddlVehicle" + x).style.borderColor = "";
                document.getElementById("txtStrtDate" + x).style.borderColor = "";
                document.getElementById("txtEndDate" + x).style.borderColor = "";
                document.getElementById("ddlEmployee" + x).style.borderColor = "";

                if (document.getElementById("ddlEmployee" + x).value.trim() == "") {
                    document.getElementById("ddlEmployee" + x).style.borderColor = "Red";
                    document.getElementById("ddlEmployee" + x).focus();
                    ret = false;
                }
                if (document.getElementById("txtEndDate" + x).value.trim() == "") {
                    document.getElementById("txtEndDate" + x).style.borderColor = "Red";
                    document.getElementById("txtEndDate" + x).focus();
                    ret = false;
                }
                if (document.getElementById("txtStrtDate" + x).value.trim() == "") {
                    document.getElementById("txtStrtDate" + x).style.borderColor = "Red";
                    document.getElementById("txtStrtDate" + x).focus();
                    ret = false;
                }
                if (document.getElementById("ddlVehicle" + x).value.trim() == "") {
                    document.getElementById("ddlVehicle" + x).style.borderColor = "Red";
                    document.getElementById("ddlVehicle" + x).focus();
                    ret = false;
                }
            }
            else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
                //AirTickets
                document.getElementById("ddlFlight" + x).style.borderColor = "";
                document.getElementById("txtSector" + x).style.borderColor = "";
                document.getElementById("txtTravelDt" + x).style.borderColor = "";
                document.getElementById("ddlEmployee" + x).style.borderColor = "";

                if (document.getElementById("ddlEmployee" + x).value.trim() == "") {
                    document.getElementById("ddlEmployee" + x).style.borderColor = "Red";
                    document.getElementById("ddlEmployee" + x).focus();
                    ret = false;
                }
                if (document.getElementById("txtTravelDt" + x).value.trim() == "") {
                    document.getElementById("txtTravelDt" + x).style.borderColor = "Red";
                    document.getElementById("txtTravelDt" + x).focus();
                    ret = false;
                }
                if (document.getElementById("txtSector" + x).value.trim() == "") {
                    document.getElementById("txtSector" + x).style.borderColor = "Red";
                    document.getElementById("txtSector" + x).focus();
                    ret = false;
                }
                if (document.getElementById("ddlFlight" + x).value.trim() == "") {
                    document.getElementById("ddlFlight" + x).style.borderColor = "Red";
                    document.getElementById("ddlFlight" + x).focus();
                    ret = false;
                }

            }
        }
        var Flag = 0;
        if (ret == true) {

            if (ChangeDates(x) == false) {
                Flag++;
                document.getElementById("txtStrtDate" + x).style.borderColor = "Red";
                document.getElementById("txtEndDate" + x).style.borderColor = "Red";
                ret = false;
            }

            if (CheckProductDuplication(x) == false) {
                Flag++;
                ret = false;
            }
        }

        if (ret == false && Flag == 0) {
            $("#danger-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            ret = false;
        }

        return ret;
    }

    function CheckProductDuplication(x) {

        var ret = true;
        var Table = "";
        if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
            Table = document.getElementById("tableProducts");
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
            Table = document.getElementById("tableVehicles");
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
            Table = document.getElementById("tableAirTickt");
        }

        for (var i = 0; i < Table.rows.length; i++) {
            var xLoop = (Table.rows[i].cells[0].innerHTML);
            var xLoopId = "";
            var Id = "";
            if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
                xLoopId = $("#tdProductId" + xLoop).val();
                Id = $("#tdProductId" + x).val();
                if (xLoop != x) {
                    if (xLoopId == Id) {
                        $noCon("#danger-alert").html("Products should not be duplicated.");
                        $noCon("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                        });
                        $noCon("#ddlProducts" + x).css("borderColor", "red");
                        $noCon("#ddlProducts" + x).select();
                        $noCon(window).scrollTop(0);
                        return false;
                    }
                }
            }
            else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
                xLoopId = $("#tdProductId" + xLoop).val();
                Id = $("#tdProductId" + x).val();
                xLoopEmpId = $("#tdEmpId" + xLoop).val();
                EmpId = $("#tdEmpId" + x).val();
                if (xLoop != x) {
                    if (xLoopId == Id && xLoopEmpId == EmpId) {
                        $noCon("#danger-alert").html("Vehicles should not be duplicated.");
                        $noCon("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                        });
                        $noCon("#ddlEmployee" + x).css("borderColor", "red");
                        $noCon("#ddlVehicle" + x).css("borderColor", "red");
                        $noCon("#ddlVehicle" + x).select();
                        $noCon(window).scrollTop(0);
                        return false;
                    }
                }
            }
            else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
                xLoopId = $("#ddlFlight" + xLoop).val();
                Id = $("#ddlFlight" + x).val();
                xLoopEmpId = $("#ddlEmployee" + xLoop).val();
                EmpId = $("#ddlEmployee" + x).val();
                if (xLoop != x) {
                    if (xLoopId == Id && xLoopEmpId == EmpId) {
                        $noCon("#danger-alert").html("Air tickets should not be duplicated.");
                        $noCon("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                        });
                        $noCon("ddlEmployee" + x).css("borderColor", "red");
                        $noCon("ddlFlight" + x).css("borderColor", "red");
                        $noCon("ddlFlight" + x).focus();
                        $noCon(window).scrollTop(0);
                        return false;
                    }
                }
            }
        }
        return ret;
    }

    function RemoveRows(x) {

        var Msg = "";
        if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
            Msg = "Are you sure you want to cancel selected product details?";
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
            Msg = "Are you sure you want to cancel selected vehicle details?";
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
            Msg = "Are you sure you want to cancel selected air ticket details?";
        }

        ezBSAlert({
            type: "confirm",
            messageText: Msg,
            alertType: "info"
        }).done(function (e) {
            if (e == true) {

                var evt = document.getElementById("tdEvt" + x).innerHTML;

                document.getElementById("<%=hiddenCnclDtlIds.ClientID%>").value = "";
                if (evt == "UPD") {
                    var detailId = document.getElementById("tdDtlId" + x).innerHTML;

                    var CanclIds = document.getElementById("<%=hiddenCnclDtlIds.ClientID%>").value;
                    if (CanclIds == '') {
                        document.getElementById("<%=hiddenCnclDtlIds.ClientID%>").value = detailId;
                    }
                    else {
                        document.getElementById("<%=hiddenCnclDtlIds.ClientID%>").value = document.getElementById("<%=hiddenCnclDtlIds.ClientID%>").value + ',' + detailId;
                    }
                }
                jQuery('#trRowId_' + x).remove();

                var idlast = "";
                if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
                    idlast = $('#tableProducts tr:last').attr('id');
                }
                else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
                    idlast = $('#tableVehicles tr:last').attr('id');
                }
                else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
                    idlast = $('#tableAirTickt tr:last').attr('id');
                }
                if (idlast != undefined) {
                    var LastId = "";
                    if (idlast != "") {
                        var res = idlast.split("_");
                        LastId = res[1];
                    }
                    document.getElementById("btnAdd" + LastId).disabled = false;
                }

                var Table = "";
                if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
                    Table = document.getElementById("tableProducts");
                }
                else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
                    Table = document.getElementById("tableVehicles");
                }
                else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
                    Table = document.getElementById("tableAirTickt");
                }

                if (Table.rows.length < 1) {
                    if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
                        AddMoreRowsProducts(0);
                    }
                    else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
                        AddMoreRowsVehicles(0);
                    }
                    else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
                        AddMoreRowsAirTckt(0);
                    }
                }
            }
            else {
                return false;
            }
        });
        return false;
    }

    function ValidateDtls() {

        var ret = true;
        var flag = 0;

        document.getElementById("<%=hiddenPurchsOrdrDtls.ClientID%>").value = "";

        var Table = "";
        if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
            Table = document.getElementById("tableProducts");
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
            Table = document.getElementById("tableVehicles");
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
            Table = document.getElementById("tableAirTickt");
        }

        for (var x = 0; x < Table.rows.length; x++) {

            if (Table.rows[x].cells[0].innerHTML != "") {

                var validRowID = (Table.rows[x].cells[0].innerHTML);

                if (Table.rows.length > 0) {
                    if (CheckAndHighlight(validRowID, 1, "") == false) {
                        ret = false;
                    }
                    flag = 1;
                }

            }
        }

        if (ret == true) {

            var tbClientTotalValues = '';
            tbClientTotalValues = [];

            for (var x = 0; x < Table.rows.length; x++) {

                if (Table.rows[x].cells[0].innerHTML != "") {

                    var validRowID = (Table.rows[x].cells[0].innerHTML);

                    var Price = document.getElementById("txtPrice" + validRowID).value.trim();
                    var Qnty = document.getElementById("txtQnty" + validRowID).value.trim();
                    var TotalAmnt = document.getElementById("txtTotalAmnt" + validRowID).value.trim();

                    var ProductId = "", DiscntPrcntg = "", DiscntAmnt = "", TaxId = "", TaxPrcntg = "", TaxAmnt = "", EmpId = "", StrtDate = "", EndDate = "", VehicleId = "", FlightPNRno = "", Sector = "", TrvlDate = "";
                    if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
                        ProductId = document.getElementById("tdProductId" + validRowID).value;
                        DiscntPrcntg = document.getElementById("txtDiscntPrcnt" + validRowID).value.trim();
                        DiscntAmnt = document.getElementById("txtDiscntAmnt" + validRowID).value.trim();

                        if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "1") {
                            TaxId = document.getElementById("tdTaxId" + validRowID).value;
                            TaxPrcntg = document.getElementById("txtTaxPrcnt" + validRowID).value.trim();
                            TaxAmnt = document.getElementById("txtTaxAmnt" + validRowID).value.trim();
                        }
                    }
                    else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
                        VehicleId = document.getElementById("tdProductId" + validRowID).value;
                        StrtDate = document.getElementById("txtStrtDate" + validRowID).value.trim();
                        EndDate = document.getElementById("txtEndDate" + validRowID).value.trim();
                        EmpId = document.getElementById("tdEmpId" + validRowID).value;
                    }
                    else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "3") {
                        FlightPNRno = document.getElementById("ddlFlight" + validRowID).value.trim();
                        Sector = document.getElementById("txtSector" + validRowID).value.trim();
                        TrvlDate = document.getElementById("txtTravelDt" + validRowID).value.trim();
                        EmpId = document.getElementById("tdEmpId" + validRowID).value.trim();
                    }
                    var SlNo = parseFloat(validRowID) + 1;
                    var Evt = document.getElementById("tdEvt" + validRowID).innerHTML;
                    var DetailId = document.getElementById("tdDtlId" + validRowID).innerHTML;


                    var client = JSON.stringify({
                        ROWID: "" + validRowID + "",
                        SLNO: "" + SlNo + "",
                        QUANTITY: "" + Qnty + "",
                        PRICE: "" + Price + "",
                        TOTALAMNT: "" + TotalAmnt + "",
                        PRODUCTID: "" + ProductId + "",
                        DISCNTPRCNTG: "" + DiscntPrcntg + "",
                        DISCNTAMNT: "" + DiscntAmnt + "",
                        TAXID: "" + TaxId + "",
                        TAXPRCNTG: "" + TaxPrcntg + "",
                        VEHICLEID: "" + VehicleId + "",
                        STRTDATE: "" + StrtDate + "",
                        ENDDATE: "" + EndDate + "",
                        EMPID: "" + EmpId + "",
                        FLGHTPNRNO: "" + FlightPNRno + "",
                        SECTOR: "" + Sector + "",
                        TRVLDATE: "" + TrvlDate + "",
                        EVTACTION: "" + Evt + "",
                        DTLID: "" + DetailId + "",
                    });
                    tbClientTotalValues.push(client);

                }
            }

            document.getElementById("<%=hiddenPurchsOrdrDtls.ClientID%>").value = JSON.stringify(tbClientTotalValues);
        }

        return ret;
    }


    function ChangeDates(x) {

        var ret = true;

        if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {

            var FrmDate = document.getElementById("txtStrtDate" + x).value.trim();
            var ToDate = document.getElementById("txtEndDate" + x).value.trim();

            if (FrmDate != "" && ToDate != "") {

                var datepickerDate = document.getElementById("txtStrtDate" + x).value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateFrmDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var datepickerDate = document.getElementById("txtEndDate" + x).value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateToDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                document.getElementById("txtStrtDate" + x).style.borderColor = "";
                document.getElementById("txtEndDate" + x).style.borderColor = "";

                if (dateFrmDt > dateToDt) {
                    $noCon("#divWarning").html("Sorry, From date should not be greater than To date !");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    ret = false;
                }
            }

        }

        return ret;
    }

    //-----------------------Charge-----------------------

    function CheckaddMoreRowsChrg(x) {

        if (CheckAndHighlightChrg(x, 1, "") == true) {

            AddMoreRowsCharge(1);
            var idlast = $('#tableCharge tr:last').attr('id');
            var LastId = "";
            if (idlast != "") {
                var res = idlast.split("_");
                LastId = res[1];
            }
            document.getElementById("ddlChrgHead" + LastId).focus();
            document.getElementById("btnAddChrg" + x).disabled = true;
            return false;
        }
        else {
            return false;
        }

        return false;
    }

    function CheckAndHighlightChrg(x, Mode, obj) {

        var ret = true;

        var Table = document.getElementById("tableCharge");

        document.getElementById("ddlChrgHead" + x).style.borderColor = "";
        document.getElementById("txtChrgAmnt" + x).style.borderColor = "";

        if (Mode == "0") {

            if ((obj == "txtChrgAmnt" + x) && (document.getElementById("txtChrgAmnt" + x).value.trim() == "")) {
                document.getElementById("txtChrgAmnt" + x).style.borderColor = "Red";
                ret = false;
            }
            if ((obj == "ddlChrgHead" + x) && (document.getElementById("ddlChrgHead" + x).value.trim() == "")) {
                document.getElementById("ddlChrgHead" + x).style.borderColor = "Red";
                ret = false;
            }
        }
        else {
            if (document.getElementById("txtChrgAmnt" + x).value.trim() == "") {
                document.getElementById("txtChrgAmnt" + x).style.borderColor = "Red";
                document.getElementById("txtChrgAmnt" + x).focus();
                ret = false;
            }
            if (document.getElementById("ddlChrgHead" + x).value.trim() == "") {
                document.getElementById("ddlChrgHead" + x).style.borderColor = "Red";
                document.getElementById("ddlChrgHead" + x).focus();
                ret = false;
            }
        }
        var Flag = 0;
        if (ret == true) {
            if (CheckChrgDuplication(x) == false) {
                Flag++;
                ret = false;
            }
        }

        if (ret == false && Flag == 0) {
            $("#danger-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            ret = false;
        }

        return ret;
    }

    function CheckChrgDuplication(x) {

        var ret = true;
        var Table = document.getElementById("tableCharge");
        
        for (var i = 0; i < Table.rows.length; i++) {
            var xLoop = (Table.rows[i].cells[0].innerHTML);
            var xLoopId = "";
            var Id = "";
            xLoopId = $("#ddlChrgHead" + xLoop).val();
            Id = $("#ddlChrgHead" + x).val();
            if (xLoop != x) {
                if (xLoopId == Id) {
                    $noCon("#danger-alert").html("Charge heads should not be duplicated.");
                    $noCon("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon("#ddlChrgHead" + x).css("borderColor", "red");
                    $noCon("#ddlChrgHead" + x).select();
                    $noCon(window).scrollTop(0);
                    return false;
                }
            }
        }
        return ret;
    }

    function RemoveRowsChrg(x) {

        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to cancel selected charge details?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {

                jQuery('#trRowChrgId_' + x).remove();

                CalculateNetAmount();

                var idlast = $('#tableCharge tr:last').attr('id');

                if (idlast != undefined) {
                    var LastId = "";
                    if (idlast != "") {
                        var res = idlast.split("_");
                        LastId = res[1];
                    }
                    document.getElementById("btnAddChrg" + LastId).disabled = false;
                }

                var Table = document.getElementById("tableCharge");
                if (Table.rows.length < 1) {
                    AddMoreRowsCharge(0);
                }
            }
            else {
                return false;
            }
        });
        return false;
    }

    function ValidateChrgDtls() {

        var ret = true;
        var flag = 0;

        var Table = document.getElementById("tableCharge");

        for (var x = 0; x < Table.rows.length; x++) {

            if (Table.rows[x].cells[0].innerHTML != "") {

                var validRowID = (Table.rows[x].cells[0].innerHTML);

                var ChrgHd = document.getElementById("ddlChrgHead" + validRowID).value.trim();
                var ChrgAmnt = document.getElementById("txtChrgAmnt" + validRowID).value.trim();

                if ((Table.rows.length > 1) || (Table.rows.length == 1 && (ChrgHd != "" || ChrgAmnt != ""))) {
                    if (CheckAndHighlightChrg(validRowID, 1, "") == false) {
                        ret = false;
                    }
                    flag = 1;
                }

            }
        }

        if (ret == true) {

            document.getElementById("<%=hiddenChrgDtls.ClientID%>").value = "";

            var tbClientTotalValues = '';
            tbClientTotalValues = [];

            for (var x = 0; x < Table.rows.length; x++) {

                if (Table.rows[x].cells[0].innerHTML != "") {

                    var validRowID = (Table.rows[x].cells[0].innerHTML);

                    var ChrgHeadId = document.getElementById("tdChrgHdId" + validRowID).value.trim();
                    var ChrgAmnt = document.getElementById("txtChrgAmnt" + validRowID).value.trim();
                    var Evt = document.getElementById("tdEvtChrg" + validRowID).innerHTML;
                    var DetailId = document.getElementById("tdDtlIdChrg" + validRowID).innerHTML;

                    if (ChrgHeadId != "") {
                        var client = JSON.stringify({
                            ROWID: "" + validRowID + "",
                            CHRGHDID: "" + ChrgHeadId + "",
                            CHRGAMNT: "" + ChrgAmnt + "",
                            EVTACTION: "" + Evt + "",
                            DTLID: "" + DetailId + "",
                        });
                        tbClientTotalValues.push(client);
                    }

                }
            }

            document.getElementById("<%=hiddenChrgDtls.ClientID%>").value = JSON.stringify(tbClientTotalValues);
        }

        return ret;
    }


    //-----------------------Attachmnt-----------------------

    function ChangeFile(x) {

        if (CheckFileExtension(x)) {

            IncrmntConfrmCounter();

            if (document.getElementById('fileAttach' + x).value != "") {
                document.getElementById('filePath' + x).innerHTML = document.getElementById('fileAttach' + x).value;
            }
            else {
                document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';
            }
        }
    }

    function CheckFileExtension(x) {

        var fileData = document.getElementById('fileAttach' + x);
        var FileUploaded = fileData.value;

        var Extension = FileUploaded.substring(FileUploaded.lastIndexOf('.') + 1).toLowerCase();
        if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                    || Extension == "jpeg" || Extension == "jpg" || Extension == "xlsx" || Extension == "xls" || Extension == "doc" ||
            Extension == "docx" || Extension == "csv" || Extension == "ppt" || Extension == "pptx"
           || Extension == "txt" || Extension == "pdf") {
            return true;
        }
        else {
            document.getElementById('fileAttach' + x).value = "";
            document.getElementById('filePath' + x).innerHTML = 'No File Selected';
            $noCon("#danger-alert").html("The specified file type could not be uploaded.Only support image files and document files.");
            $noCon("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
    }

    function CheckaddMoreRowsAttch(x) {

        if (CheckAndHighlightFileUploaded(x) == true) {
            AddMoreRowsAttachmnt(1);
            var idlast = $('#tableAttachmnt tr:last').attr('id');
            var LastId = "";
            if (idlast != "") {
                var res = idlast.split("_");
                LastId = res[1];
            }
            document.getElementById("fileAttach" + LastId).focus();
            document.getElementById("btnAddFile" + x).disabled = true;
        }
        return false;
    }

    function CheckAndHighlightFileUploaded(x) {

        var evt = document.getElementById("tdEvtFile" + x).innerHTML;
        if (evt == 'INS') {
            if (document.getElementById('fileAttach' + x).value != "") {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            var FilePath = "";
            if (document.getElementById("filePath" + x).innerHTML != "") {
                FilePath = document.getElementById("filePath" + x).innerHTML;
            }
            if (FilePath != "") {
                return true;
            }
            else {
                return false;
            }
        }
    }

    function RemoveRowsAttch(x) {

        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to cancel selected attachment?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {

                var evt = document.getElementById("tdEvtFile" + x).innerHTML;

                document.getElementById("<%=hiddenAttchCnclDtlIds.ClientID%>").value = "";
                if (evt == "UPD") {
                    var detailId = document.getElementById("tdDtlIdFile" + x).innerHTML;

                    var CanclIds = document.getElementById("<%=hiddenAttchCnclDtlIds.ClientID%>").value;
                    if (CanclIds == '') {
                        document.getElementById("<%=hiddenAttchCnclDtlIds.ClientID%>").value = detailId;
                    }
                    else {
                        document.getElementById("<%=hiddenAttchCnclDtlIds.ClientID%>").value = document.getElementById("<%=hiddenAttchCnclDtlIds.ClientID%>").value + ',' + detailId;
                    }
                }

                jQuery('#trRowAttchId_' + x).remove();

                var idlast = $('#tableAttachmnt tr:last').attr('id');

                if (idlast != undefined) {
                    var LastId = "";
                    if (idlast != "") {
                        var res = idlast.split("_");
                        LastId = res[1];
                    }
                    document.getElementById("btnAddFile" + LastId).disabled = false;
                }

                var Table = document.getElementById("tableAttachmnt");
                if (Table.rows.length < 1) {
                    AddMoreRowsAttachmnt(0);
                }
            }
            else {
                return false;
            }
        });
        return false;
    }

    function ValidateAttchmntDtls() {

        var ret = true;

        var tbClientTotalValues = '';
        tbClientTotalValues = [];

        document.getElementById("<%=hiddenAttchmntDtls.ClientID%>").value = "";

        var Table = document.getElementById("tableAttachmnt");

        for (var x = 0; x < Table.rows.length; x++) {

            if (Table.rows[x].cells[0].innerHTML != "") {

                var validRowID = (Table.rows[x].cells[0].innerHTML);

                var Evt = document.getElementById("tdEvtFile" + validRowID).innerHTML;
                var FilePath = "";
                if (Evt == "INS") {
                    FilePath = document.getElementById("filePath" + validRowID).innerHTML;
                }
                else {
                    FilePath = document.getElementById("tdActFileName" + validRowID).innerHTML;
                }
                var Descrptn = document.getElementById("fileDescrptn" + validRowID).value;

                var DetailId = document.getElementById("tdDtlIdFile" + validRowID).innerHTML;

                if (FilePath != "" && FilePath != "No File Uploaded") {
                    var client = JSON.stringify({
                        ROWID: "" + validRowID + "",
                        FILENAME: "" + FilePath + "",
                        DESCRPTN: "" + Descrptn + "",
                        EVTACTION: "" + Evt + "",
                        DTLID: "" + DetailId + "",
                    });
                    tbClientTotalValues.push(client);
                }

            }
        }

        document.getElementById("<%=hiddenAttchmntDtls.ClientID%>").value = JSON.stringify(tbClientTotalValues);

        return ret;
    }



</script>

<script>
    //Add Project

    function OpenProject() {
        if (document.getElementById("<%=hiddenView.ClientID%>").value != "1") {

            if (document.getElementById("<%=ddlPODivision.ClientID%>").value != "--SELECT DIVISION--" && document.getElementById("<%=ddlPODivision.ClientID%>").value != "") {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to add new project?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var Division = document.getElementById("<%=ddlPODivision.ClientID%>").value;
                        var nWindow = window.open('/Master/gen_Projects/gen_Projects.aspx?DivId=' + Division + '&PRCHS=RFG', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                        nWindow.focus();
                    } else {
                        return false;
                    }
                });
            }
            else {
                $noCon("#danger-alert").html("Please select a division before adding project!");
                $noCon("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
                });
            }
        }
        return false;
    }

    function GetValueFromChildProject(PrjctId, PrjctName) {
        if (PrjctId != '') {
            PostbackFunProject(PrjctId, PrjctName);
        }
    }
    function PostbackFunProject(PrjctId, PrjctName) {

        document.getElementById("<%=hiddenProjectId.ClientID%>").value = PrjctId;
        document.getElementById("<%=btnPrjct.ClientID%>").click();
        return false;
    }

    //Add Vendor

    function OpenVendor() {
        if (document.getElementById("<%=hiddenView.ClientID%>").value != "1") {

            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to add new vendor?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var Division = document.getElementById("<%=ddlPODivision.ClientID%>").value;
                    var nWindow = window.open('/FMS/FMS_Master/fms_Supplier/fms_Supplier.aspx?RFGP=SUPID', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                    nWindow.focus();
                } else {
                    return false;
                }
            });

            return false;
        }
    }

    function GetValueFromChildSupplierId(myVal, myValName) {
        if (myVal != '') {
            PostbackFunVendor(myVal, myValName);
        }
    }
    function PostbackFunVendor(myVal, myValName) {
        document.getElementById("<%=hiddenVendorId.ClientID%>").value = myVal;
        document.getElementById("<%=ddlVendor.ClientID%>").value = myValName;
        document.getElementById("<%=tdVendorName.ClientID%>").value = myValName;
        LoadVendors(1, null);
        document.getElementById("<%=btnSupp.ClientID%>").click();
        return false;
    }

    //Add product

    function OpenProduct(RowNum) {

        var Msg = "";
        if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
            Msg = "Are you sure you want to create new product?";
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
            Msg = "Are you sure you want to create new vehicle?";
        }

        if (document.getElementById("<%=hiddenView.ClientID%>").value != "1") {
            ezBSAlert({
                type: "confirm",
                messageText: Msg,
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
                        var nWindow = window.open('/Master/gen_Product_Master/gen_Product_Master.aspx?PRCHS=PRDCTROW&ROW=' + RowNum + '', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                    }
                    else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
                        var nWindow = window.open('/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master.aspx?PRCHS=VEHROW&ROW=' + RowNum + '', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                    }
                    nWindow.focus();
                } else {
                    return false;
                }
            });
        }
        return false;
    }

    function GetValueFromChildProduct(myVal, myValName, Row) {
        if (myVal != '' && Row != '') {
            PostbackFunProduct(myVal, myValName, Row);
        }
    }

    function PostbackFunProduct(myVal, myValName, Row) {
        document.getElementById("tdProductId" + Row).value = myVal;
        document.getElementById("ddlProducts" + Row).value = myValName;
        document.getElementById("tdProductName" + Row).value = myValName;
        LoadProductTaxDtls(Row);
    }

    function GetValueFromChildVehicle(myVal, myValName, Row) {
        if (myVal != '' && Row != '') {
            PostbackFunVehicle(myVal, myValName, Row);
        }
    }

    function PostbackFunVehicle(myVal, myValName, Row) {
        document.getElementById("tdProductId" + Row).value = myVal;
        document.getElementById("ddlVehicle" + Row).value = myValName;
        document.getElementById("tdProductName" + Row).value = myValName;
        LoadProductTaxDtls(Row);
    }

    function GetValueFromChildPOList(Id, BasicDtls, Products, ChrgHd, TermsCndtns) {
        PostbackFunPOList(Id, BasicDtls, Products, ChrgHd, TermsCndtns);
    }

    function PostbackFunPOList(Id, BasicDtls, Products, ChrgHd, TermsCndtns) {
        document.getElementById("<%=HiddenCopy.ClientID%>").value = Id + "," + BasicDtls + "," + Products + "," + ChrgHd + "," + TermsCndtns;
        document.getElementById("<%=btnCopyClick.ClientID%>").click();
        return false;
    }

</script>

<script>
    //Bulk products

    function LoadBulkProducts() {

        if (isTagEnter(event) == false) {
            return false;
        }

        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var OrgId = '<%=Session["ORGID"]%>';
        var ProductMode = document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value;

        $noCon('#txtBulkProductSearch').autocomplete({
            source: function (request, response) {
                $.ajax({
                    async: false,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "pms_Purchase_Order.aspx/LoadBulkProducts",
                    data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",ProductMode:"' + ProductMode + '",strText:"' + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + '"}',
                    success: function (data) {
                        if (data.d != "") {
                            document.getElementById("ulProductList").innerHTML = data.d;
                        }
                    }
                });
            }
        });
    }

    function AppendSelectedList(strProductId, strProductName, Mode) {
        if (Mode == "1") {
            $("#olSelProductList").append("<li id=\"liPrdct_" + strProductId + "\" data-draggable=\"item\" draggable=\"true\" style=\"word-break:break-word;\"><input id=\"cbxPrdct" + strProductId + "\" type=\"checkbox\" class=\"ck_b1\" onclick=\"return AppendSelectedList('" + strProductId + "','" + strProductName + "','2');\"><label id=\"lblPrdct" + strProductId + "\">" + strProductName + "</label><input id=\"txtBulkQnty" + strProductId + "\" class=\"in_qty tr_c\" type=\"number\" value=\"1\" placeholder=\"1\" min=\"1\"></li>");
            $('#ulProductList #liPrdct_' + strProductId).remove();
        }
        else if (Mode == "2") {
            $("#ulProductList").append("<li id=\"liPrdct_" + strProductId + "\" data-draggable=\"item\" draggable=\"true\" style=\"word-break:break-word;\"><input id=\"cbxPrdct" + strProductId + "\" type=\"checkbox\" class=\"ck_b1\" onclick=\"return AppendSelectedList('" + strProductId + "','" + strProductName + "','1');\"><label id=\"lblPrdct" + strProductId + "\">" + strProductName + "</label><input id=\"txtBulkQnty" + strProductId + "\" class=\"in_qty tr_c\" type=\"number\" value=\"1\" placeholder=\"1\" min=\"1\"></li>");
            $('#olSelProductList #liPrdct_' + strProductId).remove();
        }
        return false;
    }

    function AddProducts() {

        var Table = "", obj = "";
        if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
            Table = document.getElementById("tableProducts");
            obj = "ddlProducts";
        }
        else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
            Table = document.getElementById("tableVehicles");
            obj = "ddlVehicle";
        }

        if (Table.rows.length == 1) {

            var x = (Table.rows[0].cells[0].innerHTML);

            if (document.getElementById(obj + x).value == "") {//1st row value not there, append to it separately

                if ($("#olSelProductList li").length > 0) {
                    var product = $('#olSelProductList li:first').attr("id");
                    var productSplit = product.split('_');
                    var Id = productSplit[1];
                    var ProductName = document.getElementById("lblPrdct" + Id).innerHTML;
                    var Qnty = document.getElementById("txtBulkQnty" + Id).value;

                    document.getElementById(obj + x).value = ProductName;
                    document.getElementById("tdProductId" + x).value = Id;
                    document.getElementById("tdProductName" + x).value = ProductName;
                    LoadProductTaxDtls(x);
                    document.getElementById("txtQnty" + x).value = Qnty;
                    BlurValue(x);
                }

                AppendProducts(1);
            }
            else {
                AppendProducts(0);
            }
        }
        else {
            AppendProducts(0);
        }

        return false;
    }


    function AppendProducts(Mode) {

        if (Mode == "1") {
            $('#olSelProductList li:first').remove();
        }
        var listItems = $("#olSelProductList li");

        if ($("#olSelProductList li").length > 0) {

            listItems.each(function (idx, li) {

                var product = $(li).attr("id");
                var productSplit = product.split('_');
                var Id = productSplit[1];
                var ProductName = document.getElementById("lblPrdct" + Id).innerHTML;
                var Qnty = document.getElementById("txtBulkQnty" + Id).value;

                var idlast = "", obj = "";
                if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "1") {
                    AddMoreRowsProducts(1);
                    idlast = $('#tableProducts tr:last').attr('id');
                    obj = "ddlProducts";
                }
                else if (document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value == "2") {
                    AddMoreRowsVehicles(1);
                    idlast = $('#tableVehicles tr:last').attr('id');
                    obj = "ddlVehicle";
                }
                var LastId = "";
                if (idlast != "") {
                    var res = idlast.split("_");
                    LastId = res[1];
                }

                document.getElementById(obj + LastId).value = ProductName;
                document.getElementById("tdProductId" + LastId).value = Id;
                document.getElementById("tdProductName" + LastId).value = ProductName;
                LoadProductTaxDtls(LastId);
                document.getElementById("txtQnty" + LastId).value = Qnty;
                BlurValue(LastId);

            });

            $('#ModalBulkProduct').modal('hide');
        }
        else {
            $("#olSelProductList").css("border-color", "Red");
            return false;
        }
    }

</script>

<script>
    function LoadSearchPO() {

        if (isTagEnter(event) == false) {
            return false;
        }

        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var OrgId = '<%=Session["ORGID"]%>';

        $noCon('#txtSearchPO').autocomplete({
            source: function (request, response) {
                $.ajax({
                    async: false,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "pms_Purchase_Order.aspx/LoadSearchPO",
                    data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",strText:"' + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + '"}',
                    success: function (data) {
                        if (data.d != "") {
                            document.getElementById("divReport").innerHTML = data.d;
                        }
                    }
                });
            }
        });
    }
</script>

<script>
    function LoadFunctions(EditDtls, ChrgDtls, PaymntTerms, TermsCndtns, FrieghtTerms, VendorId, F9Mode) {

        document.getElementById("<%=hiddenEditDtls.ClientID%>").value = EditDtls;
        document.getElementById("<%=hiddenChrgDtls.ClientID%>").value = ChrgDtls;

        document.getElementById("<%=txtPaymntTerms.ClientID%>").value = PaymntTerms;
        document.getElementById("<%=txtTermsCondtns.ClientID%>").value = TermsCndtns;
        document.getElementById("<%=txtFreightTerms.ClientID%>").value = FrieghtTerms;

        document.getElementById("<%=hiddenVendorId.ClientID%>").value = VendorId;
        document.getElementById("<%=hiddenF9Mode.ClientID%>").value = F9Mode;

        if (EditDtls != "[]" && EditDtls != "") {
            DisplayProducts(0, 1);
        }
        if (ChrgDtls != "[]" && ChrgDtls != "") {
            $("#tableCharge").empty();
            DisplayCharge(0, 1);
        }

        document.getElementById("<%=tdDiscntTotal.ClientID%>").value = "0";

        CalculateNetAmount();

        AutoCompleteAll();
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

   <asp:HiddenField ID="hiddenDefaultCurrencyId" runat="server" />
   <asp:HiddenField ID="hiddenTaxEnabled" runat="server" />
   <asp:HiddenField ID="hiddenDefaultCrncyAbrvtn" runat="server" />
   <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" /> 
   <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
   <asp:HiddenField ID="hiddenTaxDecimalCount" runat="server" />
   <asp:HiddenField ID="hiddenCnclDtlIds" runat="server" />
   <asp:HiddenField ID="hiddenPercntgDecimalCount" runat="server" />
   <asp:HiddenField ID="hiddenNetAmnt" runat="server" />
   <asp:HiddenField ID="hiddenExchngCrncyAbrvtn" runat="server" />
   <asp:HiddenField ID="hiddenExchngCurrencyModeId" runat="server" />
   <asp:HiddenField ID="hiddenPurchsOrdrDtls" runat="server" />
   <asp:HiddenField ID="hiddenEditDtls" runat="server" />
   <asp:HiddenField ID="hiddenView" runat="server" />
   <asp:HiddenField ID="hiddenChrgDtls" runat="server" />
   <asp:HiddenField ID="hiddenFilePath" runat="server" />
   <asp:HiddenField ID="hiddenAttchmntDtls" runat="server" />
   <asp:HiddenField ID="hiddenAttchCnclDtlIds" runat="server" />
   <asp:HiddenField ID="hiddenVendorId" runat="server" />
   <asp:HiddenField ID="hiddenProjectId" runat="server" />
   <asp:HiddenField ID="hiddenEnableReopen" runat="server" />
   <asp:HiddenField ID="hiddenF9Mode" runat="server" />
   <asp:HiddenField ID="hiddenApprvaCnslMode" runat="server" />
   <asp:HiddenField ID="HiddenCopy" runat="server" /> 

  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <ol id="OlSection" runat="server" class="breadcrumb">
          <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Pms.aspx">Procurement Management</a></li>
        <li><a href="pms_Purchase_Order_List.aspx">Purchase order</a></li>
        <li class="active">Add Purchase order</li>
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


  <a id="divList" runat="server" href="javascript:;" onclick="return ConfirmMessageList()" type="button" class="list_b" title="Back to List">
    <i class="fa fa-arrow-circle-left"></i>
  </a>

    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">

          <div onmouseover="closesave()">

          <h1 class="h1_con h1_po"><asp:Label ID="lblEntry" runat="server">Add Purchase Order</asp:Label></h1>

          <button id="btnCopy" title="Copy from existing PO" class="btn btn-primary pull-right btn_po" onclick="return CopyPO();" style="display:none;"><i class="fa fa-files-o"></i> Copy from existing PO</button>
          
         <script>
             function CopyPO() {
                 myWindow = window.open('pms_Purchase_Order_List.aspx?Inscopy=1', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                 return false;
             }
         </script>     
              
          <div class="clearfix"></div>
          <div class="free_sp"></div>

      <asp:UpdatePanel ID="UpdatePanel1" EnableViewState="true" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

        <div id="divMain">

          <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1">Purchase Order Type:<span class="spn1">*</span></label>
               <asp:DropDownList ID="ddlPrchsOrdrType" runat="server" class="form-control fg2_inp1 fg_chs1 inp_mst" onchange="DisplayProducts(1,0);" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);">
                   <asp:ListItem Text="Products" Value="1"></asp:ListItem>
                   <asp:ListItem Text="Car Rental" Value="2"></asp:ListItem>
                   <asp:ListItem Text="Air Ticket" Value="3"></asp:ListItem>
               </asp:DropDownList>  
          </div>

          <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1">Purchase Order ref#:<span class="spn1">*</span></label>
            <asp:TextBox ID="txtPrchsOrdrRef" runat="server" readonly="true" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 fg_chs1 inp_mst" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtPrchsOrdrRef')"></asp:TextBox>
          </div>

          <div class="form-group fg2 fg2_wf">
            <div class="tdte">
              <label class="fg2_la1">Purchase Order Date:<span class="spn1">*</span> </label>
              <div id="datepickerPrchsDate" class="input-group date" data-date-format="dd-mm-yyyy">
                 <input id="txtPrchsOrdrDate" runat="server" type="text" onkeypress="return isTagEnter(event)" class="form-control inp_bdr inp_mst" data-dateformat="dd-mm-yyyy" placeholder="dd-mm-yyyy" maxlength="50" autocomplete="off" />
                 <span id="spanPrchsOrdrDate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>
            </div> 
          </div>

            <script>
                $noCon('#datepickerPrchsDate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false
                }).on('changeDate', function (selected) {
                    var minDate = new Date(selected.date.valueOf());
                    $noCon('#datepickerExpctdDelvryDt').datepicker('setStartDate', minDate);
                });
            </script>

          <div class="form-group fg2 fg2_wf">
            <div class="tdte">
              <label for="pwd" class="fg2_la1">Expected Delivery Date:<span class="spn1"></span> </label>
              <div id="datepickerExpctdDelvryDt" class="input-group date" data-date-format="dd-mm-yyyy">
                 <input id="txtDeliveryDate" runat="server" type="text" onkeypress="return isTagEnter(event)" class="form-control inp_bdr" data-dateformat="dd-mm-yyyy" placeholder="dd-mm-yyyy" maxlength="50" autocomplete="off" />
                 <span id="spanDeliveryDate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>
            </div> 
          </div>

            <script>
                var DateVal = document.getElementById("<%=txtPrchsOrdrDate.ClientID%>").value;

                $noCon('#datepickerExpctdDelvryDt').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    startDate: DateVal,
                    timepicker: false
                });
            </script>

        <div class="form-group fg2">
          <label class="fg2_la1">Division:<span class="spn1">*</span></label>
            <div id="divddlPODivision">
              <asp:DropDownList ID="ddlPODivision" runat="server" class="form-control fg2_inp1 fg_chs1 inp_mst ddl" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);" OnSelectedIndexChanged="ddlPODivision_SelectedIndexChanged" AutoPostBack="true" >
               </asp:DropDownList>  
            </div>
        </div>

          <div class="form-group fg2 fg2_wf1">
            <label class="fg2_la1 pad_l">Project:<span class="spn1">&nbsp;</span></label>
              <div id="divddlProject">
              <asp:DropDownList ID="ddlProjects" runat="server" class="form-control fg2_inp1 ddl" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged" AutoPostBack="true">
               </asp:DropDownList>
              </div>
            <a id="AddProject" runat="server" href="javascript:;" onclick="OpenProject();" title="Add New Project"><span class="input-group-addon cur6"><i class="fa fa-plus"></i></span></a>
          </div>

          <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1">Client Name:<span class="spn1"></span></label>
            <asp:TextBox ID="txtClientName" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 fg_chs1" placeholder="Client Name" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtClientName')"></asp:TextBox>
          </div>

          <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1">End-customer Name:<span class="spn1"></span></label>
            <asp:TextBox ID="txtEndCustomer" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 fg_chs1" placeholder="End-customer Name" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtEndCustomer')"></asp:TextBox>        
          </div>

         <div class="clearfix fx_c_h"></div>

          <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1">Mode of Supply:<span class="spn1">*</span></label>
               <asp:DropDownList ID="ddlModeofSupply" runat="server" class="form-control fg2_inp1 fg_chs1 inp_mst" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);">
               </asp:DropDownList>       
          </div>

           <div class="form-group fg2 fg2_wf">
            <label for="cphMain_radioWarehouse" class="fg2_la1">Deliver To:<span class="spn1">*</span></label>
            <div class="mar_a flt_l fg2_wf1">
              <div class="form-group">
                <label for="cphMain_radioProjct" class="fg2_la1 pa_tp0">
                  <asp:RadioButton ID="radioProjct" runat="server" Text="Project Location" GroupName="Delivery" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);" OnCheckedChanged="ddlProjects_SelectedIndexChanged" />
                </label>
              </div>
              <div class="form-group">
                <label for="cphMain_radioWarehouse" class="fg2_la1">
                  <asp:RadioButton ID="radioWarehouse" runat="server" Text="Warehouse" Checked="true" GroupName="Delivery" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);" OnCheckedChanged="ddlProjects_SelectedIndexChanged" />
                </label>
              </div>

            </div>      
          </div>
      
         
        <div class="ware_1">
          <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1">Warehouse:<span class="spn1">*</span></label>
              <div id="divddlWarehouse">
               <asp:DropDownList ID="ddlWarehouse" runat="server" class="form-control fg2_inp1 fg_chs1 inp_mst" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);" OnSelectedIndexChanged="ddlWarehouse_SelectedIndexChanged" AutoPostBack="true">
               </asp:DropDownList>
              </div>      
          </div>
          <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1">Delivery Location:<span class="spn1">*</span></label>
            <asp:TextBox ID="txtWarehouseDelivery" runat="server" Rows="4" class="form-control fg2_inp1 fg_chs1 inp_mst" MaxLength="500" TextMode="MultiLine" placeholder="Delivery Location" Style="resize:none;" onchange="IncrmntConfrmCounter();" onkeydown="textCounter(cphMain_txtWarehouseDelivery,450)" onkeyup="textCounter(cphMain_txtWarehouseDelivery,450)" onblur="return isTag(event)"></asp:TextBox>
          </div>
        </div>

        <div class="clearfix"></div>
        <div class="free_sp"></div>

        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Quotation Ref#:<span class="spn1"></span></label>
          <asp:TextBox ID="txtQuotatnRef" runat="server" autocomplete="off" MaxLength="50" class="form-control fg2_inp1 fg_chs1" placeholder="Quotation Ref#" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtQuotatnRef')"></asp:TextBox>          
        </div>

        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Quotation Date:<span class="spn1"></span></label>
              <div id="datepickerQuotnDate" class="input-group date" data-date-format="dd-mm-yyyy">
                 <input id="txtQuotatnDate" runat="server" type="text" onkeypress="return isTagEnter(event)" class="form-control inp_bdr" data-dateformat="dd-mm-yyyy" placeholder="dd-mm-yyyy" maxlength="50" autocomplete="off" />
                 <span id="spanQuotatnDate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>        
        </div>

            <script>
                $noCon('#datepickerQuotnDate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false
                });
            </script>

        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Currency:<span class="spn1">*</span></label>
               <asp:DropDownList ID="ddlCurrency" runat="server" class="form-control fg2_inp1 fg_chs1 inp_mst" onchange="return ChangeCurrency(1);" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);">
               </asp:DropDownList>        
        </div>

        <div class="form-group fg2 fg2_wf" id="divExchangeRate" style="display: none">
          <label class="fg2_la1">Exchange Rate:<span class="spn1">*</span></label>
            <%--<div class="input-group">--%>
             <%--<asp:TextBox ID="txtExchgRate" runat="server" autocomplete="off" MaxLength="20" class="form-control inp_bdr inp_mst tr_r" onkeydown="return isNumber(event);" onkeypress="return isNumber(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveNaN_OnBlur('cphMain_txtExchgRate')"></asp:TextBox>--%>
             <asp:TextBox ID="txtExchgRate" runat="server" value="1" autocomplete="off" MaxLength="20" class="form-control fg2_inp1 fg_chs1 inp_mst tr_r" onkeydown="return isNumberAmount(event,'cphMain_txtExchgRate')" onkeypress="return isNumberAmount(event,'cphMain_txtExchgRate')" onkeyup="IncrmntConfrmCounter()" onblur="CalculateNetAmount();"></asp:TextBox>       
             <span id="spanCrncyExchng" runat="server" style="display:none;" class="input-group-addon date1"></span> 
            <%--</div>  --%>            
        </div>


<!---=================section_devider============--->
    <div class="clearfix"></div>
    <div class="free_sp"></div>
    <div class="devider"></div>
<!---=================section_devider============--->
          <h3 class="h1_con">Vendor Details</h3>

          <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1 pad_l">Vendor Name:<span class="spn1">*</span></label>
              <div id="divddlVendor">
               <asp:TextBox ID="ddlVendor" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 fg_chs1" placeholder="--SELECT VENDOR--" onkeydown="return LoadVendors(1,event);" onkeypress="return LoadVendors(1,event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_ddlVendor')" OnTextChanged="ddlVendor_TextChanged"></asp:TextBox>
                <input id="tdVendorName" runat="server" style="display:none" />
              </div>
            <a id="AddVendor" runat="server" href="javascript:;" onclick="OpenVendor();" title="Add New Vendor"><span class="input-group-addon cur6"><i class="fa fa-plus"></i></span></a>
            <br>
            <label class="fg2_la1 pad_l">Vendor Rating:</label>
            <div class="rat_ven">
              <span id="spanRate1" class="fa fa-star" runat="server"></span>
              <span id="spanRate2" class="fa fa-star" runat="server"></span>
              <span id="spanRate3" class="fa fa-star" runat="server"></span>
              <span id="spanRate4" class="fa fa-star" runat="server"></span>
              <span id="spanRate5" class="fa fa-star" runat="server"></span>
            </div>
          </div>

          <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1">Vendor Ref#:<span class="spn1"></span></label>
             <asp:TextBox ID="txtVendorRef" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 fg_chs1" placeholder="Vendor Ref#" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtVendorRef')"></asp:TextBox>         
          </div>

          <div class="form-group fg6 fg2_wf">
            <label class="fg2_la1">Address:<span class="spn1"></span></label>
            <asp:TextBox ID="txtVendorAddress" runat="server" Rows="4" class="form-control fg2_inp1 fg_chs1" MaxLength="250" TextMode="MultiLine" placeholder="Address" Style="resize:none;" onkeydown="textCounter(cphMain_txtVendorAddress,250)" onkeyup="textCounter(cphMain_txtVendorAddress,250)" onblur="return isTag(event)"></asp:TextBox>
          </div>

            <div class="clearfix"></div>

         <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1">Vendor Contact person:<span class="spn1"></span></label>
              <asp:DropDownList ID="ddlVendorContact" runat="server" class="form-control fg2_inp1" onkeypress="return F9Click(event,0);" onkeydown="return F9Click(event,0);">
               </asp:DropDownList>
             <asp:TextBox ID="txtVendorContact" runat="server" autocomplete="off" Style="display:none;" MaxLength="100" class="form-control fg2_inp1 fg_chs1" placeholder="Vendor Contact person" onkeypress="return F9Click(event,1);" onkeydown="return F9Click(event,1);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtVendorContact')"></asp:TextBox>         
          </div>

         <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1">Mobile#:<span class="spn1">*</span></label>
            <asp:TextBox ID="txtVendorMobile" runat="server" autocomplete="off" MaxLength="20" class="form-control fg2_inp1 fg_chs1 inp_mst" placeholder="Mobile#" onkeydown="return isNumber(event);" onkeypress="return isNumber(event);" onkeyup="IncrmntConfrmCounter()" onblur="return ValidateMobile('cphMain_txtVendorMobile');"></asp:TextBox>                  
          </div>

          <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1">Contact#:<span class="spn1"></span></label>
            <asp:TextBox ID="txtVendorContactNo" runat="server" autocomplete="off" MaxLength="20" class="form-control fg2_inp1 fg_chs1" placeholder="Contact#" onkeydown="return isNumber(event);" onkeypress="return isNumber(event);" onkeyup="IncrmntConfrmCounter()" onblur="return RemoveNaN_OnBlur('cphMain_txtVendorContactNo')"></asp:TextBox>        
          </div>

          <div class="form-group fg2 fg2_wf">
            <label class="fg2_la1">Fax#:<span class="spn1"></span></label>
             <asp:TextBox ID="txtVendorFax" runat="server" autocomplete="off" MaxLength="20" class="form-control fg2_inp1 fg_chs1" placeholder="Fax#" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtVendorFax')"></asp:TextBox>       
          </div>

          <div class="form-group fg6 po_chk fg2_wf1">
            <div class="check1">
              <div class="">
                <label class="switch">
                  <input id="cbxFuture" type="checkbox" runat="server" onkeypress="return DisableEnter(event)" disabled="disabled" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
            <p>Use these contact details as default information in future PO's
          </p>
        </div>
        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Email ID:<span class="spn1"></span></label>
            <asp:TextBox ID="txtVendorEmail" runat="server" autocomplete="off" MaxLength="50" class="form-control fg2_inp1 fg_chs1" placeholder="Email ID" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="return ValidateEmail('cphMain_txtVendorEmail');"></asp:TextBox>
        </div>
        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Comments:<span class="spn1"></span></label>
            <asp:TextBox ID="txtVendorComments" runat="server" Rows="2" class="form-control fg2_inp1 fg_chs1" MaxLength="300" TextMode="MultiLine" placeholder="Comments" Style="resize:none;" onkeydown="textCounter(cphMain_txtVendorComments,300)" onkeyup="textCounter(cphMain_txtVendorComments,300)" onblur="return isTag(event)"></asp:TextBox>      
        </div>
          
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
      <div class="devider"></div>
<!---=================section_devider============--->

        <h3 class="h1_con">Internal Details</h3>

        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Document Workflow:<span class="spn1">*</span></label>
            <div id="divddlDocumntWrkflw">
            <asp:DropDownList ID="ddlDocumntWrkflw" runat="server" class="form-control fg2_inp1 fg_chs1 inp_mst ddl" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);">
              </asp:DropDownList>
            </div>
        </div>
        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Requested By:<span class="spn1"></span></label>
            <div id="divddlPORequestor">
            <asp:DropDownList ID="ddlPORequestor" runat="server" class="form-control fg2_inp1 fg_chs1 ddl" OnSelectedIndexChanged="ddlPORequestor_SelectedIndexChanged" AutoPostBack="true" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);">
              </asp:DropDownList>
            </div>
        </div>

        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Date of Requirement:<span class="spn1"></span></label>
              <div id="datepickerRqrmntDate" class="input-group date" data-date-format="dd-mm-yyyy">
                 <input id="txtPORequiremntDate" runat="server" type="text" onkeypress="return isTagEnter(event)" class="form-control inp_bdr" data-dateformat="dd-mm-yyyy" placeholder="dd-mm-yyyy" maxlength="50" autocomplete="off" />
                 <span id="spanPORequiremntDate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>          
        </div>

            <script>
                $noCon('#datepickerRqrmntDate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false
                });
            </script>

        <div class="fg2 fg2_wf">
            <label class="fg2_la1 pad_l">This is an urgent Purchase Order:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch" onclick="dte_m_1()">
                  <input id="cbxPOUrgent" type="checkbox" runat="server" onkeypress="return DisableEnter(event)" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

      <div class="clearfix"></div>
        
        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Requisition#:<span class="spn1"></span></label>
            <asp:TextBox ID="txtPORequisitionNo" runat="server" autocomplete="off" MaxLength="50" class="form-control fg2_inp1 fg_chs1" placeholder="Requisition#" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtPORequisitionNo')"></asp:TextBox>
        </div>

        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Requisition Date:<span class="spn1"></span></label>
              <div id="datepickerRqstnDate" class="input-group date" data-date-format="dd-mm-yyyy">
                 <input id="txtPORequisitnDate" runat="server" type="text" onkeypress="return isTagEnter(event)" class="form-control inp_bdr" data-dateformat="dd-mm-yyyy" placeholder="dd-mm-yyyy" maxlength="50" autocomplete="off" />
                 <span id="spanPORequisitnDate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>          
        </div>

            <script>
                $noCon('#datepickerRqstnDate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false
                });
            </script>

        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">PO Contact Person:<span class="spn1"></span></label>
              <asp:DropDownList ID="ddlPOContact" runat="server" class="form-control fg2_inp1" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);">
               </asp:DropDownList>        
        </div>

        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Mobile#:<span class="spn1">*</span></label>
            <asp:TextBox ID="txtPOMobile" runat="server" autocomplete="off" MaxLength="20" class="form-control fg2_inp1 fg_chs1 inp_mst" placeholder="Mobile#" onkeydown="return isNumber(event);" onkeypress="return isNumber(event);" onkeyup="IncrmntConfrmCounter()" onblur="return ValidateMobile('cphMain_txtPOMobile');"></asp:TextBox>
        </div>


        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Approval Date:<span class="spn1"></span></label>
              <div id="datepickerAprvlDate" class="input-group date" data-date-format="dd-mm-yyyy">
                 <input id="txtApprovalDate" runat="server" type="text" onkeypress="return isTagEnter(event)" class="form-control inp_bdr" data-dateformat="dd-mm-yyyy" placeholder="dd-mm-yyyy" maxlength="50" autocomplete="off" />
                 <span id="spanApprovalDate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>            
        </div>

            <script>
                $noCon('#datepickerAprvlDate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    //startDate: new Date(),
                    timepicker: false
                });
            </script>

        <div class="form-group fg2 fg2_wf">
          <label class="fg2_la1">Internal Jobcode#:<span class="spn1"></span></label>
        <asp:TextBox ID="txtJobCode" runat="server" autocomplete="off" MaxLength="50" class="form-control fg2_inp1 fg_chs1" placeholder="Internal Jobcode#" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtJobCode')"></asp:TextBox>
        <%--<asp:TextBox ID="txtJobCode" runat="server" autocomplete="off" MaxLength="50" class="form-control fg2_inp1 fg_chs1" placeholder="Internal Jobcode#"  onkeydown="return isNumber(event);" onkeypress="return isNumber(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveNaN_OnBlur('cphMain_txtJobCode')" ></asp:TextBox>--%>
        </div>


        <div class="form-group fg2 fg2_wf">
          <label for="cphMain_txtJobDescrptn" class="fg2_la1">Job Description:<span class="spn1"></span></label>
          <asp:TextBox ID="txtJobDescrptn" runat="server" Rows="2" class="form-control" MaxLength="500" TextMode="MultiLine" placeholder="Job Description" Style="resize:none;" onkeydown="textCounter(cphMain_txtJobDescrptn,450)" onkeyup="textCounter(cphMain_txtJobDescrptn,450)" onblur="return isTag(event)"></asp:TextBox>
        </div>
 
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
      <div class="devider"></div>
<!---=================section_devider============--->

      </div>

              <asp:Button ID="btnPrjct" runat="server" Style="display:none;" class="btn sub2" OnClick="btnPrjct_Click" />
              <asp:Button ID="btnSupp" runat="server" Style="display:none;" class="btn sub2" OnClick="btnSupp_Click" />
              <asp:Button ID="btnCopyClick" runat="server" Style="display:none;" class="btn sub2" OnClick="btnCopyClick_Click" />

       </ContentTemplate>
      </asp:UpdatePanel>
        
        <div id="divBulkProduct" class="blk_btn pull-right" style="display:none;">
          <button class="btn tab_but1 butn1" data-toggle="modal" data-target="#ModalBulkProduct" onclick="return OpenBulkProduct();">
            <span class="add_bulk"><i class="fa fa-plus"></i> Add products in bulk</span>
          </button>
        </div>

              <script>
                  function OpenBulkProduct() {

                      document.getElementById("txtBulkProductSearch").value = "";

                      $("#ulProductList").empty();
                      $("#olSelProductList").empty();

                      return false;
                  }
              </script>

     <div id="divTables">

<!---========Products==========---->

       <div id="divProducts" class="prdct_po" style="display:none;">
          <div class="tabl_set">
          <table class="table table-bordered">
            <thead class="thead1">

              <tr id="trTaxEnabled">
                <th class="th_b5">SL#</th>
                <th class="th_b2 tr_l">PRODUCT Name</th>
                <th class="th_b5 tr_c">QTY</th>
                <th class="th_b1 tr_r">PRICE</th>
                <th class="th_b8">DISCOUNT</th>
                <th id="thTax" class="th_b3">TAX</th>
                <th class="th_b7 tr_r">TOTAL AMOUNT</th>
                <th class="th_b6">ACTIONS</th>
              </tr>

            </thead>
            <tbody id="tableProducts">
           </tbody>

          </table>
          </div>
        </div>

<!---========Products==========---->

<!---========Vehicle==========---->

        <div id="divVehicle" class="rnt_car tabl_set" style="display:none;">
          <div class="tabl_set">
          <table class="table table-bordered">
            <thead class="thead1">
              <tr>
                <th class="th_b5">SL#</th>
                <th class="th_b11 tr_l">Vehicle Name</th>
                <th class="th_b8 tr_c">Starting Date</th>
                <th class="th_b8 tr_c">Ending Date</th>
                <th class="th_b2 tr_l">Username</th>
                <th class="th_b8">Employee ID</th>
                <th class="th_b8 tr_l">Division</th>
                <th class="th_b5">NOS</th>
                <th class="th_b6 tr_r">Rate</th>
                <th class="th_b6 tr_r">Amount</th>
                <th class="th_b4">ACTIONS</th>
              </tr>
            </thead>
            <tbody id="tableVehicles">
            </tbody>
          </table>
          </div>
        </div>

<!---========Vehicle==========---->

<!---========Airticket==========---->

        <div id="divAirTicket" class="ar_tkt tabl_set" style="display:none;">
          <div class="tabl_set">
          <table class="table table-bordered">
            <thead class="thead1">
              <tr>
                <th class="th_b5">SL#</th>
                <th class="th_b11 tr_l">PNR#</th>
                <th class="th_b2 tr_c">Sector</th>
                <th class="th_b8 tr_c">Date of Travel</th>
                <th class="th_b2 tr_l">Passenger Name</th>
                <th class="th_b6">Employee ID</th>
                <th class="th_b8 tr_l">Division</th>
                <th class="th_b5">NOS</th>
                <th class="th_b7 tr_r">Rate</th>
                <th class="th_b6 tr_r">Amount</th>
                <th class="th_b4">ACTIONS</th>
              </tr>
            </thead>
            <tbody id="tableAirTickt">
            </tbody>
          </table>
          </div>
        </div>

<!---========Airticket==========---->

      </div>

<!---========AdditionalCharges==========---->

        <div class="text_area_container po_txt">

          <p>Aditional charges for PO, if any:</p>
          <div class="col-md-8 ma_at_fl">
            <table class="table table-bordered">
              <thead class="thead1">
                <tr>
                  <th class="col-md-6 tr_l">Charges</th>
                  <th class="col-md-3 tr_r">Amount</th>
                  <th class="col-md-3">Actions</th>
                </tr>
              </thead>
              <tbody id="tableCharge">
              </tbody>
            </table>
          </div>

<!---========NetTotalAmount==========---->

          <div class="col-md-4 txt_alg al1">
            <div class="col-md-6 fg2_wf po_flt">
              <label class="fg2_la1 tt_am">Gross Amount: <span class="spn1">&nbsp;</span></label>
            </div>
            <div class="col-md-6 fg2_wf po_flt">
              <input id="txtGrossTotal" runat="server" class="tt_am tt_al tr_r" readonly="true" style="border:none;background-color:#f2f2f2;" />
            </div>

            <div class="col-md-6 fg2_wf po_flt">
              <label class="fg2_la1 tt_am am2">Tax Amount:<span class="spn1">&nbsp;</span></label>
            </div>
            <div class="col-md-6 fg2_wf po_flt">
               <input id="txtTaxTotal" runat="server" class="tt_am am2 tt_al tr_r" readonly="true" style="border:none;background-color:#f2f2f2;" />
            </div>

            <div class="col-md-6 fg2_wf po_flt">
              <label class="fg2_la1 tt_am am3">Total Discount:<span class="spn1">&nbsp;</span></label>
            </div>
            <div class="col-md-6 fg2_wf po_flt">
              <input id="txtDiscntTotal" runat="server" type="text" class="form-control fg2_inp2 tr_r mar_bo_d" readonly="true" maxlength="10" onblur="ChangeDiscntTotal();" onkeydown="return isNumberAmount(event,'cphMain_txtDiscntTotal')" onkeypress="return isNumberAmount(event,'cphMain_txtDiscntTotal')" />
                <input id="tdDiscntTotal" runat="server" type="text" style="display:none;" />
            </div>

            <hr class="hr_amt" />

            <div class="col-md-6 fg2_wf po_flt">
              <label class="fg2_la1 tt_am am1 txt_l">Net Amount:<span class="spn1"></span></label>
            </div>
            <div class="col-md-6 fg2_wf po_flt">
              <input id="txtNetTotal" runat="server" class="tt_am am1 tt_al tr_r" readonly="true" style="border:none;background-color:#f2f2f2;" />
            </div>

            <div id="divExchngTotal" class="col-md-12 tr_r">
              <span id="spanExchngTotal" runat="server" class="fg2_la1 tr_r flt_r"><span class="spn1"></span></span>
            </div>
          </div>

        </div>

<!---========NetTotalAmount==========---->

<!---========AdditionalCharges==========---->


<!---========area_devider==========---->
    <div class="clearfix"></div>
    <div class="free_sp"></div>
<!---========area_devider==========---->


        <div class="">
          <div class="col-md-12">

<!---========Documents==========---->

        <div>
            <label class="fg2_la1 pad_l">Attaching related documents, if any:<span class="spn1">*</span></label>
            <div class="check1 mar_btm1">
              <div class="">
                <label class="switch">
                  <input id="cbxAttachmnt" runat="server" type="checkbox" class="bu1" onclick="AttachmentAdd()" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);"/>
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
            <table id="tableAttachmnt" style="display:none;">
            </table>
        </div>

<!---========Documents==========---->

<!---========area_devider==========---->
    <div class="clearfix"></div>
    <div class="free_sp"></div>
<!---========area_devider==========---->

<!---========Terms&Conditions==========---->

              <div class="col-md-12 pa_n">
                <div class="col-md-4 ma_at_fl">
                  <div class="form-group">
                    <label class="fg2_la1">Payment Terms: <span class="spn1">&nbsp;</span></label>
                     <asp:TextBox ID="txtPaymntTerms" runat="server" Rows="4" Columns="50" class="form-control" MaxLength="500" TextMode="MultiLine" placeholder="Payment Terms" Style="resize:none;" onchange="IncrmntConfrmCounter();" onkeydown="textCounter(cphMain_txtPaymntTerms,450)" onkeyup="textCounter(cphMain_txtPaymntTerms,450)" onblur="return isTag(event)"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-4 ma_at_fl">
                  <div class="form-group">
                    <label class="fg2_la1">General Terms & Conditions: <span class="spn1">&nbsp;</span></label>
                     <asp:TextBox ID="txtTermsCondtns" runat="server" Rows="4" Columns="50" class="form-control" MaxLength="500" TextMode="MultiLine" placeholder="General Terms & Conditions" Style="resize:none;" onchange="IncrmntConfrmCounter();" onkeydown="textCounter(cphMain_txtTermsCondtns,450)" onkeyup="textCounter(cphMain_txtTermsCondtns,450)" onblur="return isTag(event)"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-4 ma_at_fl">
                  <div class="form-group">
                    <label class="fg2_la1">Freight Terms: <span class="spn1">&nbsp;</span></label>
                     <asp:TextBox ID="txtFreightTerms" runat="server" Rows="4" Columns="50" class="form-control" MaxLength="500" TextMode="MultiLine" placeholder="Freight Terms" Style="resize:none;" onchange="IncrmntConfrmCounter();" onkeydown="textCounter(cphMain_txtFreightTerms,450)" onkeyup="textCounter(cphMain_txtFreightTerms,450)" onblur="return isTag(event)"></asp:TextBox>
                  </div>
                </div>
              </div>

<!---========Terms&Conditions==========---->
            
          </div>
        </div>

<!---========Documents & Terms&Conditions==========---->


<!---========area_devider==========---->
    <div class="clearfix"></div>
    <div class="free_sp"></div>
<!---========area_devider==========---->


          <div class="sub_cont pull-right">
            <div class="save_sec">
              <asp:Button ID="btnSave"  runat="server" OnClientClick="return ValidatePO();" class="btn sub1" Text="Save" OnClick="btnSave_Click"  />
              <asp:Button ID="btnSaveAndClose"  runat="server" OnClientClick="return ValidatePO();" class="btn sub3" Text="Save & Close" OnClick="btnSave_Click"  />
              <asp:Button ID="btnUpdate"  runat="server" OnClientClick="return ValidatePO();" class="btn sub1" Text="Update" OnClick="btnUpdate_Click"  />
              <asp:Button ID="btnUpdateAndClose"  runat="server" OnClientClick="return ValidatePO();" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />
              <asp:Button ID="btnConfirm" runat="server" OnClientClick="return ConfirmAlert();" class="btn sub2" Text="Confirm" />
              <asp:Button ID="btnReopen" runat="server" OnClientClick="return ReopenAlert();" class="btn sub2" Text="Reopen" />
              <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
              <asp:Button ID="btnCancel" runat="server" OnClientClick="return ConfirmMessage();" class="btn sub4" Text="Cancel" />
              
              <asp:Button ID="btnConfirmClick" runat="server" Style="display:none;" OnClientClick="return ValidatePO();" class="btn sub2" Text="Confirm" OnClick="btnUpdate_Click" />
              <asp:Button ID="btnReopenClick" runat="server" Style="display:none;" OnClientClick="return ValidatePO();" class="btn sub2" Text="Reopen" OnClick="btnReopen_Click" />

            </div>
          </div>

         </div>
        </div>
      </div>
  </div>



<!----save_quick_actions_started--->
  <a id="btnFloat" href="javascript:;" onmouseover="opensave()" type="button" class="save_b" title="Save">
    <i class="fa fa-save"></i>
  </a>

<script>
    function opensave() {
        document.getElementById("mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("mySave").style.width = "0px";
    }
</script>

  <div class="mySave1" id="mySave">
    <div class="save_sec">
         <asp:Button ID="btnSaveFloat"  runat="server" OnClientClick="return ValidatePO();" class="btn sub1" Text="Save" OnClick="btnSave_Click" />
         <asp:Button ID="btnSaveAndCloseFloat"  runat="server" OnClientClick="return ValidatePO();" class="btn sub3" Text="Save & Close" OnClick="btnSave_Click" />
         <asp:Button ID="btnUpdateFloat"  runat="server" OnClientClick="return ValidatePO();" class="btn sub1" Text="Update" OnClick="btnUpdate_Click"  />
         <asp:Button ID="btnUpdateAndCloseFloat"  runat="server" OnClientClick="return ValidatePO();" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />
         <asp:Button ID="btnConfirmFloat" runat="server" OnClientClick="return ConfirmAlert();" class="btn sub2" Text="Confirm" />
         <asp:Button ID="btnReopenFloat" runat="server" OnClientClick="return ReopenAlert();" class="btn sub2" Text="Reopen" />
         <asp:Button ID="btnClearFloat" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
         <asp:Button ID="btnCancelFloat" runat="server" OnClientClick="return ConfirmMessage();" class="btn sub4" Text="Cancel" />
    </div>
  </div>
<!----save_quick_actions_closed--->

<!---Quick Search_fixed_section--->
  <a id="divQuickSearch" runat="server" href="javascript:;" type="button" class="qk_btn" title="Quick Search" onclick="op_qkser()">
    <i class="fa fa-search"></i>
  </a>

<script>
    function op_qkser() {
        document.getElementById("cphMain_qk_bo").style.display = "block";
        document.getElementById("txtSearchPO").value = "";
    }

    function cls_qkser() {
        document.getElementById("cphMain_qk_bo").style.display = "none";
    }
</script>

    <div class="qk_box" id="qk_bo" runat="server">
      <div class="qk_box_in">
        <div class="col-md-4">
          <span class="spn_cls"  onclick="cls_qkser()">
            <i class="fa fa-close"></i>
          </span>
        </div>
        <div class="col-md-4 pull-right">
          <label for="email" class="fg2_la1">Purchase Order#: <span class="spn1"></span></label>
          <input id="txtSearchPO" type="text" placeholder="Purchase Order#" class="form-control" autocomplete="off" maxlength="100" onkeydown="return LoadSearchPO();" onkeypress="return LoadSearchPO();" onkeyup="return LoadSearchPO();" />
        </div>
        <div class="col-md-12">
          <div class="qk_fix">
              <div id="divReport"></div>
          </div>
         </div>
    </div>
  </div>
<!---Quick Search_fixed_section--->


<!-- Modal_Bulk_Product -->
<div class="modal fade" id="ModalBulkProduct" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog mod2" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Add products in bulk</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        
<div class="col-md-12">
  <div class="col-md-6">
    <input type="text" id="txtBulkProductSearch" class=" myser1_s" onkeydown="return LoadBulkProducts();" onkeypress="return LoadBulkProducts();" onkeyup="return LoadBulkProducts();" placeholder="Search for products" title="Search for products" />
    <ul id="ulProductList" data-draggable="target" class="t1">
    </ul>
  </div>

  <div class="col-md-6">
    <h3>Selected Items</h3>
      <div id="divolSelProductList">
       <ol id="olSelProductList" data-draggable="target" class="t2 sel"></ol>
      </div>
  </div>
</div>
      </div>
      <div class="modal-footer" style="text-align: center;">
        <div class="flt_r tr_c" style="width: 20%;">
          <button type="submit" class="btn sub1" onclick="return AddProducts();">Add</button>
        </div>
        <h5>Drag product from item list section and drop into selected items section</h5>
      </div>
      </div>
    </div>
  </div>
<!-- Modal_Bulk_Product -->

  <script type="text/javascript">
      (function () {

          //exclude older browsers by the features we need them to support
          //and legacy opera explicitly so we don't waste time on a dead browser
          if 
          (
            !document.querySelectorAll
            ||
            !('draggable' in document.createElement('span'))
            ||
            window.opera
          )
          { return; }

          //get the collection of draggable items and add their draggable attribute
          for (var
            items = document.querySelectorAll('[data-draggable="item"]'),
            len = items.length,
            i = 0; i < len; i++) {
              items[i].setAttribute('draggable', 'true');
          }

          //variable for storing the dragging item reference 
          //this will avoid the need to define any transfer data 
          //which means that the elements don't need to have IDs 
          var item = null;

          //dragstart event to initiate mouse dragging
          document.addEventListener('dragstart', function (e) {
              //set the item reference to this element
              item = e.target;

              //we don't need the transfer data, but we have to define something
              //otherwise the drop action won't work at all in firefox
              //most browsers support the proper mime-type syntax, eg. "text/plain"
              //but we have to use this incorrect syntax for the benefit of IE10+
              e.dataTransfer.setData('text', '');

          }, false);

          //dragover event to allow the drag by preventing its default
          //ie. the default action of an element is not to allow dragging 
          document.addEventListener('dragover', function (e) {
              if (item) {
                  e.preventDefault();
              }

          }, false);

          //drop event to allow the element to be dropped into valid targets
          document.addEventListener('drop', function (e) {
              //if this element is a drop target, move the item here 
              //then prevent default to allow the action (same as dragover)
              if (e.target.getAttribute('data-draggable') == 'target') {
                  e.target.appendChild(item);

                  e.preventDefault();
              }

          }, false);

          //dragend event to clean-up after drop or abort
          //which fires whether or not the drop target was valid
          document.addEventListener('dragend', function (e) {
              item = null;

          }, false);

      })();
  </script>


</asp:Content>

