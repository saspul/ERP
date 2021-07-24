<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Leave_Partial_Process.aspx.cs" Inherits="HCM_HCM_Master_hcm_LeaveMaster_hcm_Leave_Partial_Process" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
        .divbutton {
            display: inline-block;
            color: #0C7784;
            border: 1px solid #999;
            background: #CBCBCB;
            /*box-shadow: 0 0 5px -1px rgba(0,0,0,0.2);*/
            cursor: pointer;
            vertical-align: middle;
            width: 10%;
            padding: 5px;
            text-align: center;
            font-family: calibri;
        }

.divbutton:active {
                color: red;
                box-shadow: 0 0 5px -1px rgba(0,0,0,0.6);
            }
.datelbl {
            margin-left: 27.5%;
            font-size: 15px;
        }

#divMessageAreaTickt,#divMessageAreaSettlmt,#divMessageAreaExit{
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }

    </style>

    <script src="/JavaScript/jquery-1.8.3.min.js"></script>

    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            document.getElementById("<%=lblTicktStatus.ClientID%>").style.display = "none";
            document.getElementById("<%=lblSettlmtStatus.ClientID%>").style.display = "none";
            document.getElementById("<%=lblExitStatus.ClientID%>").style.display = "none";

             //EXIT PRCS STATUS
            if (document.getElementById("<%=Hiddenprtclridexit.ClientID%>").value == "true") {             //exit present
                if (document.getElementById("<%=HiddenFieldSettlmtFinishSts.ClientID%>").value == "1") {
                    document.getElementById("divButtonExit").style.display = "";
                    divButtonExitClick();
                }
                else {
                    document.getElementById("divButtonExit").style.pointerEvents = "none";
                }
            }
            else {
                document.getElementById("divButtonExit").style.display = "none";
            }


             //SETTLMT STATUS
            if (document.getElementById("<%=Hiddenprtclridsettlmt.ClientID%>").value == "true") {       //settlmt present

                if (document.getElementById("<%=Hidddentiketneeded.ClientID%>").value != "1") {        //only settlmt and no tickt prcs
                    document.getElementById("divButtonTicket").style.display = "none";
                    document.getElementById("divButtonSettlmt").style.display = "";

                    divButtonSettlmtClick();
                }
                else {
                                                                                               //ticket & settlmt present
                    if (document.getElementById("<%=HiddenFieldTicktFinishSts.ClientID%>").value == "1") {
                        document.getElementById("divButtonSettlmt").style.display = "";
                        divButtonSettlmtClick();
                    }
                    else {
                        document.getElementById("divButtonSettlmt").style.pointerEvents = "none";
                    }
                }
            }
            else {
                document.getElementById("divButtonSettlmt").style.display = "none";
            }

            //TICKET STATUS
            if (document.getElementById("<%=Hiddenprtclridtickt.ClientID%>").value == "true") {           //ticket present

                divButtonTicketClick();

            }
            else {
                document.getElementById("divButtonTicket").style.display = "none";
            }

            if (document.getElementById("<%=HiddenFieldTicktFinishSts.ClientID%>").value == "1") {
                document.getElementById("<%=lblTicktStatus.ClientID%>").style.display = "";
                document.getElementById("<%=lblTicktStatus.ClientID%>").innerText = "Finished";
            }
            else if (document.getElementById("<%=HiddenFieldTicktCloseSts.ClientID%>").value == "1") {
                document.getElementById("<%=lblTicktStatus.ClientID%>").style.display = "";
                document.getElementById("<%=lblTicktStatus.ClientID%>").innerText = "Closed";
            }
            if (document.getElementById("<%=HiddenFieldSettlmtFinishSts.ClientID%>").value == "1") {
                document.getElementById("<%=lblSettlmtStatus.ClientID%>").style.display = "";
                document.getElementById("<%=lblSettlmtStatus.ClientID%>").innerText = "Finished";
            }
            else if (document.getElementById("<%=HiddenFieldSettlmtCloseSts.ClientID%>").value == "1") {
                document.getElementById("<%=lblSettlmtStatus.ClientID%>").style.display = "";
                document.getElementById("<%=lblSettlmtStatus.ClientID%>").innerText = "Closed";
            }  
            if (document.getElementById("<%=HiddenFieldExitFinishSts.ClientID%>").value == "1") {
                document.getElementById("<%=lblExitStatus.ClientID%>").style.display = "";
                document.getElementById("<%=lblExitStatus.ClientID%>").innerText = "Finished";
            }
            else if (document.getElementById("<%=HiddenFieldExitCloseSts.ClientID%>").value == "1") {
                document.getElementById("<%=lblExitStatus.ClientID%>").style.display = "";
                document.getElementById("<%=lblExitStatus.ClientID%>").innerText = "Closed";
            }




            //insert fn tab to be seen
            if (document.getElementById("<%=hiddenfromdiv.ClientID%>").value == "1") {
                divButtonTicketClick();
            }
            else if (document.getElementById("<%=hiddenfromdiv.ClientID%>").value == "2") {
                  divButtonSettlmtClick();
              }
              else if (document.getElementById("<%=hiddenfromdiv.ClientID%>").value == "3") {
                divButtonExitClick();
              }

            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                TicktDisbld();
                SettlmtDisbld();
                ExitPrcsDisbld();
            }
        });

    </script>

    <script>

        function ConfirmMessage() {
          
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "hcm_Leave_Partial_Process_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
        }

        // for not allowing <> tags
        function isTag(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
        // for not allowing <> tags
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

        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }


        function divButtonTicketClick() {

            //hiding other
            document.getElementById('divButtonSettlmt').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonExit').style.backgroundColor = "#CBCBCB";

            document.getElementById('divSettlmt').style.display = "none";
            document.getElementById('divExit').style.display = "none";


            //displaying current
            document.getElementById('divButtonTicket').style.backgroundColor = "#f9f9f9";
            document.getElementById('divTicket').style.display = "";
            document.getElementById('cphMain_ddlTicktSts').focus();

        }


        function divButtonSettlmtClick() {

            //hiding other
            document.getElementById('divButtonTicket').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonExit').style.backgroundColor = "#CBCBCB";

            document.getElementById('divTicket').style.display = "none";
            document.getElementById('divExit').style.display = "none";


            //displaying current
            document.getElementById('divButtonSettlmt').style.backgroundColor = "#f9f9f9";
            document.getElementById('divSettlmt').style.display = "";
            document.getElementById('cphMain_ddlSettlmtStatus').focus();


        }

        function divButtonExitClick() {

            //hiding other
            document.getElementById('divButtonTicket').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonSettlmt').style.backgroundColor = "#CBCBCB";

            document.getElementById('divSettlmt').style.display = "none";
            document.getElementById('divTicket').style.display = "none";


            //displaying current
            document.getElementById('divButtonExit').style.backgroundColor = "#f9f9f9";
            document.getElementById('divExit').style.display = "";
            document.getElementById('cphMain_ddlExitSts').focus();

        }

        function CloseTicktFn() {

            if (confirm("Are you sure you want to close Ticket process?")) {
                confirmboxTickt = 0;

                var leavFcltyId = document.getElementById("<%=HiddenFieldLevFcltyId.ClientID%>").value;
                var leavDtlId = document.getElementById("<%=HiddenFieldTicktEmpDtlId.ClientID%>").value;
                var EmpId = document.getElementById("<%=hiddenEmpId.ClientID%>").value;
                var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;

                var Details = PageMethods.CloseTickt(leavFcltyId, leavDtlId, EmpId, UserId, function (response) {

                    TicktDisbld();

                    if (response == "false") {
                        DuplictTickt();
                    }
                    else {
                        SuccessCloseTickt();
                    }
                });
            }
        }

        function TicktDisbld() {
            //details display disabled

            document.getElementById("<%=ddlTicktSts.ClientID%>").disabled = true;
            document.getElementById("<%=txtTicktExptdDate.ClientID%>").disabled = true;
            document.getElementById("divTicktExpDate").style.pointerEvents = "none";
            document.getElementById("cphMain_btnAddTickt").style.display = "none";
            document.getElementById("cphMain_btnClearTickt").style.display = "none";
            document.getElementById("cphMain_divTicktClose").style.display = "none";
            document.getElementById("cphMain_divTicktFinish").style.display = "none";
        }

        function finishTicktFn() {

            if (confirm("Are you sure you want to finish Ticket process?")) {
                confirmboxTickt = 0;

                var leavFcltyId = document.getElementById("<%=HiddenFieldLevFcltyId.ClientID%>").value;
                var leavDtlId = document.getElementById("<%=HiddenFieldTicktEmpDtlId.ClientID%>").value;
                var EmpId = document.getElementById("<%=hiddenEmpId.ClientID%>").value;
                var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;

                var Details = PageMethods.FinishTickt(leavFcltyId, leavDtlId, EmpId, UserId, function (response) {

                    TicktDisbld();

                    if (response == "false") {
                        DuplictTickt();
                    }
                    else {
                        SuccessFinishTickt();
                        document.getElementById("divButtonSettlmt").style.pointerEvents = "";
                    }
                });
            }
        }


        function CloseSettlmtFn() {

            if (confirm("Are you sure you want to close Settlement process?")) {
                confirmboxSettlmt = 0;

                var leavFcltyId = document.getElementById("<%=HiddenFieldLevFcltyId.ClientID%>").value;
                var leavDtlId = document.getElementById("<%=HiddenFieldSettlmtEmpDtlId.ClientID%>").value;
                var EmpId = document.getElementById("<%=hiddenEmpId.ClientID%>").value;
                var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;

                var Details = PageMethods.CloseSettlmt(leavFcltyId, leavDtlId, EmpId, UserId, function (response) {

                    SettlmtDisbld();

                    if (response == "false") {
                        DuplictSettlmt();
                    }
                    else {
                        SuccessCloseSettlmt();
                    }
                });
            }
        }

        function SettlmtDisbld() {
            // details display disabled

            document.getElementById("<%=ddlSettlmtStatus.ClientID%>").disabled = true;
            document.getElementById("<%=txtSettlmtExptdDate.ClientID%>").disabled = true;
            document.getElementById("divSettlmtExpDate").style.pointerEvents = "none";
            document.getElementById("cphMain_btnAddSettlmt").style.display = "none";
            document.getElementById("cphMain_btnClearSettlmt").style.display = "none";
            document.getElementById("cphMain_divSettlmtClose").style.display = "none";
            document.getElementById("cphMain_divSettlmtFinish").style.display = "none";
        }

        function finishSettlmtFn() {

            if (confirm("Are you sure you want to finish Settlement process?")) {
                confirmboxSettlmt = 0;

                var leavFcltyId = document.getElementById("<%=HiddenFieldLevFcltyId.ClientID%>").value;
                var leavDtlId = document.getElementById("<%=HiddenFieldSettlmtEmpDtlId.ClientID%>").value;
                var EmpId = document.getElementById("<%=hiddenEmpId.ClientID%>").value;
                var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;

                var Details = PageMethods.FinishSettlmt(leavFcltyId, leavDtlId, EmpId, UserId, function (response) {

                    SettlmtDisbld();

                    if (response == "false") {
                        DuplictSettlmt();
                    }
                    else {
                        SuccessFinishSettlmt();
                        document.getElementById("divButtonExit").style.pointerEvents = "";
                    }
                });
            }
        }

        function CloseExitPrcsFn() {

            if (confirm("Are you sure you want you want to close Exit process?")) {
                confirmboxExit = 0;

                var leavFcltyId = document.getElementById("<%=HiddenFieldLevFcltyId.ClientID%>").value;
                var leavDtlId = document.getElementById("<%=HiddenFieldExitEmpDtlId.ClientID%>").value;
                var EmpId = document.getElementById("<%=hiddenEmpId.ClientID%>").value;
                var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;

                var Details = PageMethods.CloseExitPrcs(leavFcltyId, leavDtlId, EmpId, UserId, function (response) {

                    ExitPrcsDisbld();

                    if (response == "false") {
                        DuplictExit();
                    }
                    else {
                        SuccessCloseExit();
                    }
                });
            }
        }


        function ExitPrcsDisbld() {
            //details display disabled

            document.getElementById("<%=ddlExitSts.ClientID%>").disabled = true;
            document.getElementById("<%=txtExitExptdDate.ClientID%>").disabled = true;
            document.getElementById("divExitExpDate").style.pointerEvents = "none";
            document.getElementById("cphMain_btnAddExit").style.display = "none";
            document.getElementById("cphMain_btnClearExit").style.display = "none";
            document.getElementById("cphMain_divExitClose").style.display = "none";
            document.getElementById("cphMain_divExitFinish").style.display = "none";
        }

        function finishExitPrcsFn() {

            if (confirm("Are you sure you want you want to finish Exit process?")) {
                confirmboxExit = 0;

                var leavFcltyId = document.getElementById("<%=HiddenFieldLevFcltyId.ClientID%>").value;
                var leavDtlId = document.getElementById("<%=HiddenFieldExitEmpDtlId.ClientID%>").value;
                var EmpId = document.getElementById("<%=hiddenEmpId.ClientID%>").value;
                var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;

                var Details = PageMethods.FinishExitPrcs(leavFcltyId, leavDtlId, EmpId, UserId, function (response) {

                    ExitPrcsDisbld();

                    if (response == "false") {
                        DuplictExit();
                    }
                    else {
                        SuccessFinishExit();
                    }
                });
            }
        }

        function SuccessAddTickt() {
            document.getElementById('divMessageAreaTickt').style.display = "";
            document.getElementById("<%=lblMessageAreaTickt.ClientID%>").innerHTML = "Ticket details saved successfully.";
            document.getElementById('imgMessageAreaTickt').src = "/Images/Icons/imgMsgAreaInfo.png";

        }

        function SuccessAddSettlmt() {
            document.getElementById('divMessageAreaSettlmt').style.display = "";
            document.getElementById("<%=lblMessageAreaSettlmt.ClientID%>").innerHTML = "Settlement details saved successfully.";
            document.getElementById('imgMessageAreaSettlmt').src = "/Images/Icons/imgMsgAreaInfo.png";
            divButtonSettlmtClick(); 
        }

        function SuccessAddExit() {
            document.getElementById('divMessageAreaExit').style.display = "";
            document.getElementById("<%=lblMessageAreaExit.ClientID%>").innerHTML = "Exit process details saved successfully.";
            document.getElementById('imgMessageAreaExit').src = "/Images/Icons/imgMsgAreaInfo.png";
            divButtonExitClick();
        }

        function DuplictTickt() {
            document.getElementById('divMessageAreaTickt').style.display = "";
            document.getElementById("<%=lblMessageAreaTickt.ClientID%>").innerHTML = "Ticket details finished or closed by another user.";
            document.getElementById('imgMessageAreaTickt').src = "/Images/Icons/imgMsgAreaInfo.png";
        }

        function DuplictSettlmt() {
            document.getElementById('divMessageAreaSettlmt').style.display = "";
            document.getElementById("<%=lblMessageAreaSettlmt.ClientID%>").innerHTML = "Settlement details finished or closed by another user.";
            document.getElementById('imgMessageAreaSettlmt').src = "/Images/Icons/imgMsgAreaInfo.png";
            divButtonSettlmtClick();
        }

        function DuplictExit() {
            document.getElementById('divMessageAreaExit').style.display = "";
            document.getElementById("<%=lblMessageAreaExit.ClientID%>").innerHTML = "Exit process details finished or closed by another user.";
            document.getElementById('imgMessageAreaExit').src = "/Images/Icons/imgMsgAreaInfo.png";
            divButtonExitClick();
        }

        function SuccessCloseTickt() {
            document.getElementById('divMessageAreaTickt').style.display = "";
            document.getElementById("<%=lblMessageAreaTickt.ClientID%>").innerHTML = "Ticket details closed successfully.";
            document.getElementById('imgMessageAreaTickt').src = "/Images/Icons/imgMsgAreaInfo.png";
        }

        function SuccessCloseSettlmt() {
            document.getElementById('divMessageAreaSettlmt').style.display = "";
            document.getElementById("<%=lblMessageAreaSettlmt.ClientID%>").innerHTML = "Settlement details closed successfully.";
            document.getElementById('imgMessageAreaSettlmt').src = "/Images/Icons/imgMsgAreaInfo.png";
            divButtonSettlmtClick();
        }

        function SuccessCloseExit() {
            document.getElementById('divMessageAreaExit').style.display = "";
            document.getElementById("<%=lblMessageAreaExit.ClientID%>").innerHTML = "Exit process details closed successfully.";
            document.getElementById('imgMessageAreaExit').src = "/Images/Icons/imgMsgAreaInfo.png";
            divButtonExitClick();
        }

        function SuccessFinishTickt() {
            document.getElementById('divMessageAreaTickt').style.display = "";
            document.getElementById("<%=lblMessageAreaTickt.ClientID%>").innerHTML = "Ticket details finished successfully.";
            document.getElementById('imgMessageAreaTickt').src = "/Images/Icons/imgMsgAreaInfo.png";
        }

        function SuccessFinishSettlmt() {
            document.getElementById('divMessageAreaSettlmt').style.display = "";
            document.getElementById("<%=lblMessageAreaSettlmt.ClientID%>").innerHTML = "Settlement details finished successfully.";
            document.getElementById('imgMessageAreaSettlmt').src = "/Images/Icons/imgMsgAreaInfo.png";
            divButtonSettlmtClick();
        }

        function SuccessFinishExit() {
            document.getElementById('divMessageAreaExit').style.display = "";
            document.getElementById("<%=lblMessageAreaExit.ClientID%>").innerHTML = "Exit process details finished successfully.";
            document.getElementById('imgMessageAreaExit').src = "/Images/Icons/imgMsgAreaInfo.png";
            divButtonExitClick();
        }

    </script>

    <script>
        var confirmboxTickt = 0;
        function IncrmntConfrmCounterTickt() {

            confirmboxTickt++;
        }

        var confirmboxSettlmt = 0;
        function IncrmntConfrmCounterSettlmt() {
            confirmboxSettlmt++;
        }
        var confirmboxExit = 0;
        function IncrmntConfrmCounterExit() {
            confirmboxExit++;
        }

        function ConfirmCancel() {
            if (confirmboxTickt > 0 || confirmboxSettlmt > 0 || confirmboxExit > 0) {
                if (confirm("Are you sure you want to cancel this page?")) {
                    window.location.href = "hcm_Leave_Partial_Process_List.aspx";
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                window.location.href = "hcm_Leave_Partial_Process_List.aspx";
                return false;
            }
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


        function AlertClearTickt() {
            if (confirmboxTickt > 0) {
                if (confirm("Are you sure you want to clear all data in this page?")) {
                    confirmboxTickt = 0;
                    document.getElementById("<%=ddlTicktSts.ClientID%>").value = document.getElementById("<%=HiddenFieldTicktSts.ClientID%>").value;
                    document.getElementById("<%=txtTicktExptdDate.ClientID%>").value = "";
                    return false;
                }
            }
            else {
                document.getElementById("<%=ddlTicktSts.ClientID%>").value = document.getElementById("<%=HiddenFieldTicktSts.ClientID%>").value;
                document.getElementById("<%=txtTicktExptdDate.ClientID%>").value = "";
                document.getElementById("<%=hiddenfromdiv.ClientID%>").value = "1";
            }
        }

        function AlertClearSettlmt() {
            if (confirmboxSettlmt > 0) {
                if (confirm("Are you sure you want to clear all data in this page?")) {
                    confirmboxSettlmt = 0;
                    document.getElementById("<%=ddlSettlmtStatus.ClientID%>").value = document.getElementById("<%=HiddenFieldSettlmtSts.ClientID%>").value;
                    document.getElementById("<%=txtSettlmtExptdDate.ClientID%>").value = "";
                    return false;
                }
            }
            else {
                document.getElementById("<%=ddlSettlmtStatus.ClientID%>").value = document.getElementById("<%=HiddenFieldSettlmtSts.ClientID%>").value;
                document.getElementById("<%=txtSettlmtExptdDate.ClientID%>").value = "";
                document.getElementById("<%=hiddenfromdiv.ClientID%>").value = "2";
            }
        }

        function AlertClearExitPrcs() {
            if (confirmboxExit > 0) {
                if (confirm("Are you sure you want to clear all data in this page?")) {
                    confirmboxExit  = 0;
                    document.getElementById("<%=ddlExitSts.ClientID%>").value = document.getElementById("<%=HiddenFieldExitSts.ClientID%>").value;
                    document.getElementById("<%=txtExitExptdDate.ClientID%>").value = "";
                    return false;
                }
            }
            else {
                document.getElementById("<%=ddlExitSts.ClientID%>").value = document.getElementById("<%=HiddenFieldExitSts.ClientID%>").value;
                document.getElementById("<%=txtExitExptdDate.ClientID%>").value = "";
                document.getElementById("<%=hiddenfromdiv.ClientID%>").value = "3";
            }
        }


        function TicketAdd() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtTicktExptdDate.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTicktExptdDate.ClientID%>").value = replaceText2;

            document.getElementById("<%=ddlTicktSts.ClientID%>").style.borderColor = "";
            var status = document.getElementById("<%=ddlTicktSts.ClientID%>").value;

            document.getElementById('divMessageAreaTickt').style.display = "none";
            document.getElementById('imgMessageAreaTickt').src = "";

            if (status == "") {
                document.getElementById('divMessageAreaTickt').style.display = "";
                document.getElementById('imgMessageAreaTickt').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaTickt.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlTicktSts.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlTicktSts.ClientID%>").focus();
                ret = false;
            }

            var datepickerDate = document.getElementById("<%=txtTicktExptdDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateExptDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=Hiddendate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateToday = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
            
            if (document.getElementById("<%=txtTicktExptdDate.ClientID%>").value != "" && dateExptDt < dateToday) {

                document.getElementById("<%=txtTicktExptdDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtTicktExptdDate.ClientID%>").focus();
                document.getElementById('divMessageAreaTickt').style.display = "";
                document.getElementById('imgMessageAreaTickt').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaTickt.ClientID%>").innerHTML = "Sorry,expected target date cannot be less than current date!.";
                ret = false;
            }

            if (ret == false) {
                CheckSubmitZero();
            }

            return ret;
        }

        function SettlmtAdd() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtSettlmtExptdDate.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtSettlmtExptdDate.ClientID%>").value = replaceText2;
            var date = document.getElementById("<%=txtSettlmtExptdDate.ClientID%>").value;

            document.getElementById("<%=ddlSettlmtStatus.ClientID%>").style.borderColor = "";
            var status = document.getElementById("<%=ddlSettlmtStatus.ClientID%>").value;

            document.getElementById('divMessageAreaSettlmt').style.display = "none";
            document.getElementById('imgMessageAreaSettlmt').src = "";

            if (status == "") {
                document.getElementById('divMessageAreaSettlmt').style.display = "";
                document.getElementById('imgMessageAreaSettlmt').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaSettlmt.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlSettlmtStatus.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlSettlmtStatus.ClientID%>").focus();
                ret = false;
            }

            var datepickerDate = document.getElementById("<%=txtSettlmtExptdDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateExptDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=Hiddendate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateToday = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            if (document.getElementById("<%=txtSettlmtExptdDate.ClientID%>").value != "" && dateExptDt < dateToday) {
              
                document.getElementById("<%=txtSettlmtExptdDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtSettlmtExptdDate.ClientID%>").focus();
                document.getElementById('divMessageAreaSettlmt').style.display = "";
                document.getElementById('imgMessageAreaSettlmt').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaSettlmt.ClientID%>").innerHTML = "Sorry,expected target date cannot be less than current date!.";
                ret = false;
            }

              if (ret == false) {
                  CheckSubmitZero();
              }
            
              return ret;
        }

        function ExitPrcsAdd() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtExitExptdDate.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtExitExptdDate.ClientID%>").value = replaceText2;

            document.getElementById("<%=ddlExitSts.ClientID%>").style.borderColor = "";
            var status = document.getElementById("<%=ddlExitSts.ClientID%>").value;

            document.getElementById('divMessageAreaExit').style.display = "none";
            document.getElementById('imgMessageAreaExit').src = "";

            if (status == "") {
                document.getElementById('divMessageAreaExit').style.display = "";
                document.getElementById('imgMessageAreaExit').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaExit.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlExitSts.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlExitSts.ClientID%>").focus();
                ret = false;
            }

            var datepickerDate = document.getElementById("<%=txtExitExptdDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateExptDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=Hiddendate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateToday = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);


            if (document.getElementById("<%=txtExitExptdDate.ClientID%>").value != "" && dateExptDt < dateToday) {

                document.getElementById("<%=txtExitExptdDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtExitExptdDate.ClientID%>").focus();
                document.getElementById('divMessageAreaExit').style.display = "";
                document.getElementById('imgMessageAreaExit').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaExit.ClientID%>").innerHTML = "Sorry,expected target date cannot be less than current date!.";
                ret = false;
            }

            if (ret == false) {
                CheckSubmitZero();

            }

            return ret;
        }
    </script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenEmpId" runat="server" />
    <asp:HiddenField ID="HiddenFieldQryId" runat="server" />
    <asp:HiddenField ID="HiddenFieldLevFcltyId" runat="server" />

    <asp:HiddenField ID="HiddenFieldTicktSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldTicktFinishSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldTicktCloseSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldTicktEmpDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldTicketTrgtDate" runat="server" />
          <asp:HiddenField ID="Hiddenprtclridtickt" runat="server" />

    <asp:HiddenField ID="HiddenFieldSettlmtSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldSettlmtFinishSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldSettlmtCloseSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldSettlmtEmpDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldSettlmtTrgtDate" runat="server" />
          <asp:HiddenField ID="Hiddenprtclridsettlmt" runat="server" />

    <asp:HiddenField ID="HiddenFieldExitSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldExitFinishSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldExitCloseSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldExitEmpDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldExitTrgtDate" runat="server" />
     <asp:HiddenField ID="Hidddentiketneeded" runat="server" />
          <asp:HiddenField ID="Hiddenprtclridexit" runat="server" />


        <asp:HiddenField ID="hiddenfromdiv" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="HiddenFieldQrylevId" runat="server" />
     <asp:HiddenField ID="Hiddendate" runat="server" />

      <asp:HiddenField ID="HiddenView" runat="server" />
    <div class="cont_rght">

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: absolute; right: 5%; top: 43.5%; height: 26.5px;">
        </div>

        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke;float:left;margin-bottom:1%;height: 245px;">
            <div id="divReportCaption" style="width:100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;float:left">
                <asp:Label ID="lblEntry" runat="server">Leave Partial Process</asp:Label>
            </div>

            <div style="float: left; width: 98%;padding: 10px;margin-top: 2%;border: 1px solid #929292;background-color: #c9c9c9;font-family: Calibri;height: 175px;">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Name</h2>
                    <asp:Label ID="lblName"  class="form1" runat="server" style="word-wrap: break-word;font-family: calibri;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Designation</h2>
                    <asp:Label ID="lblDesgntn" class="form1" runat="server" style="word-wrap: break-word;font-family: calibri;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Department</h2>
                    <asp:Label ID="lblDept" class="form1" runat="server" style="word-wrap: break-word;font-family: calibri;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Nationality</h2>
                    <asp:Label ID="lblNation" class="form1" runat="server" style="word-wrap: break-word;font-family: calibri;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Mode</h2>
                    <asp:Label ID="lblMode" class="form1" runat="server" style="word-wrap: break-word;font-family: calibri;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Division</h2>
                    <asp:Label ID="lblDivsn" class="form1" runat="server" style="word-wrap: break-word;font-family: calibri;"></asp:Label>
                </div>
               
            </div>

            </div>


         <%--Tabs --%>

            <div style="width: 99%;margin-top: 21%;padding: 0px;">
            <div id="divButtonTicket" onclick="divButtonTicketClick()" class="divbutton" >Ticket</div>
            <div id="divButtonSettlmt" onclick="divButtonSettlmtClick()" class="divbutton" >Settlement</div> 
            <div id="divButtonExit" onclick="divButtonExitClick()" class="divbutton" >Exit Process</div>
                  </div>  



         <%-- Ticket tab--%>

            <div id="divTicket" style="border:.5px solid;border-color: #9ba48b;background-color:white;width: 96%; margin-top:1%;padding:2%;display:none;"> 
                 
              <div id="divMessageAreaTickt" style="display:none; width: 84%; margin-left: 6%;margin-top: -1%;">
              <img id="imgMessageAreaTickt" src="" />
              <asp:Label ID="lblMessageAreaTickt" runat="server"></asp:Label>
                </div> 

            <br />
             <div class="eachform" style="float:left;width:80%;">
             <h2>Target Date</h2>             
             <asp:Label ID="lblTicktTrgtDate" class="datelbl"  runat="server" style="word-wrap: break-word;"></asp:Label>
            </div>

                <div class="eachform" style="float: right; width: 13%;">
             <asp:Label ID="lblTicktStatus" class="datelbl" runat="server" style="padding:3%;word-wrap:break-word;font-family:calibri;font-size:20px;color:#377438;border-style:solid;"></asp:Label>
                    </div>

             <div class="eachform" style="float:left;margin-top:1%;width:80%;">
             <h2>Status*</h2>             
             <asp:DropDownList ID="ddlTicktSts"  class="form1" runat="server" Style="height:30px;width:42%;text-align:left;margin-right: 20%;" onchange="IncrmntConfrmCounterTickt();">
                <asp:ListItem Text="Availability Check" Value="1"></asp:ListItem>
                <asp:ListItem Text="Awaiting, Approval from candidate" Value="2"></asp:ListItem>
                <asp:ListItem Text="Booking Confirm, ticket copy attach" Value="3"></asp:ListItem>
             </asp:DropDownList>
            </div>

             <div  id="divTicktClose" runat="server" style="width: 10%;margin-left: 81%;margin-top: 3%;cursor:pointer" onclick="CloseTicktFn()">
             <img id="imgTicktClose" runat="server" src="/Images/Icons/close guarantee.png" style="margin-left:23%;width:37%;"/>
              <h2 style="margin-top: 1%;font-size:15px;margin-left:21%;">CLOSE</h2>
              </div>

              <div class="eachform" style="float:left;margin-top:1%;width:80%;">
                <h2>Expected Target Date</h2>

                 <div id="divTicktExpDate" class="input-append date" style="float: right;width: 43%;margin-right: 19%;">

                        <asp:TextBox ID="txtTicktExptdDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:81%;margin-top: 0%;float:left;" onchange="IncrmntConfrmCounterTickt();" onkeypress="return DisableEnter(event)" onkeydown="return isTagEnter(event)" onblur="return isTag(event)"></asp:TextBox>

                        <input type="image" runat="server" id="Image11" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

                        <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                               <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                           <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divTicktExpDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                            });

                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>
           
             <div  id="divTicktFinish" runat="server" style="width: 10%;margin-left: 81%;margin-top: 4%;cursor:pointer" onclick=" finishTicktFn()">
             <img id="imgTicktFinish" runat="server" src="/Images/new_Icons32/Quotation.png" style="margin-left:23%;width:37%;"/>
             <h2 style="margin-top: 1%;font-size:15px;margin-left:18%;">FINISH</h2>
              </div>
           
             <div class="eachform" style="margin-top:2%;">
                <div class="subform" style="width:448px;margin-right:19%;">
                    <div class="form-group" >                     
                         <asp:Button ID="btnAddTickt" runat="server" class="save" Text="Save" OnClientClick="return TicketAdd();" OnClick="btnAddTickt_Click"/>
                         <asp:Button ID="btnClearTickt" runat="server" style="margin-left: 11px;" class="cancel" Text="Clear" OnClientClick="return AlertClearTickt();"/>
                         <asp:Button ID="btnCancelTickt" runat="server" class="cancel" style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCancel();"/>
                       </div>
                </div>
            </div>

        </div>

        <%--Settlement tab--%>

         <div id="divSettlmt" style="border:.5px solid;border-color: #9ba48b;background-color:white;width: 96%; margin-top:1%;padding:2%;display:none;"> 
                 
              <div id="divMessageAreaSettlmt" style="display:none; width: 84%; margin-left: 6%;margin-top: -1%;">
              <img id="imgMessageAreaSettlmt" src="" />
              <asp:Label ID="lblMessageAreaSettlmt" runat="server"></asp:Label>
                </div> 

            <br />
             <div class="eachform" style="float:left;width:80%;">
             <h2>Target Date</h2>             
             <asp:Label ID="lblSettlmtTrgtDate" class="datelbl"  runat="server" style="word-wrap: break-word;"></asp:Label>
            </div>

             <div class="eachform" style="float: right; width: 13%;">
             <asp:Label ID="lblSettlmtStatus" class="datelbl" runat="server" style="padding:3%;word-wrap:break-word;font-family:calibri;font-size:20px;color:#377438;border-style:solid;"></asp:Label>
                 </div>

             <div class="eachform" style="float:left;margin-top:1%;width:80%;">
             <h2>Status*</h2>             
             <asp:DropDownList ID="ddlSettlmtStatus"  class="form1" runat="server" Style="height:30px;width:42%;text-align:left;margin-right: 20%;" onchange="IncrmntConfrmCounterSettlmt();" >
                <asp:ListItem Text="Pending" Value="1"></asp:ListItem>
                <asp:ListItem Text="Success" Value="2"></asp:ListItem>
                <asp:ListItem Text="Failed" Value="3"></asp:ListItem>
             </asp:DropDownList>
            </div>

             <div  id="divSettlmtClose" runat="server" style="width: 10%;margin-left: 81%;margin-top: 3%;cursor:pointer" onclick="CloseSettlmtFn()">
             <img id="imgSetttlmtClose" runat="server" src="/Images/Icons/close guarantee.png" style="margin-left:23%;width:37%;"/>
              <h2 style="margin-top: 1%;font-size:15px;margin-left:21%;">CLOSE</h2>
              </div>

              <div class="eachform" style="float:left;margin-top:1%;width:80%;">
                <h2>Expected Target Date</h2>

                 <div id="divSettlmtExpDate" class="input-append date" style="float: right;width: 43%;margin-right: 19%;">

                        <asp:TextBox ID="txtSettlmtExptdDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:81%;margin-top: 0%;float:left;" onchange="IncrmntConfrmCounterSettlmt();" onkeypress="return DisableEnter(event)" onkeydown="return isTagEnter(event)" onblur="return isTag(event)"></asp:TextBox>

                        <input type="image" runat="server" id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

                        <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                               <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                           <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divSettlmtExpDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                            });

                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>
           
             <div  id="divSettlmtFinish" runat="server" style="width: 10%;margin-left: 81%;margin-top: 4%;cursor:pointer" onclick=" finishSettlmtFn()">
             <img id="imgSettlmtFinish" runat="server" src="/Images/new_Icons32/Quotation.png" style="margin-left:23%;width:37%;"/>
             <h2 style="margin-top: 1%;font-size:15px;margin-left:18%;">FINISH</h2>
              </div>
           
             <div class="eachform" style="margin-top:2%;">
                <div class="subform" style="width:448px;margin-right:19%;">
                    <div class="form-group" >                     
                         <asp:Button ID="btnAddSettlmt" runat="server" class="save" Text="Save" OnClientClick="return SettlmtAdd();" OnClick="btnAddSettlmt_Click"/>
                         <asp:Button ID="btnClearSettlmt" runat="server" style="margin-left: 11px;" class="cancel" Text="Clear" OnClientClick="return AlertClearSettlmt();"/>
                         <asp:Button ID="btnCancelSettlmt" runat="server" class="cancel" style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCancel();"/>
                       </div>
                </div>
            </div>

        </div>


         <%--Exit Process tab--%>

         <div id="divExit" style="border:.5px solid;border-color: #9ba48b;background-color:white;width: 96%; margin-top:1%;padding:2%;display:none;"> 
                 
              <div id="divMessageAreaExit" style="display:none; width: 84%; margin-left: 6%;margin-top: -1%;">
              <img id="imgMessageAreaExit" src="" />
              <asp:Label ID="lblMessageAreaExit" runat="server"></asp:Label>
                </div> 

            <br />
             <div class="eachform" style="float:left;width:80%;">
             <h2>Target Date</h2>             
             <asp:Label ID="lblExitTrgtDate" class="datelbl"  runat="server" style="word-wrap: break-word;"></asp:Label>
            </div>

             <div class="eachform" style="float: right; width: 13%;">
             <asp:Label ID="lblExitStatus" class="datelbl" runat="server" style="padding:3%;word-wrap:break-word;font-family:calibri;font-size:20px;color:#377438;border-style:solid;"></asp:Label>
                 </div>

             <div class="eachform" style="float:left;margin-top:1%;width:80%;">
             <h2>Status*</h2>             
             <asp:DropDownList ID="ddlExitSts"  class="form1" runat="server" Style="height:30px;width:42%;text-align:left;margin-right: 20%;" onchange="IncrmntConfrmCounterExit();" onkeypress="return DisableEnter(event)" onkeydown="return isTagEnter(event)" onblur="return isTag(event)">
                <asp:ListItem Text="Applied" Value="1"></asp:ListItem>
                <asp:ListItem Text="Approved" Value="2"></asp:ListItem>
                <asp:ListItem Text="Rejected" Value="3"></asp:ListItem>
             </asp:DropDownList>
            </div>

             <div  id="divExitClose" runat="server" style="width: 10%;margin-left: 81%;margin-top: 3%;cursor:pointer" onclick="CloseExitPrcsFn()">
             <img id="imgExitClose" runat="server" src="/Images/Icons/close guarantee.png" style="margin-left:23%;width:37%;"/>
              <h2 style="margin-top: 1%;font-size:15px;margin-left:21%;">CLOSE</h2>
              </div>

              <div class="eachform" style="float:left;margin-top:1%;width:80%;">
                <h2>Expected Target Date</h2>

                 <div id="divExitExpDate" class="input-append date" style="float: right;width: 43%;margin-right: 19%;">

                        <asp:TextBox ID="txtExitExptdDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:81%;margin-top: 0%;float:left;" onchange="IncrmntConfrmCounterExit();" onkeypress="return DisableEnter(event)" onkeydown="return isTagEnter(event)" onblur="return isTag(event)"></asp:TextBox>

                        <input type="image" runat="server" id="Image2" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

                        <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                               <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                           <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divExitExpDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                            });

                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>
           
             <div  id="divExitFinish" runat="server" style="width: 10%;margin-left: 81%;margin-top: 4%;cursor:pointer" onclick=" finishExitPrcsFn()">
             <img id="imgExitFinish" runat="server" src="/Images/new_Icons32/Quotation.png" style="margin-left:23%;width:37%;"/>
             <h2 style="margin-top: 1%;font-size:15px;margin-left:18%;">FINISH</h2>
              </div>
           
             <div class="eachform" style="margin-top:2%;">
                <div class="subform" style="width:448px;margin-right:19%;">
                    <div class="form-group" >                     
                         <asp:Button ID="btnAddExit" runat="server" class="save" Text="Save" OnClientClick="return ExitPrcsAdd();" OnClick="btnAddExit_Click"/>
                         <asp:Button ID="btnClearExit" runat="server" style="margin-left: 11px;" class="cancel" Text="Clear" OnClientClick="return AlertClearExitPrcs();"/>
                         <asp:Button ID="btnCanceExit" runat="server" class="cancel" style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCancel();"/>
                       </div>
                </div>
            </div>

        </div>




        </div>


    <style>
         .open > .dropdown-menu {
    display: none;
}
    </style>



</asp:Content>

