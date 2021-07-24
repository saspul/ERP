<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Approval_Console.aspx.cs" Inherits="Master_gen_Approval_Console_gen_Approval_Console" %>

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
    var $noCon = jQuery.noConflict();

    $noCon(window).load(function () {

        document.getElementById("<%=hiddenIds.ClientID%>").value = "";
    });

    function SuccessApproval() {
        $("#success-alert").html("Purchase order approved successfully.");
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }

    function SuccessRejection() {
        $("#success-alert").html("Purchase order rejected successfully.");
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }

    function SuccessOnHold() {
        $("#success-alert").html("Purchase order hold successfully.");
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

    function ErrorApproval() {
        $("#danger-alert").html("Please select a document to approve!");
        $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }
    
    function ErrorReject() {
        $("#danger-alert").html("Please select a document to reject!");
        $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }

    function OnHoldMsg() {
        $("#danger-alert").html("This document is onhold by another user!");
        $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }
    function HoldNotPossible() {
        $("#danger-alert").html("This document is already onhold!");
        $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }
    

    function ChangeCheck(Id) {

        if (document.getElementById("cbxPrchs_" + Id).checked == true) {

            if (document.getElementById("<%=hiddenIds.ClientID%>").value == "") {
                document.getElementById("<%=hiddenIds.ClientID%>").value = Id;
            }
            else {
                document.getElementById("<%=hiddenIds.ClientID%>").value = document.getElementById("<%=hiddenIds.ClientID%>").value + "," + Id;
            }
        }
    }

    function ChangeCheckAll() {

        document.getElementById("<%=hiddenIds.ClientID%>").value = "";

        if (document.getElementById("cbxAll").checked == true) {
            $('.Chkcls').attr("checked", "true");
        }
        else {
            $('.Chkcls').removeAttr("checked");
        }

        $('.Chkcls').each(function () {
            var id = $(this).attr("id");
            var id_split = id.split('_');
            var Value = id_split[1];
            ChangeCheck(Value);
        });
    }

    function OpenApproveOrHold(strId, Mode) {

        if (strId != "") {
            document.getElementById("<%=hiddenIds.ClientID%>").value = strId;
        }

        if (document.getElementById("<%=hiddenIds.ClientID%>").value == "") {
            ErrorApproval();
        }
        else {

            var Msg = "";
            if (Mode == "1")
                Msg = "Do you want to approve this document?"//1
            else if (Mode == "3")
                Msg = "Do you want to hold this document?"//3

            ezBSAlert({
                type: "confirm",
                messageText: Msg,
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    if (document.getElementById("<%=hiddenIds.ClientID%>").value != "") {
                        ApproveRejectById(Mode, "");
                    }
                    else {
                        ErrorApproval();
                    }

                }
            });
        }

        return false;
    }

    function ApproveRejectById(Mode, RejectReason) {

        var UserId = '<%=Session["USERID"]%>';
        var OrgId = '<%=Session["ORGID"]%>';
        var CorpId = '<%=Session["CORPOFFICEID"]%>';

        var OrderIds = document.getElementById("<%=hiddenIds.ClientID%>").value;

        if (UserId != "" && OrderIds != "") {

            $.ajax({
                async: false,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "gen_Approval_Console.aspx/ApproveReject",
                data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",UserId:"' + UserId + '",Mode:"' + Mode + '",RejectReason:"' + RejectReason + '",OrderIds:"' + OrderIds + '"}',
                success: function (response) {

                    if (response.d != "") {
                        window.location = 'gen_Approval_Console.aspx?InsUpd=' + response.d + '';
                    }
                    else {
                        window.location = 'gen_Approval_Console.aspx?InsUpd=Error';
                    }

                },
                failure: function (response) {

                }

            });

            return false;
        }
    }

    function OpenRejectModal(strId) {

        if (strId != "") {
            document.getElementById("<%=hiddenIds.ClientID%>").value = strId;
        }

        if (document.getElementById("<%=hiddenIds.ClientID%>").value == "") {
            ErrorReject();
        }
        else {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to reject this document?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    document.getElementById("lblErrMsgCancelReason").style.display = "none";

                    document.getElementById("txtRejectReason").style.borderColor = "";
                    document.getElementById("txtRejectReason").value = "";

                    $('#ModalReject').modal('show');
                    $('#ModalReject').on('shown.bs.modal', function () {
                        document.getElementById("txtRejectReason").focus();
                    });

                }
            });
        }

        return false;
    }

    function ValidateCancelReason() {
        var ret = true;
        document.getElementById("lblErrMsgCancelReason").style.display = "none";
        document.getElementById("txtRejectReason").style.borderColor = "";

        var strRejectReason = document.getElementById("txtRejectReason").value;
        if (strRejectReason == "") {
            document.getElementById("txtRejectReason").style.borderColor = "red";
            document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
            document.getElementById("lblErrMsgCancelReason").style.display = "";
            $("div.war").fadeIn(200).delay(500).fadeOut(400);
            return ret;
        }
        else {
            strRejectReason = strRejectReason.replace(/(^\s*)|(\s*$)/gi, "");
            strRejectReason = strRejectReason.replace(/[ ]{2,}/gi, " ");
            strRejectReason = strRejectReason.replace(/\n /, "\n");
            if (strRejectReason.length < "10") {
                document.getElementById("lblErrMsgCancelReason").innerHTML = " Reject reason should be minimum 10 characters";
                document.getElementById("txtRejectReason").style.borderColor = "red";
                document.getElementById("lblErrMsgCancelReason").style.display = "";
                $("div.war").fadeIn(200).delay(500).fadeOut(400);
                return ret;
            }
        }
        if (ret == true) {

            var strId = document.getElementById("<%=hiddenIds.ClientID%>").value;//2

            if (document.getElementById("<%=hiddenIds.ClientID%>").value != "") {
                ApproveRejectById(2, strRejectReason);
            }
            else {
                ErrorReject();
            }

            $('#ModalReject').modal('hide');
            return false;
        }
    }

    function LoadActiveApprovalSets() {

        var Desgntn = document.getElementById("<%=hiddenDesgnation.ClientID%>").value;
        var nWindow = window.open('/Master/gen_approval_set/gen_approval_set_list.aspx?VId=' + Desgntn + '', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
        nWindow.focus();
    }
    </script>

<script>

        function ValidateSearch() {

            var ret = true;

            var FrmDate = document.getElementById("<%=txtStartDate.ClientID%>").value.trim();
            var ToDate = document.getElementById("<%=txtEndDate.ClientID%>").value.trim();

            document.getElementById("<%=txtStartDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEndDate.ClientID%>").style.borderColor = "";

            if (FrmDate != "" && ToDate != "") {

                var datepickerDate = document.getElementById("<%=txtStartDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateFrmDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var datepickerDate = document.getElementById("<%=txtEndDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateToDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                if (dateFrmDt > dateToDt) {
                    $noCon("#divWarning").html("Sorry, From date should not be greater than To date !");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtStartDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtStartDate.ClientID%>").focus();
                    ret = false;
                }

            }

            return ret;
        }

        //--------------------------------------Pagination--------------------------------------

        $(document).ready(function () {
            LoadList();
        });

        function LoadList() {
            Load_dt();
            if (ValidateSearch() == true) {
                getdata(1);
            }
            return false;
        }

        //Efficiently Paging Through Large Amounts of Data
        var intOrderByColumn = 0;
        var intOrderByStatus = 0;
        var intToltalSearchColumns = 0;

        //------------Load column filters and table----------

        function Load_dt() {

            var strPagingTable = '';
            strPagingTable += '<div id="divHeader_dt"></div>';
            strPagingTable += '<div><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_800" style="width:100%;">';
            strPagingTable += '<thead class="thead1"><tr id="trPagingTableHeading"></tr><tr id="thPagingTable_SearchColumns"></tr></thead>';
            strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
            strPagingTable += '</table></div>';

            $("#divPagingTableContainer").html(strPagingTable);

            intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

            var url = "/Master/gen_Approval_Console/gen_Approval_Console.aspx/LoadStaticDatafordt";
            var objData = {};

            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(objData),
                contentType: "application/json; charset=utf-8",
                url: url,
                success: function (result) {
                    $("#divHeader_dt").html(result.d[0]);
                    $("#thPagingTable_SearchColumns").html(result.d[1]);
                    intToltalSearchColumns = result.d[2];

                    //bind on paste event to enable search on paste via mouse
                    $("input").on('paste', function (e) {
                        setTimeout(function () { $(e.target).keyup(); }, 100);
                    });
                },
                error: function () {
                    Error();
                }
            });
        }

        //-----------Load datatable & pagination----------

        function getdata(strPageNumber) {

            document.getElementById("divPagingTable_processing").style.display = "";
            var strPageSize = 10;
            var strCommonSearchString = "";
            var strInputColumnSearch = getColumnSearchData();//individual column search

            if (document.getElementById("txtCommonSearch_dt")) {
                strCommonSearchString = document.getElementById("txtCommonSearch_dt").value.trim();
                strCommonSearchString = ValidateSearchInputData(strCommonSearchString);
            }

            if (document.getElementById("ddl_page_size")) {
                strPageSize = document.getElementById("ddl_page_size").value;
            }

            var strOrgId = '<%= Session["ORGID"] %>';
            var strCorpId = '<%= Session["CORPOFFICEID"] %>';
            var strUserId = '<%= Session["USERID"] %>';

            //if (strOrgId == "" || strCorpId == "") {
            //    window.location.href = "/Default.aspx";
            //    return false;
            //}

            var strDocumnt = document.getElementById("<%=ddlDocumentTyp.ClientID%>").value;
            var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
            var strStrtDate = document.getElementById("<%=txtStartDate.ClientID%>").value;
            var strEndDate = document.getElementById("<%=txtEndDate.ClientID%>").value;

            var strEnableHold = document.getElementById("<%=hiddenEnableHold.ClientID%>").value;

            var url = "/Master/gen_Approval_Console/gen_Approval_Console.aspx/GetData";
            var objData = {};
            objData.OrgId = strOrgId;
            objData.CorpId = strCorpId;
            objData.UserId = strUserId;
            objData.ddlStatus = strddlStatus;
            objData.Documnt = strDocumnt;
            objData.StrtDate = strStrtDate;
            objData.EndDate = strEndDate;
            objData.EnableHold = strEnableHold;
            objData.PageNumber = strPageNumber;
            objData.PageMaxSize = strPageSize;
            objData.strCommonSearchTerm = strCommonSearchString;
            objData.OrderColumn = intOrderByColumn;
            objData.OrderMethod = intOrderByStatus;
            objData.strInputColumnSearch = strInputColumnSearch;

            $.ajax({

                type: 'POST',
                data: JSON.stringify(objData),
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                url: url,
                success: function (result) {

                    $('#trPagingTableHeading').html(result.d[0]);
                    $('#tblPagingTable tbody').html(result.d[1]);

                    $("#cphMain_divReport").html(result.d[2]);//datatable

                    var intToltalColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

                    var intAdditionalCoumns = intToltalColumns - (intToltalSearchColumns);

                    if (intAdditionalCoumns < 0) {
                        intAdditionalCoumns = 0;
                    }

                    $("#thPagingTable_thAdjuster").attr('colspan', intAdditionalCoumns);

                    if (document.getElementById("td_No_data_row_dt")) {
                        $("#td_No_data_row_dt").attr('colspan', intToltalColumns);
                    }

                    //enable sort icon 

                    if (intOrderByStatus == 1) {
                        $("#tdColumnHead_" + intOrderByColumn).addClass("asc");
                    }
                    else {
                        $("#tdColumnHead_" + intOrderByColumn).addClass("desc");
                    }

                    document.getElementById("divPagingTable_processing").style.display = "none";

                    //--------Disable for Hold----------
                    var DisabledCnt = 0;
                    $('.Chkcls').each(function () {
                        var id = $(this).attr("id");
                        if (document.getElementById(id).disabled == true) {
                            DisabledCnt++;
                        }
                    });
                    if (parseInt(DisabledCnt) > 0) {
                        document.getElementById("cbxAll").disabled = true;
                    }
                    //--------Disable for Hold----------

                },
                error: function () {
                    Error();
                }
            });
            return false;
        }


        function getColumnSearchData() {

            //this function collects data from input column search boxes and along with the id
            //— ‡
            var inputSearchTerms = "";
            for (var intSearchColumnCount = 0; intSearchColumnCount < intToltalSearchColumns; intSearchColumnCount++) {
                if (document.getElementById("txtSearchColumn_" + intSearchColumnCount)) {
                    var searchString = document.getElementById("txtSearchColumn_" + intSearchColumnCount).value.trim();
                    if (searchString != "") {

                        searchString = ValidateSearchInputData(searchString);

                        if (inputSearchTerms == "") {
                            inputSearchTerms = intSearchColumnCount + "‡" + searchString;
                        } else {
                            inputSearchTerms += "—" + intSearchColumnCount + "‡" + searchString;
                        }
                    }
                }
            }
            return inputSearchTerms;
        }

        function SetOrderByValue(intOrderBy) {
            intOrderByColumn = intOrderBy;
            if (intOrderByStatus == 1) {
                intOrderByStatus = 0;
            }
            else {
                intOrderByStatus = 1;
            }
            //redraw
            getdata(1);
        }

        function ValidateSearchInputData(strSearchString) {
            var text = strSearchString;
            var replaceText1 = text.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            strSearchString = replaceText3;
            if (strSearchString.length > 100) {
                strSearchString = strSearchString.substring(0, 100);
            }
            else {
            }
            return strSearchString;
        }

        //Efficiently Paging Through Large Amounts of Data

        //setup before functions
        var typingTimer;                //timer identifier
        var doneTypingInterval = 1000;  //time in ms (5 seconds)

        function SettypingTimer() {
            //on keyup, start the countdown
            clearTimeout(typingTimer);
            typingTimer = setTimeout(doneTyping, doneTypingInterval);
        }

        //user is "finished typing," do something
        function doneTyping() {
            //do something
            getdata(1);
        }

        //$("th i").click(function () {
        //    alert();
        //});

        //$('.pull-right hed_fa').click(function () {
        //    alert("1  " + $(this).hasClass('fa fa-sort')); alert("2  " + $(this).hasClass('fa fa-caret-up')); alert("3  " + $(this).hasClass('fa fa-caret-down'));
        //    if ($(this).hasClass('fa fa-sort') == true) {
        //        $(this).addClass('fa fa-caret-up');
        //    }
        //    else if ($(this).hasClass('fa fa-caret-up') == true) {
        //        $(this).addClass('fa fa-caret-down');
        //    }
        //    else {
        //        $(this).addClass('fa fa-sort');
        //    }
        //});

        //--------------------------------------Pagination--------------------------------------
</script>

<script>

    function SuccessNote() {
        $("#success-alert").html("Note added successfully.");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function SuccessNoteReply() {
        $("#success-alert").html("Replied to note successfully.");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function NoteAlreadyCnfrmd() {
        $("#danger-alert").html("Sorry, adding note denied. This document is already confirmed!");
        $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function NoteNotPossible() {
        $("#danger-alert").html("Sorry, adding note denied. This document has an unreplied note!");
        $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }

    var confirmboxNote = 0;

    function IncrmntConfrmCounterNote() {
        confirmboxNote++;
    }

    function OpenModalNote(CnslId, Id, NoteCnt, POCreator, POCreatorId, RepliedCnt) {

        confirmboxNote = 0;
        document.getElementById("<%=txtMessage.ClientID%>").value = "";

        if (NoteCnt != "0" || RepliedCnt != "0") {
            document.getElementById("divFromNote").style.display = "block";
        }
        else {
            document.getElementById("divFromNote").style.display = "none";
        }

        document.getElementById("<%=hiddenPurchaseOrderId.ClientID%>").value = Id;
        document.getElementById("<%=hiddenAprvlCnslId.ClientID%>").value = CnslId;

        var UserId = '<%= Session["USERID"] %>';
        var UserName = '<%= Session["USERNAME"] %>';

        var NoteNeedReplySts = "0";
        if (NoteCnt != "0") {
            NoteNeedReplySts = "1";
        }

        var NoteReplyViewSts = "0";
        if (RepliedCnt != "0") {
            NoteReplyViewSts = "1";
        }

        $.ajax({
            async: false,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "gen_Approval_Console.aspx/LoadNoteData",
            data: '{ CnslId:"' + CnslId + '",UserId:"' + UserId + '",NoteNeedReplySts:"' + NoteNeedReplySts + '",NoteReplyViewSts:"' + NoteReplyViewSts + '"}',
            success: function (response) {

                $('#ModalNote').on('shown.bs.modal', function () {
                    document.getElementById("<%=txtMessage.ClientID%>").focus();
                });

                //To user
                document.getElementById("txtToUser").innerHTML = POCreator;
                document.getElementById("<%=hiddenToUserId.ClientID%>").value = POCreatorId;
                if (NoteNeedReplySts != "0") {
                    document.getElementById("txtToUser").innerHTML = response.d[0];
                    document.getElementById("<%=hiddenToUserId.ClientID%>").value = response.d[5];
                }

                //From user
                document.getElementById("<%=hiddenFromUserId.ClientID%>").value = UserId;
                if (NoteReplyViewSts == "1") {
                    document.getElementById("txtFromUser").innerHTML = "Reply Message :";
                }
                else {
                    document.getElementById("txtFromUser").innerHTML = UserName;
                }
                if (NoteNeedReplySts != "0") {
                    document.getElementById("txtFromUser").innerHTML = response.d[1];
                    document.getElementById("<%=hiddenFromUserId.ClientID%>").value = response.d[6];
                }

                //Other dtls
                document.getElementById("<%=hiddenNoteId.ClientID%>").value = response.d[2];
                document.getElementById("txtFromMessage").innerHTML = response.d[3];

                if (response.d[7] != "0") {
                    if (response.d[7] == "1") {
                        document.getElementById("txtFromAttchmnt").innerHTML = response.d[7] + " Attachment";
                    }
                    else {
                        document.getElementById("txtFromAttchmnt").innerHTML = response.d[7] + " Attachments";
                    }
                    document.getElementById("divFrmAttchmnts").innerHTML = response.d[4];
                }

                document.getElementById("spanRefPO").innerHTML = document.getElementById("tdRef" + Id).innerHTML;

                if (NoteNeedReplySts == "0") {
                    document.getElementById("spanMsgHd").innerHTML = "Message";
                }
                else {
                    document.getElementById("spanMsgHd").innerHTML = "Reply";
                }

                $("#tableAttachmnt").empty();

                AddMoreRowsAttachmnt(0);

            },
            failure: function (response) {

            }
        });

        return false;
    }

    //-----------------------Attachmnt-----------------------


    var CountAttch = 0;

    function AddMoreRowsAttachmnt(Mode) {

        if (Mode != "0") {
            CountAttch++;
        }

        var RecRow = '';

        RecRow += '<tr id="trRowAttchId_' + CountAttch + '" >';
        RecRow += '<td id="tdFileId' + CountAttch + '" style="display: none;">' + CountAttch + '</td>';
        RecRow += '<td>';
        RecRow += '<input id="fileAttach' + CountAttch + '" type="file" name="fileAttach' + CountAttch + '" onchange="ChangeFile(' + CountAttch + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" />';
        RecRow += '<label for="fileAttach' + CountAttch + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
        RecRow += '<div id="filePath' + CountAttch + '" class="file_n gbb">No File Uploaded</div>';
        RecRow += '</td>';
        RecRow += '<td class="gbn pull-right">';
        RecRow += '<button id="btnAddFile' + CountAttch + '" class="btn act_btn bn2" title="Add New" onclick="return CheckaddMoreRowsAttch(' + CountAttch + ');"><i class="fa fa-plus-circle"></i></button>';
        RecRow += '<button id="btnDeleteFile' + CountAttch + '" class="btn act_btn bn3" title="Delete" onclick="return RemoveRowsAttch(' + CountAttch + ');"><i class="fa fa-trash"></i></button>';
        RecRow += '</td>';
        RecRow += '<td id="tdEvtFile' + CountAttch + '" style="width:0%;display: none;">INS</td>';
        RecRow += '<td id="tdDtlIdFile' + CountAttch + '" style="width:0%;display: none;">0</td>';
        RecRow += '<td id="tdActFileName' + CountAttch + '" style="display: none;"></td>';
        RecRow += '</tr>';

        $("#tableAttachmnt").append(RecRow);

    }


    function ChangeFile(x) {

        IncrmntConfrmCounterNote();

        if (CheckFileExtension(x)) {

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

        IncrmntConfrmCounterNote();

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

        IncrmntConfrmCounterNote();

        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to delete selected attachment?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {

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

                if (FilePath != "" && FilePath != "No File Uploaded") {
                    var client = JSON.stringify({
                        ROWID: "" + validRowID + "",
                        FILENAME: "" + FilePath + "",
                        EVTACTION: "" + Evt + "",
                    });
                    tbClientTotalValues.push(client);
                }

            }
        }

        document.getElementById("<%=hiddenAttchmntDtls.ClientID%>").value = JSON.stringify(tbClientTotalValues);

        return ret;
    }

    function ValidateNote() {

        var ret = true;

        if (ValidateAttchmntDtls() == false) {
            ret = false;
        }

        document.getElementById("<%=txtMessage.ClientID%>").style.borderColor = "";

        var Msg = document.getElementById("<%=txtMessage.ClientID%>").value.trim();

        if (Msg == "") {
            document.getElementById("<%=txtMessage.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtMessage.ClientID%>").focus();
            ret = false;
        }

        return ret;
    }

    function CloseNote() {

        if (confirmboxNote > 0) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close without adding a note?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    $('#ModalNote').modal('hide');
                }
            });
        }
        else {
            $('#ModalNote').modal('hide');
        }
        return false;
    }

</script>

<script>

    function SuccessComment() {
        $("#success-alert").html("Comment added successfully.");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }

    var confirmboxCmnt = 0;

    function IncrmntConfrmCounterCmnt() {
        confirmboxCmnt++;
    }

    function OpenComments(CnslId, Id) {

        var UserId = '<%= Session["USERID"] %>';
        document.getElementById("<%=hiddenPurchaseOrderId.ClientID%>").value = Id;
        document.getElementById("<%=hiddenAprvlCnslId.ClientID%>").value = CnslId;

        document.getElementById("<%=txtComment.ClientID%>").value = "";

        $.ajax({
            async: false,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "gen_Approval_Console.aspx/LoadComments",
            data: '{ Id:"' + Id + '",UserId:"' + UserId + '"}',
            success: function (response) {

                $('#ModalComment').on('shown.bs.modal', function () {
                    document.getElementById("<%=ddlVisibilitySts.ClientID%>").focus();
                });

                if (response.d[2] != "0") {
                    document.getElementById("divUserComments").style.display = "block";
                }
                else {
                    document.getElementById("divUserComments").style.display = "none";
                    document.getElementById("divAddComments").style.cssFloat = "right";
                }
                document.getElementById("divCommentDates").innerHTML = response.d[0];
                document.getElementById("divComment").innerHTML = response.d[1];
            },
            failure: function (response) {

            }
        });
        return false;
    }

    function ValidateComment() {

        var ret = true;

        document.getElementById("<%=txtComment.ClientID%>").style.borderColor = "";

        var Msg = document.getElementById("<%=txtComment.ClientID%>").value.trim();

        if (Msg == "") {
            document.getElementById("<%=txtComment.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtComment.ClientID%>").focus();
            ret = false;
        }

        return ret;
    }

    function CloseComment() {

        if (confirmboxCmnt > 0) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close without adding a comment?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    $('#ModalComment').modal('hide');
                }
            });
        }
        else {
            $('#ModalComment').modal('hide');
        }
        return false;
    }
</script>

<script>

        function SuccessAddtnlDtls() {
            $("#success-alert").html("Additional details added successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessAddtnlDtlsReply() {
            $("#success-alert").html("Replied to additional details request successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function AddtnlDtlsNotPossible() {
            $("#danger-alert").html("Sorry, adding additional details denied. This document has an unreplied additional details request!");
            $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        var confirmboxAddtnl = 0;

        function IncrmntConfrmCounterAddtnl() {
            confirmboxAddtnl++;
        }

        function LoadEmployees(obj, event) {

            if (event != null) {
                if (isTagEnter(event) == false) {
                    return false;
                }
            }

            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var OrgId = '<%=Session["ORGID"]%>';

            $noCon('#' + obj).autocomplete({
                source: function (request, response) {

                    $.ajax({
                        async: false,
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        url: "gen_Approval_Console.aspx/LoadEmployees",
                        data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",strText:"' + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + '"}',
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
                    document.getElementById("<%=hiddenEmployeeId.ClientID%>").value = i.item.val;
                    document.getElementById("<%=txtToUserAddtnl.ClientID%>").value = i.item.label;
                },
                change: function (event, ui) {
                    if (ui.item) {
                        document.getElementById("<%=hiddenEmployeeName.ClientID%>").value = document.getElementById("<%=txtToUserAddtnl.ClientID%>").value;
                    }
                    else {
                        document.getElementById("<%=txtToUserAddtnl.ClientID%>").value = document.getElementById("<%=hiddenEmployeeName.ClientID%>").value;
                    }
                }
            });
        }

        function OpenModalAddtnl(CnslId, Id, Cnt, RepliedCnt) {

            confirmboxAddtnl = 0;
            document.getElementById("<%=txtMessageAddtnl.ClientID%>").value = "";
            document.getElementById("<%=txtToUserAddtnl.ClientID%>").value = "";
            document.getElementById("<%=hiddenEmployeeName.ClientID%>").value = "";
            document.getElementById("<%=hiddenEmployeeId.ClientID%>").value = "";

            if (Cnt != "0" || RepliedCnt != "0") {
                document.getElementById("divFromAddtnl").style.display = "block";
            }
            else {
                document.getElementById("divFromAddtnl").style.display = "none";
            }

            document.getElementById("<%=hiddenPurchaseOrderId.ClientID%>").value = Id;
            document.getElementById("<%=hiddenAprvlCnslId.ClientID%>").value = CnslId;

            var UserId = '<%= Session["USERID"] %>';
            var UserName = '<%= Session["USERNAME"] %>';

            var NeedReplySts = "0";
            if (Cnt != "0") {
                NeedReplySts = "1";
            }

            var ReplyViewSts = "0";
            if (RepliedCnt != "0") {
                ReplyViewSts = "1";
            }

            $.ajax({
                async: false,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "gen_Approval_Console.aspx/LoadAddtnalDtlsData",
                data: '{ CnslId:"' + CnslId + '",UserId:"' + UserId + '",NeedReplySts:"' + NeedReplySts + '",ReplyViewSts:"' + ReplyViewSts + '"}',
                success: function (response) {

                    $('#ModalSupport').on('shown.bs.modal', function () {
                        document.getElementById("<%=txtToUserAddtnl.ClientID%>").focus();
                    });

                    //To user
                    if (NeedReplySts != "0") {
                        document.getElementById("<%=txtToUserAddtnl.ClientID%>").value = response.d[0];
                        document.getElementById("<%=hiddenEmployeeName.ClientID%>").value = response.d[0];
                        document.getElementById("<%=hiddenEmployeeId.ClientID%>").value = response.d[5];
                        document.getElementById("<%=txtToUserAddtnl.ClientID%>").disabled = true;
                    }

                    //From user
                    document.getElementById("<%=hiddenFromUserIdAddtnl.ClientID%>").value = UserId;
                    if (ReplyViewSts == "1") {
                        document.getElementById("txtFromUserAddtnl").innerHTML = "Reply Message :";
                    }
                    else {
                        document.getElementById("txtFromUserAddtnl").innerHTML = UserName;
                    }
                    if (NeedReplySts != "0") {
                        document.getElementById("txtFromUserAddtnl").innerHTML = response.d[1];
                        document.getElementById("<%=hiddenFromUserIdAddtnl.ClientID%>").value = response.d[6];
                    }

                    //Other dtls
                    document.getElementById("<%=hiddenAddtnlDtlId.ClientID%>").value = response.d[2];
                    document.getElementById("txtFromMessageAddtnl").innerHTML = response.d[3];

                    if (response.d[7] != "0") {
                        if (response.d[7] == "1") {
                            document.getElementById("txtFromAttchmntAddtnl").innerHTML = response.d[7] + " Attachment";
                        }
                        else {
                            document.getElementById("txtFromAttchmntAddtnl").innerHTML = response.d[7] + " Attachments";
                        }
                        document.getElementById("divFrmAttchmntsAddtnl").innerHTML = response.d[4];
                    }

                    document.getElementById("spanRefPOAddtnl").innerHTML = document.getElementById("tdRef" + Id).innerHTML;

                    if (NeedReplySts == "0") {
                        document.getElementById("spanMsgHdAddtnl").innerHTML = "Message";
                    }
                    else {
                        document.getElementById("spanMsgHdAddtnl").innerHTML = "Reply";
                    }

                    $("#tableAttachmntAddtnl").empty();

                    AddMoreRowsAttachmntAddtnl(0);

                },
                failure: function (response) {

                }
            });

            return false;
        }

    //-----------------------Attachmnt-----------------------


    var CountAttchAddtnl = 0;

    function AddMoreRowsAttachmntAddtnl(Mode) {

        if (Mode != "0") {
            CountAttchAddtnl++;
        }

        var RecRow = '';

        RecRow += '<tr id="trRowAttchIdAddtnl_' + CountAttchAddtnl + '" >';
        RecRow += '<td id="tdFileIdAddtnl' + CountAttchAddtnl + '" style="display: none;">' + CountAttchAddtnl + '</td>';
        RecRow += '<td>';
        RecRow += '<input id="fileAttachAddtnl' + CountAttchAddtnl + '" type="file" name="fileAttachAddtnl' + CountAttchAddtnl + '" onchange="ChangeFileAddtnl(' + CountAttchAddtnl + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" />';
        RecRow += '<label for="fileAttachAddtnl' + CountAttchAddtnl + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
        RecRow += '<div id="filePathAddtnl' + CountAttchAddtnl + '" class="file_n gbb">No File Uploaded</div>';
        RecRow += '</td>';
        RecRow += '<td class="gbn pull-right">';
        RecRow += '<button id="btnAddFileAddtnl' + CountAttchAddtnl + '" class="btn act_btn bn2" title="Add New" onclick="return CheckaddMoreRowsAttchAddtnl(' + CountAttchAddtnl + ');"><i class="fa fa-plus-circle"></i></button>';
        RecRow += '<button id="btnDeleteFileAddtnl' + CountAttchAddtnl + '" class="btn act_btn bn3" title="Delete" onclick="return RemoveRowsAttch(' + CountAttchAddtnl + ');"><i class="fa fa-trash"></i></button>';
        RecRow += '</td>';
        RecRow += '<td id="tdEvtFileAddtnl' + CountAttchAddtnl + '" style="width:0%;display: none;">INS</td>';
        RecRow += '<td id="tdDtlIdFileAddtnl' + CountAttchAddtnl + '" style="width:0%;display: none;">0</td>';
        RecRow += '<td id="tdActFileNameAddtnl' + CountAttchAddtnl + '" style="display: none;"></td>';
        RecRow += '</tr>';

        $("#tableAttachmntAddtnl").append(RecRow);

    }


    function ChangeFileAddtnl(x) {

        IncrmntConfrmCounterAddtnl();

        if (CheckFileExtensionAddtnl(x)) {

            if (document.getElementById('fileAttachAddtnl' + x).value != "") {
                document.getElementById('filePathAddtnl' + x).innerHTML = document.getElementById('fileAttachAddtnl' + x).value;
            }
            else {
                document.getElementById('filePathAddtnl' + x).innerHTML = 'No File Uploaded';
            }
        }
    }

    function CheckFileExtensionAddtnl(x) {

        var fileData = document.getElementById('fileAttachAddtnl' + x);
        var FileUploaded = fileData.value;

        var Extension = FileUploaded.substring(FileUploaded.lastIndexOf('.') + 1).toLowerCase();
        if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                    || Extension == "jpeg" || Extension == "jpg" || Extension == "xlsx" || Extension == "xls" || Extension == "doc" ||
            Extension == "docx" || Extension == "csv" || Extension == "ppt" || Extension == "pptx"
           || Extension == "txt" || Extension == "pdf") {
            return true;
        }
        else {
            document.getElementById('fileAttachAddtnl' + x).value = "";
            document.getElementById('filePathAddtnl' + x).innerHTML = 'No File Selected';
            $noCon("#danger-alert").html("The specified file type could not be uploaded.Only support image files and document files.");
            $noCon("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
    }

    function CheckaddMoreRowsAttchAddtnl(x) {

        IncrmntConfrmCounterAddtnl();

        if (CheckAndHighlightFileUploadedAddtnl(x) == true) {
            AddMoreRowsAttachmntAddtnl(1);
            var idlast = $('#tableAttachmntAddtnl tr:last').attr('id');
            var LastId = "";
            if (idlast != "") {
                var res = idlast.split("_");
                LastId = res[1];
            }
            document.getElementById("fileAttachAddtnl" + LastId).focus();
            document.getElementById("btnAddFileAddtnl" + x).disabled = true;
        }
        return false;
    }

    function CheckAndHighlightFileUploadedAddtnl(x) {

        var evt = document.getElementById("tdEvtFileAddtnl" + x).innerHTML;
        if (evt == 'INS') {
            if (document.getElementById('fileAttachAddtnl' + x).value != "") {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            var FilePath = "";
            if (document.getElementById("filePathAddtnl" + x).innerHTML != "") {
                FilePath = document.getElementById("filePathAddtnl" + x).innerHTML;
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

        IncrmntConfrmCounterAddtnl();

        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to delete selected attachment?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {

                jQuery('#trRowAttchIdAddtnl_' + x).remove();

                var idlast = $('#tableAttachmntAddtnl tr:last').attr('id');

                if (idlast != undefined) {
                    var LastId = "";
                    if (idlast != "") {
                        var res = idlast.split("_");
                        LastId = res[1];
                    }
                    document.getElementById("btnAddFileAddtnl" + LastId).disabled = false;
                }

                var Table = document.getElementById("tableAttachmntAddtnl");
                if (Table.rows.length < 1) {
                    AddMoreRowsAttachmntAddtnl(0);
                }
            }
            else {
                return false;
            }
        });
        return false;
    }

    function ValidateAttchmntDtlsAddtnl() {

        var ret = true;

        var tbClientTotalValues = '';
        tbClientTotalValues = [];

        document.getElementById("<%=hiddenAttchmntDtlsAddtnl.ClientID%>").value = "";

        var Table = document.getElementById("tableAttachmntAddtnl");

        for (var x = 0; x < Table.rows.length; x++) {

            if (Table.rows[x].cells[0].innerHTML != "") {

                var validRowID = (Table.rows[x].cells[0].innerHTML);

                var Evt = document.getElementById("tdEvtFileAddtnl" + validRowID).innerHTML;
                var FilePath = "";
                if (Evt == "INS") {
                    FilePath = document.getElementById("filePathAddtnl" + validRowID).innerHTML;
                }
                else {
                    FilePath = document.getElementById("tdActFileNameAddtnl" + validRowID).innerHTML;
                }

                if (FilePath != "" && FilePath != "No File Uploaded") {
                    var client = JSON.stringify({
                        ROWID: "" + validRowID + "",
                        FILENAME: "" + FilePath + "",
                        EVTACTION: "" + Evt + "",
                    });
                    tbClientTotalValues.push(client);
                }

            }
        }

        document.getElementById("<%=hiddenAttchmntDtlsAddtnl.ClientID%>").value = JSON.stringify(tbClientTotalValues);

        return ret;
    }

    function ValidateAddtnl() {

        var ret = true;

        if (ValidateAttchmntDtlsAddtnl() == false) {
            ret = false;
        }

        document.getElementById("<%=txtMessageAddtnl.ClientID%>").style.borderColor = "";
        document.getElementById("<%=txtToUserAddtnl.ClientID%>").style.borderColor = "";

        var Msg = document.getElementById("<%=txtMessageAddtnl.ClientID%>").value.trim();
        var Employee = document.getElementById("<%=txtToUserAddtnl.ClientID%>").value.trim();

        if (Msg == "") {
            document.getElementById("<%=txtMessageAddtnl.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtMessageAddtnl.ClientID%>").focus();
            ret = false;
        }

        if (Employee == "" || Employee == "-Select-") {
            document.getElementById("<%=txtToUserAddtnl.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtToUserAddtnl.ClientID%>").focus();
            ret = false;
        }

        return ret;
    }

    function CloseAddtnl() {

        if (confirmboxAddtnl > 0) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close without adding a additional details?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    $('#ModalSupport').modal('hide');
                }
            });
        }
        else {
            $('#ModalSupport').modal('hide');
        }
        return false;
    }

    function CheckAddtnlApprv(Id, Mode) {

        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to continue when there is an unreplied additional requirement request?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {
                if (Mode == "1" || Mode == "3") {
                    OpenApproveOrHold(Id, 1);
                }
                else if (Mode == "2") {
                    OpenRejectModal(Id);
                }
            }
        });
        return false;
    }

    </script>

<script>

    function SuccessDelegateDtls() {
        $("#success-alert").html("Delegation of employee done successfully.");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }

    function LoadEmployeesHierachy(obj, event) {

        if (event != null) {
            if (isTagEnter(event) == false) {
                return false;
            }
        }

        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var OrgId = '<%=Session["ORGID"]%>';
        var UserId = '<%= Session["USERID"] %>';
        var Id = document.getElementById("<%=hiddenPurchaseOrderId.ClientID%>").value;

        $noCon('#' + obj).autocomplete({
            source: function (request, response) {

                $.ajax({
                    async: false,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Approval_Console.aspx/LoadEmployeesHierachy",
                    data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",UserId:"' + UserId + '",Id:"' + Id + '",strText:"' + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + '"}',
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
                document.getElementById("<%=hiddenEmployeeId.ClientID%>").value = i.item.val;
                document.getElementById(obj).value = i.item.label;
            },
            change: function (event, ui) {
                if (ui.item) {
                    document.getElementById("<%=hiddenEmployeeName.ClientID%>").value = document.getElementById(obj).value;
                }
                else {
                    document.getElementById(obj).value = document.getElementById("<%=hiddenEmployeeName.ClientID%>").value;
                }
            }
        });
    }

    function OpenDelegate(CnslId, Id, Cnt, DelegateSts) {

        document.getElementById("<%=txtMessageDelegate.ClientID%>").value = "";
        document.getElementById("<%=txtToUserDelegate.ClientID%>").value = "";
        document.getElementById("<%=hiddenEmployeeName.ClientID%>").value = "";
        document.getElementById("<%=hiddenEmployeeId.ClientID%>").value = "";

        if (Cnt != "0") {
            document.getElementById("divFromDelegate").style.display = "block";
        }
        else {
            document.getElementById("divFromDelegate").style.display = "none";
        }

        if (DelegateSts == "1") {
            document.getElementById("divToDelegate").style.display = "block";
        }
        else {
            document.getElementById("divToDelegate").style.display = "none";
            document.getElementById("cphMain_btnSubmitDelegate").style.display = "none";
        }

        document.getElementById("<%=hiddenPurchaseOrderId.ClientID%>").value = Id;
        document.getElementById("<%=hiddenAprvlCnslId.ClientID%>").value = CnslId;

        var UserId = '<%= Session["USERID"] %>';
        var UserName = '<%= Session["USERNAME"] %>';

        var ReplyViewSts = "0";
        if (Cnt != "0") {
            ReplyViewSts = "1";
        }

        $.ajax({
            async: false,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "gen_Approval_Console.aspx/LoadDelegateData",
            data: '{ CnslId:"' + CnslId + '",UserId:"' + UserId + '",ReplyViewSts:"' + ReplyViewSts + '"}',
            success: function (response) {
                $('#ModalDelegate').on('shown.bs.modal', function () {
                    document.getElementById("<%=txtToUserDelegate.ClientID%>").focus();
                });

                //From user
                if (ReplyViewSts == "1") {
                    document.getElementById("txtFromUserDelegate").innerHTML = response.d[1];
                }

                //Other dtls
                document.getElementById("txtFromMessageDelegate").innerHTML = response.d[3];

                document.getElementById("spanRefPODelegate").innerHTML = document.getElementById("tdRef" + Id).innerHTML;

            },
            failure: function (response) {

            }
        });

        return false;
    }

    function ValidateDelegate() {

        var ret = true;

        document.getElementById("<%=txtMessageDelegate.ClientID%>").style.borderColor = "";
        document.getElementById("<%=txtToUserDelegate.ClientID%>").style.borderColor = "";

        var Msg = document.getElementById("<%=txtMessageDelegate.ClientID%>").value.trim();
        var Employee = document.getElementById("<%=txtToUserDelegate.ClientID%>").value.trim();

        if (Msg == "") {
            document.getElementById("<%=txtMessageDelegate.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtMessageDelegate.ClientID%>").focus();
            ret = false;
        }

        if (Employee == "" || Employee == "-Select-") {
            document.getElementById("<%=txtToUserDelegate.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtToUserDelegate.ClientID%>").focus();
            ret = false;
        }

        return ret;
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

 <asp:HiddenField ID="hiddenEnableHold" runat="server" />
 <asp:HiddenField ID="hiddenIds" runat="server" />
 <asp:HiddenField ID="hiddenWrkFlowId" runat="server" />
 <asp:HiddenField ID="hiddenPurchaseOrderId" runat="server" />
 <asp:HiddenField ID="hiddenToUserId" runat="server" />
 <asp:HiddenField ID="hiddenFromUserId" runat="server" />
 <asp:HiddenField ID="hiddenNoteId" runat="server" />
 <asp:HiddenField ID="hiddenAttchmntDtls" runat="server" />  
 <asp:HiddenField ID="hiddenAprvlCnslId" runat="server" />
 <asp:HiddenField ID="hiddenEmployeeId" runat="server" />
 <asp:HiddenField ID="hiddenEmployeeName" runat="server" />
 <asp:HiddenField ID="hiddenAttchmntDtlsAddtnl" runat="server" />
 <asp:HiddenField ID="hiddenFromUserIdAddtnl" runat="server" />
 <asp:HiddenField ID="hiddenAddtnlDtlId" runat="server" />
 <asp:HiddenField ID="hiddenAddtnalSts" runat="server" />
 <asp:HiddenField ID="hiddenDesgnation" runat="server" />
 <asp:HiddenField ID="hiddenDelegateId" runat="server" />


 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
  </asp:ScriptManager>

 <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
        <li class="active">Approval Console</li>
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
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con">Approval Console</h1>

          <div class="form-group fg5 fg_cnl1">
            <label for="email" class="fg2_la1">Document Type:<span class="spn1"></span></label>
            <asp:DropDownList ID="ddlDocumentTyp" runat="server" class="form-control fg2_inp1 fg_chs1" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);">
               </asp:DropDownList>       
          </div>

          <div class="form-group fg5 fg_cnl1">
            <label for="email" class="fg2_la1">Status:<span class="spn1"></span></label>
               <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1 fg_chs1" runat="server" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);">
                   <asp:ListItem Text="Pending" Value="0" Selected="True"></asp:ListItem>
                   <asp:ListItem Text="Approved" Value="1"></asp:ListItem>
                   <asp:ListItem Text="Rejected" Value="2"></asp:ListItem>
                   <asp:ListItem Text="All" Value="3"></asp:ListItem>
               </asp:DropDownList>        
          </div>

           <div class="form-group fg5 fg_cnl1">
            <div class="tdte">
              <label for="pwd" class="fg2_la1">From Date:<span class="spn1"></span> </label>
              <div id="datepickerStrtDt" class="input-group date" data-date-format="dd-mm-yyyy">
                 <input id="txtStartDate" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr" data-dateformat="dd-mm-yyyy" placeholder="dd-mm-yyyy" maxlength="50" />
                 <span id="spandate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>
            </div> 
          </div>

             <script>
                 $noCon('#datepickerStrtDt').datepicker({
                     autoclose: true,
                     format: 'dd-mm-yyyy',
                     timepicker: false
                 });
            </script>

           <div class="form-group fg5 fg_cnl1">
            <div class="tdte">
              <label for="pwd" class="fg2_la1">To Date:<span class="spn1"></span> </label>
                <div id="datepickerEndDt" class="input-group date" data-date-format="dd-mm-yyyy">
                 <input id="txtEndDate" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr" data-dateformat="dd-mm-yyyy" placeholder="dd-mm-yyyy" maxlength="50" />
                 <span id="span1" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>
            </div> 
          </div>

            <script>
                $noCon('#datepickerEndDt').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false
                });
            </script>

          <div class="fg5 fg_cnl1">
            <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
              <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClientClick="return LoadList();" />
          </div>

<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
<!---=================section_devider============---> 


   <div class="tbl_consle">
    <div class="tabl_set">

<!----table---->
       <div id="divPagingTable_processing" style="display: none;">Processing...</div>
       <div id="divPagingTableContainer"></div>
       <div id="divReport" runat="server"></div>
<!----table---->



  </div>
</div><!---table_Set_closed--->



<!---inner_content_sections area_closed--->

<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
<!---=================section_devider============--->


<!--Buttons_Area_started--->
          <div class="sub_cont pull-right">
            <div class="save_sec">
              <button type="submit" class="btn sub1" onclick="return OpenApproveOrHold('', 1)">Approve Multiple</button>
              <button type="submit" class="btn sub4" onclick="return OpenRejectModal('')">Reject Multiple</button>
            </div>
          </div>
<!--Buttons_area_closed--->


<!---frame_border_area_closed---->
        </div>
      </div>
    </div>


  <div class="mySave1" id="mySave">
    <div class="save_sec">
      <button type="submit" class="btn sub1 bt_b bt_sht" onclick="return OpenApproveOrHold('', 1)">Approve Multiple</button>
      <button type="submit" class="btn sub4 bt_b bt_sht" onclick="return OpenRejectModal('')">Reject Multiple</button>
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

<a href="javascript:;" type="button" class="act_aprvl_btn" title="View active approval sets" onclick="return LoadActiveApprovalSets()">
  <i class="fa fa-wpforms "></i>
</a>
     <button id="print" onclick="return PrintClick();" class="print_o" title="Print page"><i class="fa fa-print"></i></button>
      <button id="csv" onclick="return PrintCSV();" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>
   
<!------------------------ Modal_reject ---------------------------------------------->

<div class="modal fade" id="ModalReject">
  <div class="modal-dialog mod1" role="document">
    <div class="modal-content">
      <div class="modal-header mo_hd1">
        <h5 class="modal-title" id="exampleModalLabel">Reason for delete</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>
        <textarea id="txtRejectReason" placeholder="Write reason for reject" rows="6" class="text_ar1" onblur="RemoveTag('txtRejectReason')" onkeypress="return isTag(event)" onkeydown="textCounter(txtRejectReason,450)" onkeyup="textCounter(txtRejectReason,450)" style="resize: none;"></textarea>
      </div>
      <div class="modal-footer mo_ft1">
        <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-primary" data-toggle="modal">SAVE</button>
        <button type="button" id="btnCnclRsn" class="btn btn-danger" data-dismiss="modal">Cancel</button>
      </div>
    </div>
  </div>
</div>


<!------------------------ Modal_note --------------------------------------------------->

 <div class="modal fade" id="ModalNote" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      
        <div class="modal-header">
        <h2 class="modal-title dcmt_ref3" id="H1">Note</h2>
        <button type="button" class="close" onclick="return CloseNote();">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>

      <div class="modal-body8">
        <div class="note_container1">
          <span class="dcmt_ref">Document Ref#: <span id="spanRefPO" class="dcmt_ref2"></span></span>

            <!----Already Created Note---->
          <div id="divFromNote" class="attch_bx" style="display:none;">
            <h3 id="txtFromUser" class="dcmt_refrnc2"></h3>
            <p id="txtFromMessage" class="dcmt_refrnc" style="word-wrap:break-word;text-align: justify;margin: 0 18px 10px 0;"></p>

            <h3 id="txtFromAttchmnt" class="dcmt_refrnc2 blk"></h3>
            <div id="divFrmAttchmnts"></div>
          </div>
            <!----Already Created Note---->
          <div class="clearfix"></div>

          <!----Note Create/Reply---->
          <p class="dcmt_ref">Note to<span class="spn1">*</span></p>
          <h3 id="txtToUser" class="dcmt_ref2"></h3>
          <div class="form-group fd">
            <label for="email" class="fg2_la1"><span id="spanMsgHd"></span><span class="spn1">*</span></label>
            <textarea id="txtMessage" runat="server" rows="4" cols="50" class="form-control" maxlength="290" style="resize:none;" onkeydown="textCounter(cphMain_txtMessage,290)" onkeyup="textCounter(cphMain_txtMessage,290)" onblur="textCounter(cphMain_txtMessage,290)" onchange="IncrmntConfrmCounterNote();"></textarea>
          </div>
        </div>
         
        <div class="note_uplrd">
          <div class="dcmt_ref2">Attach File

            <table id="tableAttachmnt" class="attch_row">
            </table>

          </div>
        </div>
          <!----Note Create/Reply---->

      </div>
      <div class="modal-footer">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-danger map2" OnClientClick="return ValidateNote();" OnClick="btnSubmit_Click" />
        <button type="button" class="btn btn-secondary" onclick="return CloseNote();">Close</button>
      </div>
    </div>
  </div>
</div>


<!------------------------ Modal_Document Approver Delegation --------------------------------------------------->

<div class="modal fade" id="ModalDelegate" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h2 class="modal-title dcmt_ref3" id="H2">Document Approver Delegation</h2>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="note_container1">
          <span class="dcmt_ref">Document Ref#: <span id="spanRefPODelegate" class="dcmt_ref2"></span></span>

            <!----Already Created Details---->
          <div id="divFromDelegate" class="attch_bx" style="display:none;">
            <h3 id="txtFromUserDelegate" class="dcmt_refrnc2"></h3>
            <p id="txtFromMessageDelegate" class="dcmt_refrnc" style="word-wrap:break-word;text-align: justify;margin: 0 18px 10px 0;"></p>

            <h3 id="txtFromAttchmntDelegate" class="dcmt_refrnc2 blk"></h3>
            <div id="divFrmAttchmntsDelegate"></div>
          </div>
            <!----Already Created Details---->

          <div class="free_sp"></div>

        <div id="divToDelegate">
          <p class="dcmt_ref wd_100 mar_tp">Transfer to<span class="spn1">*</span></p>
          <div class="form-group fg4">
              <input id="txtToUserDelegate" runat="server" class="form-control fg2_inp1 fg_chs1" autocomplete="off" placeholder="-Select-" maxlength="500"  onkeypress="return LoadEmployeesHierachy('cphMain_txtToUserDelegate',event);" onkeydown="return LoadEmployeesHierachy('cphMain_txtToUserDelegate',event);" />      
          </div>
         <div class="form-group fd mar_tp">
              <label for="email" class="fg2_la1">Message<span class="spn1">*</span></label>
              <textarea id="txtMessageDelegate" runat="server" rows="4" cols="50" class="form-control" maxlength="290" style="resize:none;" onkeydown="textCounter(cphMain_txtMessageDelegate,290)" onkeyup="textCounter(cphMain_txtMessageDelegate,290)" onblur="textCounter(cphMain_txtMessageDelegate,290)"></textarea>
         </div>
        </div>

        </div>
      </div>
        
      <div class="modal-footer">
        <asp:Button ID="btnSubmitDelegate" runat="server" Text="Submit" class="btn btn-success map2" OnClientClick="return ValidateDelegate();" OnClick="btnSubmitDelegate_Click" />
        <button type="button" class="btn btn-danger " data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>


<!------------------------ Modal_request for additional dtls --------------------------------------------------->

<div class="modal fade" id="ModalSupport" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h2 class="modal-title dcmt_ref3" id="H3">Request for additional details</h2>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="note_container1">
          <span class="dcmt_ref">Document Ref#: <span id="spanRefPOAddtnl" class="dcmt_ref2"> </span></span>

            <!----Already Created Details---->
          <div id="divFromAddtnl" class="attch_bx" style="display:none;">
            <h3 id="txtFromUserAddtnl" class="dcmt_refrnc2"></h3>
            <p id="txtFromMessageAddtnl" class="dcmt_refrnc" style="word-wrap:break-word;text-align: justify;margin: 0 18px 10px 0;"></p>

            <h3 id="txtFromAttchmntAddtnl" class="dcmt_refrnc2 blk"></h3>
            <div id="divFrmAttchmntsAddtnl"></div>
          </div>
            <!----Already Created Details---->

          <div class="free_sp"></div>
          <p class="dcmt_ref wd_100 mar_tp">Request to<span class="spn1">*</span></p>
          <div class="form-group fg4">
              <input id="txtToUserAddtnl" runat="server" class="form-control fg2_inp1 fg_chs1" autocomplete="off" placeholder="-Select-" maxlength="500"  onkeypress="return LoadEmployees('cphMain_txtToUserAddtnl',event);" onkeydown="return LoadEmployees('cphMain_txtToUserAddtnl',event);" />      
          </div>
           <div class="form-group fd mar_tp">
              <label for="email" class="fg2_la1"><span id="spanMsgHdAddtnl"></span><span class="spn1">*</span></label>
              <textarea id="txtMessageAddtnl" runat="server" rows="4" cols="50" class="form-control" maxlength="290" style="resize:none;" onkeydown="textCounter(cphMain_txtMessageAddtnl,290)" onkeyup="textCounter(cphMain_txtMessageAddtnl,290)" onblur="textCounter(cphMain_txtMessageAddtnl,290)"></textarea>
            </div>
      </div>
         <div class="note_uplrd">
          <div class="dcmt_ref2">Attach File

            <table id="tableAttachmntAddtnl" class="attch_row">
            </table>

          </div>
        </div>
      </div>
      <div class="modal-footer">
        <asp:Button ID="btnSubmitAddtnl" runat="server" Text="Submit" class="btn btn-success map2" OnClientClick="return ValidateAddtnl();" OnClick="btnSubmitAddtnl_Click" />
        <button type="button" class="btn btn-danger " data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>


<!------------------------ Modal_comment--------------------------------------------------->

<div class="modal fade" id="ModalComment" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h2 class="modal-title dcmt_ref3" id="H4">Comment</h2>
        <button type="button" class="close" onclick="return CloseComment();">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>

  <div class="modal-body">
   <div class="row">
    <div class="col-md-12">

    <div id="divUserComments" class="col-md-8" style="display:none;">     
     <div class="col-md-6 bj kp">        
       <div class="timeline">
        <div class="year">
          <div id="divCommentDates"></div>     
        </div>
       </div>    
      </div>
      <div class="col-md-6 bj lj">
         <div id="divComment" style="word-wrap:break-word;text-align: justify;"></div>
      </div>
    </div>

    <div id="divAddComments" class="col-md-4 bj">
        <div class="form-group fd">
          <label for="email" class="fg2_la12">Visibility Mode:<span class="spn1">*</span></label>
          <asp:DropDownList ID="ddlVisibilitySts" class="form-control fg2_inp1 fg_chs1 inp_mst" runat="server" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);" onchange="IncrmntConfrmCounterCmnt();">
            <asp:ListItem Text="Public" Value="0"></asp:ListItem>
            <asp:ListItem Text="Private" Value="1"></asp:ListItem>
          </asp:DropDownList>     
        </div>
        <div class="clearfix"></div>
        <div class="form-group fd">
          <label for="email" class="fg2_la12">Comment:<span class="spn1">*</span></label>
          <textarea id="txtComment" runat="server" rows="4" cols="50" class="form-control form_fnt fg2_inp1 fg_chs1 inp_mst" placeholder="Description" maxlength="300" style="resize:none;" onkeydown="textCounter(cphMain_txtComment,290)" onkeyup="textCounter(cphMain_txtComment,290)" onblur="textCounter(cphMain_txtComment,290)" onchange="IncrmntConfrmCounterCmnt();"></textarea>       
        </div>
    </div>

    </div>
   </div>
  </div>
  <div class="modal-footer">
    <asp:Button ID="btnCmntSubmit" runat="server" Text="Submit" class="btn btn-success map2" OnClientClick="return ValidateComment();" OnClick="btnCmntSubmit_Click" />
    <button type="button" class="btn btn-danger " onclick="return CloseComment();">Close</button>
  </div>

     </div>
   </div>
</div>


    <script>
        function PrintClick() {

            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var UserId = '<%= Session["USERID"] %>';
            var statusid = 0;
          
            var docid = 0;
            
            var from = document.getElementById("<%=txtStartDate.ClientID%>").value;
              var toDt = document.getElementById("<%=txtEndDate.ClientID%>").value;
           
              var doc = "";

              if (document.getElementById("<%=ddlDocumentTyp.ClientID%>").value != "--SELECT DOCUMENT--") {
                docid = document.getElementById("<%=ddlDocumentTyp.ClientID%>").value;
                  doc = $("#cphMain_ddlDocumentTyp :selected").text();
            }

           
            statusid = document.getElementById("cphMain_ddlStatus").value;
           
            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                // alert("d");
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Approval_Console.aspx/PrintList",
                    data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",UserId:"'+UserId+'",statusid: "' + statusid + '" ,docid:"' + docid + '",doc:"' + doc + '",from:"' + from + '",toDt:"' + toDt + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {

                            window.open(data.d, '_blank');
                        }
                        else {
                            Error();

                        }
                    }
                });
            }
            else {
                window.location = '/Security/Login.aspx';
            }
            return false;
        }
        function PrintCSV() {

            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var UserId = '<%= Session["USERID"] %>';
            var statusid = 0;

            var docid = 0;

            var from = document.getElementById("<%=txtStartDate.ClientID%>").value;
            var toDt = document.getElementById("<%=txtEndDate.ClientID%>").value;

            var doc = "";

            if (document.getElementById("<%=ddlDocumentTyp.ClientID%>").value != "--SELECT DOCUMENT--") {
                  docid = document.getElementById("<%=ddlDocumentTyp.ClientID%>").value;
                  doc = $("#cphMain_ddlDocumentTyp :selected").text();
              }


              statusid = document.getElementById("cphMain_ddlStatus").value;
              if (corptID != "" && corptID != null && orgID != "" && orgID != null) {

                  $.ajax({
                      type: "POST",
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      url: "gen_Approval_Console.aspx/PrintCSV",
                      data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",UserId:"' + UserId + '",statusid: "' + statusid + '" ,docid:"' + docid + '",doc:"' + doc + '",from:"' + from + '",toDt:"' + toDt + '"}',
                      dataType: "json",
                      success: function (data) {
                          //  alert("d");
                          if (data.d != "") {
                              // 
                              window.open(data.d, '_blank');
                          }
                          else {
                              Error();

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

