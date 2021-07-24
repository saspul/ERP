<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Account_Closing.aspx.cs" Inherits="FMS_FMS_Master_fms_Account_Closing_fms_Account_Closing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
    <script src="/js/Common/Common.js"></script>
    <script type="text/javascript" src="/js/datepick.min.js"></script>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />


    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
        
            if (document.getElementById("<%=HiddenSearch.ClientID%>").value == "") {
                toggler('myContentCls');
            }
            LoadEmpListCls();     
            LoadEmpList();
            if (document.getElementById("<%=HiddenFieldYearEndId.ClientID%>").value != "") {
                document.getElementById("ClsDate").style.pointerEvents = "none";
                document.getElementById("divCheck").style.pointerEvents = "none";     
            }
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

            /* COLUMN FILTER  */
            var otable = $NoConfi3('#datatable_fixed_columnCls').DataTable({
                "bSort": false,
                "bDestroy": true,

                "preDrawCallback": function () {
                    // Initialize the responsive datatables helper once.
                    if (!responsiveHelper_datatable_fixed_column) {
                        responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#datatable_fixed_columnCls'), breakpointDefinition);
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
            $NoConfi("#datatable_fixed_columnCls thead th input[type=text]").on('keyup change', function () {

                otable
                    .column($NoConfi(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });
            /* END COLUMN FILTER */
        }

        function LoadEmpListCls() {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';

            var responsiveHelper_datatable_fixed_column = undefined;
            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };
            /* COLUMN FILTER  */
            var otable = $NoConfi3('#datatable_fixed_column').DataTable({

                //"searching": false,
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
            $noCon("#divWarning").html("This action is  denied! This account date is already deleted .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function AlreadyConfirm() {
            $noCon("#divWarning").html("This action is  denied! This account date is already confirmed.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function PendingConfirmMsg() {
            $noCon("#divWarning").html("There is pending confirmed account closing.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessConfirm() {
            $noCon("#success-alert").html("Closed date confirmed successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessClose() {
            $noCon("#success-alert").html("Closed date deleted successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessMsg() {
            $noCon("#success-alert").html("financial account closed successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
           

            return false;

        }


        function AlreadyRecall() {
            $noCon("#divWarning").html("This action is  denied! This account date is already recalled.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SucRecall() {
            $noCon("#success-alert").html("financial account recalled successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        function CloseValidate() {

            var msg = "Are you sure you want to close the financial account?";
            if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                //msg = "Are you sure you want to close this financial year accounts?";
            }
            if (document.getElementById("<%=HiddenFieldYearEndId.ClientID%>").value != "") {
                msg = "Are you sure you want to recall the financial account?";
            }    
            ezBSAlert({
                type: "confirm",
                messageText: msg,
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=bttnsave.ClientID%>").click();
            }
            else {
                    // window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                return false;
            }
            });

        return false;
    }

    function Validate() {
        var ret = true;
        $noCon("div#divddlAccntGrp input.ui-autocomplete-input").css("borderColor", "");
        var VLedToDate = document.getElementById("<%=LedToDate.ClientID%>").value;
            var AccGrpId = document.getElementById("<%=ddlAccntGrp.ClientID%>").value;


            document.getElementById("<%=LedToDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlAccntGrp.ClientID%>").style.borderColor = "";


            if (AccGrpId == "--SELECT ACCOUNT GROUP--") {
                //  document.getElementById("<%=ddlAccntGrp.ClientID%>").style.borderColor = "Red";


                $noCon("div#divddlAccntGrp input.ui-autocomplete-input").css("borderColor", "red");

                $noCon("div#divddlAccntGrp input.ui-autocomplete-input").focus();
                $noCon("div#divddlAccntGrp input.ui-autocomplete-input").select();

                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
               
                $noCon(window).scrollTop(0);

                ret = false;
            }
            else {

                document.getElementById("<%=HiddenddlAccntGrp.ClientID%>").value = AccGrpId;
                // DateChk();
            }

            if (VLedToDate == "") {

                document.getElementById("<%=LedToDate.ClientID%>").style.borderColor = "Red";
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });            
                $noCon(window).scrollTop(0);
                ret = false;
            }
            else {
                document.getElementById("<%=HiddenSearch.ClientID%>").value = "1";
            }

            return ret;

        }
        function CloseErrorMsg() {
            $noCon("#divWarning").html("Entered date is invalid.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });         
            $noCon(window).scrollTop(0);
        }
        function toggler(divId) {

            $("#" + divId).toggle();
            if (divId == 'myContentCls') {
                if (document.getElementById("myContent").style.display == "block") {
                    $("#myContent").toggle();
                    // LoadEmpListCls();

                }
            }
            else {
                if (document.getElementById("myContentCls").style.display == "block") {
                    $("#myContentCls").toggle();

                }

            }
            $au('#cphMain_ddlAccntGrp').selectToAutocomplete1Letter();
            // alert();
            LoadEmpListCls();
            LoadEmpList();
            // LoadEmpList();
            return false;
        }

        function OpenCancelView(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to delete this closed date?",
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
        function OpenConfirm(strId) {
            var strUserID = '<%=Session["USERID"]%>';

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to confirm this closed date?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    if (strId != "" && strUserID != '') {
                        var Details = PageMethods.ConfirmAccountClose(strId, strUserID, function (response) {
                            var SucessDetails = response;
                            if (SucessDetails == "ConfirmSus") {
                                window.location = "fms_Account_Closing.aspx?InsUpd=ConfirmSus";
                            }
                            else if (SucessDetails == "UpdCancl") {
                                window.location = "fms_Account_Closing.aspx?InsUpd=UpdCancl";
                            }
                            else {
                                window.location = 'fms_Account_Closing.aspx?InsUpd=Error';
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

        function DeleteByID(strId, strCancelReason, strCancelMust) {
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgID = '<%=Session["ORGID"]%>';
            var strCorprtID = '<%=Session["CORPOFFICEID"]%>';
            if (strId != "" && strUserID != '') {
                var Details = PageMethods.CancelMemoReason(strId, strCancelMust, strUserID, strCancelReason, strOrgID, strCorprtID, function (response) {

                    var SucessDetails = response;
                    if (SucessDetails == "successcncl") {
                        window.location = "fms_Account_Closing.aspx?InsUpd=cncl";
                    }
                    else if (SucessDetails == "UpdCancl") {
                        window.location = "fms_Account_Closing.aspx?InsUpd=UpdCancl";
                    }
                    else if (SucessDetails == "Confirmed") {
                        window.location = "fms_Account_Closing.aspx?InsUpd=Confirmed";
                    }
                    else {
                        window.location = 'fms_Account_Closing.aspx?InsUpd=Error';
                    }

                });
            }

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
    <asp:HiddenField ID="HiddenLastClosDate" runat="server" />
    <asp:HiddenField ID="HiddenStartDate" runat="server" />
    <asp:HiddenField ID="HiddenAccountClsDate" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="HiddenFieldDecimalCnt" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenddlAccntGrp" runat="server" />

    <asp:HiddenField ID="HiddenFieldYearEndId" runat="server" />
    <asp:HiddenField ID="HiddenSearch" runat="server" />

    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Account Closing</li>
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
                    <label for="pwd" class="fg2_la1">Closing Date:<span class="spn1"></span> </label>
                    <div id="ClsDate" class="input-group date" data-date-format="mm-dd-yyyy">
                            <input id="txtFromdate" runat="server" type="text" onkeypress="return DisableEnter(event)" onfocus="return DateFocus();" readonly="readonly" onchange="show()" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
                            <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                    </div>
                </div>


                <script>
                    var dateAudit = "";
                    var datepickerDate1 = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
                    var datepickerDate2 = document.getElementById("<%=HiddenFinancialYearTo.ClientID%>").value;


                    $noCon('#ClsDate').datepicker({
                        format: 'dd-mm-yyyy',
                        startDate: datepickerDate1,
                        endDate: datepickerDate2,
                        autoclose: true,
                        //  timepicker: false
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
                    function DisplayChange() {
                        $("#myContent").toggle();


                    }

                    function ChngYrEndClose() {

                        var datepickerDate1 = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
                        var datepickerDate2 = '+0d';

                        if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                            datepickerDate2 = document.getElementById("<%=HiddenFinancialYearTo.ClientID%>").value;
                        }
                        else {
                            document.getElementById("<%=txtFromdate.ClientID%>").value = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;
                        }

                        //alert(datepickerDate1); alert(datepickerDate2);

                        $noCon('#ClsDate').datepicker('setStartDate', datepickerDate1);
                        $noCon('#ClsDate').datepicker('setEndDate', datepickerDate2);

                        return false;
                    }


                    function ValidateClose() {

                        var ret = true;

                        document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
                        var date = document.getElementById("<%=txtFromdate.ClientID%>").value;

                        if (date == "") {
                            $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtFromdate.ClientID%>").focus();
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
                        return ret;
                    }

                </script>
                  <div class="form-group fg7" id="divCheck">
                    <label class="form1 mar_bo mar_tp">
                        <span class="button-checkbox">
                             <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" Checked="false" class="form2" onclick="DisableEnter(event)" onkeydown="return DisableEnter(event)" />
                            <button type="button" class="btn-d" data-color="p"></button>
                        </span>
                        <p class="pz_s">Year-end closing</p>
                    </label>
                </div>
                <div class="fg5">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <button id="BtnClose" tabindex="23" runat="server" onclick="return CloseValidate();" class="btn tab_but1 butn5 tr_c"><i class="fa fa-times-circle fa_clo"></i>Account Close </button>
                </div>
                <div class="fg5">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <a href="#myContentCls" onclick="return toggler('myContentCls' );">
                        <button onclick="return false" class="btn tab_but1 butn5 tablinks">Closing History</button></a>
                </div>
                <div class="fg5">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <a href="#myContent" onclick="return toggler('myContent' );">
                        <button onclick="return false" class="btn tab_but1 butn5 tablinks" title="OUTSTANDING AMOUNT"><i class="fa fa-money list1 pad_tp"></i></button>
                    </a>
                </div>

                <div class="clearfix"></div>
                <p class="plc1">
                    Last Closed Date :
                    <label id="lblLastClsdDate" for="example-text-input" runat="server"></label>
                </p>

                <div id="myContent" class="hiddenncopy">
                    <h2>
                        <asp:Label ID="Label" runat="server">OUTSTANDING AMOUNT</asp:Label></h2>
                    <div class="form-group fg2">
                        <label for="pwd" class="fg2_la1">To Date<span class="spn1"></span> </label>
                        <div id="datepicker2" class="input-group date">
                            <input id="LedToDate" runat="server" type="text" onkeypress="return DisableEnter(event)" onfocus="return DateFocus();" readonly="readonly" onchange="show()" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
                            <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                            <script>
                                var dateFinFrom = "";
                                var dateFinTo = "";
                                if (document.getElementById("cphMain_HiddenFinancialYearFrom").value != "") {
                                    var datepickerDate2 = document.getElementById("cphMain_HiddenFinancialYearFrom").value;
                                    var arrDatePickerDate2 = datepickerDate2.split("-");
                                    var varday1 = arrDatePickerDate2[0];
                                    varday1++;
                                    dateFinFrom = new Date(arrDatePickerDate2[2], arrDatePickerDate2[1] - 1, varday1);
                                }
                                if (document.getElementById("cphMain_HiddenFinancialYearTo").value != "") {
                                    var YearTo = document.getElementById("cphMain_HiddenFinancialYearTo").value;
                                    var arrYearTo = YearTo.split("-");
                                    var varday = arrYearTo[0];
                                    varday++;
                                    dateFinTo = new Date(arrYearTo[2], arrYearTo[1] - 1, varday);
                                }
                                $noCon('#datepicker2').datepicker({
                                    format: 'dd-mm-yyyy',
                                    startDate: dateFinFrom,
                                    endDate: dateFinTo,
                                    autoclose: true,
                                });
                            </script>
                        </div>
                    </div>
                    <div class="form-group fg2 mar_bo1">
                        <label for="email" class="fg2_la1">Account Group:<span class="spn1"></span></label>
                        <div id="divddlAccntGrp">
                            <asp:DropDownList ID="ddlAccntGrp" CssClass="form-control form-control fg2_inp1" runat="server" onchange="return  IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="fg2">
                        <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                        <asp:Button ID="btnCnclSearch" runat="server" class="submit_ser" OnClientClick="return Validate();" OnClick="btnCnclSearch_Click" />
                    </div>

                    <div class="clearfix"></div>
                    <div class="devider"></div>
                    <div id="DivOutstdBal" runat="server">
                    </div>
                </div>
                <div class="clearfix"></div>
                <div id="myContentCls" class="hiddenncopy">
                    <h2>CLOSING History</h2>
                    <div id="DivClsHis" class="table_box tb_scr" runat="server">
                    </div>
                </div>
                 <div style="clear: both"></div>
        <asp:Button ID="bttnsave" runat="server" OnClick="bttnsave_Click" Style="display: none" class="btn btn-primary btn-grey  btn-width" Text="Save" OnClientClick="return ValidateClose();" />
            </div>
        </div>
        </div>

    
       

  
  
  
                    
        <%--------------------------------View for error Reason--------------------------%>

     <%--   <div id="dialog_simple" title="Dialog Simple Title" style="display: none;">
            <div class="widget-body no-padding" id="divCancelPopUp">
                <div class="alert alert-danger fade in" id="lblErrMsgCancelReason" style="display: none; margin-top: 1%">
                    <i class="fa-fw fa fa-times"></i>
                    <strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReason"> Please fill this out</label>
                </div>
                <div style="width: 100%; float: left; clear: both; margin-top: 5%">
                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Delete Reason*</label>
                        <label class="input" style="float: left; width: 60%;">
                            <textarea name="txtCancelReason" rows="2" cols="20" id="txtCancelReason" class="form-control" style="text-transform: uppercase; resize: none;" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)"></textarea>
                        </label>
                    </section>
                </div>
                <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="border-top: none;">
                    <div class="ui-dialog-buttonset">
                        <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; SAVE</button>
                        <button type="button" class="btn btn-default" onclick="return CloseCancelView();"><i class="fa fa-times"></i>&nbsp; Cancel</button>
                    </div>
                </div>
            </div>
        </div>--%>
   
        
 <div class="modal fade" id="dialog_simple" tabindex="-1"  data-backdrop="static"   role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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

  
    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlAccntGrp').selectToAutocomplete1Letter();
        });
    </script>
        <style>
        .hiddenncopy {
            display: none;
        }
    </style>
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
</asp:Content>

