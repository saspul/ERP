<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="~/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Approval/hcm_Clearance_Form_Approval.aspx.cs" Inherits="HCM_HCM_Master_hcm_LeaveMaster_hcm_Clearance_Form_Worker_hcm_Clearance_Form_Worker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style>
        .div-Contact-details {
            /*border: 1px solid #cad1be;
            padding: 1% 2% 3% 2%;
            margin-top: 0%;
            display: block;
            */
            width: 95.5%;
            padding: 1% 2% 3% 2%;
            min-height: 104px;
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
background: url("/Images/Icons/") no-repeat;
background-size: 100%;
height: 32px;
width: 32px;
display:inline-block;
padding: 0 0 0 0px;
}
input[type=checkbox]:checked + label
{
background: url("/Images/Icons/") no-repeat;
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
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance form  details inserted successfully.";
            document.getElementById("<%=ddlEmployee.ClientID%>").focus();
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }

        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance form  details updated successfully.";
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
                    window.location.href = "hcm_Clearance_Form_Approval_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_Clearance_Form_Approval_List.aspx";
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
          
            if (confirm("Are you sure you want to approve?")) {
              
                }
                else {
                    return false;
                }
          
        }
        function RejectClearanceForm() {

            if (confirm("Are You Sure You Want To Reject?")) {
                window.location.href = "hcm_Clearance_Form_Approval_List.aspx";
                return false;
            }
            else {
                return false;
            }

        }
        
        function addToLocalStorage(particular, cbStatus, textRemarks, DetailID, tblType, EvtAction) {
           // alert(textRemarks);
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
          //  alert(document.getElementById("<%=hiddenTotalData.ClientID%>").value);
            rowCountLocalStore++;
        }
        // checks every field in row
        function CheckAndHighlightGatePass(x, FirstRow) {
            ret = true;
            if (FirstRow == 1) {
                //first row condition
                document.getElementById("txtOtherGatePass" + x).style.borderColor = "";
                var GatePass = document.getElementById("txtOtherGatePass" + x).value;
                var GatePassRemarks = document.getElementById("txtGatePassRemarks" + x).value;
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
                var GatePass = document.getElementById("txtOtherGatePass" + x).value;
                var GatePassRemarks = document.getElementById("txtGatePassRemarks" + x).value;
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
            ret = true;
            if (FirstRow == 1) {
                //first row condition
                document.getElementById("txtOtherOtherItem" + x).style.borderColor = "";
                var OtherItem = document.getElementById("txtOtherOtherItem" + x).value;
                var OtherItemRemarks = document.getElementById("txtOtherItemRemarks" + x).value;
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
                var OtherItem = document.getElementById("txtOtherOtherItem" + x).value;
                var OtherItemRemarks = document.getElementById("txtOtherItemRemarks" + x).value;
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
            localStorage.clear();
            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;
            if (delView == "TRUE") {
                
                document.getElementById("imgAddOtherItem").style.display = "none";
                document.getElementById("imgAddGatePass").style.display = "none";
            }
            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";
            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;

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
                            }
                            else {
                                EditListRowsOtherItem(json[key].PARTICULAR, json[key].STATUS, json[key].REMARKS, json[key].LVECLRWKR_DTL_ID);
                            }
                        }
                    }
                }
            }
            else {
                AddMoreRowGatePass();
                AddMoreRowOtherItem();

            }

        });

        var rowCountGatePass = 0;
        var rowCountOtherItem = 0;
        var rowCountLocalStore = 0;
        var tbClientTotalValues = '';
        tbClientTotalValues = [];

        function EditListRowsGatePass(PARTICULAR, STATUS, REMARKS, LVECLRWKR_DTL_ID) {
            var submitstats;
            if (STATUS == 1)
            {
                submitstats = "Submitted";

            }
            else
                submitstats = "Not Submitted";

            var FrecRow = '<tr id="GatePassRowId_' + rowCountGatePass + '" ><td   id="tdIdGatePass' + rowCountGatePass + '" style="display: none;" >' + rowCountGatePass + '</td>';
            FrecRow += '<td   id="GatePassSlno' + rowCountGatePass + '" class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;" ></td  >';

            FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountGatePass + '"   class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;"><input type="text" id="txtOtherGatePass' + rowCountGatePass + '" value="' + PARTICULAR + '"  onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherGatePass' + rowCountGatePass + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
            FrecRow += '<input type="image" id="imgDelGP' + rowCountOtherItem + '"  class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowGatePass(' + rowCountGatePass + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
            //FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountGatePass + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + rowCountGatePass + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">' + submitstats + '</td>';
            FrecRow += '<td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;">';
            FrecRow += '<textarea rows="2" cols="20" id="txtGatePassRemarks' + rowCountGatePass + '"  onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onkeyup="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onblur="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" style="height:40px;width: 426px;float: right; resize: none; font-family: Calibri;"></textarea>';
            FrecRow += '</td>'
            FrecRow += '<td id="tdEvtGatePass' + rowCountGatePass + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="tdDtlIdGatePass' + rowCountGatePass + '" style="display: none;">' + LVECLRWKR_DTL_ID + '</td>';
            FrecRow += '</tr>';
            jQuery('#TableFileUploadContainerPermit').append(FrecRow);
            document.getElementById("txtGatePassRemarks" + rowCountGatePass).value = REMARKS;
          
            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;
            if (delView == "TRUE") {
                document.getElementById("txtOtherGatePass" + rowCountGatePass).disabled = true;
                 document.getElementById("txtGatePassRemarks" + rowCountGatePass).disabled = true;
                document.getElementById("imgDelGP" + rowCountGatePass).style.display = "none";

                //txtGatePassRemarks0

            }
            rowCountGatePass++;
            return false;
        }
        function EditListRowsOtherItem(PARTICULAR, STATUS, REMARKS, LVECLRWKR_DTL_ID) {
            var submitstats;
            if (STATUS == 1) {
                submitstats = "Submitted";

            }
            else
                submitstats = "Not Submitted";


            var FrecRow = '<tr id="OtherItemRowId_' + rowCountOtherItem + '" ><td   id="tdIdOtherItem' + rowCountOtherItem + '" style="display: none;" >' + rowCountOtherItem + '</td>';
            FrecRow += '<td   id="OtherItemSlno' + rowCountOtherItem + '" class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;" ></td  >';

            FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountOtherItem + '"   class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;"><input type="text" id="txtOtherOtherItem' + rowCountOtherItem + '" value="' + PARTICULAR + '"  onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherOtherItem' + rowCountOtherItem + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
            FrecRow += '<input type="image" id="imgDel' + rowCountOtherItem + '"  class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowOtherItem(' + rowCountOtherItem + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
            //FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountOtherItem + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + rowCountOtherItem + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">' + submitstats + '</td>';
            FrecRow += '<td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;">';
            FrecRow += '<textarea rows="2" cols="20" id="txtOtherItemRemarks' + rowCountOtherItem + '"  onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onkeyup="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onblur="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" style="height:40px;width: 426px;float: right; resize: none; font-family: Calibri;"></textarea>';
            FrecRow += '</td>'

            FrecRow += '<td id="tdEvtOtherItem' + rowCountOtherItem + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="tdDtlIdOtherItem' + rowCountOtherItem + '" style="display: none;">' + LVECLRWKR_DTL_ID + '</td>';
            FrecRow += '<td id="tdChanged' + rowCountOtherItem + '" style="display: none;"></td>';
            FrecRow += '</tr>';
            jQuery('#tblOtherItemContainer').append(FrecRow);
            document.getElementById("txtOtherItemRemarks" + rowCountOtherItem).value = REMARKS;
            //if (STATUS == "1") {
            //    document.getElementById("cbOtherOtherItemSts" + rowCountOtherItem).checked = true;
            //}
            //else {
            //    document.getElementById("cbOtherOtherItemSts" + rowCountOtherItem).checked = false;
            //}
            
            var delView = document.getElementById("<%=HiddenDelView.ClientID%>").value;
            if (delView == "TRUE") {
                document.getElementById("txtOtherOtherItem" + rowCountOtherItem).disabled = true;
                //document.getElementById("cbOtherOtherItemSts" + rowCountOtherItem).disabled = true;
                document.getElementById("txtOtherItemRemarks" + rowCountOtherItem).disabled = true;
                document.getElementById("imgDel" + rowCountOtherItem).style.display = "none";

                //txtGatePassRemarks0

            }
            rowCountOtherItem++;
            return false;
        }

        function AddMoreRowGatePass() {


            var FrecRow = '<tr id="GatePassRowId_' + rowCountGatePass + '" ><td   id="tdIdGatePass' + rowCountGatePass + '" style="display: none;" >' + rowCountGatePass + '</td>';
            FrecRow += '<td   id="GatePassSlno' + rowCountGatePass + '" class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;" ></td  >';
            FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountGatePass + '"   class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;"><input type="text" id="txtOtherGatePass' + rowCountGatePass + '" onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherGatePass' + rowCountGatePass + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
            FrecRow += '<input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowGatePass(' + rowCountGatePass + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
            //FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountGatePass + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + rowCountGatePass + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;"><input type="checkbox" id="cbOtherGatePassSts' + rowCountGatePass + '"><label for="cbOtherGatePassSts' + rowCountGatePass + '"></label></td>';
            FrecRow += '<td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;">';
            FrecRow += '<textarea rows="2" cols="20" id="txtGatePassRemarks' + rowCountGatePass + '" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onkeyup="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" onblur="textCounter(txtGatePassRemarks' + rowCountGatePass + ',450);" style="height:40px;width: 426px;float: right; resize: none; font-family: Calibri;"></textarea>';
            FrecRow += '</td>'
            FrecRow += '<td id="tdEvtGatePass' + rowCountGatePass + '" style="display: none;">INS</td>';
            FrecRow += '<td id="tdDtlIdGatePass' + rowCountGatePass + '" style="display: none;"></td>';
            FrecRow += '</tr>';
            jQuery('#TableFileUploadContainerPermit').append(FrecRow);
            if (rowCountGatePass != 0) {
                document.getElementById("txtOtherGatePass" + rowCountGatePass).focus();
            }
           
            rowCountGatePass++;
            return false;
        }

        function AddMoreRowOtherItem() {


            var FrecRow = '<tr id="OtherItemRowId_' + rowCountOtherItem + '" ><td   id="tdIdOtherItem' + rowCountOtherItem + '" style="display: none;" >' + rowCountOtherItem + '</td>';
            FrecRow += '<td   id="OtherItemSlno' + rowCountOtherItem + '" class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;" ></td  >';

            FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountOtherItem + '"   class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;"><input type="text" id="txtOtherOtherItem' + rowCountOtherItem + '" onkeypress="return isTag(event)" maxlength="49" onblur="return RemoveTag(\'txtOtherOtherItem' + rowCountOtherItem + '\');" style="width: 80%;height: 24px;font-family: Calibri;">';
            FrecRow += '<input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowOtherItem(' + rowCountOtherItem + ',\'Are you sure you want to delete this entry?\');"  title="Delete"  style="float: right; cursor: pointer;" ></td>';
            //FrecRow += '<td id="FileIndvlAddMoreRow' + rowCountOtherItem + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + rowCountOtherItem + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;"><input type="checkbox" id="cbOtherOtherItemSts' + rowCountOtherItem + '"><label for="cbOtherOtherItemSts' + rowCountOtherItem + '"></label></td>';
            FrecRow += '<td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;">';
            FrecRow += '<textarea rows="2" cols="20" id="txtOtherItemRemarks' + rowCountOtherItem + '" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onkeyup="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" onblur="textCounter(txtOtherItemRemarks' + rowCountOtherItem + ',450);" style="height:40px;width: 426px;float: right; resize: none; font-family: Calibri;"></textarea>';
            FrecRow += '</td>'
            FrecRow += '<td id="tdEvtOtherItem' + rowCountOtherItem + '" style="display: none;">INS</td>';
            FrecRow += '<td id="tdDtlIdOtherItem' + rowCountOtherItem + '" style="display: none;"></td>';
            FrecRow += '</tr>';
            jQuery('#tblOtherItemContainer').append(FrecRow);
            if (rowCountOtherItem != 0) {
                document.getElementById("txtOtherOtherItem" + rowCountOtherItem).focus();
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenTotalData" runat="server" />
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenDelView" runat="server" />
      <asp:HiddenField ID="HiddenViewId" runat="server" />

    <div id="divMessageArea" style="display: none">
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

               
            <div class="div-Contact-details" style="float: left; margin-bottom: 2%;">
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="margin-top: 1%;">Employee Name*</h2>
                    <asp:DropDownList ID="ddlEmployee" Height="30px" Width="294px" class="form1" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>



                </div>
                <div class="eachform" style="width: 47%; padding-left: 6%">
                    <h2 style="margin-top: 1%;">Leave</h2>
                    <asp:DropDownList ID="ddlLeave" Height="30px" Width="294px" class="form1" AutoPostBack="true" OnSelectedIndexChanged="ddlLeave_SelectedIndexChanged" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>



                </div>

                <div style="float: left; width: 100%">
                    <div class="eachform" style="width: 47%; float: left;">
                        <h2 style="margin-top: 1%;">Employee No. :</h2>
                        <asp:Label ID="lblEmpNo" style="font-family: Calibri;font-size: 17px;color: #909c7b;margin-left: 25%;"  class="lblTop" runat="server"></asp:Label>

                    </div>

                    <div class="eachform" style="width: 47%; padding-left: 6%">
                        <h2 style="margin-top: 1%;">Designation :</h2>

                        <asp:Label ID="lblDesig" style="font-family: Calibri;font-size: 17px;color: #909c7b;margin-left: 25%;"  class="lblTop" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="margin-top: 1%;margin-bottom: 0%;">Department :</h2>

                    <asp:Label ID="lblDept" style="font-family: Calibri;font-size: 17px;color: #909c7b;margin-left: 23%;" class="lblTop" runat="server"></asp:Label>

                </div>
                <div class="eachform" style="width: 47%; padding-left: 6%">
                    <h2 style="margin-top: 1%;">Division :</h2>

                    <asp:Label ID="lblDivision" style="font-family: Calibri;font-size: 17px;color: #909c7b;margin-left: 25%;" class="lblTop" runat="server"></asp:Label>

                </div>



                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="margin-top: 1%;">Date of travel :</h2>
                    <asp:Label ID="lblDateOfTravel" class="lblTop" style="font-family: Calibri;font-size: 17px;color: #909c7b;margin-left: 21%;" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; padding-left: 6%">
                    <h2 style="margin-top: 1%;">Expected date of return :</h2>
                    <asp:Label ID="lblDateOfReturn" class="lblTop" style="font-family: Calibri;font-size: 17px;color: #909c7b;margin-left: 8%;" runat="server"></asp:Label>
                </div>

            </div>
                     </ContentTemplate>
            </asp:UpdatePanel>
            <%--test--%>
            <table id="ReportTable" class="main_table" cellspacing="0" cellpadding="2px" style="margin-bottom: 0%;">
                <thead>
                    <tr class="main_table_head">
                        <th class="thT" style="width: 5%; word-wrap: break-word; text-align: center;">SLdd#</th>
                        <th class="thT" style="width: 45%; word-wrap: break-word; text-align: center;">Particulars</th>
                        <th class="thT" style="width: 10%; word-wrap: break-word; text-align: center;">Submit</th>
                        <th class="thT" style="width: 40%; word-wrap: break-word; text-align: center;">Remarks</th>
                    </tr>
                </thead>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">1</td>
                    <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">QP Pass</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox  runat="server" ID="cbQpPass" /><label id="cphMain_cbQpPass" runat="server" for='cphMain_cbQpPass' style="width: 61px;"></label></td>

                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;">
                        <asp:TextBox ID="txtQpPassRemarks" Height="40px" Width="426px" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtAddress,450);" onkeyup="textCounter(cphMain_txtAddress,450);" onblur="textCounter(cphMain_txtAddress,450);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">2</td>
                    <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">Sim Card</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox  runat="server" ID="cbSimCard" /><label for='cphMain_cbSimCard' id="cphMain_cbSimCard"  style="width: 61px;" runat="server" ></label></td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtSimCardRemarks" Height="40px" Width="426px" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtAddress,450);" onkeyup="textCounter(cphMain_txtAddress,450);" onblur="textCounter(cphMain_txtAddress,450);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">3</td>
                    <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">Driving Licence</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox  runat="server" ID="cbDrivingLic"  /><label for='cphMain_cbDrivingLic' id="cphMain_cbDrivingLic"  style="width: 61px;" runat="server" ></label></td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtdrivingLicRemarks" Height="40px" Width="426px" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtAddress,450);" onkeyup="textCounter(cphMain_txtAddress,450);" onblur="textCounter(cphMain_txtAddress,450);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">4</td>
                    <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">Tools/company belongings</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox  runat="server" ID="cbToolsAndCompany" /><label for='cphMain_cbToolsAndCompany' id="cphMain_cbToolsAndCompany"  style="width: 61px;" runat="server"></label></td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtToolsAndCompanyRemarks" Height="40px" Width="426px" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtAddress,450);" onkeyup="textCounter(cphMain_txtAddress,450);" onblur="textCounter(cphMain_txtAddress,450);"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">5</td>
                    <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">Clearance from traffic Dept (Only for Drivers)</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox  runat="server" ID="cbClearanceTrafficDept" /><label for='cphMain_cbClearanceTrafficDept' id="cphMain_cbClearanceTrafficDept"  style="width: 61px;" runat="server"></label></td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtClearanceTrafficRemarks" Height="40px" Width="426px" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtAddress,450);" onkeyup="textCounter(cphMain_txtAddress,450);" onblur="textCounter(cphMain_txtAddress,450);"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="tdT" style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left;">6</td>
                    <td class="tdT" style="width: 45%; word-break: break-all; word-wrap: break-word; text-align: left;">Mess Amount</td>
                    <td class="tdT" style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:CheckBox  runat="server" ID="cbMessAmount" /><label  for='cphMain_cbMessAmount' id="cphMain_cbMessAmount"  style="width: 61px;" runat="server"></label></td>
                    <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: center;">
                        <asp:TextBox ID="txtMessAmountRemarks" Height="40px" Width="426px" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtAddress,450);" onkeyup="textCounter(cphMain_txtAddress,450);" onblur="textCounter(cphMain_txtAddress,450);"></asp:TextBox>

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

                        <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;"></td>
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
                        <td class="tdT" style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left;"></td>
                    </tr>
                </table>
                <table id="tblOtherItemContainer" class="main_table" cellspacing="0" cellpadding="2px">
                </table>
            </div>
            <div class="eachform" style="width: 47%;">
                <h2 style="margin-top: 1%;">Comments</h2>
                <asp:TextBox ID="txtComments" class="form1" Height="80px" Width="276px" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtAddress,450);" onkeyup="textCounter(cphMain_txtAddress,450);" onblur="textCounter(cphMain_txtAddress,450);"></asp:TextBox>
            </div>

            <br />
            <div class="eachform" style="margin-top: 3%;">
                <div class="subform" style="width: 60%;">
                     <asp:Button ID="btnApprove" runat="server" class="save" Text="Approve" OnClientClick="return validateClearanceForm();" OnClick="btnApprove_Click" />
                       <asp:Button ID="btnReject" runat="server" class="save" Text="Reject" OnClientClick="return RejectClearanceForm();" OnClick="btnReject_Click" />
                    <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                </div>
            </div>


        </div>
    </div>
</asp:Content>
