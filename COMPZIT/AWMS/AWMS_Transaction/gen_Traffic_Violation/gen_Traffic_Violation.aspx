<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Traffic_Violation.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Traffic_Violation_gen_Traffic_Violation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
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
        /*.input-append .add-on {
            margin-top: -5%;
            padding-top: 2%;
            padding-bottom: 3%;
            cursor: pointer;
        }*/
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

                    window.location.href = "/AWMS/AWMS_Transaction/gen_Traffic_Violation/gen_Traffic_Violation_List.aspx";

                    return false;
                }
                else {
                    return false;

                }
            }
            else {

                window.location.href = "/AWMS/AWMS_Transaction/gen_Traffic_Violation/gen_Traffic_Violation_List.aspx";

                return false;
            }
        }
        function ConfirmClear() {
            if (confirmbox > 0) {

                if (confirm("Are You Sure You Want Clear All Data In This Page?")) {

                    window.location.href = "gen_Traffic_Violation.aspx";

                    return false;
                }
                else {
                    return false;

                }
            }
            else {

                window.location.href = "gen_Traffic_Violation.aspx";

                return false;
            }
        }
        //stop-0006
    </script>

    <script>


        function RedirectConFirm(TrfcVioltnId) {

            document.getElementById("<%=HiddenField1.ClientID%>").value = "";
            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";
            localStorage.clear();
            VehicleSelected('0');

            if (confirm("Do you want to confirm this Entry?")) {

                window.location.href = "gen_Traffic_Violation.aspx?Id=" + TrfcVioltnId + "&InsUpd=CnfrmPnd";

            }
            else {

                window.location.href = "gen_Traffic_Violation.aspx?InsUpd=Save";

            }
        }
        function RedirectConFirmAdCls(TrfcVioltnId) {

            document.getElementById("<%=HiddenField1.ClientID%>").value = "";
            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";
            localStorage.clear();
            VehicleSelected('0');

            if (confirm("Do you want to confirm this Entry?")) {

                window.location.href = "gen_Traffic_Violation.aspx?Id=" + TrfcVioltnId + "&InsUpd=CnfrmPnd";

            }
            else {

                window.location.href = "gen_Traffic_Violation.aspx?InsUpd=Save";

            }
        }

        function SuccessSave() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Traffic Violation Details Saved Successfully.";
        }
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Traffic Violation Details Confirmed Successfully.";
        }
        function FailureConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirmation  Not Successfull. It is already Confirmed.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Traffic Violation Details Updated Successfully.";
        }

        function SuccessReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Traffic Violation Details Re-Opened Successfully.";
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
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Traffic Violation Details Inserted Successfully.Confirmation Pending";
        }


    </script>
    <script>

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

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }


        //  End -->>
        function ShowHidden() {
            var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
            alert('Main ' + h);

           // var MainCancDtlld = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value
            //alert('MainCancDtlld ' + MainCancDtlld);
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
                    $noCon("#" + objDestntn).select();
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
        function isTagNameEmp(Srcobj, Dstnobj, x, event) {
            //for item name and unit name
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;

            // alert(keyCode);
            if (keyCode == 13) {
                document.getElementById(Dstnobj).focus();
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
            var $au = jQuery.noConflict();

            (function ($au) {
                $au(function () {
                    selectorToAutocompleteTextBox('txtselectorEmp' + rowCount, rowCount);
                    selectorToAutocompleteTextBox('txtVioltn' + rowCount, rowCount);
                    //   $('#selectorItem' + rowCount).selectToAutocomplete();

                    $au('form').submit(function () {

                        //   alert($au(this).serialize());


                        //   return false;
                    });
                });
            })(jQuery);

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
            else if (keyCodes == 173 || keyCodes == 189 || keyCodes == 109) {
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


        // For adjust to decimal point also used for checking
        function DateCheck(obj, x, rtn) {

           
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
                //alert(obj + x+'='+"txtDate"+ x);
                
                if (obj == "txtDate") {
                    
                    if (RdateDateCntrlr > dateCurrentDate) {
                        document.getElementById(obj + x).style.borderColor = "Red";
                        document.getElementById(obj + x).focus();
                        document.getElementById('divErrorNotification').style.visibility = "visible";
                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, Violation Date cannot be Greater than Current Date !.";
                        ret = false;
                    }
                }
                if (obj == "txtSettledDate") {
                    var CurrentDateDate1 = document.getElementById("txtDate"+x).value;
                    var arrCurrentDate1 = CurrentDateDate1.split("-");
                    var dateCurrentDate1 = new Date(arrCurrentDate1[2], arrCurrentDate1[1] - 1, arrCurrentDate1[0]);

                    if (RdateDateCntrlr > dateCurrentDate) {
                        document.getElementById(obj + x).style.borderColor = "Red";
                        document.getElementById(obj + x).focus();
                        document.getElementById('divErrorNotification').style.visibility = "visible";
                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, Settled Date cannot be Greater than Current Date !.";
                        ret = false;
                    }
                    if (RdateDateCntrlr < dateCurrentDate1) {
                        document.getElementById(obj + x).style.borderColor = "Red";
                        document.getElementById(obj + x).focus();
                        document.getElementById('divErrorNotification').style.visibility = "visible";
                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, Settled Date cannot be Less than Violation Date !.";
                        ret = false;
                    }
                }

                //  document.getElementById(obj + x).value = Rcptdate;
            }
            if (rtn == true) {
                return ret;
            }
        }

        // For adjust to decimal point also used for checking
        function ValueCheck(obj, x, rtn) {

             //alert(obj);
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


                if (obj == 'txtAmnt' || 'txtSettledAmnt') {
                    FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                }

                if (FloatingValue != "") {

                    n = num.toFixed(FloatingValue);
                }

                document.getElementById(obj + x).value = n;
            }

                //if true
            else {
                //alert('hi');

                    v = Val.split(',').join('');

                    var amt = parseFloat(v);

                    var num = amt;
                    var n = Val;

                    // for floatting number adjustment from corp global
                    var FloatingValue = 0;

                    if (obj == 'txtAmnt' || 'txtSettledAmnt') {
                        FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                    }

                    if (FloatingValue != "") {

                        n = num.toFixed(FloatingValue);
                    }

                    document.getElementById(obj + x).value = addCommas(n);
                }
          
                                 if (rtn == true) {
                                     return ret;
                                 }
        }
        function addCommas(nStr) {
            
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];
            //var a = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;
            //alert('hi'+a);
            if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "1") {
              
                var rgx = /(\d+)(\d{7})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{5})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{3})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
            }

            if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "2") {
                
                var rgx = /(\d+)(\d{9})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }

                rgx = /(\d+)(\d{6})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{5})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{3})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
            }
            if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "3") {
               
                var rgx = /(\d+)(\d{9})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{6})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{3})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
            }




            if (isNaN(x2))
                return x1;
            else
                return x1 + "." + x2;
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
        .divSettlmntDetls {
            font-family: Calibri;
            padding-bottom: 2%;
            overflow-x: auto;
            background: #f4f6f0;
            margin: 0 0 5px;
            border: 1px solid #9BA48B;
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
        }

            .cont_rght h2 {
                float: none;
                color: rgb(83, 101, 51);
                margin: 0 0 0px;
                font-size: 17px;
            }

        .ui-autocomplete {
            width: 37.5% !important;
            max-height: 190px !important;
        }
    </style>

    <style type="text/css">
        .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
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
        #TableHeaderTrfcVoltn {
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

    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link rel="stylesheet" href="../../../css/Autocomplete/jquery-ui.css" />


    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script src="/JavaScript/datepicker/bootstrap-datepicker.js"></script>

    <link href="/JavaScript/datepicker/datepicker3.css" rel="stylesheet" />

    <script type="text/javascript">



        var $noC = jQuery.noConflict();
        var rowCount = 0;
        //rowCount for uniquness
        //row index add(+) and (-)delete count based on action
        var RowIndex = 0;


          function addMoreRows(frm, boolFocus, boolAppendorNot, row_index) {
              //alert('add row');
            document.getElementById('divErrorNotification').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
            rowCount++;
            RowIndex++;
            var num = 0;
            var nMoney = 0;


            var AmntMaxLen = 12;

            // for floatting number adjustment from corp global
            var FloatingValueMoney = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
            if (FloatingValueMoney != "") {

                nMoney = num.toFixed(FloatingValueMoney);
                //floating value show the lenght of floating decimal 
                //added one for fullstop

            }






            // alert('ADD');
            //   alert(RowIndex.toString());
            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();

            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
            recRow += '<td style="width: 2.8%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


            recRow += ' <td id="tdDate' + rowCount + '"  style="width: 10.4%;" class="input-append date">';
            recRow += ' <input  id="txtDate' + rowCount + '"  class="BillngEntryField" placeholder="DD-MM-YYYY" type="text"   onkeypress="return isTagDateEnter(\'txtDate' + rowCount + '\',\'txtselectorEmp' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return isTagDate(\'txtDate' + rowCount + '\',\'txtselectorEmp' + rowCount + '\',' + rowCount + ', event)" onchange="return BlurTVVioltnDate(\'txtDate\',' + rowCount + ')" onfocus="return FocusValue(\'txtDate\',' + rowCount + ')"  maxlength=10 style="text-align: left; line-height: 20px; margin-top:0.5px; margin-bottom: 2px; width: 94%;margin-left: 0%; "/>';
            recRow += '   </td> ';

            recRow += ' <td id="tdEmp' + rowCount + '" style="width: 27%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98.2%;margin-left: 0%;" id="txtselectorEmp' + rowCount + '" class="BillngEntryField" type="text"  value="--Select Employee--"  onkeypress="return isTagNameEmp(\'txtselectorEmp' + rowCount + '\',\'txtVioltn' + rowCount + '\',' + rowCount + ', event)"   onblur="return BlurTVEmp(' + rowCount + ')" onfocus="return FocusTVEmp(' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorEmpId' + rowCount + '"  value="--Select Employee--" type="text"   /></td>';
            recRow += ' <td  style="display: none;"><input id="txtselectorEmployee' + rowCount + '" value="--Select Employee--" type="text" maxlength=100  /></td>';




            recRow += ' <td id="tdVioltn' + rowCount + '" style="width: 26.8%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0%;" id="txtVioltn' + rowCount + '" class="BillngEntryField" type="text" value="--Select Violation--"  onkeypress="return isTagName(\'txtVioltn' + rowCount + '\',\'cbxSettled' + rowCount + '\',' + rowCount + ', event)"  onblur="return BlurTVVioltn(' + rowCount + ')" onfocus="return FocusTVVioltn(' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorVioltnId' + rowCount + '"  value="--Select Violation--" type="text"   /></td>';
            recRow += ' <td  style="display: none;"><input id="txtselectorVioltn' + rowCount + '" value="--Select Violation--" type="text" maxlength=100  /></td>';



            recRow += ' <td style="width: 9.5%;"><input disabled  id="txtAmnt' + rowCount + '" class="BillngEntryField" value="' + nMoney + '" type="text"    maxlength="' + AmntMaxLen + '" onkeydown="return isNumber(\'txtAmnt' + rowCount + '\',\'cbxSettled' + rowCount + '\', event)"   onblur="return BlurValue(\'txtAmnt\',' + rowCount + ')" onfocus="FocusValue(\'txtAmnt\',' + rowCount + ')"  style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 94%;margin-left: 0%;"/></td>';


            recRow += ' <td id="tdCbxSettled' + rowCount + '" style="width: 5%;"><div class="Cls' + rowCount + '" style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-top: -5%; width: 98%;margin-left: 0%;"   >';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 1.5px; width: 45%;margin-left: 30%;" id="cbxSettled' + rowCount + '" class="BillngEntryField"  type="checkbox"    onkeypress="return isTagName(\'cbxSettled' + rowCount + '\',\'txtSettledAmnt' + rowCount + '\',' + rowCount + ', event)" onclick="return ClickCbx(\'cbxSettled\',' + rowCount + ')"  onblur="return BlurCbx(\'cbxSettled\',' + rowCount + ')" onfocus="return FocusValue(\'cbxSettled\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' </td>';


            recRow += ' <td style="width: 9.5%;"><input disabled id="txtSettledAmnt' + rowCount + '" class="BillngEntryField" value="' + nMoney + '" type="text"    maxlength="' + AmntMaxLen + '" onkeydown="return isNumber(\'txtSettledAmnt' + rowCount + '\',\'txtSettledDate' + rowCount + '\', event)"   onblur="return BlurValue(\'txtSettledAmnt\',' + rowCount + ')" onfocus="FocusValue(\'txtSettledAmnt\',' + rowCount + ')"  style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 96%;margin-left: 0%;"/></td>';

            recRow += ' <td id="tdSettledDate' + rowCount + '"  style="width: 9.4%;" class="input-append date">';
            recRow += ' <input disabled id="txtSettledDate' + rowCount + '"  class="BillngEntryField" placeholder="DD-MM-YYYY" type="text"   onkeypress="return isTagDateEnter(\'txtSettledDate' + rowCount + '\',\'tdIndvlAddMoreRow' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return isTagDate(\'txtSettledDate' + rowCount + '\',\'tdIndvlAddMoreRow' + rowCount + '\',' + rowCount + ', event)" onchange="return BlurTVStldDate(\'txtSettledDate\',' + rowCount + ')" onfocus="FocusValue(\'txtSettledDate\',' + rowCount + ')"  maxlength=10 style="text-align: left; line-height: 20px; margin-top:0.5px; margin-bottom: 2px; width: 95%;margin-left: 0%; "/>';

            recRow += '   </td> ';



            recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRows(\'' + rowCount + '\',true);"  style="  cursor: pointer;"></td>';
            recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\');"    style=" cursor: pointer;" ></td>';

            recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
            recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
            recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';
              // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';


            recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
            recRow += '</tr>';






            if (boolAppendorNot == false) {
                //to append
                jQuery('#TableaddedRows').append(recRow);
            }
            else {

                // to insert in perticular position
                var $NoAppnd = jQuery.noConflict();
                if (parseInt(row_index) != 0) {
                    $NoAppnd('#TableaddedRows > tbody > tr').eq(parseInt(row_index) - 1).after(recRow);
                }
                else {

                    var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                    if (parseInt(TableRowCount) != 0) {
                        $NoAppnd('#TableaddedRows > tbody > tr').eq(parseInt(row_index)).before(recRow);
                    }
                    else {
                        //if table row count is 0
                        jQuery('#TableaddedRows').append(recRow);
                    }
                }




            }








            var $au = jQuery.noConflict();

            (function ($au) {
                $au(function () {
                    selectorToAutocompleteTextBox('txtselectorEmp' + rowCount, rowCount);
                    selectorToAutocompleteTextBox('txtVioltn' + rowCount, rowCount);
                    //   $('#selectorItem' + rowCount).selectToAutocomplete();

                    $au('form').submit(function () {

                        //   alert($au(this).serialize());


                        //   return false;
                    });
                });
            })(jQuery);

            //have to look into it
            //  PopulateList(rowCount);
            //-------------------------------------------------------------
           




            ////   alert('add rows');

            $noC('#txtDate' + rowCount).datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                endDate: new Date(),
            });

            $noC('#txtSettledDate' + rowCount).datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                endDate: new Date()
            });
        }


function EditListRows(EditRcptNumbr,EditStldUsrID,EditVioltnDate,EditEmpId, EditEmpName,EditVioltnId, EditVioltn,EditVioltnAmnt, EditStldSts, EditStldAmnt,EditStldDate, EditRcptAmnt, EditDtlId) {

    //  alert('EditDtlId ' + EditDtlId);// && EditHike != "" && EditAmount != "" && EditStockStatus != ""
    if (EditVioltnDate != "" && EditEmpId != "" && EditVioltnId != "" && EditVioltnAmnt.toString() != "" && EditDtlId != "") {

       // alert('Edited');
        rowCount++;
        RowIndex++;


        var nVioltnAmnt = EditVioltnAmnt;
        var nStldAmnt = EditVioltnAmnt;
        var nRcptAmnt = EditVioltnAmnt;
        var AmntMaxLen = 12;
        var cbxStld;
        if (EditStldSts == 1) {
            cbxStld = true;
        }
        else {
           
            cbxStld = false;
        }
        // for floatting number adjustment from corp global
        var FloatingValueMoney = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                if (FloatingValueMoney != "") {


                    nVioltnAmnt = addCommas(EditVioltnAmnt.toFixed(FloatingValueMoney));
                    nStldAmnt =addCommas(EditStldAmnt.toFixed(FloatingValueMoney));
                    nRcptAmnt = EditRcptAmnt.toFixed(FloatingValueMoney);
                }




                //      document.getElementById("spanAddRowTax").style.opacity = "0.3";



                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 2.8%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';

                
                recRow += ' <td id="tdDate' + rowCount + '"  style="width: 10.4%;" class="input-append date">';
                recRow += ' <input  id="txtDate' + rowCount + '"  class="BillngEntryField" placeholder="DD-MM-YYYY" type="text" value="' + EditVioltnDate + '"  onkeypress="return isTagDateEnter(\'txtDate' + rowCount + '\',\'txtselectorEmp' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return isTagDate(\'txtDate' + rowCount + '\',\'txtselectorEmp' + rowCount + '\',' + rowCount + ', event)" onchange="return BlurTVVioltnDate(\'txtDate\',' + rowCount + ')" onfocus="return FocusValue(\'txtDate\',' + rowCount + ')"  maxlength=10 style="text-align: left; line-height: 20px; margin-top:0.5px; margin-bottom: 2px; width: 94%;margin-left: 0%; "/>';

                recRow += '   </td> ';

                recRow += ' <td id="tdEmp' + rowCount + '" style="width: 27%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98.2%;margin-left: -0%;" id="txtselectorEmp' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditEmpName + '"  onkeypress="return isTagNameEmp(\'txtselectorEmp' + rowCount + '\',\'txtVioltn' + rowCount + '\',' + rowCount + ', event)"   onblur="return BlurTVEmp(' + rowCount + ')" onfocus="return FocusTVEmp(' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorEmpId' + rowCount + '" value="' + EditEmpId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorEmployee' + rowCount + '" value="' + EditEmpName + '" type="text" maxlength=100  /></td>';




                recRow += ' <td id="tdVioltn' + rowCount + '" style="width: 26.8%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0%;" id="txtVioltn' + rowCount + '" class="BillngEntryField" type="text" value="' + EditVioltn + '"  onkeypress="return isTagName(\'txtVioltn' + rowCount + '\',\'cbxSettled' + rowCount + '\',' + rowCount + ', event)"  onblur="return BlurTVVioltn(' + rowCount + ')" onfocus="return FocusTVVioltn(' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorVioltnId' + rowCount + '" value="' + EditVioltnId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorVioltn' + rowCount + '" value="' + EditVioltn + '" type="text" maxlength=100  /></td>';



                recRow += ' <td style="width: 9.5%;"><input disabled  id="txtAmnt' + rowCount + '" class="BillngEntryField" value="' + nVioltnAmnt + '" type="text"    maxlength="' + AmntMaxLen + '" onkeydown="return isNumber(\'txtAmnt' + rowCount + '\',\'cbxSettled' + rowCount + '\', event)"   onblur="return BlurValue(\'txtAmnt\',' + rowCount + ')" onfocus="FocusValue(\'txtAmnt\',' + rowCount + ')"  style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 94%;margin-left: 0%;"/></td>';


                recRow += ' <td id="tdCbxSettled' + rowCount + '" style="width: 5%;"><div class="Cls' + rowCount + '" style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-top: -5%; width: 98%;margin-left: 0%;"   >';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 1.5px; width: 45%;margin-left: 30%;" id="cbxSettled' + rowCount + '" class="BillngEntryField"  type="checkbox"   onkeypress="return isTagName(\'cbxSettled' + rowCount + '\',\'txtSettledAmnt' + rowCount + '\',' + rowCount + ', event)" onclick="return ClickCbx(\'cbxSettled\',' + rowCount + ')"  onblur="return BlurCbx(\'cbxSettled\',' + rowCount + ')" onfocus="return FocusValue(\'cbxSettled\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' </td>';


                recRow += ' <td style="width: 9.5%;"><input  id="txtSettledAmnt' + rowCount + '" class="BillngEntryField" value="' + nStldAmnt + '" type="text"    maxlength="' + AmntMaxLen + '" onkeydown="return isNumber(\'txtSettledAmnt' + rowCount + '\',\'txtSettledDate' + rowCount + '\', event)"   onblur="return BlurValue(\'txtSettledAmnt\',' + rowCount + ')" onfocus="FocusValue(\'txtSettledAmnt\',' + rowCount + ')"  style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 96%;margin-left: 0%;"/></td>';

                recRow += ' <td id="tdSettledDate' + rowCount + '"  style="width: 9.4%;" class="input-append date">';
                recRow += ' <input  id="txtSettledDate' + rowCount + '"  class="BillngEntryField" placeholder="DD-MM-YYYY" type="text" value="' + EditStldDate + '"  onkeypress="return isTagDateEnter(\'txtSettledDate' + rowCount + '\',\'tdIndvlAddMoreRow' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return isTagDate(\'txtSettledDate' + rowCount + '\',\'tdIndvlAddMoreRow' + rowCount + '\',' + rowCount + ', event)" onchange="return BlurTVStldDate(\'txtSettledDate\',' + rowCount + ')" onfocus="FocusValue(\'txtSettledDate\',' + rowCount + ')"  maxlength=10 style="text-align: left; line-height: 20px; margin-top:0.5px; margin-bottom: 2px; width: 95%;margin-left: 0%; "/>';

                recRow += '   </td> ';


                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRows(' + rowCount + ',true);"  style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\');"    style=" cursor: pointer;" ></td>';


                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + EditDtlId + '</td>';

                // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';


                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';






                jQuery('#TableaddedRows').append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
                //  document.getElementById("selectorItem" + rowCount).focus();
                // alert('add rows');
                document.getElementById("cbxSettled" + rowCount).checked = cbxStld;
                if (cbxStld == false) {
                    document.getElementById("txtSettledAmnt" + rowCount).disabled = true;
                    document.getElementById("txtSettledDate" + rowCount).disabled=true;
                }
                var $au = jQuery.noConflict();

                (function ($au) {
                    $au(function () {
                        selectorToAutocompleteTextBox('txtselectorEmp' + rowCount, rowCount);
                        selectorToAutocompleteTextBox('txtVioltn' + rowCount, rowCount);
                        //   $('#selectorItem' + rowCount).selectToAutocomplete();

                        $au('form').submit(function () {

                            //   alert($au(this).serialize());


                            //   return false;
                        });
                    });
                })(jQuery);


                LocalStorageAdd(rowCount);

            }
            else {

                // alert('error');
            }
    $noC('#txtDate' + rowCount).datepicker({
        autoclose: true,
        format: 'dd-mm-yyyy',
        language: 'en',
        endDate: new Date()
    });

    $noC('#txtSettledDate' + rowCount).datepicker({
        autoclose: true,
        format: 'dd-mm-yyyy',
        language: 'en',
        endDate: new Date()
    });
        }

        function ViewListRows(EditRcptNumbr, EditStldUsrID, EditVioltnDate, EditEmpId, EditEmpName, EditVioltnId, EditVioltn, EditVioltnAmnt, EditStldSts, EditStldAmnt, EditStldDate, EditRcptAmnt, EditDtlId) {
            //  alert('EditDtlId ' + EditDtlId);// && EditHike != "" && EditAmount != "" && EditStockStatus != ""
            if (EditVioltnDate != "" && EditEmpId != "" && EditVioltnId != "" && EditVioltnAmnt.toString() != "" && EditDtlId != "") {


                rowCount++;
                RowIndex++;


                var nVioltnAmnt = EditVioltnAmnt;
                var nStldAmnt = EditVioltnAmnt;
                var nRcptAmnt = EditVioltnAmnt;
                var AmntMaxLen = 12;
                var cbxStld;
                if (EditStldSts == 1) {
                    cbxStld = true;
                }
                else {
                    cbxStld = false;
                }
                // for floatting number adjustment from corp global
                var FloatingValueMoney = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
        if (FloatingValueMoney != "") {


            nVioltnAmnt = addCommas(EditVioltnAmnt.toFixed(FloatingValueMoney));
            nStldAmnt = addCommas(EditStldAmnt.toFixed(FloatingValueMoney));
            nRcptAmnt = EditRcptAmnt.toFixed(FloatingValueMoney);
        }




        //      document.getElementById("spanAddRowTax").style.opacity = "0.3";



        document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 2.8%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';

                
                recRow += ' <td id="tdDate' + rowCount + '"  style="width: 10.4%;" class="input-append date">';
                recRow += ' <input disabled id="txtDate' + rowCount + '"  class="BillngEntryField" placeholder="DD-MM-YYYY" type="text" value="' + EditVioltnDate + '"  onkeypress="return isTagDateEnter(\'txtDate' + rowCount + '\',\'txtselectorEmp' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return isTagDate(\'txtDate' + rowCount + '\',\'txtselectorEmp' + rowCount + '\',' + rowCount + ', event)" onblur="return BlurTVDate(\'txtDate\',' + rowCount + ')" onfocus="return FocusValue(\'txtDate\',' + rowCount + ')"  maxlength=10 style="text-align: left; line-height: 20px; margin-top:0.5px; margin-bottom: 2px; width: 72%;margin-left: 0%; "/>';
                recRow += ' <img class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:16px; width:18px" />';
                recRow += '   </td> ';

                recRow += ' <td id="tdEmp' + rowCount + '" style="width: 27%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98.2%;margin-left: 0%;" id="txtselectorEmp' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditEmpName + '"  onkeypress="return isTagNameEmp(\'txtselectorEmp' + rowCount + '\',\'txtVioltn' + rowCount + '\',' + rowCount + ', event)"   onblur="return BlurTVEmp(' + rowCount + ')" onfocus="return FocusTVEmp(' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorEmpId' + rowCount + '" value="' + EditEmpId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorEmployee' + rowCount + '" value="' + EditEmpName + '" type="text" maxlength=100  /></td>';




                recRow += ' <td id="tdVioltn' + rowCount + '" style="width: 26.8%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0%;" id="txtVioltn' + rowCount + '" class="BillngEntryField" type="text" value="' + EditVioltn + '"  onkeypress="return isTagName(\'txtVioltn' + rowCount + '\',\'txtAmnt' + rowCount + '\',' + rowCount + ', event)"  onblur="return BlurTVVioltn(' + rowCount + ')" onfocus="return FocusTVVioltn(' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorVioltnId' + rowCount + '" value="' + EditVioltnId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorVioltn' + rowCount + '" value="' + EditVioltn + '" type="text" maxlength=100  /></td>';



                recRow += ' <td style="width: 9.5%;"><input disabled id="txtAmnt' + rowCount + '" class="BillngEntryField" value="' + nVioltnAmnt + '" type="text"    maxlength="' + AmntMaxLen + '" onkeydown="return isNumber(\'txtAmnt' + rowCount + '\',\'cbxSettled' + rowCount + '\', event)"   onblur="return BlurValue(\'txtAmnt\',' + rowCount + ')" onfocus="FocusValue(\'txtAmnt\',' + rowCount + ')"  style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 94%;margin-left: 0%;"/></td>';


                recRow += ' <td id="tdCbxSettled' + rowCount + '" style="width: 5%;"><div class="Cls' + rowCount + '" style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-top: -5%; width: 98%;margin-left: 0%;"   >';
                recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 1.5px; width: 45%;margin-left: 30%;" id="cbxSettled' + rowCount + '" class="BillngEntryField"  type="checkbox"    onkeypress="return isTagName(\'cbxSettled' + rowCount + '\',\'txtSettledAmnt' + rowCount + '\',' + rowCount + ', event)"   onblur="return BlurCbx(\'cbxSettled\',' + rowCount + ')" onfocus="return FocusValue(\'cbxSettled\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' </td>';


                recRow += ' <td style="width: 9.5%;"><input disabled id="txtSettledAmnt' + rowCount + '" class="BillngEntryField" value="' + nStldAmnt + '" type="text"    maxlength="' + AmntMaxLen + '" onkeydown="return isNumber(\'txtSettledAmnt' + rowCount + '\',\'txtSettledDate' + rowCount + '\', event)"   onblur="return BlurValue(\'txtSettledAmnt\',' + rowCount + ')" onfocus="FocusValue(\'txtSettledAmnt\',' + rowCount + ')"  style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 96%;margin-left: 0%;"/></td>';

                recRow += ' <td id="tdSettledDate' + rowCount + '"  style="width: 9.4%;" class="input-append date">';
                recRow += ' <input disabled id="txtSettledDate' + rowCount + '"  class="BillngEntryField" placeholder="DD-MM-YYYY" type="text" value="' + EditStldDate + '"  onkeypress="return isTagDateEnter(\'txtSettledDate' + rowCount + '\',\'tdIndvlAddMoreRow' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return isTagDate(\'txtSettledDate' + rowCount + '\',\'tdIndvlAddMoreRow' + rowCount + '\',' + rowCount + ', event)" onblur="return BlurTVDate(\'txtSettledDate\',' + rowCount + ')" onfocus="FocusValue(\'txtSettledDate\',' + rowCount + ')"  maxlength=10 style="text-align: left; line-height: 20px; margin-top:0.5px; margin-bottom: 2px; width:68%;margin-left: 0%; "/>';
                recRow += ' <img class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:16px; width:16px" />';
                recRow += '   </td> ';


                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input disabled id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRows(' + rowCount + ',true);"  style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 1.5%; padding-left: 1px;"><input disabled type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\');"    style=" cursor: pointer;" ></td>';


                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + EditDtlId + '</td>';

        // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';


                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';


                jQuery('#TableaddedRows').append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
                //  document.getElementById("selectorItem" + rowCount).focus();
                // alert('add rows');
                document.getElementById("cbxSettled" + rowCount).checked = cbxStld;



                LocalStorageAdd(rowCount);

            }
            else {

                // alert('error');
            }


        }



        function removeRow(removeNum, CofirmMsg) {
            if (confirm(CofirmMsg)) {

                var row_index = jQuery('#rowId_' + removeNum).index();
                var BforeRmvTableRowCount = document.getElementById("TableaddedRows").rows.length;

                LocalStorageDelete(row_index, removeNum);

                jQuery('#rowId_' + removeNum).remove();
                RowIndex--;
                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();
                var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                if (TableRowCount != 0) {
                    var idlast = $noC('#TableaddedRows tr:last').attr('id');
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


                    addMoreRows(this.form, true, false, 0);

                    //    document.getElementById("spanAddRow").style.opacity = "1";

                }


                //  LocalStorageDelete(row_index,removeNum);

                //     alert('BforeRmvTableRowCount ' + BforeRmvTableRowCount);
                //    alert('row_index ' + row_index);
                //for focussing to next or previous accordingly
                // While delete, then focus to be moved to next row (If there is any row below of current row) 
                // While delete, then focus to be moved to previous row (If there is any row above of current row) 
                if (BforeRmvTableRowCount > 1) {

                    if ((BforeRmvTableRowCount - 1) == row_index) {
                        var table = document.getElementById("TableaddedRows");
                        var preRowId = table.rows[row_index - 1].id;
                        if (preRowId != "") {
                            var res = preRowId.split("_");
                            if (res[1] != "") {


                                document.getElementById("txtDate" + res[1]).focus();
                                $noCon("#txtDate" + res[1]).select();
                                ReNumberTable();

                            }
                        }
                    }
                    else {

                        var table = document.getElementById("TableaddedRows");
                        var NxtRowId = table.rows[row_index].id;
                        //          alert('NxtRowId ' + NxtRowId);
                        if (NxtRowId != "") {
                            var res = NxtRowId.split("_");
                            if (res[1] != "") {

                                document.getElementById("txtDate" + res[1]).focus();
                                $noCon("#txtDate" + res[1]).select();
                                ReNumberTable();

                            }
                        }


                    }
                }

                return false;
            }
            else {
                return false;

            }
        }



    </script>

    <script>
        var $noCon = jQuery.noConflict();
        function ChangeVehicleNumber() {
            var $noCT = jQuery.noConflict();
            var PreviousVal = document.getElementById("<%=hiddenPreviousVehicleNumber.ClientID%>").value;



            var DropdownVehicleNumber = document.getElementById("<%=ddlVehicleNumber.ClientID%>");
            var SelectedValueVehicleNumber = DropdownVehicleNumber.value;

            if (SelectedValueVehicleNumber != PreviousVal) {
                //  alert('i');
                if (SelectedValueVehicleNumber == '--SELECT VEHICLE NUMBER--') {

                    SelectedValueVehicleNumber = 0;
                }
                if (SelectedValueVehicleNumber != 0) {
                    VehicleSelected(SelectedValueVehicleNumber);
                    $noCon("div#divVehicleNumber input.ui-autocomplete-input").css("borderColor", "");
                    IncrmntConfrmCounter();
                }
                else {
                    VehicleSelected('0');
                    IncrmntConfrmCounter();
                    return false;
                }
            }
            else {
                return false;
            }
        }

        function IsVehicleSelected() {

            var DropdownVehicleNumber = document.getElementById("<%=ddlVehicleNumber.ClientID%>");
            var SelectedValueVehicleNumber = DropdownVehicleNumber.value;


            if (SelectedValueVehicleNumber == '--SELECT VEHICLE NUMBER--') {

                //    document.getElementById("<%=ddlVehicleNumber.ClientID%>").style.borderColor = "Red";
                       $noCon("div#divVehicleNumber input.ui-autocomplete-input").css("borderColor", "Red");
                       $noCon("div#divVehicleNumber input.ui-autocomplete-input").focus();
                       $noCon("div#divVehicleNumber input.ui-autocomplete-input").select();
                       document.getElementById("<%=ddlVehicleNumber.ClientID%>").focus();

                       return false;
                   }
                   else {
                       return true;

                   }


               }

               function getPreviousDDLVehicleNumber_SelectedVal() {
                   var DropdownList = document.getElementById('<%=ddlVehicleNumber.ClientID %>');
            var SelectedValue = DropdownList.value;
            document.getElementById("<%=hiddenPreviousVehicleNumber.ClientID%>").value = SelectedValue;

        }

        //this function is to RE-NUMBER table when deletion .as it show duplicate sl num when deleted othre than last row
        function ReNumberTable() {
            //if (idlast != "") {
            //    var res = idlast.split("_");

            //    document.getElementById("tdInx" + res[1]).innerHTML = " ";
            //    document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
            //}
            var table = "";


            table = document.getElementById("TableaddedRows");

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


        




        function BlurTVStldDate(obj, x) {

            document.getElementById('divBlink').style.visibility = "hidden";

            var DateWithoutReplace = document.getElementById(obj + x).value;

            var replaceText1 = DateWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");
            document.getElementById(obj + x).value = replaceText5.trim();

            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;

            if (SavedorNot == "saved") {

                if (IsVehicleSelected() == true) {
                    //if not null and zero
                    if (DateCheck(obj, x, true) == true) {
                        document.getElementById('divErrorNotification').style.visibility = "hidden";
                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
                        document.getElementById(obj + x).style.borderColor = "";
                        // Update to local storage
                        LocalStorageEdit(x, row_index);

                    }

                    else {

                        var hiddenRcptDateFocus = document.getElementById("<%=hiddenValueFocus.ClientID%>").value;
                        if (hiddenRcptDateFocus != "") {
                            document.getElementById(obj + x).value = hiddenRcptDateFocus;


                        }

                    }
                }
                else {

                    var hiddenDateFocus = document.getElementById("<%=hiddenValueFocus.ClientID%>").value;
                    if (hiddenDateFocus != "") {
                        document.getElementById(obj + x).value = hiddenDateFocus;


                    }
                }
            }
            else {
              
                if (IsVehicleSelected() == true) {
                    var TVDate = document.getElementById("txtSettledDate" + x).value;
                   
                    var hiddenDateFocus = document.getElementById("<%=hiddenValueFocus.ClientID%>").value;
                    if (TVDate != hiddenDateFocus) {
                       
                        if (CheckSettledAmntFieldAndHighlight(x) == true) {



                            //  alert(obj);

                            if (DateCheck(obj, x, true) == true) {
                                document.getElementById('divErrorNotification').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                                document.getElementById(obj + x).style.borderColor = "";


                                //for saving



                                if (CheckAllRowField(x, row_index) == false) {

                                    return false;

                                }


                                if (SavedorNot == " ") {
                                    //alert('add local');
                                    //  id tdSAVE is made'saved ' in localStorageAdd
                                    //add to local storage
                                   LocalStorageAdd(x);

                                }

                            }
                            else {
                                document.getElementById(obj + x).value = "";
                                // ValueCheck(obj, x, false);

                            }


                        }

                        else {

                            document.getElementById(obj + x).value = "";

                        }
                    }


                }
                else {

                    document.getElementById(obj + x).value = "";
                }
            }
        }

        function BlurTVVioltnDate(obj, x) {

            document.getElementById('divBlink').style.visibility = "hidden";

            var DateWithoutReplace = document.getElementById(obj + x).value;

            var replaceText1 = DateWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");
            document.getElementById(obj + x).value = replaceText5.trim();

            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;

            if (SavedorNot == "saved") {

                if (IsVehicleSelected() == true) {
                    //if not null and zero
                    if (DateCheck(obj, x, true) == true) {
                        document.getElementById('divErrorNotification').style.visibility = "hidden";
                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
                        document.getElementById(obj + x).style.borderColor = "";
                        // Update to local storage
                        LocalStorageEdit(x, row_index);

                    }

                    else {

                        var hiddenRcptDateFocus = document.getElementById("<%=hiddenValueFocus.ClientID%>").value;
                        if (hiddenRcptDateFocus != "") {
                            document.getElementById(obj + x).value = hiddenRcptDateFocus;


                        }

                    }
                }
                else {

                    var hiddenDateFocus = document.getElementById("<%=hiddenValueFocus.ClientID%>").value;
                    if (hiddenDateFocus != "") {
                        document.getElementById(obj + x).value = hiddenDateFocus;


                    }
                }
            }
            else {

                if (IsVehicleSelected() == true) {
                    var TVDate = document.getElementById("txtDate" + x).value;
                    if (TVDate == "") {
                        document.getElementById("txtselectorEmp" + x).value="--Select Employee--";
                        document.getElementById("txtselectorEmpId" + x).value="--Select Employee--";
                        document.getElementById("txtselectorEmployee" + x).value = "--Select Employee--";
                    }

                    var hiddenDateFocus = document.getElementById("<%=hiddenValueFocus.ClientID%>").value;
                    if (TVDate != hiddenDateFocus) {

                        if (CheckSettledAmntFieldAndHighlight(x) == true) {



                            //  alert(obj);

                            if (DateCheck(obj, x, true) == true) {
                                document.getElementById('divErrorNotification').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                                document.getElementById(obj + x).style.borderColor = "";


                                //for saving



                                if (CheckAllRowField(x, row_index) == false) {

                                    return false;

                                }


                                if (SavedorNot == " ") {
                                    //alert('add local');
                                    //  id tdSAVE is made'saved ' in localStorageAdd
                                    //add to local storage
                                    LocalStorageAdd(x);

                                }

                            }
                            else {
                                document.getElementById(obj + x).value = "";
                                // ValueCheck(obj, x, false);

                            }


                        }

                        else {

                            document.getElementById(obj + x).value = "";

                        }
                    }


                }
                else {

                    document.getElementById(obj + x).value = "";
                }
            }
        }








        function BlurTVEmp(x) {
            if (document.getElementById("txtselectorEmpId" + x).value == "" || document.getElementById("txtselectorEmpId" + x).value == "--Select Employee--") {

                document.getElementById("txtselectorEmp" + x).value = "--Select Employee--";
            }

            var TxtName = document.getElementById("txtselectorEmp" + x).value.trim();

            if (TxtName == "" || TxtName == "--Select Employee--") {
                document.getElementById("txtselectorEmpId" + x).value = "--Select Employee--";
                document.getElementById("txtselectorEmployee" + x).value = "--Select Employee--";
                document.getElementById("txtselectorEmp" + x).value = "--Select Employee--";
            }

            var Employee = document.getElementById("txtselectorEmployee" + x).value.trim();
            if (Employee != "" || Employee != "--Select Employee--") {
                document.getElementById("txtselectorEmp" + x).value = Employee;
            }

            //////////////////////////////
            document.getElementById('divBlink').style.visibility = "hidden";
            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (SavedorNot == "saved") {
                if (IsVehicleSelected() == true) {
                    var TVEmpId = document.getElementById("txtselectorEmpId" + x).value;

                    var hiddenEmpIdFocus = document.getElementById("<%=hiddenTVEmpIdFocus.ClientID%>").value;
                    if (TVEmpId != hiddenEmpIdFocus) {

                        if (TVEmpId != "--Select Employee--") {
                        document.getElementById("txtselectorEmp" + x).style.borderColor = "";

                        //Update to local storage

                        document.getElementById('divErrorNotification').style.visibility = "hidden";
                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                        LocalStorageEdit(x, row_index);


                    }

                    else {
                        var hiddenHeadValId = document.getElementById("<%=hiddenTVEmpIdFocus.ClientID%>").value;
                        var hiddenHeadValText = document.getElementById("<%=hiddenTVEmpNameFocus.ClientID%>").value;
                        if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                            document.getElementById("txtselectorEmp" + x).value = hiddenHeadValText;
                            document.getElementById("txtselectorEmpId" + x).value = hiddenHeadValId;
                            document.getElementById("txtselectorEmployee" + x).value = hiddenHeadValText;

                        }
                    }
                }

            }
            else {
                var hiddenHeadValId = document.getElementById("<%=hiddenTVEmpIdFocus.ClientID%>").value;
                    var hiddenHeadValText = document.getElementById("<%=hiddenTVEmpNameFocus.ClientID%>").value;
                    if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                        document.getElementById("txtselectorEmp" + x).value = hiddenHeadValText;
                        document.getElementById("txtselectorEmpId" + x).value = hiddenHeadValId;
                        document.getElementById("txtselectorEmployee" + x).value = hiddenHeadValText;

                    }
                }

            }

            else {

                var TVEmpId = document.getElementById("txtselectorEmpId" + x).value;
                var hiddenEmpIdFocus = document.getElementById("<%=hiddenTVEmpIdFocus.ClientID%>").value;
                if (IsVehicleSelected() == true) {
                    if (TVEmpId != hiddenEmpIdFocus) {
                        if (TVEmpId != "--Select Employee--") {
                            // alert(WBVhclId);


                            document.getElementById('divErrorNotification').style.visibility = "hidden";
                            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                            document.getElementById("txtselectorEmp" + x).style.borderColor = "";


                            //for saving


                            if (CheckAllRowField(x, row_index) == false) {

                                return false;

                            }

                            if (SavedorNot == " ") {
                                //  id tdSAVE is made'saved ' in localStorageAdd
                                //add to local storage
                                LocalStorageAdd(x);

                            }


                        }

                    }
                }
                else {
                    var hiddenHeadValId = document.getElementById("<%=hiddenTVEmpIdFocus.ClientID%>").value;
                    var hiddenHeadValText = document.getElementById("<%=hiddenTVEmpNameFocus.ClientID%>").value;
                    if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                        document.getElementById("txtselectorEmp" + x).value = hiddenHeadValText;
                        document.getElementById("txtselectorEmpId" + x).value = hiddenHeadValId;
                        document.getElementById("txtselectorEmployee" + x).value = hiddenHeadValText;

                    }
                }
            }
        }
        function BlurTVVioltn(x) {
            if (document.getElementById("txtselectorVioltnId" + x).value == "" || document.getElementById("txtselectorVioltnId" + x).value == "--Select Violation--") {

                document.getElementById("txtVioltn" + x).value = "--Select Violation--";
            }

            var TxtName = document.getElementById("txtVioltn" + x).value.trim();

            if (TxtName == "" || TxtName == "--Select Violation--") {
                document.getElementById("txtselectorVioltnId" + x).value = "--Select Violation--";
                document.getElementById("txtselectorVioltn" + x).value = "--Select Violation--";
                document.getElementById("txtVioltn" + x).value = "--Select Violation--";
            }

            var Violtn = document.getElementById("txtselectorVioltn" + x).value.trim();
            if (Violtn != "" || Violtn != "--Select Violation--") {
                document.getElementById("txtVioltn" + x).value = Violtn;
            }

            //////////////////////////////
            document.getElementById('divBlink').style.visibility = "hidden";
            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (SavedorNot == "saved") {
                if (IsVehicleSelected() == true) {
                    var TVVioltnId = document.getElementById("txtselectorVioltnId" + x).value;

                    var hiddenVioltnIdFocus = document.getElementById("<%=hiddenTVVioltnIdFocus.ClientID%>").value;
                    if (TVVioltnId != hiddenVioltnIdFocus) {

                        if (TVVioltnId != "--Select Violation--") {
                            document.getElementById("txtVioltn" + x).style.borderColor = "";

                            //Update to local storage

                            document.getElementById('divErrorNotification').style.visibility = "hidden";
                            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                        LocalStorageEdit(x, row_index);


                    }

                    else {
                        var hiddenHeadValId = document.getElementById("<%=hiddenTVVioltnIdFocus.ClientID%>").value;
                            var hiddenHeadValText = document.getElementById("<%=hiddenTVVioltnFocus.ClientID%>").value;
                            if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                                document.getElementById("txtVioltn" + x).value = hiddenHeadValText;
                                document.getElementById("txtselectorVioltnId" + x).value = hiddenHeadValId;
                                document.getElementById("txtselectorVioltn" + x).value = hiddenHeadValText;

                            }
                        }
                    }

                }
                else {
                    var hiddenHeadValId = document.getElementById("<%=hiddenTVVioltnIdFocus.ClientID%>").value;
                    var hiddenHeadValText = document.getElementById("<%=hiddenTVVioltnFocus.ClientID%>").value;
                    if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                        document.getElementById("txtVioltn" + x).value = hiddenHeadValText;
                        document.getElementById("txtselectorVioltnId" + x).value = hiddenHeadValId;
                        document.getElementById("txtselectorVioltn" + x).value = hiddenHeadValText;

                    }
                }

            }

            else {

                var TVVioltnId = document.getElementById("txtselectorVioltnId" + x).value;
                var hiddenVioltnIdFocus = document.getElementById("<%=hiddenTVVioltnIdFocus.ClientID%>").value;
                if (IsVehicleSelected() == true) {
                    if (TVVioltnId != hiddenVioltnIdFocus) {
                        if (TVVioltnId != "--Select Violation--") {
                            // alert(WBVhclId);


                            document.getElementById('divErrorNotification').style.visibility = "hidden";
                            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                            document.getElementById("txtVioltn" + x).style.borderColor = "";


                            //for saving


                            if (CheckAllRowField(x, row_index) == false) {

                                return false;

                            }

                            if (SavedorNot == " ") {
                                //  id tdSAVE is made'saved ' in localStorageAdd
                                //add to local storage
                                LocalStorageAdd(x);

                            }


                        }

                    }
                }
                else {
                    var hiddenHeadValId = document.getElementById("<%=hiddenTVVioltnIdFocus.ClientID%>").value;
                    var hiddenHeadValText = document.getElementById("<%=hiddenTVVioltnFocus.ClientID%>").value;
                    if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                        document.getElementById("txtVioltn" + x).value = hiddenHeadValText;
                        document.getElementById("txtselectorVioltnId" + x).value = hiddenHeadValId;
                        document.getElementById("txtselectorVioltn" + x).value = hiddenHeadValText;

                    }
                }
            }
        }


        function FocusTVEmp(x, event) {

            
            //for viewing over label
            var offset = $noCon("#txtselectorEmp" + x).offset();
     
           
            var posY = 0;
            var posX = 0;
           
            posY = offset.top - 12.8;
           
            posX = offset.left - 680;
           
            posX = 15.5;
            //document.getElementById("divBlink").innerHTML = "Employee"
            var d = document.getElementById('divBlink');
            d.style.position = "absolute";
            d.style.left = posX + '%';
            d.style.top = posY + 'px';
            document.getElementById('divBlink').style.visibility = "visible";
            

            //   var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            //   if (SavedorNot == "saved") {
           
            document.getElementById("<%=hiddenTVEmpIdFocus.ClientID%>").value = "";
            document.getElementById("<%=hiddenTVEmpNameFocus.ClientID%>").value = "";
            var TVEmpId = document.getElementById("txtselectorEmpId" + x).value;
            document.getElementById("<%=hiddenTVEmpIdFocus.ClientID%>").value = TVEmpId;
            var TVEmpName = document.getElementById("txtselectorEmployee" + x).value;
            document.getElementById("<%=hiddenTVEmpNameFocus.ClientID%>").value = TVEmpName;
  
            if (document.getElementById("txtselectorEmp" + x).value == "--Select Employee--") {
               
                document.getElementById("txtselectorEmp" + x).value = "";
                }
            
            //  }
        }
        function FocusTVVioltn(x, event) {


            //for viewing over label
            var offset = $noCon("#txtVioltn" + x).offset();


            var posY = 0;
            var posX = 0;

            posY = offset.top - 12.8;

            posX = offset.left - 680;

            posX = 39;
           // document.getElementById("divBlink").innerHTML = "Violation"
            var d = document.getElementById('divBlink');
            d.style.position = "absolute";
            d.style.left = posX + '%';
            d.style.top = posY + 'px';
            document.getElementById('divBlink').style.visibility = "visible";


            //   var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            //   if (SavedorNot == "saved") {

            document.getElementById("<%=hiddenTVVioltnIdFocus.ClientID%>").value = "";
            document.getElementById("<%=hiddenTVVioltnFocus.ClientID%>").value = "";
            var TVEmpId = document.getElementById("txtselectorVioltnId" + x).value;
            document.getElementById("<%=hiddenTVVioltnIdFocus.ClientID%>").value = TVEmpId;
            var TVEmpName = document.getElementById("txtselectorVioltn" + x).value;
            document.getElementById("<%=hiddenTVVioltnFocus.ClientID%>").value = TVEmpName;

            if (document.getElementById("txtVioltn" + x).value == "--Select Violation--") {

                document.getElementById("txtVioltn" + x).value = "";
            }

            //  }
        }
        function ClickCbx(obj, x) {
           
            var StldAmnt = document.getElementById("txtAmnt" + x).value;
            if ((document.getElementById(obj + x).checked) == true) {
                document.getElementById("txtSettledAmnt" + x).disabled = false;
                document.getElementById("txtSettledAmnt" + x).value = StldAmnt;
                document.getElementById("txtSettledDate" + x).disabled = false;
            }
            else {
                document.getElementById("txtSettledAmnt" + x).disabled = true;
                document.getElementById("txtSettledAmnt" + x).value = "0.00";
                document.getElementById("txtSettledDate" + x).disabled = true;
                document.getElementById("txtSettledDate" + x).value = "";
            }
           // CalculateTotalAmountFromHiddenField();
           
        }

        function BlurCbx(obj, x) {


            document.getElementById('divBlink').style.visibility = "hidden";
            var StldAmnt = document.getElementById("txtAmnt" + x).value;
            if (document.getElementById(obj + x).checked) {
                
               
                document.getElementById("<%=txtRecptNo.ClientID%>").disabled = false;
                $("div#divStld input.ui-autocomplete-input").attr("disabled", false);
               // document.getElementById("<%=ddlSettledBy.ClientID%>").disabled=false;
                document.getElementById("<%=lblReceiptAmount.ClientID%>").disabled=false;
               
            }
           
               
               
          
           
           
            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;

            if (SavedorNot == "saved") {

                if (IsVehicleSelected() == true) {
                   

                   

                        document.getElementById(obj + x).style.borderColor = "";
                        // Update to local storage

                        LocalStorageEdit(x, row_index);

                    }

                    else {

                        

                        }
                    }
                   
                
                else {


                    if (IsVehicleSelected() == true) {
                        



                        if (CheckAllRowFieldAndHighlight(x, true) == true) {

                            document.getElementById(obj + x).style.borderColor = "";

                            //for saving

                            if (CheckAllRowField(x, row_index) == false) {

                                return false;

                            }


                            if (SavedorNot == " ") {
                                //  id tdSAVE is made'saved ' in localStorageAdd
                                //add to local storage
                                LocalStorageAdd(x);

                            }

                        }
                        else {
                            document.getElementById(obj + x).style.borderColor = "";

                        }


                    } else {
                        document.getElementById(obj + x).style.borderColor = "";
                    }
                }
            }


        function BlurValue(obj, x) {
     
           
                document.getElementById('divBlink').style.visibility = "hidden";

                var AmntVal = (document.getElementById(obj + x).value).split(',').join('');
               

                if (isNaN(AmntVal) == true) {
                    //NaN not a number ,if number return false ,If not a number return true
                    AmntVal = "";
                    //alert('hi');
                }
                if (AmntVal < 0) {
                    //NaN not a number ,if number return false ,If not a number return true
                    AmntVal = "";

                }
              
                document.getElementById(obj + x).value = AmntVal;
                var row_index = jQuery('#rowId_' + x).index();

                var SavedorNot = document.getElementById("tdSave" + x).innerHTML;

                if (SavedorNot == "saved") {

                    if (IsVehicleSelected() == true) {
                        var Amnt = document.getElementById(obj + x).value;

                        //if not null and zero
                        if (ValueCheck(obj, x, true) == true) {

                         
                            document.getElementById(obj + x).style.borderColor = "";
                            // Update to local storage
                            
                            LocalStorageEdit(x, row_index);

                        }

                        else {

                            var hiddenAmntVal = document.getElementById("<%=hiddenValueFocus.ClientID%>").value;
                        if (hiddenAmntVal != "") {
                            document.getElementById(obj + x).value = hiddenAmntVal;
                            ValueCheck(obj, x, false);
                            //Update to local storage
                            //  var row_index = jQuery('#rowId_' + x).index();
                            // LocalStorageEdit(x, row_index);
                        }

                    }
                }
                else {

                    var hiddenAmntVal = document.getElementById("<%=hiddenValueFocus.ClientID%>").value;
                    if (hiddenAmntVal != "") {
                        document.getElementById(obj + x).value = hiddenAmntVal;
                        ValueCheck(obj, x, false);

                    }
                }
            }
                else {
                   

                    if (IsVehicleSelected() == true) {
                        
                    var Amnt = document.getElementById(obj + x).value;
                    
                    ValueCheck(obj, x, false);
                    
                    // alert(obj);
              


                    if (CheckAllRowFieldAndHighlight(x, true) == true) {
                      
                        document.getElementById(obj + x).style.borderColor = "";

                        //for saving

                        if (CheckAllRowField(x, row_index) == false) {
                           
                            return false;
                        

                        }


                        if (SavedorNot == " ") {
                            //  id tdSAVE is made'saved ' in localStorageAdd
                            //add to local storage
                            LocalStorageAdd(x);

                        }

                    }
                    else {
                        //alert('hi' + Amnt);
                        //document.getElementById(obj + x).value = 0;
                       // ValueCheck(obj, x, false);

                    }


                } else {
                    document.getElementById(obj + x).value = 0;
                    ValueCheck(obj, x, false);

                }
            }
        }
        function BlurVioltn(x) {
            

            //////////////////////////////
            document.getElementById('divBlink').style.visibility = "hidden";

            //for replacing ',",\,<,>
            // replacing < and > tags and backslash and single and double quotes
            var VioltnWithoutReplace = document.getElementById("txtVioltn" + x).value;

            var replaceText1 = VioltnWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");
            document.getElementById("txtVioltn" + x).value = replaceText5.trim();
            

            var row_index = jQuery('#rowId_' + x).index();
            
            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
           
            if (SavedorNot == "saved") {
               
                if (IsVehicleSelected() == true) {
                    var Violtn = document.getElementById("txtVioltn" + x).value.trim();

                    var hiddenVioltnFocus = document.getElementById("<%=hiddenValueFocus.ClientID%>").value.trim();
                    if (Violtn != hiddenVioltnFocus) {

                        if (Violtn != "") {
                            document.getElementById("txtVioltn" + x).style.borderColor = "";
                            //  $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "");
                            //Update to local storage

                            if (DuplicationCheck(x, row_index) == true) {


                                document.getElementById('divErrorNotification').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
                                //   if (RecptToCheck() == true) {
                                LocalStorageEdit(x, row_index);
                                //  }
                            }
                            else {

                                var hiddenVioltn = document.getElementById("<%=hiddenValueFocus.ClientID%>").value.trim();

                                if (hiddenVioltn != "") {

                                    document.getElementById("txtVioltn" + x).value = hiddenRcptNumber;


                                }


                            }
                        }
                        else {
                            var hiddenVioltn = document.getElementById("<%=hiddenValueFocus.ClientID%>").value.trim();

                            if (hiddenVioltn != "") {

                                document.getElementById("txtVioltn" + x).value = hiddenVioltn;


                            }
                        }
                    }
                }
                else {
                    var hiddenVioltn = document.getElementById("<%=hiddenValueFocus.ClientID%>").value.trim();

                    if (hiddenVioltn != "") {

                        document.getElementById("txtVioltn" + x).value = hiddenVioltn;


                    }
                }
            }
       
            else {
                
                //   if (RecptToCheck() == true) {
                if (IsVehicleSelected() == true) {
                   
                    var Violtn = document.getElementById("txtVioltn" + x).value.trim();
                    var hiddenVioltn = document.getElementById("<%=hiddenValueFocus.ClientID%>").value.trim();
                    if (Violtn != hiddenVioltn) {
                        if (Violtn != "") {
                          
                            // alert(QtnItemId);

                            //check duplication
                                 
                                document.getElementById('divErrorNotification').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                                document.getElementById("txtVioltn" + x).style.borderColor = "";
                            
                                if (document.getElementById("<%=hiddenDefaultEmpId.ClientID%>").value != "" && document.getElementById("<%=hiddenDefaultEmployee.ClientID%>").value != "" && document.getElementById("<%=hiddenDefaultEmployee.ClientID%>").value != null && document.getElementById("<%=hiddenDefaultEmpId.ClientID%>").value != null) {
                                    if (document.getElementById("txtselectorVioltnId" + x).value == "--Select Violation--" && document.getElementById("txtVioltn" + x).value == "--Select Violation--" && document.getElementById("txtselectorViolation" + x).value == "--Select Violation--") {
                                        document.getElementById("txtselectorVioltnId" + x).value = document.getElementById("<%=hiddenDefaultEmpId.ClientID%>").value;
                                        document.getElementById("txtselectorViolation" + x).value = document.getElementById("<%=hiddenDefaultEmployee.ClientID%>").value;
                                        document.getElementById("txtVioltn" + x).value = document.getElementById("<%=hiddenDefaultEmployee.ClientID%>").value;
                                        // alert(document.getElementById("<%=hiddenDefaultEmpId.ClientID%>").value);
                                    }
                                }


                                if (CheckAllRowField(x, row_index) == false) {
                                    return false;
                                }

                                if (SavedorNot == " ") {
                                    //  id tdSAVE is made'saved ' in localStorageAdd
                                    //add to local storage
                                    LocalStorageAdd(x);
                                }

                       
                            else {

                                document.getElementById("txtVioltn" + x).value = "";

                                document.getElementById("txtVioltn" + x).style.borderColor = "Red";


                            }


                        }
                        else {



                        }
                    }
                }
                else {

                    document.getElementById("txtVioltn" + x).value = "";
                }
            }
        }

        function FocusValue(obj, x) {


            //alert('fstart ' + obj);
            //for viewing over label
            var offset = $noCon("#" + obj + x).offset();

            var posY = 0;
            var posX = 0;
            posY = offset.top - 12.5;

            //  posX = 27.5;
            if (obj == "txtAmnt") {

                posX = 61.8;

              //  document.getElementById("divBlink").innerHTML = " Violation Amount";
            }
            else if (obj == "txtDate") {

                posX = 7;

                //document.getElementById("divBlink").innerHTML = "Violation Date";
            }
            
            else if (obj == "txtSettledAmnt") {
                //alert('txtRcptNumber ' );
                posX = 75;

               // document.getElementById("divBlink").innerHTML = "Settled Amount";
            }
            else if (obj == "txtSettledDate") {
                //alert('txtRcptNumber ' );
                posX = 83.7;

              //  document.getElementById("divBlink").innerHTML = "Settled Date";
            }
            else if (obj == "cbxSettled") {
                //alert('txtRcptNumber ' );
                posX = 71;
                posY = offset.top - 14.5;
               // document.getElementById("divBlink").innerHTML = "Settled";
            }

            var d = document.getElementById('divBlink');
            d.style.position = "absolute";
            d.style.left = posX + '%';
            d.style.top = posY + 'px';
            document.getElementById('divBlink').style.visibility = "visible";

            document.getElementById("<%=hiddenValueFocus.ClientID%>").value = "";
                var Val = document.getElementById(obj + x).value;
                document.getElementById("<%=hiddenValueFocus.ClientID%>").value = Val;
                //    alert('fstop' + obj);
           }




           function LocalStorageAdd(x) {
               //alert('add local');
               var tbClientTrficVltn = localStorage.getItem("tbClientTrficVltn");//Retrieve the stored data

               tbClientTrficVltn = JSON.parse(tbClientTrficVltn); //Converts string to object

               if (tbClientTrficVltn == null) //If there is no data, initialize an empty array
                   tbClientTrficVltn = [];
               var detailId = document.getElementById("tdDtlId" + x).innerHTML;
               //  var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
               var evt = document.getElementById("tdEvt" + x).innerHTML;
               var cbxSettld=0;
               if (document.getElementById("cbxSettled" + x).checked) {
                   cbxSettld = 1;
               }
               else {
                   cbxSettld = 0;
               }
              

               if (evt == 'INS') {
                  // alert('inside local add');
                   var $add = jQuery.noConflict();
                   var client = JSON.stringify({
                       ROWID: "" + x + "",
                       VLTNDATE: $add("#txtDate" + x).val(),
                       EMPID: $add("#txtselectorEmpId" + x).val(),
                       EMPNAME: $add("#txtselectorEmployee" + x).val(),
                       VLTN: $add("#txtselectorVioltnId" + x).val(),
                       VLTNAMNT: $add("#txtAmnt" + x).val(),
                       STLD: "" + cbxSettld + "",
                       STLDAMNT: $add("#txtSettledAmnt" + x).val(),
                       STLDDATE: $add("#txtSettledDate" + x).val(),
                       EVTACTION: "" + evt + "",
                       DTLID: "0"

                   });
               }
               else if (evt == 'UPD') {
                   var $add = jQuery.noConflict();
                   var client = JSON.stringify({
                       ROWID: "" + x + "",
                       VLTNDATE: $add("#txtDate" + x).val(),
                       EMPID: $add("#txtselectorEmpId" + x).val(),
                       EMPNAME: $add("#txtselectorEmployee" + x).val(),
                       VLTN: $add("#txtselectorVioltnId" + x).val(),
                       VLTNAMNT: $add("#txtAmnt" + x).val(),
                       STLD: "" + cbxSettld + "",
                       STLDAMNT: $add("#txtSettledAmnt" + x).val(),
                       STLDDATE: $add("#txtSettledDate" + x).val(),
                       EVTACTION: "" + evt + "",
                       DTLID: "" + detailId + ""


                   });
               }




               tbClientTrficVltn.push(client);
               localStorage.setItem("tbClientTrficVltn", JSON.stringify(tbClientTrficVltn));

               $add("#cphMain_HiddenField1").val(JSON.stringify(tbClientTrficVltn));


               //for calculation of total Amount
               CalculateTotalAmountFromHiddenField();



         // alert("The data was saved.");
          // var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
         //  alert(h);

    document.getElementById("tdSave" + x).innerHTML = "saved";
    //   alert('saved');
    CheckaddMoreRows(x, true);
    IncrmntConfrmCounter();
   
    return true;

}
function LocalStorageDelete(row_index, x) {

    var tbClientTrficVltn = localStorage.getItem("tbClientTrficVltn");//Retrieve the stored data

    tbClientTrficVltn = JSON.parse(tbClientTrficVltn); //Converts string to object

    if (tbClientTrficVltn == null) //If there is no data, initialize an empty array
        tbClientTrficVltn = [];



    // Using splice() we can specify the index to begin removing items, and the number of items to remove.
    tbClientTrficVltn.splice(row_index, 1);
    localStorage.setItem("tbClientTrficVltn", JSON.stringify(tbClientTrficVltn));
    $noCon("#cphMain_HiddenField1").val(JSON.stringify(tbClientTrficVltn));
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
   CalculateTotalAmountFromHiddenField();
    IncrmntConfrmCounter();
            // alert('gj');

}

        function LocalStorageEdit(x, row_index) {

    var tbClientTrficVltn = localStorage.getItem("tbClientTrficVltn");//Retrieve the stored data

    tbClientTrficVltn = JSON.parse(tbClientTrficVltn); //Converts string to object

    if (tbClientTrficVltn == null) //If there is no data, initialize an empty array
        tbClientTrficVltn = [];
    var detailId = document.getElementById("tdDtlId" + x).innerHTML;
    // var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
    var evt = document.getElementById("tdEvt" + x).innerHTML;
    //alert('event'+evt);
    // alert('edit pmode ' + PrdctMode);
    //  alert('additional:' + additional)
    //alert('detailID'+detailId);
    var cbxSettld = 0;
    if (document.getElementById("cbxSettled" + x).checked) {
        cbxSettld = 1;
    }
    else {
        cbxSettld = 0;
    }
    
    if (evt == 'INS') {
      
        var $E = jQuery.noConflict();
        tbClientTrficVltn[row_index] = JSON.stringify({

           
            ROWID: "" + x + "",
            VLTNDATE: $E("#txtDate" + x).val(),
            EMPID: $E("#txtselectorEmpId" + x).val(),
            EMPNAME: $E("#txtselectorEmployee" + x).val(),
            VLTN: $E("#txtselectorVioltnId" + x).val(),
            VLTNAMNT: $E("#txtAmnt" + x).val(),
            STLD: "" + cbxSettld + "",
            STLDAMNT: $E("#txtSettledAmnt" + x).val(),
            STLDDATE: $E("#txtSettledDate" + x).val(),
            EVTACTION: "" + evt + "",
            DTLID: "0"

        });//Alter the selected item on the table
    }
    else {
       
        var $E = jQuery.noConflict();
        tbClientTrficVltn[row_index] = JSON.stringify({
            ROWID: "" + x + "",
            VLTNDATE: $E("#txtDate" + x).val(),
            EMPID: $E("#txtselectorEmpId" + x).val(),
            EMPNAME: $E("#txtselectorEmployee" + x).val(),
            VLTN: $E("#txtselectorVioltnId" + x).val(),
            VLTNAMNT: $E("#txtAmnt" + x).val(),
            STLD: "" + cbxSettld + "",
            STLDAMNT: $E("#txtSettledAmnt" + x).val(),
            STLDDATE: $E("#txtSettledDate" + x).val(),
            EVTACTION: "" + evt + "",
            DTLID: "" + detailId + ""

        });//Alter the selected item on the table

    }
   // alert('local edit');
    



    localStorage.setItem("tbClientTrficVltn", JSON.stringify(tbClientTrficVltn));
    $E("#cphMain_HiddenField1").val(JSON.stringify(tbClientTrficVltn));


    //for calculation of total Amount
    CalculateTotalAmountFromHiddenField();




    //  alert("The data was edited.");
    //  operation = "A"; //Return to default value
     //var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
    //alert(h);
    //CheckaddMoreRows(x, true);
    //alert('cal stop');
    //  IncrmntConfrmCounter();
    // alert('gj');
    return true;
}
    </script>

    <script>
        var $noCon = jQuery.noConflict();
        function DuplicationCheck(x, row_Index) {

            var RcptNumberObj = document.getElementById("txtRecptNo" + x);

           
        }
        function CalculateTotalAmountFromHiddenField() {
            
            var Total = 0;
            //  var resultJSON = '{"FirstName":"John","LastName":"Doe","Email":"johndoe@johndoe.com","Phone":"123 dead drive"}","{"FirstName":"Johni","LastName":"Doioe","Email":"johndoe@johndoe.com","Phone":"123 dead drive"}';
            var hiddenVal = document.getElementById("<%=HiddenField1.ClientID%>").value;
            //alert(hiddenVal);
            //    alert('hical');
            //  alert(hiddenVal);
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

                     var resultJSON = "";
                     if (i == 0) {
                         resultJSON = jdatas[i];

                     }
                     else {

                         resultJSON = "{" + jdatas[i];

                     }

                     var result = $noCon.parseJSON(resultJSON);
                     $noCon.each(result, function (k, v) {

                         if (k == "STLDAMNT") {
                             //alert(parseFloat(v));
                          
                             v = v.split(',').join('');
                             Total = Total + parseFloat(v);

                         }
                     });
                 }

             }
           
             var num = Total;
             var n = Total;
            // for floatting number adjustment from corp global
             var FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
            if (FloatingValue != "") {
                n = num.toFixed(FloatingValue);
            }
            
        
            document.getElementById("<%=lblReceiptAmount.ClientID%>").innerHTML = addCommas(n);

            document.getElementById("<%=hiddenNetAmount.ClientID%>").value = n;
           
        }
     

        
        function CheckaddMoreRows(x, retBool) {
           
           
            var check = document.getElementById("tdInx" + x).innerHTML;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (check == " ") {
              
                if (retBool == true) {
                   
                    if (CheckAllRowFieldAndHighlight(x, false) == true) {
                       // alert('check');
                        document.getElementById("tdInx" + x).innerHTML = x;
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";

                       
                       



                        addMoreRows(this.form, retBool, false, 0);

                        return false;
                    }
                }
                else if (retBool == false) {
                   
                    var row_index = jQuery('#rowId_' + x).index();
                    if (CheckAllRowField(x, row_index) == true) {
                        document.getElementById("tdInx" + x).innerHTML = x;
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";

                       

                       

                        addMoreRows(this.form, retBool, false, 0);


                        return false;
                    }
                }
            }
            return false;
        }


        // checks every field in row
        function CheckAllRowField(x, row_index) {
            ret = true;

          // alert('check all row');

            var VioltnDate = document.getElementById("txtDate" + x).value;
            if (VioltnDate == "") {
                ret = false;
            }
            var TVEmpId = document.getElementById("txtselectorEmpId" + x).value;
            if (TVEmpId == "--Select Employee--" || TVEmpId == "") {
                ret = false;

            }
            var Violtn = document.getElementById("txtVioltn" + x).value;
            if (Violtn == "--Select Violation--" || Violtn=="") {
                ret = false;
            }
            if (ValueCheck('txtAmnt', x, true) == false) {
                ret = false;
            }
            if (document.getElementById("cbxSettled" + x).checked) {

                if (ValueCheck('txtSettledAmnt', x, true) == false) {


                    return false;
                }
                var StldDate = document.getElementById("txtSettledDate" + x).value;
                if (StldDate == "") {

                    return false;
                }


            }
            
           


            return ret;
        }

        // checks every field in row
        function CheckSettledAmntFieldAndHighlight(x) {
        // alert('check settled amnt');
            ret = true;
            var SettledAmnt = document.getElementById("txtSettledAmnt" + x).value;
            if (SettledAmnt == "") {
                document.getElementById("txtSettledAmnt" + x).style.borderColor = "Red";
                document.getElementById("txtSettledAmnt" + x).focus();
                $noCon("#txtSettledAmnt" + x).select();
                return false;
            }


            return true;
        }
        // checks every field in row
        function CheckAllRowFieldAndHighlight(x, blFromBlurValue) {
            ret = true;
           
            var VioltnDate = document.getElementById("txtDate" + x).value;
            if (VioltnDate == "") {
                document.getElementById("txtDate" + x).style.borderColor = "Red";
                document.getElementById("txtDate" + x).focus();
                $noCon("#txtDate" + x).select();
                return false;
            }
            var TVEmpId = document.getElementById("txtselectorEmpId" + x).value;
            if (TVEmpId == "--Select Employee--" || TVEmpId == "") {
                document.getElementById("txtselectorEmp" + x).style.borderColor = "Red";
                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                document.getElementById("txtselectorEmp" + x).focus();
                $noCon("#txtselectorEmp" + x).select();
                return false;

            }
            var Violtn = document.getElementById("txtVioltn" + x).value;
            if (Violtn == "--Select Violation--") {
                document.getElementById("txtVioltn" + x).style.borderColor = "Red";
                document.getElementById("txtVioltn" + x).focus();
                $noCon("#txtVioltn" + x).select();
                return false;
            }
            var VioltnAmnt = document.getElementById("txtAmnt" + x).value;
            if (ValueCheck('txtAmnt', x, true) == false) {

                document.getElementById("txtAmnt" + x).style.borderColor = "Red";
                document.getElementById("txtAmnt" + x).focus();
                $noCon("#txtAmnt" + x).select();
                return false;
            }
           

            if (document.getElementById("cbxSettled" + x).checked) {
                var StldAmnt = document.getElementById("txtSettledAmnt" + x).value;
                if (ValueCheck('txtSettledAmnt', x, true) == false) {

                    document.getElementById("txtSettledAmnt" + x).style.borderColor = "Red";
                    document.getElementById("txtSettledAmnt" + x).focus();
                    $noCon("#txtSettledAmnt" + x).select();
                    return false;
                }
                var StldDate = document.getElementById("txtSettledDate" + x).value;
                if (StldDate == "") {
                    document.getElementById("txtSettledDate" + x).style.borderColor = "Red";
                    document.getElementById("txtSettledDate" + x).focus();
                    $noCon("#txtSettledDate" + x).select();
                    return false;
                }


            }
            return true;
           
        }
         
        

         

               
        function CheckReceiptDtlsAndHighlight(x, blFromBlurValue) {
            document.getElementById('ErrorMsgReceiptNo').style.visibility = "hidden";
            document.getElementById("<%=txtRecptNo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlSettledBy.ClientID%>").style.borderColor = "";
            if (document.getElementById("cbxSettled" + x).checked) {
               
                var RcptNumbr = document.getElementById("<%=txtRecptNo.ClientID%>").value;
                if (RcptNumbr == "") {
                    document.getElementById("<%=txtRecptNo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtRecptNo.ClientID%>").focus();
                    $noCon("<%=txtRecptNo.ClientID%>").select();
                    return false;
                }
                

                var SelectedValueStldEmp = document.getElementById("<%=ddlSettledBy.ClientID%>").value;

               
                if (SelectedValueStldEmp == '--Select Employee--') {
                  
                    $noCon("div#divStld input.ui-autocomplete-input").css("borderColor", "Red");
                    $noCon("div#divStld input.ui-autocomplete-input").focus();
                    $noCon("div#divStld input.ui-autocomplete-input").select();
                   // document.getElementById("<%=ddlSettledBy.ClientID%>").style.borderColor = "Red";
                   //document.getElementById("<%=ddlSettledBy.ClientID%>").focus();
                   //$noCon("<%=ddlSettledBy.ClientID%>").select();
                   // alert('hi');
                    return false;

                }
               
            }
            return true;
        }
            function ReOpenConfirm() {
                var ret = true;
                if (CheckIsRepeat() == true) {
                }
                else {
                    ret = false;
                    return ret;
                }
                if (confirm("Are you sure you want to Re-Open ?")) {

                    ret = true;
                }
                else {
                    ret = false;
                }
                if (ret == false) {
                    CheckSubmitZero();

                }
                return ret;
            }
      

            function ValidateAndSave(obj) {
                
                var ret = true;
                if (CheckIsRepeat() == true) {
                }
                else {
                    ret = false;
                    return ret;
                }
                var NameWithoutReplace = document.getElementById("<%=txtRecptNo.ClientID%>").value;
                var replaceText1 = NameWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById("<%=txtRecptNo.ClientID%>").value = replaceText2.trim();
                var StldUsrId = document.getElementById("<%=ddlSettledBy.ClientID%>").value;
              //  alert(StldUsrId);
                document.getElementById("<%=hiddenStldUserId.ClientID%>").value = StldUsrId;
                document.getElementById('divErrorNotification').style.visibility = "hidden";
                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                if (IsVehicleSelected() == true) {
                    
                   
                        
                       
                            var TableRowCount = document.getElementById("TableaddedRows").rows.length;
                            
                             if (TableRowCount != 0) {
                                 if (TableRowCount == 1) {
                                     //if added a row not entered any value validate

                                     var idlast = $noCon('#TableaddedRows tr:last').attr('id');
                                     if (idlast != "") {
                                         var res = idlast.split("_");
                                         var x = res[1];


                                         if (CheckAllRowFieldAndHighlight(x, false) == false) {
                                             ret = false;
                                         }


                                         if (ret == false) {

                                             document.getElementById('divErrorNotification').style.visibility = "visible";
                                             document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                         }
                                         else if (ret == true) {

                                             if (obj == "Confirm") {
                                                 if (confirm("Are you Sure you want to Confirm ?")) {

                                                     var DropdownVehicleNumbr = document.getElementById("<%=ddlVehicleNumber.ClientID%>");
                                                     var SelectedValueVehicleNumbr = DropdownVehicleNumbr.value;



                                                     if (SelectedValueVehicleNumbr == '--SELECT VEHICLE NUMBER--') {

                                                         SelectedValueVehicleNumbr = 0;
                                                     }
                                                     if (SelectedValueVehicleNumbr != 0) {
                                                         VehicleSelected(SelectedValueVehicleNumbr);
                                                     }
                                                     else {
                                                         VehicleSelected('0');
                                                     }


                                                 }
                                                 else {
                                                     ret = false;
                                                 }

                                             }


                                         }

                                     }
                                     else {
                                         ret = false;

                                     }
                                     if (ret == false) {
                                         CheckSubmitZero();

                                     }

                                     return ret;
                                 }


                                 else { //ok

                                     var ret = true;
                                     var table = document.getElementById('TableaddedRows');
                                     // alert(table.rows.length);
                                     for (var i = 0; i < table.rows.length; i++) {
                                         if (i != table.rows.length - 1) {
                                             // FIX THIS
                                             var row = table.rows[i];

                                             var xLoop = (table.rows[i].cells[0].innerHTML);
                                             //alert(xLoop);
                                             if (CheckAllRowFieldAndHighlight(xLoop, false) == false) {
                                                 ret = false;
                                             }
                                            
                                             if (CheckReceiptDtlsAndHighlight(xLoop, false) == false) {
                                                 ret = false;
                                             }
                                             if (CheckDupReceiptNo(obj) == false) {

                                                 ret = false;
                                             }

                                         }
                                         else {
                                             //last row


                                             //var xLoop = (table.rows[i].cells[0].innerHTML);
                                             //if (document.getElementById("tdChanged" + xLoop).innerHTML == "Changed") {
                                             //    if (CheckAllRowFieldAndHighlight(xLoop, false) == false) {
                                             //        ret = false;
                                             //    }
                                             //}

                                         }
                                     }

                                     if (ret == true) {
                                         var idlast = $noCon('#TableaddedRows tr:last').attr('id');
                                         //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                                         //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");


                                         if (idlast != "") {
                                             var res = idlast.split("_");
                                             var x = res[1];
                                             //  alert(res[1]);

                                             var VioltnDate = document.getElementById("txtDate" + x).value.trim();
                                             if (VioltnDate != "") {
                                                 if (CheckAllRowFieldAndHighlight(x, false) == false) {
                                                     ret = false;
                                                 }

                                             }


                                             if (ret == false) {
                                                 document.getElementById('divErrorNotification').style.visibility = "visible";
                                                 document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                             }
                                             else if (ret == true) {

                                                 if (obj == "Confirm") {

                                                     if (confirm("Are you sure you want to Confirm ?")) {

                                                         var DropdownVehicleNumbr = document.getElementById("<%=ddlVehicleNumber.ClientID%>");
                                                         var SelectedValueVehicleNumbr = DropdownVehicleNumbr.value;



                                                         if (SelectedValueVehicleNumbr == '--SELECT VEHICLE NUMBER--') {

                                                             SelectedValueVehicleNumbr = 0;
                                                         }
                                                         if (SelectedValueVehicleNumbr != 0) {
                                                             VehicleSelected(SelectedValueVehicleNumbr);
                                                         }
                                                         else {
                                                             VehicleSelected('0');
                                                         }

                                                     }
                                                     else {
                                                         ret = false;
                                                     }

                                                 }


                                             }

                                         }
                                         else {

                                             ret = false;
                                         }

                                     }

                                     else if (ret == false) {
                                         document.getElementById('divErrorNotification').style.visibility = "visible";
                                         document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                     }
                                     if (ret == false) {

                                         CheckSubmitZero();

                                     }
                                     //alert('kooi' + ret);
                                     return ret;
                                    
                                 }

                             }//ok

                             else {
                               
                                 document.getElementById('divErrorNotification').style.visibility = "visible";
                                 document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, Please add atleast one Item to Save!";
                                 CheckSubmitZero();
                                 return false;

                             }

                            //----

                   
                    

                } //ok

                else {
                   
                    document.getElementById('divErrorNotification').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                    CheckSubmitZero();
                    return false;
                }
                
            }
        

    </script>

    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            //alert('load');
            $('#cphMain_ddlVehicleNumber').selectToAutocomplete1Letter();
            $('#cphMain_ddlSettledBy').selectToAutocomplete1Letter();
             

            document.getElementById('divBlink').style.visibility = "hidden";

           
            document.getElementById("<%=HiddenField1.ClientID%>").value = "";
            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";


            localStorage.clear();
           

            var DropdownVehicleNumber = document.getElementById("<%=ddlVehicleNumber.ClientID%>");
            var SelectedValueVehicleNumber = DropdownVehicleNumber.value;
           

           
            if (SelectedValueVehicleNumber == '--SELECT VEHICLE NUMBER--') {

                SelectedValueVehicleNumber = 0;
            }
          
            if (SelectedValueVehicleNumber != 0) {
               
                VehicleSelected(SelectedValueVehicleNumber);
                
            }
            else {
               
                VehicleSelected('0');
                // alert('hi');
            }
          


            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
                var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;
            //alert('viewval'+ViewVal);
            if (EditVal != "") {
               // alert('inside edit');

                // alert('edit  ' + EditVal);

                // var find1 = '\\\\';
                //  var re1 = new RegExp(find1, 'g');
                //  var res1 = EditVal.replace(re1, '');

                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = EditVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
                //   alert('res3' + res3);
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].TransId != "") {

                            //  alert('json[key].AddDesc ' + json[key].AddDesc);
                            EditListRows(json[key].RcptNumbr, json[key].StldUsrID, json[key].VioltnDate, json[key].EmpId, json[key].EmpName, json[key].VioltnId, json[key].Violtn, json[key].VioltnAmnt, json[key].StldSts, json[key].StldAmnt, json[key].StldDate, json[key].RcptAmnt, json[key].TransDtlId);
                            if (json[key].StldSts == 1) {
                                document.getElementById("<%=txtRecptNo.ClientID%>").disabled = false;
                                $("div#divStld input.ui-autocomplete-input").attr("disabled", false);
                            }
                            //  alert(json[key].LdgrHeadId);
                            //  alert(json[key].Amount);
                        }
                    }
                }


            }

            else if (ViewVal != "") {

                //alert('hi');

                document.getElementById("<%=ddlVehicleNumber.ClientID%>").disabled = true;
                document.getElementById("<%=ddlSettledBy.ClientID%>").disabled = true;
                document.getElementById("<%=txtRecptNo.ClientID%>").disabled = true;              
                $("div#divStld input.ui-autocomplete-input").attr("disabled", "disabled");
                $("div#divVehicleNumber input.ui-autocomplete-input").attr("disabled", "disabled");
                //  alert('View  ' + ViewVal);

                //    var find1 = '\\\\';
                //      var re1 = new RegExp(find1, 'g');
                //     var res1 = ViewVal.replace(re1, '');

                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = ViewVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
                //alert(res3);
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].TransId != "") {

                            ViewListRows(json[key].RcptNumbr, json[key].StldUsrID, json[key].VioltnDate, json[key].EmpId, json[key].EmpName, json[key].VioltnId, json[key].Violtn, json[key].VioltnAmnt, json[key].StldSts, json[key].StldAmnt, json[key].StldDate, json[key].RcptAmnt, json[key].TransDtlId);


                            //  alert(json[key].LdgrHeadId);
                            //  alert(json[key].Amount);
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
                //     document.getElementById("<%=lblReceiptAmount.ClientID%>").innerText = n;

                //    document.getElementById('tdFooterTotalAmount').innerText = n;

            }
            //alert('hi');
            if (ViewVal == "") {

      
                addMoreRows(this.form, false, false, 0);



               
                document.getElementById("<%=ddlVehicleNumber.ClientID%>").focus();
                $("div#divVehicleNumber input.ui-autocomplete-input").select();
               
            }


        



        });
    </script>
  <script>
      //ReceiptNo Duplication check 0012
      function CheckDupReceiptNo(obj) {
          //alert('CheckDupReceiptNo');
          ret = false;
          var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;

                var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
          var VioltnId = 0;
          var receiptAmount = 0;
                //obj = 0;
                if (obj != "Save") {
                    VioltnId = document.getElementById("<%=hiddenVioltnId.ClientID%>").value;
                    
                    receiptAmount = document.getElementById("<%=hiddenNetAmount.ClientID%>").value;

                }
                var strReceiptNo = document.getElementById("<%=txtRecptNo.ClientID%>").value;
                

                $cod = jQuery.noConflict();

                $cod.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: '<%=ResolveUrl("WebServiceAutoCompleteTrafficViolation.asmx/CheckDupReceiptNo") %>',
                    //url: "gen_Traffic_Violation_Settlement_Dtl.aspx/CheckReceiptNo",
                    data: '{intOrgId:"' + parseInt(OrgId) + '",intCorpId:"' + parseInt(CorpId) + '",intVioltnId:"' + parseInt(VioltnId) + '",strReceiptNo:"' + strReceiptNo + '",decReceiptAmount:"' + parseFloat(receiptAmount) + '",strStatus:"' + obj + '"}',
                    //data: '{intOrgId:"' + parseInt(OrgId) + '"}',


                    dataType: "json",
                    success: function (data) {

                        if (data.d == "0") {
                            //Valid Receipt No.
                            //alert('Valid');
                            ret= true;

                        }
                       
                        else {
                            //Duplicate
                            //alert('Duplicate');
                            document.getElementById("<%=txtRecptNo.ClientID%>").style.borderColor = "Red";
                            
                            document.getElementById('ErrorMsgReceiptNo').style.visibility = "visible";

                            ret = false;
                        }
                    },
                    error: function (response) {
                        ret= false;
                    }

                });
                return ret;
      }
      function DuplicateReceiptNo() {
          document.getElementById("<%=txtRecptNo.ClientID%>").style.borderColor = "Red";

          document.getElementById('ErrorMsgReceiptNo').style.visibility = "visible";
      }
      function selectorToAutocompleteTextBox(obj, x) {
       
          var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;

          var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
          var VhclId = document.getElementById("<%=ddlVehicleNumber.ClientID%>").value;
         
          var VioltnDate = document.getElementById("txtDate" + x).value;
         
          //alert(VioltnDate);
          //$au('#cphMain_ddlExistingCustomer').selectToAutocomplete1Letter();
          //$au('#cphMain_ddlExistingProject').selectToAutocomplete1Letter();
          //$au('#cphMain_ddlExistingClient').selectToAutocomplete1Letter();
          //$au('#cphMain_ddlExistingContractor').selectToAutocomplete1Letter();
          //$au('#cphMain_ddlExistingConsultant').selectToAutocomplete1Letter();
          if(obj=="txtselectorEmp"+x)
          {
             
          if (CorpId != '' && CorpId != null && (!isNaN(CorpId)) && OrgId != '' && OrgId != null && (!isNaN(OrgId))) {
          
              $("#" + obj).autocomplete({
                  source: function (request, response) {

                      $.ajax({
                          url: '<%=ResolveUrl("WebServiceAutoCompleteTrafficViolation.asmx/GetEmployeeDetails") %>',
                          data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'intOrgId': '" + parseInt(OrgId) + "', 'intCorpId': '" + parseInt(CorpId) + "', 'intVhclId': '" + parseInt(VhclId) + "', 'strVioltnDate': '" + VioltnDate + "'  }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          success: function (data) {
                                
                              response($.map(data.d, function (item) {
                                  return {
                                      label: item.split('<->')[1],
                                      val: item.split('<->')[0]
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
                      document.getElementById("txtselectorEmpId" + x).value = i.item.val;
                      document.getElementById("txtselectorEmployee" + x).value = i.item.label;
                      //  alert(i.item.val);
                      //  alert(i.item.label);
                  },

                  minLength: 1

              });
          }
      }
          if (obj == "txtVioltn" + x) {
             
              if (CorpId != '' && CorpId != null && (!isNaN(CorpId)) && OrgId != '' && OrgId != null && (!isNaN(OrgId))) {
                 
                  $("#" + obj).autocomplete({
                      source: function (request, response) {

                          $.ajax({
                              url: '<%=ResolveUrl("WebServiceAutoCompleteTrafficViolation.asmx/GetViolationDetails") %>',
                              data: "{ 'strLikeViolation': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'intOrgId': '" + parseInt(OrgId) + "', 'intCorpId': '" + parseInt(CorpId) + "'  }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          success: function (data) {
                             
                              response($.map(data.d, function (item) {
                                  return {
                                      label: item.split('<->')[1],
                                      val: item.split('<->')[0],
                                      pnlty: item.split('<->')[2]
                                     
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
                      document.getElementById("txtselectorVioltnId" + x).value = i.item.val;
                      document.getElementById("txtselectorVioltn" + x).value = i.item.label;
                      document.getElementById("txtAmnt" + x).value = addCommas(i.item.pnlty);
                     
                      //  alert(i.item.val);
                      //  alert(i.item.label);
                  },

                  minLength: 1

              });
          }

      }


        }


        function VehicleSelected(VhclId) {
           
            //web method for drop down of narrations for common narration
            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            var VhclId=document.getElementById("<%=ddlVehicleNumber.ClientID%>").value;
            if (CorpId != '' && CorpId != null && OrgId != '' && OrgId != null && VhclId != '' && VhclId != null && VhclId != '--SELECT VEHICLE NUMBER--') {
                
              
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Traffic_Violation.aspx/VehicleDetails",
                    data: '{corporateId: "' + CorpId + '",organisationId:"' + OrgId + '" ,VHCLID:"' + VhclId + '"}',
                    dataType: "json",
                    success: function (data) {
                       
                        if (data.d != '') {

                            
                            document.getElementById("<%=hiddenDefaultEmpId.ClientID%>").value = data.d.strEmpId;
                            document.getElementById("<%=hiddenDefaultEmployee.ClientID%>").value = data.d.strEmployee;
                            


                            // CalculateTotalAmountWhenBlur(x);

                            CalculateTotalAmountFromHiddenField();
                           
                        }
                    },
                    error: function (result) {
                        // alert("Error");
                    }
                });

            }
          
        }


    </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:HiddenField ID="hiddenNetAmount" runat="server" />   
     <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />
     <asp:HiddenField ID="hiddenDefaultEmpId" runat="server" />
     <asp:HiddenField ID="hiddenDefaultEmployee" runat="server" />
    <asp:HiddenField ID="hiddenDefaultVioltnId" runat="server" />
     <asp:HiddenField ID="hiddenDefaultVioltn" runat="server" />
     <asp:HiddenField ID="hiddenCurrentDate" runat="server" />        
    <asp:HiddenField ID="hiddenValueFocus" runat="server" />
    <asp:HiddenField ID="hiddenTVEmpIdFocus" runat="server" />
    <asp:HiddenField ID="hiddenTVEmpNameFocus" runat="server" />
     <asp:HiddenField ID="hiddenTVVioltnIdFocus" runat="server" />
    <asp:HiddenField ID="hiddenTVVioltnFocus" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hiddenStldUserId" runat="server" />
    <asp:HiddenField ID="hiddenFloatingValueMoney" runat="server" />
    <asp:HiddenField ID="hiddenPreviousVehicleNumber" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    
    <asp:HiddenField ID="hiddenVioltnId" runat="server" />

     <asp:HiddenField ID="hiddenAllowRcptNumberDuplication" runat="server" Value="1" /> <%--for duplication allowing--%>
    <asp:Label ID="lblIndex" runat="server" Text="Label" Style="display: none"></asp:Label>

    <div class="cont_rght">


        <%--  --%>

          <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>
      

     
        <br />
        
        <div class="fillform">
              <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="height:26.5px;float:right;">

          <%--   <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;width: 80%;">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <%--EVM-0027--%>
             <div id="div1" style="width: 45%; margin-top: 2.2%;" class="eachform">
                  <h2 style="margin-top: 1%; float: left; padding-right: 7%;">REF #</h2>
                    <asp:Label ID="lblRefNumber" class="form1" runat="server" Style="margin-right: 40%;padding-top:4px; border: none;font-family: calibri;font-size: 15px;font-weight: bold;"></asp:Label>
                  </div>
         
         <%--   //END--%>
               <div id="divVehicleNumber" style="width: 45%; margin-top: 2.2%;" class="eachform">
            <h2 style="margin-top: 1%; float: left; padding-right: 7%;">Vehicle Number *</h2>
            <asp:DropDownList ID="ddlVehicleNumber" class="form1" Style="width: 65.5%; float: left;" runat="server" onblur="return ChangeVehicleNumber();" onfocus="getPreviousDDLVehicleNumber_SelectedVal()" autofocus="autofocus" autocorrect="off" autocomplete="off"></asp:DropDownList>

        </div>
            <div class="leads_form">
                <div id="divErrorNotification" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotification" runat="server"></asp:Label>
                </div>
                <div id="divTables" style="width: 100%; margin: auto; padding-top: 0.6%;">

                    <table id="TableHeaderTrfcVoltn" rules="all" style="width: 95.5%;">

                        <tr>
                            <td style="font-size: 14px; width: 2.8%; padding-left: 0.5%;">Sl#</td>
                            <td style="font-size: 14px; width: 10.4%; padding-left: 0.5%;">Date</td>
                            <td style="font-size: 14px; width: 27%; padding-left: 0.5%;">Employee</td>
                            <td style="font-size: 14px; width: 26.8%; text-align: left; padding-left: 0.5%;">Violation</td>
                            <td style="font-size: 14px; width: 9.5%; text-align: right; padding-right: 1%;">Amount</td>
                            <td style="font-size: 14px; width: 5%; text-align: center; padding-right: 1%;">Settled</td>
                            <td style="font-size: 14px; width: 9.5%; text-align: right; padding-right: 1%;">Settled Amount</td>
                            <td style="font-size: 14px; width: 9.4%; text-align: left; padding-right: 1%;">Settled Date</td>



                            <td id="spanAddRow" style="background: rgb(244, 246, 240) none repeat scroll 0% 0%;">
                                <%--  this not used  now if needed remove display none--%>
                                <img src="../../../Images/imgAddRows.png" style="cursor: pointer; width: 100%; height: 30px; display: none" onclick="CheckaddMoreRows();" />

                            </td>
                        </tr>
                    </table>

                    <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                        <table id="TableaddedRows" style="width: 100%;">
                        </table>

                        


                    </div>
                    <div id="divBlink" style="background-color: rgb(249, 246, 3); font-size: 10.5px; color: black; opacity: 0.6;"></div>

                </div>




            </div>


             <div class="divSettlmntDetls" style="margin-top: 1%;">
                 <div style="margin-top:1%;margin-left:1%;">
                     <h2  >Settlement Details </h2>
                     </div>
                 <div id="divStld" style="margin-top:3%;">
                   <h2 style="float:left;margin-left:3%;margin-top: 0.5%;" >Receipt Number *</h2>
                 <asp:TextBox ID="txtRecptNo" class="form1" MaxLength="50" style="float:left;margin-left:5%;"  runat="server"></asp:TextBox>
                  <h2 style="float:left;margin-left:5%;margin-top: 0.5%;">Settled By *</h2>
                 <asp:DropDownList ID="ddlSettledBy" class="form1" value="--Select Employee--" style="float:left;margin-left:5%;width:15%" runat="server"></asp:DropDownList>
                      <h2 style="float:left;margin-left:5%;">Receipt Amount </h2>
                   <asp:Label ID="lblReceiptAmount" runat="server" style="color: red;font-weight: bold;margin-left: 3%;" >0.00</asp:Label>
                 </div>
                 <div style="margin-top:1%;">
                <p class="error" id="ErrorMsgReceiptNo" style="color: red;margin-left: 18%;visibility: hidden;font-family: Calibri; font-size: small;">Receipt No. can't contain special characters or duplicate value</p>                   

                 </div>
                  
            </div>

            <div class="eachform" style="margin-top: -1.5%;">

                <div class="subform" style="margin-left: 36.8%; width: 55%; margin-top: 2%;">


                    <asp:Button ID="btnSave" runat="server" class="save" Text="Save" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
                        <asp:Button ID="btnSaveClose" runat="server" class="save" Text="Save & Close" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />
                       <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnConfirm" runat="server" class="save" Text="Confirm" OnClientClick="return ValidateAndSave('Confirm');" OnClick="btnConfirm_Click" />
                    <asp:Button ID="btnReOpen" runat="server" class="save" Text="Re-Open" OnClientClick="return ReOpenConfirm();" OnClick="btnReOpen_Click" />
                 <%--  <asp:Button ID="Button1" runat="server" class="save" Text="show" OnClientClick="return ShowHidden();" />--%>
                     <%--<asp:Button ID="btnList" runat="server" class="save" Text="List"   OnClientClick="return ConfirmMessage();" />--%>
                     <asp:Button ID="btnCancel" runat="server" class="save" Text="Cancel" PostBackUrl="gen_Traffic_Violation_List.aspx"  />
                     <asp:Button ID="btnClear" runat="server" class="save"  Text="Clear" OnClientClick="return ConfirmClear();" />
                    <%--<asp:Button ID="btnClose" runat="server" class="save" Text="Close" OnClientClick="return ConfirmMessage();" />--%>
                   <%-- <input type="submit" name="name" value="Save" onclick="return CheckDupReceiptNo('Save');"  />
                    <input type="submit" name="name" value="Update" onclick="return CheckDupReceiptNo('Update');"  />--%>

                </div>

            </div>

             
        </div>
    </div>
    <style>
         .datepicker table tr td, .datepicker table tr th {
            text-align: center;
            width: 0px;
            height: 0px;
            border-radius: 4px;
            border: none;
        }

        .table > thead > tr > th {
            vertical-align: bottom;
            background: #7b7b7b;
            color: #fff;
        }

        .datepicker table tr td.disabled, .datepicker table tr td.disabled:hover {
            background: none;
            color: #c5c5c5;
            cursor: default;
        }
    </style>
</asp:Content>

