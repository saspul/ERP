<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Budget.aspx.cs" Inherits="FMS_FMS_Master_fms_Budget_fms_Budget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>

    <script>
        var confirmbox = 0;
        var AlertCnt = 0;
        function disableMnths() {
            var DisabledMnth = "";

            var DisabledMnth = document.getElementById("<%=HiddenFieldDisabledMnts.ClientID%>").value;
            $('#tabMain input').not(".ddl").each(function () {
                var inputID = this.id;
                var res = inputID.substr(7, 3);
                if (document.getElementById("<%=HiddenFieldDisabledMnts.ClientID%>").value != "") {
                    DisabledMnth = document.getElementById("<%=HiddenFieldDisabledMnts.ClientID%>").value;
                    if (DisabledMnth.includes(res)) {
                        $(this).prop('disabled', true);
                        $(this).val('');
                    }
                }
            });
        }
        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            //document.getElementById("defaultOpen").style.backgroundColor = "#39558a";
            if (document.getElementById("cphMain_lblEntry").innerHTML != "View Monthly Budgeting") {
               // disableMnths();
            }
            //$('#tabMain input').not(".ddl").each(function () {
            //    var ObjVal = $(this).val().trim();
            //    var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
            //    if (FloatingValueMoney != "" && ObjVal != "") {
            //        ObjVal = parseFloat(ObjVal);
            //        ObjVal = ObjVal.toFixed(FloatingValueMoney);
            //        $(this).val(ObjVal);
            //    }
            //});
            if ($('#ddlLed00').length > 0) {
                document.getElementById("ddlLed00").focus();
                $("#divddlLed00> input").focus();
                $("#divddlLed00> input").select();
            }
           
            LedgerCostCentreChange('typLedger');
           // if (document.getElementById("<%=HiddenEdit.ClientID%>").value != "")
           // {
               
                //var tableOtherItemSub = document.getElementById("TableCostCentre");
                //var tableOtherItemSub1 = document.getElementById("tabMain");
                //if (tableOtherItemSub.rows.length == 1) {
                //    addMainTabRow_costCentre("0");
                //}
          
             
                //if (tableOtherItemSub1.rows.length == 1) {
                //    addMainTabRow("0");
                //}
           // }
            if (document.getElementById("<%=HiddenView.ClientID%>").value != "")
            {
                $("#cphMain_DivLedgerTable *").prop('disabled', true);
                $("#cphMain_DivCostCentre *").prop('disabled', true);
            }
          //  LoadFinancialYearId();
        });
        
        function SuccessCreateBudgt() {
            $noCon("#success-alert").html("Budget created successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            addMainTabRow("0");
            addMainTabRow_costCentre("0");
           // disableMnths();
            return false;
        }
        function SuccessMsg() {
            $noCon("#success-alert").html("Budget details saved successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdMsg() {
            $noCon("#success-alert").html("Budget details updated successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessCnfMsg() {
            $noCon("#success-alert").html("Budget details confirmed successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessDupMsgName() {
            $noCon("#divWarning").html("Duplication error! Budget name cant be duplicated.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                document.getElementById("cphMain_txtBudgtName").style.borderColor = "red";
                document.getElementById("cphMain_txtBudgtName").focus();
            });
            return false;
        }
        function SuccessDupMsgYear() {
            $noCon("#divWarning").html("Budget is already created for the selected year.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                document.getElementById("cphMain_ddlYear").style.borderColor = "red";
                document.getElementById("cphMain_ddlYear").focus();
            });
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
                        window.location.href = "fms_Budget_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
            }
            else {
                window.location.href = "fms_Budget_List.aspx";
            }
            return false;
        }
        function isNumberDec(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if ((keyCodes == 65 || keyCodes == 86 || keyCodes == 67) && (evt.ctrlKey === true || evt.metaKey === true)) {

                return true;
            }
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
            else if (keyCodes == 34 || keyCodes == 33 || keyCodes == 36 || keyCodes == 35 || keyCodes == 41 || keyCodes == 37 || keyCodes == 39) {

                return true;
            }

          
            else if (keyCodes == 46) {
                return true;
            }
                // . period and numpad . period
            else if (keyCodes == 190 || keyCodes == 110) {
                var ret = true;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
   
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenupd" runat="server" />
    <asp:HiddenField ID="HiddenFieldQryString" runat="server" />
    <asp:HiddenField ID="HiddenFieldBudjetId" runat="server" />
    <asp:HiddenField ID="HiddenFieldDecimalCnt" runat="server" />
    <asp:HiddenField ID="HiddenFieldTableId" runat="server" />
    <asp:HiddenField ID="HiddenFieldBudgtDataLedgr" runat="server" />
    <asp:HiddenField ID="HiddenFieldBudgtDataCostCentr" runat="server" />
    <asp:HiddenField ID="HiddenFieldName" runat="server" />
    <asp:HiddenField ID="HiddenFieldYear" runat="server" />
    <asp:HiddenField ID="HiddenFieldLedgerOrCC" runat="server" />
    <asp:HiddenField ID="HiddenLedgerRowCount" runat="server" />
    <asp:HiddenField ID="HiddenEdit" runat="server" />
    <asp:HiddenField ID="HiddenView" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYrId" runat="server" />
    <asp:HiddenField ID="HiddenFieldMode" runat="server" />
    <asp:HiddenField ID="HiddenFieldDisabledMnts" runat="server" />
     <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
     <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />

   <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="fms_Budget_List.aspx">Monthly Budgeting List</a></li>
        <li class="active">Add Monthly Budgeting</li>
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
                <h2>
                    <asp:Label ID="lblEntry" runat="server"> </asp:Label>
                </h2>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Budget Name: <span class="spn1">&nbsp;</span></label>
                    <input class="form-control fg2_inp1" id="txtBudgtName" onkeypress="return isTag(event)" autocomplete="off" onkeydown="return isTag(event)" type="text" runat="server" style="text-transform: uppercase;" maxlength="100" />
                </div>


                <div class="form-group fg2">
                    <label for="ddlYear" class="fg2_la1">Year<span class="spn1"></span>:</label>
                    <select class="form-control fg2_inp1 fg_chs1" id="ddlYear" runat="server" onkeypress="return isTag(event)" onkeydown="return isTag(event)">
                    </select>
                    <select style="display: none;" class="form-control" id="ddlMainCostCenter" runat="server" onkeypress="return isTag(event)" onkeydown="return isTag(event)">
                    </select>
                    <select style="display: none;" class="form-control" id="ddlMainLedger" runat="server" onkeypress="return isTag(event)" onkeydown="return isTag(event)">
                    </select>
                </div>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Mode<span class="spn1"></span>:</label>
                    <select class="form-control fg2_inp1 fg_chs1" id="ddlMode" runat="server" onkeypress="return isTag(event)" onkeydown="return isTag(event)">
                        <option value="0">Income</option>
                        <option value="1">Expense</option>
                    </select>
                </div>

                <div class="fg2">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnCreateBudgt" runat="server" OnClientClick="return ValidateCreateBdgt();" OnClick="btnCreateBudgt_Click" class="btn tab_but1 butn5" Text="Create Budget" />
                </div>

                <div class="clearfix"></div>
                <div class="devider"></div>

                <div id="DivModeType" runat="server" >

                    <button class="tab_mn " onclick="return LedgerCostCentreChange('typLedger'); " id="defaultOpen">Ledger</button>
                <button class="tab_mn" onclick="return LedgerCostCentreChange('typCostCenter');" id="btnCostcentre">Cost Centre</button>

                    <div class="smart-form" style="float: left; width: 99%;display:none;" >
                        <div class="inline-group" style="background-color: #f5f5f5; padding-left: 6%; padding-top: 3px; float: left; margin-bottom: 1px; margin-left: 12%;">
                            <label class="radio">
                                <input type="radio" tabindex="5" checked="true" onkeypress="return DisableEnter(event)" onchange=" LedgerCostCentreChange('typLedger');" runat="server" id="typLedger" style="display: block" name="optradio" />
                                <i></i>Ledger</label>
                            <label class="radio">
                                <input type="radio" id="typCostCenter" tabindex="6" onkeypress="return DisableEnter(event)" onchange="LedgerCostCentreChange('typCostCenter');" runat="server" style="display: block" name="optradio" />
                                <i></i>Cost Centre</label>
                        </div>
                    </div>
                </div>
                
                <script>
                    function openPage(pageName, elmnt, color) {
                        var i, tabcontent, tablinks;
                        tabcontent = document.getElementsByClassName("tab_mn_cnt");

                        for (i = 0; i < tabcontent.length; i++) {
                            tabcontent[i].style.display = "none";
                        }
                        tablinks = document.getElementsByClassName("tab_mn");
                        for (i = 0; i < tablinks.length; i++) {
                            tablinks[i].style.backgroundColor = "";
                        }
                        document.getElementById(pageName).style.display = "block";
                        elmnt.style.backgroundColor = color;
                    }

                    // Get the element with id="defaultOpen" and click on it
                    //document.getElementById("defaultOpen").click(600);
                </script>
                <div id="DivLedgerTable" runat="server" class="tab_mn_cnt">
                    <table class="table table-bordered table-responsive" id="tabMain">
                        <thead class="thead1">
                            <tr>
                                <th class="th_b3 tr_l">Particulars</th>
                                <th class="" colspan="6">Monthly Budgeting</th>
                                <th class="th_b6">Total</th>
                                <th class="th_b8">Actions</th>
                            </tr>
                        </thead>

                        <tbody id="tabMainBody" runat="server">
                        </tbody>
                    </table>
                </div>

                <div id="DivCostCentre" runat="server" class="tab_mn_cnt">
                    <table class="table table-bordered table-responsive" id="TableCostCentre">
                        <thead class="thead1">
                            <tr>
                                <th class="th_b3 tr_l">Particulars</th>
                                <th class="" colspan="6">Monthly Budgeting</th>
                                <th class="th_b6">Total</th>
                                <th class="th_b8">Actions</th>
                            </tr>
                        </thead>
                        <tbody id="TableCostCentreBody" runat="server">
                        </tbody>
                    </table>
                </div>

                

                <div class="sub_cont pull-right">
                    <asp:Button ID="bttnsave" runat="server" OnClientClick="return ValidateBudgt(this);" OnClick="bttnsave_Click" class="btn sub1" Text="Save" />
                    <asp:Button ID="bttnsavecls" runat="server" OnClientClick="return ValidateBudgt(this);" OnClick="bttnsave_Click" class="btn sub3" Text="Save & Close" />
                    <asp:Button ID="btnUpdate" runat="server" OnClientClick="return ValidateBudgt(this);" OnClick="btnUpdate_Click" class="btn sub1" Text="Update" />
                    <asp:Button ID="btnUpdatecls" runat="server" OnClientClick="return ValidateBudgt(this);" OnClick="btnUpdate_Click" class="btn sub3" Text="Update & Close" />

                    <%--<asp:Button ID="btnUpdatecls" runat="server" OnClientClick="return ValidateReceiptAccnt(this);" OnClick="btnUpdate_Click" class="btn sub3" Text="Update & Close" />--%>
                    <asp:Button ID="btnConfirm" runat="server" OnClientClick="return ValidateBudgt(this);" OnClick="btnConfirm_Click" class="btn sub2" Text="Confirm" />
                       <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                    <asp:Button ID="btnCancel" runat="server" OnClientClick="return ConfirmMessage();" class="btn sub4" Text="Cancel" />


                </div>

                <div id="divList" class="list_b" runat="server" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
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
                    messageText: "Are you sure you want to clear this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Budget.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "fms_Budget.aspx";
                return false;
            }
        }

        function ValidateCreateBdgt() {
            var ret = true;
            var BudgtNAme = document.getElementById("cphMain_txtBudgtName").value.trim();
            document.getElementById("cphMain_txtBudgtName").style.borderColor = "";
            if (BudgtNAme == "") {
                document.getElementById("cphMain_txtBudgtName").style.borderColor = "red";
                document.getElementById("cphMain_txtBudgtName").focus();
                ret = false;
            }
            if (ret == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
        }
        function Validate_addMainTabRow(validRowID) {
            var ret = true;
            var LedgerCnt = 0;
      
            $("divddlLed" + validRowID + "0> input").css("borderColor", "");
            document.getElementById("ddlLed" + validRowID + "0").style.borderColor = "";
            document.getElementById("txtAmntJan" + validRowID + "0").style.borderColor = "";
            document.getElementById("txtAmntFeb" + validRowID + "0").style.borderColor = "";
            document.getElementById("txtAmntMar" + validRowID + "0").style.borderColor = "";
            document.getElementById("txtAmntApr" + validRowID + "0").style.borderColor = "";
            document.getElementById("txtAmntMay" + validRowID + "0").style.borderColor = "";
            document.getElementById("txtAmntJun" + validRowID + "0").style.borderColor = "";
            document.getElementById("txtAmntJul" + validRowID + "0").style.borderColor = "";
            document.getElementById("txtAmntAug" + validRowID + "0").style.borderColor = "";
            document.getElementById("txtAmntSep" + validRowID + "0").style.borderColor = "";
            document.getElementById("txtAmntOct" + validRowID + "0").style.borderColor = "";
            document.getElementById("txtAmntNov" + validRowID + "0").style.borderColor = "";
            document.getElementById("txtAmntDec" + validRowID + "0").style.borderColor = "";

            var Ledgr = document.getElementById("ddlLed" + validRowID + "0").value;
            var LedgrAmntJan = document.getElementById("txtAmntJan" + validRowID + "0").value.trim();
            var LedgrAmntFeb = document.getElementById("txtAmntFeb" + validRowID + "0").value.trim();
            var LedgrAmntMar = document.getElementById("txtAmntMar" + validRowID + "0").value.trim();
            var LedgrAmntApr = document.getElementById("txtAmntApr" + validRowID + "0").value.trim();
            var LedgrAmntMay = document.getElementById("txtAmntMay" + validRowID + "0").value.trim();
            var LedgrAmntJun = document.getElementById("txtAmntJun" + validRowID + "0").value.trim();
            var LedgrAmntJul = document.getElementById("txtAmntJul" + validRowID + "0").value.trim();
            var LedgrAmntAug = document.getElementById("txtAmntAug" + validRowID + "0").value.trim();
            var LedgrAmntSep = document.getElementById("txtAmntSep" + validRowID + "0").value.trim();
            var LedgrAmntOct = document.getElementById("txtAmntOct" + validRowID + "0").value.trim();
            var LedgrAmntNov = document.getElementById("txtAmntNov" + validRowID + "0").value.trim();
            var LedgrAmntDec = document.getElementById("txtAmntDec" + validRowID + "0").value.trim();
          
            if (LedgrAmntJan == "" && LedgrAmntFeb == "" && LedgrAmntMar == "" && LedgrAmntApr == "" && LedgrAmntMay == "" && LedgrAmntJun == "" && LedgrAmntJul == "" && LedgrAmntAug == "" && LedgrAmntSep == "" && LedgrAmntOct == "" && LedgrAmntNov == "" && LedgrAmntDec == "") {
                LedgerCnt++;
                ret = false;
            }
            if (Ledgr == "-Select Ledger-" || Ledgr == "") {
                $("#divddlLed" + validRowID + "0> input").css("borderColor", "red");
                $("#divddlLed" + validRowID + "0> input").focus();
                $("#divddlLed" + validRowID + "0> input").select();
                document.getElementById("ddlLed" + validRowID + "0").style.borderColor = "red";
                document.getElementById("ddlLed" + validRowID + "0").focus();
                ret = false;
            }
            if (ret == false) {
                if (LedgerCnt == 0)
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                else
                    $("#divWarning").html("Please enter ledger amount against atleast one month.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            else {
                $('#btnAddMain' + validRowID + "0").attr("disabled", "disabled");
                document.getElementById("btnAddMain" + validRowID + "0").style.opacity = "0.3";
                addMainTabRow("1");
                return false;
            }
        }


        function Validate_addMainTab_CC(validRowID) {
            var ret = true;
            var LedgerCnt = 0;
            $("divddlCost" + validRowID + "1> input").css("borderColor", "");
            document.getElementById("txtAmntJan" + validRowID + "1").style.borderColor = "";
            document.getElementById("txtAmntFeb" + validRowID + "1").style.borderColor = "";
            document.getElementById("txtAmntMar" + validRowID + "1").style.borderColor = "";
            document.getElementById("txtAmntApr" + validRowID + "1").style.borderColor = "";
            document.getElementById("txtAmntMay" + validRowID + "1").style.borderColor = "";
            document.getElementById("txtAmntJun" + validRowID + "1").style.borderColor = "";
            document.getElementById("txtAmntJul" + validRowID + "1").style.borderColor = "";
            document.getElementById("txtAmntAug" + validRowID + "1").style.borderColor = "";
            document.getElementById("txtAmntSep" + validRowID + "1").style.borderColor = "";
            document.getElementById("txtAmntOct" + validRowID + "1").style.borderColor = "";
            document.getElementById("txtAmntNov" + validRowID + "1").style.borderColor = "";
            document.getElementById("txtAmntDec" + validRowID + "1").style.borderColor = "";

            var Cost = document.getElementById("ddlCost" + validRowID + "1").value;
            var CostAmntJan = document.getElementById("txtAmntJan" + validRowID + "1").value.trim();
            var CostAmntFeb = document.getElementById("txtAmntFeb" + validRowID + "1").value.trim();
            var CostAmntMar = document.getElementById("txtAmntMar" + validRowID + "1").value.trim();
            var CostAmntApr = document.getElementById("txtAmntApr" + validRowID + "1").value.trim();
            var CostAmntMay = document.getElementById("txtAmntMay" + validRowID + "1").value.trim();
            var CostAmntJun = document.getElementById("txtAmntJun" + validRowID + "1").value.trim();
            var CostAmntJul = document.getElementById("txtAmntJul" + validRowID + "1").value.trim();
            var CostAmntAug = document.getElementById("txtAmntAug" + validRowID + "1").value.trim();
            var CostAmntSep = document.getElementById("txtAmntSep" + validRowID + "1").value.trim();
            var CostAmntOct = document.getElementById("txtAmntOct" + validRowID + "1").value.trim();
            var CostAmntNov = document.getElementById("txtAmntNov" + validRowID + "1").value.trim();
            var CostAmntDec = document.getElementById("txtAmntDec" + validRowID + "1").value.trim();
          
            if (CostAmntJan == "" && CostAmntFeb == "" && CostAmntMar == "" && CostAmntApr == "" && CostAmntMay == "" && CostAmntJun == "" && CostAmntJul == "" && CostAmntAug == "" && CostAmntSep == "" && CostAmntOct == "" && CostAmntNov == "" && CostAmntDec == "") {
                LedgerCnt++;
                ret = false;
            }
            if (Cost == "-Select Cost Center-" || Cost == "") {
                $("#divddlCost" + validRowID + "1> input").css("borderColor", "red");
                $("#divddlCost" + validRowID + "1> input").focus();
                $("#divddlCost" + validRowID + "1> input").select();
                document.getElementById("ddlCost" + validRowID + "1").style.borderColor = "red";
                document.getElementById("ddlCost" + validRowID + "1").focus();
                ret = false;
            }
            if (ret == false) {
                if (LedgerCnt == 0)
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                else
                    $("#divWarning").html("Please enter cost centre amount against atleast one month.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            else {
                $('#btnAddSub' + validRowID + "1").attr("disabled", "disabled");
                document.getElementById("btnAddSub" + validRowID + "1").style.opacity = "0.3";
                addMainTabRow_costCentre("1");
                return false;
            }
        }
        function ValidateBudgt(ClickedBtn) {
            LedgerCnt = 0;
            var ret = true;
           
            document.getElementById("<%=HiddenFieldBudgtDataLedgr.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldBudgtDataCostCentr.ClientID%>").value = "";
            //if (document.getElementById("<%=HiddenFieldLedgerOrCC.ClientID%>").value == "0") {

            var tableOtherItem = document.getElementById("tabMain");
            var flagLed = 0;
            for (var i = 1; i < tableOtherItem.rows.length ; i++) {
              
                var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                $("divddlLed" + validRowID + "> input").css("borderColor", "");
                document.getElementById("ddlLed" + validRowID).style.borderColor = "";
                document.getElementById("txtAmntJan" + validRowID).style.borderColor = "";
                document.getElementById("txtAmntFeb" + validRowID).style.borderColor = "";
                document.getElementById("txtAmntMar" + validRowID).style.borderColor = "";
                document.getElementById("txtAmntApr" + validRowID).style.borderColor = "";
                document.getElementById("txtAmntMay" + validRowID).style.borderColor = "";
                document.getElementById("txtAmntJun" + validRowID).style.borderColor = "";
                document.getElementById("txtAmntJul" + validRowID).style.borderColor = "";
                document.getElementById("txtAmntAug" + validRowID).style.borderColor = "";
                document.getElementById("txtAmntSep" + validRowID).style.borderColor = "";
                document.getElementById("txtAmntOct" + validRowID).style.borderColor = "";
                document.getElementById("txtAmntNov" + validRowID).style.borderColor = "";
                document.getElementById("txtAmntDec" + validRowID).style.borderColor = "";

                var Ledgr = document.getElementById("ddlLed" + validRowID).value;
                var LedgrAmntJan = document.getElementById("txtAmntJan" + validRowID).value.trim();
                var LedgrAmntFeb = document.getElementById("txtAmntFeb" + validRowID).value.trim();
                var LedgrAmntMar = document.getElementById("txtAmntMar" + validRowID).value.trim();
                var LedgrAmntApr = document.getElementById("txtAmntApr" + validRowID).value.trim();
                var LedgrAmntMay = document.getElementById("txtAmntMay" + validRowID).value.trim();
                var LedgrAmntJun = document.getElementById("txtAmntJun" + validRowID).value.trim();
                var LedgrAmntJul = document.getElementById("txtAmntJul" + validRowID).value.trim();
                var LedgrAmntAug = document.getElementById("txtAmntAug" + validRowID).value.trim();
                var LedgrAmntSep = document.getElementById("txtAmntSep" + validRowID).value.trim();
                var LedgrAmntOct = document.getElementById("txtAmntOct" + validRowID).value.trim();
                var LedgrAmntNov = document.getElementById("txtAmntNov" + validRowID).value.trim();
                var LedgrAmntDec = document.getElementById("txtAmntDec" + validRowID).value.trim();
                

                if ((LedgrAmntJan == "" || LedgrAmntJan == 0) && (LedgrAmntFeb == "" || LedgrAmntFeb == 0) && (LedgrAmntMar == "" || LedgrAmntMar == 0) && (LedgrAmntApr == "" || LedgrAmntApr == 0) && (LedgrAmntMay == "" || LedgrAmntMay == 0) && (LedgrAmntJun == "" || LedgrAmntJun == 0) && (LedgrAmntJul == "" || LedgrAmntJul == 0) && (LedgrAmntAug == "" || LedgrAmntAug == 0) && (LedgrAmntSep == "" || LedgrAmntSep == 0) && (LedgrAmntOct == "" || LedgrAmntOct == 0) && (LedgrAmntNov == "" || LedgrAmntNov == 0) && (LedgrAmntDec == "" || LedgrAmntDec == 0) && (Ledgr == "-Select Ledger-" || Ledgr == "")) {
                    flagLed = 1;
                   
                }
                else {
                  
                  
                    if (Ledgr == "-Select Ledger-" || Ledgr == "") {
                        
                        $("#divddlLed" + validRowID + "> input").css("borderColor", "red");
                        $("#divddlLed" + validRowID + "> input").focus();
                        $("#divddlLed" + validRowID + "> input").select();
                       
                        document.getElementById("ddlLed" + validRowID ).style.borderColor = "red";
                        document.getElementById("ddlLed" + validRowID ).focus();
                        ret = false;
                    }
                    if ((LedgrAmntJan == "" || LedgrAmntJan == 0) && (LedgrAmntFeb == "" || LedgrAmntFeb == 0) && (LedgrAmntMar == "" || LedgrAmntMar == 0) && (LedgrAmntApr == "" || LedgrAmntApr == 0) && (LedgrAmntMay == "" || LedgrAmntMay == 0) && (LedgrAmntJun == "" || LedgrAmntJun == 0) && (LedgrAmntJul == "" || LedgrAmntJul == 0) && (LedgrAmntAug == "" || LedgrAmntAug == 0) && (LedgrAmntSep == "" || LedgrAmntSep == 0) && (LedgrAmntOct == "" || LedgrAmntOct == 0) && (LedgrAmntNov == "" || LedgrAmntNov == 0) && (LedgrAmntDec == "" || LedgrAmntDec == 0)) {

                        LedgerCnt++;
                        ret = false;
                    }
                }
            }

         
            // if (document.getElementById("<%=HiddenFieldLedgerOrCC.ClientID%>").value == "1") {
            var tableOtherItemSub = document.getElementById("TableCostCentre");
           
            var flagCC = 0;
            for (var j = 1; j < tableOtherItemSub.rows.length; j++) {
             
                var validRowIDSub = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                var CostCnt = 0;
                $("divddlCost" + validRowIDSub + "> input").css("borderColor", "");
                document.getElementById("ddlCost" + validRowIDSub).style.borderColor = "";
                document.getElementById("txtAmntJan" + validRowIDSub).style.borderColor = "";
                document.getElementById("txtAmntFeb" + validRowIDSub).style.borderColor = "";
                document.getElementById("txtAmntMar" + validRowIDSub).style.borderColor = "";
                document.getElementById("txtAmntApr" + validRowIDSub).style.borderColor = "";
                document.getElementById("txtAmntMay" + validRowIDSub).style.borderColor = "";
                document.getElementById("txtAmntJun" + validRowIDSub).style.borderColor = "";
                document.getElementById("txtAmntJul" + validRowIDSub).style.borderColor = "";
                document.getElementById("txtAmntAug" + validRowIDSub).style.borderColor = "";
                document.getElementById("txtAmntSep" + validRowIDSub).style.borderColor = "";
                document.getElementById("txtAmntOct" + validRowIDSub).style.borderColor = "";
                document.getElementById("txtAmntNov" + validRowIDSub).style.borderColor = "";
                document.getElementById("txtAmntDec" + validRowIDSub).style.borderColor = "";

                var Cost = document.getElementById("ddlCost" + validRowIDSub).value;
                var CostAmntJan = document.getElementById("txtAmntJan" + validRowIDSub).value.trim();
                var CostAmntFeb = document.getElementById("txtAmntFeb" + validRowIDSub).value.trim();
                var CostAmntMar = document.getElementById("txtAmntMar" + validRowIDSub).value.trim();
                var CostAmntApr = document.getElementById("txtAmntApr" + validRowIDSub).value.trim();
                var CostAmntMay = document.getElementById("txtAmntMay" + validRowIDSub).value.trim();
                var CostAmntJun = document.getElementById("txtAmntJun" + validRowIDSub).value.trim();
                var CostAmntJul = document.getElementById("txtAmntJul" + validRowIDSub).value.trim();
                var CostAmntAug = document.getElementById("txtAmntAug" + validRowIDSub).value.trim();
                var CostAmntSep = document.getElementById("txtAmntSep" + validRowIDSub).value.trim();
                var CostAmntOct = document.getElementById("txtAmntOct" + validRowIDSub).value.trim();
                var CostAmntNov = document.getElementById("txtAmntNov" + validRowIDSub).value.trim();
                var CostAmntDec = document.getElementById("txtAmntDec" + validRowIDSub).value.trim();
              
                if (CostAmntJan == "" && CostAmntFeb == "" && CostAmntMar == "" && CostAmntApr == "" && CostAmntMay == "" && CostAmntJun == "" && CostAmntJul == "" && CostAmntAug == "" && CostAmntSep == "" && CostAmntOct == "" && CostAmntNov == "" && CostAmntDec == "" && (Cost == "-Select Cost Centre-" || Cost == "")) {
                   
                  
                }
                else
                {
                    flagCC = 1;
                    if ((CostAmntJan == "" || CostAmntJan == 0) && (CostAmntFeb == "" || CostAmntFeb == 0) && (CostAmntMar == "" || CostAmntMar == 0) && (CostAmntApr == "" || CostAmntApr == 0) && (CostAmntMay == "" || CostAmntMay == 0) && (CostAmntJun == "" || CostAmntJun == 0) && (CostAmntJul == "" || CostAmntJul == 0) && (CostAmntAug == "" || CostAmntAug == 0) && (CostAmntSep == "" || CostAmntSep == 0) && (CostAmntOct == "" || CostAmntOct == 0) && (CostAmntNov == "" || CostAmntNov == 0) && (CostAmntDec == "" || CostAmntDec == 0)) {
                        CostCnt++;
                        
                        ret = false;
                    }
                    

                    if (Cost == "-Select Cost Centre-" || Cost == "")
                    {
                       
                        $("#divddlCost" + validRowIDSub + "> input").css("borderColor", "red");
                        $("#divddlCost" + validRowIDSub + "> input").focus();
                        $("#divddlCost" + validRowIDSub + "> input").select();
                        document.getElementById("ddlCost" + validRowIDSub).style.borderColor = "red";
                        document.getElementById("ddlCost" + validRowIDSub).focus();
                        ret = false;
                    }
                }
            }
          
            //  }
         
                if ((flagCC == 0 && flagLed==1 )||(flagCC == 0 && flagLed==1 )) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (ret == false) {
                if (document.getElementById("<%=HiddenFieldLedgerOrCC.ClientID%>").value == "0") {
                    if (LedgerCnt == 0)
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    else
                        $("#divWarning").html("Please enter ledger amount against atleast one month.");
                }
                if (document.getElementById("<%=HiddenFieldLedgerOrCC.ClientID%>").value == "1") {
                    if (CostCnt == 0)
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    else
                        $("#divWarning").html("Please enter cost centre amount against atleast one month.");
                }
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
          //  alert("");
            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];

            var tbClientJobShedulingCost = '';
            tbClientJobShedulingCost = [];

            //   if (document.getElementById("<%=HiddenFieldLedgerOrCC.ClientID%>").value == "0") {
            var tableOtherItem = document.getElementById("tabMain");
            for (var i = 1; i < tableOtherItem.rows.length; i++)
            {
                var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                var TabId = (tableOtherItem.rows[i].cells[1].innerHTML);
                var Ledgr = document.getElementById("ddlLed" + validRowID).value;
                if (Ledgr != "-Select Ledger-" && Ledgr != "")
                {
                   
                    var LedgrAmntJan = document.getElementById("txtAmntJan" + validRowID).value.trim();
                    var LedgrAmntFeb = document.getElementById("txtAmntFeb" + validRowID).value.trim();
                    var LedgrAmntMar = document.getElementById("txtAmntMar" + validRowID).value.trim();
                    var LedgrAmntApr = document.getElementById("txtAmntApr" + validRowID).value.trim();
                    var LedgrAmntMay = document.getElementById("txtAmntMay" + validRowID).value.trim();
                    var LedgrAmntJun = document.getElementById("txtAmntJun" + validRowID).value.trim();
                    var LedgrAmntJul = document.getElementById("txtAmntJul" + validRowID).value.trim();
                    var LedgrAmntAug = document.getElementById("txtAmntAug" + validRowID).value.trim();
                    var LedgrAmntSep = document.getElementById("txtAmntSep" + validRowID).value.trim();
                    var LedgrAmntOct = document.getElementById("txtAmntOct" + validRowID).value.trim();
                    var LedgrAmntNov = document.getElementById("txtAmntNov" + validRowID).value.trim();
                    var LedgrAmntDec = document.getElementById("txtAmntDec" + validRowID).value.trim();
                    var LedgrTotalAmt = document.getElementById("txtTotal" + validRowID).value.trim();

                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        MAINTABID: "" + validRowID + "",
                        LEDGRTABID: "" + TabId + "",
                        LEDGRID: "" + Ledgr + "",
                        LEDGRAMNTJAN: "" + LedgrAmntJan + "",
                        LEDGRAMNTFEB: "" + LedgrAmntFeb + "",
                        LEDGRAMNTMAR: "" + LedgrAmntMar + "",
                        LEDGRAMNTAPR: "" + LedgrAmntApr + "",
                        LEDGRAMNTMAY: "" + LedgrAmntMay + "",
                        LEDGRAMNTJUN: "" + LedgrAmntJun + "",
                        LEDGRAMNTJUL: "" + LedgrAmntJul + "",
                        LEDGRAMNTAUG: "" + LedgrAmntAug + "",
                        LEDGRAMNTSEP: "" + LedgrAmntSep + "",
                        LEDGRAMNTOCT: "" + LedgrAmntOct + "",
                        LEDGRAMNTNOV: "" + LedgrAmntNov + "",
                        LEDGRAMNTDEC: "" + LedgrAmntDec + "",
                        LEDGRTOTALAMT: "" + LedgrTotalAmt + ""
                    });
                    tbClientJobSheduling.push(client);
                }
            }
            //  }
            //   if (document.getElementById("<%=HiddenFieldLedgerOrCC.ClientID%>").value == "1") {
            var tableOtherItemSub = document.getElementById("TableCostCentre");
            for (var j = 1; j < tableOtherItemSub.rows.length; j++) {
                var validRowID = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                var CostTabId = (tableOtherItemSub.rows[j].cells[1].innerHTML);
                var CostCentrId = document.getElementById("ddlCost" + validRowID).value;
                if (CostCentrId != "-Select Cost Centre-" && CostCentrId != "") {
                    var CostCentrAmntJan = document.getElementById("txtAmntJan" + validRowID).value.trim();
                    var CostCentrAmntFeb = document.getElementById("txtAmntFeb" + validRowID).value.trim();
                    var CostCentrAmntMar = document.getElementById("txtAmntMar" + validRowID).value.trim();
                    var CostCentrAmntApr = document.getElementById("txtAmntApr" + validRowID).value.trim();
                    var CostCentrAmntMay = document.getElementById("txtAmntMay" + validRowID).value.trim();
                    var CostCentrAmntJun = document.getElementById("txtAmntJun" + validRowID).value.trim();
                    var CostCentrAmntJul = document.getElementById("txtAmntJul" + validRowID).value.trim();
                    var CostCentrAmntAug = document.getElementById("txtAmntAug" + validRowID).value.trim();
                    var CostCentrAmntSep = document.getElementById("txtAmntSep" + validRowID).value.trim();
                    var CostCentrAmntOct = document.getElementById("txtAmntOct" + validRowID).value.trim();
                    var CostCentrAmntNov = document.getElementById("txtAmntNov" + validRowID).value.trim();
                    var CostCentrAmntDec = document.getElementById("txtAmntDec" + validRowID).value.trim();
                    var CostCentrTotalAmt = document.getElementById("txtTotal" + validRowID).value.trim();
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        MAINTABID: "" + validRowID + "",
                        SUBTABID: "" + "1" + "",
                        COSTCENTRTABID: "" + CostTabId + "",
                        COSTCENTRID: "" + CostCentrId + "",
                        COSTCENTRAMNTJAN: "" + CostCentrAmntJan + "",
                        COSTCENTRAMNTFEB: "" + CostCentrAmntFeb + "",
                        COSTCENTRAMNTMAR: "" + CostCentrAmntMar + "",
                        COSTCENTRAMNTAPR: "" + CostCentrAmntApr + "",
                        COSTCENTRAMNTMAY: "" + CostCentrAmntMay + "",
                        COSTCENTRAMNTJUN: "" + CostCentrAmntJun + "",
                        COSTCENTRAMNTJUL: "" + CostCentrAmntJul + "",
                        COSTCENTRAMNTAUG: "" + CostCentrAmntAug + "",
                        COSTCENTRAMNTSEP: "" + CostCentrAmntSep + "",
                        COSTCENTRAMNTOCT: "" + CostCentrAmntOct + "",
                        COSTCENTRAMNTNOV: "" + CostCentrAmntNov + "",
                        COSTCENTRAMNTDEC: "" + CostCentrAmntDec + "",
                        COSTCENTRTOTALAMT: "" + CostCentrTotalAmt + ""

                    });
                    tbClientJobShedulingCost.push(client);
                }
            }

            if (ClickedBtn.id == "cphMain_btnConfirm") {
                if (confirm("Are you sure you want to confirm?")) {
                }
                else {
                    return false;
                }
            }

            $add("#cphMain_HiddenFieldBudgtDataLedgr").val(JSON.stringify(tbClientJobSheduling));
            $add("#cphMain_HiddenFieldBudgtDataCostCentr").val(JSON.stringify(tbClientJobShedulingCost));
            return true;

        }
        







         function isTag(evt) {
             //    IncrmntConfrmCounter();
             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

             var charCode = (evt.which) ? evt.which : evt.keyCode;
             var ret = true;
             if (charCode == 60 || charCode == 62) {
                 ret = false;
             }
             if (keyCodes == 13) {
                 return false;
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
       </script>
     <script>
        
         function LedgerCostCentreChange(type) {
             if (type == "typCostCenter")
             {
                 document.getElementById('cphMain_typCostCenter').setAttribute('checked', 'checked');
                 document.getElementById('cphMain_typLedger').setAttribute('checked', 'unchecked');

                 document.getElementById("btnCostcentre").style.backgroundColor = "#39558a";
                 document.getElementById("defaultOpen").style.backgroundColor = "";
                 if (document.getElementById("<%=HiddenEdit.ClientID%>").value != "") {

                     var tableOtherItemSub = document.getElementById("TableCostCentre");
                   
                     if (tableOtherItemSub.rows.length == 1) {
                         addMainTabRow_costCentre("0");
                     }


                     
                 }

                 document.getElementById("cphMain_DivCostCentre").style.display = "block";
                 document.getElementById("cphMain_DivLedgerTable").style.display = "none";
                 document.getElementById("<%=HiddenFieldLedgerOrCC.ClientID%>").value = "1";
                 var idlast = $noCon('#TableCostCentre >tbody > tr:not(:has(>td>table)):last').attr('id');
                 var splitid = idlast.split('SubRow');
                 $("#divddlCost" + splitid[1] + "> input").focus();
                 $("#divddlCost" + splitid[1] + "> input").select();
             }
             else if (type == "typLedger") {

                 document.getElementById('cphMain_typLedger').setAttribute('checked', 'checked');
                 document.getElementById('cphMain_typCostCenter').setAttribute('checked', 'unchecked');
                 document.getElementById("defaultOpen").style.backgroundColor = "#39558a";
                 document.getElementById("btnCostcentre").style.backgroundColor = "";
                 var tableOtherItemSub1 = document.getElementById("tabMain");
                 if (tableOtherItemSub1.rows.length == 1) {
                     addMainTabRow("0");
                 }
                 document.getElementById("cphMain_DivLedgerTable").style.display = "block";
                 document.getElementById("cphMain_DivCostCentre").style.display = "none";
                 document.getElementById("<%=HiddenFieldLedgerOrCC.ClientID%>").value = "0";
                 var idlast = $noCon('#tabMain >tbody > tr:not(:has(>td>table)):last').attr('id');
                 var splitid = idlast.split('MainRow');
                 $("#divddlLed" + splitid[1] + "0> input").focus();
                 $("#divddlLed" + splitid[1] + "0> input").select();
              //   addMainTabRow("0");
             }
             return false;
         }
         function LoadFinancialYearId() {
             var finYear = "";
             if (document.getElementById("cphMain_ddlYear").value != "")
                 finYear = document.getElementById("cphMain_ddlYear").value;
             if (finYear != "") {
                 var corpid = '<%= Session["CORPOFFICEID"] %>';
                 var orgid = '<%= Session["ORGID"] %>';
                 var userid = '<%= Session["USERID"] %>';
                 $noCon.ajax({
                     type: "POST",
                     async: false,
                     url: "fms_Budget.aspx/FinancialYear",
                     data: '{finYear:"' + finYear + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '"}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (response) {
                         if (response.d!= "0") {
                             document.getElementById("<%=HiddenFinancialYrId.ClientID%>").value = response.d;
                         }
                     },
                     failure: function (response) {

                     }
                 });
             }

         }
         var x = 0;
         var LedgerFlag = 0;

         function addMainTabRow(val) {
            
           
             if (document.getElementById("<%=HiddenLedgerRowCount.ClientID%>").value != "") {
                 if (LedgerFlag == 0) {
                     x = document.getElementById("<%=HiddenLedgerRowCount.ClientID%>").value;
                     x++;
                     LedgerFlag++;
                 }
             }
             IncrmntConfrmCounter();
             //if (val == "0") {
             //    $("#cphMain_tabMainBody tr").remove();
             //}
            // var $options = $("#cphMain_ddlMainLedger > option").clone();
             var $options = $("#cphMain_ddlMainLedger > option").clone();
             var recRow = '<tr id="MainRow' + x + '">';
             recRow += '<td style="display:none;">' + x + '0</td>';
             recRow += '<td style="display:none;"></td>';

             recRow += '<td  ><span>&nbsp;</span><br>';
             recRow += '<div id="divddlLed' + x + '0"><select onblur="IncrmntConfrmCounter();" class="form-control fg2_inp4 t_bx tr_l ddl" id="ddlLed' + x + '0" onchange="return changeLedger(0,' + x + ');" onkeydown="return isTag(event);" onkeypress="return isTag(event);" >';
             recRow += '</select></div></td>';
             //recRow += '<span >';
             

             recRow += '<td  ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JANUARY\" >JAN</span>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntJan' + x + '0" type="text" autocomplete="off" onchange="CalculateLedgerAmnt(' + x + ',\'Jan\');" onkeydown="return isNumberDec(event);"   maxlength=8 onkeypress="return isNumberDec(event);"></div>';
            

             recRow += '<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"FEBRUARY\" >FEB</span>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntFeb' + x + '0" type="text" autocomplete="off" onchange="CalculateLedgerAmnt(' + x + ',\'Feb\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
             recRow += '</td>';

             recRow += '<td  ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"MARCH\" >MAR</span>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntMar' + x + '0" type="text" autocomplete="off" onchange="CalculateLedgerAmnt(' + x + ',\'Mar\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
            

             recRow += '<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"APRIL\" >APR</span>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntApr' + x + '0" type="text" autocomplete="off" onchange="CalculateLedgerAmnt(' + x + ',\'Apr\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
             recRow += '</td>';

             recRow += '<td  ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"MAY\" >MAY</span>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntMay' + x + '0" type="text" autocomplete="off" onchange="CalculateLedgerAmnt(' + x + ',\'May\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
            

             recRow += '<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JUNE\" >JUN</span>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntJun' + x + '0" type="text" autocomplete="off" onchange="CalculateLedgerAmnt(' + x + ',\'Jun\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
             recRow += '</td>';

             recRow += '<td  ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JULY\" >JUL</span>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntJul' + x + '0" type="text" autocomplete="off" onchange="CalculateLedgerAmnt(' + x + ',\'Jul\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
             

             recRow += '<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"AUGUST\" >AUG</span>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntAug' + x + '0" type="text" autocomplete="off" onchange="CalculateLedgerAmnt(' + x + ',\'Aug\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
             recRow += '</td>';

             recRow += '<td  ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"SEPTEMBER\" >SEP</span>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntSep' + x + '0" type="text" autocomplete="off" onchange="CalculateLedgerAmnt(' + x + ',\'Sep\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
            

             recRow += '<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"OCTOBER\" >OCT</span>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntOct' + x + '0" type="text" autocomplete="off" onchange="CalculateLedgerAmnt(' + x + ',\'Oct\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
             recRow += '</td>';

             recRow += '<td  ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"NOVEMBER\" >NOV</span>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntNov' + x + '0" type="text" autocomplete="off" onchange="CalculateLedgerAmnt(' + x + ',\'Nov\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
             

             recRow += '<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"DECEMBER\" >DEC</span>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntDec' + x + '0" type="text" autocomplete="off" onchange="CalculateLedgerAmnt(' + x + ',\'Dec\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
             recRow += '</td>';
             recRow += '<td ><span>&nbsp;</span><br><b>';
             recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtTotal' + x + '0" disabled type="text"  onchange="CalculateLedgerAmnt(' + x + ',\'Total\');" onkeydown="return isNumberDec(event);"  maxlength=12 onkeypress="return isNumberDec(event);">';
             recRow += '</b></td>';


             recRow += '<td><div class="btn_stl1 ltp">';
             recRow += '<button class="btn act_btn bn2"  title="Add" id="btnAddMain' + x + '0" onclick="return Validate_addMainTabRow(' + x + ');">';
             recRow += '<span class="fa fa-plus" id="Span1" >&nbsp;</span>';
             recRow += '</button>';
             recRow += '<button class="btn act_btn bn3" title="Delete"  id="btnDelMain' + x + '0" onclick="return delMainTabRow(' + x + ');">';
             recRow += '<span class="fa fa-trash" id="chevron-left" style="display: block;">&nbsp;</span>';
             recRow += '</button>';
             //recRow += '</span>';
             recRow += '</div></td>';
             recRow += '</tr>';

             //recRow += '</tr>';
             //jQuery('#TableCostCentre').append(recRow);
             jQuery('#tabMain').append(recRow);
             document.getElementById("cphMain_DivLedgerTable").style.display = "block";
             
           
            
             $("#ddlLed" + x + "0").append($options);
             document.getElementById("ddlLed" + x + "0").value = "-Select Ledger-";
             $au("#ddlLed" + x + "0").selectToAutocomplete1Letter();
            // disableMnths();
             buttnVisibile();
             $("#divddlLed" + x + "0> input").focus();
             $("#divddlLed" + x + "0> input").select();
             x++;

             if (document.getElementById("<%=HiddenEdit.ClientID%>").value == "2") {
                 $("#cphMain_DivLedgerTable *").prop('disabled', true);
             }
             return false;
         }
         var CC_No = 0;
         var CCFlag = 0;
         function addMainTabRow_costCentre(val)
         {
             if (document.getElementById("<%=HiddenLedgerRowCount.ClientID%>").value != "")
             {
                 if (CCFlag == 0) {
                     CC_No = document.getElementById("<%=HiddenLedgerRowCount.ClientID%>").value;
                     CC_No++;
                     CCFlag++;
                 }
             }
             IncrmntConfrmCounter();
             //if (val == "0") {
             //    $("#cphMain_TableCostCentreBody tr").remove();
             //}
           //  if (ValidateBudgt(this) == true) {
                 var $options1 = $("#cphMain_ddlMainCostCenter > option").clone();
              
                 var recRow = '<tr id="SubRow' + CC_No + '1">';
                 recRow += '<td style="display:none;">' + CC_No + '1</td>';
                 recRow += '<td style="display:none;"></td>';
                 recRow += '<td><span>&nbsp;</span><br>';
                 recRow += '<div id="divddlCost' + CC_No + '1"><select onblur="IncrmntConfrmCounter();" class="form-control fg2_inp4 t_bx tr_l ddl" id="ddlCost' + CC_No + '1" onchange="return changeCostCentr(1,' + CC_No + ');" onkeydown="return isTag(event);" onkeypress="return isTag(event);"  >';

                 recRow += '</select></div></td>';

                 //recRow += '<span style="display:inline-block;float:right;width:100%">';


                 recRow += '<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JANUARY\" >JAN</span>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntJan' + CC_No + '1" type="text"   autocomplete="off" onchange="CalculateCostAmnt(' + CC_No + ',' + 1 + ',\'Jan\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
                
                 recRow += '<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"FEBRUARY\" >FEB</span>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntFeb' + CC_No + '1" type="text" autocomplete="off" onchange="CalculateCostAmnt(' + CC_No + ',' + 1 + ',\'Feb\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
                 recRow += '</td>';

                 recRow += '<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"MARCH\" >MAR</span>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntMar' + CC_No + '1" type="text" autocomplete="off" onchange="CalculateCostAmnt(' + CC_No + ',' + 1 + ',\'Mar\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
                 recRow += '<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"APRIL\" >APR</span>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntApr' + CC_No + '1" type="text" autocomplete="off" onchange="CalculateCostAmnt(' + CC_No + ',' + 1 + ',\'Apr\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
                 recRow += '</td>';

                 recRow += '<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"MAY\" >MAY</span>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntMay' + CC_No + '1" type="text" autocomplete="off" onchange="CalculateCostAmnt(' + CC_No + ',' + 1 + ',\'May\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
                 recRow += '<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JUNE\" >JUN</span>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntJun' + CC_No + '1" type="text" autocomplete="off" onchange="CalculateCostAmnt(' + CC_No + ',' + 1 + ',\'Jun\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
                 recRow += '</td>';

                 recRow += '<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JULY\" >JUL</span>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntJul' + CC_No + '1" type="text" autocomplete="off" onchange="CalculateCostAmnt(' + CC_No + ',' + 1 + ',\'Jul\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
                 recRow += '<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"AUGUST\" >AUG</span>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntAug' + CC_No + '1" type="text" autocomplete="off" onchange="CalculateCostAmnt(' + CC_No + ',' + 1 + ',\'Aug\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
                 recRow += '</td>';
                 recRow += '<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"SEPTEMBER\" >SEP</span>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntSep' + CC_No + '1" type="text" autocomplete="off" onchange="CalculateCostAmnt(' + CC_No + ',' + 1 + ',\'Sep\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
                 recRow += '<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"OCTOBER\" >OCT</span>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntOct' + CC_No + '1" type="text" autocomplete="off" onchange="CalculateCostAmnt(' + CC_No + ',' + 1 + ',\'Oct\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
                 recRow += '</td>';

                 recRow += '<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"NOVEMBER\" >NOV</span>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntNov' + CC_No + '1" type="text" autocomplete="off" onchange="CalculateCostAmnt(' + CC_No + ',' + 1 + ',\'Nov\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
                 recRow += '<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"DECEMBER\" >DEC</span>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtAmntDec' + CC_No + '1" type="text" autocomplete="off" onchange="CalculateCostAmnt(' + CC_No + ',' + 1 + ',\'Dec\');" onkeydown="return isNumberDec(event);"  maxlength=8 onkeypress="return isNumberDec(event);"></div>';
                 recRow += '</td>';

                 recRow += '<td ><span>&nbsp;</span><br><b>';
                 recRow += '<input class="form-control fg2_inp2 tr_r amt_1"  value="" id="txtTotal' + CC_No + '1" disabled type="text" onkeydown="return isNumberDec(event);"  maxlength=12 onkeypress="return isNumberDec(event);">';
                 recRow += '</b></td>';

                 recRow += '<td><div class="btn_stl1 ltp">';
                 recRow += '<button class="btn act_btn bn2" title="Add" id="btnAddSub' + CC_No + '1" onclick="return Validate_addMainTab_CC(' + CC_No + ');">';
                 recRow += '<span class="fa fa-plus" id="Span3">&nbsp;</span>';
                 recRow += '</button>';
                 recRow += '<button class="btn act_btn bn3" title="Delete" id="btnDelSub' + CC_No + '1" onclick="return delSubRow(1,' + CC_No + ');">';
                 recRow += '<span class="fa fa-trash" id="Span2" style="display: block;">&nbsp;</span>';
                 recRow += '</button>';
                 recRow += '</span>';
                 recRow += '</div></td>';

                 recRow += '</tr>';

                 jQuery('#TableCostCentre').append(recRow);
               //  $('#btnAddSub' + CC_No + "1").attr("disabled", "disabled");
                // document.getElementById("btnAddSub" + CC_No + "1").style.opacity = "0.3";

                 $("#ddlCost" + +CC_No + "1").append($options1);
                // document.getElementById("ddlCost" + +CC_No + "1").value = "-Select Cost Center-";
                 $au("#ddlCost" + +CC_No + "1").selectToAutocomplete1Letter();
                 buttnVisibile();
                 $("#divddlCost" + CC_No + "1> input").focus();
                 $("#divddlCost" + CC_No + "1> input").select();
                 CC_No++;
                 if (document.getElementById("<%=HiddenEdit.ClientID%>").value == "2")
                 {
                     $("#cphMain_DivCostCentre *").prop('disabled', true);
                 }
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



               //alert(x1);
               if (isNaN(x2))
                   document.getElementById('' + textboxid + '').value = x1;
                   //return x1;
               else
                   document.getElementById('' + textboxid + '').value = x1 + "." + x2;
               // return x1 + "." + x2;
               //    alert(document.getElementById('' + textboxid + '').value);
           }

         function buttnVisibile() {
             if (document.getElementById("<%=HiddenFieldLedgerOrCC.ClientID%>").value == "0") {
                 var TableRowCount = document.getElementById("tabMain").rows.length;
                 addRowtable = document.getElementById("tabMain");
                 for (var i = 1; i < addRowtable.rows.length; i++) {
                     var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                     if (TableRowCount != 0) {
                         if (xLoop != "") {
                             if ((TableRowCount - 1) == i) {
                                 // var xLoop = $noCon('#tabMain tr:last').attr('id');
                                 document.getElementById("btnAddMain" + xLoop).style.opacity = "1";
                                 document.getElementById("btnAddMain" + xLoop).disabled = false;
                             }
                         }
                     }
                 }
             }
             if (document.getElementById("<%=HiddenFieldLedgerOrCC.ClientID%>").value == "1") {
                 var TableRowCount1 = document.getElementById("TableCostCentre").rows.length;
                 var TableRow = document.getElementById("TableCostCentre");
                 for (var i = 1; i < TableRowCount1; i++) {
                     var idlast1 = (TableRow.rows[i].cells[0].innerHTML);
                     if (TableRowCount1 != 0) {
                         if (idlast1 != "") {
                             if ((TableRowCount1 - 1) == i) {
                                 document.getElementById("btnAddSub" + idlast1).style.opacity = "1";
                                 document.getElementById("btnAddSub" + idlast1).disabled = false;

                             }
                         }
                     }
                 }
             }
         }
         
         function delSubRow(RowNum, tabNum) {
             IncrmntConfrmCounter();
             ezBSAlert({
                 type: "confirm",
                 messageText: "Are you sure you want to delete this cost center?",
                 alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                     var $options = $("#cphMain_ddlMainCostCenter > option").clone();
                     var row = document.getElementById("SubRow" + tabNum + RowNum);
                     jQuery('#SubRow' + tabNum + "" + RowNum).remove();
                     var tableOtherItemSub = document.getElementById("TableCostCentre");
                     if (tableOtherItemSub.rows.length == 1) {
                         addMainTabRow_costCentre("0");
                     }
                     buttnVisibile();
                 }
                 else {
                     return false;
                 }
             });
             
             return false;
         }
         function delMainTabRow(RowNum, tabNum) {
            
             IncrmntConfrmCounter();
             ezBSAlert({
                 type: "confirm",
                 messageText: "Are you sure you want to delete this ledger?",
                 alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                     var $options = $("#cphMain_ddlMainLedger > option").clone();

                     var $options1 = $("#cphMain_ddlMainCostCenter > option").clone();
                
                     jQuery('#MainRow' + tabNum).remove();
                     var tableOtherItemSub = document.getElementById("tabMain");
                     if (tableOtherItemSub.rows.length == 1)
                         addMainTabRow("0");
                     buttnVisibile();
                     return false;
                 }
                 else {
                     return false;
                 }
             });
             return false;
         }
         var comVar = 0;
         function changeLedger(rowId, tabNum) {
             var addRowtable = "";
             var ret = true;
             var flag = 0;
             addRowtable = document.getElementById("tabMain");
             for (var i = 1; i < addRowtable.rows.length; i++) {
                 var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                 var xLoopLdgrId = $("#ddlLed" + xLoop).val();
                 var LedgerId = $("#ddlLed" + tabNum + "" + rowId).val();
                 if (xLoop != tabNum + "" + rowId) {
                     if (xLoopLdgrId == LedgerId) {
                         $("#divddlLed" + tabNum + "" + rowId + "> input").css("borderColor", "red");
                         $("#divddlLed" + tabNum + "" + rowId + "> input").focus();
                         $("#divddlLed" + tabNum + "" + rowId + "> input").select();
                         $noCon("#divWarning").html("Ledger cant be duplicated.");
                         $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                         });
                         
                         $noCon(window).scrollTop(0);
                         flag++;
                         ret = false;
                     }
                 }
                 if (LedgerId == "" && LedgerId == "-select ledger-") {
                     $("div#divddlled" + tabNum + tabNum + " input.ui-autocomplete-input").val("-select ledger-");
                     $("#ddlled" + tabNum + tabNum).val("-select ledger-");
                 }
             }
             return ret;
         }

         function changeCostCentr(rowId, tabNum) {
             var addRowtable = "";
             var ret = true;
             var flag = 0;
             $("#divddlLed" + tabNum + "" + rowId + "> input").css("borderColor", "");
             addRowtable = document.getElementById("TableCostCentre");
             for (var i = 1; i < addRowtable.rows.length; i++) {
                 var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                 var xLoopLdgrId = $("#ddlCost" + xLoop).val();
                 var LedgerId = $("#ddlCost" + tabNum + "" + rowId).val();
                 if (xLoop != tabNum + "" + rowId) {
                     if (xLoopLdgrId == LedgerId) {
                         $("#divddlCost" + tabNum + "" + rowId + "> input").css("borderColor", "red");
                         $("#divddlCost" + tabNum + "" + rowId + "> input").focus();
                         $("#divddlCost" + tabNum + "" + rowId + "> input").select();
                         $noCon("#divWarning").html("Ledger cant be duplicated.");
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
         function CalculateLedgerAmnt(validRowID, Month) {
            
             IncrmntConfrmCounter();
             var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
             var totAmnt = 0;
             var LedgrAmntJan = 0;
             var LedgrAmntFeb = 0;
             var LedgrAmntMar = 0;
             var LedgrAmntApr = 0;
             var LedgrAmntMay = 0;
             var LedgrAmntJun = 0;
             var LedgrAmntJul = 0;
             var LedgrAmntAug = 0;
             var LedgrAmntSep = 0;
             var LedgrAmntOct = 0;
             var LedgrAmntNov = 0;
             var LedgrAmntDec = 0;
             if (document.getElementById("txtAmntJan" + validRowID + "0").value.trim() != "") {
                 //alert(document.getElementById("txtAmntJan" + validRowID + "0").value);
                 LedgrAmntJan = document.getElementById("txtAmntJan" + validRowID + "0").value.trim();
                 LedgrAmntJan = LedgrAmntJan.replace(/,/g, '');
                 //alert(LedgrAmntJan);
                 LedgrAmntJan = parseFloat(LedgrAmntJan).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntJan" + validRowID + "0").value = LedgrAmntJan;
             }
             if (document.getElementById("txtAmntFeb" + validRowID + "0").value.trim() != "") {
                 LedgrAmntFeb = document.getElementById("txtAmntFeb" + validRowID + "0").value.trim();
                 LedgrAmntFeb = LedgrAmntFeb.replace(/,/g, '');
                 LedgrAmntFeb = parseFloat(LedgrAmntFeb).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntFeb" + validRowID + "0").value = LedgrAmntFeb;
              

             }
             if (document.getElementById("txtAmntMar" + validRowID + "0").value.trim() != "") {
                 LedgrAmntMar = document.getElementById("txtAmntMar" + validRowID + "0").value.trim();
                 LedgrAmntMar = LedgrAmntMar.replace(/,/g, '');
                 LedgrAmntMar = parseFloat(LedgrAmntMar).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntMar" + validRowID + "0").value = LedgrAmntMar;
                

             }
             if (document.getElementById("txtAmntApr" + validRowID + "0").value.trim() != "") {
                 LedgrAmntApr = document.getElementById("txtAmntApr" + validRowID + "0").value.trim();
                 LedgrAmntApr = LedgrAmntApr.replace(/,/g, '');
                 LedgrAmntApr = parseFloat(LedgrAmntApr).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntApr" + validRowID + "0").value = LedgrAmntApr;
             

             }
             if (document.getElementById("txtAmntMay" + validRowID + "0").value.trim() != "") {
                 LedgrAmntMay = document.getElementById("txtAmntMay" + validRowID + "0").value.trim();
                 LedgrAmntMay = LedgrAmntMay.replace(/,/g, '');
                 LedgrAmntMay = parseFloat(LedgrAmntMay).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntMay" + validRowID + "0").value = LedgrAmntMay;
               

             }
             if (document.getElementById("txtAmntJun" + validRowID + "0").value.trim() != "") {
                 LedgrAmntJun = document.getElementById("txtAmntJun" + validRowID + "0").value.trim();
                 LedgrAmntJun = LedgrAmntJun.replace(/,/g, '');
                 LedgrAmntJun = parseFloat(LedgrAmntJun).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntJun" + validRowID + "0").value = LedgrAmntJun;
               

             }
             if (document.getElementById("txtAmntJul" + validRowID + "0").value.trim() != "") {
                 LedgrAmntJul = document.getElementById("txtAmntJul" + validRowID + "0").value.trim();
                 LedgrAmntJul = LedgrAmntJul.replace(/,/g, '');
                 LedgrAmntJul = parseFloat(LedgrAmntJul).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntJul" + validRowID + "0").value = LedgrAmntJul;
              

             }
             if (document.getElementById("txtAmntAug" + validRowID + "0").value.trim() != "") {
                 LedgrAmntAug = document.getElementById("txtAmntAug" + validRowID + "0").value.trim();
                 LedgrAmntAug = LedgrAmntAug.replace(/,/g, '');
                 LedgrAmntAug = parseFloat(LedgrAmntAug).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntAug" + validRowID + "0").value = LedgrAmntAug;
               

             }
             if (document.getElementById("txtAmntSep" + validRowID + "0").value.trim() != "") {
                 LedgrAmntSep = document.getElementById("txtAmntSep" + validRowID + "0").value.trim();
                 LedgrAmntSep = LedgrAmntSep.replace(/,/g, '');
                 LedgrAmntSep = parseFloat(LedgrAmntSep).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntSep" + validRowID + "0").value = LedgrAmntSep;
                

             }
             if (document.getElementById("txtAmntOct" + validRowID + "0").value.trim() != "") {
                 LedgrAmntOct = document.getElementById("txtAmntOct" + validRowID + "0").value.trim();
                 LedgrAmntOct = LedgrAmntOct.replace(/,/g, '');
                 LedgrAmntOct = parseFloat(LedgrAmntOct).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntOct" + validRowID + "0").value = LedgrAmntOct;
                

             }
             if (document.getElementById("txtAmntNov" + validRowID + "0").value.trim() != "") {
                 LedgrAmntNov = document.getElementById("txtAmntNov" + validRowID + "0").value.trim();
                 LedgrAmntNov = LedgrAmntNov.replace(/,/g, '');
                 LedgrAmntNov = parseFloat(LedgrAmntNov).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntNov" + validRowID + "0").value = LedgrAmntNov;
               

             }
             if (document.getElementById("txtAmntDec" + validRowID + "0").value.trim() != "") {
                 LedgrAmntDec = document.getElementById("txtAmntDec" + validRowID + "0").value.trim();
                 LedgrAmntDec = LedgrAmntDec.replace(/,/g, '');
                 LedgrAmntDec = parseFloat(LedgrAmntDec).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntDec" + validRowID + "0").value = LedgrAmntDec;
              

             }
             totAmnt = totAmnt + parseFloat(LedgrAmntJan) + parseFloat(LedgrAmntFeb) + parseFloat(LedgrAmntMar) + parseFloat(LedgrAmntApr) + parseFloat(LedgrAmntMay) + parseFloat(LedgrAmntJun) + parseFloat(LedgrAmntJul) + parseFloat(LedgrAmntAug) + parseFloat(LedgrAmntSep) + parseFloat(LedgrAmntOct) + parseFloat(LedgrAmntNov) + parseFloat(LedgrAmntDec);
             totAmnt = totAmnt.toFixed(FloatingValueMoney);
             document.getElementById("txtTotal" + validRowID + "0").value = totAmnt;
          
             addCommas("txtAmntJan" + validRowID + "0");
             addCommas("txtAmntFeb" + validRowID + "0");
             addCommas("txtAmntMar" + validRowID + "0");
             addCommas("txtAmntApr" + validRowID + "0");
             addCommas("txtAmntMay" + validRowID + "0");
             addCommas("txtAmntJun" + validRowID + "0");
             addCommas("txtAmntJul" + validRowID + "0");
             addCommas("txtAmntAug" + validRowID + "0");
             addCommas("txtAmntSep" + validRowID + "0");
             addCommas("txtAmntOct" + validRowID + "0");
             addCommas("txtAmntNov" + validRowID + "0");
             addCommas("txtAmntDec" + validRowID + "0");
             addCommas("txtTotal" + validRowID + "0");
         }
         function CalculateCostAmnt(validRowID, validRowID1, Month) {
             IncrmntConfrmCounter();
             var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
             var totAmnt = 0;
             var LedgrAmntJan = 0;
             var LedgrAmntFeb = 0;
             var LedgrAmntMar = 0;
             var LedgrAmntApr = 0;
             var LedgrAmntMay = 0;
             var LedgrAmntJun = 0;
             var LedgrAmntJul = 0;
             var LedgrAmntAug = 0;
             var LedgrAmntSep = 0;
             var LedgrAmntOct = 0;
             var LedgrAmntNov = 0;
             var LedgrAmntDec = 0;
             if (document.getElementById("txtAmntJan" + validRowID + validRowID1).value.trim() != "") {
                 LedgrAmntJan = document.getElementById("txtAmntJan" + validRowID + validRowID1).value.trim();
                 LedgrAmntJan = LedgrAmntJan.replace(/,/g, '');
                 LedgrAmntJan = parseFloat(LedgrAmntJan).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntJan" + validRowID + validRowID1).value = LedgrAmntJan;
             }
             if (document.getElementById("txtAmntFeb" + validRowID + validRowID1).value.trim() != "") {
                 LedgrAmntFeb = document.getElementById("txtAmntFeb" + validRowID + validRowID1).value.trim();
                 LedgrAmntFeb = LedgrAmntFeb.replace(/,/g, '');
                 LedgrAmntFeb = parseFloat(LedgrAmntFeb).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntFeb" + validRowID + validRowID1).value = LedgrAmntFeb;

             }
             if (document.getElementById("txtAmntMar" + validRowID + validRowID1).value.trim() != "") {
                 LedgrAmntMar = document.getElementById("txtAmntMar" + validRowID + validRowID1).value.trim();
                 LedgrAmntMar = LedgrAmntMar.replace(/,/g, '');
                 LedgrAmntMar = parseFloat(LedgrAmntMar).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntMar" + validRowID + validRowID1).value = LedgrAmntMar;

             }
             if (document.getElementById("txtAmntApr" + validRowID + validRowID1).value.trim() != "") {
                 LedgrAmntApr = document.getElementById("txtAmntApr" + validRowID + validRowID1).value.trim();
                 LedgrAmntApr = LedgrAmntApr.replace(/,/g, '');
                 LedgrAmntApr = parseFloat(LedgrAmntApr).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntApr" + validRowID + validRowID1).value = LedgrAmntApr;

             }
             if (document.getElementById("txtAmntMay" + validRowID + validRowID1).value.trim() != "") {
                 LedgrAmntMay = document.getElementById("txtAmntMay" + validRowID + validRowID1).value.trim();
                 LedgrAmntMay = LedgrAmntMay.replace(/,/g, '');
                 LedgrAmntMay = parseFloat(LedgrAmntMay).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntMay" + validRowID + validRowID1).value = LedgrAmntMay;

             }
             if (document.getElementById("txtAmntJun" + validRowID + validRowID1).value.trim() != "") {
                 LedgrAmntJun = document.getElementById("txtAmntJun" + validRowID + validRowID1).value.trim();
                 LedgrAmntJun = LedgrAmntJun.replace(/,/g, '');
                 LedgrAmntJun = parseFloat(LedgrAmntJun).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntJun" + validRowID + validRowID1).value = LedgrAmntJun;

             }
             if (document.getElementById("txtAmntJul" + validRowID + validRowID1).value.trim() != "") {
                 LedgrAmntJul = document.getElementById("txtAmntJul" + validRowID + validRowID1).value.trim();
                 LedgrAmntJul = LedgrAmntJul.replace(/,/g, '');
                 LedgrAmntJul = parseFloat(LedgrAmntJul).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntJul" + validRowID + validRowID1).value = LedgrAmntJul;

             }
             if (document.getElementById("txtAmntAug" + validRowID + validRowID1).value.trim() != "") {
                 LedgrAmntAug = document.getElementById("txtAmntAug" + validRowID + validRowID1).value.trim();
                 LedgrAmntAug = LedgrAmntAug.replace(/,/g, '');
                 LedgrAmntAug = parseFloat(LedgrAmntAug).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntAug" + validRowID + validRowID1).value = LedgrAmntAug;

             }
             if (document.getElementById("txtAmntSep" + validRowID + validRowID1).value.trim() != "") {
                 LedgrAmntSep = document.getElementById("txtAmntSep" + validRowID + validRowID1).value.trim();
                 LedgrAmntSep = LedgrAmntSep.replace(/,/g, '');
                 LedgrAmntSep = parseFloat(LedgrAmntSep).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntSep" + validRowID + validRowID1).value = LedgrAmntSep;

             }
             if (document.getElementById("txtAmntOct" + validRowID + validRowID1).value.trim() != "") {
                 LedgrAmntOct = document.getElementById("txtAmntOct" + validRowID + validRowID1).value.trim();
                 LedgrAmntOct = LedgrAmntOct.replace(/,/g, '');
                 LedgrAmntOct = parseFloat(LedgrAmntOct).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntOct" + validRowID + validRowID1).value = LedgrAmntOct;

             }
             if (document.getElementById("txtAmntNov" + validRowID + validRowID1).value.trim() != "") {
                 LedgrAmntNov = document.getElementById("txtAmntNov" + validRowID + validRowID1).value.trim();
                 LedgrAmntNov = LedgrAmntNov.replace(/,/g, '');
                 LedgrAmntNov = parseFloat(LedgrAmntNov).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntNov" + validRowID + validRowID1).value = LedgrAmntNov;

             }
             if (document.getElementById("txtAmntDec" + validRowID + validRowID1).value.trim() != "") {
                 LedgrAmntDec = document.getElementById("txtAmntDec" + validRowID + validRowID1).value.trim();
                 LedgrAmntDec = LedgrAmntDec.replace(/,/g, '');
                 LedgrAmntDec = parseFloat(LedgrAmntDec).toFixed(FloatingValueMoney);
                 document.getElementById("txtAmntDec" + validRowID + validRowID1).value = LedgrAmntDec;

             }
             totAmnt = totAmnt + parseFloat(LedgrAmntJan) + parseFloat(LedgrAmntFeb) + parseFloat(LedgrAmntMar) + parseFloat(LedgrAmntApr) + parseFloat(LedgrAmntMay) + parseFloat(LedgrAmntJun) + parseFloat(LedgrAmntJul) + parseFloat(LedgrAmntAug) + parseFloat(LedgrAmntSep) + parseFloat(LedgrAmntOct) + parseFloat(LedgrAmntNov) + parseFloat(LedgrAmntDec);
             totAmnt = totAmnt.toFixed(FloatingValueMoney);
             document.getElementById("txtTotal" + validRowID + validRowID1).value = totAmnt;
             addCommas("txtAmntJan" + validRowID + validRowID1);
             addCommas("txtAmntFeb" + validRowID + validRowID1);
             addCommas("txtAmntMar" + validRowID + validRowID1);
             addCommas("txtAmntApr" + validRowID + validRowID1);
             addCommas("txtAmntMay" + validRowID + validRowID1);
             addCommas("txtAmntJun" + validRowID + validRowID1);
             addCommas("txtAmntJul" + validRowID + validRowID1);
             addCommas("txtAmntAug" + validRowID + validRowID1);
             addCommas("txtAmntSep" + validRowID + validRowID1);
             addCommas("txtAmntOct" + validRowID + validRowID1);
             addCommas("txtAmntNov" + validRowID + validRowID1);
             addCommas("txtAmntDec" + validRowID + validRowID1);
             addCommas("txtTotal" + validRowID + validRowID1);
         }



         function changeCostAmnt(RowNum, tabNum, Month) {
             alert("");
         document.getElementById("txtAmnt" + Month + tabNum + RowNum).style.borderColor = "";
         IncrmntConfrmCounter();
         var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
         var ObjVal = document.getElementById("txtAmnt" + Month + tabNum + RowNum).value.trim();
             if (FloatingValueMoney != "" && ObjVal != "") {
                 ObjVal = parseFloat(ObjVal);
                 ObjVal = ObjVal.toFixed(FloatingValueMoney);
                             
                 document.getElementById("txtAmnt" + Month + tabNum + RowNum).value = ObjVal;
                 var totAmnt = 0;
                 var tableOtherItem = document.getElementById("tabSub"+ tabNum);
                 for (var i = 1; i < tableOtherItem.rows.length; i++) {
                     var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                     var CostAmnt = document.getElementById("txtAmnt" + Month + tabNum + validRowID).value.trim();
                     if (CostAmnt != "") {
                         totAmnt = totAmnt + parseFloat(CostAmnt);
                     }
                 }
                 var LedgrAmnt = document.getElementById("txtAmnt" + Month + tabNum+"0").value.trim();
                 if (LedgrAmnt != "" && parseFloat(totAmnt) > parseFloat(LedgrAmnt)) {
                     alert("Total Cost center amount cant be greater than ledger amount.");
                     document.getElementById("txtAmnt" + Month + tabNum + RowNum).value = "";                  
                 }
             }
             document.getElementById("txtAmnt" + Month + tabNum + RowNum).focus();
          
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
        function FillAuto() {
            $au(function () {
                $au(".ddl").selectToAutocomplete1Letter();
            });
        }
    </script>
</asp:Content>


