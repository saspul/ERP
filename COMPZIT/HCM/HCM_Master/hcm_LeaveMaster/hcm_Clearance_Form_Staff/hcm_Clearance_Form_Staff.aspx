<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Clearance_Form_Staff.aspx.cs" Inherits="HCM_HCM_Master_hcm_LeaveMaster_hcm_Clearance_Form_Staff_hcm_Clearance_Form_Staff" %>

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




        .tdT {
            padding: 0 0 0 0;
        }

        .form1 {
            width: 98%;
        }

        input[type="checkbox"] {
            width: 100%;
        }

        .div-Contact-details {
            /*border: 1px solid #cad1be;
            padding: 1% 2% 3% 2%;
            margin-top: 0%;
            display: block;
            */
            width: 95.5%;
            padding: 1% 2% 3% 2%;
            min-height: 75px;
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





        .cont_rght {
            width: 95%;
        }
    </style>
      <style type="text/css">
      

         input[type="file"] {
            position: relative;
            z-index: 1;
            margin-left: -78px;
            display: none;
        }
 .custom-file-upload {
            border: 1px solid #ccc;
            display: inline-block;
            padding: 3px 8px;
            cursor: pointer;
            position: relative;
            z-index: 2;
            background: white;
           
        }

 

      
    </style>
    <style>
        /* Styles the thumbnail */
        a.lightbox img {
            height: 150px;
            border: 3px solid white;
            box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
            margin: 94px 20px 20px 20px;
        }

        /* Styles the lightbox, removes it from sight and adds the fade-in transition */
        .lightbox-target {
            position: fixed;
            top: -100%;
            width: 100%;
            background: rgba(0, 0, 0, 0.7);
            width: 60%;
            opacity: 0;
            -webkit-transition: opacity .5s ease-in-out;
            -moz-transition: opacity .5s ease-in-out;
            -o-transition: opacity .5s ease-in-out;
            transition: opacity .5s ease-in-out;
            overflow: hidden;
        }

            /* Styles the lightbox image, centers it vertically and horizontally, adds the zoom-in transition and makes it responsive using a combination of margin and absolute positioning */
            .lightbox-target img {
                margin: auto;
                position: absolute;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                max-height: 0%;
                max-width: 0%;
                border: 3px solid white;
                box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
                box-sizing: border-box;
                -webkit-transition: .5s ease-in-out;
                -moz-transition: .5s ease-in-out;
                -o-transition: .5s ease-in-out;
                transition: .5s ease-in-out;
            }

        /* Styles the close link, adds the slide down transition */
        a.lightbox-close {
            display: block;
            width: 50px;
            height: 50px;
            box-sizing: border-box;
            background: white;
            color: black;
            text-decoration: none;
            position: absolute;
            top: -80px;
            right: 0;
            -webkit-transition: .5s ease-in-out;
            -moz-transition: .5s ease-in-out;
            -o-transition: .5s ease-in-out;
            transition: .5s ease-in-out;
        }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:before {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(45deg);
                -moz-transform: rotate(45deg);
                -o-transform: rotate(45deg);
                transform: rotate(45deg);
            }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:after {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(-45deg);
                -moz-transform: rotate(-45deg);
                -o-transform: rotate(-45deg);
                transform: rotate(-45deg);
            }

        /* Uses the :target pseudo-class to perform the animations upon clicking the .lightbox-target anchor */
        .lightbox-target:target {
            opacity: 1;
            top: 0;
            bottom: 0;
            z-index: 3;
            right: 18%;
            z-index: 102;
        }

            .lightbox-target:target img {
                max-height: 100%;
                max-width: 80%;
            }

            .lightbox-target:target a.lightbox-close {
                top: 0px;
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

                $au('#cphMain_ddlMobileNoHndOvr').selectToAutocomplete1Letter();
                $au('#cphMain_ddlCarKeyAndDoc').selectToAutocomplete1Letter();
                $au('#cphMain_ddlDrvLicHndOvr').selectToAutocomplete1Letter();
                $au('#cphMain_ddlH2SBAHndOvr').selectToAutocomplete1Letter();             
                $au('#cphMain_ddlOfficialKeysHndOvr').selectToAutocomplete1Letter();
                $au('#cphMain_ddlImprestHndOvr').selectToAutocomplete1Letter();
                $au('#cphMain_ddlStaffAdvanceHndOvr').selectToAutocomplete1Letter();
                $au('#cphMain_ddlTelephoneBillsHndOvr').selectToAutocomplete1Letter();
                $au('#cphMain_ddlItClearanceHndOvr').selectToAutocomplete1Letter();

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
        function OpenCancelView() {

            document.getElementById("MymodalCancelView").style.display = "block";
            document.getElementById("freezelayer").style.display = "";
            return false;

        }
        function CloseCancelView() {
                document.getElementById('divMessageArea').style.display = "none";
                document.getElementById('imgMessageArea').src = "";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                document.getElementById("MymodalCancelView").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
                return false;
              
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
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
        function isTagWithEnter(evt) {
            IncrmntConfrmCounter();
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
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
                    if (document.getElementById("<%=HiddenFieldCancelPage.ClientID%>").value == "LR") {
                        window.location.href = "/HCM/HCM_Master/hcm_LeaveMaster/hcm_Leave_Request/hcm_Leave_Request_List.aspx";
                    }
                    else if (document.getElementById("<%=HiddenFieldCancelPage.ClientID%>").value == "LA") {
                        window.location.href = "/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Approval/hcm_Clearance_Form_Approval_List.aspx";
                    }
                    else {
                        window.location.href = "/HCM/HCM_Master/hcm_Exit_Management/hcm_Resignation_Master/hcm_Resignation_Master.aspx";
                    }
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                if (document.getElementById("<%=HiddenFieldCancelPage.ClientID%>").value == "LR") {
                    window.location.href = "/HCM/HCM_Master/hcm_LeaveMaster/hcm_Leave_Request/hcm_Leave_Request_List.aspx";
                }
                else if (document.getElementById("<%=HiddenFieldCancelPage.ClientID%>").value == "LA") {
                    window.location.href = "/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Approval/hcm_Clearance_Form_Approval_List.aspx";
                }
                else {
                    window.location.href = "/HCM/HCM_Master/hcm_Exit_Management/hcm_Resignation_Master/hcm_Resignation_Master.aspx";
                }
                return false;
            }
        }
        function ConfirmClear() {
            if (confirmbox > 0) {
                if (confirm("Are You Sure You Want To Clear?")) {
                    window.location.href = "hcm_Clearance_Form_Staff.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_Clearance_Form_Staff.aspx";
                return false;
            }
        }
        function validateClearanceForm() {
            ret = true;
            document.getElementById("<%=hiddenEmpDdlData.ClientID%>").value = 0;
            //document.getElementById('divMessageArea').style.display = "none";
            document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = '';

            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtComments.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtComments.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtMobNoRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtMobNoRemarks.ClientID%>").value = replaceText2;

             NameWithoutReplace = document.getElementById("<%=txtCarKeysDocRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCarKeysDocRemarks.ClientID%>").value = replaceText2;

             NameWithoutReplace = document.getElementById("<%=txtdrivingLicRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtdrivingLicRemarks.ClientID%>").value = replaceText2;

             NameWithoutReplace = document.getElementById("<%=txtH2SBACardsRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtH2SBACardsRemarks.ClientID%>").value = replaceText2;

             NameWithoutReplace = document.getElementById("<%=txtOfficialKeyRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOfficialKeyRemarks.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtImpresetRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtImpresetRemarks.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtStaffAdvanceRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtStaffAdvanceRemarks.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtTeleBillsPerRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTeleBillsPerRemarks.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtItClearanceRemarks.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtItClearanceRemarks.ClientID%>").value = replaceText2;


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
                for (var i = tableOtherItem.rows.length-1; i >=0 ; i--) {
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
                for (var i = table.rows.length-1; i >=0 ; i--) {
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


                    NameWithoutReplace = GatePass;
                    replaceText1 = NameWithoutReplace.replace(/</g, "");
                    replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("txtOtherGatePass" + validRowID).value = replaceText2;



                    var GatePassRemarks = document.getElementById("txtGatePassRemarks" + validRowID).value.trim();

                    NameWithoutReplace = GatePassRemarks;
                    replaceText1 = NameWithoutReplace.replace(/</g, "");
                    replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("txtGatePassRemarks" + validRowID).value = replaceText2;
                    GatePassRemarks = document.getElementById("txtGatePassRemarks" + validRowID).value.trim();

                    //ddlEmpGatePass0
                    var varddlCat = document.getElementById("ddlEmpGatePass" + validRowID);
                    var ddlEmpGatePassVal = varddlCat.options[varddlCat.selectedIndex].value;
                    if (ddlEmpGatePassVal == "--SELECT--")
                        ddlEmpGatePassVal = 0;
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

                    var tblType = "GATEPASS";
                    if (GatePass != "") {
                        addToLocalStorage(GatePass, ddlEmpGatePassVal, GatePassRemarks, DetailID, tblType, EvtAction);
                    }

                }

                //other table
                for (var i = 0; i < tableOtherItem.rows.length; i++) {
                    // var row = tableOtherItem.rows[i];

                    var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);

                    var OtherItem = document.getElementById("txtOtherOtherItem" + validRowID).value.trim();

                    NameWithoutReplace = OtherItem;
                    replaceText1 = NameWithoutReplace.replace(/</g, "");
                    replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("txtOtherOtherItem" + validRowID).value = replaceText2;

                    var OtherItemRemarks = document.getElementById("txtOtherItemRemarks" + validRowID).value.trim();

                    NameWithoutReplace = OtherItemRemarks;
                    replaceText1 = NameWithoutReplace.replace(/</g, "");
                    replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("txtOtherItemRemarks" + validRowID).value = replaceText2;
                    OtherItemRemarks = document.getElementById("txtOtherItemRemarks" + validRowID).value.trim();

                    //ddlEmpOtherItem0
                    var varddlCat = document.getElementById("ddlEmpOtherItem" + validRowID);
                    var ddlEmpOtherItemVal = varddlCat.options[varddlCat.selectedIndex].value;
                    if (ddlEmpOtherItemVal == "--SELECT--")
                        ddlEmpOtherItemVal = 0;
                    var tbDetailID = document.getElementById("tdDtlIdOtherItem" + validRowID).innerHTML;
                    var EvtAction = document.getElementById("tdEvtOtherItem" + validRowID).innerHTML;
                    var DetailID = "";
                    if (tbDetailID == "") {
                        DetailID = 0;
                    }
                    else {
                        DetailID = tbDetailID;
                    }

                    var tblType = "OTHERITEM";
                    if (OtherItem != "") {
                        addToLocalStorage(OtherItem, ddlEmpOtherItemVal, OtherItemRemarks, DetailID, tblType, EvtAction);
                    }
                }


            }
            else if (ret == false) {
                ErrMsg();
            }
            var ddlEmp = document.getElementById("<%=ddlEmployee.ClientID%>").value;
            if (ddlEmp == "--SELECT EMPLOYEE--" || ddlEmp == "") {
                   
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                     $noCon("div#divEmp input.ui-autocomplete-input").css("borderColor", "Red");
                     $noCon("div#divEmp input.ui-autocomplete-input").focus();
                     $noCon("div#divEmp input.ui-autocomplete-input").select();
               

                 document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=ddlEmployee.ClientID%>").focus();
                 ret = false;
            }



            return ret;
        }

        function addToLocalStorage(particular, ddlEmpVal, textRemarks, DetailID, tblType, EvtAction) {
            //alert(textRemarks);
            var $add = jQuery.noConflict();


            var client = JSON.stringify({
                ROWID: "" + rowCountLocalStore + "",
                ITEM: "" + particular + "",
                EMPID: "" + ddlEmpVal + "",
                REMARKS: "" + textRemarks + "",
                TYPE: "" + tblType + "",
                DETAILID: "" + DetailID + "",
                EVTACTION: "" + EvtAction + ""
            });
            tbClientTotalValues.push(client);
            document.getElementById("<%=hiddenTotalData.ClientID%>").value = JSON.stringify(tbClientTotalValues);
                 //alert(document.getElementById("<%=hiddenTotalData.ClientID%>").value);
            rowCountLocalStore++;
        }
        // checks every field in row
        function CheckAndHighlightGatePass(x, FirstRow) {

            if (FirstRow == 1) {
                //first row condition
                document.getElementById("txtOtherGatePass" + x).style.borderColor = "";
                var GatePass = document.getElementById("txtOtherGatePass" + x).value.trim();
                var GatePassRemarks = document.getElementById("txtGatePassRemarks" + x).value.trim();

                //ddlEmpGatePass0
                var varddlCat = document.getElementById("ddlEmpGatePass" + x);
                var ddlEmpGatePassVal = varddlCat.options[varddlCat.selectedIndex].value;

              
                if (ddlEmpGatePassVal != 0 || GatePassRemarks != "") {
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
                //ddlEmpGatePass0
                var varddlCat = document.getElementById("ddlEmpOtherItem" + x);
                var ddlEmpOtherItemVal = varddlCat.options[varddlCat.selectedIndex].value;

                if (ddlEmpOtherItemVal != 0 || OtherItemRemarks != "") {
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
                if (OtherItem == "") {
                    document.getElementById("txtOtherOtherItem" + x).style.borderColor = "Red";
                    document.getElementById("txtOtherOtherItem" + x).focus();
                    //$noCon("#txtAPTName" + x).select();
                    return false;
                }


            }



            return true;
        }

        function FillddlEmployee(rowCount, mode) {
            var ddlTestDropDownListXML = "";
            if (mode == "GATEPASS") {
                ddlTestDropDownListXML = $noCon("#ddlEmpGatePass" + rowCount);
            }
            else {
                ddlTestDropDownListXML = $noCon("#ddlEmpOtherItem" + rowCount);
            }
            var intOrgID = '<%= Session["ORGID"] %>';
            var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableEmployee";
            if (document.getElementById("<%=hiddenEmpDdlData.ClientID%>").value != 0) {
                ddlEmpdata = document.getElementById("<%=hiddenEmpDdlData.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                // Now find the Table from response and loop through each item (row).
                $noCon(ddlEmpdata).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('USR_ID').text();
                    var OptionText = $noCon(this).find('USR_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });
            }

            else {
                $noCon.ajax({
                    type: "POST",
                    url: "hcm_Clearance_Form_Staff.aspx/DropdownEmployeeBind",
                    data: '{tableName:"' + tableName + '",intOrgID:"' + intOrgID + '",intCorrpID:"' + intCorrpID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon("<option>--SELECT--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $noCon(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('USR_ID').text();
                            var OptionText = $noCon(this).find('USR_NAME').text();
                            // Create an Option for DropDownList.
                            var option = $noCon("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);

                            ddlTestDropDownListXML.append(option);
                        });
                    },
                    failure: function (response) {

                    }
                });
            }

            //if (mode == "GATEPASS") {
            //    $au("#ddlEmpGatePass" + rowCount).selectToAutocomplete1Letter();
            //}
            //else {
            //    $au("#ddlEmpOtherItem" + rowCount).selectToAutocomplete1Letter();
            //}

          

        }
        function Autocomplt() {
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
          
        }


        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
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
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
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
          
            if (document.getElementById("<%=HiddenFieldParentPage.ClientID%>").value == "Resg") {
                document.getElementById("divDateTrvl").style.display = "none";
                document.getElementById("divDateRetrn").style.display = "none";
              
                
            }

            for (var i = 1; i <= 9; i++) {
            if (document.getElementById("cphMain_lblEntry").innerText == "Add Clearance Form Staff") {
               
                    document.getElementById("cphMain_view" + i).style.display = "none";
            }
           
            }
           
            document.getElementById("freezelayer").style.display = "none";
            document.getElementById('MymodalCancelView').style.display = "none";
            localStorage.clear();
            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;
           
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
                        if (json[key].LVECLRSTF_DTL_ID != "") {

                            if (json[key].TYPE == "1") {
                               
                                EditListRowsGatePass(json[key].SUBJECT, json[key].HNDED_USR_ID, json[key].HNDED_USR_NAME, json[key].DECISION, json[key].COMMENTS, json[key].REMARKS, json[key].LVECLRSTF_DTL_ID);
                                a++;
                            }
                            else {
                                EditListRowsOtherItem(json[key].SUBJECT, json[key].HNDED_USR_ID, json[key].HNDED_USR_NAME, json[key].DECISION, json[key].COMMENTS, json[key].REMARKS, json[key].LVECLRSTF_DTL_ID);
                                b++;
                            }
                        }
                    }
                }
            }
            if (a == 0) {
                AddMoreRowGatePass();

            }
            if (b == 0) {
                AddMoreRowOtherItem();
            }
            if (delView == "TRUE") {

                //document.getElementById("imgAddOtherItem").style.display = "none";
                //document.getElementById("imgAddGatePass").style.display = "none";
                document.getElementById("Image2").style.display = "none";
                document.getElementById("Image3").style.display = "none";
                document.getElementById("lblLicence").style.pointerEvents = "none";
                document.getElementById("ClearImageLicense").style.display = "none";
                
            }

        });

        var rowCountGatePass = 0;
        var rowCountOtherItem = 0;
        var rowCountLocalStore = 0;
        var tbClientTotalValues = '';
        tbClientTotalValues = [];

        function viewComment(i) {
         
            if (document.getElementById("cphMain_divcmnt" + i).innerHTML != "null") {
                document.getElementById("<%=txtCnclReason.ClientID%>").value = document.getElementById("cphMain_divcmnt" + i).innerHTML;
                }
            else {
            document.getElementById("<%=txtCnclReason.ClientID%>").value = "";
            }
           
           OpenCancelView();
        }


        function viewCommentGatePass(divCount) {
            if (document.getElementById("divGatePass" + divCount).innerHTML != "null") {
                document.getElementById("<%=txtCnclReason.ClientID%>").value = document.getElementById("divGatePass" + divCount).innerHTML;
            }
            else {
                document.getElementById("<%=txtCnclReason.ClientID%>").value = "";
            }
            OpenCancelView();
        }
        function viewCommentOtherItem(divCount) {
            // alert(document.getElementById("divOtherItem" + divCount).innerHTML);
        if (document.getElementById("divOtherItem" + divCount).innerHTML != "null") {
                document.getElementById("<%=txtCnclReason.ClientID%>").value = document.getElementById("divOtherItem" + divCount).innerHTML;
         }
          else {
            document.getElementById("<%=txtCnclReason.ClientID%>").value = "";
           }
            OpenCancelView();
        }
        function EditListRowsGatePass(SUBJECT, HNDED_USR_ID, HNDED_USR_NAME, DECISION, COMMENTS, REMARKS, LVECLRSTF_DTL_ID) {
            var strDecision = "";
            // 0-Pending 1-Approved 2-Rejected
            if (DECISION == "0") {
                strDecision = "Pending";
            }
            else if (DECISION == "1") {
                strDecision = "Approved";
            }
            else if (DECISION == "2") {
                strDecision = "Rejected";
            }
            if (HNDED_USR_ID == "") {
                strDecision = "";
            }

          

            var FrecRow = '<tr id="GatePassRowId_' + rowCountGatePass + '" ><td   id="tdIdGatePass' + rowCountGatePass + '" style="display: none;" >' + rowCountGatePass + '</td>';
            FrecRow += '<td   id="GatePassSlno' + rowCountGatePass + '" class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;" ></td  >';
            if (document.getElementById("<%=HiddenDelView.ClientID%>").value == "TRUE") {
              
                FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountGatePass + '"   class="tdT" style="width: 38.7%; word-break: break-all; word-wrap: break-word; text-align: left;"><input disabled type="text" id="txtOtherGatePass' + rowCountGatePass + '" onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherGatePass' + rowCountGatePass + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
                FrecRow += '<input disabled type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowGatePass(' + rowCountGatePass + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
                FrecRow += '<td class="tdT" style="width: 19.5%; word-break: break-all; word-wrap: break-word; text-align: center;"><select disabled id="ddlEmpGatePass' + rowCountGatePass + '" onkeypress="return DisableEnter(event);" class="form1" /></td>';
                FrecRow += '<td class="tdT" style="width: 14.5%; word-break: break-all; word-wrap: break-word; text-align: center;">' + strDecision + '</td>';
                if (HNDED_USR_ID == "") {
                    FrecRow += '<td class="tdT" style="width: 6.8%; word-break: break-all; word-wrap: break-word; text-align: center;"><div class="tooltip" title="View" style="display:none;" onclick="return viewCommentGatePass(' + rowCountGatePass + ');" ><img style="" src="/Images/Icons/view.png"> </div><div id="divGatePass' + rowCountGatePass + '"style="display:none;" >' + COMMENTS + '</div></td>';
                }
                else {
                    FrecRow += '<td class="tdT" style="width: 6.8%; word-break: break-all; word-wrap: break-word; text-align: center;"><div class="tooltip" title="View" onclick="return viewCommentGatePass(' + rowCountGatePass + ');" ><img style="" src="/Images/Icons/view.png"> </div><div id="divGatePass' + rowCountGatePass + '"style="display:none;" >' + COMMENTS + '</div></td>';
                }
             
                FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">';
                FrecRow += '<textarea disabled rows="2" cols="20" id="txtGatePassRemarks' + rowCountGatePass + '" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onkeyup="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onblur="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" style="height:40px;width: 95%;float: right; resize: none; font-family: Calibri;"></textarea>';
                FrecRow += '</td>'
                FrecRow += '<td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>';
            }
            else {
                FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountGatePass + '"   class="tdT" style="width: 38.7%; word-break: break-all; word-wrap: break-word; text-align: left;"><input type="text" id="txtOtherGatePass' + rowCountGatePass + '" onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherGatePass' + rowCountGatePass + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
                FrecRow += '<input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowGatePass(' + rowCountGatePass + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
                FrecRow += '<td class="tdT" style="width: 19.5%; word-break: break-all; word-wrap: break-word; text-align: center;"><select id="ddlEmpGatePass' + rowCountGatePass + '" onkeypress="return DisableEnter(event);" class="form1" /></td>';
                FrecRow += '<td class="tdT" style="width: 14.5%; word-break: break-all; word-wrap: break-word; text-align: center;">' + strDecision + '</td>';
                if (HNDED_USR_ID == "") {
                    FrecRow += '<td class="tdT" style="width: 6.8%; word-break: break-all; word-wrap: break-word; text-align: center;"><div class="tooltip" title="View" style="display:none;" onclick="return viewCommentGatePass(' + rowCountGatePass + ');" ><img style="" src="/Images/Icons/view.png"> </div><div id="divGatePass' + rowCountGatePass + '"style="display:none;" >' + COMMENTS + '</div></td>';
                }
                else {
                    FrecRow += '<td class="tdT" style="width: 6.8%; word-break: break-all; word-wrap: break-word; text-align: center;"><div class="tooltip" title="View" onclick="return viewCommentGatePass(' + rowCountGatePass + ');" ><img style="" src="/Images/Icons/view.png"> </div><div id="divGatePass' + rowCountGatePass + '"style="display:none;" >' + COMMENTS + '</div></td>';
                }
              
                FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">';
                FrecRow += '<textarea rows="2" cols="20" id="txtGatePassRemarks' + rowCountGatePass + '" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onkeyup="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onblur="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" style="height:40px;width: 95%;float: right; resize: none; font-family: Calibri;"></textarea>';
                FrecRow += '</td>'
                FrecRow += '<td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>';
            }
           

            FrecRow += '<td id="tdEvtGatePass' + rowCountGatePass + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="tdDtlIdGatePass' + rowCountGatePass + '" style="display: none;">'+LVECLRSTF_DTL_ID+'</td>';
            FrecRow += '</tr>';
            jQuery('#TableFileUploadContainerPermit').append(FrecRow);
            
            document.getElementById("txtOtherGatePass" + rowCountGatePass).value = SUBJECT;
            document.getElementById("txtGatePassRemarks" + rowCountGatePass).value = REMARKS;
           
            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;
            if (delView == "TRUE") {
                //document.getElementById("txtOtherGatePass" + rowCountGatePass).disabled = true;
               
                //document.getElementById("txtGatePassRemarks" + rowCountGatePass).disabled = true;
                //document.getElementById("imgDelGP" + rowCountGatePass).style.display = "none";

                //txtGatePassRemarks0

            }

          

            var mode = "GATEPASS";
            FillddlEmployee(rowCountGatePass, mode);
            var ddlTestDropDownListXML = $noCon("#ddlEmpGatePass" + rowCountGatePass);
            if (HNDED_USR_ID != "") {


               
                elmnt = document.getElementById("ddlEmpGatePass" + rowCountGatePass);

                for (var i = 0; i < elmnt.options.length; i++) {

                    if (elmnt.options[i].value == HNDED_USR_ID) {
                       
                        elmnt.selectedIndex = i;
                    }
                }


            }
            //if (mode == "GATEPASS") {
            $au("#ddlEmpGatePass" + rowCountGatePass).selectToAutocomplete1Letter();
            //}
            //else {
            //    $au("#ddlEmpOtherItem" + rowCount).selectToAutocomplete1Letter();
            //}
            rowCountGatePass++;

            return false;
        }
        function EditListRowsOtherItem(SUBJECT, HNDED_USR_ID, HNDED_USR_NAME, DECISION, COMMENTS, REMARKS, LVECLRSTF_DTL_ID) {

          

            var strDecision = "";
            // 0-Pending 1-Approved 2-Rejected
            if (DECISION == "0") {
                strDecision = "Pending";
            }
            else if (DECISION == "1") {
                strDecision = "Approved";
            }
            else if (DECISION == "2") {
                strDecision = "Rejected";
            }
            if (HNDED_USR_ID == "") {
                strDecision = "";
            }
            var FrecRow = '<tr id="OtherItemRowId_' + rowCountOtherItem + '" ><td   id="tdIdOtherItem' + rowCountOtherItem + '" style="display: none;" >' + rowCountOtherItem + '</td>';
            FrecRow += '<td   id="OtherItemSlno' + rowCountOtherItem + '" class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;" ></td  >';
            if (document.getElementById("<%=HiddenDelView.ClientID%>").value == "TRUE") {
                FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountOtherItem + '"   class="tdT" style="width: 38.7%; word-break: break-all; word-wrap: break-word; text-align: left;"><input disabled type="text" id="txtOtherOtherItem' + rowCountOtherItem + '" onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherOtherItem' + rowCountOtherItem + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
                FrecRow += '<input disabled type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowOtherItem(' + rowCountOtherItem + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
                FrecRow += '<td class="tdT" style="width: 19.5%; word-break: break-all; word-wrap: break-word; text-align: center;"><select disabled id="ddlEmpOtherItem' + rowCountOtherItem + '" onkeypress="return DisableEnter(event);" class="form1" /></td>';
                FrecRow += '<td class="tdT" style="width: 14.5%; word-break: break-all; word-wrap: break-word; text-align: center;">' + strDecision + '</td>';
                if (HNDED_USR_ID == "") {
                    FrecRow += '<td class="tdT" style="width: 6.8%; word-break: break-all; word-wrap: break-word; text-align: center;"><div class="tooltip" title="View" style="display:none;" onclick="return viewCommentOtherItem(' + rowCountOtherItem + ');" ><img style="" src="/Images/Icons/view.png"> </div><div id="divOtherItem' + rowCountOtherItem + '"style="display:none;" >' + COMMENTS + '</div></td>';
                }
                else {
                    FrecRow += '<td class="tdT" style="width: 6.8%; word-break: break-all; word-wrap: break-word; text-align: center;"><div class="tooltip" title="View" onclick="return viewCommentOtherItem(' + rowCountOtherItem + ');" ><img style="" src="/Images/Icons/view.png"> </div><div id="divOtherItem' + rowCountOtherItem + '"style="display:none;" >' + COMMENTS + '</div></td>';
                }
                
              
                FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">';
                FrecRow += '<textarea disabled rows="2" cols="20" id="txtOtherItemRemarks' + rowCountOtherItem + '" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onkeyup="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onblur="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" style="height:40px;width: 95%;float: right; resize: none; font-family: Calibri;"></textarea>';
                FrecRow += '</td>'
                FrecRow += '<td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>';
            }
            else {
                FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountOtherItem + '"   class="tdT" style="width: 38.7%; word-break: break-all; word-wrap: break-word; text-align: left;"><input type="text" id="txtOtherOtherItem' + rowCountOtherItem + '" onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherOtherItem' + rowCountOtherItem + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
                FrecRow += '<input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowOtherItem(' + rowCountOtherItem + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
                FrecRow += '<td class="tdT" style="width: 19.5%; word-break: break-all; word-wrap: break-word; text-align: center;"><select id="ddlEmpOtherItem' + rowCountOtherItem + '" onkeypress="return DisableEnter(event);" class="form1" /></td>';
                FrecRow += '<td class="tdT" style="width: 14.5%; word-break: break-all; word-wrap: break-word; text-align: center;">' + strDecision + '</td>';
                if (HNDED_USR_ID == "") {
                    FrecRow += '<td class="tdT" style="width: 6.8%; word-break: break-all; word-wrap: break-word; text-align: center;"><div class="tooltip" title="View" style="display:none;" onclick="return viewCommentOtherItem(' + rowCountOtherItem + ');" ><img style="" src="/Images/Icons/view.png"> </div><div id="divOtherItem' + rowCountOtherItem + '"style="display:none;" >' + COMMENTS + '</div></td>';
                }
                else {
                    FrecRow += '<td class="tdT" style="width: 6.8%; word-break: break-all; word-wrap: break-word; text-align: center;"><div class="tooltip" title="View" onclick="return viewCommentOtherItem(' + rowCountOtherItem + ');" ><img style="" src="/Images/Icons/view.png"> </div><div id="divOtherItem' + rowCountOtherItem + '"style="display:none;" >' + COMMENTS + '</div></td>';
                }

              
                FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">';
                FrecRow += '<textarea rows="2" cols="20" id="txtOtherItemRemarks' + rowCountOtherItem + '" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onkeyup="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onblur="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" style="height:40px;width: 95%;float: right; resize: none; font-family: Calibri;"></textarea>';
                FrecRow += '</td>'
                FrecRow += '<td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>';
            }
           

            FrecRow += '<td id="tdEvtOtherItem' + rowCountOtherItem + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="tdDtlIdOtherItem' + rowCountOtherItem + '" style="display: none;">'+LVECLRSTF_DTL_ID+'</td>';
            FrecRow += '</tr>';
            jQuery('#tblOtherItemContainer').append(FrecRow);

            document.getElementById("txtOtherOtherItem" + rowCountOtherItem).value = SUBJECT;
            document.getElementById("txtOtherItemRemarks" + rowCountOtherItem).value = REMARKS;

            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;
            if (delView == "TRUE") {
                //document.getElementById("txtOtherOtherItem" + rowCountOtherItem).disabled = true;

                //document.getElementById("txtOtherItemRemarks" + rowCountOtherItem).disabled = true;
                //document.getElementById("imgDelGP" + rowCountOtherItem).style.display = "none";

                //txtOtherItemRemarks0

            }
            var mode = "OTHERITEM";
            FillddlEmployee(rowCountOtherItem, mode);
            var ddlTestDropDownListXML = $noCon("#ddlEmpOtherItem" + rowCountOtherItem);
            if (HNDED_USR_ID != "") {

                elmnt = document.getElementById("ddlEmpOtherItem" + rowCountOtherItem);

                for (var i = 0; i < elmnt.options.length; i++) {

                    if (elmnt.options[i].value == HNDED_USR_ID)
                        elmnt.selectedIndex = i;
                }


            }
            //if (mode == "GATEPASS") {
            //$au("#ddlEmpGatePass" + rowCountGatePass).selectToAutocomplete1Letter();
            //}
            //else {
            $au("#ddlEmpOtherItem" + rowCountOtherItem).selectToAutocomplete1Letter();
            //}
            rowCountOtherItem++;
            return false;
        }

        function AddMoreRowGatePass() {

            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;

            var FrecRow = '<tr id="GatePassRowId_' + rowCountGatePass + '" ><td   id="tdIdGatePass' + rowCountGatePass + '" style="display: none;" >' + rowCountGatePass + '</td>';
            FrecRow += '<td   id="GatePassSlno' + rowCountGatePass + '" class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;" ></td  >';
            FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountGatePass + '"   class="tdT" style="width: 38.7%; word-break: break-all; word-wrap: break-word; text-align: left;"><input type="text" id="txtOtherGatePass' + rowCountGatePass + '" onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherGatePass' + rowCountGatePass + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
            if (delView == "TRUE") {
                FrecRow += '<input disabled type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowGatePass(' + rowCountGatePass + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
            }
            else {
                FrecRow += '<input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowGatePass(' + rowCountGatePass + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
            }
            FrecRow += '<td class="tdT" style="width: 19.5%; word-break: break-all; word-wrap: break-word; text-align: center;"><select id="ddlEmpGatePass' + rowCountGatePass + '" onkeypress="return DisableEnter(event);" class="form1" /></td>';
            FrecRow += '<td class="tdT" style="width: 14.5%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>';
            FrecRow += '<td class="tdT" style="width: 6.8%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>';
            FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">';
            FrecRow += '<textarea rows="2" cols="20" id="txtGatePassRemarks' + rowCountGatePass + '" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onkeyup="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onblur="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" style="height:40px;width: 95%;float: right; resize: none; font-family: Calibri;"></textarea>';
            FrecRow += '</td>'
            FrecRow += '<td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>';

            FrecRow += '<td id="tdEvtGatePass' + rowCountGatePass + '" style="display: none;">INS</td>';
            FrecRow += '<td id="tdDtlIdGatePass' + rowCountGatePass + '" style="display: none;"></td>';
            FrecRow += '</tr>';
            jQuery('#TableFileUploadContainerPermit').append(FrecRow);
            if (rowCountGatePass != 0) {
                document.getElementById("txtOtherGatePass" + rowCountGatePass).focus();
            }

         
            


            var mode = "GATEPASS";
            FillddlEmployee(rowCountGatePass, mode);
          

            if (delView == "TRUE") {
                document.getElementById("txtOtherGatePass" + rowCountGatePass).disabled = true
                document.getElementById("txtGatePassRemarks" + rowCountGatePass).disabled = true;
                document.getElementById("ddlEmpGatePass" + rowCountGatePass).disabled = true;
            }
            $au("#ddlEmpGatePass" + rowCountGatePass).selectToAutocomplete1Letter();
            rowCountGatePass++;

          
            return false;
        }

        function AddMoreRowOtherItem() {
            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;
            var FrecRow = '<tr id="OtherItemRowId_' + rowCountOtherItem + '" ><td   id="tdIdOtherItem' + rowCountOtherItem + '" style="display: none;" >' + rowCountOtherItem + '</td>';
            FrecRow += '<td   id="OtherItemSlno' + rowCountOtherItem + '" class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;" ></td  >';
            FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountOtherItem + '"   class="tdT" style="width: 38.7%; word-break: break-all; word-wrap: break-word; text-align: left;"><input type="text" id="txtOtherOtherItem' + rowCountOtherItem + '" onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherOtherItem' + rowCountOtherItem + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
            if (delView == "TRUE") {
                FrecRow += '<input disabled type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowOtherItem(' + rowCountOtherItem + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
            }
            else {
                FrecRow += '<input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowOtherItem(' + rowCountOtherItem + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
            }
            FrecRow += '<td class="tdT" style="width: 19.5%; word-break: break-all; word-wrap: break-word; text-align: center;"><select id="ddlEmpOtherItem' + rowCountOtherItem + '" onkeypress="return DisableEnter(event);" class="form1" /></td>';
            FrecRow += '<td class="tdT" style="width: 14.5%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>';
            FrecRow += '<td class="tdT" style="width: 6.8%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>';
            FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">';
            FrecRow += '<textarea rows="2" cols="20" id="txtOtherItemRemarks' + rowCountOtherItem + '" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onkeyup="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onblur="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" style="height:40px;width: 95%;float: right; resize: none; font-family: Calibri;"></textarea>';
            FrecRow += '</td>'
            FrecRow += '<td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>';

            FrecRow += '<td id="tdEvtOtherItem' + rowCountOtherItem + '" style="display: none;">INS</td>';
            FrecRow += '<td id="tdDtlIdOtherItem' + rowCountOtherItem + '" style="display: none;"></td>';
            FrecRow += '</tr>';


           
           


            jQuery('#tblOtherItemContainer').append(FrecRow);
            if (rowCountOtherItem != 0) {
                document.getElementById("txtOtherOtherItem" + rowCountOtherItem).focus();
            }
            var mode = "OTHERITEM";
            FillddlEmployee(rowCountOtherItem, mode);
          

            if (delView == "TRUE") {
                document.getElementById("txtOtherOtherItem" + rowCountOtherItem).disabled = true;
                document.getElementById("txtOtherItemRemarks" + rowCountOtherItem).disabled = true;
                document.getElementById("ddlEmpOtherItem" + rowCountOtherItem).disabled = true;
            }
            $au("#ddlEmpOtherItem" + rowCountOtherItem).selectToAutocomplete1Letter();
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
        function clearHidden() {
            //alert(document.getElementById("<%=hiddenEmpDdlData.ClientID%>").value);
            document.getElementById("<%=hiddenEmpDdlData.ClientID%>").value = 0;
            IncrmntConfrmCounter();
            return true;
        }
        function ClearDivDisplayImage() {

            IncrmntConfrmCounter();

            var hidnImageSize = document.getElementById("<%=hiddenLicenceFileSize.ClientID%>").value;
            var fuData = document.getElementById("<%=FileUploadLicence.ClientID%>").value.replace("C:\\fakepath\\", "");
                   
            var Extension = fuData.substring(fuData.lastIndexOf('.') + 1).toLowerCase();
          
            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg" || Extension == "pdf") {

            }
            else {
                document.getElementById("<%=FileUploadLicence.ClientID%>").value = "";
                document.getElementById("<%=Label3.ClientID%>").textContent = "No file selected";
                alert("The specified file type could not be uploaded.Only support image files");

            }

                 if (document.getElementById("<%=FileUploadLicence.ClientID%>").value != "") {
                     document.getElementById("<%=Label3.ClientID%>").textContent = document.getElementById("<%=FileUploadLicence.ClientID%>").value.replace("C:\\fakepath\\", "");
                    document.getElementById("<%=divImageDisplay.ClientID%>").innerHTML = "";
                    document.getElementById("<%=hiddenLicenceFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenLicenceFile.ClientID%>").value;
                    document.getElementById("<%=hiddenLicenceFile.ClientID%>").value = "";
                }

             
        }
        function ClearImage() {
            if (document.getElementById("<%=hiddenLicenceFile.ClientID%>").value != "" || document.getElementById("<%=FileUploadLicence.ClientID%>").value != "") {
                if (confirm("Do You Want To Remove Selected File?")) {
                    IncrmntConfrmCounter();
                    document.getElementById("<%=FileUploadLicence.ClientID%>").value = "";
                       document.getElementById("<%=hiddenLicenceFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenLicenceFile.ClientID%>").value;
                       document.getElementById("<%=hiddenLicenceFile.ClientID%>").value = "";
                       document.getElementById("<%=divImageDisplay.ClientID%>").innerHTML = "";
                       document.getElementById("<%=Label3.ClientID%>").textContent = "No File Selected";
                       //  alert("Image has been Removed Sucessfully. ");
                   }
                   else {

                   }

               }
        }

        function validateClearanceForms() {

            if (confirm("Are you sure you want to approve?")) {
                document.getElementById("<%=hiddenEmpDdlData.ClientID%>").value = null;
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
            document.getElementById("<%=hiddenEmpDdlData.ClientID%>").value = null;
            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenTotalData" runat="server" />
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="hiddenEmpDdlData" runat="server" />

    <asp:HiddenField ID="HiddenDelView" runat="server" />
    <asp:HiddenField ID="hiddenLicenceFileDeleted" runat="server" />
    <asp:HiddenField ID="hiddenLicenceFileSize" runat="server" />
    <asp:HiddenField ID="hiddenLicenceFile" runat="server" />

       <asp:HiddenField ID="HiddenFieldMstrTblId" runat="server" />

      <asp:HiddenField ID="HiddenFieldCancelPage" runat="server" />

     <asp:HiddenField ID="HiddenFieldQryStringId" runat="server" />

      <asp:HiddenField ID="HiddenFieldParentPage" runat="server" />
    <div id="divMessageArea" style="display: none;width:95%;">
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

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="display: none; position: fixed; right: 2%; top: 42%; height: 26.5px;">

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
            <div class="div-Contact-details" style="float: left; margin-bottom: 2%;">
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="width:37%;">Employee Name</h2>
                    <asp:Label runat="server" ID="lblEmployeeName" Style="font-family: Calibri; font-size: 14px; color: #000;width:63%;float: left; " class="lblTop"></asp:Label>



                </div>
                 <div class="eachform" style="width: 47%; float: right;">
                        <h2 style="width:26%;">Employee No. </h2>
                    <asp:Label ID="lblEmpNo" Style="font-family: Calibri; font-size: 14px; color: #000;word-break:break-all;width:70%;float: left;"  class="lblTop" runat="server"></asp:Label>

                    </div>
            

                    <div class="eachform" style="width: 47%; float:left;margin-top: 1%;">
                        <h2 style="width:37%;">Designation </h2>

                        <asp:Label ID="lblDesig" Style="font-family: Calibri; font-size: 14px; color: #000;word-break:break-all;width:63%;float: left;" class="lblTop" runat="server"></asp:Label>
                    </div>
           
                <div class="eachform" style="width: 47%; float: right;margin-top: 1%;">
                    <h2 style="width:26%; margin-bottom: 0%;">Department </h2>

                    <asp:Label ID="lblDept" Style="font-family: Calibri; font-size: 14px; color: #000;word-break:break-all;width:70%;float: left; " class="lblTop" runat="server"></asp:Label>

                </div>
                <div id="divDvsn" class="eachform" style="width: 47%; margin-top:1%;float:right;">
                    <h2 style="width:26%;">Division </h2>

                    <asp:Label ID="lblDivision" Style="font-family: Calibri; font-size: 14px; color: #000;word-break:break-all;width:70%;float: left;" class="lblTop" runat="server"></asp:Label>

                </div>



                <div id="divDateTrvl" class="eachform" style="width: 47%; float: left;margin-top:1%;">
                    <h2 style="width:37%;">Date of Travel </h2>
                    <asp:Label ID="lblDateOfTravel" class="lblTop" Style="font-family: Calibri; font-size: 14px; color: #000; width:63%;float: left;" runat="server"></asp:Label>
                </div>
                <div id="divDateRetrn" class="eachform" style="margin-top:1%;float:left;">
                    <h2 style="width:17.5%;">Expected Date of Return </h2>
                    <asp:Label ID="lblDateOfReturn" class="lblTop" Style="font-family: Calibri; font-size: 14px; color: #000;width:70%;float: left; " runat="server"></asp:Label>
                </div>

            </div>


            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="div-Contact-details" style="float: left; margin-bottom: 2%;">
                         <h2 style="font-size: 20px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">Official Charge</h2>

                        <div id="divEmp" class="eachform" style="width: 100%; float: left; margin-bottom: 1%; margin-top: 1%;">
                            <h2 style="margin-top: 1%;">Take Over By*</h2>
                            <asp:DropDownList ID="ddlEmployee" Height="30px" Width="294px" class="form1" Style="float: left; margin-left: 6.4%;" AutoPostBack="true" onchange="clearHidden();" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>

                            <div class="eachform" style="width: 47%;float: right; padding-left: 0%;">
                            <h2 style="margin-top: 1%;">Attachment</h2>
                            <label for="cphMain_FileUploadLicence" id="lblLicence" class="custom-file-upload" tabindex="0" style="margin-left: 16.8%; font-family: Calibri;">
                                <img src="../../../../Images/Icons/cloud_upload.jpg" />Upload File</label>


                            <asp:FileUpload ID="FileUploadLicence" class="fileUpload" runat="server" Style="height: 30px; display: none;" onchange="ClearDivDisplayImage()" Accept="All" />


                            <div id="divImageEdit" runat="server" style="float: left; width: 54%; height: 20px; margin-top: 0%; margin-left: 37%;">
                                <div id="imgWrap1" class="imgWrap">
                                    <img id="ClearImageLicense" src="/Images/Icons/clear-image-green.png" alt="Clear" title="Remove File" onclick="ClearImage()" style="cursor: pointer; float: right;" />
                                </div>
                                <div id="divImageDisplay" runat="server">
                                </div>
                            </div>
                            <asp:Label ID="Label3" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
                        </div>
                        </div>

                        <div class="eachform" style="float: left; width: 47%;margin-top:0.5%;">
                            <h2 >Designation </h2>

                            <asp:Label ID="lblDesigTakeOverEmp" Style="font-family: Calibri; font-size: 14px; color: #000; margin-left:16.5%;" class="lblTop" runat="server"></asp:Label>
                        </div>


                        <div class="eachform" style="float: right; width: 47%;margin-top:0.5%;">
                            <h2 style="width:26%;">Division </h2>

                            <asp:Label ID="lblDivisionTakeOverEmp" Style="font-family: Calibri; font-size: 14px; color: #000; width: 70%;float:left;word-break:break-all;" class="lblTop" runat="server"></asp:Label>

                        </div>

                        

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
            <%--test--%>
            <table id="ReportTable" class="main_table" cellspacing="0" cellpadding="2px" style="margin-bottom: 0%;">
                <thead>
                    <tr class="main_table_head">
                        <th class="thT" style="width: 5%; word-wrap: break-word; text-align: center;">SL#</th>
                        <th class="thT" style="width: 40%; word-wrap: break-word; text-align: left;">Subject</th>
                        <th class="thT" style="width: 20%; word-wrap: break-word; text-align: left;">Handed Over To</th>
                        <th class="thT" style="width: 15%; word-wrap: break-word; text-align: center;">Handed Over Decision</th>
                        <th class="thT" style="width: 5%; word-wrap: break-word; text-align: center;">Comment</th>
                        <th class="thT" style="width: 10%; word-wrap: break-word; text-align: left;">Remarks</th>
                        <th class="thT" style="width: 5%; word-wrap: break-word; text-align: center;">N/A</th>
                        <td class="tdT" style="display: none;"></td>
                        <td class="tdT" style="display: none;"></td>
                    </tr>
                </thead>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">1</td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;">Mobile Number</td>
                    <td class="tdT" style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left;">
                        <asp:DropDownList ID="ddlMobileNoHndOvr" Height="30px" class="form1" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>
                    </td>
                    <td id="Decsn1" runat="server" class="tdT" style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: center;">
                   
                    </td>
                  
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">
                    <div id="view1" runat="server" class="tooltip" title="View" onclick="return viewComment(1);" ><img style="margin-left: 31%;" src="/Images/Icons/view.png"/> </div>
                    <div id="divcmnt1" runat="server" style="display:none;" ></div>
                    </td>

                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left;">
                        <asp:TextBox ID="txtMobNoRemarks" Height="40px" Width="98%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtMobNoRemarks,450);" onkeyup="textCounter(cphMain_txtMobNoRemarks,450);" onblur="textCounter(cphMain_txtMobNoRemarks,450);"></asp:TextBox>
                    </td>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox runat="server" ID="cbMobNo" /><label for='cphMain_cbQpPass'></label></td>
                    <td class="tdT" style="display: none;"></td>
                    <td class="tdT" style="display: none;"></td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">2</td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;">Car Key & Documents</td>
                    <td class="tdT" style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left;">
                        <asp:DropDownList ID="ddlCarKeyAndDoc" Height="30px" class="form1" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>
                    </td>
                   <td id="Decsn2" runat="server" class="tdT" style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: center;">
                   
                    </td>
                  
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">
                    <div id="view2" runat="server" class="tooltip" title="View" onclick="return viewComment(2);" ><img style="margin-left: 31%;" src="/Images/Icons/view.png"/> </div>
                    <div id="divcmnt2" runat="server" style="display:none;" ></div>
                    </td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtCarKeysDocRemarks" Height="40px" Width="98%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtCarKeysDocRemarks,450);" onkeyup="textCounter(cphMain_txtCarKeysDocRemarks,450);" onblur="textCounter(cphMain_txtCarKeysDocRemarks,450);"></asp:TextBox>
                    </td>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox runat="server" ID="cbCarKeysDoc" /><label for='cphMain_cbCarKeysDoc'></label></td>
                    <td class="tdT" style="display: none;"></td>
                    <td class="tdT" style="display: none;"></td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">3</td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;">Driving Licence</td>
                    <td class="tdT" style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left;">
                        <asp:DropDownList ID="ddlDrvLicHndOvr" Height="30px" class="form1" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>
                    </td>
                   <td id="Decsn3" runat="server" class="tdT" style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: center;">
                   
                    </td>
                  
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">
                    <div id="view3" runat="server" class="tooltip" title="View" onclick="return viewComment(3);" ><img style="margin-left: 31%;" src="/Images/Icons/view.png"/> </div>
                    <div id="divcmnt3" runat="server" style="display:none;" ></div>
                    </td>

                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtdrivingLicRemarks" Height="40px" Width="98%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtdrivingLicRemarks,450);" onkeyup="textCounter(cphMain_txtdrivingLicRemarks,450);" onblur="textCounter(cphMain_txtdrivingLicRemarks,450);"></asp:TextBox>
                    </td>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox runat="server" ID="cbDrivingLic" /><label for='cphMain_cbDrivingLic'></label></td>
                    <td class="tdT" style="display: none;"></td>
                    <td class="tdT" style="display: none;"></td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">4</td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;">H2S/BA Cards</td>
                    <td class="tdT" style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left;">
                        <asp:DropDownList ID="ddlH2SBAHndOvr" Height="30px" class="form1" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>
                    </td>
                    <td id="Decsn4" runat="server" class="tdT" style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: center;">
                   
                    </td>
                  
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">
                    <div id="view4" runat="server" class="tooltip" title="View" onclick="return viewComment(4);" ><img style="margin-left: 31%;" src="/Images/Icons/view.png"/> </div>
                    <div id="divcmnt4" runat="server" style="display:none;" ></div>
                    </td>

                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtH2SBACardsRemarks" Height="40px" Width="98%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtH2SBACardsRemarks,450);" onkeyup="textCounter(cphMain_txtH2SBACardsRemarks,450);" onblur="textCounter(cphMain_txtH2SBACardsRemarks,450);"></asp:TextBox>

                    </td>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox runat="server" ID="cbH2SBA" /><label for='cphMain_cbToolsAndCompany'></label></td>
                    <td class="tdT" style="display: none;"></td>
                    <td class="tdT" style="display: none;"></td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">5</td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;">Official Keys</td>
                    <td class="tdT" style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left;">
                        <asp:DropDownList ID="ddlOfficialKeysHndOvr" Height="30px" class="form1" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>
                    </td>
                 <td id="Decsn5" runat="server" class="tdT" style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: center;">
                   
                    </td>
                  
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">
                    <div id="view5" runat="server" class="tooltip" title="View" onclick="return viewComment(5);" ><img style="margin-left: 31%;" src="/Images/Icons/view.png"/> </div>
                    <div id="divcmnt5" runat="server" style="display:none;" ></div>
                    </td>

                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtOfficialKeyRemarks" Height="40px" Width="98%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtOfficialKeyRemarks,450);" onkeyup="textCounter(cphMain_txtOfficialKeyRemarks,450);" onblur="textCounter(cphMain_txtOfficialKeyRemarks,450);"></asp:TextBox>

                    </td>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox runat="server" ID="cbOfficialKey" /><label for='cphMain_cbClearanceTrafficDept'></label></td>
                    <td class="tdT" style="display: none;"></td>
                    <td class="tdT" style="display: none;"></td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">6</td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;">Imprest</td>
                    <td class="tdT" style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left;">
                        <asp:DropDownList ID="ddlImprestHndOvr" Height="30px" class="form1" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>
                    </td>
                  <td id="Decsn6" runat="server" class="tdT" style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: center;">
                   
                    </td>
                  
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">
                    <div id="view6" runat="server" class="tooltip" title="View" onclick="return viewComment(6);" ><img style="margin-left: 31%;" src="/Images/Icons/view.png"/> </div>
                    <div id="divcmnt6" runat="server" style="display:none;" ></div>
                    </td>

                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtImpresetRemarks" Height="40px" Width="98%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtImpresetRemarks,450);" onkeyup="textCounter(cphMain_txtImpresetRemarks,450);" onblur="textCounter(cphMain_txtImpresetRemarks,450);"></asp:TextBox>

                    </td>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox runat="server" ID="cbImpreset" /><label for='cphMain_cbMessAmount'></label></td>
                    <td class="tdT" style="display: none;"></td>
                    <td class="tdT" style="display: none;"></td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">7</td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;">Staff Advance</td>
                    <td class="tdT" style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left;">
                        <asp:DropDownList ID="ddlStaffAdvanceHndOvr" Height="30px" class="form1" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>
                    </td>
                  <td id="Decsn7" runat="server" class="tdT" style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: center;">
                   
                    </td>
                  
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">
                    <div id="view7" runat="server" class="tooltip" title="View" onclick="return viewComment(7);" ><img style="margin-left: 31%;" src="/Images/Icons/view.png"/> </div>
                    <div id="divcmnt7" runat="server" style="display:none;" ></div>
                    </td>

                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtStaffAdvanceRemarks" Height="40px" Width="98%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtStaffAdvanceRemarks,450);" onkeyup="textCounter(cphMain_txtStaffAdvanceRemarks,450);" onblur="textCounter(cphMain_txtStaffAdvanceRemarks,450);"></asp:TextBox>

                    </td>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox runat="server" ID="cbStaffAdvance" /><label for='cphMain_cbMessAmount'></label></td>
                    <td class="tdT" style="display: none;"></td>
                    <td class="tdT" style="display: none;"></td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">8</td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;">Telephone Bills (personal)</td>
                    <td class="tdT" style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left;">
                        <asp:DropDownList ID="ddlTelephoneBillsHndOvr" Height="30px" class="form1" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>
                    </td>
                    <td id="Decsn8" runat="server" class="tdT" style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: center;">
                   
                    </td>
                  
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">
                    <div id="view8" runat="server" class="tooltip" title="View" onclick="return viewComment(8);" ><img style="margin-left: 31%;" src="/Images/Icons/view.png"/> </div>
                    <div id="divcmnt8" runat="server" style="display:none;" ></div>
                    </td>

                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtTeleBillsPerRemarks" Height="40px" Width="98%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtTeleBillsPerRemarks,450);" onkeyup="textCounter(cphMain_txtTeleBillsPerRemarks,450);" onblur="textCounter(cphMain_txtTeleBillsPerRemarks,450);"></asp:TextBox>

                    </td>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox runat="server" ID="cbTeleBillsPer" /><label for='cphMain_cbMessAmount'></label></td>
                    <td class="tdT" style="display: none;"></td>
                    <td class="tdT" style="display: none;"></td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">9</td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;">IT Clearance</td>
                    <td class="tdT" style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left;">
                        <asp:DropDownList ID="ddlItClearanceHndOvr" Height="30px" class="form1" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>
                    </td>
                 <td id="Decsn9" runat="server" class="tdT" style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: center;">
                   
                    </td>
                  
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">
                    <div id="view9" runat="server" class="tooltip" title="View" onclick="return viewComment(9);" ><img style="margin-left: 31%;" src="/Images/Icons/view.png"/> </div>
                    <div id="divcmnt9" runat="server" style="display:none;" ></div>
                    </td>

                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtItClearanceRemarks" Height="40px" Width="98%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtItClearanceRemarks,450);" onkeyup="textCounter(cphMain_txtItClearanceRemarks,450);" onblur="textCounter(cphMain_txtItClearanceRemarks,450);"></asp:TextBox>

                    </td>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox runat="server" ID="cbItClearanc" /></td>
                    <td class="tdT" style="display: none;"></td>
                    <td class="tdT" style="display: none;"></td>
                </tr>
                <%--  <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">7</td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;">Exit Permit</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left;"></td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left;"></td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="TextBox4" Height="40px" Width="98%" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtAddress,450);" onkeyup="textCounter(cphMain_txtAddress,450);" onblur="textCounter(cphMain_txtAddress,450);"></asp:TextBox>
                    </td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>

                </tr>--%>
            </table>

            <div id="divPerAtch" runat="server" style="">
                <%--   overflow-y: auto;--%>
                <table id="Table2" class="main_table" cellspacing="0" cellpadding="2px" style="margin-bottom: 0%;">

                    <tr>
                        <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">10</td>
                        <td class="tdT" style="width: 38.7%; word-break: break-all; word-wrap: break-word; text-align: left;">Security Passes (Specify)
                        <input type="image" id="Image2" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRows('GATEPASS');" style="float: right; cursor: pointer;" />
                        </td>
                        <td class="tdT" style="width: 19.5%; word-break: break-all; word-wrap: break-word; text-align: left;"></td>
                        <td class="tdT" style="width: 14.5%; word-break: break-all; word-wrap: break-word; text-align: left;"></td>
                        <td class="tdT" style="width: 6.8%; word-break: break-all; word-wrap: break-word; text-align: left;"></td>

                        <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>
                        <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>
                        <td class="tdT" style="display: none;"></td>
                        <td class="tdT" style="display: none;"></td>
                    </tr>

                </table>
                <table id="TableFileUploadContainerPermit" class="main_table" cellspacing="0" cellpadding="2px" style="margin-bottom: 0%;">
                </table>

                <table id="Table1" class="main_table" cellspacing="0" cellpadding="2px" style="margin-bottom: 0%;">


                    <tr>
                        <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;">11</td>
                        <td class="tdT" style="width: 38.7%; word-break: break-all; word-wrap: break-word; text-align: left;">Any other Documents Specify
                        <input type="image" id="Image3" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRows('OTHERITEM');" style="float: right; cursor: pointer;" />
                        </td>
                        <td class="tdT" style="width: 19.5%; word-break: break-all; word-wrap: break-word; text-align: left;"></td>
                        <td class="tdT" style="width: 14.5%; word-break: break-all; word-wrap: break-word; text-align: left;"></td>
                        <td class="tdT" style="width: 6.8%; word-break: break-all; word-wrap: break-word; text-align: left;"></td>

                        <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>
                        <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: center;"></td>
                        <td class="tdT" style="display: none;"></td>
                        <td class="tdT" style="display: none;"></td>
                    </tr>

                </table>
                <table id="tblOtherItemContainer" class="main_table" cellspacing="0" cellpadding="2px">
                </table>
            </div>
            <div class="eachform" style="width: 47%;">
                <h2 style="margin-top: 1%;">Comments</h2>
                <asp:TextBox ID="txtComments" class="form1" Height="80px" Width="340px" Style="float: left; resize: none; font-family: Calibri;border: 1px solid #665656;margin-left:11%;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtComments,450);" onkeyup="textCounter(cphMain_txtComments,450);" onblur="textCounter(cphMain_txtComments,450);"></asp:TextBox>
            </div>

            <br />
            <div class="eachform" style="margin-top: 3%;">
                <div class="subform" style="width: 60%;">
                       <%--Start:-Emp-0009--%>
                     <asp:Button ID="btnConfirm" runat="server" class="save" Text="Approve" OnClick="btnConfirm_Click" OnClientClick="return validateClearanceForms();"/>
                      <asp:Button ID="btnReject" runat="server" class="save" Text="Reject" OnClick="btnReject_Click" OnClientClick="return RejectClearanceForm();"/>
                       <%--End:-Emp-0009--%>
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return validateClearanceForm();" />
                    <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return validateClearanceForm();" />
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClientClick="return validateClearanceForm();" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return validateClearanceForm();" />
                    <asp:Button ID="btnClear" runat="server" class="save" Text="Clear" OnClientClick="return ConfirmClear();" />
                    <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                </div>
            </div>


        </div>
        
                                 <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 45%; padding-bottom: 0.7%; padding-top: 0.6%;">Comment</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <%--<label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>--%>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Enabled="false" Width="100%" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                    
                        <%--<asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="return CloseCancelView();" runat="server" Text="Close" />--%>
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   




             <div id="Div1" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelViewRjct();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Clearance Form Staff</h3>
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
    <style>
        .form1 {
    width: 92%;
}

    </style>
</asp:Content>

