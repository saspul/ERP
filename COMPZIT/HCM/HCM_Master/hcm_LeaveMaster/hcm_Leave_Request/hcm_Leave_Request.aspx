<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Leave_Request.aspx.cs" Inherits="HCM_HCM_Master_hcm_OnBoarding_hcm_Leave_Management_hcm_Leave_Request" %>

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
                       window.location.href = "hcm_Leave_Request_List.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "hcm_Leave_Request_List.aspx";

               }
           }

           function AlertClearAll() {
               if (confirmbox > 0) {
                   if (confirm("Are you sure you want clear all data in this page?")) {
                       window.location.href = "hcm_Leave_Request.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "hcm_Leave_Request.aspx";

               }
           }
           function CancelAlert() {
               if (confirmbox > 0) {
                   if (confirm("Are you sure you want to cancel this page?")) {
                       window.location.href = "hcm_Leave_Request_List.aspx";
                       return false;
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "hcm_Leave_Request_List.aspx";
                   return false;

               }
           }

    </script>
    <script src="../../../../JavaScript/jquery-1.8.3.min.js"></script>
   

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            LoadLeaveTypes();


            //EVM-0027 08-02-2019
            changeTrvlDtl();
            //END
            if (document.getElementById("<%=hiddenDupWithWarningMsg.ClientID%>").value == "1") {
                document.getElementById("<%=hiddenDupWithWarningMsg.ClientID%>").value = "1";
            }
            else {
                document.getElementById("<%=hiddenDupWithWarningMsg.ClientID%>").value = "0";
            }


            if (document.getElementById("<%=HiddenTrvlSts.ClientID%>").value == "0")
            {
             document.getElementById("divcbdTrvlNd").style.display = "block";
         
                     
         }



            if (document.getElementById("<%=status1.ClientID%>").innerText == "Rejected") {
                document.getElementById("<%=status2.ClientID%>").style.color = "rgb(144, 130, 124)";
                document.getElementById("<%=status2.ClientID%>").style.fontSize = "16px";
              
                
            }


            if (document.getElementById("<%=HiddenFieldConfirm.ClientID%>").value == "1") {
                document.getElementById("divStatus").style.display = "block";
            }
            if (document.getElementById("<%=HiddenTrvlSts.ClientID%>").value == "0")
            {
              
              document.getElementById("divcbdTrvlNd").style.display = "block";
           }
            if (document.getElementById("<%=HiddenTrvlSts.ClientID%>").value == "1")
            {

              document.getElementById("divcbdTrvlNd").style.display = "block";
        }

            if (document.getElementById("<%=HiddenFieldShowCancel.ClientID%>").value == "true" && document.getElementById("<%=HiddenFieldExpiredSts.ClientID%>").value != "Exp") {
                
                if (document.getElementById("<%=HiddenFieldCancelUsrRole.ClientID%>").value == "1") {
                    document.getElementById("cphMain_divAirptClose").style.display = "block";
                }
                if (document.getElementById("<%=HiddenFieldEmpType.ClientID%>").value == "0") {
                    document.getElementById("cphMain_btnClearanceLink").style.display = "block";
                }
            }
            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                mulCbxChange();
            }
            document.getElementById("<%=HiddenFieldDepntIds.ClientID%>").value = null;
            
            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {

                IncrmntConfrmCounter();
            }
            if (document.getElementById("<%=hiddennoofleave.ClientID%>").value != "") {
                var numlev = document.getElementById("<%=hiddennoofleave.ClientID%>").value;
                document.getElementById("<%=NumOfLev.ClientID%>").value = numlev;
            }
          
            if (document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value != "") {
                var numlev = document.getElementById("<%=hiddennoofleave.ClientID%>").value;
                var Yerlylev = document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value;
                var BalanceLeavCount = parseFloat(Yerlylev) - parseFloat(numlev)
                //document.getElementById("<%=YearlyLev.ClientID%>").value = Yerlylev;
                document.getElementById("<%=YearlyLev.ClientID%>").value = BalanceLeavCount;

            }






        });
    </script>
   

        <script type="text/javascript">
            function DuplicationConfm() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirm denied.The selected days are already confirmed";
               
            }

            function CheckReportingOfficer() {
                document.getElementById("<%=hiddenReportOffcr.ClientID%>").value = "1";
             //   alert("Enter");
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Sorry.Selected employee does not have reporting officer.";
                return false;
            }
          

           
            function EpmlyInUsr() {
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
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,selected day is holiday";
                }

                function SameDateSelected() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,from date and to date should not be same";
                }

                function SuccessConfirmation() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave request details inserted successfully.";
                }

                function SuccessUpdation() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave request details updated successfully.";
                }

                function SuccessReOpen() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave request details reopened successfully.";
                }

                function SuccessConfirm() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave request details confirmed successfully.";
                }

            function successClose() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave request details cancelled successfully.";
            }
            function SuccessAddStaff() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance staff form details inserted successfully.";
            }
            function SuccessUpdStaff() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance staff form details updated successfully.";
            }
            function DuplicationLevDate() {   //emp25
                ddlSecToIndexChanged1();
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error.Leave Already Applied for Selected Days ";
                document.getElementById("<%=HiddenFieldDup.ClientID%>").value = "true";
                document.getElementById("<%=hiddenDupWithWarningMsg.ClientID%>").value = "1";
                
             
               
            }
            function FaildAllocation() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Sorry.Selected date does not have any leave.";

            }
            function servcecall(LeavDateFrom, EmpId, LeavTypId) {
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
                                var NumOfLeav = document.getElementById("<%=NumOfLev.ClientID%>").value
                                var YearlyLeavCount = parseInt(response.d) - parseInt(NumOfLeav);

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

                                    //ret = false;
                                  //  document.getElementById("<%=NumOfLev.ClientID%>").value = 0;
                                  //     document.getElementById("<%=YearlyLev.ClientID%>").value = 0;

                                  //  document.getElementById("<%=txtDateFrom.ClientID%>").value = "";

                                 //   document.getElementById("<%=TextDateTo.ClientID%>").value = "";
                                  //  document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "red";

                                  //  document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "red";

                                    //   alert();
                              //      FaildAllocation();
                               //     return false;


                                    var opngLev = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;
                                    //var RemaingLev= document.getElementById("<%=hiddenremaingLev.ClientID%>").value;

                                    //  var totalLev = parseFloat(opngLev) + parseFloat(yerlylevcount);  

                                    document.getElementById("<%=YearlyLev.ClientID%>").value = opngLev;
                                    document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value = opngLev;
                                    document.getElementById("<%=hiddenFrmRem.ClientID%>").value = opngLev;


                                 //   var opngLev = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;
                                    //var RemaingLev= document.getElementById("<%=hiddenremaingLev.ClientID%>").value;

                                    //  var totalLev = parseFloat(opngLev) + parseFloat(yerlylevcount);
                                   // document.getElementById("<%=YearlyLev.ClientID%>").value = opngLev;
                                   // document.getElementById("<%=hiddenremngNxtyrLv.ClientID%>").value = opngLev;
                                   // document.getElementById("<%=hiddenFrmRem.ClientID%>").value = opngLev;
                                }

                            }
                        }


                    });
                if (ret == false) {
                    document.getElementById("<%=NumOfLev.ClientID%>").value = 0;
                     document.getElementById("<%=YearlyLev.ClientID%>").value = 0;

                 }
                }
               
                function mulCbxChange() {
                    if (document.getElementById("<%=cbxStatus.ClientID%>").checked == true && document.getElementById("<%=HiddenFieldConfirm.ClientID%>").value !="1") {
                        document.getElementById("cphMain_TextDateTo").disabled = false;
                        //EVM-0027 08-02-2019
                        document.getElementById("cphMain_img1").tabIndex = 0;
                        //END
                        document.getElementById("cphMain_img1").style.pointerEvents = "";
                        document.getElementById("cphMain_ddlSecTo").disabled = false;
                        document.getElementById("cphMain_hTodate").innerText = "To Date*";
                        document.getElementById("cphMain_hTosec").innerText = "Session To*";
                    }
                    else if (document.getElementById("<%=cbxStatus.ClientID%>").checked == false) {
                        document.getElementById("cphMain_TextDateTo").disabled = true;
                        //EVM-0027 08-02-2019
                        document.getElementById("cphMain_img1").tabIndex =-1;
                        //END
                        document.getElementById("cphMain_img1").style.pointerEvents = "none";
                        document.getElementById("cphMain_ddlSecTo").disabled = true;
                        document.getElementById("cphMain_hTodate").innerText = "To Date";
                        document.getElementById("cphMain_hTosec").innerText = "Session To";
                        document.getElementById("cphMain_TextDateTo").value = "";
                        document.getElementById("cphMain_ddlSecTo").value = 0;
                    }
                   
                    if (document.getElementById("<%=HiddenFieldDup.ClientID%>").value != "true" && document.getElementById("<%=HiddenFieldConfirm.ClientID%>").value!= "1") {                       
                    ddlSecToIndexChanged1();
                    }
                    else {
                        document.getElementById("<%=HiddenFieldDup.ClientID%>").value = "false";
                    }
                }

            // EVM 0041 

            //start
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
                    if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "0") {
                        if (ToLev > 0) {
                            document.getElementById("<%=HiddenOffDaySts.ClientID%>").value = "1";


                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning,  The Starting date you have  selected is holiday   !";

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
                    if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "0") {
                        if (ToLev > 0) {
                            document.getElementById("<%=HiddenOffDaySts.ClientID%>").value = "1";


                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning,  The Ending date you have  selected is holiday   !";

                        }
                    }



                }
            }




            //
            function CountHolidayTo(LeavDateFrom) {


                if (document.getElementById("<%= HiddenLevstrtdtholidaysts.ClientID%>").value == "0") {

                    var ToLev = 0;
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


                    // alert(LeavDateFrom);
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
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, The Starting date you have  selected is offday  !";
                                ret = false;
                            }
                        }


                    });
                }


            }

            //

            function DutyOfChkgEnddt(LeavDateTo) {


                if (document.getElementById("<%=HiddenLevenddtoffdaysts.ClientID%>").value == "0") {


                    // alert(LeavDateFrom);
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
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, The Ending date you have  selected is offday  !";
                                ret = false;
                            }
                        }


                    });
                }


            }

            //END

                function DutyOfChkgdateRange(LeavDateFrom, LeaveDateTo) {
               
                    var orgid = document.getElementById("<%=HiddenFieldOrg.ClientID%>").value;
                    var corpid = document.getElementById("<%=HiddenFieldCorp.ClientID%>").value;



                    var dutyoff = 0;
                    if (document.getElementById("<%=HiddenFieldHolidayChck.ClientID%>").value != "0") {
                        var HoliPaidSts = document.getElementById("<%=HiddenFieldHoliPaidSts.ClientID%>").value;
                        var OffPaidSts = document.getElementById("<%=HiddenFieldOffPaidSts.ClientID%>").value;

                        var Details = PageMethods.ReadDutyofChkDateRanges(LeavDateFrom, orgid, corpid, LeaveDateTo, HoliPaidSts, OffPaidSts, function (response) {


                            if (response != 0) {
                                dutyoff = response;
                                //  ddlSecToIndexChanged();


                            }
                            else {
                                dutyoff = 0;
                                // ddlSecToIndexChanged();


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
                            document.getElementById("<%=hiddenfunReturn.ClientID%>").value = ToLev;

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

                            if (data.d != '') {


                                document.getElementById("<%=hiddenfunReturn.ClientID%>").value = data.d;
                        }
                    },
                    error: function (result) {
                        // alert("Error");
                    }
                });
            }

            function CloseRqst() {
                if (confirm("Are you sure you want to cancel this leave request?")) {
            
                    var UserId = document.getElementById("<%=hiddenEmployeeId.ClientID%>").value;
                    var LeaveRqstId = document.getElementById("<%=hiddenstrid.ClientID%>").value;
                    var Details = PageMethods.CancelRqst(LeaveRqstId, UserId, function (response) {

                        window.location.href = "hcm_Leave_Request_List.aspx?InsUpd=Cncl";
                        //document.getElementById("cphMain_divAirptClose").style.display = "none";
                        //document.getElementById("cphMain_btnClearanceLink").style.display = "none";
                        //successClose();
                    });
                }
            }
           

            function dutyoffFun() {
                var ret = true;



                document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
                   document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "";
               
                var LeavDateFrm = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();

                 var LeavDateTo = document.getElementById("<%=TextDateTo.ClientID%>").value.trim();

                var EmpId = document.getElementById("<%=hiddenEmployeeId.ClientID%>").value;



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
                if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "0") {

                    //evm 0041

                    CountHoliday(LeavDateFrom);
                    CountHolidayEnddt(LeavDateTo);
                    DutyOfChkg(LeavDateFrom);
                    DutyOfChkgEnddt(LeavDateTo);
                    //end

                    document.getElementById("<%=HiddenOffDaySts.ClientID%>").value = 0;
                }
                
                if (document.getElementById("<%=HiddenOffDaySts.ClientID%>").value == "1") {
                    //return false;
                }

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

                                //end
                                        NumOfHolFrm = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;


                                        YearComprsn = 1;
                                        var FrmLeav = 0;
                                        var ToLev = 0;
                                        var RemlevTotal;

                                       // CountHolidayTo(LeaveDateTo)
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


                                                      //  document.getElementById("<%=YearlyLev.ClientID%>").value = 0;


                                                       // document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "red";





                                                    //    document.getElementById("<%=NumOfLev.ClientID%>").value = 0;
                                                      //  document.getElementById("<%=txtDateFrom.ClientID%>").value = "";
//
                                                      //  FaildAllocation();
                                                      //  ret = false;
                                                      //  return false;


                                                        FrmLeav = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;
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
                                                       // document.getElementById("<%=YearlyLev.ClientID%>").value = 0;

                                                       // document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "red";


                                                       /// ToLev = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;
                                                      //  document.getElementById("<%=NumOfLev.ClientID%>").value = 0;

                                                      //  document.getElementById("<%=TextDateTo.ClientID%>").value = "";
                                                       // ret = false;

                                                       // FaildAllocation();
                                                      //  return false;

                                                       ToLev = document.getElementById("<%=hiddenOpeningLev.ClientID%>").value;
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
                                     var numdaysNew = numdays-Dutyoff;
                                     if (ret == true) {

                                         if (yerlylevcount < numdaysNew && yerlylevcount != 0) {
                                             document.getElementById('divMessageArea').style.display = "";
                                             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";                                                                                         
                                             if (document.getElementById("<%=hiddenDupWithWarningMsg.ClientID%>").value == "1") {
                                               //  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error.Leave Already Applied for Selected Days."
                                             }
                                             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, number of leave exceed yearly leave count !";
                                             document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "Red";
                                         }
                                         if (YearComprsn == 0) {
                                             NumOfHolFrm = parseFloat(NumOfHolFrm) + parseFloat(Dutyoff);

                                             if (Dutyoff == 0) {

                                                 numdays = parseFloat(numdays);
                                                 document.getElementById("<%=hiddennoofleave.ClientID%>").value = numdays;
                                                 document.getElementById("<%=NumOfLev.ClientID%>").value = numdays;
                                             }
                                             else {
                                                 if (numdays > Dutyoff) {
                                                     //alert('numdays=' + numdays);
                                                     //alert('Dutyoff=' + Dutyoff);
                                                     //  var ComLevHol = numdays - NumOfHolFrm;
                                                     var ComLevHol = numdays - Dutyoff;
                                                     //alert('ComLevHol=' + ComLevHol);
                                                     //alert('yerlylevcount=' + yerlylevcount);
                                                     document.getElementById("<%=hiddennoofleave.ClientID%>").value = ComLevHol;
                                                     document.getElementById("<%=NumOfLev.ClientID%>").value = ComLevHol;
                                                     if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "1") {
                                                         if (yerlylevcount >= ComLevHol) {
                                                             document.getElementById('divMessageArea').style.display = "none";
                                                             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";

                                                             ConvertDecToWords(Dutyoff);
                                                             var numinWords = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;
                                                             if (Dutyoff == 1) {
                                                                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, in selected leave period there is '" + numinWords + "' holiday  !";
                                                             }
                                                             else {
                                                                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, in selected leave period  there are '" + numinWords + "' holidays  !";
                                                             }

                                                         }
                                                         else {

                                                             document.getElementById('divMessageArea').style.display = "";
                                                             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";

                                                             ConvertDecToWords(Dutyoff);
                                                             var numinWords = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;
                                                             if (Dutyoff == 1) {
                                                                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning,  in selected leave period  there is '" + numinWords + "' holiday and  number of leave exceed yearly leave count !";
                                                             }
                                                             else {
                                                                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning,  in selected leave period  there are '" + numinWords + "' holidays and  number of leave exceed yearly leave count !";
                                                             }
                                                             document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "Red";
                                                         }
                                                     }
                                                 }
                                                 else {
                                                     document.getElementById("<%=hiddenHolidaychck.ClientID%>").value = 1;
                                                     document.getElementById('divMessageArea').style.display = "";
                                                     document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                     document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning,  selected days were holidays  !";
                                                     ret = false;
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
                                                     if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "1") {
                                                         if (yerlylevcount >= ComLevHol) {
                                                             document.getElementById('divMessageArea').style.display = "none";
                                                             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                             ConvertDecToWords(Dutyoff);
                                                             var numinWords = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;
                                                             if (Dutyoff == 1) {
                                                                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, in selected leave period there is '" + numinWords + "' holiday  !";
                                                             }
                                                             else {
                                                                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, in selected leave period there are '" + numinWords + "' holidays  !";
                                                             }

                                                         }
                                                         else {

                                                             document.getElementById('divMessageArea').style.display = "";
                                                             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                                             ConvertDecToWords(totalHol);
                                                             var numinWords = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;
                                                             if (totalHol == 1) {
                                                                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, in selected leave period there is '" + numinWords + "' holiday and  number of leave exceed yearly leave count!";
                                                             }
                                                             else {
                                                                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, in selected leave period there are '" + numinWords + "' holidays and  number of leave exceed yearly leave count!";
                                                             }
                                                             document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "Red";
                                                         }
                                                     }

                                                 }

                                                 else {
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
                        if (ret == true) {
                            var BlnceLeavCount = parseFloat(yerlylevcount) - parseFloat(numdays);

                            document.getElementById("<%=YearlyLev.ClientID%>").value = BlnceLeavCount;
                        }
                      }
                            else {
                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "To date should be greater than from date";
                                document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "Red";
                                ret = false;

                            }

                }




                if (ret == false) {
                    document.getElementById("<%=NumOfLev.ClientID%>").value = 0;
                     document.getElementById("<%=YearlyLev.ClientID%>").value = 0;

                }
                

                ////////////
        }

                function WaterCardValidate() {

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


                    var LeavDateFrm = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();
                    var LeavDateTo = document.getElementById("<%=TextDateTo.ClientID%>").value.trim();

                    var arrFrmDate = LeavDateFrm.split("-");
                    var dateFrmDte = new Date(arrFrmDate[2], arrFrmDate[1] - 1, arrFrmDate[0]);

                    var arrToDate = LeavDateTo.split("-");
                    var dateToDte = new Date(arrToDate[2], arrToDate[1] - 1, arrToDate[0]);

                   

                    var Typddl = document.getElementById("<%=ddlLeavTyp.ClientID%>");
                    var LeavTyp = Typddl.options[Typddl.selectedIndex].text;

                    var ddlsecF = document.getElementById("<%=ddlSecnFrom.ClientID%>");
                    var ddlSecFrmChk = ddlsecF.options[ddlsecF.selectedIndex].text;

                 
                    //Start:-For travel details
                  //  alert(document.getElementById("<%=HiddenFieldTrvlDtlsVisible.ClientID%>").value);
                    if (document.getElementById("<%=HiddenFieldTrvlDtlsVisible.ClientID%>").value == "true") {
                        var CrdExpWithoutReplace = document.getElementById("<%=txtCmnt.ClientID%>").value.trim();
                        var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                        var replaceCode2 = replaceCode1.replace(/>/g, "");
                        document.getElementById("<%=txtCmnt.ClientID%>").value = replaceCode2;

                        var CrdExpWithoutReplace = document.getElementById("<%=txtAddrss.ClientID%>").value.trim();
                        var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                        var replaceCode2 = replaceCode1.replace(/>/g, "");
                        document.getElementById("<%=txtAddrss.ClientID%>").value = replaceCode2;

                        var CrdExpWithoutReplace = document.getElementById("<%=txtTelNo.ClientID%>").value.trim();
                        var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                        var replaceCode2 = replaceCode1.replace(/>/g, "");
                        document.getElementById("<%=txtTelNo.ClientID%>").value = replaceCode2;


                        var CrdExpWithoutReplace = document.getElementById("<%=txtLclCntctNo.ClientID%>").value.trim();
                        var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                        var replaceCode2 = replaceCode1.replace(/>/g, "");
                        document.getElementById("<%=txtLclCntctNo.ClientID%>").value = replaceCode2;


                        var CrdExpWithoutReplace = document.getElementById("<%=txtEmail.ClientID%>").value.trim();
                        var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                        var replaceCode2 = replaceCode1.replace(/>/g, "");
                        document.getElementById("<%=txtEmail.ClientID%>").value = replaceCode2;

                        var CrdExpWithoutReplace = document.getElementById("<%=txtDateTrvl.ClientID%>").value;
                        var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                        var replaceCode2 = replaceCode1.replace(/>/g, "");
                        document.getElementById("<%=txtDateTrvl.ClientID%>").value = replaceCode2;

                        var CrdExpWithoutReplace = document.getElementById("<%=txtDateRetrn.ClientID%>").value;
                        var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                        var replaceCode2 = replaceCode1.replace(/>/g, "");
                        document.getElementById("<%=txtDateRetrn.ClientID%>").value = replaceCode2;

                        var CrdExpWithoutReplace = document.getElementById("<%=txtDestntn.ClientID%>").value.trim();
                        var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                        var replaceCode2 = replaceCode1.replace(/>/g, "");
                        document.getElementById("<%=txtDestntn.ClientID%>").value = replaceCode2;

                        var CrdExpWithoutReplace = document.getElementById("<%=txtAirLine.ClientID%>").value.trim();
                        var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                        var replaceCode2 = replaceCode1.replace(/>/g, "");
                        document.getElementById("<%=txtAirLine.ClientID%>").value = replaceCode2;

                        document.getElementById("<%=txtDateTrvl.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtDateRetrn.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtDestntn.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtAirLine.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtAddrss.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtTelNo.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtLclCntctNo.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtCmnt.ClientID%>").style.borderColor = "";

                        var DateTrvl = document.getElementById("<%=txtDateTrvl.ClientID%>").value;
                        var DateRetrn = document.getElementById("<%=txtDateRetrn.ClientID%>").value;
                        var Destntn = document.getElementById("<%=txtDestntn.ClientID%>").value;
                        var Airline = document.getElementById("<%=txtAirLine.ClientID%>").value;
                        var Address = document.getElementById("<%=txtAddrss.ClientID%>").value;
                        var TeleNo = document.getElementById("<%=txtTelNo.ClientID%>").value;
                        var LclContactNo = document.getElementById("<%=txtLclCntctNo.ClientID%>").value;
                        var Email = document.getElementById("<%=txtEmail.ClientID%>").value;
                        var Cmnt = document.getElementById("<%=txtCmnt.ClientID%>").value;


                        document.getElementById('ErrorLclNum').style.display = "none";
                        document.getElementById('ErrorTele').style.display = "none";
                        document.getElementById('ErrorEnqEmail').style.display = "none";

                        var presenrdate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                        var arrpresenrdate = presenrdate.split("-");
                        var datepresenrdate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);

                        var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                        var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;
                        //EVM-0027 08-02-2019
                       // var mobileregular = /\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\d{1,12}$/;
                        //END


                        if (Email != "") {
                            if (!filter.test(Email)) {
                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById('ErrorEnqEmail').style.display = "block";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtEmail.ClientID%>").focus();
                                ret = false;
                            }
                        }
                        if (LclContactNo != "") {    // emp25
                            if (!mobileregular.test(LclContactNo)) {
                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById('ErrorLclNum').style.display = "block";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                document.getElementById("<%=txtLclCntctNo.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtLclCntctNo.ClientID%>").focus();
                                ret = false;
                            }
                        }
                       // if (LclContactNo == "") {     emp25
                          //  document.getElementById('divMessageArea').style.display = "";
                        //    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";                        
                         //   document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                         //   document.getElementById("<%=txtLclCntctNo.ClientID%>").style.borderColor = "Red";
                        //    document.getElementById("<%=txtLclCntctNo.ClientID%>").focus();
                         //   ret = false;
                       // }
                       // else {

                           
                      //  }



                        if (TeleNo == "") {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=txtTelNo.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtTelNo.ClientID%>").focus();
                            ret = false;
                        }
                        else {

                            if (!mobileregular.test(TeleNo)) {
                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById('ErrorTele').style.display = "block";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                document.getElementById("<%=txtTelNo.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtTelNo.ClientID%>").focus();
                                ret = false;
                            }
                        }
                        //For Current date checking
                        if (DateRetrn == "") {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=txtDateRetrn.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtDateRetrn.ClientID%>").focus();
                            ret = false;
                        }

                        else {


                            var arrpresenrdateRetrn = DateRetrn.split("-");
                            var datepresenrdateRetrn = new Date(arrpresenrdateRetrn[2], arrpresenrdateRetrn[1] - 1, arrpresenrdateRetrn[0]);
                            if (datepresenrdateRetrn < datepresenrdate) {

                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, date of return should be greater than  or equal to current date !";
                                document.getElementById("<%=txtDateRetrn.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtDateRetrn.ClientID%>").focus();
                                ret = false;

                            }

                        }


                      //  if (Destntn == "") {    emp25
                        //    document.getElementById('divMessageArea').style.display = "";
                          //  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                          //  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            //document.getElementById("<%=txtDestntn.ClientID%>").style.borderColor = "Red";
                           // document.getElementById("<%=txtDestntn.ClientID%>").focus();
                          //  ret = false;
                     //   }



                        if (DateTrvl == "") {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=txtDateTrvl.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtDateTrvl.ClientID%>").focus();
                            ret = false;
                        }

                        else {


                            var arrpresenrdateRetrn = DateTrvl.split("-");
                            var datepresenrdateRetrn = new Date(arrpresenrdateRetrn[2], arrpresenrdateRetrn[1] - 1, arrpresenrdateRetrn[0]);
                            if (datepresenrdateRetrn < datepresenrdate) {

                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, date of travel should be greater than  or equal to current date !";
                                document.getElementById("<%=txtDateTrvl.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtDateTrvl.ClientID%>").focus();
                                ret = false;

                            }

                        }
                        if (DateTrvl != "" && DateRetrn != "") {
                          
                            var arrpresenrdateRetrn = DateRetrn.split("-");
                            var datepresenrdateRetrn = new Date(arrpresenrdateRetrn[2], arrpresenrdateRetrn[1] - 1, arrpresenrdateRetrn[0]);


                            var arrpresenrdateTrvl = DateTrvl.split("-");
                            var datepresenrdateTrvl = new Date(arrpresenrdateTrvl[2], arrpresenrdateTrvl[1] - 1, arrpresenrdateTrvl[0]);

                            if (datepresenrdateRetrn < datepresenrdateTrvl) {


                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, date of travel should be greater than  or equal to date of return !";
                                document.getElementById("<%=txtDateTrvl.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtDateRetrn.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtDateTrvl.ClientID%>").focus();
                                ret = false;

                            }

                    }

                    }
                   
                  



                    //End:-For travel details

                 
                    var ddlsecT = document.getElementById("<%=ddlSecTo.ClientID%>");
                    var ddlSecToChk = ddlsecT.options[ddlsecT.selectedIndex].text;
                    var hiddnstrid = document.getElementById("<%=hiddenstrid.ClientID%>").value;
                  
                    if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "0") {
                        if (document.getElementById("<%=HiddenOffDaySts.ClientID%>").value == "1") {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning, The Starting date you have  selected is offday  !";
                            document.getElementById("<%=HiddenOffDaySts.ClientID%>").value = "0";
                            ret = false;
                            }
                            ddlSecToIndexChanged();

                        }
                
                    if (document.getElementById("<%=hiddenHolidaychck.ClientID%>").value == 1) {
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Warning,  selected days were holidays  !";
                        document.getElementById("<%=hiddenHolidaychck.ClientID%>").value = 0;
                        document.getElementById("<%=HiddenOffDaySts.ClientID%>").value = 0;
                        ret = false;
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
                            if (dateDateCntrlr < datepresenrdate) {

                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,from date cant't be less than current year !";
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


                        }


                        if (dateToDte != "" && LeavDateFrm != "") {

                            var TaskdatepickerDate = document.getElementById("<%=TextDateTo.ClientID%>").value;
                            var arrDatePickerDate = TaskdatepickerDate.split("-");
                            var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                            var CurrentDateDate = document.getElementById("<%=txtDateFrom.ClientID%>").value;
                            var arrCurrentDate = CurrentDateDate.split("-");
                            var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                            if (document.getElementById("cphMain_cbxStatus").checked == true && document.getElementById("<%=hiddenOverRideLeavTypDate.ClientID%>").value != "") {

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
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, to date can't be less than current date !";
                                document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                                document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
                                document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "Red";
                                ret = false;

                            }

                            if (datepresenrdate > dateCurrentDate) {

                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, from date can't be less than current date !";
                               document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                                document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "";
                                ret = false;

                            }

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
                 
                   
                    if (ret == false) {

                        CheckSubmitZero();

                    }
                    else {
                        document.getElementById("<%=hiddenLeaveTypId.ClientID%>").value = document.getElementById("cphMain_ddlLeavTyp").value;
                        $('#cphMain_ddlLeavTyp').empty();
                        $('#cphMain_ddlLeavTyp').append("--SELECT LEAVE TYPE--");
                    }

                    //Start:-For checked family members
                    var RowCount = document.getElementById("<%=HiddenFieldCbxCount.ClientID%>").value;
                    for (var i = 0; i < RowCount; i++) {
                        var depntId = document.getElementById("DepntId" + i).innerHTML;
                        if (document.getElementById("cbx" + i).checked == true) {

                            var depntIds = document.getElementById("<%=HiddenFieldDepntIds.ClientID%>").value;
                            if (depntIds == '') {
                                document.getElementById("<%=HiddenFieldDepntIds.ClientID%>").value = depntId;

                            }
                            else {

                                document.getElementById("<%=HiddenFieldDepntIds.ClientID%>").value = document.getElementById("<%=HiddenFieldDepntIds.ClientID%>").value + ',' + depntId;
                            }
                        }
                    }
                    //End:-For checked family members
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

           
            //evm-0027 08-02-2019

            
            //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox


            function textCounter(field, maxlimit) {        
                RemoveTag();
               
              
               
                if (field.value.length > maxlimit) {
                    field.value = field.value.substring(0, maxlimit);
                } else {
                   // isTag(event);
                }
            }
            function RemoveTag() {

            
                var NameWithoutReplace = document.getElementById("<%=txtLvDesc.ClientID%>").value;

                 var replaceText1 = NameWithoutReplace.replace(/</g, "");
                 var replaceText2 = replaceText1.replace(/>/g, "");
                 document.getElementById("<%=txtLvDesc.ClientID%>").value = replaceText2;

                var NameWithoutReplace = document.getElementById("<%=txtLvDesc.ClientID%>").value;

                var replaceText1 = NameWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById("<%=txtLvDesc.ClientID%>").value = replaceText2;

                var NameWithoutReplace = document.getElementById("<%=txtAddrss.ClientID%>").value;
                var replaceText1 = NameWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById("<%=txtAddrss.ClientID%>").value = replaceText2;

                var NameWithoutReplace = document.getElementById("<%=txtCmnt.ClientID%>").value;
                var replaceText1 = NameWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById("<%=txtCmnt.ClientID%>").value = replaceText2;

                
                

            }
            function RemoveTag1(control)
            {
                
                var text = control.value;
                var replaceText1 = text.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                control.value = replaceText2;
            }
            //end
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

            function isNumber(evt) {
              
                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                var charCode = (evt.which) ? evt.which : evt.keyCode;

             
                //enter
                if (keyCodes == 13 || keyCodes == 16) {
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
                //    // . period and numpad . period
                //else if (keyCodes == 190 || keyCodes == 110) {
                //    var ret = true;

                //    var count = txtPerVal.split('.').length - 1;

                //    if (count > 0) {

                //        ret = false;
                //    }
                //    else {
                //        ret = true;
                //    }
                //    return ret;

                //}

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
            function clearselect() {
              
              
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



        function DateChk() {
            //  if (document.getElementById("<%=txtDateTrvl.ClientID%>").value != "") {
          //  document.getElementById('divMessageArea').style.display = "none";
            var datepickerDate1 = document.getElementById("<%=txtDateFrom.ClientID%>").value;
            var arrDatePickerDate1 = datepickerDate1.split("-");
            
            var dateTxIss1 = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);


            var dateCurrentDate = document.getElementById("<%=TextDateTo.ClientID%>").value;
                    var arrDateCurrentDate = dateCurrentDate.split("-");
                    var CurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);

                    var datepickerDate2 = document.getElementById("<%=txtDateTrvl.ClientID%>").value;
                    var arrDatePickerDate2 = datepickerDate2.split("-");
                    var dateofTravl = new Date(arrDatePickerDate2[2], arrDatePickerDate2[1] - 1, arrDatePickerDate2[0]);

                    var datepickerDate3 = document.getElementById("<%=txtDateRetrn.ClientID%>").value;
                    var arrDatePickerDate3 = datepickerDate3.split("-");
                    var dateReturn = new Date(arrDatePickerDate3[2], arrDatePickerDate3[1] - 1, arrDatePickerDate3[0]);




                if (document.getElementById("<%=cbxStatus.ClientID%>").checked == true) {
                    

                    if (datepickerDate2 != "" && datepickerDate1 != "" && dateCurrentDate != "") {
                        if (dateofTravl >= dateTxIss1 && dateofTravl <= CurrentDate) {
                            //alert("Sorry, issue date should be less than or equal to current date !");
                           
                    

                        }
                        else {
                            document.getElementById("<%=txtDateTrvl.ClientID%>").value = "";

                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, traveling date should be in leave period !";
                            document.getElementById("<%=txtDateTrvl.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtDateTrvl.ClientID%>").focus();
                        }
                    }
                    
                    if (datepickerDate3 != "" && datepickerDate1 != "" && dateCurrentDate != "")
                    {
                     
                        if (dateReturn >= dateTxIss1 && dateReturn <= CurrentDate) {
                            //alert("Sorry, issue date should be less than or equal to current date !");

                        }
                        else {
                            document.getElementById("<%=txtDateRetrn.ClientID%>").value = "";

                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, traveling date should be in leave period !";
                            document.getElementById("<%=txtDateRetrn.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtDateRetrn.ClientID%>").focus();
                          }

                    }
                }
                else {
                    if (datepickerDate2 != "" && datepickerDate1 != "") {
                        
                        if (datepickerDate1 != datepickerDate2) {
                           
                            //alert("Sorry, issue date should be less than or equal to current date !");
                            document.getElementById("<%=txtDateTrvl.ClientID%>").value = "";
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, traveling date should be in leave period !";
                            document.getElementById("<%=txtDateTrvl.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtDateTrvl.ClientID%>").focus();
                        }
                    }
                    if (datepickerDate3 != "" && datepickerDate1 != "") {
                        if (datepickerDate3 != datepickerDate2) {
                          
                            //alert("Sorry, issue date should be less than or equal to current date !");
                            document.getElementById("<%=txtDateRetrn.ClientID%>").value = "";
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, traveling date should be in leave period !";
                            document.getElementById("<%=txtDateRetrn.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtDateRetrn.ClientID%>").focus();
                        }
                    }
                }
            //  }
            if (datepickerDate3 != "" && datepickerDate2 != "") {
            
                  if (dateReturn < dateofTravl) {
                      // alert("Sorry, expiry date should be greater than issue date !");
                      document.getElementById("<%=txtDateRetrn.ClientID%>").value = "";
                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, date of travel should be less than date of return !";
                            document.getElementById("<%=txtDateRetrn.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=txtDateRetrn.ClientID%>").focus();
                   }
               }
               return false;

           }

                    </script>
   
    <%--FOR DATE TIME PICKER--%>
<script type="text/javascript" src="../../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>                      
<script type="text/javascript" src="../../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
<script type="text/javascript" src="../../../../JavaScript/Date/bootstrap-datepicker.js"></script>
<script type="text/javascript"src="../../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
<link href="../../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
<link href="../../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />

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
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
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

      <asp:HiddenField ID="hiddenEmployeeId" runat="server" />
      <asp:HiddenField ID="HiddenFieldDepntIds" runat="server" />
      <asp:HiddenField ID="HiddenFieldCbxCount" runat="server" />
     <asp:HiddenField ID="HiddenFieldTrvlDtlsVisible" runat="server" />  
      <asp:HiddenField ID="HiddenFieldConfirm" runat="server" />
      <asp:HiddenField ID="HiddenFieldShowCancel" runat="server" />
      <asp:HiddenField ID="HiddenFieldEmpType" runat="server" />
     <asp:HiddenField ID="HiddenFieldQryString" runat="server" />

    <asp:HiddenField ID="hiddenDutyoffunReturn" runat="server" />
     <asp:HiddenField ID="HiddenFieldOrg" runat="server" />
     <asp:HiddenField ID="HiddenFieldCorp" runat="server" />

     <asp:HiddenField ID="HiddenFieldDup" runat="server" />


      <asp:HiddenField ID="HiddenFieldCancelUsrRole" runat="server" />
     <asp:HiddenField ID="HiddenFieldHolidayChck" runat="server" />

     <asp:HiddenField ID="HiddenFieldExpiredSts" runat="server" />
      <asp:HiddenField ID="HiddenView" runat="server" />
     <asp:HiddenField ID="HiddenTrvlSts" runat="server" />
     <asp:HiddenField ID="hiddenDupWithWarningMsg" runat="server" />
     <asp:HiddenField ID="hiddenCurrentDate2" runat="server" />

    <asp:HiddenField ID="hiddenReportOffcr" runat="server" />
         <asp:HiddenField ID="HiddenOffDaySts" Value="0" runat="server" />
         <asp:HiddenField ID="HiddenOFfdaysSts"  Value="1" runat="server" />
     <asp:HiddenField ID="hiddenLeaveTypId" runat="server" />
    <asp:HiddenField ID="hiddenOverRideLeavTypDate" runat="server" />
    <asp:HiddenField ID="hiddenOverRidedLeavTyp" runat="server" />


     <asp:HiddenField ID="HiddenFieldPaidLeaveSts" Value="0" runat="server" />

      <%--EVM 0041--%>

      <asp:HiddenField ID="HiddenLevstrtdtholidaysts"  runat="server" />
    <asp:HiddenField ID="HiddenLevenddtholidaysts" runat="server" />
    <asp:HiddenField ID="HiddenLevstrtdtoffdaysts" runat="server" />
    <asp:HiddenField ID="HiddenLevenddtoffdaysts" runat="server" />

     <%--end--%>

      <%--Start:-Code0009--%>
    <asp:HiddenField ID="HiddenFieldHoliPaidSts"  Value="0" runat="server" />
    <asp:HiddenField ID="HiddenFieldOffPaidSts"  Value="0" runat="server" />
       <%--End:-Code0009--%>

    <div class="cont_rght">


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

                  
            <div class="eachform" style="width:49%;float: left;"> 
                 
                <div class="subform" style=" float: left; ">


                    <asp:CheckBox ID="cbxStatus" Text="" onchange="mulCbxChange();"  runat="server"  onkeydown="return DisableEnter(event)"  class="form2" />
                    <h2 style="margin-top:1%;">Leave For Multiple days</h2>
                  
                  
                  
                </div>
                

            </div>
             <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                
             <div class="eachform"  style="width:49%;float: right;">
                  <h2>Leave Type*</h2>
               
                  <asp:DropDownList ID="ddlLeavTyp" Height="30px" Width="54%" class="form1" onkeydown="return DisableEnter(event)" onchange="ddlLevtyponchge()" runat="server" Style="margin-right: 4%;"></asp:DropDownList>
               

            </div>
                    
           <%--     </ContentTemplate>
            </asp:UpdatePanel>--%>
         <div class="eachform" style="width:49%;float:left;">
              <h2>From Date*</h2>
               <div id="WaterCardExpiry" class="input-append date" style="font-family:Calibri;float:right;width:57.5%">
                 <asp:TextBox ID="txtDateFrom" AutoComplete="off"  class="textDate"  placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onblur="return ChangeDate();" onkeydown="return ChangeDate();" onchange="return ChangeDate();" onkeyup="return ChangeDate();"  Style="width:83%;height:23px; font-family: calibri;" ></asp:TextBox>  <%--emp25--%>

                        <input id= "imgDate" type="image" class="add-on" src="/Images/Icons/CalandarIcon.png"   runat="server" onblur="return ChangeDate();" onkeydown="return ChangeDate();" onchange="return ChangeDate();" onkeyup="return ChangeDate();" style=" height:17px; width:12px; cursor:pointer;" /><%--emp25--%>

                        <script type="text/javascript">
                            var $noCo = jQuery.noConflict();
                            var year = (new Date).getFullYear();
                            year = year + 2;
                            $noCo('#WaterCardExpiry').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(year, '0', '0'),
                                startDate: new Date(),

                            })



                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                   </div>

              <div class="eachform"  style="width:49%;float: right;">
                             <h2>Session From*</h2>    
                  <asp:DropDownList ID="ddlSecnFrom" Height="30px" Width="54%" class="form1" onkeydown="return DisableEnter(event)" onchange="return ddlSecToIndexChanged();" runat="server"   Style="margin-right: 4%; ">  
                         <asp:ListItem Text="--SELECT FROM--" Value="0"></asp:ListItem>
                     <asp:ListItem Text="FULL DAY" Value="1"></asp:ListItem>
                     <asp:ListItem Text="FIRST SESSION" Value="2"></asp:ListItem>
                      <asp:ListItem Text="SECOND SESSION" Value="3"></asp:ListItem>
                  </asp:DropDownList>

            </div>
                         
     
         <div class="eachform" style="width:49%;float:left;">
              <h2 id="hTodate" runat="server">To Date</h2>
               <div id="Div1" class="input-append date" style="font-family:Calibri;float:right;width:57.5%">
                 <asp:TextBox ID="TextDateTo" AutoComplete="off"  class="textDate"   placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onblur="return ddlSecToIndexChanged();" onkeydown="return ddlSecToIndexChanged();" onchange="return ddlSecToIndexChanged();" onkeyup="return ddlSecToIndexChanged();"  Style="width:83%;height:23px; font-family: calibri;" ></asp:TextBox>   <%--emp25--%>

                        <input id= "img1" type="image"  class="add-on" tabindex="-1" src="/Images/Icons/CalandarIcon.png"  runat="server" onblur="return ddlSecToIndexChanged();" onkeydown="return ddlSecToIndexChanged();" onchange="return ddlSecToIndexChanged();" onkeyup="return ddlSecToIndexChanged();" style=" height:17px; width:12px; cursor:pointer;" />    <%--emp25--%>

                        <script type="text/javascript">

                            var $noCon = jQuery.noConflict();
                            var year = (new Date).getFullYear();
                            year = year + 2;
                            $noCon('#Div1').datetimepicker({

                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                startDate: new Date(),
                                endDate: new Date(year, '0', '0'),
                                setDate: null


                            });


                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                   </div>
             <div class="eachform"  style="width:49%;float: right;">
                                <h2 id="hTosec" runat="server">Session To</h2>    
                  <asp:DropDownList ID="ddlSecTo" Height="30px" Width="54%" class="form1" onkeydown="return DisableEnter(event)"  onchange="return ddlSecToIndexChanged()"  runat="server" Style="margin-right: 4%;">

                        <asp:ListItem Text="--SELECT TO--" Value="0"></asp:ListItem>
                     <asp:ListItem Text="FULL DAY" Value="1"></asp:ListItem>
                     <asp:ListItem Text="FIRST SESSION" Value="2"></asp:ListItem>
                      <%--<asp:ListItem Text="SECOND SECTION" Value="3"></asp:ListItem>--%>
                  </asp:DropDownList>
               
            </div>
               
            <div class="eachform"" style="width:49%;">
                <h2>Number Of Leave Days</h2>

                 <asp:TextBox ID="NumOfLev" Enabled="false" Height="30px" Width="51.5%" class="form1" runat="server" MaxLength="12" Style="text-transform: uppercase;text-align:left; margin-right: 3%;border-color: white;background-color: #e3e3e3;"  ></asp:TextBox>
           
                </div>
              <div class="eachform" style="width: 49%; float: left;">
                    <h2>Description</h2>
                     <asp:TextBox ID="txtLvDesc" class="form1" runat="server" MaxLength="50" TextMode="MultiLine" Style="width: 51%; text-transform: uppercase; margin-right: 3.3%; height: 108px; resize:none;font-family: calibri;" onkeypress="return  isTagEnter(event);" onblur="return textCounter(cphMain_txtLvDesc,450)" onkeydown=" return textCounter(cphMain_txtLvDesc,450)"></asp:TextBox>    <%--emp25--%>
                                 
                </div>
              <div class="eachform"" style="width:49%;float: right;margin-top:-4.5%;">
                <h2>Balance Leave Count</h2>

                    <asp:TextBox ID="YearlyLev" Enabled="false" Height="30px" Width="51.5%" class="form1" runat="server" MaxLength="12" Style="text-transform: uppercase;text-align:left; margin-right: 3%;border-color: white;background-color: #e3e3e3;"  ></asp:TextBox>
              
                </div>
                                                                <div class="eachform"" style="width:49%;float: right">
                                          <div id="DivFixedAllowance" runat="server" style="">
                                                   <section style=">
                                                    <div   class="smart-form"> 
                                                          <h2>Include In Settlement</h2>
                                                        <%-- <label class="lblh2" for="inputPassword" style="margin-bottom:3px;width: 33%;float: left;">Fixed allowance Applicable</label>--%>
                                                          <%--     <div class="col-sm-8">--%>
                                                                        <div   class="smart-form" style="">    
                                                                                <label class="checkbox" style="/*! float: right; */margin-left: 15%;margin-bottom: 0%;">Yes
                                                                                <input type="checkbox" id="cbxSettlement" onkeypress="return DisableEnter(event)" runat="server" />
                                                                                <i  ></i> </label>
                                                                        </div>
                                                           <%--    </div>   --%>
                                                    </div>
                                            </section>
                                              </div>

</div>  

                <div class="eachform" style="width:49%;float: right;  margin-right:  24%;margin-top: -12%;"> 
                 
                <div  id="divcbdTrvlNd" class="subform" style=" float: right;  display:none; margin-top: 6%;">
                     
                        <h2 style="margin-top:1%;margin-right: 42%;">Travel Needed</h2>
                    
                    <asp:CheckBox ID="cbxTrvlSts" Text="" onchange="changeTrvlDtl();"  runat="server"  onkeydown="return DisableEnter(event)"  class="form2" Checked="true"/>
                   
                  <h2 style="margin-top:1%;"> Yes</h2>
                  
                </div>
                

            </div>
        
            <div id="divTravelDtls" style="display:none;">


                <div class="eachform"" >
               <h2 style="font-size: 20px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">Travel Details</h2>
            
              
                </div>

                 <div class="eachform"" style="width:49%;float:left;">
               <h2>Date of Travel*</h2>
               <div id="Div2" class="input-append date" style="font-family:Calibri;float:right;width:57.5%">
                 <asp:TextBox ID="txtDateTrvl" AutoComplete="off"  class="textDate"  placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onblur="return DateChk();"  Style="width:83%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <input id= "Image1" type="image"  class="add-on" src="/Images/Icons/CalandarIcon.png"  onblur="return DateChk();"  runat="server" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var $noCo = jQuery.noConflict();
                            var year = (new Date).getFullYear();
                            year = year + 2;
                            $noCo('#Div2').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(year, '0', '0'),
                                startDate: new Date(),

                            })



                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
           
                </div>
              <div class="eachform"" style="width:49%;float: right;">
               <h2>Sector/Destination</h2>  
                <%--  EVM-0027 08-02-2019--%>
               <asp:TextBox ID="txtDestntn"  Height="30px" Width="51.5%" class="form1" onkeypress="return  isTagEnter(event);" onblur="RemoveTag(cphMain_txtDestntn)"  runat="server" MaxLength="100" Style="text-transform: uppercase;text-align:left; margin-right: 3%;"  ></asp:TextBox>
                  <%--END--%>
              
                </div>

                  <div class="eachform"" style="width:49%;float:left;">
               <h2>Date of Return*</h2>
               <div id="Div3" class="input-append date" style="font-family:Calibri;float:right;width:57.5%">
                 <asp:TextBox ID="txtDateRetrn" class="textDate" AutoComplete="off"  placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onblur="return DateChk();"  onchange="return ddlSecToIndexChanged();"  Style="width:83%;height:23px; font-family: calibri;" ></asp:TextBox>
                    <%--  EVM-0027 08-02-2019--%>
                        <input id= "Image2" type="image"  class="add-on" src="/Images/Icons/CalandarIcon.png" onblur="return DateChk();"  runat="server" style=" height:17px; width:12px; cursor:pointer;" />
                    <%--END--%>
                        <script type="text/javascript">
                            var $noCo = jQuery.noConflict();
                            var year = (new Date).getFullYear();
                            year = year + 2;
                            $noCo('#Div3').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(year, '0', '0'),
                                startDate: new Date(),

                            })



                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
           
                </div>
              <div class="eachform"" style="width:49%;float: right;">
               <h2>Air Line Preferred</h2>
                 <%-- EVM-0027 08-02-2019--%>
               <asp:TextBox ID="txtAirLine"  Height="30px" Width="51.5%" class="form1" runat="server" onblur="RemoveTag1(cphMain_txtAirLine)" MaxLength="100" Style="text-transform: uppercase;text-align:left; margin-right: 3%;"  ></asp:TextBox>
                 <%-- END--%>
              
                </div>

                  <div class="eachform"" >
                  <h2 >Family members accompanied if any</h2>
                </div>
                 <div id="divFamlyDtls" runat="server" style="width:98.5%;"></div>

                <div class="eachform"" >
               <h2 style="font-size: 20px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">Contact Details During Leave</h2>   
                </div>

                 <div class="eachform" style="width: 49%; float: left;">
                    <h2>Address</h2>
                     <asp:TextBox ID="txtAddrss" class="form1" runat="server" MaxLength="50"   TextMode="MultiLine" Style="width: 50%; text-transform: uppercase; margin-right: 2.3%; height: 108px; resize:none;font-family: calibri;" onblur="textCounter(cphMain_txtAddrss,450)" onkeydown="textCounter(cphMain_txtAddrss,450)" onkeyup="textCounter(cphMain_txtAddrss,450)"></asp:TextBox>
                                 
                </div>
                <div class="eachform"" style="width:49%;float: right;">
               <h2>Tel No.* (Including Code)</h2>
               <asp:TextBox ID="txtTelNo"  Height="30px" Width="51.5%" class="form1" onblur="RemoveTag1(cphMain_txtTelNo)"  runat="server" MaxLength="20" Style="text-transform: uppercase;text-align:left; margin-right: 3%;"  onkeydown="return isNumber(event)"></asp:TextBox>         
                   <p class="error" id="ErrorTele" style="display: none;float: right;width: 268px; font-family: Calibri; font-size: small;">Please enter valid phone number</p>
                     </div>
                <div class="eachform"" style="width:49%;float: right;">
               <h2>Local Contact No. (Qatar)</h2>  <%--emp25--%>
               <asp:TextBox ID="txtLclCntctNo"  Height="30px" Width="51.5%" class="form1" onblur="RemoveTag1(cphMain_txtLclCntctNo)" runat="server" MaxLength="20" Style="text-transform: uppercase;text-align:left; margin-right: 3%;" onkeydown="return isNumber(event)" ></asp:TextBox>         
                    <p class="error" id="ErrorLclNum" style="display: none;float: right;width: 268px; font-family: Calibri; font-size: small;">Please enter valid contact number</p>
                </div>

               <div class="eachform"" style="width:49%;float: right;">
               <h2>Email Address</h2>
               <asp:TextBox ID="txtEmail"  Height="30px" Width="51.5%" class="form1" runat="server" onblur="RemoveTag1(cphMain_txtEmail)"  MaxLength="100" Style="text-align:left; margin-right: 3%;"  ></asp:TextBox>         
                   <p class="error" id="ErrorEnqEmail" style="display: none;float: right;width: 268px; font-family: Calibri; font-size: small;">Please enter valid email address</p> 
               </div>

                  <div class="eachform" >
                    <h2>Comment/Remark</h2>
                     <asp:TextBox ID="txtCmnt" class="form1" runat="server" MaxLength="50"  TextMode="MultiLine" Style="width: 75%; text-transform: uppercase; margin-left: 8.6%; height: 80px; resize:none;font-family: calibri;float:left;" onblur="textCounter(cphMain_txtCmnt,450)" onkeydown="textCounter(cphMain_txtCmnt,450)" onkeyup="textCounter(cphMain_txtCmnt,450)"></asp:TextBox>
                                 
                </div>
          

            <div class="eachform" style="width:49%;float: left;"> 
                 
                <div class="subform" style=" float: left; ">

                     
                    <asp:CheckBox ID="cbxNeedTckt" Text="" runat="server"  onkeydown="return DisableEnter(event)"  class="form2" />
                    <h2 style="margin-top:1%;">Need Travel Ticket</h2>
                  
                  
                  
                </div>
                

            </div>
                  </div>

            <br />
            <div class="eachform">
                <div class="subform" style="width: 62%; margin-top:5%">

                      <asp:Button ID="btnConfirm" runat="server" class="save" Text="Confirm" OnClick="btnConfirm_Click" OnClientClick="return WaterCardValidate();"/>
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return WaterCardValidate();"/>
                      <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return WaterCardValidate();"/>
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return WaterCardValidate();"/>
                     <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return WaterCardValidate();"/>
                     <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return CancelAlert();"/>
                 <asp:Button ID="btnClear" runat="server" style="margin-left: 13px;" OnClientClick="return AlertClearAll();" OnClick="btnClear_Click" class="cancel" Text="Clear"/>
                </div>
            </div>


            <div id="divStatus" class="eachform" style="float:left;width:55%;border: 1px solid;background-color: #e3e3e3;border-color: darkgrey;padding-left: 2%;display:none;" >
            <h2 style="font-size: 20px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;width:100%;">Status</h2>  
            <h2 id="status1" runat="server" style="font-size: 17px; font-weight: bold; color: rgb(224, 87, 24); font-family: Calibri;width:100%;"></h2> 
           <div id="divSts2">
                 <h2 id="status2" runat="server" style="font-size: 17px; font-weight: bold; color: rgb(224, 87, 24); font-family: Calibri;width:100%;word-break:break-all;"></h2> 
           </div> 
           </div>
            <div class="eachform" style="width:40%;float:right;">
                 <div  id="divAirptClose" runat="server" style="width: 30%;margin-left: 8%;margin-top: 4%;cursor:pointer;display:none;" onclick="CloseRqst()">
             <img id="imgAirptClose" runat="server" src="/Images/Icons/close guarantee.png" style="margin-left:23%;width:37%;"/>
             <%-- <h2 style="margin-top: 1%;font-size:15px;margin-left:10%;">Cancel Leave Request</h2>--%>
                     
               <h2 id="imgCaption" runat="server" style="margin-top: 1%;font-size:15px;margin-left:10%;display:normal">Cancel Leave Request</h2>
                     
              </div>

                 <asp:Button ID="btnClearanceLink" runat="server" class="save" Text="Go To Clearance Form" style="margin-left:8%;display:none;" OnClick="btnClrnceLink_Click"/>

            </div>

    </div>
    </div>
    <style>

.error {
               
              
               color: red;
               font-size: small;
             
                font-family: Calibri;
           }
    </style>
  <script>
         function ddlLevtyponchge() {
             IncrmntConfrmCounter();
          
             ddlSecToIndexChanged1();

             

             resetDatePickers();
             

             var LevTypId = document.getElementById("cphMain_ddlLeavTyp").value;
             var EmpId = document.getElementById("cphMain_hiddenEmployeeId").value;

             $.ajax({
                 url: "hcm_Leave_Request.aspx/LevTypOverRideDate",
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
         function ddlSecToIndexChanged1() {      //emp25

             var LeaveTypeId = document.getElementById("<%=ddlLeavTyp.ClientID%>").value;
             if (LeaveTypeId != "--SELECT LEAVE TYPE--" && LeaveTypeId != "") {

                 var Details = PageMethods.CheckTrvlDtlShow(LeaveTypeId, function (response) {
                     document.getElementById("<%=HiddenFieldHolidayChck.ClientID%>").value = response[1];

                     document.getElementById("<%=HiddenFieldPaidLeaveSts.ClientID%>").value = response[3];
                     //Start:-Code0009
                     document.getElementById("<%=HiddenFieldHoliPaidSts.ClientID%>").value = response[4];
                     document.getElementById("<%=HiddenFieldOffPaidSts.ClientID%>").value = response[5];
                     //End:-Code0009
                     
                     if (response[0] == "false") {

                         document.getElementById("divcbdTrvlNd").style.display = "none";

                         document.getElementById("divTravelDtls").style.display = "none";
                         document.getElementById("<%=HiddenFieldTrvlDtlsVisible.ClientID%>").value = "false";
                     }
                     else {
                         document.getElementById("divcbdTrvlNd").style.display = "block";

                         if (document.getElementById("<%=cbxTrvlSts.ClientID%>").checked == true) {


                             document.getElementById("divTravelDtls").style.display = "block";
                             document.getElementById("<%=HiddenFieldTrvlDtlsVisible.ClientID%>").value = "true";
                             ddlSecToIndexChanged();

                         }

                     }

                 });
             }
         }

      function ChangeDate() {

          LoadLeaveTypes();
          ddlSecToIndexChanged();
      }

      function LoadLeaveTypes() {

          var OrgId = '<%= Session["ORGID"] %>';
          var CorpId = '<%= Session["CORPOFFICEID"] %>';
          var EmpId = document.getElementById("cphMain_hiddenEmployeeId").value;
          var FromDate = document.getElementById("cphMain_txtDateFrom").value;
          var LeavTypId = document.getElementById("cphMain_hiddenLeaveTypId").value;

          $.ajax({
              url: "hcm_Leave_Request.aspx/LeavTypLoad",
              async: false,
              data: '{ CorpId:"' + CorpId + '", OrgId:"' + OrgId + '", EmpId:"' + EmpId + '", FromDate:"' + FromDate + '"}',
              dataType: "json",
              type: "POST",
              contentType: "application/json; charset=utf-8",
              success: function (data) {

                  if (data.d != "") {

                      $("#cphMain_ddlLeavTyp").empty();
                      $("#cphMain_ddlLeavTyp").append(data.d);

                      if (LeavTypId != "") {
                          $("#cphMain_ddlLeavTyp").val(LeavTypId);
                      }
                      else {
                          $("#cphMain_ddlLeavTyp").val("--SELECT LEAVE TYPE--");
                      }
                  }

              },
              failure: function (data) {
                  alert();
              },

          });
      }



      function ddlSecToIndexChanged() {    //emp25
        
          DateChk();
       
         
          var LeaveTypeId = document.getElementById("<%=ddlLeavTyp.ClientID%>").value;
          if (LeaveTypeId != "--SELECT LEAVE TYPE--" && LeaveTypeId != "") {
    

              if (document.getElementById("<%=cbxStatus.ClientID%>").checked == true) {
                  IncrmntConfrmCounter();

              }

                               //emp25
              
          
              var $noCon = jQuery.noConflict();



              var ret = true;
            
              document.getElementById("<%=hiddenConfirmValue.ClientID%>").value = "1";

              var LeavDateFrm = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();

              var EmpId = document.getElementById("<%=hiddenEmployeeId.ClientID%>").value;

              var LeavDateTo = document.getElementById("<%=TextDateTo.ClientID%>").value.trim();

              if (document.getElementById("<%=cbxStatus.ClientID%>").checked == true) {
                  IncrmntConfrmCounter();

                  if (LeavDateTo != "" && document.getElementById("<%=HiddenFieldDup.ClientID%>").value==false) {
                 
                      document.getElementById('divMessageArea').style.display = "none";
                      document.getElementById('imgMessageArea').src = "";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                      document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                      document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
                      document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "";
                  }
              }
              if (LeavDateFrm != "" && document.getElementById("<%=HiddenFieldDup.ClientID%>").value==false) {
                 // alert();
                  document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById('imgMessageArea').src = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("<%=YearlyLev.ClientID%>").style.borderColor = "";
                  document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
                  document.getElementById("<%=TextDateTo.ClientID%>").style.borderColor = "";

              }
              if (document.getElementById("<%=HiddenFieldDup.ClientID%>").value == true) {

                  DuplicationLevDate();
              }

              if (document.getElementById("<%=hiddenReportOffcr.ClientID%>").value == "1") {

                  CheckReportingOfficer();
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
              var total

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
                          if (document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value == "0") {
                              document.getElementById("<%=HiddenFieldHolidayChck.ClientID%>").value = "1";
                          }

                          if (document.getElementById("<%=HiddenFieldHolidayChck.ClientID%>").value != "0") {


                              document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";

                              var yerlylevcount = document.getElementById("<%=YearlyLev.ClientID%>").value;
                              var TaskdatepickerDate = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();
                              var RemaingLev = document.getElementById("<%=hiddenremaingLev.ClientID%>").value;
                              //evm 0041
                              DutyOfChkg(LeavDateFrom);
                              CountHoliday(LeavDateFrom);
                              CountHolidayEnddt(LeavDateTo);
                              DutyOfChkgEnddt(LeavDateTo);
                              //end
                              var countHoldy = document.getElementById("<%=hiddenfunReturn.ClientID%>").value;

                              if (countHoldy == 0) {
                                  var DutyOff = document.getElementById("<%=hiddenDutyoffunReturn.ClientID%>").value;
                                  if (DutyOff != 0) {
                                      document.getElementById('divMessageArea').style.display = "";
                                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,selected day is duty off!";
                                      document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                                  }
                                  if (seccalctn == 0) {
                                      seccalctn = 1;
                                  }
                                  // alert(seccalctn);
                                  document.getElementById("<%=NumOfLev.ClientID%>").value = seccalctn;
                                  document.getElementById("<%=hiddennoofleave.ClientID%>").value = seccalctn;



                                  if (dateFromdate.toDateString() == datepresenrdate.toDateString() || dateFromdate > datepresenrdate) {
                                      servcecall(LeavDateFrom, EmpId, LeavTypId);


                                      var yerlylevcount = document.getElementById("<%=YearlyLev.ClientID%>").value;
                                      if (DutyOff != 0) {
                                          if (seccalctn > yerlylevcount && yerlylevcount != 0) {

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

                          }

                      }

                  if (document.getElementById("<%=HiddenFieldPaidLeaveSts.ClientID%>").value == "1") {

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

              if (LeavDateFrm != "" && LeavDateTo != "" && ddlSecFrmChk != "--SELECT FROM--" && ddlSecToChk != "--SELECT TO--" && LeavTyp != "--SELECT LEAVE TYPE--" && LeavTyp != "") {

                 

                      var countFrmHoldy = 0;
                      var countToHoldy = 0;
                      var Dutyoff = 0;
                      DutyOfChkgdateRange(LeavDateFrom, LeaveDateTo);
                      // setTimeout(DutyOfChkgdateRange(LeavDateFrom, LeaveDateTo), 2000);

                      Dutyoff = document.getElementById("<%=hiddenDutyoffunReturn.ClientID%>").value;

              if (document.getElementById("<%=HiddenFieldPaidLeaveSts.ClientID%>").value == "1") {


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
      }
      function changeTrvlDtl()
      {
         
          if (document.getElementById("<%=cbxTrvlSts.ClientID%>").checked == true)
          {

              document.getElementById("divTravelDtls").style.display = "block";
           document.getElementById("<%=HiddenFieldTrvlDtlsVisible.ClientID%>").value = "true";
          }
          else
          {
           
              document.getElementById("divTravelDtls").style.display = "none";
          document.getElementById("<%=HiddenFieldTrvlDtlsVisible.ClientID%>").value = "false";

          }                 
      }

  </script>



     <script>

         var $noCo24 = jQuery.noConflict();
         function resetDatePickers() {
             var presenrdate = document.getElementById("<%=hiddenCurrentDate2.ClientID%>").value;                        
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
                startDate: PresentFulDate

            });


            var presenrdate =document.getElementById("<%=hiddenCurrentDate2.ClientID%>").value;
            var arrpresenrdate = presenrdate.split("-");
            var PresentFulDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
            PresentFulDate.setDate(PresentFulDate.getDate() + 2);


            $noCo24("#Div1").datetimepicker('destroy', '');

            var year = (new Date).getFullYear();
            year = year + 2;
            $noCo24('#Div1').datetimepicker({

                format: 'dd-MM-yyyy',
                language: 'en',
                pickTime: false,

                startDate: PresentFulDate,
                endDate: new Date(year, '0', '0'),
                setDate: null


            });

        }

    </script>


</asp:Content>

