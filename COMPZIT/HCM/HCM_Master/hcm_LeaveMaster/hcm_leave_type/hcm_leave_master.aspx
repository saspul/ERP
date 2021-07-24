<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_leave_master.aspx.cs" Inherits="HCM_HCM_Master_hcm_leave_type_hcm_leave_master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">



    <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>
    <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
    <link href="/JavaScript/multiselect/AdminLTE.min.css" rel="stylesheet" />
    <style>
        input[type="radio"] {
            display: block;
            float: left;
            font-family: Calibri;
        }
    </style>


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
    <script>

 
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function ConfirmMessage() {
           
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "hcm_leave_master_list.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                //alert();
                window.location.href = "hcm_leave_master_list.aspx";
                return false;
            }
        }

        function isNumber(evt) {
          
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //alert(charCode);
          //  var txtPerVal = document.getElementById(textboxid).value;
            //enter
            if (keyCodes == 13 || keyCodes == 110) {
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
                var ret = false;


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
        function CalenderDaysChange() {
            if (document.getElementById("cphMain_RbCalendar").checked == true) {
                document.getElementById("cphMain_cbxHoliPaid").checked = false;
                document.getElementById("cphMain_cbxOffPaid").checked = false;
                document.getElementById("cphMain_cbxHoliPaid").disabled = true;
                document.getElementById("cphMain_cbxOffPaid").disabled = true;
            }
            else {
                document.getElementById("cphMain_cbxHoliPaid").disabled = false;
                document.getElementById("cphMain_cbxOffPaid").disabled = false;
            }
        }


        function AlertClearAll() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    window.location.href = "hcm_leave_master.aspx";

                    $('input[type="text"]').val('');
                    document.getElementById("<%=hiddenselectedDesignlist.ClientID%>").value = "";
                    document.getElementById("<%=hiddenselectedPaygradelist.ClientID%>").value = "";
                    document.getElementById("<%=hiddenselectedExperiencelist.ClientID%>").value="";

                    document.getElementById('cphMain_ddlmodeSearch').value =null;
                    document.getElementById('cphMain_ddlpay').value = "";
                    document.getElementById('cphMain_ddlexp').value = "";
                    document.getElementById('cphMain_cbxTravel').checked = false;
                    document.getElementById('cphMain_cbxleave').checked = false;
                    document.getElementById('cphMain_Rbwrkgday').checked = false;
                    document.getElementById('cphMain_RbCalendar').checked = false;
                    document.getElementById('cphMain_RbMale').checked = false;
                    document.getElementById('cphMain_RBfemale').checked = false;
                    document.getElementById('cphMain_RbBoth').checked = false;
                    document.getElementById('cphMain_Rbsingle').checked = false;
                    document.getElementById('cphMain_RBMarried').checked = false;
                    document.getElementById('cphMain_Rbbothmarital').checked = false;

                    document.getElementById('cphMain_cbxAll1').checked = false;
                    document.getElementById('cphMain_cbxAll2').checked = false;
                    document.getElementById('cphMain_cbxAll3').checked = false;
                    document.getElementById('cphMain_CbxStatus').checked = false;

             
  
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_leave_master.aspx";

            }
        }






    </script>



    <script type="text/javascript">

        function DuplicationLeavAbsnc() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. leave on absence already exists.";
        }


        function DuplicationName() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=TypNme.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Leave Type Name Can’t be Duplicated.";
        }



        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Type Details Inserted Successfully.";
          }

          function SuccessUpdation() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Type Details Updated Successfully.";
            }

            function SuccessReOpen() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Type Details ReOpened Successfully.";
            }

            function SuccessConfirm() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Type Details Confirmed Successfully.";
            }

        function LeaveTypeValidate() {
            selected();

            var $noCon = jQuery.noConflict();
            var ret = true;
            if (CheckIsRepeat() == true) {

            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags 

            var CrdNumWithoutReplace = document.getElementById("<%=TypNme.ClientID%>").value;
            var replaceText1 = CrdNumWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var ddldesignationvalues;
            var ddlPaygradevalues;
            var ddlexpvalues;
            var sel = "";
            //  alert($noCon2('#cphMain_ddlmodeSearch').val());

            ddldesignationvalues = $noCon2('#cphMain_ddlmodeSearch').val();
            ddlPaygradevalues = $noCon2('#cphMain_ddlpay').val();
            ddlexpvalues = $noCon2('#cphMain_ddlexp').val();

            document.getElementById("<%=TypNme.ClientID%>").value = replaceText2;

            var CrdExpWithoutReplace = document.getElementById("<%=NumDays.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=NumDays.ClientID%>").value = replaceCode2;

            document.getElementById("<%=TypNme.ClientID%>").style.borderColor = "";
            document.getElementById("<%=NumDays.ClientID%>").style.borderColor = "";
            //   $noCon("div#divBank input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("expdiv").style.border = "0px solid red";
            document.getElementById("paygrddiv").style.border = "0px solid red";
            document.getElementById("divsrch").style.border = "0px solid red";



            var CardNum = document.getElementById("<%=TypNme.ClientID%>").value.trim();
            var HolDat = document.getElementById("<%=NumDays.ClientID%>").value.trim();
            ///    var desig = document.getElementById("<%=ddlmodeSearch.ClientID%>").value();
            //  var paygrd = document.getElementById("<%=ddlpay.ClientID%>").value();
            //  var exprnc = document.getElementById("<%=ddlexp.ClientID%>").value();

            var CardNum = document.getElementById("<%=TypNme.ClientID%>").value.trim();

            if (document.getElementById("<%=cbxNone.ClientID%>").checked == false) {
                if (document.getElementById("<%=cbxAll1.ClientID%>").checked == false && ddldesignationvalues == "" && document.getElementById("<%=cbxAll2.ClientID%>").checked == false && (ddlPaygradevalues == "" || ddlPaygradevalues == "--SELECT PAYGRADE--") && document.getElementById("<%=cbxAll3.ClientID%>").checked == false && ddlexpvalues == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    ret = false;
                    document.getElementById("divsrch").style.border = "1px solid red";
                    document.getElementById("paygrddiv").style.border = "1px solid red";
                    document.getElementById("paygrddiv").style.borderColor = "red";
                    //  document.getElementById("divsrch").style.borderColor = "red";
                    document.getElementById("expdiv").style.border = "1px solid red";
                    document.getElementById("expdiv").style.borderColor = "red";
                }
            }

            if (HolDat != "") {
                var num = document.getElementById("<%=NumDays.ClientID%>").value;
                var max = 365;
                if (num > max) {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,Number Of Day Should Be Less Than or Equal to 365 !";
                    document.getElementById("<%=NumDays.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=NumDays.ClientID%>").focus();
                    ret = false;
                }
            }
            else {
                if (HolDat == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=NumDays.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=NumDays.ClientID%>").focus();
                    ret = false;
                }
                else {
                    document.getElementById("<%=NumDays.ClientID%>").style.borderColor = "";
                }
            }
            if (CardNum == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=TypNme.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=TypNme.ClientID%>").focus();
                ret = false;
            }
            else {
                document.getElementById("<%=TypNme.ClientID%>").style.borderColor = "";
            }

            if (ret == false) {
                CheckSubmitZero();
            }
            return ret;
        }
        function CbxChange(chkbox) {
            IncrmntConfrmCounter();
            if (chkbox == 'cbxAll1') {
                if (document.getElementById("<%=cbxAll1.ClientID%>").checked == true) {
                    document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlpay.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlexp.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll2.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll3.ClientID%>").disabled = true;
                    var newVar = "";
                    $p('#cphMain_ddlmodeSearch').val(newVar);
                    $p("#cphMain_ddlmodeSearch").trigger("change");
                    $p('#cphMain_ddlpay').val(newVar);
                    $p("#cphMain_ddlpay").trigger("change");
                    $p('#cphMain_ddlexp').val(newVar);
                    $p("#cphMain_ddlexp").trigger("change");
                }
                else {
                    document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlpay.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlexp.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll2.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll3.ClientID%>").disabled = false;
                }
            }
            else if (chkbox == 'cbxAll2') {
                if (document.getElementById("<%=cbxAll2.ClientID%>").checked == true) {
                    document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlpay.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlexp.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll1.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll3.ClientID%>").disabled = true;
                    var newVar = "";
                    $p('#cphMain_ddlmodeSearch').val(newVar);
                    $p("#cphMain_ddlmodeSearch").trigger("change");
                    $p('#cphMain_ddlpay').val(newVar);
                    $p("#cphMain_ddlpay").trigger("change");
                    $p('#cphMain_ddlexp').val(newVar);
                    $p("#cphMain_ddlexp").trigger("change");
                }
                else {
                    document.getElementById("<%=ddlpay.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlexp.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll1.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll3.ClientID%>").disabled = false;
                }
            }
            else if (chkbox == 'cbxAll3') {
                if (document.getElementById("<%=cbxAll3.ClientID%>").checked == true) {
                    document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlpay.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlexp.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll2.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll1.ClientID%>").disabled = true;
                    var newVar = "";
                    $p('#cphMain_ddlmodeSearch').val(newVar);
                    $p("#cphMain_ddlmodeSearch").trigger("change");
                    $p('#cphMain_ddlpay').val(newVar);
                    $p("#cphMain_ddlpay").trigger("change");
                    $p('#cphMain_ddlexp').val(newVar);
                    $p("#cphMain_ddlexp").trigger("change");
                }
                else {
                    document.getElementById("<%=ddlexp.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlpay.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll2.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll1.ClientID%>").disabled = false;
                }
            }
            else if (chkbox == 'cbxNone') {
                if (document.getElementById("<%=cbxNone.ClientID%>").checked == true) {
                    document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlpay.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlexp.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll2.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll1.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll3.ClientID%>").disabled = true;
                }
                else {
                    document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlpay.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlexp.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll2.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll1.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll3.ClientID%>").disabled = false;
                }
            }

        }

        function selectedValidate(field) {

            var ddldesignationvalues;
            var ddlPaygradevalues;
            var ddlexpvalues;
            ddldesignationvalues = $noCon2('#cphMain_ddlmodeSearch').val();
            ddlPaygradevalues = $noCon2('#cphMain_ddlpay').val();
            ddlexpvalues = $noCon2('#cphMain_ddlexp').val();
            if (field == 'ddlmodeSearch') {
                if (ddldesignationvalues != "") {
                    document.getElementById("<%=ddlpay.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlexp.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll1.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll2.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll3.ClientID%>").disabled = true;
                }
                else {
                    document.getElementById("<%=ddlpay.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlexp.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll1.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll2.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll3.ClientID%>").disabled = false;
                }
            }
            else if (field == 'ddlpay') {
                if (ddlPaygradevalues != "") {
                    document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlexp.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll1.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll2.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll3.ClientID%>").disabled = true;
                }
                else {
                    document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlexp.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll1.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll2.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll3.ClientID%>").disabled = false;
                }
            }
            else if (field == 'ddlexp') {
                if (ddlexpvalues != "") {
                    document.getElementById("<%=ddlpay.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll1.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll2.ClientID%>").disabled = true;
                    document.getElementById("<%=cbxAll3.ClientID%>").disabled = true;
                }
                else {
                    document.getElementById("<%=ddlpay.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll1.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll2.ClientID%>").disabled = false;
                    document.getElementById("<%=cbxAll3.ClientID%>").disabled = false;
                }
            }
        }
        //EVM-0027 08-02-2019
        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
           
            RemoveTag();
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {
                // isTag(event);
            }
        }
        //END
        function RemoveTag() {
           
            var SearchWithoutReplace = document.getElementById("<%=TypNme.ClientID%>").value;
            var replaceText1 = SearchWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TypNme.ClientID%>").value = replaceText2;

            var SearchWithoutReplace = document.getElementById("<%=NumDays.ClientID%>").value;
            var replaceText1 = SearchWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=NumDays.ClientID%>").value = replaceText2;

            var SearchWithoutReplace = document.getElementById("<%=txtDesc.ClientID%>").value;
            var replaceText1 = SearchWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDesc.ClientID%>").value = replaceText2;
        }
    
    </script>




    <script>


        function selectedSomethng() {

            {
                var abcd;
                abcd = document.getElementById("<%=ddlmodeSearch.ClientID%>").value;
       
                document.getElementById("<%=hiddensearchby.ClientID%>").value = "0";


       

            }

     

            return false;
        }



    </script>


    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />


    <script>
        var $p = jQuery.noConflict();
        var $pc = jQuery.noConflict();
        $pc(function () {
            if (document.getElementById("<%=cbxAll1.ClientID%>").checked != true && document.getElementById("<%=cbxAll2.ClientID%>").checked != true && document.getElementById("<%=cbxAll3.ClientID%>").checked != true) {
                $p("#cphMain_ddlmodeSearch").change(function () {
                    if (document.getElementById("<%=cbxAll1.ClientID%>").checked != true && document.getElementById("<%=cbxAll2.ClientID%>").checked != true && document.getElementById("<%=cbxAll3.ClientID%>").checked != true) {

                        selectedValidate('ddlmodeSearch');
                    }
                    });
                $p("#cphMain_ddlpay").change(function () {
                    if (document.getElementById("<%=cbxAll1.ClientID%>").checked != true && document.getElementById("<%=cbxAll2.ClientID%>").checked != true && document.getElementById("<%=cbxAll3.ClientID%>").checked != true) {

                        selectedValidate('ddlpay');
                    }
                    });
                $p("#cphMain_ddlexp").change(function () {
                    if (document.getElementById("<%=cbxAll1.ClientID%>").checked != true && document.getElementById("<%=cbxAll2.ClientID%>").checked != true && document.getElementById("<%=cbxAll3.ClientID%>").checked != true) {

                        selectedValidate('ddlexp');
                    }
                    });
               }

        });
        $p(document).ready(function () {
            //  $noCon2("#cphMain_ddlmodeSearch").val('').trigger("change");

            if (document.getElementById("<%=cbxAll1.ClientID%>").checked == true) {
                document.getElementById('cphMain_ddlmodeSearch').value = null;
                document.getElementById('cphMain_ddlpay').value = null;
                document.getElementById('cphMain_ddlexp').value = null;
            }
            if (document.getElementById("<%=cbxAll2.ClientID%>").checked == true) {
                document.getElementById('cphMain_ddlmodeSearch').value = null;
                document.getElementById('cphMain_ddlpay').value = null;
                document.getElementById('cphMain_ddlexp').value = null;
            }
            if (document.getElementById("<%=cbxAll3.ClientID%>").checked == true) {
                document.getElementById('cphMain_ddlmodeSearch').value = null;
                document.getElementById('cphMain_ddlpay').value = null;
                document.getElementById('cphMain_ddlexp').value = null;
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

                $p('#cphMain_ddlmodeSearch').val(newVar);
                $p("#cphMain_ddlmodeSearch").trigger("change");
            }
            else {
                document.getElementById('cphMain_ddlmodeSearch').value = null;
            }


            var data = document.getElementById("<%=hiddenselectedPaygradelist.ClientID%>").value;
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


                $p('#cphMain_ddlpay').val(newVar);
                $p("#cphMain_ddlpay").trigger("change");

            }
            else {
                document.getElementById('cphMain_ddlpay').value = "";
            }

            var data = document.getElementById("<%=hiddenselectedExperiencelist.ClientID%>").value;
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

                $p('#cphMain_ddlexp').val(newVar);
                $p("#cphMain_ddlexp").trigger("change");
            }
            else {
                document.getElementById('cphMain_ddlexp').value = "";
            }

            if (document.getElementById("cphMain_hiddenLeavOnAbsnc").value != 0) {
                document.getElementById("divLeavOnAbsnc").style.display = "none";
                
            }
            

            if (document.getElementById("cphMain_cbxLeaveOnAbsence").checked == true) {
                ChangeCorpLeave();
            }

        });
     

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:HiddenField ID="HiddenselectedDesigntext" runat="server" />
    <asp:HiddenField ID="HiddenselectedPaygradetext" runat="server" />
    <asp:HiddenField ID="HiddenselectedExperiencetext" runat="server" />
    <asp:HiddenField ID="hiddenselectedDesignlist" runat="server" />
    <asp:HiddenField ID="hiddenselectedPaygradelist" runat="server" />
    <asp:HiddenField ID="hiddenselectedExperiencelist" runat="server" />
    <asp:HiddenField ID="hiddenSelectdNodesig" runat="server" />
    <asp:HiddenField ID="hiddenSelectdNoPaygrade" runat="server" />
    <asp:HiddenField ID="hiddenSelectdNoExperience" runat="server" />
    <asp:HiddenField ID="HiddenAllocatnConfirmed" runat="server" />
    <asp:HiddenField ID="hiddensearchby" Value="0" runat="server" />
    <asp:HiddenField ID="hiddenRsnid" Value="0" runat="server" />

    <asp:HiddenField ID="HiddenLeaveId" Value="0" runat="server" />
    <asp:HiddenField ID="hiddenLeavOnAbsnc" Value="0" runat="server" />

    <script>
        $noCon = jQuery.noConflict();
        $noCon2 = jQuery.noConflict();
        $noCon(function () {
            //Initialize Select2 Elements
            $noCon2(".select2").select2();

            //  checkclickedradio();
            document.getElementById("<%=ddlmodeSearch.ClientID%>").style.borderColor = "";

            CalenderDaysChange();
        });
    </script>

    <style>
        .open > .dropdown-menu {
            display: none;
        }
    </style>
    <script>
      
        function selected() {
            var ddldesignationvalues;
            var ddlPaygradevalues;
            var ddlexpvalues;
            var sel = "";
            //  alert($noCon2('#cphMain_ddlmodeSearch').val());

            ddldesignationvalues = $noCon2('#cphMain_ddlmodeSearch').val();

            ddlPaygradevalues = $noCon2('#cphMain_ddlpay').val();
            ddlexpvalues = $noCon2('#cphMain_ddlexp').val();
          
          
            $noCon2("#cphMain_ddlmodeSearch option:selected").each(function () {
                var $noCon2this = $noCon2(this);
                if ($noCon2this.length)
                {
                    var selText = $noCon2this.text();
                    sel = sel + selText + ",";
                    document.getElementById("<%=HiddenselectedDesigntext.ClientID%>").value = sel;
                }
            });
            $noCon2("#cphMain_ddlpay option:selected").each(function () {
                var $noCon2this = $noCon2(this);
                if ($noCon2this.length) {
                    var selText = $noCon2this.text();
                    sel = sel + selText + ",";

                    document.getElementById("<%=HiddenselectedPaygradetext.ClientID%>").value = sel
                }
            });
            $noCon2("#cphMain_ddlexp option:selected").each(function () {
                var $noCon2this = $noCon2(this);
                if ($noCon2this.length) {
                    var selText = $noCon2this.text();
                    sel = sel + selText + ",";


                    ;
                    document.getElementById("<%=HiddenselectedExperiencetext.ClientID%>").value = sel;
                }
            });
            
            document.getElementById("<%=hiddensearchby.ClientID%>").value = "Employee";
            document.getElementById("<%=hiddenselectedDesignlist.ClientID%>").value = ddldesignationvalues;
            document.getElementById("<%=hiddensearchby.ClientID%>").value = "PayGrade";
            document.getElementById("<%=hiddenselectedPaygradelist.ClientID%>").value = ddlPaygradevalues;
            document.getElementById("<%=hiddensearchby.ClientID%>").value = "Experience";
            document.getElementById("<%=hiddenselectedExperiencelist.ClientID%>").value = ddlexpvalues;

     
            return true;
        }
       

        function isTagEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
        function isTag(evt) {
            document.getElementById('divMessageArea').style.display = "none";          

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62 || keyCodes == 13) {
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
        }


        function SettlmtWork() {
            if (document.getElementById("cphMain_cbxleave").checked == true) {

                document.getElementById("divSettlmt").style.display = "";
                document.getElementById("divPaidOption").style.display = "none";
                //document.getElementById("cphMain_cbxExcSalProc").checked = false;
                document.getElementById("cphMain_cbxIncDutyRejoin").checked = false;
            }
            else {
                document.getElementById("divSettlmt").style.display = "none";
                document.getElementById("divPaidOption").style.display = "";
            }
            IncrmntConfrmCounter();
        }

        function ChangeCorpLeave() {


            //Applicable For
            if (document.getElementById("cphMain_cbxLeaveOnAbsence").checked == true) {

                document.getElementById("cphMain_NumDays").value = 0;
                document.getElementById("cphMain_NumDays").disabled = true;

                document.getElementById("cphMain_cbxTravel").disabled = true;
                document.getElementById("cphMain_cbxleave").disabled = true;

                //Radio button
                document.getElementById("cphMain_RbCalendar").disabled = true;
                document.getElementById("cphMain_Rbwrkgday").disabled = true;
                document.getElementById("cphMain_RbMale").disabled = true;
                document.getElementById("cphMain_RBfemale").disabled = true;
                document.getElementById("cphMain_RbBoth").disabled = true;
                document.getElementById("cphMain_Rbsingle").disabled = true;
                document.getElementById("cphMain_RBMarried").disabled = true;
                document.getElementById("cphMain_Rbbothmarital").disabled = true;

                if (document.getElementById("cphMain_cbxAll1").checked == true) {
                    document.getElementById("cphMain_cbxAll1").checked = true;
                }
                else {
                    document.getElementById("cphMain_cbxAll1").disabled = false;
                    document.getElementById("cphMain_cbxAll1").click();
                }
                document.getElementById("cphMain_cbxAll1").disabled = true;                                  
                document.getElementById("cphMain_cbxAll2").checked = false;
                document.getElementById("cphMain_cbxAll3").checked = false;
            }
            else {
                document.getElementById("cphMain_NumDays").value = "";
                document.getElementById("cphMain_NumDays").disabled = false;
                document.getElementById("cphMain_cbxTravel").disabled = false;
                document.getElementById("cphMain_cbxleave").disabled = false;

                //Radio button
                document.getElementById("cphMain_RbCalendar").disabled = false;
                document.getElementById("cphMain_Rbwrkgday").disabled = false;
                document.getElementById("cphMain_RbMale").disabled = false;
                document.getElementById("cphMain_RBfemale").disabled = false;
                document.getElementById("cphMain_RbBoth").disabled = false;
                document.getElementById("cphMain_Rbsingle").disabled = false;
                document.getElementById("cphMain_RBMarried").disabled = false;
                document.getElementById("cphMain_Rbbothmarital").disabled = false;

                ////Applicable For
                document.getElementById("cphMain_cbxAll1").disabled = false;
                document.getElementById("cphMain_cbxAll1").checked = false;
                document.getElementById("<%=ddlmodeSearch.ClientID%>").disabled = false;
                document.getElementById("<%=ddlpay.ClientID%>").disabled = false;
                document.getElementById("<%=ddlexp.ClientID%>").disabled = false;
                document.getElementById("<%=cbxAll2.ClientID%>").disabled = false;
                document.getElementById("<%=cbxAll3.ClientID%>").disabled = false;
            }
        }

    </script>

    <div class="cont_rght" style="width: 110%">


        <div id="divMessageArea" style="display: none; margin: 0px 0 13px;">
            <img id="imgMessageArea" src="">
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

        <br />

        <div onclick=" ConfirmMessage()" id="divList" class="list" runat="server" style="position: fixed; right: 5%; top: 42%; height: 26.5px;">

            <%-- <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>




        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <asp:Label ID="lblEntry" runat="server"></asp:Label>
        </div>
        <br />
        <br />


        <div style="float: left;
background-color: rgb(243, 243, 243);
width: 88%;
border: 1px solid #428734;
padding: 2%;
display: block;"
>


           <div id="divLeavOnAbsnc" class="eachform" style="float: left; width: 72%">
                <h2 style="width: 24%;">Leave on absence</h2>
                <asp:CheckBox ID="cbxLeaveOnAbsence"  Text="" runat="server" onchange="ChangeCorpLeave();" onkeydown="return DisableEnter(event)" class="form2"  />
            </div>

        <div style="width: 48%; float: left">
         
            <div class="eachform" style="float: left; width: 80%">
                <h2 style="width: 38%;">Type Name*</h2>
                <asp:TextBox ID="TypNme" class="form1" runat="server" MaxLength="50" Width="50%" Height="30px" onblur="RemoveTag();" onkeypress="return isTag(event);" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
            </div>
            <div class="eachform" style="float: left; width: 80%">    <%--emp27--%>
                <h2 style="width: 38%;">Description</h2>
                <asp:TextBox ID="txtDesc" class="form1" TextMode="MultiLine"  runat="server"  MaxLength="1000" Width="50%" Height="80px" onkeypress="return  isTagEnter(event);" onblur="return textCounter(cphMain_txtDesc,450)" onkeydown=" return textCounter(cphMain_txtDesc,450)"  Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
            </div>
            <div class="eachform" style="float: left; width: 80%">
                <h2>No. of Days*</h2>
                <asp:TextBox ID="NumDays" class="form1" runat="server" MaxLength="3" Width="32%" Height="30px" Style="resize: none; float: left; margin-left: 79px; font-family: calibri;" ></asp:TextBox><h2 style="float: right; margin-top: 1%;">Per Year</h2>
            </div>


            <div class="eachform" style="float: left; width: 80%">
                <h2>Status*</h2>
                <asp:CheckBox ID="CbxStatus" Text="" runat="server" onkeydown="return DisableEnter(event)" Checked="true" class="form2" Style="margin-left: 32.7%;" />
            </div>

            <div class="eachform" style="float: left; width: 99%">
                <h2 style="font-size: 23px; margin-top: 8%;">Applicable For</h2> <%-- emp25--%>
            </div>

            <div class="eachform" style="float: left; margin-top: 3%; width: 99%">
                <h2>Designation*</h2>
                <div id="divsrch" class="eachform" style="width: 54%; margin-left: 36.8%; margin-top: -29px; float: left; border-color: red; border: 0px solid; border-color: red;">
                    <asp:DropDownList ID="ddlmodeSearch" class="form-control select2" multiple="multiple" data-placeholder="Select Designation" Style="height: 27px; width: 70%; float: left;" runat="server" onblur="RemoveTag();" >
              
                    </asp:DropDownList>
                    <h2 style="float: right;margin-top: 2%;">All*</h2>
                    <asp:CheckBox ID="cbxAll1" Text="" runat="server" Style="float: right;margin-top: 2%;" onchange="CbxChange('cbxAll1');" onkeydown="return DisableEnter(event)" class="form2" />
                </div>
            </div>
            <div class="eachform" style="float: left; width: 99%">
                <h2>Pay Grade*</h2>
                <div id="paygrddiv" class="eachform" style="width: 54%; margin-left: 36.8%; margin-top: -29px; float: left; border-color: red; border: 0px solid; border-color: red;">
                    <asp:DropDownList ID="ddlpay" class="form-control select2" multiple="multiple" data-placeholder="Select Paygrade" Style="height: 27px; width: 70%; float: left;" runat="server"  >
                    </asp:DropDownList>

                    <h2 style="float: right;margin-top: 2%;">All*</h2>
                    <asp:CheckBox ID="cbxAll2" Text="" runat="server" Style="float: right;margin-top: 2%;" onchange="CbxChange('cbxAll2');" onkeydown="return DisableEnter(event)" class="form2" />
                </div>

            </div>
            <div class="eachform" style="float: left; width: 99%">
                <h2>Experience*</h2>
                <div id="expdiv" class="eachform" style="width: 54%; margin-left: 36.8%; margin-top: -29px; float: left; border-color: red; border: 0px solid; border-color: red;">
                    <asp:DropDownList ID="ddlexp" class="form-control select2" multiple="multiple" data-placeholder="Select Experience" Style="height: 27px; width: 70%; float: left;" runat="server" >
                    </asp:DropDownList>
                    <h2 style="float: right;margin-top: 3%;">All*</h2>
                    <asp:CheckBox ID="cbxAll3" Text="" runat="server" Style="float: right;margin-top: 3%;" onchange="CbxChange('cbxAll3');" onkeydown="return DisableEnter(event)" class="form2" />
                </div>
            </div>

            <div class="eachform" style="float: left; width: 99%">
                <h2 style="width: 36%;">None Applicable*</h2>
                <asp:CheckBox ID="cbxNone" Text="" runat="server" Style="float: left;" onkeydown="return DisableEnter(event)" class="form2" onchange="CbxChange('cbxNone');" />
            </div>

            <%--<div class="eachform" style="float: left; width: 99%">
                <h2>Experience*</h2>
                <div id="" class="eachform" style="width: 37.5%;margin-left: 18.5%; margin-top: -8px; float: left; border-color: red; border: 0px solid; border-color: red;">
                    <asp:DropDownList ID="" class="form-control select2" multiple="multiple" data-placeholder="Select Experience" Style="height: 27px; width: 100%; float: left;" runat="server">
                    </asp:DropDownList>
                    <h2 style="float: right;">All*</h2>
                <asp:CheckBox ID="" Text="" runat="server" Style="float: right;" onkeydown="return DisableEnter(event)" class="form2" />
                </div>
                

            </div>--%>

        </div>

        <div style="width: 48%; float: right">

            <div class="eachform" style="float: left; width: 99%">
                <h2 style="width: 38%;">Travel Needed</h2>
                <asp:CheckBox ID="cbxTravel" Text="" runat="server" Style="float: left;" onkeydown="return DisableEnter(event)" class="form2" />
            </div>
            <div class="eachform" style="float: left; margin-top: 2%; width: 99%">
                <h2 style="width: 38%;">Earned Leaves</h2>
                <asp:CheckBox ID="cbxleave" Text="" runat="server" Style="float: left;" onkeydown="return DisableEnter(event)" class="form2"  onchange="SettlmtWork();" />
            </div>


            <div class="eachform" style="float: left; margin-top: 2%; width: 99%">
                <asp:RadioButton ID="RbCalendar" Style="float: left; width: 22%;" Text="Calendar" runat="server" Checked="True" GroupName="Radiocalendar" onclick="CalenderDaysChange();" />
                <asp:RadioButton ID="Rbwrkgday" Style="float: left;" Text="Working Day" runat="server" GroupName="Radiocalendar" onclick="CalenderDaysChange();"/>
            </div>


            <div id="divHoliOff">
                <asp:Label runat="server">Between Leave</asp:Label>
              <div class="eachform" style="float: left; margin-top: 2%; width: 99%">
                <h2 style="width: 22%;">Holiday Paid</h2>
                <asp:CheckBox ID="cbxHoliPaid" Text="" runat="server" Style="float: left;" onkeydown="return DisableEnter(event)" class="form2"  />

                   <h2 style="width: 22%;margin-left:5%;">Off Day Paid</h2>
                <asp:CheckBox ID="cbxOffPaid" Text="" runat="server" Style="float: left;" onkeydown="return DisableEnter(event)" class="form2"  />
            </div>
            </div>




            <div id="divPaidOption">
             <%-- <div class="eachform" style="float: left; margin-top: 2%; width: 99%;display:none;">
                <h2 style="width: 38%;">Exclude in Salary Processing</h2>
                <asp:CheckBox ID="cbxExcSalProc" Text="" runat="server" Style="float: left;" onkeydown="return DisableEnter(event)" class="form2"  />
            </div>--%>
              <div class="eachform" style="float: left; margin-top: 2%; width: 99%">
                <h2 style="width: 38%;">Include in Duty Rejoin</h2>
                <asp:CheckBox ID="cbxIncDutyRejoin" Text="" runat="server" Style="float: left;" onkeydown="return DisableEnter(event)" class="form2"  />
            </div>
            </div>




            <div id="divSettlmt" class="eachform" style="float: left; margin-top: 2%; width: 99%;display:none;" >
                <h2 style="width: 38%;">Include in Settlement</h2>
                <asp:CheckBox ID="cbxSettlmt" Text="" runat="server" Style="float: left;" onkeydown="return DisableEnter(event)" class="form2" />
            </div>

           <div class="eachform" style="float: left; margin-top: 2%;display:none; width: 99%">
                <h2 style="width: 38%;">Monthly Increment</h2>
                <asp:CheckBox ID="cbxMonthly" Text="" runat="server" Style="float: left;" onkeydown="return DisableEnter(event)" class="form2"  onchange="SettlmtWork();" />
            </div>

          
            <div class="eachform" style="float: left; margin-top: 11%; width: 99%" onkeydown="return DisableEnter(evt)">
                <h2 style="margin-left: 0%; float: left;">Sex*</h2>
                <asp:RadioButton ID="RbMale" Style="float: left; margin-left: 34%;" Text="Male" runat="server"  onkeydown="return DisableEnter(evt)" GroupName="Radiosex" />
                <asp:RadioButton ID="RBfemale" Style="float: left;" Text="Female" runat="server"  GroupName="Radiosex" />
                <asp:RadioButton ID="RbBoth" Style="float: left;" Text="All" runat="server"  GroupName="Radiosex" />
            </div>
            <div class="eachform" style="float: left; margin-top: 2.5%; width: 99%">
                <h2>Marital Status*</h2>

                <asp:RadioButton ID="Rbsingle" Style="float: left; margin-left: 18%;" Text="Single"  runat="server"  GroupName="Radiomarital" />
                <asp:RadioButton ID="RBMarried" Style="float: left;" Text="Married" runat="server"  GroupName="Radiomarital" />
                <asp:RadioButton ID="Rbbothmarital" Style="float: left;" Text="All" runat="server"  GroupName="Radiomarital" />
            </div>
        </div>






        <div class="eachform" id="divemplysearch" style="width: 100%; float: left; margin-top: 14px; margin-left: 0px; margin-left: 0%;">

            <div id="div3" class="subform" style="margin-left: 1%; float: left; width: 39%;">
            </div>
        </div>
        </div>
        <br />
        <div class="eachform">
            <div class="subform" style="width: 72%; margin-top: 5%">


                <asp:Button ID="btnUpdate" runat="server" class="save" OnClientClick="return LeaveTypeValidate();" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnUpdateClose" runat="server" class="save" OnClientClick="return LeaveTypeValidate();" Text="Update & Close" OnClick="btnUpdate_Click"/>
                <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClientClick="return LeaveTypeValidate();;" OnClick="btnAdd_Click" />
                <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClientClick="return LeaveTypeValidate();" OnClick="btnAdd_Click" />
                <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                <asp:Button ID="btnClear" runat="server" Style="margin-left: 13px;" OnClientClick="return AlertClearAll();" class="cancel" Text="Clear" />
            </div>
        </div>

    </div>

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
            .select2-search__field {
            font-family: Calibri;

        }
    </style>
    <script>
               
    </script>
</asp:Content>

