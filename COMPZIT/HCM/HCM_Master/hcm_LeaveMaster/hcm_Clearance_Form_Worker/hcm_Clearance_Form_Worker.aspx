<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Clearance_Form_Worker.aspx.cs" Inherits="HCM_HCM_Master_hcm_LeaveMaster_hcm_Clearance_Form_Worker_hcm_Clearance_Form_Worker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style>


        

         /*--------------------------------------------------for modal Cancel Reason------------------------------------------------------*/
         .modalCancelView {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 23%;
             top: 30%;
             width: 50%; /* Full width */
             /*height: 58%;*/ /* Full height */
             overflow: auto; /* Enable scroll if needed */
             background-color: transparent;
         }


         /* Modal Content */
         .modal-CancelView {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 95.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }


         /* The Close Button */
         .closeCancelView {
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
         }

             .closeCancelView:hover,
             .closeCancelView:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
             }

         .modal-headerCancelView {
             /*padding: 1% 1%;*/
            background-color: #91a172;
             color: white;
         }

         .modal-bodyCancelView {
             padding: 4% 4% 7% 4%;
         }

         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
         #divErrorRsnAWMS,#div2 {
    border-radius: 4px;
    background: #fff;
    color: #53844E;
    font-size: 12.5px;
    font-family: Calibri;
    font-weight: bold;
    border: 2px solid #53844E;
    margin-top: -3.5%;
    margin-bottom: 2%;
}



        .div-Contact-details {
            /*border: 1px solid #cad1be;
            padding: 1% 2% 3% 2%;
            margin-top: 0%;
            display: block;
            */
            width: 95.5%;
            padding: 1% 2% 3% 2%;
            height: 115px;
            border: .5px solid;
            border-color: #9ba48b;
            background-color: #f3f3f3;
            margin-top: 0%;
        }

        .eachform {
            width: 100%;
            display: inline-block;
            margin: 0 0 6px;
        }

        .error {
            padding-top: 7%;
            padding-left: 29%;
            color: red;
            font-size: small;
            margin-left: 8%;
            font-family: Calibri;
        }



     input[type=checkbox] {
display:none;


}
 
input[type=checkbox] + label
{
background: url("/Images/Icons/cbUnchecked.png") no-repeat;
background-size: 100%;
height: 32px;
width: 32px;
display:inline-block;
padding: 0 0 0 0px;
}
input[type=checkbox]:checked + label
{
background: url("/Images/Icons/CbChecked.png") no-repeat;
background-size: 100%;
height: 32px;
width: 32px;
display:inline-block;
padding: 0 0 0 0px;
}
        /*////////////////////////////// old\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\*/


        /*input[type=checkbox] + label::before {
            display: block;
            content: url('/Images/Icons/cbUnchecked.png');
            position: relative;
        }

        input[type=checkbox]:checked + label::before {
            content: url('/Images/Icons/CbChecked.png');
        }

        .CheckBoxImg-class {
            display: none;
        }

        input[type="checkbox"] {
            display: none;
        }*/

        .cont_rght {
            width: 95%;
        }
    </style>

     <style type="text/css">
        .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            /*width: 52.6%;*/
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
   
    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
                $au('form').submit(function () {


                });
            });
        })(jQuery);
        </script>
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }

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

        function SuccessIns() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance Form  details inserted successfully.";
            document.getElementById("<%=ddlEmployee.ClientID%>").focus();
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }

        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance Form  details updated successfully.";
            document.getElementById("<%=ddlEmployee.ClientID%>").focus();
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function ErrMsg() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function Autocomplt() {
         
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();

        }
    </script>
    <%--validations--%>
    <script type="text/javascript" language="javascript">

        // for not allowing <> tags
        function isTag(evt) {
            IncrmntConfrmCounter();
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var retIsTag = true;
            if (charCode == 60 || charCode == 62) {
                retIsTag = false;
            }
            return retIsTag;
        }
        function isTagWithEnter(evt) {
            IncrmntConfrmCounter();
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var retIstagE = true;
            if (charCode == 60 || charCode == 62) {
                retIstagE = false;
            }
            return retIstagE;
        }
        // for not allowing enter
        function DisableEnter(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
            else {
                return true;
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
        function ConfirmMessage() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    if (document.getElementById("<%=HiddenFieldPage.ClientID%>").value == "Aprvl") {
                        window.location.href = "/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Approval/hcm_Clearance_Form_Approval_List.aspx";
                    }
                    else {
                        window.location.href = "hcm_Clearance_Form_WorkerList.aspx";
                    }
                            
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                if (document.getElementById("<%=HiddenFieldPage.ClientID%>").value == "Aprvl") {
                    window.location.href = "/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Approval/hcm_Clearance_Form_Approval_List.aspx";
                }
                else {
                    window.location.href = "hcm_Clearance_Form_WorkerList.aspx";
                }
                return false;
            }
        }
        function ConfirmClear() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to clear?")) {
                    window.location.href = "hcm_Clearance_Form_Worker.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_Clearance_Form_Worker.aspx";
                return false;
            }
        }
        function validateClearanceForm() {
            ret = true;
            //document.getElementById('divMessageArea').style.display = "none";
            document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = '';

            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtComments.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtComments.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtQpPassRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtQpPassRemarks.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtSimCardRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtSimCardRemarks.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtdrivingLicRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtdrivingLicRemarks.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtToolsAndCompanyRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtToolsAndCompanyRemarks.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtClearanceTrafficRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtClearanceTrafficRemarks.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtMessAmountRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtMessAmountRemarks.ClientID%>").value = replaceText2;
           

            //other tbl
            tableOtherItem = document.getElementById("tblOtherItemContainer");
            if (tableOtherItem.rows.length == 1) {
                for (var i = 0; i < tableOtherItem.rows.length; i++) {
                    if (i != tableOtherItem.rows.length) {
                        // FIX THIS
                        var row = tableOtherItem.rows[i];

                        var xLoop = (tableOtherItem.rows[i].cells[0].innerHTML);

                        if (CheckAndHighlightOtherItem(xLoop, 1) == false) {
                            ret = false;
                            //break;
                        }
                    }
                }
            }
            else {
                
                for (var i = tableOtherItem.rows.length-1; i >=0; i--) {
                    if (i != tableOtherItem.rows.length) {
                        // FIX THIS
                        var row = tableOtherItem.rows[i];

                        var xLoop = (tableOtherItem.rows[i].cells[0].innerHTML);

                        if (CheckAndHighlightOtherItem(xLoop, 0) == false) {
                            ret = false;
                            // break;
                        }
                    }
                }
            }


            //validate other Gate Passes
            table = document.getElementById("TableFileUploadContainerPermit");
            if (table.rows.length == 1) {
                for (var i = 0; i < table.rows.length; i++) {
                    if (i != table.rows.length) {
                        // FIX THIS
                        var row = table.rows[i];

                        var xLoop = (table.rows[i].cells[0].innerHTML);

                        if (CheckAndHighlightGatePass(xLoop, 1) == false) {
                            ret = false;
                            //break;
                        }
                    }
                }
            }
            else {
              
                for (var i = table.rows.length-1; i >=0; i--) {
                    if (i != table.rows.length) {
                        // FIX THIS
                        var row = table.rows[i];

                        var xLoop = (table.rows[i].cells[0].innerHTML);

                        if (CheckAndHighlightGatePass(xLoop, 0) == false) {
                            ret = false;
                            // break;
                        }
                    }
                }
            }

           





            if (ret == true) {

                tbClientTotalValues = '';
                tbClientTotalValues = [];

                for (var i = 0; i < table.rows.length; i++) {
                    // var row = table.rows[i];

                    var validRowID = (table.rows[i].cells[0].innerHTML);

                    var GatePass = document.getElementById("txtOtherGatePass" + validRowID).value.trim();
                    var GatePassRemarks = document.getElementById("txtGatePassRemarks" + validRowID).value.trim();
                    var cbGatePassStatus = document.getElementById("cbOtherGatePassSts" + validRowID).checked;
                    var tbDetailID = document.getElementById("tdDtlIdGatePass" + validRowID).innerHTML;
                    var EvtAction = document.getElementById("tdEvtGatePass" + validRowID).innerHTML;
                    var DetailID = "";
                    if (tbDetailID == "") {
                        DetailID = 0;
                    }
                    else {
                        DetailID = tbDetailID;
                    }
                    var cbStatus = "";
                    if (cbGatePassStatus == true) {
                        cbStatus = "1";
                    }
                    else {
                        cbStatus = "0";
                    }
                    var tblType = "GATEPASS";
                    if (GatePass != "") {
                        addToLocalStorage(GatePass, cbStatus, GatePassRemarks, DetailID, tblType, EvtAction);
                    }

                }

                //other table
                for (var i = 0; i < tableOtherItem.rows.length; i++) {
                    // var row = tableOtherItem.rows[i];

                    var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);

                    var OtherItem = document.getElementById("txtOtherOtherItem" + validRowID).value.trim();
                    var OtherItemRemarks = document.getElementById("txtOtherItemRemarks" + validRowID).value.trim();
                 
                    var cbOtherItemStatus = document.getElementById("cbOtherOtherItemSts" + validRowID).checked;
                    var tbDetailID = document.getElementById("tdDtlIdOtherItem" + validRowID).innerHTML;
                    var EvtAction = document.getElementById("tdEvtOtherItem" + validRowID).innerHTML;
                    var DetailID = "";
                    if (tbDetailID == "") {
                        DetailID = 0;
                    }
                    else {
                        DetailID = tbDetailID;
                    }
                    var cbStatus = "";
                    if (cbOtherItemStatus == true) {
                        cbStatus = "1";
                    }
                    else {
                        cbStatus = "0";
                    }
                    var tblType = "OTHERITEM";
                    if (OtherItem != "") {
                        addToLocalStorage(OtherItem, cbStatus, OtherItemRemarks, DetailID, tblType, EvtAction);
                    }
                }


            }
            else if (ret == false) {
                ErrMsg();
            }
            var ddlEmp = document.getElementById("<%=ddlEmployee.ClientID%>").value;
            if (ddlEmp == "--SELECT EMPLOYEE--") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                $noCon("div#DivCGuarantee input.ui-autocomplete-input").css("borderColor", "Red");
                $noCon("div#DivCGuarantee input.ui-autocomplete-input").focus();
                $noCon("div#DivCGuarantee input.ui-autocomplete-input").select();

                document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlEmployee.ClientID%>").focus();
                ret = false;
            }
            var ddlLeave = document.getElementById("<%=ddlLeave.ClientID%>").value;
            if (ddlLeave == "--SELECT LEAVE--") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                document.getElementById("<%=ddlLeave.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlLeave.ClientID%>").focus();
                ret = false;
            }
            
            //return false;
            return ret;
        }

        function addToLocalStorage(particular, cbStatus, textRemarks, DetailID, tblType, EvtAction) {
           
            var $add = jQuery.noConflict();


            var client = JSON.stringify({
                ROWID: "" + rowCountLocalStore + "",
                ITEM: "" + particular + "",
                STATUS: "" + cbStatus + "",
                REMARKS: "" + textRemarks + "",
                TYPE: "" + tblType + "",
                DETAILID: "" + DetailID + "",
                EVTACTION: "" + EvtAction + ""
            });
            tbClientTotalValues.push(client);
            document.getElementById("<%=hiddenTotalData.ClientID%>").value = JSON.stringify(tbClientTotalValues);
           
            rowCountLocalStore++;
        }
        // checks every field in row
        function CheckAndHighlightGatePass(x, FirstRow) {
         
            if (FirstRow == 1) {
                //first row condition
                document.getElementById("txtOtherGatePass" + x).style.borderColor = "";
                var GatePass = document.getElementById("txtOtherGatePass" + x).value.trim();
                var GatePassRemarks = document.getElementById("txtGatePassRemarks" + x).value.trim();
                var cbGatePassStatus = document.getElementById("cbOtherGatePassSts" + x).checked;
                if (cbGatePassStatus == true || GatePassRemarks !== "") {
                    if (GatePass == "") {
                        document.getElementById("txtOtherGatePass" + x).style.borderColor = "Red";
                        document.getElementById("txtOtherGatePass" + x).focus();
                        //$noCon("#txtAPTName" + x).select();
                        return false;
                    }
                }
            }
            else {
                //other than first row
                document.getElementById("txtOtherGatePass" + x).style.borderColor = "";
                var GatePass = document.getElementById("txtOtherGatePass" + x).value.trim();
                var GatePassRemarks = document.getElementById("txtGatePassRemarks" + x).value.trim();
                var cbGatePassStatus = document.getElementById("cbOtherGatePassSts" + x).checked;
                if (GatePass == "") {
                    document.getElementById("txtOtherGatePass" + x).style.borderColor = "Red";
                    document.getElementById("txtOtherGatePass" + x).focus();
                    //$noCon("#txtAPTName" + x).select();
                    return false;
                }


            }



            return true;
        }
        // checks every field in row
        function CheckAndHighlightOtherItem(x, FirstRow) {
           
            if (FirstRow == 1) {
                //first row condition
                document.getElementById("txtOtherOtherItem" + x).style.borderColor = "";
                var OtherItem = document.getElementById("txtOtherOtherItem" + x).value.trim();
                var OtherItemRemarks = document.getElementById("txtOtherItemRemarks" + x).value.trim();
                var cbOtherItemStatus = document.getElementById("cbOtherOtherItemSts" + x).checked;
                if (cbOtherItemStatus == true || OtherItemRemarks !== "") {
                    if (OtherItem == "") {
                        document.getElementById("txtOtherOtherItem" + x).style.borderColor = "Red";
                        document.getElementById("txtOtherOtherItem" + x).focus();
                        //$noCon("#txtAPTName" + x).select();
                        return false;
                    }
                }
            }
            else {
                //other than first row
                document.getElementById("txtOtherOtherItem" + x).style.borderColor = "";
                var OtherItem = document.getElementById("txtOtherOtherItem" + x).value.trim();
                var OtherItemRemarks = document.getElementById("txtOtherItemRemarks" + x).value.trim();
                var cbOtherItemStatus = document.getElementById("cbOtherOtherItemSts" + x).checked;
                if (OtherItem == "") {
                    document.getElementById("txtOtherOtherItem" + x).style.borderColor = "Red";
                    document.getElementById("txtOtherOtherItem" + x).focus();
                    //$noCon("#txtAPTName" + x).select();
                    return false;
                }


            }



            return true;
        }
        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
            var txt = field.value;
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            field.value = replaceText2;

        }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13) {
                // return false;
            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete,UP ARROW ,DOWN ARROW
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
            else {
                var retIsNum = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    retIsNum = false;
                }
                return retIsNum;
            }
        }
        function removeSpclChrcter(obj) {

            var txt = document.getElementById(obj).value;


            if (txt != "") {

                if (isNaN(txt)) {
                    document.getElementById(obj).value = "";
                    document.getElementById(obj).focus();
                    return false;

                }
                else {
                    var specialChars = "!@#$^&%*()+=-[]\/{}|:<>?,.";
                    if (!specialChars.test(txt)) {
                        document.getElementById(obj).value = "";

                        return false;
                    }
                }


            }

        }
        function RemoveTag(obj) {
            var txt = document.getElementById(obj).value;
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2;

        }

    </script>
    <script>
        //Table mgmnt

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            document.getElementById("freezelayer").style.display = "none";
            document.getElementById('Div1').style.display = "none";

            localStorage.clear();
            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;
            if (delView == "TRUE") {
                
                document.getElementById("imgAddOtherItem").style.display = "none";
                document.getElementById("imgAddGatePass").style.display = "none";
            }
            $noCon("div#DivCGuarantee input.ui-autocomplete-input").focus();
            $noCon("div#DivCGuarantee input.ui-autocomplete-input").select();
            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";
            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;

            var a = 0, b = 0;


            if (EditVal != "") {
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
                        if (json[key].LVECLRWKR_DTL_ID != "") {

                            if (json[key].TYPE == "0") {
                                EditListRowsGatePass(json[key].PARTICULAR, json[key].STATUS, json[key].REMARKS, json[key].LVECLRWKR_DTL_ID);
                                a++;
                            }
                            else {
                                EditListRowsOtherItem(json[key].PARTICULAR, json[key].STATUS, json[key].REMARKS, json[key].LVECLRWKR_DTL_ID);
                                b++;
                            }
                        }
                    }
                }
            }
           if(a==0) {
                AddMoreRowGatePass();
               
           }
           if (b == 0) {
               AddMoreRowOtherItem();
           }

        });

        var rowCountGatePass = 0;
        var rowCountOtherItem = 0;
        var rowCountLocalStore = 0;
        var tbClientTotalValues = '';
        tbClientTotalValues = [];

        function EditListRowsGatePass(PARTICULAR, STATUS, REMARKS, LVECLRWKR_DTL_ID) {


            var FrecRow = '<tr id="GatePassRowId_' + rowCountGatePass + '" ><td   id="tdIdGatePass' + rowCountGatePass + '" style="display: none;" >' + rowCountGatePass + '</td>';
            FrecRow += '<td   id="GatePassSlno' + rowCountGatePass + '" class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;" ></td  >';

            FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountGatePass + '"   class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;"><input type="text" id="txtOtherGatePass' + rowCountGatePass + '" value="' + PARTICULAR + '"  onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherGatePass' + rowCountGatePass + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
            FrecRow += '<input type="image" id="imgDelGP' + rowCountOtherItem + '"  class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowGatePass(' + rowCountGatePass + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
            //FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountGatePass + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + rowCountGatePass + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;"><input type="checkbox" id="cbOtherGatePassSts' + rowCountGatePass + '"><label for="cbOtherGatePassSts' + rowCountGatePass + '"></label></td>';
            FrecRow += '<td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;padding: 0 0 0 7px;">';
            FrecRow += '<textarea rows="2" cols="20" id="txtGatePassRemarks' + rowCountGatePass + '"  onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onkeyup="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onblur="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" style="height:40px;width: 100%;float: right; resize: none; font-family: Calibri;"></textarea>';
            FrecRow += '</td>'
            FrecRow += '<td id="tdEvtGatePass' + rowCountGatePass + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="tdDtlIdGatePass' + rowCountGatePass + '" style="display: none;">' + LVECLRWKR_DTL_ID + '</td>';
            FrecRow += '</tr>';
            jQuery('#TableFileUploadContainerPermit').append(FrecRow);
            document.getElementById("txtGatePassRemarks" + rowCountGatePass).value = REMARKS;
            if (STATUS == "1") {
                document.getElementById("cbOtherGatePassSts" + rowCountGatePass).checked = true;
            }
            else {
                document.getElementById("cbOtherGatePassSts" + rowCountGatePass).checked = false;
            }
            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;
            if (delView == "TRUE") {
             
                document.getElementById("txtOtherGatePass" + rowCountGatePass).disabled = true;
                document.getElementById("cbOtherGatePassSts" + rowCountGatePass).disabled = true;
                document.getElementById("txtGatePassRemarks" + rowCountGatePass).disabled = true;
                document.getElementById("imgDelGP" + rowCountGatePass).style.pointerEvents = "none";

                //txtGatePassRemarks0

            }
            rowCountGatePass++;
            return false;
        }
        function EditListRowsOtherItem(PARTICULAR, STATUS, REMARKS, LVECLRWKR_DTL_ID) {


            var FrecRow = '<tr id="OtherItemRowId_' + rowCountOtherItem + '" ><td   id="tdIdOtherItem' + rowCountOtherItem + '" style="display: none;" >' + rowCountOtherItem + '</td>';
            FrecRow += '<td   id="OtherItemSlno' + rowCountOtherItem + '" class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;" ></td  >';

            FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountOtherItem + '"   class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;"><input type="text" id="txtOtherOtherItem' + rowCountOtherItem + '" value="' + PARTICULAR + '"  onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherOtherItem' + rowCountOtherItem + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
            FrecRow += '<input type="image" id="imgDel' + rowCountOtherItem + '"  class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowOtherItem(' + rowCountOtherItem + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
            //FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountOtherItem + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + rowCountOtherItem + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;"><input type="checkbox" id="cbOtherOtherItemSts' + rowCountOtherItem + '"><label for="cbOtherOtherItemSts' + rowCountOtherItem + '"></label></td>';
            FrecRow += '<td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;padding: 0 0 0 7px;">';
            FrecRow += '<textarea rows="2" cols="20" id="txtOtherItemRemarks' + rowCountOtherItem + '"  onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onkeyup="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onblur="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" style="height:40px;width: 100%;float: right; resize: none; font-family: Calibri;"></textarea>';
            FrecRow += '</td>'

            FrecRow += '<td id="tdEvtOtherItem' + rowCountOtherItem + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="tdDtlIdOtherItem' + rowCountOtherItem + '" style="display: none;">' + LVECLRWKR_DTL_ID + '</td>';
            FrecRow += '<td id="tdChanged' + rowCountOtherItem + '" style="display: none;"></td>';
            FrecRow += '</tr>';
            jQuery('#tblOtherItemContainer').append(FrecRow);
            document.getElementById("txtOtherItemRemarks" + rowCountOtherItem).value = REMARKS;
            if (STATUS == "1") {
                document.getElementById("cbOtherOtherItemSts" + rowCountOtherItem).checked = true;
            }
            else {
                document.getElementById("cbOtherOtherItemSts" + rowCountOtherItem).checked = false;
            }
            
            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;
         
            if (delView == "TRUE") {
              
                document.getElementById("txtOtherOtherItem" + rowCountOtherItem).disabled = true;
                document.getElementById("cbOtherOtherItemSts" + rowCountOtherItem).disabled = true;
                document.getElementById("txtOtherItemRemarks" + rowCountOtherItem).disabled = true;
                document.getElementById("imgDel" + rowCountOtherItem).style.pointerEvents = "none";

                //txtGatePassRemarks0

            }
            rowCountOtherItem++;
            return false;
        }

        function AddMoreRowGatePass() {


            var FrecRow = '<tr id="GatePassRowId_' + rowCountGatePass + '" ><td   id="tdIdGatePass' + rowCountGatePass + '" style="display: none;" >' + rowCountGatePass + '</td>';
            FrecRow += '<td   id="GatePassSlno' + rowCountGatePass + '" class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;" ></td  >';
            FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountGatePass + '"   class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;"><input type="text" id="txtOtherGatePass' + rowCountGatePass + '" onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherGatePass' + rowCountGatePass + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
            FrecRow += '<input id="imgDelGP' + rowCountGatePass+'" type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowGatePass(' + rowCountGatePass + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
            //FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountGatePass + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + rowCountGatePass + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;"><input type="checkbox" id="cbOtherGatePassSts' + rowCountGatePass + '"><label for="cbOtherGatePassSts' + rowCountGatePass + '"></label></td>';
            FrecRow += '<td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;padding: 0 0 0 7px;">';
            FrecRow += '<textarea rows="2" cols="20" id="txtGatePassRemarks' + rowCountGatePass + '" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onkeyup="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onblur="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" style="height:40px;width: 100%;float: right; resize: none; font-family: Calibri;"></textarea>';
            FrecRow += '</td>'
            FrecRow += '<td id="tdEvtGatePass' + rowCountGatePass + '" style="display: none;">INS</td>';
            FrecRow += '<td id="tdDtlIdGatePass' + rowCountGatePass + '" style="display: none;"></td>';
            FrecRow += '</tr>';
            jQuery('#TableFileUploadContainerPermit').append(FrecRow);
            if (rowCountGatePass != 0) {
                document.getElementById("txtOtherGatePass" + rowCountGatePass).focus();
            }
           
            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;
            if (delView == "TRUE") {
              
                document.getElementById("txtOtherGatePass" + rowCountGatePass).disabled = true;
                document.getElementById("cbOtherGatePassSts" + rowCountGatePass).disabled = true;
                document.getElementById("txtGatePassRemarks" + rowCountGatePass).disabled = true;
              
                document.getElementById("imgDelGP" + rowCountGatePass).style.pointerEvents = "none";
               
                //txtGatePassRemarks0

            }

            rowCountGatePass++;
          
            return false;
        }

        function AddMoreRowOtherItem() {

          

            var FrecRow = '<tr id="OtherItemRowId_' + rowCountOtherItem + '" ><td   id="tdIdOtherItem' + rowCountOtherItem + '" style="display: none;" >' + rowCountOtherItem + '</td>';
            FrecRow += '<td   id="OtherItemSlno' + rowCountOtherItem + '" class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;" ></td  >';

            FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountOtherItem + '"   class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;"><input type="text" id="txtOtherOtherItem' + rowCountOtherItem + '" onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherOtherItem' + rowCountOtherItem + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
            FrecRow += '<input id="imgDel' + rowCountOtherItem + '" type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowOtherItem(' + rowCountOtherItem + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
            //FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountOtherItem + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + rowCountOtherItem + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;"><input type="checkbox" id="cbOtherOtherItemSts' + rowCountOtherItem + '"><label for="cbOtherOtherItemSts' + rowCountOtherItem + '"></label></td>';
            FrecRow += '<td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;padding: 0 0 0 7px;">';
            FrecRow += '<textarea rows="2" cols="20" id="txtOtherItemRemarks' + rowCountOtherItem + '" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onkeyup="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onblur="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" style="height:40px;width: 100%;float: right; resize: none; font-family: Calibri;"></textarea>';
            FrecRow += '</td>'
            FrecRow += '<td id="tdEvtOtherItem' + rowCountOtherItem + '" style="display: none;">INS</td>';
            FrecRow += '<td id="tdDtlIdOtherItem' + rowCountOtherItem + '" style="display: none;"></td>';
            FrecRow += '</tr>';
            jQuery('#tblOtherItemContainer').append(FrecRow);
            if (rowCountOtherItem != 0) {
                document.getElementById("txtOtherOtherItem" + rowCountOtherItem).focus();
            }

            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;

            if (delView == "TRUE") {

                document.getElementById("txtOtherOtherItem" + rowCountOtherItem).disabled = true;
                document.getElementById("cbOtherOtherItemSts" + rowCountOtherItem).disabled = true;
                document.getElementById("txtOtherItemRemarks" + rowCountOtherItem).disabled = true;
                document.getElementById("imgDel" + rowCountOtherItem).style.pointerEvents = "none";

                //txtGatePassRemarks0

            }
            rowCountOtherItem++;

            return false;
        }

        function removeRowGatePass(removeNum, CofirmMsg) {
            //alert(removeNum);
            if (confirm(CofirmMsg)) {
                var evt = document.getElementById("tdEvtGatePass" + removeNum).innerHTML;
                if (evt == 'UPD') {
                    var detailId = document.getElementById("tdDtlIdGatePass" + removeNum).innerHTML;
                    var CanclIds = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value;
                    if (CanclIds == '') {
                        document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = detailId;
                    }
                    else {
                        document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value + ',' + detailId;
                    }
                }
                var row_index = jQuery('#GatePassRowId_' + removeNum).index();
                var BforeRmvTableRowCount = document.getElementById("TableFileUploadContainerPermit").rows.length;

                jQuery('#GatePassRowId_' + removeNum).remove();

                var TableRowCount = document.getElementById("TableFileUploadContainerPermit").rows.length;

                if (TableRowCount != 0) {
                    //var idlast = $noC('#TableFileUploadContainerPermit tr:last').attr('id');

                    //if (idlast != "") {
                    //    var res = idlast.split("_");

                    //    document.getElementById("tdInx" + res[1]).innerHTML = " ";
                    //    document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
                    //}
                }
                else {
                    AddMoreRowGatePass();
                }


                return false;
            }
            else {
                return false;

            }
        }
        function removeRowOtherItem(removeNum, CofirmMsg) {
            if (confirm(CofirmMsg)) {

                var evt = document.getElementById("tdEvtOtherItem" + removeNum).innerHTML;
                if (evt == 'UPD') {
                    var detailId = document.getElementById("tdDtlIdOtherItem" + removeNum).innerHTML;
                    var CanclIds = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value;
                    if (CanclIds == '') {
                        document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = detailId;
                    }
                    else {
                        document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value + ',' + detailId;
                    }
                }

                var row_index = jQuery('#OtherItemRowId_' + removeNum).index();
                var BforeRmvTableRowCount = document.getElementById("tblOtherItemContainer").rows.length;

                jQuery('#OtherItemRowId_' + removeNum).remove();

                var TableRowCount = document.getElementById("tblOtherItemContainer").rows.length;

                if (TableRowCount != 0) {
                    //var idlast = $noC('#TableFileUploadContainerPermit tr:last').attr('id');

                    //if (idlast != "") {
                    //    var res = idlast.split("_");

                    //    document.getElementById("tdInx" + res[1]).innerHTML = " ";
                    //    document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
                    //}
                }
                else {
                    AddMoreRowOtherItem();
                }


                return false;
            }
            else {
                return false;

            }
        }

        function CheckaddMoreRows(tblType) {
            var addRowtable;
            var addRowResult = true;
            if (tblType == "GATEPASS") {
                addRowtable = document.getElementById("TableFileUploadContainerPermit");
                for (var i = 0; i < addRowtable.rows.length; i++) {

                    var row = addRowtable.rows[i];
                    var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                    if (CheckAndHighlightGatePass(xLoop, 0) == false) {
                        addRowResult = false;
                    }
                }
                if (addRowResult == false) {
                    return false;
                }
                else {
                    AddMoreRowGatePass();
                    return false;
                }

            }
            else {
                addRowtable = document.getElementById("tblOtherItemContainer");

                for (var i = 0; i < addRowtable.rows.length; i++) {

                    var row = addRowtable.rows[i];
                    var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                    if (CheckAndHighlightOtherItem(xLoop, 0) == false) {
                        addRowResult = false;
                    }

                }
                if (addRowResult == false) {
                    return false;
                }
                else {
                    AddMoreRowOtherItem();
                    return false;
                }
            }




        }
        function validateClearanceForms() {

            if (confirm("Are you sure you want to approve?")) {

            }
            else {
                return false;
            }

        }

        function RejectClearanceForm() {

            if (confirm("Are you sure you want to reject?")) {
                OpenCancelViewRjct();
                document.getElementById("cphMain_TextBox1").focus();
                return false;
            }
            else {
                return false;
            }

        }

        function OpenCancelViewRjct() {

            document.getElementById("Div1").style.display = "block";
            document.getElementById("freezelayer").style.display = "";
            return false;

        }
        function CloseCancelViewRjct() {
            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
            document.getElementById("Div1").style.display = "none";
            document.getElementById("freezelayer").style.display = "none";
            return false;

        }

        //validation when cancel process
        function ValidateCancelReason() {
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=TextBox1.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TextBox1.ClientID%>").value = replaceText2;



            var divErrorMsg = document.getElementById('div2').style.visibility = "hidden";
            var txthighlit = document.getElementById("<%=TextBox1.ClientID%>").style.borderColor = "";
            var Reason = document.getElementById("<%=TextBox1.ClientID%>").value.trim();
            if (Reason == "") {
                document.getElementById('div2').style.visibility = "visible";
                document.getElementById("<%=Label1.ClientID%>").innerHTML = "Please fill this out";
                document.getElementById("<%=TextBox1.ClientID%>").style.borderColor = "Red";
                return false;
            }
            else {
                Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                Reason = Reason.replace(/[ ]{2,}/gi, " ");
                Reason = Reason.replace(/\n /, "\n");
                if (Reason.length < "10") {
                    document.getElementById('div2').style.visibility = "visible";
                    document.getElementById("<%=Label1.ClientID%>").innerHTML = "Reject reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=TextBox1.ClientID%>").style.borderColor = "Red";
                    return false;
                }
            }
           

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenTotalData" runat="server" />
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenDelView" runat="server" />

      <asp:HiddenField ID="HiddenFieldPage" runat="server" />
    <div id="divMessageArea" style="display: none;">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght" style="padding-top: 0%;">


        <div id="divErrorTotal" style="visibility: hidden">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>
        <br />
        <br />
        <br />

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 2%; top: 42%; height: 26.5px;">

            <%-- <a href="gen_Product_MasterList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div style="width: 100%;">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />

            <asp:UpdatePanel runat="server">
                <ContentTemplate>

               
            <div class="div-Contact-details" style="float: left; margin-bottom: 2%; height: 145px;">
                <div id="DivCGuarantee" class="eachform" style="width: 47%; float: left;margin-top:0.3%;">
                    <h2 style="margin-top: 1%;">Employee Name*</h2>
                    <asp:DropDownList ID="ddlEmployee" Height="30px" Width="294px" class="form1" style="margin-right: 2%;" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>



                </div>
                <div class="eachform" style="width: 47%; padding-left: 6%;margin-top:0.3%;">
                    <h2 style="margin-top: 1%;">Leave*</h2>
                    <asp:DropDownList ID="ddlLeave" Height="30px" Width="294px" class="form1" AutoPostBack="true" OnSelectedIndexChanged="ddlLeave_SelectedIndexChanged" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>



                </div>

                <div style="float: left; width: 100%">
                    <div class="eachform" style="width: 47%; float: left;margin-top:0.5%;">
                        <h2 ">Employee No.</h2>
                        <asp:Label ID="lblEmpNo" style="font-family: Calibri;font-size: 14px;color: #000;margin-left: 17%;"  class="lblTop" runat="server"></asp:Label>

                    </div>

                    <div class="eachform" style="width: 47%; padding-left: 6%;margin-top:0.5%;">
                        <h2 >Designation</h2>

                        <asp:Label ID="lblDesig" style="font-family: Calibri;font-size: 14px;color: #000;margin-left: 25%;"  class="lblTop" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="eachform" style="width: 47%; float: left;margin-top:0.5%;">
                    <h2 style="margin-bottom: 0%;">Department</h2>

                    <asp:Label ID="lblDept" style="font-family: Calibri;font-size: 14px;color: #000;margin-left: 19%;" class="lblTop" runat="server"></asp:Label>

                </div>
                <div class="eachform" style="width: 47%; padding-left: 6%;margin-top:0.5%;">
                    <h2 style="width:41%;">Division</h2>

                    <asp:Label ID="lblDivision" style="font-family: Calibri;font-size: 14px;color: #000;word-break:break-all;width:59%;" class="lblTop" runat="server"></asp:Label>

                </div>

                <div class="eachform" style="width: 47%; float: left;margin-top:0.5%;">
                    <h2 >Date of Travel</h2>
                    <asp:Label ID="lblDateOfTravel" class="lblTop" style="font-family: Calibri;font-size: 14px;color: #000;margin-left: 17%;" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; padding-left: 6%;margin-top:0.5%;">
                    <h2 >Expected Date of Return</h2>
                    <asp:Label ID="lblDateOfReturn" class="lblTop" style="font-family: Calibri;font-size: 14px;color: #000;margin-left: 7.5%;" runat="server"></asp:Label>
                </div>

            </div>
                     </ContentTemplate>
            </asp:UpdatePanel>
            <%--test--%>
            <table id="ReportTable" class="main_table" cellspacing="0" cellpadding="2px" style="margin-bottom: 0%;">
                <thead>
                    <tr class="main_table_head">
                        <th class="thT" style="width: 5%; word-wrap: break-word; text-align: center;">SL#</th>
                        <th class="thT" style="width: 45%; word-wrap: break-word; text-align: left;">Particulars</th>
                        <th class="thT" style="width: 10%; word-wrap: break-word; text-align: center;">Submit</th>
                        <th class="thT" style="width: 40%; word-wrap: break-word; text-align: left;">Remarks</th>
                    </tr>
                </thead>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">1</td>
                    <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">QP Pass</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox  runat="server" ID="cbQpPass" /><label for='cphMain_cbQpPass'></label></td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;padding: 0 0 0 7px;">
                        <asp:TextBox ID="txtQpPassRemarks" Height="40px" Width="100%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtQpPassRemarks,450);" onkeyup="textCounter(cphMain_txtQpPassRemarks,450);" onblur="textCounter(cphMain_txtQpPassRemarks,450);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">2</td>
                    <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">Sim Card</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox  runat="server" ID="cbSimCard" /><label for='cphMain_cbSimCard'></label></td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;padding: 0 0 0 7px;">
                        <asp:TextBox ID="txtSimCardRemarks" Height="40px" Width="100%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtSimCardRemarks,450);" onkeyup="textCounter(cphMain_txtSimCardRemarks,450);" onblur="textCounter(cphMain_txtSimCardRemarks,450);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">3</td>
                    <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">Driving Licence</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox  runat="server" ID="cbDrivingLic"  /><label for='cphMain_cbDrivingLic'></label></td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;padding: 0 0 0 7px;">
                        <asp:TextBox ID="txtdrivingLicRemarks" Height="40px" Width="100%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtdrivingLicRemarks,450);" onkeyup="textCounter(cphMain_txtdrivingLicRemarks,450);" onblur="textCounter(cphMain_txtdrivingLicRemarks,450);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">4</td>
                    <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">Tools/company belongings</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox  runat="server" ID="cbToolsAndCompany" /><label for='cphMain_cbToolsAndCompany'></label></td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;padding: 0 0 0 7px;">
                        <asp:TextBox ID="txtToolsAndCompanyRemarks" Height="40px" Width="100%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtToolsAndCompanyRemarks,450);" onkeyup="textCounter(cphMain_txtToolsAndCompanyRemarks,450);" onblur="textCounter(cphMain_txtToolsAndCompanyRemarks,450);"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">5</td>
                    <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">Clearance from traffic Dept (Only for Drivers)</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox  runat="server" ID="cbClearanceTrafficDept" /><label for='cphMain_cbClearanceTrafficDept'></label></td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;padding: 0 0 0 7px;">
                        <asp:TextBox ID="txtClearanceTrafficRemarks" Height="40px" Width="100%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtClearanceTrafficRemarks,450);" onkeyup="textCounter(cphMain_txtClearanceTrafficRemarks,450);" onblur="textCounter(cphMain_txtClearanceTrafficRemarks,450);"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">6</td>
                    <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">Mess Amount</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox  runat="server" ID="cbMessAmount" /><label  for='cphMain_cbMessAmount'></label></td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;padding: 0 0 0 7px;">
                        <asp:TextBox ID="txtMessAmountRemarks" Height="40px" Width="100%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtMessAmountRemarks,450);" onkeyup="textCounter(cphMain_txtMessAmountRemarks,450);" onblur="textCounter(cphMain_txtMessAmountRemarks,450);"></asp:TextBox>

                    </td>
                </tr>

            </table>

            <div id="divPerAtch" runat="server" style="">
                <%--   overflow-y: auto;--%>
                <table id="Table2" class="main_table" cellspacing="0" cellpadding="2px" style="margin-bottom: 0%;">
                    <tr>
                        <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">7</td>
                        <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">Any other Gate Passes (Specify)
                        <input type="image" id="imgAddGatePass" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRows('GATEPASS');" style="margin-right: 10%; float: right; cursor: pointer;" />
                        </td>
                        <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>

                        <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;padding: 0 0 0 7px;"></td>
                    </tr>

                </table>
                <table id="TableFileUploadContainerPermit" class="main_table" cellspacing="0" cellpadding="2px" style="margin-bottom: 0%;">
                </table>

                <table id="Table1" class="main_table" cellspacing="0" cellpadding="2px" style="margin-bottom: 0%;">
                    <tr>
                        <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">8</td>
                        <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">Others
                            <input type="image" id="imgAddOtherItem" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRows('OTHERITEM');" style="margin-right: 10%; float: right; cursor: pointer;" />
                        </td>
                        <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>
                        <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;padding: 0 0 0 7px;"></td>
                    </tr>
                </table>
                <table id="tblOtherItemContainer" class="main_table" cellspacing="0" cellpadding="2px">
                </table>
            </div>
            <div class="eachform" style="width: 47%;">
                <h2 style="margin-top: 1%;">Comments</h2>
                <asp:TextBox ID="txtComments" class="form1" Height="80px" Width="276px" Style="float: right; resize: none; font-family: Calibri;border: 1px solid #665656;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtComments,450);" onkeyup="textCounter(cphMain_txtComments,450);" onblur="textCounter(cphMain_txtComments,450);"></asp:TextBox>
            </div>

            <br />
            <div class="eachform" style="margin-top: 3%;">
                <div class="subform" style="width: 60%;">
                     <asp:Button ID="btnApprove" runat="server" class="save" Text="Approve" OnClientClick="return validateClearanceForms();"  OnClick="btnApprove_Click" />
                       <asp:Button ID="btnReject" runat="server" class="save" Text="Reject" OnClientClick="return RejectClearanceForm();" OnClick="btnReject_Click" />
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return validateClearanceForm();" />
                    <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return validateClearanceForm();" />
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClientClick="return validateClearanceForm();" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return validateClearanceForm();" />
                    <asp:Button ID="btnClear" runat="server" class="save" Text="Clear" OnClientClick="return ConfirmClear();" />
                    <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                </div>
            </div>


        </div>



        
             <div id="Div1" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelViewRjct();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Clearance Form Worker</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="div2"  style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="Label1" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Reject Reason*</label>
                        <asp:TextBox ID="TextBox1" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_TextBox1)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_TextBox1,450)" onkeyup="textCounter(cphMain_TextBox1,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" OnClick="btnReject_Click"/>
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="return CloseCancelViewRjct();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   


          <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>


    </div>
</asp:Content>
