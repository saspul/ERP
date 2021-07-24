<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzitFinance.master" AutoEventWireup="true" CodeFile="fms_Journal.aspx.cs" Inherits="FMS_FMS_Master_fms_Journal_fms_Journal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="/js/jQueryUI/jquery-ui.min.js"></script>
    <script src="/js/jQueryUI/jquery-ui.js"></script>
    <script src="/js/datepicker/bootstrap-datepicker.js"></script>
    <link href="/js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>
    <script src="/js/jquery.min.js"></script>

     
    <style>
        .list-group {
    margin-bottom: 0px;
    padding-left: 0;
}
        .auto1 {
    width: 92%;
    margin-left: 17px;
}
         input[type="radio"] {
            display: table-cell;
        }
         input[type="checkbox"] {
    margin: 0px 0 0;
    line-height: normal;
}
         .cont_rght {
    min-height: auto;
}
         .table {
    width: 100%;
    max-width: 100%;
    margin-bottom: 0px;
}
    </style>
    <script>
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            calcTotDebCreAmnt('Deb');
            calcTotDebCreAmnt('Cre');
            enableexchangeRate(0);
        });
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
        function SuccessCnfMsg() {

            $noCon("#success-alert").html("Journal details confirmed successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessReopMsg() {

            $noCon("#success-alert").html("Journal details reopened successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        
        function CanclUpdMsg() {
            $noCon("#divWarning").html("This action is  denied! This Journal is already canceled .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function CanclCnfMsg() {
            $noCon("#divWarning").html("This action is  denied! This Journal is already confirmed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
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
                        window.location.href = "fms_Journal_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
            }
            else {
                window.location.href = "fms_Journal_List.aspx";
            }
            return false;

        }

        function AmountChecking(textboxid) {

           // alert(textboxid);
            var txtPerVal = document.getElementById(textboxid).value;
            //  alert(txtPerVal);

            txtPerVal = txtPerVal.replace(/,/g, "");



            if (txtPerVal == "") {
                return false;
            }
            else {
                if (!isNaN(txtPerVal) == false) {
                    document.getElementById('' + textboxid + '').value = "";
                    return false;
                }
                else {
                    if (txtPerVal < 0) {
                        document.getElementById('' + textboxid + '').value = "";
                        return false;
                    }
                    var amt = parseFloat(txtPerVal);
                    var num = amt;
                    var n = 0;
                    // for floatting number adjustment from corp global
                    var FloatingValue = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);

                    }
                    document.getElementById('' + textboxid + '').value = n;

                }
            }

           // addCommas(textboxid);
        }

        function isDecimalNumber(evt, textboxid) {
            // alert(textboxid);
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            var txtPerVal = document.getElementById(textboxid).value;
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 38 || keyCodes == 40) {
                return false;

            }
            else if (keyCodes == 46) {
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


        function isNumberDec(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //at enter
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
            else if (keyCodes == 190 || keyCodes == 110) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;
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
    <asp:HiddenField ID="HiddenFieldJournalId" runat="server" />
    <asp:HiddenField ID="HiddenFieldDecimalCnt" runat="server" />
    <asp:HiddenField ID="HiddenFieldTableId" runat="server" />
    <asp:HiddenField ID="HiddenFieldJornlDataLedgr" runat="server" />
    <asp:HiddenField ID="HiddenFieldJornlDataCostCentr" runat="server" />
    <asp:HiddenField ID="HiddenFieldTotAmnt" runat="server" />

    <asp:HiddenField ID="HiddenFieldAcntCloseReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenExchngCurrency" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />

    <asp:HiddenField ID="HiddenFieldViewMode" runat="server" />
    <div class="cont_rght" style="width: 100%; margin-left: 2%;">
        <div style="height: 34px;">

            <div class="alert alert-danger" id="divWarning" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
            <div class="alert alert-success" id="success-alert" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="width: 100%; padding-left: 13px; padding-right: 0px;">
                        <div class="" id="wid-id-0">


                            <div id="divReportCaption" runat="server" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">

                                <asp:Label ID="lblEntry" runat="server"></asp:Label>
                            </div>

                            <div id="divList" class="list" runat="server" style="position: fixed; right: 1%; top: 42%; height: 26.5px; z-index: 90;" onclick="return ConfirmMessage();">
                            </div>

                            <br>

                            <div style="width: 100%; border: 1px solid #8e8f8e; padding: 0px; background-color: #f6f6f6; float: left">

                                <div class="auto1" style="width: 100%; margin-left: 0px;">
                                    <div class="cont_rght" style="width: 100%">
                                        <div class="sect250">
                                            <div class="row">
                                                <div class="container" style="padding-top: 18px; padding-bottom: 33px; padding-left: 0px; padding-right: 0px;">




                                                    <!-- Start:-New design -->




                                                    <div class="row">
                                                        <div class="form-group col-md-4" style="padding-left: 3px;">
                                                            <label for="txtRefNum" class="col-md-2 col-form-label">REF<span>*</span></label>
                                                            <div class="col-md-10">
                                                                <input disabled="disabled" class="form-control" value="" id="txtRefNum" type="text" runat="server" />

                                                            </div>
                                                        </div>
                                                        <div class="form-group col-md-4" style="padding-right: 0px;">
                                                            <label for="txtDateFrom" class="col-md-2 col-form-label">Date<span>*</span></label>
                                                            <div class="col-md-10">
                                                                <input id="txtDateFrom" runat="server" name="txtDateFrom" onkeypress="return isTag(event)" onkeydown="return isTag(event)" class="Tabletxt form-control datepicker" data-dateformat="dd-mm-yyyy" placeholder="dd-mm-yyyy" maxlength="10" onchange="showFromDate()" type="text" />
                                                                <script>
                                                                    var $noCon4 = jQuery.noConflict();
                                                                    var dateToday = new Date();
                                                                    $noCon4('#cphMain_txtDateFrom').datepicker({
                                                                        autoclose: true,
                                                                        format: 'dd-mm-yyyy',
                                                                        endDate: 'today',
                                                                    });

                                                                    function showFromDate() {
                                                                        document.getElementById("cphMain_txtDateFrom").style.borderColor = "";
                                                                        IncrmntConfrmCounter();
                                                                        var orgID = '<%= Session["ORGID"] %>';
                                              var corptID = '<%= Session["CORPOFFICEID"] %>';
                                              var jrnlDate = $('#cphMain_txtDateFrom').val().trim();
                                              if (jrnlDate != "" && document.getElementById("<%=HiddenFieldAcntCloseReopenSts.ClientID%>").value != "1") {
                                                  $.ajax({
                                                      type: "POST",
                                                      async: false,
                                                      contentType: "application/json; charset=utf-8",
                                                      url: "fms_Journal.aspx/CheckAcntCloseSts",
                                                      data: '{jrnlDate: "' + jrnlDate + '",orgID: "' + orgID + '",corptID: "' + corptID + '"}',
                                                      dataType: "json",
                                                      success: function (data) {
                                                          if (data.d == "1") {
                                                              document.getElementById("cphMain_txtDateFrom").style.borderColor = "Red";
                                                              document.getElementById("cphMain_txtDateFrom").focus();
                                                              document.getElementById("cphMain_txtDateFrom").value = "";
                                                              $noCon("#divWarning").html("This action is  denied! Account is already closed for the selected date.");
                                                              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                                              });
                                                          }
                                                      }
                                                  });
                                              }
                                          }


                                                                </script>
                                                            </div>
                                                        </div>
                                                        <div class="form-group col-md-4">
                                                            <label for="ddlCurrency" class="col-md-2 col-form-label">Currency<span>*</span></label>
                                                            <div class="col-md-10">
                                                                <div>
                                                                    <select class="form-control" onchange="enableexchangeRate(1);" id="ddlCurrency" runat="server" onkeypress="return isTag(event)" onkeydown="return isTag(event)">
                                                                    </select>
                                                                </div>
                                                                <div>
                                                                    <select class="form-control" id="ddlMainCostCenter" runat="server" onkeypress="return isTag(event)" onkeydown="return isTag(event)" style="display: none;">
                                                                    </select>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <script>
                                                            function enableexchangeRate(x) {
                                                                var CurrencyId = document.getElementById("<%=ddlCurrency.ClientID%>").value;
                                      if (CurrencyId == "307") {
                                          document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = "INR";
                                          document.getElementById("CurrencyAbrv").innerHTML = "INR";
                                      }
                                      else if (CurrencyId == "308") {
                                          document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = "OMR";
                                               document.getElementById("CurrencyAbrv").innerHTML = "OMR";

                                           }
                                           else if (CurrencyId == "309") {
                                               document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = "USD";
                                                   document.getElementById("CurrencyAbrv").innerHTML = "USD";

                                               }

                                       var DftCurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
                                      if (CurrencyId == DftCurrencyId) {
                                          document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                                          document.getElementById("CurrencyAbrv").style.display = "none";

                                      }
                                      else if (CurrencyId == "--SELECT CURRENCY--") {
                                          document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                                               document.getElementById("CurrencyAbrv").style.display = "none";

                                           }
                                           else {
                                               document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "";
                                               document.getElementById("CurrencyAbrv").style.display = "";
                                           }
                                       if (x == 1)
                                           document.getElementById("<%=txtExchangeRate.ClientID%>").value = "";
                                  }
                                                        </script>
                                                    </div>
                                                    <div class="row">

                                                        <div id="divExchangeRate" runat="server" class="col-md-4" style="display: none;">

                                                            <label for="example-text-input" class="col-md-5 col-form-label" style="padding: 0%; width: 33%;">Exchange Currency</label>
                                                            <div class="col-md-7">
                                                                <input id="txtExchangeRate" style="width: 101%;" runat="server" type="text" onkeydown="return isNumberDec(event);" onkeypress="return isNumberDec(event);" class="form-control" maxlength="12" />
                                                            </div>
                                                            <label id="CurrencyAbrv" for="example-text-input" class="col-md-5 col-form-label" style="width: 18%; margin-top: 2%; margin-right: -11%;"></label>

                                                        </div>


                                                    </div>
                                                    <div class="container" style="margin-top: 1.5%; width: 100%; padding-left: 0px; padding-right: 0px;">
                                                        <div class="row">
                                                            <div class="col-md-6" style="padding-right: 0px;">
                                                                <table class="table table-bordered table-responsive" id="tabMainDeb" style="margin-bottom: 0px; border-top: 1px solid #bcb5b5; border-right: 1px solid #bcb5b5; border-left: 1px solid #bcb5b5;">
                                                                    <thead>
                                                                        <tr>
                                                                            <th colspan="5">Debit</th>
                                                                        </tr>
                                                                        <tr>
                                                                            <th style="width: 32%;">Particular*</th>
                                                                            <th style="width: 30%; text-align: right;">Amount*</th>
                                                                            <th style="width: 28%; text-align: center;">Sales/Cost Center</th>
                                                                            <th style="width: 10%;"></th>
                                                                        </tr>
                                                                    </thead>


                                                                    <tbody id="tabMainDebBody" runat="server">
                                                                    </tbody>

                                                                </table>

                                                            </div>

                                                            <div class="col-md-6" style="padding-left: 0px;">
                                                                <table class="table table-bordered table-responsive" id="tabMainCre" style="margin-bottom: 0px; border-top: 1px solid #bcb5b5; border-right: 1px solid #bcb5b5;">
                                                                    <thead>
                                                                        <tr>
                                                                            <th colspan="5">Credit</th>
                                                                        </tr>
                                                                        <tr>
                                                                            <th style="width: 32%;">Particular*</th>
                                                                            <th style="width: 30%; text-align: right;">Amount*</th>
                                                                            <th style="width: 28%; text-align: center;">Purchase/Cost Center</th>
                                                                            <th style="width: 10%;"></th>
                                                                        </tr>
                                                                    </thead>


                                                                    <tbody id="tabMainCreBody" runat="server">
                                                                    </tbody>

                                                                </table>

                                                            </div>
                                                        </div>


                                                        <div class="row">
                                                            <div class="col-md-6" style="padding-right: 0px;">
                                                                <table class="table table-bordered table-responsive" id="Table1" style="border: 1px solid #bcb5b5;">
                                                                    <thead>
                                                                        <tr>
                                                                            <th style="width: 31.8%;">Total Amount</th>
                                                                            <th id="lblTotDeb" style="width: 30%; text-align: right; padding-right: 14px;" runat="server"></th>
                                                                            <th colspan="2" style="width: 38.2%; text-align: right;"></th>
                                                                        </tr>
                                                                    </thead>
                                                                </table>
                                                            </div>
                                                            <div class="col-md-6" style="padding-right: 0px; padding-left: 0px; width: 49%;">
                                                                <table class="table table-bordered table-responsive" id="Table2" style="border: 1px solid #bcb5b5;">
                                                                    <thead>
                                                                        <tr>
                                                                            <th style="width: 31.8%;">Total Amount</th>
                                                                            <th id="lblTotCre" style="width: 30%; text-align: right; padding-right: 14px;" runat="server"></th>
                                                                            <th colspan="2" style="width: 38.2%; text-align: right;"></th>
                                                                        </tr>
                                                                    </thead>
                                                                </table>
                                                            </div>
                                                        </div>



                                                        <div class="row" style="margin-top:3%;">
                          <div class="col-md-6">
                           <label for="example-text-input" class="col-md-2 col-form-label">Narration*<span></span></label>
                                 <div class="col-md-10">
                                       <textarea rows="4" cols="50" class="form-control"  onchange="changeNarr();" runat="server" style="resize: none;" id="txtDesc" onkeydown="textCounter(cphMain_txtDesc,500)" onkeyup="textCounter(cphMain_txtDesc,500)"></textarea>
                                      
                                      </div>
                          </div>
                                            </div>



                                                       

                                                    </div>
                                                    <button id="BtnPopupCstCntr" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModalCstCntr">Open Modal</button>
                                                    <div id="CostCenterModal"></div>

                                                    <!-- Modal -->
                                                    <div class="modal fade" id="myModal" role="dialog" style="margin-top: 4%;">
                                                        <div class="modal-dialog">

                                                            <!-- Modal content-->
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                    <h4 class="modal-title" id="popTitle">Purchase</h4>
                                                                </div>
                                                                <div class="alert alert-danger fade in" id="divErrMsgCnclRsn" style="display: none; margin-top: 1%">

                                                                    <i class="fa-fw fa fa-times"></i>
                                                                    <strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReason"> Please fill this out</label>
                                                                </div>
                                                                <div class="modal-body">

                                                                    <div class="col-md-12" style="padding-bottom: 15px;">



                                                                        <div class="col-md-12 res_table_box">
                                                                            <div class="tab-content" id="myTabContent" style="max-height: 300px; overflow: auto;">
                                                                                <div class="tab-pane fade active in" id="home" role="tabpanel" aria-labelledby="home-tab" style="border: 1px solid #dddddd; padding: 3px;">
                                                                                    <ul class="list-group bg-grey" style="font-size: 15px;" id="divSelectList">
                                                                                    </ul>
                                                                                </div>


                                                                            </div>
                                                                        </div>
                                                                    </div>


                                                                </div>
                                                                <div class="clearfix"></div>
                                                                <div class="modal-footer">
                                                                    <label id="Label1PurSale" for="example-text-input" class="col-md-1 col-form-label" style="margin-left: 39%; width: 21%;">Ledger Amount<span></span></label>
                                                                    <label id="LedgerAmtInModalPurSale" for="example-text-input" class="col-md-1 col-form-label" style="width: 18%;"></label>
                                                                    <button type="button" class="btn btn-primary" onclick="return CloseSelectList();">Import</button>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>




                                                <div style="clear: both"></div>
                                                <div class="form-row form-inline">
                                                    <div class="col-sm-4 col-md-4 padding-10" style="margin-top: 3px; padding: 0; width: 100%; float: right; margin-right: 1%;">
                                                    </div>
                                                </div>
                                                <div style="clear: both"></div>




                                                <!-- End:-New design -->

                                                <div>
                                                    <div class="col-md-12" style="padding: 9px;">
                                                        <div style="float: right; margin-right: 2%;">
                                                            <asp:Button ID="bttnsave" runat="server" OnClientClick="return ValidateJournl(this);" OnClick="bttnsave_Click" class="btn btn-primary btn-grey  btn-width" Text="Save" />
                                                            <asp:Button ID="btnUpdate" runat="server" OnClientClick="return ValidateJournl(this);" OnClick="btnUpdate_Click" class="btn btn-primary btn-grey  btn-width" Text="Update" />
                                                            <asp:Button ID="btnConfirm" runat="server" OnClientClick="return ValidateJournl(this);" OnClick="btnConfirm_Click" class="btn btn-primary btn-grey  btn-width" Text="Confirm" />
                                                            <asp:Button ID="btnReopen" runat="server" OnClientClick="return ValidateJournl(this);" OnClick="btnReopen_Click" class="btn btn-primary btn-grey  btn-width" Text="Reopen" />
                                                            <asp:Button ID="btnCancel" runat="server" OnClientClick="return ConfirmMessage();" class="btn btn-primary btn-grey  btn-width" Text="Cancel" />
                                                            <asp:Button ID="Button1" runat="server" OnClick="btnConfirm_Click" Style="display: none;" class="btn btn-primary btn-grey  btn-width" Text="Confirm" />
                                                            <asp:Button ID="Button2" runat="server" OnClick="btnReopen_Click" Style="display: none;" class="btn btn-primary btn-grey  btn-width" Text="Reopen" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>


                                </div>

                            </div>

                        </div>
                </div>
            </article> 
        </div>
        </section> 

    </div>
    </div>

     
    <script>

        function changeNarr() {
            IncrmntConfrmCounter();
            document.getElementById("cphMain_txtDesc").style.borderColor = "";
        }
        function ValidateJournl(ClickedBtn) {
          
            var ret = true;
            document.getElementById("<%=HiddenFieldJornlDataLedgr.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldJornlDataCostCentr.ClientID%>").value = "";
            var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
            if (ClickedBtn.id != "cphMain_btnReopen") {
                var NullVal = false;
                var tabMode = "Cre";
                var tableOtherItem = document.getElementById("tabMain" + tabMode);
                for (var i = tableOtherItem.rows.length - 1; i > 1; i--) {
                    var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);                  
                    $("#divLed" + tabMode + validRowID + "> input").css("borderColor", "");
                    document.getElementById("txtTotAmnt" + tabMode + validRowID).style.borderColor = "";
                    var Ledgr = document.getElementById("ddlLed" + tabMode + validRowID).value;
                    var LedgrAmnt = document.getElementById("txtTotAmnt" + tabMode + validRowID).value.trim().replace(/,/g, "");
                    var DtlPurchase = document.getElementById("DtlPurchase" + tabMode + validRowID).innerHTML;
                    var DtlCostCenter = document.getElementById("DtlCostCenter" + tabMode + validRowID).innerHTML;
                    var CostCentrTotAmnt = 0;
                    var PurSaleTotAmnt = 0;
                    var f1 = 0;
                    var f2 = 0;
                    if (DtlPurchase != "") {
                        var splitrow = DtlPurchase.split("$");
                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var splitEach = splitrow[Cst].split("%");
                            if (splitEach[0] != "") {
                                f1 = 1;
                                var CostCentrAmnt = splitEach[1].trim().replace(/,/g, "");


                                var orgID = '<%= Session["ORGID"] %>';
                                var corptID = '<%= Session["CORPOFFICEID"] %>';
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    contentType: "application/json; charset=utf-8",
                                    url: "fms_Journal.aspx/LoadSelectListById",
                                    data: '{tabMode: "' + tabMode + '",CostCentrId: "' + splitEach[0] + '",orgID: "' + orgID + '",corptID: "' + corptID + '"}',
                                    dataType: "json",
                                    success: function (data) {
                                        var SalePurAmnt = data.d.replace(/,/g, "");
                                        SalePurAmnt = parseFloat(SalePurAmnt);
                                        if (SalePurAmnt < parseFloat(CostCentrAmnt)) {
                                            ret = false;
                                            $('html,body').scrollTop(0);
                                            $noCon("#divWarning").html("Cost center amount cant be greater than remaing balance " + SalePurAmnt);
                                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                                document.getElementById("txtTotAmnt" + tabMode + validRowID ).style.borderColor = "red";
                                                document.getElementById("txtTotAmnt" + tabMode + validRowID ).focus();
                                            });
                                        }
                                    }
                                });
                                PurSaleTotAmnt = parseFloat(PurSaleTotAmnt) + parseFloat(CostCentrAmnt);
                            }
                        }
                    }
                    if (DtlCostCenter != "") {
                        var splitrow = DtlCostCenter.split("$");
                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var splitEach = splitrow[Cst].split("%");
                            if (splitEach[0] != "") {
                                f2 = 1;
                                var CostCentrAmnt = splitEach[1].trim().replace(/,/g, "");
                                CostCentrTotAmnt = parseFloat(CostCentrTotAmnt) + parseFloat(CostCentrAmnt);
                            }
                        }
                    }                        
                    if (LedgrAmnt == "") {
                        NullVal = true;
                        document.getElementById("txtTotAmnt" + tabMode + validRowID).style.borderColor = "red";
                        document.getElementById("txtTotAmnt" + tabMode + validRowID).focus();
                        ret = false;
                    }
                    else if ((f2 != 0 && CostCentrTotAmnt != LedgrAmnt) || (f1 != 0 && PurSaleTotAmnt != LedgrAmnt)) {                     
                        document.getElementById("txtTotAmnt" + tabMode + validRowID).style.borderColor = "red";
                        document.getElementById("txtTotAmnt" + tabMode + validRowID).focus();
                       
                        $('html,body').scrollTop(0);
                        if (f2 != 0 && CostCentrTotAmnt != LedgrAmnt) {
                            $noCon("#divWarning").html("Ledger amount must be equal to sum of cost center amounts");
                        }
                        else {
                            $noCon("#divWarning").html("Ledger amount must be equal to sum of purchase amounts");
                        }
                        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {                          
                        });
                        ret = false;
                    }
                    if (Ledgr == "-Select Ledger-" || Ledgr == "") {
                        NullVal = true;
                        $("#divLed" + tabMode + validRowID + "> input").css("borderColor", "red");
                        $("#divLed" + tabMode + validRowID + "> input").focus();
                        $("#divLed" + tabMode + validRowID + "> input").select();
                        ret = false;
                    }
                }


                var tabMode = "Deb";
                var tableOtherItem = document.getElementById("tabMain" + tabMode);
                for (var i = tableOtherItem.rows.length - 1; i > 1; i--) {
                    var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);

                    $("#divLed" + tabMode + validRowID + "> input").css("borderColor", "");
                    document.getElementById("txtTotAmnt" + tabMode + validRowID).style.borderColor = "";

                    var Ledgr = document.getElementById("ddlLed" + tabMode + validRowID).value;
                    var LedgrAmnt = document.getElementById("txtTotAmnt" + tabMode + validRowID).value.trim().replace(/,/g, "");
                    var DtlPurchase = document.getElementById("DtlPurchase" + tabMode + validRowID).innerHTML;
                    var DtlCostCenter = document.getElementById("DtlCostCenter" + tabMode + validRowID).innerHTML;
                    var CostCentrTotAmnt = 0;
                    var PurSaleTotAmnt = 0;
                    var f1 = 0;
                    var f2 = 0;
                    if (DtlPurchase != "") {
                        var splitrow = DtlPurchase.split("$");
                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var splitEach = splitrow[Cst].split("%");
                            if (splitEach[0] != "") {
                                f1 = 1;
                                var CostCentrAmnt = splitEach[1].trim().replace(/,/g, "");

                                var orgID = '<%= Session["ORGID"] %>';
                                var corptID = '<%= Session["CORPOFFICEID"] %>';
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    contentType: "application/json; charset=utf-8",
                                    url: "fms_Journal.aspx/LoadSelectListById",
                                    data: '{tabMode: "' + tabMode + '",CostCentrId: "' + splitEach[0] + '",orgID: "' + orgID + '",corptID: "' + corptID + '",FloatingValueMoney: "' + FloatingValueMoney + '"}',
                                    dataType: "json",
                                    success: function (data) {
                                       
                                        var SalePurAmnt = data.d.replace(/,/g, "");
                                        SalePurAmnt = parseFloat(SalePurAmnt);
                                        if (SalePurAmnt < parseFloat(CostCentrAmnt)) {
                                            ret = false;
                                            $('html,body').scrollTop(0);
                                            $noCon("#divWarning").html("Cost center amount cant be greater than remaing balance " + SalePurAmnt);
                                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                                document.getElementById("txtTotAmnt" + tabMode + validRowID).style.borderColor = "red";
                                                document.getElementById("txtTotAmnt" + tabMode + validRowID).focus();
                                            });
                                        }

                                    }
                                });


                                PurSaleTotAmnt = parseFloat(PurSaleTotAmnt) + parseFloat(CostCentrAmnt);
                            }
                        }
                    }
                    if (DtlCostCenter != "") {
                        var splitrow = DtlCostCenter.split("$");
                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var splitEach = splitrow[Cst].split("%");
                            if (splitEach[0] != "") {
                                f2 = 1;
                                var CostCentrAmnt = splitEach[1].trim().replace(/,/g, "");
                                CostCentrTotAmnt = parseFloat(CostCentrTotAmnt) + parseFloat(CostCentrAmnt);
                            }
                        }
                    }                   
                    if (LedgrAmnt == "") {
                        NullVal = true;
                        document.getElementById("txtTotAmnt" + tabMode + validRowID).style.borderColor = "red";
                        document.getElementById("txtTotAmnt" + tabMode + validRowID).focus();
                        ret = false;
                    }
                    else if ((f2 != 0 && CostCentrTotAmnt != LedgrAmnt) || (f1 != 0 && PurSaleTotAmnt != LedgrAmnt)) {
                        document.getElementById("txtTotAmnt" + tabMode + validRowID).style.borderColor = "red";
                        document.getElementById("txtTotAmnt" + tabMode + validRowID).focus();
                        $('html,body').scrollTop(0);
                        if (f2 != 0 && CostCentrTotAmnt != LedgrAmnt) {
                            $noCon("#divWarning").html("Ledger amount must be equal to sum of cost center amounts");
                        }
                        else {
                            $noCon("#divWarning").html("Ledger amount must be equal to sum of sales amounts");
                        }
                        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {                          
                        });                       
                        ret = false;
                    }
                    if (Ledgr == "-Select Ledger-" || Ledgr == "") {
                        NullVal = true;
                        $("#divLed" + tabMode + validRowID + "> input").css("borderColor", "red");
                        $("#divLed" + tabMode + validRowID + "> input").focus();
                        $("#divLed" + tabMode + validRowID + "> input").select();
                        ret = false;
                    }
                }



                var DebitTot = document.getElementById("cphMain_lblTotDeb").innerHTML;
                var CreditTot = document.getElementById("cphMain_lblTotCre").innerHTML;
                document.getElementById("Table1").style.borderColor = "";
                document.getElementById("Table2").style.borderColor = "";
                if (DebitTot != CreditTot) {
                    $('html,body').scrollTop(0);
                    $noCon("#divWarning").html("Debit side total  must be equal to credit side total");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        document.getElementById("Table1").style.borderColor = "red";
                        document.getElementById("Table2").style.borderColor = "red";
                    });                   
                    ret = false;
                }
                var DateJrnl = document.getElementById("cphMain_txtDateFrom").value.trim();
                var Currency = document.getElementById("cphMain_ddlCurrency").value;
                var Narration = document.getElementById("cphMain_txtDesc").value.trim();

                document.getElementById("cphMain_ddlCurrency").style.borderColor = "";
                document.getElementById("cphMain_txtDateFrom").style.borderColor = "";
                document.getElementById("cphMain_txtDesc").style.borderColor = "";
                if (Narration == "") {
                    NullVal = true;
                    document.getElementById("cphMain_txtDesc").style.borderColor = "Red";
                    document.getElementById("cphMain_txtDesc").focus();
                    ret = false;
                }
                if (DateJrnl == "") {
                    NullVal = true;
                    document.getElementById("cphMain_txtDateFrom").style.borderColor = "Red";
                    document.getElementById("cphMain_txtDateFrom").focus();
                    ret = false;
                }
                if (Currency == "" || Currency == "--SELECT CURRENCY--") {
                    NullVal = true;
                    document.getElementById("cphMain_ddlCurrency").style.borderColor = "Red";
                    document.getElementById("cphMain_ddlCurrency").focus();
                    ret = false;
                }
                if (ret == false) {
                    if (NullVal == true) {
                        $('html,body').scrollTop(0);
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                    }
                    return false;
                }
            }



             var tbClientJobSheduling = '';
             tbClientJobSheduling = [];

             var tbClientJobShedulingCost = '';
             tbClientJobShedulingCost = [];

             var tabMode = "Cre";
             var tableOtherItem = document.getElementById("tabMain" + tabMode);
             for (var i = tableOtherItem.rows.length - 1; i > 1; i--) {
                 var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                 var LedgrTabId = (tableOtherItem.rows[i].cells[1].innerHTML);
                 var Ledgr = document.getElementById("ddlLed" + tabMode + validRowID).value;
                 var LedgrAmnt = document.getElementById("txtTotAmnt" + tabMode + validRowID).value.trim().replace(/,/g, "");

                 var $add = jQuery.noConflict();
                 var client = JSON.stringify({
                     TABMODE: "1",
                     MAINTABID: "" + validRowID + "",
                     LEDGRTABID: "" + LedgrTabId + "",
                     LEDGRID: "" + Ledgr + "",
                     LEDGRAMNT: "" + LedgrAmnt + ""
                 });
                 tbClientJobSheduling.push(client);


                 var DtlPurchase = document.getElementById("DtlPurchase" + tabMode + validRowID).innerHTML;
                 var DtlCostCenter = document.getElementById("DtlCostCenter" + tabMode + validRowID).innerHTML;
               
                 if (DtlPurchase != "") {
                     var splitrow = DtlPurchase.split("$");
                     for (var Cst = 0; Cst < splitrow.length; Cst++) {
                         var splitEach = splitrow[Cst].split("%");
                         if (splitEach[0] != "") {                            
                             var $add = jQuery.noConflict();
                             var client = JSON.stringify({
                                 TABMODE: "1",
                                 MAINTABID: "" + validRowID + "",
                                 SUBTABID: "",
                                 COSTCENTRTABID: "",
                                 COSTCENTRID: "" + splitEach[0] + "",
                                 COSTCENTRAMNT: "" + splitEach[1] + "",
                                 PURSALESTS: "Cre",
                             });
                             tbClientJobShedulingCost.push(client);
                         }
                     }
                 }
                 if (DtlCostCenter != "") {
                     var splitrow = DtlCostCenter.split("$");
                     for (var Cst = 0; Cst < splitrow.length; Cst++) {
                         var splitEach = splitrow[Cst].split("%");
                         if (splitEach[0] != "") {
                             var $add = jQuery.noConflict();
                             var client = JSON.stringify({
                                 TABMODE: "1",
                                 MAINTABID: "" + validRowID + "",
                                 SUBTABID: "",
                                 COSTCENTRTABID: "",
                                 COSTCENTRID: "" + splitEach[0] + "",
                                 COSTCENTRAMNT: "" + splitEach[1] + "",
                                 PURSALESTS: "",
                             });
                             tbClientJobShedulingCost.push(client);
                         }
                     }
                 }


             }
             var tabMode = "Deb";
             var tableOtherItem = document.getElementById("tabMain" + tabMode);
             for (var i = tableOtherItem.rows.length - 1; i > 1; i--) {
                 var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                 var LedgrTabId = (tableOtherItem.rows[i].cells[1].innerHTML);
                 var Ledgr = document.getElementById("ddlLed" + tabMode + validRowID).value;
                 var LedgrAmnt = document.getElementById("txtTotAmnt" + tabMode + validRowID).value.trim().replace(/,/g, "");

                 var $add = jQuery.noConflict();
                 var client = JSON.stringify({
                     TABMODE: "0",
                     MAINTABID: "" + validRowID + "",
                     LEDGRTABID: "" + LedgrTabId + "",
                     LEDGRID: "" + Ledgr + "",
                     LEDGRAMNT: "" + LedgrAmnt + ""
                 });
                 tbClientJobSheduling.push(client);

                 var DtlPurchase = document.getElementById("DtlPurchase" + tabMode + validRowID).innerHTML;
                 var DtlCostCenter = document.getElementById("DtlCostCenter" + tabMode + validRowID).innerHTML;

                 if (DtlPurchase != "") {
                     var splitrow = DtlPurchase.split("$");
                     for (var Cst = 0; Cst < splitrow.length; Cst++) {
                         var splitEach = splitrow[Cst].split("%");
                         if (splitEach[0] != "") {
                             var $add = jQuery.noConflict();
                             var client = JSON.stringify({
                                 TABMODE: "0",
                                 MAINTABID: "" + validRowID + "",
                                 SUBTABID: "",
                                 COSTCENTRTABID: "",
                                 COSTCENTRID: "" + splitEach[0] + "",
                                 COSTCENTRAMNT: "" + splitEach[1] + "",
                                 PURSALESTS: "Deb",
                             });
                             tbClientJobShedulingCost.push(client);
                         }
                     }
                 }
                 if (DtlCostCenter != "") {
                     var splitrow = DtlCostCenter.split("$");
                     for (var Cst = 0; Cst < splitrow.length; Cst++) {
                         var splitEach = splitrow[Cst].split("%");
                         if (splitEach[0] != "") {
                             var $add = jQuery.noConflict();
                             var client = JSON.stringify({
                                 TABMODE: "0",
                                 MAINTABID: "" + validRowID + "",
                                 SUBTABID: "",
                                 COSTCENTRTABID: "",
                                 COSTCENTRID: "" + splitEach[0] + "",
                                 COSTCENTRAMNT: "" + splitEach[1] + "",
                                 PURSALESTS: "",
                             });
                             tbClientJobShedulingCost.push(client);
                         }
                     }
                 }
             }


             document.getElementById("<%=HiddenFieldTotAmnt.ClientID%>").value = DebitTot;
             $add("#cphMain_HiddenFieldJornlDataLedgr").val(JSON.stringify(tbClientJobSheduling));
             $add("#cphMain_HiddenFieldJornlDataCostCentr").val(JSON.stringify(tbClientJobShedulingCost));

             if (ClickedBtn.id == "cphMain_btnConfirm") {
                 ezBSAlert({
                     type: "confirm",
                     messageText: "Are you sure you want to confirm?",
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         document.getElementById("cphMain_Button1").click();             
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else if (ClickedBtn.id == "cphMain_btnReopen") {

                 ezBSAlert({
                     type: "confirm",
                     messageText: "Are you sure you want to reopen?",
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         document.getElementById("cphMain_Button2").click();
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             
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
      
         function addMainTabRow(RowNum, tabMode) {

             var PartName = "Sales";
             if (tabMode == "Cre")
                 PartName = "Purchase";

             IncrmntConfrmCounter();
             var LedgerId = $("#ddlLed" + tabMode + RowNum).val();
             var LedgerAmnt = document.getElementById("txtTotAmnt" + tabMode + RowNum).value.trim();

             $("#divLed" + tabMode + RowNum + "> input").css("borderColor", "");
             document.getElementById("txtTotAmnt" + tabMode + RowNum).style.borderColor = "";

             if (LedgerId != "-Select Ledger-" && LedgerId != null && LedgerAmnt != "") {

                 var $options1 = $("#cphMain_ddlMainCostCenter > option").clone();


                 var $options = $("#ddlLed" + tabMode + RowNum + " > option").clone();
                 var x = RowNum + 1;

                 var recRow = '<tr id="MainRow' + tabMode + x + '">';
                 recRow += '<td style="display:none;">' + x + '</td>';
                 recRow += '<td style="display:none;"></td>';
                 recRow += '<td style="width:32%;">';
                 recRow += '<div id="divLed' + tabMode + x + '"><select onblur="IncrmntConfrmCounter();" class="form-control ddl" id="ddlLed' + tabMode + x + '"  onchange="return changeLedger(' + x + ',\'' + tabMode + '\');" onkeydown="return isTag(event);" onkeypress="return isTag(event);" >';
                 recRow += '</select></div>';
                 recRow += '<label id="lblBal' + tabMode + x + '" style="font-size: 11px;margin-top: 1%;"></label>';
                 recRow += '</td>';
               
                 recRow += '<td style="width:30%;">';
                 recRow += '<input type="text" class="form-control" style="padding: 6px;text-align: right;" id="txtTotAmnt' + tabMode + x + '" onchange="changeLedgrAmnt(' + x + ',\'' + tabMode + '\');"   maxlength=10 onkeypress=\"return isDecimalNumber(event,\'txtTotAmnt' + tabMode + '' + x + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtTotAmnt' + tabMode + '' + x + '\')\"  onblur=\"return AmountChecking(\'txtTotAmnt' + tabMode + '' + x + '\');\">';
                 recRow += '</td>';

                 recRow += '<td class="smart-form" style="width:28%;word-break: break-all; word-wrap:break-word;text-align: center;">';
                 recRow += '<button id="ChkPurchase' + tabMode + x + '" type="button" class="btn" onclick="return ddlLedOnchange(' + x + ',\'' + tabMode + '\');" style="padding: 6px 12px;padding: 6px 12px;width: 86%; margin-bottom: 2%; height: 32px;">' + PartName + '</button>';
                 recRow += '<button id="ChkCostCenter' + tabMode + x + '" type="button" class="btn" onclick="MyModalCostCenter(' + x + ',\'' + tabMode + '\');" style="padding: 6px 12px;width: 86%;height: 32px;">Cost Center</button>';
                 recRow += '</td>';

                 recRow += '<td style="width:10%;padding:10px">';
                 recRow += '<button class="btn btn-primary"  title="Add" id="btnAddMain' + tabMode + x + '" onclick="return addMainTabRow(' + x + ',\'' + tabMode + '\');">';
                 recRow += '<span class="fa fa-plus" id="Span7" style="display: block;">&nbsp;</span>';
                 recRow += '</button>';
                 recRow += '<button class="btn btn-primary" title="Delete" style="margin-top:2%;" id="btnDelMain' + tabMode + x + '" onclick="return delMainTabRow(' + x + ',\'' + tabMode + '\');">';
                 recRow += '<span class="fa fa-trash" id="Span6" style="display: block;">&nbsp;</span>';
                 recRow += '</button>';
                 recRow += '</td>';

                 recRow += '<td id="DtlPurchase' + tabMode + x + '" style="display:none;"></td>';
                 recRow += '<td id="DtlCostCenter' + tabMode + x + '" style="display:none;"></td>';

                 recRow += '</tr>';
                 jQuery('#tabMain' + tabMode).append(recRow);
                 $('#btnAddMain' + tabMode + RowNum).attr("disabled", "disabled");

                 $("#ddlLed" + tabMode + x).append($options);
                 document.getElementById("ddlLed" + tabMode + x).value = "-Select Ledger-";
                
                 $au("#ddlLed" + tabMode + x).selectToAutocomplete1Letter();

                 $("#divLed" + tabMode + x + "> input").focus();
                 $("#divLed" + tabMode + x + "> input").select();
             }
             else {
                 if (LedgerAmnt == "") {
                     document.getElementById("txtTotAmnt" + tabMode + RowNum).style.borderColor = "red";
                     document.getElementById("txtTotAmnt" + tabMode + RowNum).focus();
                 }
                 if (LedgerId == "-Select Ledger-" || LedgerId==null) {
                     $("#divLed" + tabMode + RowNum + "> input").css("borderColor", "red");
                     $("#divLed" + tabMode + RowNum + "> input").focus();
                     $("#divLed" + tabMode + RowNum + "> input").select();
                 }
             }
            return false;
        }        
         function delMainTabRow(RowNum, tabMode) {


             var PartName = "Sales";
             if (tabMode == "Cre")
                 PartName = "Purchase";

             IncrmntConfrmCounter();
                if (confirm("Are you sure you want to remove the details?")) {

                    var $options = $("#ddlLed" + tabMode + RowNum + " > option").clone();

                    var row = document.getElementById("MainRow" + tabMode + RowNum);
                    row.parentNode.removeChild(row);

                    var tableOtherItemSub = document.getElementById("tabMain" + tabMode);
                    if (tableOtherItemSub.rows.length == 2) {
                        var x = 0;
                        var recRow = '<tr id="MainRow' + tabMode + x + '">';
                        recRow += '<td style="display:none;">' + x + '</td>';
                        recRow += '<td style="display:none;"></td>';
                        recRow += '<td style="width:32%;">';
                        recRow += '<div id="divLed' + tabMode + x + '"><select onblur="IncrmntConfrmCounter();" class="form-control ddl" id="ddlLed' + tabMode + x + '" onchange="return changeLedger(' + x + ',\'' + tabMode + '\');" onkeydown="return isTag(event);" onkeypress="return isTag(event);" >';
                        recRow += '</select></div>';
                        recRow += '<label id="lblBal' + tabMode + x + '" style="font-size: 11px;margin-top: 1%;"></label>';
                        recRow += '</td>';
                       
                        recRow += '<td style="width:30%;">';
                        recRow += '<input type="text" class="form-control" style="padding: 6px;text-align: right;" id="txtTotAmnt' + tabMode + x + '" onchange="changeLedgrAmnt(' + x + ',\'' + tabMode + '\');" onkeydown="return isNumberDec(event);"  maxlength=10 onkeypress="return isNumberDec(event);">';
                        recRow += '</td>';


                        recRow += '<td class="smart-form" style="width:28%;word-break: break-all; word-wrap:break-word;text-align: center;">';
                        recRow += '<button id="ChkPurchase' + tabMode + x + '" type="button" class="btn" onclick="return ddlLedOnchange(' + x + ',\'' + tabMode + '\');" style="padding: 6px 12px;padding: 6px 12px;width: 86%; margin-bottom: 2%; height: 32px;">' + PartName + '</button>';
                        recRow += '<button id="ChkCostCenter' + tabMode + x + '" type="button" class="btn" onclick="MyModalCostCenter(' + x + ',\'' + tabMode + '\');" style="padding: 6px 12px;width: 86%;height: 32px;">Cost Center</button>';
                        recRow += '</td>';

                        recRow += '<td style="width:10%;padding:10px">';
                        recRow += '<button class="btn btn-primary"  title="Add" id="btnAddMain' + tabMode + x + '" onclick="return addMainTabRow(' + x + ',\'' + tabMode + '\');">';
                        recRow += '<span class="fa fa-plus" id="Span7" style="display: block;">&nbsp;</span>';
                        recRow += '</button>';
                        recRow += '<button class="btn btn-primary" title="Delete" style="margin-top:2%;" id="btnDelMain' + tabMode + x + '" onclick="return delMainTabRow(' + x + ',\'' + tabMode + '\');">';
                        recRow += '<span class="fa fa-trash" id="Span6" style="display: block;">&nbsp;</span>';
                        recRow += '</button>';
                        recRow += '</td>';
                        recRow += '<td id="DtlPurchase' + tabMode + x + '" style="display:none;"></td>';
                        recRow += '<td id="DtlCostCenter' + tabMode + x + '" style="display:none;"></td>';
                        recRow += '</tr>';
                        jQuery('#tabMain' + tabMode).append(recRow);
                       
                        $("#ddlLed" + tabMode + x).append($options);
                        document.getElementById("ddlLed" + tabMode + x).value = "-Select Ledger-";
                        $au("#ddlLed" + tabMode + x).selectToAutocomplete1Letter();
                    }
                    var tableOtherItem = document.getElementById("tabMain" + tabMode);
                    var validRowID = (tableOtherItem.rows[tableOtherItem.rows.length-1].cells[0].innerHTML);
                    $('#btnAddMain' + tabMode + validRowID).removeAttr("disabled");
                    calcTotDebCreAmnt(tabMode);
                }
            return false;
         }
         var comVar = 0;
         function changeLedger(RowNum, tabMode) {
             comVar = comVar + 1;
             document.getElementById("divErrMsgCnclRsn").style.display = "none";
             var NewLedgerId = document.getElementById("ddlLed" + tabMode + RowNum).value;
           
                 if (NewLedgerId == "") {
                     $("div#divLed" + tabMode + RowNum + " input.ui-autocomplete-input").val("-Select Ledger-");
                     $("#ddlLed" + tabMode + RowNum).val("-Select Ledger-");
                 }
                 //IncrmntConfrmCounter();                
                 var flag = true;
                 var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
                 var tableOtherItem = document.getElementById("tabMain" + tabMode);

                 for (var i = 2; i < tableOtherItem.rows.length; i++) {
                     var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                     var LedgerId = document.getElementById("ddlLed" + tabMode + validRowID).value;
                     if (NewLedgerId == LedgerId && RowNum != validRowID && NewLedgerId != "-Select Ledger-" && NewLedgerId != "") {
                         flag = false;
                     }
                 }
                 if (NewLedgerId == "-Select Ledger-" || NewLedgerId == "") {
                     document.getElementById("lblBal" + tabMode + RowNum).innerHTML = "";
                 }
                 if (flag == false) {

                     $("div#divLed" + tabMode + RowNum + " input.ui-autocomplete-input").val("-Select Ledger-");
                     $("#ddlLed" + tabMode + RowNum).val("-Select Ledger-");
                     document.getElementById("lblBal" + tabMode + RowNum).innerHTML = "";

                   
                     if (comVar == 1) {
                         $('html,body').scrollTop(0);
                         $noCon("#divWarning").html("Ledger cant be duplicated.");
                         $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                             $("#divLed" + tabMode + RowNum + "> input").blur();
                             $("#divLed" + tabMode + RowNum + "> input").focus();
                             $("#divLed" + tabMode + RowNum + "> input").select();
                         });
                     }
                    
                 }                
                 if (flag == true) {
                     document.getElementById("DtlPurchase" + tabMode + RowNum).innerHTML = "";
                     document.getElementById("DtlCostCenter" + tabMode + RowNum).innerHTML = "";
                 }
                 if (comVar == 2) {
                     comVar = 0;
                 }
             return false;
         }        
         function changeLedgrAmnt(RowNum, tabMode) {

           //  alert(document.getElementById("txtTotAmnt" + tabMode + RowNum).value.trim());

            // AmountChecking(textboxid)
             IncrmntConfrmCounter();

             var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
             var ObjVal = document.getElementById("txtTotAmnt" + tabMode + RowNum).value.trim().replace(/,/g, "");


             if (!isNaN(ObjVal) == false) {
                 document.getElementById("txtTotAmnt" + tabMode + RowNum).value = parseFloat(0).toFixed(FloatingValueMoney);
                 ObjVal = document.getElementById("txtTotAmnt" + tabMode + RowNum).value;
                // return false;
             }


             if (FloatingValueMoney != "" && ObjVal != "") {
                 ObjVal = parseFloat(ObjVal);
                 document.getElementById("txtTotAmnt" + tabMode + RowNum).value = ObjVal.toFixed(FloatingValueMoney);            
                 var LedgrAmnt = document.getElementById("txtTotAmnt" + tabMode + RowNum).value.trim().replace(/,/g, "");
                 document.getElementById("txtTotAmnt" + tabMode + RowNum).value = document.getElementById("txtTotAmnt" + tabMode + RowNum).value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
             }
             calcTotDebCreAmnt(tabMode);
             document.getElementById("txtTotAmnt" + tabMode + RowNum).focus();
         }

         function CloseSelectList() {
             var checkCount=0;
             var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
             $('#divSelectList :input').each(function () {
                 if ($(this).val() != "") {
                     checkCount = 1;
                 }
             });
             if (checkCount > 0) {
                 var id = document.getElementById("<%=HiddenFieldTableId.ClientID%>").value.split('-');
                 var tabMode = id[0];
                 var tabNum = id[1];
                 var totLedAmnt = 0;
                 document.getElementById("divErrMsgCnclRsn").style.display = "none";               
             }
             else {
                 var id = document.getElementById("<%=HiddenFieldTableId.ClientID%>").value.split('-');
                 var tabMode = id[0];
                 if (tabMode == "Deb") {
                     document.getElementById("lblErrMsgCancelReason").innerHTML = " Select at least one sale.";
                 }
                 else {
                     document.getElementById("lblErrMsgCancelReason").innerHTML = " Select at least one purchase.";
                 }
                 document.getElementById("divErrMsgCnclRsn").style.display = "";
                 return false;
             }
             var LedgrAmnt = document.getElementById("txtTotAmnt" + tabMode + tabNum).value.trim().replace(/,/g, "");
             document.getElementById("DtlPurchase" + tabMode + tabNum).innerHTML = "";
             var totSaleAmnt = 0;
             var ret = true;
             $('#divSelectList :input').each(function () {
                 if ($(this).val() != "") {
                     var isc = $(this).attr("id").split('e');
                     var selId = isc[1];
                     document.getElementById("txtTotAmntPurSale" + selId).style.borderColor = "";
                     var RefList = document.getElementById("refList" + selId).innerHTML;
                     var AmntList = document.getElementById("txtTotAmntPurSale" + selId).value.replace(/,/g, "");
                     var AmntListAct = document.getElementById("AmntList" + selId).innerHTML.replace(/,/g, "");
                     AmntListAct = parseFloat(AmntListAct);
                     if (AmntListAct < parseFloat(AmntList)) {
                         document.getElementById("txtTotAmntPurSale" + selId).style.borderColor = "red";
                         document.getElementById("txtTotAmntPurSale" + selId).focus();
                         ret = false;
                     }
                     totSaleAmnt = totSaleAmnt + parseFloat(AmntList);
                     if (document.getElementById("DtlPurchase" + tabMode + tabNum).innerHTML == "") {
                         document.getElementById("DtlPurchase" + tabMode + tabNum).innerHTML = selId + "%" + AmntList;
                     }
                     else {
                         document.getElementById("DtlPurchase" + tabMode + tabNum).innerHTML = document.getElementById("DtlPurchase" + tabMode + tabNum).innerHTML + "$" + selId + "%" + AmntList;
                     }
                 }
             });
             if (ret == false) {
                 document.getElementById("DtlPurchase" + tabMode + tabNum).innerHTML = "";               
                 document.getElementById("divErrMsgCnclRsn").style.display = "";
                 document.getElementById("lblErrMsgCancelReason").innerHTML = "Amount cannot be greater than balance amount.";
                 return false;
             }
             if (totSaleAmnt != LedgrAmnt) {
                 document.getElementById("DtlPurchase" + tabMode + tabNum).innerHTML = "";
                 document.getElementById("divErrMsgCnclRsn").style.display = "";
                 document.getElementById("lblErrMsgCancelReason").innerHTML = "Total amount must be equal to ledger amount.";
                 return false;
             }
             $noCon('#myModal').modal('hide');
         }
         function calcTotDebCreAmnt(tabMode) {
             var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
             var tableOtherItem = document.getElementById("tabMain" + tabMode);
             var totAmnt = 0;
             for (var i = 2; i < tableOtherItem.rows.length; i++) {
                 var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                 var ObjVal = document.getElementById("txtTotAmnt" + tabMode + validRowID).value.trim().replace(/,/g, "");
                 if (FloatingValueMoney != "" && ObjVal != "") {
                     ObjVal = parseFloat(ObjVal);
                     totAmnt = parseFloat(totAmnt) + parseFloat(ObjVal);
                 }
             }
             totAmnt = totAmnt.toFixed(FloatingValueMoney);
             document.getElementById("cphMain_lblTot" + tabMode).innerHTML= totAmnt.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
         }
         
         function ddlLedOnchange(RowNum, tabMode) {
             comVar = comVar + 1;

             var TxtCstctrAmount = document.getElementById("txtTotAmnt" + tabMode + RowNum).value.trim()
             document.getElementById("txtTotAmnt" + tabMode + RowNum).style.borderColor = "";
             $("#divLed" + tabMode + RowNum + "> input").css("borderColor", "");
             if ((document.getElementById("ddlLed" + tabMode + RowNum).value != "-Select Ledger-" && document.getElementById("ddlLed" + tabMode + RowNum).value != "") && TxtCstctrAmount != "") {

              
                 document.getElementById("LedgerAmtInModalPurSale").innerHTML = TxtCstctrAmount;

                 document.getElementById("divErrMsgCnclRsn").style.display = "none";
                 var NewLedgerId = document.getElementById("ddlLed" + tabMode + RowNum).value;

                 if (NewLedgerId == "") {
                     $("div#divLed" + tabMode + RowNum + " input.ui-autocomplete-input").val("-Select Ledger-");
                     $("#ddlLed" + tabMode + RowNum).val("-Select Ledger-");
                 }
                 IncrmntConfrmCounter();
                 document.getElementById("<%=HiddenFieldTableId.ClientID%>").value = tabMode + "-" + RowNum;
                 var flag = true;
                 var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
                 var tableOtherItem = document.getElementById("tabMain" + tabMode);

                 for (var i = 2; i < tableOtherItem.rows.length; i++) {
                     var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                     var LedgerId = document.getElementById("ddlLed" + tabMode + validRowID).value;
                     if (NewLedgerId == LedgerId && RowNum != validRowID && NewLedgerId != "-Select Ledger-" && NewLedgerId != "") {
                         flag = false;
                     }
                 }
                 if (NewLedgerId == "-Select Ledger-" || NewLedgerId == "") {
                     document.getElementById("lblBal" + tabMode + RowNum).innerHTML = "";
                 }
                 if (flag == false) {

                     $("div#divLed" + tabMode + RowNum + " input.ui-autocomplete-input").val("-Select Ledger-");
                     $("#ddlLed" + tabMode + RowNum).val("-Select Ledger-");
                     document.getElementById("lblBal" + tabMode + RowNum).innerHTML = "";


                     if (comVar == 1) {
                         $('html,body').scrollTop(0);
                         $noCon("#divWarning").html("Ledger cant be duplicated.");
                         $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                             $("#divLed" + tabMode + RowNum + "> input").blur();
                             $("#divLed" + tabMode + RowNum + "> input").focus();
                             $("#divLed" + tabMode + RowNum + "> input").select();
                         });
                     }

                 }
                 else if (NewLedgerId != "-Select Ledger-" && NewLedgerId != "") {
                     var orgID = '<%= Session["ORGID"] %>';
                     var corptID = '<%= Session["CORPOFFICEID"] %>';
                     $.ajax({
                         type: "POST",
                         async: false,
                         contentType: "application/json; charset=utf-8",
                         url: "fms_Journal.aspx/LoadSelectList",
                         data: '{tabMode: "' + tabMode + '",NewLedgerId: "' + NewLedgerId + '",orgID: "' + orgID + '",corptID: "' + corptID + '",FloatingValueMoney: "' + FloatingValueMoney + '"}',
                         dataType: "json",
                         success: function (data) {
                             document.getElementById("divSelectList").innerHTML = data.d[0];
                             document.getElementById("lblBal" + tabMode + RowNum).innerHTML = data.d[1];
                             if (data.d[0] != "") {

                                 if (tabMode == "Cre") {
                                     document.getElementById("popTitle").innerHTML = "Purchase";
                                 }
                                 else {
                                     document.getElementById("popTitle").innerHTML = "Sales";
                                 }
                                 $noCon('#myModal').modal('show');

                                 var CstCntrDtl = document.getElementById("DtlPurchase" + tabMode + RowNum).innerHTML;
                                 var splitrow = CstCntrDtl.split("$");
                                 for (var Cst = 0; Cst < splitrow.length; Cst++) {
                                     var splitEach = splitrow[Cst].split("%");
                                     if (splitEach[0] != "") {
                                         if ($("#txtTotAmntPurSale"+ splitEach[0]).length) {
                                             document.getElementById("txtTotAmntPurSale" + splitEach[0]).value = splitEach[1];
                                         }
                                     }
                                 }

                             }
                         }
                     });
                 }           
             if (comVar == 2) {
                 comVar = 0;
             }
                 
             }
             if (document.getElementById("ddlLed" + tabMode + RowNum).value == "-Select Ledger-" || document.getElementById("ddlLed" + tabMode + RowNum).value == "") {
                 $("#divLed" + tabMode + RowNum + "> input").css("borderColor", "red");
                 $("#divLed" + tabMode + RowNum + "> input").focus();
                 $("#divLed" + tabMode + RowNum + "> input").select();
             }
             if (TxtCstctrAmount == "") {
                 document.getElementById("txtTotAmnt" + tabMode + RowNum).style.borderColor = "red";
             }
             if (document.getElementById("<%=HiddenFieldViewMode.ClientID%>").value == "1") {
                 $("#myModal").find(":input").not(".close").prop("disabled", true);
             }
         }
         function changePurSaleAmnt(id) {
             document.getElementById("divErrMsgCnclRsn").style.display = "none";
             document.getElementById("txtTotAmntPurSale" + id).style.borderColor = "";
             IncrmntConfrmCounter();
             var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
             var ObjVal = document.getElementById("txtTotAmntPurSale" + id).value.trim().replace(/,/g, "");
             var ObjSalePurVal = document.getElementById("AmntList" + id).innerHTML.replace(/,/g, "");
              if (ObjVal != "") {
                  ObjVal = parseFloat(ObjVal);
                  ObjSalePurVal = parseFloat(ObjSalePurVal);
                  if (ObjVal > ObjSalePurVal) {
                      document.getElementById("txtTotAmntPurSale" + id).style.borderColor = "red";
                      document.getElementById("txtTotAmntPurSale" + id).focus();
                      document.getElementById("txtTotAmntPurSale" + id).value = "";
                      document.getElementById("divErrMsgCnclRsn").style.display = "";
                      document.getElementById("lblErrMsgCancelReason").innerHTML = "Amount cannot be greater than balance amount.";                   
                  }
                  else {
                      var totSaleAmnt = 0;
                      $('#divSelectList :input').each(function () {
                          if ($(this).val() != "") {
                              var isc = $(this).attr("id").split('e');
                              var selId = isc[1];
                              var RefList = document.getElementById("refList" + selId).innerHTML;
                              var AmntList = document.getElementById("txtTotAmntPurSale" + selId).value.replace(/,/g, "");
                              totSaleAmnt = parseFloat(totSaleAmnt) + parseFloat(AmntList);
                          }
                      });
                      ObjSalePurVal = document.getElementById("LedgerAmtInModalPurSale").innerHTML.replace(/,/g, "");
                      ObjSalePurVal = parseFloat(ObjSalePurVal);
                      totSaleAmnt = parseFloat(totSaleAmnt);
                      if (totSaleAmnt > ObjSalePurVal) {
                          document.getElementById("txtTotAmntPurSale" + id).value = "";
                          document.getElementById("divErrMsgCnclRsn").style.display = "";
                          document.getElementById("lblErrMsgCancelReason").innerHTML = "Total amount cannot be greater than ledger amount.";
                          document.getElementById("txtTotAmntPurSale" + id).style.borderColor = "red";
                          document.getElementById("txtTotAmntPurSale" + id).focus();
                          return false;
                      }
                      else {
                          document.getElementById("txtTotAmntPurSale" + id).value = ObjVal.toFixed(FloatingValueMoney);
                          document.getElementById("txtTotAmntPurSale" + id).value = document.getElementById("txtTotAmntPurSale" + id).value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                      }
                  }
              }
         }
         function changeCostAmnt(id) {
             document.getElementById("divErrMsgCnclRsnCostCenter").style.display = "none";
             document.getElementById("TxtCstctrAmount_" + id).style.borderColor = "";
             IncrmntConfrmCounter();
             var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
             var ObjVal = document.getElementById("TxtCstctrAmount_" + id).value.trim().replace(/,/g, "");
             var ObjSalePurVal = document.getElementById("LedgerAmtInModal").innerHTML.replace(/,/g, "");
             if (ObjVal != "") {               
                 var addRowtable = document.getElementById("TableAddQstnCostCenter");
                 var CstTotal = 0;
                 for (var i = 1; i < addRowtable.rows.length; i++) {
                     var varId = (addRowtable.rows[i].cells[0].innerHTML);                   
                      if (document.getElementById("TxtCstctrAmount_" + varId).value.trim() != "") {
                             var ldgramt = document.getElementById("TxtCstctrAmount_" + varId).value.trim();
                             ldgramt = ldgramt.replace(/\,/g, '');
                             CstTotal = parseFloat(CstTotal) + parseFloat(ldgramt);
                         }
                 }               
                 ObjSalePurVal = parseFloat(ObjSalePurVal);
                 if (CstTotal > ObjSalePurVal) {
                     document.getElementById("TxtCstctrAmount_" + id).value = "";
                     document.getElementById("lblErrMsgCancelReasonCostCenter").innerHTML = "Sum of Cost center amounts cannot be greater than ledger amount";
                     document.getElementById("divErrMsgCnclRsnCostCenter").style.display = "";
                     document.getElementById("TxtCstctrAmount_" + id).style.borderColor = "red";
                     document.getElementById("TxtCstctrAmount_" + id).focus();
                 }
                 else {
                     ObjVal = parseFloat(ObjVal);
                     document.getElementById("TxtCstctrAmount_" + id).value = ObjVal.toFixed(FloatingValueMoney);
                 }
             }
         }
         function changeCostDdl(id) {
             document.getElementById("lblErrMsgCancelReasonCostCenter").innerHTML = "";
             document.getElementById("divErrMsgCnclRsnCostCenter").style.display = "none";
             IncrmntConfrmCounter();
             $("#divCostCenter" + id + "> input").css("borderColor", "");
             if (document.getElementById("ddlRecptCosCtr_" + id).value != "-Select Cost Center-") {
                 var NewLedgerId = $("#ddlRecptCosCtr_" + id).val();
                 if (NewLedgerId == "") {
                     $("#divCostCenter" + id + "> input").val("-Select Cost Center-");
                     $("#ddlRecptCosCtr_" + id).val("-Select Cost Center-");
                 }               
                 var flag = true;
                 $('#TableAddQstnCostCenter td:first-child').each(function () {
                     varId = $(this).text();
                     var Costcenterval = $("#ddlRecptCosCtr_" + varId).val();                  
                     if (NewLedgerId == Costcenterval && id != varId && NewLedgerId != "-Select Cost Center-" && NewLedgerId != "") {
                         flag = false;
                     }
                 });
                 if (flag == false) {
                     document.getElementById("lblErrMsgCancelReasonCostCenter").innerHTML = "Cost center cannot be duplicated.";
                     document.getElementById("divErrMsgCnclRsnCostCenter").style.display = "";
                     $("#divCostCenter" + id + "> input").css("borderColor", "red");
                     $("#divCostCenter" + id + "> input").focus();
                     $("#divCostCenter" + id + "> input").select();
                     $("#divCostCenter" + id + "> input").val("-Select Cost Center-");
                     $("#ddlRecptCosCtr_" + id).val("-Select Cost Center-");
                     }
             }
         }
         function CostCentr(RowNum, tabMode) {
             var TxtCstctrAmount = document.getElementById("txtTotAmnt" + tabMode + RowNum).value.trim()
             document.getElementById("txtTotAmnt" + tabMode + RowNum).style.borderColor = "";
             $("#divLed" + tabMode + RowNum + "> input").css("borderColor", "");
             if ((document.getElementById("ddlLed"+tabMode + RowNum).value != "-Select Ledger-" && document.getElementById("ddlLed"+tabMode + RowNum).value != "") && TxtCstctrAmount != "") {

                 if (document.getElementById("DtlCostCenter"+tabMode + RowNum).innerHTML != "") {
                     var CstCntrDtl = document.getElementById("DtlCostCenter" + tabMode + RowNum).innerHTML;
                     var splitrow = CstCntrDtl.split("$");
                     for (var Cst = 0; Cst < splitrow.length; Cst++) {
                         var splitEach = splitrow[Cst].split("%");
                         if (splitEach[0] != "") {
                             FunctionQustn(Cst,1);
                             document.getElementById("ddlRecptCosCtr_" + Cst).value = splitEach[0];
                             $au("#ddlRecptCosCtr_" + Cst).selectToAutocomplete1Letter();
                             document.getElementById("TxtCstctrAmount_" + Cst).value = splitEach[1];
                             $('#btnCostCenter_' + Cst).attr("disabled", "disabled");
                         }
                     }
                 }
                 else {
                     FunctionQustn(0,0);
                 }
                 document.getElementById("BtnPopupCstCntr").click();
                 document.getElementById("LedgerAmtInModal").innerText = TxtCstctrAmount;
             }
             if (document.getElementById("ddlLed" + tabMode + RowNum).value == "-Select Ledger-" || document.getElementById("ddlLed" + tabMode + RowNum).value == "") {
                 $("#divLed" + tabMode + RowNum + "> input").css("borderColor", "red");
                 $("#divLed" + tabMode + RowNum + "> input").focus();
                 $("#divLed" + tabMode + RowNum + "> input").select();
             }
             if (TxtCstctrAmount == "") {
                 document.getElementById("txtTotAmnt" + tabMode + RowNum).style.borderColor = "red";
             }
         }
         function FunctionQustn(x,y) {
             var FrecRowQst = '';
             FrecRowQst = '<tr id="SubQstnRowId_' + x +'" ><td   id="tdidQstnDtls' + x + '" style="display: none" >' + x + '</td>';
             FrecRowQst += '<td   id="tdvalidate' + x + '" style="display: none" >' + x + '</td>';
            
             FrecRowQst += '<td  style="width:50%;padding-left: 1px;"><input style="display:none" value="-1" name="TxtIdSales_' + x + '" class="form-control" id="TxtIdSales_' + x + '" ><input name="TxtRecptCosCtr_' + x + '"  style="display: none;pointer-events: none;background: #eee;" class="form-control" id="TxtRecptCosCtr_' + x + '" ><div id="divCostCenter' + x + '"><select id="ddlRecptCosCtr_' + x + '" name="ddlRecptCosCtr_' + x + '" onchange="return changeCostDdl(' + x + ');" class="form-control ddl"  onkeypress="return DisableEnter(event)"  >';
             FrecRowQst += '</select></div><input name="ddlCostCtrId_' + x + '" style="display:none"  class="form-control" id="ddlCostCtrId_' + x + '" ></td><td  style="width:40%;padding-left: 1px;"><input class="form-control" maxlength="10"  id="TxtCstctrAmount_' + x + '" name="TxtCstctrAmount_' + x + '" value=""   onkeydown="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '\');" onkeypress="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '\');" id="TxtCstctrAmount_' + x + '" onchange="return changeCostAmnt(' + x + ');" onblur="return AmountChecking(\'TxtCstctrAmount_' + x + '\');" type="text" style="text-align: right;"><input class="form-control"   id="TxtActCstctrAmount_' + x + '" value="" onblur="return CheckSumOfLedger(TxtActCstctrAmount_' + x + ',' + x + ',);"  style="text-align: right; display:none"  name="TxtActCstctrAmount_' + x + '" type="text"></td>';

             FrecRowQst += '<td style="width:10%;padding-left: 7px;"><button class="btn btn-primary" id="btnCostCenterDel_' + x + '" onclick="return removeRowQstn(' + x + ',\'Are you sure you want to delete this cost center?\')" style="margin-bottom:8%;">';

             FrecRowQst += '<span title="DELETE"   class="fa fa-trash" id="Span4" style="display: block;">&nbsp;</span></button>';
             FrecRowQst += '<button title="ADD" id="btnCostCenter_' + x + '" onclick="return CheckaddMoreRowsQstn(\'' + x + '\');" class="btn btn-primary"><span  class="fa fa-plus"  style="display: block;">&nbsp;</span></button></td>';


             FrecRowQst += '<td   style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value="INS" id="tdEvtQstn' + x + '" name="tdEvtQstn' + x + '" placeholder=""/></td>';
             FrecRowQst += '<td style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdDtlIdQstn' + x + '" name="tdDtlIdQstn' + x + '" placeholder=""/></td>';
             FrecRowQst += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdInxQstn' + x + '" name="tdInxQstn' + x + '" placeholder=""/> </td></tr>';
             jQuery('#TableAddQstnCostCenter').append(FrecRowQst);
           
             var $options1 = $("#cphMain_ddlMainCostCenter > option").clone();
             $("#ddlRecptCosCtr_" + x).append($options1);
             document.getElementById("ddlRecptCosCtr_" + x).value = "-Select Cost Center-";
             if(y==0)
             $au("#ddlRecptCosCtr_" + x).selectToAutocomplete1Letter();
             return false;
         }
        
         
         function CheckaddMoreRowsQstn(x) {
             var addRowtable;
             var addRowResult = true;
             var check = document.getElementById("tdInxQstn" + x ).value;
             addRowtable = document.getElementById("TableAddQstnCostCenter");
                 if (CheckAndHighlightCostCenter(x) == false) {
                     addRowResult = false;
                 }
                 if (addRowResult == false) {
                     return false;
                 }
                 else {
                     $('#btnCostCenter_' + x).attr("disabled", "disabled");
                     
                     x = parseInt(x) + 1;

                     FunctionQustn(x,0);
                     return false;
                 }
             }

         function CheckAndHighlightCostCenter(x) {
             var ret = true;
             var CstTotal = 0;
             var varId = "";
             var varfocus = "";
             $('#TableAddQstnCostCenter td:first-child').each(function () {
                 varId = $(this).text();
                 var Costcenterval = $("#ddlRecptCosCtr_" + varId).val();
                 document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";

                 $("#divCostCenter" + varId + "> input").css("borderColor", "");
                 $("#divLedger" + x + "> input").css("borderColor", "");

                 if (document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                     document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                     document.getElementById("TxtCstctrAmount_" + varId).focus();
                     ret = false;
                 }
                 if (Costcenterval == '-Select Cost Center-') {
                     $("#divCostCenter" + varId + "> input").css("borderColor", "red");
                     $("#divCostCenter" + varId + "> input").focus();
                     $("#divCostCenter" + varId + "> input").select();

                     document.getElementById("ddlRecptCosCtr_" + varId).style.borderColor = "Red";
                     document.getElementById("ddlRecptCosCtr_" + varId).focus();
                     ret = false;
                 }
             });
             return ret;
         }
         
         function removeRowQstn(Rowid, CofirmMsg) {

             var Costcenterval = $("#ddlRecptCosCtr_" + Rowid).val();
                 ezBSAlert({
                     type: "confirm",
                     messageText: CofirmMsg,
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         jQuery('#SubQstnRowId_' + Rowid).remove();

                         var TableRowCount = document.getElementById("TableAddQstnCostCenter").rows.length;

                         if (TableRowCount != 1) {
                             var idlast = $noCon('#TableAddQstnCostCenter tr:last').attr('id');
                             if (idlast != "") {
                                 var res = idlast.split("_");
                                 document.getElementById("tdInxQstn" + res[1]).value = "";
                                 //document.getElementById("btnCostCenter_" + res[1]).style.opacity = "1";
                                 $('#btnCostCenter_' + res[1]).removeAttr("disabled");
                             }
                         }
                         else {
                             FunctionQustn(0,0);
                         }
                        
                         

                         var id = document.getElementById("<%=HiddenFieldTableId.ClientID%>").value.split('-');
                         var tabMode = id[0];
                         var tabNum = id[1];

                        
                         DtlCostCenter = document.getElementById("DtlCostCenter" + tabMode + tabNum).innerHTML;
                         if (DtlCostCenter != "") {
                             document.getElementById("DtlCostCenter" + tabMode + tabNum).innerHTML = "";
                             var splitrow = DtlCostCenter.split("$");
                             for (var Cst = 0; Cst < splitrow.length; Cst++) {
                                 var splitEach = splitrow[Cst];
                                 var n = splitEach.includes(Costcenterval + "%");
                                 if (n == false) {
                                     if (document.getElementById("DtlCostCenter" + tabMode + tabNum).innerHTML == "") {
                                         document.getElementById("DtlCostCenter" + tabMode + tabNum).innerHTML = splitEach;
                                     }
                                     else {
                                         document.getElementById("DtlCostCenter" + tabMode + tabNum).innerHTML = document.getElementById("DtlCostCenter" + tabMode + tabNum).innerHTML + "$" + splitEach;
                                     }
                                 }
                             }                           
                         }
                         

                     }
                     else {
                     }
                 });
                 return false;
         }
         function MyModalCostCenter(RowNum, tabMode) {
             document.getElementById("<%=HiddenFieldTableId.ClientID%>").value = tabMode + "-" + RowNum;
             var SbCostCenter = '';
             SbCostCenter = '<div class=\"modal fade\" id=\"myModalCstCntr\" role=\"dialog\" style=\"margin-top:8%;\">';
             SbCostCenter += '<div class=\"modal-dialog\">';

             SbCostCenter += '<div class=\"modal-content\">';
             SbCostCenter += '<div class=\"modal-header\">';
             SbCostCenter += '<button type=\"button\" class=\"close\" data-dismiss=\"modal\">&times;</button>';
             SbCostCenter += "<h4 id=\"ModelHeading\" class=\"modal-title\">Import Cost Center</h4>";
             SbCostCenter += "</div>";
             SbCostCenter += '<div class=\"alert alert-danger fade in\" id="divErrMsgCnclRsnCostCenter" style=\"display: none; margin-top: 1%\">';

             SbCostCenter += '<i class=\"fa-fw fa fa-times\"></i>';
             SbCostCenter += '<strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReasonCostCenter"> Please fill this out</label>';
             SbCostCenter += '</div>';
             SbCostCenter += '<div class=\"modal-body\">';

             SbCostCenter += '<div class=\"col-md-12\" style=\"padding-bottom:15px;\">';

             SbCostCenter += '<div class=\"col-md-12 res_table_box\" style=\"padding-bottom:15px;padding-left: 1px;padding-right: 11px;width:102%\">';
             SbCostCenter += '<div class=\"tab-content\" id=\"myTabContent\" style=\"max-height:300px;overflow:auto;\">';
             SbCostCenter += '<div class=\"tab-pane fade active in\" id=\"home\" role=\"tabpanel\" aria-labelledby=\"home-tab\" style=\"border:1px solid #dddddd;padding: 3px;\">';

             SbCostCenter += '<ul class=\"list-group bg-grey\" style=\"font-size:15px;\">';

             SbCostCenter += '<div id=\"DivPopUpCostCenter\">';

             SbCostCenter += '<table id="TableAddQstnCostCenter">';
             SbCostCenter += '<thead> <tr><th style=\"width:50px;padding-left: 1px;\">Cost Center</th><th style=\"width:40%;padding-left: 1px;\"> Amount</th><th style=\"width:10%;padding-left: 2px;\">';
             SbCostCenter += '</th></tr></thead>';
             SbCostCenter += '</table>';
             SbCostCenter += '</div></ul></div></div></div></div></div>';
             SbCostCenter += '<div class=\"clearfix\"></div>';
             SbCostCenter += '<div class=\"modal-footer\">';
             SbCostCenter += '<label id=\"Label1\" for=\"example-text-input\" class=\"col-md-1 col-form-label\" style=\"margin-left: 39%;width: 21%;\">Ledger Amount<span></span></label>';

             SbCostCenter += '<label id="LedgerAmtInModal" for=\"example-text-input\" class=\"col-md-1 col-form-label\" style=\"width: 18%;\"><span></span></label>';
             SbCostCenter += '<button id="btnImportCostCenter" type=\"button\" class=\"btn btn-primary\"  onclick=\"ButtnFillClickCostCenter(\'' + RowNum + '\',\'' + tabMode + '\');\" >Import</button>';
             SbCostCenter += '<button id="BttnCost" type=\"button\" style=\"display:none\" class=\"btn btn-primary\" data-dismiss=\"modal\"></button>';
             SbCostCenter += '</div></div> </div></div>';
             document.getElementById("CostCenterModal").innerHTML = SbCostCenter;
             CostCentr(RowNum, tabMode);
             if (document.getElementById("<%=HiddenFieldViewMode.ClientID%>").value == "1") {
                 $("#myModalCstCntr").find(":input").not(".close").prop("disabled", true);
             }
             var idlast = $noCon('#TableAddQstnCostCenter tr:last').attr('id');
             if (idlast != "") {
                 var res = idlast.split("_");
                 $('#btnCostCenter_' + res[1]).removeAttr("disabled");
             }
         }
         function ButtnFillClickCostCenter(x, tabMode) {
             var ret = true;
             var TotalAmnt = 0;
             var purchaseFlag = 0;
             var CheckCount = 0;
             document.getElementById("divErrMsgCnclRsn").style.display = "none";
             var TotalAmnt = document.getElementById("txtTotAmnt" + tabMode+x).value;
             TotalAmnt = TotalAmnt.replace(/\,/g, '');
             var addRowtable = document.getElementById("TableAddQstnCostCenter");
             document.getElementById("lblErrMsgCancelReasonCostCenter").innerHTML = "";
             document.getElementById("divErrMsgCnclRsnCostCenter").style.display = "none";
             document.getElementById("DtlCostCenter" +tabMode+ x).innerHTML = "";
             var CstTotal = 0;
             for (var i = 1; i < addRowtable.rows.length; i++) {
                 var varId = (addRowtable.rows[i].cells[0].innerHTML);                     
                 document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
                 document.getElementById("ddlRecptCosCtr_" + varId).style.borderColor = "";
                 var Costval = $("#ddlRecptCosCtr_" + varId).val();
                 if (Costval == "-Select Cost Center-" && document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                 }
                 else {
                     if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                         var ldgramt = document.getElementById("TxtCstctrAmount_" + varId).value;
                         ldgramt = ldgramt.replace(/\,/g, '');
                         CstTotal = parseFloat(CstTotal) + parseFloat(ldgramt);
                         purchaseFlag++;
                     }
                     if (document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                         document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                        
                     }
                     if (Costval == "-Select Cost Center-") {
                         $("#ddlRecptCosCtr_" + varId).css("borderColor", "red");
                     }

                     if (Costval != "-Select Cost Center-" && document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                         if (document.getElementById("DtlCostCenter" + tabMode + x).innerHTML == "") {
                             document.getElementById("DtlCostCenter" + tabMode + x).innerHTML = Costval + "%" + document.getElementById("TxtCstctrAmount_" + varId).value;
                         }
                         else {
                             document.getElementById("DtlCostCenter" + tabMode + x).innerHTML = document.getElementById("DtlCostCenter" + tabMode + x).innerHTML + "$" + Costval + "%" + document.getElementById("TxtCstctrAmount_" + varId).value;
                         }
                     }
                 }
             }
             if (CstTotal != "") {
                 if (parseFloat(TotalAmnt) != parseFloat(CstTotal)) {
                     document.getElementById("lblErrMsgCancelReasonCostCenter").innerHTML = " Ledger amount should be equal to cost center amount";
                     document.getElementById("divErrMsgCnclRsnCostCenter").style.display = "";
                     ret = false;
                 }
             }
             if (purchaseFlag == 0) {
                 document.getElementById("lblErrMsgCancelReasonCostCenter").innerHTML = " Please select a cost center to import.";
                 document.getElementById("divErrMsgCnclRsnCostCenter").style.display = "";
                 ret = false;
             }
             if (ret == true) {
                 if (purchaseFlag != 0) {
                     document.getElementById("BttnCost").click();
                 }
             }      
          }
        </script>
     <style>
                 .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
    padding: 5px 5px;
}
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
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
     <script>
         var $au = jQuery.noConflict();
         $au(function () {
             $au(".ddl").selectToAutocomplete1Letter();
         });
         </script>
</asp:Content>

