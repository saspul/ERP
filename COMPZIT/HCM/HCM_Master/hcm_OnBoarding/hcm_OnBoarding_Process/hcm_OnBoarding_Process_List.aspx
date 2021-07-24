<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="hcm_OnBoarding_Process_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_OnBoarding_hcm_OnBoarding_Process_hcm_OnBoarding_Process_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>
    <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>


    <script src="/JavaScript/datepicker/bootstrap-datepicker.js"></script>

    <link href="/JavaScript/datepicker/datepicker3.css" rel="stylesheet" />

    <script type="text/javascript">
        // for not allowing enter
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

        function DisableEnter(evt) {
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

        var $noC = jQuery.noConflict();

        $noCon = jQuery.noConflict();
        $noCon2 = jQuery.noConflict();
        $noCon(function () {

            document.getElementById("<%=hiddenFinishStatus.ClientID%>").value = "0";
            //Initialize Select2 Elements
            $noCon2(".select2").select2();

            document.getElementById("freezelayer").style.display = "none";
            document.getElementById("MyModalProcessMultiple").style.display = "none";
            $noCon2('#txtTargetDate1').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),
                forceParse: false
            });
            $noCon2('#txtTargetDate2').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),
                forceParse: false

            });
            $noCon2('#txtTargetDate3').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),
                forceParse: false
            });
            $noCon2('#txtTargetDate4').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),
                forceParse: false
            });
            $noCon2('#txtTargetDate5').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),
                forceParse: false
            });
            $noCon2('#txtTargetDate6').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),
                forceParse: false
            });
            $noCon2('#txtTargetDate7').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),
                forceParse: false
            });
            $noCon2('#txtTargetDate8').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),
                forceParse: false
            });
        });
    </script>
     


  
    <script type="text/javascript">
        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {

                return false;
            }
            else {
                return true;
            }
        } function CheckSubmitZero() {
            submit = 0;
        }
    </script>
    <script>
        function SuccessIns() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "On boarding process added successfully.";
            CloseProcessMulty(1);
            $(window).scrollTop(0);
        }
        //old
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "On boarding process updated successfully.";
            CloseProcessSingle(1);
        }

        function SuccessRecall() {
            document.getElementById('divpopError').style.visibility = "visible";
            document.getElementById("<%=lblPopError.ClientID%>").innerHTML = "On boarding process Recalled successfully.";
        }
        function SuccessClose() {
            document.getElementById('divpopError').style.visibility = "visible";
            document.getElementById("<%=lblPopError.ClientID%>").innerHTML = "On boarding process Closed successfully.";
        }
        function getselected() {
            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
            var strAmntList = "";
            checked = false;
            for (i = 0; i < RowCount; i++) {


                if (document.getElementById('cblcandidatelist' + i).checked) {

                    checked = true;
                    strAmntList = strAmntList + document.getElementById('tdcandiateid' + i).innerHTML + ',';

                }
            }
            if (checked == false) {
                return false;
            }

            document.getElementById("<%=Hiddenchecklist.ClientID%>").value = strAmntList;
            return true;
        }

        function selectAllCandidate() {
            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
            var strAmntList = "";
            if (document.getElementById('cbxSelectAll').checked == true) {
                for (i = 0; i < RowCount; i++) {

                    document.getElementById('cblcandidatelist' + i).checked = true;

                }
            }
            else {
                for (i = 0; i < RowCount; i++) {

                    document.getElementById('cblcandidatelist' + i).checked = false;

                }
            }
        }

        function SearchValidation() {


            var ddlManPwr = document.getElementById("<%=ddlManPower.ClientID%>").value;
            if (ddlManPwr == '--SELECT MANPOWER--') {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlManPower.ClientID%>").style.borderColor = "red";
                return false;
            }
            else {

                return true;
            }
        }
        function SelectedCandidate()
        {
        
            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
           
            var strAmntList = "";
            var strCountryList = "";
            var CheckDifferentCountry=0;
            var strManPwRqst="";
            checked = false;
            count = 0;
            for (i = 0; i < RowCount; i++) {


                if (document.getElementById('cblcandidatelist' + i).checked) {

                    checked = true;
                    count++;
                    strAmntList = strAmntList + document.getElementById('tdcandiateid' + i).innerHTML + ',';
                    //  strCountryList = strCountryList + document.getElementById('tdCountryid' + i).innerHTML + ',';
                   

             
                        var test=document.getElementById('tdManRqstid' + i).innerHTML;
                 
                        if (strManPwRqst == "")
                            strManPwRqst = document.getElementById('tdManRqstid' + i).innerHTML;
                        else {
                            if (strManPwRqst.includes(test) == false)
                            {
                                strManPwRqst = strManPwRqst + ',' + document.getElementById('tdManRqstid' + i).innerHTML;
                            }
                            //if (jQuery.inArray(  test , strManPwRqst) == -1) {
                            //    strManPwRqst = strManPwRqst + ',' + document.getElementById('tdManRqstid' + i).innerHTML;
                            //}
                        }
                        //difference.push(el);
                        //  })
                  
                    }
                }
         
       
                if (checked == false) {

                    document.getElementById('divErrorlabel').style.visibility = "visible";
                    return false;
                }
                else {


                
                }

                document.getElementById('divErrorlabel').style.visibility = "hidden";
                document.getElementById('lblNoOfselectedEmp').innerHTML = count;

                document.getElementById("<%=Hiddenchecklist.ClientID%>").value = strAmntList;
                document.getElementById("<%=HiddenManPwrId.ClientID%>").value = strManPwRqst;
                
                document.getElementById("MyModalProcessMultiple").style.display = "block";
                document.getElementById("freezelayer").style.display = "";
                return true;
            }
        
        

        function ShowProcess_Multy(EmpName, EmpId, TodayDate) {


            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
           
            var strAmntList = "";
            var strCountryList = "";
            var CheckDifferentCountry=0;
            var strManPwRqst="";
            checked = false;
            count = 0;
            for (i = 0; i < RowCount; i++) {


                if (document.getElementById('cblcandidatelist' + i).checked) {

                    checked = true;
                    count++;
                    strAmntList = strAmntList + document.getElementById('tdcandiateid' + i).innerHTML + ',';
                    //  strCountryList = strCountryList + document.getElementById('tdCountryid' + i).innerHTML + ',';
                    var test1 = document.getElementById('tdCountryid' + i).innerHTML;
                 
                    if (test1 == "" || test1 == null)
                    {
                        CheckDifferentCountry = 1;
                        document.getElementById("<%=HiddenCountryid.ClientID%>").value = "";
                    }
                    if (strCountryList == "")
                    {
                        strCountryList = document.getElementById('tdCountryid' + i).innerHTML;
                        document.getElementById("<%=HiddenCountryid.ClientID%>").value=strCountryList;
                    }
                    else {
                        if (strCountryList.includes(test1) == false)
                        {
                            CheckDifferentCountry = 1;
                            document.getElementById("<%=HiddenCountryid.ClientID%>").value = "";
                           
                        }
                        else
                        {
                            strCountryList = strCountryList + ',' + document.getElementById('tdCountryid' + i).innerHTML;
                        }

                    }
                        var test=document.getElementById('tdManRqstid' + i).innerHTML;
                 
                        if (strManPwRqst == "")
                            strManPwRqst = document.getElementById('tdManRqstid' + i).innerHTML;
                        else {
                            if (strManPwRqst.includes(test) == false)
                            {
                                strManPwRqst = strManPwRqst + ',' + document.getElementById('tdManRqstid' + i).innerHTML;
                            }
                            //if (jQuery.inArray(  test , strManPwRqst) == -1) {
                            //    strManPwRqst = strManPwRqst + ',' + document.getElementById('tdManRqstid' + i).innerHTML;
                            //}
                        }
                        //difference.push(el);
                        //  })
                  
                    }
            }
         
          
            if (checked == false) {

                document.getElementById('divErrorlabel').style.visibility = "visible";
                return false;
            }
            else {


                if (CheckDifferentCountry == 0) {
                    if (strCountryList != "" && strCountryList != null) {
                     
                        document.getElementById("<%=btnVisaBundle.ClientID%>").click();

                    }

                }
                else {
                    document.getElementById("<%=btnVisaBundle.ClientID%>").click();
                }

                document.getElementById('divErrorlabel').style.visibility = "hidden";
                document.getElementById('lblNoOfselectedEmp').innerHTML = count;

                document.getElementById("<%=Hiddenchecklist.ClientID%>").value = strAmntList;
                document.getElementById("<%=HiddenManPwrId.ClientID%>").value = strManPwRqst;
                
                document.getElementById("MyModalProcessMultiple").style.display = "block";
                document.getElementById("freezelayer").style.display = "";
                return true;
            }

        }

        function CloseProcessMulty(x) {
            if (x == 0) {
                if (confirm("Are you sure,you want to close this page?")) {
                    document.getElementById("MyModalProcessMultiple").style.display = "none";
                    document.getElementById("freezelayer").style.display = "none";
                    document.getElementById("<%=ddlVehicle.ClientID%>").value = "--VEHICLE--";
                    document.getElementById("<%=ddlRoomAltmntType.ClientID%>").value = "0";
                    document.getElementById("<%=ddlFlightTcktType.ClientID%>").value = "0";
                    document.getElementById("<%=ddlVisaType.ClientID%>").value = "--VISA PROFESSION--";
                    document.getElementById("<%=ddlVisaBund.ClientID%>").value = "--VISA QUOTA--";
                    $noC('#cphMain_ddlEmp4').val("");
                    $noC('#cphMain_ddlEmp3').val("");
                    $noC('#cphMain_ddlEmp2').val("");
                    $noC('#cphMain_ddlEmp1').val("");
                    $noC("#cphMain_ddlEmp4").trigger("change");
                    $noC("#cphMain_ddlEmp3").trigger("change");
                    $noC("#cphMain_ddlEmp2").trigger("change");
                    $noC("#cphMain_ddlEmp1").trigger("change");
                    document.getElementById("<%=ddlAirPickStats.ClientID%>").value = "0";
                    document.getElementById("<%=ddlRoomAltmntStats.ClientID%>").value = "0";
                    document.getElementById("<%=ddlFlightStatus.ClientID%>").value = "0";
                    document.getElementById("<%=ddlVisaStatus.ClientID%>").value = "0";
                    document.getElementById("<%=txtTargetDate1.ClientID%>").value = "";
                    document.getElementById("<%=txtTargetDate2.ClientID%>").value = "";
                    document.getElementById("<%=txtTargetDate3.ClientID%>").value = "";
                    document.getElementById("<%=txtTargetDate4.ClientID%>").value = "";
                    $noC('#MyModalProcessMultiple').find(':input').prop('disabled', false);
                }
            }
            else {
                document.getElementById("MyModalProcessMultiple").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
                document.getElementById("<%=ddlVehicle.ClientID%>").value = "--VEHICLE--";
                    document.getElementById("<%=ddlRoomAltmntType.ClientID%>").value = "0";
                document.getElementById("<%=ddlFlightTcktType.ClientID%>").value = "0";
                document.getElementById("<%=ddlVisaType.ClientID%>").value = "--VISA PROFESSION--";
                document.getElementById("<%=ddlVisaBund.ClientID%>").value = "--VISA QUOTA--";
                $noC('#cphMain_ddlEmp4').val("");
                $noC('#cphMain_ddlEmp3').val("");
                $noC('#cphMain_ddlEmp2').val("");
                $noC('#cphMain_ddlEmp1').val("");
                $noC("#cphMain_ddlEmp4").trigger("change");
                $noC("#cphMain_ddlEmp3").trigger("change");
                $noC("#cphMain_ddlEmp2").trigger("change");
                $noC("#cphMain_ddlEmp1").trigger("change");
                document.getElementById("<%=ddlAirPickStats.ClientID%>").value = "0";
                    document.getElementById("<%=ddlRoomAltmntStats.ClientID%>").value = "0";
                document.getElementById("<%=ddlFlightStatus.ClientID%>").value = "0";
                document.getElementById("<%=ddlVisaStatus.ClientID%>").value = "0";
                document.getElementById("<%=txtTargetDate1.ClientID%>").value = "";
                document.getElementById("<%=txtTargetDate2.ClientID%>").value = "";
                document.getElementById("<%=txtTargetDate3.ClientID%>").value = "";
                document.getElementById("<%=txtTargetDate4.ClientID%>").value = "";
                $noC('#MyModalProcessMultiple').find(':input').prop('disabled', false);
            }
        }

        function CloseProcessSingle(x) {
            if (x == 0) {
                if (confirm("Are you sure,you want to close this page?")) {

                    document.getElementById('divpopError').style.visibility = "hidden";
                    document.getElementById("MymodalProcessSingle").style.display = "none";
                    document.getElementById("freezelayer").style.display = "none";

                    document.getElementById("<%=ddlVehicle2.ClientID%>").value = "--VEHICLE--";
                    document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").value = "0";
                    document.getElementById("<%=ddlFlightTcktType2.ClientID%>").value = "0";
                    document.getElementById("<%=ddlVisatype2.ClientID%>").value = "--VISA PROFESSION--";
                    document.getElementById("<%=ddlVisaBund2.ClientID%>").value = "--VISA QUOTA--";
                    $noC('#cphMain_ddlEmp5').val("");
                    $noC('#cphMain_ddlEmp6').val("");
                    $noC('#cphMain_ddlEmp7').val("");
                    $noC('#cphMain_ddlEmp8').val("");
                    $noC("#cphMain_ddlEmp5").trigger("change");
                    $noC("#cphMain_ddlEmp6").trigger("change");
                    $noC("#cphMain_ddlEmp7").trigger("change");
                    $noC("#cphMain_ddlEmp8").trigger("change");
                    document.getElementById("<%=ddlAirPickStats2.ClientID%>").value = "0";
                    document.getElementById("<%=ddlRoomAltmntStats2.ClientID%>").value = "0";
                    document.getElementById("<%=ddlFlightStatus2.ClientID%>").value = "0";
                    document.getElementById("<%=ddlVisaStatus2.ClientID%>").value = "0";
                    document.getElementById("<%=txtTargetDate8.ClientID%>").value = "";
                    document.getElementById("<%=txtTargetDate7.ClientID%>").value = "";
                    document.getElementById("<%=txtTargetDate6.ClientID%>").value = "";
                    document.getElementById("<%=txtTargetDate5.ClientID%>").value = "";

                    document.getElementById("<%=FileUploadVisaMulty.ClientID%>").value = "";
                    document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>").value = "";

                    document.getElementById('VisaFinish2').style.pointerEvents = "";
                    document.getElementById('VisaFinish2').style.opacity = "1";
                    document.getElementById('roomFinish2').style.pointerEvents = "";
                    document.getElementById('roomFinish2').style.opacity = "1";
                    document.getElementById('AirFinish2').style.pointerEvents = "";
                    document.getElementById('AirFinish2').style.opacity = "1";
                    document.getElementById('FliFinish2').style.pointerEvents = "";
                    document.getElementById('FliFinish2').style.opacity = "1";


                    document.getElementById('VisaClose2').style.pointerEvents = "";
                    document.getElementById('VisaClose2').style.opacity = "1";
                    document.getElementById('VisaClose2').style.display = "";
                    document.getElementById('FliClose2').style.pointerEvents = "";
                    document.getElementById('FliClose2').style.opacity = "1";
                    document.getElementById('FliClose2').style.display = "";
                    document.getElementById('RoomClose2').style.pointerEvents = "";
                    document.getElementById('RoomClose2').style.opacity = "1";
                    document.getElementById('RoomClose2').style.display = "";
                    document.getElementById('AirClose2').style.pointerEvents = "";
                    document.getElementById('AirClose2').style.opacity = "1";
                    document.getElementById('AirClose2').style.display = "";

                    document.getElementById('VisaRecall2').style.display = "none";
                    document.getElementById('FliRecall2').style.display = "none";
                    document.getElementById('RoomRecall2').style.display = "none";
                    document.getElementById('AirRecall2').style.display = "none";



                    $noC('#MymodalProcessSingle').find(':input').prop('disabled', false);
                }
            }
            else {
                document.getElementById('divpopError').style.visibility = "hidden";
                document.getElementById("MymodalProcessSingle").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";

                document.getElementById("<%=ddlVehicle2.ClientID%>").value = "--VEHICLE--";
                    document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").value = "0";
                document.getElementById("<%=ddlFlightTcktType2.ClientID%>").value = "0";
                document.getElementById("<%=ddlVisatype2.ClientID%>").value = "--VISA PROFESSION--";
                document.getElementById("<%=ddlVisaBund2.ClientID%>").value = "--VISA QUOTA--";
                $noC('#cphMain_ddlEmp5').val("");
                $noC('#cphMain_ddlEmp6').val("");
                $noC('#cphMain_ddlEmp7').val("");
                $noC('#cphMain_ddlEmp8').val("");
                $noC("#cphMain_ddlEmp5").trigger("change");
                $noC("#cphMain_ddlEmp6").trigger("change");
                $noC("#cphMain_ddlEmp7").trigger("change");
                $noC("#cphMain_ddlEmp8").trigger("change");
                document.getElementById("<%=ddlAirPickStats2.ClientID%>").value = "0";
                    document.getElementById("<%=ddlRoomAltmntStats2.ClientID%>").value = "0";
                document.getElementById("<%=ddlFlightStatus2.ClientID%>").value = "0";
                document.getElementById("<%=ddlVisaStatus2.ClientID%>").value = "0";
                document.getElementById("<%=txtTargetDate8.ClientID%>").value = "";
                document.getElementById("<%=txtTargetDate7.ClientID%>").value = "";
                document.getElementById("<%=txtTargetDate6.ClientID%>").value = "";
                document.getElementById("<%=txtTargetDate5.ClientID%>").value = "";

                document.getElementById("<%=FileUploadVisaMulty.ClientID%>").value = "";
                document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>").value = "";

                document.getElementById('VisaFinish2').style.pointerEvents = "";
                document.getElementById('VisaFinish2').style.opacity = "1";
                document.getElementById('roomFinish2').style.pointerEvents = "";
                document.getElementById('roomFinish2').style.opacity = "1";
                document.getElementById('AirFinish2').style.pointerEvents = "";
                document.getElementById('AirFinish2').style.opacity = "1";
                document.getElementById('FliFinish2').style.pointerEvents = "";
                document.getElementById('FliFinish2').style.opacity = "1";


                document.getElementById('VisaClose2').style.pointerEvents = "";
                document.getElementById('VisaClose2').style.opacity = "1";
                document.getElementById('VisaClose2').style.display = "";
                document.getElementById('FliClose2').style.pointerEvents = "";
                document.getElementById('FliClose2').style.opacity = "1";
                document.getElementById('FliClose2').style.display = "";
                document.getElementById('RoomClose2').style.pointerEvents = "";
                document.getElementById('RoomClose2').style.opacity = "1";
                document.getElementById('RoomClose2').style.display = "";
                document.getElementById('AirClose2').style.pointerEvents = "";
                document.getElementById('AirClose2').style.opacity = "1";
                document.getElementById('AirClose2').style.display = "";

                document.getElementById('VisaRecall2').style.display = "none";
                document.getElementById('FliRecall2').style.display = "none";
                document.getElementById('RoomRecall2').style.display = "none";
                document.getElementById('AirRecall2').style.display = "none";



                $noC('#MymodalProcessSingle').find(':input').prop('disabled', false);
            }
        }

        function ValidateProcessSingle() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            var VisaBundle = document.getElementById("<%=ddlVisaBund2.ClientID%>");
            var VisaTypeText = VisaBundle.options[VisaBundle.selectedIndex].text;

            var VisaType = document.getElementById("<%=ddlVisatype2.ClientID%>");
            var VisaTypeText = VisaType.options[VisaType.selectedIndex].text;

            var FlightType = document.getElementById("<%=ddlFlightTcktType2.ClientID%>");
            var FlightTypeText = FlightType.options[FlightType.selectedIndex].text;

            var RoomType = document.getElementById("<%=ddlRoomAltmntType2.ClientID%>");
            var RoomTypeText = RoomType.options[RoomType.selectedIndex].text;

            var VehicleType = document.getElementById("<%=ddlVehicle2.ClientID%>");
            var VehicleTypeText = VehicleType.options[VehicleType.selectedIndex].text;




            var VisaStatus = document.getElementById("<%=ddlVisaStatus2.ClientID%>");
            var VisaStatusText = VisaStatus.options[VisaStatus.selectedIndex].text;

            var FlightStatus = document.getElementById("<%=ddlFlightStatus2.ClientID%>");
            var FlightStatusText = FlightStatus.options[FlightStatus.selectedIndex].text;

            var RoomStatus = document.getElementById("<%=ddlRoomAltmntStats2.ClientID%>");
            var RoomStatusText = RoomStatus.options[RoomStatus.selectedIndex].text;

            var VehicleStatus = document.getElementById("<%=ddlAirPickStats2.ClientID%>");
            var VehicleStatusText = VehicleStatus.options[VehicleStatus.selectedIndex].text;

            var VisaDate = document.getElementById("<%=txtTargetDate5.ClientID%>").value.trim();
            var FlightDate = document.getElementById("<%=txtTargetDate6.ClientID%>").value.trim();
            var RoomDate = document.getElementById("<%=txtTargetDate7.ClientID%>").value.trim();
            var VehicleDate = document.getElementById("<%=txtTargetDate8.ClientID%>").value.trim();


            document.getElementById("<%=ddlVisaBund2.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlVehicle2.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlFlightTcktType2.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlVisatype2.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlEmp8.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlEmp7.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlEmp6.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlEmp5.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlAirPickStats2.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlRoomAltmntStats2.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlFlightStatus2.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlVisaStatus2.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTargetDate8.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTargetDate7.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTargetDate6.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTargetDate5.ClientID%>").style.borderColor = "";



            //new 
            var vaildRows = 0;
            if (VehicleDate != "" || document.getElementById("<%=ddlEmp8.ClientID%>").value != "" || VehicleTypeText != "--VEHICLE--") {
                vaildRows++;
                if (VehicleDate == "") {
                    document.getElementById("<%=txtTargetDate8.ClientID%>").style.borderColor = "red";
                       ret = false;
                   }
                   if (document.getElementById("<%=ddlEmp8.ClientID%>").value == "") {

                    document.getElementById("<%=ddlEmp8.ClientID%>").style.borderColor = "red";
                      document.getElementById("<%=ddlEmp8.ClientID%>").focus();
                      ret = false;
                  }
                  if (VehicleTypeText == "--VEHICLE--") {
                      document.getElementById("<%=ddlVehicle2.ClientID%>").style.borderColor = "red";
                      document.getElementById("<%=ddlVehicle2.ClientID%>").focus();
                      ret = false;
                  }
                  if (VehicleStatusText == "--SELECT--") {
                      document.getElementById("<%=ddlAirPickStats2.ClientID%>").style.borderColor = "red";
                      document.getElementById("<%=ddlAirPickStats2.ClientID%>").focus();
                      ret = false;
                  }

              }
              if (RoomDate != "" || document.getElementById("<%=ddlEmp7.ClientID%>").value != "" || RoomTypeText != "--SELECT--") {
                vaildRows++;
                // 	Room Allotment
                if (RoomDate == "") {
                    document.getElementById("<%=txtTargetDate7.ClientID%>").style.borderColor = "red";
                    ret = false;
                }
                if (document.getElementById("<%=ddlEmp7.ClientID%>").value == "") {

                      document.getElementById("<%=ddlEmp7.ClientID%>").style.borderColor = "red";
                      document.getElementById("<%=ddlEmp7.ClientID%>").focus();
                      ret = false;
                  }
                  if (RoomStatusText == "--SELECT--") {
                      document.getElementById("<%=ddlRoomAltmntStats2.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlRoomAltmntStats2.ClientID%>").focus();
                ret = false;
            }
            if (RoomTypeText == "--SELECT--") {
                document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").style.borderColor = "red";
                  document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").focus();
                  ret = false;
              }

          }

            if (FlightDate != "" || document.getElementById("<%=ddlEmp6.ClientID%>").value != "" || FlightTypeText != "--SELECT--" || document.getElementById("<%=FileUploadFlightTicketSingle.ClientID%>").value != "") {
                vaildRows++;
                // 	Flight Ticket


                if (FlightDate == "") {
                    document.getElementById("<%=txtTargetDate6.ClientID%>").style.borderColor = "red";
                    ret = false;
                }

                if (document.getElementById("<%=ddlEmp6.ClientID%>").value == "") {

                  document.getElementById("<%=ddlEmp6.ClientID%>").style.borderColor = "red";
                      document.getElementById("<%=ddlEmp6.ClientID%>").focus();
                      ret = false;
                  }
                  if (FlightStatusText == "--SELECT--") {
                      document.getElementById("<%=ddlFlightStatus2.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlFlightStatus2.ClientID%>").focus();
                ret = false;
            }
            if (FlightTypeText == "--SELECT--") {
                document.getElementById("<%=ddlFlightTcktType2.ClientID%>").style.borderColor = "red";
                  document.getElementById("<%=ddlFlightTcktType2.ClientID%>").focus();
                  ret = false;
              }
          }


            if (VisaDate != "" || document.getElementById("<%=ddlEmp1.ClientID%>").value != "" || VisaTypeText != "--VISA QUOTA--" || VisaTypeText != "--VISA PROFESSION--" || document.getElementById("<%=FileUploadVisaSingle.ClientID%>").value != "") {
                vaildRows++;
                // 	Visa

                if (VisaDate == "") {
                    document.getElementById("<%=txtTargetDate5.ClientID%>").style.borderColor = "red";
                    ret = false;
                }

                if (VisaStatusText == "--SELECT--") {
                    document.getElementById("<%=ddlVisaStatus2.ClientID%>").style.borderColor = "red";
                      document.getElementById("<%=ddlVisaStatus2.ClientID%>").focus();
                      ret = false;
                  }
                  if (document.getElementById("<%=ddlEmp5.ClientID%>").value == "") {

                  document.getElementById("<%=ddlEmp5.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlEmp5.ClientID%>").focus();
                ret = false;
            }

                if (VisaTypeText == "--VISA PROFESSION--") {
                document.getElementById("<%=ddlVisatype2.ClientID%>").style.borderColor = "red";
                  document.getElementById("<%=ddlVisatype2.ClientID%>").focus();
                  ret = false;
            }

                if (VisaTypeText == "--VISA QUOTA--") {
                    document.getElementById("<%=ddlVisaBund2.ClientID%>").style.borderColor = "red";
                      document.getElementById("<%=ddlVisaBund2.ClientID%>").focus();
                      ret = false;
                  }
          }
            //new ends

            //old
            //va0085
            //old ends

          document.getElementById("divErrorNotificationPrcsMlty").style.visibility = "hidden";
          if (vaildRows > 0) {

          }
          else {

              document.getElementById("divErrorNotificationPrcsMlty").style.visibility = "visible";
              document.getElementById("<%=lblErrorNotificationPrcsMlty.ClientID%>").innerText = "No data in any fields";
                ret = false;
            }


            if (ret == false) {
                CheckSubmitZero();

            }
            else {
                $noC('#MymodalProcessSingle').find(':input').prop('disabled', false);

                var Emp1val = $noC('#cphMain_ddlEmp5').val();
                var Emp2val = $noC('#cphMain_ddlEmp6').val();
                var Emp3val = $noC('#cphMain_ddlEmp7').val();
                var Emp4val = $noC('#cphMain_ddlEmp8').val();
                document.getElementById("<%=hiddenEmp1.ClientID%>").value = Emp1val;
                document.getElementById("<%=hiddenEmp2.ClientID%>").value = Emp2val;
                document.getElementById("<%=hiddenEmp3.ClientID%>").value = Emp3val;
                document.getElementById("<%=hiddenEmp4.ClientID%>").value = Emp4val;
            }

            return ret;
        }

        function ValidateProcessMulty() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            var VisaBundle = document.getElementById("<%=ddlVisaBund.ClientID%>");
            var VisaBundleText = VisaBundle.options[VisaBundle.selectedIndex].text;

            var VisaType = document.getElementById("<%=ddlVisaType.ClientID%>");
            var VisaTypeText = VisaType.options[VisaType.selectedIndex].text;

            var FlightType = document.getElementById("<%=ddlFlightTcktType.ClientID%>");
              var FlightTypeText = FlightType.options[FlightType.selectedIndex].text;

              var RoomType = document.getElementById("<%=ddlRoomAltmntType.ClientID%>");
            var RoomTypeText = RoomType.options[RoomType.selectedIndex].text;

            var VehicleType = document.getElementById("<%=ddlVehicle.ClientID%>");
            var VehicleTypeText = VehicleType.options[VehicleType.selectedIndex].text;




            var VisaStatus = document.getElementById("<%=ddlVisaStatus.ClientID%>");
            var VisaStatusText = VisaStatus.options[VisaStatus.selectedIndex].text;

            var FlightStatus = document.getElementById("<%=ddlFlightStatus.ClientID%>");
            var FlightStatusText = FlightStatus.options[FlightStatus.selectedIndex].text;

            var RoomStatus = document.getElementById("<%=ddlRoomAltmntStats.ClientID%>");
            var RoomStatusText = RoomStatus.options[RoomStatus.selectedIndex].text;

            var VehicleStatus = document.getElementById("<%=ddlAirPickStats.ClientID%>");
            var VehicleStatusText = VehicleStatus.options[VehicleStatus.selectedIndex].text;

            var VisaDate = document.getElementById("<%=txtTargetDate1.ClientID%>").value.trim();
            var FlightDate = document.getElementById("<%=txtTargetDate2.ClientID%>").value.trim();
            var RoomDate = document.getElementById("<%=txtTargetDate3.ClientID%>").value.trim();
            var VehicleDate = document.getElementById("<%=txtTargetDate4.ClientID%>").value.trim();

            document.getElementById("<%=ddlVehicle.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlRoomAltmntType.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlFlightTcktType.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlVisaType.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlVisaBund.ClientID%>").style.borderColor = "";

            document.getElementById("<%=ddlEmp4.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlEmp3.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlEmp2.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlEmp1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlAirPickStats.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlRoomAltmntStats.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlFlightStatus.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlVisaStatus.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTargetDate4.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTargetDate3.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTargetDate2.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTargetDate1.ClientID%>").style.borderColor = "";



            var vaildRows = 0;
            if (VehicleDate != "" || document.getElementById("<%=ddlEmp4.ClientID%>").value != "" || VehicleTypeText != "--VEHICLE--") {
                //Air Port Pickup
                vaildRows++;
                if (VehicleDate == "") {
                    document.getElementById("<%=txtTargetDate4.ClientID%>").style.borderColor = "red";
                      ret = false;
                  }
                  if (document.getElementById("<%=ddlEmp4.ClientID%>").value == "") {

                      document.getElementById("<%=ddlEmp4.ClientID%>").style.borderColor = "red";
                      document.getElementById("<%=ddlEmp4.ClientID%>").focus();
                      ret = false;
                  }
                  if (VehicleTypeText == "--VEHICLE--") {
                      document.getElementById("<%=ddlVehicle.ClientID%>").style.borderColor = "red";
                      document.getElementById("<%=ddlVehicle.ClientID%>").focus();
                      ret = false;
                  }
                  if (VehicleStatusText == "--SELECT--") {
                      document.getElementById("<%=ddlAirPickStats.ClientID%>").style.borderColor = "red";
                      document.getElementById("<%=ddlAirPickStats.ClientID%>").focus();
                      ret = false;
                  }

              }
              if (RoomDate != "" || document.getElementById("<%=ddlEmp3.ClientID%>").value != "" || RoomTypeText != "--SELECT--") {
                vaildRows++;
                // 	Room Allotment
                if (RoomDate == "") {
                    document.getElementById("<%=txtTargetDate3.ClientID%>").style.borderColor = "red";
                      ret = false;
                  }
                  if (document.getElementById("<%=ddlEmp3.ClientID%>").value == "") {

                      document.getElementById("<%=ddlEmp3.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlEmp3.ClientID%>").focus();
                ret = false;
            }
            if (RoomStatusText == "--SELECT--") {
                document.getElementById("<%=ddlRoomAltmntStats.ClientID%>").style.borderColor = "red";
                  document.getElementById("<%=ddlRoomAltmntStats.ClientID%>").focus();
                  ret = false;
              }
              if (RoomTypeText == "--SELECT--") {
                  document.getElementById("<%=ddlRoomAltmntType.ClientID%>").style.borderColor = "red";
                  document.getElementById("<%=ddlRoomAltmntType.ClientID%>").focus();
                  ret = false;
              }

          }

            if (FlightDate != "" || document.getElementById("<%=ddlEmp2.ClientID%>").value != "" || FlightTypeText != "--SELECT--" || document.getElementById("<%=FileUploadVisaMulty.ClientID%>").value != "") {
                vaildRows++;
                // 	Flight Ticket

                if (FlightDate == "") {
                    document.getElementById("<%=txtTargetDate2.ClientID%>").style.borderColor = "red";
                
                      ret = false;
                  }

                  if (document.getElementById("<%=ddlEmp2.ClientID%>").value == "") {

                  document.getElementById("<%=ddlEmp2.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlEmp2.ClientID%>").focus();
                ret = false;
            }
            if (FlightStatusText == "--SELECT--") {
                document.getElementById("<%=ddlFlightStatus.ClientID%>").style.borderColor = "red";
                  document.getElementById("<%=ddlFlightStatus.ClientID%>").focus();
                  ret = false;
              }
              if (FlightTypeText == "--SELECT--") {
                  document.getElementById("<%=ddlFlightTcktType.ClientID%>").style.borderColor = "red";
                  document.getElementById("<%=ddlFlightTcktType.ClientID%>").focus();
                  ret = false;
              }
          }


            if (VisaDate != "" || document.getElementById("<%=ddlEmp1.ClientID%>").value != "" || VisaBundleText != "--VISA QUOTA--" || VisaTypeText != "--VISA PROFESSION--" || document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>").value != "") {
                vaildRows++;
                // 	Visa
                if (VisaDate == "") {
                    document.getElementById("<%=txtTargetDate1.ClientID%>").style.borderColor = "red";
                   
                      ret = false;
                  }

                  if (VisaStatusText == "--SELECT--") {
                      document.getElementById("<%=ddlVisaStatus.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlVisaStatus.ClientID%>").focus();
                ret = false;
            }
            if (document.getElementById("<%=ddlEmp1.ClientID%>").value == "") {

                  document.getElementById("<%=ddlEmp1.ClientID%>").style.borderColor = "red";
                  document.getElementById("<%=ddlEmp1.ClientID%>").focus();
                  ret = false;
              }

                if (VisaTypeText == "--VISA PROFESSION--") {
                  document.getElementById("<%=ddlVisaType.ClientID%>").style.borderColor = "red";
                  document.getElementById("<%=ddlVisaType.ClientID%>").focus();
                  ret = false;
              }
              
                if (VisaBundleText == "--VISA QUOTA--") {
                    document.getElementById("<%=ddlVisaBund.ClientID%>").style.borderColor = "red";
                      document.getElementById("<%=ddlVisaBund.ClientID%>").focus();
                      ret = false;
                  }

          }
          document.getElementById("divErrorNotificationPrcsMlty").style.visibility = "hidden";
          if (vaildRows > 0) {

          }
          else {

              document.getElementById("divErrorNotificationPrcsMlty").style.visibility = "visible";
              document.getElementById("<%=lblErrorNotificationPrcsMlty.ClientID%>").innerText = "No data in any fields";
                ret = false;
            }


            if (ret == false) {
                CheckSubmitZero();

            }
            else {
                var Emp1val = $noC('#cphMain_ddlEmp1').val();
                var Emp2val = $noC('#cphMain_ddlEmp2').val();
                var Emp3val = $noC('#cphMain_ddlEmp3').val();
                var Emp4val = $noC('#cphMain_ddlEmp4').val();
                document.getElementById("<%=hiddenEmp1.ClientID%>").value = Emp1val;
              document.getElementById("<%=hiddenEmp2.ClientID%>").value = Emp2val;
              document.getElementById("<%=hiddenEmp3.ClientID%>").value = Emp3val;
              document.getElementById("<%=hiddenEmp4.ClientID%>").value = Emp4val;
          }

          return ret;
      }
      function DisableButton2(type) {

          if (type == "Visa2") {
              document.getElementById('VisaFinish2').style.pointerEvents = "none";
              document.getElementById('VisaFinish2').style.opacity = ".5";

              document.getElementById('VisaClose2').style.pointerEvents = "none";
              document.getElementById('VisaClose2').style.opacity = ".5";
          }
          if (type == "Flight2") {
              document.getElementById('FliFinish2').style.pointerEvents = "none";
              document.getElementById('FliFinish2').style.opacity = ".5";
              document.getElementById('FliClose2').style.pointerEvents = "none";
              document.getElementById('FliClose2').style.opacity = ".5";
          }
          if (type == "Room2") {
              document.getElementById('roomFinish2').style.pointerEvents = "none";
              document.getElementById('roomFinish2').style.opacity = ".5";
              document.getElementById('RoomClose2').style.pointerEvents = "none";
              document.getElementById('RoomClose2').style.opacity = ".5";

          }
          if (type == "AirPick2") {
              document.getElementById('AirFinish2').style.pointerEvents = "none";
              document.getElementById('AirFinish2').style.opacity = ".5";
              document.getElementById('AirClose2').style.pointerEvents = "none";
              document.getElementById('AirClose2').style.opacity = ".5";
          }

      }
     
      function FinishProcess2(Type) {
          var TypePass = Type;
          if (confirm("Are you sure? You want to finish this task.")) {
              var TypeTotal = document.getElementById("<%=hiddenFinishStatus.ClientID%>").value;
              
              if (Type == "Visa2") {
                  document.getElementById("<%=txtTargetDate5.ClientID%>").style.borderColor = "";
                  document.getElementById("<%=ddlVisatype2.ClientID%>").style.borderColor = "";
                  document.getElementById("<%=ddlVisaBund2.ClientID%>").style.borderColor = "";
                
                  if (document.getElementById("<%=ddlVisaBund2.ClientID%>").value != "--VISA QUOTA--" && document.getElementById("<%=ddlVisatype2.ClientID%>").value != "--VISA PROFESSION--" && document.getElementById("<%=txtTargetDate5.ClientID%>").value != "" && document.getElementById("<%=ddlEmp5.ClientID%>").value != "") {

                      document.getElementById("<%=ddlVisatype2.ClientID%>").disabled = true;
                      document.getElementById("<%=ddlVisaBund2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmp5.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlVisaStatus2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate5.ClientID%>").disabled = true;
                        document.getElementById('tdFileVisa').style.pointerEvents = "none";

                    }
                  else {


                      if (document.getElementById("<%=ddlEmp5.ClientID%>").value == "") {
                          document.getElementById("<%=ddlEmp5.ClientID%>").focus();
                      }

                      if (document.getElementById("<%=txtTargetDate5.ClientID%>").value == "") {
                          document.getElementById("<%=txtTargetDate5.ClientID%>").style.borderColor = "Red";

                       }
                      if (document.getElementById("<%=ddlVisatype2.ClientID%>").value == "--VISA PROFESSION--") {
                              document.getElementById("<%=ddlVisatype2.ClientID%>").style.borderColor = "Red";
                              document.getElementById("<%=ddlVisatype2.ClientID%>").focus();
                          }
                      if (document.getElementById("<%=ddlVisaBund2.ClientID%>").value == "--VISA QUOTA--") {
                          document.getElementById("<%=ddlVisaBund2.ClientID%>").style.borderColor = "Red";
                              document.getElementById("<%=ddlVisaBund2.ClientID%>").focus();
                          }
                    

                        return false;
                    }
                }

              if (Type == "Flight2") {

                  document.getElementById("<%=txtTargetDate6.ClientID%>").style.borderColor = "";
                  document.getElementById("<%=ddlFlightTcktType2.ClientID%>").style.borderColor = "";


                  Type = Type + "," + "Visa2";
                  if (document.getElementById("<%=ddlFlightTcktType2.ClientID%>").value != "0" && document.getElementById("<%=txtTargetDate6.ClientID%>").value != "" && document.getElementById("<%=ddlEmp6.ClientID%>").value != "") {
                      document.getElementById("<%=ddlFlightTcktType2.ClientID%>").disabled = true;
                      document.getElementById("<%=ddlEmp6.ClientID%>").disabled = true;
                      document.getElementById("<%=ddlFlightStatus2.ClientID%>").disabled = true;
                      document.getElementById("<%=txtTargetDate6.ClientID%>").disabled = true;
                      document.getElementById('tdFileFlight').style.pointerEvents = "none";

                  } else {

                      if (document.getElementById("<%=ddlEmp6.ClientID%>").value == "") {
                          document.getElementById("<%=ddlEmp6.ClientID%>").focus();
                      }

                      if (document.getElementById("<%=txtTargetDate6.ClientID%>").value == "") {
                          document.getElementById("<%=txtTargetDate6.ClientID%>").style.borderColor = "Red";

                      }
                      if (document.getElementById("<%=ddlFlightTcktType2.ClientID%>").value == "0") {
                          document.getElementById("<%=ddlFlightTcktType2.ClientID%>").style.borderColor = "Red";
                          document.getElementById("<%=ddlFlightTcktType2.ClientID%>").focus();
                      }

                      return false;
                  }
              }
              if (Type == "Room2") {

                  document.getElementById("<%=txtTargetDate7.ClientID%>").style.borderColor = "";
                  document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").style.borderColor = "";

                    Type = Type + "," + "Visa2" + "," + "Flight2";
                    if (document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").value != "0" && document.getElementById("<%=txtTargetDate7.ClientID%>").value != "" && document.getElementById("<%=ddlEmp7.ClientID%>").value != "") {
                        document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmp7.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlRoomAltmntStats2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = true;
                    } else {

                        if (document.getElementById("<%=ddlEmp7.ClientID%>").value == "") {
                            document.getElementById("<%=ddlEmp7.ClientID%>").focus();
                         }

                         if (document.getElementById("<%=txtTargetDate7.ClientID%>").value == "") {
                            document.getElementById("<%=txtTargetDate7.ClientID%>").style.borderColor = "Red";

                        }
                        if (document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").value == "0") {
                            document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").style.borderColor = "Red";
                          document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").focus();
                      }

                        return false;
                    }
                }
              if (Type == "AirPick2") {

                  document.getElementById("<%=txtTargetDate8.ClientID%>").style.borderColor = "";
                  document.getElementById("<%=ddlVehicle2.ClientID%>").style.borderColor = "";

                    Type = Type + "," + "Visa2" + "," + "Flight2" + "," + "Room2";
                    if (document.getElementById("<%=ddlVehicle2.ClientID%>").value != "--VEHICLE--" && document.getElementById("<%=txtTargetDate8.ClientID%>").value != "" && document.getElementById("<%=ddlEmp8.ClientID%>").value != "") {
                        document.getElementById("<%=ddlVehicle2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmp8.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlAirPickStats2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = true;
                    } else {
                        if (document.getElementById("<%=ddlEmp8.ClientID%>").value == "") {
                            document.getElementById("<%=ddlEmp8.ClientID%>").focus();
                         }

                         if (document.getElementById("<%=txtTargetDate8.ClientID%>").value == "") {
                            document.getElementById("<%=txtTargetDate8.ClientID%>").style.borderColor = "Red";

                         }
                        if (document.getElementById("<%=ddlVehicle2.ClientID%>").value == "--VEHICLE--") {
                            document.getElementById("<%=ddlVehicle2.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=ddlVehicle2.ClientID%>").focus();
                        }
                        return false;
                    }
                }



                TypeTotal = TypeTotal + "," + Type;
                document.getElementById("<%=hiddenFinishStatus.ClientID%>").value = TypeTotal;

                DisableButton2(TypePass);
            }
            else {

            }
        }

        function CloseProcess2Old(Type) {
            if (confirm("Are you sure? You want to close this task.")) {
                var TypeTotal = document.getElementById("<%=hiddenCloseStatus.ClientID%>").value;

                if (Type == "Visa2") {
                    if (document.getElementById("<%=ddlVisaBund2.ClientID%>").value != "--VISA QUOTA--" && document.getElementById("<%=ddlVisatype2.ClientID%>").value != "--VISA PROFESSION--" && document.getElementById("<%=txtTargetDate5.ClientID%>").value != "") {
                        document.getElementById("<%=ddlVisaBund2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlVisatype2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmp5.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlVisaStatus2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate5.ClientID%>").disabled = true;




                        document.getElementById('VisaClose2').style.pointerEvents = "none";
                        document.getElementById('VisaClose2').style.opacity = ".5";

                        document.getElementById('VisaFinish2').style.pointerEvents = "none";
                        document.getElementById('VisaFinish2').style.opacity = ".5";
                        document.getElementById('tdFileVisa').style.pointerEvents = "none";
                    }
                    else {
                        return false;
                    }
                }

                if (Type == "Flight2") {
                    if (document.getElementById("<%=ddlFlightTcktType2.ClientID%>").value != "0" && document.getElementById("<%=txtTargetDate6.ClientID%>").value != "") {
                        document.getElementById("<%=ddlFlightTcktType2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmp6.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlFlightStatus2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate6.ClientID%>").disabled = true;


                        document.getElementById('FliClose2').style.pointerEvents = "none";
                        document.getElementById('FliClose2').style.opacity = ".5";

                        document.getElementById('FliFinish2').style.pointerEvents = "none";
                        document.getElementById('FliFinish2').style.opacity = ".5";

                        document.getElementById('tdFileFlight').style.pointerEvents = "none";

                    } else {
                        return false;
                    }
                }
                if (Type == "Room2") {
                    if (document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").value != "0" && document.getElementById("<%=txtTargetDate7.ClientID%>").value != "") {
                          document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").disabled = true;
                          document.getElementById("<%=ddlEmp7.ClientID%>").disabled = true;
                          document.getElementById("<%=ddlRoomAltmntStats2.ClientID%>").disabled = true;
                          document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = true;



                          document.getElementById('RoomClose2').style.pointerEvents = "none";
                          document.getElementById('RoomClose2').style.opacity = ".5";
 
                          document.getElementById('roomFinish2').style.pointerEvents = "none";
                          document.getElementById('roomFinish2').style.opacity = ".5";

                      } else {
                          return false;
                      }
                  }
                  if (Type == "AirPick2") {
                      if (document.getElementById("<%=ddlVehicle2.ClientID%>").value != "--VEHICLE--" && document.getElementById("<%=txtTargetDate8.ClientID%>").value != "") {
                        document.getElementById("<%=ddlVehicle2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmp8.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlAirPickStats2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = true;

                        document.getElementById('AirClose2').style.pointerEvents = "none";
                        document.getElementById('AirClose2').style.opacity = ".5";
                        document.getElementById('AirFinish2').style.pointerEvents = "none";
                        document.getElementById('AirFinish2').style.opacity = ".5";
                    } else {
                        return false;
                    }
                }



                TypeTotal = TypeTotal + "," + Type;
                document.getElementById("<%=hiddenCloseStatus.ClientID%>").value = TypeTotal;

            }
            else {

            }
        }

        function RecallProcess2(Type) {

            if (confirm("Are you sure? You want to recall this task.")) {
                DetailId = "";
                if (Type == "Visa2") {
                    DetailId = document.getElementById("<%=hiddenOnBoardDtlId1.ClientID%>").value;
                }
                else if (Type == "Flight2") {
                    DetailId = document.getElementById("<%=hiddenOnBoardDtlId2.ClientID%>").value;
                }
                else if (Type == "Room2") {
                    DetailId = document.getElementById("<%=hiddenOnBoardDtlId3.ClientID%>").value;
                }
                else if (Type == "AirPick2") {
                    DetailId = document.getElementById("<%=hiddenOnBoardDtlId4.ClientID%>").value;
                }
                CandId = document.getElementById("<%=hiddenCandidateId.ClientID%>").value;

    $.ajax({
        type: "POST",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "hcm_OnBoarding_Process_List.aspx/RecallProcess",
        data: '{ProcessDetailId: "' + DetailId + '"}',
        dataType: "json",
        success: function (data) {

            if (data.d == "true") {
                //window.location.href = "hcm_OnBoarding_Process_List.aspx?InsUpd=Rcl";
                CloseProcessSingle(1);
                SuccessRecall();
               
                ProcessEdit(CandId)
                
            }
        }
    });
}
else {

}

}

        function CloseProcess2(Type) {

            if (confirm("Are you sure? You want to close this task.")) {
                DetailId = "";
                if (Type == "Visa2") {
                    DetailId = document.getElementById("<%=hiddenOnBoardDtlId1.ClientID%>").value;
                }
                else if (Type == "Flight2") {
                    DetailId = document.getElementById("<%=hiddenOnBoardDtlId2.ClientID%>").value;
                }
                else if (Type == "Room2") {
                    DetailId = document.getElementById("<%=hiddenOnBoardDtlId3.ClientID%>").value;
                }
                else if (Type == "AirPick2") {
                    DetailId = document.getElementById("<%=hiddenOnBoardDtlId4.ClientID%>").value;
                }
                CandId = document.getElementById("<%=hiddenCandidateId.ClientID%>").value;

    $.ajax({
        type: "POST",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "hcm_OnBoarding_Process_List.aspx/CloseProcess",
        data: '{ProcessDetailId: "' + DetailId + '"}',
        dataType: "json",
        success: function (data) {

            if (data.d == "true") {
                //window.location.href = "hcm_OnBoarding_Process_List.aspx?InsUpd=Rcl";
                CloseProcessSingle(1);
                SuccessClose();

                
                ProcessEdit(CandId)
               
            }
        }
    });
}
else {

}

}


        var $NonCon = jQuery.noConflict();
        function ProcessEdit(CandId) {
            clearDeleted();
            DisableButton2("Visa2");
            DisableButton2("Flight2");
            DisableButton2("Room2");
            DisableButton2("AirPick2");
            var Countryid = "0";
            document.getElementById('tdFileVisa').style.pointerEvents = "";
            document.getElementById('tdFileFlight').style.pointerEvents = "";
            document.getElementById("<%=hiddenCandidateId.ClientID%>").value = CandId;

            document.getElementById("MymodalProcessSingle").style.display = "block";
            document.getElementById("freezelayer").style.display = "";
            $NonCon.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_OnBoarding_Process_List.aspx/ReadCandidateData",
                data: '{intCandId: "' + CandId + '"}',
                dataType: "json",
                success: function (data) {

                    document.getElementById("<%=lblName.ClientID%>").innerText = data.d[0];
                    document.getElementById("<%=lblLocation.ClientID%>").innerText = data.d[1];
                    document.getElementById("<%=lblReference.ClientID%>").innerText = data.d[2];
                    document.getElementById("<%=lblResume.ClientID%>").innerText = data.d[3];
                    document.getElementById("<%=lblNationality.ClientID%>").innerText = data.d[5];
                    document.getElementById("<%=lblVisa.ClientID%>").innerText = data.d[6];
                    Countryid = data.d[7];
                    
                    document.getElementById("<%=HiddenCountryid.ClientID%>").value = Countryid;
                    document.getElementById('ResumeLink').href = data.d[4];
                }
            });
            var orgid = '<%= Session["ORGID"] %>';
            var corpid = '<%= Session["CORPOFFICEID"] %>';
            $NonCon.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_OnBoarding_Process_List.aspx/ReadVisaData",
                data: '{intCandId: "' + CandId + '",intorgid: "' + orgid + '",intcorpid: "' + corpid + '",intCountryid: "' + Countryid + '"}',
                dataType: "json",
                success: function (data) {
                    document.getElementById("<%=hiddenOnBoardDtlId1.ClientID%>").value = data.d[0];

                    if (data.d[1] != "" && data.d[1] != "null" && data.d[1] != null)
                        document.getElementById("<%=ddlVisaStatus2.ClientID%>").value = data.d[1];
                    document.getElementById("<%=txtTargetDate5.ClientID%>").value = data.d[2];
                    document.getElementById('cphMain_btnProcessSingleSave').style.visibility = "visible";

                    var ddlTestDropDownListXML1 = $NonCon('#<%=ddlVisaBund2.ClientID%>');
                    ddlTestDropDownListXML1.empty();

                    var OptionStart = $noCon("<option>--VISA QUOTA--</option>");
                    OptionStart.attr("value", "--VISA QUOTA--");
                    ddlTestDropDownListXML1.append(OptionStart);
                    var tableName = "dtTableVisaBund";

                    var ddlVisadata1 = data.d[21];

                    $NonCon(ddlVisadata1).find(tableName).each(function () {
                        // Get the OptionValue and OptionText Column values.
                        var OptionValue = $NonCon(this).find('VISQT_ID').text();
                        var OptionText = $NonCon(this).find('VISQT_NUM').text();
                        // Create an Option for DropDownList.


                        var option = $NonCon("<option>" + OptionText + "</option>");

                        option.attr("value", OptionValue);

                        ddlTestDropDownListXML1.append(option);

                    });

                  
                    if (data.d[18] == "1" && data.d[16] != "" && data.d[16] != null) {
                            document.getElementById("<%=ddlVisaBund2.ClientID%>").value = data.d[16];
                            document.getElementById("<%=hiddenBundleId.ClientID%>").value = data.d[16];
                        }
                        else {

                        if (data.d[16] != "" && data.d[16] != null) {
                            var $Mo = jQuery.noConflict();
                            var newOption = "<option value='" + data.d[16] + "'>" + data.d[17] + "</option>";

                            $Mo('#<%=ddlVisaBund2.ClientID%>').append(newOption);
                            //SORTING DDL
                      var options = $Mo("#<%=ddlVisaBund2.ClientID%> option");                    // Collect options         
                            options.detach().sort(function (a, b) {               // Detach from select, then Sort
                                var at = $Mo(a).text();
                                var bt = $Mo(b).text();
                                return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                            });
                            options.appendTo('#<%=ddlVisaBund2.ClientID%>');



                            //var select = document.getElementById("cphMain_ddlVisaBund2");
                            //var option = document.createElement('option');
                            //option.text = data.d[17];
                            //option.value = data.d[16];
                            //select.add(option, 0);
                            document.getElementById("<%=ddlVisaBund2.ClientID%>").value = data.d[16];
                            document.getElementById("<%=hiddenBundleId.ClientID%>").value = data.d[16];
                            document.getElementById("<%=HiddenBundleName.ClientID%>").value = data.d[17];
                            
                        }
                        }

        

                    var ddlTestDropDownListXML = $NonCon('#<%=ddlVisatype2.ClientID%>');
                    ddlTestDropDownListXML.empty();
               
                    var OptionStart = $noCon("<option>--VISA PROFESSION--</option>");
                    OptionStart.attr("value", "--VISA PROFESSION--");
                    ddlTestDropDownListXML.append(OptionStart);
                    var tableName = "dtTableVisaTyp";
                  
                    var ddlVisadata = data.d[20];
                
                    $NonCon(ddlVisadata).find(tableName).each(function () {
                        // Get the OptionValue and OptionText Column values.
                        var OptionValue = $NonCon(this).find('VISATYP_ID').text();
                        var OptionText = $NonCon(this).find('VISA_NAME').text();
                        // Create an Option for DropDownList.
                    
                      
                        var option = $NonCon("<option>" + OptionText + "</option>");
                      
                        option.attr("value", OptionValue);

                        ddlTestDropDownListXML.append(option);
                    
                    });


                    if (data.d[19] == "1" && data.d[5] != "" && data.d[5] != null) {
                        document.getElementById("<%=ddlVisatype2.ClientID%>").value = data.d[5];
                        document.getElementById("<%= hiddenVisaTypeId.ClientID%>").value = data.d[5];
       }
       else {

                        if (data.d[5] != "" && data.d[5] != null) {
                            var $Mo = jQuery.noConflict();
                            var newOption = "<option value='" + data.d[5] + "'>" + data.d[8] + "</option>";

                            $Mo('#<%=ddlVisatype2.ClientID%>').append(newOption);
                            //SORTING DDL
                            var options = $Mo("#<%=ddlVisatype2.ClientID%> option");                    // Collect options         
                            options.detach().sort(function (a, b) {               // Detach from select, then Sort
                                var at = $Mo(a).text();
                                var bt = $Mo(b).text();
                                return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                            });
                            options.appendTo('#<%=ddlVisatype2.ClientID%>');




                            //var select = document.getElementById("cphMain_ddlVisatype2");
                            //var option = document.createElement('option');
                            //option.text = data.d[8];
                            //option.value = data.d[5];
                            //select.add(option, 0);
                            document.getElementById("<%=ddlVisatype2.ClientID%>").value = data.d[5];
                            document.getElementById("<%= hiddenVisaTypeId.ClientID%>").value = data.d[5];
                        }
       }
                  //  if (data.d[5] != "" && data.d[5] != "null" && data.d[5] != null) {
                       // if (data.d[7] == "1") {
                       //     document.getElementById("<%=ddlVisatype2.ClientID%>").value = data.d[5];
                     //   }
                      //  else {


                          //  var select = document.getElementById("cphMain_ddlVisatype2");
                         //   var option = document.createElement('option');
                           // option.text = data.d[8];
                           // option.value = data.d[5];
                          //  select.add(option, 0);
                          //  document.getElementById("<%=ddlVisatype2.ClientID%>").value = data.d[5];
                          //  document.getElementById("<%= hiddenVisaTypeId.ClientID%>").value = data.d[5];
                        //}
                  //  }
                    
                    if (data.d[3] == "1") {
                        document.getElementById("<%=hiddenFinishStatus.ClientID%>").value = "Visa2";
                        document.getElementById("<%=ddlVisatype2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlVisaBund2.ClientID%>").disabled = true;
                        
                        document.getElementById("<%=ddlEmp5.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlVisaStatus2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate5.ClientID%>").disabled = true;
                        document.getElementById("<%=FileUploadVisaSingle.ClientID%>").disabled = true;
                        document.getElementById('imgClearVisaMulti').style.pointerEvents = "none";
                        DisableButton2("Visa2");
                    }
                    else if (data.d[3] == "0") {
                        if (data.d[2] != "") {
                            document.getElementById('VisaFinish2').style.pointerEvents = "";
                            document.getElementById('VisaFinish2').style.opacity = "1";
                        }

                    }

                    if (data.d[4] == "1") {
                        document.getElementById("<%=hiddenCloseStatus.ClientID%>").value = "Visa2";
                        document.getElementById('VisaClose2').style.display = "none";
                        document.getElementById('VisaRecall2').style.display = "";

                        document.getElementById("<%=ddlVisatype2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlVisaBund2.ClientID%>").disabled = true;
                        
                        document.getElementById("<%=ddlEmp5.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlVisaStatus2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate5.ClientID%>").disabled = true;

                        document.getElementById("<%=FileUploadVisaSingle.ClientID%>").disabled = true;
                        document.getElementById('imgClearVisaMulti').style.pointerEvents = "none";
                        document.getElementById('VisaClose2').style.pointerEvents = "none";
                        document.getElementById('VisaClose2').style.opacity = ".5";


                        document.getElementById('VisaFinish2').style.pointerEvents = "none";
                        document.getElementById('VisaFinish2').style.opacity = ".5";



                    }
                    else if (data.d[4] == "0") {
                        if (data.d[2] != "" && data.d[3] == "0") {
                            document.getElementById('VisaClose2').style.pointerEvents = "";
                            document.getElementById('VisaClose2').style.opacity = "1";
                        }
                    }


                    var totalString = data.d[6];
                    var Status = data.d[14];
                    var UserName = data.d[15];
                    varSts = Status.split(',');
                    varUsernm = UserName.split(',');
                    eachString = totalString.split(',');
                    var newVar = new Array();
                    for (count = 0; count < eachString.length; count++) {
                        if (eachString[count] != "") {
                            newVar.push(eachString[count]);

                            if (varSts[count] == "0") {
                                var $Mo = jQuery.noConflict();
                                var newOption = "<option value='" + eachString[count] + "'>" + varUsernm[count] + "</option>";

                                $Mo('#<%=ddlEmp5.ClientID%>').append(newOption);
                                //SORTING DDL
                                var options = $Mo("#<%=ddlEmp5.ClientID%> option");                    // Collect options         
                                options.detach().sort(function (a, b) {               // Detach from select, then Sort
                                    var at = $Mo(a).text();
                                    var bt = $Mo(b).text();
                                    return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                                });
                                options.appendTo('#<%=ddlEmp5.ClientID%>');
                            }

                        }
                    }

                    $noC('#cphMain_ddlEmp5').val(newVar);
                    $noC("#cphMain_ddlEmp5").trigger("change");

                    document.getElementById("<%=hiddenVisaFile.ClientID%>").value = data.d[9];
                    document.getElementById("<%=hiddenVisaFileActual.ClientID%>").value = data.d[10];

                    document.getElementById("<%=divImageDisplayVisaMulti.ClientID%>").innerHTML = data.d[11];

                }
            });
            $NonCon.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_OnBoarding_Process_List.aspx/ReadFlightData",
                data: '{intCandId: "' + CandId + '"}',
                dataType: "json",
                success: function (data) {
                    document.getElementById("<%=hiddenOnBoardDtlId2.ClientID%>").value = data.d[0];
                    if (data.d[1] != "" && data.d[1] != "null" && data.d[1] != null)
                        document.getElementById("<%=ddlFlightStatus2.ClientID%>").value = data.d[1];
                    document.getElementById("<%=txtTargetDate6.ClientID%>").value = data.d[2];
                    if (data.d[5] != "" && data.d[5] != "null" && data.d[5] != null)
                        document.getElementById("<%=ddlFlightTcktType2.ClientID%>").value = data.d[5];
                    document.getElementById('cphMain_btnProcessSingleSave').style.visibility = "visible";
                    if (data.d[3] == "1") {
                        document.getElementById("<%=hiddenFinishStatus.ClientID%>").value = document.getElementById("<%=hiddenFinishStatus.ClientID%>").value + "," + "Flight2";
                        document.getElementById("<%=ddlFlightTcktType2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmp6.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlFlightStatus2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate6.ClientID%>").disabled = true;
                        document.getElementById("<%=FileUploadFlightTicketSingle.ClientID%>").disabled = true;
                        document.getElementById('imgClearFlightTicketMulti').style.pointerEvents = "none";

                        DisableButton2("Flight2");
                    }
                    else if (data.d[3] == "0") {
                        if (data.d[2] != "") {
                            document.getElementById('FliFinish2').style.pointerEvents = "";
                            document.getElementById('FliFinish2').style.opacity = "1";
                        }
                    }
                    if (data.d[4] == "1") {
                        document.getElementById("<%=hiddenCloseStatus.ClientID%>").value = document.getElementById("<%=hiddenCloseStatus.ClientID%>").value + "," + "Flight2";
                        document.getElementById('FliClose2').style.display = "none";
                        document.getElementById('FliRecall2').style.display = "";

                        document.getElementById("<%=ddlFlightTcktType2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmp6.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlFlightStatus2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate6.ClientID%>").disabled = true;
                        document.getElementById("<%=FileUploadFlightTicketSingle.ClientID%>").disabled = true;
                        document.getElementById('imgClearFlightTicketMulti').style.pointerEvents = "none";

                        document.getElementById('FliClose2').style.pointerEvents = "none";
                        document.getElementById('FliClose2').style.opacity = ".5";

                        document.getElementById('FliFinish2').style.pointerEvents = "none";
                        document.getElementById('FliFinish2').style.opacity = ".5";


                    }
                    else if (data.d[4] == "0") {
                        if (data.d[2] != "" && data.d[3] == "0") {
                            document.getElementById('FliClose2').style.pointerEvents = "";
                            document.getElementById('FliClose2').style.opacity = "1";
                        }
                    }
                    var totalString = data.d[6];
                    var Status = data.d[14];
                    var UserName = data.d[15];
                    varSts = Status.split(',');
                    varUsernm = UserName.split(',');
                    eachString = totalString.split(',');
                    var newVar = new Array();
                    for (count = 0; count < eachString.length; count++) {
                        if (eachString[count] != "") {
                            newVar.push(eachString[count]);

                            if (varSts[count] == "0") {
                                var $Mo = jQuery.noConflict();
                                var newOption = "<option value='" + eachString[count] + "'>" + varUsernm[count] + "</option>";

                                $Mo('#<%=ddlEmp6.ClientID%>').append(newOption);
                                //SORTING DDL
                                var options = $Mo("#<%=ddlEmp6.ClientID%> option");                    // Collect options         
                                options.detach().sort(function (a, b) {               // Detach from select, then Sort
                                    var at = $Mo(a).text();
                                    var bt = $Mo(b).text();
                                    return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                                });
                                options.appendTo('#<%=ddlEmp6.ClientID%>');
                            }

                        }
                    }

                    $noC('#cphMain_ddlEmp6').val(newVar);
                    $noC("#cphMain_ddlEmp6").trigger("change");

                    document.getElementById("<%=hiddenFlightTicketFile.ClientID%>").value = data.d[7];
                    document.getElementById("<%=divImageDisplayFlightTicketMulti.ClientID%>").innerHTML = data.d[9];
                    document.getElementById("<%=hiddenFlightTicketFileActual.ClientID%>").value = data.d[8];
                }
            });
            $NonCon.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_OnBoarding_Process_List.aspx/ReadRoomData",
                data: '{intCandId: "' + CandId + '"}',
                dataType: "json",
                success: function (data) {
                    document.getElementById("<%=hiddenOnBoardDtlId3.ClientID%>").value = data.d[0];
                    if (data.d[1] != "" && data.d[1] != "null" && data.d[1] != null)
                        document.getElementById("<%=ddlRoomAltmntStats2.ClientID%>").value = data.d[1];
                    document.getElementById("<%=txtTargetDate7.ClientID%>").value = data.d[2];

                    if (data.d[5] != "")
                        document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").value = data.d[5];
                    document.getElementById('cphMain_btnProcessSingleSave').style.visibility = "visible";

                    if (data.d[3] == "1") {
                        document.getElementById("<%=hiddenFinishStatus.ClientID%>").value = document.getElementById("<%=hiddenFinishStatus.ClientID%>").value + "," + "Room2";
                        document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmp7.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlRoomAltmntStats2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = true;

                        DisableButton2("Room2");
                    }
                    else if (data.d[3] == "0") {
                        if (data.d[2] != "") {
                            document.getElementById('roomFinish2').style.pointerEvents = "";
                            document.getElementById('roomFinish2').style.opacity = "1";
                        }
                    }
                    if (data.d[4] == "1") {
                        document.getElementById("<%=hiddenCloseStatus.ClientID%>").value = document.getElementById("<%=hiddenCloseStatus.ClientID%>").value + "," + "Room2";
                        document.getElementById('RoomClose2').style.display = "none";
                        document.getElementById('RoomRecall2').style.display = "";

                        document.getElementById("<%=ddlRoomAltmntType2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmp7.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlRoomAltmntStats2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = true;


                        document.getElementById('RoomClose2').style.pointerEvents = "none";
                        document.getElementById('RoomClose2').style.opacity = ".5";


                        document.getElementById('roomFinish2').style.pointerEvents = "none";
                        document.getElementById('roomFinish2').style.opacity = ".5";



                    }
                    else if (data.d[4] == "0") {
                        if (data.d[2] != "" && data.d[3] == "0") {
                            document.getElementById('RoomClose2').style.pointerEvents = "";
                            document.getElementById('RoomClose2').style.opacity = "1";
                        }
                    }
                    var totalString = data.d[6];
                    var Status = data.d[14];
                    var UserName = data.d[15];
                    varSts = Status.split(',');
                    varUsernm = UserName.split(',');
                    eachString = totalString.split(',');
                    var newVar = new Array();
                    for (count = 0; count < eachString.length; count++) {
                        if (eachString[count] != "") {
                            newVar.push(eachString[count]);

                            if (varSts[count] == "0") {
                                var $Mo = jQuery.noConflict();
                                var newOption = "<option value='" + eachString[count] + "'>" + varUsernm[count] + "</option>";

                                $Mo('#<%=ddlEmp7.ClientID%>').append(newOption);
                                //SORTING DDL
                                var options = $Mo("#<%=ddlEmp7.ClientID%> option");                    // Collect options         
                                options.detach().sort(function (a, b) {               // Detach from select, then Sort
                                    var at = $Mo(a).text();
                                    var bt = $Mo(b).text();
                                    return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                                });
                                options.appendTo('#<%=ddlEmp7.ClientID%>');
                            }

                        }
                    }

                    $noC('#cphMain_ddlEmp7').val(newVar);
                    $noC("#cphMain_ddlEmp7").trigger("change");

                }
            });
            $NonCon.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_OnBoarding_Process_List.aspx/ReadAirData",
                data: '{intCandId: "' + CandId + '"}',
                dataType: "json",
                success: function (data) {
                    document.getElementById("<%=hiddenOnBoardDtlId4.ClientID%>").value = data.d[0];
                    if (data.d[1] != "" && data.d[1] != "null" && data.d[1] != null)
                        document.getElementById("<%=ddlAirPickStats2.ClientID%>").value = data.d[1];
                    document.getElementById("<%=txtTargetDate8.ClientID%>").value = data.d[2];
                    document.getElementById('cphMain_btnProcessSingleSave').style.visibility = "visible";
                    if (data.d[3] == "1") {
                        document.getElementById("<%=hiddenFinishStatus.ClientID%>").value = document.getElementById("<%=hiddenFinishStatus.ClientID%>").value + "," + "AirPick2";
                        document.getElementById("<%=ddlVehicle2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmp8.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlAirPickStats2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = true;
                        document.getElementById('cphMain_btnProcessSingleSave').style.visibility = "hidden";
                        DisableButton2("AirPick2");
                    }
                    else if (data.d[3] == "0") {
                        if (data.d[2] != "") {
                            document.getElementById('AirFinish2').style.pointerEvents = "";
                            document.getElementById('AirFinish2').style.opacity = "1";
                        }
                    }
                    if (data.d[4] == "1") {
                        document.getElementById("<%=hiddenCloseStatus.ClientID%>").value = document.getElementById("<%=hiddenCloseStatus.ClientID%>").value + "," + "AirPick2";
                        document.getElementById('AirClose2').style.display = "none";
                        document.getElementById('AirRecall2').style.display = "";

                        document.getElementById("<%=ddlVehicle2.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlEmp8.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlAirPickStats2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = true;

                        document.getElementById('AirClose2').style.pointerEvents = "none";
                        document.getElementById('AirClose2').style.opacity = ".5";

                        document.getElementById('AirFinish2').style.pointerEvents = "none";
                        document.getElementById('AirFinish2').style.opacity = ".5";


                    }
                    else if (data.d[4] == "0") {
                        if (data.d[2] != "" && data.d[3] == "0") {
                            document.getElementById('AirClose2').style.pointerEvents = "";
                            document.getElementById('AirClose2').style.opacity = "1";
                        }
                    }
                    if (data.d[5] != "")
                        document.getElementById("<%=ddlVehicle2.ClientID%>").value = data.d[5];

                    var totalString = data.d[6];
                    var Status = data.d[14];
                    var UserName = data.d[15];
                    varSts = Status.split(',');
                    varUsernm = UserName.split(',');
                    eachString = totalString.split(',');
                    var newVar = new Array();
                    for (count = 0; count < eachString.length; count++) {
                        if (eachString[count] != "") {
                            newVar.push(eachString[count]);

                            if (varSts[count] == "0") {
                                var $Mo = jQuery.noConflict();
                                var newOption = "<option value='" + eachString[count] + "'>" + varUsernm[count] + "</option>";

                                $Mo('#<%=ddlEmp8.ClientID%>').append(newOption);
                                //SORTING DDL
                                var options = $Mo("#<%=ddlEmp8.ClientID%> option");                    // Collect options         
                                options.detach().sort(function (a, b) {               // Detach from select, then Sort
                                    var at = $Mo(a).text();
                                    var bt = $Mo(b).text();
                                    return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                                });
                                options.appendTo('#<%=ddlEmp8.ClientID%>');
                            }

                        }
                    }

                    $noC('#cphMain_ddlEmp8').val(newVar);
                    $noC("#cphMain_ddlEmp8").trigger("change");

                }
            });

        }

        function ConfirmCancel() {
            if (confirm("Are you sure? Do you want to cancel")) {

                window.location.href = "hcm_OnBoarding_Process_List.aspx";
            }
        }


        //FlightTicket
        function ClearDivDisplayImageFlightTicket() {

            var hidnImageSize = document.getElementById("<%=hiddenFlightTicketFileSize.ClientID%>").value;
            var fuData = document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>");
            var size = fuData.size;

            var convertToKb = hidnImageSize / 1000;
            if (size > hidnImageSize) {
                document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>").value = "";
                document.getElementById("<%=Label3FlightTicket.ClientID%>").textContent = "No File Selected";
                alert(" Sorry Maximum file size exceeds. Please Upload Image of size less than " + convertToKb + "KB !.");
                //return false;
            }
            else {

                if (document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>").value != "") {
                    document.getElementById("<%=Label3FlightTicket.ClientID%>").textContent = document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>").value;

                 }

                //    return true;

             }
         }

         function ClearImageFlightTicket() {
             if (document.getElementById("<%=hiddenFlightTicketFile.ClientID%>").value != "" || document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>").value != "") {
                if (confirm("Do You Want To Remove Selected File?")) {

                    document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>").value = "";

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
            var fuData = document.getElementById("<%=FileUploadVisaMulty.ClientID%>");
            var size = fuData.size;

            var convertToKb = hidnImageSize / 1000;
            if (size > hidnImageSize) {
                document.getElementById("<%=FileUploadVisaMulty.ClientID%>").value = "";
                document.getElementById("<%=Label3Visa.ClientID%>").textContent = "No File Selected";
                alert(" Sorry Maximum file size exceeds. Please Upload Image of size less than " + convertToKb + "KB !.");
                //return false;
            }
            else {

                if (document.getElementById("<%=FileUploadVisaMulty.ClientID%>").value != "") {
                    document.getElementById("<%=Label3Visa.ClientID%>").textContent = document.getElementById("<%=FileUploadVisaMulty.ClientID%>").value;
                }

                //    return true;

            }
        }

        function ClearImageVisa() {

            if (document.getElementById("<%=hiddenVisaFile.ClientID%>").value != "" || document.getElementById("<%=FileUploadVisaMulty.ClientID%>").value != "") {
                if (confirm("Do You Want To Remove Selected File?")) {

                    document.getElementById("<%=FileUploadVisaMulty.ClientID%>").value = "";
                    document.getElementById("<%=Label3Visa.ClientID%>").textContent = "No File Selected";
                    //  alert("Image has been Removed Sucessfully. ");
                }
                else {

                }

            }
        }

        //VisaMulti
        function ClearDivDisplayImageVisaMulti() {

            var hidnImageSize = document.getElementById("<%=hiddenVisaFileSize.ClientID%>").value;
            var fuData = document.getElementById("<%=FileUploadVisaMulty.ClientID%>");
            var size = fuData.size;

            var convertToKb = hidnImageSize / 1000;
            if (size > hidnImageSize) {
                document.getElementById("<%=FileUploadVisaMulty.ClientID%>").value = "";
                document.getElementById("<%=Label3VisaMulti.ClientID%>").textContent = "No File Selected";
                alert(" Sorry Maximum file size exceeds. Please Upload Image of size less than " + convertToKb + "KB !.");
                //return false;
            }
            else {

                if (document.getElementById("<%=FileUploadVisaMulty.ClientID%>").value != "") {
                    document.getElementById("<%=Label3Visa.ClientID%>").textContent = document.getElementById("<%=FileUploadVisaMulty.ClientID%>").value;
                    document.getElementById("<%=divImageDisplayVisaMulti.ClientID%>").innerHTML = "";
                    document.getElementById("<%=hiddenVisaFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenVisaFile.ClientID%>").value;
                    document.getElementById("<%=hiddenVisaFile.ClientID%>").value = "";
                }

                //    return true;

            }
        }

        function ClearImageVisaMulti() {


            // alert(document.getElementById("<%=hiddenVisaFile.ClientID%>").value);
            if (document.getElementById("<%=hiddenVisaFile.ClientID%>").value != "" || document.getElementById("<%=FileUploadVisaSingle.ClientID%>").value != "") {
                if (confirm("Do You Want To Remove Selected File?")) {

                    document.getElementById("<%=FileUploadVisaSingle.ClientID%>").value = "";
                     document.getElementById("<%=hiddenVisaFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenVisaFile.ClientID%>").value;
                     document.getElementById("<%=hiddenVisaFile.ClientID%>").value = "";
                     document.getElementById("<%=divImageDisplayVisaMulti.ClientID%>").innerHTML = "";
                     document.getElementById("<%=Label3VisaMulti.ClientID%>").textContent = "No File Selected";
                     //  alert("Image has been Removed Sucessfully. ");
                 }
                 else {

                 }

             }
         }

         //FlightTicketMulti
         function ClearDivDisplayImageFlightTicketMulti() {

             var hidnImageSize = document.getElementById("<%=hiddenFlightTicketFileSize.ClientID%>").value;
            var fuData = document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>");
            var size = fuData.size;

            var convertToKb = hidnImageSize / 1000;
            if (size > hidnImageSize) {
                document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>").value = "";
                document.getElementById("<%=Label3FlightTicketMulti.ClientID%>").textContent = "No File Selected";
                alert(" Sorry Maximum file size exceeds. Please Upload Image of size less than " + convertToKb + "KB !.");
                //return false;
            }
            else {

                if (document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>").value != "") {
                    document.getElementById("<%=Label3FlightTicket.ClientID%>").textContent = document.getElementById("<%=FileUploadFlightTicketMulty.ClientID%>").value;
                    document.getElementById("<%=divImageDisplayFlightTicketMulti.ClientID%>").innerHTML = "";
                    document.getElementById("<%=hiddenFlightTicketFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenFlightTicketFile.ClientID%>").value;
                    document.getElementById("<%=hiddenFlightTicketFile.ClientID%>").value = "";
                }

                //    return true;

            }
        }

        function ClearImageFlightTicketMulti() {
            if (document.getElementById("<%=hiddenFlightTicketFile.ClientID%>").value != "" || document.getElementById("<%=FileUploadFlightTicketSingle.ClientID%>").value != "") {
                if (confirm("Do You Want To Remove Selected File?")) {

                    document.getElementById("<%=FileUploadFlightTicketSingle.ClientID%>").value = "";
                    document.getElementById("<%=hiddenFlightTicketFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenFlightTicketFile.ClientID%>").value;
                    document.getElementById("<%=hiddenFlightTicketFile.ClientID%>").value = "";
                    document.getElementById("<%=divImageDisplayFlightTicketMulti.ClientID%>").innerHTML = "";
                    document.getElementById("<%=Label3FlightTicketMulti.ClientID%>").textContent = "No File Selected";
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
        function ddlVisatype2Change()
        {

            var VisaType = document.getElementById("<%=ddlVisatype2.ClientID%>");
            var VisaTypeText = VisaType.options[VisaType.selectedIndex].text;
            if (VisaTypeText != "--VISA PROFESSION--")
            {
                document.getElementById("<%=hiddenVisaTypeId.ClientID%>").value = document.getElementById("<%=ddlVisatype2.ClientID%>").value;
            }
        }

        function ddlVisaBund2Change() {

            var VisaType1 = document.getElementById("<%=ddlVisaBund2.ClientID%>");
            var VisaTypeText1 = VisaType1.options[VisaType1.selectedIndex].text;
            if (VisaTypeText1 != "--VISA QUOTA--") {
                  document.getElementById("<%=hiddenBundleId.ClientID%>").value = document.getElementById("<%=ddlVisaBund2.ClientID%>").value;
            }
        }

        function ddlVisaTypeChange() {
            document.getElementById("divErrorNotificationPrcsMlty").style.visibility = "hidden";
            var VisaType2 = document.getElementById("<%=ddlVisaType.ClientID%>");
            var VisaTypeText2 = VisaType2.options[VisaType2.selectedIndex].text;
            if (VisaTypeText2 != "--VISA PROFESSION--") {
                var visbundleid = document.getElementById("<%=ddlVisaBund.ClientID%>").value;
                var Typeid = document.getElementById("<%=ddlVisaType.ClientID%>").value;

                $noCon.ajax({
                    type: "POST",
                    url: "hcm_OnBoarding_Process_List.aspx/CheckVisanumber",
                    data: '{intvisbundleid:"' + visbundleid + '",intTypeid:"' + Typeid + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (count > response.d)
                        {
                            document.getElementById("divErrorNotificationPrcsMlty").style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotificationPrcsMlty.ClientID%>").innerText = "Number of selected persons should be less than or equal to visa count";
                            document.getElementById("<%=ddlVisaType.ClientID%>").value = "--VISA PROFESSION--";
                        }
                      
                    },
                    failure: function (response) {

                    }
                });
            }
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <%--hiddenfields for file upload--%>
      <asp:HiddenField ID="HiddenManPwrId" runat="server" />
    <asp:HiddenField ID="hiddenFlightTicketFile" runat="server" />
    <asp:HiddenField ID="hiddenFlightTicketFileSize" runat="server" />
    <asp:HiddenField ID="hiddenFlightTicketFileDeleted" runat="server" />
    <asp:HiddenField ID="hiddenFlightTicketFileActual" runat="server" />

    <asp:HiddenField ID="hiddenVisaFile" runat="server" />
    <asp:HiddenField ID="hiddenVisaFileSize" runat="server" />
    <asp:HiddenField ID="hiddenVisaFileDeleted" runat="server" />

    <asp:HiddenField ID="hiddenVisaFileActual" runat="server" />

    <asp:HiddenField ID="hiddenOnBoardDtlId1" runat="server" />
    <asp:HiddenField ID="hiddenOnBoardDtlId2" runat="server" />
    <asp:HiddenField ID="hiddenOnBoardDtlId3" runat="server" />
    <asp:HiddenField ID="hiddenOnBoardDtlId4" runat="server" />
    <asp:HiddenField ID="hiddenCandidateId" runat="server" />
    <asp:HiddenField ID="hiddenEmp4" runat="server" />
    <asp:HiddenField ID="hiddenEmp3" runat="server" />
    <asp:HiddenField ID="hiddenEmp2" runat="server" />
    <asp:HiddenField ID="hiddenEmp1" runat="server" />
    <asp:HiddenField ID="HiddenConsultancyId" runat="server" />
    <asp:HiddenField ID="HiddenreqstId" runat="server" />
    <asp:HiddenField ID="HiddenShortlistMasterid" runat="server" />
    <asp:HiddenField ID="hiddenRowCount" runat="server" />
    <asp:HiddenField ID="Hiddenchecklist" runat="server" />
    <asp:HiddenField ID="hiddenFinishStatus" runat="server" />
    <asp:HiddenField ID="hiddenCloseStatus" runat="server" />
    <asp:HiddenField ID="hiddenRecallStatus" runat="server" />
    <asp:HiddenField ID="hiddenAlreadyClosed" runat="server" />
    <asp:HiddenField ID="hiddenVisaTypeId" runat="server" />
      <asp:HiddenField ID="hiddenBundleId" runat="server" />
        <asp:HiddenField ID="HiddenCountryid" runat="server" />
       <asp:HiddenField ID="HiddenBundleName" runat="server" />
     
    
    
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">






        <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
            <asp:Label ID="lblEntry" runat="server">On Boarding Process</asp:Label>
        </div>
        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left">


            <div style="float: left; width: 100%; margin-top: 1%">
                <div style="width: 30%; float: left; padding: 5px; border: 1px solid #c3c3c3;">
                    <h2>On Boarding* :</h2>
                    <div style="float: right; margin-right: 0%; width: 61%;">
                        <asp:RadioButton ID="radioAssigned" Text="Assigned" runat="server" Checked="true" OnkeyPress="return DisableEnter(event)" GroupName="RadioSkCer" Style="float: left; font-family: calibri" />
                        <asp:RadioButton ID="radioNotAssigned" Text="Not Assigned" runat="server" GroupName="RadioSkCer" OnkeyPress="return DisableEnter(event)" Style="float: left; font-family: calibri; margin-left: 6%;" />
                    </div>
                </div>

                <div style="width: 63%; float: left; padding: 5px; margin-left: 4%;">
                    <h2>Man Power Request : </h2>

                    <asp:DropDownList ID="ddlManPower" class="form1" runat="server" Style="height: 30px; width: 35%; float: left; margin-left: 2%;">
                    </asp:DropDownList>

                    <asp:Button ID="btnSearch" Style="cursor: pointer; margin-left: 10%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click" />

                </div>

            </div>

            <div id="divReport" class="table-responsive" runat="server" style="float: left; width: 100%; margin-top: 1%">
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

            <div id="divErrorlabel" style="float: left; margin-left: 70%; visibility: hidden;">
                <label style="color: red; font-family: calibri;">Please select atleast one candidate</label>
            </div>
            <input type="button" id="btnOnBoard" runat="server" style="width: 114px; float: left; margin-left: 0.5%; margin-top: 0%; background: #127c8f; border: 2px solid #b12709;" class="save" value="OnBoard" onclick="ShowProcess_Multy()" />

        </div>

    </div>

    <%-- ----------------for On boarding process multiple//-----%>

    <div>
        <div id="MyModalProcessMultiple" class="MyModalProcessMultiple">
            <div id="divJbFull">
                <div id="DivEmpHeader" style="height: 30px; background-color: #6f7b5a;">

                    <label id="lblProcess" style="margin-left: 38%; font-size: 18px; color: #fff; font-family: calibri;">ON BOARDING PROCESS-MULTIPLE</label>

                    <img class="closeCancelView" style="margin-top: .5%; margin-right: 1%; float: right; cursor: pointer;" onclick="CloseProcessMulty(0);" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                </div>
                <div style="float: left; margin: 13px; border: 1px solid; border-color: #d7c9c9; background-color: #fff; margin-bottom: 6px; width: 97%;">
                    <div id="JbShdlTop" style="width: 100%; float: left; margin-top: 1%;">
                        <h2 style="margin-left: 2%; width: 23%; float: left;">No.of selected persons : 
                        </h2>
                        <label id="lblNoOfselectedEmp" style="float: left; color: #042f95; font-family: calibri; width: 10%; cursor: inherit"></label>
                    </div>



                    <div id="divSheduleContainer" style="float: left; width: 100%;">
                        <div id="divErrorNotificationPrcsMlty" style="visibility: hidden; width: 70%; margin-left: 15%; border: 1px solid green;float: left;">
                            <asp:Label ID="lblErrorNotificationPrcsMlty" style="margin-left: 12%; float: left; color: #29451b; font-family: calibri; width: 100%; cursor: inherit" runat="server"></asp:Label>
                        </div>
                        <div id="divTableProcessMlty" style="width: 98%; margin: 1%; padding-top: 0.6%;">

                            <%-- <table class="TableHeaderProcess" rules="all" style="width: 96%; margin-left: 2%; font-family: calibri;">
                               
                            </table>--%>
                            <table id="tblOnBoardMult" style="width: 96%; margin-left: 2%; font-family: calibri; background-color: #f6f6f6;">
                                <thead>
                                    <tr class="main_table_head">
                                        <th class="thT" style="font-size: 14px; width: 4.2%; padding-left: 0.5%; text-align: center;">Sl#</th>
                                        <th class="thT" style="font-size: 14px; width: 10%; padding-left: 0.5%; text-align: left;">Particulars</th>
                                        <th class="thT" style="font-size: 14px; width: 10.2%; padding-left: 0.5%; text-align: left;">Category</th>
                                        <th class="thT" style="font-size: 14px; width: 20.7%; padding-left: 0.5%; text-align: left;">Employee</th>
                                        <th class="thT" style="font-size: 14px; width: 11.1%; padding-left: 0.5%; text-align: center;">Status</th>
                                        <th class="thT" style="font-size: 14px; width: 10.1%; padding-left: 0.5%; text-align: center;">Target</th>
                                        <th class="thT" style="font-size: 14px; width: 35.5%; padding-left: 0.5%; text-align: center;">Attachments</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">1</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Visa</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                  <asp:UpdatePanel ID="UpdatePanel1"  EnableViewState="true" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnVisaBundle" runat="server" Text="Button" style="display:none;" OnClick="btnVisaBundle_Click"/>
                                                  <asp:DropDownList ID="ddlVisaBund" class="form1" OnSelectedIndexChanged="ddlVisaBund_SelectedIndexChanged" AutoPostBack="true" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlVisaType" onchange="ddlVisaTypeChange();" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                      </ContentTemplate>
                     
                     </asp:UpdatePanel>

                                        </td>
                                        <td style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp1" data-placeholder="select employee" multiple="mutiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">

                                            <asp:DropDownList ID="ddlVisaStatus" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">


                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                                <asp:ListItem Value="1">Document Preparation</asp:ListItem>
                                                <asp:ListItem Value="2">Applied, Awaiting MOI Approval</asp:ListItem>
                                                <asp:ListItem Value="3">MOI Approved, ready to print</asp:ListItem>
                                                <asp:ListItem Value="4">MOI rejected – Close</asp:ListItem>
                                                <asp:ListItem Value="5">MOI Rejected – Reapply</asp:ListItem>
                                                <asp:ListItem Value="6">Visa print complete</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate1" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;" onkeypress="DisableEnter(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 35%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <label for="cphMain_FileUploadVisaMulty" id="lblVisa" class="custom-file-upload" tabindex="0" style="display: none; margin-left: 9.5%; font-family: Calibri;">
                                                <img src="../../../../Images/Icons/cloud_upload.jpg" />Upload File</label>


                                            <asp:FileUpload ID="FileUploadVisaMulty" class="fileUpload" runat="server" Style="width: 90%; height: 30px; display: block;float: left;" onchange="ClearDivDisplayImageVisa()" Accept="All" />


                                            <div id="divVisa" runat="server" style="float: left; width: 7%; height: 20px;  margin-top: 2%;">
                                                <div id="imgWrapVisa" class="imgWrap">
                                                    <img id="imgClearVisa" src="/Images/Icons/clear-image-blue.png" alt="Clear" title="Remove File" onclick="ClearImageVisa()" style="cursor: pointer; float: right;" />
                                                </div>
                                            </div>
                                            <asp:Label ID="Label3Visa" runat="server" Text="No File selected" Style="display: none; font-family: Calibri; font-size: medium;"></asp:Label>

                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">2</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Flight Ticket</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlFlightTcktType" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">

                                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="1">ECONOMY CLASS</asp:ListItem>
                                                <asp:ListItem Value="2">BUSSINESS CLASS</asp:ListItem>
                                                <asp:ListItem Value="3">FIRST CLASS</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp2" data-placeholder="select employee" multiple="multiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlFlightStatus" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">

                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                                <asp:ListItem Value="1">Availability Check</asp:ListItem>
                                                <asp:ListItem Value="2">Awaiting, Approval from candidate</asp:ListItem>
                                                <asp:ListItem Value="3">Booking Confirm, ticket copy attach</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate2" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;" onkeypress="DisableEnter(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 25%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">

                                            <label for="cphMain_FileUploadFlightTicketMulty" id="lblFlightTicket" class="custom-file-upload" tabindex="0" style="display: none; margin-left: 9.5%; font-family: Calibri;">
                                                <img src="../../../../Images/Icons/cloud_upload.jpg" />Upload File</label>


                                            <asp:FileUpload ID="FileUploadFlightTicketMulty" class="fileUpload" runat="server" Style="width: 90%; height: 30px; display: block;float: left;" onchange="ClearDivDisplayImageFlightTicket()" Accept="All" />


                                            <div id="divFlightTicket" runat="server" style="float: left; width: 7%; height: 20px;  margin-top: 2%;">
                                                <div id="imgWrapFlightTicket" class="imgWrap">
                                                    <img id="imgClearFlightTicket" src="/Images/Icons/clear-image-blue.png" alt="Clear" title="Remove File" onclick="ClearImageFlightTicket()" style="cursor: pointer; float: right;" />
                                                </div>
                                            </div>
                                            <asp:Label ID="Label3FlightTicket" runat="server" Text="No File selected" Style="display: none; font-family: Calibri; font-size: medium;"></asp:Label>
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">3</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Room Allotment</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlRoomAltmntType" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">
                                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="1">BED SPACE</asp:ListItem>
                                                <asp:ListItem Value="2">1BHK</asp:ListItem>
                                                <asp:ListItem Value="3">2BHK</asp:ListItem>
                                                <asp:ListItem Value="4">3BHK</asp:ListItem>
                                                <asp:ListItem Value="5">VILLA</asp:ListItem>
                                                <asp:ListItem Value="6">FLAT</asp:ListItem>
                                            </asp:DropDownList>

                                        </td>
                                        <td style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp3" data-placeholder="select employee" multiple="multiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlRoomAltmntStats" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">

                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                                <asp:ListItem Value="1">Availability Check</asp:ListItem>
                                                <asp:ListItem Value="2">Facility Procurement</asp:ListItem>
                                                <asp:ListItem Value="3">Complete</asp:ListItem>
                                                <asp:ListItem Value="4">Closed Without Allotment</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate3" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;" onkeypress="DisableEnter(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 25%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd"></td>
                                        
                                    </tr>
                                    <tr>
                                        <td style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">4</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Air Port Pickup</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlVehicle" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp4" data-placeholder="select employee" multiple="multiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlAirPickStats" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">


                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate4" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;" onkeypress="DisableEnter(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 25%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd"></td>
                                       
                                    </tr>
                                </tbody>

                            </table>



                        </div>

                    </div>
                </div>


                <asp:Button ID="btnProcessMultySave" class="save" runat="server" Text="Save" Style="width: 105px; float: left; margin-left: 40%;" OnClientClick="return ValidateProcessMulty()" OnClick="btnProcessMultySave_Click" />
                <%--<input type="button" id="btnProcessMultyClr" class="save" style="width: 90px; float: left;" value="Clear" />--%>
                <input type="button" id="btnProcessMultyCncl" onclick="ConfirmCancel();" class="save" style="width: 90px; float: left;" value="Cancel" />

            </div>

        </div>
    </div>

    <%-- ----------------for On boarding process multiple//-----%>

    <div>
        <div id="MymodalProcessSingle" class="MyModalProcessMultiple">
            <div id="div2">
                <div id="Div3" style="height: 30px; background-color: #6f7b5a;">

                    <label style="margin-left: 38%; font-size: 18px; color: #fff; font-family: calibri;">ON BOARDING PROCESS</label>

                    <img class="closeCancelView" style="margin-top: .5%; margin-right: 1%; float: right; cursor: pointer;" onclick="CloseProcessSingle(0);" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                </div>
                <div style="float: left; margin: 13px; border: 1px solid; border-color: #d7c9c9; background-color: #fff; margin-bottom: 6px; width: 97%;">
                    <div id="Div4" style="width: 91%; float: left; margin-top: 1%; padding: 16px; margin-left: 3%; background-color: #ded2d2;">

                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">Name</h2>
                            <asp:Label ID="lblName" class="lblTop" runat="server"></asp:Label>
                            <asp:Label ID="lblCandId" class="lblTop" Style="display: none" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: right;">
                            <h2 style="color: #603504;">Location</h2>
                            <asp:Label ID="lblLocation" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">Reference</h2>
                            <asp:Label ID="lblReference" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: right;">
                            <h2 style="color: #603504;">Resume</h2>
                            <a id="ResumeLink" onclick="return getdetails(this.href);" href="">
                                <asp:Label ID="lblResume" class="lblTop" runat="server"></asp:Label></a>
                        </div>
                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">Nationality</h2>
                            <asp:Label ID="lblNationality" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: right;">
                            <h2 style="color: #603504;">Visa</h2>
                            <asp:Label ID="lblVisa" class="lblTop" runat="server"></asp:Label>
                        </div>

                    </div>



                    <div id="div5" style="float: left; width: 100%;">
                        <div id="divpopError" style="visibility: hidden;width: 70%;margin-left: 15%;border: 1px solid green;float:left">
                            <asp:Label ID="lblPopError" runat="server" style="margin-left: 38%; float: left; color: #29451b; font-family: calibri; width: 100%; cursor: inherit" ></asp:Label>
                        </div>
                        <div id="div7" style="width: 98%; margin: 1%; padding-top: 0.6%;">

                            <%-- <table class="TableHeaderProcess" rules="all" style="width: 96%; margin-left: 2%; font-family: calibri;">
                              
                            </table>--%>
                            <table id="tblOnBoardSingle" style="width: 96%; margin-left: 2%; font-family: calibri; background-color: #f6f6f6;">
                                <thead class="main_table_head">
                                    <tr>
                                        <td style="font-size: 14px; width: 4.2%; padding-left: 0.5%; text-align: center;">Sl#</td>
                                        <td style="font-size: 14px; width: 10%; padding-left: 0.5%; text-align: left;">Particulars</td>
                                        <td style="font-size: 14px; width: 10.2%; padding-left: 0.5%; text-align: left;">Category</td>
                                        <td style="font-size: 14px; width: 20.7%; padding-left: 0.5%; text-align: left;">Employee</td>
                                        <td style="font-size: 14px; width: 11.1%; padding-left: 0.5%; text-align: center;">Status</td>
                                        <td style="font-size: 14px; width: 10.1%; padding-left: 0.5%; text-align: center;">Target</td>
                                        <td style="font-size: 14px; width: 25.1%; padding-left: 0.5%; text-align: center;">Attachments</td>
                                        <td style="font-size: 14px; width: 5.2%; padding-left: 0.5%; text-align: center;">Finish</td>
                                        <td style="font-size: 14px; width: 5.2%; padding-left: 0.5%; text-align: center;">Close</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">1</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Visa</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                              <asp:UpdatePanel ID="UpdatePanel2"  EnableViewState="true" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                                             <asp:DropDownList ID="ddlVisaBund2" onchange="ddlVisaBund2Change();" class="form1" OnSelectedIndexChanged="ddlVisaBund2_SelectedIndexChanged" AutoPostBack="true" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlVisatype2" onchange="ddlVisatype2Change();" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                    </ContentTemplate>
                                                  </asp:UpdatePanel>

                                        </td>
                                        <td style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp5" data-placeholder="select employee" multiple="mutiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">

                                            <asp:DropDownList ID="ddlVisaStatus2" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">


                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                                <asp:ListItem Value="1">Document Preparation</asp:ListItem>
                                                <asp:ListItem Value="2">Applied, Awaiting MOI Approval</asp:ListItem>
                                                <asp:ListItem Value="3">MOI Approved, ready to print</asp:ListItem>
                                                <asp:ListItem Value="4">MOI rejected – Close</asp:ListItem>
                                                <asp:ListItem Value="5">MOI Rejected – Reapply</asp:ListItem>
                                                <asp:ListItem Value="6">Visa print complete</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate5" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;" onkeypress="DisableEnter(event)"></asp:TextBox>
                                        </td>
                                        <td id="tdFileVisa" style="width: 25%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <label for="cphMain_FileUploadVisaSingle" id="Label1" class="custom-file-upload" tabindex="0" style="display: none; margin-left: 9.5%; font-family: Calibri;">
                                                <img src="../../../../Images/Icons/cloud_upload.jpg" />Upload File</label>


                                            <asp:FileUpload ID="FileUploadVisaSingle" class="fileUpload" runat="server" Style="height: 30px; display: block; width: 100%;" onchange="ClearDivDisplayImageVisaMulti()" Accept="All" />


                                            <div id="divVisaMulti" runat="server" style="float: left; width: 89%; height: 20px; margin-top: 0%; margin-left: 12%;">
                                                <div id="imgWarpVisaMulti" class="imgWrap">
                                                    <img id="imgClearVisaMulti" src="/Images/Icons/clear-image-blue.png" alt="Clear" title="Remove File" onclick="ClearImageVisaMulti()" style="cursor: pointer; float: right;" />
                                                </div>
                                                <div id="divImageDisplayVisaMulti" runat="server">
                                                </div>
                                            </div>
                                            <asp:Label ID="Label3VisaMulti" runat="server" Text="No File selected" Style="display: none; font-family: Calibri; font-size: medium;"></asp:Label>

                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="VisaFinish2" style="opacity: 1;" class="tooltip" title="Finish" onclick="return FinishProcess2('Visa2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/success.png' /></a>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="VisaClose2" class="tooltip" title="Close" onclick="return CloseProcess2('Visa2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/close.png' /></a>
                                            <a id="VisaRecall2" style="display: none" class="tooltip" title="Recall" onclick="return RecallProcess2('Visa2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/recallProcess.png' /></a>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">2</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Flight Ticket</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlFlightTcktType2" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">

                                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="1">ECONOMY CLASS</asp:ListItem>
                                                <asp:ListItem Value="2">BUSSINESS CLASS</asp:ListItem>
                                                <asp:ListItem Value="3">FIRST CLASS</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp6" data-placeholder="select employee" multiple="multiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlFlightStatus2" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">


                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                                <asp:ListItem Value="1">Availability Check</asp:ListItem>
                                                <asp:ListItem Value="2">Awaiting, Approval from candidate</asp:ListItem>
                                                <asp:ListItem Value="3">Booking Confirm, ticket copy attach</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate6" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;" onkeypress="DisableEnter(event)"></asp:TextBox>
                                        </td>
                                        <td id="tdFileFlight" style="width: 25%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">

                                            <label for="cphMain_FileUploadFlightTicketSingle" id="lblFlightTicketMulti" class="custom-file-upload" tabindex="0" style="display: none; margin-left: 9.5%; font-family: Calibri;">
                                                <img src="../../../../Images/Icons/cloud_upload.jpg" />Upload File</label>


                                            <asp:FileUpload ID="FileUploadFlightTicketSingle" class="fileUpload" runat="server" Style="height: 30px; display: block; width: 100%;" onchange="ClearDivDisplayImageFlightTicketMulti()" Accept="All" />


                                            <div id="divFlightTicketMulti" runat="server" style="float: left; width: 89%; height: 20px; margin-top: 0%; margin-left: 12%;">
                                                <div id="imgWrapFlightTicketMulti" class="imgWrap">
                                                    <img id="imgClearFlightTicketMulti" src="/Images/Icons/clear-image-blue.png" alt="Clear" title="Remove File" onclick="ClearImageFlightTicketMulti()" style="cursor: pointer; float: right;" />
                                                </div>
                                                <div id="divImageDisplayFlightTicketMulti" runat="server">
                                                </div>
                                            </div>
                                            <asp:Label ID="Label3FlightTicketMulti" runat="server" Text="No File selected" Style="display: none; font-family: Calibri; font-size: medium;"></asp:Label>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="FliFinish2" style="opacity: 0.5;" class="tooltip" title="Finish" onclick="return FinishProcess2('Flight2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/success.png' /></a>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="FliClose2" class="tooltip" title="Close" onclick="return CloseProcess2('Flight2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/close.png' /></a>

                                            <a id="FliRecall2" style="display: none" class="tooltip" title="Recall" onclick="return RecallProcess2('Flight2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/recallProcess.png' /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">3</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Room Allotment</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlRoomAltmntType2" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">
                                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="1">BED SPACE</asp:ListItem>
                                                <asp:ListItem Value="2">1BHK</asp:ListItem>
                                                <asp:ListItem Value="3">2BHK</asp:ListItem>
                                                <asp:ListItem Value="4">3BHK</asp:ListItem>
                                                <asp:ListItem Value="5">VILLA</asp:ListItem>
                                                <asp:ListItem Value="6">FLAT</asp:ListItem>
                                            </asp:DropDownList>

                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp7" data-placeholder="select employee" multiple="multiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlRoomAltmntStats2" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">


                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                                <asp:ListItem Value="1">Availability Check</asp:ListItem>
                                                <asp:ListItem Value="2">Facility Procurement</asp:ListItem>
                                                <asp:ListItem Value="3">Complete</asp:ListItem>
                                                <asp:ListItem Value="4">Closed Without Allotment</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate7" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;" onkeypress="DisableEnter(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 25%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd"></td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="roomFinish2" style="opacity: 0.5;" class="tooltip" title="Finish" onclick="return FinishProcess2('Room2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/success.png' /></a>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="RoomClose2" class="tooltip" title="Close" onclick="return CloseProcess2('Room2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/close.png' /></a>
                                            <a id="RoomRecall2" style="display: none" class="tooltip" title="Recall" onclick="return RecallProcess2('Room2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/recallProcess.png' /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">4</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Air Port Pickup</td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlVehicle2" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp8" data-placeholder="select employee" multiple="multiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlAirPickStats2" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">

                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate8" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;" onkeypress="DisableEnter(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 25%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd"></td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="AirFinish2" style="opacity: 0.5;" class="tooltip" title="Finish" onclick="return FinishProcess2('AirPick2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/success.png' /></a>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="AirClose2" class="tooltip" title="Close" onclick="return CloseProcess2('AirPick2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/close.png' /></a>

                                            <a id="AirRecall2" style="display: none" class="tooltip" title="Recall" onclick="return RecallProcess2('AirPick2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/recallProcess.png' /></a>
                                        </td>
                                    </tr>
                                </tbody>

                            </table>



                        </div>

                    </div>
                </div>


                <asp:Button ID="btnProcessSingleSave" class="save" runat="server" Text="Update" Style="width: 105px; float: left; margin-left: 34%;" OnClientClick="return ValidateProcessSingle()" OnClick="btnProcessSingleSave_Click" />
                <%--<input type="button" id="btnProcessMultyClr" class="save" style="width: 90px; float: left;" value="Clear" />--%>
                <input type="button" id="btnProcessSingleCancel" onclick="ConfirmCancel();" class="save" style="width: 90px; float: left;" value="Cancel" />

            </div>

        </div>
    </div>


    <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: black; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.8; z-index: 29; height: auto !important;display:none"
        class="freezelayer" id="freezelayer">
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

        #tblOnBoardSingle > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
            height: 30px;
            background: #DDD;
            font-size: 14px;
            color: #5c5c5e;
        }

        #tblOnBoardSingle > tbody > tr:nth-child(2n) > td, .main_table > tbody > tr:nth-child(2n) > th {
            height: 30px;
            background: #C2C2C2;
            font-size: 14px;
            color: #000;
        }

        #tblOnBoardMult > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
            height: 30px;
            background: #DDD;
            font-size: 14px;
            color: #5c5c5e;
        }

        #tblOnBoardMult > tbody > tr:nth-child(2n) > td, .main_table > tbody > tr:nth-child(2n) > th {
            height: 30px;
            background: #C2C2C2;
            font-size: 14px;
            color: #000;
        }

        .select2-container--default .select2-selection--multiple .select2-selection__choice {
            background-color: #a5a5a5;
            border-color: #8d8d8d;
            padding: 1px 5px;
            color: #fff;
            font-size: 14px;
            margin: 2px;
            max-width: 260px;
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

        .TableHeaderProcess {
            background-color: #A4B487;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 30px;
        }


        .MyModalProcessMultiple {
            display: none;
            position: fixed;
            z-index: 100;
            padding-top: 0%;
            left: 8%;
            top: 15%;
            width: 84%;
            height: 80%;
            overflow: auto;
            background-color: white;
            border: 3px solid;
            border-color: #6f7b5a;
        }


        .cont_rght {
            width: 97%;
        }

        .save {
            width: 100%;
        }

        input[type="radio"] {
            display: table-cell;
        }

        .cont_rght {
            width: 100%;
            padding-top: 1%;
        }

        .lblTop {
            width: 232px;
            padding: 0px 8px;
            float: right;
            color: #000;
            font-size: 14px;
            font-family: calibri;
            word-wrap: break-word;
        }
    </style>

</asp:Content>

