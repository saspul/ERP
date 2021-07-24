<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Emp_Transfer_Bulk.aspx.cs" Inherits="HCM_HCM_Master_hcm_Employee_Transfer_hcm_Emp_Transfer_Bulk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />

    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />

    <script src="/js/HCM/Common.js"></script>
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

        .ui-autocomplete-input {
            padding-left: 10px;
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

    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

    <script src="/js/datepicker/bootstrap-datepicker.js"></script>
    <link href="/js/datepicker/datepicker3.css" rel="stylesheet" />
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();

        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {
                // alert('An attempt was made to submit this form more than once; this extra attempt will be ignored.');
                return false;
            }
            else {
                return true;
            }
        } function CheckSubmitZero() {
            submit = 0;
        }

        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }

        var $au = jQuery.noConflict();
        var $noCon2 = jQuery.noConflict();

        $au(function () {

            //messages
            var session = '<%=Session["SUCCESS_EMPTRNS"]%>';

            if (session == "SAVE") {
                AddSuccesMessage();
            }
            else if (session == "UPD") {
                UpdateSuccesMessage();
            }
            else if (session == "CONFIRM") {
                ConfirmSuccesMessage();
            }
            '<%Session["SUCCESS_EMPTRNS"] = '"' + null + '"'; %>';

            $au('#cphMain_ddlBusinessUnit').selectToAutocomplete1Letter();
            $au('#cphMain_ddlNewBussinessunit').selectToAutocomplete1Letter();

            $('#cphMain_cbxNewEmployeeId').attr('checked', false);
            BusinessdivVisible('QCK')

            $noCon('div#divddlBusinessUnit input.ui-autocomplete-input').focus();

            if (document.getElementById("<%=hiddenManpowerId.ClientID%>").value != "") {
                var ManPowId = document.getElementById("<%=hiddenManpowerId.ClientID%>").value;
                ManListView();
                $('#cphMain_ManYes').attr('checked', true);
                Manpowerproceed();
                if ($('#cbxManPwr_' + ManPowId).length) {
                    $('#cbxManPwr_' + ManPowId).prop('checked', true);
                    $('#cbxManPwr_' + ManPowId).closest('tr').css('background', '#93c689');
                }
            } else {
            }
            ManTableVisible('QCK');
        });

        function DateChk(obj) {

            document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
               var dateFromDate = document.getElementById("<%=txtFromdate.ClientID%>").value;
               var arrdateFromDate = dateFromDate.split("-");
               var FromDate = new Date(arrdateFromDate[2], arrdateFromDate[1] - 1, arrdateFromDate[0]);

               var dateTodate = document.getElementById("<%=txtTodate.ClientID%>").value;
            var arrdateTodate = dateTodate.split("-");
            var Todate = new Date(arrdateTodate[2], arrdateTodate[1] - 1, arrdateTodate[0]);

            if ($('#cphMain_radioTemporary').is(':checked')) {


                if (FromDate != "" && Todate != "") {
                    if (Todate < FromDate) {

                        $noCon("#Warningalert").fadeTo(2000, 500).slideUp(500, function () {

                        });
                        $noCon("#Warningalert").alert();
                        document.getElementById(obj).value = "";
                        document.getElementById(obj).style.borderColor = "red";
                    }

                }

            }

        }

        function ValidateTransfer() {

            var Empval = $noCon('#cphMain_ddlNewDivision').val();
            document.getElementById("<%=hiddenDivIds.ClientID%>").value = Empval;
          
            var flag = true;

            var focus = '';
            $noCon('#cphMain_ddlreporter').each(function () {

                if ($noCon.trim($noCon(this).val()) == '--SELECT REPORTER--') {
                    //  isValid = false;
                    flag = false;
                    $noCon(this).focus();
                    $noCon(this).css({
                        "border": "1px solid red",
                        "background": ""
                    });

                }
                else {
                    $noCon(this).css({
                        "border": "",
                        "background": ""
                    });
                }
            });
            if (document.getElementById("<%=hiddenPaygradeId.ClientID%>").value == "") {
                $noCon('#cphMain_ddlnewPaygrade').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '--SELECT PAYGRADE--') {
                        //  isValid = false;
                        flag = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });

                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });
            }

            if (document.getElementById("<%=hiddenDepartmentId.ClientID%>").value == "") {
                $noCon('#cphMain_ddlNewDepartment').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '--SELECT DEPARTMENT--') {
                        //  isValid = false;
                        flag = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });

                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });
            }

            if ($('#cphMain_radioBUtransfer').is(':checked')) {
                $noCon('#cphMain_ddlNewBussinessunit').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '--SELECT BUSINESS UNIT--') {
                        //  isValid = false;
                        flag = false;
                        $noCon('div#divddlNewBusinessUnit input.ui-autocomplete-input').focus();
                        $noCon('div#divddlNewBusinessUnit input.ui-autocomplete-input').css({
                            "border": "1px solid red",
                            "background": ""
                        });

                    }
                    else {
                        $noCon('div#divddlNewBusinessUnit input.ui-autocomplete-input').css({
                            "border": "",
                            "background": ""
                        });
                    }
                });
            } else {
                if ($('#cphMain_ManYes').is(':checked')) {
                    if (document.getElementById("<%=hiddenManpowerId.ClientID%>").value == "") {
                        $noCon("#WarningAlertManpower").fadeTo(2000, 500).slideUp(500, function () {

                        });
                        $noCon("#WarningAlertManpower").alert();

                        $(window).scrollTop(0);
                        ret = false;
                    }
                }
            }


            if ($('#cphMain_radioTemporary').is(':checked')) {
                $noCon('#cphMain_txtFromdate,#cphMain_txtTodate').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '') {
                        //  isValid = false;
                        flag = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });

                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });


                document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
                var dateFromDate = document.getElementById("<%=txtFromdate.ClientID%>").value;
                var arrdateFromDate = dateFromDate.split("-");
                var FromDate = new Date(arrdateFromDate[2], arrdateFromDate[1] - 1, arrdateFromDate[0]);

                var dateTodate = document.getElementById("<%=txtTodate.ClientID%>").value;
                var arrdateTodate = dateTodate.split("-");
                var Todate = new Date(arrdateTodate[2], arrdateTodate[1] - 1, arrdateTodate[0]);

                if (FromDate != "" && Todate != "") {
                    if (Todate < FromDate) {
                        $noCon("#Warningalert").fadeTo(2000, 500).slideUp(500, function () {

                        });
                        $noCon("#Warningalert").alert();
                        document.getElementById("<%=txtTodate.ClientID%>").value = "";
                        document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "red";
                        flag = false;
                    }

                }
            } else {
                $noCon('#cphMain_txtFromdate').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '') {
                        //  isValid = false;
                        flag = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });

                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });
            }

            if (document.getElementById("<%=hiddenEmployeeIds.ClientID%>").value == "") {

                $noCon("#success-alert-danger").html("Please select atleast one employee to continue..");
                $noCon("#success-alert-danger").fadeTo(2000, 500).slideUp(500, function () {

                });
                $noCon("#success-alert-danger").alert();

                $(window).scrollTop(0);
                return false;
            }

            if (flag == false) {

                $noCon("#success-alert-danger").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#success-alert-danger").fadeTo(2000, 500).slideUp(500, function () {

                });
                $noCon("#success-alert-danger").alert();

                $(window).scrollTop(0);

            }
            return flag;
        }

    </script>
    <script type="text/javascript">
        function RecallAutocompletePartial() {
            BusinessdivVisible('QCK')
            TodateVisible()
            ManTableVisible('QCK');

            $au('#cphMain_ddlBusinessUnit').selectToAutocomplete1Letter();
            $au('#cphMain_ddlNewBussinessunit').selectToAutocomplete1Letter();

            $noCon('#cphMain_txtFromdate').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                timepicker: false
            });


            $noCon('#cphMain_txtTodate').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                timepicker: false
            });
        }
        function RecallAutocomplete(FocusField) {

            BusinessdivVisible('QCK');
            TodateVisible();
            ManTableVisible('QCK');

            $au('#cphMain_ddlBusinessUnit').selectToAutocomplete1Letter();
            $au('#cphMain_ddlNewBussinessunit').selectToAutocomplete1Letter();

            $noCon('#cphMain_txtFromdate').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                timepicker: false
            });


            $noCon('#cphMain_txtTodate').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                timepicker: false
            });

            if (FocusField == "{BU}") {
                $noCon('div#divddlBusinessUnit input.ui-autocomplete-input').focus();
            } else if (FocusField == "{NBU}") {
                $noCon('div#divddlNewBusinessUnit input.ui-autocomplete-input').focus();
            } else if (FocusField == "{DEPT}") {
                $noCon('#cphMain_ddlDepartment').focus();
            } else if (FocusField == "{NDEPT}") {
                $noCon('#cphMain_ddlNewDepartment').focus();
            }
        }
        var $Animate = jQuery.noConflict();
        function BusinessdivVisible(SPEED) {
            if ($('#cphMain_radioBUtransfer').is(':checked')) {
                $('#divBUdatacontainer').css('display', '');
                $('#divManpowerDetails').css('display', 'none');
                if (SPEED == "QCK") {
                    $('#divRelateManpower').css('display', 'none');
                } else {
                    if ($('#divRelateManpower').css('display')== 'block') {
                        $('#divRelateManpower').toggle(function () {
                            $(this).animate({ display: 'none' }, .5);
                        });
                    }
                }

                document.getElementById("<%=hiddenManpowerId.ClientID%>").value = "";
                $('#divddlPaygrade').css('display', 'block');
                $('#divddlnewDepartment').css('display', 'block');
                $('#divddlProject').css('display', 'block');
                $('#divddlNewDivision').css('display', 'block');

                document.getElementById("<%=hiddenPaygradeId.ClientID%>").value = "";
                document.getElementById("<%=hiddenDepartmentId.ClientID%>").value = "";
                document.getElementById("<%=HiddenProjectId.ClientID%>").value = "";
                document.getElementById("<%=hiddenDivIds.ClientID%>").value = "";

            } else {
                ManListView();
                $('#divBUdatacontainer').css('display', 'none');

                if (document.getElementById("<%=hiddenManpowerId.ClientID%>").value != "") {
                    var ManPowId = document.getElementById("<%=hiddenManpowerId.ClientID%>").value;
                    if ($('#cbxManPwr_' + ManPowId).length) {
                        $('#cbxManPwr_' + ManPowId).prop('checked', true);
                        $('#cbxManPwr_' + ManPowId).closest('tr').css('background', '#93c689');
                    }
                }

                if (SPEED == "QCK") {
                    $('#divRelateManpower').css('display', 'block');
                } else {
                    if ($('#divRelateManpower').css('display')== 'none') {
                        $('#divRelateManpower').toggle(function () {
                            $(this).animate({ display: 'block' }, .5);
                        });
                    }
                }

            }
        }
        function TodateVisible() {
            if ($('#cphMain_radioTemporary').is(':checked')) {
                $('#divTodateContainer').css('display', '');
            } else {
                $('#divTodateContainer').css('display', 'none');
            }
        }



        //show messages 
        function AddSuccesMessage() {

            $noCon("#success-alert").html("Employee transfer details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#success-alert").alert();
            return false;
        }

        function UpdateSuccesMessage() {

            $noCon("#success-alert").html("Employee transfer details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#success-alert").alert();
            return false;
        }
        function ConfirmSuccesMessage() {

            $noCon("#success-alert").html("Employee transfer details confirmed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#success-alert").alert();
            return false;
        }
        function labelDivVisible() {

            if ($('#divEmpDetailsContainer').css('display')== 'none') {
                $("#divEmpDetailsContainer").toggle(function () {
                    $(this).animate({ display: "block" }, .5);
                });
            }
        }

        function ManListView() {
            var orgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
            var CorpId = document.getElementById("<%=ddlBusinessUnit.ClientID%>").value;
            if (CorpId != "--SELECT BUSINESS UNIT--") {
                $noCon.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "hcm_Emp_Transfer_Bulk.aspx/ManpowerTableCreator",
                    data: '{strCorpId: "' + CorpId + '",strOrgId: "' + orgId + '"}',
                    dataType: "json",
                    success: function (data) {
                        document.getElementById('divManTableContainer').innerHTML = data.d;
                    }
                });
            }
        }
        function ManTableVisible(SPEED) {

            if (SPEED != "QCK") {
                if ($('#cphMain_ManNo').is(':checked')) {
                    if ($('#divManTableContainer').css('display')== 'block') {
                        $("#divManTableContainer").toggle(function () {
                            $('#divManTableContainer').animate({ display: 'none' }, .5)
                        });
                    }
                    $('#divManpowerDetails').css('display', 'none');
                    //$('#btnManPwrProceed').css('display', 'none');
                    ManCbxUnCheckAll();
                    document.getElementById("<%=hiddenManpowerId.ClientID%>").value = "";
                    $('#divddlPaygrade').css('display', 'block');
                    $('#divddlnewDepartment').css('display', 'block');
                    $('#divddlProject').css('display', 'block');
                    $('#divddlNewDivision').css('display', 'block');

                    document.getElementById("<%=hiddenPaygradeId.ClientID%>").value = "";
                    document.getElementById("<%=hiddenDepartmentId.ClientID%>").value = "";
                    document.getElementById("<%=HiddenProjectId.ClientID%>").value = "";
                    document.getElementById("<%=hiddenDivIds.ClientID%>").value = "";

                } else {
                    if ($('#divManTableContainer').css('display')== 'none') {
                        $("#divManTableContainer").toggle(function () {
                            $('#divManTableContainer').animate({ display: 'block' }, .5)
                            //$('#btnManPwrProceed').css('display', 'block');
                        });
                    }
                }
            } else {
                if ($('#cphMain_ManNo').is(':checked')) {
                    $('#divManTableContainer').css('display', 'none');
                    // $('#btnManPwrProceed').css('display', 'none');
                    $('#divManpowerDetails').css('display', 'none');
                    ManCbxUnCheckAll();
                    document.getElementById("<%=hiddenManpowerId.ClientID%>").value = "";
                } else {

                    $('#divManTableContainer').css('display', 'block');

                    // $('#btnManPwrProceed').css('display', 'block');
                }
            }

        }
        function ManCbxClick(id, ManId) {
            var Remain = document.getElementById('tdremainCount_' + ManId).innerHTML;
            var selected = document.getElementById('lblNumbrofEmp').innerText;
            if (selected == "" || selected == "0") {
                selected = 0;
                $noCon("#WarningAlertManpower").html("Please select atleast one employee to continue..");
                $noCon("#WarningAlertManpower").fadeTo(2000, 500).slideUp(500, function () {

                });
                $noCon("#WarningAlertManpower").alert();
                ManCbxUnCheckAll();
                return false;
            } else {
                if (Remain - selected < 0) {
                    $noCon("#WarningAlertManpower").html("sorry.The selected manpower request does not have sufficient vacancy.");
                    $noCon("#WarningAlertManpower").fadeTo(2000, 500).slideUp(500, function () {

                    });
                    $noCon("#WarningAlertManpower").alert();
                    ManCbxUnCheckAll();
                    if (document.getElementById("<%=hiddenManpowerId.ClientID%>").value != "") {
                        var selectedMan = document.getElementById("<%=hiddenManpowerId.ClientID%>").value;
                       
                        $('#cbxManPwr_' + selectedMan).prop('checked', true);
                        $('#trMan_' + selectedMan).css('background', '#93c689');
                    }
                } else {
                   
                    $('#tableManPower tbody tr td input[type="checkbox"]').each(function () {
                        if (this.id == id) {
                            $(this).prop('checked', true);
                            $(this).closest('tr').css('background', '#93c689');
                        } else {
                            $(this).prop('checked', false);
                            $(this).closest('tr').css('background', '');
                           
                        }

                    });

                    document.getElementById("<%=hiddenManpowerId.ClientID%>").value = ManId;
                    document.getElementById("<%=HiddenManPowerCapacity.ClientID%>").value = Remain;
                    
                    Manpowerproceed();
                }
            }
           // return false;
        }

       
        function EmpCbxClick(Count) {
            var EmpCount = document.getElementById('lblNumbrofEmp').innerText.trim();
            var ManCapacity = document.getElementById("<%=HiddenManPowerCapacity.ClientID%>").value.trim();
            if (EmpCount != "" && ManCapacity != "") {
                if (EmpCount.toString() == ManCapacity.toString()) {
                    $noCon("#success-alert-danger").html("Sorry..The Vacancy in the manpower request exceeds..");
                    $noCon("#success-alert-danger").fadeTo(2000, 500).slideUp(500, function () {

                    });
                    $noCon("#success-alert-danger").alert();

                    $('#Checkbox_' + Count).prop('checked', false);

                    return false;
                }
            }

            var TotalEmpIds = "";
            var count = 0;
            $('#EmployeeTable tbody tr td input[type="checkbox"]').each(function () {
                if ($(this).is(':checked')) {
                    count++;
                    var CbxId = this.id;
                    splitid = CbxId.split('_');
                    var MainCount = splitid[1];
                    var EmployeeId = document.getElementById("tdEmployId_" + MainCount).innerHTML;
                    TotalEmpIds = TotalEmpIds + "," + EmployeeId;

                    $(this).closest('tr').css('background', '#93c689');
                } else {
                    $(this).closest('tr').css('background', '');
                }
            });
            document.getElementById("<%=hiddenEmployeeIds.ClientID%>").value = TotalEmpIds;
            document.getElementById('lblNumbrofEmp').innerText = count;
        }

        function EmpCbxUnCheckAll() {
            $('#EmployeeTable tbody tr td input[type="checkbox"]').each(function () {
                $(this).prop('checked', false);
            });

            document.getElementById("<%=hiddenEmployeeIds.ClientID%>").value = "";
        }

        function ManCbxUnCheckAll() {
            $('#tableManPower tbody tr td input[type="checkbox"]').each(function () {
                $(this).prop('checked', false);
            });

            document.getElementById("<%=hiddenManpowerId.ClientID%>").value = "";
        }
        function Manpowerproceed() {
            if (document.getElementById("<%=hiddenManpowerId.ClientID%>").value != "") {

                var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
                var CorpId = document.getElementById("<%=ddlBusinessUnit.ClientID%>").value;
                var ManpId = document.getElementById("<%=hiddenManpowerId.ClientID%>").value;
                $noCon.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "hcm_Emp_Transfer_Bulk.aspx/ManPowerDetailsFill",
                    data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '",intManpId:"' + ManpId + '"}',
                    dataType: "json",
                    success: function (data) {
                        document.getElementById("<%=lblRefNum.ClientID%>").innerText = data.d[0];
                        document.getElementById("<%=lblDateOfReq.ClientID%>").innerText = data.d[1];
                        document.getElementById("<%=lblNumber.ClientID%>").innerText = data.d[2];
                        document.getElementById("<%=lblDesign.ClientID%>").innerText = data.d[3];
                        document.getElementById("<%=lblDeprtmnt.ClientID%>").innerText = data.d[4];
                        document.getElementById("<%=lblPrjct.ClientID%>").innerText = data.d[5];
                        document.getElementById("<%=lblExprnce.ClientID%>").innerText = data.d[6];
                        document.getElementById("<%=lblPaygrd.ClientID%>").innerText = data.d[7];

                        if (data.d[8] != "") {
                            var Paygradeid = data.d[8];
                            document.getElementById("<%=hiddenPaygradeId.ClientID%>").value = Paygradeid;
                            document.getElementById("<%=ddlnewPaygrade.ClientID%>").value = Paygradeid;
                            $('#divddlNewPayGrade').css('display', 'none');

                        } else {
                            document.getElementById("<%=hiddenPaygradeId.ClientID%>").value = "";
                            document.getElementById("<%=ddlnewPaygrade.ClientID%>").value = "--SELECT PAYGRADE--";
                            $('#divddlNewPayGrade').css('display', 'block');
                        }
                        if (data.d[9] != "") {
                            var DepartMentid = data.d[9];
                            document.getElementById("<%=hiddenDepartmentId.ClientID%>").value = DepartMentid;
                            document.getElementById("<%=ddlNewDepartment.ClientID%>").value = DepartMentid;
                            $('#divddlnewDepartment').css('display', 'none');
                        } else {
                            document.getElementById("<%=hiddenDepartmentId.ClientID%>").value = "";
                            document.getElementById("<%=ddlNewDepartment.ClientID%>").value = "--SELECT DEPARTMENT--";
                            $('#divddlnewDepartment').css('display', 'block');
                        }
                        if (data.d[10] != "") {
                            var Projectid = data.d[10];
                            document.getElementById("<%=HiddenProjectId.ClientID%>").value = Projectid;
                            document.getElementById("<%=ddlproject.ClientID%>").value = Projectid;
                            $('#divddlProject').css('display', 'none');
                        } else {
                            document.getElementById("<%=HiddenProjectId.ClientID%>").value = "";
                            document.getElementById("<%=ddlproject.ClientID%>").value = "--SELECT PROJECT--";
                            $('#divddlProject').css('display', 'block');
                        }
                        if (data.d[11] != "") {
                            var DivisionId = data.d[11];
                            document.getElementById("<%=hiddenDivIds.ClientID%>").value = DivisionId;
                            //document.getElementById("<%=ddlNewDivision.ClientID%>").value = DivisionId;
                            $('#divddlNewDivision').css('display', 'none');
                        } else {
                            document.getElementById("<%=hiddenDivIds.ClientID%>").value = "";
                            document.getElementById("<%=ddlNewDivision.ClientID%>").value = "--SELECT DIVISION--";
                            $('#divddlNewDivision').css('display', 'block');
                        }
                    }
                });


                $('#divManpowerDetails').css('display', 'block');
            } else {
                $noCon("#WarningAlertManpower").fadeTo(2000, 500).slideUp(500, function () {

                });
                $noCon("#WarningAlertManpower").alert();
            }
        }

        function validateSearch() {
       
            var flag = true;

            if ($noCon.trim($noCon('#cphMain_ddlDepartment').val()) == '--SELECT DEPARTMENT--') {
                //  isValid = false;
                flag = false;
                $noCon('#cphMain_ddlDepartment').css({
                    "border": "1px solid red",
                    "background": ""
                });
                $noCon('#cphMain_ddlDepartment').focus();
            }
            else {
                $noCon('#cphMain_ddlDepartment').css({
                    "border": "",
                    "background": ""
                });
            }
            if ($noCon.trim($noCon('#cphMain_ddlBusinessUnit').val()) == '--SELECT BUSINESS UNIT--') {
                //  isValid = false;
                flag = false;
                $noCon('div#divOldddlBusinessUnit input.ui-autocomplete-input').focus();
                $noCon('div#divOldddlBusinessUnit input.ui-autocomplete-input').css({
                    "border": "1px solid red",
                    "background": ""
                });

            }
            else {
                $noCon('div#divOldddlBusinessUnit input.ui-autocomplete-input').css({
                    "border": "",
                    "background": ""
                });
            }
            if (flag == false) {
                $noCon("#success-alert-danger").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#success-alert-danger").fadeTo(2000, 500).slideUp(500, function () {

                });
                $noCon("#success-alert-danger").alert();
            }
            return flag;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenDivIds" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenManpowerId" runat="server" />
    <asp:HiddenField ID="hiddenEmployeeIds" runat="server" />
    <asp:HiddenField ID="HiddenManPowerCapacity" runat="server" />
    <asp:HiddenField ID="hiddenDepartmentId" runat="server" />
    <asp:HiddenField ID="hiddenPaygradeId" runat="server" />
    <asp:HiddenField ID="HiddenProjectId" runat="server" />
    <div id="main" role="main">
        <div id="content">
            <div class="alert alert-success" id="success-alert" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>

            <div class="alert alert-danger" id="success-alert-danger" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>

            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">

                            <header>

                                <label id="lblHeader" class="pageh2" runat="server">Employee Transfer</label>

                            </header>

                            <div id="boarder" class="smart-form" style="float: left; width: 99%;">
                                <div id="divList" class="list" onclick="return ConfirmRedirectList();" runat="server" style="position: fixed; right: 0%; top: 26%; height: 26.5px; z-index: 1;"></div>

                                <div id="searchfield" style="float: left; width: 98%; background: white; padding-left: 1%;">

                                    <div style="width: 100%; float: left; margin-top: 0px" class="formdiv">

                                                <div style="float: left; width: 98%; padding: 10px; border: 1px solid #929292; background-color: #f2f2f2;">
                                                    
                                           <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                    <label style="float: left; width: 100%; font-size: 14px; text-decoration: underline; color: #922929; font-weight: bold;">FROM</label>

                                                    <div style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%;">
                                                            <label class="lblh2" style="float: left; width: 27%;">Business Unit*</label>
                                                            <div id="divOldddlBusinessUnit">
                                                                <label class="select">
                                                                    <asp:DropDownList ID="ddlBusinessUnit" AutoPostBack="true" class="form-control" runat="server" Style="width: 56%; height: 30px" OnSelectedIndexChanged="ddlBusinessUnit_SelectedIndexChanged"></asp:DropDownList>
                                                                </label>
                                                            </div>

                                                        </section>
                                                    </div>
                                                    <div style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 5%;">
                                                            <label class="lblh2" style="float: left; width: 27%;">Department*</label>
                                                            <div id="divOldddlDepartment">
                                                                <label class="select">
                                                                    <asp:DropDownList ID="ddlDepartment" AutoPostBack="true" class="form-control" runat="server" Style="width: 58%" onkeypress="return IsEnter(event);" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList>
                                                                </label>
                                                            </div>
                                                        </section>
                                                    </div>
                                                    <div style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%;">
                                                            <label class="lblh2" style="float: left; width: 27%;">Division</label>
                                                            <div id="divOldddlDivision">
                                                                <label class="select">
                                                                    <asp:DropDownList ID="ddlDivision" class="form-control" runat="server" Style="width: 58%" onkeypress="return IsEnter(event);"></asp:DropDownList>
                                                                </label>
                                                            </div>
                                                        </section>
                                                    </div>
                                                    <div style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 5%;">
                                                            <label class="lblh2" style="float: left; width: 27%;">Paygrade</label>
                                                            <div id="divddlPaygrade">
                                                                <label class="select">
                                                                    <asp:DropDownList ID="ddlPaygrade" class="form-control" runat="server" Style="width: 58%" onkeypress="return IsEnter(event);"></asp:DropDownList>
                                                                </label>
                                                            </div>
                                                        </section>
                                                    </div>
                                                    <div style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%;">
                                                            <label class="lblh2" style="float: left; width: 27%;">Sponsor</label>
                                                            <div id="divddlSpnsor">
                                                                <label class="select">
                                                                    <asp:DropDownList ID="ddlSponsor" class="form-control" runat="server" Style="width: 58%" onkeypress="return IsEnter(event);"></asp:DropDownList>
                                                                </label>
                                                            </div>
                                                        </section>
                                                    </div>
                                                    <div style="width: 50%; float: left;">
                                                        <section style="width: 95%;">
                                                            <div class="inline-group" style="padding-left: 4%; padding-top: 4px; width: 57%; float: left; margin-left: 28%;">
                                                                <label class="radio">
                                                                    <input name="radioCustProv" checked="true" runat="server" type="radio" id="radioCustTypeStaff" onchange="IncrmntConfrmCounter()" /><i></i>Staff</label>
                                                                <label class="radio">
                                                                    <input name="radioCustProv" runat="server" type="radio" id="radioCustTypeWorker" onchange="IncrmntConfrmCounter()" /><i></i>Worker</label>

                                                                <asp:Button ID="btnsearch" runat="server" Style="background-color: #1c74a4; width: 75px; height: 27px; padding: 2px; float: right; margin-left: 7%" class="btn btn-info" Text="Search" OnClientClick="return validateSearch();" OnClick="btnsearch_Click" />
                                                            </div>
                                                        </section>
                                                    </div>
                                                    <div style="float: left; width: 100%;">
                                                        <h2 style="font-size: 15px; color: #b63434; margin: 2px;">Number of employees selected :  </h2>
                                                        <label id="lblNumbrofEmp" style="float: left; font-size: 14px; color: #922929; font-weight: bold; margin-left: 5px;"></label>
                                                    </div>
                                             
                                                    <div style="width: 100%; max-height: 300px; overflow: auto; margin-top: 0px;" class="formdiv">
                                                        <div id="divEmplyeeList" runat="server" style="width: 99%; border: 1px solid #3c8295; float: left;">
                                                            <table id="EmployeeTable" class="tbMan" style="width: 99.8%; float: left;" cellspacing="0" cellpadding="2px">
                                                                <thead>
                                                                    <tr class="ManTableHead">
                                                                        <th class="MHead" style="width: 5%; text-align: center;"></th>
                                                                        <th class="MHead" style="width: 12%; text-align: center; word-wrap: break-word;">Employee Code</th>
                                                                        <th class="MHead" style="width: 17%; text-align: left; word-wrap: break-word;">Employee Name</th>
                                                                        <%--<th class="MHead" style="width: 17%; text-align: left; word-wrap: break-word;">Division</th>--%>
                                                                        <th class="MHead" style="width: 17%; text-align: left; word-wrap: break-word;">Designation</th>
                                                                        <th class="MHead" style="width: 17%; text-align: left; word-wrap: break-word;">Paygrade</th>
                                                                        <th class="MHead" style="width: 15%; text-align: left; word-wrap: break-word;">Sponsor</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="7">
                                                                            <p style="text-align: center; font-family: calibri;">No Data Available</p>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                        </asp:UpdatePanel>
                                                </div>
                                           
                                    </div>

                                    <div style="width: 100%; float: left;margin-top: 10px;" class="formdiv">
                                        <div id="div1" style=" margin-bottom: 8px; float: left; width: 98%; padding: 10px; border: 1px solid #929292; background-color: #f2f2f2;">

                                            <div style="width: 50%; float: left;">
                                                <section style="width: 95%;margin-left: 3%;">
                                                    <label class="lblh2" style="float: left; width: 25%;">Transfer type</label>
                                                    <div class="inline-group" style="background-color: #f5f5f5; padding-left: 1%; padding-top: 3px; width: 58%; float: right; border: 1px solid #04619c; margin-bottom: 1px;margin-right: 13%;">
                                                        <label class="radio" style="font-family: Calibri;padding-left: 24px;">
                                                            <input id="radioIOtransfer" name="RadioType" checked="true" runat="server" onchange="BusinessdivVisible('SLW');" onkeypress="return DisableEnter(event)" type="radio" />
                                                            <i></i>Inter office transfer</label>
                                                        <label class="radio" style="font-family: Calibri;margin-right: 12px;">
                                                            <input id="radioBUtransfer" name="RadioType" runat="server" onchange="BusinessdivVisible('SLW');" onkeypress="return DisableEnter(event)" type="radio" />
                                                            <i></i>Business unit transfer</label>

                                                    </div>
                                                </section>


                                            </div>

                                            <div style="width: 50%; float: left;">

                                                <section style="width: 95%;margin-left:3%">
                                                    <label class="lblh2" style="float: left; width: 27%;">Transfer method</label>
                                                    <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; width: 45%; float: right; border: 1px solid #04619c; margin-bottom: 1px;margin-right: 23%;">

                                                        <label class="radio" style="font-family: Calibri;">
                                                            <input name="radioCustType" id="radioTemporary" checked="true" runat="server" onchange="TodateVisible();" onkeypress="return DisableEnter(event)" type="radio" />
                                                            <i></i>Temporary</label>
                                                        <label class="radio" style="font-family: Calibri;">
                                                            <input name="radioCustType" id="radioPermanent" runat="server" onchange="TodateVisible();" onkeypress="return DisableEnter(event)" type="radio" />
                                                            <i></i>Permanent</label>
                                                    </div>

                                                </section>


                                            </div>
                                        </div>
                                    </div>

                                    <div style="width: 100%; float: left;margin-top: 1px;" class="formdiv">
                                        <div class="alert alert-danger" id="WarningAlertManpower" style="display: none; float: left; width: 98%; height: 17px;">
                                            <button type="button" class="close" data-dismiss="alert">x</button>
                                            <strong>Warning! </strong>
                                            Please select atleast one manpower to continue..
   
                                        </div>
                                        <div id="divRelateManpower" style="display: none; margin-bottom: 8px; float: left; width: 98%; padding: 10px; border: 1px solid #929292; background-color: #f2f2f2;">

                                            <div style="width: 100%; float: left;">
                                                <section style="width: 45%; margin-left: 1.5%; float: left; margin-bottom: 0px;">
                                                    <div class="inline-group">
                                                        <label class="lblh2" style="float: left; width: 40%;">Related to Manpower request</label>
                                                        <div class="inline-group" style="background-color: #f5f5f5; padding-top: 3px; width: 26%; float: left; border: 1px solid #04619c; margin-bottom: 1px; padding-left: 1%; margin-left: 22%">

                                                            <label class="radio" style="font-family: Calibri; margin-right: 25px;">
                                                                <input name="radioRelMan" id="ManNo" checked="true" runat="server" onchange="ManTableVisible('SLW');" onkeypress="return DisableEnter(event)" type="radio" />
                                                                <i></i>NO</label>
                                                            <label class="radio" style="font-family: Calibri; margin-right: 25px;">
                                                                <input name="radioRelMan" id="ManYes" runat="server" onchange="ManTableVisible('SLW');" onkeypress="return DisableEnter(event)" type="radio" />
                                                                <i></i>YES</label>
                                                        </div>
                                                    </div>

                                                </section>
                                                <section style="width: 45%; margin-left: 1.5%; float: left; margin-bottom: 0px;">
                                                    <%--<input id="btnManPwrProceed" type="button" value="Proceed" style="display: none; width: 15%; background: #3c8295; color: white; float: right; height: 25px;" onclick="Manpowerproceed();" />--%>
                                                </section>
                                                <div id="divManpowerContainer">

                                                    <div id="divManTableContainer" style="width: 96%; margin-left: 2%; display: block; max-height: 300px; overflow: auto;">
                                                    </div>



                                                </div>


                                            </div>
                                        </div>

                                        <div class="alert alert-danger" id="Warningalert" style="display: none; float: left; width: 98%; height: 17px;">
                                            <button type="button" class="close" data-dismiss="alert">x</button>
                                            <strong>Warning! </strong>
                                            To date Should be Greater than From date
   
                                        </div>


                                        <div style="float: left; width: 98%; padding: 10px; border: 1px solid #929292; background-color: #f2f2f2;">
                                            <label style="float: left; width: 100%; font-size: 14px; text-decoration: underline; color: #922929; font-weight: bold;">To</label>
                                            <div id="divManpowerDetails" style="display: none; float: left; width: 100%; border: 1px solid #929292; background-color: #c9c9c9; margin-bottom: 20px;">

                                                <div style="width: 50%; float: left;">
                                                    <section style="width: 95%; margin-left: 3%;">
                                                        <label class="lblh2" style="float: left; width: 27%; color: #511a1a;">Ref#</label>
                                                        <asp:Label ID="lblRefNum" class="lblTopR" runat="server"></asp:Label>
                                                    </section>
                                                </div>
                                                <div style="width: 50%; float: left;">
                                                    <section style="width: 95%; margin-left: 3%;">
                                                        <label class="lblh2" style="float: left; width: 27%; color: #511a1a;">Date Of Request</label>
                                                        <asp:Label ID="lblDateOfReq" class="lblTopR" runat="server"></asp:Label>
                                                    </section>
                                                </div>
                                                <div style="width: 50%; float: left;">
                                                    <section style="width: 95%; margin-left: 3%;">
                                                        <label class="lblh2" style="float: left; width: 27%; color: #511a1a;">No.of Resources</label>
                                                        <asp:Label ID="lblNumber" class="lblTopR" runat="server"></asp:Label>
                                                    </section>
                                                </div>
                                                <div style="width: 50%; float: left;">
                                                    <section style="width: 95%; margin-left: 3%;">
                                                        <label class="lblh2" style="float: left; width: 27%; color: #511a1a;">Designation</label>
                                                        <asp:Label ID="lblDesign" class="lblTopR" runat="server"></asp:Label>
                                                    </section>
                                                </div>

                                                <div style="width: 50%; float: left;">
                                                    <section style="width: 95%; margin-left: 3%;">
                                                        <label class="lblh2" style="float: left; width: 27%; color: #511a1a;">Department</label>
                                                        <asp:Label ID="lblDeprtmnt" class="lblTopR" runat="server"></asp:Label>
                                                    </section>
                                                </div>
                                                <div style="width: 50%; float: left;">
                                                    <section style="width: 95%; margin-left: 3%;">
                                                        <label class="lblh2" style="float: left; width: 27%; color: #511a1a;">Project</label>
                                                        <asp:Label ID="lblPrjct" class="lblTopR" runat="server"></asp:Label>
                                                    </section>
                                                </div>
                                                <div style="width: 50%; float: left;">
                                                    <section style="width: 95%; margin-left: 3%;">
                                                        <label class="lblh2" style="float: left; width: 27%; color: #511a1a;">Experience</label>
                                                        <asp:Label ID="lblExprnce" class="lblTopR" runat="server"></asp:Label>
                                                    </section>
                                                </div>
                                                <div style="width: 50%; float: left;">
                                                    <section style="width: 95%; margin-left: 3%;">
                                                        <label class="lblh2" style="float: left; width: 27%; color: #511a1a;">Pay Grade</label>
                                                        <asp:Label ID="lblPaygrd" class="lblTopR" runat="server"></asp:Label>
                                                    </section>
                                                </div>
                                            </div>

                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>

                                                    <div style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%; float: left;">
                                                            <label class="lblh2" style="float: left; width: 27%;">From Date*</label>

                                                            <label class="input" style="float: left; width: 60%;">
                                                                <input id="txtFromdate" runat="server" type="text" onkeypress="return DisableEnter(event)" onchange="DateChk('cphMain_txtFromdate')" class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="50" />
                                                                <script>

                                                                    $noCon('#cphMain_txtFromdate').datepicker({
                                                                        autoclose: true,
                                                                        format: 'dd-mm-yyyy',

                                                                        timepicker: false
                                                                    });

                                                                </script>
                                                            </label>
                                                        </section>
                                                    </div>
                                                    <div id="divTodateContainer" style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%; float: left;">
                                                            <label class="lblh2" style="float: left; width: 27%;">To Date*</label>
                                                            <label class="input" style="float: left; width: 60%;">
                                                                <input id="txtTodate" runat="server" type="text" onkeypress="return DisableEnter(event)" onchange="DateChk('cphMain_txtTodate')" class="Tabletxt form-control" placeholder="dd-mm-yyyy" maxlength="50" />
                                                                <script>

                                                                    $noCon('#cphMain_txtTodate').datepicker({
                                                                        autoclose: true,
                                                                        format: 'dd-mm-yyyy',

                                                                        timepicker: false
                                                                    });

                                                                </script>
                                                            </label>
                                                        </section>
                                                    </div>
                                                    <div id="divBUdatacontainer" style="width: 100%; float: left;">
                                                        <div style="width: 50%; float: left;">
                                                            <section style="width: 95%; margin-left: 3%;">
                                                                <label class="lblh2" style="float: left; width: 27%;">Business Unit*</label>
                                                                <div id="divddlNewBusinessUnit">
                                                                    <label class="select">
                                                                        <asp:DropDownList ID="ddlNewBussinessunit" AutoPostBack="true" class="form-control" runat="server" Style="width: 58%" onchange="IncrmntConfrmCounter();" OnSelectedIndexChanged="ddlNewBussinessunit_SelectedIndexChanged" onkeypress="return DisableEnter(event)"></asp:DropDownList>
                                                                    </label>
                                                                </div>

                                                            </section>
                                                        </div>

                                                        <div style="width: 50%; float: left;">
                                                            <section style="width: 95%; margin-left: 3%; height: 32px;">
                                                                <label class="lblh2" style="float: left; width: 27%;">New employee ID*</label>
                                                                <div class="inline-group">
                                                                    <label class="checkbox">
                                                                        <input id="cbxNewEmployeeId" runat="server" checked="checked" type="checkbox" />
                                                                        <i></i>YES</label>
                                                                </div>
                                                            </section>
                                                        </div>
                                                    </div>



                                                    <div id="divddlnewDepartment" style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%;">
                                                            <label class="lblh2" style="float: left; width: 27%;">Department*</label>
                                                            <div>
                                                                <label class="select">
                                                                    <asp:DropDownList ID="ddlNewDepartment" AutoPostBack="true" class="form-control" runat="server" onchange="IncrmntConfrmCounter();" OnSelectedIndexChanged="ddlNewDepartment_SelectedIndexChanged" Style="width: 60%" onkeypress="return DisableEnter(event)"></asp:DropDownList>

                                                                </label>
                                                            </div>
                                                        </section>
                                                    </div>
                                                    <div id="divddlNewDivision" style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%; height: 32px">
                                                            <label class="lblh2" style="float: left; width: 27%;">Division</label>
                                                            <div>
                                                                <label class="select">
                                                                    <asp:DropDownList ID="ddlNewDivision" class="form-control select2" runat="server" onchange="IncrmntConfrmCounter();" Style="width: 60%;" onkeypress="return DisableEnter(event)"></asp:DropDownList>

                                                                </label>
                                                            </div>
                                                        </section>
                                                    </div>
                                                    <div id="divddlNewPayGrade" style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%;">
                                                            <label class="lblh2" style="float: left; width: 27%;">PayGrade*</label>
                                                            <div>
                                                                <label class="select">
                                                                    <asp:DropDownList ID="ddlnewPaygrade" class="form-control" runat="server" onchange="IncrmntConfrmCounter();" Style="width: 60%" onkeypress="return DisableEnter(event)"></asp:DropDownList>

                                                                </label>
                                                            </div>
                                                        </section>
                                                    </div>

                                                    <div style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%;">
                                                            <label class="lblh2" style="float: left; width: 27%;">Reporting officer*</label>
                                                            <div id="divddlreporter">
                                                                <label class="select">
                                                                    <asp:DropDownList ID="ddlreporter" class="form-control" runat="server" onchange="IncrmntConfrmCounter();" Style="width: 60%" onkeypress="return DisableEnter(event)"></asp:DropDownList>

                                                                </label>
                                                            </div>
                                                        </section>
                                                    </div>
                                                    <div style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%;">
                                                            <label class="lblh2" style="float: left; width: 27%;">Sponsor</label>
                                                            <div id="divddlNewSponsor">
                                                                <label class="select">
                                                                    <asp:DropDownList ID="ddlNewSponsor" class="form-control" runat="server" onchange="IncrmntConfrmCounter();" Style="width: 60%" onkeypress="return DisableEnter(event)"></asp:DropDownList>

                                                                </label>
                                                            </div>
                                                        </section>
                                                    </div>
                                                    <div id="divddlProject" style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%;">
                                                            <label class="lblh2" style="float: left; width: 27%;">Project</label>
                                                            <div>
                                                                <label class="select">
                                                                    <asp:DropDownList ID="ddlproject" class="form-control" runat="server" onchange="IncrmntConfrmCounter();" Style="width: 60%" onkeypress="return DisableEnter(event)"></asp:DropDownList>

                                                                </label>
                                                            </div>
                                                        </section>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                        <footer style="background: white; border-color: white; float: right;">
                                            <asp:Button ID="btnSave" runat="server" Style="float: left;" class="btn btn-primary" Text="Save" OnClientClick="return ValidateTransfer();" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnSaveClose" runat="server" Style="float: left;" class="btn btn-primary" Text="Save & Close" OnClientClick="return ValidateTransfer();" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnConfirm" runat="server" Style="float: left;" class="btn btn-primary" Text="Confirm" OnClientClick="return ConfirmAlert();" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnUpdate" runat="server" Style="float: left;" class="btn btn-primary" Text="Update" OnClientClick="return ValidateTransfer();" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnUpdateClose" runat="server" Style="float: left;" class="btn btn-primary" Text="Update & Close" OnClientClick="return ValidateTransfer();" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnCancel" runat="server" Style="float: left;" class="btn btn-primary" Text="Cancel" OnClientClick="return ConfirmCancel();" />
                                        </footer>
                                    </div>


                                </div>
                            </div>
                        </div>
                    </article>
                </div>
            </section>
        </div>
    </div>
    <style>
        .lblh2 {
            color: #445722;
        }

        .lblTopL {
            width: 27%;
            font-family: Calibri;
            font-size: 15px;
            text-align: left;
            color: #6d7560;
            padding: 0;
            margin: 6px 0 6px;
            line-height: 1;
            font-weight: normal;
            float: right;
            width: 71%;
        }

        .lblTopR {
            width: 27%;
            font-family: Calibri;
            font-size: 15px;
            text-align: left;
            color: #6d7560;
            padding: 0;
            margin: 6px 0 6px;
            line-height: 1;
            font-weight: normal;
            float: right;
            width: 71%;
        }

        .ManTableHead {
            width: 100%;
            border: 1px solid #fff;
            background: #3c8295;
            color: #fff;
            font-size: 13px;
            text-align: left;
            height: 30px;
        }

        .MHead {
            padding: 0 8px 0 8px;
            border-right: 1px solid #b5bca9;
            font-family: Calibri;
            font-weight: bold;
            font-size: 15px;
        }

        .tbMan > tbody > tr:nth-child(2n+1) {
            height: 30px;
            background: #d5d5d5;
            font-size: 14px;
            color: black;
        }

        .tbMan > tbody > tr:nth-child(2n) {
            height: 30px;
            font-size: 14px;
            background: #ededed;
            color: #5c5c5e;
        }

        .tbMan tbody td {
            padding-top: 0px;
            padding-bottom: 0px;
            padding-left: 1%;
            padding-right: 1%;
            border-right: 1px solid white;
        }
    </style>
    <style>
        .select2-container--default .select2-selection--multiple .select2-selection__choice {
            background-color: #a5a5a5;
            border-color: #8d8d8d;
            padding: 1px 5px;
            color: #fff;
            font-size: 14px;
            margin: 2px;
            max-width: 260px;
        }

        .select2-container--default .select2-selection--multiple .select2-selection__choice__remove {
            color: #fff;
            cursor: pointer;
            display: inline-block;
            font-weight: bold;
            margin-right: 5px;
        }

        .select2-container--default.select2-container--focus .select2-selection--multiple {
            border: solid #aeaeae 1px;
            outline: 0;
        }

        .select2-results__option[aria-selected] {
            cursor: pointer;
            font-size: small;
            font-family: calibri;
        }
    </style>

    <script src="/js/HCM/Common.js"></script>
    <script>


        function ConfirmRedirectList() {

            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "hcm_Emp_Transfer_List.aspx";
                    } else {
                    }
                });
            } else {
                window.location.href = "hcm_Emp_Transfer_List.aspx";
            }
            return false;
        }


        function ConfirmAlert() {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm this entry?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        return true;
                    } else {
                        return false;
                    }
                });
        }

        function ConfirmCancel() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to cancel this entry?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "hcm_Emp_Transfer_Single.aspx";
                    } else {
                    }
                });
            } else {
                window.location.href = "hcm_Emp_Transfer_Single.aspx";
            }
            return false;
        }
    </script>
</asp:Content>

