<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="pms_Purchase_Order_List.aspx.cs" Inherits="PMS_PMS_Master_pms_Purchase_Order_pms_Purchase_Order_List" %>

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
    var confirmboxCncl = 0;

    function IncrmntConfrmCounterCncl() {
        confirmboxCncl++;
    }

    var confirmboxNote = 0;

    function IncrmntConfrmCounterNote() {
        confirmboxNote++;
    }

    var confirmboxCmnt = 0;

    function IncrmntConfrmCounterCmnt() {
        confirmboxCmnt++;
    }

    var $noCon = jQuery.noConflict();

    $noCon(window).load(function () {

        //$noCon("#divVendor> input").select();

    });

    var $au = jQuery.noConflict();
    $au(function () {
        $au(".ddl").selectToAutocomplete1Letter();
    });


    function OpenCancelView(StrId) {

        confirmboxCncl = 0;

        ezBSAlert({
            type: "confirm",
            messageText: "Do you want to cancel this purchase order?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {
                var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        //cancl rsn must

                        document.getElementById("lblErrMsgCancelReason").style.display = "none";

                        document.getElementById("txtCancelReason").style.borderColor = "";
                        document.getElementById("txtCancelReason").value = "";
                        $('#dialog_simple').modal('show');
                        $('#dialog_simple').on('shown.bs.modal', function () {
                            document.getElementById("txtCancelReason").focus();
                        });

                    }
                    else {
                        DeleteByID(StrId, strCancelReason, strCancelMust);
                        $('#dialog_simple').modal('hide');
                    }
                    return false;

                }
                else {
                    return false;
                }
            });
            return false;

        }

        function ValidateCancelReason() {
            var ret = true;
            document.getElementById("lblErrMsgCancelReason").style.display = "none";
            document.getElementById("txtCancelReason").style.borderColor = "";

            var strCancelReason = document.getElementById("txtCancelReason").value;
            if (strCancelReason == "") {
                document.getElementById("txtCancelReason").style.borderColor = "red";
                document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                document.getElementById("lblErrMsgCancelReason").style.display = "";
                $("div.war").fadeIn(200).delay(500).fadeOut(400);
                return ret;
            }
            else {
                strCancelReason = strCancelReason.replace(/(^\s*)|(\s*$)/gi, "");
                strCancelReason = strCancelReason.replace(/[ ]{2,}/gi, " ");
                strCancelReason = strCancelReason.replace(/\n /, "\n");
                if (strCancelReason.length < "10") {
                    document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                    document.getElementById("txtCancelReason").style.borderColor = "red";
                    document.getElementById("lblErrMsgCancelReason").style.display = "";
                    $("div.war").fadeIn(200).delay(500).fadeOut(400);
                    return ret;
                }
                else {

                }
            }
            if (ret == true) {
                var strId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
                var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                DeleteByID(strId, strCancelReason, strCancelMust);
                $('#dialog_simple').modal('hide');
            }

            return false;

        }
        function DeleteByID(strId, strCancelReason, strCancelMust) {
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';

            if (strId != "" && strUserID != '') {
                var Details = PageMethods.CancelReason(strId, strCancelMust, strUserID, strCancelReason, strOrgIdID, strCorpID, function (response) {

                    var SucessDetails = response;
                    if (SucessDetails == "successcncl") {

                        window.location = 'pms_Purchase_Order_List.aspx?InsUpd=Cncl';


                    }
                    else {
                        window.location = 'pms_Purchase_Order_List.aspx?InsUpd=Error';
                    }
                });
            }

            return false;
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

    function SuccessCancelation() {
        $("#success-alert").html("Purchase order cancelled successfully.");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }

    function SuccessConfirmation() {
        $("#success-alert").html("Purchase order confirmed successfully.");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }

    function SuccessReopen() {
        $("#success-alert").html("Purchase order reopened successfully.");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function CancelNotPossible() {
        $("#danger-alert").html("Sorry, cancellation denied. This purchase order is already confirmed!");
        $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function NoteNotPossible() {
        $("#danger-alert").html("Sorry, adding note denied. This purchase order has an unreplied note!");
        $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
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
    function AlreadyDeleted() {
        $("#danger-alert").html("Sorry, this purchase order is already deleted!");
        $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function NoteAlreadyCnfrmd() {
        $("#danger-alert").html("Sorry, adding note denied. This purchase order is already confirmed!");
        $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function SuccessComment() {
        $("#success-alert").html("Comment added successfully.");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
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

            var strCancelStatus = 0;
            if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                strCancelStatus = 1;
            }

            var url = "/PMS/PMS_Master/pms_Purchase_Order/pms_Purchase_Order_List.aspx/LoadStaticDatafordt";
            var objData = {};
            objData.CancelStatus = strCancelStatus;

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

            var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
            var strCancelStatus = 0;
            if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                strCancelStatus = 1;
            }
            var strVendor = document.getElementById("<%=ddlVendor.ClientID%>").value;
            var strWrkflw = document.getElementById("<%=ddlDocumntWrkflw.ClientID%>").value;

            var strStrtDate = document.getElementById("<%=txtStartDate.ClientID%>").value;
            var strEndDate = document.getElementById("<%=txtEndDate.ClientID%>").value;

            var strPOType = document.getElementById("<%=ddlPrchsOrdrType.ClientID%>").value;

            strEnableModify = document.getElementById("<%=hiddenEnableModify.ClientID%>").value;
            strEnableCancel = document.getElementById("<%=hiddenEnableCancel.ClientID%>").value;
            strEnableConfirm = document.getElementById("<%=hiddenEnableConfirm.ClientID%>").value;
            strEnableReopen = document.getElementById("<%=hiddenEnableReopen.ClientID%>").value;
            
            strDefltCrncy = document.getElementById("<%=hiddenDefaultCurrencyId.ClientID%>").value;

            // for copy
            var intcopy = document.getElementById("<%=HiddenCopy.ClientID%>").value;

            var url = "/PMS/PMS_Master/pms_Purchase_Order/pms_Purchase_Order_List.aspx/GetData";
            var objData = {};
            objData.OrgId = strOrgId;
            objData.CorpId = strCorpId;
            objData.UserId = strUserId;
            objData.ddlStatus = strddlStatus;
            objData.CancelStatus = strCancelStatus;
            objData.Vendor = strVendor;
            objData.Wrkflw = strWrkflw;
            objData.StrtDate = strStrtDate;
            objData.EndDate = strEndDate;
            objData.POType = strPOType;
            objData.EnableModify = strEnableModify;
            objData.EnableCancel = strEnableCancel;
            objData.EnableConfirm = strEnableConfirm;
            objData.EnableReopen = strEnableReopen;
            objData.DefltCrncy = strDefltCrncy;
            objData.PageNumber = strPageNumber;
            objData.PageMaxSize = strPageSize;
            objData.strCommonSearchTerm = strCommonSearchString;
            objData.OrderColumn = intOrderByColumn;
            objData.OrderMethod = intOrderByStatus;
            objData.strInputColumnSearch = strInputColumnSearch;
            //for copy
            objData.intcop = intcopy;

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

                    if (intAdditionalCoumns > 0) {
                        $("#thPagingTable_thAdjuster").attr('colspan', intAdditionalCoumns);
                    }
                    else {
                        $("#thPagingTable_thAdjuster").hide();
                    }

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

    function OpenModalNote(Id, NoteCnt, POCreator, POCreatorId, RepliedCnt) {

        confirmboxNote = 0;
        document.getElementById("<%=txtMessage.ClientID%>").value = "";

        if (NoteCnt != "0" || RepliedCnt != "0") {
            document.getElementById("divFromNote").style.display = "block";
        }
        else {
            document.getElementById("divFromNote").style.display = "none";
        }

        document.getElementById("<%=hiddenPurchaseOrderId.ClientID%>").value = Id;

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
            url: "pms_Purchase_Order_List.aspx/LoadNoteData",
            data: '{  Id:"' + Id + '",UserId:"' + UserId + '",NoteNeedReplySts:"' + NoteNeedReplySts + '",NoteReplyViewSts:"' + NoteReplyViewSts + '"}',
            success: function (response) {

                $('#ModalNote').on('shown.bs.modal', function () {
                    document.getElementById("<%=txtMessage.ClientID%>").focus();
                });

                document.getElementById("txtToUser").innerHTML = POCreator;
                document.getElementById("<%=hiddenToUserId.ClientID%>").value = POCreatorId;
                if (NoteNeedReplySts != "0") {
                    document.getElementById("txtToUser").innerHTML = response.d[0];
                    document.getElementById("<%=hiddenToUserId.ClientID%>").value = response.d[5];
                }
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

    function CloseCancelView() {

        if (confirmboxCncl > 0) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close without completing cancellation process?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    $('#dialog_simple').modal('hide');
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = "";
                }
            });
        }
        else {
            $('#dialog_simple').modal('hide');
            document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = "";
        }
        return false;
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

    function OpenStatus(Id) {

        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var CurrencyId = document.getElementById("<%=hiddenDefaultCurrencyId.ClientID%>").value;
        var CurrencyAbrv = document.getElementById("<%=hiddenDefaultCrncyAbrvtn.ClientID%>").value;

        $.ajax({
            async: false,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "pms_Purchase_Order_List.aspx/LoadStatus",
            data: '{ CorpId:"' + CorpId + '",Id:"' + Id + '", CurrencyId:"' + CurrencyId + '", CurrencyAbrv:"' + CurrencyAbrv + '"}',
            success: function (response) {

                document.getElementById("divStatus").innerHTML = response.d;
            },
            failure: function (response) {

            }
        });
        return false;
    }
</script>

<script>

    function OpenComments(Id) {

        var UserId = '<%= Session["USERID"] %>';
        document.getElementById("<%=hiddenPurchaseOrderId.ClientID%>").value = Id;

        document.getElementById("<%=txtComment.ClientID%>").value = "";

        $.ajax({
            async: false,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "pms_Purchase_Order_List.aspx/LoadComments",
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

    function OpenCopyModal(Id) {

        document.getElementById("<%=hiddenPurchaseOrderId.ClientID%>").value = Id;

        document.getElementById("cbxBasicDtls").checked = false;
        document.getElementById("cbxProducts").checked = false;
        document.getElementById("cbxChrgHeads").checked = false;
        document.getElementById("cbxTermsCondtns").checked = false;

        document.getElementById("spanRefCopy").innerHTML = document.getElementById("tdRef" + Id).innerHTML;
        document.getElementById("spanDateCopy").innerHTML = document.getElementById("tdDate" + Id).innerHTML;

        $('#CopyModal').on('shown.bs.modal', function () {
            document.getElementById("cbxBasicDtls").focus();
        });
        return false;
    }

    function ValidateCopy() {

        var BasicDtls = 0;
        var Products = 0;
        var ChrgHd = 0;
        var TermsCndtns = 0;

        var Count = 0;
        if (document.getElementById("cbxBasicDtls").checked == true) {
            BasicDtls = 1;
            Count++;
        }
        if (document.getElementById("cbxProducts").checked == true) {
            Products = 1;
            Count++;
        }
        if (document.getElementById("cbxChrgHeads").checked == true) {
            ChrgHd = 1;
            Count++;
        }
        if (document.getElementById("cbxTermsCondtns").checked == true) {
            TermsCndtns = 1;
            Count++;
        }

        if (Count == 0) {
            document.getElementById("cbxBasicDtls").style.borderColor = "red";
            document.getElementById("cbxProducts").style.borderColor = "red";
            document.getElementById("cbxChrgHeads").style.borderColor = "red";
            document.getElementById("cbxTermsCondtns").style.borderColor = "red";
        }
        else {

            $('#CopyModal').modal('hide');

            var Id = document.getElementById("<%=hiddenPurchaseOrderId.ClientID%>").value;

            if (window.opener != null && !window.opener.closed) {
                window.opener.GetValueFromChildPOList(Id, BasicDtls, Products, ChrgHd, TermsCndtns);
            }
            window.close();
        }
        return false;
    }

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:HiddenField ID="hiddenDefaultCurrencyId" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="hiddenDefaultCrncyAbrvtn" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="hiddenEnableModify" runat="server" />
    <asp:HiddenField ID="hiddenEnableCancel" runat="server" />
    <asp:HiddenField ID="hiddenEnableConfirm" runat="server" />
    <asp:HiddenField ID="hiddenEnableReopen" runat="server" />
    <asp:HiddenField ID="HiddenCopy" runat="server" />
    <asp:HiddenField ID="hiddenAttchmntDtls" runat="server" />
    <asp:HiddenField ID="hiddenNoteId" runat="server" />
    <asp:HiddenField ID="hiddenPurchaseOrderId" runat="server" />
    <asp:HiddenField ID="hiddenFromUserId" runat="server" />
    <asp:HiddenField ID="hiddenToUserId" runat="server" />
    <asp:HiddenField ID="hiddenAprvlCnslId" runat="server" />

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

 <ol id="OlSection" runat="server" class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Pms.aspx">Procurement Management</a></li>
        <li class="active">Purchase Order</li>
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


      <div id="divAdd" onclick="location.href='pms_Purchase_Order.aspx'" runat="server">
           <a href="pms_Purchase_Order.aspx" type="button" id="myBtn" title="Add New">
             <i class="fa fa-plus-circle"></i>
           </a>
      </div>

     <button id="print" onclick="return PrintClick();" class="print_o" title="Print page"><i class="fa fa-print"></i></button>
      <button id="csv" onclick="return PrintCSV();" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>
   
  <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">

             <h1 class="h1_con">Purchase Order LIST</h1>

           <div class="form-group fg2 pa_ze">
            <label for="email" class="fg2_la1">Purchase Order Type<span class="spn1"></span>:</label>
               <asp:DropDownList ID="ddlPrchsOrdrType" runat="server" class="form-control fg2_inp1 fg_chs1" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);">
                   <asp:ListItem Text="All" Value="0" Selected="True"></asp:ListItem>
                   <asp:ListItem Text="Products" Value="1"></asp:ListItem>
                   <asp:ListItem Text="Car Rental" Value="2"></asp:ListItem>
                   <asp:ListItem Text="Air Ticket" Value="3"></asp:ListItem>
               </asp:DropDownList>         
          </div>

          <div class="form-group fg2 pa_ze">
            <label class="fg2_la1">Vendor<span class="spn1"></span>:</label>
              <div id="divVendor">
              <asp:DropDownList ID="ddlVendor" runat="server" class="form-control fg2_inp1 fg_chs1 ddl" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);">
               </asp:DropDownList>
              </div>       
          </div>

          <div class="form-group fg5 fg5_r1">
            <div class="tdte">
              <label class="fg2_la1">Start Date:<span class="spn1"></span> </label>
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

          <div class="form-group fg5 fg5_r1">
            <div class="tdte">
              <label class="fg2_la1">End Date:<span class="spn1"></span> </label>
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

          <div class="form-group fg2 fg5_r1 pa_ze">
            <label class="fg2_la1">Document Workflow<span class="spn1"></span>:</label>
              <asp:DropDownList ID="ddlDocumntWrkflw" runat="server" class="form-control fg2_inp1 fg_chs1 ddl" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);">
               </asp:DropDownList>           
          </div>

          <div class="form-group fg8 fg5_r1">
            <label class="fg2_la1">Status<span class="spn1"></span>:</label>
               <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1 fg_chs1" runat="server" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);">
                   <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                   <asp:ListItem Text="Confirmed" Value="1"></asp:ListItem>
                   <asp:ListItem Text="Reopened" Value="2"></asp:ListItem>
                   <asp:ListItem Text="All" Value="3" Selected="True"></asp:ListItem>
               </asp:DropDownList>            
          </div>

          <div id="divCancel" runat="server" class="fg7 fg5_r1">
            <label class="form1 mar_bo mar_tp">
              <span class="button-checkbox">
                <button type="button" class="btn-d" data-color="p"></button>
                <asp:CheckBox ID="cbxCnclStatus" Text="" class="hidden" runat="server" Checked="false" onclick="DisableEnter(event)" onkeydown="return DisableEnter(event)" />
              </span>
              <p class="pz_s">Show Deleted Entries</p>
            </label>
          </div>

          <div class="fg8 fg5_r1 flt_r">
            <label class="fg2_la1 nbsp1">&nbsp;</label>
             <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClientClick="return LoadList();" />
          </div>

      <div class="clearfix"></div>
      <div class="free_sp"></div>
      <div class="devider"></div>


<!----table---->
       <div id="divPagingTable_processing" style="display: none;">Processing...</div>
       <div id="divPagingTableContainer"></div>
       <div id="divReport" runat="server"></div>
<!----table---->


        </div>
      </div>
    </div>


<!----Cancel modal---->

    <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document">
            <div class="modal-content">
                <div class="modal-header mo_hd1">
                    <h5 class="modal-title" id="H1">Reason for delete</h5>
                    <button type="button" class="close" onclick="return CloseCancelView();">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>
                    <textarea id="txtCancelReason" placeholder="Write reason for delete" rows="6" class="text_ar1" onblur="RemoveTag('txtCancelReason')" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="resize: none;" onchange="IncrmntConfrmCounterCncl();"></textarea>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-success" data-toggle="modal">SAVE</button>
                    <button type="button" id="btnCnclRsn" class="btn btn-danger" onclick="return CloseCancelView();">Cancel</button>
                </div>
            </div>
        </div>
    </div>

<!------------------------ Modal_note --------------------------------------------------->


 <div class="modal fade" id="ModalNote" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      
        <div class="modal-header">
        <h2 class="modal-title dcmt_ref3" id="H2">Note</h2>
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
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-danger map2" OnClick="btnSubmit_Click" OnClientClick="return ValidateNote();" />
        <button type="button" class="btn btn-secondary" onclick="return CloseNote();">Close</button>
      </div>
    </div>
  </div>
</div>


<!------------------------ Modal_comment--------------------------------------------------->

<div class="modal fade" id="ModalComment" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h2 class="modal-title dcmt_ref3" id="H3">Comment</h2>
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
    <asp:Button ID="btnCmntSubmit" runat="server" Text="Submit" class="btn btn-success map2" OnClick="btnCmntSubmit_Click" OnClientClick="return ValidateComment();" />
    <button type="button" class="btn btn-danger " onclick="return CloseComment();">Close</button>
  </div>

     </div>
   </div>
</div>


<!------------------------ Modal_status--------------------------------------------------->

<div class="modal fade bd-example-modal-sm" id="ModalStatus" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h2 class="modal-title dcmt_ref3" id="exampleModalLabel">Approval Status</h2>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="timeline1">      
           <div id="divStatus"></div>
        </div>
      </div>

      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>


<div class="modal fade" id="CopyModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H4">Copy Purchase Order</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
       <ul class="po_head">
         <li>Selected Purchase Order: <span id="spanRefCopy" class="spn_pr_2"></span></li>
         <li class="tr_r">Purchase Order Date: <span id="spanDateCopy" class="spn_pr_2"></span></li>
       </ul>
       <div class="clearfix"></div>
       <div class="devider"></div>

       <div class="sec_po mar_bo1">
         <h3>Sections</h3>

         <div class="form-group fg6 fg_cop">
            <label for="email" class="fg2_la1 pad_l">Basic Details:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                <input id="cbxBasicDtls" type="checkbox" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>
          <div class="form-group fg6 fg_cop">
            <label for="email" class="fg2_la1 pad_l">Products:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                <input id="cbxProducts" type="checkbox" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>
          <div class="form-group fg6 fg_cop">
            <label for="email" class="fg2_la1 pad_l">Charges:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                <input id="cbxChrgHeads" type="checkbox" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>
          <div class="form-group fg6 fg_cop">
            <label for="email" class="fg2_la1 pad_l">Terms and Conditions:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                <input id="cbxTermsCondtns" type="checkbox" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

       </div>

      </div>
      <div class="modal-footer">
        <button id="btnCopySubmit" type="button" class="btn btn-success" onclick="return ValidateCopy();">Yes</button>
        <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
      </div>
    </div>
  </div>
</div>
    <script>
        function PrintClick() {

            var orgID = '<%= Session["ORGID"] %>';
              var corptID = '<%= Session["CORPOFFICEID"] %>';

              var statusid = 0;
              var venid = 0;
              var docid = 0;
              var purchase = document.getElementById("cphMain_ddlPrchsOrdrType").value;
              var vendor = "";
              var from = document.getElementById("<%=txtStartDate.ClientID%>").value;
              var toDt = document.getElementById("<%=txtEndDate.ClientID%>").value;
              if (document.getElementById("<%=ddlVendor.ClientID%>").value != "--SELECT VENDOR--") {
                  venid = document.getElementById("<%=ddlVendor.ClientID%>").value;
                  vendor = $("#cphMain_ddlVendor :selected").text();
             }
            var doc = "";

            if (document.getElementById("<%=ddlDocumntWrkflw.ClientID%>").value != "--SELECT DOCUMENT WORKFLOW--") {
                docid = document.getElementById("<%=ddlDocumntWrkflw.ClientID%>").value;
                doc = $("#cphMain_ddlDocumntWrkflw :selected").text();
               }

              var CnclSts = 0;
              statusid = document.getElementById("cphMain_ddlStatus").value;
              if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                  CnclSts = 1;
              }
              if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                  // alert("d");
                  $.ajax({
                      type: "POST",
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      url: "pms_Purchase_Order_List.aspx/PrintList",
                      data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",statusid: "' + statusid + '",CnclSts: "' + CnclSts + '" ,purchase:"' + purchase + '",venid:"' + venid + '",docid:"' + docid + '",vendor:"' + vendor + '",doc:"' + doc + '",from:"' + from + '",toDt:"'+toDt+'"}',
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

              var statusid = 0;
              var venid = 0;
              var docid = 0;
              var purchase = document.getElementById("cphMain_ddlPrchsOrdrType").value;
              var vendor = "";
              var from = document.getElementById("<%=txtStartDate.ClientID%>").value;
              var toDt = document.getElementById("<%=txtEndDate.ClientID%>").value;
              if (document.getElementById("<%=ddlVendor.ClientID%>").value != "--SELECT VENDOR--") {
                  venid = document.getElementById("<%=ddlVendor.ClientID%>").value;
                  vendor = $("#cphMain_ddlVendor :selected").text();
              }
              var doc = "";

              if (document.getElementById("<%=ddlDocumntWrkflw.ClientID%>").value != "--SELECT DOCUMENT WORKFLOW--") {
                docid = document.getElementById("<%=ddlDocumntWrkflw.ClientID%>").value;
                doc = $("#cphMain_ddlDocumntWrkflw :selected").text();
            }

            var CnclSts = 0;
            statusid = document.getElementById("cphMain_ddlStatus").value;
            if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                CnclSts = 1;
            }
            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
              
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "pms_Purchase_Order_List.aspx/PrintCSV",
                    data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",statusid: "' + statusid + '",CnclSts: "' + CnclSts + '" ,purchase:"' + purchase + '",venid:"' + venid + '",docid:"' + docid + '",vendor:"' + vendor + '",doc:"' + doc + '",from:"' + from + '",toDt:"' + toDt + '"}',
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

