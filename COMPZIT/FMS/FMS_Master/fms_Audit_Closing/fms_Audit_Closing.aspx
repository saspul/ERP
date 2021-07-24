<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Audit_Closing.aspx.cs" Inherits="FMS_FMS_Master_fms_Audit_Closing_fms_Audit_Closing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script>

    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            LoadEmpList();       
        });

        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();
        function LoadEmpList() {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var responsiveHelper_datatable_fixed_column = undefined;
            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };
            var otable = $NoConfi3('#datatable_fixed_column').DataTable({

               
                "bDestroy": true,
                "bSort": false,
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
            // custom toolbar
            // Apply the filter
            $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                otable
                    .column($NoConfi(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });
            /* END COLUMN FILTER */

        }


    </script>
    <script>
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function SuccessError() {
            $noCon("#divWarning").html("Some error occured!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessDeleted() {
            $noCon("#divWarning").html("This action is  denied! This audit date is already deleted .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessClose() {
            $noCon("#success-alert").html("Audit date deleted successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessMsg() {
            $noCon("#success-alert").html("Audit closed successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
           

            return false;

        }
        function CloseValidate() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to the audit?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=bttnsave.ClientID%>").click();
            }

            else {
                return false;
            }
            });

        return false;
    }
    function PendingConfirmMsg() {
        $noCon("#divWarning").html("There is pending confirmed audit closing.");
        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function AlreadyConfirm() {
        $noCon("#divWarning").html("This action is  denied! This audit date is already confirmed.");
        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function AccountCloseBeforeAudit() {
        $noCon("#divWarning").html("Audit close can be done only after account close.");
        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
    function SuccessConfirm() {
        $noCon("#success-alert").html("Audit date confirmed successfully.");
        $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }

    function CloseErrorMsg() {
        $noCon("#divWarning").html("Enterd date is invalid.");
        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
        });
        
        $noCon(window).scrollTop(0);

    }
    function toggler(divId) {
        $("#" + divId).toggle();
        if (divId == 'myContentCls') {
        }
        else {
            if (document.getElementById("myContentCls").style.display == "block")
                $("#myContentCls").toggle();

        }
        LoadEmpList();
        return false;
    }

    function OpenCancelView(StrId) {
        ezBSAlert({
            type: "confirm",
            messageText: "Do you want to delete this audit date?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {
                var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                var strCancelReason = "";
                if (strCancelMust == 1) {


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


        function DeleteByID(strId, strCancelReason, strCancelMust) {
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgID = '<%=Session["ORGID"]%>';
            var strCorprtID = '<%=Session["CORPOFFICEID"]%>';
            if (strId != "" && strUserID != '') {
                var Details = PageMethods.CancelMemoReason(strId, strCancelMust, strUserID, strCancelReason, strOrgID, strCorprtID, function (response) {

                    var SucessDetails = response;
                    if (SucessDetails == "successcncl") {
                        window.location = "fms_Audit_Closing.aspx?InsUpd=cncl";
                    }
                    else if (SucessDetails == "UpdCancl") {
                        window.location = "fms_Audit_Closing.aspx?InsUpd=UpdCancl";
                    }
                    else if (SucessDetails == "Confirmed") {
                        window.location = "fms_Audit_Closing.aspx?InsUpd=Confirmed";
                    }
                    else {
                        window.location = 'fms_Audit_Closing.aspx?InsUpd=Error';
                    }

                });
            }

            return false;
        }

        function OpenConfirm(strId) {
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgID = '<%=Session["ORGID"]%>';
            var strCorprtID = '<%=Session["CORPOFFICEID"]%>';

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to confirm this audit date?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    if (strId != "" && strUserID != '') {
                        var Details = PageMethods.ConfirmAccountClose(strId, strUserID, strOrgID, strCorprtID, function (response) {
                            var SucessDetails = response;
                            if (SucessDetails == "ConfirmSus") {
                                window.location = "fms_Audit_Closing.aspx?InsUpd=ConfirmSus";
                            }
                            else if (SucessDetails == "UpdCancl") {
                                window.location = "fms_Audit_Closing.aspx?InsUpd=UpdCancl";
                            }
                            else {
                                window.location = 'fms_Audit_Closing.aspx?InsUpd=Error';
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

        function ValidateCancelReason()
        {
            var ret = true;
            document.getElementById("txtCancelReason").style.borderColor = "";
            var strCancelReason = document.getElementById("txtCancelReason").value;
            if (strCancelReason == "") {
                document.getElementById("txtCancelReason").style.borderColor = "red";
                document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
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
                    $('#dialog_simple').on('shown.bs.modal', function () {
                        document.getElementById("txtCancelReason").focus();
                    });

                    return false;
                }
            });
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYearFrom" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYearTo" runat="server" />
    <asp:HiddenField ID="HiddenFocusDate" runat="server" />
    <asp:HiddenField ID="HiddenAccountClsDate" runat="server" />
    <asp:HiddenField ID="HiddenLastClosDate" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="HiddenFieldDecimalCnt" runat="server" />
    <asp:HiddenField ID="HiddenAuditDependent" runat="server" />
    <asp:HiddenField ID="HiddenStartDate" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
     
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Audit Closing</li>
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
    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                <h1>
                    <asp:Label ID="lblEntry" runat="server"></asp:Label></h1>

                <div class="form-group fg2">
                    <label for="pwd" class="fg2_la1">Audit Date:<span class="spn1"></span> </label>
                    <div id="ClsDate" class="input-group date" data-date-format="mm-dd-yyyy">
                        <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                            <input id="txtFromdate" runat="server" type="text" onkeypress="return DisableEnter(event)" onfocus="return DateFocus();" readonly="readonly" onchange="show()" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
                            <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                        </div>
                    </div>
                </div>

                <script>
                    var dateAudit = "";
                    var datepickerDate1 = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
                    var arrDatePickerDate1 = datepickerDate1.split("-");
                    var varday = arrDatePickerDate1[0];
                    dateAudit = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, varday);
                    $noCon('#datepicker').datepicker({
                        format: 'dd-mm-yyyy',
                        startDate: dateAudit,
                        endDate: '+0d',
                        autoclose: true,
                    });
                </script>
                <script>
                    var $noCon4 = jQuery.noConflict();
                    function DateFocus() {
                        $noCon4('#cphMain_HiddenFocusDate').val($noCon4('#cphMain_txtFromdate').val().trim());

                        return false;
                    }
                    function show() {

                        IncrmntConfrmCounter();

                        // $noCon4("#txtDateFrom").datetimepicker({ format: 'dd-mm-yyyy' })
                        $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#cphMain_txtFromdate').val().trim());
                        if ($noCon4('#cphMain_txtFromdate').val().trim() != "") {
                            var datepickerDate = document.getElementById("cphMain_txtFromdate").value;
                            var arrDatePickerDate = datepickerDate.split("-");
                            var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                            var datepickerDate = document.getElementById("cphMain_HiddenCurrentDate").value;
                            var arrDatePickerDate = datepickerDate.split("-");
                            var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                            if (dateTxIss > dateCompExp) {

                                if (document.getElementById("cphMain_HiddenFocusDate").value != "") {

                                    //  $noCon4('#cphMain_txtFromdate').val($noCon4('#cphMain_HiddenFocusDate').val().trim());
                                    if ($noCon4('#cphMain_txtFromdate').val().trim() !== "")
                                        $noCon4(".datepicker").datepicker("update", $noCon4('#cphMain_txtFromdate').val().trim());

                                }
                                else
                                    $noCon4('#cphMain_txtFromdate').val("");
                            }


                        }
                        else {
                            $noCon4('#cphMain_txtFromdate').val($noCon4('#cphMain_HiddenCurrentDate').val().trim());
                        }


                    }

                    function insert() {

                        IncrmntConfrmCounter();
                        $noCon4('#cphMain_txtFromdate').val($noCon4('#cphMain_Hiddentxtefctvedate').val().trim());

                    }
                    function insertTO() {

                        IncrmntConfrmCounter();
                        $noCon4('#cphMain_txtFromdate').val($noCon4('#cphMain_HiddentxtefctvedateTo').val().trim());

                    }

                </script>

                <div class="fg2">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <button id="BtnClose" tabindex="23" runat="server" onclick="return CloseValidate();" class="btn tab_but1 butn5"><i class="fa fa-times-circle fa_clo"></i>AUDIT CLOSE  </button>
                </div>

                <div class="fg2">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <a href="#myContentCls" onclick="return toggler('myContentCls' );">
                        <button onclick="return false" class="btn tab_but1 butn5 tablinks">CLOSING HISTORY</button>
                    </a>
                </div>

                <div class="clearfix"></div>
                 <p class="plc1">
                   Last Account Closed Date:
                    <label id="lblLastAccountClsdDate" for="example-text-input" runat="server"></label>
                </p>
                <p class="plc1">
                     Last Audited Date:
                    <label id="lblLastAuditClsdDate" for="example-text-input" runat="server"></label>
                </p>

               

                <div id="myContentCls" class="open_cl">
                    <h2>CLOSING History</h2>
                    <div class="row">
                        <div class="form-group col-md-12">
                            <div id="DivClsHis" runat="server">
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both"></div>
                <asp:Button ID="bttnsave" runat="server" OnClick="bttnsave_Click" Style="display: none" class="btn btn-primary btn-grey  btn-width" Text="Save" />
            </div>
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
</asp:Content>

