<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Debit_note_List.aspx.cs" Inherits="FMS_FMS_Master_fms_Debit_Note_fms_Debit_note_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
      <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>

    <script>


        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {

            var ReopenSts = '<%= Session["REOPEN_STS"] %>';
            if (ReopenSts != '') {
                if (ReopenSts == 'successReopen') {
                    SuccessReoen();
                }
                else if (ReopenSts == 'failed') {
                    SuccessErrorReoen();
                } else if (ReopenSts == 'successConfirm') {
                    SuccesssuccessConfirm();
                }
                
            }


            LoadEmpList();   //
          

        });


        function SuccessInsertion() {
            $noCon("#success-alert").html("Debit note inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           
            return false;

        }
        function SuccessUpdation() {
            $noCon("#success-alert").html("Debit note updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           
            return false;
        }
        function SuccesssuccessConfirm() {
            var ret = false;
            $noCon("#success-alert").html("Debit note confirmed successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function Alreadyreopened() {
            var ret = false;
            $noCon("#divWarning").html("Debit note aleady reopened.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function Alreadyconfirm() {
            var ret = false;
            $noCon("#divWarning").html("Entry already confirmed.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function SuccessReoen() {
            var ret = false;
            $noCon("#success-alert").html("Debit note reopened successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
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
                                         {
                                             "targets": 3,
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
                },
            });
            // Apply the filter
            $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {
                otable
                 //   .column($NoConfi(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });
            /* END COLUMN FILTER */
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
                messageText: "Do you want to delete this debit note?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    //  alert(strCancelMust);
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        //cancl rsn must

                        document.getElementById("lblErrMsgCancelReason").style.display = "none";
                        document.getElementById("txtCancelReason").style.borderColor = "";
                        document.getElementById("txtCancelReason").value = "";
                       $('#dialog_simple').modal('show');

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
            $noCon("#success-alert").html("Sorry, cancellation denied. This debit note is already selected somewhere or it is a confirmed debit note!");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
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
                    url: "fms_Debit_note_List.aspx/CancelMemoReason",
                    data: '{strmemotId: "' + strmemotId + '",reasonmust: "' + reasonmust + '",usrId: "' + usrId + '",cnclRsn: "' + cnclRsn + '",strCorpID: "' + strCorpID + '",strOrgIdID: "' + strOrgIdID + '"}',
                    dataType: "json",
                    success: function (data) {
                        var ReopenSts = data.d[0];
                       
                        $(window).scrollTop(0);
                        var SucessDetails = ReopenSts;
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
                        else if (SucessDetails == "CnfCancl") {
                            document.getElementById("cphMain_divList").innerHTML = data.d[1];
                            document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                            LoadEmpList();
                            CanclCnfMsg();
                        }
                        else if (SucessDetails == "AlreadyCancl") {
                            document.getElementById("cphMain_divList").innerHTML = data.d[1];
                            document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                            LoadEmpList();
                            Alreadycancl();
                        }
                        else {
                            SuccessError();
                        }
                       
                    }
                });
            }

            return false;
        }
        function CanclCnfMsg() {
            $noCon("#divWarning").html("This action is  denied! This Debit note is already confirmed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function Alreadycancl() {
            $noCon("#divWarning").html(" This Debit note is already deleted .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessClose() {
            $noCon("#success-alert").html("Debit note deleted successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessError() {
            $noCon("#divWarning").html("Some error occured!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessDeleted() {
            $noCon("#divWarning").html("This action is  denied! This debit note is already deleted .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
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
                        return false;
                    }
                });
                return false;
            }
        }
        function ValidateCancelReason() {
            // replacing < and > tags

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
                    document.getElementById("lblErrMsgCancelReason").innerHTML = " Delete reason should be minimum 10 characters";
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

        function ReOpenByID(strPayemntId) {

            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to reopen?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    if (strPayemntId != "" && strUserID != '') {


                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "fms_Debit_note_List.aspx/ReopenReceiptDetails",
                            data: '{strUserID: "' + strUserID + '",strPayemntId: "' + strPayemntId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '"}',
                            dataType: "json",
                            success: function (data) {
                                var ReopenSts = data.d[0];
                               
                                $(window).scrollTop(0);
                                if (ReopenSts != '') {
                                    if (ReopenSts == 'successReopen') {
                                        SuccessReoen();
                                        document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                        document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                        LoadEmpList();
                                    }
                                    else if (ReopenSts == 'failed') {
                                        SuccessErrorReoen();
                                    } else if (ReopenSts == 'successConfirm') {
                                        document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                        document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                        LoadEmpList();
                                        SuccesssuccessConfirm();
                                    }

                                    else if (ReopenSts == 'alrdyreopened') {
                                        document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                        document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                        LoadEmpList();
                                        Alreadyreopened();
                                    }

                                }
                                
                            }
                        });

                    }

                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }
        function SuccessConfirmation() {
            $noCon("#success-alert").html("Debit note confirmed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           
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
        function AlredyConfirm() {
            $noCon("#divWarning").html("This action is  denied! This Debit note is already confirmed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessDeleted() {
            $noCon("#divWarning").html("This action is  denied! This Debit note is already deleted .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function OpenPrint(StrId) {

            var orgID = '<%= Session["ORGID"] %>';
              var corptID = '<%= Session["CORPOFFICEID"] %>';
              var UsrName = '<%= Session["USERFULLNAME"] %>';
              var Id = StrId;
              var DecCnt = document.getElementById("cphMain_HiddenFieldDecimalCnt").value;
              var crncyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

              if (corptID != "" && corptID != null && orgID != "" && orgID != null && UsrName != null && UsrName != "" && Id != "") {
                  $.ajax({
                      type: "POST",
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      url: "fms_Debit_note_List.aspx/PrintPDF",
                      data: '{Id: "' + Id + '",orgID: "' + orgID + '",corptID: "' + corptID + '",UsrName: "' + UsrName + '",DecCnt: "' + DecCnt + '",crncyId: "' + crncyId + '"}',
                      dataType: "json",
                      success: function (data) {
                          if (data.d != "") {
                              window.open(data.d, '_blank');
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

          function PrintNotPossible() {
              ezBSAlert({
                  type: "alert",
                  messageText: "Sorry, Printing Denied. This sale details is not confirmed!",
                  alertType: "info"
              });
              return false;
          }
          function PurchaseAmountExceeded() {
              $noCon("#divWarning").html("Debit note amount should not be greater than purchase amount.");
              $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
              });
              return false;
          }
          function PrchsAmtFullySettld() {
              $noCon("#divWarning").html("Purchase amount is already settled.");
              $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
              });
              return false;
          }

          function ConfirmByID(StrId) {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm?",
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
                url: "fms_Debit_note_List.aspx/CheckSaleSettlement",
                data: '{strPayemntId: "' + strPayemntId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '"}',
                dataType: "json",
                success: function (data) {

                    if (data.d == "successConfirm") {
                        Confirm(strPayemntId);
                        return false;
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
                    else if (data.d == 'failed') {
                        SuccessErrorReoen();
                    }

                }
            });

        }


        function Confirm(strPayemntId) {//EVM-0020

            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            var FinYrID = '<%=Session["FINCYRID"]%>';

            if (strPayemntId != "" && strUserID != '') {

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Debit_note_List.aspx/ConfirmReceiptDetails",
                    data: '{strUserID: "' + strUserID + '",strPayemntId: "' + strPayemntId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",FinYrID: "' + FinYrID + '"}',
                    dataType: "json",
                    success: function (data) {
                        var ReopenSts = data.d[0];

                        $(window).scrollTop(0);
                        if (ReopenSts != '') {
                            if (ReopenSts == 'successReopen') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                LoadEmpList();
                                SuccessReoen();
                            }
                            else if (ReopenSts == "PrchsAmountExceeded") {
                                PurchaseAmountExceeded();
                            }
                            else if (ReopenSts == "PrchsAmtFullySettld") {
                                PrchsAmtFullySettld();
                            }
                            else if (ReopenSts == 'failed') {
                                SuccessErrorReoen();
                            } else if (ReopenSts == 'successConfirm') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                LoadEmpList();
                                SuccesssuccessConfirm();
                            }
                            else if (ReopenSts == 'alrdyCnfrmd') {
                                document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                document.getElementById("cphMain_divPrintReport").innerHTML = data.d[2];
                                LoadEmpList();
                                Alreadyconfirm();
                            }

                        }

                    }
                });
            }
        }

        function PrintClick(PrintMode) {
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
            var Status = document.getElementById("<%=ddlPurchaseStatus.ClientID%>").value;
            var LedgerID = "";
            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Debit_note_List.aspx/ListPrint_PDF",
                    data: '{FINCYRID: "' + FINCYRID + '",orgID: "' + orgID + '",corptID: "' + corptID + '",DecCnt: "' + DecCnt + '",CnclSts: "' + CnclSts + '",fromDate: "' + fromDate + '",toDate: "' + toDate + '",Status: "' + Status + '",LedgerID: "' + LedgerID + '",strPrintMode: "' + strPrintMode + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            if (data.d != "") {
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
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:HiddenField ID="HiddenRoleEdit" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="Hiddencnclsts" runat="server" />
    <asp:HiddenField ID="HiddenFieldDecimalCnt" runat="server" />
    <asp:HiddenField ID="hiddenEnableCancl" runat="server" />
    <asp:HiddenField ID="HiddenFnancialEndDeate" runat="server" />
    <asp:HiddenField ID="HiddenFinancialStartDate" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="HiddenCurrencyAbrv" runat="server" />
    <asp:HiddenField ID="HiddenConfirmProvision" runat="server" />
    <asp:HiddenField ID="HiddenAuditProvision" runat="server" />
    <asp:HiddenField ID="HiddenReopenProvision" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYearId" runat="server" />
    <asp:HiddenField ID="HiddenProvisionSts" runat="server" />

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:Button ID="btnEdit" runat="server" Text="Button" style="display:none"/>

     <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Debit Note</li>
    </ol>

      <!---alert_message_section---->
    <div class="myAlert-top alert alert-success" id="success-alert">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Success!</strong> Changes completed succesfully
    </div>

    <div class="myAlert-bottom alert alert-danger" id="divWarning">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Danger!</strong> Request not conmpleted
    </div>
<!----alert_message_section_closed---->
    <div class="content_area_container cont_contr">
        <div class="content_box1 cont_contr">
            <h1>Debit Note list</h1>

            <div class="form-group fg5">
                <label for="pwd" class="fg2_la1">From Date:<span class="spn1"></span> </label>
                <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                    <input id="txtDateFrom" runat="server" name="txtDateFrom" onkeypress="return isTag(event)" onkeydown="return isTag(event)" class="form-control inp_bdr" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="10" type="text" />
                    <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                </div>

                <script>

                    var StartDateVal = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
                    var EndDateVal = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
                    var $noCon4 = jQuery.noConflict();
                    $noCon4('#datepicker').datepicker({
                        autoclose: true,
                        format: 'dd-mm-yyyy',

                        timepicker: false,
                        startDate: StartDateVal,
                        endDate: EndDateVal,
                    });
                </script>
            </div>

            <div class="form-group fg5">
                <label for="pwd" class="fg2_la1">To Date:<span class="spn1"></span> </label>
                <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                    <input id="txtDateTo" runat="server" name="txtDateTo" onkeypress="return isTag(event)" onkeydown="return isTag(event)" class="form-control inp_bdr" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="10" type="text" />
                    <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                </div>
            </div>


            <script>
                var StartDateVal = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
                var EndDateVal = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
                $noCon4('#datepicker1').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false,
                    startDate: StartDateVal,
                    endDate: EndDateVal
                });
            </script>

            <div class="form-group fg5">
                <label for="email" class="fg2_la1">Debit Note Status:<span class="spn1"></span></label>
                <asp:DropDownList ID="ddlPurchaseStatus" class="form-control fg2_inp1 fg_chs1" runat="server">
                    <asp:ListItem Text="All" Value="4" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Confirmed" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Reopened" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="fg5">
                <label class="form1 mar_bo mar_tp">
                    <span class="button-checkbox">
                        <asp:CheckBox ID="CbxCnclStatus" Text="" class="hidden" runat="server" Checked="false" onclick="DisableEnter(event)" onkeydown="return DisableEnter(event)" />
                        <button type="button" class="btn-d" data-color="p"></button>
                    </span>
                    <p class="pz_s">Show Deleted Entries</p>
                </label>
            </div>

            <div class="fg5">
                <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClientClick="return SearchValidate();" OnClick="btnSearch_Click" />
            </div>

            <div class="clearfix"></div>
            <div class="devider"></div>

              <div id="divList" runat="server" class="widget-body"></div>

            <div id="divAdd" onclick="location.href='fms_Debit_Note.aspx'" class="add" runat="server">
                <a href="fms_Debit_Note.aspx" type="button" onclick="topFunction()" id="myBtn" title="Add New">
                    <i class="fa fa-plus-circle"></i>
                </a>
            </div>

            <button id="print" onclick="return PrintClick('pdf');" class="print_o" title="Print page"><i class="fa fa-print"></i></button>
            <button id="csv" onclick="return PrintClick('csv');" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>

            </div>
        </div>

               <%--------------------------------View for error Reason--------------------------%>


    <div class="modal fade" id="dialog_simple" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document">
            <div class="modal-content">
                <div class="modal-header mo_hd1">
                    <h5 class="modal-title" id="H1">Reason for delete</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>
                    <textarea id="txtCancelReason" placeholder="Write reason for delete" rows="6" class="text_ar1" onblur="RemoveTag('txtCancelReason')" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="resize: none;"></textarea>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-success" data-toggle="modal">SAVE</button>
                    <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
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
    <div id="divTitle" runat="server" style="display: none">
        DEBIT NOTE
    </div>
</asp:Content>

