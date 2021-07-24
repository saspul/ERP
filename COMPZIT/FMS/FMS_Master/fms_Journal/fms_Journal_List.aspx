<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Journal_List.aspx.cs" Inherits="FMS_FMS_Master_fms_Journal_fms_Journal_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>

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


        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {

            var ReopenSts = '<%= Session["REOPEN_STS"] %>';
            if (ReopenSts != '') {
                if (ReopenSts == 'successReopen') {
                    SuccessReoen();
                }
                else if (ReopenSts == 'Updreopen') {
                    WarnigReopen();
                }
                else if (ReopenSts == 'fail') {
                    SuccessErrorReoen();
                }
            }
            var CONFIRMSts = '<%= Session["CONFIRM_STS"] %>';
            if (CONFIRMSts != '') {
                if (CONFIRMSts == 'successConfirm') {
                    SuccessConfirm();
                }
                else if (CONFIRMSts == 'failed') {
                    SuccessErrorReoen();
                }
                else if (CONFIRMSts == 'alrdydeleted') {
                    SuccessDeletedList();
                }
                else if (CONFIRMSts == 'acntclosed') {
                    AcntClosedList();
                }
                else if (CONFIRMSts == 'Auditclosed') {
                    AuditClosed();
                }

            }
            LoadEmpList(); 
         
          
        });
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

        function SuccessReoen() {
            var ret = false;
            $noCon("#success-alert").html("Journal reopened successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function Alreadyreopened() {
            var ret = false;
            $noCon("#divWarning").html("Entry already reopened");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }

        function SuccessConfirm() {
            var ret = false;
            $noCon("#success-alert").html("Journal details confirmed successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["CONFIRM_STS"] = "' + null + '"; %>';
            return false;
        }
        function Alreadyconfirm() {
            var ret = false;
            $noCon("#divWarning").html("Entry already confirmed");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["CONFIRM_STS"] = "' + null + '"; %>';
            return false;
        }
        function SuccessErrorReoen() {
            $noCon("#divWarning").html("Some error occured!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }

        function PrintVersnError() {
            $noCon("#divWarning").html("Please select a version for printing from account setting.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function AuditClosedList() {
            $noCon("#divWarning").html("This action is  denied! Audit is already closed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function AcntClosedList() {
            $noCon("#divWarning").html("This action is  denied! Account is already closed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function AcntClosed() {
            $noCon("#divWarning").html("This action is  denied! Account is already closed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function AuditClosed() {
            $noCon("#divWarning").html("This action is  denied! Audit is already closed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }


        function LoadEmpList() {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var responsiveHelper_datatable_fixed_column = undefined;
            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };

            /* COLUMN FILTER  */
            var otable = $NoConfi3('#datatable_fixed_column').DataTable({

                "columnDefs": [
                        {
                          "targets": 0,
                          "orderData": 4,
                        },
                        {
                           "targets": 4,
                           "visible": false
                        },
                         
                ],
                "order": [[0, 'desc']],

                "preDrawCallback": function () {
                    // Initialize the responsive datatables helper once.
                    if (!responsiveHelper_datatable_fixed_column) {
                        responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#datatable_fixed_column'), breakpointDefinition);
                    }
                },
                "rowCallback": function (nRow) {
                    responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                },
                "drawCallback": function (oSettings) {
                    responsiveHelper_datatable_fixed_column.respond();
                }

            });


            // Apply the filter
            $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {
                otable
                   .column($NoConfi(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();
            });
            /* END COLUMN FILTER */
        }
     

        function SuccessError() {
            $noCon("#divWarning").html("Some error occured!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessDeleted() {
            $noCon("#divWarning").html("This action is  denied! This journal is already deleted .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function Alreadycanceled() {
            $noCon("#divWarning").html(" This journal is already deleted .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessClose() {
            $noCon("#success-alert").html("Journal deleted successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }
        function CanclCnfMsg() {
            $noCon("#divWarning").html("This action is  denied! This Journal is already confirmed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function AcntClosed() {
            $noCon("#divWarning").html("This action is  denied! Account is already closed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }       
        




        var $noCon = jQuery.noConflict();


        //for search option
        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();



        function getdetails(href) {
            window.location = href;
            return false;
        }



        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                var prm = Sys.WebForms.PageRequestManager.getInstance();
                //  prm.add_initializeRequest(InitializeRequest);
                prm.add_endRequest(EndRequest);
            });
        })(jQuery);

        function EndRequest(sender, args) {
            // after update occur on UpdatePanel re-init the Autocomplete
            LoadEmpList();

        }


        function OpenCancelView(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to delete this journal?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    //  alert(strCancelMust);
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        //cancl rsn must

                        document.getElementById("divErrMsgCnclRsn").style.display = "none";
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
        function OpenCancelBlock() {
            $noCon("#divWarning").html("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function PrintNotPossible() {
            $noCon("#divWarning").html("Sorry, printing denied.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
        }

        function ReOpen(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to reopen this journal?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {


                    ReOpenByID(StrId);


                    return false;

                }
                else {
                    return false;
                }
            });
            return false;

        }
        function ReOpenByID(strmemotId) {
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            if (strmemotId != "" && strUserID != '') {

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Journal_List.aspx/ReopenReceiptDetails",
                    data: '{strmemotId: "' + strmemotId + '",strUserID: "' + strUserID + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '"}',
                    dataType: "json",
                    success: function (data) {

                      
                        $(window).scrollTop(0);
                        var ReopenSts = data.d[0];
                        if (ReopenSts != '') {
                            if (ReopenSts == 'successReopen') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                LoadEmpList();
                                SuccessReoen();
                               
                            }
                            else if (ReopenSts == 'alrdyreopened') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                LoadEmpList();
                                Alreadyreopened();

                            }
                            else if (ReopenSts == 'Updreopen') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                LoadEmpList();
                                WarnigReopen();
                            }
                            else if (ReopenSts == 'fail') {
                                SuccessErrorReoen();
                            }
                        }
                    }
                 });
            }
            return false;
        }
        function DeleteByID(strmemotId, cnclRsn, reasonmust) {
            var usrId = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            if (strmemotId != "" && usrId != '') {

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Journal_List.aspx/CancelMemoReason",
                    data: '{strmemotId: "' + strmemotId + '",reasonmust: "' + reasonmust + '",usrId: "' + usrId + '",cnclRsn: "' + cnclRsn + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '"}',
                    dataType: "json",
                    success: function (data) {

                        $(window).scrollTop(0);
                       
                        var SucessDetails = data.d[0];
                        if (SucessDetails == "successcncl") {
                            document.getElementById("cphMain_divList").innerHTML = data.d[1];
                            document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                            LoadEmpList();
                            SuccessClose();
                           
                        }
                        else if (SucessDetails == "UpdCancl") {
                            document.getElementById("cphMain_divList").innerHTML = data.d[1];
                            document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                            LoadEmpList();
                            SuccessDeleted();
                        }
                        else if (SucessDetails == "AlreadyCancl") {
                            document.getElementById("cphMain_divList").innerHTML = data.d[1];
                            document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                            LoadEmpList();
                            Alreadycanceled();
                        }
                        else if (SucessDetails == "CnfCancl") {
                            document.getElementById("cphMain_divList").innerHTML = data.d[1];
                            document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                            LoadEmpList();
                            CanclCnfMsg();
                        }
                        else {
                            SuccessError();
                        }
                    }
                 });
            }

            return false;
        }
        function CloseCancelView() {
            ReasonConfirm = document.getElementById("txtCancelReason").value;

            if (document.getElementById("<%=Hiddencnclsts.ClientID%>").value == "") {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to close  without completing deletion process?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        $('#dialog_simple').modal('hide');
                    }
                    else {
                        $('#dialog_simple').modal('show');
                        $('#dialog_simple').on('shown.bs.modal', function () {
                            document.getElementById("txtCancelReason").focus();
                        });
                        return false;
                    }
                });
                return false;
            }
        }
        function SuccessCnfMsg() {

            $noCon("#success-alert").html("Journal details confirmed successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function ValidateCancelReason() {
            // replacing < and > tags

            var ret = true;
            document.getElementById("divErrMsgCnclRsn").style.display = "none";
            document.getElementById("lblErrMsgCancelReason").style.display = "none";
            document.getElementById("txtCancelReason").style.borderColor = "";

            var strCancelReason = document.getElementById("txtCancelReason").value;
            if (strCancelReason == "") {
                document.getElementById("txtCancelReason").style.borderColor = "red";
                document.getElementById("lblErrMsgCancelReason").style.display = "block";
                document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                document.getElementById("divErrMsgCnclRsn").style.display = "";
                $("div.war").fadeIn(200).delay(500).fadeOut(400);
                return ret;
            }
            else {
                strCancelReason = strCancelReason.replace(/(^\s*)|(\s*$)/gi, "");
                strCancelReason = strCancelReason.replace(/[ ]{2,}/gi, " ");
                strCancelReason = strCancelReason.replace(/\n /, "\n");
                if (strCancelReason.length < "10") {
                    document.getElementById("lblErrMsgCancelReason").style.display = "block";
                    document.getElementById("lblErrMsgCancelReason").innerHTML = " Delete reason should be minimum 10 characters";
                    document.getElementById("txtCancelReason").style.borderColor = "red";
                    document.getElementById("divErrMsgCnclRsn").style.display = "";
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

        function printsorted(PrintMode) {
            var strPrintMode = PrintMode;
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var FINCYRID = '<%= Session["FINCYRID"] %>';
            var DecCnt = document.getElementById("cphMain_HiddenFieldDecimalCnt").value;
            var CnclSts = 0;
            if (document.getElementById("cphMain_CbxCnclStatus").checked == true)
                CnclSts = 1;
          
            var fromDate = document.getElementById("<%=txtDateFrom.ClientID%>").value;
            var toDate = document.getElementById("<%=txtDateTo.ClientID%>").value;
            var Status = document.getElementById("<%=ddlJrnlSts.ClientID%>").value;
          
            var LedgerID = document.getElementById("<%=ddlLedger.ClientID%>").value;
            if (corptID != "" && corptID != null && orgID != "" && orgID != null  ) {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Journal_List.aspx/ListPrint_PDF",
                    data: '{FINCYRID: "' + FINCYRID + '",orgID: "' + orgID + '",corptID: "' + corptID + '",DecCnt: "' + DecCnt + '",CnclSts: "' + CnclSts + '",fromDate: "' + fromDate + '",toDate: "' + toDate + '",Status: "' + Status + '",LedgerID: "' + LedgerID + '",strPrintMode: "' + strPrintMode + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            if (data.d != "false") {
                                window.open(data.d, '_blank');
                            }
                        }
                        else {
                            Error();
                        }
                    }
                });
            }
            //window.open("../../Print/Common_print.htm");
            return false;

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
        function SearchValidate() {
            var ret = true;
            var DateFrom = document.getElementById("cphMain_txtDateFrom").value.trim();
            var DateTo = document.getElementById("cphMain_txtDateTo").value.trim();

            document.getElementById("cphMain_txtDateTo").style.borderColor = "";
            document.getElementById("cphMain_txtDateFrom").style.borderColor = "";

            if (DateTo == "") {
                document.getElementById("cphMain_txtDateTo").style.borderColor = "Red";
                document.getElementById("cphMain_txtDateTo").focus();
                ret = false;
            }
            if (DateFrom == "") {
                document.getElementById("cphMain_txtDateFrom").style.borderColor = "Red";
                document.getElementById("cphMain_txtDateFrom").focus();
                ret = false;
            }
            if (DateFrom != "" && DateTo != "") {
                var DateFrom1 = "";
                var DateTo1 = "";
                var arrDateTochk = DateTo.split("-");
                DateTo1 = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);
                var arrDateFromchk = DateFrom.split("-");
                DateFrom1 = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);
                if (DateFrom1 > DateTo1) {
                    document.getElementById("cphMain_txtDateFrom").style.borderColor = "Red";
                    document.getElementById("cphMain_txtDateTo").style.borderColor = "Red";
                    ret = false;
                }
            }
            if (ret == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            return ret;
        }


        function OpenPrint(StrId) {

            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var UsrName = '<%= Session["USERFULLNAME"] %>';
            var Id = StrId;
            var DecCnt = document.getElementById("cphMain_HiddenFieldDecimalCnt").value;

            if (corptID != "" && corptID != null && orgID != "" && orgID != null && UsrName != null && UsrName != "" && Id != "") {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Journal_List.aspx/PrintPDF",
                    data: '{Id: "' + Id + '",orgID: "' + orgID + '",corptID: "' + corptID + '",UsrName: "' + UsrName + '",DecCnt: "' + DecCnt + '"}',
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


        function ConfirmByID(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to confirm this journal?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    CheckSaleSettlements(StrId);//EVM-0020
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }

        function CheckSaleSettlements(strPayemntId) {//EVM-0020

            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';

            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "fms_Journal_List.aspx/CheckSaleSettlement",
                data: '{strPayemntId: "' + strPayemntId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '"}',
                dataType: "json",
                success: function (data) {

                    if (data.d == "successConfirm") {
                        Confirm(strPayemntId);
                        return false;
                    }
                    else if (data.d == "SalesAmtFullySettld") {

                        ezBSAlert({
                            type: "confirm",
                            messageText: "One or more sale amount(s) is fully settled. Do you want to confirm by deleting added sales?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {

                                Confirm(strPayemntId);
                                return false;
                            }
                            else {
                                return false;
                            }
                        });

                    }
                    else if (data.d == "SalesAmountExceeded") {
                        SalesAmountExceeded();
                    }
                    else if (data.d == 'failed') {
                        SuccessErrorReoen();
                    }
                    else if (data.d == "PrchsAmtFullySettld") {

                        ezBSAlert({
                            type: "confirm",
                            messageText: "One or more purchase amount(s) is fully settled. Do you want to confirm by deleting added purchases?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {

                                Confirm(strPayemntId);
                                return false;
                            }
                            else {
                                return false;
                            }
                        });
                    }
                    else if (data.d == "PrchsAmountExceeded") {
                        PurchaseAmountExceeded();
                    }
                }
            });

        }


        function Confirm(strPayemntId) {//EVM-0020

            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';

            if (strPayemntId != "" && strUserID != '') {


                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Journal_List.aspx/ConfirmJrnlDetails",
                    data: '{strUserID: "' + strUserID + '",strPayemntId: "' + strPayemntId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '"}',
                    dataType: "json",
                    success: function (data) {

                        $(window).scrollTop(0);

                        var CONFIRMSts = data.d[0];
                      //  alert(data.d[0]);


                        if (CONFIRMSts != '') {
                            if (CONFIRMSts == 'successConfirm') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                LoadEmpList();
                                SuccessConfirm();

                            }
                            else if (CONFIRMSts == 'alrdyCnfrmd') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                LoadEmpList();
                                Alreadyconfirm();

                            }
                            else if (CONFIRMSts == 'failed') {
                                SuccessErrorReoen();
                            }
                            else if (CONFIRMSts == 'SalesAmountExceeded') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                SalesAmountExceeded();
                            }
                            else if (CONFIRMSts == 'PurchaseAmtExceed') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                PurchaseAmountExceeded();
                            }
                            else if (CONFIRMSts == 'alrdydeleted') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                LoadEmpList();
                                SuccessDeletedList();
                            }
                            else if (CONFIRMSts == 'acntclosed') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                LoadEmpList();
                                AcntClosedList();
                            }
                            else if (CONFIRMSts == 'Auditclosed') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                LoadEmpList();
                                AuditClosed();
                            }
                            else if (CONFIRMSts == 'SalesAmountFullySettld') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                SalesAmountFullySettld();
                            }
                            else if (CONFIRMSts == 'PrchsAmtFullySettld') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                PrchsAmtFullySettld();
                            }

                        }
                    }
                });
            }

            return false;
        }




        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenEditID" runat="server" />
    <asp:HiddenField ID="hiddenViewID" runat="server" />
    <asp:HiddenField ID="hiddenCnclrsnMust" runat="server" />
    <asp:HiddenField ID="hiddenDeleteID" runat="server" />
        <asp:HiddenField ID="HiddenRoleEdit" runat="server" />
      <asp:HiddenField ID="HiddenRoleAllDiv" runat="server" />
      <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
     <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
       <asp:HiddenField ID="Hiddencnclsts" runat="server" />
           <asp:HiddenField ID="Hiddencncl" runat="server" />
      <asp:HiddenField ID="HiddenFieldDecimalCnt" runat="server" />
    
       <asp:HiddenField ID="hiddenEnableCancl" runat="server" />
       <asp:HiddenField ID="HiddenFnancialEndDeate" runat="server" /> 
       <asp:HiddenField ID="HiddenFinancialStartDate" runat="server" /> 
    
       <asp:HiddenField ID="HiddenReopenSts" runat="server" /> 
       <asp:HiddenField ID="HiddenProvisionSts" runat="server" /> 
    <asp:HiddenField ID="HiddenReopen" runat="server" />
        <asp:HiddenField ID="HiddenAcntClsDate" runat="server" />
     <asp:HiddenField ID="HiddenFieldAcntCloseReopenSts" runat="server" />

    
      <asp:HiddenField ID="HiddenFieldAuditCloseReopenSts" runat="server" />

    <asp:Button ID="btnEdit" runat="server" Text="Button" style="display:none"/>


     <ol class="breadcrumb">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Journal</li>
    </ol>
    <div class="myAlert-top alert alert-success" id="success-alert">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Success!</strong> Changes completed succesfully
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Danger!</strong> Request not conmpleted
    </div>



    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                <h1>Journal list</h1>


                <div class="form-group fg5">
                    <label for="pwd" class="fg2_la1">From Date:<span class="spn1"></span> </label>
                    <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtDateFrom" runat="server" type="text" style="" onkeypress="return DisableEnterAndComma(event)" onkeydown="return DisableEnterAndComma(event)" class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                        <script>

                            var StartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value
                            var curentDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value
                            $noCon('#datepicker').datepicker({
                                autoclose: true,
                                format: 'dd-mm-yyyy',
                                startDate: StartDate,
                                endDate: curentDate,
                                timepicker: false
                            });
                        </script>
                    </div>
                </div>

                <div class="form-group fg5">
                    <label for="pwd" class="fg2_la1">To Date:<span class="spn1"></span></label>
                    <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtDateTo" runat="server" type="text" style="" onkeypress="return DisableEnterAndComma(event)" onkeydown="return DisableEnterAndComma(event)" class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                        <script>
                            var StartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value
                            var curentDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value
                            $noCon('#datepicker1').datepicker({
                                autoclose: true,
                                format: 'dd-mm-yyyy',
                                startDate: StartDate,
                                endDate: curentDate,
                                timepicker: false
                            });
                        </script>
                    </div>
                </div>
                <div class="form-group fg5">
                    <label for="email" class="fg2_la1">Journal Status:<span class="spn1"></span></label>
                    <asp:DropDownList ID="ddlJrnlSts" Height="30px" Width="160px" class="form-control fg2_inp1 fg_chs1" runat="server" Style="cursor: pointer;">
                        <asp:ListItem Text="All" Value="4" Selected="True"> </asp:ListItem>
                        <asp:ListItem Text="Pending" Value="0"> </asp:ListItem>
                        <asp:ListItem Text="Confirmed" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Reopened" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="eachform" style="width: 22%; margin: 0 0 0px; margin-top: 1%; float: left; margin-left: 3%; display: none">
                    <%--emp0025--%>
                    <h2 style="margin-top: 1%;">Ledger</h2>
                    <asp:DropDownList ID="ddlLedger" Height="30px" Width="160px" class="form1" runat="server" Style="margin-left: 15%;" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)">
                    </asp:DropDownList>
                </div>
                <div class="fg5">
                    <label class="form1 mar_bo mar_tp">
                        <span class="button-checkbox">
                            <button type="button" class="btn-d" data-color="p" onclick="myFunct()" ng-model="all"></button>
                            <asp:CheckBox ID="CbxCnclStatus" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" Text="" runat="server" Checked="false" class="form2" />
                        </span>
                        <p class="pz_s">Show Deleted Entries</p>
                    </label>
                </div>
                <div class="fg5">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnCnclSearch" Style="cursor: pointer;" runat="server" class="submit_ser" OnClientClick="return SearchValidate();" OnClick="btnCnclSearch_Click" />
                </div>
                <div class="clearfix"></div>
                <div class="devider divid"></div>
                <div id="divList" runat="server">
                </div>
            </div>
        </div>
        <button id="print" onclick="return printsorted('pdf');" class="print_o" title="Print page"><i class="fa fa-print"></i></button>
        <button id="csv" onclick="return printsorted('csv');" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>

        <div id="divAdd" runat="server" onclick="location.href='fms_Journal.aspx'">
            <a href="fms_Journal.aspx" type="button" onclick="topFunction()" id="myBtn" title="Add New">
                <i class="fa fa-plus-circle"></i>
            </a>
        </div>
    </div>   
    <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
            <br />
            <br />
            <br />
            <br />
            <br />
       </div>
                                  <div id="divPrintReport" runat="server" style="display: none">
            <br />
            <br /> 
            <br />
            <br />
            <br />
        </div>
                            <div id="divPrintCaptionDrilDown" runat="server" style="display: none">
                </div>
                  <div id="divPrintReportDrilDown" runat="server" style="display: none">
                </div>
    
    
                                 <div id="divTitle" runat="server" style="display: none">
    JOURNAL
      </div>
               <%--------------------------------View for error Reason--------------------------%>


      <div class="modal fade" id="dialog_simple" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" style="display:none;"">
        <div class="modal-dialog mod1" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Reason for delete</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="alert alert-danger fade in" id="divErrMsgCnclRsn" style="display: none; margin-top: 1%">

                    <i class="fa-fw fa fa-times"></i>
                    <strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReason1"> Please fill this out</label>
                </div>

                <div class="modal-body">
                     <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>
                    <textarea id="txtCancelReason" placeholder="Write reason for delete" rows="6" maxlength="500" class="text_ar1"></textarea>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-success" data-toggle="modal">SAVE</button>
                    <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>    
     <script>
         var $au = jQuery.noConflict();      
         $au(function () {
             $au('#cphMain_ddlLedger').selectToAutocomplete1Letter();

             
         });
         </script>
</asp:Content>

