<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="flt_Water_Billing.aspx.cs" Inherits="AWMS_AWMS_Transaction_flt_Water_Billing_flt_Water_Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
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
    <%--date--%>
    <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen"
        href="../../../css/Date/StyleSheetDate.css" />
    <%--date stop--%>

    <script>
        //start-0006
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function ConfirmMessage() {
            if (confirmbox > 0) {

                if (confirm("Are You Sure You Want To Leave This Page?")) {

                    window.location.href = "/AWMS/AWMS_Transaction/flt_Water_Billing/flt_Water_Billing_List.aspx";

                    return false;
                }
                else {
                    return false;

                }
            }
            else {

                window.location.href = "/AWMS/AWMS_Transaction/flt_Water_Billing/flt_Water_Billing_List.aspx";

                return false;
            }
        }
        function ConfirmClear() {
            if (confirmbox > 0) {

                if (confirm("Are You Sure You Want Clear All Data In This Page?")) {

                    window.location.href = "flt_Water_Billing.aspx";

                    return false;
                }
                else {
                    return false;

                }
            }
            else {

                window.location.href = "flt_Water_Billing.aspx";

                return false;
            }
        }
        //stop-0006
    </script>

    <script>


        function RedirectConFirm(WtrFillngId) {

            document.getElementById("<%=HiddenField1.ClientID%>").value = "";
            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";
            localStorage.clear();
            WaterCardSelected('0');

            if (confirm("Do you want to confirm this Entry?")) {
              
                window.location.href = "flt_Water_Billing.aspx?Id=" + WtrFillngId + "&InsUpd=CnfrmPnd";

            }
               else {
  
                window.location.href = "flt_Water_Billing.aspx?InsUpd=Save";
                   
               }
           }
        function RedirectConFirmAdCls(WtrFillngId) {

            document.getElementById("<%=HiddenField1.ClientID%>").value = "";
            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";
            localStorage.clear();
            WaterCardSelected('0');

            if (confirm("Do you want to confirm this Entry?")) {

                window.location.href = "flt_Water_Billing.aspx?Id=" + WtrFillngId + "&InsUpd=CnfrmPnd";
               }
               else {
                window.location.href = "flt_Water_Billing_List.aspx?InsUpd=Save";
               }
           }

        function SuccessSave() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Water Billing Details Saved Successfully.";
        }
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Water Billing Details Confirmed Successfully.";
        }
        function FailureConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirmation  Not Successfull. It is already Confirmed.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Water Billing Details Updated Successfully.";
        }

        function SuccessReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Water Billing Details Re-Opened Successfully.";
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
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Water Billing Details Inserted Successfully.Confirmation Pending";
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
        //function ShowHidden() {
         //   var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
          //  alert('Main ' + h);

           // var MainCancDtlld = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value
           // alert('MainCancDtlld ' + MainCancDtlld);
           // return false;
       // }


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


        // For adjust to decimal point also used for checking
        function DateCheck(obj, x, rtn) {

         //   alert('DateCheck ' + obj);
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
                        if (parseDate(document.getElementById(obj + x).value)==false) {
                         
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
        #TableHeaderBilling {
            background-color: #A4B487;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 30px;
        }



        #TableFooterBilling {
            color: red;
            font-weight: bold;
            font-family: calibri;
            line-height: 25px;
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

    <%--evm-0023 link for date picker--%>
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
           // alert('addMoreRows');
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






            //    alert('ADD');
            //   alert(RowIndex.toString());
            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
            recRow += '<td style="width: 2.8%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


            recRow += ' <td id="tdRcptNumber' + rowCount + '"  style="width: 36.5%;">';
            recRow += ' <input  id="txtRcptNumber' + rowCount + '"  class="BillngEntryField"  type="text"  onkeypress="return isTagName(\'txtRcptNumber' + rowCount + '\',\'txtRcptDate' + rowCount + '\',' + rowCount + ', event)"  onblur="return BlurWBRcptNumber(' + rowCount + ')"  onfocus="FocusValue(\'txtRcptNumber\',' + rowCount + ')"   maxlength=50 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 100%;margin-left: -0.5%;"/>';
            recRow += '   </td> ';


            recRow += ' <td id="tdRcptDate' + rowCount + '"  style="width: 14.7%;" class="input-append date">';
            recRow += ' <input  id="txtRcptDate' + rowCount + '"  class="BillngEntryField" placeholder="DD-MM-YYYY" type="text"   onkeypress="return isTagDateEnter(\'txtRcptDate' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return isTagDate(\'txtRcptDate' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)" onblur="return BlurWBRcptDate(\'txtRcptDate\',' + rowCount + ')" onfocus="FocusValue(\'txtRcptDate\',' + rowCount + ')"  maxlength=10 style="text-align: left; line-height: 20px; margin-top:0.5px; margin-bottom: 2px; width: 96%;margin-left: 3.3%; "/>';
            //recRow += ' <img class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:18px; width:18px" />';
            recRow += '   </td> ';
            /////////////////////////////

            recRow += ' <td id="tdVhclSelect' + rowCount + '" style="width: 30%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 1%;" id="txtselectorVhcl' + rowCount + '" class="BillngEntryField" type="text"  value="--Select Vehicle--"  onkeypress="return isTagName(\'txtselectorVhcl' + rowCount + '\',\'txtAmnt' + rowCount + '\',' + rowCount + ', event)"   onblur="return BlurWBVehicle(' + rowCount + ')" onfocus="return FocusWBVehicle(' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="--Select Vehicle--" type="text"   /></td>';
            recRow += ' <td  style="display: none;"><input id="txtselectorVhclNumbr' + rowCount + '"  value="--Select Vehicle--" type="text" maxlength=100  /></td>';


            recRow += ' <td style="width: 15%;"><input  id="txtAmnt' + rowCount + '" class="BillngEntryField" value="' + nMoney + '" type="text"    maxlength="' + AmntMaxLen + '" onkeydown="return isNumber(\'txtAmnt' + rowCount + '\',\'tdIndvlAddMoreRowPic' + rowCount + '\', event)"   onblur="return BlurValue(\'txtAmnt\',' + rowCount + ')" onfocus="FocusValue(\'txtAmnt\',' + rowCount + ')"  style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 95%;margin-left: 0.9%;"/></td>';

            recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);"  style="  cursor: pointer;"></td>';
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
                    selectorToAutocompleteTextBox('txtselectorVhcl' + rowCount, rowCount);
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
            if (boolFocus == true) {
             
                document.getElementById("txtRcptNumber" + rowCount).focus();
                //$noC("div.Cls" + rowCount + " input.ui-autocomplete-input").select();
                $noC("#txtRcptNumber" + rowCount).select();
            }


            $noC('#txtRcptDate' + rowCount).datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                endDate: new Date()
            });

         //   alert('add rows');


        }

       
        function EditListRows(EditRcptNumbr, EditRcptDate, EditVhclNumbr, EditVhclId, EditAmount, EditDtlId) {


          //  alert('EditDtlId ' + EditDtlId);// && EditHike != "" && EditAmount != "" && EditStockStatus != ""
            if (EditRcptNumbr != "" && EditRcptDate != "" && EditVhclNumbr != "" && EditVhclId != "" && EditAmount.toString() != "" && EditDtlId != "") {

             
                rowCount++;
                RowIndex++;


                var nAmnt = EditAmount;
              
                var AmntMaxLen = 12;
              
                // for floatting number adjustment from corp global
                var FloatingValueMoney = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                if (FloatingValueMoney != "") {

                 
                    nAmnt = EditAmount.toFixed(FloatingValueMoney);
                }




                //      document.getElementById("spanAddRowTax").style.opacity = "0.3";


              
                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 2.8%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                recRow += ' <td id="tdRcptNumber' + rowCount + '"  style="width: 36.5%;">';
                recRow += ' <input  id="txtRcptNumber' + rowCount + '"  class="BillngEntryField"  type="text" value="' + EditRcptNumbr + '" onkeypress="return isTagName(\'txtRcptNumber' + rowCount + '\',\'txtRcptDate' + rowCount + '\',' + rowCount + ', event)"  onblur="return BlurWBRcptNumber(' + rowCount + ')"  onfocus="FocusValue(\'txtRcptNumber\',' + rowCount + ')"   maxlength=50 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 100%;margin-left: -0.5%;"/>';
                recRow += '   </td> ';
              

                recRow += ' <td id="tdRcptDate' + rowCount + '"  style="width: 14.7%;" class="input-append date">';
                recRow += ' <input  id="txtRcptDate' + rowCount + '"  class="BillngEntryField" placeholder="DD-MM-YYYY" type="text" value="' + EditRcptDate + '" onkeypress="return isTagDateEnter(\'txtRcptDate' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)" onkeydown="return isTagDate(\'txtRcptDate' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)" onblur="return BlurWBRcptDate(\'txtRcptDate\',' + rowCount + ')" onfocus="FocusValue(\'txtRcptDate\',' + rowCount + ')"  maxlength=10 style="text-align: left; line-height: 20px; margin-top:0.5px; margin-bottom: 2px; width: 96%;margin-left: 3.3%; "/>';
                //recRow += ' <img class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:18px; width:18px" />';
                recRow += '   </td> ';


                recRow += ' <td id="tdVhclSelect' + rowCount + '" style="width: 30%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 1%;" id="txtselectorVhcl' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditVhclNumbr + '"  onkeypress="return isTagName(\'txtselectorVhcl' + rowCount + '\',\'txtAmnt' + rowCount + '\',' + rowCount + ', event)"   onblur="return BlurWBVehicle(' + rowCount + ')" onfocus="return FocusWBVehicle(' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> '; 
                recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="' + EditVhclId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorVhclNumbr' + rowCount + '"  value="' + EditVhclNumbr + '" type="text" maxlength=100  /></td>';

                
                recRow += ' <td style="width: 15%;"><input  id="txtAmnt' + rowCount + '" value="' + nAmnt + '" class="BillngEntryField"  type="text"    maxlength="' + AmntMaxLen + '" onkeydown="return isNumber(\'txtAmnt' + rowCount + '\',\'tdIndvlAddMoreRowPic' + rowCount + '\', event)"   onblur="return BlurValue(\'txtAmnt\',' + rowCount + ')" onfocus="FocusValue(\'txtAmnt\',' + rowCount + ')"  style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 95%;margin-left: 0.9%;"/></td>';

            
                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);"  style="  cursor: pointer;"></td>';
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

                var $au = jQuery.noConflict();

                (function ($au) {
                    $au(function () {
                        selectorToAutocompleteTextBox('txtselectorVhcl' + rowCount, rowCount);
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

            //evm-0023 function for water billing date picker
            $noC('#txtRcptDate' + rowCount).datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                endDate: new Date()
            });

        }

        function ViewListRows(EditRcptNumbr, EditRcptDate, EditVhclNumbr, EditVhclId, EditAmount, EditDtlId) {

          
            //    alert('EditStockStatus' + EditStockStatus);// && EditHike != "" && EditAmount != "" && EditStockStatus != ""
            if (EditRcptNumbr != "" && EditRcptDate != "" && EditVhclNumbr != "" && EditVhclId != "" && EditAmount.toString() != "" && EditDtlId != "") {

               //  alert('in view');
                rowCount++;
                RowIndex++;

               
             
                var AmntMaxLen = 12;
              
                // for floatting number adjustment from corp global
                var FloatingValueMoney = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                if (FloatingValueMoney != "") {

                    nAmnt = EditAmount.toFixed(FloatingValueMoney);
                }

                //      document.getElementById("spanAddRowTax").style.opacity = "0.3";



                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();



                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 2.8%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                recRow += ' <td id="tdRcptNumber' + rowCount + '"  style="width: 36.5%;">';
                recRow += ' <input disabled id="txtRcptNumber' + rowCount + '"  class="BillngEntryField"  type="text" value="' + EditRcptNumbr + '" onkeypress="return isTagName(\'txtRcptNumber' + rowCount + '\',\'txtRcptDate' + rowCount + '\',' + rowCount + ', event)"  onblur="return BlurWBRcptNumber(' + rowCount + ')"  onfocus="FocusValue(\'txtRcptNumber\',' + rowCount + ')"   maxlength=50 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 100%;margin-left: -0.5%;"/>';
                recRow += '   </td> ';


                recRow += ' <td id="tdRcptDate' + rowCount + '"  style="width: 14.7%;" class="input-append date">';
                recRow += ' <input disabled  id="txtRcptDate' + rowCount + '"  class="BillngEntryField" placeholder="DD-MM-YYYY" type="text" value="' + EditRcptDate + '" onkeypress="return isTagDateEnter(\'txtRcptDate' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)" onkeydown="return isTagDate(\'txtRcptDate' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)" onblur="return BlurWBRcptDate(\'txtRcptDate\',' + rowCount + ')" onfocus="FocusValue(\'txtRcptDate\',' + rowCount + ')"  maxlength=10 style="text-align: left; line-height: 20px; margin-top:0.5px; margin-bottom: 2px; width: 96%;margin-left: 3.3%; "/>';
                //recRow += ' <img  class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:18px; width:18px" />';
                recRow += '   </td> ';


                recRow += ' <td id="tdVhclSelect' + rowCount + '" style="width: 30%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 1%;" id="txtselectorVhcl' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditVhclNumbr + '"  onkeypress="return isTagName(\'txtselectorVhcl' + rowCount + '\',\'txtAmnt' + rowCount + '\',' + rowCount + ', event)"   onblur="return BlurWBVehicle(' + rowCount + ')" onfocus="return FocusWBVehicle(' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input  id="txtselectorVhclId' + rowCount + '"  value="' + EditVhclId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input  id="txtselectorVhclNumbr' + rowCount + '"  value="' + EditVhclNumbr + '" type="text" maxlength=100  /></td>';


                recRow += ' <td style="width: 15%;"><input disabled id="txtAmnt' + rowCount + '" value="' + nAmnt + '" class="BillngEntryField"  type="text"    maxlength="' + AmntMaxLen + '" onkeydown="return isNumber(\'txtAmnt' + rowCount + '\',\'tdIndvlAddMoreRowPic' + rowCount + '\', event)"   onblur="return BlurValue(\'txtAmnt\',' + rowCount + ')" onfocus="FocusValue(\'txtAmnt\',' + rowCount + ')"  style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 95%;margin-left: 0.9%;"/></td>';

                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input disabled id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);"  style="  cursor: pointer;"></td>';
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
                            

                                    document.getElementById("txtRcptNumber" + res[1]).focus();
                                    $noCon("#txtRcptNumber" + res[1]).select();                               
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

                                    document.getElementById("txtRcptNumber" + res[1]).focus();
                                    $noCon("#txtRcptNumber" + res[1]).select();                              
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
        function ChangeCardNumber() {
            var $noCT = jQuery.noConflict();
            var PreviousVal = document.getElementById("<%=hiddenPreviousCardNumber.ClientID%>").value;



            var DropdownCardNumber = document.getElementById("<%=ddlCardNumber.ClientID%>");
            var SelectedValueCardNumber = DropdownCardNumber.value;

            if (SelectedValueCardNumber != PreviousVal) {
              //  alert('i');
                if (SelectedValueCardNumber == '--SELECT WATER CARD--') {

                    SelectedValueCardNumber = 0;
                }
                if (SelectedValueCardNumber != 0) {
                    WaterCardSelected(SelectedValueCardNumber);
                    $noCon("div#divCardNumber input.ui-autocomplete-input").css("borderColor", "");
                    IncrmntConfrmCounter();
                }
                else {
                    WaterCardSelected('0');
                    IncrmntConfrmCounter();
                    return false;
                }
            }
            else {
                return false;
            }
        }

        function IsWaterCardSelected() {
  
            var DropdownCardNumber = document.getElementById("<%=ddlCardNumber.ClientID%>");
                   var SelectedValueCardNumber = DropdownCardNumber.value;

             
                   if (SelectedValueCardNumber == '--SELECT WATER CARD--') {
                    
                   //    document.getElementById("<%=ddlCardNumber.ClientID%>").style.borderColor = "Red";
                       $noCon("div#divCardNumber input.ui-autocomplete-input").css("borderColor", "Red");
                       $noCon("div#divCardNumber input.ui-autocomplete-input").focus();
                       $noCon("div#divCardNumber input.ui-autocomplete-input").select();
                       document.getElementById("<%=ddlCardNumber.ClientID%>").focus();
                    
                     //  alert('IsWaterCardSelected');
                       return false;
                   }
                   else {
                       return true;

                   }
                       
                  
               }

        function getPreviousDDLCardNumber_SelectedVal() {
            var DropdownList = document.getElementById('<%=ddlCardNumber.ClientID %>');
            var SelectedValue = DropdownList.value;
            document.getElementById("<%=hiddenPreviousCardNumber.ClientID%>").value = SelectedValue;

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


        function BlurWBRcptNumber(x) {
          

            //////////////////////////////
            document.getElementById('divBlink').style.visibility = "hidden";

            //for replacing ',",\,<,>
            // replacing < and > tags and backslash and single and double quotes
            var RcptNumberWithoutReplace = document.getElementById("txtRcptNumber" + x).value;

            var replaceText1 = RcptNumberWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");
            document.getElementById("txtRcptNumber" + x).value = replaceText5.trim();

            
            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (SavedorNot == "saved") {
                if (IsWaterCardSelected() == true) {
                    var RcptNumber = document.getElementById("txtRcptNumber" + x).value.trim();

                    var hiddenRcptNumberFocus = document.getElementById("<%=hiddenValueFocus.ClientID%>").value.trim();
                    if (RcptNumber != hiddenRcptNumberFocus) {

                        if (RcptNumber != "") {
                            document.getElementById("txtRcptNumber" + x).style.borderColor = "";
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

                                var hiddenRcptNumber = document.getElementById("<%=hiddenValueFocus.ClientID%>").value.trim();

                                if (hiddenRcptNumber != "") {

                                    document.getElementById("txtRcptNumber" + x).value = hiddenRcptNumber;


                                }


                            }
                        }
                        else {
                            var hiddenRcptNumber = document.getElementById("<%=hiddenValueFocus.ClientID%>").value.trim();

                            if (hiddenRcptNumber != "") {

                                document.getElementById("txtRcptNumber" + x).value = hiddenRcptNumber;


                            }
                        }
                    }
                }
                else {
                    var hiddenRcptNumber = document.getElementById("<%=hiddenValueFocus.ClientID%>").value.trim();

                    if (hiddenRcptNumber != "") {

                        document.getElementById("txtRcptNumber" + x).value = hiddenRcptNumber;


                    }
                }
            }
            else {
                //   if (RecptToCheck() == true) {
                if (IsWaterCardSelected() == true) {
                    var RcptNumber = document.getElementById("txtRcptNumber" + x).value.trim();
                    var hiddenRcptNumberFocus = document.getElementById("<%=hiddenValueFocus.ClientID%>").value.trim();
                    if (RcptNumber != hiddenRcptNumberFocus) {
                        if (RcptNumber != "") {
                            // alert(QtnItemId);

                            //check duplication
                            if (DuplicationCheck(x, row_index) == true) {
                                document.getElementById('divErrorNotification').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                                document.getElementById("txtRcptNumber" + x).style.borderColor = "";

                                if (document.getElementById("<%=hiddenDefaultVhclId.ClientID%>").value != "" && document.getElementById("<%=hiddenDefaultVhclNumbr.ClientID%>").value != "" && document.getElementById("<%=hiddenDefaultVhclNumbr.ClientID%>").value != null && document.getElementById("<%=hiddenDefaultVhclId.ClientID%>").value != null) {
                                    if (document.getElementById("txtselectorVhclId" + x).value == "--Select Vehicle--" && document.getElementById("txtselectorVhcl" + x).value == "--Select Vehicle--" && document.getElementById("txtselectorVhclNumbr" + x).value == "--Select Vehicle--") {
                                        document.getElementById("txtselectorVhclId" + x).value = document.getElementById("<%=hiddenDefaultVhclId.ClientID%>").value;
                                        document.getElementById("txtselectorVhclNumbr" + x).value = document.getElementById("<%=hiddenDefaultVhclNumbr.ClientID%>").value;
                                        document.getElementById("txtselectorVhcl" + x).value = document.getElementById("<%=hiddenDefaultVhclNumbr.ClientID%>").value;
                                        // alert(document.getElementById("<%=hiddenDefaultVhclId.ClientID%>").value);
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

                            }
                            else {

                                document.getElementById("txtRcptNumber" + x).value = "";

                                document.getElementById("txtRcptNumber" + x).style.borderColor = "Red";


                            }


                        }
                        else {



                        }
                    }
                }
                else {

                    document.getElementById("txtRcptNumber" + x).value = "";
                }
            }
        }




        function BlurWBRcptDate(obj, x) {

            document.getElementById('divBlink').style.visibility = "hidden";

            var RcptDateWithoutReplace = document.getElementById(obj+ x).value;

            var replaceText1 = RcptDateWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");
            document.getElementById(obj + x).value = replaceText5.trim();
               
            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;

            if (SavedorNot == "saved") {

                if (IsWaterCardSelected() == true) {
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

                    var hiddenRcptDateFocus = document.getElementById("<%=hiddenValueFocus.ClientID%>").value;
                    if (hiddenRcptDateFocus != "") {
                        document.getElementById(obj + x).value = hiddenRcptDateFocus;


                    }
                }
            }
            else {

                if (IsWaterCardSelected() == true) {
                    var WBtxtRcptDate = document.getElementById("txtRcptDate" + x).value;
                    var hiddenRcptDateFocus = document.getElementById("<%=hiddenValueFocus.ClientID%>").value;
                    if (WBtxtRcptDate != hiddenRcptDateFocus) {
                        if (CheckRcptNumberFieldAndHighlight(x) == true) {



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


 




        function BlurWBVehicle(x) {
            if (document.getElementById("txtselectorVhclId" + x).value == "" || document.getElementById("txtselectorVhclId" + x).value == "--Select Vehicle--") {

                document.getElementById("txtselectorVhcl" + x).value = "--Select Vehicle--";
            }

            var TxtName = document.getElementById("txtselectorVhcl" + x).value.trim();

            if (TxtName == "" || TxtName == "--Select Vehicle--") {
                document.getElementById("txtselectorVhclId" + x).value = "--Select Vehicle--";
                document.getElementById("txtselectorVhclNumbr" + x).value = "--Select Vehicle--";
                document.getElementById("txtselectorVhcl" + x).value = "--Select Vehicle--";
            }

            var VhclNmbr = document.getElementById("txtselectorVhclNumbr" + x).value.trim();
            if (VhclNmbr != "" || VhclNmbr != "--Select Vehicle--") {
                document.getElementById("txtselectorVhcl" + x).value = VhclNmbr;
            }

            //////////////////////////////
            document.getElementById('divBlink').style.visibility = "hidden";
            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (SavedorNot == "saved") {
                if (IsWaterCardSelected() == true) {
                var WBVhclId = document.getElementById("txtselectorVhclId" + x).value;

                var hiddenVhclIdFocus = document.getElementById("<%=hiddenWBVhclIdFocus.ClientID%>").value;
                if (WBVhclId != hiddenVhclIdFocus) {

                    if (WBVhclId != "--Select Vehicle--") {
                        document.getElementById("txtselectorVhcl" + x).style.borderColor = "";

                        //Update to local storage

                        document.getElementById('divErrorNotification').style.visibility = "hidden";
                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                        LocalStorageEdit(x, row_index);


                    }

                    else {
                        var hiddenHeadValId = document.getElementById("<%=hiddenWBVhclIdFocus.ClientID%>").value;
                        var hiddenHeadValText = document.getElementById("<%=hiddenWBVhclNameFocus.ClientID%>").value;
                        if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                            document.getElementById("txtselectorVhcl" + x).value = hiddenHeadValText;
                            document.getElementById("txtselectorVhclId" + x).value = hiddenHeadValId;
                            document.getElementById("txtselectorVhclNumbr" + x).value = hiddenHeadValText;

                        }
                    }
                }

                }
                else {
                    var hiddenHeadValId = document.getElementById("<%=hiddenWBVhclIdFocus.ClientID%>").value;
                    var hiddenHeadValText = document.getElementById("<%=hiddenWBVhclNameFocus.ClientID%>").value;
                    if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                        document.getElementById("txtselectorVhcl" + x).value = hiddenHeadValText;
                        document.getElementById("txtselectorVhclId" + x).value = hiddenHeadValId;
                        document.getElementById("txtselectorVhclNumbr" + x).value = hiddenHeadValText;

                    }
                }

            }

            else {

                var WBVhclId = document.getElementById("txtselectorVhclId" + x).value;
                var hiddenVhclIdFocus = document.getElementById("<%=hiddenWBVhclIdFocus.ClientID%>").value;
                if (IsWaterCardSelected() == true) {
                    if (WBVhclId != hiddenVhclIdFocus) {
                        if (WBVhclId != "--Select Vehicle--") {
                            // alert(WBVhclId);


                            document.getElementById('divErrorNotification').style.visibility = "hidden";
                            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

                            document.getElementById("txtselectorVhcl" + x).style.borderColor = "";


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
                    var hiddenHeadValId = document.getElementById("<%=hiddenWBVhclIdFocus.ClientID%>").value;
                    var hiddenHeadValText = document.getElementById("<%=hiddenWBVhclNameFocus.ClientID%>").value;
                    if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                        document.getElementById("txtselectorVhcl" + x).value = hiddenHeadValText;
                        document.getElementById("txtselectorVhclId" + x).value = hiddenHeadValId;
                        document.getElementById("txtselectorVhclNumbr" + x).value = hiddenHeadValText;

                    }
                }
            }
        }


        function FocusWBVehicle(x, event) {


            //for viewing over label
            var offset = $noCon("#txtselectorVhcl" + x).offset();

           //  alert('hi')
            var posY = 0;
            var posX = 0;
            posY = offset.top - 12.8;

            posX = offset.left - 680;

            posX = 52.4;
            document.getElementById("divBlink").innerHTML = "Vehicle Number"
            var d = document.getElementById('divBlink');
            d.style.position = "absolute";
            d.style.left = posX + '%';
            d.style.top = posY + 'px';
            document.getElementById('divBlink').style.visibility = "visible";


            //   var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            //   if (SavedorNot == "saved") {
            document.getElementById("<%=hiddenWBVhclIdFocus.ClientID%>").value = "";
            document.getElementById("<%=hiddenWBVhclNameFocus.ClientID%>").value = "";
            var WBVhclId = document.getElementById("txtselectorVhclId" + x).value;
            document.getElementById("<%=hiddenWBVhclIdFocus.ClientID%>").value = WBVhclId;
                var WBVhclName = document.getElementById("txtselectorVhclNumbr" + x).value;
                document.getElementById("<%=hiddenWBVhclNameFocus.ClientID%>").value = WBVhclName;
            if (document.getElementById("txtselectorVhcl" + x).value == "--Select Vehicle--") {
                document.getElementById("txtselectorVhcl" + x).value = "";
            }
          
            //  }
        }


        function BlurValue(obj, x) {
          //  alert('BlurValue ');
            document.getElementById('divBlink').style.visibility = "hidden";

            var AmntVal = document.getElementById(obj + x).value;


            if (isNaN(AmntVal) == true) {
                //NaN not a number ,if number return false ,If not a number return true
                AmntVal = "";

            }
            if (AmntVal < 0) {
                //NaN not a number ,if number return false ,If not a number return true
                AmntVal = "";

            }
            document.getElementById(obj + x).value = AmntVal;
            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;

            if (SavedorNot == "saved") {

                if (IsWaterCardSelected() == true) {
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

                if (IsWaterCardSelected() == true) {
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
                        document.getElementById(obj + x).value = 0;
                        ValueCheck(obj, x, false);

                    }


                } else {
                    document.getElementById(obj + x).value = 0;
                    ValueCheck(obj, x, false);

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

                    posX = offset.left - 971.1;

                    document.getElementById("divBlink").innerHTML = "Amount";
                }
                else if (obj == "txtRcptDate") {

                    posX = offset.left - 494.1;

                    document.getElementById("divBlink").innerHTML = "Receipt Date";
                }
                else if (obj == "txtRcptNumber") {
                    //alert('txtRcptNumber ' );
                    posX = offset.left - 86.6;

                    document.getElementById("divBlink").innerHTML = "Receipt Number";
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

    var tbClientWtrBilling = localStorage.getItem("tbClientWtrBilling");//Retrieve the stored data

    tbClientWtrBilling = JSON.parse(tbClientWtrBilling); //Converts string to object

    if (tbClientWtrBilling == null) //If there is no data, initialize an empty array
        tbClientWtrBilling = [];
    var detailId = document.getElementById("tdDtlId" + x).innerHTML;
    //  var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
    var evt = document.getElementById("tdEvt" + x).innerHTML;



    if (evt == 'INS') {
        var $add = jQuery.noConflict();
        var client = JSON.stringify({
            ROWID: "" + x + "",
            RCPTNUMBR: $add("#txtRcptNumber" + x).val(),
            RCPTDATE: $add("#txtRcptDate" + x).val(),
            VHCLID: $add("#txtselectorVhclId" + x).val(),
            VHCLNUMBR: $add("#txtselectorVhclNumbr" + x).val(),
            AMOUNT: $add("#txtAmnt" + x).val(),
            EVTACTION: "" + evt + "",
            DTLID: "0"

        });
    }
    else if (evt == 'UPD') {
        var $add = jQuery.noConflict();
        var client = JSON.stringify({
            ROWID: "" + x + "",
            RCPTNUMBR: $add("#txtRcptNumber" + x).val(),
            RCPTDATE: $add("#txtRcptDate" + x).val(),
            VHCLID: $add("#txtselectorVhclId" + x).val(),
            VHCLNUMBR: $add("#txtselectorVhclNumbr" + x).val(),
            AMOUNT: $add("#txtAmnt" + x).val(),
            EVTACTION: "" + evt + "",
            DTLID: "" + detailId + ""


        });
    }




    tbClientWtrBilling.push(client);
    localStorage.setItem("tbClientWtrBilling", JSON.stringify(tbClientWtrBilling));

    $add("#cphMain_HiddenField1").val(JSON.stringify(tbClientWtrBilling));


    //for calculation of total Amount
    CalculateTotalAmountFromHiddenField();



    // alert("The data was saved.");
    // var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
            // alert(h);

            document.getElementById("tdSave" + x).innerHTML = "saved";
            //   alert('saved');
            CheckaddMoreRowsIndividual(x, true);
            IncrmntConfrmCounter();
           // alert('gj');
            return true;

        }
        function LocalStorageDelete(row_index, x) {

            var tbClientWtrBilling = localStorage.getItem("tbClientWtrBilling");//Retrieve the stored data

            tbClientWtrBilling = JSON.parse(tbClientWtrBilling); //Converts string to object

            if (tbClientWtrBilling == null) //If there is no data, initialize an empty array
                tbClientWtrBilling = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientWtrBilling.splice(row_index, 1);
            localStorage.setItem("tbClientWtrBilling", JSON.stringify(tbClientWtrBilling));
            $noCon("#cphMain_HiddenField1").val(JSON.stringify(tbClientWtrBilling));
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
    //  alert('edit start x ' + x);
    //  alert('edit start row_index ' + row_index);
    var tbClientWtrBilling = localStorage.getItem("tbClientWtrBilling");//Retrieve the stored data

    tbClientWtrBilling = JSON.parse(tbClientWtrBilling); //Converts string to object

    if (tbClientWtrBilling == null) //If there is no data, initialize an empty array
        tbClientWtrBilling = [];
    var detailId = document.getElementById("tdDtlId" + x).innerHTML;
    // var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
    var evt = document.getElementById("tdEvt" + x).innerHTML;

    // alert('edit pmode ' + PrdctMode);
    //  alert('additional:' + additional)




    if (evt == 'INS') {

        var $E = jQuery.noConflict();
        tbClientWtrBilling[row_index] = JSON.stringify({
            ROWID: "" + x + "",
            RCPTNUMBR: $E("#txtRcptNumber" + x).val(),
            RCPTDATE: $E("#txtRcptDate" + x).val(),
            VHCLID: $E("#txtselectorVhclId" + x).val(),
            VHCLNUMBR: $E("#txtselectorVhclNumbr" + x).val(),
            AMOUNT: $E("#txtAmnt" + x).val(),
            EVTACTION: "" + evt + "",
            DTLID: "0"

        });//Alter the selected item on the table
    }
    else {

        var $E = jQuery.noConflict();
        tbClientWtrBilling[row_index] = JSON.stringify({
            ROWID: "" + x + "",
            RCPTNUMBR: $E("#txtRcptNumber" + x).val(),
            RCPTDATE: $E("#txtRcptDate" + x).val(),
            VHCLID: $E("#txtselectorVhclId" + x).val(),
            VHCLNUMBR: $E("#txtselectorVhclNumbr" + x).val(),
            AMOUNT: $E("#txtAmnt" + x).val(),
            EVTACTION: "" + evt + "",
            DTLID: "" + detailId + ""

        });//Alter the selected item on the table

    }





    localStorage.setItem("tbClientWtrBilling", JSON.stringify(tbClientWtrBilling));
    $E("#cphMain_HiddenField1").val(JSON.stringify(tbClientWtrBilling));


    //for calculation of total Amount
    CalculateTotalAmountFromHiddenField();




    //  alert("The data was edited.");
    //  operation = "A"; //Return to default value
    // var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
            // alert(h);
            CheckaddMoreRowsIndividual(x, true);
    //alert('cal stop');
          //  IncrmntConfrmCounter();
           // alert('gj');
            return true;
        }
    </script>

    <script>
        var $noCon = jQuery.noConflict();
        function DuplicationCheck(x, row_Index) {

            var RcptNumberObj = document.getElementById("txtRcptNumber" + x);

            //  var selectedText = QtnItem.options[QtnItem.selectedIndex].text;
            var selectedText = RcptNumberObj.value;
            var RcptNumber = selectedText;

            //  var resultJSON = '{"FirstName":"John","LastName":"Doe","Email":"johndoe@johndoe.com","Phone":"123 dead drive"}","{"FirstName":"Johni","LastName":"Doioe","Email":"johndoe@johndoe.com","Phone":"123 dead drive"}';
            var hiddenVal = document.getElementById("<%=HiddenField1.ClientID%>").value;
              //  alert(hiddenVal);

            var ret = true;
            if (document.getElementById("<%=hiddenAllowRcptNumberDuplication.ClientID%>").value != "1") {
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

                            if (k == "RCPTNUMBR") {

                                if (v.toUpperCase().trim() == RcptNumber.toUpperCase().trim()) {
                                    //alert('found');
                                    //alert('i ' + i);
                                    // alert('RowIndex' + row_Index);
                                    var Rindex = parseInt(row_Index);

                                    if (i != Rindex) {

                                        //display the key and value pair
                                        // alert(k + ' is ' + v);
                                        document.getElementById('divErrorNotification').style.visibility = "visible";
                                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, You have already selected this Receipt Number!";
                                        ret = false;
                                        // return false;
                                    }
                                }
                            }
                        });
                    }

                }
            }

            return ret;

        }
        function CalculateTotalAmountFromHiddenField() {
            var Total = 0;
            //  var resultJSON = '{"FirstName":"John","LastName":"Doe","Email":"johndoe@johndoe.com","Phone":"123 dead drive"}","{"FirstName":"Johni","LastName":"Doioe","Email":"johndoe@johndoe.com","Phone":"123 dead drive"}';
            var hiddenVal = document.getElementById("<%=HiddenField1.ClientID%>").value;
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

                        if (k == "AMOUNT") {
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
            document.getElementById('tdFooterTotalAmount').innerText = n;

            var TotalGrossAmt = n;

            var WtrCardCurrentAmount = 0;
            if (document.getElementById("<%=hiddenWtrCurrentAmount.ClientID%>").value != "")
            {
                WtrCardCurrentAmount = parseFloat(document.getElementById("<%=hiddenWtrCurrentAmount.ClientID%>").value);
                
            }
            var TotalNetBalance = 0;
            var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;
            if (ViewVal == "") {
                TotalNetBalance = WtrCardCurrentAmount - TotalGrossAmt;
           }
           else {
               TotalNetBalance = WtrCardCurrentAmount;
            }
            if (FloatingValue != "") {
                TotalNetBalance = TotalNetBalance.toFixed(FloatingValue);
            }
            document.getElementById("<%=lblBalanceAmount.ClientID%>").innerText = TotalNetBalance;
        }



        function CheckaddMoreRowsIndividual(x, retBool) {
            // for add image in each row

            var check = document.getElementById("tdInx" + x).innerHTML;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (check == " ") {

                if (retBool == true) {

                    if (CheckAllRowFieldAndHighlight(x,false) == true) {
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



            var RcptNumber = document.getElementById("txtRcptNumber" + x).value;
            if (RcptNumber == "") {
                ret = false;
            }
            else {

                if (DuplicationCheck(x, row_index) == true) {
                    document.getElementById('divErrorNotification').style.visibility = "hidden";
                    document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
                    }
                    else {

                    document.getElementById("txtRcptNumber" + x).value = "";
    
                    document.getElementById("txtRcptNumber" + x).style.borderColor = "Red";                     
                        ret = false;
                    }
                }
            var RcptDate = document.getElementById("txtRcptDate" + x).value;
            if (RcptDate == "") {
                ret = false;
            }
            var WBVhclId = document.getElementById("txtselectorVhclId" + x).value;
            if (WBVhclId == "--Select Vehicle--" || WBVhclId == "") {
                ret = false;

            }
            if (ValueCheck('txtAmnt', x, true) == false) {
                ret = false;
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
        function CheckAllRowFieldAndHighlight(x,blFromBlurValue) {
            ret = true;
            var RcptNumber = document.getElementById("txtRcptNumber" + x).value;
            if (RcptNumber == "") {
                document.getElementById("txtRcptNumber" + x).style.borderColor = "Red";
                document.getElementById("txtRcptNumber" + x).focus();
                $noCon("#txtRcptNumber" + x).select();
                return false;
            }
            var RcptDate = document.getElementById("txtRcptDate" + x).value;
            if (RcptDate == "") {
                document.getElementById("txtRcptDate" + x).style.borderColor = "Red";
                document.getElementById("txtRcptDate" + x).focus();
                $noCon("#txtRcptDate" + x).select();
                return false;
            }
            var WBVhclId = document.getElementById("txtselectorVhclId" + x).value;
            if (WBVhclId == "--Select Vehicle--" || WBVhclId == "") {
                document.getElementById("txtselectorVhcl" + x).style.borderColor = "Red";
                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                document.getElementById("txtselectorVhcl" + x).focus();
                $noCon("#txtselectorVhcl" + x).select();
                return false;

            }

            if (blFromBlurValue != true) {
                if (ValueCheck('txtAmnt', x, true) == false) {
                    document.getElementById("txtAmnt" + x).style.borderColor = "Red";
                    document.getElementById("txtAmnt" + x).focus();
                    $noCon("#txtAmnt" + x).select();
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
           // alert('validate');
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            

            document.getElementById('divErrorNotification').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

            if (IsWaterCardSelected() == true) {

                var CurrntBalAmnt = document.getElementById("<%=lblBalanceAmount.ClientID%>").innerText;
                if (CurrntBalAmnt.toString() != "" && CurrntBalAmnt >= 0) {
                    document.getElementById("<%=hiddenNetAmount.ClientID%>").value = document.getElementById("tdFooterTotalAmount").innerText;
                    var NetAmnt = document.getElementById("<%=hiddenNetAmount.ClientID%>").value;
                   // && NetAmnt != 0
                    if (NetAmnt.toString() != "" ) {
                        var TableRowCount = document.getElementById("TableaddedRows").rows.length;
                        //  alert(TableRowCount);
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

                                                var DropdownCardNumbr = document.getElementById("<%=ddlCardNumber.ClientID%>");
                                                var SelectedValueCardNumbr = DropdownCardNumbr.value;



                                                if (SelectedValueCardNumbr == '--SELECT WATER CARD--') {

                                                    SelectedValueCardNumbr = 0;
                                                }
                                                if (SelectedValueCardNumbr != 0) {
                                                    WaterCardSelected(SelectedValueCardNumbr);
                                                }
                                                else {
                                                    WaterCardSelected('0');
                                                }
                                                var CurrntBalAmt = document.getElementById("<%=lblBalanceAmount.ClientID%>").innerText;
                                                if (CurrntBalAmt.toString() != "" && CurrntBalAmt >= 0) {
                                                    ret = true;
                                                }
                                                else {

                                                    document.getElementById('divErrorNotification').style.visibility = "visible";
                                                    document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, Water card Current Balance cannot be less than zero.";
                                                   CheckSubmitZero();
                                                   return false;
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


                            else {

                                var ret = true;
                                var table = document.getElementById('TableaddedRows');
                                // alert(table.rows.length);
                                for (var i = 0; i < table.rows.length; i++) {
                                    if (i != table.rows.length - 1) {
                                        // FIX THIS
                                        var row = table.rows[i];

                                        var xLoop = (table.rows[i].cells[0].innerHTML);
                                        if (CheckAllRowFieldAndHighlight(xLoop, false) == false) {
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

                                        var RcptNumber = document.getElementById("txtRcptNumber" + x).value.trim();
                                        if (RcptNumber != "") {
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

                                                    var DropdownCardNumbr = document.getElementById("<%=ddlCardNumber.ClientID%>");
                                                    var SelectedValueCardNumbr = DropdownCardNumbr.value;



                                                    if (SelectedValueCardNumbr == '--SELECT WATER CARD--') {

                                                        SelectedValueCardNumbr = 0;
                                                    }
                                                    if (SelectedValueCardNumbr != 0) {
                                                        WaterCardSelected(SelectedValueCardNumbr);
                                                    }
                                                    else {
                                                        WaterCardSelected('0');
                                                    }
                                                    var CurrntBalAmt = document.getElementById("<%=lblBalanceAmount.ClientID%>").innerText;
                                                if (CurrntBalAmt.toString() != "" && CurrntBalAmt >= 0) {
                                                    ret = true;
                                                }
                                                else {

                                                    document.getElementById('divErrorNotification').style.visibility = "visible";
                                                    document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, Water card Current Balance cannot be less than zero.";
                                                    CheckSubmitZero();
                                                    return false;
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

                                return ret;
                            }
                        }
                        else {
                            document.getElementById('divErrorNotification').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, Please add atleast one Item to Save!";
                            CheckSubmitZero();
                            return false;

                        }

                        //----

                    }
                    else {

                        document.getElementById('divErrorNotification').style.visibility = "visible";
                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                        CheckSubmitZero();
                        return false;
                    }

                }
                else {

                    document.getElementById('divErrorNotification').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Sorry, Water card Current Balance cannot be less than zero.";
                CheckSubmitZero();
                return false;
            }
            }
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

            $('#cphMain_ddlCardNumber').selectToAutocomplete1Letter();
       //     alert('load begin');



            document.getElementById('divBlink').style.visibility = "hidden";

            // Run code
            //     alert('loaded statr');
            document.getElementById("<%=HiddenField1.ClientID%>").value = "";
            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";


            localStorage.clear();


            var DropdownCardNumber = document.getElementById("<%=ddlCardNumber.ClientID%>");
            var SelectedValueCardNumber = DropdownCardNumber.value;

       
           
                if (SelectedValueCardNumber == '--SELECT WATER CARD--') {

                    SelectedValueCardNumber = 0;
                }
                if (SelectedValueCardNumber != 0) {
                    WaterCardSelected(SelectedValueCardNumber);
                }
                else {
                    WaterCardSelected('0');
                }
            


            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
            var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;

            if (EditVal != "") {


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
                            EditListRows(json[key].RcptNumbr, json[key].RcptDate, json[key].VhclNumbr, json[key].VhclId, json[key].Amount,json[key].TransDtlId);

                            //  alert(json[key].LdgrHeadId);
                            //  alert(json[key].Amount);
                        }
                    }
                }


            }

            else if (ViewVal != "") {


              
                document.getElementById("<%=ddlCardNumber.ClientID%>").disabled = true;
                $("div#divCardNumber input.ui-autocomplete-input").attr("disabled", "disabled");
             //   alert('View  ' + ViewVal);

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

                            ViewListRows(json[key].RcptNumbr, json[key].RcptDate, json[key].VhclNumbr, json[key].VhclId, json[key].Amount, json[key].TransDtlId);


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
             //     document.getElementById("<%=lblBalanceAmount.ClientID%>").innerText = n;

            //    document.getElementById('tdFooterTotalAmount').innerText = n;

            }
            //  alert('hi');
            if (ViewVal == "") {


                addMoreRows(this.form, false, false, 0);



                //  alert('hi');
                document.getElementById("<%=ddlCardNumber.ClientID%>").focus();
                $("div#divCardNumber input.ui-autocomplete-input").select();
            }

         
        //    alert('loaded');



        });
    </script>

    <script>
        function selectorToAutocompleteTextBox(obj, x) {


            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;

            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;


            //$au('#cphMain_ddlExistingCustomer').selectToAutocomplete1Letter();
            //$au('#cphMain_ddlExistingProject').selectToAutocomplete1Letter();
            //$au('#cphMain_ddlExistingClient').selectToAutocomplete1Letter();
            //$au('#cphMain_ddlExistingContractor').selectToAutocomplete1Letter();
            //$au('#cphMain_ddlExistingConsultant').selectToAutocomplete1Letter();
            if (CorpId != '' && CorpId != null && (!isNaN(CorpId)) && OrgId != '' && OrgId != null && (!isNaN(OrgId))) {

                $("#" + obj).autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: '<%=ResolveUrl("WebServiceAutoCompletionWaterBilling.asmx/GetVehicleNumber") %>',
                            data: "{ 'strLikeVhclNumbr': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'intOrgId': '" + parseInt(OrgId) + "', 'intCorpId': '" + parseInt(CorpId) + "'}",
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
                        document.getElementById("txtselectorVhclNumbr" + x).value = i.item.label;
                        //  alert(i.item.val);
                        //  alert(i.item.label);
                    },

                    minLength:1

                });
            }


        }


        function WaterCardSelected(CardId) {

            //web method for drop down of narrations for common narration
            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;

            if (CorpId != '' && CorpId != null && OrgId != '' && OrgId != null && CardId != '' && CardId != null && CardId != '--SELECT WATER CARD--') {
                //     alert('hi entered');
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "flt_Water_Billing.aspx/CardDetails",
                    data: '{corporateId: "' + CorpId + '",organisationId:"' + OrgId + '" ,CARDID:"' + CardId + '"}',
                    dataType: "json",
                    success: function (data) {

                        if (data.d != '') {

                            document.getElementById("<%=hiddenWtrCurrentAmount.ClientID%>").value = data.d.strCurrentAmount;
                            document.getElementById("<%=hiddenDefaultVhclId.ClientID%>").value = data.d.strVhclId;
                            document.getElementById("<%=hiddenDefaultVhclNumbr.ClientID%>").value = data.d.strVchlNumbr;
           

                   
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
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
     <asp:HiddenField ID="hiddenNetAmount" runat="server" />
    <asp:HiddenField ID="hiddenWtrCurrentAmount" runat="server" />
       <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />
     <asp:HiddenField ID="hiddenDefaultVhclId" runat="server" />
     <asp:HiddenField ID="hiddenDefaultVhclNumbr" runat="server" />
        <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
          <asp:HiddenField ID="hiddenAllowRcptNumberDuplication" runat="server" Value="1" /> <%--for duplication allowing--%>
    <asp:HiddenField ID="hiddenValueFocus" runat="server" />
    <asp:HiddenField ID="hiddenWBVhclIdFocus" runat="server" />
    <asp:HiddenField ID="hiddenWBVhclNameFocus" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hiddenFloatingValueMoney" runat="server" />
    <asp:HiddenField ID="hiddenPreviousCardNumber" runat="server" />
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
         
               <div id="divCardNumber" style="width: 40%; margin-top: 2.2%;" class="eachform">
            <h2 style="margin-top: 1%; float: left; padding-right: 7%;">Card Number *</h2>
            <asp:DropDownList ID="ddlCardNumber" class="form1" Style="width: 65.5%; float: left;" runat="server" onblur="return ChangeCardNumber();" onfocus="getPreviousDDLCardNumber_SelectedVal()" autofocus="autofocus" autocorrect="off" autocomplete="off"></asp:DropDownList>

        </div>
            <div class="leads_form">
                <div id="divErrorNotification" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotification" runat="server"></asp:Label>
                </div>
                <div id="divTables" style="width: 100%; margin: auto; padding-top: 0.6%;">

                    <table id="TableHeaderBilling" rules="all" style="width: 95.5%;">

                        <tr>
                            <td style="font-size: 14px; width: 3%; padding-left: 0.5%;">Sl#</td>
                            <td style="font-size: 14px; width: 37%; padding-left: 0.5%;">Receipt Number</td>
                            <td style="font-size: 14px; width: 15%; padding-left: 0.5%;">Date</td>
                            <td style="font-size: 14px; width: 30.2%; text-align: center; padding-left: 0.5%;">Vehicle Number</td>
                            <td style="font-size: 14px; width: 15%; text-align: right; padding-right: 1%;">Amount</td>



                            <td id="spanAddRow" style="background: rgb(244, 246, 240) none repeat scroll 0% 0%;">
                                <%--  this not used  now if needed remove display none--%>
                                <img src="../../../Images/imgAddRows.png" style="cursor: pointer; width: 100%; height: 30px; display: none" onclick="CheckaddMoreRows();" />

                            </td>
                        </tr>
                    </table>

                    <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                        <table id="TableaddedRows" style="width: 100%;">
                        </table>

                        <table id="TableFooterBilling" rules="all" style="width: 95.4%; border: 1px none; background-color: beige;">

                            <tr>
                                <td style="font-size: 18px; width: 85%; padding-right: 1.2%; text-align: right; color: black;">Total</td>

                                <td id="tdFooterTotalAmount" style="font-size: 14px; width: 15%; text-align: right; padding-right: 0.3%;"></td>



                            </tr>
                        </table>


                    </div>
                    <div id="divBlink" style="background-color: rgb(249, 246, 3); font-size: 10.5px; color: black; opacity: 0.6;"></div>

                </div>




            </div>


             <div class="eachform" style="margin-top: 1%;">
                   <h2 style=" float: left; padding-right: 2%;">Balance Amount </h2>
                   <asp:Label ID="lblBalanceAmount" runat="server" Text="Label" style="color: red;font-weight: bold;" >0</asp:Label>
                        </div>


            <div class="eachform" style="margin-top: -1.5%;">

                <div class="subform" style="margin-left: 36.8%; width: 55%; margin-top: 2%;">


                    <asp:Button ID="btnSave" runat="server" class="save" Text="Save" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
                        <asp:Button ID="btnSaveClose" runat="server" class="save" Text="Save & Close" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />
                       <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnConfirm" runat="server" class="save" Text="Confirm" OnClientClick="return ValidateAndSave('Confirm');" OnClick="btnConfirm_Click" />
                    <asp:Button ID="btnReOpen" runat="server" class="save" Text="Re-Open" OnClientClick="return ReOpenConfirm();" OnClick="btnReOpen_Click" />
                    <%--<asp:Button ID="Button1" runat="server" class="save" Text="show" OnClientClick="return ShowHidden();" />--%>
                     <%--<asp:Button ID="btnList" runat="server" class="save" Text="List"   OnClientClick="return ConfirmMessage();" />--%>
                     <asp:Button ID="btnCancel" runat="server" class="save" Text="Cancel" PostBackUrl="flt_Water_Billing_List.aspx"  />
                     <asp:Button ID="btnClear" runat="server" class="save"  Text="Clear" OnClientClick="return ConfirmClear();" />
                    <%--<asp:Button ID="btnClose" runat="server" class="save" Text="Close" OnClientClick="return ConfirmMessage();" />--%>
                </div>

            </div>

             
        </div>


    </div>

    <%--evm-0023 css for date picker--%>
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

