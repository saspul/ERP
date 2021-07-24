<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Traffic_Violation_Settlement_Dtl.aspx.cs" Inherits="AWMS_AWMS_Transaction_gen_Traffic_Violation_Settlement_gen_Traffic_Violation_Settlement_Dtl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
   
    <script>
        var TotalSettleAmount = 0;
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function calcAmount(RowCount) {
           
            TotalSettleAmount = 0;
            for (i = 0; i < RowCount; i++) {
                if (document.getElementById('txtSettleAmnt' + i).value != "") {
                    var AmtWithoutReplace = document.getElementById('txtSettleAmnt' + i).value;
                    var AmtWitoutComma = AmtWithoutReplace.replace(/,/g, "");
                    
                    TotalSettleAmount = parseFloat(TotalSettleAmount) + parseFloat(AmtWitoutComma);
                }
                
                
            }
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            if (FloatingValue != "") {
                TotalSettleAmount = TotalSettleAmount.toFixed(FloatingValue);
            }
            document.getElementById("<%=hiddenReceiptAmt.ClientID%>").value = TotalSettleAmount;
            document.getElementById("<%=lblReceiptAmount.ClientID%>").innerHTML = addCommas(TotalSettleAmount);
        }
        function toggleCheckbox(x, SettleAmount,RowCount) {
            //alert(x);
            //txtSettleAmnt0
            //hiddenDecimalCount
           

            //Start:-EMP-0009

            var rowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
            for (i = 0; i < rowCount; i++) {
                if (document.getElementById('cbxSettle' + i).checked==true) {
                    document.getElementById("<%=txtReceiptNo.ClientID%>").disabled = false;

                    $("div#divDdlEmployee input.ui-autocomplete-input").attr("disabled", false);
                    break;
                }
                else {
                    document.getElementById("<%=txtReceiptNo.ClientID%>").disabled = true;
                    $("div#divDdlEmployee input.ui-autocomplete-input").attr("disabled", true);
                }
            }
            //End:-EMP-0009


            
            if (document.getElementById('txtSettleAmnt' + x).disabled == false) {
                document.getElementById('txtSettleAmnt' + x).disabled = true;
                document.getElementById('txtSettledDate' + x).disabled = true;
                //TotalSettleAmount = parseFloat(TotalSettleAmount)-parseFloat(SettleAmount);
                document.getElementById('txtSettleAmnt' + x).value = "";
                document.getElementById("<%=txtReceiptNo.ClientID%>").disabled = true;
                document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
            }
            else {
                document.getElementById('txtSettleAmnt' + x).value =SettleAmount;
                AmountCheck('txtSettleAmnt' + x);
                //TotalSettleAmount = parseFloat(TotalSettleAmount) + parseFloat(SettleAmount);
                document.getElementById('txtSettleAmnt' + x).disabled = false;
                document.getElementById('txtSettledDate' + x).disabled = false;
                document.getElementById("<%=txtReceiptNo.ClientID%>").disabled = false;
                document.getElementById("<%=ddlEmployee.ClientID%>").disabled = false;
                //alert(TotalSettleAmount);

            }
            
            calcAmount(RowCount);
        }
        function isNumber(evt, textboxid) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            var txtPerVal = document.getElementById(textboxid).value;
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
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
                // . period and numpad . period
            else if (keyCodes == 190 || keyCodes == 110) {
                var ret = true;

                var count = txtPerVal.split('.').length - 1;

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
        function AmountCheck(textboxid) {
            var txtPerVal = (document.getElementById(textboxid).value).split(',').join('');
            if (txtPerVal == "") {
                return false;
            }
            else {
                if (!isNaN(txtPerVal) == false) {
                    document.getElementById('' + textboxid + '').value = "";
                    return false;
                }
                else {
                    if (txtPerVal < 0) {
                        document.getElementById('' + textboxid + '').value = "";
                        return false;
                    }
                    var amt = parseFloat(txtPerVal);
                    var num = amt;
                    var n = 0;
                    // for floatting number adjustment from corp global
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);
                    }
                   

                    document.getElementById('' + textboxid + '').value = addCommas(n);

                }
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
        function test() {
            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
           
            var strCbxVal = "";
            var strTrvID = "";
            var strTrvStlID = "";

            var strAmntList = "";
            for (i = 0; i < RowCount; i++) {
                if (document.getElementById('cbxSettle' + i).checked) {
                    var AmtWithoutReplace = document.getElementById('txtSettleAmnt' + i).value;
                    var AmtWitoutComma = AmtWithoutReplace.replace(/,/g, "");
                    strCbxVal = document.getElementById('cbxSettle' + i).value;
                    fields = strCbxVal.split("_");
                    strTrvID =strTrvID+ fields[0]+",";
                    strTrvStlID = strTrvStlID + fields[1] + ",";
                    strAmntList = strAmntList + AmtWitoutComma + ",";
                }
                
            }
            alert(strTrvID);
            alert(strTrvStlID);
            alert(strAmntList);

        }
        // Function to check letters and numbers  
        function alphanumeric(inputtxt)  
        {  
            var letterNumber = /^[0-9a-zA-Z]+$/;  
            if((inputtxt.value.match(letterNumber)))  
            {  
                return true;  
            }  
            else  
            {   
                //alert("message");   
                return false;   
            }  
        }  
        function validateSettlement(obj)
        {
            var $noCong = jQuery.noConflict();
            
            $noCon("div#divDdlEmployee input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById("<%=txtReceiptNo.ClientID%>").style.borderColor = "";
            rowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
           
                strReceiptNo = document.getElementById("<%=txtReceiptNo.ClientID%>").value;
            strReceiptAmnt = document.getElementById("<%=hiddenReceiptAmt.ClientID%>").value;
            ret = true;
            for (i = 0; i < rowCount; i++) {
                document.getElementById('txtSettleAmnt' + i).style.borderColor = "";
                document.getElementById('txtSettledDate' + i).style.borderColor = "";

            }
            if (strReceiptNo != "") {
                if (alphanumeric(document.getElementById("<%=txtReceiptNo.ClientID%>"))) {

                }
                else {
                    CustomErrorMsg('Invalid characters in Receipt No');
                    document.getElementById("<%=txtReceiptNo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtReceiptNo.ClientID%>").focus();
                    ret = false;
                }
                if (CheckDupReceiptNoByID() == false) {
                    CustomErrorMsg('Duplicate Receipt Number');
                    document.getElementById("<%=txtReceiptNo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtReceiptNo.ClientID%>").focus();
                    ret = false;
                }

            }
            if (obj == 'Save') {
                strEmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;
                if (strEmpId == "--SELECT--") {

                    $noCong("div#divDdlEmployee input.ui-autocomplete-input").css("borderColor", "Red");
                    $noCong("div#divDdlEmployee input.ui-autocomplete-input").focus();
                    $noCong("div#divDdlEmployee input.ui-autocomplete-input").select();
                    document.getElementById("<%=ddlEmployee.ClientID%>").focus();
                InputDataErrorMsg();
                    //alert('strEmpId');
                ret = false;
            }
             }
            
            if (strReceiptNo=="")
            {
                //alert('strReceiptNo');
                InputDataErrorMsg();
                document.getElementById("<%=txtReceiptNo.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtReceiptNo.ClientID%>").focus();
                ret = false;
            }
            
            if (strReceiptAmnt <= 0) {
                //alert('strReceiptAmnt');
                CustomErrorMsg('Settled Amount must be greater than zero');
                ret = false;
            }
            flag = 0;
            for (i = 0; i < rowCount; i++) {
                if (document.getElementById('cbxSettle' + i).checked) {
                    flag = 1;
                    break;
                }
            }
            if (flag == 0) {
                //alert('No violation selected');
                InputDataErrorMsg();
                CustomErrorMsg('No violation selected');
                for (i = 0; i < rowCount; i++) {
                    document.getElementById('txtSettleAmnt' + i).style.borderColor = "Red";
                }
                document.getElementById('cbxSettle' + 0).focus();
                ret = false;

            }

            for (i = 0; i < rowCount; i++) {
                if (document.getElementById('cbxSettle' + i).checked) {
                    if (document.getElementById('txtSettledDate' + i).value == "") {

                        CustomErrorMsg('Please enter settled date');
                        document.getElementById('txtSettledDate' + i).style.borderColor = "Red";
                        ret = false;
                    }
                    
                }
            }

           
            return ret;
            
        }
        function ReOpenTrafficViolation() {
            if (confirm("Do you want to Re-Open this Entry?")) {
                
                    var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;

                    var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                    var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
                    var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;


                    var strCbxVal = "";
                    var strTrvID = "";
                    var strTrvDtlID = "";
                    var strAmntList = "";
                    var strEmpId = "0";
                    var strReceiptNo = "";
                    for (i = 0; i < RowCount; i++) {
                        if (document.getElementById('cbxSettle' + i).checked) {
                            var AmtWithoutReplace = document.getElementById('txtSettleAmnt' + i).value;
                            var AmtWitoutComma = AmtWithoutReplace.replace(/,/g, "");
                            strCbxVal = document.getElementById('cbxSettle' + i).value;
                            fields = strCbxVal.split("_");
                            strTrvID = strTrvID + fields[0] + ",";
                            strTrvDtlID = strTrvDtlID + fields[1] + ",";
                            strAmntList = strAmntList + AmtWitoutComma + ",";
                        }

                    }
                    
                    strReceiptNo = document.getElementById("<%=txtReceiptNo.ClientID%>").value;
                    strReceiptAmnt = document.getElementById("<%=hiddenReceiptAmt.ClientID%>").value;
                    //string stores Receipt No(0), Employee id(1),ReceiptAmnt(2),VehicleId(3),UserId (4),OrgId(5),CorpId(6)

                    strDtlList = strReceiptNo + "," + strEmpId + "," + strReceiptAmnt;
                    strDtlList = strDtlList + "," + document.getElementById("<%=hiddenVehicleId.ClientID%>").value;
                    strDtlList = strDtlList + "," + UserId + "," + OrgId + "," + CorpId;
                    $co = jQuery.noConflict();
                    $co.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "gen_Traffic_Violation_Settlement_Dtl.aspx/ReOpenTrafficViolation",
                        data: '{strTrvID:"' + strTrvID + '",strTrvDtlID:"' + strTrvDtlID + '",strAmntList:"' + strAmntList + '",strDtlList:"' + strDtlList + '"}',


                        dataType: "json",
                        success: function (data) {

                            if (data.d == "success") {
                                setTimeout(RedirectAfterSave(2), 3000);
                                return false;

                            }
                           
                            else {


                                setTimeout(RedirectAfterSave(5), 3000);
                            }
                        },
                        error: function (response) {

                        }

                    });
                    return false;
               

 }
 else {
     return false;
 }

}
        function ConfirmSettlement()
        {
            if (validateSettlement("Confirm")==true) {

                if (confirm("Are you sure you want to Confirm ?")) {
                    var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;

                    var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                    var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
                    var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;


                    var strCbxVal = "";
                    var strTrvID = "";
                    var strTrvDtlID = "";
                    var strAmntList = "";
                    var strEmpId = "";
                    var strReceiptNo = "";
                    var strStldDate = "";
                    for (i = 0; i < RowCount; i++) {
                        if (document.getElementById('cbxSettle' + i).checked) {
                            var AmtWithoutReplace = document.getElementById('txtSettleAmnt' + i).value;
                            var AmtWitoutComma = AmtWithoutReplace.replace(/,/g, "");
                            var stldDate = document.getElementById('txtSettledDate' + i).value;
                            strCbxVal = document.getElementById('cbxSettle' + i).value;
                            fields = strCbxVal.split("_");
                            strTrvID = strTrvID + fields[0] + ",";
                            strTrvDtlID = strTrvDtlID + fields[1] + ",";
                            strAmntList = strAmntList + AmtWitoutComma + ",";
                            strStldDate = strStldDate + stldDate + ",";
                        }

                    }
                    
                    strEmpId = "0";
                    strReceiptNo = document.getElementById("<%=txtReceiptNo.ClientID%>").value;
                    strReceiptAmnt = document.getElementById("<%=hiddenReceiptAmt.ClientID%>").value;
                    //string stores Receipt No(0), Employee id(1),ReceiptAmnt(2),VehicleId(3),UserId (4),OrgId(5),CorpId(6)

                    strDtlList = strReceiptNo + "," + strEmpId + "," + strReceiptAmnt;
                    strDtlList = strDtlList + "," + document.getElementById("<%=hiddenVehicleId.ClientID%>").value;
                    strDtlList = strDtlList + "," + UserId + "," + OrgId + "," + CorpId;
                    $co = jQuery.noConflict();
                    $co.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "gen_Traffic_Violation_Settlement_Dtl.aspx/ConfirmSettlement",
                        data: '{strTrvID:"' + strTrvID + '",strTrvDtlID:"' + strTrvDtlID + '",strAmntList:"' + strAmntList + '",strDtlList:"' + strDtlList + '",strStldDate:"' + strStldDate + '"}',


                        dataType: "json",
                        success: function (data) {

                            if (data.d == "success") {
                                setTimeout(RedirectAfterSave(1), 3000);
                                return false;

                            }
                            else if (data.d == "Duplicate") {
                                DuplicateReceiptNo();
                                return false;
                            }
                            else {


                                setTimeout(RedirectAfterSave(5), 3000);
                            }
                        },
                        error: function (response) {

                        }

                    });
                    return false;

                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
        function RedirectAfterSave(status)
        {
            //status 0 for saved and 1 for confirmed
            if (document.getElementById("<%=hiddenViewStatus.ClientID%>").value == "Pending") {
                if (status == 0) {
                    //saved
                    window.location = 'gen_Traffic_Violation_Settlement_List.aspx?Save=1&View=Pending';
                }
                else if (status == 1)
                {
                    //confirmed
                    window.location = 'gen_Traffic_Violation_Settlement_List.aspx?Save=2&View=Pending';
                }
                else if (status == 2) {
                    //reopened
                    window.location = 'gen_Traffic_Violation_Settlement_List.aspx?Save=3&View=Pending';
                }
                else {
                    window.location = 'gen_Traffic_Violation_Settlement_List.aspx?View=Pending';
                }
            }
            else if (document.getElementById("<%=hiddenViewStatus.ClientID%>").value == "Settled") {
                if (status == 0) {
                    //saved
                   
                    window.location.href = 'gen_Traffic_Violation_Settlement_List.aspx?Save=1&View=Settled';
                    return false;
                }
                else if (status == 1) {
                    //confirmed
                    window.location = 'gen_Traffic_Violation_Settlement_List.aspx?Save=2&View=Settled';
                }
                else if (status == 2) {
                    //reopened
                    window.location = 'gen_Traffic_Violation_Settlement_List.aspx?Save=3&View=Settled';
                }
                else {
                    window.location = 'gen_Traffic_Violation_Settlement_List.aspx?View=Settled';
                }
            }
            else {
                window.location = 'gen_Traffic_Violation_Settlement_List.aspx';
            }

           
        }
        function ConfirmSave() {
            strSaveStatus = document.getElementById("<%=hiddenSaveStatus.ClientID%>").value;
            if (validateSettlement(strSaveStatus)==true) {
                if (confirm("Do you want to Save?")) {
                    var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;

                    var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                    var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
                    var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;


                    var strCbxVal = "";
                    var strTrvID = "";
                    var strTrvDtlID = "";
                    var strAmntList = "";
                    var strEmpId = "";
                    var strReceiptNo = "";
                    var strSettldDate = "";

                    for (i = 0; i < RowCount; i++) {
                        if (document.getElementById('cbxSettle' + i).checked) {

                            var settldDate = document.getElementById('txtSettledDate' + i).value;
                            var AmtWithoutReplace = document.getElementById('txtSettleAmnt' + i).value;
                            var AmtWitoutComma = AmtWithoutReplace.replace(/,/g, "");
                            strCbxVal = document.getElementById('cbxSettle' + i).value;
                            fields = strCbxVal.split("_");
                            strTrvID = strTrvID + fields[0] + ",";
                            strTrvDtlID = strTrvDtlID + fields[1] + ",";
                            strAmntList = strAmntList + AmtWitoutComma + ",";
                            strSettldDate = strSettldDate + settldDate + ",";
                        }

                    }
                    if (strSaveStatus == 'Save') {
                        strEmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;
                    }
                    else {
                        strEmpId = "0";
                    }
                    strReceiptNo = document.getElementById("<%=txtReceiptNo.ClientID%>").value;
                    strReceiptAmnt = document.getElementById("<%=hiddenReceiptAmt.ClientID%>").value;
                    //string stores Receipt No(0), Employee id(1),ReceiptAmnt(2),VehicleId(3),UserId (4),OrgId(5),CorpId(6)

                    strDtlList = strReceiptNo + "," + strEmpId + "," + strReceiptAmnt;
                    strDtlList = strDtlList + "," + document.getElementById("<%=hiddenVehicleId.ClientID%>").value;
                    strDtlList = strDtlList + "," + UserId + "," + OrgId + "," + CorpId;
                    

                 
                    var ResultFlag = "fail";
                    $Ko = jQuery.noConflict();
                    $Ko.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "gen_Traffic_Violation_Settlement_Dtl.aspx/ConfirmSave",
                        data: '{strTrvID:"' + strTrvID + '",strTrvDtlID:"' + strTrvDtlID + '",strAmntList:"' + strAmntList + '",strDtlList:"' + strDtlList + '",strSaveStatus:"' + strSaveStatus + '",strStldDateList:"' + strSettldDate + '"}',
                        //data: '{strCorpId:"' + CorpId + '"}',

                        dataType: "json",
                        success: function (data) {

                            if (data.d == "success") {
                                //RedirectAfterSave(1);

                                RedirectAfterSave(0);
                                //window.location.href = 'gen_Traffic_Violation_Settlement_List.aspx?Save=1';
                                return false;
                            }
                            else if (data.d == "Duplicate") {
                                DuplicateReceiptNo();
                                return false;
                            }
                            else {
                                //failed
                                RedirectAfterSave(5);
                                //window.location.href = 'gen_Traffic_Violation_Settlement_List.aspx?Save=0';
                                return false;
                            }
                        }

                    });

                    return false;

                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
        //obj Save to check while save 
        function CheckDupReceiptNo(obj) {
            //alert('CheckDupReceiptNo');
            ret = false;
            var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;

          var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
            var VhclId = 0;
            var receiptAmount = 0;
            //obj = 0;
            if (obj != "Save") {
                VhclId = document.getElementById("<%=hiddenVehicleId.ClientID%>").value;

                    receiptAmount = document.getElementById("<%=hiddenReceiptAmt.ClientID%>").value;

                }
                var strReceiptNo = document.getElementById("<%=txtReceiptNo.ClientID%>").value;

           
            $cod = jQuery.noConflict();

            $cod.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Traffic_Violation_Settlement_Dtl.aspx/CheckDupReceiptNo",
                    data: '{intOrgId:"' + parseInt(OrgId) + '",intCorpId:"' + parseInt(CorpId) + '",intVhclId:"' + parseInt(VhclId) + '",strReceiptNo:"' + strReceiptNo + '",decReceiptAmount:"' + parseFloat(receiptAmount) + '",strStatus:"' + obj + '"}',
                    //data: '{intOrgId:"' + parseInt(OrgId) + '"}',


                    dataType: "json",
                    success: function (data) {

                        if (data.d == "0") {
                            //Valid Receipt No.
                            //alert('Valid');
                            ret = true;

                        }

                        else {
                            //Duplicate
                            //alert('Duplicate');
                           // document.getElementById("<%=txtReceiptNo.ClientID%>").style.borderColor = "Red";

                            //document.getElementById('ErrorMsgReceiptNo').style.visibility = "visible";

                            ret = false;
                        }
                    },
                    error: function (response) {
                        ret = false;
                    }

                });
                return ret;
        }
        //check by id
        function CheckDupReceiptNoByID() {
            ret = false;
                var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;

                var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
                var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;


                var strCbxVal = "";
                var strTrvID = "";
                var strTrvDtlID = "";
                var strAmntList = "";
                var strEmpId = "";
                var strReceiptNo = "";
                for (i = 0; i < RowCount; i++) {
                    if (document.getElementById('cbxSettle' + i).checked) {
                        var AmtWithoutReplace = document.getElementById('txtSettleAmnt' + i).value;
                        var AmtWitoutComma = AmtWithoutReplace.replace(/,/g, "");
                        strCbxVal = document.getElementById('cbxSettle' + i).value;
                        fields = strCbxVal.split("_");
                        strTrvID = strTrvID + fields[0] + ",";
                        strTrvDtlID = strTrvDtlID + fields[1] + ",";
                        strAmntList = strAmntList + AmtWitoutComma + ",";
                    }

                }
                //strEmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;
            strEmpId = "0";
            strReceiptNo = document.getElementById("<%=txtReceiptNo.ClientID%>").value;
                strReceiptAmnt = document.getElementById("<%=hiddenReceiptAmt.ClientID%>").value;
                //string stores Receipt No(0), Employee id(1),ReceiptAmnt(2),VehicleId(3),UserId (4),OrgId(5),CorpId(6)

                strDtlList = strReceiptNo + "," + strEmpId + "," + strReceiptAmnt;
                strDtlList = strDtlList + "," + document.getElementById("<%=hiddenVehicleId.ClientID%>").value;
                strDtlList = strDtlList + "," + UserId + "," + OrgId + "," + CorpId;
                $co = jQuery.noConflict();
                $co.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Traffic_Violation_Settlement_Dtl.aspx/CheckDupReceiptNoByID",
                    data: '{strTrvID:"' + strTrvID + '",strTrvDtlID:"' + strTrvDtlID + '",strAmntList:"' + strAmntList + '",strDtlList:"' + strDtlList + '"}',


                    dataType: "json",
                    success: function (data) {

                        if (data.d == "success") {
                            //setTimeout(RedirectAfterSave(2), 3000);
                            //alert('valid');
                            ret= true;

                        }
                        else if (data.d == "Duplicate") {
                            //DuplicateReceiptNoOnReOpen();
                            //alert('Duplicate');
                            ret= false;
                        }
                        
                    },
                    error: function (response) {

                    }

                });
                return ret;

            

        }
        function ConfirmClear() {
            if (confirmbox > 0) {
                if (confirm("Do you want to clear?")) {
                    // window.location = href;
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        function ConfirmMessage() {
            //hiddenViewStatus
            if (confirmbox > 0)
                {
                if (confirm("Are You Sure You Want To Leave This Page?")) {
                    if (document.getElementById("<%=hiddenViewStatus.ClientID%>").value == "Pending") {
                        window.location.href = 'gen_Traffic_Violation_Settlement_List.aspx?View=Pending';
                        return false;
                    }
                    else {
                        window.location.href = 'gen_Traffic_Violation_Settlement_List.aspx?View=Settled';
                        return false;
                    }

                }
                else {
                    return false;
                }
        }
            else {
                if (document.getElementById("<%=hiddenViewStatus.ClientID%>").value == "Pending") {
                    window.location.href = 'gen_Traffic_Violation_Settlement_List.aspx?View=Pending';
                    return false;
                }
                else {
                    window.location.href = 'gen_Traffic_Violation_Settlement_List.aspx?View=Settled';
                    return false;
                }
                return false;
            }
        }
        function DuplicateReceiptNo() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Receipt Number Can’t be Duplicated.";
            
            document.getElementById("<%=txtReceiptNo.ClientID%>").focus();
        }
        
        function DuplicateReceiptNoOnReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Receipt Number Can’t be Duplicated.";

        }
        function InputDataErrorMsg() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

        }
        function CustomErrorMsg(strErrorMsg) {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = strErrorMsg;

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
        
        function RemoveTag(obj) {
            var txt = document.getElementById(obj).value;
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2;

        }

        function blurDate(obj) {
         
            var Rcptdate = document.getElementById(obj).value;
            document.getElementById(obj).style.borderColor = "";
            if (Rcptdate != "") {
                var RcptdatepickerDate = Rcptdate;
                var RarrDatePickerDate = RcptdatepickerDate.split("/");
                var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);


                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
               

                if (RdateDateCntrlr > dateCurrentDate) {
                    document.getElementById(obj).value = "";
                    document.getElementById(obj).style.borderColor = "Red";
                    document.getElementById(obj).focus();
                    CustomErrorMsg('Sorry, Settled Date cannot be Greater than Current Date !.');
                    return false;
                }
            }
        }

 </script>
  
        <style type="text/css">
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
                  .divSettlmntDetls {
            font-family: Calibri;
            padding-bottom: 2%;
            overflow-x: auto;
            background: #f4f6f0;
            margin: 0 0 5px;
            border: 1px solid #9BA48B;
        }
                  .cont_rght {
            width: 99.5%;
        }
    </style>
    

    
    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link rel="stylesheet" href="../../../css/Autocomplete/jquery-ui.css" />


    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>


      <script src="/JavaScript/datepicker/bootstrap-datepicker.js"></script>

    <link href="/JavaScript/datepicker/datepicker3.css" rel="stylesheet" />
      <script type="text/javascript">



          



          var $noConf = jQuery.noConflict();
          
          $noConf(window).load(function () {
             
              var rowCount = $noConf('#ReportTable tr').length - 1;

              for (var i = 0; i < rowCount; i++) {
                  $noConf('#txtSettledDate' + i).datepicker({
                      autoclose: true,
                      format: 'dd/mm/yyyy',
                      language: 'en',
                      endDate: new Date(),
                  });

                  AmountCheck("txtSettleAmnt" + i);
                

                  var txtPerVal = (document.getElementById("vltnAmnt" + i).innerHTML).split(',').join('');
                  if (txtPerVal == "") {
                      return false;
                  }
                  else {
                      if (!isNaN(txtPerVal) == false) {
                          document.getElementById("vltnAmnt" + i).innerHTML = "";
                          return false;
                      }
                      else {
                          if (txtPerVal < 0) {
                              document.getElementById("vltnAmnt" + i).innerHTML = "";
                              return false;
                          }
                          var amt = parseFloat(txtPerVal);
                          var num = amt;
                          var n = 0;
                          // for floatting number adjustment from corp global
                          var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);
                    }


                    document.getElementById("vltnAmnt" + i).innerHTML = addCommas(n) + " " + document.getElementById("<%=HiddenFieldSymbl.ClientID%>").value;;

                }
            }
              }


              $('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
              calcAmount(document.getElementById("<%=hiddenRowCount.ClientID%>").value);
              //Start:-EMP-0009
              document.getElementById("<%=txtReceiptNo.ClientID%>").disabled = true;
              $("div#divDdlEmployee input.ui-autocomplete-input").attr("disabled", true);
              //End:-EMP-0009
          });


                    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
        <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenRowCount" runat="server" />
    <asp:HiddenField ID="hiddenVehicleId" runat="server" />
    <asp:HiddenField ID="hiddenReceiptAmt" runat="server" />
    <asp:HiddenField ID="hiddenViewStatus" runat="server" />
      <asp:HiddenField ID="hiddenCurrentDate" runat="server" />  
    <asp:HiddenField ID="hiddenSaveStatus" runat="server" />

      <asp:HiddenField ID="HiddenFieldSymbl" runat="server" />
        
    <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:.5%; top:25%;height:26.5px;"></div>
    <div class="cont_rght" style="width: 93%;" >

            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
               <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
   
        <br />
           <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
          

        
           <div id="divVehicleNumber" style="width: 45%; margin-top: 2.2%;" class="eachform">
            <h2 style=" float: left; padding-right: 3%;">Vehicle Number:</h2>
<asp:Label ID="lblVheNo" Style="font-family: Calibri;color: #909c7b;" runat="server"></asp:Label>
        </div>
   

        <div id="divReport" class="table-responsive" runat="server">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        
              <div class="divSettlmntDetls" style="margin-top: 1%;padding-bottom: 1%;">
                 <div style="margin-top:1%;margin-left:1%;width: 93%;">
                     <h2 style="font-size: 17px;margin: 0 0 0px;" >Settlement Details </h2>
                     </div>
                 <div id="divStld" style="margin-top:3%;float:left;width: 93%;">
                     <h2 style="font-size: 17px;margin-left: 12px;">Receipt Number *</h2>
                   <asp:TextBox ID="txtReceiptNo" class="form1" runat="server" onkeypress="return isTag(event);" MaxLength="50"  Style="margin-left: 20px;text-transform: uppercase;float: left;" onblur="return RemoveTag('cphMain_txtReceiptNo');" ></asp:TextBox>
                     <div id="divDdlEmployee">
                         <div id="divHiddenDdlEmploee" runat="server" visible="false">
<h2 style="font-size: 17px;margin-left: 3%;">Settled By *</h2>
                <asp:DropDownList ID="ddlEmployee" class="form1" runat="server" Style="float: left;margin-left: 20px;" onkeypress="return isTag(event);" ></asp:DropDownList>
                  

                         </div>
                     </div>
                      <h2 style="font-size: 17px;margin-left: 3%;">Receipt Amount </h2>
                    <asp:Label ID="lblReceiptAmount" runat="server" style="color: red;font-weight: bold;margin-left: 1%;" >0.00</asp:Label>
                           <asp:Label ID="lblCurrencyAbbr" runat="server" style="color: red;font-weight: bold;margin-left: 0%;" ></asp:Label>   
                 </div>
                  
                 
                  <div style="margin-top: 3%;float:right;width: 93%;">
                      
                  </div> 
                 
                  
            </div>       
             <div id="div3" style="margin-top:3%;float:right;">
                <%--<input type="submit" name="name" onclick="ConfirmSave();" value="ok " />--%>
                     <asp:Button ID="btnSave" runat="server" class="save" Text="Save" OnClientClick="return ConfirmSave();"  />
                     <asp:Button ID="btnConfirm" runat="server" class="save" Visible="false" Text="Confirm" OnClientClick="return ConfirmSettlement();"  />
                     <asp:Button ID="btnReOpen" runat="server" class="save" Visible="false" Text="Re-Open"  OnClientClick="return ReOpenTrafficViolation();"  />

                     <asp:Button ID="btnClear" runat="server" onclicK="btnClear_Click"  OnClientClick="return ConfirmClear();" class="save" Text="Clear" />
                     <asp:Button ID="btnCancel" runat="server" class="save"  OnClientClick="return ConfirmMessage();"  Text="Cancel" />
                  <%-- <input type="submit" name="name" value="Save" onclick="return CheckDupReceiptNoByID();"  />
                    <input type="submit" name="name" value="Update" onclick="return CheckDupReceiptNo('Update');"  />--%>
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

