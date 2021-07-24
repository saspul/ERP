<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="hcm_Individual_Leave_Type.aspx.cs" Inherits="HCM_HCM_Master_hcm_LeaveMaster_hcm_leave_type_hcm_Individual_Leave_Type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
<%-- <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>--%>

 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

 <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
 <script src="/js/New%20js/date_pick/datepicker.js"></script>

 <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
 <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>

 <script src="/js/Common/Common.js"></script>
 <link rel="stylesheet" type="text/css" href="/css/New css/hcm_ns.css"/>


     <style>
         .ui-autocomplete {
             padding: 0;
             list-style: none;
             background-color: #fff;
             width: 300px;
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
         .select2-search__field {
             width:400px!important;
         }
    </style>

<script>

    var $au = jQuery.noConflict();
    $au(function () {
        $au(".ddl").selectToAutocomplete1Letter();
    });

    var confirmbox = 0;
    function IncrmntConfrmCounter() {
        confirmbox++;
        return false;
    }

    var $noCon = jQuery.noConflict();
    $noCon(window).load(function () {

        Update();

    });

    var Counter = 0;

    function AddEmpLvTyp() {


        var FrecRow = '<tr id="EmpLvTypRowId_' + Counter + '" >';
        FrecRow += '<td id="tdIdEmpLvTyp' + Counter + '" style="display: none;width:0%;">' + Counter + '</td>';
        FrecRow += '<td id="dbId_' + Counter + '" style="display: none" >0</td>';

        FrecRow += '<td id="tdChangeIcon_' + Counter + '"></td>';
        FrecRow += '<td class="tr_l"><input type="text" class="form-control fg2_inp2 myTextBox" id="ddlEmp' + Counter + '" name="ddlEmp' + Counter + '" autocomplete="off" placeholder="-Select-" maxlength="100"   onkeypress="return selectorToAutocompleteTextBox(' + Counter + ',event);" onkeydown="return selectorToAutocompleteTextBox(' + Counter + ',event);" onkeyup="IncrmntConfrmCounter()"></td>';
        FrecRow += '<td><div id="datepicker' + Counter + '" class="input-group date" data-date-format="dd-mm-yyyy"><input class="form-control inp_bdr hei_1q tr_c" type="text" id="txtStrtDate' + Counter + '" name="txtStrtDate' + Counter + '" autocomplete="off" onchange="return ChangeEmpLvTyp(' + Counter + ',\'txtStrtDate' + Counter + '\');" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" maxlength="20" /><span id="spanStrtDate' + Counter + '" class="input-group-addon date1 fnt_sz1"><i class="fa fa-calendar"></i></span></td>';

        FrecRow += '<td><div class="btn_stl1">';
        FrecRow += '<button title="Add" id="btnAddEmpLvTyp' + Counter + '" class="btn act_btn bn2" onchange="return focusMain(\'' + Counter + '\');" onclick="return CheckaddMoreRows(' + Counter + ');" ><i class="fa fa-plus-circle"></i></button>';
        FrecRow += '<button title="Delete" id="btnDeleteEmpLvTyp' + Counter + '" class="btn act_btn bn3" onchange="return focusMain(\'' + Counter + '\');" onclick="return RemoveRows(' + Counter + ');" ><i class="fa fa-trash"></i></button>';
        FrecRow += '<button title="Save" id="btnSaveEmpLvTyp' + Counter + '" class="btn act_btn bn2" onchange="return focusMain(\'' + Counter + '\');" onclick="return FuctionSaveMain(\'' + Counter + '\',0,null);" ><i class="fa fa-save"></i></button>';
        FrecRow += '<button title="Confirm" disabled id="btnConfrmEmpLvTyp' + Counter + '" class="btn act_btn bn2" onchange="return focusMain(\'' + Counter + '\');" onclick="return OpenModal(' + Counter + ')" ><i class="fa fa-check"></i></button>';
        FrecRow += '<button title="Reopen" disabled id="btnReopenEmpLvTyp' + Counter + '" class="btn act_btn bn2" onchange="return focusMain(\'' + Counter + '\');" onclick="return Reopen(' + Counter + ');"><i class="fa fa-unlock"></i></button>';
        FrecRow += '</div></td>';

        FrecRow += '<td style="display: none;"><input id="tdEmpId' + Counter + '" value="-Select-"></td>';
        FrecRow += '<td style="display: none;"><input id="tdEmpName' + Counter + '" ></td>';
        FrecRow += '<td style="display: none;"><input id="tdDate' + Counter + '" ></td>';
        FrecRow += '<td style="display: none;"><input id="tdOverRideDtls' + Counter + '" ></td>';

        FrecRow += '<td id="tdEvt' + Counter + '" style="width:0%;display: none;">INS</td>';
        FrecRow += '<td id="tdDtlId' + Counter + '" style="width:0%;display: none;">0</td>';

        FrecRow += '</tr>';

        jQuery('#tableEmpLvTyp').append(FrecRow);

        if (document.getElementById("<%=HiddenViewSts.ClientID%>").value == "1") {
            document.getElementById("btnAddEmpLvTyp" + Counter).disabled = true;
            document.getElementById("btnDeleteEmpLvTyp" + Counter).disabled = true;
            document.getElementById("btnSaveEmpLvTyp" + Counter).disabled = true;
            document.getElementById("btnConfrmEmpLvTyp" + Counter).disabled = true;
            document.getElementById("btnReopenEmpLvTyp" + Counter).disabled = true;
            document.getElementById("ddlEmp" + Counter).disabled = true;
            document.getElementById("txtStrtDate" + Counter).disabled = true;
            document.getElementById("spanStrtDate" + Counter).style.pointerEvents = "none";
        }

        $noCon('#datepicker' + Counter).datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            timepicker: false,
        }).on('changeDate', function (ev) {

            $noCon(this).datepicker('hide');
            ChangeEmpLvTyp(Counter, "txtStrtDate" + Counter);
            document.getElementById("tdDate" + Counter).value = document.getElementById("txtStrtDate" + Counter).value;

            var lastJQueryTS = 0 ;
            var send = true;
            if (typeof(event) == 'object'){
                if (event.timeStamp - lastJQueryTS < 300){
                    send = false;
                }
                lastJQueryTS = event.timeStamp;
            }
            if (send){
                post_values(this);
            }

        });

        document.getElementById("ddlEmp" + Counter).focus();

        Counter++;

    }


    var EditCounter = 0;

    function EditEmpLvTyp(ID, EMPID, EMPNAME, STRTDATE, CNFRMSTS, USEDSTS, FullCnfrmSts) {

        AddEmpLvTyp();

        document.getElementById("dbId_" + EditCounter).innerHTML = "1";
        document.getElementById("tdChangeIcon_" + EditCounter).innerHTML = "<i class=\"fa fa-hdd-o grn\" title=\"Saved\"></i>";
        document.getElementById('tdDtlId' + EditCounter).innerHTML = ID;
        document.getElementById("tdEmpId" + EditCounter).value = EMPID;
        document.getElementById("ddlEmp" + EditCounter).value = EMPNAME;
        document.getElementById("tdEmpName" + EditCounter).value = EMPNAME;
        document.getElementById("txtStrtDate" + EditCounter).value = STRTDATE;
        document.getElementById("tdEvt" + EditCounter).innerHTML = "UPD";
        document.getElementById("btnSaveAll").innerText = "Update All";
        document.getElementById("btnFloatSaveAll").innerText = "Update All";

        //if (FullCnfrmSts == "1") {
        //    document.getElementById("btnConfirmAll").style.display = "none";
        //    document.getElementById("btnFloatConfirmAll").style.display = "none";

        //    document.getElementById("btnReopenAll").style.display = "block";
        //    document.getElementById("btnFloatReopenAll").style.display = "block";
        //}
        //else {
        //    document.getElementById("btnConfirmAll").style.display = "block";
        //    document.getElementById("btnFloatConfirmAll").style.display = "block";

        //    document.getElementById("btnReopenAll").style.display = "none";
        //    document.getElementById("btnFloatReopenAll").style.display = "none";
        //}

        if ((parseInt(document.getElementById("cphMain_hiddenEmpLvTypRows").value) - 1) > parseInt(EditCounter)) {
            document.getElementById("btnAddEmpLvTyp" + EditCounter).disabled = true;
        }

        document.getElementById("btnSaveEmpLvTyp" + EditCounter).disabled = true;
        if (CNFRMSTS == "0") {
            document.getElementById("btnConfrmEmpLvTyp" + EditCounter).disabled = false;
            document.getElementById("btnReopenEmpLvTyp" + EditCounter).disabled = true;
            document.getElementById("btnDeleteEmpLvTyp" + EditCounter).disabled = false;
            document.getElementById("ddlEmp" + EditCounter).disabled = false;
            document.getElementById("txtStrtDate" + EditCounter).disabled = false;
            document.getElementById("spanStrtDate" + EditCounter).style.pointerEvents = "block";
        }
        else {
            document.getElementById("btnConfrmEmpLvTyp" + EditCounter).disabled = true;
            document.getElementById("btnReopenEmpLvTyp" + EditCounter).disabled = false;
            document.getElementById("btnDeleteEmpLvTyp" + EditCounter).disabled = true;
            document.getElementById("ddlEmp" + EditCounter).disabled = true;
            document.getElementById("txtStrtDate" + EditCounter).disabled = true;
            document.getElementById("spanStrtDate" + EditCounter).style.pointerEvents = "none";
        }

        if (document.getElementById("<%=HiddenViewSts.ClientID%>").value == "1" || USEDSTS == "1") {
            if (document.getElementById("<%=HiddenViewSts.ClientID%>").value == "1") {
                document.getElementById("btnAddEmpLvTyp" + EditCounter).disabled = true;
            }
            else {
                if ((parseInt(document.getElementById("cphMain_hiddenEmpLvTypRows").value) - 1) > parseInt(EditCounter)) {
                    document.getElementById("btnAddEmpLvTyp" + EditCounter).disabled = true;
                }
            }
            document.getElementById("btnDeleteEmpLvTyp" + EditCounter).disabled = true;
            document.getElementById("btnSaveEmpLvTyp" + EditCounter).disabled = true;
            document.getElementById("btnConfrmEmpLvTyp" + EditCounter).disabled = true;
            document.getElementById("btnReopenEmpLvTyp" + EditCounter).disabled = true;
            document.getElementById("ddlEmp" + EditCounter).disabled = true;
            document.getElementById("txtStrtDate" + EditCounter).disabled = true;
            document.getElementById("spanStrtDate" + EditCounter).style.pointerEvents = "none";
        }

        EditCounter++;

    }

    function Update() {

        var LeavTypId = document.getElementById("<%=HiddenLeaveId.ClientID%>").value;

        $("#tableEmpLvTyp").find("tr:gt(0)").remove();

        document.getElementById("<%=hiddenEmpLvTypDtls.ClientID%>").value = "";

        $.ajax({
            url: "hcm_Individual_Leave_Type.aspx/LoadDatas",
            async: false,
            data: '{ LeavTypId:"' + LeavTypId + '"}',
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                document.getElementById("<%=lblLeaveTypName.ClientID%>").innerHTML = data.d[0];
                document.getElementById("<%=hiddenEmpLvTypDtls.ClientID%>").value = data.d[1];
                document.getElementById("<%=hiddenEmpLvTypRows.ClientID%>").value = data.d[2];

                var FullCnfrmSts = data.d[3];
                document.getElementById("<%=hiddenFullConfirmSts.ClientID%>").value = data.d[3];
                document.getElementById("<%=hiddenNoOfDays.ClientID%>").value = data.d[4];
                document.getElementById("<%=hiddenPaidLevTypSts.ClientID%>").value = data.d[5]; 

                Counter = 0;
                EditCounter = 0;

                if (document.getElementById("<%=hiddenEmpLvTypDtls.ClientID%>").value != "[]" && document.getElementById("<%=hiddenEmpLvTypDtls.ClientID%>").value != "") {

                    var EditVal = document.getElementById("<%=hiddenEmpLvTypDtls.ClientID%>").value;
                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditVal.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');

                    var jsonAtt = $.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {
                            if (jsonAtt[key].ID != "") {

                                EditEmpLvTyp(jsonAtt[key].ID, jsonAtt[key].EMPID, jsonAtt[key].EMPNAME, jsonAtt[key].STRTDATE, jsonAtt[key].CNFRMSTS, jsonAtt[key].USEDSTS, FullCnfrmSts);

                            }
                        }
                    }
                }
                else {
                    AddEmpLvTyp();
                }


            }

        });

    }

    function selectorToAutocompleteTextBox(x, ev) {

        ev = (ev) ? ev : window.event;
        var keyCodes = ev.keyCode ? ev.keyCode : ev.which ? ev.which : ev.charCode;
        if (keyCodes == 39) {
            $("#ddlEmp" + x).closest('tr').next().find(':input:visible:first').focus();
            return false;
        }
        else if (keyCodes == 37) {
            $("#ddlEmp" + x).closest('tr').prev().find(':input:visible:first').focus();
            return false;
        }

        var OrgId = '<%= Session["ORGID"] %>';
        var CorpId = '<%= Session["CORPOFFICEID"] %>';

        if (CorpId != '' && CorpId != null && (!isNaN(CorpId)) && OrgId != '' && OrgId != null && (!isNaN(OrgId))) {
            $au("#ddlEmp" + x).autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "hcm_Individual_Leave_Type.aspx/LoadEmployees",
                        async: false,
                        data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",strSearchString:"' + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + '"}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    val: item.split('<,>')[0],
                                    label: item.split('<,>')[1],
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
                    document.getElementById("tdEmpId" + x).value = i.item.val;
                    document.getElementById("ddlEmp" + x).value = i.item.label;
                },
                change: function (event, ui) {
                    if (ui.item) {
                        document.getElementById("tdEmpName" + x).value = document.getElementById("ddlEmp" + x).value;
                        var EmpId = document.getElementById("tdEmpId" + x).value;

                        $.ajax({
                            url: "hcm_Individual_Leave_Type.aspx/LoadEmpDate",
                            async: false,
                            data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",EmpId:"' + EmpId + '"}',
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                document.getElementById("txtStrtDate" + x).value = data.d;
                            }

                        });

                        ChangeEmpLvTyp(x, "ddlEmp" + x);

                    }
                    else {
                        document.getElementById("ddlEmp" + x).value = document.getElementById("tdEmpName" + x).value;
                    }
                }

            });
        }
    }


    function ChangeEmpLvTyp(x, obj) {

        RemoveTag(obj);

        if (CheckAndHighlight(x, 1, "") == true) {
            FuctionSaveMain(x, 0, null);
            document.getElementById("tdChangeIcon_" + x).innerHTML = "<i class=\"fa fa-hdd-o grn\" title=\"Saved\"></i>";
            document.getElementById("btnSaveEmpLvTyp" + x).disabled = true;
            document.getElementById("btnConfrmEmpLvTyp" + x).disabled = false;
            document.getElementById("btnReopenEmpLvTyp" + x).disabled = true;
        }
        else {
            document.getElementById("tdChangeIcon_" + x).innerHTML = "<i class=\"fa fa-spinner ble\" title=\"Editing\"></i>";
            document.getElementById("btnSaveEmpLvTyp" + x).disabled = false;
            document.getElementById("btnConfrmEmpLvTyp" + x).disabled = true;
            document.getElementById("btnReopenEmpLvTyp" + x).disabled = false;
            return false;
        }
    }

    function CheckDuplication(rowId) {
        var addRowtable = "";
        var ret = true;
        var flag = 0;
        addRowtable = document.getElementById("tableEmpLvTyp");

        for (var i = 1; i < addRowtable.rows.length; i++) {
            var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
            var xLoopLdgrId = $("#tdEmpId" + xLoop).val();
            var EmpId = $("#tdEmpId" + rowId).val();
            if (xLoop != rowId) {
                if (xLoopLdgrId == EmpId) {
                    document.getElementById("ddlEmp" + rowId).style.borderColor = "Red";
                    document.getElementById("ddlEmp" + rowId).focus();
                    $noCon("#divWarning").html("Employees cannot be duplicated.");
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

    function focusMain(CurrentRow) {
        var oldRow = document.getElementById("<%=HiddenFieldOldRow.ClientID%>").value;
        if (CurrentRow != oldRow && oldRow != "") {
            if (SaveUpdDelEmpDtls(oldRow, 0, 0, 0, null) == false) {
                return false;
            }
            if (document.getElementById("dbId_" + oldRow).innerHTML == "1") {
                document.getElementById("tdChangeIcon_" + oldRow).innerHTML = "<i class=\"fa fa-hdd-o grn\" title=\"Saved\"></i>";
            }
            else {
                document.getElementById("tdChangeIcon_" + oldRow).innerHTML = "";
            }
        }
        document.getElementById("<%=HiddenFieldOldRow.ClientID%>").value = CurrentRow;
        return false;
    }


    function CheckaddMoreRows(x, obj) {

        document.getElementById("ddlEmp" + x).style.borderColor = "";
        document.getElementById("txtStrtDate" + x).style.borderColor = "";

        if (CheckAndHighlight(x, 1, "") == true) {

            AddEmpLvTyp();

            var idlast = $('#tableEmpLvTyp tr:last').attr('id');
            var LastId = "";
            if (idlast != "") {
                var res = idlast.split("_");
                LastId = res[1];
            }
            document.getElementById("ddlEmp" + LastId).focus();
            document.getElementById("btnAddEmpLvTyp" + x).disabled = true;
            return false;
        }
        else {
            return false;
        }

        return false;
    }

    function CheckAndHighlight(x, Mode, obj) {//Mode=> 0=blur 1=save

        var ret = true;

        var Table = document.getElementById("tableEmpLvTyp");

        document.getElementById("ddlEmp" + x).style.borderColor = "";
        document.getElementById("txtStrtDate" + x).style.borderColor = "";

        var Emp = document.getElementById("ddlEmp" + x).value.trim();
        var Date = document.getElementById("txtStrtDate" + x).value.trim();

        if (Mode == "0") {
            if ((obj == "txtStrtDate" + x) && (Date == "")) {
                document.getElementById("txtStrtDate" + x).style.borderColor = "Red";
                ret = false;
            }
            if ((obj == "ddlEmp" + x) && (Emp == "-Select-" || Emp == "" || Emp == "0")) {
                document.getElementById("ddlEmp" + x).style.borderColor = "Red";
                document.getElementById("ddlEmp" + x).focus();
                ret = false;
            }
        }
        else {
            if (Date == "") {
                document.getElementById("txtStrtDate" + x).style.borderColor = "Red";
                ret = false;
            }
            if (Emp == "-Select-" || Emp == "" || Emp == "0") {
                document.getElementById("ddlEmp" + x).style.borderColor = "Red";
                document.getElementById("ddlEmp" + x).focus();
                ret = false;
            }
        }

        if (ret == true) {

            for (var i = 0; i < Table.rows.length; i++) {

                if (Table.rows[i].cells[0].innerHTML != "") {

                    var validRowID = (Table.rows[i].cells[0].innerHTML);

                    if (Mode == "0") {
                        if (obj == "ddlEmp" + x && (Emp == "-Select-" || Emp == "" || Emp == "0")) {
                            var EmpAll = document.getElementById("ddlEmp" + validRowID).value.trim();

                            if (x != validRowID && Emp == EmpAll) {
                                document.getElementById("ddlEmp" + x).style.borderColor = "Red";
                                document.getElementById("ddlEmp" + x).focus();
                                $("#divWarning").html("Employees cannot be duplicated!");
                                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                ret = false;
                            }
                        }
                    }
                    else {
                        if (Emp == "-Select-" || Emp == "" || Emp == "0") {
                            var EmpAll = document.getElementById("ddlEmp" + validRowID).value.trim();

                            if (x != validRowID && Emp == EmpAll) {
                                document.getElementById("ddlEmp" + x).style.borderColor = "Red";
                                document.getElementById("ddlEmp" + x).focus();
                                $("#divWarning").html("Employees cannot be duplicated!");
                                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                ret = false;
                            }
                        }
                    }

                    if (ret == true) {
                        if (CheckDuplication(x) == false) {
                            ret = false;
                        }
                    }
                }
            }
        }
        else {
            $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            ret = false;
        }

        return ret;
    }

    function RemoveRows(removeNum) {

        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to delete selected leave type details?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {

                var row_index = jQuery('#EmpLvTypRowId_' + removeNum).index();

                var evt = document.getElementById("tdEvt" + removeNum).innerHTML;

                document.getElementById("<%=hiddenEmpLvTypCnclDtlIds.ClientID%>").value = "";

                if (evt == "UPD") {
                    var detailId = document.getElementById("tdDtlId" + removeNum).innerHTML;

                    var CanclIds = document.getElementById("<%=hiddenEmpLvTypCnclDtlIds.ClientID%>").value;
                    if (CanclIds == '') {
                        document.getElementById("<%=hiddenEmpLvTypCnclDtlIds.ClientID%>").value = detailId;
                    }
                    else {
                        document.getElementById("<%=hiddenEmpLvTypCnclDtlIds.ClientID%>").value = document.getElementById("<%=hiddenEmpLvTypCnclDtlIds.ClientID%>").value + ',' + detailId;
                    }
                }

                jQuery('#EmpLvTypRowId_' + removeNum).remove();

                if (document.getElementById("<%=hiddenEmpLvTypCnclDtlIds.ClientID%>").value != "") {
                    FuctionSaveMain(removeNum, 2, null);
                }

                var idlast = $('#tableEmpLvTyp tr:last').attr('id');
                if (idlast != undefined) {
                    var LastId = "";
                    if (idlast != "") {
                        var res = idlast.split("_");
                        LastId = res[1];
                    }
                    document.getElementById("btnAddEmpLvTyp" + LastId).disabled = false;
                }

                var Table = document.getElementById("tableEmpLvTyp");
                if (Table.rows.length < 2) {
                    AddEmpLvTyp();
                }

            }
            else {
                return false;
            }
        });
        return false;
    }

    function ValidateEmpLvTypDtls() {

        var ret = true;
        var flag = 0;

        var Table = document.getElementById("tableEmpLvTyp");

        for (var x = 0; x < Table.rows.length; x++) {

            if (Table.rows[x].cells[0].innerHTML != "") {

                var validRowID = (Table.rows[x].cells[0].innerHTML);

                var Emp = document.getElementById("ddlEmp" + validRowID).value.trim();
                var StrtDate = document.getElementById("txtStrtDate" + validRowID).value.trim();

                if ((Table.rows.length > 1) || (Table.rows.length == 1 && (Emp != "" || StrtDate != ""))) {
                    if (CheckAndHighlight(validRowID, 1, "") == false) {
                        ret = false;
                    }
                    flag = 1;
                }

            }
        }

        if (ret == true) {

        }

        return ret;
    }

    function FuctionSaveMain(RowNum, Mode, ev) {//RowNo, Mode(0-save,1-confirm,2-delete,2-reopen), check main buttons direct click      

        if (Mode != "2") {

            if (RowNum != null) {
                if (CheckAndHighlight(RowNum, 1, "") == true) {
                    SaveUpdDelEmpDtls(RowNum, Mode, 0, 1, ev);
                }
            }
            else {
                if (ValidateEmpLvTypDtls() == true) {
                    SaveUpdDelEmpDtls(null, Mode, 1, 1, ev);
                }
            }
        }
        else {
            SaveUpdDelEmpDtls(RowNum, Mode, 0, 1, ev);
        }
        return false;
    }


    function SaveUpdDelEmpDtls(RowNum, Mode, MainMode, FocusMode, ev) {

        //Mode(0-save,1-confirm,2-delete,3-reopen)
        //MainMode(check main buttons direct click)
        //FocusMode(0-On focus,1-not on focus)

        var OrgId = '<%= Session["ORGID"] %>';
        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var UserId = '<%= Session["USERID"] %>';
        var LeaveTypId = document.getElementById("<%=HiddenLeaveId.ClientID%>").value;
        var CancelIds = document.getElementById("<%=hiddenEmpLvTypCnclDtlIds.ClientID%>").value;
        var NoOfDays = document.getElementById("<%=hiddenNoOfDays.ClientID%>").value;
        var PaidLevTypSts = document.getElementById("<%=hiddenPaidLevTypSts.ClientID%>").value; 

        var AddEmpDtls = "";

        var Table = document.getElementById("tableEmpLvTyp");
        for (var x = 0; x < Table.rows.length; x++) {

            if (Table.rows[x].cells[0].innerHTML != "") {
                var validRowID = (Table.rows[x].cells[0].innerHTML);

                var DetailId = "";
                if (document.getElementById("tdEvt" + validRowID).innerHTML == "UPD") {
                    DetailId = document.getElementById("tdDtlId" + validRowID).innerHTML;
                }
                var Emp = document.getElementById("tdEmpId" + validRowID).value;
                var StrtDate = document.getElementById("txtStrtDate" + validRowID).value.trim();
                var OverRideIds = document.getElementById("tdOverRideDtls" + validRowID).value;

                if (RowNum != null) {
                    if (validRowID == RowNum) {
                        AddEmpDtls = DetailId + "%" + Emp + "%" + StrtDate + "%" + OverRideIds;
                    }
                }
                else {
                    AddEmpDtls = AddEmpDtls + "‡" + DetailId + "%" + Emp + "%" + StrtDate + "%" + OverRideIds;
                }
            }
        }

        $.ajax({
            url: "hcm_Individual_Leave_Type.aspx/SaveUpdDelEmpDtls",
            async: false,
            data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",UserId:"' + UserId + '",LeaveTypId:"' + LeaveTypId + '",AddEmpDtls:"' + AddEmpDtls + '",Mode:"' + Mode + '",CancelIds:"' + CancelIds + '",NoOfDays:"' + NoOfDays + '",PaidLevTypSts:"' + PaidLevTypSts + '"}',
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.d != "" && data.d != "0") {


                    if (RowNum != null) {

                        if (Mode != "2") {
                            document.getElementById("tdDtlId" + RowNum).innerHTML = data.d;

                            document.getElementById("dbId_" + RowNum).innerHTML = "1";
                            document.getElementById("tdChangeIcon_" + RowNum).innerHTML = "<i class=\"fa fa-hdd-o grn\" title=\"Saved\"></i>";
                            document.getElementById("btnSaveEmpLvTyp" + RowNum).disabled = true;

                            if (document.getElementById("tdEvt" + RowNum).innerHTML == "UPD") {
                                SuccessUpdate();
                            }
                            else {
                                SuccessSave();
                            }
                        }

                        if (Mode == "1") {
                            SuccessConf();
                        }
                        else if (Mode == "3") {
                            SuccessReop();
                        }
                        else if (Mode == "2") {
                            SuccessDelete();
                        }

                        Update();

                        //var Id = data.d;
                        //var EmpId = document.getElementById("tdEmpId" + RowNum).value;
                        //var EmpName = document.getElementById("ddlEmp" + RowNum).value.trim();
                        //var Date = document.getElementById("txtStrtDate" + RowNum).value.trim();
                        //var CNFRMSTS = "0";
                        //var FullCnfrmSts = "0";
                        //if (Mode == "1") {
                        //    CNFRMSTS = "1";
                        //    if (document.getElementById("<%=hiddenFullConfirmSts.ClientID%>").value == "1") {
                        //        FullCnfrmSts = "1";
                        //    }
                        //}

                        //EditEmpLvTyp(Id, EmpId, EmpName, Date, CNFRMSTS, "0", FullCnfrmSts);

                    }
                    else {

                        Update();

                        var clickedBtnId = "";
                        if (ev != "null" && ev != null && ev != "") {
                            clickedBtnId = ev.srcElement.id;
                        }
                        if (clickedBtnId == "btnSaveAll" || clickedBtnId == "btnFloatSaveAll") {
                            if (document.getElementById("btnSaveAll").innerText == "Update All" || document.getElementById("btnFloatSaveAll").innerText == "Update All") {
                                SuccessUpdate();
                            }
                            else {
                                SuccessSave();
                            }
                        }

                        if (Mode == "1") {
                            SuccessConf();
                        }
                        else if (Mode == "3") {
                            SuccessReop();
                        }
                        else if (Mode == "2") {
                            SuccessDelete();
                        }

                    }

                }

            },
            error: function (response) {
            },
            failure: function (response) {
            }
        });

        return true;

    }


    function Confirm(RowNum) {

        if (document.getElementById("cbxOverRide" + RowNum).checked == true) {
            document.getElementById("tdOverRideDtls" + RowNum).value = $('#ddlLeaveTyps' + RowNum).val();
        }

        //$('#override_pop' + RowNum).hide();
        $('#override_pop' + RowNum).modal('hide');
        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to confirm individual leave type entry?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {

                FuctionSaveMain(RowNum, 1, null);
            }
            else {
                return false;
            }
        });
        return false;
    }

    function OpenModal(RowNum) {
        ModalOverRide(RowNum);
        //$('.overlay-bg').show();
        //$('#override_pop' + RowNum).show();
        //document.getElementById("cbxOverRide" + RowNum).focus();
        $('#override_pop' + RowNum).modal('show');
        $('#override_pop' + RowNum).on('shown.bs.modal', function () {
            document.getElementById("cbxOverRide" + RowNum).focus();
        });
        return false;
    }

    function CloseModal(RowNum) {
        //$('#override_pop' + RowNum).hide();
        //$('.overlay-bg').hide();
        $('#override_pop' + RowNum).modal('hide');
    }

    function Reopen(RowNum) {
        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to reopen individual leave type entry?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {

                FuctionSaveMain(RowNum, 3, null);
            }
            else {
                return false;
            }
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
                    window.location.href = "hcm_leave_master_list.aspx";
                }
                else {
                    return false;
                }
            });
            return false;
        }
        else {
            window.location.href = "hcm_leave_master_list.aspx";
            return false;
        }
    }

    function SuccessSave() {
        $("#success-alert").html("Individual leave type saved successfully");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function SuccessUpdate() {
        $("#success-alert").html("Individual leave type updated successfully");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function SuccessConf() {
        $("#success-alert").html("Individual leave type confirmed successfully");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function SuccessReop() {
        $("#success-alert").html("Individual leave type reopened successfully");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function SuccessDelete() {
        $("#success-alert").html("Individual leave type deleted successfully");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }


    function ModalOverRide(RowNum) {

        //var FrecRow = '<div class="overlay-content popup1" id="override_pop' + RowNum + '">';

        //FrecRow += '<div class="modal-header mo_hd1">';
        //FrecRow += '<h5 class="modal-title" id="exampleModalLabel">OVER RIDE</h5><button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return CloseModal(' + RowNum + ');"><span aria-hidden="true">&times;</span></button>';
        //FrecRow += '</div>';

        //FrecRow += '<div class="modal-body ovr_mod">';
        //FrecRow += '<div id="divcbxOverride' + RowNum + '" class="form-group fg2 fg2_mr sa_fg4">';
        //FrecRow += '<label for="cbxOverRide" class="fg2_la1 pad_l">Over ride:<span class="spn1">*</span></label>';
        //FrecRow += '<div class="check1"><label class="switch"><input id="cbxOverRide' + RowNum + '" type="checkbox" class="over_dis" onclick="return OpenLeaveTypes(' + RowNum + ');" /><span class="slider_tog round"></span></label></div>';
        //FrecRow += '</div>';
        //FrecRow += '<div class="clearfix"></div>';
        //FrecRow += '<div id="divLeaveTyps' + RowNum + '" style="display:none;" class="fg12 ovr_rid_shw">';
        //FrecRow += '<label class="mar_m1">Leave Types:</label>';
        //FrecRow += '<div class="dropdown-mul-1 wid_96 pz1">';
        //FrecRow += '<select id="ddlLeaveTyps' + RowNum + '" data-placeholder="Select LeaveTypes" multiple="" style="width:90%;"></select>';
        //FrecRow += '</div>';
        //FrecRow += '</div>';
        //FrecRow += '</div>';

        //FrecRow += '<div class="modal-footer mo_ft1">';
        //FrecRow += '<button id="btnSubmit' + RowNum + '" type="button" class="btn btn-success" onclick="return Confirm(' + RowNum + ');">Submit</button>';
        //FrecRow += '<button type="button" class="btn btn-danger" data-dismiss="modal" onclick="return CloseModal(' + RowNum + ');">Cancel</button>';
        //FrecRow += '</div>';

        //FrecRow += '</div>';


        var FrecRow = '<div class="modal fade" id="override_pop' + RowNum + '" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">';
        FrecRow += '<div class="modal-dialog" role="document">';
        FrecRow += '<div class="modal-content">';
        FrecRow += '<div class="modal-header mo_hd1"><h5 class="modal-title" id="exampleModalLabel">OVER RIDE</h5><button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>';
        FrecRow += '<div class="modal-body ovr_mod"><div id="divcbxOverride' + RowNum + '" class="form-group fg2 fg2_mr sa_fg4"><label for="cbxOverRide" class="fg2_la1 pad_l">Over ride:<span class="spn1">*</span></label>';
        FrecRow += '<div class="check1"><label class="switch"><input id="cbxOverRide' + RowNum + '" type="checkbox" class="over_dis" onclick="return OpenLeaveTypes(' + RowNum + ');" /><span class="slider_tog round"></span></label></div>';
        FrecRow += '</div><div class="clearfix"></div>';
        FrecRow += '<div id="divLeaveTyps' + RowNum + '" style="display:none;" class="fg12 ovr_rid_shw">';
        FrecRow += '<label class="mar_m1">Leave Types:</label><div class="dropdown-mul-1 wid_96 pz1">';
        FrecRow += '<div id="divddlLeaveTyps' + RowNum + '"><select id="ddlLeaveTyps' + RowNum + '" data-placeholder="Select Leave Types" multiple="" style="width:90%;"></select></div>';
        FrecRow += '</div></div></div>';
        FrecRow += '<div class="modal-footer mo_ft1">';
        FrecRow += '<button id="btnSubmit' + RowNum + '" type="button" class="btn btn-success" onclick="return Confirm(' + RowNum + ');">Submit</button>';
        FrecRow += '<button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>';
        FrecRow += '</div>';
        FrecRow += '</div></div>';

        document.getElementById("divModalOverride").innerHTML = FrecRow;


        $noCon("#ddlLeaveTyps" + RowNum).select2({
        }).on("select2:unselecting", function (e) {
            if ($noCon(e.params.args.originalEvent.currentTarget).hasClass("select2-results__option")) {
                e.preventDefault();
                $noCon(".js-example-tags").select2().trigger("close");
            }
        });

        LoadPaidLeaveTyps(RowNum);

    }

    function OpenLeaveTypes(RowNum) {
        if (document.getElementById("cbxOverRide" + RowNum).checked == true) {
            document.getElementById("divLeaveTyps" + RowNum).style.display = "block";
        }
        else {
            document.getElementById("divLeaveTyps" + RowNum).style.display = "none";
        }
    }

    function LoadPaidLeaveTyps(RowNum) {

        var OrgId = '<%= Session["ORGID"] %>';
        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var LeavTypId = document.getElementById("<%=HiddenLeaveId.ClientID%>").value;
        var EmpId = document.getElementById("tdEmpId" + RowNum).value;
        var OverRideIds = document.getElementById("<%=hiddenOverRideIds.ClientID%>").value;
        var StartDate = document.getElementById("txtStrtDate" + RowNum).value;

        $noCon.ajax({
            type: "POST",
            async: false,
            url: "hcm_Individual_Leave_Type.aspx/LoadPaidLeaveTypes",
            data: '{CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",EmpId:"' + EmpId + '",LeavTypId:"' + LeavTypId + '",StartDate:"' + StartDate + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (data) {

                $noCon("#ddlLeaveTyps" + RowNum).empty();
                $noCon("#ddlLeaveTyps" + RowNum).append(data.d);

                if (OverRideIds != "") {
                    $noCon("#ddlLeaveTyps" + RowNum).val(OverRideIds);
                }
            },
            failure: function (data) {
                alert("error");
            }

        });
    }

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:HiddenField ID="hiddenEmpLvTypDtls" runat="server" />
    <asp:HiddenField ID="hiddenEmpLvTypCnclDtlIds" runat="server" />
    <asp:HiddenField ID="hiddenEmpLvTypRows" runat="server" />
    <asp:HiddenField ID="HiddenViewSts" runat="server" />
    <asp:HiddenField ID="HiddenLeaveId" runat="server" />
    <asp:HiddenField ID="HiddenFieldOldRow" runat="server" />
    <asp:HiddenField ID="hiddenNoOfDays" runat="server" />
    <asp:HiddenField ID="hiddenOverRideIds" runat="server" />
    <asp:HiddenField ID="hiddenFullConfirmSts" runat="server" />
    <asp:HiddenField ID="hiddenPaidLevTypSts" runat="server" />

  <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
        <li><a href="/HCM/HCM_Master/hcm_LeaveMaster/hcm_leave_type/hcm_leave_master_list.aspx">Leave Type</a></li>
        <li class="active">Individual Leave Type Allocation</li>
  </ol>

    <div class="myAlert-top alert alert-success" id="success-alert"></div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning"></div>

      <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->
          
          <h1 class="h1_con h2_con">Individual Leave Type Allocation</h1>
          <h3 id="lblLeaveTypName" runat="server"></h3>
          <div class="clearfix"></div>
          <div class="devider"></div>

          <div class="tab_res">
            <div class="r_480">


              <table id="tableEmpLvTyp" class="display table-bordered pro_tab1 tbl_480" cellspacing="0" width="100%">
                <thead class="thead1">
                  <tr>
                    <th class="col-md-1"></th>
                    <th class="col-md-5 tr_l">Employee</th>
                    <th class="col-md-2">Date</th>
                    <th class="col-md-4">Actions</th>
                  </tr>
                </thead>
                <tbody>
                </tbody>
              </table>


            </div>
          </div>
        <div class="clearfix"></div>
        <div class="free_sp"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">
            <button id="btnSaveAll" type="submit" class="btn sub1" onclick="return FuctionSaveMain(null,0,event);">Save All</button>
            <button id="btnConfirmAll" type="submit" class="btn sub3" style="display:none;" onclick="return Confirm(null);">Confirm All</button>
            <button id="btnReopenAll" type="submit" class="btn sub2" style="display:none;" onclick="return Reopen(null);">Reopen All</button>
          </div>
         </div>


<!---inner_content_sections area_closed--->

<!---frame_border_area_closed---->
        </div>
      </div>
    </div>


<div class="overlay-bg"></div>
<div id="divModalOverride"></div>


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

<div id="divList" runat="server" class="list_b" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
    <i class="fa fa-arrow-circle-left"></i>
</div>

<div class="mySave1" id="mySave" runat="server">
    <div class="save_sec">
       <button id="btnFloatSaveAll" type="submit" class="btn sub1 bt_b" onclick="return FuctionSaveMain(null,0,event);">Save All</button>
       <button id="btnFloatConfirmAll" type="submit" class="btn sub3 bt_b" style="display:none;" onclick="return Confirm(null);">Confirm All</button>
       <button id="btnFloatReopenAll" type="submit" class="btn sub2 bt_b" style="display:none;" onclick="return Reopen(null);">Reopen All</button>
    </div>
</div>

<a href="javscript:;" type="button" class="auto_b" title="Auto save indication">
<i id="d_aut_s" class="fa fa-magic bounce"><i class="fa fa-save spn_qkr"></i></i>
</a>


</asp:Content>

