<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="flt_Job_Shdl.aspx.cs" Inherits="AWMS_AWMS_Transaction_flt_Job_Shdl_flt_Job_Shdl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <%--auto completion files--%>

    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link rel="stylesheet" href="../../../css/Autocomplete/jquery-ui.css" />
    <%--FOR DATE TIME PICKER--%>
    <script type="text/javascript" src="../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>
    <script type="text/javascript" src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
    <script type="text/javascript" src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
    <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
    <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
        var submit = 0;
        function CheckIsRepeat() {

            if (++submit > 1) {

                return false;
            }
            else {
                return true;
            }
        }
        function CheckSubmitZero() {
            submit = 0;
        }
    </script>
    <style>
        /*for error related to quotation entery*/
        #divErrorNotification {
            border-radius: 8px;
            background: #fff;
            padding: 5px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: -1.5%;
            font-family: Calibri;
            border: 2px solid #53844E;
            width: 94%;
        }
           #divErrorNotificationDW {
            border-radius: 8px;
            background: #fff;
            padding: 5px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: -1.5%;
            font-family: Calibri;
            border: 2px solid #53844E;
            width: 94%;
        }
        /*.input-append .add-on {
            margin-top: -5%;
            padding-top: 2%;
            padding-bottom: 3%;
            cursor: pointer;
        }*/
        .open > .dropdown-menu {
            display: none;
        }
    </style>


    <script>
        //start-0006
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function ConfirmMessage() {
            if (confirmbox > 0) {

                if (confirm("Are You Sure You Want To Leave This Page?")) {

                    window.location.href = "/AWMS/AWMS_Transaction/flt_Job_Shdl/flt_Job_Shdl_List.aspx";

                    return false;
                }
                else {
                    return false;

                }
            }
            else {

                window.location.href = "/AWMS/AWMS_Transaction/flt_Job_Shdl/flt_Job_Shdl_List.aspx";

                return false;
            }
        }
        function ConfirmClear() {
            var Emp =document.getElementById("<%= hiddenEmpJSIdQS.ClientID%>").value;
            if (confirmbox > 0) {

                if (confirm("Are You Sure You Want Clear All Data In This Page?")) {

                    window.location.href = "flt_Job_Shdl.aspx?EmpId=" + Emp;

                    return false;
                }
                else {
                    return false;

                }
            }
            else {

                window.location.href = "flt_Job_Shdl.aspx?EmpId=" + Emp;

                return false;
            }
        }
        //stop-0006
    </script>

    <script>



        function SuccessSave() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job Schedule Details Saved Successfully.";
        }
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job Schedule Details Confirmed Successfully.";
        }
        function FailureConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirmation  Not Successfull. It is already Confirmed.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job Schedule Details Updated Successfully.";
        }

        function SuccessReOpen() {
           
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job Schedule Details Re-Opened Successfully.";
        }
        function FailureReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Re-Opening  Not Successfull. It is already Re-Opened.";
        }
        function ErrorMsg() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some Error Occured.Please Review Entered Values !";
        }
        function ConfirmPnd() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job Schedule Details Inserted Successfully.Confirmation Pending";
        }


    </script>
    <script>
        var $noC = jQuery.noConflict();
        // for not allowing <> tags
        function isTag(obj, evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                if (obj == "cphMain_txtComments" || obj == "cphMain_txtPriceTerm" || obj == "cphMain_txtPymntTerm" || obj == "cphMain_txtDlvryTerm" || obj == "cphMain_txtValidityTerm" || obj == "cphMain_txtManufacturerTerm" || obj == "cphMain_txtReopenReasonDescptn") {

                }
                else {
                    return false;
                }
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
        function isTagQuotesBackSlash(obj, event) {

            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;

            if (keyCode == 39) {
                //single quote also right arrow when key press
                //  return false;
            }
            else if (keyCode == 34) {//double quotes
                return false;
            }
            else if (keyCode == 92) {
                // \ back slash
                return false;
            }
            else if (keyCode == 60 || keyCode == 62) {
                //< and >
                return false;
            }
        }

        // for replacing <> tags
        function ReplaceTag(obj, evt) {

            // replacing < and > tags
            var WithoutReplace = document.getElementById(obj).value;

            var replaceText1 = WithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2.trim();


        }
        function ReplaceTagAlphabetValidity(obj, evt) {

            // replacing < and > tags
            var WithoutReplace = document.getElementById(obj).value;

            var replaceText1 = WithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var QuoteValidity = document.getElementById(obj).value = replaceText2.trim();
            if (isNaN(QuoteValidity)) {
                document.getElementById(obj).value = '';
            }
            return false;
        }




        //<!-- Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TXTBOX
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }
        // for not allowing enter
        function DisableEnter(evt) {
           // alert('hi');
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }


        //  End -->>
        function ShowHidden() {
            var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
            alert('PERIOD WISE Main ' + h);
            var I = document.getElementById("<%=HiddenField2.ClientID%>").value;
            alert('DAY WISE Main ' + I);
            var MainCancDtlld = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value
            alert('MainCancDtlld ' + MainCancDtlld);
            return false;
        }


        // not to be taken for other form  other thsn this table creation
        function isNumber(objSource, objDestntn, evt) {
            // KEYCODE FOR. AND DELETE IS SAME IN KEY PRESS DIFFERENT IN KEY DOWN AND UP
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //  alert(keyCodes);
            var ObjVal = document.getElementById(objSource).value;
            if (keyCodes == 13) {
                document.getElementById(objDestntn).focus();
                if (objDestntn != "cphMain_btnSave") {
                    $noC("#" + objDestntn).select();
                }
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
                // . period and numpad . period
            else if (keyCodes == 190 || keyCodes == 110) {
                var ret = true;



                var count = ObjVal.split('.').length - 1;

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

        function isTagName(Srcobj, Dstnobj, x, event) {
            //for item name and unit name
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;

            // alert(keyCode);
            if (keyCode == 13) {
                document.getElementById(Dstnobj).focus();
                //  $noC("#" + Dstnobj).select();
                return false;
            }
            else if (keyCode == 39) {
                //single quote also right arrow when key press
                //  return false;
            }
            else if (keyCode == 34) {//double quotes
                return false;
            }
            else if (keyCode == 92) {
                // \ back slash
                return false;
            }
            else if (keyCode == 60 || keyCode == 62) {
                //< and >
                return false;
            }

        }
        function isTagDate(Srcobj, Dstnobj, x, event) {

            //    alert("The Unicode key code is: " + event.keyCode);
            var keyCodes = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            var charCode = (event.which) ? event.which : event.keyCodes;
            // alert('isTagDate');

            //    alert(keyCodes);
            if (keyCodes == 13) {
                //  document.getElementById(Dstnobj).focus();
                //   return false;

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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
                // -   given or as'-' have different keycode in browsers
            else if (keyCodes == 173 || keyCodes == 189) {
                return true;

            }

            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    return false;
                }
                return ret;
            }


        }
        function isTagDateEnter(Srcobj, Dstnobj, x, event) {


            var keyCodes = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            var charCode = (event.which) ? event.which : event.keyCodes;
            // alert('isTagDate');

            // alert(keyCodes);
            if (keyCodes == 13) {
                document.getElementById(Dstnobj).focus();
                return false;

            }


        }

        function parseDate(str) {
            //   var t = str.match(/^(\d{2})\/(\d{2})\/(\d{4})$/);  //dd/mm/yyyy
            var t = str.match(/^(\d{2})-(\d{2})-(\d{4})$/);//dd-mm-yyyy
            if (t !== null) {
                var d = +t[1], m = +t[2], y = +t[3];

                var date = new Date(y, m - 1, d);
                if (date.getFullYear() === y && date.getMonth() === m - 1) {
                    return true;
                }
            }
            return false;
        }


        // For CHECKING TIME
        function TimeCheck(obj, x, rtn) {

            //   alert('TimeCheck ' + obj);
            var ret = true;
            var Val = document.getElementById(obj + x).value;
            //date
            var Rcptdate = document.getElementById(obj + x).value;


            if (Rcptdate == "") {
                ret = false;
            }
            else {
                var RCPTdata = Rcptdate.split("-");
                if (isNaN(parseInt(RCPTdata[0])) == true || isNaN(parseInt(RCPTdata[1])) == true || isNaN(parseInt(RCPTdata[2])) == true) {

                    // alert('RCPTdata[1] ' + RCPTdata[1]);
                    ret = false;
                    document.getElementById('divErrorNotification').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Please Enter a valid date !";
                }
                else {



                    if (isNaN(Date.parse(RCPTdata[2] + "-" + RCPTdata[1] + "-" + RCPTdata[0]))) {
                        //alert('Rcptdate ' + Rcptdate);
                        ret = false;
                        document.getElementById('divErrorNotification').style.visibility = "visible";
                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Please Enter a valid date !";
                        //  alert(RCPTdata + ret);
                    }
                    else {

                        var FormatDatearr = Rcptdate.split("-");
                        var txtDay = FormatDatearr[0];
                        var txtMonth = FormatDatearr[1];
                        var txtYear = FormatDatearr[2];

                        if (txtDay < 10) {
                            txtDay = "0" + parseInt(txtDay);
                        }
                        if (txtMonth < 10) {
                            txtMonth = "0" + parseInt(txtMonth);
                        }


                        document.getElementById(obj + x).value = txtDay + '-' + txtMonth + '-' + txtYear;
                        if (isNaN(Date.parse(txtYear + "-" + txtMonth + "-" + txtDay))) {

                            ret = false;
                            document.getElementById('divErrorNotification').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Please Enter a valid date !";
                            //  alert(RCPTdata + ret);
                        }
                        if (parseDate(document.getElementById(obj + x).value) == false) {

                            ret = false;
                            document.getElementById('divErrorNotification').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Please Enter a valid date !";
                            //  alert(RCPTdata + ret);
                        }
                    }

                }
            }
            if (ret == false) {

                document.getElementById(obj + x).value = "";
            }

                //if true
            else {



                var RcptdatepickerDate = Rcptdate;
                var RarrDatePickerDate = RcptdatepickerDate.split("-");
                var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);
                // alert('RdateDateCntrlr ' + RdateDateCntrlr);

                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                if (RdateDateCntrlr > dateCurrentDate) {
                    document.getElementById(obj + x).style.borderColor = "Red";
                    document.getElementById(obj + x).focus();
                    document.getElementById('divErrorNotification').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, Receipt Date cannot be Greater than Current Date !.";
                    ret = false;
                }
                //  document.getElementById(obj + x).value = Rcptdate;
            }
            if (rtn == true) {
                return ret;
            }
        }

        // For adjust to decimal point also used for checking
        function ValueCheck(obj, x, rtn) {

            // alert(obj);
            var ret = true;
            var Val = document.getElementById(obj + x).value;
            if (Val == "") {
                ret = false;
            }
            else {

                var amt = parseFloat(Val);

                if (amt == 0) {

                    ret = false;

                }
            }
            if (ret == false) {
                var num = 0;
                var n = 0;
                // for floatting number adjustment from corp global
                var FloatingValue = 0;


                if (obj == 'txtAmnt') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }

                if (FloatingValue != "") {

                    n = num.toFixed(FloatingValue);
                }

                document.getElementById(obj + x).value = n;
            }

                //if true
            else {

                var amt = parseFloat(Val);
                var num = amt;
                var n = Val;

                // for floatting number adjustment from corp global
                var FloatingValue = 0;

                if (obj == 'txtAmnt') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }

                if (FloatingValue != "") {

                    n = num.toFixed(FloatingValue);
                }
                document.getElementById(obj + x).value = n;
            }
            if (rtn == true) {
                return ret;
            }
        }
    </script>
    <style>
        .fillform {
            width: 100%;
        }

        .subform {
            float: left;
            margin-left: 38.8%;
        }

        .leads_field:focus {
            box-shadow: 0px 0px 4px 2.5px #bbf2cf;
            border: 1px solid #bbf2cf;
        }

        .BillngEntryField:focus {
            box-shadow: 0px 0px 3px 2px #bbf2cf;
            border: 0px solid #bbf2cf;
        }

        .BillngEntryFieldCopy:focus {
            box-shadow: 0px 0px 3px 2px #bbf2cf;
            /*border: 0px solid #bbf2cf;*/
        }

        .leads_form {
            font-family: Calibri;
            padding-bottom: 2%;
            overflow-x: auto;
            background: #f4f6f0;
            margin: 0 0 5px;
        }

        .leads_field_txtarea2 {
            width: 99.5% !important;
            resize: none;
        }

        .leads_des {
            margin: 0% 1.5% 0.5%;
            width: 96%;
        }

        .leads_form_right {
            /*margin-bottom:1%;*/
        }

        .leads_form_left {
            /*margin-bottom:1%;*/
        }

        input[type="radio"] {
            display: inline;
            cursor: pointer;
        }

            input[type="radio"]:hover, input[type="radio"]:focus {
                box-shadow: 0px 0px 4px 2.5px #bbf2cf;
                border: 1px solid #bbf2cf;
            }

        .leads_field {
            height: 25px;
            font-family: calibri;
            font-size: 15px;
        }

        .leads_name {
            width: 296px !important;
        }

        .leads_form h3 {
            font-size: 15px;
        }

        .cont_rght {
            width: 99.5%;
            padding-top :0.5% !important;
        }

            .cont_rght h2 {
                float: none;
                color: rgb(83, 101, 51);
                margin: 0 0 0px;
                font-size: 17px;
            }
           .ui-autocomplete {
            /*width: 32% !important;*/
            max-width:32% !important;
            max-height: 190px !important;
        }
       .TimeEntry .ui-autocomplete {
            /*width: 22% !important;*/
            max-height: 190px !important;
        }
    </style>

    <style type="text/css">
        .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            /*width: 218px;*/
            border: 1px solid #B0BECA;
            max-height: 140px;
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
    <style type="text/css">
        .TableHeader {
            background-color: #A4B487;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 30px;
        }






        #myTable {
            background-color: #039ED1;
            color: white;
            font-weight: bold;
            line-height: 30px;
        }
    </style>


    <%-- test table scripts start --%>

    <%--auto completion files--%>



    <%--<script src="../../../JavaScript/jquery-1.8.3.min.js"></script>--%>



    <script type="text/javascript">



        var $noC = jQuery.noConflict();
        var rowCount = 0;
        //rowCount for uniquness
        //row index add(+) and (-)delete count based on action
        var RowIndex = 0;


        function addMoreRows(frm, boolFocus, JobMode, boolAppendorNot, row_index, TableName) {
            //   alert('addMoreRows-TableName ' + TableName);
            if (TableName == "TableaddedRowsPW") {
                document.getElementById('divErrorNotification').style.visibility = "hidden";
                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

            }
            else if (TableName == "TableaddedRowsDW") {
                document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";

            }


        rowCount++;
        RowIndex++;



            //    alert('ADD');
            //   alert(RowIndex.toString());
        document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
            recRow += '<td style="width: 2.8%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -3%;" >' + RowIndex.toString() + ' </div></td>';
            if (JobMode == 1) {
                recRow += ' <td id="tdJobSelect' + rowCount + '" style="width: 27.2%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98.2%;margin-left: 0.1%;" id="txtselectorJob' + rowCount + '" class="BillngEntryField" type="text"  value="--Select Job--"  onkeypress="return isTagName(\'txtselectorJob' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return ChangeJobMode(\'txtselectorJob\',' + rowCount + ',\'' + TableName + '\', event)"   onblur="return BlurJSJobVhclPrjct(\'txtselectorJob\',' + rowCount + ',\'Job\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorJob\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorJobId' + rowCount + '"  value="--Select Job--" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorJobName' + rowCount + '"  value="--Select Job--" type="text" maxlength=100  /></td>';

            }
            else if (JobMode == 2) {


                recRow += ' <td id="tdJobText' + rowCount + '"  style="width: 27.2%;">';
                recRow += ' <input id="txtJob' + rowCount + '"  class="BillngEntryField"  type="text" onkeypress="return isTagName(\'txtJob' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)" onkeydown="return ChangeJobMode(\'txtJob\',' + rowCount + ',\'' + TableName + '\', event)"    onblur="return BlurJSTXTJob(\'txtJob\',' + rowCount + ',\'' + TableName + '\')" onfocus="FocusTXTJob(\'txtJob\',' + rowCount + ',event)" maxlength=100 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%; background-color: rgb(231, 255, 185);"/>';
                recRow += '   </td> ';
            }

            recRow += ' <td id="tdVhclSelect' + rowCount + '" style="width: 22.5%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" id="txtselectorVhcl' + rowCount + '" class="BillngEntryField" type="text"  value="--Select Vehicle--"  onkeypress="return isTagName(\'txtselectorVhcl' + rowCount + '\',\'txtselectorPrjct' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSJobVhclPrjct(\'txtselectorVhcl\',' + rowCount + ',\'Vehicle\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorVhcl\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="--Select Vehicle--" type="text"   /></td>';
            recRow += ' <td  style="display: none;"><input id="txtselectorVhclName' + rowCount + '"  value="--Select Vehicle--" type="text" maxlength=100  /></td>';

            recRow += ' <td id="tdPrjctSelect' + rowCount + '" style="width: 22.5%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 97.8%;margin-left: 0.1%;" id="txtselectorPrjct' + rowCount + '" class="BillngEntryField" type="text"  value="--Select Project--"  onkeypress="return isTagName(\'txtselectorPrjct' + rowCount + '\',\'txtselectorFrmTime' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSJobVhclPrjct(\'txtselectorPrjct\',' + rowCount + ',\'Project\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorPrjct\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorPrjctId' + rowCount + '"  value="--Select Project--" type="text"   /></td>';
            recRow += ' <td  style="display: none;"><input id="txtselectorPrjctName' + rowCount + '"  value="--Select Project--" type="text" maxlength=100  /></td>';


            recRow += ' <td id="tdFrmTimeSelect' + rowCount + '" style="width: 8%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorFrmTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="--Select Time--"  onkeypress="return isTagName(\'txtselectorFrmTime' + rowCount + '\',\'txtselectorToTime' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSTime(\'txtselectorFrmTime\',' + rowCount + ',\'Time\',\'' + TableName + '\')" onfocus="return FocusJSTime(\'txtselectorFrmTime\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorFrmTimeId' + rowCount + '"  value="--Select Time--" type="text" maxlength=100  /></td>';

            recRow += ' <td id="tdToTimeSelect' + rowCount + '" style="width: 8%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorToTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="--Select Time--"  onkeypress="return isTagName(\'txtselectorToTime' + rowCount + '\',\'tdIndvlAddMoreRowPic' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSTime(\'txtselectorToTime\',' + rowCount + ',\'Time\',\'' + TableName + '\')" onfocus="return FocusJSTime(\'txtselectorToTime\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorToTimeId' + rowCount + '"  value="--Select Time--" type="text" maxlength=100  /></td>';




            recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true,\'' + TableName + '\',false);"  style="  cursor: pointer;"></td>';
            recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\',true,\'' + TableName + '\');"    style=" cursor: pointer;" ></td>';


            recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
            recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
            recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';
            // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';
            if (JobMode == 1) {
                recRow += '<td id="tdJobMode' + rowCount + '" style="display: none;">1</td>';
            }
            else if (JobMode == 2) {
                recRow += '<td id="tdJobMode' + rowCount + '" style="display: none;">2</td>';
            }

            recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
            recRow += '</tr>';





            if (boolAppendorNot == false) {
                //to append
                jQuery('#' + TableName).append(recRow);
            }
            else {

                // to insert in perticular position
                var $NoAppnd = jQuery.noConflict();
                if (parseInt(row_index) != 0) {
                    $NoAppnd('#' + TableName + ' > tbody > tr').eq(parseInt(row_index) - 1).after(recRow);
                }
                else {

                    var TableRowCount = document.getElementById(TableName).rows.length;

                    if (parseInt(TableRowCount) != 0) {
                        $NoAppnd('#' + TableName + ' > tbody > tr').eq(parseInt(row_index)).before(recRow);
                    }
                    else {
                        //if table row count is 0
                        jQuery('#' + TableName).append(recRow);
                    }
                }




            }


            var $au = jQuery.noConflict();

            (function ($au) {
                $au(function () {
                    selectorToAutocompleteVehicle('txtselectorVhcl', rowCount);
                    selectorToAutocompleteProject('txtselectorPrjct', rowCount);
                    selectorToAutocompleteTime('txtselectorFrmTime', rowCount, TableName);
                    selectorToAutocompleteTime('txtselectorToTime', rowCount, TableName);
                    //$('#selectorItem' + rowCount).selectToAutocomplete();

                    $au('form').submit(function () {

                        //   alert($au(this).serialize());


                        //   return false;
                    });
                });
            })(jQuery);

            //for renumbering
            ReNumberTable(TableName);


            if (JobMode == 1) {
                // var $au = jQuery.noConflict();

                (function ($au) {
                    $au(function () {
                        selectorToAutocompleteJob('txtselectorJob', rowCount);
                        //$('#selectorItem' + rowCount).selectToAutocomplete();

                        $au('form').submit(function () {

                            //   alert($au(this).serialize());


                            //   return false;
                        });
                    });
                })(jQuery);
                //have to look into it
                //  PopulateList(rowCount);
                //-------------------------------------------------------------

                if (boolFocus == true) {
                    document.getElementById("txtselectorJob" + rowCount).focus();
                    // $noC("div.Cls" + rowCount + " input.ui-autocomplete-input").select();
                    $noC("#txtselectorJob" + rowCount).select();
                }

            }

            else if (JobMode == 2) {

                if (boolFocus == true) {
                    document.getElementById("txtJob" + rowCount).focus();

                }
            }


            //  alert('boolFocus ' + boolFocus);

            //    alert('add rows');


        }

    //    json[key].JobId, json[key].JobName, json[key].VhclNumbr, json[key].VhclId, json[key].PrjctId, json[key].PrjctName, json[key].FromTime, json[key].ToTime, json[key].JobMode, json[key].txtJobName, json[key].TransDtlId, 'TableaddedRowsDW'
        function EditListRows(EditJobId, EditJobName, EditVhclNumbr, EditVhclId, EditPrjctId, EditPrjctName, EditFromTime, EditToTime, EditJobMode, EditTxtJobName, EditDtlId, TableName) {

  
            //  alert('EditDtlId ' + EditDtlId);// && EditHike != "" && EditAmount != "" && EditStockStatus != ""
            if (EditJobId.toString() != "" && EditVhclNumbr != "" && EditVhclId != "" && EditPrjctId != "" && EditPrjctName != "" && EditFromTime != "" && EditToTime != "" && EditJobMode != "" && EditDtlId != "" && TableName != "") {


                rowCount++;
                RowIndex++;




                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 2.8%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -3%;" >' + RowIndex.toString() + ' </div></td>';
                if (parseInt(EditJobMode) == 1) {
                    recRow += ' <td id="tdJobSelect' + rowCount + '" style="width: 27.2%;"><div class="Cls' + rowCount + '">';
                    recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98.2%;margin-left: 0.1%;" id="txtselectorJob' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditJobName + '"  onkeypress="return isTagName(\'txtselectorJob' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return ChangeJobMode(\'txtselectorJob\',' + rowCount + ',\'' + TableName + '\', event)"   onblur="return BlurJSJobVhclPrjct(\'txtselectorJob\',' + rowCount + ',\'Job\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorJob\',' + rowCount + ',event)"  maxlength=100 /> ';
                    recRow += ' </div> </td> ';
                    recRow += ' <td  style="display: none;"><input id="txtselectorJobId' + rowCount + '"  value="' + EditJobId + '" type="text"   /></td>';
                    recRow += ' <td  style="display: none;"><input id="txtselectorJobName' + rowCount + '"  value="' + EditJobName + '" type="text" maxlength=100  /></td>';

                }
                else if (parseInt(EditJobMode) == 2) {


                    recRow += ' <td id="tdJobText' + rowCount + '"  style="width: 27.2%;">';
                    recRow += ' <input id="txtJob' + rowCount + '"  class="BillngEntryField"  type="text" value="' + EditTxtJobName + '" onkeypress="return isTagName(\'txtJob' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)" onkeydown="return ChangeJobMode(\'txtJob\',' + rowCount + ',\'' + TableName + '\', event)"    onblur="return BlurJSTXTJob(\'txtJob\',' + rowCount + ',\'' + TableName + '\')" onfocus="FocusTXTJob(\'txtJob\',' + rowCount + ',event)" maxlength=100 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%; background-color: rgb(231, 255, 185);"/>';
                    recRow += '   </td> ';
                }

                recRow += ' <td id="tdVhclSelect' + rowCount + '" style="width: 22.5%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" id="txtselectorVhcl' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditVhclNumbr + '"  onkeypress="return isTagName(\'txtselectorVhcl' + rowCount + '\',\'txtselectorPrjct' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSJobVhclPrjct(\'txtselectorVhcl\',' + rowCount + ',\'Vehicle\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorVhcl\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="' + EditVhclId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorVhclName' + rowCount + '"  value="' + EditVhclNumbr + '" type="text" maxlength=100  /></td>';

                recRow += ' <td id="tdPrjctSelect' + rowCount + '" style="width: 22.5%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 97.8%;margin-left: 0.1%;" id="txtselectorPrjct' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditPrjctName + '"  onkeypress="return isTagName(\'txtselectorPrjct' + rowCount + '\',\'txtselectorFrmTime' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSJobVhclPrjct(\'txtselectorPrjct\',' + rowCount + ',\'Project\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorPrjct\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorPrjctId' + rowCount + '"  value="' + EditPrjctId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorPrjctName' + rowCount + '"  value="' + EditPrjctName + '" type="text" maxlength=100  /></td>';


                recRow += ' <td id="tdFrmTimeSelect' + rowCount + '" style="width: 8%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorFrmTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="' + EditFromTime + '"  onkeypress="return isTagName(\'txtselectorFrmTime' + rowCount + '\',\'txtselectorToTime' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSTime(\'txtselectorFrmTime\',' + rowCount + ',\'Time\',\'' + TableName + '\')" onfocus="return FocusJSTime(\'txtselectorFrmTime\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorFrmTimeId' + rowCount + '"  value="' + EditFromTime + '" type="text" maxlength=100  /></td>';

                recRow += ' <td id="tdToTimeSelect' + rowCount + '" style="width: 8%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorToTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="' + EditToTime + '"  onkeypress="return isTagName(\'txtselectorToTime' + rowCount + '\',\'tdIndvlAddMoreRowPic' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSTime(\'txtselectorToTime\',' + rowCount + ',\'Time\',\'' + TableName + '\')" onfocus="return FocusJSTime(\'txtselectorToTime\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorToTimeId' + rowCount + '"  value="' + EditToTime + '" type="text" maxlength=100  /></td>';


                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true,\'' + TableName + '\',false);"  style="  cursor: pointer;"></td>';
                recRow += '<td id="tdIndvlDelRow' + rowCount + '" style="width: 1.5%; padding-left: 1px;"><input id="tdIndvlDelRowPic' + rowCount + '" type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\',true,\'' + TableName + '\');"    style=" cursor: pointer;" ></td>';


                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + EditDtlId + '</td>';
                // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';
                if (parseInt(EditJobMode) == 1) {
                    recRow += '<td id="tdJobMode' + rowCount + '" style="display: none;">1</td>';
                }
                else if (parseInt(EditJobMode) == 2) {
                    recRow += '<td id="tdJobMode' + rowCount + '" style="display: none;">2</td>';
                }

                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';

             



                jQuery('#' + TableName).append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
                //  document.getElementById("selectorItem" + rowCount).focus();
                // alert('add rows');
               // alert(document.getElementById("<%=hiddenConfirmedEntry.ClientID%>").value);
                if (document.getElementById("<%=hiddenConfirmedEntry.ClientID%>").value=="1")
                {
                    document.getElementById("txtselectorJob" + rowCount).disabled = true;
                    document.getElementById("txtselectorVhcl" + rowCount).disabled = true;
                    document.getElementById("txtselectorPrjct" + rowCount).disabled = true;
                    document.getElementById("txtselectorFrmTime" + rowCount).disabled = true;
                    document.getElementById("txtselectorToTime" + rowCount).disabled = true;
                    
                    document.getElementById("tdIndvlDelRowPic" + rowCount).disabled = true;
                }



           
                var $au = jQuery.noConflict();

                (function ($au) {
                    $au(function () {
                        selectorToAutocompleteVehicle('txtselectorVhcl', rowCount);
                        selectorToAutocompleteProject('txtselectorPrjct', rowCount);
                        selectorToAutocompleteTime('txtselectorFrmTime', rowCount, TableName);
                        selectorToAutocompleteTime('txtselectorToTime', rowCount, TableName);
                        //$('#selectorItem' + rowCount).selectToAutocomplete();

                        $au('form').submit(function () {

                            //   alert($au(this).serialize());


                            //   return false;
                        });
                    });
                })(jQuery);

                //for renumbering
                ReNumberTable(TableName);



                if (parseInt(EditJobMode) == 1) {
                    // var $au = jQuery.noConflict();

                    (function ($au) {
                        $au(function () {
                            selectorToAutocompleteJob('txtselectorJob', rowCount);
                            //$('#selectorItem' + rowCount).selectToAutocomplete();

                            $au('form').submit(function () {

                                //   alert($au(this).serialize());


                                //   return false;
                            });
                        });
                    })(jQuery);
                    //have to look into it
                    //  PopulateList(rowCount);
                    //-------------------------------------------------------------

                   

                }
                LocalStorageAdd(rowCount, TableName);

            }
            else {

                // alert('error');
            }

        }

        function ViewListRows(EditJobId, EditJobName, EditVhclNumbr, EditVhclId, EditPrjctId, EditPrjctName, EditFromTime, EditToTime, EditJobMode, EditTxtJobName, EditDtlId, TableName) {


            if (EditJobId.toString() != "" && EditVhclNumbr != "" && EditVhclId != "" && EditPrjctId != "" && EditPrjctName != "" && EditFromTime != "" && EditToTime != "" && EditJobMode != "" && EditDtlId != "" && TableName != "") {


                rowCount++;
                RowIndex++;




                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 2.8%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -3%;" >' + RowIndex.toString() + ' </div></td>';
                if (parseInt(EditJobMode) == 1) {
                    recRow += ' <td id="tdJobSelect' + rowCount + '" style="width: 27.2%;"><div class="Cls' + rowCount + '">';
                    recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98.2%;margin-left: 0.1%;" id="txtselectorJob' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditJobName + '"  onkeypress="return isTagName(\'txtselectorJob' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return ChangeJobMode(\'txtselectorJob\',' + rowCount + ',\'' + TableName + '\', event)"   onblur="return BlurJSJobVhclPrjct(\'txtselectorJob\',' + rowCount + ',\'Job\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorJob\',' + rowCount + ',event)"  maxlength=100 /> ';
                    recRow += ' </div> </td> ';
                    recRow += ' <td  style="display: none;"><input id="txtselectorJobId' + rowCount + '"  value="' + EditJobId + '" type="text"   /></td>';
                    recRow += ' <td  style="display: none;"><input id="txtselectorJobName' + rowCount + '"  value="' + EditJobName + '" type="text" maxlength=100  /></td>';

                }
                else if (parseInt(EditJobMode) == 2) {


                    recRow += ' <td id="tdJobText' + rowCount + '"  style="width: 27.2%;">';
                    recRow += ' <input disabled id="txtJob' + rowCount + '"  class="BillngEntryField"  type="text" value="' + EditTxtJobName + '" onkeypress="return isTagName(\'txtJob' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)" onkeydown="return ChangeJobMode(\'txtJob\',' + rowCount + ',\'' + TableName + '\', event)"    onblur="return BlurJSTXTJob(\'txtJob\',' + rowCount + ',\'' + TableName + '\')" onfocus="FocusTXTJob(\'txtJob\',' + rowCount + ',event)" maxlength=100 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%; background-color: rgb(231, 255, 185);"/>';
                    recRow += '   </td> ';
                }

                recRow += ' <td id="tdVhclSelect' + rowCount + '" style="width: 22.5%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" id="txtselectorVhcl' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditVhclNumbr + '"  onkeypress="return isTagName(\'txtselectorVhcl' + rowCount + '\',\'txtselectorPrjct' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSJobVhclPrjct(\'txtselectorVhcl\',' + rowCount + ',\'Vehicle\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorVhcl\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="' + EditVhclId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorVhclName' + rowCount + '"  value="' + EditVhclNumbr + '" type="text" maxlength=100  /></td>';

                recRow += ' <td id="tdPrjctSelect' + rowCount + '" style="width: 22.5%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 97.8%;margin-left: 0.1%;" id="txtselectorPrjct' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditPrjctName + '"  onkeypress="return isTagName(\'txtselectorPrjct' + rowCount + '\',\'txtselectorFrmTime' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSJobVhclPrjct(\'txtselectorPrjct\',' + rowCount + ',\'Project\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorPrjct\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorPrjctId' + rowCount + '"  value="' + EditPrjctId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorPrjctName' + rowCount + '"  value="' + EditPrjctName + '" type="text" maxlength=100  /></td>';


                recRow += ' <td id="tdFrmTimeSelect' + rowCount + '" style="width: 8%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorFrmTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="' + EditFromTime + '"  onkeypress="return isTagName(\'txtselectorFrmTime' + rowCount + '\',\'txtselectorToTime' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSTime(\'txtselectorFrmTime\',' + rowCount + ',\'Time\',\'' + TableName + '\')" onfocus="return FocusJSTime(\'txtselectorFrmTime\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorFrmTimeId' + rowCount + '"  value="' + EditFromTime + '" type="text" maxlength=100  /></td>';

                recRow += ' <td id="tdToTimeSelect' + rowCount + '" style="width: 8%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorToTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="' + EditToTime + '"  onkeypress="return isTagName(\'txtselectorToTime' + rowCount + '\',\'tdIndvlAddMoreRowPic' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSTime(\'txtselectorToTime\',' + rowCount + ',\'Time\',\'' + TableName + '\')" onfocus="return FocusJSTime(\'txtselectorToTime\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorToTimeId' + rowCount + '"  value="' + EditToTime + '" type="text" maxlength=100  /></td>';


                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input disabled id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true,\'' + TableName + '\',false);"  style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 1.5%; padding-left: 1px;"><input disabled type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\',true,\'' + TableName + '\');"    style=" cursor: pointer;" ></td>';


                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + EditDtlId + '</td>';
              // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';
                if (parseInt(EditJobMode) == 1) {
                    recRow += '<td id="tdJobMode' + rowCount + '" style="display: none;">1</td>';
                }
                else if (parseInt(EditJobMode) == 2) {
                    recRow += '<td id="tdJobMode' + rowCount + '" style="display: none;">2</td>';
                }

                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';





                jQuery('#' + TableName).append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
              //  document.getElementById("selectorItem" + rowCount).focus();
              // alert('add rows');


                if (document.getElementById("<%=hiddenConfirmedEntry.ClientID%>").value == "1") {
                    document.getElementById("txtselectorJob" + rowCount).disabled = true;
                    document.getElementById("txtselectorVhcl" + rowCount).disabled = true;
                    document.getElementById("txtselectorPrjct" + rowCount).disabled = true;
                    document.getElementById("txtselectorFrmTime" + rowCount).disabled = true;
                    document.getElementById("txtselectorToTime" + rowCount).disabled = true;


                }



                var $au = jQuery.noConflict();

                (function ($au) {
                    $au(function () {
                        selectorToAutocompleteVehicle('txtselectorVhcl', rowCount);
                        selectorToAutocompleteProject('txtselectorPrjct', rowCount);
                        selectorToAutocompleteTime('txtselectorFrmTime', rowCount, TableName);
                        selectorToAutocompleteTime('txtselectorToTime', rowCount, TableName);
                        //$('#selectorItem' + rowCount).selectToAutocomplete();

                        $au('form').submit(function () {

                            //   alert($au(this).serialize());


                            //   return false;
                        });
                    });
                })(jQuery);

              //for renumbering
                ReNumberTable(TableName);



                if (parseInt(EditJobMode) == 1) {
                    // var $au = jQuery.noConflict();

                    (function ($au) {
                        $au(function () {
                            selectorToAutocompleteJob('txtselectorJob', rowCount);
                            //$('#selectorItem' + rowCount).selectToAutocomplete();

                            $au('form').submit(function () {

                                //   alert($au(this).serialize());


                                //   return false;
                            });
                        });
                    })(jQuery);
                    //have to look into it
                    //  PopulateList(rowCount);
                    //-------------------------------------------------------------



                }
                LocalStorageAdd(rowCount, TableName);

            }
            else {

              // alert('error');
            }


        }



        function removeRow(removeNum, CofirmMsg,boolAskConfirm, TableName) {
        //    alert('removeRow-TableName' + TableName);
            var blConfirm = true;
            if (boolAskConfirm == true) {
                if (confirm(CofirmMsg)) {
                    blConfirm = true;
                }
                else {
                    blConfirm = false;
                }
            }
              
            if (blConfirm == true) {

                var row_index = jQuery('#rowId_' + removeNum).index();
                var BforeRmvTableRowCount = document.getElementById(TableName).rows.length;
               // alert('BforeRmvTableRowCount' + BforeRmvTableRowCount);
                LocalStorageDelete(row_index, removeNum, TableName);
              
                jQuery('#rowId_' + removeNum).remove();
                RowIndex--;
                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();
                var TableRowCount = document.getElementById(TableName).rows.length;

                if (TableRowCount != 0) {
                    var idlast = $noC('#' + TableName + ' tr:last').attr('id');
                    //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                    //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                    if (idlast != "") {
                        var res = idlast.split("_");
                        //  alert(res[1]);
                        document.getElementById("tdInx" + res[1]).innerHTML = " ";
                        document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
                    }
                }
                else {

                    if (TableName == "TableaddedRowsPW") {


                        document.getElementById("<%=ddlTimeSlot_PeriodWise.ClientID%>").disabled = false;
                        $("div#divTimeSlotPeridWise input.ui-autocomplete-input").removeAttr('disabled');

                    }
                    else if (TableName == "TableaddedRowsDW") {


                        document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").disabled = false;
                $("div#divTimeSlotDayWise input.ui-autocomplete-input").removeAttr('disabled');

            }
                    addMoreRows(this.form, true, 1, false, 0, TableName);

                    //    document.getElementById("spanAddRow").style.opacity = "1";

                }

                //  alert('BforeRmvTableRowCount ' + BforeRmvTableRowCount);
                //  LocalStorageDelete(row_index,removeNum);

                //     alert('BforeRmvTableRowCount ' + BforeRmvTableRowCount);
                //    alert('row_index ' + row_index);
                //for focussing to next or previous accordingly
                // While delete, then focus to be moved to next row (If there is any row below of current row) 
                // While delete, then focus to be moved to previous row (If there is any row above of current row) 
                if (BforeRmvTableRowCount > 1) {

                    if ((BforeRmvTableRowCount - 1) == row_index) {

                        var table = document.getElementById(TableName);
                        var preRowId = table.rows[row_index - 1].id;

                        if (preRowId != "") {
                            var res = preRowId.split("_");
                            if (res[1] != "") {


                                document.getElementById("txtselectorJob" + res[1]).focus();
                                $noCon("#txtselectorJob" + res[1]).select();
                                ReNumberTable(TableName);

                            }
                        }
                    }
                    else {
                        //     alert('entered 2 case');
                        var table = document.getElementById(TableName);
                        var NxtRowId = table.rows[row_index].id;
                        //  alert('NxtRowId ' + NxtRowId);
                        if (NxtRowId != "") {
                            var res = NxtRowId.split("_");
                            if (res[1] != "") {

                                document.getElementById("txtselectorJob" + res[1]).focus();
                                $noCon("#txtselectorJob" + res[1]).select();
                                ReNumberTable(TableName);

                            }
                        }


                    }
                }
             //   alert('removeRow-end' );
                return false;
            }
            else {
            //    alert('removeRow-end' );
               return false;

            }
        }


        function removeRowJobMode(removeNum, CofirmMsg, boolAskConfirm, TableName) {
            var blConfirm = true;
            if (boolAskConfirm == true) {
                if (confirm(CofirmMsg)) {
                    blConfirm = true;
                }
                else {
                    blConfirm = false;
                }
            }


            if (blConfirm == true) {

                var evt = document.getElementById("tdEvt" + removeNum).innerHTML;
                var detailId = document.getElementById("tdDtlId" + removeNum).innerHTML;
                //   var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;




                var Jmode = document.getElementById('tdJobMode' + removeNum).innerText;

                var row_index = jQuery('#rowId_' + removeNum).index();

                jQuery('#rowId_' + removeNum).remove();
                RowIndex--;
                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


                if (Jmode == "1") {

                    addMoreRows(this.form, true, 2, true, row_index, TableName);
                    //    alert('fyn1');
                    ReNumberTable(TableName);


                }
                else if (Jmode == "2") {

                    addMoreRows(this.form, true, 1, true, row_index, TableName);
                    ReNumberTable(TableName);



                }


                //to get id of the row in table by row index
                var RowIdNewRow = $noC('#' + TableName + ' tr').eq(row_index).attr('id');
                if (RowIdNewRow != "") {
                    var resNew = RowIdNewRow.split("_");
                    //  alert(res[1]);
                    var xNewRow = resNew[1];

                }
                // alert('xNewRow' + xNewRow.toString());
                document.getElementById("tdEvt" + xNewRow).innerHTML = evt;
                document.getElementById("tdDtlId" + xNewRow).innerHTML = detailId;
                //update to default value when adding row
                LocalStorageEdit(xNewRow, row_index, TableName);
                document.getElementById("tdSave" + xNewRow).innerHTML = "saved";
                document.getElementById("tdChanged" + xNewRow).innerHTML = "Changed";

                var TableRowCount = document.getElementById(TableName).rows.length;
                //   alert(TableRowCount);
                if (TableRowCount != row_index + 1) {



                    document.getElementById("tdInx" + xNewRow).innerHTML = xNewRow;
                    document.getElementById("tdIndvlAddMoreRow" + xNewRow).style.opacity = "0.3";

                }
                else {

                }

                return true;
            }
            else {
                return false;
            }

        }

    </script>
    
    <script>
        //start-0009    
       
        function ChangeJSToDate() {
          
            FromToDateCheck();
            var dateCheck = document.getElementById("<%=hiddenDateCheck.ClientID%>").value;
           
                if (dateCheck == "true") {
                    return true;
                }
                else if (dateCheck == "false") {

                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtFromDate.ClientID%>").focus();
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, From Date And To Date cannot be overlapped !.";

               return false;
            }

         }
        function FromToDateCheck() {
           
            //web method for drop down of narrations for common narration
             var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
             var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            var EmpID = document.getElementById("<%=hiddenEmpJSId.ClientID%>").value;;
             var FromDate=document.getElementById("<%=txtFromDate.ClientID%>").value;
            var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;
            var JobShdlID = document.getElementById("<%=HiddenFieldJobScdlID.ClientID%>").value;;


           


            //alert(FromDate + 'hi' + ToDate);
            if (CorpId != '' && CorpId != null && OrgId != '' && OrgId != null && FromDate != '' && FromDate != null && ToDate != '' && ToDate != null && EmpID != '' && EmpID != null) {
                //  alert('hi entered');
                 $.ajax({
                     type: "POST",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     url: "flt_Job_Shdl.aspx/FromToDateDetails",
                     data: '{corporateId: "' + CorpId + '",organisationId:"' + OrgId + '" ,EmpID:"' + EmpID + '",FromDate:"' + FromDate + '",ToDate:"' + ToDate + '",JobShdlID:"' + JobShdlID + '"}',
                     dataType: "json",
                     success: function (data) {
                         //alert('success');
                         if (data.d != '') {
                            // alert('res' + data.d);
                          
                            document.getElementById("<%=hiddenDateCheck.ClientID%>").value = data.d;
                              
                           
                          }
                     },
                     error: function (result) {
                         // alert("Error");
                     }
                 });

             }
         }
        //stop-0009
    </script>
    <script>
        var $noCon = jQuery.noConflict();
        function ChangeTimeSlot(obj) {
         //   alert(obj);
            var $noCT = jQuery.noConflict();
            var PreviousVal = document.getElementById("<%=hiddenPreviousTimeSlot.ClientID%>").value;
       //     alert('PreviousVal' + PreviousVal);
            var DropdownTimeSlot = '';
            if (obj == 'ddlTimeSlot_PeriodWise') {
                DropdownTimeSlot = document.getElementById("<%=ddlTimeSlot_PeriodWise.ClientID%>");

            }
            else if (obj == 'ddlTimeSlot_DayWise') {
                DropdownTimeSlot = document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>");
            }


        var SelectedValueTimeSlot = DropdownTimeSlot.value;

        if (SelectedValueTimeSlot != PreviousVal) {
            //  alert('i');
            if (SelectedValueTimeSlot == '--SELECT TIME SLOT--') {

                SelectedValueTimeSlot = 0;
            }
            if (SelectedValueTimeSlot != 0) {

                if (obj == 'ddlTimeSlot_PeriodWise') {
                    TimeSlotSelected(SelectedValueTimeSlot, 'PeriodWise');
                    $noCon("div#divTimeSlotPeridWise input.ui-autocomplete-input").css("borderColor", "");

                   
                }
                else if (obj == 'ddlTimeSlot_DayWise') {
                    TimeSlotSelected(SelectedValueTimeSlot, 'DayWise');
                    $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").css("borderColor", "");

                 
                }
                IncrmntConfrmCounter();
            }
            else {
                if (obj == 'ddlTimeSlot_PeriodWise') {
                    TimeSlotSelected('0', 'PeriodWise');
                }
                else if (obj == 'ddlTimeSlot_DayWise') {
                    TimeSlotSelected('0', 'DayWise');

                }
                IncrmntConfrmCounter();
                return false;
            }
        }
        else {
            return false;
        }
    }
        function IsDateSelected(TableName) {
            var DropdownTimeSlot = '';
            var SelectedValueTimeSlot = '';
            if (TableName == "TableaddedRowsPW") {
                DropdownTimeSlot = document.getElementById("<%=ddlTimeSlot_PeriodWise.ClientID%>");
                SelectedValueTimeSlot = DropdownTimeSlot.value;
            }
            else if (TableName == "TableaddedRowsDW") {
                DropdownTimeSlot = document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>");
                    SelectedValueTimeSlot = DropdownTimeSlot.value;
                }

            if (SelectedValueTimeSlot == '--SELECT TIME SLOT--' || SelectedValueTimeSlot == '') {

                if (TableName == "TableaddedRowsPW") {
                    $noCon("div#divTimeSlotPeridWise input.ui-autocomplete-input").css("borderColor", "Red");
                    $noCon("div#divTimeSlotPeridWise input.ui-autocomplete-input").focus();
                    $noCon("div#divTimeSlotPeridWise input.ui-autocomplete-input").select();
                    document.getElementById("<%=ddlTimeSlot_PeriodWise.ClientID%>").focus();
                }
                else if (TableName == "TableaddedRowsDW") {
                    $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").css("borderColor", "Red");
                    $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").focus();
                    $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").select();
                    document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").focus();

                }
                //     alert('IsTimeSlotPeriodWiseSelected');
            return false;
        }
        else {
            return true;

        }
        }

        function IsWeekDaysSelected() {
            var ret = true;
            document.getElementById('divWeekdays').style.backgroundColor = "";
            if (document.getElementById("<%=hiddenWeekDayId.ClientID%>").value.trim() == "")
            {
                document.getElementById('divWeekdays').style.backgroundColor = "Red";
                ret = false;
            }
            return ret;
        }


        function IsTimeSlotSelected(TableName) {

            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";

            var DropdownTimeSlot = '';
            var SelectedValueTimeSlot = '';
            if (TableName == "TableaddedRowsPW") {
                DropdownTimeSlot = document.getElementById("<%=ddlTimeSlot_PeriodWise.ClientID%>");
                SelectedValueTimeSlot = DropdownTimeSlot.value;
                
            }
            else if (TableName == "TableaddedRowsDW") {
                DropdownTimeSlot = document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>");
                SelectedValueTimeSlot = DropdownTimeSlot.value;
            }
           

           

            var fromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;
           

               
              
      





        if (SelectedValueTimeSlot == '--SELECT TIME SLOT--' || SelectedValueTimeSlot == ''||fromDate == '' || ToDate == '') {

                if (TableName == "TableaddedRowsPW") {
                    $noCon("div#divTimeSlotPeridWise input.ui-autocomplete-input").css("borderColor", "Red");
                    $noCon("div#divTimeSlotPeridWise input.ui-autocomplete-input").focus();
                    $noCon("div#divTimeSlotPeridWise input.ui-autocomplete-input").select();
                    document.getElementById("<%=ddlTimeSlot_PeriodWise.ClientID%>").focus();
                }
                else if (TableName == "TableaddedRowsDW") {
                    $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").css("borderColor", "Red");
                    $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").focus();
                    $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").select();
                    document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").focus();

                }
            if (ToDate == "") {
                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "red";
                 document.getElementById("<%=txtToDate.ClientID%>").focus();
             }
             if (fromDate == "") {
                 document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=txtFromDate.ClientID%>").focus();

                }
                  //     alert('IsTimeSlotPeriodWiseSelected');
                return false;
            }
            else {
                return true;

            }
        }
     
        function getPreviousDDLTimeSlot_SelectedVal(objName) {
         //   alert('getPreviousDDLTimeSlot_SelectedVal' + objName)
            document.getElementById("<%=hiddenPreviousTimeSlot.ClientID%>").value = '--SELECT TIME SLOT--';
            var DropdownList = '';
                if (objName == 'ddlTimeSlot_PeriodWise') {
                     DropdownList = document.getElementById('<%=ddlTimeSlot_PeriodWise.ClientID %>');
               
            }
            else if (objName == 'ddlTimeSlot_DayWise') {
                 DropdownList = document.getElementById('<%=ddlTimeSlot_DayWise.ClientID %>');
              
            }
            var SelectedValue = DropdownList.value;
            document.getElementById("<%=hiddenPreviousTimeSlot.ClientID%>").value = SelectedValue;
    }

    //this function is to RE-NUMBER table when deletion .as it show duplicate sl num when deleted othre than last row
    function ReNumberTable(TableName) {
        //if (idlast != "") {
        //    var res = idlast.split("_");

        //    document.getElementById("tdInx" + res[1]).innerHTML = " ";
        //    document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
        //}
        //   alert('ReNumberTable-TableName ' + TableName);
        var table = "";


        table = document.getElementById(TableName);

        for (var i = 0, row; row = table.rows[i]; i++) {
            var x = "";
            // RwId = row.innerHTML;

            //iterate through rows
            //rows would be accessed using the "row" variable assigned in the for loop
            for (var j = 0, col; col = row.cells[j]; j++) {
                if (j == 0) {
                    x = col.innerHTML;
                    if (x != "") {

                        var intRecount = parseInt(i) + 1;
                        //   alert('i :' + intcount);
                        document.getElementById("divSlNum" + x).innerHTML = intRecount
                        var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                        if (SavedorNot == "saved") {
                            //  var row_index = jQuery('#rowId_' + x).index();

                            // LocalStorageEdit(x, row_index);

                        }
                    }
                }

                //iterate through columns
                //columns would be accessed using the "col" variable assigned in the for loop
                // alert(col.innerHTML);
            }
        }
    }

    function ChangeJobMode(obj, x, TableName, evt) {

        evt = (evt) ? evt : window.event;
        var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
        var charCode = (evt.which) ? evt.which : evt.keyCode;



        if (keyCodes == 120) {// both F9 AND 'x' has same code in keypress

            //return false;
            if (obj == 'txtselectorJob') {
                var boolAskConfirm = false;
                var ValueId = document.getElementById(obj + "Id" + x).value;
                //     alert(QtnItemId);
                if (ValueId != "--Select Job--") {
                    boolAskConfirm = true;
                }

                if (removeRowJobMode(x, 'Are you sure you  want to clear this row ?', boolAskConfirm, TableName) == true) {
                    //for
                }
            }
            else if (obj == 'txtJob') {
                var boolAskConfirm = false;
                var ValueName = document.getElementById(obj + x).value;

                if (ValueName != "") {
                    boolAskConfirm = true;
                }

                if (removeRowJobMode(x, 'Are you sure you  want to clear this row ?', boolAskConfirm, TableName) == true) {

                }

            }

        }
    }
    function FocusJSValue(obj, x, event) {
        //job,vehicle,project


        //for viewing over label
        var offset = $noCon("#" + obj + x).offset();

        var posY = 0;
        var posX = 0;
        posY = offset.top - 12.5;



        //  posX = 27.5;
        if (obj == "txtselectorJob") {
            posX = offset.left - 91.1;
            document.getElementById("divBlink").innerHTML = "Job";
        }
        else if (obj == "txtselectorVhcl") {
            posX = offset.left - 415.4;
            document.getElementById("divBlink").innerHTML = "Vehicle";
        }
        else if (obj == "txtselectorPrjct") {
            posX = offset.left - 683.8;
            document.getElementById("divBlink").innerHTML = "Project";
        }


        var d = document.getElementById('divBlink');
        d.style.position = "absolute";
        d.style.left = posX + '%';
        d.style.top = posY + 'px';
        document.getElementById('divBlink').style.visibility = "visible";

        document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value = "";
        document.getElementById("<%=hiddenJSNameFocus.ClientID%>").value = "";
        var ValueId = document.getElementById(obj + 'Id' + x).value;
        document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value = ValueId;
            var ValueName = document.getElementById(obj + 'Name' + x).value;
            document.getElementById("<%=hiddenJSNameFocus.ClientID%>").value = ValueName;
        //for removing text for typing friendly
            if ((document.getElementById(obj + x).value == ("--Select Job--")) || (document.getElementById(obj + x).value == ("--Select Vehicle--")) || (document.getElementById(obj + x).value == ("--Select Project--"))) {
                document.getElementById(obj + x).value = "";
            }

        }

        function FocusJSTime(obj, x, event) {



            //for viewing over label
            var offset = $noCon("#" + obj + x).offset();

            var posY = 0;
            var posX = 0;
            posY = offset.top - 12.5;



            //  posX = 27.5;
            if (obj == "txtselectorFrmTime") {
                posX = offset.left - 951.8;
                document.getElementById("divBlink").innerHTML = "From Time";
            }
            else if (obj == "txtselectorToTime") {
                posX = offset.left - 1047.1;
                document.getElementById("divBlink").innerHTML = "To Time";
            }



            var d = document.getElementById('divBlink');
            d.style.position = "absolute";
            d.style.left = posX + '%';
            d.style.top = posY + 'px';
            document.getElementById('divBlink').style.visibility = "visible";

            document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value = "";
            var ValueId = document.getElementById(obj + 'Id' + x).value;
            document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value = ValueId;

            //for removing text for typing friendly
            if (document.getElementById(obj + x).value == "--Select Time--") {
                document.getElementById(obj + x).value = "";
            }

        }


        function FocusTXTJob(obj, x, event) {
            //for viewing over label
            var offset = $noCon("#" + obj + x).offset();
            var posY = 0;
            var posX = 0;
            posY = offset.top - 12.5;

            posX = offset.left - 680;

            posX = 7.6;
            document.getElementById("divBlink").innerHTML = "Job"
            var d = document.getElementById('divBlink');
            d.style.position = "absolute";
            d.style.left = posX + '%';
            d.style.top = posY + 'px';
            document.getElementById('divBlink').style.visibility = "visible";


            document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value = "";
            var ValueName = document.getElementById(obj + x).value;
            document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value = ValueName;

        }











        function BlurJSJobVhclPrjct(obj, x, DefaultTxt, TableName) {

            //alert('BlurJSJobVhclPrjct-TableName ' + TableName);
         
            if (document.getElementById(obj + "Id" + x).value == "" || document.getElementById(obj + "Id" + x).value == "--Select " + DefaultTxt + "--") {

                document.getElementById(obj + x).value = "--Select " + DefaultTxt + "--";
            }

            var TxtName = document.getElementById(obj + x).value.trim();

            if (TxtName == "" || TxtName == "--Select " + DefaultTxt + "--") {
                document.getElementById(obj + "Id" + x).value = "--Select " + DefaultTxt + "--";
                document.getElementById(obj + "Name" + x).value = "--Select " + DefaultTxt + "--";
                document.getElementById(obj + x).value = "--Select " + DefaultTxt + "--";
            }

            var JSName = document.getElementById(obj + "Name" + x).value.trim();
            if (JSName != "" || JSName != "--Select " + DefaultTxt + "--") {
                document.getElementById(obj + x).value = JSName;
            }

           


         
            if (obj == "txtselectorVhcl") {

                var VhclId = document.getElementById("txtselectorVhclId" + x).value;

                var FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;
                var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
                if (VhclId != "--Select Vehicle--") {


                    var Details = PageMethods.prjctReadByVhcl(FromDate, ToDate, VhclId, CorpId, OrgId, function (response) {

                        if (response != "") {

                            var y = response.split(',');


                            document.getElementById("txtselectorPrjctId" + x).value = y[0];
                            document.getElementById("txtselectorPrjctName" + x).value = y[1];
                            document.getElementById("txtselectorPrjct" + x).value = y[1];

                        }
                        else {
                            document.getElementById("txtselectorPrjctId" + x).value = "--Select Project--";
                            document.getElementById("txtselectorPrjctName" + x).value = "--Select Project--";
                            document.getElementById("txtselectorPrjct" + x).value = "--Select Project--";
                        }


                    });
                }

            }







            document.getElementById('divBlink').style.visibility = "hidden";
            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
           
            if (SavedorNot == "saved") {
               
                if (IsTimeSlotSelected(TableName) == true) {
                   
                    var ValueId = document.getElementById(obj + "Id" + x).value;

                    var hiddenIdFocus = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                    if (ValueId != hiddenIdFocus) {

                        if (ValueId != "--Select " + DefaultTxt + "--") {
                            document.getElementById(obj + x).style.borderColor = "";

                            //Update to local storage


                            if (TableName == "TableaddedRowsPW") {
                                document.getElementById('divErrorNotification').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                            }
                            else if (TableName == "TableaddedRowsDW") {
                                document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";

                            }

                         LocalStorageEdit(x, row_index, TableName);


    }

    else {
        var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                            var hiddenHeadValText = document.getElementById("<%=hiddenJSNameFocus.ClientID%>").value;
                            if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                                document.getElementById(obj + x).value = hiddenHeadValText;
                                document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                                document.getElementById(obj + "Name" + x).value = hiddenHeadValText;

                            }
                        }
                    }

                }
                else {
                    var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                    var hiddenHeadValText = document.getElementById("<%=hiddenJSNameFocus.ClientID%>").value;
                    if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                        document.getElementById(obj + x).value = hiddenHeadValText;
                        document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                        document.getElementById(obj + "Name" + x).value = hiddenHeadValText;

                    }
                }

            }

            else {

                var ValueId = document.getElementById(obj + "Id" + x).value;
                var hiddenIdFocus = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                if (IsTimeSlotSelected(TableName) == true) {
                    if (ValueId != hiddenIdFocus) {
                        if (ValueId != "--Select " + DefaultTxt + "--") {
                            // alert(WBVhclId);


                            if (TableName == "TableaddedRowsPW") {
                                document.getElementById('divErrorNotification').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                            }
                            else if (TableName == "TableaddedRowsDW") {
                                document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";

                            }

                            document.getElementById(obj + x).style.borderColor = "";


                            //for saving


                            if (CheckAllRowField(x, row_index, TableName) == false) {

                                return false;

                            }

                            if (SavedorNot == " ") {
                                //  id tdSAVE is made'saved ' in localStorageAdd
                                //add to local storage
                                LocalStorageAdd(x, TableName);

                            }


                        }

                    }
                }
                else {

                    var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                    var hiddenHeadValText = document.getElementById("<%=hiddenJSNameFocus.ClientID%>").value;
                    if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                        document.getElementById(obj + x).value = hiddenHeadValText;
                        document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                        document.getElementById(obj + "Name" + x).value = hiddenHeadValText;

                    }
                    // alert('h');
                }
            }


           




            

           




        }

        function BlurJSTime(obj, x, DefaultTxt, TableName) {

            //     alert('BlurJSTime-TableName ' + TableName);


            if (document.getElementById(obj + "Id" + x).value == "" || document.getElementById(obj + "Id" + x).value == "--Select " + DefaultTxt + "--") {

                document.getElementById(obj + x).value = "--Select " + DefaultTxt + "--";
            }

            var TxtName = document.getElementById(obj + x).value.trim();

            if (TxtName == "" || TxtName == "--Select " + DefaultTxt + "--") {
                document.getElementById(obj + "Id" + x).value = "--Select " + DefaultTxt + "--";
                document.getElementById(obj + x).value = "--Select " + DefaultTxt + "--";
            }

            var JSName = document.getElementById(obj + "Id" + x).value.trim();
            if (JSName != "" || JSName != "--Select " + DefaultTxt + "--") {
                document.getElementById(obj + x).value = JSName;
            }
            //////////////////////////////
            document.getElementById('divBlink').style.visibility = "hidden";
            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (SavedorNot == "saved") {
                if (IsTimeSlotSelected(TableName) == true) {
                    var ValueId = document.getElementById(obj + "Id" + x).value;

                    var hiddenIdFocus = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                    if (ValueId != hiddenIdFocus) {

                        if (ValueId != "--Select " + DefaultTxt + "--") {
                            if (SameFromAndToTime(x, TableName) == true) {
                                if (DuplicationTimeCheck(obj, x, row_index, TableName) == true) {
                                    document.getElementById(obj + x).style.borderColor = "";

                                    //Update to local storage

                                    if (TableName == "TableaddedRowsPW") {
                                        document.getElementById('divErrorNotification').style.visibility = "hidden";
                                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                                    }
                                    else if (TableName == "TableaddedRowsDW") {
                                        document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                                        document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";

                                    }

                                    LocalStorageEdit(x, row_index, TableName);
                                }
                                else {
                                    var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                                    if (hiddenHeadValId != "") {

                                        document.getElementById(obj + x).value = hiddenHeadValId;
                                        document.getElementById(obj + "Id" + x).value = hiddenHeadValId;

                                    }
                                }
                            }
                            else {
                                var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                                if (hiddenHeadValId != "") {

                                    document.getElementById(obj + x).value = hiddenHeadValId;
                                    document.getElementById(obj + "Id" + x).value = hiddenHeadValId;

                                }
                            }
                        }

                        else {
                            var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                            if (hiddenHeadValId != "") {

                                document.getElementById(obj + x).value = hiddenHeadValId;
                                document.getElementById(obj + "Id" + x).value = hiddenHeadValId;

                            }
                        }
                    }

                }
                else {
                    var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                    if (hiddenHeadValId != "") {

                        document.getElementById(obj + x).value = hiddenHeadValId;
                        document.getElementById(obj + "Id" + x).value = hiddenHeadValId;

                    }
                }

            }

            else {
             
                var ValueId = document.getElementById(obj + "Id" + x).value;
                var hiddenIdFocus = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                if (IsTimeSlotSelected(TableName) == true) {
                   
                    if (ValueId != hiddenIdFocus) {
                      //  alert('hi' + ValueId);
                        if (ValueId != "--Select " + DefaultTxt + "--") {
                            // alert(WBVhclId);
                            //  alert('row_Index' + row_Index);
                            if (SameFromAndToTime(x, TableName) == true) {
                                if (DuplicationTimeCheck(obj, x, row_index, TableName) == true) {
                                    if (TableName == "TableaddedRowsPW") {
                                        document.getElementById('divErrorNotification').style.visibility = "hidden";
                                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                                    }
                                    else if (TableName == "TableaddedRowsDW") {
                                        document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                                        document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";

                                    }

                                    document.getElementById(obj + x).style.borderColor = "";


                                    //for saving


                                    if (CheckAllRowField(x, row_index, TableName) == false) {

                                        return false;

                                    }

                                    if (SavedorNot == " ") {
                                        //  id tdSAVE is made'saved ' in localStorageAdd
                                        //add to local storage
                                        LocalStorageAdd(x, TableName);

                                    }
                                }
                                else {

                                    var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                                    if (hiddenHeadValId != "") {

                                        document.getElementById(obj + x).value = hiddenHeadValId;
                                        document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                                    }
                                    // alert('h');
                                }
                            }
                            else {

                                var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                                if (hiddenHeadValId != "") {

                                    document.getElementById(obj + x).value = hiddenHeadValId;
                                    document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                                }
                                // alert('h');
                            }
                        }

                    }
                }
                else {

                    var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                    if (hiddenHeadValId != "") {

                        document.getElementById(obj + x).value = hiddenHeadValId;
                        document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                    }
                    // alert('h');
                }
            }
        }

        function BlurJSTXTJob(obj, x, TableName) {

            //  alert('BlurJSTXTJob-TableName ' + TableName);

            document.getElementById('divBlink').style.visibility = "hidden";
            //for replacing ',",\,<,>
            // replacing < and > tags and backslash and single and double quotes
            var JobWithoutReplace = document.getElementById(obj + x).value;

            var replaceText1 = JobWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");
            document.getElementById(obj + x).value = replaceText5.trim();
            var row_index = jQuery('#rowId_' + x).index();
            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (SavedorNot == "saved") {
                if (IsTimeSlotSelected(TableName) == true) {
                    var ValueName = document.getElementById(obj + x).value;
                    var hiddenIdFocus = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                    if (ValueName != hiddenIdFocus) {

                        if (ValueName != "") {


                            //Update to local storage


                            document.getElementById(obj + x).style.borderColor = "";

                            if (TableName == "TableaddedRowsPW") {
                                document.getElementById('divErrorNotification').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                            }
                            else if (TableName == "TableaddedRowsDW") {
                                document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";

                            }
                            //   if (RecptToCheck() == true) {
                            LocalStorageEdit(x, row_index, TableName);
                            //  }


                        }
                        else {
                            var hiddenHeadVal = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                            if (hiddenHeadVal != "") {

                                document.getElementById(obj + x).value = hiddenHeadVal;
                            }
                        }
                    }
                }
                else {

                    var hiddenHeadVal = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value.trim();

                    //     if (hiddenHeadVal != "") {

                    document.getElementById(obj + x).value = hiddenHeadVal;
                    //  }
                }
            }
            else {
                //   if (RecptToCheck() == true) {
                var ValueName = document.getElementById(obj + x).value;
                var hiddenIdFocus = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                if (IsTimeSlotSelected(TableName) == true) {
                    if (ValueName != hiddenIdFocus) {
                        if (ValueName != "") {

                            if (TableName == "TableaddedRowsPW") {
                                document.getElementById('divErrorNotification').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                            }
                            else if (TableName == "TableaddedRowsDW") {
                                document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";

                            }

                            document.getElementById(obj + x).style.borderColor = "";


                            //for saving
                            // for loading item details
                            //  ProductChangeBlurItemName(x);

                            if (CheckAllRowField(x, row_index, TableName) == false) {

                                return false;

                            }

                            if (SavedorNot == " ") {
                                //  id tdSAVE is made'saved ' in localStorageAdd
                                //add to local storage
                                LocalStorageAdd(x, TableName);

                            }

                        }

                    }
                }
                else {
                    var hiddenHeadVal = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value.trim();
                    document.getElementById(obj + x).value = hiddenHeadVal;

                }

            }
        }




        function LocalStorageAdd(x, TableName) {
            //   alert('LocalStorageAdd')
            var tbClientJobSheduling = '';
            if (TableName == "TableaddedRowsPW") {
                tbClientJobSheduling=  localStorage.getItem("tbClientJobShedulingPW");//Retrieve the stored data
            }
            else if (TableName == "TableaddedRowsDW") {
                tbClientJobSheduling = localStorage.getItem("tbClientJobShedulingDW");//Retrieve the stored data

            }
            tbClientJobSheduling = JSON.parse(tbClientJobSheduling); //Converts string to object

            if (tbClientJobSheduling == null) //If there is no data, initialize an empty array
                tbClientJobSheduling = [];
            var detailId = document.getElementById("tdDtlId" + x).innerHTML;
            //  var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
            var evt = document.getElementById("tdEvt" + x).innerHTML;
            var JobMode = document.getElementById("tdJobMode" + x).innerText;

            if (JobMode == "1") {
                if (evt == 'INS') {
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + x + "",
                        JOBID: $add("#txtselectorJobId" + x).val(),
                        JOBNAME: $add("#txtselectorJobName" + x).val(),
                        VHCLID: $add("#txtselectorVhclId" + x).val(),
                        PRJCTID: $add("#txtselectorPrjctId" + x).val(),
                        FROMTIME: $add("#txtselectorFrmTimeId" + x).val(),
                        TOTIME: $add("#txtselectorToTimeId" + x).val(),
                        EVTACTION: "" + evt + "",
                        DTLID: "0",
                        JOBMODE: "" + JobMode + ""

                    });
                }
                else if (evt == 'UPD') {
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + x + "",
                        JOBID: $add("#txtselectorJobId" + x).val(),
                        JOBNAME: $add("#txtselectorJobName" + x).val(),
                        VHCLID: $add("#txtselectorVhclId" + x).val(),
                        PRJCTID: $add("#txtselectorPrjctId" + x).val(),
                        FROMTIME: $add("#txtselectorFrmTimeId" + x).val(),
                        TOTIME: $add("#txtselectorToTimeId" + x).val(),
                        EVTACTION: "" + evt + "",
                        DTLID: "" + detailId + "",
                        JOBMODE: "" + JobMode + ""

                    });
                }

            }

            else if (JobMode == "2") {
                if (evt == 'INS') {
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + x + "",
                        JOBID: "0",
                        JOBNAME: $add("#txtJob" + x).val(),
                        VHCLID: $add("#txtselectorVhclId" + x).val(),
                        PRJCTID: $add("#txtselectorPrjctId" + x).val(),
                        FROMTIME: $add("#txtselectorFrmTimeId" + x).val(),
                        TOTIME: $add("#txtselectorToTimeId" + x).val(),
                        EVTACTION: "" + evt + "",
                        DTLID: "0",
                        JOBMODE: "" + JobMode + ""
                    });
                }
                else if (evt == 'UPD') {
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + x + "",
                        JOBID: "0",
                        JOBNAME: $add("#txtJob" + x).val(),
                        VHCLID: $add("#txtselectorVhclId" + x).val(),
                        PRJCTID: $add("#txtselectorPrjctId" + x).val(),
                        FROMTIME: $add("#txtselectorFrmTimeId" + x).val(),
                        TOTIME: $add("#txtselectorToTimeId" + x).val(),
                        EVTACTION: "" + evt + "",
                        DTLID: "" + detailId + "",
                        JOBMODE: "" + JobMode + ""

                    });
                }

            }
            tbClientJobSheduling.push(client);
            if (TableName == "TableaddedRowsPW") {
                localStorage.setItem("tbClientJobShedulingPW", JSON.stringify(tbClientJobSheduling));
                $add("#cphMain_HiddenField1").val(JSON.stringify(tbClientJobSheduling));

                document.getElementById("<%=ddlTimeSlot_PeriodWise.ClientID%>").disabled = true;
                $("div#divTimeSlotPeridWise input.ui-autocomplete-input").attr("disabled", "disabled");

            }
            else if (TableName == "TableaddedRowsDW") {
                localStorage.setItem("tbClientJobShedulingDW", JSON.stringify(tbClientJobSheduling));
                $add("#cphMain_HiddenField2").val(JSON.stringify(tbClientJobSheduling));

                document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").disabled = true;
                $("div#divTimeSlotDayWise input.ui-autocomplete-input").attr("disabled", "disabled");

            }
         
          
            

            //for calculation of total Amount
            //  CalculateTotalAmountFromHiddenField();



            // alert("The data was saved.");
            // var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
            // alert(h);

            document.getElementById("tdSave" + x).innerHTML = "saved";
            //  alert('TableName ' + TableName);
            CheckaddMoreRowsIndividual(x, true, TableName,false);
            IncrmntConfrmCounter();
            // alert('gj');
            return true;

        }
        function LocalStorageDelete(row_index, x, TableName) {

            var tbClientJobSheduling = '';
            if (TableName == "TableaddedRowsPW") {
                tbClientJobSheduling = localStorage.getItem("tbClientJobShedulingPW");//Retrieve the stored data
            }
            else if (TableName == "TableaddedRowsDW") {
                tbClientJobSheduling = localStorage.getItem("tbClientJobShedulingDW");//Retrieve the stored data
            }
            tbClientJobSheduling = JSON.parse(tbClientJobSheduling); //Converts string to object

            if (tbClientJobSheduling == null) //If there is no data, initialize an empty array
                tbClientJobSheduling = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientJobSheduling.splice(row_index, 1);
            if (TableName == "TableaddedRowsPW") {
                localStorage.setItem("tbClientJobShedulingPW", JSON.stringify(tbClientJobSheduling));
                $noCon("#cphMain_HiddenField1").val(JSON.stringify(tbClientJobSheduling));
            }
            else if (TableName == "TableaddedRowsDW") {
                localStorage.setItem("tbClientJobShedulingDW", JSON.stringify(tbClientJobSheduling));
                $noCon("#cphMain_HiddenField2").val(JSON.stringify(tbClientJobSheduling));
            }
       
            //   alert("Client deleted.");

            //   var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
            //   alert(h);


            var evt = document.getElementById("tdEvt" + x).innerHTML;
            if (evt == 'UPD') {
                var detailId = document.getElementById("tdDtlId" + x).innerHTML;
                //   var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
                if (detailId != '') {
                    var CanclIds = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value;

                        if (CanclIds == '') {
                            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = detailId;

                       }
                       else {

                           document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value + ',' + detailId;
                       }

                   }

               }

            //for calculation of total Amount
            //   CalculateTotalAmountFromHiddenField();
               IncrmntConfrmCounter();
            // alert('gj');

           }

           function LocalStorageEdit(x, row_index, TableName) {
               //  alert('edit start x ' + x);
               //  alert('edit start row_index ' + row_index);
               var tbClientJobSheduling = '';
               if (TableName == "TableaddedRowsPW") {
                   tbClientJobSheduling = localStorage.getItem("tbClientJobShedulingPW");//Retrieve the stored data
               }
               else if (TableName == "TableaddedRowsDW") {
                   tbClientJobSheduling = localStorage.getItem("tbClientJobShedulingDW");//Retrieve the stored data
               }
               tbClientJobSheduling = JSON.parse(tbClientJobSheduling); //Converts string to object

               if (tbClientJobSheduling == null) //If there is no data, initialize an empty array
                   tbClientJobSheduling = [];
               var detailId = document.getElementById("tdDtlId" + x).innerHTML;
               // var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
               var evt = document.getElementById("tdEvt" + x).innerHTML;
               var JobMode = document.getElementById("tdJobMode" + x).innerText;
               // alert('edit pmode ' + PrdctMode);
               //  alert('additional:' + additional)




               if (JobMode == "1") {
                   if (evt == 'INS') {
                       var $E = jQuery.noConflict();
                       tbClientJobSheduling[row_index] = JSON.stringify({
                           ROWID: "" + x + "",
                           JOBID: $E("#txtselectorJobId" + x).val(),
                           JOBNAME: $E("#txtselectorJobName" + x).val(),
                           VHCLID: $E("#txtselectorVhclId" + x).val(),
                           PRJCTID: $E("#txtselectorPrjctId" + x).val(),
                           FROMTIME: $E("#txtselectorFrmTimeId" + x).val(),
                           TOTIME: $E("#txtselectorToTimeId" + x).val(),
                           EVTACTION: "" + evt + "",
                           DTLID: "0",
                           JOBMODE: "" + JobMode + ""

                       });
                   }
                   else if (evt == 'UPD') {
                       var $E = jQuery.noConflict();
                       tbClientJobSheduling[row_index] = JSON.stringify({
                           ROWID: "" + x + "",
                           JOBID: $E("#txtselectorJobId" + x).val(),
                           JOBNAME: $E("#txtselectorJobName" + x).val(),
                           VHCLID: $E("#txtselectorVhclId" + x).val(),
                           PRJCTID: $E("#txtselectorPrjctId" + x).val(),
                           FROMTIME: $E("#txtselectorFrmTimeId" + x).val(),
                           TOTIME: $E("#txtselectorToTimeId" + x).val(),
                           EVTACTION: "" + evt + "",
                           DTLID: "" + detailId + "",
                           JOBMODE: "" + JobMode + ""

                       });
                   }

               }

               else if (JobMode == "2") {
                   if (evt == 'INS') {
                       var $E = jQuery.noConflict();
                       tbClientJobSheduling[row_index] = JSON.stringify({
                           ROWID: "" + x + "",
                           JOBID: "0",
                           JOBNAME: $E("#txtJob" + x).val(),
                           VHCLID: $E("#txtselectorVhclId" + x).val(),
                           PRJCTID: $E("#txtselectorPrjctId" + x).val(),
                           FROMTIME: $E("#txtselectorFrmTimeId" + x).val(),
                           TOTIME: $E("#txtselectorToTimeId" + x).val(),
                           EVTACTION: "" + evt + "",
                           DTLID: "0",
                           JOBMODE: "" + JobMode + ""
                       });
                   }
                   else if (evt == 'UPD') {
                       var $E = jQuery.noConflict();
                       tbClientJobSheduling[row_index] = JSON.stringify({
                           ROWID: "" + x + "",
                           JOBID: "0",
                           JOBNAME: $E("#txtJob" + x).val(),
                           VHCLID: $E("#txtselectorVhclId" + x).val(),
                           PRJCTID: $E("#txtselectorPrjctId" + x).val(),
                           FROMTIME: $E("#txtselectorFrmTimeId" + x).val(),
                           TOTIME: $E("#txtselectorToTimeId" + x).val(),
                           EVTACTION: "" + evt + "",
                           DTLID: "" + detailId + "",
                           JOBMODE: "" + JobMode + ""

                       });
                   }

               }



               if (TableName == "TableaddedRowsPW") {
                   localStorage.setItem("tbClientJobShedulingPW", JSON.stringify(tbClientJobSheduling));
                   $E("#cphMain_HiddenField1").val(JSON.stringify(tbClientJobSheduling));
               }
               else if (TableName == "TableaddedRowsDW") {
                   localStorage.setItem("tbClientJobShedulingDW", JSON.stringify(tbClientJobSheduling));
                   $E("#cphMain_HiddenField2").val(JSON.stringify(tbClientJobSheduling));
               }
               //for calculation of total Amount
               //    CalculateTotalAmountFromHiddenField();




               //  alert("The data was edited.");
               //  operation = "A"; //Return to default value
               // var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
            // alert(h);
            CheckaddMoreRowsIndividual(x, true, TableName,true);
            //alert('cal stop');
            //  IncrmntConfrmCounter();
            
            return true;
        }
    </script>

    <script>
        var $noCon = jQuery.noConflict();
        function dateString2Date(dateString) {
            var dt = dateString.split(/\-|\s/);
            var TimeCheck = dt[3].split(':');
            if (TimeCheck[0] == 12) {
                TimeCheck[0] = TimeCheck[0] - 12;
            }
           else if (TimeCheck[0] == 24)
            {
                TimeCheck[0] = TimeCheck[0] - 12;
            }
            var Time = TimeCheck[0] + ":" + TimeCheck[1] + ":" + TimeCheck[2];
          //  alert('dt' + Time);
            return new Date(dt.slice(0, 3).reverse().join('-') + ' ' + Time);
        }
        function SameFromAndToTime(x, TableName) {

            var TimeDifferenceSts = '';
            if (TableName == 'TableaddedRowsPW') {
                TimeDifferenceSts = document.getElementById("<%=hiddenPeriodWiseTimeDifferenceSts.ClientID%>").value;
                //alert()

            }
            else if (TableName == 'TableaddedRowsDW') {
                TimeDifferenceSts = document.getElementById("<%=hiddenDayWiseTimeDifferenceSts.ClientID%>").value;
              }
            var ret = true;
            var FromTime = document.getElementById('txtselectorFrmTimeId' + x).value;
            var ToTime = document.getElementById('txtselectorToTimeId' + x).value;
            if (FromTime == ToTime)
            {
                ret = false;
                if (TableName == "TableaddedRowsPW") {
                    document.getElementById('divErrorNotification').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, both From Time and To Time can't be same!";
                }
                else if (TableName == "TableaddedRowsDW") {
                    document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Sorry, both From Time and To Time can't be same!";
                        }
            }
            if (FromTime != "--Select Time--" && FromTime != "" && ToTime != "--Select Time--" && ToTime != "") {
               
                var Frinput = FromTime, Frmatches = Frinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
Froutput = (parseInt(Frmatches[1]) + (Frmatches[3] == 'pm' ? 12 : 0)) + ':' + Frmatches[2] + ':00';
                var FromDateTime = dateString2Date('01-01-2016 ' + Froutput);

                var Toinput = ToTime, Tomatches = Toinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
Tooutput = (parseInt(Tomatches[1]) + (Tomatches[3] == 'pm' ? 12 : 0)) + ':' + Tomatches[2] + ':00';
                var ToDateTime = dateString2Date('01-01-2016 ' + Tooutput);
              //  alert('FromDateTime' + FromDateTime);
              //  alert('ToDateTime' + ToDateTime);
                if (FromDateTime > ToDateTime) {
                   // alert(TimeDifferenceSts);
                    if (TimeDifferenceSts == '0') {
                        ret = false;
                        if (TableName == "TableaddedRowsPW") {
                            document.getElementById('divErrorNotification').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry,'From Time' cannot be greater than 'To Time'!";
                }
                else if (TableName == "TableaddedRowsDW") {
                    document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Sorry,'From Time' cannot be greater than 'To Time'!";
                }
                    }
                }
            }
            if (ret == false)
            {
                

            }
            return ret;
        }
        function DuplicationTimeCheck(obj, x, row_Index, TableName) {
            var dup = false;
        //    alert(obj);
            var TimeDifferenceSts = '';
            var DefaultStartValue = '';
            var DefaultEndValue = '';
            if (TableName == 'TableaddedRowsPW') {
                TimeDifferenceSts =  document.getElementById("<%=hiddenPeriodWiseTimeDifferenceSts.ClientID%>").value ;
                DefaultStartValue = document.getElementById("<%=hidden_DefalultStartTimePeriodWise.ClientID%>").value;
                DefaultEndValue = document.getElementById("<%=hidden_DefalultEndTimePeriodWise.ClientID%>").value;
              }
              else if (TableName == 'TableaddedRowsDW') {
                  TimeDifferenceSts = document.getElementById("<%=hiddenDayWiseTimeDifferenceSts.ClientID%>").value;
                  DefaultStartValue = document.getElementById("<%=hidden_DefalultStartTimeDayWise.ClientID%>").value;
                  DefaultEndValue = document.getElementById("<%=hidden_DefalultEndTimeDayWise.ClientID%>").value;
              }
           // alert('TimeDifferenceSts ' + TimeDifferenceSts);
           
            var TimeObj = document.getElementById(obj + "Id" + x);

            //  var selectedText = QtnItem.options[QtnItem.selectedIndex].text;
            var selectedText = TimeObj.value;
            var TimeValue = selectedText;
           
            
            var DfltStartinput = DefaultStartValue, DfltStartmatches = DfltStartinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
  DfltStartoutput = (parseInt(DfltStartmatches[1]) + (DfltStartmatches[3] == 'pm' ? 12 : 0)) + ':' + DfltStartmatches[2] + ':00';
            var DfltStartDateTime = dateString2Date('01-01-2016 ' + DfltStartoutput);

            var DfltStopinput = DefaultEndValue, DfltStopmatches = DfltStopinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
 DfltStopoutput = (parseInt(DfltStopmatches[1]) + (DfltStopmatches[3] == 'pm' ? 12 : 0)) + ':' + DfltStopmatches[2] + ':00';
            var DfltStopDateTime = dateString2Date('01-01-2016 ' + DfltStopoutput);
            if (TimeDifferenceSts != '0') {

                DfltStopDateTime = dateString2Date('02-01-2016 ' + DfltStopoutput);
            }
            var input = TimeValue, matches = input.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
   output = (parseInt(matches[1]) + (matches[3] == 'pm' ? 12 : 0)) + ':' + matches[2] + ':00';
            var objDateTime = dateString2Date('01-01-2016 ' + output);

            if (TimeDifferenceSts != '0') {
               // alert(DfltStartDateTime);
                if (objDateTime < DfltStartDateTime) {

                    objDateTime = dateString2Date('02-01-2016 ' + output);
                 
                }
            }
       //     alert(objDateTime)
            var ret = true;


            if (obj == "txtselectorFrmTime") {
                //for checking withing the range
              
                    var NxtTimeObj = document.getElementById("txtselectorToTimeId" + x);
                    var NxtTimeValue = NxtTimeObj.value;
                    if (NxtTimeValue != "--Select Time--" && NxtTimeValue != "") {
                        var Nxtinput = NxtTimeValue, Nxtmatches = Nxtinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
Nxtoutput = (parseInt(Nxtmatches[1]) + (Nxtmatches[3] == 'pm' ? 12 : 0)) + ':' + Nxtmatches[2] + ':00';
                        var NxtDateTime = dateString2Date('01-01-2016 ' + Nxtoutput);
                        if (TimeDifferenceSts != '0') {
                            // alert(DfltStartDateTime);
                            if (NxtDateTime < DfltStartDateTime) {

                                NxtDateTime = dateString2Date('02-01-2016 ' + Nxtoutput);

                            }
                        }
                     
                     //   alert('objDateTime' + objDateTime);
                     //  alert('DfltStartDateTime' + DfltStartDateTime);
                    //    alert('NxtDateTime' + NxtDateTime);
                      // alert('DfltStopDateTime' + DfltStopDateTime);

                        if (objDateTime >= DfltStartDateTime && NxtDateTime <= DfltStopDateTime) {
                            // alert('error');
                            if (objDateTime > NxtDateTime) {
                                 ret = false;
                            }
                        }
                        else {
                            ret = false;
                        }

                    }

            }
            else if (obj == "txtselectorToTime") {
                //for checking withing the range
            
                    var NxtTimeObj = document.getElementById("txtselectorFrmTimeId" + x);
                    var NxtTimeValue = NxtTimeObj.value;
                    if (NxtTimeValue != "--Select Time--" && NxtTimeValue != "") {
                        var Nxtinput = NxtTimeValue, Nxtmatches = Nxtinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
Nxtoutput = (parseInt(Nxtmatches[1]) + (Nxtmatches[3] == 'pm' ? 12 : 0)) + ':' + Nxtmatches[2] + ':00';
                        var NxtDateTime = dateString2Date('01-01-2016 ' + Nxtoutput);
                        if (TimeDifferenceSts != '0') {
                            if (NxtDateTime < DfltStartDateTime) {

                                NxtDateTime = dateString2Date('02-01-2016 ' + Nxtoutput);

                            }
                        }
                     

                    //    alert('NxtDateTime ' + NxtDateTime);
                     //   alert('objDateTime ' + objDateTime);
                     //   alert('DfltStartDateTime ' + DfltStartDateTime);
                     //   alert('DfltStopDateTime ' + DfltStopDateTime);
                        if (NxtDateTime >= DfltStartDateTime && objDateTime <= DfltStopDateTime) {
                            if (NxtDateTime > objDateTime) {
                                ret = false;
                            }
                        }
                        else {
                            ret = false;
                        }

                    }

            }

         //   alert(ret);
            if (ret == true) {

                var objDateTime12AM = dateString2Date('01-01-2016 12:00:00');
                //      alert(output);
                //      alert(objDateTime);

                //  var resultJSON = '{"FirstName":"John","LastName":"Doe","Email":"johndoe@johndoe.com","Phone":"123 dead drive"}","{"FirstName":"Johni","LastName":"Doioe","Email":"johndoe@johndoe.com","Phone":"123 dead drive"}';
                var hiddenVal = '';
                //  alert(hiddenVal);
                if (TableName == "TableaddedRowsPW") {
                    hiddenVal = document.getElementById("<%=HiddenField1.ClientID%>").value;
                }
                else if (TableName == "TableaddedRowsDW") {

                    hiddenVal = document.getElementById("<%=HiddenField2.ClientID%>").value;
                }

                if (document.getElementById("<%=hiddenAllowJobDuplication.ClientID%>").value == "1") {
                    if (hiddenVal != "" && hiddenVal != "[]") {

                        var find1 = '\\\\';
                        var re1 = new RegExp(find1, 'g');

                        var res1 = hiddenVal.replace(re1, '');

                        var find2 = '\\["';
                        var re2 = new RegExp(find2, 'g');

                        var res2 = res1.replace(re2, '');

                        var find3 = '\\"]';
                        var re3 = new RegExp(find3, 'g');

                        var res3 = res2.replace(re3, '');

                        var jdatas = res3.split("\",\"{");


                        var i;
                        for (i = 0; i < jdatas.length; i++) {
                            var FrTm = '';
                            var ToTm = '';
                            var resultJSON = "";
                            if (i == 0) {
                                resultJSON = jdatas[i];

                            }
                            else {

                                resultJSON = "{" + jdatas[i];

                            }

                            var result = $noCon.parseJSON(resultJSON);
                            $noCon.each(result, function (k, v) {
                                if (k == "FROMTIME") {
                                    FrTm = v.trim();
                                }
                                if (k == "TOTIME") {
                                    ToTm = v.trim();
                                }
                            });
                            var Rindex = parseInt(row_Index);

                            if (i != Rindex) {


                                var Frinput = FrTm, Frmatches = Frinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
    Froutput = (parseInt(Frmatches[1]) + (Frmatches[3] == 'pm' ? 12 : 0)) + ':' + Frmatches[2] + ':00';
                                var FromDateTime = dateString2Date('01-01-2016 ' + Froutput);

                                if (TimeDifferenceSts != '0') {
                                    if (FromDateTime < DfltStartDateTime) {

                                        FromDateTime = dateString2Date('02-01-2016 ' + Froutput);
                                    }
                                }

                                var Toinput = ToTm, Tomatches = Toinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
    Tooutput = (parseInt(Tomatches[1]) + (Tomatches[3] == 'pm' ? 12 : 0)) + ':' + Tomatches[2] + ':00';
                                var ToDateTime = dateString2Date('01-01-2016 ' + Tooutput);

                                if (TimeDifferenceSts != '0') {
                                    if (ToDateTime < DfltStartDateTime) {

                                        ToDateTime = dateString2Date('02-01-2016 ' + Tooutput);
                                    }
                                }


                                //if (TimeDifferenceSts != '0') {
                                //    if (FromDateTime > ToDateTime) {
                                //        ToDateTime = dateString2Date('02-01-2016 ' + Tooutput);

                                //    }
                                //}

                                if (obj == "txtselectorFrmTime") {
                                    //for same cheching and oterbound checking
                                    if (FrTm == TimeValue) {
                                        ret = false;
                                    }

                                    if (ret == true) {
                                        var NxtTimeObj = document.getElementById("txtselectorToTimeId" + x);
                                        var NxtTimeValue = NxtTimeObj.value;
                                        if (NxtTimeValue != "--Select Time--" && NxtTimeValue != "") {
                                            var Nxtinput = NxtTimeValue, Nxtmatches = Nxtinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
    Nxtoutput = (parseInt(Nxtmatches[1]) + (Nxtmatches[3] == 'pm' ? 12 : 0)) + ':' + Nxtmatches[2] + ':00';
                                            var NxtDateTime = dateString2Date('01-01-2016 ' + Nxtoutput);
                                            if (TimeDifferenceSts != '0') {
                                                if (NxtDateTime < DfltStartDateTime) {

                                                    NxtDateTime = dateString2Date('02-01-2016 ' + Nxtoutput);

                                                }
                                            }

                                            if (FromDateTime > objDateTime && NxtDateTime > ToDateTime) {
                                                ret = false;
                                            }


                                        }

                                    }
                                }
                                else if (obj == "txtselectorToTime") {
                                    //for same cheching and oterbound checking
                                    if (ToTm == TimeValue) {
                                        ret = false;
                                    }

                                    if (ret == true) {
                                        var NxtTimeObj = document.getElementById("txtselectorFrmTimeId" + x);
                                        var NxtTimeValue = NxtTimeObj.value;
                                        if (NxtTimeValue != "--Select Time--" && NxtTimeValue != "") {
                                            var Nxtinput = NxtTimeValue, Nxtmatches = Nxtinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
    Nxtoutput = (parseInt(Nxtmatches[1]) + (Nxtmatches[3] == 'pm' ? 12 : 0)) + ':' + Nxtmatches[2] + ':00';
                                            var NxtDateTime = dateString2Date('01-01-2016 ' + Nxtoutput);
                                           
                                            if (TimeDifferenceSts != '0') {
                                                if (NxtDateTime < DfltStartDateTime) {

                                                    NxtDateTime = dateString2Date('02-01-2016 ' + Nxtoutput);

                                                }
                                            }

                                            if (FromDateTime > NxtDateTime && objDateTime > ToDateTime) {
                                                ret = false;
                                            }


                                        }

                                    }

                                }
                                //inner bound
                                if (ret == true) {
                                    if (FromDateTime < objDateTime && objDateTime < ToDateTime) {
                                        ret = false;
                                    }
                                }


                            }

                        }


                        if (ret == false) {
                            if (TableName == "TableaddedRowsPW") {
                                document.getElementById('divErrorNotification').style.visibility = "visible";
                                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, You have already selected this Time!";
                            }
                            else if (TableName == "TableaddedRowsDW") {
                                document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Sorry, You have already selected this Time!";
                            }

                        }

                    }
                }
            }
            else if (ret == false) {
                if (TableName == "TableaddedRowsPW") {
                    document.getElementById('divErrorNotification').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, Please select time within range of Time Slot!";
                      }
                else if (TableName == "TableaddedRowsDW") {
                    document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Sorry, Please select time within range of Time Slot!";
                     }

            }
            return ret;

        }



        function SelectWeekdays(WkId) {
            var blCheckedPrevious = false;
            var PreviousSlctdValues = document.getElementById("<%=hiddenWeekDayId.ClientID%>").value;
            var arrWeekDays = PreviousSlctdValues.split(",");
            //  alert('bla' +PreviousSlctdValues);

            //  alert(WkId);
            //  alert( arrWeekDays.length);
            for (i = 0; i < arrWeekDays.length; i++) {
                if (arrWeekDays[i].toString() == WkId.toString() && arrWeekDays[i].toString() != "") {
                    blCheckedPrevious = true;
                    document.getElementById("liWeekdays" + WkId).style.border = ".5px solid";
                    document.getElementById("liWeekdays" + WkId).style.backgroundColor = "";

                }
            }



            // var oldImage = document.getElementById("<%=hiddenWeekDayId.ClientID%>").value;
            //if (oldImage != "") {
            //    document.getElementById("divImageLicenseType-" + oldImage).style.border = ".5px solid";
            //    document.getElementById("divImageLicenseType-" + oldImage).style.borderColor = "#ceb6b6";
            //    document.getElementById("divImageLicenseType-" + oldImage).style.backgroundColor = "";
            //}
            if (blCheckedPrevious == false) {// if not selected previously
                document.getElementById("liWeekdays" + WkId).style.border = ".5px solid";
                document.getElementById("liWeekdays" + WkId).style.backgroundColor = "rgb(138, 195, 34)";
                if (document.getElementById("<%=hiddenWeekDayId.ClientID%>").value == "") {
                    document.getElementById("<%=hiddenWeekDayId.ClientID%>").value = WkId + ",";
                }
                else {
                    document.getElementById("<%=hiddenWeekDayId.ClientID%>").value = document.getElementById("<%=hiddenWeekDayId.ClientID%>").value + WkId + ",";

                }
            }
            else {

                var replacedValue = PreviousSlctdValues.replace(WkId + ",", "");
                document.getElementById("<%=hiddenWeekDayId.ClientID%>").value = replacedValue;

            }


        }

        function testWeekdays() {

            alert(document.getElementById("<%=hiddenWeekDayId.ClientID%>").value);
            return false;
        }

        function CheckAddIntervl(x, retBool, TableName, a) {
           
            if (a==true) {

               

                var check = document.getElementById("tdInx" + x).innerHTML;

            
                //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
                //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                if (check == " ") {
  
                    if (retBool == true) {

                        if (CheckAllRowFieldAndHighlight(x) == true) {

                            document.getElementById("tdInx" + x).innerHTML = x;
                            document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";



                            addMoreRows(this.form, retBool, 1, false, 0, TableName);

                            return false;
                        }
                    }
                    else if (retBool == false) {
                        var row_index = jQuery('#rowId_' + x).index();
                        if (CheckAllRowField(x, row_index, TableName) == true) {
                            document.getElementById("tdInx" + x).innerHTML = x;
                            document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";
                            //   alert('TableName ' + TableName);
                            addMoreRows(this.form, retBool, 1, false, 0, TableName);
                            return false;
                        }
                    }
                }
               
            }
            else {
                
                document.getElementById("txtselectorFrmTime" + x).value = "--Select Time--";
                document.getElementById("txtselectorFrmTimeId" + x).value = "--Select Time--";

                document.getElementById("txtselectorToTime" + x).value = "--Select Time--";
                document.getElementById("txtselectorToTimeId" + x).value = "--Select Time--";


                document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";

                document.getElementById('divErrorNotification').style.visibility = "visible";
                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, Vehicle is already scheduled within the time range!";

                return false;
            }

            return false;
        }


        function CheckaddMoreRowsIndividual(x, retBool, TableName,y) {
            // for add image in each row
            //   alert('CheckaddMoreRowsIndividual');
       
         
            vhclCheck(x, retBool, TableName, y);
           
           
            return false;
        }


        function vhclCheck(x, retBool, TableName,y) {
            var ret = true;
            var Fromdate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var Todate = document.getElementById("<%=txtToDate.ClientID%>").value;
            var FromTime = document.getElementById('txtselectorFrmTimeId' + x).value;
            var ToTime = document.getElementById('txtselectorToTimeId' + x).value;
            var VhclId = document.getElementById("txtselectorVhclId" + x).value;
            var edit = document.getElementById("tdDtlId" + x).innerHTML;
            if (Fromdate != "" && Todate != "" && FromTime != "--Select Time--" && ToTime != "--Select Time--" && VhclId != "--Select Vehicle--") {



                var Details = PageMethods.VhclCheck(Fromdate, Todate, FromTime, ToTime, VhclId, edit, function (response) {




                    if (response == "false" && edit == "") {
                        CheckAddIntervl(x, retBool, TableName, false);

                    }

                    else if (response == "false" && edit != "" && y == true) {

                        CheckAddIntervl(x, retBool, TableName, false);

                    }
                    else {

                        CheckAddIntervl(x, retBool, TableName, true);
                    }
                });



            }
            else {

                CheckAddIntervl(x, retBool, TableName, true);

            }
          

        }


        // checks every field in row
        function CheckIfAnyAdded(x) {
            ret = false;
            var JMode = document.getElementById("tdJobMode" + x).innerText;
            if (JMode == "1") {
                var Job = document.getElementById("txtselectorJobId" + x).value;
                if (Job != "--Select Job--") {
                    ret = true;

                }

            }
            else {
                var Job = document.getElementById("txtJob" + x).value;
                if (Job != "") {
                    ret = true;

                }

            }
            var Vhcl = document.getElementById("txtselectorVhclId" + x).value;
            if (Vhcl != "--Select Vehicle--") {
                ret = true;

            }
            var Prjct = document.getElementById("txtselectorPrjctId" + x).value;
            if (Prjct != "--Select Project--") {
                ret = true;

            }
            var FrmTime = document.getElementById("txtselectorFrmTimeId" + x).value;
            if (FrmTime != "--Select Time--") {
                ret = true;

            }
            var ToTime = document.getElementById("txtselectorToTimeId" + x).value;
            if (ToTime != "--Select Time--") {
                ret = true;

            }

            return ret;
        }


        // checks every field in row
        function CheckAllRowField(x, row_index, TableName) {
            ret = true;
            var JMode = document.getElementById("tdJobMode" + x).innerText;
            if (JMode == "1") {
                var Job = document.getElementById("txtselectorJobId" + x).value;
                if (Job == "--Select Job--") {
                    ret = false;

                }

            }
            else {
                var Job = document.getElementById("txtJob" + x).value;
                if (Job == "") {
                    ret = false;

                }

            }
            var Vhcl = document.getElementById("txtselectorVhclId" + x).value;
            if (Vhcl == "--Select Vehicle--") {
                ret = false;

            }
            var Prjct = document.getElementById("txtselectorPrjctId" + x).value;
            if (Prjct == "--Select Project--") {
                ret = false;

            }
            var FrmTime = document.getElementById("txtselectorFrmTimeId" + x).value;
            if (FrmTime == "--Select Time--") {
                ret = false;

            } else {
                
               if (DuplicationTimeCheck('txtselectorFrmTime', x, row_index, TableName) == true) {
                    if (TableName == "TableaddedRowsPW") {
                        document.getElementById('divErrorNotification').style.visibility = "hidden";
                     document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
                         }
                     else if (TableName == "TableaddedRowsDW") {
                         document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                         document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";
                       }
                   }
                   else {

                   document.getElementById("txtselectorFrmTime" + x).value = "--Select Time--";
                 document.getElementById("txtselectorFrmTimeId" + x).value = "--Select Time--";
                                   
                    document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                      
                  
                       ret = false;
                  }
                }
            var ToTime = document.getElementById("txtselectorToTimeId" + x).value;
            if (ToTime == "--Select Time--") {
                ret = false;

            }
            else {

                if (DuplicationTimeCheck('txtselectorToTime', x, row_index, TableName) == true) {
                   if (TableName == "TableaddedRowsPW") {
                        document.getElementById('divErrorNotification').style.visibility = "hidden";
                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
                   }
                    else if (TableName == "TableaddedRowsDW") {
                        document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                        document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";
                     }
                  }
                    else {

                    document.getElementById("txtselectorToTime" + x).value = "--Select Time--";
                    document.getElementById("txtselectorToTimeId" + x).value = "--Select Time--";
                 
                    document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";
              

                    ret = false;
                   }
                }

            return ret;
        }



        // checks every field in row
        function CheckRcptNumberFieldAndHighlight(x) {
            ret = true;
            var RcptNumber = document.getElementById("txtRcptNumber" + x).value;
            if (RcptNumber == "") {
                document.getElementById("txtRcptNumber" + x).style.borderColor = "Red";
                document.getElementById("txtRcptNumber" + x).focus();
                $noCon("#txtRcptNumber" + x).select();
                return false;
            }


            return true;
        }
        // checks every field in row
        function CheckAllRowFieldAndHighlight(x) {
            ret = true;

            var JMode = document.getElementById("tdJobMode" + x).innerText;
            if (JMode == "1") {
                var Job = document.getElementById("txtselectorJobId" + x).value;
                if (Job == "--Select Job--") {
                    document.getElementById("txtselectorJob" + x).style.borderColor = "Red";
                    // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                    document.getElementById("txtselectorJob" + x).focus();
                    $noCon("#txtselectorJob" + x).select();
                    return false;

                }
            }
            else {
                var Job = document.getElementById("txtJob" + x).value;
                if (Job == "") {
                    document.getElementById("txtJob" + x).style.borderColor = "Red";
                    document.getElementById("txtJob" + x).focus();
                    $noCon("#txtJob" + x).select();
                    return false;
                }

            }


            var VhclId = document.getElementById("txtselectorVhclId" + x).value;
            if (VhclId == "--Select Vehicle--" || VhclId == "") {
                document.getElementById("txtselectorVhcl" + x).style.borderColor = "Red";
                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                document.getElementById("txtselectorVhcl" + x).focus();
                $noCon("#txtselectorVhcl" + x).select();
                return false;

            }

            var PrjctId = document.getElementById("txtselectorPrjctId" + x).value;
            if (PrjctId == "--Select Project--" || PrjctId == "") {
                document.getElementById("txtselectorPrjct" + x).style.borderColor = "Red";
                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                document.getElementById("txtselectorPrjct" + x).focus();
                $noCon("#txtselectorPrjct" + x).select();
                return false;

            }
            var PrjctId = document.getElementById("txtselectorPrjctId" + x).value;
            if (PrjctId == "--Select Project--" || PrjctId == "") {
                document.getElementById("txtselectorPrjct" + x).style.borderColor = "Red";
                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                document.getElementById("txtselectorPrjct" + x).focus();
                $noCon("#txtselectorPrjct" + x).select();
                return false;

            }
            var FrmTime = document.getElementById("txtselectorFrmTimeId" + x).value;
            if (FrmTime == "--Select Time--" || FrmTime == "") {
                document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                document.getElementById("txtselectorFrmTime" + x).focus();
                $noCon("#txtselectorFrmTime" + x).select();
                return false;

            }
            var ToTime = document.getElementById("txtselectorToTimeId" + x).value;
            if (ToTime == "--Select Time--" || ToTime == "") {
                document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";
                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                document.getElementById("txtselectorToTime" + x).focus();
                $noCon("#txtselectorToTime" + x).select();
                return false;

            }
            return true;
        }

        function ShowHideDiv(obj) {
        //    alert('ShowHideDiv '+ obj);
             if (obj == "cphMain_cbxMustDayWise") {
                if (document.getElementById(obj).checked) {
                    document.getElementById('divDayWiseContent').style.display = "block";
                }
                else {
                    alert('If you are not selecting Day wise Section then information in this Section will not be saved  !');
                    document.getElementById('divDayWiseContent').style.display = "none";

                }

            }

             return false;
        }
        function CheckDate(blCheckWithCurrntDate)
        {
            var ret = true;
            var FDateWithoutReplace = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var FDatereplaceText1 = FDateWithoutReplace.replace(/</g, "");
            var FDatereplaceText2 = FDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtFromDate.ClientID%>").value = FDatereplaceText2;


            var TDateWithoutReplace = document.getElementById("<%=txtToDate.ClientID%>").value;
            var TDatereplaceText1 = TDateWithoutReplace.replace(/</g, "");
            var TDatereplaceText2 = TDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtToDate.ClientID%>").value = TDatereplaceText2;

            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";

            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";


            var Fromdate = document.getElementById("<%=txtFromDate.ClientID%>").value;
         

            var Todate = document.getElementById("<%=txtToDate.ClientID%>").value;
         
            if (Todate == "") {
                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtToDate.ClientID%>").focus();
                 ret = false;

             }
             else if (Todate != "") {
                 if (parseDate(Todate) == false) {
                     document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtToDate.ClientID%>").focus();
                    ret = false;

                }
            }
            if (Fromdate == "") {
                document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtFromDate.ClientID%>").focus();
                ret = false;
                
            }
            else if (Fromdate != "") {
                if (parseDate(Fromdate) == false)
                {
                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFromDate.ClientID%>").focus();
                    ret = false;

                }
            }
           
            if (ret == true) {
                //// AFTER if validation is true in above case
                //check if  date is less than current date
                var FromdatepickerDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                var arrFromDatePickerDate = FromdatepickerDate.split("-");
                var dateFromDateCntrlr = new Date(arrFromDatePickerDate[2], arrFromDatePickerDate[1] - 1, arrFromDatePickerDate[0]);

                var TodatepickerDate = document.getElementById("<%=txtToDate.ClientID%>").value;
                var arrToDatePickerDate = TodatepickerDate.split("-");
                var dateToDateCntrlr = new Date(arrToDatePickerDate[2], arrToDatePickerDate[1] - 1, arrToDatePickerDate[0]);

                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);


                if (dateFromDateCntrlr > dateToDateCntrlr) {
                    document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtToDate.ClientID%>").focus();
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, To Date cannot be Less than From Date !.";
                    ret = false;
                }

                if ((ret == true) && (blCheckWithCurrntDate == true)) {
                    //   alert('dateDateCntrlr ' + dateDateCntrlr);
                    // alert('dateCurrentDate ' + dateCurrentDate);
                    if (dateFromDateCntrlr < dateCurrentDate) {
                        document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtFromDate.ClientID%>").focus();
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, From Date cannot be Less than Current Date !.";
                        ret = false;
                    }
                    if (ret == true) {

                        if (dateToDateCntrlr < dateCurrentDate) {
                            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtToDate.ClientID%>").focus();
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, To Date cannot be Less than Current Date !.";
                            ret = false;
                        }

                    }
                }

            }
            else {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
            }
            return ret;
        }

        function ValidateAndSave(obj, blCheckWithCurrntDate) {
          
            var ret = true;
            if (CheckIsRepeat() == true) {
           
            }
            else {
                ret = false;
                return ret;
            }
          
          
            
          
            document.getElementById('divErrorNotification').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
            document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";
            if (CheckDate(blCheckWithCurrntDate) == true)//error message is wriiten in function itself
            {
               
                if (ChangeJSToDate() == false) {
                   
                    CheckSubmitZero();
                    ret = false;
                    return ret;
                   
                }
             
                if (IsTimeSlotSelected('TableaddedRowsPW') == true) {
                   
                    var DropdownTimeSlotPW = document.getElementById("<%=ddlTimeSlot_PeriodWise.ClientID%>");
                    var SelectedValueTimeSlotPW = DropdownTimeSlotPW.value;
                    document.getElementById("<%=hiddenddlTimeSlotPWVal.ClientID%>").value = SelectedValueTimeSlotPW;
                    if (validatePeriodorDayWiseTable('TableaddedRowsPW') == false) {
                    
                        ret= false;
                    }
                    else {
                       
                        if (document.getElementById("<%=cbxMustDayWise.ClientID%>").checked) {
                       
                            if (IsWeekDaysSelected() == true) {
                                if (IsTimeSlotSelected('TableaddedRowsDW') == true) {
                                   
                                    var DropdownTimeSlotDW = document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>");
                                    var SelectedValueTimeSlotDW = DropdownTimeSlotDW.value;
                                    document.getElementById("<%=hiddenddlTimeSlotDWVal.ClientID%>").value = SelectedValueTimeSlotDW;
                                    if (validatePeriodorDayWiseTable('TableaddedRowsDW') == false) {                                   
                                        ret=false;
                                    }
                                    else {
                                      //  return true;

                                    }

                                }
                                else
                                {

                                    document.getElementById('divMessageArea').style.display = "";
                                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                                    ret=false;
                                }

                            }
                            else {
                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                          
                                ret= false;
                            }

                        }


                    }


                }
                else {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";                  
                    ret= false;
                }
            }
            else {
              
                ret=false;

            }

           
      
         if (ret == false) {
            
                CheckSubmitZero();

            }
            return ret;
        }


        function validatePeriodorDayWiseTable(TableName) {
            var TableRowCount = document.getElementById(TableName).rows.length;
            //  alert(TableRowCount);
            if (TableRowCount != 0) {
                if (TableRowCount == 1) {
                    var ret = true;
                    //if added a row not entered any value validate
                  
                    var idlast = $noCon('#' + TableName + ' tr:last').attr('id');
                    if (idlast != "") {
                        var res = idlast.split("_");
                        var x = res[1];


                        if (CheckAllRowFieldAndHighlight(x) == false) {
                            ret = false;
                        }


                        if (ret == false) {
                            if (TableName == "TableaddedRowsPW") {
                                document.getElementById('divErrorNotification').style.visibility = "visible";
                                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
    
                                 }
                         else if (TableName == "TableaddedRowsDW") {
                                document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                                }
                          
                            }
                            else if (ret == true) {

                               
                               

                            }

                        }
                        else {
                            ret = false;

                        }

                     
                    return ret;
                }


                else {

                    var ret = true;
                    var table = document.getElementById(TableName);
                        // alert(table.rows.length);
                    for (var i = 0; i < table.rows.length; i++) {
                        if (i != table.rows.length - 1) {
                            // FIX THIS
                            var row = table.rows[i];

                            var xLoop = (table.rows[i].cells[0].innerHTML);
                            if (CheckAllRowFieldAndHighlight(xLoop) == false) {
                                ret = false;
                            }


                        }
                        else {
                            //last row


                            var xLoop = (table.rows[i].cells[0].innerHTML);
                            if (document.getElementById("tdChanged" + xLoop).innerHTML == "Changed") {
                                if (CheckAllRowFieldAndHighlight(xLoop) == false) {
                                    ret = false;
                                }
                            }

                        }
                    }
                    if (ret == true) {
                        var idlast = $noCon('#'+ TableName +' tr:last').attr('id');
                        //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                        //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");


                        if (idlast != "") {
                            var res = idlast.split("_");
                            var x = res[1];
                            //  alert(res[1]);
                            if (CheckIfAnyAdded(x) == true)//if any added value
                            {
                                if (CheckAllRowFieldAndHighlight(x) == false) {
                                    ret = false;
                                }
                            }
                        
                         
                            if (ret == false) {
                                if (TableName == "TableaddedRowsPW") {
                                    document.getElementById('divErrorNotification').style.visibility = "visible";
                                    document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                            }
                            else if (TableName == "TableaddedRowsDW") {
                                document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                            }
                            }
                            else if (ret == true) {

                                
                         
                              

                            }

                        }
                        else {

                            ret = false;
                        }
                    }

                    else if (ret == false) {
                        if (TableName == "TableaddedRowsPW") {
                            document.getElementById('divErrorNotification').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                                }
                                else if (TableName == "TableaddedRowsDW") {
                                    document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                                    document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                            }
                    }
              

                 return ret;
             }
         }
            else {


                if (TableName == "TableaddedRowsPW") {
                    document.getElementById('divErrorNotification').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, Please add atleast one Item to Save!";

            }
            else if (TableName == "TableaddedRowsDW") {
                document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Sorry, Please add atleast one Item to Save!";

            }
           
           
             return false;

         }

        }

    </script>

    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            if (document.getElementById("<%=hiddenConfirmedEntry.ClientID%>").value == "1") {
                // document.getElementById('DivBtnClearAll').style.display = "none";
                
                document.getElementById('divWeekdays').style.pointerEvents="none";
            }
            if (document.getElementById("<%=cbxMustDayWise.ClientID%>").checked) {
                document.getElementById('divDayWiseContent').style.display = "block";
            }
            else {
                document.getElementById('divDayWiseContent').style.display = "none";

            }
            $('#cphMain_ddlTimeSlot_PeriodWise').selectToAutocomplete1Letter();
            $('#cphMain_ddlTimeSlot_DayWise').selectToAutocomplete1Letter();
             //  alert('load begin');



            document.getElementById('divBlink').style.visibility = "hidden";

            // Run code
            //     alert('loaded statr');
            document.getElementById("<%=HiddenField1.ClientID%>").value = "";
            document.getElementById("<%=HiddenField2.ClientID%>").value = "";
            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";


            localStorage.clear();

           
            var DropdownTimeSlotPeriodWise = document.getElementById("<%=ddlTimeSlot_PeriodWise.ClientID%>");
            var SelectedValueTimeSlotPeriodWise = DropdownTimeSlotPeriodWise.value;

            var DropdownTimeSlotDayWise = document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>");
            var SelectedValueTimeSlotDayWise = DropdownTimeSlotDayWise.value;

            //period wise

            if (SelectedValueTimeSlotPeriodWise == '--SELECT TIME SLOT--') {

                SelectedValueTimeSlotPeriodWise = 0;
            }
           
            if (SelectedValueTimeSlotPeriodWise != 0) {
                //alert('loadedefwef '+SelectedValueTimeSlotPeriodWise);
             

                TimeSlotSelected(SelectedValueTimeSlotPeriodWise, 'PeriodWise');
            }
            else {
                TimeSlotSelected('0', 'PeriodWise');
            }
         
            //Day wise

            if (SelectedValueTimeSlotDayWise == '--SELECT TIME SLOT--') {

                SelectedValueTimeSlotDayWise = 0;
            }
            if (SelectedValueTimeSlotDayWise != 0) {
                //  alert('loadedefwef ' + SelectedValueTimeSlotPeriodWise);
              

                TimeSlotSelected(SelectedValueTimeSlotDayWise, 'DayWise');
            }
            else {
                TimeSlotSelected('0', 'DayWise');
            }



            var WeekdaySlctdValues = document.getElementById("<%=hiddenWeekDayId.ClientID%>").value.trim();
            if (WeekdaySlctdValues != "") {
                var arrWeekday = WeekdaySlctdValues.split(",");
                //  alert('bla' +PreviousSlctdValues);
                //    alert(LicTypes.length);
                for (i = 0; i < arrWeekday.length; i++) {
                    if (arrWeekday[i].toString() != "") {
                        if (document.getElementById("liWeekdays" + arrWeekday[i])) {
                            document.getElementById("liWeekdays" + arrWeekday[i]).style.border = ".5px solid";
                            document.getElementById("liWeekdays" + arrWeekday[i]).style.backgroundColor = "rgb(138, 195, 34)";

                        }

                    }
                }
            }



            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
            var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;
           // alert('EditVal ' + EditVal);
           // alert('ViewVal ' + ViewVal);
            if (EditVal != "") {
                // alert('edit  ' + EditVal);
               
               
                // var find1 = '\\\\';
                //  var re1 = new RegExp(find1, 'g');
                //  var res1 = EditVal.replace(re1, '');
                var EditValPeriodWise = document.getElementById("<%=hiddenDataPeriodWise.ClientID%>").value;
                
                if (EditValPeriodWise != "") {

                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = EditValPeriodWise.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');
                    //   alert('res3' + res3);
                    var json = $noCon.parseJSON(res3);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            if (json[key].TransId != "") {

                                //  alert('json[key].AddDesc ' + json[key].AddDesc);
                                EditListRows(json[key].JobId, json[key].JobName, json[key].VhclNumbr, json[key].VhclId, json[key].PrjctId, json[key].PrjctName, json[key].FromTime, json[key].ToTime, json[key].JobMode,json[key].txtJobName ,json[key].TransDtlId, 'TableaddedRowsPW');

                                //  alert(json[key].LdgrHeadId);
                                //  alert(json[key].Amount);
                            }
                        }
                    }
                }
                var EditValDayWise = document.getElementById("<%=hiddenDataDayWise.ClientID%>").value;

                if (EditValDayWise != "") {

                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = EditValDayWise.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');
                    //   alert('res3' + res3);
                    var json = $noCon.parseJSON(res3);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            if (json[key].TransId != "") {

                                //  alert('json[key].AddDesc ' + json[key].AddDesc);
                                EditListRows(json[key].JobId, json[key].JobName, json[key].VhclNumbr, json[key].VhclId, json[key].PrjctId, json[key].PrjctName, json[key].FromTime, json[key].ToTime, json[key].JobMode, json[key].txtJobName, json[key].TransDtlId, 'TableaddedRowsDW');

                                //  alert(json[key].LdgrHeadId);
                                //  alert(json[key].Amount);
                            }
                        }
                    }
                }
            }

            else if (ViewVal != "") {
                
                

                $("div#ToDate input").attr("disabled", "disabled");
                $("div#FromDate input").attr("disabled", "disabled");
                //document.getElementById("<%=txtFromDate.ClientID%>").disabled = true;
               // document.getElementById("<%=txtToDate.ClientID%>").disabled = true;
                document.getElementById("<%=ddlTimeSlot_PeriodWise.ClientID%>").disabled = true;
                $("div#divTimeSlotPeridWise input.ui-autocomplete-input").attr("disabled", "disabled");
                document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").disabled = true;
                $("div#divTimeSlotDayWise input.ui-autocomplete-input").attr("disabled", "disabled");
                //   alert('View  ' + ViewVal);


                var ViewValPeriodWise = document.getElementById("<%=hiddenDataPeriodWise.ClientID%>").value;

                if (ViewValPeriodWise != "") {

                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = ViewValPeriodWise.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');
                    //alert(res3);
                    var json = $noCon.parseJSON(res3);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            if (json[key].TransId != "") {

                                ViewListRows(json[key].JobId, json[key].JobName, json[key].VhclNumbr, json[key].VhclId, json[key].PrjctId, json[key].PrjctName, json[key].FromTime, json[key].ToTime, json[key].JobMode, json[key].txtJobName, json[key].TransDtlId, 'TableaddedRowsPW');


                                //  alert(json[key].LdgrHeadId);
                                //  alert(json[key].Amount);
                            }
                        }
                    }

                }
                var ViewValDayWise = document.getElementById("<%=hiddenDataDayWise.ClientID%>").value;

                if (ViewValDayWise != "") {


                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = ViewValDayWise.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');
                    //alert(res3);
                    var json = $noCon.parseJSON(res3);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            if (json[key].TransId != "") {

                                ViewListRows(json[key].JobId, json[key].JobName, json[key].VhclNumbr, json[key].VhclId, json[key].PrjctId, json[key].PrjctName, json[key].FromTime, json[key].ToTime, json[key].JobMode, json[key].txtJobName, json[key].TransDtlId, 'TableaddedRowsDW');


                                //  alert(json[key].LdgrHeadId);
                                //  alert(json[key].Amount);
                            }
                        }
                    }

                }
            }
            else {

                //   var num = 0;
                //  var n = 0;
                // for floatting number adjustment from corp global
                //    var FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                //  if (FloatingValue != "") {
                //       var n = num.toFixed(FloatingValue);
                //  }
                // write  to Total Label



            }
            //  alert('hi');
            if (ViewVal == "") {
                //     alert('hi');
                if (document.getElementById("<%=hiddenConfirmedEntry.ClientID%>").value!="1") {
                    addMoreRows(this.form, false, 1, false, 0, 'TableaddedRowsPW');
                    addMoreRows(this.form, false, 1, false, 0, 'TableaddedRowsDW');
                }

                // alert('hi');
                document.getElementById("<%=txtFromDate.ClientID%>").focus();

            }


          //  alert('loaded');



        });
    </script>

    <script>
        function selectorToAutocompleteJob(obj, x) {


            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;

            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;



            if (CorpId != '' && CorpId != null && (!isNaN(CorpId)) && OrgId != '' && OrgId != null && (!isNaN(OrgId))) {

                $("#" + obj + x).autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: '<%=ResolveUrl("WebServiceAutoCompletionJobScheduling.asmx/GetJob") %>',
                            data: "{ 'strLikeJobName': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'intOrgId': '" + parseInt(OrgId) + "', 'intCorpId': '" + parseInt(CorpId) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('<->')[0],
                                        val: item.split('<->')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                                //  alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alert(response.responseText);
                            }
                        });
                    },
                    autoFocus: true,

                    select: function (e, i) {
                        document.getElementById("txtselectorJobId" + x).value = i.item.val;
                        document.getElementById("txtselectorJobName" + x).value = i.item.label;
                        //  alert(i.item.val);
                        //  alert(i.item.label);
                    },

                    minLength: 1

                });
            }


        }

        function selectorToAutocompleteVehicle(obj, x) {


            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;

            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;



            if (CorpId != '' && CorpId != null && (!isNaN(CorpId)) && OrgId != '' && OrgId != null && (!isNaN(OrgId))) {

                $("#" + obj + x).autocomplete({
                    source: function (request, response) {
                 
                        $.ajax({
                            url: '<%=ResolveUrl("WebServiceAutoCompletionJobScheduling.asmx/GetVehicle") %>',
                            data: "{ 'strLikeVehicleNumbr': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'intOrgId': '" + parseInt(OrgId) + "', 'intCorpId': '" + parseInt(CorpId) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('<->')[0],
                                        val: item.split('<->')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                                //  alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alert(response.responseText);
                            }
                        });
                    },
                    autoFocus: true,

                    select: function (e, i) {
                        document.getElementById("txtselectorVhclId" + x).value = i.item.val;
                        document.getElementById("txtselectorVhclName" + x).value = i.item.label;
                        //  alert(i.item.val);
                        //  alert(i.item.label);
                    },

                    minLength: 1

                });
            }


        }
        function selectorToAutocompleteProject(obj, x) {


            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;

                    var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;

           // var VhclId = document.getElementById("txtselectorVhclId" + x).value;
           
           // var FromDate=document.getElementById("<%=txtFromDate.ClientID%>").value;
           // var ToDate= document.getElementById("<%=txtToDate.ClientID%>").value;
          // alert('hi' + VhclId);

                    if (CorpId != '' && CorpId != null && (!isNaN(CorpId)) && OrgId != '' && OrgId != null && (!isNaN(OrgId))) {

                        $("#" + obj + x).autocomplete({
                            source: function (request, response) {

                                $.ajax({
                                    url: '<%=ResolveUrl("WebServiceAutoCompletionJobScheduling.asmx/GetProject") %>',
                                    data: "{ 'strLikeProjectName': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'intOrgId': '" + parseInt(OrgId) + "', 'intCorpId': '" + parseInt(CorpId) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('<->')[0],
                                        val: item.split('<->')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                                //  alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alert(response.responseText);
                            }
                        });
                    },
                    autoFocus: true,

                    select: function (e, i) {
                        document.getElementById("txtselectorPrjctId" + x).value = i.item.val;
                        document.getElementById("txtselectorPrjctName" + x).value = i.item.label;
                        //  alert(i.item.val);
                        //  alert(i.item.label);
                    },

                    minLength: 1

                });
            }


        }
        function selectorToAutocompleteTime(obj, x, TableName) {
           // alert(selectorToAutocompleteTime);
           
          
                $("#" + obj + x).autocomplete({
                    source: function (request, response) {
                        var StartTime = '';
                        var StopTime = '';
                       
                        if (TableName == 'TableaddedRowsPW') {
                            StartTime = document.getElementById("<%=hidden_DefalultStartTimePeriodWise.ClientID%>").value.trim();
                StopTime = document.getElementById("<%=hidden_DefalultEndTimePeriodWise.ClientID%>").value.trim();

            }
            else if (TableName == 'TableaddedRowsDW') {
                StartTime = document.getElementById("<%=hidden_DefalultStartTimeDayWise.ClientID%>").value.trim();
                StopTime = document.getElementById("<%=hidden_DefalultEndTimeDayWise.ClientID%>").value.trim();

            }

                   //     alert('StartTime ' + StartTime);
                   //     alert('StopTime ' + StopTime);
                        $.ajax({
                            url: '<%=ResolveUrl("WebServiceAutoCompletionJobScheduling.asmx/GetTime") %>',
                            data: "{ 'strLikeTime': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'strStartTime': '" + StartTime.trim() + "', 'strStopTime': '" + StopTime.trim() + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                  //  alert('no');
                                    if (TableName == 'TableaddedRowsPW') {
                                        document.getElementById("<%=hiddenPeriodWiseTimeDifferenceSts.ClientID%>").value = item.split('<->')[2];
                                        //alert()
                                        
                                    }
                                    else if (TableName == 'TableaddedRowsDW') { 
                                        document.getElementById("<%=hiddenDayWiseTimeDifferenceSts.ClientID%>").value = item.split('<->')[2];
                                    }
                                    return {
                                        label: item.split('<->')[0],
                                        val: item.split('<->')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                                //  alert(response.responseText);
                            },
                            failure: function (response) {
                                // alert(response.responseText);
                            }
                        });
                    },
                    autoFocus: true,

                    select: function (e, i) {



                        document.getElementById(obj + "Id" + x).value = i.item.label;

                        //alert(i.item.val);
                        //alert(i.item.label);
                    },

                    minLength: 1

                });

            

             }

             function TimeSlotSelected(SlotId, PeriodOrDayWise) {
              //   alert('SlotId ' + SlotId);
                 //web method for drop down of narrations for common narration
                 var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                        var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;

                        if (CorpId != '' && CorpId != null && OrgId != '' && OrgId != null && SlotId.toString() != '' && SlotId != null && SlotId != '--SELECT TIME SLOT--') {
                              //   alert('hi entered');
                            $.ajax({
                                type: "POST",
                                async: false,
                                contentType: "application/json; charset=utf-8",
                                url: "flt_Job_Shdl.aspx/TimeSlotDetails",
                                data: '{corporateId: "' + CorpId + '",organisationId:"' + OrgId + '" ,SLOTID:"' + SlotId + '"}',
                                dataType: "json",
                                success: function (data) {

                      if (data.d != '') {
                            if (PeriodOrDayWise == 'PeriodWise') {
                                    document.getElementById("<%=hidden_DefalultStartTimePeriodWise.ClientID%>").value = data.d.strStartTime;
                                    document.getElementById("<%=hidden_DefalultEndTimePeriodWise.ClientID%>").value = data.d.strEndTime;
                           
                            }
                            else if (PeriodOrDayWise == 'DayWise') {
                                document.getElementById("<%=hidden_DefalultStartTimeDayWise.ClientID%>").value = data.d.strStartTime;
                                document.getElementById("<%=hidden_DefalultEndTimeDayWise.ClientID%>").value = data.d.strEndTime;
                              

                            }
                              //  alert('strStartTime ' + data.d.strStartTime);
                               // alert('strEndTime ' + data.d.strEndTime);


                            //CalculateTotalAmountFromHiddenField();
                    }
                    },
                    error: function (result) {
                       // alert("Error");
                    }
                });

        }
    }
    function fun() {

        alert('dfg');
    }
    function ClearAll(TableName,ClearAllDayWiseField)
    {
        var $noC = jQuery.noConflict();
        //$("#TableaddedRowsDW tr").remove();
      //  addMoreRows(this.form, false, 1, false, 0, 'TableaddedRowsDW');
     //   alert('clearall');

        var table = document.getElementById(TableName);

          //  for (var i = 0, row; row = table.rows[i]; i++) {
        for (var i = table.rows.length-1;i>=0; i--) {
           
            var row = table.rows[i];
            if (row != null) {
                //iterate through rows
                //rows would be accessed using the "row" variable assigned in the for loop
                for (var j = 0, col; col = row.cells[j]; j++) {
                    if (j == 0) {
                        x = col.innerHTML;
                       // alert('1 ' + x);
                        removeRow(x, 'Are you sure you want to Delete this Entr?', false, TableName);

                    }

                    //iterate through columns
                    //columns would be accessed using the "col" variable assigned in the for loop
                    // alert(col.innerHTML);
                }
            }
            }

        
        if (ClearAllDayWiseField == true) {

            document.getElementById("<%=cbxMustDayWise.ClientID%>").disabled = false;
            document.getElementById("liWeekdays0").style.backgroundColor = "";
            document.getElementById("liWeekdays1").style.backgroundColor = "";
            document.getElementById("liWeekdays2").style.backgroundColor = "";
            document.getElementById("liWeekdays3").style.backgroundColor = "";
            document.getElementById("liWeekdays4").style.backgroundColor = "";
            document.getElementById("liWeekdays5").style.backgroundColor = "";
            document.getElementById("liWeekdays6").style.backgroundColor = "";
            document.getElementById("<%=hiddenWeekDayId.ClientID%>").value = "";


            document.getElementById("<%=cbxMustDayWise.ClientID%>").disabled = false;


            document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").value = '--SELECT TIME SLOT--';

            var a = $noC("#cphMain_ddlTimeSlot_DayWise option:selected").text();
            $noC("div#divTimeSlotDayWise input.ui-autocomplete-input").val(a);
            $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=cbxMustDayWise.ClientID%>").focus();


        }
        return false;

    }


        function confirmShdl() {

            if (confirm("Are You Sure You Want To Confirm this entry?")) {
                if (ValidateAndSave('Update',false) == true) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>


     <asp:HiddenField ID="HiddenFieldJobScdlID" runat="server" />


    <asp:HiddenField ID="hidden_DefalultStartTimePeriodWise" runat="server" />
    <asp:HiddenField ID="hidden_DefalultEndTimePeriodWise" runat="server" />
     <asp:HiddenField ID="hiddenPeriodWiseTimeDifferenceSts" runat="server" />
    <asp:HiddenField ID="hidden_DefalultStartTimeDayWise" runat="server" />
    <asp:HiddenField ID="hidden_DefalultEndTimeDayWise" runat="server" />
       <asp:HiddenField ID="hiddenDayWiseTimeDifferenceSts" runat="server" />
    
    <asp:HiddenField ID="HiddenField3" runat="server" />

    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="hiddenAllowJobDuplication" runat="server" Value="1" />
    <%--for duplication allowing--%>
      <asp:HiddenField ID="hiddenddlTimeSlotPWVal" runat="server" />
      <asp:HiddenField ID="hiddenddlTimeSlotDWVal" runat="server" />
    <asp:HiddenField ID="hiddenJSIdFocus" runat="server" />
    <asp:HiddenField ID="hiddenJSNameFocus" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
     <asp:HiddenField ID="hiddenDataPeriodWise" runat="server" />
     <asp:HiddenField ID="hiddenDataDayWise" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
      <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="hiddenFloatingValueMoney" runat="server" />
    <asp:HiddenField ID="hiddenPreviousTimeSlot" runat="server" />
    <asp:HiddenField ID="hiddenWeekDayId" runat="server" />
     <asp:HiddenField ID="hiddenDateCheck" runat="server" />
     <asp:HiddenField ID="hiddenEmpJSId" runat="server" />
      <asp:HiddenField ID="hiddenEmpJSIdQS" runat="server" />
     <asp:HiddenField ID="hiddenConfirmedEntry" runat="server" />
    <asp:Label ID="lblIndex" runat="server" Text="Label" Style="display: none"></asp:Label>

    <div class="cont_rght">


        <%--  --%>

        <div id="divMessageArea" style="display: none; margin: 0px 0 13px;">
            <img id="imgMessageArea" src="">
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>



        <br />

        <div class="fillform">
            <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="height: 26.5px; float: right;">

                <%--   <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
            </div>
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; width: 80%;">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
                
                <asp:Label ID="Label2" style="font-size: 20px;margin-left: 30%;color: rgb(154, 180, 108);" runat="server">Employee-</asp:Label>
                <asp:Label ID="lblEmpName" style="word-wrap: break-word;font-size: 20px;color: rgb(154, 180, 108);" runat="server"></asp:Label>

            </div>
            <br />
            <div style="font-size: 20px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; width: 80%;">
                <asp:Label ID="Label1" runat="server">Job Schedule-Period Wise</asp:Label>
                <%--<h2>Job Schedule-Period Wise</h2>--%>
            </div>
            <br />
            <div class="eachform" style="width: 25%; float: left;">
                <h2 style="float: left;">From Date*</h2>
                <div id="FromDate" class="input-append date" style="font-family: Calibri; float: right; width: 60%; margin-right: 8%;">
                    <asp:TextBox ID="txtFromDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event);" onblur="IncrmntConfrmCounter()" Style="width: 93.8%; height: 23px; font-family: calibri;"></asp:TextBox>

                    <img id="imgFD" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style="height: 19px; width: 17px; cursor: pointer;" />

                    <script type="text/javascript">
                        var $noC = jQuery.noConflict();
                        $noC('#FromDate').datetimepicker({
                            format: 'dd-MM-yyyy',
                            language: 'en',
                            pickTime: false,
                            startDate: new Date(),

                            // endDate: new Date(),
                        });

                    </script>
                    <p style="visibility: hidden">Please enter</p>
                </div>
            </div>
            <div class="eachform" style="width: 25%; float: left; padding-left: 2%;">
                <h2 style="float: left;">To Date*</h2>
                <div id="ToDate" class="input-append date" style="font-family: Calibri; float: right; width: 61%; margin-right: 8%;">
                    <asp:TextBox ID="txtToDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event);" onblur="IncrmntConfrmCounter()" Style="width: 93.8%; height: 23px; font-family: calibri;" ></asp:TextBox>

                    <img id="imgTD" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style="height: 19px; width: 17px; cursor: pointer;" />

                    <script type="text/javascript">
                        var $noC = jQuery.noConflict();
                        $noC('#ToDate').datetimepicker({
                            format: 'dd-MM-yyyy',
                            language: 'en',
                            pickTime: false,
                            startDate: new Date(),
                            // endDate: new Date(),
                        });

                    </script>
                    <p style="visibility: hidden">Please enter</p>
                </div>
            </div>
            <div id="divTimeSlotPeridWise" style="width: 30%; float: left; padding-left: 2%;" class="eachform">
                <h2 style="float: left;">Time Slot *</h2>
                <asp:DropDownList ID="ddlTimeSlot_PeriodWise" class="form1" Style="width: 70.5%; float: right;" runat="server" onblur="return ChangeTimeSlot('ddlTimeSlot_PeriodWise');" onfocus="getPreviousDDLTimeSlot_SelectedVal('ddlTimeSlot_PeriodWise')"></asp:DropDownList>

            </div>

            <div class="leads_form">
                <div id="divErrorNotification" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotification" runat="server"></asp:Label>
                </div>
                  <asp:Button ID="btnClearRowPW" runat="server" class="save" Text="Clear Period Wise Schedule" OnClientClick="return ClearAll('TableaddedRowsPW',false);" />
                <div id="divTablesPeriodWise" style="width: 100%; margin: auto; padding-top: 0.6%;">

                    <table class="TableHeader" rules="all" style="width: 95.3%;">

                        <tr>
                            <td style="font-size: 14px; width: 3.15%; padding-left: 0.5%; text-align: center;">Sl#</td>
                            <td style="font-size: 14px; width: 29.9%; padding-left: 0.5%; text-align: left;">Job</td>
                            <td style="font-size: 14px; width: 24.8%; padding-left: 0.5%; text-align: left;">Vehicle</td>
                            <td style="font-size: 14px; width: 24.7%; padding-left: 0.5%; text-align: left;">Project</td>
                            <td style="font-size: 14px; width: 8.7%; padding-left: 0.5%; text-align: center;">From Time</td>
                            <td style="font-size: 14px; width: 8.7%; padding-left: 0.5%; text-align: center;">To Time</td>

                        </tr>
                    </table>

                    <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                        <table id="TableaddedRowsPW" style="width: 100%;">
                        </table>



                   <%--evm-20--%> <span style="font-family: calibri;font-size: 14px; color: rgb(65, 78, 42);"> *NOTE: You can use F9 key to toggle between direct  Job entry and existing Job selection.</span>
                    </div>
                    <div id="divBlink" style="background-color: rgb(249, 246, 3); font-size: 10.5px; color: black; opacity: 0.6;"></div>

                </div>
            </div>
             <div id="divDayWiseHeader" style="width: 100%; float: left;display:block;font-size: 20px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;padding-bottom: 1%;padding-top: 1%;">

                    <asp:CheckBox ID="cbxMustDayWise" Text="Job Schedule-Day Wise" runat="server"  Checked="false" class="caption" onchange=" return ShowHideDiv('cphMain_cbxMustDayWise');" />
                 <div id="DivBtnClearAll" style="display:block;">
                 <asp:Button ID="btnClearAll" runat="server" class="save" Text="Clear Day Wise Schedule Details" OnClientClick="return ClearAll('TableaddedRowsDW',true);" />

                 </div>
                
                </div>

                <div id="divDayWiseContent">
        
           

            <div id="divWeekdays" style="width: 687px; float: left; padding-top: 0.5%; padding-bottom: 0.5%;padding-left:0.5%;font-family:Calibri;">
                <ul style="list-style-type: none; margin: 0; padding: 0; overflow: hidden; background-color: #686868; width: 98.5%;">
                    <li id="liWeekdays1" style="float: left; border: 0.5px solid;" onclick="SelectWeekdays('1')"><span class="clsSpanWeekdays">MONDAY</span></li>
                    <li id="liWeekdays2" style="float: left; border: 0.5px solid;" onclick="SelectWeekdays('2')"><span class="clsSpanWeekdays">TUESDAY</span></li>
                    <li id="liWeekdays3" style="float: left; border: 0.5px solid;" onclick="SelectWeekdays('3')"><span class="clsSpanWeekdays">WEDNESDAY</span></li>
                    <li id="liWeekdays4" style="float: left; border: 0.5px solid;" onclick="SelectWeekdays('4')"><span class="clsSpanWeekdays">THURSDAY</span></li>
                    <li id="liWeekdays5" style="float: left; border: 0.5px solid;" onclick="SelectWeekdays('5')"><span class="clsSpanWeekdays">FRIDAY</span></li>
                    <li id="liWeekdays6" style="float: left; border: 0.5px solid;" onclick="SelectWeekdays('6')"><span class="clsSpanWeekdays">SATURDAY</span></li>
                    <li id="liWeekdays0" style="float: left; border: 0.5px solid;" onclick="SelectWeekdays('0')"><span class="clsSpanWeekdays">SUNDAY</span></li>
                </ul>
            </div>
            <style>
                .clsSpanWeekdays {
                    display: block;
                    color: white;
                    text-align: center;
                    padding: 16px;
                    text-decoration: none;
                    cursor: pointer;
                }

                    .clsSpanWeekdays:hover {
                        background-color: #04B400;
                    }
            </style>
            <div id="divTimeSlotDayWise" style="width: 30%; float: left; padding-left: 2%; padding-top: 1.5%; padding-bottom: 2%;" class="eachform">
                <h2 style="float: left; margin-top: 1.5%;">Time Slot *</h2>
                <asp:DropDownList ID="ddlTimeSlot_DayWise" class="form1" Style="width: 70.5%; float: right;" runat="server" onblur="return ChangeTimeSlot('ddlTimeSlot_DayWise');" onfocus="getPreviousDDLTimeSlot_SelectedVal('ddlTimeSlot_DayWise')"></asp:DropDownList>

            </div>


            <div class="leads_form">
                <div id="divErrorNotificationDW" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotificationDW" runat="server"></asp:Label>
                </div>
                   <asp:Button ID="btnClearRowDW" runat="server" class="save" Text="Clear Day Wise Schedule" OnClientClick="return ClearAll('TableaddedRowsDW',false);" />
                <div id="divTablesDayWise" style="width: 100%; margin: auto; padding-top: 0.6%;">

                    <table class="TableHeader" rules="all" style="width: 95.3%;">

                        <tr>
                            <td style="font-size: 14px; width: 3.15%; padding-left: 0.5%; text-align: center;">Sl#</td>
                            <td style="font-size: 14px; width: 29.9%; padding-left: 0.5%; text-align: left;">Job</td>
                            <td style="font-size: 14px; width: 24.8%; padding-left: 0.5%; text-align: left;">Vehicle</td>
                            <td style="font-size: 14px; width: 24.7%; padding-left: 0.5%; text-align: left;">Project</td>
                            <td style="font-size: 14px; width: 8.7%; padding-left: 0.5%; text-align: center;">From Time</td>
                            <td style="font-size: 14px; width: 8.7%; padding-left: 0.5%; text-align: center;">To Time</td>

                        </tr>
                    </table>

                    <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                        <table id="TableaddedRowsDW" style="width: 100%;">
                        </table>
                        <%--<span style="font-family: calibri; color: rgb(65, 78, 42);"> *NOTE: You can use F9 key to toggle between direct  Job entry and existing Job selection.</span>--%>

                    </div>

                    
                </div>
            </div>
            </div>


            <div class="eachform" style="margin-top: 0.5%;">

                <div class="subform" style="margin-left: 36.8%; width: 55%; margin-top: 2%;">


                    <asp:Button ID="btnSave" runat="server" class="save" Text="Save" OnClientClick="return ValidateAndSave('Save',true);" OnClick="btnSave_Click" />
                     <asp:Button ID="btnReopen" runat="server" class="save" Text="Re-Open"  OnClick="btnReopen_Click" />
                     <asp:Button ID="btnConfirm" runat="server" class="save" Text="Confirm" OnClientClick="return confirmShdl();" OnClick="btnConfirm_Click" />
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClientClick="return ValidateAndSave('Update',false);" OnClick="btnUpdate_Click" />
                    <%--   <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClientClick="return ValidateAndSave('Update',false);" OnClick="btnUpdate_Click" />--%>
                <%--    <asp:Button ID="Button1" runat="server" class="save" Text="show" OnClientClick="return ShowHidden();" />--%> 
                    <%--<asp:Button ID="btnList" runat="server" class="save" Text="List"   OnClientClick="return ConfirmMessage();" />--%>
                    <asp:Button ID="btnCancel" runat="server" class="save" Text="Cancel" PostBackUrl="flt_Job_Shdl_List.aspx" />
                    <asp:Button ID="btnClear" runat="server" class="save" Text="Clear" OnClientClick="return ConfirmClear();" />
                    <%--<asp:Button ID="btnClose" runat="server" class="save" Text="Close" OnClientClick="return ConfirmMessage();" />--%>
                  <%--   <asp:Button ID="Button2" runat="server" class="cancel" Text="weekdastest" OnClientClick="return testWeekdays();" /> --%>
                </div>

            </div>


        </div>
    </div>




</asp:Content>
