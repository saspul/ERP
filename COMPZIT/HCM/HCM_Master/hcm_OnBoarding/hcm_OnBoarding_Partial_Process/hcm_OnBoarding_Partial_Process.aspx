<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_OnBoarding_Partial_Process.aspx.cs" Inherits="HCM_HCM_Master_hcm_OnBoarding_hcm_OnBoarding_Partial_Process_hcm_OnBoarding_Partial_Process" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
        .custom-file-upload {
            border: 1px solid #ccc;
            display: inline-block;
            padding: 3px 8px;
            cursor: pointer;
            position: relative;
            z-index: 2;
            background: white;
        }

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

        #divMessageAreaVisa, #divMessageAreaFlight, #divMessageAreaRoom, #divMessageAreaAirport {
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

        .datelbl {
            font-family: Calibri;
            margin-left: 27.5%;
            font-size: 15px;
        }
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
            padding: 1% 4% 0% 4%;
        }

        .modal-footerCancelView {
            padding: 1.5% 1%;
            background-color: #91a172;
            color: white;
        }

        #divErrorRsnAWMS {
            border-radius: 4px;
            background: #fff;
            color: #53844E;
            font-size: 12.5px;
            font-family: Calibri;
            font-weight: bold;
            border: 2px solid #53844E;
            margin-top: 0%;
            margin-bottom: 0%;
        }
    </style>
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
    <script>
        function divButtonVisaClick() {
            //hiding other
            document.getElementById('divButtonFlight').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonRoom').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonAirport').style.backgroundColor = "#CBCBCB";

            document.getElementById('divFlight').style.display = "none";
            document.getElementById('divRoom').style.display = "none";
            document.getElementById('divAirport').style.display = "none";


            document.getElementById('divButtonVisa').style.backgroundColor = "#f9f9f9";
            document.getElementById('divVisa').style.display = "block";
            document.getElementById('cphMain_ddlVisaSts').focus();       //12emp17
         

        }
        function divButtonFlightClick() {



            //hiding other
            document.getElementById('divButtonVisa').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonRoom').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonAirport').style.backgroundColor = "#CBCBCB";

            document.getElementById('divVisa').style.display = "none";
            document.getElementById('divRoom').style.display = "none";
            document.getElementById('divAirport').style.display = "none";


            //displaying current
            document.getElementById('divButtonFlight').style.backgroundColor = "#f9f9f9";
            document.getElementById('divFlight').style.display = "block";
            document.getElementById('cphMain_ddlFlightSts').focus();



        }
        function divButtonRoomClick() {
            //hiding other
            document.getElementById('divButtonVisa').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonFlight').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonAirport').style.backgroundColor = "#CBCBCB";

            document.getElementById('divVisa').style.display = "none";
            document.getElementById('divFlight').style.display = "none";
            document.getElementById('divAirport').style.display = "none";


            //displaying current
            document.getElementById('divButtonRoom').style.backgroundColor = "#f9f9f9";
            document.getElementById('divRoom').style.display = "block";
            document.getElementById('cphMain_ddlRoomSts').focus();    //12emp17

        }
        function divButtonAirportClick() {

            //hiding other
            document.getElementById('divButtonVisa').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonFlight').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonRoom').style.backgroundColor = "#CBCBCB";

            document.getElementById('divVisa').style.display = "none";
            document.getElementById('divFlight').style.display = "none";
            document.getElementById('divRoom').style.display = "none";


            //displaying current
            document.getElementById('divButtonAirport').style.backgroundColor = "#f9f9f9";
            document.getElementById('divAirport').style.display = "block";
            document.getElementById('cphMain_ddlAirportSts').focus();   //12emp17

        }
    </script>
    <script>
        function isTag(evt) {

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
     
        function SuccessAddFlight() {
            document.getElementById('divMessageAreaFlight').style.display = "";
            document.getElementById("<%=lblMessageAreaFlight.ClientID%>").innerHTML = "Flight details saved successfully.";
            document.getElementById('imgMessageAreaFlight').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "Flight";

        }
        function SuccessAddRoom() {
            document.getElementById('divMessageAreaRoom').style.display = "";
            document.getElementById("<%=lblMessageAreaRoom.ClientID%>").innerHTML = "Room details saved successfully.";
            document.getElementById('imgMessageAreaRoom').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "Room";

        }
        function SuccessCloseVisa() {
            document.getElementById('divMessageAreaVisa').style.display = "";
            document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = "Visa details closed successfully.";
            document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "Visa";

document.getElementById("<%=lblStatusVisa.ClientID%>").innerHTML = "Closed";
     document.getElementById("<%=lblStatusVisa.ClientID%>").style.display = "";
        }
        function SuccessCloseFlight() {
            document.getElementById('divMessageAreaFlight').style.display = "";
            document.getElementById("<%=lblMessageAreaFlight.ClientID%>").innerHTML = "Flight details closed successfully.";
            document.getElementById('imgMessageAreaFlight').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "Flight";

            document.getElementById("<%=lblStatusFlight.ClientID%>").innerHTML = "Closed";
            document.getElementById("<%=lblStatusFlight.ClientID%>").style.display = "";

        }
        function SuccessCloseRoom() {
            document.getElementById('divMessageAreaRoom').style.display = "";
            document.getElementById("<%=lblMessageAreaRoom.ClientID%>").innerHTML = "Room details closed successfully.";
            document.getElementById('imgMessageAreaRoom').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "Room";

            document.getElementById("<%=lblStatusRoom.ClientID%>").innerHTML = "Closed";
            document.getElementById("<%=lblStatusRoom.ClientID%>").style.display = "";
        }
        function SuccessCloseAirpt() {
            document.getElementById('divMessageAreaAirport').style.display = "";
            document.getElementById("<%=lblMessageAreaAirport.ClientID%>").innerHTML = "Airport details closed successfully.";
            document.getElementById('imgMessageAreaAirport').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "airport";

            document.getElementById("<%=lblStatusAirport.ClientID%>").innerHTML = "Closed";
            document.getElementById("<%=lblStatusAirport.ClientID%>").style.display = "";
        }

        
        function SuccessFinishFlight() {
            document.getElementById('divMessageAreaFlight').style.display = "";
            document.getElementById("<%=lblMessageAreaFlight.ClientID%>").innerHTML = "Flight details finished successfully.";
            document.getElementById('imgMessageAreaFlight').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "Flight";
            

            document.getElementById("<%=lblStatusFlight.ClientID%>").innerHTML = "Finished";
            document.getElementById("<%=lblStatusFlight.ClientID%>").style.display = "";
        }
        function SuccessFinishRoom() {
            document.getElementById('divMessageAreaRoom').style.display = "";
            document.getElementById("<%=lblMessageAreaRoom.ClientID%>").innerHTML = "Room details finished successfully.";
            document.getElementById('imgMessageAreaRoom').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "Room";

            document.getElementById("<%=lblStatusRoom.ClientID%>").innerHTML = "Finished";
            document.getElementById("<%=lblStatusRoom.ClientID%>").style.display = "";
        }
        function SuccessFinishAirpt() {
            document.getElementById('divMessageAreaAirport').style.display = "";
            document.getElementById("<%=lblMessageAreaAirport.ClientID%>").innerHTML = "Airport details finished successfully.";
            document.getElementById('imgMessageAreaAirport').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "airport";
            document.getElementById("<%=lblStatusAirport.ClientID%>").innerHTML = "Finished";
            document.getElementById("<%=lblStatusAirport.ClientID%>").style.display = "";

        }

        function DupVisa() {
            document.getElementById('divMessageAreaVisa').style.display = "";
            document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = "Visa details finished or closed by another user.";
            document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "Visa";

        }
        function DupFlight() {
            document.getElementById('divMessageAreaVisa').style.display = "";
            document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = "Flight details finished or closed by another user.";
            document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "Flight";

        }
        function DupRoom() {
            document.getElementById('divMessageAreaVisa').style.display = "";
            document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = "Room details finished or closed by another user.";
            document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "Room";

        }
        function Dupairpt() {
            document.getElementById('divMessageAreaVisa').style.display = "";
            document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = "Airport details finished or closed by another user.";
            document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "airport";

        }
       
       
       
        function Flightdis() {
            document.getElementById("<%=ddlFlightSts.ClientID%>").disabled = true;
            document.getElementById("<%=txtFlightTrgtDate.ClientID%>").disabled = true;
            document.getElementById("divflightTrgtDate").style.pointerEvents = "none";
            document.getElementById("cphMain_btnAddFlight").style.display = "none";
            document.getElementById("cphMain_btnClearFlight").style.display = "none";
            document.getElementById("cphMain_divFlightClose").style.display = "none";
            document.getElementById("cphMain_divFghtFinish").style.display = "none";
            document.getElementById("lblFlightTicket").style.pointerEvents = "none";
            document.getElementById("imgClearFlightTicket").style.pointerEvents = "none";

        }
        function CloseFlight() {
            if (confirm("Are you sure you want to close flight details?")) {
                var OnbrdIdDtlId = document.getElementById("<%=HiddenFieldFlightDtlId.ClientID%>").value;//For onboard detail id
                var OnbrdTblId = document.getElementById("<%=HiddenFieldTblOnbrdId.ClientID%>").value; //For onboard id
                var UserId = document.getElementById("<%=HiddenFieldLoginUserId.ClientID%>").value;

                var OnbrdId = document.getElementById("<%=HiddenFieldOnbrdId.ClientID%>").value;
                var Details = PageMethods.CloseFlight(OnbrdId, OnbrdIdDtlId, OnbrdTblId, UserId, function (response) {
                    Flightdis();
                    if (response == "false") {
                        DupFlight();
                    }
                    else {
                        SuccessCloseFlight();
                    }


                });
            }
        }
        function Roomdis() {
            document.getElementById("<%=ddlRoomSts.ClientID%>").disabled = true;
            document.getElementById("<%=txtRoomTrgtdate.ClientID%>").disabled = true;
            document.getElementById("divRoomexpcdTrgtDate").style.pointerEvents = "none";
            document.getElementById("cphMain_btnAddRoom").style.display = "none";
            document.getElementById("cphMain_btnclearRoom").style.display = "none";
            document.getElementById("cphMain_divRoomClose").style.display = "none";
            document.getElementById("cphMain_divRoomfinish").style.display = "none";
        }
        function CloseRoom() {
            if (confirm("Are you sure you want to close room details?")) {
                var OnbrdIdDtlId = document.getElementById("<%=HiddenFieldRoomDtlId.ClientID%>").value;//For onboard detail id
                var OnbrdTblId = document.getElementById("<%=HiddenFieldTblOnbrdId.ClientID%>").value; //For onboard id
                var UserId = document.getElementById("<%=HiddenFieldLoginUserId.ClientID%>").value;
                var OnbrdId = document.getElementById("<%=HiddenFieldOnbrdId.ClientID%>").value;
                var Details = PageMethods.CloseRoom(OnbrdId, OnbrdIdDtlId, OnbrdTblId, UserId, function (response) {
                    Roomdis();
                    if (response == "false") {
                        DupRoom();
                    }
                    else {
                        SuccessCloseRoom();
                    }


                });
            }
        }
        function AirptDis() {
            document.getElementById("cphMain_divAirptClose").style.display = "none";
            document.getElementById("cphMain_divAirptFinish").style.display = "none";
            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                document.getElementById("cphMain_btnCancelAirport").style.marginTop = "11%";

            }

        }
        function CloseAirpt() {
            if (confirm("Are you sure you want to close airport details?")) {
                var OnbrdIdDtlId = document.getElementById("<%=HiddenFieldAirportDtlId.ClientID%>").value;//For onboard detail id
                var OnbrdTblId = document.getElementById("<%=HiddenFieldTblOnbrdId.ClientID%>").value; //For onboard id
                var UserId = document.getElementById("<%=HiddenFieldLoginUserId.ClientID%>").value;

                var OnbrdId = document.getElementById("<%=HiddenFieldOnbrdId.ClientID%>").value;
                var Details = PageMethods.CloseAirpt(OnbrdId, OnbrdIdDtlId, OnbrdTblId, UserId, function (response) {
                    AirptDis();
                    if (response == "false") {
                        Dupairpt();
                    }
                    else {
                        SuccessCloseAirpt();
                    }


                });
            }
        }


                    document.getElementById("divButtonFlight").style.pointerEvents = "";
                
        function finishFlight() {
            if (confirm("Are you sure you want to finish flight details?")) {
                var OnbrdId = document.getElementById("<%=HiddenFieldOnbrdId.ClientID%>").value;

                var OnbrdIdDtlId = document.getElementById("<%=HiddenFieldFlightDtlId.ClientID%>").value;//For onboard detail id
                var OnbrdTblId = document.getElementById("<%=HiddenFieldTblOnbrdId.ClientID%>").value; //For onboard id
                var UserId = document.getElementById("<%=HiddenFieldLoginUserId.ClientID%>").value;

                var Details = PageMethods.finishFlight(OnbrdId, OnbrdIdDtlId, OnbrdTblId, UserId, function (response) {
                    Flightdis();

                    if (response == "false") {
                        DupFlight();
                    }
                    else {
                        SuccessFinishFlight();
                        document.getElementById("divButtonRoom").style.pointerEvents = "";
                    }
                });
            }
        }
        function finishRoom() {
            if (confirm("Are you sure you want to finish room details?")) {

            
            var OnbrdId = document.getElementById("<%=HiddenFieldOnbrdId.ClientID%>").value;
            var OnbrdIdDtlId = document.getElementById("<%=HiddenFieldRoomDtlId.ClientID%>").value;//For onboard detail id
            var OnbrdTblId = document.getElementById("<%=HiddenFieldTblOnbrdId.ClientID%>").value; //For onboard id
            var UserId = document.getElementById("<%=HiddenFieldLoginUserId.ClientID%>").value;

            var Details = PageMethods.finishRoom(OnbrdId, OnbrdIdDtlId, OnbrdTblId, UserId, function (response) {
                Roomdis();
                if (response == "false") {
                    DupRoom();
                }
                else {
                    SuccessFinishRoom();
                    document.getElementById("divButtonAirport").style.pointerEvents = "";
                }

            });
        }
        }
        function finishAirpt() {
            if (confirm("Are you sure you want to finish airport details?")) {

                var OnbrdId = document.getElementById("<%=HiddenFieldOnbrdId.ClientID%>").value;

                var OnbrdIdDtlId = document.getElementById("<%=HiddenFieldAirportDtlId.ClientID%>").value;//For onboard detail id
                var OnbrdTblId = document.getElementById("<%=HiddenFieldTblOnbrdId.ClientID%>").value; //For onboard id
                var UserId = document.getElementById("<%=HiddenFieldLoginUserId.ClientID%>").value;
                var Details = PageMethods.finishAirpt(OnbrdId, OnbrdIdDtlId, OnbrdTblId, UserId, function (response) {
                    AirptDis();
                    if (response == "false") {
                        Dupairpt();
                    }
                    else {
                        SuccessFinishAirpt();
                    }

                });
            }
        }
    </script>
    <script>

        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {

                return false;
            }
            else {
                return true;
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
                

        function AlertClearVisa() {
            if (confirmboxVisa > 0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    confirmboxVisa = 0;
                    document.getElementById("<%=ddlVisaSts.ClientID%>").value = document.getElementById("<%=HiddenFieldVisaSts.ClientID%>").value;
                    document.getElementById("<%=txtVisaExptdDate.ClientID%>").value = "";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                document.getElementById("<%=ddlVisaSts.ClientID%>").value = document.getElementById("<%=HiddenFieldVisaSts.ClientID%>").value;
                document.getElementById("<%=txtVisaExptdDate.ClientID%>").value = "";
                return false;
            }
        }

        function AlertClearFlight() {
            if (confirmboxFlight > 0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    confirmboxFlight = 0;
                    document.getElementById("<%=ddlFlightSts.ClientID%>").value = document.getElementById("<%=HiddenFieldFlightSts.ClientID%>").value;
                    document.getElementById("<%=txtFlightTrgtDate.ClientID%>").value = "";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                document.getElementById("<%=ddlFlightSts.ClientID%>").value = document.getElementById("<%=HiddenFieldFlightSts.ClientID%>").value;
                document.getElementById("<%=txtFlightTrgtDate.ClientID%>").value = "";
                return false;
            }
        }
        function AlertClearRoom() {
            if (confirmboxRoom > 0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    confirmboxRoom = 0;
                    document.getElementById("<%=ddlRoomSts.ClientID%>").value = document.getElementById("<%=HiddenFieldRoomSts.ClientID%>").value;
                    document.getElementById("<%=txtRoomTrgtdate.ClientID%>").value = "";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                document.getElementById("<%=ddlRoomSts.ClientID%>").value = document.getElementById("<%=HiddenFieldRoomSts.ClientID%>").value;
                document.getElementById("<%=txtRoomTrgtdate.ClientID%>").value = "";
                return false;
            }
        }
        function VisaAdd() {
            var ret = true;
     if (document.getElementById("<%=ddlVisaQuota.ClientID%>").value = "--SELECT VISA QUOTA--") {
                document.getElementById('visaQuota').borderColor = "red";
              document.getElementById("MymodalCancelView").style.display = "block";
           document.getElementById("freezelayer").style.display = "";
            document.getElementById("<%=ddlVisaQuota.ClientID%>").value = "--SELECT VISA QUOTA--";
           document.getElementById("<%=ddlVisaQuota.ClientID%>").focus();
            LoadVisaquottable();
             return false;

          }


            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                   
                return ret;
            }
            
          
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtVisaExptdDate.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtVisaExptdDate.ClientID%>").value = replaceText2;
            document.getElementById("<%=ddlVisaSts.ClientID%>").style.borderColor = "";
            var status = document.getElementById("<%=ddlVisaSts.ClientID%>").value;
            var OldSts = document.getElementById("<%=HiddenFieldVisaSts.ClientID%>").value;
            document.getElementById('divMessageAreaVisa').style.display = "none";
            document.getElementById('imgMessageAreaVisa').src = "";
         
            //date check start
            var CurrentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;
            var ExpDate = document.getElementById("<%=txtVisaExptdDate.ClientID%>").value;
            if (ExpDate != "" && CurrentDate != "") {
                var datepickerDate = CurrentDate;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var datepickerDate = ExpDate;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                if (dateTxIss >= dateCompExp) {
                    document.getElementById("<%=txtVisaExptdDate.ClientID%>").value = "";
                      ExpDate = "";
                      document.getElementById('divMessageAreaVisa').style.display = "";
                      document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = " Sorry,expected target date cannot be less than current date!.";
                    var txthighlit = document.getElementById("<%=txtVisaExptdDate.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=txtVisaExptdDate.ClientID%>").focus();
                      ret = false;
                  }
              }

            //end

            if (ret == false) {
                CheckSubmitZero();

            }

            return ret;
        }
        function checkVisaQuota() {
            if (document.getElementById("<%=ddlVisaQuota.ClientID%>").value = "--SELECT VISA QUOTA--") {
                document.getElementById('divMessageAreaVisa').style.display = "";
                document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = "please select visa quota.";
                    document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";
                    LoadVisaquottable();

                }
            }
        function FlightAdd() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtFlightTrgtDate.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtFlightTrgtDate.ClientID%>").value = replaceText2;
            document.getElementById("<%=ddlFlightSts.ClientID%>").style.borderColor = "";
            var status = document.getElementById("<%=ddlFlightSts.ClientID%>").value;
            var OldSts = document.getElementById("<%=HiddenFieldFlightSts.ClientID%>").value;
            document.getElementById('divMessageAreaFlight').style.display = "none";
            document.getElementById('imgMessageAreaFlight').src = "";
        
            //date check start
            var CurrentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;
            var ExpDate = document.getElementById("<%=txtFlightTrgtDate.ClientID%>").value;
            if (ExpDate != "" && CurrentDate != "") {
                var datepickerDate = CurrentDate;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var datepickerDate = ExpDate;
                  var arrDatePickerDate = datepickerDate.split("-");
                  var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                  if (dateTxIss >= dateCompExp) {
                      document.getElementById("<%=txtFlightTrgtDate.ClientID%>").value = "";
                    ExpDate = "";
                    document.getElementById('divMessageAreaFlight').style.display = "";
                    document.getElementById('imgMessageAreaFlight').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaFlight.ClientID%>").innerHTML = " Sorry,expected target date cannot be less than current date!.";
                var txthighlit = document.getElementById("<%=txtFlightTrgtDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFlightTrgtDate.ClientID%>").focus();
                    ret = false;
                }
            }

            //end



              if (ret == false) {
                  CheckSubmitZero();

              }

              return ret;
          }
          function RoomAdd() {
              var ret = true;
              if (CheckIsRepeat() == true) {
              }
              else {
                  ret = false;
                  return ret;
              }
              // replacing < and > tags
              var NameWithoutReplace = document.getElementById("<%=txtRoomTrgtdate.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtRoomTrgtdate.ClientID%>").value = replaceText2;
            document.getElementById("<%=ddlRoomSts.ClientID%>").style.borderColor = "";
            var status = document.getElementById("<%=ddlRoomSts.ClientID%>").value;
            var OldSts = document.getElementById("<%=HiddenFieldRoomSts.ClientID%>").value;
            document.getElementById('divMessageAreaRoom').style.display = "none";
            document.getElementById('imgMessageAreaRoom').src = "";
         
              //date check start
            var CurrentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;
            var ExpDate = document.getElementById("<%=txtRoomTrgtdate.ClientID%>").value;
              if (ExpDate != "" && CurrentDate != "") {
                  var datepickerDate = CurrentDate;
                  var arrDatePickerDate = datepickerDate.split("-");
                  var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                  var datepickerDate = ExpDate;
                  var arrDatePickerDate = datepickerDate.split("-");
                  var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                  if (dateTxIss >= dateCompExp) {
                      document.getElementById("<%=txtRoomTrgtdate.ClientID%>").value = "";
                    ExpDate = "";
                    document.getElementById('divMessageAreaRoom').style.display = "";
                    document.getElementById('imgMessageAreaRoom').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaRoom.ClientID%>").innerHTML = " Sorry,expected target date cannot be less than current date!.";
                      var txthighlit = document.getElementById("<%=txtRoomTrgtdate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtRoomTrgtdate.ClientID%>").focus();
                    ret = false;
                }
            }

              //end

              if (ret == false) {
                  CheckSubmitZero();

              }

              return ret;
          }
        function AlertStatus()
        {
           
            if(confirm("Are you sure you want to finish  visa details ?."))
            {
                return true; 
            }
            else {
               
                  return false;
                }

            }
           
        
          function OpenCancelView() {
              var Prvsvisatyp = document.getElementById("<%=HiddenVisaType.ClientID%>").value;
            var PrvsNation = document.getElementById("<%=HiddenNation.ClientID%>").value;
            var visamatch = document.getElementById("<%=HiddenVisamatch.ClientID%>").value;
            var select = 0;
            if (Prvsvisatyp == "" || PrvsNation == "" || visamatch == "0") {
               // alert("Are you sure you save visa details?.");
              if (confirm("Are you sure you want to  finish visa details ?.")) {
                    document.getElementById("MymodalCancelView").style.display = "block";
                    document.getElementById("freezelayer").style.display = "";
                    // document.getElementById("<%=txtCnclReason.ClientID%>").focus();
                    document.getElementById("<%=ddlVisaQuota.ClientID%>").value = "--SELECT VISA QUOTA--";
                    document.getElementById("<%=ddlVisaQuota.ClientID%>").focus();
                    LoadVisaquottable();
                }
                else { }
            }
            else {
                document.getElementById("MymodalCancelView").style.display = "block";
                document.getElementById("freezelayer").style.display = "";
                // document.getElementById("<%=txtCnclReason.ClientID%>").focus();
                document.getElementById("<%=ddlVisaQuota.ClientID%>").value = "--SELECT VISA QUOTA--";
                document.getElementById("<%=ddlVisaQuota.ClientID%>").focus();
                LoadVisaquottable();

            }


            return false;

          }
        
       
        function CloseCancelView() {
            if (confirm("Do you want to close  without completing Closing Process?")) {
                closeVisaModelView();
                return false;

            }
            else {
                return false;
            }
                }
        function LoadVisaquottable() {
            var VisaQutId = "";
            
            if (document.getElementById("<%=HiddenVisaDtlId.ClientID%>").value == "") {
                VisaQutId = document.getElementById("<%=ddlVisaQuota.ClientID%>").value;
            }
            else {

                VisaQutId = document.getElementById("<%=HiddenVisaDtlId.ClientID%>").value;
                document.getElementById("<%=ddlVisaQuota.ClientID%>").value = document.getElementById("<%=HiddenVisaDtlId.ClientID%>").value;
            }
            if (VisaQutId == "--SELECT VISA QUOTA--") {
                VisaQutId = 0;
            }
            
           
            var OnboardId = document.getElementById("<%=HiddenFieldOnbrdId.ClientID%>").value;
            var Prvsvisatyp = document.getElementById("<%=HiddenVisaType.ClientID%>").value;
            var VisaQtDtId = document.getElementById("<%=HiddenVisaname.ClientID%>").value;
            var CntryNm = document.getElementById("<%=HiddenCntryName.ClientID%>").value;
            //  var CandId = document.getElementById("<%=HiddenFieldOnbrdId.ClientID%>").value;
           // alert(Prvsvisatyp);
            var Details = PageMethods.LoadVisaTable(VisaQutId, OnboardId, Prvsvisatyp, VisaQtDtId, CntryNm, function (response) {
                
                if (response[1] != "") {
                    document.getElementById('divReport').innerHTML = response[1];
                   
                    

                }
               
                if (response[2] != "") {
                    document.getElementById("<%=HiddenConfirmChk.ClientID%>").value = response[2];
                }
                if (response[2]== "") {
                    document.getElementById("<%=HiddenConfirmChk.ClientID%>").value = "";
                }


            });
        }
          function checkboxChange(VisId, rowCount) {
              var check = 0;
              document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
              var Prvsvisatyp = document.getElementById("<%=HiddenVisaType.ClientID%>").value;
            var PrvsNation = document.getElementById("<%=HiddenNation.ClientID%>").value;
            if (Prvsvisatyp != "" || PrvsNation != "") {
                if (document.getElementById("cblcandidatelist" + rowCount).checked == true) {
                    check = 1;
                }

                $noCon('#divReport').find('input[type=checkbox]:checked').removeAttr('checked');

                var visacount = document.getElementById("tdVisanum" + rowCount).innerHTML;
                var visaType = document.getElementById("tdVisatype" + rowCount).innerHTML;
                var visaNation = document.getElementById("tdNation" + rowCount).innerHTML;

                // var visaChk = 0;
                // var nationChk = 0;

                if (check == 1) {
                    if (visacount > 0) {
                        document.getElementById("cblcandidatelist" + rowCount).checked = true;
               
                       
                    }
                }
                else {
                    document.getElementById("cblcandidatelist" + rowCount).checked = false;
                  
                }
                if (Prvsvisatyp != "" && PrvsNation != "") {

                    if (document.getElementById("<%=HiddenVisamatch.ClientID%>").value != 0) {

                        if (Prvsvisatyp == visaType && PrvsNation == visaNation) {
                            //visaChk = 1;
                        }
                        else {
                            $noCon('#divReport').find('input[type=checkbox]:checked').removeAttr('checked');
                            document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                            document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Mismatch in visa type or nation";

                        }
                    }

                }

            }
            if (document.getElementById("cblcandidatelist" + rowCount).checked == true) {

                document.getElementById("<%=btnConfirm.ClientID%>").disabled = false;
                document.getElementById("<%=HiddenConfirmChk.ClientID%>").value = VisId;
            }
            else {
                document.getElementById("<%=btnConfirm.ClientID%>").disabled = true;
               // document.getElementById("<%=HiddenConfirmChk.ClientID%>").value = VisId;
            }

              if (document.getElementById("cblcandidatelist" + rowCount).checked == false) {

               document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
               document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing or Mismatch . Please check the highlighted fields below.";
                  document.getElementById("cblcandidatelist").focus();
           
                  ret = false;
                
                }
            

        }
        function ConfirmAlert() {
           
            var ret = true;
            

           

                if (CheckIsRepeat() == true) {
                }
                else {
                    ret = false;
                    return ret;
                }
                document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
               
              
                   
                if (ret == false) {
                    CheckSubmitZero();
                    return ret;
                }
                if (ret == true) {
               

                    if (confirm("Are you sure you want to update?")) {
                        
                        ret = true;
                       
                    }
                    else {
                        CheckSubmitZero();
                        ret = false;
                    }
                }
            
             return ret;
         

        }
        //FlightTicket
        function ClearDivDisplayImageFlightTicket() {

            var hidnImageSize = document.getElementById("<%=hiddenFlightTicketFileSize.ClientID%>").value;
            var fuData = document.getElementById("<%=FileUploadFlightTicket.ClientID%>");
            var size = fuData.size;

            var convertToKb = hidnImageSize / 1000;
            if (size > hidnImageSize) {
                document.getElementById("<%=FileUploadFlightTicket.ClientID%>").value = "";
                document.getElementById("<%=Label3FlightTicket.ClientID%>").textContent = "No File Selected";
                alert(" Sorry Maximum file size exceeds. Please Upload Image of size less than " + convertToKb + "KB !.");
                //return false;
            }
            else {

                if (document.getElementById("<%=FileUploadFlightTicket.ClientID%>").value != "") {
                    document.getElementById("<%=Label3FlightTicket.ClientID%>").textContent = document.getElementById("<%=FileUploadFlightTicket.ClientID%>").value;
                    document.getElementById("<%=divImageDisplayFlightTicket.ClientID%>").innerHTML = "";
                    document.getElementById("<%=hiddenFlightTicketFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenFlightTicketFile.ClientID%>").value;
                    document.getElementById("<%=hiddenFlightTicketFile.ClientID%>").value = "";
                }

                //    return true;

            }
        }

        function ClearImageFlightTicket() {

            if (document.getElementById("<%=hiddenFlightTicketFile.ClientID%>").value != "" || document.getElementById("<%=FileUploadFlightTicket.ClientID%>").value != "") {
                if (confirm("Do You Want To Remove Selected File?")) {

                    document.getElementById("<%=FileUploadFlightTicket.ClientID%>").value = "";
                    document.getElementById("<%=hiddenFlightTicketFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenFlightTicketFile.ClientID%>").value;
                    document.getElementById("<%=hiddenFlightTicketFile.ClientID%>").value = "";
                    document.getElementById("<%=divImageDisplayFlightTicket.ClientID%>").innerHTML = "";
                    document.getElementById("<%=Label3FlightTicket.ClientID%>").textContent = "No File Selected";
                    //  alert("Image has been Removed Sucessfully. ");
                }
                else {

                }

            }
        }

        //Visa
        function ClearDivDisplayImageVisa() {

            var hidnImageSize = document.getElementById("<%=hiddenVisaFileSize.ClientID%>").value;
             var fuData = document.getElementById("<%=FileUploadVisa.ClientID%>");
             var size = fuData.size;

             var convertToKb = hidnImageSize / 1000;
             if (size > hidnImageSize) {
                 document.getElementById("<%=FileUploadVisa.ClientID%>").value = "";
                document.getElementById("<%=Label3Visa.ClientID%>").textContent = "No File Selected";
                alert(" Sorry Maximum file size exceeds. Please Upload Image of size less than " + convertToKb + "KB !.");
                //return false;
            }
            else {

                if (document.getElementById("<%=FileUploadVisa.ClientID%>").value != "") {
                    document.getElementById("<%=Label3Visa.ClientID%>").textContent = document.getElementById("<%=FileUploadVisa.ClientID%>").value;
                    document.getElementById("<%=divImageDisplayVisa.ClientID%>").innerHTML = "";
                    document.getElementById("<%=hiddenVisaFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenVisaFile.ClientID%>").value;
                    document.getElementById("<%=hiddenVisaFile.ClientID%>").value = "";
                }

                //    return true;

            }
        }

        function ClearImageVisa() {
        
            if (document.getElementById("<%=hiddenVisaFile.ClientID%>").value != "" || document.getElementById("<%=FileUploadVisa.ClientID%>").value != "") {
                if (confirm("Do You Want To Remove Selected File?")) {

                    document.getElementById("<%=FileUploadVisa.ClientID%>").value = "";
                    document.getElementById("<%=hiddenVisaFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenVisaFile.ClientID%>").value;
                    document.getElementById("<%=hiddenVisaFile.ClientID%>").value = "";
                    document.getElementById("<%=divImageDisplayVisa.ClientID%>").innerHTML = "";
                    document.getElementById("<%=Label3Visa.ClientID%>").textContent = "No File Selected";
                    //  alert("Image has been Removed Sucessfully. ");
                }
                else {

                }

            }
        }
        function clearDeleted() {
            document.getElementById("<%=hiddenVisaFileDeleted.ClientID%>").value = "";
            document.getElementById("<%=hiddenFlightTicketFileDeleted.ClientID%>").value = "";

        }
    </script>
                        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <%--hiddenfields for file upload--%>
  
        <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="HiddenView" runat="server" />
    
    <asp:HiddenField ID="hiddenFlightTicketFile" runat="server" />
    <asp:HiddenField ID="hiddenFlightTicketFileSize" runat="server" />
    <asp:HiddenField ID="hiddenFlightTicketFileDeleted" runat="server" />
        <asp:HiddenField ID="hiddenFlightTicketFileActual" runat="server" />
    
        <asp:HiddenField ID="hiddenVisaFile" runat="server" />
    <asp:HiddenField ID="hiddenVisaFileSize" runat="server" />
    <asp:HiddenField ID="hiddenVisaFileDeleted" runat="server" />
    
        <asp:HiddenField ID="hiddenVisaFileActual" runat="server" />


     <asp:HiddenField ID="HiddenFieldVisaSts" runat="server" />
     <asp:HiddenField ID="HiddenFieldFlightSts" runat="server" />
     <asp:HiddenField ID="HiddenFieldRoomSts" runat="server" />
     <asp:HiddenField ID="HiddenFieldCandId" runat="server" />
     <asp:HiddenField ID="HiddenFieldOnbrdId" runat="server" />
     <asp:HiddenField ID="HiddenFieldQryId" runat="server" />
     <asp:HiddenField ID="HiddenTab" runat="server" />
     <asp:HiddenField ID="HiddenFieldVisaCloseSts" runat="server" />
     <asp:HiddenField ID="HiddenFieldFlightCloseSts" runat="server" />
     <asp:HiddenField ID="HiddenFieldRoomCloseSts" runat="server" />
     <asp:HiddenField ID="HiddenFieldAirptCloseSts" runat="server" />
     <asp:HiddenField ID="HiddenFieldVisaFinishSts" runat="server" />
     <asp:HiddenField ID="HiddenFieldFlightFinishSts" runat="server" />
     <asp:HiddenField ID="HiddenFieldRoomFinishSts" runat="server" />
     <asp:HiddenField ID="HiddenFieldAirptFinishSts" runat="server" />
     <asp:HiddenField ID="HiddenFieldVisaTab" runat="server" />
     <asp:HiddenField ID="HiddenFieldFlightTab" runat="server" />
     <asp:HiddenField ID="HiddenFieldRoomTab" runat="server" />
     <asp:HiddenField ID="HiddenFieldAirportTab" runat="server" />

    <asp:HiddenField ID="HiddenFieldVisaOnbrdDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldFlightDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldRoomDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldAirportDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldTblOnbrdId" runat="server" />
     <asp:HiddenField ID="HiddenFieldLoginUserId" runat="server" />
        <asp:HiddenField ID="HiddenDataTable" runat="server" />
     <asp:HiddenField ID="hiddenRowCount" runat="server" />
     <asp:HiddenField ID="HiddenVisaType" runat="server" />
     <asp:HiddenField ID="HiddenNation" runat="server" />
     <asp:HiddenField ID="HiddenVisamatch" runat="server" />
     <asp:HiddenField ID="HiddenVisaDtlId" runat="server" />
         <asp:HiddenField ID="HiddenConfirmChk" runat="server" />
     <asp:HiddenField ID="HiddenVisaname" runat="server" />
     <asp:HiddenField ID="HiddenCntryName" runat="server" />
    <div id="divMessageArea" style="display: none;width:100%;">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: absolute; right: 5%; top: 43.5%; height: 26.5px;">
        </div>

        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke;float:left;margin-bottom:1%;">
            <div id="divReportCaption" style="width:100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;float:left">
                <asp:Label ID="lblEntry" runat="server">On Boarding Task</asp:Label>
            </div>

            <div style="float: left; width: 98%;padding: 10px;margin-top: 2%;border: 1px solid #929292;background-color: #c9c9c9;font-family: Calibri;">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Name</h2>
                    <asp:Label ID="lblCandtName"  class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Location</h2>
                    <asp:Label ID="lblLoctn" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Reference</h2>
                    <asp:Label ID="lblRefEmp" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Resume</h2>
                    <asp:Label ID="lblResume" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Nationality</h2>
                    <asp:Label ID="lblNation" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Visa</h2>
                    <asp:Label ID="lblVisa" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
               
            </div>



             <%--Start Tabs --%>
            <div style="width: 99%;margin-top: 21%;padding: 0px;">
            <div id="divButtonVisa" onclick="divButtonVisaClick()" class="divbutton" >Visa</div>
            <div id="divButtonFlight" onclick="divButtonFlightClick()" class="divbutton" >Flight</div> 
            <div id="divButtonRoom" onclick="divButtonRoomClick()" class="divbutton" >Room</div>
            <div id="divButtonAirport" onclick="divButtonAirportClick()" class="divbutton" >Airport</div> 
                  </div>  
            <%--Start:Visa--%>   
            <div id="divVisa" style="border:.5px solid;border-color: #9ba48b;background-color:white;width: 96%; margin-top:1%;padding:2%;display:none;"> 
                 <div id="divMessageAreaVisa" style="display:none; width: 84%; margin-left: 6%;margin-top: -1%;">
                 <img id="imgMessageAreaVisa" src="" />
                 <asp:Label ID="lblMessageAreaVisa" runat="server"></asp:Label>
                 </div>          
           
                <br />
                  <div class="eachform" style="float: right; width: 13%;">
             <asp:Label  ID="lblStatusVisa" class="datelbl" runat="server" Text="" style="display:none; padding:3%;word-wrap:break-word;font-family:calibri;font-size:20px;color:#377438;border-style:solid;"></asp:Label>
                 </div>
             <div class="eachform" style="float:left;width:80%;">
             <h2>Target Date</h2>             
             <asp:Label ID="lblVisaTrgtDate" class="datelbl"  runat="server" style="word-wrap: break-word;"></asp:Label>
            </div>
              <div class="eachform" style="float:left;margin-top:1%;width:80%;">
             <h2>Status*</h2>             
             <asp:DropDownList ID="ddlVisaSts"  TabIndex="1" class="form1" runat="server" Style="height:30px;width:42%;text-align:left;margin-right: 20%;" onchange="IncrmntConfrmCounterVisa();">
                <asp:ListItem Text="Job Assigned" Value="0"></asp:ListItem>
                <asp:ListItem Text="Document Preparation" Value="1"></asp:ListItem>
                <asp:ListItem Text="Applied,Awaiting MOI Approval" Value="2"></asp:ListItem>
                <asp:ListItem Text="MOI Approved,Ready To Print" Value="3"></asp:ListItem>
                <asp:ListItem Text="MOI Rejected–Close" Value="4"></asp:ListItem>
                <asp:ListItem Text="MOI Rejected–Reapply" Value="5"></asp:ListItem>
                <asp:ListItem Text="Visa Print Complete" Value="6"></asp:ListItem>
             </asp:DropDownList>
            </div>

             <div  id="divVisaClose" runat="server" style="width: 10%;margin-left: 81%;margin-top: 3%;cursor:pointer" onclick="CloseVisa()">
             <asp:ImageButton runat="server" tabindex="8" src="/Images/Icons/close guarantee.png" style="margin-left:23%;width:37%;"/>
              <h2 style="margin-top: 1%;font-size:15px;margin-left:21%;">CLOSE</h2>
              </div>


             <div class="eachform" style="float:left;margin-top:1%;width:80%;">
                <h2>Expected Target Date</h2>
                
               <div id="divVisaExpDate" class="input-append date" style="float: right;width: 43%;margin-right: 19%;">

                 
                   
                        <asp:TextBox ID="txtVisaExptdDate" TabIndex="2" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:82%;margin-top: 0%;float:left;" onchange="IncrmntConfrmCounterVisa();"></asp:TextBox>

                        <input type="image" runat="server" id="Image11" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

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
                            $noC('#divVisaExpDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
                  </div>
           

                  <div  id="divVisaFinish" runat="server" style="width: 10%;margin-left: 81%;margin-top: 4%;cursor:pointer"  >
             
             <asp:ImageButton id="imgVisaFinish"  TabIndex="8" runat="server" src="/Images/new_Icons32/Quotation.png" style="margin-left:23%;width:37%;" OnClientClick="return  AlertStatus();" onclick="imgVisaFinish_Click"/>
              <h2 style="margin-top: 1%;font-size:15px;margin-left:18%;">FINISH</h2>
              </div>
                 <div class="eachform" style="width: 100%; float: left;">
                <h2 id="12h" style="margin-top: 1%;">Attachments</h2>
                 <%--   --%>
                <label for="cphMain_FileUploadVisa" id="lblCertificates"  tabindex="3" class="custom-file-upload"  style="margin-left: 21%; font-family: Calibri;">
                    <img   src="../../../../Images/Icons/cloud_upload.jpg" />Upload File</label>


                <asp:FileUpload ID="FileUploadVisa"  class="fileUpload" runat="server" Style="height: 30px; display: none;" onchange="ClearDivDisplayImageVisa()" Accept="All" />


                <div id="divCertificates" runat="server" style="float: left; width: 54%; height: 20px; margin-top: 0%; margin-left:30.5%;">
                    <div  id="imgWrap2" class="imgWrap">
                        <img id="imgWrapVisa" src="/Images/Icons/clear-image-green.png" alt="Clear" title="Remove File" onclick="ClearImageVisa()" style="cursor: pointer; float: right;margin-right: 30%;" />
                    </div>
                    <div id="divImageDisplayVisa" runat="server">
                    </div>
                      
                </div>
                      <div class="eachform" style="width: 100%; float: left;">
                      <div id="visaQuota"  style="float: left;width: 10%;margin-right: 19%; cursor:pointer" >
                              <br />
                             
                         </div>
                           </div>
                     

                <asp:Label ID="Label3Visa" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
            </div>
                                             

           
           

               
           
                 <div class="eachform" style="margin-top:2%;">
                <div class="subform" style="width:448px;margin-right:19%;">
                    <div class="form-group" >   
                        <div id="divAddVisa" class="form-group" >                   
                         <asp:Button ID="btnAddVisa" tabindex="5" runat="server" class="save" Text="Save" OnClientClick="return VisaAdd();"/>
                            </div>
                         <asp:Button ID="btnClearVisa" tabindex="6" runat="server" style="margin-left: 11px;" class="cancel" Text="Clear" OnClientClick="return AlertClearVisa();"/>
                         <asp:Button ID="btnCancelVisa" tabindex="7" runat="server" class="cancel" style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCancel();"/>
                         </div>
                </div>

            </div>
                              
           
            
           
        </div>
          
            <%--End:Visa--%> 

           <%--Start:Flight--%>   
            <div id="divFlight" style="border:.5px solid;border-color: #9ba48b;background-color: white;width: 96%; margin-top:1%;padding:2%;display:none;"> 
                 <div id="divMessageAreaFlight" style="display:none; width: 84%; margin-left: 6%;margin-top: -1%;">
                 <img id="imgMessageAreaFlight" src="" />
                 <asp:Label ID="lblMessageAreaFlight" runat="server"></asp:Label>
                 </div>          
           
                <br />
                <div class="eachform" style="float: right; width: 13%;">
             <asp:Label  ID="lblStatusFlight" class="datelbl" runat="server" Text="" style="display:none;padding:3%;word-wrap:break-word;font-family:calibri;font-size:20px;color:#377438;border-style:solid;"></asp:Label>
                 </div>
             <div class="eachform" style="float:left;width:80%;" >
             <h2>Target Date</h2>             
             <asp:Label ID="lblFlightTrgtDate" class="datelbl"  runat="server" style="word-wrap: break-word;"></asp:Label>
            </div>
              <div class="eachform" style="float:left;margin-top:1%;width:80%;" >
             <h2>Status*</h2>             
             <asp:DropDownList ID="ddlFlightSts"    tabindex="1" class="form1" runat="server" Style="height:30px;width:42%;text-align:left;margin-right: 20%;" onchange="IncrmntConfrmCounterflight();">
                 <asp:ListItem Text="Job Assigned" Value="0"></asp:ListItem>
                <asp:ListItem Text="Availability Check" Value="1"></asp:ListItem>
                <asp:ListItem Text="Awaiting,Approval From Candidate" Value="2"></asp:ListItem>
                <asp:ListItem Text="Booking Confirm,Ticket Copy Attach" Value="3"></asp:ListItem>
             </asp:DropDownList>
            </div>
                 <div  id="divFlightClose" runat="server"   style="width: 10%;margin-left: 81%;margin-top: 3%;cursor:pointer" onclick="CloseFlight()">
             <img id="imgFlightClose" runat="server" src="/Images/Icons/close guarantee.png" style="margin-left:23%;width:37%;"/>
              <h2 style="margin-top: 1%;font-size:15px;margin-left:21%;" >CLOSE</h2>
              </div>
             <div class="eachform"  tabindex="2" style="float:left;margin-top:1%;width:80%;" >
                <h2>Expected Target Date</h2>
                
               <div id="divflightTrgtDate" class="input-append date" style="float: right;width: 43%;margin-right: 19%;">

                 
                   
                        <asp:TextBox ID="txtFlightTrgtDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:82%;margin-top: 0%;float:left;" onchange="IncrmntConfrmCounterflight();"></asp:TextBox>

                        <input type="image" runat="server" id="Image1" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

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
                            $noC('#divflightTrgtDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>
           <%--     <div class="eachform" style="float:left;margin-top:1%;width:80%;" >
                <h2>Attachments</h2>
                <div>
                    
<label for="cphMain_FileUploadFlightTicket" id="lblFlightTicket" class="custom-file-upload" tabindex="0" style="display: block;width: 20%;float: right;margin-right: 40%; font-family: Calibri;">
                    <img src="../../../../Images/Icons/cloud_upload.jpg" />Upload File</label>


                <asp:FileUpload ID="FileUploadFlightTicket" class="fileUpload" runat="server" Style="width:100%;height: 30px; display: none;width: 100%;" onchange="ClearDivDisplayImageFlightTicket()" Accept="All" />


                <div id="divFlightTicket" runat="server" style="float: left; width: 89%; height: 20px; margin-top: 0%; margin-left:12%;">
                    <div  id="imgWrapFlightTicket" class="imgWrap">
                        <img id="imgClearFlightTicket" src="/Images/Icons/clear-image-green.png" alt="Clear" title="Remove File" onclick="ClearImageFlightTicket()" style="cursor: pointer; float: right;" />
                    </div>
                    <div id="divImageDisplayFlightTicket" runat="server">
                    </div>
                </div>
                                              <asp:Label ID="Label3FlightTicket" runat="server" Text="" Style="display: block;font-family: Calibri; font-size: medium;"></asp:Label>
                  
                </div>
                                                      
                </div>--%>
                  <div  id="divFghtFinish" runat="server" style="width: 10%;margin-left: 81%;margin-top: 4%;cursor:pointer" onclick="finishFlight()">
             <img id="imgfghtFinish" runat="server" src="/Images/new_Icons32/Quotation.png" style="margin-left:23%;width:37%;"/>
              <h2 style="margin-top: 1%;font-size:15px;margin-left:18%;">FINISH</h2>
              </div>
                  <div class="eachform" style="width: 100%; float: left;">
                <h2 style="margin-top: 1%;">Attachments</h2>
                     <%-- --%>
                <label for="cphMain_FileUploadFlightTicket" id="lblFlightTicket" tabindex="0" class="custom-file-upload"  style="margin-left: 21%; font-family: Calibri;">
                    <img src="../../../../Images/Icons/cloud_upload.jpg" />Upload File</label>


                <asp:FileUpload ID="FileUploadFlightTicket" tabindex="3" class="fileUpload" runat="server" Style="height: 30px; display: none;" onchange="ClearDivDisplayImageFlightTicket()" Accept="All" />


                <div id="divFlightTicket" runat="server" style="float: left; width: 54%; height: 20px; margin-top: 0%; margin-left:30.5%;">
                    <div  id="Div2" class="imgWrap">
                        <img id="imgClearFlightTicket" src="/Images/Icons/clear-image-green.png" alt="Clear" title="Remove File" onclick="ClearImageFlightTicket()" style="cursor: pointer; float: right;margin-right: 30%;" />
                    </div>
                    <div id="divImageDisplayFlightTicket" runat="server">
                    </div>
                </div>z
                <asp:Label ID="Label3FlightTicket" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
            </div>

            
           
                 <div class="eachform" style="margin-top:2%;">
                <div class="subform" style="width:448px;margin-right:19%;">
                    <div class="form-group" >                     
                         <asp:Button ID="btnAddFlight" runat="server"  tabindex="0" class="save" Text="Save" OnClientClick="return FlightAdd();" OnClick="btnAddFlight_Click"/>
                         <asp:Button ID="btnClearFlight" runat="server" tabindex="0" style="margin-left: 11px;" class="cancel" Text="Clear" OnClientClick="return AlertClearFlight();"/>
                         <asp:Button ID="btnCancelFlight" runat="server" class="cancel" style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCancel();"/>
                         </div>
                </div>

            </div>
                              
           
            
           
        </div>
          
            <%--End:Flight--%> 

             <%--Start:Room--%>   
            <div id="divRoom" style="border:.5px solid;border-color: #9ba48b;background-color: white;width: 96%; margin-top:1%;padding:2%;display:none;"> 
                 <div id="divMessageAreaRoom" style="display:none; width: 84%; margin-left: 6%;margin-top: -1%;">
                 <img id="imgMessageAreaRoom" src="" />
                 <asp:Label ID="lblMessageAreaRoom" runat="server"></asp:Label>
                 </div>          
           
                <br />
                <div class="eachform" style="float: right; width: 13%;">
             <asp:Label  ID="lblStatusRoom" class="datelbl" runat="server" Text="" style="display:none;padding:3%;word-wrap:break-word;font-family:calibri;font-size:20px;color:#377438;border-style:solid;"></asp:Label>
                 </div>
             <div class="eachform" style="float:left;width:80%;">
             <h2>Target Date</h2>             
             <asp:Label ID="lblRoomTrgtDate" class="datelbl" runat="server" style="word-wrap: break-word;"></asp:Label>
            </div>
              <div class="eachform" style="float:left;margin-top:1%;width:80%;">
             <h2>Status*</h2>             
             <asp:DropDownList ID="ddlRoomSts" tabindex="4" class="form1" runat="server" Style="height:30px;width:42%;text-align:left;margin-right: 20%;" onchange="IncrmntConfrmCounterRoom();">
                 <asp:ListItem Text="Job Assigned" Value="0"></asp:ListItem>
                <asp:ListItem Text="Availability Check" Value="1"></asp:ListItem>
                <asp:ListItem Text="Facility Procurement" Value="2"></asp:ListItem>
                <asp:ListItem Text="Complete" Value="3"></asp:ListItem>
                <asp:ListItem Text="Closed Without Allotment" Value="4"></asp:ListItem>
             </asp:DropDownList>
            </div>
                 <div  id="divRoomClose" tabindex="5" runat="server"  style="width: 10%;margin-left: 81%;margin-top: 3%;cursor:pointer" onclick="CloseRoom()">
             <img id="imgRoomClose" runat="server"   src="/Images/Icons/close guarantee.png" style="margin-left:23%;width:37%;"/>
              <h2 style="margin-top: 1%;font-size:15px;margin-left:21%;">CLOSE</h2>
              </div>
             <div class="eachform" style="float:left;margin-top:1%;width:80%;">
                <h2>Expected Target Date</h2>
                
               <div id="divRoomexpcdTrgtDate" class="input-append date" style="float: right;width: 43%;margin-right: 19%;">

                 
                   
                        <asp:TextBox ID="txtRoomTrgtdate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:82%;margin-top: 0%;float:left;" onchange="IncrmntConfrmCounterRoom();"></asp:TextBox>

                        <input type="image" runat="server" id="Image2" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />
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
                            $noC('#divRoomexpcdTrgtDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>
              <div  id="divRoomfinish" runat="server" style="width: 10%;margin-left: 81%;margin-top: 4%;cursor:pointer" onclick="finishRoom()">
             <img id="imgRoomFinish" runat="server" src="/Images/new_Icons32/Quotation.png" style="margin-left:23%;width:37%;"/>
              <h2 style="margin-top: 1%;font-size:15px;margin-left:18%;">FINISH</h2>
              </div>
           
                 <div class="eachform" style="margin-top:2%;">
                <div class="subform" style="width:448px;margin-right:19%;">
                    <div class="form-group" >                     
                         <asp:Button ID="btnAddRoom" runat="server" class="save" Text="Save" OnClientClick="return RoomAdd();" OnClick="btnAddRoom_Click"/>
                         <asp:Button ID="btnclearRoom" runat="server" style="margin-left: 11px;" class="cancel" Text="Clear" OnClientClick="return AlertClearRoom();"/>
                         <asp:Button ID="btnCancelRoom" runat="server" class="cancel" style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCancel();"/>
                         </div>
                </div>

            </div>
                              
           
            
           
        </div>
          
            <%--End:Room--%> 
          
              <%--Start:Airport--%>   
            <div id="divAirport" style="border:.5px solid;border-color: #9ba48b;background-color: white;width: 96%; margin-top:1%;padding:2%;display:none;"> 
                 <div id="divMessageAreaAirport" style="display:none; width: 84%; margin-left: 6%;margin-top: -1%;">
                 <img id="imgMessageAreaAirport" src="" />
                 <asp:Label ID="lblMessageAreaAirport" runat="server"></asp:Label>
                 </div>          
           
                <br />
                <div class="eachform" style="float: right; width: 13%;">
             <asp:Label  ID="lblStatusAirport"  class="datelbl" runat="server" Text="" style="display:none;padding:3%;word-wrap:break-word;font-family:calibri;font-size:20px;color:#377438;border-style:solid;"></asp:Label>
                 </div>
             <div class="eachform" style="float:left;width:80%;">
             <h2>Target Date</h2>             
             <asp:Label ID="lblAirptTrgtdate" class="datelbl" runat="server" style="word-wrap: break-word;"></asp:Label>
            </div>
              <div class="eachform" style="float:left;margin-top:1%;width:80%;">
             <h2>Status*</h2>             
             <asp:DropDownList ID="ddlAirportSts" Enabled="false"  class="form1" runat="server" Style="height:30px;width:42%;text-align:left;margin-right: 20%;" >
              <asp:ListItem Text="Job Assigned" Value="0"></asp:ListItem>
             </asp:DropDownList>
            </div>
                 <div  id="divAirptClose" runat="server" style="width: 10%;margin-left: 81%;margin-top: 3%;cursor:pointer" onclick="CloseAirpt()">
             <img id="imgAirptClose" runat="server" src="/Images/Icons/close guarantee.png" style="margin-left:23%;width:37%;"/>
              <h2 style="margin-top: 1%;font-size:15px;margin-left:21%;">CLOSE</h2>
              </div>
             <div class="eachform" style="float:left;margin-top:1%;width:80%;display:none;">
                <h2>Expected Target Date</h2>
                
               <div id="divAirptTrgtDate" class="input-append date" style="float: right;width: 43%;margin-right: 19%;">

                 
                   
                        <asp:TextBox ID="txtAirptTrgtDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:82%;margin-top: 0%;float:left;"></asp:TextBox>

                        <input type="image" runat="server" id="Image3" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />
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
                            $noC('#divAirptTrgtDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>
              <div  id="divAirptFinish" runat="server" style="width: 10%;margin-left: 81%;margin-top: 4%;cursor:pointer" onclick="finishAirpt()">
             <img id="imgAirptFinish" runat="server" src="/Images/new_Icons32/Quotation.png" style="margin-left:23%;width:37%;"/>
              <h2 style="margin-top: 1%;font-size:15px;margin-left:18%;">FINISH</h2>
              </div>
           
                 <div class="eachform" style="margin-top:2%;">
                <div class="subform" style="width:448px;margin-right:13%;margin-top:-5%;">
                    <div class="form-group" >                     
                         <asp:Button ID="btnAddAirport" runat="server" class="save" Text="Save" style="display:none;" />
                         <asp:Button ID="btnClearAirport" runat="server" style="margin-left: 11px;display:none;" class="cancel" Text="Clear" />
                         <asp:Button ID="btnCancelAirport" runat="server" class="cancel" style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCancel();"/>
                         </div>
                </div>

            </div>
                              
           
            
           
        </div>
          
            <%--End:Airport--%> 

                                     

       
    </div>
        </div>
         <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 1%; margin-right: 1%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 42%; padding-bottom: 0.7%; padding-top: 0.6%;">VISA DETAILS</h3>
                    </div>
                    <div class="modal-bodyCancelView" style="overflow: auto;height: 360px;">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center;margin-top: 1%; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; display:none">Close Reason*</label>
                       <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;display:none" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTagOnly(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                        
                        <div style="float: left;width: 100%;">
                          <div class="eachform" style="width:25%;float:left;margin-top:10px;margin-left:1px;border: 1px solid;border-color: #9ba48b;">
                       <%-- <div class="eachform" style="width: 100%;margin-top:0%;">--%>

                <h2 style="margin-top:1%;margin-left: 33%">Visa Quota*</h2>
           <%-- </div>--%>
                  <div class="eachform" style="width: 100%; padding-left: 0.5%;padding-top:1% ;float: left;">
                        <asp:DropDownList ID="ddlVisaQuota"   class="form1" onchange="LoadVisaquottable()"  style="height:25px;width:90%;margin-left: 5%;margin-top: 0%;float: left;margin-bottom: 2%;" runat="server">
                  
                  
                     </asp:DropDownList>
        </div>
 </div>
                  <div class="eachform" style="width: 47%;  float: right;margin-top: 2%;">
                    <div class="subform" style="width: 44%; margin-left: 38%;padding: 1%;border: 2px solid rgb(207, 204, 204);margin-top: 1%;height: 21px;" >
                       
                         <asp:Button ID="btnConfirm"  runat="server" style="width: 44%;" class="save" Text="Update" OnClientClick="return ConfirmAlert();" OnClick="btnAddVisa_Click" />
                          
                         <asp:Button ID="btnCancel"   runat="server" style="width: 44%;margin-left: 1%;" class="cancel" Text="Cancel"  OnClientClick="return CloseCancelView();"  />
                     

                        </div>
                                    </div>               

               </div>
                        
                           <div id="divReport"    class="table-responsive"  style="margin-top: 1%;float: left;width: 100%;">
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
                      
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
    
    <script>

       

        function SuccessAddVisa() {

        
            document.getElementById('divMessageAreaVisa').style.display = "";
            document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = "Visa details saved successfully.";
            document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "Visa";

        }
        
        function closeVisaModelView() {
            
            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                document.getElementById("MymodalCancelView").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
        }

        function CloseVisa() {
            if (confirm("Are you sure you want to close visa details?")) {

            
                var OnbrdIdDtlId = document.getElementById("<%=HiddenFieldVisaOnbrdDtlId.ClientID%>").value;//For onboard detail id
                var OnbrdTblId = document.getElementById("<%=HiddenFieldTblOnbrdId.ClientID%>").value; //For onboard id
                var UserId = document.getElementById("<%=HiddenFieldLoginUserId.ClientID%>").value;
                var OnbrdId = document.getElementById("<%=HiddenFieldOnbrdId.ClientID%>").value;
                var Details = PageMethods.CloseVisa(OnbrdId, OnbrdIdDtlId, OnbrdTblId, UserId, function (response) {
                    visaDis();
                    if (response == "false") {
                        DupVisa();
                    }
                    else {
                        SuccessCloseVisa();
                    }


                });
            }
        }
        function ConfirmMessage() {
            if (confirmboxVisa > 0 || confirmboxFlight > 0 || confirmboxRoom > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "hcm_OnBoarding_Partial_Process_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_OnBoarding_Partial_Process_List.aspx";
                return false;
            }
        }

        function ConfirmCancel() {
       
          //  if (confirmboxVisa > 0 || confirmboxFlight > 0 || confirmboxRoom > 0) {
                if (confirm("Are you sure you want to cancel this page?")) {
                    window.location.href = "hcm_OnBoarding_Partial_Process_List.aspx";
                    return false;
                }
                else {
                    window.location.href = "hcm_OnBoarding_Partial_Process_List.aspx";
                    return false;
                }
           // }
           // else {
               
              //  return false;
            }
        function visaDis() {

            document.getElementById("<%=ddlVisaSts.ClientID%>").disabled = true;
           document.getElementById("<%=txtVisaExptdDate.ClientID%>").disabled = true;
           document.getElementById("divVisaExpDate").style.pointerEvents = "none";
           document.getElementById("cphMain_btnAddVisa").style.display = "none";
           document.getElementById("cphMain_btnClearVisa").style.display = "none";
           document.getElementById("cphMain_divVisaClose").style.display = "none";
           document.getElementById("cphMain_divVisaFinish").style.display = "none";
           document.getElementById("lblCertificates").style.pointerEvents = "none";
           document.getElementById("imgWrapVisa").style.pointerEvents = "none";

        }
        function SuccessFinishVisa() {

            document.getElementById('divMessageAreaVisa').style.display = "";
            document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = "Visa details finished successfully.";
            document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=HiddenTab.ClientID%>").value = "Visa";

            document.getElementById("<%=lblStatusVisa.ClientID%>").innerHTML = "Finished";
            document.getElementById("<%=lblStatusVisa.ClientID%>").style.display = "";
            document.getElementById("cphMain_divVisaClose").style.display = "none";
            document.getElementById("cphMain_divVisaFinish").style.display = "none";


            closeVisaModelView();

        }

    </script>
   
  <script>
      var $noCon = jQuery.noConflict();
      $noCon(window).load(function () {
          document.getElementById("freezelayer").style.display = "none";
          document.getElementById('MymodalCancelView').style.display = "none";

          if (document.getElementById("<%=HiddenFieldVisaTab.ClientID%>").value != "true") {
                document.getElementById("divButtonVisa").style.display = "none";
            }
            if (document.getElementById("<%=HiddenFieldFlightTab.ClientID%>").value != "true") {
                document.getElementById("divButtonFlight").style.display = "none";
            }
            if (document.getElementById("<%=HiddenFieldRoomTab.ClientID%>").value != "true") {
                document.getElementById("divButtonRoom").style.display = "none";
            }
            if (document.getElementById("<%=HiddenFieldAirportTab.ClientID%>").value != "true") {
                document.getElementById("divButtonAirport").style.display = "none";
            }
   
          if (document.getElementById("<%=HiddenFieldVisaFinishSts.ClientID%>").value == "1" || document.getElementById("<%=HiddenFieldVisaCloseSts.ClientID%>").value == "1") {
             
              divButtonVisaClick();
            }

            if (document.getElementById("<%=HiddenFieldFlightFinishSts.ClientID%>").value == "1" || document.getElementById("<%=HiddenFieldFlightCloseSts.ClientID%>").value == "1") {
                Flightdis();
            }
            if (document.getElementById("<%=HiddenFieldRoomFinishSts.ClientID%>").value == "1" || document.getElementById("<%=HiddenFieldRoomCloseSts.ClientID%>").value == "1") {
                Roomdis();
            }

            if (document.getElementById("<%=HiddenFieldAirptFinishSts.ClientID%>").value == "1" || document.getElementById("<%=HiddenFieldAirptCloseSts.ClientID%>").value == "1") {
                AirptDis();
            }

            if (document.getElementById("<%=HiddenFieldVisaFinishSts.ClientID%>").value != "1") {
                // document.getElementById("divButtonFlight").style.pointerEvents = "none";
            }
            if (document.getElementById("<%=HiddenFieldFlightFinishSts.ClientID%>").value != "1") {
                // document.getElementById("divButtonRoom").style.pointerEvents = "none";
            }
            if (document.getElementById("<%=HiddenFieldRoomFinishSts.ClientID%>").value != "1") {
                // document.getElementById("divButtonAirport").style.pointerEvents = "none";
            }




            var Mode = document.getElementById("<%=HiddenTab.ClientID%>").value;
            if (Mode == "Visa") {
                divButtonVisaClick();
            }
            else if (Mode == "Flight") {
                divButtonFlightClick();
            }
            else if (Mode == "Room") {
                divButtonRoomClick();
            }
            else if (Mode == "airport") {
                divButtonAirportClick();
            }
            else {


                if (document.getElementById("<%=HiddenFieldVisaTab.ClientID%>").value == "true") {
                    divButtonVisaClick();
                }
                else if (document.getElementById("<%=HiddenFieldFlightTab.ClientID%>").value == "true") {
                    divButtonFlightClick();
                    if (document.getElementById("<%=HiddenFieldVisaFinishSts.ClientID%>").value != "1") {
                        Flightdis();
                    }
                }
                else if (document.getElementById("<%=HiddenFieldRoomTab.ClientID%>").value == "true") {
                    divButtonRoomClick();
                    if (document.getElementById("<%=HiddenFieldFlightFinishSts.ClientID%>").value != "1") {
                        Roomdis();
                    }
                }
                else if (document.getElementById("<%=HiddenFieldAirportTab.ClientID%>").value == "true") {
                    divButtonAirportClick();
                    if (document.getElementById("<%=HiddenFieldRoomFinishSts.ClientID%>").value != "1") {
                        AirptDis();
                    }
                }
}

            //0008
            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                visaDis();
                Flightdis();
                Roomdis();
                AirptDis();
            }

        });



        var confirmboxVisa = 0;
        function IncrmntConfrmCounterVisa() {

            confirmboxVisa++;
        }

        var confirmboxFlight = 0;
        function IncrmntConfrmCounterflight() {
            confirmboxFlight++;
        }
        var confirmboxRoom = 0;
        function IncrmntConfrmCounterRoom() {
            confirmboxRoom++;
        }

  </script>
        <style>
        .open > .dropdown-menu {
            display: none;
        }

        .tooltipp {
            z-index: 1030;
            display: block;
            padding: 5px;
            font-size: 11px;
            opacity: 0;
            filter: alpha(opacity=0);
            visibility: visible;
        }



        .modalCancelView {
            display: none;
            position: fixed;
            z-index: 30;
            padding-top: 0%;
            left: 2%;
            top: 20%;
            width: 96%;
            height: 475px;
            overflow: auto;
            background-color: transparent;
        }
    </style>
</asp:Content>

