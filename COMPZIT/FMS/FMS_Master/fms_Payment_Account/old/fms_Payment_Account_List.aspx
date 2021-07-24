<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Payment_Account_List.aspx.cs" Inherits="FMS_FMS_Master_fms_Payment_Account_fms_Payment_Account_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

     <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>

    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            $("#divAccount" + "> input").focus();

            var ReopenSts = '<%= Session["REOPEN_STS"] %>';
              if (ReopenSts != '') {
                  if (ReopenSts == 'successReopen') {
                      SuccessReoen();
                  }
                  else if (ReopenSts == 'failed') {
                      SuccessErrorReoen();
                  }
                  else if (ReopenSts == 'alrdydeleted') {
                      SuccessDeletedList();
                  }
                  else if (ReopenSts == 'auditclosed') {
                      AuditClosedList();
                  }

                  else if (ReopenSts == 'acntclosed') {
                      AcntClosedList();
                  }
                  else if (ReopenSts == 'successConfirm') {
                      SuccessConfirm();
                  }
                  else if (ReopenSts == 'alrdyConfirmed') {
                      SuccessConfirmed();
                  }
              }
              var CheckSts = '<%= Session["CHK_ISSUE"] %>';
              if (CheckSts != '') {
                  if (CheckSts == 'successIssue') {
                      SuccessCheckIssue();
                  }
                  else if (CheckSts == 'failed') {
                      SuccessErrorReoenCheck();
                  }
              }
              LoadEmployeeList(0);
              loadTableDesg();
          });
          function SalesAmountExceeded() {
              $noCon("#divWarning").html(" Payment amount should not be greater than purchase amount.");
              $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
              });

              return false;
          }
          function SuccessConfirm() {
              var ret = false;
              $noCon("#success-alert").html("Payment details confirmed successfully.");
              $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

              });
              '<%Session["REOPEN_STS"] = "' + null + '"; %>';
              return false;
          }
          function SuccessInsertion() {
              $noCon("#success-alert").html("Payment inserted successfully.");
              $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
              });

              return false;

          }
          function SuccessUpdation() {
              $noCon("#success-alert").html("Payment updated successfully.");
              $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
              });

              return false;
          }
          function SuccessConfirmed() {
              var ret = false;
              $noCon("#success-alert").html("Purchase details already confirmed.");
              $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

              });
              '<%Session["REOPEN_STS"] = "' + null + '"; %>';
              return false;
          }
          function AuditClosedList() {
              $noCon("#divWarning").html("This action is  denied! Audit is already closed.");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              '<%Session["REOPEN_STS"] = "' + null + '"; %>';
              return false;
          }
          function AcntClosedList() {
              $noCon("#divWarning").html("This action is  denied! Account is already closed.");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              '<%Session["REOPEN_STS"] = "' + null + '"; %>';
              return false;
          }
          function SuccessDeletedList() {

              $noCon("#divWarning").html("This action is  denied! This Payment is already deleted .");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });

              '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function ChequeNumberDuplicationMsg() {
            $noCon("#divWarning").html("This cheque number is already used.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            
            $noCon(window).scrollTop(0);
            return false;
        }
        function PrintVersnError() {
            $noCon("#divWarning").html("Please select a version for printing from account setting.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            
            return false;
        }
        function loadTableDesg() {

            $noCon(function () {
                //$noCon('#dialog_simple').dialog({
                //    autoOpen: false,
                //    width: 600,
                //    resizable: false,
                //    modal: true,
                //    title: "Payment",
                //});
            });
        }

        function getdetails(href) {
            window.location = href;
            return false;
        }
        function SuccessCheckIssue() {
            var ret = false;
            $noCon("#success-alert").html("cheque issued successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["CHK_ISSUE"] = "' + null + '"; %>';
              return false;
          }
          function SuccessReoen() {
              var ret = false;
              $noCon("#success-alert").html("Payment reopened successfully.");
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
          function SuccessErrorReoenCheck() {
              $noCon("#divWarning").html("Some error occured!.");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              '<%Session["CHK_ISSUE"] = "' + null + '"; %>';
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
          function SuccessDeleted() {

              $noCon("#divWarning").html("This action is  denied! This Payment is already deleted .");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });


              return false;
          }
          function SearchValidation() {

              var ret = true;
              document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
              var fromdate = document.getElementById("cphMain_txtFromdate").value;
              var toDate = document.getElementById("cphMain_txtTodate").value;
              if (fromdate == "" && toDate == "") {
                  document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                  document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                  });
                  
                  $noCon(window).scrollTop(0);
                  ret = false;
              }
              if (fromdate != "" && toDate != "") {

                  var arrDateFromchk = fromdate.split("-");
                  dateDateFromchk = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);

                  var arrDateTochk = toDate.split("-");
                  dateDateTochk = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);
                  if (dateDateFromchk > dateDateTochk) {
                      $noCon("#divWarning").html("From date should not be greater than to date.");
                      $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                      });
                      
                      $noCon(window).scrollTop(0);
                      document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                      document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                      ret = false;
                  }
              }
              if (ret == true) {
                  LoadEmployeeList(0);
              }
              return ret;
            
          }
          function CloseCancelView() {
              ezBSAlert({
                  type: "confirm",
                  messageText: "Do you want to close  without completing cancellation process?",
                  alertType: "info"
              }).done(function (e) {
                  if (e == true) {
                      $('#dialog_simple').modal('hide');

                      document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = "";
                  }
                  else {
                      $('#dialog_simple').modal('show');
                      return false;
                  }
              });
              return false;
          }

        function ConfirmByID(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to confirm this payment?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    CheckSaleSettlements(StrId);
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
                  url: "fms_Payment_Account_List.aspx/CheckSaleSettlement",
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

          function Confirm(strId) {

              var strUserID = '<%=Session["USERID"]%>';
              var strOrgIdID = '<%=Session["ORGID"]%>';
              var strCorpID = '<%=Session["CORPOFFICEID"]%>';
              var strFinYrID = '<%=Session["FINCYRID"]%>';
              if (strId != "" && strUserID != '') {

                  var Details = PageMethods.ConfirmPurchaseDetails(strUserID, strId, strOrgIdID, strCorpID, strFinYrID, function (response) {
                      var SucessDetails = response[0];
                      $(window).scrollTop(0);

                      var ReopenSts = SucessDetails;
                      if (ReopenSts != '') {
                          $(window).scrollTop(0);
                          LoadEmployeeList(0);
                          if (ReopenSts == 'successReopen') {
                              SuccessReoen();
                          }
                          else if (ReopenSts == 'failed') {
                              SuccessErrorReoen();
                          }
                          else if (ReopenSts == 'alrdydeleted') {
                              SuccessDeletedList();
                          }
                          else if (ReopenSts == 'auditclosed') {
                              AuditClosedList();
                          }

                          else if (ReopenSts == 'acntclosed') {
                              AcntClosedList();
                          }
                          else if (ReopenSts == 'successConfirm') {
                              SuccessConfirm();
                          }
                          else if (ReopenSts == 'alrdyConfirmed') {
                              SuccessConfirmed();
                          }
                          else if (ReopenSts == 'SalesAmountExceeded') {
                              SalesAmountExceeded();
                          }
                           if (ReopenSts != 'failed') {
                               if (document.getElementById("<%=HiddenFieldRecurrRole.ClientID%>").value == "1") {
                                   if (response[3] != "" && response[3] != null) {
                                       document.getElementById("cphMain_sPendOrdNum").innerText = response[3];
                                       document.getElementById("cphMain_menu1").style.display = "block";
                                   }
                                   else {
                                       document.getElementById("cphMain_menu1").style.display = "none";
                                   }
                                   document.getElementById("cphMain_myTable").innerHTML = response[4];
                               }
                          }
                      }
                  });


              }

              return false;
          }

        function PurchaseAmountExceeded() {
            $noCon("#divWarning").html("Payment amount should not be greater than purchase amount.");
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

        function PrintClick() {

            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var LedgerId = 0;
            var AccountId = 0;
            var SupName = "";
            var Suplier = 0;
            if (document.getElementById("<%=ddlAccount.ClientID%>").value != "--SELECT ACCOUNT--") {
                AccountId = document.getElementById("<%=ddlAccount.ClientID%>").value;
                SupName = $("#cphMain_ddlAccount :selected").text();
            }
            var PurchaseStatus = document.getElementById("cphMain_ddlPurchaseStatus").value;
            if (document.getElementById("<%=ddlLedger.ClientID%>").value != "--SELECT LEDGER--") {
                LedgerId = document.getElementById("<%=ddlLedger.ClientID%>").value;
            }
            var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;
            var CnclSts = 0;
            var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
            //var PurchaseStatus = document.getElementById("cphMain_ddlPurchaseStatus").value;
            var StartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
            var EndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
            var Currency = document.getElementById("<%=HiddenCurrrencyAbrvtn.ClientID%>").value;

            if (document.getElementById("cphMain_cbxCnclStatus").checked == true)
                CnclSts = 1;

            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Payment_Account_List.aspx/PrintList",
                    data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",PurchaseStatus: "' + PurchaseStatus + '",AccountId: "' + AccountId + '",from: "' + from + '",toDt: "' + toDt + '",CnclSts: "' + CnclSts + '",CurrencyId: "' + CurrencyId + '",StartDate: "' + StartDate + '",EndDate: "' + EndDate + '",LedgerId: "' + LedgerId + '",SupName: "' + SupName + '",Currency: "' + Currency + '"}',
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
                    var LedgerId = 0;
                    var AccountId = 0;
                    var SupName = "";
                    var Suplier = 0;
                    if (document.getElementById("<%=ddlAccount.ClientID%>").value != "--SELECT ACCOUNT--") {
                AccountId = document.getElementById("<%=ddlAccount.ClientID%>").value;
                SupName = $("#cphMain_ddlAccount :selected").text();
            }
            var PurchaseStatus = document.getElementById("cphMain_ddlPurchaseStatus").value;
            if (document.getElementById("<%=ddlLedger.ClientID%>").value != "--SELECT LEDGER--") {
                LedgerId = document.getElementById("<%=ddlLedger.ClientID%>").value;
            }
            var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
                    var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;
                    var CnclSts = 0;
                    var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
                    //var PurchaseStatus = document.getElementById("cphMain_ddlPurchaseStatus").value;
            var StartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
                    var EndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
                    var Currency = document.getElementById("<%=HiddenCurrrencyAbrvtn.ClientID%>").value;

                    if (document.getElementById("cphMain_cbxCnclStatus").checked == true)
                        CnclSts = 1;

                    if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "fms_Payment_Account_List.aspx/PrintCSV",
                            data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",PurchaseStatus: "' + PurchaseStatus + '",AccountId: "' + AccountId + '",from: "' + from + '",toDt: "' + toDt + '",CnclSts: "' + CnclSts + '",CurrencyId: "' + CurrencyId + '",StartDate: "' + StartDate + '",EndDate: "' + EndDate + '",LedgerId: "' + LedgerId + '",SupName: "' + SupName + '",Currency: "' + Currency + '"}',
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="HiddenEnableDelete" runat="server" />
    <asp:HiddenField ID="HiddenEnableModify" runat="server" />
    <asp:HiddenField ID="HiddenPayemntID" runat="server" />
    <asp:HiddenField ID="HiddenAuditProvisionStatus" runat="server" />
    <asp:HiddenField ID="HiddenConfirmStatus" runat="server" />
    <asp:HiddenField ID="HiddenProvisionSts" runat="server" />
    <asp:HiddenField ID="HiddenReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenFinancialStartDate" runat="server" />
    <asp:HiddenField ID="HiddenFnancialEndDeate" runat="server" />
    <asp:HiddenField ID="HiddenAccountClsDate" runat="server" />
    <asp:HiddenField ID="HiddenCurrrencyAbrvtn" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
     <asp:HiddenField ID="HiddenFieldRecurrRole" runat="server" />
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Payment</li>
    </ol>
              <div id="divAdd"  runat="server" onclick="location.href='fms_Payment_Account.aspx'"  >
               <a   href="fms_Payment_Account.aspx" type="button" onclick="topFunction()" id="myBtn"  title="Add New" >
                  <i class="fa fa-plus-circle"></i>
               </a>
        </div>

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
                <h1 class="h1_con">Payment</h1>
                <div class="form-group fg5 mar_bo1">
                    <label for="email" class="fg2_la1">Account Book:<span class="spn1"></span></label>
                    <div id="divAccount">
                        <asp:DropDownList ID="ddlAccount" class="form-control fg2_inp1 fg_chs1 ddl" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group fg7">
                    <label for="pwd" class="fg2_la1">From Date:<span class="spn1"></span> </label>
                    <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtFromdate" runat="server" type="text" autocomplete="off" onkeypress="return DisableEnterAndComma(event)" onkeydown="return DisableEnterAndComma(event)" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
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
                    <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtTodate" runat="server" type="text" autocomplete="off" onkeypress="return DisableEnterAndComma(event)" onkeydown="return DisableEnterAndComma(event)" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
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
                    <label for="email" class="fg2_la1">Payment Status:<span class="spn1"></span></label>
                    <asp:DropDownList ID="ddlPurchaseStatus" class="form-control fg2_inp1 fg_chs1" runat="server">
                        <asp:ListItem Text="All" Value="3" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Confirmed" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Reopened" Value="2"></asp:ListItem>
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

                <div class="fg5">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnSearch" Style="cursor: pointer;" runat="server" class="submit_ser" OnClientClick="return SearchValidation();" />
                </div>
                <br>
                <div class="clearfix"></div>
                <div class="devider"></div>

                    <table id="datatable_fixed_column" class="display table-bordered" cellspacing="0" width="100%">
                        <thead class="thead1">
                            <tr>
                                <th class="th_b1 tr_l">REF #
                                    <input type="text" class="tb_inp_1 tb_in" placeholder="REF #" onkeydown="return DisableEnter(event)" /></th>
                                <th class="th_b4 tr_l">Account
                                    <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                    <br />
                                    <input type="text" class="tb_inp_1 tb_in" placeholder="Account Group" onkeydown="return DisableEnter(event)" />
                                </th>
                                <th class="th_b1 tr_l">Payee Name
                                    <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                    <br />
                                    <input type="text" class="tb_inp_1 tb_in" placeholder="Payee Name" onkeydown="return DisableEnter(event)" />
                                </th>
                                <th class="th_b1 tr_c">Date
                                    <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                    <input type="text" class="tb_inp_1 tb_in" placeholder="Date" onkeydown="return DisableEnter(event)" />
                                </th>
                                <th class="th_b7 tr_l">Narration
                                    <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                    <br />
                                    <input type="text" class="tb_inp_1 tb_in" placeholder="Narration" onkeydown="return DisableEnter(event)" />
                                </th>
                                <th class="th_b7 tr_r">Total Amount
                                    <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                    <input type="text" class="tb_inp_1 tb_in" placeholder="Total Amount" onkeydown="return DisableEnter(event)" />
                                </th>
                                <th class="th_b1_4 ">Status
                                    <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                </th>
                                <th class="th_b4">Actions
                                    <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td colspan="6" class="dataTables_empty">Loading details...</td>
                            </tr>
                        </tbody>
                         <tr id="trTotal" runat="server">

                        </tr>
                    </table>
            </div>
        </div>
    </div>
    <div id="divPrint" style="cursor: default; float: right; height: 39px; margin-right: 5%; margin-top: 0%; font-family: Calibri; display: none" class="print">
        <a id="print_cap" target="_blank" href="/FMS/FMS_Master/fms_Payment_Account/18_Print.htm" style="color: rgb(83, 101, 51)">
            <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%; margin-bottom: -46%; margin-left: -18%;">
            <span style="margin-top: 2px; margin-left: 35%;">Print</span></a>
    </div>



    <input type="text" id="lblWidth" style="display: none;" runat="server" />
    <input type="text" id="lblHeight" style="display: none;" runat="server" />
    <input type="text" id="lblPayeeTop" style="display: none;" runat="server" />
    <input type="text" id="lblPayeeLeft" style="display: none;" runat="server" />
    <input type="text" id="lblDateTop" style="display: none;" runat="server" />
    <input type="text" id="lblDateLeft" style="display: none;" runat="server" />
    <input type="text" id="lblAmntWordTop" style="display: none;" runat="server" />
    <input type="text" id="lblAmntWordLeft" style="display: none;" runat="server" />
    <input type="text" id="lblAmntWordTop1" style="display: none;" runat="server" />
    <input type="text" id="lblAmntWordLeft1" style="display: none;" runat="server" />
    <input type="text" id="lblAmntNumTop" style="display: none;" runat="server" />
    <input type="text" id="lblAmntNumLeft" style="display: none;" runat="server" />

    <input type="text" id="lblPayeeTopS" style="display: none;" runat="server" />
    <input type="text" id="lblDateTopS" style="display: none;" runat="server" />
    <input type="text" id="lblAmntWordTopS" style="display: none;" runat="server" />
    <input type="text" id="lblAmntWordTop1S" style="display: none;" runat="server" />
    <input type="text" id="lblAmntNumTopS" style="display: none;" runat="server" />
    <asp:HiddenField ID="HiddenAuditClsDate" runat="server" />
    <asp:HiddenField ID="HiddenAccountCloseDate" runat="server" />


    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <div class="eachform" style="width: 32%; margin-top: 2%; margin-left: 4%; display: none;">
        <h2 style="margin-top: 1%;">Ledger </h2>
        <asp:DropDownList ID="ddlLedger" Height="30px" class="form-control ddl" runat="server" Style="margin-left: 25%; margin-bottom: 2%; width: 64%;">
        </asp:DropDownList>
    </div>
    <div class="cont_rght">
        <button id="print" onclick="return PrintClick();" class="print_o" title="Print page"><i class="fa fa-print"></i></button>
        <button id="csv" onclick="return PrintCSV();" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>
        <br />
        <div id="divReport" class="table-responsive" runat="server" style="display: none;">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>




        <asp:TextBox ID="TextBox1" Style="display: none; width: 65%; text-transform: uppercase; height: 20px;" runat="server" MaxLength="50" class="form-control resizable" onkeypress="return DisableEnter(event)"></asp:TextBox>

        <asp:TextBox ID="TextBox2" Style="display: none; width: 20%; text-transform: uppercase; height: 20px;" runat="server" MaxLength="10" class=" form-control datepicker resizable" onkeypress="return DisableEnter(event)"></asp:TextBox>


        <asp:TextBox ID="TextBox3" Style="display: none; width: 59%; text-transform: uppercase; height: 20px;" runat="server" MaxLength="50" class="form-control resizable" onkeypress="return DisableEnter(event)"></asp:TextBox>


        <asp:TextBox ID="TextBox4" Style="display: none; width: 19%; text-transform: uppercase; height: 25px;" runat="server" MaxLength="15" class="form-control resizable" onkeypress="return isDecimalNumber(event,'cphMain_TextBox4')" onkeydown="return isDecimalNumber(event,'cphMain_TextBox4')"></asp:TextBox>

        <asp:TextBox ID="TextBox5" Style="display: none; width: 64%; text-transform: uppercase; height: 20px;" runat="server" MaxLength="50" class="form-control resizable" onkeypress="return DisableEnter(event)"></asp:TextBox>

        <a id="ButtonPrint" style="display: none" class="btn btn-primary" target="_blank" href="/FMS/FMS_Master/fms_Payment_Account/cheque_Print.htm"></a>



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
                    <textarea id="txtCancelReason" placeholder="Write reason for delete" rows="6" maxlength="500" style="resize:none;" class="text_ar1"></textarea>
                </div>
                <div class="modal-footer">
                        <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-success"><i class="fa fa-trash-o"></i>&nbsp; Save</button>
                        <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-danger"><i class="fa fa-times"></i>&nbsp; Cancel</button>
                </div>
            </div>
        </div>
    </div>      

        <!-- Modal -->
        <div class="modal fade" id="myModal" data-backdrop="static" role="dialog" tabindex="-1">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 id="ModelHeading" class="modal-title"></h4>
                    </div>
                    <div class="alert alert-danger fade in" id="divErrMsgCnclRsnCheque" style="display: none;">

                        <i class="fa-fw fa fa-times"></i>
                        <strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReasonCheque"> Please fill this out</label>
                    </div>
                    <div class="modal-body">

                        <div class="col-md-12">

                            <div class="col-md-12 res_table_box">
                                <div class="tab-content" id="myTabContent">
                                    <%--  <div class="tab-pane fade active in" id="home" role="tabpanel" aria-labelledby="home-tab" style="border:1px solid #dddddd;
    padding: 3px;">--%>

                                    <%--  <ul class="list-group bg-grey" style="font-size:15px;">--%>
                                    <%--  <li class="list-group-item" style="font-weight:bold;"> 
 Resident  </li>--%>
                                    <%--<div id="Div2" class="input-group date" data-date-format="mm-dd-yyyy">
                                        <input id="Text1" runat="server" type="text" autocomplete="off" onkeypress="return DisableEnterAndComma(event)" onkeydown="return DisableEnterAndComma(event)" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
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
                                    </div>--%>

                                    <div class="form-group col-md-12" style="">
                                         <%-- <label for="pwd" class="fg2_la1">From Date:<span class="spn1"></span> </label>--%>
                                      <label for="example-text-input" class="col-md-5 col-form-label">Cheque Issue Date<span>*</span></label>
                                         <div id="datepicker3" class="input-group date" data-date-format="mm-dd-yyyy">
                                            <input id="txtdate" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                              <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                                              <script>
                                                  var StartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value
                                                  var curentDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value
                                                  $noCon('#datepicker3').datepicker({
                                                      autoclose: true,
                                                      format: 'dd-mm-yyyy',
                                                      startDate: StartDate,
                                                      endDate: curentDate,
                                                      timepicker: false
                                                  });
                                        </script>
                                        </div>
                                    </div>
                                   

                                    <%--</ul>--%>
                                    <%--  </div>--%>
                                </div>
                            </div>
                        </div>


                    </div>
                    <div class="clearfix"></div>
                    <div class="modal-footer">
                        <button id="btnImportSales" type="button" class="btn btn-success" onclick="ButtnCheckIssueDate();">Submit</button>
                        <button id="BttnTemp" type="button" style="display: none" class="btn btn-danger" data-dismiss="modal"></button>
                    </div>
                </div>




            </div>
        </div>

    </div>
    <button id="BtnPopup" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>




      <div class="pending" type="button"   data-toggle="modal" data-target="#myrecur" title="Pending Actions" id="menu1" runat="server">
  <i class="fa fa-retweet" aria-hidden="true"></i>
  <span class="badge beln cht cht1 pen_b" id="sPendOrdNum" runat="server"></span>
</div>

<!-- Modal -->
<div class="modal fade" id="myrecur" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog rec_db" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Pending Actions</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
       <table class="table table-bordered table-fixed">
    <thead class="thead1">
      <tr>
        <th class="td_rec">Date</th>
        <th class="td_rec1">Ref#</th>
        <th class="td_rec">Action</th>
      </tr>
    </thead>
    <tbody id="myTable" runat="server">
     
    </tbody>
  </table>
      </div>
    </div>
  </div>
</div>




<div id="pan_l" class="l1">
</div>
    <!---slide toogle of pending Orders--->
<script>
    $(document).ready(function () {
        $(".flip_o").mouseover(function () {
            $(".l1").show("200");
        });
        $(".flip_o").mouseout(function () {
            $(".l1").hide("");
        });
    });

    function RecurReject(strid, obj) {
        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to reject this item?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {
        var UserId = '<%= Session["USERID"] %>';
        if (strid != "" && UserId != "") {
            $.ajax({
                type: "POST",
                async: false,
                url: "fms_Payment_Account_List.aspx/RecurReject",
                data: '{strid:"' + strid + '",UserId:"' + UserId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {                  
                    obj.closest('tr').remove();
                    var cnt = parseInt(document.getElementById("cphMain_sPendOrdNum").innerText);
                    cnt = cnt - 1;
                    if (cnt <= 0) {
                        document.getElementById("cphMain_menu1").style.display = "none";
                        $('#myrecur').modal('hide');
                    }
                    else {
                        document.getElementById("cphMain_sPendOrdNum").innerText = cnt;
                    }
                    $noCon("#success-alert").html("Item rejected successfully.");
                    $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    //window.location.href = "fms_Payment_Account_List.aspx";
                },
                failure: function (response) {
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
    function ShowOrderDtls(strid) {
        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        if (strid != "" && CorpId != "") {
            $.ajax({
                type: "POST",
                async: false,
                url: "fms_Payment_Account_List.aspx/ShowOrderDtls",
                data: '{strid:"' + strid + '",CorpId:"' + CorpId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    document.getElementById("pan_l").innerHTML = response.d;
                },
                failure: function (response) {
                }
            });
        }
        return false;
    }

</script>



    <script>

        //for search option
        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();
        function LoadEmployeeList(mode) {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var LedgerId = 0;
            var AccountId = 0;
            var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
            var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;
            var EnableReopen = document.getElementById("<%=HiddenProvisionSts.ClientID%>").value;
            var EnableConfirm = document.getElementById("<%=HiddenConfirmStatus.ClientID%>").value;
            var EnableAudit = document.getElementById("<%=HiddenAuditProvisionStatus.ClientID%>").value;
            var Costcenterval = document.getElementById("<%=ddlAccount.ClientID%>").value;
            var Ledgval = document.getElementById("<%=ddlLedger.ClientID%>").value;
            if (document.getElementById("<%=ddlAccount.ClientID%>").value != "--SELECT ACCOUNT--") {
                AccountId = document.getElementById("<%=ddlAccount.ClientID%>").value;
            }
            if (document.getElementById("<%=ddlLedger.ClientID%>").value != "--SELECT LEDGER--") {
                LedgerId = document.getElementById("<%=ddlLedger.ClientID%>").value;
            }
            var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;
            var CnclSts = 0;
            var reopenSts = document.getElementById("<%=HiddenReopenSts.ClientID%>").value;
            var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
            var PurchaseStatus = document.getElementById("cphMain_ddlPurchaseStatus").value;
            var StartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
            var EndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
            var AccountClsDate = document.getElementById("<%=HiddenAccountClsDate.ClientID%>").value;
            var ReccuRole = document.getElementById("<%=HiddenFieldRecurrRole.ClientID%>").value;
            var responsiveHelper_datatable_fixed_column = undefined;
            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };
            /* COLUMN FILTER  */
            if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                CnclSts = 1;

                var otable = $NoConfi3('#datatable_fixed_column').DataTable({
                    'bProcessing': true,
                    'bServerSide': true,
                    'sAjaxSource': 'data.ashx',
                    "order": [[0, 'desc']],
                    "bDestroy": true,
                    "autoWidth": true,
                    //"sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>>r>" +
                    //        "t" +
                    //        "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
                    //"autoWidth": true,
                    //"oLanguage": {
                    //    "sSearch": ' <span  class="input-group-addon"><i  class="glyphicon glyphicon-search"></i></span>'

                    //},
                    "preDrawCallback": function () {
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
                    "fnServerParams": function (aoData) {
                        aoData.push({ "name": "ORG_ID", "value": orgID });
                        aoData.push({ "name": "CORPT_ID", "value": corptID });
                        aoData.push({ "name": "CNCL_STS", "value": CnclSts });
                        aoData.push({ "name": "ACCOUNTID", "value": AccountId });
                        aoData.push({ "name": "LEDGERID", "value": LedgerId });
                        aoData.push({ "name": "FROMDT", "value": from });
                        aoData.push({ "name": "TODAT", "value": toDt });
                        aoData.push({ "name": "ENABLEDIT", "value": EnableEdit });
                        aoData.push({ "name": "ENABLEDELETE", "value": EnableDelete });
                        aoData.push({ "name": "ENABLEREOPEN", "value": EnableReopen });
                        aoData.push({ "name": "STARTDATE", "value": StartDate });
                        aoData.push({ "name": "ENDDATE", "value": EndDate });
                        aoData.push({ "name": "ACNTCLSDATE", "value": AccountClsDate });
                        aoData.push({ "name": "ENABLEAUDIT", "value": EnableAudit });
                        aoData.push({ "name": "CONFIRM", "value": EnableConfirm });
                        aoData.push({ "name": "PURCAHSESTATUS", "value": PurchaseStatus });
                        aoData.push({ "name": "CURRENCY", "value": CurrencyId });
                        aoData.push({ "name": "MODE", "value": mode });
                        aoData.push({ "name": "RECCU", "value": ReccuRole });
                        
                    },
                    "columnDefs": [
                          {
                              "targets": [0],
                              "className": "tr_l",
                              "visible": true
                          },
                          {
                              "targets": [1],
                              "className": "tr_l",
                              "visible": true
                          },
                          {
                              "targets": [2],
                              "className": "tr_l",
                              "visible": true
                          },
                          {
                              "targets": [4],
                              "className": "tr_l",
                              "visible": true
                         },
                          {
                               "targets": 0,
                               "orderData": 6,
                          },
                          {
                                "targets": 6,
                                "visible": false
                          },
                          {
                              "targets": [5],
                              "className": "tr_r",
                              "visible": true
                          },
                    ],
                });
                $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                    otable
                        .column($NoConfi(this).parent().index() + ':visible')
                        .search(this.value)
                        .draw();

                });
            }
            else {
                var otable = $NoConfi3('#datatable_fixed_column').DataTable({
                    'bProcessing': true,
                    'bServerSide': true,
                    'sAjaxSource': 'data.ashx',
                    "order": [[0, 'desc']],
                    "bDestroy": true,
                    "autoWidth": true,
                    //"sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>>r>" +
                    //        "t" +
                    //        "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
                    //"autoWidth": true,
                    //"oLanguage": {
                    //    "sSearch": ' <span  class="input-group-addon"><i  class="glyphicon glyphicon-search"></i></span>'

                    //},
                    "preDrawCallback": function () {
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
                    "fnServerParams": function (aoData) {
                        aoData.push({ "name": "ORG_ID", "value": orgID });
                        aoData.push({ "name": "CORPT_ID", "value": corptID });
                        aoData.push({ "name": "CNCL_STS", "value": CnclSts });
                        aoData.push({ "name": "ACCOUNTID", "value": AccountId });
                        aoData.push({ "name": "LEDGERID", "value": LedgerId });
                        aoData.push({ "name": "FROMDT", "value": from });
                        aoData.push({ "name": "TODAT", "value": toDt });
                        aoData.push({ "name": "ENABLEDIT", "value": EnableEdit });
                        aoData.push({ "name": "ENABLEDELETE", "value": EnableDelete });
                        aoData.push({ "name": "ENABLEREOPEN", "value": EnableReopen });
                        aoData.push({ "name": "STARTDATE", "value": StartDate });
                        aoData.push({ "name": "ENDDATE", "value": EndDate });
                        aoData.push({ "name": "ACNTCLSDATE", "value": AccountClsDate });
                        aoData.push({ "name": "ENABLEAUDIT", "value": EnableAudit });
                        aoData.push({ "name": "CONFIRM", "value": EnableConfirm });
                        aoData.push({ "name": "PURCAHSESTATUS", "value": PurchaseStatus });
                        aoData.push({ "name": "CURRENCY", "value": CurrencyId });
                        aoData.push({ "name": "MODE", "value": mode });
                        aoData.push({ "name": "RECCU", "value": ReccuRole });
                    },
                    "columnDefs": [
          {
              "targets": 0,
              "orderData": 7,
          },
            {
                "targets": [0],
                "className": "tr_l",
                "visible": true
            },
           {
               "targets": [1],
               "className": "tr_l",
               "visible": true
           },
           {
               "targets": [2],
               "className": "tr_l",
               "visible": true
           },
           {
               "targets": [4],
               "className": "tr_l",
               "visible": true
           },
           {
               "targets": [5],
               "className": "tr_r",
               "visible": true
           },

                    ],
                });
                $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                    otable
                        .column($NoConfi(this).parent().index() + ':visible')
                        .search(this.value)
                        .draw();

                });
            }


            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var LedgerId = 0;
            var AccountId = 0;
            if (document.getElementById("<%=ddlAccount.ClientID%>").value != "--SELECT ACCOUNT--") {
                  AccountId = document.getElementById("<%=ddlAccount.ClientID%>").value;
              }
              if (document.getElementById("<%=ddlLedger.ClientID%>").value != "--SELECT LEDGER--") {
                LedgerId = document.getElementById("<%=ddlLedger.ClientID%>").value;
              }
              var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;
            var CnclSts = 0;
            var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
            var Currency = document.getElementById("<%=HiddenCurrrencyAbrvtn.ClientID%>").value;
              var PurchaseStatus = document.getElementById("cphMain_ddlPurchaseStatus").value;
              var StartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
              var EndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
            if (document.getElementById("cphMain_cbxCnclStatus").checked == true)
                CnclSts = 1;
            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Payment_Account_List.aspx/PaymentAmountSum",
                    data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",PurchaseStatus: "' + PurchaseStatus + '",AccountId: "' + AccountId + '",from: "' + from + '",toDt: "' + toDt + '",CnclSts: "' + CnclSts + '",CurrencyId: "' + CurrencyId + '",StartDate: "' + StartDate + '",EndDate: "' + EndDate + '",LedgerId: "' + LedgerId + '",Currency: "' + Currency + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            document.getElementById("cphMain_trTotal").innerHTML = data.d;
                            return false;
                        }
                        else {
                            document.getElementById("cphMain_trTotal").innerHTML = "";
                        }
                    }
                });
                }
                else {
                    window.location = '/Security/Login.aspx';
                }
        }

    </script>

    <script>



        function ReOpenByID(strId) {

            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            var AcntClsPrvsn = document.getElementById("<%=HiddenProvisionSts.ClientID%>").value;
            var AuditClsPrvsn = document.getElementById("<%=HiddenAuditProvisionStatus.ClientID%>").value;
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to reopen this payment?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    if (strId != "" && strUserID != '') {
                        var Details = PageMethods.ReopenReceiptDetails(strUserID, strId, strOrgIdID, strCorpID, AcntClsPrvsn, AuditClsPrvsn, function (response) {

                            var SucessDetails = response[0];
                            $(window).scrollTop(0);

                            var ReopenSts = SucessDetails;
                            if (ReopenSts != '') {
                                LoadEmployeeList(0);
                                if (ReopenSts == 'successReopen') {
                                    SuccessReoen();
                                }
                                else if (ReopenSts == 'failed') {
                                    SuccessErrorReoen();
                                }
                                else if (ReopenSts == 'alrdydeleted') {
                                    SuccessDeletedList();
                                }
                                else if (ReopenSts == 'auditclosed') {
                                    AuditClosedList();
                                }

                                else if (ReopenSts == 'acntclosed') {
                                    AcntClosedList();
                                }
                                else if (ReopenSts == 'successConfirm') {
                                    SuccessConfirm();
                                }
                                else if (ReopenSts == 'alrdyConfirmed') {
                                    SuccessConfirmed();
                                }
                                if (ReopenSts != 'failed') {

                                    if (document.getElementById("<%=HiddenFieldRecurrRole.ClientID%>").value == "1") {
                                        if (response[3] != "" && response[3] != null) {
                                            document.getElementById("cphMain_sPendOrdNum").innerText = response[3];
                                            document.getElementById("cphMain_menu1").style.display = "block";
                                        }
                                        else {
                                            document.getElementById("cphMain_menu1").style.display = "none";
                                        }
                                        document.getElementById("cphMain_myTable").innerHTML = response[4];
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
        function CheckIssue(strId) {
            document.getElementById("<%=HiddenPayemntID.ClientID%>").value = strId;
            document.getElementById("BtnPopup").click();
            document.getElementById("divErrMsgCnclRsnCheque").style.display = "none";

            var corpid = '<%= Session["CORPOFFICEID"] %>';
            var orgid = '<%= Session["ORGID"] %>';
            var userid = '<%= Session["USERID"] %>';
            var Details = PageMethods.ReadCheckDate(strId, corpid, orgid, userid, function (response) {
                var SucessDetails = response;
                if (SucessDetails[0] != "") {
                    var from = SucessDetails[0].split("-")
                    var f = new Date(from[2], from[1] - 1, from[0])
                    f.setMonth(f.getMonth() + 3);
                    $noCon('#cphMain_txtdate').datepicker({
                        autoclose: true,
                        format: 'dd-mm-yyyy',
                        endDate: f,
                        timepicker: false
                    });
                }
            });
        }
        function ButtnCheckIssueDate() {
            var ret = true;
            document.getElementById("divErrMsgCnclRsnCheque").style.display = "none";
            document.getElementById("lblErrMsgCancelReasonCheque").innerHTML = "";
            document.getElementById("<%=txtdate.ClientID%>").style.borderColor = "";

            if (document.getElementById("<%=txtdate.ClientID%>").value == "") {
                document.getElementById("lblErrMsgCancelReasonCheque").style.display = "block";
                document.getElementById("lblErrMsgCancelReasonCheque").innerHTML = "Please fill cheque issue date.";
                document.getElementById("divErrMsgCnclRsnCheque").style.display = "";
                document.getElementById("<%=txtdate.ClientID%>").style.borderColor = "red";
                ret = false;
            }
            if (ret == true) {
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';

                if (document.getElementById("<%=HiddenPayemntID.ClientID%>").value != "") {
                    var strdate = "";
                    var strId = document.getElementById("<%=HiddenPayemntID.ClientID%>").value;
                    if (document.getElementById("<%=txtdate.ClientID%>").value != "") {
                        strdate = document.getElementById("<%=txtdate.ClientID%>").value;
                    }
                    var Details = PageMethods.CheckIssuedSuccess(strId, strdate, corpid, orgid, userid, function (response) {

                        var SucessDetails = response;
                        //if (SucessDetails[0] == "successIssue") {
                        //    //window.location = 'fms_Payment_Account_List.aspx';
                        //    if (SucessDetails[1] != "") {
                        //        var find2 = '\\"\\[';
                        //        var re2 = new RegExp(find2, 'g');
                        //        var res2 = SucessDetails[1].replace(re2, '\[');

                        //        var find3 = '\\]\\"';
                        //        var re3 = new RegExp(find3, 'g');
                        //        var res3 = res2.replace(re3, '\]');
                        //        var json = $noCon.parseJSON(res3);
                        //        for (var key in json) {
                        //            if (json.hasOwnProperty(key)) {
                        //                if (json[key].LDGR_ID != "") {
                        //                    EditListRows(json[key].CHKTEMPLT_WIDTH, json[key].CHKTEMPLT_HEIGHT, json[key].CHKTEMPLT_TOPS, json[key].CHKTEMPLT_TOPS_F, json[key].CHKTEMPLT_PAYEE_LEFT, json[key].CHKTEMPLT_DATE_LEFT, json[key].CHKTEMPLT_AMNTWORD1_LEFT, json[key].CHKTEMPLT_AMNTWORD2_LEFT, json[key].CHKTEMPLT_AMNTNUM_LEFT, json[key].CHKTEMPLT_PAYEE_TOP, json[key].CHKTEMPLT_DATE_TOP, json[key].CHKTEMPLT_AMNTWORD1_TOP, json[key].CHKTEMPLT_AMNTWORD2_TOP, json[key].CHKTEMPLT_AMNTNUM_TOP, json[key].CHKTEMPLT_PAYEE_NAME, json[key].CHKTEMPLT_DATE, json[key].CHKTEMPLT_AMT_WORD_ONE, json[key].CHKTEMPLT_AMT_WORD_TWO, json[key].CHKTEMPLT_AMT_NUM);
                        //                }
                        //            }
                        //        }
                        //        document.getElementById("print_cap").click();
                        //        return false;
                        //        //  document.getElementById("ButtonPrint").click();
                        //        //window.location = '/FMS/FMS_Master/fms_Payment_Account/cheque_Print.htm';
                        //    }
                        //}
                        $(window).scrollTop(0);

                        var CheckSts = SucessDetails[0];
                        if (CheckSts != '') {
                            if (CheckSts == 'successIssue') {
                                LoadEmployeeList(0);
                                SuccessCheckIssue();
                                document.getElementById("BttnTemp").click();
                            }
                            else if (CheckSts == 'failed') {
                                SuccessErrorReoenCheck();
                            }
                        }
                    });
                }
            }
        }

        function EditListRows(CHKTEMPLT_WIDTH, CHKTEMPLT_HEIGHT, CHKTEMPLT_TOPS, CHKTEMPLT_TOPS_F, CHKTEMPLT_PAYEE_LEFT, CHKTEMPLT_DATE_LEFT, CHKTEMPLT_AMNTWORD1_LEFT, CHKTEMPLT_AMNTWORD2_LEFT, CHKTEMPLT_AMNTNUM_LEFT, CHKTEMPLT_PAYEE_TOP, CHKTEMPLT_DATE_TOP, CHKTEMPLT_AMNTWORD1_TOP, CHKTEMPLT_AMNTWORD2_TOP, CHKTEMPLT_AMNTNUM_TOP, CHKTEMPLT_PAYEE_NAME, CHKTEMPLT_DATE, CHKTEMPLT_AMT_WORD_ONE, CHKTEMPLT_AMT_WORD_TWO, CHKTEMPLT_AMT_NUM) {


            document.getElementById("cphMain_lblHeight").value = CHKTEMPLT_HEIGHT;
            document.getElementById("cphMain_lblWidth").value = CHKTEMPLT_WIDTH;
            document.getElementById("cphMain_lblPayeeLeft").value = CHKTEMPLT_PAYEE_LEFT;
            document.getElementById("cphMain_lblPayeeTop").value = CHKTEMPLT_PAYEE_TOP;


            document.getElementById("cphMain_lblDateLeft").value = CHKTEMPLT_DATE_LEFT;
            document.getElementById("cphMain_lblDateTop").value = CHKTEMPLT_DATE_TOP;



            document.getElementById("cphMain_lblAmntWordLeft").value = CHKTEMPLT_AMNTWORD1_LEFT;
            document.getElementById("cphMain_lblAmntWordTop").value = CHKTEMPLT_AMNTWORD1_TOP;


            document.getElementById("cphMain_lblAmntNumLeft").value = CHKTEMPLT_AMNTWORD2_LEFT;
            document.getElementById("cphMain_lblAmntNumTop").value = CHKTEMPLT_AMNTWORD2_TOP;



            document.getElementById("cphMain_lblAmntWordLeft1").value = CHKTEMPLT_AMNTNUM_LEFT;
            document.getElementById("cphMain_lblAmntWordTop1").value = CHKTEMPLT_AMNTNUM_TOP;


            document.getElementById("cphMain_TextBox1").value = CHKTEMPLT_PAYEE_NAME;
            document.getElementById("cphMain_TextBox2").value = CHKTEMPLT_DATE;
            document.getElementById("cphMain_TextBox3").value = CHKTEMPLT_AMT_WORD_ONE;
            document.getElementById("cphMain_TextBox4").value = CHKTEMPLT_AMT_NUM;
            document.getElementById("cphMain_TextBox5").value = CHKTEMPLT_AMT_WORD_TWO;


        }

        function ChangeStatus(StrId, stsmode, cnclusrId) {
            if (cnclusrId == "") {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to change the status of this payment details?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var usrId = '<%= Session["USERID"] %>';

                        var Details = PageMethods.ChangePurchaseStatus(StrId, stsmode, usrId, function (response) {
                            var SucessDetails = response;
                            if (SucessDetails == "success") {
                                window.location = 'fms_Payment_Account_List.aspx?InsUpd=StsCh';
                            }
                            else {
                                window.location = 'fms_Payment_Account_List.aspx?InsUpd=Error';
                            }
                        });
                    }
                });
                return false;
            }
        }
        function OpenCancelView(StrId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to delete this payment?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        //cancl rsn must
                        document.getElementById("divErrMsgCnclRsn").style.display = "none";
                        document.getElementById('txtCancelReason').style.borderColor = "";
                        document.getElementById('txtCancelReason').value = "";
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

        function DeleteByID(strId, strCancelReason, strCancelMust) {
            var strUserID = '<%=Session["USERID"]%>';
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            if (strId != "" && strUserID != '') {
                // alert(strId); alert(strCancelReason); alert(strCancelMust); alert(strUserID);
                var Details = PageMethods.CancelPaymentAccount(strId, strCancelMust, strUserID, strCancelReason, orgID, corptID, function (response) {
                    var SucessDetails = response;
                    $(window).scrollTop(0);
                    LoadEmployeeList(0);
                    if (SucessDetails == "successcncl") {
                        SuccessCancelation();
                    }
                    else {
                        SuccessNotConfirmation();
                    }
                });
            }

            return false;
        }
        //validation when cancel process
        function ValidateCancelReason() {
            // replacing < and > tags

            var ret = true;
            document.getElementById("divErrMsgCnclRsn").style.display = "none";
            document.getElementById("txtCancelReason").style.borderColor = "";
            var strCancelReason = document.getElementById("txtCancelReason").value;
            if (strCancelReason == "") {
                document.getElementById("txtCancelReason").style.borderColor = "red";
                //document.getElementById("lblErrMsgCancelReason1").innerHTML = " Please fill this out";
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
                    document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                    document.getElementById("txtCancelReason").style.borderColor = "red";
                    document.getElementById("divErrMsgCnclRsn").style.display = "";
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

        function DisableEnterAndComma(evt) {
            DisableEnter(evt);
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 188) {
                return false;
            }
        }
        function SuccessConfirmation() {
            $noCon("#success-alert").html("Payment Confirmed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessUpdation() {
            $noCon("#success-alert").html("Payment updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessAlreadyCancel() {
            $noCon("#success-alert").html("Payment is already cancelled.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;

        }
        function SuccessCancelation() {
            $noCon("#success-alert").html("Payment details deleted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;

        }
        function SuccessNotConfirmation() {
            $noCon("#success-alert").html("Payment is already confirmed.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessStatusChange() {
            $noCon("#success-alert").html("Payment status changed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        function CancelNotPossible() {
            ezBSAlert({
                type: "alert",
                messageText: "Sorry, Cancellation Denied. This payment details is already confirmed!",
                alertType: "info"

            });
            return false;
        }

        function PrintPdf(id) {

        
            var UsrName = '<%= Session["USERFULLNAME"] %>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            var strId = id;
            var crncyAbrvt = document.getElementById("<%=HiddenCurrrencyAbrvtn.ClientID%>").value;
                    var crncyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

            if (strCorpID != "" && strCorpID != null && strOrgIdID != "" && strOrgIdID != null && UsrName != null && UsrName != "" && strId != "" && crncyAbrvt != "") {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Payment_Account_List.aspx/printReceiptDetails",
                    data: '{strId: "' + strId + '",UsrName: "' + UsrName + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",crncyAbrvt: "' + crncyAbrvt + '",crncyId: "' + crncyId + '"}',
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
        $au(function () {
            $au(".ddl").selectToAutocomplete1Letter();
        });
    </script>
    <div id="div1" class="table-responsive" runat="server" style="display: none;">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
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
        PAYMENT
    </div>
</asp:Content>

