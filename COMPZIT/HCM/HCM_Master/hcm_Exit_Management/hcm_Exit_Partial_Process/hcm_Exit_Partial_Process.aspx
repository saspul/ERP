<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Exit_Partial_Process.aspx.cs" Inherits="HCM_HCM_Master_hcm_Exit_Management_hcm_Exit_Partial_Process_hcm_Exit_Partial_Process" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
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

        #divMessageAreaTickt, #divMessageAreaSettlmt, #divMessageAreaExit {
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




            //HiddenTicketFinSts
            //HiddenExitPermitFinSts
            //HiddenVisaNocFinSts

            //HiddenTicketCloseSts
            //HiddenExitPermitCloseSts
            //HiddenVisaNocCloseSts

       

            //hide tabs
            //HiddenTicketTab
            //HiddenExitPermitTab
            //HiddenVisaNocTab


            if (document.getElementById("<%=HiddenVisaNocTab.ClientID%>").value != "1") {
                document.getElementById('divButtonVisaNoc').style.display = "none";
            }
            else {
                divButtonVisaNocClick();
            }
            if (document.getElementById("<%=HiddenExitPermitTab.ClientID%>").value != "1") {
                document.getElementById('divButtonExit').style.display = "none";
            }
            else {
                divButtonExitClick();
            }
            if (document.getElementById("<%=HiddenTicketTab.ClientID%>").value != "1") {
                document.getElementById('divButtonTicket').style.display = "none";
            }
            else {
                divButtonTicketClick();
            }
            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1")
            {
                TicktDisbld();
                ExitPrcsDisbld();
                VisaDisbld();
              
            }

        });

    </script>

    <script>

        function ConfirmMessage() {
            if (confirmboxTickt > 0 || confirmboxVisa > 0 || confirmboxExit > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "hcm_Exit_Partial_Process_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_Exit_Partial_Process_List.aspx";
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
            document.getElementById('divButtonVisaNoc').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonExit').style.backgroundColor = "#CBCBCB";

            document.getElementById('divSettlmt').style.display = "none";
            document.getElementById('divExit').style.display = "none";


            //displaying current
            document.getElementById('divButtonTicket').style.backgroundColor = "#f9f9f9";
            document.getElementById('divTicket').style.display = "";
            document.getElementById('cphMain_ddlTicktSts').focus();

        }


        function divButtonVisaNocClick() {

            //hiding other
            document.getElementById('divButtonTicket').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonExit').style.backgroundColor = "#CBCBCB";

            document.getElementById('divTicket').style.display = "none";
            document.getElementById('divExit').style.display = "none";


            //displaying current
            document.getElementById('divButtonVisaNoc').style.backgroundColor = "#f9f9f9";
            document.getElementById('divSettlmt').style.display = "";
            document.getElementById('cphMain_ddlVisaNocStatus').focus();


        }

        function divButtonExitClick() {

            //hiding other
            document.getElementById('divButtonTicket').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonVisaNoc').style.backgroundColor = "#CBCBCB";

            document.getElementById('divSettlmt').style.display = "none";
            document.getElementById('divTicket').style.display = "none";


            //displaying current
            document.getElementById('divButtonExit').style.backgroundColor = "#f9f9f9";
            document.getElementById('divExit').style.display = "";
            document.getElementById('cphMain_ddlExitSts').focus();

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





        function VisaDisbld() {
            // details display disabled

            document.getElementById("<%=ddlVisaNocStatus.ClientID%>").disabled = true;
            document.getElementById("<%=txtVisaExptdDate.ClientID%>").disabled = true;
            document.getElementById("divSettlmtExpDate").style.pointerEvents = "none";
            document.getElementById("cphMain_btnAddVisaNoc").style.display = "none";
            document.getElementById("cphMain_btnClearSettlmt").style.display = "none";
            document.getElementById("cphMain_divVisaNocClose").style.display = "none";
            document.getElementById("cphMain_divVisaNocFinish").style.display = "none";
        }

        function validateDate(date) {
            //fromdate is current date
            
            var fromDate = document.getElementById("<%=Hiddendate.ClientID%>").value;
            var toDate = date;
            if (fromDate != "" && toDate != "") {
                dateFirst = fromDate.split('-');
                dateSecond = toDate.split('-');
                var finalFromDate = new Date(dateFirst[2], dateFirst[1], dateFirst[0]); //Year, Month, Date
                var finalToDate = new Date(dateSecond[2], dateSecond[1], dateSecond[0]);

                if (finalToDate >= finalFromDate) {
                    return true;
                }
                else {
                    alert('Invalid expected target date');
                    return false;

                }
            }
        }

        function savePartialProcess(Mode, strFinishSts) {
            var $NonCon = jQuery.noConflict();
            var exitDtlId = "";
            var dateExpec = "0";
            var intDdlStatus = "";
            var intMode = "";
            var strMsg = " details saved successfully.";
            var strConfirmMsg = "Are you sure you want to save this process?";
            if (strFinishSts == "1") {
                strMsg = " details finished successfully.";
                var strConfirmMsg = "Are you sure you want to finish this process?";
            }
            


            // details finished successfully.
            if (Mode == "TICKET") {
                strMsg = "Ticket" + strMsg;
                intMode = 0;
                exitDtlId = document.getElementById("<%=HiddenTicketID.ClientID%>").value;
                intDdlStatus = document.getElementById("<%=ddlTicktSts.ClientID%>").value;
                if (document.getElementById("<%=txtTicktExptdDate.ClientID%>").value != "") {
                    dateExpec = document.getElementById("<%=txtTicktExptdDate.ClientID%>").value;
                    if (validateDate(dateExpec)) {
                    }
                    else {
                        return false;
                    }

                }
                else {
                    dateExpec = document.getElementById("<%=lblTicktTrgtDate.ClientID%>").innerHTML;
                }

            }
            else if (Mode == "EXIT") {
                strMsg = "Exit permit" + strMsg;
                intMode = 2;
                exitDtlId = document.getElementById("<%=HiddenExitPermitID.ClientID%>").value;
                intDdlStatus = document.getElementById("<%=ddlExitSts.ClientID%>").value;

                if (document.getElementById("<%=txtExitExptdDate.ClientID%>").value != "") {
                    dateExpec = document.getElementById("<%=txtExitExptdDate.ClientID%>").value;
                    if (validateDate(dateExpec)) {
                    }
                    else {
                        return false;
                    }
                }
                else {
                    dateExpec = document.getElementById("<%=lblExitTrgtDate.ClientID%>").innerHTML;
                }
            }
            else if (Mode == "VISA") {
                strMsg = "Visa" + strMsg;
                intMode = 4;

                intDdlStatus = document.getElementById("<%=ddlVisaNocStatus.ClientID%>").value;
                exitDtlId = document.getElementById("<%=HiddenVisaNocID.ClientID%>").value;
                if (document.getElementById("<%=txtVisaExptdDate.ClientID%>").value != "") {
                    dateExpec = document.getElementById("<%=txtVisaExptdDate.ClientID%>").value;
                    if (validateDate(dateExpec)) {
                    }
                    else {
                        return false;
                    }
                }
                else {

                    dateExpec = document.getElementById("<%=lblVisaTrgtDate.ClientID%>").innerHTML;
                }

            }
    if (confirm(strConfirmMsg)) {
        

        var intExitProcdureID = document.getElementById("<%=HiddenExitProcdureID.ClientID%>").value;


        //ajax
        $NonCon.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "hcm_Exit_Partial_Process.aspx/SaveExitPartialProcess",
            //data: '{intExitProcdureID:"' + intExitProcdureID + '"}',
            data: '{intExitProcdureID:"' + intExitProcdureID + '" ,intExitDtlId: "' + exitDtlId + '",dateExpec:"' + dateExpec + '",intDdlStatus:"' + intDdlStatus + '",strFinishSts:"' + strFinishSts + '",intMode:"' + intMode + '"}',
            dataType: "json",
            success: function (data) {
                if (data.d == "true") {


                    if (Mode == "TICKET") {
                        confirmboxTickt = 0;
                        document.getElementById("<%=lblTicktTrgtDate.ClientID%>").innerHTML = dateExpec;
                        SuccessMsgTicket(strMsg);
                        if (strFinishSts == "1") {
                            document.getElementById("<%=lblStatsInfoTickt.ClientID%>").innerHTML = "Finished";
                            document.getElementById("<%=lblStatsInfoTickt.ClientID%>").style.borderStyle = "solid";
                            TicktDisbld();
                            if (document.getElementById("<%=HiddenExitPermitTab.ClientID%>").value == "1") {
                               // document.getElementById('divButtonExit').style.pointerEvents = "";
                            }
                            else {
                                if (document.getElementById("<%=HiddenVisaNocTab.ClientID%>").value == "1") {
                                   // document.getElementById('divButtonVisaNoc').style.pointerEvents = "";
                                }
                            }
                        }
                        divButtonTicketClick();
                    }
                    else if (Mode == "EXIT") {
                        confirmboxExit = 0;
                        document.getElementById("<%=lblExitTrgtDate.ClientID%>").innerHTML = dateExpec;
                          SuccessMsgExit(strMsg);
                          if (strFinishSts == "1") {
                              document.getElementById("<%=lblStatusInfoExit.ClientID%>").innerHTML = "Finished";
                              document.getElementById("<%=lblStatusInfoExit.ClientID%>").style.borderStyle = "solid";
                              ExitPrcsDisbld();
                              if (document.getElementById("<%=HiddenVisaNocTab.ClientID%>").value == "1") {
                                  //document.getElementById('divButtonVisaNoc').style.pointerEvents = "";
                              }
                          }
                          divButtonExitClick();
                      }
                    else if (Mode == "VISA") {
                        confirmboxVisa = 0;
                          document.getElementById("<%=lblVisaTrgtDate.ClientID%>").innerHTML = dateExpec;
                            SuccessMsgVisa(strMsg);
                            if (strFinishSts == "1") {
                                document.getElementById("<%=lblStatusInfoVisa.ClientID%>").innerHTML = "Finished";
                                document.getElementById("<%=lblStatusInfoVisa.ClientID%>").style.borderStyle = "solid";

                                VisaDisbld();
                            }
                            divButtonVisaNocClick();
                        }
            }
            else {
                    // DuplictSettlmt();
                if (Mode == "TICKET") {
                    SuccessMsgTicket("Ticket details finished or closed by another user.");
                    TicktDisbld();
                    divButtonTicketClick();
                }
                else if (Mode == "EXIT") {
                    SuccessMsgExit("Exit permit details finished or closed by another user.");

                    ExitPrcsDisbld();
                    divButtonExitClick();
                }
                else if (Mode == "VISA") {
                    SuccessMsgVisa("Visa details finished or closed by another user.");
                    VisaDisbld();
                    divButtonVisaNocClick();
                }
            }
            }
        });



    return false;





}
}

        function ClosePartialExitPrcs(Mode) {
            var intMode = "";
            var $NonCon2 = jQuery.noConflict();
    if (confirm("Are you sure you want you want to close this process?")) {
     

        if (Mode == "TICKET") {
            intMode = 0;
            exitDtlId = document.getElementById("<%=HiddenTicketID.ClientID%>").value;


                        }
                        else if (Mode == "EXIT") {
                            intMode = 2;
                            exitDtlId = document.getElementById("<%=HiddenExitPermitID.ClientID%>").value;

            }
            else if (Mode == "VISA") {
                intMode = 4;
                exitDtlId = document.getElementById("<%=HiddenVisaNocID.ClientID%>").value;


            }

    var intExitProcdureID = document.getElementById("<%=HiddenExitProcdureID.ClientID%>").value;

                        //ajax
        $NonCon2.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "hcm_Exit_Partial_Process.aspx/ClosePartialExitPrcs",
                            //data: '{intExitProcdureID:"' + intExitProcdureID + '"}',
                            data: '{intExitProcdureID:"' + intExitProcdureID + '" ,intExitDtlId: "' + exitDtlId + '",intMode: "' + intMode + '"}',
                            dataType: "json",
                            success: function (data) {
                                if (data.d == "true") {


                                    if (Mode == "TICKET") {
                                        confirmboxTickt = 0;
                                     
                                        SuccessMsgTicket("Ticket details closed successfully.");
                                        TicktDisbld();
                                        divButtonTicketClick();
                                        document.getElementById("<%=lblStatsInfoTickt.ClientID%>").innerHTML = "Closed";
                                        document.getElementById("<%=lblStatsInfoTickt.ClientID%>").style.borderStyle = "solid";

                                    }
                                    else if (Mode == "EXIT") {
                                        confirmboxExit = 0;
                                       
                        SuccessMsgExit("Exit permit details closed successfully.");
                        ExitPrcsDisbld();
                        divButtonExitClick();
                        document.getElementById("<%=lblStatusInfoExit.ClientID%>").innerHTML = "Closed";
                                        document.getElementById("<%=lblStatusInfoExit.ClientID%>").style.borderStyle = "solid";

                    }
                                    else if (Mode == "VISA") {
                                        confirmboxVisa = 0;
                
                              SuccessMsgVisa("Visa details closed successfully.");
                              VisaDisbld();
                              divButtonVisaNocClick();
                              document.getElementById("<%=lblStatusInfoVisa.ClientID%>").innerHTML = "Closed";
                                        document.getElementById("<%=lblStatusInfoVisa.ClientID%>").style.borderStyle = "solid";

                          }
              }
              else {
                                    // DuplictSettlmt();
                  if (Mode == "TICKET") {
                      SuccessMsgTicket("Ticket details finished or closed by another user.");
                      TicktDisbld();
                      divButtonTicketClick();
                  }
                  else if (Mode == "EXIT") {
                      SuccessMsgExit("Exit permit details finished or closed by another user.");

                      ExitPrcsDisbld();
                      divButtonExitClick();
                  }
                  else if (Mode == "VISA") {
                      SuccessMsgVisa("Visa details finished or closed by another user.");
                      VisaDisbld();
                      divButtonVisaNocClick();
                  }
              }
                            }
                        });
  }
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
            divButtonVisaNocClick();
        }

        function SuccessCloseExit() {
            document.getElementById('divMessageAreaExit').style.display = "";
            document.getElementById("<%=lblMessageAreaExit.ClientID%>").innerHTML = "Exit process details closed successfully.";
            document.getElementById('imgMessageAreaExit').src = "/Images/Icons/imgMsgAreaInfo.png";
            divButtonExitClick();
        }






        function SuccessMsgVisa(msg) {
            document.getElementById('divMessageAreaSettlmt').style.display = "";
            document.getElementById("<%=lblMessageAreaSettlmt.ClientID%>").innerHTML = msg;
            document.getElementById('imgMessageAreaSettlmt').src = "/Images/Icons/imgMsgAreaInfo.png";

        }
        function SuccessMsgExit(msg) {
            document.getElementById('divMessageAreaExit').style.display = "";
            document.getElementById("<%=lblMessageAreaExit.ClientID%>").innerHTML = msg;
            document.getElementById('imgMessageAreaExit').src = "/Images/Icons/imgMsgAreaInfo.png";
        }
        function SuccessMsgTicket(msg) {
            document.getElementById('divMessageAreaTickt').style.display = "";
            document.getElementById("<%=lblMessageAreaTickt.ClientID%>").innerHTML = msg;
            document.getElementById('imgMessageAreaTickt').src = "/Images/Icons/imgMsgAreaInfo.png";
        }
    </script>

    <script>
        var confirmboxTickt = 0;
        function IncrmntConfrmCounterTickt() {

            confirmboxTickt++;
        }

        var confirmboxVisa = 0;
        function IncrmntConfrmCounterSettlmt() {
            confirmboxVisa++;
        }
        var confirmboxExit = 0;
        function IncrmntConfrmCounterExit() {
            confirmboxExit++;
        }

        function ConfirmCancel() {
            if (confirmboxTickt > 0 || confirmboxVisa > 0 || confirmboxExit > 0) {
                if (confirm("Are you sure you want to cancel this page?")) {
                    window.location.href = "hcm_Exit_Partial_Process_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
                
            }
            else {
                window.location.href = "hcm_Exit_Partial_Process_List.aspx";
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
                    document.getElementById("<%=ddlTicktSts.ClientID%>").focus();
                    return false;
                }
                return false;
            }
            else {
                document.getElementById("<%=ddlTicktSts.ClientID%>").value = document.getElementById("<%=HiddenFieldTicktSts.ClientID%>").value;
                document.getElementById("<%=txtTicktExptdDate.ClientID%>").value = "";
                document.getElementById("<%=ddlTicktSts.ClientID%>").focus();

                return false;
            }
        }
        function AlertClearVisaNoc() {
            if (confirmboxVisa > 0) {
                if (confirm("Are you sure you want to clear all data in this page?")) {
                    confirmboxVisa = 0;
                    document.getElementById("<%=ddlVisaNocStatus.ClientID%>").value = document.getElementById("<%=HiddenFieldVisaSts.ClientID%>").value;
                    document.getElementById("<%=txtVisaExptdDate.ClientID%>").value = "";
                    document.getElementById("<%=ddlVisaNocStatus.ClientID%>").focus();

                    return false;
                }
                return false;
            }
            else {
                document.getElementById("<%=ddlVisaNocStatus.ClientID%>").value = document.getElementById("<%=HiddenFieldVisaSts.ClientID%>").value;
                document.getElementById("<%=txtVisaExptdDate.ClientID%>").value = "";
                document.getElementById("<%=ddlVisaNocStatus.ClientID%>").focus();
                return false;

            }
        }

        function AlertClearExitPrcs() {
            if (confirmboxExit > 0) {
                if (confirm("Are you sure you want to clear all data in this page?")) {
                    confirmboxExit = 0;
                    document.getElementById("<%=ddlExitSts.ClientID%>").value = document.getElementById("<%=HiddenFieldExitSts.ClientID%>").value;
                    document.getElementById("<%=txtExitExptdDate.ClientID%>").value = "";
                    document.getElementById("<%=ddlExitSts.ClientID%>").focus();
                    return false;
                }
                return false;
            }
            else {
                document.getElementById("<%=ddlExitSts.ClientID%>").value = document.getElementById("<%=HiddenFieldExitSts.ClientID%>").value;
                document.getElementById("<%=txtExitExptdDate.ClientID%>").value = "";
                document.getElementById("<%=ddlExitSts.ClientID%>").focus();
                return false;
            }
        }











    </script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenEmpId" runat="server" />
    <asp:HiddenField ID="HiddenFieldQryId" runat="server" />
    <asp:HiddenField ID="HiddenFieldExitProcdureID" runat="server" />



    <asp:HiddenField ID="HiddenFieldTicktFinishSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldTicktCloseSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldTicktEmpDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldTicketTrgtDate" runat="server" />



    <asp:HiddenField ID="HiddenFieldSettlmtFinishSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldSettlmtCloseSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldSettlmtEmpDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldSettlmtTrgtDate" runat="server" />


    <asp:HiddenField ID="HiddenFieldExitFinishSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldExitCloseSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldExitEmpDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldExitTrgtDate" runat="server" />
    <asp:HiddenField ID="Hidddentiketneeded" runat="server" />
    <asp:HiddenField ID="Hiddenprtclrid" runat="server" />

    <asp:HiddenField ID="hiddenfromdiv" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="HiddenFieldQrylevId" runat="server" />


    <asp:HiddenField ID="Hiddendate" runat="server" />




    <asp:HiddenField ID="HiddenTicketTab" runat="server" />
    <asp:HiddenField ID="HiddenExitPermitTab" runat="server" />
    <asp:HiddenField ID="HiddenVisaNocTab" runat="server" />

    <asp:HiddenField ID="HiddenTicketFinSts" runat="server" />
    <asp:HiddenField ID="HiddenExitPermitFinSts" runat="server" />
    <asp:HiddenField ID="HiddenVisaNocFinSts" runat="server" />

    <asp:HiddenField ID="HiddenTicketCloseSts" runat="server" />
    <asp:HiddenField ID="HiddenExitPermitCloseSts" runat="server" />
    <asp:HiddenField ID="HiddenVisaNocCloseSts" runat="server" />

    <asp:HiddenField ID="HiddenTicketID" runat="server" />
    <asp:HiddenField ID="HiddenExitPermitID" runat="server" />
    <asp:HiddenField ID="HiddenVisaNocID" runat="server" />
    <asp:HiddenField ID="HiddenExitProcdureID" runat="server" />

    <asp:HiddenField ID="HiddenFieldVisaSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldTicktSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldExitSts" runat="server" />
     <asp:HiddenField ID="HiddenView" runat="server" />

    <div class="cont_rght">

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: absolute; right: 5%; top: 43.5%; height: 26.5px;">
        </div>

        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left; margin-bottom: 1%; height: 207px;">
            <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
                <asp:Label ID="lblEntry" runat="server">Exit Partial Process</asp:Label>
            </div>

            <div style="float: left; width: 98%; padding: 10px; margin-top: 2%; border: 1px solid #929292; background-color: #c9c9c9; font-family: Calibri; height: 135px;">

                <div class="eachform" style="width: 47%; float: left;margin-top: 1%;">
                    <h2 style="color: #603504;">Employee</h2>
                    <asp:Label ID="lblEmpName" class="form1" runat="server" Style="word-wrap: break-word; font-family: calibri;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;margin-top: 1%;">
                    <h2 style="color: #603504;">Designation</h2>
                    <asp:Label ID="lblDesgntn" class="form1" runat="server" Style="word-wrap: break-word; font-family: calibri;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Department</h2>
                    <asp:Label ID="lblDept" class="form1" runat="server" Style="word-wrap: break-word; font-family: calibri;"></asp:Label>
                </div>


                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Division</h2>
                    <asp:Label ID="lblDivsn" class="form1" runat="server" Style="word-wrap: break-word; font-family: calibri;overflow-x: auto;max-height: 93px;height: auto;"></asp:Label>
                </div>

            </div>

        </div>


        <%--Tabs --%>

        <div style="width: 99%; margin-top: 21%; padding: 0px;">
            <div id="divButtonTicket" onclick="divButtonTicketClick()" class="divbutton">Ticket</div>
            <div id="divButtonExit" onclick="divButtonExitClick()" class="divbutton">Exit Permit</div>
            <div id="divButtonVisaNoc" onclick="divButtonVisaNocClick()" class="divbutton">Visa/NOC</div>

        </div>



        <%-- Ticket tab--%>

        <div id="divTicket" style="border: .5px solid; border-color: #9ba48b; background-color: white; width: 98%; margin-top: 1%; padding: 2%; display: none;">

            <div id="divMessageAreaTickt" style="display: none; width: 84%; margin-left: 6%; margin-top: -1%;">
                <img id="imgMessageAreaTickt" src="" />
                <asp:Label ID="lblMessageAreaTickt" runat="server"></asp:Label>
            </div>

            <br />
            <div class="eachform" style="float: left; width: 80%;">
                <h2>Target Date</h2>
                <asp:Label ID="lblTicktTrgtDate" class="datelbl" runat="server" Style="word-wrap: break-word; font-family: calibri;"></asp:Label>
            </div>
            <div class="eachform" style="float: right; width: 13%;">
                               <asp:Label ID="lblStatsInfoTickt" class="datelbl" runat="server"  Style="padding: 3%;word-wrap: break-word; font-family: calibri;font-size: 20px;color: #377438;"></asp:Label>
            </div>
            <div class="eachform" style="float: left; margin-top: 1%; width: 80%;">
                <h2>Status*</h2>
                <asp:DropDownList ID="ddlTicktSts" class="form1" runat="server" Style="height: 30px; width: 42%; text-align: left; margin-right: 20%;" onchange="IncrmntConfrmCounterTickt();">
                     <asp:ListItem Text="Job assigned" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Availability Check" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Awaiting, Approval from candidate" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Booking Confirm, ticket copy attach" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div id="divTicktClose" runat="server" style="width: 10%; margin-left: 81%; margin-top: 3%; cursor: pointer" onclick="ClosePartialExitPrcs('TICKET')">
                <img id="imgTicktClose" runat="server" src="/Images/Icons/close guarantee.png" style="margin-left: 23%; width: 37%;" />
                <h2 style="margin-top: 1%; font-size: 15px; margin-left: 21%;">CLOSE</h2>
            </div>

            <div class="eachform" style="float: left; margin-top: 1%; width: 80%;">
                <h2>Expected Target Date</h2>

                <div id="divTicktExpDate" class="input-append date" style="float: right; width: 43%; margin-right: 19%;">

                    <asp:TextBox ID="txtTicktExptdDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height: 30px; width: 81%; margin-top: 0%; float: left;" onchange="IncrmntConfrmCounterTickt();" onkeypress="return DisableEnter(event)" onkeydown="return isTagEnter(event)" onblur="return isTag(event)"></asp:TextBox>

                    <input type="image" runat="server" onclick="IncrmntConfrmCounterTickt();" id="Image11" class="add-on" src="/Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px; margin-top: 0%;" />

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

            <div id="divTicktFinish" runat="server" style="width: 10%; margin-left: 81%; margin-top: 4%; cursor: pointer" onclick="return savePartialProcess('TICKET','1');">
                <img id="imgTicktFinish" runat="server" src="/Images/new_Icons32/Quotation.png" style="margin-left: 23%; width: 37%;" />
                <h2 style="margin-top: 1%; font-size: 15px; margin-left: 18%;">FINISH</h2>
            </div>

            <div class="eachform" style="margin-top: 2%;">
                <div class="subform" style="width: 448px; margin-right: 19%;">
                    <div class="form-group">
                        <asp:Button ID="btnAddTickt" runat="server" class="save" Text="Save" OnClientClick="return savePartialProcess('TICKET','0');" />
                        <asp:Button ID="btnClearTickt" runat="server" Style="margin-left: 11px;" class="cancel" Text="Clear" OnClientClick="return AlertClearTickt();" />
                        <asp:Button ID="btnCancelTickt" runat="server" class="cancel" Style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCancel();" />
                    </div>
                </div>
            </div>

        </div>

        <%--Settlement tab--%>

        <div id="divSettlmt" style="border: .5px solid; border-color: #9ba48b; background-color: white; width: 98%; margin-top: 1%; padding: 2%; display: none;">

            <div id="divMessageAreaSettlmt" style="display: none; width: 84%; margin-left: 6%; margin-top: -1%;">
                <img id="imgMessageAreaSettlmt" src="" />
                <asp:Label ID="lblMessageAreaSettlmt" runat="server"></asp:Label>
            </div>

            <br />
            <div class="eachform" style="float: left; width: 80%;">
                <h2>Target Date</h2>
                <asp:Label ID="lblVisaTrgtDate" class="datelbl" runat="server" Style="word-wrap: break-word; font-family: calibri;"></asp:Label>
            </div>
            <div class="eachform" style="float: right; width: 13%;">
                               <asp:Label ID="lblStatusInfoVisa" class="datelbl" runat="server"  Style="padding: 3%;word-wrap: break-word; font-family: calibri;font-size: 20px;color: #377438;"></asp:Label>
            </div>
            <div class="eachform" style="float: left; margin-top: 1%; width: 80%;">
                <h2>Status*</h2>
                <asp:DropDownList ID="ddlVisaNocStatus" class="form1" runat="server" Style="height: 30px; width: 42%; text-align: left; margin-right: 20%;" onchange="IncrmntConfrmCounterSettlmt();">
                     <asp:ListItem Text="Job assigned" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Released" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Canceled with NOC" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Canceled without NOC" Value="3"></asp:ListItem>


                </asp:DropDownList>
            </div>

            <div id="divVisaNocClose" runat="server" style="width: 10%; margin-left: 81%; margin-top: 3%; cursor: pointer" onclick="ClosePartialExitPrcs('VISA')">
                <img id="imgSetttlmtClose" runat="server" src="/Images/Icons/close guarantee.png" style="margin-left: 23%; width: 37%;" />
                <h2 style="margin-top: 1%; font-size: 15px; margin-left: 21%;">CLOSE</h2>
            </div>

            <div class="eachform" style="float: left; margin-top: 1%; width: 80%;">
                <h2>Expected Target Date</h2>

                <div id="divSettlmtExpDate" class="input-append date" style="float: right; width: 43%; margin-right: 19%;">

                    <asp:TextBox ID="txtVisaExptdDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height: 30px; width: 81%; margin-top: 0%; float: left;" onchange="IncrmntConfrmCounterSettlmt();" onkeypress="return DisableEnter(event)" onkeydown="return isTagEnter(event)" onblur="return isTag(event)"></asp:TextBox>

                    <input type="image" runat="server" onclick="IncrmntConfrmCounterSettlmt();"  id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px; margin-top: 0%;" />

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

            <div id="divVisaNocFinish" runat="server" style="width: 10%; margin-left: 81%; margin-top: 4%; cursor: pointer" onclick="return savePartialProcess('VISA','1');">
                <img id="imgSettlmtFinish" runat="server" src="/Images/new_Icons32/Quotation.png" style="margin-left: 23%; width: 37%;" />
                <h2 style="margin-top: 1%; font-size: 15px; margin-left: 18%;">FINISH</h2>
            </div>

            <div class="eachform" style="margin-top: 2%;">
                <div class="subform" style="width: 448px; margin-right: 19%;">
                    <div class="form-group">
                        <asp:Button ID="btnAddVisaNoc" runat="server" class="save" Text="Save" OnClientClick="return savePartialProcess('VISA','0');" />
                        <asp:Button ID="btnClearSettlmt" runat="server" Style="margin-left: 11px;" class="cancel" Text="Clear" OnClientClick="return AlertClearVisaNoc();" />
                        <asp:Button ID="btnCancelSettlmt" runat="server" class="cancel" Style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCancel();" />
                    </div>
                </div>
            </div>

        </div>


        <%--Exit Process tab--%>

        <div id="divExit" style="border: .5px solid; border-color: #9ba48b; background-color: white; width: 98%; margin-top: 1%; padding: 2%; display: none;">

            <div id="divMessageAreaExit" style="display: none; width: 84%; margin-left: 6%; margin-top: -1%;">
                <img id="imgMessageAreaExit" src="" />
                <asp:Label ID="lblMessageAreaExit" runat="server"></asp:Label>
            </div>

            <br />
            <div class="eachform" style="float: left; width: 80%;">
                <h2>Target Date</h2>
                <asp:Label ID="lblExitTrgtDate" class="datelbl" runat="server" Style="word-wrap: break-word; font-family: calibri;"></asp:Label>
            </div>
            <div class="eachform" style="float: right; width: 13%;">
                               <asp:Label ID="lblStatusInfoExit" class="datelbl" runat="server"  Style="padding: 3%;word-wrap: break-word; font-family: calibri;font-size: 20px;color: #377438;"></asp:Label>
            </div>
            <div class="eachform" style="float: left; margin-top: 1%; width: 80%;">
                <h2>Status*</h2>
                <asp:DropDownList ID="ddlExitSts" class="form1" runat="server" Style="height: 30px; width: 42%; text-align: left; margin-right: 20%;" onchange="IncrmntConfrmCounterExit();" onkeypress="return DisableEnter(event)" onkeydown="return isTagEnter(event)" onblur="return isTag(event)">
                    <asp:ListItem Text="Job assigned" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Processing" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Released" Value="2"></asp:ListItem>



                </asp:DropDownList>
            </div>

            <div id="divExitClose" runat="server" style="width: 10%; margin-left: 81%; margin-top: 3%; cursor: pointer" onclick="ClosePartialExitPrcs('EXIT')">
                <img id="imgExitClose" runat="server" src="/Images/Icons/close guarantee.png" style="margin-left: 23%; width: 37%;" />
                <h2 style="margin-top: 1%; font-size: 15px; margin-left: 21%;">CLOSE</h2>
            </div>

            <div class="eachform" style="float: left; margin-top: 1%; width: 80%;">
                <h2>Expected Target Date</h2>

                <div id="divExitExpDate" class="input-append date" style="float: right; width: 43%; margin-right: 19%;">

                    <asp:TextBox ID="txtExitExptdDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height: 30px; width: 81%; margin-top: 0%; float: left;" onchange="IncrmntConfrmCounterExit();" onkeypress="return DisableEnter(event)" onkeydown="return isTagEnter(event)" onblur="return isTag(event)"></asp:TextBox>

                    <input type="image" runat="server" id="Image2" onclick="IncrmntConfrmCounterExit();" class="add-on" src="/Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px; margin-top: 0%;" />

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

            <div id="divExitFinish" runat="server" style="width: 10%; margin-left: 81%; margin-top: 4%; cursor: pointer" onclick="return savePartialProcess('EXIT','1');">
                <img id="imgExitFinish" runat="server" src="/Images/new_Icons32/Quotation.png" style="margin-left: 23%; width: 37%;" />
                <h2 style="margin-top: 1%; font-size: 15px; margin-left: 18%;">FINISH</h2>
            </div>

            <div class="eachform" style="margin-top: 2%;">
                <div class="subform" style="width: 448px; margin-right: 19%;">
                    <div class="form-group">
                        <asp:Button ID="btnAddExit" runat="server" class="save" Text="Save" OnClientClick="return savePartialProcess('EXIT','0');" />
                        <asp:Button ID="btnClearExit" runat="server" Style="margin-left: 11px;" class="cancel" Text="Clear" OnClientClick="return AlertClearExitPrcs();" />
                        <asp:Button ID="btnCanceExit" runat="server" class="cancel" Style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCancel();" />
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

