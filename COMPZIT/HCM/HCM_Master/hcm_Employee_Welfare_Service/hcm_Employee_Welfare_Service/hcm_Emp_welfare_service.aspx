<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Emp_welfare_service.aspx.cs" Inherits="HCM_HCM_Master_hcm_Employee_Welfare_Service_hcm_Employee_Welfare_Service_hcm_Emp_welfare_service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
      <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />

    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>
        <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
    <style>
        td, th {
    padding: 0px;
    padding-right: 1%;
}
.font-sty {
    font-size:17px;
    color:#696969;
	font-weight: 400;
}
.button_sty {
    font-family: Calibri;
    font-size: 14px;
    color: #fff;
    padding:8px 24px 7px;
    margin: 0;
    line-height: 1;
    font-weight: normal;
    float: left;
    background: #9ba48b;
    border: none;
    border-radius: 2px;
    cursor: pointer;
    text-transform: uppercase;
	margin-left: 30px;
	    margin-top: 10px;
}
.button_sty:hover
{background:#aab39a;color: #fff;}
        .btn {
            border: 2.3px solid transparent;
            font-size: 14px;
            line-height: 1.5;
            font-family: calibri;
            padding: 7px 12px;
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
            font-family: Calibri;
        }

        .select2-container--default .select2-selection--multiple .select2-selection__choice__remove {
            color: #fff;
            cursor: pointer;
            display: inline-grid;
            font-weight: bold;
            margin-right: 0px;
        }
        .select2-selection__choice__remove {
    font-family: FontAwesome;
    font-size: 0;
    font-style: normal;
    font-weight: 400;
    line-height: 1;
    margin: 0;
    margin-right: 0px;
    min-height: 20px;
    min-width: 21px;
    position: inherit;
    text-decoration: none !important;
}
        .select2-container-multi .select2-search-choice-close, .select2-selection__choice__remove {
    display: block;
    top: 0;
    right: 0;
    padding: 3px 4px 3px 0px;
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
            .select2-search__field {
            font-family: Calibri;

        }
        .select2-dropdown {
            z-index: 10051;
        }
    </style>
        <script>
            var $noCon1 = jQuery.noConflict();
            $noCon1(window).load(function () {

                localStorage.clear();

                var EditVal = document.getElementById("<%=HiddenEdit.ClientID%>").value;
                var ViewVal = document.getElementById("<%=HiddenView.ClientID%>").value;
                if (EditVal != "") {
                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = EditVal.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');
                    var json = $noCon.parseJSON(res3);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            if (json[key].WELFAREID != "") {

                                EditListRows(json[key].QUANTITY, json[key].UNIT, json[key].MANDATORY, json[key].CURRENCY, json[key].FREQUENCY, json[key].FROMDATE, json[key].TODATE, json[key].WELFARESUB_ID, json[key].TRANSACTION, json[key].DEPTCOUNT, json[key].DSGNCOUNT, json[key].DIVCOUNT, json[key].EMPCOUNT);
                            }
                        }
                    }
                }
                else if (ViewVal != "") {
                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = ViewVal.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');
                    var json = $noCon.parseJSON(res3);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            if (json[key].WELFAREID != "") {

                                ViewListRows(json[key].QUANTITY, json[key].UNIT, json[key].MANDATORY, json[key].CURRENCY, json[key].FREQUENCY, json[key].FROMDATE, json[key].TODATE, json[key].WELFARESUB_ID, json[key].TRANSACTION, json[key].DEPTCOUNT, json[key].DSGNCOUNT, json[key].DIVCOUNT, json[key].EMPCOUNT);
                            }
                        }
                    }
                    document.getElementById("cphMain_cbxAllDept").disabled = true;
                    document.getElementById("cphMain_cbxAllDiv").disabled = true;
                    document.getElementById("cphMain_cbxDsgn").disabled = true;
                    document.getElementById("cphMain_cbxAllEmp").disabled = true;
                    document.getElementById("cphMain_cbxStatus").disabled = true;

                }
                else {
                }

                if (ViewVal == "" && EditVal == "") {
                    addMoreRows();
                }

                document.getElementById("cphMain_ddlCategory").focus();


            });

            $noCon = jQuery.noConflict();
            $noCon2 = jQuery.noConflict();
            $noCon(function () {
                $noCon2(".select2").select2();
            });
    </script>
    <script type="text/javascript" language="javascript">
        // for not allowing <> tags
        function isTagDes(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return true;
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
        // for not allowing enter
        function DisableEnter(evt) {
            //  var b = new Date(); alert(b);

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        function controlTab(obj, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 9) {
                document.getElementById(obj).focus();
                return false;
            }

            else {
                return true;
            }
        }

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            // var txtPerVal = document.getElementById(textboxid).value;
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
                return false;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
                // . period and numpad . period
            else if (keyCodes == 190 || keyCodes == 110) {
                var ret = true;
                return ret;

            }
            else if (keyCodes >= 65 && keyCodes <= 73) {
                ret = false;
            }
            else if (keyCodes == 78) {
                ret = false;
            }
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    ret = false;
                }
                return ret;
            }
        }
        function trim(value) {
            return value.replace(/^\s+|\s+$/g, "");
        }
        var $noconfli = jQuery.noConflict();

        var $noCon = jQuery.noConflict();
        function ServiceValidate() {
            var rownumber = RowNum;
            ddlDeptHaveValue = $noCon2('#cphMain_ddlDepartment').val();
            ddlDivisionHaveValue = $noCon2('#cphMain_ddlDivision').val();
            ddlEmpHaveValue = $noCon2('#cphMain_ddlEmployee').val();
            ddlDsgnHaveValue = $noCon2('#cphMain_ddlDesignation').val();

            var ret = true;
            if (document.getElementById("cphMain_ddlCategory").value == "-- SELECT CATEGORY --") {
                document.getElementById("cphMain_ddlCategory").style.borderColor = "Red";
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                $noCon1(window).scrollTop(0);
                ret = false;
            }
            else {
                document.getElementById("cphMain_ddlCategory").style.borderColor = "";
            }
            var service = trim(document.getElementById("cphMain_txtServiceName").value);
            //        var animalName = trim(nameInput.value)
            if (service == "" || service == null) {
                document.getElementById("cphMain_txtServiceName").style.borderColor = "Red";
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                $noCon1(window).scrollTop(0);
                ret = false;
            }
            else {
                document.getElementById("cphMain_txtServiceName").style.borderColor = "";
            }
            if ((document.getElementById("cphMain_cbxAllDept").checked == false) && (document.getElementById("cphMain_cbxAllDiv").checked == false) && (document.getElementById("cphMain_cbxDsgn").checked == false) && (document.getElementById("cphMain_cbxAllEmp").checked == false) && ddlDeptHaveValue == null && ddlDivisionHaveValue == null && ddlDsgnHaveValue == null && ddlEmpHaveValue == null) {

                document.getElementById("cphMain_divAvailable").style.borderColor = "Red";

                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                $noCon1(window).scrollTop(0);
                ret = false;
                // alert("out of if");
            }
            var table = document.getElementById("TableaddedRows");
            for (var x = 1; x <= RowNum; x++) {
                var AddButton = $noconfli("#btnadd" + x);
                if (AddButton.length) {
                    document.getElementById("ddlCurrency" + x).style.borderColor = "";
                    document.getElementById("txtQntity" + x).style.borderColor = "";
                    document.getElementById("ddlFrequency" + x).style.borderColor = "";
                    document.getElementById("txtFromDate" + x).style.borderColor = "";
                    document.getElementById("txtToDate" + x).style.borderColor = "";
                    document.getElementById("ddlUnit" + x).style.borderColor = "";

                    var FromDt = document.getElementById("txtFromDate" + x).value;
                    if (FromDt == "") {
                        document.getElementById("txtFromDate" + x).style.borderColor = "Red";
                        // $noCon("#txtFromDate" + x).select();
                        ret = false;
                    } var ToDate = document.getElementById("txtToDate" + x).value;
                    if (ToDate == "") {
                        document.getElementById("txtToDate" + x).style.borderColor = "Red";
                        //  $noCon("#txtToDate" + x).select();
                        ret = false;
                    }

                    var sharePer = document.getElementById("txtQntity" + x).value;
                    if (sharePer == "") {
                        document.getElementById("txtQntity" + x).style.borderColor = "Red";
                        document.getElementById("txtQntity" + x).focus();
                        $noCon("#txtQntity" + x).select();
                        ret = false;
                    }
                    var documentNo = document.getElementById("ddlFrequency" + x).value;
                    if (documentNo == "--SELECT FREQUENCY--") {
                        document.getElementById("ddlFrequency" + x).style.borderColor = "Red";
                        document.getElementById("ddlFrequency" + x).focus();
                        $noCon("#ddlFrequency" + x).select();
                        ret = false;
                    }
                    var unit = document.getElementById("ddlUnit" + x).value;

                    if (unit == "" || unit == "--SELECT UNIT--") {
                        document.getElementById("ddlUnit" + x).style.borderColor = "red";
                        document.getElementById("ddlUnit" + x).focus();
                        $noCon("#ddlUnit" + x).select();
                        ret = false;
                    }
                    else {
                        document.getElementById("ddlUnit" + x).style.borderColor = "";
                        if (unit == "1") {
                            var currency = document.getElementById("ddlCurrency" + x).value;
                            if (currency == "--SELECT CURRENCY--") {
                                document.getElementById("ddlCurrency" + x).style.borderColor = "red";
                                document.getElementById("ddlCurrency" + x).focus();
                                $noCon("#ddlCurrency" + x).select();
                                ret = false;
                            }
                        }
                    }
                }
            }
            if (ret == true)
                var LimitValoidate = LimitTableCheck();
            if (LimitValoidate == true) {
                if (CheckDate(rownumber) == true) {
                    return true;
                    // document.getElementById("txtFromDate" + Rownum).style.borderColor = "";
                }
                else {

                    return false;
                }
            }
            else {
                return false;
            }
        }
        function LimitTableCheck() {
            selected();

            var ret = true;
            var table = document.getElementById("TableaddedRows");
            for (var x = 1; x <= RowNum; x++) {
                var AddButton = $noconfli("#btnadd" + x);
                if (AddButton.length) {
                    document.getElementById("ddlCurrency" + x).style.borderColor = "";
                    document.getElementById("txtQntity" + x).style.borderColor = "";
                    document.getElementById("ddlFrequency" + x).style.borderColor = "";
                    document.getElementById("txtFromDate" + x).style.borderColor = "";
                    document.getElementById("txtToDate" + x).style.borderColor = "";
                    document.getElementById("ddlUnit" + x).style.borderColor = "";

                    var FromDt = document.getElementById("txtFromDate" + x).value;
                    if (FromDt == "") {
                        document.getElementById("txtFromDate" + x).style.borderColor = "Red";
                        // $noCon("#txtFromDate" + x).select();
                        ret = false;
                    } var ToDate = document.getElementById("txtToDate" + x).value;
                    if (ToDate == "") {
                        document.getElementById("txtToDate" + x).style.borderColor = "Red";
                        //  $noCon("#txtToDate" + x).select();
                        ret = false;
                    }

                    var sharePer = document.getElementById("txtQntity" + x).value;
                    if (sharePer == "") {
                        document.getElementById("txtQntity" + x).style.borderColor = "Red";
                        document.getElementById("txtQntity" + x).focus();
                        $noCon("#txtQntity" + x).select();
                        ret = false;
                    }
                    var documentNo = document.getElementById("ddlFrequency" + x).value;
                    if (documentNo == "--SELECT FREQUENCY--") {
                        document.getElementById("ddlFrequency" + x).style.borderColor = "Red";
                        document.getElementById("ddlFrequency" + x).focus();
                        $noCon("#ddlFrequency" + x).select();
                        ret = false;
                    }
                    var unit = document.getElementById("ddlUnit" + x).value;

                    if (unit == "" || unit == "--SELECT UNIT--") {
                        document.getElementById("ddlUnit" + x).style.borderColor = "red";
                        document.getElementById("ddlUnit" + x).focus();
                        $noCon("#ddlUnit" + x).select();
                        ret = false;
                    }
                    else {
                        document.getElementById("ddlUnit" + x).style.borderColor = "";
                        if (unit == "1") {
                            var currency = document.getElementById("ddlCurrency" + x).value;
                            if (currency == "--SELECT CURRENCY--") {
                                document.getElementById("ddlCurrency" + x).style.borderColor = "red";
                                document.getElementById("ddlCurrency" + x).focus();
                                $noCon("#ddlCurrency" + x).select();
                                ret = false;
                            }
                        }
                    }
                }
            }
            if (ret == true) {
                var tbClientTotalValues = '';
                tbClientTotalValues = [];
                var cbGatePassStatus;
                var curncy = "0";
                var fromDate = "";
                var todate = "0";
                var table = document.getElementById("TableaddedRows");
                for (var i = 1; i <= RowNum; i++) {
                    var AddButton = $noconfli("#ddlUnit" + i);
                    if (AddButton.length) {
                        var qty = document.getElementById("txtQntity" + i).value;
                        var unit = document.getElementById("ddlUnit" + i).value;
                        //   alert(unit);
                        var frq = document.getElementById("ddlFrequency" + i).value;
                        if (document.getElementById("ddlCurrency" + i).value != "--SELECT CURRENCY--")
                            curncy = document.getElementById("ddlCurrency" + i).value;
                        else
                            curncy = 0;
                        if (document.getElementById("cbDefault" + i).checked == true)
                            cbGatePassStatus = 1;
                        else
                            cbGatePassStatus = 0;

                        //  fromDate = document.getElementById("txtFromDate" + i).value;
                        fromDate = document.getElementById("txtFromDate" + i).value;

                        if (document.getElementById("txtToDate" + i).value != "")
                            todate = document.getElementById("txtToDate" + i).value;

                        var detailId = document.getElementById("tdDtlId" + i).innerHTML;
                        var evt = document.getElementById("tdEvt" + i).innerHTML;
                        // alert(evt);
                        var client = JSON.stringify({
                            ROWID: "" + i + "",
                            QUANTITY: "" + qty + "",
                            MADATORY: "" + cbGatePassStatus + "",
                            UNIT: "" + unit + "",
                            CURRENCY: "" + curncy + "",
                            FREQUENCY: "" + frq + "",
                            FROMDATE: "" + fromDate + "",
                            TODATE: "" + todate + "",
                            EVTACTION: "" + evt + "",
                            DTLID: "" + detailId + "",
                        });
                        tbClientTotalValues.push(client);
                    }
                }
                document.getElementById("<%=HiddenAdd.ClientID%>").value = JSON.stringify(tbClientTotalValues);
            }
            return ret;
        }

        function SuccessConfirmation() {
            $noCon("#success-alert").html("Welfare service details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
            $noCon1(window).scrollTop(0);
            return false;
        }

        function SuccessUpdation() {
            $noCon("#success-alert").html("Welfare service details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
            $noCon1(window).scrollTop(0);
            return false;
        }
        function SuccessCancel() {
            $noCon("#success-alert").html("Welfare service details canceled successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
            $noCon1(window).scrollTop(0);
            return false;
        }
        function RemoveTag() {
            var SearchWithoutReplace = document.getElementById("<%=txtServiceName.ClientID%>").value;
            var replaceText1 = SearchWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtServiceName.ClientID%>").value = replaceText2;

                var SearchWithoutReplace = document.getElementById("<%=txtServiceName.ClientID%>").value;
            var replaceText1 = SearchWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtServiceName.ClientID%>").value = replaceText2;
            }
            function RemoveDescTag() {
                var SearchWithoutReplace = document.getElementById("<%=txtServiceDesc.ClientID%>").value;
                var replaceText1 = SearchWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById("<%=txtServiceDesc.ClientID%>").value = replaceText2;

                       var SearchWithoutReplace = document.getElementById("<%=txtServiceDesc.ClientID%>").value;
                var replaceText1 = SearchWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById("<%=txtServiceDesc.ClientID%>").value = replaceText2;
                   }
                   function textCounter(field, maxlimit) {
                       RemoveTag();
                       RemoveDescTag();
                       if (field.value.length > maxlimit) {
                           field.value = field.value.substring(0, maxlimit);
                       } else {
                           isTag(event);
                       }
                   }
                   function isTag(evt) {
                       IncrmntConfrmCounter();
                       evt = (evt) ? evt : window.event;
                       var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                       if (keyCodes == 13) {
                           return false;
                       }
                       var charCode = (evt.which) ? evt.which : evt.keyCode;
                       var ret = true;
                       if (charCode == 60 || charCode == 62) {
                           ret = false;
                       }
                       return ret;
                   }
                   function selected() {
                       var ddldesignationvalues;
                       var ddlPaygradevalues;
                       var ddlexpvalues;
                       var sel = "";
                       //  alert($noCon2('#cphMain_ddlmodeSearch').val());

                       ddldesignationvalues = $noCon2('#cphMain_ddlDesignation').val();

                       ddlDeptvalues = $noCon2('#cphMain_ddlDepartment').val();
                       ddlDivionvalues = $noCon2('#cphMain_ddlDivision').val();
                       ddlEmpvalues = $noCon2('#cphMain_ddlEmployee').val();
                       $noCon2("#cphMain_ddlDesignation option:selected").each(function () {
                           var $noCon2this = $noCon2(this);
                           if ($noCon2this.length) {
                               var selText = $noCon2this.text();
                               sel = sel + selText + ",";

                               document.getElementById("<%=HiddenselectedDesigntext.ClientID%>").value = sel;
                 }
             });
             $noCon2("#cphMain_ddlDepartment option:selected").each(function () {
                 var $noCon2this = $noCon2(this);
                 if ($noCon2this.length) {
                     var selText = $noCon2this.text();
                     sel = sel + selText + ",";

                     document.getElementById("<%=HiddenselectedDepttext.ClientID%>").value = sel
                }
            });
            $noCon2("#cphMain_ddlDivision option:selected").each(function () {
                var $noCon2this = $noCon2(this);
                if ($noCon2this.length) {
                    var selText = $noCon2this.text();
                    sel = sel + selText + ",";


                    ;
                    document.getElementById("<%=HiddenselectedDivisionetext.ClientID%>").value = sel;
                }
            });
            $noCon2("#cphMain_ddlEmployee option:selected").each(function () {
                var $noCon2this = $noCon2(this);
                if ($noCon2this.length) {
                    var selText = $noCon2this.text();
                    sel = sel + selText + ",";


                    ;
                    document.getElementById("<%=hiddenselectedEmployeetext.ClientID%>").value = sel;
                }
            });
            document.getElementById("<%=hiddenselectedDesignlist.ClientID%>").value = ddldesignationvalues;
             document.getElementById("<%=HiddenDeptList.ClientID%>").value = ddlDeptvalues;
             document.getElementById("<%=HiddenDivisionList.ClientID%>").value = ddlDivionvalues;
             document.getElementById("<%=HiddenEmpList.ClientID%>").value = ddlEmpvalues;
             return true;
         }

    </script> 
  

      <script>
          var $p = jQuery.noConflict();
          $p(document).ready(function () {
              if (document.getElementById("<%=cbxAllDept.ClientID%>").checked == true) {
                  document.getElementById('cphMain_ddlDepartment').value = null;
                  document.getElementById("cphMain_ddlDepartment").disabled = true;
              }
              if (document.getElementById("<%=cbxAllDiv.ClientID%>").checked == true) {

                  document.getElementById('cphMain_ddlDivision').value = null;
                  document.getElementById("cphMain_ddlDivision").disabled = true;
              }
              if (document.getElementById("<%=cbxAllEmp.ClientID%>").checked == true) {
                  document.getElementById('cphMain_ddlEmployee').value = null;
                  document.getElementById("cphMain_ddlEmployee").disabled = true;
              }
              if (document.getElementById("<%=cbxDsgn.ClientID%>").checked == true) {
                  document.getElementById('cphMain_ddlDesignation').value = null;
                  document.getElementById("cphMain_ddlDesignation").disabled = true;
              }


              var data = document.getElementById("<%=hiddenselectedDesignlist.ClientID%>").value;
              //  alert(data);
              if (data !== "") {
                  var totalString = data;
                  eachString = totalString.split(',');
                  var newVar = new Array();
                  for (count = 0; count < eachString.length; count++) {
                      if (eachString[count] != "") {
                          newVar.push(eachString[count]);
                      }
                  }

                  $p('#cphMain_ddlDesignation').val(newVar);
                  $p("#cphMain_ddlDesignation").trigger("change");
              }


              var data = document.getElementById("<%=HiddenDeptList.ClientID%>").value;
              //alert(data);
              if (data !== "") {
                  var totalString = data;
                  eachString = totalString.split(',');
                  var newVar = new Array();
                  for (count = 0; count < eachString.length; count++) {
                      if (eachString[count] != "") {
                          newVar.push(eachString[count]);

                      }
                  }
                  $p('#cphMain_ddlDepartment').val(newVar);
                  $p("#cphMain_ddlDepartment").trigger("change");

              }
              var data = document.getElementById("<%=HiddenDivisionList.ClientID%>").value;
              //alert(data);
            if (data !== "") {
                var totalString = data;
                eachString = totalString.split(',');
                var newVar = new Array();
                for (count = 0; count < eachString.length; count++) {
                    if (eachString[count] != "") {
                        newVar.push(eachString[count]);
                    }
                }
                $p('#cphMain_ddlDivision').val(newVar);
                $p("#cphMain_ddlDivision").trigger("change");
            }
            var data = document.getElementById("<%=HiddenEmpList.ClientID%>").value;
              //alert(data);
            if (data !== "") {
                var totalString = data;
                eachString = totalString.split(',');
                var newVar = new Array();
                for (count = 0; count < eachString.length; count++) {
                    if (eachString[count] != "") {
                        newVar.push(eachString[count]);
                    }
                }
                $p('#cphMain_ddlEmployee').val(newVar);
                $p("#cphMain_ddlEmployee").trigger("change");
            }
            var field = 'ViewId';
            var url = window.location.href;
            if (url.indexOf('?' + field + '=') != -1) {
                document.getElementById("cphMain_ddlDepartment").disabled = true;
                document.getElementById("cphMain_ddlDivision").disabled = true;
                document.getElementById("cphMain_ddlEmployee").disabled = true;
                document.getElementById("cphMain_ddlDesignation").disabled = true;
            }
          });
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function ConfirmMessage() {
            if (confirmbox > 0) {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "hcm_Emp_Welfare_Service_List.aspx";
                    }
                    else {
                        // window.location.href = "hcm_Emp_welfare_service.aspx";
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "hcm_Emp_Welfare_Service_List.aspx";
            }
        }

    
        function CategoryCancelMsg() {
            document.getElementById("cphMain_ddlCategory").style.borderColor = "Red";
            $noCon("#divWarning").html("Selected category is not available for this service.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#divWarning").alert();
            $noCon1(window).scrollTop(0);
            return false;
        }
        function AlertClearAll() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want clear all data in this page?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    window.location.href = "hcm_Emp_welfare_service.aspx";
                }
                else {
                    window.location.href = "hcm_Emp_welfare_service.aspx";
                }
            });
            return false;
        }
    </script> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    
        <asp:HiddenField ID="HiddenselectedDesigntext" runat="server" />
    <asp:HiddenField ID="HiddenselectedDepttext" runat="server" />
    <asp:HiddenField ID="HiddenselectedDivisionetext" runat="server" />
    <asp:HiddenField ID="hiddenselectedEmployeetext" runat="server" />
    <asp:HiddenField ID="hiddenselectedDesignlist" runat="server" />
    <asp:HiddenField ID="HiddenDeptList" runat="server" />
    <asp:HiddenField ID="HiddenDivisionList" runat="server" />
    <asp:HiddenField ID="HiddenEmpList" runat="server" />
    <asp:HiddenField ID="HiddenAdd" runat="server" />
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="contentarea"> 
        <script>
            function ChangeEnable(field) {
                ddlDeptHaveValue = $noCon2('#cphMain_ddlDepartment').val();
                ddlDivisionHaveValue = $noCon2('#cphMain_ddlDivision').val();
                ddlEmpHaveValue = $noCon2('#cphMain_ddlEmployee').val();
                ddlDsgnHaveValue = $noCon2('#cphMain_ddlDesignation').val();

                if (field == 'cphMain_cbxAllDiv') {
                    if (document.getElementById("<%=cbxAllDiv.ClientID%>").checked == true && ddlDivisionHaveValue != null) {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Selected division will be remove and consider as all divisions",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                var newVar = "";

                                document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                                $p('#cphMain_ddlDivision').val(newVar);
                                $p("#cphMain_ddlDivision").trigger("change");
                            }
                            else {
                                document.getElementById("<%=cbxAllDiv.ClientID%>").checked = false;
                            }
                        });
                        return false;

                    }

                    else if (document.getElementById("<%=cbxAllDiv.ClientID%>").checked == true && ddlDivisionHaveValue == null) {
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                    }
                    else if (document.getElementById("<%=cbxAllDiv.ClientID%>").checked == false) {
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = false;
                    }
                    return false;
                }
                else if (field == 'cphMain_cbxAllDept') {

                    if (document.getElementById("<%=cbxAllDept.ClientID%>").checked == true && (ddlDeptHaveValue != null || ddlDivisionHaveValue != null || ddlEmpHaveValue != null || ddlDsgnHaveValue != null)) {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Selected departments will be remove and consider as all departments",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                var newVar = "";
                                $p('#cphMain_ddlDepartment').val(newVar);
                                $p("#cphMain_ddlDepartment").trigger("change");
                                $p('#cphMain_ddlEmployee').val(newVar);
                                $p("#cphMain_ddlEmployee").trigger("change");
                                $p('#cphMain_ddlDivision').val(newVar);
                                $p("#cphMain_ddlDivision").trigger("change");
                                $p('#cphMain_ddlDesignation').val(newVar);
                                $p("#cphMain_ddlDesignation").trigger("change");
                                document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllEmp.ClientID%>").checked = true;
                                document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxDsgn.ClientID%>").checked = true;
                                document.getElementById("<%=cbxDsgn.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                            }
                            else {
                                document.getElementById("<%=cbxAllDept.ClientID%>").checked = false;
                            }

                        });

                        return false;

                    }
                    else if (document.getElementById("<%=cbxAllDept.ClientID%>").checked == true && (ddlDeptHaveValue == null || ddlDivisionHaveValue == null || ddlEmpHaveValue == null || ddlDsgnHaveValue == null)) {
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                    }
                    else if (document.getElementById("<%=cbxAllDept.ClientID%>").checked == false) {
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = false;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = false;
                    }
                    return false;

                }
                else if (field == 'cphMain_cbxDsgn') {

                    if (document.getElementById("<%=cbxDsgn.ClientID%>").checked == true && (ddlEmpHaveValue != null || ddlDsgnHaveValue != null)) {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Selected designations will be remove and consider as all designations",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                var newVar = "";
                                document.getElementById("<%=cbxAllEmp.ClientID%>").checked = true;
                                document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                                document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDept.ClientID%>").checked = true;
                                document.getElementById("<%=cbxAllDept.ClientID%>").disabled = true;
                                $p('#cphMain_ddlDepartment').val(newVar);
                                $p("#cphMain_ddlDepartment").trigger("change");
                                $p('#cphMain_ddlEmployee').val(newVar);
                                $p("#cphMain_ddlEmployee").trigger("change");
                                $p('#cphMain_ddlDivision').val(newVar);
                                $p("#cphMain_ddlDivision").trigger("change");
                                $p('#cphMain_ddlDesignation').val(newVar);
                                $p("#cphMain_ddlDesignation").trigger("change");
                            }
                            else {
                                document.getElementById("<%=cbxDsgn.ClientID%>").checked = false;
                            }
                        });
                        return false;

                    }
                    else if (document.getElementById("<%=cbxDsgn.ClientID%>").checked == true && (ddlEmpHaveValue == null || ddlDsgnHaveValue == null)) {
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = true;
                    }
                    else if (document.getElementById("<%=cbxDsgn.ClientID%>").checked == false) {
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = false;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllEmp.ClientID%>").disabled = false;
                    }
                    return false;

                }

                else if (field == 'cphMain_cbxAllEmp') {
                    if (document.getElementById("<%=cbxAllEmp.ClientID%>").checked == true && (ddlDeptHaveValue != null || ddlDivisionHaveValue != null || ddlEmpHaveValue != null || ddlDsgnHaveValue != null)) {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Selected employees will be remove and consider as all employees",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                var newVar = "";

                                document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxDsgn.ClientID%>").checked = true;
                                document.getElementById("<%=cbxDsgn.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                                document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                                document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                                document.getElementById("<%=cbxAllDept.ClientID%>").checked = true;
                                document.getElementById("<%=cbxAllDept.ClientID%>").disabled = true;
                                $p('#cphMain_ddlDepartment').val(newVar);
                                $p("#cphMain_ddlDepartment").trigger("change");
                                $p('#cphMain_ddlEmployee').val(newVar);
                                $p("#cphMain_ddlEmployee").trigger("change");
                                $p('#cphMain_ddlDivision').val(newVar);
                                $p("#cphMain_ddlDivision").trigger("change");
                                $p('#cphMain_ddlDesignation').val(newVar);
                                $p("#cphMain_ddlDesignation").trigger("change");
                            }
                            else {
                                document.getElementById("<%=cbxAllEmp.ClientID%>").checked = false;
                            }
                        });
                        return false;
                    }
                    else if (document.getElementById("<%=cbxAllEmp.ClientID%>").checked == true && (ddlDeptHaveValue == null || ddlDivisionHaveValue == null || ddlEmpHaveValue == null || ddlDsgnHaveValue == null)) {

                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = true;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = true;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = true;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = true;
                    }
                    else if (document.getElementById("<%=cbxAllEmp.ClientID%>").checked == false) {
                        document.getElementById("<%=ddlEmployee.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDesignation.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxDsgn.ClientID%>").checked = false;
                        document.getElementById("<%=cbxDsgn.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlDivision.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDiv.ClientID%>").checked = false;
                        document.getElementById("<%=ddlDepartment.ClientID%>").disabled = false;
                        document.getElementById("<%=cbxAllDept.ClientID%>").checked = false;
                        document.getElementById("<%=cbxAllDept.ClientID%>").disabled = false;

                    }
                    return false;
                }

            }
//function CalculateToDate(row) {

//    var DropdownListWeek = document.getElementById("ddlFrequency" + row);
//    var SelectedValueWeek = DropdownListWeek.value;
//    var dateCurrentDate = document.getElementById("txtFromDate" + row).value;
//    if (dateCurrentDate != "" && SelectedValueWeek != '--SELECT FREQUENCY--') {
//        var arrDateCurrentDate = dateCurrentDate.split("-");
//        // var CurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);
//        var dateDateCntrlr = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);
//        //= new Date();

//        if (SelectedValueWeek == "0") {
//            var dd = dateDateCntrlr.getDate();
//            var mm = dateDateCntrlr.getMonth() + 2; //January is 0!

//            var yyyy = dateDateCntrlr.getFullYear();
//            if (dd < 10) {
//                dd = '0' + dd
//            }
//            if (mm >= 13) {
//                mm = mm - 12
//                yyyy = yyyy + 1;
//            }
//            if (mm < 10) {
//                mm = '0' + mm
//            }

//            var ddmmyyyyDate = dd + '-' + mm + '-' + yyyy;

//            document.getElementById("txtToDate" + row).value = ddmmyyyyDate;
//        }
//        else if (SelectedValueWeek == "1") {
//            var dd = dateDateCntrlr.getDate();
//            var mm = dateDateCntrlr.getMonth() + 3; //January is 0!

//            var yyyy = dateDateCntrlr.getFullYear();
//            if (dd < 10) {
//                dd = '0' + dd
//            }
//            if (mm >= 13) {
//                mm = mm - 12
//                yyyy = yyyy + 1;

//            }
//            if (mm < 10) {
//                mm = '0' + mm
//            }

//            var ddmmyyyyDate = dd + '-' + mm + '-' + yyyy;

//            document.getElementById("txtToDate" + row).value = ddmmyyyyDate;
//        }
//        else if (SelectedValueWeek == "2") {
//            var dd = dateDateCntrlr.getDate();
//            var mm = dateDateCntrlr.getMonth() + 1; //January is 0!

//            var yyyy = dateDateCntrlr.getFullYear() + 1;
//            if (dd < 10) {
//                dd = '0' + dd
//            }
//            if (mm >= 13) {
//                mm = mm - 12
//            }
//            if (mm < 10) {
//                mm = '0' + mm
//            }
//            var ddmmyyyyDate = dd + '-' + mm + '-' + yyyy;

//            document.getElementById("txtToDate" + row).value = ddmmyyyyDate;
//        }
//        else if (SelectedValueWeek == "3") {
//            document.getElementById("txtToDate" + row).disabled = false;
//            document.getElementById("txtToDate" + row).value = "";

//        }

//    }
//    CheckDate(row);
//}
        </script>
        <script>

            var RowNum = 0;
            function addMoreRows() {
                RowNum++;

                var recRow = '<tr  id="rowId_' + RowNum + '">';
                recRow += '<td style=\"width: 14%; padding-right: 1%;\"> <select id=\"ddlUnit' + RowNum + '\" style=\"margin-left: 4%;\" tabindex=\"13\" onkeydown=\"return isTag(event)\"  onchange=\"ChangeCurrency(' + RowNum + ')\" onkeypress=\"return IncrmntConfrmCounter()\" class=\"form-control\"><option Selected=True>--SELECT UNIT--</option><option value=\"0\"> Liter </option><option value=\"1\"> Amount </option> <option value=\"2\"> Count </option><option value=\"3\"> Kilogram </option> <option value=\"4\"> Meter </option> </select> </td> ';
                recRow += '<td style=\"width: 18%; padding-right: 1%;\"> <select id=\"ddlCurrency' + RowNum + '\" tabindex=\"13\" onkeydown=\"return isTag(event)\" onchange=\"ChangeAllCurrency(' + RowNum + ')\" onkeypress=\"return IncrmntConfrmCounter()\" class=\"form-control\" > <option>--SELECT CURRENCY--</option></select></td>';

                recRow += '<td style=\"width:10%;\"><input id=\"txtQntity' + RowNum + '\"  tabindex=\"13\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"form-control\" /></td>';
                recRow += '<td  style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><div class=\"smart-form\" style=\"float: left; width: 122%; margin-bottom: 20%;\"><label class=\"checkbox\"><input type=\"checkbox\" tabindex=\"13\" style=\"margin-left: 36%;\" onkeypress=\"return DisableEnter(event)\" id=\"cbDefault' + RowNum + '\"  /><i style=\"margin-left: 30%;\" ></i> </label></div></td>';
                recRow += '<td style=\"width: 19%; padding-right: 1%;\"> <select id=\"ddlFrequency' + RowNum + '\"  onkeydown=\"return isTag(event)\" tabindex=\"13\" onkeypress=\"return IncrmntConfrmCounter()\" class=\"form-control\" > <option Selected=True>--SELECT FREQUENCY--</option> <option value=\"0\"> 1 month </option> <option value=\"1\"> 2 month </option> <option value=\"2\"> 1 year </option> <option value=\"3\"> Per visit </option> </select></td>';
                recRow += '<td style=\"width: 10%; padding-right: 1%;\"><input id=\"txtFromDate' + RowNum + '\" maxlength=10 onkeydown=\"return isTag(event)\" tabindex=\"13\" onchange="return CheckDate(' + RowNum + ');" onkeypress=\"return IncrmntConfrmCounter()\"  type=\"text\" placeholder=\"dd-mm-yyyy\" class=\"form-control datepickerFrom\" /></td>';
                recRow += '<td style=\"width:10%;padding-right: 1%;\"><input id=\"txtToDate' + RowNum + '\" tabindex=\"13\" maxlength=10 onkeydown=\"return isTag(event)\"  onchange="return CheckDate(' + RowNum + ');"  onkeypress=\"return IncrmntConfrmCounter()\" type=\"text\" placeholder=\"dd-mm-yyyy\" class=\"form-control datepicker\" /></td>';

                recRow += '<td id="tdIndvlAddMoreRow' + RowNum + '" style=\"width:6;\"><button id=\"btnadd' + RowNum + '\" type=\"button\" tabindex=\"13\" style=\"width: 114%; color: rgb(255, 255, 255); background-color: rgb(65, 123, 176);\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CheckaddMoreRows(' + RowNum + ');\"><span  class=\"glyphicon glyphicon-plus\"></span> Add </button></td>';
                recRow += '<td id="tdIndvlDeleteMoreRow1' + RowNum + '" style=\"padding-right: 1%;\"><button id=\"btnDeleteNot' + RowNum + '\" type=\"button\" tabindex=\"13\" style=\"margin-left: 2%; width: 107%;opacity: 0.5; background-color: rgb(65, 123, 176); color: rgb(255, 255, 255);\" class=\"btn btn-info btn-lg\" onclick=\"return CancelNotPossible();\"><span class=\"glyphicon glyphicon-trash\"></span> Delete </button></td>';
                recRow += '<td id="tdIndvlDeleteMoreRow2' + RowNum + '" style=\"padding-right: 1%; padding-left: 0.5%;\"><button id=\"btnDelete' + RowNum + '\" type=\"button\" tabindex=\"13\" style=\"width: 106%; background-color: rgb(65, 123, 176); color: rgb(255, 255, 255);\" class=\"btn btn-info btn-lg\" onclick=\"return CheckDelEachRow(' + RowNum + ');\"><span style="margin-left: -13%;" class=\"glyphicon glyphicon-trash\"></span> Delete </button></td>';

                recRow += '<td id="tdEvt' + RowNum + '" style="display: none;">INS</td>';
                recRow += '<td id="tdDtlId' + RowNum + '" style="display: none;"></td>';
                recRow += '</tr>';
                jQuery('#TableaddedRows').append(recRow);
                $noCon(".select2").select2();
                var valuesSel = "";
                document.getElementById("ddlUnit" + RowNum).focus();

                document.getElementById("<%=HiddenRownum.ClientID%>").value = RowNum;

                FillddlCurrency(RowNum, valuesSel);
                var $au = jQuery.noConflict();

                $p('.datepicker').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    // startDate: new Date(),
                    timepicker: false,
                });
                $p('.datepickerFrom').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    startDate: new Date(),
                    timepicker: false,
                });
                document.getElementById("tdIndvlDeleteMoreRow1" + RowNum).style.display = "none";
                document.getElementById("tdIndvlDeleteMoreRow2" + RowNum).style.display = "visibile";

                <%-- if (RowNum != "1") {
                    if (document.getElementById("<%=HiddenUnit.ClientID%>").value != "") {

                         var ddlUnit = document.getElementById("<%=HiddenUnit.ClientID%>").value;
                         var arrayUNIT = JSON.parse("[" + ddlUnit + "]");
                         $noCon("#ddlUnit" + RowNum).val(arrayUNIT);
                         document.getElementById("ddlUnit" + RowNum).disabled = true;
                     }
                    setTimeout(function () {
                        if (document.getElementById("<%=HiddenCurrency.ClientID%>").value != "") {
                            var ddlCurrency = document.getElementById("<%=HiddenCurrency.ClientID%>").value;
                          var arrayddlCurrency = JSON.parse("[" + ddlCurrency + "]");
                          $noCon("#ddlCurrency" + RowNum).val(arrayddlCurrency);
                          document.getElementById("ddlCurrency" + RowNum).disabled = true;
                      }
                    }, 35);
                    
                   
                   
                }--%>

                if (document.getElementById("ddlUnit" + RowNum).value == "1") {
                    document.getElementById("ddlCurrency" + RowNum).disabled = false;

                }
                else {
                    document.getElementById("ddlCurrency" + RowNum).disabled = true;
                }
            }
            function AddDeleted(Delrowcount) {
                if (document.getElementById("tdEvt" + Delrowcount).innerHTML == "UPD") {
                    var detailId = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value;
                    detailId = detailId + "," + document.getElementById("tdDtlId" + Delrowcount).innerHTML;
                    document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = detailId;

                }

            }

            var $noconfli = jQuery.noConflict();
            function CheckDelEachRow(Delrowcount) {
                //   var newCount = 0;
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to cancel this welfare limit?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        AddDeleted(Delrowcount);
                        jQuery('#rowId_' + Delrowcount).remove();
                        var table = document.getElementById("TableaddedRows");
                        var x = table.rows.length;
                        var Rownum = document.getElementById("<%=HiddenRownum.ClientID%>").value;

                        var len;
                        if (x == 0) {
                            addMoreRows();
                        }
                        for (var i = Rownum ; i >= 1 ; i--) {
                            var AddButton = $noconfli("#txtFromDate" + i);
                            if (AddButton.length) {
                                // newCount++;
                                document.getElementById("btnadd" + i).disabled = false;
                                document.getElementById("tdIndvlAddMoreRow" + i).style.opacity = "";
                                break;
                            }

                        }

                    }
                });
                return false;
            }
            function ChangeCurrency(RowNum) {

                if (document.getElementById("ddlUnit" + RowNum).value == "1") {
                    document.getElementById("ddlCurrency" + RowNum).disabled = false;

                }
                else {
                    document.getElementById("ddlCurrency" + RowNum).disabled = true;
                    document.getElementById("ddlCurrency" + RowNum).value = "--SELECT CURRENCY--";
                }

                //var table = document.getElementById("TableaddedRows");
                //var UnitValue = document.getElementById("ddlUnit" + RowNum).value;
                //if (document.getElementById("ddlUnit" + RowNum).value == "1") {
                //    document.getElementById("ddlCurrency" + RowNum).disabled = false;

                //}
                //else {
                //    document.getElementById("ddlCurrency" + RowNum).disabled = true;
                //}
                //for (var i = 1; i <= table.rows.length; i++) {
                //    var AddButton = $noconfli("#ddlUnit" + i);
                //    if (AddButton.length) {
                //        if (document.getElementById("tdIndvlDeleteMoreRow1" + i).style.display == "none") {
                //            document.getElementById("ddlUnit" + i).value = UnitValue;
                //            if (document.getElementById("ddlUnit" + i).value == "1") {
                //                document.getElementById("ddlCurrency" + i).disabled = false;

                //            }
                //            else {
                //                document.getElementById("ddlCurrency" + i).disabled = true;
                //                document.getElementById("ddlCurrency" + i).value = "--SELECT CURRENCY--";
                //            }

                //        }
                //    }
                //}
            }

            function CheckDate(r) {
                var ret = true;

                document.getElementById("<%=HiddenRet.ClientID%>").value = "";
                document.getElementById("txtFromDate" + r).style.borderColor = "";
                document.getElementById("txtToDate" + r).style.borderColor = "";
                if (document.getElementById("txtFromDate" + r).value != "" && document.getElementById("txtToDate" + r).value != "") {
                    var DateToCurrent = document.getElementById("txtToDate" + r).value;
                    var arrToCurrent = DateToCurrent.split("-");
                    DateToCurrent = new Date(arrToCurrent[2], arrToCurrent[1], arrToCurrent[0]);

                    var DateFromCurrent = document.getElementById("txtFromDate" + r).value;
                    var arrFromCurrent = DateFromCurrent.split("-");
                    DateFromCurrent = new Date(arrFromCurrent[2], arrFromCurrent[1], arrFromCurrent[0]);
                    if (DateFromCurrent > DateToCurrent) {
                        document.getElementById("txtFromDate" + r).style.borderColor = "Red";
                        document.getElementById("txtToDate" + r).style.borderColor = "Red";

                        $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                        });
                        $noCon("#divWarning").alert();
                        $noCon1(window).scrollTop(0);
                        ret = false;

                    }
                }
                var arrFromPrevius;
                var arrToprevius;
                var num = document.getElementById("<%=HiddenRownum.ClientID%>").value;
                var table = document.getElementById("TableaddedRows");
                //  alert(RowNum);
                for (var i = RowNum ; i >= 1 ; i--) {
                    var previus = i - 1;
                    var AddButton = $noconfli("#txtFromDate" + previus);
                    if (AddButton.length) {
                        var DateFromprevius = document.getElementById("txtFromDate" + previus).value;
                        arrFromPrevius = DateFromprevius.split("-");
                        DateFromprevius = new Date(arrFromPrevius[2], arrFromPrevius[1], arrFromPrevius[0]);
                        var DateToprevius = document.getElementById("txtToDate" + previus).value;
                        if (DateToprevius != "") {
                            arrToprevius = DateToprevius.split("-");
                            DateToprevius = new Date(arrToprevius[2], arrToprevius[1], arrToprevius[0]);


                            if (r != previus) {
                                if (DateFromprevius <= DateToCurrent && DateFromCurrent <= DateToprevius) {
                                    document.getElementById("txtFromDate" + r).style.borderColor = "Red";
                                    $noCon("#divWarning").html("Limit date range should not overlap.");
                                    $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                                    });
                                    $noCon("#divWarning").alert();
                                    $noCon1(window).scrollTop(0);
                                    ret = false;
                                }
                            }
                        }
                    }
                }

                document.getElementById("<%=HiddenRet.ClientID%>").value = ret;
                return ret;
            }
            function FillddlCurrency(rowCount, CRNCY_VALUES) {

                var ddlTestDropDownListXML = $noCon("#ddlCurrency" + rowCount);
                var strOrgId = '<%=Session["ORGID"]%>';
                var strCorpId = '<%=Session["CORPOFFICEID"]%>';
                var tableName = "dtTableLoadCurrency";

                $noCon.ajax({
                    type: "POST",
                    url: "hcm_Emp_welfare_service.aspx/DropdownCurrencyBind",
                    data: '{strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        $noCon(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('CRNCMST_ID').text();
                            var OptionText = $noCon(this).find('CRNCMST_NAME').text();
                            // Create an Option for DropDownList.
                            var option = $noCon("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);
                            ddlTestDropDownListXML.append(option);
                            var currency = "";
                            if (CRNCY_VALUES != null)
                                currency = CRNCY_VALUES;


                            if (currency != "") {

                                var arrayCNTRY_VALUES = JSON.parse("[" + CRNCY_VALUES + "]");
                                $noCon("#ddlCurrency" + rowCount).val(arrayCNTRY_VALUES);
                                document.getElementById("<%=HiddenCurrency.ClientID%>").value = CRNCY_VALUES;
                            }
                        });
                    },
                    failure: function (response) {

                    }
                });
            }
            function CheckaddMoreRows(x) {

                if (LimitTableCheck() == true) {
                    if (CheckDate(x) == true) {
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.6";
                        document.getElementById("btnadd" + x).disabled = true;

                        addMoreRows();
                        return false;
                    }
                }
                return false;
            }

            function CheckAllRowFieldAndHighlight(x) {
                ret = true;

                document.getElementById("ddlCurrency" + x).style.borderColor = "";
                document.getElementById("txtQntity" + x).style.borderColor = "";
                document.getElementById("ddlFrequency" + x).style.borderColor = "";
                document.getElementById("txtFromDate" + x).style.borderColor = "";
                document.getElementById("txtToDate" + x).style.borderColor = "";
                document.getElementById("ddlUnit" + x).style.borderColor = "";
                var table = document.getElementById("TableaddedRows");

                for (var x = 1; x <= table.rows.length; x++) {
                    var AddButton = $noconfli("#ddlUnit" + x);
                    if (AddButton.length) {
                        var FromDt = document.getElementById("txtFromDate" + x).value;
                        if (FromDt == "") {
                            document.getElementById("txtFromDate" + x).style.borderColor = "Red";
                            // $noCon("#txtFromDate" + x).select();
                            ret = false;
                        } var ToDate = document.getElementById("txtToDate" + x).value;
                        if (ToDate == "") {
                            document.getElementById("txtToDate" + x).style.borderColor = "Red";
                            //$noCon("#txtToDate" + x).select();
                            ret = false;
                        }

                        var sharePer = document.getElementById("txtQntity" + x).value;
                        if (sharePer == "") {
                            document.getElementById("txtQntity" + x).style.borderColor = "Red";
                            document.getElementById("txtQntity" + x).focus();
                            $noCon("#txtQntity" + x).select();
                            ret = false;
                        }
                        var documentNo = document.getElementById("ddlFrequency" + x).value;
                        if (documentNo == "--SELECT FREQUENCY--") {
                            document.getElementById("ddlFrequency" + x).style.borderColor = "Red";
                            document.getElementById("ddlFrequency" + x).focus();
                            $noCon("#ddlFrequency" + x).select();
                            ret = false;
                        }
                        var unit = document.getElementById("ddlUnit" + x).value;
                        if (unit == "" || unit == "--SELECT UNIT--") {
                            document.getElementById("ddlUnit" + RowNum).style.borderColor = "red";
                            document.getElementById("ddlUnit" + RowNum).focus();
                            $noCon("#ddlUnit" + x).select();
                            ret = false;
                        }
                        else {
                            if (unit == "1") {
                                var currency = document.getElementById("ddlCurrency" + x).value;
                                if (currency == "--SELECT CURRENCY--") {
                                    document.getElementById("ddlCurrency" + RowNum).style.borderColor = "red";
                                    document.getElementById("ddlCurrency" + RowNum).focus();
                                    $noCon("#ddlCurrency" + x).select();
                                    ret = false;
                                }
                            }
                        }
                    }
                }


                if (ret == true) {
                    //    var retDate = CheckDate(table.rows.length)
                    //}
                    //if (retDate == true) {
                    return true;
                }
                else {
                    return false;
                }

            }
            function EditListRows(QUANTITY, UNIT, MANDATORY, CURRENCY, FREQUENCY, FROMDATE, TODATE, WELFARESUB_ID, TRANSACTION, DEPTCOUNT, DSGNCOUNT, DIVCOUNT, EMPCOUNT) {


                RowNum++;

                var recRow = '<tr  id="rowId_' + RowNum + '">';
                recRow += '<td style=\"width: 14%; padding-right: 1%;\"> <select id=\"ddlUnit' + RowNum + '\" style=\"margin-left: 4%;\" tabindex=\"13\"  onkeydown=\"return isTag(event)\"  onchange=\"ChangeCurrency(' + RowNum + ')\" onkeypress=\"return isTag(event)\" class=\"form-control\"><option Selected=True>--SELECT UNIT--</option><option value=\"0\"> Liter </option><option value=\"1\"> Amount </option> <option value=\"2\"> Count </option><option value=\"3\"> Kilogram </option> <option value=\"4\"> Meter </option> </select> </td> ';
                recRow += '<td style=\"width: 18%; padding-right: 1%;\"> <select id=\"ddlCurrency' + RowNum + '\" tabindex=\"13\"  onkeydown=\"return isTag(event)\" onchange=\"ChangeAllCurrency(' + RowNum + ')\" onkeypress=\"return isTag(event)\" class=\"form-control\" > <option>--SELECT CURRENCY--</option></select></td>';

                recRow += '<td style=\"width:10%;\"><input id=\"txtQntity' + RowNum + '\" tabindex=\"13\"  maxlength=8 isNumber(event) onkeypress=\"return isNumber(event)\" type=\"text\" value="' + QUANTITY + '"  class=\"form-control\" /></td>';
                if (MANDATORY == "1")
                    recRow += '<td  style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><div class=\"smart-form\" style=\"float: left; width: 122%; margin-bottom: 20%;\"><label class=\"checkbox\"><input type=\"checkbox\" checked=\"true\" style=\"margin-left: 36%;\" onkeypress=\"return DisableEnter(event)\" id=\"cbDefault' + RowNum + '\" tabindex=\"13\" /><i style=\"margin-left: 30%;\" ></i> </label></div></td>';

                if (MANDATORY == "0")
                    recRow += '<td  style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><div class=\"smart-form\" style=\"float: left; width: 122%; margin-bottom: 20%;\"><label class=\"checkbox\"><input type=\"checkbox\" style=\"margin-left: 36%;\" onkeypress=\"return DisableEnter(event)\" id=\"cbDefault' + RowNum + '\" tabindex=\"13\"  /><i style=\"margin-left: 30%;\" ></i> </label></div></td>';

                recRow += '<td style=\"width: 19%; padding-right: 1%;\"> <select id=\"ddlFrequency' + RowNum + '\" tabindex=\"13\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" class=\"form-control\" > <option value=\"0\"> 1 month </option> <option value=\"1\"> 2 month </option> <option value=\"2\"> 1 year </option> <option value=\"3\"> Per visit </option> </select></td>';
                recRow += '<td style=\"width: 10%; padding-right: 1%;\"><input id=\"txtFromDate' + RowNum + '\" tabindex=\"13\" maxlength=10 onkeydown=\"return isTag(event)\"   onchange="return CheckDate(' + RowNum + ');" onkeypress=\"return isTag(event)\"  type=\"text\" value="' + FROMDATE + '" placeholder=\"dd-mm-yyyy\" class=\"form-control datepickerFrom\" /></td>';
                recRow += '<td style=\"width:10%;padding-right: 1%;\"><input id=\"txtToDate' + RowNum + '\" tabindex=\"13\" maxlength=10 onkeydown=\"return isTag(event)\"  onchange="return CheckDate(' + RowNum + ');"  onkeypress=\"return isTag(event)\" type=\"text\" value="' + TODATE + '" placeholder=\"dd-mm-yyyy\" class=\"form-control datepicker\" /></td>';

              
                recRow += '<td id="tdIndvlAddMoreRow' + RowNum + '" style=\"width:6;\"><button id=\"btnadd' + RowNum + '\" type=\"button\" tabindex=\"13\" style=\"width: 114%; color: rgb(255, 255, 255); background-color: rgb(65, 123, 176);\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CheckaddMoreRows(' + RowNum + ');\"><span  class=\"glyphicon glyphicon-plus\"></span> Add </button></td>';
                recRow += '<td id="tdIndvlDeleteMoreRow1' + RowNum + '" style=\"padding-right: 1%;\"><button id=\"btnDeleteNot' + RowNum + '\" type=\"button\" tabindex=\"13\" style=\"margin-left: 2%; width: 107%;opacity: 0.5; background-color: rgb(65, 123, 176); color: rgb(255, 255, 255);\" class=\"btn btn-info btn-lg\" onclick=\"return CancelNotPossible();\"><span class=\"glyphicon glyphicon-trash\"></span> Delete </button></td>';
                recRow += '<td id="tdIndvlDeleteMoreRow2' + RowNum + '" style=\"padding-right: 1%; padding-left: 0.5%;\"><button id=\"btnDelete' + RowNum + '\" type=\"button\" tabindex=\"13\" style=\"width: 106%; background-color: rgb(65, 123, 176); color: rgb(255, 255, 255);\" class=\"btn btn-info btn-lg\" onclick=\"return CheckDelEachRow(' + RowNum + ');\"><span style="margin-left: -13%;" class=\"glyphicon glyphicon-trash\"></span> Delete </button></td>';



                recRow += '<td id="tdEvt' + RowNum + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + RowNum + '" style="display: none;">' + WELFARESUB_ID + '</td>';

                recRow += '</tr>';
                jQuery('#TableaddedRows').append(recRow);
                document.getElementById("tdIndvlAddMoreRow" + RowNum).style.opacity = "";

                $p('.datepicker').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    // startDate: new Date(),
                    timepicker: false,
                });
                $p('.datepickerFrom').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    startDate: new Date(),
                    timepicker: false,
                });

                if (UNIT != "") {
                    var arrayUNIT = JSON.parse("[" + UNIT + "]");
                    $noCon("#ddlUnit" + RowNum).val(arrayUNIT);
                }
                if (FREQUENCY != "") {
                    var arrayUNIT = JSON.parse("[" + FREQUENCY + "]");
                    $noCon("#ddlFrequency" + RowNum).val(arrayUNIT);
                }

                if (document.getElementById("ddlUnit" + RowNum).value == "1") {
                    document.getElementById("ddlCurrency" + RowNum).disabled = false;

                }
                else {
                    document.getElementById("ddlCurrency" + RowNum).disabled = true;

                }
                if (TRANSACTION > 0 || DEPTCOUNT > 0 || DSGNCOUNT > 0 || DIVCOUNT > 0 || EMPCOUNT > 0) {
                    //document.getElementById("txtQntity" + RowNum).disabled = true;
                    //document.getElementById("ddlUnit" + RowNum).disabled = true;
                    //document.getElementById("ddlCurrency" + RowNum).disabled = true;
                    //document.getElementById("txtFromDate" + RowNum).disabled = true;
                    //document.getElementById("txtToDate" + RowNum).disabled = true;
                    //document.getElementById("ddlFrequency" + RowNum).disabled = true;
                    //document.getElementById("cbDefault" + RowNum).disabled = true;
                    document.getElementById("tdIndvlDeleteMoreRow1" + RowNum).style.display = "visibile";
                    document.getElementById("tdIndvlDeleteMoreRow2" + RowNum).style.display = "none";
                    document.getElementById("<%=HiddenCurrency.ClientID%>").value = CURRENCY;
                    document.getElementById("<%=HiddenUnit.ClientID%>").value = UNIT;

                }
                else {
                    document.getElementById("tdIndvlDeleteMoreRow1" + RowNum).style.display = "none";
                    document.getElementById("tdIndvlDeleteMoreRow2" + RowNum).style.display = "visibile";
                }
                if (RowNum != "1")
                    document.getElementById("btnadd" + (RowNum - 1)).disabled = true;


                FillddlCurrency(RowNum, CURRENCY);

            }
            function ViewListRows(QUANTITY, UNIT, MANDATORY, CURRENCY, FREQUENCY, FROMDATE, TODATE, WELFARESUB_ID, TRANSACTION, DEPTCOUNT, DSGNCOUNT, DIVCOUNT, EMPCOUNT) {


                RowNum++;

                var recRow = '<tr  id="rowId_' + RowNum + '">';
                recRow += '<td style=\"width: 14%; padding-right: 1%;\"> <select id=\"ddlUnit' + RowNum + '\" style=\"margin-left: 4%;\" disabled=\=true\" onkeydown=\"return isTag(event)\"  onchange=\"ChangeCurrency(' + RowNum + ')\" onkeypress=\"return isTag(event)\" class=\"form-control\"><option Selected=True>--SELECT UNIT--</option><option value=\"0\"> Liter </option><option value=\"1\"> Amount </option> <option value=\"2\"> Count </option><option value=\"3\"> Kilogram </option> <option value=\"4\"> Meter </option> </select> </td> ';
                recRow += '<td style=\"width: 18%; padding-right: 1%;\"> <select id=\"ddlCurrency' + RowNum + '\" disabled=\=true\" onkeydown=\"return isTag(event)\" onchange=\"ChangeAllCurrency(' + RowNum + ')\" onkeypress=\"return isTag(event)\" class=\"form-control\" > <option>--SELECT CURRENCY--</option></select></td>';

                recRow += '<td style=\"width:9%;\"><input id=\"txtQntity' + RowNum + '\" maxlength=8 isNumber(event) onkeypress=\"return isNumber(event)\" type=\"text\" disabled=\=true\" value="' + QUANTITY + '"  class=\"form-control\" /></td>';
                if (MANDATORY == "1")
                    recRow += '<td  style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><div class=\"smart-form\" style=\"float: left; width: 122%; margin-bottom: 20%;\"><label class=\"checkbox\"><input type=\"checkbox\" disabled=\=true\" checked=\"true\" style=\"margin-left: 36%;\" onkeypress=\"return DisableEnter(event)\" id=\"cbDefault' + RowNum + '\"  /><i style=\"margin-left: 30%;\" ></i> </label></div></td>';

                if (MANDATORY == "0")
                    recRow += '<td  style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><div class=\"smart-form\" style=\"float: left; width: 122%; margin-bottom: 20%;\"><label class=\"checkbox\"><input type=\"checkbox\" style=\"margin-left: 36%;\" disabled=\=true\" onkeypress=\"return DisableEnter(event)\" disabled=\=true\" id=\"cbDefault' + RowNum + '\"  /><i style=\"margin-left: 30%;\" ></i> </label></div></td>';

                recRow += '<td style=\"width: 19%; padding-right: 1%;\"> <select id=\"ddlFrequency' + RowNum + '\" disabled=\=true\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" class=\"form-control\" > <option value=\"0\"> 1 month </option> <option value=\"1\"> 2 month </option> <option value=\"2\"> 1 year </option> <option value=\"3\"> Per visit </option> </select></td>';
                recRow += '<td style=\"width: 10%; padding-right: 1%;\"><input id=\"txtFromDate' + RowNum + '\" disabled=\=true\" maxlength=10 onkeydown=\"return isTag(event)\"   onchange="return CheckDate(' + RowNum + ');" onkeypress=\"return isTag(event)\"  type=\"text\" value="' + FROMDATE + '" placeholder=\"dd-mm-yyyy\" class=\"form-control datepicker\" /></td>';
                recRow += '<td style=\"width:10%;padding-right: 1%;\"><input id=\"txtToDate' + RowNum + '\" maxlength=10 disabled=\=true\" onkeydown=\"return isTag(event)\"  onchange="return CheckDate(' + RowNum + ');"  onkeypress=\"return isTag(event)\" type=\"text\" value="' + TODATE + '" placeholder=\"dd-mm-yyyy\" class=\"form-control datepicker\" /></td>';


                recRow += '<td id="tdIndvlAddMoreRow' + RowNum + '" style=\"width:6;\"><button id=\"btnadd' + RowNum + '\" type=\"button\" tabindex=\"13\" style=\"width: 114%; color: rgb(255, 255, 255); background-color: rgb(65, 123, 176);\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CheckaddMoreRows(' + RowNum + ');\"><span  class=\"glyphicon glyphicon-plus\"></span> Add </button></td>';
                recRow += '<td id="tdIndvlDeleteMoreRow1' + RowNum + '" style=\"padding-right: 1%;\"><button id=\"btnDeleteNot' + RowNum + '\" type=\"button\" tabindex=\"13\" style=\"margin-left: 2%; width: 107%;opacity: 0.5; background-color: rgb(65, 123, 176); color: rgb(255, 255, 255);\" class=\"btn btn-info btn-lg\" onclick=\"return CancelNotPossible();\"><span class=\"glyphicon glyphicon-trash\"></span> Delete </button></td>';
                recRow += '<td id="tdIndvlDeleteMoreRow2' + RowNum + '" style=\"padding-right: 1%; padding-left: 0.5%;\"><button id=\"btnDelete' + RowNum + '\" type=\"button\" tabindex=\"13\" style=\"width: 106%; background-color: rgb(65, 123, 176); color: rgb(255, 255, 255);\" class=\"btn btn-info btn-lg\" onclick=\"return CheckDelEachRow(' + RowNum + ');\"><span style="margin-left: -13%;" class=\"glyphicon glyphicon-trash\"></span> Delete </button></td>';




                recRow += '<td id="tdEvt' + RowNum + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + RowNum + '" style="display: none;">' + WELFARESUB_ID + '</td>';

                recRow += '</tr>';
                jQuery('#TableaddedRows').append(recRow);
                document.getElementById("tdIndvlAddMoreRow" + RowNum).style.opacity = "";
                if (UNIT != "") {
                    var arrayUNIT = JSON.parse("[" + UNIT + "]");
                    $noCon("#ddlUnit" + RowNum).val(arrayUNIT);
                }
                if (FREQUENCY != "") {
                    var arrayUNIT = JSON.parse("[" + FREQUENCY + "]");
                    $noCon("#ddlFrequency" + RowNum).val(arrayUNIT);
                }

                if (document.getElementById("ddlUnit" + RowNum).value == "1") {
                    document.getElementById("ddlCurrency" + RowNum).disabled = false;

                }
                else {
                    document.getElementById("ddlCurrency" + RowNum).disabled = true;

                }
                if (TRANSACTION > 0 || DEPTCOUNT > 0 || DSGNCOUNT > 0 || DIVCOUNT > 0 || EMPCOUNT > 0) {
                    document.getElementById("txtQntity" + RowNum).disabled = true;
                    document.getElementById("ddlUnit" + RowNum).disabled = true;
                    document.getElementById("ddlCurrency" + RowNum).disabled = true;
                    document.getElementById("txtFromDate" + RowNum).disabled = true;
                    document.getElementById("txtToDate" + RowNum).disabled = true;
                    document.getElementById("ddlFrequency" + RowNum).disabled = true;
                    document.getElementById("cbDefault" + RowNum).disabled = true;
                    document.getElementById("tdIndvlDeleteMoreRow1" + RowNum).style.display = "visibile";
                    document.getElementById("tdIndvlDeleteMoreRow2" + RowNum).style.display = "none";

                }
                else {
                    document.getElementById("tdIndvlDeleteMoreRow1" + RowNum).style.display = "none";
                    document.getElementById("tdIndvlDeleteMoreRow2" + RowNum).style.display = "visibile";
                }


                FillddlCurrency(RowNum, CURRENCY);
            }


        </script>
        <style>
            .font-sty {
                color: #484242;
            }
         .table-responsive {
    min-height: 0;
}
        .form-control custom-select:focus {
    border: 1px solid #bbf2cf;
}
         
        </style>
<div class="auto1" style="width:100%;">
<div class="cont_lft">
    <asp:HiddenField ID="HiddenCurrency" runat="server" />
    <asp:HiddenField ID="HiddenUnit" runat="server" />
    <asp:HiddenField ID="HiddenRownum" runat="server" />
    <asp:HiddenField ID="HiddenRet" runat="server" />

    <asp:HiddenField ID="HiddenEdit" runat="server" />

    <asp:HiddenField ID="HiddenView" runat="server" />

</div>
<div class="cont_rght" style="width:100%">
            <div class="alert alert-success" id="success-alert" style="display: none;margin-left: 0%;width: 98%;">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
                 <div class="alert alert-danger" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>

          <div id="divList" class="list" tabindex="10"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:1%;z-index:1; top:42%;height:26.5px;">

        </div>
<div class="sect250">
<div class="row">
<div class="col-xs-12">
<div class="box box-solid">
<div class="box-header">
  <h3 class="box-title" style=" margin-bottom: 14px; color: rgb(83, 101, 51); font-weight: bold; font-family: Calibri; font-size: 24px;">Add Welfare Service</h3>
</div>
<div  class="box-body" >
<div class="container-fluid" style="padding-top: 40px;
    padding-bottom: 33px;
       border:1px solid #a4ad94;background-color: #f7f7f7;">
<div class="col-sm-12 col-md-12 col-lg-6">
<form>
<div class="form-group row">
  <label for="staticEmail" class="col-sm-4 col-form-label font-sty" style="width: 23%;">Category<span style="color:#F00">*</span></label>
  <div id="divddlCategory" runat="server" class="col-sm-8">
         <asp:DropDownList ID="ddlCategory" class="form-control custom-select" TabIndex="1" runat="server" Style="width: 100%;"  onkeypress="return IsEnter(event);"></asp:DropDownList>
  </div>
</div>
</div>
    <div class="col-sm-12 col-md-12 col-lg-6" style="float: right;">
  <div class="form-group row">
    <label for="inputPassword" class="col-sm-4 col-form-label font-sty"style="width: 28%;">Available for<span style="color:#F00">*</span></label>
    <div class="col-sm-8">
     <div id="divAvailable" runat="server" class="col-xs-12" style="background-color: rgb(234, 234, 234); height: auto; padding-top: 10px; border: 1px solid rgb(204, 204, 204); border-radius: 3px; width: 105%;">
           <div class="form-group row">
    <label for="inputPassword" class="col-sm-3 col-form-label font-sty" style="padding:7px; width:27%">Department</label>
   
             <div id="divDept" class="col-sm-6">
         <asp:DropDownList ID="ddlDepartment" class="form-control select2" TabIndex="5"  multiple="multiple" data-placeholder="Select Department" Style="height: 25px; width: 124%;" runat="server">
                    </asp:DropDownList>
    </div>
    <div class="col-sm-2" style="padding:0px;width:20%;">
          <div id="divcbxAllDept"  runat="server" class="smart-form" style="float: left; width: 99%;">    
      <label class="checkbox" style="float: right;">All
        <input  type="checkbox" runat="server" tabindex="6"  onchange="ChangeEnable('cphMain_cbxAllDept');"  onkeypress="return DisableEnter(event)" id="cbxAllDept" />
       <i  ></i> </label>
               </div>
        </div>
               
  </div>
           <div class="form-group row">
    <label for="inputPassword" class="col-sm-3 col-form-label font-sty"  style="padding:7px; width:27%">Division</label>
    <div id="divDivision" class="col-sm-6">
          <asp:DropDownList ID="ddlDivision" class="form-control select2" TabIndex="7" multiple="multiple" data-placeholder="Select Division" Style="height:25px; width: 124%;" runat="server">
                    </asp:DropDownList>   
    </div>
    <div class="col-sm-2" style="padding:0px;width:20%;">
     
         <div id="divcbxAllDiv"  runat="server" class="smart-form" style="float: left; width: 99%;">    
      <label class="checkbox" style="float: right;">All
        <input  type="checkbox" runat="server" tabindex="8"  onchange="ChangeEnable('cphMain_cbxAllDiv');"  onkeypress="return DisableEnter(event)" id="cbxAllDiv" />
       <i  ></i> </label>
               </div>
        </div>
  </div>
       <div class="form-group row">
    <label for="inputPassword" class="col-sm-3 col-form-label font-sty" style="padding:7px;  width:27%">Designation</label>
    <div id="divDsgn" class="col-sm-6">
           <asp:DropDownList ID="ddlDesignation" class="form-control select2" TabIndex="9" multiple="multiple" data-placeholder="Select Designation" Style="height: 25px; width: 124%;" runat="server">
                    </asp:DropDownList>
    </div>
    <div class="col-sm-2" style="padding:0px;width:20%;">
      
          <div id="divcbxDsgn"  runat="server" class="smart-form" style="float: left; width: 99%;">    
      <label class="checkbox" style="float: right;">All
        <input  type="checkbox" runat="server" tabindex="10"  onchange="ChangeEnable('cphMain_cbxDsgn');"  onkeypress="return DisableEnter(event)" id="cbxDsgn" />
       <i  ></i> </label>
               </div>
        </div>
  </div>
  <div class="form-group row">
    <label for="inputPassword" class="col-sm-3 col-form-label font-sty" style="padding:7px; width:27%">Employee</label>
    <div id="divEmp" class="col-sm-6">
  <asp:DropDownList ID="ddlEmployee" class="form-control select2" TabIndex="11" multiple="multiple" data-placeholder="Select Employee" Style="height: 25px; width: 124%;" runat="server">
                    </asp:DropDownList>   
    </div>
    <div class="col-sm-2" style="padding:0px;width:20%;">
           <div id="divcbxAllEmp"  runat="server" class="smart-form" style="float: left; width: 99%;">    
      <label class="checkbox" style="float: right;">All
        <input  type="checkbox" runat="server" tabindex="12"  onchange="ChangeEnable('cphMain_cbxAllEmp');"  onkeypress="return DisableEnter(event)" id="cbxAllEmp" />
       <i  ></i> </label>
               </div>
        </div>
  </div>


  
     </div>
    </div>
  </div>
</div>

    
<div class="col-sm-12 col-md-12 col-lg-6 " style="margin-top: 1%;">
  <div class="form-group row">
    <label for="inputPassword" class="col-sm-4 col-form-label font-sty"style="width: 23%;">Name<span style="color:#F00">*</span></label>
    <div class="col-sm-8">
                <asp:TextBox ID="txtServiceName" Height="30px" Width="100%" class="form-control" runat="server"  TabIndex="2" MaxLength="100" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtServiceName,190)" onkeydown=" return textCounter(cphMain_txtServiceName,150)" Style="text-transform: uppercase; margin-right: 4%;" ></asp:TextBox>
    </div>
  </div>
</div>

<div class="col-sm-12 col-md-12 col-lg-6" style="margin-top: 1%;">
  <div class="form-group row">
    <label for="inputPassword" class="col-sm-4 col-form-label font-sty"style="width: 23%;">Facility details</label>
    <div class="col-sm-8">
                <asp:TextBox ID="txtServiceDesc"  class="form-control" runat="server" MaxLength="500" TabIndex="3" TextMode="MultiLine" onchange="IncrmntConfrmCounter();" onkeypress="return  isTagDes(event);" Style="height: 60px; width: 100%; resize: none; margin-right: 4%;"></asp:TextBox>

    </div>
  </div>
</div>
    <div class="col-sm-12 col-md-12 col-lg-6">
        <div class="form-group row"style="margin-top: 6%;">
    <label for="inputPassword" class="col-sm-4 col-form-label font-sty"style="width: 23%;">Status</label>
    <div class="col-sm-8">
         <div id="divcbxStatus"  runat="server" class="smart-form" style="float: left; width: 99%;">    
      <label class="checkbox" style="float: left;">Active
        <input  type="checkbox" runat="server" tabindex="4"  onkeypress="return DisableEnter(event)" id="cbxStatus" />
       <i  ></i> </label>
               </div>
    </div>
  </div>
        </div>
 
      <div class="col-sm-12 col-md-12 col-lg-6" style="width:100%;">
        <div class="form-group row"style="">
    <label for="inputPassword" class="col-sm-4 col-form-label font-sty"style="width: 23%;">Limit<span style="color:#F00;">*</span></label>
   </div>   </div> 
    <div id="divEmployeeTable" class="" style=" background-color: rgb(219, 219, 219);margin-left: 1%; width: 97%; padding-top: 25px; clear: both; border-color: rgb(68, 29, 29);" runat="server">

          <table id="tableMain" class="table table-bordered table-responsive" style="font-size:13px;width: 88%; min-height:0; overflow-x:hidden">
                    <tr>
                    <td style="width: 10%; text-align: center;">Unit </td>
                          <td style="width:13%; text-align: center;"> Currency </td>
                    <td style="width: 3%; text-align: center;"> Quantity </td>
                    <td style="width:7%;"> Mandatory </td>
                  
                    <td style="width:11%;text-align: left;"> Frequency </td>
                    <td style="width:8%;text-align: center;"> From Period </td>

                    <td style="width:8%;text-align: left;"> To Period </td>        
                    <td style="width:22%;text-align: center;display:none;"></td>        

                    </tr>
              </table>
          <div style="width: 100%;">
                        <table id="TableaddedRows">
                        </table>
                    </div>

    </div>



 <div class="col-xs-12"style="float:right;width:65%;margin-top:6%;" >

  <asp:Button ID="btnUpdate"  runat="server" class="btn btn-primary"  TabIndex="22"  Text="Update" OnClientClick="return ServiceValidate();" OnClick="btnUpdate_Click" />
<asp:Button ID="btnUpdateClose" runat="server" class="btn btn-primary" TabIndex="23" Text="Update & Close"  OnClientClick="return ServiceValidate();"  OnClick="btnUpdate_Click" />
<asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="Save" TabIndex="22"  OnClientClick="return ServiceValidate();" OnClick="btnAdd_Click"/>  
<asp:Button ID="btnAddClose" runat="server" class="btn btn-primary" TabIndex="23" Text="Save & Close"  OnClientClick="return ServiceValidate();" OnClick="btnAdd_Click"/>
<asp:Button ID="btnCancel" runat="server" class="btn btn-primary" TabIndex="24" Text="Cancel" OnClientClick="return ConfirmMessage();"/>
<asp:Button ID="btnClear" runat="server"  TabIndex="25" OnClientClick="return AlertClearAll();" class="btn btn-primary" Text="Clear" /> 
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
       <style>
         .datepicker.dropdown-menu {
            z-index: 10000;
             
        }
            .datepicker table tr td.disabled {
                color: #C58E8E;
            }
        
        </style> 
       
</asp:Content>

