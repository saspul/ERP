<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" CodeFile="Leave_Allocation_Master.aspx.cs" Inherits="AWMS_AWMS_Transaction_Leave_Allocation_Master_Leave_Allocation_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">


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
                       window.location.href = "Leave_Allocation_Master_List.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "Leave_Allocation_Master_List.aspx";

               }
           }

           function AlertClearAll() {
               if (confirmbox > 0) {
                   if (confirm("Are you sure you want clear all data in this page?")) {
                       window.location.href = "Leave_Allocation_Master.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "Leave_Allocation_Master.aspx";

               }
           }


    </script>

     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
                     
            // ddlSecToIndexChanged();

           // $noCon('#WaterCardExpiry').datetimepicker({          
         //   }).on("changeDate", function (e) {
         

            $au('#cphMain_ddlEmploye').selectToAutocomplete1Letter();
        
            $noCon("div#divBank input.ui-autocomplete-input").focus();
            $noCon("#divBank input.ui-autocomplete-input").select();

            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {

                IncrmntConfrmCounter();
            }
            if (document.getElementById("<%=hiddennoofleave.ClientID%>").value != "")
            {
                var numlev = document.getElementById("<%=hiddennoofleave.ClientID%>").value;              
                document.getElementById("<%=NumOfLev.ClientID%>").value = numlev;
            }
            

          // if (document.getElementById("<%=hiddenConfirmSts.ClientID%>").value != "1") {
            //    if (document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value != "") {

              //      var Yerlylev = document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value;
                //    var NumberOfLeaveDays = document.getElementById("<%=hiddennoofleave.ClientID%>").value;

                  //  document.getElementById("<%=YearlyLev.ClientID%>").value = Yerlylev - NumberOfLeaveDays;


                    //if (document.getElementById("<%=YearlyLev.ClientID%>").value < 0) {
                      //  document.getElementById('divMessageArea').style.display = "";
                        //document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        //document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, number of leave exceed yearly leave count !";
                        //document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "Red";
                   // }
                //}

       //     }

        });



        function LoadLeaveTypes() {

            var OrgId = '<%= Session["ORGID"] %>';
            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var EmpId = document.getElementById("cphMain_ddlEmploye").value;
            var FromDate = document.getElementById("cphMain_txtDateFrom").value;
            var LevTypId = document.getElementById("cphMain_hiddenLeaveTypId").value;

            $.ajax({
                url: "Leave_Allocation_Master.aspx/LeavTypLoad",
                async: false,
                data: '{ CorpId:"' + CorpId + '", OrgId:"' + OrgId + '", EmpId:"' + EmpId + '", FromDate:"' + FromDate + '", LevTypId:"' + LevTypId + '"}',
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.d != "") {
                        if (data.d != "EpmlyNotInUsr") {

                            $("#cphMain_ddlLeavTyp").empty();
                            $("#cphMain_ddlLeavTyp").append(data.d);
                            $("#cphMain_ddlLeavTyp").val("--SELECT LEAVE TYPE--");
                        }
                        else {
                            EpmlyNotInUsr();
                        }
                    }

                    Autocomplete();

                },
                failure: function (data) {
                    alert("error");
                },

            });
        }

    </script>
    <style type="text/css">

        td.ui-datepicker-current-day {
         background-color: red;
      }

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
    <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                $au('#cphMain_ddlEmploye').selectToAutocomplete1Letter();
              //  $au('#cphMain_ddlLeavTyp').selectToAutocomplete1Letter();
                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);





                    </script>


        <script type="text/javascript">

            //0039
            function LeaveSmAllctd() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Sorry. Selected employee already allocated leave on these days.";
            }
            //end

            function DuplicationConfm()
            {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirm denied.The selected days are already confirmed";
            }
            function DuplicationLevDate(DupLeavFromLeaveAllocation,DupLeavFromLeaveRequest, DupLeavFromDialyLeave)

            {
                var strAllocation="";
                if (DupLeavFromLeaveAllocation > 0) {
                    strAllocation +="leave allocation"
                }

                if (DupLeavFromLeaveRequest > 0) {
                    if (DupLeavFromLeaveAllocation > 0) {
                        strAllocation += ", leave request"
                    }
                    else {
                        strAllocation += "leave request"
                    }
                }

                if (DupLeavFromDialyLeave > 0) {
                    if (DupLeavFromLeaveAllocation > 0 || DupLeavFromLeaveRequest > 0) {
                        strAllocation += ", daily attendance"
                    }
                    else {
                        strAllocation += "daily attendance"
                    }
                }

                if (document.getElementById("<%=hiddenConfirmSts.ClientID%>").value != "1") {
                    if (document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value != "") {

                                    var Yerlylev = document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value;
                    var NumberOfLeaveDays = document.getElementById("<%=hiddennoofleave.ClientID%>").value;

                    document.getElementById("<%=YearlyLev.ClientID%>").value = Yerlylev - NumberOfLeaveDays;


                    if (document.getElementById("<%=YearlyLev.ClientID%>").value < 0) {
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                       // alert("aaa");
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, number of leave exceed yearly leave count !";
                        document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "Red";
                    }
                }

            }



                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error. Leave already allocated for selected days in "+strAllocation;
            }
            
            function Autocomplete()
            {
              
                $au('#cphMain_ddlEmploye').selectToAutocomplete1Letter();
               
                $noCon("div#divBank input.ui-autocomplete-input").focus();
                //$noCon("div#divBank input.ui-autocomplete-input").select();
            }
            function ReOpenNotPossible()
            {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "The selected entry cannot be re-opened ";

            }

            function Already_ReOpened() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Reopen denied. The selected leave allocation is already reopened state.";

            }
            function Already_Rejoined() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Reopen denied. The selected leave allocation is already used in duty resume.";

            }
            function ddlReload()
            {
                document.getElementById("<%=ddlEmploye.ClientID%>").value = 0;
            }
            function EpmlyInUsr()
            {
               document.getElementById('divMessageArea').style.display = "none";
               document.getElementById('imgMessageArea').src = "";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
            }
            function EpmlyNotInUsr() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Selected employee does't permitted for leave ";
            }
            function DupHolidaySingleLev() {
                if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "1") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,selected day is holiday";
                }
            }
            
                function SameDateSelected() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,From Date And To Date Should Not Be Same";
                }
           
                function SuccessConfirmation() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave allocation details inserted successfully.";
                }

                function SuccessUpdation() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Allocation Details Updated Successfully.";
                }

                function SuccessReOpen() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave allocation details reopened successfully.";
                }

                function SuccessConfirm() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave allocation details confirmed successfully.";
                }
            function FaildAllocation() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Sorry.Selected date does not have any leave.";
          
            }

            function CheckReportingOfficer() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Sorry. Selected employee does not have reporting officer.";

            }
           

                function servcecall(LeavDateFrom, EmpId, LeavTypId)
                {
                    var ret = true;
                    document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";

                    document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "";
                    var $noCon = jQuery.noConflict();
                    $noCon.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/ReadRemUsrLevType",
                        data: '{strdate:"' + LeavDateFrom + '",strUserId: "' + EmpId + '",strtypId:"' + LeavTypId + '" }',
                        dataType: "json",
                        success: function (response) {
                            if (response.d != "") {
                             
                                document.getElementById("<%=YearlyLev.ClientID%>").value = response.d;
                                document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value = response.d;
                                document.getElementById("<%=hiddenFrmRem.ClientID%>").value = response.d;

                            }
                            else {
                                if (response.d == "0") {
                                  
                                    document.getElementById("<%=YearlyLev.ClientID%>").value = response.d;
                                    document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value = response.d;
                                    document.getElementById("<%=hiddenFrmRem.ClientID%>").value = response.d;
                                }

                                else {
                                  //  ret = false;
                                  //  alert();
                                   // var opngLev = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;
                                 //   var RemaingLev = document.getElementById("<%=hiddenremaingLev.ClientID%>").value;

                                 //   var totalLev = parseFloat(opngLev) + parseFloat(yerlylevcount);
                                 //   document.getElementById("<%=YearlyLev.ClientID%>").value = opngLev;
                                 //  document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value = opngLev;
                                 //   document.getElementById("<%=hiddenFrmRem.ClientID%>").value = opngLev;

                                  //  document.getElementById("<%=NumOfLev.ClientID%>").value = 0;
                                //    document.getElementById("<%=YearlyLev.ClientID%>").value = 0;

                                 //   document.getElementById("<%=txtDateFrom.ClientID%>").value = "";

                                  //  document.getElementById("<%=TextDateTo.ClientID%>").value = "";
                                 //   document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "red";

                                 //   document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "red";

                                 //   alert();
                                 //   FaildAllocation();
                                //    return false;
                                    var opngLev = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;
                                    //var RemaingLev= document.getElementById("<%=hiddenremaingLev.ClientID%>").value;

                                    //  var totalLev = parseFloat(opngLev) + parseFloat(yerlylevcount);
                                    document.getElementById("<%=YearlyLev.ClientID%>").value = opngLev;
                                    document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value = opngLev;
                                    document.getElementById("<%=hiddenFrmRem.ClientID%>").value = opngLev;
                                 

                                }

                            }
                        }
                 

                    });
                    if (ret == false) {
                      
                        document.getElementById("<%=NumOfLev.ClientID%>").value = 0;
                        document.getElementById("<%=YearlyLev.ClientID%>").value = 0;

                    }
                }


            function ddlLevtyponchge() {

                IncrmntConfrmCounter();
                ddlSecToIndexChanged();

                var LevTypId = document.getElementById("cphMain_ddlLeavTyp").value;
                var EmpId = document.getElementById("cphMain_ddlEmploye").value;

                $.ajax({
                    url: "Leave_Allocation_Master.aspx/LevTypOverRideDate",
                    async: false,
                    data: '{ LevTypId:"' + LevTypId + '",EmpId:"' + EmpId + '"}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {

                        var Result = data.d;
                        if (Result != "") {
                            var ResultSplit = Result.split('_');
                            document.getElementById("<%=hiddenOverRideLeavTypDate.ClientID%>").value = ResultSplit[0];
                            document.getElementById("<%=hiddenOverRidedLeavTyp.ClientID%>").value = ResultSplit[1];
                        }

                    },
                    failure: function (data) {
                        alert("error");
                    },

                });
            }

            function CountHoliday(LeavDateFrom) {



                if (document.getElementById("<%= HiddenLevstrtdtholidaysts.ClientID%>").value == "0") {
                var ToLev = 0;
                $noCon.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/ReadHolidayCountSiglDat",
                    data: '{strdate:"' + LeavDateFrom + '" }',
                    dataType: "json",
                    success: function (response) {

                        if (response.d != 0 && response.d != "0") {
                            ToLev = response.d;


                        }
                        else {
                            ToLev = 0;


                        }

                        //return ToLev;
                        document.getElementById("<%=hiddenfunReturn.ClientID%>").value = ToLev;

                        }


                    });
                }

                if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "0") {
                if (ToLev > 0) {
                    document.getElementById("<%=HiddenOffDaySts.ClientID%>").value = "1";


                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        if (document.getElementById("<%=HiddenOffDayCount.ClientID%>").value > 1) {

                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, The Starting date you have  selected is offday. And You have " + document.getElementById("<%=HiddenOffDayCount.ClientID%>").value + " continues offdays/holidays ";
                            // document.getElementById("cphMain_txtDateFrom").value;
                        }
                        else {

                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning,  The Starting date you have  selected is holiday   !";
                            return false;
                        }

                    }
                }

            }

            //



            function CountHolidayEnddt(LeavDateTo) {



                if (document.getElementById("<%= HiddenLevenddtholidaysts.ClientID%>").value == "0") {
                    var ToLev = 0;
                    $noCon.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/ReadHolidayCountSiglDat",
                        data: '{strdate:"' + LeavDateTo + '" }',
                        dataType: "json",
                        success: function (response) {

                            if (response.d != 0 && response.d != "0") {
                                ToLev = response.d;


                            }
                            else {
                                ToLev = 0;


                            }

                            //return ToLev;
                            document.getElementById("<%=hiddenfunReturn.ClientID%>").value = ToLev;

                        }


                    });
                }

                if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "0") {
                    if (ToLev > 0) {
                        document.getElementById("<%=HiddenOffDaySts.ClientID%>").value = "1";


                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        if (document.getElementById("<%=HiddenOffDayCount.ClientID%>").value > 1) {

                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, The Ending date you have  selected is offday. And You have " + document.getElementById("<%=HiddenOffDayCount.ClientID%>").value + " continues offdays/holidays ";
                            // document.getElementById("cphMain_txtDateFrom").value;
                        }
                        else {

                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning,  The Ending date you have  selected is holiday   !";
                            return false;
                        }

                    }
                }

            }

            //



            function CountHolidayTo(LeavDateFrom) {

                if (document.getElementById("<%= HiddenLevstrtdtholidaysts.ClientID%>").value == "0") {

                    var ToLev = 0;
                    var dutyoff = 0;
                    $noCon.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/ReadHolidayCountSiglDatTo",
                        data: '{strdate:"' + LeavDateFrom + '" }',
                        dataType: "json",
                        success: function (response) {

                            if (response.d != 0 && response.d != "0") {
                                ToLev = response.d;


                            }
                            else {
                                ToLev = 0;


                            }

                            //return ToLev;
                            document.getElementById("<%=hiddenfunReturn.ClientID%>").value = ToLev;

                        }


                    });
                }
            }



            //

            function CountHolidayTo(LeavDateTo) {

                if (document.getElementById("<%= HiddenLevenddtholidaysts.ClientID%>").value == "0") {

                    var ToLev = 0;
                    var dutyoff = 0;
                    $noCon.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/ReadHolidayCountSiglDatTo",
                        data: '{strdate:"' + LeavDateTo + '" }',
                        dataType: "json",
                        success: function (response) {

                            if (response.d != 0 && response.d != "0") {
                                ToLev = response.d;


                            }
                            else {
                                ToLev = 0;


                            }

                            //return ToLev;
                            document.getElementById("<%=hiddenfunReturn.ClientID%>").value = ToLev;

                         }


                     });
                 }
             }





             //
             function CountHolidayFrm(LeavDateTo) {

                 if (document.getElementById("<%= HiddenLevenddtholidaysts.ClientID%>").value == "0") {

                    var ToLev = 0;
                    $noCon.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/ReadHolidayCountSiglDatFrm",
                        data: '{strdate:"' + LeavDateTo + '" }',
                        dataType: "json",
                        success: function (response) {

                            if (response.d != 0 && response.d != "0") {
                                ToLev = response.d;



                            }
                            else {
                                ToLev = 0;


                            }

                            //return ToLev;
                            document.getElementById("<%=hiddenfunReturn.ClientID%>").value = ToLev;

                        }


                    });
                }

            }


            //


            function CountHolidayFrm(LeavDateFrom) {

                if (document.getElementById("<%= HiddenLevstrtdtholidaysts.ClientID%>").value == "0") {

                    var ToLev = 0;
                    $noCon.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/ReadHolidayCountSiglDatFrm",
                        data: '{strdate:"' + LeavDateFrom + '" }',
                        dataType: "json",
                        success: function (response) {

                            if (response.d != 0 && response.d != "0") {
                                ToLev = response.d;



                            }
                            else {
                                ToLev = 0;


                            }

                            //return ToLev;
                            document.getElementById("<%=hiddenfunReturn.ClientID%>").value = ToLev;

                        }


                    });
                }

            }




            //
            function DutyOfChkg(LeavDateFrom) {

                if (document.getElementById("<%=HiddenLevstrtdtoffdaysts.ClientID%>").value == "0") {

                    var orgid = document.getElementById("<%=HiddenFieldOrg.ClientID%>").value;
                    var corpid = document.getElementById("<%=HiddenFieldCorp.ClientID%>").value;



                    var dutyoff = 0;

                    var Details = PageMethods.ReadDutyofChk(LeavDateFrom, orgid, corpid, function (response) {


                        if (response != 0) {
                            dutyoff = response;


                        }
                        else {
                            dutyoff = 0;


                        }


                        //return ToLev;
                        document.getElementById("<%=hiddenDutyoffunReturn.ClientID%>").value = dutyoff;
                        if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "0") {
                            if (dutyoff > 0) {
                                document.getElementById("<%=HiddenOffDaySts.ClientID%>").value = "1";
                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                if (document.getElementById("<%=HiddenOffDayCount.ClientID%>").value > 1) {

                                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, The Starting date you have  selected is offday. And You have " + document.getElementById("<%=HiddenOffDayCount.ClientID%>").value + " continues offdays/holidays ";
                                }
                                else {

                                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, The Starting date you have  selected is offday  !";
                                    return false;
                                }

                            }
                        }



                    });
                }
            }


            //

            function DutyOfChkgEnddt(LeavDateTo) {

                if (document.getElementById("<%=HiddenLevenddtoffdaysts.ClientID%>").value == "0") {

                    var orgid = document.getElementById("<%=HiddenFieldOrg.ClientID%>").value;
                    var corpid = document.getElementById("<%=HiddenFieldCorp.ClientID%>").value;



                    var dutyoff = 0;

                    var Details = PageMethods.ReadDutyofChk(LeavDateTo, orgid, corpid, function (response) {


                        if (response != 0) {
                            dutyoff = response;


                        }
                        else {
                            dutyoff = 0;


                        }


                        //return ToLev;
                        document.getElementById("<%=hiddenDutyoffunReturn.ClientID%>").value = dutyoff;
                        if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "0") {
                            if (dutyoff > 0) {
                                document.getElementById("<%=HiddenOffDaySts.ClientID%>").value = "1";
                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                if (document.getElementById("<%=HiddenOffDayCount.ClientID%>").value > 1) {

                                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, The Ending date you have  selected is offday. And You have " + document.getElementById("<%=HiddenOffDayCount.ClientID%>").value + " continues offdays/holidays ";
                                }
                                else {

                                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, The Ending date you have  selected is offday  !";
                                    return false;
                                }

                            }
                        }



                    });
                }
            }





            /// END

            function DutyOfChkgdateRange(LeavDateFrom, LeaveDateTo) {
              
                var orgid = document.getElementById("<%=HiddenFieldOrg.ClientID%>").value;
                var corpid = document.getElementById("<%=HiddenFieldCorp.ClientID%>").value;
                var dutyoff = 0;
                
                   if (document.getElementById("<%=HiddenFieldHolidayChck.ClientID%>").value != "0") {
                       //Start:-Code0009
                       var HoliPaidSts = document.getElementById("<%=HiddenFieldHoliPaidSts.ClientID%>").value;
                       var OffPaidSts = document.getElementById("<%=HiddenFieldOffPaidSts.ClientID%>").value;

                       var Details = PageMethods.ReadDutyofChkDateRanges(LeavDateFrom, orgid, corpid, LeaveDateTo, HoliPaidSts, OffPaidSts, function (response) {

                           //End:-Code0009

                            
                             if (response[0] != 0) {
                                 dutyoff = response[0];
                                 //  ddlSecToIndexChanged();


                             }
                             else {
                                 dutyoff = 0;
                                 // ddlSecToIndexChanged();


                             }
                             if (response[1] != 0) {
                                 document.getElementById("<%=HiddenOffDayCount.ClientID%>").value = response[1];
                                 
                             }
                             // alert(dutyoff+"sss");
                             //return ToLev;
                             document.getElementById("<%=hiddenDutyoffunReturn.ClientID%>").value = dutyoff;

                             //dutyoffFun();
                             setTimeout(dutyoffFun, 100);

                         });
                    }
                     else {
                      document.getElementById("<%=hiddenDutyoffunReturn.ClientID%>").value = dutyoff;
                        setTimeout(dutyoffFun, 100);

                    }

                }

                function CountHolidaySameyr(LeavDateFrom, LeaveDateTo) {

                    var ToLev = 0;
                    $noCon.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/HolidaySameyrCount",
                        data: '{strdate:"' + LeavDateFrom + '" ,strdateto: "' + LeaveDateTo + '"}',
                        dataType: "json",
                        success: function (response) {

                            if (response.d != 0 && response.d != "0") {
                                ToLev = response.d;


                            }
                            else {
                                ToLev = 0;


                            }
                       
                            //return ToLev;
                            document.getElementById("<%=hiddenDutyoffunReturn.ClientID%>").value = ToLev;

                        }


                    });
                }
            

            function ConvertDecToWords(num) {
               
                var ToLev = 0;
                $noCon.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/HolidayCovrtDecToWords",
                    data: '{strnum:"' + num + '" }',
                    dataType: "json",
                    success: function (data) {

                        if (data.d!='') {
                          

                            document.getElementById("<%=hiddenfunReturn.ClientID%>").value = data.d;
                        }
                    },
                    error: function (result) {
                       
                    }
                });
            }
      
            function ddlSecToIndexChangedUpdatePanel(ModeReportOfficer) {

                LoadLeaveTypes();
                ddlSecToIndexChanged();

                document.getElementById("<%=NumOfLev.ClientID%>").value = "";
                document.getElementById("<%=YearlyLev.ClientID%>").value = "";

                resetDatePickers();
                if (ModeReportOfficer == 1) {
                    CheckReportingOfficer();
                }
                else {
                    document.getElementById('divMessageArea').style.display = "none";
                }
                
            }

            function ChangeDate() {

                LoadLeaveTypes();
                ddlSecToIndexChanged();
            }

         
            function ddlSecToIndexChanged() {
                var paidLeave = 0;
                if (document.getElementById("cphMain_cbxStatus").checked == true) {
                    document.getElementById("cphMain_TextDateTo").disabled = false;
                    document.getElementById("cphMain_ddlSecTo").disabled = false;
                    document.getElementById("cphMain_img1").disabled = false;

                    document.getElementById("cphMain_hTodate").innerHTML = "To Date*";
                    document.getElementById("cphMain_hTosec").innerHTML = "Session To*";
                }
                else {

                    document.getElementById("cphMain_TextDateTo").disabled = true;
                    document.getElementById("cphMain_ddlSecTo").disabled = true;
                    document.getElementById("cphMain_img1").disabled = true;
                    document.getElementById("cphMain_TextDateTo").value = "";
                    document.getElementById("cphMain_ddlSecTo").value = 0;

                    document.getElementById("cphMain_hTodate").innerHTML = "To Date";
                    document.getElementById("cphMain_hTosec").innerHTML = "Session To";
                }


                var LeaveTypeId = document.getElementById("<%=ddlLeavTyp.ClientID%>").value;
                if (LeaveTypeId != "--SELECT LEAVE TYPE--" && LeavTyp != "") {

                    var Details = PageMethods.CheckTrvlDtlShow(LeaveTypeId, function (response) {
                        paidLeave = response[3];
                        document.getElementById("<%=HiddenFieldHolidayChck.ClientID%>").value = response[1];
                        //Start:-Code0009
                        document.getElementById("<%=HiddenFieldHoliPaidSts.ClientID%>").value = response[4];
                        document.getElementById("<%=HiddenFieldOffPaidSts.ClientID%>").value = response[5];
                        //End:-Code0009
                        if (response[2] == 1) {
                            document.getElementById("cphMain_DivFixedAllowance").style.display = "block";
                            document.getElementById("cphMain_divcbxSettlementleaveallocation").style.display = "block";
                            document.getElementById("cphMain_cbxSettlement").checked = true;

                        }
                        else {
                            document.getElementById("cphMain_DivFixedAllowance").style.display = "none";
                            document.getElementById("cphMain_divcbxSettlementleaveallocation").style.display = "none";

                        }

                    });
                }

                var $noCon = jQuery.noConflict();

                var ret = true;
                document.getElementById("<%=hiddenConfirmValue.ClientID%>").value = "1";

                var LeavDateFrm = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();

                var DllEmp = document.getElementById("<%=ddlEmploye.ClientID%>");
                var EmpId = DllEmp.options[DllEmp.selectedIndex].value;

                var LeavDateTo = document.getElementById("<%=TextDateTo.ClientID%>").value.trim();
                if (document.getElementById("<%=cbxStatus.ClientID%>").checked == true) {
                    IncrmntConfrmCounter();
                    if (LeavDateTo != "") {
                        document.getElementById('divMessageArea').style.display = "none";
                        document.getElementById('imgMessageArea').src = "";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                        document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "";
                    }
                }
                if (LeavDateFrm != "") {

                    document.getElementById('divMessageArea').style.display = "none";
                    document.getElementById('imgMessageArea').src = "";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                    document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "";

                }

                var Typddl = document.getElementById("<%=ddlLeavTyp.ClientID%>");
                var LeavTyp = Typddl.options[Typddl.selectedIndex].text;
                var LeavTypId = Typddl.options[Typddl.selectedIndex].value;
                var presenrdate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;

                var arrpresenrdate = presenrdate.split("-");
                PresentFulDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);

                var datepresenrdate = new Date(arrpresenrdate[2]);


                var arrFrmdate = LeavDateFrm.split("-");
                var dateFromdate = new Date(arrFrmdate[2]);
                var arrTodate = LeavDateTo.split("-");
                var dateTodate = new Date(arrTodate[2]);

                var ddlsecF = document.getElementById("<%=ddlSecnFrom.ClientID%>");
                var ddlSecFrmChk = ddlsecF.options[ddlsecF.selectedIndex].text;

                var ddlsecT = document.getElementById("<%=ddlSecTo.ClientID%>");
                var ddlSecToChk = ddlsecT.options[ddlsecT.selectedIndex].text;
                var secfrom = document.getElementById("<%=ddlSecnFrom.ClientID%>").value;
                var seccalctn = 0;
                var secto = document.getElementById("<%=ddlSecTo.ClientID%>").value;
                var seccalctn2 = 0;
                var total = 0;
                var OpengLev = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;
                var LeavDateFrom = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();
                var LeaveDateTo = document.getElementById("<%=TextDateTo.ClientID%>").value.trim();
                var DateFromchk = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();
                var DateTochk = document.getElementById("<%=TextDateTo.ClientID%>").value.trim();
                var arrDateFromchk = DateFromchk.split("-");
                dateDateFromchk = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);

                var arrDateTochk = DateTochk.split("-");
                dateDateTochk = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);


                if (ddlSecFrmChk != "--SELECT FROM--") {
                    IncrmntConfrmCounter();

                    if (secfrom == "1") {
                        seccalctn = '0';
                    }
                    else if (secfrom == "2" || secfrom == "3") {
                        seccalctn = '0.5';
                    }

                }

                if (ddlSecToChk != "--SELECT TO--") {
                    IncrmntConfrmCounter();

                    if (secto == "1") {
                        seccalctn2 = '0';
                    }
                    else if (secto == '2') {
                        seccalctn2 = '0.5';
                    }
                }
                var total;
                if (LeavDateFrm != "") {
                    IncrmntConfrmCounter();

                }
                if (LeavDateTo != "") {
                    IncrmntConfrmCounter();

                }

                $noCon.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/ReadOPeningLeave",
                    data: '{strtypId:"' + LeavTypId + '" }',
                    dataType: "json",
                    success: function (response) {

                        if (response.d != "") {

                            document.getElementById("<%=hiddenOpeningLev.ClientID%>").value = response.d;
                            var num = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;
                        }
                        else {
                            document.getElementById("<%=hiddenOpeningLev.ClientID%>").value = 0;
                        }
                    }

                });



                if (LeavDateFrm != "" && ddlSecFrmChk != "--SELECT FROM--" && LeavTyp != "--SELECT LEAVE TYPE--" && LeavTyp != "") {

                    if (document.getElementById("<%=cbxStatus.ClientID%>").checked == false) {

                        if (dateDateFromchk < PresentFulDate) {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, selected date should be greater than  or equal current year !";
                            document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";

                        }
                        else {

                                if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "0") {
                                    document.getElementById("<%=HiddenFieldHolidayChck.ClientID%>").value = "1";
                                }
                                if (document.getElementById("<%=HiddenFieldHolidayChck.ClientID%>").value != "0") {
                                    document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
                                    var yerlylevcount = document.getElementById("<%=YearlyLev.ClientID%>").value;
                                    var TaskdatepickerDate = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();
                                    var RemaingLev = document.getElementById("<%=hiddenremaingLev.ClientID%>").value;
                                    //0041
                                    DutyOfChkg(LeavDateFrom)
                                    DutyOfChkgEnddt(LeavDateTo)
                                    CountHoliday(LeavDateFrom)
                                    CountHolidayEnddt(LeavDateTo)
                                    //end

                                    var countHoldy = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;

                                    if (countHoldy == 0) {
                                        var DutyOff = document.getElementById("<%=hiddenDutyoffunReturn.ClientID%>").value;
                                        if (DutyOff != 0) {
                                            if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value != "0") {
                                                document.getElementById('divMessageArea').style.display = "";
                                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,selected day is duty off!";
                                                document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                                            }
                                        }
                                        if (seccalctn == 0) {
                                            seccalctn = 1;
                                        }


                                        document.getElementById("<%=NumOfLev.ClientID%>").value = seccalctn;
                                        document.getElementById("<%=hiddennoofleave.ClientID%>").value = seccalctn;



                                        if (dateFromdate.toDateString() == datepresenrdate.toDateString() || dateFromdate > datepresenrdate) {
                                            servcecall(LeavDateFrom, EmpId, LeavTypId);


                                            var yerlylevcount = document.getElementById("<%=YearlyLev.ClientID%>").value;
                                            if (DutyOff != 0) {
                                                if (seccalctn > yerlylevcount) {

                                                    document.getElementById('divMessageArea').style.display = "";
                                                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, number of leave exceed yearly leave count !";
                                                    document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "Red";

                                                }
                                            }


                                        }


                                    }
                                    else {
                                        document.getElementById("<%=hiddenHolidaychck.ClientID%>").value = 1;
                                        DupHolidaySingleLev();
                                    }
                                }
                                else {
                                    servcecall(LeavDateFrom, EmpId, LeavTypId);
                                    if (seccalctn == 0) {
                                        seccalctn = 1;
                                    }
                                    document.getElementById("<%=NumOfLev.ClientID%>").value = seccalctn;
                                    document.getElementById("<%=hiddennoofleave.ClientID%>").value = seccalctn;
                                    //cmt
                                    var yrLeave = document.getElementById("<%=YearlyLev.ClientID%>").value;
                                    yrLeave = yrLeave - seccalctn;
                                    document.getElementById("<%=YearlyLev.ClientID%>").value = yrLeave
                                }

                            if (paidLeave == 1) {

                                var strOrgId = '<%= Session["ORGID"] %>';
                                var strCorpId = '<%= Session["CORPOFFICEID"] %>';

                                $noCon.ajax({
                                    type: "POST",
                                    async: false,
                                    contentType: "application/json; charset=utf-8",
                                    url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/ReadRemLeavePaidEligble",
                                    data: '{strtypId:"' + LeavTypId + '",EmpId:"' + EmpId + '",strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '"}',
                                    dataType: "json",
                                    success: function (response) {
                                        if (response.d != "") {
                                            document.getElementById("<%=YearlyLev.ClientID%>").value = response.d;
                                        }
                                        else {
                                            document.getElementById("<%=YearlyLev.ClientID%>").value = 0;
                                        }
                                    }
                                  });
                            }





                        }
                    }
                }






                if (LeavDateFrm != "" && LeavDateTo != "" && ddlSecFrmChk != "--SELECT FROM--" && ddlSecToChk != "--SELECT TO--" && LeavTyp != "--SELECT LEAVE TYPE--" && LeavTyp != "") {


                  
                        var countFrmHoldy = 0;
                        var countToHoldy = 0;
                        var Dutyoff = 0;
                        DutyOfChkgdateRange(LeavDateFrom, LeaveDateTo);

                        Dutyoff = document.getElementById("<%=hiddenDutyoffunReturn.ClientID%>").value;


                        //cmt
                        var Yerlylev = document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value;
                        var NumberOfLeaveDays = document.getElementById("<%=hiddennoofleave.ClientID%>").value;
                        document.getElementById("<%=YearlyLev.ClientID%>").value = Yerlylev - NumberOfLeaveDays;

                    if (paidLeave == 1)  {

                        var strOrgId = '<%= Session["ORGID"] %>';
                        var strCorpId = '<%= Session["CORPOFFICEID"] %>';
                        $noCon.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/ReadRemLeavePaidEligble",
                            data: '{strtypId:"' + LeavTypId + '",EmpId:"' + EmpId + '",strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '"}',
                            dataType: "json",
                            success: function (response) {
                                if (response.d != "") {
                                    document.getElementById("<%=YearlyLev.ClientID%>").value = response.d;
                                        }
                                        else {
                                            document.getElementById("<%=YearlyLev.ClientID%>").value = 0;
                                        }
                                    }
                                });
                    }


                }
                else {

                    ret = false;
                }
                return ret;
            }

            function dutyoffFun()
            {
                var ret = true;

                document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
                document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "";


                var LeavDateFrm = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();

                var LeavDateTo = document.getElementById("<%=TextDateTo.ClientID%>").value.trim();

                var DllEmp = document.getElementById("<%=ddlEmploye.ClientID%>");
                var EmpId = DllEmp.options[DllEmp.selectedIndex].value;



                var Typddl = document.getElementById("<%=ddlLeavTyp.ClientID%>");
                var LeavTyp = Typddl.options[Typddl.selectedIndex].text;
                var LeavTypId = Typddl.options[Typddl.selectedIndex].value;
                var presenrdate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;

                    var arrpresenrdate = presenrdate.split("-");
                    PresentFulDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
                    var datepresenrdate = new Date(arrpresenrdate[2]);

                    var arrFrmdate = LeavDateFrm.split("-");
                    var dateFromdate = new Date(arrFrmdate[2]);
                    var arrTodate = LeavDateTo.split("-");
                    var dateTodate = new Date(arrTodate[2]);

                    var ddlsecF = document.getElementById("<%=ddlSecnFrom.ClientID%>");
                    var ddlSecFrmChk = ddlsecF.options[ddlsecF.selectedIndex].text;

                    var ddlsecT = document.getElementById("<%=ddlSecTo.ClientID%>");
                    var ddlSecToChk = ddlsecT.options[ddlsecT.selectedIndex].text;
                    var secfrom = document.getElementById("<%=ddlSecnFrom.ClientID%>").value;
                    var seccalctn = 0;
                    var secto = document.getElementById("<%=ddlSecTo.ClientID%>").value;
                    var seccalctn2 = 0;
                    var total = 0;
                    var OpengLev = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;
                    var LeavDateFrom = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();
                var LeaveDateTo = document.getElementById("<%=TextDateTo.ClientID%>").value.trim();
                var DateFromchk = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();
                var DateTochk = document.getElementById("<%=TextDateTo.ClientID%>").value.trim();
                var arrDateFromchk = DateFromchk.split("-");
                dateDateFromchk = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);

                var arrDateTochk = DateTochk.split("-");
                dateDateTochk = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);


                if (ddlSecFrmChk != "--SELECT FROM--") {
                  //  IncrmntConfrmCounter();

                    if (secfrom == "1") {
                        seccalctn = '0';
                    }
                    else if (secfrom == "2" || secfrom == "3") {
                        seccalctn = '0.5';
                    }

                }

                if (ddlSecToChk != "--SELECT TO--") {
                   //alert IncrmntConfrmCounter();

                    if (secto == "1") {
                        seccalctn2 = '0';
                    }
                    else if (secto == '2') {
                        seccalctn2 = '0.5';
                    }
                }



                var countFrmHoldy = 0;
                var countToHoldy = 0;
                var Dutyoff = 0;

                Dutyoff = document.getElementById("<%=hiddenDutyoffunReturn.ClientID%>").value;
             
               // alert(Dutyoff+"ss");
                //var flt = parseFloat(seccalctn);
                //var tot;
                //tot = flt + seccalctn2;


                //11/1
                if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "0") {

                    //0041 
                    CountHoliday(LeavDateFrom)
                    CountHolidayEnddt(LeavDateTo)

                    DutyOfChkg(LeavDateFrom);
                    DutyOfChkgEnddt(LeavDateTo);

                    //end
                    document.getElementById("<%=HiddenOffDaySts.ClientID%>").value = 0;
                }
                if (document.getElementById("<%=HiddenOffDaySts.ClientID%>").value == "1") {
                  //  ret = false;
                    //  return false;
                }
              
              
                //End
                if (document.getElementById("<%=cbxStatus.ClientID%>").checked == true) {
                            document.getElementById("<%=hiddenHolidaychck.ClientID%>").value = 0;

                            if (dateDateFromchk < dateDateTochk) {

                                if (dateFromdate.toDateString() == dateTodate.toDateString() || dateDateFromchk < dateDateTochk) {
                                    var YearComprsn;
                                    var NumOfHolFrm;
                                    var NumOfHolTo;
                                    if (dateFromdate.toDateString() == dateTodate.toDateString()) {
                                        YearComprsn = 0;
                                        CountHolidaySameyr(LeavDateFrom, LeaveDateTo);
                                        NumOfHolFrm = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;

                                        CountHoliday(LeavDateFrom);
                                        countFrmHoldy = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;

                                       // CountHoliday(LeaveDateTo);
                                        countToHoldy = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;



                                        servcecall(LeavDateFrom, EmpId, LeavTypId);



                                    }
                                    else {

                                        //0041

                                        CountHolidayFrm(LeavDateFrom);
                                        CountHolidayFrm(LeavDateTo);

                                        NumOfHolFrm = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;


                                        YearComprsn = 1;
                                        var FrmLeav = 0;
                                        var ToLev = 0;
                                        var RemlevTotal;

                                      //  CountHolidayTo(LeaveDateTo)
                                        NumOfHolTo = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;

                                      
                                        // FrmLeav=  servcecall(LeavDateFrom, EmpId, LeavTypId);
                                        $noCon.ajax({
                                            type: "POST",
                                            async: false,
                                            contentType: "application/json; charset=utf-8",
                                            url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/ReadRemUsrLevType",
                                            data: '{strdate:"' + LeavDateFrom + '" ,strUserId: "' + EmpId + '",strtypId:"' + LeavTypId + '" }',
                                            dataType: "json",
                                            success: function (response) {

                                                if (response.d != "") {
                                                    FrmLeav = response.d;


                                                }
                                                else {
                                                    if (response.d == "0") {
                                                        FrmLeav = response.d;
                                                    }
                                                    else {
                                                        FrmLeav = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;

                                                        // alert("23");
                                                        //   FrmLeav = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;

                                                     //   document.getElementById("<%=YearlyLev.ClientID%>").value = 0;

                                                       
                                                     //   document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "red";

                                                      



                                                    ///   document.getElementById("<%=NumOfLev.ClientID%>").value = 0;
                                                     ///   document.getElementById("<%=txtDateFrom.ClientID%>").value = "";

                                                     //   FaildAllocation();
                                                     //   ret = false;
                                                    //    return false;

                                                    }


                                                }

                                            }


                                        });



                                        $noCon.ajax({
                                            type: "POST",
                                            async: false,
                                            contentType: "application/json; charset=utf-8",
                                            url: "/AWMS/AWMS_WebServices/Service_Leave_Allocation.asmx/ReadRemUsrLevType",
                                            data: '{strdate:"' + LeaveDateTo + '" ,strUserId: "' + EmpId + '",strtypId:"' + LeavTypId + '" }',
                                            dataType: "json",
                                            success: function (response) {
                                                if (response.d != "") {
                                                    ToLev = response.d;


                                                }
                                                else {
                                                    if (response.d == "0") {

                                                        ToLev = response.d;

                                                    }
                                                    else {
                                                        ToLev = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;

                                                        //   alert("66");

                                                      //  document.getElementById("<%=YearlyLev.ClientID%>").value = 0;

                                                     //   document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "red";


                                                     //   ToLev = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;
                                                    //  document.getElementById("<%=NumOfLev.ClientID%>").value = 0;

                                                     //   document.getElementById("<%=TextDateTo.ClientID%>").value = "";
                                                     //   ret = false;

                                                     //   FaildAllocation();
                                                     //   return false;
                                                        //  alert("3333");

                                                    }
                                                }

                                            }

                                        });

                                        document.getElementById("<%=hiddenFrmRem.ClientID%>").value = FrmLeav;
                                        document.getElementById("<%=hiddenToRem.ClientID%>").value = ToLev;

                                        RemlevTotal = parseFloat(FrmLeav) + parseFloat(ToLev);

                                        document.getElementById("<%=YearlyLev.ClientID%>").value = RemlevTotal;
                                        document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value = RemlevTotal;

                                    }



                                    if (ddlSecToChk != "--SELECT TO--" && ddlSecFrmChk != "--SELECT FROM--") {
                                        if (countFrmHoldy != 0) {
                                            total = seccalctn2;

                                        }
                                        if (countToHoldy != 0) {
                                            total = seccalctn;

                                        }
                                        if (countFrmHoldy != 0 && countToHoldy != 0) {
                                            total = 0;
                                        }
                                        if (countFrmHoldy == 0 && countToHoldy == 0) {
                                            total = parseFloat(seccalctn) + parseFloat(seccalctn2);

                                        }

                                    }

                                    var yerlylevcount = document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value;

                                    var CurrentDateDate = document.getElementById("<%=TextDateTo.ClientID%>").value;
                                    var arrCurrentDate = CurrentDateDate.split("-");
                                    var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                                    var TaskdatepickerDate = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();
                                    var arrDatePickerDate = TaskdatepickerDate.split("-");
                                    var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
                                    var timeDiff = Math.abs(dateDateCntrlr.getTime() - dateCurrentDate.getTime());
                                    var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
                                    diffDays = diffDays + 1;
                                    var numdays = diffDays - total;
                                    //duty off
                                    // if (numdays > Dutyoff)
                                    //  numdays = numdays-Dutyoff;
                                    // alert(Dutyoff);

                                    if (ret == true) {
                                     
                                        if (yerlylevcount < numdays) {
                                            document.getElementById('divMessageArea').style.display = "";
                                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, number of leave exceed yearly leave count !";
                                            document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "Red";
                                        }
                                        if (YearComprsn == 0) {
                                           
                                            NumOfHolFrm = parseFloat(NumOfHolFrm) + parseFloat(Dutyoff);

                                            if (Dutyoff == 0) {
                                             
                                                numdays = parseFloat(numdays);
                                                document.getElementById("<%=hiddennoofleave.ClientID%>").value = numdays;
                                                //alert("4")
                                              

                                                document.getElementById("<%=NumOfLev.ClientID%>").value = numdays;

                                                //cmt
                                                var yrLeave = document.getElementById("<%=YearlyLev.ClientID%>").value;
                                                yrLeave = yrLeave - numdays;                                                
                                                document.getElementById("<%=YearlyLev.ClientID%>").value = yrLeave
                                            }
                                            else {
                                             
                                                if (numdays > Dutyoff) {
                                                 
                                                    //  var ComLevHol = numdays - NumOfHolFrm;
                                                    var ComLevHol = numdays - Dutyoff;
                                                    document.getElementById("<%=hiddennoofleave.ClientID%>").value = ComLevHol;

                                                  

                                                    document.getElementById("<%=NumOfLev.ClientID%>").value = ComLevHol;
                                                    if (yerlylevcount > numdays) {
                                                       
                                                        

                                                        ConvertDecToWords(Dutyoff);
                                                        var numinWords = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;
                                                        if (Dutyoff == 1) {

                                                            if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "1") {
                                                                document.getElementById('divMessageArea').style.display = "";
                                                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, in selected leave period there is '" + numinWords + "' holiday  !";
                                                            }
                                                            }
                                                        else {
                                                            if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "1") {
                                                                document.getElementById('divMessageArea').style.display = "";
                                                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, in selected leave period  there are '" + numinWords + "' holidays  !";
                                                            }
                                                            }

                                                    }
                                                    else {
                                                      

                                                        ConvertDecToWords(Dutyoff);
                                                        var numinWords = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;
                                                        if (Dutyoff == 1) {
                                                            if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "1") {
                                                                document.getElementById('divMessageArea').style.display = "";
                                                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning,  in selected leave period  there is '" + numinWords + "' holiday and  number of leave exceed yearly leave count !";
                                                            }
                                                            }
                                                        else {
                                                            if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value != "0") {
                                                                document.getElementById('divMessageArea').style.display = "";
                                                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning,  in selected leave period  there are '" + numinWords + "' holidays and  number of leave exceed yearly leave count !";
                                                            }
                                                            }
                                                        document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "Red";
                                                    }
                                                }
                                                else {
                                                    if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value != "0") {
                                                        document.getElementById("<%=hiddenHolidaychck.ClientID%>").value = 1;
                                                        document.getElementById('divMessageArea').style.display = "";
                                                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning,  selected days were holidays  !";
                                                        //    document.getElementById("<%=hiddenHolidaychck.ClientID%>").value = 0;
                                                        ret = false;
                                                    }
                                                }
                                            }
                                        }
                                        else {
                                            var totalHol = Dutyoff;
                                            // var totalHol = parseFloat(NumOfHolFrm) + parseFloat(NumOfHolTo);
                                            // totalHol = parseFloat(totalHol) + parseFloat(Dutyoff);
                                            if (totalHol == 0) {
                                                document.getElementById("<%=hiddennoofleave.ClientID%>").value = numdays;
                                               

                                                document.getElementById("<%=NumOfLev.ClientID%>").value = numdays;
                                            }
                                            else {
                                                if (numdays > totalHol) {
                                                    var ComLevHol = numdays - totalHol;
                                                    document.getElementById("<%=hiddennoofleave.ClientID%>").value = ComLevHol;
                                                  

                                                    document.getElementById("<%=NumOfLev.ClientID%>").value = ComLevHol;
                                                    if (yerlylevcount > numdays) {
                                                       
                                                        ConvertDecToWords(Dutyoff);
                                                        var numinWords = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;
                                                        if (Dutyoff == 1) {
                                                            if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "1") {
                                                                document.getElementById('divMessageArea').style.display = "";
                                                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, in selected leave period there is '" + numinWords + "' holiday  !";
                                                            }
                                                            }
                                                        else {
                                                            if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "1") {
                                                                document.getElementById('divMessageArea').style.display = "";
                                                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, in selected leave period there are '" + numinWords + "' holidays  !";
                                                            }
                                                            }

                                                    }
                                                    else {
                                                       
                                                        ConvertDecToWords(totalHol);
                                                        var numinWords = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;
                                                        if (totalHol == 1) {
                                                            if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "1") {
                                                                document.getElementById('divMessageArea').style.display = "";
                                                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, in selected leave period there is '" + numinWords + "' holiday and  number of leave exceed yearly leave count!";
                                                            }
                                                            }
                                                        else {
                                                            if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "1") {
                                                                document.getElementById('divMessageArea').style.display = "";
                                                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, in selected leave period there are '" + numinWords + "' holidays and  number of leave exceed yearly leave count!";
                                                            }
                                                            }
                                                        document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "Red";
                                                    }
                                                }
                                                else {
                                                    if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value != "0") {
                                                        document.getElementById("<%=hiddenHolidaychck.ClientID%>").value = 1;
                                                        document.getElementById('divMessageArea').style.display = "";
                                                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, selected days were holidays  !";
                                                        ret = false;
                                                    }
                                                }
                                            }
                                        }

                                        //  ret = true;
                                    }
                                }
                            }
                            else {
                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave date should be greater than salary process date.";
                                document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "Red";
                                ret = false;

                            }

                }

                if (ret == false) {
                  
                    document.getElementById("<%=NumOfLev.ClientID%>").value = 0;
                    document.getElementById("<%=YearlyLev.ClientID%>").value = 0;

                }
            }
           
                function WaterCardValidate(Mode) {

                    var $noCon = jQuery.noConflict();
                    var ret = true;
                    if (CheckIsRepeat() == true) {

                    }
                    else {
                        ret = false;
                        return ret;
                    }
                    // replacing < and > tags
                    document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
                    var CrdExpWithoutReplace = document.getElementById("<%=txtDateFrom.ClientID%>").value;
                    var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                    var replaceCode2 = replaceCode1.replace(/>/g, "");
                    document.getElementById("<%=txtDateFrom.ClientID%>").value = replaceCode2;

                    var CrdExpWithoutReplace = document.getElementById("<%=TextDateTo.ClientID%>").value;
                    var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                    var replaceCode2 = replaceCode1.replace(/>/g, "");
                    document.getElementById("<%=TextDateTo.ClientID%>").value = replaceCode2;

                    document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";

                    document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "";

                   // var LeavDFrm = document.getElementById("<%=txtDateFrom.ClientID%>").value;
                   // var LeavDTo = document.getElementById("<%=TextDateTo.ClientID%>").value;

                    var LeavDateFrm = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();
                    var LeavDateTo = document.getElementById("<%=TextDateTo.ClientID%>").value.trim();

                    var arrFrmDate = LeavDateFrm.split("-");
                    var dateFrmDte = new Date(arrFrmDate[2], arrFrmDate[1] - 1, arrFrmDate[0]);

                    var arrToDate = LeavDateTo.split("-");
                    var dateToDte = new Date(arrToDate[2], arrToDate[1] - 1, arrToDate[0]);

                    var DllEmp = document.getElementById("<%=ddlEmploye.ClientID%>");
                    var EmpChek = DllEmp.options[DllEmp.selectedIndex].text;

                    var Typddl = document.getElementById("<%=ddlLeavTyp.ClientID%>");
                    var LeavTyp = Typddl.options[Typddl.selectedIndex].text;

                    var ddlsecF = document.getElementById("<%=ddlSecnFrom.ClientID%>");
                    var ddlSecFrmChk = ddlsecF.options[ddlsecF.selectedIndex].text;

                    var ddlsecT = document.getElementById("<%=ddlSecTo.ClientID%>");
                    var ddlSecToChk = ddlsecT.options[ddlsecT.selectedIndex].text;
                    var hiddnstrid = document.getElementById("<%=hiddenstrid.ClientID%>").value;
                  //  alert(document.getElementById("<%=hiddenHolidaychck.ClientID%>").value);
                    if (document.getElementById("<%=hiddenHolidaychck.ClientID%>").value == 1) {
                        if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value != "0") {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning,  selected days were holidays  !";
                            document.getElementById("<%=hiddenHolidaychck.ClientID%>").value = 0;
                            ret = false;
                        }
                    }
                    //11/2
                    if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "0") {
                        if (document.getElementById("<%=HiddenOffDaySts.ClientID%>").value == "1") {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            if (document.getElementById("<%=HiddenOffDayCount.ClientID%>").value > 1) {

                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, The Starting date you have  selected is offday. And You have " + document.getElementById("<%=HiddenOffDayCount.ClientID%>").value + " continues offdays/holidays ";
                            }
                            else {

                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, The Starting date you have  selected is offday  !";

                                document.getElementById("<%=HiddenOffDaySts.ClientID%>").value = "0";
                                ret = false;
                            }
                            ddlSecToIndexChanged();

                        }
                    }
                   
                    // if (hiddnstrid == "0") {
                    
                    if (LeavDateFrm != "") {
                         
                        var TaskdatepickerDate = document.getElementById("<%=txtDateFrom.ClientID%>").value;
                        var arrDatePickerDate = TaskdatepickerDate.split("-");
                        var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
                        var FrmYr = arrDatePickerDate[2];
                        FrmYr = parseInt(FrmYr);
                        var presenrdate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;

                        var arrpresenrdate = presenrdate.split("-");
                        var datepresenrdate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
                        var presentyr = arrpresenrdate[2];
                        presentyr = parseInt(presentyr) + 1;
                       // alert(Mode);
                      //  if (Mode == "INS" || LeavDateTo=="") {
                         
                        if (dateDateCntrlr < datepresenrdate) {

                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";

                            //evm-00023-15-2
                            //document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,from date cant't be less than current year !";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave date should be greater than salary process date.";
                            document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                            ret = false;

                        }
                            
                         
                        if (FrmYr > presentyr) {

                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,leave allocation permit only for curent year and next year !";
                            document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                            ret = false;

                        }
                           
                   // }
                        }


                        if (dateToDte != "" && LeavDateFrm != "") {

                            var TaskdatepickerDate = document.getElementById("<%=TextDateTo.ClientID%>").value;
                            var arrDatePickerDate = TaskdatepickerDate.split("-");
                            var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                            var CurrentDateDate = document.getElementById("<%=txtDateFrom.ClientID%>").value;
                            var arrCurrentDate = CurrentDateDate.split("-");
                            var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                            if (document.getElementById("<%=hiddenOverRideLeavTypDate.ClientID%>").value != "") {

                                var OverRideDate = document.getElementById("<%=hiddenOverRideLeavTypDate.ClientID%>").value;
                                var arrOverRideDate = OverRideDate.split("-");
                                var dateOverRideDate = new Date(arrOverRideDate[2], arrOverRideDate[1] - 1, arrOverRideDate[0]);

                                if (dateOverRideDate >= dateCurrentDate && dateOverRideDate <= dateDateCntrlr) {

                                    document.getElementById('divMessageArea').style.display = "";
                                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, the leavetype is being overrided by " + document.getElementById("<%=hiddenOverRidedLeavTyp.ClientID%>").value + " from " + document.getElementById("<%=hiddenOverRideLeavTypDate.ClientID%>").value + " !";
                                    document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                                    document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "Red";
                                    document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                                    $(window).scrollTop(0);
                                    ret = false;
                                }
                            }

                            if (dateDateCntrlr.toDateString() == dateCurrentDate.toDateString()) {

                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, from date and to date should be different !";
                                document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                                ret = false;

                            }
                           if (dateDateCntrlr < dateCurrentDate) {

                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, from date should be less than to date !";
                                document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                               document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                                ret = false;

                            }

                            var presenrdate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                            var arrpresenrdate = presenrdate.split("-");
                            var datepresenrdate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
                            var presentyr = arrpresenrdate[2];
                            presentyr = parseInt(presentyr) + 1;
                            var Fromyr = arrCurrentDate[2];
                            Fromyr = parseInt(Fromyr);
                            var Toyr = arrDatePickerDate[2];
                            Toyr = parseInt(Toyr);
                            if (datepresenrdate > dateDateCntrlr) {
                               
                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave date should be greater than salary process date.";
                                document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                                document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
                                document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "Red";
                                  ret = false;

                            }
                            
                            //if (datepresenrdate > dateCurrentDate ) {
                             //   if (2 > 4) {

                             //   document.getElementById('divMessageArea').style.display = "";
                             //  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                              // document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, from date can't be less than current date !";
                              //  document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                               // document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                              //  document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "";
                              //  ret = false;

                         //   }
                          
                            if (Fromyr > presentyr) {
                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, leave allocation permit only for curent year and next year  !";
                                document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                                document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "Red";
                                 ret = false;
                            }
                          
                             if (Toyr > presentyr) {
                                 document.getElementById('divMessageArea').style.display = "";
                                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,leave allocation permit only for curent year and next year  !";
                                 document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                                document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "Red";
                                ret = false;
                            }

                        }
                    //}
               
                   
                       // else {
                       //     document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "";
                    //    }
                    if (document.getElementById("<%=cbxStatus.ClientID%>").checked == true) {
                        if (ddlSecToChk == "--SELECT TO--") {

                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=ddlSecTo.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=ddlSecTo.ClientID%>").focus();
                            ret = false;
                        }
                        else {
                            document.getElementById("<%=ddlSecTo.ClientID%>").style.borderColor = "";
                        }
                    
                        if (LeavDateTo == "") {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                            document.getElementById("<%=TextDateTo.ClientID%>").focus();
                            ret = false;
                        }
                    }
               

                    


                    if (ddlSecFrmChk == "--SELECT FROM--") {

                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=ddlSecnFrom.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=ddlSecnFrom.ClientID%>").focus();
                        ret = false;
                    }
                    else {
                        document.getElementById("<%=ddlSecnFrom.ClientID%>").style.borderColor = "";
                    }
                 
                    if (LeavDateFrm == "") {
                      
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtDateFrom.ClientID%>").focus();
                        ret = false;
                    }
                   // else {
                      //  document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
                   // }
                    if (LeavTyp == "--SELECT LEAVE TYPE--" || LeavTyp == "") {

                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=ddlLeavTyp.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=ddlLeavTyp.ClientID%>").focus();

                        // $noCon("div#ddlLeavTyp input.ui-autocomplete-input").css("borderColor", "red");
                        // $noCon("div#ddlLeavTyp input.ui-autocomplete-input").focus();
                        // $noCon("div#ddlLeavTyp input.ui-autocomplete-input").select();
                        ret = false;
                    }
                    else {
                        document.getElementById("<%=ddlLeavTyp.ClientID%>").style.borderColor = "";

                    }
                    if (EmpChek == "--SELECT AN EMPLOYEE--") {

                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        //  document.getElementById("<%=ddlEmploye.ClientID%>").style.borderColor = "Red";
                        // document.getElementById("<%=ddlEmploye.ClientID%>").focus();

                        $noCon("div#divBank input.ui-autocomplete-input").css("borderColor", "red");
                        $noCon("div#divBank input.ui-autocomplete-input").focus();
                        $noCon("div#divBank input.ui-autocomplete-input").select();
                        ret = false;
                    }
                    else {

                        document.getElementById("<%=ddlEmploye.ClientID%>").style.borderColor = "";
                    }
                    if (document.getElementById("<%=NumOfLev.ClientID%>").value == "" || document.getElementById("<%=NumOfLev.ClientID%>").value == null) {
                        ret = false;
                    }
                    if (ret == false) {
                        CheckSubmitZero();
                    }
                    else {
                        document.getElementById("<%=hiddenLeaveTypId.ClientID%>").value = document.getElementById("cphMain_ddlLeavTyp").value;
                        $('#cphMain_ddlLeavTyp').empty();
                        $('#cphMain_ddlLeavTyp').append("--SELECT LEAVE TYPE--");
                    }
           
                    return ret;
                }


    </script>

    <%-- <script type="text/javascript">
         var $noCo = jQuery.noConflict();
       

         $noCo('#date-end').datetimepicker().on('changeDate', function (ev) {
             if(ev.date.valueOf() < date-start-display.valueOf())
             {
                 alert("123");
                 return ddlSecToIndexChanged();
             }

         
         });
                        </script>--%>

        <script type="text/javascript" language="javascript">
            // for not allowing <> tags
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
            // for not allowing enter
            function DisableEnter(evt) {
                //  var b = new Date(); alert(b);
             
                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                if (keyCodes == 13) {
                    return false;
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


            function ConfirmReOpen() {
                if (confirm("Are you sure you want to reopen this page?")) {
                    return true;
                }
                else {
                    return false;
                }
            }

            //evm-0023-2-3
            function clearselect() {              
              //  alert("10")
               // document.getElementById("<%=NumOfLev.ClientID%>").value = 0;
                var DllEmp = document.getElementById("<%=ddlEmploye.ClientID%>");
                 //  var EmpChek = DllEmp.options[DllEmp.selectedIndex].text;

                   // if (EmpChek == "--SELECT AN EMPLOYEE--") {
                   $noCon("#divBank input.ui-autocomplete-input").select();
                   //}
               }
    </script>
         <style type="text/css">
       
                
              
            .imgDescription {
            position: absolute;
            /*top: 511px;
            left: 6.5%;*/
            background: rgb(154, 163, 138);
            visibility: hidden;
            opacity: 0;
            padding: 0.1%;
            font-family: Calibri;
            /*remove comment if you want a gradual transition between states
  -webkit-transition: visibility opacity 0.2s;
  */
        }

        .imgWrap:hover .imgDescription {
            visibility: visible;
            opacity: 1;
        }
   
    </style>
 
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {



                $au('form').submit(function () {


                });
            });
        })(jQuery);



        function cbxSettlementClick() {
            if (document.getElementById("cphMain_cbxSettlement").checked == true) {
                document.getElementById("cphMain_divcbxSettlementleaveallocation").style.display = "block";
            }
            else {
                document.getElementById("cphMain_divcbxSettlementleaveallocation").style.display = "none";
            }
        }

        //evm-0023-15-2

        //function changeLeaveMultiplDays() {
        //    if (document.getElementById("cphMain_cbxStatus").checked == true) {
        //        document.getElementById("cphMain_TextDateTo").disabled = false;
        //        document.getElementById("cphMain_ddlSecTo").disabled = false;
        //        document.getElementById("cphMain_img1").disabled = false;
        //        document.getElementById("cphMain_hTodate").innerHTML = "To Date*";
        //        document.getElementById("cphMain_hTosec").innerHTML = "Section To*";

        //        ddlSecToIndexChanged();
        //    }
        //    else {
        //        $("#cphMain_ddlSecTo").val(0);
        //        document.getElementById("cphMain_TextDateTo").value = "";
        //        document.getElementById("cphMain_hTodate").innerHTML = "To Date";
        //        document.getElementById("cphMain_hTosec").innerHTML = "Section To";

        //        document.getElementById("cphMain_TextDateTo").disabled = true;
        //        document.getElementById("cphMain_ddlSecTo").disabled = true;
        //        document.getElementById("cphMain_img1").disabled = true;

        //        ddlSecToIndexChanged();

        //    }
        //}

      




                    </script>
   
    <%--FOR DATE TIME PICKER--%>
<script type="text/javascript" src="../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>                      
<script type="text/javascript" src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
<script type="text/javascript" src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
<script type="text/javascript"src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
<link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
<link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />



<script>

    var $noCo24 = jQuery.noConflict();
    function resetDatePickers() {
        //this function work when select a name
        var presenrdate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
          var arrpresenrdate = presenrdate.split("-");
          var PresentFulDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
          PresentFulDate.setDate(PresentFulDate.getDate() + 2);



          $noCo24("#WaterCardExpiry").datetimepicker('destroy', '');


          var year = (new Date).getFullYear();
          year = year + 2;
          $noCo24('#WaterCardExpiry').datetimepicker({
              format: 'dd-MM-yyyy',
              language: 'en',
              pickTime: false,
              endDate: new Date(year, '0', '0'),
              endDate9: new Date(year, '0', '0'),
              startDate: PresentFulDate

          }).on("changeDate", function (e) {

              //on change function

              endDate = document.getElementById("cphMain_txtDateFrom").value;
              var presenrdate = endDate;
              var arrpresenrdate = presenrdate.split("-");

              var PresentSelectedDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
              var fromdate = PresentSelectedDate;

              //alert(PresentSelectedDate);
              PresentSelectedDate.setDate(PresentSelectedDate.getDate() + 1);
              //alert(PresentSelectedDate);

              //if (document.getElementById("cphMain_TextDateTo").value != "")
              //{

              //  alert("some")
              //    endDate = document.getElementById("cphMain_TextDateTo").value;
              //    var presenrdate = endDate;
              //    var arrpresenrdate = presenrdate.split("-");
              //    var PresentSelectedToDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
              //    PresentSelectedToDate.setDate(PresentSelectedToDate.getDate() + 1);
              //}



              $noCo("#Div1").datetimepicker('destroy', '');

              //var arrpresenrdate1 = presenrdate.split("-");
              //var PresentSelectedToDate1 = new Date(arrpresenrdate1[2], arrpresenrdate1[1] - 1, arrpresenrdate1[0]);


              var dd = PresentSelectedDate.getDate();
              var mm = PresentSelectedDate.getMonth() + 1;
              var yyyy = PresentSelectedDate.getFullYear();

              //alert(dd); alert(mm); alert(yyyy);
              //var b1 = PresentSelectedDate.split("-");  //p 
              //var b2 = new Date(b1[2], b1[1] - 1, b1[0]);


              //if (document.getElementById("cphMain_cbxStatus").checked == true && document.getElementById("cphMain_TextDateTo").value == "")
              //{

              //alert("ggg "+document.getElementById("cphMain_TextDateTo").value);


              //--------------0039-----------//

              if (dd < 10) {
                  dd = '0' + dd;
              }
              if (mm < 10) {
                  mm = '0' + mm;
              }
              //from day in 00 frmt
              document.getElementById("cphMain_TextDateTo").value = dd + "-" + mm + "-" + yyyy;


              //-----end----//
              //}

              //this function work when from date greater than to
              if (fromdate > PresentSelectedDate) {

                  ////document.getElementById("cphMain_TextDateTo").value = "";
                  document.getElementById("cphMain_TextDateTo").value = dd + "-" + mm + "-" + yyyy;

              }

              var year = (new Date).getFullYear();
              year = year + 2;
              $noCo('#Div1').datetimepicker({
                  format: 'dd-MM-yyyy',
                  language: 'en',
                  pickTime: false,
                  startDate: PresentSelectedDate,
                  endDate: new Date(year, '0', '0'),
                  setDate: null

              });
          });


          var presenrdate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
            var arrpresenrdate = presenrdate.split("-");
            var PresentFulDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
            PresentFulDate.setDate(PresentFulDate.getDate() + 2);



          //$noCo24("#Div1").datetimepicker('destroy', '');

          //var year = (new Date).getFullYear();
          //year = year + 2;
          //$noCo24('#Div1').datetimepicker({

          //    format: 'dd-MM-yyyy',
          //    language: 'en',
          //    pickTime: false,

          //    startDate: PresentFulDate,
          //    endDate: new Date(year, '0', '0'),
          //    setDate: null


          //});

        }

    </script>


     <style>

           .textDate:focus {
            border: 1px solid #bbf2cf;
            box-shadow: 0px 0px 4px 2.5px #bbf2cf;
        }
        .textDate {
            border: 1px solid #cfcccc;
        }
            .open > .dropdown-menu {
    display: none;
             }

            .bootstrap-datetimepicker-widget {

    z-index: 100;
}
              .eachform h2 {
                margin: 6px 0 6px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
 
     <asp:HiddenField ID="hiddenCancelReason" runat="server" />
    <asp:HiddenField ID="hiddenRoleReOpen" runat="server" />
    <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />
    <asp:HiddenField ID="hiddenremaingLev" runat="server" />
     <asp:HiddenField ID="hiddennoofleave" runat="server" />
     <asp:HiddenField ID="hiddenOpeningLev" runat="server" />
      <asp:HiddenField ID="hiddenremngNxtyrLv" runat="server" />
       <asp:HiddenField ID="hiddenFrmRem" runat="server" />
       <asp:HiddenField ID="hiddenToRem" runat="server" />
      <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
     <asp:HiddenField ID="hiddenfunReturn" runat="server" />
             <asp:HiddenField ID="hiddenstrid" runat="server" />
     <asp:HiddenField ID="hiddenHolidaychck" runat="server" />
     <asp:HiddenField ID="hiddenBlurchck" runat="server" />
     <asp:HiddenField ID="hiddenDutyoffunReturn" runat="server" />
     <asp:HiddenField ID="HiddenFieldOrg" runat="server" />
     <asp:HiddenField ID="HiddenFieldCorp" runat="server" />

     <asp:HiddenField ID="HiddenFieldHolidayChck" runat="server" />
    <asp:HiddenField ID="hiddenConfirmSts" runat="server" />
      <asp:HiddenField ID="HiddenOffDaySts" Value="0" runat="server" />
      <asp:HiddenField ID="HiddenOffDayCount"  Value="0" runat="server" />
     <asp:HiddenField ID="HiddenOFfdaysSts"  Value="1" runat="server" />
    <asp:HiddenField ID="hiddenOverRideLeavTypDate" runat="server" />
    <asp:HiddenField ID="hiddenOverRidedLeavTyp" runat="server" />
    <asp:HiddenField ID="hiddenLeaveTypId" runat="server" />

    <%-- 0041--%>

     <asp:HiddenField ID="HiddenLevstrtdtholidaysts"  runat="server" />
    <asp:HiddenField ID="HiddenLevenddtholidaysts" runat="server" />
    <asp:HiddenField ID="HiddenLevstrtdtoffdaysts" runat="server" />
    <asp:HiddenField ID="HiddenLevenddtoffdaysts" runat="server" />

    <%--end--%>

       <%--Start:-Code0009--%>
    <asp:HiddenField ID="HiddenFieldHoliPaidSts"  Value="0" runat="server" />
    <asp:HiddenField ID="HiddenFieldOffPaidSts"  Value="0" runat="server" />
       <%--End:-Code0009--%>
    <div class="cont_rght" style="min-height:300px;">

      <%--  0041--%>
                   <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>

     <br />

          <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:5%; top:42%;height:26.5px;">

            <%-- <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div class="fillform" style="width:100%;">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />

                   <div id="divImage" style="float: right;margin-right:30%;margin-top:-7%">
                       
                        <asp:ImageButton ID="imgbtnReOpen" runat="server" OnClientClick="return ConfirmReOpen();" Style="margin-left: 0%;" OnClick="imgbtnReOpen_Click" />
                         <p id="imgReOpen" class="imgDescription" style="color: white">ReOpen Confirmed Entry</p>
                    </div>

          
               <asp:UpdatePanel ID="updatepnl" runat="server">  
<ContentTemplate> 
           
    <div class="eachform" style=" float: left;margin-top: 0.5%; width:47%;">

                     <h2 style="margin-left: 0px;">Employee*</h2>
                <asp:DropDownList ID="ddlEmploye" Height="30px" Width="50%"  class="form1" onfocus="clearselect()" onkeydown="return DisableEnter(event)" OnSelectedIndexChanged="ddlEmploye_SelectedIndexChanged" AutoPostBack="true" runat="server" Style="margin-right: 2%;">
                  
                                   </asp:DropDownList>
                      </div>

           
    

     <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <div class="eachform" style="margin:auto;width:49%;float:right;">
                  <h2>Leave For Multiple days</h2>
                <div class="subform" style=" float: left;margin-top: 0.5%;width:49%; ">

                    <%--evm-0023-15-2--%>
                    <asp:CheckBox ID="cbxStatus" Text=""  OnCheckedChanged="CtrlChanged" AutoPostBack="true" runat="server"  onkeydown="return DisableEnter(event)"  class="form2" />
              
                   <%-- Checked="true"--%>
                  
                  
                </div>
                
                 
            </div>
     </ContentTemplate>  
</asp:UpdatePanel>
    <div class="clearfix"></div>
    <div style="width:100%;margin:auto;float:left;">
                <div id="divBank" class="eachform"  style="width:49%">

                          <h2>From Date*</h2>
               <div id="WaterCardExpiry" class="input-append date" style="font-family:Calibri;float:right;width:57.5%">
                 <asp:TextBox ID="txtDateFrom" class="textDate"  placeholder="DD-MM-YYYY" MaxLength="20" runat="server"   onchange="return ChangeDate();" onblur="return ChangeDate();" Style="width:83%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <input id= "imgDate" type="image" tabindex="-1" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onblur="return ChangeDate();" onchange="return ChangeDate();"  runat="server" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var presenrdate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                            var arrpresenrdate = presenrdate.split("-");
                            var PresentFulDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
                            PresentFulDate.setDate(PresentFulDate.getDate() + 1);
                            var fromdate = document.getElementById("<%=txtDateFrom.ClientID%>").value;

                            var $noCo = jQuery.noConflict();
                            var year = (new Date).getFullYear();
                            year = year + 2;
                            $noCo('#WaterCardExpiry').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(year, '0', '0'),
                                startDate: PresentFulDate,
                            }).on("changeDate", function (e) {
                                endDate = document.getElementById("cphMain_txtDateFrom").value;
                                var presenrdate = endDate;
                                var arrpresenrdate = presenrdate.split("-");
                                var PresentSelectedDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
                                PresentSelectedDate.setDate(PresentSelectedDate.getDate() + 2);

                                if (document.getElementById("cphMain_TextDateTo").value != "") {
                                    endDate = document.getElementById("cphMain_TextDateTo").value;
                                    var presenrdate = endDate;
                                    var arrpresenrdate = presenrdate.split("-");
                                    var PresentSelectedToDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
                                    PresentSelectedToDate.setDate(PresentSelectedToDate.getDate() + 2);
                                }

                                $noCo("#Div1").datetimepicker('destroy', '');


                                var arrpresenrdate1 = presenrdate.split("-");
                                var PresentSelectedToDate1 = new Date(arrpresenrdate1[2], arrpresenrdate1[1] - 1, arrpresenrdate1[0]);
                                if (document.getElementById("cphMain_cbxStatus").checked == true && document.getElementById("cphMain_TextDateTo").value == "") {
                                    //document.getElementById("cphMain_TextDateTo").value = parseInt(arrpresenrdate1[0]) + 1 + "-" + arrpresenrdate1[1] + "-" + arrpresenrdate1[2];
                                }

                                if (PresentSelectedDate > PresentSelectedToDate) {
                                    document.getElementById("cphMain_TextDateTo").value = "";
                                }


                                var year = (new Date).getFullYear();
                                year = year + 2;
                                $noCo('#Div1').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    startDate: PresentSelectedDate,
                                    endDate: new Date(year, '0', '0'),
                                    setDate: null,
                                    defaultDate: '',
                                });

                            });






                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>

            </div>
    <div class="eachform" style="width: 49%; float: right;">
       <h2>Session From*</h2>    
                  <asp:DropDownList ID="ddlSecnFrom" Height="30px" Width="54%" class="form1" onkeydown="return DisableEnter(event)" onchange="return ddlSecToIndexChanged()" runat="server" Style="margin-right: 4%;">
                         <asp:ListItem Text="--SELECT FROM--" Value="0"></asp:ListItem>
                     <asp:ListItem Text="FULL DAY" Value="1"></asp:ListItem>
                     <asp:ListItem Text="FIRST SESSION" Value="2"></asp:ListItem>
                      <asp:ListItem Text="SECOND SESSION" Value="3"></asp:ListItem>
                  </asp:DropDownList>
        <br />
        <div style="width:100%;margin:auto;float:left;margin-top:16px;">

        <h2 id="hTosec" runat="server">Session To</h2>    
                  <asp:DropDownList ID="ddlSecTo" Height="30px" Width="54%" class="form1" onkeydown="return DisableEnter(event)"  onchange="return ddlSecToIndexChanged()"  runat="server" Style="margin-right: 4%;">

                        <asp:ListItem Text="--SELECT TO--" Value="0"></asp:ListItem>
                     <asp:ListItem Text="FULL DAY" Value="1"></asp:ListItem>
                     <asp:ListItem Text="FIRST SESSION" Value="2"></asp:ListItem>
                      <%--<asp:ListItem Text="SECOND SECTION" Value="3"></asp:ListItem>--%>
                  </asp:DropDownList>
            </div>


    </div>
           


                    
 
         <div class="eachform" style="width:49%">
             <h2 id="hTodate" runat="server">To Date</h2>
               <div id="Div1" class="input-append date" style="font-family:Calibri;float:right;width:57.5%">
                 <asp:TextBox ID="TextDateTo" class="textDate"  onchange="return ddlSecToIndexChanged()" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"   Style="width:83%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <input id= "img1" type="image" tabindex="-1" class="add-on" src="../../../Images/Icons/CalandarIcon.png"  onblur="return ddlSecToIndexChanged()" runat="server"  style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">



                            if (document.getElementById("<%=TextDateTo.ClientID%>").value != "") {
                                var presenrdate = document.getElementById("<%=TextDateTo.ClientID%>").value;
                                var arrpresenrdate = presenrdate.split("-");
                                var PresentFulDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
                                PresentFulDate.setDate(PresentFulDate.getDate() + 1);
                            }
                            else {
                                var presenrdate = document.getElementById("<%=txtDateFrom.ClientID%>").value;
                                var arrpresenrdate1 = presenrdate.split("-");
                                var PresentSelectedToDate1 = new Date(arrpresenrdate1[2], arrpresenrdate1[1] - 1, arrpresenrdate1[0]);

                                var PresentFulDate = new Date(arrpresenrdate1[2], arrpresenrdate1[1] - 1, arrpresenrdate1[0]);
                                PresentFulDate.setDate(PresentFulDate.getDate() + 2);


                                if (document.getElementById('cphMain_TextDateTo').disabled == false) {
                                    document.getElementById("cphMain_TextDateTo").value = parseInt(arrpresenrdate1[0]) + 1 + "-" + arrpresenrdate1[1] + "-" + arrpresenrdate1[2];
                                }

                            }

                            var $noCon = jQuery.noConflict();
                            var year = (new Date).getFullYear();
                            year = year + 2;
                            $noCon('#Div1').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: PresentFulDate,
                                endDate: new Date(year, '0', '0'),
                                setDate: null

                            }).on("changeDate", function (e) {



                            });
                        </script>


                         <p style="visibility: hidden">Please enter</p>
                    </div>
                   </div>

              <div class="eachform"  style="width:49%;float: right;">         
                 
             </div>
                         
     
         <div class="eachform" style="width:49%">
             <h2>Leave Type*</h2>
  <asp:DropDownList ID="ddlLeavTyp" Height="30px" Width="54%" class="form1" onkeydown="return DisableEnter(event)" onchange="ddlLevtyponchge()"  runat="server" Style="margin-right: 4%;"></asp:DropDownList>
                   </div>
               
         
               
            <div class="eachform"" style="width:49%;">
                <h2>Number Of Leave Days</h2>

                 <asp:TextBox ID="NumOfLev" Enabled="false" Height="30px" Width="51.5%" class="form1" runat="server" MaxLength="12" Style="text-transform: uppercase;text-align:left; margin-right: 3%;border-color: white;background-color: #e3e3e3;"  ></asp:TextBox>
              <%--  <asp:Label ID="NumOfLev"
           Text=""
          
           runat="server"/>--%>
                </div>
          <%--  end--%>
              <div class="eachform"" style="width:49%;float: right;">
                <h2>Balance Leave Count</h2>

                    <asp:TextBox ID="YearlyLev" Enabled="false" Height="30px" Width="51.5%" class="form1" runat="server" MaxLength="12" Style="text-transform: uppercase;text-align:left; margin-right: 3%;border-color: white;background-color: #e3e3e3;"  ></asp:TextBox>
                 <%-- <span id="cphMain_YearlyLev"   style="display:inline-block;height:30px;width:54%;margin-left: 17%;float: left;padding-top: 7px;">
                <asp:Label  ID="YearlyLev" 
           Text=""
          onchange="return ddlSecToIndexChanged()"
           runat="server"   >
                    </asp:Label></span>--%>
                </div>
                              <div class="eachform"" style="width:49%;float: left">
                                          <div id="DivFixedAllowance" runat="server" style="">
                                                   <section style=">
                                                    <div   class="smart-form"> 
                                                          <h2>Include In Settlement</h2>
                                                        <%-- <label class="lblh2" for="inputPassword" style="margin-bottom:3px;width: 33%;float: left;">Fixed allowance Applicable</label>--%>
                                                          <%--     <div class="col-sm-8">--%>
                                                                        <div   class="smart-form" style="">    
                                                                                <label class="checkbox" style="/*! float: right; */margin-left: 15%;margin-bottom: 0%;font-size: 13px;">Yes
                                                                                <input type="checkbox" id="cbxSettlement" onclick="cbxSettlementClick();" onkeypress="return DisableEnter(event)" runat="server" />
                                                                                <i  ></i> </label>
                                                                        </div>
                                                           <%--    </div>   --%>
                                                    </div>

                                                <br/>
                                                 <div   class="smart-form" id ="divcbxSettlementleaveallocation" runat="server" style="display:none"> 
                                                          <h2 style="width: 30.5%;">Settlement eligible with leave allocation</h2>
                                                        <%-- <label class="lblh2" for="inputPassword" style="margin-bottom:3px;width: 33%;float: left;">Fixed allowance Applicable</label>--%>
                                                          <%--     <div class="col-sm-8">--%>
                                                                        <div   class="smart-form" style="">    
                                                                                <label class="checkbox" style="/*! float: right; */margin-left: 15%;margin-bottom: 0%;font-size: 13px;">Yes
                                                                                <input type="checkbox" id="cbxElgblLeavAllctn"  onkeypress="return DisableEnter(event)" runat="server" />
                                                                                <i  ></i> </label>
                                                                        </div>
                                                           <%--    </div>   --%>
                                                    </div>


                                            </section>
                                              </div>
                                </div> 


            <br />
            <div class="eachform">
                <div class="subform" style="width: 62%; margin-top:5%">

                      <asp:Button ID="btnConfirm" runat="server" class="save" Text="Confirm" OnClick="btnConfirm_Click" OnClientClick="return WaterCardValidate('UPD');"/>
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return WaterCardValidate('UPD');"/>
                      <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return WaterCardValidate('UPD');"/>
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return WaterCardValidate('INS');"/>
                     <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return WaterCardValidate('INS');"/>
                     <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" PostBackUrl="~/AWMS/AWMS_Transaction/Leave_Allocation_Master/Leave_Allocation_Master_List.aspx"/>
                 <asp:Button ID="btnClear" runat="server" style="margin-left: 13px;" OnClientClick="return AlertClearAll();" OnClick="btnClear_Click" class="cancel" Text="Clear"/>
                </div>
            </div>


    </div>
    </div>


</asp:Content>
