<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Postdated_Cheque_List.aspx.cs" Inherits="FMS_FMS_Master_fms_Postdated_Cheque_fms_Postdated_Cheque_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>

    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>

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
        var $noCon = jQuery.noConflict();
        //for search option
        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();
        $au(function () {
            $au(".ddl").selectToAutocomplete1Letter();
        });
        var $noCon1 = jQuery.noConflict();
        $noCon(window).load(function () {

            var ReopenSts = '<%= Session["REOPEN_STS"] %>';
            if (ReopenSts != '') {
                if (ReopenSts == 'successReopen') {
                    successReopen();
                }
                else if (ReopenSts == 'failed') {
                    SuccessError();
                } else if (ReopenSts == 'successConfirm') {
                    SuccesssuccessConfirm();
                }
                else if (ReopenSts == 'Paid') {
                    AlreadyPaid();
                }
                else if (ReopenSts == 'Canceled') {
                    AlreadyCanceled();
                }
            }
            LoadEmpList();
        });
        function LoadEmpList() {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var responsiveHelper_datatable_fixed_column = undefined;
            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };
            if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                /* COLUMN FILTER  */
                var otable = $NoConfi3('#datatable_fixed_column').DataTable({

                    "columnDefs": [
                         {
                             "targets": 0,
                             "orderData": 6,
                         },
                          {
                              "targets": 5,
                              "orderData":7,
                          },
                       {
                           "targets": 7,
                           "visible": false
                       },
                          {
                              "targets": 6,
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
                        .column($NoConfi(this).parent().index() + ':visible')
                        .search(this.value)
                        .draw();

                });
            }
            else {

                /* COLUMN FILTER  */
                var otable = $NoConfi3('#datatable_fixed_column').DataTable({

                    "columnDefs": [
                         {
                             "targets": 0,
                             "orderData": 7,
                         },
                          {
                              "targets": 5,
                              "orderData": 8,
                          },
                       {
                           "targets": 7,
                           "visible": false
                       },
                          {
                              "targets": 8,
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
                        .column($NoConfi(this).parent().index() + ':visible')
                        .search(this.value)
                        .draw();

                });
            }    
        }
        function AlreadyCanceled() {
            $noCon("#divWarning").html("Cheque is already canceled!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function Alreadyconfirmed() {
            $noCon("#divWarning").html("Cheque is already confirmed!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function AmountError() {
            $noCon("#divWarning").html("Cheque amount cannot be greater than the invoice balance amount to be paid!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function AlreadyPaid() {
            $noCon("#divWarning").html("Cheque is already paid!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessError() {
            $noCon("#divWarning").html("Some error occured!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccesssuccessConfirm() {
            var ret = false;
            $noCon("#success-alert").html("Postdated Cheque confirmed successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function successReopen() {
            var ret = false;
            $noCon("#success-alert").html("Postdated Cheque reopened successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        //0039
        function AlreadyReopened() {
            var ret = false;
            $noCon("#divWarning").html("Postdated Cheque already reopened.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        //end
        function SuccessCancelation() {
            $noCon("#success-alert").html("Postdated Cheque details deleted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        } function Alreadycancel() {
            $noCon("#divWarning").html("Postdated Cheque  deleted already.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessNotConfirmation() {
            $noCon("#divWarning").html("Postdated Cheque is already confirmed.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SearchValidate() {
            var ret = true;
            var DateFrom = document.getElementById("cphMain_txtFromDate").value.trim();
            var DateTo = document.getElementById("cphMain_txtToDate").value.trim();

            document.getElementById("cphMain_txtToDate").style.borderColor = "";
            document.getElementById("cphMain_txtFromDate").style.borderColor = "";

            if (DateTo == "") {
                document.getElementById("cphMain_txtToDate").style.borderColor = "Red";
                document.getElementById("cphMain_txtToDate").focus();
                ret = false;
            }
            if (DateFrom == "") {
                document.getElementById("cphMain_txtFromDate").style.borderColor = "Red";
                document.getElementById("cphMain_txtFromDate").focus();
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
                    document.getElementById("cphMain_txtFromDate").style.borderColor = "Red";
                    document.getElementById("cphMain_txtToDate").style.borderColor = "Red";
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
        function ConfirmByID(strChequeId) {

            var LedgrId = document.getElementById("cphMain_ddlAccount").value.trim();
            var Status = document.getElementById("cphMain_DdlStatus").value.trim();
            var ToDate = document.getElementById("cphMain_txtToDate").value.trim();
            var FromDate = document.getElementById("cphMain_txtFromDate").value.trim();
            var FinStartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
            var FinEndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
            var TransType = document.getElementById("cphMain_ddlType").value.trim();
            var strHiddenDecimalCount = document.getElementById("<%=HiddenDecimalCount.ClientID%>").value;
            var strHiddenEnableModify = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
            var strHiddenAuditProvisionStatus = document.getElementById("<%=HiddenAuditProvisionStatus.ClientID%>").value;
            var strHiddenProvisionSts = document.getElementById("<%=HiddenProvisionSts.ClientID%>").value;
            var strHiddenConfirmStatus = document.getElementById("<%=HiddenConfirmStatus.ClientID%>").value;
            var strHiddenReopenSts = document.getElementById("<%=HiddenReopenSts.ClientID%>").value;
            var strHiddenEnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;


            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            var FinYrID = '<%=Session["FINCYRID"]%>';
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to confirm?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    if (strChequeId != "" && strUserID != '') {
                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "fms_Postdated_Cheque_List.aspx/ConfirmPostdatedChequeDetails",
                            data: '{strUserID: "' + strUserID + '",strChequeId: "' + strChequeId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",FinYrID: "' + FinYrID + '",LedgrId: "' + LedgrId + '",Status: "' + Status + '",ToDate: "' + ToDate + '",FromDate: "' + FromDate + '",FinStartDate: "' + FinStartDate + '",FinEndDate: "' + FinEndDate + '",TransType: "' + TransType + '",strHiddenDecimalCount: "' + strHiddenDecimalCount + '",strHiddenEnableModify: "' + strHiddenEnableModify + '",strHiddenAuditProvisionStatus: "' + strHiddenAuditProvisionStatus + '",strHiddenProvisionSts: "' + strHiddenProvisionSts + '",strHiddenConfirmStatus: "' + strHiddenConfirmStatus + '",strHiddenReopenSts: "' + strHiddenReopenSts + '",strHiddenEnableDelete: "' + strHiddenEnableDelete + '"}',
                            dataType: "json",
                            success: function (data) {
                                var ReopenSts = data.d[0];
                                $(window).scrollTop(0);
                                if (ReopenSts != '') {
                                     if (ReopenSts == 'failed') {
                                        SuccessError();
                                    } else if (ReopenSts == 'successConfirm') {
                                        SuccesssuccessConfirm();
                                    }
                                    else if (ReopenSts == 'Paid') {
                                        AlreadyPaid();
                                    }
                                    else if (ReopenSts == 'Canceled') {
                                        AlreadyCanceled();
                                    }
                                    else if (ReopenSts == 'Alreadyconfrm') {
                                        Alreadyconfirmed();
                                    }
                                    else if (ReopenSts == 'AmntERR') {
                                        AmountError();
                                    }
                                    document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                    LoadEmpList();
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
        function ReOpenByID(strChequeId) {

            var LedgrId = document.getElementById("cphMain_ddlAccount").value.trim();
            var Status = document.getElementById("cphMain_DdlStatus").value.trim();
            var ToDate = document.getElementById("cphMain_txtToDate").value.trim();
            var FromDate = document.getElementById("cphMain_txtFromDate").value.trim();
            var FinStartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
            var FinEndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
            var TransType = document.getElementById("cphMain_ddlType").value.trim();
            var strHiddenDecimalCount = document.getElementById("<%=HiddenDecimalCount.ClientID%>").value;
            var strHiddenEnableModify = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
            var strHiddenAuditProvisionStatus = document.getElementById("<%=HiddenAuditProvisionStatus.ClientID%>").value;
            var strHiddenProvisionSts = document.getElementById("<%=HiddenProvisionSts.ClientID%>").value;
            var strHiddenConfirmStatus = document.getElementById("<%=HiddenConfirmStatus.ClientID%>").value;
            var strHiddenReopenSts = document.getElementById("<%=HiddenReopenSts.ClientID%>").value;
            var strHiddenEnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;

           
              var strUserID = '<%=Session["USERID"]%>';
              var strOrgIdID = '<%=Session["ORGID"]%>';
              var strCorpID = '<%=Session["CORPOFFICEID"]%>';
              var FinYrID = '<%=Session["FINCYRID"]%>';
              ezBSAlert({
                  type: "confirm",
                  messageText: "Are you sure you want to reopen?",
                  alertType: "info"
              }).done(function (e) {
                  if (e == true) {
                      if (strChequeId != "" && strUserID != '') {
                          $.ajax({
                              type: "POST",
                              async: false,
                              contentType: "application/json; charset=utf-8",
                              url: "fms_Postdated_Cheque_List.aspx/ReopenPostdatedChequeDetails",
                              data: '{strUserID: "' + strUserID + '",strChequeId: "' + strChequeId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",FinYrID: "' + FinYrID + '",LedgrId: "' + LedgrId + '",Status: "' + Status + '",ToDate: "' + ToDate + '",FromDate: "' + FromDate + '",FinStartDate: "' + FinStartDate + '",FinEndDate: "' + FinEndDate + '",TransType: "' + TransType + '",strHiddenDecimalCount: "' + strHiddenDecimalCount + '",strHiddenEnableModify: "' + strHiddenEnableModify + '",strHiddenAuditProvisionStatus: "' + strHiddenAuditProvisionStatus + '",strHiddenProvisionSts: "' + strHiddenProvisionSts + '",strHiddenConfirmStatus: "' + strHiddenConfirmStatus + '",strHiddenReopenSts: "' + strHiddenReopenSts + '",strHiddenEnableDelete: "' + strHiddenEnableDelete + '"}',
                              dataType: "json",
                              success: function (data) {
                                  var ReopenSts = data.d[0];
                                  $(window).scrollTop(0);
                                  if (ReopenSts != '') {
                                      if (ReopenSts == 'successReopen') {
                                          successReopen();
                                      }
                                     else if (ReopenSts == 'Alreadyreopen') {
                                          AlreadyReopened();
                                      }
                                      else if (ReopenSts == 'failed') {
                                          SuccessError();
                                      }
                                      else if (ReopenSts == 'Paid') {
                                          AlreadyPaid();
                                      }
                                      else if (ReopenSts == 'Canceled') {
                                          AlreadyCanceled();
                                      }
                                      document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                      LoadEmpList();
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
        function OpenCancelView(StrId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to delete this postdated cheque?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
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
        function DeleteByID(strId, strCancelReason, strCancelMust) {
            var strUserID = '<%=Session["USERID"]%>';
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            if (strId != "" && strUserID != '') {
                var Details = PageMethods.Cancelpostdated_cheque(strId, strCancelMust, strUserID, strCancelReason, orgID, corptID, function (response) {
                    var SucessDetails = response;
                    $(window).scrollTop(0);
                    if (SucessDetails == "successcncl") {    
                        window.location = 'fms_Postdated_Cheque_List.aspx';
                        SuccessCancelation();
                    }
                    else if (SucessDetails == "AlreadyCancl") {          
                        window.location = 'fms_Postdated_Cheque_List.aspx';
                        Alreadycancel();
                    }
                    else {
                        window.location = 'fms_Postdated_Cheque_List.aspx';
                        SuccessNotConfirmation();
                    }
                });
            }

            return false;
        }
        function CloseCancelView() {
            ReasonConfirm = document.getElementById("txtCancelReason").value;
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
        function SuccessInsertion() {
            $noCon("#success-alert").html("Postdated cheque inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdation() {
            $noCon("#success-alert").html("Postdated cheque updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        //0039
        function AllreadyReopened() {
            $noCon("#divWarning").html("Postdated cheque already reopened.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        //end
        //0039
        function Reopensucce() {
            $noCon("#success-alert").html("Postdated cheque reopened successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        //end
        function SuccessConfirmation() {
            $noCon("#success-alert").html("Postdated cheque confirmed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenCurrencyId" runat="server" />
    <asp:HiddenField ID="HiddenCurrrencyAbrvtn" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="HiddenConfirmStatus" runat="server" />
    <asp:HiddenField ID="HiddenEnableModify" runat="server" />
    <asp:HiddenField ID="HiddenEnableDelete" runat="server" />
    <asp:HiddenField ID="HiddenReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenAuditProvisionStatus" runat="server" />
    <asp:HiddenField ID="HiddenFnancialEndDeate" runat="server" />
    <asp:HiddenField ID="HiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="HiddenFinancialStartDate" runat="server" />
    <asp:HiddenField ID="HiddenReopenProvision" runat="server" />
    <asp:HiddenField ID="HiddenProvisionSts" runat="server" />
    
     <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
 
        <ol class="breadcrumb sticky1">
            <li><a id="aHome" runat="server" href="">Home</a></li>
            <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
            <li class="active">Postdated Cheque</li>
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

        <div class="content_sec2 cont_contr">
            <div class="content_area_container cont_contr">
                <div class="content_box1 cont_contr">
                    <h1>POSTDATED CHEQUE</h1>

                    <div class="form-group fg5 mar_bo1">
                        <label for="email" class="fg2_la1">Account Book:<span class="spn1"></span></label>
                        <div id="divAccount">
                            <asp:DropDownList ID="ddlAccount" class="form-control fg2_inp1 fg_chs1 ddl" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                      <div class="form-group fg8 mar_bo1">
          <label for="email" class="fg2_la1">Transaction Type:<span class="spn1"></span></label>
          <select class="form-control fg2_inp1 fg_chs1" id="ddlType" runat="server">            
            <option value="0">Payment</option>
            <option value="1">Receipt</option>
          </select>    
        </div>

                    <div class="form-group fg7">
                        <label for="pwd" class="fg2_la1">From Date:<span class="spn1"></span> </label>
                        <div id="datepicker" class="input-group date" data-date-format="dd-mm-yyyy">
                            <input id="txtFromDate" runat="server" class="form-control inp_bdr" type="text" />
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

                    <div class="form-group fg7">
                        <label for="pwd" class="fg2_la1">To Date:<span class="spn1"></span></label>
                        <div id="datepicker1" class="input-group date" data-date-format="dd-mm-yyyy">
                            <input id="txtToDate" runat="server" class="form-control inp_bdr" type="text" />
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

                    <div class="form-group fg7 mar_bo1">
                        <label for="email" class="fg2_la1">Status:<span class="spn1"></span></label>
                         <asp:DropDownList ID="DdlStatus" class="form-control fg2_inp1 fg_chs1" runat="server">
                             <asp:ListItem Value="0">Pending</asp:ListItem>
                             <asp:ListItem Value="1">Payment Pending</asp:ListItem>
                             <asp:ListItem Value="2">Payment Completed</asp:ListItem>
                             <asp:ListItem Value="3">Reopened</asp:ListItem>
<%--                             <asp:ListItem Value="4" Selected="True">All</asp:ListItem>--%>
                            </asp:DropDownList>
                    </div>

                    <div class="fg7">
                        <label class="form1 mar_bo mar_tp">
                            <span class="button-checkbox">
                                <button type="button" class="btn-d" data-color="p"></button>
                                <asp:CheckBox ID="cbxCnclStatus" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" Text="" runat="server" Checked="false" class="form2" />
                            </span>
                            <p class="pz_s">Show Deleted Entries</p>
                        </label>
                    </div>

                    <div class="fg8">
                        <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnSearch" Style="cursor: pointer;" runat="server" class="submit_ser" OnClientClick="return SearchValidate();" OnClick="btnSearch_Click"/>

                    </div>
                    <br>

                    <div class="clearfix"></div>
          <div class="devider"></div> 
                  <div id="divList" runat="server" class="widget-body"></div>
                </div>
            </div>
        </div>
           <div id="divAdd" runat="server" onclick="location.href='fms_Postdated_Cheque.aspx'">
            <a href="fms_Postdated_Cheque.aspx" type="button" onclick="topFunction()" id="myBtn" title="Add New">
                <i class="fa fa-plus-circle"></i>
            </a></div>
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
        POSTDATED CHEQUE
    </div>
</asp:Content>

