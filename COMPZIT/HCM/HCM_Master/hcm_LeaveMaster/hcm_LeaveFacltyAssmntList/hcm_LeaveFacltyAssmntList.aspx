<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" CodeFile="hcm_LeaveFacltyAssmntList.aspx.cs" Inherits="HCM_HCM_Master_hcm_LeaveMaster_hcm_LeaveFacltyAssmntList_hcm_LeaveFacltyAssmntList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

   
   
   



    <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>
    <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>


    <script src="/JavaScript/datepicker/bootstrap-datepicker.js"></script>

    <link href="/JavaScript/datepicker/datepicker3.css" rel="stylesheet" />


     <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <%--<script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>--%>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">
        var $noC = jQuery.noConflict();

        $noCon = jQuery.noConflict();
        $noCon2 = jQuery.noConflict();
        $noCon(function () {

            document.getElementById("<%=hiddenFinishStatus.ClientID%>").value = "0";
            document.getElementById("<%=hiddenFinishStatus.ClientID%>").value = "0";

            document.getElementById("<%=ddlEmp1.ClientID%>").disabled = true;
            document.getElementById("<%=ddlVisaStatus.ClientID%>").disabled = true;
            document.getElementById("<%=txtTargetDate1.ClientID%>").disabled = true;
            document.getElementById("<%=ddlClear.ClientID%>").disabled = true;
            document.getElementById("<%=DropDownList2.ClientID%>").disabled = true;
            document.getElementById("<%=TextBox1.ClientID%>").disabled = true;
            document.getElementById('VisaFinish').style.opacity = "1";
            document.getElementById('VisaClose').style.opacity = "1";
            document.getElementById('A1').style.opacity = "0.5";
            document.getElementById('A2').style.opacity = "0.5";
            //Initialize Select2 Elements
            $noCon2(".select2").select2();

            document.getElementById("freezelayer").style.display = "none";
            document.getElementById("MyModalProcessMultiple").style.display = "none";
            $noCon2('#txtTargetDate1').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date()
            });
            $noCon2('#txtTargetDate2').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),

            });
            $noCon2('#txtTargetDate3').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date()
            });
            $noCon2('#txtTargetDate4').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date()
            });
            $noCon2('#txtTargetDate5').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date()
            });
            $noCon2('#txtTargetDate6').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date()
            });
            $noCon2('#txtTargetDate7').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),
                forceParse: false //evm-0023 single lin
            });
            $noCon2('#txtTargetDate8').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),
                forceParse: false //evm-0023 single lin
            });
            $noCon2('#cphMain_txtLeavRangeFrm').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date()
            });
            $noCon2('#cphMain_txtLeavRangeTo').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date()
            });
        });
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
       
           </style>
   
       <script>


           // for not allowing enter
           function DisableEnter(evt) {

               evt = (evt) ? evt : window.event;
               var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
               if (keyCodes == 13) {
                   return false;
               }
           }

           var $auaa = jQuery.noConflict();

           (function ($auaa) {
               $auaa(function () {

                   $auaa('#cphMain_ddlEmploy').selectToAutocomplete1Letter();
                   $auaa('form').submit(function () {
                   });
                   //re

               });
           })(jQuery);




           function ImagePosition(object) {

               var $Mo = jQuery.noConflict();
               
               var offset = $Mo("#" + object).offset();

               var posY = 0;
               var posX = 0;
               posY = offset.top;

               posX = offset.left

               posX = 47;

               var d = document.getElementById('ui-id-1');
               d.style.position = "absolute";
               d.style.left = posX +1.8+ '%';
               d.style.top = posY +39+ '%';
           }


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
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave facility assignment added successfully.";
            $(window).scrollTop(0);
        }
        //old
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave facility assignment updated successfully.";
        }

        function SuccessRecall() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave facility assignment Recalled successfully.";
        }

        function getselected() {
            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
            var strAmntList = "";
            var strLeavid = "";
            var strAiline="";var airlineChk=0;
            checked = false;
            for (i = 0; i < RowCount; i++) {


                if (document.getElementById('cblcandidatelist' + i).checked) {

                    checked = true;
                    strAmntList = strAmntList + document.getElementById('tdcandiateid' + i).innerHTML + ',';
                    strLeavid = strLeavid + document.getElementById('tdLevid' + i).innerHTML + ',';
                   
                    if (document.getElementById('tdAirlinePrfed' + i).innerHTML == 0 ) {

                        document.getElementById("<%=HiddenAirlinNoteneed.ClientID%>").value = 1;
                        strAiline = strAiline + '0' + ',';
                    }
                    else {

                        document.getElementById("<%=HiddenAirlineneed.ClientID%>").value = 1;
                        strAiline = strAiline + '1' + ',';
                    }
                    
                }
            }
            if (checked == false) {
                return false;
            }

            document.getElementById("<%=Hiddenchecklist.ClientID%>").value = strAmntList;
            document.getElementById("<%=HiddenLeavId.ClientID%>").value = strLeavid;
            document.getElementById("<%=HiddenAirLine.ClientID%>").value = strAiline;
            
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
            ret = true;
            var CrdExpWithoutReplace = document.getElementById("<%=txtLeavRangeFrm.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtLeavRangeFrm.ClientID%>").value = replaceCode2;

            var CrdExpWithoutReplace = document.getElementById("<%=txtLeavRangeTo.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtLeavRangeTo.ClientID%>").value = replaceCode2;

            var FromDate = document.getElementById("<%=txtLeavRangeFrm.ClientID%>").value;
            var ToDate = document.getElementById("<%=txtLeavRangeTo.ClientID%>").value;





            if (ret == true) {

                document.getElementById("<%=HiddenSearchField.ClientID%>").value = FromDate + ',' + ToDate ;
                }

        }


        function ShowProcess_Multy(EmpName, EmpId, TodayDate) {


            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
            var strAmntList = "";
            var strLeavid = "";
            var strAiline="";
            checked = false;
            count = 0;
            for (i = 0; i < RowCount; i++) {


                if (document.getElementById('cblcandidatelist' + i).checked) {

                    checked = true;
                    count++;
                    strAmntList = strAmntList + document.getElementById('tdcandiateid' + i).innerHTML + ',';
                    strLeavid = strLeavid + document.getElementById('tdLevid' + i).innerHTML + ',';

                    if (document.getElementById('tdAirlinePrfed' + i).innerHTML == 0 ) {

                        document.getElementById("<%=HiddenAirlinNoteneed.ClientID%>").value = 1;
                        strAiline = strAiline + '0' + ',';
                    }
                    else {

                        document.getElementById("<%=HiddenAirlineneed.ClientID%>").value = 1;
                        strAiline = strAiline + '1' + ',';
                    }
                   // strAiline=strAiline+document.getElementById('tdAirlinePrfed' + i).innerHTML + ',';

                }
            }
        

        
            if (checked == false) {

                document.getElementById('divErrorlabel').style.visibility = "visible";
                return false;
            }
            else {
                document.getElementById('divErrorlabel').style.visibility = "hidden";
                document.getElementById('lblNoOfselectedEmp').innerHTML = count;

                document.getElementById("<%=Hiddenchecklist.ClientID%>").value = strAmntList;
                document.getElementById("<%=HiddenLeavId.ClientID%>").value = strLeavid;
                document.getElementById("<%=HiddenAirLine.ClientID%>").value = strAiline;


                document.getElementById("<%=ddlEmp1.ClientID%>").disabled = true;
                document.getElementById("<%=ddlVisaStatus.ClientID%>").disabled = true;
                document.getElementById("<%=txtTargetDate1.ClientID%>").disabled = true;
                document.getElementById("<%=ddlClear.ClientID%>").disabled = true;
                document.getElementById("<%=DropDownList2.ClientID%>").disabled = true;
                document.getElementById("<%=TextBox1.ClientID%>").disabled = true;
                document.getElementById('VisaFinish').style.opacity = ".5";
                document.getElementById('VisaClose').style.opacity = ".5";
                document.getElementById('A1').style.opacity = ".5";
                document.getElementById('A2').style.opacity = ".5";

                document.getElementById("MyModalProcessMultiple").style.display = "block";
                document.getElementById("freezelayer").style.display = "";
                if (document.getElementById("<%=HiddenAirlinNoteneed.ClientID%>").value == "1" && document.getElementById("<%=HiddenAirlineneed.ClientID%>").value == "1") {
                   
                }
                else if (document.getElementById("<%=HiddenAirlinNoteneed.ClientID%>").value == "1") {
                    document.getElementById('trFlight').style.display = "none";
                    document.getElementById('SlCler').innerHTML = "1";
                    document.getElementById('slSetl').innerHTML = "2";
                    document.getElementById('SlExit').innerHTML = "3";

                    }
                return true;
            }
        }

        function CloseProcessMulty() {
            document.getElementById("MyModalProcessMultiple").style.display = "none";
            document.getElementById("freezelayer").style.display = "none";
   
          
            document.getElementById("<%=ddlEmp4.ClientID%>").value = "";
            $noC('#cphMain_ddlEmp4').val("");
            $noC('#cphMain_ddlEmp3').val("");
            $noC('#cphMain_ddlEmp2').val("");
            $noC('#cphMain_ddlEmp1').val("");
            $noC("#cphMain_ddlEmp4").trigger("change");
            $noC("#cphMain_ddlEmp3").trigger("change");
            $noC("#cphMain_ddlEmp2").trigger("change");
            $noC("#cphMain_ddlEmp1").trigger("change");
            document.getElementById("<%=ddlEmp3.ClientID%>").value = "";
            document.getElementById("<%=ddlEmp2.ClientID%>").value = "";
            document.getElementById("<%=ddlEmp1.ClientID%>").value = "";
            document.getElementById("<%=ddlExitprcss.ClientID%>").value = "0";
            document.getElementById("<%=ddlSettlment.ClientID%>").value = "0";
            document.getElementById("<%=ddlFlightStatus.ClientID%>").value = "0";
            document.getElementById("<%=ddlVisaStatus.ClientID%>").value = "0";
            document.getElementById("<%=txtTargetDate1.ClientID%>").value = "";
            document.getElementById("<%=txtTargetDate2.ClientID%>").value = "";
            document.getElementById("<%=txtTargetDate3.ClientID%>").value = "";
            document.getElementById("<%=txtTargetDate4.ClientID%>").value = "";
            $('#MyModalProcessMultiple').find(':input').prop('disabled', false);
        }

        function CloseProcessSingle() {
            document.getElementById("MymodalProcessSingle").style.display = "none";
            document.getElementById("freezelayer").style.display = "none";

            document.getElementById("<%=ddlEmp8.ClientID%>").value = "";
            document.getElementById("<%=ddlEmp7.ClientID%>").value = "";
            document.getElementById("<%=ddlEmp6.ClientID%>").value = "";
          
            document.getElementById("<%=ddlSettlment7.ClientID%>").value = "0";
            document.getElementById("<%=ddlExitprcss8.ClientID%>").value = "0";
            document.getElementById("<%=ddlFlightStatus2.ClientID%>").value = "0";
           
            document.getElementById("<%=txtTargetDate8.ClientID%>").value = "";
            document.getElementById("<%=txtTargetDate7.ClientID%>").value = "";
            document.getElementById("<%=txtTargetDate6.ClientID%>").value = "";
          


           
            document.getElementById('roomFinish2').style.pointerEvents = "";
            document.getElementById('roomFinish2').style.opacity = "1";
            document.getElementById('AirFinish2').style.pointerEvents = "";
            document.getElementById('AirFinish2').style.opacity = "1";
            document.getElementById('FliFinish2').style.pointerEvents = "";
            document.getElementById('FliFinish2').style.opacity = "1";


          
            document.getElementById('FliClose2').style.pointerEvents = "";
            document.getElementById('FliClose2').style.opacity = "1";
            document.getElementById('FliClose2').style.display = "";
            document.getElementById('RoomClose2').style.pointerEvents = "";
            document.getElementById('RoomClose2').style.opacity = "1";
            document.getElementById('RoomClose2').style.display = "";
            document.getElementById('AirClose2').style.pointerEvents = "";
            document.getElementById('AirClose2').style.opacity = "1";
            document.getElementById('AirClose2').style.display = "";

           
            document.getElementById('FliRecall2').style.display = "none";
            document.getElementById('RoomRecall2').style.display = "none";
            document.getElementById('AirRecall2').style.display = "none";



            $('#MymodalProcessSingle').find(':input').prop('disabled', false);
        }

        function ValidateProcessSingle() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
          
              


            if (document.getElementById("<%=HiddenUpdFlghtChk.ClientID%>").value == "1") {
                var FlightStatus = document.getElementById("<%=ddlFlightStatus2.ClientID%>");
                var FlightStatusText = FlightStatus.options[FlightStatus.selectedIndex].text;
            }

            var RoomStatus = document.getElementById("<%=ddlSettlment7.ClientID%>");
            var RoomStatusText = RoomStatus.options[RoomStatus.selectedIndex].text;

            var VehicleStatus = document.getElementById("<%=ddlExitprcss8.ClientID%>");
            var VehicleStatusText = VehicleStatus.options[VehicleStatus.selectedIndex].text;

            if (document.getElementById("<%=HiddenUpdFlghtChk.ClientID%>").value == "1") {
                var FlightDate = document.getElementById("<%=txtTargetDate6.ClientID%>").value.trim();
            }
            var RoomDate = document.getElementById("<%=txtTargetDate7.ClientID%>").value.trim();
            var VehicleDate = document.getElementById("<%=txtTargetDate8.ClientID%>").value.trim();

         
            document.getElementById("<%=ddlEmp8.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlEmp7.ClientID%>").style.borderColor = "";
            if (document.getElementById("<%=HiddenUpdFlghtChk.ClientID%>").value == "1") {
                document.getElementById("<%=ddlEmp6.ClientID%>").style.borderColor = "";
            }
          
            document.getElementById("<%=ddlSettlment7.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlExitprcss8.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlFlightStatus2.ClientID%>").style.borderColor = "";
          
            document.getElementById("<%=txtTargetDate8.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTargetDate7.ClientID%>").style.borderColor = "";
            if (document.getElementById("<%=HiddenUpdFlghtChk.ClientID%>").value == "1") {
                document.getElementById("<%=txtTargetDate6.ClientID%>").style.borderColor = "";
            }

            if (VehicleDate == "") {
                document.getElementById("<%=txtTargetDate8.ClientID%>").style.borderColor = "red";
                // document.getElementById("<%=txtTargetDate8.ClientID%>").focus();
                ret = false;
            }

            if (RoomDate == "") {
                document.getElementById("<%=txtTargetDate7.ClientID%>").style.borderColor = "red";
                // document.getElementById("<%=txtTargetDate7.ClientID%>").focus();
                ret = false;
            }
            if (document.getElementById("<%=HiddenUpdFlghtChk.ClientID%>").value == "1" ) 
            {
                if (FlightDate == "") {
                    document.getElementById("<%=txtTargetDate6.ClientID%>").style.borderColor = "red";
                    //document.getElementById("<%=txtTargetDate6.ClientID%>").focus();
                    ret = false;
                }
            }

            if (VehicleStatusText == "--SELECT--") {
                document.getElementById("<%=ddlSettlment7.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlSettlment7.ClientID%>").focus();
                ret = false;
            }
            if (RoomStatusText == "--SELECT--") {
                document.getElementById("<%=ddlExitprcss8.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlExitprcss8.ClientID%>").focus();
                ret = false;
            }
            if (FlightStatusText == "--SELECT--") {
                document.getElementById("<%=ddlFlightStatus2.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlFlightStatus2.ClientID%>").focus();
                ret = false;
            }
           
            if (document.getElementById("<%=ddlEmp8.ClientID%>").value == "") {
                document.getElementById("<%=ddlEmp8.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlEmp8.ClientID%>").focus();
                ret = false;
            }
            if (document.getElementById("<%=ddlEmp7.ClientID%>").value == "") {

                document.getElementById("<%=ddlEmp7.ClientID%>").style.borderColor = "red";
                   document.getElementById("<%=ddlEmp7.ClientID%>").focus();
                   ret = false;
            }
                if (document.getElementById("<%=HiddenUpdFlghtChk.ClientID%>").value == "1" ) {
                    if (document.getElementById("<%=ddlEmp6.ClientID%>").value == "") {

                        document.getElementById("<%=ddlEmp6.ClientID%>").style.borderColor = "red";
                        document.getElementById("<%=ddlEmp6.ClientID%>").focus();
                        ret = false;
                    }
                }
          


         
            if (ret == false) {
                CheckSubmitZero();

            }
            else {
                $('#MymodalProcessSingle').find(':input').prop('disabled', false);

                //var Emp1val = $noC('#cphMain_ddlEmp5').val();
                if (document.getElementById("<%=HiddenUpdFlghtChk.ClientID%>").value == "1" ) 
                {
                    var Emp2val = $noC('#cphMain_ddlEmp6').val();
                }
                var Emp3val = $noC('#cphMain_ddlEmp7').val();
                var Emp4val = $noC('#cphMain_ddlEmp8').val();
                    // document.getElementById("<%=hiddenEmp1.ClientID%>").value = Emp1val;
                    if (document.getElementById("<%=HiddenUpdFlghtChk.ClientID%>").value == "1" ) 
                {
                    document.getElementById("<%=hiddenEmp2.ClientID%>").value = Emp2val;
                }
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

            var flightchk = 0;
          //    var VisaTypeText = VisaType.options[VisaType.selectedIndex].text;

            if (document.getElementById("<%=HiddenAirlinNoteneed.ClientID%>").value == "1" && document.getElementById("<%=HiddenAirlineneed.ClientID%>").value == "1") {
               
            }
             else if (document.getElementById("<%=HiddenAirlinNoteneed.ClientID%>").value == "1")
            {
                 flightchk = 1;
             }




          //  var VisaStatus = document.getElementById("<%=ddlVisaStatus.ClientID%>");
         //   var VisaStatusText = VisaStatus.options[VisaStatus.selectedIndex].text;
            if (flightchk == 0) {
                var FlightStatus = document.getElementById("<%=ddlFlightStatus.ClientID%>");
                var FlightStatusText = FlightStatus.options[FlightStatus.selectedIndex].text;
            }

            var RoomStatus = document.getElementById("<%=ddlSettlment.ClientID%>");
            var Settlement = RoomStatus.options[RoomStatus.selectedIndex].text;

            var VehicleStatus = document.getElementById("<%=ddlExitprcss.ClientID%>");
            var VehicleStatusText = VehicleStatus.options[VehicleStatus.selectedIndex].text;

            // var VisaDate = document.getElementById("<%=txtTargetDate1.ClientID%>").value.trim();
            if (flightchk == 0) {
                var FlightDate = document.getElementById("<%=txtTargetDate2.ClientID%>").value.trim();
            }
              var RoomDate = document.getElementById("<%=txtTargetDate3.ClientID%>").value.trim();
              var VehicleDate = document.getElementById("<%=txtTargetDate4.ClientID%>").value.trim();

           
              document.getElementById("<%=ddlEmp4.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlEmp3.ClientID%>").style.borderColor = "";
            if (flightchk == 0) {
                document.getElementById("<%=ddlEmp2.ClientID%>").style.borderColor = "";
            }
              //document.getElementById("<%=ddlEmp1.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlExitprcss.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlSettlment.ClientID%>").style.borderColor = "";
            if (flightchk == 0) {
                document.getElementById("<%=ddlFlightStatus.ClientID%>").style.borderColor = "";
            }
             // document.getElementById("<%=ddlVisaStatus.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtTargetDate4.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTargetDate3.ClientID%>").style.borderColor = "";
            if (flightchk == 0) {
                document.getElementById("<%=txtTargetDate2.ClientID%>").style.borderColor = "";
            }
             // document.getElementById("<%=txtTargetDate1.ClientID%>").style.borderColor = "";


              if (VehicleDate == "") {
                  document.getElementById("<%=txtTargetDate4.ClientID%>").style.borderColor = "red";
                // document.getElementById("<%=txtTargetDate4.ClientID%>").focus();
                ret = false;
            }

            if (RoomDate == "") {
                document.getElementById("<%=txtTargetDate3.ClientID%>").style.borderColor = "red";
                // document.getElementById("<%=txtTargetDate3.ClientID%>").focus();
                ret = false;
            }
            if (flightchk == 0) {
                if (FlightDate == "") {
                    document.getElementById("<%=txtTargetDate2.ClientID%>").style.borderColor = "red";
                    //document.getElementById("<%=txtTargetDate2.ClientID%>").focus();
                    ret = false;
                }
            }
           // if (VisaDate == "") {
              //  document.getElementById("<%=txtTargetDate1.ClientID%>").style.borderColor = "red";
                //document.getElementById("<%=txtTargetDate1.ClientID%>").focus();
              //  ret = false;
           // }

            if (VehicleStatusText == "--SELECT--") {
                document.getElementById("<%=ddlExitprcss.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlExitprcss.ClientID%>").focus();
                ret = false;
            }
            if (Settlement == "--SELECT--") {
                document.getElementById("<%=ddlSettlment.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlSettlment.ClientID%>").focus();
                ret = false;
            }
            if (flightchk == 0) {
                if (FlightStatusText == "--SELECT--") {
                    document.getElementById("<%=ddlFlightStatus.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=ddlFlightStatus.ClientID%>").focus();
                    ret = false;
                }
            }
           // if (VisaStatusText == "--SELECT--") {
             //   document.getElementById("<%=ddlVisaStatus.ClientID%>").style.borderColor = "red";
            //    document.getElementById("<%=ddlVisaStatus.ClientID%>").focus();
            //    ret = false;
           // }
            if (document.getElementById("<%=ddlEmp4.ClientID%>").value == "") {

                  document.getElementById("<%=ddlEmp4.ClientID%>").style.borderColor = "red";
                   document.getElementById("<%=ddlEmp4.ClientID%>").focus();
                   ret = false;
               }
               if (document.getElementById("<%=ddlEmp3.ClientID%>").value == "") {

                  document.getElementById("<%=ddlEmp3.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlEmp3.ClientID%>").focus();
                ret = false;
               }
            if (flightchk == 0) {
                if (document.getElementById("<%=ddlEmp2.ClientID%>").value == "") {

                    document.getElementById("<%=ddlEmp2.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=ddlEmp2.ClientID%>").focus();
                    ret = false;
                }
            }
          //  if (document.getElementById("<%=ddlEmp1.ClientID%>").value == "") {

               //   document.getElementById("<%=ddlEmp1.ClientID%>").style.borderColor = "red";
               // document.getElementById("<%=ddlEmp1.ClientID%>").focus();
              //  ret = false;
           // }


        
          
            if (ret == false) {
                CheckSubmitZero();

            }
            else {
                //  var Emp1val = $noC('#cphMain_ddlEmp1').val();
                if (flightchk == 0) {
                    var Emp2val = $noC('#cphMain_ddlEmp2').val();
                }
                var Emp3val = $noC('#cphMain_ddlEmp3').val();
                var Emp4val = $noC('#cphMain_ddlEmp4').val();
                // document.getElementById("<%=hiddenEmp1.ClientID%>").value = Emp1val;
                if (flightchk == 0) {
                    document.getElementById("<%=hiddenEmp2.ClientID%>").value = Emp2val;
                }
                  document.getElementById("<%=hiddenEmp3.ClientID%>").value = Emp3val;
                  document.getElementById("<%=hiddenEmp4.ClientID%>").value = Emp4val;
            }
            if (ret == true) {
                if (document.getElementById("<%=HiddenAirlinNoteneed.ClientID%>").value == "1" && document.getElementById("<%=HiddenAirlineneed.ClientID%>").value == "1") {
                    if (confirm("The datas that where assigned against ticket particular only applicable on the employees those who have ticket facility")) {

                    }
                    else {
                        ret = false;
                    }
                }
               // else if (document.getElementById("<%=HiddenAirlinNoteneed.ClientID%>").value == "1")
               // {
               //     document.getElementById('trFlight').style.display = "none";
               // }

            }

              return ret;
          }
          function DisableButton2(type) {

             
              if (type == "Flight") {
                 
                  document.getElementById('roomFinish2').style.pointerEvents = "";
                  document.getElementById('roomFinish2').style.opacity = "1";
                  document.getElementById('AirFinish2').style.pointerEvents = "none";
                  document.getElementById('AirFinish2').style.opacity = ".5";
                  document.getElementById('FliFinish2').style.pointerEvents = "none";
                  document.getElementById('FliFinish2').style.opacity = ".5";

               
                  document.getElementById('FliClose2').style.pointerEvents = "none";
                  document.getElementById('FliClose2').style.opacity = ".5";
              }
              if (type == "Room") {

               
                  document.getElementById('roomFinish2').style.pointerEvents = "none";
                  document.getElementById('roomFinish2').style.opacity = ".5";
                  document.getElementById('AirFinish2').style.pointerEvents = "";
                  document.getElementById('AirFinish2').style.opacity = "1";

                  document.getElementById('AirClose2').style.pointerEvents = "";
                  document.getElementById('AirClose2').style.opacity = "1";
                  
              
                  document.getElementById('FliFinish2').style.pointerEvents = "none";
                  document.getElementById('FliFinish2').style.opacity = ".5";

                
                  document.getElementById('FliClose2').style.pointerEvents = "none";
                  document.getElementById('FliClose2').style.opacity = ".5";
                  document.getElementById('RoomClose2').style.pointerEvents = "none";
                  document.getElementById('RoomClose2').style.opacity = ".5";

              }
              if (type == "AirPick") {
                 
                  document.getElementById('roomFinish2').style.pointerEvents = "none";
                  document.getElementById('roomFinish2').style.opacity = ".5";
                  document.getElementById('AirFinish2').style.pointerEvents = "none";
                  document.getElementById('AirFinish2').style.opacity = ".5";
                  document.getElementById('FliFinish2').style.pointerEvents = "none";
                  document.getElementById('FliFinish2').style.opacity = ".5";

                
                  document.getElementById('FliClose2').style.pointerEvents = "none";
                  document.getElementById('FliClose2').style.opacity = ".5";
                  document.getElementById('RoomClose2').style.pointerEvents = "none";
                  document.getElementById('RoomClose2').style.opacity = ".5";
                  document.getElementById('AirClose2').style.pointerEvents = "none";
                  document.getElementById('AirClose2').style.opacity = ".5";
              }

          }
          
          function CloseProcess2MulBrwserChk(Type) {
              var CandId = document.getElementById("<%=hiddenCandidateId.ClientID%>").value;
                     var LeavId = document.getElementById("<%=HiddenUpdLevid.ClientID%>").value;
              var typename;
                     if (Type == "Flight") {
                         typename = 0;
                     }
                     if (Type == "Room") {
                         typename = 2;

                     }
                     if (Type == "AirPick") {
                         typename = 3;

                     }
                   
                     var Details = PageMethods.CheckStatusBefrEdit(typename, CandId, LeavId, function (response) {
                        
                         var SucessDetails = response;
                         if (response[0] == 0 && response[1] == 0) {
                             if (Type == "Flight") {
                                 CloseProcess2('Flight');
                             }
                             if (Type == "Room") {
                                 CloseProcess2('Room');

                             }
                             if (Type == "AirPick") {
                                 CloseProcess2('AirPick');

                             }

                         }
                         else {
                             if (Type == "Flight") {

                                 document.getElementById("<%=HiddenPrtclrChk.ClientID%>").value = "0";
                            document.getElementById("<%=ddlEmp6.ClientID%>").disabled = "true";
                            document.getElementById("<%=ddlFlightStatus2.ClientID%>").disabled = "true";
                            document.getElementById("<%=txtTargetDate6.ClientID%>").disabled = "true";
                            document.getElementById('FliFinish2').disabled = "true";
                            document.getElementById('FliClose2').disabled = "true";
                            if (response[1] == 1) {
                                alert("Sorry.It is already closed");
                                document.getElementById('FliRecall2').style.display = "block";
                                document.getElementById('FliClose2').style.display = "none";
                                document.getElementById("<%=HiddenPrtclrChk1.ClientID%>").value = "2";
                                document.getElementById("<%=ddlEmp7.ClientID%>").disabled = "true";
                                document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = "true";
                                document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = "true";
                                document.getElementById('roomFinish2').disabled = "true";
                                document.getElementById('RoomClose2').disabled = "true";
                                document.getElementById("<%=HiddenPrtclrChk.ClientID%>").value = "3";
                                document.getElementById("<%=ddlEmp8.ClientID%>").disabled = "true";
                                document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = "true";
                                document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = "true";
                                document.getElementById('AirFinish2').disabled = "true";
                                document.getElementById('AirClose2').disabled = "true";
                            }
                            else {
                                alert("Sorry.It is already finished");

                                document.getElementById('roomFinish2').style.pointerEvents = "";
                                document.getElementById('roomFinish2').style.opacity = "1";
                            }

                            
                        }
                        if (Type == "Room") {
                            // document.getElementById('trSettlmnt1').disabled = "true";
                            document.getElementById("<%=HiddenPrtclrChk.ClientID%>").value = "2";
                            document.getElementById("<%=ddlEmp7.ClientID%>").disabled = "true";
                            document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = "true";
                            document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = "true";
                            document.getElementById('roomFinish2').disabled = "true";
                            document.getElementById('RoomClose2').disabled = "true";
                            if (response[1] == 1) {
                                alert("Sorry.It is already closed");
                                document.getElementById('RoomRecall2').style.display = "block";
                                document.getElementById('RoomClose2').style.display = "none";

                              
                                document.getElementById("<%=ddlEmp7.ClientID%>").disabled = "true";
                                document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = "true";
                                document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = "true";
                                document.getElementById('roomFinish2').disabled = "true";
                                document.getElementById('RoomClose2').disabled = "true";

                                document.getElementById("<%=HiddenPrtclrChk.ClientID%>").value = "3";
                                document.getElementById("<%=ddlEmp8.ClientID%>").disabled = "true";
                                document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = "true";
                                document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = "true";
                                document.getElementById('AirFinish2').disabled = "true";
                                document.getElementById('AirClose2').disabled = "true";
                            }
                            else {
                                alert("Sorry.It is already finished");
                                document.getElementById('AirFinish2').style.pointerEvents = "";
                                document.getElementById('AirFinish2').style.opacity = "1";
                            }

                          
                        }
                        if (Type == "AirPick") {
                            // FinishProcess2('AirPick');
                            document.getElementById("<%=HiddenPrtclrChk.ClientID%>").value = "3";
                            document.getElementById("<%=ddlEmp8.ClientID%>").disabled = "true";
                            document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = "true";
                            document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = "true";
                            document.getElementById('AirFinish2').disabled = "true";
                            document.getElementById('AirClose2').disabled = "true";
                            if (response[1] == 1) {
                                alert("Sorry.It is already closed");
                                document.getElementById('AirRecall2').style.display = "block";
                                document.getElementById('AirClose2').style.display = "none";

                                document.getElementById("<%=ddlEmp7.ClientID%>").disabled = "true";
                                document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = "true";
                                document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = "true";
                                document.getElementById('roomFinish2').disabled = "true";
                                document.getElementById('RoomClose2').disabled = "true";
                                document.getElementById("<%=HiddenPrtclrChk.ClientID%>").value = "3";
                                document.getElementById("<%=ddlEmp8.ClientID%>").disabled = "true";
                                document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = "true";
                                document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = "true";
                                document.getElementById('AirFinish2').disabled = "true";
                                document.getElementById('AirClose2').disabled = "true";
                            }
                            else {
                                alert("Sorry.It is already finished");
                            }

                        }

                    }


                });
                return false;

            }
          function FinishProcess2MulBrwserChk(Type) {
              var CandId= document.getElementById("<%=hiddenCandidateId.ClientID%>").value  ;
              var LeavId=  document.getElementById("<%=HiddenUpdLevid.ClientID%>").value ;
              var typename;
              if (Type == "Flight") {
                  typename = 0;
                                  }
                if (Type == "Room") {
                    typename = 2;
                   
                }
                if (Type == "AirPick") {
                    typename = 3;
                  
                }
              
                var Details = PageMethods.CheckStatusBefrEdit(typename, CandId, LeavId, function (response) {
                   
                    var SucessDetails = response;
                    if (response[0] == 0 && response[1] == 0) {
                        if (Type == "Flight") {
                            FinishProcess2('Flight');
                        }
                        if (Type == "Room") {
                            FinishProcess2('Room');

                        }
                        if (Type == "AirPick") {
                            FinishProcess2('AirPick');

                        }

                    }
                    else {
                        if (Type == "Flight") {
                            
                            document.getElementById("<%=HiddenPrtclrChk.ClientID%>").value = "0";
                            document.getElementById("<%=ddlEmp6.ClientID%>").disabled = "true";
                            document.getElementById("<%=ddlFlightStatus2.ClientID%>").disabled = "true";
                            document.getElementById("<%=txtTargetDate6.ClientID%>").disabled = "true";
                            document.getElementById('FliFinish2').disabled = "true";
                            document.getElementById('FliClose2').disabled = "true";
                            if (response[1] == 1) {
                                alert("Sorry.It is already closed");
                                document.getElementById('FliRecall2').style.display = "block";
                                document.getElementById('FliClose2').style.display = "none";

                                document.getElementById("<%=ddlEmp7.ClientID%>").disabled = "true";
                                document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = "true";
                                document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = "true";
                                document.getElementById('roomFinish2').disabled = "true";
                                document.getElementById('RoomClose2').disabled = "true";
                                document.getElementById("<%=HiddenPrtclrChk.ClientID%>").value = "3";
                                document.getElementById("<%=ddlEmp8.ClientID%>").disabled = "true";
                                document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = "true";
                                document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = "true";
                                document.getElementById('AirFinish2').disabled = "true";
                                document.getElementById('AirClose2').disabled = "true";
                            }
                            else {
                                alert("Sorry.It is already finished");
                                document.getElementById('roomFinish2').style.pointerEvents = "";
                                document.getElementById('roomFinish2').style.opacity = "1";
                            }
                            
                         
                        }
                        if (Type == "Room") {
                           // document.getElementById('trSettlmnt1').disabled = "true";
                            document.getElementById("<%=HiddenPrtclrChk.ClientID%>").value = "2";
                            document.getElementById("<%=ddlEmp7.ClientID%>").disabled = "true";
                            document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = "true";
                            document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = "true";
                            document.getElementById('roomFinish2').disabled = "true";
                            document.getElementById('RoomClose2').disabled = "true";
                            if (response[1] == 1) {
                                alert("Sorry.It is already closed");
                                document.getElementById('RoomRecall2').style.display = "block";
                                document.getElementById('RoomClose2').style.display = "none";


                                document.getElementById("<%=ddlEmp7.ClientID%>").disabled = "true";
                                document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = "true";
                                document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = "true";
                                document.getElementById('roomFinish2').disabled = "true";
                                document.getElementById('RoomClose2').disabled = "true";
                                document.getElementById("<%=HiddenPrtclrChk1.ClientID%>").value = "2";
                                document.getElementById("<%=HiddenPrtclrChk.ClientID%>").value = "3";
                                document.getElementById("<%=ddlEmp8.ClientID%>").disabled = "true";
                                document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = "true";
                                document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = "true";
                                document.getElementById('AirFinish2').disabled = "true";
                                document.getElementById('AirClose2').disabled = "true";
                            }
                            else {
                                alert("Sorry.It is already finished");
                                document.getElementById('AirFinish2').style.pointerEvents = "";
                                document.getElementById('AirFinish2').style.opacity = "1";
                            }

                        }
                        if (Type == "AirPick") {
                           // FinishProcess2('AirPick');
                            document.getElementById("<%=HiddenPrtclrChk.ClientID%>").value = "3";
                            document.getElementById("<%=ddlEmp8.ClientID%>").disabled = "true";
                            document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = "true";
                            document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = "true";
                            document.getElementById('AirFinish2').disabled = "true";
                            document.getElementById('AirClose2').disabled = "true";
                            if (response[1] == 1) {
                                alert("Sorry.It is already closed");
                                document.getElementById('AirRecall2').style.display = "block";
                                document.getElementById('AirClose2').style.display = "none";

                                document.getElementById("<%=ddlEmp7.ClientID%>").disabled = "true";
                                document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = "true";
                                document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = "true";
                                document.getElementById('roomFinish2').disabled = "true";
                                document.getElementById('RoomClose2').disabled = "true";
                                document.getElementById("<%=HiddenPrtclrChk.ClientID%>").value = "3";
                                document.getElementById("<%=ddlEmp8.ClientID%>").disabled = "true";
                                document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = "true";
                                document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = "true";
                                document.getElementById('AirFinish2').disabled = "true";
                                document.getElementById('AirClose2').disabled = "true";
                            }
                            else {

                                alert("Sorry.It is already finished");
                            }

                        }

                    }

                   
                });
                return false;
              
            }
         
        

          function FinishProcess2(Type) {
              var TypePass = Type;
              if (confirm("Are you sure? You want to finish this task.")) {
                  var TypeTotal = document.getElementById("<%=hiddenFinishStatus.ClientID%>").value;

          

                if (Type == "Flight") {

                    Type = Type ;
                    if ( document.getElementById("<%=txtTargetDate6.ClientID%>").value != "") {
                        document.getElementById("<%=txtTargetDate6.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=ddlEmp6.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlFlightStatus2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate6.ClientID%>").disabled = true;
                    } else {
                        document.getElementById("<%=txtTargetDate6.ClientID%>").style.borderColor = "red";
                        return false;
                    }
                }
                if (Type == "Room") {
                    Type = Type +  "," + "Flight2";
                    if (document.getElementById("<%=txtTargetDate7.ClientID%>").value != "") {
                        document.getElementById("<%=txtTargetDate7.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=ddlEmp7.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = true;
                    } else {
                        document.getElementById("<%=txtTargetDate7.ClientID%>").style.borderColor = "red";
                        return false;
                    }
                }
                if (Type == "AirPick") {
                    Type = Type + "," + "Flight2" + "," + "Room2";
                    if ( document.getElementById("<%=txtTargetDate8.ClientID%>").value != "") {
                        document.getElementById("<%=txtTargetDate8.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=ddlEmp8.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = true;
                    } else {
                        document.getElementById("<%=txtTargetDate8.ClientID%>").style.borderColor = "red";
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

        function CloseProcess2(Type) {
          
            if (confirm("Are you sure? You want to close this task.")) {
                var TypeTotal = document.getElementById("<%=hiddenCloseStatus.ClientID%>").value;

            
                if (Type == "Flight") {
                    if ( document.getElementById("<%=txtTargetDate6.ClientID%>").value != "") {
                        document.getElementById("<%=txtTargetDate6.ClientID%>").style.borderColor = "";
                          document.getElementById("<%=ddlEmp6.ClientID%>").disabled = true;
                          document.getElementById("<%=ddlFlightStatus2.ClientID%>").disabled = true;
                          document.getElementById("<%=txtTargetDate6.ClientID%>").disabled = true;

                        
                          document.getElementById("<%=ddlEmp7.ClientID%>").disabled = true;
                          document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = true;
                          document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = true;

                       
                          document.getElementById("<%=ddlEmp8.ClientID%>").disabled = true;
                          document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = true;
                          document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = true;

                          document.getElementById('FliClose2').style.pointerEvents = "none";
                          document.getElementById('FliClose2').style.opacity = ".5";
                          document.getElementById('RoomClose2').style.pointerEvents = "none";
                          document.getElementById('RoomClose2').style.opacity = ".5";
                          document.getElementById('AirClose2').style.pointerEvents = "none";
                          document.getElementById('AirClose2').style.opacity = ".5";


                          document.getElementById('FliFinish2').style.pointerEvents = "none";
                          document.getElementById('FliFinish2').style.opacity = ".5";
                          document.getElementById('roomFinish2').style.pointerEvents = "none";
                          document.getElementById('roomFinish2').style.opacity = ".5";
                          document.getElementById('AirFinish2').style.pointerEvents = "none";
                          document.getElementById('AirFinish2').style.opacity = ".5";

                    } else {
                        document.getElementById("<%=txtTargetDate6.ClientID%>").style.borderColor = "red";
                          return false;
                      }
                  }
                  if (Type == "Room") {
                      if ( document.getElementById("<%=txtTargetDate7.ClientID%>").value != "") {
                          document.getElementById("<%=txtTargetDate7.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=ddlEmp7.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = true;

                      
                        document.getElementById("<%=ddlEmp8.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = true;

                        document.getElementById('RoomClose2').style.pointerEvents = "none";
                        document.getElementById('RoomClose2').style.opacity = ".5";
                        document.getElementById('AirClose2').style.pointerEvents = "none";
                        document.getElementById('AirClose2').style.opacity = ".5";

                        document.getElementById('roomFinish2').style.pointerEvents = "none";
                        document.getElementById('roomFinish2').style.opacity = ".5";
                        document.getElementById('AirFinish2').style.pointerEvents = "none";
                        document.getElementById('AirFinish2').style.opacity = ".5";
                      } else {
                          document.getElementById("<%=txtTargetDate7.ClientID%>").style.borderColor = "red";
                        return false;
                    }
                }
                if (Type == "AirPick") {
                    if ( document.getElementById("<%=txtTargetDate8.ClientID%>").value != "") {
                        document.getElementById("<%=txtTargetDate8.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=ddlEmp8.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = true;

                        document.getElementById('AirClose2').style.pointerEvents = "none";
                        document.getElementById('AirClose2').style.opacity = ".5";
                        document.getElementById('AirFinish2').style.pointerEvents = "none";
                        document.getElementById('AirFinish2').style.opacity = ".5";
                    } else {

                        document.getElementById("<%=txtTargetDate8.ClientID%>").style.borderColor = "red";
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
             
                 if (Type == "Flight2") {
                    DetailId = document.getElementById("<%=hiddenOnBoardDtlId2.ClientID%>").value;
                }
                else if (Type == "Room2") {
                    DetailId = document.getElementById("<%=hiddenOnBoardDtlId3.ClientID%>").value;
                }
                else if (Type == "AirPick2") {
                    DetailId = document.getElementById("<%=hiddenOnBoardDtlId4.ClientID%>").value;
                }


    $.ajax({
        type: "POST",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "hcm_LeaveFacltyAssmntList.aspx/RecallProcess",
        data: '{ProcessDetailId: "' + DetailId + '"}',
        dataType: "json",
        success: function (data) {

            if (data.d == "true") {
                 window.location.href = "hcm_LeaveFacltyAssmntList.aspx?InsUpd=Rcl";

            }
        }
    });
}
else {

            }
         


}



function DisableButton1(type) {
    if (type == "Visa2") {
       
        document.getElementById('roomFinish').disabled = true;
        document.getElementById('roomFinish').style.opacity = ".5";
        document.getElementById('AirFinish').disabled = true;
        document.getElementById('AirFinish').style.opacity = ".5";
        document.getElementById('FliFinish').disabled = false;
        document.getElementById('FliFinish').style.opacity = "1";
        document.getElementById('VisaClose2').disabled = true;
        document.getElementById('VisaClose2').style.opacity = ".5";

    }
    if (type == "Flight2") {
       
        document.getElementById('roomFinish').disabled = false;
        document.getElementById('roomFinish').style.opacity = "1";
        document.getElementById('AirFinish').disabled = true;
        document.getElementById('AirFinish').style.opacity = ".5";
        document.getElementById('FliFinish').disabled = true;
        document.getElementById('FliFinish').style.opacity = ".5";

       
        document.getElementById('FliClose2').disabled = true;
        document.getElementById('FliClose2').style.opacity = ".5";
    }
    if (type == "Room2") {
      
        document.getElementById('roomFinish').disabled = true;
        document.getElementById('roomFinish').style.opacity = ".5";
        document.getElementById('AirFinish').disabled = false;
        document.getElementById('AirFinish').style.opacity = "1";
        document.getElementById('FliFinish').disabled = true;
        document.getElementById('FliFinish').style.opacity = ".5";

        document.getElementById('VisaClose2').disabled = true;
        document.getElementById('VisaClose2').style.opacity = ".5";
        document.getElementById('FliClose2').disabled = true;
        document.getElementById('FliClose2').style.opacity = ".5";
        document.getElementById('RoomClose2').disabled = true;
        document.getElementById('RoomClose2').style.opacity = ".5";
    }
    if (type == "AirPick2") {
       
        document.getElementById('roomFinish').disabled = true;
        document.getElementById('roomFinish').style.opacity = ".5";
        document.getElementById('AirFinish').disabled = true;
        document.getElementById('AirFinish').style.opacity = ".5";
        document.getElementById('FliFinish').disabled = true;
        document.getElementById('FliFinish').style.opacity = ".5";

       
        document.getElementById('FliClose2').disabled = true;
        document.getElementById('FliClose2').style.opacity = ".5";
        document.getElementById('RoomClose2').disabled = true;
        document.getElementById('RoomClose2').style.opacity = ".5";
        document.getElementById('AirClose2').disabled = true;
        document.getElementById('AirClose2').style.opacity = ".5";
    }

}
function FinishProcess(Type) {
    return false;
    if (confirm("Are you sure? You want to finish this task.")) {
        var TypeTotal = document.getElementById("<%=hiddenFinishStatus.ClientID%>").value;

       

                   if (Type == "Flight") {
                     
                    document.getElementById("<%=ddlEmp2.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlFlightStatus.ClientID%>").disabled = true;
                    document.getElementById("<%=txtTargetDate2.ClientID%>").disabled = true;
                }
                if (Type == "Room") {
                 
                    document.getElementById("<%=ddlEmp3.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = true;
                    document.getElementById("<%=txtTargetDate3.ClientID%>").disabled = true;
                }
                if (Type == "AirPick") {
                  
                    document.getElementById("<%=ddlEmp4.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = true;
                    document.getElementById("<%=txtTargetDate4.ClientID%>").disabled = true;
                }




                TypeTotal = TypeTotal + "," + Type;
                document.getElementById("<%=hiddenFinishStatus.ClientID%>").value = TypeTotal;

                DisableButton1(Type);
            }
            else {

            }
        }

        function CloseProcess(Type) {
        }
        var $NonCon = jQuery.noConflict();
        function ProcessEdit(CandId, FlightChk, LeavId, staffworker) {



            document.getElementById("<%=ddlEmp1.ClientID%>").disabled = true;
            document.getElementById("<%=ddlVisaStatus.ClientID%>").disabled = true;
            document.getElementById("<%=txtTargetDate1.ClientID%>").disabled = true;
            document.getElementById("<%=ddlClear.ClientID%>").disabled = true;
            document.getElementById("<%=DropDownList2.ClientID%>").disabled = true;
            document.getElementById("<%=TextBox1.ClientID%>").disabled = true;
            document.getElementById('VisaFinish').style.opacity = ".5";
            document.getElementById('VisaClose').style.opacity = ".5";
            document.getElementById('A1').style.opacity = ".5";
            document.getElementById('A2').style.opacity = ".5";




            document.getElementById("<%=btnProcessSingleSave.ClientID%>").style.display = "block";
            document.getElementById("<%=hiddenCandidateId.ClientID%>").value = CandId;
            document.getElementById("<%=HiddenUpdFlghtChk.ClientID%>").value = FlightChk;
            document.getElementById("<%=HiddenUpdLevid.ClientID%>").value = LeavId;






            if (staffworker != "") {
               
                document.getElementById("<%=DropDownList2.ClientID%>").value = staffworker;
            }
       
            document.getElementById("MymodalProcessSingle").style.display = "block";
            document.getElementById("freezelayer").style.display = "";
            $NonCon.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_LeaveFacltyAssmntList.aspx/ReadCandidateData",
                data: '{intCandId: "' + CandId + '"}',
                dataType: "json",
                success: function (data) {
                  
                    document.getElementById("<%=lblName.ClientID%>").innerText = data.d.empdatails[0];
                    document.getElementById("<%=lblDesg.ClientID%>").innerText = data.d.empdatails[1];
                    document.getElementById("<%=lblDiv.ClientID%>").innerText = data.d.empdivision;
                    document.getElementById("<%=lblDep.ClientID%>").innerText = data.d.empdatails[2];
                    document.getElementById("<%=lblNationality.ClientID%>").innerText = data.d.empdatails[3];
                    document.getElementById("<%=lblMode.ClientID%>").innerText = data.d.empdatails[4];


                }
            });
            if (FlightChk == "0") {
                document.getElementById('trFlight1').style.display = "none";
                document.getElementById('SlCler1').innerHTML = "1";
                document.getElementById('slSetl1').innerHTML = "2";
                document.getElementById('SlExit1').innerHTML = "3";
              

                document.getElementById('roomFinish2').style.pointerEvents = "";
                document.getElementById('roomFinish2').style.opacity = "1";
                document.getElementById('AirFinish2').style.pointerEvents = "none";
                document.getElementById('AirFinish2').style.opacity = ".5";
                document.getElementById('AirClose2').style.pointerEvents = "none";
                document.getElementById('AirClose2').style.opacity = ".5";

               // DisableButton2("Flight");
            }
            if (FlightChk=="1")
                {
                $NonCon.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "hcm_LeaveFacltyAssmntList.aspx/ReadFlightData",
                    data: '{intCandId: "' + CandId + '",intLevid:"' + LeavId + '"}',
                    dataType: "json",
                    success: function (data) {
                        document.getElementById("<%=hiddenOnBoardDtlId2.ClientID%>").value = data.d[0];
                        document.getElementById("<%=ddlFlightStatus2.ClientID%>").value = data.d[1];
                        document.getElementById("<%=txtTargetDate6.ClientID%>").value = data.d[2];
                
                        if (data.d[3] == "1") {
                            document.getElementById("<%=hiddenFinishStatus.ClientID%>").value = document.getElementById("<%=hiddenFinishStatus.ClientID%>").value + "," + "Flight2";
                      
                            document.getElementById("<%=ddlEmp6.ClientID%>").disabled = true;
                            document.getElementById("<%=ddlFlightStatus2.ClientID%>").disabled = true;
                            document.getElementById("<%=txtTargetDate6.ClientID%>").disabled = true;

                            DisableButton2("Flight");
                        }
                        else {
                       
                            document.getElementById('roomFinish2').style.pointerEvents = "none";
                            document.getElementById('roomFinish2').style.opacity = ".5";
                            document.getElementById('AirFinish2').style.pointerEvents = "none";
                            document.getElementById('AirFinish2').style.opacity = ".5";
                            document.getElementById('FliFinish2').style.pointerEvents = "";
                            document.getElementById('FliFinish2').style.opacity = "1";
                        }
                        if (data.d[4] == "1") {
                            document.getElementById("<%=hiddenCloseStatus.ClientID%>").value = document.getElementById("<%=hiddenCloseStatus.ClientID%>").value + "," + "Flight2";
                            document.getElementById('FliClose2').style.display = "none";
                            document.getElementById('FliRecall2').style.display = "";

                    
                            document.getElementById("<%=ddlEmp6.ClientID%>").disabled = true;
                            document.getElementById("<%=ddlFlightStatus2.ClientID%>").disabled = true;
                            document.getElementById("<%=txtTargetDate6.ClientID%>").disabled = true;

                      
                            document.getElementById("<%=ddlEmp7.ClientID%>").disabled = true;
                            document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = true;
                            document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = true;

                    
                            document.getElementById("<%=ddlEmp8.ClientID%>").disabled = true;
                            document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = true;
                            document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = true;


                            document.getElementById('FliClose2').style.pointerEvents = "none";
                            document.getElementById('FliClose2').style.opacity = ".5";
                            document.getElementById('RoomClose2').style.pointerEvents = "none";
                            document.getElementById('RoomClose2').style.opacity = ".5";
                            document.getElementById('AirClose2').style.pointerEvents = "none";
                            document.getElementById('AirClose2').style.opacity = ".5";

                            document.getElementById('FliFinish2').style.pointerEvents = "none";
                            document.getElementById('FliFinish2').style.opacity = ".5";
                            document.getElementById('roomFinish2').style.pointerEvents = "none";
                            document.getElementById('roomFinish2').style.opacity = ".5";
                            document.getElementById('AirFinish2').style.pointerEvents = "none";
                            document.getElementById('AirFinish2').style.opacity = ".5";


                        }
                        var totalString = data.d[5];
                        eachString = totalString.split(',');
                        var newVar = new Array();
                        for (count = 0; count < eachString.length; count++) {
                            if (eachString[count] != "") {
                                newVar.push(eachString[count]);
                            }
                        }

                        $noC('#cphMain_ddlEmp6').val(newVar);
                        $noC("#cphMain_ddlEmp6").trigger("change");
                    }
                });
        }
            $NonCon.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_LeaveFacltyAssmntList.aspx/ReadRoomData",
                data: '{intCandId: "' + CandId + '",intLevid:"' + LeavId + '"}',
                dataType: "json",
                success: function (data) {
                    document.getElementById("<%=hiddenOnBoardDtlId3.ClientID%>").value = data.d[0];
                  
                    document.getElementById("<%=ddlSettlment7.ClientID%>").value = data.d[1];
                    document.getElementById("<%=txtTargetDate7.ClientID%>").value = data.d[2];
                 

                    if (data.d[3] == "1") {
                        document.getElementById("<%=hiddenFinishStatus.ClientID%>").value = document.getElementById("<%=hiddenFinishStatus.ClientID%>").value + "," + "Room2";
                    
                        document.getElementById("<%=ddlEmp7.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = true;

                        DisableButton2("Room");
                    }
                    if (data.d[4] == "1") {
                        document.getElementById("<%=hiddenCloseStatus.ClientID%>").value = document.getElementById("<%=hiddenCloseStatus.ClientID%>").value + "," + "Room2";
                        document.getElementById('RoomClose2').style.display = "none";
                        document.getElementById('RoomRecall2').style.display = "";

                    
                        document.getElementById("<%=ddlEmp7.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlSettlment7.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate7.ClientID%>").disabled = true;

                      
                        document.getElementById("<%=ddlEmp8.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = true;


                        document.getElementById('RoomClose2').style.pointerEvents = "none";
                        document.getElementById('RoomClose2').style.opacity = ".5";
                        document.getElementById('AirClose2').style.pointerEvents = "none";
                        document.getElementById('AirClose2').style.opacity = ".5";

                        document.getElementById('roomFinish2').style.pointerEvents = "none";
                        document.getElementById('roomFinish2').style.opacity = ".5";
                        document.getElementById('AirFinish2').style.pointerEvents = "none";
                        document.getElementById('AirFinish2').style.opacity = ".5";


                    }
                    var totalString = data.d[5];
                    eachString = totalString.split(',');

                    PassingString = "";
                    var newVar = new Array();
                    for (count = 0; count < eachString.length; count++) {
                        if (eachString[count] != "") {
                            newVar.push(eachString[count]);
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
                url: "hcm_LeaveFacltyAssmntList.aspx/ReadAirData",
                data: '{intCandId: "' + CandId + '",intLevid:"' + LeavId + '"}',
                dataType: "json",
                success: function (data) {
                  
                    document.getElementById("<%=hiddenOnBoardDtlId4.ClientID%>").value = data.d[0];
                    document.getElementById("<%=ddlExitprcss8.ClientID%>").value = data.d[1];
                    document.getElementById("<%=txtTargetDate8.ClientID%>").value = data.d[2];

                    if (data.d[3] == "1") {
                        document.getElementById("<%=hiddenFinishStatus.ClientID%>").value = document.getElementById("<%=hiddenFinishStatus.ClientID%>").value + "," + "AirPick2";
                      
                        document.getElementById("<%=ddlEmp8.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = true;
                        document.getElementById("<%=btnProcessSingleSave.ClientID%>").style.display = "none";
                      
                        DisableButton2("AirPick");
                    }
                    if (data.d[4] == "1") {
                        document.getElementById("<%=hiddenCloseStatus.ClientID%>").value = document.getElementById("<%=hiddenCloseStatus.ClientID%>").value + "," + "AirPick2";
                        document.getElementById('AirClose2').style.display = "none";
                        document.getElementById('AirRecall2').style.display = "";

                     
                        document.getElementById("<%=ddlEmp8.ClientID%>").disabled = true;
                        document.getElementById("<%=ddlExitprcss8.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTargetDate8.ClientID%>").disabled = true;

                        document.getElementById('AirClose2').style.pointerEvents = "none";
                        document.getElementById('AirClose2').style.opacity = ".5";

                        document.getElementById('AirFinish2').style.pointerEvents = "none";
                        document.getElementById('AirFinish2').style.opacity = ".5";


                    }
                

                    var totalString = data.d[5];
                    eachString = totalString.split(',');

                    PassingString = "";
                    var newVar = new Array();
                    for (count = 0; count < eachString.length; count++) {
                        if (eachString[count] != "") {
                            newVar.push(eachString[count]);
                        }
                    }

                    $noC('#cphMain_ddlEmp8').val(newVar);
                    $noC("#cphMain_ddlEmp8").trigger("change");
                }
            });

        }

        function ConfirmCancel() {
            if (confirm("Are you sure? Do you want to cancel")) {

                window.location.href = "hcm_LeaveFacltyAssmntList.aspx";
            }
        }
        function ConfirmClose() {
            if (confirm("Are you sure? Do you want to close")) {

                window.location.href = "hcm_LeaveFacltyAssmntList.aspx";
            }
        }
        function ConfirmCloseSingle() {
            if (confirm("Are you sure? Do you want to close")) {

                window.location.href = 'hcm_LeaveFacltyAssmntList.aspx?InsUpd=Cls';
            }
        }
        

        function DateChkSearch() {

            if (document.getElementById("<%=txtLeavRangeFrm.ClientID%>").value != "" && document.getElementById("<%=txtLeavRangeTo.ClientID%>").value != "") {
                var datepickerDate = document.getElementById("<%=txtLeavRangeFrm.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var datepickerDate = document.getElementById("<%=txtLeavRangeTo.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                if (dateTxIss >= dateCompExp) {
                    document.getElementById("<%=txtLeavRangeTo.ClientID%>").value = "";
                       alert("Sorry, to date should be greater than from date !");
                   }
               }
               return false;

           }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>


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
    <asp:HiddenField ID="HiddenSearchField" runat="server" />
     <asp:HiddenField ID="HiddenLeavId" runat="server" />
     <asp:HiddenField ID="HiddenAirLine" runat="server" />
     <asp:HiddenField ID="HiddenAirlineneed" runat="server" />
      <asp:HiddenField ID="HiddenAirlinNoteneed" runat="server" />
        <asp:HiddenField ID="HiddenUpdLevid" runat="server" />
        <asp:HiddenField ID="HiddenUpdFlghtChk" runat="server" />
      <asp:HiddenField ID="HiddenPrtclrChk" runat="server" />
       <asp:HiddenField ID="HiddenUpdateChk" runat="server" />
     <asp:HiddenField ID="HiddenPrtclrChk1" runat="server" />
     <asp:HiddenField ID="HiddenAdd" runat="server" />
     <asp:HiddenField ID="HiddenEdit" runat="server" />
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">






        <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
            <img src="../../../../Images/BigIcons/Leave_Facility_Assignment.PNG" />
             <asp:Label ID="lblEntry" runat="server">Leave Facility Assignment List</asp:Label>
        </div>
        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left">


            <div style="float: left; width: 100%; margin-top: 1%">
                <div style="width: 32%; float: left; padding: 5px; border: 1px solid #c3c3c3;">
                    <h2>Leave Assignment* :</h2>
                    <div style="float: right; margin-right: 0%; width: 55%;">
                        <asp:RadioButton ID="radioAssigned" Text="Assigned" runat="server" Checked="true" GroupName="RadioSkCer" Style="float: left; font-family: calibri" />
                        <asp:RadioButton ID="radioNotAssigned" Text="Not Assigned" runat="server" GroupName="RadioSkCer" Style="float: left; font-family: calibri; margin-left: 6%;" />
                    </div>
                </div>

                <div style="width: 61%; float: left; padding: 5px; margin-left: 4%;">
                    <h2>Employee : </h2>

                    <asp:DropDownList ID="ddlEmploy" class="form1" onkeydown="ImagePosition('cphMain_ddlEmploy')" runat="server" Style="height: 30px; width: 32.5%; float: left; margin-left: 5%;">
                    </asp:DropDownList>

                  

                </div>
                   <div style="width: 32%; float: left; padding: 5px; border: 1px solid #c3c3c3;">
                    <h2>Mode* :</h2>
                    <div style="float: right; margin-right: 0%; width: 55%;">
                        <asp:RadioButton ID="RadioStaff" Text="Staff" runat="server" Checked="true" GroupName="RadioMode" Style="float: left; font-family: calibri" />
                        <asp:RadioButton ID="RadioWorker" Text="Worker" runat="server" GroupName="RadioMode" Style="float: left; font-family: calibri; margin-left: 9.5%;" />
                        <asp:RadioButton ID="RadioAll" Text="All" runat="server" GroupName="RadioMode" Style="float: left; font-family: calibri; margin-left: 9.5%;" />
                    </div>
                </div>
                  <div style="width: 61%; float: left; padding: 5px; margin-left: 4%;">
                    <h2>Leave Range : </h2>

                    <asp:TextBox ID="txtLeavRangeFrm" placeholder="dd/mm/yyyy"  class="form1" runat="server" onblur="DateChkSearch()" MaxLength="12" Style="text-transform: uppercase;width: 12.8%; text-align:left;  height: 30px;float: left;margin-left: 2.1%;" ></asp:TextBox>
                   <h2 style="margin-left: 1%;float: left;">To</h2>
                  <asp:TextBox ID="txtLeavRangeTo"  placeholder="dd/mm/yyyy"  class="form1" onblur="DateChkSearch()" runat="server" MaxLength="12" Style="text-transform: uppercase;width: 12.8%;text-align:left;  height: 30px;float: left;margin-left: 1%;" ></asp:TextBox>
 <asp:Button ID="btnSearch" Style="cursor: pointer; margin-left: 10%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
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
                <label style="color: red; font-family: calibri;">Please select atleast one employee</label>
            </div>
            <input type="button" id="btnOnBoard" runat="server" style="width: 114px; float: left; margin-left: 0.5%; margin-top: 0%; background: #127c8f; border: 2px solid #b12709;" class="save" value="Assign" onclick="ShowProcess_Multy()" />

        </div>

    </div>

    <%-- ----------------for On boarding process multiple//-----%>

    <div>
        <div id="MyModalProcessMultiple" class="MyModalProcessMultiple" style="height:400px;">
            <div id="divJbFull">
                <div id="DivEmpHeader" style="height: 30px; background-color: #6f7b5a;">

                    <label style="margin-left: 38%; font-size: 18px; color: #fff; font-family: calibri;">Leave Facility Assignment</label>
                    
                  <%--  CloseProcessMulty()--%>
                    <img class="closeCancelView" style="margin-top: .5%; margin-right: 1%; float: right; cursor: pointer;" onclick="ConfirmClose();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                </div>
                <div style="float: left; margin: 13px; border: 1px solid; border-color: #d7c9c9; background-color: #fff; margin-bottom: 6px; width: 97%;">
                    <div id="JbShdlTop" style="width: 100%; float: left; margin-top: 1%;">
                        <h2 style="margin-left: 2%; width: 23%; float: left;">No.of selected persons : 
                        </h2>
                        <label id="lblNoOfselectedEmp" style="float: left; color: #042f95; font-family: calibri; width: 10%; cursor: inherit"></label>
                    </div>



                    <div id="divSheduleContainer" style="float: left; width: 100%;">
                        <div id="divErrorNotificationPrcsMlty" style="visibility: hidden">
                            <asp:Label ID="lblErrorNotificationPrcsMlty" runat="server"></asp:Label>
                        </div>
                        <div id="divTableProcessMlty" style="width: 98%; margin: 1%; padding-top: 0.6%; height: 250px;">

                            <table class="TableHeaderProcess" rules="all" style="width: 96%; margin-left: 2%; font-family: calibri;">
                                <tbody>
                                    <tr>
                                        <td style="font-size: 14px; width: 4.2%; padding-left: 0.5%; text-align: center;">Sl#</td>
                                        <td style="font-size: 14px; width: 15%; padding-left: 0.5%; text-align: left;">Particulars</td>
                                       <%-- <td style="font-size: 14px; width: 15.2%; padding-left: 0.5%; text-align: left;">Category</td>--%>
                                        <td style="font-size: 14px; width: 60.1%; padding-left: 0.5%; text-align: left;">Employee</td>
                                        <td style="font-size: 14px; width: 11.1%; padding-left: 0.5%; text-align: center;">Status</td>
                                        <td style="font-size: 14px; width: 10.1%; padding-left: 0.5%; text-align: center;">Target</td>
                                        <td style="display:none; font-size: 14px; width: 5.2%; padding-left: 0.5%; text-align: center;">Finish</td>
                                        <td style="display:none;font-size: 14px; width: 5.2%; padding-left: 0.5%; text-align: center;">Close</td>
                                    </tr>
                                </tbody>
                            </table>
                            <table id="tblOnBoardMult" style="width: 96%; margin-left: 2%; font-family: calibri; background-color: #f6f6f6;">

                                <tbody>

                                                    <tr id="trFlight" >
                                        <td id="SlFlight" style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">1</td>
                                        <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Flight Ticket</td>
                                     <%--   <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlFlightTcktType" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">

                                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="1">ECONOMY CLASS</asp:ListItem>
                                                <asp:ListItem Value="2">BUSSINESS CLASS</asp:ListItem>
                                                <asp:ListItem Value="3">FIRST CLASS</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>--%>
                                        <td style="width: 60%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
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
                                            <asp:TextBox ID="txtTargetDate2" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;"></asp:TextBox>
                                        </td>
                                        <td style="display:none;width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="FliFinish" class="tooltip" title="Finish" onclick="return FinishProcess('Flight');">
                                                <img style="cursor: pointer; margin-left: 25%; opacity: 1;" src='/Images/Icons/success.png' /></a>
                                        </td>
                                        <td style="display:none;width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="FliClose" class="tooltip" title="Close" onclick="return CloseProcess('Flight');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/close.png' /></a>
                                        </td>
                                    </tr>
                                    <tr class="disabledtr">
                                        <td id="SlCler" style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">2</td>
                                        <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Clearance</td>
                                      <%--  <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlVisaType" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>

                                        </td>--%>
                                        <td style="width: 60%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp1" disabled="disabled"  data-placeholder="select employee" multiple="mutiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">

                                            <asp:DropDownList ID="ddlVisaStatus" disabled="disabled" class="form1" runat="server" Style="background-color: #ebebe4;height: 27px; width: 100%; float: left;">


                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                               
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate1" disabled="disabled" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;"></asp:TextBox>
                                        </td>
                                        <td style="display:none;width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="VisaFinish"  class="tooltip" title="Finish" onclick="return FinishProcess('Visa');">
                                                <img style="cursor: pointer; margin-left: 25%; opacity: 1;" src='/Images/Icons/success.png' /></a>
                                        </td>
                                        <td style="display:none;width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="VisaClose"  class="tooltip" title="Close" onclick="return CloseProcess('Visa');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/close.png' /></a>
                                        </td>
                                    </tr>
                    
                                    <tr>
                                        <td  id="slSetl" style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">3</td>
                                        <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Settlement</td>
                                       <%-- <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlRoomAltmntType" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">
                                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="1">BED SPACE</asp:ListItem>
                                                <asp:ListItem Value="2">1BHK</asp:ListItem>
                                                <asp:ListItem Value="3">2BHK</asp:ListItem>
                                                <asp:ListItem Value="4">3BHK</asp:ListItem>
                                                <asp:ListItem Value="5">VILLA</asp:ListItem>
                                                <asp:ListItem Value="6">FLAT</asp:ListItem>
                                            </asp:DropDownList>

                                        </td>--%>
                                        <td style="width: 60%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp3" data-placeholder="select employee" multiple="multiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlSettlment" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">

                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                                <asp:ListItem Value="1">Pending</asp:ListItem>
                                                <asp:ListItem Value="2">Success</asp:ListItem>
                                                <asp:ListItem Value="3">Failed</asp:ListItem>
                                              <%--  <asp:ListItem Value="4">Closed Without Allotment</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate3" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;"></asp:TextBox>
                                        </td>
                                        <td style="display:none;width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="roomFinish" class="tooltip" title="Finish" onclick="return FinishProcess('Room');">
                                                <img style="cursor: pointer; margin-left: 25%; opacity: 1;" src='/Images/Icons/success.png' /></a>
                                        </td>
                                        <td style="display:none;width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="RoomClose" class="tooltip" title="Close" onclick="return CloseProcess('Room');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/close.png' /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="SlExit" style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">4</td>
                                        <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Exit process</td>
                                       <%-- <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                          
                                        </td>--%>
                                        <td style="width: 60%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp4" data-placeholder="select employee" multiple="multiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                             <asp:DropDownList ID="ddlExitprcss" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">

                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                                <asp:ListItem Value="1">Applied</asp:ListItem>
                                                <asp:ListItem Value="2">Approved</asp:ListItem>
                                                <asp:ListItem Value="3">Rejected</asp:ListItem>
                                              <%--  <asp:ListItem Value="4">Closed Without Allotment</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate4" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;"></asp:TextBox>
                                        </td>
                                        <td style="display:none;width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="AirFinish" class="tooltip" title="Finish" onclick="return FinishProcess('AirPick');">
                                                <img style="cursor: pointer; margin-left: 25%; opacity: 1;" src='/Images/Icons/success.png' /></a>
                                        </td>
                                        <td style="display:none;width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="AirClose" class="tooltip" title="Close" onclick="return CloseProcess('AirPick');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/close.png' /></a>
                                        </td>
                                    </tr>
                                </tbody>

                            </table>



                        </div>

                    </div>
                </div>


                <asp:Button ID="btnProcessMultySave" class="save" runat="server" Text="Save" Style="width: 105px; float: left; margin-left: 34%;" OnClientClick="return ValidateProcessMulty()" OnClick="btnProcessMultySave_Click"  />
                <%--<input type="button" id="btnProcessMultyClr" class="save" style="width: 90px; float: left;" value="Clear" />--%>
                <input type="button" id="btnProcessMultyCncl" onclick="ConfirmCancel();" class="save" style="width: 90px; float: left;" value="Cancel" />

            </div>

        </div>
    </div>

    <%-- ----------------for On boarding process multiple//-----%>

    <div>
        <div id="MymodalProcessSingle" class="MyModalProcessMultiple1" >
            <div id="div2">
                <div id="Div3" style="height: 30px; background-color: #6f7b5a;">

                    <label style="margin-left: 38%; font-size: 18px; color: #fff; font-family: calibri;">Leave Facility Assignment</label>
                    
                   <%-- CloseProcessSingle()--%>
                    <img class="closeCancelView" style="margin-top: .5%; margin-right: 1%; float: right; cursor: pointer;" onclick="ConfirmCloseSingle();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                </div>
                <div style="float: left; margin: 13px; border: 1px solid; border-color: #d7c9c9; background-color: #fff; margin-bottom: 6px; width: 97%;height:464px">
                    <div id="Div4" style="width: 91%; float: left; margin-top: 1%; padding: 16px; margin-left: 3%; background-color: #ded2d2;">

                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">Name</h2>
                            <asp:Label ID="lblName" class="lblTop" runat="server"></asp:Label>
                            <asp:Label ID="lblCandId" class="lblTop" Style="display: none" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: right;">
                            <h2 style="color: #603504;">Designation</h2>
                            <asp:Label ID="lblDesg" class="lblTop" runat="server"></asp:Label>
                        </div>
                    
                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">Department</h2>
                         
                                <asp:Label ID="lblDep" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: right;">
                            <h2 style="color: #603504;">Nationality</h2>
                            <asp:Label ID="lblNationality" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">Mode</h2>
                            <asp:Label ID="lblMode" class="lblTop" runat="server"></asp:Label>
                        </div>
                            <div class="eachform" style="width: 47%; float: right;">
                            <h2 style="color: #603504;">Division</h2>
                            <asp:Label ID="lblDiv" class="lblTop" runat="server"></asp:Label>
                        </div>

                    </div>



                    <div id="div5" style="float: left; width: 100%;">
                        <div id="div6" style="visibility: hidden">
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </div>
                            <div id="div7" style="width: 98%; margin: 1%; padding-top: 0.6%; height: 250px;">

                            <table class="TableHeaderProcess" rules="all" style="width: 96%; margin-left: 2%; font-family: calibri;">
                                <tbody>
                                    <tr>
                                        <td style="font-size: 14px; width: 4.2%; padding-left: 0.5%; text-align: center;">Sl#</td>
                                        <td style="font-size: 14px; width: 15%; padding-left: 0.5%; text-align: left;">Particulars</td>
                                       <%-- <td style="font-size: 14px; width: 15.2%; padding-left: 0.5%; text-align: left;">Category</td>--%>
                                        <td style="font-size: 14px; width: 49.7%; padding-left: 0.5%; text-align: left;">Employee</td>
                                        <td style="font-size: 14px; width: 11.1%; padding-left: 0.5%; text-align: center;">Status</td>
                                        <td style="font-size: 14px; width: 10.1%; padding-left: 0.5%; text-align: center;">Target</td>
                                        <td style="font-size: 14px; width: 5.2%; padding-left: 0.5%; text-align: center;">Finish</td>
                                        <td style="font-size: 14px; width: 5.2%; padding-left: 0.5%; text-align: center;">Close</td>
                                    </tr>
                                </tbody>
                            </table>
                            <table id="tblOnBoardSingle" style="width: 96%; margin-left: 2%; font-family: calibri; background-color: #f6f6f6;">

                                <tbody>

                                                    <tr id="trFlight1">
                                        <td  style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">1</td>
                                        <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Flight Ticket</td>
                                     <%--   <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlFlightTcktType" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">

                                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="1">ECONOMY CLASS</asp:ListItem>
                                                <asp:ListItem Value="2">BUSSINESS CLASS</asp:ListItem>
                                                <asp:ListItem Value="3">FIRST CLASS</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>--%>
                                        <td style="width: 50%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
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
                                            <asp:TextBox ID="txtTargetDate6" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;"></asp:TextBox>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="FliFinish2" class="tooltip" title="Finish" onclick="return FinishProcess2MulBrwserChk('Flight');">
                                                <img style="cursor: pointer; margin-left: 25%; opacity: 1;" src='/Images/Icons/success.png' /></a>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="FliClose2" class="tooltip" title="Close" onclick="return CloseProcess2MulBrwserChk('Flight');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/close.png' /></a>
<a id="FliRecall2" style="display:none" class="tooltip" title="Recall" onclick="return RecallProcess2('Flight2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/recallProcess.png' /></a>
                                        </td>
                                    </tr>
                                    <tr class="disabledtr">
                                        <td id="SlCler1" style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">2</td>
                                        <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Clearance</td>
                                      <%--  <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlVisaType" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>

                                        </td>--%>
                                        <td style="width: 50%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlClear" disabled="disabled"  data-placeholder="select employee" multiple="mutiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                            <%-- <asp:TextBox ID="TxtClernce" disabled="disabled"  ClientIDMode="static" class="form-control pull-right" runat="server" Style="height: 27px; width: 100%; float: left;font-family: calibri;" ></asp:TextBox>--%>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">

                                           <%-- <asp:DropDownList ID="DropDownList2" disabled="disabled" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">


                                               <asp:ListItem Selected Value="0">Job Assigned</asp:ListItem>
                                                <asp:ListItem Value="1">APPROVED</asp:ListItem>
                                                <asp:ListItem Value="2">REJECTED</asp:ListItem>
                                                <asp:ListItem Value="3">PENDING</asp:ListItem>
                                               
                                            </asp:DropDownList>--%>
                                               <asp:TextBox ID="DropDownList2" text="Job Assigned" disabled="disabled"  ClientIDMode="static" class="form-control pull-right" runat="server" Style="background-color: #ebebe4;height: 25px; width: 93%; float: left;font-family: calibri;" ></asp:TextBox>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="TextBox1" disabled="disabled" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;"></asp:TextBox>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="A1" style="opacity: 0.5;"  class="tooltip" title="Finish" onclick="return FinishProcess('Visa');">
                                                <img style="cursor: pointer; margin-left: 25%; opacity: 1;" src='/Images/Icons/success.png' /></a>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="A2"  class="tooltip" title="Close" onclick="return CloseProcess('Visa');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/close.png' /></a>
                                        </td>
                                    </tr>
                    
                                    <tr id="trSettlmnt1">
                                        <td id="slSetl1" style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">3</td>
                                        <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Settlement</td>
                                       <%-- <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlRoomAltmntType" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">
                                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="1">BED SPACE</asp:ListItem>
                                                <asp:ListItem Value="2">1BHK</asp:ListItem>
                                                <asp:ListItem Value="3">2BHK</asp:ListItem>
                                                <asp:ListItem Value="4">3BHK</asp:ListItem>
                                                <asp:ListItem Value="5">VILLA</asp:ListItem>
                                                <asp:ListItem Value="6">FLAT</asp:ListItem>
                                            </asp:DropDownList>

                                        </td>--%>
                                        <td style="width: 50%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp7" data-placeholder="select employee" multiple="multiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlSettlment7" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">

                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                                <asp:ListItem Value="1">Pending</asp:ListItem>
                                                <asp:ListItem Value="2">Success</asp:ListItem>
                                                <asp:ListItem Value="3">Failed</asp:ListItem>
                                              <%--  <asp:ListItem Value="4">Closed Without Allotment</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate7" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;"></asp:TextBox>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="roomFinish2" style="opacity: 1;" class="tooltip" title="Finish" onclick="return FinishProcess2MulBrwserChk('Room');">
                                                <img style="cursor: pointer; margin-left: 25%; opacity: 1;" src='/Images/Icons/success.png' /></a>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="RoomClose2" class="tooltip" title="Close" onclick="return CloseProcess2MulBrwserChk('Room');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/close.png' /></a>
 <a id="RoomRecall2" style="display:none" class="tooltip" title="Recall" onclick="return RecallProcess2('Room2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/recallProcess.png' /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="SlExit1" style="width: 4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">4</td>
                                        <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">Exit process</td>
                                       <%-- <td style="width: 15%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                          
                                        </td>--%>
                                        <td style="width: 50%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:DropDownList ID="ddlEmp8" data-placeholder="select employee" multiple="multiple" class="form1 select2" runat="server" Style="height: 27px; width: 100%; float: left;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 11%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                             <asp:DropDownList ID="ddlExitprcss8" class="form1" runat="server" Style="height: 27px; width: 100%; float: left;">

                                                <asp:ListItem Value="0">Job Assigned</asp:ListItem>
                                                <asp:ListItem Value="1">Applied</asp:ListItem>
                                                <asp:ListItem Value="2">Approved</asp:ListItem>
                                                <asp:ListItem Value="3">Rejected</asp:ListItem>
                                              <%--  <asp:ListItem Value="4">Closed Without Allotment</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <asp:TextBox ID="txtTargetDate8" placeholder="dd/mm/yyyy" ClientIDMode="static" class="form-control pull-right" runat="server" Style="width: 93%; height: 23px; font-family: calibri;"></asp:TextBox>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="AirFinish2" style="opacity: 1;" class="tooltip" title="Finish" onclick="return FinishProcess2MulBrwserChk('AirPick');">
                                                <img style="cursor: pointer; margin-left: 25%; opacity: 1;" src='/Images/Icons/success.png' /></a>
                                        </td>
                                        <td style="width: 5%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">
                                            <a id="AirClose2" class="tooltip" title="Close" opacity: 1; onclick="return CloseProcess2MulBrwserChk('AirPick');">
                                                <img style="cursor: pointer; margin-left: 25%; opacity: 1;" src='/Images/Icons/close.png' /></a>
   <a id="AirRecall2" style="display:none" class="tooltip" title="Recall" onclick="return RecallProcess2('AirPick2');">
                                                <img style="cursor: pointer; margin-left: 25%;" src='/Images/Icons/recallProcess.png' /></a>
                                        </td>
                                    </tr>
                                </tbody>

                            </table>



                        </div>

                    </div>
                </div>

                <div style="float:left;width:100%;margin-top:-3%">
                     <div style="float:right;width:61%;">
                <asp:Button ID="btnProcessSingleSave" class="save" runat="server" Text="Update" Style="width: 105px; float: left; margin-left: 0%;" OnClientClick="return ValidateProcessSingle()" OnClick="btnProcessSingleSave_Click" />
                <%--<input type="button" id="btnProcessMultyClr" class="save" style="width: 90px; float: left;" value="Clear" />--%>
                <input type="button" id="btnProcessSingleCancel" onclick="ConfirmCancel();" class="save" style="width: 90px; float: left;" value="Cancel" />
                          </div>
                </div>
            </div>

        </div>
    </div>


    <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: black; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.8; z-index: 29; height: auto !important;"
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
           .MyModalProcessMultiple1 {
            display: none;
            position: fixed;
            z-index: 100;
            padding-top: 0%;
            left: 8%;
            top: 15%;
            width: 84%;
            height: 80%;
            /*overflow: auto;*/
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
        .disabledtr {
    background-color:#f6f6f6;
    pointer-events:none;
}
     
      /*.ui-menu {
    list-style: none;
    padding: 0;
    margin: 254px;
        margin-left: 254px;
    display: block;
    outline: none;
    float: left;
    margin-left: 656px;
}*/


        
    </style>
    <%-- <script src="JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>--%>

</asp:Content>

